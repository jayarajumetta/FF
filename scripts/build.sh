#!/usr/bin/env bash
set -euo pipefail
dotnet restore ./ToscaModernized.sln
dotnet build ./ToscaModernized.sln -c Release --no-restore
python3 ./tools/validate_framework.py
