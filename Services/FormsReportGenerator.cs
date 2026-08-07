using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PnCTestAutomation.Models;

namespace PnCTestAutomation.Services
{
    /// <summary>
    /// Generates color-coded HTML reports for forms validation results.
    /// Replaces the manual review of raw CSV/clipboard data from the legacy Tosca workflow.
    /// </summary>
    public static class FormsReportGenerator
    {
        /// <summary>
        /// Generates a self-contained HTML report for one or more validation summaries.
        /// Supports both single-run and multi-state batch output.
        /// </summary>
        public static string Generate(IList<FormsValidationSummary> summaries, string outputPath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);

            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html lang=\"en\"><head><meta charset=\"UTF-8\">");
            sb.AppendLine("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            sb.AppendLine("<title>Forms Validation Report</title>");
            sb.AppendLine("<style>");
            sb.AppendLine(GetCss());
            sb.AppendLine("</style>");
            sb.AppendLine("<script>");
            sb.AppendLine(GetJs());
            sb.AppendLine("</script>");
            sb.AppendLine("</head><body>");

            // Share toolbar
            sb.AppendLine("<div class=\"share-toolbar\">");
            sb.AppendLine("  <div class=\"share-label\">&#128Share this report:</div>");
            sb.AppendLine("  <button class=\"share-btn\" onclick=\"window.print()\">&#128438; Save as PDF</button>");
            sb.AppendLine($"  <button class=\"share-btn\" onclick=\"copyPath()\">&#128203; Copy file path</button>");
            sb.AppendLine($"  <span class=\"share-hint\">or attach <strong>{Enc(Path.GetFileName(outputPath))}</strong> directly to email / Teams</span>");
            sb.AppendLine("</div>");
            sb.AppendLine($"<input type=\"hidden\" id=\"reportPath\" value=\"{Enc(Path.GetFullPath(outputPath))}\">");

            // Header
            var first = summaries[0];
            var timestamp = first.Timestamp.ToString("yyyy-MM-dd HH:mm:ss");
            sb.AppendLine($"<h1>Forms Validation Report</h1>");
            var policyLabel = summaries.Select(s => s.PolicyTypeLabel).FirstOrDefault(l => !string.IsNullOrWhiteSpace(l)) ?? string.Empty;
            var policyDisplay = string.IsNullOrWhiteSpace(policyLabel) ? string.Empty : $" &mdash; Policy: <strong>{Enc(policyLabel)}</strong>";
            sb.AppendLine($"<p class=\"subtitle\">LOB: <strong>{Enc(first.LOB)}</strong>{policyDisplay} &mdash; Generated: {timestamp}</p>");

            // Aggregate banner
            var totalPass = summaries.Sum(s => s.Passed);
            var totalFail = summaries.Sum(s => s.Failed);
            var totalInfo = summaries.Sum(s => s.Info);
            var totalIssue = summaries.Sum(s => s.Issues);
            var totalForms = summaries.Sum(s => s.TotalForms);
            var overallStatus = totalFail == 0 && totalIssue == 0 ? "ALL PASSED" : "FAILURES DETECTED";
            var bannerClass = totalFail == 0 && totalIssue == 0 ? "banner-pass" : "banner-fail";

            sb.AppendLine($"<div class=\"banner {bannerClass}\">");
            sb.AppendLine($"  <span class=\"banner-status\">{overallStatus}</span>");
            sb.AppendLine($"  <span class=\"banner-detail\">Total: {totalForms} &bull; Pass: {totalPass} &bull; Fail: {totalFail} &bull; Info: {totalInfo} &bull; Issue: {totalIssue}</span>");
            sb.AppendLine("</div>");

            // Per-summary sections
            foreach (var summary in summaries)
            {
                sb.AppendLine($"<div class=\"section\">");
                var sectionPolicy = string.IsNullOrWhiteSpace(summary.PolicyTypeLabel) ? string.Empty : $" &mdash; {Enc(summary.PolicyTypeLabel)}";
                sb.AppendLine($"<h2>{Enc(summary.LOB)} / {Enc(summary.State)}{sectionPolicy} &mdash; Quote {Enc(summary.QuoteId)}</h2>");

                // Summary cards
                sb.AppendLine("<div class=\"cards\">");
                AppendCard(sb, "Total", summary.TotalForms, "card-total");
                AppendCard(sb, "Pass", summary.Passed, "card-pass");
                AppendCard(sb, "Fail", summary.Failed, summary.Failed > 0 ? "card-fail" : "card-pass");
                AppendCard(sb, "Info", summary.Info, "card-info");
                AppendCard(sb, "Issue", summary.Issues, summary.Issues > 0 ? "card-issue" : "card-pass");
                sb.AppendLine("</div>");

                // Metadata
                if (summary.ResponseMetadata != null)
                {
                    var m = summary.ResponseMetadata;
                    sb.AppendLine("<details class=\"metadata\"><summary>Response Metadata</summary><ul>");
                    sb.AppendLine($"<li>PrintJob: {Enc(m.PrintJobName)}</li>");
                    sb.AppendLine($"<li>Manuscript: {Enc(m.Manuscript)}</li>");
                    sb.AppendLine($"<li>RoleBasedSecurity: {m.HasRoleBasedSecurity}</li>");
                    sb.AppendLine($"<li>ReturnSuccess: {Enc(m.ReturnSuccessStatus)}</li>");
                    if (m.Warnings.Count > 0)
                    {
                        sb.AppendLine("<li>Warnings:<ul>");
                        foreach (var w in m.Warnings)
                            sb.AppendLine($"<li>{Enc(w)}</li>");
                        sb.AppendLine("</ul></li>");
                    }
                    sb.AppendLine("</ul></details>");
                }

                // Results table
                sb.AppendLine("<table>");
                sb.AppendLine("<thead><tr><th>Form</th><th>Expected</th><th>Actual</th><th>Result</th><th>Code</th><th>Message</th></tr></thead>");
                sb.AppendLine("<tbody>");

                // Failures first, then issues, info, pass
                var ordered = summary.Results
                    .OrderBy(r => r.Result switch { "FAIL" => 0, "ISSUE" => 1, "INFO" => 2, _ => 3 })
                    .ThenBy(r => r.FormName);

                foreach (var r in ordered)
                {
                    var rowClass = r.Result switch
                    {
                        "FAIL" => "row-fail",
                        "ISSUE" => "row-issue",
                        "INFO" => "row-info",
                        _ => "row-pass"
                    };
                    var actualText = r.ActualSelected switch
                    {
                        0 => "Not Checked (0)",
                        1 => "Selected (1)",
                        2 => "Mandatory (2)",
                        _ => "Not On Policy"
                    };
                    sb.AppendLine($"<tr class=\"{rowClass}\">");
                    sb.AppendLine($"  <td>{Enc(r.FormName)}</td>");
                    sb.AppendLine($"  <td>{Enc(r.ExpectedStatus)}</td>");
                    sb.AppendLine($"  <td>{actualText}</td>");
                    sb.AppendLine($"  <td><span class=\"badge badge-{r.Result.ToLowerInvariant()}\">{r.Result}</span></td>");
                    sb.AppendLine($"  <td>{Enc(r.ResultCode)}</td>");
                    sb.AppendLine($"  <td>{Enc(r.Message)}</td>");
                    sb.AppendLine("</tr>");
                }

                sb.AppendLine("</tbody></table>");
                sb.AppendLine("</div>"); // section
            }

            sb.AppendLine("<footer>Generated by PnC Test Automation &mdash; Forms Validation Engine</footer>");
            sb.AppendLine("</body></html>");

            File.WriteAllText(outputPath, sb.ToString());
            Console.WriteLine($"HTML report saved: {outputPath}");
            return outputPath;
        }

