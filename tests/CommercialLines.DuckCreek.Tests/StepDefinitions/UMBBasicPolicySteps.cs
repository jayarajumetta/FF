using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "UMB Basic Policy")]
public sealed class UMBBasicPolicySteps
{
    private readonly ScenarioContext _scenario;
    public UMBBasicPolicySteps(ScenarioContext scenario) => _scenario = scenario;

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
        await page.PressInsuredTypeAsync("Enter");
        await page.PressInsuredTypeAsync("Tab");
        await page.PressInsuredTypeAsync("Tab");
        await page.ClickEntityTypeAsync();
        await page.WaitForBusinessNameAsync("Visible");
        await page.EnterBusinessNameAsync(data.Resolve("{{data:business_name_7}}"));
        await page.PressBusinessNameAsync("Tab");
        await page.EnterEntityTypeAsync(data.Resolve("{{data:entity_type_8}}"));
        await page.PressEntityTypeAsync("Tab");
        // Source step 0041: RANDOM input for Primary Phone.
        await page.EnterPrimaryPhoneAsync(data.Resolve("{{runtime:PrimaryPhone_0041}}"));
        await page.PressAddress17A1FBAsync("TAB");
        await page.EnterZipCode26D22Async(data.Resolve("{{data:zipcode_11}}"));
        await page.PressZipCode26D22Async("Tab");
        await page.PressZipCode26D22Async("Tab");
        await page.EnterAddress17A1FBAsync(data.Resolve("{{data:address1_12}}"));
        await page.PressAddress17A1FBAsync("Tab");
        await page.VerifyYearsInBusinessAsync("Exists", "");
        await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_14}}"));
        await page.PressYearsInBusinessAsync("Tab");
        await page.EnterNameOfInspectionContactAsync(data.Resolve("{{data:name_of_inspection_contact_16}}"));
        await page.PressNameOfInspectionContactAsync("Tab");
        await page.PressNameOfInspectionContactAsync("Tab");
        await page.PressNameOfInspectionContactAsync("CLICK");
        await page.PressNameOfInspectionContactAsync("CLICK");
        await page.PressNameOfInspectionContactAsync("Tab");
        // Source step 0045: RANDOM input for Inspection Telephone #.
        await page.EnterInspectionTelephoneAsync(data.Resolve("{{runtime:InspectionTelephone_0045}}"));
        await page.EnterInsuredEMailAddressAsync(data.Resolve("{{data:insured_e_mail_address_18}}"));
        await page.PressInsuredEMailAddressAsync("Tab");
        await page.PressInsuredEMailAddressAsync("CLICK");
        await page.PressInsuredEMailAddressAsync("Tab");
        await page.EnterWebsiteAddressAsync(data.Resolve("{{data:website_address_19}}"));
        await page.PressWebsiteAddressAsync("Tab");
        await page.PressAddress2Async("TAB");
        await page.PressAddress2Async("Tab");
        await page.VerifyZipCode26D22Async("[0-9]{5}-[0-9]{4}", "Regex:value");
        data.Set("State", data.Resolve("{{data:state}}"));
        data.Set("Product (LOB)", data.Resolve("{{data:product_lob}}"));

    }

    [Given(@"^I add a new Associated Client \\- Business Owner Type \\- Click Add Client$")]
    [When(@"^I add a new Associated Client \\- Business Owner Type \\- Click Add Client$")]
    [Then(@"^I add a new Associated Client \\- Business Owner Type \\- Click Add Client$")]
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
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_35}}"));
        await page.PressBillTypeAsync("Tab");
        await page.PressBillTypeAsync("TAB");
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_38}}"));
        await page.PressPayPlanAsync("Tab");
        await page.PressPayPlanAsync("TAB");
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_42}}"));
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
        data.GenerateRandom("MiddleName_0057", "^[a-z]{1}$");
        data.GenerateRandom("LastName_0057", "^[a-z]{7}$");
        data.GenerateRandom("FirstName_0057", "^[a-z]{4}$");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.EnterIndividualTypeAsync(data.Resolve("{{data:individualtype_45}}"));
        await page.PressIndividualTypeAsync("Tab");
        await page.PressIndividualTypeAsync("CLICK");
        await page.PressIndividualTypeAsync("Tab");
        await page.WaitForPleaseVerifySSNF738AAsync("Exists");
        // Source step 0057: RANDOM input for MiddleName.
        await page.EnterMiddleNameAsync(data.Resolve("{{runtime:MiddleName_0057}}"));
        await page.PressFirstNameC5387Async("TAB");
        await page.PressFirstNameC5387Async("Tab");
        // Source step 0057: RANDOM input for LastName.
        await page.EnterLastNameAsync(data.Resolve("{{runtime:LastName_0057}}"));
        await page.EnterDateOfBirth338D7Async(data.Resolve("{{data:dateofbirth_50}}"));
        await page.PressDateOfBirth338D7Async("Tab");
        await page.EnterAddress1D319BAsync(data.Resolve("{{data:address1_51}}"));
        await page.PressAddress1D319BAsync("Tab");
        await page.PressAddress1D319BAsync("Tab");
        await page.EnterCityAsync(data.Resolve("{{data:city_52}}"));
        await page.PressCityAsync("Tab");
        await page.PressCityAsync("Tab");
        await page.PressCityAsync("Tab");
        await page.EnterStateAsync(data.Resolve("{{data:state_53}}"));
        await page.PressStateAsync("Tab");
        await page.PressStateAsync("Tab");
        await page.PressStateAsync("Tab");
        await page.EnterZipCodeA088EAsync(data.Resolve("{{data:zipcode_54}}"));
        await page.PressZipCodeA088EAsync("Tab");
        await page.PressZipCodeA088EAsync("Tab");
        await page.PressZipCodeA088EAsync("Tab");
        await page.EnterGender4973CAsync(data.Resolve("{{data:gender_55}}"));
        // Source step 0057: RANDOM input for FirstName.
        await page.EnterFirstNameC5387Async(data.Resolve("{{runtime:FirstName_0057}}"));
        await page.PressGender4973CAsync("Tab");
        await page.WaitForClientSearch41F28Async("Exists");
        await page.ClickClientSearch41F28Async();
        await page.VerifySearchResultsDuckCreekPolicyFirstCheckboxAsync("Absent", "");
        await page.ClickOKAsync();
        await page.ClickOrderSSN5E031Async();
        await page.PressEnterSSNFA186Async("TAB");
        await page.PressEnterSSNFA186Async("Enter");
        await page.EnterEnterSSNFA186Async(data.Resolve("{{data:enter_ssn_63}}"));
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
        await page.EnterIsThereAPriorCarrierAsync(data.Resolve("{{data:is_there_a_prior_carrier_83}}"));
        await page.PressIsThereAPriorCarrierAsync("Tab");
        await page.ClickAddPriorCarrierAsync();
        await page.WaitForCarrierAsync("Exists");
        await page.EnterCarrierAsync(data.Resolve("{{data:carrier_86}}"));
        await page.PressCarrierAsync("Tab");
        await page.PressCarrierAsync("Tab");
        await page.EnterPolicyNumberBA28EAsync(data.Resolve("{{data:policy_number_87}}"));
        await page.PressPolicyNumberBA28EAsync("Tab");
        await page.EnterPolicyTypeAsync(data.Resolve("{{data:policy_type_88}}"));
        await page.PressPolicyTypeAsync("Tab");
        await page.EnterEffectiveDateB557FAsync(data.Resolve("{DATE[][-2y][MM'/'dd'/'yyyy]}"));
        await page.PressEffectiveDateB557FAsync("Tab");
        await page.EnterExpirationDate34EACAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.PressExpirationDate34EACAsync("Tab");
        await page.EnterModificationFactorAsync(data.Resolve("{{data:modificationfactor_91}}"));
        await page.PressModificationFactorAsync("Tab");
        await page.EnterTotalPremiumAsync(data.Resolve("{{data:total_premium_92}}"));
        await page.PressTotalPremiumAsync("Tab");
        await page.ClickOtherInsuranceHistoryOKAsync();
        await page.WaitForDetail0F8C6Async("Exists");
        await page.ClickLossExperienceAsync();
        await page.WaitForNoKnownLossesAsync("Exists");
        await page.SetNoKnownLossesAsync(data.Resolve("{{data:no_known_losses_97}}"));
        await page.PressNoKnownLossesAsync("Tab");
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
        await page.PressEffectiveDate95094Async("Tab");
        if (data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
                    await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_106}}"));
                    await page.PressYearsInBusinessAsync("Tab");
        }
        await page.PauseAsync(1000);
        if (data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_108}}"));
                    await page.PressPrimaryRatingStateAsync("Tab");
        }
        if (data.Condition("'Product (LOB)' != \"WC\""))
        {
                    await page.ClickPrimaryRatingStateAsync();
        }
        if (data.Condition("'Product (LOB)' != \"WC\""))
        {
                    await page.PressPrimaryRatingStateAsync("TAB");
        }
        if (data.Condition("'Product (LOB)' != \"WC\""))
        {
                    await page.PressPrimaryRatingStateAsync("TAB");
        }
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_112}}"));
        await page.PressWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync("Tab");
        await page.PressWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync("Tab");
        if (data.Condition("'Product (LOB)' == \"UMB\""))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_114}}"));
                    await page.PressPrimaryRatingStateAsync("Tab");
        }
        if (data.Condition("'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"UMB\" || 'Product (LOB)' == \"BAP\""))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_115}}"));
                    await page.PressPrimaryRatingStateAsync("Down");
                    await page.PressPrimaryRatingStateAsync("Enter");
                    await page.PressPrimaryRatingStateAsync("Tab");
                    await page.PressPrimaryRatingStateAsync("Tab");
        }
        if (data.Condition("'Product (LOB)' == \"UMB\""))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_117}}"));
                    await page.PressPrimaryRatingStateAsync("Tab");
        }
        if (data.Condition("'Product (LOB)' == \"UMB\""))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_118}}"));
                    await page.PressPrimaryRatingStateAsync("Down");
                    await page.PressPrimaryRatingStateAsync("Enter");
                    await page.PressPrimaryRatingStateAsync("Tab");
                    await page.PressPrimaryRatingStateAsync("Tab");
        }
        await page.PauseAsync(1000);
        if (data.Condition("'Product (LOB)' != \"WC\""))
        {
                    await page.WaitForPrimaryRatingStateAsync("Exists");
        }
        if (data.Condition("'Product (LOB)' != \"WC\""))
        {
                    await page.PressPrimaryRatingStateAsync("TAB");
        }
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_122}}"));
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
        await page.EnterDescriptionOfSpecifiedOperationAsync("AL UMB Basic {NMONTH}.{NDAY}.{NYEAR} {Time}");
        await page.PressDescriptionOfSpecifiedOperationAsync("Tab");
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
        if (data.Condition("'Umb Limit' == \"$1,000,000\""))
        {
                    await page.VerifyUmbrellaLimitAsync(data.Resolve("{{data:expected_umbrella_limit_value_134}}"), "Value");
        }
        if (data.Condition("'Excluded Liability' == \"CU2186\""))
        {
                    await page.VerifyExcludedLiabilityConfidentialInformationAsync(data.Resolve("{{data:expected_excluded_liability_confidential_information_value_135}}"), "value");
        }
        if (data.Condition("'Products - Aggregate Limit' == \"Umbrella Policy Limit\""))
        {
                    await page.VerifyProductsCompletedOperationsAggregateLimitAsync(data.Resolve("{{data:expected_products_completed_operations_aggregate_limit_value_136}}"), "value");
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

    [Given(@"^I add SFP \\- 10 Liability Farm Underlying LOB$")]
    [When(@"^I add SFP \\- 10 Liability Farm Underlying LOB$")]
    [Then(@"^I add SFP \\- 10 Liability Farm Underlying LOB$")]
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
        await page.EnterPolicyNumber461C7Async(data.Resolve("{{data:policy_number_163}}"));
        await page.PressPolicyNumber461C7Async("Tab");
        await page.PressPolicyNumber461C7Async("Tab");
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
        await page.PressGeneralLiabAsync("TAB");
        await page.ClickGeneralLiabAsync();
        await page.WaitForGeneralLiabilityAsync("Visible");
        await page.EnterPolicyNumberFDF5CAsync(data.Resolve("{{data:policy_number_173}}"));
        await page.PressPolicyNumberFDF5CAsync("Tab");
        await page.PressPolicyNumberFDF5CAsync("Tab");
        if (data.Condition("'GL Policy Number' == \"GLPOL#\""))
        {
                    await page.EnterEffectiveDateB3600Async(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
                    await page.PressEffectiveDateB3600Async("Tab");
        }
        await page.WaitForEffectiveDateB3600Async("NotEqual");
        if (data.Condition("'GL Policy Number' == \"GLPOL#\""))
        {
                    await page.EnterExpirationDateB437CAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
                    await page.PressExpirationDateB437CAsync("Tab");
        }
        if (data.Condition("'GL Policy Number' == \"GLPOL#\""))
        {
                    await page.EnterCGLLimitsAsync(data.Resolve("{{data:cgl_limits_177}}"));
                    await page.PressCGLLimitsAsync("CLICK");
                    await page.PressCGLLimitsAsync("Enter");
                    await page.PressCGLLimitsAsync("Tab");
        }
        if (data.Condition("'GL Policy Number' == \"GLPOL#\""))
        {
                    await page.EnterTotalSubjectPremium19B44Async(data.Resolve("{{data:total_subject_premium_178}}"));
                    await page.PressTotalSubjectPremium19B44Async("Tab");
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
        await page.EnterPolicyNumberAsync(data.Resolve("{{data:policy_number_183}}"));
        await page.PressPolicyNumberAsync("Tab");
        await page.PressPolicyNumberAsync("Tab");
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

    [Given(@"^I complete required employers liability information$")]
    [When(@"^I complete required employers liability information$")]
    [Then(@"^I complete required employers liability information$")]
    public async Task CompleteRequiredEmployersLiabilityInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForEmployersLiabAsync("Visible");
        await page.PressEmployersLiabAsync("TAB");
        await page.ClickEmployersLiabAsync();
        await page.EnterPolicyNumber6566FAsync(data.Resolve("{{data:policy_number_192}}"));
        await page.PressPolicyNumber6566FAsync("Tab");
        await page.PressPolicyNumber6566FAsync("Tab");
        if (data.Condition("'WC Policy Number' != \"WCPOL#\""))
        {
                    await page.ClickImportPolicyDataButtonEF44CAsync();
        }
        await page.WaitForEffectiveDate6CF3DAsync("NotEqual");
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);

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
        await page.PressCPPLiabilityAsync("TAB");
        await page.ClickCPPLiabilityAsync();
        await page.EnterPolicyNumber6566FAsync(data.Resolve("{{data:policy_number_200}}"));
        await page.PressPolicyNumber6566FAsync("Tab");
        await page.PressPolicyNumber6566FAsync("Tab");
        if (data.Condition("'CPP Policy Number' ==\"CPPPOL#\""))
        {
                    await page.EnterEffectiveDate6CF3DAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
                    await page.PressEffectiveDate6CF3DAsync("Tab");
        }
        await page.WaitForEffectiveDate6CF3DAsync("NotEqual");
        if (data.Condition("'CPP Policy Number' ==\"CPPPOL#\""))
        {
                    await page.EnterExpirationDate82561Async(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
                    await page.PressExpirationDate82561Async("Tab");
        }
        if (data.Condition("'CPP Policy Number' ==\"CPPPOL#\""))
        {
                    await page.EnterLiabilityLimit1AE2BAsync(data.Resolve("{{data:liability_limit_204}}"));
                    await page.PressLiabilityLimit1AE2BAsync("CLICK");
                    await page.PressLiabilityLimit1AE2BAsync("Enter");
                    await page.PressLiabilityLimit1AE2BAsync("Tab");
        }
        if (data.Condition("'CPP Policy Number' ==\"CPPPOL#\""))
        {
                    await page.EnterTotalSubjectPremiumE8AF0Async(data.Resolve("{{data:total_subject_premium_205}}"));
                    await page.PressTotalSubjectPremiumE8AF0Async("Tab");
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
        await page.EnterPolicyNumber78B85Async(data.Resolve("{{data:policy_number_210}}"));
        await page.PressPolicyNumber78B85Async("Tab");
        await page.PressPolicyNumber78B85Async("Tab");
        await page.EnterEffectiveDate0E335Async(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.PressEffectiveDate0E335Async("Tab");
        await page.WaitForEffectiveDate0E335Async("NotEqual");
        await page.EnterExpirationDate664A1Async(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        await page.PressExpirationDate664A1Async("Tab");
        await page.EnterLiabilityLimit56E57Async(data.Resolve("{{data:liability_limit_214}}"));
        await page.PressLiabilityLimit56E57Async("CLICK");
        await page.PressLiabilityLimit56E57Async("Enter");
        await page.PressLiabilityLimit56E57Async("Tab");
        await page.EnterTotalSubjectPremiumAF452Async(data.Resolve("{{data:total_subject_premium_215}}"));
        await page.PressTotalSubjectPremiumAF452Async("Tab");

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
        await page.PressEndorsements9D4A5Async("TAB");
        await page.PressEndorsements9D4A5Async("END");
        await page.ClickEndorsements9D4A5Async();
        await page.WaitForEndorsementsHeading8FD33Async("Exists");

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
        await page.EnterPleaseProvideWebsiteAddressEsAsync(data.Resolve("{{data:please_provide_website_address_es_225}}"));

    }

    [Given(@"^I navigate to Pricing Screen$")]
    [When(@"^I navigate to Pricing Screen$")]
    [Then(@"^I navigate to Pricing Screen$")]
    public async Task NavigateToPricingScreenAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickPricingB84E6Async();
        await page.VerifyWaitonPricingHeadingAndFillOutRequiredFieldsAsync("Exists", "");
        await page.VerifyPremiumAsync(data.Resolve("{{data:expected_premium_value_228}}"), "value");

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
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_231}}"));
        await page.PressBillTypeAsync("Tab");
        await page.PressBillTypeAsync("TAB");
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_234}}"));
        await page.PressPayPlanAsync("Tab");
        await page.PressPayPlanAsync("TAB");
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_238}}"));
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
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_249}}"));
        await page.PressIsThisCoverageBoundAsync("Tab");
        await page.PressIsThisCoverageBoundAsync("CLICK");
        await page.PressIsThisCoverageBoundAsync("Tab");
        await page.VerifyOrderAuditAsync("Exists", "");
        await page.EnterOrderAuditAsync(data.Resolve("{{data:order_audit_251}}"));
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
        await page.VerifyIsThisCoverageBoundAsync(data.Resolve("{{data:expected_is_this_coverage_bound_value_259}}"), "Value");
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_260}}"));
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
        await page.VerifyFullTermPremiumAsync(data.Resolve("{{data:expected_full_term_premium_value_292}}"), "value");
        await page.VerifyPremiumWrittenAsync(data.Resolve("{{data:expected_premium_written_value_293}}"), "value");
        await page.VerifyPriorPremiumAsync(data.Resolve("{{data:expected_prior_premium_value_294}}"), "value");
        await page.VerifyPremiumChangeAsync(data.Resolve("{{data:expected_premium_change_value_295}}"), "value");
        await page.EnterTitleAsync(data.Resolve("{{data:title_297}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_298}}"));
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
        await page.VerifyStatusCodeAsync(data.Resolve("{{data:expected_statuscode_value_302}}"), "value");
        await page.PauseAsync(1000);
        await page.PauseAsync(1000);
        await page.VerifyLoadingMessageAsync("Visible", "");
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
