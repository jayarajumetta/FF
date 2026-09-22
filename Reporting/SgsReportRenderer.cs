#nullable enable
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace PnCTestAutomation.Reporting;

public static class ScenarioReportRenderer
{
    public static ScenarioReportDocuments Render(
        ScenarioReportProjection projection,
        ScenarioReportEvidence evidence,
        ReportLimits? limits = null,
        ReportRedactor? redactor = null)
    {
        var report = new ConsolidatedReport(
            projection.CompletedAtUtc,
            [new ReportTestResult(projection.TestFullName, projection.Status,
                projection.DurationMilliseconds, [new ScenarioReportView(projection, evidence)])],
            evidence.Issues, []);
        var renderer = new SgsHtmlRenderer(limits, redactor);
        return new ScenarioReportDocuments(
            renderer.Render(report, "Canonical scenario manifest projection"),
            ReportJson.Serialize(projection));
    }
}

public static class ConsolidatedReportRenderer
{
    public static ConsolidatedReportDocuments Render(
        ConsolidatedReport report,
        ReportLimits? limits = null,
        ReportRedactor? redactor = null)
    {
        var renderer = new SgsHtmlRenderer(limits, redactor);
        return new ConsolidatedReportDocuments(
            renderer.Render(report, "Canonical TRX / NUnit execution projection"),
            renderer.RenderStandaloneLog(report),
            renderer.RenderXml(report),
            renderer.RenderSummary(report));
    }

    public static ReportStatus CanonicalStatus(IEnumerable<ReportTestResult> tests)
    {
        var values = tests.Select(item => item.Status).ToArray();
        if (values.Length == 0 || values.Contains(ReportStatus.Unknown))
            return ReportStatus.Unknown;
        if (values.Contains(ReportStatus.Fail))
            return ReportStatus.Fail;
        return values.Contains(ReportStatus.Skip) ? ReportStatus.Skip : ReportStatus.Pass;
    }

    public static ReportStatus OverallStatus(ConsolidatedReport report) =>
        report.Issues.Length > 0 || report.UnmatchedEvidence.Length > 0
            ? ReportStatus.Fail
            : CanonicalStatus(report.Tests);
}

internal sealed class SgsHtmlRenderer
{
    private readonly ReportLimits _limits;
    private readonly ReportRedactor _redactor;

    internal SgsHtmlRenderer(ReportLimits? limits, ReportRedactor? redactor)
    {
        _limits = limits ?? new ReportLimits();
        _limits.Validate();
        _redactor = redactor ?? new ReportRedactor();
    }

