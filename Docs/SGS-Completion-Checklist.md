# Combined framework completion checklist

Status: APPROVED - full-scope sequential delivery; no pilot phase.
Updated: 2026-09-22.

## Goal

Finish the combined framework locally: preserve existing PnC/SFP behavior and
make all 32 original SGS workflows and their 1,115 active cases executable,
with intended inputs, real business assertions, and rich SGS-style reporting.
The 34 source-commented Country Estate examples remain separately accounted
for; they are not silently enabled, discarded, or counted as passing.

There is no pilot, proof-of-concept, pilot-week reassessment, or pilot
go/no-go gate. The first workflows below are required implementation work,
not a trial to decide whether to deliver the rest of the approved scope.

Keep `Playwright_POC.sln` and
`pa3402-anico-combined-framework-integration`. PnC remains the reference
architecture. Live pipeline rollout, schedules, live Azure Test Plans
publication, a PR, and a Development merge are outside this local finish line.

## How work will proceed

### Temporary premium/forms baseline policy

Approved by the user on 2026-09-22: keep the original premium and forms
validation logic active and record its genuine pass/fail results against the
existing baselines. Do not spend this integration phase approving, correcting,
regenerating or tuning those baselines; the user will update tests and data.
Baseline comparison outcomes are observations, not gates on current integration
progress. Rebaselining and final baseline-dependent acceptance belong after
that refresh, in item 15.

This is an engineering-progress exception, not a test-result override. A
baseline mismatch may still fail the runner, component, manifest and report.
Do not relabel it as a pass, remove assertions, suppress exceptions, widen
tolerances or update expected values merely to obtain a green run. No runtime
assertion bypass or pipeline fail-on-error change is authorized by this policy.
If a comparison stops execution, later unexecuted steps remain unverified.
Missing baseline execution evidence is not a successful comparison.

Only demonstrated expected-versus-actual premium/forms baseline discrepancies
are non-blocking. Authentication, navigation, selectors/frames, unusable required
inputs, stale/corrupt input checksums, malformed responses, Forms API failures,
wrong quote identity, missing evidence and reporting defects remain blockers.
Classify failures from their evidence; do not exempt every premium/forms error.

At the SFP checkpoint on 2026-09-22, the user explicitly included its missing
`returnSuccessStatus="1"` expectation in this deferral. The authenticated
response returned HTTP 200, `status="success"` and actual Forms XML, but omitted
that separate attribute. Keep the response-contract assertion and its real
failure unchanged; do not manufacture `"1"` from `"success"`. This specific
deferral does not excuse authentication, unusable-response or evidence failures.

For items 5-14, record implementation/workflow readiness separately from full
business verification. Keep two-run evidence for the demonstrated non-baseline
behavior, and list baseline failures or unexecuted comparisons explicitly.
An engineering checkpoint may advance with those baseline results pending;
the affected business case must not be marked fully `Verified` on that basis.
All 32 workflows and 1,115 active cases remain in scope.

### Sequential execution

The user chose sequential progress, pausing only for blockers or scope changes.
Only one numbered implementation item is active at a time. Complete and
verify its exit gate before starting the next item. Work inside a coverage
batch also proceeds one workflow at a time, not as parallel product projects.

The order is approved; routine progress does not require repeated approval.
At each checkpoint, update this checklist with the commit, evidence,
completed cases, and remaining blockers. If the current item is blocked,
report the exact dependency and pause; do not silently switch to another item.
Any proposed reorder must be explicit.

Copilot performs the approved internal engineering work: coding, adaptation,
diagnosis, validation, commits, and guarded IDE synchronization. This does not
make Copilot the organizational acceptance authority or transfer SGS's source
ownership/vendor obligations. Existing child work is preserved and resumed
only for its current checklist item; no new parallel workstreams.

Technical acceptance belongs to Internal Automation Architecture (IAA);
business expectations and functional acceptance to QA; protected-data controls
to Security; operational/package/pipeline acceptance to Internal DevOps; and
scope exceptions/final program acceptance to the Automation Manager (AM).
Named approvers and outstanding decisions must be recorded, not assumed.
The user is not being assigned coding, dependency mapping, or integration work.

## Current checkpoint

