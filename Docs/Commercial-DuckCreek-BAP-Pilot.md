# Commercial DuckCreek BAP Alabama Pilot

Phase 7B adapts the business intent of the SGS
`012_BAP_Smoke_Test` into the destination-owned PnC-TestAutomation contracts.
It does not copy SGS hooks, browser/session factories, `UiActions`,
`FrameExecutionContext`, retry generation, reporters, generated pages, or
pipelines.

## Destination contract

- Module: `commercial-duckcreek-bap-al-pilot`
- Stable automation identity: `CLDC-BAP-SMOKE:AL`
- Data profile: `Resources/DataProfiles/cldc-bap-pilot.json`
- Frame catalog: `Resources/FrameHints/cldc-bap-frame-hints.json`
- Discovery owner: suite `CommercialDuckCreekPilot`, shard
  `CldcBapAlPilot`
- Execution state: `NonRunnable`, `NoRetry`
- Required evidence includes unique screenshots, business outcomes, quote
  handoff, canonical TRX metadata, timing, and redacted runtime locator/frame
  records.

The package mapping template lists `CLDC-BAP-SMOKE:AL` as deferred. Production
schedules do not select its suite. Package validation discovers and executes
the isolated shard only to prove exactly one explicit `NotExecuted` result.

## Source audit and disposition

The provenance catalog records every file in the approved audit ledger. The
supplied ledger contains 46 distinct files (rather than the stated 45), and
none is omitted to force a target count.

| SGS source | Destination disposition |
|------------|-------------------------|
| `Features/Smoke/012_BAP_Smoke_Test.feature` | Retain the business-readable Alabama BAP client, policy, score, and BAP-field sequence; extend only with explicitly required quote save/search/reopen outcomes |
| `BAPSmokeTestSteps.cs` and `ApplicationSteps.cs` | Retire source bindings; one destination workflow owns the pilot checkpoints |
| Invoked `Pages/*` and `Pages/Locators/*` | Audit behavior and hashes; do not copy wrappers or fieldref/role selectors |
| `012_bap_smoke_test_al.json`, `ExternalDataOverrides.json`, and layered manifest | Preserve safe intent and hashes; replace direct/static flattened resolution with typed, checksummed profiles |
| `DuckCreekFrameHints.json` and frame/runtime resolvers | Retain the frame-hint concept; reject its generic `iframe` recipe and dropped-scope behavior |
| SGS hooks, core UI actions, retry generator, evidence finalizers/publishers | Retire from adaptation; shared destination lifecycle and evidence services remain authoritative |

The audited scenario JSON does not participate in the source layered manifest:
root discovery points to the wrong directory and the manifest has no AL BAP
entry. Its fixed `12-01-2025` dates are stale, and its versioned product value
requires application-owner approval. Neither value is carried into the
destination profile.

## Retained and changed behavior

Safe retained intent includes Alabama, Individual/Person,
Individual/Sole Proprietor, Male, six years in business, no prior coverage
within 90 days, Account Credit `No`, and an explicit NAICS search/selection
checkpoint. Approved values must be applied with semantic fill/select/toggle
operations and verified by actual value, selected, checked, and enabled
postconditions.

Masked identity is compared only to an approved mask pattern and must not equal
the full SSN. Runtime locator evidence hashes selector/runtime identities and
does not write entered values, credentials, SSNs, names, phones, addresses, or
quote descriptions. Each checkpoint gets a unique screenshot path.

The destination workflow requires a nonempty, pattern-validated insurance
score reference instead of the source blank equality check. It captures and
validates the quote description, captures an authoritative quote identity into
`IQuoteHandoff`, saves, searches, reopens, and exactly compares both identity
and description. The source did not promise premium, forms, bind/issue, or
transmission outcomes, so Phase 7B does not invent them.

Required frame controls name a versioned logical scope. A scope maps to one
exact page index, positive frame depth, and stable frame name. Missing or
multiple runtime matches fail; controls cannot fall back to the top document.
Nested frame depth and logical scope survive resolution, action,
postcondition, and evidence. The checked-in catalog contains no approved
scopes and records source `iframe` as rejected.

## Fail-closed blockers

QA, application, credential, and infrastructure owners must provide:

- approved non-production client, address, identity, and contact data plus
  retention/redaction rules;
- a current effective date and current BAP product identifier;
- approved NAICS and account-credit expectations;
- an insurance-score reference pattern/status;
- quote-description and quote-identity formats plus save/search/reopen
  outcomes;
- stable destination `data-testid` values for every interactive control;
- stable frame names/paths, including any nested frames, with current DOM/trace
  evidence;
- external `CL_DC_USERNAME` and `CL_DC_PASSWORD`, reachable CLDC/SSO and score
  services, and a retry cleanup/resume policy;
- Azure DevOps plan/suite/test-case/configuration mapping.

The source canonical JSON contains credential-like literals and broad PII.
Those values were not copied. Credentials remain external, profile validation
rejects secret-bearing keys and synthetic/empty required data, and approved
execution remains blocked until selectors and frame scopes are cleared.
