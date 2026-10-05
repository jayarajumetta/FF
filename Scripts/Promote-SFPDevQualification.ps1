#requires -Version 7.4
<#
.SYNOPSIS
    Validates and promotes reviewed MD/PA/VT DEV qualification artifacts.

.DESCRIPTION
    Dry-run by default. With -Approve, writes reviewed premiums to
    appsettings.Dev.json and adds approved MD/PA/VT states to SFP.json.

    Promotion is rejected unless all six tests passed with positive premiums and
    quote numbers, every forms status is explicit, and proposal form rows already
    exist in the canonical JSON scenarios. New/unclassified forms require manual review
    and classification before this script can write.
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory)][string]$QualificationDirectory,
    [switch]$Approve
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

$projectRoot = (Resolve-Path "$PSScriptRoot\..").Path
$qualification = (Resolve-Path $QualificationDirectory).Path
$premiumPath = Join-Path $qualification "SFP_DEV_Qualification.premiums.csv"
$expectedStates = @("MD", "PA", "VT")
$expectedVariants = @("BASIC", "CE")

if (-not (Test-Path $premiumPath)) {
    throw "Premium capture not found: $premiumPath"
}

$premiums = @(Import-Csv $premiumPath)
foreach ($variant in $expectedVariants) {
    foreach ($state in $expectedStates) {
        $matches = @($premiums | Where-Object {
            $_.Variant -eq $variant -and $_.State -eq $state
        })
        if ($matches.Count -ne 1) {
            throw "Expected exactly one $variant/$state premium capture; found $($matches.Count)."
        }

        $row = $matches[0]
        $amount = [decimal]0
        $premiumParsed = [decimal]::TryParse(
            $row.Premium,
            [Globalization.NumberStyles]::Number,
            [Globalization.CultureInfo]::InvariantCulture,
            [ref]$amount)
        if (($row.Outcome -ne "Passed") -or (-not $premiumParsed) -or
            ($amount -le 0) -or ($row.Quote -notmatch "^\d{7,9}$")) {
            throw "$variant/$state is not promotable: outcome=$($row.Outcome), " +
                  "premium='$($row.Premium)', quote='$($row.Quote)'."
        }
    }
}

$canonicalPath = Join-Path $projectRoot "Resources\ExpectedForms\SFP\SFP.json"
$canonicalText = Get-Content -LiteralPath $canonicalPath -Raw
$canonical = $canonicalText | ConvertFrom-Json -AsHashtable
. (Join-Path $PSScriptRoot "Get-FormsValidationRuntime.ps1")
$validator = (Get-FormsValidationRuntime).Validator
$captures = @{}
foreach ($variant in $expectedVariants) {
    $template = $validator.ParseSfpJson($canonicalText, $canonical.STATES[$variant][0], $variant)
    $captures[$variant] = @{}
    $proposalPath = Join-Path $qualification "SFP_${variant}_PROPOSED.json"
    $proposalText = Get-Content -LiteralPath $proposalPath -Raw
    foreach ($state in $expectedStates) {
        if ($canonical.STATES[$variant] -contains $state) {
            throw "SFP.json already contains $variant/$state; refusing to overwrite."
        }
        $proposal = $validator.ParseSfpJson($proposalText, $state, $variant)
        if (@(Compare-Object -ReferenceObject @($template.FormName) -DifferenceObject @($proposal.FormName) -CaseSensitive).Count -ne 0) {
            throw "$variant proposal forms differ from the canonical scenario; manual classification/review is required."
        }
        $values = @{}
        foreach ($entry in $proposal) { $values[$entry.FormName] = $entry.ExpectedStatus }
        $captures[$variant][$state] = $values
    }
}

function Get-ExistingStatus($definition, [string]$state) {
    if ($definition -is [string]) { return "YM" }
    if ($definition -is [System.Collections.IDictionary]) {
        if ($definition.Contains($state)) { return $definition[$state] }
        return "N"
    }
    if ($definition -contains $state) { return "YM" }
    return "N"
}

foreach ($section in @("BASE", "BASIC", "CE")) {
    $oldStates = if ($section -eq "BASE") {
        @($canonical.STATES.BASIC + $canonical.STATES.CE | Sort-Object -Unique)
    } else { @($canonical.STATES[$section]) }
    foreach ($form in @($canonical[$section].Keys)) {
        $statuses = [ordered]@{}
        foreach ($state in $oldStates) {
            $statuses[$state] = Get-ExistingStatus $canonical[$section][$form] $state
        }
        foreach ($state in $expectedStates) {
            $variant = if ($section -eq "BASE") { "BASIC" } else { $section }
            $value = $captures[$variant][$state][$form]
            if ($section -eq "BASE" -and $value -cne $captures.CE[$state][$form]) {
                throw "Shared form $form differs between BASIC and CE for $state; review scenario classification before promotion."
            }
            $statuses[$state] = $value
        }
        $canonical[$section][$form] = $statuses
    }
}
foreach ($variant in $expectedVariants) {
    $canonical.STATES[$variant] = @($canonical.STATES[$variant] + $expectedStates | Sort-Object -Unique)
}
$mergedJson = $canonical | ConvertTo-Json -Depth 10
foreach ($variant in $expectedVariants) {
    foreach ($state in $canonical.STATES[$variant]) {
        [void]$validator.ParseSfpJson($mergedJson, $state, $variant)
    }
}

$devConfigPath = Join-Path $projectRoot "appsettings.Dev.json"
$devConfig = Get-Content $devConfigPath -Raw | ConvertFrom-Json
if (-not $devConfig.PSObject.Properties["ExpectedPremiums"]) {
    $devConfig | Add-Member NoteProperty ExpectedPremiums ([pscustomobject]@{})
}

foreach ($variant in $expectedVariants) {
    $product = if ($variant -eq "BASIC") { "SFP" } else { "CE" }
    if (-not $devConfig.ExpectedPremiums.PSObject.Properties[$product]) {
        $devConfig.ExpectedPremiums | Add-Member NoteProperty $product ([pscustomobject]@{})
    }
    foreach ($state in $expectedStates) {
        $row = $premiums | Where-Object {
            $_.Variant -eq $variant -and $_.State -eq $state
        }
        $value = [decimal]::Parse(
            $row.Premium,
            [Globalization.CultureInfo]::InvariantCulture)
        $devConfig.ExpectedPremiums.$product |
            Add-Member NoteProperty $state ([pscustomobject]@{ Amount = $value }) -Force
    }
}

Write-Host ""
Write-Host "Validated qualification artifacts for all six DEV cases." -ForegroundColor Green
Write-Host "  Premium target : appsettings.Dev.json"
Write-Host "  Forms target   : Resources\ExpectedForms\SFP\SFP.json"

if (-not $Approve) {
    Write-Host ""
    Write-Host "Dry run only; no versioned files changed." -ForegroundColor Cyan
    Write-Host "After human review, rerun with -Approve."
    exit 0
}

$mergedJson | Set-Content -LiteralPath $canonicalPath -Encoding utf8
$devConfig | ConvertTo-Json -Depth 10 | Set-Content -Path $devConfigPath -Encoding utf8

Write-Host ""
Write-Host "Approved DEV baselines promoted. Review git diff and run targeted tests before commit." -ForegroundColor Green
