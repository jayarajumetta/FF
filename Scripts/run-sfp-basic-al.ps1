[CmdletBinding()]
param(
    [ValidateSet("SfpBasicAl", "SgsExpertQuoteBopAl")]
    [string]$Workflow = "SfpBasicAl",
    [string]$ResultsDirectory = (Join-Path $PSScriptRoot (
        "..\TestResults\$Workflow-" + [Guid]::NewGuid().ToString("N"))),
    [string]$AppSettingsPath,
    [switch]$ValidateCredentialsOnly,
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
$profilePath = Join-Path $root "Resources\ExpectedOutcomes\sfp-basic-al-local.json"
$profile = (Get-Content -LiteralPath $profilePath -Raw |
    ConvertFrom-Json).profiles[0]
$settings = @{
    TEST_ENVIRONMENT = "qa"
    TEST_OUTCOME_PROFILE_PATH = $profilePath
    TEST_ARTIFACT_ROOT = (Join-Path $results "evidence")
    TEST_RUN_ID = ("sfp-basic-al-" + [Guid]::NewGuid().ToString("N"))
    TEST_ATTEMPT_NUMBER = "1"
    TEST_ARTIFACT_PROFILE = "sfp-basic-al-local"
    DATAPOOL_AUTO_START = "false"
    DATAPOOL_REQUIRED = "false"
    DATAPOOL_BASE_URL = ""
    'DataPool__BaseUrl' = ""
    PLAYWRIGHT_HEADLESS = "true"
    'DuckCreekForms__BaselineVersions__SFP_BASIC' =
        [string]$profile.forms.baselineVersion
}
$filter = "TestCategory=AutomationId-SFP-BASIC-POLICY&TestCategory=Shard1&TestCategory=Debug"
$identityPattern = '^SFPBasicPolicy_State\("Alabama","AL",'
if ($Workflow -eq "SgsExpertQuoteBopAl") {
    $filter = 'TestCategory=AutomationId-SGS-CLEQ-03-EQ-BOP-SMOKE-TEST&FullyQualifiedName~03_eq_bop_smoke_test_al.json'
    $identityPattern = '^EQBOPSmokeTest_StateCode\("AL","TestData/Scenarios/Smoke/03_eq_bop_smoke_test_al\.json",'
    $settings.TEST_RUN_ID = "sgs-cleq-bop-al-" + [Guid]::NewGuid().ToString("N")
    $settings.TEST_ARTIFACT_PROFILE = "sgs-cleq-bop-al-local"
    $settings.TEST_SGS_LOCAL_CASE = "SGS-CLEQ-03-EQ-BOP-SMOKE-TEST:AL-3B2D76491867"
}
$credentialFields = [ordered]@{
    EQ_USERNAME = @("Credentials", "Username")
    EQ_PASSWORD = @("Credentials", "Password")
    DUCKCREEK_USERNAME = @("DuckCreekForms", "Username")
    DUCKCREEK_PASSWORD = @("DuckCreekForms", "Password")
    CLAS_USERNAME = @("DuckCreekForms", "CLASUsername")
    CLAS_PASSWORD = @("DuckCreekForms", "CLASPassword")
}
$fromFile = $PSBoundParameters.ContainsKey("AppSettingsPath")
$localSettings = $null
if ($fromFile) {
    if ([string]::IsNullOrWhiteSpace($AppSettingsPath) -or
        -not (Test-Path -LiteralPath $AppSettingsPath -PathType Leaf)) {
        throw "The explicitly selected local appsettings file is missing."
    }
    try {
        $localSettings = Get-Content -LiteralPath $AppSettingsPath -Raw |
            ConvertFrom-Json
    }
    catch {
        throw "The local appsettings file could not be read as JSON. Configuration values are not included in this error."
    }
    if ($localSettings -isnot [PSCustomObject]) {
        throw "The local appsettings file must contain a JSON object."
    }
}
foreach ($entry in $credentialFields.GetEnumerator()) {
    $value = [Environment]::GetEnvironmentVariable($entry.Key)
    if ($fromFile) {
        $section = $localSettings.PSObject.Properties[$entry.Value[0]]
        $field = if ($null -ne $section -and $section.Value -is [PSCustomObject]) {
            $section.Value.PSObject.Properties[$entry.Value[1]]
        } else {
            $null
        }
        $value = if ($null -ne $field) { $field.Value } else { $null }
    }
    if ($value -isnot [string] -or [string]::IsNullOrWhiteSpace($value) -or
        $value.Trim() -match '(?i)^(PLACEHOLDER|CHANGEME|\$\([^)]*\)|\$\{[^}]*\}|<[^>]*>)$') {
        $source = if ($fromFile) { $entry.Value -join "." } else { $entry.Key }
        throw "Required credential '$source' is missing, non-text, or a placeholder."
    }
    if ($fromFile) {
        $settings[$entry.Key] = $value
    }
}
$localSettings = $null
$value = $null
$previous = @{}
try {
    foreach ($name in $settings.Keys) {
        $previous[$name] = [Environment]::GetEnvironmentVariable($name)
        [Environment]::SetEnvironmentVariable($name, $settings[$name])
    }
    if ($ValidateCredentialsOnly) {
        return [PSCustomObject]@{
            CredentialSource = $(if ($fromFile) { "ExplicitLocalAppSettings" } else { "ProcessEnvironment" })
            RequiredCredentialFields = $credentialFields.Count
            FieldValidationPassed = $true
            ApplicationAccessVerified = $false
            BusinessTestsExecuted = $false
        }
    }
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
        $reportToolRoot = Join-Path $root "Tools\SgsReport\bin\Release\net8.0"
        foreach ($name in @("SgsReport.dll", "SgsReport.deps.json", "SgsReport.runtimeconfig.json",
                "TestAutomation.dll", "TestPlanPublisher.dll")) {
            if (-not (Test-Path -LiteralPath (Join-Path $reportToolRoot $name) -PathType Leaf)) {
                throw "The Release reporting runtime is incomplete. Run without -NoBuild before business execution."
            }
        }
        if ($InstallBrowser) {
            & pwsh -NoProfile -File (
                Join-Path $root "bin\Release\net8.0\playwright.ps1") install chromium
            if ($LASTEXITCODE -ne 0) { throw "Playwright installation failed." }
        }
        $trx = Join-Path $results "$Workflow.trx"
        & dotnet test $assembly `
            --filter $filter `
            --logger "trx;LogFileName=$Workflow.trx" `
            --results-directory $results
        $testExit = $LASTEXITCODE
        Import-Module (Join-Path $root "Scripts\CI\PipelineContracts.psm1") -Force
        $result = Read-TrxResults -Path $trx
        $report = Invoke-CanonicalReport `
            -ReportTool (Join-Path $reportToolRoot "SgsReport.dll") `
            -EvidenceRoot $results -CanonicalResultPath $trx `
            -ScenarioRoots @("evidence") -OutputDirectory (Join-Path $results "report")
        if ($result.Results.Count -ne 1 -or
            $result.Results[0].testName -notmatch $identityPattern) {
            throw "The local run did not execute exactly the expected '$Workflow' case."
        }
        if ($testExit -ne 0 -or $result.Results[0].outcome -ne "Passed" -or $report.ExitCode -ne 0) {
            throw "$Workflow did not pass. Review '$trx'; expectations have not been changed."
        }
        Write-Host "$Workflow passed. Results and scenario evidence: $results"
    }
    finally {
        Pop-Location
    }
}
finally {
    foreach ($name in $previous.Keys) {
        if ($null -eq $previous[$name]) {
            if (Test-Path -LiteralPath "Env:\$name") {
                Remove-Item -LiteralPath "Env:\$name" -ErrorAction Stop
            }
        }
        else {
            [Environment]::SetEnvironmentVariable($name, $previous[$name])
        }
    }
    $settings.Clear()
    $previous.Clear()
}
