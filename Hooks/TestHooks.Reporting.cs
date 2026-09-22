using Microsoft.Playwright;
using PnCTestAutomation.Artifacts;
using PnCTestAutomation.Reporting;
using Reqnroll;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnitTestContext = NUnit.Framework.TestContext;

namespace PnCTestAutomation.Hooks
{
    public partial class TestHooks
    {
        private const string NotRecorded = "Not recorded";
        private readonly ScenarioReportRecorder _reportRecorder;
        private readonly ScenarioReportPrivacy _reportPrivacy;
        private readonly ConcurrentQueue<ArtifactEvidenceException> _completionFailures = new();
        private readonly Stack<(int Order, int DiagnosticStart)> _reportSteps = new();
        private readonly List<IPage> _reportPages = new();
        private readonly object _reportPageGate = new();
        private ScenarioReportMetadata _reportMetadata;
        private bool _reportingEnabled;
        private bool _browserListenersAttached;
        private int _browserDiagnosticCount;

        private void InitializeReporting(string automationId, IEnumerable<string> tags)
        {
            _reportingEnabled = automationId != null;
            if (!_reportingEnabled)
                return;

            _artifacts.Require(
                ArtifactKind.ScenarioReportHtml, ArtifactKind.ScenarioResultJson, ArtifactKind.ExecutionLog);
            var suppliedAttempt = Environment.GetEnvironmentVariable("TEST_ATTEMPT_NUMBER");
            var attempt = 1;
            if (suppliedAttempt != null &&
                (!int.TryParse(suppliedAttempt, NumberStyles.None, CultureInfo.InvariantCulture, out attempt) || attempt < 1))
                throw new InvalidOperationException("TEST_ATTEMPT_NUMBER must be a positive integer supplied by the owning runner.");
            _reportMetadata = new ScenarioReportMetadata(
                _featureContext.FeatureInfo.Title, _scenarioContext.ScenarioInfo.Title,
                NotRecorded, TryGetScenarioStateAbbreviation() ?? NotRecorded, NotRecorded,
                _artifacts.RunId, attempt)
            {
                Tags = tags.Order(StringComparer.Ordinal).ToImmutableArray()
            };
            RecordDiagnostic("scenario", "info", "Scenario lifecycle started.");
        }

        private void SkipScenario(string reason)
        {
            var safeReason = _reportPrivacy.CreateRedactor().Text(reason);
            RecordDiagnostic("preflight", "skip", safeReason);
            NUnit.Framework.Assert.Ignore(safeReason);
        }

        [BeforeStep(Order = int.MinValue)]
        public void BeforeStep()
        {
            if (!_reportingEnabled)
                return;
            var step = _scenarioContext.StepContext.StepInfo;
            var method = step.BindingMatch?.StepBinding?.Method;
            var binding = method == null ? null :
                new ReportBinding($"{method.Type.FullName}.{method.Name}", NotRecorded);
            var order = _reportRecorder.StartStep(
                $"{step.StepDefinitionType} {step.Text}", binding,
                _reportSteps.TryPeek(out var parent) ? parent.Order : null);
            _reportSteps.Push((order, _reportRecorder.ReadDiagnostics().Length));
        }

