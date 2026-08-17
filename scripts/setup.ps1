param([switch]$InstallChromium)
$ErrorActionPreference = 'Stop'
Push-Location (Split-Path $PSScriptRoot -Parent)
try {
    Write-Host '1/3 Restoring and building solution...'
    dotnet restore .\ToscaCanonicalSimple.sln
    dotnet build .\ToscaCanonicalSimple.sln -c Debug --no-restore
    if ($InstallChromium) {
        Write-Host '2/3 Installing Playwright Chromium...'
        & .\scripts\install-browsers.ps1 -Browser chromium
    } else {
        Write-Host '2/3 Using installed Microsoft Edge by default. No browser download required.'
    }
    Write-Host '3/3 Setup complete.'
    Write-Host 'Run: .\scripts\run.ps1 -Project CLEQ'
} finally { Pop-Location }
