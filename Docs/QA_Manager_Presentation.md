# QA Manager Framework Presentation
**Branch:** feature/forms-ado-reporting  
**Date:** August 2026  
**Presenter:** PnC Test Automation Team  

---

## SUGGESTED FLOW (45–60 min)

| # | Section | Time | Type |
|---|---------|------|------|
| 1 | Framework Overview | ~5 min | Talk |
| 2 | DataPool Demo | ~10 min | Live Demo |
| 3 | Smoke Test Run | ~15 min | Live Run |
| 4 | Locator Scanner Tool | ~10 min | Live Demo |
| 5 | Forms Validation Report | ~10 min | Live Demo |
| 6 | Q&A | ~10 min | Open |

---

## PRE-PRESENTATION CHECKLIST
> Run this the morning of your presentation

```powershell
# 1. Clean build
cd "C:\PnC Test Automation\PnC-TestAutomation"
dotnet build Playwright_POC.sln --verbosity minimal

# 2. Start DataPool and confirm it responds
cd DataPool
dotnet run &
Start-Sleep 3
Invoke-RestMethod http://localhost:5100/api/quotes | ConvertTo-Json

# 3. Confirm a recent HTML forms report exists
Get-ChildItem "bin\TestResults" -Recurse -Filter "FormsReport_SFP_AL_*.html" `
  | Sort-Object LastWriteTime -Descending `
  | Select-Object -First 3

# 4. Confirm Expert Quote QA environment is up
Invoke-WebRequest "https://expertquote-qa.americannational.com" -UseBasicParsing `
  | Select-Object StatusCode