    internal string Render(ConsolidatedReport report, string authority)
    {
        var status = ConsolidatedReportRenderer.OverallStatus(report);
        var tests = report.Tests;
        var passed = tests.Count(item => item.Status == ReportStatus.Pass);
        var failed = tests.Count(item => item.Status == ReportStatus.Fail);
        var skipped = tests.Count(item => item.Status == ReportStatus.Skip);
        var attempts = tests.SelectMany(item => item.Attempts).ToArray();
        var start = attempts.Length > 0 ? attempts.Min(item => item.Projection.StartedAtUtc) : (DateTimeOffset?)null;
        var end = attempts.Length > 0 ? attempts.Max(item => item.Projection.CompletedAtUtc) : (DateTimeOffset?)null;
        var wall = start.HasValue ? (end!.Value - start.Value).TotalMilliseconds : 0;
        var totalTime = tests.Sum(item => item.DurationMilliseconds);
        var cards = Card("Overall", status.Text(), status == ReportStatus.Pass ? "ok-text" : "fail-text") +
            Card("Total tests", tests.Length.ToString(CultureInfo.InvariantCulture)) +
            Card("Successful", passed.ToString(CultureInfo.InvariantCulture), "ok-text") +
            Card("Failed", failed.ToString(CultureInfo.InvariantCulture), "fail-text") +
            Card("Skipped", skipped.ToString(CultureInfo.InvariantCulture), "skip-text") +
            Card("Success rate", Number(Percent(passed, tests.Length), "F1") + "%") +
            Card("Scenario time", Duration(totalTime)) + Card("Wall time", Duration(wall)) +
            Card("Features", tests.Select(Feature).Distinct().Count().ToString(CultureInfo.InvariantCulture)) +
            Card("Actual attempts", attempts.Length.ToString(CultureInfo.InvariantCulture)) +
            Card("States", attempts.Select(item => item.Projection.State).Distinct().Count().ToString(CultureInfo.InvariantCulture)) +
            Card("Bindings", attempts.Sum(item => item.Projection.Steps.Count(step => step.Binding != null)).ToString(CultureInfo.InvariantCulture));
        var statistics = Statistics(tests, "feature", "Statistics by feature", Feature) +
            Statistics(tests, "application", "Statistics by application", test => Final(test)?.Application ?? "Not recorded") +
            Statistics(tests, "state", "Statistics by state", test => Final(test)?.State ?? "Not recorded") +
            Statistics(tests, "lob", "Statistics by LOB", test => Final(test)?.Lob ?? "Not recorded");
        var groups = new StringBuilder();
        var ordinal = 0;
        foreach (var group in tests.GroupBy(Feature).OrderBy(group => group.Key, StringComparer.Ordinal))
        {
            groups.Append($"""<section class="feature-group" data-feature="{E(group.Key)}"><details open><summary>{Pill(ConsolidatedReportRenderer.CanonicalStatus(group))} SUITE {E(group.Key)}<span class="feature-counts">{group.Count()} tests | {group.Count(item => item.Status == ReportStatus.Pass)} successful | {group.Count(item => item.Status == ReportStatus.Fail)} failed | {group.Count(item => item.Status == ReportStatus.Skip)} skipped</span></summary><div class="scenario-list">""");
            foreach (var test in group.OrderBy(item => item.Status == ReportStatus.Fail ? 0 : 1)
                         .ThenBy(item => item.TestIdentity, StringComparer.Ordinal))
                groups.Append(Scenario(test, ++ordinal));
            groups.Append("</div></details></section>");
        }
        if (tests.Length == 0)
            groups.Append("""<p class="evidence-error">No canonical executions were available. Evidence discovery is not execution.</p>""");
        var unmatched = report.UnmatchedEvidence.Length == 0 ? "" :
            "<h2>Unmatched evidence (not counted as execution)</h2>" +
            string.Concat(report.UnmatchedEvidence.Select((view, index) =>
                $"""<details class="evidence-error"><summary>{E(view.Projection.Scenario)}</summary>{Attempt(view, "unmatched-" + index)}</details>"""));
        return $$"""
            <!doctype html>
            <html lang="en"><head><meta charset="utf-8"><meta name="viewport" content="width=device-width, initial-scale=1">
            <meta name="referrer" content="no-referrer"><link rel="icon" href="data:,"><title>Insurance Automation Execution Report</title>
            <style>{{SgsReportAssets.Css}}</style></head><body><div class="report-shell">
            <header class="robot-banner {{status.Text()}}">
              <div class="robot-tabs" role="group" aria-label="Report views"><button type="button" class="active" data-view="report">REPORT</button><button type="button" data-view="log">LOG</button></div>
              <h1>Insurance Automation Execution Report</h1>
              <div class="generated"><strong>Generated</strong><br>{{E(Timestamp(report.GeneratedAtUtc))}}</div>
              <dl class="banner-summary">
                <dt>Status:</dt><dd><strong>{{status.Text()}}</strong> | {{passed}} successful, {{failed}} failed, {{skipped}} skipped</dd>
                <dt>Authority:</dt><dd>{{E(authority)}}; reporting never changes the canonical test outcome.</dd>
                <dt>Start time:</dt><dd>{{E(Timestamp(start))}}</dd><dt>End time:</dt><dd>{{E(Timestamp(end))}}</dd>
                <dt>Elapsed:</dt><dd>{{E(Duration(wall))}} wall time | {{E(Duration(totalTime))}} canonical scenario time</dd>
                <dt>Presentation source:</dt><dd>SGS {{SgsReportAssets.SourceCommit}}; offline .NET 8 port</dd>
              </dl>
            </header>
            <main class="main-content">
              {{Issues(report.Issues)}}
              {{(report.DuplicateCopies.Length == 0 ? "" : "<p class=\"notice\">Identical attachment copies excluded from execution counts: " + E(string.Join("; ", report.DuplicateCopies)) + "</p>")}}
              <section id="report-view" class="view active"><h2>Summary information</h2><div class="cards">{{cards}}</div>
                <div class="overall-bar" aria-label="Success fail skip distribution"><span class="ok" style="width:{{Number(Percent(passed, tests.Length))}}%"></span><span class="fail" style="width:{{Number(Percent(failed, tests.Length))}}%"></span><span class="skip" style="width:{{Number(Percent(skipped, tests.Length))}}%"></span></div>
                <div class="overall-bar-legend"><span>Success {{passed}}</span><span>Fail {{failed}}</span><span>Skip {{skipped}} (not verified)</span></div>
                <h2>Test statistics</h2><div class="statistics-grid">{{statistics}}</div>
                <section id="test-details"><div class="section-heading"><h2>Test details</h2><span class="muted">Final canonical outcomes; only actual recorded attempts.</span></div>
                  <div class="toolbar" aria-label="Test filters">
                    <input id="filter-search" type="search" placeholder="Search scenario, feature, state, LOB or tag" aria-label="Search tests">
                    <select id="filter-status" aria-label="Filter by status">{{Options(["PASS", "FAIL", "SKIP", "UNKNOWN"], "statuses")}}</select>
                    <select id="filter-feature" aria-label="Filter by feature">{{Options(tests.Select(Feature), "features")}}</select>
                    <select id="filter-application" aria-label="Filter by application">{{Options(tests.Select(test => Final(test)?.Application ?? "Not recorded"), "applications")}}</select>
                    <select id="filter-state" aria-label="Filter by state">{{Options(tests.Select(test => Final(test)?.State ?? "Not recorded"), "states")}}</select>
                    <select id="filter-lob" aria-label="Filter by LOB">{{Options(tests.Select(test => Final(test)?.Lob ?? "Not recorded"), "LOBs")}}</select>
                    <button id="failures-only" type="button">Failures only</button><button id="expand-visible" type="button">Expand visible</button>
                    <button id="collapse-all" type="button">Collapse all</button><button id="clear-filters" type="button">Clear</button><span id="visible-count" class="visible-count"></span>
                  </div>{{groups}}
                </section>{{unmatched}}
              </section>
              <section id="log-view" class="view"><div class="section-heading"><h2>Test execution log</h2><span class="muted">Feature / scenario / actual attempt / executed keyword</span></div>
                <div class="log-toolbar"><input id="log-search" type="search" placeholder="Search feature or scenario" aria-label="Search log"><select id="log-status" aria-label="Filter log by status">{{Options(["PASS", "FAIL", "SKIP"], "statuses")}}</select></div>
                {{FlatLog(report)}}
              </section>
            </main></div>
            <div id="lightbox" class="lightbox" aria-hidden="true" role="dialog" aria-modal="true" aria-label="Screenshot preview">
              <div class="lightbox-inner"><div class="lightbox-controls"><button id="lightbox-previous" type="button">Previous</button><button id="lightbox-next" type="button">Next</button><button id="lightbox-close" type="button" aria-label="Close screenshot">Close</button></div>
                <img id="lightbox-image" alt="Expanded screenshot evidence"><div id="lightbox-caption" class="lightbox-caption"></div>
              </div>
            </div><script>{{SgsReportAssets.JavaScript}}</script></body></html>
            """;
    }

