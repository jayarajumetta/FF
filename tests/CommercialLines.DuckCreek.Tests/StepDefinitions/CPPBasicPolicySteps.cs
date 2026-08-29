using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "CPP Basic Policy")]
public sealed class CPPBasicPolicySteps
{
    private readonly ScenarioContext _scenario;
    public CPPBasicPolicySteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I enter business client information$")]
    [When(@"^I enter business client information$")]
    [Then(@"^I enter business client information$")]
    public async Task EnterBusinessClientInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("PrimaryPhone_0041", "[0-9]{10}");
        data.GenerateRandom("FEIN_0044", "486[0-9]{6}");
        data.GenerateRandom("AuditTelephone_0045", "[0-9]{10}");
        data.GenerateRandom("InspectionTelephone_0045", "[0-9]{10}");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await page.EnterFEINAsync(data.Resolve("{{runtime:FEIN_0044}}"));

        await page.WaitForQuickQuoteAsync("Exists");
        await page.SetQuickQuoteAsync(data.Resolve("{{data:quick_quote_2}}"));
        await page.WaitForUnderwritingInfoAsync("Exists");
        await page.EnterInsuredTypeAsync(data.Resolve("{{data:insured_type_4}}"));
        await page.EnterEntityTypeAsync(data.Resolve("{{data:entity_type_8}}"));
        await page.WaitForBusinessNameAsync("Visible");
        await page.EnterBusinessNameAsync(data.Resolve("{{data:business_name_7}}"));
        await page.EnterPrimaryPhoneAsync(data.Resolve("{{runtime:PrimaryPhone_0041}}"));
        await page.EnterNamedInsuredZipCodeAsync(data.Resolve("{{data:zipcode_11}}"));
        await page.EnterAddressAsync(data.Resolve("{{data:address1_12}}"));
        await page.VerifyYearsInBusinessAsync("Exists", "");
        await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_14}}"));
        await page.EnterNameOfAuditContactAsync(data.Resolve("{{data:name_of_audit_contact_16}}"));
        await page.EnterAuditTelephoneAsync(data.Resolve("{{runtime:AuditTelephone_0045}}"));
        await page.EnterNameOfInspectionContactAsync(data.Resolve("{{data:name_of_inspection_contact_18}}"));
        await page.EnterInspectionTelephoneAsync(data.Resolve("{{runtime:InspectionTelephone_0045}}"));
        await page.EnterInsuredEMailAddressAsync(data.Resolve("{{data:insured_e_mail_address_20}}"));
        await page.EnterWebsiteAddressAsync(data.Resolve("{{data:website_address_21}}"));
        await page.VerifyNamedInsuredZipCodeAsync("[0-9]{5}-[0-9]{4}", "Regex:value");

    }

    [Given(@"^I add a new Associated Client \- Business Owner Type \- Click Add Client$")]
    [When(@"^I add a new Associated Client \- Business Owner Type \- Click Add Client$")]
    [Then(@"^I add a new Associated Client \- Business Owner Type \- Click Add Client$")]
    public async Task AddANewAssociatedClientBusinessOwnerTypeClickAddClientAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForAddClientAsync("Exists");
        await page.ClickAddClientAsync();
        await page.VerifyIndividualTypeAsync("Absent", "");

    }

    [Given(@"^I complete aJAX Error Check$")]
    [When(@"^I complete aJAX Error Check$")]
    [Then(@"^I complete aJAX Error Check$")]
    public async Task CompleteAJAXErrorCheckAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyAJAXErrorCheckAsync("Exists", "");

    }

    [Given(@"^I complete required billing information$")]
    [When(@"^I complete required billing information$")]
    [Then(@"^I complete required billing information$")]
    public async Task CompleteRequiredBillingInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickNavigationBillingAsync();
        await page.WaitForBillingAsync("Exists");
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_37}}"));
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_40}}"));
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_44}}"));
        await page.PauseAsync(1000);

    }

    [Given(@"^I complete the Associated Client Info$")]
    [When(@"^I complete the Associated Client Info$")]
    [Then(@"^I complete the Associated Client Info$")]
    public async Task CompleteTheAssociatedClientInfoAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("MiddleName_0057", "^[a-z]{1}$");
        data.GenerateRandom("LastName_0057", "^[a-z]{7}$");
        data.GenerateRandom("FirstName_0057", "^[a-z]{4}$");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.EnterIndividualTypeAsync(data.Resolve("{{data:individualtype_47}}"));
        await page.WaitForPleaseVerifySSNAsync("Exists");
        await page.EnterMiddleNameAsync(data.Resolve("{{runtime:MiddleName_0057}}"));
        await page.EnterLastNameAsync(data.Resolve("{{runtime:LastName_0057}}"));
        await page.EnterAddAssociatedClientDateOfBirthAsync(data.Resolve("{{data:dateofbirth_52}}"));
        await page.EnterAddressAsync(data.Resolve("{{data:address1_53}}"));
        await page.EnterCityAsync(data.Resolve("{{data:city_54}}"));
        await page.EnterStateAsync(data.Resolve("{{data:state_55}}"));
        await page.EnterNamedInsuredZipCodeAsync(data.Resolve("{{data:zipcode_56}}"));
        await page.EnterGenderAsync(data.Resolve("{{data:gender_57}}"));
        await page.WaitForClientSearchAsync("Exists");
        await page.ClickClientSearchAsync();
        await page.EnterFirstNameAsync(data.Resolve("{{runtime:FirstName_0057}}"));
        await page.VerifySearchResultsDuckCreekPolicyFirstCheckboxAsync("Absent", "");
        await page.ClickOKAsync();
        await page.ClickOrderSSNAsync();
        await page.PressAddAssociatedClientEnterSSNAsync("Enter");
        await page.EnterAddAssociatedClientEnterSSNAsync(data.Resolve("{{data:enter_ssn_65}}"));
        await page.VerifyVerifyAsync("Absent", "");
        await page.ClickCompleteAsync();
        await page.ClickAddAssociatedClientDetailAsync();
        await page.WaitForAddAssociatedClientEnterSSNAsync("Exists");
        await page.ClickVerifyAsync();
        await page.WaitForPleaseVerifySSNAsync("Absent");
        await page.ClickCompleteAsync();
        await page.WaitForAddAssociatedClientEnterSSNAsync("Exists");
        await page.ClickVerifyAsync();
        await page.WaitForPleaseVerifySSNAsync("Absent");
        await page.ClickCompleteAsync();
        await page.WaitForClientSearchAsync("Exists");
        await page.ClickClientSearchAsync();
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
        await page.WaitForClientSearchAsync("Absent");

    }

    [Given(@"^I complete required policy information$")]
    [When(@"^I complete required policy information$")]
    [Then(@"^I complete required policy information$")]
    public async Task CompleteRequiredPolicyInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickPolicyInfoAsync();
        await page.WaitForPolicyInfoHeaderAsync("Exists");
        await page.PauseAsync(1000);
        await page.EnterPolicyInfoRequiredAndOptionalFieldsEffectiveDateAsync(data.Resolve("{{data:effectivedate_86}}"));
        await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_87}}"));
        await page.PauseAsync(1000);
        await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_89}}"));
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_93}}"));
        await page.PauseAsync(1000);
        await page.WaitForPrimaryRatingStateAsync("Exists");
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_99}}"));
        await page.VerifyPriorAmericanNationalPolicyAsync("Absent", "");
        await page.VerifyWhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNationalAsync("Absent", "");
        await page.VerifyIsThisPolicyBeingFullyCancelledAsync("Absent", "");
        await page.PauseAsync(1000);
        await page.EnterTitleAsync(data.Resolve("{{data:title_104}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_105}}"));
        await page.VerifyResultAsync(data.Resolve("{{data:expected_result_value_106}}"), "value");
        await page.WaitForPolicyInfoHeaderAsync("Visible");
        await page.WaitForDescriptionOfSpecifiedOperationAsync("Visible");
        await page.EnterDescriptionOfSpecifiedOperationAsync(data.BuildQuoteDescription());
        data.Set("QuoteDescription", await page.CaptureDescriptionOfSpecifiedOperationAsync("value"));
        await page.PauseAsync(1000);

    }

    [Given(@"^I run insurance score$")]
    [When(@"^I run insurance score$")]
    [Then(@"^I run insurance score$")]
    public async Task RunInsuranceScoreAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyTheInsuranceScoreServiceHasReturnedTheFollowingErrorCREDITVENDORUNREACHABLEPLEASEREPROCESSAsync("Exists", "");
        await page.ClickInsuranceScoreConsentAsync();
        await page.WaitForAcceptAsync("Exists");
        await page.ClickAcceptAsync();
        await page.WaitForInsuranceScoreAsync("Exists");
        await page.ClickInsuranceScoreAsync();
        await page.VerifyReferenceNumberAsync(data.Resolve("{{data:expected_reference_number_innertext_120}}"), "InnerText");
        await page.PauseAsync(1000);
        await page.PauseAsync(1000);

    }

    [Given(@"^I select CPP Coverage \- GL$")]
    [When(@"^I select CPP Coverage \- GL$")]
    [Then(@"^I select CPP Coverage \- GL$")]
    public async Task SelectCPPCoverageGLAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        if (data.Condition("(State == \"MD\")||(State == \"NJ\")||(State == \"NY\")||(State == \"VT\")"))
        {
            await page.EnterEstimatedPremiumAsync("");
        }
        if (data.Condition("'CPP LOB' == \"GL\""))
        {
            await page.ClickGLAsync();
        }

    }

    [Given(@"^I select CPP Coverage \- CP$")]
    [When(@"^I select CPP Coverage \- CP$")]
    [Then(@"^I select CPP Coverage \- CP$")]
    public async Task SelectCPPCoverageCPAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        if (data.Condition("'CPP LOB' == \"CP\""))
        {
            await page.ClickCPAsync();
        }

    }

    [Given(@"^I select CPP Coverage \- IM$")]
    [When(@"^I select CPP Coverage \- IM$")]
    [Then(@"^I select CPP Coverage \- IM$")]
    public async Task SelectCPPCoverageIMAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        if (data.Condition("'CPP LOB' == \"IM\""))
        {
            await page.ClickIMAsync();
        }

    }

    [Given(@"^I select CP Detail$")]
    [When(@"^I select CP Detail$")]
    [Then(@"^I select CP Detail$")]
    public async Task SelectCPDetailAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        if (data.Condition("'CPP LOB' == \"CP\""))
        {
            await page.ClickCPDetailAsync();
        }

    }

    [Given(@"^I complete CP Fields$")]
    [When(@"^I complete CP Fields$")]
    [Then(@"^I complete CP Fields$")]
    public async Task CompleteCPFieldsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForPolicyCovgAsync("Exists");
        await page.EnterDoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackupAsync(data.Resolve("{{data:does_any_risk_generate_power_other_than_private_windmills_or_emergency_backup_129}}"));

    }

    [Given(@"^I complete mask Error Recovery$")]
    [When(@"^I complete mask Error Recovery$")]
    [Then(@"^I complete mask Error Recovery$")]
    public async Task CompleteMaskErrorRecoveryAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickStartAsync();

    }

    [Given(@"^I complete CP Fields for policy coverage$")]
    [When(@"^I complete CP Fields for policy coverage$")]
    [Then(@"^I complete CP Fields for policy coverage$")]
    public async Task CompleteCPFieldsForPolicyCoverageAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.EnterPolicyCoverageAsync(data.Resolve("{{data:policy_coverage_132}}"));
        if (data.Condition("'Property Extension Endorsements' != NULL"))
        {
            await page.EnterPropertyExtensionEndorsementsAsync(data.Resolve("{{data:property_extension_endorsements_133}}"));
        }
        if (data.Condition("'Utility Services' != NULL"))
        {
            await page.EnterUtilityServicesAsync(data.Resolve("{{data:utility_services_134}}"));
        }
        if (data.Condition("Fungus != NULL"))
        {
            await page.EnterFungusAsync(data.Resolve("{{data:fungus_135}}"));
        }

    }

    [Given(@"^I complete CP Fields for location$")]
    [When(@"^I complete CP Fields for location$")]
    [Then(@"^I complete CP Fields for location$")]
    public async Task CompleteCPFieldsForLocationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickWCNavigationLinksLocationAsync();
        await page.WaitForLocationAddressAsync("Exists");
        await page.EnterFeetFromHydrantAsync(data.Resolve("{{data:feet_from_hydrant_138}}"));
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.WaitForLocationAddressAsync("Exists");
        await page.EnterMilesFromFireDepartmentAsync(data.Resolve("{{data:miles_from_fire_department_144}}"));
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.VerifyFeetFromHydrantAsync(data.Resolve("{{data:expected_feet_from_hydrant_value_147}}"), "NotEqual:Value");
        await page.WaitForLocationAddressAsync("Exists");
        await page.EnterFeetFromHydrantAsync(data.Resolve("{{data:feet_from_hydrant_149}}"));
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.WaitForLocationAddressAsync("Exists");
        await page.ClickCallISOAsync();
        await page.ClickSelectPPCAsync();
        await page.ClickSelectAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.VerifyFeetFromHydrantAsync(data.Resolve("{{data:expected_feet_from_hydrant_value_158}}"), "NotEqual:Value");
        await page.WaitForLocationAddressAsync("Exists");
        await page.EnterFeetFromHydrantAsync(data.Resolve("{{data:feet_from_hydrant_160}}"));
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.WaitForLocationAddressAsync("Exists");
        await page.ClickOKAsync();

    }

    [Given(@"^I complete CP Fields for building$")]
    [When(@"^I complete CP Fields for building$")]
    [Then(@"^I complete CP Fields for building$")]
    public async Task CompleteCPFieldsForBuildingAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickBuildingAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickAddBuildingAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickLocationDetailAsync();
        if (data.Condition("Construction != NULL"))
        {
            await page.EnterBuildingDetailConstructionAsync(data.Resolve("{{data:construction_170}}"));
        }
        if (data.Condition("'Year Built' != NULL"))
        {
            await page.EnterYearBuiltAsync(data.Resolve("{{data:year_built_171}}"));
        }
        if (data.Condition("'Square Feet' != NULL"))
        {
            await page.EnterSquareFeetAsync(data.Resolve("{{data:square_feet_172}}"));
        }
        if (data.Condition("Stories != NULL"))
        {
            await page.EnterStoriesAsync(data.Resolve("{{data:stories_173}}"));
        }
        if (data.Condition("Interest != NULL"))
        {
            await page.EnterInterestAsync(data.Resolve("{{data:interest_174}}"));
        }
        if (data.Condition("'Roof Type' != NULL"))
        {
            await page.EnterRoofTypeAsync(data.Resolve("{{data:roof_type_175}}"));
        }
        if (data.Condition("Deductible != NULL"))
        {
            await page.EnterBuildingDetailDeductibleAsync(data.Resolve("{{data:deductible_176}}"));
        }
        if (data.Condition("'Deductible Increased Theft' != NULL"))
        {
            await page.EnterBuildingDetailDeductibleIncreasedTheftAsync(data.Resolve("{{data:deductible_increased_theft_177}}"));
        }
        if (data.Condition("'Deductible Wind Hail' != NULL"))
        {
            await page.EnterBuildingDetailDeductibleWindHailAsync(data.Resolve("{{data:deductible_wind_hail_178}}"));
        }
        if (data.Condition("'BG2 Symbol' != NULL"))
        {
            await page.EnterBG2SymbolAsync(data.Resolve("{{data:bg2_symbol_179}}"));
        }
        if (data.Condition("'BG2 Symbol Prefix' != NULL"))
        {
            await page.EnterBG2SymbolPrefixAsync(data.Resolve("{{data:bg2_symbol_prefix_180}}"));
        }
        if (data.Condition("'Is the building cooled?' != NULL"))
        {
            await page.EnterIsTheBuildingCooledAsync(data.Resolve("{{data:is_the_building_cooled_181}}"));
        }
        if (data.Condition("'Is the building heated with a Solid Fuel Heating Device?' != NULL"))
        {
            await page.EnterIsTheBuildingHeatedWithASolidFuelHeatingDeviceAsync(data.Resolve("{{data:is_the_building_heated_with_a_solid_fuel_heating_device_182}}"));
        }
        if (data.Condition("'Provide a List of Surrounding Exposure/Other Occupancies within 100 ft (Including North, East, South, and West)' != NULL"))
        {
            await page.EnterProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWestAsync(data.Resolve("{{data:provide_a_list_of_surrounding_exposure_other_occupancies_within_100_ft_including_north_east_south_and_west_183}}"));
        }
        if (data.Condition("'Eligible For Enhanced Wind Rating Program' != NULL"))
        {
            await page.EnterEligibleForEnhancedWindRatingProgramAsync(data.Resolve("{{data:eligible_for_enhanced_wind_rating_program_184}}"));
        }
        await page.ClickOKAsync();

    }

    [Given(@"^I add a Rating Group$")]
    [When(@"^I add a Rating Group$")]
    [Then(@"^I add a Rating Group$")]
    public async Task AddARatingGroupAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickRatingGroupsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        if (data.Condition("Description != NULL"))
        {
            await page.EnterRatingGroupsDescriptionAsync(data.Resolve("{{data:description_188}}"));
        }
        if (data.Condition("'Risk Type' != NULL"))
        {
            await page.EnterRiskTypeAsync(data.Resolve("{{data:risk_type_189}}"));
        }
        if (data.Condition("Coinsurance != NULL"))
        {
            await page.EnterRatingGroupsCoinsuranceAsync(data.Resolve("{{data:coinsurance_190}}"));
        }
        if (data.Condition("Deductible != NULL"))
        {
            await page.EnterRatingGroupsDeductibleAsync(data.Resolve("{{data:deductible_191}}"));
        }
        if (data.Condition("'Deductible Increased Theft' != NULL"))
        {
            await page.EnterRatingGroupsDeductibleIncreasedTheftAsync(data.Resolve("{{data:deductible_increased_theft_192}}"));
        }
        if (data.Condition("'Deductible Wind Hail' != NULL"))
        {
            await page.EnterRatingGroupsDeductibleWindHailAsync(data.Resolve("{{data:deductible_wind_hail_193}}"));
        }
        if (data.Condition("'Cause Of Loss' != NULL"))
        {
            await page.EnterCauseOfLossAsync(data.Resolve("{{data:cause_of_loss_194}}"));
        }
        if (data.Condition("Valuation != NULL"))
        {
            await page.EnterValuationAsync(data.Resolve("{{data:valuation_195}}"));
        }
        await page.ClickAddGroupAsync();

    }

    [Given(@"^I complete Structure Questions$")]
    [When(@"^I complete Structure Questions$")]
    [Then(@"^I complete Structure Questions$")]
    public async Task CompleteStructureQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickPropertyAsync();
        if (data.Condition("'Increased Pollutant Cleanup' != NULL"))
        {
            await page.EnterIncreasedPollutantCleanupAsync(data.Resolve("{{data:increased_pollutant_cleanup_198}}"));
        }
        if (data.Condition("'Debris Removal Additional' != NULL"))
        {
            await page.EnterDebrisRemovalAdditionalAsync(data.Resolve("{{data:debris_removal_additional_199}}"));
        }
        if (data.Condition("'Debris Removal Additional Limit' != NULL"))
        {
            await page.EnterDebrisRemovalAdditionalLimitAsync(data.Resolve("{{data:debris_removal_additional_limit_200}}"));
        }
        if (data.Condition("'Vacant Building' != NULL"))
        {
            await page.EnterVacantBuildingAsync(data.Resolve("{{data:vacant_building_201}}"));
        }
        if (data.Condition("'% Occupied' != NULL"))
        {
            await page.EnterOccupiedAsync(data.Resolve("{{data:occupied_202}}"));
        }
        if (data.Condition("'Pier Or Wharf' != NULL"))
        {
            await page.EnterPierOrWharfAsync(data.Resolve("{{data:pier_or_wharf_203}}"));
        }
        if (data.Condition("'Pier Or Wharf Construction' != NULL"))
        {
            await page.EnterPierOrWharfConstructionAsync(data.Resolve("{{data:pier_or_wharf_construction_204}}"));
        }
        if (data.Condition("'Pier Or Wharf Cause Of Loss' != NULL"))
        {
            await page.EnterPierOrWharfCauseOfLossAsync(data.Resolve("{{data:pier_or_wharf_cause_of_loss_205}}"));
        }
        if (data.Condition("'Pier Or Wharf COL Options' != NULL"))
        {
            await page.EnterPierOrWharfCOLOptionsAsync(data.Resolve("{{data:pier_or_wharf_col_options_206}}"));
        }
        if (data.Condition("'Vacancy Permit' != NULL"))
        {
            await page.EnterVacancyPermitAsync(data.Resolve("{{data:vacancy_permit_207}}"));
        }
        if (data.Condition("'Pier Or Wharf COL Options' != NULL"))
        {
            await page.WaitForPierOrWharfCOLOptionsAsync("Exists");
        }
        await page.ClickAddClassAsync();
        if (data.Condition("(State !=\"OR\")||(State!=\"WA\")||(State!=\"VT\")"))
        {
            await page.EnterPropertyAddClassSearchValueAsync(data.Resolve("{{data:search_value_210}}"));
        }
        if (data.Condition("(State !=\"OR\")||(State!=\"WA\")||(State!=\"VT\")"))
        {
            await page.EnterSearchResultsAsync(data.Resolve("{{data:search_results_211}}"));
        }
        await page.EnterOccupancyTypeAsync(data.Resolve("{{data:occupancy_type_212}}"));
        if (data.Condition("(State ==\"OR\")||(State==\"WA\")"))
        {
            await page.EnterSearchResultsAsync("");
        }
        await page.ClickOKAsync();
        await page.EnterBuildingRatingGroupAsync(data.Resolve("{{data:building_rating_group_215}}"));
        await page.EnterBuildingLimitAsync(data.Resolve("{{data:building_limit_216}}"));
        await page.EnterPersonalPropertyRatingGroupAsync(data.Resolve("{{data:personal_property_rating_group_217}}"));
        await page.EnterPersonalPropertyLimitAsync(data.Resolve("{{data:personal_property_limit_218}}"));
        await page.EnterPropertyOfOthersRatingGroupAsync(data.Resolve("{{data:property_of_others_rating_group_219}}"));
        await page.EnterPropertyOfOthersLimitAsync(data.Resolve("{{data:property_of_others_limit_220}}"));
        if (data.Condition("(State ==\"OR\")||(State==\"WA\")"))
        {
            await page.EnterPropertyAddClassSearchValueAsync(data.Resolve("{{data:search_value_221}}"));
        }
        await page.ClickLocationDetailAsync();
        await page.EnterEstimatorTypeAsync(data.Resolve("{{data:estimator_type_223}}"));
        await page.EnterValuationTypeAsync(data.Resolve("{{data:valuation_type_224}}"));
        await page.ClickCreateValuationAsync();
        await page.ClickGetCalculatedValueAsync();
        await page.ClickOKAsync();

    }

    [Given(@"^I complete ensure Property of Others Rating Group has been entered$")]
    [When(@"^I complete ensure Property of Others Rating Group has been entered$")]
    [Then(@"^I complete ensure Property of Others Rating Group has been entered$")]
    public async Task CompleteEnsurePropertyOfOthersRatingGroupHasBeenEnteredAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyPropertyOfOthersRatingGroupAsync(data.Resolve("{{data:expected_property_of_others_rating_group_value_228}}"), "NotEqual:Value");
        await page.VerifyPropertyOfOthersRatingGroupAsync(data.Resolve("{{data:expected_property_of_others_rating_group_value_229}}"), "NotEqual:Value");
        await page.EnterPropertyOfOthersRatingGroupAsync(data.Resolve("{{data:property_of_others_rating_group_230}}"));

    }

    [Given(@"^I add Addl Interests$")]
    [When(@"^I add Addl Interests$")]
    [Then(@"^I add Addl Interests$")]
    public async Task AddAddlInterestsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LossHistoryPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickAddlInterestsAsync();
        await page.ClickAddAddlInterestAsync();
        await page.EnterTypeAsync(data.Resolve("{{data:type_233}}"));
        await page.EnterLoanNumberAsync(data.Resolve("{{data:loan_number_234}}"));
        await page.EnterInsuredTypeAsync(data.Resolve("{{data:insured_type_235}}"));
        await page.EnterFirstNameAsync(data.Resolve("{{data:first_name_236}}"));
        await page.EnterMIAsync(data.Resolve("{{data:mi_237}}"));
        await page.EnterLastNameAsync(data.Resolve("{{data:last_name_238}}"));
        await page.EnterLossAddressAsync(data.Resolve("{{data:address_1_239}}"));
        await page.EnterZipCodeAsync(data.Resolve("{{data:zip_code_240}}"));
        await page.EnterProvisionsApplicableAsync(data.Resolve("{{data:provisions_applicable_241}}"));
        await page.EnterDescriptionOfPropertyAsync(data.Resolve("{{data:description_of_property_242}}"));
        await page.ClickAssignLocationsAsync();
        await page.WaitForOtherInterestPremisesScheduleAsync("Exists");
        await page.ClickNewAssignmentAsync();
        await page.WaitForNewAssignmentAsync("Exists");
        await page.ClickOtherInterestPremisesDetailOKAsync();
        await page.WaitForAssignmentScheduleForAsync("Exists");
        await page.ClickAssignmentScheduleForOKAsync();
        await page.ClickOtherInterestPremisesScheduleOKAsync();
        if (data.Condition("State != \"OR\""))
        {
            await page.ClickAddlInterestsMainOKAsync();
        }

    }

    [Given(@"^I complete Property UW Questions$")]
    [When(@"^I complete Property UW Questions$")]
    [Then(@"^I complete Property UW Questions$")]
    public async Task CompletePropertyUWQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickPropertyUWQuestionsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickPropertyUWQuestionsUpdateAnswersAsync();

    }

    [Given(@"^I return to CPP Navigation$")]
    [When(@"^I return to CPP Navigation$")]
    [Then(@"^I return to CPP Navigation$")]
    public async Task ReturnToCPPNavigationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickReturnToCPPAsync();

    }

    [Given(@"^I select GL Detail$")]
    [When(@"^I select GL Detail$")]
    [Then(@"^I select GL Detail$")]
    public async Task SelectGLDetailAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickPolicyInfoAsync();
        if (data.Condition("'CPP LOB' == \"GL\""))
        {
            await page.ClickGLDetailAsync();
        }

    }

    [Given(@"^I complete CGL Fields$")]
    [When(@"^I complete CGL Fields$")]
    [Then(@"^I complete CGL Fields$")]
    public async Task CompleteCGLFieldsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForPolicyCovgGLPolicyCovgAsync("Exists");
        if (data.Condition("'Occurence Limit' != NULL"))
        {
            await page.EnterOccurenceLimitAsync(data.Resolve("{{data:occurence_limit_259}}"));
        }
        if (data.Condition("'Aggregate Limit' != NULL"))
        {
            await page.EnterAggregateLimitAsync(data.Resolve("{{data:aggregate_limit_260}}"));
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.EnterProductsAggLimitAsync("");
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.EnterDedTypeAsync(data.Resolve("{{data:ded_type_262}}"));
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.EnterDeductibleBasisAsync(data.Resolve("{{data:deductible_basis_263}}"));
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.EnterPremOpDedAsync(data.Resolve("{{data:premop_ded_264}}"));
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.EnterPremOpPDDedAsync("");
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.SetSplitBIDedAsync(data.Resolve("{{data:split_bi_ded_266}}"));
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.EnterSplitPDDedAsync("");
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.EnterProdBIDedAsync(data.Resolve("{{data:prod_bi_ded_268}}"));
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.EnterProdPDDedAsync("");
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.EnterFireDamageAsync("");
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.EnterMedicalAsync("");
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.EnterPersAdvInjAsync("");
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.EnterIsTheInsuredEngagedInAnySnowOrIceRemovalOperationsAsync(data.Resolve("{{data:is_the_insured_engaged_in_any_snow_or_ice_removal_operations_273}}"));
        }
        if (data.Condition("(State==\"NY\")||(State == \"NJ\")||(State == \"WV\")||(State == \"MA\")||(State == \"CT\")||(State == \"ME\")||(State == \"NH\")||(State == \"OR\")||(State == \"AZ\")||(State == \"PA\")||(State == \"MD\")||(State == \"DE\")||(State == \"RI\")||(State == \"VA\")||(State == \"VT\")&& 'Coverage Form' != \"OCP\""))
        {
            await page.EnterOfFullTimeEmployeesAsync(data.Resolve("{{data:of_full_time_employees_274}}"));
        }
        if (data.Condition("(State==\"NY\")||(State == \"NJ\")||(State == \"WV\")||(State == \"MA\") ||(State == \"CT\")||(State == \"ME\")||(State == \"NH\")||(State == \"OR\")||(State == \"AZ\")||(State == \"PA\")||(State == \"MD\")||(State == \"DE\")||(State == \"RI\")||(State == \"VA\")||(State == \"VT\")&& 'Coverage Form' != \"OCP\""))
        {
            await page.EnterOfPartTimeEmployeesAsync(data.Resolve("{{data:of_part_time_employees_275}}"));
        }
        if (data.Condition("(State==\"NY\")||(State == \"NJ\")||(State == \"WV\")||(State == \"MA\")||(State == \"CT\")||(State == \"ME\")||(State == \"NH\")||(State == \"OR\") ||(State == \"AZ\")||(State == \"PA\")||(State == \"MD\")||(State == \"DE\")||(State == \"RI\")||(State == \"VA\")||(State == \"VT\")&& 'Coverage Form' != \"OCP\""))
        {
            await page.EnterOfSeasonalTemporaryEmployeesAsync(data.Resolve("{{data:of_seasonal_temporary_employees_276}}"));
        }

    }

    [Given(@"^I add Class$")]
    [When(@"^I add Class$")]
    [Then(@"^I add Class$")]
    public async Task AddClassAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickCGLAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickAddClassAsync();
        await page.EnterSearchResultsAsync(data.Resolve("{{data:search_results_280}}"));
        await page.ClickOKAsync();
        await page.EnterExposureAsync(data.Resolve("{{data:exposure_282}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I add \[CG0435\] Employee Benefits Liability Endorsement$")]
    [When(@"^I add \[CG0435\] Employee Benefits Liability Endorsement$")]
    [Then(@"^I add \[CG0435\] Employee Benefits Liability Endorsement$")]
    public async Task AddCG0435EmployeeBenefitsLiabilityEndorsementAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        if (data.Condition("'Navigate to Endorsements Screen first time' != NULL"))
        {
            await page.ClickGLNavigationLinksEndorsementsAsync();
        }
        await page.WaitForEndorsementsAsync("Exists");
        await page.ClickEndorsementsAddEndorsementAsync();
        await page.EnterCG2401NonBindingArbitrationEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_287}}"));
        await page.EnterNumberOfEmployeesAsync(data.Resolve("{{data:number_of_employees_288}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I add \[CG2142\] Exclusion \- Explosion, Collapse and Underground Property Damage Hazard \(Specified Operations\)$")]
    [When(@"^I add \[CG2142\] Exclusion \- Explosion, Collapse and Underground Property Damage Hazard \(Specified Operations\)$")]
    [Then(@"^I add \[CG2142\] Exclusion \- Explosion, Collapse and Underground Property Damage Hazard \(Specified Operations\)$")]
    public async Task AddCG2142ExclusionExplosionCollapseAndUndergroundPropertyDamageHazardSpecifiedOperationsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        if (data.Condition("'Navigate to Endorsements Screen first time' != NULL"))
        {
            await page.ClickGLNavigationLinksEndorsementsAsync();
        }
        await page.WaitForEndorsementsAsync("Exists");
        await page.ClickEndorsementsAddEndorsementAsync();
        await page.EnterCG2401NonBindingArbitrationEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_293}}"));
        await page.SetExcludeExplosionHazardAsync(data.Resolve("{{data:exclude_explosion_hazard_294}}"));
        await page.SetExcludeCollapseHazardAsync(data.Resolve("{{data:exclude_collapse_hazard_295}}"));
        await page.SetExcludeUndergroundPropertyDamageHazardAsync(data.Resolve("{{data:exclude_underground_property_damage_hazard_296}}"));
        await page.EnterDescriptionOfOperationSAsync(data.Resolve("{{data:description_of_operation_s_297}}"));
        if (data.Condition("State != \"VA\""))
        {
            await page.ClickExcludeUndergroundPropertyDamageHazardAsync();
        }
        if (data.Condition("State == \"VA\""))
        {
            await page.ClickExcludeUndergroundPropertyDamageHazardAsync();
        }

    }

    [Given(@"^I add \[CG 2149\] Total Pollution Exclusion Endorsement$")]
    [When(@"^I add \[CG 2149\] Total Pollution Exclusion Endorsement$")]
    [Then(@"^I add \[CG 2149\] Total Pollution Exclusion Endorsement$")]
    public async Task AddCG2149TotalPollutionExclusionEndorsementAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        if (data.Condition("'Navigate to Endorsements Screen first time' != NULL"))
        {
            await page.ClickGLNavigationLinksEndorsementsAsync();
        }
        await page.WaitForEndorsementsAsync("Exists");
        await page.ClickEndorsementsAddEndorsementAsync();
        await page.EnterCG2401NonBindingArbitrationEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_303}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I verify and Fill out \[FG0055\] Employment Practices Liability Insurance Coverage Endorsement$")]
    [When(@"^I verify and Fill out \[FG0055\] Employment Practices Liability Insurance Coverage Endorsement$")]
    [Then(@"^I verify and Fill out \[FG0055\] Employment Practices Liability Insurance Coverage Endorsement$")]
    public async Task VerifyAndFillOutFG0055EmploymentPracticesLiabilityInsuranceCoverageEndorsementAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForFGFormTableRowAsync("Exists");
        await page.VerifyFG0055TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementAsync("Exists", "");
        await page.ClickDetailAsync();
        await page.EnterLimitDeductibleAsync(data.Resolve("{{data:limit_deductible_308}}"));
        await page.EnterHasTheInsuredEverHadAClaimForEmploymentPracticesAsync(data.Resolve("{{data:has_the_insured_ever_had_a_claim_for_employment_practices_309}}"));
        await page.EnterTheInsuredAndAnyExecutiveOfficerOrOwnerHasKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaintAsync(data.Resolve("{{data:the_insured_and_any_executive_officer_or_owner_has_knowledge_or_information_of_any_act_error_or_omission_which_might_give_rise_to_an_epl_claim_suit_or_complaint_310}}"));
        await page.EnterThirdPartyAsync(data.Resolve("{{data:third_party_311}}"));
        await page.ClickPolicyCovgAccountsReceivableOKAsync();

    }

    [Given(@"^I add Addl Interest \[CG2007\] \- Engineers$")]
    [When(@"^I add Addl Interest \[CG2007\] \- Engineers$")]
    [Then(@"^I add Addl Interest \[CG2007\] \- Engineers$")]
    public async Task AddAddlInterestCG2007EngineersAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickGLNavigationLinksAddlInterestsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickAddAddlInterestAsync();
        if (data.Condition("Type != NULL"))
        {
            await page.WaitForCG2007AddLInsuredEngineersArchitectsTypeAsync("Exists");
        }
        await page.ClickOKAsync();
        if (data.Condition("Type != NULL"))
        {
            await page.ClickCG2007AddLInsuredEngineersArchitectsTypeAsync();
        }
        if (data.Condition("Type != NULL"))
        {
            await page.EnterCG2007AddLInsuredEngineersArchitectsTypeAsync(data.Resolve("{{data:type_319}}"));
        }

    }

    [Given(@"^I add Addl Interest \[CG2020\] Add'l Insured\-Charitable Institution$")]
    [When(@"^I add Addl Interest \[CG2020\] Add'l Insured\-Charitable Institution$")]
    [Then(@"^I add Addl Interest \[CG2020\] Add'l Insured\-Charitable Institution$")]
    public async Task AddAddlInterestCG2020AddLInsuredCharitableInstitutionAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickGLNavigationLinksAddlInterestsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickAddAddlInterestAsync();
        if (data.Condition("Type != NULL"))
        {
            await page.EnterCG2007AddLInsuredEngineersArchitectsTypeAsync(data.Resolve("{{data:type_323}}"));
        }
        if (data.Condition("'Type of License' != NULL"))
        {
            await page.EnterTypeOfLicenseAsync(data.Resolve("{{data:type_of_license_324}}"));
        }
        await page.ClickOKAsync();

    }

    [Given(@"^I add Addl Interest \[CG2023\] Add'l Insured\-Executors$")]
    [When(@"^I add Addl Interest \[CG2023\] Add'l Insured\-Executors$")]
    [Then(@"^I add Addl Interest \[CG2023\] Add'l Insured\-Executors$")]
    public async Task AddAddlInterestCG2023AddLInsuredExecutorsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickGLNavigationLinksAddlInterestsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickAddAddlInterestAsync();
        if (data.Condition("Type != NULL"))
        {
            await page.EnterCG2007AddLInsuredEngineersArchitectsTypeAsync(data.Resolve("{{data:type_329}}"));
        }
        await page.ClickOKAsync();

    }

    [Given(@"^I add Addl Interest \[CG2025\] Add'l Insured\-Executive Officers$")]
    [When(@"^I add Addl Interest \[CG2025\] Add'l Insured\-Executive Officers$")]
    [Then(@"^I add Addl Interest \[CG2025\] Add'l Insured\-Executive Officers$")]
    public async Task AddAddlInterestCG2025AddLInsuredExecutiveOfficersAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickGLNavigationLinksAddlInterestsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickAddAddlInterestAsync();
        if (data.Condition("Type != NULL"))
        {
            await page.EnterCG2007AddLInsuredEngineersArchitectsTypeAsync(data.Resolve("{{data:type_334}}"));
        }
        await page.ClickOKAsync();

    }

    [Given(@"^I add Addl Interest \[CG2034\] Add'l Insured\-Leased Equipment Automatic$")]
    [When(@"^I add Addl Interest \[CG2034\] Add'l Insured\-Leased Equipment Automatic$")]
    [Then(@"^I add Addl Interest \[CG2034\] Add'l Insured\-Leased Equipment Automatic$")]
    public async Task AddAddlInterestCG2034AddLInsuredLeasedEquipmentAutomaticAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickGLNavigationLinksAddlInterestsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickAddAddlInterestAsync();
        if (data.Condition("Type != NULL"))
        {
            await page.EnterCG2007AddLInsuredEngineersArchitectsTypeAsync(data.Resolve("{{data:type_339}}"));
        }
        if (data.Condition("'Type of Equipment' != NULL"))
        {
            await page.EnterTypeOfEquipmentAsync(data.Resolve("{{data:type_of_equipment_340}}"));
        }
        await page.ClickOKAsync();

    }

    [Given(@"^I answer GL UW Questions OR \& WA$")]
    [When(@"^I answer GL UW Questions OR \& WA$")]
    [Then(@"^I answer GL UW Questions OR \& WA$")]
    public async Task AnswerGLUWQuestionsORWAAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickGLUWQuestionsAsync();
        await page.WaitForGeneralLiabilityInformationAsync("Exists");
        await page.ClickUWQuestionsUmbrellaUpdateAnswersAsync();
        await page.EnterDescribeAllHoldHarmlessAgreementsAndPleaseProvideACopyAsync(data.Resolve("{{data:describe_all_hold_harmless_agreements_and_please_provide_a_copy_345}}"));
        await page.ClickGeneralLiabilityInformationAsync();
        await page.ClickGLUWQuestionsAsync();
        await page.WaitForGeneralLiabilityInformationAsync("Exists");
        await page.ClickProductsCompletedOpsButtonAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickUWQuestionsUmbrellaUpdateAnswersAsync();
        await page.ClickOKAsync();

    }

    [Given(@"^I return to CPP Navigation for return to cpp$")]
    [When(@"^I return to CPP Navigation for return to cpp$")]
    [Then(@"^I return to CPP Navigation for return to cpp$")]
    public async Task ReturnToCPPNavigationForReturnToCppAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickReturnToCPPAsync();

    }

    [Given(@"^I select IM Detail$")]
    [When(@"^I select IM Detail$")]
    [Then(@"^I select IM Detail$")]
    public async Task SelectIMDetailAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        if (data.Condition("'CPP LOB' == \"IM\""))
        {
            await page.ClickIMDetailAsync();
        }

    }

    [Given(@"^I add Accounts Receivable Coverage$")]
    [When(@"^I add Accounts Receivable Coverage$")]
    [Then(@"^I add Accounts Receivable Coverage$")]
    public async Task AddAccountsReceivableCoverageAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForPolicyCovgMainPolicyCovgAsync("Exists");
        await page.EnterCoverageFormToBeAddedAsync(data.Resolve("{{data:coverage_form_to_be_added_356}}"));
        await page.ClickAddCoverageFormAsync();
        await page.EnterDescriptionAsync(data.Resolve("{{data:description_358}}"));
        await page.EnterCoinsuranceAsync(data.Resolve("{{data:coinsurance_359}}"));
        await page.EnterAwayFromPremisesLmtAsync(data.Resolve("{{data:away_from_premises_lmt_360}}"));
        await page.EnterAwayFromPremisesDescAsync(data.Resolve("{{data:away_from_premises_desc_361}}"));
        await page.ClickPolicyCovgAccountsReceivableOKAsync();

    }

    [Given(@"^I add Bailees Customers Coverage$")]
    [When(@"^I add Bailees Customers Coverage$")]
    [Then(@"^I add Bailees Customers Coverage$")]
    public async Task AddBaileesCustomersCoverageAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickIMNavigationLinksPolicyCovgAsync();
        await page.WaitForPolicyCovgMainPolicyCovgAsync("Exists");
        await page.EnterCoverageFormToBeAddedAsync(data.Resolve("{{data:coverage_form_to_be_added_365}}"));
        await page.ClickAddCoverageFormAsync();
        await page.WaitForPolicyCovgBaileesCutomersCoverageFormDisplayAsync("Exists");
        await page.EnterPolicyCovgBaileesCutomersDescriptionAsync(data.Resolve("{{data:description_369}}"));
        await page.EnterPolicyCovgBaileesCutomersPropertyInTransitAsync(data.Resolve("{{data:property_in_transit_370}}"));
        await page.ClickPropertyAwayFromYourPremisesScheduleAsync();
        await page.ClickAddPremisesAsync();
        await page.EnterAddressStreetCityStateZipAsync(data.Resolve("{{data:address_street_city_state_zip_373}}"));
        await page.EnterPolicyCovgBaileesPropertyAwayFromYourPremisesLimitAsync(data.Resolve("{{data:limit_374}}"));
        await page.ClickOKAsync();
        await page.WaitForPolicyCovgBaileesCutomersCoverageFormDisplayAsync("Exists");
        await page.ClickOKAsync();

    }

    [Given(@"^I add Computer Systems$")]
    [When(@"^I add Computer Systems$")]
    [Then(@"^I add Computer Systems$")]
    public async Task AddComputerSystemsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickIMNavigationLinksPolicyCovgAsync();
        await page.WaitForPolicyCovgMainPolicyCovgAsync("Exists");
        await page.EnterCoverageFormToBeAddedAsync(data.Resolve("{{data:coverage_form_to_be_added_380}}"));
        await page.ClickAddCoverageFormAsync();
        await page.WaitForPolicyCovgComputerSystemsCoverageFormDisplayAsync("Exists");
        await page.EnterPolicyCovgComputerSystemsDescriptionAsync(data.Resolve("{{data:description_384}}"));
        await page.EnterPolicyCovgComputerSystemsDeductibleAsync(data.Resolve("{{data:deductible_385}}"));
        await page.EnterPolicyCovgComputerSystemsCoinsuranceAsync(data.Resolve("{{data:coinsurance_386}}"));
        await page.EnterPolicyCovgComputerSystemsPropertyInTransitAsync(data.Resolve("{{data:property_in_transit_387}}"));
        await page.EnterUnnamedPremisesAsync(data.Resolve("{{data:unnamed_premises_388}}"));
        await page.EnterPersonalPortableComputersAsync(data.Resolve("{{data:personal_portable_computers_389}}"));
        await page.EnterExtraExpenseAsync(data.Resolve("{{data:extra_expense_390}}"));
        await page.EnterVirusHarmfulCodeOrSimilarInstructionAsync(data.Resolve("{{data:virus_harmful_code_or_similar_instruction_391}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I add Contractors Equipment$")]
    [When(@"^I add Contractors Equipment$")]
    [Then(@"^I add Contractors Equipment$")]
    public async Task AddContractorsEquipmentAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickIMNavigationLinksPolicyCovgAsync();
        await page.WaitForPolicyCovgMainPolicyCovgAsync("Exists");
        await page.EnterCoverageFormToBeAddedAsync(data.Resolve("{{data:coverage_form_to_be_added_395}}"));
        await page.ClickAddCoverageFormAsync();
        await page.WaitForPolicyCovgContractorsEquipmentCoverageFormDisplayAsync("Exists");
        await page.EnterPolicyCovgContractorsEquipmentDescriptionAsync(data.Resolve("{{data:description_399}}"));
        await page.EnterPolicyCovgContractorsEquipmentCoinsuranceAsync(data.Resolve("{{data:coinsurance_400}}"));
        await page.EnterPolicyCovgContractorsEquipmentDeductibleAsync(data.Resolve("{{data:deductible_401}}"));
        await page.EnterBoomDeductibleAsync(data.Resolve("{{data:boom_deductible_402}}"));
        await page.EnterTypeOfContractorAsync(data.Resolve("{{data:type_of_contractor_403}}"));
        await page.EnterScheduledCoverageAsync(data.Resolve("{{data:scheduled_coverage_404}}"));
        await page.EnterRentedEquipmentExpenseAsync(data.Resolve("{{data:rented_equipment_expense_405}}"));
        await page.EnterToolsAndClothingBelongingToYourEmployeesAsync(data.Resolve("{{data:tools_and_clothing_belonging_to_your_employees_406}}"));
        await page.EnterMiscItemsBlanketCoverageAsync(data.Resolve("{{data:misc_items_blanket_coverage_407}}"));
        await page.EnterRentalReimbursementAsync(data.Resolve("{{data:rental_reimbursement_408}}"));
        await page.EnterHiredEquipmentAsync(data.Resolve("{{data:hired_equipment_409}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I add Motor Truck Cargo$")]
    [When(@"^I add Motor Truck Cargo$")]
    [Then(@"^I add Motor Truck Cargo$")]
    public async Task AddMotorTruckCargoAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickIMNavigationLinksPolicyCovgAsync();
        await page.WaitForPolicyCovgMainPolicyCovgAsync("Exists");
        await page.EnterCoverageFormToBeAddedAsync(data.Resolve("{{data:coverage_form_to_be_added_413}}"));
        await page.ClickAddCoverageFormAsync();
        await page.WaitForPolicyCovgMotorTruckCargoCoverageFormDisplayAsync("Exists");
        await page.EnterPolicyCovgMotorTruckCargoDescriptionAsync(data.Resolve("{{data:description_417}}"));
        await page.EnterCoverageTypeAsync(data.Resolve("{{data:coverage_type_418}}"));
        await page.EnterCoveredPropertyConsistingPrincipallyOfAsync(data.Resolve("{{data:covered_property_consisting_principally_of_419}}"));
        await page.EnterPolicyCovgMotorTruckCargoDeductibleAsync(data.Resolve("{{data:deductible_420}}"));
        await page.EnterPerVehicleLimitAsync(data.Resolve("{{data:per_vehicle_limit_421}}"));
        await page.EnterGroupClassAsync(data.Resolve("{{data:group_class_422}}"));
        await page.EnterNumberOfVehiclesAsync(data.Resolve("{{data:number_of_vehicles_423}}"));
        await page.EnterUnnamedTerminalsLimitAsync(data.Resolve("{{data:unnamed_terminals_limit_424}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I add Signs$")]
    [When(@"^I add Signs$")]
    [Then(@"^I add Signs$")]
    public async Task AddSignsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickIMNavigationLinksPolicyCovgAsync();
        await page.WaitForPolicyCovgMainPolicyCovgAsync("Exists");
        await page.EnterCoverageFormToBeAddedAsync(data.Resolve("{{data:coverage_form_to_be_added_428}}"));
        await page.ClickAddCoverageFormAsync();
        await page.WaitForPolicyCovgSignsCoverageFormDisplayAsync("Exists");
        await page.EnterPolicyCovgSignsDescriptionAsync(data.Resolve("{{data:description_432}}"));
        await page.VerifyPolicyCovgSignsCoverageFormAsync("Exists", "");
        await page.EnterN5DeductibleAsync(data.Resolve("{{data:5_deductible_434}}"));
        await page.ClickOKAsync();
        await page.PauseAsync(1000);

    }

    [Given(@"^I add Accounts Receivable$")]
    [When(@"^I add Accounts Receivable$")]
    [Then(@"^I add Accounts Receivable$")]
    public async Task AddAccountsReceivableAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickRiskAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.EnterRiskMainCoverageFormAsync(data.Resolve("{{data:coverage_form_439}}"));
        await page.ClickAddAsync();
        await page.WaitForAccountsReceivableHeadingAsync("Exists");
        await page.EnterRiskAccountsReceivableSearchValueAsync(data.Resolve("{{data:search_value_443}}"));
        await page.EnterRiskAccountsReceivableSearchResultAsync(data.Resolve("{{data:search_result_444}}"));
        await page.EnterRiskAccountsReceivableConstructionAsync(data.Resolve("{{data:construction_445}}"));
        await page.EnterPremisesTypeAsync(data.Resolve("{{data:premises_type_446}}"));
        await page.EnterDuplicatedRecordsAsync(data.Resolve("{{data:duplicated_records_447}}"));
        await page.EnterClassificationOfRiskAsync(data.Resolve("{{data:classification_of_risk_448}}"));
        await page.ClickRiskAccountsReceivableOKAsync();

    }

    [Given(@"^I complete if search result Alert exists$")]
    [When(@"^I complete if search result Alert exists$")]
    [Then(@"^I complete if search result Alert exists$")]
    public async Task CompleteIfSearchResultAlertExistsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyShowMeAsync("Exists", "");
        await page.ClickShowMeAsync();

    }

    [Given(@"^I complete ensure Class has been entered for Accounts Receivable$")]
    [When(@"^I complete ensure Class has been entered for Accounts Receivable$")]
    [Then(@"^I complete ensure Class has been entered for Accounts Receivable$")]
    public async Task CompleteEnsureClassHasBeenEnteredForAccountsReceivableAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyRiskAccountsReceivableSearchResultAsync(data.Resolve("{{data:expected_search_result_value_452}}"), "Value");
        await page.VerifyRiskAccountsReceivableSearchResultAsync(data.Resolve("{{data:expected_search_result_value_453}}"), "Value");
        await page.WaitForAccountsReceivableHeadingAsync("Exists");
        await page.EnterRiskAccountsReceivableSearchValueAsync(data.Resolve("{{data:search_value_455}}"));
        await page.EnterRiskAccountsReceivableSearchResultAsync(data.Resolve("{{data:search_result_456}}"));
        await page.ClickRiskAccountsReceivableOKAsync();

    }

    [Given(@"^I add Bailees Customers$")]
    [When(@"^I add Bailees Customers$")]
    [Then(@"^I add Bailees Customers$")]
    public async Task AddBaileesCustomersAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickRiskAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.EnterRiskMainCoverageFormAsync(data.Resolve("{{data:coverage_form_460}}"));
        await page.ClickAddAsync();
        await page.WaitForBaileesCustomersHeadingAsync("Exists");
        await page.EnterRiskBaileesCustomersDeductibleAsync(data.Resolve("{{data:deductible_463}}"));
        await page.EnterRiskBaileesCustomersSearchValueAsync(data.Resolve("{{data:search_value_465}}"));
        await page.EnterRiskBaileesCustomersSearchResultAsync(data.Resolve("{{data:search_result_466}}"));
        await page.EnterRiskBaileesCustomersConstructionAsync(data.Resolve("{{data:construction_467}}"));
        await page.EnterAnnualGrossReceiptsAsync(data.Resolve("{{data:annual_gross_receipts_468}}"));
        await page.EnterAverageNumberOfDaysServiceAsync(data.Resolve("{{data:average_number_of_days_service_469}}"));
        await page.EnterAverageNumberOfWorkingDaysAsync(data.Resolve("{{data:average_number_of_working_days_470}}"));
        await page.EnterAverageServiceChargeAsync(data.Resolve("{{data:average_service_charge_471}}"));
        await page.EnterAverageValuePerOrderAsync(data.Resolve("{{data:average_value_per_order_472}}"));
        await page.EnterRiskBaileesCustomersLimitAsync(data.Resolve("{{data:limit_473}}"));
        await page.EnterEarthquakeAsync(data.Resolve("{{data:earthquake_474}}"));
        await page.EnterStorageLimitAsync(data.Resolve("{{data:storage_limit_475}}"));
        await page.ClickRiskBaileesCustomersOKAsync();

    }

    [Given(@"^I complete if search result Alert exists for show me$")]
    [When(@"^I complete if search result Alert exists for show me$")]
    [Then(@"^I complete if search result Alert exists for show me$")]
    public async Task CompleteIfSearchResultAlertExistsForShowMeAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyShowMeAsync("Exists", "");
        await page.ClickShowMeAsync();

    }

    [Given(@"^I complete ensure Class has been entered for Bailees Customers$")]
    [When(@"^I complete ensure Class has been entered for Bailees Customers$")]
    [Then(@"^I complete ensure Class has been entered for Bailees Customers$")]
    public async Task CompleteEnsureClassHasBeenEnteredForBaileesCustomersAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyRiskBaileesCustomersSearchResultAsync(data.Resolve("{{data:expected_search_result_value_479}}"), "Value");
        await page.VerifyRiskBaileesCustomersSearchResultAsync(data.Resolve("{{data:expected_search_result_value_480}}"), "Value");
        await page.EnterRiskBaileesCustomersSearchValueAsync(data.Resolve("{{data:search_value_481}}"));
        await page.EnterRiskBaileesCustomersSearchResultAsync(data.Resolve("{{data:search_result_482}}"));
        await page.ClickRiskBaileesCustomersOKAsync();

    }

    [Given(@"^I add Computer Systems for risk$")]
    [When(@"^I add Computer Systems for risk$")]
    [Then(@"^I add Computer Systems for risk$")]
    public async Task AddComputerSystemsForRiskAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickRiskAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.EnterRiskMainCoverageFormAsync(data.Resolve("{{data:coverage_form_486}}"));
        await page.ClickAddAsync();
        await page.EnterComputerEquipmentAsync(data.Resolve("{{data:computer_equipment_488}}"));
        await page.EnterDataAndMediaAsync(data.Resolve("{{data:data_and_media_489}}"));
        await page.EnterRiskComputerSystemsSearchValueAsync(data.Resolve("{{data:search_value_491}}"));
        await page.EnterRiskComputerSystemsSearchResultAsync(data.Resolve("{{data:search_result_492}}"));
        await page.EnterConstructionCodeAsync(data.Resolve("{{data:construction_code_493}}"));
        await page.ClickRiskComputerSystemsOKAsync();

    }

    [Given(@"^I complete if search result Alert exists for duck creek policy$")]
    [When(@"^I complete if search result Alert exists for duck creek policy$")]
    [Then(@"^I complete if search result Alert exists for duck creek policy$")]
    public async Task CompleteIfSearchResultAlertExistsForDuckCreekPolicyAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyShowMeAsync("Exists", "");
        await page.ClickShowMeAsync();

    }

    [Given(@"^I complete ensure Class has been entered for Computer Systems$")]
    [When(@"^I complete ensure Class has been entered for Computer Systems$")]
    [Then(@"^I complete ensure Class has been entered for Computer Systems$")]
    public async Task CompleteEnsureClassHasBeenEnteredForComputerSystemsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyRiskComputerSystemsSearchResultAsync(data.Resolve("{{data:expected_search_result_value_497}}"), "Value");
        await page.VerifyRiskComputerSystemsSearchResultAsync(data.Resolve("{{data:expected_search_result_value_498}}"), "Value");
        await page.EnterRiskComputerSystemsSearchValueAsync(data.Resolve("{{data:search_value_499}}"));
        await page.EnterRiskComputerSystemsSearchResultAsync(data.Resolve("{{data:search_result_500}}"));
        await page.ClickRiskComputerSystemsOKAsync();

    }

    [Given(@"^I add Signs for risk$")]
    [When(@"^I add Signs for risk$")]
    [Then(@"^I add Signs for risk$")]
    public async Task AddSignsForRiskAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickRiskAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.EnterRiskMainCoverageFormAsync(data.Resolve("{{data:coverage_form_504}}"));
        await page.ClickAddAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.EnterLimitOfInsuranceAsync(data.Resolve("{{data:limit_of_insurance_507}}"));
        await page.EnterSignLocationAsync(data.Resolve("{{data:sign_location_508}}"));
        await page.EnterRiskSignsTypeAsync(data.Resolve("{{data:type_509}}"));
        await page.EnterLetteringAsync(data.Resolve("{{data:lettering_510}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I add CM 66 01 Exclude Named Customer$")]
    [When(@"^I add CM 66 01 Exclude Named Customer$")]
    [Then(@"^I add CM 66 01 Exclude Named Customer$")]
    public async Task AddCM6601ExcludeNamedCustomerAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Exists");
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.EnterEndorsementMainTypeAsync(data.Resolve("{{data:type_515}}"));
        await page.EnterNamesAsync(data.Resolve("{{data:names_517}}"));
        await page.EnterAddressAsync(data.Resolve("{{data:address_519}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I add IF 00 02 Waterborne Equipment$")]
    [When(@"^I add IF 00 02 Waterborne Equipment$")]
    [Then(@"^I add IF 00 02 Waterborne Equipment$")]
    public async Task AddIF0002WaterborneEquipmentAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Exists");
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.EnterEndorsementMainTypeAsync(data.Resolve("{{data:type_524}}"));
        await page.EnterEndorsementIF0002WaterborneEquipmentLimitAsync(data.Resolve("{{data:limit_525}}"));
        await page.EnterEndorsementIF0002WaterborneEquipmentDeductibleAsync(data.Resolve("{{data:deductible_526}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I complete Accounts Receivable Questions$")]
    [When(@"^I complete Accounts Receivable Questions$")]
    [Then(@"^I complete Accounts Receivable Questions$")]
    public async Task CompleteAccountsReceivableQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickSpecificUnderwritingQuestionsAsync();
        await page.ClickAccountsReceivableUWQuestionsAsync();
        await page.WaitForAccountsReceivableHeadingAsync("Exists");
        await page.ClickUWQuestionsUmbrellaUpdateAnswersAsync();
        await page.EnterWhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStoredAsync(data.Resolve("{{data:what_is_the_construction_of_the_premises_where_the_receivables_are_stored_532}}"));
        await page.EnterWhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheftAsync(data.Resolve("{{data:what_safeguards_are_in_place_for_receivables_to_protect_against_damage_or_theft_534}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I complete Bailees Customers Questions$")]
    [When(@"^I complete Bailees Customers Questions$")]
    [Then(@"^I complete Bailees Customers Questions$")]
    public async Task CompleteBaileesCustomersQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickSpecificUnderwritingQuestionsAsync();
        await page.ClickBaileesCustomerUWQuestionsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.EnterDryCleaningAsync(data.Resolve("{{data:dry_cleaning_539}}"));
        await page.EnterLaundryAsync(data.Resolve("{{data:laundry_540}}"));
        await page.EnterN2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremisesAsync(data.Resolve("{{data:2_indicate_the_age_type_of_construction_and_protection_class_of_the_premises_541}}"));
        await page.EnterN3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepairAsync(data.Resolve("{{data:3_what_is_the_percentage_of_annual_gross_receipts_derived_from_service_or_repair_542}}"));
        await page.EnterN4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdatedAsync(data.Resolve("{{data:4_what_method_do_you_use_for_keeping_records_of_property_in_your_care_and_how_often_are_the_records_updated_543}}"));
        await page.EnterN5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintainedAsync(data.Resolve("{{data:5_are_recognized_approved_central_station_burglar_alarms_installed_and_maintained_544}}"));
        await page.EnterN6AreAllStorageAreasLockedAtAllTimesWhenUnoccupiedAsync(data.Resolve("{{data:6_are_all_storage_areas_locked_at_all_times_when_unoccupied_545}}"));
        await page.EnterN7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremisesAsync(data.Resolve("{{data:7_are_there_any_hazardous_or_flammable_materials_used_or_stored_on_the_premises_546}}"));
        await page.EnterAWhatIsThePublicProtectionClassRatingAsync(data.Resolve("{{data:a_what_is_the_public_protection_class_rating_547}}"));
        await page.EnterBAreThereAnyPrivateProtectionImprovementsAsync(data.Resolve("{{data:b_are_there_any_private_protection_improvements_548}}"));
        await page.EnterCWhatIsTheDistanceInFeetToTheNearestHydrantAsync(data.Resolve("{{data:c_what_is_the_distance_in_feet_to_the_nearest_hydrant_549}}"));
        await page.EnterDWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartmentAsync(data.Resolve("{{data:d_what_is_the_distance_in_miles_to_the_nearest_responding_fire_department_550}}"));
        await page.EnterEAreNoSmokingRulesPostedAndEnforcedAsync(data.Resolve("{{data:e_are_no_smoking_rules_posted_and_enforced_551}}"));
        await page.EnterN9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystemAsync(data.Resolve("{{data:9_are_the_premises_or_any_portion_of_the_premises_equipped_with_a_sprinkler_system_552}}"));
        await page.EnterN10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarmsAsync(data.Resolve("{{data:10_are_the_premises_equipped_with_a_recognized_approved_central_station_fire_alarm_fire_extinguishers_or_smoke_alarms_553}}"));
        await page.EnterN11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransitAsync(data.Resolve("{{data:11_what_is_the_procedure_for_transporting_property_include_the_transit_methods_used_and_the_protection_class_provided_while_in_transit_554}}"));
        await page.EnterN12AreDriversMVRsReviewedOnARegularBasisAndMaintainedAsync(data.Resolve("{{data:12_are_drivers_mvrs_reviewed_on_a_regular_basis_and_maintained_555}}"));
        await page.EnterN13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicleAsync(data.Resolve("{{data:13_what_types_of_vehicles_do_you_operate_and_what_protective_devices_are_on_each_vehicle_556}}"));
        await page.EnterN14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorageAsync(data.Resolve("{{data:14_what_is_your_procedure_for_protecting_small_items_from_breakage_or_disappearance_while_in_storage_557}}"));
        await page.EnterN15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheftAsync(data.Resolve("{{data:15_what_measures_does_the_insured_take_to_protect_customer_s_property_against_theft_558}}"));
        await page.EnterN16DoesTheRiskUseReleaseFormsAsync(data.Resolve("{{data:16_does_the_risk_use_release_forms_559}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I complete Computer Systems Questions$")]
    [When(@"^I complete Computer Systems Questions$")]
    [Then(@"^I complete Computer Systems Questions$")]
    public async Task CompleteComputerSystemsQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickSpecificUnderwritingQuestionsAsync();
        await page.ClickComputerSystemsUWQuestionsAsync();
        await page.ClickUWQuestionsUmbrellaUpdateAnswersAsync();
        await page.EnterWhatIsTheProcedureForTransportingTheComputerEquipmentAsync(data.Resolve("{{data:what_is_the_procedure_for_transporting_the_computer_equipment_564}}"));
        await page.EnterIndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocatedAsync(data.Resolve("{{data:indicate_the_building_s_age_type_of_construction_and_protection_class_and_other_tenants_in_the_building_s_where_the_computer_equipment_is_located_565}}"));
        await page.EnterWhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecuredAsync(data.Resolve("{{data:what_are_the_procedures_and_methods_for_keeping_the_edp_areas_secured_566}}"));
        await page.EnterWhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorageAsync(data.Resolve("{{data:what_are_the_procedures_and_schedule_for_backing_up_the_media_and_data_and_their_storage_567}}"));
        await page.EnterProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMediaAsync(data.Resolve("{{data:provide_information_regarding_antivirus_methods_and_copyright_protection_of_data_and_media_568}}"));
        await page.EnterWhatIsThePublicProtectionClassRatingAsync(data.Resolve("{{data:what_is_the_public_protection_class_rating_569}}"));
        await page.EnterWhatIsTheDistanceInFeetToTheNearestFireHydrantAsync(data.Resolve("{{data:what_is_the_distance_in_feet_to_the_nearest_fire_hydrant_570}}"));
        await page.EnterWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartmentAsync(data.Resolve("{{data:what_is_the_distance_in_miles_to_the_nearest_responding_fire_department_571}}"));
        await page.EnterUninterruptiblePowerSourceAsync(data.Resolve("{{data:uninterruptible_power_source_572}}"));
        await page.EnterLineConditionerAsync(data.Resolve("{{data:line_conditioner_573}}"));
        await page.EnterPowerSuppressorVoltageRegulatorAsync(data.Resolve("{{data:power_suppressor_voltage_regulator_574}}"));
        await page.EnterDedicatedLineAsync(data.Resolve("{{data:dedicated_line_575}}"));
        await page.EnterHowOftenIsDataBackedUpAsync(data.Resolve("{{data:how_often_is_data_backed_up_576}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I complete Contractors Equipment Questions$")]
    [When(@"^I complete Contractors Equipment Questions$")]
    [Then(@"^I complete Contractors Equipment Questions$")]
    public async Task CompleteContractorsEquipmentQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickSpecificUnderwritingQuestionsAsync();
        await page.ClickContractorsEquipmentUWQuestionsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickSpecificUnderwritingQuestionsContractorsEquipmentUpdateAnswersAsync();
        await page.EnterEstimatedHighestValueAsync(data.Resolve("{{data:estimated_highest_value_582}}"));
        await page.EnterIfYesDescribeAsync(data.Resolve("{{data:if_yes_describe_583}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I complete Motor Truck Cargo Questions \(Owner\)$")]
    [When(@"^I complete Motor Truck Cargo Questions \(Owner\)$")]
    [Then(@"^I complete Motor Truck Cargo Questions \(Owner\)$")]
    public async Task CompleteMotorTruckCargoQuestionsOwnerAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickSpecificUnderwritingQuestionsAsync();
        await page.ClickMotorTruckCargoUWQuestionsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.EnterWhichFormAreYouCompletingAsync(data.Resolve("{{data:which_form_are_you_completing_588}}"));
        await page.EnterN1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipmentAsync(data.Resolve("{{data:1_what_are_the_distances_the_shipments_will_travel_and_the_time_required_to_complete_the_shipment_590}}"));
        await page.EnterN2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommoditiesAsync(data.Resolve("{{data:2_what_are_the_types_and_ages_of_the_vehicles_trailers_used_to_transport_your_commodities_591}}"));
        await page.EnterN3DoesTheApplicantHaulForOthersAsync(data.Resolve("{{data:3_does_the_applicant_haul_for_others_592}}"));
        await page.EnterN4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailerAsync(data.Resolve("{{data:4_what_protective_devices_are_installed_on_each_vehicle_or_trailer_593}}"));
        await page.EnterN5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttachedAsync(data.Resolve("{{data:5_do_any_vehicles_have_special_equipment_mounted_or_attached_594}}"));
        await page.EnterN6DoesTheApplicantPullDoubleOrTripleTrailersAsync(data.Resolve("{{data:6_does_the_applicant_pull_double_or_triple_trailers_595}}"));
        await page.EnterN7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattendedAsync(data.Resolve("{{data:7_does_the_applicant_leave_the_truck_windows_doors_and_compartments_closed_and_locked_when_unattended_596}}"));
        await page.EnterN8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperateAsync(data.Resolve("{{data:8_do_you_provide_scheduled_maintenance_for_the_vehicles_and_trailers_you_operate_597}}"));
        await page.EnterN9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommoditiesAsync(data.Resolve("{{data:9_are_the_employees_that_pack_load_and_unload_trained_in_proper_handling_of_the_commodities_598}}"));
        await page.EnterN10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheftAsync(data.Resolve("{{data:10_how_are_the_goods_being_transported_protected_from_damage_and_theft_599}}"));
        await page.EnterN11AreDriversMVRsAndTripLogsMaintainedAsync(data.Resolve("{{data:11_are_drivers_mvrs_and_trip_logs_maintained_600}}"));
        await page.EnterN12HowOftenAreTheseLogsReviewedOrUpdatedAsync(data.Resolve("{{data:12_how_often_are_these_logs_reviewed_or_updated_601}}"));
        await page.EnterN13LiveAnimalInTransitCoverageAsync(data.Resolve("{{data:13_live_animal_in_transit_coverage_602}}"));
        await page.EnterN14LegalLiabilityCoverageAsync(data.Resolve("{{data:14_legal_liability_coverage_603}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I complete Signs Questions$")]
    [When(@"^I complete Signs Questions$")]
    [Then(@"^I complete Signs Questions$")]
    public async Task CompleteSignsQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickSpecificUnderwritingQuestionsAsync();
        await page.ClickSignsUWQuestionsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.EnterAreAnySignsOffPremisesOrNotAttachedToBuildingAsync(data.Resolve("{{data:are_any_signs_off_premises_or_not_attached_to_building_608}}"));
        await page.EnterDoesTheApplicantWishToCoverAnySignsInsideTheirPremisesAsync(data.Resolve("{{data:does_the_applicant_wish_to_cover_any_signs_inside_their_premises_609}}"));
        await page.EnterWhatIsTheConstructionOfEachSignAsync(data.Resolve("{{data:what_is_the_construction_of_each_sign_610}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I return to CPP policy navigation$")]
    [When(@"^I return to CPP policy navigation$")]
    [Then(@"^I return to CPP policy navigation$")]
    public async Task ReturnToCPPPolicyNavigationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickReturnToCPPAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.PauseAsync(1000);

    }

    [Given(@"^I select GL Available Classiifcation$")]
    [When(@"^I select GL Available Classiifcation$")]
    [Then(@"^I select GL Available Classiifcation$")]
    public async Task SelectGLAvailableClassiifcationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickPricingAsync();
        await page.EnterAvailableClassificationsAsync(data.Resolve("{{data:available_classifications_617}}"));

    }

    [Given(@"^I navigate to Underwriting Info Screens$")]
    [When(@"^I navigate to Underwriting Info Screens$")]
    [Then(@"^I navigate to Underwriting Info Screens$")]
    public async Task NavigateToUnderwritingInfoScreensAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickAddClientAsync();
        await page.ClickUnderwritingInfoAsync();

    }

    [Given(@"^I answer General UW Questions$")]
    [When(@"^I answer General UW Questions$")]
    [Then(@"^I answer General UW Questions$")]
    public async Task AnswerGeneralUWQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickUnderwritingInfoNavigationGeneralUWQuestionsAsync();
        await page.WaitForUnderwritingInfoGeneralUWQuestionsGeneralUWQuestionsAsync("Exists");
        await page.ClickUpdateAnswersAsync();

    }

    [Given(@"^I answer General Liability History Questions$")]
    [When(@"^I answer General Liability History Questions$")]
    [Then(@"^I answer General Liability History Questions$")]
    public async Task AnswerGeneralLiabilityHistoryQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickUnderwritingInfoNavigationCommercialGeneralLiabilityHistoryAsync();
        await page.WaitForUnderwritingInfoCommercialPropertyHistoryCommercialGeneralLiabilityHistoryAsync("Exists");
        await page.EnterUnderwritingInfoCommercialGeneralLiabilityHistoryIsThereAPriorCarrierAsync(data.Resolve("{{data:is_there_a_prior_carrier_625}}"));

    }

    [Given(@"^I answer Commercial Property History Questions$")]
    [When(@"^I answer Commercial Property History Questions$")]
    [Then(@"^I answer Commercial Property History Questions$")]
    public async Task AnswerCommercialPropertyHistoryQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickCommercialPropertyHistoryAsync();
        await page.WaitForUnderwritingInfoCommercialPropertyHistoryCommercialGeneralLiabilityHistoryAsync("Exists");
        await page.EnterUnderwritingInfoCommercialPropertyHistoryIsThereAPriorCarrierAsync(data.Resolve("{{data:is_there_a_prior_carrier_628}}"));

    }

    [Given(@"^I answer Other Insurance History Questions$")]
    [When(@"^I answer Other Insurance History Questions$")]
    [Then(@"^I answer Other Insurance History Questions$")]
    public async Task AnswerOtherInsuranceHistoryQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickUnderwritingInfoNavigationOtherInsuranceHistoryAsync();
        await page.WaitForUnderwritingInfoOtherInsuranceHistoryOtherInsuranceHistoryAsync("Exists");
        await page.EnterUnderwritingInfoOtherInsuranceHistoryIsThereAPriorCarrierAsync(data.Resolve("{{data:is_there_a_prior_carrier_631}}"));

    }

    [Given(@"^I navigate back to CPP Main$")]
    [When(@"^I navigate back to CPP Main$")]
    [Then(@"^I navigate back to CPP Main$")]
    public async Task NavigateBackToCPPMainAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickReturnToQuoteAsync();

    }

    [Given(@"^I complete required billing information for billing$")]
    [When(@"^I complete required billing information for billing$")]
    [Then(@"^I complete required billing information for billing$")]
    public async Task CompleteRequiredBillingInformationForBillingAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickNavigationBillingAsync();
        await page.WaitForBillingAsync("Exists");
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_635}}"));
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_638}}"));
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_642}}"));
        await page.PauseAsync(1000);

    }

    [Given(@"^I add notepad comment$")]
    [When(@"^I add notepad comment$")]
    [Then(@"^I add notepad comment$")]
    public async Task AddNotepadCommentAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickNotepadAsync();
        await page.WaitForNotepadHeadingAsync("Exists");
        await page.ClickAddNotesRemarksAsync();
        await page.EnterTextBoxAsync(data.Resolve("Test {B[Product (LOB)]}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I complete required submission information$")]
    [When(@"^I complete required submission information$")]
    [Then(@"^I complete required submission information$")]
    public async Task CompleteRequiredSubmissionInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForSubmissionAsync("Visible");
        await page.ClickSubmissionAsync();
        await page.WaitForSubmissionHeadingAsync("Exists");
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_653}}"));
        await page.VerifyOrderAuditAsync("Exists", "");
        await page.EnterOrderAuditAsync(data.Resolve("{{data:order_audit_655}}"));
        await page.VerifySubmissionHeadingAsync("Absent", "");
        await page.ClickSubmissionAsync();
        await page.PauseAsync(1000);
        await page.WaitForSubmissionHeadingAsync("Exists");
        await page.PauseAsync(1000);

    }

    [Given(@"^I run Stoplight$")]
    [When(@"^I run Stoplight$")]
    [Then(@"^I run Stoplight$")]
    public async Task RunStoplightAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyIsThisCoverageBoundAsync("Exists", "");
        await page.VerifyIsThisCoverageBoundAsync(data.Resolve("{{data:expected_is_this_coverage_bound_value_663}}"), "Value");
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_664}}"));
        await page.ClickCompleteApplicationAsync();
        await page.VerifyStoplightWaitingWindowCloseAsync("Absent", "");
        await page.PauseAsync(1000);
        await page.VerifyStoplightWaitingWindowErrorAsync("Exists", "");
        await page.ClickStoplightWaitingWindowFirstCloseButtonOnErrorAsync();
        await page.PauseAsync(1000);
        await page.ClickCompleteApplicationAsync();
        await page.PauseAsync(1000);
        await page.ClickStoplightWaitingWindowCloseAsync();
        await page.WaitForStoplightWaitingWindowAsync("Absent");
        await page.PauseAsync(1000);
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.VerifyAllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabsAsync("Exists", "");
        await page.ClickCompleteApplicationAsync();
        await page.VerifyStoplightWaitingWindowCloseAsync("Absent", "");
        await page.PauseAsync(1000);
        await page.VerifyStoplightWaitingWindowErrorAsync("Exists", "");
        await page.ClickStoplightWaitingWindowFirstCloseButtonOnErrorAsync();
        await page.PauseAsync(1000);
        await page.ClickCompleteApplicationAsync();
        await page.PauseAsync(1000);
        await page.ClickStoplightWaitingWindowCloseAsync();
        await page.WaitForStoplightWaitingWindowAsync("Absent");
        await page.PauseAsync(1000);
        await page.VerifyAllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabsAsync("Absent", "");

    }

    [Given(@"^I verify values in premium fields$")]
    [When(@"^I verify values in premium fields$")]
    [Then(@"^I verify values in premium fields$")]
    public async Task VerifyValuesInPremiumFieldsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyFullTermPremiumAsync(data.Resolve("{{data:expected_full_term_premium_value_696}}"), "value");
        await page.VerifyPremiumWrittenAsync(data.Resolve("{{data:expected_premium_written_value_697}}"), "value");
        await page.VerifyPriorPremiumAsync(data.Resolve("{{data:expected_prior_premium_value_698}}"), "value");
        await page.VerifyPremiumChangeAsync(data.Resolve("{{data:expected_premium_change_value_699}}"), "value");
        await page.EnterTitleAsync(data.Resolve("{{data:title_701}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_702}}"));
        data.Set("SessionId", await page.CaptureResultAsync("value"));

    }

    [Given(@"^I complete forms verification$")]
    [When(@"^I complete forms verification$")]
    [Then(@"^I complete forms verification$")]
    public async Task CompleteFormsVerificationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.EnterSessionIDAsync(data.Resolve("{B[SessionId]}"));
        await page.VerifyStatusCodeAsync(data.Resolve("{{data:expected_statuscode_value_706}}"), "value");
        await page.PauseAsync(1000);
        await page.PauseAsync(1000);

    }

}
