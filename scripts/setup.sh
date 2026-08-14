#!/usr/bin/env bash
set -euo pipefail
ROOT="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
cd "$ROOT"
dotnet restore ToscaArtifactAutomation.sln
dotnet build ToscaArtifactAutomation.sln -c Release --no-restore
pwsh "$(find tests -path '*/bin/Release/net8.0/playwright.ps1' | head -n 1)" install msedge
