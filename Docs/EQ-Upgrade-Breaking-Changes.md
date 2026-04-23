# EQ Upgrade Breaking Changes — Test Automation Impact

**Tracking doc for alignment meeting with EQ team**
Last updated: April 20, 2026

This document captures every breaking UI change observed after the QA EQ environment was upgraded, along with the specific test automation fix applied. Grouped by change type to illustrate patterns for discussion.

---

## Standing Rule for This Fix Cycle

**Always use `GetByTestId()` first.** `GetByText()`, `GetByRole()`, and `GetByLabel()` are fragile fallbacks — they break when label text changes and are not part of the stable test contract. If a `GetByTestId` fix isn't immediately obvious, inspect the element in DevTools before reaching for a text-based selector:
```js
// Run in DevTools console to find all test IDs near an element:
document.querySelectorAll('[data-testid]').forEach(el => console.log(el.dataset.testid, el.textContent.trim().slice(0,40)))
```
If an element genuinely has no `data-testid`, that is a **bug to report to the EQ team**, not a reason to use `GetByText`.

---

## Theme 1: Chip Components — Indexed Test IDs Replaced with Shared Test ID

**Root cause:** The EQ upgrade replaced individually-indexed chip/tile components (e.g. `value-0`, `value-1`, `value-2`) with a new shared component where every chip in a group shares the same `data-testid`. Disambiguation now requires text content filtering — but **text is not a stable contract** and may change with content updates.

Additionally, the new chip component renders **two nested elements** that both carry the same `data-testid` (one outer `chip-item-wrapper` div and one inner `chip-wrapper` div), requiring `.First` disambiguation on top of text filtering.

---

### Example 1: Insurance Product selection (Proposal Details page)

| | Before | After |
|---|---|---|
| **Test ID pattern** | `proposal.product-0` through `proposal.product-5` | `proposal.product-chip-item-wrapper` (all 6 share this ID) |
| **Nested duplicate** | No | Yes — outer + inner div both have the same test ID |

**Before (broke):**
```csharp
private ILocator FarmPackageButton => _page.GetByTestId("proposal.product-5");
```

**After (fixed):**
```csharp
private ILocator FarmPackageButton => _page.GetByTestId("proposal.product-chip-item-wrapper")
    .Filter(new() { HasText = "Special Farm Package" }).First;
```

Affected locators: `PersonalAutoButton`, `MotorcycleButton`, `RecreationalVehicleButton`, `HomeButton`, `BusinessOwnerButton`, `FarmPackageButton`
File: `Pages/ExpertQuotePages/QuoteDetailsPage.cs`

---

### Example 2: Farm Type Category chips (Policy Details page)

| | Before | After |
|---|---|---|
| **Test ID pattern** | `farmTypeCategory.value-0`, `value-1`, `value-2` (Animals/Crops/Other) | `farmTypeCategory.value-chip-item-wrapper` (all share this ID) |

**Before (broke):**
```csharp
// Index 0=Animals, 1=Crops, 2=Other stored in a dictionary
private ILocator GetPrimaryFarmCategoryButton(string category) =>
    _page.GetByTestId($"fields.account.policyInput$farmTypeCategory.value-{FarmCategoryIndex[category]}");
```

**After (fixed):**
```csharp
private ILocator GetPrimaryFarmCategoryButton(string category) =>
    _page.GetByTestId("fields.account.policyInput$farmTypeCategory.value-chip-item-wrapper")
         .Filter(new() { HasText = category }).First;
```

Same pattern applied to `farmTypeSecondaryCategory`.
File: `Pages/ExpertQuotePages/SFP/SFP_PolicyDetailsPage.cs`

---

### Example 3: Grow Industrial Hemp Yes/No (Policy Details page)

| | Before | After |
|---|---|---|
| **Test ID pattern** | `industrialHemp.value-0` (No), `industrialHemp.value-1` (Yes) | `industrialHemp.value-chip-wrapper` (both share this ID) |
| **Nested duplicate** | No | No (uses `chip-wrapper` not `chip-item-wrapper`) |

**Before (broke):**
```csharp
private ILocator GetGrowIndustrialHempButton(string yesOrNo) =>
    _page.GetByTestId($"fields.account.policyInput$industrialHemp.value-{(yesOrNo.Equals("No") ? "0" : "1")}");
```

