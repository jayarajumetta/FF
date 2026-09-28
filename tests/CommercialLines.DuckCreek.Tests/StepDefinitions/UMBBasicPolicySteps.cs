using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;
using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "UMB Basic Policy")]
public sealed class UMBBasicPolicySteps
{
    private readonly ScenarioContext _scenario;
    public UMBBasicPolicySteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I start a new quote$")]
    [When(@"^I start a new quote$")]
    [Then(@"^I start a new quote$")]
    public async Task StartANewQuoteAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickNewQuoteAsync();
        await page.EnterEffectiveDateAsync(data.Resolve("{{data:effectivedate_105}}"));
        await page.EnterProductAsync(data.Resolve("{{data:product_14}}"));
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
        data.GenerateRandom("FEIN_0044", "486[0-9]{6}");
        data.GenerateRandom("InspectionTelephone_0045", "[0-9]{10}");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForQuickQuoteAsync("Exists");
        await page.SetQuickQuoteAsync(data.Resolve("{{data:quick_quote_2}}"));
        await page.WaitForUnderwritingInfoAsync("Exists");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterInsuredTypeSequentiallyAsync(data.Resolve("{{data:insured_type_4}}")),
            () => page.PressInsuredTypeAsync("Tab"),
            () => page.CaptureInsuredTypeAsync("value"),
            "InsuredType");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterEntityTypeSequentiallyAsync(data.Resolve("{{data:entity_type_8}}")),
            () => page.PressEntityTypeAsync("Tab"),
            () => page.CaptureEntityTypeAsync("value"),
            "EntityType");
        await page.WaitForBusinessNameAsync("Visible");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterBusinessNameSequentiallyAsync(data.Resolve("{{data:business_name_7}}")),
            () => page.PressBusinessNameAsync("Tab"),
            () => page.CaptureBusinessNameAsync("value"),
            "BusinessName");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterPrimaryPhoneSequentiallyAsync(data.Resolve("{{runtime:PrimaryPhone_0041}}")),
            () => page.PressPrimaryPhoneAsync("Tab"),
            () => page.CapturePrimaryPhoneAsync("value"),
            "PrimaryPhone");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterNamedInsuredZipCodeSequentiallyAsync(data.Resolve("{{data:zipcode_11}}")),
            () => page.PressNamedInsuredZipCodeAsync("Tab"),
            () => page.CaptureNamedInsuredZipCodeAsync("value"),
            "NamedInsuredZipCode");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterAddressSequentiallyAsync(data.Resolve("{{data:address1_12}}")),
            () => page.PressAddressAsync("Tab"),
            () => page.CaptureAddressAsync("value"),
            "Address");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterFEINSequentiallyAsync(data.Resolve("{{runtime:FEIN_0044}}")),
            () => page.PressFEINAsync("Tab"),
            () => page.CaptureFEINAsync("value"),
            "FEIN");

        if (await page.HasYearsInBusinessAsync())
        {
            await page.VerifyYearsInBusinessAsync("Exists", "");
            await EnterWithTabAndNonEmptyRetryAsync(
                () => page.EnterYearsInBusinessSequentiallyAsync(data.Resolve("{{data:years_in_business_14}}")),
                () => page.PressYearsInBusinessAsync("Tab"),
                () => page.CaptureYearsInBusinessAsync("value"),
                "YearsInBusiness");
        }
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterNameOfInspectionContactSequentiallyAsync(data.Resolve("{{data:name_of_inspection_contact_16}}")),
            () => page.PressNameOfInspectionContactAsync("Tab"),
            () => page.CaptureNameOfInspectionContactAsync("value"),
            "NameOfInspectionContact");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterInspectionTelephoneSequentiallyAsync(data.Resolve("{{runtime:InspectionTelephone_0045}}")),
            () => page.PressInspectionTelephoneAsync("Tab"),
            () => page.CaptureInspectionTelephoneAsync("value"),
            "InspectionTelephone");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterInsuredEMailAddressSequentiallyAsync(data.Resolve("{{data:insured_e_mail_address_18}}")),
            () => page.PressInsuredEMailAddressAsync("Tab"),
            () => page.CaptureInsuredEMailAddressAsync("value"),
            "InsuredEMailAddress");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterWebsiteAddressSequentiallyAsync(data.Resolve("{{data:website_address_19}}")),
            () => page.PressWebsiteAddressAsync("Tab"),
            () => page.CaptureWebsiteAddressAsync("value"),
            "WebsiteAddress");
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
        await page.VerifyIndividualTypeAsync("Exists", "");

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
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterFirstNameSequentiallyAsync(data.Resolve("{{runtime:FirstName_0057}}")),
            () => page.PressFirstNameAsync("Tab"),
            () => page.CaptureFirstNameAsync("value"),
            "FirstName");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterMiddleNameSequentiallyAsync(data.Resolve("{{runtime:MiddleName_0057}}")),
            () => page.PressMiddleNameAsync("Tab"),
            () => page.CaptureMiddleNameAsync("value"),
            "MiddleName");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterLastNameSequentiallyAsync(data.Resolve("{{runtime:LastName_0057}}")),
            () => page.PressLastNameAsync("Tab"),
            () => page.CaptureLastNameAsync("value"),
            "LastName");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterAddAssociatedClientDateOfBirthSequentiallyAsync(data.Resolve("{{data:dateofbirth_50}}")),
            () => page.PressAddAssociatedClientDateOfBirthAsync("Tab"),
            () => page.CaptureAddAssociatedClientDateOfBirthAsync("value"),
            "DateOfBirth");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterAddressSequentiallyAsync(data.Resolve("{{data:address1_51}}")),
            () => page.PressAddressAsync("Tab"),
            () => page.CaptureAddressAsync("value"),
            "Address");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterCitySequentiallyAsync(data.Resolve("{{data:city_52}}")),
            () => page.PressCityAsync("Tab"),
            () => page.CaptureCityAsync("value"),
            "City");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterStateSequentiallyAsync(data.Resolve("{{data:state_53}}")),
            () => page.PressStateAsync("Tab"),
            () => page.CaptureStateAsync("value"),
            "State");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterNamedInsuredZipCodeSequentiallyAsync(data.Resolve("{{data:zipcode_54}}")),
            () => page.PressNamedInsuredZipCodeAsync("Tab"),
            () => page.CaptureNamedInsuredZipCodeAsync("value"),
            "NamedInsuredZipCode");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterGenderSequentiallyAsync(data.Resolve("{{data:gender_55}}")),
            () => page.PressGenderAsync("Tab"),
            () => page.CaptureGenderAsync("value"),
            "Gender");
        await page.WaitForClientSearchAsync("Exists");
        await page.ClickClientSearchAsync();
        await page.VerifySearchResultsDuckCreekPolicyFirstCheckboxAsync("Absent", "");
        await page.ClickOKAsync();
        await page.ClickOrderSSNAsync();
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterAddAssociatedClientEnterSSNAsync(data.Resolve("{{data:enter_ssn_63}}")),
            () => page.PressAddAssociatedClientEnterSSNAsync("Tab"),
            () => page.CaptureAddAssociatedClientEnterSSNAsync("value"),
            "AddAssociatedClientEnterSSN");
        await page.PauseAsync(4000);
        if (await page.HasVerifyAsync())
        {
            await page.ClickVerifyAsync();
            await page.WaitForPleaseVerifySSNAsync("Absent");
            await page.ClickCompleteAsync();
        }
        else
        {
            await page.ClickCompleteAsync();
        }
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
        await page.EnterIsThereAPriorCarrierAsync("Yes");
        await page.ClickAddPriorCarrierAsync();
        await page.WaitForCarrierAsync("Exists");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterCarrierSequentiallyAsync(data.Resolve("{{data:carrier_86}}")),
            () => page.PressCarrierAsync("Tab"),
            () => page.CaptureCarrierAsync("value"),
            "Carrier");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterGeneralLiabilityPolicyNumberSequentiallyAsync(data.Resolve("{{data:policy_number_87}}")),
            () => page.PressGeneralLiabilityPolicyNumberAsync("Tab"),
            () => page.CaptureGeneralLiabilityPolicyNumberAsync("value"),
            "GeneralLiabilityPolicyNumber");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterPolicyTypeSequentiallyAsync(data.Resolve("{{data:policy_type_88}}")),
            () => page.PressPolicyTypeAsync("Tab"),
            () => page.CapturePolicyTypeAsync("value"),
            "PolicyType");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterCommercialAutoEffectiveDateSequentiallyAsync(data.Resolve("{DATE[][-2y][MM'/'dd'/'yyyy]}")),
            () => page.PressCommercialAutoEffectiveDateAsync("Tab"),
            () => page.CaptureCommercialAutoEffectiveDateAsync("value"),
            "CommercialAutoEffectiveDate");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterGeneralLiabilityExpirationDateSequentiallyAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}")),
            () => page.PressGeneralLiabilityExpirationDateAsync("Tab"),
            () => page.CaptureGeneralLiabilityExpirationDateAsync("value"),
            "GeneralLiabilityExpirationDate");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterModificationFactorSequentiallyAsync(data.Resolve("{{data:modificationfactor_91}}")),
            () => page.PressModificationFactorAsync("Tab"),
            () => page.CaptureModificationFactorAsync("value"),
            "ModificationFactor");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterTotalPremiumSequentiallyAsync(data.Resolve("{{data:total_premium_92}}")),
            () => page.PressTotalPremiumAsync("Tab"),
            () => page.CaptureTotalPremiumAsync("value"),
            "TotalPremium");
        await page.ClickOKAsync();
        //await page.WaitForUnderwritingInfoOtherInsuranceHistoryDetailAsync("Exists");
        await page.ClickLossExperienceAsync();
        await page.WaitForNoKnownLossesAsync("Exists");
        await page.SetNoKnownLossesAsync(data.Resolve("{{data:no_known_losses_97}}"));
        await page.ClickReturnToQuoteAsync();
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

        var stateCode = data.Resolve("{{data:state}}");
        var primaryRatingState = data.Resolve("{{data:primaryratingstate_108}}");

        if (stateCode == "KS")
        {
            await page.EnterPrimaryRatingStateSequentiallyAsync(primaryRatingState);
            await page.ClickPrimaryRatingStateKansasAsync();
        }
        else
        {
            await page.EnterPrimaryRatingStateAsync(primaryRatingState);
        }
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysSequentiallyAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_112}}")),
            () => page.PressWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync("Tab"),
            () => page.CaptureWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync("value"),
            "WereTheExposuresInsuredPreviouslyInsuredWithinLast90Days");
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

        var umbLimit = await page.CaptureUmbrellaLimitAsync("value");
        if (umbLimit != "$1,000,000")
        {
            await page.EnterUmbrellaLimitAsync(data.Resolve("{{data:expected_umbrella_limit_value_134}}"));

            if (data.Resolve("{{data:expected_umbrella_limit_value_134}}") == "Over $15M")
            {
                await page.EnterRequestedUmbrellaLimitAsync(data.Resolve("{{data:requested_umbrella_limit_value_134}}"));
            }
        }
        else
        {
            await page.VerifyUmbrellaLimitAsync(data.Resolve("{{data:expected_umbrella_limit_value_134}}"), "Value");
        }
        
        if(data.Resolve("{{data:state}}") =="TX")
        {
            await page.EnterIndustryCodeAsync(data.Resolve("{{data:indutrycode_63}}"));
        }

        var actualValue = await page.CaptureExcludedLiabilityConfidentialInformationAsync("value");
        if (actualValue == "CU2186")
        {
            await page.VerifyExcludedLiabilityConfidentialInformationAsync(data.Resolve("{{data:expected_excluded_liability_confidential_information_value_135}}"), "value");
        }
        else
        {
            await page.EnterExcludedLiabilityConfidentialInformationAsync(data.Resolve("{{data:expected_excluded_liability_confidential_information_value_135}}"));
        }
        var actualValueAggregate = await page.CaptuteProductsCompletedOperationsAggregateLimitAsync("value");

        if (actualValueAggregate == "Umbrella Policy Limit")
        {
            await page.VerifyProductsCompletedOperationsAggregateLimitAsync(data.Resolve("{{data:expected_products_completed_operations_aggregate_limit_value_136}}"), "value");
        }
        else 
        {
            await page.EnterProductsCompletedOperationsAggregateLimitAsync(data.Resolve("{{data:expected_products_completed_operations_aggregate_limit_value_136}}"));
        }
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
        if(data.Resolve("{{data:state}}") =="VT")
        {
            await page.WaitUMLimitdsAsync("Visible");
            await page.EnterUMLimitsAsync(data.Resolve("{{data:um_limit}}"));
        }

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
        await page.PauseAsync(3000);
        var contarct = await page.CaptureDoesThisPolicyCoversAContractorExposureAsync("Value");
        if(contarct == "Yes")
        {
            await page.EnterDoesThisPolicyCoversAContractorExposureAsync(data.Resolve("{{data:does_this_policy_cover_contractor_exposure_224}}"));
        }
        else
        {
            await page.VerifyDoesThisPolicyCoversAContractorExposureAsync(data.Resolve("{{data:does_this_policy_cover_contractor_exposure_224}}"), "Value");
        }
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
        await page.WaitForCommercialAutoDetailAsync("Visible");
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterCommercialAutoPolicyNumberSequentiallyAsync(data.Resolve("{{data:policy_number_163}}")),
            () => page.PressCommercialAutoPolicyNumberAsync("Tab"),
            () => page.CaptureCommercialAutoPolicyNumberAsync("value"),
            "CommercialAutoPolicyNumber");

        if (data.Resolve("{{data:policy_number_163}}") != "BAPPOL#")
        {
            await page.ClickImportPolicyDataAsync();
            await page.PauseAsync(5000);
        }
        else
        {
            await page.EnterCommercialAutoEffectiveDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
            await page.EnterCommercialAutoExpirynDateAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
            await EnterWithTabAndNonEmptyRetryAsync(
                () => page.EnterCGLLimitsSequentiallyAsync(data.Resolve("{{data:ca_cgl_limits_177}}")),
                () => page.PressCGLLimitsAsync("Tab"),
                () => page.CaptureCGLLimitsAsync("value"),
                "CGLLimits");
            await EnterWithTabAndNonEmptyRetryAsync(
                () => page.EnterGeneralLiabilityTotalSubjectPremiumSequentiallyAsync(data.Resolve("{{data:ca_total_subject_premium_178}}")),
                () => page.PressGeneralLiabilityTotalSubjectPremiumAsync("Tab"),
                () => page.CaptureGeneralLiabilityTotalSubjectPremiumAsync("value"),
                "GeneralLiabilityTotalSubjectPremium");
        }
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
        await page.WaitForGeneralLiabilityInformationAsync("Visible");
        await page.PauseAsync(3000);
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterGeneralLiabilityPolicyNumberSequentiallyAsync(data.Resolve("{{data:policy_number_173}}")),
            () => page.PressGeneralLiabilityPolicyNumberAsync("Tab"),
            () => page.CaptureGeneralLiabilityPolicyNumberAsync("value"),
            "GeneralLiabilityPolicyNumber");
        await page.PauseAsync(3000);
        if (data.Resolve("{{data:policy_number_173}}") == "GLPOL#")
        {
            await page.EnterCommercialAutoEffectiveDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
            await page.EnterGeneralLiabilityExpirationDateAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
            await page.WaitForCommercialAutoEffectiveDateAsync("NotEqual");
            await EnterWithTabAndNonEmptyRetryAsync(
                () => page.EnterCGLLimitsSequentiallyAsync(data.Resolve("{{data:gl_cgl_limits_177}}")),
                () => page.PressCGLLimitsAsync("Tab"),
                () => page.CaptureCGLLimitsAsync("value"),
                "CGLLimits");
            await EnterWithTabAndNonEmptyRetryAsync(
                () => page.EnterGeneralLiabilityTotalSubjectPremiumSequentiallyAsync(data.Resolve("{{data:gl_total_subject_premium_178}}")),
                () => page.PressGeneralLiabilityTotalSubjectPremiumAsync("Tab"),
                () => page.CaptureGeneralLiabilityTotalSubjectPremiumAsync("value"),
                "GeneralLiabilityTotalSubjectPremium");
        }
        else
        {
            await page.ClickImportPolicyDataAsync();
            await page.PauseAsync(6000);
        }

        var yearbuilt1980 = data.Resolve("{{data:yearbuilt1980}}");
        if (data.Resolve("{{data:state}}") == "NY")
        {
            if (yearbuilt1980 == "Yes")
            {
                await page.EnterEnterYearInBuilt1980Async(data.Resolve("{{data:yearbuilt1980}}"));
            }
            else
            {
                await page.VerifyYearBuilt1980Async(data.Resolve("{{data:yearbuilt1980}}"), "value");
            }
        }

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
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterPolicyNumberSequentiallyAsync(data.Resolve("{{data:policy_number_183}}")),
            () => page.PressPolicyNumberAsync("Tab"),
            () => page.CapturePolicyNumberAsync("value"),
            "BusinessownersPolicyNumber");
        await page.PauseAsync(3000);
        if (data.Resolve("{{data:policy_number_183}}") != "BOPPOL#")
        {
            await page.ClickImportPolicyDataButtonAsync();
            await page.PauseAsync(3000);
        }
        else
        {
            if (data.Resolve("{{data:state}}") == "MO")
            {
                await page.EnterLiquifiedGasAsync(data.Resolve("{{data:gl_liquifiedgas}}"));
                await page.EnterEffectiveDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
                await page.EnterExpirationDateAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
            }
            else if (data.Resolve("{{data:state}}") == "MA Auto")
            {
                await page.EnterEffectiveDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
                await page.EnterExpirationDateAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
            }
            else
            {
                await page.EnterEffectiveDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
                await page.EnterExpirationDateAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
                await page.EnterLiabilityLimitAsync(data.Resolve("{{data:bo_cgl_limits_177}}"));
                await page.EnterTotalSubjectPremiumAsync(data.Resolve("{{data:bo_total_subject_premium_178}}"));
            }
        }
        
        if (data.Resolve("{{data:state}}") == "NY")
        {
            await page.VerifyYearBuilt1980Async(data.Resolve("{{data:yearbuilt1980}}"), "value");
        }
        await page.PauseAsync(3000);

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
        await page.PauseAsync(3000);
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterBusinessownersPolicyNumberSequentiallyAsync(data.Resolve("{{data:policy_number_192}}")),
            () => page.PressBusinessownersPolicyNumberAsync("Tab"),
            () => page.CaptureBusinessownersPolicyNumberAsync("value"),
            "EmployersLiabilityPolicyNumber");
        await page.PauseAsync(2000);
        if (data.Resolve("{{data:policy_number_192}}") != "WCPOL#")
        {
            await page.ClickImportPolicyDataButtonAsync();
            await page.PauseAsync(3000);
        }
        else
        {
            if (data.Resolve("{{data:state}}") == "LA")
            {
                await page.EnterCommercialAutoEffectiveDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
                await page.EnterGeneralLiabilityExpirationDateAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
            }
            else
            {
                await page.EnterCommercialAutoEffectiveDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
                await page.EnterGeneralLiabilityExpirationDateAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
                await EnterWithTabAndNonEmptyRetryAsync(
                    () => page.EnterCGLLimitsSequentiallyAsync(data.Resolve("{{data:emp_cgl_limits_177}}")),
                    () => page.PressCGLLimitsAsync("Tab"),
                    () => page.CaptureCGLLimitsAsync("value"),
                    "CGLLimits");
                await EnterWithTabAndNonEmptyRetryAsync(
                    () => page.EnterGeneralLiabilityTotalSubjectPremiumSequentiallyAsync(data.Resolve("{{data:emp_total_subject_premium_178}}")),
                    () => page.PressGeneralLiabilityTotalSubjectPremiumAsync("Tab"),
                    () => page.CaptureGeneralLiabilityTotalSubjectPremiumAsync("value"),
                    "GeneralLiabilityTotalSubjectPremium");
            }
        }
        await page.PauseAsync(3000);

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
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterCPPLiabPolicyNumberSequentiallyAsync(data.Resolve("{{data:policy_number_200}}")),
            () => page.PressCPPLiabPolicyNumberAsync("Tab"),
            () => page.CaptureCPPLiabPolicyNumberAsync("value"),
            "CPPLiabilityPolicyNumber");
        await page.PauseAsync(3000);
        if (data.Resolve("{{data:policy_number_200}}") == "CPPPOL#")
        {
            if(data.Resolve("{{data:state}}") == "LA" || data.Resolve("{{data:state}}") == "MA Auto" || data.Resolve("{{data:state}}") == "NM")
            {
                await page.EnterBusinessownersEffectiveDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
                await page.EnterBusinessownersExpirationDateAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
            }
            else
            {
                await page.EnterBusinessownersEffectiveDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
                await page.EnterBusinessownersExpirationDateAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
                await EnterWithTabAndNonEmptyRetryAsync(
                    () => page.EnterCommercialAutoLiabilityLimitSequentiallyAsync(data.Resolve("{{data:cpp_cgl_limits_177}}")),
                    () => page.PressCommercialAutoLiabilityLimitAsync("Tab"),
                    () => page.CaptureCommercialAutoLiabilityLimitAsync("value"),
                    "CommercialAutoLiabilityLimit");
                await EnterWithTabAndNonEmptyRetryAsync(
                    () => page.EnterBusinessownersTotalSubjectPremiumSequentiallyAsync(data.Resolve("{{data:cpp_total_subject_premium_178}}")),
                    () => page.PressBusinessownersTotalSubjectPremiumAsync("Tab"),
                    () => page.CaptureBusinessownersTotalSubjectPremiumAsync("value"),
                    "BusinessownersTotalSubjectPremium");
            }
            
        }
        else
        {
            await page.ClickImportPolicyDataAsync();
            await page.PauseAsync(3000);
        }
        if (data.Resolve("{{data:state}}") == "NY")
        {
            await page.WaitForYearBuilt1980Async("Exists");
            await page.VerifyYearBuilt1980Async(data.Resolve("{{data:yearbuilt1980}}"), "value");
        }
        await page.PauseAsync(1000);
    }

    [Given(@"^I complete required sfp 10 information$")]
    [When(@"^I complete required sfp 10 information$")]
    [Then(@"^I complete required sfp 10 information$")]
    public async Task CompleteRequiredSfp10InformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await page.PauseAsync(3000);
        await page.ClickSFP10LiabilityFarmAsync();


        if(data.Resolve("{{data:state}}") == "ME")
        {
            await page.EnterFarmLiabilityCoverage10000000Async(data.Resolve("{{data:me_farm_family_liability}}"));
            await EnterWithTabAndNonEmptyRetryAsync(
                () => page.EnterSFPiabilityPolicyNumberSequentiallyAsync(data.Resolve("{{data:policy_number_210}}")),
                () => page.PressGeneralLiabilityPolicyNumberAsync("Tab"),
                () => page.CaptureGeneralLiabilityPolicyNumberAsync("value"),
                "SFPPolicyNumber");
            await page.EnterCommercialAutoEffectiveDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
            await page.WaitForCommercialAutoEffectiveDateAsync("NotEqual");
            await page.EnterGeneralLiabilityExpirationDateAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
            await EnterWithTabAndNonEmptyRetryAsync(
                () => page.EnterSFP10LiabilityFarmLiabilityLimitSequentiallyAsync(data.Resolve("{{data:sfp_cgl_limits_177}}")),
                () => page.PressSFP10LiabilityFarmLiabilityLimitAsync("Tab"),
                () => page.CaptureSFP10LiabilityFarmLiabilityLimitAsync("value"),
                "SFP10LiabilityFarmLiabilityLimit");
            await EnterWithTabAndNonEmptyRetryAsync(
                () => page.EnterGeneralLiabilityTotalSubjectPremiumSequentiallyAsync(data.Resolve("{{data:sfp_total_subject_premium_178}}")),
                () => page.PressGeneralLiabilityTotalSubjectPremiumAsync("Tab"),
                () => page.CaptureGeneralLiabilityTotalSubjectPremiumAsync("value"),
                "GeneralLiabilityTotalSubjectPremium");
        }
        else
        {
            await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterSFPiabilityPolicyNumberSequentiallyAsync(data.Resolve("{{data:policy_number_210}}")),
            () => page.PressGeneralLiabilityPolicyNumberAsync("Tab"),
            () => page.CaptureGeneralLiabilityPolicyNumberAsync("value"),
            "SFPPolicyNumber");
            await page.EnterCommercialAutoEffectiveDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
            await page.WaitForCommercialAutoEffectiveDateAsync("NotEqual");
            await page.EnterGeneralLiabilityExpirationDateAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
            await EnterWithTabAndNonEmptyRetryAsync(
                () => page.EnterSFP10LiabilityFarmLiabilityLimitSequentiallyAsync(data.Resolve("{{data:sfp_cgl_limits_177}}")),
                () => page.PressSFP10LiabilityFarmLiabilityLimitAsync("Tab"),
                () => page.CaptureSFP10LiabilityFarmLiabilityLimitAsync("value"),
                "SFP10LiabilityFarmLiabilityLimit");
            await EnterWithTabAndNonEmptyRetryAsync(
                () => page.EnterGeneralLiabilityTotalSubjectPremiumSequentiallyAsync(data.Resolve("{{data:sfp_total_subject_premium_178}}")),
                () => page.PressGeneralLiabilityTotalSubjectPremiumAsync("Tab"),
                () => page.CaptureGeneralLiabilityTotalSubjectPremiumAsync("value"),
                "GeneralLiabilityTotalSubjectPremium");
            await page.PauseAsync(3000);

        }

        var yearbuilt1980 = data.Resolve("{{data:yearbuilt1980}}");

        if (data.Resolve("{{data:state}}") == "NY")
        {
            await page.WaitForYearBuilt1980Async("Exists");
            await page.EnterEnterYearInBuilt1980Async(data.Resolve("{{data:yearbuilt1980}}"));
            await page.EnterLiveStockMeatAsync(data.Resolve("{{data:LiveStockMeat}}"));
        }
    }

    [Given(@"^I complete required endorsement information$")]
    [When(@"^I complete required endorsement information$")]
    [Then(@"^I complete required endorsement information$")]
    public async Task CompleteRequiredEndorsementInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForWCNavigationLinksEndorsementsAsync("Visible");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await Task.Delay(3000);
    }

    [Given(@"^I complete required underwriting question information$")]
    [When(@"^I complete required underwriting question information$")]
    [Then(@"^I complete required underwriting question information$")]
    public async Task CompleteRequiredUnderwritingQuestionInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickUWQuestionsUmbrellaAsync();
        await page.WaitForUWQuestionHeaderAsync("Visible");
        await Task.Delay(3000);
        await page.WaitForUWQuestionsUmbrellaUpdateAnswersAsync("Visible");
        await page.ClickSpecificUnderwritingQuestionsContractorsEquipmentUpdateAnswersAsync();
        await Task.Delay(3000);
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

        await page.ClickPricingAsync();
        await page.WaitForPricingHeadingAsync("Visible");
        var expectedPremium = data.Resolve("{{data:expected_premium_value_228}}").Replace("*", string.Empty).Trim();
        await page.VerifyPremiumAsync(expectedPremium, "value");
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
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_231}}"));
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_234}}"));
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_238}}"));
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
        await EnterWithTabAndNonEmptyRetryAsync(
            () => page.EnterTextBoxSequentiallyAsync(data.Resolve("Test {B[Product (LOB)]}")),
            () => page.PressTextBoxAsync("Tab"),
            () => page.CaptureTextBoxAsync("value"),
            "NotepadTextBox");
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
    }

    [Given(@"^I run Stoplight$")]
    [When(@"^I run Stoplight$")]
    [Then(@"^I run Stoplight$")]
    public async Task RunStoplightAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickCompleteApplicationAsync();
        await page.PauseAsync(6000);
        await page.WaitStoplightWaitingWindowCloseAsync("Visible");
        await page.ClickStoplightWaitingWindowFirstCloseButtonOnErrorAsync();
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

        var expectedFullTermPremium = data.Resolve("{{data:expected_full_term_premium_value_292}}").Replace("*", string.Empty).Trim();
        var expectedPremiumWritten = data.Resolve("{{data:expected_premium_written_value_293}}").Replace("*", string.Empty).Trim();
        var expectedPriorPremium = data.Resolve("{{data:expected_prior_premium_value_294}}").Replace("*", string.Empty).Trim();
        var expectedPremiumChange = data.Resolve("{{data:expected_premium_change_value_295}}").Replace("*", string.Empty).Trim();

        await page.VerifyFullTermPremiumAsync(expectedFullTermPremium, "value");
        await page.VerifyPremiumWrittenAsync(expectedPremiumWritten, "value");
        await page.VerifyPriorPremiumAsync(expectedPriorPremium, "value");
        await page.VerifyPremiumChangeAsync(expectedPremiumChange, "value");
    }

    [Given(@"^I complete forms verification UMB$")]
    [When(@"^I complete forms verification UMB$")]
    [Then(@"^I complete forms verification UMB$")]
    public async Task CompleteFormsVerificationUMBAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
    }

    [Given(@"^I sign out of the application$")]
    [When(@"^I sign out of the application$")]
    [Then(@"^I sign out of the application$")]
    public async Task SignOutOfTheApplicationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        //await page.ClickLoggedInUserAsync();
        //await page.ClickLogoutAsync();
        //await page.PauseAsync(1000);
        //await page.VerifyBrowserCommunicationHTTPStatusZeroAsync("Exists", "");
        //await page.ClickOKAsync();
        //await page.WaitForOKAsync("Absent");
        //await page.ClickLoggedInUserAsync();
        //await page.ClickLogoutAsync();

    }

    private static async Task EnterWithTabAndNonEmptyRetryAsync(
        Func<Task> enter,
        Func<Task> pressTab,
        Func<Task<string>> capture,
        string fieldName,
        int maxAttempts = 4)
    {
        for (var attempt = 1; attempt <= maxAttempts; attempt++)
        {
            await enter();
            await pressTab();
            await Task.Delay(2000);

            var actual = (await capture())?.Trim() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(actual))
            {
                return;
            }
        }

        throw new InvalidOperationException($"Value was empty after Tab commit for field '{fieldName}' after {maxAttempts} attempts.");
    }

}
