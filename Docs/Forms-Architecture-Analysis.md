# Excel → JSON Migration: Architectural Analysis

## What Already Exists (The Migration Is Largely Done)

The pipeline is already built end-to-end:

```
Excel Masterlist
    ↓ ExcelFormsParser.cs (ClosedXML)
    ↓ FormsBaselineGeneratorTool.cs (NUnit test wrapper)
    ↓ BaselineJsonEmitter.cs
    → SFP.json  ←  FormsValidationService.LoadFromIncludeOnlyJson()
```

Running the generator today is one command:

```powershell
dotnet test --settings generate-baseline.runsettings `
  --filter "Category=Tools&Name~GenerateFormsBaseline"
```

The `generate-baseline.runsettings` already has hardcoded paths to **two** Excel files:
- `SFP Forms Masterlist v9.00 (1).xlsx` (LOB-specific)
- `Common Forms MASTERLIST (all States) - Version 80.00 (2).xlsx` (merged into BASE)

And `DRY_RUN=true` is the current default, so no writes happen unless you explicitly flip it.

---

## Gap 1: `DRY_RUN=true` Is the Default — Writes Are Manual

**Risk:** Every time someone regenerates, they must remember to change `DRY_RUN` (in the `.runsettings` or via CLI override). Easy to forget; the "dry run" output is only in console, which evaporates once the terminal closes.

**Question:** Should `DRY_RUN` default to `false` once the baseline is stabilized? Or is the current cautious default intentional given that the baseline is still being cleaned up?

---

## Gap 2: `INCLUDE_SHEETS` Is Scoped to Division 0+1 Only

The `.runsettings` has `INCLUDE_SHEETS=Division 0,Division 1`. This matches the **Basic Div 0+1** test policy profile specifically. But the Excel may have 7+ division sheets (Division I–VII), and forms from other divisions (e.g., Division IV — liability) might legitimately appear on a Basic policy quote.

**Risk:** If DuckCreek returns a form that lives in Division IV of the Excel but `INCLUDE_SHEETS` excluded Division IV, that form won't be in the baseline → always produces C14/C15 `INFO`. This is likely the root cause of the 47 conditional-form INFOs observed in the AR XML run.

**Question:** Do you know which Excel sheets correspond to your Basic test policy profile? Does the DC engineer/underwriter have a mapping of "which divisions apply to a Div 0+1 policy"?

---

## Gap 3: Static Status — No Conditional Forms Support

The JSON format only supports static per-state status values (`YM`, `YS`, `YU`). There is no notion of:
- "This form only appears when Wind/Hail deductible is selected"
- "This form only applies when EQ coverage is added"
- "This form is mandatory only if the policy is in a coastal zone"

**Impact:** Conditional forms will always produce a mismatch unless handled one of two ways:
1. Remove them from the baseline entirely (treat as INFO, not FAIL)
2. Run separate test scenarios (Wind/Hail selected vs. not selected) with separate JSON sections

**Question:** Are the 47 failing forms ALL conditional, or is that mix — some conditional, some just wrong state coverage in the baseline? Did you get a clarification from the DC SME on which forms are truly conditional?

---

## Gap 4: `ResolveStatusFromJsonElement` — Only `"all"` Maps to YM

The current `"all"` shorthand hardcodes status as `YM`:

```csharp
case JsonValueKind.String:
    return value.GetString()?.Equals("all", ...) == true ? "YM" : null;
```

There is no `"all-YS"` or `"selected-all"` shorthand. If a form should be `YS` (selected, not mandatory) in all 23 states, the generator would emit the full object form `{"AL":"YS","AR":"YS",...,"WY":"YS"}` — 23 key-value pairs. This is verbose but functionally correct.

**Risk:** Low — just cosmetic verbosity. Worth knowing if you're hand-editing the JSON.

---

## Gap 5: Last-State-Wins if a Form Appears in Both LOB Excel and Common Excel

In `FormsBaselineGeneratorTool`:

```csharp
var lobFormNumbers = new HashSet<string>(rows.Select(r => r.FormNumber), ...);
var added = commonRows.Where(r => !lobFormNumbers.Contains(r.FormNumber)).ToList();
rows = rows.Concat(added).ToList();
```

LOB rows win over Common rows for any form that appears in both. Common forms are merged **only if** they don't already exist in the LOB rows. This is the right behavior assuming the LOB Excel is the authoritative source, but:

**Risk:** If a form exists in both Excels with *different section assignments* (e.g., BASE in LOB, BASIC in Common), the LOB assignment silently wins. No warning is printed.

---

## Gap 6: The `ApplyCompanyFilters` Method Is an Invisible Pre-Filter

Before any JSON-vs-actual comparison runs, `FormsValidationService.Validate()` calls:

```csharp
actual = ApplyCompanyFilters(actual, state);
```

This strips out forms by company code before the baseline is consulted. The JSON baseline has no knowledge of this. If that filter is wrong (wrong company codes for a state), forms disappear from the comparison and you can't see it from the JSON alone.

**Question:** Do you know what `ApplyCompanyFilters` does? Is it filtering by the insuring company entity (e.g., "only show ISO forms for PnC company X")? If so, is that filter maintained anywhere other than in the C# code?

---

## Gap 7: Excel Path in `.runsettings` Is an Absolute Local Path

```xml
<Parameter name="EXCEL" value="c:\PnC Test Automation\PnC-TestAutomation\Resources\ExpectedForms\SFP\SFP Forms Masterlist v9.00 (1).xlsx" />
```

This path only works on the machine where the file exists at that exact location. Running on a build server or a colleague's machine will fail immediately.

**Risk:** The Excel files are likely not in source control (`.xlsx` files are binary; probably in `.gitignore`). Anyone else who runs the generator needs the files locally at the right path, or needs to override via CLI.

**Question:** Are the Excel masterlist files committed to the repo, stored in SharePoint/Teams, or both? Is there a CI pipeline that runs the generator, or is it purely a dev-machine tool?

---

## Gap 8: No Validation on Generated JSON Output

The generator writes the JSON and prints the diff (added/removed form names). But it doesn't:
- Validate that state counts in the output match the `SupportedStates` list
- Warn if a form has `YM` for zero states (would be omitted)
- Assert that BASE section size is non-zero

If the parser silently skips all rows (wrong column headers), you get an empty JSON with `Assert.Pass` logged.

---

## Summary Table

| # | Gap | Severity | Blocks Migration? |
|---|-----|----------|-------------------|
| 1 | `DRY_RUN=true` default | Low | No |
| 2 | `INCLUDE_SHEETS` may exclude valid forms (root cause of 47 INFOs?) | **High** | Likely yes |
| 3 | No conditional form support | **High** | For accuracy, yes |
| 4 | No `"all"` shorthand for YS/YU | Low | No |
| 5 | Common + LOB merge: silent section conflict | Medium | No |
| 6 | `ApplyCompanyFilters` is opaque, not part of JSON | Medium | Depends |
| 7 | Absolute Excel paths in `.runsettings` | Medium | For team use, yes |
| 8 | No post-emit validation | Low | No |

---

## The 3 Questions That Block a Clean Migration

1. **Which Excel sheets cover your Basic Policy test profile?** (Gap 2 — likely the biggest impact on current FAIL/INFO counts)
2. **What is the full list of conditional forms, and is there a DC-defined source for them?** (Gap 3 — determines if a second JSON section is feasible or if they just get excluded)
3. **What does `ApplyCompanyFilters` filter on, and is it correct for all 23 states?** (Gap 6 — invisible to the JSON model)
