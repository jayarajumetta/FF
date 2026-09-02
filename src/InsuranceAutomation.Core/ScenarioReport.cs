using System.Net;
using System.Text;
using System.Text.Json;

namespace InsuranceAutomation.Core;

public sealed class ScenarioReport
{
    private readonly List<StepResult> _steps = [];
    private readonly List<DeferredVerificationFailure> _deferredVerifications = [];
    private readonly string _artifactDirectory;
    private readonly DateTimeOffset _scenarioStartUtc = DateTimeOffset.UtcNow;
    private DateTime _currentStart;
    private string _currentStep = string.Empty;

    public ScenarioReport(string artifactDirectory) => _artifactDirectory = artifactDirectory;

    public void StartStep(string step)
    {
        _currentStep = step;
        _currentStart = DateTime.Now;
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
            rows.Append($"<tr class='{status.ToLowerInvariant()}'><td>{Encode(step.Step)}</td><td>{status}</td><td>{step.Duration.TotalSeconds:F1}s</td><td>{Encode(step.Data)}</td><td>{Encode(step.ConsoleErrors)}</td><td>{Encode(step.NetworkErrors)}</td><td>{Encode(step.Error)}</td><td>{screenshot}</td></tr>");
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
        </style></head>
        <body><h1>{{Encode(feature)}}</h1><div class="meta">Scenario: {{Encode(scenario)}}</div>
        <div class="artifacts"><a href='{{Rel(logPath)}}'>execution log</a>{{Link("trace", tracePath)}}{{Link("video", videoPath)}}{{Link("HAR", harPath)}}{{Link("evidence bundle", bundlePath)}}</div>
        <h2>Execution steps</h2><table><thead><tr><th>Business step</th><th>Status</th><th>Duration</th><th>Resolved data</th><th>Console/Page errors</th><th>Network errors</th><th>Test error</th><th>Evidence</th></tr></thead><tbody>{{rows}}</tbody></table>
        {{deferredTable}}
        </body></html>
        """;
        File.WriteAllText(file, html);

        var scenarioPassed = _steps.All(step => step.Passed) && _deferredVerifications.Count == 0;
        var result = new
        {
            schemaVersion = "1.0",
            feature,
            scenario,
            status = scenarioPassed ? "PASS" : "FAIL",
            startedAtUtc = _scenarioStartUtc,
            completedAtUtc = DateTimeOffset.UtcNow,
            durationMilliseconds = Math.Round(_steps.Sum(step => step.Duration.TotalMilliseconds), 3),
            steps = _steps.Select((step, index) => new
            {
                order = index + 1,
                text = step.Step,
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
    }
}
