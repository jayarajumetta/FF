<#
.SYNOPSIS
    DuckCreek Manuscript Scanner — discovers which manuscript+printjob combinations
    return forms for a given policy session, and probes the CLAS REST API for form lists.

.DESCRIPTION
    Two discovery modes run together:

    1. DuckCreek XML probe  — POSTs Session.resumeRq + FormsEngine.initPrintJobRq
       to http://svqw-clas21:8080/duckcreek/dctserver.aspx for every combination
       of known manuscript × print-job names, recording how many forms are returned.

    2. CLAS REST probe — GETs /Express/api/v1/forms (and related endpoints)
       using the DuckCreek SessionId as a request header, similar to how the
       browser calls them when rendering the Forms Preview.

    Results are written to the console (color-coded) and saved to a JSON + HTML file.

.PARAMETER SessionId
    The value of the DuckCreek_SessionId cookie (colon-separated hex).
    If omitted, the script will attempt to read it from the most recent
    test-run output in TestResults\FormsCheck.

.PARAMETER PolicyId
    The CLAS encoded policy ID for REST probes.
    Visible in the Network tab as the PolicyId query parameter.
    Example: k6Y4WLgW50Oj5ODM4MzU1K0LzdLvvg

.PARAMETER HistoryId
    The CLAS HistoryId (transaction ID) for REST probes.
    Visible in the Network tab as the HistoryId query parameter.

.PARAMETER QuoteId
    Plain quote number (used only for labelling output).

.PARAMETER DuckCreekUrl
    DuckCreek Forms Engine endpoint. Default: http://svqw-clas21:8080/duckcreek/dctserver.aspx

.PARAMETER DuckCreekUser
    Basic-auth username for DuckCreek. Default: PA3402

.PARAMETER DuckCreekPass
    Basic-auth password for DuckCreek. Default: Cl212689

.PARAMETER CLASBaseUrl
    CLAS Express base URL. Default: https://clasq.anico.com

.PARAMETER OutputDir
    Where to save JSON + HTML results. Default: TestResults\ManuscriptScan

.EXAMPLE
    .\ManuscriptScanner.ps1 -SessionId "CF917025:68A14345:AA960FD8:906B5CBC:7A35D507:48E90C44" `
                             -PolicyId "k6Y4WLgW50Oj5ODM4MzU1K0LzdLvvg" `
                             -HistoryId "3167651" `
                             -QuoteId "01918753"

.EXAMPLE
    # SessionId only (no REST probe)
    .\ManuscriptScanner.ps1 -SessionId "CF917025:68A14345:AA960FD8:906B5CBC:7A35D507:48E90C44"
#>

[CmdletBinding()]
param(
    [string]$SessionId    = "",
    [string]$PolicyId     = "",
    [string]$HistoryId    = "",
    [string]$QuoteId      = "unknown",
    [string]$DuckCreekUrl = "http://svqw-clas21:8080/duckcreek/dctserver.aspx",
    [string]$DuckCreekUser = "PA3402",
    [string]$DuckCreekPass = "Cl212689",
    [string]$CLASBaseUrl   = "https://clasq.anico.com",
    [string]$OutputDir     = "TestResults\ManuscriptScan"
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

# ─────────────────────────────────────────────────────────────────────────────
#  CONFIGURATION — edit these lists to add/remove candidates
# ─────────────────────────────────────────────────────────────────────────────

$Manuscripts = @(
    "Carrier_CommercialLines_Forms_US_4_0_0_0",
    "Carrier_CommercialLines_Forms_Multistate_4_0_0_0",
    "Carrier_PersonalLines_Forms_US_4_0_0_0",
    "Carrier_PersonalLines_Forms_Multistate_4_0_0_0",
    "Carrier_Interline_Forms_US_4_0_0_0",
    "Carrier_Interline_Forms_Multistate_4_0_0_0",
    "Carrier_SpecialFarmPackage_Forms_US_4_0_0_0",
    "Carrier_SpecialFarmPackage_Forms_Multistate_4_0_0_0",
    "Carrier_Farm_Forms_US_4_0_0_0",
    "Carrier_Farm_Forms_Multistate_4_0_0_0",
    "Carrier_FarmOwners_Forms_US_4_0_0_0",
    "Carrier_BusinessOwners_Forms_US_4_0_0_0",
    "Carrier_SpecialtyLines_Forms_US_4_0_0_0",
    "Carrier_Umbrella_Forms_US_4_0_0_0",
    "Carrier_WorkersComp_Forms_US_4_0_0_0"
)

$PrintJobs = @(
    "TransactionPrint",
    "FormsPreview",
    "Print",
    "FormsList",
    "PolicyPrint",
    "FullPolicyPrint",
    "NewBusinessPrint",
    "IssuePrint",
    "BinderPrint",
    "RenewalPrint",
    "EndorsementPrint",
    "CancellationPrint",
    "ApplicationPrint",
    "QuotePrint",
    "DeclarationPrint",
    "ProposalPrint",
    "PackagePrint",
    "AllForms"
)

# CLAS REST API paths to probe (GET)
$CLASRestPaths = @(
    "/Express/api/v1/forms",
    "/Express/api/v1/forms/list",
    "/Express/api/v1/policy/forms",
    "/Express/api/v1/formslist",
    "/Express/api/v1/documents",
    "/Express/api/v1/documents/list",
    "/Express/api/v1/printjobs"
)

# ─────────────────────────────────────────────────────────────────────────────
#  HELPERS
# ─────────────────────────────────────────────────────────────────────────────

function Get-DuckCreekAuth {
    $bytes = [System.Text.Encoding]::ASCII.GetBytes("${DuckCreekUser}:${DuckCreekPass}")
    return "Basic " + [Convert]::ToBase64String($bytes)
}

function Invoke-DuckCreekXml([string]$xml) {
    $auth = Get-DuckCreekAuth
    try {
        $resp = Invoke-WebRequest -Uri $DuckCreekUrl -Method POST `
            -Headers @{ Authorization = $auth } `
            -Body $xml -ContentType "text/xml" `
            -UseBasicParsing -TimeoutSec 15
        return $resp.Content
    } catch {
        if ($_.Exception.Response) {
            $stream = $_.Exception.Response.GetResponseStream()
            $reader = New-Object System.IO.StreamReader($stream)
            return $reader.ReadToEnd()
        }
        return "ERROR: $($_.Exception.Message)"
    }
}

