using System.Text.Json;

namespace InsuranceAutomation.Core;

public sealed class FrameworkConfig
{
    private const long MaxConfigBytes = 1 * 1024 * 1024;

    public BrowserOptions Browser { get; init; } = new();
    public ReportingOptions Reporting { get; init; } = new();
    public WaitOptions Waits { get; init; } = new();
    public ExecutionOptions Execution { get; init; } = new();

    public static FrameworkConfig Load()
    {
        var repositoryRoot = SafeFileAccess.FindRepositoryRoot();
        var configRelativePath = Path.Combine("config", "framework.json");
        var safePath = SafeFileAccess.ResolveExistingFileUnderRoot(configRelativePath, MaxConfigBytes, ".json");
        var expectedPath = Path.GetFullPath(Path.Combine(repositoryRoot, configRelativePath));
        if (!safePath.Equals(expectedPath, StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException("Resolved framework configuration path is invalid.");

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        using var configStream = File.Open(safePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        var config = JsonSerializer.Deserialize<FrameworkConfig>(configStream, options)
                     ?? throw new InvalidOperationException($"Unable to parse framework configuration: {safePath}");
        config.Validate(safePath);
        config.Reporting.ResultsRoot = TestOutputPaths.ResolveResultsRoot(repositoryRoot, config.Reporting.ResultsRoot);
        config.Reporting.ArtifactRoot = TestOutputPaths.ResolveArtifactRoot(config.Reporting.ResultsRoot, config.Reporting.ArtifactRoot);
        return config;
    }

    public void Validate(string path)
    {
        if (Execution.RetryCount < 0 || Execution.RetryCount == int.MaxValue)
            throw new InvalidOperationException($"execution.retryCount must be between 0 and {int.MaxValue - 1}. Config: {path}");
        if (Browser.ActionTimeoutMs <= 0 || Browser.NavigationTimeoutMs <= 0)
            throw new InvalidOperationException($"Browser timeouts must be positive. Config: {path}");
        if (Browser.HighlightDurationMs < 0)
            throw new InvalidOperationException($"browser.highlightDurationMs cannot be negative. Config: {path}");
        if (Waits.PageReadyTimeoutMs <= 0 || Waits.ElementReadyTimeoutMs <= 0 || Waits.VerifyTimeoutMs <= 0 || Waits.FrameProbeTimeoutMs <= 0 || Waits.DropdownOptionTimeoutMs <= 0 || Waits.DropdownPollIntervalMs <= 0)
            throw new InvalidOperationException($"Framework wait timeouts must be positive. Config: {path}");
        if (Waits.NetworkIdleTimeoutMs <= 0 || Waits.PresenceTimeoutMs <= 0 || Waits.GenericFramePresenceTimeoutMs <= 0)
            throw new InvalidOperationException($"Framework presence/network-idle wait timeouts must be positive. Config: {path}");
        if (string.IsNullOrWhiteSpace(Browser.Channel) && string.IsNullOrWhiteSpace(Browser.FallbackBrowser))
            throw new InvalidOperationException($"Configure browser.channel or browser.fallbackBrowser. Config: {path}");
        if (!Reporting.AttachmentMode.Equals("all", StringComparison.OrdinalIgnoreCase) &&
            !Reporting.AttachmentMode.Equals("key", StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException($"reporting.attachmentMode must be 'all' or 'key'. Config: {path}");
        if (Reporting.MaxSingleAttachmentBytes <= 0 || Reporting.MaxAttachmentCount <= 0)
            throw new InvalidOperationException($"Reporting attachment limits must be positive. Config: {path}");



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
    public bool Trace { get; init; }
    public bool Video { get; init; }
    public bool Har { get; init; }
    public bool ScreenshotOnFailure { get; init; } = true;
    public bool ScreenshotEachStep { get; init; }
    public bool ScreenshotAtScenarioEnd { get; init; }
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
    // Framework-level pacing applied before every UiActions-driven action.
    public int PreActionDelayMs { get; init; } = 500;
    // Best-effort network-idle wait after DOM/load state settles. Some pages poll continuously and never idle,
    // so this is intentionally short and non-blocking (warn-and-continue on timeout).
    public int NetworkIdleTimeoutMs { get; init; } = 2000;
    // How long to wait for a control to be *attached* to the DOM (not necessarily visible) before falling
    // back to a generic iframe scan. Deliberately shorter than ElementReadyTimeoutMs.
    public int PresenceTimeoutMs { get; init; } = 4000;
    // Timeout applied per-frame while probing child iframes for a control during generic frame fallback.
    public int GenericFramePresenceTimeoutMs { get; init; } = 1500;
    // The Duck Creek loading overlay (#loadingMask/#loadingWindow/.x-mask) is checked before every single
    // action. It should clear quickly in the normal case; deliberately shorter than PageReadyTimeoutMs so a
    // slow-to-clear overlay cannot silently compound PageReadyTimeoutMs-sized stalls onto every action.
    public int LoadingOverlayTimeoutMs { get; init; } = 5000;
}

public sealed class ReportingOptions
{
    public bool ExcludeVideos { get; init; } = true;
    public bool ExcludePassedVideos { get; init; } = true;
    public bool ShouldExcludeVideo(bool passed) => ExcludeVideos || (ExcludePassedVideos && passed);
    public bool CollectConsole { get; init; }
    public bool CollectNetwork { get; init; }
    public EvidenceAttachmentPolicy Passed { get; init; } = EvidenceAttachmentPolicy.PassedDefaults();
    public EvidenceAttachmentPolicy Failed { get; init; } = EvidenceAttachmentPolicy.FailedDefaults();
    public string ResultsRoot { get; set; } = "TestResults";
    public string ArtifactRoot { get; set; } = "Artifacts";
    public bool HtmlReport { get; init; } = true;
    public bool IncludeResolvedData { get; init; } = true;
    public bool IncludeConsoleErrors { get; init; }
    public bool IncludeNetworkErrors { get; init; }
    public bool CreateEvidenceBundle { get; init; } = true;

    // NUnit/Visual Studio/Azure DevOps test-result evidence integration.
    // "all" attaches every scenario-owned file; "key" attaches the report/log,
    // screenshots, trace, HAR, videos, evidence manifest and bundle only.
    public bool AttachEvidenceToTestResult { get; init; } = true;
    public bool AttachPassedEvidenceToTestResult { get; init; } = true;
    public string AttachmentMode { get; init; } = "all";
    public long MaxSingleAttachmentBytes { get; init; } = 536870912; // 512 MiB guardrail
    public int MaxAttachmentCount { get; init; } = 5000;
}

public sealed class EvidenceAttachmentPolicy
{
    public bool Screenshot { get; init; } = true;
    public bool ExecutionLog { get; init; } = true;
    public bool HtmlReport { get; init; } = true;
    public bool Video { get; init; }
    public bool Trace { get; init; }
    public bool Har { get; init; }
    public bool Console { get; init; }
    public bool Network { get; init; }
    public bool Bundle { get; init; } = false;
    public static EvidenceAttachmentPolicy PassedDefaults() => new();
    public static EvidenceAttachmentPolicy FailedDefaults() => new();
}

public sealed class ExecutionOptions
{
    public int RetryCount { get; init; } = 0;
    public bool StrictUnknownConditions { get; init; } = true;
    // Tosca verification failures are accumulated after mature waits and canonical locator resolution and fail at scenario end,
    // allowing later steps and all requested evidence to complete. Fatal browser/action failures still fail immediately.
    public bool DeferVerificationFailures { get; init; } = true;
    public string ExternalDataFile { get; init; } = "TestData/ExternalDataOverrides.json";

    // Source of truth for test-level (fixture) parallel execution. Honored by Tosca.runsettings,
    // which is synced from this value (config/framework.json: execution.parallel) before every build/test run
    // via Directory.Build.targets -> scripts/Sync-ParallelSettings.ps1, so toggling it requires no code changes.
    // The release pipeline's EnableParallelExecution variable takes precedence over this value when set,
    // letting operators disable parallelism from the pipeline without touching config or code.
    public bool Parallel { get; init; } = true;
}
