param(
	[Parameter(Mandatory = $true)][string]$PlanId,
	[Parameter(Mandatory = $true)][string]$ParentSuiteId,
	[Parameter(Mandatory = $true)][string]$TestCaseId,
	[string]$ConfigurationId
)

$ErrorActionPreference = 'Stop'

if ([string]::IsNullOrWhiteSpace($env:SYSTEM_ACCESSTOKEN)) {
	throw 'SYSTEM_ACCESSTOKEN is required.'
}
if ([string]::IsNullOrWhiteSpace($env:SYSTEM_COLLECTIONURI) -or [string]::IsNullOrWhiteSpace($env:SYSTEM_TEAMPROJECT)) {
	throw 'SYSTEM_COLLECTIONURI and SYSTEM_TEAMPROJECT are required.'
}

$collectionUri = $env:SYSTEM_COLLECTIONURI.TrimEnd('/')
$project = $env:SYSTEM_TEAMPROJECT
$headers = @{ Authorization = "Bearer $($env:SYSTEM_ACCESSTOKEN)" }

$suiteName = "Pipeline SingleCase $($env:BUILD_BUILDID) TC$TestCaseId"
$createSuiteUri = "$collectionUri/$project/_apis/testplan/Plans/$PlanId/suites/$ParentSuiteId?api-version=7.1-preview.1"
$createSuiteBody = @{
	suiteType = 'StaticTestSuite'
	name = $suiteName
} | ConvertTo-Json

$createdSuite = Invoke-RestMethod -Method Post -Uri $createSuiteUri -Headers $headers -ContentType 'application/json' -Body $createSuiteBody
if ($null -eq $createdSuite -or $null -eq $createdSuite.id) {
	throw 'Failed to create temporary suite.'
}

$suiteId = [string]$createdSuite.id
$addTestCaseUri = "$collectionUri/$project/_apis/test/Plans/$PlanId/suites/$suiteId/testcases/$TestCaseId?api-version=7.1-preview.2"
$null = Invoke-RestMethod -Method Post -Uri $addTestCaseUri -Headers $headers

Write-Host "##vso[task.setvariable variable=PIPELINE_SINGLE_CASE_SUITE_ID]$suiteId"
Write-Host "Created temporary suite $suiteId and added test case $TestCaseId."
