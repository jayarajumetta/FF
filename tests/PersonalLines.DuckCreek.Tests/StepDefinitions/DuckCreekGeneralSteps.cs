using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.PLDC.Pages;

namespace InsuranceAutomation.PLDC.StepDefinitions;

[Binding]
public sealed class DuckCreekGeneralSteps
{
    private readonly ScenarioContext _scenario;

    public DuckCreekGeneralSteps(ScenarioContext scenario)
    {
        _scenario = scenario;
    }

    [Given("I open the configured Commercial Lines Duck Creek application")]
    public Task OpenCommercialLinesDuckCreekApplicationAsync()
    {
        var page = new DuckCreekGeneralPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        const string duckCreekUrl = "https://clasq.anico.com/Express/default.aspx";
        _scenario.Get<RunLogger>().Info($"Opening Duck Creek URL: {duckCreekUrl}");

        return page.NavigateAsync(duckCreekUrl);
    }

    [Given("I sign in to Commercial Lines Duck Creek using configured credentials")]
    public async Task SignInToCommercialLinesDuckCreekAsync()
    {
        var page = new DuckCreekGeneralPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
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
        var page = new DuckCreekGeneralPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickQuickSearchAsync();
        await page.SelectSearchFieldAsync("Description");
        await page.SelectSearchOperatorAsync("is");
        await page.EnterSearchValueAsync(description);
        await page.ClickSearchAsync();
        await page.ClickSearchAsync();
    }

    [Given("I click the insured name in the Duck Creek search results")]
    public async Task ClickInsuredNameInSearchResultsAsync()
    {
        var page = new DuckCreekGeneralPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await page.ClickSearchResultInsuredNameAsync();
    }

    [Given("I navigate to the Submission window in Duck Creek")]
    public Task NavigateToSubmissionWindowAsync()
    {
        var page = new DuckCreekGeneralPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        return page.ClickSubmissionAsync();
    }

    [Given("I click Complete Application in Duck Creek")]
    public async Task ClickCompleteApplicationAsync()
    {
        var page = new DuckCreekGeneralPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await page.ClickCompleteApplicationAsync();
        await page.WaitForProcessingCompleteAsync();
        await page.ClickProcessingCompleteCloseAsync();
        await page.ClickApproveAsync();
        await page.WaitForOkButtonAsync();
        await page.ClickOkAsync();
        await page.VerifyApprovedStatusAsync("Approved", "Status");
    }

    [Given("I open the configured Commercial Lines ExpertQuote application")]
    public Task OpenCommercialLinesExpertQuoteApplicationAsync()
    {
        var page = new ApplicationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        const string expertQuoteUrl = "https://expertquote-qa.americannational.com/expertquote/";
        _scenario.Get<RunLogger>().Info($"Opening ExpertQuote URL: {expertQuoteUrl}");

        return page.NavigateAsync(expertQuoteUrl);
    }

    [Given("I sign in to Commercial Lines ExpertQuote using configured credentials")]
    public Task SignInToCommercialLinesExpertQuoteAsync()
    {
        var page = new ApplicationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        const string username = "YDH040";
        const string password = "Anico456";
        return page.SignInAsync(username, password);
    }

    [Given(@"^I capture the quote identity and close the current quote$")]
    [When(@"^I capture the quote identity and close the current quote$")]
    [Then(@"^I capture the quote identity and close the current quote$")]
    public async Task CaptureTheQuoteIdentityAndCloseTheCurrentQuoteAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        // Source captures Name and Quote -> Quote_NameNum, then sets Quote_Num with
        // STRINGREPLACE(Quote_NameNum, LastName, "") before selecting Close Quote.
        data.Set("Quote_NameNum", await page.CaptureNameAndQuoteAsync("InnerText"));
        data.Set("Quote_Num", data.Get("Quote_NameNum")
            .Replace(data.Get("LastName"), string.Empty, StringComparison.OrdinalIgnoreCase)
            .Trim());

        await page.ClickCloseQuoteAsync();
    }

    [Given(@"^I go to submission and transmit the policy$")]
    [When(@"^I go to submission and transmit the policy$")]
    [Then(@"^I go to submission and transmit the policy$")]
    public async Task GoToSubmissionAndTransmitThePolicyAsync()
    {
        var navigationPage = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        var submissionPage = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await navigationPage.NavigateToScreenAsync("Submission");

        //await submissionPage.WaitForTransmitAsync("Exists");
        await submissionPage.ClickTransmitAsync();

        await submissionPage.WaitForPolicyNumberAsync("Exists");
    }

    [Given(@"^I search for the quote description using quick search$")]
    [When(@"^I search for the quote description using quick search$")]
    [Then(@"^I search for the quote description using quick search$")]
    public async Task SearchForTheQuoteDescriptionUsingQuickSearchAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        //await page.WaitForSearchTextAsync("Visible");
        await page.EnterSearchTextSequentiallyAsync(data.Get("Quote_Num"));
        //await page.WaitForQuickSearchButtonAsync("Visible");
        await page.ClickQuickSearchButtonAsync();
        //await page.WaitForSearchMethodEGDescriptionPolicyAsync("Visible");
        await page.EnterSearchMethodEGDescriptionPolicySequentiallyAsync("Description");
        await page.PressSearchMethodEGDescriptionPolicyAsync("Tab");
        //await page.WaitForSearchButtonAsync("Visible");
        await page.ClickSearchButtonAsync();
        //await page.WaitForSearchResultsInsuredNameColumnHeaderAsync("Visible");
        await page.ClickSearchResultInsuredNameLinkAsync();
        //await page.WaitForCommercialAutoQuoteLinkAsync("Visible");
        await page.ClickCommercialAutoQuoteLinkAsync();

        var navigationPage = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        //await navigationPage.WaitForClientLinkAsync("Visible");
        await navigationPage.ClickClientLinkAsync();
        await navigationPage.WaitForClientPageTitleAsync("Visible");
    }
}
