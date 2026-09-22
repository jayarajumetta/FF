[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string]$PackageRoot,

    [Parameter(Mandatory)]
    [string]$ShardId,

    [ValidateSet("Full", "Debug")]
    [string]$Mode = "Full",

    [Parameter(Mandatory)]
    [string]$ResultsDirectory,

    [ValidateRange(0, 1)]
    [int]$MaxRetryCount = 1
)

$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest

$root = [IO.Path]::GetFullPath($PackageRoot)
$resultsRoot = [IO.Path]::GetFullPath($ResultsDirectory)
if ($resultsRoot.StartsWith(
        $root.TrimEnd('\', '/') + [IO.Path]::DirectorySeparatorChar,
        [StringComparison]::OrdinalIgnoreCase)) {
    throw "Results must be written outside the immutable package root."
}

Import-Module (Join-Path $root "scripts\CI\PipelineContracts.psm1") -Force
$packageManifest = Test-PackageManifest -PackageRoot $root

function Get-EvidenceSummary {
    param(
        [Parameter(Mandatory)][string]$Root,
        [Parameter(Mandatory)][int]$ExpectedCount,
        [Parameter(Mandatory)][string]$Attempt
    )

    $files = @(
        if (Test-Path -LiteralPath $Root -PathType Container) {
            Get-ChildItem -LiteralPath $Root -Recurse `
                -Filter "manifest.json" -File
        }
    )
    if ($files.Count -ne $ExpectedCount) {
        throw "$Attempt evidence count disagreement. Expected=$ExpectedCount, manifests=$($files.Count)."
    }

    $passed = 0
    $failed = 0
    $skipped = 0
    foreach ($manifestFile in $files) {
        try {
            $artifact = Get-Content -LiteralPath $manifestFile.FullName -Raw |
                ConvertFrom-Json
        }
        catch {
            throw "$Attempt evidence manifest '$($manifestFile.FullName)' is corrupt."
        }
        if ($artifact.outcome -eq "Passed" -or
            [string]$artifact.outcome -eq "0") {
            $passed++
        }
        elseif ($artifact.outcome -eq "Failed" -or
            [string]$artifact.outcome -eq "1") {
            $failed++
        }
        elseif ($artifact.outcome -eq "Skipped" -or
            [string]$artifact.outcome -eq "2") {
            $skipped++
        }
        else {
            throw "$Attempt evidence manifest '$($manifestFile.FullName)' has invalid outcome '$($artifact.outcome)'."
        }
        if ([string]::IsNullOrWhiteSpace([string]$artifact.trxMetadataPath) -or
            [string]::IsNullOrWhiteSpace([string]$artifact.timingSummaryPath)) {
            throw "$Attempt evidence manifest '$($manifestFile.FullName)' is incomplete."
        }
    }

    return [PSCustomObject]@{
        Files = $files
        Passed = $passed
        Failed = $failed
        Skipped = $skipped
    }
}

$config = Get-Content -LiteralPath (Join-Path $root "config\shards.json") -Raw |
    ConvertFrom-Json
$shardMatches = @($config.shards | Where-Object id -eq $ShardId)
if ($shardMatches.Count -ne 1) {
    throw "Shard '$ShardId' must have exactly one definition."
}
$shard = $shardMatches[0]
$filter = if ($Mode -eq "Debug") {
    [string]$shard.debugFilter
} else {
    [string]$shard.fullFilter
}

$inventoryFiles = @(
    Get-ChildItem -LiteralPath (Join-Path $root "metadata") `
        -Filter "shards-*-$Mode.json" -File
)
$expectedMatches = [System.Collections.Generic.List[object]]::new()
foreach ($inventoryFile in $inventoryFiles) {
    $inventory = Get-Content -LiteralPath $inventoryFile.FullName -Raw |
        ConvertFrom-Json
    $property = $inventory.shards.PSObject.Properties[$ShardId]
    if ($null -ne $property) {
        $expectedMatches.Add($property.Value)
    }
}
if ($expectedMatches.Count -eq 0) {
    throw "No packaged ownership inventory contains shard '$ShardId' in $Mode mode."
}
$expectedCounts = @($expectedMatches | ForEach-Object { [int]$_.count } | Sort-Object -Unique)
if ($expectedCounts.Count -ne 1) {
    throw "Packaged ownership inventories disagree for shard '$ShardId'."
}
$expectedCount = $expectedCounts[0]
$expectedNames = @(
    $expectedMatches[0].testNames |
        ForEach-Object { [string]$_ } |
        Sort-Object
)
foreach ($expectedMatch in $expectedMatches) {
    $candidateNames = @(
        $expectedMatch.testNames |
            ForEach-Object { [string]$_ } |
            Sort-Object
    )
    if (@(Compare-Object $expectedNames $candidateNames).Count -ne 0) {
        throw "Packaged ownership inventories disagree on test identities for shard '$ShardId'."
    }
}

$testAssembly = Join-Path $root "test\TestAutomation.dll"
$runSettings = Join-Path $root "runsettings\ci.runsettings"
$compiledInventory = Get-Content -LiteralPath (
    Join-Path $root "metadata\test-inventory.json") -Raw | ConvertFrom-Json
$rules = if ($Mode -eq "Debug") {
    @($shard.debugRules)
} else {
    @($shard.fullRules)
}
$discovered = @(Select-TestInventory `
    -Tests @($compiledInventory.tests) `
    -Rules $rules)
if ($discovered.Count -ne $expectedCount) {
    throw "Expected/discovered count disagreement for shard '$ShardId'. Expected=$expectedCount, discovered=$($discovered.Count)."
}
if ($discovered.Count -eq 0) {
    throw "Shard '$ShardId' discovered zero tests."
}

if (Test-Path -LiteralPath $resultsRoot) {
    $existing = @(Get-ChildItem -LiteralPath $resultsRoot -Force)
    if ($existing.Count -gt 0) {
        throw "Results directory '$resultsRoot' is not empty."
    }
}
else {
    New-Item -ItemType Directory -Force -Path $resultsRoot | Out-Null
}

$trxRoot = Join-Path $resultsRoot "trx"
$evidenceRoot = Join-Path $resultsRoot "evidence"
$initialEvidenceRoot = Join-Path $evidenceRoot "initial"
$retryEvidenceRoot = Join-Path $evidenceRoot "retry"
$workRoot = Join-Path $resultsRoot "work"
$executionTestRoot = Join-Path $workRoot "test"
New-Item -ItemType Directory -Force `
    -Path $trxRoot, $evidenceRoot, $executionTestRoot | Out-Null
Copy-Item -Path (Join-Path $root "test\*") `
    -Destination $executionTestRoot -Recurse -Force
$initialPath = Join-Path $trxRoot "$ShardId-initial.trx"
$retryPath = Join-Path $trxRoot "$ShardId-retry.trx"
$finalPath = Join-Path $trxRoot "$ShardId-final.trx"

$previousArtifactRoot = $env:TEST_ARTIFACT_ROOT
$previousRunId = $env:TEST_RUN_ID
$previousAttemptNumber = $env:TEST_ATTEMPT_NUMBER
$env:TEST_ARTIFACT_ROOT = $initialEvidenceRoot
$env:TEST_RUN_ID = "$($packageManifest.build.id)-$ShardId-$([Guid]::NewGuid().ToString('N'))"
$env:TEST_ATTEMPT_NUMBER = "1"

$attempts = 1
$retryExitCode = $null
$retryNames = [System.Collections.Generic.List[string]]::new()
try {
    Push-Location $executionTestRoot
    try {
        & dotnet test "TestAutomation.dll" `
            --filter $filter `
            --settings $runSettings `
            --logger "trx;LogFileName=$initialPath" `
            --results-directory $trxRoot
        $initialExitCode = $LASTEXITCODE
    }
    finally {
        Pop-Location
    }

    $initial = Read-TrxResults -Path $initialPath
    if ($initial.Results.Count -ne $expectedCount) {
        throw "Initial TRX count disagreement for shard '$ShardId'. Expected=$expectedCount, actual=$($initial.Results.Count)."
    }
    $actualNames = @(
        $initial.Results |
            ForEach-Object { [string]$_.testName } |
            Sort-Object
    )
    $identityDifference = @(Compare-Object $expectedNames $actualNames)
    if ($identityDifference.Count -ne 0) {
        $sample = @(
            $identityDifference |
                Select-Object -First 5 |
                ForEach-Object {
                    "$($_.SideIndicator) $($_.InputObject)"
                }
        ) -join "; "
        throw "Initial TRX identity disagreement for shard '$ShardId': $sample."
    }
    $initialEvidence = Get-EvidenceSummary `
        -Root $initialEvidenceRoot `
        -ExpectedCount $expectedCount `
        -Attempt "Initial"
    $initialPassed = @($initial.Results | Where-Object outcome -eq "Passed").Count
    $initialSkipped = @($initial.Results | Where-Object outcome -eq "NotExecuted").Count
    $initialFailed = $initial.Results.Count - $initialPassed - $initialSkipped
    if ($initialEvidence.Passed -ne $initialPassed -or
        $initialEvidence.Failed -ne $initialFailed -or
        $initialEvidence.Skipped -ne $initialSkipped) {
        throw "Initial pass/fail/skip outcomes disagree with the canonical scenario evidence."
    }

    if ($MaxRetryCount -eq 1) {
        $safeSet = @{}
        foreach ($safeTest in @(
            $compiledInventory.tests |
                Where-Object {
                    $_.categories -contains "RetrySafe" -and
                    -not $_.parameterized
                }
        )) {
            $safeSet["$($safeTest.className).$($safeTest.methodName)"] = $true
        }

        foreach ($failure in @($initial.Results | Where-Object outcome -in @("Failed", "Error", "Timeout", "Aborted"))) {
            $unitTest = $initial.Xml.SelectSingleNode(
                "//t:UnitTest[@id='$($failure.testId)']/t:TestMethod",
                $initial.NamespaceManager)
            $fullyQualifiedName = if ($null -eq $unitTest) {
                ""
            } else {
                "$($unitTest.GetAttribute("className")).$($unitTest.GetAttribute("name"))"
            }
            $messageNode = $failure.node.SelectSingleNode(
                "./t:Output/t:ErrorInfo/t:Message",
                $initial.NamespaceManager)
            $failureText = if ($null -eq $messageNode) {
                ""
            } else {
                [string]$messageNode.InnerText
            }
            $decision = Get-RetryDecision `
                -FailureText $failureText `
                -IsRetrySafe $safeSet.ContainsKey($fullyQualifiedName) `
                -IsParameterized ($failure.testName -match '\(')
            if ($decision.ShouldRetry) {
                $retryNames.Add($failure.testName)
            }
            else {
                Write-Host "No retry for '$($failure.testName)': $($decision.Reason)"
            }
        }
    }

    if ($retryNames.Count -gt 0) {
        $retryFilters = @(
            $retryNames | ForEach-Object {
                $escaped = $_.Replace('"', '').Replace("'", "")
                "Name=`"$escaped`""
            }
        )
        $retryFilter = "TestCategory=RetrySafe&(" + ($retryFilters -join "|") + ")"
        $env:TEST_ARTIFACT_ROOT = $retryEvidenceRoot
        $env:TEST_ATTEMPT_NUMBER = "2"
        Push-Location $executionTestRoot
        try {
            & dotnet test "TestAutomation.dll" `
                --filter $retryFilter `
                --settings $runSettings `
                --logger "trx;LogFileName=$retryPath" `
                --results-directory $trxRoot
            $retryExitCode = $LASTEXITCODE
        }
        finally {
            Pop-Location
        }
        $attempts++
        $retry = Read-TrxResults -Path $retryPath
        if ($retry.Results.Count -ne $retryNames.Count) {
            throw "Retry TRX count disagreement for shard '$ShardId'. Expected=$($retryNames.Count), actual=$($retry.Results.Count)."
        }
        $retryEvidence = Get-EvidenceSummary `
            -Root $retryEvidenceRoot `
            -ExpectedCount $retry.Results.Count `
            -Attempt "Retry"
        $retryPassed = @($retry.Results | Where-Object outcome -eq "Passed").Count
        $retrySkipped = @($retry.Results | Where-Object outcome -eq "NotExecuted").Count
        $retryFailed = $retry.Results.Count - $retryPassed - $retrySkipped
        if ($retryEvidence.Passed -ne $retryPassed -or
            $retryEvidence.Failed -ne $retryFailed -or
            $retryEvidence.Skipped -ne $retrySkipped) {
            throw "Retry pass/fail/skip outcomes disagree with the canonical scenario evidence."
        }
        Write-Host "Retry process exit code: $retryExitCode"
    }
    else {
        $retry = $null
        $retryEvidence = [PSCustomObject]@{
            Files = @()
            Passed = 0
            Failed = 0
            Skipped = 0
        }
    }

    $canonical = Merge-TrxResults `
        -InitialPath $initialPath `
        -RetryPath $(if (Test-Path -LiteralPath $retryPath) { $retryPath } else { "" }) `
        -OutputPath $finalPath
    $final = Read-TrxResults -Path $finalPath
    if ($final.Results.Count -ne $expectedCount) {
        throw "Canonical TRX count disagreement for shard '$ShardId'. Expected=$expectedCount, actual=$($final.Results.Count)."
    }

    $manifestFiles = @($initialEvidence.Files) + @($retryEvidence.Files)
    $artifactPassed = $initialEvidence.Passed + $retryEvidence.Passed
    $artifactFailed = $initialEvidence.Failed -
        $retryEvidence.Files.Count + $retryEvidence.Failed
    $artifactSkipped = $initialEvidence.Skipped + $retryEvidence.Skipped
    if ($artifactPassed -ne $canonical.passed -or
        $artifactFailed -ne $canonical.failed -or
        $artifactSkipped -ne $canonical.skipped) {
        throw "Canonical pass/fail/skip outcomes disagree with the reconciled evidence."
    }

    $report = Invoke-CanonicalReport `
        -ReportTool (Join-Path $root "tools\SgsReport\SgsReport.dll") `
        -EvidenceRoot $resultsRoot `
        -CanonicalResultPath $finalPath `
        -ScenarioRoots @("evidence") `
        -OutputDirectory (Join-Path $resultsRoot "report")

    $attachments = @(
        Get-ChildItem -LiteralPath $evidenceRoot -Recurse -File |
            ForEach-Object {
                [PSCustomObject][ordered]@{
                    path = $_.FullName.Substring(
                        $resultsRoot.TrimEnd('\', '/').Length + 1
                    ).Replace('\', '/')
                    size = [long]$_.Length
                    sha256 = Get-FileSha256 -Path $_.FullName
                }
            } |
            Sort-Object path
    )
    if ($attachments.Count -lt $manifestFiles.Count) {
        throw "Publication preparation omitted required scenario evidence."
    }

    $resultManifest = [PSCustomObject][ordered]@{
        schemaVersion = 1
        packageVersion = $packageManifest.packageVersion
        commit = $packageManifest.commit.sha
        buildId = $packageManifest.build.id
        shard = $ShardId
        suite = $shard.suite
        mode = $Mode
        filter = $filter
        expected = $expectedCount
        discovered = $discovered.Count
        reported = $canonical.total
        executed = $canonical.executed
        passed = $canonical.passed
        failed = $canonical.failed
        skipped = $canonical.skipped
        attempts = $attempts
        retried = $canonical.retried
        initialExitCode = $initialExitCode
        retryExitCode = $retryExitCode
        finalTrx = "trx/$ShardId-final.trx"
        finalTrxSha256 = Get-FileSha256 -Path $finalPath
        evidenceManifests = $manifestFiles.Count
        initialEvidenceManifests = $initialEvidence.Files.Count
        retryEvidenceManifests = $retryEvidence.Files.Count
        attachments = $attachments
        reporting = [PSCustomObject][ordered]@{
            exitCode = $report.ExitCode
            reportPath = "report/report.html"
            summaryPath = "report/summary.json"
            summarySha256 = $report.SummarySha256
        }
    }
    $resultManifest | ConvertTo-Json -Depth 8 |
        Set-Content -LiteralPath (Join-Path $resultsRoot "result-manifest.json") `
            -Encoding UTF8

    if ($report.ExitCode -eq 2) {
        throw "Shard '$ShardId' canonical reporting failed with exit code $($report.ExitCode)."
    }
    if ($canonical.failed -ne 0 -or $canonical.skipped -ne 0) {
        throw "Shard '$ShardId' has $($canonical.failed) failed and $($canonical.skipped) skipped canonical result(s)."
    }
    if ($report.ExitCode -ne 0) {
        throw "Shard '$ShardId' reporting disagrees with its passing canonical results."
    }
    if ($retryNames.Count -gt 0 -and $retryExitCode -ne 0) {
        throw "Shard '$ShardId' retry process failed with exit code $retryExitCode."
    }
    if ($initialExitCode -ne 0 -and $canonical.retried -eq 0) {
        throw "Shard '$ShardId' failed and no approved retry produced a passing canonical outcome."
    }

    Write-Host "Shard '$ShardId' passed $($canonical.passed)/$($canonical.total) canonical results."
}
finally {
    $env:TEST_ARTIFACT_ROOT = $previousArtifactRoot
    $env:TEST_RUN_ID = $previousRunId
    $env:TEST_ATTEMPT_NUMBER = $previousAttemptNumber
    if (Test-Path -LiteralPath $workRoot) {
        Remove-Item -LiteralPath $workRoot -Recurse -Force
    }
}
