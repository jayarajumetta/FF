param([ValidateSet("all","smoke","regression","cl-dc","cl-eq","pl-dc","rate-filings")][string]$Suite="all")
$ErrorActionPreference = "Stop"
$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$Filters = @{ smoke="TestCategory=smoke"; regression="TestCategory=regression"; "cl-dc"="TestCategory=CL_DC"; "cl-eq"="TestCategory=CL_EQ"; "pl-dc"="TestCategory=PL_DC"; "rate-filings"="TestCategory=rate_filings" }
$Args = @("test", (Join-Path $Root "ToscaArtifactAutomation.sln"), "-c", "Release", "--logger", "trx;LogFileName=results.trx")
if ($Suite -ne "all") { $Args += @("--filter", $Filters[$Suite]) }
& dotnet @Args
