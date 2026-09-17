[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string]$PackageRoot,

    [string]$Browser = "chromium"
)

$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest

Import-Module (Join-Path $PackageRoot "scripts\CI\PipelineContracts.psm1") -Force
[void](Test-PackageManifest -PackageRoot $PackageRoot)

$playwright = Join-Path $PackageRoot "test\playwright.ps1"
if (-not (Test-Path -LiteralPath $playwright -PathType Leaf)) {
    throw "The packaged Playwright installer is missing."
}

& $playwright install $Browser
if ($LASTEXITCODE -ne 0) {
    throw "Playwright browser installation failed with exit code $LASTEXITCODE."
}

Write-Host "Installed $Browser using the package's Playwright runtime pair."
