[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string]$VaultName,
    [string]$ResultsDirectory,
    [switch]$NoBuild,
    [switch]$InstallBrowser
)

$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest

if (-not (Get-Command az -ErrorAction SilentlyContinue)) {
    throw "Azure CLI 'az' is required to read Key Vault secrets."
}

if ($VaultName -match "^https://") {
    $uri = [Uri]$VaultName
    $VaultName = $uri.Host.Split(".")[0]
}

$secretMap = [ordered]@{
    EQ_USERNAME          = "pnc-testautomation-credentials-username"
    EQ_PASSWORD          = "pnc-testautomation-credentials-password"
    DUCKCREEK_USERNAME   = "pnc-test-automation-duckcreek-username"
    DUCKCREEK_PASSWORD   = "pnc-test-automation-duckcreek-password"
    CLAS_USERNAME        = "pnc-test-automation-clas-username"
    CLAS_PASSWORD        = "pnc-test-automation-clas-password"
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
    }

    $arguments = @()
    if (-not [string]::IsNullOrWhiteSpace($ResultsDirectory)) {
        $arguments += "-ResultsDirectory"
        $arguments += $ResultsDirectory
    }
    if ($NoBuild) {
        $arguments += "-NoBuild"
    }
    if ($InstallBrowser) {
        $arguments += "-InstallBrowser"
    }

    & (Join-Path $PSScriptRoot "run-sfp-basic-al.ps1") @arguments
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }
}
finally {
    foreach ($name in $previous.Keys) {
        [Environment]::SetEnvironmentVariable($name, $previous[$name])
    }
}
