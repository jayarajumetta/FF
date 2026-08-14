$ErrorActionPreference = "Stop"
dotnet build ./ToscaModernized.sln -c Release
$script = Get-ChildItem -Recurse -Filter playwright.ps1 ./tests/ToscaModernized.Tests/bin/Release | Select-Object -First 1
if (-not $script) { throw "playwright.ps1 was not generated." }
& $script.FullName install --with-deps chromium
