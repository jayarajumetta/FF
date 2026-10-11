<#
.SYNOPSIS
	Removes a leading "*" from expected_premium_value_233 in BAP Basic Policy scenario JSON files.

.DESCRIPTION
	Some scenario files have the field like "expected_premium_value_233": "*$1,890.00".
	This script strips the leading "*" so the value becomes "$1,890.00".

.NOTES
	Run from any directory; the script locates files relative to its own location.
#>

$ErrorActionPreference = 'Stop'

$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path

$field = 'expected_premium_value_233'

$jsonFiles = Get-ChildItem -Path (Join-Path $scriptDir 'Basic') -Filter '001_bap_basic_policy_*.json' -File

$totalChanged = 0

foreach ($file in $jsonFiles) {
	$content = Get-Content -Path $file.FullName -Raw
	$fileChanged = $false

	$pattern = '("' + [regex]::Escape($field) + '"\s*:\s*")\*'
	if ($content -match $pattern) {
		$content = [regex]::Replace($content, $pattern, '$1')
		$fileChanged = $true
	}

	if ($fileChanged) {
		Set-Content -Path $file.FullName -Value $content -NoNewline
		$totalChanged++
		Write-Host "Updated: $($file.Name)"
	}
}

Write-Host ""
Write-Host "Done. Files updated: $totalChanged out of $($jsonFiles.Count) scanned."
