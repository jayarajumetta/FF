#!/usr/bin/env bash
set -euo pipefail
cd "$(dirname "$0")/.."
python3 RunScripts/quality_gate_v29.py
