using System.Security.Cryptography;
using System.Text.Json;
using InsuranceAutomation.Core;
using NUnit.Framework;

namespace InsuranceAutomation.NUnit;

/// <summary>
/// Publishes scenario-owned Playwright evidence into the current NUnit test result.
/// NUnit3TestAdapter then exposes the attachments to Visual Studio Test Explorer/vstest,
/// and Azure DevOps PublishTestResults@2 can upload those test-result attachments.
/// Attachment failures are evidence/reporting failures and never replace the business test outcome.
/// </summary>
public static class NUnitEvidencePublisher
{
    private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

    public static EvidencePublishResult Publish(
        string artifactDirectory,
        FrameworkConfig config,
        string feature,
        string scenario,
        Exception? scenarioError)
    {
        if (!config.Reporting.AttachEvidenceToTestResult)
            return new EvidencePublishResult(false, 0, 0, [], [], null);

        try
        {
            return PublishCore(artifactDirectory, config, feature, scenario, scenarioError);
        }
        catch (Exception ex)
        {
            // Evidence transport must never replace the actual business-test outcome.
            try { TestContext.Progress.WriteLine($"NUnit evidence publication failed: {ex}"); } catch { }
            return new EvidencePublishResult(true, 0, 0, [], [$"publisher::{ex.GetType().Name}: {ex.Message}"], null);
        }
    }

    private static EvidencePublishResult PublishCore(
        string artifactDirectory,
        FrameworkConfig config,
        string feature,
        string scenario,
        Exception? scenarioError)
    {
        var root = Path.GetFullPath(artifactDirectory);
        Directory.CreateDirectory(root);

        var manifestPath = Path.Combine(root, "test-evidence-manifest.json");
        var resultPath = Path.Combine(root, "nunit-attachment-result.json");
        var manifest = BuildManifest(root, feature, scenario, scenarioError, resultPath);
        File.WriteAllText(manifestPath, JsonSerializer.Serialize(manifest, JsonOptions));

        var allFiles = Directory.EnumerateFiles(root, "*", SearchOption.AllDirectories)
            .Where(path => !SamePath(path, resultPath))
            .Select(Path.GetFullPath)
            .OrderBy(AttachmentPriority)
            .ThenBy(path => Path.GetRelativePath(root, path), StringComparer.OrdinalIgnoreCase)
            .ToList();

        if (config.Reporting.AttachmentMode.Equals("key", StringComparison.OrdinalIgnoreCase))
            allFiles = allFiles.Where(IsKeyEvidence).ToList();

        var attached = new List<string>();
        var skipped = new List<string>();
        var failures = new List<string>();

        foreach (var file in allFiles.Take(config.Reporting.MaxAttachmentCount))
        {
            try
            {
                var info = new FileInfo(file);
                if (!info.Exists)
                {
                    skipped.Add($"missing::{Path.GetRelativePath(root, file)}");
                    continue;
                }
                if (info.Length > config.Reporting.MaxSingleAttachmentBytes)
                {
                    skipped.Add($"oversize::{Path.GetRelativePath(root, file)}::{info.Length}");
                    continue;
                }

                TestContext.AddTestAttachment(file, Describe(root, file));
                attached.Add(Path.GetRelativePath(root, file));
            }
            catch (Exception ex)
            {
                failures.Add($"{Path.GetRelativePath(root, file)} :: {ex.GetType().Name}: {ex.Message}");
                try { TestContext.Progress.WriteLine($"Evidence attachment failed: {file} :: {ex.Message}"); } catch { }
            }
        }

        if (allFiles.Count > config.Reporting.MaxAttachmentCount)
            skipped.Add($"attachment-count-limit::{allFiles.Count - config.Reporting.MaxAttachmentCount}");

        var result = new
        {
            generatedAt = DateTimeOffset.Now,
            nunit = new
            {
                id = SafeTestContext(() => TestContext.CurrentContext.Test.ID),
                name = SafeTestContext(() => TestContext.CurrentContext.Test.Name),
                fullName = SafeTestContext(() => TestContext.CurrentContext.Test.FullName)
            },
            feature,
            scenario,
            mode = config.Reporting.AttachmentMode,
            attachedCount = attached.Count,
            skippedCount = skipped.Count,
            failedCount = failures.Count,
            attached,
            skipped,
            failures
        };
        File.WriteAllText(resultPath, JsonSerializer.Serialize(result, JsonOptions));

        // Attach the publisher's own result last so the test result proves exactly what was attempted.
        try
        {
            TestContext.AddTestAttachment(resultPath, "NUnit test-evidence attachment result");
            attached.Add(Path.GetRelativePath(root, resultPath));
        }
        catch (Exception ex)
        {
            failures.Add($"nunit-attachment-result.json :: {ex.GetType().Name}: {ex.Message}");
        }

        return new EvidencePublishResult(true, attached.Count, skipped.Count, attached, failures, resultPath);
    }

