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
                    // v56 suppressed redundant Tosca keyboard steering: InsuredType CLICK
                    // v56 suppressed redundant Tosca keyboard steering: InsuredType Tab
        }
        if (data.Condition("'Insured Type' != NULL"))
        {
                    await page.ClickEntityTypeAsync();
        }
        await page.WaitForBusinessNameAsync("Visible");
        if (data.Condition("'Business Name' != NULL"))
        {
                    await page.EnterBusinessNameAsync(data.Resolve("{{data:business_name_7}}"));
                    // v56 suppressed redundant Tosca keyboard steering: BusinessName CLICK
                    // v56 suppressed redundant Tosca keyboard steering: BusinessName Tab
        }
        if (data.Condition("'Legal Nature' != NULL"))
        {
                    await page.EnterEntityTypeAsync(data.Resolve("{{data:entity_type_8}}"));
                    // v56 suppressed redundant Tosca keyboard steering: EntityType CLICK
                    // v56 suppressed redundant Tosca keyboard steering: EntityType Tab
        }
        if (data.Condition("'Address 1' != NULL"))
        {
                            // Source step 0041: RANDOM input for Primary Phone.
        await page.EnterPrimaryPhoneAsync(data.Resolve("{{runtime:PrimaryPhone_0041}}"));
        await page.EnterAddress17A1FBAsync(data.Resolve("{{data:address1_10}}"));
                    // v56 suppressed redundant Tosca keyboard steering: Address17A1FB CLICK
                    // v56 suppressed redundant Tosca keyboard steering: Address17A1FB Tab
        }
        if (data.Condition("ZipCode != NULL"))
        {
                    await page.EnterZipCode26D22Async(data.Resolve("{{data:zipcode_11}}"));
                    // v56 suppressed redundant Tosca keyboard steering: ZipCode26D22 CLICK
                    // v56 suppressed redundant Tosca keyboard steering: ZipCode26D22 Tab
        }
        await page.VerifyYearsInBusinessAsync("Exists", "");
        await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_13}}"));
        if (data.Condition("'Product (LOB)' != \"UMB\""))
        {
                    await page.EnterNameOfAuditContactAsync(data.Resolve("{{data:name_of_audit_contact_15}}"));
                    // v56 suppressed redundant Tosca keyboard steering: NameOfAuditContact CLICK
                    // v56 suppressed redundant Tosca keyboard steering: NameOfAuditContact Tab
        }
        // Source step 0045: RANDOM input for Audit Telephone #.
        if (data.Condition("'Product (LOB)' != \"UMB\""))
        {
            await page.EnterAuditTelephoneAsync(data.Resolve("{{runtime:AuditTelephone_0045}}"));
        }
        await page.EnterNameOfInspectionContactAsync(data.Resolve("{{data:name_of_inspection_contact_17}}"));
        // v56 suppressed redundant Tosca keyboard steering: NameOfInspectionContact CLICK
        // v56 suppressed redundant Tosca keyboard steering: NameOfInspectionContact Tab
        // Source step 0045: RANDOM input for Inspection Telephone #.
        await page.EnterInspectionTelephoneAsync(data.Resolve("{{runtime:InspectionTelephone_0045}}"));
        await page.EnterInsuredEMailAddressAsync(data.Resolve("{{data:insured_e_mail_address_19}}"));
        // v56 suppressed redundant Tosca keyboard steering: InsuredEMailAddress CLICK
        // v56 suppressed redundant Tosca keyboard steering: InsuredEMailAddress Tab
        await page.EnterWebsiteAddressAsync(data.Resolve("{{data:website_address_20}}"));
        // v56 suppressed redundant Tosca keyboard steering: WebsiteAddress CLICK
        // v56 suppressed redundant Tosca keyboard steering: WebsiteAddress Tab
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
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets AddClient
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
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_35}}"));
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_39}}"));
        // v56 suppressed redundant Tosca keyboard steering: EasyPay CLICK
        // v56 suppressed redundant Tosca keyboard steering: EasyPay Enter
        // v56 suppressed redundant Tosca keyboard steering: EasyPay Tab
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
        // v56 suppressed redundant Tosca keyboard steering: IndividualType CLICK
        // v56 suppressed redundant Tosca keyboard steering: IndividualType Tab
        await page.WaitForPleaseVerifySSNF738AAsync("Exists");
        // Source step 0056: RANDOM input for MiddleName.
        await page.EnterMiddleNameAsync(data.Resolve("{{runtime:MiddleName_0056}}"));
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets FirstNameC5387
        // Source step 0056: RANDOM input for LastName.
        await page.EnterLastNameAsync(data.Resolve("{{runtime:LastName_0056}}"));
        await page.EnterDateOfBirth338D7Async(data.Resolve("{{data:dateofbirth_47}}"));
        await page.EnterAddress1D319BAsync(data.Resolve("{{data:address1_48}}"));
        await page.EnterCityAsync(data.Resolve("{{data:city_49}}"));
        await page.EnterStateAsync(data.Resolve("{{data:state_50}}"));
        await page.EnterZipCodeA088EAsync(data.Resolve("{{data:zipcode_51}}"));
        await page.EnterGender4973CAsync(data.Resolve("{{data:gender_52}}"));
        await page.WaitForClientSearch41F28Async("Exists");
        await page.ClickClientSearch41F28Async();
        // Source RANDOM FirstName entered after Client Search per Tosca source step.
        await page.EnterFirstName55A0BAsync(data.Resolve("{{runtime:FirstName_0056}}"));
        await page.VerifySearchResultsDuckCreekPolicyFirstCheckboxAsync("Absent", "");
        await page.ClickOKAsync();
        await page.ClickOrderSSN5E031Async();
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets EnterSSNFA186
        await page.PressEnterSSNFA186Async("Enter");
        await page.EnterEnterSSNFA186Async(data.Resolve("{{data:enter_ssn_60}}"));
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
        await page.WaitForCarrierAsync("Exists");
        await page.EnterCarrierAsync(data.Resolve("{{data:carrier_82}}"));
        await page.EnterPolicyNumberBA28EAsync(data.Resolve("{{data:policy_number_83}}"));
        await page.EnterPolicyTypeAsync(data.Resolve("{{data:policy_type_84}}"));
        await page.EnterEffectiveDateB557FAsync(data.Resolve("{DATE[][-2y][MM'/'dd'/'yyyy]}"));
        await page.EnterExpirationDate34EACAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.EnterModificationFactorAsync(data.Resolve("{{data:modificationfactor_87}}"));
        await page.EnterTotalPremiumAsync(data.Resolve("{{data:total_premium_88}}"));
        await page.ClickOtherInsuranceHistoryOKAsync();
        await page.WaitForDetail0F8C6Async("Exists");
        await page.ClickLossExperienceAsync();
        await page.WaitForNoKnownLossesAsync("Exists");
        await page.SetNoKnownLossesAsync(data.Resolve("{{data:no_known_losses_93}}"));
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
        await page.PauseAsync(1000);
        if (data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_103}}"));
        }
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_104}}"));
        await page.PauseAsync(1000);
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_108}}"));
        // v56 suppressed redundant Tosca keyboard steering: WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days CLICK
        // v56 suppressed redundant Tosca keyboard steering: WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days Enter
        // v56 suppressed redundant Tosca keyboard steering: WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days Tab
        await page.VerifyPriorAmericanNationalPolicyAsync("Absent", "");
        await page.VerifyWhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNationalAsync("Absent", "");
        await page.VerifyIsThisPolicyBeingFullyCancelledAsync("Absent", "");
        await page.PauseAsync(1000);
        await page.WaitForPolicyInfoHeaderAsync("Visible");
        await page.WaitForDescriptionOfSpecifiedOperationAsync("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets DescriptionOfSpecifiedOperation
        await page.EnterDescriptionOfSpecifiedOperationAsync("AL WC ST {NMONTH}.{NDAY}.{NYEAR} {Time}");
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
        // v56 suppressed redundant Tosca keyboard steering: HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage CLICK
        // v56 suppressed redundant Tosca keyboard steering: HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage Enter
        // v56 suppressed redundant Tosca keyboard steering: HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage Tab

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
        }
        if (data.Condition("'Small Deductible' != NULL"))
        {
                    await page.EnterSmallDeductibleAsync(data.Resolve("{{data:small_deductible_134}}"));
        }
        if (data.Condition("'Company Name' != NULL"))
        {
                    await page.EnterCompanyNameAsync(data.Resolve("{{data:company_name_135}}"));
                    // v56 suppressed redundant Tosca keyboard steering: CompanyName CLICK
                    // v56 suppressed redundant Tosca keyboard steering: CompanyName Tab
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
        }
        if (data.Condition("'Experience Mod Type' != NULL"))
        {
                    await page.EnterExperienceModTypeAsync(data.Resolve("{{data:experience_mod_type_140}}"));
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
        }
        if (data.Condition("'Class Code 1' != NULL"))
        {
                    await page.EnterSelectClassCodeAsync(data.Resolve("{{data:class_code_frame_class_code_window_select_class_code_150}}"));
                    // v56 suppressed redundant Tosca keyboard steering: SelectClassCode CLICK
                    // v56 suppressed redundant Tosca keyboard steering: SelectClassCode Enter
                    // v56 suppressed redundant Tosca keyboard steering: SelectClassCode Tab
                    // v56 suppressed redundant Tosca keyboard steering: SelectClassCode CLICK
                    // v56 suppressed redundant Tosca keyboard steering: SelectClassCode Tab
        }
        // v56 suppressed redundant Tosca keyboard steering: SelectClassCode TAB
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
                    // v56 suppressed redundant Tosca keyboard steering: TotalPayrollEstimated CLICK
                    // v56 suppressed redundant Tosca keyboard steering: TotalPayrollEstimated Tab
        }
        if (data.Condition("'Waiver of Subrogation Exposure' != NULL"))
        {
                    await page.EnterWaiverOfSubrogationExposureAsync(data.Resolve("{{data:class_code_frame_class_code_window_waiver_of_subrogation_exposure_157}}"));
                    // v56 suppressed redundant Tosca keyboard steering: WaiverOfSubrogationExposure CLICK
                    // v56 suppressed redundant Tosca keyboard steering: WaiverOfSubrogationExposure Tab
        }
        await page.EnterNumberOfPartTimeEmployeesAsync(data.Resolve("{{data:class_code_frame_class_code_window_number_of_part_time_employees_158}}"));
        // v56 suppressed redundant Tosca keyboard steering: NumberOfPartTimeEmployees CLICK
        // v56 suppressed redundant Tosca keyboard steering: NumberOfPartTimeEmployees Tab
        await page.EnterNumberOfFullTimeEmployeesAsync(data.Resolve("{{data:class_code_frame_class_code_window_number_of_full_time_employees_159}}"));
        // v56 suppressed redundant Tosca keyboard steering: NumberOfFullTimeEmployees CLICK
        // v56 suppressed redundant Tosca keyboard steering: NumberOfFullTimeEmployees Tab
        await page.ClickOKDetailsAsync();
        await page.WaitForClassCodeFrameAsync("Absent");
        await page.WaitForAddClassCodeAsync("Exists");
        await page.ClickAddClassCodeAsync();
        await page.VerifyOKClassCodeAsync("Absent", "");
        await page.WaitForSearchValue53135Async("Exists");
        if (data.Condition("'Class Code 2' != NULL"))
        {
                    await page.EnterSearchValue53135Async(data.Resolve("{{data:class_code_frame_class_code_window_searchvalue_166}}"));
        }
        if (data.Condition("'Class Code 2' != NULL"))
        {
                    await page.EnterSelectClassCodeAsync(data.Resolve("{{data:class_code_frame_class_code_window_select_class_code_168}}"));
                    // v56 suppressed redundant Tosca keyboard steering: SelectClassCode CLICK
                    // v56 suppressed redundant Tosca keyboard steering: SelectClassCode Enter
                    // v56 suppressed redundant Tosca keyboard steering: SelectClassCode Tab
                    // v56 suppressed redundant Tosca keyboard steering: SelectClassCode CLICK
                    // v56 suppressed redundant Tosca keyboard steering: SelectClassCode Tab
        }
        // v56 suppressed redundant Tosca keyboard steering: SelectClassCode TAB
        await page.PauseAsync(1000);
        if (data.Condition("'Class Code 2' != NULL"))
        {
                    await page.VerifySelectClassCodeAsync(data.Resolve("{{data:expected_class_code_frame_class_code_window_select_class_code_value_171}}"), "value");
        }
        await page.WaitForOKClassCodeAsync("Exists");
        await page.ClickOKClassCodeAsync();
        await page.EnterTotalPayrollEstimatedAsync(data.Resolve("{{data:class_code_frame_class_code_window_total_payroll_estimated_174}}"));
        // v56 suppressed redundant Tosca keyboard steering: TotalPayrollEstimated CLICK
        // v56 suppressed redundant Tosca keyboard steering: TotalPayrollEstimated Tab
        if (data.Condition("'Waiver of Subrogation Exposure' != NULL"))
        {
                    await page.EnterWaiverOfSubrogationExposureAsync(data.Resolve("{{data:class_code_frame_class_code_window_waiver_of_subrogation_exposure_175}}"));
        }
        await page.EnterNumberOfPartTimeEmployeesAsync(data.Resolve("{{data:class_code_frame_class_code_window_number_of_part_time_employees_176}}"));
        // v56 suppressed redundant Tosca keyboard steering: NumberOfPartTimeEmployees CLICK
        // v56 suppressed redundant Tosca keyboard steering: NumberOfPartTimeEmployees Tab
        await page.EnterNumberOfFullTimeEmployeesAsync(data.Resolve("{{data:class_code_frame_class_code_window_number_of_full_time_employees_177}}"));
        // v56 suppressed redundant Tosca keyboard steering: NumberOfFullTimeEmployees CLICK
        // v56 suppressed redundant Tosca keyboard steering: NumberOfFullTimeEmployees Tab
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
        await page.ClickLocationIDAsync();
        await page.EnterLocationIDAsync(data.Resolve("{{data:location_assignment_entity_location_locationid_198}}"));
        await page.VerifyLocationIDAsync(data.Resolve("{{data:expected_location_assignment_entity_location_locationid_value_199}}"), "Value");
        await page.ClickSelectNAICSCodeAsync();
        await page.WaitForNAICSCodeSearchValueAsync("Exists");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets NAICSCodeSearchValue
        await page.EnterNAICSCodeSearchValueAsync(data.Resolve("{{data:location_assignment_entity_location_naicscodesearchvalue_203}}"));
        // v56 suppressed redundant Tosca keyboard steering: NAICSCodeSearchValue CLICK
        // v56 suppressed redundant Tosca keyboard steering: NAICSCodeSearchValue Tab
        await page.ClickNAICSCodeSearchValueAsync();
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets SelectAppropriateCode
        await page.EnterSelectAppropriateCodeAsync(data.Resolve("{{data:location_assignment_entity_location_select_appropriate_code_206}}"));
        // v56 suppressed redundant Tosca keyboard steering: SelectAppropriateCode CLICK
        // v56 suppressed redundant Tosca keyboard steering: SelectAppropriateCode Tab
        // v56 suppressed redundant Tosca keyboard steering: SelectAppropriateCode Click
        // v56 suppressed redundant Tosca keyboard steering: SelectAppropriateCode Tab
        await page.VerifySelectAppropriateCodeAsync(data.Resolve("{{data:expected_location_assignment_entity_location_select_appropriate_code_value_207}}"), "value");
        await page.WaitForLocationAssignmentAsync("Absent");
        await page.EnterSelectAppropriateCodeAsync(data.Resolve("{{data:location_assignment_entity_location_select_appropriate_code_209}}"));
        // v56 suppressed redundant Tosca keyboard steering: SelectAppropriateCode CLICK
        // v56 suppressed redundant Tosca keyboard steering: SelectAppropriateCode Tab
        // v56 suppressed redundant Tosca keyboard steering: SelectAppropriateCode Click
        // v56 suppressed redundant Tosca keyboard steering: SelectAppropriateCode Tab
        await page.VerifySelectAppropriateCodeAsync(data.Resolve("{{data:expected_location_assignment_entity_location_select_appropriate_code_value_210}}"), "value");
        await page.WaitForLocationAssignmentAsync("Absent");
        await page.VerifySelectAppropriateCodeAsync(data.Resolve("{{data:expected_location_assignment_entity_location_select_appropriate_code_value_212}}"), "value");
        await page.ClickOKFirstAsync();
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets OKFirst
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
                    // v56 suppressed redundant Tosca keyboard steering: AreThereAnyOfficersThatShouldBeExcluded CLICK
                    // v56 suppressed redundant Tosca keyboard steering: AreThereAnyOfficersThatShouldBeExcluded Tab
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
        }
        if (data.Condition("City != NULL"))
        {
                    await page.EnterCityAsync(data.Resolve("{{data:city_224}}"));
        }
        if (data.Condition("State != NULL"))
        {
                    await page.EnterState89468Async(data.Resolve("{{data:state_225}}"));
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
                    await page.EnterOthersB1A1BAsync(data.Resolve("{{data:others_234}}"));
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
                    await page.EnterOthers9E098Async(data.Resolve("{{data:others_246}}"));
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
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets UpdateAnswers6FF76
        await page.ClickUpdateAnswers6FF76Async();
        await page.WaitForArePhysicalsRequiredAfterOffersOfEmploymentAreMadeAsync("NotEqual");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets ListAllPoliciesWithAmericanNational
        await page.EnterListAllPoliciesWithAmericanNationalAsync(data.Resolve("{{data:list_all_policies_with_american_national_254}}"));
        // v56 suppressed redundant Tosca keyboard steering: ListAllPoliciesWithAmericanNational CLICK
        // v56 suppressed redundant Tosca keyboard steering: ListAllPoliciesWithAmericanNational CLICK
        // v56 suppressed redundant Tosca keyboard steering: ListAllPoliciesWithAmericanNational Tab

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
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_266}}"));
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_270}}"));
        // v56 suppressed redundant Tosca keyboard steering: EasyPay CLICK
        // v56 suppressed redundant Tosca keyboard steering: EasyPay Enter
        // v56 suppressed redundant Tosca keyboard steering: EasyPay Tab
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
        // v56 suppressed redundant Tosca keyboard steering: IsThisCoverageBound CLICK
        // v56 suppressed redundant Tosca keyboard steering: IsThisCoverageBound Tab
        await page.VerifyOrderAuditAsync("Exists", "");
        await page.EnterOrderAuditAsync(data.Resolve("{{data:order_audit_283}}"));
        await page.VerifySubmissionHeadingAsync("Absent", "");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Submission
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