**After (fixed):**
```csharp
private ILocator GetGrowIndustrialHempButton(string yesOrNo) =>
    _page.GetByTestId("fields.account.policyInput$industrialHemp.value-chip-wrapper")
         .Filter(new() { HasText = yesOrNo });
```

> **Note:** Two different chip component variants observed — some use `chip-item-wrapper`, others use `chip-wrapper`. The inconsistency makes it impossible to apply a single fix pattern across all fields.

File: `Pages/ExpertQuotePages/SFP/SFP_PolicyDetailsPage.cs`

---

## Theme 2: Custom Button Toggles Replaced with Native Radio Buttons

**Root cause:** Several Yes/No toggle components and selection components were replaced with native HTML `<input type="radio">` elements. The old components were `<button>` elements selectable by CSS type (`button[data-testid^='...']`). Native radio buttons are not `<button>` elements — the CSS type selector produces zero matches.

---

### Example 4: Marital Status (Account Owner Info page, PA Add Driver page)

| | Before | After |
|---|---|---|
| **Element type** | Custom `<button>` toggle with test ID | Native `<input type="radio">` with `<label>` |
| **Selector approach** | `button[data-testid^='owner.maritalStatus-']` + `HasTextString` filter | `GetByLabel()` |

**Before (broke):**
```csharp
private ILocator GetMaritalStatusButton(string maritalStatus) =>
    _page.Locator("button[data-testid^='owner.maritalStatus-']")
         .Filter(new() { HasTextString = maritalStatus });
```

**After (fixed):**
```csharp
private ILocator GetMaritalStatusButton(string maritalStatus) =>
    _page.Locator("[data-testid^='owner.maritalStatus-']").Filter(new() { HasText = maritalStatus.Trim() });
```

> The old locator used `button[data-testid^='owner.maritalStatus-']`. The options still have their `data-testid` attributes — the only bug was the `button` CSS type restriction. Radio inputs are not `<button>` elements. Fix: remove the element type prefix, keep the test ID selector.

Files: `Pages/ExpertQuotePages/AccountOwnerInfoPage.cs`, `Pages/ExpertQuotePages/PA/PA_AddDriverInfoPage.cs`

---

### Example 5: "Is the address where the client resides?" / "Received mail for 90 days?" (Account Owner Info page)

| | Before | After |
|---|---|---|
| **Element type** | Custom `<button>` toggle | Native radio button |
| **Selector approach** | `button[data-testid^='owner.address.useAsResidence']` + `HasTextString` | `[data-testid^='...']` + `HasText` (removed `button` type restriction) |

**Before (broke):**
```csharp
private ILocator GetClientResidesButton(string yesOrNo) =>
    _page.Locator("button[data-testid^='owner.address.useAsResidence']")
         .Filter(new() { HasTextString = yesOrNo });
```

**After (fixed):**
```csharp
private ILocator GetClientResidesButton(string yesOrNo) =>
    _page.Locator("[data-testid^='owner.address.useAsResidence']")
         .Filter(new() { HasText = yesOrNo });
```

Same pattern applied to `resided90days` (received mail question).
File: `Pages/ExpertQuotePages/AccountOwnerInfoPage.cs`

---

## Theme 3: Chip Tile No Longer Renders as `<button>` Role

**Root cause:** The "Create New Client" tile in the client search results changed from a `<button>` element (selectable via `GetByRole(Button, ...)`) to a styled chip/card component that has no button role.

---

### Example 6: "Create New Client" tile (New Client page / Shared EQ Steps)

| | Before | After |
|---|---|---|
| **Element type** | `<button>` with accessible name | Non-button chip element |
| **Selector approach** | `GetByRole(AriaRole.Button, "Create New Client")` | `GetByText("Create New Client", Exact=true)` |

**Before (broke):**
```csharp
private ILocator CreateNewClientButton =>
    _page.GetByRole(AriaRole.Button, new() { Name = "Create New Client" });
```

**After (fixed):**
```csharp
private ILocator CreateNewClientButton =>
    _page.GetByText("Create New Client", new() { Exact = true });
```

Files: `Pages/ExpertQuotePages/NewClientPage.cs`, `StepDefinitions/SharedSteps/SharedEQSteps.cs`

---

### Example 8: "Prior FFAN Policy" — Exposures Insured Yes/No (Claims/Prior Insurance page)

