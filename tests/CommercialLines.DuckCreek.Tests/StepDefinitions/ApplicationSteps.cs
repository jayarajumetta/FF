using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

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

    [Given("I open the configured Commercial Lines Duck Creek application")]
    public Task OpenApplicationAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        var page = new ApplicationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        return page.NavigateAsync(data.GetRequired("url"));
    }

    [Given("I sign in to Commercial Lines Duck Creek using configured credentials")]
    public Task SignInAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        var page = new ApplicationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        var username = ResolveCredential(data, "username", "CL_DC_USERNAME");
        var password = ResolveCredential(data, "password", "CL_DC_PASSWORD");
        return page.SignInAsync(username, password);
    }


    [When("I refresh the authenticated Duck Creek session")]
    public Task RefreshAuthenticatedSessionAsync() => AuthenticateAsync("agent", conditionalWineryState: false);

    [When("I switch to UW Director for OR and WA when required")]
    public Task SwitchToUwDirectorAsync() => AuthenticateAsync("uw-director", conditionalWineryState: true);

    [When("I switch back to Agent for OR and WA when required")]
    public Task SwitchBackToAgentAsync() => AuthenticateAsync("agent", conditionalWineryState: true);

    private async Task AuthenticateAsync(string role, bool conditionalWineryState)
    {
        var data = _scenario.Get<ScenarioData>();
        var logger = _scenario.Get<RunLogger>();
        var stateCode = data.Get("stateCode", data.Get("stateVariant", data.Get("state"))).Trim();
        if (conditionalWineryState &&
            !stateCode.Equals("OR", StringComparison.OrdinalIgnoreCase) &&
            !stateCode.Equals("WA", StringComparison.OrdinalIgnoreCase))
        {
            logger.Info($"Raw Tosca conditional authentication skipped for state '{stateCode}'. Role={role}.");
            return;
        }

        var url = data.Get("url", data.Get("application_url"));
        if (string.IsNullOrWhiteSpace(url))
            throw new InvalidOperationException("Duck Creek authentication URL is not available in raw-Tosca scenario data.");

        string username;
        string password;
        if (role.Equals("uw-director", StringComparison.OrdinalIgnoreCase))
        {
            username = Environment.GetEnvironmentVariable("CL_DC_UW_DIRECTOR_USERNAME") ?? string.Empty;
            password = Environment.GetEnvironmentVariable("CL_DC_UW_DIRECTOR_PASSWORD") ?? string.Empty;
            if (ScenarioData.IsSynthetic(username) || ScenarioData.IsSynthetic(password))
                throw new InvalidOperationException(
                    "Raw Tosca requires a UW Director role transition for OR/WA. Set CL_DC_UW_DIRECTOR_USERNAME and CL_DC_UW_DIRECTOR_PASSWORD.");
        }
        else
        {
            username = ResolveCredential(data, "username", "CL_DC_USERNAME");
            password = ResolveCredential(data, "password", "CL_DC_PASSWORD");
        }

        logger.Info($"Executing raw-Tosca authentication transition. Role={role}; State={stateCode}; Url={url}");
        var page = new ApplicationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await page.NavigateAsync(url);
        await page.SignInAsync(username, password);
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
