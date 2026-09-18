[CmdletBinding()]
param(
    [string]$ResultsDirectory = (Join-Path $PSScriptRoot (
        "..\TestResults\SfpBasicAl-" + [Guid]::NewGuid().ToString("N"))),
    [switch]$NoBuild,
    [switch]$InstallBrowser
)

$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest
$root = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot ".."))
$results = [IO.Path]::GetFullPath($ResultsDirectory)
if ((Test-Path -LiteralPath $results) -and
    @(Get-ChildItem -LiteralPath $results -Force).Count -gt 0) {
    throw "Use an empty results directory for this state-changing, non-retried run."
}
foreach ($name in @(
    "EQ_USERNAME", "EQ_PASSWORD",
    "CLAS_USERNAME", "CLAS_PASSWORD",
    "DUCKCREEK_USERNAME", "DUCKCREEK_PASSWORD")) {
    if ([string]::IsNullOrWhiteSpace(
        [Environment]::GetEnvironmentVariable($name))) {
        throw "Required credential environment variable '$name' is missing."
    }
}

$profilePath = Join-Path $root "Resources\ExpectedOutcomes\sfp-basic-al-local.json"
$profile = (Get-Content -LiteralPath $profilePath -Raw |
    ConvertFrom-Json).profiles[0]
$settings = @{
    TEST_ENVIRONMENT = "qa"
    TEST_OUTCOME_PROFILE_PATH = $profilePath
    TEST_ARTIFACT_ROOT = (Join-Path $results "evidence")
    TEST_RUN_ID = ("sfp-basic-al-" + [Guid]::NewGuid().ToString("N"))
    TEST_ARTIFACT_PROFILE = "sfp-basic-al-local"
    DATAPOOL_AUTO_START = "false"
    DATAPOOL_REQUIRED = "false"
    DATAPOOL_BASE_URL = ""
    'DataPool__BaseUrl' = ""
    PLAYWRIGHT_HEADLESS = "true"
    'DuckCreekForms__BaselineVersions__SFP_BASIC' =
        [string]$profile.forms.baselineVersion
}
$previous = @{}
foreach ($name in $settings.Keys) {
    $previous[$name] = [Environment]::GetEnvironmentVariable($name)
    [Environment]::SetEnvironmentVariable($name, $settings[$name])
}

try {
    Push-Location $root
    try {
        if (-not $NoBuild) {
            & dotnet restore .\Playwright_POC.sln --locked-mode
            if ($LASTEXITCODE -ne 0) { throw "Locked restore failed." }
            & dotnet build .\Playwright_POC.sln -c Release --no-restore
            if ($LASTEXITCODE -ne 0) { throw "Release build failed." }
        }
        $assembly = Join-Path $root "bin\Release\net8.0\TestAutomation.dll"
        if (-not (Test-Path -LiteralPath $assembly -PathType Leaf)) {
            throw "The Release test assembly is missing. Run without -NoBuild."
        }
        if ($InstallBrowser) {
            & pwsh -NoProfile -File (
                Join-Path $root "bin\Release\net8.0\playwright.ps1") install chromium
            if ($LASTEXITCODE -ne 0) { throw "Playwright installation failed." }
        }
        $trx = Join-Path $results "SfpBasicAl.trx"
        & dotnet test $assembly `
            --filter ("TestCategory=AutomationId-SFP-BASIC-POLICY&" +
                "TestCategory=Shard1&TestCategory=Debug") `
            --logger "trx;LogFileName=SfpBasicAl.trx" `
            --results-directory $results
        $testExit = $LASTEXITCODE
        Import-Module (Join-Path $root "Scripts\CI\PipelineContracts.psm1") -Force
        $result = Read-TrxResults -Path $trx
        if ($result.Results.Count -ne 1 -or
            $result.Results[0].testName -notmatch '^SFPBasicPolicy_State\("Alabama","AL",') {
            throw "The local run did not execute exactly the expected Alabama Basic case."
        }
        if ($testExit -ne 0 -or $result.Results[0].outcome -ne "Passed") {
            throw "SFP Basic Alabama did not pass. Review '$trx'; expectations have not been changed."
        }
        Write-Host "SFP Basic Alabama passed. Results and scenario evidence: $results"
    }
    finally {
        Pop-Location
    }
}
finally {
    foreach ($name in $settings.Keys) {
        [Environment]::SetEnvironmentVariable($name, $previous[$name])
    }
}
