[CmdletBinding(DefaultParameterSetName = "Directory")]
param(
    [Parameter(Mandatory, ParameterSetName = "Directory")]
    [string]$PackageRoot,

    [Parameter(Mandatory, ParameterSetName = "Archive")]
    [string]$ArchivePath,

    [Parameter(Mandatory)]
    [string]$OutputPath
)

$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest

$temporaryRoot = $null
if ($PSCmdlet.ParameterSetName -eq "Archive") {
    if (-not (Test-Path -LiteralPath $ArchivePath -PathType Leaf)) {
        throw "Package archive '$ArchivePath' is missing."
    }
    Add-Type -AssemblyName System.IO.Compression.FileSystem
    $archive = [IO.Compression.ZipFile]::OpenRead(
        [IO.Path]::GetFullPath($ArchivePath))
    try {
        foreach ($entry in $archive.Entries) {
            $name = $entry.FullName.Replace("\", "/")
            if ($name.StartsWith("/", [StringComparison]::Ordinal) -or
                $name -match '(^|/)\.\.(/|$)' -or
                [IO.Path]::IsPathRooted($name)) {
                throw "Package archive contains unsafe entry '$name'."
            }
        }
    }
    finally {
        $archive.Dispose()
    }
    $temporaryRoot = Join-Path ([IO.Path]::GetTempPath()) (
        "PnC-Stabilization-" + [Guid]::NewGuid().ToString("N"))
    New-Item -ItemType Directory -Force -Path $temporaryRoot | Out-Null
    Expand-Archive -LiteralPath $ArchivePath -DestinationPath $temporaryRoot
    $PackageRoot = $temporaryRoot
}

$verificationRoot = Join-Path ([IO.Path]::GetTempPath()) (
    "PnC-Stabilization-Report-" + [Guid]::NewGuid().ToString("N"))
New-Item -ItemType Directory -Force -Path $verificationRoot | Out-Null
try {
    $root = [IO.Path]::GetFullPath($PackageRoot)
    & (Join-Path $root "scripts\CI\Test-TestPackage.ps1") `
        -PackageRoot $root `
        -DiscoverySmoke `
        -SfpGatedSmoke `
        -PublisherDryRunSmoke `
        -ScanForSecrets

    $readinessPath = Join-Path $verificationRoot "readiness.json"
    & (Join-Path $root "scripts\CI\Test-IntegrationReadiness.ps1") `
        -PackageRoot $root `
        -OutputPath $readinessPath

    $readiness = Get-Content -LiteralPath $readinessPath -Raw |
        ConvertFrom-Json
    $body = [PSCustomObject][ordered]@{
        schemaVersion = 1
        packageVersion = [string]$readiness.report.packageVersion
        packageCommit = [string]$readiness.report.packageCommit
        credentialFree = $true
        sourceFreePackageExecution = $true
        checks = [PSCustomObject][ordered]@{
            packageManifest = "Passed"
            sourceFreeDiscovery = "Passed"
            sfpGatedProfiles = "Passed"
            canonicalResultEvidenceParity = "Passed"
            testPlansDryRunReconciliation = "Passed"
            readinessContract = "Passed"
            catalogIntegrity = "Passed"
        }
        readinessChecksum = [string]$readiness.checksum
        readiness = $readiness.report
    }
    $canonical = $body | ConvertTo-Json -Depth 20 -Compress
    $report = [PSCustomObject][ordered]@{
        checksum = [Convert]::ToHexString(
            [Security.Cryptography.SHA256]::HashData(
                [Text.Encoding]::UTF8.GetBytes($canonical)))
        report = $body
    }
    $parent = Split-Path -Parent $OutputPath
    if ($parent) {
        New-Item -ItemType Directory -Force -Path $parent | Out-Null
    }
    $report | ConvertTo-Json -Depth 22 |
        Set-Content -LiteralPath $OutputPath -Encoding UTF8
    Write-Host (
        "Stabilization verification passed: workflows={0}, checksum={1}." -f
        [int]$readiness.report.workflowCount,
        $report.checksum)
}
finally {
    if (Test-Path -LiteralPath $verificationRoot) {
        Remove-Item -LiteralPath $verificationRoot -Recurse -Force
    }
    if ($null -ne $temporaryRoot -and
        (Test-Path -LiteralPath $temporaryRoot)) {
        Remove-Item -LiteralPath $temporaryRoot -Recurse -Force
    }
}
