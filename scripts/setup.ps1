$ErrorActionPreference = "Stop"
$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
dotnet restore (Join-Path $Root "ToscaArtifactAutomation.sln")
dotnet build (Join-Path $Root "ToscaArtifactAutomation.sln") -c Release --no-restore
$Playwright = Get-ChildItem $Root -Recurse -Filter playwright.ps1 | Where-Object FullName -Like "*bin*Release*net8.0*" | Select-Object -First 1
if (-not $Playwright) { throw "playwright.ps1 was not found after build." }
& $Playwright.FullName install msedge
