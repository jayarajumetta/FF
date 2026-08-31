using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLEQ.Pages;

namespace InsuranceAutomation.CLEQ.StepDefinitions;

[Binding]
public sealed class ApplicationSteps
{
    private readonly ScenarioContext _scenario;

    public ApplicationSteps(ScenarioContext scenario)
    {
        _scenario = scenario;
    }

    [Given("I open a browser session")]
    public Task OpenBrowserSessionAsync() =>
    _scenario.Get<BrowserSession>().OpenAsync(_scenario.Get<RunLogger>());

    [Given("test data {string} and external data {string} are loaded")]
    public void LoadScenarioData(string scenarioDataFile, string externalDataFile)
    {
        var scenarioPath = ResolvePath(scenarioDataFile);
        var externalPath = ResolvePath(externalDataFile);
        _scenario.Get<ScenarioData>().Load(scenarioPath, externalPath);
        _scenario.Get<RunLogger>().Info($"Loaded scenario data: {scenarioPath}");
    }

    [Given("I open the configured Commercial Lines ExpertQuote application")]
    public Task OpenApplicationAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        var page = new ApplicationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        return page.NavigateAsync(data.GetRequired("url"));
    }

    [Given("I sign in to Commercial Lines ExpertQuote using configured credentials")]
    public Task SignInAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        var page = new ApplicationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        var username = ResolveCredential(data, "username", "CL_EQ_USERNAME");
        var password = ResolveCredential(data, "password", "CL_EQ_PASSWORD");
        return page.SignInAsync(username, password);
    }

    private static string ResolveCredential(ScenarioData data, string key, string environmentVariable)
    {
        var value = data.Get(key);
        if (!ScenarioData.IsSynthetic(value)) return value;

        value = Environment.GetEnvironmentVariable(environmentVariable) ?? string.Empty;
        if (ScenarioData.IsSynthetic(value))
        {
            throw new InvalidOperationException(
        $"Credential '{key}' is not available. Set {environmentVariable} or provide it in TestData/ExternalDataOverrides.json.");
        }

        return value;
    }

    private static string ResolvePath(string relativePath) =>
    Path.Combine(AppContext.BaseDirectory, relativePath.Replace('/', Path.DirectorySeparatorChar));
}
