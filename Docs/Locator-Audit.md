# Locator Audit — GetByTestId Compliance

**Rule:** Every EQ interactive element (button, chip, toggle, input, radio, checkbox) MUST be located via `GetByTestId()`. `GetByRole`, `GetByText`, and `GetByLabel` are NOT acceptable for interactive elements. They are only acceptable for:
- Angular Material dropdown overlay options (`AriaRole.Option`) — these have no `data-testid`
- Context menu items (`AriaRole.Menuitem`) — no `data-testid`
- Page header text used only as a load/visibility assertion (not clicked)

Shared control definitions must list `GetByTestId` first. An exact HTML `id`
may be added only through `WithDocumentedAniIdFallback`, with a reference to an
entry in the exception table below. Generic CSS fallback and locator
substitution are not supported. Locator rescue logs candidates only; it never
changes the locator used by the test.

## ANi HTML-ID Exceptions

| Exception | Page | HTML `id` | Reason |
|-----------|------|-----------|--------|
| `ANI-ID-001` | `ClientSearchPage` | `new-quote-button` | ANi-owned navigation control migrated from `data-testid` |
| `ANI-ID-002` | `QuoteDetailsPage` | `startQuote` | ANi-owned quote-start control with a stable application ID |
| `ANI-ID-003` | `SFP_ChecklistPage` | `exception-note-confirm` | ANi-owned modal confirmation control with a stable application ID |
| `ANI-ID-004` | `SFP_PricingPage` | `*FullPremiumTotalPremiumSumm*` | ANi-owned generated premium summary ID; used only for exact premium text extraction |
| `ANI-ID-005` | `ExpertQuoteBopPilotPage` | `customer.name.first` | SGS-audited client first-name input; pilot is blocked until the destination DOM test ID is confirmed |
| `ANI-ID-006` | `ExpertQuoteBopPilotPage` | `customer.name.last` | SGS-audited client last-name input; pilot is blocked until the destination DOM test ID is confirmed |
| `ANI-ID-007` | `ExpertQuoteBopPilotPage` | `customer.dateOfBirth` | SGS-audited date-of-birth input; pilot is blocked until the destination DOM test ID is confirmed |
| `ANI-ID-008` | `ExpertQuoteBopPilotPage` | `owner.phone` | SGS-audited owner phone input; pilot is blocked until the destination DOM test ID is confirmed |
| `ANI-ID-009` | `ExpertQuoteBopPilotPage` | `owner.email` | SGS-audited owner email input; pilot is blocked until the destination DOM test ID is confirmed |
| `ANI-ID-010` | `ExpertQuoteBopPilotPage` | `owner.address.line1` | SGS-audited account street input; pilot is blocked until the destination DOM test ID is confirmed |
| `ANI-ID-011` | `ExpertQuoteBopPilotPage` | `owner.address.city` | SGS-audited account city input; pilot is blocked until the destination DOM test ID is confirmed |
| `ANI-ID-012` | `ExpertQuoteBopPilotPage` | `owner.address.state` | SGS-audited account state input; pilot is blocked until the destination DOM test ID is confirmed |
| `ANI-ID-013` | `ExpertQuoteBopPilotPage` | `owner.address.zip` | SGS-audited account ZIP input; pilot is blocked until the destination DOM test ID is confirmed |
| `ANI-ID-014` | `ExpertQuoteBopPilotPage` | `business.isIndividualDba-checkbox` | SGS-audited DBA ownership checkbox; exact checked state is required |
| `ANI-ID-015` | `ExpertQuoteBopPilotPage` | `business.individualDba` | SGS-audited DBA-name input; pilot is blocked until the destination DOM test ID is confirmed |
| `ANI-ID-016` | `ExpertQuoteBopPilotPage` | `proposal.effectiveDate` | SGS-audited effective-date input; pilot requires a current QA-approved date |
| `ANI-ID-017` | `ExpertQuoteBopPilotPage` | `proposal.riskAddressSelection-0-input` | SGS-audited account-address selection; exact checked state is required |
| `ANI-ID-018` | `ExpertQuoteBopPilotPage` | `proposal.ratingState` | SGS-audited rating-state input; exact selected value is required |
| `ANI-ID-019` | `ExpertQuoteBopPilotPage` | `proposal.agentPC` | SGS-audited agent-code input; pilot requires authorization approval |
| `ANI-ID-020` | `ExpertQuoteBopPilotPage` | `ssn` | SGS-audited SSN input; the value must come from an externally approved QA profile |
| `ANI-ID-021` | `ExpertQuoteBopPilotPage` | `btnConfirmYes` | SGS-audited confirmation button; used only after semantic input postconditions pass |
| `ANI-ID-022` | `ExpertQuoteBopPilotPage` | `quoteSearchInput` | SGS-audited quote-search input; pilot is blocked until exact destination behavior is confirmed |
| `ANI-ID-023` | `ExpertQuoteBopPilotPage` | `quoteSearchButton` | SGS-audited quote-search action; pilot is blocked until exact destination behavior is confirmed |

