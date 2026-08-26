using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLEQ.Pages;

namespace InsuranceAutomation.CLEQ.StepDefinitions;

[Binding, Scope(Feature = "EQ SFP Country Estate Policy")]
public sealed class EQSFPCountryEstatePolicySteps
{
    private readonly ScenarioContext _scenario;
    private readonly ApplicationLogin _auth;
    public EQSFPCountryEstatePolicySteps(ScenarioContext scenario) => _scenario = scenario;
    private ApplicationLogin Auth => _auth ?? new ApplicationLogin(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());

    [Given(@"^I enter client search information$")]
    [When(@"^I enter client search information$")]
    [Then(@"^I enter client search information$")]
    public async Task EnterClientSearchInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("LastName", "CE-[A-Z]{4}");
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
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets AdditionalInterestsNext
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

        // v54 RAW TOSCA ORDER. Source: EQ|Common|Account Details - Account Info.
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

        var county = data.GetCanonicalField("County");
        if (!string.IsNullOrWhiteSpace(county))
            await page.EnterCountyAsync(county);

        // Map/Satellite are generated only after address steering in raw Tosca.
        await page.VerifyMapAsync("Visible", "");
        await page.VerifySatelliteAsync("Visible", "");

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
        await page.SelectSpecialFarmPackageAsync("");
        await page.ClickSelectSFPCEAsync();
        await page.PressEffectiveDate78F67Async("ENTER");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets EffectiveDate78F67
        await page.EnterTrueAsync(data.Resolve("{{data:true_35}}"));
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets PolicyTerm
        await page.EnterPolicyTermAsync(data.Resolve("{{data:policyterm_37}}"));
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets StateDropdown
        await page.SelectStateAsync(data.Resolve("{{runtime:StateName}}"));
        await page.PressAgentPCAsync("ENTER");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets AgentPC
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
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets SubmitAngular
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

    }

    [Given(@"^I complete policy Details \(Optimized\)$")]
    [When(@"^I complete policy Details \(Optimized\)$")]
    [Then(@"^I complete policy Details \(Optimized\)$")]
    public async Task CompletePolicyDetailsOptimizedAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyInformationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickPrimaryFarmCategoryAsync();
        await page.WaitForPrimaryFarmTypeAsync("Exists");
        await page.ClickPrimaryFarmTypeAsync();
        await page.ClickAddSecondaryFarmTypeToggleAsync();
        await page.WaitForSecondaryFarmCategoryAsync("Visible");
        await page.ClickSecondaryFarmCategoryAsync();
        await page.WaitForSecondaryFarmTypeAsync("Exists");
        await page.ClickSecondaryFarmTypeAsync();
        await page.EnterGrossFarmIncomeAsync(data.Resolve("{{data:gross_farm_income_76}}"));
        if (data.Condition("'Industrial Hemp Answer' == \"No\""))
        {
                    await page.SelectIndustrialHempNoAsync("");
        }
        if (data.Condition("'Industrial Hemp Answer' == \"Yes\""))
        {
                    await page.SelectIndustrialHempYesAsync("");
        }
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
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets UncheckedNoneOfTheAbove
        }
        if (await page.IsResponseRequiredToContinuePresentAsync())
        {
                    await page.WaitForResponseRequiredToContinueAsync("Exists");
        }
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
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets ExistingClient
        await page.ClickNextSFPAsync();
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Save
        await page.ClickSaveAsync();
        if (data.Condition("ReadOnly == NULL"))
        {
                    await page.ClickEQCommonPrimaryInsuredRequiredAsync();
        }
        if (data.Condition("ReadOnly == NULL"))
        {
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets DescriptionOfOperations
        }
        if (data.Condition("ReadOnly == NULL"))
        {
                    await page.PressNumberOfFulltimeEmployeesAsync("ENTER");
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets NumberOfFulltimeEmployees
        }
        if (data.Condition("ReadOnly == NULL"))
        {
                    await page.PressNumberOfPartTimeEmployeesAsync("ENTER");
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets NumberOfPartTimeEmployees
        }
        if (data.Condition("ReadOnly == NULL"))
        {
                    await page.PressNumberOfSeasonalEmployeesAsync("ENTER");
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets NumberOfSeasonalEmployees
        }
        if (data.Condition("ReadOnly == NULL"))
        {
                    await page.ClickSaveAsync();
        }
        if (data.Condition("ReadOnly == NULL"))
        {
                    await page.VerifyDescriptionOfOperationsAsync(data.Resolve("{{runtime:QuoteDescription}}"), "");
        }
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets NoneOfTheAboveCheckbox
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

    [Given(@"^I complete edit Client Roles$")]
    [When(@"^I complete edit Client Roles$")]
    [Then(@"^I complete edit Client Roles$")]
    public async Task CompleteEditClientRolesAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets InspectionContact
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
        await page.EnterDescriptionOfTheBusinessExposuresActivitiesAndExperienceAsync(data.Resolve("{{data:description_of_the_business_exposures_activities_and_experience_130}}"));
        if (data.Condition("'Referred and Locked' != \"Yes\""))
        {
                    await page.ClickSaveAsync();
        }
        await page.WaitForUserDateAndTimestampAsync("Visible");
        await page.VerifyUserDateAndTimestampAsync(data.Resolve("{{data:expected_user_date_and_timestamp_innertext_133}}"), "NotEqual:InnerText");
        if (data.Condition("'Referred and Locked' == \"Yes\""))
        {
                    await page.VerifyLockedThisQuoteHasBeenSubmittedAndYouCanNoLongerMakeChangesToThisTextAsync("Exists", "");
        }
        await page.EnterDescriptionOfTheBusinessExposuresActivitiesAndExperienceAsync("");
        data.Set("Quote_Num", data.Resolve("{B[NameQuoteNum]}"));
        data.Set("Policy#", data.Resolve("{{data:policy}}"));
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
        if (!await page.IsLoadingPresentAsync())
        {
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
        await page.PressYearsInBusinessAsync("ENTER");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets YearsInBusiness
        await page.ClickN3YearsAsync();
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets N3Years
        await page.PressPriorInsuranceLatestExpirationDateAsync("ENTER");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets PriorInsuranceLatestExpirationDate
        await page.PressPriorInsuranceLatestCarrierAsync("ENTER");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets PriorInsuranceLatestCarrier

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
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets LocationDescription
        await page.PressMilesFromFDAsync("ENTER");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets MilesFromFD
        await page.EnterFeetFromHydrantAsync(data.Resolve("{{data:feet_from_hydrant_161}}"));
        await page.EnterTotalFarmingAcreageAsync(data.Resolve("{{data:total_farming_acreage_163}}"));
        await page.PressTotalFarmingAcreageAsync("SCROLL[1]");
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
        await page.WaitForAddResidenceHeaderAsync("Exists");
        await page.PressAdditionalDescriptionAsync("CTRL+A");
        await page.PressAdditionalDescriptionAsync("Enter");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets AdditionalDescription
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Frame
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets SingleFamily
        await page.PressYearBuiltAsync("CTRL+A");
        await page.PressYearBuiltAsync("Enter");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets YearBuilt
        await page.PauseAsync(1000);
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets PlumbingYear
        await page.WaitForAddResidenceHeaderAsync("Exists");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets RateType1
        await page.PressRoofYearAsync("CTRL+A");
        await page.PressRoofYearAsync("Enter");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets RoofYear
        await page.WaitForAddResidenceHeaderAsync("Exists");
        await page.EnterRoofType1Async(data.Resolve("{{data:roof_type_1_189}}"));
        await page.EnterRoofImpact1Async(data.Resolve("{{data:roof_impact_1_190}}"));
        await page.WaitForAddResidenceHeaderAsync("Exists");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets RoofYear
        await page.PressRoofYearAsync("SCROLL[2]");
        await page.WaitForAddResidenceHeaderAsync("Exists");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets ResidenceCoverage
        await page.PressResidenceCoverageAsync("SCROLL[-3]");
        await page.PauseAsync(1000);
        await page.ClickDoesTheClientHaveASolidFuelHeatingTypeNoAsync();
        await page.WaitForAddResidenceHeaderAsync("Exists");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets ResidenceCoverage
        await page.ClickResidenceCoverageAsync();

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
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets InsuranceAmount
        await page.PressSquareFeetAsync("ENTER");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets SquareFeet
        await page.PressActualCashValueAsync("SHIFTTAB");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets DoesTheResidenceHaveAThermostaticallyControlledDeviceYes
        await page.EnterActualCashValueAsync(data.Resolve("{{data:actual_cash_value_209}}"));
        await page.PressSaveAsync("SHIFTTAB");
        await page.PressSaveAsync("SCROLL[-1]");
        await page.ClickRCTAsync();
        await page.ClickStandardRCTUseDefaultsAsync();
        await page.ClickGetValuationAsync();
        await page.ClickSaveAsync();
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
        if (!await page.IsLoadingPresentAsync())
        {
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.WaitForScreenHeading9696CAsync("Exists");
        }

    }

    [Given(@"^I complete policy\-wide$")]
    [When(@"^I complete policy\-wide$")]
    [Then(@"^I complete policy\-wide$")]
    public async Task CompletePolicyWideAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForCECoverageAsync("Exists");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets AddCoverage
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets CECoverage
        if (data.Condition("CoverageType == \"Choice\""))
        {
                    await page.PressChoiceAsync("SHIFTTAB");
        }
        if (data.Condition("CoverageType == \"Choice Horse\""))
        {
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets ChoiceWithHorse
        }
        if (data.Condition("CoverageType == \"Select\""))
        {
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Select
        }
        if (data.Condition("CoverageType == \"Select Horse\""))
        {
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets SelectWithHorse
        }
        if (data.Condition("CoverageType == \"Premier\""))
        {
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Premier
        }
        if (data.Condition("CoverageType == \"Premier Horse\""))
        {
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets PremierWithHorse
        }
        await page.EnterWaterDamageAsync(data.Resolve("{{data:water_damage_234}}"));
        await page.EnterUnscheduledStructuresAsync(data.Resolve("{{data:unscheduled_structures_235}}"));
        await page.EnterBlanketFPPAsync(data.Resolve("{{data:blanket_fpp_236}}"));
        await page.EnterLiabilityLimitAsync(data.Resolve("{{data:liability_limit_239}}"));
        await page.ClickSaveAsync();
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
        if (!await page.IsLoadingPresentAsync())
        {
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
        await page.EnterEntityTypeAsync(data.Resolve("{{data:entity_type_248}}"));
        await page.PressInsuranceScoreConsentAsync("SHIFTTAB");
        await page.PressInsuranceScoreConsentAsync("SCROLL[-3]");
        await page.ClickPrimaryInsuredAsync();
        await page.PauseAsync(1000);
        await page.ClickInsuranceScoreConsentAsync();
        await page.WaitForAcceptAsync("Exists");
        await page.ClickAcceptAsync();
        if (!await page.IsScreenHeadingPresentAsync())
        {
                    await page.VerifyScreenHeadingAsync("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0198$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0198$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0198$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0198Async()
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
        await page.PressSearchNameAsync("ENTER");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets SearchName
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets SearchZipCode
        await page.ClickClientInfoSearchAsync();
        await page.EnterTrueAsync(data.Resolve("{{data:true_271}}"));
        await page.WaitForLocationPrimaryLocationAsync("Visible");
        await page.EnterLocationPrimaryLocationAsync(data.Resolve("{STRINGTOUPPER[1918 Avalon Ave]}*"));
        await page.EnterResidenceAsync(data.Resolve("{{data:residence_274}}"));
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets LocationPrimaryLocation
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets AccountNumber
        await page.ClickCopyOfDecNoAsync();
        await page.PressAccountNumberAsync("ENTER");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets AccountNumber
        await page.PressDescriptionOfInterestAsync("ENTER");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets DescriptionOfInterest
        await page.PressDescriptionOfInterestAsync("ENTER");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets DescriptionOfInterest
        await page.ClickEscrowBilledYesAsync();
        await page.ClickSaveAsync();
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.VerifyScreenHeading9696CAsync("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0221$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0221$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0221$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0221Async()
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

    [Given(@"^I verify premium$")]
    [When(@"^I verify premium$")]
    [Then(@"^I verify premium$")]
    public async Task VerifyPremiumAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (!await page.IsScreenHeadingPresentAsync())
        {
                    await page.VerifyScreenHeadingAsync("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen for subsequent screen 0230$")]
    [When(@"^I navigate to the required policy screen for subsequent screen 0230$")]
    [Then(@"^I navigate to the required policy screen for subsequent screen 0230$")]
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0230Async()
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
        // Source conditional not executed because no deterministic data/DOM condition was available: if an existing CLAS session is still logged in
        if (false)
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
        // Source conditional not executed because no deterministic data/DOM condition was available: if an existing CLAS session is still logged in
        if (false)
        {
                    await page.NavigateAsync(data.Resolve("{{data:application_url_2}}"));
        }
        await page.WaitForUserNameAsync("Exists");
        await Auth.SignInAsync("CL_DC");
        await page.WaitForLogin0D21AAsync("Absent");
        await page.EnterSearchModeAsync(data.Resolve("{{data:search_mode_331}}"));
        await page.EnterSearchTextAsync(data.Resolve("{B[LastName]}, {B[FirstName]}"));
        await page.ClickQuickSearchButtonAsync();
        await page.WaitForViewPolicyAsync("Exists");
        if (await page.IsLoadingMessagePresentAsync())
        {
                    await page.VerifyLoadingMessageAsync("Visible", "");
        }
        await page.ClickViewPolicyAsync();
        if (await page.IsLoadingMessagePresentAsync())
        {
                    await page.VerifyLoadingMessageAsync("Visible", "");
        }
        await page.NoteAsync("Source operation requires environment-specific implementation.");
        await page.EnterGetSessionIDBufferAsync(data.Resolve("{{data:get_session_id_buffer_342}}"));
        await page.EnterGetSessionIDBufferAsync(data.Resolve("{{data:get_session_id_buffer_343}}"));
        await page.EnterGetSessionIDBufferAsync(data.Resolve("{{runtime:SessionId}}"));

    }

    [Given(@"^I complete forms verification for EQ in CLAS$")]
    [When(@"^I complete forms verification for EQ in CLAS$")]
    [Then(@"^I complete forms verification for EQ in CLAS$")]
    public async Task CompleteFormsVerificationForEQInCLASAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        // Source conditional not executed because no deterministic data/DOM condition was available: during run the API and repeat if Content Length is less than 40 [max=4]
        if (false)
        {
        }
        if (await page.IsFormsAPIRequest01660PresentAsync())
        {
                    await page.EnterFormsAPIRequest01660Async(data.Resolve("{{runtime:SessionId}}"));
        }
        if (await page.IsFormsAPIResponse53891PresentAsync())
        {
                    await page.EnterFormsAPIResponse53891Async(data.Resolve("{{data:forms_api_response_348}}"));
        }
        if (await page.IsFormsAPIResponse53891PresentAsync())
        {
                    await page.EnterFormsAPIResponse53891Async(data.Resolve("{{data:forms_api_response_349}}"));
        }
        // Source conditional not executed because no deterministic data/DOM condition was available: during run the API and repeat if Content Length is less than 40 [max=4]
        if (false)
        {
                    await page.NoteAsync("Browser-console/forms verification requires environment-specific implementation.");
        }
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

}