| Area | Actual status |
|---|---|
| Source audit and dependency map | Complete; current implementation pin is `d1fa9404f1a245722879e523626beb72e68d033b`. Do not restart this inventory. |
| Coverage ledger and stable identities | Integrated; all 32 features, 1,115 active cases, and 34 source-commented cases are accounted for. |
| Strict SGS data adapter | Integrated, including scoped Startup registration and the shared-state/quote-handoff composition test. |
| Semantic controls and frame contracts | Integrated; typed captures, actual selection checks, frame-safe Material dropdowns, and explicit main/nested frame scopes have focused passing coverage. |
| Reporting adaptation | Integrated: child `05644a9` picked as `37a9dbd`; actual-runner skip compatibility in `6f369fb`, lifecycle/DI/privacy in `d7e47c2`, package/runner/publication gates in `e9c89ec`. Item 5 now preserves Forms comparison evidence after a contract failure and corrects live-discovered marker/redaction/raw-JSON issues. No duplicate lifecycle or SGS retry engine. |
| Parent framework suite | Current BOP checkpoint: 481 passed, 0 failed, 0 skipped; 83 offline CI/runner assertions passed. Ready-case authorization was separately proved before promotion. |
| Live SGS verification | Original ExpertQuote BOP smoke AL is `Verified` after two independent real QA passes with complete evidence. One of 1,115 active SGS cases is verified; all other active cases remain individually gated. |
| Premium/forms baselines | Original validation stays active and real results stay visible. Baseline approval/refresh and baseline-dependent acceptance are deferred until the user's test/data refresh; baseline mismatches do not gate current integration progress. |
| Work/process state | Items 1-6 are complete for engineering progress under the approved boundaries. SFP retains its explicitly deferred Forms failures; BOP AL is verified. Item 7 is blocked at CLAS QA sign-in: HTTP 500 from `/express/workbench/listgroups`. Its date, score-result and documented fieldref decisions are approved. No BAP execution or readiness promotion has occurred. Key Vault approval remains pending; no PR, push, Development merge, IDE synchronization or pipeline rollout has occurred. |

## Ordered remaining work

1. [x] **Stabilize the current integration baseline.**
   Correct the forms-finalization regression without allowing real failures to
   be overwritten by later success. Finish the saved data DI/composition slice.
   Exit: the full framework suite is green and the integration worktree has a
   clean, committed checkpoint. Do not start a new business workflow here.
   Completed 2026-09-22: implementation commit
   `d6670f16973351a2d35c5467d1c2d6d32edd32be`; 42 focused checks and all 283
   framework tests passed with zero skips. Evidence:
   `checklist-01-targeted.trx` and `checklist-01-full-suite.trx` in the
   integration session's `files\resume-validation` directory. Added coverage
   for genuine failures remaining failed after a subsequent passing check,
   baseline-resolution failures, and scenario-scoped data/quote ownership.

2. [x] **Finish and integrate reporting into the existing lifecycle.**
   Finish the reporting child's final offline check and handoff, then integrate
   its renderer, canonical reader, and report tool. Wire the existing
   `TestHooks` and artifact finalizer, not a second lifecycle. Include unique
   screenshots, execution logs, required trace/video, forms links, and truthful
   pass/fail/skip/teardown outcomes.
   Exit: canonical results, manifests, and reports agree; required missing
   evidence fails; existing PnC behavior remains intact.
   Completed 2026-09-22: `d7e47c2` and `e9c89ec`, following the single approved
   child cherry-pick and runner compatibility fix above. The existing artifact
   owner now freezes rich reports after real step/deferred outcomes, owned
   browser evidence, teardown, persistence handling and log flushing.
   Required omissions/report defects fail rather than disappearing.
   Canonical consolidation preserves skips and actual attempt groups.
   Evidence under the integration session's `files\resume-validation`:
   `checklist-02-full-suite.trx` (431/0/0),
   `checklist-02-ci-contracts.log` (54 assertions),
   `checklist-02-native-gates` (45 genuinely skipped, zero business passes;
   canonical/manifests/reports agree), and
   `checklist-02-sourcefree-report\verification.json` (copied .NET 8 Release
   runtime, unchanged inventory, expected exit 1 for skips and 2 for missing
   canonical input). The Release reporting build had zero warnings/errors.
   Full case and immutable-package qualification remains items 15-16; this reporting
   runtime check is not live SGS verification or pipeline rollout.

