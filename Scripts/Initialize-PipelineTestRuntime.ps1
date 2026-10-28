[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string]$ArtifactRoot,

    [Parameter(Mandatory)]
    [string]$ResultsRoot,

    [Parameter(Mandatory)]
    [ValidateSet("QA", "IT")]
    [string]$Environment,

    [Parameter(Mandatory)]
    [string]$DataPoolUrl,

    [switch]$ValidateEndpoints
)

$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest

function Test-HttpEndpoint {
    param(
        [Parameter(Mandatory)]
        [string]$Name,

        [Parameter(Mandatory)]
        [string]$Uri
    )

    try {
        $response = Invoke-WebRequest `
            -Uri $Uri `
            -Method Get `
            -MaximumRedirection 0 `
            -TimeoutSec 30 `
            -UseBasicParsing
        $statusCode = [int]$response.StatusCode
    }
    catch {
        if ($_.Exception.Response -and $_.Exception.Response.StatusCode) {
            $statusCode = [int]$_.Exception.Response.StatusCode
        }
        else {
            throw "$Name is unreachable at '$Uri': $($_.Exception.Message)"
        }
    }

    if ($statusCode -lt 200 -or $statusCode -ge 400) {
        throw "$Name returned HTTP $statusCode from '$Uri'."
    }

    Write-Host "$Name is reachable at '$Uri' (HTTP $statusCode)."
}

$resolvedArtifactRoot = [IO.Path]::GetFullPath($ArtifactRoot)
$resolvedResultsRoot = [IO.Path]::GetFullPath($ResultsRoot)
$testsRoot = Join-Path $resolvedArtifactRoot "tests"
$scriptsRoot = Join-Path $resolvedArtifactRoot "scripts"
$runSettingsPath = Join-Path $resolvedArtifactRoot "ci.runsettings"
$testAssembly = Join-Path $testsRoot "TestAutomation.dll"

foreach ($requiredPath in @($testsRoot, $scriptsRoot, $runSettingsPath, $testAssembly)) {
    if (-not (Test-Path -LiteralPath $requiredPath)) {
        throw "Required test-package path is missing: $requiredPath"
    }
}

New-Item -ItemType Directory -Force -Path $resolvedResultsRoot | Out-Null
Write-Host "##vso[task.setvariable variable=TEST_RESULTS_ROOT]$resolvedResultsRoot"

$requiredSecrets = @(
    "Credentials__Username",
    "Credentials__Password",
    "DuckCreekForms__Username",
    "DUCKCREEK_PASSWORD",
    "DuckCreekForms__CLASUsername",
    "DuckCreekForms__CLASPassword"
)
foreach ($secretName in $requiredSecrets) {
    $secretValue = [Environment]::GetEnvironmentVariable($secretName)
    if ([string]::IsNullOrWhiteSpace($secretValue) -or $secretValue -match '^\$\(.+\)$') {
        throw "Required pipeline secret '$secretName' is unavailable. Authorize the PnC_DC_TestAutomation variable group for this pipeline."
    }
}
Write-Host "Required pipeline credentials are available."

$browserPath = if ($env:PLAYWRIGHT_BROWSERS_PATH) {
    $env:PLAYWRIGHT_BROWSERS_PATH
}
elseif ($env:AGENT_TOOLSDIRECTORY) {
    Join-Path $env:AGENT_TOOLSDIRECTORY "playwright-browsers"
}
else {
    Join-Path $env:LOCALAPPDATA "ms-playwright"
}
New-Item -ItemType Directory -Force -Path $browserPath | Out-Null
$env:PLAYWRIGHT_BROWSERS_PATH = $browserPath

$playwrightScript = Get-ChildItem `
    -LiteralPath $testsRoot `
    -Filter "playwright.ps1" `
    -Recurse `
    -File |
    Select-Object -First 1
if (-not $playwrightScript) {
    throw "playwright.ps1 was not included in the immutable test package."
}

$chromium = Get-ChildItem -LiteralPath $browserPath -Directory -Filter "chromium-*" -ErrorAction SilentlyContinue |
    Select-Object -First 1
if (-not $chromium) {
    & $playwrightScript.FullName install chromium
    if ($LASTEXITCODE -ne 0) {
        throw "Playwright Chromium installation failed with exit code $LASTEXITCODE."
    }
}

if ($ValidateEndpoints) {
    $baseConfigPath = Join-Path $testsRoot "appsettings.json"
    $baseConfig = Get-Content -LiteralPath $baseConfigPath -Raw | ConvertFrom-Json
    $expertQuoteBase = [string]$baseConfig.Playwright.ExpertQuoteBase

    $environmentConfigPath = Join-Path $testsRoot "appsettings.$Environment.json"
    if (Test-Path -LiteralPath $environmentConfigPath) {
        $environmentConfig = Get-Content -LiteralPath $environmentConfigPath -Raw | ConvertFrom-Json
        if ($environmentConfig.Playwright -and $environmentConfig.Playwright.ExpertQuoteBase) {
            $expertQuoteBase = [string]$environmentConfig.Playwright.ExpertQuoteBase
        }
    }

    if ([string]::IsNullOrWhiteSpace($expertQuoteBase)) {
        throw "ExpertQuote base URL is not configured for $Environment."
    }

    Test-HttpEndpoint -Name "ExpertQuote $Environment" -Uri $expertQuoteBase

    $dataPoolEndpoint = "$($DataPoolUrl.TrimEnd('/'))/api/quotes"
    try {
        $quotes = Invoke-RestMethod -Uri $dataPoolEndpoint -Method Get -TimeoutSec 15
        Write-Host "DataPool is reachable at '$dataPoolEndpoint'. Quote count: $(@($quotes).Count)."
    }
    catch {
        throw "DataPool is unavailable at '$dataPoolEndpoint': $($_.Exception.Message)"
    }
}

Write-Host "##vso[task.setvariable variable=PLAYWRIGHT_BROWSERS_PATH]$browserPath"
Write-Host "Runtime initialized for $Environment. Results: $resolvedResultsRoot"
