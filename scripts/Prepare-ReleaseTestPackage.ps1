$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest

$sourceRoot = Split-Path $PSScriptRoot -Parent
$configuration = $env:BUILDCONFIGURATION
$stageKey = $env:STAGEKEY
$resultsDirectory = $env:STAGERESULTSDIRECTORY
foreach ($value in @($configuration, $stageKey, $resultsDirectory, $env:AGENT_TEMPDIRECTORY)) {
	if ([string]::IsNullOrWhiteSpace($value) -or $value.Contains('$(')) { throw 'Required release preparation variable is missing.' }
}
if ($configuration -notin @('Debug', 'Release')) { throw 'Unsupported BuildConfiguration.' }
if ($stageKey -notin @('Assembly', 'Suite', 'TestPlan')) { throw 'Unsupported StageKey.' }
if ($env:PLAYWRIGHTBROWSER -notin @('chromium', 'firefox', 'webkit')) { throw 'PlaywrightBrowser must be chromium, firefox, or webkit.' }
$packageRoot = Join-Path $env:AGENT_TEMPDIRECTORY ("FFTestAutomation\{0}\{1}\{2}\{3}\package" -f $env:RELEASE_RELEASEID, $env:RELEASE_ENVIRONMENTID, $env:RELEASE_DEPLOYMENTID, [guid]::NewGuid().ToString('N'))
if ([IO.Path]::IsPathRooted($resultsDirectory) -or $resultsDirectory.Contains(':')) { throw 'StageResultsDirectory must be a relative path inside the package.' }
$resultsRoot = [IO.Path]::GetFullPath((Join-Path $packageRoot $resultsDirectory))
if (-not $resultsRoot.StartsWith($packageRoot + [IO.Path]::DirectorySeparatorChar, [StringComparison]::OrdinalIgnoreCase) -or
	$resultsRoot.StartsWith((Join-Path $packageRoot 'bin') + [IO.Path]::DirectorySeparatorChar, [StringComparison]::OrdinalIgnoreCase) -or
	$resultsRoot.StartsWith((Join-Path $packageRoot 'config') + [IO.Path]::DirectorySeparatorChar, [StringComparison]::OrdinalIgnoreCase) -or
	$resultsRoot -in @((Join-Path $packageRoot 'bin'), (Join-Path $packageRoot 'config'))) { throw 'StageResultsDirectory must stay inside the package and outside bin/config.' }
$binRoot = Join-Path $packageRoot 'bin'
New-Item -ItemType Directory -Path $binRoot -Force | Out-Null
$sourceBin = Join-Path $sourceRoot 'bin'
if (-not (Test-Path -LiteralPath $sourceBin -PathType Container)) { throw 'Run a new CI build: packaged bin folder is missing.' }
& robocopy $sourceBin $binRoot /E /R:2 /W:1 /NFL /NDL /NJH /NJS
if ($LASTEXITCODE -ge 8) { throw "Copying test binaries failed: $LASTEXITCODE" }
$global:LASTEXITCODE = 0
foreach ($project in @('InsuranceAutomation.Core', 'CommercialLines.DuckCreek.Tests', 'CommercialLines.ExpertQuote.Tests', 'PersonalLines.DuckCreek.Tests')) {
	$dll = Join-Path $binRoot "$project\$configuration\net8.0\$project.dll"
	if (-not (Test-Path -LiteralPath $dll -PathType Leaf)) { throw "Required CI binary missing: $dll" }
}

$headless = $true
if (-not [bool]::TryParse($env:HEADLESS, [ref]$headless)) { throw 'Headless must be true or false.' }
$configSource = Join-Path $sourceRoot 'config\framework.json'
$config = Get-Content -LiteralPath $configSource -Raw | ConvertFrom-Json
$config.browser.headless = $headless
$config.browser.fallbackBrowser = $env:PLAYWRIGHTBROWSER
$config.reporting.resultsRoot = $resultsDirectory
$config.reporting.artifactRoot = 'Artifacts'
$configDirectory = Join-Path $packageRoot 'config'
New-Item -ItemType Directory -Path $configDirectory -Force | Out-Null
$frameworkConfig = Join-Path $configDirectory 'framework.json'
$config | ConvertTo-Json -Depth 30 | Set-Content -LiteralPath $frameworkConfig -Encoding UTF8
foreach ($name in @('Runner', 'NUnit', 'NUnitWork', 'Artifacts')) {
	New-Item -ItemType Directory -Path (Join-Path $resultsRoot $name) -Force | Out-Null
}
$runSettingsPath = Join-Path $packageRoot 'Tosca.runsettings'
$escapedResults = [Security.SecurityElement]::Escape($resultsRoot)
$settings = @"
<?xml version="1.0" encoding="utf-8"?>
<RunSettings>
  <RunConfiguration>
	<ResultsDirectory>$escapedResults\Runner</ResultsDirectory>
	<MaxCpuCount>3</MaxCpuCount>
  </RunConfiguration>
  <NUnit>
	<WorkDirectory>$escapedResults\NUnitWork</WorkDirectory>
	<NumberOfTestWorkers>3</NumberOfTestWorkers>
	<UseParentFQNForParametrizedTests>false</UseParentFQNForParametrizedTests>
	<TestOutputXml>$escapedResults\NUnit</TestOutputXml>
  </NUnit>
</RunSettings>
"@
Set-Content -LiteralPath $runSettingsPath -Value $settings -Encoding UTF8
foreach ($entry in @{
	TEST_PACKAGE_ROOT = $packageRoot
	TEST_FRAMEWORK_CONFIG = $frameworkConfig
	TEST_RESULTS_ROOT = $resultsRoot
	TEST_REPOSITORY_ROOT = $packageRoot
	VSTEST_RUNSETTINGS = $runSettingsPath
}.GetEnumerator()) {
	Write-Host "##vso[task.setvariable variable=$($entry.Key)]$($entry.Value)"
}

if ($stageKey -eq 'TestPlan') {
	$runId = 0L
	if (-not [long]::TryParse($env:ONDEMAND_TEST_RUN_ID, [ref]$runId) -or $runId -le 0) {
		if (-not [long]::TryParse($env:MANUALTESTRUNID, [ref]$runId) -or $runId -le 0) { throw 'TestPlan execution requires test.RunId or a positive ManualTestRunId.' }
	}
	Write-Host "##vso[task.setvariable variable=TCM_TEST_RUN_ID]$runId"
}
$playwright = Get-ChildItem -LiteralPath $binRoot -Recurse -File -Filter 'playwright.ps1' |
	Where-Object { Test-Path -LiteralPath (Join-Path $_.Directory.FullName 'Microsoft.Playwright.dll') } | Select-Object -First 1
if (-not $playwright) { throw 'Playwright runtime not found in CI binaries.' }
& $playwright.FullName install $env:PLAYWRIGHTBROWSER
if ($LASTEXITCODE -ne 0) { throw "Playwright installation failed: $LASTEXITCODE" }
Write-Host "Prepared package: $packageRoot"
Write-Host "Results: $resultsRoot; configured scenario retries: $($config.execution.retryCount)"
$global:LASTEXITCODE = 0
