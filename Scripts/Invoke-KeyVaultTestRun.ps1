<#
.SYNOPSIS
    Runs framework tests with credentials loaded from Azure Key Vault.

.DESCRIPTION
    Authenticates Azure CLI with the Playwright user-assigned managed identity,
    reads framework credentials into process-only environment variables, runs
    the requested tests, and restores the previous environment afterward.

.PARAMETER VaultName
    Azure Key Vault name or vault URL. Defaults to the framework automation vault.

.PARAMETER ManagedIdentityClientId
    Client ID for the Playwright user-assigned managed identity.

.PARAMETER AuthenticationMode
    Authentication method. Auto uses managed identity in Azure DevOps and the
    current Azure CLI login elsewhere.

.PARAMETER Filter
    Optional dotnet test filter. When omitted, the complete test project runs.

.PARAMETER ValidateCredentialsOnly
    Verifies that every configured secret can be read without running tests.

.PARAMETER NoBuild
    Passes --no-build to dotnet test.

.EXAMPLE
    .\Scripts\Invoke-KeyVaultTestRun.ps1

.EXAMPLE
    .\Scripts\Invoke-KeyVaultTestRun.ps1 -Filter "Category=SFP&Category=Regression"

.EXAMPLE
    .\Scripts\Invoke-KeyVaultTestRun.ps1 -ValidateCredentialsOnly
#>

[CmdletBinding()]
param(
    [string]$VaultName = "kv-pa-d-tstauto-1",

    [string]$ManagedIdentityClientId = "0baaaf70-3528-475d-9906-506d65b72a77",

    [ValidateSet("Auto", "AzureCli", "ManagedIdentity")]
    [string]$AuthenticationMode = "Auto",

    [string]$Filter,

    [switch]$ValidateCredentialsOnly,

    [switch]$NoBuild
)

$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest

$managedIdentityName = "id-cts-pa-d-tstauto-ado-1"
$projectRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot ".."))
$projectPath = Join-Path $projectRoot "TestAutomation.csproj"
$timestamp = Get-Date -Format "yyyy-MM-dd_HHmmss"
$resultsDirectory = Join-Path $projectRoot "TestResults\KeyVaultRuns"
$trxName = "Framework_$timestamp.trx"

if (-not (Get-Command az -ErrorAction SilentlyContinue)) {
    throw "Azure CLI 'az' is required to authenticate with managed identity and read Key Vault secrets."
}

if ($VaultName -match "^https://") {
    $vaultUri = [Uri]$VaultName
    $VaultName = $vaultUri.Host.Split(".")[0]
}

$resolvedAuthenticationMode = $AuthenticationMode
if ($resolvedAuthenticationMode -eq "Auto") {
    $resolvedAuthenticationMode = if ($env:TF_BUILD -eq "True") {
        "ManagedIdentity"
    }
    else {
        "AzureCli"
    }
}

if ($resolvedAuthenticationMode -eq "ManagedIdentity") {
    Write-Host "Authenticating with managed identity '$managedIdentityName'."
    & az login `
        --identity `
        --client-id $ManagedIdentityClientId `
        --allow-no-subscriptions `
        --output none `
        --only-show-errors
    if ($LASTEXITCODE -ne 0) {
        throw "Azure CLI managed identity authentication failed for '$managedIdentityName'."
    }
}
else {
    Write-Host "Using the current Azure CLI login."
    $tokenExpiry = & az account get-access-token `
        --resource "https://vault.azure.net" `
        --query expiresOn `
        --output tsv `
        --only-show-errors
    if ($LASTEXITCODE -ne 0 -or [string]::IsNullOrWhiteSpace($tokenExpiry)) {
        throw "No usable Azure CLI login was found. Run 'az login' and try again."
    }
}

$secretMap = [ordered]@{
    Credentials__Username         = "pnc-testautomation-credentials-username"
    Credentials__Password         = "pnc-testautomation-credentials-password"
    DuckCreekForms__Username      = "pnc-test-automation-duckcreek-username"
    DUCKCREEK_PASSWORD            = "pnc-test-automation-duckcreek-password"
    DuckCreekForms__CLASUsername  = "pnc-test-automation-clas-username"
    DuckCreekForms__CLASPassword  = "pnc-test-automation-clas-password"
}

$previous = @{}
try {
    foreach ($entry in $secretMap.GetEnumerator()) {
        $value = & az keyvault secret show `
            --vault-name $VaultName `
            --name $entry.Value `
            --query value `
            --output tsv `
            --only-show-errors
        if ($LASTEXITCODE -ne 0 -or [string]::IsNullOrWhiteSpace($value)) {
            throw "Unable to read required Key Vault secret '$($entry.Value)'."
        }

        $previous[$entry.Key] = [Environment]::GetEnvironmentVariable($entry.Key)
        [Environment]::SetEnvironmentVariable($entry.Key, [string]$value)
        $value = $null
    }

    if ($ValidateCredentialsOnly) {
        return [PSCustomObject]@{
            Vault = $VaultName
            AuthenticationMode = $resolvedAuthenticationMode
            RequiredSecrets = $secretMap.Count
            SecretRetrievalPassed = $true
            TestsExecuted = $false
        }
    }

    New-Item -ItemType Directory -Force -Path $resultsDirectory | Out-Null

    $dotnetArguments = @(
        "test"
        $projectPath
        "--logger"
        "trx;LogFileName=$trxName"
        "--results-directory"
        $resultsDirectory
    )
    if (-not [string]::IsNullOrWhiteSpace($Filter)) {
        $dotnetArguments += @("--filter", $Filter)
    }
    if ($NoBuild) {
        $dotnetArguments += "--no-build"
    }

    & dotnet @dotnetArguments
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }

    Write-Host "TRX saved to: $(Join-Path $resultsDirectory $trxName)"
}
finally {
    $value = $null
    foreach ($name in $previous.Keys) {
        [Environment]::SetEnvironmentVariable($name, $previous[$name])
    }

    $previous.Clear()
}
