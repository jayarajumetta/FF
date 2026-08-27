param([ValidateSet('chromium','firefox','webkit')][string]$Browser='chromium')
$ErrorActionPreference = 'Stop'
Push-Location (Split-Path $PSScriptRoot -Parent)
try {
    dotnet build .\src\InsuranceAutomation.Core\InsuranceAutomation.Core.csproj -c Debug
    $playwright = Get-ChildItem .\src\InsuranceAutomation.Core\bin\Debug\net8.0\playwright.ps1 -ErrorAction Stop
    & $playwright.FullName install $Browser
} finally { Pop-Location }
