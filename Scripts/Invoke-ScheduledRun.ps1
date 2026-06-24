<#
.SYNOPSIS
    Scheduled local test runner — called by Windows Task Scheduler.

.DESCRIPTION
    Runs a named test suite via dotnet test, writes all output to a dated log
    file under <repo>\TestResults\ScheduledLogs\, and exits with the dotnet
    exit code so Task Scheduler can report pass/fail.

.PARAMETER Suite
    Which suite to run:
        SFP          – Basic Policy smoke tests
        CE           – Country Estate smoke tests
        FormsCheck   – SFP + CE forms validation checks
        FormsCheck-SFP  – SFP forms only
        FormsCheck-CE   – Country Estate forms only

.PARAMETER Environment
    Target environment: QA | DEV | STG  (default: QA)

.EXAMPLE
    .\Scripts\Invoke-ScheduledRun.ps1 -Suite SFP
    .\Scripts\Invoke-ScheduledRun.ps1 -Suite FormsCheck-SFP -Environment QA
#>

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

$filterMap = @{
    "SFP"           = "TestCategory=SFP"
    "CE"            = "TestCategory=CE"
    "FormsCheck"    = "Category=FormsCheck"
    "FormsCheck-SFP"= "Category=FormsCheck&Category=SFP"
    "FormsCheck-CE" = "Category=FormsCheck&Category=CE"
}

$filter  = $filterMap[$Suite]
$trxFile = Join-Path $logDir "${Suite}_${timestamp}.trx"
$project = Join-Path $repoRoot "TestAutomation.csproj"

Write-Host ""
Write-Host "Running: dotnet test --filter `"$filter`""
Write-Host ""

dotnet test $project `
    --filter $filter `
    --logger "trx;LogFileName=$trxFile" `
    --no-build

$exitCode = $LASTEXITCODE

Write-Host ""
Write-Host "======================================================"
Write-Host "  Finished    : $(Get-Date)"
Write-Host "  Exit code   : $exitCode  $(if ($exitCode -eq 0) { '(PASSED)' } else { '(FAILED)' })"
Write-Host "  TRX report  : $trxFile"
Write-Host "======================================================"

Stop-Transcript

exit $exitCode
