using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "CP Basic Policy")]
public sealed class CPBasicPolicySteps
{
    private readonly ScenarioContext _scenario;
    public CPBasicPolicySteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I enter business client information$")]
    [When(@"^I enter business client information$")]
    [Then(@"^I enter business client information$")]
    public async Task EnterBusinessClientInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("PrimaryPhone_0041", "[0-9]{10}");
        data.GenerateRandom("FEIN_0044", "486[0-9]{6}");
        data.GenerateRandom("AuditTelephone_0045", "[0-9]{10}");
        data.GenerateRandom("InspectionTelephone_0045", "[0-9]{10}");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

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
        await page.PressAddress17A1FBAsync("TAB");
        await page.EnterZipCode26D22Async(data.Resolve("{{data:zipcode_11}}"));
        await page.PressZipCode26D22Async("Tab");
        await page.PressZipCode26D22Async("Tab");
        await page.EnterAddress17A1FBAsync(data.Resolve("{{data:address1_12}}"));
        await page.PressAddress17A1FBAsync("Tab");
        await page.VerifyYearsInBusinessAsync("Exists", "");
        await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_14}}"));
        await page.PressYearsInBusinessAsync("Tab");
        if (data.Condition("'Product (LOB)' != \"UMB\""))
        {
                    await page.EnterNameOfAuditContactAsync(data.Resolve("{{data:name_of_audit_contact_16}}"));
                    await page.PressNameOfAuditContactAsync("Tab");
                    await page.PressNameOfAuditContactAsync("Tab");
        }
        if (data.Condition("'Product (LOB)' != \"UMB\""))
        {
        }
        await page.EnterNameOfInspectionContactAsync(data.Resolve("{{data:name_of_inspection_contact_18}}"));
        await page.PressNameOfInspectionContactAsync("Tab");
        await page.PressNameOfInspectionContactAsync("Tab");
        await page.PressNameOfInspectionContactAsync("CLICK");
        await page.PressNameOfInspectionContactAsync("CLICK");
        await page.PressNameOfInspectionContactAsync("Tab");
        await page.EnterInsuredEMailAddressAsync(data.Resolve("{{data:insured_e_mail_address_20}}"));
        await page.PressInsuredEMailAddressAsync("Tab");
        await page.PressInsuredEMailAddressAsync("CLICK");
        await page.PressInsuredEMailAddressAsync("Tab");
        await page.EnterWebsiteAddressAsync(data.Resolve("{{data:website_address_21}}"));
        await page.PressWebsiteAddressAsync("Tab");
        await page.PressAddress2Async("TAB");
        await page.PressAddress2Async("Tab");
        await page.VerifyZipCode26D22Async("[0-9]{5}-[0-9]{4}", "Regex:value");
        data.Set("State", data.Resolve("{{data:state}}"));
        data.Set("Product (LOB)", data.Resolve("{{data:product_lob}}"));
        data.Set("FormOnPolicyDocName", data.Resolve("{{data:formonpolicydocname}}"));
        data.Set("Server", data.Resolve("{{data:server}}"));

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
        data.Set("AJAX Error", data.Resolve("The scripts experienced an AJAX error with the following information: {B[AJAX]}"));
        data.Set("ForceAFail", "'FALSE' == 'TRUE'");

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
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_37}}"));
        await page.PressBillTypeAsync("Tab");
        await page.PressBillTypeAsync("TAB");
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_40}}"));
        await page.PressPayPlanAsync("Tab");
        await page.PressPayPlanAsync("TAB");
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_44}}"));
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
        await page.EnterIndividualTypeAsync(data.Resolve("{{data:individualtype_47}}"));
        await page.PressIndividualTypeAsync("Tab");
        await page.PressIndividualTypeAsync("CLICK");
        await page.PressIndividualTypeAsync("Tab");
        await page.WaitForPleaseVerifySSNF738AAsync("Exists");
        await page.PressFirstNameC5387Async("TAB");
        await page.PressFirstNameC5387Async("Tab");
        await page.EnterDateOfBirth338D7Async(data.Resolve("{{data:dateofbirth_52}}"));
        await page.PressDateOfBirth338D7Async("Tab");
        await page.EnterAddress1D319BAsync(data.Resolve("{{data:address1_53}}"));
        await page.PressAddress1D319BAsync("Tab");
        await page.PressAddress1D319BAsync("Tab");
        await page.EnterCityAsync(data.Resolve("{{data:city_54}}"));
        await page.PressCityAsync("Tab");
        await page.PressCityAsync("Tab");
        await page.PressCityAsync("Tab");
        await page.EnterStateAsync(data.Resolve("{{data:state_55}}"));
        await page.PressStateAsync("Tab");
        await page.PressStateAsync("Tab");
        await page.PressStateAsync("Tab");
        await page.EnterZipCodeA088EAsync(data.Resolve("{{data:zipcode_56}}"));
        await page.PressZipCodeA088EAsync("Tab");
        await page.PressZipCodeA088EAsync("Tab");
        await page.PressZipCodeA088EAsync("Tab");
        await page.EnterGender4973CAsync(data.Resolve("{{data:gender_57}}"));
        await page.PressGender4973CAsync("Tab");
        await page.WaitForClientSearch41F28Async("Exists");
        await page.ClickClientSearch41F28Async();
        await page.VerifySearchResultsDuckCreekPolicyFirstCheckboxAsync("Absent", "");
        await page.ClickOKAsync();
        await page.ClickOrderSSN5E031Async();
        await page.PressEnterSSNFA186Async("TAB");
        await page.PressEnterSSNFA186Async("Enter");
        await page.EnterEnterSSNFA186Async(data.Resolve("{{data:enter_ssn_65}}"));
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
        await page.EnterIsThereAPriorCarrierAsync(data.Resolve("{{data:is_there_a_prior_carrier_88}}"));
        await page.PressIsThereAPriorCarrierAsync("Tab");
        await page.WaitForCarrierAsync("Exists");
        await page.EnterCarrierAsync(data.Resolve("{{data:carrier_90}}"));
        await page.PressCarrierAsync("Tab");
        await page.PressCarrierAsync("Tab");
        await page.EnterPolicyNumberBA28EAsync(data.Resolve("{{data:policy_number_91}}"));
        await page.PressPolicyNumberBA28EAsync("Tab");
        await page.EnterPolicyTypeAsync(data.Resolve("{{data:policy_type_92}}"));
        await page.PressPolicyTypeAsync("Tab");
        await page.EnterEffectiveDateB557FAsync("{DATE[][-2y][MM'/'dd'/'yyyy]}");
        await page.PressEffectiveDateB557FAsync("Tab");
        await page.EnterExpirationDate34EACAsync("{DATE[][][MM'/'dd'/'yyyy]}");
        await page.PressExpirationDate34EACAsync("Tab");
        await page.EnterModificationFactorAsync(data.Resolve("{{data:modificationfactor_95}}"));
        await page.PressModificationFactorAsync("Tab");
        await page.EnterTotalPremiumAsync(data.Resolve("{{data:total_premium_96}}"));
        await page.PressTotalPremiumAsync("Tab");
        await page.ClickOtherInsuranceHistoryOKAsync();
        await page.WaitForDetail0F8C6Async("Exists");
        await page.ClickLossExperienceAsync();
        await page.WaitForNoKnownLossesAsync("Exists");
        await page.SetNoKnownLossesAsync(data.Resolve("{{data:no_known_losses_101}}"));
        await page.PressNoKnownLossesAsync("Tab");
        await page.ClickReturnToQuoteAsync();
        await page.EnterTitleAsync(data.Resolve("{{data:title_103}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_104}}"));
        await page.VerifyResultAsync(data.Resolve("{{data:expected_result_value_105}}"), "value");

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
        await page.EnterEffectiveDate95094Async(data.Resolve("{{data:effectivedate_109}}"));
        await page.PressEffectiveDate95094Async("Tab");
        if (data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
                    await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_110}}"));
                    await page.PressYearsInBusinessAsync("Tab");
        }
        await page.PauseAsync(1000);
        if (data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_112}}"));
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
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_116}}"));
        await page.PressWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync("Tab");
        await page.PressWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync("Tab");
        data.Set("StateIsKansas", "Arizona==\"Kansas\"; Expression= 'Arizona'=='Kansas'");
        data.Set("StateIsVirginia", "Arizona==\"Virginia\"; Expression= 'Arizona'=='Virginia'");
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
        await page.EnterDescriptionOfSpecifiedOperationAsync("AZ CP Basic {NMONTH}.{NDAY}.{NYEAR} {Time}");
        await page.PressDescriptionOfSpecifiedOperationAsync("Tab");
        await page.VerifyDescriptionOfSpecifiedOperationAsync("{XB[QuoteDescription]}", "value");
        await page.PauseAsync(1000);

    }

    [Given(@"^I run insurance score$")]
    [When(@"^I run insurance score$")]
    [Then(@"^I run insurance score$")]
    public async Task RunInsuranceScoreAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyTheInsuranceScoreServiceHasReturnedTheFollowingErrorCREDITVENDORUNREACHABLEPLEASEREPROCESSAsync("Exists", "");
        data.Set("CheckIfItIsBAPVT", data.Resolve("'{B[Product (LOB)]}' = 'BAP' && '{B[State]}'= 'VT'"));
        await page.ClickInsuranceScoreConsentAsync();
        await page.WaitForAcceptAsync("Exists");
        await page.ClickAcceptAsync();
        await page.WaitForInsuranceScoreAsync("Exists");
        await page.ClickInsuranceScoreAsync();
        await page.VerifyReferenceNumberAsync(data.Resolve("{{data:expected_reference_number_innertext_140}}"), "InnerText");
        await page.PauseAsync(1000);
        await page.PauseAsync(1000);

    }

    [Given(@"^I complete CP Fields$")]
    [When(@"^I complete CP Fields$")]
    [Then(@"^I complete CP Fields$")]
    public async Task CompleteCPFieldsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickPolicyCovgD0419Async();
        await page.WaitForPolicyCovgFF145Async("Exists");
        await page.EnterDoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackupAsync(data.Resolve("{{data:does_any_risk_generate_power_other_than_private_windmills_or_emergency_backup_145}}"));
        await page.PressDoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackupAsync("CLICK");
        await page.PressDoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackupAsync("Enter");
        await page.PressDoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackupAsync("Tab");

    }

    [Given(@"^I complete mask Error Recovery$")]
    [When(@"^I complete mask Error Recovery$")]
    [Then(@"^I complete mask Error Recovery$")]
    public async Task CompleteMaskErrorRecoveryAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickStartAsync();
        await page.ClickStartAsync();

    }

    [Given(@"^I complete CP Fields for policy coverage$")]
    [When(@"^I complete CP Fields for policy coverage$")]
    [Then(@"^I complete CP Fields for policy coverage$")]
    public async Task CompleteCPFieldsForPolicyCoverageAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.EnterPolicyCoverageAsync(data.Resolve("{{data:policy_coverage_148}}"));
        await page.PressPolicyCoverageAsync("Tab");
        if (data.Condition("'Property Extension Endorsements' != NULL"))
        {
                    await page.EnterPropertyExtensionEndorsementsAsync(data.Resolve("{{data:property_extension_endorsements_149}}"));
                    await page.PressPropertyExtensionEndorsementsAsync("CLICK");
                    await page.PressPropertyExtensionEndorsementsAsync("Enter");
                    await page.PressPropertyExtensionEndorsementsAsync("Tab");
        }
        if (data.Condition("'Utility Services' != NULL"))
        {
                    await page.EnterUtilityServicesAsync(data.Resolve("{{data:utility_services_150}}"));
                    await page.PressUtilityServicesAsync("Tab");
        }
        if (data.Condition("Fungus != NULL"))
        {
                    await page.EnterFungusAsync("");
        }

    }

    [Given(@"^I complete CP Fields for location$")]
    [When(@"^I complete CP Fields for location$")]
    [Then(@"^I complete CP Fields for location$")]
    public async Task CompleteCPFieldsForLocationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickLocationB7B1DAsync();
        await page.WaitForAddress1C0AF1Async("Exists");
        await page.EnterFeetFromHydrantAsync(data.Resolve("{{data:feet_from_hydrant_154}}"));
        await page.PressFeetFromHydrantAsync("Tab");
        await page.PressFeetFromHydrantAsync("Tab");
        await page.PressFeetFromHydrantAsync("Enter");
        await page.PressFeetFromHydrantAsync("Tab");
        await page.PressFeetFromHydrantAsync("Tab");
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.WaitForAddress1C0AF1Async("Exists");
        await page.EnterMilesFromFireDepartmentAsync(data.Resolve("{{data:miles_from_fire_department_160}}"));
        await page.PressMilesFromFireDepartmentAsync("Tab");
        await page.PressMilesFromFireDepartmentAsync("Tab");
        await page.PressMilesFromFireDepartmentAsync("Tab");
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.VerifyFeetFromHydrantAsync(data.Resolve("{{data:expected_feet_from_hydrant_value_163}}"), "NotEqual:Value");
        await page.WaitForAddress1C0AF1Async("Exists");
        await page.EnterFeetFromHydrantAsync(data.Resolve("{{data:feet_from_hydrant_165}}"));
        await page.PressFeetFromHydrantAsync("Tab");
        await page.PressFeetFromHydrantAsync("Tab");
        await page.PressFeetFromHydrantAsync("Enter");
        await page.PressFeetFromHydrantAsync("Tab");
        await page.PressFeetFromHydrantAsync("Tab");
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.WaitForAddress1C0AF1Async("Exists");
        await page.ClickCallISOAsync();
        await page.ClickSelectPPCAsync();
        await page.ClickSelectAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.VerifyFeetFromHydrantAsync(data.Resolve("{{data:expected_feet_from_hydrant_value_174}}"), "NotEqual:Value");
        await page.WaitForAddress1C0AF1Async("Exists");
        await page.EnterFeetFromHydrantAsync(data.Resolve("{{data:feet_from_hydrant_176}}"));
        await page.PressFeetFromHydrantAsync("CLICK");
        await page.PressFeetFromHydrantAsync("CLICK");
        await page.PressFeetFromHydrantAsync("Enter");
        await page.PressFeetFromHydrantAsync("Enter");
        await page.PressFeetFromHydrantAsync("Tab");
        await page.PressFeetFromHydrantAsync("Tab");
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.WaitForAddress1C0AF1Async("Exists");
        await page.ClickLocationOKAsync();

    }

    [Given(@"^I complete CP Fields for building$")]
    [When(@"^I complete CP Fields for building$")]
    [Then(@"^I complete CP Fields for building$")]
    public async Task CompleteCPFieldsForBuildingAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickBuilding87910Async();
        await page.WaitForBuilding8205FAsync("Exists");
        await page.ClickAddBuildingAsync();
        await page.WaitForBuilding8205FAsync("Exists");
        await page.ClickDetail10932Async();
        if (data.Condition("Construction != NULL"))
        {
                    await page.EnterConstruction39800Async(data.Resolve("{{data:construction_186}}"));
                    await page.PressConstruction39800Async("Tab");
                    await page.PressConstruction39800Async("Tab");
        }
        if (data.Condition("'Year Built' != NULL"))
        {
                    await page.EnterYearBuiltAsync(data.Resolve("{{data:year_built_187}}"));
                    await page.PressYearBuiltAsync("Tab");
                    await page.PressYearBuiltAsync("Tab");
        }
        if (data.Condition("'Square Feet' != NULL"))
        {
                    await page.EnterSquareFeetAsync(data.Resolve("{{data:square_feet_188}}"));
                    await page.PressSquareFeetAsync("Tab");
                    await page.PressSquareFeetAsync("Tab");
        }
        if (data.Condition("Stories != NULL"))
        {
                    await page.EnterStoriesAsync(data.Resolve("{{data:stories_189}}"));
                    await page.PressStoriesAsync("Tab");
                    await page.PressStoriesAsync("Tab");
        }
        if (data.Condition("Interest != NULL"))
        {
                    await page.EnterInterestAsync(data.Resolve("{{data:interest_190}}"));
                    await page.PressInterestAsync("Tab");
                    await page.PressInterestAsync("Tab");
        }
        if (data.Condition("'Roof Type' != NULL"))
        {
                    await page.EnterRoofTypeAsync(data.Resolve("{{data:roof_type_191}}"));
                    await page.PressRoofTypeAsync("Tab");
                    await page.PressRoofTypeAsync("Tab");
        }
        if (data.Condition("Deductible != NULL"))
        {
                    await page.EnterDeductible592D9Async(data.Resolve("{{data:deductible_192}}"));
                    await page.PressDeductible592D9Async("Tab");
                    await page.PressDeductible592D9Async("Tab");
                    await page.PressDeductible592D9Async("CLICK");
                    await page.PressDeductible592D9Async("CLICK");
                    await page.PressDeductible592D9Async("Tab");
        }
        if (data.Condition("'Deductible Increased Theft' != NULL"))
        {
                    await page.EnterDeductibleIncreasedTheft99E5FAsync(data.Resolve("{{data:deductible_increased_theft_193}}"));
                    await page.PressDeductibleIncreasedTheft99E5FAsync("Tab");
                    await page.PressDeductibleIncreasedTheft99E5FAsync("Tab");
        }
        if (data.Condition("'Deductible Wind Hail' != NULL"))
        {
                    await page.EnterDeductibleWindHail911AFAsync(data.Resolve("{{data:deductible_wind_hail_194}}"));
                    await page.PressDeductibleWindHail911AFAsync("Tab");
                    await page.PressDeductibleWindHail911AFAsync("Tab");
        }
        if (data.Condition("'BG2 Symbol' != NULL"))
        {
                    await page.EnterBG2SymbolAsync(data.Resolve("{{data:bg2_symbol_195}}"));
                    await page.PressBG2SymbolAsync("Tab");
                    await page.PressBG2SymbolAsync("Tab");
        }
        if (data.Condition("'BG2 Symbol Prefix' != NULL"))
        {
                    await page.EnterBG2SymbolPrefixAsync(data.Resolve("{{data:bg2_symbol_prefix_196}}"));
                    await page.PressBG2SymbolPrefixAsync("CLICK");
                    await page.PressBG2SymbolPrefixAsync("Tab");
        }
        if (data.Condition("'Is the building cooled?' != NULL"))
        {
                    await page.EnterIsTheBuildingCooledAsync(data.Resolve("{{data:is_the_building_cooled_197}}"));
                    await page.PressIsTheBuildingCooledAsync("Tab");
                    await page.PressIsTheBuildingCooledAsync("Tab");
        }
        if (data.Condition("'Is the building heated with a Solid Fuel Heating Device?' != NULL"))
        {
                    await page.EnterIsTheBuildingHeatedWithASolidFuelHeatingDeviceAsync(data.Resolve("{{data:is_the_building_heated_with_a_solid_fuel_heating_device_198}}"));
                    await page.PressIsTheBuildingHeatedWithASolidFuelHeatingDeviceAsync("Tab");
                    await page.PressIsTheBuildingHeatedWithASolidFuelHeatingDeviceAsync("CLICK");
                    await page.PressIsTheBuildingHeatedWithASolidFuelHeatingDeviceAsync("Tab");
        }
        if (data.Condition("'Provide a List of Surrounding Exposure/Other Occupancies within 100 ft (Including North, East, South, and West)' != NULL"))
        {
                    await page.EnterProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWestAsync(data.Resolve("{{data:provide_a_list_of_surrounding_exposure_other_occupancies_within_100_ft_including_north_east_south_and_west_199}}"));
                    await page.PressProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWestAsync("Tab");
                    await page.PressProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWestAsync("CLICK");
                    await page.PressProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWestAsync("Tab");
        }
        if (data.Condition("'Eligible For Enhanced Wind Rating Program' != NULL"))
        {
                    await page.EnterEligibleForEnhancedWindRatingProgramAsync(data.Resolve("{{data:eligible_for_enhanced_wind_rating_program_200}}"));
                    await page.PressEligibleForEnhancedWindRatingProgramAsync("Tab");
                    await page.PressEligibleForEnhancedWindRatingProgramAsync("Tab");
        }
        await page.ClickBuildingDetailOKAsync();

    }

    [Given(@"^I add a Rating Group$")]
    [When(@"^I add a Rating Group$")]
    [Then(@"^I add a Rating Group$")]
    public async Task AddARatingGroupAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickRatingGroups46191Async();
        await page.WaitForRatingGroups46DD2Async("Exists");
        if (data.Condition("Description != NULL"))
        {
                    await page.EnterDescription8A08DAsync(data.Resolve("{{data:description_204}}"));
                    await page.PressDescription8A08DAsync("Tab");
                    await page.PressDescription8A08DAsync("Tab");
        }
        if (data.Condition("'Risk Type' != NULL"))
        {
                    await page.EnterRiskTypeAsync(data.Resolve("{{data:risk_type_205}}"));
                    await page.PressRiskTypeAsync("Tab");
                    await page.PressRiskTypeAsync("Tab");
        }
        if (data.Condition("Coinsurance != NULL"))
        {
                    await page.EnterCoinsurance6348BAsync(data.Resolve("{{data:coinsurance_206}}"));
                    await page.PressCoinsurance6348BAsync("Tab");
                    await page.PressCoinsurance6348BAsync("Tab");
        }
        if (data.Condition("Deductible != NULL"))
        {
                    await page.EnterDeductible01AB9Async(data.Resolve("{{data:deductible_207}}"));
                    await page.PressDeductible01AB9Async("Tab");
                    await page.PressDeductible01AB9Async("Tab");
        }
        if (data.Condition("'Deductible Increased Theft' != NULL"))
        {
                    await page.EnterDeductibleIncreasedTheftF76DBAsync(data.Resolve("{{data:deductible_increased_theft_208}}"));
                    await page.PressDeductibleIncreasedTheftF76DBAsync("Tab");
                    await page.PressDeductibleIncreasedTheftF76DBAsync("Tab");
        }
        if (data.Condition("'Deductible Wind Hail' != NULL"))
        {
                    await page.EnterDeductibleWindHailAB1C3Async(data.Resolve("{{data:deductible_wind_hail_209}}"));
                    await page.PressDeductibleWindHailAB1C3Async("Tab");
                    await page.PressDeductibleWindHailAB1C3Async("Tab");
        }
        if (data.Condition("'Cause Of Loss' != NULL"))
        {
                    await page.EnterCauseOfLossAsync(data.Resolve("{{data:cause_of_loss_210}}"));
                    await page.PressCauseOfLossAsync("Tab");
                    await page.PressCauseOfLossAsync("Tab");
        }
        if (data.Condition("Valuation != NULL"))
        {
                    await page.EnterValuationAsync(data.Resolve("{{data:valuation_211}}"));
                    await page.PressValuationAsync("Tab");
                    await page.PressValuationAsync("Tab");
        }
        await page.ClickAddGroupAsync();

    }

    [Given(@"^I complete Structure Questions$")]
    [When(@"^I complete Structure Questions$")]
    [Then(@"^I complete Structure Questions$")]
    public async Task CompleteStructureQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickPropertyAsync();
        if (data.Condition("'Increased Pollutant Cleanup' != NULL"))
        {
                    await page.EnterIncreasedPollutantCleanupAsync(data.Resolve("{{data:increased_pollutant_cleanup_214}}"));
                    await page.PressIncreasedPollutantCleanupAsync("Tab");
                    await page.PressIncreasedPollutantCleanupAsync("Tab");
        }
        if (data.Condition("'Debris Removal Additional' != NULL"))
        {
                    await page.EnterDebrisRemovalAdditionalAsync(data.Resolve("{{data:debris_removal_additional_215}}"));
                    await page.PressDebrisRemovalAdditionalAsync("Tab");
                    await page.PressDebrisRemovalAdditionalAsync("Tab");
        }
        if (data.Condition("'Debris Removal Additional Limit' != NULL"))
        {
                    await page.EnterDebrisRemovalAdditionalLimitAsync(data.Resolve("{{data:debris_removal_additional_limit_216}}"));
                    await page.PressDebrisRemovalAdditionalLimitAsync("Tab");
                    await page.PressDebrisRemovalAdditionalLimitAsync("Tab");
        }
        if (data.Condition("'Vacant Building' != NULL"))
        {
                    await page.EnterVacantBuildingAsync(data.Resolve("{{data:vacant_building_217}}"));
                    await page.PressVacantBuildingAsync("Tab");
                    await page.PressVacantBuildingAsync("Tab");
        }
        if (data.Condition("'% Occupied' != NULL"))
        {
                    await page.EnterOccupiedAsync(data.Resolve("{{data:occupied_218}}"));
                    await page.PressOccupiedAsync("Tab");
                    await page.PressOccupiedAsync("Tab");
        }
        if (data.Condition("'Pier Or Wharf' != NULL"))
        {
                    await page.EnterPierOrWharfAsync(data.Resolve("{{data:pier_or_wharf_219}}"));
                    await page.PressPierOrWharfAsync("Tab");
                    await page.PressPierOrWharfAsync("Tab");
        }
        if (data.Condition("'Pier Or Wharf Construction' != NULL"))
        {
                    await page.EnterPierOrWharfConstructionAsync(data.Resolve("{{data:pier_or_wharf_construction_220}}"));
                    await page.PressPierOrWharfConstructionAsync("Tab");
                    await page.PressPierOrWharfConstructionAsync("Tab");
        }
        if (data.Condition("'Pier Or Wharf Cause Of Loss' != NULL"))
        {
                    await page.EnterPierOrWharfCauseOfLossAsync(data.Resolve("{{data:pier_or_wharf_cause_of_loss_221}}"));
                    await page.PressPierOrWharfCauseOfLossAsync("Tab");
                    await page.PressPierOrWharfCauseOfLossAsync("Tab");
                    await page.PressPierOrWharfCauseOfLossAsync("Tab");
        }
        if (data.Condition("'Pier Or Wharf COL Options' != NULL"))
        {
                    await page.EnterPierOrWharfCOLOptionsAsync(data.Resolve("{{data:pier_or_wharf_col_options_222}}"));
                    await page.PressPierOrWharfCOLOptionsAsync("Tab");
                    await page.PressPierOrWharfCOLOptionsAsync("CLICK");
                    await page.PressPierOrWharfCOLOptionsAsync("Tab");
        }
        if (data.Condition("'Vacancy Permit' != NULL"))
        {
                    await page.EnterVacancyPermitAsync(data.Resolve("{{data:vacancy_permit_223}}"));
                    await page.PressVacancyPermitAsync("Tab");
                    await page.PressVacancyPermitAsync("Tab");
        }
        if (data.Condition("'Pier Or Wharf COL Options' != NULL"))
        {
                    await page.WaitForPierOrWharfCOLOptionsAsync("Exists");
        }
        await page.ClickAddClassDCD8FAsync();
        if (data.Condition("(State !=\"OR\")||(State!=\"WA\")||(State!=\"VT\")"))
        {
                    await page.EnterSearchValue54F3CAsync(data.Resolve("{{data:search_value_226}}"));
                    await page.PressSearchValue54F3CAsync("CLICK");
                    await page.PressSearchValue54F3CAsync("Tab");
                    await page.PressSearchValue54F3CAsync("Tab");
        }
        if (data.Condition("(State !=\"OR\")||(State!=\"WA\")||(State!=\"VT\")"))
        {
                    await page.EnterSearchResultsD0AA8Async(data.Resolve("{{data:search_results_227}}"));
                    await page.PressSearchResultsD0AA8Async("CLICK");
                    await page.PressSearchResultsD0AA8Async("Enter");
                    await page.PressSearchResultsD0AA8Async("Tab");
                    await page.PressSearchResultsD0AA8Async("Tab");
        }
        await page.EnterOccupancyTypeAsync(data.Resolve("{{data:occupancy_type_228}}"));
        await page.PressOccupancyTypeAsync("CLICK");
        await page.PressOccupancyTypeAsync("Tab");
        if (data.Condition("(State ==\"OR\")||(State==\"WA\")"))
        {
                    await page.EnterSearchResultsD0AA8Async("");
        }
        await page.ClickPropertyAddClassOKAsync();
        await page.EnterBuildingRatingGroupAsync(data.Resolve("{{data:building_rating_group_231}}"));
        await page.PressBuildingRatingGroupAsync("Tab");
        await page.PressBuildingRatingGroupAsync("CLICK");
        await page.PressBuildingRatingGroupAsync("Tab");
        await page.EnterBuildingLimitAsync(data.Resolve("{{data:building_limit_232}}"));
        await page.PressBuildingLimitAsync("Tab");
        await page.PressBuildingLimitAsync("Tab");
        await page.EnterPersonalPropertyRatingGroupAsync(data.Resolve("{{data:personal_property_rating_group_233}}"));
        await page.PressPersonalPropertyRatingGroupAsync("Tab");
        await page.PressPersonalPropertyRatingGroupAsync("Tab");
        await page.EnterPersonalPropertyLimitAsync(data.Resolve("{{data:personal_property_limit_234}}"));
        await page.PressPersonalPropertyLimitAsync("Tab");
        await page.PressPersonalPropertyLimitAsync("Tab");
        await page.EnterPropertyOfOthersRatingGroupAsync(data.Resolve("{{data:property_of_others_rating_group_235}}"));
        await page.PressPropertyOfOthersRatingGroupAsync("Tab");
        await page.PressPropertyOfOthersRatingGroupAsync("Tab");
        await page.PressPropertyOfOthersRatingGroupAsync("Tab");
        await page.EnterPropertyOfOthersLimitAsync(data.Resolve("{{data:property_of_others_limit_236}}"));
        await page.PressPropertyOfOthersLimitAsync("Tab");
        await page.PressPropertyOfOthersLimitAsync("Tab");
        if (data.Condition("(State ==\"OR\")||(State==\"WA\")"))
        {
                    await page.EnterSearchValue54F3CAsync(data.Resolve("{{data:search_value_237}}"));
                    await page.PressSearchValue54F3CAsync("CLICK");
                    await page.PressSearchValue54F3CAsync("Tab");
                    await page.PressSearchValue54F3CAsync("Tab");
        }
        await page.ClickDetail7F662Async();
        await page.EnterEstimatorTypeAsync(data.Resolve("{{data:estimator_type_239}}"));
        await page.PressEstimatorTypeAsync("Tab");
        await page.PressEstimatorTypeAsync("Tab");
        await page.EnterValuationTypeAsync(data.Resolve("{{data:valuation_type_240}}"));
        await page.PressValuationTypeAsync("Tab");
        await page.PressValuationTypeAsync("Tab");
        await page.ClickCreateValuationAsync();
        await page.ClickGetCalculatedValueAsync();
        await page.ClickPropertyEnterBuildingRCTOKAsync();

    }

    [Given(@"^I add Addl Interests$")]
    [When(@"^I add Addl Interests$")]
    [Then(@"^I add Addl Interests$")]
    public async Task AddAddlInterestsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LossHistoryPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickAddlInterestsAsync();
        await page.ClickAddAddlInterestAsync();
        await page.EnterTypeAsync(data.Resolve("{{data:type_246}}"));
        await page.PressTypeAsync("Tab");
        await page.PressTypeAsync("CLICK");
        await page.PressTypeAsync("Tab");
        await page.EnterLoanNumberAsync(data.Resolve("{{data:loan_number_247}}"));
        await page.PressLoanNumberAsync("Tab");
        await page.PressLoanNumberAsync("CLICK");
        await page.PressLoanNumberAsync("Tab");
        await page.EnterInsuredTypeAsync(data.Resolve("{{data:insured_type_248}}"));
        await page.PressInsuredTypeAsync("Tab");
        await page.PressInsuredTypeAsync("CLICK");
        await page.PressInsuredTypeAsync("Tab");
        await page.EnterFirstNameAsync(data.Resolve("{{data:first_name_249}}"));
        await page.PressFirstNameAsync("Tab");
        await page.PressFirstNameAsync("CLICK");
        await page.PressFirstNameAsync("Tab");
        await page.EnterMIAsync(data.Resolve("{{data:mi_250}}"));
        await page.PressMIAsync("Tab");
        await page.PressMIAsync("CLICK");
        await page.PressMIAsync("Tab");
        await page.EnterLastNameAsync(data.Resolve("{{data:last_name_251}}"));
        await page.PressLastNameAsync("Tab");
        await page.PressLastNameAsync("CLICK");
        await page.PressLastNameAsync("Tab");
        await page.EnterAddress1Async(data.Resolve("{{data:address_1_252}}"));
        await page.PressAddress1Async("Tab");
        await page.PressAddress1Async("CLICK");
        await page.PressAddress1Async("Tab");
        await page.EnterZipCodeAsync(data.Resolve("{{data:zip_code_253}}"));
        await page.PressZipCodeAsync("Tab");
        await page.PressZipCodeAsync("CLICK");
        await page.PressZipCodeAsync("Tab");
        await page.EnterProvisionsApplicableAsync(data.Resolve("{{data:provisions_applicable_254}}"));
        await page.PressProvisionsApplicableAsync("Tab");
        await page.PressProvisionsApplicableAsync("CLICK");
        await page.PressProvisionsApplicableAsync("Tab");
        await page.EnterDescriptionOfPropertyAsync(data.Resolve("{{data:description_of_property_255}}"));
        await page.PressDescriptionOfPropertyAsync("Tab");
        await page.PressDescriptionOfPropertyAsync("CLICK");
        await page.PressDescriptionOfPropertyAsync("Tab");
        await page.ClickAssignLocationsAsync();
        await page.WaitForOtherInterestPremisesScheduleAsync("Exists");
        await page.ClickNewAssignmentAsync();
        await page.WaitForNewAssignmentAsync("Exists");
        await page.ClickOtherInterestPremisesDetailOKAsync();
        await page.WaitForAssignmentScheduleForAsync("Exists");
        await page.ClickAssignmentScheduleForOKAsync();
        await page.ClickOtherInterestPremisesScheduleOKAsync();
        if (data.Condition("State != \"OR\""))
        {
                    await page.ClickAddlInterestsMainOKAsync();
        }

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
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_267}}"));
        await page.PressBillTypeAsync("Tab");
        await page.PressBillTypeAsync("TAB");
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_270}}"));
        await page.PressPayPlanAsync("Tab");
        await page.PressPayPlanAsync("TAB");
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_274}}"));
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

    [Given(@"^I complete Property UW Questions$")]
    [When(@"^I complete Property UW Questions$")]
    [Then(@"^I complete Property UW Questions$")]
    public async Task CompletePropertyUWQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickPropertyUWQuestions8452CAsync();
        await page.WaitForPropertyUWQuestions790F2Async("Exists");
        await page.ClickUpdateAnswers99D68Async();
        await page.PressUpdateAnswers99D68Async("Tab");
        await page.PressUpdateAnswers99D68Async("Tab");
        await page.PressUpdateAnswers99D68Async("Tab");
        await page.PressUpdateAnswers99D68Async("Tab");
        await page.EnterClient35F85Async("");
        await page.ClickSaveForLaterAsync();
        await page.EnterTitleAsync(data.Resolve("{{data:title_287}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_288}}"));
        await page.VerifyResultAsync(data.Resolve("{{data:expected_result_value_289}}"), "value");

    }

    [Given(@"^I sign in to Duck Creek$")]
    [When(@"^I sign in to Duck Creek$")]
    [Then(@"^I sign in to Duck Creek$")]
    public async Task SignInToDuckCreekAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.NavigateAsync(data.Resolve("{{data:application_url}}"));
        data.Set("CheckTheLoopLogin", data.Resolve("{B[Loop Login]} = 0"));
        data.Set("Loop Login", data.Resolve("{{data:loop_login}}"));
        data.Set("URL", data.Resolve("{{data:url}}"));
        data.Set("UserName", data.Resolve("{{env:CL_DC_USERNAME}}"));
        data.Set("Password", data.Resolve("{{env:CL_DC_PASSWORD}}"));
        await page.NavigateAsync(data.Resolve("{{data:application_url_2}}"));
        await page.WaitForBODYAsync("Exists");
        await page.PauseAsync(1000);

    }

    [Given(@"^I complete restart Edge Popup$")]
    [When(@"^I complete restart Edge Popup$")]
    [Then(@"^I complete restart Edge Popup$")]
    public async Task CompleteRestartEdgePopupAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyRestartMicrosoftEdgeMessageOKAsync("Exists", "");
        await page.ClickRestartMicrosoftEdgeMessageOKAsync();

    }

    [Given(@"^I sign in to Duck Creek for logged in user$")]
    [When(@"^I sign in to Duck Creek for logged in user$")]
    [Then(@"^I sign in to Duck Creek for logged in user$")]
    public async Task SignInToDuckCreekForLoggedInUserAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyLoggedInUserAsync("Exists", "");

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

    [Given(@"^I sign in to Duck Creek for username$")]
    [When(@"^I sign in to Duck Creek for username$")]
    [Then(@"^I sign in to Duck Creek for username$")]
    public async Task SignInToDuckCreekForUsernameAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.EnterUserNameAsync(data.Resolve("{{env:CL_DC_USERNAME}}"));
        await page.PressUserNameAsync("Tab");
        await page.EnterPasswordAsync(data.Resolve("{{env:CL_DC_PASSWORD}}"));
        await page.ClickLoginAsync();
        await page.WaitForLoginAsync("Absent");
        data.Set("Loop Login", data.Resolve("{{data:loop_login_2}}"));
        data.Set("DocPath", data.Resolve("{{data:docpath}}"));
        data.Set("GetHostname", "\"\"\"${COMPUTERNAME}\"\"\"");
        data.Set("AgentName", data.Resolve("{B[GetHostname]}"));

    }

    [Given(@"^I search by Desc$")]
    [When(@"^I search by Desc$")]
    [Then(@"^I search by Desc$")]
    public async Task SearchByDescAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.EnterSearchTextAsync(data.Resolve("{B[QuoteDescription]}"));
        await page.PressSearchTextAsync("Tab");
        await page.PressSearchTextAsync("Tab");
        await page.PressSearchTextAsync("Tab");
        await page.PressSearchTextAsync("Tab");
        await page.ClickQuickSearchButtonAsync();
        await page.EnterSearchMethodEGDescriptionPolicyAsync(data.Resolve("{{data:search_method_e_g_description_policy_333}}"));
        await page.PressSearchMethodEGDescriptionPolicyAsync("Tab");
        await page.ClickSearchButtonAsync();
        await page.WaitForViewPolicyAsync("Exists");
        await page.PressViewPolicyAsync("TAB");
        await page.ClickViewPolicyAsync();

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
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_341}}"));
        await page.PressIsThisCoverageBoundAsync("Tab");
        await page.PressIsThisCoverageBoundAsync("CLICK");
        await page.PressIsThisCoverageBoundAsync("Tab");
        await page.VerifyOrderAuditAsync("Exists", "");
        await page.EnterOrderAuditAsync(data.Resolve("{{data:order_audit_343}}"));
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
        await page.VerifyIsThisCoverageBoundAsync(data.Resolve("{{data:expected_is_this_coverage_bound_value_351}}"), "Value");
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_352}}"));
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
        await page.VerifyFullTermPremiumAsync(data.Resolve("{{data:expected_full_term_premium_value_384}}"), "value");
        await page.VerifyPremiumWrittenAsync(data.Resolve("{{data:expected_premium_written_value_385}}"), "value");
        await page.VerifyPriorPremiumAsync(data.Resolve("{{data:expected_prior_premium_value_386}}"), "value");
        await page.VerifyPremiumChangeAsync(data.Resolve("{{data:expected_premium_change_value_387}}"), "value");
        await page.EnterTitleAsync(data.Resolve("{{data:title_389}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_390}}"));
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
        await page.VerifyStatusCodeAsync(data.Resolve("{{data:expected_statuscode_value_394}}"), "value");
        await page.PauseAsync(1000);
        await page.PauseAsync(1000);
        data.Set("PowershellArguments", data.Resolve("powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\CP\\\" -FileName \"CP_BASIC\" -State  \"AZ\" -QuoteID \"{B[QuoteID]}\""));
        data.Set("SummaryResults", await page.CaptureValueAsync("InnerText"));
        data.Set("SummaryResults", data.Resolve("{{data:summaryresults}}"));
        data.Set("SummaryResults", data.Resolve("{{data:summaryresults_2}}"));
        data.Set("SummaryResults", data.Resolve("{{data:summaryresults_3}}"));
        data.Set("SummaryResults", data.Resolve("{{data:summaryresults_4}}"));

    }

}
