function Get-TestOutputConfiguration {
	param([string]$RepositoryRoot, [string]$ResultsDirectory = '')
	$root = [IO.Path]::GetFullPath($RepositoryRoot)
	$configPath = if ($env:TEST_FRAMEWORK_CONFIG) { $env:TEST_FRAMEWORK_CONFIG } else { 'config\framework.json' }
	if (-not [IO.Path]::IsPathRooted($configPath)) { $configPath = Join-Path $root $configPath }
	$config = Get-Content -LiteralPath $configPath -Raw -ErrorAction Stop | ConvertFrom-Json
	if ([string]::IsNullOrWhiteSpace($ResultsDirectory)) {
		$ResultsDirectory = if ($env:TEST_RESULTS_ROOT) { $env:TEST_RESULTS_ROOT } elseif ($config.reporting.resultsRoot) { $config.reporting.resultsRoot } else { 'TestResults' }
	}
	$resultsRoot = Resolve-TestResultsRoot $root $ResultsDirectory
	$artifactName = if ($null -ne $config.reporting.artifactRoot) { [string]$config.reporting.artifactRoot } else { 'Artifacts' }
	if ([string]::IsNullOrWhiteSpace($artifactName) -or [IO.Path]::IsPathRooted($artifactName)) { throw 'reporting.artifactRoot must be a relative subfolder of the results root.' }
	$artifactRoot = Resolve-TestResultsRoot $resultsRoot $artifactName
	return [pscustomobject]@{ RepositoryRoot = $root; ConfigPath = [IO.Path]::GetFullPath($configPath); ResultsRoot = $resultsRoot; ArtifactRoot = $artifactRoot }
}

function Resolve-TestResultsRoot {
	param([string]$RepositoryRoot, [string]$ResultsDirectory)
	$root = [IO.Path]::GetFullPath($RepositoryRoot).TrimEnd('\', '/')
	if ([string]::IsNullOrWhiteSpace($ResultsDirectory)) { throw 'Results directory cannot be empty.' }
	$path = if ([IO.Path]::IsPathRooted($ResultsDirectory)) { [IO.Path]::GetFullPath($ResultsDirectory) } else { [IO.Path]::GetFullPath((Join-Path $root $ResultsDirectory)) }
	$path = $path.TrimEnd('\', '/')
	if (-not $path.StartsWith($root + [IO.Path]::DirectorySeparatorChar, [StringComparison]::OrdinalIgnoreCase)) { throw 'Results directory must be a subfolder of the repository/package root.' }
	$relative = $path.Substring($root.Length + 1)
	if (($relative -split '[\\/]')[0] -in @('.git', '.azuredevops', 'src', 'tests', 'config', 'scripts', 'tools')) { throw 'Results directory cannot be inside a source/configuration folder.' }
	$current = $path
	while ($current -ne $root) {
		if (Test-Path -LiteralPath $current) {
			$item = Get-Item -LiteralPath $current -Force
			if (-not $item.PSIsContainer -or ($item.Attributes -band [IO.FileAttributes]::ReparsePoint)) { throw "Unsafe results path: $current" }
		}
		$current = Split-Path $current -Parent
	}
	return $path
}

function Assert-NoOutputReparsePoints {
	param([string]$Path)
	foreach ($item in Get-ChildItem -LiteralPath $Path -Force) {
		if ($item.Attributes -band [IO.FileAttributes]::ReparsePoint) { throw "Refusing cleanup of reparse point: $($item.FullName)" }
		if ($item.PSIsContainer) { Assert-NoOutputReparsePoints $item.FullName }
	}
}

function Initialize-TestResultsRoot {
	param([string]$RepositoryRoot, [string]$ResultsDirectory)
	$path = Resolve-TestResultsRoot $RepositoryRoot $ResultsDirectory
	New-Item -ItemType Directory -Path $path -Force | Out-Null
	$marker = Join-Path $path '.automation-results'
	$lockPath = Join-Path $path '.automation-run.lock'
	$lock = [IO.File]::Open($lockPath, [IO.FileMode]::OpenOrCreate, [IO.FileAccess]::ReadWrite, [IO.FileShare]::None)
	try {
		$children = @(Get-ChildItem -LiteralPath $path -Force | Where-Object { $_.Name -ne '.automation-run.lock' })
		if (Test-Path -LiteralPath $marker) {
			if ((Get-Content -LiteralPath $marker -Raw).Trim() -ne 'InsuranceAutomation.Results.v1') { throw "Invalid results ownership marker: $marker" }
		} elseif ($children.Count -gt 0) {
			throw "Refusing to clear unowned nonempty folder: $path. Move existing results elsewhere or choose a new empty results folder."
		}
		Assert-NoOutputReparsePoints $path
		Set-Content -LiteralPath $marker -Value 'InsuranceAutomation.Results.v1' -Encoding ASCII
		foreach ($item in $children) {
			if ($item.Name -ne '.automation-results') { Remove-Item -LiteralPath $item.FullName -Recurse -Force }
		}
		return [pscustomobject]@{ Path = $path; Lock = $lock }
	} catch {
		$lock.Dispose()
		throw
	}
}