    private string Scenario(ReportTestResult test, int ordinal)
    {
        var final = Final(test);
        var feature = Feature(test);
        var scenario = final?.Scenario ?? test.TestIdentity;
        var application = final?.Application ?? "Not recorded";
        var state = final?.State ?? "Not recorded";
        var lob = final?.Lob ?? "Not recorded";
        var search = string.Join(" ", feature, scenario, application, state, lob,
            string.Join(" ", final?.Tags ?? [])).ToLowerInvariant();
        var buttons = new StringBuilder();
        var panels = new StringBuilder();
        for (var index = 0; index < test.Attempts.Length; index++)
        {
            var attempt = test.Attempts[index];
            var selected = index == test.Attempts.Length - 1;
            var id = $"scenario-{ordinal}-attempt-{index}";
            buttons.Append($"""<button type="button" class="evidence-tab attempt-tab{(selected ? " active" : "")}" data-attempt="{id}" aria-controls="{id}" aria-pressed="{selected.ToString().ToLowerInvariant()}" title="Attempt {attempt.Projection.AttemptNumber}: {attempt.Projection.Status.Text()}">{attempt.Projection.AttemptNumber}</button>""");
            panels.Append($"""<section class="attempt-panel" id="{id}"{(selected ? "" : " hidden")}><div class="steps-heading"><h4>Actual attempt {attempt.Projection.AttemptNumber}</h4>{Pill(attempt.Projection.Status)}</div>{Attempt(attempt, id)}</section>""");
        }
        return $$"""
            <article class="scenario-card {{test.Status.Text()}}" id="scenario-{{ordinal}}"
              data-status="{{test.Status.Text()}}" data-feature="{{E(feature)}}" data-state="{{E(state)}}"
              data-application="{{E(application)}}" data-lob="{{E(lob)}}" data-search="{{E(search)}}">
              <details class="scenario-details"{{(test.Status == ReportStatus.Fail || test.Attempts.Length == 0 ? " open" : "")}}><summary>
                <span class="scenario-index">{{ordinal.ToString("D3", CultureInfo.InvariantCulture)}}</span><span class="test-label">TEST</span>
                <span class="scenario-title">{{E(scenario)}}</span><span class="scenario-context">{{E(application)}} | {{E(lob)}} | {{E(state)}}</span>
                <span class="scenario-duration">{{E(Duration(test.DurationMilliseconds))}}</span>{{Pill(test.Status)}}
              </summary><div class="scenario-content"><p>Canonical outcome: {{Pill(test.Status)}} | {{E(test.TestIdentity)}}</p>
                {{Panel("Canonical failure / skip reason", test.FailureMessage)}}
                {{(test.Attempts.Length == 0 ? "<p class=\"evidence-error\">No finalized scenario manifest/report projection matched this canonical execution.</p>" : "")}}
                <div class="attempt-tabs" role="group" aria-label="Execution attempts"><span class="field-label">Attempts</span>{{buttons}}</div>{{panels}}
              </div></details>
            </article>
            """;
    }