3. [x] **Unblock and verify local credentials and application access.**
   Prefer the user-selected `kv-pa-d-tstauto-1`, existing process-only secret
   loading, and Ping. Confirm required credential reads and authorized access
   to the relevant QA applications/services without printing secrets.
   Exit: credential and connectivity prerequisites are demonstrated.
   Key Vault access remains pending approval: the CLI identity receives
   `ForbiddenByRbac` for secret reads.
   Rechecked after item 2 using the approved vault and named credential secret,
   returning only ID/enabled metadata: still `ForbiddenByRbac`. No secret value
   was displayed or persisted. Evidence:
   `files\resume-validation\checklist-03-keyvault-access.json` in the integration
   session.
   On 2026-09-22 the user explicitly authorized the existing local
   `appsettings.json` as the temporary credential source. This supersedes the
   Key Vault-only pause for local execution, not the long-term vault or CI
   policy. The Visual Studio checkout's file contains the existing credentials;
   the integration copy intentionally leaves those fields empty.
   `Scripts\run-sfp-basic-al.ps1 -AppSettingsPath <external-file>` reads only
   the six required credential fields into process variables, restores the
   caller environment, and never copies the source file into this branch or
   its package. There is no automatic fallback from a denied vault read.
   `-ValidateCredentialsOnly` passed for all six fields without modifying
   the source file, printing values, building, logging in or executing tests.
   Evidence: `files\resume-validation\checklist-03-local-appsettings-preflight.json`
   and `checklist-03-local-credential-contracts.log` (79 assertions).
   Actual access verification completed on 2026-09-22 using the existing
   `ExpertQuoteLoginPage`, `ExpressLoginPage` and `BrowserFactory`: ExpertQuote
   QA, CLAS QA and QA Express each authenticated once and passed their actual
   landing-page assertion. All owned browser contexts were closed. No quote
   searches, business mutations, saved cookies/tokens, screenshots or traces
   were produced. The local credential file remained unchanged.
   Evidence: `files\resume-validation\checklist-03-qa-access.json` and
   `checklist-03-qa-access-console.log`.
   The Forms endpoint returned HTTP 200 to an anonymous HEAD request. This
   proves reachability only, not Forms API authentication. Its configured
   address uses HTTP; no service password was sent by this access probe.
   The user explicitly approved closing item 3 on the verified browser logins
   and moving authenticated Forms API verification to the required item 5
   quote/forms check. Item 4 must record the approved Forms connection/transport
   before a credential-bearing request. Key Vault approval is still pending.

4. [x] **Confirm usable first-run inputs and execution permissions.**
   Resolve the operational inputs for the SFP reference. By explicit user
   approval, review SGS operational inputs just in time at each workflow item,
   rather than blocking SFP on future SGS examples. Confirm date applicability
   and rerun/cleanup rules without approving or updating premium/forms baselines.
   CLEQ AL retains `values.effective_date = 03-01-2025`; do not silently replace it.
   Exit: required execution inputs and permissions are explicit and usable.
   Existing premium/forms comparisons remain available under the observation
   policy above; their pass/fail outcomes are not this item's exit gate.
   Completed 2026-09-22: after disclosure that HTTP does not provide TLS
   protection for the service credentials, the user explicitly approved the
   existing internal QA HTTP Forms connection. The user also approved proceeding
   with SFP now and checking SGS inputs at each workflow step. The unchanged
   SFP profile is valid through `2026-10-18T12:44:42.179Z`; all six required
   credentials passed the explicit external-settings preflight. An earlier
   launch stopped before execution when that external file was blank; once
   the user's Development copy was populated, the same loader succeeded.
   No credential fallback, IDE modification or Development change was made.
   Actual transmission, binding, issuance, or payment requires separate
   explicit authorization; quote-only authorization does not imply it.

