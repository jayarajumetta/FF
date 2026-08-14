using Reqnroll;
using Serilog;
using ToscaArtifactAutomation.Core.Actions;
using ToscaArtifactAutomation.Core.Browser;
using ToscaArtifactAutomation.Core.Configuration;
using ToscaArtifactAutomation.Core.Reporting;
using ToscaArtifactAutomation.Core.Runtime;

namespace ToscaArtifactAutomation.Tests.Shared.Hooks;

[Binding]
public sealed class AutomationHooks
{
    private readonly RootSettings _settings;
    private readonly BrowserSession _browser;
    private readonly ScenarioDataContext _data;
    private readonly StepExecutionTracker _steps;
    private readonly SystemActionService _system;
    private readonly ScenarioContext _scenario;
    private readonly FeatureContext _feature;
    private DateTime _scenarioStartUtc;
    private string _scenarioId = string.Empty;

    public AutomationHooks(RootSettings settings, BrowserSession browser, ScenarioDataContext data, StepExecutionTracker steps, SystemActionService system, ScenarioContext scenario, FeatureContext feature)
    {
        _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        _browser = browser ?? throw new ArgumentNullException(nameof(browser));
        _data = data ?? throw new ArgumentNullException(nameof(data));
        _steps = steps ?? throw new ArgumentNullException(nameof(steps));
        _system = system ?? throw new ArgumentNullException(nameof(system));
        _scenario = scenario ?? throw new ArgumentNullException(nameof(scenario));
        _feature = feature ?? throw new ArgumentNullException(nameof(feature));
    }

    [BeforeTestRun(Order = 0)]
    public static void BeforeTestRun()
    {
        var settings = FrameworkSettingsLoader.Load();
        ExecutionReportRegistry.Reset();
        LoggingBootstrap.Configure(settings);
    }

    [BeforeScenario(Order = 0)]
    public async Task BeforeScenarioAsync()
    {
        _scenarioId = Guid.NewGuid().ToString("N");
        _scenarioStartUtc = DateTime.UtcNow;
        _data.Initialize(_scenarioId);
        await _system.ExecuteProcessCleanupAsync();
        await _browser.StartAsync(_scenarioId, _scenario.ScenarioInfo.Title);
        if (_settings.Framework.CleanCookiesBeforeScenario) await _browser.ClearCookiesAsync();
    }

    [BeforeStep(Order = 0)]
    public void BeforeStep()
    {
        var info = _scenario.StepContext.StepInfo;
        _steps.Start(info.StepDefinitionType.ToString(), info.Text);
        Log.Information("MANUAL-EQUIVALENT STEP START: {Keyword} {Step}", info.StepDefinitionType, info.Text);
    }

    [AfterStep(Order = 100)]
    public async Task AfterStepAsync()
    {
        var failed = _scenario.TestError is not null;
        var screenshot = string.Empty;
        if ((failed && _settings.Framework.ScreenshotOnFailedStep) || (!failed && _settings.Framework.ScreenshotOnPassedStep))
            screenshot = await _browser.CaptureScreenshotAsync($"step-{_steps.Steps.Count + 1:D3}-{(failed ? "failed" : "passed")}");
        _steps.Complete(failed ? "Failed" : "Passed", screenshot, failed ? _scenario.TestError : null);
        Log.Information("MANUAL-EQUIVALENT STEP END: status={Status}", failed ? "Failed" : "Passed");
    }

    [AfterScenario(Order = 90)]
    public async Task CaptureFailureAndRecoverAsync()
    {
        if (_scenario.TestError is not null)
        {
            await _browser.CaptureScreenshotAsync("scenario-failure");
            if (_settings.Framework.CaptureDomOnFailure) await _browser.CaptureDomAsync("failure-dom");
        }
        if (_settings.Framework.CloseExtraPagesAfterScenario) await _browser.CloseExtraPagesAsync();
        if (_settings.Framework.CleanCookiesBeforeScenario) await _browser.ClearCookiesAsync();
    }

    [AfterScenario(Order = 100)]
    public async Task FinalizeScenarioAsync()
    {
        var status = _scenario.TestError is null ? "Passed" : "Failed";
        var artifactDirectory = _browser.ScenarioArtifactDirectory;
        await _browser.StopAsync();
        ExecutionReportRegistry.Add(new ScenarioExecutionRecord
        {
            ScenarioId = _scenarioId,
            Feature = _feature.FeatureInfo.Title,
            Scenario = _scenario.ScenarioInfo.Title,
            Application = _settings.Application.Name,
            Status = status,
            StartedUtc = _scenarioStartUtc,
            FinishedUtc = DateTime.UtcNow,
            ArtifactDirectory = artifactDirectory,
            Error = _scenario.TestError?.ToString() ?? string.Empty,
            RuntimeData = _data.RuntimeSnapshot(),
            Steps = _steps.Steps
        });
        _data.Release();
    }

    [AfterTestRun(Order = 100)]
    public static async Task AfterTestRunAsync()
    {
        var settings = FrameworkSettingsLoader.Load();
        var report = await ReportWriter.WriteAsync(settings);
        await ReportWriter.SendEmailAsync(settings, report);
        Log.Information("Automation run completed. Report: {Report}", report);
        Log.CloseAndFlush();
    }
}
