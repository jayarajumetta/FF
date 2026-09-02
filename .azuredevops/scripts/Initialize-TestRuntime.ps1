param(
	[Parameter(Mandatory = $true)][string]$ArtifactRoot,
	[Parameter(Mandatory = $true)][string]$EvidenceRoot,
	[bool]$Headless = $true
)

$ErrorActionPreference = 'Stop'

if (-not (Test-Path -LiteralPath $ArtifactRoot)) {
	throw "Artifact root not found: $ArtifactRoot"
}

$resolvedArtifactRoot = (Resolve-Path -LiteralPath $ArtifactRoot).Path
$runsettingsPath = Join-Path $resolvedArtifactRoot 'Tosca.runsettings'
if (-not (Test-Path -LiteralPath $runsettingsPath)) {
	throw "Run settings file not found: $runsettingsPath"
}

New-Item -ItemType Directory -Force -Path $EvidenceRoot | Out-Null

$configPath = Join-Path $resolvedArtifactRoot 'config\framework.json'
if (-not (Test-Path -LiteralPath $configPath)) {
	throw "Framework config not found: $configPath"
}

$config = Get-Content -Raw -LiteralPath $configPath | ConvertFrom-Json
if ($null -eq $config.browser) {
	throw "Invalid framework config: missing browser section in $configPath"
}
$config.browser.headless = [bool]$Headless
$config | ConvertTo-Json -Depth 100 | Set-Content -LiteralPath $configPath -Encoding UTF8

$playwrightPath = Join-Path $resolvedArtifactRoot 'src\InsuranceAutomation.Core\bin\Release\net8.0\playwright.ps1'
if (-not (Test-Path -LiteralPath $playwrightPath)) {
	$discoveredPlaywright = Get-ChildItem -Path $resolvedArtifactRoot -Filter 'playwright.ps1' -Recurse -File -ErrorAction SilentlyContinue | Select-Object -First 1
	if ($null -eq $discoveredPlaywright) {
		throw "playwright.ps1 not found under artifact root: $resolvedArtifactRoot"
	}
	$playwrightPath = $discoveredPlaywright.FullName
}

& $playwrightPath install chromium
if ($LASTEXITCODE -ne 0) {
	throw "Playwright browser installation failed with exit code $LASTEXITCODE"
}

Write-Host "##vso[task.setvariable variable=VSTEST_RUNSETTINGS]$runsettingsPath"
Write-Host "##vso[task.setvariable variable=TEST_FRAMEWORK_CONFIG]$configPath"
Write-Host "Runtime initialized. ArtifactRoot=$resolvedArtifactRoot EvidenceRoot=$EvidenceRoot Headless=$Headless"
