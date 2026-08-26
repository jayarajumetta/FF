using System.Net;
using System.Text;

namespace InsuranceAutomation.Core;

public sealed record LocatorFallbackTrace(
    DateTimeOffset Timestamp,
    string Application,
    string BusinessStep,
    string Page,
    string Control,
    string Action,
    int Attempt,
    string Strategy,
    string Value,
    string Role,
    string HasText,
    string Pick,
    int Index,
    int MatchCount,
    bool Success,
    string Outcome,
    double Confidence,
    string SourceFile,
    string SourceModule,
    string SourceField,
    string SourceProperty,
    string FrameStrategy,
    string FrameValue,
    string Reason,
    string PrimaryFailure);

public sealed class ScenarioReport
{
    private readonly List<StepResult> _steps = [];
    private readonly List<LocatorFallbackTrace> _allFallbacks = [];
    private readonly List<LocatorFallbackTrace> _currentFallbacks = [];
    private readonly List<DeferredVerificationFailure> _deferredVerifications = [];
    private readonly string _artifactDirectory;
    private DateTime _currentStart;
    private string _currentStep = string.Empty;

    public ScenarioReport(string artifactDirectory) => _artifactDirectory = artifactDirectory;

    public void StartStep(string step)
    {
        _currentStep = step;
        _currentStart = DateTime.Now;
        _currentFallbacks.Clear();
    }

    public void RecordLocatorFallback(LocatorFallbackTrace trace)
    {
        _currentFallbacks.Add(trace);
        _allFallbacks.Add(trace);
    }

    public void RecordDeferredVerification(DeferredVerificationFailure failure) => _deferredVerifications.Add(failure);

