# ExpertQuote BOP Alabama Pilot

Phase 7A adapts the business intent of the SGS
`03_EQ_BOP_Smoke_Test` into the existing PnC-TestAutomation architecture. It
does not import SGS lifecycle, browser, retry, reporting, pipeline, or generated
page infrastructure.

## Destination contract

- Module: `expertquote-bop-al-pilot`
- Stable automation identity: `EQ-BOP-SMOKE:AL`
- Data profile: `Resources/DataProfiles/eq-bop-pilot.json`
- Discovery owner: suite `ExpertQuotePilot`, shard `EqBopAlPilot`
- Execution state: `NonRunnable`, `NoRetry`
- Required reusable contracts: semantic controls and frame-preserving
  resolution, typed pilot data, scenario quote handoff, business outcomes,
  artifact evidence, canonical results, and Test Plans publishing.

The package mapping template lists `EQ-BOP-SMOKE:AL` as explicitly deferred.
That makes the pilot visible to validation while preventing a deferred mapping
from satisfying a gated publication request. Production scheduled matrices do
not include the pilot suite.

## Source audit and disposition

| SGS source | Destination disposition |
|------------|-------------------------|
| `Features/Smoke/03_EQ_BOP_Smoke_Test.feature` | Retain business-readable create/search/address/proposal/close/retrieve intent and source hash; replace implementation bindings |
| `StepDefinitions/EQBOPSmokeTestSteps.cs` | Retire bindings; adapt intent through one destination workflow service |
| `Pages/ApplicationPage.cs`, `ClientSearchPage.cs`, `AccountInformationPage.cs`, `ProposalPage.cs`, `SocialSecurityPage.cs`, `NavigationPage.cs`, `QuoteSearchPage.cs` | Audit exercised behavior; adapt only required controls through shared semantic contracts |
| Corresponding `Pages/Locators/*Locators.cs` files | Audit IDs; use test ID first with individually documented ANi HTML-ID exceptions; do not copy wrappers |
| `TestData/Scenarios/03_eq_bop_smoke_test_al.json` and layered `Base.json` / `StateOverrides.json` | Preserve hash provenance and safe business selections; replace flattened/silent resolution with typed precedence and checksum validation |
| SGS hooks, `BrowserSession`, retry generator, `UiActions`, reporters, pipelines, broad generated wrappers | Retire from this adaptation; existing destination services remain authoritative |

The source AL override is empty and the source base is byte-identical to the AL
scenario despite its `_MO` directory name. The profile records those facts
through exact source hashes rather than treating the directory name as state
authority.

## Retained and changed behavior

The pilot retains Alabama, Married, Business Owners, Individual ownership,
account-address use, no lessors-risk exposure, ALABAMA rating state, and
PreQualification navigation. Yes/no inputs are normalized to typed booleans.

Destination actions distinguish fill, select, toggle, and click and assert
value, selected, checked, or enabled postconditions. Resolution retains the
page/frame scope through the action. Quote identity is captured into
scenario-owned `IQuoteHandoff`, validated against an approved format, searched,
and compared exactly. Checkpoint screenshots are unique and contain no raw
identity or personal values in names or manifests.

The source workflow does not promise premium, forms, transmission, bind, or
issuance, so Phase 7A does not add those outcomes.

## Fail-closed blockers

The checked-in profile cannot run and cannot satisfy a gate. QA or application
owners must provide:

- approved non-production first/last name, date of birth, phone, email, SSN,
  street, city, ZIP, and DBA name;
- current effective date;
- authorization for the agent code;
- expected prefill result;
- authoritative quote identity format;
- destination DOM/test-ID evidence for the audited controls;
- reliable client-search, prefill-result, active-quote-identity, close, and
  retrieved-result controls;
- external ExpertQuote credentials;
- Azure DevOps plan/suite/test-case/configuration mapping when publication is
  approved.

Profile validation rejects missing keys, duplicate precedence, leaf collisions,
synthetic or secret-bearing data, stale provenance/checksums, and ambiguous
environment/state resolution. Credentials are external and are never part of
the profile. A profile cannot become `Approved` while required values are
missing. If a profile is changed to `Approved` before its module blockers are
cleared, preflight fails as a configuration error before browser work.