```

---

## SECTION 1 — Framework Overview (~5 min)
> **No demo — talk track only**

"What we've built is a full end-to-end test automation framework specifically for Expert Quote —
covering the SFP Basic Policy and Country Estate workflows. It's written in .NET 8, uses Microsoft
Playwright for browser automation, and Gherkin feature files so every test reads like a plain
English business scenario.

Every test we run logs into Expert Quote, creates a random client, completes the full policy
workflow, validates the premium against a known baseline, runs through the checklist, and then
calls DuckCreek directly to validate every form attached to that policy. All of that happens
automatically, without any manual steps.

Here are the key highlights:

- Gherkin/BDD — tests are written in plain English, readable by non-engineers
- 41 scenario states represented for both SFP Basic Policy and Country Estate;
  38 Basic and 14 CE states currently have live-qualified premium baselines
- Premium regression — every run checks actual vs expected premium per state
- Forms validation — every policy's DuckCreek forms are verified against a state baseline
- Built-in tools — DataPool, Locator Scanner, Forms Baseline Generator
- Pipeline-ready — runs in Azure DevOps on a schedule or on-demand
- Parallel execution — 6 shards running simultaneously, full suite in ~25-30 minutes"

**Key architecture points to mention:**
- Three layers: Tests (Gherkin) → Step Definitions → Page Objects → Services
- appsettings.json holds all baselines, credentials, and environment config
- Every completed test auto-persists its quote to the DataPool

---

## SECTION 2 — DataPool Demo (~10 min)
> **Start DataPool before beginning this section**

### Start command:
```powershell
cd "C:\PnC Test Automation\PnC-TestAutomation\DataPool"
dotnet run
```
Then open **http://localhost:5100** in the browser.

### Talk track:
"The DataPool is a lightweight local web application that acts as a quote registry for the
automation framework. Every time a test run completes successfully, the framework automatically
posts the quote ID, state, line of business, premium amount, and policy type to this pool.

The pool tracks three statuses:
- Available  — quote exists and is ready to be used by a test
- Claimed    — a test is currently using this quote
- Consumed   — the quote has been fully used and is retired

This matters because some tests don't need to create a brand new quote from scratch — they just
need an existing quote to work from. Instead of spending 5 minutes creating one, a test can pull
an available quote from the pool in seconds. This saves significant runtime across a full suite.

It also gives us full traceability — we always know exactly which quotes were produced by
automation, when, and what state and product they cover."

### Show live:
1. The main quotes table — ID, state, LOB, variant, status, premium, date
2. The raw REST API at: http://localhost:5100/api/quotes
3. Filter by status: http://localhost:5100/api/quotes?status=available&lob=SFP
4. Filter by variant: http://localhost:5100/api/quotes?lob=SFP&sfpVariant=CE
5. Point out the automatic cleanup — quotes older than 90 days are purged automatically

---

## SECTION 3 — Smoke Test Run (~15 min)
> **START THIS FIRST — kick it off, then narrate while it runs**

### Run command:
```powershell
cd "C:\PnC Test Automation\PnC-TestAutomation"
dotnet test --filter "Category=Smoke&Name~SFPSmoke" --logger "console;verbosity=detailed"
```

### Talk track (while the test runs):
"I've just kicked off our SFP Smoke test. This is a lightweight version of the full workflow —
it logs in, creates a randomized client, selects the Special Farm Package product, navigates
through the quote, and captures a quote number. It's designed to run in about 2-3 minutes and
tell us immediately if Expert Quote is up and functioning correctly.

Notice what's happening in the output as it runs:

The client name is randomly generated every single run — first name, last name — so we never
collide with existing clients or repeat data. The date of birth, phone number, email address,
and SSN are all randomized as well. This means the test suite can run unlimited times without
manual data management.

In the full QA regression suite we run the 38 QA-available states using sharding — 6 parallel
threads, each picking up a different set of states. The three DEV-only states are targeted
separately with the DevOnly filter."

### When it finishes — point out in the output:
- `*** QUOTE NUMBER: XXXXXXXX ***` — quote captured mid-flow
- `[Premium] SFP/AL baseline assertion passed: $1,540.00` — premium validated
- `[DataPool] Persisted quote XXXXXXXX (SFP/BasicPolicy)` — auto-saved to pool
- Total duration in the final line
- Go back to http://localhost:5100 and show the new quote appeared in the pool

---

## SECTION 4 — Locator Scanner Tool (~10 min)
> **Before this section — have Expert Quote open and logged in at any page**

### Talk track:
"One of the biggest time sinks in building a test framework is figuring out how to reliably
select elements on a page — buttons, inputs, dropdowns, checkboxes. A bad selector breaks your
test every time the UI changes. We built a Locator Scanner tool that solves this.

The tool attaches to a running browser session, scans every interactive element visible on the
current page, and ranks the best possible selectors in order of stability:
- Test IDs first — the most stable, won't change with UI redesigns
- ARIA roles second — semantic, accessibility-aligned
- CSS/text fallbacks last — least preferred

Critically, it also compares every candidate against every locator already in the repo. So it
only shows you what's new — you're never looking at duplicates of things you already have.
This takes what used to be 30-60 minutes of manual inspection per page down to about 30 seconds."

### Run it live:

**Step 1 — Launch Chrome with remote debugging:**
```powershell
& "C:\Program Files\Google\Chrome\Application\chrome.exe" --remote-debugging-port=9222
```
Navigate to any Expert Quote page in that browser.

**Step 2 — Run the scanner:**
```powershell
cd "C:\PnC Test Automation\PnC-TestAutomation"
dotnet test --filter "Category=Tools&Name~Scan" `
  -- TestRunParameters.Parameter(name="CDP",value="http://localhost:9222") `
     TestRunParameters.Parameter(name="NEW_ONLY",value="true") `
     TestRunParameters.Parameter(name="SCENARIO",value="Demo")
```

### Show the output:
- Ranked locator suggestions per element with confidence scores
- Side-by-side: new elements vs already covered in repo
- The generated .cs locator file ready to drop into a Page Object
- Point out the FAST_MODE default (~10-30 seconds) vs FULL_SCAN (~1-2 minutes)

---

## SECTION 5 — Forms Validation Report (~10 min)
> **Open the most recent HTML report**

