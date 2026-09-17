[CmdletBinding()]
param(
    [ValidateSet(
        "All",
        "BasicPolicy",
        "CE",
        "Forms",
        "ExpertQuotePilot",
        "CommercialDuckCreekPilot")]
    [string]$Suite = "All",

    [ValidateSet("Full", "Debug")]
    [string]$Mode = "Full",

    [string]$PackageArchive,

    [string]$OutputDirectory = (Join-Path (
        Resolve-Path (Join-Path $PSScriptRoot "..\..")).Path "TestResults\PackageRuns"),

    [switch]$InstallBrowser
)

$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest

$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot "..\..")).Path
$runId = [DateTimeOffset]::UtcNow.ToString("yyyyMMdd-HHmmss") + "-" +
    [Guid]::NewGuid().ToString("N").Substring(0, 8)
$runRoot = Join-Path ([IO.Path]::GetFullPath($OutputDirectory)) $runId
$packageRoot = Join-Path $runRoot "package"
New-Item -ItemType Directory -Force -Path $runRoot | Out-Null

if ([string]::IsNullOrWhiteSpace($PackageArchive)) {
    $packageOutput = Join-Path $repoRoot "artifacts\package\$runId"
    $created = & (Join-Path $PSScriptRoot "New-TestPackage.ps1") `
        -RepositoryRoot $repoRoot `
        -OutputDirectory $packageOutput
    $PackageArchive = $created.ArchivePath
}

& (Join-Path $PSScriptRoot "Test-TestPackage.ps1") `
    -ArchivePath $PackageArchive `
    -ExtractionRoot $packageRoot `
    -DiscoverySmoke `
    -ScanForSecrets

if ($InstallBrowser) {
    & (Join-Path $packageRoot "scripts\CI\Install-Playwright.ps1") `
        -PackageRoot $packageRoot
}

$ownership = & (Join-Path $packageRoot "scripts\CI\Test-ShardOwnership.ps1") `
    -PackageRoot $packageRoot `
    -Suite $Suite `
    -Mode $Mode
$failed = [System.Collections.Generic.List[string]]::new()
foreach ($property in $ownership.shards.PSObject.Properties) {
    $shardId = $property.Name
    $shardResults = Join-Path $runRoot "results\$shardId"
    try {
        & (Join-Path $packageRoot "scripts\CI\Invoke-TestShard.ps1") `
            -PackageRoot $packageRoot `
            -ShardId $shardId `
            -Mode $Mode `
            -ResultsDirectory $shardResults
    }
    catch {
        $failed.Add("${shardId}: $($_.Exception.Message)")
    }
}

if ($failed.Count -gt 0) {
    throw "Package suite failed: $($failed -join '; ')"
}

Write-Host "Package suite '$Suite' completed successfully. Results: $runRoot"
