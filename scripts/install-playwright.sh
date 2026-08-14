#!/usr/bin/env bash
set -euo pipefail
dotnet build ./ToscaModernized.sln -c Release
script=$(find ./tests/ToscaModernized.Tests/bin/Release -name playwright.sh -o -name playwright.ps1 | head -1)
[ -n "$script" ] || { echo "Playwright installer was not generated" >&2; exit 1; }
if [[ "$script" == *.ps1 ]]; then pwsh "$script" install --with-deps chromium; else "$script" install --with-deps chromium; fi
