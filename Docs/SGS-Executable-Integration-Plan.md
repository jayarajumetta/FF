# SGS executable integration plan

Status: APPROVED - implementation resumed at the user's request on 2026-09-22.

## Objective and authority

Deliver one working PnC framework that executes all SGS-delivered business
coverage using the original PnC implementation standards. Retaining feature
files, compiling cases, or skipping scenarios is not delivery.

Copilot owns source analysis, adaptation, debugging, reporting integration,
verification, small commits, and guarded IDE-checkout synchronization. The user
is not being assigned coding, dependency mapping, or test-wiring work.

The user explicitly approved this plan and authorized implementation on
2026-09-18. Implementation proceeds in the reviewable milestones below.
Approval does not authorize production activity, transmission, binding,
issuance, payment, pipeline rollout, a pull request, or a solution rename.

## Implementation pause checkpoint

The user requested a safe pause on 2026-09-18 and explicitly resumed work on
2026-09-22. The following historical checkpoint was preserved; implementation
continues from it rather than restarting the completed inventory.

- Latest-source reconciliation is complete at the SHA recorded below. No
  new source inventory is needed unless the remote changes before resumption.
- The strict data-adapter and pure reporting interfaces have been agreed.
  Their implementation work is isolated on
  `pa3402-anico-sgs-data-adapter` and
  `pa3402-anico-sgs-report-adaptation`; neither has been integrated.
- The integration branch has not yet received the M1 execution ledger, M2
  runtime bridge, or executable SGS workflow changes from this plan.
  No milestone is being declared complete.
- No browser runs, pipeline changes, or Visual Studio checkout updates were
  started during this implementation entry.

At the pause, all three workstreams confirmed their commands completed:

| Workstream | Saved checkpoint |
|---|---|
| Source references | Complete pinned export: 189 reference files and `sgs-source-reference-manifest.json` in the source inventory session's `files\sgs-source-ecd9019` directory. No source checkout changes. |
| Data adapter | API/ownership agreed; no source changes or implementation commit yet. |
| Reporting | Four untracked draft files under `Reporting`: `ReportContracts.cs`, `ReportRedactor.cs`, `ScenarioReportProjector.cs`, and `ScenarioReportRecorder.cs`. Not yet validated or committed; do not treat them as a finished report implementation. |

The saved workstreams have resumed. Continue the coverage ledger and shared
artifact/finalization contracts, integrate tested data/reporting slices, then
adapt the original ExpertQuote BOP smoke workflow. Preserve the existing
solution and scenario lifecycle throughout.

## Baselines and source freshness

- Destination branch: `pa3402-anico-combined-framework-integration`.
- Destination planning baseline: `6b9bcf9c4ec80da3342731e3aeb5d6876b1b28f3`.
- Keep the established `Playwright_POC.sln` and the existing integration branch.
- Existing imported SGS provenance: `ecd9019ab991028341ad76de11cff06aa43cb32f`.
- The execution plan must use freshly fetched SGS remote-default-branch source,
  not assume the imported snapshot or a local checkout is current.
- Record the remote ref, full SHA, fetch time, feature/case counts, and changes
  from the imported snapshot. Newly delivered coverage is in scope. Upstream
  removals are reviewed, not silently deleted from the retained deliverables.
- Fetch again before execution starts. If source changed, reconcile the delta
  before adaptation; do not allow a moving branch to change a milestone's inputs.

Latest SGS source was fetched on 2026-09-18 between 18:24:07 and 18:24:19 UTC:
`refs/remotes/origin/main` resolves to
`ecd9019ab991028341ad76de11cff06aa43cb32f`, whose commit date is
2026-09-17 20:07:30 UTC. A direct remote-HEAD check at 18:35:47 UTC confirmed
the same SHA and `main` as the remote default branch. Latest source therefore
equals the imported provenance: there are no added, removed, renamed, or
changed source files to reconcile at this snapshot.

The implementation-entry fetch and live remote-HEAD check at 18:51:42 UTC
on 2026-09-18 reconfirmed that same SHA and default branch. The first
implementation milestone is pinned to that commit.

The 2026-09-22 resume fetch (12:57:29-12:57:46 UTC) found newer remote `main`:
`d1fa9404f1a245722879e523626beb72e68d033b`, nine commits after the original
snapshot. This is the current implementation pin. Its 19 changed paths affect
reporting/configuration/delivery only; features, bindings, pages, locators, and
data profiles are unchanged, so the completed executable map remains valid.
Imported checksums continue to describe the original immutable import.

