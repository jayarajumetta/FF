Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

function Get-FileSha256 {
    param([Parameter(Mandatory)][string]$Path)

    if (-not (Test-Path -LiteralPath $Path -PathType Leaf)) {
        throw "Required file '$Path' does not exist."
    }

    return (Get-FileHash -LiteralPath $Path -Algorithm SHA256).Hash.ToUpperInvariant()
}

function Get-SafeRelativePath {
    param(
        [Parameter(Mandatory)][string]$Root,
        [Parameter(Mandatory)][string]$Path
    )

    $rootPath = [IO.Path]::GetFullPath($Root).TrimEnd('\', '/') + [IO.Path]::DirectorySeparatorChar
    $filePath = [IO.Path]::GetFullPath($Path)
    if (-not $filePath.StartsWith($rootPath, [StringComparison]::OrdinalIgnoreCase)) {
        throw "Path '$filePath' is outside package root '$rootPath'."
    }

    return $filePath.Substring($rootPath.Length).Replace('\', '/')
}

function Get-PackageInventory {
    param([Parameter(Mandatory)][string]$PackageRoot)

    $root = [IO.Path]::GetFullPath($PackageRoot)
    if (-not (Test-Path -LiteralPath $root -PathType Container)) {
        throw "Package root '$root' does not exist."
    }
    $reparsePoints = @(
        Get-ChildItem -LiteralPath $root -Recurse -Force |
            Where-Object {
                ($_.Attributes -band [IO.FileAttributes]::ReparsePoint) -ne 0
            }
    )
    if ($reparsePoints.Count -gt 0) {
        throw "Package content cannot contain reparse points."
    }

    return @(
        Get-ChildItem -LiteralPath $root -Recurse -File |
            Where-Object { $_.Name -ne "package-manifest.json" } |
            ForEach-Object {
                [PSCustomObject][ordered]@{
                    path = Get-SafeRelativePath -Root $root -Path $_.FullName
                    size = [long]$_.Length
                    sha256 = Get-FileSha256 -Path $_.FullName
                }
            } |
            Sort-Object path
    )
}

function Get-DependencyInventory {
    param([Parameter(Mandatory)][string]$DepsPath)

    $deps = Get-Content -LiteralPath $DepsPath -Raw | ConvertFrom-Json
    if ($null -eq $deps.libraries) {
        throw "Dependency manifest '$DepsPath' has no libraries section."
    }

    return @(
        $deps.libraries.PSObject.Properties |
            ForEach-Object {
                $parts = $_.Name -split '/', 2
                [PSCustomObject][ordered]@{
                    name = $parts[0]
                    version = if ($parts.Count -eq 2) { $parts[1] } else { "" }
                    type = [string]$_.Value.type
                }
            } |
            Sort-Object name, version
    )
}

function New-PackageManifest {
    param(
        [Parameter(Mandatory)][string]$PackageRoot,
        [Parameter(Mandatory)][string]$PackageVersion,
        [Parameter(Mandatory)][string]$CommitSha,
        [Parameter(Mandatory)][string]$BuildId,
        [Parameter(Mandatory)][string]$BuildNumber
    )

    if ($PackageVersion -notmatch '^\d+\.\d+\.\d+([-.][A-Za-z0-9.-]+)?$') {
        throw "Package version '$PackageVersion' is not a supported semantic version."
    }
    if ([string]::IsNullOrWhiteSpace($CommitSha)) {
        throw "A commit SHA is required."
    }

    $depsPath = Join-Path $PackageRoot "test\TestAutomation.deps.json"
    $manifest = [PSCustomObject][ordered]@{
        schemaVersion = 1
        packageVersion = $PackageVersion
        createdUtc = [DateTimeOffset]::UtcNow.ToString("O")
        commit = [PSCustomObject][ordered]@{
            sha = $CommitSha
        }
        build = [PSCustomObject][ordered]@{
            id = $BuildId
            number = $BuildNumber
        }
        runtime = [PSCustomObject][ordered]@{
            targetFramework = "net8.0"
            dotnetSdk = (& dotnet --version).Trim()
            testAssembly = "test/TestAutomation.dll"
            dataPoolAssembly = "datapool/DataPool.dll"
            playwrightScript = "test/playwright.ps1"
        }
        dependencies = Get-DependencyInventory -DepsPath $depsPath
        inventory = Get-PackageInventory -PackageRoot $PackageRoot
    }

    $manifestPath = Join-Path $PackageRoot "package-manifest.json"
    $manifest | ConvertTo-Json -Depth 12 | Set-Content -LiteralPath $manifestPath -Encoding UTF8
    return $manifestPath
}

function Test-PackageManifest {
    param(
        [Parameter(Mandatory)][string]$PackageRoot,
        [switch]$ScanForSecrets
    )

    $root = [IO.Path]::GetFullPath($PackageRoot)
    $manifestPath = Join-Path $root "package-manifest.json"
    if (-not (Test-Path -LiteralPath $manifestPath -PathType Leaf)) {
        throw "Package manifest is missing."
    }

    try {
        $manifest = Get-Content -LiteralPath $manifestPath -Raw | ConvertFrom-Json
    }
    catch {
        throw "Package manifest is malformed JSON."
    }

    if ($manifest.schemaVersion -ne 1 -or
        [string]::IsNullOrWhiteSpace([string]$manifest.packageVersion) -or
        [string]::IsNullOrWhiteSpace([string]$manifest.commit.sha) -or
        [string]::IsNullOrWhiteSpace([string]$manifest.build.id) -or
        [string]::IsNullOrWhiteSpace([string]$manifest.build.number)) {
        throw "Package manifest identity is incomplete."
    }

    $requiredPaths = @(
        "test/TestAutomation.dll",
        "test/TestAutomation.deps.json",
        "test/TestAutomation.runtimeconfig.json",
        "test/playwright.ps1",
        "test/.playwright/package/browsers.json",
        "test/.playwright/package/cli.js",
        "test/appsettings.json",
        "test/appsettings.Dev.json",
        "datapool/DataPool.dll",
        "datapool/DataPool.deps.json",
        "datapool/DataPool.runtimeconfig.json",
        "tools/CiTestInventory/CiTestInventory.dll",
        "tools/CiTestInventory/CiTestInventory.deps.json",
        "tools/CiTestInventory/CiTestInventory.runtimeconfig.json",
        "metadata/test-inventory.json",
        "metadata/shards-All-Full.json",
        "metadata/shards-All-Debug.json",
        "metadata/shards-Forms-Full.json",
        "runsettings/ci.runsettings",
        "config/shards.json",
        "scripts/CI/PipelineContracts.psm1",
        "scripts/CI/Invoke-TestShard.ps1",
        "scripts/CI/Test-ShardOwnership.ps1",
        "scripts/CI/Install-Playwright.ps1",
        "scripts/CI/Test-TestPackage.ps1",
        "tools/reports/Cleanup-TestArtifacts.ps1",
        "tools/reports/Extract-SFPPremiums.ps1",
        "tools/reports/FormsCheck.ps1"
    )

    $inventory = @($manifest.inventory)
    if ($inventory.Count -eq 0) {
        throw "Package manifest inventory is empty."
    }

    $manifestPaths = @($inventory | ForEach-Object { [string]$_.path })
    foreach ($required in $requiredPaths) {
        if ($manifestPaths -notcontains $required) {
            throw "Package inventory is missing '$required'."
        }
    }
    foreach ($requiredPrefix in @(
        "test/Resources/Contracts/",
        "test/Resources/ExpectedForms/",
        "test/Resources/ExpectedOutcomes/"
    )) {
        if (@($manifestPaths | Where-Object {
                    $_.StartsWith(
                        $requiredPrefix,
                        [StringComparison]::OrdinalIgnoreCase)
                }).Count -eq 0) {
            throw "Package inventory has no files under '$requiredPrefix'."
        }
    }

    $actual = @(Get-PackageInventory -PackageRoot $root)
    if ($actual.Count -ne $inventory.Count) {
        throw "Package inventory count mismatch. Manifest=$($inventory.Count), actual=$($actual.Count)."
    }

    $byPath = @{}
    foreach ($entry in $inventory) {
        $path = [string]$entry.path
        if ($byPath.ContainsKey($path)) {
            throw "Package manifest contains duplicate path '$path'."
        }
        $byPath[$path] = $entry
    }

    foreach ($entry in $actual) {
        if (-not $byPath.ContainsKey($entry.path)) {
            throw "Package contains unmanifested file '$($entry.path)'."
        }
        $expected = $byPath[$entry.path]
        if ([long]$expected.size -ne [long]$entry.size -or
            [string]$expected.sha256 -ne [string]$entry.sha256) {
            throw "Package checksum or size mismatch for '$($entry.path)'."
        }
    }

    $forbiddenPathPattern =
        '(?i)(^|/)(quotes\.json|QuoteNumber\.txt|nunit_random_seed\.tmp|seed\.tmp)$|\.(pfx|p12|pem|key|snk|trx)$'
    $forbidden = @($manifestPaths | Where-Object { $_ -match $forbiddenPathPattern })
    if ($forbidden.Count -gt 0) {
        throw "Package contains forbidden secret/runtime files: $($forbidden -join ', ')."
    }

    if ($ScanForSecrets) {
        $textExtensions = @(
            ".config", ".json", ".md", ".ps1", ".runsettings",
            ".txt", ".xml", ".yaml", ".yml"
        )
        $secretPattern =
            '(?i)-----BEGIN (RSA |EC |OPENSSH )?PRIVATE KEY-----|(password|client[_-]?secret|api[_-]?key|access[_-]?token)\s*["'']?\s*[:=]\s*["''][^"'']{8,}["'']'
        foreach ($entry in $inventory) {
            $extension = [IO.Path]::GetExtension([string]$entry.path)
            if ($textExtensions -notcontains $extension) {
                continue
            }

            $content = Get-Content -LiteralPath (Join-Path $root $entry.path.Replace('/', '\')) -Raw
            if ($content -match $secretPattern) {
                throw "Potential secret literal detected in package file '$($entry.path)'."
            }
        }
    }

    return $manifest
}

function Get-CompiledTestInventory {
    param(
        [Parameter(Mandatory)][string]$InventoryTool,
        [Parameter(Mandatory)][string]$TestAssembly,
        [Parameter(Mandatory)][string]$OutputPath
    )

    foreach ($required in @($InventoryTool, $TestAssembly)) {
        if (-not (Test-Path -LiteralPath $required -PathType Leaf)) {
            throw "Inventory input '$required' does not exist."
        }
    }

    & dotnet $InventoryTool $TestAssembly $OutputPath
    if ($LASTEXITCODE -ne 0) {
        throw "Compiled test inventory generation failed."
    }

    try {
        $inventory = Get-Content -LiteralPath $OutputPath -Raw | ConvertFrom-Json
    }
    catch {
        throw "Compiled test inventory '$OutputPath' is malformed JSON."
    }
    if ($inventory.schemaVersion -ne 1 -or
        [int]$inventory.count -le 0 -or
        @($inventory.tests).Count -ne [int]$inventory.count) {
        throw "Compiled test inventory '$OutputPath' is invalid or empty."
    }

    return $inventory
}

function Select-TestInventory {
    param(
        [Parameter(Mandatory)][object[]]$Tests,
        [Parameter(Mandatory)][object[]]$Rules
    )

    return @(
        $Tests | Where-Object {
            $test = $_
            $categories = @($test.categories)
            $matched = $false
            foreach ($rule in $Rules) {
                $allProperty = $rule.PSObject.Properties["all"]
                $noneProperty = $rule.PSObject.Properties["none"]
                $all = if ($null -eq $allProperty) {
                    @()
                } else {
                    @($allProperty.Value)
                }
                $none = if ($null -eq $noneProperty) {
                    @()
                } else {
                    @($noneProperty.Value)
                }
                $hasAll = @($all | Where-Object { $categories -notcontains $_ }).Count -eq 0
                $hasNone = @($none | Where-Object { $categories -contains $_ }).Count -eq 0
                if ($hasAll -and $hasNone) {
                    $matched = $true
                    break
                }
            }
            $matched
        }
    )
}

function Test-ShardOwnershipSets {
    param(
        [Parameter(Mandatory)][string[]]$SelectedTests,
        [Parameter(Mandatory)][hashtable]$ShardTests,
        [int]$ExpectedCount = -1
    )

    $selected = @($SelectedTests | Sort-Object -Unique)
    if ($selected.Count -eq 0) {
        throw "The selected gated suite discovered zero tests."
    }
    if ($SelectedTests.Count -ne $selected.Count) {
        throw "The selected gated suite contains duplicate test identities."
    }
    if ($ExpectedCount -ge 0 -and $selected.Count -ne $ExpectedCount) {
        throw "Expected/discovered test count disagreement. Expected=$ExpectedCount, discovered=$($selected.Count)."
    }

    $owners = @{}
    foreach ($shardId in ($ShardTests.Keys | Sort-Object)) {
        $tests = @($ShardTests[$shardId])
        if ($tests.Count -eq 0) {
            throw "Shard '$shardId' discovered zero tests."
        }
        foreach ($test in $tests) {
            if ($selected -notcontains $test) {
                throw "Shard '$shardId' owns test '$test' outside the selected suite."
            }
            if (-not $owners.ContainsKey($test)) {
                $owners[$test] = [System.Collections.Generic.List[string]]::new()
            }
            $owners[$test].Add([string]$shardId)
        }
    }

    $unassigned = @($selected | Where-Object { -not $owners.ContainsKey($_) })
    if ($unassigned.Count -gt 0) {
        throw "Selected gated tests are unassigned: $($unassigned -join ', ')."
    }

    $overlap = @(
        $owners.GetEnumerator() |
            Where-Object { $_.Value.Count -ne 1 } |
            ForEach-Object { "$($_.Key) [$($_.Value -join ',')]" }
    )
    if ($overlap.Count -gt 0) {
        throw "Shard ownership overlaps: $($overlap -join '; ')."
    }

    $counts = [ordered]@{}
    foreach ($shardId in ($ShardTests.Keys | Sort-Object)) {
        $counts[[string]$shardId] = @($ShardTests[$shardId]).Count
    }

    return [PSCustomObject][ordered]@{
        selectedCount = $selected.Count
        shardCounts = [PSCustomObject]$counts
    }
}

function Read-TrxResults {
    param([Parameter(Mandatory)][string]$Path)

    if (-not (Test-Path -LiteralPath $Path -PathType Leaf)) {
        throw "TRX result '$Path' is missing."
    }
    if ((Get-Item -LiteralPath $Path).Length -eq 0) {
        throw "TRX result '$Path' is empty."
    }

    try {
        [xml]$xml = Get-Content -LiteralPath $Path -Raw
    }
    catch {
        throw "TRX result '$Path' is malformed XML."
    }

    $manager = New-Object System.Xml.XmlNamespaceManager($xml.NameTable)
    $manager.AddNamespace("t", "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")
    $nodes = @($xml.SelectNodes("//t:UnitTestResult", $manager))
    if ($nodes.Count -eq 0) {
        throw "TRX result '$Path' contains zero test results."
    }

    $results = @(
        $nodes | ForEach-Object {
            [PSCustomObject][ordered]@{
                testId = $_.GetAttribute("testId")
                testName = $_.GetAttribute("testName")
                outcome = $_.GetAttribute("outcome")
                node = $_
            }
        }
    )
    $duplicates = @($results | Group-Object testName | Where-Object Count -gt 1)
    if ($duplicates.Count -gt 0) {
        throw "TRX result '$Path' contains duplicate executions: $($duplicates.Name -join ', ')."
    }

    $counters = $xml.SelectSingleNode("//t:ResultSummary/t:Counters", $manager)
    if ($null -eq $counters) {
        throw "TRX result '$Path' has no result counters."
    }
    $counterValues = @{}
    foreach ($name in @("total", "executed", "passed", "failed", "notExecuted")) {
        $value = $counters.GetAttribute($name)
        if ($value -notmatch '^\d+$') {
            throw "TRX result '$Path' has an invalid '$name' counter."
        }
        $counterValues[$name] = [int]$value
    }
    $nodePassed = @($results | Where-Object outcome -eq "Passed").Count
    $nodeFailed = @($results | Where-Object outcome -eq "Failed").Count
    if ($counterValues.total -ne $results.Count -or
        $counterValues.passed -ne $nodePassed -or
        $counterValues.failed -ne $nodeFailed -or
        $counterValues.executed -lt ($nodePassed + $nodeFailed) -or
        $counterValues.executed -gt $counterValues.total -or
        $counterValues.notExecuted -gt $counterValues.total) {
        throw "TRX result '$Path' counters disagree with its test results."
    }

    return [PSCustomObject]@{
        Xml = $xml
        NamespaceManager = $manager
        Results = $results
    }
}

function Get-RetryDecision {
    param(
        [Parameter(Mandatory)][string]$FailureText,
        [Parameter(Mandatory)][bool]$IsRetrySafe,
        [Parameter(Mandatory)][bool]$IsParameterized
    )

    $transientPattern =
        '(?is)(timeout|timed out|net::err_|502|503|504|service unavailable|bad gateway|gateway timeout|connection.*(reset|refused|closed|aborted)|socket|dns|ssl|tls|httprequestexception|taskcanceledexception|econnreset|etimedout|enotfound|eai_again|target (page|context|browser) has been closed|execution context was destroyed|websocket|temporary failure|transport connection)'
    $businessPattern =
        '(?is)(premium|mismatch|assertion|expected:|forms validation|baseline|business outcome|locator|strict mode|no element|not found|test data|configuration|checksum|identity)'

    if (-not $IsRetrySafe) {
        return [PSCustomObject]@{ ShouldRetry = $false; Reason = "Test is not marked RetrySafe." }
    }
    if ($IsParameterized) {
        return [PSCustomObject]@{ ShouldRetry = $false; Reason = "Parameterized/state-changing tests are not retried." }
    }
    if ($FailureText -match $businessPattern) {
        return [PSCustomObject]@{ ShouldRetry = $false; Reason = "Failure is deterministic or business-related." }
    }
    if ($FailureText -notmatch $transientPattern) {
        return [PSCustomObject]@{ ShouldRetry = $false; Reason = "Failure is not an approved transient failure." }
    }

    return [PSCustomObject]@{ ShouldRetry = $true; Reason = "RetrySafe test matched an approved transient failure." }
}

function Merge-TrxResults {
    param(
        [Parameter(Mandatory)][string]$InitialPath,
        [string]$RetryPath,
        [Parameter(Mandatory)][string]$OutputPath
    )

    $initial = Read-TrxResults -Path $InitialPath
    $retryCount = 0
    if (-not [string]::IsNullOrWhiteSpace($RetryPath)) {
        $retry = Read-TrxResults -Path $RetryPath
        $initialByName = @{}
        foreach ($result in $initial.Results) {
            $initialByName[$result.testName] = $result.node
        }
        foreach ($retryResult in $retry.Results) {
            if (-not $initialByName.ContainsKey($retryResult.testName)) {
                throw "Retry TRX contains unexpected test '$($retryResult.testName)'."
            }
            $oldNode = $initialByName[$retryResult.testName]
            $replacement = $initial.Xml.ImportNode($retryResult.node, $true)
            foreach ($identityAttribute in @("executionId", "testId", "testListId")) {
                if ($oldNode.HasAttribute($identityAttribute)) {
                    $replacement.SetAttribute(
                        $identityAttribute,
                        $oldNode.GetAttribute($identityAttribute))
                }
            }
            [void]$oldNode.ParentNode.ReplaceChild($replacement, $oldNode)
            $initialByName[$retryResult.testName] = $replacement
            $retryCount++
        }
    }

    $manager = $initial.NamespaceManager
    $resultNodes = @($initial.Xml.SelectNodes("//t:UnitTestResult", $manager))
    foreach ($resultNode in $resultNodes) {
        if ($resultNode.GetAttribute("outcome") -ne "Passed") {
            $resultNode.SetAttribute("outcome", "Failed")
        }
    }
    $passed = @($resultNodes | Where-Object { $_.GetAttribute("outcome") -eq "Passed" }).Count
    $failed = @($resultNodes | Where-Object { $_.GetAttribute("outcome") -eq "Failed" }).Count
    $counters = $initial.Xml.SelectSingleNode("//t:ResultSummary/t:Counters", $manager)
    if ($null -eq $counters) {
        throw "Initial TRX has no result counters."
    }
    $counters.SetAttribute("total", [string]$resultNodes.Count)
    $counters.SetAttribute("executed", [string]$resultNodes.Count)
    $counters.SetAttribute("passed", [string]$passed)
    $counters.SetAttribute("failed", [string]$failed)
    $counters.SetAttribute("notExecuted", "0")

    $summary = $initial.Xml.SelectSingleNode("//t:ResultSummary", $manager)
    $summary.SetAttribute("outcome", $(if ($failed -eq 0) { "Completed" } else { "Failed" }))

    $parent = Split-Path -Parent $OutputPath
    if ($parent) {
        New-Item -ItemType Directory -Force -Path $parent | Out-Null
    }
    $initial.Xml.Save($OutputPath)

    return [PSCustomObject][ordered]@{
        total = $resultNodes.Count
        passed = $passed
        failed = $failed
        retried = $retryCount
    }
}

Export-ModuleMember -Function @(
    "Get-FileSha256",
    "Get-PackageInventory",
    "New-PackageManifest",
    "Test-PackageManifest",
    "Get-CompiledTestInventory",
    "Select-TestInventory",
    "Test-ShardOwnershipSets",
    "Read-TrxResults",
    "Get-RetryDecision",
    "Merge-TrxResults"
)
