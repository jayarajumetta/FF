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
        await page.EnterNameOfInspectionContactAsync(data.Resolve("{{data:name_of_inspection_contact_16}}"));
        await page.EnterInspectionTelephoneAsync(data.Resolve("{{runtime:InspectionTelephone_0045}}"));
        await page.EnterInsuredEMailAddressAsync(data.Resolve("{{data:insured_e_mail_address_18}}"));
        await page.EnterWebsiteAddressAsync(data.Resolve("{{data:website_address_19}}"));
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
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_35}}"));
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_38}}"));
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_42}}"));
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

        await page.EnterIndividualTypeAsync(data.Resolve("{{data:individualtype_45}}"));
        await page.WaitForPleaseVerifySSNAsync("Exists");
        await page.EnterMiddleNameAsync(data.Resolve("{{runtime:MiddleName_0057}}"));
        await page.EnterLastNameAsync(data.Resolve("{{runtime:LastName_0057}}"));
        await page.EnterAddAssociatedClientDateOfBirthAsync(data.Resolve("{{data:dateofbirth_50}}"));
        await page.EnterAddressAsync(data.Resolve("{{data:address1_51}}"));
        await page.EnterCityAsync(data.Resolve("{{data:city_52}}"));
        await page.EnterStateAsync(data.Resolve("{{data:state_53}}"));
        await page.EnterNamedInsuredZipCodeAsync(data.Resolve("{{data:zipcode_54}}"));
        await page.EnterGenderAsync(data.Resolve("{{data:gender_55}}"));
        await page.EnterFirstNameAsync(data.Resolve("{{runtime:FirstName_0057}}"));
        await page.WaitForClientSearchAsync("Exists");
        await page.ClickClientSearchAsync();
        await page.VerifySearchResultsDuckCreekPolicyFirstCheckboxAsync("Absent", "");
        await page.ClickOKAsync();
        await page.ClickOrderSSNAsync();
        await page.PressAddAssociatedClientEnterSSNAsync("Enter");
        await page.EnterAddAssociatedClientEnterSSNAsync(data.Resolve("{{data:enter_ssn_63}}"));
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

    [Given(@"^I navigate to Underwriting Info Screen$")]
    [When(@"^I navigate to Underwriting Info Screen$")]
    [Then(@"^I navigate to Underwriting Info Screen$")]
    public async Task NavigateToUnderwritingInfoScreenAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickUnderwritingInfoAsync();
        await page.WaitForIsThereAPriorCarrierAsync("Exists");
        await page.EnterIsThereAPriorCarrierAsync(data.Resolve("{{data:is_there_a_prior_carrier_83}}"));
        await page.ClickAddPriorCarrierAsync();
        await page.WaitForCarrierAsync("Exists");
        await page.EnterCarrierAsync(data.Resolve("{{data:carrier_86}}"));
        await page.EnterGeneralLiabilityPolicyNumberAsync(data.Resolve("{{data:policy_number_87}}"));
        await page.EnterPolicyTypeAsync(data.Resolve("{{data:policy_type_88}}"));
        await page.EnterCommercialAutoEffectiveDateAsync(data.Resolve("{DATE[][-2y][MM'/'dd'/'yyyy]}"));
        await page.EnterGeneralLiabilityExpirationDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.EnterModificationFactorAsync(data.Resolve("{{data:modificationfactor_91}}"));
        await page.EnterTotalPremiumAsync(data.Resolve("{{data:total_premium_92}}"));
        await page.ClickOKAsync();
        await page.WaitForUnderwritingInfoOtherInsuranceHistoryDetailAsync("Exists");
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

        await page.ClickPolicyInfoAsync();
        await page.WaitForPolicyInfoHeaderAsync("Exists");
        await page.PauseAsync(1000);
        await page.EnterPolicyInfoRequiredAndOptionalFieldsEffectiveDateAsync(data.Resolve("{{data:effectivedate_105}}"));
        await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_106}}"));
        await page.PauseAsync(1000);
        await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_108}}"));
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_112}}"));
        await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_114}}"));
        await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_115}}"));
        await page.PressPrimaryRatingStateAsync("Down");
        await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_117}}"));
        await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_118}}"));
        await page.PressPrimaryRatingStateAsync("Down");
        await page.PauseAsync(1000);
        await page.WaitForPrimaryRatingStateAsync("Exists");
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_122}}"));
        await page.VerifyPriorAmericanNationalPolicyAsync("Absent", "");
        await page.VerifyWhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNationalAsync("Absent", "");
        await page.VerifyIsThisPolicyBeingFullyCancelledAsync("Absent", "");
        await page.PauseAsync(1000);
        await page.WaitForPolicyInfoHeaderAsync("Visible");
        await page.WaitForDescriptionOfSpecifiedOperationAsync("Visible");
        await page.EnterDescriptionOfSpecifiedOperationAsync(data.BuildQuoteDescription());
        data.Set("QuoteDescription", await page.CaptureDescriptionOfSpecifiedOperationAsync("value"));

    }

    [Given(@"^I complete required policy covg information$")]
    [When(@"^I complete required policy covg information$")]
    [Then(@"^I complete required policy covg information$")]
    public async Task CompleteRequiredPolicyCovgInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickPolicyCovgerageAsync();
        await page.WaitForPolicyCovgAsync("Visible");
        if (data.Condition("'Umb Limit' != \"$1,000,000\""))
        {
            await page.EnterUmbrellaLimitAsync(data.Resolve("{{data:umbrella_limit_134}}"));
        }
        if (data.Condition("'Umb Limit' == \"Over $15M\""))
        {
            await page.EnterRequestedUmbrellaLimitAsync(data.Resolve("{{data:requested_umbrella_limit_135}}"));
        }
        if (data.Condition("'Excluded Liability' != \"CU2186\""))
        {
            await page.EnterExcludedLiabilityConfidentialInformationAsync(data.Resolve("{{data:excluded_liability_confidential_information_136}}"));
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

        await page.WaitForPolicyCovgAsync("Visible");
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

        await page.WaitForPolicyCovgAsync("Visible");
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

        await page.WaitForPolicyCovgAsync("Visible");
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

        await page.WaitForPolicyCovgAsync("Visible");
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

        await page.WaitForPolicyCovgAsync("Visible");
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

        await page.WaitForPolicyCovgAsync("Visible");
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

        await page.WaitForPolicyCovgAsync("Visible");
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

        await page.WaitForPolicyCovgAsync("Visible");
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

        await page.WaitForPolicyCovgAsync("Visible");
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

        await page.ClickWCNavigationLinksLocationAsync();
        await page.WaitForLocationAsync("Visible");
        await page.VerifyLocationZipCodeAsync("[0-9]{5}-[0-9]{4}", "Regex:value");
        await page.ClickOKAsync();
        await page.WaitForLocationDetailAsync("Visible");

    }

    [Given(@"^I complete required commercial auto information$")]
    [When(@"^I complete required commercial auto information$")]
    [Then(@"^I complete required commercial auto information$")]
    public async Task CompleteRequiredCommercialAutoInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickCommercialAutoAsync();
        await page.WaitForSignsHeadingAsync("Visible");
        await page.EnterCommercialAutoPolicyNumberAsync(data.Resolve("{{data:policy_number_183}}"));
        if (data.Condition("'BAP Policy Number' != \"BAPPOL#\""))
        {
            await page.ClickImportPolicyDataAsync();
        }
        await page.WaitForCommercialAutoEffectiveDateAsync("NotEqual");
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

        await page.WaitForGeneralLiabAsync("Visible");
        await page.ClickGeneralLiabAsync();
        await page.WaitForSignsHeadingAsync("Visible");
        await page.EnterGeneralLiabilityPolicyNumberAsync(data.Resolve("{{data:policy_number_193}}"));
        if (data.Condition("'GL Policy Number' == \"GLPOL#\""))
        {
            await page.EnterCommercialAutoEffectiveDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        }
        await page.WaitForCommercialAutoEffectiveDateAsync("NotEqual");
        if (data.Condition("'GL Policy Number' == \"GLPOL#\""))
        {
            await page.EnterGeneralLiabilityExpirationDateAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        }
        if (data.Condition("'GL Policy Number' == \"GLPOL#\""))
        {
            await page.EnterCGLLimitsAsync(data.Resolve("{{data:cgl_limits_197}}"));
        }
        if (data.Condition("'GL Policy Number' == \"GLPOL#\""))
        {
            await page.EnterGeneralLiabilityTotalSubjectPremiumAsync(data.Resolve("{{data:total_subject_premium_198}}"));
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

        await page.ClickSFP10LiabilityFarmAsync();
        await page.WaitForSignsHeadingAsync("Visible");
        await page.EnterGeneralLiabilityPolicyNumberAsync(data.Resolve("{{data:policy_number_211}}"));
        await page.EnterCommercialAutoEffectiveDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.WaitForCommercialAutoEffectiveDateAsync("NotEqual");
        await page.EnterGeneralLiabilityExpirationDateAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        await page.EnterSFP10LiabilityFarmLiabilityLimitAsync(data.Resolve("{{data:liability_limit_215}}"));
        await page.EnterGeneralLiabilityTotalSubjectPremiumAsync(data.Resolve("{{data:total_subject_premium_216}}"));

    }

    [Given(@"^I complete required employers liability information$")]
    [When(@"^I complete required employers liability information$")]
    [Then(@"^I complete required employers liability information$")]
    public async Task CompleteRequiredEmployersLiabilityInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForEmployersLiabAsync("Visible");
        await page.ClickEmployersLiabAsync();
        await page.EnterBusinessownersPolicyNumberAsync(data.Resolve("{{data:policy_number_220}}"));
        if (data.Condition("'WC Policy Number' != \"WCPOL#\""))
        {
            await page.ClickImportPolicyDataButtonAsync();
        }
        await page.WaitForBusinessownersEffectiveDateAsync("NotEqual");
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

        await page.WaitForHomeownerSLiabilityAsync("Visible");
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

        await page.WaitForMotorcycleLiabilityAsync("Visible");
        await page.ClickMotorcycleLiabilityAsync();
        await page.EnterBusinessownersPolicyNumberAsync(data.Resolve("{{data:policy_number_236}}"));
        await page.EnterBusinessownersEffectiveDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.WaitForBusinessownersEffectiveDateAsync("NotEqual");
        await page.EnterBusinessownersExpirationDateAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        if (data.Condition("'Motocycle Libaility Limit' != NULL"))
        {
            await page.EnterCommercialAutoLiabilityLimitAsync(data.Resolve("{{data:liability_limit_240}}"));
        }
        await page.EnterBusinessownersTotalSubjectPremiumAsync(data.Resolve("{{data:total_subject_premium_241}}"));

    }

    [Given(@"^I complete required personal auto liability information$")]
    [When(@"^I complete required personal auto liability information$")]
    [Then(@"^I complete required personal auto liability information$")]
    public async Task CompleteRequiredPersonalAutoLiabilityInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForPersonalAutoAsync("Visible");
        await page.ClickPersonalAutoAsync();
        await page.EnterPolicyNumberAsync(data.Resolve("{{data:policy_number_245}}"));
        await page.EnterEffectiveDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.WaitForEffectiveDateAsync("NotEqual");
        await page.EnterExpirationDateAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        await page.EnterLiabilityLimitAsync(data.Resolve("{{data:liability_limit_249}}"));
        if (data.Condition("'PD Limit' != NULL"))
        {
            await page.EnterPDLimitAsync(data.Resolve("{{data:pd_limit_250}}"));
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

        await page.WaitForRentalOwnersLiabilityAsync("Visible");
        await page.ClickRentalOwnersLiabilityAsync();
        await page.EnterBusinessownersPolicyNumberAsync(data.Resolve("{{data:policy_number_255}}"));
        await page.EnterBusinessownersEffectiveDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.WaitForBusinessownersEffectiveDateAsync("NotEqual");
        await page.EnterBusinessownersExpirationDateAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        await page.EnterCommercialAutoLiabilityLimitAsync(data.Resolve("{{data:liability_limit_259}}"));

    }

    [Given(@"^I complete required cpp information$")]
    [When(@"^I complete required cpp information$")]
    [Then(@"^I complete required cpp information$")]
    public async Task CompleteRequiredCppInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForCPPLiabilityAsync("Visible");
        await page.ClickCPPLiabilityAsync();
        await page.EnterBusinessownersPolicyNumberAsync(data.Resolve("{{data:policy_number_263}}"));
        if (data.Condition("'CPP Policy Number' ==\"CPPPOL#\""))
        {
            await page.EnterBusinessownersEffectiveDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        }
        await page.WaitForBusinessownersEffectiveDateAsync("NotEqual");
        if (data.Condition("'CPP Policy Number' ==\"CPPPOL#\""))
        {
            await page.EnterBusinessownersExpirationDateAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        }
        if (data.Condition("'CPP Policy Number' ==\"CPPPOL#\""))
        {
            await page.EnterCommercialAutoLiabilityLimitAsync(data.Resolve("{{data:liability_limit_267}}"));
        }
        if (data.Condition("'CPP Policy Number' ==\"CPPPOL#\""))
        {
            await page.EnterBusinessownersTotalSubjectPremiumAsync(data.Resolve("{{data:total_subject_premium_268}}"));
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

        await page.WaitForWatercraftLiabilityAsync("Visible");
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

        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForWCNavigationLinksEndorsementsAsync("Visible");
        await page.PressWCNavigationLinksEndorsementsAsync("END");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForWCNavigationLinksEndorsementsAsync("Visible");
        await page.PressWCNavigationLinksEndorsementsAsync("END");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySelectEndorsementAsync(data.Resolve("{{data:expected_select_endorsement_value_300}}"), "Value");
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_301}}"));
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_305}}"));
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.EnterIFRAMEDuckCreekPolicyDescriptionOfPremisesOrActivitiesAsync(data.Resolve("{{data:iframe_duck_creek_policy_description_of_premises_or_activities_308}}"));
        await page.ClickOKAsync();
        await page.WaitForSelectEndorsementAsync("Exists");
        await page.PauseAsync(1000);
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForWCNavigationLinksEndorsementsAsync("Visible");
        await page.PressWCNavigationLinksEndorsementsAsync("END");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForWCNavigationLinksEndorsementsAsync("Visible");
        await page.PressWCNavigationLinksEndorsementsAsync("END");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySelectEndorsementAsync(data.Resolve("{{data:expected_select_endorsement_value_322}}"), "Value");
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_323}}"));
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_327}}"));
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.WaitForSelectEndorsementAsync("Exists");
        await page.PauseAsync(1000);
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForWCNavigationLinksEndorsementsAsync("Visible");
        await page.PressWCNavigationLinksEndorsementsAsync("END");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySelectEndorsementAsync(data.Resolve("{{data:expected_select_endorsement_value_338}}"), "Value");
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_339}}"));
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_343}}"));
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.EnterAggregateLimitAsync(data.Resolve("{{data:iframe_duck_creek_policy_aggregate_limit_346}}"));
        await page.ClickOKAsync();
        await page.WaitForSelectEndorsementAsync("Exists");
        await page.PauseAsync(1000);
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForWCNavigationLinksEndorsementsAsync("Visible");
        await page.PressWCNavigationLinksEndorsementsAsync("END");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySelectEndorsementAsync(data.Resolve("{{data:expected_select_endorsement_value_355}}"), "Value");
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_356}}"));
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_360}}"));
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.EnterIFRAMEDuckCreekPolicyExcludedDriverAsync(data.Resolve("{{data:iframe_duck_creek_policy_excluded_driver_363}}"));
        await page.ClickOKAsync();
        await page.WaitForSelectEndorsementAsync("Exists");
        await page.PauseAsync(1000);
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForWCNavigationLinksEndorsementsAsync("Visible");
        await page.PressWCNavigationLinksEndorsementsAsync("END");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForWCNavigationLinksEndorsementsAsync("Visible");
        await page.PressWCNavigationLinksEndorsementsAsync("END");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForWCNavigationLinksEndorsementsAsync("Visible");
        await page.PressWCNavigationLinksEndorsementsAsync("END");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySelectEndorsementAsync(data.Resolve("{{data:expected_select_endorsement_value_382}}"), "Value");
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_383}}"));
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_387}}"));
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.WaitForSelectEndorsementAsync("Exists");
        await page.PauseAsync(1000);
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForWCNavigationLinksEndorsementsAsync("Visible");
        await page.PressWCNavigationLinksEndorsementsAsync("END");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySelectEndorsementAsync(data.Resolve("{{data:expected_select_endorsement_value_398}}"), "Value");
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_399}}"));
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_403}}"));
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.WaitForSelectEndorsementAsync("Exists");
        await page.PauseAsync(1000);
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForWCNavigationLinksEndorsementsAsync("Visible");
        await page.PressWCNavigationLinksEndorsementsAsync("END");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySelectEndorsementAsync(data.Resolve("{{data:expected_select_endorsement_value_414}}"), "Value");
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_415}}"));
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_419}}"));
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.EnterIFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedFarmLocationSAsync(data.Resolve("{{data:iframe_duck_creek_policy_address_es_or_description_s_of_designated_farm_location_s_422}}"));
        await page.ClickOKAsync();
        await page.WaitForSelectEndorsementAsync("Exists");
        await page.PauseAsync(1000);
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForWCNavigationLinksEndorsementsAsync("Visible");
        await page.PressWCNavigationLinksEndorsementsAsync("END");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySelectEndorsementAsync(data.Resolve("{{data:expected_select_endorsement_value_431}}"), "Value");
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_432}}"));
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_436}}"));
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.EnterNameSOrDescriptionSAndDateSOfDesignatedActivitiesOrServicesAsync(data.Resolve("{{data:iframe_duck_creek_policy_name_s_or_description_s_and_date_s_of_designated_activities_or_services_439}}"));
        await page.ClickOKAsync();
        await page.WaitForSelectEndorsementAsync("Exists");
        await page.PauseAsync(1000);
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForWCNavigationLinksEndorsementsAsync("Visible");
        await page.PressWCNavigationLinksEndorsementsAsync("END");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySelectEndorsementAsync(data.Resolve("{{data:expected_select_endorsement_value_448}}"), "Value");
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_449}}"));
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_453}}"));
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.EnterIFRAMEDuckCreekPolicyNameSOrDescriptionSOfDesignatedAnimalSAsync(data.Resolve("{{data:iframe_duck_creek_policy_name_s_or_description_s_of_designated_animal_s_456}}"));
        await page.ClickOKAsync();
        await page.WaitForSelectEndorsementAsync("Exists");
        await page.PauseAsync(1000);
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForWCNavigationLinksEndorsementsAsync("Visible");
        await page.PressWCNavigationLinksEndorsementsAsync("END");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySelectEndorsementAsync(data.Resolve("{{data:expected_select_endorsement_value_465}}"), "Value");
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_466}}"));
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_470}}"));
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.EnterIFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedPremisesAsync(data.Resolve("{{data:iframe_duck_creek_policy_address_es_or_description_s_of_designated_premises_473}}"));
        await page.ClickOKAsync();
        await page.WaitForSelectEndorsementAsync("Exists");
        await page.PauseAsync(1000);
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForWCNavigationLinksEndorsementsAsync("Visible");
        await page.PressWCNavigationLinksEndorsementsAsync("END");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForWCNavigationLinksEndorsementsAsync("Visible");
        await page.PressWCNavigationLinksEndorsementsAsync("END");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForWCNavigationLinksEndorsementsAsync("Visible");
        await page.PressWCNavigationLinksEndorsementsAsync("END");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForWCNavigationLinksEndorsementsAsync("Visible");
        await page.PressWCNavigationLinksEndorsementsAsync("END");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForWCNavigationLinksEndorsementsAsync("Visible");
        await page.PressWCNavigationLinksEndorsementsAsync("END");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySelectEndorsementAsync(data.Resolve("{{data:expected_select_endorsement_value_502}}"), "Value");
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_503}}"));
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_507}}"));
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickOKAsync();
        await page.WaitForSelectEndorsementAsync("Exists");
        await page.PauseAsync(1000);

    }

    [Given(@"^I complete fill in CU2103 if it exists$")]
    [When(@"^I complete fill in CU2103 if it exists$")]
    [Then(@"^I complete fill in CU2103 if it exists$")]
    public async Task CompleteFillInCU2103IfItExistsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyValueAsync("Exists", "");
        await page.ClickValueAsync();
        await page.WaitForEndorsementHeadingAsync("Equal");
        await page.ClickIFRAMEDuckCreekPolicyOtherCheckBoxAsync();
        await page.EnterIFRAMEDuckCreekPolicyDescriptionOfOtherAsync(data.Resolve("{{data:iframe_duck_creek_policy_description_of_other_517}}"));
        await page.ClickOKAsync();
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

        await page.ClickUWQuestionsUmbrellaAsync();
        await page.PressUWQuestionsUmbrellaAsync("LongClick");
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickUWQuestionsUmbrellaUpdateAnswersAsync();
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

        await page.ClickNavigationBillingAsync();
        await page.WaitForBillingAsync("Exists");
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_528}}"));
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_531}}"));
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_535}}"));
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
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_546}}"));
        await page.VerifyOrderAuditAsync("Exists", "");
        await page.EnterOrderAuditAsync(data.Resolve("{{data:order_audit_548}}"));
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
