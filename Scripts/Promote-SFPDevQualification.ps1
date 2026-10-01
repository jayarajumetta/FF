<#
.SYNOPSIS
    Validates and promotes reviewed MD/PA/VT DEV qualification artifacts.

.DESCRIPTION
    Dry-run by default. With -Approve, writes reviewed premiums to
    appsettings.Dev.json and appends approved MD/PA/VT columns to the canonical
    SFP_BASIC.csv and SFP_CE.csv files.

    Promotion is rejected unless all six tests passed with positive premiums and
    quote numbers, every forms status is explicit, and proposal form rows already
    exist in the canonical matrices. New/unclassified forms require manual review
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

function Get-MergedFormsCsv {
    param(
        [Parameter(Mandatory)][string]$CanonicalPath,
        [Parameter(Mandatory)][string]$ProposedPath
    )

    if (-not (Test-Path $ProposedPath)) {
        throw "Forms proposal not found: $ProposedPath"
    }

    $canonical = @(Get-Content $CanonicalPath)
    $proposed = @(Get-Content $ProposedPath)
    $canonicalHeader = $canonical[0].Split(",")
    $proposedHeader = $proposed[0].Split(",")
    $canonicalForms = @{}
    $proposedForms = @{}

    for ($i = 1; $i -lt $canonical.Count; $i++) {
        $parts = $canonical[$i].Split(",")
        $canonicalForms[$parts[1]] = $parts
    }
    for ($i = 1; $i -lt $proposed.Count; $i++) {
        $parts = $proposed[$i].Split(",")
        $proposedForms[$parts[1]] = $parts
    }

    $unexpected = @($proposedForms.Keys | Where-Object {
        -not $canonicalForms.ContainsKey($_)
    })
    if ($unexpected.Count -gt 0) {
        throw "Proposal contains new forms requiring manual BASE/BASIC/CE classification: " +
              ($unexpected -join ", ")
    }

    foreach ($state in $expectedStates) {
        if ($canonicalHeader -contains $state) {
            throw "$CanonicalPath already contains $state; refusing to overwrite."
        }
        if ($proposedHeader -notcontains $state) {
            throw "$ProposedPath is missing the $state column."
        }
    }

    $merged = [System.Collections.Generic.List[string]]::new()
    $merged.Add(($canonicalHeader + $expectedStates) -join ",")

    for ($i = 1; $i -lt $canonical.Count; $i++) {
        $parts = $canonical[$i].Split(",")
        $form = $parts[1]
        if (-not $proposedForms.ContainsKey($form)) {
            throw "Proposal is missing canonical form $form."
        }

        $proposalRow = $proposedForms[$form]
        $values = foreach ($state in $expectedStates) {
            $index = [Array]::IndexOf($proposedHeader, $state)
            $value = $proposalRow[$index]
            if ($value -notin @("YM", "YS", "YU", "N")) {
                throw "$ProposedPath has invalid/blank $state status '$value' for $form."
            }
            $value
        }
        $merged.Add(($parts + $values) -join ",")
    }

    return $merged.ToArray()
}

$basicCanonical = Join-Path $projectRoot "Resources\ExpectedForms\SFP\SFP_BASIC.csv"
$ceCanonical = Join-Path $projectRoot "Resources\ExpectedForms\SFP\SFP_CE.csv"
$basicMerged = Get-MergedFormsCsv `
    -CanonicalPath $basicCanonical `
    -ProposedPath (Join-Path $qualification "SFP_BASIC_PROPOSED.csv")
$ceMerged = Get-MergedFormsCsv `
    -CanonicalPath $ceCanonical `
    -ProposedPath (Join-Path $qualification "SFP_CE_PROPOSED.csv")

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
Write-Host "  Forms targets  : Resources\ExpectedForms\SFP\SFP_BASIC.csv"
Write-Host "                   Resources\ExpectedForms\SFP\SFP_CE.csv"

if (-not $Approve) {
    Write-Host ""
    Write-Host "Dry run only; no versioned files changed." -ForegroundColor Cyan
    Write-Host "After human review, rerun with -Approve."
    exit 0
}

$basicMerged | Set-Content -Path $basicCanonical -Encoding utf8
$ceMerged | Set-Content -Path $ceCanonical -Encoding utf8
$devConfig | ConvertTo-Json -Depth 10 | Set-Content -Path $devConfigPath -Encoding utf8

Write-Host ""
Write-Host "Approved DEV baselines promoted. Review git diff and run targeted tests before commit." -ForegroundColor Green
