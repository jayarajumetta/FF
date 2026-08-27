$ErrorActionPreference = 'Stop'
Push-Location (Split-Path $PSScriptRoot -Parent)
try {
    dotnet --version
    dotnet restore .\ToscaCanonicalSimple.sln
    dotnet build .\ToscaCanonicalSimple.sln -c Debug --no-restore
} finally { Pop-Location }