The ExpertQuote BOP pilot definitions always try the named `data-testid`
first. These HTML IDs are explicit ANi exceptions, not an auto-heal path. Five
workflow boundaries remain blocked because the SGS source did not provide a
reliable destination control for client search, prefill outcome, active quote
identity, close, or retrieved quote identity.

## Commercial DuckCreek BAP pilot

The Phase 7B SGS audit found no invoked `data-testid` selectors. It found
source `fieldref` selectors, exact accessible-role links, login HTML IDs, and
the generic frame recipe `iframe`. None is approved as a destination fallback:
there are no new `ANI-ID-*` exceptions for the CLDC pilot.

The module therefore blocks login, proposal start, client/profile, masked
identity, policy, score, BAP fields, stable frame paths, quote save, search,
and reopen. Before any boundary can become runnable, the application owner
must supply exact destination `data-testid` evidence. Any unavoidable ANi
HTML-ID fallback requires a new row in the exception table and test-ID-first
ordering. `fieldref`, role, text, generic CSS, and bare `iframe` selectors are
not silent rescue paths.

---

## Status Legend
- ✅ Fixed
- 🔴 Needs Fix — test ID exists or should exist; must use `GetByTestId`
- 🟡 Needs DOM Inspection — test ID unknown; must inspect before fixing
- ⚪ Acceptable — no test ID exists on this element type (dropdown options, headers)

---

## Pages\ExpertQuotePages\AccountOwnerInfoPage.cs

| Status | Line | Locator | Issue | Fix |
|--------|------|---------|-------|-----|
| ✅ | 39 | `GetMaritalStatusButton` | Was `GetByLabel` | Fixed → `[data-testid^='owner.maritalStatus-']` + `HasText` |
| ✅ | 37 | `GetClientResidesButton` | Was `button[data-testid...]` | Fixed → `[data-testid^='owner.address.useAsResidence']` + `HasText` |
| ✅ | 35 | `GetReceivedMailButton` | Was `button[data-testid...]` + `HasTextString` | Fixed → `[data-testid^='owner.address.resided90days-']` + `HasText` |
| ⚪ | 16 | `PageHeader` | `GetByRole(Heading)` | Heading assertion only — no test ID exists |
| 🟡 | 44 | `GetMoreOptionsValue` | `GetByRole(Button, Name=value)` | "More Options" overflow items — inspect for test ID |
| ⚪ | 146 | State select option | `GetByRole(Option)` | Angular Material overlay — no test ID |

---

## Pages\ExpertQuotePages\SFP\SFP_ResidenceCoveragePage.cs

| Status | Line | Locator | Issue | Fix |
|--------|------|---------|-------|-----|
| ✅ | dynamic | `GetThermostatButton(string)` | Was `buildingThermostatQuestion.value-0/1` (indexed) | Fixed → `value-chip-item-wrapper` + `HasText` + `.First` |
| ✅ | dynamic | `EstimatorTypeRCTButton` | Was `estimatorType.value-0` (indexed) | Fixed → `value-chip-item-wrapper` + `HasText = "RCT"` |
| ✅ | dynamic | `GetValuationTypeChip(string)` | Was `valuationType.value-0/1/2` (indexed) | Fixed → `value-chip-item-wrapper` + `HasText` + `.First` |

---

## Pages\ExpertQuotePages\SFP\SFP_InsuranceScorePage.cs

| Status | Locator | Resolution |
|--------|---------|------------|
| ✅ | Insurance score consent | Shared `ControlScopeResolver`, exact test ID |
| ✅ | Accept/Decline decision | Shared resolver across main page, popup pages, and nested frames; ambiguous matches fail |
| ✅ | Decision action | Shared semantic click verifies enabled state and the actual selected state |

---

## Pages\ExpertQuotePages\SFP\SFP_EquipmentBreakdownPage.cs

