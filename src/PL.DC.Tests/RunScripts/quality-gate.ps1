$ErrorActionPreference = "Stop"
$report = Get-Content "Reports/business-feature-quality-v24.json" | ConvertFrom-Json
if ($report.missingBindings.Count -gt 0) { throw "Missing Feature bindings detected." }
Write-Host "v24 business Feature quality gate passed."
