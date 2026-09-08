param([string]$ResultsDirectory = '')
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'TestOutput.ps1')
$output = Get-TestOutputConfiguration (Split-Path $PSScriptRoot -Parent) $ResultsDirectory
$reportDirectory = Resolve-TestResultsRoot $output.ResultsRoot 'ConsolidatedReport'
$evidence = $output.ArtifactRoot.TrimEnd('\', '/')
if ($reportDirectory.Equals($evidence, [StringComparison]::OrdinalIgnoreCase) -or
	$reportDirectory.StartsWith($evidence + '\', [StringComparison]::OrdinalIgnoreCase) -or
	$evidence.StartsWith($reportDirectory + '\', [StringComparison]::OrdinalIgnoreCase)) {
	throw 'The report directory and reporting.artifactRoot must be separate subfolders.'
}
if (-not (Test-Path -LiteralPath $evidence -PathType Container)) { throw "Completed scenario evidence not found: $evidence. Specify the same -ResultsDirectory used for execution." }
$python = Get-Command python -CommandType Application -ErrorAction Stop | Select-Object -First 1
$generator = Join-Path $output.RepositoryRoot 'tools\generate_consolidated_report.py'
if (-not (Test-Path -LiteralPath $generator -PathType Leaf)) { throw "Report generator not found: $generator" }
$lock = [IO.File]::Open((Join-Path $output.ResultsRoot '.automation-run.lock'), [IO.FileMode]::OpenOrCreate, [IO.FileAccess]::ReadWrite, [IO.FileShare]::None)
try {
	Assert-NoOutputReparsePoints $evidence
	if (Test-Path -LiteralPath $reportDirectory) { Assert-NoOutputReparsePoints $reportDirectory }
	if (-not (Get-ChildItem -LiteralPath $evidence -Recurse -File -Filter 'scenario-result.json' | Select-Object -First 1)) {
		throw "No scenario-result.json files found under $evidence. Existing report and evidence were left unchanged."
	}
	& $python.Source $generator --evidence-root $evidence --source-root $output.RepositoryRoot --output-dir $reportDirectory --fail-on-empty
	if ($LASTEXITCODE -ne 0) { throw "Report generator failed with exit code $LASTEXITCODE" }
	Write-Host "Consolidated report: $(Join-Path $reportDirectory 'report.html')"
} finally { $lock.Dispose() }