The preserved reference overlay is `sgs-source-delta-ecd9019-to-d1fa940` in the
inventory session's `files` directory. Its manifest SHA-256 is
`E3DBC24F204A89377C66A4E306A7FB20630B923DA8432BE5522BAFDA6B20F8CB`.
Adapt the newer report root/deduplication and evidence-integrity improvements.
Do not copy source video-omission defaults over required destination evidence,
or replace the destination pipelines with the source release implementation.

The research worktree itself was ten commits behind at `496d6a3`; it was NOT
used as source truth. The dependency audit read the freshly fetched Git
objects, not that stale working directory.

The current destination compiled inventory was inspected without running tests:
1,199 main-assembly cases, including 1,115 SGS cases, and one product module
(`SfpProductModule`). The imported inventory contains 32 features: 18 Commercial
DuckCreek, five Commercial ExpertQuote, and nine Personal DuckCreek; 1,152
scenario-data JSON files and one frame catalog are retained.

The latest-source audit maps all 32 features to 32 scoped binding classes,
three shared application-binding files, 54 reachable page files, and 51
reachable locator files, with no reported missing dependency mappings.
There are 515 CLDC, 161 CLEQ, and 439 PLDC active cases, matching destination
compiled discovery. An additional 34 Country Estate profile/example rows
are commented out in SGS source: preserve them and track them as
source-disabled, not silently delete, enable, or count them as passing.
Appendix A lists every feature and binding.

Read-only evidence is retained in the SGS inventory session:

- `sgs-executable-adaptation-plan.md`, SHA-256
  `6CD2A2F9559932A20A0E75A671630EFB72ED43075F7AEF8B4CA44ABD5B836603`.
- `sgs-feature-executable-map.json`, SHA-256
  `0034E07F151836767950B10140936E69F8E971496F9805260FF754C372DF488E`.
- Artifact directory:
  `C:\Users\PA3402\.copilot\session-state\99df5767-3f08-4797-a528-f1ff57c03fc9\files`.

The JSON records exact direct/shared page and locator paths, data/frame inputs,
business steps, captures, assertions, mutations, outcome gaps, and 191
path-level retain/adapt/retire decisions. M1 materializes that completed map
as a tracked execution ledger; it is not a second open-ended inventory exercise.

## Non-negotiable implementation rules

1. Preserve every delivered scenario, example row, business variation, and
   promised outcome. Maintain original-source provenance and current adaptation
   provenance separately. Retained code is not automatically accepted as correct.
2. Follow business-readable Gherkin -> thin step definitions -> task-oriented
   page objects -> `BasePage`/shared controls. No locators, browser creation,
   data-generation engines, or duplicated domain algorithms in bindings.
3. Reuse existing PnC behavior where it genuinely matches. Adapt SGS-specific
   business logic and locator knowledge where PnC has no equivalent. Do not
   invoke another binding class as a substitute for shared implementation.
4. One `TestHooks`, one scenario-owned `ScenarioContextData`, one browser/API
   lifecycle, one quote-handoff contract, one evidence/finalization path.
5. Use `GetByTestId` first. Preserve documented ANi HTML-ID exceptions and the
   specifically documented overlay/display exceptions. Missing IDs require live
   DOM evidence and an approved exception or application fix, not guessed CSS,
   XPath, position-based selection, or silent locator substitution.
6. Preserve exact page/frame scope from resolution through action, assertion,
   and evidence. Reject ambiguous controls, generic iframe hints, and a fallback
   to the top document when a required frame is absent.
7. Use existing Playwright waits and semantic controls. Do not copy SGS retry
   generation, fixed sleeps, broad retry loops, browser factories, hooks, or
   pipelines. State-changing workflows remain `NoRetry` unless rerun safety is
   explicitly established.
8. Assert actual values, checked/selected/enabled states, quote/proposal
   identities, and promised premiums/forms/transaction outcomes. Visibility is
   not equality, and transmit-button availability is not transmission.
9. Keep credentials external. Reuse process-only Key Vault loading and current
   Ping authentication. Do not change to Okta or assume another OAuth secret
   works. Generate personal test identity once per scenario; never fabricate
   missing required business inputs or expected outcomes.
10. Follow the two-consecutive-local-runs requirement for completed scenario
    coverage. Unit tests and successful discovery support, but do not replace,
    live verification. A blocked or skipped case is never counted as verified.