| | Before | After |
|---|---|---|
| **Test ID pattern** | `exposuresInsuredAN90Days.value-0` (Yes), `value-1` (No) | `value-chip-item-wrapper` (both share this ID) |

**Before (broke):**
```csharp
private ILocator ExposuresInsuredYesButton => _page.GetByTestId("...exposuresInsuredAN90Days.value-0");
private ILocator ExposuresInsuredNoButton  => _page.GetByTestId("...exposuresInsuredAN90Days.value-1");
```

**After (fixed):**
```csharp
private ILocator GetExposuresInsuredButton(string yesOrNo) =>
    _page.GetByTestId("fields.data.policy.policyInput$exposuresInsuredAN90Days.value-chip-item-wrapper")
         .Filter(new() { HasText = yesOrNo }).First;
```

Same pattern applied to `fullyCancelled` and `transferUnearnedPremium` Yes/No chips on the same page.
File: `Pages/ExpertQuotePages/ClaimsPriorInsurancePage.cs`

---

### Example 9: Years of Continuous Coverage chips (Claims/Prior Insurance page)

| | Before | After |
|---|---|---|
| **Test ID pattern** | `yearsMaintainedContinuousInsuranceCoverage.value-0` through `value-3` | `value-chip-item-wrapper` (all 4 share this ID) |

**Before (broke):**
```csharp
private ILocator YearsCoverageNoPriorButton => _page.GetByTestId("...value-0");
private ILocator YearsCoverage1YearButton   => _page.GetByTestId("...value-1");
private ILocator YearsCoverage2YearsButton  => _page.GetByTestId("...value-2");
private ILocator YearsCoverage3PlusButton   => _page.GetByTestId("...value-3");
```

**After (fixed):**
```csharp
private ILocator GetYearsContinuousCoverageButton(string chipLabel) =>
    _page.GetByTestId("fields.data.policy.policyUnderwriting.policyUnderwritingInput$yearsMaintainedContinuousInsuranceCoverage.value-chip-item-wrapper")
         .Filter(new() { HasText = chipLabel }).First;
```

Chip labels in DOM: `"No Prior Carrier"`, `"1 year"`, `"2 years"`, `"3+ years"` — input values mapped to these exact labels.
File: `Pages/ExpertQuotePages/ClaimsPriorInsurancePage.cs`

---

### Example 10: Primary Insured client suggestion chip (Primary Insured page)

| | Before | After |
|---|---|---|
| **Test ID pattern** | `temp.clientSuggestions-0` (index-based) | `temp.clientSuggestions-cif-client-{clientId}-chip` (dynamic CIF ID embedded) |
| **Container test ID** | None | `temp.clientSuggestions` (stable parent) |

**Before (broke):**
```csharp
private ILocator SelectExistingClientButton => _page.GetByTestId("temp.clientSuggestions-0");
```

**After (fixed):**
```csharp
private ILocator SelectExistingClientButton =>
    _page.GetByTestId("temp.clientSuggestions").Locator("[data-testid$='-chip']").First;
```

> The chip now embeds a real CIF client ID in its test ID, making the full ID unpredictable. Fix scopes to the stable container and selects the first `*-chip` descendant.

File: `Pages/ExpertQuotePages/SFP/SFP_PrimaryInsuredPage.cs`

---

### Example 11: Location Type chips (Location Info page)

| | Before | After |
|---|---|---|
| **Element type** | `<button>` toggle (`mat-button-toggle`) | Still `mat-button-toggle` (NOT a chip component) |
| **Test ID pattern** | None — selected by `GetByRole(Button, Name="Both")` | No test ID on options — locate by element type + text |
| **Selected state class** | `mat-button-toggle-checked` | `mat-button-toggle-checked` (unchanged) |

**Before (broke):**
```csharp
private ILocator LocationTypeButton(string typeText) =>
    _page.GetByRole(AriaRole.Button, new() { Name = typeText });
```

**After (fixed):**
```csharp
private ILocator LocationTypeButton(string typeText) =>
    _page.Locator("mat-button-toggle").Filter(new() { HasText = typeText }).First;
```

`GetByRole(Button, Name=text)` broke because the accessible name resolution changed post-upgrade. Locating by Angular Material component element type (`mat-button-toggle`) + text filter is more stable. These are NOT chip components despite other fields on the same page being chips.
File: `Pages/ExpertQuotePages/LocationPage.cs`

