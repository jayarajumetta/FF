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
        await page.PressOwnerMiddleNameAsync("Tab");
        await page.SelectMarriedAsync("");
        await page.PressStreetAddressAsync("SHIFTTAB");
        await page.PressStreetAddressAsync("ENTER");
        await page.PressStreetAddressAsync("Tab");
        await page.PressAddress2Async("ENTER");
        await page.PressAddress2Async("Tab");
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
        await page.SelectSpecialFarmPackageAsync("");
        await page.PressEffectiveDate78F67Async("ENTER");
        await page.PressEffectiveDate78F67Async("Tab");
        await page.EnterTrueAsync(data.Resolve("{{data:true_34}}"));
        await page.PressPolicyTermAsync("TAB");
        await page.EnterPolicyTermAsync(data.Resolve("{{data:policyterm_36}}"));
        await page.PressPolicyTermAsync("TAB");
        await page.PressStateDropdownAsync("TAB");
        await page.SelectStateAsync(data.Resolve("{{runtime:StateName}}"));
        await page.PressAgentPCAsync("ENTER");
        await page.PressAgentPCAsync("Tab");
        data.Set("EffDate", await page.CaptureEffectiveDate78F67Async("InnerText"));
        await page.ClickStateDropdownAsync();
        await page.ClickStartQuoteAsync();
        data.Set("LOB", data.Resolve("{{data:lob}}"));

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
        data.Set("Screen", data.Resolve("{{data:screen}}"));
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
        data.Set("Screen", data.Resolve("{{data:screen}}"));
        if (!await page.IsLoadingPresentAsync())
        {
                    await page.WaitForLoadingAsync("Absent");
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.WaitForScreenHeading9696CAsync("Exists");
        }
        data.Set("PrimaryFarmCategory", data.Resolve("{{data:primaryfarmcategory}}"));
        data.Set("PrimaryFarmType", data.Resolve("{{data:primaryfarmtype}}"));
        data.Set("SecondaryFarmCategory", data.Resolve("{{data:secondaryfarmcategory}}"));
        data.Set("SecondaryFarmType", data.Resolve("{{data:secondaryfarmtype}}"));

    }

    [Given(@"^I complete policy Details \\(Optimized\\)$")]
    [When(@"^I complete policy Details \\(Optimized\\)$")]
    [Then(@"^I complete policy Details \\(Optimized\\)$")]
    public async Task CompletePolicyDetailsOptimizedAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyInformationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickPrimaryFarmCategoryAsync();
        await page.WaitForLoadingAsync("Absent");
        await page.WaitForPrimaryFarmTypeAsync("Exists");
        await page.ClickPrimaryFarmTypeAsync();
        await page.WaitForLoadingAsync("Absent");
        await page.ClickAddSecondaryFarmTypeToggleAsync();
        await page.WaitForSecondaryFarmCategoryAsync("Visible");
        await page.ClickSecondaryFarmCategoryAsync();
        await page.WaitForLoadingAsync("Absent");
        await page.WaitForSecondaryFarmTypeAsync("Exists");
        await page.ClickSecondaryFarmTypeAsync();
        await page.WaitForLoadingAsync("Absent");
        await page.EnterGrossFarmIncomeAsync(data.Resolve("{{data:gross_farm_income_75}}"));
        if (data.Condition("'Industrial Hemp Answer' == \"No\""))
        {
                    await page.SelectIndustrialHempNoAsync("");
        }
        if (data.Condition("'Industrial Hemp Answer' == \"Yes\""))
        {
                    await page.SelectIndustrialHempYesAsync("");
        }
        data.Set("Screen", data.Resolve("{{data:screen_2}}"));
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
        data.Set("Screen", data.Resolve("{{data:screen_2}}"));
        if (!await page.IsLoadingPresentAsync())
        {
                    await page.WaitForLoadingAsync("Absent");
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.WaitForScreenHeading9696CAsync("Exists");
        }
        await page.VerifyGeneralEligibilityRestrictionsSynchingAsync("Exists", "");

    }

    [Given(@"^I verify None of the Above$")]
    [When(@"^I verify None of the Above$")]
    [Then(@"^I verify None of the Above$")]
    public async Task VerifyNoneOfTheAboveAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsUncheckedNoneOfTheAbovePresentAsync())
        {
                    await page.VerifyUncheckedNoneOfTheAboveAsync("Exists", "");
        }
        if (await page.IsUncheckedNoneOfTheAbovePresentAsync())
        {
                    await page.PressUncheckedNoneOfTheAboveAsync("TAB");
        }
        if (await page.IsResponseRequiredToContinuePresentAsync())
        {
                    await page.WaitForResponseRequiredToContinueAsync("Exists");
        }
        data.Set("Screen", data.Resolve("{{data:screen_3}}"));
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.VerifyScreenHeading9696CAsync("Absent", "");
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
        data.Set("Screen", data.Resolve("{{data:screen_3}}"));
        if (!await page.IsLoadingPresentAsync())
        {
                    await page.WaitForLoadingAsync("Absent");
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
        await page.ClickNextSFPAsync();
        await page.WaitForLoadingAsync("Absent");
        await page.PressSaveAsync("TAB");
        await page.ClickSaveAsync();
        if (data.Condition("ReadOnly == NULL"))
        {
                    await page.ClickEQCommonPrimaryInsuredRequiredAsync();
        }
        await page.WaitForLoadingAsync("Absent");
        if (data.Condition("ReadOnly == NULL"))
        {
                    await page.PressDescriptionOfOperationsAsync("TAB");
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
        await page.WaitForLoadingAsync("Absent");
        await page.PressNoneOfTheAboveCheckboxAsync("TAB");
        data.Set("Screen", data.Resolve("{{data:screen_4}}"));
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
        data.Set("Screen", data.Resolve("{{data:screen_4}}"));
        if (!await page.IsLoadingPresentAsync())
        {
                    await page.WaitForLoadingAsync("Absent");
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.WaitForScreenHeading9696CAsync("Exists");
        }
        data.Set("InspectionContactIndex", data.Resolve("{{data:inspectioncontactindex}}"));

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
        data.Set("Screen", data.Resolve("{{data:screen_5}}"));
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.VerifyScreenHeading9696CAsync("Absent", "");
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
        if (!await page.IsScreen4475CPresentAsync())
        {
                    await page.ClickScreen4475CAsync();
        }
        if (data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
                    await page.ClickKeepGoingAsync();
        }
        data.Set("Screen", data.Resolve("{{data:screen_5}}"));
        if (!await page.IsLoadingPresentAsync())
        {
                    await page.WaitForLoadingAsync("Absent");
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
        await page.EnterDescriptionOfTheBusinessExposuresActivitiesAndExperienceAsync(data.Resolve("{{data:description_of_the_business_exposures_activities_and_experience_129}}"));
        if (data.Condition("'Referred and Locked' != \"Yes\""))
        {
                    await page.ClickSaveAsync();
        }
        await page.WaitForUserDateAndTimestampAsync("Visible");
        await page.VerifyUserDateAndTimestampAsync(data.Resolve("{{data:expected_user_date_and_timestamp_innertext_132}}"), "NotEqual:InnerText");
        if (data.Condition("'Referred and Locked' == \"Yes\""))
        {
                    await page.VerifyLockedThisQuoteHasBeenSubmittedAndYouCanNoLongerMakeChangesToThisTextAsync("Exists", "");
        }
        await page.EnterDescriptionOfTheBusinessExposuresActivitiesAndExperienceAsync("");
        data.Set("NameQuoteNum", await page.CaptureNameAndQuoteNum8EB77Async("InnerText"));
        data.Set("Quote_Num", data.Resolve("{B[NameQuoteNum]}"));
        data.Set("QuoteID", data.Resolve("{{runtime:Quote_Num}}"));
        data.Set("Policy#", data.Resolve("{{data:policy}}"));
        data.Set("Screen", data.Resolve("{{data:screen_6}}"));
        if (!await page.IsScreenHeadingDCABFPresentAsync())
        {
                    await page.VerifyScreenHeadingDCABFAsync("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0118$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0118$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0118$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0118Async()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (!await page.IsScreen25E91PresentAsync())
        {
                    await page.ClickScreen25E91Async();
        }
        if (data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
                    await page.ClickKeepGoingAsync();
        }
        data.Set("Screen", data.Resolve("{{data:screen_6}}"));
        if (!await page.IsLoadingPresentAsync())
        {
                    await page.WaitForLoadingAsync("Absent");
        }
        if (!await page.IsScreenHeadingDCABFPresentAsync())
        {
                    await page.WaitForScreenHeadingDCABFAsync("Exists");
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
        await page.ClickPriorPolicyNoAsync();
        await page.WaitForLoadingAsync("Absent");
        await page.PressYearsInBusinessAsync("ENTER");
        await page.PressYearsInBusinessAsync("Tab");
        await page.ClickN3YearsAsync();
        await page.PressN3YearsAsync("TAB");
        await page.WaitForLoadingAsync("Absent");
        await page.PressPriorInsuranceLatestExpirationDateAsync("ENTER");
        await page.PressPriorInsuranceLatestExpirationDateAsync("Tab");
        await page.WaitForLoadingAsync("Absent");
        await page.PressPriorInsuranceLatestCarrierAsync("ENTER");
        await page.PressPriorInsuranceLatestCarrierAsync("Tab");

    }

    [Given(@"^I add a Location$")]
    [When(@"^I add a Location$")]
    [Then(@"^I add a Location$")]
    public async Task AddALocationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LocationsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickLocationLinkAsync();
        await page.WaitForLocationDescriptionAsync("Exists");
        await page.PressLocationDescriptionAsync("ENTER");
        await page.PressLocationDescriptionAsync("Tab");
        await page.PressMilesFromFDAsync("ENTER");
        await page.PressMilesFromFDAsync("Tab");
        await page.WaitForLoadingAsync("Absent");
        await page.EnterFeetFromHydrantAsync(data.Resolve("{{data:feet_from_hydrant_160}}"));
        await page.WaitForLoadingAsync("Absent");
        await page.EnterTotalFarmingAcreageAsync(data.Resolve("{{data:total_farming_acreage_162}}"));
        await page.PressTotalFarmingAcreageAsync("ENTER");
        await page.PressTotalFarmingAcreageAsync("Tab");
        await page.PressTotalFarmingAcreageAsync("SCROLL[1]");
        await page.WaitForLoadingAsync("Absent");
        if (data.Condition("WindHail == \"1%\" && '1% Mandatory' != \"Yes\""))
        {
                    await page.ClickWindHail1Async();
        }
        if (data.Condition("WindHail == \"2%\""))
        {
                    await page.ClickWindHail2Async();
        }
        if (data.Condition("WindHail == \"5%\""))
        {
                    await page.ClickWindHail5Async();
        }
        await page.WaitForLoadingAsync("Absent");
        if (await page.IsSavePresentAsync())
        {
                    await page.VerifySaveAsync("Exists", "");
        }
        if (await page.IsSavePresentAsync())
        {
                    await page.ClickSaveAsync();
        }
        if (await page.IsLoadingPresentAsync())
        {
                    await page.WaitForLoadingAsync("Absent");
        }

    }

    [Given(@"^I add a Residence$")]
    [When(@"^I add a Residence$")]
    [Then(@"^I add a Residence$")]
    public async Task AddAResidenceAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickAddResidenceToLocationAsync();
        await page.WaitForLoadingAsync("Absent");
        await page.WaitForAddResidenceHeaderAsync("Exists");
        await page.PressAdditionalDescriptionAsync("CTRL+A");
        await page.PressAdditionalDescriptionAsync("Enter");
        await page.PressAdditionalDescriptionAsync("Tab");
        await page.PressFrameAsync("TAB");
        await page.PressSingleFamilyAsync("TAB");
        await page.PressYearBuiltAsync("CTRL+A");
        await page.PressYearBuiltAsync("Enter");
        await page.PressYearBuiltAsync("Tab");
        await page.PauseAsync(1000);
        await page.PressPlumbingYearAsync("TAB");
        await page.WaitForLoadingAsync("Absent");
        await page.WaitForAddResidenceHeaderAsync("Exists");
        await page.PressRateType1Async("TAB");
        await page.PressRoofYearAsync("CTRL+A");
        await page.PressRoofYearAsync("Enter");
        await page.PressRoofYearAsync("Tab");
        await page.WaitForLoadingAsync("Absent");
        await page.WaitForAddResidenceHeaderAsync("Exists");
        await page.EnterRoofType1Async(data.Resolve("{{data:roof_type_1_188}}"));
        await page.EnterRoofImpact1Async(data.Resolve("{{data:roof_impact_1_189}}"));
        await page.WaitForAddResidenceHeaderAsync("Exists");
        await page.PressRoofYearAsync("TAB");
        await page.PressRoofYearAsync("SCROLL[2]");
        await page.ClickSeasonalOrVacantNoAsync();
        await page.WaitForLoadingAsync("Absent");
        await page.WaitForAddResidenceHeaderAsync("Exists");
        await page.PressResidenceCoverageAsync("TAB");
        await page.PressResidenceCoverageAsync("SCROLL[-3]");
        await page.PauseAsync(1000);
        await page.ClickDoesTheClientHaveASolidFuelHeatingTypeNoAsync();
        await page.WaitForLoadingAsync("Absent");
        await page.WaitForAddResidenceHeaderAsync("Exists");
        await page.PressResidenceCoverageAsync("TAB");
        await page.ClickResidenceCoverageAsync();
        await page.WaitForLoadingAsync("Absent");

    }

    [Given(@"^I add Residence Covg$")]
    [When(@"^I add Residence Covg$")]
    [Then(@"^I add Residence Covg$")]
    public async Task AddResidenceCovgAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BuildingsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyResidenceCoverageAsync(data.Resolve("{{data:expected_residence_coverage_203}}"), "");
        await page.PressInsuranceAmountAsync("ENTER");
        await page.PressInsuranceAmountAsync("Tab");
        await page.WaitForLoadingAsync("Absent");
        await page.PressSquareFeetAsync("ENTER");
        await page.PressSquareFeetAsync("Tab");
        await page.EnterPerilsAsync(data.Resolve("{{data:perils_207}}"));
        await page.PressActualCashValueAsync("SHIFTTAB");
        await page.PressDoesTheResidenceHaveAThermostaticallyControlledDeviceYesAsync("TAB");
        await page.EnterActualCashValueAsync(data.Resolve("{{data:actual_cash_value_210}}"));
        await page.WaitForLoadingAsync("Absent");
        await page.PressSaveAsync("SHIFTTAB");
        await page.PressSaveAsync("SCROLL[-1]");
        await page.ClickRCTAsync();
        await page.ClickStandardRCTUseDefaultsAsync();
        await page.ClickGetValuationAsync();
        await page.WaitForLoadingAsync("Absent");
        await page.ClickSaveAsync();
        await page.WaitForLoadingAsync("Absent");
        data.Set("Screen", data.Resolve("{{data:screen_7}}"));
        if (!await page.IsScreenHeadingPresentAsync())
        {
                    await page.VerifyScreenHeadingAsync("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0174$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0174$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0174$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0174Async()
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
        data.Set("Screen", data.Resolve("{{data:screen_7}}"));
        if (!await page.IsLoadingPresentAsync())
        {
                    await page.WaitForLoadingAsync("Absent");
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.WaitForScreenHeading9696CAsync("Exists");
        }

    }

    [Given(@"^I enter FPP$")]
    [When(@"^I enter FPP$")]
    [Then(@"^I enter FPP$")]
    public async Task EnterFPPAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.PressSearchByNameOrCodeAsync("ENTER");
        await page.PressSearchByNameOrCodeAsync("Tab");
        await page.PressCheckBoxAsync("TAB");
        await page.PressAddCoverageAsync("TAB");
        await page.PressDescriptionAsync("ENTER");
        await page.PressDescriptionAsync("Tab");
        await page.PressLimitAsync("ENTER");
        await page.PressLimitAsync("Tab");
        await page.EnterDeductibleAsync(data.Resolve("{{data:deductible_231}}"));
        await page.ClickSaveAsync();
        data.Set("Screen", data.Resolve("{{data:screen_8}}"));
        if (!await page.IsScreenHeadingPresentAsync())
        {
                    await page.VerifyScreenHeadingAsync("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0184$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0184$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0184$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0184Async()
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
        data.Set("Screen", data.Resolve("{{data:screen_8}}"));
        if (!await page.IsLoadingPresentAsync())
        {
                    await page.WaitForLoadingAsync("Absent");
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.WaitForScreenHeading9696CAsync("Exists");
        }

    }

    [Given(@"^I complete equipment Breakdown and Implements Coverage$")]
    [When(@"^I complete equipment Breakdown and Implements Coverage$")]
    [Then(@"^I complete equipment Breakdown and Implements Coverage$")]
    public async Task CompleteEquipmentBreakdownAndImplementsCoverageAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.PressPowerGreaterThan250kwYesAsync("SHIFTTAB");
        await page.PressPowerGreaterThan250kwYesAsync("HOME");
        await page.PressPowerGreaterThan250kwNoAsync("SCROLL[1]");
        await page.WaitForLoadingAsync("Absent");
        await page.PressTwoOrMoreLossesNoAsync("SCROLL[1]");
        await page.WaitForLoadingAsync("Absent");
        await page.ClickGreaterThan25000NoAsync();
        await page.PressCombinedDeductibleAsync("TAB");
        await page.WaitForLoadingAsync("Absent");
        await page.ClickFarmImplementsNoAsync();
        await page.WaitForLoadingAsync("Absent");
        data.Set("Screen", data.Resolve("{{data:screen_9}}"));
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.VerifyScreenHeading9696CAsync("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0201$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0201$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0201$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0201Async()
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
        data.Set("Screen", data.Resolve("{{data:screen_9}}"));
        if (!await page.IsLoadingPresentAsync())
        {
                    await page.WaitForLoadingAsync("Absent");
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.WaitForScreenHeading9696CAsync("Exists");
        }

    }

    [Given(@"^I add bicycle$")]
    [When(@"^I add bicycle$")]
    [Then(@"^I add bicycle$")]
    public async Task AddBicycleAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new VehiclesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForScheduledPersonalPropertyHeaderAsync("Exists");
        await page.PressSearchByNameOrCodeAsync("ENTER");
        await page.PressSearchByNameOrCodeAsync("Tab");
        await page.ClickClientInfoSearchAsync();
        await page.EnterTrueAsync(data.Resolve("{{data:true_260}}"));
        await page.WaitForLoadingAsync("Absent");
        await page.WaitForAddCoverageAsync("Exists");
        await page.SelectAddCoverageAsync("");
        await page.PressDescriptionAsync("ENTER");
        await page.PressDescriptionAsync("Tab");
        await page.PressLimitAsync("ENTER");
        await page.PressLimitAsync("Tab");
        await page.WaitForLoadingAsync("Absent");
        await page.PressYearOfLastAppraisalAsync("ENTER");
        await page.PressYearOfLastAppraisalAsync("Tab");
        await page.ClickSaveAsync();
        data.Set("Screen", data.Resolve("{{data:screen_10}}"));
        if (!await page.IsScreenHeadingPresentAsync())
        {
                    await page.VerifyScreenHeadingAsync("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0215$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0215$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0215$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0215Async()
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
        data.Set("Screen", data.Resolve("{{data:screen_10}}"));
        if (!await page.IsLoadingPresentAsync())
        {
                    await page.WaitForLoadingAsync("Absent");
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.WaitForScreenHeading9696CAsync("Exists");
        }

    }

    [Given(@"^I complete nOT CE$")]
    [When(@"^I complete nOT CE$")]
    [Then(@"^I complete nOT CE$")]
    public async Task CompleteNOTCEAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.PressAddLiabilityYesAsync("SCROLL[-2]");
        await page.ClickAddLiabilityYesAsync();
        await page.WaitForLoadingAsync("Absent");
        await page.EnterLiabilityLimitAsync(data.Resolve("{{data:liability_limit_279}}"));
        await page.WaitForLoadingAsync("Absent");
        await page.PressLivestockHorsesAsync("ENTER");
        await page.PressLivestockHorsesAsync("Tab");
        await page.WaitForLoadingAsync("Absent");
        await page.PressLivestockSmallAsync("ENTER");
        await page.PressLivestockSmallAsync("Tab");
        await page.WaitForLoadingAsync("Absent");
        await page.PressLivestockLargeAsync("ENTER");
        await page.PressLivestockLargeAsync("Tab");
        await page.WaitForLoadingAsync("Absent");
        await page.PressUnlistedAcreageAsync("ENTER");
        await page.PressUnlistedAcreageAsync("Tab");
        await page.WaitForLoadingAsync("Absent");
        data.Set("Screen", data.Resolve("{{data:screen_11}}"));
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.VerifyScreenHeading9696CAsync("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0236$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0236$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0236$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0236Async()
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
        data.Set("Screen", data.Resolve("{{data:screen_11}}"));
        if (!await page.IsLoadingPresentAsync())
        {
                    await page.WaitForLoadingAsync("Absent");
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.WaitForScreenHeading9696CAsync("Exists");
        }

    }

    [Given(@"^I complete insurance Score$")]
    [When(@"^I complete insurance Score$")]
    [Then(@"^I complete insurance Score$")]
    public async Task CompleteInsuranceScoreAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.EnterEntityTypeAsync(data.Resolve("{{data:entity_type_296}}"));
        await page.PressInsuranceScoreConsentAsync("SHIFTTAB");
        await page.PressInsuranceScoreConsentAsync("SCROLL[-3]");
        await page.WaitForLoadingAsync("Absent");
        await page.ClickPrimaryInsuredAsync();
        await page.PauseAsync(1000);
        await page.ClickInsuranceScoreConsentAsync();
        await page.WaitForAcceptAsync("Exists");
        await page.ClickAcceptAsync();
        await page.WaitForLoadingAsync("Absent");
        data.Set("Screen", data.Resolve("{{data:screen_12}}"));
        if (!await page.IsScreenHeadingPresentAsync())
        {
                    await page.VerifyScreenHeadingAsync("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0250$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0250$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0250$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0250Async()
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
        data.Set("Screen", data.Resolve("{{data:screen_12}}"));
        if (!await page.IsLoadingPresentAsync())
        {
                    await page.WaitForLoadingAsync("Absent");
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.WaitForScreenHeading9696CAsync("Exists");
        }

    }

    [Given(@"^I complete mortgagee/Loss Payee Information$")]
    [When(@"^I complete mortgagee/Loss Payee Information$")]
    [Then(@"^I complete mortgagee/Loss Payee Information$")]
    public async Task CompleteMortgageeLossPayeeInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickADDADDITIONALINTERESTAsync();
        await page.ClickMortgageeSecuredPartyAsync();
        await page.WaitForLoadingAsync("Absent");
        await page.PressSearchNameAsync("ENTER");
        await page.PressSearchNameAsync("Tab");
        await page.PressSearchZipCodeAsync("TAB");
        await page.ClickClientInfoSearchAsync();
        await page.WaitForLoadingAsync("Absent");
        await page.EnterTrueAsync(data.Resolve("{{data:true_319}}"));
        await page.WaitForLocationPrimaryLocationAsync("Visible");
        await page.EnterLocationPrimaryLocationAsync("{STRINGTOUPPER[1918 Avalon Ave]}*");
        await page.EnterResidenceAsync(data.Resolve("{{data:residence_322}}"));
        await page.PressLocationPrimaryLocationAsync("TAB");
        await page.WaitForLoadingAsync("Absent");
        await page.PressAccountNumberAsync("TAB");
        await page.ClickCopyOfDecNoAsync();
        await page.WaitForLoadingAsync("Absent");
        await page.PressAccountNumberAsync("ENTER");
        await page.PressAccountNumberAsync("Tab");
        await page.PressDescriptionOfInterestAsync("ENTER");
        await page.PressDescriptionOfInterestAsync("Tab");
        await page.PressDescriptionOfInterestAsync("ENTER");
        await page.PressDescriptionOfInterestAsync("Tab");
        await page.WaitForLoadingAsync("Absent");
        await page.ClickEscrowBilledYesAsync();
        await page.WaitForLoadingAsync("Absent");
        await page.ClickSaveAsync();
        data.Set("Screen", data.Resolve("{{data:screen_13}}"));
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.VerifyScreenHeading9696CAsync("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0273$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0273$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0273$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0273Async()
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
        data.Set("Screen", data.Resolve("{{data:screen_13}}"));
        if (!await page.IsLoadingPresentAsync())
        {
                    await page.WaitForLoadingAsync("Absent");
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.WaitForScreenHeading9696CAsync("Exists");
        }

    }

    [Given(@"^I verify premium$")]
    [When(@"^I verify premium$")]
    [Then(@"^I verify premium$")]
    public async Task VerifyPremiumAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        data.Set("Total Premium", await page.CaptureTotalPremiumAsync("InnerText"));
        data.Set("Screen", data.Resolve("{{data:screen_14}}"));
        if (!await page.IsScreenHeadingPresentAsync())
        {
                    await page.VerifyScreenHeadingAsync("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0282$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0282$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0282$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0282Async()
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
        data.Set("Screen", data.Resolve("{{data:screen_14}}"));
        if (!await page.IsLoadingPresentAsync())
        {
                    await page.WaitForLoadingAsync("Absent");
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.WaitForScreenHeading9696CAsync("Exists");
        }

    }

    [Given(@"^I open a CLAS Browser and Search for EQ by Description 1$")]
    [When(@"^I open a CLAS Browser and Search for EQ by Description 1$")]
    [Then(@"^I open a CLAS Browser and Search for EQ by Description 1$")]
    public async Task OpenACLASBrowserAndSearchForEQByDescription1Async()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.NavigateAsync(data.Resolve("{{data:application_url}}"));
        await page.NavigateAsync(data.Resolve("{{data:application_url_2}}"));
        await page.WaitForBODY4F40DAsync("Exists");
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

    [Given(@"^I open a CLAS Browser and Search for EQ by Description 1 for username$")]
    [When(@"^I open a CLAS Browser and Search for EQ by Description 1 for username$")]
    [Then(@"^I open a CLAS Browser and Search for EQ by Description 1 for username$")]
    public async Task OpenACLASBrowserAndSearchForEQByDescription1ForUsernameAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsUserNameE0ACDPresentAsync())
        {
                    await page.VerifyUserNameE0ACDAsync("Absent", "");
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
        if (await page.IsLoggedInUser8A0DDPresentAsync())
        {
                    await page.ClickLoggedInUser8A0DDAsync();
        }
        if (await page.IsLogoutPresentAsync())
        {
                    await page.ClickLogoutAsync();
        }
        if (data.Condition("if an existing CLAS session is still logged in"))
        {
                    await page.NoteAsync("Source operation requires environment-specific implementation.");
        }
        if (await page.IsTheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0B8256PresentAsync())
        {
                    await page.VerifyTheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0B8256Async("Exists", "");
        }
        if (await page.IsEChecklistEChecklistOKPresentAsync())
        {
                    await page.ClickEChecklistEChecklistOKAsync();
        }
        if (await page.IsEChecklistEChecklistOKPresentAsync())
        {
                    await page.WaitForEChecklistEChecklistOKAsync("Absent");
        }
        if (await page.IsLoggedInUser8A0DDPresentAsync())
        {
                    await page.ClickLoggedInUser8A0DDAsync();
        }
        if (await page.IsLogoutPresentAsync())
        {
                    await page.ClickLogoutAsync();
        }

    }

    [Given(@"^I open a CLAS Browser and Search for EQ by Description 1 for open a clas browser and search for eq by description 1$")]
    [When(@"^I open a CLAS Browser and Search for EQ by Description 1 for open a clas browser and search for eq by description 1$")]
    [Then(@"^I open a CLAS Browser and Search for EQ by Description 1 for open a clas browser and search for eq by description 1$")]
    public async Task OpenACLASBrowserAndSearchForEQByDescription1ForOpenAClasBrowserAndSearchForEqByDescription1Async()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (data.Condition("if an existing CLAS session is still logged in"))
        {
                    await page.NavigateAsync(data.Resolve("{{data:application_url_2}}"));
        }
        await page.WaitForUserNameAsync("Exists");
        await _auth.SignInAsync("CL_DC");
        await page.WaitForLogin0D21AAsync("Absent");
        await page.EnterSearchModeAsync(data.Resolve("{{data:search_mode_379}}"));
        await page.EnterSearchTextAsync(data.Resolve("{B[LastName]}, {B[FirstName]}"));
        await page.PressSearchTextAsync("Tab");
        await page.ClickQuickSearchButtonAsync();
        await page.WaitForViewPolicyAsync("Exists");
        if (await page.IsLoadingMessagePresentAsync())
        {
                    await page.VerifyLoadingMessageAsync("Visible", "");
        }
        await page.WaitForLoadingAsync("Absent");
        await page.ClickViewPolicyAsync();
        if (await page.IsLoadingMessagePresentAsync())
        {
                    await page.VerifyLoadingMessageAsync("Visible", "");
        }
        await page.WaitForLoadingAsync("Absent");
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
        data.Set("ClipboardValue", "{\"Value\": \"{XB[QuoteID]}\"}");
        data.Set("ClipboardValue", "{\"Value\": \"{XB[QuoteID]}\"}");
        await page.NoteAsync("Browser-console/forms verification requires environment-specific implementation.");
        data.Set("ClipboardValue", "{\"Value\": \"{XB[SessionId]}\"}");
        data.Set("ClipboardValue", "{\"Value\": \"{XB[SessionId]}\"}");
        data.Set("ServerAddress", data.Resolve("{{data:serveraddress}}"));
        await page.EnterFormsAPIRequestB50D4Async(data.Resolve("{{runtime:SessionId}}"));
        await page.EnterFormsAPIResponse3FBAFAsync(data.Resolve("{{data:forms_api_response_401}}"));
        await page.NoteAsync("Browser-console/forms verification requires environment-specific implementation.");
        await page.NoteAsync("Browser-console/forms verification requires environment-specific implementation.");
        data.Set("PowershellArguments", data.Resolve("powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\SFP\\\" -FileName \"SFP_BASIC\" -State  \"AL\" -QuoteID \"{B[QuoteID]}\""));
        data.Set("ClipboardValue", "{\"Value\": \"SummaryResults\"}");
        data.Set("SummaryResults", data.Resolve("{{data:summaryresults}}"));
        data.Set("SummaryResults", data.Resolve("{{data:summaryresults_2}}"));
        data.Set("SummaryResults", data.Resolve("{{data:summaryresults_3}}"));
        data.Set("SummaryResults", data.Resolve("{{data:summaryresults_4}}"));

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

}
