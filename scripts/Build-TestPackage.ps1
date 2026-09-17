param(
	[Parameter(Mandatory = $true)][string]$StagingDirectory,
	[string]$SourceRoot = (Split-Path $PSScriptRoot -Parent),
	[ValidateSet('Debug', 'Release')][string]$BuildConfiguration = 'Release'
)
$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest

$SourceRoot = [IO.Path]::GetFullPath($SourceRoot)
$package = [IO.Path]::GetFullPath((Join-Path $StagingDirectory 'testpackage'))
$binSource = Join-Path $SourceRoot 'bin'
if ($package.Equals($SourceRoot, [StringComparison]::OrdinalIgnoreCase) -or
	$package.StartsWith($binSource.TrimEnd('\', '/') + [IO.Path]::DirectorySeparatorChar, [StringComparison]::OrdinalIgnoreCase)) {
	throw 'Package staging must be separate from the source bin tree.'
}
$runtimeFiles = @(
	'config/framework.json',
	'scripts/Invoke-ReleaseStage.ps1',
	'scripts/Prepare-ReleaseTestPackage.ps1',
	'tools/release_reporting.py',
	'tools/generate_consolidated_report.py'
)

function Resolve-TestDataDirectory {
	param(
		[Parameter(Mandatory = $true)][string]$Root,
		[Parameter(Mandatory = $true)][string]$ProjectName,
		[Parameter(Mandatory = $true)][string]$CompiledPath
	)

	if (Test-Path -LiteralPath $CompiledPath -PathType Container) {
		return $CompiledPath
	}

	$candidates = @(Get-ChildItem -LiteralPath $Root -Recurse -Directory -Filter 'TestData' -ErrorAction SilentlyContinue |
		Where-Object {
			$full = $_.FullName
			$full -match [regex]::Escape("$ProjectName\TestData") -and
			$full -notmatch '[\\/](bin|obj)[\\/]'
		} |
		Select-Object -ExpandProperty FullName -Unique)

	if ($candidates.Count -gt 0) {
		return $candidates[0]
	}

	return $null
}

$required = @($runtimeFiles)
$testProjects = @('CommercialLines.DuckCreek.Tests', 'CommercialLines.ExpertQuote.Tests', 'PersonalLines.DuckCreek.Tests')
$testDataCopies = @()
foreach ($project in $testProjects) {
	$base = "bin/$project/$BuildConfiguration/net8.0"
	foreach ($name in @("$project.dll", "$project.deps.json", "$project.runtimeconfig.json", 'playwright.ps1', 'Microsoft.Playwright.dll', 'NUnit3.TestAdapter.dll', 'reqnroll.json')) {
		$required += "$base/$name"
	}
	$compiledTestData = Join-Path $SourceRoot "$base/TestData"
	$resolvedTestData = Resolve-TestDataDirectory -Root $SourceRoot -ProjectName $project -CompiledPath $compiledTestData
	if ($null -ne $resolvedTestData) {
		$testDataCopies += @{ Source = $resolvedTestData; Destination = "$base/TestData" }
	} else {
		Write-Warning "TestData was not found for $project. Continuing package build without TestData for this project."
	}
}
$required += "bin/InsuranceAutomation.Core/$BuildConfiguration/net8.0/InsuranceAutomation.Core.dll"
foreach ($relative in $required) {
	if (-not (Test-Path -LiteralPath (Join-Path $SourceRoot $relative) -PathType Leaf)) {
		throw "Cannot publish an incomplete testpackage. Missing: $relative"
	}
}
if (Test-Path -LiteralPath $package) {
	if ((Get-Item -LiteralPath $package).Attributes -band [IO.FileAttributes]::ReparsePoint) { throw 'Package staging cannot be a reparse point.' }
	Remove-Item -LiteralPath $package -Recurse -Force
}
New-Item -ItemType Directory -Path $package -Force | Out-Null
Copy-Item -LiteralPath $binSource -Destination (Join-Path $package 'bin') -Recurse -Force
foreach ($copy in $testDataCopies) {
	$destination = Join-Path $package $copy.Destination
	if (Test-Path -LiteralPath $destination) { Remove-Item -LiteralPath $destination -Recurse -Force }
	New-Item -ItemType Directory -Path (Split-Path $destination -Parent) -Force | Out-Null
	Copy-Item -LiteralPath $copy.Source -Destination $destination -Recurse -Force
}
foreach ($relative in $runtimeFiles) {
	$destination = Join-Path $package $relative
	New-Item -ItemType Directory -Path (Split-Path $destination -Parent) -Force | Out-Null
	Copy-Item -LiteralPath (Join-Path $SourceRoot $relative) -Destination $destination
}
foreach ($directory in @('src', 'tests')) {
	$sourceDirectory = Join-Path $SourceRoot $directory
	if (Test-Path -LiteralPath $sourceDirectory -PathType Container) {
		Get-ChildItem -LiteralPath $sourceDirectory -Recurse -File -Filter '*.cs' |
			Where-Object { $_.FullName -notmatch '[\\/](bin|obj)[\\/]' } |
			ForEach-Object {
				$relative = $_.FullName.Substring($SourceRoot.Length).TrimStart('\', '/')
				$destination = Join-Path $package $relative
				New-Item -ItemType Directory -Path (Split-Path $destination -Parent) -Force | Out-Null
				Copy-Item -LiteralPath $_.FullName -Destination $destination
			}
	}
}
$manifest = @{
	schemaVersion = 2
	buildConfiguration = $BuildConfiguration
	buildId = $env:BUILD_BUILDID
	buildNumber = $env:BUILD_BUILDNUMBER
	sourceVersion = $env:BUILD_SOURCEVERSION
	sourceBranch = $env:BUILD_SOURCEBRANCH
	requiredFiles = $required
	runtimeHashes = @{}
}
foreach ($relative in $required) {
	if (-not (Test-Path -LiteralPath (Join-Path $package $relative) -PathType Leaf)) { throw "Package copy is incomplete: $relative" }
}
foreach ($relative in $runtimeFiles) {
	$manifest.runtimeHashes[$relative] = (Get-FileHash -LiteralPath (Join-Path $package $relative) -Algorithm SHA256).Hash
}
$manifest | ConvertTo-Json -Depth 5 | Set-Content -LiteralPath (Join-Path $package 'package-info.json') -Encoding UTF8
Write-Host "Validated compiled test package: $package"
Write-Host "Build $($manifest.buildId), configuration $BuildConfiguration, commit $($manifest.sourceVersion)"
$global:LASTEXITCODE = 0
