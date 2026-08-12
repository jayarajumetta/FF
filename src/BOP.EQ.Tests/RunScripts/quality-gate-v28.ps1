$ErrorActionPreference='Stop'
Set-Location (Join-Path $PSScriptRoot '..')
python .\RunScripts\quality_gate_v28.py
