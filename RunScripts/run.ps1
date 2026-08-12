param(
  [ValidateSet("all","bop-eq","pl-dc")] [string]$Domain="all",
  [string]$Filter=""
)
$ErrorActionPreference="Stop"
Set-Location (Join-Path $PSScriptRoot "..")
switch($Domain) {
  "bop-eq" {$Target=".\src\BOP.EQ.Tests\ClientAutomation.BOPEQ.Tests.csproj"}
  "pl-dc" {$Target=".\src\PL.DC.Tests\ClientAutomation.PLDC.Tests.csproj"}
  default {$Target=".\ClientAutomation.sln"}
}
$Args=@("test",$Target,"--settings",".\client.runsettings")
if($Filter){$Args+=@("--filter",$Filter)}
dotnet @Args
