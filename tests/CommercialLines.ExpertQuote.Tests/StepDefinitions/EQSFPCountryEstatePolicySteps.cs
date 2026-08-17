using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLEQ.Pages;

namespace InsuranceAutomation.CLEQ.StepDefinitions;

[Binding, Scope(Feature = "EQ SFP Country Estate Policy")]
public sealed class EQSFPCountryEstatePolicySteps
{
    private readonly ScenarioContext _scenario;
    public EQSFPCountryEstatePolicySteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I enter client search information$")]
    [When(@"^I enter client search information$")]
    [Then(@"^I enter client search information$")]
    public async Task EnterClientSearchInformationAsync()
    {
        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.EnterClientSearchInformationAsync();
    }

    [Given(@"^I create a new client$")]
    [When(@"^I create a new client$")]
    [Then(@"^I create a new client$")]
    public async Task CreateANewClientAsync()
    {
        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CreateANewClientAsync();
    }

    [Given(@"^I enter account details$")]
    [When(@"^I enter account details$")]
    [Then(@"^I enter account details$")]
    public async Task EnterAccountDetailsAsync()
    {
        var page = new AccountInformationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.EnterAccountDetailsAsync();
    }

    [Given(@"^I start the policy proposal$")]
    [When(@"^I start the policy proposal$")]
    [Then(@"^I start the policy proposal$")]
    public async Task StartThePolicyProposalAsync()
    {
        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.StartThePolicyProposalAsync();
    }

    [Given(@"^I enter and validate the insured social security number$")]
    [When(@"^I enter and validate the insured social security number$")]
    [Then(@"^I enter and validate the insured social security number$")]
    public async Task EnterAndValidateTheInsuredSocialSecurityNumberAsync()
    {
        var page = new SocialSecurityPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.EnterAndValidateTheInsuredSocialSecurityNumberAsync();
    }