Applicable references: `Docs\Contractor-Guide.md`,
`Docs\Architecture-Invariants.md`, `Docs\Locator-Audit.md`,
`Docs\EQ-Upgrade-Breaking-Changes.md`, and `Docs\Tagging-Convention.md`.
The contractor guide contains conflicting page-object DI guidance, and older
examples include locator exceptions that do not satisfy the current policy.
Preserve the actual scenario lifetime, use current approved selector contracts,
and resolve touched documentation inconsistencies explicitly rather than
copying every old example or redesigning DI.

## Verified destination reuse and missing integration

| Surface | Existing implementation to reuse | Required adaptation |
|---|---|---|
| Scenario lifecycle | `Hooks\TestHooks.cs`: `BeforeScenarioAsync`, `AfterStepAsync`, `AfterScenarioAsync`, `FinalizeRun` | Replace the blanket `SgsImported` ignore with explicit per-case readiness; add reporting to the existing lifecycle, not another hook class. |
| State and DI | `Startup.ConfigureServices`, `Helpers\ScenarioContextData.cs`, `Context\PlaywrightContext.cs` | Attach one SGS data/buffer context to the existing scenario scope. Preserve scenario ownership and page availability at construction. |
| Shared business pages | `StepDefinitions\SharedSteps\SharedEQSteps.cs`, `Pages\ExpertQuotePages`, `Pages\ExpertQuotePages\SFP`, `Pages\ExpertQuotePages\PA` | Extract/reuse matching page actions; remediate only directly reused nonconforming inline locator logic. Do not assume EQ pages represent CLDC or PLDC pages. |
| Controls | `Controls\ControlContracts.cs`, `ControlScopeResolver`, `SemanticControlActions`, `PlaywrightControlRuntime` | Pass the scenario's resolver and evidence sink into adapted pages. The default `BasePage(IPage)` creates controls without scenario evidence, so it is insufficient for required SGS locator evidence. |
| Frames | `Controls\FrameScopeHints.cs`: `IFrameScopeHintProvider`, `FrameScopeHintMatcher` | Wire approved product catalogs into `PlaywrightControlRuntime`. Remove reliance on the deleted pilot catalog default. Verify CLEQ/PLDC scope as well as CLDC. |
| Data resolution | `Helpers\RandomGenerators.ResolveRuntimeTokens`, typed models, `ScenarioContextData` | Implement one collision-safe, strict product-aware scenario-data loader; the pilot data engine was removed and there is no active SGS loader. |
| Business outcomes | `BusinessOutcomes\BusinessOutcomeProfiles.cs`, `IBusinessOutcomeVerifier` | Generalize the SFP-only hook/profile selection to workflow-declared assertions. Support state, company, variant, and effective-date distinctions without weakening SFP validation or inventing irrelevant premium/forms requirements for quote-only smoke cases. |
| Quote handoff | `QuoteHandoffs\QuoteHandoff.cs`: `IQuoteHandoff`, `ScenarioQuoteHandoff`, `FileQuoteHandoffStore` | Use scenario state for close/reopen/search; no shared quote text file. Cross-process sharing only through the qualified envelope. |
| Forms | `IFormsOrchestrationService`, `DuckCreekFormsClient`, `FormsEvidenceWriter`, `FormsReportGenerator` | Reuse the existing validation/report path when forms are promised; link its evidence into the unified report. |
| Evidence/reporting | `Infrastructure\ArtifactContext.cs`: `IArtifactContext`, `IArtifactCaptureService`, `ArtifactManifest` | Adapt SGS rich HTML/report presentation and step records onto this owner; add required report/log artifacts and canonical outcome reconciliation. |
| Product ownership | `Products\ProductModules.cs`: `IProductModule`, `ProductModuleRegistry` | Register actual SGS workflow families in the current assembly; no physical project split or new solution. |
| Identity and discovery | `TestPlans\ScenarioAutomationIdentity.cs`, `Tools\CiTestInventory\Program.cs` | Add stable SGS case qualifiers; current state-only argument lookup does not cover SGS `stateCode`/`stateVariant` and can collide across company/effective-date variants. |
| Inventory integrity | `SgsFeatureInventoryTests`, `Resources\Contracts\sgs-*-inventory.json`, `.gitattributes` | Preserve immutable source hashes while tracking deliberate adaptations and case parity. Current tests require every imported feature to remain `NonRunnable`; change that model explicitly rather than disabling integrity checks. |
| Execution/package/ADO | `Scripts\CI\Invoke-PackageSuite.ps1`, `Invoke-TestShard.ps1`, `New-TestPackage.ps1`, `Pipelines\config\shards.json`, `Tools\TestPlanPublisher\CanonicalResultLoader.cs` | Extend existing selectors, inventory, package content, and result/evidence mapping. Do not create a parallel SGS pipeline or reporter that changes test outcomes. |

