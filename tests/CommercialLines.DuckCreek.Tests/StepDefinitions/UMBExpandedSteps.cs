using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;
using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "UMB Expanded")]
public sealed class UMBExpandedSteps
{
    private readonly ScenarioContext _scenario;
    public UMBExpandedSteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I start a new quote$")]
    [When(@"^I start a new quote$")]
    [Then(@"^I start a new quote$")]
    public async Task StartANewQuoteAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickNewQuoteAsync();
        await page.EnterEffectiveDateAsync(data.Resolve("{{data:effectivedate_104}}"));
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
        await page.EnterInsuredTypeSequentiallyAsync(data.Resolve("{{data:insured_type_4}}"));
        await page.EnterEntityTypeSequentiallyAsync(data.Resolve("{{data:entity_type_8}}"));
        await page.WaitForBusinessNameAsync("Visible");
        await page.EnterBusinessNameSequentiallyAsync(data.Resolve("{{data:business_name_7}}"));
        await page.EnterPrimaryPhoneSequentiallyAsync(data.Resolve("{{runtime:PrimaryPhone_0041}}"));
        await page.EnterNamedInsuredZipCodeSequentiallyAsync(data.Resolve("{{data:zipcode_11}}"));
        await page.EnterAddressSequentiallyAsync(data.Resolve("{{data:address1_12}}"));
        await page.EnterFEINSequentiallyAsync(data.Resolve("{{runtime:FEIN_0044}}"));
        if (await page.HasYearsInBusinessAsync())
        {
            await page.VerifyYearsInBusinessAsync("Exists", "");
            await page.EnterYearsInBusinessSequentiallyAsync(data.Resolve("{{data:years_in_business_14}}"));
        }
        await page.EnterNameOfInspectionContactSequentiallyAsync(data.Resolve("{{data:name_of_inspection_contact_16}}"));
        await page.EnterInspectionTelephoneSequentiallyAsync(data.Resolve("{{runtime:InspectionTelephone_0045}}"));
        await page.EnterInsuredEMailAddressSequentiallyAsync(data.Resolve("{{data:insured_e_mail_address_18}}"));
        await page.EnterWebsiteAddressSequentiallyAsync(data.Resolve("{{data:website_address_19}}"));
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

        await page.EnterIndividualTypeSequentiallyAsync(data.Resolve("{{data:individualtype_45}}"));
        await page.PressIndividualTypeAsync("Tab");
        await page.WaitForPleaseVerifySSNAsync("Exists");
        await page.EnterFirstNameSequentiallyAsync(data.Resolve("{{runtime:FirstName_0057}}"));
        await page.EnterMiddleNameSequentiallyAsync(data.Resolve("{{runtime:MiddleName_0057}}"));
        await page.EnterLastNameSequentiallyAsync(data.Resolve("{{runtime:LastName_0057}}"));
        await page.EnterAddAssociatedClientDateOfBirthSequentiallyAsync(data.Resolve("{{data:dateofbirth_50}}"));
        await page.EnterAddressSequentiallyAsync(data.Resolve("{{data:address1_51}}"));
        await page.EnterCitySequentiallyAsync(data.Resolve("{{data:city_52}}"));
        await page.EnterStateSequentiallyAsync(data.Resolve("{{data:state_53}}"));
        await page.EnterNamedInsuredZipCodeSequentiallyAsync(data.Resolve("{{data:zipcode_54}}"));
        await page.EnterGenderSequentiallyAsync(data.Resolve("{{data:gender_55}}"));
        await page.PressGenderAsync("Tab");
        await page.WaitForClientSearchAsync("Exists");
        await page.ClickClientSearchAsync();
        await page.ClickOKWithRetryAsync();
        await page.ClickOrderSSNAsync();
        await page.EnterAddAssociatedClientEnterSSNSequentiallyAsync(data.Resolve("{{data:enter_ssn_63}}"));
        await page.PauseAsync(4000);
        await page.PressAddAssociatedClientEnterSSNAsync("Tab");
        await page.PauseAsync(3000);
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
        await page.ClickOKWithRetryAsync();
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
        await page.EnterCarrierSequentiallyAsync(data.Resolve("{{data:carrier_86}}"));
        await page.EnterGeneralLiabilityPolicyNumberSequentiallyAsync(data.Resolve("{{data:policy_number_87}}"));
        await page.EnterPolicyTypeSequentiallyAsync(data.Resolve("{{data:policy_type_88}}"));
        await page.EnterCommercialAutoEffectiveDateSequentiallyAsync(data.Resolve("{DATE[][-2y][MM'/'dd'/'yyyy]}"));
        await page.EnterGeneralLiabilityExpirationDateSequentiallyAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.EnterModificationFactorSequentiallyAsync(data.Resolve("{{data:modificationfactor_91}}"));
        await page.EnterTotalPremiumSequentiallyAsync(data.Resolve("{{data:total_premium_92}}"));
        await page.ClickOKAsync();
        await page.ClickLossExperienceAsync();
        await page.WaitForNoKnownLossesAsync("Visible");
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
        await page.EnterPolicyInfoRequiredAndOptionalFieldsEffectiveDateSequentiallyAsync(data.Resolve("{{data:effectivedate_104}}"));
        await page.EnterYearsInBusinessSequentiallyAsync(data.Resolve("{{data:years_in_business_106}}"));
        var stateCode = data.Resolve("{{data:state}}");
        var primaryRatingState = data.Resolve("{{data:primaryratingstate_108}}");

