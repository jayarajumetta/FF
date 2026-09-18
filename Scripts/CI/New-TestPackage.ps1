[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Resolve-Path (Join-Path $PSScriptRoot "..\..")).Path,

    [string]$OutputDirectory = (Join-Path (
        Resolve-Path (Join-Path $PSScriptRoot "..\..")).Path "artifacts\package"),

    [string]$PackageVersion,

    [string]$CommitSha,

    [string]$BuildId,

    [string]$BuildNumber,

    [switch]$RequireClean
)

$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest

$root = [IO.Path]::GetFullPath($RepositoryRoot)
$output = [IO.Path]::GetFullPath($OutputDirectory)
if ($output -eq $root -or
    -not $output.StartsWith(
        $root.TrimEnd('\', '/') + [IO.Path]::DirectorySeparatorChar,
        [StringComparison]::OrdinalIgnoreCase)) {
    throw "Package output must be a child of the repository root."
}

if ($RequireClean) {
    $dirty = @(git -C $root status --porcelain --untracked-files=all)
    if ($LASTEXITCODE -ne 0) {
        throw "Unable to verify the Git worktree."
    }
    if ($dirty.Count -gt 0) {
        throw "A clean checkout is required to build the CI package."
    }
}

if ([string]::IsNullOrWhiteSpace($PackageVersion)) {
    $PackageVersion = (
        Get-Content -LiteralPath (Join-Path $root "Pipelines\package-version.txt") -Raw
    ).Trim()
}
if ([string]::IsNullOrWhiteSpace($CommitSha)) {
    $CommitSha = (& git -C $root rev-parse HEAD).Trim()
}
if ([string]::IsNullOrWhiteSpace($BuildId)) {
    $BuildId = if ($env:BUILD_BUILDID) { $env:BUILD_BUILDID } else { "local" }
}
if ([string]::IsNullOrWhiteSpace($BuildNumber)) {
    $BuildNumber = if ($env:BUILD_BUILDNUMBER) {
        $env:BUILD_BUILDNUMBER
    } else {
        [DateTimeOffset]::UtcNow.ToString("yyyyMMddHHmmss")
    }
}

$stageRoot = Join-Path $output "stage"
$verificationRoot = Join-Path $output "verification"
foreach ($path in @($stageRoot, $verificationRoot)) {
    if (Test-Path -LiteralPath $path) {
        Remove-Item -LiteralPath $path -Recurse -Force
    }
    New-Item -ItemType Directory -Force -Path $path | Out-Null
}

foreach ($buildOutput in @(
    (Join-Path $root "bin\Release"),
    (Join-Path $root "DataPool\bin\Release"),
    (Join-Path $root "TestAutomation.UnitTests\bin\Release"),
    (Join-Path $root "Tools\CiTestInventory\bin\Release"),
    (Join-Path $root "Tools\TestPlanPublisher\bin\Release")
)) {
    if (Test-Path -LiteralPath $buildOutput) {
        Remove-Item -LiteralPath $buildOutput -Recurse -Force
    }
}

Push-Location $root
try {
    & dotnet restore PnC-TestAutomation.sln --locked-mode
    if ($LASTEXITCODE -ne 0) {
        throw "Locked solution restore failed."
    }

    & dotnet build PnC-TestAutomation.sln `
        --configuration Release `
        --no-restore `
        --nologo `
        -p:ContinuousIntegrationBuild=true
    if ($LASTEXITCODE -ne 0) {
        throw "Release solution build failed."
    }

    $unitResults = Join-Path $verificationRoot "unit"
    New-Item -ItemType Directory -Force -Path $unitResults | Out-Null
    & dotnet test TestAutomation.UnitTests\TestAutomation.UnitTests.csproj `
        --configuration Release `
        --no-build `
        --no-restore `
        --logger "trx;LogFileName=UnitTests.trx" `
        --results-directory $unitResults
    if ($LASTEXITCODE -ne 0) {
        throw "Unit/contract tests failed."
    }

    & (Join-Path $root "Scripts\CI\Tests\Invoke-CIContractTests.ps1") `
        -RepositoryRoot $root
}
finally {
    Pop-Location
}

$testOutput = Join-Path $root "bin\Release\net8.0"
$dataPoolOutput = Join-Path $root "DataPool\bin\Release\net8.0"
$inventoryToolOutput = Join-Path $root "Tools\CiTestInventory\bin\Release\net8.0"
$publisherToolOutput = Join-Path $root "Tools\TestPlanPublisher\bin\Release\net8.0"
foreach ($required in @(
    (Join-Path $testOutput "TestAutomation.dll"),
    (Join-Path $testOutput "TestAutomation.deps.json"),
    (Join-Path $testOutput "TestAutomation.runtimeconfig.json"),
    (Join-Path $testOutput "playwright.ps1"),
    (Join-Path $dataPoolOutput "DataPool.dll"),
    (Join-Path $inventoryToolOutput "CiTestInventory.dll"),
    (Join-Path $inventoryToolOutput "CiTestInventory.runtimeconfig.json"),
    (Join-Path $publisherToolOutput "TestPlanPublisher.dll"),
    (Join-Path $publisherToolOutput "TestPlanPublisher.runtimeconfig.json")
)) {
    if (-not (Test-Path -LiteralPath $required -PathType Leaf)) {
        throw "Build output '$required' is missing."
    }
}

$testStage = Join-Path $stageRoot "test"
$dataPoolStage = Join-Path $stageRoot "datapool"
New-Item -ItemType Directory -Force -Path $testStage, $dataPoolStage | Out-Null
Copy-Item -Path (Join-Path $testOutput "*") -Destination $testStage -Recurse -Force
Copy-Item -Path (Join-Path $dataPoolOutput "*") -Destination $dataPoolStage -Recurse -Force

foreach ($runtimePath in @(
    (Join-Path $testStage "TestResults"),
    (Join-Path $testStage "data"),
    (Join-Path $dataPoolStage "data"),
    (Join-Path $testStage "nunit_random_seed.tmp"),
    (Join-Path $testStage "seed.tmp")
)) {
    if (Test-Path -LiteralPath $runtimePath) {
        Remove-Item -LiteralPath $runtimePath -Recurse -Force
    }
}

New-Item -ItemType Directory -Force -Path `
    (Join-Path $stageRoot "runsettings"), `
    (Join-Path $stageRoot "config"), `
    (Join-Path $stageRoot "scripts\CI"), `
    (Join-Path $stageRoot "tools\CiTestInventory"), `
    (Join-Path $stageRoot "tools\TestPlanPublisher"), `
    (Join-Path $stageRoot "tools\reports") | Out-Null

Copy-Item -LiteralPath (Join-Path $root "ci.runsettings") `
    -Destination (Join-Path $stageRoot "runsettings\ci.runsettings")
Copy-Item -LiteralPath (Join-Path $root "Pipelines\config\shards.json") `
    -Destination (Join-Path $stageRoot "config\shards.json")
Copy-Item -LiteralPath (
    Join-Path $root "Pipelines\config\testplans-mapping.template.json") `
    -Destination (
        Join-Path $stageRoot "config\testplans-mapping.template.json")
foreach ($script in @(
    "PipelineContracts.psm1",
    "Test-TestPackage.ps1",
    "Test-ShardOwnership.ps1",
    "Install-Playwright.ps1",
    "Invoke-PackageSuite.ps1",
    "Invoke-TestShard.ps1",
    "Invoke-TestPlanPublication.ps1",
    "Invoke-StabilizationVerification.ps1",
    "Test-IntegrationReadiness.ps1",
    "Test-TestPlanPublisherSmoke.ps1"
)) {
    Copy-Item -LiteralPath (Join-Path $root "Scripts\CI\$script") `
        -Destination (Join-Path $stageRoot "scripts\CI\$script")
}

