<#
.SYNOPSIS
    Registers Windows Task Scheduler tasks to replace the removed ADO pipeline schedules.

.DESCRIPTION
    Creates two scheduled package-runner tasks under "PnC Test Automation":

        PnC-SFP-NightlySmoke   - every day 04:00 AM
        PnC-CE-NightlySmoke    - every day 04:30 AM

    Run this script ONCE on the server/machine where tests should execute.
    Must be run as Administrator (Task Scheduler requires elevation to create tasks).

.PARAMETER RepoRoot
    Full path to the repository root.
    Default: parent folder of this script.

.PARAMETER Environment
    Target test environment: QA | DEV | STG  (default: QA)

.PARAMETER RunAs
    Windows account the tasks will run under.
    Default: current logged-in user (DOMAIN\username).

.PARAMETER Disable
    Pass -Disable to remove / unregister both tasks instead of creating them.

.EXAMPLE
    # Register tasks (run as Administrator)
    .\Scripts\Register-ScheduledRuns.ps1

    # Register against a different environment
    .\Scripts\Register-ScheduledRuns.ps1 -Environment STG

    # Remove all tasks
    .\Scripts\Register-ScheduledRuns.ps1 -Disable
#>

[CmdletBinding(SupportsShouldProcess)]
param(
    [string]$RepoRoot   = (Resolve-Path "$PSScriptRoot\..").Path,
    [ValidateSet("QA","DEV","STG")]
    [string]$Environment = "QA",
    [string]$RunAs      = "$env:USERDOMAIN\$env:USERNAME",
    [switch]$Disable
)

$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest

# ── Verify elevation ─────────────────────────────────────────────────────────
$isAdmin = ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole(
    [Security.Principal.WindowsBuiltInRole]::Administrator)
if (-not $isAdmin) {
    Write-Error "This script must be run as Administrator. Right-click PowerShell → Run as Administrator."
    exit 1
}

$taskFolder = "PnC Test Automation"
$runner     = Join-Path $RepoRoot "Scripts\Invoke-ScheduledRun.ps1"
$pwsh       = (Get-Command pwsh -ErrorAction SilentlyContinue)?.Source ?? "pwsh"

# ── Task definitions ─────────────────────────────────────────────────────────
$tasks = @(
    @{
        Name        = "PnC-SFP-NightlySmoke"
        Description = "SFP Basic Policy smoke tests — daily 4:00 AM"
        Suite       = "SFP"
        Time        = "04:00"
        DaysOfWeek  = @("Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday")
    },
    @{
        Name        = "PnC-CE-NightlySmoke"
        Description = "Country Estate smoke tests — daily 4:30 AM"
        Suite       = "CE"
        Time        = "04:30"
        DaysOfWeek  = @("Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday")
    }
)

# ── Ensure task folder exists ────────────────────────────────────────────────
$schedService = New-Object -ComObject Schedule.Service
$schedService.Connect()
$rootFolder = $schedService.GetFolder("\")
try {
    $null = $rootFolder.GetFolder($taskFolder)
} catch {
    $null = $rootFolder.CreateFolder($taskFolder)
    Write-Host "Created Task Scheduler folder: $taskFolder" -ForegroundColor Cyan
}

foreach ($t in $tasks) {
    $fullName = "\$taskFolder\$($t.Name)"

    # ── Remove mode ──────────────────────────────────────────────────────────
    if ($Disable) {
        try {
            Unregister-ScheduledTask -TaskPath "\$taskFolder\" -TaskName $t.Name -Confirm:$false
            Write-Host "Removed task: $($t.Name)" -ForegroundColor Yellow
        } catch {
            Write-Host "Task not found (already removed?): $($t.Name)" -ForegroundColor DarkGray
        }
        continue
    }

    # ── Create / update mode ─────────────────────────────────────────────────
    Write-Host "Registering: $($t.Name)  [$($t.Time) — $($t.DaysOfWeek -join ', ')]" -ForegroundColor Cyan

    $action  = New-ScheduledTaskAction `
        -Execute $pwsh `
        -Argument "-NonInteractive -NoProfile -ExecutionPolicy Bypass -File `"$runner`" -Suite $($t.Suite) -Environment $Environment" `
        -WorkingDirectory $RepoRoot

    $trigger = New-ScheduledTaskTrigger `
        -Weekly `
        -DaysOfWeek $t.DaysOfWeek `
        -At $t.Time

    $settings = New-ScheduledTaskSettingsSet `
        -ExecutionTimeLimit  (New-TimeSpan -Hours 3) `
        -StartWhenAvailable `
        -RunOnlyIfNetworkAvailable `
        -MultipleInstances   IgnoreNew

    $principal = New-ScheduledTaskPrincipal `
        -UserId    $RunAs `
        -LogonType Interactive `
        -RunLevel  Highest

    $params = @{
        TaskName    = $t.Name
        TaskPath    = "\$taskFolder\"
        Description = $t.Description
        Action      = $action
        Trigger     = $trigger
        Settings    = $settings
        Principal   = $principal
        Force       = $true
    }

    Register-ScheduledTask @params | Out-Null
    Write-Host "  OK -> Task Scheduler\$taskFolder\$($t.Name)" -ForegroundColor Green
}

if (-not $Disable) {
    Write-Host ""
    Write-Host "======================================================"
    Write-Host "  All tasks registered under: Task Scheduler\$taskFolder"
    Write-Host "  Logs written to:            $RepoRoot\TestResults\ScheduledLogs\"
    Write-Host "  To remove all tasks run:    .\Scripts\Register-ScheduledRuns.ps1 -Disable"
    Write-Host "======================================================"
}
