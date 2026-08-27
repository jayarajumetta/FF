using System.Security.Cryptography;
using System.Text.Json;
using InsuranceAutomation.Core;
using NUnit.Framework;

namespace InsuranceAutomation.NUnit;

/// <summary>
/// Publishes scenario-owned Playwright evidence into the current NUnit test result.
/// Evidence is first staged under NUnit's WorkDirectory so Visual Studio Test Explorer/vstest
/// receives stable, runner-owned files rather than transient repository-relative paths.
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

        var sourceResultPath = Path.Combine(root, "nunit-attachment-result.json");
        var manifestPath = Path.Combine(root, "test-evidence-manifest.json");
        var manifest = BuildManifest(root, feature, scenario, scenarioError, sourceResultPath);
        File.WriteAllText(manifestPath, JsonSerializer.Serialize(manifest, JsonOptions));

        var stageRoot = CreateStageDirectory(feature, scenario, createUnique: true);
        var allFiles = Directory.EnumerateFiles(root, "*", SearchOption.AllDirectories)
            .Where(path => !SamePath(path, sourceResultPath))
            .Select(Path.GetFullPath)
            .OrderBy(AttachmentPriority)
            .ThenBy(path => Path.GetRelativePath(root, path), StringComparer.OrdinalIgnoreCase)
            .ToList();

        if (config.Reporting.AttachmentMode.Equals("key", StringComparison.OrdinalIgnoreCase))
            allFiles = allFiles.Where(IsKeyEvidence).ToList();

        var attached = new List<string>();
        var skipped = new List<string>();
        var failures = new List<string>();
        var requiredFinalized = new[] { "report.html", "execution.log" };
        foreach (var required in requiredFinalized)
            if (!File.Exists(Path.Combine(root, required))) failures.Add($"required-finalized-evidence-missing::{required}");
        var screenshotDirectory = Path.Combine(root, "screenshots");
        if (config.Browser.ScreenshotAtScenarioEnd &&
            (!Directory.Exists(screenshotDirectory) || !Directory.EnumerateFiles(screenshotDirectory, "*.png", SearchOption.TopDirectoryOnly).Any()))
            failures.Add("required-finalized-evidence-missing::screenshot");
        var videoDirectory = Path.Combine(root, "video");
        if (config.Browser.Video &&
            (!Directory.Exists(videoDirectory) || !Directory.EnumerateFiles(videoDirectory, "*", SearchOption.TopDirectoryOnly).Any()))
            failures.Add("required-finalized-evidence-missing::video");

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
                File.Copy(sourceFile, stagedFile, true);
                // v57 contract: copy into persistent NUnit result storage, prove the finalized file exists/readable,
                // and only then register it with TestContext.AddTestAttachment.
                if (!File.Exists(stagedFile)) throw new FileNotFoundException("Persistent NUnit evidence copy was not created.", stagedFile);
                using (File.Open(stagedFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) { }
                InsuranceAutomation.NUnit.NUnitEvidenceAttachment.AddTestAttachment(stagedFile, Describe(root, sourceFile));
                attached.Add(relative);
            }
            catch (Exception ex)
            {
                failures.Add($"{relative} :: {ex.GetType().Name}: {ex.Message}");
                try { TestContext.Progress.WriteLine($"Evidence attachment failed: {sourceFile} :: {ex.Message}"); } catch { }
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
                fullName = SafeTestContext(() => TestContext.CurrentContext.Test.FullName),
                workDirectory = SafeTestContext(() => TestContext.CurrentContext.WorkDirectory)
            },
            feature,
            scenario,
            sourceArtifactRoot = root,
            stagedEvidenceRoot = stageRoot,
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
            InsuranceAutomation.NUnit.NUnitEvidenceAttachment.AddTestAttachment(stagedResultPath, "NUnit test-evidence attachment result");
            attached.Add("nunit-attachment-result.json");
        }
        catch (Exception ex)
        {
            failures.Add($"nunit-attachment-result.json :: {ex.GetType().Name}: {ex.Message}");
        }

        try
        {
            TestContext.Progress.WriteLine($"NUnit test evidence staged under: {stageRoot}");
            TestContext.Progress.WriteLine($"NUnit attachments registered: {attached.Count}; skipped: {skipped.Count}; failures: {failures.Count}");
        }
        catch { }

        return new EvidencePublishResult(true, attached.Count, skipped.Count, attached, failures, stagedResultPath);
    }

    private static string CreateStageDirectory(string feature, string scenario, bool createUnique)
    {
        var work = SafeTestContext(() => TestContext.CurrentContext.WorkDirectory);
        if (string.IsNullOrWhiteSpace(work)) work = AppContext.BaseDirectory;
        var testId = SafeTestContext(() => TestContext.CurrentContext.Test.ID);
        var suffix = createUnique ? $"_{DateTime.Now:yyyyMMdd_HHmmss_fff}_{Guid.NewGuid():N}" : string.Empty;
        var folder = $"{Safe(feature)}__{Safe(scenario)}__{Safe(testId)}{suffix}";
        var path = Path.Combine(work, "TestResults", "TestEvidence", folder);
        Directory.CreateDirectory(path);
        return path;
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
        if (name == "trace.zip") return 5;
        if (name == "network.har.zip") return 6;
        if (normalized.Contains("/video/")) return 7;
        if (normalized.Contains("/self-heal/")) return 8;
        if (name == "evidence-bundle.zip") return 9;
        if (name == "test-evidence-manifest.json") return 10;
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

    private static string Safe(string value) =>
        string.Concat((value ?? string.Empty).Select(c => char.IsLetterOrDigit(c) || c is '-' or '_' ? c : '_')).Trim('_');

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