| Status | Line | Locator | Issue | Fix |
|--------|------|---------|-------|-----|
| ✅ | dynamic | `PowerGenerationYesButton`/`NoButton` | Was `covEquipmentBreakdownInput$powerGeneration.value-1/0` | Fixed → `value-chip-item-wrapper` + `HasText = "Yes"/"No"` |
| ✅ | dynamic | `TwoOrMoreLossIn24MonthYesButton`/`NoButton` | Was `...twoOrMoreLossIn24Month.value-1/0` | Fixed → chip-item-wrapper + HasText |
| ✅ | dynamic | `LossGreaterThan24KEverYesButton`/`NoButton` | Was `...lossGreaterThan24KEver.value-1/0` | Fixed → chip-item-wrapper + HasText |
| ✅ | dynamic | `FarmImplementYesButton`/`NoButton` | Was `...farmImplement.value-1/0` | Fixed → chip-item-wrapper + HasText |

---

## Pages\ExpertQuotePages\SFP\SFP_LiabilityPage.cs

| Status | Line | Locator | Issue | Fix |
|--------|------|---------|-------|-----|
| ✅ | dynamic | `BaseLiabilityYesButton` | Was `lineCoverages$isBaseLiability.value-1` (indexed) | Fixed → `value-chip-item-wrapper` + `HasText = "Yes"` |
| ✅ | dynamic | `BaseLiabilityNoButton` | Was `lineCoverages$isBaseLiability.value-0` (indexed) | Fixed → `value-chip-item-wrapper` + `HasText = "No"` |
| ⚪ | dynamic | `LimitOption(int index)` | `GetByRole(Option)` | Angular Material select overlay — no test ID |

---

## Pages\ExpertQuotePages\SFP\SFP_MortgageeLossPayeePage.cs

| Status | Line | Locator | Issue | Fix |
|--------|------|---------|-------|-----|
| ✅ | 44 | `FirstResidenceOption` | Was `additionalOtherInterestInput$buildingID.value-chip-item-wrapper.First` — wrong: it's a mat-select dropdown, not a chip | Fixed → `GetByRole(AriaRole.Option).First` (mat-select overlay — no test ID exists) |
| ✅ | 53 | `ProofOfCoverageYesButton` | Was `proofOfCoverageRequired.value-1` (indexed) | Fixed → `value-chip-item-wrapper` + `HasText = "Yes"` |
| ✅ | 56 | `ProofOfCoverageNoButton` | Was `proofOfCoverageRequired.value-0` (indexed) | Fixed → `value-chip-item-wrapper` + `HasText = "No"` |
| ✅ | 59 | `EscrowBilledYesButton` | Was `mortgageeResponsibleForEscrow.value-1` (indexed) | Fixed → `value-chip-item-wrapper` + `HasText = "Yes"` |
| ✅ | 62 | `EscrowBilledNoButton` | Was `mortgageeResponsibleForEscrow.value-0` (indexed) | Fixed → `value-chip-item-wrapper` + `HasText = "No"` |
| ⚪ | dynamic | `FirstSearchResultCheckbox` | Inner scoped `GetByTestId` | Already uses test ID — no change needed |

---

## Pages\ExpertQuotePages\BillingPage.cs

| Status | Line | Locator | Issue | Fix |
|--------|------|---------|-------|-----|
| 🟡 | 21 | `GetPrimaryPayerButton` | `GetByRole(Button, Name)` | Inspect DOM for test ID |
| 🟡 | 24 | `GetPaymentTypeButton` | `GetByRole(Button, Name)` | Inspect DOM for test ID |
| 🟡 | 27 | `GetPaymentPlanButton` | `GetByRole(Button, Name)` | Inspect DOM for test ID |
| 🟡 | 30 | `GetPaymentAmountRadioButton` | `GetByRole(Radio, Name)` | Inspect DOM for test ID |
| 🟡 | 33 | `GetPaymentMethodButton` | `GetByRole(Button, Name)` | Inspect DOM for test ID |
| 🟡 | 36 | `GetPaperlessCommunicationButton` | `GetByRole(Button, Name)` | Inspect DOM for test ID |

**DevTools command to run on Billing page:**
```js
document.querySelectorAll('[data-testid]').forEach(el => {
  if (el.tagName === 'BUTTON' || el.tagName === 'INPUT' || el.dataset.testid.includes('billing') || el.dataset.testid.includes('payment') || el.dataset.testid.includes('payer'))
    console.log(el.dataset.testid, el.textContent.trim().slice(0,40))
})
```

---

## Pages\ExpertQuotePages\ClientSearchPage.cs

| Status | Line | Locator | Issue | Fix |
|--------|------|---------|-------|-----|
| ⚪ | 17 | `DashboardElement` | `GetByText("Quote")` | Navigation detection only |
| ⚪ | 18 | `PageHeader` | `GetByText(...)` | Page header assertion only |
| 🟡 | 20 | `SearchButton` | `GetByRole(Button, "Search")` | Inspect for test ID |
| ⚪ | dynamic | Exact quote result link | `GetByRole(Link, quote identity, Exact=true)` | Search result exposes no known test ID; exact accessible identity is required and ambiguity fails |