---

### Example 12: Wind/Hail deductible option visibility (Location Info page)

| | Before | After |
|---|---|---|
| **Chip options** | All deductible options (N/A, 1%, 2%, 5%, etc.) visible as direct chips | All options hidden behind "More Options" overflow — only "More Options" button visible |
| **Verify impact** | `button[data-testid*='...'].InnerText` collected all options directly | Only "MOREOPTIONS" collected; `Contains("1%")` assertion failed |
| **Element type** | `<button>` chip elements | Chip divs (`chip-item-wrapper`) for options + `<button>` for "More Options" |

**Before (broke):**
```csharp
// VerifyWindHailDeductibleOptionsAsync
var buttons = scope.Locator("button[data-testid*='locationInput$windHailDeductible.value']");
// buttonCount=1, optionTexts=["MOREOPTIONS"] → Assert("1%" in list) → FAIL
```

**After (fixed):**
```csharp
// Removed `button` CSS type prefix from option locator
var buttons = scope.Locator("[data-testid*='locationInput$windHailDeductible.value']");

// After collecting visible options, if no numeric options found → expand overflow:
if (!hasNumericOptions && moreOptionsVisible)
{
    // Click More Options → collect menu items → Escape to close
    // optionTexts now includes: ["MOREOPTIONS", "N/A", "1%", "2%", "5%"]
}
```

Also removed `buttons.Nth(aboveIdx).IsEnabledAsync()` from above-min check — index no longer maps to button locator after overflow expansion.
File: `Pages/ExpertQuotePages/LocationPage.cs`

---

### Example 13: Add Residence button test ID (Locations/Residences/Buildings page)

| | Before | After |
|---|---|---|
| **Test ID** | `HD1Residence-nav` | `fields.data.accountDetail.locationDetail.rows[{row}].addResidenceButton` |
| **Signature** | `AddResidenceButton()` (no parameter) | `AddResidenceButton(int row = 0)` |

**Before (broke):**
```csharp
public ILocator AddResidenceButton() =>
    _page.GetByTestId("HD1Residence-nav");
```

**After (fixed):**
```csharp
public ILocator AddResidenceButton(int row = 0) =>
    _page.GetByTestId($"fields.data.accountDetail.locationDetail.rows[{row}].addResidenceButton");
```

Matches same row-indexed pattern as `AddBuildingButton`. Consistent with `fields.data.accountDetail.locationDetail.rows[{row}].xxx` naming convention established by other buttons on this page.
File: `Pages/ExpertQuotePages/SFP/SFP_LocationsResidencesBuildingsPage.cs`

---

### Example 14: Add Residence form — 16 indexed chip locators (SFP_AddResidencePage)

| | Before | After |
|---|---|---|
| **Fields affected** | Occupancy, NumberOfFamilies, ServicePanel, ConditionRating, VacantSeasonal, SolidFuel | Same fields |
| **Old pattern** | `buildingInput$occupancy.value-0`, `...value-1`, etc. | `buildingInput$occupancy.value-chip-item-wrapper` + `HasText` + `.First` |
| **Count** | 16 individual indexed locator properties | 6 dynamic `GetXxxButton(string value)` methods |

**Before (broke):**
```csharp
public ILocator OwnerButton => _page.GetByTestId("fields.building.rows[0].buildingInput$occupancy.value-0");
public ILocator TenantButton => _page.GetByTestId("fields.building.rows[0].buildingInput$occupancy.value-1");
// ... 14 more
```

**After (fixed):**
```csharp
private ILocator GetOccupancyButton(string value) =>
    _page.GetByTestId("fields.building.rows[0].buildingInput$occupancy.value-chip-item-wrapper")
         .Filter(new() { HasText = value }).First;
// Same pattern for: GetNumberOfFamiliesButton, GetServicePanelButton,
//                   GetConditionRatingButton, GetVacantSeasonalButton, GetSolidFuelButton
```

File: `Pages/ExpertQuotePages/SFP/SFP_AddResidencePage.cs`

---

### Example 15: Residence Coverage Detail — 6 indexed chip locators (SFP_ResidenceCoveragePage)

