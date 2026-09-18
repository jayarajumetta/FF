[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string]$PackageRoot,

    [Parameter(Mandatory)]
    [string]$OutputPath
)

$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest

function Assert-True {
    param(
        [bool]$Condition,
        [string]$Message
    )
    if (-not $Condition) {
        throw $Message
    }
}

function Get-OrdinalStrings {
    param(
        [object[]]$Values,
        [switch]$IgnoreCase
    )
    [string[]]$sorted = @($Values | ForEach-Object { [string]$_ })
    $comparer = if ($IgnoreCase) {
        [StringComparer]::OrdinalIgnoreCase
    } else {
        [StringComparer]::Ordinal
    }
    [Array]::Sort($sorted, $comparer)
    return $sorted
}

function Assert-ExactSet {
    param(
        [object[]]$Expected,
        [object[]]$Actual,
        [string]$Description
    )
    $expectedValues = @(Get-OrdinalStrings $Expected -IgnoreCase)
    $actualValues = @(Get-OrdinalStrings $Actual -IgnoreCase)
    $difference = @(Compare-Object $expectedValues $actualValues)
    if ($expectedValues.Count -ne $actualValues.Count -or
        $difference.Count -ne 0) {
        $sample = @($difference | Select-Object -First 5 |
            ForEach-Object { "$($_.SideIndicator) $($_.InputObject)" }) -join "; "
        throw "$Description disagrees with committed contracts. $sample"
    }
}

function Get-FrameCatalogChecksum {
    param([object]$Catalog)
    $lines = [Collections.Generic.List[string]]::new()
    $lines.Add([string]$Catalog.schemaVersion)
    $lines.Add(([string]$Catalog.catalogVersion).Trim())
    $lines.Add(([string]$Catalog.sourcePath).Trim())
    $lines.Add(([string]$Catalog.sourceSha256).Trim().ToUpperInvariant())
    foreach ($hint in @($Catalog.hints | Sort-Object scopeId)) {
        $framePath = @($hint.framePath |
            ForEach-Object { ([string]$_).Trim() }) -join ">"
        $lines.Add(
            "hint|$(([string]$hint.scopeId).Trim())|$([int]$hint.pageIndex)|$framePath")
    }
    foreach ($rejected in @(Get-OrdinalStrings @(
        $Catalog.rejectedSourceHints))) {
        $lines.Add("rejected|$($rejected.Trim())")
    }
    return [Convert]::ToHexString(
        [Security.Cryptography.SHA256]::HashData(
            [Text.Encoding]::UTF8.GetBytes(($lines -join "`n"))))
}

function Test-FrameCatalog {
    param([string]$Path)
    $catalog = Get-Content -LiteralPath $Path -Raw | ConvertFrom-Json
    Assert-True ($catalog.schemaVersion -eq 1) (
        "Frame catalog '$Path' has an unsupported schema.")
    Assert-True (
        ([string]$catalog.sourceSha256) -match '^[A-Fa-f0-9]{64}$') (
        "Frame catalog '$Path' has an invalid source checksum.")
    Assert-True (
        (Get-FrameCatalogChecksum $catalog).Equals(
            [string]$catalog.checksum,
            [StringComparison]::OrdinalIgnoreCase)) (
        "Frame catalog '$Path' has a stale checksum.")
    return $catalog
}

function Select-WorkflowTests {
    param(
        [object[]]$Tests,
        [object[]]$Categories
    )
    return @($Tests | Where-Object {
        $testCategories = @($_.categories | ForEach-Object { [string]$_ })
        @($Categories | Where-Object {
            $testCategories -notcontains [string]$_
        }).Count -eq 0
    })
}

$root = [IO.Path]::GetFullPath($PackageRoot)
Import-Module (Join-Path $root "scripts\CI\PipelineContracts.psm1") -Force
$package = Test-PackageManifest -PackageRoot $root -ScanForSecrets
$manifestPath = Join-Path $root "package-manifest.json"
$matrixPath = Join-Path $root (
    "test\Resources\Contracts\integration-readiness.json")
