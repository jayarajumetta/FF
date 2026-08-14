using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Serilog;
using ToscaArtifactAutomation.Core.Configuration;

namespace ToscaArtifactAutomation.Core.Reporting;

public sealed class StepExecutionRecord
{
    public int Order { get; init; }
    public string Keyword { get; init; } = string.Empty;
    public string Text { get; init; } = string.Empty;
    public string Status { get; init; } = string.Empty;
    public long DurationMs { get; init; }
    public string Screenshot { get; init; } = string.Empty;
    public string Error { get; init; } = string.Empty;
}

public sealed class ScenarioExecutionRecord
{
    public string ScenarioId { get; init; } = string.Empty;
    public string Feature { get; init; } = string.Empty;
    public string Scenario { get; init; } = string.Empty;
    public string Application { get; init; } = string.Empty;
    public string Status { get; init; } = string.Empty;
    public DateTime StartedUtc { get; init; }
    public DateTime FinishedUtc { get; init; }
    public string ArtifactDirectory { get; init; } = string.Empty;
    public string Error { get; init; } = string.Empty;
    public IReadOnlyDictionary<string, string> RuntimeData { get; init; } = new Dictionary<string, string>();
    public IReadOnlyList<StepExecutionRecord> Steps { get; init; } = Array.Empty<StepExecutionRecord>();
}

public static class ExecutionReportRegistry
{
    private static readonly ConcurrentQueue<ScenarioExecutionRecord> Records = new();
    public static void Add(ScenarioExecutionRecord record) => Records.Enqueue(record ?? throw new ArgumentNullException(nameof(record)));
    public static IReadOnlyList<ScenarioExecutionRecord> Snapshot() => Records.OrderBy(x => x.StartedUtc).ToArray();
    public static void Reset() { while (Records.TryDequeue(out _)) { } }
}

public sealed class StepExecutionTracker
{
    private readonly List<StepExecutionRecord> _steps = new();
    private Stopwatch? _watch;
    private string _keyword = string.Empty;
    private string _text = string.Empty;
    private int _order;

    public IReadOnlyList<StepExecutionRecord> Steps => _steps.ToArray();

    public void Start(string keyword, string text)
    {
        if (_watch is not null) throw new InvalidOperationException("A step timer is already running.");
        _keyword = keyword ?? string.Empty;
        _text = text ?? string.Empty;
        _watch = Stopwatch.StartNew();
    }

    public void Complete(string status, string screenshot, Exception? error)
    {
        var watch = _watch ?? throw new InvalidOperationException("No active step timer exists.");
        watch.Stop();
        _steps.Add(new StepExecutionRecord
        {
            Order = ++_order, Keyword = _keyword, Text = _text, Status = status,
            DurationMs = watch.ElapsedMilliseconds, Screenshot = screenshot ?? string.Empty,
            Error = error?.ToString() ?? string.Empty
        });
        _watch = null; _keyword = string.Empty; _text = string.Empty;
    }
}

public static class ReportWriter
{
    public static async Task<string> WriteAsync(RootSettings settings)
    {
        ArgumentNullException.ThrowIfNull(settings);
        var records = ExecutionReportRegistry.Snapshot();
        var root = ArtifactPaths.RunRoot(settings.Framework);
        var jsonPath = Path.Combine(root, "execution-summary.json");
        await File.WriteAllTextAsync(jsonPath, JsonSerializer.Serialize(records, new JsonSerializerOptions { WriteIndented = true }));
        if (!settings.Framework.HtmlReport.Enabled) return jsonPath;
        var htmlPath = Path.Combine(root, settings.Framework.HtmlReport.FileName);
        await File.WriteAllTextAsync(htmlPath, BuildHtml(records, settings.Application.Name));
        return htmlPath;
    }

