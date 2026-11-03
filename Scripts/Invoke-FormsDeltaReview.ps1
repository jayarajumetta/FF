[CmdletBinding()]
param(
    [ValidateSet("SFP", "Common")]
    [string]$SourceFamily = $env:FORMS_DELTA_SOURCE_FAMILY,

    [string]$EventId = $env:FORMS_DELTA_EVENT_ID,

    [string]$CorrelationId = $env:FORMS_DELTA_CORRELATION_ID,

    [string]$PreviousSourceIdentity =
        $env:FORMS_DELTA_PREVIOUS_SOURCE_IDENTITY,

    [string]$PreviousSourceReference =
        $env:FORMS_DELTA_PREVIOUS_SOURCE_REFERENCE,

    [string]$PreviousSourceSha256 =
        $env:FORMS_DELTA_PREVIOUS_SOURCE_SHA256,

    [string]$CurrentSourceIdentity =
        $env:FORMS_DELTA_CURRENT_SOURCE_IDENTITY,

    [string]$CurrentSourceReference =
        $env:FORMS_DELTA_CURRENT_SOURCE_REFERENCE,

    [string]$CurrentSourceSha256 =
        $env:FORMS_DELTA_CURRENT_SOURCE_SHA256,

    [string]$CounterpartSourceIdentity =
        $env:FORMS_DELTA_COUNTERPART_SOURCE_IDENTITY,

    [string]$CounterpartSourceReference =
        $env:FORMS_DELTA_COUNTERPART_SOURCE_REFERENCE,

    [string]$CounterpartSourceSha256 =
        $env:FORMS_DELTA_COUNTERPART_SOURCE_SHA256,

    [string]$ApprovedBaselineSha256 =
        $env:FORMS_DELTA_APPROVED_BASELINE_SHA256,

    [Parameter(Mandatory = $true)]
    [string]$ProjectRoot,

    [Parameter(Mandatory = $true)]
    [string]$ResultRoot,

    [bool]$AllowReviewedChanges = $false,

    [bool]$WritePackage = $false,

    [bool]$OverwriteExisting = $false
)

$ErrorActionPreference = "Stop"

function Get-BooleanEnvironmentValue {
    param([string]$Name, [bool]$DefaultValue)
    $value = [Environment]::GetEnvironmentVariable($Name)
    if ([string]::IsNullOrWhiteSpace($value)) {
        return $DefaultValue
    }
    $parsed = $false
    if (-not [bool]::TryParse($value, [ref]$parsed)) {
        throw "$Name must be true or false."
    }
    return $parsed
}

