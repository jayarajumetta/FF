# Forms Baseline Generator
# Reads an LOB Excel masterlist (and optionally the Common Forms masterlist)
# and writes TestResults\FormsBaseline\{LOB}_MASTERLIST_CANDIDATE.json for review.
# Catalog extraction does not qualify scenario rules or replace SFP.json.
#
# USAGE:
#   .\.\Scripts\generate-baseline.ps1 -Excel "C:\path\to\SFP_Masterlist.xlsx"
#   .\.\Scripts\generate-baseline.ps1 -Excel "C:\path\to\SFP_Masterlist.xlsx" -DryRun
#   .\.\Scripts\generate-baseline.ps1 -Excel "C:\path\to\SFP_Masterlist.xlsx" -Common "C:\path\to\CommonForms.xlsx"
#   .\.\Scripts\generate-baseline.ps1 -Excel "C:\path\to\SFP_Masterlist.xlsx" -Lob CE

param(
    [Parameter(Mandatory=$true)]
    [string]$Excel,

    [string]$Common = "",

    [string]$Lob = "SFP",

    [switch]$DryRun
)

if (-not (Test-Path $Excel)) {
    Write-Error "Excel file not found: $Excel"
    exit 1
}

$settings = "$PSScriptRoot\..\generate-baseline.runsettings"

@"
<?xml version="1.0" encoding="utf-8"?>
<RunSettings>
  <TestRunParameters>
    <Parameter name="EXCEL"        value="$Excel" />
    <Parameter name="COMMON_EXCEL" value="$Common" />
    <Parameter name="LOB"          value="$Lob" />
    <Parameter name="DRY_RUN"      value="$($DryRun.IsPresent.ToString().ToLower())" />
  </TestRunParameters>
</RunSettings>
"@ | Out-File -Encoding utf8 $settings

dotnet test "$PSScriptRoot\..\TestAutomation.csproj" `
    --filter "Category=Tools&Name~GenerateFormsBaseline" `
    --settings $settings