        if (stateCode == "KS")
        {
            await page.EnterPrimaryRatingStateSequentiallyAsync(primaryRatingState);
            await page.ClickPrimaryRatingStateKansasAsync();
        }
        else
        {
            await page.EnterPrimaryRatingStateSequentiallyAsync(primaryRatingState);
        }
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysSequentiallyAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_112}}"));
        await page.PauseAsync(1000);
        await page.WaitForPolicyInfoHeaderAsync("Visible");
        await page.WaitForDescriptionOfSpecifiedOperationAsync("Visible");
        await page.EnterDescriptionOfSpecifiedOperationSequentiallyAsync(data.BuildQuoteDescription());
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
        await page.EnterUmbrellaLimitSequentiallyAsync(data.Resolve("{{data:umbrella_limit_134}}"));
        await page.PressUmbrellaLimitAsync("Tab");
        if (data.Resolve("{{data:umbrella_limit_134}}") == "Over $15M")
        {
            await page.EnterRequestedUmbrellaLimitSequentiallyAsync(data.Resolve("{{data:requested_umbrella_limit_135}}"));
        }
        await page.EnterExcludedLiabilityConfidentialInformationSequentiallyAsync(data.Resolve("{{data:excluded_liability_confidential_information_136}}"));
        await page.EnterProductsCompletedOperationsAggregateLimitSequentiallyAsync(data.Resolve("{{data:products_completed_operations_aggregate_limit_138}}"));
        if (data.Resolve("{{data:stateVariant}}") == "TX")
        {
            await page.EnterIndustryCodeAsync(data.Resolve("{{data:indutrycode_63}}"));
        }
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
        await page.EnterDoesThisPolicyCoversAContractorExposureAsync(data.Resolve("{{data:does_this_policy_cover_contractor_exposure_224}}"));
        if (data.Resolve("{{data:stateVariant}}") == "VT")
        {
            await page.EnterUMLimitAsync(data.Resolve("{{data:ul_Limit}}"));
        }
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
        await page.EnterCommercialAutoPolicyNumberSequentiallyAsync(data.Resolve("{{data:policy_number_183}}"));
        if (data.Resolve("{{data:policy_number_183}}") != "BAPPOL#")
        {
            await page.ClickImportPolicyDataAsync();
            await page.PauseAsync(5000);
        }
        else
        {
            await page.EnterCommercialAutoEffectiveDateSequentiallyAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
            await page.EnterCommercialAutoExpirynDateAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
            await page.EnterCGLLimitsSequentiallyAsync(data.Resolve("{{data:ca_cgl_limits_177}}"));
            await page.EnterGeneralLiabilityTotalSubjectPremiumSequentiallyAsync(data.Resolve("{{data:ca_total_subject_premium_178}}"));
        }
        await page.PauseAsync(3000);
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
        await page.EnterGeneralLiabilityPolicyNumberSequentiallyAsync(data.Resolve("{{data:policy_number_193}}"));
        if (data.Resolve("{{data:policy_number_193}}") == "GLPOL#")
        {
            await page.EnterCommercialAutoEffectiveDateSequentiallyAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
            await page.EnterGeneralLiabilityExpirationDateSequentiallyAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
            await page.WaitForCommercialAutoEffectiveDateAsync("NotEqual");
            await page.EnterCGLLimitsSequentiallyAsync(data.Resolve("{{data:gl_cgl_limits_177}}"));
            await page.EnterGeneralLiabilityTotalSubjectPremiumSequentiallyAsync(data.Resolve("{{data:gl_total_subject_premium_178}}"));
            await page.PauseAsync(1000);
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
        await page.EnterPolicyNumberSequentiallyAsync(data.Resolve("{{data:policy_number_203}}"));
        await page.PauseAsync(3000);
        if (data.Resolve("{{data:policy_number_203}}") != "BOPPOL#")
        {
            await page.ClickImportPolicyDataButtonAsync();
            await page.PauseAsync(3000);
        }
        else
        {
            if (data.Resolve("{{data:state}}") == "MO")
            {
                await page.EnterLiquifiedGasAsync(data.Resolve("{{data:gl_liquifiedgas}}"));
                await page.EnterEffectiveDateSequentiallyAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
                await page.EnterExpirationDateSequentiallyAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
                await page.EnterLiabilityLimitAsync(data.Resolve("{{data:bo_cgl_limits_177}}"));
                await page.EnterTotalSubjectPremiumAsync(data.Resolve("{{data:bo_total_subject_premium_178}}"));
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

    [Given(@"^I complete required sfp 10 information$")]
    [When(@"^I complete required sfp 10 information$")]
    [Then(@"^I complete required sfp 10 information$")]
    public async Task CompleteRequiredSfp10InformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickSFP10LiabilityFarmAsync();
        await page.PauseAsync(2000);
        await page.WaitForSignsHeadingAsync("Visible");
        if (data.Resolve("{{data:state}}") == "ME")
        {
            await page.EnterFarmLiabilityCoverage10000000Async(data.Resolve("{{data:me_farm_family_liability}}"));
            await page.EnterSFPiabilityPolicyNumberSequentiallyAsync(data.Resolve("{{data:policy_number_211}}"));
            await page.EnterCommercialAutoEffectiveDateSequentiallyAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
            await page.EnterGeneralLiabilityExpirationDateSequentiallyAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
            await page.EnterSFP10LiabilityFarmLiabilityLimitSequentiallyAsync(data.Resolve("{{data:sfp_cgl_limits_177}}"));
            await page.EnterGeneralLiabilityTotalSubjectPremiumSequentiallyAsync(data.Resolve("{{data:sfp_total_subject_premium_178}}"));
        }
        else
        {
            await page.EnterSFPiabilityPolicyNumberSequentiallyAsync(data.Resolve("{{data:policy_number_211}}"));
            await page.EnterCommercialAutoEffectiveDateSequentiallyAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
            await page.WaitForCommercialAutoEffectiveDateAsync("NotEqual");
            await page.EnterGeneralLiabilityExpirationDateSequentiallyAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
            await page.EnterSFP10LiabilityFarmLiabilityLimitSequentiallyAsync(data.Resolve("{{data:sfp_cgl_limits_177}}"));
            await page.EnterGeneralLiabilityTotalSubjectPremiumSequentiallyAsync(data.Resolve("{{data:sfp_total_subject_premium_178}}"));
            await page.PauseAsync(3000);

        }

        var yearbuilt1980 = data.Resolve("{{data:yearbuilt1980}}");

        if (data.Resolve("{{data:stateVariant}}") == "NY")
        {
            await page.WaitForYearBuilt1980Async("Exists");
            await page.EnterEnterYearInBuilt1980Async(data.Resolve("{{data:yearbuilt1980}}"));
            await page.EnterLiveStockMeatAsync(data.Resolve("{{data:LiveStockMeat}}"));
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
        await page.PauseAsync(2000);
        await page.EnterBusinessownersPolicyNumberSequentiallyAsync(data.Resolve("{{data:policy_number_220}}"));
        await page.PauseAsync(2000);
        if (data.Resolve("{{data:policy_number_220}}") != "WCPOL#")
        {
            await page.ClickImportPolicyDataButtonAsync();
            await page.PauseAsync(3000);
        }
        else
        {
            if (data.Resolve("{{data:state}}") == "LA")
            {
                await page.EnterCommercialAutoEffectiveDateSequentiallyAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
                await page.EnterGeneralLiabilityExpirationDateSequentiallyAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
                await page.EnterCGLLimitsSequentiallyAsync(data.Resolve("{{data:emp_cgl_limits_177}}"));
                await page.EnterGeneralLiabilityTotalSubjectPremiumSequentiallyAsync(data.Resolve("{{data:emp_total_subject_premium_178}}"));
            }
            else
            {
                await page.EnterCommercialAutoEffectiveDateSequentiallyAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
                await page.EnterGeneralLiabilityExpirationDateSequentiallyAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
                await page.EnterCGLLimitsSequentiallyAsync(data.Resolve("{{data:emp_cgl_limits_177}}"));
                await page.EnterGeneralLiabilityTotalSubjectPremiumSequentiallyAsync(data.Resolve("{{data:emp_total_subject_premium_178}}"));
            }
        }
        await page.PauseAsync(3000);
    }

    [Given(@"^I complete required homeowners liability information$")]
    [When(@"^I complete required homeowners liability information$")]
    [Then(@"^I complete required homeowners liability information$")]
    public async Task CompleteRequiredHomeownersLiabilityInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForHomeownerSLiabilityAsync("Visible");
        await page.ClickHomeownerSLiabilityAsync();
        await page.PauseAsync(2000);
        await page.EnterPolicyNumberSequentiallyAsync(data.Resolve("{{data:policy_number_228}}"));
        await page.EnterEffectiveDateSequentiallyAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.EnterExpirationDateSequentiallyAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        await page.EnterLiabilityLimitSequentiallyAsync(data.Resolve("{{data:ol_cgl_limits_177}}"));

        if (!string.IsNullOrEmpty(data.Resolve("{{data:ca_total_subject_premium_229}}")))
        {
            await page.EnterTotalSubjectPremiumSequentiallyAsync(data.Resolve("{{data:ca_total_subject_premium_229}}"));
        }

        await page.PressLiabilityLimitAsync("Tab");
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
        await page.PauseAsync(2000);
        await page.EnterBusinessownersPolicyNumberSequentiallyAsync(data.Resolve("{{data:policy_number_236}}"));
        await page.EnterBusinessownersEffectiveDateSequentiallyAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.EnterBusinessownersExpirationDateSequentiallyAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));

        if (data.Resolve("{{data:mc_cgl_limits_177}}") != "")
        {
            await page.EnterCommercialAutoLiabilityLimitSequentiallyAsync(data.Resolve("{{data:mc_cgl_limits_177}}"));
            await page.PressCommercialAutoLiabilityLimitAsync("Tab");
        }
        if (data.Resolve("{{data:vt_nh_wv_la_um_limit}}") != "")
        {
            await page.EnterCommercialUMLimitSequentiallyAsync(data.Resolve("{{data:vt_nh_wv_la_um_limit}}"));
            await page.PressCommercialUMLimitAsync("Tab");
        }
       
        if (data.Resolve("{{data:mc_total_subject_premium_178}}") != "")
        {
            await page.EnterBusinessownersTotalSubjectPremiumAsync(data.Resolve("{{data:mc_total_subject_premium_178}}"));
            await page.PressBusinessownersTotalSubjectPremiumAsync("Tab");
        }
        await page.PauseAsync(3000);
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
        await page.PauseAsync(2000);
        await page.EnterPolicyNumberSequentiallyAsync(data.Resolve("{{data:policy_number_245}}"));
        await page.EnterEffectiveDateSequentiallyAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.EnterExpirationDateSequentiallyAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        await page.EnterLiabilityLimitSequentiallyAsync(data.Resolve("{{data:liability_limit_249}}"));
        await page.EnterTotalSubjectPremiumAsync(data.Resolve("{{data:total_subject_premium_251}}"));

        if (data.Resolve("{{data:pd_limit_250}}") != "")
        {
            await page.EnterPDLimitAsync(data.Resolve("{{data:pd_limit_250}}"));
        }
        if (data.Resolve("{{data:pa_vt_nh_wv_la_um_limit}}") != "")
        {
            await page.EnterCommercialUMLimitSequentiallyAsync(data.Resolve("{{data:pa_vt_nh_wv_la_um_limit}}"));
            await page.PressCommercialUMLimitAsync("Tab");
        }
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
        await page.PauseAsync(3000);
        await page.EnterBusinessownersPolicyNumberSequentiallyAsync(data.Resolve("{{data:policy_number_255}}"));
        await page.EnterBusinessownersEffectiveDateSequentiallyAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.EnterBusinessownersExpirationDateSequentiallyAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        await page.EnterCommercialAutoLiabilityLimitSequentiallyAsync(data.Resolve("{{data:rro_cgl_limits_177}}"));
        await page.PressCommercialAutoLiabilityLimitAsync("Tab");
        if(!string.IsNullOrEmpty(data.Resolve("{{data:rro_total_subject_premium_178}}")))
        {
            await page.EnterBusinessownersTotalSubjectPremiumSequentiallyAsync(data.Resolve("{{data:rro_total_subject_premium_178}}"));
        }
        if(data.Resolve("{{data:stateVariant}}") == "NY")
        {
            await page.EnterEnterYearInBuilt1980Async(data.Resolve("{{data:rr0_yearbuilt1980}}"));
        }
        await Task.Delay(3000);
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
        await page.PauseAsync(2000);
        await page.EnterCPPLiabPolicyNumberSequentiallyAsync(data.Resolve("{{data:policy_number_263}}"));
        await page.PauseAsync(3000);
        if (data.Resolve("{{data:policy_number_263}}") == "CPPPOL#")
        {
            if (data.Resolve("{{data:state}}") == "LA")
            {
                await page.EnterBusinessownersEffectiveDateSequentiallyAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
                await page.EnterBusinessownersExpirationDateSequentiallyAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
                await page.EnterBusinessownersTotalSubjectPremiumSequentiallyAsync(data.Resolve("{{data:cpp_total_subject_premium_178}}"));
            }
            else if(data.Resolve("{{data:state}}") == "NM")
            {
                await page.EnterBusinessownersEffectiveDateSequentiallyAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
                await page.EnterBusinessownersExpirationDateSequentiallyAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
                await page.EnterCommercialAutoLiabilityLimitSequentiallyAsync(data.Resolve("{{data:cpp_cgl_limits_177}}"));
                await page.EnterBusinessownersTotalSubjectPremiumSequentiallyAsync(data.Resolve("{{data:cpp_total_subject_premium_178}}"));
            }
            else
            {
                await page.EnterBusinessownersEffectiveDateSequentiallyAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
                await page.EnterBusinessownersExpirationDateSequentiallyAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
                await page.EnterCommercialAutoLiabilityLimitSequentiallyAsync(data.Resolve("{{data:cpp_cgl_limits_177}}"));
                await page.EnterBusinessownersTotalSubjectPremiumSequentiallyAsync(data.Resolve("{{data:cpp_total_subject_premium_178}}"));
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

    [Given(@"^I complete required watercraft liability information$")]
    [When(@"^I complete required watercraft liability information$")]
    [Then(@"^I complete required watercraft liability information$")]
    public async Task CompleteRequiredWatercraftLiabilityInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForWatercraftLiabilityAsync("Visible");
        await page.ClickWatercraftLiabilityAsync();
        await page.PauseAsync(2000);
        await page.EnterPolicyNumberSequentiallyAsync(data.Resolve("{{data:policy_number_274}}"));
        await page.EnterEffectiveDateSequentiallyAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.EnterExpirationDateSequentiallyAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        await page.EnterLiabilityLimitSequentiallyAsync(data.Resolve("{{data:wl_cgl_limits_177}}"));
        await page.EnterTotalSubjectPremiumSequentiallyAsync(data.Resolve("{{data:wl_total_subject_premium_178}}"));
        await page.PressTotalSubjectPremiumAsync("Tab");
    }

    [Given(@"^I complete required recreational vehicle information$")]
    [When(@"^I complete required recreational vehicle information$")]
    [Then(@"^I complete required recreational vehicle information$")]
    public async Task CompleteRequiredRecreationalVehicleInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new VehiclesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickRecreationalVehicleLiabilityAsync();
        await Task.Delay(2000);
        await page.WaitForRecreationalVehicleLiabilityHeadingAsync("Visible");
        await page.EnterPolicyNumberSequentiallyAsync(data.Resolve("{{data:policy_number_282}}"));
        await page.EnterCarrierNameAsync(data.Resolve("{{data:carrier_name_283}}"));
        await page.EnterEffectiveDateSequentiallyAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.EnterExpirationDateSequentiallyAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        await page.EnterLiabilityLimitSequentiallyAsync(data.Resolve("{{data:rv_cgl_limits_177}}"));
        await page.EnterTotalSubjectPremiumSequentiallyAsync(data.Resolve("{{data:rv_total_subject_premium_178}}"));
        await page.PressTotalSubjectPremiumAsync("Tab");
        if (!string.IsNullOrEmpty(data.Resolve("{{data:um_Limit_1}}")) || data.Resolve("{{data:state}}") == "NH" || data.Resolve("{{data:state}}") == "LA")
        {
            await page.EnterCommercialUMLimitSequentiallyAsync(data.Resolve("{{data:rv_um_Limit_1}}"));
            await page.PressCommercialUMLimitAsync("Tab");
        }
        if (!string.IsNullOrEmpty(data.Resolve("{{data:pd_limit_288}}")))
        {
            await page.EnterPDLimitSequentiallyAsync(data.Resolve("{{data:pd_limit_288}}"));
            await page.PressPDLimitAsync("Tab");
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
        
        await page.WaitForSelectEndorsementAsync("Visible");
        
        if(data.Resolve("{{data:stateVariant}}") is ("MA" or "TX" or "WA"))
        {
            var endorsement = data.Resolve("{{data:select_endorsement_305}}");
            if (new[] { "[CU2119]", "[CU2120]", "[CU2121]" }.Any(code => endorsement?.Contains(code, StringComparison.OrdinalIgnoreCase) == true))

            {
                await page.PauseAsync(3000);
                if (await page.IsCU2118DeletePresentAsync())
                {
                    await page.ClickCU2118DeleteAsync();
                }
            }
            await page.EnterSelectEndorsementSequentiallyAsync(data.Resolve("{{data:select_endorsement_305}}"));
            await page.PressSelectEndorsementAsync("Tab");
            await page.ClickEndorsementMainAddEndorsementAsync();
            await page.WaitForOKAsync2("Visible");
            await page.ClickOKAsync();
        }
        else {
            await page.EnterSelectEndorsementSequentiallyAsync(data.Resolve("{{data:select_endorsement_305}}"));
            await page.PressSelectEndorsementAsync("Tab");
            await page.ClickEndorsementMainAddEndorsementAsync();
            await page.EnterIFRAMEDuckCreekPolicyDescriptionOfPremisesOrActivitiesSequentiallyAsync(data.Resolve("{{data:iframe_duck_creek_policy_description_of_premises_or_activities_308}}"));
            await page.WaitForOKAsync2("Visible");
            await page.ClickOKAsync();
        }
        

        if (data.Resolve("{{data:stateVariant}}") is "IA" or "IL" or "KS" or "MO" or "MT" or "KY" or "MD" or "ME" or "ND" or "NJ" or "NY" or "OH" or "OK" or "OR" or "PA" or "RI" or "SC" or "TN" or "VT" or "WI" or "WV" or "WY")
        {
            var endorsement = data.Resolve("{{data:select_endorsement_306}}");
            if (new[] { "[CU2119]", "[CU2120]", "[CU2121]" }.Any(code => endorsement?.Contains(code, StringComparison.OrdinalIgnoreCase) == true))

            {
                await page.PauseAsync(3000);
                if (await page.IsCU2118DeletePresentAsync())
                {
                    await page.ClickCU2118DeleteAsync();
                }
            }
            if (data.Resolve("{{data:stateVariant}}") is "IA" or "WY")
            {
                await page.EnterSelectEndorsementSequentiallyAsync(data.Resolve("{{data:select_endorsement_306}}"));
                await page.PressSelectEndorsementAsync("Tab");
                await page.ClickEndorsementMainAddEndorsementAsync();
                await page.ClickBadilyJustingAsync();
                await page.ClickPropertDamageAsync();
                await page.ClickPersonalAdvertisingAsync();
                await page.EnterSDescriptionLocationSequentiallyAsync(data.Resolve("{{data:description_1}}"));
                await page.WaitForOKAsync2("Visible");
                await page.ClickOKAsync();
            }
            else
            {
                await page.EnterSelectEndorsementSequentiallyAsync(data.Resolve("{{data:select_endorsement_306}}"));
                await page.PressSelectEndorsementAsync("Tab");
                await page.ClickEndorsementMainAddEndorsementAsync();
                await page.WaitForOKAsync2("Visible");
                await page.ClickOKAsync();
            }
        }

        if(data.Resolve("{{data:stateVariant}}") is "NM" or "UT" or "WA")
        {
            await page.EnterSelectEndorsementSequentiallyAsync(data.Resolve("{{data:select_endorsement_306}}"));
            await page.PressSelectEndorsementAsync("Tab");
            await page.ClickEndorsementMainAddEndorsementAsync();
            await page.ClickBadilyJustingAsync();
            await page.ClickPropertDamageAsync();
            await page.ClickPersonalAdvertisingAsync();
            await page.EnterSDescriptionLocationSequentiallyAsync(data.Resolve("{{data:DescriptionLocation}}"));
            await page.ClickOKAsync();
        }

        await page.WaitForSelectEndorsementAsync("Visible");
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_323}}"));
        await page.PressSelectEndorsementAsync("Tab");
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForOKAsync2("Visible");
        await page.ClickOKAsync();
        
        await page.WaitForSelectEndorsementAsync("Visible");
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_339}}"));
        await page.PressSelectEndorsementAsync("Tab");

        await page.ClickEndorsementMainAddEndorsementAsync();
        
        await page.EnterAggregateLimitSequentiallyAsync(data.Resolve("{{data:iframe_duck_creek_policy_aggregate_limit_346}}"));
        await page.WaitForOKAsync2("Visible");

        await page.ClickOKAsync();
        
        await page.WaitForSelectEndorsementAsync("Visible");
        
        if (data.Resolve("{{data:stateVariant}}") is not ("MO" or "NH" or "NY" or "UT" or "VA"))
        {
            await page.EnterSelectEndorsementSequentiallyAsync(data.Resolve("{{data:select_endorsement_360}}"));
            await page.PressSelectEndorsementAsync("Tab");
            await page.ClickEndorsementMainAddEndorsementAsync();
            await page.EnterIFRAMEDuckCreekPolicyExcludedDriverAsync(data.Resolve("{{data:iframe_duck_creek_policy_excluded_driver_363}}"));
            await page.WaitForOKAsync2("Visible");

            await page.ClickOKAsync();
        }
        await page.WaitForSelectEndorsementAsync("Visible");
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_383}}"));
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForOKAsync2("Visible");

        await page.ClickOKAsync();
        await page.WaitForSelectEndorsementAsync("Visible");
        if(data.Resolve("{{data:stateVariant}}") != "MS")
        {
            await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_399}}"));
            await page.PressSelectEndorsementAsync("Tab");

            await page.ClickEndorsementMainAddEndorsementAsync();
            await page.WaitForOKAsync2("Visible");

            await page.ClickOKAsync();
        }
        await page.WaitForSelectEndorsementAsync("Visible");
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_419}}"));
        await page.PressSelectEndorsementAsync("Tab");
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.EnterIFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedFarmLocationSAsync(data.Resolve("{{data:iframe_duck_creek_policy_address_es_or_description_s_of_designated_farm_location_s_422}}"));
        await page.WaitForOKAsync2("Visible");

        await page.ClickOKAsync();
        await page.WaitForSelectEndorsementAsync("Visible");

        if (data.Resolve("{{data:stateVariant}}") is not ("AR"))
        {
            await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_432}}"));
            await page.PressSelectEndorsementAsync("Tab");
            await page.ClickEndorsementMainAddEndorsementAsync();
            await page.EnterNameSOrDescriptionSAndDateSOfDesignatedActivitiesOrServicesAsync(data.Resolve("{{data:iframe_duck_creek_policy_name_s_or_description_s_and_date_s_of_designated_activities_or_services_439}}"));
            await page.WaitForOKAsync2("Visible");

            await page.ClickOKAsync();
        }
        await page.WaitForSelectEndorsementAsync("Visible");
        if (data.Resolve("{{data:stateVariant}}") is not ("IL" or "NH" or "NY" or "VT"))
        {
            await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_449}}"));
            await page.PressSelectEndorsementAsync("Tab");
            await page.ClickEndorsementMainAddEndorsementAsync();
            await page.EnterIFRAMEDuckCreekPolicyNameSOrDescriptionSOfDesignatedAnimalSAsync(data.Resolve("{{data:iframe_duck_creek_policy_name_s_or_description_s_of_designated_animal_s_456}}"));
            await page.WaitForOKAsync2("Visible");

            await page.ClickOKAsync();
        }
        await page.WaitForSelectEndorsementAsync("Visible");
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_466}}"));
        await page.PressSelectEndorsementAsync("Tab");

        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.EnterIFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedPremisesAsync(data.Resolve("{{data:iframe_duck_creek_policy_address_es_or_description_s_of_designated_premises_473}}"));
        await page.WaitForOKAsync2("Visible");

        await page.ClickOKAsync();
        if(data.Resolve("{{data:stateVariant}}") == "UT")
        {
            await page.WaitForSelectEndorsementAsync("Visible");
            await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_502}}"));
            await page.PressSelectEndorsementAsync("Tab");
            await page.ClickEndorsementMainAddEndorsementAsync();
            await page.WaitForOKAsync2("Visible");

            await page.ClickOKAsync();
        }

        if(data.Resolve("{{data:stateVariant}}") == "WA")
        {
            await page.WaitForSelectEndorsementAsync("Visible");
            await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_502}}"));
            await page.PressSelectEndorsementAsync("Tab");
            await page.ClickEndorsementMainAddEndorsementAsync();
            await page.EnterIFRAMEDuckCreekPolicyWADescriptionOfPremisesOrActivitiesAsync(data.Resolve("{{data:test_premises_activities}}"));
            await page.WaitForOKAsync2("Visible");

            await page.ClickOKAsync();
        }

        if (data.Resolve("{{data:stateVariant}}") == "CT")
        {
            await page.WaitForSelectEndorsementAsync("Visible");
            await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_504}}"));
            await page.PressSelectEndorsementAsync("Tab");
            await page.ClickEndorsementMainAddEndorsementAsync();
            await page.WaitForOKAsync2("Visible");

            await page.ClickOKAsync();
            await page.WaitForSelectEndorsementAsync("Visible");
            await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_505}}"));
            await page.PressSelectEndorsementAsync("Tab");
            await page.ClickEndorsementMainAddEndorsementAsync();
            await page.WaitForOKAsync2("Visible");

            await page.ClickOKAsync();
        }

        if (data.Resolve("{{data:stateVariant}}") == "VT")
        {
            await page.WaitForSelectEndorsementAsync("Visible");
            await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_502}}"));
            await page.PressSelectEndorsementAsync("Tab");
            await page.ClickEndorsementMainAddEndorsementAsync();
            await page.WaitForOKAsync2("Visible");

            await page.ClickOKAsync();
            await page.WaitForSelectEndorsementAsync("Visible");
            await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_504}}"));
            await page.PressSelectEndorsementAsync("Tab");
            await page.ClickEndorsementMainAddEndorsementAsync();
            await page.WaitForOKAsync2("Visible");

            await page.ClickOKAsync();

            await page.WaitForSelectEndorsementAsync("Visible");
            await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_505}}"));
            await page.PressSelectEndorsementAsync("Tab");
            await page.ClickEndorsementMainAddEndorsementAsync();
            await page.WaitForOKAsync2("Visible");

            await page.ClickOKAsync();

            await page.WaitForSelectEndorsementAsync("Visible");
            await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_506}}"));
            await page.PressSelectEndorsementAsync("Tab");
            await page.ClickEndorsementMainAddEndorsementAsync();
            await page.WaitForOKAsync2("Visible");

            await page.ClickOKAsync();
        }
        await page.WaitForSelectEndorsementAsync("Visible");
        await page.EnterSelectEndorsementAsync(data.Resolve("{{data:select_endorsement_503}}"));
        await page.PressSelectEndorsementAsync("Tab");
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.WaitForOKAsync2("Visible");

        await page.ClickOKAsync();
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
        await page.ClickIFRAMEDuckCreekPolicyOtherCheckBoxAsync();
        await page.EnterIFRAMEDuckCreekPolicyDescriptionOfOtherSequentiallyAsync(data.Resolve("{{data:iframe_duck_creek_policy_description_of_other_517}}"));
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
        await page.ClickUWQuestionsUmbrellaUpdateAnswersAsync();
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
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_531}}"));
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
        await page.EnterTextBoxSequentiallyAsync(data.Resolve("Test {B[Product (LOB)]}"));
        await page.ClickOKAsync();
        //await page.ClickSaveForLaterAsync();
        //await page.ClickOKAsync();
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
        await page.PauseAsync(5000);
        await page.WaitStoplightWaitingWindowCloseAsync("Visible");
        await page.ClickStoplightWaitingWindowFirstCloseButtonOnErrorAsync();
        await page.PauseAsync(1000);
        await page.VerifyAllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabsAsync("Absent", "");
    }

    [Given(@"^I complete forms verification UMB$")]
    [When(@"^I complete forms verification UMB$")]
    [Then(@"^I complete forms verification UMB$")]
    public async Task CompleteFormsVerificationUMBAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        //await page.EnterSessionIDAsync(data.Resolve("{B[SessionId]}"));
        //await page.VerifyStatusCodeAsync(data.Resolve("{{data:expected_statuscode_value_594}}"), "value");
        //await page.PauseAsync(1000);
        //await page.PauseAsync(1000);

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