        /// <summary>
        /// Convenience overload for a single validation run.
        /// </summary>
        public static string Generate(FormsValidationSummary summary, string outputPath)
            => Generate(new[] { summary }, outputPath);

        /// <summary>
        /// Writes a Markdown summary file and emits ##vso[task.uploadsummary] so ADO attaches it to the pipeline run page.
        /// </summary>
        public static void WritePipelineSummary(FormsValidationSummary summary, string outputDirectory)
        {
            var overall = summary.AllPassed ? "✅ ALL PASSED" : $"❌ {summary.Failed} FAILURE(S)";
            var md = new StringBuilder();
            md.AppendLine($"# Forms Validation — {summary.LOB} / {summary.State}");
            md.AppendLine();
            md.AppendLine("| Item | Value |");
            md.AppendLine("|---|---|");
            md.AppendLine($"| Policy Type | {summary.PolicyTypeLabel} |");
            md.AppendLine($"| State | {summary.State} |");
            md.AppendLine($"| Quote | {summary.QuoteId} |");
            md.AppendLine($"| Generated | {summary.Timestamp:yyyy-MM-dd HH:mm:ss} |");
            md.AppendLine();
            md.AppendLine("| Forms Checked | Pass | Fail | Info | Result |");
            md.AppendLine("|---:|---:|---:|---:|---|");
            md.AppendLine($"| {summary.TotalForms} | {summary.Passed} | {summary.Failed} | {summary.Info} | {overall} |");

            var attention = summary.Results
                .Where(r => r.Result == "FAIL" || r.Result == "INFO" || r.Result == "ISSUE")
                .ToList();

            if (attention.Any())
            {
                md.AppendLine();
                md.AppendLine("## Attention Items");
                md.AppendLine();
                md.AppendLine("| Form | Result | Message |");
                md.AppendLine("|---|---|---|");
                foreach (var item in attention)
                    md.AppendLine($"| {item.FormName} | {item.Result} | {item.Message?.Replace("|", "\\|")} |");
            }

            Directory.CreateDirectory(outputDirectory);
            var mdPath = Path.GetFullPath(Path.Combine(outputDirectory, $"FormsValidationSummary_{summary.LOB}_{summary.State}.md"));
            File.WriteAllText(mdPath, md.ToString(), Encoding.UTF8);

            // ADO reads this from stdout and pins the Markdown to the pipeline run summary tab.
            Console.WriteLine($"##vso[task.uploadsummary]{mdPath}");
        }

