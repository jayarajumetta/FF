<#
.SYNOPSIS
    Runs the SFP Basic Policy test across all 23 states and saves a TRX log.

.DESCRIPTION
    Compatibility entry point that delegates to the immutable package builder
    and canonical shard/result runner.

.PARAMETER NoBuild
    Pass -NoBuild to skip the dotnet build step (faster when code hasn't changed).

.EXAMPLE
    .\Scripts\run-sfp-basic.ps1
    .\Scripts\run-sfp-basic.ps1 -NoBuild
#>

#requires -Version 7.2
param(
    [switch]$NoBuild
)

$projectRoot = (Resolve-Path "$PSScriptRoot\..").Path
$packageArchive = $null
if ($NoBuild) {
    $packageArchive = Get-ChildItem `
        -LiteralPath (Join-Path $projectRoot "artifacts\package") `
        -Filter "PnC-TestAutomation-*.zip" `
        -File `
        -Recurse `
        -ErrorAction SilentlyContinue |
        Sort-Object LastWriteTimeUtc -Descending |
        Select-Object -First 1 -ExpandProperty FullName
    if ([string]::IsNullOrWhiteSpace($packageArchive)) {
        throw "-NoBuild requires an existing validated package under artifacts\package."
    }
}

Write-Host ""
Write-Host "=== SFP Basic Policy - Packaged execution ===" -ForegroundColor Cyan
Write-Host "  Project : $projectRoot"
Write-Host ""

& (Join-Path $projectRoot "Scripts\CI\Invoke-PackageSuite.ps1") `
    -Suite BasicPolicy `
    -Mode Full `
    -PackageArchive $packageArchive `
    -InstallBrowser
