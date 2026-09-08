$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'TestOutput.ps1')
function Assert-Rejected([scriptblock]$Action) {
	$rejected = $false
	try { & $Action } catch { $rejected = $true }
	if (-not $rejected) { throw 'Expected unsafe operation to be rejected.' }
}
$root = Join-Path ([IO.Path]::GetTempPath()) ('output-check-' + [Guid]::NewGuid().ToString('N'))
New-Item -ItemType Directory -Path $root | Out-Null
$run = $null
$oldConfig = $env:TEST_FRAMEWORK_CONFIG
$oldResults = $env:TEST_RESULTS_ROOT
try {
	New-Item -ItemType Directory -Path (Join-Path $root 'config') | Out-Null
	$configFile = Join-Path $root 'config\framework.json'
	Set-Content -LiteralPath $configFile -Value '{"reporting":{"resultsRoot":"Configured Results","artifactRoot":"Evidence"}}'
	$env:TEST_FRAMEWORK_CONFIG = 'config\framework.json'
	$env:TEST_RESULTS_ROOT = $null
	$output = Get-TestOutputConfiguration $root
	if ($output.ArtifactRoot -ne (Join-Path $root 'Configured Results\Evidence')) { throw 'Config-based output resolution failed.' }
	$env:TEST_RESULTS_ROOT = 'Environment Results'
	if ((Get-TestOutputConfiguration $root).ResultsRoot -ne (Join-Path $root 'Environment Results')) { throw 'Environment override failed.' }
	if ((Get-TestOutputConfiguration $root 'Explicit Results').ResultsRoot -ne (Join-Path $root 'Explicit Results')) { throw 'Explicit override failed.' }
	Set-Content -LiteralPath $configFile -Value '{"reporting":{"artifactRoot":"..\\outside"}}'
	Assert-Rejected { Get-TestOutputConfiguration $root }
	Assert-Rejected { Resolve-TestResultsRoot $root '.' }
	Assert-Rejected { Resolve-TestResultsRoot $root '..\outside' }
	Assert-Rejected { Resolve-TestResultsRoot $root 'tests\results' }
	$unowned = Join-Path $root 'Unowned'
	New-Item -ItemType Directory -Path $unowned | Out-Null
	Set-Content -LiteralPath (Join-Path $unowned 'keep.txt') -Value 'keep'
	Assert-Rejected { Initialize-TestResultsRoot $root 'Unowned' }
	if (-not (Test-Path -LiteralPath (Join-Path $unowned 'keep.txt'))) { throw 'Unowned content was deleted.' }
	$run = Initialize-TestResultsRoot $root 'Results With Spaces'
	Set-Content -LiteralPath (Join-Path $run.Path 'prior.trx') -Value 'old'
	Assert-Rejected { Initialize-TestResultsRoot $root 'Results With Spaces' }
	if (-not (Test-Path -LiteralPath (Join-Path $run.Path 'prior.trx'))) { throw 'Concurrent run deleted current evidence.' }
	$run.Lock.Dispose()
	$run = Initialize-TestResultsRoot $root 'Results With Spaces'
	if (Test-Path -LiteralPath (Join-Path $run.Path 'prior.trx')) { throw 'Previous run was not cleared.' }
	Write-Host 'PASS: relative paths, unsafe path rejection, unowned-folder protection, exclusive run lock, repeat-run cleanup.'
} finally {
	$env:TEST_FRAMEWORK_CONFIG = $oldConfig
	$env:TEST_RESULTS_ROOT = $oldResults
	if ($null -ne $run) { $run.Lock.Dispose() }
	Remove-Item -LiteralPath $root -Recurse -Force
}
