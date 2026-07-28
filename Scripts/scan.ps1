<#
.SYNOPSIS
    Runs the Locator Scanner against the page currently open in the debug Chrome instance.

.DESCRIPTION
    Resolves the live Chrome DevTools WebSocket address, writes it into scan.runsettings,
    and runs the scanner. scan.runsettings is regenerated on every run and is git-ignored:
    the CDP value is a per-session GUID that is only valid for the Chrome instance it came
    from, so it is meaningless on another machine or after Chrome restarts.

    Chrome must already be running with remote debugging enabled — use
    Scripts\Start-DebugChrome.ps1.

.PARAMETER NoCompare
    Skip comparison against existing repo locators and report every element found.
    Useful for pages the repo has no coverage for yet, such as CLAS or Express.

.PARAMETER NewOnly
    Report only elements that are not already covered by repo locators.

.EXAMPLE
    .\Scripts\scan.ps1
    Default scan — compares against the repo and skips elements already covered.

.EXAMPLE
    .\Scripts\scan.ps1 -NoCompare
#>
[CmdletBinding()]
param(
    [switch]$NoCompare,
    [switch]$NewOnly,
    [int]$Port = 9222
)

$ErrorActionPreference = 'Stop'

$repoRoot    = Split-Path -Parent $PSScriptRoot
$project     = Join-Path $repoRoot 'TestAutomation.csproj'
$runSettings = Join-Path $repoRoot 'scan.runsettings'

try {
    $cdp = (Invoke-RestMethod -Uri "http://localhost:$Port/json/version" -TimeoutSec 5).webSocketDebuggerUrl
}
catch {
    throw "Could not reach Chrome's debugging endpoint on port $Port. " +
          "Start Chrome with Scripts\Start-DebugChrome.ps1 first — a normal Chrome window will not work."
}

$compareValue = if ($NoCompare) { 'false' } else { 'true' }
$newOnlyValue = if ($NewOnly)   { 'true'  } else { 'false' }

@"
<?xml version="1.0" encoding="utf-8"?>
<RunSettings>
  <TestRunParameters>
    <Parameter name="CDP"      value="$cdp" />
    <Parameter name="COMPARE"  value="$compareValue" />
    <Parameter name="NEW_ONLY" value="$newOnlyValue" />
    <Parameter name="CS_ONLY"  value="true" />
  </TestRunParameters>
</RunSettings>
"@ | Out-File -Encoding utf8 $runSettings

dotnet test $project --filter "Category=Tools&Name~Scan" --settings $runSettings
