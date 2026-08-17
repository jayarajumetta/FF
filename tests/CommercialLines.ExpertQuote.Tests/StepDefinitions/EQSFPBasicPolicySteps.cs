using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLEQ.Pages;

namespace InsuranceAutomation.CLEQ.StepDefinitions;

[Binding, Scope(Feature = "EQ SFP Basic Policy")]
public sealed class EQSFPBasicPolicySteps
{
    private readonly ScenarioContext _scenario;
    public EQSFPBasicPolicySteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I enter client search information$")]
    [When(@"^I enter client search information$")]
    [Then(@"^I enter client search information$")]
    public async Task EnterClientSearchInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("LastName", "FETT[A-Z]{4}");
        data.GenerateRandom("FirstName", "SFP[A-Z]{3}");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.EnterClientSearchInformationAsync4();
    }

    [Given(@"^I create a new client$")]
    [When(@"^I create a new client$")]
    [Then(@"^I create a new client$")]
    public async Task CreateANewClientAsync()
    {
        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CreateANewClientAsync4();
    }

    [Given(@"^I enter account details$")]
    [When(@"^I enter account details$")]
    [Then(@"^I enter account details$")]
    public async Task EnterAccountDetailsAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("OwnerPhone", "3[0-9]{9}");
        data.GenerateRandom("OwnerEmail", "test@[a-z]{4}\\\\.com");

        var page = new AccountInformationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.EnterAccountDetailsAsync4();
    }

    [Given(@"^I start the policy proposal$")]
    [When(@"^I start the policy proposal$")]
    [Then(@"^I start the policy proposal$")]
    public async Task StartThePolicyProposalAsync()
    {
        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.StartThePolicyProposalAsync4();
    }

    [Given(@"^I enter and validate the insured social security number$")]
    [When(@"^I enter and validate the insured social security number$")]
    [Then(@"^I enter and validate the insured social security number$")]
    public async Task EnterAndValidateTheInsuredSocialSecurityNumberAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("InsuredSSN", "025[0-9]{6}");

        var page = new SocialSecurityPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.EnterAndValidateTheInsuredSocialSecurityNumberAsync4();
    }

    [Given(@"^I navigate to the required policy screen$")]
    [When(@"^I navigate to the required policy screen$")]
    [Then(@"^I navigate to the required policy screen$")]
    public async Task NavigateToTheRequiredPolicyScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenAsync5();
    }

    [Given(@"^I complete policy Details \\(Optimized\\)$")]
    [When(@"^I complete policy Details \\(Optimized\\)$")]
    [Then(@"^I complete policy Details \\(Optimized\\)$")]
    public async Task CompletePolicyDetailsOptimizedAsync()
    {
        var page = new PolicyInformationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompletePolicyDetailsOptimizedAsync2();
    }

    [Given(@"^I navigate to the required policy screen for screen$")]
    [When(@"^I navigate to the required policy screen for screen$")]
    [Then(@"^I navigate to the required policy screen for screen$")]
    public async Task NavigateToTheRequiredPolicyScreenForScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForScreenAsync4();
    }

    [Given(@"^I verify None of the Above$")]
    [When(@"^I verify None of the Above$")]
    [Then(@"^I verify None of the Above$")]
    public async Task VerifyNoneOfTheAboveAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.VerifyNoneOfTheAboveAsync2();
    }

    [Given(@"^I navigate to the required policy screen for navigate to screen$")]
    [When(@"^I navigate to the required policy screen for navigate to screen$")]
    [Then(@"^I navigate to the required policy screen for navigate to screen$")]
    public async Task NavigateToTheRequiredPolicyScreenForNavigateToScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForNavigateToScreenAsync3();
    }

    [Given(@"^I enter Required Info$")]
    [When(@"^I enter Required Info$")]
    [Then(@"^I enter Required Info$")]
    public async Task EnterRequiredInfoAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.EnterRequiredInfoAsync3();
    }

    [Given(@"^I navigate to the required policy screen for navigate to correct screen$")]
    [When(@"^I navigate to the required policy screen for navigate to correct screen$")]
    [Then(@"^I navigate to the required policy screen for navigate to correct screen$")]
    public async Task NavigateToTheRequiredPolicyScreenForNavigateToCorrectScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForNavigateToCorrectScreenAsync3();
    }

    [Given(@"^I complete edit Client Roles$")]
    [When(@"^I complete edit Client Roles$")]
    [Then(@"^I complete edit Client Roles$")]
    public async Task CompleteEditClientRolesAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteEditClientRolesAsync3();
    }

    [Given(@"^I navigate to the required policy screen for policy data entry$")]
    [When(@"^I navigate to the required policy screen for policy data entry$")]
    [Then(@"^I navigate to the required policy screen for policy data entry$")]
    public async Task NavigateToTheRequiredPolicyScreenForPolicyDataEntryAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForPolicyDataEntryAsync3();
    }

    [Given(@"^I add/Edit a Narrative and Verify Timestamp$")]
    [When(@"^I add/Edit a Narrative and Verify Timestamp$")]
    [Then(@"^I add/Edit a Narrative and Verify Timestamp$")]
    public async Task AddEditANarrativeAndVerifyTimestampAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddEditANarrativeAndVerifyTimestampAsync3();
    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0118$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0118$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0118$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0118Async()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForSubsequentScreen0118Async2();
    }

    [Given(@"^I enter Required$")]
    [When(@"^I enter Required$")]
    [Then(@"^I enter Required$")]
    public async Task EnterRequiredAsync()
    {
        var page = new LossHistoryPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.EnterRequiredAsync3();
    }

    [Given(@"^I add a Location$")]
    [When(@"^I add a Location$")]
    [Then(@"^I add a Location$")]
    public async Task AddALocationAsync()
    {
        var page = new LocationsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddALocationAsync2();
    }

    [Given(@"^I add a Residence$")]
    [When(@"^I add a Residence$")]
    [Then(@"^I add a Residence$")]
    public async Task AddAResidenceAsync()
    {
        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddAResidenceAsync2();
    }

    [Given(@"^I add Residence Covg$")]
    [When(@"^I add Residence Covg$")]
    [Then(@"^I add Residence Covg$")]
    public async Task AddResidenceCovgAsync()
    {
        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddResidenceCovgAsync2();
    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0174$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0174$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0174$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0174Async()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForSubsequentScreen0174Async2();
    }

    [Given(@"^I enter FPP$")]
    [When(@"^I enter FPP$")]
    [Then(@"^I enter FPP$")]
    public async Task EnterFPPAsync()
    {
        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.EnterFPPAsync();
    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0184$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0184$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0184$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0184Async()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForSubsequentScreen0184Async2();
    }

    [Given(@"^I complete equipment Breakdown and Implements Coverage$")]
    [When(@"^I complete equipment Breakdown and Implements Coverage$")]
    [Then(@"^I complete equipment Breakdown and Implements Coverage$")]
    public async Task CompleteEquipmentBreakdownAndImplementsCoverageAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteEquipmentBreakdownAndImplementsCoverageAsync();
    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0201$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0201$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0201$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0201Async()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForSubsequentScreen0201Async();
    }

    [Given(@"^I add bicycle$")]
    [When(@"^I add bicycle$")]
    [Then(@"^I add bicycle$")]
    public async Task AddBicycleAsync()
    {
        var page = new VehiclesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddBicycleAsync();
    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0215$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0215$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0215$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0215Async()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForSubsequentScreen0215Async();
    }

    [Given(@"^I complete nOT CE$")]
    [When(@"^I complete nOT CE$")]
    [Then(@"^I complete nOT CE$")]
    public async Task CompleteNOTCEAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteNOTCEAsync();
    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0236$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0236$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0236$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0236Async()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForSubsequentScreen0236Async();
    }

    [Given(@"^I complete insurance Score$")]
    [When(@"^I complete insurance Score$")]
    [Then(@"^I complete insurance Score$")]
    public async Task CompleteInsuranceScoreAsync()
    {
        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteInsuranceScoreAsync2();
    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0250$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0250$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0250$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0250Async()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForSubsequentScreen0250Async();
    }

    [Given(@"^I complete mortgagee/Loss Payee Information$")]
    [When(@"^I complete mortgagee/Loss Payee Information$")]
    [Then(@"^I complete mortgagee/Loss Payee Information$")]
    public async Task CompleteMortgageeLossPayeeInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteMortgageeLossPayeeInformationAsync2();
    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0273$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0273$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0273$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0273Async()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForSubsequentScreen0273Async();
    }

    [Given(@"^I verify premium$")]
    [When(@"^I verify premium$")]
    [Then(@"^I verify premium$")]
    public async Task VerifyPremiumAsync()
    {
        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.VerifyPremiumAsync2();
    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0282$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0282$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0282$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0282Async()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForSubsequentScreen0282Async();
    }

    [Given(@"^I open a CLAS Browser and Search for EQ by Description 1$")]
    [When(@"^I open a CLAS Browser and Search for EQ by Description 1$")]
    [Then(@"^I open a CLAS Browser and Search for EQ by Description 1$")]
    public async Task OpenACLASBrowserAndSearchForEQByDescription1Async()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.OpenACLASBrowserAndSearchForEQByDescription1Async2();
    }

    [Given(@"^I complete restart Edge Popup$")]
    [When(@"^I complete restart Edge Popup$")]
    [Then(@"^I complete restart Edge Popup$")]
    public async Task CompleteRestartEdgePopupAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRestartEdgePopupAsync3();
    }

    [Given(@"^I open a CLAS Browser and Search for EQ by Description 1 for username$")]
    [When(@"^I open a CLAS Browser and Search for EQ by Description 1 for username$")]
    [Then(@"^I open a CLAS Browser and Search for EQ by Description 1 for username$")]
    public async Task OpenACLASBrowserAndSearchForEQByDescription1ForUsernameAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.OpenACLASBrowserAndSearchForEQByDescription1ForUsernameAsync2();
    }

    [Given(@"^I sign out of the application$")]
    [When(@"^I sign out of the application$")]
    [Then(@"^I sign out of the application$")]
    public async Task SignOutOfTheApplicationAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SignOutOfTheApplicationAsync3();
    }

    [Given(@"^I open a CLAS Browser and Search for EQ by Description 1 for open a clas browser and search for eq by description 1$")]
    [When(@"^I open a CLAS Browser and Search for EQ by Description 1 for open a clas browser and search for eq by description 1$")]
    [Then(@"^I open a CLAS Browser and Search for EQ by Description 1 for open a clas browser and search for eq by description 1$")]
    public async Task OpenACLASBrowserAndSearchForEQByDescription1ForOpenAClasBrowserAndSearchForEqByDescription1Async()
    {
        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.OpenACLASBrowserAndSearchForEQByDescription1ForOpenAClasBrowserAndSearchForEqByDescription1Async2();
    }

    [Given(@"^I complete forms verification Retrieve QuoteID \\& SessionID by Browser Console$")]
    [When(@"^I complete forms verification Retrieve QuoteID \\& SessionID by Browser Console$")]
    [Then(@"^I complete forms verification Retrieve QuoteID \\& SessionID by Browser Console$")]
    public async Task CompleteFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsoleAsync()
    {
        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsoleAsync2();
    }

    [Given(@"^I complete save for Later/Return to Admin$")]
    [When(@"^I complete save for Later/Return to Admin$")]
    [Then(@"^I complete save for Later/Return to Admin$")]
    public async Task CompleteSaveForLaterReturnToAdminAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteSaveForLaterReturnToAdminAsync3();
    }

}