    private string Attempt(ScenarioReportView view, string id)
    {
        var projection = view.Projection;
        var tags = string.Concat(projection.Tags.Select(tag => $"""<span class="tag">{E(tag)}</span>"""));
        var componentRows = string.Concat(projection.ComponentOutcomes.OrderBy(item => item.Key)
            .Select(item => $"""<tr><td>{E(item.Key)}</td><td>{Pill(item.Value ? ReportStatus.Pass : ReportStatus.Fail)}</td></tr>"""));
        var components = componentRows.Length == 0 ? "" :
            $"""<details class="diagnostic" open><summary>Finalized components (including teardown/evidence)</summary><table><tbody>{componentRows}</tbody></table></details>""";
        var steps = Steps(view, null);
        return $$"""
            <div class="scenario-meta-grid" {{ReportEvidenceReader.ManifestMarker(projection)}}>
              <div><span class="field-label">Feature / suite</span><strong>{{E(projection.Feature)}}</strong></div>
              <div><span class="field-label">Start</span>{{E(Timestamp(projection.StartedAtUtc))}}</div>
              <div><span class="field-label">End</span>{{E(Timestamp(projection.CompletedAtUtc))}}</div>
              <div><span class="field-label">Steps</span>{{projection.Steps.Length}} total | {{projection.Steps.Count(step => step.Status == ReportStatus.Pass)}} successful | {{projection.Steps.Count(step => step.Status == ReportStatus.Fail)}} failed | {{projection.Steps.Count(step => step.Status == ReportStatus.Skip)}} skipped</div>
              <div class="meta-wide"><span class="field-label">Tags</span>{{(tags.Length == 0 ? "Not recorded" : tags)}}</div>
              <div class="meta-wide"><span class="field-label">Canonical profile / execution</span>{{E(projection.ProfileName)}} / {{E(projection.ExecutionId)}}</div>
              <div class="meta-wide"><span class="field-label">Canonical evidence source</span>{{E(view.SourcePath ?? "Current scenario artifact owner")}}</div>
            </div>
            {{Issues(view.Evidence.Issues)}}{{Artifacts(view)}}{{components}}
            {{string.Concat(projection.Diagnostics.Select(diagnostic => Panel($"{Timestamp(diagnostic.Timestamp)} {diagnostic.Component} [{diagnostic.Level}]", diagnostic.Message)))}}
            {{Deferred(view)}}
            <div class="steps-heading"><h4>Execution steps</h4><span>{{projection.Steps.Length}} keyword(s)</span></div>
            <div class="step-list">{{(steps.Length == 0 ? "<p class=\"notice\">No executed business steps were recorded; this is not a passing step.</p>" : steps)}}</div>
            {{Evidence(view, id)}}{{Videos(view)}}
            """;
    }

    private string Steps(ScenarioReportView view, int? parent)
    {
        var html = new StringBuilder();
        foreach (var step in view.Projection.Steps.Where(step => step.ParentOrder == parent).OrderBy(step => step.Order))
        {
            var binding = step.Binding == null ? """<span class="muted">Not recorded (no inferred binding)</span>""" :
                $"""<strong>{E(step.Binding.Method)}</strong><div class="binding-source">{E(step.Binding.SourceFile)}{(step.Binding.Line.HasValue ? ":" + step.Binding.Line.Value.ToString(CultureInfo.InvariantCulture) : "")}</div>""";
            var screenshots = string.Join(" ", step.Screenshots.Select(path => ScreenshotLink(view, path)));
            var diagnostics = Panel("Test failure", step.Error) +
                Panel("Console / page errors", string.Join("\n", step.ConsoleErrors)) +
                Panel("Network errors", string.Join("\n", step.NetworkErrors));
            html.Append($$"""
                <details class="step-row {{step.Status.Text()}}" data-step-order="{{step.Order}}"{{(step.Status == ReportStatus.Fail ? " open" : "")}}>
                  <summary><span class="step-order">{{step.Order}}</span><span class="step-kind">KEYWORD</span><span class="step-name">{{E(step.Text)}}</span>
                    <span class="step-duration">{{E(Duration(step.DurationMilliseconds))}}</span>{{Pill(step.Status)}}</summary>
                  <div class="step-body"><div class="step-grid"><div><span class="field-label">C# step definition</span>{{binding}}</div>
                    <div><span class="field-label">Display data (redacted)</span>{{Data(step.Data)}}</div><div><span class="field-label">Step screenshot</span>{{(screenshots.Length == 0 ? "Not recorded" : screenshots)}}</div>
                  </div>{{(diagnostics.Length == 0 ? "<p class=\"muted\">No error, console or network diagnostics were recorded for this step.</p>" : diagnostics)}}
                    {{Steps(view, step.Order)}}
                  </div>
                </details>
                """);
        }
        return html.ToString();
    }

