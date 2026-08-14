using System.Text.Json;

namespace ToscaModernized.Core.Configuration;

public static class SettingsLoader
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true
    };

    public static (FrameworkSettings Settings, string ContentRoot) Load()
    {
        var root = FindContentRoot();
        var path = Path.Combine(root, "appsettings.json");
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"Framework configuration was not found at '{path}'.", path);
        }

        var settings = JsonSerializer.Deserialize<FrameworkSettings>(File.ReadAllText(path), JsonOptions)
            ?? throw new InvalidDataException($"Configuration '{path}' deserialized to null.");

        var browser = settings.Browser;
        var execution = settings.Execution;
        settings = new FrameworkSettings
        {
            Browser = new BrowserOptions
            {
                Name = Env("BROWSER", browser.Name),
                Channel = EnvNullable("BROWSER_CHANNEL", browser.Channel),
                Headless = EnvBool("HEADLESS", browser.Headless),
                TimeoutMs = EnvInt("PLAYWRIGHT_TIMEOUT_MS", browser.TimeoutMs),
                NavigationTimeoutMs = EnvInt("NAVIGATION_TIMEOUT_MS", browser.NavigationTimeoutMs),
                SlowMoMs = EnvInt("SLOW_MO_MS", browser.SlowMoMs),
                IgnoreHttpsErrors = EnvBool("IGNORE_HTTPS_ERRORS", browser.IgnoreHttpsErrors),
                Viewport = Env("VIEWPORT", browser.Viewport)
            },
            Execution = new ExecutionOptions
            {
                DryRun = EnvBool("DRY_RUN", execution.DryRun),
                StrictStepOrder = EnvBool("STRICT_STEP_ORDER", execution.StrictStepOrder),
                StrictLocatorAmbiguity = EnvBool("STRICT_LOCATOR_AMBIGUITY", execution.StrictLocatorAmbiguity),
                ExecuteUnknownConditions = EnvBool("EXECUTE_UNKNOWN_CONDITIONS", execution.ExecuteUnknownConditions),
                ScreenshotOnFailure = EnvBool("SCREENSHOT_ON_FAILURE", execution.ScreenshotOnFailure),
                TraceEnabled = EnvBool("TRACE_ENABLED", execution.TraceEnabled)
            },
            Security = settings.Security,
            Paths = settings.Paths
        };
        return (settings, root);
    }

    private static string FindContentRoot()
    {
        var candidates = new[] { AppContext.BaseDirectory, Directory.GetCurrentDirectory() };
        foreach (var candidate in candidates)
        {
            var current = new DirectoryInfo(Path.GetFullPath(candidate));
            while (current is not null)
            {
                if (File.Exists(Path.Combine(current.FullName, "appsettings.json")))
                {
                    return current.FullName;
                }
                var testProjectRoot = Path.Combine(current.FullName, "tests", "ToscaModernized.Tests");
                if (File.Exists(Path.Combine(testProjectRoot, "appsettings.json")))
                {
                    return testProjectRoot;
                }
                current = current.Parent;
            }
        }
        throw new DirectoryNotFoundException("Unable to locate the ToscaModernized.Tests content root containing appsettings.json.");
    }

    private static string Env(string key, string fallback) =>
        string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(key)) ? fallback : Environment.GetEnvironmentVariable(key)!;

    private static string? EnvNullable(string key, string? fallback) =>
        string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(key)) ? fallback : Environment.GetEnvironmentVariable(key);

    private static bool EnvBool(string key, bool fallback) =>
        bool.TryParse(Environment.GetEnvironmentVariable(key), out var parsed) ? parsed : fallback;

    private static int EnvInt(string key, int fallback) =>
        int.TryParse(Environment.GetEnvironmentVariable(key), out var parsed) ? parsed : fallback;
}
