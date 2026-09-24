using System.Net;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Text;
using System.Text.Json;

namespace InsuranceAutomation.Core;

public sealed class ScenarioReport
{
    private const long MaxScenarioResultBytes = 5 * 1024 * 1024;
    private const long MaxReportHtmlBytes = 10 * 1024 * 1024;

    private readonly List<StepResult> _steps = [];
    private readonly List<DeferredVerificationFailure> _deferredVerifications = [];
    private readonly string _artifactDirectory;
    private readonly DateTimeOffset _scenarioStartUtc = DateTimeOffset.UtcNow;
    private DateTime _currentStart;
    private string _currentStep = string.Empty;
    private List<ReportAction> _actions = [];
    private readonly AsyncLocal<ReportAction?> _activeAction = new();

    public async Task<T> TraceActionAsync<T>(string method, string operation, string target,
        IReadOnlyDictionary<string, string> data, Func<Task<T>> action)
    {
        var sensitive = Regex.IsMatch(target + " " + method, "password|passwd|secret|token|credential", RegexOptions.IgnoreCase);
        var node = new ReportAction
        {
            Method = method, Operation = operation, Target = target,
            Data = data.ToDictionary(x => x.Key, x => sensitive || Regex.IsMatch(x.Key,
                "password|passwd|pwd|secret|token|authorization|api[_ -]?key", RegexOptions.IgnoreCase) ? "***" : x.Value)
        };
        var parent = _activeAction.Value;
        var siblings = parent?.Children ?? _actions;
        lock (siblings) siblings.Add(node);
        _activeAction.Value = node;
        var timer = Stopwatch.StartNew();
        try
        {
            var result = await action();
            if (result is bool boolean) node.Result = boolean.ToString();
            if (node.Status == "RUNNING") node.Status = "PASS";
            return result;
        }
        catch (Exception ex)
        {
            node.Status = "FAIL";
            node.Error = sensitive ? "Sensitive action failed; details omitted." : ex.Message;
            throw;
        }
        finally
        {
            node.DurationMilliseconds = timer.Elapsed.TotalMilliseconds;
            _activeAction.Value = parent;
        }
    }
    private IReadOnlyDictionary<string, string> _scenarioData = new Dictionary<string, string>();
    public void SetScenarioData(IReadOnlyDictionary<string, string> data) =>
        _scenarioData = new Dictionary<string, string>(data);
    public string? ScreenshotPath { get; set; }
    private readonly ScenarioAttemptContext? _attemptContext = ScenarioAttemptContext.Current;
    public int AttemptNumber { get; }
    public string ReportPath => Path.Combine(_artifactDirectory, "report.html");

    public ScenarioReport(string artifactDirectory)
    {
        _artifactDirectory = artifactDirectory;
        AttemptNumber = _attemptContext?.AttemptNumber ?? 1;
        _attemptContext?.Register(this);
    }

    public void StartStep(string step)
    {
        _currentStep = step;
        _actions = [];
        _currentStart = DateTime.Now;
    }


    public void RecordDeferredVerification(DeferredVerificationFailure failure)
    {
        _deferredVerifications.Add(failure);
        if (_activeAction.Value is { } action)
        {
            action.Status = "FAIL";
            action.Error = "Deferred verification failed; see step verification details.";
        }
    }

    public void EndStep(bool passed, string? error, IReadOnlyDictionary<string, string> data, string? screenshot, StepEvidence evidence,
        string? binding = null, bool bindingCaptured = false)
    {
        _steps.Add(new StepResult
        {
            Step = _currentStep,
            Actions = _actions,
            Binding = binding ?? string.Empty,
            BindingCaptured = bindingCaptured,
            Passed = passed,
            Error = error ?? string.Empty,
            Duration = DateTime.Now - _currentStart,
            Data = new Dictionary<string, string>(data),
            Screenshot = screenshot ?? string.Empty,
            ConsoleErrors = string.Join("\n", evidence.ConsoleErrors),
            NetworkErrors = string.Join("\n", evidence.NetworkErrors)
        });
    }