| | Before | After |
|---|---|---|
| **Fields affected** | ThermostatQuestion (Yes/No), EstimatorType (RCT), ValuationType (Standard/No Defaults/High Value) | Same fields |
| **Old pattern** | `buildingThermostatQuestion.value-0`, `...value-1`, etc. | `buildingThermostatQuestion.value-chip-item-wrapper` + `HasText` + `.First` |
| **Count** | 6 individual indexed locator properties | 3 dynamic methods + 1 static property |

**Before (broke):**
```csharp
public ILocator ThermostatYesButton => _page.GetByTestId("...buildingThermostatQuestion.value-1");
public ILocator ThermostatNoButton  => _page.GetByTestId("...buildingThermostatQuestion.value-0");
public ILocator EstimatorTypeRCTButton => _page.GetByTestId("...estimatorType.value-0");
// ... 3 more valuation type buttons
```

**After (fixed):**
```csharp
private ILocator GetThermostatButton(string yesOrNo) =>
    _page.GetByTestId("fields.building.rows[0].buildingThermostatQuestion.value-chip-item-wrapper")
         .Filter(new() { HasText = yesOrNo }).First;

public ILocator EstimatorTypeRCTButton =>
    _page.GetByTestId("fields.building.rows[0].buildingValuatioinInput$estimatorType.value-chip-item-wrapper")
         .Filter(new() { HasText = "RCT" }).First;

private ILocator GetValuationTypeChip(string text) =>
    _page.GetByTestId("fields.building.rows[0].buildingValuatioinInput$valuationType.value-chip-item-wrapper")
         .Filter(new() { HasText = text }).First;
```

File: `Pages/ExpertQuotePages/SFP/SFP_ResidenceCoveragePage.cs`

---

### Example 16: Equipment Breakdown eligibility — 8 indexed chip locators (SFP_EquipmentBreakdownPage)

| | Before | After |
|---|---|---|
| **Fields affected** | PowerGeneration, TwoOrMoreLossIn24Month, LossGreaterThan24KEver, FarmImplement (each Yes/No) | Same fields |
| **Old pattern** | `covEquipmentBreakdownInput$powerGeneration.value-0`, `...value-1`, etc. | `...value-chip-item-wrapper` + `HasText "Yes"/"No"` + `.First` |
| **Count** | 8 individual indexed `Yes/No` properties | 8 properties rewritten with chip-item-wrapper + HasText |

**Before (broke):**
```csharp
public ILocator PowerGenerationYesButton =>
    _page.GetByTestId("fields.line.covEquipmentBreakdownPowerGeneration.covEquipmentBreakdownInput$powerGeneration.value-1");
public ILocator PowerGenerationNoButton =>
    _page.GetByTestId("fields.line.covEquipmentBreakdownPowerGeneration.covEquipmentBreakdownInput$powerGeneration.value-0");
// ... 6 more
```

**After (fixed):**
```csharp
public ILocator PowerGenerationYesButton =>
    _page.GetByTestId("fields.line.covEquipmentBreakdownPowerGeneration.covEquipmentBreakdownInput$powerGeneration.value-chip-item-wrapper")
         .Filter(new() { HasText = "Yes" }).First;
public ILocator PowerGenerationNoButton =>
    _page.GetByTestId("fields.line.covEquipmentBreakdownPowerGeneration.covEquipmentBreakdownInput$powerGeneration.value-chip-item-wrapper")
         .Filter(new() { HasText = "No" }).First;
// Same pattern for: TwoOrMoreLoss, LossGreaterThan24K, FarmImplement
```

File: `Pages/ExpertQuotePages/SFP/SFP_EquipmentBreakdownPage.cs`

---

### Example 17: Liability Base Coverage toggle — 2 indexed chip locators (SFP_LiabilityPage)

| | Before | After |
|---|---|---|
| **Fields affected** | BaseLiabilityYesButton, BaseLiabilityNoButton | Same fields |
| **Old pattern** | `lineCoverages$isBaseLiability.value-1`, `...value-0` | `lineCoverages$isBaseLiability.value-chip-item-wrapper` + `HasText` |
| **Count** | 2 indexed properties | 2 properties rewritten |

**Before (broke):**
```csharp
public ILocator BaseLiabilityYesButton =>
    _page.GetByTestId("fields.line.lineCoverages$isBaseLiability.value-1");
public ILocator BaseLiabilityNoButton =>
    _page.GetByTestId("fields.line.lineCoverages$isBaseLiability.value-0");
```

