using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "WC Expanded")]
public sealed class WCExpandedSteps
{
    private readonly ScenarioContext _scenario;
    public WCExpandedSteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I start a new quote$")]
    [When(@"^I start a new quote$")]
    [Then(@"^I start a new quote$")]
    public async Task StartANewQuoteAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await page.ClickNewQuoteAsync();
        await page.EnterEffectiveDateAsync(data.Resolve("{{data:effective_date_43}}"));
        await page.EnterProductAsync(data.Resolve("{{data:product_45}}"));
        await page.EnterProducerAsync(data.Resolve("{{data:producer}}"));
        await page.WaitForStartAsync("Visible");
        await page.ClickStartAsync();
    }


    [Given(@"^I enter business client information$")]
    [When(@"^I enter business client information$")]
    [Then(@"^I enter business client information$")]
    public async Task EnterBusinessClientInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("PrimaryPhone_0041", "[0-9]{10}");
        data.GenerateRandom("FEIN_0044", "[0-9]{9}");
        data.GenerateRandom("AuditTelephone_0045", "[0-9]{10}");
        data.GenerateRandom("InspectionTelephone_0045", "[0-9]{10}");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
       

        await page.WaitForQuickQuoteAsync("Exists");
        await page.SetQuickQuoteAsync(data.Resolve("{{data:quick_quote_2}}"));
        await page.WaitForUnderwritingInfoAsync("Exists");
        if (data.Condition("'Insured Type' != NULL"))
        {
            await page.EnterInsuredTypeAsync(data.Resolve("{{data:insured_type_4}}"));
        }
        await page.WaitForBusinessNameAsync("Visible");
        if (data.Condition("'Business Name' != NULL"))
        {
            await page.EnterBusinessNameAsync(data.Resolve("{{data:business_name_7}}"));
        }
        if (data.Condition("'Legal Nature' != NULL"))
        {
            await page.EnterEntityTypeAsync(data.Resolve("{{data:entity_type_8}}"));
        }
        if (data.Condition("'Address 1' != NULL"))
        {
            await page.EnterPrimaryPhoneAsync(data.Resolve("{{runtime:PrimaryPhone_0041}}"));
            await page.EnterAddressAsync(data.Resolve("{{data:address1_10}}"));
        }
        if (data.Condition("ZipCode != NULL"))
        {
            await page.EnterNamedInsuredZipCodeAsync(data.Resolve("{{data:zipcode_11}}"));
        }
        await page.EnterFEINAsync(data.Resolve("{{runtime:FEIN_0044}}"));
        await page.VerifyYearsInBusinessAsync("Exists", "");

        await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_13}}"));
        await page.EnterNameOfAuditContactAsync(data.Resolve("{{data:name_of_audit_contact_15}}"));
        await page.EnterAuditTelephoneAsync(data.Resolve("{{runtime:AuditTelephone_0045}}"));
        await page.EnterNameOfInspectionContactAsync(data.Resolve("{{data:name_of_inspection_contact_17}}"));
        await page.EnterInspectionTelephoneAsync(data.Resolve("{{runtime:InspectionTelephone_0045}}"));
        await page.EnterInsuredEMailAddressAsync(data.Resolve("{{data:insured_e_mail_address_19}}"));
        await page.EnterWebsiteAddressAsync(data.Resolve("{{data:website_address_20}}"));

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
        //await page.VerifyIndividualTypeAsync("Absent", "");

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
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_32}}"));
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_35}}"));
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_39}}"));
        await page.PauseAsync(1000);

    }

    [Given(@"^I complete the Associated Client Info$")]
    [When(@"^I complete the Associated Client Info$")]
    [Then(@"^I complete the Associated Client Info$")]
    public async Task CompleteTheAssociatedClientInfoAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("MiddleName_0056", "^[a-z]{1}$");
        data.GenerateRandom("LastName_0056", "^[a-z]{7}$");
        data.GenerateRandom("FirstName_0056", "^[a-z]{4}$");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.EnterIndividualTypeAsync(data.Resolve("{{data:individualtype_42}}"));
        await page.WaitForPleaseVerifySSNAsync("Exists");
        await page.EnterMiddleNameAsync(data.Resolve("{{runtime:MiddleName_0056}}"));
        await page.EnterLastNameAsync(data.Resolve("{{runtime:LastName_0056}}"));
        await page.EnterAddAssociatedClientDateOfBirthAsync(data.Resolve("{{data:dateofbirth_47}}"));
        await page.EnterAddressAsync(data.Resolve("{{data:address_2}}"));
        await page.EnterCityAsync(data.Resolve("{{data:city_49}}"));
        await page.EnterFirstNameAsync(data.Resolve("{{runtime:FirstName_0056}}"));
        await page.EnterStateAsync(data.Resolve("{{data:state_51}}"));
        await page.EnterNamedInsuredZipCodeAsync(data.Resolve("{{data:zipcode_51}}"));
        await page.EnterGenderAsync(data.Resolve("{{data:gender_52}}"));
        await page.WaitForClientSearchAsync("Exists");
        await page.ClickClientSearchAsync();
        await page.PauseAsync(1000);
        await page.VerifySearchResultsDuckCreekPolicyFirstCheckboxAsync("Absent", "");
        await page.ClickOKAsync();
        await page.ClickOrderSSNAsync();
        await page.PressAddAssociatedClientEnterSSNAsync("Enter");
        await page.EnterAddAssociatedClientEnterSSNAsync(data.Resolve("{{data:enter_ssn_60}}"));
        //await page.VerifyVerifyAsync("Absent", "");
        //await page.ClickCompleteAsync();
        //await page.ClickAddAssociatedClientDetailAsync();
        //await page.WaitForAddAssociatedClientEnterSSNAsync("Exists");
        await page.ClickVerifyAsync();
        await page.WaitForPleaseVerifySSNAsync("Absent");
        await page.ClickCompleteAsync();
        //await page.WaitForAddAssociatedClientEnterSSNAsync("Exists");
        //await page.ClickVerifyAsync();
        //await page.WaitForPleaseVerifySSNAsync("Absent");
        //await page.ClickCompleteAsync();
        //await page.WaitForClientSearchAsync("Exists");
        //await page.ClickClientSearchAsync();
        //await page.WaitForOKAsync("Exists");
        //await page.ClickOKAsync();
        //await page.WaitForClientSearchAsync("Absent");
        await page.WaitForClientSearchAsync("Exists");
        await page.ClickClientSearchAsync();

        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
        await page.WaitForClientSearchAsync("Absent");

    }

    [Given(@"^I navigate to Underwriting Info Screen$")]
    [When(@"^I navigate to Underwriting Info Screen$")]
    [Then(@"^I navigate to Underwriting Info Screen$")]
    public async Task NavigateToUnderwritingInfoScreenAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickUnderwritingInfoAsync();
        await page.WaitForIsThereAPriorCarrierAsync("Exists");
        await page.EnterIsThereAPriorCarrierAsync(data.Resolve("{{data:is_there_a_prior_carrier_80}}"));
        await page.WaitForCarrierAsync("Exists");
        await page.EnterCarrierAsync(data.Resolve("{{data:carrier_82}}"));
        await page.EnterGeneralLiabilityPolicyNumberAsync(data.Resolve("{{data:policy_number_83}}"));
        await page.EnterPolicyTypeAsync(data.Resolve("{{data:policy_type_84}}"));
        await page.EnterCommercialAutoEffectiveDateAsync(data.Resolve("{DATE[][-2y][MM'/'dd'/'yyyy]}"));
        await page.EnterGeneralLiabilityExpirationDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.EnterModificationFactorAsync(data.Resolve("{{data:modificationfactor_87}}"));
        await page.EnterTotalPremiumAsync(data.Resolve("{{data:total_premium_88}}"));
        await page.ClickOKAsync();
        //await page.WaitForUnderwritingInfoOtherInsuranceHistoryDetailAsync("Exists");
        await page.ClickLossExperienceAsync();
        //await page.WaitForNoKnownLossesAsync("Exists");
        //await page.SetNoKnownLossesAsync(data.Resolve("{{data:no_known_losses_93}}"));
        await page.ClickReturnToQuoteAsync();
        //await page.EnterTitleAsync(data.Resolve("{{data:title_95}}"));
        //await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_96}}"));
        //await page.VerifyResultAsync(data.Resolve("{{data:expected_result_value_97}}"), "value");

    }

    [Given(@"^I complete required policy information$")]
    [When(@"^I complete required policy information$")]
    [Then(@"^I complete required policy information$")]
    public async Task CompleteRequiredPolicyInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickPolicyInfoAsync();
        //await page.WaitForPolicyInfoHeaderAsync("Exists");
        await page.PauseAsync(1000);
        await page.EnterPolicyInfoRequiredAndOptionalFieldsEffectiveDateAsync(data.Resolve("{{data:effectivedate_101}}"));
        await page.PauseAsync(1000);
        //await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_103}}"));
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_104}}"));
        await page.PauseAsync(1000);
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_108}}"));
        await page.VerifyPriorAmericanNationalPolicyAsync("Absent", "");
        await page.VerifyWhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNationalAsync("Absent", "");
        await page.VerifyIsThisPolicyBeingFullyCancelledAsync("Absent", "");
        await page.PauseAsync(1000);
        await page.WaitForPolicyInfoHeaderAsync("Visible");
        await page.WaitForDescriptionOfSpecifiedOperationAsync("Visible");
        await page.EnterDescriptionOfSpecifiedOperationAsync(data.BuildQuoteDescription());
        data.Set("QuoteDescription", await page.CaptureDescriptionOfSpecifiedOperationAsync("value"));

        if (data.Condition("State ==\"VT\" || State ==\"NY\" || State == \"PA\""))
        {
            await page.EnterWorkplaceSafetyRiskManagementAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_113}}"));

        }

        if (data.Condition("State == \"NY\""))
        {

            await page.EnterWCEstimatedPremiumAsync(data.Resolve("{{data:estimated_premium_12}}"));

        }

    }

    [Given(@"^I complete WC Specific Fields$")]
    [When(@"^I complete WC Specific Fields$")]
    [Then(@"^I complete WC Specific Fields$")]
    public async Task CompleteWCSpecificFieldsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await page.EnterHasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverageAsync(data.Resolve("{{data:has_the_applicant_been_in_business_for_at_least_3_years_with_continuous_workers_compensation_coverage_118}}"));

    }

    [Given(@"^I complete Estimated premium$")]
    [When(@"^I complete Estimated premium$")]
    [Then(@"^I complete Estimated premium$")]
    public async Task CompleteEstimatedPremiumAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        if (data.Condition("'Estimated Premium' == NULL"))
        {
            await page.VerifyEstimatedPremiumAsync("Absent", "");
        }

    }

    [Given(@"^I complete coverage Information$")]
    [When(@"^I complete coverage Information$")]
    [Then(@"^I complete coverage Information$")]
    public async Task CompleteCoverageInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickPolicyCovgerageAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.WaitForPrimaryLocationStateAsync("Exists");
        //if (data.Condition("'Primary Rating State' != NULL"))
        //{
        //    await page.VerifyPrimaryLocationStateAsync("(?i)^Alabama$", "Regex:value");
        //}
        if (data.Condition("('Experience Rated' != NULL)&&(State!=\"OK\")"))
        {
            await page.EnterExperienceRatedAsync(data.Resolve("{{data:experience_rated_124}}"));
        }
        if (data.Condition("('Default Experience Mod Type' != NULL)&&(State!=\"OK\")&&(State!=\"NY\")"))
        {
            await page.EnterDefaultExpModTypeAsync(data.Resolve("{{data:default_exp_mod_type_126}}"));
        }

    }

    [Given(@"^I complete Address 1$")]
    [When(@"^I complete Address 1$")]
    [Then(@"^I complete Address 1$")]
    public async Task CompleteAddress1Async()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickWCNavigationLinksLocationAsync();
        await page.WaitForLocationAddressAsync("Exists");
        await page.VerifyLocationZipCodeAsync(data.Resolve("{{data:location_zip_code_regex_129}}"), data.Resolve("{{data:location_zip_code_match_type_130}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I complete rating Information$")]
    [When(@"^I complete rating Information$")]
    [Then(@"^I complete rating Information$")]
    public async Task CompleteRatingInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickStateDetailsAsync();
        await page.WaitForIntrastateRiskIDAsync("Exists");
        if (data.Condition("'Waiver of Subrogation' != NULL"))
        {
            await page.EnterWaiverOfSubrogationAsync(data.Resolve("{{data:waiver_of_subrogation_133}}"));
        }


        if (data.Condition("State == \"PA\" || State == \"OK\""))
        {
            await page.EnterLLinestateDeductibleSelectionAsync(data.Resolve("{{data:ll_in_state_deductible_selection_136}}"));
            await page.PauseAsync(2000);
            await page.EnterSmallDeductibleSelectioncreditdeductableAsync(data.Resolve("{{data:small_deductible_134}}"));
            await page.PauseAsync(2000);
            await page.EnterCompanyNameAsync(data.Resolve("{{data:company_name_135}}"));
         
 
           
        }

        if (data.Condition("State == \"MN\""))
        {
            await page.EnterLLinestateDeductibleSelectionAsync(data.Resolve("{{data:ll_in_state_deductible_selection_136}}"));
            await page.PauseAsync(2000);
            await page.EnterSmallDeductibleAsync(data.Resolve("{{data:small_deductible_134}}"));
            await page.PauseAsync(2000);
            await page.EnterCompanyNameAsync(data.Resolve("{{data:company_name_135}}"));
        }
        if (data.Condition("State == \"PA\""))
        {
            await page.ClickSafetyCommoditiesAsync();
        }



        if (data.Condition("State == \"OK\""))
        {
            await page.EnterMeritRatingSelectionAsync(data.Resolve("{{data:merit_rating_selection_138}}"));
        }

        if (data.Condition("State == \"AR\" || State == \"SD\""))
        {
            await page.EnterSmallDeductibleSelectionAsync(data.Resolve("{{data:smallDeductable_14}}"));
        }


        if (data.Condition("State == \"SD\""))
        {
            await page.EnterSmallDeductibleSelectioncreditdeductableAsync(data.Resolve("{{data:small_deductible_134}}"));
            await page.PauseAsync(2000);
            await page.EnterMeritRatingSelectionAsync(data.Resolve("{{data:merit_rating_selection_138}}"));
          
        }

        if (data.Condition("State == \"IA\""))
        {
            await page.EnterSmallDeductibleSelectioncreditAsync(data.Resolve("{{data:small_deductible_134}}"));
        }


        await page.PauseAsync(1000);
        if (data.Condition("'Experience Rating Options' != NULL"))
        {
            await page.EnterExperienceRatingOptionsAsync(data.Resolve("{{data:experience_rating_options_139}}"));
        }

        if (data.Condition("'Experience Mod Type' != NULL"))
        {
            await page.EnterExperienceModTypeAsync(data.Resolve("{{data:experience_mod_type_140}}"));
        }
        if (data.Condition("'Company Name' != NULL && State != \"MN\""))
        {
            await page.EnterCompanyNameAsync(data.Resolve("{{data:company_name_135}}"));
        }



        if (data.Condition("State != \"IA\" && State != \"SD\" && State != \"OK\" && State != \"MN\""))
        {
            if (data.Condition("'Small Deductible' != NULL"))
            {
                await page.EnterSmallDeductibleAsync(data.Resolve("{{data:small_deductible_134}}"));
            }
          
            if (data.Condition("('Merit Rating' != NULL)&&(State!=\"NY\")"))
            {
                await page.EnterMeritRatingAsync(data.Resolve("{{data:merit_rating_137}}"));
            }


            if (data.Condition("State == \"AZ\" || State == \"TN\" || State == \"MD\"|| State == \"AR\""))
            {
                await page.ClickAlcoholOrFreedrugspaceAsync();
            }
            if (data.Condition("Deductible != NULL"))
            {
                await page.EnterRatingGroupsDeductibleAsync(data.Resolve("{{data:rating_groups_deductible_142}}"));
            }
            await page.PauseAsync(1000);
            if (data.Condition("Deductible != NULL"))
            {
                await page.EnterRatingGroupsDeductibleAsync(data.Resolve("{{data:rating_groups_deductible_142}}"));
            }
          
          
            if (data.Condition("'Pending Rate Change' != NULL"))
            {
                await page.VerifyPendingRateChangeAsync(data.Resolve("{{data:expected_pending_rate_change_value_141}}"), "value");
            }
        }   
      



    }

    [Given(@"^I add Class Codes$")]
    [When(@"^I add Class Codes$")]
    [Then(@"^I add Class Codes$")]
    public async Task AddClassCodesAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickWCScheduleAsync();
        //await page.WaitForAddClassCodeAsync("Exists");
        await page.ClickAddClassCodeAsync();
        //await page.WaitForClassCodeFrameAsync("Exists");
        await page.WaitForSearchValueAsync("Exists");
        //await page.VerifyOKClassCodeAsync("Absent", "");
        //await page.WaitForSearchValueAsync("Exists");

        if (data.Condition("'Class Code 1' != NULL"))
        {
            await page.EnterSearchValueAsync(data.Resolve("{{data:class_code_frame_class_code_window_searchvalue_148}}"));
        }
        if (data.Condition("'Class Code 1' != NULL"))
        {
            await page.EnterSelectClassCodeAsync(data.Resolve("{{data:class_code_frame_class_code_window_select_class_code_150}}"));
        }
        await page.PauseAsync(1000);
        await _scenario.Get<BrowserSession>().Page.Keyboard.PressAsync("Tab");
        if (data.Condition("'Class Code 1' != NULL"))
            {
                await page.VerifySelectClassCodeAsync(data.Resolve("{{data:expected_class_code_frame_class_code_window_select_class_code_value_153}}"), "value");
            }
            await page.WaitForOKClassCodeAsync("Exists");
        await page.ClickOKClassCodeAsync();
        await page.PauseAsync(2000);
        //if (data.Condition("State != \"MD\""))
        //{
            await page.EnterTotalPayrollEstimatedAsync(data.Resolve("{{data:class_code_frame_class_code_window_total_payroll_estimated_156}}"));
        //}
        if (await page.IsWaiverOfSubrogationExposureVisibleAsync())
        {
            await page.EnterWaiverOfSubrogationExposureAsync(data.Resolve("{{data:class_code_frame_class_code_window_waiver_of_subrogation_exposure_157}}"));
        }
        await page.EnterNumberOfPartTimeEmployeesAsync(data.Resolve("{{data:class_code_frame_class_code_window_number_of_part_time_employees_158}}"));
        await page.EnterNumberOfFullTimeEmployeesAsync(data.Resolve("{{data:class_code_frame_class_code_window_number_of_full_time_employees_159}}"));
        await page.PauseAsync(2000);
        await _scenario.Get<BrowserSession>().Page.Keyboard.PressAsync("Tab");
        await page.ClickOKDetailsAsync();
        //await page.WaitForClassCodeFrameAsync("Absent");


        await page.PauseAsync(2000);
        await page.WaitForAddClassCodeAsync("Exists");
        await page.PauseAsync(2000);
        await page.ClickAddClassCodeAsync();
        //await page.WaitForClassCodeFrameAsync("Exists");
        //await page.VerifyOKClassCodeAsync("Absent", "");
        //await page.WaitForSearchValueAsync("Exists");
        await page.PauseAsync(2000);
        //if (data.Condition("'Class Code 2' != NULL"))
        //{
            await page.EnterSearchValueAsync(data.Resolve("{{data:class_code_frame_class_code_window_searchvalue_166}}"));
        //}
        //if (data.Condition("'Class Code 2' != NULL"))
        //{
            await page.EnterSelectClassCodeAsync(data.Resolve("{{data:class_code_frame_class_code_window_select_class_code_168}}"));
        //}
        await page.PauseAsync(1000);
        await _scenario.Get<BrowserSession>().Page.Keyboard.PressAsync("Tab");
        if (data.Condition("'Class Code 2' != NULL"))
        {
            await page.VerifySelectClassCodeAsync(data.Resolve("{{data:expected_class_code_frame_class_code_window_select_class_code_value_171}}"), "value");
        }
        await page.WaitForOKClassCodeAsync("Exists");
        await _scenario.Get<BrowserSession>().Page.Keyboard.PressAsync("Tab");
        await page.ClickOKClassCodeAsync();
        await page.EnterTotalPayrollEstimatedAsync(data.Resolve("{{data:class_code_frame_class_code_window_total_payroll_estimated_174}}"));
        if (await page.IsWaiverOfSubrogationExposureVisibleAsync())
        {
            await page.EnterWaiverOfSubrogationExposureAsync(data.Resolve("{{data:class_code_frame_class_code_window_waiver_of_subrogation_exposure_175}}"));
        }
        await page.EnterNumberOfPartTimeEmployeesAsync(data.Resolve("{{data:class_code_frame_class_code_window_number_of_part_time_employees_176}}"));
        await page.EnterNumberOfFullTimeEmployeesAsync(data.Resolve("{{data:class_code_frame_class_code_window_number_of_full_time_employees_177}}"));
        await _scenario.Get<BrowserSession>().Page.Keyboard.PressAsync("Tab");
        await page.ClickOKDetailsAsync();
        await page.WaitForClassCodeFrameAsync("Absent");

    }

    [Given(@"^I navigate to Entity Schedule$")]
    [When(@"^I navigate to Entity Schedule$")]
    [Then(@"^I navigate to Entity Schedule$")]
    public async Task NavigateToEntityScheduleAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("EntityInfoFrameEntityInfoWindowFax_0113", "[0-9]{10}");
        data.GenerateRandom("EntityInfoFrameEntityInfoWindowBureauNumber_0113", "[0-9]{7}");
        data.GenerateRandom("EntityInfoFrameEntityInfoWindowStateUnemploymentNumberDefault_0113", "[0-9]{6}");

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickEntityScheduleAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickLocationDetailAsync();
        await page.WaitForInsuredTypeAsync("Exists");
        await page.EnterEntityInfoFrameEntityInfoWindowFaxAsync(data.Resolve("{{runtime:EntityInfoFrameEntityInfoWindowFax_0113}}"));
        await page.EnterEntityInfoFrameEntityInfoWindowBureauNumberAsync(data.Resolve("{{runtime:EntityInfoFrameEntityInfoWindowBureauNumber_0113}}"));
        await page.EnterEntityInfoFrameEntityInfoWindowStateUnemploymentNumberDefaultAsync(data.Resolve("{{runtime:EntityInfoFrameEntityInfoWindowStateUnemploymentNumberDefault_0113}}"));
        if (data.Condition("State == \"NJ\""))
        {
            await page.EnterTaxpayerIdAsync(data.Resolve("{{data:nj_taxpayer_id_185}}"));
        }
        await page.EnterEMailAsync(data.Resolve("{{data:entity_info_frame_entity_info_window_e_mail_186}}"));
        await page.ClickOKAsync();
        await page.WaitForEntityInfoFrameAsync("Absent");
        await page.WaitForAssignLocationsAsync("Exists");
        await page.ClickAssignLocationsAsync();
        await page.WaitForAssignLocationAsync("Exists");
        await page.ClickAssignLocationAsync();
        await page.WaitForLocationIDAsync("Exists");
        await page.EnterLocationIDAsync(data.Resolve("{{data:location_assignment_entity_location_locationid_196}}"));
        await page.EnterLocationIDAsync(data.Resolve("{{data:location_assignment_entity_location_locationid_198}}"));
        //await page.VerifyLocationIDAsync(data.Resolve("{{data:expected_location_assignment_entity_location_locationid_value_199}}"), "Value");

        await page.PauseAsync(2000);
        await page.ClickSelectNAICSCodeAsync();
        await page.PauseAsync(1000);
        await page.WaitForNAICSCodeSearchValueAsync("Exists");
        await page.EnterNAICSCodeSearchValueAsync(data.Resolve("{{data:location_assignment_entity_location_naicscodesearchvalue_203}}"));
        await page.EnterSelectAppropriateCodeAsync(data.Resolve("{{data:location_assignment_entity_location_select_appropriate_code_206}}"));
        await _scenario.Get<BrowserSession>().Page.Keyboard.PressAsync("Tab");
        //await page.VerifySelectAppropriateCodeAsync(data.Resolve("{{data:expected_location_assignment_entity_location_select_appropriate_code_value_207}}"), "value");
        //await page.WaitForLocationAssignmentAsync("Absent");
        //await page.EnterSelectAppropriateCodeAsync(data.Resolve("{{data:location_assignment_entity_location_select_appropriate_code_209}}"));
        //await page.VerifySelectAppropriateCodeAsync(data.Resolve("{{data:expected_location_assignment_entity_location_select_appropriate_code_value_210}}"), "value");
        //await page.WaitForLocationAssignmentAsync("Absent");
        //await page.VerifySelectAppropriateCodeAsync(data.Resolve("{{data:expected_location_assignment_entity_location_select_appropriate_code_value_212}}"), "value");
       await page.PauseAsync(2000);
        await page.ClickOKFirstAsync();
        await page.WaitForOKSecondAsync("Absent");
        await page.ClickOKAsync();
        await page.WaitForLocationAssignmentAsync("Absent");

    }

    [Given(@"^I complete endorsements$")]
    [When(@"^I complete endorsements$")]
    [Then(@"^I complete endorsements$")]
    public async Task CompleteEndorsementsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickWCNavigationLinksEndorsementsAsync();
        //await page.PauseAsync(1000);
        //await page.ClickEndorsementMainAddEndorsementAsync();
        await page.PauseAsync(3000);
        if (data.Condition("State == \"NY\""))
        {
            await page.EnterAreThereAnyOfficersThatShouldBeExcludedAsync(data.Resolve("{{data:are_there_any_officers_that_should_be_excluded_218}}"));
        }
        //await page.WaitForEndorsementMainAddEndorsementAsync("Exists");

    }

    [Given(@"^I add Designated Workplaces Exclusion$")]
    [When(@"^I add Designated Workplaces Exclusion$")]
    [Then(@"^I add Designated Workplaces Exclusion$")]
    public async Task AddDesignatedWorkplacesExclusionAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());


        if (data.Condition("State != \"VT\" && State != \"VA\" && State != \"PA\"&& State != \"NY\"|| State == \"NV\""))
        {

            //await page.ClickWCNavigationLinksEndorsementsAsync();
            //await page.WaitForEndorsementMainAddEndorsementAsync("Exists");
            await page.ClickEndorsementMainAddEndorsementAsync();

            await page.PauseAsync(1000);
            if (data.Condition("'Endorsement Type' != NULL"))
            {
                await page.EnterCG2401NonBindingArbitrationEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_223}}"));
            }
            if (data.Condition("State != NULL"))
            {
                await page.EnterEndorsementsDesignatedWorkplacesExclusionStateAsync(data.Resolve("{{data:state_225}}"));
            }
            if (data.Condition("City != NULL"))
            {
                await page.EnterCityAsync(data.Resolve("{{data:city_224}}"));
            }
            //await page.ClickDesignatedWorkplacesExclusionOKAsync();
            await page.ClickOKAsync();
        }
    }

    [Given(@"^I add Partners, Officers And Others Exclusion$")]
    [When(@"^I add Partners, Officers And Others Exclusion$")]
    [Then(@"^I add Partners, Officers And Others Exclusion$")]
    public async Task AddPartnersOfficersAndOthersExclusionAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        if (data.Condition("State !=\"NE\" && State !=\"OK\" && State !=\"RI\" && State != \"WV\" && State != \"VT\" && State != \"VA\" && State != \"CO\" && State != \"PA\" && State != \"NY\" && State != \"NJ\""))
        {
            //await page.ClickWCNavigationLinksEndorsementsAsync();
            await page.ClickEndorsementMainAddEndorsementAsync();
            //await page.WaitForEndorsementMainAddEndorsementAsync("Exists");
            if (data.Condition("'Endorsement Type' != NULL"))
            {
                await page.EnterEndorsementsPartnersOfficersAndOthersExclusionEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_229}}"));
            }
            if (data.Condition("(State!=\"MO\")&&(State!=\"ID\")"))
            {
                await page.ClickAddExcludedOfficerInformationAsync();
            }
            if (data.Condition("(Officers != NULL)&&(State!=\"MO\")&&(State!=\"ID\")"))
            {
                await page.EnterOfficersAsync(data.Resolve("{{data:officers_231}}"));
            }
            if (data.Condition("('Position Held' != NULL)&&(State!=\"MO\")&&(State!=\"ID\")"))
            {
                await page.EnterOfficersPositionHeldAsync(data.Resolve("{{data:officers_position_held_232}}"));
            }
            if (data.Condition("(State != \"IA\")&&(State != \"IN\")&&(State!=\"MA\")&&(State!=\"ID\")&&(State!=\"MS\")&&(State!=\"KY\")&&(State!=\"SC\")&&(State!=\"MT\")&&(State!=\"KS\")&&(State!=\"ME\")"))
            {
                await page.ClickAddExcludedOthersInformationAsync();
            }
            if (data.Condition("(State != \"IA\")&&(State != \"IN\")&&(State!=\"MA\")&&(State!=\"ID\")&&(State!=\"MS\")&&(State!=\"KY\")&&(State!=\"SC\")&&(State!=\"MT\")&&(State!=\"KS\")&&(State!=\"ME\")"))
            {
                await page.EnterOthersAsync(data.Resolve("{{data:others_234}}"));
            }
            await page.ClickOKAsync();
            //await page.ClickEndorsementMainAddEndorsementAsync();
        }



    }

    [Given(@"^I add Sole Proprietors, Partners, Officers And Others Coverage$")]
    [When(@"^I add Sole Proprietors, Partners, Officers And Others Coverage$")]
    [Then(@"^I add Sole Proprietors, Partners, Officers And Others Coverage$")]
    public async Task AddSoleProprietorsPartnersOfficersAndOthersCoverageAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());




        if (data.Condition("State !=\"RI\" && State != \"WV\" && State != \"VT\" && State != \"VA\" && State != \"AR\" && State != \"NY\" && State != \"NV\""))
        {
            //await page.ClickWCNavigationLinksEndorsementsAsync();
            //await page.WaitForEndorsementMainAddEndorsementAsync("Exists");
            await page.ClickEndorsementMainAddEndorsementAsync();
            await page.PauseAsync(2000); 
            if (data.Condition("'Endorsement Type' != NULL"))
            {
                await page.EnterCG2401NonBindingArbitrationEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_240}}"));
            }
            await page.ClickAddSoleProprietorInformationAsync();
            if (data.Condition("'Sole Proprietors' != NULL"))
            {
                await page.EnterSoleProprietorsAsync(data.Resolve("{{data:sole_proprietors_242}}"));
            }
            await page.ClickAddPartnerInformationAsync();
            if (data.Condition("Partners != NULL"))
            {
                await page.EnterPartnersAsync(data.Resolve("{{data:partners_244}}"));
            }
            if (data.Condition("(State!=\"CO\")&&(State!=\"DE\")&&(State!=\"IA\")&&(State!=\"MN\")&&(State!=\"MO\")&&(State!=\"NH\")&&(State!=\"SD\")&&(State!=\"AL\")"))
            {
                await page.ClickAddOthersInformationAsync();
            }
            if (data.Condition("(State!=\"CO\")&&(State!=\"DE\")&&(State!=\"IA\")&&(State!=\"MN\")&&(State!=\"MO\")&&(State!=\"NH\")&&(State!=\"SD\")&&(State!=\"AL\")"))
            {
                await page.EnterOthersAsync(data.Resolve("{{data:others_246}}"));
            }
            await page.ClickOKAsync();
        }

      

    }

    [Given(@"^I complete WC UW Questions$")]
    [When(@"^I complete WC UW Questions$")]
    [Then(@"^I complete WC UW Questions$")]
    public async Task CompleteWCUWQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickUWQuestionsWorkersCompAsync();
        await page.WaitForUWQuestionsUmbrellaUpdateAnswersAsync("Exists");
        await page.ClickUWQuestionsUmbrellaUpdateAnswersAsync();
        await page.WaitForArePhysicalsRequiredAfterOffersOfEmploymentAreMadeAsync("NotEqual");
        await page.EnterListAllPoliciesWithAmericanNationalAsync(data.Resolve("{{data:list_all_policies_with_american_national_254}}"));

    }

    [Given(@"^I navigate to Pricing Screen$")]
    [When(@"^I navigate to Pricing Screen$")]
    [Then(@"^I navigate to Pricing Screen$")]
    public async Task NavigateToPricingScreenAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickPricingAsync();
        //await page.WaitForPricingDetailAsync("Exists");
        //await page.ClickPricingDetailAsync();
        //await page.ClickPricingDetailOKAsync();
        //await page.WaitForPricingDetailAsync("Exists");



        if (data.Condition("State ==\"PA\" || State ==\"NJ\""))
        {
            await page.ClickWorksheetAsync();
            await page.EnterPremisesCredit(data.Resolve("{{data:worksheet_pa_nj_premises_credit_255}}"));
            await page.PauseAsync(1000);
            await page.EnterPremisesComments(data.Resolve("{{data:worksheet_pa_nj_premises_comments_256}}"));
            await page.EnterClassificationPecularities(data.Resolve("{{data:worksheet_pa_nj_classification_pecularities_257}}"));
            await page.PauseAsync(1000);
            await page.EnterClassificationPecularitiesComments(data.Resolve("{{data:worksheet_pa_nj_classification_comments_258}}"));
            await page.PauseAsync(1000);
            await page.EnterMedicalFacilities(data.Resolve("{{data:worksheet_pa_nj_medical_facilities_259}}"));
            await page.PauseAsync(1000);
            await page.EnterMedicalFacilitiesComments(data.Resolve("{{data:worksheet_pa_nj_medical_comments_260}}"));
            await page.EnterExtraordinarySafetyPrograms(data.Resolve("{{data:worksheet_pa_nj_extraordinary_safety_programs_261}}"));
            await page.PauseAsync(1000);
            await page.EnterExtraordinarySafetyProgramsComments(data.Resolve("{{data:worksheet_pa_nj_extraordinary_safety_comments_262}}"));
            await page.PauseAsync(1000);
            await page.EnterSafetyDevices(data.Resolve("{{data:worksheet_pa_nj_safety_devices_264}}"));
            await page.PauseAsync(1000);
            await page.EnterSafetyDevicesComments(data.Resolve("{{data:worksheet_pa_nj_safety_comments_265}}"));
            await page.PauseAsync(1000);
            await page.EnterEmployeesSelection(data.Resolve("{{data:worksheet_pa_nj_employees_selection_267}}"));
            await page.PauseAsync(1000);
            await page.EnterEmployeeselectionComments(data.Resolve("{{data:worksheet_pa_nj_employees_comments_268}}"));
            await page.PauseAsync(1000);
            await page.EnterManagementCooperationWithInsuranceCarrierStateInput(data.Resolve("{{data:worksheet_pa_nj_management_cooperation_271}}"));
            await page.PauseAsync(1000);
            await page.EnterManagementCooperationWithInsuranceCarrierStateInputComments(data.Resolve("{{data:worksheet_pa_nj_management_cooperation_comments_272}}"));
            await page.PauseAsync(1000);
            await page.EnterPolicyExpensesStateInput(data.Resolve("{{data:worksheet_pa_nj_policy_expenses_273}}"));
            await page.PauseAsync(1000);
            await page.EnterPolicyExpensesStateInputComments(data.Resolve("{{data:worksheet_pa_nj_policy_expenses_comments_274}}"));
            await page.PauseAsync(1000);
            await page.EnterOtherFactorsStateInput(data.Resolve("{{data:worksheet_pa_nj_other_factors_275}}"));
            await page.PauseAsync(1000);
            await page.EnterOtherFactorsStateInputComments(data.Resolve("{{data:worksheet_pa_nj_other_factors_comments_276}}"));
            await page.ClickOKAsync();
        }


        if (data.Condition("State ==\"MO\""))



        {

            await page.ClickWorksheetAsync();
            await page.EnterPremisesCredit(data.Resolve("{{data:worksheet_mo_premises_credit_255}}"));
            //await _scenario.Get<BrowserSession>().Page.Keyboard.PressAsync("Tab");
            await page.PauseAsync(1000);
            await page.EnterPremisesComments(data.Resolve("{{data:worksheet_mo_premises_comments_256}}"));
            //await _scenario.Get<BrowserSession>().Page.Keyboard.PressAsync("Tab");
            await page.PauseAsync(1000);
            await page.ClickOKAsync();

        }



        if (data.Condition("State ==\"CO\" || State ==\"VT\" || State ==\"VA\" || State ==\"NV\" || State ==\"NY\" || State ==\"OK\" || State ==\"SD\" || State ==\"TN\" || State ==\"UT\" || State == \"AZ\" || State == \"CT\" || State == \"DE\" || State == \"GA\" || State == \"IA\" || State == \"IN\" || State == \"MD\" || State == \"MN\""))
        {
            await page.ClickWorksheetAsync();
            await page.EnterPremisesCredit(data.Resolve("{{data:worksheet_multistate_premises_credit_255}}"));
            //await _scenario.Get<BrowserSession>().Page.Keyboard.PressAsync("Tab");
            await page.PauseAsync(1000);
            await page.EnterPremisesComments(data.Resolve("{{data:worksheet_multistate_premises_comments_256}}"));
            //await _scenario.Get<BrowserSession>().Page.Keyboard.PressAsync("Tab");
            await page.PauseAsync(1000);
            await page.EnterClassificationPecularities(data.Resolve("{{data:worksheet_multistate_classification_pecularities_257}}"));
            //await _scenario.Get<BrowserSession>().Page.Keyboard.PressAsync("Tab");
            await page.PauseAsync(1000);
            await page.EnterClassificationPecularitiesComments(data.Resolve("{{data:worksheet_multistate_classification_comments_258}}"));
            //await _scenario.Get<BrowserSession>().Page.Keyboard.PressAsync("Tab");
            await page.PauseAsync(1000);
            await page.EnterMedicalFacilities(data.Resolve("{{data:worksheet_multistate_medical_facilities_259}}"));
            //await _scenario.Get<BrowserSession>().Page.Keyboard.PressAsync("Tab");
            await page.PauseAsync(1000);
            await page.EnterMedicalFacilitiesComments(data.Resolve("{{data:worksheet_multistate_medical_comments_260}}"));
            //await _scenario.Get<BrowserSession>().Page.Keyboard.PressAsync("Tab");
            await page.PauseAsync(1000);
            await page.EnterSafetyDevices(data.Resolve("{{data:worksheet_multistate_safety_devices_264}}"));
            //await _scenario.Get<BrowserSession>().Page.Keyboard.PressAsync("Tab");
            await page.PauseAsync(1000);
            await page.EnterSafetyDevicesComments(data.Resolve("{{data:worksheet_multistate_safety_comments_265}}"));
            //await _scenario.Get<BrowserSession>().Page.Keyboard.PressAsync("Tab");
            await page.PauseAsync(1000);
            await page.EnterEmployeesSelection(data.Resolve("{{data:worksheet_multistate_employees_selection_267}}"));
            //await _scenario.Get<BrowserSession>().Page.Keyboard.PressAsync("Tab");
            await page.EnterEmployeeselectionComments(data.Resolve("{{data:worksheet_multistate_employees_comments_268}}"));
            await page.PauseAsync(1000);
            //await _scenario.Get<BrowserSession>().Page.Keyboard.PressAsync("Tab");
            await page.EnterManagementSafetyOrganizationStateInput(data.Resolve("{{data:worksheet_multistate_management_safety_organization_269}}"));
            //await _scenario.Get<BrowserSession>().Page.Keyboard.PressAsync("Tab");
            await page.PauseAsync(1000);
            await page.EnterManagementSafetyOrganizationStateInputComments(data.Resolve("{{data:worksheet_multistate_management_safety_organization_comments_270}}"));
            //await _scenario.Get<BrowserSession>().Page.Keyboard.PressAsync("Tab");
            await page.EnterManagementCooperationWithInsuranceCarrierStateInput(data.Resolve("{{data:worksheet_multistate_management_cooperation_271}}"));
            //await _scenario.Get<BrowserSession>().Page.Keyboard.PressAsync("Tab");
            await page.EnterManagementCooperationWithInsuranceCarrierStateInputComments(data.Resolve("{{data:worksheet_multistate_management_cooperation_comments_272}}"));
            //await _scenario.Get<BrowserSession>().Page.Keyboard.PressAsync("Tab");
            await page.ClickOKAsync();
        }


    }

    [Given(@"^I verify Class Codes on Policy are Valid$")]
    [When(@"^I verify Class Codes on Policy are Valid$")]
    [Then(@"^I verify Class Codes on Policy are Valid$")]
    public async Task VerifyClassCodesOnPolicyAreValidAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BusinessClassificationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyInvalidClassCodeMessageAsync("Absent", "");

    }

    [Given(@"^I complete required billing information for billing$")]
    [When(@"^I complete required billing information for billing$")]
    [Then(@"^I complete required billing information for billing$")]
    public async Task CompleteRequiredBillingInformationForBillingAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickNavigationBillingAsync();
        //await page.WaitForBillingAsync("Exists");
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_263}}"));
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_266}}"));
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_270}}"));
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
        //await page.WaitForNotepadHeadingAsync("Exists");
        await page.ClickAddNotesRemarksAsync();
        await page.EnterTextBoxAsync(data.Resolve("{{data:notepad_text_remarks_278}}"));
        await page.PauseAsync(1000);
        await _scenario.Get<BrowserSession>().Page.Keyboard.PressAsync("Tab");
        await page.ClickOKAsync();

    }

    [Given(@"^I complete required submission information$")]
    [When(@"^I complete required submission information$")]
    [Then(@"^I complete required submission information$")]
    public async Task CompleteRequiredSubmissionInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        //await page.WaitForSubmissionAsync("Visible");
        await page.ClickSubmissionAsync();
        //await page.WaitForSubmissionHeadingAsync("Exists");
        //await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_281}}"));
        //await page.VerifyOrderAuditAsync("Exists", "");
        //await page.EnterOrderAuditAsync(data.Resolve("{{data:order_audit_283}}"));
        //await page.VerifySubmissionHeadingAsync("Absent", "");
        //await page.ClickSubmissionAsync();
        await page.PauseAsync(1000);
        //await page.WaitForSubmissionHeadingAsync("Exists");
        //await page.PauseAsync(1000);

    }

    [Given(@"^I run Stoplight$")]
    [When(@"^I run Stoplight$")]
    [Then(@"^I run Stoplight$")]
    public async Task RunStoplightAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        //await page.VerifyIsThisCoverageBoundAsync("Exists", "");
        //await page.VerifyIsThisCoverageBoundAsync(data.Resolve("{{data:expected_is_this_coverage_bound_value_291}}"), "Value");
        //await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_292}}"));
        await page.ClickCompleteApplicationAsync();
        //await page.VerifyStoplightWaitingWindowCloseAsync("Absent", "");
        await page.PauseAsync(1000);
        //await page.VerifyStoplightWaitingWindowErrorAsync("Exists", "");
        //await page.ClickStoplightWaitingWindowFirstCloseButtonOnErrorAsync();
        //await page.PauseAsync(1000);
        //await page.ClickCompleteApplicationAsync();
        //await page.PauseAsync(1000);
        //await page.ClickStoplightWaitingWindowCloseAsync();
        //await page.WaitForStoplightWaitingWindowAsync("Absent");
        //await page.PauseAsync(1000);
        //await page.VerifyLoadingMessageAsync("Visible", "");
        //await page.PauseAsync(1000);
        //await page.VerifyAllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabsAsync("Exists", "");
        //await page.ClickCompleteApplicationAsync();
        //await page.VerifyStoplightWaitingWindowCloseAsync("Absent", "");
        //await page.PauseAsync(1000);
        //await page.VerifyStoplightWaitingWindowErrorAsync("Exists", "");
        await page.ClickStoplightWaitingWindowFirstCloseButtonOnErrorAsync();
        await page.PauseAsync(1000);
        //await page.ClickCompleteApplicationAsync();
        //await page.PauseAsync(1000);
        //await page.ClickStoplightWaitingWindowCloseAsync();
        //await page.WaitForStoplightWaitingWindowAsync("Absent");
        //await page.PauseAsync(1000);
        //await page.VerifyAllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabsAsync("Absent", "");

    }

    [Given(@"^I verify values in premium fields$")]
    [When(@"^I verify values in premium fields$")]
    [Then(@"^I verify values in premium fields$")]
    public async Task VerifyValuesInPremiumFieldsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyFullTermPremiumAsync(data.Resolve("{{data:expected_full_term_premium_value_324}}"), "value");
        await page.VerifyPremiumWrittenAsync(data.Resolve("{{data:expected_premium_written_value_325}}"), "value");
        await page.VerifyPriorPremiumAsync(data.Resolve("{{data:expected_prior_premium_value_326}}"), "value");
        await page.VerifyPremiumChangeAsync(data.Resolve("{{data:expected_premium_change_value_327}}"), "value");
        //await page.EnterTitleAsync(data.Resolve("{{data:title_329}}"));
        //await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_330}}"));
        //data.Set("SessionId", await page.CaptureResultAsync("value"));

    }

    [Given(@"^I complete forms verification$")]
    [When(@"^I complete forms verification$")]
    [Then(@"^I complete forms verification$")]
    public async Task CompleteFormsVerificationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.EnterSessionIDAsync(data.Resolve("{B[SessionId]}"));
        await page.VerifyStatusCodeAsync(data.Resolve("{{data:expected_statuscode_value_334}}"), "value");
        await page.PauseAsync(1000);
        await page.PauseAsync(1000);

    }

    [Given(@"^I sign out of the application$")]
    [When(@"^I sign out of the application$")]
    [Then(@"^I sign out of the application$")]
    public async Task SignOutOfTheApplicationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickLoggedInUserAsync();
        await page.ClickLogoutAsync();
        await page.PauseAsync(1000);
        await page.VerifyBrowserCommunicationHTTPStatusZeroAsync("Exists", "");
        await page.ClickOKAsync();
        await page.WaitForOKAsync("Absent");
        await page.ClickLoggedInUserAsync();
        await page.ClickLogoutAsync();

    }

}