    private static object BuildManifest(string root, string feature, string scenario, Exception? scenarioError, string resultPath)
    {
        var files = Directory.EnumerateFiles(root, "*", SearchOption.AllDirectories)
            .Where(path => !SamePath(path, resultPath))
            .OrderBy(path => path, StringComparer.OrdinalIgnoreCase)
            .Select(path =>
            {
                var info = new FileInfo(path);
                return new
                {
                    relativePath = Path.GetRelativePath(root, path),
                    category = Category(root, path),
                    description = Describe(root, path),
                    sizeBytes = info.Length,
                    sha256 = Sha256(path)
                };
            }).ToArray();

        return new
        {
            generatedAt = DateTimeOffset.Now,
            feature,
            scenario,
            outcome = scenarioError is null ? "Passed" : "Failed",
            error = scenarioError?.ToString(),
            artifactRoot = root,
            fileCount = files.Length,
            files
        };
    }

    private static bool IsKeyEvidence(string path)
    {
        var name = Path.GetFileName(path).ToLowerInvariant();
        var normalized = path.Replace('\\', '/').ToLowerInvariant();
        return name is "report.html" or "execution.log" or "console.log" or "network.log" or "trace.zip" or "network.har.zip" or "evidence-bundle.zip" or "test-evidence-manifest.json"
            || normalized.Contains("/screenshots/") || normalized.Contains("/video/")
            || normalized.Contains("/self-heal/");
    }

    private static int AttachmentPriority(string path)
    {
        var name = Path.GetFileName(path).ToLowerInvariant();
        var normalized = path.Replace('\\', '/').ToLowerInvariant();
        if (name == "report.html") return 0;
        if (name == "execution.log") return 1;
        if (name == "console.log") return 2;
        if (name == "network.log") return 3;
        if (normalized.Contains("/screenshots/")) return 4;
        if (normalized.Contains("/dom/") && path.EndsWith(".html", StringComparison.OrdinalIgnoreCase)) return 3;
        if (name == "trace.zip") return 4;
        if (name == "network.har.zip") return 5;
        if (normalized.Contains("/video/")) return 6;
        if (normalized.Contains("/self-heal/")) return 7;
        if (name == "evidence-bundle.zip") return 8;
        if (name == "test-evidence-manifest.json") return 9;
        return 20;
    }

    private static string Category(string root, string path)
    {
        var name = Path.GetFileName(path).ToLowerInvariant();
        var rel = Path.GetRelativePath(root, path).Replace('\\', '/').ToLowerInvariant();
        if (name == "report.html") return "html-report";
        if (name == "execution.log") return "execution-log";
        if (name == "console.log") return "browser-console-log";
        if (name == "network.log") return "network-call-log";
        if (rel.StartsWith("screenshots/")) return "screenshot";
        if (rel.StartsWith("dom/") && name.EndsWith(".html")) return "html-dom";
        if (rel.StartsWith("dom/")) return "dom-metadata";
        if (name == "trace.zip") return "playwright-trace";
        if (name == "network.har.zip") return "har";
        if (rel.StartsWith("video/")) return "video";
        if (rel.StartsWith("self-heal/")) return "self-heal";
        if (name == "evidence-bundle.zip") return "evidence-bundle";
        return "artifact";
    }

    private static string Describe(string root, string path)
    {
        var category = Category(root, path);
        var rel = Path.GetRelativePath(root, path).Replace('\\', '/');
        return category switch
        {
            "html-report" => "Scenario HTML execution report",
            "execution-log" => "Scenario execution log",
            "browser-console-log" => "Browser console and page-error log",
            "network-call-log" => "Browser request/response/failure log",
            "screenshot" => $"Playwright screenshot: {rel}",
            "html-dom" => $"Scenario-owned HTML DOM evidence: {rel}",
            "dom-metadata" => $"Scenario DOM/control/locator evidence: {rel}",
            "playwright-trace" => "Playwright trace archive",
            "har" => "Playwright HAR network archive",
            "video" => $"Playwright video: {rel}",
            "self-heal" => $"Locator healing evidence: {rel}",
            "evidence-bundle" => "Complete scenario evidence bundle",
            _ => $"Scenario artifact: {rel}"
        };
    }

    private static string Sha256(string path)
    {
        using var stream = File.OpenRead(path);
        return Convert.ToHexString(SHA256.HashData(stream)).ToLowerInvariant();
    }

    private static bool SamePath(string a, string b) =>
        Path.GetFullPath(a).Equals(Path.GetFullPath(b), StringComparison.OrdinalIgnoreCase);

    private static string SafeTestContext(Func<string> read)
    {
        try { return read() ?? string.Empty; }
        catch { return string.Empty; }
    }
}

public sealed record EvidencePublishResult(
    bool Enabled,
    int AttachedCount,
    int SkippedCount,
    IReadOnlyList<string> Attached,
    IReadOnlyList<string> Failures,
    string? ResultPath);
