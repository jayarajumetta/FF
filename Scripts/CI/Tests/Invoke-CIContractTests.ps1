[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Resolve-Path (Join-Path $PSScriptRoot "..\..\..")).Path
)

$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest

Import-Module (Join-Path $RepositoryRoot "Scripts\CI\PipelineContracts.psm1") -Force

$script:Passed = 0
function Assert-True {
    param([bool]$Condition, [string]$Message)
    if (-not $Condition) {
        throw $Message
    }
    $script:Passed++
}

function Assert-Throws {
    param([scriptblock]$Action, [string]$MessagePattern)
    try {
        & $Action
    }
    catch {
        if ($_.Exception.Message -notmatch $MessagePattern) {
            throw "Expected error matching '$MessagePattern' but received '$($_.Exception.Message)'."
        }
        $script:Passed++
        return
    }
    throw "Expected an exception matching '$MessagePattern'."
}

function Write-Trx {
    param(
        [string]$Path,
        [object[]]$Results
    )

    $resultXml = @(
        $Results | ForEach-Object {
            $executionId = if ($_.ContainsKey("ExecutionId")) {
                $_.ExecutionId
            } else {
                "execution-$($_.Id)"
            }
            '<UnitTestResult executionId="{0}" testId="{1}" testName="{2}" outcome="{3}" duration="00:00:01" />' -f
                $executionId, $_.Id, $_.Name, $_.Outcome
        }
    ) -join [Environment]::NewLine
    $definitionXml = @(
        $Results | ForEach-Object {
            $executionId = if ($_.ContainsKey("ExecutionId")) {
                $_.ExecutionId
            } else {
                "execution-$($_.Id)"
            }
            '<UnitTest id="{0}" name="{1}"><Execution id="{2}" /><TestMethod className="Contract.Tests" name="{1}" /></UnitTest>' -f
                $_.Id, $_.Name, $executionId
        }
    ) -join [Environment]::NewLine
    $entryXml = @(
        $Results | ForEach-Object {
            $executionId = if ($_.ContainsKey("ExecutionId")) {
                $_.ExecutionId
            } else {
                "execution-$($_.Id)"
            }
            '<TestEntry testId="{0}" executionId="{1}" />' -f
                $_.Id, $executionId
        }
    ) -join [Environment]::NewLine
    $passed = @($Results | Where-Object Outcome -eq "Passed").Count
    $failed = $Results.Count - $passed
    @"
<?xml version="1.0" encoding="utf-8"?>
<TestRun xmlns="http://microsoft.com/schemas/VisualStudio/TeamTest/2010">
  <Results>
    $resultXml
  </Results>
  <TestDefinitions>
    $definitionXml
  </TestDefinitions>
  <TestEntries>
    $entryXml
  </TestEntries>
  <ResultSummary outcome="$(if ($failed -eq 0) { "Completed" } else { "Failed" })">
    <Counters total="$($Results.Count)" executed="$($Results.Count)" passed="$passed" failed="$failed" notExecuted="0" />
  </ResultSummary>
</TestRun>
"@ | Set-Content -LiteralPath $Path -Encoding UTF8
}

$temporaryRoot = Join-Path ([IO.Path]::GetTempPath()) (
    "PnC-CIContracts-" + [Guid]::NewGuid().ToString("N"))
New-Item -ItemType Directory -Force -Path $temporaryRoot | Out-Null

