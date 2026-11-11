using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.PLDC.Pages;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.StepDefinitions;

[Binding]
public sealed class CommercialDuckCreekApplicationSteps
{
    private readonly ScenarioContext _scenario;

    public CommercialDuckCreekApplicationSteps(ScenarioContext scenario)
    {
        _scenario = scenario;
    }

    [Given(@"^I click on QA button to logout$")]
    [When(@"^I click on QA button to logout$")]
    [Then(@"^I click on QA button to logout$")]
    public async Task ClickOnQAButtonToLogoutAsync()
    {
        var page = new CommercialDuckCreekPolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        var navigationPage = new CommercialDuckCreekNavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await navigationPage.WaitForHomeLinkAsync("Visible");
        await navigationPage.ClickHomeLinkAsync();
        await page.WaitForUserNameInitialAsync("Visible");
        await Task.Delay(8000);
        await page.ClickUserNameInitialAsync();
        await page.WaitForLogoutAsync("Visible");
        await page.ClickLogoutAsync();
        await Task.Delay(6000);

        if (await page.LogoutOkButtonIsVisibleAsync())
        {
            await page.ClickLogoutOkButtonAsync();
            await page.WaitForLogoutOkButtonAsync("Hidden");
            await page.WaitForUserNameInitialAsync("Visible");
            await Task.Delay(8000);
            await page.ClickUserNameInitialAsync();
            await page.WaitForLogoutAsync("Visible");
            await page.ClickLogoutAsync();
            await Task.Delay(6000);
        }
    }

    [Given(@"^I search for the quote description using quick search$")]
    [When(@"^I search for the quote description using quick search$")]
    [Then(@"^I search for the quote description using quick search$")]
    public async Task SearchForTheQuoteDescriptionUsingQuickSearchAsync()
    {
        var page = new CommercialDuckCreekPolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForSearchTextAsync("Visible");
        await page.EnterSearchTextSequentiallyAsync("AL BAP STRAIGHTTHROUGH 03.13.25 15:03");
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

        var navigationPage = new CommercialDuckCreekNavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        if (await navigationPage.IsClientLinkVisibleAsync())
        {
            await navigationPage.ClickClientLinkAsync();
            await navigationPage.WaitForClientPageTitleAsync("Visible");
        }
    }

    [Given(@"^I capture the quote identity and close the current quote$")]
    [When(@"^I capture the quote identity and close the current quote$")]
    [Then(@"^I capture the quote identity and close the current quote$")]
    public async Task CaptureTheQuoteIdentityAndCloseTheCurrentQuoteAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        var page = new ExpertQuoteQuoteSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await Task.Delay(9000);
        data.Set("Quote_NameNum", await page.CaptureNameAndQuoteAsync("InnerText"));

        var quoteNameNum = data.Get("Quote_NameNum");
        var lastName = data.Get("LastName");
        if (string.IsNullOrEmpty(lastName))
            lastName = data.Get("Last Name");

        var quoteNum = string.IsNullOrEmpty(lastName)
            ? quoteNameNum
            : quoteNameNum.Replace(lastName, string.Empty, StringComparison.OrdinalIgnoreCase);
        data.Set("Quote_Num", quoteNum.Trim());

        await page.ClickCloseQuoteAsync();
        await Task.Delay(5000);
    }

    [Given(@"^I retrieve the quote and verify its identity$")]
    [When(@"^I retrieve the quote and verify its identity$")]
    [Then(@"^I retrieve the quote and verify its identity$")]
    public async Task RetrieveTheQuoteAndVerifyItsIdentityAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        var page = new ExpertQuoteQuoteSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await Task.Delay(5000);
        await page.EnterQuoteSearchAsync(data.Resolve("{{runtime:Quote_Num}}"));
        await Task.Delay(5000);
        await page.ClickQuoteSearchAsync();
        await Task.Delay(5000);

        var screen = "PreQualification";

        var ui = _scenario.Get<UiActions>();
        var screenHeadingLocator = new ExpertQuoteQuoteSearchLocators(_scenario.Get<BrowserSession>().Page).GetScreenHeading(screen);
        var isAlreadyOnScreen = await ui.ExistsAsync(screenHeadingLocator);

        if (!isAlreadyOnScreen)
        {
            await page.NavigateToScreenAsync(screen);
            if (await page.IsKeepGoingPresentAsync())
                await page.ClickKeepGoingAsync();
        }

        await Task.Delay(5000);
        await page.VerifyScreenAsync(screen);
    }
}