---

## Pages\ExpertQuotePages\SubmissionPage.cs

| Status | Line | Locator | Issue | Fix |
|--------|------|---------|-------|-----|
| ✅ | dynamic | `TransmitButton` | `GetByTestId("fields.data.submission.transmit")` | Primary readiness locator |
| ⚪ | dynamic | `TransmitButtonAlt` | `GetByRole(Button, "Transmit")` | Exact accessible fallback only when the test ID is absent; multiple matches fail |

---

## Pages\ExpertQuotePages\ExpertQuoteLoginPage.cs

| Status | Line | Locator | Issue | Fix |
|--------|------|---------|-------|-----|
| ⚪ | 24 | `NewQuoteButton` | `GetByRole(Button, "New Quote")` | Login success detection; Ping SSO — EQ-owned but used only as nav assertion |

---

## Pages\ExpertQuotePages\LocationPage.cs

| Status | Line | Locator | Issue | Fix |
|--------|------|---------|-------|-----|
| ✅ | 46 | `LocationTypeButton` | Was `GetByRole(Button, Name)` — accessible name resolution broke | Fixed → `mat-button-toggle` element type + `HasText` + `.First`. Selected check: `mat-button-toggle-checked`. |
| ✅ | 123 | WH deductible option locator | Was `button[data-testid*='...']` — EQ upgrade moved options to overflow; chip divs not buttons | Fixed → `[data-testid*='...']` (no `button` prefix); verify now expands overflow menu when no numeric options are visible |
| ⚪ | 93 | State dropdown option | `.cdk-overlay-pane mat-option` GetByText | Angular Material overlay |
| ⚪ | 118 | Wind Hail "More Options" | `GetByRole(Button, "More Options")` | Context button — inspect but likely no test ID |
| ⚪ | 122 | Wind Hail menu item | `GetByRole(Menuitem)` | Context menu — no test IDs |

**DevTools command to run on Location Info page:**
```js
document.querySelectorAll('[data-testid*="locationType"],[data-testid*="locationInput"]').forEach(el => console.log(el.dataset.testid, el.textContent.trim().slice(0,40)))
```

---

## Pages\ExpertQuotePages\NewClientPage.cs

| Status | Line | Locator | Issue | Fix |
|--------|------|---------|-------|-----|
| 🟡 | 23 | `SearchButton` | `GetByRole(Button, "Search")` | Inspect for test ID |
| 🟡 | 24 | `CreateNewClientButton` | `GetByText("Create New Client")` | Inspect for chip test ID |

**DevTools command to run on New Client page:**
```js
document.querySelectorAll('[data-testid]').forEach(el => console.log(el.dataset.testid, el.textContent.trim().slice(0,40)))
```

---

## Pages\ExpertQuotePages\PreQualificationsPage.cs

| Status | Line | Locator | Issue | Fix |
|--------|------|---------|-------|-----|
| ✅ | dynamic | `GetQualificationSelection("None Of The Above")` | Uses specific test ID via `mat-checkbox:has(...)` | OK |
| 🟡 | 33 | `GetQualificationSelection(other values)` | `GetByRole(Button, Name)` | Inspect for test IDs |

---

## Pages\ExpertQuotePages\QuoteDetailsPage.cs

| Status | Line | Locator | Issue | Fix |
|--------|------|---------|-------|-----|
| ✅ | 18-23 | `FarmPackageButton` etc. | Was `GetByTestId("proposal.product-N")` | Fixed → `chip-item-wrapper` + `HasText` + `.First` |
| ⚪ | 17 | `PageHeader` | `GetByText("Proposal Details")` | Page load assertion only |
| ⚪ | 47 | `SSNPopup` | `GetByRole(Heading)` | Popup detection only |
| ⚪ | 112 | `Expect(GetByText("Quote Details"))` | Inline wait assertion | Assertion only |

---

## Pages\ExpertQuotePages\SubmissionPage.cs

| Status | Line | Locator | Issue | Fix |
|--------|------|---------|-------|-----|
| ⚪ | 21 | `ChecklistButtonAlt` | `GetByRole(Button)` | Primary `ChecklistButton` uses `GetByTestId` — Alt is fallback only |
| ⚪ | 29/32 | `NoReferralsText` | `GetByText(...)` | Text assertion, no test ID on display text |
| ⚪ | 39 | `TransmitButtonAlt` | `GetByRole(Button)` | Primary `TransmitButton` uses `GetByTestId` — Alt is fallback only |

---