        [AfterStep(Order = int.MaxValue)]
        public async Task AfterStepAsync()
        {
            var stepContext = _scenarioContext.StepContext;
            var status = stepContext.Status switch
            {
                ScenarioExecutionStatus.OK => ReportStatus.Pass,
                ScenarioExecutionStatus.Skipped => ReportStatus.Skip,
                _ => ReportStatus.Fail
            };
            var error = _reportPrivacy.CreateRedactor().Text(stepContext.StepError?.Message);
            ArtifactEvidenceException captureFailure = null;
            var screenshots = ImmutableArray<string>.Empty;
            if (status != ReportStatus.Skip && _context.Page is { IsClosed: false } &&
                (_reportingEnabled || status == ReportStatus.Fail))
            {
                try
                {
                    if (status == ReportStatus.Fail)
                        RequireFailureEvidence();
                    var screenshot = await CaptureScreenshotAsync("step-checkpoint");
                    screenshots = [screenshot.RelativePath];
                }
                catch (Exception exception)
                {
                    captureFailure = RecordCompletionFailure("step-screenshot", exception);
                    status = ReportStatus.Fail;
                    error = string.Join(Environment.NewLine,
                        new[] { error, captureFailure.Message }.Where(value => !string.IsNullOrEmpty(value)));
                }
            }

            if (_reportingEnabled)
            {
                if (!_reportSteps.TryPop(out var step))
                    throw RecordCompletionFailure("step-recording",
                        new InvalidOperationException("AfterStep has no matching scenario-owned BeforeStep record."));
                var diagnostics = _reportRecorder.ReadDiagnostics().Skip(step.DiagnosticStart).ToArray();
                var method = stepContext.StepInfo.BindingMatch?.StepBinding?.Method;
                _reportRecorder.EndStep(step.Order, status, error, screenshots: screenshots,
                    consoleErrors: diagnostics.Where(item => item.Component == "browser-console")
                        .Select(item => item.Message).ToImmutableArray(),
                    networkErrors: diagnostics.Where(item => item.Component == "browser-network")
                        .Select(item => item.Message).ToImmutableArray(),
                    binding: method == null ? null :
                        new ReportBinding($"{method.Type.FullName}.{method.Name}", NotRecorded));
            }
            if (captureFailure != null)
                throw captureFailure;
        }

        private Task<ArtifactRecord> CaptureScreenshotAsync(string checkpoint) =>
            _artifactCapture.CaptureAsync(
                ArtifactKind.Screenshot, checkpoint, ".png",
                path => _context.Page.ScreenshotAsync(new() { Path = path, FullPage = true }));

        private void AttachBrowserReporting()
        {
            if (!_reportingEnabled)
                return;
            _browserContext.Page += OnReportPage;
            _browserContext.RequestFailed += OnReportRequestFailed;
            _browserContext.Response += OnReportResponse;
            _browserListenersAttached = true;
            _artifacts.Require(ArtifactKind.ConsoleLog, ArtifactKind.NetworkLog);
        }

        private void OnReportPage(object sender, IPage page)
        {
            lock (_reportPageGate)
            {
                if (_reportPages.Contains(page))
                    return;
                _reportPages.Add(page);
                page.Console += OnReportConsole;
                page.PageError += OnReportPageError;
            }
        }

        private void OnReportConsole(object sender, IConsoleMessage message)
        {
            if (message.Type == "error")
                RecordBrowserDiagnostic("browser-console", message.Text);
        }

        private void OnReportPageError(object sender, string error) =>
            RecordBrowserDiagnostic("browser-console", error);

        private void OnReportRequestFailed(object sender, IRequest request) =>
            RecordBrowserDiagnostic("browser-network", $"{request.Method} {request.Url}: {request.Failure}");

        private void OnReportResponse(object sender, IResponse response)
        {
            if (response.Status >= 400)
                RecordBrowserDiagnostic("browser-network", $"{response.Request.Method} {response.Url}: HTTP {response.Status}");
        }

        private void RecordBrowserDiagnostic(string component, string message)
        {
            try
            {
                var count = Interlocked.Increment(ref _browserDiagnosticCount);
                if (count > 500)
                {
                    if (count == 501)
                        _reportRecorder.RecordDiagnostic("browser", "warning",
                            "Browser diagnostics exceeded 500 events; additional events are not retained in the text report.");
                    return;
                }
                // Do not retain a severed credential or PII value when an event exceeds the text budget.
                _reportRecorder.RecordDiagnostic(component, "error", message.Length <= 4096
                    ? message : $"An oversized browser diagnostic was omitted ({message.Length} characters).");
            }
            catch (Exception exception)
            {
                _artifacts.RecordComponentOutcome("browser-diagnostics", false);
                _completionFailures.Enqueue(new ArtifactEvidenceException(
                    $"Browser diagnostic capture failed ({exception.GetType().Name})."));
            }
        }

        private IPage[] ReportPages()
        {
            lock (_reportPageGate)
                return _reportPages.ToArray();
        }

