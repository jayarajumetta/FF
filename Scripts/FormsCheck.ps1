<#
.SYNOPSIS
    Forms Validation — Standalone PowerShell runner.
    Validates a DuckCreek FormsEngine XML response against a CSV baseline.

.DESCRIPTION
    Modernised replacement for the legacy Tosca FormsCheckQA.ps1.

    Improvements over the original:
      - Supports merged single-CSV-per-LOB format with Type column filtering
      - Human-readable messages alongside C1-C15 codes
      - Color-coded console output
      - Self-contained HTML report generation
      - Clean parameter handling (no debug mode flags)

.PARAMETER BaselinePath
    Full path to the CSV baseline file (e.g. SFP.csv or SFP_BASIC.csv).

.PARAMETER XmlPath
    Full path to the DuckCreek FormsEngine XML response file.

.PARAMETER State
    Two-letter state abbreviation (must match a CSV column).

.PARAMETER QuoteID
    Quote / policy ID (used for output file naming).

.PARAMETER TestCase
    Test case name: BASIC, CE, etc.  Drives the Type column filter.
    Default: BASIC

.PARAMETER OutputDir
    Folder for results CSV and HTML report.  Default: same folder as BaselinePath.

.EXAMPLE
    .\FormsCheck.ps1 -BaselinePath .\SFP.csv -XmlPath .\response.xml -State CO -QuoteID 777178
    .\FormsCheck.ps1 -BaselinePath .\SFP.csv -XmlPath .\response.xml -State TX -QuoteID 123456 -TestCase CE
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory)][string]$BaselinePath,
    [Parameter(Mandatory)][string]$XmlPath,
    [Parameter(Mandatory)][string]$State,
    [Parameter(Mandatory)][string]$QuoteID,
    [string]$TestCase = "BASIC",
    [string]$OutputDir = ""
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

$startTime = Get-Date
Write-Host "`n=== Forms Validation ===" -ForegroundColor Cyan
Write-Host "  Baseline : $BaselinePath"
Write-Host "  XML      : $XmlPath"
Write-Host "  State    : $State"
Write-Host "  QuoteID  : $QuoteID"
Write-Host "  TestCase : $TestCase"
Write-Host ""

# ── Resolve output directory ──────────────────────────────────────────────────
if (-not $OutputDir) { $OutputDir = Split-Path $BaselinePath -Parent }
if (-not (Test-Path $OutputDir)) { New-Item -Path $OutputDir -ItemType Directory -Force | Out-Null }

$baseName    = [System.IO.Path]::GetFileNameWithoutExtension($BaselinePath)
$resultsPath = Join-Path $OutputDir "${baseName}_${State}_${QuoteID}Results.csv"
$htmlPath    = Join-Path $OutputDir "${baseName}_${State}_${QuoteID}Report.html"

# ── Type code mapping ─────────────────────────────────────────────────────────
$typeCodeMap = @{ "BASIC" = "B"; "CE" = "C" }
$typeCode    = if ($typeCodeMap.ContainsKey($TestCase.ToUpper())) { $typeCodeMap[$TestCase.ToUpper()] } else { $TestCase.Substring(0,1).ToUpper() }
$allowedTypes = @("BASE", $typeCode)
Write-Host "  Type filter: $($allowedTypes -join ' + ')" -ForegroundColor DarkGray

# ── Status name lookups ───────────────────────────────────────────────────────
$statusNames   = @{ "YM" = "Mandatory"; "YS" = "Selected"; "YU" = "Listed (Unchecked)"; "N" = "Not Expected" }
$selectedNames = @{ 0 = "Not Checked"; 1 = "Selected"; 2 = "Mandatory (Checked)" }

function Get-StatusName($code)  { if ($statusNames.ContainsKey($code))        { $statusNames[$code] }        else { $code } }
function Get-SelectedName($val) { if ($selectedNames.ContainsKey([int]$val))   { $selectedNames[[int]$val] }  else { "selected=$val" } }

# ── Load baseline CSV with Type filtering ─────────────────────────────────────
Write-Host "Loading baseline..." -NoNewline
$rawData = Import-Csv $BaselinePath

