param(
	[Parameter(Mandatory = $true)][string]$ArtifactRoot,
	[Parameter(Mandatory = $true)][string]$ResultsDirectory
)
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'TestOutput.ps1')
$run = Initialize-TestResultsRoot $ArtifactRoot $ResultsDirectory
try {
	$root = $run.Path
	$settingsPath = Join-Path $root 'Tosca.runsettings'
	[xml]$settings = Get-Content -LiteralPath (Join-Path $ArtifactRoot 'Tosca.runsettings') -Raw
	$settings.SelectSingleNode('/RunSettings/RunConfiguration/ResultsDirectory').InnerText = [string](Join-Path $root 'Runner')
	$settings.SelectSingleNode('/RunSettings/NUnit/WorkDirectory').InnerText = [string](Join-Path $root 'NUnitWork')
	$xmlOutput = $settings.CreateElement('TestOutputXml')
	$xmlOutput.InnerText = Join-Path $root 'NUnit'
	[void]$settings.RunSettings.NUnit.AppendChild($xmlOutput)
	foreach ($name in @('Runner', 'NUnitWork', 'NUnit')) { New-Item -ItemType Directory -Path (Join-Path $root $name) -Force | Out-Null }
	$settings.Save($settingsPath)
	Write-Host "##vso[task.setvariable variable=VSTEST_RUNSETTINGS]$settingsPath"
	Write-Host "##vso[task.setvariable variable=TEST_RESULTS_ROOT]$root"
	Write-Host "##vso[task.setvariable variable=TEST_REPOSITORY_ROOT]$ArtifactRoot"
} finally { $run.Lock.Dispose() }