        private static void AppendCard(StringBuilder sb, string label, int value, string cssClass)
        {
            sb.AppendLine($"<div class=\"card {cssClass}\"><div class=\"card-value\">{value}</div><div class=\"card-label\">{label}</div></div>");
        }

        private static string Enc(string value) => System.Net.WebUtility.HtmlEncode(value ?? "");

        private static string GetJs() => @"
function copyPath() {
    var path = document.getElementById('reportPath').value;
    navigator.clipboard.writeText(path).then(function() {
        var btn = event.target;
        var orig = btn.textContent;
        btn.textContent = '\u2713 Copied!';
        setTimeout(function() { btn.textContent = orig; }, 2000);
    });
}
";

        private static string GetCss() => @"
* { box-sizing: border-box; margin: 0; padding: 0; }
body { font-family: 'Segoe UI', system-ui, sans-serif; padding: 24px; background: #f4f6f8; color: #1a1a1a; }
h1 { font-size: 1.8rem; margin-bottom: 4px; }
.subtitle { color: #555; margin-bottom: 16px; }
.banner { padding: 14px 20px; border-radius: 8px; margin-bottom: 24px; display: flex; justify-content: space-between; align-items: center; }
.banner-pass { background: #d4edda; border: 1px solid #28a745; }
.banner-fail { background: #f8d7da; border: 1px solid #dc3545; }
.banner-status { font-weight: 700; font-size: 1.1rem; }
.banner-detail { font-size: 0.95rem; }
.section { background: #fff; border-radius: 8px; padding: 20px; margin-bottom: 20px; box-shadow: 0 1px 3px rgba(0,0,0,0.08); }
h2 { font-size: 1.3rem; margin-bottom: 12px; }
.cards { display: flex; gap: 12px; margin-bottom: 16px; flex-wrap: wrap; }
.card { border-radius: 8px; padding: 12px 20px; min-width: 100px; text-align: center; }
.card-value { font-size: 1.6rem; font-weight: 700; }
.card-label { font-size: 0.85rem; color: #555; }
.card-total { background: #e9ecef; }
.card-pass { background: #d4edda; }
.card-fail { background: #f8d7da; }
.card-info { background: #d1ecf1; }
.card-issue { background: #fff3cd; }
.metadata { margin-bottom: 12px; font-size: 0.9rem; cursor: pointer; }
.metadata summary { font-weight: 600; }
.metadata ul { margin: 8px 0 0 20px; }
table { width: 100%; border-collapse: collapse; font-size: 0.88rem; }
thead th { background: #343a40; color: #fff; padding: 8px 10px; text-align: left; position: sticky; top: 0; }
tbody td { padding: 6px 10px; border-bottom: 1px solid #dee2e6; }
.row-fail { background: #fff0f0; }
.row-issue { background: #fff9e6; }
.row-info { background: #f0f8ff; }
.row-pass { background: #fff; }
.badge { padding: 2px 8px; border-radius: 4px; font-weight: 600; font-size: 0.8rem; }
.badge-pass { background: #28a745; color: #fff; }
.badge-fail { background: #dc3545; color: #fff; }
.badge-info { background: #17a2b8; color: #fff; }
.badge-issue { background: #ffc107; color: #000; }
footer { text-align: center; color: #888; font-size: 0.8rem; margin-top: 24px; padding: 12px; }
.share-toolbar { display: flex; align-items: center; gap: 10px; background: #fff; border: 1px solid #dee2e6; border-radius: 8px; padding: 10px 16px; margin-bottom: 20px; flex-wrap: wrap; }
.share-label { font-weight: 600; color: #555; margin-right: 4px; }
.share-btn { padding: 6px 14px; border: 1px solid #6c757d; border-radius: 6px; background: #f8f9fa; cursor: pointer; font-size: 0.88rem; }
.share-btn:hover { background: #e2e6ea; }
.share-hint { color: #888; font-size: 0.85rem; }
@media print { .share-toolbar { display: none; } body { background: #fff; } .section { box-shadow: none; } }
";
    }
}