## Pages\ExpertQuotePages\UnderwritingPage.cs

| Status | Line | Locator | Issue | Fix |
|--------|------|---------|-------|-----|
| 🟡 | 13 | `GetConvictedOfFelonyButton` | `[id*='felonyConviction']` + `GetByRole(Button)` | Inspect for test ID on the Yes/No options |

**DevTools command to run on Underwriting page:**
```js
document.querySelectorAll('[data-testid*="felony"],[data-testid*="Conviction"],[id*="felonyConviction"] [data-testid]').forEach(el => console.log(el.dataset.testid, el.textContent.trim()))
```

---

## Pages\ExpertQuotePages\AddClaimPage.cs

| Status | Line | Locator | Issue | Fix |
|--------|------|---------|-------|-----|
| 🟡 | 46 | `DateOfOccurrenceInput` | `GetByRole(Textbox).Nth(0)` | Inspect claim dialog for test ID |
| 🟡 | 47 | `OpenCalendarButton` | `GetByRole(Button, "Open calendar")` | Likely a Material datepicker — may not have test ID |
| ⚪ | 81/87 | Type/Cause of loss options | `GetByRole(Option)` | Angular Material overlay |

---

## Pages\ExpertQuotePages\ClaimsPriorInsurancePage.cs

| Status | Line | Locator | Issue | Fix |
|--------|------|---------|-------|-----|
| ⚪ | 12/13 | `NoClaimsBanner`, `NoViolationsBanner` | `GetByText(...)` | Text assertion only |
| ⚪ | 110 | Reason dropdown option | `GetByRole(Option)` | Angular Material overlay |
| ✅ | 25-26 | `ExposuresInsuredYesButton` / `NoButton` | Was `value-0` / `value-1` | Fixed → `value-chip-item-wrapper` + `HasText` + `.First` |
| ✅ | 29-30 | `FullyCancelledYesButton` / `NoButton` | Was `value-0` / `value-1` | Fixed → `value-chip-item-wrapper` + `HasText` + `.First` |
| ✅ | 33-34 | `TransferUnearnedPremiumYesButton` / `NoButton` | Was `value-0` / `value-1` | Fixed → `value-chip-item-wrapper` + `HasText` + `.First` |
| ✅ | 37-40 | `YearsCoverageNoPriorButton` through `3PlusButton` | Was `value-0` through `value-3` | Fixed → `value-chip-item-wrapper` + `HasText` + `.First` |

---

## Pages\ExpertQuotePages\SFP\SFP_PolicyDetailsPage.cs

| Status | Line | Locator | Issue | Fix |
|--------|------|---------|-------|-----|
| ✅ | 14 | `GetPrimaryFarmCategoryButton` | Was `GetByTestId("...value-N")` | Fixed → `chip-item-wrapper` + `HasText` + `.First` |
| ✅ | 20 | `GetSecondaryFarmCategoryButton` | Same | Fixed |
| ✅ | 42 | `GetGrowIndustrialHempButton` | Was `GetByTestId("...value-0/1")` | Fixed → `value-chip-wrapper` + `HasText` |

---

## Pages\ExpertQuotePages\SFP\SFP_PrimaryInsuredPage.cs

| Status | Line | Locator | Issue | Fix |
|--------|------|---------|-------|-----|
| ✅ | 20 | `SelectExistingClientButton` | Was `GetByTestId("temp.clientSuggestions-0")` | Fixed → container scoped `[data-testid$='-chip'].First` |
| 🟡 | 25 | `SearchButton` | Was `button:has-text('Search')` | Changed to `GetByTestId("temp.clientSearch-search")` — verify test ID in DOM |

---

## SFP Pages Still Under Investigation

These pages have not yet been run against the new EQ environment. Expect the same chip/radio patterns:

| File | Suspect Locators |
|------|-----------------|
| `SFP_LocationsResidencesBuildingsPage.cs` | `AddResidenceButton` fixed → `fields.data.accountDetail.locationDetail.rows[0].addResidenceButton`; `occupancy`, `rateType`, `seasonalVacant`, `solidFuel` still need inspection |
| `SFP_CoveragePage.cs` | `perils`, `actualCashValue`, `RCTOption`, thermostat question |
| `SFP_ClaimsPriorInsurancePage.cs` | `yearsContinuousCoverage`, `priorPolicy` |

Use DevTools on each page to enumerate test IDs before attempting fixes.

---

## Summary Counts

| Status | Count |
|--------|-------|
| ✅ Fixed | 40 |
| 🔴 Needs Fix (test ID known) | 0 |
| 🟡 Needs DOM Inspection | 12 |
| ⚪ Acceptable | 19 |