foreach ($tool in @(
    "Cleanup-TestArtifacts.ps1",
    "Extract-SFPPremiums.ps1",
    "FormsCheck.ps1"
)) {
    Copy-Item -LiteralPath (Join-Path $root "Scripts\$tool") `
        -Destination (Join-Path $stageRoot "tools\reports\$tool")
}

$metadataRoot = Join-Path $stageRoot "metadata"
New-Item -ItemType Directory -Force -Path $metadataRoot | Out-Null
Copy-Item -Path (Join-Path $inventoryToolOutput "*") `
    -Destination (Join-Path $stageRoot "tools\CiTestInventory") `
    -Recurse -Force
Copy-Item -Path (Join-Path $publisherToolOutput "*") `
    -Destination (Join-Path $stageRoot "tools\TestPlanPublisher") `
    -Recurse -Force

Import-Module (Join-Path $stageRoot "scripts\CI\PipelineContracts.psm1") -Force
[void](Get-CompiledTestInventory `
    -InventoryTool (Join-Path $stageRoot "tools\CiTestInventory\CiTestInventory.dll") `
    -TestAssembly (Join-Path $stageRoot "test\TestAutomation.dll") `
    -OutputPath (Join-Path $metadataRoot "test-inventory.json"))
foreach ($suiteMode in @(
    @("All", "Full"),
    @("All", "Debug"),
    @("Forms", "Full")
)) {
    $suite = $suiteMode[0]
    $mode = $suiteMode[1]
    & (Join-Path $stageRoot "scripts\CI\Test-ShardOwnership.ps1") `
        -PackageRoot $stageRoot `
        -Suite $suite `
        -Mode $mode `
        -OutputPath (Join-Path $metadataRoot "shards-$Suite-$Mode.json") |
        Out-Null
}

[void](New-PackageManifest `
    -PackageRoot $stageRoot `
    -PackageVersion $PackageVersion `
    -CommitSha $CommitSha `
    -BuildId $BuildId `
    -BuildNumber $BuildNumber)
[void](Test-PackageManifest -PackageRoot $stageRoot -ScanForSecrets)

$safeCommit = ($CommitSha -replace '[^A-Za-z0-9]', '').Substring(
    0,
    [Math]::Min(12, ($CommitSha -replace '[^A-Za-z0-9]', '').Length))
$archiveName = "PnC-TestAutomation-$PackageVersion-$safeCommit.zip"
$archivePath = Join-Path $output $archiveName
if (Test-Path -LiteralPath $archivePath) {
    throw "Immutable package archive '$archivePath' already exists."
}
Compress-Archive -Path (Join-Path $stageRoot "*") -DestinationPath $archivePath

$stabilizationReport = Join-Path $verificationRoot "stabilization-report.json"
& (Join-Path $stageRoot "scripts\CI\Invoke-StabilizationVerification.ps1") `
    -ArchivePath $archivePath `
    -OutputPath $stabilizationReport

Write-Host "Created validated package: $archivePath"
return [PSCustomObject]@{
    ArchivePath = $archivePath
    PackageRoot = $stageRoot
    UnitResultsPath = $unitResults
    StabilizationReportPath = $stabilizationReport
}