    public void Write(string feature, string scenario, string logPath, string? tracePath, string? videoPath, string? harPath, string? bundlePath)
    {
        var file = Path.Combine(_artifactDirectory, "report.html");
        var rows = new StringBuilder();
        foreach (var step in _steps)
        {
            var status = step.Passed ? "PASS" : "FAIL";
            var screenshot = string.IsNullOrWhiteSpace(step.Screenshot) ? string.Empty : $"<a href='{Rel(step.Screenshot)}'>screenshot</a>";
            var method = string.IsNullOrWhiteSpace(step.Binding) ? "No step-definition method was captured for this step." : step.Binding;
            var provenance = step.BindingCaptured
                ? (string.IsNullOrWhiteSpace(step.Binding) ? "No step-definition method was selected or captured at runtime." : "Selected by ReqnRoll at runtime.")
                : "Runtime binding metadata unavailable.";
            rows.Append($"<tr class='{status.ToLowerInvariant()}'><td><details{(step.Passed ? string.Empty : " open")}><summary>{Encode(step.Step)}</summary><details class='binding-node'{(step.Passed ? string.Empty : " open")}><summary>C# step definition: {Encode(method)} — {status} — {step.Duration.TotalSeconds:F1}s</summary><div class='small'>{Encode(provenance)}</div><h4>Data read or written in this step</h4>{RenderData(step.Data)}<h4>Executed actions</h4>{RenderActions(step.Actions)}<h4>Test error</h4><pre>{Encode(step.Error)}</pre><h4>Console/Page errors</h4><pre>{Encode(step.ConsoleErrors)}</pre><h4>Network errors</h4><pre>{Encode(step.NetworkErrors)}</pre>{screenshot}</details></details></td><td>{status}</td><td>{step.Duration.TotalSeconds:F1}s</td></tr>");
        }

        var deferredTable = RenderDeferredVerificationTable();
        var html = $$"""
        <!doctype html>
        <html><head><meta charset="utf-8"><title>{{Encode(scenario)}}</title>
        <style>
        body{font-family:Segoe UI,Arial;margin:24px;color:#1f2937}h1{margin-bottom:4px}.meta{color:#6b7280;margin-bottom:18px}
        table{border-collapse:collapse;width:100%;font-size:12px;margin-bottom:24px}th,td{border:1px solid #d1d5db;padding:7px;vertical-align:top;white-space:pre-wrap;word-break:break-word}
        th{background:#16324f;color:#fff}.pass td:nth-child(2){color:#16713b;font-weight:700}.fail{background:#fff0f0}.fail td:nth-child(2){color:#b42318;font-weight:700}
        .artifacts a{margin-right:16px}.ok{color:#16713b;font-weight:700}.warn{color:#875f00}.muted{color:#6b7280}.small{font-size:11px;color:#4b5563}
        details summary{cursor:pointer}.mono{font-family:Consolas,Menlo,monospace;font-size:11px}
        .binding-node,.action-node{margin:8px 0 8px 16px;padding:8px;border-left:3px solid #d1d5db}.action-node.FAIL{border-color:#b42318}.action-node.PASS{border-color:#16713b}
        </style></head>
        <body><h1>{{Encode(feature)}}</h1><div class="meta">Scenario: {{Encode(scenario)}}</div>
        <!-- attempt-links-start -->{{RenderAttemptLinks()}}<!-- attempt-links-end -->
        <div class="artifacts"><a href='{{Rel(logPath)}}'>execution log</a>{{Link("screenshot", ScreenshotPath)}}{{Link("trace", tracePath)}}{{Link("video", videoPath)}}{{Link("HAR", harPath)}}{{Link("evidence bundle", bundlePath)}}</div>
        <details class="scenario-data" open><summary>Test-case data (final resolved snapshot for this attempt)</summary>{{RenderData(_scenarioData)}}</details>
        <h2>Execution steps</h2><table><thead><tr><th>Feature step — expand for method, data and errors</th><th>Status</th><th>Duration</th></tr></thead><tbody>{{rows}}</tbody></table>
        {{deferredTable}}
        </body></html>
        """;
        File.WriteAllText(file, html);

        var scenarioPassed = _steps.All(step => step.Passed) && _deferredVerifications.Count == 0;
        var result = new
        {
            schemaVersion = "1.0",
            executionId = _attemptContext?.ExecutionId,
            testFullName = _attemptContext?.TestFullName,
            attemptNumber = AttemptNumber,
            maxAttempts = _attemptContext?.MaxAttempts ?? 1,
            feature,
            scenario,
            data = _scenarioData,
            stepDataScope = "accessed",
            status = scenarioPassed ? "PASS" : "FAIL",
            startedAtUtc = _scenarioStartUtc,
            completedAtUtc = DateTimeOffset.UtcNow,
            durationMilliseconds = Math.Round(_steps.Sum(step => step.Duration.TotalMilliseconds), 3),
            steps = _steps.Select((step, index) => new
            {
                order = index + 1,
                text = step.Step,
                binding = step.Binding,
                bindingCaptured = step.BindingCaptured,
                actions = step.Actions,
                status = step.Passed ? "PASS" : "FAIL",
                durationMilliseconds = Math.Round(step.Duration.TotalMilliseconds, 3),
                data = step.Data,
                error = step.Error,
                consoleErrors = step.ConsoleErrors,
                networkErrors = step.NetworkErrors,
                screenshot = string.IsNullOrWhiteSpace(step.Screenshot) ? string.Empty : Rel(step.Screenshot)
            }),
            deferredVerifications = _deferredVerifications.Select(item => new
            {
                businessStep = item.BusinessStep,
                page = item.Page,
                control = item.Control,
                property = item.Property,
                expected = item.Expected,
                error = item.Error,
                screenshot = string.IsNullOrWhiteSpace(item.Screenshot) ? string.Empty : Rel(item.Screenshot)
            }),
            artifacts = new
            {
                report = "report.html",
                screenshot = string.IsNullOrWhiteSpace(ScreenshotPath) ? string.Empty : Rel(ScreenshotPath),
                log = Rel(logPath),
                trace = string.IsNullOrWhiteSpace(tracePath) ? string.Empty : Rel(tracePath),
                video = string.IsNullOrWhiteSpace(videoPath) ? string.Empty : Rel(videoPath),
                har = string.IsNullOrWhiteSpace(harPath) ? string.Empty : Rel(harPath),
                evidenceBundle = string.IsNullOrWhiteSpace(bundlePath) ? string.Empty : Rel(bundlePath)
            }
        };
        File.WriteAllText(
            Path.Combine(_artifactDirectory, "scenario-result.json"),
            JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true }));
    }

    public void CompleteAttempt(string status, string? error)
    {
        var path = Path.Combine(_artifactDirectory, "scenario-result.json");
        if (!File.Exists(path)) return;
        var relativePath = SafeFileAccess.ToRepositoryRelativePath(path);
        var safeResultPath = SafeFileAccess.ResolveExistingFileUnderRoot(relativePath, MaxScenarioResultBytes, ".json");
        var result = System.Text.Json.Nodes.JsonNode.Parse(File.ReadAllText(safeResultPath))!;
        result["status"] = status;
        result["error"] = error ?? string.Empty;
        File.WriteAllText(path, result.ToJsonString(new JsonSerializerOptions { WriteIndented = true }));
    }

    public void RefreshAttemptLinks()
    {
        if (!File.Exists(ReportPath)) return;
        var relativePath = SafeFileAccess.ToRepositoryRelativePath(ReportPath);
        var safeReportPath = SafeFileAccess.ResolveExistingFileUnderRoot(relativePath, MaxReportHtmlBytes, ".html");
        var html = File.ReadAllText(safeReportPath);
        const string start = "<!-- attempt-links-start -->";
        const string end = "<!-- attempt-links-end -->";
        var from = html.IndexOf(start, StringComparison.Ordinal);
        var to = html.IndexOf(end, StringComparison.Ordinal);
        if (from >= 0 && to > from)
            File.WriteAllText(ReportPath, html[..(from + start.Length)] + RenderAttemptLinks() + html[to..]);
    }

    private string RenderAttemptLinks()
    {
        var reports = _attemptContext?.Reports ?? new[] { this };
        return "<div class='artifacts meta'>Attempts: " + string.Join(" ", reports.Select(report =>
            report == this ? $"<strong aria-current='page'>{report.AttemptNumber}</strong>" :
            $"<a href='{Encode(Rel(report.ReportPath))}' aria-label='Attempt {report.AttemptNumber}'>{report.AttemptNumber}</a>")) + "</div>";
    }

    private string RenderDeferredVerificationTable()
    {
        if (_deferredVerifications.Count == 0)
            return "<h2>Deferred verification results</h2><p class='muted'>No deferred verification failures were recorded.</p>";

        var rows = new StringBuilder();
        foreach (var x in _deferredVerifications)
        {
            var screenshot = string.IsNullOrWhiteSpace(x.Screenshot) ? string.Empty : $"<a href='{Rel(x.Screenshot)}'>screenshot</a>";
            rows.Append($"<tr class='fail'><td>{Encode(x.BusinessStep)}</td><td>{Encode(x.Page)}.{Encode(x.Control)}</td><td>{Encode(x.Property)}</td><td>{Encode(x.Expected)}</td><td>{Encode(x.Error)}</td><td>{screenshot}</td></tr>");
        }
        return $"<h2>Deferred verification results</h2><p class='small'>These assertions exhausted the configured wait, canonical locator, frame/document resolution. Execution continued only to collect later business/evidence context; NUnit fails the scenario after evidence publication.</p><table><thead><tr><th>Business step</th><th>Page.Control</th><th>Property</th><th>Expected</th><th>Error</th><th>Evidence</th></tr></thead><tbody>{rows}</tbody></table>";
    }

    private static string RenderActions(IReadOnlyList<ReportAction> actions) => actions.Count == 0
        ? "<p class='muted'>No instrumented page/action calls were recorded. Direct calls outside UiActions are not traced.</p>"
        : string.Join(string.Empty, actions.Select(action =>
            $"<details class='action-node {Encode(action.Status)}'{(action.Status == "FAIL" ? " open" : string.Empty)}><summary>{Encode(action.Method)} — {Encode(action.Status)} — {action.DurationMilliseconds / 1000:F3}s</summary><div>Operation: {Encode(action.Operation)} · Target: {Encode(action.Target)}</div>{RenderData(action.Data)}<div>{Encode(action.Result)}</div><pre>{Encode(action.Error)}</pre>{(action.Children.Count == 0 ? string.Empty : RenderActions(action.Children))}</details>"));

    private string Link(string label, string? path) => string.IsNullOrWhiteSpace(path) ? string.Empty : $"<a href='{Rel(path)}'>{label}</a>";
    private static string RenderData(IReadOnlyDictionary<string, string> data) => data.Count == 0
        ? "<p class='muted'>No data recorded.</p>"
        : "<table class='data-table'><tbody>" + string.Join(string.Empty, data.Select(item =>
            $"<tr><th>{Encode(item.Key)}</th><td>{Encode(item.Value)}</td></tr>")) + "</tbody></table>";
    private string Rel(string path) => Path.GetRelativePath(_artifactDirectory, path).Replace('\\', '/');
    private static string Encode(string value) => WebUtility.HtmlEncode(value ?? string.Empty);

    private sealed class StepResult
    {
        public List<ReportAction> Actions { get; set; } = [];
        public string Step { get; set; } = string.Empty;
        public string Binding { get; set; } = string.Empty;
        public bool BindingCaptured { get; set; }
        public bool Passed { get; set; }
        public string Error { get; set; } = string.Empty;
        public TimeSpan Duration { get; set; }
        public IReadOnlyDictionary<string, string> Data { get; set; } = new Dictionary<string, string>();
        public string Screenshot { get; set; } = string.Empty;
        public string ConsoleErrors { get; set; } = string.Empty;
        public string NetworkErrors { get; set; } = string.Empty;
    }
}
