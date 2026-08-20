using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "WC Expanded")]
public sealed class WCExpandedSteps
{
    private readonly ScenarioContext _scenario;
    public WCExpandedSteps(ScenarioContext scenario) => _scenario = scenario;

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
        // Source step 0044: RANDOM input for FEIN.
        await page.EnterFEINAsync(data.Resolve("{{runtime:FEIN_0044}}"));

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForQuickQuoteAsync("Exists");
        await page.SetQuickQuoteAsync(data.Resolve("{{data:quick_quote_2}}"));
        await page.WaitForUnderwritingInfoAsync("Exists");
        if (data.Condition("'Insured Type' != NULL"))
        {
                    await page.EnterInsuredTypeAsync(data.Resolve("{{data:insured_type_4}}"));
                    await page.PressInsuredTypeAsync("Tab");
                    await page.PressInsuredTypeAsync("CLICK");
                    await page.PressInsuredTypeAsync("Tab");
                    await page.PressInsuredTypeAsync("Tab");
        }
        if (data.Condition("'Insured Type' != NULL"))
        {
                    await page.ClickEntityTypeAsync();
        }
        await page.WaitForBusinessNameAsync("Visible");
        if (data.Condition("'Business Name' != NULL"))
        {
                    await page.EnterBusinessNameAsync(data.Resolve("{{data:business_name_7}}"));
                    await page.PressBusinessNameAsync("Tab");
                    await page.PressBusinessNameAsync("CLICK");
                    await page.PressBusinessNameAsync("Tab");
        }
        if (data.Condition("'Legal Nature' != NULL"))
        {
                    await page.EnterEntityTypeAsync(data.Resolve("{{data:entity_type_8}}"));
                    await page.PressEntityTypeAsync("Tab");
                    await page.PressEntityTypeAsync("CLICK");
                    await page.PressEntityTypeAsync("Tab");
        }
        if (data.Condition("'Address 1' != NULL"))
        {
                            // Source step 0041: RANDOM input for Primary Phone.
        await page.EnterPrimaryPhoneAsync(data.Resolve("{{runtime:PrimaryPhone_0041}}"));
        await page.EnterAddress17A1FBAsync(data.Resolve("{{data:address1_10}}"));
                    await page.PressAddress17A1FBAsync("Tab");
                    await page.PressAddress17A1FBAsync("CLICK");
                    await page.PressAddress17A1FBAsync("Tab");
        }
        if (data.Condition("ZipCode != NULL"))
        {
                    await page.EnterZipCode26D22Async(data.Resolve("{{data:zipcode_11}}"));
                    await page.PressZipCode26D22Async("Tab");
                    await page.PressZipCode26D22Async("CLICK");
                    await page.PressZipCode26D22Async("Tab");
        }
        await page.VerifyYearsInBusinessAsync("Exists", "");
        await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_13}}"));
        await page.PressYearsInBusinessAsync("Tab");
        if (data.Condition("'Product (LOB)' != \"UMB\""))
        {
                    await page.EnterNameOfAuditContactAsync(data.Resolve("{{data:name_of_audit_contact_15}}"));
                    await page.PressNameOfAuditContactAsync("Tab");
                    await page.PressNameOfAuditContactAsync("CLICK");
                    await page.PressNameOfAuditContactAsync("Tab");
        }
        // Source step 0045: RANDOM input for Audit Telephone #.
        if (data.Condition("'Product (LOB)' != \"UMB\""))
        {
            await page.EnterAuditTelephoneAsync(data.Resolve("{{runtime:AuditTelephone_0045}}"));
        }
        await page.EnterNameOfInspectionContactAsync(data.Resolve("{{data:name_of_inspection_contact_17}}"));
        await page.PressNameOfInspectionContactAsync("Tab");
        await page.PressNameOfInspectionContactAsync("CLICK");
        await page.PressNameOfInspectionContactAsync("Tab");
        // Source step 0045: RANDOM input for Inspection Telephone #.
        await page.EnterInspectionTelephoneAsync(data.Resolve("{{runtime:InspectionTelephone_0045}}"));
        await page.EnterInsuredEMailAddressAsync(data.Resolve("{{data:insured_e_mail_address_19}}"));
        await page.PressInsuredEMailAddressAsync("Tab");
        await page.PressInsuredEMailAddressAsync("CLICK");
        await page.PressInsuredEMailAddressAsync("Tab");
        await page.EnterWebsiteAddressAsync(data.Resolve("{{data:website_address_20}}"));
        await page.PressWebsiteAddressAsync("Tab");
        await page.PressWebsiteAddressAsync("CLICK");
        await page.PressWebsiteAddressAsync("Tab");
        data.Set("State", data.Resolve("{{data:state}}"));
        data.Set("Product (LOB)", data.Resolve("{{data:product_lob}}"));

    }

    [Given(@"^I add a new Associated Client \- Business Owner Type \- Click Add Client$")]
    [When(@"^I add a new Associated Client \- Business Owner Type \- Click Add Client$")]
    [Then(@"^I add a new Associated Client \- Business Owner Type \- Click Add Client$")]
    public async Task AddANewAssociatedClientBusinessOwnerTypeClickAddClientAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForAddClientAsync("Exists");
        await page.PressAddClientAsync("TAB");
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

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyAJAXErrorCheckAsync("Exists", "");

    }

    [Given(@"^I complete required billing information$")]
    [When(@"^I complete required billing information$")]
    [Then(@"^I complete required billing information$")]
    public async Task CompleteRequiredBillingInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickBilling6ED79Async();
        await page.WaitForBillingD1518Async("Exists");
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_32}}"));
        await page.PressBillTypeAsync("Tab");
        await page.PressBillTypeAsync("TAB");
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_35}}"));
        await page.PressPayPlanAsync("Tab");
        await page.PressPayPlanAsync("TAB");
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_39}}"));
        await page.PressEasyPayAsync("CLICK");
        await page.PressEasyPayAsync("Enter");
        await page.PressEasyPayAsync("Tab");
        await page.PressEasyPayAsync("Tab");
        await page.PressEasyPayAsync("TAB");
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

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.EnterIndividualTypeAsync(data.Resolve("{{data:individualtype_42}}"));
        await page.PressIndividualTypeAsync("Tab");
        await page.PressIndividualTypeAsync("CLICK");
        await page.PressIndividualTypeAsync("Tab");
        await page.WaitForPleaseVerifySSNF738AAsync("Exists");
        // Source step 0056: RANDOM input for MiddleName.
        await page.EnterMiddleNameAsync(data.Resolve("{{runtime:MiddleName_0056}}"));
        await page.PressFirstNameC5387Async("TAB");
        await page.PressFirstNameC5387Async("Tab");
        // Source step 0056: RANDOM input for LastName.
        await page.EnterLastNameAsync(data.Resolve("{{runtime:LastName_0056}}"));
        await page.EnterDateOfBirth338D7Async(data.Resolve("{{data:dateofbirth_47}}"));
        await page.PressDateOfBirth338D7Async("Tab");
        await page.EnterAddress1D319BAsync(data.Resolve("{{data:address1_48}}"));
        await page.PressAddress1D319BAsync("Tab");
        await page.PressAddress1D319BAsync("Tab");
        await page.EnterCityAsync(data.Resolve("{{data:city_49}}"));
        await page.PressCityAsync("Tab");
        await page.PressCityAsync("Tab");
        await page.PressCityAsync("Tab");
        await page.EnterStateAsync(data.Resolve("{{data:state_50}}"));
        await page.PressStateAsync("Tab");
        await page.PressStateAsync("Tab");
        await page.PressStateAsync("Tab");
        await page.EnterZipCodeA088EAsync(data.Resolve("{{data:zipcode_51}}"));
        await page.PressZipCodeA088EAsync("Tab");
        await page.PressZipCodeA088EAsync("Tab");
        await page.PressZipCodeA088EAsync("Tab");
        await page.EnterGender4973CAsync(data.Resolve("{{data:gender_52}}"));
        await page.PressGender4973CAsync("Tab");
        await page.WaitForClientSearch41F28Async("Exists");
        await page.ClickClientSearch41F28Async();
        // Source RANDOM FirstName entered after Client Search per Tosca source step.
        await page.EnterFirstName55A0BAsync(data.Resolve("{{runtime:FirstName_0056}}"));
        await page.VerifySearchResultsDuckCreekPolicyFirstCheckboxAsync("Absent", "");
        await page.ClickOKAsync();
        await page.ClickOrderSSN5E031Async();
        await page.PressEnterSSNFA186Async("TAB");
        await page.PressEnterSSNFA186Async("Enter");
        await page.EnterEnterSSNFA186Async(data.Resolve("{{data:enter_ssn_60}}"));
        await page.PressEnterSSNFA186Async("Tab");
        await page.PressEnterSSNFA186Async("Tab");
        await page.ClickEnterSSNFA186Async();
        await page.VerifyVerify7A388Async("Absent", "");
        await page.ClickCompleteAsync();
        await page.ClickDetail6D228Async();
        await page.WaitForEnterSSNFA186Async("Exists");
        await page.ClickVerify7A388Async();
        await page.WaitForPleaseVerifySSNF738AAsync("Absent");
        await page.ClickCompleteAsync();
        await page.WaitForEnterSSNFA186Async("Exists");
        await page.ClickVerify7A388Async();
        await page.WaitForPleaseVerifySSNF738AAsync("Absent");
        await page.ClickCompleteAsync();
        await page.WaitForClientSearchFDC36Async("Exists");
        await page.ClickClientSearchFDC36Async();
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
        await page.WaitForClientSearchFDC36Async("Absent");

    }

    [Given(@"^I navigate to Underwriting Info Screen$")]
    [When(@"^I navigate to Underwriting Info Screen$")]
    [Then(@"^I navigate to Underwriting Info Screen$")]
    public async Task NavigateToUnderwritingInfoScreenAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickUnderwritingInfoAsync();
        await page.WaitForIsThereAPriorCarrierAsync("Exists");
        await page.EnterIsThereAPriorCarrierAsync(data.Resolve("{{data:is_there_a_prior_carrier_80}}"));
        await page.PressIsThereAPriorCarrierAsync("Tab");
        await page.WaitForCarrierAsync("Exists");
        await page.EnterCarrierAsync(data.Resolve("{{data:carrier_82}}"));
        await page.PressCarrierAsync("Tab");
        await page.PressCarrierAsync("Tab");
        await page.EnterPolicyNumberBA28EAsync(data.Resolve("{{data:policy_number_83}}"));
        await page.PressPolicyNumberBA28EAsync("Tab");
        await page.EnterPolicyTypeAsync(data.Resolve("{{data:policy_type_84}}"));
        await page.PressPolicyTypeAsync("Tab");
        await page.EnterEffectiveDateB557FAsync(data.Resolve("{DATE[][-2y][MM'/'dd'/'yyyy]}"));
        await page.PressEffectiveDateB557FAsync("Tab");
        await page.EnterExpirationDate34EACAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.PressExpirationDate34EACAsync("Tab");
        await page.EnterModificationFactorAsync(data.Resolve("{{data:modificationfactor_87}}"));
        await page.PressModificationFactorAsync("Tab");
        await page.EnterTotalPremiumAsync(data.Resolve("{{data:total_premium_88}}"));
        await page.PressTotalPremiumAsync("Tab");
        await page.ClickOtherInsuranceHistoryOKAsync();
        await page.WaitForDetail0F8C6Async("Exists");
        await page.ClickLossExperienceAsync();
        await page.WaitForNoKnownLossesAsync("Exists");
        await page.SetNoKnownLossesAsync(data.Resolve("{{data:no_known_losses_93}}"));
        await page.PressNoKnownLossesAsync("Tab");
        await page.ClickReturnToQuoteAsync();
        await page.EnterTitleAsync(data.Resolve("{{data:title_95}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_96}}"));
        await page.VerifyResultAsync(data.Resolve("{{data:expected_result_value_97}}"), "value");

    }

    [Given(@"^I complete required policy information$")]
    [When(@"^I complete required policy information$")]
    [Then(@"^I complete required policy information$")]
    public async Task CompleteRequiredPolicyInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickPolicyInfoAsync();
        await page.WaitForPolicyInfoHeaderAsync("Exists");
        await page.PauseAsync(1000);
        await page.EnterEffectiveDate95094Async(data.Resolve("{{data:effectivedate_101}}"));
        await page.PressEffectiveDate95094Async("Tab");
        await page.PauseAsync(1000);
        if (data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_103}}"));
                    await page.PressPrimaryRatingStateAsync("Tab");
        }
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_104}}"));
        await page.PressWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync("Tab");
        await page.PressWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync("Tab");
        await page.PauseAsync(1000);
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_108}}"));
        await page.PressWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync("CLICK");
        await page.PressWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync("Enter");
        await page.PressWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync("Tab");
        await page.VerifyPriorAmericanNationalPolicyAsync("Absent", "");
        await page.VerifyWhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNationalAsync("Absent", "");
        await page.VerifyIsThisPolicyBeingFullyCancelledAsync("Absent", "");
        await page.PauseAsync(1000);
        await page.WaitForPolicyInfoHeaderAsync("Visible");
        await page.WaitForDescriptionOfSpecifiedOperationAsync("Visible");
        await page.PressDescriptionOfSpecifiedOperationAsync("TAB");
        await page.EnterDescriptionOfSpecifiedOperationAsync("AL WC ST {NMONTH}.{NDAY}.{NYEAR} {Time}");
        await page.PressDescriptionOfSpecifiedOperationAsync("Tab");
        data.Set("QuoteDescription", await page.CaptureDescriptionOfSpecifiedOperationAsync("value"));

    }

    [Given(@"^I complete WC Specific Fields$")]
    [When(@"^I complete WC Specific Fields$")]
    [Then(@"^I complete WC Specific Fields$")]
    public async Task CompleteWCSpecificFieldsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.EnterHasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverageAsync(data.Resolve("{{data:has_the_applicant_been_in_business_for_at_least_3_years_with_continuous_workers_compensation_coverage_118}}"));
        await page.PressHasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverageAsync("CLICK");
        await page.PressHasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverageAsync("Enter");
        await page.PressHasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverageAsync("Tab");

    }

    [Given(@"^I complete Estimated premium$")]
    [When(@"^I complete Estimated premium$")]
    [Then(@"^I complete Estimated premium$")]
    public async Task CompleteEstimatedPremiumAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
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

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickPolicyCovgD3CEFAsync();
        await page.WaitForPolicyCovgHeaderAsync("Exists");
        await page.WaitForPrimaryLocationStateAsync("Exists");
        if (data.Condition("'Primary Rating State' != NULL"))
        {
                    await page.VerifyPrimaryLocationStateAsync("(?i)^Alabama$", "Regex:value");
        }
        if (data.Condition("('Experience Rated' != NULL)&&(State!=\"OK\")"))
        {
                    await page.EnterExperienceRatedAsync(data.Resolve("{{data:experience_rated_124}}"));
                    await page.PressExperienceRatedAsync("Tab");
        }
        if (data.Condition("('Default Experience Mod Type' != NULL)&&(State!=\"OK\")&&(State!=\"NY\")"))
        {
                    await page.EnterDefaultExpModTypeAsync(data.Resolve("{{data:default_exp_mod_type_126}}"));
                    await page.PressDefaultExpModTypeAsync("Tab");
        }

    }

    [Given(@"^I complete Address 1$")]
    [When(@"^I complete Address 1$")]
    [Then(@"^I complete Address 1$")]
    public async Task CompleteAddress1Async()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickLocation8DEE2Async();
        await page.WaitForAddress1C0AF1Async("Exists");
        await page.VerifyZipCodeD2DBAAsync("[0-9]{5}-[0-9]{4}", "Regex:value");
        await page.ClickLocationOKAsync();

    }

    [Given(@"^I complete rating Information$")]
    [When(@"^I complete rating Information$")]
    [Then(@"^I complete rating Information$")]
    public async Task CompleteRatingInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickStateDetailsB407BAsync();
        await page.WaitForIntrastateRiskIDAsync("Exists");
        if (data.Condition("'Waiver of Subrogation' != NULL"))
        {
                    await page.EnterWaiverOfSubrogationAsync(data.Resolve("{{data:waiver_of_subrogation_133}}"));
                    await page.PressWaiverOfSubrogationAsync("Tab");
                    await page.PressWaiverOfSubrogationAsync("Tab");
        }
        if (data.Condition("'Small Deductible' != NULL"))
        {
                    await page.EnterSmallDeductibleAsync(data.Resolve("{{data:small_deductible_134}}"));
                    await page.PressSmallDeductibleAsync("Tab");
                    await page.PressSmallDeductibleAsync("Tab");
        }
        if (data.Condition("'Company Name' != NULL"))
        {
                    await page.EnterCompanyNameAsync(data.Resolve("{{data:company_name_135}}"));
                    await page.PressCompanyNameAsync("Tab");
                    await page.PressCompanyNameAsync("CLICK");
                    await page.PressCompanyNameAsync("Tab");
                    await page.PressCompanyNameAsync("Tab");
        }
        if (data.Condition("('Merit Rating' != NULL)&&(State!=\"NY\")"))
        {
                    await page.EnterMeritRatingAsync("");
        }
        if (data.Condition("Deductible != NULL"))
        {
                    await page.EnterDeductible5F45DAsync("");
        }
        if (data.Condition("Deductible != NULL"))
        {
                    await page.EnterDeductible5F45DAsync("");
        }
        if (data.Condition("'Experience Rating Options' != NULL"))
        {
                    await page.EnterExperienceRatingOptionsAsync(data.Resolve("{{data:experience_rating_options_139}}"));
                    await page.PressExperienceRatingOptionsAsync("Tab");
                    await page.PressExperienceRatingOptionsAsync("Tab");
        }
        if (data.Condition("'Experience Mod Type' != NULL"))
        {
                    await page.EnterExperienceModTypeAsync(data.Resolve("{{data:experience_mod_type_140}}"));
                    await page.PressExperienceModTypeAsync("Tab");
                    await page.PressExperienceModTypeAsync("Tab");
        }
        if (data.Condition("'Pending Rate Change' != NULL"))
        {
                    await page.VerifyPendingRateChangeAsync(data.Resolve("{{data:expected_pending_rate_change_value_141}}"), "value");
        }

    }

    [Given(@"^I add Class Codes$")]
    [When(@"^I add Class Codes$")]
    [Then(@"^I add Class Codes$")]
    public async Task AddClassCodesAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickWCScheduleAsync();
        await page.WaitForAddClassCodeAsync("Exists");
        await page.ClickAddClassCodeAsync();
        await page.EnterClassCodeFrameClassCodeWindowAsync("");
        await page.VerifyOKClassCodeAsync("Absent", "");
        await page.WaitForSearchValue53135Async("Exists");
        if (data.Condition("'Class Code 1' != NULL"))
        {
                    await page.EnterSearchValue53135Async(data.Resolve("{{data:class_code_frame_class_code_window_searchvalue_148}}"));
                    await page.PressSearchValue53135Async("Tab");
        }
        await page.PressSearchValue53135Async("TAB");
        if (data.Condition("'Class Code 1' != NULL"))
        {
                    await page.EnterSelectClassCodeAsync(data.Resolve("{{data:class_code_frame_class_code_window_select_class_code_150}}"));
                    await page.PressSelectClassCodeAsync("CLICK");
                    await page.PressSelectClassCodeAsync("Enter");
                    await page.PressSelectClassCodeAsync("Tab");
                    await page.PressSelectClassCodeAsync("CLICK");
                    await page.PressSelectClassCodeAsync("Tab");
                    await page.PressSelectClassCodeAsync("Tab");
        }
        await page.PressSelectClassCodeAsync("TAB");
        await page.PauseAsync(1000);
        if (data.Condition("'Class Code 1' != NULL"))
        {
                    await page.VerifySelectClassCodeAsync(data.Resolve("{{data:expected_class_code_frame_class_code_window_select_class_code_value_153}}"), "value");
        }
        await page.WaitForOKClassCodeAsync("Exists");
        await page.ClickOKClassCodeAsync();
        if (data.Condition("State != \"MD\""))
        {
                    await page.EnterTotalPayrollEstimatedAsync(data.Resolve("{{data:class_code_frame_class_code_window_total_payroll_estimated_156}}"));
                    await page.PressTotalPayrollEstimatedAsync("Tab");
                    await page.PressTotalPayrollEstimatedAsync("CLICK");
                    await page.PressTotalPayrollEstimatedAsync("Tab");
        }
        if (data.Condition("'Waiver of Subrogation Exposure' != NULL"))
        {
                    await page.EnterWaiverOfSubrogationExposureAsync(data.Resolve("{{data:class_code_frame_class_code_window_waiver_of_subrogation_exposure_157}}"));
                    await page.PressWaiverOfSubrogationExposureAsync("Tab");
                    await page.PressWaiverOfSubrogationExposureAsync("CLICK");
                    await page.PressWaiverOfSubrogationExposureAsync("Tab");
        }
        await page.EnterNumberOfPartTimeEmployeesAsync(data.Resolve("{{data:class_code_frame_class_code_window_number_of_part_time_employees_158}}"));
        await page.PressNumberOfPartTimeEmployeesAsync("Tab");
        await page.PressNumberOfPartTimeEmployeesAsync("CLICK");
        await page.PressNumberOfPartTimeEmployeesAsync("Tab");
        await page.EnterNumberOfFullTimeEmployeesAsync(data.Resolve("{{data:class_code_frame_class_code_window_number_of_full_time_employees_159}}"));
        await page.PressNumberOfFullTimeEmployeesAsync("Tab");
        await page.PressNumberOfFullTimeEmployeesAsync("CLICK");
        await page.PressNumberOfFullTimeEmployeesAsync("Tab");
        await page.ClickOKDetailsAsync();
        await page.WaitForClassCodeFrameAsync("Absent");
        await page.WaitForAddClassCodeAsync("Exists");
        await page.ClickAddClassCodeAsync();
        await page.VerifyOKClassCodeAsync("Absent", "");
        await page.WaitForSearchValue53135Async("Exists");
        if (data.Condition("'Class Code 2' != NULL"))
        {
                    await page.EnterSearchValue53135Async(data.Resolve("{{data:class_code_frame_class_code_window_searchvalue_166}}"));
                    await page.PressSearchValue53135Async("Tab");
        }
        await page.PressSearchValue53135Async("TAB");
        if (data.Condition("'Class Code 2' != NULL"))
        {
                    await page.EnterSelectClassCodeAsync(data.Resolve("{{data:class_code_frame_class_code_window_select_class_code_168}}"));
                    await page.PressSelectClassCodeAsync("CLICK");
                    await page.PressSelectClassCodeAsync("Enter");
                    await page.PressSelectClassCodeAsync("Tab");
                    await page.PressSelectClassCodeAsync("CLICK");
                    await page.PressSelectClassCodeAsync("Tab");
                    await page.PressSelectClassCodeAsync("Tab");
        }
        await page.PressSelectClassCodeAsync("TAB");
        await page.PauseAsync(1000);
        if (data.Condition("'Class Code 2' != NULL"))
        {
                    await page.VerifySelectClassCodeAsync(data.Resolve("{{data:expected_class_code_frame_class_code_window_select_class_code_value_171}}"), "value");
        }
        await page.WaitForOKClassCodeAsync("Exists");
        await page.ClickOKClassCodeAsync();
        await page.EnterTotalPayrollEstimatedAsync(data.Resolve("{{data:class_code_frame_class_code_window_total_payroll_estimated_174}}"));
        await page.PressTotalPayrollEstimatedAsync("Tab");
        await page.PressTotalPayrollEstimatedAsync("CLICK");
        await page.PressTotalPayrollEstimatedAsync("Tab");
        if (data.Condition("'Waiver of Subrogation Exposure' != NULL"))
        {
                    await page.EnterWaiverOfSubrogationExposureAsync(data.Resolve("{{data:class_code_frame_class_code_window_waiver_of_subrogation_exposure_175}}"));
                    await page.PressWaiverOfSubrogationExposureAsync("Tab");
        }
        await page.EnterNumberOfPartTimeEmployeesAsync(data.Resolve("{{data:class_code_frame_class_code_window_number_of_part_time_employees_176}}"));
        await page.PressNumberOfPartTimeEmployeesAsync("Tab");
        await page.PressNumberOfPartTimeEmployeesAsync("CLICK");
        await page.PressNumberOfPartTimeEmployeesAsync("Tab");
        await page.EnterNumberOfFullTimeEmployeesAsync(data.Resolve("{{data:class_code_frame_class_code_window_number_of_full_time_employees_177}}"));
        await page.PressNumberOfFullTimeEmployeesAsync("Tab");
        await page.PressNumberOfFullTimeEmployeesAsync("CLICK");
        await page.PressNumberOfFullTimeEmployeesAsync("Tab");
        await page.ClickOKDetailsAsync();
        await page.WaitForClassCodeFrameAsync("Absent");
        await page.EnterClassCodeFrameClassCodeWindowAsync("");

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

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickEntityScheduleEA671Async();
        await page.WaitForEntityScheduleE6C9FAsync("Exists");
        await page.ClickDetail238D5Async();
        await page.WaitForInsuredTypeAsync("Exists");
        await page.EnterEntityInfoFrameEntityInfoWindowFaxAsync(data.Resolve("{{runtime:EntityInfoFrameEntityInfoWindowFax_0113}}"));
        await page.EnterEntityInfoFrameEntityInfoWindowBureauNumberAsync(data.Resolve("{{runtime:EntityInfoFrameEntityInfoWindowBureauNumber_0113}}"));
        await page.EnterEntityInfoFrameEntityInfoWindowStateUnemploymentNumberDefaultAsync(data.Resolve("{{runtime:EntityInfoFrameEntityInfoWindowStateUnemploymentNumberDefault_0113}}"));
        await page.EnterEMailAsync(data.Resolve("{{data:entity_info_frame_entity_info_window_e_mail_186}}"));
        await page.ClickOKAsync();
        await page.WaitForEntityInfoFrameAsync("Absent");
        await page.WaitForAssignLocationsAsync("Exists");
        await page.ClickAssignLocationsAsync();
        await page.WaitForAssignLocationAsync("Exists");
        await page.ClickAssignLocationAsync();
        await page.WaitForLocationIDAsync("Exists");
        await page.EnterLocationIDAsync(data.Resolve("{{data:location_assignment_entity_location_locationid_196}}"));
        await page.PressLocationIDAsync("Tab");
        await page.PressLocationIDAsync("Enter");
        await page.PressLocationIDAsync("Tab");
        await page.PressLocationIDAsync("Tab");
        await page.ClickLocationIDAsync();
        await page.EnterLocationIDAsync(data.Resolve("{{data:location_assignment_entity_location_locationid_198}}"));
        await page.PressLocationIDAsync("Tab");
        await page.PressLocationIDAsync("Enter");
        await page.PressLocationIDAsync("Tab");
        await page.PressLocationIDAsync("Tab");
        await page.VerifyLocationIDAsync(data.Resolve("{{data:expected_location_assignment_entity_location_locationid_value_199}}"), "Value");
        await page.ClickSelectNAICSCodeAsync();
        await page.WaitForNAICSCodeSearchValueAsync("Exists");
        await page.PressNAICSCodeSearchValueAsync("TAB");
        await page.EnterNAICSCodeSearchValueAsync(data.Resolve("{{data:location_assignment_entity_location_naicscodesearchvalue_203}}"));
        await page.PressNAICSCodeSearchValueAsync("CLICK");
        await page.PressNAICSCodeSearchValueAsync("Tab");
        await page.PressNAICSCodeSearchValueAsync("Tab");
        await page.ClickNAICSCodeSearchValueAsync();
        await page.PressSelectAppropriateCodeAsync("TAB");
        await page.EnterSelectAppropriateCodeAsync(data.Resolve("{{data:location_assignment_entity_location_select_appropriate_code_206}}"));
        await page.PressSelectAppropriateCodeAsync("CLICK");
        await page.PressSelectAppropriateCodeAsync("Tab");
        await page.PressSelectAppropriateCodeAsync("Tab");
        await page.PressSelectAppropriateCodeAsync("Click");
        await page.PressSelectAppropriateCodeAsync("Tab");
        await page.PressSelectAppropriateCodeAsync("Tab");
        await page.PressSelectAppropriateCodeAsync("Tab");
        await page.VerifySelectAppropriateCodeAsync(data.Resolve("{{data:expected_location_assignment_entity_location_select_appropriate_code_value_207}}"), "value");
        await page.WaitForLocationAssignmentAsync("Absent");
        await page.EnterSelectAppropriateCodeAsync(data.Resolve("{{data:location_assignment_entity_location_select_appropriate_code_209}}"));
        await page.PressSelectAppropriateCodeAsync("CLICK");
        await page.PressSelectAppropriateCodeAsync("Tab");
        await page.PressSelectAppropriateCodeAsync("Tab");
        await page.PressSelectAppropriateCodeAsync("Click");
        await page.PressSelectAppropriateCodeAsync("Tab");
        await page.PressSelectAppropriateCodeAsync("Tab");
        await page.PressSelectAppropriateCodeAsync("Tab");
        await page.VerifySelectAppropriateCodeAsync(data.Resolve("{{data:expected_location_assignment_entity_location_select_appropriate_code_value_210}}"), "value");
        await page.WaitForLocationAssignmentAsync("Absent");
        await page.VerifySelectAppropriateCodeAsync(data.Resolve("{{data:expected_location_assignment_entity_location_select_appropriate_code_value_212}}"), "value");
        await page.ClickOKFirstAsync();
        await page.PressOKFirstAsync("Tab");
        await page.PressOKFirstAsync("Tab");
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

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickEndorsementsB76E9Async();
        if (data.Condition("State == \"NY\""))
        {
                    await page.EnterAreThereAnyOfficersThatShouldBeExcludedAsync(data.Resolve("{{data:are_there_any_officers_that_should_be_excluded_218}}"));
                    await page.PressAreThereAnyOfficersThatShouldBeExcludedAsync("Tab");
                    await page.PressAreThereAnyOfficersThatShouldBeExcludedAsync("CLICK");
                    await page.PressAreThereAnyOfficersThatShouldBeExcludedAsync("Tab");
        }
        await page.WaitForAddEndorsementB6452Async("Exists");

    }

    [Given(@"^I add Designated Workplaces Exclusion$")]
    [When(@"^I add Designated Workplaces Exclusion$")]
    [Then(@"^I add Designated Workplaces Exclusion$")]
    public async Task AddDesignatedWorkplacesExclusionAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickEndorsementsB76E9Async();
        await page.WaitForAddEndorsement9E5F4Async("Exists");
        await page.ClickAddEndorsement9E5F4Async();
        if (data.Condition("'Endorsement Type' != NULL"))
        {
                    await page.EnterEndorsementType8DB33Async(data.Resolve("{{data:endorsement_type_223}}"));
                    await page.PressEndorsementType8DB33Async("Tab");
                    await page.PressEndorsementType8DB33Async("Tab");
        }
        if (data.Condition("City != NULL"))
        {
                    await page.EnterCityAsync(data.Resolve("{{data:city_224}}"));
                    await page.PressCityAsync("Tab");
                    await page.PressCityAsync("Tab");
        }
        if (data.Condition("State != NULL"))
        {
                    await page.EnterState89468Async(data.Resolve("{{data:state_225}}"));
                    await page.PressState89468Async("Tab");
                    await page.PressState89468Async("Tab");
        }
        await page.ClickDesignatedWorkplacesExclusionOKAsync();

    }

    [Given(@"^I add Partners, Officers And Others Exclusion$")]
    [When(@"^I add Partners, Officers And Others Exclusion$")]
    [Then(@"^I add Partners, Officers And Others Exclusion$")]
    public async Task AddPartnersOfficersAndOthersExclusionAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickEndorsementsB76E9Async();
        await page.WaitForAddEndorsementCE8DDAsync("Exists");
        if (data.Condition("'Endorsement Type' != NULL"))
        {
                    await page.EnterEndorsementTypeF8D4AAsync(data.Resolve("{{data:endorsement_type_229}}"));
                    await page.PressEndorsementTypeF8D4AAsync("Tab");
                    await page.PressEndorsementTypeF8D4AAsync("Tab");
        }
        if (data.Condition("(State!=\"MO\")&&(State!=\"ID\")"))
        {
                    await page.ClickAddExcludedOfficerInformationAsync();
        }
        if (data.Condition("(Officers != NULL)&&(State!=\"MO\")&&(State!=\"ID\")"))
        {
                    await page.EnterOfficersAsync(data.Resolve("{{data:officers_231}}"));
                    await page.PressOfficersAsync("Tab");
                    await page.PressOfficersAsync("Tab");
        }
        if (data.Condition("('Position Held' != NULL)&&(State!=\"MO\")&&(State!=\"ID\")"))
        {
                    await page.EnterOfficersPositionHeldAsync(data.Resolve("{{data:officers_position_held_232}}"));
                    await page.PressOfficersPositionHeldAsync("Tab");
                    await page.PressOfficersPositionHeldAsync("Tab");
        }
        if (data.Condition("(State != \"IA\")&&(State != \"IN\")&&(State!=\"MA\")&&(State!=\"ID\")&&(State!=\"MS\")&&(State!=\"KY\")&&(State!=\"SC\")&&(State!=\"MT\")&&(State!=\"KS\")&&(State!=\"ME\")"))
        {
                    await page.ClickAddExcludedOthersInformationAsync();
        }
        if (data.Condition("(State != \"IA\")&&(State != \"IN\")&&(State!=\"MA\")&&(State!=\"ID\")&&(State!=\"MS\")&&(State!=\"KY\")&&(State!=\"SC\")&&(State!=\"MT\")&&(State!=\"KS\")&&(State!=\"ME\")"))
        {
                    await page.EnterOthersB1A1BAsync(data.Resolve("{{data:others_234}}"));
                    await page.PressOthersB1A1BAsync("Tab");
                    await page.PressOthersB1A1BAsync("Tab");
        }
        await page.ClickPartnersOfficersAndOthersExclusionOKAsync();
        await page.ClickAddEndorsementCE8DDAsync();

    }

    [Given(@"^I add Sole Proprietors, Partners, Officers And Others Coverage$")]
    [When(@"^I add Sole Proprietors, Partners, Officers And Others Coverage$")]
    [Then(@"^I add Sole Proprietors, Partners, Officers And Others Coverage$")]
    public async Task AddSoleProprietorsPartnersOfficersAndOthersCoverageAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickEndorsementsB76E9Async();
        await page.WaitForAddEndorsement44E6AAsync("Exists");
        await page.ClickAddEndorsement44E6AAsync();
        if (data.Condition("'Endorsement Type' != NULL"))
        {
                    await page.EnterEndorsementTypeAEC4FAsync(data.Resolve("{{data:endorsement_type_240}}"));
                    await page.PressEndorsementTypeAEC4FAsync("Tab");
                    await page.PressEndorsementTypeAEC4FAsync("Tab");
        }
        await page.ClickAddSoleProprietorInformationAsync();
        if (data.Condition("'Sole Proprietors' != NULL"))
        {
                    await page.EnterSoleProprietorsAsync(data.Resolve("{{data:sole_proprietors_242}}"));
                    await page.PressSoleProprietorsAsync("Tab");
                    await page.PressSoleProprietorsAsync("Tab");
        }
        await page.ClickAddPartnerInformationAsync();
        if (data.Condition("Partners != NULL"))
        {
                    await page.EnterPartnersAsync(data.Resolve("{{data:partners_244}}"));
                    await page.PressPartnersAsync("Tab");
                    await page.PressPartnersAsync("Tab");
        }
        if (data.Condition("(State!=\"CO\")&&(State!=\"DE\")&&(State!=\"IA\")&&(State!=\"MN\")&&(State!=\"MO\")&&(State!=\"NH\")&&(State!=\"SD\")&&(State!=\"AL\")"))
        {
                    await page.ClickAddOthersInformationAsync();
        }
        if (data.Condition("(State!=\"CO\")&&(State!=\"DE\")&&(State!=\"IA\")&&(State!=\"MN\")&&(State!=\"MO\")&&(State!=\"NH\")&&(State!=\"SD\")&&(State!=\"AL\")"))
        {
                    await page.EnterOthers9E098Async(data.Resolve("{{data:others_246}}"));
                    await page.PressOthers9E098Async("Tab");
                    await page.PressOthers9E098Async("Tab");
        }
        await page.ClickSoleProprietorsPartnersOfficersAndOthersCoverageOKAsync();

    }

    [Given(@"^I complete WC UW Questions$")]
    [When(@"^I complete WC UW Questions$")]
    [Then(@"^I complete WC UW Questions$")]
    public async Task CompleteWCUWQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickUWQuestionsWorkersCompAsync();
        await page.WaitForUpdateAnswers6FF76Async("Exists");
        await page.PressUpdateAnswers6FF76Async("TAB");
        await page.ClickUpdateAnswers6FF76Async();
        await page.WaitForArePhysicalsRequiredAfterOffersOfEmploymentAreMadeAsync("NotEqual");
        await page.PressListAllPoliciesWithAmericanNationalAsync("TAB");
        await page.EnterListAllPoliciesWithAmericanNationalAsync(data.Resolve("{{data:list_all_policies_with_american_national_254}}"));
        await page.PressListAllPoliciesWithAmericanNationalAsync("Tab");
        await page.PressListAllPoliciesWithAmericanNationalAsync("CLICK");
        await page.PressListAllPoliciesWithAmericanNationalAsync("CLICK");
        await page.PressListAllPoliciesWithAmericanNationalAsync("Tab");
        await page.PressListAllPoliciesWithAmericanNationalAsync("Tab");

    }

    [Given(@"^I navigate to Pricing Screen$")]
    [When(@"^I navigate to Pricing Screen$")]
    [Then(@"^I navigate to Pricing Screen$")]
    public async Task NavigateToPricingScreenAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickPricingDCBD4Async();
        await page.WaitForPricingDetailAsync("Exists");
        await page.ClickPricingDetailAsync();
        await page.ClickPricingDetailOKAsync();
        await page.WaitForPricingDetailAsync("Exists");

    }

    [Given(@"^I verify Class Codes on Policy are Valid$")]
    [When(@"^I verify Class Codes on Policy are Valid$")]
    [Then(@"^I verify Class Codes on Policy are Valid$")]
    public async Task VerifyClassCodesOnPolicyAreValidAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BusinessClassificationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyInvalidClassCodeMessageAsync("Absent", "");

    }

    [Given(@"^I complete required billing information for billing$")]
    [When(@"^I complete required billing information for billing$")]
    [Then(@"^I complete required billing information for billing$")]
    public async Task CompleteRequiredBillingInformationForBillingAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickBilling6ED79Async();
        await page.WaitForBillingD1518Async("Exists");
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_263}}"));
        await page.PressBillTypeAsync("Tab");
        await page.PressBillTypeAsync("TAB");
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_266}}"));
        await page.PressPayPlanAsync("Tab");
        await page.PressPayPlanAsync("TAB");
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_270}}"));
        await page.PressEasyPayAsync("CLICK");
        await page.PressEasyPayAsync("Enter");
        await page.PressEasyPayAsync("Tab");
        await page.PressEasyPayAsync("Tab");
        await page.PressEasyPayAsync("TAB");
        await page.PauseAsync(1000);

    }

    [Given(@"^I add notepad comment$")]
    [When(@"^I add notepad comment$")]
    [Then(@"^I add notepad comment$")]
    public async Task AddNotepadCommentAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickNotepadAsync();
        await page.WaitForNotepadHeadingAsync("Exists");
        await page.ClickAddNotesRemarksAsync();
        await page.EnterTextBoxAsync(data.Resolve("Test {B[Product (LOB)]}"));
        await page.ClickNotePadOKAsync();

    }

    [Given(@"^I complete required submission information$")]
    [When(@"^I complete required submission information$")]
    [Then(@"^I complete required submission information$")]
    public async Task CompleteRequiredSubmissionInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForSubmissionAsync("Visible");
        await page.ClickSubmissionAsync();
        await page.WaitForSubmissionHeadingAsync("Exists");
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_281}}"));
        await page.PressIsThisCoverageBoundAsync("Tab");
        await page.PressIsThisCoverageBoundAsync("CLICK");
        await page.PressIsThisCoverageBoundAsync("Tab");
        await page.VerifyOrderAuditAsync("Exists", "");
        await page.EnterOrderAuditAsync(data.Resolve("{{data:order_audit_283}}"));
        await page.PressOrderAuditAsync("Tab");
        await page.VerifySubmissionHeadingAsync("Absent", "");
        await page.PressSubmissionAsync("TAB");
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

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyIsThisCoverageBoundAsync("Exists", "");
        await page.VerifyIsThisCoverageBoundAsync(data.Resolve("{{data:expected_is_this_coverage_bound_value_291}}"), "Value");
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_292}}"));
        await page.PressIsThisCoverageBoundAsync("Tab");
        await page.PressIsThisCoverageBoundAsync("Tab");
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

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyFullTermPremiumAsync(data.Resolve("{{data:expected_full_term_premium_value_324}}"), "value");
        await page.VerifyPremiumWrittenAsync(data.Resolve("{{data:expected_premium_written_value_325}}"), "value");
        await page.VerifyPriorPremiumAsync(data.Resolve("{{data:expected_prior_premium_value_326}}"), "value");
        await page.VerifyPremiumChangeAsync(data.Resolve("{{data:expected_premium_change_value_327}}"), "value");
        await page.EnterTitleAsync(data.Resolve("{{data:title_329}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_330}}"));
        data.Set("SessionId", await page.CaptureResultAsync("value"));

    }

    [Given(@"^I complete forms verification$")]
    [When(@"^I complete forms verification$")]
    [Then(@"^I complete forms verification$")]
    public async Task CompleteFormsVerificationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
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

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickLoggedInUserAsync();
        await page.ClickLogoutAsync();
        await page.PauseAsync(1000);
        await page.VerifyTheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0Async("Exists", "");
        await page.ClickHttpErrorMsgOKAsync();
        await page.WaitForHttpErrorMsgOKAsync("Absent");
        await page.ClickLoggedInUserAsync();
        await page.ClickLogoutAsync();

    }

}
