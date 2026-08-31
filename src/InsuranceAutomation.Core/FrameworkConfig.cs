using System.Text.Json;

namespace InsuranceAutomation.Core;

public sealed class FrameworkConfig
{
    public BrowserOptions Browser { get; init; } = new();
    public ReportingOptions Reporting { get; init; } = new();
    public WaitOptions Waits { get; init; } = new();
    public ExecutionOptions Execution { get; init; } = new();

    public static FrameworkConfig Load()
    {
        var path = FindConfigFile();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var config = JsonSerializer.Deserialize<FrameworkConfig>(File.ReadAllText(path), options)
                     ?? throw new InvalidOperationException($"Unable to parse framework configuration: {path}");
        config.Validate(path);
        return config;
    }

    public void Validate(string path)
    {
        if (Browser.ActionTimeoutMs <= 0 || Browser.NavigationTimeoutMs <= 0)
            throw new InvalidOperationException($"Browser timeouts must be positive. Config: {path}");
        if (Browser.HighlightDurationMs < 0)
            throw new InvalidOperationException($"browser.highlightDurationMs cannot be negative. Config: {path}");
        if (Waits.PageReadyTimeoutMs <= 0 || Waits.ElementReadyTimeoutMs <= 0 || Waits.VerifyTimeoutMs <= 0 || Waits.FrameProbeTimeoutMs <= 0 || Waits.DropdownOptionTimeoutMs <= 0 || Waits.DropdownPollIntervalMs <= 0)
            throw new InvalidOperationException($"Framework wait timeouts must be positive. Config: {path}");
        if (string.IsNullOrWhiteSpace(Browser.Channel) && string.IsNullOrWhiteSpace(Browser.FallbackBrowser))
            throw new InvalidOperationException($"Configure browser.channel or browser.fallbackBrowser. Config: {path}");
        if (!Reporting.AttachmentMode.Equals("all", StringComparison.OrdinalIgnoreCase) &&
            !Reporting.AttachmentMode.Equals("key", StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException($"reporting.attachmentMode must be 'all' or 'key'. Config: {path}");
        if (Reporting.MaxSingleAttachmentBytes <= 0 || Reporting.MaxAttachmentCount <= 0)
            throw new InvalidOperationException($"Reporting attachment limits must be positive. Config: {path}");



    }


    private static string FindConfigFile()
    {
        var explicitPath = Environment.GetEnvironmentVariable("TEST_FRAMEWORK_CONFIG");
        if (!string.IsNullOrWhiteSpace(explicitPath) && File.Exists(explicitPath)) return Path.GetFullPath(explicitPath);

        foreach (var start in new[] { Directory.GetCurrentDirectory(), AppContext.BaseDirectory })
        {
            var current = new DirectoryInfo(start);
            while (current is not null)
            {
                var candidate = Path.Combine(current.FullName, "config", "framework.json");
                if (File.Exists(candidate)) return candidate;
                current = current.Parent;
            }
        }
        throw new FileNotFoundException("config/framework.json was not found. Set TEST_FRAMEWORK_CONFIG to an explicit path if needed.");
    }
}

public sealed class BrowserOptions
{
    public string Channel { get; init; } = "msedge";
    public string FallbackBrowser { get; init; } = "chromium";
    public bool Headless { get; init; }
    public bool IgnoreHttpsErrors { get; init; } = true;
    public bool Maximize { get; init; } = true;
    public int ViewportWidth { get; init; } = 1440;
    public int ViewportHeight { get; init; } = 900;
    public int ActionTimeoutMs { get; init; } = 15000;
    public int NavigationTimeoutMs { get; init; } = 30000;
    public bool Trace { get; init; } = true;
    public bool Video { get; init; } = true;
    public bool Har { get; init; } = true;
    public bool ScreenshotOnFailure { get; init; } = true;
    public bool ScreenshotEachStep { get; init; }
    public bool ScreenshotAtScenarioEnd { get; init; } = true;
    public bool HighlightInteractions { get; init; } = true;
    public int HighlightDurationMs { get; init; } = 120;
}


public sealed class WaitOptions
{
    // Core synchronization defaults. Page methods should rely on UiActions rather than scatter sleeps.
    public int PageReadyTimeoutMs { get; init; } = 30000;
    public int ElementReadyTimeoutMs { get; init; } = 30000;
    public int VerifyTimeoutMs { get; init; } = 35000;
    // Raw Tosca HtmlFrame is a hint only. Probe briefly before falling back to top document.
    public int FrameProbeTimeoutMs { get; init; } = 2000;
    // Dropdown option discovery uses a deliberately shorter budget than a normal page/control wait.
    public int DropdownOptionTimeoutMs { get; init; } = 1200;
    public int DropdownPollIntervalMs { get; init; } = 75;
    public int PollIntervalMs { get; init; } = 250;
    public bool WaitForDomContentLoadedBeforeActions { get; init; } = true;
}

public sealed class ReportingOptions
{
    public bool CollectConsole { get; init; } = true;
    public bool CollectNetwork { get; init; } = true;
    public EvidenceAttachmentPolicy Passed { get; init; } = EvidenceAttachmentPolicy.PassedDefaults();
    public EvidenceAttachmentPolicy Failed { get; init; } = EvidenceAttachmentPolicy.FailedDefaults();
    public string ArtifactRoot { get; init; } = "Artifacts";
    public bool HtmlReport { get; init; } = true;
    public bool IncludeResolvedData { get; init; } = true;
    public bool IncludeConsoleErrors { get; init; } = true;
    public bool IncludeNetworkErrors { get; init; } = true;
    public bool CreateEvidenceBundle { get; init; } = true;

    // NUnit/Visual Studio/Azure DevOps test-result evidence integration.
    // "all" attaches every scenario-owned file; "key" attaches the report/log,
    // screenshots, trace, HAR, videos, evidence manifest and bundle only.
    public bool AttachEvidenceToTestResult { get; init; } = true;
    public string AttachmentMode { get; init; } = "all";
    public long MaxSingleAttachmentBytes { get; init; } = 536870912; // 512 MiB guardrail
    public int MaxAttachmentCount { get; init; } = 5000;
}

public sealed class EvidenceAttachmentPolicy
{
    public bool Screenshot { get; init; } = true;
    public bool ExecutionLog { get; init; } = true;
    public bool HtmlReport { get; init; } = true;
    public bool Video { get; init; } = true;
    public bool Trace { get; init; } = true;
    public bool Har { get; init; } = false;
    public bool Console { get; init; } = true;
    public bool Network { get; init; } = true;
    public bool Bundle { get; init; } = false;
    public static EvidenceAttachmentPolicy PassedDefaults() => new() { Har = false, Bundle = false };
    public static EvidenceAttachmentPolicy FailedDefaults() => new() { Har = true, Bundle = true };
}

public sealed class ExecutionOptions
{
    public bool StrictUnknownConditions { get; init; } = true;
    // Tosca verification failures are accumulated after mature waits and canonical locator resolution and fail at scenario end,
    // allowing later steps and all requested evidence to complete. Fatal browser/action failures still fail immediately.
    public bool DeferVerificationFailures { get; init; } = true;
    public string ExternalDataFile { get; init; } = "TestData/ExternalDataOverrides.json";
}
