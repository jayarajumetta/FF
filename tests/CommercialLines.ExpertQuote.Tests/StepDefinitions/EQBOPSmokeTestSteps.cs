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
        await page.VerifyClientInfoAsync("Visible", "");
        await page.EnterCustomerNameFirstAsync(data.Resolve("{{runtime:FirstName}}"));
        await page.EnterCustomerNameLastAsync(data.Resolve("{{runtime:LastName}}"));
        await page.EnterCustomerDateOfBirthAsync(data.Resolve("{{data:customer_dateofbirth}}"));
        await page.ClickClientInfoSearchAsync();
        await page.VerifyExistingClientMatchAsync("Exists", "");
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
        await page.VerifyAccountInformationAsync("Visible", "");
        await page.EnterOwnerMiddleNameAsync("");
        await page.ClickMarriedAsync();
        await page.VerifyMapAsync("Exists", "");
        await page.VerifySatelliteAsync("Exists", "");
        await page.ClickYesAsync();
        await page.ClickYesAsync();
        await page.ClickAdditionalInterestsNextAsync();
        await page.EnterStreetAddressAsync(data.Resolve("{{data:street_address_18}}"));
        await page.EnterAddress2Async("");
        await page.EnterCityAsync(data.Resolve("{{data:city_20}}"));
        await page.EnterStateAE19AAsync(data.Resolve("{{data:state_21}}"));
        await page.EnterZipAsync(data.Resolve("{{data:zip_22}}"));

    }

    [Given(@"^I start the configured policy proposal$")]
    [When(@"^I start the configured policy proposal$")]
    [Then(@"^I start the configured policy proposal$")]
    public async Task StartTheConfiguredPolicyProposalAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyProposalDetailsAsync("Visible", "");
        await page.ClickBusinessOwnersAsync();
        await page.PressSearchBusinessNameAsync("ENTER");
        await page.EnterIndividualAsync(data.Resolve("{{data:individual_31}}"));
        await page.ClickIndividuallyOwnedDBAOrTAAsync();
        await page.EnterIndividualDBAAsync(data.Resolve("{{data:individual_dba}}"));
        await page.EnterEffectiveDate6F16BAsync(data.Resolve("{{data:effective_date}}"));
        await page.SetNewAccountAddressAsync(data.Resolve("{{data:new_account_address}}"));
        await page.ClickNoAsync();
        await page.SelectMissouriAsync("");
        await page.EnterAgentPCAsync(data.Resolve("{{data:agentpc}}"));
        data.Set("EffDate", await page.CaptureEffectiveDate6F16BAsync("Value"));
        await page.ClickStartQuoteAsync();
        data.Set("LOB", data.Resolve("{{data:line_of_business}}"));

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
        data.Set("WaitOnTime", data.Resolve("{{data:wait_on_time}}"));
        await page.VerifyTheSSNCouldNotBeFoundPleaseEnterAnSSNAsync("Visible", "");
        await page.EnterTheSSNCouldNotBeFoundPleaseEnterAnSSNAsync(data.Resolve("{{runtime:InsuredSSN}}"));
        await page.VerifyEChecklistEChecklistSubmitAsync("Visible", "");
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
        data.Set("WaitOnTime", data.Resolve("{{data:wait_on_time_2}}"));
        data.Set("Screen", data.Resolve("{{data:required_target_screen}}"));
        await page.EnterPreQualificationAsync(data.Resolve("{{data:prequalification_51}}"));
        if (data.Condition("if the \"Review Required\" popup is displayed and the configured action is \"Keep Going\""))
        {
                    await page.ClickKeepGoingAsync();
        }
        await page.WaitForLoadingAsync("Absent");
        await page.VerifyPreQualificationAsync("Exists", "");

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
        data.Set("Quote_Num", data.Resolve("{{runtime:Quote_NameNum}}"));
        data.Set("Quote_Num", data.Resolve("{{runtime:QuoteID}}"));
        await page.ClickCloseQuoteAsync();

    }

    [Given(@"^I retrieve the quote and verify its identity$")]
    [When(@"^I retrieve the quote and verify its identity$")]
    [Then(@"^I retrieve the quote and verify its identity$")]
    public async Task RetrieveTheQuoteAndVerifyItsIdentityAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new QuoteSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForLoadingAsync("Absent");
        await page.EnterQuoteSearchAsync(data.Resolve("{{runtime:Quote_Num}}"));
        await page.ClickClientInfoSearchAsync();
        await page.WaitForLoadingAsync("Absent");
        data.Set("Screen", data.Resolve("{{data:required_target_screen}}"));
        await page.EnterPreQualificationAsync(data.Resolve("{{data:prequalification_64}}"));
        if (data.Condition("if the \"Review Required\" popup is displayed and the configured action is \"Keep Going\""))
        {
                    await page.ClickKeepGoingAsync();
        }
        await page.WaitForLoadingAsync("Absent");
        await page.VerifyPreQualificationAsync("Exists", "");
        await page.VerifyNameAndQuoteAsync(data.Resolve("{{runtime:Quote_NameNum}}"), "");

    }

}
