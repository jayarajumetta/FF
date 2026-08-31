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
        await page.EnterCommercialAutoPolicyNumberAsync(data.Resolve("{{data:policy_number_163}}"));
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
        await page.EnterGeneralLiabilityPolicyNumberAsync(data.Resolve("{{data:policy_number_173}}"));
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
            await page.EnterCGLLimitsAsync(data.Resolve("{{data:cgl_limits_177}}"));
        }
        if (data.Condition("'GL Policy Number' == \"GLPOL#\""))
        {
            await page.EnterGeneralLiabilityTotalSubjectPremiumAsync(data.Resolve("{{data:total_subject_premium_178}}"));
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
        await page.EnterPolicyNumberAsync(data.Resolve("{{data:policy_number_183}}"));
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

        await page.WaitForEmployersLiabAsync("Visible");
        await page.ClickEmployersLiabAsync();
        await page.EnterBusinessownersPolicyNumberAsync(data.Resolve("{{data:policy_number_192}}"));
        if (data.Condition("'WC Policy Number' != \"WCPOL#\""))
        {
            await page.ClickImportPolicyDataButtonAsync();
        }
        await page.WaitForBusinessownersEffectiveDateAsync("NotEqual");
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

        await page.WaitForCPPLiabilityAsync("Visible");
        await page.ClickCPPLiabilityAsync();
        await page.EnterBusinessownersPolicyNumberAsync(data.Resolve("{{data:policy_number_200}}"));
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
            await page.EnterCommercialAutoLiabilityLimitAsync(data.Resolve("{{data:liability_limit_204}}"));
        }
        if (data.Condition("'CPP Policy Number' ==\"CPPPOL#\""))
        {
            await page.EnterBusinessownersTotalSubjectPremiumAsync(data.Resolve("{{data:total_subject_premium_205}}"));
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
        await page.EnterGeneralLiabilityPolicyNumberAsync(data.Resolve("{{data:policy_number_210}}"));
        await page.EnterCommercialAutoEffectiveDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.WaitForCommercialAutoEffectiveDateAsync("NotEqual");
        await page.EnterGeneralLiabilityExpirationDateAsync(data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        await page.EnterSFP10LiabilityFarmLiabilityLimitAsync(data.Resolve("{{data:liability_limit_214}}"));
        await page.EnterGeneralLiabilityTotalSubjectPremiumAsync(data.Resolve("{{data:total_subject_premium_215}}"));

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
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_249}}"));
        await page.VerifyOrderAuditAsync("Exists", "");
        await page.EnterOrderAuditAsync(data.Resolve("{{data:order_audit_251}}"));
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
        await page.VerifyIsThisCoverageBoundAsync(data.Resolve("{{data:expected_is_this_coverage_bound_value_259}}"), "Value");
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_260}}"));
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
