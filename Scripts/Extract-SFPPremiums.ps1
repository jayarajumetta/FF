<#
.SYNOPSIS
    Extracts the annual premium logged per state from a TRX test result file.

.DESCRIPTION
    Parses the NUnit TRX produced by run-sfp-basic.ps1.
    Looks for "*** ANNUAL PREMIUM: $X,XXX.XX ***" in each test's stdout.
    Also reads the state abbreviation from the quote number log line or
    the FormsReport filename written during the run.

    Outputs a sorted table of State -> Premium and saves a CSV alongside the TRX.

.PARAMETER TrxPath
    Full path to the .trx file produced by run-sfp-basic.ps1.

.EXAMPLE
    .\Scripts\Extract-SFPPremiums.ps1 -TrxPath "c:\...\SFP_BasicPolicy_2026-04-10_073041.trx"
#>

param(
    [Parameter(Mandatory)][string]$TrxPath
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

if (-not (Test-Path $TrxPath)) {
    Write-Error "TRX file not found: $TrxPath"
    exit 1
}

Write-Host ""
Write-Host "=== SFP Premium Extraction ===" -ForegroundColor Cyan
Write-Host "  TRX: $TrxPath"
Write-Host ""

[xml]$trx = Get-Content $TrxPath -Raw

# All 23 SFP states
$allStates = @('AL','AR','AZ','CO','ID','IL','KS','KY','LA','MN','MT','NE','NV','ND','OR','SC','SD','TN','TX','UT','WA','WI','WY')

$results = [System.Collections.Generic.List[PSCustomObject]]::new()

foreach ($unitTest in $trx.TestRun.Results.UnitTestResult) {
    $output = $unitTest.Output.StdOut

    # Extract state from test name — format: "SFP Basic Policy - Alabama" etc.
    $testName = $unitTest.testName
    $stateMatch = [regex]::Match($testName, '\b(Alabama|Arkansas|Arizona|Colorado|Idaho|Illinois|Kansas|Kentucky|Louisiana|Minnesota|Montana|Nebraska|Nevada|North\s*Dakota|Oregon|South\s*Carolina|South\s*Dakota|Tennessee|Texas|Utah|Washington|Wisconsin|Wyoming)\b', 'IgnoreCase')

    $stateFullToAbbv = @{
        'Alabama'='AL'; 'Arkansas'='AR'; 'Arizona'='AZ'; 'Colorado'='CO'
        'Idaho'='ID'; 'Illinois'='IL'; 'Kansas'='KS'; 'Kentucky'='KY'
        'Louisiana'='LA'; 'Minnesota'='MN'; 'Montana'='MT'; 'Nebraska'='NE'
        'Nevada'='NV'; 'NorthDakota'='ND'; 'Oregon'='OR'; 'SouthCarolina'='SC'
        'SouthDakota'='SD'; 'Tennessee'='TN'; 'Texas'='TX'; 'Utah'='UT'
        'Washington'='WA'; 'Wisconsin'='WI'; 'Wyoming'='WY'
    }

    $stateAbbv = 'UNKNOWN'
    if ($stateMatch.Success) {
        $key = ($stateMatch.Value -replace '\s', '')
        $stateAbbv = if ($stateFullToAbbv.ContainsKey($key)) { $stateFullToAbbv[$key] } else { $key.Substring(0,2).ToUpper() }
    }

    # Extract premium
    $premiumMatch = [regex]::Match($output, '\*\*\* ANNUAL PREMIUM: \$([\d,]+\.?\d{0,2}) \*\*\*')
    $premium = if ($premiumMatch.Success) { $premiumMatch.Groups[1].Value } else { 'N/A' }

    # Extract quote number for reference
    $quoteMatch = [regex]::Match($output, '\*\*\* QUOTE NUMBER.*?(\d{7,9})')
    $quote = if ($quoteMatch.Success) { $quoteMatch.Groups[1].Value } else { '' }

    $outcome = $unitTest.outcome  # Passed / Failed

    $results.Add([PSCustomObject]@{
        State   = $stateAbbv
        Premium = $premium
        Quote   = $quote
        Outcome = $outcome
    })
}

# Add any states that didn't get a result at all (crashed before test ran)
$foundStates = $results | Select-Object -ExpandProperty State
foreach ($s in $allStates) {
    if ($s -notin $foundStates) {
        $results.Add([PSCustomObject]@{ State = $s; Premium = 'N/A'; Quote = ''; Outcome = 'NotRun' })
    }
}

$sorted = $results | Sort-Object State

# Print table
Write-Host ("  {0,-6} {1,-14} {2,-12} {3}" -f "State", "Premium", "Quote", "Outcome")
Write-Host ("  {0,-6} {1,-14} {2,-12} {3}" -f "-----", "-------", "-----", "-------")
foreach ($r in $sorted) {
    $color = switch ($r.Outcome) {
        'Passed'  { 'Green' }
        'Failed'  { 'Red' }
        default   { 'Yellow' }
    }
    Write-Host ("  {0,-6} {1,-14} {2,-12} {3}" -f $r.State, $r.Premium, $r.Quote, $r.Outcome) -ForegroundColor $color
}

# Save CSV
$csvPath = [System.IO.Path]::ChangeExtension($TrxPath, "premiums.csv")
$sorted | Export-Csv -Path $csvPath -NoTypeInformation
Write-Host ""
Write-Host "CSV saved: $csvPath" -ForegroundColor Green
Write-Host ""
Write-Host "Once reviewed, pass the premium values to Copilot to lock them into appsettings.json." -ForegroundColor Cyan
