# SGS reporting adaptation

The reporting code is a presentation/projection layer, **not a test runner or a
second scenario lifecycle**. `Reporting` compiles into `TestAutomation.dll`.
`Tools\SgsReport` is a .NET 8 console utility in the existing `04 - Tools`
solution folder. It references the main assembly and `TestPlanPublisher`;
neither references the utility. No Python, CDN, service, new browser, retry
engine, or additional hook is needed.

This slice does not enable SGS business scenarios, modify their coverage, or
claim live execution. The existing integration-owned hooks must supply the
scenario metadata, recorder events, canonical outcome and finalized evidence.

## Source provenance and retained presentation

The original reference is SGS
`ecd9019ab991028341ad76de11cff06aa43cb32f`, confirmed against remote `main` on
2026-09-18. The current reference is
`d1fa9404f1a245722879e523626beb72e68d033b`, fetched from
`refs/remotes/origin/main` on 2026-09-22 at 12:57:46 UTC. The preserved delta
manifest SHA-256 is
`E3DBC24F204A89377C66A4E306A7FB20630B923DA8432BE5522BAFDA6B20F8CB`.
These references were read from pinned Git objects / exported source, not the
stale source working tree.

The source-backed implementation adapts:

- `src\InsuranceAutomation.Core\ScenarioReport.cs`: business steps, timing,
  diagnostics and deferred assertions. Its private `StepResult` was not a
  reusable public contract; the destination uses immutable report records.
- `tools\generate_consolidated_report.py`: inline Robot-style REPORT/LOG views,
  feature/application/state/LOB statistics, filters, suite/test/keyword
  hierarchy, expandable diagnostics, attempt panels, evidence tabs, screenshot
  gallery/lightbox, logs, raw result display and video links.
- The `d1fa940` delta: contained, repeatable nonoverlapping scenario roots and
  file-labelled duplicate attempts. Identical attachment copies are excluded
  only after comparing the manifest, projection, report and every declared
  artifact byte-for-byte.

The latest delta does not change the inline CSS/JavaScript presentation.
`SgsReportAssets` preserves that presentation while fixing repeated attempt
event-handler registration and mobile statistics/log overflow, and adding
keyboard/previous/next screenshot navigation. Actual binding metadata replaces
source regex guessing.

Source `NUnitScenarioEvidenceFinalizer`, `NUnitEvidencePublisher`, and evidence
contracts informed sequencing only; none was transplanted. The source's new
`excludeVideos` / `excludePassedVideos` defaults, release packaging and Python
transport were **not** copied. The canonical destination profile still governs
all required artifacts, including trace and video.

## Existing-owner integration contract

Public API in `PnCTestAutomation.Reporting`:

```csharp
ScenarioReportProjection ScenarioReportProjector.Project(
    ArtifactManifest manifest,
    ScenarioReportMetadata metadata,
    ReportRedactor? redactor = null);

ScenarioReportDocuments ScenarioReportRenderer.Render(
    ScenarioReportProjection projection,
    ScenarioReportEvidence evidence,
    ReportLimits? limits = null,
    ReportRedactor? redactor = null);

ScenarioReportFiles ScenarioReportWriter.Write(
    string scenarioRoot,
    ArtifactManifest manifest,
    ScenarioReportMetadata metadata,
    ReportRedactor? redactor = null,
    ReportLimits? limits = null);
```

`Project` and `Render` do no file I/O and do not derive an authoritative outcome
from steps. `Write` resolves existing evidence and writes only the two reserved
files. It never calls `RecordFile`, `Complete`, `Assert`, or browser APIs.
`ScenarioReportFiles.Issues` must be inspected by the existing finalizer.

`ScenarioReportMetadata` requires feature, scenario, application, state, LOB,
execution ID and an actual attempt number (default one). Use an explicit
`"Not recorded"` display value when a classification is genuinely unavailable;
do not infer a business value. Tags, steps, deferred failures and diagnostics
are immutable collections. `ReportStep` supports a parent order, captured
binding method/source/line, explicit Pass/Fail/Skip status, start time, elapsed
milliseconds, approved display data, diagnostics and manifest-relative
screenshot paths. Unfinished, duplicate, cyclic, unreasonably deep, or
invalid-duration steps are rejected.

`ScenarioReportRecorder` is an optional scenario-owned recorder:
`StartStep` returns an order ID; `EndStep` takes that ID and an explicit status.
Child steps must finish before their parent. `Snapshot(metadata)` refuses
active steps. It uses monotonic elapsed time, has no static scenario state and
never owns the test outcome or browser. It only records events the existing
hook/page flow actually supplies; it does not create skipped steps or retries.

