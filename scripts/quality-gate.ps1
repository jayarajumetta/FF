$ErrorActionPreference = "Stop"
$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
python (Join-Path $Root "tools/quality_gate.py") $Root
dotnet build (Join-Path $Root "ToscaArtifactAutomation.sln") -c Release
dotnet test (Join-Path $Root "ToscaArtifactAutomation.sln") -c Release --no-build --list-tests
