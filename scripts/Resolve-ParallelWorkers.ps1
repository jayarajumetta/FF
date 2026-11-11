# Resolves the effective NUnit worker count honoring, in precedence order:
#   1. The release pipeline's EnableParallelExecution variable (env:EnableParallelExecution), when explicitly set.
#      This lets an operator disable (or enable) parallelism from the pipeline without any code or config change.
#   2. config/framework.json's execution.parallel flag (the local/default source of truth), when (1) is not set.
#      This lets a developer disable (or enable) parallelism locally by editing JSON, without any code change.
#   3. Parallel enabled (3 workers), if neither (1) nor (2) resolve a value.
# Parallel level is fixed at 3 to match the assembly-level ceiling declared in Parallelization.cs
# ([assembly: LevelOfParallelism(3)]); disabling parallel execution resolves to a single worker (1).
function Resolve-ParallelWorkerCount {
	param(
		[Parameter(Mandatory = $true)][string]$FrameworkConfigPath,
		[int]$ParallelWorkerCount = 3,
		[int]$SequentialWorkerCount = 1
	)

	$enabled = $true
	$pipelineOverride = $env:EnableParallelExecution
	if (-not [string]::IsNullOrWhiteSpace($pipelineOverride)) {
		$parsed = $false
		if (-not [bool]::TryParse($pipelineOverride, [ref]$parsed)) {
			throw "EnableParallelExecution must be 'true' or 'false'. Got: '$pipelineOverride'"
		}
		$enabled = $parsed
	} elseif (Test-Path -LiteralPath $FrameworkConfigPath -PathType Leaf) {
		$config = Get-Content -LiteralPath $FrameworkConfigPath -Raw | ConvertFrom-Json
		if ($null -ne $config.execution -and $null -ne $config.execution.parallel) {
			$enabled = [bool]$config.execution.parallel
		}
	}

	if ($enabled) { return $ParallelWorkerCount }
	return $SequentialWorkerCount
}