if (-not $PSBoundParameters.ContainsKey("AllowReviewedChanges")) {
    $AllowReviewedChanges = Get-BooleanEnvironmentValue `
        "FORMS_DELTA_ALLOW_REVIEWED_CHANGES" $false
}
if (-not $PSBoundParameters.ContainsKey("WritePackage")) {
    $WritePackage = Get-BooleanEnvironmentValue `
        "FORMS_DELTA_WRITE_PACKAGE" $false
}
if (-not $PSBoundParameters.ContainsKey("OverwriteExisting")) {
    $OverwriteExisting = Get-BooleanEnvironmentValue `
        "FORMS_DELTA_OVERWRITE" $false
}

function Assert-Sha256 {
    param([string]$Value, [string]$Name)
    if ($Value -notmatch '^[A-Fa-f0-9]{64}$') {
        throw "$Name must be an exact SHA-256 value."
    }
}

function Assert-OpaqueReference {
    param([string]$Value, [string]$Name)
    if ([string]::IsNullOrWhiteSpace($Value) -or
        $Value.Contains("://") -or
        $Value.Contains("?") -or
        $Value.Contains("#")) {
        throw "$Name must be an opaque SharePoint identity/version reference, not a URL."
    }
}

foreach ($required in @(
    @{ Value = $SourceFamily; Name = "SourceFamily" },
    @{ Value = $EventId; Name = "EventId" },
    @{ Value = $CorrelationId; Name = "CorrelationId" },
    @{ Value = $PreviousSourceIdentity; Name = "PreviousSourceIdentity" },
    @{ Value = $CurrentSourceIdentity; Name = "CurrentSourceIdentity" },
    @{ Value = $CounterpartSourceIdentity; Name = "CounterpartSourceIdentity" })) {
    if ([string]::IsNullOrWhiteSpace($required.Value)) {
        throw "$($required.Name) is required."
    }
}

function Get-VerifiedHash {
    param([string]$Path, [string]$ExpectedHash, [string]$Label)
    if (-not (Test-Path -LiteralPath $Path -PathType Leaf)) {
        throw "$Label acquisition did not produce a file."
    }
    $actual = (Get-FileHash -LiteralPath $Path -Algorithm SHA256).Hash
    if ($actual -ne $ExpectedHash.ToUpperInvariant()) {
        throw "$Label SHA-256 mismatch."
    }
    return $actual
}

function Invoke-AcquisitionProvider {
    param(
        [string]$Reference,
        [string]$Destination,
        [string]$Label
    )
    $provider = $env:FORMS_SHAREPOINT_ACQUISITION_PROVIDER
    if ([string]::IsNullOrWhiteSpace($provider) -or
        -not (Test-Path -LiteralPath $provider -PathType Leaf)) {
        throw "FORMS_SHAREPOINT_ACQUISITION_PROVIDER must identify the approved agent-side acquisition provider."
    }
    $providerArguments = @{
        AcquisitionReference = $Reference
        DestinationPath = $Destination
        TenantId = $env:FORMS_SHAREPOINT_TENANT_ID
        ClientId = $env:FORMS_SHAREPOINT_CLIENT_ID
    }
    if (-not [string]::IsNullOrWhiteSpace($env:FORMS_SHAREPOINT_FEDERATED_TOKEN_FILE)) {
        $providerArguments.FederatedTokenFile =
            $env:FORMS_SHAREPOINT_FEDERATED_TOKEN_FILE
    }
    if (-not [string]::IsNullOrWhiteSpace(
            $env:FORMS_SHAREPOINT_CERTIFICATE_THUMBPRINT)) {
        $providerArguments.CertificateThumbprint =
            $env:FORMS_SHAREPOINT_CERTIFICATE_THUMBPRINT
    }
    $global:LASTEXITCODE = 0
    & $provider @providerArguments *> $null
    if (-not $? -or $LASTEXITCODE -ne 0) {
        throw "$Label acquisition provider failed."
    }
}

foreach ($hash in @(
    @{ Value = $PreviousSourceSha256; Name = "PreviousSourceSha256" },
    @{ Value = $CurrentSourceSha256; Name = "CurrentSourceSha256" },
    @{ Value = $CounterpartSourceSha256; Name = "CounterpartSourceSha256" },
    @{ Value = $ApprovedBaselineSha256; Name = "ApprovedBaselineSha256" })) {
    Assert-Sha256 @hash
}
foreach ($reference in @(
    @{ Value = $PreviousSourceReference; Name = "PreviousSourceReference" },
    @{ Value = $CurrentSourceReference; Name = "CurrentSourceReference" },
    @{ Value = $CounterpartSourceReference; Name = "CounterpartSourceReference" })) {
    Assert-OpaqueReference @reference
}
if ($WritePackage -and -not $AllowReviewedChanges) {
    throw "WritePackage requires AllowReviewedChanges=true."
}
if ([string]::IsNullOrWhiteSpace($env:FORMS_SHAREPOINT_TENANT_ID) -or
    [string]::IsNullOrWhiteSpace($env:FORMS_SHAREPOINT_CLIENT_ID)) {
    throw "SharePoint acquisition requires FORMS_SHAREPOINT_TENANT_ID and FORMS_SHAREPOINT_CLIENT_ID."
}
$hasFederatedToken =
    -not [string]::IsNullOrWhiteSpace($env:FORMS_SHAREPOINT_FEDERATED_TOKEN_FILE) -and
    (Test-Path -LiteralPath $env:FORMS_SHAREPOINT_FEDERATED_TOKEN_FILE -PathType Leaf)
$hasCertificate =
    -not [string]::IsNullOrWhiteSpace($env:FORMS_SHAREPOINT_CERTIFICATE_THUMBPRINT)
if (-not $hasFederatedToken -and -not $hasCertificate) {
    throw "SharePoint acquisition requires a federated token file or certificate thumbprint."
}

$project = (Resolve-Path -LiteralPath $ProjectRoot).Path
$approvedBaseline = Join-Path $project "Resources\ExpectedForms\SFP\SFP.json"
$basicFeature = Join-Path $project "Features\SFP\SFP_BasicPolicy.feature"
$ceFeature = Join-Path $project "Features\SFP\SFP_CE.feature"
$resultDirectory = [IO.Path]::GetFullPath($ResultRoot)
$resultPath = Join-Path $resultDirectory "forms-delta-result.json"
$packageDirectory = Join-Path $resultDirectory "review-package"
$tempRoot = Join-Path $env:AGENT_TEMPDIRECTORY (
    "FormsDelta-" + [Guid]::NewGuid().ToString("N"))

try {
    New-Item -ItemType Directory -Force -Path $tempRoot, $resultDirectory |
        Out-Null
    $previousPath = Join-Path $tempRoot "previous-changed-source.xlsx"
    $currentPath = Join-Path $tempRoot "current-changed-source.xlsx"
    $counterpartPath = Join-Path $tempRoot "current-counterpart.xlsx"

    Invoke-AcquisitionProvider `
        -Reference $PreviousSourceReference `
        -Destination $previousPath `
        -Label "Previous changed source"
    Invoke-AcquisitionProvider `
        -Reference $CurrentSourceReference `
        -Destination $currentPath `
        -Label "Current changed source"
    Invoke-AcquisitionProvider `
        -Reference $CounterpartSourceReference `
        -Destination $counterpartPath `
        -Label "Current counterpart source"

    Get-VerifiedHash $previousPath $PreviousSourceSha256 "Previous changed source" |
        Out-Null
    Get-VerifiedHash $currentPath $CurrentSourceSha256 "Current changed source" |
        Out-Null
    Get-VerifiedHash $counterpartPath $CounterpartSourceSha256 "Current counterpart source" |
        Out-Null
    Get-VerifiedHash $approvedBaseline $ApprovedBaselineSha256 "Approved baseline" |
        Out-Null

    $env:DELTA_SOURCE_FAMILY = $SourceFamily
    $env:DELTA_EVENT_ID = $EventId
    $env:DELTA_CORRELATION_ID = $CorrelationId
    $env:DELTA_PREVIOUS_SOURCE_IDENTITY = $PreviousSourceIdentity
    $env:DELTA_PREVIOUS_SOURCE_REFERENCE = $PreviousSourceReference
    $env:DELTA_PREVIOUS_SOURCE_PATH = $previousPath
    $env:DELTA_PREVIOUS_SOURCE_SHA256 = $PreviousSourceSha256
    $env:DELTA_CURRENT_SOURCE_IDENTITY = $CurrentSourceIdentity
    $env:DELTA_CURRENT_SOURCE_REFERENCE = $CurrentSourceReference
    $env:DELTA_CURRENT_SOURCE_PATH = $currentPath
    $env:DELTA_CURRENT_SOURCE_SHA256 = $CurrentSourceSha256
    $env:DELTA_COUNTERPART_SOURCE_IDENTITY = $CounterpartSourceIdentity
    $env:DELTA_COUNTERPART_SOURCE_REFERENCE = $CounterpartSourceReference
    $env:DELTA_COUNTERPART_SOURCE_PATH = $counterpartPath
    $env:DELTA_COUNTERPART_SOURCE_SHA256 = $CounterpartSourceSha256
    $env:DELTA_APPROVED_BASELINE = $approvedBaseline
    $env:DELTA_APPROVED_BASELINE_SHA256 = $ApprovedBaselineSha256
    $env:DELTA_BASIC_FEATURE = $basicFeature
    $env:DELTA_CE_FEATURE = $ceFeature
    $env:DELTA_RESULT_PATH = $resultPath
    $env:DELTA_OUTPUT_DIRECTORY = $packageDirectory
    $env:DELTA_ALLOW_REVIEWED_CHANGES = $AllowReviewedChanges.ToString()
    $env:DELTA_WRITE_PACKAGE = $WritePackage.ToString()
    $env:DELTA_OVERWRITE = $OverwriteExisting.ToString()

    dotnet test (Join-Path $project "TestAutomation.csproj") `
        --configuration Release `
        --no-build `
        --filter "Category=Tools&Name~RunCanonicalFormsDeltaReview" `
        --logger "console;verbosity=minimal"
    if ($LASTEXITCODE -ne 0) {
        throw "Canonical Forms delta tool failed."
    }

    Get-VerifiedHash $previousPath $PreviousSourceSha256 "Previous changed source" |
        Out-Null
    Get-VerifiedHash $currentPath $CurrentSourceSha256 "Current changed source" |
        Out-Null
    Get-VerifiedHash $counterpartPath $CounterpartSourceSha256 "Current counterpart source" |
        Out-Null

    $result = Get-Content -LiteralPath $resultPath -Raw | ConvertFrom-Json
    foreach ($variable in @{
        FormsDeltaStatus = $result.status
        FormsDeltaNotificationWorthy =
            $result.notificationWorthy.ToString().ToLowerInvariant()
        FormsDeltaResultPath = $resultPath
        FormsDeltaPackageCorrelationId = $result.packageCorrelationId
        FormsDeltaAffectedIdentitySha256 = $result.affectedIdentitySha256
        FormsDeltaCandidateSha256 = $result.candidateSha256
        FormsDeltaReportSha256 = $result.reportSha256
    }.GetEnumerator()) {
        $value = [string]$variable.Value
        $escaped = $value.Replace("%", "%25").
            Replace("`r", "%0D").
            Replace("`n", "%0A").
            Replace(";", "%3B").
            Replace("]", "%5D")
        Write-Host "##vso[task.setvariable variable=$($variable.Key)]$escaped"
    }
}
finally {
    if (Test-Path -LiteralPath $tempRoot) {
        Remove-Item -LiteralPath $tempRoot -Recurse -Force
    }
}
