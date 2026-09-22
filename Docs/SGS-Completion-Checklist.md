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
| Reporting adaptation | Integrated: child `05644a9` picked as `37a9dbd`; actual-runner skip compatibility in `6f369fb`, lifecycle/DI/privacy in `d7e47c2`, package/runner/publication gates in `e9c89ec`. No duplicate lifecycle or SGS retry engine. |
| Parent framework suite | Item 2 gate passed: 431 passed, 0 failed, 0 skipped; 54 CI contract assertions passed. Real gated Reqnroll execution reconciled 45 SKIP results with 45 scenario reports and no reporting issues. |
| Live SGS verification | No imported SGS case has been live-verified. Discovery, unit tests, and synthetic report previews do not count. |
| Work/process state | Items 1 and 2 are complete; item 3 is next, with the known Key Vault RBAC blocker. No push, PR, pipeline rollout, live business execution, or IDE synchronization during this reporting milestone. |

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
   Full immutable-package/case qualification remains item 16; this reporting
   runtime check is not live SGS verification or pipeline rollout.

3. [ ] **Unblock and verify local credentials and application access.**
   Use the user-selected `kv-pa-d-tstauto-1`, existing process-only secret
   loading, and Ping. Confirm required credential reads and authorized access
   to the relevant QA applications/services without printing secrets.
   Exit: credential and connectivity prerequisites are demonstrated.
   Current blocker: the CLI identity receives `ForbiddenByRbac` for secret
   reads; an authorized Azure owner must supply the required access.

4. [ ] **Confirm the first-run business data and execution permissions.**
   Resolve the specific outstanding inputs/expectations for the SFP reference
   and first four SGS examples below. Confirm date applicability, expected
   premium/forms where promised, and rerun/cleanup rules. CLEQ AL currently
   retains `values.effective_date = 03-01-2025`; do not silently replace it.
   Exit: the first-run inputs and expectations are explicit and usable.
   Actual transmission, binding, issuance, or payment requires separate
   explicit authorization; quote-only authorization does not imply it.

5. [ ] **Prove the existing PnC SFP Alabama reference still works.**
   Rerun the original SFP Basic workflow, including the pending forms retest.
   Verify the same quote identity, approved premium, genuine forms results,
   and the existing availability-only transmission contract.
   Exit: two consecutive authorized local passes with complete evidence.

6. [ ] **Implement and prove original ExpertQuote BOP smoke, Alabama.**
   Adapt `03_EQ_BOP_Smoke_Test.feature` through thin scoped bindings and reused
   PnC/shared page behavior. Apply and assert the account/address/proposal
   inputs; capture, close, retrieve, and verify the same quote.
   Exit: two consecutive local passes with conforming selectors, the rich
   report, and canonical evidence. Other rows remain individually gated.

7. [ ] **Implement and prove original Commercial DuckCreek BAP smoke, Alabama.**
   Adapt `012_BAP_Smoke_Test.feature`. Apply intended BAP inputs, verify the
   promised business result, and prove actual frame scope through actions and
   locator evidence.
   Exit: two consecutive authorized local passes with complete evidence.

8. [ ] **Implement and prove original Personal DuckCreek Auto smoke, AZ ANG.**
   Adapt `211_Smoke_Test_Auto.feature`. Verify state/company/auto inputs and
   actual quote/proposal identity using the correct controls and frame.
   Exit: two consecutive authorized local passes with complete evidence.

9. [ ] **Prove the corrected Personal DuckCreek rate-filing workflow.**
   Start with one approved example from `181_Auto_Rate_Filings_Policy_1_NB`.
   Correct state/marital/driver targeting, verify actual premium, and prove
   durable transaction identity/status when the operation is authorized.
   Exit: two consecutive passes for all promised, authorized outcomes.
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
    required input/expectation has an explicit readiness or blocker record.

12. [ ] **Complete the full ExpertQuote workflows.**
    Adapt CLEQ 02, 05, and 06: full BOP, SFP Basic, and SFP Country Estate.
    Reuse correct PnC SFP logic and replace source placeholder premium checks.
    Preserve the separate disposition of the 34 source-commented examples.
    Exit: all promised business steps and outcomes are implemented and proven
    for initial examples, with remaining rows tracked individually.

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
| Reporting, deferred verification, diagnostics, retention (pages 3-4) | Reporting code is saved separately and has focused passing checks, but lifecycle integration remains unfinished. Deferred checks must fail the final result, not merely appear in HTML. The current flat seven-day cleanup is not evidence of the matrix's tiered-retention requirement; record the Security/DevOps policy decision and validate approved behavior. | Items 2, 15-17 |
| Secret consumption and sensitive-data approval (pages 2-3) | Keep Key Vault as the protected-configuration source and process variables only as its transport. No alternate SGS credential provider or plaintext fallback is authorized. Vault access is currently blocked, and Security review/approval is still distinct from code completion. | Items 3, 4, 17 |
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
