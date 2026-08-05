# Locator Scan Tool — How-To Guide

Use this tool to scrape a live application page and automatically generate Playwright locators for any elements found. The output is a ready-to-use C# page object file you can drop straight into the project.

---

## Prerequisites

- The repo is cloned and builds successfully (`dotnet build`)
- Google Chrome is installed
- You are on the correct VPN / network to reach the application

---

## Step 1 — Open Chrome with Remote Debugging

In any PowerShell terminal, type:

```powershell
chrome
```

This opens a dedicated Chrome instance with remote debugging enabled on port 9222. Keep it open for the duration of the scan.

> Do not use a regular Chrome window — it won't be reachable by the scanner.

---

## Step 2 — Navigate to the Page You Want to Scan

In that Chrome window, log into the application and navigate to the exact page or step you need locators for — for example, a specific quote screen, a coverage page, or a checklist.

The scanner will capture whatever is currently visible (and conditionally hidden) on that page.

---

## Step 3 — Run the Scanner

In any PowerShell terminal, type:

```powershell
scan
```

That's it. The scanner will:
1. Connect to the Chrome window
2. Scrape all interactive elements on the current page
3. Rank and deduplicate locators against existing repo code
4. Output a ready-to-use C# page object file

The scan takes approximately **10–30 seconds**.

### Scan Variants

```powershell
scan              # Default — dedupes against repo, skips elements already covered
scan -NoCompare   # Show ALL elements with no repo comparison (useful for CLAS/Express pages)
scan -NewOnly     # Only show elements NOT already in the repo
```

---

## Step 4 — Find the Output

Results are saved to:
```
TestResults\<timestamp>\<scenario>\
```

The primary output is a **C# page object file** (e.g. `QuoteDetailsPage_Locators.cs`) containing ranked locators for every interactive element found on the page. This file is formatted to match the project's existing page object pattern and is ready to review and integrate.

---

## Full Workflow (Quick Reference)

```powershell
# 1. Open debug Chrome
chrome

# 2. Navigate to the target page in that Chrome window, then:
scan

# 3. Check output in TestResults\<timestamp>\
```

---

## Advanced Options

For cases where you need more control, you can pass parameters directly:

```powershell
# Full scan — slower but captures more locator candidates per element
dotnet test TestAutomation.csproj --filter "Category=Tools&Name~Scan" `
  -- TestRunParameters.Parameter(name="CDP",value="http://localhost:9222") `
     TestRunParameters.Parameter(name="FAST_MODE",value="false")

# Name the output folder for easier identification
dotnet test TestAutomation.csproj --filter "Category=Tools&Name~Scan" `
  -- TestRunParameters.Parameter(name="CDP",value="http://localhost:9222") `
     TestRunParameters.Parameter(name="SCENARIO",value="SFPCoveragePage")
```

### All Parameters

| Parameter | Default | Description |
|---|---|---|
| `CDP` | *(required)* | Chrome DevTools URL — always `http://localhost:9222` when using remote debugging |
| `URL` | *(empty)* | If provided, opens this URL in a new browser instead of attaching to Chrome |
| `FAST_MODE` | `true` | Limits locator candidates per element for speed. Set to `false` for exhaustive output |
| `SCAN_HIDDEN` | `true` | Includes hidden/conditional elements (dropdowns, modals, off-screen fields) |
| `COMPARE` | `true` | Cross-references results against existing repo locators to avoid duplicates |
| `NEW_ONLY` | `false` | Only outputs elements not already in the repo. Requires `COMPARE=true` |
| `CS_ONLY` | `true` | Outputs only the `.cs` page object file. Set to `false` to also get CSV output |
| `SCENARIO` | *(empty)* | Label for the output folder |

---

## Tips

- **Scan one page at a time.** Navigate to a specific step/screen before scanning rather than scanning from a landing page.
- **For conditional fields** (e.g. fields that appear after selecting a dropdown value), make those selections first so they are visible when the scan runs.
- **Use `-NoCompare` for CLAS/Express pages** where there are no existing repo locators to compare against.
- **Re-scan after UI changes.** If the application is updated and locators start breaking, re-scan the affected page and compare the new output to what's in the repo.
- **The output file is a starting point**, not final code. Review the generated locators and rename properties to match the project's naming conventions before integrating.
