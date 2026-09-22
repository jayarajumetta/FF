[CmdletBinding(DefaultParameterSetName = "Directory")]
param(
    [Parameter(Mandatory, ParameterSetName = "Directory")]
    [string]$PackageRoot,

    [Parameter(Mandatory, ParameterSetName = "Archive")]
    [string]$ArchivePath,

    [Parameter(ParameterSetName = "Archive")]
    [string]$ExtractionRoot,

    [switch]$DiscoverySmoke,

    [switch]$SfpGatedSmoke,

    [switch]$PublisherDryRunSmoke,

    [switch]$ReportToolSmoke,

    [switch]$ScanForSecrets
)

$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest

function Test-NonRunnableSelection {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [string]$PackageRoot,

        [Parameter(Mandatory)]
        [string]$Filter,

        [Parameter(Mandatory)]
        [string]$ResultName,

        [Parameter(Mandatory)]
        [string]$DisplayName,

        [Parameter(Mandatory)]
        [string[]]$RequiredCategories
    )

    $testAssembly = Join-Path $PackageRoot "test\TestAutomation.dll"
    $runSettings = Join-Path $PackageRoot "runsettings\ci.runsettings"
    $inventory = Get-Content -LiteralPath (
        Join-Path $PackageRoot "metadata\test-inventory.json") -Raw |
        ConvertFrom-Json
    $expectedCount = @($inventory.tests | Where-Object {
        $categories = @($_.categories | ForEach-Object { [string]$_ })
        @($RequiredCategories | Where-Object {
            $categories -notcontains $_
        }).Count -eq 0
    }).Count
    if ($expectedCount -eq 0) {
        throw "$DisplayName has no compiled tests."
    }
    $probeRoot = Join-Path ([IO.Path]::GetTempPath()) (
        "PnC-$ResultName-" + [Guid]::NewGuid().ToString("N"))
    $probeTestRoot = Join-Path $probeRoot "test"
    $probeResults = Join-Path $probeRoot "results"
    New-Item -ItemType Directory -Force -Path $probeTestRoot, $probeResults |
        Out-Null
    Copy-Item -Path (Join-Path $PackageRoot "test\*") `
        -Destination $probeTestRoot -Recurse -Force
    try {
        Push-Location $probeRoot
        try {
            & dotnet test (Join-Path $probeTestRoot "TestAutomation.dll") `
                --settings $runSettings `
                --filter $Filter `
                --logger "trx;LogFileName=$ResultName.trx" `
                --results-directory $probeResults
            if ($LASTEXITCODE -ne 0) {
                throw "Extracted $DisplayName NonRunnable probe failed."
            }
            [xml]$probe = Get-Content -LiteralPath (
                Join-Path $probeResults "$ResultName.trx") -Raw
            $namespace = [Xml.XmlNamespaceManager]::new($probe.NameTable)
            $namespace.AddNamespace(
                "t",
                "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")
            $results = @($probe.SelectNodes(
                "/t:TestRun/t:Results/t:UnitTestResult",
                $namespace))
            if ($results.Count -ne $expectedCount -or
                @($results | Where-Object outcome -ne "NotExecuted").Count -ne 0) {
                throw "$DisplayName must discover exactly $expectedCount explicitly ignored NonRunnable executions."
            }
        }
        finally {
            Pop-Location
        }
    }
    finally {
        Remove-Item -LiteralPath $probeRoot -Recurse -Force
    }
    Write-Host (
        "Extracted {0} NonRunnable probe passed: {1} NotExecuted." -f
        $DisplayName,
        $expectedCount)
}

$temporaryExtraction = $false
if ($PSCmdlet.ParameterSetName -eq "Archive") {
    if (-not (Test-Path -LiteralPath $ArchivePath -PathType Leaf)) {
        throw "Package archive '$ArchivePath' is missing."
    }

    Add-Type -AssemblyName System.IO.Compression.FileSystem
    $archive = [IO.Compression.ZipFile]::OpenRead(
        [IO.Path]::GetFullPath($ArchivePath))
    try {
        foreach ($entry in $archive.Entries) {
            $name = $entry.FullName.Replace('\', '/')
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

    if ([string]::IsNullOrWhiteSpace($ExtractionRoot)) {
        $ExtractionRoot = Join-Path ([IO.Path]::GetTempPath()) (
            "PnCTestPackage-" + [Guid]::NewGuid().ToString("N"))
        $temporaryExtraction = $true
    }
    elseif (Test-Path -LiteralPath $ExtractionRoot) {
        throw "Extraction root '$ExtractionRoot' already exists."
    }

    New-Item -ItemType Directory -Force -Path $ExtractionRoot | Out-Null
    Expand-Archive -LiteralPath $ArchivePath -DestinationPath $ExtractionRoot
    $PackageRoot = $ExtractionRoot
}

try {
    Import-Module (Join-Path $PackageRoot "scripts\CI\PipelineContracts.psm1") -Force
    $manifest = Test-PackageManifest `
        -PackageRoot $PackageRoot `
        -ScanForSecrets:$ScanForSecrets

    if ($DiscoverySmoke) {
        $testAssembly = Join-Path $PackageRoot "test\TestAutomation.dll"
        $inventoryTool = Join-Path $PackageRoot "tools\CiTestInventory\CiTestInventory.dll"
        $expectedInventoryPath = Join-Path $PackageRoot "metadata\test-inventory.json"
        $runtimeInventoryPath = Join-Path ([IO.Path]::GetTempPath()) (
            "PnC-TestInventory-" + [Guid]::NewGuid().ToString("N") + ".json")
        $runtimeInventory = Get-CompiledTestInventory `
            -InventoryTool $inventoryTool `
            -TestAssembly $testAssembly `
            -OutputPath $runtimeInventoryPath
        $expectedInventory = Get-Content -LiteralPath $expectedInventoryPath -Raw |
            ConvertFrom-Json
        Remove-Item -LiteralPath $runtimeInventoryPath -Force

        $expectedIds = @($expectedInventory.tests | ForEach-Object id | Sort-Object)
        $runtimeIds = @($runtimeInventory.tests | ForEach-Object id | Sort-Object)
        if ($expectedIds.Count -ne $runtimeIds.Count -or
            @(Compare-Object $expectedIds $runtimeIds).Count -ne 0) {
            throw "Extracted assembly test inventory disagrees with the packaged inventory."
        }

        $runSettings = Join-Path $PackageRoot "runsettings\ci.runsettings"
        $smokeRoot = Join-Path ([IO.Path]::GetTempPath()) (
            "PnC-SourceFreeSmoke-" + [Guid]::NewGuid().ToString("N"))
        $smokeTestRoot = Join-Path $smokeRoot "test"
        New-Item -ItemType Directory -Force -Path $smokeTestRoot | Out-Null
        Copy-Item -Path (Join-Path $PackageRoot "test\*") `
            -Destination $smokeTestRoot -Recurse -Force
        $smokeAssembly = Join-Path $smokeTestRoot "TestAutomation.dll"
        Push-Location $smokeRoot
        try {
            $listOutput = @(
                & dotnet test $smokeAssembly `
                    --list-tests `
                    --settings $runSettings 2>&1
            )
            if ($LASTEXITCODE -ne 0) {
                throw "Source-free dotnet test discovery failed."
            }
        }
        finally {
            Pop-Location
            Remove-Item -LiteralPath $smokeRoot -Recurse -Force
        }
        $listed = @(
            $listOutput |
                Where-Object { [string]$_ -match '^\s{4}\S' } |
                ForEach-Object { ([string]$_).Trim() } |
                Sort-Object
        )
        $expectedNames = @(
            $runtimeInventory.tests |
                ForEach-Object { [string]$_.displayName } |
                Sort-Object
        )
        $identityDifference = @(Compare-Object $expectedNames $listed)
        if ($listed.Count -ne [int]$runtimeInventory.count -or
            $identityDifference.Count -ne 0) {
            $sample = @(
                $identityDifference |
                    Select-Object -First 5 |
                    ForEach-Object {
                        "$($_.SideIndicator) $($_.InputObject)"
                    }
            ) -join "; "
            throw "Source-free test discovery disagrees with compiled inventory. Listed=$($listed.Count), inventory=$($runtimeInventory.count), differences=$sample."
        }
        [void](Test-PackageManifest -PackageRoot $PackageRoot)

        $sfpTests = @(
            $runtimeInventory.tests |
                Where-Object {
                    $_.categories -contains "SFP"
                }
        )
        if ($sfpTests.Count -eq 0) {
            throw "Extracted package discovery smoke found zero SFP tests."
        }
        Write-Host "Extracted package discovery smoke found $($sfpTests.Count) SFP tests."
    }
    if ($SfpGatedSmoke) {
        Test-NonRunnableSelection `
            -PackageRoot $PackageRoot `
            -Filter (
                "TestCategory=SfpBasicOutcome&" +
                "TestCategory=ExpertQuote&" +
                "TestCategory=AutomationId-SFP-BASIC-POLICY") `
            -ResultName "SfpBasicPolicy" `
            -DisplayName "SFP Basic Policy gate" `
            -RequiredCategories @(
                "SfpBasicOutcome",
                "ExpertQuote",
                "AutomationId-SFP-BASIC-POLICY")
        Test-NonRunnableSelection `
            -PackageRoot $PackageRoot `
            -Filter (
                "TestCategory=SfpCountryEstateOutcome&" +
                "TestCategory=AutomationId-SFP-COUNTRY-ESTATE") `
            -ResultName "SfpCountryEstate" `
            -DisplayName "SFP Country Estate gate" `
            -RequiredCategories @(
                "SfpCountryEstateOutcome",
                "AutomationId-SFP-COUNTRY-ESTATE")
        Test-NonRunnableSelection `
            -PackageRoot $PackageRoot `
            -Filter (
                "TestCategory=Forms&" +
                "TestCategory=AutomationId-SFP-FORMS-VALIDATION") `
            -ResultName "SfpForms" `
            -DisplayName "SFP forms gate" `
            -RequiredCategories @(
                "Forms",
                "AutomationId-SFP-FORMS-VALIDATION")
    }
    if ($PublisherDryRunSmoke) {
        & (Join-Path $PackageRoot "scripts\CI\Test-TestPlanPublisherSmoke.ps1") `
            -PackageRoot $PackageRoot
    }
    if ($ReportToolSmoke) {
        $reportSmokeRoot = Join-Path ([IO.Path]::GetTempPath()) (
            "PnC-ReportRuntime-" + [Guid]::NewGuid().ToString("N"))
        New-Item -ItemType Directory -Path $reportSmokeRoot | Out-Null
        try {
            $reportSmoke = Invoke-CanonicalReport `
                -ReportTool (Join-Path $PackageRoot "tools\SgsReport\SgsReport.dll") `
                -EvidenceRoot $reportSmokeRoot `
                -CanonicalResultPath (Join-Path $reportSmokeRoot "deliberately-missing.trx") `
                -OutputDirectory (Join-Path $reportSmokeRoot "report")
            if ($reportSmoke.ExitCode -ne 2 -or $reportSmoke.Total -ne 0) {
                throw "Source-free reporting did not fail closed for missing canonical execution."
            }
            $global:LASTEXITCODE = 0
            [void](Test-PackageManifest -PackageRoot $PackageRoot)
        }
        finally {
            Remove-Item -LiteralPath $reportSmokeRoot -Recurse -Force
        }
    }

    Write-Host (
        "Package validated: version={0}, commit={1}, files={2}." -f
        $manifest.packageVersion,
        $manifest.commit.sha,
        @($manifest.inventory).Count)
}
finally {
    if ($temporaryExtraction -and
        -not [string]::IsNullOrWhiteSpace($ExtractionRoot) -and
        (Test-Path -LiteralPath $ExtractionRoot)) {
        Remove-Item -LiteralPath $ExtractionRoot -Recurse -Force
    }
}
