<#
.SYNOPSIS
    Runs the SFP Basic Policy test across all 23 states and saves a TRX log.

.DESCRIPTION
    Adds --logger trx so NUnit captures per-test console output (including
    *** ANNUAL PREMIUM *** lines) into a structured XML file.

    After the run, use Extract-SFPPremiums.ps1 to pull premiums by state.

.PARAMETER NoBuild
    Pass -NoBuild to skip the dotnet build step (faster when code hasn't changed).

.EXAMPLE
    .\Scripts\run-sfp-basic.ps1
    .\Scripts\run-sfp-basic.ps1 -NoBuild
#>

param(
    [switch]$NoBuild
)

$projectRoot = Resolve-Path "$PSScriptRoot\.."
$timestamp   = Get-Date -Format "yyyy-MM-dd_HHmmss"
$trxPath     = "$projectRoot\bin\TestResults\SFP_BasicPolicy_$timestamp.trx"

Write-Host ""
Write-Host "=== SFP Basic Policy — All 23 States ===" -ForegroundColor Cyan
Write-Host "  Project : $projectRoot"
Write-Host "  TRX log : $trxPath"
Write-Host ""

$dotnetArgs = @(
    "test", "$projectRoot\TestAutomation.csproj",
    "--filter", "FullyQualifiedName~SFPBasicPolicy_State",
    "--logger", "trx;LogFileName=$trxPath"
)

if ($NoBuild) { $dotnetArgs += "--no-build" }

dotnet @dotnetArgs

Write-Host ""
if (Test-Path $trxPath) {
    Write-Host "TRX saved to: $trxPath" -ForegroundColor Green
    Write-Host "Run Extract-SFPPremiums.ps1 to get the premium list:" -ForegroundColor Yellow
    Write-Host "  .\Scripts\Extract-SFPPremiums.ps1 -TrxPath `"$trxPath`"" -ForegroundColor Yellow
} else {
    Write-Host "WARNING: TRX file not found — dotnet may not have written it to the expected path." -ForegroundColor Red
    Write-Host "Check bin\TestResults\ for a timestamped .trx file and pass it to Extract-SFPPremiums.ps1." -ForegroundColor Red
}