    [Given(@"^I navigate to the required policy screen$")]
    [When(@"^I navigate to the required policy screen$")]
    [Then(@"^I navigate to the required policy screen$")]
    public async Task NavigateToTheRequiredPolicyScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.NavigateToTheRequiredPolicyScreenAsync();
    }

    [Given(@"^I complete policy Details \\(Optimized\\)$")]
    [When(@"^I complete policy Details \\(Optimized\\)$")]
    [Then(@"^I complete policy Details \\(Optimized\\)$")]
    public async Task CompletePolicyDetailsOptimizedAsync()
    {
        var page = new PolicyInformationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompletePolicyDetailsOptimizedAsync();
    }

    [Given(@"^I navigate to the required policy screen for screen$")]
    [When(@"^I navigate to the required policy screen for screen$")]
    [Then(@"^I navigate to the required policy screen for screen$")]
    public async Task NavigateToTheRequiredPolicyScreenForScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.NavigateToTheRequiredPolicyScreenForScreenAsync();
    }

    [Given(@"^I verify None of the Above$")]
    [When(@"^I verify None of the Above$")]
    [Then(@"^I verify None of the Above$")]
    public async Task VerifyNoneOfTheAboveAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.VerifyNoneOfTheAboveAsync();
    }

    [Given(@"^I navigate to the required policy screen for navigate to screen$")]
    [When(@"^I navigate to the required policy screen for navigate to screen$")]
    [Then(@"^I navigate to the required policy screen for navigate to screen$")]
    public async Task NavigateToTheRequiredPolicyScreenForNavigateToScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.NavigateToTheRequiredPolicyScreenForNavigateToScreenAsync();
    }

    [Given(@"^I enter Required Info$")]
    [When(@"^I enter Required Info$")]
    [Then(@"^I enter Required Info$")]
    public async Task EnterRequiredInfoAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.EnterRequiredInfoAsync();
    }

    [Given(@"^I navigate to the required policy screen for navigate to correct screen$")]
    [When(@"^I navigate to the required policy screen for navigate to correct screen$")]
    [Then(@"^I navigate to the required policy screen for navigate to correct screen$")]
    public async Task NavigateToTheRequiredPolicyScreenForNavigateToCorrectScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.NavigateToTheRequiredPolicyScreenForNavigateToCorrectScreenAsync();
    }

    [Given(@"^I complete edit Client Roles$")]
    [When(@"^I complete edit Client Roles$")]
    [Then(@"^I complete edit Client Roles$")]
    public async Task CompleteEditClientRolesAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteEditClientRolesAsync();
    }

    [Given(@"^I navigate to the required policy screen for policy data entry$")]
    [When(@"^I navigate to the required policy screen for policy data entry$")]
    [Then(@"^I navigate to the required policy screen for policy data entry$")]
    public async Task NavigateToTheRequiredPolicyScreenForPolicyDataEntryAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.NavigateToTheRequiredPolicyScreenForPolicyDataEntryAsync();
    }

    [Given(@"^I add/Edit a Narrative and Verify Timestamp$")]
    [When(@"^I add/Edit a Narrative and Verify Timestamp$")]
    [Then(@"^I add/Edit a Narrative and Verify Timestamp$")]
    public async Task AddEditANarrativeAndVerifyTimestampAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddEditANarrativeAndVerifyTimestampAsync();
    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0118$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0118$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0118$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0118Async()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.NavigateToTheRequiredPolicyScreenForSubsequentScreen0118Async();
    }

    [Given(@"^I enter Required$")]
    [When(@"^I enter Required$")]
    [Then(@"^I enter Required$")]
    public async Task EnterRequiredAsync()
    {
        var page = new LossHistoryPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.EnterRequiredAsync();
    }

    [Given(@"^I add a Location$")]
    [When(@"^I add a Location$")]
    [Then(@"^I add a Location$")]
    public async Task AddALocationAsync()
    {
        var page = new LocationsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddALocationAsync();
    }

    [Given(@"^I add a Residence$")]
    [When(@"^I add a Residence$")]
    [Then(@"^I add a Residence$")]
    public async Task AddAResidenceAsync()
    {
        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddAResidenceAsync();
    }

    [Given(@"^I add Residence Covg$")]
    [When(@"^I add Residence Covg$")]
    [Then(@"^I add Residence Covg$")]
    public async Task AddResidenceCovgAsync()
    {
        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddResidenceCovgAsync();
    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0174$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0174$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0174$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0174Async()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.NavigateToTheRequiredPolicyScreenForSubsequentScreen0174Async();
    }

    [Given(@"^I complete policy\\-wide$")]
    [When(@"^I complete policy\\-wide$")]
    [Then(@"^I complete policy\\-wide$")]
    public async Task CompletePolicyWideAsync()
    {
        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompletePolicyWideAsync();
    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0184$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0184$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0184$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0184Async()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.NavigateToTheRequiredPolicyScreenForSubsequentScreen0184Async();
    }

    [Given(@"^I complete insurance Score$")]
    [When(@"^I complete insurance Score$")]
    [Then(@"^I complete insurance Score$")]
    public async Task CompleteInsuranceScoreAsync()
    {
        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteInsuranceScoreAsync();
    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0198$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0198$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0198$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0198Async()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.NavigateToTheRequiredPolicyScreenForSubsequentScreen0198Async();
    }

    [Given(@"^I complete mortgagee/Loss Payee Information$")]
    [When(@"^I complete mortgagee/Loss Payee Information$")]
    [Then(@"^I complete mortgagee/Loss Payee Information$")]
    public async Task CompleteMortgageeLossPayeeInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteMortgageeLossPayeeInformationAsync();
    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0221$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0221$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0221$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0221Async()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.NavigateToTheRequiredPolicyScreenForSubsequentScreen0221Async();
    }

    [Given(@"^I verify premium$")]
    [When(@"^I verify premium$")]
    [Then(@"^I verify premium$")]
    public async Task VerifyPremiumAsync()
    {
        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.VerifyPremiumAsync();
    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0230$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0230$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0230$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0230Async()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.NavigateToTheRequiredPolicyScreenForSubsequentScreen0230Async();
    }

    [Given(@"^I open a CLAS Browser and Search for EQ by Description 1$")]
    [When(@"^I open a CLAS Browser and Search for EQ by Description 1$")]
    [Then(@"^I open a CLAS Browser and Search for EQ by Description 1$")]
    public async Task OpenACLASBrowserAndSearchForEQByDescription1Async()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.OpenACLASBrowserAndSearchForEQByDescription1Async();
    }

    [Given(@"^I complete restart Edge Popup$")]
    [When(@"^I complete restart Edge Popup$")]
    [Then(@"^I complete restart Edge Popup$")]
    public async Task CompleteRestartEdgePopupAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRestartEdgePopupAsync();
    }

    [Given(@"^I open a CLAS Browser and Search for EQ by Description 1 for username$")]
    [When(@"^I open a CLAS Browser and Search for EQ by Description 1 for username$")]
    [Then(@"^I open a CLAS Browser and Search for EQ by Description 1 for username$")]
    public async Task OpenACLASBrowserAndSearchForEQByDescription1ForUsernameAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.OpenACLASBrowserAndSearchForEQByDescription1ForUsernameAsync();
    }

    [Given(@"^I sign out of the application$")]
    [When(@"^I sign out of the application$")]
    [Then(@"^I sign out of the application$")]
    public async Task SignOutOfTheApplicationAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.SignOutOfTheApplicationAsync();
    }

    [Given(@"^I open a CLAS Browser and Search for EQ by Description 1 for open a clas browser and search for eq by description 1$")]
    [When(@"^I open a CLAS Browser and Search for EQ by Description 1 for open a clas browser and search for eq by description 1$")]
    [Then(@"^I open a CLAS Browser and Search for EQ by Description 1 for open a clas browser and search for eq by description 1$")]
    public async Task OpenACLASBrowserAndSearchForEQByDescription1ForOpenAClasBrowserAndSearchForEqByDescription1Async()
    {
        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.OpenACLASBrowserAndSearchForEQByDescription1ForOpenAClasBrowserAndSearchForEqByDescription1Async();
    }

    [Given(@"^I complete forms verification for EQ in CLAS$")]
    [When(@"^I complete forms verification for EQ in CLAS$")]
    [Then(@"^I complete forms verification for EQ in CLAS$")]
    public async Task CompleteFormsVerificationForEQInCLASAsync()
    {
        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteFormsVerificationForEQInCLASAsync();
    }

    [Given(@"^I complete save for Later/Return to Admin$")]
    [When(@"^I complete save for Later/Return to Admin$")]
    [Then(@"^I complete save for Later/Return to Admin$")]
    public async Task CompleteSaveForLaterReturnToAdminAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteSaveForLaterReturnToAdminAsync();
    }

}