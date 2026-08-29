using InsuranceAutomation.Core;
using InsuranceAutomation.NUnit;
using Reqnroll;

namespace InsuranceAutomation.PLDC.Hooks;

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
        var testEvidenceContext = NUnitTestEvidenceContext.Capture(_feature.FeatureInfo.Title, _scenario.ScenarioInfo.Title);
        var logger = new RunLogger(artifactDirectory);
        var browser = new BrowserSession(config);
        browser.SetArtifactDirectory(artifactDirectory);
        var data = new ScenarioData(config);
        var report = new ScenarioReport(artifactDirectory);
        var verificationFailures = new DeferredVerificationCollector();
        var ui = new UiActions(browser, config, logger, report, "PersonalLines.DuckCreek", verificationFailures);

        _scenario.Set(config);
        _scenario.Set(artifactDirectory);
        _scenario.Set(logger);
        _scenario.Set(browser);
        _scenario.Set(data);
        _scenario.Set(ui);
        _scenario.Set(report);
        _scenario.Set(verificationFailures);
        _scenario.Set(testEvidenceContext);

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
            3);

        _scenario.Get<BrowserSession>().BeginStepEvidence();
        _scenario.Set(_scenario.Get<DeferredVerificationCollector>().Failures.Count, "DeferredVerificationCountAtStepStart");
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
        var verificationFailures = _scenario.Get<DeferredVerificationCollector>();
        var beforeDeferred = _scenario.ContainsKey("DeferredVerificationCountAtStepStart") ? _scenario.Get<int>("DeferredVerificationCountAtStepStart") : 0;
        var deferredInStep = verificationFailures.Failures.Count > beforeDeferred;
        var failed = _scenario.TestError is not null || deferredInStep;
        string? screenshot = null;

        if (browser.IsStarted && (failed || config.Browser.ScreenshotEachStep))
        {
            screenshot = await browser.CaptureScreenshotAsync(
                $"{DateTime.Now:HHmmssfff}_{Safe(_scenario.StepContext.StepInfo.Text)}.png");
        }

        if (_scenario.TestError is not null)
            logger.Error($"FAILED STEP: {_scenario.StepContext.StepInfo.Text} :: {_scenario.TestError}");
        else if (deferredInStep)
            logger.Warn($"STEP COMPLETED WITH DEFERRED VERIFICATION: {_scenario.StepContext.StepInfo.Text}");
        else
            logger.Info($"PASSED STEP: {_scenario.StepContext.StepInfo.Text}");

        var evidence = browser.EndStepEvidence();
        var stepError = _scenario.TestError?.Message ?? (deferredInStep ? "Verification failed after readiness wait and resolved-control interaction; deferred until scenario end." : null);
        report.EndStep(!failed, stepError, data.Snapshot(), screenshot, evidence);
    }

    [AfterScenario(Order = 100)]
    public Task FinishScenarioAsync() =>
        NUnitScenarioEvidenceFinalizer.FinishAsync(
            _scenario.Get<BrowserSession>(),
            _scenario.Get<RunLogger>(),
            _scenario.Get<FrameworkConfig>(),
            _scenario.Get<ScenarioReport>(),
            _scenario.Get<DeferredVerificationCollector>(),
            _scenario.Get<string>(),
            _feature.FeatureInfo.Title,
            _scenario.ScenarioInfo.Title,
            _scenario.TestError,
            _scenario.Get<NUnitTestEvidenceContext>());

    private static string Safe(string value) =>
        string.Concat(value.Select(c => char.IsLetterOrDigit(c) ? c : '_')).Trim('_');
}
