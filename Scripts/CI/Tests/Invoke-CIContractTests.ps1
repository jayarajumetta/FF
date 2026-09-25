[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Resolve-Path (Join-Path $PSScriptRoot "..\..\..")).Path,
    [switch]$IncludeCompiledInventory
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
    $skipped = @($Results | Where-Object Outcome -eq "NotExecuted").Count
    $failed = @($Results | Where-Object Outcome -eq "Failed").Count
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
    <Counters total="$($Results.Count)" executed="$($Results.Count - $skipped)" passed="$passed" failed="$failed" notExecuted="$skipped" />
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
        "test\Resources\Contracts\integration-readiness.json",
        "test\Resources\Contracts\sgs-feature-inventory.json",
        "test\Resources\Contracts\sgs-data-inventory.json",
        "test\Resources\ExpectedForms\SFP\forms.json",
        "test\Resources\ExpectedOutcomes\sfp-outcomes.json",
        "test\Resources\SGS\retained-data.json",
        "datapool\DataPool.dll",
        "datapool\DataPool.deps.json",
        "datapool\DataPool.runtimeconfig.json",
        "tools\CiTestInventory\CiTestInventory.dll",
        "tools\CiTestInventory\CiTestInventory.deps.json",
        "tools\CiTestInventory\CiTestInventory.runtimeconfig.json",
        "tools\TestPlanPublisher\TestPlanPublisher.dll",
        "tools\TestPlanPublisher\TestPlanPublisher.deps.json",
        "tools\TestPlanPublisher\TestPlanPublisher.runtimeconfig.json",
        "tools\SgsReport\SgsReport.dll",
        "tools\SgsReport\SgsReport.deps.json",
        "tools\SgsReport\SgsReport.runtimeconfig.json",
        "tools\SgsReport\TestAutomation.dll",
        "tools\SgsReport\TestPlanPublisher.dll",
        "metadata\test-inventory.json",
        "metadata\shards-All-Full.json",
        "metadata\shards-All-Debug.json",
        "metadata\shards-Forms-Full.json",
        "runsettings\ci.runsettings",
        "config\shards.json",
        "config\testplans-mapping.template.json",
        "scripts\CI\PipelineContracts.psm1",
        "scripts\CI\Invoke-TestShard.ps1",
        "scripts\CI\Invoke-TestPlanPublication.ps1",
        "scripts\CI\Invoke-StabilizationVerification.ps1",
        "scripts\CI\Test-IntegrationReadiness.ps1",
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

    Remove-Item -LiteralPath (Join-Path $packageRoot "tools\SgsReport\SgsReport.dll")
    [void](New-PackageManifest -PackageRoot $packageRoot -PackageVersion "1.0.0" `
        -CommitSha "0123456789abcdef" -BuildId "42" -BuildNumber "20260917.1")
    Assert-Throws { Test-PackageManifest -PackageRoot $packageRoot } "missing.*SgsReport"
    "contract-file" | Set-Content -LiteralPath (Join-Path $packageRoot "tools\SgsReport\SgsReport.dll") -Encoding UTF8
    [void](New-PackageManifest -PackageRoot $packageRoot -PackageVersion "1.0.0" `
        -CommitSha "0123456789abcdef" -BuildId "42" -BuildNumber "20260917.1")

    Add-Content -LiteralPath (Join-Path $packageRoot "test\TestAutomation.dll") `
        -Value "tampered"
    Assert-Throws {
        Test-PackageManifest -PackageRoot $packageRoot
    } "checksum"
    "contract-file" |
        Set-Content -LiteralPath (Join-Path $packageRoot "test\TestAutomation.dll") `
            -Encoding UTF8

    $secretPath = Join-Path $packageRoot "config\credential.json"
    foreach ($credentialFixture in @(
        '{ "clientSecret": "not-a-real-secret-but-must-be-rejected" }',
        '{ "password": "SYNTHETIC_REPLACE_ME" }'
    )) {
        $credentialFixture | Set-Content -LiteralPath $secretPath -Encoding UTF8
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
    }

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

    foreach ($relativeQuotesPath in @(
        "datapool\quotes.json",
        "datapool\data\quotes.json",
        "test\data\quotes.json",
        "tools\CiTestInventory\data\quotes.json",
        "tools\SgsReport\data\quotes.json",
        "tools\TestPlanPublisher\data\quotes.json",
        "tools\reports\data\quotes.json",
        "tools\future-tool\nested\data\quotes.json"
    )) {
        $quotesPath = Join-Path $packageRoot $relativeQuotesPath
        New-Item -ItemType Directory -Force -Path (Split-Path -Parent $quotesPath) | Out-Null
        '[]' | Set-Content -LiteralPath $quotesPath -Encoding UTF8
        Remove-Item -LiteralPath (Join-Path $packageRoot "package-manifest.json")
        [void](New-PackageManifest `
            -PackageRoot $packageRoot `
            -PackageVersion "1.0.0" `
            -CommitSha "0123456789abcdef" `
            -BuildId "42" `
            -BuildNumber "20260917.1")
        Assert-Throws {
            Test-PackageManifest -PackageRoot $packageRoot -ScanForSecrets
        } ("forbidden secret/runtime files: " + [regex]::Escape($relativeQuotesPath.Replace('\', '/')))
        Remove-Item -LiteralPath $quotesPath
    }

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

    $skippedTrx = Join-Path $trxRoot "skipped.trx"
    $skippedFinal = Join-Path $trxRoot "skipped-final.trx"
    Write-Trx -Path $skippedTrx -Results @(
        @{ Id = "1"; Name = "Passes"; Outcome = "Passed" },
        @{ Id = "2"; Name = "Gated"; Outcome = "NotExecuted" }
    )
    $skipCanonical = Merge-TrxResults -InitialPath $skippedTrx -OutputPath $skippedFinal
    Assert-True (
        $skipCanonical.total -eq 2 -and $skipCanonical.executed -eq 1 -and
        $skipCanonical.passed -eq 1 -and $skipCanonical.failed -eq 0 -and $skipCanonical.skipped -eq 1
    ) "Canonical consolidation changed a genuine skip into a pass or failure."
    Assert-True (
        @((Read-TrxResults -Path $skippedFinal).Results | Where-Object outcome -eq "NotExecuted").Count -eq 1
    ) "The final TRX did not retain its skipped result."
    $unfinished = Join-Path $trxRoot "unfinished.trx"
    Write-Trx -Path $unfinished -Results @(@{ Id = "1"; Name = "Unfinished"; Outcome = "Running" })
    Assert-Throws {
        Merge-TrxResults -InitialPath $unfinished -OutputPath (Join-Path $trxRoot "unfinished-final.trx")
    } "unsupported or unfinished outcome"
    Assert-Throws {
        Invoke-CanonicalReport -ReportTool (Join-Path $temporaryRoot "missing.dll") `
            -EvidenceRoot $temporaryRoot -CanonicalResultPath $finalTrx `
            -OutputDirectory (Join-Path $temporaryRoot "report")
    } "utility is missing"

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

    $localRunner = Join-Path $RepositoryRoot "Scripts\run-sfp-basic-al.ps1"
    $localSettingsPath = Join-Path $temporaryRoot "appsettings.local.json"
    $localResults = Join-Path $temporaryRoot "must-not-execute"
    $localSettings = @{
        Credentials = @{ Username = "offline-contract-user"; Password = "offline-contract-password" }
        DuckCreekForms = @{
            Username = "offline-contract-dc"; Password = "offline-contract-dc-password"
            CLASUsername = "offline-contract-clas"; CLASPassword = "offline-contract-clas-password"
        }
        OAuthConfig = @{ ClientSecret = "must-not-import-an-oauth-secret" }
        BusinessOutcomes = @{ ProfilePath = "must-not-override-approved-profile" }
    }
    $localSettingsJson = $localSettings | ConvertTo-Json -Depth 4
    $localSettingsJson | Set-Content -LiteralPath $localSettingsPath -Encoding UTF8
    $credentialEnvironment = @(
        "EQ_USERNAME", "EQ_PASSWORD", "DUCKCREEK_USERNAME", "DUCKCREEK_PASSWORD",
        "CLAS_USERNAME", "CLAS_PASSWORD")
    $originalEnvironment = @{}
    foreach ($name in $credentialEnvironment) {
        $originalEnvironment[$name] = [Environment]::GetEnvironmentVariable($name)
        [Environment]::SetEnvironmentVariable($name, "existing-offline-contract")
    }
    $originalRunId = $env:TEST_RUN_ID
    $originalProfile = $env:TEST_OUTCOME_PROFILE_PATH
    $originalLocalCase = $env:TEST_SGS_LOCAL_CASE
    try {
        $settingsHash = Get-FileSha256 -Path $localSettingsPath
        $receipt = & $localRunner -AppSettingsPath $localSettingsPath `
            -ValidateCredentialsOnly -ResultsDirectory $localResults
        Assert-True (
            $receipt.CredentialSource -eq "ExplicitLocalAppSettings" -and
            $receipt.RequiredCredentialFields -eq 6 -and $receipt.FieldValidationPassed -and
            -not $receipt.ApplicationAccessVerified -and -not $receipt.BusinessTestsExecuted
        ) "Local credential preflight fabricated application access or skipped a required field."
        Assert-True (
            (Get-FileSha256 -Path $localSettingsPath) -eq $settingsHash -and
            -not (Test-Path -LiteralPath $localResults)
        ) "Local credential preflight changed its source file or started a test run."
        Assert-True (
            ($receipt | ConvertTo-Json) -notmatch "offline-contract|must-not-import" -and
            $env:TEST_RUN_ID -eq $originalRunId -and
            $env:TEST_OUTCOME_PROFILE_PATH -eq $originalProfile
        ) "Local credential preflight leaked values or retained an execution-profile override."
        foreach ($name in $credentialEnvironment) {
            Assert-True (
                [Environment]::GetEnvironmentVariable($name) -eq "existing-offline-contract"
            ) "Local credential preflight failed to restore '$name'."
        }
        $sgsReceipt = & $localRunner -Workflow SgsExpertQuoteBopAl `
            -AppSettingsPath $localSettingsPath -ValidateCredentialsOnly -ResultsDirectory $localResults
        Assert-True (
            $sgsReceipt.FieldValidationPassed -and -not $sgsReceipt.BusinessTestsExecuted -and
            $env:TEST_SGS_LOCAL_CASE -eq $originalLocalCase -and
            $env:TEST_RUN_ID -eq $originalRunId -and
            -not (Test-Path -LiteralPath $localResults)
        ) "SGS preflight started execution or retained its local-case permission."
        $existingDotnetFunction = Get-Item -LiteralPath "Function:\dotnet" -ErrorAction SilentlyContinue
        try {
            function dotnet {
                if ($args[0] -ne "restore" -or
                    $env:EQ_USERNAME -ne "offline-contract-user" -or
                    $env:EQ_PASSWORD -ne "offline-contract-password" -or
                    $env:DUCKCREEK_USERNAME -ne "offline-contract-dc" -or
                    $env:DUCKCREEK_PASSWORD -ne "offline-contract-dc-password" -or
                    $env:CLAS_USERNAME -ne "offline-contract-clas" -or
                    $env:CLAS_PASSWORD -ne "offline-contract-clas-password" -or
                    $env:TEST_OUTCOME_PROFILE_PATH -eq "must-not-override-approved-profile") {
                    throw "Local credential handoff or approved profile isolation failed."
                }
                if ($expectedWorkflow -eq "SgsExpertQuoteBopAl" -and
                    ($env:TEST_SGS_LOCAL_CASE -ne "SGS-CLEQ-03-EQ-BOP-SMOKE-TEST:AL-3B2D76491867" -or
                     $env:TEST_ARTIFACT_PROFILE -ne "sgs-cleq-bop-al-local" -or
                     $env:TEST_RUN_ID -notlike "sgs-cleq-bop-al-*")) {
                    throw "The SGS local runner did not select exactly its reviewed case and evidence identity."
                }
                throw "Controlled stop after verifying the credential handoff; no build or tests started."
            }
            foreach ($expectedWorkflow in @("SfpBasicAl", "SgsExpertQuoteBopAl")) {
                Assert-Throws {
                    & $localRunner -Workflow $expectedWorkflow `
                        -AppSettingsPath $localSettingsPath -ResultsDirectory $localResults
                } "Controlled stop after verifying the credential handoff"
                Assert-True ($env:TEST_SGS_LOCAL_CASE -eq $originalLocalCase) `
                    "Failed local execution retained SGS case authorization."
            }
        }
        finally {
            if ($null -eq $existingDotnetFunction) {
                Remove-Item -LiteralPath "Function:\dotnet"
            }
            else {
                Set-Item -LiteralPath "Function:\dotnet" -Value $existingDotnetFunction.ScriptBlock
            }
        }
        foreach ($name in $credentialEnvironment) {
            Assert-True (
                [Environment]::GetEnvironmentVariable($name) -eq "existing-offline-contract"
            ) "Failed local execution did not restore '$name'."
        }
        Assert-Throws {
            & $localRunner -AppSettingsPath (Join-Path $temporaryRoot "missing-settings.json") `
                -ValidateCredentialsOnly
        } "explicitly selected local appsettings file is missing"
        foreach ($invalid in @("", "PLACEHOLDER", 123, '$(UNRESOLVED_PASSWORD)')) {
            $localSettings.Credentials.Password = $invalid
            $localSettings | ConvertTo-Json -Depth 4 |
                Set-Content -LiteralPath $localSettingsPath -Encoding UTF8
            Assert-Throws {
                & $localRunner -AppSettingsPath $localSettingsPath -ValidateCredentialsOnly
            } "Credentials.Password.*missing, non-text, or a placeholder"
        }
        $localSettings.Remove("DuckCreekForms")
        $localSettings.Credentials.Password = "offline-contract-password"
        $localSettings | ConvertTo-Json -Depth 4 |
            Set-Content -LiteralPath $localSettingsPath -Encoding UTF8
        Assert-Throws {
            & $localRunner -AppSettingsPath $localSettingsPath -ValidateCredentialsOnly
        } "DuckCreekForms.Username.*missing"
        '{"Credentials":{"Password":"offline-secret-must-not-be-printed"' |
            Set-Content -LiteralPath $localSettingsPath -Encoding UTF8
        $invalidMessage = $null
        try {
            & $localRunner -AppSettingsPath $localSettingsPath -ValidateCredentialsOnly
        }
        catch {
            $invalidMessage = $_.Exception.Message
        }
        Assert-True (
            $null -ne $invalidMessage -and
            $invalidMessage -match "could not be read as JSON" -and
            $invalidMessage -notmatch "offline-secret"
        ) "Malformed credential JSON exposed its contents or did not fail."
        $receipt = & $localRunner -ValidateCredentialsOnly
        Assert-True (
            $receipt.CredentialSource -eq "ProcessEnvironment" -and $receipt.FieldValidationPassed
        ) "The existing environment/Key Vault handoff no longer works."
        $env:EQ_PASSWORD = ""
        Assert-Throws {
            & $localRunner -ValidateCredentialsOnly
        } "EQ_PASSWORD.*missing"
    }
    finally {
        foreach ($name in $originalEnvironment.Keys) {
            if ($null -eq $originalEnvironment[$name]) {
                if (Test-Path -LiteralPath "Env:\$name") {
                    Remove-Item -LiteralPath "Env:\$name"
                }
            }
            else {
                [Environment]::SetEnvironmentVariable($name, $originalEnvironment[$name])
            }
        }
        $originalEnvironment.Clear()
    }

    $buildTemplate = Get-Content -LiteralPath (
        Join-Path $RepositoryRoot "Pipelines\templates\build-package-stage.yml") -Raw
    $testTemplate = Get-Content -LiteralPath (
        Join-Path $RepositoryRoot "Pipelines\templates\test-shards-stage.yml") -Raw
    $entry = Get-Content -LiteralPath (
        Join-Path $RepositoryRoot "Pipelines\sfp-smoke-adhoc.yml") -Raw
    $buildEntry = Get-Content -LiteralPath (
        Join-Path $RepositoryRoot "Pipelines\build-package-validation.yml") -Raw
    $dataPoolSetup = Get-Content -LiteralPath (
        Join-Path $RepositoryRoot "Pipelines\templates\setup-datapool-stage.yml") -Raw
    $dataPoolProgram = Get-Content -LiteralPath (
        Join-Path $RepositoryRoot "DataPool\Program.cs") -Raw
    [xml]$dataPoolProject = Get-Content -LiteralPath (
        Join-Path $RepositoryRoot "DataPool\DataPool.csproj") -Raw
    foreach ($itemType in @("Content", "None")) {
        $runtimeExclusions = @($dataPoolProject.SelectNodes(
            "/Project/ItemGroup/$itemType[@Update='data\**\*']"))
        Assert-True (
            $runtimeExclusions.Count -eq 1 -and
            $runtimeExclusions[0].GetAttribute("CopyToOutputDirectory") -ceq "Never" -and
            $runtimeExclusions[0].GetAttribute("CopyToPublishDirectory") -ceq "Never"
        ) "DataPool runtime $itemType items must be excluded from both build and publish propagation."
    }
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
    foreach ($pipeline in @(
        @{ Name = "Build/package validation"; Yaml = $buildEntry },
        @{ Name = "Canonical UI validation"; Yaml = $entry }
    )) {
        foreach ($trigger in @("trigger", "pr")) {
            Assert-True (
                [regex]::Matches($pipeline.Yaml, "(?m)^${trigger}:").Count -eq 1 -and
                $pipeline.Yaml -cmatch "(?m)^${trigger}:[ \t]*none[ \t]*\r?$"
            ) "$($pipeline.Name) must explicitly disable its '$trigger' automatic trigger."
        }
        Assert-True (
            $pipeline.Yaml -notmatch "(?m)^resources:"
        ) "$($pipeline.Name) must not introduce resource-triggered execution during cutover."
    }
    Assert-True (
        $buildEntry -match "(?m)^pool:\r?\n  name: Playwright[ \t]*\r?$"
    ) "Build/package validation must use the existing Playwright pool."
    Assert-True (
        [regex]::Matches($buildEntry, "(?m)^  - ").Count -eq 1 -and
        $buildEntry -match "(?m)^stages:\r?\n  - template: templates/build-package-stage\.yml[ \t]*\r?$" -and
        $buildEntry -notmatch "(?m)^(schedules|jobs|steps):"
    ) "Build/package validation must include only the package template, without schedules, UI shards or DataPool setup."

    $schedules = [regex]::Match($entry, "(?ms)^schedules:\r?\n(?<content>.*?)^parameters:")
    $crons = @([regex]::Matches($schedules.Groups["content"].Value, '(?m)^  - cron: "([^"]+)"[ \t]*\r?$') |
        ForEach-Object { $_.Groups[1].Value })
    $scheduleBranches = @([regex]::Matches($schedules.Groups["content"].Value, "(?m)^        - ([^\r\n]+)") |
        ForEach-Object { $_.Groups[1].Value.Trim() })
    Assert-True (
        $schedules.Success -and $crons.Count -eq 2 -and
        @($crons | Sort-Object -Unique).Count -eq 2 -and
        @($crons | Where-Object { $_ -notin @("0 6 * * *", "0 17 * * *") }).Count -eq 0
    ) "Canonical validation must retain both existing Development schedule times."
    Assert-True (
        $scheduleBranches.Count -eq 2 -and
        @($scheduleBranches | Where-Object { $_ -cne "Development" }).Count -eq 0 -and
        [regex]::Matches($schedules.Groups["content"].Value, "(?m)^    always: true[ \t]*\r?$").Count -eq 2
    ) "Canonical schedules must retain Development-only ownership and always-run behavior."

    $executionEnvironments = [regex]::Matches($testTemplate, (
        '(?m)^            displayName: Execute and reconcile shard \$\(SHARD_ID\)\r?\n' +
        '            env:\r?\n(?<content>(?:              [^\r\n]+\r?\n)+)'))
    Assert-True ($executionEnvironments.Count -eq 1) "The canonical shard execution environment is missing or ambiguous."
    $executionEnvironment = @{}
    foreach ($assignment in [regex]::Matches(
        $executionEnvironments[0].Groups["content"].Value,
        "(?m)^              (?<key>[A-Za-z_][A-Za-z0-9_]*):[ \t]*(?<value>[^\r\n]+)")) {
        $key = $assignment.Groups["key"].Value
        Assert-True (-not $executionEnvironment.ContainsKey($key)) "Duplicate test execution environment key '$key'."
        $executionEnvironment[$key] = $assignment.Groups["value"].Value.Trim()
    }
    $expectedVariableMappings = [ordered]@{
        EQ_USERNAME = "EQ_USERNAME"
        EQ_PASSWORD = "EQ_PASSWORD"
        EXPRESS_USERNAME = "EXPRESS_USERNAME"
        EXPRESS_PASSWORD = "EXPRESS_PASSWORD"
        DuckCreekForms__Username = "DUCKCREEK_FORMS_USERNAME"
        DuckCreekForms__Password = "DUCKCREEK_FORMS_PASSWORD"
        DuckCreekForms__CLASUsername = "DUCKCREEK_FORMS_CLAS_USERNAME"
        DuckCreekForms__CLASPassword = "DUCKCREEK_FORMS_CLAS_PASSWORD"
        OAUTH_TOKEN_URL = "OAUTH_TOKEN_URL"
        OAUTH_CLIENT_ID = "OAUTH_CLIENT_ID"
        PING_SECRET_ID = "PING_SECRET_ID"
        PING_TOKEN_ENDPOINT = "PING_TOKEN_ENDPOINT"
        PING_SECRET_ENDPOINT = "PING_SECRET_ENDPOINT"
        PING_BOOTSTRAP_CLIENT_ID = "PING_BOOTSTRAP_CLIENT_ID"
        PING_BOOTSTRAP_CLIENT_SECRET = "PING_BOOTSTRAP_CLIENT_SECRET"
        EXPERT_QUOTE_API_BASE_URL = "EXPERT_QUOTE_API_BASE_URL"
        DATAPOOL_BASE_URL = "DATAPOOL_BASE_URL"
        DATAPOOL_API_KEY = "DATAPOOL_API_KEY"
    }
    foreach ($mapping in $expectedVariableMappings.GetEnumerator()) {
        Assert-True (
            $executionEnvironment.ContainsKey($mapping.Key) -and
            $executionEnvironment[$mapping.Key] -ceq ('$(' + $mapping.Value + ')')
        ) "Execution environment '$($mapping.Key)' must reference its exact ADO variable, never an inline value."
    }
    Assert-True (
        $executionEnvironment["DATAPOOL_REQUIRED"] -ceq '"${{ parameters.dataPoolRequired }}"' -and
        $executionEnvironment["DATAPOOL_AUTO_START"] -ceq '"false"'
    ) "The existing DataPool requiredness or no-auto-start execution policy changed."
    Assert-True (
        $dataPoolProgram -match 'status\s*=\s*"ok"' -and
        $dataPoolSetup -match '\$health\.status\s+-eq\s+"ok"'
    ) "DataPool installation health contract disagrees with the service."
    $shardCatalog = Get-Content -LiteralPath (
        Join-Path $RepositoryRoot "Pipelines\config\shards.json") -Raw |
        ConvertFrom-Json
    Assert-True (
        @($shardCatalog.suites).Count -eq 4 -and
        @($shardCatalog.shards).Count -eq 8
    ) "Shard catalog contains unexpected non-reference suites."
    $packageVersion = (
        Get-Content -LiteralPath (
            Join-Path $RepositoryRoot "Pipelines\package-version.txt") -Raw
    ).Trim()
    $readiness = Get-Content -LiteralPath (
        Join-Path $RepositoryRoot (
            "Resources\Contracts\integration-readiness.json")) -Raw |
        ConvertFrom-Json
    $packageBuilder = Get-Content -LiteralPath (
        Join-Path $RepositoryRoot "Scripts\CI\New-TestPackage.ps1") -Raw
    $stabilization = Get-Content -LiteralPath (
        Join-Path $RepositoryRoot (
            "Scripts\CI\Invoke-StabilizationVerification.ps1")) -Raw
    Assert-True (
        $packageVersion -eq "1.4.0" -and
        $readiness.packageVersion -eq "1.4.0"
    ) "Package/runtime stabilization is not frozen at 1.4.0."
    Assert-True (
        @($readiness.workflows).Count -eq 3 -and
        @($readiness.requiredApprovalRoles).Count -eq 4 -and
        @($readiness.workflows | Where-Object state -ne "Gated").Count -eq 0
    ) "The integration readiness matrix is incomplete or success-shaped."
    Assert-True (
        $packageBuilder -match "Invoke-StabilizationVerification\.ps1" -and
        $stabilization -match "SfpProfileContract" -and
        $stabilization -match "ReadinessOutputPath" -and
        $stabilization -match 'catalogIntegrity = "Passed"' -and
        $stabilization -notmatch "ValidatedByCatalog"
    ) "Package creation bypasses the source-free stabilization gate."

    $roles = @("Architecture/David", "QA", "Security/Operations", "DevOps/ADO")
    $enabled = [PSCustomObject]@{
        workflowId = "enabled-regression"
        state = "Runnable"
        profile = @{ status = "PerCase" }
        selectorFrameStatus = "Approved"
        businessOutcomeStatus = "Approved"
        adoMappingStatus = "Mapped"
        blockers = @()
        approvalEvidence = @($roles | ForEach-Object {
            @{ role = $_; status = "Approved"; required = "Recorded approval evidence" }
        })
    }
    $admissions = @([PSCustomObject]@{ isRunnable = $true })
    Test-WorkflowActivation -Workflow $enabled -RequiredRoles $roles `
        -ProfileAdmissions $admissions
    Assert-True ($true) "Runnable workflows with complete evidence must be accepted."
    $enabled.state = "Gated"
    Assert-Throws {
        Test-WorkflowActivation -Workflow $enabled -RequiredRoles $roles
    } "without explicit blockers"
    $enabled.state = "Runnable"
    $enabled.profile.status = "NonRunnable"
    Assert-Throws {
        Test-WorkflowActivation -Workflow $enabled -RequiredRoles $roles
    } "without all approvals"
    $enabled.profile.status = "PerCase"
    Assert-Throws {
        Test-WorkflowActivation -Workflow $enabled -RequiredRoles $roles
    } "without all approvals"
    Assert-Throws {
        Test-WorkflowActivation -Workflow $enabled -RequiredRoles $roles `
            -ProfileAdmissions @([PSCustomObject]@{ isRunnable = $false })
    } "without all approvals"
    $enabled.blockers = @(@{ owner = "Nobody"; reason = "Unowned" })
    Assert-Throws {
        Test-WorkflowActivation -Workflow $enabled -RequiredRoles $roles
    } "unowned blocker"
    $enabled.blockers = @()
    $enabled.approvalEvidence[0].role = "QA"
    Assert-Throws {
        Test-WorkflowActivation -Workflow $enabled -RequiredRoles $roles
    } "duplicate approval ownership"

    & (Join-Path $PSScriptRoot "Invoke-PackagingContractTests.ps1") `
        -RepositoryRoot $RepositoryRoot -IncludeCompiledInventory:$IncludeCompiledInventory
    Write-Host "CI contract tests passed: $script:Passed assertions."
}
finally {
    if (Test-Path -LiteralPath $temporaryRoot) {
        Remove-Item -LiteralPath $temporaryRoot -Recurse -Force
    }
}
