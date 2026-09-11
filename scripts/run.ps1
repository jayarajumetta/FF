param(
    [ValidateSet('ALL','CLDC','CLEQ','PLDC')][string]$Project = 'ALL',
    [string]$Filter = '',
    [ValidateSet('Debug','Release')][string]$Configuration = 'Debug',
    [string]$ResultsDirectory = ''
)
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'TestOutput.ps1')
$projects = [ordered]@{
    'CLDC' = '.\tests\CommercialLines.DuckCreek.Tests\CommercialLines.DuckCreek.Tests.csproj'
    'CLEQ' = '.\tests\CommercialLines.ExpertQuote.Tests\CommercialLines.ExpertQuote.Tests.csproj'
    'PLDC' = '.\tests\PersonalLines.DuckCreek.Tests\PersonalLines.DuckCreek.Tests.csproj'
}
Push-Location (Split-Path $PSScriptRoot -Parent)
$run = $null
$oldResultsRoot = $env:TEST_RESULTS_ROOT
$oldRepositoryRoot = $env:TEST_REPOSITORY_ROOT
$oldConfigPath = $env:TEST_FRAMEWORK_CONFIG
$exitCode = 0
try {
    $repositoryRoot = (Get-Location).Path
    $output = Get-TestOutputConfiguration $repositoryRoot $ResultsDirectory
    $run = Initialize-TestResultsRoot $repositoryRoot $output.ResultsRoot
    $resultsFull = $run.Path
    $env:TEST_RESULTS_ROOT = $resultsFull
    $env:TEST_REPOSITORY_ROOT = $repositoryRoot
    $env:TEST_FRAMEWORK_CONFIG = $output.ConfigPath
    $nunitXmlDirectory = Join-Path $resultsFull 'NUnit'
    New-Item -ItemType Directory -Force -Path $nunitXmlDirectory | Out-Null
    Write-Host "Results and evidence: $resultsFull"

    $targets = if ($Project -eq 'ALL') { $projects.GetEnumerator() } else { @([pscustomobject]@{ Key = $Project; Value = $projects[$Project] }) }
    foreach ($target in $targets) {
        $resultFile = "$($target.Key).trx"
        $args = @(
            'test', $target.Value,
            '-c', $Configuration,
            '--settings', (Join-Path $repositoryRoot 'Tosca.runsettings'),
            '--results-directory', $resultsFull,
            '--logger', "trx;LogFileName=$resultFile",
            '--logger', 'console;verbosity=normal'
        )
        if (-not [string]::IsNullOrWhiteSpace($Filter)) { $args += @('--filter', $Filter) }
        $workDirectory = Join-Path $resultsFull "NUnitWork\$($target.Key)"
        New-Item -ItemType Directory -Force -Path $workDirectory | Out-Null
        $args += @('--', "NUnit.TestOutputXml=$nunitXmlDirectory", "NUnit.WorkDirectory=$workDirectory")

        & dotnet @args
        if ($LASTEXITCODE -ne 0) { $exitCode = $LASTEXITCODE }
    }
}
finally {
    if ($null -ne $run) { $run.Lock.Dispose() }
    $env:TEST_RESULTS_ROOT = $oldResultsRoot
    $env:TEST_REPOSITORY_ROOT = $oldRepositoryRoot
    $env:TEST_FRAMEWORK_CONFIG = $oldConfigPath
    Pop-Location
}
exit $exitCode
