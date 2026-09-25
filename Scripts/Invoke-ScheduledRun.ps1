<#
.SYNOPSIS
    Scheduled local test runner — called by Windows Task Scheduler.

.DESCRIPTION
    Builds one validated package and runs its canonical shard runner. All output
    is written to a dated log under <repo>\TestResults\ScheduledLogs\.

.PARAMETER Suite
    Which suite to run:
        SFP          – Basic Policy smoke tests
        CE           – Country Estate smoke tests
        FormsCheck   – current SFP forms validation check
        FormsCheck-SFP  – SFP forms only
        FormsCheck-CE   – retired; fails because no CE forms-only case exists

.PARAMETER Environment
    Target environment: QA | DEV | STG  (default: QA)

.EXAMPLE
    .\Scripts\Invoke-ScheduledRun.ps1 -Suite SFP
    .\Scripts\Invoke-ScheduledRun.ps1 -Suite FormsCheck-SFP -Environment QA
#>

#requires -Version 7.2
param(
    [Parameter(Mandatory)]
    [ValidateSet("SFP", "CE", "FormsCheck", "FormsCheck-SFP", "FormsCheck-CE")]
    [string]$Suite,

    [ValidateSet("QA", "DEV", "STG")]
    [string]$Environment = "QA"
)

$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest

$repoRoot  = Resolve-Path "$PSScriptRoot\.."
$timestamp = Get-Date -Format "yyyy-MM-dd_HHmmss"
$logDir    = Join-Path $repoRoot "TestResults\ScheduledLogs"
$logFile   = Join-Path $logDir "${Suite}_${timestamp}.log"

New-Item -ItemType Directory -Force -Path $logDir | Out-Null

# Redirect all output to both console and log file
$null = Start-Transcript -Path $logFile -Append

Write-Host "======================================================"
Write-Host "  Suite       : $Suite"
Write-Host "  Environment : $Environment"
Write-Host "  Start time  : $(Get-Date)"
Write-Host "  Log         : $logFile"
Write-Host "======================================================"

$env:TEST_ENVIRONMENT = $Environment

$suiteMap = @{
    "SFP"            = "BasicPolicy"
    "CE"             = "CE"
    "FormsCheck"     = "Forms"
    "FormsCheck-SFP" = "Forms"
}

if ($Suite -eq "FormsCheck-CE") {
    Write-Error "FormsCheck-CE is retired because the repository contains no CE-tagged forms-only cases."
    Stop-Transcript
    exit 1
}

$packageSuite = $suiteMap[$Suite]
$runOutput = Join-Path $repoRoot "TestResults\ScheduledPackageRuns"
$exitCode = 0
try {
    & (Join-Path $repoRoot "Scripts\CI\Invoke-PackageSuite.ps1") `
        -Suite $packageSuite `
        -Mode Full `
        -OutputDirectory $runOutput `
        -InstallBrowser
}
catch {
    Write-Error $_
    $exitCode = 1
}

Write-Host ""
Write-Host "======================================================"
Write-Host "  Finished    : $(Get-Date)"
Write-Host "  Exit code   : $exitCode  $(if ($exitCode -eq 0) { '(PASSED)' } else { '(FAILED)' })"
Write-Host "  Results root: $runOutput"
Write-Host "======================================================"

Stop-Transcript

exit $exitCode