### Open command:
```powershell
Start-Process (
  Get-ChildItem "C:\PnC Test Automation\PnC-TestAutomation\bin\TestResults" `
    -Recurse -Filter "FormsReport_SFP_AL_*.html" `
  | Sort-Object LastWriteTime -Descending `
  | Select-Object -First 1
).FullName
```

### Talk track:
"After every full test run, we don't just check the premium and call it done. We go one step
further — we call DuckCreek directly using the live session cookie from the test, pull the
complete list of forms attached to that policy, and compare it against a state-specific baseline
CSV.

This validates two things:
1. Every mandatory form that should be on an Alabama SFP policy is actually there
2. No unexpected or new forms have appeared that aren't in the baseline

This is significant because a system deployment could silently add or remove a form from a
policy without anyone noticing during manual testing. Our automation catches that automatically
on every single run, for every state.

The report gives us three categories:
- PASS  — form is in baseline and present on policy as expected
- FAIL  — form is in baseline but missing, or present when it shouldn't be
- INFO  — form appeared on the policy but isn't in our baseline yet — flags it for review"

### Show live:
1. The summary box — Total / PASS / FAIL / INFO counts
2. Walk through a PASS row — form code, description, mandatory/optional status
3. Point out any INFO items — explain the review process
4. Show the CSV results path — archived per quote for audit trail
5. Show the HTML report path — dated folder per run

---

## SECTION 6 — Key Metrics

| Metric | Value |
|--------|-------|
| Scenario states — SFP Basic | 41 (38 premium-qualified) |
| Scenario states — Country Estate | 41 (14 premium-qualified) |
| Average full test duration | ~5–6 min per state |
| Parallel shards | 6 |
| Full suite runtime (parallel) | ~25–30 min |
| Forms validated per policy | 27–31 forms |
| Premium baselines tracked | 38 Basic + 14 qualified CE states |
| Tools built | DataPool, Locator Scanner, Forms Baseline Generator |
| CI/CD | Azure DevOps pipeline — scheduled + on-demand |
| Test data | 100% randomized — no manual data prep needed |

---

## SECTION 7 — Closing Talk Track (~2 min)

"Everything you've seen today is committed to Azure DevOps and runs on the pipeline. The
framework is designed so QA engineers can add new states or new products by writing a
Gherkin scenario — no code required for standard flows. The DataPool, forms validation, and
premium regression checks all run automatically on every execution without any manual steps.

Our current roadmap:
- Expanding Country Estate state coverage to match Basic Policy
- Nightly scheduled pipeline runs with ADO dashboard reporting
- Live-qualifying premiums and forms in DEV for the newly represented MD, PA and VT workflows
- Extending the DataPool to support quote reuse across CE and future LOBs

The goal is a framework that gives the business continuous confidence that Expert Quote is
working correctly across every state, every product, and every form — automatically, every night."

---

## APPENDIX — Useful Commands Reference

```powershell
# Run full SFP Basic Policy suite (all 41 states, headed)
dotnet test --filter "Category=ExpertQuote&Category=Smoke" --logger "console;verbosity=detailed"

# Run a single state
dotnet test --filter "Name~SFPBasicPolicy_State.*Alabama" --logger "console;verbosity=detailed"

# Run CE Alabama only
dotnet test --filter "Name~SFPCountryEstatePolicy_State.*Alabama" --logger "console;verbosity=detailed"

# Run smoke tests only
dotnet test --filter "Category=Smoke" --logger "console;verbosity=detailed"

# Start DataPool
cd DataPool; dotnet run

# Open DataPool in browser
Start-Process "http://localhost:5100"

# View all available quotes via API
Invoke-RestMethod "http://localhost:5100/api/quotes?status=available" | ConvertTo-Json -Depth 3

# Open latest AL forms report
Start-Process (Get-ChildItem "bin\TestResults" -Recurse -Filter "FormsReport_SFP_AL_*.html" | Sort-Object LastWriteTime -Descending | Select-Object -First 1).FullName

# Clean build
dotnet build Playwright_POC.sln --verbosity minimal
```
