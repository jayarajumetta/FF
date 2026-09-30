<#
.SYNOPSIS
	Removes a leading "$" from specific premium value fields in BAP Basic Policy scenario JSON files.

.DESCRIPTION
	Fields fixed:
	  - expected_full_term_premium_value_280
	  - expected_premium_written_value_281
	  - expected_prior_premium_value_282
	  - expected_premium_change_value_283

	For each of these fields, if the JSON string value starts with "$" it is stripped so only the
	numeric value (e.g. "2,183.00") remains, matching the format of the other fields.

.NOTES
	Run from any directory; the script locates files relative to its own location.
#>

$ErrorActionPreference = 'Stop'

$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path

$fieldsToFix = @(
	'expected_full_term_premium_value_280',
	'expected_premium_written_value_281',
	'expected_prior_premium_value_282',
	'expected_premium_change_value_283'
)

$jsonFiles = Get-ChildItem -Path $scriptDir -Filter '001_bap_basic_policy_*.json' -File

$totalChanged = 0

foreach ($file in $jsonFiles) {
	$content = Get-Content -Path $file.FullName -Raw
	$originalContent = $content
	$fileChanged = $false

	foreach ($field in $fieldsToFix) {
		$pattern = '("' + [regex]::Escape($field) + '"\s*:\s*")\$'
		if ($content -match $pattern) {
			$content = [regex]::Replace($content, $pattern, '$1')
			$fileChanged = $true
		}
	}

	if ($fileChanged) {
		Set-Content -Path $file.FullName -Value $content -NoNewline
		$totalChanged++
		Write-Host "Updated: $($file.Name)"
	}
}

Write-Host ""
Write-Host "Done. Files updated: $totalChanged out of $($jsonFiles.Count) scanned."