## Latest SGS findings that shape the implementation

| Source behavior | Required correction, not an optional enhancement |
|---|---|
| PL `AccountInformationPage.SelectMarriedAsync` targets the divorced control; state/driver methods also have wrong or insufficiently scoped targeting. | Apply values to the actual state, marital, and driver controls and assert the selected value in the resolved frame. |
| All six PL rate-filing bindings promise premium/transmission, but pricing methods do not capture or compare premium and final confirmation is presence-style. | Implement the missing premium extraction/comparison and durable policy/transaction identity checks. Transmission still requires explicit execution authorization. |
| CLEQ `EQSFPBasicPolicySteps` and `EQSFPCountryEstatePolicySteps` have placeholder premium verification. | Reuse correct PnC SFP pricing/forms behavior where applicable; verify actual premium and saved/reopened business state. |
| CL `NavigationPage.ClickPricingAsync` targets generic `PageTitle`; some expected values contain Tosca wildcard syntax and forms status is UI-emulated. | Confirm real pricing navigation; define explicit typed comparison rules; use genuine forms results rather than a simulated status control. |
| `UiActions.VerifyAsync` conflates visibility with boolean outcomes; capture semantics are incomplete; CLDC-only resolver wiring can lose frames. | Translate business intent to the destination's typed controls/capture and explicit page/frame scopes; never bring over the flawed generic engine. |
| `BrowserSession.CaptureScreenshotAsync` reuses `scenario.png`; required missing evidence and empty consolidated inputs can look successful. | Give each checkpoint its own evidence, fail on required omissions, and reconcile reporting with the authoritative result. |
| Source scenario retries repeat mutations, and roughly 5,048 placeholder lines remain in source data. | Keep mutating execution `NoRetry`; validate actually required keys and obtain approved missing business values. Existing destination identity tokenization remains in use. |

These findings are source evidence, not proof of today's live application DOM
or approved premium values. Missing business assertions must be implemented,
not treated as SGS behavior that should be preserved for compatibility.

## Execution milestones after approval

### M1 - Source reconciliation and executable coverage ledger

- Reconcile the latest-source map with every retained feature/example; classify
  each dependency as reuse, adapt, replace because defective, or externally
  blocked. Do not stop at counting files.
- Introduce a tracked per-case coverage ledger under `Resources\Contracts`,
  with source ref/hash, feature/binding/page dependencies, data profile,
  selector/frame approval, required outcomes, mutation permission, module,
  stable case ID, evidence, and verification status.
- Keep Gherkin wording and example rows unchanged by default. Propose any
  business-wording changes separately with coverage/source traceability.
- Update the touched architecture/tagging documentation to state that SGS
  business implementations are adapted, not excluded. "Do not copy the whole
  framework" must never mean omitting executable step/page logic again.
- Fix tag normalization and product ownership without losing source tags:
  current SGS tags include both `CL_DC` and `CLDC`, and `smoke_test` rather
  than the destination's standard smoke/regression categories.
- Identify credentials, endpoints, data, and approval gaps once and continue
  safe independent implementation rather than assigning coding tasks to the user.

Exit: all source coverage is accounted for, including additions from the fresh
source; no implementation dependency is silently omitted or called complete.

### M2 - Shared executable bridge and reporting foundation

- Implement a strict, typed SGS data/profile adapter with documented precedence,
  qualified keys, supported expressions, scenario-owned buffers, external
  credentials, and runtime identity tokens. Preserve source business values.
- Validate required data and checksums before browser mutations. Reject stale
  layered manifests, placeholder required values, key collisions, unknown
  required expressions, and absent files explicitly. Rebuild stale checksums
  only after reviewing the actual approved data transformation.
- Route all actions through existing semantic controls; add only needed
  capabilities such as typed capture and comparison using those same contracts.
- Scope product bindings so repeated SGS step wording is not ambiguous. A source
  "open browser session" step uses the hook-owned session rather than creating
  another browser. Keep the source business step sequence intact.
- Wire page/frame resolution and scenario evidence for each product. Correct
  wrong state/marital targets and visibility-as-value/boolean behavior.
- Make outcomes workflow-specific and extend case identity beyond state-only
  matching while preserving existing SFP identities and checksums.
- Add SGS-style step/report records to the existing artifact owner, including
  unique checkpoint paths and failed/missing-evidence outcomes.
