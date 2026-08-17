using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLEQ.Pages;

namespace InsuranceAutomation.CLEQ.StepDefinitions;

[Binding, Scope(Feature = "EQ BOP Basic Policy")]
public sealed class EQBOPBasicPolicySteps
{
    private readonly ScenarioContext _scenario;
    public EQBOPBasicPolicySteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I enter client search information$")]
    [When(@"^I enter client search information$")]
    [Then(@"^I enter client search information$")]
    public async Task EnterClientSearchInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("LastName", "BASIC[A-Z]{4}");
        data.GenerateRandom("FirstName", "BOP[a-z]{3}");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.EnterClientSearchInformationAsync3();
    }

    [Given(@"^I create a new client$")]
    [When(@"^I create a new client$")]
    [Then(@"^I create a new client$")]
    public async Task CreateANewClientAsync()
    {
        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CreateANewClientAsync3();
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
        await page.EnterAccountDetailsAsync3();
    }

    [Given(@"^I start the policy proposal$")]
    [When(@"^I start the policy proposal$")]
    [Then(@"^I start the policy proposal$")]
    public async Task StartThePolicyProposalAsync()
    {
        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.StartThePolicyProposalAsync3();
    }

    [Given(@"^I enter and validate the insured social security number$")]
    [When(@"^I enter and validate the insured social security number$")]
    [Then(@"^I enter and validate the insured social security number$")]
    public async Task EnterAndValidateTheInsuredSocialSecurityNumberAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("InsuredSSN", "025[0-9]{6}");

        var page = new SocialSecurityPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.EnterAndValidateTheInsuredSocialSecurityNumberAsync3();
    }

    [Given(@"^I navigate to the required policy screen$")]
    [When(@"^I navigate to the required policy screen$")]
    [Then(@"^I navigate to the required policy screen$")]
    public async Task NavigateToTheRequiredPolicyScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenAsync3();
    }

    [Given(@"^I complete industry Class Code Restrictions$")]
    [When(@"^I complete industry Class Code Restrictions$")]
    [Then(@"^I complete industry Class Code Restrictions$")]
    public async Task CompleteIndustryClassCodeRestrictionsAsync()
    {
        var page = new BusinessClassificationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteIndustryClassCodeRestrictionsAsync();
    }

    [Given(@"^I navigate to the required policy screen for screen$")]
    [When(@"^I navigate to the required policy screen for screen$")]
    [Then(@"^I navigate to the required policy screen for screen$")]
    public async Task NavigateToTheRequiredPolicyScreenForScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForScreenAsync3();
    }

    [Given(@"^I enter Required Info$")]
    [When(@"^I enter Required Info$")]
    [Then(@"^I enter Required Info$")]
    public async Task EnterRequiredInfoAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.EnterRequiredInfoAsync2();
    }

    [Given(@"^I complete general UW Questions$")]
    [When(@"^I complete general UW Questions$")]
    [Then(@"^I complete general UW Questions$")]
    public async Task CompleteGeneralUWQuestionsAsync()
    {
        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteGeneralUWQuestionsAsync();
    }

    [Given(@"^I complete industry Class Code Questions$")]
    [When(@"^I complete industry Class Code Questions$")]
    [Then(@"^I complete industry Class Code Questions$")]
    public async Task CompleteIndustryClassCodeQuestionsAsync()
    {
        var page = new BusinessClassificationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteIndustryClassCodeQuestionsAsync();
    }

    [Given(@"^I navigate to the required policy screen for navigate to screen$")]
    [When(@"^I navigate to the required policy screen for navigate to screen$")]
    [Then(@"^I navigate to the required policy screen for navigate to screen$")]
    public async Task NavigateToTheRequiredPolicyScreenForNavigateToScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForNavigateToScreenAsync2();
    }

    [Given(@"^I complete edit Client Roles$")]
    [When(@"^I complete edit Client Roles$")]
    [Then(@"^I complete edit Client Roles$")]
    public async Task CompleteEditClientRolesAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteEditClientRolesAsync2();
    }

    [Given(@"^I navigate to the required policy screen for navigate to correct screen$")]
    [When(@"^I navigate to the required policy screen for navigate to correct screen$")]
    [Then(@"^I navigate to the required policy screen for navigate to correct screen$")]
    public async Task NavigateToTheRequiredPolicyScreenForNavigateToCorrectScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForNavigateToCorrectScreenAsync2();
    }

    [Given(@"^I add/Edit a Narrative and Verify Timestamp$")]
    [When(@"^I add/Edit a Narrative and Verify Timestamp$")]
    [Then(@"^I add/Edit a Narrative and Verify Timestamp$")]
    public async Task AddEditANarrativeAndVerifyTimestampAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddEditANarrativeAndVerifyTimestampAsync2();
    }

    [Given(@"^I navigate to the required policy screen for policy data entry$")]
    [When(@"^I navigate to the required policy screen for policy data entry$")]
    [Then(@"^I navigate to the required policy screen for policy data entry$")]
    public async Task NavigateToTheRequiredPolicyScreenForPolicyDataEntryAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForPolicyDataEntryAsync2();
    }

    [Given(@"^I enter Required$")]
    [When(@"^I enter Required$")]
    [Then(@"^I enter Required$")]
    public async Task EnterRequiredAsync()
    {
        var page = new LossHistoryPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.EnterRequiredAsync2();
    }

    [Given(@"^I add/Verify/Delete Claims$")]
    [When(@"^I add/Verify/Delete Claims$")]
    [Then(@"^I add/Verify/Delete Claims$")]
    public async Task AddVerifyDeleteClaimsAsync()
    {
        var page = new LossHistoryPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddVerifyDeleteClaimsAsync();
    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0143$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0143$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0143$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0143Async()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForSubsequentScreen0143Async();
    }

    [Given(@"^I complete edit a Location$")]
    [When(@"^I complete edit a Location$")]
    [Then(@"^I complete edit a Location$")]
    public async Task CompleteEditALocationAsync()
    {
        var page = new LocationsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteEditALocationAsync();
    }

    [Given(@"^I add a Building Button$")]
    [When(@"^I add a Building Button$")]
    [Then(@"^I add a Building Button$")]
    public async Task AddABuildingButtonAsync()
    {
        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddABuildingButtonAsync();
    }

    [Given(@"^I select Own or rent and Building SQ Footage Basic$")]
    [When(@"^I select Own or rent and Building SQ Footage Basic$")]
    [Then(@"^I select Own or rent and Building SQ Footage Basic$")]
    public async Task SelectOwnOrRentAndBuildingSQFootageBasicAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SelectOwnOrRentAndBuildingSQFootageBasicAsync();
    }

    [Given(@"^I select Additional Coverages \\- Building, Functional Personal Property or Habitational$")]
    [When(@"^I select Additional Coverages \\- Building, Functional Personal Property or Habitational$")]
    [Then(@"^I select Additional Coverages \\- Building, Functional Personal Property or Habitational$")]
    public async Task SelectAdditionalCoveragesBuildingFunctionalPersonalPropertyOrHabitationalAsync()
    {
        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SelectAdditionalCoveragesBuildingFunctionalPersonalPropertyOrHabitationalAsync();
    }

    [Given(@"^I select Occupancy SQ Footage$")]
    [When(@"^I select Occupancy SQ Footage$")]
    [Then(@"^I select Occupancy SQ Footage$")]
    public async Task SelectOccupancySQFootageAsync()
    {
        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SelectOccupancySQFootageAsync();
    }

    [Given(@"^I enter supplimental data\\- for class$")]
    [When(@"^I enter supplimental data\\- for class$")]
    [Then(@"^I enter supplimental data\\- for class$")]
    public async Task EnterSupplimentalDataForClassAsync()
    {
        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.EnterSupplimentalDataForClassAsync();
    }

    [Given(@"^I select Cost Estimator \\& Calculate Valuations$")]
    [When(@"^I select Cost Estimator \\& Calculate Valuations$")]
    [Then(@"^I select Cost Estimator \\& Calculate Valuations$")]
    public async Task SelectCostEstimatorCalculateValuationsAsync()
    {
        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SelectCostEstimatorCalculateValuationsAsync();
    }

    [Given(@"^I select Building Detail Fields$")]
    [When(@"^I select Building Detail Fields$")]
    [Then(@"^I select Building Detail Fields$")]
    public async Task SelectBuildingDetailFieldsAsync()
    {
        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SelectBuildingDetailFieldsAsync();
    }

    [Given(@"^I select Heating Sources$")]
    [When(@"^I select Heating Sources$")]
    [Then(@"^I select Heating Sources$")]
    public async Task SelectHeatingSourcesAsync()
    {
        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SelectHeatingSourcesAsync();
    }

    [Given(@"^I complete extra Property Risk$")]
    [When(@"^I complete extra Property Risk$")]
    [Then(@"^I complete extra Property Risk$")]
    public async Task CompleteExtraPropertyRiskAsync()
    {
        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteExtraPropertyRiskAsync();
    }

    [Given(@"^I answer Building Eligibility Questions$")]
    [When(@"^I answer Building Eligibility Questions$")]
    [Then(@"^I answer Building Eligibility Questions$")]
    public async Task AnswerBuildingEligibilityQuestionsAsync()
    {
        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AnswerBuildingEligibilityQuestionsAsync();
    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0266$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0266$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0266$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0266Async()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForSubsequentScreen0266Async();
    }

    [Given(@"^I answer EPLI Questions$")]
    [When(@"^I answer EPLI Questions$")]
    [Then(@"^I answer EPLI Questions$")]
    public async Task AnswerEPLIQuestionsAsync()
    {
        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AnswerEPLIQuestionsAsync();
    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0285$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0285$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0285$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0285Async()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForSubsequentScreen0285Async();
    }

    [Given(@"^I complete billing Account Setup$")]
    [When(@"^I complete billing Account Setup$")]
    [Then(@"^I complete billing Account Setup$")]
    public async Task CompleteBillingAccountSetupAsync()
    {
        var page = new BillingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteBillingAccountSetupAsync();
    }

    [Given(@"^I complete future Payment Plan 1$")]
    [When(@"^I complete future Payment Plan 1$")]
    [Then(@"^I complete future Payment Plan 1$")]
    public async Task CompleteFuturePaymentPlan1Async()
    {
        var page = new BillingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteFuturePaymentPlan1Async();
    }

    [Given(@"^I complete initial Payment$")]
    [When(@"^I complete initial Payment$")]
    [Then(@"^I complete initial Payment$")]
    public async Task CompleteInitialPaymentAsync()
    {
        var page = new BillingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteInitialPaymentAsync();
    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0310$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0310$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0310$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0310Async()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForSubsequentScreen0310Async();
    }

    [Given(@"^I complete insurance Score and premium Verification$")]
    [When(@"^I complete insurance Score and premium Verification$")]
    [Then(@"^I complete insurance Score and premium Verification$")]
    public async Task CompleteInsuranceScoreAndPremiumVerificationAsync()
    {
        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteInsuranceScoreAndPremiumVerificationAsync();
    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0336$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0336$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0336$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0336Async()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForSubsequentScreen0336Async();
    }

    [Given(@"^I open EQ in Browser$")]
    [When(@"^I open EQ in Browser$")]
    [Then(@"^I open EQ in Browser$")]
    public async Task OpenEQInBrowserAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.OpenEQInBrowserAsync();
    }

    [Given(@"^I complete restart Edge Popup$")]
    [When(@"^I complete restart Edge Popup$")]
    [Then(@"^I complete restart Edge Popup$")]
    public async Task CompleteRestartEdgePopupAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRestartEdgePopupAsync2();
    }

    [Given(@"^I open EQ in Browser for logout$")]
    [When(@"^I open EQ in Browser for logout$")]
    [Then(@"^I open EQ in Browser for logout$")]
    public async Task OpenEQInBrowserForLogoutAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.OpenEQInBrowserForLogoutAsync();
    }

    [Given(@"^I sign in to ExpertQuote$")]
    [When(@"^I sign in to ExpertQuote$")]
    [Then(@"^I sign in to ExpertQuote$")]
    public async Task SignInToExpertQuoteAsync()
    {
        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SignInToExpertQuoteAsync();
    }

    [Given(@"^I search by QuoteNum$")]
    [When(@"^I search by QuoteNum$")]
    [Then(@"^I search by QuoteNum$")]
    public async Task SearchByQuoteNumAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SearchByQuoteNumAsync2();
    }

    [Given(@"^I search Results Table$")]
    [When(@"^I search Results Table$")]
    [Then(@"^I search Results Table$")]
    public async Task SearchResultsTableAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SearchResultsTableAsync();
    }

    [Given(@"^I open a CLAS Browser and Search for EQ by Description$")]
    [When(@"^I open a CLAS Browser and Search for EQ by Description$")]
    [Then(@"^I open a CLAS Browser and Search for EQ by Description$")]
    public async Task OpenACLASBrowserAndSearchForEQByDescriptionAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.OpenACLASBrowserAndSearchForEQByDescriptionAsync();
    }

    [Given(@"^I sign out of the application$")]
    [When(@"^I sign out of the application$")]
    [Then(@"^I sign out of the application$")]
    public async Task SignOutOfTheApplicationAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SignOutOfTheApplicationAsync2();
    }

    [Given(@"^I open a CLAS Browser and Search for EQ by Description for cl dc$")]
    [When(@"^I open a CLAS Browser and Search for EQ by Description for cl dc$")]
    [Then(@"^I open a CLAS Browser and Search for EQ by Description for cl dc$")]
    public async Task OpenACLASBrowserAndSearchForEQByDescriptionForClDcAsync()
    {
        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.OpenACLASBrowserAndSearchForEQByDescriptionForClDcAsync();
    }

    [Given(@"^I search by Desc in DC$")]
    [When(@"^I search by Desc in DC$")]
    [Then(@"^I search by Desc in DC$")]
    public async Task SearchByDescInDCAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SearchByDescInDCAsync();
    }

    [Given(@"^I open a CLAS Browser and Search for EQ by Description for view policy$")]
    [When(@"^I open a CLAS Browser and Search for EQ by Description for view policy$")]
    [Then(@"^I open a CLAS Browser and Search for EQ by Description for view policy$")]
    public async Task OpenACLASBrowserAndSearchForEQByDescriptionForViewPolicyAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.OpenACLASBrowserAndSearchForEQByDescriptionForViewPolicyAsync();
    }

    [Given(@"^I complete forms verification Retrieve QuoteID \\& SessionID by Browser Console$")]
    [When(@"^I complete forms verification Retrieve QuoteID \\& SessionID by Browser Console$")]
    [Then(@"^I complete forms verification Retrieve QuoteID \\& SessionID by Browser Console$")]
    public async Task CompleteFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsoleAsync()
    {
        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsoleAsync();
    }

    [Given(@"^I complete save for Later/Return to Admin$")]
    [When(@"^I complete save for Later/Return to Admin$")]
    [Then(@"^I complete save for Later/Return to Admin$")]
    public async Task CompleteSaveForLaterReturnToAdminAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteSaveForLaterReturnToAdminAsync2();
    }

    [Given(@"^I open EQ in Browser for body$")]
    [When(@"^I open EQ in Browser for body$")]
    [Then(@"^I open EQ in Browser for body$")]
    public async Task OpenEQInBrowserForBodyAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.OpenEQInBrowserForBodyAsync();
    }

    [Given(@"^I complete restart Edge Popup for ok$")]
    [When(@"^I complete restart Edge Popup for ok$")]
    [Then(@"^I complete restart Edge Popup for ok$")]
    public async Task CompleteRestartEdgePopupForOkAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRestartEdgePopupForOkAsync();
    }

    [Given(@"^I open EQ in Browser for open eq in browser$")]
    [When(@"^I open EQ in Browser for open eq in browser$")]
    [Then(@"^I open EQ in Browser for open eq in browser$")]
    public async Task OpenEQInBrowserForOpenEqInBrowserAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.OpenEQInBrowserForOpenEqInBrowserAsync();
    }

    [Given(@"^I sign in to ExpertQuote for username$")]
    [When(@"^I sign in to ExpertQuote for username$")]
    [Then(@"^I sign in to ExpertQuote for username$")]
    public async Task SignInToExpertQuoteForUsernameAsync()
    {
        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SignInToExpertQuoteForUsernameAsync();
    }

    [Given(@"^I search by QuoteNum for quotesearchinput$")]
    [When(@"^I search by QuoteNum for quotesearchinput$")]
    [Then(@"^I search by QuoteNum for quotesearchinput$")]
    public async Task SearchByQuoteNumForQuotesearchinputAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SearchByQuoteNumForQuotesearchinputAsync();
    }

    [Given(@"^I search Results Table for results table$")]
    [When(@"^I search Results Table for results table$")]
    [Then(@"^I search Results Table for results table$")]
    public async Task SearchResultsTableForResultsTableAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SearchResultsTableForResultsTableAsync();
    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0502$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0502$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0502$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0502Async()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForSubsequentScreen0502Async();
    }

    [Given(@"^I complete checklist and Esign$")]
    [When(@"^I complete checklist and Esign$")]
    [Then(@"^I complete checklist and Esign$")]
    public async Task CompleteChecklistAndEsignAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteChecklistAndEsignAsync();
    }

    [Given(@"^I complete eChecklist \\- Building Photo1$")]
    [When(@"^I complete eChecklist \\- Building Photo1$")]
    [Then(@"^I complete eChecklist \\- Building Photo1$")]
    public async Task CompleteEChecklistBuildingPhoto1Async()
    {
        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteEChecklistBuildingPhoto1Async();
    }

    [Given(@"^I complete eChecklist \\- Building Photo2$")]
    [When(@"^I complete eChecklist \\- Building Photo2$")]
    [Then(@"^I complete eChecklist \\- Building Photo2$")]
    public async Task CompleteEChecklistBuildingPhoto2Async()
    {
        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteEChecklistBuildingPhoto2Async();
    }

    [Given(@"^I complete eChecklist \\- Building Photo3$")]
    [When(@"^I complete eChecklist \\- Building Photo3$")]
    [Then(@"^I complete eChecklist \\- Building Photo3$")]
    public async Task CompleteEChecklistBuildingPhoto3Async()
    {
        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteEChecklistBuildingPhoto3Async();
    }

    [Given(@"^I complete eChecklist \\- Building Photo4$")]
    [When(@"^I complete eChecklist \\- Building Photo4$")]
    [Then(@"^I complete eChecklist \\- Building Photo4$")]
    public async Task CompleteEChecklistBuildingPhoto4Async()
    {
        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteEChecklistBuildingPhoto4Async();
    }

    [Given(@"^I complete eChecklist \\- Loss Runs \\- 3 Years$")]
    [When(@"^I complete eChecklist \\- Loss Runs \\- 3 Years$")]
    [Then(@"^I complete eChecklist \\- Loss Runs \\- 3 Years$")]
    public async Task CompleteEChecklistLossRuns3YearsAsync()
    {
        var page = new LossHistoryPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteEChecklistLossRuns3YearsAsync();
    }

    [Given(@"^I select OK$")]
    [When(@"^I select OK$")]
    [Then(@"^I select OK$")]
    public async Task SelectOKAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SelectOKAsync();
    }

    [Given(@"^I navigate to the required policy screen for refer to uw in eq$")]
    [When(@"^I navigate to the required policy screen for refer to uw in eq$")]
    [Then(@"^I navigate to the required policy screen for refer to uw in eq$")]
    public async Task NavigateToTheRequiredPolicyScreenForReferToUwInEqAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForReferToUwInEqAsync();
    }

    [Given(@"^I refer to UW$")]
    [When(@"^I refer to UW$")]
    [Then(@"^I refer to UW$")]
    public async Task ReferToUWAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.ReferToUWAsync();
    }

    [Given(@"^I open a CLAS Browser and Search for EQ by Description for body$")]
    [When(@"^I open a CLAS Browser and Search for EQ by Description for body$")]
    [Then(@"^I open a CLAS Browser and Search for EQ by Description for body$")]
    public async Task OpenACLASBrowserAndSearchForEQByDescriptionForBodyAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.OpenACLASBrowserAndSearchForEQByDescriptionForBodyAsync();
    }

    [Given(@"^I sign out of the application for logged in user$")]
    [When(@"^I sign out of the application for logged in user$")]
    [Then(@"^I sign out of the application for logged in user$")]
    public async Task SignOutOfTheApplicationForLoggedInUserAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SignOutOfTheApplicationForLoggedInUserAsync();
    }

    [Given(@"^I open a CLAS Browser and Search for EQ by Description for open a clas browser and search for eq by description$")]
    [When(@"^I open a CLAS Browser and Search for EQ by Description for open a clas browser and search for eq by description$")]
    [Then(@"^I open a CLAS Browser and Search for EQ by Description for open a clas browser and search for eq by description$")]
    public async Task OpenACLASBrowserAndSearchForEQByDescriptionForOpenAClasBrowserAndSearchForEqByDescriptionAsync()
    {
        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.OpenACLASBrowserAndSearchForEQByDescriptionForOpenAClasBrowserAndSearchForEqByDescriptionAsync();
    }

    [Given(@"^I search by Desc in DC for search text$")]
    [When(@"^I search by Desc in DC for search text$")]
    [Then(@"^I search by Desc in DC for search text$")]
    public async Task SearchByDescInDCForSearchTextAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SearchByDescInDCForSearchTextAsync();
    }

    [Given(@"^I open a CLAS Browser and Search for EQ by Description for verify view policy$")]
    [When(@"^I open a CLAS Browser and Search for EQ by Description for verify view policy$")]
    [Then(@"^I open a CLAS Browser and Search for EQ by Description for verify view policy$")]
    public async Task OpenACLASBrowserAndSearchForEQByDescriptionForVerifyViewPolicyAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.OpenACLASBrowserAndSearchForEQByDescriptionForVerifyViewPolicyAsync();
    }

    [Given(@"^I navigate to Submission Screen$")]
    [When(@"^I navigate to Submission Screen$")]
    [Then(@"^I navigate to Submission Screen$")]
    public async Task NavigateToSubmissionScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToSubmissionScreenAsync();
    }

    [Given(@"^I run Stoplight$")]
    [When(@"^I run Stoplight$")]
    [Then(@"^I run Stoplight$")]
    public async Task RunStoplightAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.RunStoplightAsync();
    }

    [Given(@"^I refer Application/Policy$")]
    [When(@"^I refer Application/Policy$")]
    [Then(@"^I refer Application/Policy$")]
    public async Task ReferApplicationPolicyAsync()
    {
        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.ReferApplicationPolicyAsync();
    }

    [Given(@"^I complete alert Error Check$")]
    [When(@"^I complete alert Error Check$")]
    [Then(@"^I complete alert Error Check$")]
    public async Task CompleteAlertErrorCheckAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteAlertErrorCheckAsync();
    }

    [Given(@"^I refer Application/Policy for table row cell link$")]
    [When(@"^I refer Application/Policy for table row cell link$")]
    [Then(@"^I refer Application/Policy for table row cell link$")]
    public async Task ReferApplicationPolicyForTableRowCellLinkAsync()
    {
        var page = new BillingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.ReferApplicationPolicyForTableRowCellLinkAsync();
    }

    [Given(@"^I complete save for Later/Return to Admin for save for later$")]
    [When(@"^I complete save for Later/Return to Admin for save for later$")]
    [Then(@"^I complete save for Later/Return to Admin for save for later$")]
    public async Task CompleteSaveForLaterReturnToAdminForSaveForLaterAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteSaveForLaterReturnToAdminForSaveForLaterAsync();
    }

    [Given(@"^I complete retreive Policy Number After Referral$")]
    [When(@"^I complete retreive Policy Number After Referral$")]
    [Then(@"^I complete retreive Policy Number After Referral$")]
    public async Task CompleteRetreivePolicyNumberAfterReferralAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRetreivePolicyNumberAfterReferralAsync();
    }

    [Given(@"^I open EQ in Browser for open a browser$")]
    [When(@"^I open EQ in Browser for open a browser$")]
    [Then(@"^I open EQ in Browser for open a browser$")]
    public async Task OpenEQInBrowserForOpenABrowserAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.OpenEQInBrowserForOpenABrowserAsync();
    }

    [Given(@"^I complete restart Edge Popup for restart edge popup$")]
    [When(@"^I complete restart Edge Popup for restart edge popup$")]
    [Then(@"^I complete restart Edge Popup for restart edge popup$")]
    public async Task CompleteRestartEdgePopupForRestartEdgePopupAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRestartEdgePopupForRestartEdgePopupAsync();
    }

    [Given(@"^I open EQ in Browser for check if logout exists$")]
    [When(@"^I open EQ in Browser for check if logout exists$")]
    [Then(@"^I open EQ in Browser for check if logout exists$")]
    public async Task OpenEQInBrowserForCheckIfLogoutExistsAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.OpenEQInBrowserForCheckIfLogoutExistsAsync();
    }

    [Given(@"^I sign in to ExpertQuote for login to eq sso$")]
    [When(@"^I sign in to ExpertQuote for login to eq sso$")]
    [Then(@"^I sign in to ExpertQuote for login to eq sso$")]
    public async Task SignInToExpertQuoteForLoginToEqSsoAsync()
    {
        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SignInToExpertQuoteForLoginToEqSsoAsync();
    }

    [Given(@"^I search by QuoteNum for search by quotenum$")]
    [When(@"^I search by QuoteNum for search by quotenum$")]
    [Then(@"^I search by QuoteNum for search by quotenum$")]
    public async Task SearchByQuoteNumForSearchByQuotenumAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SearchByQuoteNumForSearchByQuotenumAsync();
    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0827$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0827$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0827$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0827Async()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToTheRequiredPolicyScreenForSubsequentScreen0827Async();
    }

    [Given(@"^I transmit to DC$")]
    [When(@"^I transmit to DC$")]
    [Then(@"^I transmit to DC$")]
    public async Task TransmitToDCAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.TransmitToDCAsync();
    }

    [Given(@"^I verify premium on DC$")]
    [When(@"^I verify premium on DC$")]
    [Then(@"^I verify premium on DC$")]
    public async Task VerifyPremiumOnDCAsync()
    {
        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.VerifyPremiumOnDCAsync();
    }

    [Given(@"^I sign in to Duck Creek$")]
    [When(@"^I sign in to Duck Creek$")]
    [Then(@"^I sign in to Duck Creek$")]
    public async Task SignInToDuckCreekAsync()
    {
        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SignInToDuckCreekAsync();
    }

    [Given(@"^I complete restart Edge Popup for restart microsoft edge message exists$")]
    [When(@"^I complete restart Edge Popup for restart microsoft edge message exists$")]
    [Then(@"^I complete restart Edge Popup for restart microsoft edge message exists$")]
    public async Task CompleteRestartEdgePopupForRestartMicrosoftEdgeMessageExistsAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRestartEdgePopupForRestartMicrosoftEdgeMessageExistsAsync();
    }

    [Given(@"^I sign in to Duck Creek for logged in user$")]
    [When(@"^I sign in to Duck Creek for logged in user$")]
    [Then(@"^I sign in to Duck Creek for logged in user$")]
    public async Task SignInToDuckCreekForLoggedInUserAsync()
    {
        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SignInToDuckCreekForLoggedInUserAsync();
    }

    [Given(@"^I sign out of the application for logout$")]
    [When(@"^I sign out of the application for logout$")]
    [Then(@"^I sign out of the application for logout$")]
    public async Task SignOutOfTheApplicationForLogoutAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SignOutOfTheApplicationForLogoutAsync();
    }

    [Given(@"^I sign in to Duck Creek for cl dc$")]
    [When(@"^I sign in to Duck Creek for cl dc$")]
    [Then(@"^I sign in to Duck Creek for cl dc$")]
    public async Task SignInToDuckCreekForClDcAsync()
    {
        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SignInToDuckCreekForClDcAsync();
    }

    [Given(@"^I perform Quick Search and Open Policy$")]
    [When(@"^I perform Quick Search and Open Policy$")]
    [Then(@"^I perform Quick Search and Open Policy$")]
    public async Task PerformQuickSearchAndOpenPolicyAsync()
    {
        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.PerformQuickSearchAndOpenPolicyAsync();
    }

    [Given(@"^I verify for Policy Packet$")]
    [When(@"^I verify for Policy Packet$")]
    [Then(@"^I verify for Policy Packet$")]
    public async Task VerifyForPolicyPacketAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.VerifyForPolicyPacketAsync();
    }

}
