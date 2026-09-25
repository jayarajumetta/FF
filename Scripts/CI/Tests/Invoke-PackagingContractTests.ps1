#requires -Version 7.2
[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Resolve-Path (Join-Path $PSScriptRoot "..\..\..")).Path,
    [switch]$IncludeCompiledInventory
)

$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest
Import-Module (Join-Path $RepositoryRoot "Scripts\CI\PipelineContracts.psm1") -Force
$script:Passed = 0
function Assert-True([bool]$Condition, [string]$Message) {
    if (-not $Condition) { throw $Message }
    $script:Passed++
}
function Assert-Throws([scriptblock]$Action, [string]$Pattern) {
    try { & $Action }
    catch {
        if ($_.Exception.Message -notmatch $Pattern) { throw }
        $script:Passed++
        return
    }
    throw "Expected failure matching '$Pattern'."
}
function Read-Ast([string]$Path) {
    $tokens = $null
    $errors = $null
    $ast = [Management.Automation.Language.Parser]::ParseFile(
        $Path, [ref]$tokens, [ref]$errors)
    Assert-True ($errors.Count -eq 0) "PowerShell parse failure: $Path"
    return $ast
}
function Write-Fixture([string]$Path, [string]$Content = "{}") {
    New-Item -ItemType Directory -Force -Path (Split-Path -Parent $Path) | Out-Null
    Set-Content -LiteralPath $Path -Value $Content -Encoding UTF8
}
function Assert-HostContract([string]$Yaml) {
    if ($Yaml -match '(?m)^\s*-\s*powershell:' -or
        $Yaml -notmatch '(?m)^\s*-\s*pwsh:' -or
        $Yaml -notmatch 'PowerShell 7\.2\+') {
        throw "Package callers require explicit pwsh and a PowerShell 7.2+ prerequisite."
    }
}

$temporaryRoot = Join-Path ([IO.Path]::GetTempPath()) (
    "PnC-PackagingContracts-" + [Guid]::NewGuid().ToString("N"))
