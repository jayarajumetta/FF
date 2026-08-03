# ── Auth ──────────────────────────────────────────────────────────────────────
$psi = [System.Diagnostics.ProcessStartInfo]::new("git", "credential fill")
$psi.RedirectStandardInput  = $true
$psi.RedirectStandardOutput = $true
$psi.RedirectStandardError  = $true
$psi.UseShellExecute        = $false
$psi.CreateNoWindow         = $true
$proc = [System.Diagnostics.Process]::Start($psi)
$proc.StandardInput.Write("protocol=https`nhost=dev.azure.com`npath=ANCollection`n`n")
$proc.StandardInput.Close()
$credOut = $proc.StandardOutput.ReadToEnd()
$proc.WaitForExit(10000)
$pwLine = ($credOut -split "`n" | Where-Object { $_ -match '^password=' }) -replace '^password=',''
if (-not $pwLine) {
    Write-Error "Could not retrieve credentials from GCM. Run 'git push' first to prime the cache, then re-run this script."
    exit 1
}
$encoded = [Convert]::ToBase64String([Text.Encoding]::ASCII.GetBytes(":$pwLine"))
$headers = @{
    Authorization  = "Basic $encoded"
    'Content-Type' = 'application/json'
}

$org        = "ANCollection"
$project    = "PnC%20Test%20Automation"
$repo       = "PnC-TestAutomation"
$baseUri    = "https://dev.azure.com/$org/$project/_apis/git/repositories/$repo"
$apiVersion = "api-version=7.1"

$newTitle = "Fix: re-shard SFP CE tests to Shard4/5/6 — resolve 55/70 test timeout issue"
$newDesc  = @"
## What This PR Does

Fixes a pipeline timeout issue where the nightly SFP smoke run (`sfp-smoke-vm.yml`) was only completing approximately 55 of 70 tests.

### Root Cause

Both `SFP_BasicPolicy.feature` and `SFP_CE.feature` were tagged with `@Shard1/2/3`, causing both suites to compete on the same 3 shards. Each shard was loaded with up to 26 tests (~156 min at ~6 min/test), exceeding the `timeoutInMinutes: 120` job limit. Tests beyond the timeout were dropped silently.

### Fix

- **`Features/SFP/SFP_CE.feature`**: Re-tagged all Examples blocks from `@Shard1/2/3` to `@Shard4/5/6`
- **`Pipelines/sfp-smoke-vm.yml`**: Expanded the matrix from 3 shards to 6 — Shard1/2/3 now run BasicPolicy, Shard4/5/6 run CE
- **`Pipelines/sfp-smoke-adhoc.yml`**: Updated CE job filter to use `Shard4/5/6`

### Result

| | Before | After |
|---|---|---|
| Max tests per shard | 26 (~156 min) | 13 (~78 min) |
| Job timeout | 120 min | 120 min |
| Tests completing | ~55 | 70 |

With 3 parallel agents, Shards 1–3 run first (BasicPolicy), then Shards 4–6 run on the same agents (CE). All 70 tests complete well within the timeout.

## Also Included

- **`Docs/Vendor-Proposal-Analysis.md`**: Response document to Sutherland Discovery Assessment, prepared for the David & Andy meeting in early August 2026.
- **`Scripts/_create-pr.ps1`**: Utility script for PR creation.

## Pipeline Schedules

The `sfp-smoke-vm.yml` pipeline is configured to run nightly at **10:00 PM CST** and **5:00 AM CST** against the `main` branch. This PR must be completed for those schedules to pick up the 6-shard configuration.
"@

# ── Check if PR #11016 exists ─────────────────────────────────────────────────
$existingPrId = 11016
$checkUri = "$baseUri/pullrequests/$existingPrId`?$apiVersion"
try {
    $existing = Invoke-RestMethod -Uri $checkUri -Method Get -Headers $headers -ErrorAction Stop
    Write-Host "PR #$existingPrId exists (status: $($existing.status)) — updating description..."
    $patchBody = ConvertTo-Json @{ title = $newTitle; description = $newDesc } -Depth 3
    $patchUri  = "$baseUri/pullrequests/$existingPrId`?$apiVersion"
    $updated   = Invoke-RestMethod -Uri $patchUri -Method Patch -Headers $headers -Body $patchBody -ErrorAction Stop
    Write-Host "SUCCESS — updated PR #$($updated.pullRequestId)"
    Write-Host "URL: https://dev.azure.com/$org/$project/_git/$repo/pullrequest/$($updated.pullRequestId)"
} catch {
    $code = $_.Exception.Response.StatusCode.value__
    if ($code -eq 404) {
        Write-Host "PR #$existingPrId not found — creating new PR..."
        $createBody = ConvertTo-Json @{
            title         = $newTitle
            description   = $newDesc
            sourceRefName = "refs/heads/Development"
            targetRefName = "refs/heads/main"
        } -Depth 3
        $createUri = "$baseUri/pullrequests?$apiVersion"
        try {
            $r = Invoke-RestMethod -Uri $createUri -Method Post -Headers $headers -Body $createBody -ErrorAction Stop
            Write-Host "SUCCESS — created PR #$($r.pullRequestId)"
            Write-Host "URL: https://dev.azure.com/$org/$project/_git/$repo/pullrequest/$($r.pullRequestId)"
        } catch {
            Write-Host "CREATE ERROR: $($_.Exception.Message)"
            try { $s = $_.Exception.Response.GetResponseStream(); $rd = New-Object System.IO.StreamReader($s); Write-Host $rd.ReadToEnd() } catch {}
        }
    } else {
        Write-Host "GET ERROR ($code): $($_.Exception.Message)"
        try { $s = $_.Exception.Response.GetResponseStream(); $rd = New-Object System.IO.StreamReader($s); Write-Host $rd.ReadToEnd() } catch {}
    }
}
