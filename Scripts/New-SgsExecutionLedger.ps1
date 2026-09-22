[CmdletBinding()]
param(
    [Parameter(Mandatory)][string] $DependencyMap,
    [Parameter(Mandatory)][DateTimeOffset] $SourceVerifiedAtUtc,
    [string] $SourceDeltaManifest,
    [string] $RepositoryRoot = (Join-Path $PSScriptRoot '..')
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest
$root = [IO.Path]::GetFullPath($RepositoryRoot)
$project = Join-Path $root 'Tools\CiTestInventory\CiTestInventory.csproj'
$arguments = @('run', '--no-build', '--project', $project, '--',
    'initialize-sgs-ledger', $root, [IO.Path]::GetFullPath($DependencyMap),
    $SourceVerifiedAtUtc.ToUniversalTime().ToString('O'))
if ($SourceDeltaManifest) { $arguments += [IO.Path]::GetFullPath($SourceDeltaManifest) }
& dotnet @arguments
if ($LASTEXITCODE -ne 0) {
    throw 'SGS ledger initialization failed. Build CiTestInventory first and inspect the reported provenance error.'
}
