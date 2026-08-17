using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "BAP Basic Policy")]
public sealed class BAPBasicPolicySteps
{
    private readonly ScenarioContext _scenario;
    public BAPBasicPolicySteps(ScenarioContext scenario) => _scenario = scenario;

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
        await page.EnterTitleAsync(data.Resolve("{{data:title_45}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_46}}"));
        await page.VerifyResultAsync(data.Resolve("{{data:expected_result_value_47}}"), "value");

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
        await page.EnterEffectiveDate95094Async(data.Resolve("{{data:effectivedate_51}}"));
        await page.PressEffectiveDate95094Async("Tab");
        if (data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
                    await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_52}}"));
                    await page.PressYearsInBusinessAsync("Tab");
        }
        await page.PauseAsync(1000);
        if (data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_54}}"));
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
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_58}}"));
        await page.PressWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync("Tab");
        await page.PressWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync("Tab");
        data.Set("StateIsKansas", "Alabama==\"Kansas\"; Expression= 'Alabama'=='Kansas'");
        if (data.Condition("'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"BAP\""))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_60}}"));
                    await page.PressPrimaryRatingStateAsync("Enter");
                    await page.PressPrimaryRatingStateAsync("Tab");
                    await page.PressPrimaryRatingStateAsync("Tab");
        }
        if (data.Condition("'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"UMB\" || 'Product (LOB)' == \"BAP\""))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_61}}"));
                    await page.PressPrimaryRatingStateAsync("Down");
                    await page.PressPrimaryRatingStateAsync("Enter");
                    await page.PressPrimaryRatingStateAsync("Tab");
                    await page.PressPrimaryRatingStateAsync("Tab");
        }
        data.Set("StateIsVirginia", "Alabama==\"Virginia\"; Expression= 'Alabama'=='Virginia'");
        if (data.Condition("'Product (LOB)' == \"BAP\""))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_63}}"));
                    await page.PressPrimaryRatingStateAsync("Tab");
        }
        if (data.Condition("'Product (LOB)' == \"BAP\""))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_64}}"));
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
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_68}}"));
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
        await page.EnterDescriptionOfSpecifiedOperationAsync("AL BAP Basic {NMONTH}.{NDAY}.{NYEAR} {Time}");
        await page.PressDescriptionOfSpecifiedOperationAsync("Tab");
        await page.VerifyDescriptionOfSpecifiedOperationAsync("{XB[QuoteDescription]}", "value");

    }

    [Given(@"^I complete Business Auto policy\\-specific fields$")]
    [When(@"^I complete Business Auto policy\\-specific fields$")]
    [Then(@"^I complete Business Auto policy\\-specific fields$")]
    public async Task CompleteBusinessAutoPolicySpecificFieldsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new DiscountsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyBAPSpecificFieldsOKAsync("Absent", "");
        await page.EnterNAICSCodeSearchValueAsync(data.Resolve("{{data:naics_code_search_value_79}}"));
        await page.PressNAICSCodeSearchValueAsync("CLICK");
        await page.PressNAICSCodeSearchValueAsync("Tab");
        await page.PressNAICSCodeSearchValueAsync("Tab");
        await page.PauseAsync(1000);
        await page.EnterNAICSCodeSearchResultsAsync(data.Resolve("{{data:naics_code_search_results_81}}"));
        await page.PressNAICSCodeSearchResultsAsync("CLICK");
        await page.PressNAICSCodeSearchResultsAsync("Tab");
        await page.PressNAICSCodeSearchResultsAsync("Tab");
        await page.PauseAsync(1000);
        if (data.Condition("State != \"NY\""))
        {
                    await page.EnterAccountCreditAsync(data.Resolve("{{data:account_credit_83}}"));
                    await page.PressAccountCreditAsync("Tab");
                    await page.PressAccountCreditAsync("Tab");
        }
        await page.PauseAsync(1000);
        await page.WaitForBAPSpecificFieldsOKAsync("Exists");
        await page.ClickBAPSpecificFieldsOKAsync();
        await page.WaitForBAPSpecificFieldsOKAsync("Absent");
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
        await page.VerifyReferenceNumberAsync(data.Resolve("{{data:expected_reference_number_innertext_96}}"), "InnerText");
        await page.PauseAsync(1000);
        await page.PauseAsync(1000);

    }

    [Given(@"^I complete underwriting information from the policy information screen$")]
    [When(@"^I complete underwriting information from the policy information screen$")]
    [Then(@"^I complete underwriting information from the policy information screen$")]
    public async Task CompleteUnderwritingInformationFromThePolicyInformationScreenAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyInformationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickEnterPriorLossInformationAsync();
        await page.WaitForLossExperienceHeadingAsync("Exists");
        await page.SetNoKnownLossesAsync(data.Resolve("{{data:no_known_losses_101}}"));
        await page.PressNoKnownLossesAsync("Tab");
        await page.VerifyNoKnownLossesAsync(data.Resolve("{{data:expected_no_known_losses_value_102}}"), "value");
        await page.PauseAsync(1000);
        await page.ClickInsuranceHistoryAsync();
        await page.WaitForIsThereAPriorCarrierAsync("Exists");
        await page.EnterIsThereAPriorCarrierAsync(data.Resolve("{{data:is_there_a_prior_carrier_106}}"));
        await page.PressIsThereAPriorCarrierAsync("Enter");
        await page.PressIsThereAPriorCarrierAsync("Tab");
        await page.ClickIsThereAPriorCarrierAsync();
        await page.PressIsThereAPriorCarrierAsync("CLICK");
        await page.PressIsThereAPriorCarrierAsync("Tab");
        await page.EnterCarrierAsync(data.Resolve("{{data:carrier_109}}"));
        await page.PressCarrierAsync("Tab");
        await page.EnterPolicyNumberAsync(data.Resolve("{{data:policy_number_110}}"));
        await page.PressPolicyNumberAsync("Tab");
        await page.EnterPolicyTypeAsync(data.Resolve("{{data:policy_type_111}}"));
        await page.PressPolicyTypeAsync("Tab");
        await page.EnterEffectiveDateAsync("{DATE[][-2y][MM'/'dd'/'yyyy]}");
        await page.PressEffectiveDateAsync("Tab");
        await page.EnterExpirationDateAsync("{DATE[][][MM'/'dd'/'yyyy]}");
        await page.PressExpirationDateAsync("Tab");
        await page.EnterModificationFactorAsync(data.Resolve("{{data:modificationfactor_114}}"));
        await page.PressModificationFactorAsync("Tab");
        await page.EnterTotalPremiumAsync(data.Resolve("{{data:total_premium_115}}"));
        await page.PressTotalPremiumAsync("Tab");
        await page.ClickOtherInsuranceHistoryOKAsync();
        await page.WaitForDetailAsync("Exists");
        await page.ClickReturnToQuoteAsync();
        await page.WaitForClientAsync("Exists");

    }

    [Given(@"^I navigate to policy coverages$")]
    [When(@"^I navigate to policy coverages$")]
    [Then(@"^I navigate to policy coverages$")]
    public async Task NavigateToPolicyCoveragesAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForPolicyCovgerageAsync("Exists");
        await page.ClickPolicyCovgerageAsync();
        await page.WaitForPolicyCovg26786Async("Exists");
        await page.EnterTrailerInterchangeCompDeductibleAsync(data.Resolve("{{data:trailer_interchange_comp_deductible_123}}"));
        await page.PressTrailerInterchangeCompDeductibleAsync("Click");
        await page.PressTrailerInterchangeCompDeductibleAsync("Enter");
        await page.PressTrailerInterchangeCompDeductibleAsync("Tab");
        await page.EnterTrailerInterchangeCollisionDeductibleAsync(data.Resolve("{{data:trailer_interchange_collision_deductible_124}}"));
        await page.PressTrailerInterchangeCollisionDeductibleAsync("Click");
        await page.PressTrailerInterchangeCollisionDeductibleAsync("Enter");
        await page.PressTrailerInterchangeCollisionDeductibleAsync("Tab");
        await page.WaitForPolicyCovg26786Async("Exists");

    }

    [Given(@"^I complete required location information$")]
    [When(@"^I complete required location information$")]
    [Then(@"^I complete required location information$")]
    public async Task CompleteRequiredLocationInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForLocationA1D91Async("Exists");
        await page.ClickLocationA1D91Async();
        await page.WaitForLocation82D95Async("Exists");
        await page.VerifyZipCodeD2DBAAsync("[0-9]{5}-[0-9]{4}", "Regex:value");

    }

    [Given(@"^I navigate to state details$")]
    [When(@"^I navigate to state details$")]
    [Then(@"^I navigate to state details$")]
    public async Task NavigateToStateDetailsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForStateDetails33183Async("Exists");
        await page.ClickStateDetails33183Async();
        await page.WaitForStateDetailsDetailAsync("Exists");
        await page.ClickStateDetailsDetailAsync();
        await page.WaitForStateDetails72631Async("Exists");
        await page.ClickUMUIMOKAsync();
        await page.WaitForStateDetailsDetailAsync("Exists");

    }

    [Given(@"^I complete vehicle information$")]
    [When(@"^I complete vehicle information$")]
    [Then(@"^I complete vehicle information$")]
    public async Task CompleteVehicleInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForRiskScheduleAsync("Exists");
        await page.ClickRiskScheduleAsync();
        await page.WaitForRiskDDE70Async("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_140}}"));
        await page.ClickAddRiskAtThisLocationAsync();
        await page.WaitForVINAsync("Exists");
        await page.PressVINAsync("TAB");
        await page.PressVINAsync("Tab");
        await page.EnterVINAsync(data.Resolve("{{data:vin_144}}"));
        await page.PressVINAsync("Tab");
        await page.PressVINAsync("Tab");
        await page.PressVINAsync("Tab");
        await page.ClickPhysicalDamageOKAsync();
        await page.WaitForRiskDDE70Async("Exists");
        await page.WaitForShowAllLocationsAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_148}}"));
        await page.PressVehicleTypeAsync("Tab");
        await page.PressVehicleTypeAsync("Tab");
        await page.PressVehicleTypeAsync("Tab");
        await page.ClickAddRiskAtThisLocationAsync();
        await page.WaitForVINAsync("Exists");
        await page.PressVINAsync("TAB");
        await page.PressVINAsync("Tab");
        await page.EnterVINAsync(data.Resolve("{{data:vin_152}}"));
        await page.PressVINAsync("Tab");
        await page.PressVINAsync("Tab");
        await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync(data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_153}}"));
        await page.PressIsThisVehicleUsedInSnowPlowOperationsAsync("Tab");
        await page.PressIsThisVehicleUsedInSnowPlowOperationsAsync("Tab");
        await page.PressIsThisVehicleUsedInSnowPlowOperationsAsync("Tab");
        await page.ClickPhysicalDamageOKAsync();
        await page.WaitForRiskDDE70Async("Exists");

    }

    [Given(@"^I complete driver information$")]
    [When(@"^I complete driver information$")]
    [Then(@"^I complete driver information$")]
    public async Task CompleteDriverInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickDriverSchedule161DFAsync();
        await page.WaitForDriverSchedule79DC6Async("Exists");
        await page.ClickAddDriverAsync();
        await page.WaitForDriverDetailAsync("Exists");
        await page.EnterFirstName813D1Async(data.Resolve("{{data:iframe_duck_creek_policy_first_name_160}}"));
        await page.PressFirstName813D1Async("Tab");
        await page.PressFirstName813D1Async("Tab");
        await page.PressFirstName813D1Async("Tab");
        await page.EnterLastName34FF6Async(data.Resolve("{{data:iframe_duck_creek_policy_last_name_161}}"));
        await page.PressLastName34FF6Async("Tab");
        await page.PressLastName34FF6Async("Tab");
        await page.PressLastName34FF6Async("Tab");
        await page.EnterDateOfBirthAsync("{DATE[09-05-2026][-40y][MM-dd-yyyy]}");
        await page.PressDateOfBirthAsync("Tab");
        await page.PressDateOfBirthAsync("Tab");
        await page.PressDateOfBirthAsync("Tab");
        await page.EnterStateLicensedAsync(data.Resolve("{{data:iframe_duck_creek_policy_state_licensed_163}}"));
        await page.PressStateLicensedAsync("Tab");
        await page.PressStateLicensedAsync("Tab");
        await page.PressStateLicensedAsync("Tab");
        await page.VerifyDriversLicenseNumberAsync(data.Resolve("{{data:expected_iframe_duck_creek_policy_drivers_license_number_innertext_164}}"), "InnerText");
        await page.EnterSexAsync(data.Resolve("{{data:iframe_duck_creek_policy_sex_165}}"));
        await page.PressSexAsync("Tab");
        await page.EnterMaritalStatusAsync(data.Resolve("{{data:iframe_duck_creek_policy_marital_status_166}}"));
        await page.PressMaritalStatusAsync("Tab");
        await page.PressMaritalStatusAsync("Tab");
        await page.EnterYearLicensedAsync(data.Resolve("{{data:iframe_duck_creek_policy_year_licensed_167}}"));
        await page.PressYearLicensedAsync("Tab");
        await page.PressYearLicensedAsync("Tab");
        await page.EnterDateOfHireAsync(data.Resolve("{{data:iframe_duck_creek_policy_date_of_hire_168}}"));
        await page.PressDateOfHireAsync("Tab");
        await page.PressDateOfHireAsync("Tab");
        await page.EnterDoYouHaveACDLLicenseAsync(data.Resolve("{{data:iframe_duck_creek_policy_do_you_have_a_cdl_license_169}}"));
        await page.PressDoYouHaveACDLLicenseAsync("Tab");
        await page.ClickOKAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.WaitForIFRAME6D695Async("Absent");
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");

    }

    [Given(@"^I complete required endorsement information$")]
    [When(@"^I complete required endorsement information$")]
    [Then(@"^I complete required endorsement information$")]
    public async Task CompleteRequiredEndorsementInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForEndorsementsC27F0Async("Exists");
        await page.ClickEndorsementsC27F0Async();
        await page.WaitForEndorsementsHeadingA3D50Async("Exists");

    }

    [Given(@"^I add endorsement$")]
    [When(@"^I add endorsement$")]
    [Then(@"^I add endorsement$")]
    public async Task AddEndorsementAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyEndorsementsHeadingA3D50Async("Absent", "");
        await page.ClickEndorsementsC27F0Async();
        await page.WaitForEndorsementsHeadingA3D50Async("Exists");
        await page.WaitForClickAddEndorsementAsync("Visible");
        await page.ClickClickAddEndorsementAsync();
        await page.WaitForEndorsementDetailAsync("Exists");
        if (data.Condition("Year != NULL"))
        {
                    await page.EnterCA9940YearAsync("");
        }
        if (data.Condition("Make != NULL"))
        {
                    await page.EnterCA9940MakeAsync("");
        }
        if (data.Condition("Model != NULL"))
        {
                    await page.EnterCA9940ModelAsync("");
        }
        if (data.Condition("VIN != NULL"))
        {
                    await page.EnterCA9940VINAsync("");
        }
        await page.WaitForOKAsync("Exists");
        await page.WaitForEndorsementType624ADAsync("Exists");
        await page.ClickEndorsementType624ADAsync();
        await page.EnterEndorsementType624ADAsync(data.Resolve("{{data:endorsement_type_192}}"));
        await page.PressEndorsementType624ADAsync("Tab");
        await page.EnterEndorsementType624ADAsync(data.Resolve("{{data:endorsement_type_193}}"));
        await page.PressEndorsementType624ADAsync("Click");
        await page.PressEndorsementType624ADAsync("Enter");
        await page.PressEndorsementType624ADAsync("Tab");
        await page.PressEndorsementType624ADAsync("Tab");
        await page.ClickOKAsync();
        await page.VerifyIFRAMEF0A48Async("Exists", "");
        await page.WaitForIFRAMEF0A48Async("Absent");
        await page.WaitForEndorsementsHeadingA3D50Async("Exists");

    }

    [Given(@"^I complete required additional\\-interest information$")]
    [When(@"^I complete required additional\\-interest information$")]
    [Then(@"^I complete required additional\\-interest information$")]
    public async Task CompleteRequiredAdditionalInterestInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForAdditionalInterestsAsync("Exists");
        await page.ClickAdditionalInterestsAsync();
        await page.WaitForAddlInterestsAsync("Exists");

    }

    [Given(@"^I complete required underwriting question information$")]
    [When(@"^I complete required underwriting question information$")]
    [Then(@"^I complete required underwriting question information$")]
    public async Task CompleteRequiredUnderwritingQuestionInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickUWQuestions368CCAsync();
        await page.WaitForUWQuestionsF3D9FAsync("Exists");
        await page.ClickUpdateAnswersButtonAsync();
        await page.PressUpdateAnswersButtonAsync("Tab");
        await page.PressUpdateAnswersButtonAsync("Tab");
        await page.EnterAreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicyAsync(data.Resolve("{{data:are_there_any_commercial_vehicles_owned_by_the_applicant_not_insured_on_the_policy_204}}"));
        await page.PressAreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicyAsync("Tab");
        await page.PressAreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicyAsync("Tab");
        await page.PressAreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicyAsync("Tab");
        await page.WaitForAreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicyAsync("Equal");
        await page.EnterAnyPersonalAutoPolicyListingNameInsuredAsync(data.Resolve("{{data:anypersonalautopolicylistingnameinsured_206}}"));
        await page.PressAnyPersonalAutoPolicyListingNameInsuredAsync("Tab");
        await page.PressAnyPersonalAutoPolicyListingNameInsuredAsync("Tab");
        await page.PressAnyPersonalAutoPolicyListingNameInsuredAsync("Tab");
        await page.EnterAnyVehicleCoveredRegisteredInNotPrimaryStateAsync(data.Resolve("{{data:anyvehiclecoveredregisteredinnotprimarystate_207}}"));
        await page.PressAnyVehicleCoveredRegisteredInNotPrimaryStateAsync("Tab");
        await page.PressAnyVehicleCoveredRegisteredInNotPrimaryStateAsync("Tab");
        await page.PressAnyVehicleCoveredRegisteredInNotPrimaryStateAsync("Tab");
        await page.EnterBorrowingHiringOrLeasingWithinYearAsync(data.Resolve("{{data:borrowinghiringorleasingwithinyear_208}}"));
        await page.PressBorrowingHiringOrLeasingWithinYearAsync("Tab");
        await page.PressBorrowingHiringOrLeasingWithinYearAsync("Tab");
        await page.PressBorrowingHiringOrLeasingWithinYearAsync("Tab");
        await page.PressBorrowingHiringOrLeasingWithinYearAsync("Tab");
        await page.PressBorrowingHiringOrLeasingWithinYearAsync("Tab");
        await page.WaitForBorrowingHiringOrLeasingWithinYearAsync("Equal");
        await page.WaitForAnyVehicleCoveredRegisteredInNotPrimaryStateAsync("Equal");
        await page.VerifyHasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiringAsync("Exists", "");
        await page.EnterHasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiringAsync(data.Resolve("{{data:has_any_applicant_been_convicted_of_a_felony_or_been_involved_in_any_incidents_or_claims_relating_to_sexual_abuse_or_molestation_allegations_discrimination_arson_fraud_bribery_or_negligent_hiring_212}}"));
        await page.PressHasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiringAsync("Tab");
        await page.PressHasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiringAsync("Tab");
        await page.PressHasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiringAsync("Tab");

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
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_215}}"));
        await page.PressBillTypeAsync("Tab");
        await page.PressBillTypeAsync("TAB");
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_218}}"));
        await page.PressPayPlanAsync("Tab");
        await page.PressPayPlanAsync("TAB");
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_222}}"));
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

    [Given(@"^I verify premium$")]
    [When(@"^I verify premium$")]
    [Then(@"^I verify premium$")]
    public async Task VerifyPremiumAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForPricingF3185Async("Exists");
        await page.ClickPricingF3185Async();
        await page.WaitForPricingHeadingAsync("Exists");
        await page.VerifyPremiumAsync(data.Resolve("{{data:expected_premium_value_233}}"), "value");

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
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_237}}"));
        await page.PressIsThisCoverageBoundAsync("Tab");
        await page.PressIsThisCoverageBoundAsync("CLICK");
        await page.PressIsThisCoverageBoundAsync("Tab");
        await page.VerifyOrderAuditAsync("Exists", "");
        await page.EnterOrderAuditAsync(data.Resolve("{{data:order_audit_239}}"));
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
        await page.VerifyIsThisCoverageBoundAsync(data.Resolve("{{data:expected_is_this_coverage_bound_value_247}}"), "Value");
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_248}}"));
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
        await page.VerifyFullTermPremiumAsync(data.Resolve("{{data:expected_full_term_premium_value_280}}"), "value");
        await page.VerifyPremiumWrittenAsync(data.Resolve("{{data:expected_premium_written_value_281}}"), "value");
        await page.VerifyPriorPremiumAsync(data.Resolve("{{data:expected_prior_premium_value_282}}"), "value");
        await page.VerifyPremiumChangeAsync(data.Resolve("{{data:expected_premium_change_value_283}}"), "value");
        await page.EnterTitleAsync(data.Resolve("{{data:title_285}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_286}}"));
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
        await page.VerifyStatusCodeAsync(data.Resolve("{{data:expected_statuscode_value_290}}"), "value");
        await page.PauseAsync(1000);
        await page.PauseAsync(1000);
        data.Set("PowershellArguments", data.Resolve("powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\BAP\\\" -FileName \"BAP_BASIC\" -State  \"AL\" -QuoteID \"{B[QuoteID]}\""));
        data.Set("SummaryResults", await page.CaptureValueAsync("InnerText"));
        data.Set("SummaryResults", data.Resolve("{{data:summaryresults}}"));
        data.Set("SummaryResults", data.Resolve("{{data:summaryresults_2}}"));
        data.Set("SummaryResults", data.Resolve("{{data:summaryresults_3}}"));
        data.Set("SummaryResults", data.Resolve("{{data:summaryresults_4}}"));

    }

}