    private string Deferred(ScenarioReportView view)
    {
        var failures = view.Projection.DeferredVerifications;
        if (failures.Length == 0)
            return """<p class="muted">No deferred verification failures were recorded.</p>""";
        var rows = string.Concat(failures.Select((failure, index) =>
            $"""<tr><td>{index + 1}</td><td>{E(failure.BusinessStep)}</td><td>{E(failure.Page)}.{E(failure.Control)}</td><td>{E(failure.Property)}</td><td>{E(_redactor.Value(failure.Control + "." + failure.Property, failure.Expected))}</td><td><pre class="cell-pre">{E(failure.Error)}</pre></td><td>{ScreenshotLink(view, failure.Screenshot)}</td></tr>"""));
        return $$"""
            <details class="deferred-block" open><summary>{{Pill(ReportStatus.Fail)}} Deferred verification failures ({{failures.Length}})</summary>
              <p class="small muted">Recorded assertions; only the existing test finalizer owns the canonical failure.</p>
              <div class="table-scroll"><table class="detail-table"><thead><tr><th>#</th><th>Business step</th><th>Page.Control</th><th>Property</th><th>Expected</th><th>Error</th><th>Evidence</th></tr></thead><tbody>{{rows}}</tbody></table></div>
            </details>
            """;
    }

    private string Artifacts(ScenarioReportView view)
    {
        var labels = new (string Kind, string Label)[]
        {
            ("ScenarioReportHtml", "Individual report"), ("ScenarioResultJson", "Scenario JSON"),
            ("ExecutionLog", "Execution log"), ("Trace", "Playwright trace"), ("Video", "Video"),
            ("FormsHtml", "PnC forms report"), ("Har", "HAR"), ("EvidenceBundle", "Evidence bundle")
        };
        var html = new StringBuilder("""<div class="artifact-strip">""");
        foreach (var (kind, label) in labels)
        {
            var files = view.Evidence.Files.Where(item => item.Kind == kind).ToArray();
            if (files.Length == 0)
                html.Append($"""<span class="artifact-link missing">{E(label)}: unavailable</span>""");
            foreach (var file in files)
                html.Append(Link(file, label, "artifact-link"));
        }
        return html.Append("</div>").ToString();
    }

    private string Evidence(ScenarioReportView view, string id)
    {
        var screenshots = view.Evidence.Files.Where(item => item.Kind == "Screenshot").ToArray();
        var gallery = new StringBuilder("""<div class="evidence-gallery">""");
        foreach (var file in screenshots)
        {
            var caption = $"{file.Checkpoint} | {file.RelativePath} | {file.SizeBytes} bytes";
            if (SafeImage(file.ImageDataUri))
                gallery.Append($"""<figure class="evidence-image"><button type="button" class="image-button" data-lightbox="true" data-lightbox-caption="{E(caption)}" aria-label="Open {E(file.Checkpoint)}"><img loading="lazy" src="{A(file.ImageDataUri!)}" alt="{E(file.Checkpoint)}"></button><figcaption>{E(caption)}</figcaption></figure>""");
            else
                gallery.Append($"""<div class="evidence-missing">{E(caption)}<br>Not embedded (format or size limit). {Link(file, "Open screenshot")}</div>""");
        }
        gallery.Append("</div>");
        if (screenshots.Length == 0)
            gallery.Append("""<p class="muted">No screenshot evidence was recorded for this scenario.</p>""");
        var logs = view.Evidence.Files.Where(item => item.Kind is "ExecutionLog" or "ConsoleLog" or "NetworkLog").ToArray();
        var logHtml = logs.Length == 0 ? """<p class="muted">No execution log evidence was recorded.</p>""" :
            string.Concat(logs.Select(file =>
                $"""<div class="embedded-file-meta">{E(file.Kind)} | {E(file.Checkpoint)} | {file.SizeBytes} bytes{(file.Truncated ? " | truncated at a complete line" : "")}</div><pre class="embedded-log">{E(file.Text)}</pre>"""));
        var raw = ReportJson.Serialize(view.Projection);
        var rawText = Encoding.UTF8.GetByteCount(raw) > _limits.MaxRawJsonBytes
            ? "Raw scenario-result.json is too large to embed. Use the redacted scenario JSON artifact."
            : raw;
        return $$"""
            <section class="failure-evidence"><div class="section-title-row"><h4>{{(view.Projection.Status == ReportStatus.Fail ? "Failure evidence" : "Attempt evidence")}}</h4><span class="evidence-count">{{screenshots.Count(file => SafeImage(file.ImageDataUri))}}/{{screenshots.Length}} screenshots embedded</span></div>
              <div class="evidence-tabs" role="group" aria-label="Failure evidence">
                <button type="button" class="evidence-tab active" data-evidence-tab="screenshots" aria-pressed="true">Screenshots</button>
                <button type="button" class="evidence-tab" data-evidence-tab="execution-log" aria-pressed="false">Execution log</button>
                <button type="button" class="evidence-tab" data-evidence-tab="raw-result" aria-pressed="false">Raw result</button>
              </div>
              <div class="evidence-pane active" data-evidence-pane="screenshots">{{gallery}}</div>
              <div class="evidence-pane" data-evidence-pane="execution-log">{{logHtml}}</div>
              <div class="evidence-pane" data-evidence-pane="raw-result"><details class="raw-json" open><summary>Redacted scenario-result.json</summary><pre>{{E(rawText)}}</pre></details></div>
            </section>
            """;
    }