5. [x] **Prove the existing PnC SFP Alabama reference still works.**
   **Engineering exit completed; deferred Forms results remain failed.**
   Rerun the original SFP Basic workflow, including the pending forms retest.
   Verify the same quote identity, genuine forms retrieval and the existing
   availability-only transmission contract. Run the original premium/forms
   comparisons and preserve their actual outcomes; do not rebaseline here.
   Authenticated Forms API access for that real quote/session is a required
   part of this item, explicitly carried from item 3 by user approval. A
   reachable endpoint or a successful browser login does not satisfy it.
   Exit: two authorized local runs demonstrating the non-baseline workflow
   behavior with complete evidence. Carry baseline comparison discrepancies
   explicitly to item 15; do not claim those failed cases as business-verified.
   Current evidence under `files\resume-validation` in this integration session:
   `checklist-05-sfp-al-02` is the first real execution. It reached the Forms API
   but the response-contract failure prevented required comparison exports.
   Its original TRX/manifest/projection remain unchanged; replay into
   `report-after-evidence-fix-final` removes false projection/handoff errors
   while correctly retaining the four genuinely missing Forms exports.
   `checklist-05-sfp-al-03` is the new non-retried qualification run:
   one failed case, duration `00:07:19.8675880`, 62 registered artifacts,
   41 unique screenshots, all required Forms XML/CSV/HTML/Markdown/TRX,
   zero manifest evidence errors and zero consolidation issues.
   Quote identity at pricing and Forms session, USD 1540.00 premium, and
   transmission availability passed. No policy was transmitted. The
   credential-bearing Forms request returned HTTP 200 and 30 actual forms;
   the credential source file remained unchanged.
   The row comparison reports 29 passes and four failures across 33 compared
   forms (three expected mandatory forms absent and one unexpected mandatory
   form). These are deferred baseline observations, not integration blockers.
   Separately, the unchanged profile requires `returnSuccessStatus="1"`, but
   the response has `status="success"` and omits `returnSuccessStatus`.
   Manuscript, print job, baseline version/checksum and security requirements
   matched. This response-status expectation has not been declared equivalent,
   rebaselined or passed. The user explicitly approved carrying this specific
   expectation with the deferred Forms baselines, preserving the assertion
   and failed result.
   Completed 2026-09-22 with the second separate, non-retried qualification:
   `checklist-05-sfp-al-04`, one failed case in `00:05:44.3459230`.
   Both `-03` and `-04` have the same successful non-baseline assertions,
   30 retrieved forms, 29 passing/four failing row comparisons, 62 artifacts,
   41 unique screenshots, complete required evidence and zero consolidation
   issues. Both credential-source files were unchanged. No other component
   failed and no policy was transmitted. These two complete-evidence runs
   satisfy the approved engineering boundary; neither is reclassified as
   passed or fully business-verified. The incomplete first run is not counted
   toward that exit gate. Evidence/reporting implementation: `7f88563`.
   Regression evidence: `checklist-05-evidence-fix-targeted.trx` (150/0/0),
   `checklist-05-evidence-fix-full-suite.trx` (441/0/0),
   `checklist-05-evidence-format-final.log`, and
   `checklist-05-evidence-replay-final.log`. No expected values, profile
   checksums, runner failure gates, SGS readiness entries or pipelines changed.

