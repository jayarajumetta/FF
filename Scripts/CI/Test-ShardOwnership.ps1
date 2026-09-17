[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string]$PackageRoot,

    [Parameter(Mandatory)]
    [ValidateSet(
        "All",
        "BasicPolicy",
        "CE",
        "Forms",
        "ExpertQuotePilot",
        "CommercialDuckCreekPilot")]
    [string]$Suite,

    [ValidateSet("Full", "Debug")]
    [string]$Mode = "Full",

    [int]$ExpectedCount = -1,

    [string]$OutputPath
)

$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest

Import-Module (Join-Path $PSScriptRoot "PipelineContracts.psm1") -Force

$root = [IO.Path]::GetFullPath($PackageRoot)
$configPath = Join-Path $root "config\shards.json"
$inventoryPath = Join-Path $root "metadata\test-inventory.json"

if (-not (Test-Path -LiteralPath $configPath -PathType Leaf)) {
    throw "Shard configuration '$configPath' is missing."
}

try {
    $config = Get-Content -LiteralPath $configPath -Raw | ConvertFrom-Json
}
catch {
    throw "Shard configuration '$configPath' is malformed JSON."
}

if ($config.schemaVersion -ne 1) {
    throw "Unsupported shard configuration schema '$($config.schemaVersion)'."
}

$suiteConfig = @($config.suites | Where-Object name -eq $Suite)
if ($suiteConfig.Count -ne 1) {
    throw "Suite '$Suite' must have exactly one shard configuration."
}
$suiteConfig = $suiteConfig[0]
$selectionFilter = if ($Mode -eq "Debug") {
    [string]$suiteConfig.debugSelectionFilter
} else {
    [string]$suiteConfig.fullSelectionFilter
}
$selectionRules = if ($Mode -eq "Debug") {
    @($suiteConfig.debugRules)
} else {
    @($suiteConfig.fullRules)
}

if (-not (Test-Path -LiteralPath $inventoryPath -PathType Leaf)) {
    throw "Compiled test inventory '$inventoryPath' is missing."
}
$compiledInventory = Get-Content -LiteralPath $inventoryPath -Raw |
    ConvertFrom-Json
$selectedRecords = @(Select-TestInventory `
    -Tests @($compiledInventory.tests) `
    -Rules $selectionRules)
$selected = @($selectedRecords | ForEach-Object { [string]$_.id })

$sets = @{}
$details = [ordered]@{}
foreach ($shardId in @($suiteConfig.shards)) {
    $shard = @($config.shards | Where-Object id -eq $shardId)
    if ($shard.Count -ne 1) {
        throw "Shard '$shardId' must have exactly one definition."
    }
    $shard = $shard[0]
    $filter = if ($Mode -eq "Debug") {
        [string]$shard.debugFilter
    } else {
        [string]$shard.fullFilter
    }
    $rules = if ($Mode -eq "Debug") {
        @($shard.debugRules)
    } else {
        @($shard.fullRules)
    }
    $records = @(Select-TestInventory `
        -Tests @($compiledInventory.tests) `
        -Rules $rules)
    $tests = @($records | ForEach-Object { [string]$_.id })
    $sets[[string]$shardId] = $tests
    $details[[string]$shardId] = [PSCustomObject][ordered]@{
        filter = $filter
        count = $tests.Count
        tests = $tests
        testNames = @($records | ForEach-Object { [string]$_.displayName })
    }
}

$result = Test-ShardOwnershipSets `
    -SelectedTests $selected `
    -ShardTests $sets `
    -ExpectedCount $ExpectedCount

$report = [PSCustomObject][ordered]@{
    schemaVersion = 1
    suite = $Suite
    mode = $Mode
    selectionFilter = $selectionFilter
    selectedCount = $result.selectedCount
    selectedTests = $selected
    shards = [PSCustomObject]$details
}

if (-not [string]::IsNullOrWhiteSpace($OutputPath)) {
    $parent = Split-Path -Parent $OutputPath
    if ($parent) {
        New-Item -ItemType Directory -Force -Path $parent | Out-Null
    }
    $report | ConvertTo-Json -Depth 12 |
        Set-Content -LiteralPath $OutputPath -Encoding UTF8
}

Write-Host "Shard ownership validated: suite=$Suite mode=$Mode selected=$($selected.Count)."
foreach ($entry in $details.GetEnumerator()) {
    Write-Host "  $($entry.Key): $($entry.Value.count)"
}

return $report