    private string Videos(ScenarioReportView view) => string.Concat(view.Evidence.Files
        .Where(file => file.Kind == "Video" && ReportPaths.IsLocalHref(file.Href))
        .Select(file => $"""<details class="video-block"><summary>Recorded execution video | {file.SizeBytes} bytes</summary><video controls preload="none" src="{A(file.Href!)}">{Link(file, "Open video")}</video></details>"""));

    internal string RenderStandaloneLog(ConsolidatedReport report) => $$"""
        <!doctype html><html lang="en"><head><meta charset="utf-8"><link rel="icon" href="data:,"><title>Execution Log</title><style>{{SgsReportAssets.Css}}</style></head>
        <body><main class="main-content"><h1>Execution Log</h1><p>Canonical executions and actual attempts. Generated {{E(Timestamp(report.GeneratedAtUtc))}}</p>{{Issues(report.Issues)}}{{FlatLog(report)}}</main></body></html>
        """;

    private string FlatLog(ConsolidatedReport report)
    {
        var html = new StringBuilder();
        foreach (var test in report.Tests)
        {
            if (test.Attempts.Length == 0)
                html.Append($"""<section class="log-suite" data-status="{test.Status.Text()}" data-search="{E(test.TestIdentity.ToLowerInvariant())}"><h3>{E(test.TestIdentity)} {Pill(test.Status)}</h3>{Panel("Canonical diagnostics", test.FailureMessage)}<p class="evidence-error">No matched evidence.</p></section>""");
            foreach (var attempt in test.Attempts)
            {
                var projection = attempt.Projection;
                html.Append($"""<section class="log-suite" data-status="{projection.Status.Text()}" data-search="{E((projection.Feature + " " + projection.Scenario).ToLowerInvariant())}"><details open><summary><span class="test-label">TEST</span> {E(projection.Feature)} / {E(projection.Scenario)} / Attempt {projection.AttemptNumber} {Pill(projection.Status)}</summary><div class="log-scenario-meta">{E(Timestamp(projection.StartedAtUtc))} / {E(Timestamp(projection.CompletedAtUtc))} | Canonical final: {Pill(test.Status)}</div>""");
                foreach (var step in projection.Steps)
                    html.Append($"""<details class="log-step {step.Status.Text()}"{(step.Status == ReportStatus.Fail ? " open" : "")}><summary><span class="step-kind">KEYWORD</span> {E(step.Text)}<span class="step-duration">{E(Duration(step.DurationMilliseconds))}</span>{Pill(step.Status)}</summary><div class="log-step-body"><p>Binding: {E(step.Binding?.Method ?? "Not recorded")} {E(step.Binding?.SourceFile)}</p>{Data(step.Data)}{Panel("Test error", step.Error)}{Panel("Console / page errors", string.Join("\n", step.ConsoleErrors))}{Panel("Network errors", string.Join("\n", step.NetworkErrors))}</div></details>""");
                foreach (var diagnostic in projection.Diagnostics)
                    html.Append(Panel(diagnostic.Component + " [" + diagnostic.Level + "]", diagnostic.Message));
                html.Append(Deferred(attempt));
                html.Append(Issues(attempt.Evidence.Issues));
                html.Append("</details></section>");
            }
        }
        return html.Length == 0 ? """<p class="evidence-error">No canonical execution log is available.</p>""" : html.ToString();
    }

    internal string RenderSummary(ConsolidatedReport report)
    {
        var tests = report.Tests;
        object Counts(IEnumerable<ReportTestResult> items)
        {
            var group = items.ToArray();
            return new
            {
                total = group.Length,
                passed = group.Count(item => item.Status == ReportStatus.Pass),
                failed = group.Count(item => item.Status == ReportStatus.Fail),
                skipped = group.Count(item => item.Status == ReportStatus.Skip),
                durationMilliseconds = group.Sum(item => item.DurationMilliseconds)
            };
        }
        Dictionary<string, object> Group(Func<ReportTestResult, string> key) =>
            tests.GroupBy(item => _redactor.Text(key(item))).OrderBy(group => group.Key, StringComparer.Ordinal)
                .ToDictionary(group => group.Key, group => Counts(group));
        return ReportJson.Serialize(new
        {
            schemaVersion = "2.0",
            generatedAtUtc = report.GeneratedAtUtc,
            status = ConsolidatedReportRenderer.OverallStatus(report).Text(),
            canonicalStatus = ConsolidatedReportRenderer.CanonicalStatus(tests).Text(),
            valid = report.Issues.Length == 0 && report.UnmatchedEvidence.Length == 0 && tests.Length > 0,
            total = tests.Length,
            attempts = tests.Sum(item => item.Attempts.Length),
            retried = tests.Count(item => item.Attempts.Length > 1),
            passed = tests.Count(item => item.Status == ReportStatus.Pass),
            failed = tests.Count(item => item.Status == ReportStatus.Fail),
            skipped = tests.Count(item => item.Status == ReportStatus.Skip),
            passRate = Math.Round(Percent(tests.Count(item => item.Status == ReportStatus.Pass), tests.Length), 3),
            durationMilliseconds = tests.Sum(item => item.DurationMilliseconds),
            features = Group(Feature),
            applications = Group(test => Final(test)?.Application ?? "Not recorded"),
            states = Group(test => Final(test)?.State ?? "Not recorded"),
            lobs = Group(test => Final(test)?.Lob ?? "Not recorded"),
            unmatchedEvidence = report.UnmatchedEvidence.Length,
            duplicateCopies = report.DuplicateCopies.Select(_redactor.Text),
            issues = report.Issues.Select(item => item with
            {
                Message = _redactor.Text(item.Message), TestIdentity = _redactor.Text(item.TestIdentity)
            })
        });
    }