function Count-Forms([string]$xml) {
    return ([regex]::Matches($xml, "printDoc")).Count
}

function Get-FormNames([string]$xml) {
    $matches = [regex]::Matches($xml, 'printDoc[^>]+name="([^"]+)"')
    return $matches | ForEach-Object { $_.Groups[1].Value } | Sort-Object -Unique
}

function Get-ErrorMessage([string]$xml) {
    $m = [regex]::Match($xml, '<error[^>]*>([^<]+)</error>')
    if ($m.Success) { return $m.Groups[1].Value }
    $m = [regex]::Match($xml, 'status="failure"[^>]*/?>(.{0,200})', [System.Text.RegularExpressions.RegexOptions]::Singleline)
    if ($m.Success) { return ($m.Groups[1].Value -replace '<[^>]+>', ' ').Trim() }
    return "(no error message)"
}

function Write-Banner([string]$text) {
    $line = "=" * 70
    Write-Host "`n$line" -ForegroundColor Cyan
    Write-Host "  $text" -ForegroundColor Cyan
    Write-Host "$line" -ForegroundColor Cyan
}

# ─────────────────────────────────────────────────────────────────────────────
#  RESOLVE SESSION ID
# ─────────────────────────────────────────────────────────────────────────────

if (-not $SessionId) {
    # Try to find the most recent saved XML and extract a valid-looking session from it
    $xmlFiles = Get-ChildItem "TestResults\FormsCheck" -Recurse -Filter "*.xml" -ErrorAction SilentlyContinue |
        Sort-Object LastWriteTime -Descending | Select-Object -First 5
    foreach ($f in $xmlFiles) {
        $content = Get-Content $f.FullName -Raw
        $m = [regex]::Match($content, 'sessionID="([A-F0-9:]{47})"')
        if ($m.Success) {
            $SessionId = $m.Groups[1].Value
            Write-Host "[AutoDetect] Found SessionId in $($f.Name): $SessionId" -ForegroundColor Yellow
            break
        }
    }
}

if (-not $SessionId) {
    Write-Host "ERROR: No SessionId provided and none found in recent test results." -ForegroundColor Red
    Write-Host "  Run the test once first, then pass -SessionId from the test output." -ForegroundColor Yellow
    exit 1
}

Write-Host "`nManuscript Scanner" -ForegroundColor Green
Write-Host "  Session : $SessionId"
Write-Host "  Quote   : $QuoteId"
Write-Host "  Probing : $($Manuscripts.Count) manuscripts × $($PrintJobs.Count) print jobs = $($Manuscripts.Count * $PrintJobs.Count) combinations"

# ─────────────────────────────────────────────────────────────────────────────
#  OUTPUT SETUP
# ─────────────────────────────────────────────────────────────────────────────