$hasTypeColumn = ($rawData | Get-Member -Name "Type" -MemberType NoteProperty) -ne $null
if ($hasTypeColumn) {
    $filtered = $rawData | Where-Object { $allowedTypes -contains $_.Type }
} else {
    $filtered = $rawData
}

$expectedForms = [ordered]@{}
foreach ($row in $filtered) {
    $formName = $row.Form.Trim()
    $stateVal = if ($row.PSObject.Properties.Name -contains $State) { $row.$State.Trim().ToUpper() } else { "" }
    if ($formName -and -not $expectedForms.Contains($formName)) {
        $expectedForms[$formName] = @{ Form = $formName; Expected = $stateVal }
    }
}
Write-Host " $($expectedForms.Count) forms loaded" -ForegroundColor Green

# ── Load XML response ─────────────────────────────────────────────────────────
Write-Host "Loading XML response..." -NoNewline
if (-not (Test-Path $XmlPath)) { throw "XML file not found: $XmlPath" }
[xml]$xml = Get-Content -Path $XmlPath
$policyForms = $xml.server.responses.'FormsEngine.initPrintJobRs'.printJob.printDoc

$actualLookup = @{}
foreach ($pf in $policyForms) { $actualLookup[$pf.name] = [int]$pf.selected }
Write-Host " $($actualLookup.Count) forms on policy" -ForegroundColor Green

# ── Validation engine ─────────────────────────────────────────────────────────
$results = [System.Collections.Generic.List[psobject]]::new()
$pass = 0; $fail = 0; $info = 0; $issue = 0

function Add-Result($form, $expected, $actualSel, $result, $code, $message) {
    $actualText = if ($actualSel -ge 0) { Get-SelectedName $actualSel } else { "Not On Policy" }
    $obj = [PSCustomObject]@{
        Form     = $form
        Expected = $expected
        Actual   = $actualText
        Result   = $result
        Code     = $code
        Message  = $message
    }
    $results.Add($obj)

    $color = switch ($result) { "FAIL" { "Red" } "ISSUE" { "Yellow" } "INFO" { "DarkCyan" } default { "DarkGray" } }
    if ($result -ne "PASS") {
        Write-Host "  [$result] $form - $message" -ForegroundColor $color
    }

    switch ($result) {
        "PASS"  { $script:pass++  }
        "FAIL"  { $script:fail++  }
        "INFO"  { $script:info++  }
        "ISSUE" { $script:issue++ }
    }
}

Write-Host "`nValidating..." -ForegroundColor Cyan

# Phase 1 — Check each expected form against the policy
foreach ($formName in $expectedForms.Keys) {
    $exp       = $expectedForms[$formName]
    $expStatus = $exp.Expected
    $expDesc   = Get-StatusName $expStatus

    if ($actualLookup.ContainsKey($formName)) {
        $sel     = $actualLookup[$formName]
        $actDesc = Get-SelectedName $sel

        switch ("$expStatus|$sel") {
            "YM|2"  { Add-Result $formName $expStatus $sel "PASS"  "C1"  "Expected $expDesc, found $actDesc" }
            "YM|1"  { Add-Result $formName $expStatus $sel "PASS"  "C2"  "Expected $expDesc, found $actDesc (not flagged mandatory but checked)" }
            "YS|1"  { Add-Result $formName $expStatus $sel "PASS"  "C3"  "Expected $expDesc, found $actDesc" }
            "YS|0"  { Add-Result $formName $expStatus $sel "FAIL"  "C4"  "Expected $expDesc, but form is $actDesc" }
            "N|2"   { Add-Result $formName $expStatus $sel "FAIL"  "C5"  "Expected $expDesc, but form is present and $actDesc" }
            "YM|0"  { Add-Result $formName $expStatus $sel "FAIL"  "C6"  "Expected $expDesc, but form is $actDesc" }
            "N|0"   { Add-Result $formName $expStatus $sel "FAIL"  "C7"  "Expected $expDesc, but form is present on policy (unchecked)" }
            "YU|0"  { Add-Result $formName $expStatus $sel "PASS"  "C8"  "Expected $expDesc, found $actDesc - correctly listed but unchecked" }
            "N|1"   { Add-Result $formName $expStatus $sel "FAIL"  "C9"  "Expected $expDesc, but form is present and $actDesc" }
            default { Add-Result $formName $expStatus $sel "ISSUE" "C10" "Unexpected combination: expected=$expStatus, actual selected=$sel" }
        }
    }
    else {
        switch ($expStatus) {
            { $_ -in "YM","YS","YU" } { Add-Result $formName $expStatus -1 "FAIL"  "C11" "Expected $expDesc, but form is missing from policy entirely" }
            "N"                        { Add-Result $formName $expStatus -1 "PASS"  "C12" "Correctly absent - expected $expDesc and form is not on policy" }
            default                    { Add-Result $formName $expStatus -1 "ISSUE" "C13" "Unknown expected status '$expStatus' and form is not on policy" }
        }
    }
}