try {
    $packageRoot = Join-Path $temporaryRoot "package"
    $requiredFiles = @(
        "test\TestAutomation.dll",
        "test\TestAutomation.deps.json",
        "test\TestAutomation.runtimeconfig.json",
        "test\playwright.ps1",
        "test\.playwright\package\browsers.json",
        "test\.playwright\package\cli.js",
        "test\appsettings.Dev.json",
        "test\Resources\Contracts\combined-framework-contract.json",
        "test\Resources\ExpectedForms\SFP\forms.json",
        "test\Resources\ExpectedOutcomes\sfp-outcomes.json",
        "test\Resources\DataProfiles\eq-bop-pilot.json",
        "test\Resources\DataProfiles\cldc-bap-pilot.json",
        "test\Resources\FrameHints\cldc-bap-frame-hints.json",
        "datapool\DataPool.dll",
        "datapool\DataPool.deps.json",
        "datapool\DataPool.runtimeconfig.json",
        "tools\CiTestInventory\CiTestInventory.dll",
        "tools\CiTestInventory\CiTestInventory.deps.json",
        "tools\CiTestInventory\CiTestInventory.runtimeconfig.json",
        "tools\TestPlanPublisher\TestPlanPublisher.dll",
        "tools\TestPlanPublisher\TestPlanPublisher.deps.json",
        "tools\TestPlanPublisher\TestPlanPublisher.runtimeconfig.json",
        "metadata\test-inventory.json",
        "metadata\shards-All-Full.json",
        "metadata\shards-All-Debug.json",
        "metadata\shards-Forms-Full.json",
        "metadata\shards-ExpertQuotePilot-Full.json",
        "metadata\shards-CommercialDuckCreekPilot-Full.json",
        "runsettings\ci.runsettings",
        "config\shards.json",
        "config\testplans-mapping.template.json",
        "scripts\CI\PipelineContracts.psm1",
        "scripts\CI\Invoke-TestShard.ps1",
        "scripts\CI\Invoke-TestPlanPublication.ps1",
        "scripts\CI\Test-ShardOwnership.ps1",
        "scripts\CI\Install-Playwright.ps1",
        "scripts\CI\Invoke-PackageSuite.ps1",
        "scripts\CI\Test-TestPlanPublisherSmoke.ps1",
        "scripts\CI\Test-TestPackage.ps1",
        "tools\reports\Cleanup-TestArtifacts.ps1",
        "tools\reports\Extract-SFPPremiums.ps1",
        "tools\reports\FormsCheck.ps1"
    )
    foreach ($relative in $requiredFiles) {
        $path = Join-Path $packageRoot $relative
        New-Item -ItemType Directory -Force -Path (Split-Path -Parent $path) |
            Out-Null
        "contract-file" | Set-Content -LiteralPath $path -Encoding UTF8
    }
    @{
        libraries = @{
            "Microsoft.Playwright/1.57.0" = @{ type = "package" }
            "Reqnroll/3.3.0" = @{ type = "package" }
        }
    } | ConvertTo-Json -Depth 5 |
        Set-Content -LiteralPath (Join-Path $packageRoot "test\TestAutomation.deps.json") `
            -Encoding UTF8
    '{ "ApiKey": "", "Password": "" }' |
        Set-Content -LiteralPath (Join-Path $packageRoot "test\appsettings.json") `
            -Encoding UTF8

    [void](New-PackageManifest `
        -PackageRoot $packageRoot `
        -PackageVersion "1.0.0" `
        -CommitSha "0123456789abcdef" `
        -BuildId "42" `
        -BuildNumber "20260917.1")
    $manifest = Test-PackageManifest -PackageRoot $packageRoot -ScanForSecrets
    Assert-True (
        @($manifest.inventory).Count -eq ($requiredFiles.Count + 1)
    ) "Package inventory count was incorrect."
    Assert-True (
        @($manifest.dependencies | Where-Object name -eq "Microsoft.Playwright").Count -eq 1
    ) "Dependency inventory omitted Playwright."

    Add-Content -LiteralPath (Join-Path $packageRoot "test\TestAutomation.dll") `
        -Value "tampered"
    Assert-Throws {
        Test-PackageManifest -PackageRoot $packageRoot
    } "checksum"
    "contract-file" |
        Set-Content -LiteralPath (Join-Path $packageRoot "test\TestAutomation.dll") `
            -Encoding UTF8

    $secretPath = Join-Path $packageRoot "config\credential.json"
    '{ "clientSecret": "not-a-real-secret-but-must-be-rejected" }' |
        Set-Content -LiteralPath $secretPath -Encoding UTF8
    Remove-Item -LiteralPath (Join-Path $packageRoot "package-manifest.json")
    [void](New-PackageManifest `
        -PackageRoot $packageRoot `
        -PackageVersion "1.0.0" `
        -CommitSha "0123456789abcdef" `
        -BuildId "42" `
        -BuildNumber "20260917.1")
    Assert-Throws {
        Test-PackageManifest -PackageRoot $packageRoot -ScanForSecrets
    } "secret literal"
    Remove-Item -LiteralPath $secretPath

    $privateKeyPath = Join-Path $packageRoot "config\diagnostic.txt"
    '-----BEGIN PRIVATE KEY-----' |
        Set-Content -LiteralPath $privateKeyPath -Encoding UTF8
    Remove-Item -LiteralPath (Join-Path $packageRoot "package-manifest.json")
    [void](New-PackageManifest `
        -PackageRoot $packageRoot `
        -PackageVersion "1.0.0" `
        -CommitSha "0123456789abcdef" `
        -BuildId "42" `
        -BuildNumber "20260917.1")
    Assert-Throws {
        Test-PackageManifest -PackageRoot $packageRoot -ScanForSecrets
    } "secret literal"
    Remove-Item -LiteralPath $privateKeyPath

    $quotesPath = Join-Path $packageRoot "datapool\quotes.json"
    '[]' | Set-Content -LiteralPath $quotesPath -Encoding UTF8
    Remove-Item -LiteralPath (Join-Path $packageRoot "package-manifest.json")
    [void](New-PackageManifest `
        -PackageRoot $packageRoot `
        -PackageVersion "1.0.0" `
        -CommitSha "0123456789abcdef" `
        -BuildId "42" `
        -BuildNumber "20260917.1")
    Assert-Throws {
        Test-PackageManifest -PackageRoot $packageRoot
    } "forbidden"
    Remove-Item -LiteralPath $quotesPath

    $seedPath = Join-Path $packageRoot "test\nunit_random_seed.tmp"
    "mutable-runtime-state" |
        Set-Content -LiteralPath $seedPath -Encoding UTF8
    Remove-Item -LiteralPath (Join-Path $packageRoot "package-manifest.json")
    [void](New-PackageManifest `
        -PackageRoot $packageRoot `
        -PackageVersion "1.0.0" `
        -CommitSha "0123456789abcdef" `
        -BuildId "42" `
        -BuildNumber "20260917.1")
    Assert-Throws {
        Test-PackageManifest -PackageRoot $packageRoot
    } "forbidden"
    Remove-Item -LiteralPath $seedPath

    $ownership = Test-ShardOwnershipSets `
        -SelectedTests @("A", "B", "C") `
        -ShardTests @{ One = @("A", "B"); Two = @("C") } `
        -ExpectedCount 3
    Assert-True ($ownership.selectedCount -eq 3) "Valid shard ownership was rejected."
    Assert-Throws {
        Test-ShardOwnershipSets `
            -SelectedTests @("A", "B") `
            -ShardTests @{ One = @("A"); Two = @("A", "B") }
    } "overlap"
    Assert-Throws {
        Test-ShardOwnershipSets `
            -SelectedTests @("A", "B") `
            -ShardTests @{ One = @("A") }
    } "unassigned"
    Assert-Throws {
        Test-ShardOwnershipSets `
            -SelectedTests @("A") `
            -ShardTests @{ One = @("A"); Two = @() }
    } "zero tests"
    Assert-Throws {
        Test-ShardOwnershipSets `
            -SelectedTests @("A") `
            -ShardTests @{ One = @("A") } `
            -ExpectedCount 2
    } "count disagreement"

    $selectedInventory = @(Select-TestInventory `
        -Tests @(
            [PSCustomObject]@{ id = "A"; categories = @("SFP", "Shard1") },
            [PSCustomObject]@{ id = "B"; categories = @("SFP", "Shard2") }
        ) `
        -Rules @(
            [PSCustomObject]@{ all = @("SFP"); none = @("Shard2") }
        ))
    Assert-True (
        $selectedInventory.Count -eq 1 -and
        $selectedInventory[0].id -eq "A"
    ) "Compiled inventory category rules selected the wrong tests."

    Assert-True (
        (Get-RetryDecision `
            -FailureText "navigation timed out" `
            -IsRetrySafe $true `
            -IsParameterized $false).ShouldRetry
    ) "Approved transient RetrySafe failure was not retried."
    Assert-True (
        -not (Get-RetryDecision `
            -FailureText "navigation timed out" `
            -IsRetrySafe $false `
            -IsParameterized $false).ShouldRetry
    ) "Unmarked failure was retried."
    Assert-True (
        -not (Get-RetryDecision `
            -FailureText "navigation timed out" `
            -IsRetrySafe $true `
            -IsParameterized $true).ShouldRetry
    ) "Parameterized failure was retried."
    Assert-True (
        -not (Get-RetryDecision `
            -FailureText "premium mismatch after timeout" `
            -IsRetrySafe $true `
            -IsParameterized $false).ShouldRetry
    ) "Business mismatch was retried."

    $trxRoot = Join-Path $temporaryRoot "trx"
    New-Item -ItemType Directory -Force -Path $trxRoot | Out-Null
    $initialTrx = Join-Path $trxRoot "initial.trx"
    $retryTrx = Join-Path $trxRoot "retry.trx"
    $finalTrx = Join-Path $trxRoot "final.trx"
    Write-Trx -Path $initialTrx -Results @(
        @{ Id = "1"; Name = "Passes"; Outcome = "Passed" },
        @{
            Id = "2"
            Name = "Retries"
            Outcome = "Failed"
            ExecutionId = "initial-execution"
        }
    )
    Write-Trx -Path $retryTrx -Results @(
        @{
            Id = "2"
            Name = "Retries"
            Outcome = "Passed"
            ExecutionId = "retry-execution"
        }
    )
    $canonical = Merge-TrxResults `
        -InitialPath $initialTrx `
        -RetryPath $retryTrx `
        -OutputPath $finalTrx
    Assert-True (
        $canonical.total -eq 2 -and
        $canonical.passed -eq 2 -and
        $canonical.failed -eq 0 -and
        $canonical.retried -eq 1
    ) "Canonical TRX did not reconcile retry outcomes."
    Assert-True (
        (Read-TrxResults -Path $finalTrx).Results.Count -eq 2
    ) "Canonical TRX is not readable."
    $finalResult = (Read-TrxResults -Path $finalTrx).Results |
        Where-Object testName -eq "Retries"
    Assert-True (
        $finalResult.node.GetAttribute("executionId") -eq "initial-execution"
    ) "Canonical TRX did not preserve its initial execution identity."

    Assert-Throws {
        Read-TrxResults -Path (Join-Path $trxRoot "missing.trx")
    } "missing"
    $emptyTrx = Join-Path $trxRoot "empty.trx"
    New-Item -ItemType File -Path $emptyTrx | Out-Null
    Assert-Throws { Read-TrxResults -Path $emptyTrx } "empty"
    $badTrx = Join-Path $trxRoot "bad.trx"
    "<broken" | Set-Content -LiteralPath $badTrx
    Assert-Throws { Read-TrxResults -Path $badTrx } "malformed"
    $zeroTrx = Join-Path $trxRoot "zero.trx"
    Write-Trx -Path $zeroTrx -Results @()
    Assert-Throws { Read-TrxResults -Path $zeroTrx } "zero test"
    $countMismatchTrx = Join-Path $trxRoot "count-mismatch.trx"
    Write-Trx -Path $countMismatchTrx -Results @(
        @{ Id = "1"; Name = "One"; Outcome = "Passed" },
        @{ Id = "2"; Name = "Two"; Outcome = "Passed" }
    )
    [xml]$countMismatch = Get-Content -LiteralPath $countMismatchTrx -Raw
    $countMismatch.TestRun.ResultSummary.Counters.total = "1"
    $countMismatch.Save($countMismatchTrx)
    Assert-Throws {
        Read-TrxResults -Path $countMismatchTrx
    } "counters disagree"

    $buildTemplate = Get-Content -LiteralPath (
        Join-Path $RepositoryRoot "Pipelines\templates\build-package-stage.yml") -Raw
    $testTemplate = Get-Content -LiteralPath (
        Join-Path $RepositoryRoot "Pipelines\templates\test-shards-stage.yml") -Raw
    $entry = Get-Content -LiteralPath (
        Join-Path $RepositoryRoot "Pipelines\sfp-smoke-adhoc.yml") -Raw
    Assert-True ($buildTemplate -match "New-TestPackage\.ps1") "Build template bypasses package entry point."
    Assert-True ($buildTemplate -match "failTaskOnFailedTests:\s*true") "Unit publication is not fail-closed."
    Assert-True ($testTemplate -match "checkout:\s*none") "Test jobs still use a source checkout."
    Assert-True ($testTemplate -match "Invoke-TestShard\.ps1") "Test template bypasses the canonical runner."
    Assert-True ($testTemplate -match "failTaskOnFailedTests:\s*true") "Test publication is not fail-closed."
    Assert-True ($testTemplate -match "failTaskOnMissingResultsFile:\s*true") "Missing TRX does not fail publication."
    Assert-True ($testTemplate -notmatch "failTaskOnFailedTests:\s*false") "A test publisher can hide failures."
    Assert-True ($testTemplate -notmatch "continueOnError:\s*true") "The test template permits hidden failures."
    Assert-True (
        $testTemplate -match "Invoke-TestPlanPublication\.ps1"
    ) "Test Plans publication bypasses the packaged publisher."
    Assert-True (
        $testTemplate -match "testPlanPublishMode[\s\S]*default:\s*Off"
    ) "Test Plans publication is not disabled by default."
    Assert-True (
        $testTemplate -match "Publish canonical result to Azure Test Plans[\s\S]*condition:\s*always\(\)"
    ) "Test Plans publication is not wired as a diagnostic-safe fail-closed step."
    Assert-True (
        $testTemplate -match "Publish canonical shard results[\s\S]*condition:\s*and\(always\(\), ne\('[^']*testPlanPublishMode[^']*', 'Publish'\)\)"
    ) "Live mapped publication does not suppress duplicate PublishTestResults results."
    Assert-True (
        $testTemplate -match "AZDO_ORGANIZATION_URL:\s*\$\(System\.CollectionUri\)" -and
        $testTemplate -match "SYSTEM_COLLECTIONURI:\s*\$\(System\.CollectionUri\)"
    ) "Credential-bearing publication is not pinned to System.CollectionUri."
    Assert-True ($entry -match "Development" -and $entry -match "combined-framework") "CI branch coverage is incomplete."
    $shardCatalog = Get-Content -LiteralPath (
        Join-Path $RepositoryRoot "Pipelines\config\shards.json") -Raw |
        ConvertFrom-Json
    $pilotSuite = @($shardCatalog.suites |
        Where-Object name -eq "ExpertQuotePilot")
    $pilotShard = @($shardCatalog.shards |
        Where-Object id -eq "EqBopAlPilot")
    Assert-True (
        $pilotSuite.Count -eq 1 -and
        $pilotShard.Count -eq 1 -and
        @($pilotSuite[0].shards).Count -eq 1 -and
        $pilotSuite[0].shards[0] -eq "EqBopAlPilot"
    ) "ExpertQuote pilot does not have one isolated shard owner."
    Assert-True (
        $entry -notmatch "ExpertQuotePilot|EqBopAlPilot"
    ) "NonRunnable ExpertQuote pilot entered scheduled production execution."
    $cldcPilotSuite = @($shardCatalog.suites |
        Where-Object name -eq "CommercialDuckCreekPilot")
    $cldcPilotShard = @($shardCatalog.shards |
        Where-Object id -eq "CldcBapAlPilot")
    Assert-True (
        $cldcPilotSuite.Count -eq 1 -and
        $cldcPilotShard.Count -eq 1 -and
        @($cldcPilotSuite[0].shards).Count -eq 1 -and
        $cldcPilotSuite[0].shards[0] -eq "CldcBapAlPilot"
    ) "Commercial DuckCreek pilot does not have one isolated shard owner."
    Assert-True (
        $entry -notmatch "CommercialDuckCreekPilot|CldcBapAlPilot"
    ) "NonRunnable Commercial DuckCreek pilot entered scheduled production execution."

    Write-Host "CI contract tests passed: $script:Passed assertions."
}
finally {
    if (Test-Path -LiteralPath $temporaryRoot) {
        Remove-Item -LiteralPath $temporaryRoot -Recurse -Force
    }
}
