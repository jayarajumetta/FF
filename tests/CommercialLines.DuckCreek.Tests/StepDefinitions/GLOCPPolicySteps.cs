using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "GL OCP Policy")]
public sealed class GLOCPPolicySteps
{
    private readonly ScenarioContext _scenario;
    public GLOCPPolicySteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I enter individual client information$")]
    [When(@"^I enter individual client information$")]
    [Then(@"^I enter individual client information$")]
    public async Task EnterIndividualClientInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("LastName_0040", "^[a-z]{4}$");
        data.GenerateRandom("PrimaryPhone_0041", "[0-9]{10}");
        data.GenerateRandom("InsuredSSN", "125[0-9]{6}");
        data.GenerateRandom("AuditTelephone_0048", "[0-9]{10}");
        data.GenerateRandom("InspectionTelephone_0048", "[0-9]{10}");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.SetQuickQuoteAsync(data.Resolve("{{data:quick_quote_1}}"));
        await page.WaitForUnderwritingInfoAsync("Exists");
        await page.EnterInsuredTypeAsync(data.Resolve("{{data:insured_type_3}}"));
        await page.PressInsuredTypeAsync("Enter");
        await page.PressInsuredTypeAsync("Tab");
        await page.PressInsuredTypeAsync("Tab");
        await page.PressInsuredTypeAsync("Tab");
        await page.ClickEntityTypeAsync();
        await page.WaitForFirstName55A0BAsync("Visible");
        await page.PressFirstName55A0BAsync("TAB");
        await page.PressFirstName55A0BAsync("Tab");
        await page.EnterFirstName55A0BAsync(data.Resolve("{{data:first_name_7}}"));
        await page.PressFirstName55A0BAsync("CLICK");
        await page.PressFirstName55A0BAsync("Tab");
        await page.PressFirstName55A0BAsync("Tab");
        await page.EnterMiddleNameAsync(data.Resolve("{{data:middle_name_8}}"));
        await page.PressMiddleNameAsync("Tab");
        await page.PressMiddleNameAsync("Tab");
        await page.PressLastNameAsync("TAB");
        await page.PressLastNameAsync("Tab");
        await page.EnterDOBAsync("{DATE[][-40y][MM-dd-yyyy]}");
        await page.PressDOBAsync("Tab");
        await page.PressDOBAsync("Tab");
        if (data.Condition("State!=\"CA\""))
        {
                    await page.EnterGender1DC4AAsync(data.Resolve("{{data:gender_11}}"));
                    await page.PressGender1DC4AAsync("Tab");
                    await page.PressGender1DC4AAsync("Tab");
        }
        await page.EnterEntityTypeAsync(data.Resolve("{{data:entity_type_13}}"));
        await page.PressEntityTypeAsync("Enter");
        await page.PressEntityTypeAsync("Tab");
        await page.PressEntityTypeAsync("Tab");
        await page.EnterAddress17A1FBAsync(data.Resolve("{{data:address1_15}}"));
        await page.PressAddress17A1FBAsync("Tab");
        await page.PressAddress17A1FBAsync("Tab");
        await page.EnterZipCode26D22Async(data.Resolve("{{data:zipcode_16}}"));
        await page.PressZipCode26D22Async("Tab");
        await page.PressZipCode26D22Async("Tab");
        await page.ClickClientSearchCA696Async();
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
        await page.WaitForOrderSSN68C87Async("Exists");
        await page.ClickOrderSSN68C87Async();
        await page.WaitForEnterSSN6B3FBAsync("Exists");
        await page.PressEnterSSN6B3FBAsync("TAB");
        await page.PressEnterSSN6B3FBAsync("Enter");
        data.Set("SSN", await page.CaptureEnterSSN6B3FBAsync("InnerText"));
        await page.ClickEnterSSN6B3FBAsync();
        await page.PressEnterSSN6B3FBAsync("Doubleclick");
        await page.PressEnterSSN6B3FBAsync("Tab");
        await page.ClickVerify8CDBEAsync();
        await page.WaitForVerify8CDBEAsync("Absent");
        data.Set("Last4SSN", data.Resolve("{B[SSN]}"));
        await page.WaitForSocialSecurityAsync("Equal");
        await page.VerifySocialSecurityAsync(data.Resolve("XXX-XX-{B[Last4SSN]}"), "InnerText");
        await page.WaitForPleaseVerifySSN3EAB9Async("Absent");
        if (data.Condition("'Product (LOB)' != \"UMB\""))
        {
                    await page.EnterNameOfAuditContactAsync(data.Resolve("{{data:name_of_audit_contact_33}}"));
                    await page.PressNameOfAuditContactAsync("Tab");
                    await page.PressNameOfAuditContactAsync("CLICK");
                    await page.PressNameOfAuditContactAsync("Tab");
                    await page.PressNameOfAuditContactAsync("Tab");
        }
        if (data.Condition("'Product (LOB)' != \"UMB\""))
        {
        }
        await page.EnterNameOfInspectionContactAsync(data.Resolve("{{data:name_of_inspection_contact_35}}"));
        await page.PressNameOfInspectionContactAsync("Tab");
        await page.PressNameOfInspectionContactAsync("CLICK");
        await page.PressNameOfInspectionContactAsync("Tab");
        await page.EnterInsuredEMailAddressAsync(data.Resolve("{{data:insured_e_mail_address_37}}"));
        await page.PressInsuredEMailAddressAsync("Tab");
        await page.PressInsuredEMailAddressAsync("CLICK");
        await page.PressInsuredEMailAddressAsync("Tab");
        await page.EnterWebsiteAddressAsync(data.Resolve("{{data:website_address_38}}"));
        await page.PressWebsiteAddressAsync("Tab");
        await page.PressAddress2Async("TAB");
        await page.PressAddress2Async("Tab");
        await page.VerifyZipCode26D22Async("[0-9]{5}-[0-9]{4}", "Regex:value");
        data.Set("State", data.Resolve("{{data:state}}"));
        data.Set("Product (LOB)", data.Resolve("{{data:product_lob}}"));
        data.Set("Server", data.Resolve("{{data:server}}"));
        data.Set("FormOnPolicyDocName", data.Resolve("{{data:formonpolicydocname}}"));

    }

    [Given(@"^I complete Underwriting Info from Client Screen$")]
    [When(@"^I complete Underwriting Info from Client Screen$")]
    [Then(@"^I complete Underwriting Info from Client Screen$")]
    public async Task CompleteUnderwritingInfoFromClientScreenAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickUnderwritingInfoAsync();
        await page.WaitForGeneralUWQuestionsAsync("Exists");
        await page.ClickUpdateAnswers9CB86Async();
        await page.ClickInsuranceHistoryAsync();
        await page.WaitForIsThereAPriorCarrierAsync("Exists");
        await page.EnterIsThereAPriorCarrierAsync(data.Resolve("{{data:is_there_a_prior_carrier_50}}"));
        await page.PressIsThereAPriorCarrierAsync("Tab");
        await page.WaitForCarrierAsync("Exists");
        await page.EnterCarrierAsync(data.Resolve("{{data:carrier_52}}"));
        await page.PressCarrierAsync("Tab");
        await page.PressCarrierAsync("Tab");
        await page.EnterPolicyNumberBA28EAsync(data.Resolve("{{data:policy_number_53}}"));
        await page.PressPolicyNumberBA28EAsync("Tab");
        await page.EnterPolicyTypeAsync(data.Resolve("{{data:policy_type_54}}"));
        await page.PressPolicyTypeAsync("Tab");
        await page.EnterEffectiveDateB557FAsync("{DATE[][-2y][MM'/'dd'/'yyyy]}");
        await page.PressEffectiveDateB557FAsync("Tab");
        await page.EnterExpirationDate34EACAsync("{DATE[][][MM'/'dd'/'yyyy]}");
        await page.PressExpirationDate34EACAsync("Tab");
        await page.EnterModificationFactorAsync(data.Resolve("{{data:modificationfactor_57}}"));
        await page.PressModificationFactorAsync("Tab");
        await page.EnterTotalPremiumAsync(data.Resolve("{{data:total_premium_58}}"));
        await page.PressTotalPremiumAsync("Tab");
        await page.ClickOtherInsuranceHistoryOKAsync();
        await page.WaitForDetail0F8C6Async("Exists");
        await page.ClickLossExperienceAsync();
        await page.WaitForNoKnownLossesAsync("Exists");
        await page.SetNoKnownLossesAsync(data.Resolve("{{data:no_known_losses_63}}"));
        await page.PressNoKnownLossesAsync("Tab");
        await page.ClickReturnToQuoteAsync();
        await page.EnterTitleAsync(data.Resolve("{{data:title_65}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_66}}"));
        await page.VerifyResultAsync(data.Resolve("{{data:expected_result_value_67}}"), "value");

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
        await page.EnterEffectiveDate95094Async(data.Resolve("{{data:effectivedate_71}}"));
        await page.PressEffectiveDate95094Async("Tab");
        await page.PauseAsync(1000);
        if (data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_73}}"));
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
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_77}}"));
        await page.PressWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync("Tab");
        await page.PressWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync("Tab");
        data.Set("StateIsKansas", "Arizona==\"Kansas\"; Expression= 'Arizona'=='Kansas'");
        data.Set("StateIsVirginia", "Arizona==\"Virginia\"; Expression= 'Arizona'=='Virginia'");
        if (data.Condition("'Product (LOB)' == \"GL OCP\""))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_80}}"));
                    await page.PressPrimaryRatingStateAsync("Tab");
        }
        if (data.Condition("'Product (LOB)' == \"GL OCP\""))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_81}}"));
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
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_85}}"));
        await page.PressWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync("CLICK");
        await page.PressWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync("Enter");
        await page.PressWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync("Tab");
        await page.VerifyPriorAmericanNationalPolicyAsync("Absent", "");
        await page.VerifyWhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNationalAsync("Absent", "");
        await page.VerifyIsThisPolicyBeingFullyCancelledAsync("Absent", "");
        if (data.Condition("'Product (LOB)' == \"SFP\"||'Product (LOB)' == \"GL OCP\""))
        {
                    await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_89}}"));
        }
        await page.PauseAsync(1000);
        await page.WaitForPolicyInfoHeaderAsync("Visible");
        await page.WaitForDescriptionOfSpecifiedOperationAsync("Visible");
        await page.PressDescriptionOfSpecifiedOperationAsync("TAB");
        await page.EnterDescriptionOfSpecifiedOperationAsync("AZ GL OCP Basic {NMONTH}.{NDAY}.{NYEAR} {Time}");
        await page.PressDescriptionOfSpecifiedOperationAsync("Tab");
        await page.VerifyDescriptionOfSpecifiedOperationAsync("{XB[QuoteDescription]}", "value");

    }

    [Given(@"^I complete OCP Fields$")]
    [When(@"^I complete OCP Fields$")]
    [Then(@"^I complete OCP Fields$")]
    public async Task CompleteOCPFieldsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickPolicyCovg50C98Async();
        await page.WaitForPolicyCovg6B651Async("Exists");
        if (data.Condition("'Coverage Form' != NULL"))
        {
                    await page.EnterCoverageForm3B382Async(data.Resolve("{{data:coverage_form_98}}"));
                    await page.PressCoverageForm3B382Async("CLICK");
                    await page.PressCoverageForm3B382Async("Enter");
                    await page.PressCoverageForm3B382Async("Tab");
        }
        if (data.Condition("'Occurence Limit' != NULL"))
        {
                    await page.EnterOccurenceLimitAsync(data.Resolve("{{data:occurence_limit_99}}"));
                    await page.PressOccurenceLimitAsync("CLICK");
                    await page.PressOccurenceLimitAsync("Enter");
                    await page.PressOccurenceLimitAsync("Tab");
        }
        if (data.Condition("'Aggregate Limit' != NULL"))
        {
                    await page.EnterAggregateLimitAsync(data.Resolve("{{data:aggregate_limit_100}}"));
                    await page.PressAggregateLimitAsync("CLICK");
                    await page.PressAggregateLimitAsync("Enter");
                    await page.PressAggregateLimitAsync("Tab");
        }
        if (data.Condition("(State == \"NJ\")||(State == \"WV\")||(State == \"MA\")||(State == \"CT\")||(State == \"ME\")||(State == \"NH\")||(State == \"OR\")||(State == \"AZ\")||(State == \"PA\")||(State == \"MD\")||(State == \"DE\")||(State == \"RI\")||(State == \"VA\")||(State == \"VT\")&& 'Coverage Form' != \"OCP\""))
        {
                    await page.EnterOfFullTimeEmployeesAsync("");
        }
        if (data.Condition("(State == \"NJ\")||(State == \"WV\")||(State == \"MA\") ||(State == \"CT\")||(State == \"ME\")||(State == \"NH\")||(State == \"OR\")||(State == \"AZ\")||(State == \"PA\")||(State == \"MD\")||(State == \"DE\")||(State == \"RI\")||(State == \"VA\")||(State == \"VT\")&& 'Coverage Form' != \"OCP\""))
        {
                    await page.EnterOfPartTimeEmployeesAsync("");
        }
        if (data.Condition("(State == \"NJ\")||(State == \"WV\")||(State == \"MA\")||(State == \"CT\")||(State == \"ME\")||(State == \"NH\")||(State == \"OR\") ||(State == \"AZ\")||(State == \"PA\")||(State == \"MD\")||(State == \"DE\")||(State == \"RI\")||(State == \"VA\")||(State == \"VT\")&& 'Coverage Form' != \"OCP\""))
        {
                    await page.EnterOfSeasonalTemporaryEmployeesAsync("");
        }
        if (data.Condition("'Coverage Form' != NULL"))
        {
                    await page.WaitForCoverageForm3B382Async("Equal");
        }

    }

    [Given(@"^I complete OCP Risk Fields$")]
    [When(@"^I complete OCP Risk Fields$")]
    [Then(@"^I complete OCP Risk Fields$")]
    public async Task CompleteOCPRiskFieldsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickOCPAsync();
        await page.WaitForRiskHeadingAsync("Exists");
        await page.EnterType885AAAsync(data.Resolve("{{data:type_107}}"));
        await page.PressType885AAAsync("CLICK");
        await page.PressType885AAAsync("Enter");
        await page.PressType885AAAsync("Tab");
        await page.EnterClassCodeAsync(data.Resolve("{{data:class_code_108}}"));
        await page.PressClassCodeAsync("CLICK");
        await page.PressClassCodeAsync("Tab");
        await page.PressClassCodeAsync("Tab");
        await page.EnterState16B92Async(data.Resolve("{{data:state_109}}"));
        await page.PressState16B92Async("Tab");
        await page.PressState16B92Async("Tab");
        await page.EnterTotalCostOfWorkAsync(data.Resolve("{{data:total_cost_of_work_110}}"));
        await page.PressTotalCostOfWorkAsync("Tab");
        await page.PressTotalCostOfWorkAsync("Tab");
        await page.EnterLocationOfCoveredOperationsAsync(data.Resolve("{{data:location_of_covered_operations_111}}"));
        await page.PressLocationOfCoveredOperationsAsync("Tab");
        await page.PressLocationOfCoveredOperationsAsync("Tab");
        await page.EnterPolicyHolderNameAsync(data.Resolve("{{data:policy_holder_name_112}}"));
        await page.PressPolicyHolderNameAsync("Tab");
        await page.PressPolicyHolderNameAsync("Tab");
        await page.EnterAddress1BE797Async(data.Resolve("{{data:address_1_113}}"));
        await page.PressAddress1BE797Async("Tab");
        await page.PressAddress1BE797Async("Tab");
        await page.EnterZipCodeC7591Async(data.Resolve("{{data:zip_code_114}}"));
        await page.PressZipCodeC7591Async("Tab");
        await page.PressZipCodeC7591Async("CLICK");
        await page.PressZipCodeC7591Async("Tab");
        await page.ClickCommonNavigationLinksNextAsync();
        await page.ClickOCPAsync();
        await page.WaitForRiskHeadingAsync("Exists");
        await page.EnterType885AAAsync(data.Resolve("{{data:type_118}}"));
        await page.PressType885AAAsync("CLICK");
        await page.PressType885AAAsync("Enter");
        await page.PressType885AAAsync("Tab");
        await page.EnterClassCodeAsync(data.Resolve("{{data:class_code_119}}"));
        await page.PressClassCodeAsync("CLICK");
        await page.PressClassCodeAsync("Tab");
        await page.PressClassCodeAsync("Tab");
        await page.EnterState16B92Async(data.Resolve("{{data:state_120}}"));
        await page.PressState16B92Async("Tab");
        await page.PressState16B92Async("Tab");
        await page.EnterTotalCostOfWorkAsync("");
        await page.EnterLocationOfCoveredOperationsAsync(data.Resolve("{{data:location_of_covered_operations_122}}"));
        await page.PressLocationOfCoveredOperationsAsync("Tab");
        await page.PressLocationOfCoveredOperationsAsync("Tab");
        await page.EnterPolicyHolderNameAsync(data.Resolve("{{data:policy_holder_name_123}}"));
        await page.PressPolicyHolderNameAsync("Tab");
        await page.PressPolicyHolderNameAsync("Tab");
        await page.EnterAddress1BE797Async(data.Resolve("{{data:address_1_124}}"));
        await page.PressAddress1BE797Async("Tab");
        await page.PressAddress1BE797Async("Tab");
        await page.EnterZipCodeC7591Async(data.Resolve("{{data:zip_code_125}}"));
        await page.PressZipCodeC7591Async("Tab");
        await page.PressZipCodeC7591Async("CLICK");
        await page.PressZipCodeC7591Async("Tab");
        await page.ClickCommonNavigationLinksNextAsync();
        await page.ClickOCPAsync();
        await page.WaitForRiskHeadingAsync("Exists");
        await page.EnterType885AAAsync(data.Resolve("{{data:type_129}}"));
        await page.PressType885AAAsync("CLICK");
        await page.PressType885AAAsync("Enter");
        await page.PressType885AAAsync("Tab");
        await page.EnterClassCodeAsync(data.Resolve("{{data:class_code_130}}"));
        await page.PressClassCodeAsync("CLICK");
        await page.PressClassCodeAsync("Tab");
        await page.PressClassCodeAsync("Tab");
        await page.EnterState16B92Async(data.Resolve("{{data:state_131}}"));
        await page.PressState16B92Async("Tab");
        await page.PressState16B92Async("Tab");
        await page.EnterTotalCostOfWorkAsync("");
        await page.EnterLocationOfCoveredOperationsAsync(data.Resolve("{{data:location_of_covered_operations_133}}"));
        await page.PressLocationOfCoveredOperationsAsync("Tab");
        await page.PressLocationOfCoveredOperationsAsync("Tab");
        await page.EnterPolicyHolderNameAsync(data.Resolve("{{data:policy_holder_name_134}}"));
        await page.PressPolicyHolderNameAsync("Tab");
        await page.PressPolicyHolderNameAsync("Tab");
        await page.EnterAddress1BE797Async(data.Resolve("{{data:address_1_135}}"));
        await page.PressAddress1BE797Async("Tab");
        await page.PressAddress1BE797Async("Tab");
        await page.EnterZipCodeC7591Async(data.Resolve("{{data:zip_code_136}}"));
        await page.PressZipCodeC7591Async("Tab");
        await page.PressZipCodeC7591Async("CLICK");
        await page.PressZipCodeC7591Async("Tab");
        await page.ClickCommonNavigationLinksNextAsync();

    }

    [Given(@"^I complete \\[CG0424\\] Coverage for Injury to Leased Workers$")]
    [When(@"^I complete \\[CG0424\\] Coverage for Injury to Leased Workers$")]
    [Then(@"^I complete \\[CG0424\\] Coverage for Injury to Leased Workers$")]
    public async Task CompleteCG0424CoverageForInjuryToLeasedWorkersAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickEndorsements7572EAsync();
        await page.WaitForEndorsements9626EAsync("Exists");
        await page.ClickAddEndorsementA9973Async();
        if (data.Condition("'Endorsement Type' != NULL"))
        {
                    await page.EnterEndorsementTypeCE99FAsync(data.Resolve("{{data:endorsement_type_141}}"));
                    await page.PressEndorsementTypeCE99FAsync("Tab");
                    await page.PressEndorsementTypeCE99FAsync("Tab");
        }
        await page.EnterWhyIsThisCoverageDesiredAsync(data.Resolve("{{data:why_is_this_coverage_desired_142}}"));
        await page.PressWhyIsThisCoverageDesiredAsync("Tab");
        await page.PressWhyIsThisCoverageDesiredAsync("Tab");
        await page.ClickCG0424CoverageForInjuryToLeasedWorkersOKAsync();

    }

    [Given(@"^I complete \\[CG2401\\] Non\\-Binding Arbitration$")]
    [When(@"^I complete \\[CG2401\\] Non\\-Binding Arbitration$")]
    [Then(@"^I complete \\[CG2401\\] Non\\-Binding Arbitration$")]
    public async Task CompleteCG2401NonBindingArbitrationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickEndorsements7572EAsync();
        await page.WaitForEndorsements9626EAsync("Exists");
        await page.ClickAddEndorsementA9973Async();
        if (data.Condition("'Endorsement Type' != NULL"))
        {
                    await page.EnterEndorsementType3503EAsync(data.Resolve("{{data:endorsement_type_147}}"));
                    await page.PressEndorsementType3503EAsync("Tab");
                    await page.PressEndorsementType3503EAsync("Tab");
        }
        await page.ClickCG2401NonBindingArbitrationOKAsync();

    }

    [Given(@"^I complete \\[CG2812\\] Pesticide or Herbicide Applicator Coverage$")]
    [When(@"^I complete \\[CG2812\\] Pesticide or Herbicide Applicator Coverage$")]
    [Then(@"^I complete \\[CG2812\\] Pesticide or Herbicide Applicator Coverage$")]
    public async Task CompleteCG2812PesticideOrHerbicideApplicatorCoverageAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickEndorsements7572EAsync();
        await page.WaitForEndorsements9626EAsync("Exists");
        await page.ClickAddEndorsementA9973Async();
        if (data.Condition("'Endorsement Type' != NULL"))
        {
                    await page.EnterEndorsementTypeC75E4Async(data.Resolve("{{data:endorsement_type_152}}"));
                    await page.PressEndorsementTypeC75E4Async("Tab");
                    await page.PressEndorsementTypeC75E4Async("Tab");
        }
        await page.EnterDescriptionOfOperationsAsync(data.Resolve("{{data:description_of_operations_153}}"));
        await page.PressDescriptionOfOperationsAsync("Tab");
        await page.PressDescriptionOfOperationsAsync("Tab");
        await page.ClickCG2812PesticideOrHerbicideApplicatorCoverageOKAsync();

    }

    [Given(@"^I complete \\[CG3132\\] Limited Fungi or Bacteria Coverage$")]
    [When(@"^I complete \\[CG3132\\] Limited Fungi or Bacteria Coverage$")]
    [Then(@"^I complete \\[CG3132\\] Limited Fungi or Bacteria Coverage$")]
    public async Task CompleteCG3132LimitedFungiOrBacteriaCoverageAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickEndorsements7572EAsync();
        await page.WaitForEndorsements9626EAsync("Exists");
        await page.ClickAddEndorsementAsync();
        if (data.Condition("'Endorsement Type' != NULL"))
        {
                    await page.EnterEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_158}}"));
                    await page.PressEndorsementTypeAsync("Tab");
                    await page.PressEndorsementTypeAsync("Tab");
        }
        await page.ClickCG3132LimitedFungiOrBacteriaCoverageOKAsync();

    }

    [Given(@"^I complete \\[CG 20 31\\] Add'l Insured\\-Engineers, Architects OCP$")]
    [When(@"^I complete \\[CG 20 31\\] Add'l Insured\\-Engineers, Architects OCP$")]
    [Then(@"^I complete \\[CG 20 31\\] Add'l Insured\\-Engineers, Architects OCP$")]
    public async Task CompleteCG2031AddLInsuredEngineersArchitectsOCPAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickAddlInterestsE39FCAsync();
        await page.WaitForAddlInterestsA10A4Async("Exists");
        await page.ClickAddAddlInterestAsync();
        await page.EnterTypeD972CAsync(data.Resolve("{{data:type_163}}"));
        await page.PressTypeD972CAsync("Tab");
        await page.PressTypeD972CAsync("Tab");
        await page.ClickOKAsync();

    }

    [Given(@"^I complete \\[CG 29 35\\] Add'l Insured\\-State or Political \\(Permits\\)$")]
    [When(@"^I complete \\[CG 29 35\\] Add'l Insured\\-State or Political \\(Permits\\)$")]
    [Then(@"^I complete \\[CG 29 35\\] Add'l Insured\\-State or Political \\(Permits\\)$")]
    public async Task CompleteCG2935AddLInsuredStateOrPoliticalPermitsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickAddlInterestsE39FCAsync();
        await page.WaitForAddlInterestsA10A4Async("Exists");
        await page.ClickAddAddlInterestAsync();
        await page.EnterTypeCDE3BAsync(data.Resolve("{{data:type_168}}"));
        await page.PressTypeCDE3BAsync("Tab");
        await page.PressTypeCDE3BAsync("Tab");
        await page.EnterStateOrPoliticalSubdivisionAsync(data.Resolve("{{data:state_or_political_subdivision_169}}"));
        await page.PressStateOrPoliticalSubdivisionAsync("Tab");
        await page.PressStateOrPoliticalSubdivisionAsync("Tab");
        await page.EnterAddress19B8B5Async(data.Resolve("{{data:address_1_170}}"));
        await page.PressAddress19B8B5Async("Tab");
        await page.PressAddress19B8B5Async("Tab");
        await page.EnterZipCodeC048FAsync(data.Resolve("{{data:zip_code_171}}"));
        await page.PressZipCodeC048FAsync("Tab");
        await page.PressZipCodeC048FAsync("Tab");
        await page.ClickCG2935AddLInsuredStateOrPoliticalPermitsOKAsync();

    }

    [Given(@"^I complete \\[FG0013\\] \\- Automatic Additional Insured \\- Specific$")]
    [When(@"^I complete \\[FG0013\\] \\- Automatic Additional Insured \\- Specific$")]
    [Then(@"^I complete \\[FG0013\\] \\- Automatic Additional Insured \\- Specific$")]
    public async Task CompleteFG0013AutomaticAdditionalInsuredSpecificAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickAddlInterestsE39FCAsync();
        await page.WaitForAddlInterestsA10A4Async("Exists");
        await page.ClickAddAddlInterestAsync();
        await page.EnterType56F72Async(data.Resolve("{{data:type_176}}"));
        await page.PressType56F72Async("Tab");
        await page.PressType56F72Async("Tab");
        await page.EnterDoesTheInsuredEverEnterIntoContractsForTasksNotContemplatedInTheCurrentLiabilityClassificationsOnThePolicyAsync(data.Resolve("{{data:does_the_insured_ever_enter_into_contracts_for_tasks_not_contemplated_in_the_current_liability_classifications_on_the_policy_177}}"));
        await page.PressDoesTheInsuredEverEnterIntoContractsForTasksNotContemplatedInTheCurrentLiabilityClassificationsOnThePolicyAsync("Tab");
        await page.PressDoesTheInsuredEverEnterIntoContractsForTasksNotContemplatedInTheCurrentLiabilityClassificationsOnThePolicyAsync("Tab");
        await page.EnterIfYesExplainAsync(data.Resolve("{{data:if_yes_explain_178}}"));
        await page.PressIfYesExplainAsync("Tab");
        await page.PressIfYesExplainAsync("Tab");
        await page.EnterDoesTheInsuredApplicantRequestAdditionalInsuredStatusWithoutAWrittenContractRequirementAsync(data.Resolve("{{data:does_the_insured_applicant_request_additional_insured_status_without_a_written_contract_requirement_179}}"));
        await page.PressDoesTheInsuredApplicantRequestAdditionalInsuredStatusWithoutAWrittenContractRequirementAsync("Tab");
        await page.PressDoesTheInsuredApplicantRequestAdditionalInsuredStatusWithoutAWrittenContractRequirementAsync("Tab");
        await page.EnterDoesTheInsuredEnterIntoContractsInvolvingCommercialSnowRemovalIncludingSnowRemovalFromResidentialRoofsAsync(data.Resolve("{{data:does_the_insured_enter_into_contracts_involving_commercial_snow_removal_including_snow_removal_from_residential_roofs_180}}"));
        await page.PressDoesTheInsuredEnterIntoContractsInvolvingCommercialSnowRemovalIncludingSnowRemovalFromResidentialRoofsAsync("Tab");
        await page.PressDoesTheInsuredEnterIntoContractsInvolvingCommercialSnowRemovalIncludingSnowRemovalFromResidentialRoofsAsync("Tab");
        await page.ClickFG0013AutomaticAdditionalInsuredSpecificRelationshipOKAsync();

    }

    [Given(@"^I answer GL UW Questions OR \\& WA$")]
    [When(@"^I answer GL UW Questions OR \\& WA$")]
    [Then(@"^I answer GL UW Questions OR \\& WA$")]
    public async Task AnswerGLUWQuestionsORWAAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickGLUWQuestionsAsync();
        await page.WaitForGeneralLiabilityInformationAsync("Exists");
        await page.ClickUpdateAnswersFB765Async();
        await page.EnterDescribeAllHoldHarmlessAgreementsAndPleaseProvideACopyAsync(data.Resolve("{{data:describe_all_hold_harmless_agreements_and_please_provide_a_copy_185}}"));
        await page.PressDescribeAllHoldHarmlessAgreementsAndPleaseProvideACopyAsync("Tab");
        await page.PressDescribeAllHoldHarmlessAgreementsAndPleaseProvideACopyAsync("Tab");
        await page.ClickGeneralLiabilityInformationOKAsync();
        await page.ClickGLUWQuestionsAsync();
        await page.WaitForGeneralLiabilityInformationAsync("Exists");
        await page.ClickProductsCompletedOpsButtonAsync();
        await page.WaitForProductsCompletedOpsAsync("Exists");
        await page.ClickUpdateAnswers69564Async();
        await page.ClickProductsCompletedOpsOKAsync();

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
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_195}}"));
        await page.PressBillTypeAsync("Tab");
        await page.PressBillTypeAsync("TAB");
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_198}}"));
        await page.PressPayPlanAsync("Tab");
        await page.PressPayPlanAsync("TAB");
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_202}}"));
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
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_213}}"));
        await page.PressIsThisCoverageBoundAsync("Tab");
        await page.PressIsThisCoverageBoundAsync("CLICK");
        await page.PressIsThisCoverageBoundAsync("Tab");
        await page.VerifyOrderAuditAsync("Exists", "");
        await page.EnterOrderAuditAsync(data.Resolve("{{data:order_audit_215}}"));
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
        await page.VerifyIsThisCoverageBoundAsync(data.Resolve("{{data:expected_is_this_coverage_bound_value_223}}"), "Value");
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_224}}"));
        await page.PressIsThisCoverageBoundAsync("Tab");
        await page.PressIsThisCoverageBoundAsync("Tab");
        await page.ClickCompleteApplicationAsync();
        await page.VerifyStoplightWaitingWindowCloseAsync("Absent", "");
        await page.PauseAsync(1000);
        await page.VerifyStoplightWaitingWindowErrorAsync("Exists", "");
        data.Set("ErrorFlag", data.Resolve("{{data:errorflag}}"));
        data.Set("ErrorFlag", data.Resolve("{{data:errorflag_2}}"));
        data.Set("ErrorFlag", data.Resolve("{{data:errorflag_2}}"));
        data.Set("REPETITION", data.Resolve("{{data:repetition}}"));
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
        data.Set("NBPrem", data.Resolve("{{data:nbprem}}"));

    }

    [Given(@"^I verify values in premium fields$")]
    [When(@"^I verify values in premium fields$")]
    [Then(@"^I verify values in premium fields$")]
    public async Task VerifyValuesInPremiumFieldsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyFullTermPremiumAsync(data.Resolve("{{data:expected_full_term_premium_value_256}}"), "value");
        await page.VerifyPremiumWrittenAsync(data.Resolve("{{data:expected_premium_written_value_257}}"), "value");
        await page.VerifyPriorPremiumAsync(data.Resolve("{{data:expected_prior_premium_value_258}}"), "value");
        await page.VerifyPremiumChangeAsync(data.Resolve("{{data:expected_premium_change_value_259}}"), "value");
        await page.EnterTitleAsync(data.Resolve("{{data:title_261}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_262}}"));
        await page.VerifyResultAsync("{XB[SessionId]}", "value");
        data.Set("ServerAddress", data.Resolve("{{data:serveraddress}}"));

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
        await page.VerifyStatusCodeAsync(data.Resolve("{{data:expected_statuscode_value_266}}"), "value");
        await page.PauseAsync(1000);
        await page.PauseAsync(1000);
        data.Set("PowershellArguments", data.Resolve("powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\GL_OCP\\\" -FileName \"GL_OCP_BASIC\" -State  \"AZ\" -QuoteID \"{B[QuoteID]}\""));
        data.Set("SummaryResults", await page.CaptureValueAsync("InnerText"));
        data.Set("SummaryResults", data.Resolve("{{data:summaryresults}}"));
        data.Set("SummaryResults", data.Resolve("{{data:summaryresults_2}}"));
        data.Set("SummaryResults", data.Resolve("{{data:summaryresults_3}}"));
        data.Set("SummaryResults", data.Resolve("{{data:summaryresults_4}}"));

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