6. [x] **Implement and prove original ExpertQuote BOP smoke, Alabama.**
   Adapt `03_EQ_BOP_Smoke_Test.feature` through thin scoped bindings and reused
   PnC/shared page behavior. Apply and assert the account/address/proposal
   inputs; capture, close, retrieve, and verify the same quote.
   Exit: two local runs demonstrating non-baseline behavior with conforming
   selectors, the rich report and truthful canonical evidence. Baseline
   observations follow the temporary policy. Other rows remain individually gated.
   Input decision approved 2026-09-22: use the execution date for Alabama
   case `SGS-CLEQ-03-EQ-BOP-SMOKE-TEST:AL-3B2D76491867`, as an explicit recorded
   runtime override of `values.effective_date`. Freeze it at scenario data
   load through the existing data resolver; do not silently change dates
   during a run. The imported value `03-01-2025`, source profile, external
   overrides and their reviewed checksums remain unchanged. This approval
   applies to this workflow/example, not all later rate-filing dates.
   The existing source binding actively enters that value; the external
   override file is empty. No SGS case has been enabled or live-executed
   as a result of this input decision.
   Adaptation checkpoint: scoped bindings reuse the existing browser/state,
   pages, strict data adapter, semantic controls, quote handoff and artifact
   finalizer. Source-declared random identities use the bounded shared
   generator; they cannot supply credentials or authoritative quote IDs,
   replace an owned identity, or leak raw generated contact values into reports.
   Actual account values, chip/checkbox selections, proposal inputs and complete
   captured/retrieved quote identity are asserted. Reviewed profile hashes and
   the frozen execution-date override are included in scenario evidence.
   At the pre-execution checkpoint only AL was `ReadyForLocalVerification`;
   the other 1,114 active SGS examples remained `NonRunnable`. A ready case requires its exact
   `TEST_SGS_LOCAL_CASE` authorization. Use the existing credential/evidence
   runner with `-Workflow SgsExpertQuoteBopAl -AppSettingsPath <external-file>`
   and a fresh `-ResultsDirectory`; omitting `-Workflow` retains SFP behavior.
   The runner restores local permission and credentials even on failure.
   No transaction execution or automatic mutation retries are enabled.
   Source feature body bytes and profile/checksum inventory are unchanged.
   Pre-execution evidence in `files\resume-validation`:
   `checklist-06-framework.trx` (465/0/0), `checklist-06-ci-contracts.log`
   (83 assertions), and `checklist-06-selector-probe\selection.trx`
   (one genuinely gated SKIP). These are not business qualification runs.
   Completed 2026-09-22: implementation `72894ff3e75d8603ee813a150d0c7703a8432c24`
   passed two separate, non-retried QA qualifications:
   `checklist-06-cleq-bop-al-06` (48.553495 seconds) and
   `checklist-06-cleq-bop-al-07` (47.704908 seconds). Each verified actual
   client/account/address values, marital/product/DBA/address/lessors selections,
   effective date, rating state, agent PC and entered SSN, then captured,
   closed and retrieved its own complete quote identity. The two runs created
   different quote identities; no transmission, issuance or payment occurred.
   Each has canonical/report PASS parity, zero evidence/consolidation issues,
   46 artifacts, 12 unique screenshots, 19 explicit main-frame locator records,
   complete logs/trace/video/manifest, and matching reviewed source checksums.
   The credential source remained unchanged. This original smoke promises no
   premium, Forms or transmission outcome, and none is claimed.
   Live adaptation failures in runs `-01` through `-05` remain preserved as
   failures: exact displayed chip casing, date zero-padding, duplicated product
   wrappers, duplicated checkbox IDs, and the dashboard's selected tab after
   quote closure. Corrections retain exact input/selection/identity assertions,
   test-ID-first targeting and ambiguity failures. UI logic now resides in
   `ExpertQuoteBopSmokePage` behind thin scoped bindings.
   Qualification evidence: `checklist-06-qualification-evidence.json`, each
   run's canonical TRX/scenario manifest/consolidated report and receipt, plus
   `checklist-06-framework-final.trx` (480/0/0). Only the AL ledger entry is
   promoted to `Verified`, with both actual run IDs, artifact paths and the
   exact implementation commit. Other 1,114 active cases and 34 source-commented
   examples remain gated. Organizational acceptance remains separate.
   The BOP page also explicitly requires its promised SSN input before using
   the shared optional-dialog handler; an unrelated page transition cannot
   silently skip that input. Negative browser coverage and the promoted ledger
   pass `checklist-06-required-input-framework.trx` (481/0/0).
   The committed guard was then confirmed by
   `checklist-06-cleq-bop-al-08` at `d3532cae63a79cf09a06a4acc6df99dfe382d33a`:
   another real PASS in 58.682577 seconds, a third distinct quote, 46 artifacts,
   12 unique screenshots, zero evidence/report issues and an unchanged credential
   source. See `checklist-06-required-input-qualification.json`. The ledger retains
   the latest consecutive passes, `-07` and `-08`, with their respective exact
   implementation commits; the earlier complete pass and failed runs remain intact.

