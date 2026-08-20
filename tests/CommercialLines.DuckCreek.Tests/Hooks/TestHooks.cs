using InsuranceAutomation.Core;
using InsuranceAutomation.NUnit;
using Reqnroll;

namespace InsuranceAutomation.CLDC.Hooks;

[Binding]
public sealed class TestHooks
{
    private readonly ScenarioContext _scenario;
    private readonly FeatureContext _feature;
    private static FrameworkConfig? _config;

    public TestHooks(ScenarioContext scenario, FeatureContext feature)
    {
        _scenario = scenario;
        _feature = feature;
    }

    [BeforeTestRun(Order = -1000)]
    public static void ValidateConfiguration() => _config = FrameworkConfig.Load();

    [BeforeScenario(Order = -100)]
    public void PrepareScenario()
    {
        var config = _config ?? FrameworkConfig.Load();
        var scenarioName = Safe(_scenario.ScenarioInfo.Title);
        var artifactDirectory = Path.Combine(
            config.Reporting.ArtifactRoot,
            Safe(_feature.FeatureInfo.Title),
            scenarioName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss_fff") + "_" + Guid.NewGuid().ToString("N")[..8]);

        Directory.CreateDirectory(artifactDirectory);
        var logger = new RunLogger(artifactDirectory);
        var browser = new BrowserSession(config);
        browser.SetArtifactDirectory(artifactDirectory);
        var data = new ScenarioData(config);
        var ui = new UiActions(browser, config, logger);
        var report = new ScenarioReport(artifactDirectory);

        _scenario.Set(config);
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
        var config = _scenario.Get<FrameworkConfig>();
        ExecutionIntent.StartStep(
            _feature.FeatureInfo.Title,
            _scenario.ScenarioInfo.Title,
            step,
            config.SelfHeal.MaxPreviousSteps);

        _scenario.Get<BrowserSession>().BeginStepEvidence();
        _scenario.Get<RunLogger>().Info($"START STEP: {step}");
        _scenario.Get<ScenarioReport>().StartStep(step);
    }

    [AfterStep]
    public async Task AfterStepAsync()
    {
        var config = _scenario.Get<FrameworkConfig>();
        var logger = _scenario.Get<RunLogger>();
        var data = _scenario.Get<ScenarioData>();
        var report = _scenario.Get<ScenarioReport>();
        var browser = _scenario.Get<BrowserSession>();
        var failed = _scenario.TestError is not null;
        string? screenshot = null;

        if (browser.IsStarted && ((failed && config.Browser.ScreenshotOnFailure) || config.Browser.ScreenshotEachStep))
        {
            screenshot = await browser.CaptureScreenshotAsync(
                $"{DateTime.Now:HHmmssfff}_{Safe(_scenario.StepContext.StepInfo.Text)}.png");
        }

        if (failed)
            logger.Error($"FAILED STEP: {_scenario.StepContext.StepInfo.Text} :: {_scenario.TestError}");
        else
            logger.Info($"PASSED STEP: {_scenario.StepContext.StepInfo.Text}");

        var evidence = browser.EndStepEvidence();
        report.EndStep(!failed, _scenario.TestError?.Message, data.Snapshot(), screenshot, evidence);
    }

    [AfterScenario(Order = 100)]
    public async Task FinishScenarioAsync()
    {
        var browser = _scenario.Get<BrowserSession>();
        var logger = _scenario.Get<RunLogger>();
        var config = _scenario.Get<FrameworkConfig>();
        var report = _scenario.Get<ScenarioReport>();
        var artifactDirectory = _scenario.Get<string>();

        try
        {
            // Browser context must close before evidence is attached so Playwright finalizes
            // trace.zip, HAR and video files for this exact test.
            await browser.CloseAsync(logger);

            if (config.Reporting.HtmlReport)
                report.Write(_feature.FeatureInfo.Title, _scenario.ScenarioInfo.Title, logger.LogPath, browser.TracePath, browser.VideoPath, browser.HarPath, null);

            var bundle = browser.CreateEvidenceBundle(logger);
            if (config.Reporting.HtmlReport)
                report.Write(_feature.FeatureInfo.Title, _scenario.ScenarioInfo.Title, logger.LogPath, browser.TracePath, browser.VideoPath, browser.HarPath, bundle);

            logger.Flush();

            // Add every scenario-owned artifact to the current NUnit result before ReqnRoll
            // returns control to the test adapter. NUnit3TestAdapter can surface these in
            // Visual Studio/vstest; Azure DevOps PublishTestResults@2 uploads them per test.
            var published = NUnitEvidencePublisher.Publish(
                artifactDirectory,
                config,
                _feature.FeatureInfo.Title,
                _scenario.ScenarioInfo.Title,
                _scenario.TestError);

            logger.Info($"TEST EVIDENCE ATTACHMENTS: enabled={published.Enabled}; attached={published.AttachedCount}; skipped={published.SkippedCount}; failures={published.Failures.Count}");
            foreach (var failure in published.Failures) logger.Warn($"ATTACHMENT FAILURE: {failure}");
            logger.Flush();
        }
        finally
        {
            logger.Dispose();
        }
    }

    private static string Safe(string value) =>
        string.Concat(value.Select(c => char.IsLetterOrDigit(c) ? c : '_')).Trim('_');
}