The transaction belongs to `IArtifactContext`:

```csharp
var metadata = recorder.Snapshot(scenarioMetadata);
var manifest = artifacts.Complete(authoritativeOutcome, snapshot =>
{
    var files = ScenarioReportWriter.Write(
        artifacts.ScenarioRoot, snapshot, metadata, redactor);
    if (snapshot.Outcome != ArtifactOutcome.Failed && files.Issues.Length != 0)
        throw new ArtifactEvidenceException(
            "Report evidence disagrees with the canonical scenario outcome.");
});
```

Before this call the existing finalizer must finish business/deferred assertions,
browser teardown, DataPool handling, screenshots, trace/video finalization and
log flushing, then record their required component outcomes. Register real
nonempty files and call `Require` for the chosen profile. The callback must not
mutate the owner. Unexpected issues must fail finalization; do not swallow
exceptions or turn a failed owner snapshot into a successful report.

The owner reserves the `ScenarioReportHtml` and `ScenarioResultJson` records,
paths and timestamps, freezes one manifest, invokes the writer, validates the
generated files, then persists that exact manifest. Self-produced files are
excluded only from the writer's pre-render checks. Final aggregation requires
both outputs. Existing required-evidence failures are already represented in
the snapshot; the writer can produce a matching failure report before the
owner raises the evidence exception. If rendering itself fails, the owner
deletes both partial projections and persists a failed manifest.

Use `ArtifactReportPaths.Report` / `.Result` (also exposed by
`ScenarioReportWriter.ReportRelativePath` / `.ResultRelativePath`):

| Location relative to scenario root | Owner / purpose |
| --- | --- |
| `manifest.json` | Canonical artifact owner; unchanged reporting authority |
| `reports\report.html` | Offline scenario report |
| `reports\scenario-result.json` | Immutable redacted report projection |
| Manifest-listed evidence paths | Existing capture/log/forms owners |

Projection schema `2.0` includes the canonical outcome, failed components,
required evidence, evidence errors and timestamps. `TestIdentityHash` binds the
exact raw canonical identity without disclosing sensitive identity text;
`TestFullName` is redacted display text. `ManifestFingerprint` hashes the
serialized frozen manifest, so a stale pre-teardown projection cannot reconcile
with a later failed manifest. The HTML also carries that fingerprint/status;
a stale or corrupt individual HTML report is not linked.

## Canonical aggregation

Example in PowerShell, after the actual runner has completed:

```powershell
dotnet run --project .\Tools\SgsReport\SgsReport.csproj -- `
  --evidence-root 'C:\runs\qualification' `
  --canonical-result 'C:\runs\qualification\canonical.trx' `
  --scenario-root 'agent-1\Artifacts' `
  --scenario-root 'agent-2\Artifacts' `
  --output-dir 'C:\runs\qualification\consolidated'
```

Omit `--scenario-root` to inspect the evidence root itself. For transported runs,
prefer explicit canonical agent artifact roots to exclude runner attachment
copies. Roots must exist, remain inside the evidence root and not overlap.
The output directory must be inside the evidence root, distinct from individual
report directories, and must not overwrite the canonical input. Copy the
evidence tree together with the report to preserve portable relative links.

The public utility API is
`ReportAggregator.Generate(SgsReportOptions) -> SgsReportResult`.
It always attempts these consolidated outputs when the owned output path is
safe:

| File | Meaning |
| --- | --- |
| `report.html` | Source-backed offline report and rich execution-log view |
| `log.html` | Standalone log with actual attempts and diagnostics |
| `output.xml` | Robot-compatible projection; **not** canonical execution |
| `summary.json` | Schema `2.0`: canonical counts, gate status, dimensions and issues |

Exit `0` means a nonempty, fully reconciled, all-passing canonical run. Exit `1`
means canonical failures or skips (a skip is not verification). Exit `2` means
invalid/missing canonical input, reconciliation failure, required evidence
failure, unsafe input or an output failure. A missing/empty/discovery-only
canonical result never becomes a successful report. Evidence with no matching
execution is shown separately, not synthesized into test counts.

`summary.json` retains the source total/passed/failed/attempts/retried/passRate/
duration/features keys and adds skipped, canonicalStatus, valid, issues,
applications, states, LOBs and duplicate-copy information. `failed` is the actual
canonical failed count, not total-minus-passed. When evidence is invalid but the
canonical tests passed, the gate `status` is FAIL while the canonical counts
remain unchanged. XML test statuses preserve SKIP; suite-level reporting errors
do not rewrite individual canonical outcomes. XML statistics expose the standard
`pass` attribute and retain the source's `ok` alias for existing consumers;
both reflect the same canonical passed count.

The canonical reader is shared with the existing publisher:

```csharp
IReadOnlyList<CanonicalReportResult> CanonicalResultLoader.LoadReportResults(
    string canonicalResultPath);