- Add focused tests for loader precedence, input application, missing data,
  identity stability, binding uniqueness, control semantics, frame propagation,
  data isolation, and reporting parity. These are implementation safeguards,
  not substitutes for browser scenarios.

Exit: an existing SGS scenario can use the destination runtime with no duplicate
hooks/helpers/retry engines; defect regressions fail for the known bad behavior.
Do not wait for every product page to finish before proving an actual workflow.

### M3 - First real SGS workflows, with original SFP preserved

Use existing delivered features, not invented pilot replacements:

| Order | Existing workflow | Required proof |
|---|---|---|
| Reference | PnC `Features\SFP\SFP_BasicPolicy.feature`, Alabama local profile | Preserve quote identity, approved premium/forms, and the explicitly availability-only transmission contract; rerun forms after the baseline-key fix. |
| First SGS | CLEQ `Smoke\03_EQ_BOP_Smoke_Test.feature`, Alabama | Apply all intended account/address/proposal inputs; capture and reopen the same quote; assert actual selected values and quote/proposal identity; produce the rich report and canonical evidence. |
| Second product | CLDC `Smoke\012_BAP_Smoke_Test.feature`, Alabama | Apply the actual BAP inputs and original promised outcomes; prove exact frame scope in action and locator evidence. |
| Third product | PLDC `Smoke\211_Smoke_Test_Auto.feature`, AZ ANG | Apply intended state/company/auto inputs and assert the actual business identity/outcome; no wrong-control or top-frame fallback. |
| PL control proof | PLDC `181_Auto_Rate_Filings_Policy_1_NB.feature`, one approved example | Verify actual state/marital selections, normalized premium, and real transaction identity/status where transmission is authorized; otherwise record that acceptance portion as blocked. |

After each workflow, fix shared defects once, rerun the affected PnC reference,
and deliver a small reviewed integration commit. Keep other cases explicitly
gated; do not remove all import gates just because one row works.

Exit: each listed case has complete evidence and two consecutive successful
authorized local runs, or an explicit external blocker. A blocked case does not
satisfy the milestone's live-verification gate.

### M4 - Complete all remaining SGS coverage

Use the dependency-based batches below; each is split into small reviewable
commits rather than one product-sized code dump:

| Batch | Features | Purpose |
|---|---|---|
| M4a | CLDC smoke 013-018; CLEQ smoke 04; PLDC smoke 212 and 215 | Reuse the three proven product entry/quote/reopen paths across sibling lines and states. |
| M4b | PLDC 182-186, plus remaining examples of 181 | Complete the common 16-page rate workflow with prior-effective-date/company variations and real premium/transaction assertions. |
| M4c | CLEQ 02, 05, 06 | Full BOP and both SFP variants; replace placeholder premium checks and review the 34 source-disabled Country Estate rows. |
| M4d | CLDC 001-006 | BAP basic/expanded, CPP, CP, GL, and OCP; reuse corrected pricing/submission/forms/coverage behavior. |
| M4e | CLDC 007-011 | IM, Umbrella basic/expanded, WC basic/expanded; complete vehicle/classification and line-specific coverage behavior. |

- Expand ExpertQuote using existing PnC client/account/proposal, BOP, and SFP
  page behavior; retain SGS-specific behavior that is not already implemented.
- Expand CLDC by shared application, account, policy, and line-of-business pages,
  then complete all basic, expanded, OCP, and smoke workflows.
- Expand PLDC by shared account/driver/vehicle/coverage pages, then complete Auto,
  Cycle, prior-effective-date/rate-filing variants, and RV.
- Validate every intended required input is applied to the right control. Do
  not equate reaching a screen, logging data, or checking visibility with
  executing the business step.
- Register each workflow's promised outcomes. Do not broaden a quote-only smoke
  into issuance, nor downgrade an issuance/rating/forms scenario to a quote-only
  smoke. Missing authoritative expectations are visible blockers.
- Retain all source scenario/example combinations and any new latest-source
  coverage. Shared automation is reused; distinct business coverage is not
  deduplicated out of existence.

Exit: every latest-source feature has actual bindings/pages/data/reporting and
is either verified by case or explicitly blocked. No unimplemented bindings,
placeholder passes, or permanent import-only skips may be called delivery.

### M5 - Finish rich reporting and canonical execution parity