$timestamp = Get-Date -Format "yyyyMMdd_HHmmss"
$null = New-Item -ItemType Directory -Path $OutputDir -Force
$reportPath = Join-Path $OutputDir "ManuscriptScan_${QuoteId}_${timestamp}.html"
$jsonPath   = Join-Path $OutputDir "ManuscriptScan_${QuoteId}_${timestamp}.json"

$allResults      = [System.Collections.Generic.List[object]]::new()
$workingCombos   = [System.Collections.Generic.List[object]]::new()

# ─────────────────────────────────────────────────────────────────────────────
#  PHASE 1 — DuckCreek XML Probe
# ─────────────────────────────────────────────────────────────────────────────

Write-Banner "Phase 1 — DuckCreek XML Probe (dctserver.aspx)"

$totalCombos   = $Manuscripts.Count * $PrintJobs.Count
$doneCount     = 0

foreach ($ms in $Manuscripts) {
    $msShort = $ms -replace "^Carrier_" -replace "_Forms_.+$"
    $msResults = [System.Collections.Generic.List[object]]::new()

    foreach ($pj in $PrintJobs) {
        $doneCount++
        $xml = "<server><requests>" +
               "<Session.resumeRq sessionID=`"$SessionId`" />" +
               "<FormsEngine.initPrintJobRq manuscript=`"$ms`" printJob=`"$pj`" forceInit=`"1`" />" +
               "</requests></server>"

        $body       = Invoke-DuckCreekXml $xml
        $formCount  = Count-Forms $body
        $isSuccess  = $formCount -gt 0
        $formNames  = if ($isSuccess) { Get-FormNames $body } else { @() }
        $errMsg     = if (-not $isSuccess) { Get-ErrorMessage $body } else { "" }

        $row = [pscustomobject]@{
            Source     = "DuckCreek"
            Manuscript = $ms
            PrintJob   = $pj
            FormCount  = $formCount
            Success    = $isSuccess
            FormNames  = $formNames
            Error      = $errMsg
        }
        $allResults.Add($row)
        $msResults.Add($row)

        if ($isSuccess) {
            $workingCombos.Add($row)
            Write-Host ("  [{0,4}/{1}] ** SUCCESS ** {2} + {3} → {4} forms" -f `
                $doneCount, $totalCombos, $msShort, $pj, $formCount) -ForegroundColor Green
        } else {
            # Classify the error for brevity
            $label = if ($errMsg -match "not found in the ManuScript")      { "NotInMs" }
                     elseif ($errMsg -match "does not exist")                { "MsNotExist" }
                     elseif ($errMsg -match "session.*invalid|resumeRs.*fail") { "SessionDead" }
                     elseif ($errMsg -match "XPathException|Expression must") { "XPathError" }
                     elseif ($errMsg -match "ERROR:")                        { "NetworkErr" }
                     else                                                    { "Failed" }

            Write-Host ("  [{0,4}/{1}]   {2} + {3} → {4}" -f `
                $doneCount, $totalCombos, $msShort, $pj, $label) -ForegroundColor DarkGray

            # If session is dead, abort early
            if ($label -eq "SessionDead") {
                Write-Host "`n  Session has expired. Provide a fresh -SessionId." -ForegroundColor Red
                break
            }
        }
    }

    # Show per-manuscript summary only if something worked
    $msWorking = $msResults | Where-Object Success
    if ($msWorking) {
        $best = $msWorking | Sort-Object FormCount -Descending | Select-Object -First 1
        Write-Host ("  └─ {0}: best={1} ({2} forms)" -f $msShort, $best.PrintJob, $best.FormCount) -ForegroundColor Yellow
    }
}

# ─────────────────────────────────────────────────────────────────────────────
#  PHASE 2 — CLAS REST API Probe
# ─────────────────────────────────────────────────────────────────────────────

Write-Banner "Phase 2 — CLAS REST API Probe"
$restResults = [System.Collections.Generic.List[object]]::new()

# Build the common headers CLAS uses (from DevTools capture)
$clasHeaders = @{
    "SessionId"       = $SessionId
    "StateFul"        = "1"
    "X-Requested-With" = "XMLHttpRequest"
    "Accept"          = "application/json, text/plain, */*"
}

# Add cookie header if we can
$clasHeaders["Cookie"] = "DuckCreek_SessionId=$SessionId"