7. [ ] **Implement and prove original Commercial DuckCreek BAP smoke, Alabama.**
   **Active item - blocked by CLAS QA sign-in; input decisions approved.**
   Adapt `012_BAP_Smoke_Test.feature`. Apply intended BAP inputs, verify the
   promised business result, and prove actual frame scope through actions and
   locator evidence.
   Exit: two authorized local runs demonstrating non-baseline behavior with
   complete evidence and separately recorded baseline comparison outcomes.
   Just-in-time review: original AL identity
   `SGS-CLDC-012-BAP-SMOKE-TEST:AL-CC1465315B0B`, profile checksum
   `83A75FEAFA039C3E15EEA1306DB298DAC73A3484D2970C75BF2C7CC3A6186FEE`.
   The source binding actively enters `values.effective_date_43` at quote
   start and `values.effectivedate_100` at Policy Info. Both contain
   `12-01-2025`, despite `dimensions.effectiveDateMode` being `Current`.
   The BOP date approval was case-specific and is not automatically inherited.
   The user explicitly approved using the execution date for both BAP fields
   on 2026-09-22. Apply recorded runtime overrides frozen at scenario data load;
   keep the imported dates and profile checksum unchanged.
   Separately, `values.expected_reference_number_innertext_135` is empty,
   while the source binding uses it to verify the insurance-score reference.
   An approved expected result or actual-reference validity rule is needed;
   do not synthesize an expected number or silently accept an empty assertion.
   The user approved requiring a successful insurance-score response and a real,
   nonempty returned reference on 2026-09-22. Verify the actual result and reject
   error/empty states; do not invent a fixed reference or treat the field's
   caption/visibility as a returned reference. Retain the imported empty value
   and record this explicit verification-rule adaptation.
   This is not a deferred premium/forms baseline. BAP source files and gates
   remain unchanged; no BAP business execution has occurred.
   The user also approved a documented legacy DuckCreek `fieldref` fallback,
   retaining test-ID-first priority, exact frame scope and ambiguity failures.
   See `DUCKCREEK-FIELDREF-001` in `Docs\Locator-Audit.md`; actual CLAS selector
   metadata confirms the missing test IDs. The shared adapter still needs this
   implementation; generic source `iframe` hints are not approved frame scopes.
   Current execution prerequisite failure: a bounded read-only inspection using
   the approved external credentials, PnC's configured Chrome channel and
   `https://clasq.anico.com/express/express.aspx` did not reach the authenticated
   search page. CLAS returned HTTP 500 from
   `https://clasq.anico.com/express/workbench/listgroups` and remained on
   `/express/default.aspx` with Login/OK actions. The observed DOM did not expose
   an invalid-credentials message; the evidence does not establish whether the
   cause is a service fault or account/group configuration. Do not assume that
   changing the framework or suppressing login checks would fix it.
   Evidence: `checklist-07-clas-dom-configured.json` and its `.log` under the
   integration session's `files\resume-validation`. The earlier root-URL probe
   also failed but did not match PnC's browser/entry-point settings, so use the
   configured-probe evidence for escalation. Neither inspection clicked quote
   Start or ran a business case; the credential file was unchanged and owned
   browser contexts were closed. Resume this item when CLAS QA login and its
   workbench group lookup are functioning. Do not switch to item 8 or promote
   BAP to runnable while this prerequisite is unresolved.

8. [ ] **Implement and prove original Personal DuckCreek Auto smoke, AZ ANG.**
   Adapt `211_Smoke_Test_Auto.feature`. Verify state/company/auto inputs and
   actual quote/proposal identity using the correct controls and frame.
   Exit: two authorized local runs demonstrating non-baseline behavior with
   complete evidence and separately recorded baseline comparison outcomes.

9. [ ] **Prove the corrected Personal DuckCreek rate-filing workflow.**
   Start with one approved example from `181_Auto_Rate_Filings_Policy_1_NB`.
   Correct state/marital/driver targeting, capture the actual premium and run
   its comparison, and prove durable transaction identity/status when the
   operation is authorized.
   Exit: two runs demonstrating all promised, authorized non-baseline outcomes,
   with premium/forms comparison results preserved rather than rebaselined.
   An unauthorized required transaction remains a blocker, not a substitute
   transmit-button assertion or a passing case.

10. [ ] **Complete the remaining sibling smoke workflows.**
    Work through CLDC 013-018, CLEQ 04, and PLDC 212/215, one workflow at a time.
    Reuse the proven entry/input/quote/reopen behavior without removing
    state/company variations.
    Exit: all nine workflows have real implementation and a proven initial
    example; remaining matrix rows are explicitly tracked for item 15.

11. [ ] **Complete the remaining Personal DuckCreek rate filings.**
    Adapt PLDC 182-186 and the remaining variants in 181. Preserve company and
    effective-date distinctions, genuine premium comparisons, and authorized
    transaction outcomes.
    Exit: each workflow has a proven initial example and every remaining
    required input has an explicit readiness or blocker record. Baseline
    expectation changes remain deferred, with actual comparison results retained.

