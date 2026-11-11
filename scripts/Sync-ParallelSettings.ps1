param(
	[Parameter(Mandatory = $true)][string]$RepositoryRoot
)
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'Resolve-ParallelWorkers.ps1')

$runSettingsPath = Join-Path $RepositoryRoot 'Tosca.runsettings'
if (-not (Test-Path -LiteralPath $runSettingsPath -PathType Leaf)) { return }

$frameworkConfigPath = Join-Path $RepositoryRoot 'config\framework.json'
$workers = Resolve-ParallelWorkerCount -FrameworkConfigPath $frameworkConfigPath

[xml]$settings = Get-Content -LiteralPath $runSettingsPath -Raw
$maxCpuCountNode = $settings.SelectSingleNode('/RunSettings/RunConfiguration/MaxCpuCount')
$numberOfWorkersNode = $settings.SelectSingleNode('/RunSettings/NUnit/NumberOfTestWorkers')
$changed = $false
if ($null -ne $maxCpuCountNode -and $maxCpuCountNode.InnerText -ne [string]$workers) {
	$maxCpuCountNode.InnerText = [string]$workers
	$changed = $true
}
if ($null -ne $numberOfWorkersNode -and $numberOfWorkersNode.InnerText -ne [string]$workers) {
	$numberOfWorkersNode.InnerText = [string]$workers
	$changed = $true
}
if ($changed) {
	$settings.Save($runSettingsPath)
	Write-Host "Tosca.runsettings parallel worker count synced to $workers (source: $(if ($env:EnableParallelExecution) { 'EnableParallelExecution pipeline variable' } else { 'config/framework.json execution.parallel' }))."
}
