$ErrorActionPreference = "Stop"
Set-Location (Join-Path $PSScriptRoot "..")
dotnet restore .\ClientAutomation.sln
dotnet build .\ClientAutomation.sln --no-restore
$script = Get-ChildItem -Recurse -Filter playwright.ps1 | Where-Object { $_.FullName -match "\\bin\\.*net8.0\\" } | Select-Object -First 1
if ($null -eq $script) { throw "Playwright install script was not generated." }
& pwsh $script.FullName install --with-deps chromium
