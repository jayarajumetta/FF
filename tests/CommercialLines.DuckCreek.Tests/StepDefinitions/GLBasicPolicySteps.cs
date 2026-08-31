using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "GL Basic Policy")]
public sealed class GLBasicPolicySteps
{
    private readonly ScenarioContext _scenario;
    public GLBasicPolicySteps(ScenarioContext scenario) => _scenario = scenario;

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

        await page.SetQuickQuoteAsync(data.Resolve("{{data:quick_quote_1}}"));
        await page.WaitForUnderwritingInfoAsync("Exists");
        await page.EnterInsuredTypeAsync(data.Resolve("{{data:insured_type_3}}"));
        await page.EnterEntityTypeAsync(data.Resolve("{{data:entity_type_13}}"));
        await page.WaitForFirstNameAsync("Visible");
        await page.EnterFirstNameAsync(data.Resolve("{{data:first_name_7}}"));
        await page.EnterMiddleNameAsync(data.Resolve("{{data:middle_name_8}}"));
        await page.EnterLastNameAsync(data.Resolve("{{runtime:LastName_0040}}"));
        await page.EnterDOBAsync(data.Resolve("{DATE[][-40y][MM-dd-yyyy]}"));
        if (data.Condition("State!=\"CA\""))
        {
            await page.EnterGenderAsync(data.Resolve("{{data:gender_11}}"));
        }
        await page.EnterPrimaryPhoneAsync(data.Resolve("{{runtime:PrimaryPhone_0041}}"));
        await page.EnterAddressAsync(data.Resolve("{{data:address1_15}}"));
        await page.EnterNamedInsuredZipCodeAsync(data.Resolve("{{data:zipcode_16}}"));
        await page.ClickClientSearchAsync();
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
        await page.WaitForOrderSSNAsync("Exists");
        await page.ClickOrderSSNAsync();
        await page.WaitForNamedInsuredIndividualEnterSSNAsync("Exists");
        await page.EnterNamedInsuredIndividualEnterSSNAsync(data.Resolve("{{runtime:InsuredSSN}}"));
        data.Set("Last4SSN", data.Get("InsuredSSN").Length >= 4 ? data.Get("InsuredSSN")[^4..] : data.Get("InsuredSSN"));
        await page.PressNamedInsuredIndividualEnterSSNAsync("Doubleclick");
        await page.ClickVerifyAsync();
        await page.WaitForVerifyAsync("Absent");
        await page.WaitForSocialSecurityAsync("Equal");
        await page.VerifySocialSecurityAsync(data.Resolve("XXX-XX-{B[Last4SSN]}"), "InnerText");
        await page.WaitForPleaseVerifySSNAsync("Absent");
        await page.EnterNameOfAuditContactAsync(data.Resolve("{{data:name_of_audit_contact_33}}"));
        await page.EnterAuditTelephoneAsync(data.Resolve("{{runtime:AuditTelephone_0048}}"));
        await page.EnterNameOfInspectionContactAsync(data.Resolve("{{data:name_of_inspection_contact_35}}"));
        await page.EnterInspectionTelephoneAsync(data.Resolve("{{runtime:InspectionTelephone_0048}}"));
        await page.EnterInsuredEMailAddressAsync(data.Resolve("{{data:insured_e_mail_address_37}}"));
        await page.EnterWebsiteAddressAsync(data.Resolve("{{data:website_address_38}}"));
        await page.VerifyNamedInsuredZipCodeAsync("[0-9]{5}-[0-9]{4}", "Regex:value");

    }

    [Given(@"^I complete Underwriting Info from Client Screen$")]
    [When(@"^I complete Underwriting Info from Client Screen$")]
    [Then(@"^I complete Underwriting Info from Client Screen$")]
    public async Task CompleteUnderwritingInfoFromClientScreenAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickUnderwritingInfoAsync();
        await page.WaitForGeneralUWQuestionsAsync("Exists");
        await page.ClickPropertyUWQuestionsUpdateAnswersAsync();
        await page.ClickInsuranceHistoryAsync();
        await page.WaitForIsThereAPriorCarrierAsync("Exists");
        await page.EnterIsThereAPriorCarrierAsync(data.Resolve("{{data:is_there_a_prior_carrier_50}}"));
        await page.WaitForCarrierAsync("Exists");
        await page.EnterCarrierAsync(data.Resolve("{{data:carrier_52}}"));
        await page.EnterGeneralLiabilityPolicyNumberAsync(data.Resolve("{{data:policy_number_53}}"));
        await page.EnterPolicyTypeAsync(data.Resolve("{{data:policy_type_54}}"));
        await page.EnterCommercialAutoEffectiveDateAsync(data.Resolve("{DATE[][-2y][MM'/'dd'/'yyyy]}"));
        await page.EnterGeneralLiabilityExpirationDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.EnterModificationFactorAsync(data.Resolve("{{data:modificationfactor_57}}"));
        await page.EnterTotalPremiumAsync(data.Resolve("{{data:total_premium_58}}"));
        await page.ClickOKAsync();
        await page.WaitForUnderwritingInfoOtherInsuranceHistoryDetailAsync("Exists");
        await page.ClickLossExperienceAsync();
        await page.WaitForNoKnownLossesAsync("Exists");
        await page.SetNoKnownLossesAsync(data.Resolve("{{data:no_known_losses_63}}"));
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

        await page.ClickPolicyInfoAsync();
        await page.WaitForPolicyInfoHeaderAsync("Exists");
        await page.PauseAsync(1000);
        await page.EnterPolicyInfoRequiredAndOptionalFieldsEffectiveDateAsync(data.Resolve("{{data:effectivedate_71}}"));
        await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_72}}"));
        await page.PauseAsync(1000);
        await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_74}}"));
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_78}}"));
        await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_81}}"));
        await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_82}}"));
        await page.PressPrimaryRatingStateAsync("Down");
        await page.PauseAsync(1000);
        await page.WaitForPrimaryRatingStateAsync("Exists");
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_86}}"));
        await page.VerifyPriorAmericanNationalPolicyAsync("Absent", "");
        await page.VerifyWhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNationalAsync("Absent", "");
        await page.VerifyIsThisPolicyBeingFullyCancelledAsync("Absent", "");
        await page.PauseAsync(1000);
        await page.WaitForPolicyInfoHeaderAsync("Visible");
        await page.WaitForDescriptionOfSpecifiedOperationAsync("Visible");
        await page.EnterDescriptionOfSpecifiedOperationAsync(data.BuildQuoteDescription());
        data.Set("QuoteDescription", await page.CaptureDescriptionOfSpecifiedOperationAsync("value"));

    }

    [Given(@"^I complete CGL Fields$")]
    [When(@"^I complete CGL Fields$")]
    [Then(@"^I complete CGL Fields$")]
    public async Task CompleteCGLFieldsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickPolicyCovgerageAsync();
        await page.WaitForPolicyCovgGLPolicyCovgAsync("Exists");
        if (data.Condition("'Coverage Form' != NULL"))
        {
            await page.EnterPolicyCovgGLCoverageFormAsync(data.Resolve("{{data:coverage_form_98}}"));
        }
        if (data.Condition("'Occurence Limit' != NULL"))
        {
            await page.EnterOccurenceLimitAsync(data.Resolve("{{data:occurence_limit_99}}"));
        }
        if (data.Condition("'Aggregate Limit' != NULL"))
        {
            await page.EnterAggregateLimitAsync(data.Resolve("{{data:aggregate_limit_100}}"));
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.EnterProductsAggLimitAsync(data.Resolve("{{data:products_agg_limit_101}}"));
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.EnterDedTypeAsync(data.Resolve("{{data:ded_type_102}}"));
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.EnterDeductibleBasisAsync(data.Resolve("{{data:deductible_basis_103}}"));
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.EnterPremOpDedAsync(data.Resolve("{{data:premop_ded_104}}"));
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.EnterPremOpPDDedAsync("");
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.SetSplitBIDedAsync(data.Resolve("{{data:split_bi_ded_106}}"));
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.EnterSplitPDDedAsync("");
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.EnterProdBIDedAsync(data.Resolve("{{data:prod_bi_ded_108}}"));
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.EnterProdPDDedAsync("");
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.EnterFireDamageAsync(data.Resolve("{{data:fire_damage_110}}"));
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.EnterMedicalAsync(data.Resolve("{{data:medical_111}}"));
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.EnterPersAdvInjAsync(data.Resolve("{{data:pers_adv_inj_112}}"));
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
            await page.EnterIsTheInsuredEngagedInAnySnowOrIceRemovalOperationsAsync(data.Resolve("{{data:is_the_insured_engaged_in_any_snow_or_ice_removal_operations_113}}"));
        }
        if (data.Condition("(State==\"NY\")||(State == \"NJ\")||(State == \"WV\")||(State == \"MA\")||(State == \"CT\")||(State == \"ME\")||(State == \"NH\")||(State == \"OR\")||(State == \"AZ\")||(State == \"PA\")||(State == \"MD\")||(State == \"DE\")||(State == \"RI\")||(State == \"VA\")||(State == \"VT\")&& 'Coverage Form' != \"OCP\""))
        {
            await page.EnterOfFullTimeEmployeesAsync(data.Resolve("{{data:of_full_time_employees_114}}"));
        }
        if (data.Condition("(State==\"NY\")||(State == \"NJ\")||(State == \"WV\")||(State == \"MA\") ||(State == \"CT\")||(State == \"ME\")||(State == \"NH\")||(State == \"OR\")||(State == \"AZ\")||(State == \"PA\")||(State == \"MD\")||(State == \"DE\")||(State == \"RI\")||(State == \"VA\")||(State == \"VT\")&& 'Coverage Form' != \"OCP\""))
        {
            await page.EnterOfPartTimeEmployeesAsync(data.Resolve("{{data:of_part_time_employees_115}}"));
        }
        if (data.Condition("(State==\"NY\")||(State == \"NJ\")||(State == \"WV\")||(State == \"MA\")||(State == \"CT\")||(State == \"ME\")||(State == \"NH\")||(State == \"OR\") ||(State == \"AZ\")||(State == \"PA\")||(State == \"MD\")||(State == \"DE\")||(State == \"RI\")||(State == \"VA\")||(State == \"VT\")&& 'Coverage Form' != \"OCP\""))
        {
            await page.EnterOfSeasonalTemporaryEmployeesAsync(data.Resolve("{{data:of_seasonal_temporary_employees_116}}"));
        }
        if (data.Condition("'Coverage Form' != NULL"))
        {
            await page.WaitForPolicyCovgGLCoverageFormAsync("Equal");
        }

    }

    [Given(@"^I add Class$")]
    [When(@"^I add Class$")]
    [Then(@"^I add Class$")]
    public async Task AddClassAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickCGLAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickAddClassAsync();
        await page.EnterSearchResultsAsync(data.Resolve("{{data:search_results_121}}"));
        await page.ClickOKAsync();
        await page.EnterExposureAsync(data.Resolve("{{data:exposure_123}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I add \[CG0435\] Employee Benefits Liability Endorsement$")]
    [When(@"^I add \[CG0435\] Employee Benefits Liability Endorsement$")]
    [Then(@"^I add \[CG0435\] Employee Benefits Liability Endorsement$")]
    public async Task AddCG0435EmployeeBenefitsLiabilityEndorsementAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        if (data.Condition("'Navigate to Endorsements Screen first time' != NULL"))
        {
            await page.ClickGLNavigationLinksEndorsementsAsync();
        }
        await page.WaitForEndorsementsAsync("Exists");
        await page.ClickEndorsementsAddEndorsementAsync();
        await page.EnterCG2401NonBindingArbitrationEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_128}}"));
        await page.EnterNumberOfEmployeesAsync(data.Resolve("{{data:number_of_employees_129}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I add \[CG2142\] Exclusion \- Explosion, Collapse and Underground Property Damage Hazard \(Specified Operations\)$")]
    [When(@"^I add \[CG2142\] Exclusion \- Explosion, Collapse and Underground Property Damage Hazard \(Specified Operations\)$")]
    [Then(@"^I add \[CG2142\] Exclusion \- Explosion, Collapse and Underground Property Damage Hazard \(Specified Operations\)$")]
    public async Task AddCG2142ExclusionExplosionCollapseAndUndergroundPropertyDamageHazardSpecifiedOperationsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        if (data.Condition("'Navigate to Endorsements Screen first time' != NULL"))
        {
            await page.ClickGLNavigationLinksEndorsementsAsync();
        }
        await page.WaitForEndorsementsAsync("Exists");
        await page.ClickEndorsementsAddEndorsementAsync();
        await page.EnterCG2401NonBindingArbitrationEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_134}}"));
        await page.SetExcludeExplosionHazardAsync(data.Resolve("{{data:exclude_explosion_hazard_135}}"));
        await page.SetExcludeCollapseHazardAsync(data.Resolve("{{data:exclude_collapse_hazard_136}}"));
        await page.SetExcludeUndergroundPropertyDamageHazardAsync(data.Resolve("{{data:exclude_underground_property_damage_hazard_137}}"));
        await page.EnterDescriptionOfOperationSAsync(data.Resolve("{{data:description_of_operation_s_138}}"));
        if (data.Condition("State != \"VA\""))
        {
            await page.ClickExcludeUndergroundPropertyDamageHazardAsync();
        }

    }

    [Given(@"^I add \[CG 2149\] Total Pollution Exclusion Endorsement$")]
    [When(@"^I add \[CG 2149\] Total Pollution Exclusion Endorsement$")]
    [Then(@"^I add \[CG 2149\] Total Pollution Exclusion Endorsement$")]
    public async Task AddCG2149TotalPollutionExclusionEndorsementAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        if (data.Condition("'Navigate to Endorsements Screen first time' != NULL"))
        {
            await page.ClickGLNavigationLinksEndorsementsAsync();
        }
        await page.WaitForEndorsementsAsync("Exists");
        await page.ClickEndorsementsAddEndorsementAsync();
        await page.EnterCG2401NonBindingArbitrationEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_143}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I verify and Fill out \[FG0055\] Employment Practices Liability Insurance Coverage Endorsement$")]
    [When(@"^I verify and Fill out \[FG0055\] Employment Practices Liability Insurance Coverage Endorsement$")]
    [Then(@"^I verify and Fill out \[FG0055\] Employment Practices Liability Insurance Coverage Endorsement$")]
    public async Task VerifyAndFillOutFG0055EmploymentPracticesLiabilityInsuranceCoverageEndorsementAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForFGFormTableRowAsync("Exists");
        await page.VerifyFG0055TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementAsync("Exists", "");
        await page.ClickDetailAsync();
        await page.EnterLimitDeductibleAsync(data.Resolve("{{data:limit_deductible_148}}"));
        await page.EnterHasTheInsuredEverHadAClaimForEmploymentPracticesAsync(data.Resolve("{{data:has_the_insured_ever_had_a_claim_for_employment_practices_149}}"));
        await page.EnterTheInsuredAndAnyExecutiveOfficerOrOwnerHasKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaintAsync(data.Resolve("{{data:the_insured_and_any_executive_officer_or_owner_has_knowledge_or_information_of_any_act_error_or_omission_which_might_give_rise_to_an_epl_claim_suit_or_complaint_150}}"));
        await page.EnterThirdPartyAsync(data.Resolve("{{data:third_party_151}}"));
        await page.ClickPolicyCovgAccountsReceivableOKAsync();

    }

    [Given(@"^I add Addl Interest \[CG2007\] \- Engineers$")]
    [When(@"^I add Addl Interest \[CG2007\] \- Engineers$")]
    [Then(@"^I add Addl Interest \[CG2007\] \- Engineers$")]
    public async Task AddAddlInterestCG2007EngineersAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickGLNavigationLinksAddlInterestsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickAddAddlInterestAsync();
        if (data.Condition("Type != NULL"))
        {
            await page.WaitForCG2007AddLInsuredEngineersArchitectsTypeAsync("Exists");
        }
        await page.ClickOKAsync();
        if (data.Condition("Type != NULL"))
        {
            await page.ClickCG2007AddLInsuredEngineersArchitectsTypeAsync();
        }
        if (data.Condition("Type != NULL"))
        {
            await page.EnterCG2007AddLInsuredEngineersArchitectsTypeAsync(data.Resolve("{{data:type_159}}"));
        }

    }

    [Given(@"^I add Addl Interest \[CG2020\] Add'l Insured\-Charitable Institution$")]
    [When(@"^I add Addl Interest \[CG2020\] Add'l Insured\-Charitable Institution$")]
    [Then(@"^I add Addl Interest \[CG2020\] Add'l Insured\-Charitable Institution$")]
    public async Task AddAddlInterestCG2020AddLInsuredCharitableInstitutionAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickGLNavigationLinksAddlInterestsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickAddAddlInterestAsync();
        if (data.Condition("Type != NULL"))
        {
            await page.EnterCG2007AddLInsuredEngineersArchitectsTypeAsync(data.Resolve("{{data:type_163}}"));
        }
        if (data.Condition("'Type of License' != NULL"))
        {
            await page.EnterTypeOfLicenseAsync(data.Resolve("{{data:type_of_license_164}}"));
        }
        await page.ClickOKAsync();

    }

    [Given(@"^I add Addl Interest \[CG2023\] Add'l Insured\-Executors$")]
    [When(@"^I add Addl Interest \[CG2023\] Add'l Insured\-Executors$")]
    [Then(@"^I add Addl Interest \[CG2023\] Add'l Insured\-Executors$")]
    public async Task AddAddlInterestCG2023AddLInsuredExecutorsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickGLNavigationLinksAddlInterestsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickAddAddlInterestAsync();
        if (data.Condition("Type != NULL"))
        {
            await page.EnterCG2007AddLInsuredEngineersArchitectsTypeAsync(data.Resolve("{{data:type_169}}"));
        }
        await page.ClickOKAsync();

    }

    [Given(@"^I add Addl Interest \[CG2025\] Add'l Insured\-Executive Officers$")]
    [When(@"^I add Addl Interest \[CG2025\] Add'l Insured\-Executive Officers$")]
    [Then(@"^I add Addl Interest \[CG2025\] Add'l Insured\-Executive Officers$")]
    public async Task AddAddlInterestCG2025AddLInsuredExecutiveOfficersAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickGLNavigationLinksAddlInterestsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickAddAddlInterestAsync();
        if (data.Condition("Type != NULL"))
        {
            await page.EnterCG2007AddLInsuredEngineersArchitectsTypeAsync(data.Resolve("{{data:type_174}}"));
        }
        await page.ClickOKAsync();

    }

    [Given(@"^I add Addl Interest \[CG2034\] Add'l Insured\-Leased Equipment Automatic$")]
    [When(@"^I add Addl Interest \[CG2034\] Add'l Insured\-Leased Equipment Automatic$")]
    [Then(@"^I add Addl Interest \[CG2034\] Add'l Insured\-Leased Equipment Automatic$")]
    public async Task AddAddlInterestCG2034AddLInsuredLeasedEquipmentAutomaticAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickGLNavigationLinksAddlInterestsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickAddAddlInterestAsync();
        if (data.Condition("Type != NULL"))
        {
            await page.EnterCG2007AddLInsuredEngineersArchitectsTypeAsync(data.Resolve("{{data:type_179}}"));
        }
        if (data.Condition("'Type of Equipment' != NULL"))
        {
            await page.EnterTypeOfEquipmentAsync(data.Resolve("{{data:type_of_equipment_180}}"));
        }
        await page.ClickOKAsync();

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

    [Given(@"^I answer GL UW Questions OR \& WA$")]
    [When(@"^I answer GL UW Questions OR \& WA$")]
    [Then(@"^I answer GL UW Questions OR \& WA$")]
    public async Task AnswerGLUWQuestionsORWAAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickGLUWQuestionsAsync();
        await page.WaitForGeneralLiabilityInformationAsync("Exists");
        await page.ClickUWQuestionsUmbrellaUpdateAnswersAsync();
        await page.EnterDescribeAllHoldHarmlessAgreementsAndPleaseProvideACopyAsync(data.Resolve("{{data:describe_all_hold_harmless_agreements_and_please_provide_a_copy_190}}"));
        await page.ClickGeneralLiabilityInformationAsync();
        await page.ClickGLUWQuestionsAsync();
        await page.WaitForGeneralLiabilityInformationAsync("Exists");
        await page.ClickProductsCompletedOpsButtonAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickUWQuestionsUmbrellaUpdateAnswersAsync();
        await page.ClickOKAsync();

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
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_200}}"));
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_203}}"));
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_207}}"));
        await page.PauseAsync(1000);

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
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_213}}"));
        await page.VerifyOrderAuditAsync("Exists", "");
        await page.EnterOrderAuditAsync(data.Resolve("{{data:order_audit_215}}"));
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
        await page.VerifyIsThisCoverageBoundAsync(data.Resolve("{{data:expected_is_this_coverage_bound_value_223}}"), "Value");
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_224}}"));
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

        await page.VerifyFullTermPremiumAsync(data.Resolve("{{data:expected_full_term_premium_value_256}}"), "value");
        await page.VerifyPremiumWrittenAsync(data.Resolve("{{data:expected_premium_written_value_257}}"), "value");
        await page.VerifyPriorPremiumAsync(data.Resolve("{{data:expected_prior_premium_value_258}}"), "value");
        await page.VerifyPremiumChangeAsync(data.Resolve("{{data:expected_premium_change_value_259}}"), "value");
        await page.EnterTitleAsync(data.Resolve("{{data:title_261}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_262}}"));
        data.Set("SessionId", await page.CaptureResultAsync("value"));

    }

    [Given(@"^I complete forms verification$")]
    [When(@"^I complete forms verification$")]
    [Then(@"^I complete forms verification$")]
    public async Task CompleteFormsVerificationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.EnterSessionIDAsync(data.Resolve("{B[SessionId]}"));
        await page.VerifyStatusCodeAsync(data.Resolve("{{data:expected_statuscode_value_266}}"), "value");
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