    internal string RenderXml(ConsolidatedReport report)
    {
        var suite = new XElement("suite", new XAttribute("id", "s1"),
            new XAttribute("name", "Insurance Automation"), new XAttribute("source", "Canonical TRX/NUnit projection"));
        var index = 0;
        foreach (var result in report.Tests)
        {
            var test = new XElement("test", new XAttribute("id", "s1-t" + ++index),
                new XAttribute("name", _redactor.Text(Final(result)?.Scenario ?? result.TestIdentity)));
            test.Add(new XElement("tag", _redactor.Text(Feature(result))));
            foreach (var attempt in result.Attempts)
            {
                var block = new XElement("kw", new XAttribute("name", "Actual attempt " + attempt.Projection.AttemptNumber),
                    new XAttribute("owner", "Canonical artifact manifest"));
                foreach (var step in attempt.Projection.Steps)
                    block.Add(new XElement("kw", new XAttribute("name", _redactor.Text(step.Text)),
                        new XAttribute("owner", _redactor.Text(step.Binding?.Method ?? "Not recorded")),
                        new XElement("msg", new XAttribute("level", step.Status == ReportStatus.Fail ? "FAIL" : "INFO"),
                            _redactor.Text(step.Error)),
                        XmlStatus(step.Status, step.StartedAtUtc, step.DurationMilliseconds)));
                block.Add(XmlStatus(attempt.Projection.Status, attempt.Projection.StartedAtUtc, attempt.Projection.DurationMilliseconds));
                test.Add(block);
            }
            test.Add(XmlStatus(result.Status, Final(result)?.StartedAtUtc, result.DurationMilliseconds, result.FailureMessage));
            suite.Add(test);
        }
        suite.Add(XmlStatus(ConsolidatedReportRenderer.OverallStatus(report), null,
            report.Tests.Sum(test => test.DurationMilliseconds),
            string.Join("\n", report.Issues.Select(issue => issue.Message))));
        var document = new XDocument(new XDeclaration("1.0", "utf-8", null),
            new XElement("robot", new XAttribute("generator", "PnC SGS compatibility projection (not canonical)"),
                new XAttribute("generated", report.GeneratedAtUtc.ToString("O", CultureInfo.InvariantCulture)),
                new XAttribute("schemaversion", "5"), suite,
                new XElement("statistics", new XElement("total",
                    new XElement("stat", new XAttribute("pass", report.Tests.Count(item => item.Status == ReportStatus.Pass)),
                        new XAttribute("ok", report.Tests.Count(item => item.Status == ReportStatus.Pass)),
                        new XAttribute("fail", report.Tests.Count(item => item.Status == ReportStatus.Fail)),
                        new XAttribute("skip", report.Tests.Count(item => item.Status == ReportStatus.Skip)), "All Tests"))),
                new XElement("errors", report.Issues.Select(issue =>
                    new XElement("msg", new XAttribute("level", "ERROR"), _redactor.Text(issue.Message))))));
        return document.Declaration + Environment.NewLine + document;
    }

    private XElement XmlStatus(ReportStatus status, DateTimeOffset? start, double duration, string message = "") =>
        new("status", new XAttribute("status", status.Text()),
            new XAttribute("elapsed", Number(duration / 1000, "F6")),
            start.HasValue ? new XAttribute("start", start.Value.ToString("O", CultureInfo.InvariantCulture)) : null,
            _redactor.Text(message));

