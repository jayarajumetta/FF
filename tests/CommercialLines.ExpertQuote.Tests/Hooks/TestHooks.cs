using InsuranceAutomation.Core;
using Reqnroll;

namespace InsuranceAutomation.CLEQ.Hooks;

[Binding]
public sealed class TestHooks
{
    private readonly ScenarioContext _scenario;
    private readonly FeatureContext _feature;

    public TestHooks(ScenarioContext scenario, FeatureContext feature)
    {
        _scenario = scenario;
        _feature = feature;
    }

    [BeforeScenario(Order = -100)]
    public void PrepareScenario()
    {
        var scenarioName = Safe(_scenario.ScenarioInfo.Title);
        var artifactDirectory = Path.Combine("Artifacts", Safe(_feature.FeatureInfo.Title), scenarioName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
        Directory.CreateDirectory(artifactDirectory);

        var logger = new RunLogger(artifactDirectory);
        var browser = new BrowserSession();
        browser.SetArtifactDirectory(artifactDirectory);
        var data = new ScenarioData();
        var ui = new UiActions(browser, logger);
        var report = new ScenarioReport(artifactDirectory);

        _scenario.Set(artifactDirectory);
        _scenario.Set(logger);
        _scenario.Set(browser);
        _scenario.Set(data);
        _scenario.Set(ui);
        _scenario.Set(report);
    }

    [BeforeStep]
    public void BeforeStep()
    {
        var step = _scenario.StepContext.StepInfo.Text;
        _scenario.Get<RunLogger>().Info($"START STEP: {step}");
        _scenario.Get<ScenarioReport>().StartStep(step);
    }

    [AfterStep]
    public async Task AfterStepAsync()
    {
        var logger = _scenario.Get<RunLogger>();
        var data = _scenario.Get<ScenarioData>();
        var report = _scenario.Get<ScenarioReport>();
        var browser = _scenario.Get<BrowserSession>();
        var failed = _scenario.TestError is not null;
        string? screenshot = null;

        if (browser.IsStarted && (failed || ReadBool("SCREENSHOT_EACH_STEP", false)))
        {
            screenshot = await browser.CaptureScreenshotAsync($"{DateTime.Now:HHmmssfff}_{Safe(_scenario.StepContext.StepInfo.Text)}.png");
        }

        if (failed)
        {
            logger.Error($"FAILED STEP: {_scenario.StepContext.StepInfo.Text} :: {_scenario.TestError}");
        }
        else
        {
            logger.Info($"PASSED STEP: {_scenario.StepContext.StepInfo.Text}");
        }

        report.EndStep(!failed, _scenario.TestError?.Message, data.Snapshot(), screenshot);
    }

    [AfterScenario(Order = 100)]
    public async Task FinishScenarioAsync()
    {
        var browser = _scenario.Get<BrowserSession>();
        var logger = _scenario.Get<RunLogger>();
        try
        {
            await browser.CloseAsync(logger);
            _scenario.Get<ScenarioReport>().Write(
            _feature.FeatureInfo.Title,
            _scenario.ScenarioInfo.Title,
            logger.LogPath,
            browser.TracePath,
            browser.VideoPath);
        }
        finally
        {
            logger.Dispose();
        }
    }

    private static bool ReadBool(string name, bool fallback) =>
    bool.TryParse(Environment.GetEnvironmentVariable(name), out var value) ? value : fallback;

    private static string Safe(string value) =>
    string.Concat(value.Select(character => char.IsLetterOrDigit(character) ? character : '_')).Trim('_');
}