- Adapt the actual latest-source report implementation, not a replacement
  dashboard. `src\InsuranceAutomation.Core\ScenarioReport.cs` contains
  `StartStep`, `EndStep`, `RecordDeferredVerification`, `Write`,
  `CompleteAttempt`, and `RefreshAttemptLinks`. Its `StepResult` is private;
  there is no public `ScenarioReportStep` contract to import.
- Use `NUnitScenarioEvidenceFinalizer.FinishAsync`,
  `NUnitEvidencePublisher`, and `NUnitTestEvidenceContext` as adaptation
  references, not additional lifecycle owners.
- Preserve the useful presentation from
  `tools\generate_consolidated_report.py`: feature/application/state/LOB
  statistics, expandable step diagnostics, deferred-verification details,
  screenshot navigation, logs, trace/video links, and honest attempt display.
  The HTML/CSS/JavaScript is inline, not a missing template directory.
- Proposed runtime choice: adapt the SGS C# renderer and translate the
  consolidated Python rendering/aggregation logic into a small .NET 8 report
  utility under the existing `Tools` solution folder. This preserves the
  actual report presentation without adding a Python prerequisite or copying
  the SGS execution framework. Any new utility project is added to the same
  `Playwright_POC.sln`; it is not a product-project split.
- Preserve per-scenario `report.html`/`scenario-result.json` as projections of
  canonical records and consolidated `report.html`, `log.html`, `output.xml`,
  and `summary.json`. The compatibility XML is not a second authoritative test
  result. Do not fabricate a retry, HAR, or bundle link when it does not exist;
  retain approved useful HAR/bundle capture through the existing owner if
  required for report parity. Automatic email/release transport is deferred
  with deployment infrastructure, not required for local reporting.
- Preserve useful SGS report presentation based on the actual latest source:
  business/scenario hierarchy, step status/timing, assertion details, and evidence
  navigation. Link forms reports into the same run instead of replacing them.
- Capture distinct checkpoint screenshots and required logs/traces/videos in
  the scenario artifact tree. Passing and failing policies are explicit.
- Encode report content, redact sensitive data, use portable safe relative
  links, and package required templates/assets. Do not dump credentials or raw
  sensitive scenario data into HTML, logs, or publisher payloads.
- Render/reconcile final status from authoritative NUnit/TRX outcomes including
  setup/step/teardown, DataPool, and required-evidence failures. Never create a
  second success-shaped result while the canonical test is failed.
- Extend the canonical attachment allowlist deliberately: HTML and richer
  artifacts do not automatically bypass current Test Plans privacy/size limits.
- Provide local run entry points using the existing Key Vault helper contract,
  exact case selection, nonempty TRX checks, and a report path.

Exit: report, TRX, scenario manifest, and canonical result manifest agree for
pass, test failure, teardown failure, skipped/blocked, and missing evidence.
Required missing artifacts fail; discovery-only data never looks like a run.

### M6 - Full local qualification, package preservation, and handoff

- Run the complete approved case inventory in controlled batches, twice, with
  distinct data/quote ownership and no unauthorized transmission/issuance.
- Do not infer all-state success from representative cases. Record pass/fail,
  explicit blocker, and evidence links for every source case.
- Preserve .NET 8, separate unit discovery, clean/locked package build,
  private-agent/browser-cache compatibility, disjoint shards, one immutable
  complete package, retry rules, missing-result failure, and existing schedules.
- Exercise source-free package discovery and contract validation locally.
  Live pipeline rollout, schedule changes, and Test Plans publication wait for
  their separate infrastructure approvals; they are not prerequisites to
  implement and verify authorized local workflows.
- Deliver small milestone commits on the existing integration branch. No PR or
  merge to Development is requested by this plan.

Exit: all approved source cases are genuinely verified, or the handoff states
exactly which are blocked and does not describe the whole suite as working.
Operational/ADO readiness is reported separately from local execution readiness.

## Work ownership and milestone handoff

The integration session owns the shared contracts, branch, final verification,
and IDE synchronization. After shared interfaces are stable, independent
product/reporting adaptations may be delegated to isolated workstreams; they
must not concurrently edit shared hooks, DI, configuration, or canonical result
code. The integrator reviews and incorporates changes in dependency order.
The user does not manage these workstreams.

Each milestone handoff states the exact commit, source SHA, changed surfaces,
cases implemented versus live-verified, evidence/report locations, regressions,
and external blockers. Approval of this plan permits safe work to continue
through its milestones; a new architectural decision or unauthorized business
mutation is escalated rather than assumed. No repeated requests for the user
to write code or map dependencies are part of the workflow.

## IDE synchronization after each approved milestone

