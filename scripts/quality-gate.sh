#!/usr/bin/env bash
set -euo pipefail
ROOT="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
python3 "$ROOT/tools/quality_gate.py" "$ROOT"
dotnet build "$ROOT/ToscaArtifactAutomation.sln" -c Release
dotnet test "$ROOT/ToscaArtifactAutomation.sln" -c Release --no-build --list-tests
