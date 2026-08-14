using Reqnroll;
using ToscaModernized.Core.Runtime;

namespace ToscaModernized.Tests.Hooks;

[Binding]
public sealed class ScenarioHooks
{
    public const string ServicesKey = "ToscaModernized.ScenarioServices";
    private readonly FeatureContext _featureContext;
    private readonly ScenarioContext _scenarioContext;

    public ScenarioHooks(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        _featureContext = featureContext;
        _scenarioContext = scenarioContext;
    }

    [BeforeScenario(Order = -10_000)]
    public async Task BeforeScenarioAsync()
    {
        var services = await ScenarioServices.CreateAsync(_featureContext.FeatureInfo.Title, _scenarioContext.ScenarioInfo.Title).ConfigureAwait(false);
        _scenarioContext.Set(services, ServicesKey);
        try
        {
            await services.ExecuteSourceBackgroundAsync().ConfigureAwait(false);
        }
        catch
        {
            await services.DisposeAsync().ConfigureAwait(false);
            throw;
        }
    }

    [AfterScenario(Order = 10_000)]
    public async Task AfterScenarioAsync()
    {
        if (!_scenarioContext.TryGetValue(ServicesKey, out ScenarioServices? services) || services is null) return;
        try
        {
            if (_scenarioContext.TestError is null)
            {
                services.VerifyScenarioComplete();
            }
            else
            {
                var (settings, _) = ToscaModernized.Core.Configuration.SettingsLoader.Load();
                if (settings.Execution.ScreenshotOnFailure)
                {
                    await services.Artifacts.ScreenshotAsync(services.Browser.Page, "failure").ConfigureAwait(false);
                }
            }
        }
        finally
        {
            await services.DisposeAsync().ConfigureAwait(false);
        }
    }
}
