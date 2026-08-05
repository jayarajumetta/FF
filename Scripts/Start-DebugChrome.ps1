<#
.SYNOPSIS
    Launches Chrome with remote debugging enabled, ready for the Locator Scanner.

.DESCRIPTION
    Uses a dedicated user-data-dir. This matters: without it Chrome hands the launch
    request to an already-running instance and exits, the debugging port is never opened,
    and the failure only surfaces later as a confusing connection error from the scanner.

    Leave the window this opens running for the duration of the scan.

.EXAMPLE
    .\Scripts\Start-DebugChrome.ps1
#>
[CmdletBinding()]
param(
    [int]$Port = 9222,
    [string]$UserDataDir = 'C:\ChromeDebug'
)

$ErrorActionPreference = 'Stop'

$candidates = @(
    'C:\Program Files\Google\Chrome\Application\chrome.exe',
    'C:\Program Files (x86)\Google\Chrome\Application\chrome.exe'
)

$chrome = $candidates | Where-Object { Test-Path $_ } | Select-Object -First 1
if (-not $chrome) {
    throw "Could not find chrome.exe in the usual locations. Checked:`n  $($candidates -join "`n  ")"
}

Start-Process $chrome -ArgumentList "--remote-debugging-port=$Port", "--user-data-dir=$UserDataDir"

Write-Host "Chrome started with remote debugging on port $Port (profile: $UserDataDir)."
Write-Host "Navigate to the page you want to scan, then run: .\Scripts\scan.ps1"