Keep `C:\PnC Test Automation\PnC-TestAutomation\Playwright_POC.sln` as the
established IDE entry point. The Copilot worktree and that clone are separate.

Copilot will verify the expected repository/branch and a clean disk worktree,
fetch, then fast-forward the IDE clone to the exact reviewed integration commit.
Never merge the integration branch into another checked-out branch, reset
changes, overwrite untracked files, or switch a dirty checkout. Unsaved editor
buffers and an active VS build/test run require a pause rather than assuming
that Git status alone proves it is safe.

After a safe update, use one coordinated Debug build for Test Explorer and the
appropriate Release validation for packaging. Remove only confirmed obsolete
generated `.feature.cs` files, or use Reqnroll's supported clean setting; never
delete legitimate feature files or broad cache directories. Verify compiled
case counts and both checkout SHAs, and report the exact solution path/commit.
Visual Studio may still require accepting a reload prompt; no manual porting or
Git troubleshooting should be delegated to the user.

## External dependencies and decision boundaries

| Dependency | Copilot can do | External authorization or fact needed |
|---|---|---|
| Latest SGS source | Fetch, record SHA, compare coverage, adapt source logic | Repository access if fetch fails; no claim of freshness from cached refs |
| Local authentication | Reuse the six-secret process-only wrapper and Ping provider; validate reads without printing values | Exact approved vault/tenant and secret-read permission; product UI permissions and reachable endpoints |
| Business data/outcomes | Reuse valid SGS values and approved PnC profiles, generate personal identity, validate provenance/checksums | QA approval for missing premium/forms/rate expectations and current business baselines |
| Mutating operations | Implement original save/rate/transmit/issue paths and verify their real results | Explicit environment and operation authorization before actual transmit/bind/issue/payment; rerun/cleanup rules |
| Missing test IDs/frames | Inspect live DOM, record evidence, propose narrow exception or application fix | Approval for new exceptions/application changes; no guessing or silent fallback |
| Architecture | Continue logical modules inside `TestAutomation.dll` | David's decision before physical project splitting, lifetime redesign, or a broader architecture change |
| CI/ADO rollout | Preserve contracts and prepare complete packages/mappings/dry runs | Service connection/PAT, plan/suite/configuration IDs, agent access, scheduling/retention and rollout decisions |

Do not freeze unrelated safe work while one external gate is unresolved.
Blocked work remains visible and incomplete. Source receipt, code adaptation,
local verification, and operational readiness are different statuses.

## Approval boundary and completion criteria

Approval of this plan permits implementation in the stated milestones, including
the narrow shared hook/DI/project/config changes and report utility identified
above. It does not
authorize production activity, policy issuance/transmission/payment, new
credentials, a project split, new pipelines, or a PR.

Before calling the integration complete, require:

- Exact reconciliation of the latest approved source feature/case set.
- One binding resolution per step, no lost examples, no duplicated shard cases.
- Actual intended input application and promised business assertions.
- Conforming selectors and proven frame propagation, with documented exceptions.
- Two consecutive authorized local passes for each completed case and preserved
  existing PnC behavior.
- Rich SGS-style reporting and required evidence with canonical outcome parity.
- Complete package contents and unchanged fail-closed result handling.
- Clean, verified commit/checkout handoff with the established solution visible
  in Visual Studio.

The next action after approval is M1/M2 implementation followed immediately by
the first original CLEQ BOP smoke workflow, not another import-only milestone.
Until explicit approval: stop after presenting this plan.

## Appendix A - Complete latest-source feature/binding coverage

Paths below are relative to each product's `Features` directory. Binding names
identify `<product project>\StepDefinitions\<name>.cs`. Product project roots:

- CLDC: `tests\CommercialLines.DuckCreek.Tests`.
- CLEQ: `tests\CommercialLines.ExpertQuote.Tests`.
- PLDC: `tests\PersonalLines.DuckCreek.Tests`.

All three also use their product's `StepDefinitions\ApplicationSteps.cs`; adapt
that glue to the PnC lifecycle/configuration rather than copy its browser owner.
Page files are under the same project's `Pages`, with locator source under
`Pages\Locators`; exact per-feature direct/transitive dependencies are retained
in the checksummed research map.

