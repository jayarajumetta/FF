<#
.SYNOPSIS
    Extracts annual SFP premiums and quote numbers from a TRX result.

.DESCRIPTION
    Produces a CSV alongside the TRX. It records only tests present in the TRX
    and never fills missing states or treats a captured amount as approved.

.PARAMETER TrxPath
    TRX produced by an SFP workflow run.
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory)][string]$TrxPath
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

if (-not (Test-Path $TrxPath)) {
    throw "TRX file not found: $TrxPath"
}

$stateNames = [ordered]@{
    "South Carolina" = "SC"; "South Dakota" = "SD"; "North Dakota" = "ND"
    "New Hampshire" = "NH"; "New Jersey" = "NJ"; "New Mexico" = "NM"
    "Rhode Island" = "RI"; "Massachusetts" = "MA"; "Pennsylvania" = "PA"
    "Connecticut" = "CT"; "Mississippi" = "MS"; "Washington" = "WA"
    "Maryland" = "MD"; "Minnesota" = "MN"; "Missouri" = "MO"
    "Nebraska" = "NE"; "Oklahoma" = "OK"; "Tennessee" = "TN"
    "Wisconsin" = "WI"; "Arkansas" = "AR"; "Colorado" = "CO"
    "Delaware" = "DE"; "Georgia" = "GA"; "Illinois" = "IL"
    "Indiana" = "IN"; "Kentucky" = "KY"; "Louisiana" = "LA"
    "Montana" = "MT"; "Vermont" = "VT"; "Alabama" = "AL"
    "Arizona" = "AZ"; "Idaho" = "ID"; "Iowa" = "IA"; "Kansas" = "KS"
    "Maine" = "ME"; "Nevada" = "NV"; "Ohio" = "OH"; "Oregon" = "OR"
    "Texas" = "TX"; "Utah" = "UT"; "Wyoming" = "WY"
}

[xml]$trx = Get-Content $TrxPath -Raw
$results = [System.Collections.Generic.List[PSCustomObject]]::new()
$csvPath = [IO.Path]::ChangeExtension($TrxPath, "premiums.csv")

if (Test-Path $csvPath) {
    Remove-Item -LiteralPath $csvPath
}

foreach ($unitTest in @($trx.TestRun.Results.UnitTestResult)) {
    $testName = [string]$unitTest.testName
    if (($testName -notmatch "^(SFPBasicPolicy_State|SFPCountryEstatePolicy_State|SFPRatePolicy_State)\(") -and
        ($testName -notmatch "SFP (Basic|Country Estate|Rate) Policy")) {
        continue
    }

    $variant = if ($testName -match "SFPRatePolicy|SFP Rate Policy") { "RATEPOLICY" }
        elseif ($testName -match "SFPCountryEstatePolicy|Country Estate") { "CE" } else { "BASIC" }
    $state = $null
    $generatedState = [regex]::Match(
        $testName,
        '^SFP(?:BasicPolicy|CountryEstatePolicy|RatePolicy)_State\("[^"]+"\s*,\s*"(?<State>[A-Z]{2})"')
    if ($generatedState.Success) {
        $state = $generatedState.Groups["State"].Value
    }
    else {
        foreach ($entry in $stateNames.GetEnumerator()) {
            if ($testName -match ("\b" + [regex]::Escape($entry.Key) + "\b")) {
                $state = $entry.Value
                break
            }
        }
    }

    $output = [string]$unitTest.Output.StdOut
    $premiumMatch = [regex]::Match(
        $output, '\*\*\* ANNUAL PREMIUM: \$([\d,]+\.?\d{0,2}) \*\*\*')
    $quoteMatch = [regex]::Match(
        $output, '\*\*\* QUOTE NUMBER.*?(\d{7,9})')

    $results.Add([PSCustomObject]@{
        Variant = $variant
        State = if ($state) { $state } else { "UNKNOWN" }
        Premium = if ($premiumMatch.Success) { $premiumMatch.Groups[1].Value.Replace(",", "") } else { "" }
        Quote = if ($quoteMatch.Success) { $quoteMatch.Groups[1].Value } else { "" }
        Outcome = [string]$unitTest.outcome
    })
}

$sorted = @($results | Sort-Object Variant, State)
if ($sorted.Count -eq 0) {
    throw "No SFP workflow results were found in the TRX. No premium CSV was created."
}

$sorted | Export-Csv -Path $csvPath -NoTypeInformation
$sorted | Format-Table Variant, State, Premium, Quote, Outcome -AutoSize
Write-Host "Premium capture saved: $csvPath" -ForegroundColor Green
