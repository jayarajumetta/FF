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
        var page = new ApplicationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Force ExpertQuote QA URL for this workflow.
        const string expertQuoteUrl = "https://expertquote-qa.americannational.com/expertquote/";
        _scenario.Get<RunLogger>().Info($"Opening ExpertQuote URL: {expertQuoteUrl}");

        return page.NavigateAsync(expertQuoteUrl);
    }

    [Given("I sign in to Commercial Lines ExpertQuote using configured credentials")]
    public Task SignInAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        var page = new ApplicationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        //var username = ResolveCredential(data, "username", "CL_EQ_USERNAME");
        //var password = ResolveCredential(data, "password", "CL_EQ_PASSWORD");
        var username = "YDH040";
        var password = "Anico456";
        return page.SignInAsync(username, password);
    }

    [Given("I open the configured Commercial Lines Duck Creek application")]
    public Task OpenDuckCreekApplicationAsync()
    {
        var page = new DuckCreekLoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        const string duckCreekUrl = "https://clasq.anico.com/Express/default.aspx";
        _scenario.Get<RunLogger>().Info($"Opening Duck Creek URL: {duckCreekUrl}");

        return page.NavigateAsync(duckCreekUrl);
    }

    [Given("I sign in to Commercial Lines Duck Creek using configured credentials")]
    public async Task SignInToDuckCreekAsync()
    {
        var page = new DuckCreekLoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        const string username = "ffqa008";
        const string password = "test";

        await page.EnterUserNameAsync(username);
        await page.EnterPasswordAsync(password);
        await page.ClickLoginAsync();
        await page.WaitForLoginAsync("Absent");
    }

    [Given("I search for the policy by Description in Duck Creek")]
    public async Task SearchPolicyByDescriptionInDuckCreekAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        var description = data.Get("DescriptionOfOperations");
        var page = new DuckCreekSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickQuickSearchAsync();
        await Task.Delay(3000);
        await page.SelectSearchFieldAsync("Description");
        await Task.Delay(3000);
        await page.SelectSearchOperatorAsync("is");
        await Task.Delay(3000);
        await page.EnterSearchValueAsync(description);
        await Task.Delay(3000);
        await page.ClickSearchAsync();
        await Task.Delay(6000);
        await page.ClickSearchAsync();
        await Task.Delay(3000);
    }

    [Given("I click the insured name in the Duck Creek search results")]
    public async Task ClickInsuredNameInSearchResultsAsync()
    {
        var page = new DuckCreekSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await Task.Delay(3000);
        await page.ClickSearchResultInsuredNameAsync();
        await Task.Delay(3000);
        await page.ClickBusinessOwnersQuoteAsync();
        await Task.Delay(3000);
    }

    [Given("I navigate to the Submission window in Duck Creek")]
    public Task NavigateToSubmissionWindowAsync()
    {
        var page = new DuckCreekSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        return page.ClickSubmissionAsync();
    }

    [Given("I click Complete Application in Duck Creek")]
    public async Task ClickCompleteApplicationAsync()
    {
        var page = new DuckCreekSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await Task.Delay(3000);
        await page.ClickCompleteApplicationAsync();
        await Task.Delay(3000);
        await page.WaitForProcessingCompleteAsync();
        await Task.Delay(9000);
        await page.ClickProcessingCompleteCloseAsync();
        await Task.Delay(3000);
        await page.ClickApproveAsync();
        await Task.Delay(3000);
        await page.WaitForOkButtonAsync();
        await page.ClickOkAsync();
        await Task.Delay(5000);
        await page.VerifyApprovedStatusAsync("Approved", "Status");
        await Task.Delay(3000);
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
