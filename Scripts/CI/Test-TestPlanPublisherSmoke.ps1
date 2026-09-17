[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string]$PackageRoot
)

$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest

$root = [IO.Path]::GetFullPath($PackageRoot)
$smokeRoot = Join-Path ([IO.Path]::GetTempPath()) (
    "PnC-TestPlanSmoke-" + [Guid]::NewGuid().ToString("N"))
$resultsRoot = Join-Path $smokeRoot "results"
$scenarioRoot = Join-Path $resultsRoot "evidence\initial\scenario-smoke"
$metadataRoot = Join-Path $scenarioRoot "metadata"
$trxRoot = Join-Path $resultsRoot "trx"
New-Item -ItemType Directory -Force -Path $metadataRoot, $trxRoot | Out-Null

try {
    $package = Get-Content -LiteralPath (
        Join-Path $root "package-manifest.json") -Raw | ConvertFrom-Json
    $testIdentity = "PackagePublisherSmoke"
    $automationId = "PACKAGE-PUBLISHER-SMOKE:CI"
    $timingPath = Join-Path $metadataRoot "timing.json"
    $trxMetadataPath = Join-Path $metadataRoot "trx.json"
    "{}" | Set-Content -LiteralPath $timingPath -Encoding UTF8
    "{}" | Set-Content -LiteralPath $trxMetadataPath -Encoding UTF8
    $scenarioManifestPath = Join-Path $scenarioRoot "manifest.json"
    [ordered]@{
        version = 2
        automationId = $automationId
        testIdentity = $testIdentity
        outcome = 0
        artifacts = @(
            [ordered]@{
                kind = 9
                relativePath = "metadata/trx.json"
            },
            [ordered]@{
                kind = 10
                relativePath = "metadata/timing.json"
            }
        )
    } | ConvertTo-Json -Depth 6 |
        Set-Content -LiteralPath $scenarioManifestPath -Encoding UTF8

    $finalTrxPath = Join-Path $trxRoot "Smoke-final.trx"
    @"
<?xml version="1.0" encoding="utf-8"?>
<TestRun xmlns="http://microsoft.com/schemas/VisualStudio/TeamTest/2010">
  <Results>
    <UnitTestResult testId="1" testName="$testIdentity" outcome="Passed" duration="00:00:00.1000000" />
  </Results>
</TestRun>
"@ | Set-Content -LiteralPath $finalTrxPath -Encoding UTF8

    $attachments = @(
        $scenarioManifestPath,
        $timingPath,
        $trxMetadataPath
    ) | ForEach-Object {
        $item = Get-Item -LiteralPath $_
        [ordered]@{
            path = [IO.Path]::GetRelativePath(
                $resultsRoot,
                $item.FullName).Replace('\', '/')
            size = [long]$item.Length
            sha256 = (
                Get-FileHash -LiteralPath $item.FullName -Algorithm SHA256
            ).Hash.ToUpperInvariant()
        }
    }
    [ordered]@{
        schemaVersion = 1
        packageVersion = [string]$package.packageVersion
        commit = [string]$package.commit.sha
        buildId = [string]$package.build.id
        shard = "PackageSmoke"
        expected = 1
        discovered = 1
        executed = 1
        passed = 1
        failed = 0
        finalTrx = "trx/Smoke-final.trx"
        finalTrxSha256 = (
            Get-FileHash -LiteralPath $finalTrxPath -Algorithm SHA256
        ).Hash.ToUpperInvariant()
        evidenceManifests = 1
        attachments = @($attachments)
    } | ConvertTo-Json -Depth 8 |
        Set-Content -LiteralPath (
            Join-Path $resultsRoot "result-manifest.json") -Encoding UTF8

    $catalogVersion = "1.0.0-smoke"
    $provenance = "package-extraction-smoke"
    $canonical = @(
        "1",
        $catalogVersion,
        $provenance,
        "$automationId|1|2|3|4"
    ) -join "`n"
    $catalogPath = Join-Path $smokeRoot "mapping.json"
    [ordered]@{
        schemaVersion = 1
        catalogVersion = $catalogVersion
        provenance = $provenance
        checksum = [Convert]::ToHexString(
            [Security.Cryptography.SHA256]::HashData(
                [Text.Encoding]::UTF8.GetBytes($canonical)))
        mappings = @(
            [ordered]@{
                automationId = $automationId
                planId = 1
                suiteId = 2
                testCaseId = 3
                configurationId = 4
            }
        )
    } | ConvertTo-Json -Depth 6 |
        Set-Content -LiteralPath $catalogPath -Encoding UTF8

    $statePath = Join-Path $smokeRoot "reconciliation.json"
    $outputPath = Join-Path $smokeRoot "dry-run.json"
    & (Join-Path $root "scripts\CI\Invoke-TestPlanPublication.ps1") `
        -Mode dry-run `
        -PackageRoot $root `
        -ResultsRoot $resultsRoot `
        -MappingCatalog $catalogPath `
        -Environment "package-smoke" `
        -Browser "chromium" `
        -ReconciliationPath $statePath `
        -DryRunOutputPath $outputPath

    $state = Get-Content -LiteralPath $statePath -Raw | ConvertFrom-Json
    $dryRun = Get-Content -LiteralPath $outputPath -Raw | ConvertFrom-Json
    if (-not $state.completed -or
        @($state.executions.PSObject.Properties).Count -ne 1 -or
        @($dryRun.executions).Count -ne 1 -or
        -not $dryRun.executions[0].automationId.Equals(
            $automationId,
            [StringComparison]::Ordinal)) {
        throw "Extracted Test Plans publisher dry-run smoke failed parity validation."
    }

    Write-Host "Extracted Test Plans publisher dry-run smoke passed."
}
finally {
    if (Test-Path -LiteralPath $smokeRoot) {
        Remove-Item -LiteralPath $smokeRoot -Recurse -Force
    }
}
