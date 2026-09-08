using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLEQ.Pages;

namespace InsuranceAutomation.CLEQ.StepDefinitions;

[Binding, Scope(Feature = "EQ BOP Basic Policy")]
public sealed class EQBOPBasicPolicySteps
{
    private readonly ScenarioContext _scenario;
    private readonly ApplicationLogin _auth;
    public EQBOPBasicPolicySteps(ScenarioContext scenario) => _scenario = scenario;
    private ApplicationLogin Auth => _auth ?? new ApplicationLogin(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());

    [Given(@"^I create a new client and begin the quote$")]
    [When(@"^I create a new client and begin the quote$")]
    [Then(@"^I create a new client and begin the quote$")]
    public async Task CreateANewClientAndBeginTheQuoteAsync()
    {
        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyNewQuoteAsync("Visible", "");
        await page.ClickNewQuoteAsync();
        await page.WaitForClientInfoAsync("Visible");
    }

    [Given(@"^I enter client search information$")]
    [When(@"^I enter client search information$")]
    [Then(@"^I enter client search information$")]
    public async Task EnterClientSearchInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("LastName", "BASIC[A-Z]{4}");
        data.GenerateRandom("FirstName", "BOP[a-z]{3}");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForClientInfoAsync("Visible");
        //await page.WaitForNewExistingClientSearchAsync("Visible");
        await page.EnterCustomerNameFirstAsync(data.Resolve("{{runtime:FirstName}}"));
        await page.EnterCustomerNameLastAsync(data.Resolve("{{runtime:LastName}}"));
        await page.EnterCustomerDateOfBirthAsync(data.Resolve("{{data:customer_dateofbirth_7}}"));
        await page.ClickClientInfoSearchAsync();

    }

    [Given(@"^I create a new client$")]
    [When(@"^I create a new client$")]
    [Then(@"^I create a new client$")]
    public async Task CreateANewClientAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        //await page.WaitForExistingClientMatchAsync("Exists");
        await page.ClickCreateNewClient1Async();
        await page.ClickAdditionalInterestsNextAsync();
        data.Set("StateName", data.Resolve("{{data:statename}}"));

    }

    [Given(@"^I enter account details$")]
    [When(@"^I enter account details$")]
    [Then(@"^I enter account details$")]
    public async Task EnterAccountDetailsAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("OwnerPhone");
        data.GenerateRandom("OwnerEmail");

        var page = new AccountInformationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // XTestStep/XTestStepValue order is authoritative; manual CSV/workbooks are not inputs.
        await page.WaitForAccountInformationHeaderAsync("Visible");
        await page.EnterOwnerMiddleNameAsync("");
        await page.EnterOwnerPhoneAsync(data.Resolve("{{runtime:OwnerPhone}}"));
        await page.EnterOwnerEmailAsync(data.Resolve("{{runtime:OwnerEmail}}"));
        await page.ClickMarriedAsync();

        await page.EnterStreetAddressAsync(data.GetCanonicalFieldRequired("Address 1"));
        await page.EnterAddress2Async(data.GetCanonicalField("Address 2"));
        await page.EnterCityAsync(data.GetCanonicalFieldRequired("City"));
        await page.SelectStateAsync(data.GetCanonicalFieldRequired("State Name"));
        await page.EnterZipAsync(data.GetCanonicalFieldRequired("Zip"));
        // Map/Satellite are generated only after address steering in raw Tosca.
        await page.VerifyMapAsync("Visible", "");
        await Task.Delay(8000);
        //await page.VerifySatelliteAsync("Visible", "");

        await page.SelectHaveYouReceivedMailAtThisAddressForAtLeast90DaysYesAsync();
        await page.SelectIsTheAccountAddressAlsoWhereTheClientResidesYesAsync();
        await page.ClickAdditionalInterestsNextAsync();
    }


    [Given(@"^I start the policy proposal$")]
    [When(@"^I start the policy proposal$")]
    [Then(@"^I start the policy proposal$")]
    public async Task StartThePolicyProposalAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForProposalDetailsHeaderAsync("Visible");
        await page.SelectBusinessOwnersAsync("");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets SearchBusinessName
        await page.ClickIndividuallyOwnedDBAOrTAAsync();
        await page.EnterIndividualDBAAsync(data.Resolve("{{data:individual_dba_35}}"));
        await page.EnterEffectiveDate6F16BAsync(data.GetCanonicalFieldRequired("EffDate"));
        await page.PressEffectiveDate78F67Async("ENTER");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets EffectiveDate78F67
        await page.EnterTrueAsync(data.Resolve("{{data:true_37}}"));
        await page.SelectLessorsRiskNoAsync("");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets StateDropdown
        await page.SelectStateAsync(data.Resolve("{{runtime:StateName}}"));
        await page.EnterAgentPCAsync(data.GetCanonicalFieldRequired("Agent"));

        // Source AgentPC steering confirms autocomplete by tabbing out twice.

        data.Set("EffDate", data.GetCanonicalFieldRequired("EffDate"));
        await page.ClickStartQuoteAsync();

    }

    [Given(@"^I enter and validate the insured social security number$")]
    [When(@"^I enter and validate the insured social security number$")]
    [Then(@"^I enter and validate the insured social security number$")]
    public async Task EnterAndValidateTheInsuredSocialSecurityNumberAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("InsuredSSN", "025[0-9]{6}");

        var page = new SocialSecurityPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForTheSSNCouldNotBeFoundPleaseEnterAnSSNAsync("Visible");
        // Source step 0041: RANDOM input for ssn.
        await page.EnterTheSSNCouldNotBeFoundPleaseEnterAnSSNAsync(data.Resolve("{{runtime:InsuredSSN}}"));
        await page.PauseAsync(2000);
        await page.WaitForSubmitAngularAsync("Visible");
        await page.ClickSubmitAngularAsync();
        await page.PauseAsync(2000);
        if (await page.IsNoPrefillMatchFoundPresentAsync())
        {
                    await page.VerifyNoPrefillMatchFoundAsync("Exists", "");
        }
        if (await page.IsContinuePresentAsync())
        {
                    await page.ClickContinueAsync();
        }
        if (!await page.IsScreenHeadingPresentAsync())
        {
                    await page.VerifyScreenHeadingAsync("Absent", "");
        }

    }

    [Given(@"^I search and add a Class Code to the policy$")]
    [When(@"^I search and add a Class Code to the policy$")]
    [Then(@"^I search and add a Class Code to the policy$")]
    public async Task SearchAndAddAClassCodeToThePolicyAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickSearchAddClassCodeAsync();
        await page.PauseAsync(2000);
        await page.WaitForFindAClassCodeAsync("Exists");
        await page.PauseAsync(2000);
        await page.EnterClassFilterAsync(data.Resolve("{{data:class_filter_64}}"));
        await page.ClickClassFilterSearchButtonAsync();
        await page.PauseAsync(2000);
        await page.ClickAddToPolicyCheckboxAsync();
        await page.PauseAsync(2000);
        await page.ClickAddAsync();
        await page.PauseAsync(2000);

    }

    [Given(@"^I complete industry Class Code Restrictions$")]
    [When(@"^I complete industry Class Code Restrictions$")]
    [Then(@"^I complete industry Class Code Restrictions$")]
    public async Task CompleteIndustryClassCodeRestrictionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BusinessClassificationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForIndustryClassCodeRestrictionsHeadingAsync("Exists");
        if (!await page.IsScreenHeadingPresentAsync())
        {
                    await page.VerifyScreenHeadingAsync("Absent", "");
        }
        await page.ClickNoneOfTheAboveAsync();
        await page.PauseAsync(2000);
    }

    [Given(@"^I confirm Primary Insured Details and select existing client$")]
    [When(@"^I confirm Primary Insured Details and select existing client$")]
    [Then(@"^I confirm Primary Insured Details and select existing client$")]
    public async Task ConfirmPrimaryInsuredDetailsAndSelectExistingClientAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        var clientSearchPage = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.PauseAsync(2000);
        await page.ClickNextPrimaryInsuredDetailsAsync();
        await page.PauseAsync(2000);
        await clientSearchPage.ClickExistingClientSuggestionAsync();
        await page.PauseAsync(2000);
        await clientSearchPage.ClickPrimaryInsuredSelectionNextAsync();
        await page.PauseAsync(2000);

    }

    [Given(@"^I enter Required Info$")]
    [When(@"^I enter Required Info$")]
    [Then(@"^I enter Required Info$")]
    public async Task EnterRequiredInfoAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        var now = DateTime.Now;

        var descriptionOfOperations = $"AL BOP EQ Basic {now:MMMM}.{now:dd}.{now:yyyy} {now:h:mm}";
        data.Set("DescriptionOfOperations", descriptionOfOperations);

        await page.PauseAsync(2000);
        await page.ClickIndividualSoleProprietorAsync();
        await page.PauseAsync(2000);
        await page.ClickSaveAsync();
        await page.PauseAsync(2000);
        await page.EnterDescriptionOfOperationsAsync(descriptionOfOperations);
        await page.PauseAsync(3000);
        await page.EnterNumberOfFulltimeEmployeesAsync("3");
        await page.PauseAsync(3000);
        await page.EnterNumberOfPartTimeEmployeesAsync("2");
        await page.PauseAsync(3000);
        await page.EnterNumberOfSeasonalEmployeesAsync("1");
        await page.PauseAsync(3000);
        await page.ClickSaveAsync();
        await page.PauseAsync(2000);

    }

    [Given(@"^I complete general UW Questions$")]
    [When(@"^I complete general UW Questions$")]
    [Then(@"^I complete general UW Questions$")]
    public async Task CompleteGeneralUWQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.PauseAsync(2000);
        await page.ClickNoneOfTheAboveCheckBoxAsync();
        await page.PauseAsync(2000);

    }

    [Given(@"^I complete industry Class Code Questions$")]
    [When(@"^I complete industry Class Code Questions$")]
    [Then(@"^I complete industry Class Code Questions$")]
    public async Task CompleteIndustryClassCodeQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BusinessClassificationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.PauseAsync(2000);
        await page.ClickNoneOfTheAboveLiabilityQuestionsAsync();
        await page.PauseAsync(2000);


    }

    [Given(@"^I navigate to Claims/Prior Insurance screen$")]
    [When(@"^I navigate to Claims/Prior Insurance screen$")]
    [Then(@"^I navigate to Claims/Prior Insurance screen$")]
    public async Task NavigateToClaimsPriorInsuranceScreenAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.PauseAsync(2000);
        await page.ClickNextClaimsPriorInsuranceAsync();
        await page.PauseAsync(2000);

    }

    [Given(@"^I complete Claims/Prior Insurance Screen$")]
    [When(@"^I complete Claims/Prior Insurance Screen$")]
    [Then(@"^I complete Claims/Prior Insurance Screen$")]
    public async Task CompleteEditClientRolesAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        var ui = _scenario.Get<UiActions>();
        var config = _scenario.Get<FrameworkConfig>();
        var timeoutMs = config.Waits.ElementReadyTimeoutMs;

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), ui);

        var lossHistoryPage = new LossHistoryPage(_scenario.Get<BrowserSession>(), ui);

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await Task.Delay(2000);
        await ui.WaitReadyBestEffortAsync(page.Locators.ExposuresInsuredAN90DaysNo, new ControlIntent("PolicyWorkflow", "ExposuresInsuredAN90DaysNo"), timeoutMs);
        await page.ClickExposuresInsuredAN90DaysNoAsync();
        await Task.Delay(3000);
        await ui.WaitReadyBestEffortAsync(page.Locators.YearsInBusiness, new ControlIntent("PolicyWorkflow", "YearsInBusiness"), timeoutMs);
        await page.EnterYearsInBusinessAsync("5");
        await Task.Delay(3000);
        await ui.WaitReadyBestEffortAsync(page.Locators.YearsMaintainedContinuousInsuranceCoverage3Plus, new ControlIntent("PolicyWorkflow", "YearsMaintainedContinuousInsuranceCoverage3Plus"), timeoutMs);
        await page.ClickYearsMaintainedContinuousInsuranceCoverage3PlusAsync();
        await Task.Delay(3000);
        await ui.WaitReadyBestEffortAsync(lossHistoryPage.Locators.PriorInsuranceLatestExpirationDate, new ControlIntent("LossHistory", "PriorInsuranceLatestExpirationDate"), timeoutMs);
        await lossHistoryPage.EnterPriorInsuranceLatestExpirationDateAsync(data.GetCanonicalFieldRequired("PriorInsuranceExpDate"));
        await Task.Delay(3000);
        await ui.WaitReadyBestEffortAsync(lossHistoryPage.Locators.PriorInsuranceLatestCarrier, new ControlIntent("LossHistory", "PriorInsuranceLatestCarrier"), timeoutMs);
        await lossHistoryPage.EnterPriorInsuranceLatestCarrierAsync(data.GetCanonicalFieldRequired("PriorInsuranceCarrier"));
        await Task.Delay(3000);
        await ui.WaitReadyBestEffortAsync(lossHistoryPage.Locators.AddClaim, new ControlIntent("LossHistory", "AddClaim"), timeoutMs);
        await lossHistoryPage.ClickAddClaimAsync();
        await Task.Delay(3000);
        await ui.WaitReadyBestEffortAsync(lossHistoryPage.Locators.ADDCLAIM, new ControlIntent("LossHistory", "DateOfOccurrence"), timeoutMs);
        await lossHistoryPage.EnterDateOfOccurrenceAsync(data.GetCanonicalFieldRequired("ClaimDateOfOccurrence"));
        await Task.Delay(3000);
        await ui.WaitReadyBestEffortAsync(lossHistoryPage.Locators.PolicyStart, new ControlIntent("LossHistory", "PolicyStart"), timeoutMs);
        await lossHistoryPage.EnterPolicyStartAsync(data.GetCanonicalFieldRequired("ClaimPolicyPeriodEffectiveDate"));
        await Task.Delay(3000);
        await ui.WaitReadyBestEffortAsync(lossHistoryPage.Locators.PolicyExpire, new ControlIntent("LossHistory", "PolicyExpire"), timeoutMs);
        await lossHistoryPage.EnterPolicyExpireAsync(data.GetCanonicalFieldRequired("ClaimPolicyPeriodExpirationDate"));
        await Task.Delay(3000);
        await ui.WaitReadyBestEffortAsync(lossHistoryPage.Locators.AmountPaid, new ControlIntent("LossHistory", "AmountPaid"), timeoutMs);
        await lossHistoryPage.EnterAmountPaidAsync(data.GetCanonicalFieldRequired("ClaimAmountPaid"));
        await Task.Delay(3000);
        await ui.WaitReadyBestEffortAsync(lossHistoryPage.Locators.AmountReserved, new ControlIntent("LossHistory", "AmountReserved"), timeoutMs);
        await lossHistoryPage.EnterAmountReservedAsync(data.GetCanonicalFieldRequired("ClaimAmountReserved"));
        await Task.Delay(3000);
        await ui.WaitReadyBestEffortAsync(lossHistoryPage.Locators.ExpenseAmount, new ControlIntent("LossHistory", "ExpenseAmount"), timeoutMs);
        await lossHistoryPage.EnterExpenseAmountAsync(data.GetCanonicalFieldRequired("ClaimExpenseAmount"));
        await Task.Delay(3000);
        await ui.WaitReadyBestEffortAsync(lossHistoryPage.Locators.TypeOfLossDropdown, new ControlIntent("LossHistory", "TypeOfLossDropdown"), timeoutMs);
        await lossHistoryPage.EnterTypeOfLossDropdownAsync(data.GetCanonicalFieldRequired("ClaimTypeOfLoss"));
        await Task.Delay(3000);
        await ui.WaitReadyBestEffortAsync(lossHistoryPage.Locators.DescriptionOfOccurrenceOrClaim, new ControlIntent("LossHistory", "DescriptionOfOccurrenceOrClaim"), timeoutMs);
        await lossHistoryPage.EnterDescriptionOfOccurrenceOrClaimAsync("Accident");
        await Task.Delay(3000);
        await ui.WaitReadyBestEffortAsync(lossHistoryPage.Locators.OpenButton, new ControlIntent("LossHistory", "OpenButton"), timeoutMs);
        await lossHistoryPage.ClickOpenButtonAsync();
        await Task.Delay(3000);
        await ui.WaitReadyBestEffortAsync(lossHistoryPage.Locators.SaveClaim, new ControlIntent("LossHistory", "SaveClaim"), timeoutMs);
        await lossHistoryPage.ClickSaveClaimAsync();
        await page.PauseAsync(3000);

    }

    [Given(@"^I complete Client Details and navigate to Narrative screen$")]
    [When(@"^I complete Client Details and navigate to Narrative screen$")]
    [Then(@"^I complete Client Details and navigate to Narrative screen$")]
    public async Task CompleteClientDetailsAndNavigateToNarrativeScreenAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickNextClientDetailsAsync();
        await Task.Delay(2000);
        await page.ClickInspectionContactCheckBoxAsync();
        await Task.Delay(2000);
        await page.ClickNextNarrativeFromClaimsAsync();
        await page.PauseAsync(2000);

    }

    [Given(@"^I add/Edit a Narrative and Verify Timestamp$")]
    [When(@"^I add/Edit a Narrative and Verify Timestamp$")]
    [Then(@"^I add/Edit a Narrative and Verify Timestamp$")]
    public async Task AddEditANarrativeAndVerifyTimestampAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickAddNarrativeAsync();
        await page.PauseAsync(2000);
        await page.EnterDescriptionOfTheBusinessExposuresActivitiesAndExperienceAsync(data.Resolve("{{data:description_of_the_business_exposures_activities_and_experience_118}}"));
        await page.PauseAsync(2000);
        await page.ClickSaveAsync();
        await page.PauseAsync(2000);
    }

    [Given(@"^I navigate to Locations/Buildings screen$")]
    [When(@"^I navigate to Locations/Buildings screen$")]
    [Then(@"^I navigate to Locations/Buildings screen$")]
    public async Task NavigateToLocationsBuildingsScreenAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickNextLocationsBuildingsAsync();
        await page.PauseAsync(2000);

    }

    [Given(@"^I enter Required on Location/Building page$")]
    [When(@"^I enter Required on Location/Building page$")]
    [Then(@"^I enter Required on Location/Building page$")]
    public async Task EnterRequiredAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LossHistoryPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        //await page.SelectPriorPolicyNoAsync("");
        //await page.PressYearsInBusinessAsync("ENTER");
        //await page.ClickN3YearsAsync();
        //await page.PressPriorInsuranceLatestExpirationDateAsync("ENTER");
        //await page.PressPriorInsuranceLatestCarrierAsync("ENTER");

    }

    [Given(@"^I add/Verify/Delete Claims$")]
    [When(@"^I add/Verify/Delete Claims$")]
    [Then(@"^I add/Verify/Delete Claims$")]
    public async Task AddVerifyDeleteClaimsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LossHistoryPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickADDCLAIMAsync();
        await page.PressDateOfOccurrenceAsync("CTRL+A");
        await page.PressDateOfOccurrenceAsync("Enter");
        await page.PressPolicyStartAsync("CTRL+A");
        await page.PressPolicyStartAsync("Enter");
        await page.PressPolicyExpireAsync("CTRL+A");
        await page.PressPolicyExpireAsync("Enter");
        await page.PressAmountPaidAsync("CTRL+A");
        await page.PressAmountPaidAsync("Enter");
        await page.PressAmountReservedAsync("CTRL+A");
        await page.PressAmountReservedAsync("Enter");
        await page.PressExpenseAmountAsync("CTRL+A");
        await page.PressExpenseAmountAsync("Enter");
        await page.ClickTypeOfLossSelectionAsync();
        await page.PressDescriptionOfOccurrenceOrClaimAsync("ENTER");
        await page.ClickOpenButtonAsync();
        await page.ClickSaveAsync();
        await page.VerifyClaimSummaryTableRowCellExplicitNameClaimDateAsync(data.Resolve("{{data:expected_claim_summary_table_row_cell_explicitname_claim_date_165}}"), "");
        await page.VerifyClaimSummaryTableRowCellExplicitNameAmountAsync(data.Resolve("{{data:expected_claim_summary_table_row_cell_explicitname_amount_166}}"), "");
        await page.VerifyClaimSummaryTableRowCellExplicitNameLineOfCoverageAsync(data.Resolve("{{data:expected_claim_summary_table_row_cell_explicitname_line_of_coverage_167}}"), "");
        await page.VerifyClaimSummaryTableRowCellExplicitNameTypeOfLossAsync(data.Resolve("{{data:expected_claim_summary_table_row_cell_explicitname_type_of_loss_168}}"), "");
        await page.VerifyClaimSummaryTableRowCellExplicitNameCATClaimAsync(data.Resolve("{{data:expected_claim_summary_table_row_cell_explicitname_cat_claim_169}}"), "");
        await page.VerifyClaimSummaryTableRowCellExplicitNameClaimDateAsync(data.Resolve("{{data:expected_claim_summary_table_row_cell_explicitname_claim_date_170}}"), "");
        await page.VerifyClaimSummaryTableRowCellExplicitNameAmountAsync("__BLANK__", "");
        await page.VerifyClaimSummaryTableRowCellExplicitNameLineOfCoverageAsync(data.Resolve("{{data:expected_claim_summary_table_row_cell_explicitname_line_of_coverage_172}}"), "");
        await page.VerifyClaimSummaryTableRowCellExplicitNameTypeOfLossAsync(data.Resolve("{{data:expected_claim_summary_table_row_cell_explicitname_type_of_loss_173}}"), "");
        if (!await page.IsScreenHeadingPresentAsync())
        {
                    await page.VerifyScreenHeadingAsync("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0143$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0143$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0143$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0143Async()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (!await page.IsScreen4475CPresentAsync())
        {
                    await page.ClickScreen4475CAsync();
        }
        if (data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
                    await page.ClickKeepGoingAsync();
        }
        if (!await page.IsLoadingPresentAsync())
        {
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.WaitForScreenHeading9696CAsync("Exists");
        }

    }

    [Given(@"^I complete edit a Location$")]
    [When(@"^I complete edit a Location$")]
    [Then(@"^I complete edit a Location$")]
    public async Task CompleteEditALocationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LocationsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickEditLocationButtonLatestAngularAsync();
        await page.PauseAsync(2000);
        await page.EnterTerritoryAsync(data.Resolve("{{data:territory_188}}"));
        await page.PauseAsync(2000);
        await page.EnterMilesFromFireDeptAsync("1");
        await page.PauseAsync(2000);
        await page.EnterFeetFromHydrantAsync(data.Resolve("{{data:feetfromhydrant_190}}"));
        await page.PauseAsync(2000);
        await page.ClickSaveAsync();
        await page.PauseAsync(2000);

    }

    [Given(@"^I add a Building Button$")]
    [When(@"^I add a Building Button$")]
    [Then(@"^I add a Building Button$")]
    public async Task AddABuildingButtonAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await Task.Delay(2000);
        await page.ClickAddBuildingBPPAsync();
        await page.PauseAsync(2000);

    }

    [Given(@"^I select Own or rent and Building SQ Footage Basic$")]
    [When(@"^I select Own or rent and Building SQ Footage Basic$")]
    [Then(@"^I select Own or rent and Building SQ Footage Basic$")]
    public async Task SelectOwnOrRentAndBuildingSQFootageBasicAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        var buildingsPage = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickOwnButtonAsync();
        await Task.Delay(2000);
        await buildingsPage.EnterTotalBuildingSqFootageAsync(data.GetCanonicalFieldRequired("Total Building Sq Footage"));
        await Task.Delay(2000);
        await buildingsPage.EnterInsuredOccupancySqFtAsync(data.GetCanonicalFieldRequired("Insured Occupancy Sq Ft Basic"));
        await page.PauseAsync(2000);

    }

    [Given(@"^I select Additional Coverages \- Building, Functional Personal Property or Habitational$")]
    [When(@"^I select Additional Coverages \- Building, Functional Personal Property or Habitational$")]
    [Then(@"^I select Additional Coverages \- Building, Functional Personal Property or Habitational$")]
    public async Task SelectAdditionalCoveragesBuildingFunctionalPersonalPropertyOrHabitationalAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickBuildingCoverageAngularAsync();
        await Task.Delay(2000);
       
    }

    [Given(@"^I select Occupancy SQ Footage$")]
    [When(@"^I select Occupancy SQ Footage$")]
    [Then(@"^I select Occupancy SQ Footage$")]
    public async Task SelectOccupancySQFootageAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.EnterInsuredOccupancySqFtAsync(data.GetCanonicalFieldRequired("Insured Occupancy Sq Ft"));
        await page.PressInsuredOccupancySqFtAngularAsync("CTRL+A");
        await page.PressInsuredOccupancySqFtAngularAsync("Enter");


    }

    [Given(@"^I enter supplimental data\- for class$")]
    [When(@"^I enter supplimental data\- for class$")]
    [Then(@"^I enter supplimental data\- for class$")]
    public async Task EnterSupplimentalDataForClassAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await Task.Delay(2000);
        await page.ClickClassCodeCheckboxAsync();
        await Task.Delay(2000);
        await page.EnterOccupancySqFootageTotalAsync(data.Resolve("{{data:expected_occupancy_sq_footage_total_value_227}}"));
        await Task.Delay(2000);
        await page.ClickPersonalPropertyLimitCheckBoxAngularAsync();
        await Task.Delay(2000);
        await page.EnterPersonalPropertyLimitAsync(data.GetCanonicalFieldRequired("Personal Property Limit"));
        await Task.Delay(2000);
        await page.EnterGrossSalesReceiptsAsync(data.GetCanonicalFieldRequired("Gross Sales Receipts"));
        await Task.Delay(2000);
        data.Set("Roof Type", data.Resolve("{{data:roof_type}}"));

    }

    [Given(@"^I select Cost Estimator \& Calculate Valuations$")]
    [When(@"^I select Cost Estimator \& Calculate Valuations$")]
    [Then(@"^I select Cost Estimator \& Calculate Valuations$")]
    public async Task SelectCostEstimatorCalculateValuationsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await Task.Delay(2000);
        await page.ClickCommercialButtonAsync();
        await Task.Delay(2000);
        await page.ClickBVSButtonAsync();
        await Task.Delay(2000);
        await page.SelectBVSGroupAsync(data.GetCanonicalFieldRequired("BVS Group"));
        await Task.Delay(2000);
        await page.SelectBVSResultAsync(data.GetCanonicalFieldRequired("BVS Result"));
        await Task.Delay(2000);
        await page.EnterYearBuiltValuationAsync(data.GetCanonicalFieldRequired("Year Built"));
        await Task.Delay(2000);
        await page.SelectRoofTypeValuationAsync(data.GetCanonicalFieldRequired("Roof Type"));
        await Task.Delay(3000);
        await page.ClickFrameAsync();
        await Task.Delay(2000);
        await page.ClickGetValuationAsync();
        await Task.Delay(2000);

    }

    [Given(@"^I select Building Detail Fields$")]
    [When(@"^I select Building Detail Fields$")]
    [Then(@"^I select Building Detail Fields$")]
    public async Task SelectBuildingDetailFieldsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await Task.Delay(4000);
        await page.ClickReplacementCostAsync();
        await Task.Delay(2000);
        await page.EnterBuildingLimitAsync("443000");
        await Task.Delay(2000);
        await page.EnterYearBuiltAsync("2020");
        await Task.Delay(2000);
        await page.EnterYearBuiltRenovatedAsync("2021");
        await Task.Delay(2000);
        await page.EnterWiringYearAsync("2021");
        await Task.Delay(2000);
        await page.EnterHeatingYearAsync("2022");
        await Task.Delay(2000);
        await page.EnterPlumbingYearAsync("2023");
        await Task.Delay(2000);
        await page.EnterNumberOfStoriesAsync("1");
        await Task.Delay(2000);
        await page.EnterRoofYearAsync("2024");
        await Task.Delay(2000);
        await page.SelectRoofType1Async("Aluminum- Shingle");
        await Task.Delay(2000);
        await page.ClickSprinklerYesAsync();
        await Task.Delay(2000);
        await page.ClickIsAnyHeatSourceThermostaticallyControlledYesAsync();
        await Task.Delay(4000);
        await page.ClickIsTheBuildingHeatedWithOneOfTheFollowingNoneOfTheAboveCheckboxAngularAsync();
        await Task.Delay(4000);
        await page.ClickSelectAnyOfTheFollowingWhichApplyToThisBuildingNoneOfTheAboveCheckboxAngularAsync();
        await Task.Delay(4000);
    }

    [Given(@"^I select Heating Sources$")]
    [When(@"^I select Heating Sources$")]
    [Then(@"^I select Heating Sources$")]
    public async Task SelectHeatingSourcesAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyEQBOPBuildingBuildingDetailsSelectPelletStoveAsync("Exists", "");
        await page.VerifyEQBOPBuildingBuildingDetailsSelectWoodFurnaceAsync("Exists", "");
        await page.VerifyEQBOPBuildingBuildingDetailsSelectWoodStoveAsync("Exists", "");

    }

    [Given(@"^I complete extra Property Risk$")]
    [When(@"^I complete extra Property Risk$")]
    [Then(@"^I complete extra Property Risk$")]
    public async Task CompleteExtraPropertyRiskAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyEQBOPBuildingBuildingDetailsAnswerAnyExtraPropertyAdditionalQuestionsAsync("Exists", "");

    }

    [Given(@"^I answer Building Eligibility Questions$")]
    [When(@"^I answer Building Eligibility Questions$")]
    [Then(@"^I answer Building Eligibility Questions$")]
    public async Task AnswerBuildingEligibilityQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await Task.Delay(4000);
        await page.ClickBuildingEligibilityQuestionsNoneOfTheAboveCheckboxAngularAsync();
        await Task.Delay(4000);
        await page.ClickSaveAsync();
        await page.PauseAsync(3000);
        await page.ClickKeepGoingConfirmIfPresentAsync();
        await page.PauseAsync(3000);

    }

    [Given(@"^I navigate to Policy Coverages screen$")]
    [When(@"^I navigate to Policy Coverages screen$")]
    [Then(@"^I navigate to Policy Coverages screen$")]
    public async Task NavigateToPolicyCoveragesScreenAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await Task.Delay(2000);
        await page.NavigateToScreenAsync("PolicyCoverages");
        await page.PauseAsync(2000);

    }

    [Given(@"^I navigate to Additional Coverages screen$")]
    [When(@"^I navigate to Additional Coverages screen$")]
    [Then(@"^I navigate to Additional Coverages screen$")]
    public async Task NavigateToAdditionalCoveragesScreenAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await Task.Delay(2000);
        await page.NavigateToScreenAsync("AdditionalCoverages");
        await page.PauseAsync(2000);

    }

    [Given(@"^I answer EPLI Questions$")]
    [When(@"^I answer EPLI Questions$")]
    [Then(@"^I answer EPLI Questions$")]
    public async Task AnswerEPLIQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await Task.Delay(3000);
        await page.SelectHaveThereBeenAnyEPLClaimsSuitsOrComplaintsOrAreThereAnyNowPendingAgainstTheInsuredOrAnyExecutiveOfficerOrOwnerAsync("No");
        await Task.Delay(7000);
        await page.SelectDoesTheInsuredAndAnyExecutiveOfficerOrOwnerHaveAnyKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaintAsync("No");
        await Task.Delay(3000);
        await page.ClickNextAdditionalInterestsAsync();
        await Task.Delay(3000);

    }

    [Given(@"^I navigate to Billing screen$")]
    [When(@"^I navigate to Billing screen$")]
    [Then(@"^I navigate to Billing screen$")]
    public async Task NavigateToBillingScreenAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await Task.Delay(2000);
        await page.ClickNextPricingAsync();
        await Task.Delay(2000);
        await page.ClickNextBillingAsync();
        await Task.Delay(4000);

    }

    [Given(@"^I complete billing Account Setup$")]
    [When(@"^I complete billing Account Setup$")]
    [Then(@"^I complete billing Account Setup$")]
    public async Task CompleteBillingAccountSetupAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BillingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickCreateNewBillingAccountAsync();
        await page.PauseAsync(2000);
        await page.ClickOTHERButtonAsync();
        await page.PauseAsync(2000);
        await page.EnterFirstNameAsync("Tommy");
        await page.PauseAsync(2000);
        await page.EnterLastNameAsync("Automation");
        await page.PauseAsync(2000);
        await page.EnterBusinessNameAsync("Auto Corp");
        await page.PauseAsync(2000);
        await page.EnterAddress1Async("9 Center Road");
        await page.PauseAsync(2000);
        await page.EnterCityAsync("Mahopac");
        await page.PauseAsync(2000);
        await page.SelectStateAsync("NY");
        await page.PauseAsync(2000);
        await page.EnterZipCodeAsync("10541");
        await page.PauseAsync(2000);

    }

    [Given(@"^I complete future Payment Plan 1$")]
    [When(@"^I complete future Payment Plan 1$")]
    [Then(@"^I complete future Payment Plan 1$")]
    public async Task CompleteFuturePaymentPlan1Async()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BillingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.PauseAsync(3000);
        await page.ClickDirectBillButtonAsync();
        await page.PauseAsync(3000);
        await page.ClickN1PaymentButtonAsync();
        await page.PauseAsync(3000);
        await page.EnterChoosePaymentDueDateAsync("1");
        await page.PauseAsync(2000);

    }

    [Given(@"^I complete initial Payment$")]
    [When(@"^I complete initial Payment$")]
    [Then(@"^I complete initial Payment$")]
    public async Task CompleteInitialPaymentAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BillingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickInitialPaymentFullBalanceAsync();
        await Task.Delay(9000);
        await page.ClickNextSubmissionAsync();
        await Task.Delay(8000);

    }

    [Given(@"^I complete Agent Comments$")]
    [When(@"^I complete Agent Comments$")]
    [Then(@"^I complete Agent Comments$")]
    public async Task CompleteAgentCommentsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await Task.Delay(4000);
        if (await page.IsAgentCommentsVisibleAndEditableAsync())
        {
            await page.EnterAgentCommentsAsync("Test");
        }
        if (await page.IsAgentComments2VisibleAndEditableAsync())
        {
            await page.EnterAgentComments2Async("Test");
        }
        await Task.Delay(2000);

    }

    [Given(@"^I launch to Checklist$")]
    [When(@"^I launch to Checklist$")]
    [Then(@"^I launch to Checklist$")]
    public async Task LaunchToChecklistAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var browser = _scenario.Get<BrowserSession>();
        var page = new NavigationPage(browser, _scenario.Get<UiActions>());

        await Task.Delay(2000);
        var newPage = await browser.SwitchToNewPageAsync(async () =>
        {
            await page.ClickLaunchToChecklistAsync();
        });
        await Task.Delay(2000);

        var checklistPage = new ChecklistPage(browser, _scenario.Get<UiActions>());
        try
        {
            await Task.Delay(2000);
            await checklistPage.ClickBuildingPhoto1Async();
            await Task.Delay(2000);
            for (var i = 0; i < 5; i++)
            {
                await Task.Delay(2000);
                await checklistPage.ClickExceptionAsync();
                await Task.Delay(2000);
                await checklistPage.TypeRequireNoteAsync("TestChecklistforUW");
                await Task.Delay(2000);
                await checklistPage.ClickExceptionNoteConfirmOKAsync();
                await Task.Delay(2000);
            }
        }
        finally
        {
            // Always attempt to return to the original ExpertQuote window and dismiss the
            // "Checklist Opened" modal, even if a checklist action above failed, so the
            // outer scenario is not left stuck on the checklist popup.
            await Task.Delay(8000);
            await browser.SwitchToFirstPageAsync();
            await Task.Delay(5000);
            await page.ClickChecklistOpenedOKAsync();
            await Task.Delay(7000);
        }

    }

    [Given(@"^I click Refer to UW$")]
    [When(@"^I click Refer to UW$")]
    [Then(@"^I click Refer to UW$")]
    public async Task ClickReferToUWAsync()
    {
        var underwritingPage = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await Task.Delay(2000);
        await underwritingPage.ClickReferToUWAsync();
        await Task.Delay(2000);
    }


    [Given(@"^I navigate to the required policy screen for subsequent screen 0310$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0310$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0310$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0310Async()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (!await page.IsScreen4475CPresentAsync())
        {
                    await page.ClickScreen4475CAsync();
        }
        if (data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
                    await page.ClickKeepGoingAsync();
        }
        if (!await page.IsLoadingPresentAsync())
        {
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.WaitForScreenHeading9696CAsync("Exists");
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.VerifyScreenHeading9696CAsync("Absent", "");
        }
        if (!await page.IsScreen4475CPresentAsync())
        {
                    await page.ClickScreen4475CAsync();
        }
        if (data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
                    await page.ClickKeepGoingAsync();
        }
        if (!await page.IsLoadingPresentAsync())
        {
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.WaitForScreenHeading9696CAsync("Exists");
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.VerifyScreenHeading9696CAsync("Absent", "");
        }
        if (!await page.IsScreen4475CPresentAsync())
        {
                    await page.ClickScreen4475CAsync();
        }
        if (data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
                    await page.ClickKeepGoingAsync();
        }
        if (!await page.IsLoadingPresentAsync())
        {
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.WaitForScreenHeading9696CAsync("Exists");
        }

    }

    [Given(@"^I complete insurance Score and premium Verification$")]
    [When(@"^I complete insurance Score and premium Verification$")]
    [Then(@"^I complete insurance Score and premium Verification$")]
    public async Task CompleteInsuranceScoreAndPremiumVerificationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        data.Set("Premium", await page.CapturePremiumAsync("InnerText"));
        await page.VerifyTABLERowCellExplicitName1Async(data.Resolve("{{data:expected_table_row_cell_explicitname_1_390}}"), "");
        if (!await page.IsScreenHeadingPresentAsync())
        {
                    await page.VerifyScreenHeadingAsync("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0336$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0336$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0336$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0336Async()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (!await page.IsScreen4475CPresentAsync())
        {
                    await page.ClickScreen4475CAsync();
        }
        if (data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
                    await page.ClickKeepGoingAsync();
        }
        if (!await page.IsLoadingPresentAsync())
        {
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.WaitForScreenHeading9696CAsync("Exists");
        }

    }

    [Given(@"^I open EQ in Browser$")]
    [When(@"^I open EQ in Browser$")]
    [Then(@"^I open EQ in Browser$")]
    public async Task OpenEQInBrowserAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.NavigateAsync(data.Resolve("{{data:application_url}}"));
        await page.NavigateAsync(data.Resolve("{{data:application_url_2}}"));
        await page.WaitForBODYAsync("Exists");
        await page.NoteAsync("Source operation requires environment-specific implementation.");

    }

    [Given(@"^I complete restart Edge Popup$")]
    [When(@"^I complete restart Edge Popup$")]
    [Then(@"^I complete restart Edge Popup$")]
    public async Task CompleteRestartEdgePopupAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsEChecklistEChecklistOKPresentAsync())
        {
                    await page.VerifyEChecklistEChecklistOKAsync("Exists", "");
        }
        if (await page.IsEChecklistEChecklistOKPresentAsync())
        {
                    await page.ClickEChecklistEChecklistOKAsync();
        }

    }

    [Given(@"^I open EQ in Browser for logout$")]
    [When(@"^I open EQ in Browser for logout$")]
    [Then(@"^I open EQ in Browser for logout$")]
    public async Task OpenEQInBrowserForLogoutAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsLogoutPresentAsync())
        {
                    await page.VerifyLogoutAsync("Exists", "");
        }
        if (await page.IsLogoutPresentAsync())
        {
                    await page.ClickLogoutAsync();
        }
        if (await page.IsLogoutLogOutPresentAsync())
        {
                    await page.ClickLogoutLogOutAsync();
        }

    }

    [Given(@"^I sign in to ExpertQuote$")]
    [When(@"^I sign in to ExpertQuote$")]
    [Then(@"^I sign in to ExpertQuote$")]
    public async Task SignInToExpertQuoteAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForUsernameAsync("Exists");
        await Auth.SignInAsync("CL_EQ");

    }

    [Given(@"^I search by QuoteNum$")]
    [When(@"^I search by QuoteNum$")]
    [Then(@"^I search by QuoteNum$")]
    public async Task SearchByQuoteNumAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.EnterQuoteSearchInputAsync(data.Resolve("{B[Quote_Num]}"));
        await page.ClickClientInfoSearchAsync();

    }

    [Given(@"^I search Results Table$")]
    [When(@"^I search Results Table$")]
    [Then(@"^I search Results Table$")]
    public async Task SearchResultsTableAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsResultsTABLEPresentAsync())
        {
                    await page.VerifyResultsTABLEAsync("Exists", "");
        }
        if (await page.IsResultsTABLERowCellExplicitNameNamePresentAsync())
        {
                    await page.VerifyResultsTABLERowCellExplicitNameNameAsync(data.Resolve("{STRINGTOUPPER[{B[LastName]}, {B[FirstName]}]}"), "");
        }
        if (await page.IsEditPresentAsync())
        {
                    await page.ClickEditAsync();
        }
        if (await page.IsNameAndQuoteNumCA893PresentAsync())
        {
                    await page.WaitForNameAndQuoteNumCA893Async("NotEqual");
        }
        if (await page.IsNameAndQuoteNumCA893PresentAsync())
        {
                    await page.VerifyNameAndQuoteNumCA893Async(data.Resolve("{B[NameQuoteNum]}|{B[Quote_Num]}|{B[Policy#]}"), "Regex:InnerText");
        }

    }

    [Given(@"^I open a CLAS Browser and Search for EQ by Description$")]
    [When(@"^I open a CLAS Browser and Search for EQ by Description$")]
    [Then(@"^I open a CLAS Browser and Search for EQ by Description$")]
    public async Task OpenACLASBrowserAndSearchForEQByDescriptionAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.NavigateAsync(data.Resolve("{{data:application_url}}"));
        await page.NavigateAsync(data.Resolve("{{data:application_url_3}}"));
        await page.WaitForBODYABC33Async("Exists");
        await page.NoteAsync("Source operation requires environment-specific implementation.");
        if (await page.IsButtonPresentAsync())
        {
                    await page.VerifyButtonAsync("Exists", "");
        }
        if (await page.IsButtonPresentAsync())
        {
                    await page.ClickButtonAsync();
        }
        if (await page.IsUserNameE65A8PresentAsync())
        {
                    await page.VerifyUserNameE65A8Async("Absent", "");
        }

    }

    [Given(@"^I sign out of the application$")]
    [When(@"^I sign out of the application$")]
    [Then(@"^I sign out of the application$")]
    public async Task SignOutOfTheApplicationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsLoggedInUser5A005PresentAsync())
        {
                    await page.ClickLoggedInUser5A005Async();
        }
        if (await page.IsLogoutPresentAsync())
        {
                    await page.ClickLogoutAsync();
        }
        // Source conditional not executed because no deterministic data/DOM condition was available: if an existing CLAS session is still logged in
        if (false)
        {
                    await page.NoteAsync("Source operation requires environment-specific implementation.");
        }
        if (await page.IsTheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus06F740PresentAsync())
        {
                    await page.VerifyTheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus06F740Async("Exists", "");
        }
        if (await page.IsEChecklistEChecklistOKPresentAsync())
        {
                    await page.ClickEChecklistEChecklistOKAsync();
        }
        if (await page.IsEChecklistEChecklistOKPresentAsync())
        {
                    await page.WaitForEChecklistEChecklistOKAsync("Absent");
        }
        if (await page.IsLoggedInUser5A005PresentAsync())
        {
                    await page.ClickLoggedInUser5A005Async();
        }
        if (await page.IsLogoutPresentAsync())
        {
                    await page.ClickLogoutAsync();
        }

    }

    [Given(@"^I open a CLAS Browser and Search for EQ by Description for cl dc$")]
    [When(@"^I open a CLAS Browser and Search for EQ by Description for cl dc$")]
    [Then(@"^I open a CLAS Browser and Search for EQ by Description for cl dc$")]
    public async Task OpenACLASBrowserAndSearchForEQByDescriptionForClDcAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        // Source conditional not executed because no deterministic data/DOM condition was available: if an existing CLAS session is still logged in
        if (false)
        {
                    await page.NavigateAsync(data.Resolve("{{data:application_url_3}}"));
        }
        await Auth.SignInAsync("CL_DC");
        await page.WaitForLoginC45A2Async("Absent");

    }

    [Given(@"^I search by Desc in DC$")]
    [When(@"^I search by Desc in DC$")]
    [Then(@"^I search by Desc in DC$")]
    public async Task SearchByDescInDCAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.EnterSearchTextAsync(data.Resolve("{B[QuoteDescription]}"));
        await page.ClickQuickSearchButtonAsync();
        await page.WaitForSearchButtonAsync("Equal");
        await page.ClickSearchButtonAsync();
        if (await page.IsLoadingMessageC7A0DPresentAsync())
        {
                    await page.VerifyLoadingMessageC7A0DAsync("Visible", "");
        }
        await page.WaitForViewPolicy56E09Async("Exists");
        await page.ClickSearchButtonAsync();
        if (await page.IsLoadingMessageC7A0DPresentAsync())
        {
                    await page.VerifyLoadingMessageC7A0DAsync("Visible", "");
        }

    }

    [Given(@"^I open a CLAS Browser and Search for EQ by Description for view policy$")]
    [When(@"^I open a CLAS Browser and Search for EQ by Description for view policy$")]
    [Then(@"^I open a CLAS Browser and Search for EQ by Description for view policy$")]
    public async Task OpenACLASBrowserAndSearchForEQByDescriptionForViewPolicyAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForViewPolicy0AC0BAsync("Exists");
        if (await page.IsLoadingMessage4DE37PresentAsync())
        {
                    await page.VerifyLoadingMessage4DE37Async("Visible", "");
        }
        await page.ClickViewPolicy0AC0BAsync();
        if (await page.IsLoadingMessage4DE37PresentAsync())
        {
                    await page.VerifyLoadingMessage4DE37Async("Visible", "");
        }
        await page.WaitForViewPolicy0AC0BAsync("Absent");
        await page.NoteAsync("Source operation requires environment-specific implementation.");

    }

    [Given(@"^I complete forms verification Retrieve QuoteID \& SessionID by Browser Console$")]
    [When(@"^I complete forms verification Retrieve QuoteID \& SessionID by Browser Console$")]
    [Then(@"^I complete forms verification Retrieve QuoteID \& SessionID by Browser Console$")]
    public async Task CompleteFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsoleAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.NoteAsync("Browser-console/forms verification requires environment-specific implementation.");
        await page.PauseAsync(1000);
        await page.NoteAsync("Browser-console/forms verification requires environment-specific implementation.");
        await page.NoteAsync("Browser-console/forms verification requires environment-specific implementation.");
        await page.NoteAsync("Browser-console/forms verification requires environment-specific implementation.");
        await page.EnterFormsAPIRequestB50D4Async(data.Resolve("{{runtime:SessionId}}"));
        await page.EnterFormsAPIResponse3FBAFAsync(data.Resolve("{{data:forms_api_response_494}}"));
        await page.NoteAsync("Browser-console/forms verification requires environment-specific implementation.");
        await page.NoteAsync("Browser-console/forms verification requires environment-specific implementation.");

    }

    [Given(@"^I complete save for Later/Return to Admin$")]
    [When(@"^I complete save for Later/Return to Admin$")]
    [Then(@"^I complete save for Later/Return to Admin$")]
    public async Task CompleteSaveForLaterReturnToAdminAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsSaveForLaterPresentAsync())
        {
                    await page.VerifySaveForLaterAsync("Exists", "");
        }
        if (await page.IsSaveForLaterPresentAsync())
        {
                    await page.ClickSaveForLaterAsync();
        }
        if (await page.IsSaveForLaterOKPresentAsync())
        {
                    await page.WaitForSaveForLaterOKAsync("Exists");
        }
        if (await page.IsSaveForLaterOKPresentAsync())
        {
                    await page.ClickSaveForLaterOKAsync();
        }
        if (await page.IsReturnToAdminPresentAsync())
        {
                    await page.VerifyReturnToAdminAsync("Exists", "");
        }
        if (await page.IsReturnToAdminPresentAsync())
        {
                    await page.ClickReturnToAdminAsync();
        }
        if (await page.IsReturnToAdminPresentAsync())
        {
                    await page.WaitForReturnToAdminAsync("Absent");
        }

    }

    [Given(@"^I open EQ in Browser for body$")]
    [When(@"^I open EQ in Browser for body$")]
    [Then(@"^I open EQ in Browser for body$")]
    public async Task OpenEQInBrowserForBodyAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.NavigateAsync(data.Resolve("{{data:application_url}}"));
        await page.NavigateAsync(data.Resolve("{{data:application_url_2}}"));
        await page.WaitForBODYAsync("Exists");
        await page.NoteAsync("Source operation requires environment-specific implementation.");

    }

    [Given(@"^I complete restart Edge Popup for ok$")]
    [When(@"^I complete restart Edge Popup for ok$")]
    [Then(@"^I complete restart Edge Popup for ok$")]
    public async Task CompleteRestartEdgePopupForOkAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsEChecklistEChecklistOKPresentAsync())
        {
                    await page.VerifyEChecklistEChecklistOKAsync("Exists", "");
        }
        if (await page.IsEChecklistEChecklistOKPresentAsync())
        {
                    await page.ClickEChecklistEChecklistOKAsync();
        }

    }

    [Given(@"^I open EQ in Browser for open eq in browser$")]
    [When(@"^I open EQ in Browser for open eq in browser$")]
    [Then(@"^I open EQ in Browser for open eq in browser$")]
    public async Task OpenEQInBrowserForOpenEqInBrowserAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsLogoutPresentAsync())
        {
                    await page.VerifyLogoutAsync("Exists", "");
        }
        if (await page.IsLogoutPresentAsync())
        {
                    await page.ClickLogoutAsync();
        }
        if (await page.IsLogoutLogOutPresentAsync())
        {
                    await page.ClickLogoutLogOutAsync();
        }

    }

    [Given(@"^I sign in to ExpertQuote for username$")]
    [When(@"^I sign in to ExpertQuote for username$")]
    [Then(@"^I sign in to ExpertQuote for username$")]
    public async Task SignInToExpertQuoteForUsernameAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForUsernameAsync("Exists");
        await Auth.SignInAsync("CL_EQ");

    }

    [Given(@"^I search by QuoteNum for quotesearchinput$")]
    [When(@"^I search by QuoteNum for quotesearchinput$")]
    [Then(@"^I search by QuoteNum for quotesearchinput$")]
    public async Task SearchByQuoteNumForQuotesearchinputAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.EnterQuoteSearchInputAsync(data.Resolve("{B[Quote_Num]}"));
        await page.ClickClientInfoSearchAsync();

    }

    [Given(@"^I search Results Table for results table$")]
    [When(@"^I search Results Table for results table$")]
    [Then(@"^I search Results Table for results table$")]
    public async Task SearchResultsTableForResultsTableAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsResultsTABLEPresentAsync())
        {
                    await page.VerifyResultsTABLEAsync("Exists", "");
        }
        if (await page.IsResultsTABLERowCellExplicitNameNamePresentAsync())
        {
                    await page.VerifyResultsTABLERowCellExplicitNameNameAsync(data.Resolve("{STRINGTOUPPER[{B[LastName]}, {B[FirstName]}]}"), "");
        }
        if (await page.IsEditPresentAsync())
        {
                    await page.ClickEditAsync();
        }
        if (await page.IsNameAndQuoteNumCA893PresentAsync())
        {
                    await page.WaitForNameAndQuoteNumCA893Async("NotEqual");
        }
        if (await page.IsNameAndQuoteNumCA893PresentAsync())
        {
                    await page.VerifyNameAndQuoteNumCA893Async(data.Resolve("{B[NameQuoteNum]}|{B[Quote_Num]}|{B[Policy#]}"), "Regex:InnerText");
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.VerifyScreenHeading9696CAsync("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0502$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0502$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0502$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0502Async()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (!await page.IsScreen4475CPresentAsync())
        {
                    await page.ClickScreen4475CAsync();
        }
        if (data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
                    await page.ClickKeepGoingAsync();
        }
        if (!await page.IsLoadingPresentAsync())
        {
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.WaitForScreenHeading9696CAsync("Exists");
        }

    }

    [Given(@"^I complete checklist and Esign$")]
    [When(@"^I complete checklist and Esign$")]
    [Then(@"^I complete checklist and Esign$")]
    public async Task CompleteChecklistAndEsignAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForSubmissionScreenHeadingAsync("Exists");
        if (data.Condition("'Referral Needed' != NULL"))
        {
                    await page.VerifyNoReferralNeededVerificationAsync("Absent", "");
        }
        await page.ClickLaunchToChecklistButtonAsync();
        if (data.Condition("'Referral Needed' == NULL"))
        {
                    await page.VerifyNoReferralNeededVerificationAsync("Exists", "");
        }

    }

    [Given(@"^I complete eChecklist \- Building Photo1$")]
    [When(@"^I complete eChecklist \- Building Photo1$")]
    [Then(@"^I complete eChecklist \- Building Photo1$")]
    public async Task CompleteEChecklistBuildingPhoto1Async()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickBuildingPhoto1Async();
        await page.WaitForBuildingPhoto1HeaderAsync("Exists");
        await page.ClickExceptionAsync();
        await page.EnterAddANoteAsync(data.Resolve("{{data:add_a_note_561}}"));
        await page.ClickEChecklistEChecklistOKAsync();
        await page.WaitForEChecklistEChecklistOKAsync("Absent");
        await page.WaitForBuildingPhoto1HeaderAsync("Absent");

    }

    [Given(@"^I complete eChecklist \- Building Photo2$")]
    [When(@"^I complete eChecklist \- Building Photo2$")]
    [Then(@"^I complete eChecklist \- Building Photo2$")]
    public async Task CompleteEChecklistBuildingPhoto2Async()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForBuildingPhoto2HeaderAsync("Exists");
        await page.ClickExceptionAsync();
        await page.EnterAddANoteAsync(data.Resolve("{{data:add_a_note_567}}"));
        await page.ClickEChecklistEChecklistOKAsync();
        await page.WaitForEChecklistEChecklistOKAsync("Absent");
        await page.WaitForBuildingPhoto2Async("Absent");

    }

    [Given(@"^I complete eChecklist \- Building Photo3$")]
    [When(@"^I complete eChecklist \- Building Photo3$")]
    [Then(@"^I complete eChecklist \- Building Photo3$")]
    public async Task CompleteEChecklistBuildingPhoto3Async()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForBuildingPhoto3HeaderAsync("Exists");
        await page.ClickExceptionAsync();
        await page.EnterAddANoteAsync(data.Resolve("{{data:add_a_note_573}}"));
        await page.ClickEChecklistEChecklistOKAsync();
        await page.WaitForEChecklistEChecklistOKAsync("Absent");
        await page.WaitForBuildingPhoto3Async("Absent");

    }

    [Given(@"^I complete eChecklist \- Building Photo4$")]
    [When(@"^I complete eChecklist \- Building Photo4$")]
    [Then(@"^I complete eChecklist \- Building Photo4$")]
    public async Task CompleteEChecklistBuildingPhoto4Async()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForBuildingPhoto4HeaderAsync("Exists");
        await page.ClickExceptionAsync();
        await page.EnterAddANoteAsync(data.Resolve("{{data:add_a_note_579}}"));
        await page.ClickEChecklistEChecklistOKAsync();
        await page.WaitForEChecklistEChecklistOKAsync("Absent");
        await page.WaitForBuildingPhoto4Async("Absent");

    }

    [Given(@"^I complete eChecklist \- Loss Runs \- 3 Years$")]
    [When(@"^I complete eChecklist \- Loss Runs \- 3 Years$")]
    [Then(@"^I complete eChecklist \- Loss Runs \- 3 Years$")]
    public async Task CompleteEChecklistLossRuns3YearsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LossHistoryPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.EnterAllLinkAsync("");
        await page.WaitForLossRunsHeaderAsync("Exists");
        await page.ClickExceptionAsync();
        await page.WaitForAddANoteAsync("Visible");
        await page.ClickEChecklistEChecklistOKAsync();
        await page.WaitForEChecklistEChecklistOKAsync("Absent");
        await page.WaitForLossRuns3YearsHeaderAsync("Absent");

    }

    [Given(@"^I select OK$")]
    [When(@"^I select OK$")]
    [Then(@"^I select OK$")]
    public async Task SelectOKAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickOkToUpdateFromChecklistAsync();
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.VerifyScreenHeading9696CAsync("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen for refer to uw in eq$")]
    [When(@"^I navigate to the required policy screen for refer to uw in eq$")]
    [Then(@"^I navigate to the required policy screen for refer to uw in eq$")]
    public async Task NavigateToTheRequiredPolicyScreenForReferToUwInEqAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (!await page.IsScreen4475CPresentAsync())
        {
                    await page.ClickScreen4475CAsync();
        }
        if (data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
                    await page.ClickKeepGoingAsync();
        }
        if (!await page.IsLoadingPresentAsync())
        {
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.WaitForScreenHeading9696CAsync("Exists");
        }
        await page.PauseAsync(1000);

    }

    [Given(@"^I refer to UW$")]
    [When(@"^I refer to UW$")]
    [Then(@"^I refer to UW$")]
    public async Task ReferToUWAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.PressUnderwritingRulesAgentCommentsAsync("ENTER");
        await page.ClickReferToUWAsync();

    }

    [Given(@"^I open a CLAS Browser and Search for EQ by Description for body$")]
    [When(@"^I open a CLAS Browser and Search for EQ by Description for body$")]
    [Then(@"^I open a CLAS Browser and Search for EQ by Description for body$")]
    public async Task OpenACLASBrowserAndSearchForEQByDescriptionForBodyAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.NavigateAsync(data.Resolve("{{data:application_url}}"));
        await page.NavigateAsync(data.Resolve("{{data:application_url_3}}"));
        await page.WaitForBODYABC33Async("Exists");
        await page.NoteAsync("Source operation requires environment-specific implementation.");
        if (await page.IsButtonPresentAsync())
        {
                    await page.VerifyButtonAsync("Exists", "");
        }
        if (await page.IsButtonPresentAsync())
        {
                    await page.ClickButtonAsync();
        }
        if (await page.IsUserNameE65A8PresentAsync())
        {
                    await page.VerifyUserNameE65A8Async("Absent", "");
        }

    }

    [Given(@"^I sign out of the application for logged in user$")]
    [When(@"^I sign out of the application for logged in user$")]
    [Then(@"^I sign out of the application for logged in user$")]
    public async Task SignOutOfTheApplicationForLoggedInUserAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsLoggedInUser5A005PresentAsync())
        {
                    await page.ClickLoggedInUser5A005Async();
        }
        if (await page.IsLogoutPresentAsync())
        {
                    await page.ClickLogoutAsync();
        }
        // Source conditional not executed because no deterministic data/DOM condition was available: if an existing CLAS session is still logged in
        if (false)
        {
                    await page.NoteAsync("Source operation requires environment-specific implementation.");
        }
        if (await page.IsTheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus06F740PresentAsync())
        {
                    await page.VerifyTheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus06F740Async("Exists", "");
        }
        if (await page.IsEChecklistEChecklistOKPresentAsync())
        {
                    await page.ClickEChecklistEChecklistOKAsync();
        }
        if (await page.IsEChecklistEChecklistOKPresentAsync())
        {
                    await page.WaitForEChecklistEChecklistOKAsync("Absent");
        }
        if (await page.IsLoggedInUser5A005PresentAsync())
        {
                    await page.ClickLoggedInUser5A005Async();
        }
        if (await page.IsLogoutPresentAsync())
        {
                    await page.ClickLogoutAsync();
        }

    }

    [Given(@"^I open a CLAS Browser and Search for EQ by Description for open a clas browser and search for eq by description$")]
    [When(@"^I open a CLAS Browser and Search for EQ by Description for open a clas browser and search for eq by description$")]
    [Then(@"^I open a CLAS Browser and Search for EQ by Description for open a clas browser and search for eq by description$")]
    public async Task OpenACLASBrowserAndSearchForEQByDescriptionForOpenAClasBrowserAndSearchForEqByDescriptionAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        // Source conditional not executed because no deterministic data/DOM condition was available: if an existing CLAS session is still logged in
        if (false)
        {
                    await page.NavigateAsync(data.Resolve("{{data:application_url_3}}"));
        }
        await Auth.SignInAsync("CL_DC");
        await page.WaitForLoginC45A2Async("Absent");

    }

    [Given(@"^I search by Desc in DC for search text$")]
    [When(@"^I search by Desc in DC for search text$")]
    [Then(@"^I search by Desc in DC for search text$")]
    public async Task SearchByDescInDCForSearchTextAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.EnterSearchTextAsync(data.Resolve("{B[QuoteDescription]}"));
        await page.ClickQuickSearchButtonAsync();
        await page.WaitForSearchButtonAsync("Equal");
        await page.ClickSearchButtonAsync();
        if (await page.IsLoadingMessageC7A0DPresentAsync())
        {
                    await page.VerifyLoadingMessageC7A0DAsync("Visible", "");
        }
        await page.WaitForViewPolicy56E09Async("Exists");
        await page.ClickSearchButtonAsync();
        if (await page.IsLoadingMessageC7A0DPresentAsync())
        {
                    await page.VerifyLoadingMessageC7A0DAsync("Visible", "");
        }

    }

    [Given(@"^I open a CLAS Browser and Search for EQ by Description for verify view policy$")]
    [When(@"^I open a CLAS Browser and Search for EQ by Description for verify view policy$")]
    [Then(@"^I open a CLAS Browser and Search for EQ by Description for verify view policy$")]
    public async Task OpenACLASBrowserAndSearchForEQByDescriptionForVerifyViewPolicyAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForViewPolicy0AC0BAsync("Exists");
        if (await page.IsLoadingMessage4DE37PresentAsync())
        {
                    await page.VerifyLoadingMessage4DE37Async("Visible", "");
        }
        await page.ClickViewPolicy0AC0BAsync();
        if (await page.IsLoadingMessage4DE37PresentAsync())
        {
                    await page.VerifyLoadingMessage4DE37Async("Visible", "");
        }
        await page.WaitForViewPolicy0AC0BAsync("Absent");

    }

    [Given(@"^I navigate to Submission Screen$")]
    [When(@"^I navigate to Submission Screen$")]
    [Then(@"^I navigate to Submission Screen$")]
    public async Task NavigateToSubmissionScreenAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForSubmission48772Async("Visible");
        await page.ClickSubmission48772Async();
        if (await page.IsSubmissionHeadingPresentAsync())
        {
                    await page.VerifySubmissionHeadingAsync("Absent", "");
        }
        if (await page.IsSubmission7E601PresentAsync())
        {
        }
        if (await page.IsSubmission7E601PresentAsync())
        {
                    await page.ClickSubmission7E601Async();
        }
        // Source conditional not executed because no deterministic data/DOM condition was available: if determine if on submission page
        if (false)
        {
                    await page.PauseAsync(1000);
        }
        if (await page.IsSubmissionHeadingPresentAsync())
        {
                    await page.WaitForSubmissionHeadingAsync("Exists");
        }
        // Source conditional not executed because no deterministic data/DOM condition was available: if determine if on submission page
        if (false)
        {
                    await page.PauseAsync(1000);
        }

    }

    [Given(@"^I run Stoplight$")]
    [When(@"^I run Stoplight$")]
    [Then(@"^I run Stoplight$")]
    public async Task RunStoplightAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsIsThisCoverageBoundPresentAsync())
        {
                    await page.VerifyIsThisCoverageBoundAsync("Exists", "");
        }
        if (await page.IsIsThisCoverageBoundPresentAsync())
        {
                    await page.VerifyIsThisCoverageBoundAsync(data.Resolve("{{data:expected_is_this_coverage_bound_661}}"), "");
        }
        if (await page.IsIsThisCoverageBoundPresentAsync())
        {
        }
        await page.ClickCompleteApplicationAsync();
        if (await page.IsClosePresentAsync())
        {
                    await page.VerifyCloseAsync("Absent", "");
        }
        // Source conditional not executed because no deterministic data/DOM condition was available: during do (Wait for Stoplight to Run) [max=90]
        if (false)
        {
                    await page.PauseAsync(1000);
        }
        if (await page.IsStoplightWaitingWindowErrorPresentAsync())
        {
                    await page.VerifyStoplightWaitingWindowErrorAsync("Exists", "");
        }
        if (await page.IsStoplightWaitingWindowFirstCloseButtonOnErrorPresentAsync())
        {
                    await page.ClickStoplightWaitingWindowFirstCloseButtonOnErrorAsync();
        }
        // Source conditional not executed because no deterministic data/DOM condition was available: during do (Wait for Stoplight to Run) [max=90]
        if (false)
        {
                    await page.PauseAsync(1000);
        }
        if (await page.IsCompleteApplicationPresentAsync())
        {
                    await page.ClickCompleteApplicationAsync();
        }
        // Source conditional not executed because no deterministic data/DOM condition was available: during do (Wait for Stoplight to Run) [max=90]
        if (false)
        {
                    await page.PauseAsync(1000);
        }
        await page.ClickCloseAsync();
        await page.WaitForStoplightWaitingWindowAsync("Absent");
        if (await page.IsLoadingMessagePresentAsync())
        {
                    await page.VerifyLoadingMessageAsync("Visible", "");
        }
        await page.WaitForAllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabsAsync("Exists");
        await page.VerifyAllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabsAsync("Exists", "");
        await page.PauseAsync(1000);
        if (await page.IsLoadingMessagePresentAsync())
        {
                    await page.VerifyLoadingMessageAsync("Visible", "");
        }
        if (await page.IsAllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabsPresentAsync())
        {
                    await page.VerifyAllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabsAsync("Exists", "");
        }
        if (await page.IsCompleteApplicationPresentAsync())
        {
                    await page.ClickCompleteApplicationAsync();
        }
        if (await page.IsClosePresentAsync())
        {
                    await page.VerifyCloseAsync("Absent", "");
        }
        // Source conditional not executed because no deterministic data/DOM condition was available: if stoplight error
        if (false)
        {
                    await page.PauseAsync(1000);
        }
        if (await page.IsStoplightWaitingWindowErrorPresentAsync())
        {
                    await page.VerifyStoplightWaitingWindowErrorAsync("Exists", "");
        }
        if (await page.IsStoplightWaitingWindowFirstCloseButtonOnErrorPresentAsync())
        {
                    await page.ClickStoplightWaitingWindowFirstCloseButtonOnErrorAsync();
        }
        // Source conditional not executed because no deterministic data/DOM condition was available: if stoplight error
        if (false)
        {
                    await page.PauseAsync(1000);
        }
        if (await page.IsCompleteApplicationPresentAsync())
        {
                    await page.ClickCompleteApplicationAsync();
        }
        // Source conditional not executed because no deterministic data/DOM condition was available: if stoplight error
        if (false)
        {
                    await page.PauseAsync(1000);
        }
        if (await page.IsClosePresentAsync())
        {
                    await page.ClickCloseAsync();
        }
        if (await page.IsStoplightWaitingWindowPresentAsync())
        {
                    await page.WaitForStoplightWaitingWindowAsync("Absent");
        }
        // Source conditional not executed because no deterministic data/DOM condition was available: if stoplight error
        if (false)
        {
                    await page.PauseAsync(1000);
        }
        await page.VerifyAllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabsAsync("Absent", "");

    }

    [Given(@"^I refer Application/Policy$")]
    [When(@"^I refer Application/Policy$")]
    [Then(@"^I refer Application/Policy$")]
    public async Task ReferApplicationPolicyAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsReferRequestIssuancePresentAsync())
        {
                    await page.VerifyReferRequestIssuanceAsync("Absent", "");
        }
        if (await page.IsIsThisCoverageBoundPresentAsync())
        {
                    await page.VerifyIsThisCoverageBoundAsync("Exists", "");
        }
        if (await page.IsIsThisCoverageBoundPresentAsync())
        {
                    await page.VerifyIsThisCoverageBoundAsync(data.Resolve("{{data:expected_is_this_coverage_bound_value_698}}"), "Value");
        }
        if (await page.IsIsThisCoverageBoundPresentAsync())
        {
        }
        if (data.Condition("'Refer Needed' == NULL"))
        {
                    await page.ClickReferRequestIssuanceAsync();
        }
        if (data.Condition("'Refer Needed' != NULL"))
        {
                    await page.ClickApproveAsync();
        }
        await page.WaitForIFRAMEDuckCreekPolicyIFRAMEOKAsync("Exists");
        await page.ClickIFRAMEDuckCreekPolicyIFRAMEOKAsync();
        if (await page.IsIFRAMEPresentAsync())
        {
                    await page.VerifyIFRAMEAsync("Exists", "");
        }
        // Source conditional not executed because no deterministic data/DOM condition was available: while check for IFRAME
        if (false)
        {
                    await page.PauseAsync(1000);
        }

    }

    [Given(@"^I complete alert Error Check$")]
    [When(@"^I complete alert Error Check$")]
    [Then(@"^I complete alert Error Check$")]
    public async Task CompleteAlertErrorCheckAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsAlertErrorMessageBoxPolicyNumberExistsForThisQuoteNumbePresentAsync())
        {
                    await page.VerifyAlertErrorMessageBoxPolicyNumberExistsForThisQuoteNumbeAsync("Exists", "");
        }
        // Source conditional not executed because no deterministic data/DOM condition was available: while check for IFRAME
        if (false)
        {
        }
        if (await page.IsIFRAMEPresentAsync())
        {
                    await page.VerifyIFRAMEAsync("Exists", "");
        }
        if (await page.IsIFRAMEDuckCreekPolicyAlertErrorMessagePresentAsync())
        {
                    await page.VerifyIFRAMEDuckCreekPolicyAlertErrorMessageAsync("Exists", "");
        }
        // Source conditional not executed because no deterministic data/DOM condition was available: while check for IFRAME
        if (false)
        {
        }
        await page.PauseAsync(1000);
        await page.WaitForTransactionTypeAsync("Exists");

    }

    [Given(@"^I refer Application/Policy for table row cell link$")]
    [When(@"^I refer Application/Policy for table row cell link$")]
    [Then(@"^I refer Application/Policy for table row cell link$")]
    public async Task ReferApplicationPolicyForTableRowCellLinkAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BillingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyTableRowCellLinkAsync("Exists", "");
        await page.WaitForBillingAsync("Exists");

    }

    [Given(@"^I complete save for Later/Return to Admin for save for later$")]
    [When(@"^I complete save for Later/Return to Admin for save for later$")]
    [Then(@"^I complete save for Later/Return to Admin for save for later$")]
    public async Task CompleteSaveForLaterReturnToAdminForSaveForLaterAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsSaveForLaterPresentAsync())
        {
                    await page.VerifySaveForLaterAsync("Exists", "");
        }
        if (await page.IsSaveForLaterPresentAsync())
        {
                    await page.ClickSaveForLaterAsync();
        }
        if (await page.IsSaveForLaterOKPresentAsync())
        {
                    await page.WaitForSaveForLaterOKAsync("Exists");
        }
        if (await page.IsSaveForLaterOKPresentAsync())
        {
                    await page.ClickSaveForLaterOKAsync();
        }
        if (await page.IsReturnToAdminPresentAsync())
        {
                    await page.VerifyReturnToAdminAsync("Exists", "");
        }
        if (await page.IsReturnToAdminPresentAsync())
        {
                    await page.ClickReturnToAdminAsync();
        }
        if (await page.IsReturnToAdminPresentAsync())
        {
                    await page.WaitForReturnToAdminAsync("Absent");
        }

    }

    [Given(@"^I complete retreive Policy Number After Referral$")]
    [When(@"^I complete retreive Policy Number After Referral$")]
    [Then(@"^I complete retreive Policy Number After Referral$")]
    public async Task CompleteRetreivePolicyNumberAfterReferralAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickViewPolicyDetails848D5Async();
        if (await page.IsPolicyDetailsE7F69PresentAsync())
        {
                    await page.VerifyPolicyDetailsE7F69Async("Absent", "");
        }
        // Source conditional not executed because no deterministic data/DOM condition was available: during loop to Check if Policy Details Exists [max=120]
        if (false)
        {
                    await page.PauseAsync(1000);
        }
        data.Set("Policy#", await page.CapturePolicyNumberAsync("InnerText"));

    }

    [Given(@"^I open EQ in Browser for open a browser$")]
    [When(@"^I open EQ in Browser for open a browser$")]
    [Then(@"^I open EQ in Browser for open a browser$")]
    public async Task OpenEQInBrowserForOpenABrowserAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.NavigateAsync(data.Resolve("{{data:application_url}}"));
        await page.NavigateAsync(data.Resolve("{{data:application_url_2}}"));
        await page.WaitForBODYAsync("Exists");
        await page.NoteAsync("Source operation requires environment-specific implementation.");

    }

    [Given(@"^I complete restart Edge Popup for restart edge popup$")]
    [When(@"^I complete restart Edge Popup for restart edge popup$")]
    [Then(@"^I complete restart Edge Popup for restart edge popup$")]
    public async Task CompleteRestartEdgePopupForRestartEdgePopupAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsEChecklistEChecklistOKPresentAsync())
        {
                    await page.VerifyEChecklistEChecklistOKAsync("Exists", "");
        }
        if (await page.IsEChecklistEChecklistOKPresentAsync())
        {
                    await page.ClickEChecklistEChecklistOKAsync();
        }

    }

    [Given(@"^I open EQ in Browser for check if logout exists$")]
    [When(@"^I open EQ in Browser for check if logout exists$")]
    [Then(@"^I open EQ in Browser for check if logout exists$")]
    public async Task OpenEQInBrowserForCheckIfLogoutExistsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsLogoutPresentAsync())
        {
                    await page.VerifyLogoutAsync("Exists", "");
        }
        if (await page.IsLogoutPresentAsync())
        {
                    await page.ClickLogoutAsync();
        }
        if (await page.IsLogoutLogOutPresentAsync())
        {
                    await page.ClickLogoutLogOutAsync();
        }

    }

    [Given(@"^I sign in to ExpertQuote for login to eq sso$")]
    [When(@"^I sign in to ExpertQuote for login to eq sso$")]
    [Then(@"^I sign in to ExpertQuote for login to eq sso$")]
    public async Task SignInToExpertQuoteForLoginToEqSsoAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForUsernameAsync("Exists");
        await Auth.SignInAsync("CL_EQ");

    }

    [Given(@"^I search by QuoteNum for search by quotenum$")]
    [When(@"^I search by QuoteNum for search by quotenum$")]
    [Then(@"^I search by QuoteNum for search by quotenum$")]
    public async Task SearchByQuoteNumForSearchByQuotenumAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.EnterQuoteSearchInputAsync(data.Resolve("{B[Quote_Num]}"));
        await page.ClickClientInfoSearchAsync();
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.VerifyScreenHeading9696CAsync("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0827$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0827$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0827$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0827Async()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (!await page.IsScreen4475CPresentAsync())
        {
                    await page.ClickScreen4475CAsync();
        }
        if (data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
                    await page.ClickKeepGoingAsync();
        }
        if (!await page.IsLoadingPresentAsync())
        {
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.WaitForScreenHeading9696CAsync("Exists");
        }

    }

    [Given(@"^I transmit to DC$")]
    [When(@"^I transmit to DC$")]
    [Then(@"^I transmit to DC$")]
    public async Task TransmitToDCAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickTransmitAsync();
        await page.VerifyTABLERowCellExplicitName1Async(data.Resolve("{{data:expected_table_row_cell_explicitname_1_767}}"), "");
        await page.VerifyTABLERowCellExplicitName2Async(data.Resolve("{{data:expected_table_row_cell_explicitname_2_768}}"), "");
        await page.VerifyTABLERowCellExplicitName4Async(data.Resolve("{{runtime:Policy#}}"), "");
        await page.VerifyTABLERowCellExplicitName5Async(data.Resolve("{{runtime:Premium}}"), "");
        await page.VerifyTABLERowCellExplicitName5Async(data.Resolve("{{data:expected_table_row_cell_explicitname_5_771}}"), "");

    }

    [Given(@"^I verify premium on DC$")]
    [When(@"^I verify premium on DC$")]
    [Then(@"^I verify premium on DC$")]
    public async Task VerifyPremiumOnDCAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyDCTransactionTableRowCellExplicitNameNewPremiumAsync(data.Resolve("{{data:expected_dc_transaction_table_row_cell_explicitname_new_premium_772}}"), "");
        await page.VerifyDCTransactionTableRowCellExplicitNameStatusAsync(data.Resolve("{{data:expected_dc_transaction_table_row_cell_explicitname_status_773}}"), "");

    }

    [Given(@"^I sign in to Duck Creek$")]
    [When(@"^I sign in to Duck Creek$")]
    [Then(@"^I sign in to Duck Creek$")]
    public async Task SignInToDuckCreekAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.NavigateAsync(data.Resolve("{{data:application_url}}"));
        // Source conditional not executed because no deterministic data/DOM condition was available: during loop for the Login [max=30]
        if (false)
        {
        }
        // Source conditional not executed because no deterministic data/DOM condition was available: during loop for the Login [max=30]
        if (false)
        {
                    await page.NavigateAsync(data.Resolve("{{data:application_url_4}}"));
        }
        if (await page.IsBODYPresentAsync())
        {
                    await page.WaitForBODYAsync("Exists");
        }
        // Source conditional not executed because no deterministic data/DOM condition was available: during loop for the Login [max=30]
        if (false)
        {
                    await page.NoteAsync("Source operation requires environment-specific implementation.");
        }

    }

    [Given(@"^I complete restart Edge Popup for restart microsoft edge message exists$")]
    [When(@"^I complete restart Edge Popup for restart microsoft edge message exists$")]
    [Then(@"^I complete restart Edge Popup for restart microsoft edge message exists$")]
    public async Task CompleteRestartEdgePopupForRestartMicrosoftEdgeMessageExistsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsEChecklistEChecklistOKPresentAsync())
        {
                    await page.VerifyEChecklistEChecklistOKAsync("Exists", "");
        }
        if (await page.IsEChecklistEChecklistOKPresentAsync())
        {
                    await page.ClickEChecklistEChecklistOKAsync();
        }

    }

    [Given(@"^I sign in to Duck Creek for logged in user$")]
    [When(@"^I sign in to Duck Creek for logged in user$")]
    [Then(@"^I sign in to Duck Creek for logged in user$")]
    public async Task SignInToDuckCreekForLoggedInUserAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsLoggedInUserPresentAsync())
        {
                    await page.VerifyLoggedInUserAsync("Exists", "");
        }

    }

    [Given(@"^I sign out of the application for logout$")]
    [When(@"^I sign out of the application for logout$")]
    [Then(@"^I sign out of the application for logout$")]
    public async Task SignOutOfTheApplicationForLogoutAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsLoggedInUser6AD12PresentAsync())
        {
                    await page.ClickLoggedInUser6AD12Async();
        }
        if (await page.IsLogoutPresentAsync())
        {
                    await page.ClickLogoutAsync();
        }
        // Source conditional not executed because no deterministic data/DOM condition was available: during loop for the Login [max=30]
        if (false)
        {
                    await page.NoteAsync("Source operation requires environment-specific implementation.");
        }
        if (await page.IsTheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus01C36BPresentAsync())
        {
                    await page.VerifyTheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus01C36BAsync("Exists", "");
        }
        if (await page.IsEChecklistEChecklistOKPresentAsync())
        {
                    await page.ClickEChecklistEChecklistOKAsync();
        }
        if (await page.IsEChecklistEChecklistOKPresentAsync())
        {
                    await page.WaitForEChecklistEChecklistOKAsync("Absent");
        }
        if (await page.IsLoggedInUser6AD12PresentAsync())
        {
                    await page.ClickLoggedInUser6AD12Async();
        }
        if (await page.IsLogoutPresentAsync())
        {
                    await page.ClickLogoutAsync();
        }

    }

    [Given(@"^I sign in to Duck Creek for cl dc$")]
    [When(@"^I sign in to Duck Creek for cl dc$")]
    [Then(@"^I sign in to Duck Creek for cl dc$")]
    public async Task SignInToDuckCreekForClDcAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await Auth.SignInAsync("CL_DC");
        if (await page.IsLogin07237PresentAsync())
        {
                    await page.WaitForLogin07237Async("Absent");
        }
        await page.PauseAsync(1000);

    }

    [Given(@"^I perform Quick Search and Open Policy$")]
    [When(@"^I perform Quick Search and Open Policy$")]
    [Then(@"^I perform Quick Search and Open Policy$")]
    public async Task PerformQuickSearchAndOpenPolicyAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.EnterSearchTextAsync(data.Resolve("{B[Policy#]}"));
        await page.ClickQuickSearchButtonAsync();
        if (await page.IsLoadingMessagePresentAsync())
        {
                    await page.VerifyLoadingMessageAsync("Visible", "");
        }
        await page.PauseAsync(1000);
        await page.WaitForN1ResultsFoundCurrentlyShowing11Async("Visible");
        await page.WaitForViewPolicyAsync("Visible");
        await page.ClickViewPolicyAsync();
        if (await page.IsLoadingMessagePresentAsync())
        {
                    await page.VerifyLoadingMessageAsync("Visible", "");
        }
        await page.PauseAsync(1000);
        if (await page.IsViewPolicyPresentAsync())
        {
                    await page.VerifyViewPolicyAsync("Visible", "");
        }
        // Source conditional not executed because no deterministic data/DOM condition was available: while view Policy Exists [max=90]
        if (false)
        {
                    await page.PauseAsync(1000);
        }
        if (await page.IsViewPolicyPresentAsync())
        {
                    await page.VerifyViewPolicyAsync("Visible", "");
        }
        if (await page.IsViewPolicyPresentAsync())
        {
                    await page.ClickViewPolicyAsync();
        }
        // Source conditional not executed because no deterministic data/DOM condition was available: while view Policy Exists [max=90]
        if (false)
        {
                    await page.PauseAsync(1000);
        }

    }

    [Given(@"^I verify for Policy Packet$")]
    [When(@"^I verify for Policy Packet$")]
    [Then(@"^I verify for Policy Packet$")]
    public async Task VerifyForPolicyPacketAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForTransACTAsync("Visible");
        await page.ClickViewPolicyDetailsC87C2Async();
        if (await page.IsPolicyDetailsABBA9PresentAsync())
        {
                    await page.VerifyPolicyDetailsABBA9Async("Absent", "");
        }
        // Source conditional not executed because no deterministic data/DOM condition was available: during loop to Check if Policy Details Exists [max=120]
        if (false)
        {
                    await page.PauseAsync(1000);
        }
        await page.WaitForAttachmentsListGridRowCellExplicitName1Async("Visible");
        await page.VerifyAttachmentsListGridRowCellExplicitName1Async(data.Resolve("{{data:expected_row_834}}"), "");
        await page.VerifyAttachmentsListGridRowCellExplicitName1Async(data.Resolve("{{data:expected_attachments_list_grid_row_cell_explicitname_1_836}}"), "");
        await page.ClickViewPolicyAsync();
        await page.WaitForTransactionTypeAsync("Visible");

    }

}
