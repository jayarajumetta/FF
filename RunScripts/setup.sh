#!/usr/bin/env bash
set -euo pipefail
cd "$(dirname "$0")/.."
dotnet restore ClientAutomation.sln
dotnet build ClientAutomation.sln --no-restore
P="$(find src -path '*/bin/*/net8.0/playwright.sh' -o -path '*/bin/*/net8.0/playwright.ps1' | head -1 || true)"
[[ -n "$P" ]] || { echo "Playwright install script not generated" >&2; exit 1; }
if [[ "$P" == *.ps1 ]]; then pwsh "$P" install --with-deps chromium; else bash "$P" install --with-deps chromium; fi