12. [ ] **Complete the full ExpertQuote workflows.**
    Adapt CLEQ 02, 05, and 06: full BOP, SFP Basic, and SFP Country Estate.
    Reuse correct PnC SFP validation logic rather than source placeholder
    premium checks; do not invent or tune expectations during this phase.
    Preserve the separate disposition of the 34 source-commented examples.
    Exit: all promised steps and comparison logic are implemented; initial
    examples demonstrate non-baseline behavior and record real comparison
    outcomes, with remaining rows tracked individually.

13. [ ] **Complete Commercial DuckCreek BAP/package/liability workflows.**
    Adapt CLDC 001-006: BAP basic/expanded, CPP, CP, GL, and OCP. Correct pricing
    navigation and verify genuine coverage, forms, and submission outcomes.
    Exit: each original workflow is implemented and its initial example proven.

14. [ ] **Complete Commercial DuckCreek IM/Umbrella/WC workflows.**
    Adapt CLDC 007-011, including expanded variants and their line-specific
    classification/coverage behavior.
    Exit: each original workflow is implemented and its initial example proven.
    Together, items 6-14 cover all 32 source features.

15. [ ] **Qualify the complete case matrix and reporting parity.**
    After the user's test/data refresh, approve the applicable premium/forms
    baselines and resolve the comparison results deferred from items 5-14.
    Reconcile all 1,115 active cases. Execute remaining unverified rows in
    controlled batches and rerun cases affected by later shared changes.
    Validate required data/checksums, intended inputs, business assertions,
    binding uniqueness, and report/result/evidence agreement.
    Exit: two consecutive authorized local passes per completed case for the
    accepted code/data revision. No all-state success inferred from one state;
    no skipped, blocked, or unit-only case counted as working. Any outstanding
    blocked case means overall delivery is still incomplete.

16. [ ] **Qualify one complete, source-free local package.**
    Verify clean locked .NET 8 restore/build, DLL/Playwright pairing, all
    configuration/resources/scripts/tools/runsettings/DataPool/report assets,
    checksums, source-free discovery, disjoint shards, and explicit failure
    for failed tests or missing/empty results. Check publication preparation
    and privacy contracts locally without live ADO publication.
    Exit: one immutable package reproduces the accepted case inventory and
    execution/reporting contract. Do not deploy pipelines or alter schedules.

17. [ ] **Deliver the final integration and Visual Studio handoff.**
    Reconcile the final ledger, reports, commits, and any remaining external
    blockers. Safely synchronize the separate IDE clone after checking its
    branch, disk changes, unsaved work, and active builds. Preserve the
    established solution path.
    Exit: the accepted integration commit and complete solution are available
    in the IDE, with clear local run instructions and evidence locations.
    Do not open a PR or merge to Development.

## Completion rules

Each workflow item includes its directly related tests/docs and a small
reviewable commit. A live failure is fixed within the current item; it does not
become a reason to open unrelated workstreams.

The first four SGS examples establish working product paths, not completion
of the remaining states or workflows. Business cases are marked verified only
by actual execution evidence. Synthetic report previews remain labeled as such.
These are incremental deliveries within the full required scope, not pilots.

Physical project separation still requires David's architecture decision and
is not silently added to this implementation. Infrastructure/ADO rollout is a
separate follow-on checklist, not mixed into local framework completion.

The detailed source map, architectural constraints, and original milestone
rationale remain in `Docs\SGS-Executable-Integration-Plan.md`. This checklist is
the execution-order and progress record.

## Responsibility and acceptance matrix alignment

Reviewed: the six-page `Responsibility-and-Acceptance-Matrix.pdf`, titled
"Preliminary Responsibility and Acceptance Matrix" and marked "Draft for
internal review." Document SHA-256:
`7BDC4D00880B774BFE7268C1E474D8C0CA25D3BA13F13D962EB73AF8C8924E60`.

The user explicitly retained this checklist's order and rejected a pilot
approach. The matrix's proposed pilot, one-week reassessment, and
pilot-before-broader-migration recommendations (pages 4-6) therefore do not
govern this implementation. Its delivery-quality, ownership, and acceptance
criteria remain relevant; they do not reduce the approved 32-workflow scope.
Selective component reuse is not permission to drop required business coverage.

