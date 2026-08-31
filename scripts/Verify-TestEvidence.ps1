# Test Evidence Diagnostic Script
# Run this after a test execution to verify evidence collection and attachments

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "TEST EVIDENCE DIAGNOSTIC TOOL" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Check Artifacts directory
Write-Host "1. Checking Artifacts directory..." -ForegroundColor Yellow
if (Test-Path "Artifacts") {
	$scenarios = Get-ChildItem -Path "Artifacts" -Recurse -Directory | Where-Object { $_.Parent.Name -ne "Artifacts" }
	Write-Host "   Found $($scenarios.Count) scenario artifact directories" -ForegroundColor Green

	foreach ($scenario in $scenarios | Select-Object -First 5) {
		Write-Host "   - $($scenario.FullName)" -ForegroundColor Gray

		# Check for key evidence files
		$screenshots = Get-ChildItem -Path $scenario.FullName -Filter "*.png" -Recurse -ErrorAction SilentlyContinue
		$videos = Get-ChildItem -Path $scenario.FullName -Filter "*.webm" -Recurse -ErrorAction SilentlyContinue
		$logs = Get-ChildItem -Path $scenario.FullName -Filter "*.log" -ErrorAction SilentlyContinue
		$htmlReports = Get-ChildItem -Path $scenario.FullName -Filter "report.html" -ErrorAction SilentlyContinue
		$traces = Get-ChildItem -Path $scenario.FullName -Filter "trace.zip" -ErrorAction SilentlyContinue

		Write-Host "     Screenshots: $($screenshots.Count)" -ForegroundColor $(if ($screenshots.Count -gt 0) { "Green" } else { "Red" })
		Write-Host "     Videos: $($videos.Count)" -ForegroundColor $(if ($videos.Count -gt 0) { "Green" } else { "Red" })
		Write-Host "     Logs: $($logs.Count)" -ForegroundColor $(if ($logs.Count -gt 0) { "Green" } else { "Red" })
		Write-Host "     HTML Report: $($htmlReports.Count)" -ForegroundColor $(if ($htmlReports.Count -gt 0) { "Green" } else { "Red" })
		Write-Host "     Trace: $($traces.Count)" -ForegroundColor $(if ($traces.Count -gt 0) { "Green" } else { "Red" })
	}
} else {
	Write-Host "   Artifacts directory not found!" -ForegroundColor Red
}

Write-Host ""

# Check TestResults directory
Write-Host "2. Checking TestResults/TestEvidence directory..." -ForegroundColor Yellow
if (Test-Path "TestResults/TestEvidence") {
	$testEvidence = Get-ChildItem -Path "TestResults/TestEvidence" -Directory
	Write-Host "   Found $($testEvidence.Count) test evidence staging directories" -ForegroundColor Green

	foreach ($evidence in $testEvidence | Select-Object -First 5) {
		Write-Host "   - $($evidence.Name)" -ForegroundColor Gray

		# Check for attachment result
		$resultFile = Join-Path $evidence.FullName "nunit-attachment-result.json"
		if (Test-Path $resultFile) {
			$result = Get-Content $resultFile | ConvertFrom-Json
			Write-Host "     Attached: $($result.attachedCount)" -ForegroundColor $(if ($result.attachedCount -gt 0) { "Green" } else { "Red" })
			Write-Host "     Skipped: $($result.skippedCount)" -ForegroundColor $(if ($result.skippedCount -eq 0) { "Green" } else { "Yellow" })
			Write-Host "     Failed: $($result.failedCount)" -ForegroundColor $(if ($result.failedCount -eq 0) { "Green" } else { "Red" })

			if ($result.failedCount -gt 0) {
				Write-Host "     Failure details:" -ForegroundColor Red
				foreach ($failure in $result.failures | Select-Object -First 3) {
					Write-Host "       - $failure" -ForegroundColor Red
				}
			}
		} else {
			Write-Host "     nunit-attachment-result.json NOT FOUND" -ForegroundColor Red
		}
	}
} else {
	Write-Host "   TestResults/TestEvidence directory not found!" -ForegroundColor Red
	Write-Host "   This means NUnit evidence publisher did not run or failed to create staging directories." -ForegroundColor Yellow
}

Write-Host ""

# Summary
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "DIAGNOSTIC SUMMARY" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan

if (Test-Path "Artifacts") {
	$totalScreenshots = (Get-ChildItem -Path "Artifacts" -Filter "*.png" -Recurse -ErrorAction SilentlyContinue).Count
	$totalVideos = (Get-ChildItem -Path "Artifacts" -Filter "*.webm" -Recurse -ErrorAction SilentlyContinue).Count
	$totalLogs = (Get-ChildItem -Path "Artifacts" -Filter "*.log" -Recurse -ErrorAction SilentlyContinue).Count
	$totalReports = (Get-ChildItem -Path "Artifacts" -Filter "report.html" -Recurse -ErrorAction SilentlyContinue).Count

	Write-Host "Total Screenshots Collected: $totalScreenshots" -ForegroundColor $(if ($totalScreenshots -gt 0) { "Green" } else { "Red" })
	Write-Host "Total Videos Collected: $totalVideos" -ForegroundColor $(if ($totalVideos -gt 0) { "Green" } else { "Red" })
	Write-Host "Total Logs Collected: $totalLogs" -ForegroundColor $(if ($totalLogs -gt 0) { "Green" } else { "Red" })
	Write-Host "Total HTML Reports: $totalReports" -ForegroundColor $(if ($totalReports -gt 0) { "Green" } else { "Red" })
}

Write-Host ""
Write-Host "Next Steps:" -ForegroundColor Yellow
Write-Host "1. Run a test and check the test output for [EVIDENCE PUBLISHER], [EVIDENCE VALIDATION], and [TEST EVIDENCE SUMMARY] messages" -ForegroundColor White
Write-Host "2. Look for [TEST EVIDENCE ATTACHED] or [ATTACHMENT FAILED] messages for each file" -ForegroundColor White
Write-Host "3. In Visual Studio Test Explorer, right-click a test > View Test Log to see attachments" -ForegroundColor White
Write-Host "4. Check the Artifacts directory manually to verify files are being created" -ForegroundColor White
Write-Host ""
