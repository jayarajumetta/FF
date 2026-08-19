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

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForClientInfoAsync("Visible");
        await page.WaitForNewExistingClientSearchAsync("Visible");
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
        await page.WaitForExistingClientMatchAsync("Exists");
        await page.ClickCreateNewClient1Async();
        await page.PressAdditionalInterestsNextAsync("TAB");
        data.Set("StateName", data.Resolve("{{data:statename}}"));

    }

    [Given(@"^I enter account details$")]
    [When(@"^I enter account details$")]
    [Then(@"^I enter account details$")]
    public async Task EnterAccountDetailsAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("OwnerPhone", "3[0-9]{9}");
        data.GenerateRandom("OwnerEmail", "test@[a-z]{4}\\\\.com");

        var page = new AccountInformationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForAccountInformationHeaderAsync("Visible");
        await page.PressOwnerMiddleNameAsync("ENTER");
        // Source step 0033: RANDOM input for Owner Phone.
        await page.EnterOwnerPhoneAsync(data.Resolve("{{runtime:OwnerPhone}}"));
        // Source step 0033: RANDOM input for Owner Email.
        await page.EnterOwnerEmailAsync(data.Resolve("{{runtime:OwnerEmail}}"));
        await page.PressOwnerMiddleNameAsync("Tab");
        await page.SelectMarriedAsync("");
        await page.PressStreetAddressAsync("SHIFTTAB");
        await page.PressStreetAddressAsync("ENTER");
        await page.PressStreetAddressAsync("Tab");
        await page.PressAddress2Async("TAB");
        await page.PressCityAsync("ENTER");
        await page.PressCityAsync("Tab");
        await page.ClickStateDropdownAsync();
        await page.SelectState0110EAsync(data.Resolve("{{runtime:StateName}}"));
        await page.PressZipAsync("ENTER");
        await page.PressZipAsync("Tab");
        await page.WaitForMapAsync("Exists");
        await page.WaitForSatelliteAsync("Exists");
        await page.PressAdditionalInterestsNextAsync("SHIFTTAB");
        await page.SelectHaveYouReceivedMailAtThisAddressForAtLeast90DaysYesAsync("");
        await page.SelectIsTheAccountAddressAlsoWhereTheClientResidesYesAsync("");
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
        await page.PressSearchBusinessNameAsync("TAB");
        await page.ClickIndividuallyOwnedDBAOrTAAsync();
        await page.EnterIndividualDBAAsync(data.Resolve("{{data:individual_dba_35}}"));
        await page.PressEffectiveDate78F67Async("ENTER");
        await page.PressEffectiveDate78F67Async("Tab");
        await page.EnterTrueAsync(data.Resolve("{{data:true_37}}"));
        await page.SelectLessorsRiskNoAsync("");
        await page.PressStateDropdownAsync("TAB");
        await page.SelectStateAsync(data.Resolve("{{runtime:StateName}}"));
        await page.PressAgentPCAsync("ENTER");
        await page.PressAgentPCAsync("Tab");
        await page.ClickStateDropdownAsync();
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
        await page.WaitForSubmitAngularAsync("Visible");
        await page.PressSubmitAngularAsync("TAB");
        await page.ClickSubmitAngularAsync();
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

    [Given(@"^I navigate to the required policy screen$")]
    [When(@"^I navigate to the required policy screen$")]
    [Then(@"^I navigate to the required policy screen$")]
    public async Task NavigateToTheRequiredPolicyScreenAsync()
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
        await page.PressSearchAddClassCodeAsync("TAB");
        await page.WaitForFindAClassCodeAsync("Exists");
        await page.EnterClassFilterAsync(data.Resolve("{{data:class_filter_64}}"));
        await page.ClickClientInfoSearchAsync();
        await page.WaitForOnAsync("Exists");
        await page.PressOnAsync("TAB");
        await page.WaitForYouHaveSelected1ClassCodesAsync("Exists");
        await page.PressYouHaveSelected1ClassCodesAsync("TAB");
        await page.ClickAddAsync();

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
        await page.PressNoneOfTheAboveAsync("TAB");
        if (!await page.IsScreenHeadingPresentAsync())
        {
                    await page.VerifyScreenHeadingAsync("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen for screen$")]
    [When(@"^I navigate to the required policy screen for screen$")]
    [Then(@"^I navigate to the required policy screen for screen$")]
    public async Task NavigateToTheRequiredPolicyScreenForScreenAsync()
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

    [Given(@"^I enter Required Info$")]
    [When(@"^I enter Required Info$")]
    [Then(@"^I enter Required Info$")]
    public async Task EnterRequiredInfoAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.PressExistingClientAsync("TAB");
        await page.ClickNextBOPAsync();
        await page.ClickIndividualSoleProprietorAsync();
        await page.PressSaveAsync("TAB");
        await page.ClickSaveAsync();
        if (data.Condition("ReadOnly == NULL"))
        {
                    await page.ClickEQCommonPrimaryInsuredRequiredAsync();
        }
        if (data.Condition("ReadOnly == NULL"))
        {
                    await page.PressDescriptionOfOperationsAsync("ENTER");
                    await page.PressDescriptionOfOperationsAsync("Tab");
        }
        if (data.Condition("ReadOnly == NULL"))
        {
                    await page.PressNumberOfFulltimeEmployeesAsync("ENTER");
                    await page.PressNumberOfFulltimeEmployeesAsync("Tab");
        }
        if (data.Condition("ReadOnly == NULL"))
        {
                    await page.PressNumberOfPartTimeEmployeesAsync("ENTER");
                    await page.PressNumberOfPartTimeEmployeesAsync("Tab");
        }
        if (data.Condition("ReadOnly == NULL"))
        {
                    await page.PressNumberOfSeasonalEmployeesAsync("ENTER");
                    await page.PressNumberOfSeasonalEmployeesAsync("Tab");
        }
        if (data.Condition("ReadOnly == NULL"))
        {
                    await page.ClickSaveAsync();
        }
        if (data.Condition("ReadOnly == NULL"))
        {
                    await page.VerifyDescriptionOfOperationsAsync(data.Resolve("{{runtime:QuoteDescription}}"), "");
        }

    }

    [Given(@"^I complete general UW Questions$")]
    [When(@"^I complete general UW Questions$")]
    [Then(@"^I complete general UW Questions$")]
    public async Task CompleteGeneralUWQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.PressNoneOfTheAboveCheckBoxAsync("TAB");

    }

    [Given(@"^I complete industry Class Code Questions$")]
    [When(@"^I complete industry Class Code Questions$")]
    [Then(@"^I complete industry Class Code Questions$")]
    public async Task CompleteIndustryClassCodeQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BusinessClassificationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.PressNoneOfTheAboveCheckboxAsync("TAB");
        if (!await page.IsScreenHeadingPresentAsync())
        {
                    await page.VerifyScreenHeadingAsync("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen for navigate to screen$")]
    [When(@"^I navigate to the required policy screen for navigate to screen$")]
    [Then(@"^I navigate to the required policy screen for navigate to screen$")]
    public async Task NavigateToTheRequiredPolicyScreenForNavigateToScreenAsync()
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

    [Given(@"^I complete edit Client Roles$")]
    [When(@"^I complete edit Client Roles$")]
    [Then(@"^I complete edit Client Roles$")]
    public async Task CompleteEditClientRolesAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.PressInspectionContactAsync("TAB");
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.VerifyScreenHeading9696CAsync("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen for navigate to correct screen$")]
    [When(@"^I navigate to the required policy screen for navigate to correct screen$")]
    [Then(@"^I navigate to the required policy screen for navigate to correct screen$")]
    public async Task NavigateToTheRequiredPolicyScreenForNavigateToCorrectScreenAsync()
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

    [Given(@"^I add/Edit a Narrative and Verify Timestamp$")]
    [When(@"^I add/Edit a Narrative and Verify Timestamp$")]
    [Then(@"^I add/Edit a Narrative and Verify Timestamp$")]
    public async Task AddEditANarrativeAndVerifyTimestampAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForNarrativeScreenHeadingAsync("Exists");
        await page.ClickAddNarrativeAsync();
        await page.EnterDescriptionOfTheBusinessExposuresActivitiesAndExperienceAsync(data.Resolve("{{data:description_of_the_business_exposures_activities_and_experience_118}}"));
        if (data.Condition("'Referred and Locked' != \"Yes\""))
        {
                    await page.ClickSaveAsync();
        }
        await page.WaitForUserDateAndTimestampAsync("Visible");
        await page.VerifyUserDateAndTimestampAsync(data.Resolve("{{data:expected_user_date_and_timestamp_innertext_121}}"), "NotEqual:InnerText");
        if (data.Condition("'Referred and Locked' == \"Yes\""))
        {
                    await page.VerifyLockedThisQuoteHasBeenSubmittedAndYouCanNoLongerMakeChangesToThisTextAsync("Exists", "");
        }
        await page.EnterDescriptionOfTheBusinessExposuresActivitiesAndExperienceAsync("");
        data.Set("Quote_Num", data.Resolve("{B[NameQuoteNum]}"));
        data.Set("Policy#", data.Resolve("{{data:policy}}"));
        if (!await page.IsScreenHeading69631PresentAsync())
        {
                    await page.VerifyScreenHeading69631Async("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen for policy data entry$")]
    [When(@"^I navigate to the required policy screen for policy data entry$")]
    [Then(@"^I navigate to the required policy screen for policy data entry$")]
    public async Task NavigateToTheRequiredPolicyScreenForPolicyDataEntryAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (!await page.IsScreenDA408PresentAsync())
        {
                    await page.ClickScreenDA408Async();
        }
        if (data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
                    await page.ClickKeepGoingAsync();
        }
        if (!await page.IsLoadingPresentAsync())
        {
        }
        if (!await page.IsScreenHeading69631PresentAsync())
        {
                    await page.WaitForScreenHeading69631Async("Exists");
        }

    }

    [Given(@"^I enter Required$")]
    [When(@"^I enter Required$")]
    [Then(@"^I enter Required$")]
    public async Task EnterRequiredAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LossHistoryPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.SelectPriorPolicyNoAsync("");
        await page.PressYearsInBusinessAsync("ENTER");
        await page.PressYearsInBusinessAsync("Tab");
        await page.ClickN3YearsAsync();
        await page.PressN3YearsAsync("TAB");
        await page.PressPriorInsuranceLatestExpirationDateAsync("ENTER");
        await page.PressPriorInsuranceLatestExpirationDateAsync("Tab");
        await page.PressPriorInsuranceLatestCarrierAsync("ENTER");
        await page.PressPriorInsuranceLatestCarrierAsync("Tab");

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
        await page.PressDateOfOccurrenceAsync("Tab");
        await page.PressPolicyStartAsync("CTRL+A");
        await page.PressPolicyStartAsync("Enter");
        await page.PressPolicyStartAsync("Tab");
        await page.PressPolicyExpireAsync("CTRL+A");
        await page.PressPolicyExpireAsync("Enter");
        await page.PressPolicyExpireAsync("Tab");
        await page.PressAmountPaidAsync("CTRL+A");
        await page.PressAmountPaidAsync("Enter");
        await page.PressAmountPaidAsync("Tab");
        await page.PressAmountReservedAsync("CTRL+A");
        await page.PressAmountReservedAsync("Enter");
        await page.PressAmountReservedAsync("Tab");
        await page.PressExpenseAmountAsync("CTRL+A");
        await page.PressExpenseAmountAsync("Enter");
        await page.PressExpenseAmountAsync("Tab");
        await page.PressTypeOfLossDropdownAsync("TAB");
        await page.ClickTypeOfLossSelectionAsync();
        await page.PressDescriptionOfOccurrenceOrClaimAsync("ENTER");
        await page.PressDescriptionOfOccurrenceOrClaimAsync("Tab");
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
        await page.WaitForEditLocationHeadingAsync("Exists");
        await page.EnterTerritoryAsync(data.Resolve("{{data:territory_188}}"));
        await page.PressMilesFromFireDeptAsync("CTRL+A");
        await page.PressMilesFromFireDeptAsync("Enter");
        await page.PressMilesFromFireDeptAsync("Tab");
        await page.EnterFeetFromHydrantAsync(data.Resolve("{{data:feetfromhydrant_190}}"));
        await page.ClickSaveAsync();
        await page.WaitForSaveAsync("Absent");
        if (data.Condition("'Order Wildfire Risk Score' == \"Yes\""))
        {
                    await page.ClickOrderWildfireRiskScoreAsync();
        }

    }

    [Given(@"^I add a Building Button$")]
    [When(@"^I add a Building Button$")]
    [Then(@"^I add a Building Button$")]
    public async Task AddABuildingButtonAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickAddBuildingBPPAsync();

    }

    [Given(@"^I select Own or rent and Building SQ Footage Basic$")]
    [When(@"^I select Own or rent and Building SQ Footage Basic$")]
    [Then(@"^I select Own or rent and Building SQ Footage Basic$")]
    public async Task SelectOwnOrRentAndBuildingSQFootageBasicAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForSelectIfClientOwnsOrRentsTheBuildingAsync("Visible");
        if (data.Condition("'Client Own or Rent' == \"OWN\""))
        {
                    await page.PressOwnButtonAsync("TAB");
        }
        await page.WaitForTotalBuildingSqFootageAsync("Visible");
        await page.WaitForInsuredOccupancySqFtAngularAsync("Visible");
        await page.PressInsuredOccupancySqFtAngularAsync("SHIFTTAB");
        await page.PressTotalBuildingSqFootageAsync("ENTER");
        await page.PressTotalBuildingSqFootageAsync("Tab");
        await page.PressInsuredOccupancySqFtAngularAsync("ENTER");
        await page.PressInsuredOccupancySqFtAngularAsync("Tab");
        await page.PressInsuredOccupancySqFtAngularAsync("TAB");

    }

    [Given(@"^I select Additional Coverages \\- Building, Functional Personal Property or Habitational$")]
    [When(@"^I select Additional Coverages \\- Building, Functional Personal Property or Habitational$")]
    [Then(@"^I select Additional Coverages \\- Building, Functional Personal Property or Habitational$")]
    public async Task SelectAdditionalCoveragesBuildingFunctionalPersonalPropertyOrHabitationalAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForSelectIfClientOwnsOrRentsTheBuildingAsync("Visible");
        if (data.Condition("'Select Building Coverage' == \"Building Coverage\""))
        {
                    await page.PressBuildingCoverageAngularAsync("TAB");
        }
        if (data.Condition("'Select Functional Personal Property' == \"Include Functional Personal Property\""))
        {
                    await page.PressFunctionalPersonalPropertyUncheckedAsync("ENTER");
        }
        if (data.Condition("'Select Building contains habitational occupancy' == \"Building contains habitational occupancies\""))
        {
                    await page.PressBuildingContainsHabitationalOccupanciesUncheckedAsync("ENTER");
        }
        if (data.Condition("'Select Functional Personal Property' == \"Include Functional Personal Property\""))
        {
                    await page.WaitForFunctionalPersonalPropertyCheckedAsync("Visible");
        }
        if (data.Condition("'Select Building contains habitational occupancy' == \"Building contains habitational occupancies\""))
        {
                    await page.WaitForBuildingContainsHabitationalOccupanciesCheckedAsync("Visible");
        }

    }

    [Given(@"^I select Occupancy SQ Footage$")]
    [When(@"^I select Occupancy SQ Footage$")]
    [Then(@"^I select Occupancy SQ Footage$")]
    public async Task SelectOccupancySQFootageAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.EnterInsuredOccupancySqFtAsync("");
        await page.EnterInsuredOccupancySqFtAsync("");
        await page.PressInsuredOccupancySqFtAngularAsync("TAB");
        await page.PressInsuredOccupancySqFtAngularAsync("CTRL+A");
        await page.PressInsuredOccupancySqFtAngularAsync("Enter");
        await page.PressInsuredOccupancySqFtAngularAsync("Tab");

    }

    [Given(@"^I enter supplimental data\\- for class$")]
    [When(@"^I enter supplimental data\\- for class$")]
    [Then(@"^I enter supplimental data\\- for class$")]
    public async Task EnterSupplimentalDataForClassAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForClassCodesAsync("Exists");
        await page.WaitForCheckBoxAngularAsync("Exists");
        await page.PressCheckBoxAngularAsync("TAB");
        await page.ClickCheckBoxAngularAsync();
        await page.WaitForOccupancySQFTHeadingAsync("Exists");
        await page.PressOccupancySqFtLimitAsync("ENTER");
        await page.PressOccupancySqFtLimitAsync("Tab");
        await page.VerifyOccupancySqFootageTotalAsync(data.Resolve("{{data:expected_occupancy_sq_footage_total_value_227}}"), "Value");
        await page.WaitForPersonalPropertyLimitCheckBoxAngularAsync("Exists");
        await page.PressPersonalPropertyLimitCheckBoxAngularAsync("TAB");
        await page.ClickPersonalPropertyLimitCheckBoxAngularAsync();
        await page.PressPersonalPropertyLimitAsync("ENTER");
        await page.PressPersonalPropertyLimitAsync("Tab");
        await page.PressGrossSalesReceiptsAsync("ENTER");
        await page.PressGrossSalesReceiptsAsync("Tab");
        data.Set("Roof Type", data.Resolve("{{data:roof_type}}"));

    }

    [Given(@"^I select Cost Estimator \\& Calculate Valuations$")]
    [When(@"^I select Cost Estimator \\& Calculate Valuations$")]
    [Then(@"^I select Cost Estimator \\& Calculate Valuations$")]
    public async Task SelectCostEstimatorCalculateValuationsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.PressCommercialButtonAsync("TAB");
        await page.ClickCommercialButtonAsync();
        await page.PressBVSButtonAsync("TAB");
        await page.ClickBVSButtonAsync();
        await page.PressFrameAsync("TAB");
        await page.ClickFrameAsync();
        await page.PressBVSGroupComboboxAsync("TAB");
        await page.ClickBVSGroupAsync();
        await page.PressBVSResultsComboboxAsync("TAB");
        await page.ClickBVSResultAsync();
        await page.PressYearBuiltAsync("TAB");
        await page.PressYearBuiltAsync("ENTER");
        await page.PressYearBuiltAsync("Tab");
        await page.PressRoofTypeMainAsync("TAB");
        await page.ClickRoofTypeSelectionAsync();
        await page.PressGetValuationAsync("TAB");
        await page.ClickGetValuationAsync();

    }

    [Given(@"^I select Building Detail Fields$")]
    [When(@"^I select Building Detail Fields$")]
    [Then(@"^I select Building Detail Fields$")]
    public async Task SelectBuildingDetailFieldsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.PressNumberOfStoriesAsync("TAB");
        await page.WaitForBuildingDetailsHeadingAsync("Exists");
        if (data.Condition("'Actual Cash Value' != NULL"))
        {
                    await page.PressActualCashValueAsync("TAB");
        }
        if (data.Condition("'Actual Cash Value' != NULL"))
        {
                    await page.ClickActualCashValueAsync();
        }
        if (data.Condition("'Replacement Cost' != NULL"))
        {
                    await page.PressReplacementCostAsync("TAB");
        }
        if (data.Condition("'Replacement Cost' != NULL"))
        {
                    await page.ClickReplacementCostAsync();
        }
        await page.PauseAsync(1000);
        await page.PressBuildingAsync("ENTER");
        await page.PressBuildingAsync("Tab");
        await page.PressYearBuiltRenovatedAsync("CTRL+A");
        await page.PressYearBuiltRenovatedAsync("DELETE");
        await page.PressYearBuiltRenovatedAsync("ENTER");
        await page.PressYearBuiltRenovatedAsync("Tab");
        await page.PressWiringYearAsync("CTRL+A");
        await page.PressWiringYearAsync("DELETE");
        await page.PressWiringYearAsync("ENTER");
        await page.PressWiringYearAsync("Tab");
        await page.PressHeatingYearAsync("CTRL+A");
        await page.PressHeatingYearAsync("DELETE");
        await page.PressHeatingYearAsync("ENTER");
        await page.PressHeatingYearAsync("Tab");
        await page.PressPlumbingYearAsync("CTRL+A");
        await page.PressPlumbingYearAsync("DELETE");
        await page.PressPlumbingYearAsync("ENTER");
        await page.PressPlumbingYearAsync("Tab");
        await page.VerifyEQBOPBuildingBuildingDetailsSelectBurglarAlarmAsync("Exists", "");
        await page.PressRoofYearAsync("ENTER");
        await page.PressRoofYearAsync("Tab");
        await page.SelectSprinklerYesAsync("");
        await page.WaitForSprinklerYesAsync("Visible");
        if (data.Condition("ANSUL != NULL"))
        {
                    await page.SelectAutomaticCommercialCookingExhaustAndExtinguishingANSULSystemYesAsync("");
        }
        await page.SelectIsAnyHeatSourceThermostaticallyControlledYesAsync("");

    }

    [Given(@"^I select Heating Sources$")]
    [When(@"^I select Heating Sources$")]
    [Then(@"^I select Heating Sources$")]
    public async Task SelectHeatingSourcesAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.PressIsTheBuildingHeatedWithOneOfTheFollowingNoneOfTheAboveCheckboxAngularAsync("TAB");
        await page.VerifyEQBOPBuildingBuildingDetailsSelectPelletStoveAsync("Exists", "");
        await page.VerifyEQBOPBuildingBuildingDetailsSelectWoodFurnaceAsync("Exists", "");
        await page.VerifyEQBOPBuildingBuildingDetailsSelectWoodStoveAsync("Exists", "");
        await page.PressIsTheBuildingHeatedWithOneOfTheFollowingNoneOfTheAboveCheckboxAngularAsync("TAB");

    }

    [Given(@"^I complete extra Property Risk$")]
    [When(@"^I complete extra Property Risk$")]
    [Then(@"^I complete extra Property Risk$")]
    public async Task CompleteExtraPropertyRiskAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.PressSelectAnyOfTheFollowingWhichApplyToThisBuildingNoneOfTheAboveCheckboxAngularAsync("TAB");
        await page.VerifyEQBOPBuildingBuildingDetailsAnswerAnyExtraPropertyAdditionalQuestionsAsync("Exists", "");

    }

    [Given(@"^I answer Building Eligibility Questions$")]
    [When(@"^I answer Building Eligibility Questions$")]
    [Then(@"^I answer Building Eligibility Questions$")]
    public async Task AnswerBuildingEligibilityQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.PressBuildingEligibilityQuestionsNoneOfTheAboveCheckboxAngularAsync("TAB");
        await page.ClickSaveAsync();
        if (!await page.IsScreenHeadingPresentAsync())
        {
                    await page.VerifyScreenHeadingAsync("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0266$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0266$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0266$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0266Async()
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

    }

    [Given(@"^I answer EPLI Questions$")]
    [When(@"^I answer EPLI Questions$")]
    [Then(@"^I answer EPLI Questions$")]
    public async Task AnswerEPLIQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.PressHaveThereBeenAnyEPLClaimsSuitsOrComplaintsOrAreThereAnyNowPendingAgainstTheInsuredOrAnyExecutiveOfficerOrOwnerAsync("ENTER");
        await page.PressHaveThereBeenAnyEPLClaimsSuitsOrComplaintsOrAreThereAnyNowPendingAgainstTheInsuredOrAnyExecutiveOfficerOrOwnerAsync("END");
        await page.PressHaveThereBeenAnyEPLClaimsSuitsOrComplaintsOrAreThereAnyNowPendingAgainstTheInsuredOrAnyExecutiveOfficerOrOwnerAsync("Tab");
        await page.PressDoesTheInsuredAndAnyExecutiveOfficerOrOwnerHaveAnyKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaintAsync("ENTER");
        await page.PressDoesTheInsuredAndAnyExecutiveOfficerOrOwnerHaveAnyKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaintAsync("Tab");
        if (!await page.IsScreenHeadingPresentAsync())
        {
                    await page.VerifyScreenHeadingAsync("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0285$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0285$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0285$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0285Async()
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

    [Given(@"^I complete billing Account Setup$")]
    [When(@"^I complete billing Account Setup$")]
    [Then(@"^I complete billing Account Setup$")]
    public async Task CompleteBillingAccountSetupAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BillingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForBillingInformationHeadingAsync("Exists");
        await page.ClickCreateNewBillingAccountAsync();
        await page.WaitForBillingInformationHeadingAsync("Exists");
        await page.ClickOTHERButtonAsync();
        await page.PressFirstNameAsync("ENTER");
        await page.PressFirstNameAsync("Tab");
        await page.PressLastNameAsync("ENTER");
        await page.PressLastNameAsync("Tab");
        await page.PressBusinessNameAsync("ENTER");
        await page.PressBusinessNameAsync("Tab");
        await page.PressAddress1Async("ENTER");
        await page.PressAddress1Async("Tab");
        await page.PressCityAsync("ENTER");
        await page.PressCityAsync("Tab");
        await page.PressStateAsync("ENTER");
        await page.PressStateAsync("Tab");
        await page.PressZipCodeAsync("ENTER");
        await page.PressZipCodeAsync("Tab");

    }

    [Given(@"^I complete future Payment Plan 1$")]
    [When(@"^I complete future Payment Plan 1$")]
    [Then(@"^I complete future Payment Plan 1$")]
    public async Task CompleteFuturePaymentPlan1Async()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BillingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.PressDirectBillButtonAsync("TAB");
        await page.PressN1PaymentButtonAsync("TAB");
        await page.PauseAsync(1000);
        await page.PressChoosePaymentDueDateAsync("ENTER");
        await page.PressChoosePaymentDueDateAsync("Tab");

    }

    [Given(@"^I complete initial Payment$")]
    [When(@"^I complete initial Payment$")]
    [Then(@"^I complete initial Payment$")]
    public async Task CompleteInitialPaymentAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BillingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (data.Condition("'Payment Type' ==\"Check\""))
        {
                    await page.PressCheckButtonAsync("TAB");
        }
        if (data.Condition("'Payment Type' ==\"Credit Card\""))
        {
                    await page.PressCreditCardButtonAsync("TAB");
        }
        if (data.Condition("'Payment Type' == \"Check\""))
        {
                    await page.VerifyCheckNumberAsync("Absent", "");
        }
        if (data.Condition("'Payment Type' == \"Check\""))
        {
                    await page.PressCheckButtonAsync("TAB");
        }
        if (data.Condition("'Payment Type' == \"Check\""))
        {
                    await page.PressCreditCardButtonAsync("TAB");
        }
        if (data.Condition("'Payment Type' == \"Check\""))
        {
                    await page.WaitForCheckNumberAsync("Exists");
        }
        if (data.Condition("'Payment Type' == \"Check\""))
        {
                    await page.PressCheckNumberAsync("ENTER");
                    await page.PressCheckNumberAsync("Tab");
        }
        await page.ClickInitialPaymentFullBalanceAsync();
        if (!await page.IsScreenHeadingPresentAsync())
        {
                    await page.VerifyScreenHeadingAsync("Absent", "");
        }

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
        await _auth.SignInAsync("CL_EQ");

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
        await page.PressQuoteSearchInputAsync("Tab");
        await page.PressQuoteSearchInputAsync("Tab");
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
        await _auth.SignInAsync("CL_DC");
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
        await page.PressSearchTextAsync("Tab");
        await page.PressSearchTextAsync("Tab");
        await page.PressSearchTextAsync("Tab");
        await page.PressSearchTextAsync("Tab");
        await page.ClickQuickSearchButtonAsync();
        await page.PressSearchMethodEGDescriptionPolicyAsync("TAB");
        await page.WaitForSearchButtonAsync("Equal");
        await page.PressSearchButtonAsync("TAB");
        await page.ClickSearchButtonAsync();
        if (await page.IsLoadingMessageC7A0DPresentAsync())
        {
                    await page.VerifyLoadingMessageC7A0DAsync("Visible", "");
        }
        await page.WaitForViewPolicy56E09Async("Exists");
        await page.PressViewPolicy56E09Async("TAB");
        await page.PressSearchButtonAsync("TAB");
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

    [Given(@"^I complete forms verification Retrieve QuoteID \\& SessionID by Browser Console$")]
    [When(@"^I complete forms verification Retrieve QuoteID \\& SessionID by Browser Console$")]
    [Then(@"^I complete forms verification Retrieve QuoteID \\& SessionID by Browser Console$")]
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
        await _auth.SignInAsync("CL_EQ");

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
        await page.PressQuoteSearchInputAsync("Tab");
        await page.PressQuoteSearchInputAsync("Tab");
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

    [Given(@"^I complete eChecklist \\- Building Photo1$")]
    [When(@"^I complete eChecklist \\- Building Photo1$")]
    [Then(@"^I complete eChecklist \\- Building Photo1$")]
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

    [Given(@"^I complete eChecklist \\- Building Photo2$")]
    [When(@"^I complete eChecklist \\- Building Photo2$")]
    [Then(@"^I complete eChecklist \\- Building Photo2$")]
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

    [Given(@"^I complete eChecklist \\- Building Photo3$")]
    [When(@"^I complete eChecklist \\- Building Photo3$")]
    [Then(@"^I complete eChecklist \\- Building Photo3$")]
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

    [Given(@"^I complete eChecklist \\- Building Photo4$")]
    [When(@"^I complete eChecklist \\- Building Photo4$")]
    [Then(@"^I complete eChecklist \\- Building Photo4$")]
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

    [Given(@"^I complete eChecklist \\- Loss Runs \\- 3 Years$")]
    [When(@"^I complete eChecklist \\- Loss Runs \\- 3 Years$")]
    [Then(@"^I complete eChecklist \\- Loss Runs \\- 3 Years$")]
    public async Task CompleteEChecklistLossRuns3YearsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LossHistoryPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.EnterAllLinkAsync("");
        await page.WaitForLossRunsHeaderAsync("Exists");
        await page.ClickExceptionAsync();
        await page.WaitForAddANoteAsync("Visible");
        await page.PressAddANoteAsync("TAB");
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
        await page.PressUnderwritingRulesAgentCommentsAsync("Tab");
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
        await _auth.SignInAsync("CL_DC");
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
        await page.PressSearchTextAsync("Tab");
        await page.PressSearchTextAsync("Tab");
        await page.PressSearchTextAsync("Tab");
        await page.PressSearchTextAsync("Tab");
        await page.ClickQuickSearchButtonAsync();
        await page.PressSearchMethodEGDescriptionPolicyAsync("TAB");
        await page.WaitForSearchButtonAsync("Equal");
        await page.PressSearchButtonAsync("TAB");
        await page.ClickSearchButtonAsync();
        if (await page.IsLoadingMessageC7A0DPresentAsync())
        {
                    await page.VerifyLoadingMessageC7A0DAsync("Visible", "");
        }
        await page.WaitForViewPolicy56E09Async("Exists");
        await page.PressViewPolicy56E09Async("TAB");
        await page.PressSearchButtonAsync("TAB");
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
                    await page.PressSubmission7E601Async("TAB");
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
                    await page.PressIsThisCoverageBoundAsync("TAB");
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
                    await page.PressIsThisCoverageBoundAsync("TAB");
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
        await _auth.SignInAsync("CL_EQ");

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
        await page.PressQuoteSearchInputAsync("Tab");
        await page.PressQuoteSearchInputAsync("Tab");
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
        await _auth.SignInAsync("CL_DC");
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
        await page.PressSearchTextAsync("Tab");
        await page.PressSearchTextAsync("Tab");
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