| Matrix area | Alignment with actual work; remaining evidence | Checklist location |
|---|---|---|
| Reference architecture, project ownership, shared interfaces (pages 1-2) | PnC remains authoritative, with one lifecycle and logical product boundaries. Physical topology is still provisional in ADR-001. An approved interface catalog/versioning policy, dependency diagram, and named IAA decisions are not replaced by passing tests. | Items 1, 6-14, 17; no unapproved project split |
| Lifecycle, API/authentication, DataPool, quote handoffs (pages 2-3) | Existing shared implementations and regression tests are retained. Item 1 corrected the forms/finalization regression and restored a green framework baseline. Technical evidence does not itself constitute security or operational approval. | Items 1, 3, 5-15 |
| Controls, locators, frames, data, thin bindings (pages 2-3) | Strict data and reusable control/frame foundations are integrated. This does not mean the SGS business bindings/pages or live control mappings have been adapted or accepted. | Items 4, 6-14 |
| Business outcomes, forms, required inputs (pages 3-4) | The intended acceptance matches the checklist: actual applied inputs and promised outcomes, QA-owned expectations, and explicit failures. Add structured redacted applied-input evidence and controlled known-pass/known-fail demonstrations to the workflow evidence, not just navigation screenshots. | Items 2, 4-15 |
| Reporting, deferred verification, diagnostics, retention (pages 3-4) | Lifecycle/report integration is complete, and the latest actual SFP failure reconciles with complete evidence. Deferred checks still fail the final result, not merely appear in HTML. The current flat seven-day cleanup is not evidence of the matrix's tiered-retention requirement; record the Security/DevOps policy decision and validate approved behavior. | Items 2, 5, 15-17 |
| Secret consumption and sensitive-data approval (pages 2-3) | Key Vault remains the intended protected source. While read approval is pending, the user explicitly authorized read-only import from the existing local appsettings file into process variables for local execution only. No secrets enter this branch/package, no automatic fallback is added, and no SGS credential provider replaces Ping. Security review/approval remains distinct from code completion. | Items 3, 4, 17 |
| Coverage and component disposition (pages 3, 6) | The existing ledger accounts for all 32 features, 1,115 active cases, 34 source-commented examples, and 191 path-level dependency decisions. It is a technical traceability register, not a signed acceptance record. The document's separate claim of 53 omitted vendor branches has not been reconciled to a finding register/current source pin; it is not the same as the 34 commented examples. | Items 4, 6-15 |
| Package, result integrity, CI/CD, Test Plans (pages 3-4) | The checklist intentionally completes local engineering/package qualification first. Formal operational acceptance still needs DevOps-owned combined execution, deliberate assertion-failure propagation, missing/malformed-result failure, and accurate real Test Plans results/attachments. Local dry runs cannot satisfy those final operational criteria. | Item 16 locally; separate later DevOps acceptance |
| Acceptance records, measurements, knowledge transfer (pages 4-6) | Add delivery-level evidence/decisions to milestone handoffs. Capture execution time, fixed-wait usage, flaky behavior, and artifact size as delivery metrics, not a pilot reassessment. Include an internal-engineer setup/diagnosis walkthrough; no blanket acceptance based on test counts. | Each checkpoint; consolidated in items 15-17 |

For each delivery checkpoint, link the existing technical ledger/evidence to
an acceptance record containing: deliverable ID/version/commit; Internal or
SGS source owner; Retain/Adapt/Reimplement/Retire disposition; target interface
version; requirements/Test Plans mappings; expected outcomes; positive and
negative validation; evidence locations; known limitations; named reviewers;
and technical/functional decisions. Conditional acceptance needs an explicit
condition, owner, and due date. Missing approval/run evidence stays pending,
not implicitly accepted. This is acceptance tracking, not another runtime
result or reporting system.

The original register behind the "53 omitted branches" statement is an
unresolved document reference. Obtain it from its owner and reconcile each
finding as open, resolved, or superseded against the pinned source. Do not
restart the completed feature/dependency inventory, manufacture 53 defects,
equate branches with example rows, or remove coverage to make counts match.

Local engineering completion and formal framework/program acceptance remain
separate. The matrix's final CI/CD demonstration and IAA/QA/Security/DevOps/AM
sign-offs cannot be claimed complete while that operational work is deferred.
