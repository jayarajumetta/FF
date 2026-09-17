param(
	[Parameter(Mandatory = $true)][ValidateSet('Prepare', 'Publish', 'Collect')][string]$Mode
)
$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest
$root = Split-Path $PSScriptRoot -Parent
$infoPath = Join-Path $root 'package-info.json'
if (-not (Test-Path -LiteralPath $infoPath -PathType Leaf)) { throw "Missing package-info.json at $root. Run the updated CI pipeline and select its testpackage in a new release." }
$info = Get-Content -LiteralPath $infoPath -Raw | ConvertFrom-Json
if ($info.schemaVersion -ne 2) { throw 'Unsupported testpackage schema. Select a new CI build.' }
if ($info.buildConfiguration -ne $env:BUILDCONFIGURATION) { throw "BuildConfiguration must match the packaged configuration: $($info.buildConfiguration)" }
function Resolve-PackageFile([string]$relative) {
	if ([string]::IsNullOrWhiteSpace($relative) -or [IO.Path]::IsPathRooted($relative) -or $relative.Contains(':')) { throw 'Invalid package manifest path.' }
	$path = [IO.Path]::GetFullPath((Join-Path $root $relative))
	if (-not $path.StartsWith($root.TrimEnd('\', '/') + [IO.Path]::DirectorySeparatorChar, [StringComparison]::OrdinalIgnoreCase)) { throw 'Manifest path escapes the package.' }
	if (-not (Test-Path -LiteralPath $path -PathType Leaf)) { throw "Incomplete testpackage. Missing: $relative" }
	return $path
}
foreach ($relative in $info.requiredFiles) { $null = Resolve-PackageFile $relative }
foreach ($relative in @('config/framework.json', 'scripts/Invoke-ReleaseStage.ps1', 'scripts/Prepare-ReleaseTestPackage.ps1', 'tools/release_reporting.py', 'tools/generate_consolidated_report.py')) {
	$path = Resolve-PackageFile $relative
	$expected = $info.runtimeHashes.PSObject.Properties[$relative]
	if ($null -eq $expected -or (Get-FileHash -LiteralPath $path -Algorithm SHA256).Hash -ne $expected.Value) { throw "Runtime checksum mismatch: $relative. Select an intact CI artifact." }
}
Write-Host "Package build: $($info.buildId) ($($info.buildNumber)); branch: $($info.sourceBranch); commit: $($info.sourceVersion)"
Write-Host "Release operation: $Mode; package: $root"
if ($Mode -eq 'Prepare') {
	& (Join-Path $PSScriptRoot 'Prepare-ReleaseTestPackage.ps1')
} else {
	& python (Join-Path $root 'tools/release_reporting.py') $Mode.ToLowerInvariant()
	if ($LASTEXITCODE -ne 0) { throw "$Mode failed with exit code $LASTEXITCODE" }
}
$global:LASTEXITCODE = 0
