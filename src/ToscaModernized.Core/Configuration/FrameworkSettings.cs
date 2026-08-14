namespace ToscaModernized.Core.Configuration;

public sealed class FrameworkSettings
{
    public BrowserOptions Browser { get; init; } = new();
    public ExecutionOptions Execution { get; init; } = new();
    public SecurityOptions Security { get; init; } = new();
    public PathOptions Paths { get; init; } = new();
}

public sealed class BrowserOptions
{
    public string Name { get; init; } = "chromium";
    public string? Channel { get; init; } = "msedge";
    public bool Headless { get; init; } = true;
    public int TimeoutMs { get; init; } = 60_000;
    public int NavigationTimeoutMs { get; init; } = 90_000;
    public int SlowMoMs { get; init; }
    public bool IgnoreHttpsErrors { get; init; } = true;
    public string Viewport { get; init; } = "1600x1000";
}

public sealed class ExecutionOptions
{
    public bool DryRun { get; init; }
    public bool StrictStepOrder { get; init; } = true;
    public bool StrictLocatorAmbiguity { get; init; } = true;
    public bool ExecuteUnknownConditions { get; init; } = true;
    public bool ScreenshotOnFailure { get; init; } = true;
    public bool TraceEnabled { get; init; } = true;
}

public sealed class SecurityOptions
{
    public bool AllowProcessExecution { get; init; }
    public bool AllowFileMutation { get; init; }
    public bool AllowJsonPreferenceMutation { get; init; }
}

public sealed class PathOptions
{
    public string Plans { get; init; } = "Plans";
    public string TestData { get; init; } = "TestData";
    public string Locators { get; init; } = "Locators";
    public string Artifacts { get; init; } = "artifacts/runtime";
    public string TdmOverrides { get; init; } = "TestData/TdmOverrides.json";
    public string SourceValueOverrides { get; init; } = "TestData/SourceValueOverrides.json";
}