    public static async Task SendEmailAsync(RootSettings settings, string reportPath)
    {
        var email = settings.Framework.EmailReport;
        if (!email.Enabled) return;
        if (string.IsNullOrWhiteSpace(email.SmtpHost) || string.IsNullOrWhiteSpace(email.From) || email.To.Count == 0)
            throw new InvalidOperationException("Email reporting is enabled but SMTP host, sender, or recipients are missing.");
        using var message = new MailMessage { From = new MailAddress(email.From), Subject = $"{settings.Application.Name} automation summary - {ArtifactPaths.RunId}", Body = BuildEmailBody(ExecutionReportRegistry.Snapshot()), IsBodyHtml = true };
        foreach (var recipient in email.To.Where(x => !string.IsNullOrWhiteSpace(x))) message.To.Add(recipient);
        if (File.Exists(reportPath)) message.Attachments.Add(new Attachment(reportPath));
        using var client = new SmtpClient(email.SmtpHost, email.SmtpPort) { EnableSsl = email.EnableSsl };
        var username = Environment.GetEnvironmentVariable(email.UsernameEnvironmentVariable);
        var password = Environment.GetEnvironmentVariable(email.PasswordEnvironmentVariable);
        if (!string.IsNullOrWhiteSpace(username)) client.Credentials = new NetworkCredential(username, password);
        await client.SendMailAsync(message);
    }

    private static string BuildEmailBody(IReadOnlyList<ScenarioExecutionRecord> records)
    {
        var passed = records.Count(x => x.Status.Equals("Passed", StringComparison.OrdinalIgnoreCase));
        return $"<h2>Automation summary</h2><p>Total: {records.Count}; Passed: {passed}; Failed: {records.Count - passed}</p>";
    }

    private static string BuildHtml(IReadOnlyList<ScenarioExecutionRecord> records, string application)
    {
        static string E(string value) => System.Net.WebUtility.HtmlEncode(value ?? string.Empty);
        var passed = records.Count(x => x.Status.Equals("Passed", StringComparison.OrdinalIgnoreCase));
        var body = new StringBuilder();
        foreach (var scenario in records)
        {
            body.Append("<section><h2>").Append(E(scenario.Feature)).Append(" — ").Append(E(scenario.Scenario)).Append("</h2>")
                .Append("<p><strong>Status:</strong> ").Append(E(scenario.Status)).Append(" | <strong>Artifacts:</strong> ").Append(E(scenario.ArtifactDirectory)).Append("</p>")
                .Append("<table><thead><tr><th>#</th><th>Step</th><th>Status</th><th>Duration</th><th>Evidence</th></tr></thead><tbody>");
            foreach (var step in scenario.Steps)
            {
                body.Append("<tr><td>").Append(step.Order).Append("</td><td>").Append(E(step.Keyword + " " + step.Text)).Append("</td><td>").Append(E(step.Status)).Append("</td><td>").Append(step.DurationMs).Append(" ms</td><td>")
                    .Append(string.IsNullOrWhiteSpace(step.Screenshot) ? "" : E(step.Screenshot)).Append("</td></tr>");
            }
            body.Append("</tbody></table>");
            if (!string.IsNullOrWhiteSpace(scenario.Error)) body.Append("<pre>").Append(E(scenario.Error)).Append("</pre>");
            body.Append("</section>");
        }
        return $$"""
<!doctype html><html><head><meta charset="utf-8"><title>{{E(application)}} automation report</title>
<style>body{font-family:Arial,sans-serif;margin:24px;background:#f5f7fa;color:#172033}header,section{background:white;border-radius:10px;padding:18px;margin-bottom:18px;box-shadow:0 2px 8px #0001}table{border-collapse:collapse;width:100%}th,td{border:1px solid #d8dee9;padding:8px;text-align:left}th{background:#eef2f7}pre{white-space:pre-wrap;background:#fff3f3;padding:12px}.pass{color:#087f23}.fail{color:#b00020}</style></head>
<body><header><h1>{{E(application)}} automation report</h1><p>Total: {{records.Count}} | <span class="pass">Passed: {{passed}}</span> | <span class="fail">Failed: {{records.Count-passed}}</span></p></header>{{body}}</body></html>
""";
    }
}

public static class LoggingBootstrap
{
    private static int _configured;
    public static void Configure(RootSettings settings)
    {
        if (Interlocked.Exchange(ref _configured, 1) == 1) return;
        var logPath = Path.Combine(ArtifactPaths.RunRoot(settings.Framework), "execution.log");
        Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File(logPath, rollingInterval: RollingInterval.Infinite, shared: true).CreateLogger();
        Log.Information("Automation run {RunId} started for {Application}", ArtifactPaths.RunId, settings.Application.Name);
    }
}
