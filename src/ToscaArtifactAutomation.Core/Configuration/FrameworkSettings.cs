using System.Text.Json;

namespace ToscaArtifactAutomation.Core.Configuration;

public sealed class RootSettings
{
    public FrameworkSettings Framework { get; set; } = new();
    public ApplicationSettings Application { get; set; } = new();
}

public sealed class FrameworkSettings
{
    public string ApplicationCode { get; set; } = string.Empty;
    public string Browser { get; set; } = "chromium";
    public string Channel { get; set; } = "msedge";
    public bool Headless { get; set; } = true;
    public float SlowMoMs { get; set; }
    public int DefaultTimeoutMs { get; set; } = 60000;
    public int NavigationTimeoutMs { get; set; } = 90000;
    public bool StrictLocatorAmbiguity { get; set; } = true;
    public string UnknownConditionPolicy { get; set; } = "SkipAndLog";
    public bool FailOnSyntheticExternalData { get; set; } = true;
    public bool ScreenshotOnPassedStep { get; set; }
    public bool ScreenshotOnFailedStep { get; set; } = true;
    public bool RecordVideo { get; set; } = true;
    public bool RecordTrace { get; set; } = true;
    public bool CaptureDomOnFailure { get; set; } = true;
    public bool CleanCookiesBeforeScenario { get; set; } = true;
    public bool CloseExtraPagesAfterScenario { get; set; } = true;
    public bool EnableProcessCleanup { get; set; }
    public string ArtifactsRoot { get; set; } = "artifacts/runs";
    public string LocatorCatalog { get; set; } = "Locators/locator-catalog.json";
    public string ExternalOverrides { get; set; } = "TestData/ExternalDataOverrides.json";
    public HtmlReportSettings HtmlReport { get; set; } = new();
    public EmailReportSettings EmailReport { get; set; } = new();
}

public sealed class HtmlReportSettings
{
    public bool Enabled { get; set; } = true;
    public string FileName { get; set; } = "execution-report.html";
}

public sealed class EmailReportSettings
{
    public bool Enabled { get; set; }
    public string SmtpHost { get; set; } = string.Empty;
    public int SmtpPort { get; set; } = 587;
    public bool EnableSsl { get; set; } = true;
    public string From { get; set; } = string.Empty;
    public List<string> To { get; set; } = new();
    public string UsernameEnvironmentVariable { get; set; } = "REPORT_SMTP_USERNAME";
    public string PasswordEnvironmentVariable { get; set; } = "REPORT_SMTP_PASSWORD";
}

public sealed class ApplicationSettings
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string BaseUrl { get; set; } = string.Empty;
    public string AuthenticationMode { get; set; } = "FormOrExistingSession";
    public string UsernameEnvironmentVariable { get; set; } = string.Empty;
    public string PasswordEnvironmentVariable { get; set; } = string.Empty;
    public string UsernameControl { get; set; } = "Username";
    public string PasswordControl { get; set; } = "Password";
    public string SignInControl { get; set; } = "Sign On";
    public string ReadyControl { get; set; } = "New Quote";
    public string LoadingControl { get; set; } = "Loading ...";
}

public static class FrameworkSettingsLoader
{
    private static readonly object Gate = new();
    private static RootSettings? _cached;

    public static RootSettings Load()
    {
        lock (Gate)
        {
            if (_cached is not null)
                return _cached;

            var path = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
            if (!File.Exists(path))
                throw new FileNotFoundException("Framework configuration was not copied to the test output directory.", path);

            var json = File.ReadAllText(path);
            _cached = JsonSerializer.Deserialize<RootSettings>(json, JsonOptions())
                ?? throw new InvalidOperationException($"Configuration '{path}' deserialized to null.");
            Validate(_cached, path);
            return _cached;
        }
    }

    public static JsonSerializerOptions JsonOptions() => new()
    {
        PropertyNameCaseInsensitive = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true
    };

    private static void Validate(RootSettings settings, string path)
    {
        if (string.IsNullOrWhiteSpace(settings.Framework.ApplicationCode))
            throw new InvalidOperationException($"Framework.ApplicationCode is required in '{path}'.");
        if (string.IsNullOrWhiteSpace(settings.Application.BaseUrl))
            throw new InvalidOperationException($"Application.BaseUrl is required in '{path}'.");
        if (settings.Framework.DefaultTimeoutMs <= 0)
            throw new InvalidOperationException($"Framework.DefaultTimeoutMs must be positive in '{path}'.");
    }
}
