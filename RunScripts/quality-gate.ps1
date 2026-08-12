$ErrorActionPreference='Stop'
Set-Location (Join-Path $PSScriptRoot '..')
python .\RunScripts\quality_gate.py