        private void DetachBrowserReporting()
        {
            if (!_browserListenersAttached)
                return;
            _browserContext.Page -= OnReportPage;
            _browserContext.RequestFailed -= OnReportRequestFailed;
            _browserContext.Response -= OnReportResponse;
            foreach (var page in ReportPages())
            {
                page.Console -= OnReportConsole;
                page.PageError -= OnReportPageError;
            }
        }

        private void RecordDiagnostic(string component, string level, string message) =>
            _reportRecorder.RecordDiagnostic(component, level, _reportPrivacy.CreateRedactor().Text(message));

        private ArtifactEvidenceException RecordCompletionFailure(string component, Exception exception)
        {
            var failure = new ArtifactEvidenceException(
                $"{component} failed ({exception.GetType().Name}): " +
                _reportPrivacy.CreateRedactor().Text(exception.Message));
            _artifacts.RecordComponentOutcome(component, false);
            _completionFailures.Enqueue(failure);
            RecordDiagnostic(component, "error", failure.Message);
            return failure;
        }

        private async Task TryCompleteAsync(string component, Func<Task> action)
        {
            try
            {
                await action();
            }
            catch (Exception exception)
            {
                RecordCompletionFailure(component, exception);
            }
        }

        private ScenarioReportMetadata SnapshotReportMetadata()
        {
            var identity = _reportMetadata ?? throw new InvalidOperationException("Scenario report metadata was not initialized.");
            identity = identity with
            {
                State = _scenarioData.SgsData.StateVariant ?? TryGetScenarioStateAbbreviation() ??
                    _scenarioData.RatingState ?? _scenarioData.State ?? identity.State,
                Lob = !string.IsNullOrWhiteSpace(_scenarioData.FormsLob) ? _scenarioData.FormsLob :
                    !string.IsNullOrWhiteSpace(_scenarioData.ProductSelection) ? _scenarioData.ProductSelection : identity.Lob
            };
            return _reportPrivacy.CreateRedactor().Metadata(_reportRecorder.Snapshot(identity));
        }

        private async Task WriteScenarioLogsAsync(ScenarioReportMetadata metadata)
        {
            var diagnostics = metadata?.Diagnostics ??
                _reportRecorder.ReadDiagnostics().Select(item => item with
                {
                    Message = _reportPrivacy.CreateRedactor().Text(item.Message)
                }).ToImmutableArray();
            await _artifactCapture.CaptureAsync(ArtifactKind.ExecutionLog, "scenario-execution", ".log",
                path => File.WriteAllTextAsync(path,
                    metadata == null ? ReportJson.Serialize(diagnostics) : ReportJson.Serialize(metadata)));
            if (!_browserListenersAttached)
                return;
            foreach (var (kind, component) in new[]
            {
                (ArtifactKind.ConsoleLog, "browser-console"), (ArtifactKind.NetworkLog, "browser-network")
            })
            {
                var entries = diagnostics.Where(item => item.Component == component || item.Component == "browser").ToArray();
                var text = $"Scenario-owned {component} listener; retained events: {entries.Length}.{Environment.NewLine}" +
                    string.Join(Environment.NewLine, entries.Select(item => $"{item.Timestamp:O} [{item.Level}] {item.Message}"));
                await _artifactCapture.CaptureAsync(kind, component, ".log",
                    path => File.WriteAllTextAsync(path, text));
            }
        }

        private void WriteFrozenReport(ArtifactManifest manifest, ScenarioReportMetadata metadata)
        {
            var files = ScenarioReportWriter.Write(
                _artifacts.ScenarioRoot, manifest, metadata, _reportPrivacy.CreateRedactor());
            var unexpected = files.Issues.Where(issue =>
                !(manifest.Outcome == ArtifactOutcome.Failed && manifest.EvidenceErrors.Count > 0 &&
                  issue.Code is "manifest-evidence-error" or "required-evidence" or "missing-evidence")).ToArray();
            if (unexpected.Length > 0)
                throw new ArtifactEvidenceException(string.Join(" ", unexpected.Select(issue => $"{issue.Code}: {issue.Message}")));
            NUnitTestContext.WriteLine($"[report] {ArtifactReportPaths.Report}");
        }
    }
}