# Phase 2 — Unexpected forms (on policy but not in baseline)
foreach ($pf in $policyForms) {
    if (-not $expectedForms.Contains($pf.name)) {
        $sel     = [int]$pf.selected
        $actDesc = Get-SelectedName $sel
        $code    = if ($sel -eq 2) { "C14" } else { "C15" }
        Add-Result $pf.name "" $sel "INFO" $code "Not in baseline but found on policy as $actDesc"
    }
}

$total = $results.Count

# ── Console summary ───────────────────────────────────────────────────────────
Write-Host ""
Write-Host ("=" * 60) -ForegroundColor Cyan
Write-Host "  FORMS VALIDATION: $State / Quote $QuoteID" -ForegroundColor Cyan
Write-Host ("=" * 60) -ForegroundColor Cyan
$summaryColor = if ($fail -eq 0 -and $issue -eq 0) { "Green" } else { "Red" }
Write-Host "  Total: $total   PASS: $pass   FAIL: $fail   INFO: $info   ISSUE: $issue" -ForegroundColor $summaryColor
Write-Host ("=" * 60) -ForegroundColor Cyan

# ── Save results CSV ──────────────────────────────────────────────────────────
$results | Export-Csv $resultsPath -NoTypeInformation -Encoding UTF8
Write-Host "`nResults CSV : $resultsPath" -ForegroundColor DarkGray

# ── Generate HTML report ──────────────────────────────────────────────────────
$bannerClass = if ($fail -eq 0 -and $issue -eq 0) { "banner-pass" } else { "banner-fail" }
$bannerText  = if ($fail -eq 0 -and $issue -eq 0) { "ALL PASSED" } else { "FAILURES DETECTED" }

$tableRows = ""
foreach ($r in $results) {
    $rowClass   = switch ($r.Result) { "FAIL" { "row-fail" } "ISSUE" { "row-issue" } "INFO" { "row-info" } default { "row-pass" } }
    $badgeClass = $r.Result.ToLower()
    $tableRows += @"
<tr class="$rowClass">
  <td>$([System.Net.WebUtility]::HtmlEncode($r.Form))</td>
  <td>$([System.Net.WebUtility]::HtmlEncode($r.Expected))</td>
  <td>$([System.Net.WebUtility]::HtmlEncode($r.Actual))</td>
  <td><span class="badge badge-$badgeClass">$($r.Result)</span></td>
  <td>$($r.Code)</td>
  <td>$([System.Net.WebUtility]::HtmlEncode($r.Message))</td>
</tr>
"@
}

