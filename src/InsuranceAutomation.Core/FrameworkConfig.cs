using System.Text.Json;

namespace InsuranceAutomation.Core;

public sealed class FrameworkConfig
{
    public BrowserOptions Browser { get; init; } = new();
    public SelfHealOptions SelfHeal { get; init; } = new();
    public ReportingOptions Reporting { get; init; } = new();
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
        if (string.IsNullOrWhiteSpace(Browser.Channel) && string.IsNullOrWhiteSpace(Browser.FallbackBrowser))
            throw new InvalidOperationException($"Configure browser.channel or browser.fallbackBrowser. Config: {path}");
        if (!Reporting.AttachmentMode.Equals("all", StringComparison.OrdinalIgnoreCase) &&
            !Reporting.AttachmentMode.Equals("key", StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException($"reporting.attachmentMode must be 'all' or 'key'. Config: {path}");
        if (Reporting.MaxSingleAttachmentBytes <= 0 || Reporting.MaxAttachmentCount <= 0)
            throw new InvalidOperationException($"Reporting attachment limits must be positive. Config: {path}");

        if (SelfHeal.Enabled)
        {
            if (string.IsNullOrWhiteSpace(SelfHeal.Provider)) throw new InvalidOperationException($"selfHeal.provider is required. Config: {path}");
            if (SelfHeal.Provider.Equals("openai-compatible",StringComparison.OrdinalIgnoreCase))
            {
                if (string.IsNullOrWhiteSpace(SelfHeal.Endpoint)) throw new InvalidOperationException($"selfHeal.endpoint is required for openai-compatible healing. Config: {path}");
                if (string.IsNullOrWhiteSpace(SelfHeal.Model)) throw new InvalidOperationException($"selfHeal.model is required for openai-compatible healing. Config: {path}");
                if (string.IsNullOrWhiteSpace(SelfHeal.ApiKeyEnvironmentVariable)) throw new InvalidOperationException($"selfHeal.apiKeyEnvironmentVariable is required. Config: {path}");
            }
            else if (!SelfHeal.Provider.Equals("github-copilot",StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException($"Unsupported selfHeal.provider '{SelfHeal.Provider}'. Use openai-compatible or github-copilot. Config: {path}");
        }
    }

    public string? GetLlmApiKey() =>
        string.IsNullOrWhiteSpace(SelfHeal.ApiKeyEnvironmentVariable)
            ? null
            : Environment.GetEnvironmentVariable(SelfHeal.ApiKeyEnvironmentVariable);

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
    public int ViewportWidth { get; init; } = 1440;
    public int ViewportHeight { get; init; } = 900;
    public int ActionTimeoutMs { get; init; } = 30000;
    public int NavigationTimeoutMs { get; init; } = 60000;
    public bool Trace { get; init; } = true;
    public bool Video { get; init; } = true;
    public bool Har { get; init; } = true;
    public bool ScreenshotOnFailure { get; init; } = true;
    public bool ScreenshotEachStep { get; init; }
}

public sealed class SelfHealOptions
{
    public bool Enabled { get; init; } = true;
    public string Provider { get; init; } = "openai-compatible";
    public string Endpoint { get; init; } = "";
    public string Model { get; init; } = "";
    public string ApiKeyEnvironmentVariable { get; init; } = "TEST_LLM_API_KEY";
    public bool IncludeScreenshot { get; init; } = true;
    public int MaxPreviousSteps { get; init; } = 3;
    public int DomMaxChars { get; init; } = 50000;
    public int CandidateLimit { get; init; } = 400;
    public int RequestTimeoutSeconds { get; init; } = 45;
    public double MinimumConfidence { get; init; } = 0.70;
    public string CacheFile { get; init; } = "Artifacts/SelfHealing/locator-cache.json";
    public string AuditFile { get; init; } = "Artifacts/SelfHealing/healing-audit.jsonl";
    public int CacheContextLimit { get; init; } = 20;
    public string CopilotExecutable { get; init; } = "copilot";
    public string DomEvidenceDirectory { get; init; } = "Artifacts/DOM";
    public string LocatorCatalogFile { get; init; } = "Artifacts/ToscaLocatorPropertyCatalog.json";
    public bool CaptureDomAfterActions { get; init; } = true;
}

public sealed class ReportingOptions
{
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

public sealed class ExecutionOptions
{
    public bool StrictUnknownConditions { get; init; } = true;
    public string ExternalDataFile { get; init; } = "TestData/ExternalDataOverrides.json";
}