    private string Statistics(ImmutableArray<ReportTestResult> tests, string type, string title,
        Func<ReportTestResult, string> key)
    {
        var rows = string.Concat(tests.GroupBy(key).OrderBy(group => group.Key, StringComparer.Ordinal).Select(group =>
        {
            var passed = group.Count(item => item.Status == ReportStatus.Pass);
            var rate = Percent(passed, group.Count());
            return $"""<tr class="click-filter" data-filter-type="{type}" data-filter-value="{E(group.Key)}"><td><a href="#test-details">{E(group.Key)}</a></td><td>{group.Count()}</td><td class="ok-text">{passed}</td><td class="fail-text">{group.Count(item => item.Status == ReportStatus.Fail)}</td><td>{group.Count(item => item.Status == ReportStatus.Skip)}</td><td>{E(Duration(group.Sum(item => item.DurationMilliseconds)))}</td><td><div class="mini-bar"><span class="ok-segment" style="width:{Number(rate)}%"></span></div><small>{Number(rate, "F1")}%</small></td></tr>""";
        }));
        return $"""<section class="statistics-panel"><h3>{E(title)}</h3><div class="table-scroll"><table class="statistics-table"><thead><tr><th>{E(type)}</th><th>Total</th><th>Success</th><th>Fail</th><th>Skip</th><th>Elapsed</th><th>Success rate</th></tr></thead><tbody>{rows}</tbody></table></div></section>""";
    }

    private string Data(ImmutableDictionary<string, string> data) => data.Count == 0
        ? """<span class="muted">No display data recorded.</span>"""
        : "<table class=\"data-table\"><tbody>" + string.Concat(data.OrderBy(item => item.Key, StringComparer.Ordinal)
            .Select(item => $"<tr><th scope=\"row\">{E(item.Key)}</th><td>{E(_redactor.Value(item.Key, item.Value))}</td></tr>")) + "</tbody></table>";

    private string ScreenshotLink(ScenarioReportView view, string? path)
    {
        var file = view.Evidence.Files.FirstOrDefault(item => item.Kind == "Screenshot" &&
            string.Equals(item.RelativePath, path?.Replace('\\', '/'), StringComparison.OrdinalIgnoreCase));
        return file == null ? """<span class="muted">Not recorded / unavailable</span>""" : Link(file, "Open screenshot");
    }

    private string Link(ReportEvidenceFile file, string label, string css = "") =>
        ReportPaths.IsLocalHref(file.Href)
            ? $"""<a class="{css}" href="{A(file.Href!)}" target="_blank" rel="noopener noreferrer">{E(label)} <small>{file.SizeBytes} bytes</small></a>"""
            : $"""<span class="{css} muted">{E(label)}: redacted preview only / unavailable link</span>""";

    private static bool SafeImage(string? data) => data != null &&
        new[] { "data:image/png;base64,", "data:image/jpeg;base64,", "data:image/webp;base64,", "data:image/gif;base64," }
            .Any(prefix => data.StartsWith(prefix, StringComparison.Ordinal) &&
                data.AsSpan(prefix.Length).IndexOfAnyExcept("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=".AsSpan()) < 0);

    private string Issues(ImmutableArray<ReportIssue> issues) => issues.Length == 0 ? "" :
        "<section class=\"evidence-error\"><h3>Evidence / reconciliation failures</h3><ul>" +
        string.Concat(issues.Select(issue => $"<li><strong>{E(issue.Code)}</strong>: {E(issue.Message)} {E(issue.TestIdentity)}</li>")) +
        "</ul><p>These findings do not change the canonical test counts or repair an outcome.</p></section>";

    private string Panel(string title, string? text) => string.IsNullOrWhiteSpace(text) ? "" :
        $"""<details class="diagnostic" open><summary>{E(title)}</summary><pre>{E(text)}</pre></details>""";
    private string Options(IEnumerable<string> values, string label) =>
        $"""<option value="">All {E(label)}</option>""" + string.Concat(values.Distinct(StringComparer.Ordinal)
            .OrderBy(value => value, StringComparer.Ordinal).Select(value => $"""<option value="{E(value)}">{E(value)}</option>"""));
    private string Card(string label, string value, string css = "") =>
        $"""<div class="card"><span>{E(label)}</span><strong class="{css}">{E(value)}</strong></div>""";
    private static string Pill(ReportStatus status) => $"""<span class="status-pill {status.Text()}">{status.Text()}</span>""";
    private static ScenarioReportProjection? Final(ReportTestResult result) =>
        result.Attempts.IsEmpty ? null : result.Attempts[^1].Projection;
    private static string Feature(ReportTestResult result) => Final(result)?.Feature ?? "Unmatched canonical results";
    private string E(string? value) => WebUtility.HtmlEncode(_redactor.Text(value));
    private static string A(string value) => WebUtility.HtmlEncode(value);
    private static string Number(double value, string format = "F3") => value.ToString(format, CultureInfo.InvariantCulture);
    private static double Percent(int count, int total) => total == 0 ? 0 : 100.0 * count / total;
    private static string Duration(double milliseconds) => milliseconds < 1000
        ? Number(milliseconds, "F0") + " ms" : Number(milliseconds / 1000, "F2") + " s";
    private static string Timestamp(DateTimeOffset? time) =>
        time?.UtcDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff 'UTC'", CultureInfo.InvariantCulture) ?? "Not recorded";
}