$inventoryPath = Join-Path $root "metadata\test-inventory.json"
$mappingPath = Join-Path $root "config\testplans-mapping.template.json"
foreach ($path in @($matrixPath, $inventoryPath, $mappingPath)) {
    Assert-True (Test-Path -LiteralPath $path -PathType Leaf) (
        "Readiness input '$path' is missing.")
}

$matrix = Get-Content -LiteralPath $matrixPath -Raw | ConvertFrom-Json
$inventory = Get-Content -LiteralPath $inventoryPath -Raw | ConvertFrom-Json
$mapping = Get-Content -LiteralPath $mappingPath -Raw | ConvertFrom-Json
Assert-True ($matrix.schemaVersion -eq 1) (
    "Unsupported integration readiness schema.")
Assert-True (([string]$matrix.packageVersion).Equals(
    "1.4.0",
    [StringComparison]::Ordinal)) (
    "The readiness contract must remain frozen at package 1.4.0.")
Assert-True (([string]$package.packageVersion).Equals(
    [string]$matrix.packageVersion,
    [StringComparison]::Ordinal)) (
    "Package and readiness versions disagree.")
Assert-True (([string]$matrix.topologyDecision).Equals(
    "ProvisionalInAssembly",
    [StringComparison]::Ordinal)) (
    "The topology decision was changed without an approved decision record.")

$workflows = @($matrix.workflows)
Assert-True ($workflows.Count -eq 3) (
    "The readiness matrix must contain exactly three reference workflows.")
Assert-True (@($workflows.workflowId | Sort-Object -Unique).Count -eq 3) (
    "Readiness workflow IDs must be unique.")
Assert-True (@($workflows.stableAutomationId |
    Sort-Object -Unique).Count -eq 3) (
    "Stable readiness automation IDs must be unique.")
$requiredRoles = @($matrix.requiredApprovalRoles |
    ForEach-Object { [string]$_ })
Assert-True ($requiredRoles.Count -eq 4) (
    "Exactly four accountable approval roles are required.")

$manifestPaths = @($package.inventory | ForEach-Object { [string]$_.path })
$ownershipKeys = [Collections.Generic.HashSet[string]]::new(
    [StringComparer]::OrdinalIgnoreCase)
