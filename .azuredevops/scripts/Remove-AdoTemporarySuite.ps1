param(
	[Parameter(Mandatory = $true)][string]$PlanId,
	[Parameter(Mandatory = $true)][string]$SuiteId
)

$ErrorActionPreference = 'Stop'

if ([string]::IsNullOrWhiteSpace($SuiteId)) {
	Write-Host 'SuiteId is empty; nothing to remove.'
	exit 0
}
if ([string]::IsNullOrWhiteSpace($env:SYSTEM_ACCESSTOKEN)) {
	throw 'SYSTEM_ACCESSTOKEN is required.'
}
if ([string]::IsNullOrWhiteSpace($env:SYSTEM_COLLECTIONURI) -or [string]::IsNullOrWhiteSpace($env:SYSTEM_TEAMPROJECT)) {
	throw 'SYSTEM_COLLECTIONURI and SYSTEM_TEAMPROJECT are required.'
}

$collectionUri = $env:SYSTEM_COLLECTIONURI.TrimEnd('/')
$project = $env:SYSTEM_TEAMPROJECT
$headers = @{ Authorization = "Bearer $($env:SYSTEM_ACCESSTOKEN)" }
$deleteUri = "$collectionUri/$project/_apis/testplan/Plans/$PlanId/suites/$SuiteId?api-version=7.1-preview.1"

try {
	Invoke-RestMethod -Method Delete -Uri $deleteUri -Headers $headers | Out-Null
	Write-Host "Removed temporary suite $SuiteId from plan $PlanId."
}
catch {
	Write-Warning "Failed to remove temporary suite $SuiteId. $($_.Exception.Message)"
}
