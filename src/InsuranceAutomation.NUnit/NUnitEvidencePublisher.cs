using System.Security.Cryptography;
using System.Text.Json;
using InsuranceAutomation.Core;
using NUnit.Framework;

namespace InsuranceAutomation.NUnit;

public static class NUnitEvidencePublisher
{
    private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

    public static EvidencePublishResult Publish(
        string artifactDirectory,
        FrameworkConfig config,
        string feature,
        string scenario,
        Exception? scenarioError,
        NUnitTestEvidenceContext? testEvidenceContext = null)
    {
        if (!config.Reporting.AttachEvidenceToTestResult)
            return new EvidencePublishResult(false, 0, 0, [], [], null);

        try
        {
            return PublishCore(artifactDirectory, config, feature, scenario, scenarioError, testEvidenceContext);
        }
        catch (Exception ex)
        {
            try { TestContext.Progress.WriteLine($"NUnit evidence publication failed: {ex}"); } catch { }
            return new EvidencePublishResult(true, 0, 0, [], [$"publisher::{ex.GetType().Name}: {ex.Message}"], null);
        }
    }

    private static EvidencePublishResult PublishCore(
        string artifactDirectory,
        FrameworkConfig config,
        string feature,
        string scenario,
        Exception? scenarioError,
        NUnitTestEvidenceContext? testEvidenceContext)
    {
        var root = Path.GetFullPath(artifactDirectory);
        Directory.CreateDirectory(root);
        var identity = testEvidenceContext ?? NUnitTestEvidenceContext.Capture(feature, scenario);
        var stageRoot = Path.GetFullPath(identity.ResultDirectory);
        Directory.CreateDirectory(stageRoot);

        var sourceResultPath = Path.Combine(root, "nunit-attachment-result.json");
        var manifestPath = Path.Combine(root, "test-evidence-manifest.json");
        File.WriteAllText(manifestPath, JsonSerializer.Serialize(BuildManifest(root, feature, scenario, scenarioError, sourceResultPath), JsonOptions));

        var allFiles = Directory.EnumerateFiles(root, "*", SearchOption.AllDirectories)
            .Where(path => !SamePath(path, sourceResultPath))
            .Select(Path.GetFullPath)
            .OrderBy(AttachmentPriority)
            .ThenBy(path => Path.GetRelativePath(root, path), StringComparer.OrdinalIgnoreCase)
            .ToList();

        if (config.Reporting.AttachmentMode.Equals("key", StringComparison.OrdinalIgnoreCase))
            allFiles = allFiles.Where(IsKeyEvidence).ToList();

        var policy = scenarioError is null ? config.Reporting.Passed : config.Reporting.Failed;
        allFiles = allFiles.Where(path => AllowedByPolicy(root, path, policy)).ToList();

        var attached = new List<string>();
        var skipped = new List<string>();
        var failures = new List<string>();
        ValidateRequiredEvidence(root, config, failures);

        foreach (var sourceFile in allFiles.Take(config.Reporting.MaxAttachmentCount))
        {
            var relative = Path.GetRelativePath(root, sourceFile);
            try
            {
                var info = new FileInfo(sourceFile);
                if (!info.Exists)
                {
                    skipped.Add($"missing::{relative}");
                    continue;
                }
                if (info.Length > config.Reporting.MaxSingleAttachmentBytes)
                {
                    skipped.Add($"oversize::{relative}::{info.Length}");
                    continue;
                }

                var stagedFile = Path.Combine(stageRoot, relative);
                Directory.CreateDirectory(Path.GetDirectoryName(stagedFile)!);
                if (!SamePath(sourceFile, stagedFile)) File.Copy(sourceFile, stagedFile, true);
                if (!File.Exists(stagedFile)) throw new FileNotFoundException("Persistent NUnit evidence copy was not created.", stagedFile);
                using (File.Open(stagedFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) { }
                TestContext.AddTestAttachment(stagedFile, Describe(root, sourceFile));
                attached.Add(relative);
                TestContext.Progress.WriteLine($"[TEST EVIDENCE] {identity.TestFullName} :: {relative} :: {stagedFile}");
            }
            catch (Exception ex)
            {
                failures.Add($"{relative} :: {ex.GetType().Name}: {ex.Message}");
                try { TestContext.Progress.WriteLine($"Evidence attachment failed: {sourceFile} :: {ex.Message}"); } catch { }
            }
        }

        if (allFiles.Count > config.Reporting.MaxAttachmentCount)
            skipped.Add($"attachment-count-limit::{allFiles.Count - config.Reporting.MaxAttachmentCount}");

        var currentTestId = SafeTestContext(() => TestContext.CurrentContext.Test.ID);
        var result = new
        {
            generatedAt = DateTimeOffset.Now,
            nunit = new
            {
                testIdAtScenarioStart = identity.TestId,
                testIdAtPublish = currentTestId,
                testName = identity.TestName,
                testFullName = identity.TestFullName,
                workDirectory = identity.WorkDirectory,
                resultDirectory = stageRoot,
                sameTestContext = string.IsNullOrWhiteSpace(identity.TestId) || string.Equals(identity.TestId, currentTestId, StringComparison.Ordinal)
            },
            feature,
            scenario,
            sourceArtifactRoot = root,
            mode = config.Reporting.AttachmentMode,
            attachedCount = attached.Count,
            skippedCount = skipped.Count,
            failedCount = failures.Count,
            attached,
            skipped,
            failures
        };

        File.WriteAllText(sourceResultPath, JsonSerializer.Serialize(result, JsonOptions));
        var stagedResultPath = Path.Combine(stageRoot, "nunit-attachment-result.json");
        File.WriteAllText(stagedResultPath, JsonSerializer.Serialize(result, JsonOptions));
        try
        {
            using (File.Open(stagedResultPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) { }
            TestContext.AddTestAttachment(stagedResultPath, "NUnit test-evidence attachment result");
            attached.Add("nunit-attachment-result.json");
        }
        catch (Exception ex)
        {
            failures.Add($"nunit-attachment-result.json :: {ex.GetType().Name}: {ex.Message}");
        }

        try
        {
            TestContext.Progress.WriteLine($"NUnit test evidence for '{identity.TestFullName}' staged under: {stageRoot}");
            TestContext.Progress.WriteLine($"NUnit attachments registered: {attached.Count}; skipped: {skipped.Count}; failures: {failures.Count}");
        }
        catch { }

        return new EvidencePublishResult(true, attached.Count, skipped.Count, attached, failures, stagedResultPath);
    }

    private static void ValidateRequiredEvidence(string root, FrameworkConfig config, ICollection<string> failures)
    {
        foreach (var required in new[] { "report.html", "execution.log" })
            if (!File.Exists(Path.Combine(root, required))) failures.Add($"required-finalized-evidence-missing::{required}");
        var screenshotDirectory = Path.Combine(root, "screenshots");
        if (config.Browser.ScreenshotAtScenarioEnd &&
            (!Directory.Exists(screenshotDirectory) || !Directory.EnumerateFiles(screenshotDirectory, "*.png", SearchOption.TopDirectoryOnly).Any()))
            failures.Add("required-finalized-evidence-missing::screenshot");
        var videoDirectory = Path.Combine(root, "video");
        if (config.Browser.Video &&
            (!Directory.Exists(videoDirectory) || !Directory.EnumerateFiles(videoDirectory, "*", SearchOption.TopDirectoryOnly).Any()))
            failures.Add("required-finalized-evidence-missing::video");
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

    private static bool AllowedByPolicy(string root, string path, EvidenceAttachmentPolicy p)
    {
        var category = Category(root, path);
        return category switch
        {
            "html-report" => p.HtmlReport,
            "execution-log" => p.ExecutionLog,
            "runtime-locator-evidence" => true,
            "browser-console-log" => p.Console,
            "network-call-log" => p.Network,
            "screenshot" => p.Screenshot,
            "playwright-trace" => p.Trace,
            "har" => p.Har,
            "video" => p.Video,
            "evidence-bundle" => p.Bundle,
            _ => true
        };
    }

    private static bool IsKeyEvidence(string path)
    {
        var name = Path.GetFileName(path).ToLowerInvariant();
        var normalized = path.Replace('\\', '/').ToLowerInvariant();
        return name is "report.html" or "execution.log" or "console.log" or "network.log" or "trace.zip" or "network.har.zip" or "evidence-bundle.zip" or "test-evidence-manifest.json" or "runtime-locators.jsonl"
            || normalized.Contains("/screenshots/") || normalized.Contains("/video/") || normalized.Contains("/self-heal/");
    }

    private static int AttachmentPriority(string path)
    {
        var name = Path.GetFileName(path).ToLowerInvariant();
        var normalized = path.Replace('\\', '/').ToLowerInvariant();
        if (name == "report.html") return 0;
        if (name == "execution.log") return 1;
        if (name == "runtime-locators.jsonl") return 2;
        if (normalized.Contains("/screenshots/")) return 3;
        if (name == "trace.zip") return 4;
        if (normalized.Contains("/video/")) return 5;
        if (name == "evidence-bundle.zip") return 6;
        if (name == "test-evidence-manifest.json") return 7;
        if (normalized.Contains("/self-heal/")) return 8;
        return 20;
    }

    private static string Category(string root, string path)
    {
        var name = Path.GetFileName(path).ToLowerInvariant();
        var rel = Path.GetRelativePath(root, path).Replace('\\', '/').ToLowerInvariant();
        if (name == "report.html") return "html-report";
        if (name == "execution.log") return "execution-log";
        if (name == "runtime-locators.jsonl") return "runtime-locator-evidence";
        if (name == "console.log") return "browser-console-log";
        if (name == "network.log") return "network-call-log";
        if (rel.StartsWith("screenshots/")) return "screenshot";
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
            "runtime-locator-evidence" => "Runtime Duck Creek technical locator evidence",
            "browser-console-log" => "Browser console and page-error log",
            "network-call-log" => "Browser request/response/failure log",
            "screenshot" => $"Playwright screenshot: {rel}",
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