$originalDotnet = Get-Item -LiteralPath "Function:\global:dotnet" -ErrorAction SilentlyContinue
$global:PackagingNative = @{
    Dotnet = (Get-Command dotnet -CommandType Application).Source
    Pwsh = (Get-Command pwsh -CommandType Application).Source
    FailVerb = ""
    Calls = [Collections.Generic.List[string]]::new()
}
try {
    New-Item -ItemType Directory -Path $temporaryRoot | Out-Null
    foreach ($template in @("build-package-stage", "test-shards-stage", "setup-datapool-stage")) {
        $yaml = Get-Content -LiteralPath (
            Join-Path $RepositoryRoot "Pipelines\templates\$template.yml") -Raw
        Assert-HostContract $yaml
        Assert-True $true "Supported host contract."
        Assert-Throws { Assert-HostContract ($yaml.Replace("- pwsh:", "- powershell:")) } "explicit pwsh"
    }
    foreach ($script in @(
        "CI\New-TestPackage", "CI\Invoke-PackageSuite", "CI\Test-TestPackage",
        "CI\Invoke-StabilizationVerification", "CI\Test-IntegrationReadiness",
        "CI\Test-TestPlanPublisherSmoke", "run-sfp-basic", "Invoke-ScheduledRun"
    )) {
        $path = Join-Path $RepositoryRoot "Scripts\$script.ps1"
        $ast = Read-Ast $path
        Assert-True ($ast.ScriptRequirements.RequiredPSVersion -eq [version]"7.2") (
            "$script must reject unsupported hosts before side effects.")
        if ($IsWindows) {
            $output = & powershell.exe -NoProfile -NonInteractive -File $path 2>&1
            Assert-True ($LASTEXITCODE -ne 0 -and ($output -join "`n") -match '7\.2') (
                "Windows PowerShell must reject $script before parameter prompts or execution.")
        }
    }

    # Execute the production builder's native-command block and return statement
    # inside a synthetic repository, then exercise the unmodified fresh-build caller.
    $builderAst = Read-Ast (Join-Path $RepositoryRoot "Scripts\CI\New-TestPackage.ps1")
    $buildBlock = $builderAst.Find({
        param($node)
        $node -is [Management.Automation.Language.TryStatementAst] -and
        $node.Extent.Text -match 'dotnet restore'
    }, $false)
    $returnStatement = @($builderAst.EndBlock.Statements |
        Where-Object { $_ -is [Management.Automation.Language.ReturnStatementAst] })
    Assert-True ($null -ne $buildBlock -and $returnStatement.Count -eq 1) (
        "The production build/receipt boundary was not found.")
    $fixtureRepo = Join-Path $temporaryRoot "caller"
    $fixtureCi = Join-Path $fixtureRepo "Scripts\CI"
    Write-Fixture (Join-Path $fixtureCi "Tests\Invoke-CIContractTests.ps1") (
        'param($RepositoryRoot, [switch]$IncludeCompiledInventory); Write-Output "synthetic contract diagnostics"')
    Write-Fixture (Join-Path $fixtureRepo "bin\Release\net8.0\playwright.ps1") (
        'Write-Output "synthetic installer diagnostics"; $global:LASTEXITCODE = 0')
    Copy-Item -LiteralPath (Join-Path $RepositoryRoot "Scripts\CI\Invoke-PackageSuite.ps1") `
        -Destination $fixtureCi
    Copy-Item -LiteralPath (Join-Path $RepositoryRoot "Scripts\CI\PipelineContracts.psm1") `
        -Destination $fixtureCi
    Write-Fixture (Join-Path $fixtureCi "New-TestPackage.ps1") (
        @'
param($RepositoryRoot, $OutputDirectory)
$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest
$root = $RepositoryRoot
$verificationRoot = Join-Path $root "verification"
$stageRoot = Join-Path $root "stage"
$archivePath = Join-Path $root "receipt.zip"
$stabilizationReport = Join-Path $root "stabilization.json"
New-Item -ItemType Directory -Force -Path $stageRoot, $verificationRoot | Out-Null
"archive-fixture" | Set-Content -LiteralPath $archivePath
"{}" | Set-Content -LiteralPath $stabilizationReport
Push-Location $root
'@ + "`n" + $buildBlock.Extent.Text + "`n" + $returnStatement[0].Extent.Text)
    Write-Fixture (Join-Path $fixtureCi "Test-TestPackage.ps1") @'
param($ArchivePath, $ExtractionRoot, [switch]$DiscoverySmoke, [switch]$ScanForSecrets)
if ($ArchivePath -ne (Join-Path (Resolve-Path "$PSScriptRoot\..\..").Path "receipt.zip")) {
    throw "Incorrect archive selected by fresh-build caller."
}
throw "Offline stop: validated typed receipt reached package validation."
'@
    function global:dotnet {
        $verb = [string]$args[0]
        $global:PackagingNative.Calls.Add($verb)
        if ($verb -notin @("restore", "build", "test")) {
            throw "Unexpected native build command '$verb'."
        }
        $code = if ($verb -eq $global:PackagingNative.FailVerb) { 9 } else { 0 }
        & $global:PackagingNative.Pwsh -NoProfile -NonInteractive -Command (
            "Write-Output 'native-$verb-diagnostics'; exit $code")
        $global:LASTEXITCODE = $LASTEXITCODE
    }
    $transcript = Join-Path $temporaryRoot "native-diagnostics.txt"
    Start-Transcript -Path $transcript | Out-Null
    try {
        $receiptOutput = @(& (Join-Path $fixtureCi "New-TestPackage.ps1") `
            -RepositoryRoot $fixtureRepo)
        $receipt = Get-PackageReceipt -Output $receiptOutput
        Assert-True ($receiptOutput.Count -eq 1) "Native stdout contaminated the receipt."
        Assert-Throws {
            & (Join-Path $fixtureCi "Invoke-PackageSuite.ps1") `
                -OutputDirectory (Join-Path $fixtureRepo "runs")
        } "Offline stop: validated typed receipt"
        foreach ($failure in @(
            @{ Verb = "restore"; Pattern = "Locked solution restore failed" },
            @{ Verb = "build"; Pattern = "Release solution build failed" },
            @{ Verb = "test"; Pattern = "Unit/contract tests failed" }
        )) {
            $global:PackagingNative.FailVerb = $failure.Verb
            $global:PackagingNative.Calls.Clear()
            Assert-Throws {
                & (Join-Path $fixtureCi "Invoke-PackageSuite.ps1") `
                    -OutputDirectory (Join-Path $fixtureRepo "runs")
            } $failure.Pattern
            Assert-True ($global:PackagingNative.Calls[-1] -eq $failure.Verb) (
                "A failed native command did not stop the builder.")
        }
    }
    finally { Stop-Transcript | Out-Null }
    $diagnostics = Get-Content -LiteralPath $transcript -Raw
    foreach ($verb in @("restore", "build", "test")) {
        Assert-True ($diagnostics -match "native-$verb-diagnostics") "Native diagnostics were hidden."
    }
    Assert-Throws { Get-PackageReceipt -Output @() } "exactly one typed"
    Assert-Throws { Get-PackageReceipt -Output @($null) } "exactly one typed"
    Assert-Throws { Get-PackageReceipt -Output @($receipt, $receipt) } "exactly one typed"
    Assert-Throws { Get-PackageReceipt -Output @("log", $receipt) } "exactly one typed"
    Assert-Throws { Get-PackageReceipt -Output @([PSCustomObject]@{ ArchivePath = $receipt.ArchivePath }) } "exactly one typed"
    $savedArchivePath = $receipt.ArchivePath
    $receipt.ArchivePath = 42
    Assert-Throws { Get-PackageReceipt -Output @($receipt) } "invalid or missing 'ArchivePath'"
    $receipt.ArchivePath = $savedArchivePath
    $receipt.PSObject.Properties.Remove("StabilizationReportPath")
    Assert-Throws { Get-PackageReceipt -Output @($receipt) } "invalid or missing 'StabilizationReportPath'"
    $receipt.ArchivePath = Join-Path $temporaryRoot "missing.zip"
    Assert-Throws { Get-PackageReceipt -Output @($receipt) } "invalid or missing 'ArchivePath'"

    $packageAst = Read-Ast (Join-Path $RepositoryRoot "Scripts\CI\Test-TestPackage.ps1")
    $testCommands = @($packageAst.FindAll({
        param($node)
        $node -is [Management.Automation.Language.CommandAst] -and
        $node.GetCommandName() -eq "dotnet" -and
        $node.CommandElements[1].Extent.Text -eq "test"
    }, $true))
    Assert-True ($testCommands.Count -eq 1 -and
        $testCommands[0].Extent.Text -match '--list-tests' -and
        $testCommands[0].Extent.Text -notmatch '--filter') (
        "Mandatory package validation must never execute business features.")
    Assert-True ($packageAst.Extent.Text -notmatch 'Test-NonRunnableSelection|NotExecuted') (
        "The obsolete all-ignored business execution path still exists.")
    Assert-True ((Get-Command (Join-Path $RepositoryRoot "Scripts\CI\Test-TestPackage.ps1")).
        Parameters["SfpProfileContract"].Aliases -contains "SfpGatedSmoke") (
        "The legacy switch must be only an alias to offline profile validation.")

    if ($IncludeCompiledInventory) {
        $packageRoot = Join-Path $temporaryRoot "package"
        $moduleAst = Read-Ast (Join-Path $RepositoryRoot "Scripts\CI\PipelineContracts.psm1")
        $requiredAssignment = $moduleAst.Find({
            param($node)
            $node -is [Management.Automation.Language.AssignmentStatementAst] -and
            $node.Left.Extent.Text -eq '$requiredPaths'
        }, $true)
        Assert-True ($null -ne $requiredAssignment) "Manifest's required paths were not found."
        . ([scriptblock]::Create($requiredAssignment.Extent.Text))
        foreach ($path in $requiredPaths + @(
            "test/Resources/ExpectedForms/SFP/SFP.json", "test/Resources/SGS/fixture.json"
        )) {
            Write-Fixture (Join-Path $packageRoot ($path.Replace("/", "\")))
        }
        foreach ($part in @(
            @{ Source = "bin\Release\net8.0"; Target = "test" },
            @{ Source = "Tools\CiTestInventory\bin\Release\net8.0"; Target = "tools\CiTestInventory" },
            @{ Source = "Tools\TestPlanPublisher\bin\Release\net8.0"; Target = "tools\TestPlanPublisher" },
            @{ Source = "Tools\SgsReport\bin\Release\net8.0"; Target = "tools\SgsReport" }
        )) {
            $source = Join-Path $RepositoryRoot $part.Source
            foreach ($file in Get-ChildItem -LiteralPath $source -File |
                Where-Object { $_.Extension -eq ".dll" -or $_.Name -match '\.(deps|runtimeconfig)\.json$' }) {
                Copy-Item -LiteralPath $file.FullName -Destination (Join-Path $packageRoot $part.Target)
            }
        }
        Copy-Item -Path (Join-Path $RepositoryRoot "Scripts\CI\*.ps1") `
            -Destination (Join-Path $packageRoot "scripts\CI")
        Copy-Item -LiteralPath (Join-Path $RepositoryRoot "Scripts\CI\PipelineContracts.psm1") `
            -Destination (Join-Path $packageRoot "scripts\CI")
        foreach ($file in @("shards.json", "testplans-mapping.template.json")) {
            Copy-Item -LiteralPath (Join-Path $RepositoryRoot "Pipelines\config\$file") `
                -Destination (Join-Path $packageRoot "config")
        }
        Copy-Item -LiteralPath (Join-Path $RepositoryRoot "ci.runsettings") `
            -Destination (Join-Path $packageRoot "runsettings\ci.runsettings")
        $matrixPath = Join-Path $packageRoot "test\Resources\Contracts\integration-readiness.json"
        Copy-Item -LiteralPath (Join-Path $RepositoryRoot "Resources\Contracts\integration-readiness.json") `
            -Destination $matrixPath
        $catalogPath = Join-Path $packageRoot "test\Resources\ExpectedOutcomes\sfp-outcomes.json"
        New-Item -ItemType Directory -Path (Split-Path -Parent $catalogPath) | Out-Null
        Copy-Item -LiteralPath (Join-Path $RepositoryRoot "Resources\ExpectedOutcomes\sfp-outcomes.json") `
            -Destination $catalogPath
        $originalCatalog = Get-Content -LiteralPath $catalogPath -Raw
        $originalMatrix = Get-Content -LiteralPath $matrixPath -Raw
        $global:PackagingNative.Calls.Clear()
        $global:PackagingNative.FailVerb = ""
        function global:dotnet {
            $first = [string]$args[0]
            $global:PackagingNative.Calls.Add(($args -join " "))
            if ($first -eq "test") {
                if ($args -notcontains "--list-tests" -or $args -contains "--filter") {
                    throw "Business test execution is forbidden by the offline contract."
                }
            }
            elseif ($first -eq "--version") { }
            elseif ([IO.Path]::GetFileName($first) -eq "CiTestInventory.dll") {
                if ($global:PackagingNative.FailVerb -eq "inventory") {
                    Write-Host "Synthetic inventory native failure."
                    $global:LASTEXITCODE = 9
                    return
                }
            }
            elseif ([IO.Path]::GetFileName($first) -eq "TestPlanPublisher.dll" -and
                $args[1] -eq "dry-run") { }
            elseif ([IO.Path]::GetFileName($first) -eq "SgsReport.dll" -and
                ($args -join " ") -match 'deliberately-missing\.trx') { }
            else { throw "Unapproved native command in offline validation: $first" }
            & $global:PackagingNative.Dotnet @args
            $global:LASTEXITCODE = $LASTEXITCODE
        }
        $inventory = Get-CompiledTestInventory `
            -InventoryTool (Join-Path $packageRoot "tools\CiTestInventory\CiTestInventory.dll") `
            -TestAssembly (Join-Path $packageRoot "test\TestAutomation.dll") `
            -OutputPath (Join-Path $packageRoot "metadata\test-inventory.json")
        foreach ($suite in @("All", "Forms")) {
            & (Join-Path $packageRoot "scripts\CI\Test-ShardOwnership.ps1") `
                -PackageRoot $packageRoot -Suite $suite -Mode Full `
                -OutputPath (Join-Path $packageRoot "metadata\shards-$suite-Full.json") | Out-Null
        }
        function Update-FixtureManifest {
            [void](New-PackageManifest -PackageRoot $packageRoot -PackageVersion "1.4.0" `
                -CommitSha "offline-contract" -BuildId "offline" -BuildNumber "offline")
        }
        Update-FixtureManifest
        $readinessOutput = Join-Path $temporaryRoot "readiness.json"
        foreach ($switchName in @("SfpProfileContract", "SfpGatedSmoke")) {
            $parameters = @{ PackageRoot = $packageRoot; ReadinessOutputPath = $readinessOutput }
            $parameters[$switchName] = $true
            & (Join-Path $packageRoot "scripts\CI\Test-TestPackage.ps1") @parameters
            $report = (Get-Content -LiteralPath $readinessOutput -Raw | ConvertFrom-Json).report
            Assert-True ($report.schemaVersion -eq 2 -and $report.workflowCount -eq 3) "Invalid readiness report."
            foreach ($workflow in $report.workflows) {
                Assert-True ($workflow.profileStatus -eq "PerCase" -and $workflow.state -eq "Gated") (
                    "Per-case approval must not authorize a workflow.")
                Assert-True ($workflow.profileAdmissions.Count -eq 2 * $workflow.discoveredCases) (
                    "Every discovered case needs both environment resolutions.")
                Assert-True (@($workflow.profileAdmissions | Where-Object {
                    $_.environment -eq "dev" -and $_.isRunnable
                }).Count -eq 0) "A QA approval leaked into dev."
            }
            $basic = @($report.workflows | Where-Object workflowId -eq "sfp-basic")[0]
            $ce = @($report.workflows | Where-Object workflowId -eq "sfp-country-estate")[0]
            Assert-True (@($basic.profileAdmissions | Where-Object {
                $_.environment -eq "qa" -and $_.isRunnable
            }).Count -eq 38) "The 38 Basic QA approvals changed."
            Assert-True (@($ce.profileAdmissions | Where-Object {
                $_.environment -eq "qa" -and $_.isRunnable
            }).Count -eq 16) "The 16 CE QA approvals changed."
            Assert-True (@($ce.profileAdmissions | Where-Object {
                $_.environment -eq "qa" -and $_.state -eq "AR" -and
                -not $_.isRunnable -and $_.mode -eq "NonRunnable" -and $_.reason
            }).Count -eq 1) "The CE AR fallback was not resolved by the provider."
        }
        $stabilizationOutput = Join-Path $temporaryRoot "stabilization.json"
        & (Join-Path $packageRoot "scripts\CI\Invoke-StabilizationVerification.ps1") `
            -PackageRoot $packageRoot -OutputPath $stabilizationOutput
        $stabilization = (Get-Content -LiteralPath $stabilizationOutput -Raw | ConvertFrom-Json).report
        Assert-True ($stabilization.schemaVersion -eq 2 -and
            $stabilization.sourceFreeOfflineValidation -and -not $stabilization.businessTestsExecuted -and
            $stabilization.checks.sfpPerCaseProfileAdmission -eq "Passed") (
            "Stabilization must report offline admission, not business execution.")
        Assert-True (@($global:PackagingNative.Calls | Where-Object { $_ -match '^test ' }).Count -eq 1) (
            "The only test-host command must be the guarded list-tests discovery.")

        foreach ($defect in @(
            "checksum", "expired", "environment", "duplicate-environment", "blanket-status",
            "workflow", "inventory"
        )) {
            $catalog = $originalCatalog | ConvertFrom-Json
            $matrix = $originalMatrix | ConvertFrom-Json
            $approved = @($catalog.profiles | Where-Object mode -eq "Approved")[0]
            switch ($defect) {
                "checksum" { $approved.checksum = "0" * 64 }
                "expired" { $approved.provenance.validUntilUtc = "2000-01-01T00:00:00Z" }
                "environment" { $matrix.workflows[0].profile.environments = @("unconfigured") }
                "duplicate-environment" { $matrix.workflows[0].profile.environments = @("qa", "QA") }
                "blanket-status" { $matrix.workflows[0].profile.status = "NonRunnable" }
                "workflow" { $matrix.workflows[0].state = "Runnable" }
                "inventory" { $global:PackagingNative.FailVerb = "inventory" }
            }
            $catalog | ConvertTo-Json -Depth 30 | Set-Content -LiteralPath $catalogPath
            $matrix | ConvertTo-Json -Depth 30 | Set-Content -LiteralPath $matrixPath
            Update-FixtureManifest
            $pattern = if ($defect -eq "workflow") { "without all approvals" } else { "inventory generation failed" }
            Assert-Throws {
                & (Join-Path $packageRoot "scripts\CI\Test-IntegrationReadiness.ps1") `
                    -PackageRoot $packageRoot -OutputPath $readinessOutput
            } $pattern
        }
    }
    Write-Host "Packaging contract tests passed: $script:Passed assertions; compiled inventory=$IncludeCompiledInventory."
}
finally {
    if ($null -eq $originalDotnet) {
        Remove-Item -LiteralPath "Function:\global:dotnet"
    } else {
        Set-Item -LiteralPath "Function:\global:dotnet" -Value $originalDotnet.ScriptBlock
    }
    Remove-Variable PackagingNative -Scope Global
    if (Test-Path -LiteralPath $temporaryRoot) {
        Remove-Item -LiteralPath $temporaryRoot -Recurse -Force
    }
}
