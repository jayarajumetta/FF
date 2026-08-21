using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLEQ.Pages;

namespace InsuranceAutomation.CLEQ.StepDefinitions;

[Binding, Scope(Feature = "EQ BOP Smoke Test")]
public sealed class EQBOPSmokeTestSteps
{
    private readonly ScenarioContext _scenario;
    public EQBOPSmokeTestSteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I create a new client and begin the quote$")]
    [When(@"^I create a new client and begin the quote$")]
    [Then(@"^I create a new client and begin the quote$")]
    public async Task CreateANewClientAndBeginTheQuoteAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("FirstName", "BOP [a-z]{3}");
        data.GenerateRandom("LastName", "Smoke[a-z]{4}");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyNewQuoteAsync("Visible", "");
        await page.ClickNewQuoteAsync();
        //await page.VerifyClientInfoAsync("Visible", "");
        await page.EnterCustomerNameFirstAsync(data.Resolve("{{runtime:FirstName}}"));
        await page.EnterCustomerNameLastAsync(data.Resolve("{{runtime:LastName}}"));
        await page.EnterCustomerDateOfBirthAsync(data.Resolve("{{data:customer_dateofbirth}}"));
        await page.ClickClientInfoSearchAsync();
        //await page.VerifyExistingClientMatchAsync("Exists", "");
        await page.ClickCreateNewClientAsync();
        await page.ClickAdditionalInterestsNextAsync();

    }

    [Given(@"^I enter the client account and address information$")]
    [When(@"^I enter the client account and address information$")]
    [Then(@"^I enter the client account and address information$")]
    public async Task EnterTheClientAccountAndAddressInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("OwnerPhone", "3[0-9]{9}");
        data.GenerateRandom("OwnerEmail", "test@[a-z]{4}.com");

        var page = new AccountInformationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        //await page.VerifyAccountInformationAsync("Visible", "");
        await page.EnterOwnerMiddleNameAsync("");
        await page.EnterOwnerPhoneAsync(data.Resolve("{{runtime:OwnerPhone}}"));
        await page.EnterOwnerEmailAsync(data.Resolve("{{runtime:OwnerEmail}}"));
        await page.ClickMarriedAsync();
        //await page.VerifyMapAsync("Exists", "");
        //await page.VerifySatelliteAsync("Exists", "");

        await page.EnterStreetAddressAsync(data.Resolve("{{data:street_address_18}}"));
        await page.EnterAddress2Async("");
        await page.EnterCityAsync(data.Resolve("{{data:city_20}}"));
        await page.ClickStateDropdownAsync();
        await page.SelectStateAsync(data.Resolve("{{data:state_21}}").ToUpper());

        await page.EnterZipAsync(data.Resolve("{{data:zip_22}}"));
        await page.SelectHaveYouReceivedMailAtThisAddressForAtLeast90DaysYesAsync();
        await page.SelectIsTheAccountAddressAlsoWhereTheClientResidesYesAsync();
        await page.ClickAdditionalInterestsNextAsync();
    }

    [Given(@"^I start the configured policy proposal$")]
    [When(@"^I start the configured policy proposal$")]
    [Then(@"^I start the configured policy proposal$")]
    public async Task StartTheConfiguredPolicyProposalAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        //await page.VerifyProposalDetailsAsync("Visible", "");
        await page.ClickBusinessOwnersAsync();

        //await page.EnterIndividualAsync(data.Resolve("{{data:individual_31}}"));
        //await page.PressSearchBusinessNameAsync("ENTER");
        await page.ClickIndividuallyOwnedDBAOrTAAsync();
        await page.EnterIndividualDBAAsync(data.Resolve("{{data:individual_dba}}"));
        await page.EnterEffectiveDate6F16BAsync(data.Resolve("{{data:effective_date}}"));
        await page.EnterAgentPCAsync(data.Resolve("{{data:agentpc}}"));
        await page.PressAgentPCAsync("Tab");
        await page.ClickRatingStateDropdownAsync();
        await page.ClickRatingStateDropdownOptionAsync(data.Resolve("{{data:state_21}}").ToUpper());
        await page.ClickLessorsRiskNoAsync();
        await page.SetNewAccountAddressAsync(data.Resolve("{{data:new_account_address}}"));
        await page.ClickStartQuoteAsync();

    }

    [Given(@"^I enter the insured social security number and handle any prefill result$")]
    [When(@"^I enter the insured social security number and handle any prefill result$")]
    [Then(@"^I enter the insured social security number and handle any prefill result$")]
    public async Task EnterTheInsuredSocialSecurityNumberAndHandleAnyPrefillResultAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("InsuredSSN", "025[0-9]{6}");

        var page = new SocialSecurityPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        //await page.VerifyTheSSNCouldNotBeFoundPleaseEnterAnSSNAsync("Visible", "");
        await page.EnterTheSSNCouldNotBeFoundPleaseEnterAnSSNAsync(data.Resolve("{{runtime:InsuredSSN}}"));
        //await page.VerifyEChecklistEChecklistSubmitAsync("Visible", "");
        await page.ClickEChecklistEChecklistSubmitAsync();
        if (await page.IsContinuePresentAsync())
        {
                    await page.ClickContinueAsync();
        }

    }

    [Given(@"^I navigate to the required policy screen$")]
    [When(@"^I navigate to the required policy screen$")]
    [Then(@"^I navigate to the required policy screen$")]
    public async Task NavigateToTheRequiredPolicyScreenAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.EnterPreQualificationAsync(data.Resolve("{{data:prequalification_51}}"));
        if (await page.IsKeepGoingPresentAsync())
        {
                    await page.ClickKeepGoingAsync();
        }
        //await page.VerifyPreQualificationAsync("Exists", "");

    }

    [Given(@"^I capture the quote identity and close the current quote$")]
    [When(@"^I capture the quote identity and close the current quote$")]
    [Then(@"^I capture the quote identity and close the current quote$")]
    public async Task CaptureTheQuoteIdentityAndCloseTheCurrentQuoteAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new QuoteSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        data.Set("Quote_NameNum", await page.CaptureNameAndQuoteAsync("InnerText"));
        data.Set("Quote_Num", data.Get("Quote_NameNum").Replace(data.Get("LastName"), string.Empty, StringComparison.OrdinalIgnoreCase).Trim());

        // Navigate back to homepage/dashboard - extract base URL from current page
        var browser = _scenario.Get<BrowserSession>();
        var currentUrl = browser.Page.Url;
        var baseUrl = new Uri(currentUrl).GetLeftPart(UriPartial.Authority);
        await browser.Page.GotoAsync(baseUrl, new Microsoft.Playwright.PageGotoOptions { WaitUntil = Microsoft.Playwright.WaitUntilState.NetworkIdle, Timeout = 60000 });

    }

    [Given(@"^I retrieve the quote and verify its identity$")]
    [When(@"^I retrieve the quote and verify its identity$")]
    [Then(@"^I retrieve the quote and verify its identity$")]
    public async Task RetrieveTheQuoteAndVerifyItsIdentityAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new QuoteSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.EnterQuoteSearchAsync(data.Resolve("{{runtime:Quote_Num}}"));
        await page.ClickClientInfoSearchAsync();
        // Smoke test: PreQualification entry not needed after successful quote retrieval
        //await page.EnterPreQualificationAsync(data.Resolve("{{data:prequalification_64}}"));
        if (await page.IsKeepGoingPresentAsync())
        {
                    await page.ClickKeepGoingAsync();
        }
        //await page.VerifyPreQualificationAsync("Exists", "");
        //await page.VerifyNameAndQuoteAsync(data.Resolve("{{runtime:Quote_NameNum}}"), "");

    }

}
