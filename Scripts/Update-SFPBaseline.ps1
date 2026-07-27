<#
.SYNOPSIS
Promotes C14 INFO forms from SFP TRX test results into SFP.json baseline.

.DESCRIPTION
Reads one or more .trx test result files and extracts every [INFO] line that
reports "Not in baseline but found on policy as Mandatory" (result code C14).
For each such form/state pair it updates Resources\ExpectedForms\SFP\SFP.json:

  • If the form already exists in SFP.json — the state is added to its array.
  • If the form does not exist — a new entry is inserted in the appropriate
    section (BASE / BASIC / CE), determined by which test variants reported it.

The script preserves the file's exact formatting (indentation, comments,
section structure) and never adds trailing commas.

.PARAMETER TrxPaths
One or more .trx files to process. Wildcards supported.
Defaults to all SFP_*.trx files under TestResults\.

.PARAMETER SfpJsonPath
Path to SFP.json. Defaults to Resources\ExpectedForms\SFP\SFP.json
relative to the repository root.

.PARAMETER WhatIf
Show proposed changes without writing any files.

.EXAMPLE
# Process the most-recent CE run
.\Scripts\Update-SFPBaseline.ps1 -TrxPaths TestResults\SFP_CE_Run2.trx

# Process all CE runs to aggregate across multiple runs
.\Scripts\Update-SFPBaseline.ps1 -TrxPaths TestResults\SFP_CE_Run*.trx

# Process Basic AND CE runs together (forms in both → BASE section)
.\Scripts\Update-SFPBaseline.ps1 -TrxPaths TestResults\SFP_Basic_Run1.trx, TestResults\SFP_CE_Run1.trx