$frameCatalogs = @{}
$workflowReports = [Collections.Generic.List[object]]::new()
foreach ($workflow in $workflows) {
    $workflowId = [string]$workflow.workflowId
    foreach ($value in @(
        $workflowId,
        [string]$workflow.stableAutomationId,
        [string]$workflow.automationIdFamily,
        [string]$workflow.moduleId,
        [string]$workflow.sourceProvenance.status,
        [string]$workflow.profile.contractId,
        [string]$workflow.profile.profileId,
        [string]$workflow.profile.status,
        [string]$workflow.selectorFrameStatus,
        [string]$workflow.retryPolicy,
        [string]$workflow.adoMappingStatus,
        [string]$workflow.businessOutcomeStatus,
        [string]$workflow.state
    )) {
        Assert-True (-not [string]::IsNullOrWhiteSpace($value)) (
            "Workflow '$workflowId' has an incomplete readiness contract.")
    }

    $modules = @($inventory.modules | Where-Object {
        ([string]$_.moduleId).Equals(
            [string]$workflow.moduleId,
            [StringComparison]::Ordinal)
    })
    Assert-True ($modules.Count -eq 1) (
        "Workflow '$workflowId' has missing or duplicate compiled module ownership.")
    $module = $modules[0]
    Assert-True (@($module.automationIdFamilies) -contains
        [string]$workflow.automationIdFamily) (
        "Workflow '$workflowId' automation family disagrees with its compiled module.")
    Assert-True (([string]$module.dataProfileId).Equals(
        [string]$workflow.profile.contractId,
        [StringComparison]::Ordinal)) (
        "Workflow '$workflowId' profile contract disagrees with its compiled module.")
    Assert-ExactSet `
        -Expected @($workflow.evidenceContract) `
        -Actual @($module.evidence.requiredArtifacts) `
        -Description "Workflow '$workflowId' evidence"
    Assert-True ([bool]$module.evidence.requiresCanonicalResult) (
        "Workflow '$workflowId' does not require a canonical result.")
    Assert-True ([bool]$module.evidence.requiresFailureTrace -and
        [bool]$module.evidence.requiresFailureVideo) (
        "Workflow '$workflowId' has incomplete failure evidence.")
    if ([string]$workflow.retryPolicy -eq "NoRetry") {
        Assert-True (-not [bool]$module.retrySafe) (
            "Workflow '$workflowId' claims NoRetry but the module is retry safe.")
    } else {
        throw "Workflow '$workflowId' has an unsupported retry policy."
    }
    if ([string]$workflow.selectorFrameStatus -in @("Contracted", "Approved")) {
        Assert-True (@($module.blockedSelectors).Count -eq 0) (
            "Workflow '$workflowId' claims contracted selectors while module blockers remain.")
    } elseif ([string]$workflow.selectorFrameStatus -eq "Blocked") {
        Assert-True (@($module.blockedSelectors).Count -gt 0) (
            "Workflow '$workflowId' claims blocked selectors without compiled blockers.")
    } else {
        throw "Workflow '$workflowId' has an unsupported selector/frame status."
    }

    $discovered = @(Select-WorkflowTests `
        -Tests @($inventory.tests) `
        -Categories @($workflow.discoveryCategories))
    Assert-True ($discovered.Count -gt 0) (
        "Workflow '$workflowId' is missing from compiled Reqnroll discovery.")

    foreach ($ownership in @($workflow.shardOwnership)) {
        $reportPath = [string]$ownership.report
        foreach ($shard in @($ownership.shards)) {
            $key = "$reportPath|$shard"
            Assert-True ($ownershipKeys.Add($key)) (
                "Shard ownership '$key' is duplicated across readiness workflows.")
        }
        $fullReportPath = Join-Path $root ($reportPath.Replace("/", "\"))
        Assert-True (Test-Path -LiteralPath $fullReportPath -PathType Leaf) (
            "Workflow '$workflowId' ownership report '$reportPath' is missing.")
        $ownershipReport = Get-Content -LiteralPath $fullReportPath -Raw |
            ConvertFrom-Json
        $owned = @()
        foreach ($shard in @($ownership.shards)) {
            $property = $ownershipReport.shards.PSObject.Properties[
                [string]$shard]
            Assert-True ($null -ne $property) (
                "Workflow '$workflowId' shard '$shard' is missing.")
            $owned += @($property.Value.tests | ForEach-Object { [string]$_ })
        }
        Assert-True (@($owned | Sort-Object -Unique).Count -eq $owned.Count) (
            "Workflow '$workflowId' has overlapping shard ownership.")
        Assert-ExactSet `
            -Expected @($discovered.id) `
            -Actual $owned `
            -Description "Workflow '$workflowId' shard ownership"
    }

    foreach ($relativePath in @($workflow.packagePaths)) {
        Assert-True ($manifestPaths -contains [string]$relativePath) (
            "Workflow '$workflowId' package inventory is missing '$relativePath'.")
    }

    $profilePath = Join-Path $root (
        ([string]$workflow.profile.catalogPath).Replace("/", "\"))
    Assert-True (Test-Path -LiteralPath $profilePath -PathType Leaf) (
        "Workflow '$workflowId' profile catalog is missing.")
    $profileCatalog = Get-Content -LiteralPath $profilePath -Raw |
        ConvertFrom-Json
    if ($workflow.sourceProvenance.status -ne "RepositoryNative") {
        throw "Workflow '$workflowId' has an unsupported provenance status."
    }
    $profileMatches = @($profileCatalog.profiles |
        Where-Object scenarioProfile -eq (
            [string]$workflow.profile.profileId))
    Assert-True ($profileMatches.Count -gt 0) (
        "Workflow '$workflowId' profile is missing.")
    Assert-True (@($profileMatches | Where-Object {
        ([string]$_.mode) -ne [string]$workflow.profile.status
    }).Count -eq 0) (
        "Workflow '$workflowId' profile status disagrees with its catalog.")

    $frameProperty = $workflow.sourceProvenance.PSObject.Properties[
        "frameCatalogPath"]
    $frameCatalogPath = if ($null -eq $frameProperty) {
        ""
    } else {
        [string]$frameProperty.Value
    }
    if (-not [string]::IsNullOrWhiteSpace($frameCatalogPath)) {
        $fullFramePath = Join-Path $root (
            $frameCatalogPath.Replace("/", "\"))
        Assert-True ($manifestPaths -contains $frameCatalogPath) (
            "Workflow '$workflowId' frame catalog is absent from the package.")
        if (-not $frameCatalogs.ContainsKey($fullFramePath)) {
            $frameCatalogs[$fullFramePath] = Test-FrameCatalog $fullFramePath
        }
    }

    $deferred = @($mapping.deferredAutomationIds |
        ForEach-Object { [string]$_ })
    $mapped = @($mapping.mappings | ForEach-Object {
        [string]$_.automationId })
    if ([string]$workflow.adoMappingStatus -eq "Deferred") {
        Assert-True ($deferred -contains
            [string]$workflow.stableAutomationId) (
            "Workflow '$workflowId' is not deferred in the ADO catalog.")
        Assert-True ($mapped -notcontains
            [string]$workflow.stableAutomationId) (
            "Workflow '$workflowId' is both mapped and deferred.")
    } elseif ([string]$workflow.adoMappingStatus -eq "ExternalRequired") {
        Assert-True (
            ([string]$workflow.stableAutomationId).Contains("<STATE>")) (
            "Workflow '$workflowId' external ADO mapping lacks a stable qualifier.")
    } elseif ([string]$workflow.adoMappingStatus -eq "Mapped") {
        Assert-True ($mapped -contains
            [string]$workflow.stableAutomationId) (
            "Workflow '$workflowId' claims an ADO mapping that does not exist.")
    } else {
        throw "Workflow '$workflowId' has an unsupported ADO mapping status."
    }

    Assert-True (@($workflow.requiredBusinessAssertions).Count -gt 0) (
        "Workflow '$workflowId' has no required business assertions.")
    $blockers = @($workflow.blockers)
    $approvals = @($workflow.approvalEvidence)
    Test-WorkflowActivation -Workflow $workflow -RequiredRoles $requiredRoles

    $workflowReports.Add([PSCustomObject][ordered]@{
        workflowId = $workflowId
        stableAutomationId = [string]$workflow.stableAutomationId
        moduleId = [string]$workflow.moduleId
        sourceProvenanceStatus = [string]$workflow.sourceProvenance.status
        profileStatus = [string]$workflow.profile.status
        selectorFrameStatus = [string]$workflow.selectorFrameStatus
        businessOutcomeStatus = [string]$workflow.businessOutcomeStatus
        evidenceContract = @($workflow.evidenceContract)
        discoveredCases = $discovered.Count
        shardOwnership = @($workflow.shardOwnership)
        retryPolicy = [string]$workflow.retryPolicy
        packagePresence = "Present"
        adoMappingStatus = [string]$workflow.adoMappingStatus
        state = [string]$workflow.state
        blockers = $blockers
        approvalEvidence = $approvals
    })
}

$reportData = [PSCustomObject][ordered]@{
    schemaVersion = 1
    catalogVersion = [string]$matrix.catalogVersion
    packageVersion = [string]$package.packageVersion
    packageCommit = [string]$package.commit.sha
    packageManifestSha256 = (
        Get-FileHash -LiteralPath $manifestPath -Algorithm SHA256
    ).Hash.ToUpperInvariant()
    topologyDecision = [string]$matrix.topologyDecision
    adaptedSourceRepository = [string]$matrix.adaptedSourceRepository
    workflowCount = $workflowReports.Count
    workflows = @($workflowReports)
}
$canonical = $reportData | ConvertTo-Json -Depth 16 -Compress
$report = [PSCustomObject][ordered]@{
    checksum = [Convert]::ToHexString(
        [Security.Cryptography.SHA256]::HashData(
            [Text.Encoding]::UTF8.GetBytes($canonical)))
    report = $reportData
}
$parent = Split-Path -Parent $OutputPath
if ($parent) {
    New-Item -ItemType Directory -Force -Path $parent | Out-Null
}
$report | ConvertTo-Json -Depth 18 |
    Set-Content -LiteralPath $OutputPath -Encoding UTF8
Write-Host (
    "Integration readiness validated: workflows={0}, gated={1}, checksum={2}." -f
    $workflowReports.Count,
    @($workflowReports | Where-Object state -eq "Gated").Count,
    $report.checksum)
