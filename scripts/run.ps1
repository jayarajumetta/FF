param(
    [ValidateSet('ALL','CLDC','CLEQ','PLDC')][string]$Project='ALL',
    [string]$Filter='',
    [string]$Configuration='Debug',
    [string]$ResultsDirectory='TestResults'
)
$ErrorActionPreference = 'Stop'

$projects = @{
    'CLDC'='.\tests\CommercialLines.DuckCreek.Tests\CommercialLines.DuckCreek.Tests.csproj'
    'CLEQ'='.\tests\CommercialLines.ExpertQuote.Tests\CommercialLines.ExpertQuote.Tests.csproj'
    'PLDC'='.\tests\PersonalLines.DuckCreek.Tests\PersonalLines.DuckCreek.Tests.csproj'
}
Push-Location (Split-Path $PSScriptRoot -Parent)
try {
    New-Item -ItemType Directory -Force -Path $ResultsDirectory | Out-Null
    $nunitXmlDirectory = Join-Path (Resolve-Path $ResultsDirectory).Path 'NUnit'
    New-Item -ItemType Directory -Force -Path $nunitXmlDirectory | Out-Null
    $targets = if ($Project -eq 'ALL') { $projects.GetEnumerator() } else { @([pscustomobject]@{ Key=$Project; Value=$projects[$Project] }) }
    foreach ($target in $targets) {
        $resultFile = "$($target.Key).trx"
        $args = @('test',$target.Value,'-c',$Configuration,'--results-directory',$ResultsDirectory,'--logger',"trx;LogFileName=$resultFile",'--logger','console;verbosity=normal','--',"NUnit.TestOutputXml=$nunitXmlDirectory")
        if ($Filter) { $args += @('--filter',$Filter) }
        & dotnet @args
        if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }
    }
} finally { Pop-Location }