| Product | Feature path | Source binding class | Active cases | Initial adaptation batch |
|---|---|---|---:|---|
| CLDC | `001_BAP_Basic_Policy.feature` | `BAPBasicPolicySteps` | 44 | M4d |
| CLDC | `002_BAP_Expanded.feature` | `BAPExpandedSteps` | 44 | M4d |
| CLDC | `003_CPP_Basic_Policy.feature` | `CPPBasicPolicySteps` | 16 | M4d |
| CLDC | `004_CP_Basic_Policy.feature` | `CPBasicPolicySteps` | 16 | M4d |
| CLDC | `005_GL_Basic_Policy.feature` | `GLBasicPolicySteps` | 16 | M4d |
| CLDC | `006_GL_OCP_Policy.feature` | `GLOCPPolicySteps` | 14 | M4d |
| CLDC | `007_IM_Basic_Policy.feature` | `IMBasicPolicySteps` | 16 | M4e |
| CLDC | `008_UMB_Basic_Policy.feature` | `UMBBasicPolicySteps` | 46 | M4e |
| CLDC | `009_UMB_Expanded.feature` | `UMBExpandedSteps` | 45 | M4e |
| CLDC | `010_WC_Basic_Policy.feature` | `WCBasicPolicySteps` | 36 | M4e |
| CLDC | `011_WC_Expanded.feature` | `WCExpandedSteps` | 36 | M4e |
| CLDC | `Smoke\012_BAP_Smoke_Test.feature` | `BAPSmokeTestSteps` | 44 | M3, then remaining examples |
| CLDC | `Smoke\013_CP_Smoke_Test.feature` | `CPSmokeTestSteps` | 16 | M4a |
| CLDC | `Smoke\014_GL_Smoke_Test.feature` | `GLSmokeTestSteps` | 16 | M4a |
| CLDC | `Smoke\015_IM_Smoke_Test.feature` | `IMSmokeTestSteps` | 16 | M4a |
| CLDC | `Smoke\016_WC_Smoke_Test.feature` | `WCSmokeTestSteps` | 34 | M4a |
| CLDC | `Smoke\017_CPP_Smoke_Test.feature` | `CPPSmokeTestSteps` | 16 | M4a |
| CLDC | `Smoke\018_UMB_Smoke_Test.feature` | `UMBSmokeTestSteps` | 44 | M4a |
| CLEQ | `02_EQ_BOP_Basic_Policy.feature` | `EQBOPBasicPolicySteps` | 45 | M4c |
| CLEQ | `05_EQ_SFP_Basic_Policy.feature` | `EQSFPBasicPolicySteps` | 35 | M4c |
| CLEQ | `06_EQ_SFP_Country_Estate_Policy.feature` | `EQSFPCountryEstatePolicySteps` | 1 | M4c; also review 34 commented rows |
| CLEQ | `Smoke\03_EQ_BOP_Smoke_Test.feature` | `EQBOPSmokeTestSteps` | 45 | M3, then remaining examples |
| CLEQ | `Smoke\04_EQ_SFP_Smoke_Test.feature` | `EQSFPSmokeTestSteps` | 35 | M4a |
| PLDC | `181_Auto_Rate_Filings_Policy_1_NB.feature` | `AutoRateFilingsPolicy1NBSteps` | 50 | M3, then M4b |
| PLDC | `182_Auto_Rate_Filings_Policy_3_NB_Prior_Eff_Date.feature` | `AutoRateFilingsPolicy3NBPriorEffDateSteps` | 50 | M4b |
| PLDC | `183_Auto_Rate_Filings_Common_Policy_NB.feature` | `AutoRateFilingsCommonPolicyNBSteps` | 50 | M4b |
| PLDC | `184_Auto_Rate_Filings_Common_Policy_NB_Prior_Eff_Date.feature` | `AutoRateFilingsCommonPolicyNBPriorEffDateSteps` | 50 | M4b |
| PLDC | `185_Cycle_Rate_Filings_Policy_1_NB_1.feature` | `CycleRateFilingsPolicy1NB1Steps` | 49 | M4b |
| PLDC | `186_Cycle_Rate_Filings_Policy_3_NB_Prior_Eff_Date.feature` | `CycleRateFilingsPolicy3NBPriorEffDateSteps` | 49 | M4b |
| PLDC | `Smoke\211_Smoke_Test_Auto.feature` | `SmokeTestAutoSteps` | 47 | M3, then remaining examples |
| PLDC | `Smoke\212_Smoke_Test_Cycle.feature` | `SmokeTestCycleSteps` | 47 | M4a |
| PLDC | `Smoke\215_Smoke_Test_RV.feature` | `SmokeTestRVSteps` | 47 | M4a |
| Total | 32 features | 32 scoped bindings | 1,115 | All coverage remains required |