    public void EndStep(bool passed, string? error, IReadOnlyDictionary<string, string> data, string? screenshot, StepEvidence evidence)
    {
        _steps.Add(new StepResult
        {
            Step = _currentStep,
            Passed = passed,
            Error = error ?? string.Empty,
            Duration = DateTime.Now - _currentStart,
            Data = string.Join("; ", data.Select(item => $"{item.Key}={item.Value}")),
            Screenshot = screenshot ?? string.Empty,
            ConsoleErrors = string.Join("\n", evidence.ConsoleErrors),
            NetworkErrors = string.Join("\n", evidence.NetworkErrors),
            LocatorFallbacks = _currentFallbacks.ToArray()
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
            rows.Append($"<tr class='{status.ToLowerInvariant()}'><td>{Encode(step.Step)}</td><td>{status}</td><td>{step.Duration.TotalSeconds:F1}s</td><td>{Encode(step.Data)}</td><td>{RenderStepFallbackSummary(step.LocatorFallbacks)}</td><td>{Encode(step.ConsoleErrors)}</td><td>{Encode(step.NetworkErrors)}</td><td>{Encode(step.Error)}</td><td>{screenshot}</td></tr>");
        }

        var fallbackTable = RenderFallbackTable();
        var deferredTable = RenderDeferredVerificationTable();
        var html = $$"""
        <!doctype html>
        <html><head><meta charset="utf-8"><title>{{Encode(scenario)}}</title>
        <style>
        body{font-family:Segoe UI,Arial;margin:24px;color:#1f2937}h1{margin-bottom:4px}.meta{color:#6b7280;margin-bottom:18px}
        table{border-collapse:collapse;width:100%;font-size:12px;margin-bottom:24px}th,td{border:1px solid #d1d5db;padding:7px;vertical-align:top;white-space:pre-wrap;word-break:break-word}
        th{background:#16324f;color:#fff}.pass td:nth-child(2){color:#16713b;font-weight:700}.fail{background:#fff0f0}.fail td:nth-child(2){color:#b42318;font-weight:700}
        .artifacts a{margin-right:16px}.fallback-ok{color:#16713b;font-weight:700}.fallback-try{color:#875f00}.fallback-none{color:#6b7280}.small{font-size:11px;color:#4b5563}
        details summary{cursor:pointer}.mono{font-family:Consolas,Menlo,monospace;font-size:11px}
        </style></head>
        <body><h1>{{Encode(feature)}}</h1><div class="meta">Scenario: {{Encode(scenario)}}</div>
        <div class="artifacts"><a href='{{Rel(logPath)}}'>execution log</a>{{Link("trace", tracePath)}}{{Link("video", videoPath)}}{{Link("HAR", harPath)}}{{Link("evidence bundle", bundlePath)}}</div>
        <h2>Execution steps</h2><table><thead><tr><th>Business step</th><th>Status</th><th>Duration</th><th>Resolved data</th><th>Locator recovery</th><th>Console/Page errors</th><th>Network errors</th><th>Test error</th><th>Evidence</th></tr></thead><tbody>{{rows}}</tbody></table>
        {{fallbackTable}}
        {{deferredTable}}
        </body></html>
        """;
        File.WriteAllText(file, html);
    }

    private string RenderStepFallbackSummary(IReadOnlyList<LocatorFallbackTrace> events)
    {
        if (events.Count == 0) return "<span class='fallback-none'>primary locator used</span>";
        var success = events.LastOrDefault(x => x.Success);
        if (success is not null)
            return $"<span class='fallback-ok'>RECOVERED</span><br/><span class='small'>{Encode(success.Strategy)}: {Encode(success.Value)}<br/>source: {Encode(success.SourceModule)} / {Encode(success.SourceField)}<br/>attempt {success.Attempt}</span>";
        return $"<span class='fallback-try'>fallback tried; not recovered</span><br/><span class='small'>{events.Count} candidate event(s)</span>";
    }

    private string RenderFallbackTable()
    {
        if (_allFallbacks.Count == 0)
            return "<h2>Locator fallback trace</h2><p class='fallback-none'>No primary locator failures occurred in this scenario.</p>";

        var rows = new StringBuilder();
        foreach (var x in _allFallbacks)
        {
            var cls = x.Success ? "fallback-ok" : "fallback-try";
            var candidate = string.IsNullOrWhiteSpace(x.Strategy)
                ? "&lt;none&gt;"
                : $"<span class='mono'>{Encode(x.Strategy)}: {Encode(x.Value)}</span>" +
                  (string.IsNullOrWhiteSpace(x.HasText) ? "" : $"<br/><span class='small'>HasText={Encode(x.HasText)}</span>") +
                  (string.IsNullOrWhiteSpace(x.FrameValue) ? "" : $"<br/><span class='small'>Frame={Encode(x.FrameStrategy)}:{Encode(x.FrameValue)}</span>");
            rows.Append($"<tr><td>{Encode(x.BusinessStep)}</td><td>{Encode(x.Page)}.{Encode(x.Control)}</td><td>{Encode(x.Action)}</td><td>{x.Attempt}</td><td>{candidate}</td><td>{x.MatchCount}</td><td class='{cls}'>{Encode(x.Outcome)}</td><td>{x.Confidence:F3}</td><td>{Encode(x.SourceModule)}<br/><span class='small'>{Encode(x.SourceField)} / {Encode(x.SourceProperty)}<br/>{Encode(x.SourceFile)}</span></td><td>{Encode(x.Reason)}</td></tr>");
        }
        return $"<h2>Locator fallback trace</h2><p class='small'>Frame-scoped controls preserve raw Tosca HtmlFrame ancestry. Deterministic Tosca candidates are attempted only after the Page Object primary locator fails. The test continues only when one candidate is unique/visible/action-compatible and the same failed action succeeds.</p><table><thead><tr><th>Business step</th><th>Page.Control</th><th>Action</th><th>#</th><th>Candidate</th><th>Matches</th><th>Outcome</th><th>Confidence</th><th>Tosca source</th><th>Reason</th></tr></thead><tbody>{rows}</tbody></table>";
    }


    private string RenderDeferredVerificationTable()
    {
        if (_deferredVerifications.Count == 0)
            return "<h2>Deferred verification results</h2><p class='fallback-none'>No deferred verification failures were recorded.</p>";

        var rows = new StringBuilder();
        foreach (var x in _deferredVerifications)
        {
            var screenshot = string.IsNullOrWhiteSpace(x.Screenshot) ? string.Empty : $"<a href='{Rel(x.Screenshot)}'>screenshot</a>";
            rows.Append($"<tr class='fail'><td>{Encode(x.BusinessStep)}</td><td>{Encode(x.Page)}.{Encode(x.Control)}</td><td>{Encode(x.Property)}</td><td>{Encode(x.Expected)}</td><td>{Encode(x.Error)}</td><td>{screenshot}</td></tr>");
        }
        return $"<h2>Deferred verification results</h2><p class='small'>These assertions exhausted the configured wait, primary locator, deterministic Tosca fallback and optional healing. Execution continued only to collect later business/evidence context; NUnit fails the scenario after evidence publication.</p><table><thead><tr><th>Business step</th><th>Page.Control</th><th>Property</th><th>Expected</th><th>Error</th><th>Evidence</th></tr></thead><tbody>{rows}</tbody></table>";
    }

    private string Link(string label, string? path) => string.IsNullOrWhiteSpace(path) ? string.Empty : $"<a href='{Rel(path)}'>{label}</a>";
    private string Rel(string path) => Path.GetRelativePath(_artifactDirectory, path).Replace('\\', '/');
    private static string Encode(string value) => WebUtility.HtmlEncode(value ?? string.Empty);

    private sealed class StepResult
    {
        public string Step { get; set; } = string.Empty;
        public bool Passed { get; set; }
        public string Error { get; set; } = string.Empty;
        public TimeSpan Duration { get; set; }
        public string Data { get; set; } = string.Empty;
        public string Screenshot { get; set; } = string.Empty;
        public string ConsoleErrors { get; set; } = string.Empty;
        public string NetworkErrors { get; set; } = string.Empty;
        public IReadOnlyList<LocatorFallbackTrace> LocatorFallbacks { get; set; } = Array.Empty<LocatorFallbackTrace>();
    }
}