// CanonicalReportResult:
// TestIdentity, CanonicalReportOutcome Outcome, TimeSpan Duration,
// string? FailureMessage
```

It accepts actual TRX `UnitTestResult` entries or NUnit `test-run/test-case`
entries, requires nonempty results and consistent final counters, validates
unique identities, finite/nonnegative durations and timestamps, and rejects
setup/teardown/run failures inconsistent with individual results. TRX uses
`testName`, matching the existing publisher; NUnit uses `fullname`. The raw
identity supplied to `ArtifactContext` must be the same runner identity.
VSTest/NUnit may put an ignore reason in a skipped TRX result's `ErrorInfo`
and leave `Counters.notExecuted` at zero. The reader preserves that reason
and derives skipped status from the actual results, while requiring exact
total/executed/passed/failed counts and any populated skipped count. This
runner representation never converts a skip into a pass or accepts missing
required counter fields.
The reporting outcome supports Passed, Failed and Skipped. Existing ADO `Load`
still accepts only its previous Passed/Failed contract and still enforces its
package/result mapping, safe attachment allowlist and 4 MiB upload limit.
Publication transport is unchanged.

Each final canonical test must match its finalized manifest/projection and actual
attempt group. Attempt numbers must be unique, contiguous and chronological;
the final manifest must agree with the canonical outcome. Separate execution
groups, unmatched identities, duplicate automation IDs, missing cases, missing
reports, changed attachment copies or conflicting attempts fail the gate.
No timestamp-based "latest" guess or simulated rerun repairs the result.

## Privacy, file safety and limits

Only explicitly supplied display metadata is accepted. Do not pass raw profile
objects, credential stores, page dumps or unfiltered request/response payloads.
Use `ReportRedactor` at log capture as well as projection; supply known sensitive
values when a secret may appear without a recognizable key. Structured sensitive
keys, credential headers, URL user info/query/fragment data, JWTs, SSNs, simple
sensitive XML values and email text are redacted. HTML attributes/text and XML
are encoded. Redaction preserves exact
identity correlation by hashing the original identity before display redaction.

The reader only links manifest-registered, existing, nonempty, contained files.
`ArtifactPathGuard` is reused and ancestor reparse points are checked. Absolute,
UNC, traversal, encoded traversal, alternate streams and active/external URI
inputs are rejected. Sensitive filenames are rejected instead of "redacting"
them into broken or misleading paths. A screenshot referenced by a step must be
present as actual registered screenshot evidence. Missing optional trace/video/
HAR/bundle assets are visibly unavailable, not invented.

Execution/console/network logs are embedded as redacted text. A changed or
truncated log is not linked directly, avoiding bypass of the sanitized preview.
Original binary evidence (screenshots, trace, video and existing forms HTML)
remains governed by the canonical capture/privacy policy; text redaction cannot
remove private pixels from an image or private data inside a trace.
HTML/media are **not** newly permitted Azure DevOps attachments.

Defaults: 5 MiB input projection JSON, 10 MiB individual report HTML, 2 MiB per
embedded log, 512 KiB embedded raw JSON, 12 MiB per image, 20 embedded images per
scenario and 24 MiB cumulative image payload per reader. Oversized image/raw
previews are visibly omitted while genuine safe file links remain available.
The writer retries oversized HTML without inline image payloads, then fails
explicitly if the HTML/JSON output is still too large. Truncated logs stop at a
complete line; their unexamined original file is not linked.

## Focused verification

```powershell
dotnet test .\TestAutomation.UnitTests\TestAutomation.UnitTests.csproj `
  --filter 'FullyQualifiedName~SgsReportingTests|FullyQualifiedName~CanonicalReportResultsTests|FullyQualifiedName~ArtifactContextTests|FullyQualifiedName~TestPlanPublisherTests'
```

These tests cover pass/failure/skip, owner-backed transactional finalization,
teardown and required-evidence failures, stale projection/HTML fingerprints,
actual attempt grouping, identical and conflicting copies, empty/missing/
malformed canonical inputs, counter/identity mismatches, source UI structure,
all output files, redaction, encoding, portable links and traversal/reparse
rejection. The offline sample emitted by the sample test is explicitly labelled
**synthetic unit fixture - NOT LIVE EXECUTION**. It is presentation evidence,
not proof of business coverage or an authorized application run.