# Preview changes without writing
.\Scripts\Update-SFPBaseline.ps1 -WhatIf
#>
[CmdletBinding()]
param(
    [string[]] $TrxPaths,
    [string]   $SfpJsonPath = 'Resources\ExpectedForms\SFP\SFP.json',
    [switch]   $WhatIf
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

# ── Resolve paths ─────────────────────────────────────────────────────────────

$repoRoot = Split-Path (Split-Path $PSCommandPath -Parent) -Parent

if (-not [IO.Path]::IsPathRooted($SfpJsonPath)) {
    $SfpJsonPath = Join-Path $repoRoot $SfpJsonPath
}
if (-not (Test-Path $SfpJsonPath)) {
    Write-Error "SFP.json not found at: $SfpJsonPath"
    exit 1
}

if (-not $TrxPaths) {
    $TrxPaths = @(Get-ChildItem (Join-Path $repoRoot 'TestResults\SFP_*.trx') |
                  Select-Object -ExpandProperty FullName)
}

if (-not $TrxPaths) {
    Write-Error 'No TRX files found. Specify -TrxPaths or place SFP_*.trx files in TestResults\.'
    exit 1
}

$resolvedTrx = @()
foreach ($tp in $TrxPaths) {
    if (-not [IO.Path]::IsPathRooted($tp)) { $tp = Join-Path $repoRoot $tp }
    $found = Get-Item $tp -ErrorAction SilentlyContinue
    if ($found) { $resolvedTrx += $found.FullName }
    else         { Write-Warning "  TRX not found: $tp" }
}
if (-not $resolvedTrx) { Write-Error 'No valid TRX files resolved.'; exit 1 }

Write-Host ''
Write-Host '  Update-SFPBaseline' -ForegroundColor Cyan
Write-Host "  SFP.json  : $SfpJsonPath"
Write-Host "  TRX files : $($resolvedTrx.Count)"
foreach ($t in $resolvedTrx) { Write-Host "    $(Split-Path $t -Leaf)" }

# ── Parse TRX files for C14 INFO items ────────────────────────────────────────
#
# Builds: $formMap[formName] = @{ Basic = @{state=$true,...}; CE = @{state=$true,...} }

$formMap = @{}
$ns = @{ t = 'http://microsoft.com/schemas/VisualStudio/TeamTest/2010' }

foreach ($trxFile in $resolvedTrx) {
    Write-Host "`n  Parsing $(Split-Path $trxFile -Leaf) ..." -ForegroundColor DarkGray
    [xml]$trx = Get-Content $trxFile -Raw

    foreach ($result in (Select-Xml -Xml $trx -XPath '//t:UnitTestResult' -Namespace $ns)) {
        $node     = $result.Node
        $testName = $node.testName
        $stdout   = $node.Output.StdOut
        if (-not $stdout) { continue }

        # Determine variant
        $variant = if     ($testName -match 'SFPBasicPolicy')     { 'Basic' }
                   elseif ($testName -match 'SFPCountryEstate')   { 'CE'    }
                   else                                            { continue }

        # State abbreviation = 2nd quoted argument, e.g. "GA"
        $params = [regex]::Matches($testName, '"([^"]*)"')
        if ($params.Count -lt 2) { continue }
        $state = $params[1].Groups[1].Value
        if ($state -notmatch '^[A-Z]{2}$') { continue }

        # Extract C14 INFO form names from StdOut
        # Line format:  "    [INFO] SF00030426 — Not in baseline but found on policy as Mandatory"
        foreach ($line in ($stdout -split '[\r\n]+')) {
            if ($line -match '^\s*\[INFO\]\s+([A-Z0-9]+)\b.+Not in baseline but found on policy as Mandatory') {
                $form = $Matches[1]
                if (-not $formMap.ContainsKey($form)) {
                    $formMap[$form] = @{ Basic = @{}; CE = @{} }
                }
                $formMap[$form][$variant][$state] = $true
            }
        }
    }
}

if ($formMap.Count -eq 0) {
    Write-Host "`n  No C14 INFO items found in the supplied TRX files. SFP.json is up to date." -ForegroundColor Green
    exit 0
}

$totalPairs = ($formMap.Values | ForEach-Object { $_.Basic.Count + $_.CE.Count } | Measure-Object -Sum).Sum
Write-Host "`n  Found $($formMap.Count) unique C14 forms ($totalPairs form/state pairs)." -ForegroundColor Yellow

# ── Read and index SFP.json ───────────────────────────────────────────────────

$fileLines = [IO.File]::ReadAllLines($SfpJsonPath)   # 0-based array

# Map: formName → { Section, LineIndex, RawLine }
$formIndex = @{}

# Map: sectionName → closing-brace LineIndex
$sectionClose = @{}

$curSection  = $null
$depth       = 0

for ($i = 0; $i -lt $fileLines.Count; $i++) {
    $line = $fileLines[$i]

    # Detect section header: "BASE": {  /  "BASIC": {  /  "CE": {
    if ($line -match '^\s*"(BASE|BASIC|CE)"\s*:\s*\{') {
        $curSection  = $Matches[1]
        $depth       = 1
        continue
    }

    if ($null -ne $curSection) {
        # Count brace depth to find closing line
        foreach ($ch in $line.ToCharArray()) {
            if ($ch -eq '{') { $depth++ }
            elseif ($ch -eq '}') {
                $depth--
                if ($depth -eq 0) {
                    $sectionClose[$curSection] = $i
                    $curSection = $null
                    break
                }
            }
        }

        # Index form entries: "FORMNAME": <value>
        if ($null -ne $curSection -and
            $line -match '^\s*"([A-Z0-9]+)"\s*:\s*(.+)$') {
            $fn  = $Matches[1]
            $raw = $Matches[2].Trim().TrimEnd(',')
            if ($fn -notin @('BASE','BASIC','CE')) {
                $formIndex[$fn] = @{
                    Section   = $curSection
                    LineIndex = $i
                    RawLine   = $line
                    RawValue  = $raw
                }
            }
        }
    }
}

# ── Plan changes ──────────────────────────────────────────────────────────────
#
# $updates  = list of existing-entry modifications
# $newForms = list of brand-new entries to insert

$updates  = [System.Collections.Generic.List[hashtable]]::new()
$newForms = [System.Collections.Generic.List[hashtable]]::new()

foreach ($formName in ($formMap.Keys | Sort-Object)) {
    $basicStates = @($formMap[$formName].Basic.Keys | Sort-Object)
    $ceStates    = @($formMap[$formName].CE.Keys    | Sort-Object)

    if ($formIndex.ContainsKey($formName)) {
        # ── Existing entry: add missing states ────────────────────────────────
        $entry   = $formIndex[$formName]
        $section = $entry.Section
        $raw     = $entry.RawValue

        if ($raw -eq '"all"') {
            Write-Host "  SKIP  $formName ($section) — already 'all'" -ForegroundColor DarkGray
            continue
        }

        # Determine which new states belong in this section
        $statesToAdd = switch ($section) {
            'BASE'  { ($basicStates + $ceStates) | Select-Object -Unique | Sort-Object }
            'BASIC' { $basicStates }
            'CE'    { $ceStates    }
        }

        # Parse existing states
        $existing = [regex]::Matches($raw, '"([A-Z]{2})"') |
                    ForEach-Object { $_.Groups[1].Value }

        $toAdd = $statesToAdd | Where-Object { $_ -notin $existing }
        if (-not $toAdd) {
            Write-Host "  SKIP  $formName ($section) — all states already present" -ForegroundColor DarkGray
            continue
        }

        $merged   = ($existing + @($toAdd)) | Sort-Object
        $newArray = '["' + ($merged -join '", "') + '"]'

        $updates.Add(@{
            FormName    = $formName
            Section     = $section
            LineIndex   = $entry.LineIndex
            OldArray    = $raw
            NewArray    = $newArray
            AddedStates = @($toAdd)
        })
    }
    else {
        # ── New entry: determine target section and states ────────────────────
        $targetSection = if ($basicStates.Count -gt 0 -and $ceStates.Count -gt 0) { 'BASE' }
                         elseif ($basicStates.Count -gt 0)                         { 'BASIC' }
                         else                                                       { 'CE'    }

        $statesToAdd = switch ($targetSection) {
            'BASE'  { ($basicStates + $ceStates) | Select-Object -Unique | Sort-Object }
            'BASIC' { $basicStates }
            'CE'    { $ceStates    }
        }

        $newArray = '["' + ($statesToAdd -join '", "') + '"]'

        $newForms.Add(@{
            FormName    = $formName
            Section     = $targetSection
            NewArray    = $newArray
            AddedStates = @($statesToAdd)
        })
    }
}

if ($updates.Count -eq 0 -and $newForms.Count -eq 0) {
    Write-Host "`n  All C14 INFO forms are already in the baseline. No changes needed." -ForegroundColor Green
    exit 0
}

# ── Print change plan ─────────────────────────────────────────────────────────

Write-Host ''
if ($updates.Count -gt 0) {
    Write-Host "  Updates ($($updates.Count) existing entries):" -ForegroundColor Yellow
    foreach ($c in ($updates | Sort-Object { $_.Section }, { $_.FormName })) {
        Write-Host "    [$($c.Section)] $($c.FormName)  +$($c.AddedStates -join ', ')"
    }
}
if ($newForms.Count -gt 0) {
    Write-Host "  New entries ($($newForms.Count) forms):" -ForegroundColor Yellow
    foreach ($c in ($newForms | Sort-Object { $_.Section }, { $_.FormName })) {
        Write-Host "    [$($c.Section)] $($c.FormName) = $($c.NewArray)"
    }
}

if ($WhatIf) {
    Write-Host "`n  -WhatIf: no changes written." -ForegroundColor Cyan
    exit 0
}

# ── Apply changes ─────────────────────────────────────────────────────────────

$lines = [System.Collections.Generic.List[string]]::new()
$lines.AddRange($fileLines)

# 1. Apply in-place updates (descending line order to preserve indices)
foreach ($c in ($updates | Sort-Object { $_.LineIndex } -Descending)) {
    $old = $lines[$c.LineIndex]
    # Replace the array value portion; use literal string match
    $new = $old -replace ([regex]::Escape($c.OldArray)), $c.NewArray
    $lines[$c.LineIndex] = $new
}

# 2. Insert new entries, grouped by section
#    Apply sections in reverse order so earlier section inserts don't shift later indices.
$sectionOrder = @('CE', 'BASIC', 'BASE')

foreach ($sec in $sectionOrder) {
    $toInsert = @($newForms | Where-Object { $_.Section -eq $sec } |
                  Sort-Object { $_.FormName })
    if (-not $toInsert) { continue }

    # Re-find the section close index (may have shifted from earlier inserts above, but
    # since we go CE→BASIC→BASE, earlier sections (BASE) are later in the file, so
    # inserting into CE/BASIC first shifts BASE's close index upward).
    # Re-scan from scratch.
    $closeIdx = -1
    $d = 0
    $inSec = $false
    for ($i = 0; $i -lt $lines.Count; $i++) {
        $l = $lines[$i]
        if ($l -match "^\s*`"$sec`"\s*:\s*\{") { $inSec = $true; $d = 1; continue }
        if ($inSec) {
            foreach ($ch in $l.ToCharArray()) {
                if ($ch -eq '{') { $d++ }
                elseif ($ch -eq '}') {
                    $d--
                    if ($d -eq 0) { $closeIdx = $i; $inSec = $false; break }
                }
            }
            if ($closeIdx -ge 0) { break }
        }
    }

    if ($closeIdx -lt 0) { Write-Warning "  Could not locate $sec section close — skipping inserts for $sec"; continue }

    # Find the last non-blank, non-comment line before closeIdx
    $lastFormIdx = $closeIdx - 1
    while ($lastFormIdx -ge 0 -and ($lines[$lastFormIdx].Trim() -eq '' -or $lines[$lastFormIdx].Trim().StartsWith('//'))) {
        $lastFormIdx--
    }

    # Ensure last existing form line has a trailing comma
    if ($lastFormIdx -ge 0 -and $lines[$lastFormIdx] -notmatch ',\s*$') {
        $lines[$lastFormIdx] = $lines[$lastFormIdx] + ','
    }

    # Build lines to insert (all have commas except the very last)
    $insertLines = @()
    for ($k = 0; $k -lt $toInsert.Count; $k++) {
        $c       = $toInsert[$k]
        $comma   = if ($k -lt $toInsert.Count - 1) { ',' } else { '' }
        $insertLines += "    `"$($c.FormName)`": $($c.NewArray)$comma"
    }

    # Insert just before the closing brace
    $insertAt = $closeIdx
    for ($k = $insertLines.Count - 1; $k -ge 0; $k--) {
        $lines.Insert($insertAt, $insertLines[$k])
    }
}

# ── Write back ────────────────────────────────────────────────────────────────

[IO.File]::WriteAllLines($SfpJsonPath, $lines.ToArray(), [Text.Encoding]::UTF8)

Write-Host "`n  SFP.json updated: $($updates.Count) entries modified, $($newForms.Count) entries added." -ForegroundColor Green

if ($updates.Count -gt 0) {
    foreach ($c in ($updates | Sort-Object { $_.Section }, { $_.FormName })) {
        Write-Host "    [OK] [$($c.Section)] $($c.FormName)  +$($c.AddedStates -join ', ')" -ForegroundColor Green
    }
}
if ($newForms.Count -gt 0) {
    foreach ($c in ($newForms | Sort-Object { $_.Section }, { $_.FormName })) {
        Write-Host "    [NEW] [$($c.Section)] $($c.FormName) = $($c.NewArray)" -ForegroundColor Green
    }
}

Write-Host ''
