$ErrorActionPreference = "Stop"
Push-Location (Join-Path $PSScriptRoot "..")
try {
  dotnet --version
  dotnet restore .\ToscaCanonicalSimple.sln
  dotnet build .\ToscaCanonicalSimple.sln -c Debug --no-restore
  $playwright = Get-ChildItem -Path . -Filter playwright.ps1 -Recurse | Select-Object -First 1
  if ($playwright) { & $playwright.FullName install chromium }
  else { Write-Host "Playwright install script is generated after build. If Edge is installed, BROWSER channel msedge can be used directly." }
  Write-Host "Setup complete. Configure config/framework.json and TEST_LLM_API_KEY if self-healing LLM is required."
} finally { Pop-Location }
