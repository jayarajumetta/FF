param(
    [ValidateSet('ALL','CLDC','CLEQ','PLDC')][string]$Project='ALL',
    [string]$Filter=''
)
$ErrorActionPreference = 'Stop'
$env:COPILOT_SELF_HEAL = if ($env:COPILOT_SELF_HEAL) { $env:COPILOT_SELF_HEAL } else { 'true' }
$env:BROWSER_CHANNEL = if ($env:BROWSER_CHANNEL) { $env:BROWSER_CHANNEL } else { 'msedge' }
$env:HEADLESS = if ($env:HEADLESS) { $env:HEADLESS } else { 'false' }
$env:TRACE_ENABLED = if ($env:TRACE_ENABLED) { $env:TRACE_ENABLED } else { 'true' }
$env:VIDEO_ENABLED = if ($env:VIDEO_ENABLED) { $env:VIDEO_ENABLED } else { 'true' }

$projects = @{
    'CLDC'='.\tests\CommercialLines.DuckCreek.Tests\CommercialLines.DuckCreek.Tests.csproj'
    'CLEQ'='.\tests\CommercialLines.ExpertQuote.Tests\CommercialLines.ExpertQuote.Tests.csproj'
    'PLDC'='.\tests\PersonalLines.DuckCreek.Tests\PersonalLines.DuckCreek.Tests.csproj'
}
Push-Location (Split-Path $PSScriptRoot -Parent)
try {
    $targets = if ($Project -eq 'ALL') { $projects.Values } else { @($projects[$Project]) }
    foreach ($target in $targets) {
        $args = @('test',$target,'-c','Debug','--logger','console;verbosity=normal')
        if ($Filter) { $args += @('--filter',$Filter) }
        & dotnet @args
        if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }
    }
} finally { Pop-Location }
