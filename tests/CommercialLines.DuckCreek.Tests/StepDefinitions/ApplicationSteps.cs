using InsuranceAutomation.Core;
using Microsoft.Playwright;
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
    [When("I sign in to Commercial Lines Duck Creek using configured credentials")]
    [Then("I sign in to Commercial Lines Duck Creek using configured credentials")]
    public Task SignInAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        var username = ResolveCredential(data, "username", "CL_DC_USERNAME");
        var password = ResolveCredential(data, "password", "CL_DC_PASSWORD");

        if(data.Resolve("{{data:stateVariant}}") == "MA Auto")
        {
            return SignInWithLoginPageAsync(page, "AGO9999", password);
        }
        else
        {
            return SignInWithLoginPageAsync(page, username, password);
        }
    }

    [When("I refresh the authenticated Duck Creek session")]
    public Task RefreshAuthenticatedSessionAsync() => AuthenticateAsync("agent", conditionalWineryState: false);

    [When("I switch to UW Director for OR and WA when required")]
    public Task SwitchToUwDirectorAsync() =>
        
        AuthenticateAsync("uw-director", conditionalWineryState: true);



    [When("I switch back to Agent for OR and WA when required")]
    public Task SwitchBackToAgentAsync() => AuthenticateAsync("agent", conditionalWineryState: true);

    [Given(@"^I click on QA button to logout$")]
    [When(@"^I click on QA button to logout$")]
    [Then(@"^I click on QA button to logout$")]
    public async Task ClickOnQAButtonToLogoutAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        var navigationPage = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        //await navigationPage.WaitForClientLinkAsync("Visible");
        //await navigationPage.ClickClientLinkAsync();
        //await navigationPage.WaitForHomeLinkAsync("Visible");
        await navigationPage.ClickHomeLinkAsync();
        //await page.WaitForUserNameInitialAsync("Visible");
        await page.ClickUserNameInitialAsync();
        //await page.WaitForLogoutAsync("Visible");
        await page.ClickLogoutAsync();

        if (await page.LogoutOkButtonIsVisibleAsync())
        {
            await page.ClickLogoutOkButtonAsync();
            //await page.WaitForLogoutOkButtonAsync("Hidden");
            //await page.WaitForUserNameInitialAsync("Visible");
            await page.ClickUserNameInitialAsync();
            //await page.WaitForLogoutAsync("Visible");
            await page.ClickLogoutAsync();
        }

    }

    [Given(@"^I search for the quote description using quick search$")]
    [When(@"^I search for the quote description using quick search$")]
    [Then(@"^I search for the quote description using quick search$")]
    public async Task SearchForTheQuoteDescriptionUsingQuickSearchAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForSearchTextAsync("Visible");
        //await page.EnterSearchTextSequentiallyAsync(data.Resolve("{B[QuoteDescription]}"));
        await page.EnterSearchTextSequentiallyAsync("AL BAP STRAIGHTTHROUGH 09.18.26 14:35");
        await page.WaitForQuickSearchButtonAsync("Visible");
        await page.ClickQuickSearchButtonAsync();
        await page.WaitForSearchMethodEGDescriptionPolicyAsync("Visible");
        await page.EnterSearchMethodEGDescriptionPolicySequentiallyAsync("Description");
        await page.PressSearchMethodEGDescriptionPolicyAsync("Tab");
        await page.WaitForSearchButtonAsync("Visible");
        await page.ClickSearchButtonAsync();
        await page.WaitForSearchResultsInsuredNameColumnHeaderAsync("Visible");
        await page.ClickSearchResultInsuredNameLinkAsync();
        await page.WaitForCommercialAutoQuoteLinkAsync("Visible");
        await page.ClickCommercialAutoQuoteLinkAsync();

        var navigationPage = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        if (await navigationPage.IsClientLinkVisibleAsync())
        {
            await navigationPage.ClickClientLinkAsync();
            await navigationPage.WaitForClientPageTitleAsync("Visible");
        }

    }

    [Given("I search for the policy quote  using quick search")]
    [When("I search for the policy quote  using quick search")]
    [Then("I search for the policy quote  using quick search")]
    public Task SearchForThePolicyQuoteUsingQuickSearchAsync() => SearchForThePolicyQuoteUsingQuickSearchAsync(null);

    [Given("I search for the policy quote  using quick search with policy number {word}")]
    [When("I search for the policy quote  using quick search with policy number {word}")]
    [Then("I search for the policy quote  using quick search with policy number {word}")]
    public async Task SearchForThePolicyQuoteUsingQuickSearchAsync(string? policyNumberRule)
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        var policyNumber = data.Get("RegressionPolicyNumber", data.Get("Policy#"));
        if (string.IsNullOrWhiteSpace(policyNumber))
        {
            policyNumber = policyNumberRule;
        }

        await page.WaitForSearchTextAsync("Visible");
        //await page.EnterSearchTextSequentiallyAsync(policyNumber);
        //await page.PressSearchTextAsync("Tab");
        //await page.WaitForQuickSearchButtonAsync("Visible");
        //await page.ClickQuickSearchButtonAsync();
        //await page.WaitForSearchMethodEGDescriptionPolicyAsync("Visible");
        ////await page.EnterSearchMethodEGDescriptionPolicySequentiallyAsync("Policy");
        ////await page.PressSearchMethodEGDescriptionPolicyAsync("Tab");
        //await page.WaitForSearchButtonAsync("Visible");
        //await page.ClickSearchButtonAsync();
        //await page.WaitForSearchResultsInsuredNameColumnHeaderAsync("Visible");
        //await page.ClickSearchResultInsuredNameLinkAsync();
        //await page.WaitForCommercialAutoQuoteLinkAsync("Visible");
        //await page.ClickCommercialAutoQuoteLinkAsync();

        //var navigationPage = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        //if (await navigationPage.IsClientLinkVisibleAsync())
        //{
        //    await navigationPage.ClickClientLinkAsync();
        //    await navigationPage.WaitForClientPageTitleAsync("Visible");
        //}
    }






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
        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await page.NavigateAsync(url);
        await SignInWithLoginPageAsync(page, username, password);
    }


    private static async Task SignInWithLoginPageAsync(LoginPage page, string username, string password)
    {
        try
        {
            await page.EnterUserNameAsync(username);
        }
        catch (Exception ex) when (ex is TimeoutException or PlaywrightException)
        {
            // The login form occasionally fails to render after a logout -> re-open navigation (stale
            // SPA bootstrap state). A single reload is far cheaper and more reliable than a longer timeout.
            await page.ReloadAsync();
            await page.EnterUserNameAsync(username);
        }

        await page.EnterPasswordAsync(password);
        await page.ClickLoginAsync();
        await page.WaitForLoginAsync("Absent");
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
