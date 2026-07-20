<#
.SYNOPSIS
    Runs SFP CE and Basic Policy for DE, GA, MA, ME and captures the DuckCreek
    forms responses as proposed baselines.

.DESCRIPTION
    Sets TEST_ENVIRONMENT=RecordBaseline so appsettings.RecordBaseline.json is
    loaded, enabling Debugging:RecordBaseline=true. The forms validation step
    then calls SaveProposedBaseline instead of comparing against the existing
    baseline, producing:

        Resources/ExpectedForms/SFP/SFP_CE_PROPOSED.csv
        Resources/ExpectedForms/SFP/SFP_BASIC_PROPOSED.csv

    Review those two files, then add the new state data into SFP.json
    (add DE/GA/MA/ME to the state arrays of any form whose column shows YM/YS/YU).

.PARAMETER NoBuild
    Skip the dotnet build step (faster when code has not changed).

.EXAMPLE
    .\Scripts\record-new-states.ps1
    .\Scripts\record-new-states.ps1 -NoBuild
#>

param(
    [switch]$NoBuild
)

$projectRoot = Resolve-Path "$PSScriptRoot\.."
$timestamp   = Get-Date -Format "yyyy-MM-dd_HHmmss"
$trxDir      = "$projectRoot\bin\TestResults"

# State filter — matches SpecFlow test display names that include the state name
$stateFilter = "Delaware|Georgia|Massachusetts|Maine"

Write-Host ""
Write-Host "=== SFP New-State Baseline Recorder ===" -ForegroundColor Cyan
Write-Host "  States    : DE, GA, MA, ME"
Write-Host "  Mode      : RecordBaseline (forms captured, not compared)"
Write-Host "  Project   : $projectRoot"
Write-Host ""

$env:TEST_ENVIRONMENT = "RecordBaseline"

try {
    # ── CE ───────────────────────────────────────────────────────────────────────
    $ceTrx = "$trxDir\SFP_CE_NewStates_$timestamp.trx"
    Write-Host "--- Running SFP CE for new states ---" -ForegroundColor Yellow

    $ceArgs = @(
        "test", "$projectRoot\TestAutomation.csproj",
        "--filter", "(FullyQualifiedName~SFPCountryEstatePolicy_State)&(FullyQualifiedName~Delaware|FullyQualifiedName~Georgia|FullyQualifiedName~Massachusetts|FullyQualifiedName~Maine)",
        "--logger", "trx;LogFileName=$ceTrx"
    )
    if ($NoBuild) { $ceArgs += "--no-build" }
    dotnet @ceArgs

    # ── Basic ────────────────────────────────────────────────────────────────────
    $basicTrx = "$trxDir\SFP_Basic_NewStates_$timestamp.trx"
    Write-Host ""
    Write-Host "--- Running SFP Basic Policy for new states ---" -ForegroundColor Yellow

    $basicArgs = @(
        "test", "$projectRoot\TestAutomation.csproj",
        "--filter", "(FullyQualifiedName~SFPBasicPolicy_State)&(FullyQualifiedName~Delaware|FullyQualifiedName~Georgia|FullyQualifiedName~Massachusetts|FullyQualifiedName~Maine)",
        "--logger", "trx;LogFileName=$basicTrx"
    )
    if ($NoBuild) { $basicArgs += "--no-build" }
    dotnet @basicArgs
}
finally {
    Remove-Item Env:TEST_ENVIRONMENT -ErrorAction SilentlyContinue
}

Write-Host ""
Write-Host "=== Done ===" -ForegroundColor Green
Write-Host ""

$ceProposed    = "$projectRoot\bin\Debug\net8.0\Resources\ExpectedForms\SFP\SFP_CE_PROPOSED.csv"
$basicProposed = "$projectRoot\bin\Debug\net8.0\Resources\ExpectedForms\SFP\SFP_BASIC_PROPOSED.csv"

foreach ($f in @($ceProposed, $basicProposed)) {
    if (Test-Path $f) {
        Write-Host "  Proposed baseline : $f" -ForegroundColor Green
    }
}

Write-Host ""
Write-Host "Next steps:" -ForegroundColor Cyan
Write-Host "  1. Review the PROPOSED CSV files above."
Write-Host "  2. For each form where a new state column shows YM/YS/YU,"
Write-Host "     add that state abbreviation to its array in SFP.json."
Write-Host "  3. Run this script again (without -RecordBaseline) to verify"
Write-Host "     the new states pass forms validation."
