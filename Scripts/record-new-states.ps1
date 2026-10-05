<#
.SYNOPSIS
    Runs the six DEV-only SFP qualification cases and captures premium/forms evidence.

.DESCRIPTION
    Loads appsettings.RecordBaseline.json, which routes Expert Quote and DuckCreek
    to DEV, enables forms record mode, and allows only MD, PA, and VT. The
    TestCategory=DevOnly filter selects Basic and Country Estate for all three states.

    The run captures:
      - one TRX with quote numbers and annual premiums;
      - one extracted premiums CSV;
      - SFP_BASIC_PROPOSED.json and SFP_CE_PROPOSED.json;
      - the raw DuckCreek Forms XML files produced during this run.

    Existing premium baselines are not required. Missing premiums are logged as
    captures, not asserted or promoted. Proposed forms remain outside the versioned
    baseline until reviewed and explicitly promoted.

.PARAMETER NoBuild
    Skip the dotnet build step.

.PARAMETER ResetProposed
    Delete only the two generated proposal files in bin\Debug before recording.
    Without this switch, the script stops if stale proposal files exist.

.EXAMPLE
    .\Scripts\record-new-states.ps1 -ResetProposed
#>

[CmdletBinding()]
param(
    [switch]$NoBuild,
    [switch]$ResetProposed
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

$projectRoot = (Resolve-Path "$PSScriptRoot\..").Path
$timestamp = Get-Date -Format "yyyy-MM-dd_HHmmss"
$artifactDir = Join-Path $projectRoot "TestResults\DevQualification\$timestamp"
$trxName = "SFP_DEV_Qualification.trx"
$trxPath = Join-Path $artifactDir $trxName
$outputRoot = Join-Path $projectRoot "bin\Debug\net8.0"
$formsRoot = Join-Path $outputRoot "Resources\ExpectedForms\SFP"
$proposalPaths = @(
    (Join-Path $formsRoot "SFP_BASIC_PROPOSED.json"),
    (Join-Path $formsRoot "SFP_CE_PROPOSED.json")
)

$recordProfilePath = Join-Path $projectRoot "appsettings.RecordBaseline.json"
$recordProfile = Get-Content -LiteralPath $recordProfilePath -Raw | ConvertFrom-Json
$allowedStates = @($recordProfile.StateFilters.DevAllowedStates | Sort-Object)
$requiredStates = @("MD", "PA", "VT")
if ($recordProfile.Environment -ne "Dev") {
    throw "RecordBaseline profile must target Dev; found '$($recordProfile.Environment)'."
}
if (-not $recordProfile.Debugging.RecordBaseline) {
    throw "RecordBaseline profile must enable Debugging.RecordBaseline."
}
if (@(Compare-Object $requiredStates $allowedStates).Count -ne 0) {
    throw "RecordBaseline profile must allow exactly MD, PA, and VT. Found: $($allowedStates -join ', ')."
}

New-Item -ItemType Directory -Force -Path $artifactDir | Out-Null

$stale = @($proposalPaths | Where-Object { Test-Path $_ })
if ($stale.Count -gt 0 -and -not $ResetProposed) {
    throw "Existing proposal files would contaminate this qualification run. " +
          "Review/archive them, or rerun with -ResetProposed."
}
if ($ResetProposed) {
    foreach ($path in $proposalPaths) {
        if (Test-Path $path) {
            Remove-Item -LiteralPath $path
        }
    }
}

Write-Host ""
Write-Host "=== SFP DEV Qualification Capture ===" -ForegroundColor Cyan
Write-Host "  Cases     : Basic + CE for MD, PA, VT (6 total)"
Write-Host "  Filter    : TestCategory=DevOnly"
Write-Host "  Profile   : RecordBaseline (Environment=Dev)"
Write-Host "  Preflight : DEV confirmed; allowed states MD, PA, VT; forms recording enabled"
Write-Host "  Artifacts : $artifactDir"
Write-Host ""

$previousEnvironment = $env:TEST_ENVIRONMENT
$env:TEST_ENVIRONMENT = "RecordBaseline"

try {
    $dotnetArgs = @(
        "test", (Join-Path $projectRoot "TestAutomation.csproj"),
        "--filter", "TestCategory=DevOnly",
        "--logger", "trx;LogFileName=$trxName",
        "--results-directory", $artifactDir
    )
    if ($NoBuild) {
        $dotnetArgs += "--no-build"
    }

    & dotnet @dotnetArgs
    $testExitCode = $LASTEXITCODE
}
finally {
    if ($null -eq $previousEnvironment) {
        Remove-Item Env:TEST_ENVIRONMENT -ErrorAction SilentlyContinue
    }
    else {
        $env:TEST_ENVIRONMENT = $previousEnvironment
    }
}

if (-not (Test-Path $trxPath)) {
    throw "The qualification run did not produce $trxPath."
}

& (Join-Path $PSScriptRoot "Extract-SFPPremiums.ps1") -TrxPath $trxPath

foreach ($path in $proposalPaths) {
    if (Test-Path $path) {
        Copy-Item -LiteralPath $path -Destination $artifactDir -Force
    }
}

$rawFormsDir = Join-Path $artifactDir "FormsXml"
New-Item -ItemType Directory -Force -Path $rawFormsDir | Out-Null
$premiumPath = [IO.Path]::ChangeExtension($trxPath, "premiums.csv")
$successfulCases = @(Import-Csv -LiteralPath $premiumPath | Where-Object Outcome -eq "Passed")
$formsResultsRoots = @(
    (Join-Path $projectRoot "TestResults\FormsCheck\SFP"),
    (Join-Path $outputRoot "TestResults\FormsCheck\SFP")
)
$missingRawForms = @()
foreach ($case in $successfulCases) {
    $expectedName = "SFP_$($case.Variant)_$($case.State)_$($case.Quote).xml"
    $matches = @(
        foreach ($root in $formsResultsRoots) {
            if (Test-Path $root) {
                Get-ChildItem -LiteralPath $root -Filter $expectedName -File
            }
        }
    )

    if ($matches.Count -eq 0) {
        $missingRawForms += $expectedName
        continue
    }

    $source = $matches | Sort-Object LastWriteTime -Descending | Select-Object -First 1
    Copy-Item -LiteralPath $source.FullName -Destination $rawFormsDir -Force
}
$rawForms = @(Get-ChildItem -LiteralPath $rawFormsDir -Filter "SFP_*.xml")

$requiredArtifacts = @(
    $trxPath,
    ([IO.Path]::ChangeExtension($trxPath, "premiums.csv")),
    (Join-Path $artifactDir "SFP_BASIC_PROPOSED.json"),
    (Join-Path $artifactDir "SFP_CE_PROPOSED.json")
)
$missing = @($requiredArtifacts | Where-Object { -not (Test-Path $_) })

Write-Host ""
Write-Host "=== Capture Complete ===" -ForegroundColor Cyan
Write-Host "  Test exit code : $testExitCode"
Write-Host "  TRX            : $trxPath"
Write-Host "  Premiums       : $([IO.Path]::ChangeExtension($trxPath, 'premiums.csv'))"
Write-Host "  Forms proposals: $artifactDir\SFP_BASIC_PROPOSED.json"
Write-Host "                   $artifactDir\SFP_CE_PROPOSED.json"
Write-Host "  Raw forms XML  : $rawFormsDir"

if ($missing.Count -gt 0) {
    Write-Error "Qualification is incomplete. Missing artifacts:`n  $($missing -join "`n  ")"
    exit 1
}
if ($missingRawForms.Count -gt 0 -or $rawForms.Count -ne $successfulCases.Count) {
    $missingDetail = if ($missingRawForms.Count -gt 0) {
        " Missing: $($missingRawForms -join ', ')."
    } else {
        ""
    }
    Write-Error "Qualification is incomplete. Expected one raw Forms XML file for each of the $($successfulCases.Count) successful baseline cases; found $($rawForms.Count).$missingDetail"
    exit 1
}
if ($testExitCode -ne 0) {
    Write-Error "One or more DEV qualification cases failed. Review the TRX; do not promote."
    exit $testExitCode
}

Write-Host ""
Write-Host "Review every quote, premium, and JSON state expectation before promotion." -ForegroundColor Yellow
Write-Host "Dry-run promotion:"
Write-Host "  .\Scripts\Promote-SFPDevQualification.ps1 -QualificationDirectory `"$artifactDir`""
Write-Host "Approved promotion:"
Write-Host "  .\Scripts\Promote-SFPDevQualification.ps1 -QualificationDirectory `"$artifactDir`" -Approve"