**After (fixed):**
```csharp
public ILocator BaseLiabilityYesButton =>
    _page.GetByTestId("fields.line.lineCoverages$isBaseLiability.value-chip-item-wrapper")
         .Filter(new() { HasText = "Yes" }).First;
public ILocator BaseLiabilityNoButton =>
    _page.GetByTestId("fields.line.lineCoverages$isBaseLiability.value-chip-item-wrapper")
         .Filter(new() { HasText = "No" }).First;
```

File: `Pages/ExpertQuotePages/SFP/SFP_LiabilityPage.cs`

---

### Example 18: Mortgagee/Loss Payee form — 5 indexed locators (SFP_MortgageeLossPayeePage)

| | Before | After |
|---|---|---|
| **Fields affected** | FirstResidenceOption, ProofOfCoverageRequired (Yes/No), MortgageeResponsibleForEscrow (Yes/No) | Same fields |
| **Old pattern** | `additionalOtherInterestInput$proofOfCoverageRequired.value-0` (index-based) | `...value-chip-item-wrapper` + `HasText` / `.First` |
| **Count** | 5 indexed locators | 5 properties rewritten |

**Before (broke):**
```csharp
public ILocator FirstResidenceOption =>
    _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$buildingID.value-0");
public ILocator ProofOfCoverageYesButton =>
    _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$proofOfCoverageRequired.value-1");
public ILocator ProofOfCoverageNoButton =>
    _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$proofOfCoverageRequired.value-0");
// ... EscrowBilled Yes/No same pattern
```

**After (fixed):**
```csharp
public ILocator FirstResidenceOption =>
    _page.GetByRole(AriaRole.Option).First;

public ILocator ProofOfCoverageYesButton =>
    _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$proofOfCoverageRequired.value-chip-item-wrapper")
         .Filter(new() { HasText = "Yes" }).First;
public ILocator ProofOfCoverageNoButton =>
    _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$proofOfCoverageRequired.value-chip-item-wrapper")
         .Filter(new() { HasText = "No" }).First;

public ILocator EscrowBilledYesButton =>
    _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$mortgageeResponsibleForEscrow.value-chip-item-wrapper")
         .Filter(new() { HasText = "Yes" }).First;
public ILocator EscrowBilledNoButton =>
    _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$mortgageeResponsibleForEscrow.value-chip-item-wrapper")
         .Filter(new() { HasText = "No" }).First;
```

Note: `value-0` for ProofOfCoverage was the **No** option (reversed from typical Yes=1/No=0 convention). With `HasText`, the chip order no longer matters — correctness is guaranteed by text match.
File: `Pages/ExpertQuotePages/SFP/SFP_MortgageeLossPayeePage.cs`

---

## Summary of Test ID Contract Issues

| Issue | Impact on Test Automation |
|---|---|
| Multiple chips sharing one `data-testid` | Cannot use `GetByTestId()` alone — must add text filter, making tests brittle to label changes |
| Nested elements both carrying the same `data-testid` | Must use `.First` to avoid strict-mode violations — fragile if DOM structure shifts |
| Two different chip component variants (`chip-item-wrapper` vs `chip-wrapper`) | Cannot write a single consistent fix pattern |
| Indexed IDs removed entirely | Every field that previously had stable per-option IDs must be re-examined |
| Custom toggle → native radio with no test ID on option | Some fields have no test ID on options at all; must fall back to `GetByLabel` (label text = test data) |

---

## Ask for EQ Team

1. **Restore per-option unique test IDs** — each selectable chip/option should have a unique `data-testid` that identifies both the field and the option value (e.g. `industrialHemp.value-yes`, `industrialHemp.value-no`). Index-based is acceptable.
2. **Do not put the same `data-testid` on nested parent and child elements** — causes strict-mode violations requiring fragile workarounds.
3. **Standardize chip component test ID suffix** — the current deployment has both `chip-item-wrapper` and `chip-wrapper` suffixes across different fields. Pick one.
4. **Treat `data-testid` attributes as a stability contract** — test ID changes should be flagged as breaking changes in the QA changelog so automation can be updated in advance.

---

*This document will be updated as additional broken locators are discovered during the fix cycle.*