# Build query strings to try
$queryVariants = [System.Collections.Generic.List[string]]::new()
$queryVariants.Add("")   # bare path
if ($PolicyId)  { $queryVariants.Add("?PolicyId=$PolicyId") }
if ($PolicyId -and $HistoryId) {
    $queryVariants.Add("?PolicyId=$PolicyId&HistoryId=$HistoryId")
    foreach ($ms in @("Carrier_CommercialLines_Forms_US_4_0_0_0",
                      "Carrier_Interline_Forms_US_4_0_0_0",
                      "Carrier_SpecialFarmPackage_Forms_Multistate_4_0_0_0")) {
        $queryVariants.Add("?PolicyId=$PolicyId&Product=$ms&HistoryId=$HistoryId")
    }
}

foreach ($path in $CLASRestPaths) {
    foreach ($qs in $queryVariants) {
        $url = "$CLASBaseUrl$path$qs"
        try {
            $resp = Invoke-WebRequest -Uri $url -Method GET -Headers $clasHeaders `
                -UseBasicParsing -TimeoutSec 10 -ErrorAction SilentlyContinue
            $status = $resp.StatusCode
            $bodyLen = $resp.Content.Length
            $bodySnip = $resp.Content.Substring(0, [Math]::Min(300, $bodyLen))

            # Try to parse JSON
            $isJson = $resp.Content.TrimStart().StartsWith("[") -or $resp.Content.TrimStart().StartsWith("{")
            $formCount = 0
            if ($isJson) {
                try {
                    $parsed = $resp.Content | ConvertFrom-Json
                    if ($parsed -is [array]) { $formCount = $parsed.Count }
                    elseif ($parsed.forms) { $formCount = $parsed.forms.Count }
                    elseif ($parsed.Forms) { $formCount = $parsed.Forms.Count }
                } catch { }
            }

            $label = if ($status -eq 200 -and $bodyLen -gt 100) { "** $status — ${bodyLen}b, forms=$formCount **" }
                     else { "$status — ${bodyLen}b" }

            if ($status -eq 200 -and $bodyLen -gt 100) {
                Write-Host "  $label  $url" -ForegroundColor Green
            } else {
                Write-Host "  $label  $path$qs" -ForegroundColor DarkGray
            }

            $restResults.Add([pscustomobject]@{
                Url       = $url
                Status    = $status
                BodyBytes = $bodyLen
                FormCount = $formCount
                IsJson    = $isJson
                Snippet   = $bodySnip
            })
        } catch {
            $errCode = if ($_.Exception.Response) { [int]$_.Exception.Response.StatusCode } else { 0 }
            Write-Host "  $errCode  $path$qs" -ForegroundColor DarkGray
            $restResults.Add([pscustomobject]@{
                Url       = "$CLASBaseUrl$path$qs"
                Status    = $errCode
                BodyBytes = 0
                FormCount = 0
                IsJson    = $false
                Snippet   = $_.Exception.Message
            })
        }
    }
}

# ─────────────────────────────────────────────────────────────────────────────
#  SUMMARY
# ─────────────────────────────────────────────────────────────────────────────

Write-Banner "Summary — Working Combinations"

if ($workingCombos.Count -eq 0) {
    Write-Host "  No working combinations found." -ForegroundColor Red
    Write-Host "  The session may have expired during probing." -ForegroundColor Yellow
} else {
    $workingCombos | Sort-Object FormCount -Descending | Format-Table -AutoSize @(
        @{L="Manuscript"; E={ ($_.Manuscript -replace "^Carrier_" -replace "_Forms_.+$") }},
        @{L="PrintJob";   E={ $_.PrintJob }},
        @{L="Forms";      E={ $_.FormCount }}
    )

    # Show unique form names found across all working combos
    $allFormNames = $workingCombos | ForEach-Object { $_.FormNames } | Sort-Object -Unique
    Write-Host "  Total unique forms across all working combos: $($allFormNames.Count)" -ForegroundColor Cyan
}

# ─────────────────────────────────────────────────────────────────────────────
#  SAVE JSON
# ─────────────────────────────────────────────────────────────────────────────

$report = @{
    Timestamp    = $timestamp
    QuoteId      = $QuoteId
    SessionId    = $SessionId
    Working      = $workingCombos
    AllResults   = $allResults
    RestResults  = $restResults
}
$report | ConvertTo-Json -Depth 10 | Set-Content $jsonPath -Encoding UTF8
Write-Host "`n  JSON saved: $jsonPath" -ForegroundColor Cyan

# ─────────────────────────────────────────────────────────────────────────────
#  SAVE HTML REPORT
# ─────────────────────────────────────────────────────────────────────────────

$workingRows = $workingCombos | Sort-Object FormCount -Descending | ForEach-Object {
    $msShort = $_.Manuscript -replace "^Carrier_" -replace "_Forms_.+$"
    $formList = ($_.FormNames | Select-Object -First 20) -join ", "
    $more = if ($_.FormNames.Count -gt 20) { " …+$($_.FormNames.Count - 20) more" } else { "" }
    "<tr class='ok'><td>$msShort</td><td>$($_.PrintJob)</td><td>$($_.FormCount)</td><td class='forms'>$formList$more</td></tr>"
}

$failRows = $allResults | Where-Object { -not $_.Success } | Group-Object Manuscript | ForEach-Object {
    $msShort = $_.Name -replace "^Carrier_" -replace "_Forms_.+$"
    $codes = $_.Group | ForEach-Object {
        $label = if ($_.Error -match "not found") { "NotInMs" }
                 elseif ($_.Error -match "does not exist") { "MsNotExist" }
                 elseif ($_.Error -match "XPath") { "XPathErr" }
                 else { "Fail" }
        $label
    } | Sort-Object -Unique
    "<tr><td>$msShort</td><td colspan='3'>All $($_.Count) print jobs failed: $($codes -join ', ')</td></tr>"
}

$html = @"
<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<title>Manuscript Scan — $QuoteId — $timestamp</title>
<style>
  body { font-family: Segoe UI, Arial, sans-serif; font-size: 13px; background:#f4f6f9; margin:20px; }
  h1 { color:#1a3a5c; }
  h2 { color:#2c5f8a; border-bottom:2px solid #2c5f8a; padding-bottom:4px; }
  table { border-collapse:collapse; width:100%; margin-bottom:24px; background:#fff; border-radius:6px; overflow:hidden; box-shadow:0 1px 4px rgba(0,0,0,.12); }
  th { background:#2c5f8a; color:#fff; padding:8px 12px; text-align:left; }
  td { padding:7px 12px; border-bottom:1px solid #e8edf2; vertical-align:top; }
  tr:last-child td { border-bottom:none; }
  tr.ok td { background:#f0faf2; }
  .forms { font-size:11px; color:#555; max-width:600px; word-break:break-all; }
  .meta { background:#fff; padding:12px 16px; border-radius:6px; margin-bottom:20px; box-shadow:0 1px 4px rgba(0,0,0,.12); }
  .meta span { font-weight:bold; }
  .badge-ok   { background:#27ae60; color:#fff; border-radius:3px; padding:1px 6px; }
  .badge-fail { background:#c0392b; color:#fff; border-radius:3px; padding:1px 6px; }
</style>
</head>
<body>
<h1>DuckCreek Manuscript Scanner</h1>
<div class="meta">
  <span>Quote:</span> $QuoteId &nbsp;|&nbsp;
  <span>Session:</span> $SessionId &nbsp;|&nbsp;
  <span>Scanned:</span> $timestamp &nbsp;|&nbsp;
  <span>Combinations tested:</span> $($allResults.Count)
</div>

<h2>Working Combinations <span class="badge-ok">$($workingCombos.Count) found</span></h2>
<table>
  <tr><th>Manuscript</th><th>Print Job</th><th>Form Count</th><th>Sample Forms</th></tr>
  $(if ($workingRows) { $workingRows -join "`n" } else { "<tr><td colspan='4'>None found — session may have expired during scan.</td></tr>" })
</table>

<h2>Failed Manuscripts <span class="badge-fail">$($Manuscripts.Count - ($workingCombos | Select-Object -ExpandProperty Manuscript -Unique).Count) with no working print job</span></h2>
<table>
  <tr><th>Manuscript</th><th colspan="3">Result</th></tr>
  $(if ($failRows) { $failRows -join "`n" } else { "<tr><td colspan='4'>All manuscripts had at least one working print job.</td></tr>" })
</table>

<h2>CLAS REST API Probe</h2>
<table>
  <tr><th>Status</th><th>Bytes</th><th>Forms</th><th>URL</th></tr>
  $(
    $restResults | Sort-Object Status | ForEach-Object {
        $cls = if ($_.Status -eq 200 -and $_.BodyBytes -gt 100) { " class='ok'" } else { "" }
        "<tr$cls><td>$($_.Status)</td><td>$($_.BodyBytes)</td><td>$($_.FormCount)</td><td>$($_.Url)</td></tr>"
    }
  )
</table>

</body>
</html>
"@

Set-Content -Path $reportPath -Value $html -Encoding UTF8
Write-Host "  HTML saved: $reportPath`n" -ForegroundColor Cyan
Write-Host "Done." -ForegroundColor Green
