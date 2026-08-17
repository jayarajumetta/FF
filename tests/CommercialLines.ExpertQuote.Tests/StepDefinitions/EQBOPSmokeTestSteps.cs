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

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CreateANewClientAndBeginTheQuoteAsync();
    }

    [Given(@"^I enter the client account and address information$")]
    [When(@"^I enter the client account and address information$")]
    [Then(@"^I enter the client account and address information$")]
    public async Task EnterTheClientAccountAndAddressInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("OwnerPhone", "3[0-9]{9}");
        data.GenerateRandom("OwnerEmail", "test@[a-z]{4}.com");

        var page = new AccountInformationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.EnterTheClientAccountAndAddressInformationAsync();
    }

    [Given(@"^I start the configured policy proposal$")]
    [When(@"^I start the configured policy proposal$")]
    [Then(@"^I start the configured policy proposal$")]
    public async Task StartTheConfiguredPolicyProposalAsync()
    {
        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.StartTheConfiguredPolicyProposalAsync();
    }

    [Given(@"^I enter the insured social security number and handle any prefill result$")]
    [When(@"^I enter the insured social security number and handle any prefill result$")]
    [Then(@"^I enter the insured social security number and handle any prefill result$")]
    public async Task EnterTheInsuredSocialSecurityNumberAndHandleAnyPrefillResultAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("InsuredSSN", "025[0-9]{6}");

        var page = new SocialSecurityPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.EnterTheInsuredSocialSecurityNumberAndHandleAnyPrefillResultAsync();
    }

    [Given(@"^I navigate to the required policy screen$")]
    [When(@"^I navigate to the required policy screen$")]
    [Then(@"^I navigate to the required policy screen$")]
    public async Task NavigateToTheRequiredPolicyScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenAsync4();
    }

    [Given(@"^I capture the quote identity and close the current quote$")]
    [When(@"^I capture the quote identity and close the current quote$")]
    [Then(@"^I capture the quote identity and close the current quote$")]
    public async Task CaptureTheQuoteIdentityAndCloseTheCurrentQuoteAsync()
    {
        var page = new QuoteSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CaptureTheQuoteIdentityAndCloseTheCurrentQuoteAsync();
    }

    [Given(@"^I retrieve the quote and verify its identity$")]
    [When(@"^I retrieve the quote and verify its identity$")]
    [Then(@"^I retrieve the quote and verify its identity$")]
    public async Task RetrieveTheQuoteAndVerifyItsIdentityAsync()
    {
        var page = new QuoteSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.RetrieveTheQuoteAndVerifyItsIdentityAsync();
    }

}
