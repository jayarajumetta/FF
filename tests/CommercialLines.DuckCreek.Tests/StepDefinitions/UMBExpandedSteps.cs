using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "UMB Expanded")]
public sealed class UMBExpandedSteps
{
    private readonly ScenarioContext _scenario;
    public UMBExpandedSteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I enter business client information$")]
    [When(@"^I enter business client information$")]
    [Then(@"^I enter business client information$")]
    public async Task EnterBusinessClientInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("PrimaryPhone_0041", "[0-9]{10}");
        data.GenerateRandom("FEIN_0044", "486[0-9]{6}");
        data.GenerateRandom("InspectionTelephone_0045", "[0-9]{10}");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        // Source step 0044: RANDOM input for FEIN.
        await page.EnterFEINAsync(data.Resolve("{{runtime:FEIN_0044}}"));

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForQuickQuoteAsync("Exists");
        await page.SetQuickQuoteAsync(data.Resolve("{{data:quick_quote_2}}"));
        await page.WaitForUnderwritingInfoAsync("Exists");
        await page.EnterInsuredTypeAsync(data.Resolve("{{data:insured_type_4}}"));
        await page.ClickEntityTypeAsync();
        await page.WaitForBusinessNameAsync("Visible");
        await page.EnterBusinessNameAsync(data.Resolve("{{data:business_name_7}}"));
        await page.EnterEntityTypeAsync(data.Resolve("{{data:entity_type_8}}"));
        // Source step 0041: RANDOM input for Primary Phone.
        await page.EnterPrimaryPhoneAsync(data.Resolve("{{runtime:PrimaryPhone_0041}}"));
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Address17A1FB
        await page.EnterZipCode26D22Async(data.Resolve("{{data:zipcode_11}}"));
        await page.EnterAddress17A1FBAsync(data.Resolve("{{data:address1_12}}"));
        await page.VerifyYearsInBusinessAsync("Exists", "");
        await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_14}}"));
        await page.EnterNameOfInspectionContactAsync(data.Resolve("{{data:name_of_inspection_contact_16}}"));
        // v56 suppressed redundant Tosca keyboard steering: NameOfInspectionContact CLICK
        // v56 suppressed redundant Tosca keyboard steering: NameOfInspectionContact CLICK
        // v56 suppressed redundant Tosca keyboard steering: NameOfInspectionContact Tab
        // Source step 0045: RANDOM input for Inspection Telephone #.
        await page.EnterInspectionTelephoneAsync(data.Resolve("{{runtime:InspectionTelephone_0045}}"));
        await page.EnterInsuredEMailAddressAsync(data.Resolve("{{data:insured_e_mail_address_18}}"));
        // v56 suppressed redundant Tosca keyboard steering: InsuredEMailAddress CLICK
        // v56 suppressed redundant Tosca keyboard steering: InsuredEMailAddress Tab
        await page.EnterWebsiteAddressAsync(data.Resolve("{{data:website_address_19}}"));
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Address2
        await page.VerifyZipCode26D22Async("[0-9]{5}-[0-9]{4}", "Regex:value");
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
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_35}}"));
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_38}}"));
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_42}}"));
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
        data.GenerateRandom("MiddleName_0057", "^[a-z]{1}$");
        data.GenerateRandom("LastName_0057", "^[a-z]{7}$");
        data.GenerateRandom("FirstName_0057", "^[a-z]{4}$");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.EnterIndividualTypeAsync(data.Resolve("{{data:individualtype_45}}"));
        // v56 suppressed redundant Tosca keyboard steering: IndividualType CLICK
        // v56 suppressed redundant Tosca keyboard steering: IndividualType Tab
        await page.WaitForPleaseVerifySSNF738AAsync("Exists");
        // Source step 0057: RANDOM input for MiddleName.
        await page.EnterMiddleNameAsync(data.Resolve("{{runtime:MiddleName_0057}}"));
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets FirstNameC5387
        // Source step 0057: RANDOM input for LastName.
        await page.EnterLastNameAsync(data.Resolve("{{runtime:LastName_0057}}"));
        await page.EnterDateOfBirth338D7Async(data.Resolve("{{data:dateofbirth_50}}"));
        await page.EnterAddress1D319BAsync(data.Resolve("{{data:address1_51}}"));
        await page.EnterCityAsync(data.Resolve("{{data:city_52}}"));
        await page.EnterStateAsync(data.Resolve("{{data:state_53}}"));
        await page.EnterZipCodeA088EAsync(data.Resolve("{{data:zipcode_54}}"));
        await page.EnterGender4973CAsync(data.Resolve("{{data:gender_55}}"));
        // Source step 0057: RANDOM input for FirstName.
        await page.EnterFirstNameC5387Async(data.Resolve("{{runtime:FirstName_0057}}"));
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Gender4973C
        await page.WaitForClientSearch41F28Async("Exists");
        await page.ClickClientSearch41F28Async();
        await page.VerifySearchResultsDuckCreekPolicyFirstCheckboxAsync("Absent", "");
        await page.ClickOKAsync();
        await page.ClickOrderSSN5E031Async();
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets EnterSSNFA186
        await page.PressEnterSSNFA186Async("Enter");
        await page.EnterEnterSSNFA186Async(data.Resolve("{{data:enter_ssn_63}}"));
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
        await page.EnterIsThereAPriorCarrierAsync(data.Resolve("{{data:is_there_a_prior_carrier_83}}"));
        await page.ClickAddPriorCarrierAsync();
        await page.WaitForCarrierAsync("Exists");
        await page.EnterCarrierAsync(data.Resolve("{{data:carrier_86}}"));
        await page.EnterPolicyNumberBA28EAsync(data.Resolve("{{data:policy_number_87}}"));
        await page.EnterPolicyTypeAsync(data.Resolve("{{data:policy_type_88}}"));
        await page.EnterEffectiveDateB557FAsync(data.Resolve("{DATE[][-2y][MM'/'dd'/'yyyy]}"));
        await page.EnterExpirationDate34EACAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.EnterModificationFactorAsync(data.Resolve("{{data:modificationfactor_91}}"));
        await page.EnterTotalPremiumAsync(data.Resolve("{{data:total_premium_92}}"));
        await page.ClickOtherInsuranceHistoryOKAsync();
        await page.WaitForDetail0F8C6Async("Exists");
        await page.ClickLossExperienceAsync();
        await page.WaitForNoKnownLossesAsync("Exists");
        await page.SetNoKnownLossesAsync(data.Resolve("{{data:no_known_losses_97}}"));
        await page.ClickReturnToQuoteAsync();
        await page.EnterTitleAsync(data.Resolve("{{data:title_99}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_100}}"));
        await page.VerifyResultAsync(data.Resolve("{{data:expected_result_value_101}}"), "value");

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
        await page.EnterEffectiveDate95094Async(data.Resolve("{{data:effectivedate_105}}"));
        if (data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
                    await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_106}}"));
        }
        await page.PauseAsync(1000);
        if (data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_108}}"));
        }
        if (data.Condition("'Product (LOB)' != \"WC\""))
        {
                    await page.ClickPrimaryRatingStateAsync();
        }
        if (data.Condition("'Product (LOB)' != \"WC\""))
        {
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets PrimaryRatingState
        }
        if (data.Condition("'Product (LOB)' != \"WC\""))
        {
                    // v56 suppressed duplicate keyboard steering: PrimaryRatingState TAB
        }
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_112}}"));
        if (data.Condition("'Product (LOB)' == \"UMB\""))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_114}}"));
        }
        if (data.Condition("'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"UMB\" || 'Product (LOB)' == \"BAP\""))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_115}}"));
                    await page.PressPrimaryRatingStateAsync("Down");
                    // v56 suppressed redundant Tosca keyboard steering: PrimaryRatingState Enter
                    // v56 suppressed redundant Tosca keyboard steering: PrimaryRatingState Tab
        }
        if (data.Condition("'Product (LOB)' == \"UMB\""))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_117}}"));
        }
        if (data.Condition("'Product (LOB)' == \"UMB\""))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_118}}"));
                    await page.PressPrimaryRatingStateAsync("Down");
                    // v56 suppressed redundant Tosca keyboard steering: PrimaryRatingState Enter
                    // v56 suppressed redundant Tosca keyboard steering: PrimaryRatingState Tab
        }
        await page.PauseAsync(1000);
        if (data.Condition("'Product (LOB)' != \"WC\""))
        {
                    await page.WaitForPrimaryRatingStateAsync("Exists");
        }
        if (data.Condition("'Product (LOB)' != \"WC\""))
        {
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets PrimaryRatingState
        }
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_122}}"));
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
        await page.EnterDescriptionOfSpecifiedOperationAsync("AL UMB StraightThrough {NMONTH}.{NDAY}.{NYEAR} {Time}");
        data.Set("QuoteDescription", await page.CaptureDescriptionOfSpecifiedOperationAsync("value"));

    }

    [Given(@"^I complete required policy covg information$")]
    [When(@"^I complete required policy covg information$")]
    [Then(@"^I complete required policy covg information$")]
    public async Task CompleteRequiredPolicyCovgInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickPolicyCovg35BE4Async();
        await page.WaitForPolicyCovgFF145Async("Visible");
        if (data.Condition("'Umb Limit' != \"$1,000,000\""))
        {
                    await page.EnterUmbrellaLimitAsync(data.Resolve("{{data:umbrella_limit_134}}"));
                    // v56 suppressed redundant Tosca keyboard steering: UmbrellaLimit CLICK
                    // v56 suppressed redundant Tosca keyboard steering: UmbrellaLimit Enter
                    // v56 suppressed redundant Tosca keyboard steering: UmbrellaLimit Tab
        }
        if (data.Condition("'Umb Limit' == \"Over $15M\""))
        {
                    await page.EnterRequestedUmbrellaLimitAsync(data.Resolve("{{data:requested_umbrella_limit_135}}"));
        }
        if (data.Condition("'Excluded Liability' != \"CU2186\""))
        {
                    await page.EnterExcludedLiabilityConfidentialInformationAsync(data.Resolve("{{data:excluded_liability_confidential_information_136}}"));
                    // v56 suppressed redundant Tosca keyboard steering: ExcludedLiabilityConfidentialInformation CLICK
                    // v56 suppressed redundant Tosca keyboard steering: ExcludedLiabilityConfidentialInformation Enter
                    // v56 suppressed redundant Tosca keyboard steering: ExcludedLiabilityConfidentialInformation Tab
        }
        if (data.Condition("'Excluded Liability' != \"CU2186\""))
        {
                    await page.WaitForExcludedLiabilityConfidentialInformationAsync("NotEqual");
        }
        if (data.Condition("'Products - Aggregate Limit' != \"Umbrella Policy Limit\""))
        {
                    await page.EnterProductsCompletedOperationsAggregateLimitAsync(data.Resolve("{{data:products_completed_operations_aggregate_limit_138}}"));
        }
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);

    }

    [Given(@"^I add Commercial Auto Underlying LOB$")]
    [When(@"^I add Commercial Auto Underlying LOB$")]
    [Then(@"^I add Commercial Auto Underlying LOB$")]
    public async Task AddCommercialAutoUnderlyingLOBAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickIncludeCommercialAutoAsync();
        await page.WaitForCommercialAutoAsync("Visible");

    }

    [Given(@"^I add General Liability Underlying LOB$")]
    [When(@"^I add General Liability Underlying LOB$")]
    [Then(@"^I add General Liability Underlying LOB$")]
    public async Task AddGeneralLiabilityUnderlyingLOBAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForPolicyCovgFF145Async("Visible");
        await page.ClickIncludeGeneralLiabilityAsync();
        await page.WaitForGeneralLiabAsync("Visible");

    }

    [Given(@"^I add Businessowners Underlying LOB$")]
    [When(@"^I add Businessowners Underlying LOB$")]
    [Then(@"^I add Businessowners Underlying LOB$")]
    public async Task AddBusinessownersUnderlyingLOBAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForPolicyCovgFF145Async("Visible");
        await page.ClickIncludeBusinessownersAsync();
        await page.WaitForBusinessownersAsync("Visible");

    }

    [Given(@"^I add SFP \- 10 Liability Farm Underlying LOB$")]
    [When(@"^I add SFP \- 10 Liability Farm Underlying LOB$")]
    [Then(@"^I add SFP \- 10 Liability Farm Underlying LOB$")]
    public async Task AddSFP10LiabilityFarmUnderlyingLOBAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForPolicyCovgFF145Async("Visible");
        await page.ClickIncludeSFP10LiabilityFarmAsync();
        await page.WaitForSFP10LiabilityFarmAsync("Visible");

    }

    [Given(@"^I add Commercial Package Policy Liability Underlying LOB$")]
    [When(@"^I add Commercial Package Policy Liability Underlying LOB$")]
    [Then(@"^I add Commercial Package Policy Liability Underlying LOB$")]
    public async Task AddCommercialPackagePolicyLiabilityUnderlyingLOBAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForPolicyCovgFF145Async("Visible");
        await page.ClickIncludeCommercialPackagePolicyLiabilityAsync();
        await page.WaitForCPPLiabilityAsync("Visible");

    }

    [Given(@"^I add Employers Liability Underlying LOB$")]
    [When(@"^I add Employers Liability Underlying LOB$")]
    [Then(@"^I add Employers Liability Underlying LOB$")]
    public async Task AddEmployersLiabilityUnderlyingLOBAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForPolicyCovgFF145Async("Visible");
        await page.ClickIncludeEmployersLiabilityAsync();
        await page.WaitForEmployersLiabAsync("Visible");

    }

    [Given(@"^I add Homeowner's Liability Underlying LOB$")]
    [When(@"^I add Homeowner's Liability Underlying LOB$")]
    [Then(@"^I add Homeowner's Liability Underlying LOB$")]
    public async Task AddHomeownerSLiabilityUnderlyingLOBAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForPolicyCovgFF145Async("Visible");
        await page.ClickIncludeHomeownerSLiabilityAsync();
        await page.WaitForHomeownerSLiabilityAsync("Visible");

    }

    [Given(@"^I add Motorcycle Liability Underlying LOB$")]
    [When(@"^I add Motorcycle Liability Underlying LOB$")]
    [Then(@"^I add Motorcycle Liability Underlying LOB$")]
    public async Task AddMotorcycleLiabilityUnderlyingLOBAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new VehiclesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForPolicyCovgAsync("Visible");
        await page.ClickIncludeMotorcycleLiabilityAsync();
        await page.WaitForMotorcycleLiabilityAsync("Visible");

    }

    [Given(@"^I add Personal Auto Liability Underlying LOB$")]
    [When(@"^I add Personal Auto Liability Underlying LOB$")]
    [Then(@"^I add Personal Auto Liability Underlying LOB$")]
    public async Task AddPersonalAutoLiabilityUnderlyingLOBAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForPolicyCovgFF145Async("Visible");
        await page.ClickIncludePersonalAutoLiabilityAsync();
        await page.WaitForPersonalAutoAsync("Visible");

    }

    [Given(@"^I add Recreational Vehicle Liability Underlying LOB$")]
    [When(@"^I add Recreational Vehicle Liability Underlying LOB$")]
    [Then(@"^I add Recreational Vehicle Liability Underlying LOB$")]
    public async Task AddRecreationalVehicleLiabilityUnderlyingLOBAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new VehiclesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForPolicyCovgAsync("Visible");
        await page.ClickIncludeRecreationalVehicleLiabilityAsync();
        await page.WaitForRecreationalVehicleLiabilityAsync("Visible");

    }

    [Given(@"^I add Rental Owner's Liability Underlying LOB$")]
    [When(@"^I add Rental Owner's Liability Underlying LOB$")]
    [Then(@"^I add Rental Owner's Liability Underlying LOB$")]
    public async Task AddRentalOwnerSLiabilityUnderlyingLOBAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForPolicyCovgFF145Async("Visible");
        await page.ClickIncludeRentalOwnerSLiabilityAsync();
        await page.WaitForRentalOwnersLiabilityAsync("Visible");

    }

    [Given(@"^I add Watercraft Liability Underlying LOB$")]
    [When(@"^I add Watercraft Liability Underlying LOB$")]
    [Then(@"^I add Watercraft Liability Underlying LOB$")]
    public async Task AddWatercraftLiabilityUnderlyingLOBAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForPolicyCovgFF145Async("Visible");
        await page.ClickIncludeWatercraftLiabilityAsync();
        await page.WaitForWatercraftLiabilityAsync("Visible");

    }

    [Given(@"^I complete required location information$")]
    [When(@"^I complete required location information$")]
    [Then(@"^I complete required location information$")]
    public async Task CompleteRequiredLocationInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickLocationE16BCAsync();
        await page.WaitForLocation82D95Async("Visible");
        await page.VerifyZipCodeD2DBAAsync("[0-9]{5}-[0-9]{4}", "Regex:value");
        await page.ClickLocationOKAsync();
        await page.WaitForDetail33F0DAsync("Visible");

    }

    [Given(@"^I complete required commercial auto information$")]
    [When(@"^I complete required commercial auto information$")]
    [Then(@"^I complete required commercial auto information$")]
    public async Task CompleteRequiredCommercialAutoInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickCommercialAutoAsync();
        await page.WaitForCommercialAutoDetailAsync("Visible");
        await page.EnterPolicyNumber461C7Async(data.Resolve("{{data:policy_number_183}}"));
        if (data.Condition("'BAP Policy Number' != \"BAPPOL#\""))
        {
                    await page.ClickImportPolicyDataButton89922Async();
        }
        await page.WaitForEffectiveDate68A1BAsync("NotEqual");
        await page.WaitForStoplightMessageTotalSubjectPremiumAsync("Absent");
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);

    }

    [Given(@"^I complete required general liability information$")]
    [When(@"^I complete required general liability information$")]
    [Then(@"^I complete required general liability information$")]
    public async Task CompleteRequiredGeneralLiabilityInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForGeneralLiabAsync("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets GeneralLiab
        await page.ClickGeneralLiabAsync();
        await page.WaitForGeneralLiabilityAsync("Visible");
        await page.EnterPolicyNumberFDF5CAsync(data.Resolve("{{data:policy_number_193}}"));
        if (data.Condition("'GL Policy Number' == \"GLPOL#\""))
        {
                    await page.EnterEffectiveDateB3600Async(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        }
        await page.WaitForEffectiveDateB3600Async("NotEqual");
        if (data.Condition("'GL Policy Number' == \"GLPOL#\""))
        {
                    await page.EnterExpirationDateB437CAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        }
        if (data.Condition("'GL Policy Number' == \"GLPOL#\""))
        {
                    await page.EnterCGLLimitsAsync(data.Resolve("{{data:cgl_limits_197}}"));
                    // v56 suppressed redundant Tosca keyboard steering: CGLLimits CLICK
                    // v56 suppressed redundant Tosca keyboard steering: CGLLimits Enter
                    // v56 suppressed redundant Tosca keyboard steering: CGLLimits Tab
        }
        if (data.Condition("'GL Policy Number' == \"GLPOL#\""))
        {
                    await page.EnterTotalSubjectPremium19B44Async(data.Resolve("{{data:total_subject_premium_198}}"));
        }
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);

    }

    [Given(@"^I complete required businessowners information$")]
    [When(@"^I complete required businessowners information$")]
    [Then(@"^I complete required businessowners information$")]
    public async Task CompleteRequiredBusinessownersInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickBusinessownersAsync();
        await page.WaitForBusinessownersHeadingAsync("Visible");
        await page.EnterPolicyNumberAsync(data.Resolve("{{data:policy_number_203}}"));
        if (data.Condition("'BOP Policy Number' != \"BOPPOL#\""))
        {
                    await page.ClickImportPolicyDataButtonAsync();
        }
        await page.WaitForEffectiveDateAsync("NotEqual");
        if (data.Condition("'Employers Liability Checkbox' == NULL"))
        {
                    await page.VerifyEmployerSLiabilityCheckBoxAsync("Absent", "");
        }
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);

    }

    [Given(@"^I complete required sfp 10 information$")]
    [When(@"^I complete required sfp 10 information$")]
    [Then(@"^I complete required sfp 10 information$")]
    public async Task CompleteRequiredSfp10InformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickSFP10LiabilityFarmAsync();
        await page.WaitForSFP10LiabilityFarmHeadingAsync("Visible");
        await page.EnterPolicyNumber78B85Async(data.Resolve("{{data:policy_number_211}}"));
        await page.EnterEffectiveDate0E335Async(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.WaitForEffectiveDate0E335Async("NotEqual");
        await page.EnterExpirationDate664A1Async(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        await page.EnterLiabilityLimit56E57Async(data.Resolve("{{data:liability_limit_215}}"));
        // v56 suppressed redundant Tosca keyboard steering: LiabilityLimit56E57 CLICK
        // v56 suppressed redundant Tosca keyboard steering: LiabilityLimit56E57 Enter
        // v56 suppressed redundant Tosca keyboard steering: LiabilityLimit56E57 Tab
        await page.EnterTotalSubjectPremiumAF452Async(data.Resolve("{{data:total_subject_premium_216}}"));

    }

    [Given(@"^I complete required employers liability information$")]
    [When(@"^I complete required employers liability information$")]
    [Then(@"^I complete required employers liability information$")]
    public async Task CompleteRequiredEmployersLiabilityInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForEmployersLiabAsync("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets EmployersLiab
        await page.ClickEmployersLiabAsync();
        await page.EnterPolicyNumber6566FAsync(data.Resolve("{{data:policy_number_220}}"));
        if (data.Condition("'WC Policy Number' != \"WCPOL#\""))
        {
                    await page.ClickImportPolicyDataButtonEF44CAsync();
        }
        await page.WaitForEffectiveDate6CF3DAsync("NotEqual");
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);

    }

    [Given(@"^I complete required homeowners liability information$")]
    [When(@"^I complete required homeowners liability information$")]
    [Then(@"^I complete required homeowners liability information$")]
    public async Task CompleteRequiredHomeownersLiabilityInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForHomeownerSLiabilityAsync("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets HomeownerSLiability
        await page.PressHomeownerSLiabilityAsync("HOME");
        await page.ClickHomeownerSLiabilityAsync();
        await page.EnterPolicyNumberAsync(data.Resolve("{{data:policy_number_228}}"));
        await page.EnterEffectiveDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.WaitForEffectiveDateAsync("NotEqual");
        await page.EnterExpirationDateAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        await page.EnterLiabilityLimitAsync(data.Resolve("{{data:liability_limit_232}}"));

    }

    [Given(@"^I complete required motorcycle liability information$")]
    [When(@"^I complete required motorcycle liability information$")]
    [Then(@"^I complete required motorcycle liability information$")]
    public async Task CompleteRequiredMotorcycleLiabilityInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForMotorcycleLiabilityAsync("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets MotorcycleLiability
        await page.ClickMotorcycleLiabilityAsync();
        await page.EnterPolicyNumber6566FAsync(data.Resolve("{{data:policy_number_236}}"));
        await page.EnterEffectiveDate6CF3DAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.WaitForEffectiveDate6CF3DAsync("NotEqual");
        await page.EnterExpirationDate82561Async(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        if (data.Condition("'Motocycle Libaility Limit' != NULL"))
        {
                    await page.EnterLiabilityLimit1AE2BAsync(data.Resolve("{{data:liability_limit_240}}"));
        }
        await page.EnterTotalSubjectPremiumE8AF0Async(data.Resolve("{{data:total_subject_premium_241}}"));

    }

    [Given(@"^I complete required personal auto liability information$")]
    [When(@"^I complete required personal auto liability information$")]
    [Then(@"^I complete required personal auto liability information$")]
    public async Task CompleteRequiredPersonalAutoLiabilityInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForPersonalAutoAsync("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets PersonalAuto
        await page.ClickPersonalAutoAsync();
        await page.EnterPolicyNumberAsync(data.Resolve("{{data:policy_number_245}}"));
        await page.EnterEffectiveDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.WaitForEffectiveDateAsync("NotEqual");
        await page.EnterExpirationDateAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        await page.EnterLiabilityLimitAsync(data.Resolve("{{data:liability_limit_249}}"));
        if (data.Condition("'PD Limit' != NULL"))
        {
                    await page.EnterPDLimitAsync(data.Resolve("{{data:pd_limit_250}}"));
                    // v56 suppressed redundant Tosca keyboard steering: PDLimit CLICK
                    // v56 suppressed redundant Tosca keyboard steering: PDLimit Enter
                    // v56 suppressed redundant Tosca keyboard steering: PDLimit Tab
        }
        await page.EnterTotalSubjectPremiumAsync(data.Resolve("{{data:total_subject_premium_251}}"));

    }

    [Given(@"^I complete required rental owners liability information$")]
    [When(@"^I complete required rental owners liability information$")]
    [Then(@"^I complete required rental owners liability information$")]
    public async Task CompleteRequiredRentalOwnersLiabilityInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForRentalOwnersLiabilityAsync("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets RentalOwnersLiability
        await page.ClickRentalOwnersLiabilityAsync();
        await page.EnterPolicyNumber6566FAsync(data.Resolve("{{data:policy_number_255}}"));
        await page.EnterEffectiveDate6CF3DAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.WaitForEffectiveDate6CF3DAsync("NotEqual");
        await page.EnterExpirationDate82561Async(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        await page.EnterLiabilityLimit1AE2BAsync(data.Resolve("{{data:liability_limit_259}}"));

    }

    [Given(@"^I complete required cpp information$")]
    [When(@"^I complete required cpp information$")]
    [Then(@"^I complete required cpp information$")]
    public async Task CompleteRequiredCppInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForCPPLiabilityAsync("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets CPPLiability
        await page.ClickCPPLiabilityAsync();
        await page.EnterPolicyNumber6566FAsync(data.Resolve("{{data:policy_number_263}}"));
        if (data.Condition("'CPP Policy Number' ==\"CPPPOL#\""))
        {
                    await page.EnterEffectiveDate6CF3DAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        }
        await page.WaitForEffectiveDate6CF3DAsync("NotEqual");
        if (data.Condition("'CPP Policy Number' ==\"CPPPOL#\""))
        {
                    await page.EnterExpirationDate82561Async(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        }
        if (data.Condition("'CPP Policy Number' ==\"CPPPOL#\""))
        {
                    await page.EnterLiabilityLimit1AE2BAsync(data.Resolve("{{data:liability_limit_267}}"));
                    // v56 suppressed redundant Tosca keyboard steering: LiabilityLimit1AE2B CLICK
                    // v56 suppressed redundant Tosca keyboard steering: LiabilityLimit1AE2B Enter
                    // v56 suppressed redundant Tosca keyboard steering: LiabilityLimit1AE2B Tab
        }
        if (data.Condition("'CPP Policy Number' ==\"CPPPOL#\""))
        {
                    await page.EnterTotalSubjectPremiumE8AF0Async(data.Resolve("{{data:total_subject_premium_268}}"));
        }
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);

    }

    [Given(@"^I complete required watercraft liability information$")]
    [When(@"^I complete required watercraft liability information$")]
    [Then(@"^I complete required watercraft liability information$")]
    public async Task CompleteRequiredWatercraftLiabilityInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForWatercraftLiabilityAsync("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets WatercraftLiability
        await page.ClickWatercraftLiabilityAsync();
        await page.EnterPolicyNumberAsync(data.Resolve("{{data:policy_number_274}}"));
        await page.EnterEffectiveDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.WaitForEffectiveDateAsync("NotEqual");
        await page.EnterExpirationDateAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        await page.EnterLiabilityLimitAsync(data.Resolve("{{data:liability_limit_278}}"));
        await page.EnterTotalSubjectPremiumAsync(data.Resolve("{{data:total_subject_premium_279}}"));

    }

    [Given(@"^I complete required recreational vehicle information$")]
    [When(@"^I complete required recreational vehicle information$")]
    [Then(@"^I complete required recreational vehicle information$")]
    public async Task CompleteRequiredRecreationalVehicleInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new VehiclesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickRecreationalVehicleLiabilityAsync();
        await page.WaitForRecreationalVehicleLiabilityHeadingAsync("Visible");
        await page.EnterPolicyNumberAsync(data.Resolve("{{data:policy_number_282}}"));
        await page.EnterCarrierNameAsync(data.Resolve("{{data:carrier_name_283}}"));
        await page.EnterEffectiveDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.WaitForEffectiveDateAsync("NotEqual");
        await page.EnterExpirationDateAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        await page.EnterLiabilityLimitAsync(data.Resolve("{{data:liability_limit_287}}"));
        if (data.Condition("'PD Limit' != NULL"))
        {
                    await page.EnterPDLimitAsync(data.Resolve("{{data:pd_limit_288}}"));
        }
        await page.EnterTotalSubjectPremiumAsync(data.Resolve("{{data:total_subject_premium_289}}"));

    }

    [Given(@"^I complete required endorsement information$")]
    [When(@"^I complete required endorsement information$")]
    [Then(@"^I complete required endorsement information$")]
    public async Task CompleteRequiredEndorsementInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyEndorsementsHeading8FD33Async("Absent", "");
        await page.WaitForEndorsements9D4A5Async("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Endorsements9D4A5
        await page.PressEndorsements9D4A5Async("END");
        await page.ClickEndorsements9D4A5Async();
        await page.WaitForEndorsementsHeading8FD33Async("Exists");
        await page.VerifyEndorsementsHeading8FD33Async("Absent", "");
        await page.WaitForEndorsements9D4A5Async("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Endorsements9D4A5
        await page.PressEndorsements9D4A5Async("END");
        await page.ClickEndorsements9D4A5Async();
        await page.WaitForEndorsementsHeading8FD33Async("Exists");
        await page.VerifySelectEndorsement0EAB0Async(data.Resolve("{{data:expected_select_endorsement_value_300}}"), "Value");
        await page.EnterSelectEndorsement0EAB0Async(data.Resolve("{{data:select_endorsement_301}}"));
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Enter
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Tab
        await page.ClickAddEndorsement04BD0Async();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.EnterSelectEndorsement0EAB0Async(data.Resolve("{{data:select_endorsement_305}}"));
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Enter
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Tab
        await page.ClickAddEndorsement34EE3Async();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.EnterIFRAMEDuckCreekPolicyDescriptionOfPremisesOrActivitiesAsync(data.Resolve("{{data:iframe_duck_creek_policy_description_of_premises_or_activities_308}}"));
        await page.ClickOKAsync();
        await page.WaitForSelectEndorsement0EAB0Async("Exists");
        await page.PauseAsync(1000);
        await page.VerifyEndorsementsHeading8FD33Async("Absent", "");
        await page.WaitForEndorsements9D4A5Async("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Endorsements9D4A5
        await page.PressEndorsements9D4A5Async("END");
        await page.ClickEndorsements9D4A5Async();
        await page.WaitForEndorsementsHeading8FD33Async("Exists");
        await page.VerifyEndorsementsHeading8FD33Async("Absent", "");
        await page.WaitForEndorsements9D4A5Async("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Endorsements9D4A5
        await page.PressEndorsements9D4A5Async("END");
        await page.ClickEndorsements9D4A5Async();
        await page.WaitForEndorsementsHeading8FD33Async("Exists");
        await page.VerifySelectEndorsement0EAB0Async(data.Resolve("{{data:expected_select_endorsement_value_322}}"), "Value");
        await page.EnterSelectEndorsement0EAB0Async(data.Resolve("{{data:select_endorsement_323}}"));
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Enter
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Tab
        await page.ClickAddEndorsement04BD0Async();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.EnterSelectEndorsement0EAB0Async(data.Resolve("{{data:select_endorsement_327}}"));
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Enter
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Tab
        await page.ClickAddEndorsement34EE3Async();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.WaitForSelectEndorsement0EAB0Async("Exists");
        await page.PauseAsync(1000);
        await page.VerifyEndorsementsHeading8FD33Async("Absent", "");
        await page.WaitForEndorsements9D4A5Async("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Endorsements9D4A5
        await page.PressEndorsements9D4A5Async("END");
        await page.ClickEndorsements9D4A5Async();
        await page.WaitForEndorsementsHeading8FD33Async("Exists");
        await page.VerifySelectEndorsement0EAB0Async(data.Resolve("{{data:expected_select_endorsement_value_338}}"), "Value");
        await page.EnterSelectEndorsement0EAB0Async(data.Resolve("{{data:select_endorsement_339}}"));
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Enter
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Tab
        await page.ClickAddEndorsement04BD0Async();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.EnterSelectEndorsement0EAB0Async(data.Resolve("{{data:select_endorsement_343}}"));
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Enter
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Tab
        await page.ClickAddEndorsement34EE3Async();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.EnterAggregateLimitAsync(data.Resolve("{{data:iframe_duck_creek_policy_aggregate_limit_346}}"));
        await page.ClickOKAsync();
        await page.WaitForSelectEndorsement0EAB0Async("Exists");
        await page.PauseAsync(1000);
        await page.VerifyEndorsementsHeading8FD33Async("Absent", "");
        await page.WaitForEndorsements9D4A5Async("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Endorsements9D4A5
        await page.PressEndorsements9D4A5Async("END");
        await page.ClickEndorsements9D4A5Async();
        await page.WaitForEndorsementsHeading8FD33Async("Exists");
        await page.VerifySelectEndorsement0EAB0Async(data.Resolve("{{data:expected_select_endorsement_value_355}}"), "Value");
        await page.EnterSelectEndorsement0EAB0Async(data.Resolve("{{data:select_endorsement_356}}"));
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Enter
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Tab
        await page.ClickAddEndorsement04BD0Async();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.EnterSelectEndorsement0EAB0Async(data.Resolve("{{data:select_endorsement_360}}"));
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Enter
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Tab
        await page.ClickAddEndorsement34EE3Async();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.EnterIFRAMEDuckCreekPolicyExcludedDriverAsync(data.Resolve("{{data:iframe_duck_creek_policy_excluded_driver_363}}"));
        await page.ClickOKAsync();
        await page.WaitForSelectEndorsement0EAB0Async("Exists");
        await page.PauseAsync(1000);
        await page.VerifyEndorsementsHeading8FD33Async("Absent", "");
        await page.WaitForEndorsements9D4A5Async("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Endorsements9D4A5
        await page.PressEndorsements9D4A5Async("END");
        await page.ClickEndorsements9D4A5Async();
        await page.WaitForEndorsementsHeading8FD33Async("Exists");
        await page.VerifyEndorsementsHeading8FD33Async("Absent", "");
        await page.WaitForEndorsements9D4A5Async("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Endorsements9D4A5
        await page.PressEndorsements9D4A5Async("END");
        await page.ClickEndorsements9D4A5Async();
        await page.WaitForEndorsementsHeading8FD33Async("Exists");
        await page.VerifyEndorsementsHeading8FD33Async("Absent", "");
        await page.WaitForEndorsements9D4A5Async("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Endorsements9D4A5
        await page.PressEndorsements9D4A5Async("END");
        await page.ClickEndorsements9D4A5Async();
        await page.WaitForEndorsementsHeading8FD33Async("Exists");
        await page.VerifySelectEndorsement0EAB0Async(data.Resolve("{{data:expected_select_endorsement_value_382}}"), "Value");
        await page.EnterSelectEndorsement0EAB0Async(data.Resolve("{{data:select_endorsement_383}}"));
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Enter
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Tab
        await page.ClickAddEndorsement04BD0Async();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.EnterSelectEndorsement0EAB0Async(data.Resolve("{{data:select_endorsement_387}}"));
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Enter
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Tab
        await page.ClickAddEndorsement34EE3Async();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.WaitForSelectEndorsement0EAB0Async("Exists");
        await page.PauseAsync(1000);
        await page.VerifyEndorsementsHeading8FD33Async("Absent", "");
        await page.WaitForEndorsements9D4A5Async("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Endorsements9D4A5
        await page.PressEndorsements9D4A5Async("END");
        await page.ClickEndorsements9D4A5Async();
        await page.WaitForEndorsementsHeading8FD33Async("Exists");
        await page.VerifySelectEndorsement0EAB0Async(data.Resolve("{{data:expected_select_endorsement_value_398}}"), "Value");
        await page.EnterSelectEndorsement0EAB0Async(data.Resolve("{{data:select_endorsement_399}}"));
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Enter
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Tab
        await page.ClickAddEndorsement04BD0Async();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.EnterSelectEndorsement0EAB0Async(data.Resolve("{{data:select_endorsement_403}}"));
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Enter
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Tab
        await page.ClickAddEndorsement34EE3Async();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.WaitForSelectEndorsement0EAB0Async("Exists");
        await page.PauseAsync(1000);
        await page.VerifyEndorsementsHeading8FD33Async("Absent", "");
        await page.WaitForEndorsements9D4A5Async("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Endorsements9D4A5
        await page.PressEndorsements9D4A5Async("END");
        await page.ClickEndorsements9D4A5Async();
        await page.WaitForEndorsementsHeading8FD33Async("Exists");
        await page.VerifySelectEndorsement0EAB0Async(data.Resolve("{{data:expected_select_endorsement_value_414}}"), "Value");
        await page.EnterSelectEndorsement0EAB0Async(data.Resolve("{{data:select_endorsement_415}}"));
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Enter
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Tab
        await page.ClickAddEndorsement04BD0Async();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.EnterSelectEndorsement0EAB0Async(data.Resolve("{{data:select_endorsement_419}}"));
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Enter
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Tab
        await page.ClickAddEndorsement34EE3Async();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.EnterIFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedFarmLocationSAsync(data.Resolve("{{data:iframe_duck_creek_policy_address_es_or_description_s_of_designated_farm_location_s_422}}"));
        await page.ClickOKAsync();
        await page.WaitForSelectEndorsement0EAB0Async("Exists");
        await page.PauseAsync(1000);
        await page.VerifyEndorsementsHeading8FD33Async("Absent", "");
        await page.WaitForEndorsements9D4A5Async("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Endorsements9D4A5
        await page.PressEndorsements9D4A5Async("END");
        await page.ClickEndorsements9D4A5Async();
        await page.WaitForEndorsementsHeading8FD33Async("Exists");
        await page.VerifySelectEndorsement0EAB0Async(data.Resolve("{{data:expected_select_endorsement_value_431}}"), "Value");
        await page.EnterSelectEndorsement0EAB0Async(data.Resolve("{{data:select_endorsement_432}}"));
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Enter
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Tab
        await page.ClickAddEndorsement04BD0Async();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.EnterSelectEndorsement63E0EAsync(data.Resolve("{{data:select_endorsement_436}}"));
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement63E0E CLICK
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement63E0E Enter
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement63E0E Tab
        await page.ClickAddEndorsementD15B0Async();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.EnterNameSOrDescriptionSAndDateSOfDesignatedActivitiesOrServicesAsync(data.Resolve("{{data:iframe_duck_creek_policy_name_s_or_description_s_and_date_s_of_designated_activities_or_services_439}}"));
        await page.ClickOKAsync();
        await page.WaitForSelectEndorsement0EAB0Async("Exists");
        await page.PauseAsync(1000);
        await page.VerifyEndorsementsHeading8FD33Async("Absent", "");
        await page.WaitForEndorsements9D4A5Async("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Endorsements9D4A5
        await page.PressEndorsements9D4A5Async("END");
        await page.ClickEndorsements9D4A5Async();
        await page.WaitForEndorsementsHeading8FD33Async("Exists");
        await page.VerifySelectEndorsement0EAB0Async(data.Resolve("{{data:expected_select_endorsement_value_448}}"), "Value");
        await page.EnterSelectEndorsement0EAB0Async(data.Resolve("{{data:select_endorsement_449}}"));
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Enter
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Tab
        await page.ClickAddEndorsement04BD0Async();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.EnterSelectEndorsement0EAB0Async(data.Resolve("{{data:select_endorsement_453}}"));
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Enter
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Tab
        await page.ClickAddEndorsement34EE3Async();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.EnterIFRAMEDuckCreekPolicyNameSOrDescriptionSOfDesignatedAnimalSAsync(data.Resolve("{{data:iframe_duck_creek_policy_name_s_or_description_s_of_designated_animal_s_456}}"));
        await page.ClickOKAsync();
        await page.WaitForSelectEndorsement0EAB0Async("Exists");
        await page.PauseAsync(1000);
        await page.VerifyEndorsementsHeading8FD33Async("Absent", "");
        await page.WaitForEndorsements9D4A5Async("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Endorsements9D4A5
        await page.PressEndorsements9D4A5Async("END");
        await page.ClickEndorsements9D4A5Async();
        await page.WaitForEndorsementsHeading8FD33Async("Exists");
        await page.VerifySelectEndorsement0EAB0Async(data.Resolve("{{data:expected_select_endorsement_value_465}}"), "Value");
        await page.EnterSelectEndorsement0EAB0Async(data.Resolve("{{data:select_endorsement_466}}"));
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Enter
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Tab
        await page.ClickAddEndorsement04BD0Async();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.EnterSelectEndorsement0EAB0Async(data.Resolve("{{data:select_endorsement_470}}"));
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Enter
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Tab
        await page.ClickAddEndorsement34EE3Async();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.EnterIFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedPremisesAsync(data.Resolve("{{data:iframe_duck_creek_policy_address_es_or_description_s_of_designated_premises_473}}"));
        await page.ClickOKAsync();
        await page.WaitForSelectEndorsement0EAB0Async("Exists");
        await page.PauseAsync(1000);
        await page.VerifyEndorsementsHeading8FD33Async("Absent", "");
        await page.WaitForEndorsements9D4A5Async("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Endorsements9D4A5
        await page.PressEndorsements9D4A5Async("END");
        await page.ClickEndorsements9D4A5Async();
        await page.WaitForEndorsementsHeading8FD33Async("Exists");
        await page.VerifyEndorsementsHeading8FD33Async("Absent", "");
        await page.WaitForEndorsements9D4A5Async("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Endorsements9D4A5
        await page.PressEndorsements9D4A5Async("END");
        await page.ClickEndorsements9D4A5Async();
        await page.WaitForEndorsementsHeading8FD33Async("Exists");
        await page.VerifyEndorsementsHeading8FD33Async("Absent", "");
        await page.WaitForEndorsements9D4A5Async("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Endorsements9D4A5
        await page.PressEndorsements9D4A5Async("END");
        await page.ClickEndorsements9D4A5Async();
        await page.WaitForEndorsementsHeading8FD33Async("Exists");
        await page.VerifyEndorsementsHeading8FD33Async("Absent", "");
        await page.WaitForEndorsements9D4A5Async("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Endorsements9D4A5
        await page.PressEndorsements9D4A5Async("END");
        await page.ClickEndorsements9D4A5Async();
        await page.WaitForEndorsementsHeading8FD33Async("Exists");
        await page.VerifyEndorsementsHeading8FD33Async("Absent", "");
        await page.WaitForEndorsements9D4A5Async("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Endorsements9D4A5
        await page.PressEndorsements9D4A5Async("END");
        await page.ClickEndorsements9D4A5Async();
        await page.WaitForEndorsementsHeading8FD33Async("Exists");
        await page.VerifySelectEndorsement0EAB0Async(data.Resolve("{{data:expected_select_endorsement_value_502}}"), "Value");
        await page.EnterSelectEndorsement0EAB0Async(data.Resolve("{{data:select_endorsement_503}}"));
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Enter
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Tab
        await page.ClickAddEndorsement34EE3Async();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.EnterSelectEndorsement0EAB0Async(data.Resolve("{{data:select_endorsement_507}}"));
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Enter
        // v56 suppressed redundant Tosca keyboard steering: SelectEndorsement0EAB0 Tab
        await page.ClickAddEndorsement04BD0Async();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.WaitForSelectEndorsement0EAB0Async("Exists");
        await page.PauseAsync(1000);

    }

    [Given(@"^I complete fill in CU2103 if it exists$")]
    [When(@"^I complete fill in CU2103 if it exists$")]
    [Then(@"^I complete fill in CU2103 if it exists$")]
    public async Task CompleteFillInCU2103IfItExistsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyValueAsync("Exists", "");
        await page.ClickValueAsync();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickIFRAMEDuckCreekPolicyOtherCheckBoxAsync();
        await page.EnterIFRAMEDuckCreekPolicyDescriptionOfOtherAsync(data.Resolve("{{data:iframe_duck_creek_policy_description_of_other_517}}"));
        await page.ClickOKAsync();
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets OK
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);

    }

    [Given(@"^I complete required underwriting question information$")]
    [When(@"^I complete required underwriting question information$")]
    [Then(@"^I complete required underwriting question information$")]
    public async Task CompleteRequiredUnderwritingQuestionInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickUWQuestionsUmbrella9F47EAsync();
        await page.PressUWQuestionsUmbrella9F47EAsync("LongClick");
        await page.WaitForUWQuestionsUmbrellaFF014Async("Exists");
        await page.ClickUpdateAnswersB41BEAsync();
        await page.WaitForHaveYouHadAnyLiabilityLossesInTheLast5YearsOnAnyPrimaryOrExcessPolicyAsync("Equal");
        await page.EnterPleaseProvideWebsiteAddressEsAsync(data.Resolve("{{data:please_provide_website_address_es_525}}"));

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
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_528}}"));
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_531}}"));
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_535}}"));
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
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_546}}"));
        // v56 suppressed redundant Tosca keyboard steering: IsThisCoverageBound CLICK
        // v56 suppressed redundant Tosca keyboard steering: IsThisCoverageBound Tab
        await page.VerifyOrderAuditAsync("Exists", "");
        await page.EnterOrderAuditAsync(data.Resolve("{{data:order_audit_548}}"));
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
        await page.VerifyIsThisCoverageBoundAsync(data.Resolve("{{data:expected_is_this_coverage_bound_value_556}}"), "Value");
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_557}}"));
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
        await page.EnterTitleAsync(data.Resolve("{{data:title_589}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_590}}"));
        data.Set("SessionId", await page.CaptureResultAsync("value"));

    }

    [Given(@"^I complete forms verification UMB$")]
    [When(@"^I complete forms verification UMB$")]
    [Then(@"^I complete forms verification UMB$")]
    public async Task CompleteFormsVerificationUMBAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.EnterSessionIDAsync(data.Resolve("{B[SessionId]}"));
        await page.VerifyStatusCodeAsync(data.Resolve("{{data:expected_statuscode_value_594}}"), "value");
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
