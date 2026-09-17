[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [ValidateSet("validate", "dry-run", "publish", "reconcile")]
    [string]$Mode,

    [Parameter(Mandatory)]
    [string]$PackageRoot,

    [Parameter(Mandatory)]
    [string]$ResultsRoot,

    [Parameter(Mandatory)]
    [string]$MappingCatalog,

    [Parameter(Mandatory)]
    [string]$Environment,

    [string]$Browser = "chromium",

    [string]$ReconciliationPath,

    [string]$DryRunOutputPath
)

$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest

$root = [IO.Path]::GetFullPath($PackageRoot)
Import-Module (Join-Path $root "scripts\CI\PipelineContracts.psm1") -Force
[void](Test-PackageManifest -PackageRoot $root)

$publisher = Join-Path $root "tools\TestPlanPublisher\TestPlanPublisher.dll"
if (-not (Test-Path -LiteralPath $publisher -PathType Leaf)) {
    throw "The packaged Test Plans publisher is missing."
}

$arguments = @(
    $publisher,
    $Mode,
    "--package-root", $root,
    "--results-root", ([IO.Path]::GetFullPath($ResultsRoot)),
    "--catalog", ([IO.Path]::GetFullPath($MappingCatalog)),
    "--environment", $Environment,
    "--browser", $Browser
)
if (-not [string]::IsNullOrWhiteSpace($ReconciliationPath)) {
    $arguments += @(
        "--state",
        [IO.Path]::GetFullPath($ReconciliationPath))
}
if (-not [string]::IsNullOrWhiteSpace($DryRunOutputPath)) {
    $arguments += @(
        "--output",
        [IO.Path]::GetFullPath($DryRunOutputPath))
}

& dotnet @arguments
if ($LASTEXITCODE -ne 0) {
    throw "Test Plans '$Mode' operation failed."
}