$timestamp = (Get-Date).ToString("yyyy-MM-dd HH:mm:ss")
$htmlContent = @"
<!DOCTYPE html>
<html lang="en"><head><meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>Forms Validation - $State / $QuoteID</title>
<style>
* { box-sizing: border-box; margin: 0; padding: 0; }
body { font-family: 'Segoe UI', system-ui, sans-serif; padding: 24px; background: #f4f6f8; color: #1a1a1a; }
h1 { font-size: 1.8rem; margin-bottom: 4px; }
.subtitle { color: #555; margin-bottom: 16px; }
.banner { padding: 14px 20px; border-radius: 8px; margin-bottom: 24px; display: flex; justify-content: space-between; align-items: center; }
.banner-pass { background: #d4edda; border: 1px solid #28a745; }
.banner-fail { background: #f8d7da; border: 1px solid #dc3545; }
.banner-status { font-weight: 700; font-size: 1.1rem; }
.banner-detail { font-size: 0.95rem; }
.cards { display: flex; gap: 12px; margin-bottom: 16px; flex-wrap: wrap; }
.card { border-radius: 8px; padding: 12px 20px; min-width: 100px; text-align: center; }
.card-value { font-size: 1.6rem; font-weight: 700; }
.card-label { font-size: 0.85rem; color: #555; }
.card-total { background: #e9ecef; } .card-pass { background: #d4edda; }
.card-fail { background: #f8d7da; } .card-info { background: #d1ecf1; } .card-issue { background: #fff3cd; }
table { width: 100%; border-collapse: collapse; font-size: 0.88rem; margin-top: 16px; }
thead th { background: #343a40; color: #fff; padding: 8px 10px; text-align: left; position: sticky; top: 0; }
tbody td { padding: 6px 10px; border-bottom: 1px solid #dee2e6; }
.row-fail { background: #fff0f0; } .row-issue { background: #fff9e6; } .row-info { background: #f0f8ff; } .row-pass { background: #fff; }
.badge { padding: 2px 8px; border-radius: 4px; font-weight: 600; font-size: 0.8rem; }
.badge-pass { background: #28a745; color: #fff; } .badge-fail { background: #dc3545; color: #fff; }
.badge-info { background: #17a2b8; color: #fff; } .badge-issue { background: #ffc107; color: #000; }
footer { text-align: center; color: #888; font-size: 0.8rem; margin-top: 24px; padding: 12px; }
</style></head><body>
<h1>Forms Validation Report</h1>
<p class="subtitle">Baseline: <strong>$([System.IO.Path]::GetFileName($BaselinePath))</strong> | State: <strong>$State</strong> | Quote: <strong>$QuoteID</strong> | TestCase: <strong>$TestCase</strong> | Generated: $timestamp</p>
<div class="banner $bannerClass">
  <span class="banner-status">$bannerText</span>
  <span class="banner-detail">Total: $total &bull; Pass: $pass &bull; Fail: $fail &bull; Info: $info &bull; Issue: $issue</span>
</div>
<div class="cards">
  <div class="card card-total"><div class="card-value">$total</div><div class="card-label">Total</div></div>
  <div class="card card-pass"><div class="card-value">$pass</div><div class="card-label">Pass</div></div>
  <div class="card $(if ($fail -gt 0) { 'card-fail' } else { 'card-pass' })"><div class="card-value">$fail</div><div class="card-label">Fail</div></div>
  <div class="card card-info"><div class="card-value">$info</div><div class="card-label">Info</div></div>
  <div class="card $(if ($issue -gt 0) { 'card-issue' } else { 'card-pass' })"><div class="card-value">$issue</div><div class="card-label">Issue</div></div>
</div>
<table>
<thead><tr><th>Form</th><th>Expected</th><th>Actual</th><th>Result</th><th>Code</th><th>Message</th></tr></thead>
<tbody>
$tableRows
</tbody></table>
<footer>Generated by PnC Test Automation &mdash; FormsCheck.ps1</footer>
</body></html>
"@

[System.IO.File]::WriteAllText($htmlPath, $htmlContent)
Write-Host "HTML report : $htmlPath" -ForegroundColor DarkGray

# ── Copy summary to clipboard ────────────────────────────────────────────────
$summaryText = "Total: $total | PASS: $pass | FAIL: $fail | INFO: $info | ISSUE: $issue"
try { $summaryText | Set-Clipboard } catch { }

$elapsed = (Get-Date) - $startTime
Write-Host "`nCompleted in $($elapsed.TotalSeconds.ToString('F1'))s" -ForegroundColor DarkGray

