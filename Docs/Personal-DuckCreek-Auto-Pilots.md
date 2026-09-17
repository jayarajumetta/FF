# Personal DuckCreek Auto Pilots

Phase 7C adapts two narrowly selected Personal DuckCreek Auto workflows from
the audited SGS commit `ecd9019ab991028341ad76de11cff06aa43cb32f`.
It does not copy SGS hooks, browser/session factories, `UiActions`, retry
generation, reporting/finalization, generated pages, or pipelines.

## Destination contracts

| Pilot | Automation ID | Profile | Shard |
|-------|---------------|---------|-------|
| AZ ANG 211 smoke | `PLDC-AUTO-SMOKE:AZ` | `pldc-auto-az-ang-smoke` | `PldcAutoAzAngPilot` |
| AL state/marital microcase | `PLDC-AUTO-STATE-MARITAL:AL` | `pldc-auto-state-marital-microcase` | `PldcAutoStateMaritalPilot` |

Both belong only to suite `PersonalDuckCreekPilot` and are
`NonRunnable`/`NoRetry`. Production schedules do not select the suite.
Package validation independently discovers each scenario and requires exactly
one `NotExecuted` result. Both Azure Test Plans identities are deferred.

The checksummed catalog `Resources/DataProfiles/pldc-auto-pilot.json` records
all 50 files in the approved source ledger. It preserves only non-sensitive
business intent and explicitly declares every missing required value. The
smoke JSON resolves directly rather than through the SGS layered manifest. The
AL microcase resolves through its manifest entry to Base plus an empty
StateOverrides patch; the original AL JSON and Base are byte-identical.

## Scope and source disposition

The smoke adapts the AZ row from
`Features/Smoke/211_Smoke_Test_Auto.feature`: create/select a client, reach
Account Information, choose Arizona and Single, start Personal Auto with ANG,
handle a deterministic approved proposal outcome, capture a quote identity,
then search, reopen, and verify the exact quote. It does not promise premium,
forms, billing, bind, or transmission, so Phase 7C adds none of those outcomes.

The microcase uses only the first AL prefix of
`181_Auto_Rate_Filings_Policy_1_NB.feature`, stopping on Account Information.
No audited 181 row selects Married; all 50 layered rows resolve to Single.
The destination scenario therefore documents the intended corrected
state/Married contract but cannot run until QA supplies an approved sanitized
Married case. It must not inherit the later feature's premium, forms, billing,
underwriting, or transmission claims.

| SGS behavior | Destination disposition |
|--------------|-------------------------|
| `SelectStateNameAsync` selecting Account Details Next | Retired; the `account-state` control receives a nonempty state and must report `SelectedValue` |
| `SelectMarriedAsync` selecting the broad Divorced locator | Retired; `marital-status-married` must target exact Married and report `SelectedValue` |
| Heading-backed readiness | Retired; readiness targets the actual control and requires `Enabled` |
| Empty select followed by fill | Retired; one semantic selection receives the canonical nonempty value |
| Fixed delays and one-shot dialog probes | Retired; one bounded conditional-outcome boundary must match the approved outcome |
| Direct DOM clicks and `SHIFTTAB` | Retired; shared semantic actions own readiness, strictness, evidence, and postconditions |
| Broad `.First` quote/tab selectors | Retired; exact quote identity/status parity is mandatory |
| Source scenario retry | Retired; client/quote creation is not idempotent and has no rollback |

## Selectors, frames, and evidence

Source HTML IDs, test IDs, roles, CSS, and XPath are audit evidence only.
No destination selector is invented and no new `ANI-ID-*` exception is
approved. Application owners must provide exact destination `data-testid`
evidence, including unique state, writing-company, Married, proposal-outcome,
quote-search, result-row, and active-quote controls.

The audited PLDC pages create top-document locators and do not wire a runtime
frame resolver. Any original Tosca frame scope has therefore been lost. The
versioned catalog `Resources/FrameHints/pldc-auto-frame-hints.json` contains no
approved frame scopes; a required framed control cannot fall back to the top
document. Approved scopes must resolve one page/frame path and remain attached
through action, selected-value verification, and redacted locator evidence.

Each checkpoint uses a unique screenshot path. Required reports, logs,
traces, videos, manifests, and result files are fatal when missing. Evidence
must redact names, DOB, SSN, address, phone, email, credentials, and quote
identifiers; source evidence masked only password/secret keys and is not
acceptable.

## Fail-closed blockers

- approved non-PII or masked disposable client/address/contact/identity data;
- external PLDC credentials, approved role, reachable QA environment, and
  recorded application build;
- current deterministic effective date/agent data and approved conditional
  proposal outcomes for the smoke case;
- exact state, writing-company, marital, proposal, quote/search/reopen
  selectors and any stable frame paths;
- quote identity format plus save/search/reopen status expectations;
- a sanitized QA-owned AL Married row for the microcase;
- evidence redaction/retention approval and mutation cleanup or continued
  `NoRetry`;
- Azure DevOps plan/suite/test-case/configuration ownership.

The source smoke metadata names an AL feature while selecting AZ ANG and pins
only a Tosca revision, not an application build. That stale lineage is recorded
as a blocker rather than treated as execution approval.
