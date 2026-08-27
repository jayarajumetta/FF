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
        await page.ClickEntityTypeAsync();
        await page.WaitForFirstName55A0BAsync("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets FirstName55A0B
        await page.EnterFirstName55A0BAsync(data.Resolve("{{data:first_name_7}}"));
        // v56 suppressed redundant Tosca keyboard steering: FirstName55A0B CLICK
        // v56 suppressed redundant Tosca keyboard steering: FirstName55A0B Tab
        await page.EnterMiddleNameAsync(data.Resolve("{{data:middle_name_8}}"));
        await page.EnterLastNameAsync(data.Resolve("{{runtime:LastName_0040}}"));
        await page.EnterDOBAsync(data.Resolve("{DATE[][-40y][MM-dd-yyyy]}"));
        if (data.Condition("State!=\"CA\""))
        {
                    await page.EnterGender1DC4AAsync(data.Resolve("{{data:gender_11}}"));
        }
        await page.EnterEntityTypeAsync(data.Resolve("{{data:entity_type_13}}"));
        // Source step 0041: RANDOM input for Primary Phone.
        await page.EnterPrimaryPhoneAsync(data.Resolve("{{runtime:PrimaryPhone_0041}}"));
        await page.EnterAddress17A1FBAsync(data.Resolve("{{data:address1_15}}"));
        await page.EnterZipCode26D22Async(data.Resolve("{{data:zipcode_16}}"));
        await page.ClickClientSearchCA696Async();
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
        await page.WaitForOrderSSN68C87Async("Exists");
        await page.ClickOrderSSN68C87Async();
        await page.WaitForEnterSSN6B3FBAsync("Exists");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets EnterSSN6B3FB
        await page.EnterEnterSSN6B3FBAsync(data.Resolve("{{runtime:InsuredSSN}}"));
        data.Set("Last4SSN", data.Get("InsuredSSN").Length >= 4 ? data.Get("InsuredSSN")[^4..] : data.Get("InsuredSSN"));
        // v56 suppressed redundant Tosca keyboard steering: EnterSSN6B3FB Tab
        await page.ClickEnterSSN6B3FBAsync();
        await page.PressEnterSSN6B3FBAsync("Doubleclick");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets EnterSSN6B3FB
        await page.ClickVerify8CDBEAsync();
        await page.WaitForVerify8CDBEAsync("Absent");
        await page.WaitForSocialSecurityAsync("Equal");
        await page.VerifySocialSecurityAsync(data.Resolve("XXX-XX-{B[Last4SSN]}"), "InnerText");
        await page.WaitForPleaseVerifySSN3EAB9Async("Absent");
        if (data.Condition("'Product (LOB)' != \"UMB\""))
        {
                    await page.EnterNameOfAuditContactAsync(data.Resolve("{{data:name_of_audit_contact_33}}"));
                    await page.EnterAuditTelephoneAsync(data.Resolve("{{runtime:AuditTelephone_0048}}"));
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets NameOfAuditContact
                    await page.ClickNameOfAuditContactAsync();
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets NameOfAuditContact
        }
        await page.EnterNameOfInspectionContactAsync(data.Resolve("{{data:name_of_inspection_contact_35}}"));
        await page.EnterInspectionTelephoneAsync(data.Resolve("{{runtime:InspectionTelephone_0048}}"));
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets NameOfInspectionContact
        await page.ClickNameOfInspectionContactAsync();
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets NameOfInspectionContact
        await page.EnterInsuredEMailAddressAsync(data.Resolve("{{data:insured_e_mail_address_37}}"));
        // v56 suppressed redundant Tosca keyboard steering: InsuredEMailAddress CLICK
        // v56 suppressed redundant Tosca keyboard steering: InsuredEMailAddress Tab
        await page.EnterWebsiteAddressAsync(data.Resolve("{{data:website_address_38}}"));
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Address2
        await page.VerifyZipCode26D22Async("[0-9]{5}-[0-9]{4}", "Regex:value");
        data.Set("State", data.Resolve("{{data:state}}"));
        data.Set("Product (LOB)", data.Resolve("{{data:product_lob}}"));
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
        if (data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
                    await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_52}}"));
        }
        await page.PauseAsync(1000);
        if (data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_54}}"));
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
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_58}}"));
        if (data.Condition("'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"BAP\""))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_60}}"));
        }
        if (data.Condition("'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"UMB\" || 'Product (LOB)' == \"BAP\""))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_61}}"));
                    await page.PressPrimaryRatingStateAsync("Down");
                    // v56 suppressed redundant Tosca keyboard steering: PrimaryRatingState Enter
                    // v56 suppressed redundant Tosca keyboard steering: PrimaryRatingState Tab
        }
        if (data.Condition("'Product (LOB)' == \"BAP\""))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_63}}"));
        }
        if (data.Condition("'Product (LOB)' == \"BAP\""))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_64}}"));
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
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_68}}"));
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
        await page.EnterDescriptionOfSpecifiedOperationAsync("AL BAP Basic {NMONTH}.{NDAY}.{NYEAR} {Time}");
        data.Set("QuoteDescription", await page.CaptureDescriptionOfSpecifiedOperationAsync("value"));

    }

    [Given(@"^I complete Business Auto policy\-specific fields$")]
    [When(@"^I complete Business Auto policy\-specific fields$")]
    [Then(@"^I complete Business Auto policy\-specific fields$")]
    public async Task CompleteBusinessAutoPolicySpecificFieldsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new DiscountsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyBAPSpecificFieldsOKAsync("Absent", "");
        await page.EnterNAICSCodeSearchValueAsync(data.Resolve("{{data:naics_code_search_value_79}}"));
        // v56 suppressed redundant Tosca keyboard steering: NAICSCodeSearchValue CLICK
        // v56 suppressed redundant Tosca keyboard steering: NAICSCodeSearchValue Tab
        await page.PauseAsync(1000);
        await page.EnterNAICSCodeSearchResultsAsync(data.Resolve("{{data:naics_code_search_results_81}}"));
        // v56 suppressed redundant Tosca keyboard steering: NAICSCodeSearchResults CLICK
        // v56 suppressed redundant Tosca keyboard steering: NAICSCodeSearchResults Tab
        await page.PauseAsync(1000);
        if (data.Condition("State != \"NY\""))
        {
                    await page.EnterAccountCreditAsync(data.Resolve("{{data:account_credit_83}}"));
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
        await page.VerifyNoKnownLossesAsync(data.Resolve("{{data:expected_no_known_losses_value_102}}"), "value");
        await page.PauseAsync(1000);
        await page.ClickInsuranceHistoryAsync();
        await page.WaitForIsThereAPriorCarrierAsync("Exists");
        await page.EnterIsThereAPriorCarrierAsync(data.Resolve("{{data:is_there_a_prior_carrier_106}}"));
        await page.ClickIsThereAPriorCarrierAsync();
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets IsThereAPriorCarrier
        await page.EnterCarrierAsync(data.Resolve("{{data:carrier_109}}"));
        await page.EnterPolicyNumberAsync(data.Resolve("{{data:policy_number_110}}"));
        await page.EnterPolicyTypeAsync(data.Resolve("{{data:policy_type_111}}"));
        await page.EnterEffectiveDateAsync(data.Resolve("{DATE[][-2y][MM'/'dd'/'yyyy]}"));
        await page.EnterExpirationDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.EnterModificationFactorAsync(data.Resolve("{{data:modificationfactor_114}}"));
        await page.EnterTotalPremiumAsync(data.Resolve("{{data:total_premium_115}}"));
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
        // v56 suppressed redundant Tosca keyboard steering: TrailerInterchangeCompDeductible Click
        // v56 suppressed redundant Tosca keyboard steering: TrailerInterchangeCompDeductible Enter
        // v56 suppressed redundant Tosca keyboard steering: TrailerInterchangeCompDeductible Tab
        await page.EnterTrailerInterchangeCollisionDeductibleAsync(data.Resolve("{{data:trailer_interchange_collision_deductible_124}}"));
        // v56 suppressed redundant Tosca keyboard steering: TrailerInterchangeCollisionDeductible Click
        // v56 suppressed redundant Tosca keyboard steering: TrailerInterchangeCollisionDeductible Enter
        // v56 suppressed redundant Tosca keyboard steering: TrailerInterchangeCollisionDeductible Tab
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
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets VIN
        await page.EnterVINAsync(data.Resolve("{{data:vin_144}}"));
        await page.ClickPhysicalDamageOKAsync();
        await page.WaitForRiskDDE70Async("Exists");
        await page.WaitForShowAllLocationsAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_148}}"));
        await page.ClickAddRiskAtThisLocationAsync();
        await page.WaitForVINAsync("Exists");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets VIN
        await page.EnterVINAsync(data.Resolve("{{data:vin_152}}"));
        await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync(data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_153}}"));
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
        await page.EnterLastName34FF6Async(data.Resolve("{{data:iframe_duck_creek_policy_last_name_161}}"));
        await page.EnterDateOfBirthAsync(data.Resolve("{DATE[09-05-2026][-40y][MM-dd-yyyy]}"));
        await page.EnterStateLicensedAsync(data.Resolve("{{data:iframe_duck_creek_policy_state_licensed_163}}"));
        await page.VerifyDriversLicenseNumberAsync(data.Resolve("{{data:expected_iframe_duck_creek_policy_drivers_license_number_innertext_164}}"), "InnerText");
        await page.EnterSexAsync(data.Resolve("{{data:iframe_duck_creek_policy_sex_165}}"));
        await page.EnterMaritalStatusAsync(data.Resolve("{{data:iframe_duck_creek_policy_marital_status_166}}"));
        await page.EnterYearLicensedAsync(data.Resolve("{{data:iframe_duck_creek_policy_year_licensed_167}}"));
        await page.EnterDateOfHireAsync(data.Resolve("{{data:iframe_duck_creek_policy_date_of_hire_168}}"));
        await page.EnterDoYouHaveACDLLicenseAsync(data.Resolve("{{data:iframe_duck_creek_policy_do_you_have_a_cdl_license_169}}"));
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
        await page.EnterEndorsementType624ADAsync(data.Resolve("{{data:endorsement_type_193}}"));
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Click
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Enter
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Tab
        await page.ClickOKAsync();
        await page.VerifyIFRAMEF0A48Async("Exists", "");
        await page.WaitForIFRAMEF0A48Async("Absent");
        await page.WaitForEndorsementsHeadingA3D50Async("Exists");

    }

    [Given(@"^I complete required additional\-interest information$")]
    [When(@"^I complete required additional\-interest information$")]
    [Then(@"^I complete required additional\-interest information$")]
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
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets UpdateAnswersButton
        await page.EnterAreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicyAsync(data.Resolve("{{data:are_there_any_commercial_vehicles_owned_by_the_applicant_not_insured_on_the_policy_204}}"));
        await page.WaitForAreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicyAsync("Equal");
        await page.EnterAnyPersonalAutoPolicyListingNameInsuredAsync(data.Resolve("{{data:anypersonalautopolicylistingnameinsured_206}}"));
        await page.EnterAnyVehicleCoveredRegisteredInNotPrimaryStateAsync(data.Resolve("{{data:anyvehiclecoveredregisteredinnotprimarystate_207}}"));
        await page.EnterBorrowingHiringOrLeasingWithinYearAsync(data.Resolve("{{data:borrowinghiringorleasingwithinyear_208}}"));
        await page.WaitForBorrowingHiringOrLeasingWithinYearAsync("Equal");
        await page.WaitForAnyVehicleCoveredRegisteredInNotPrimaryStateAsync("Equal");
        await page.VerifyHasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiringAsync("Exists", "");
        await page.EnterHasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiringAsync(data.Resolve("{{data:has_any_applicant_been_convicted_of_a_felony_or_been_involved_in_any_incidents_or_claims_relating_to_sexual_abuse_or_molestation_allegations_discrimination_arson_fraud_bribery_or_negligent_hiring_212}}"));

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
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_218}}"));
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_222}}"));
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
        // v56 suppressed redundant Tosca keyboard steering: IsThisCoverageBound CLICK
        // v56 suppressed redundant Tosca keyboard steering: IsThisCoverageBound Tab
        await page.VerifyOrderAuditAsync("Exists", "");
        await page.EnterOrderAuditAsync(data.Resolve("{{data:order_audit_239}}"));
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
        await page.VerifyIsThisCoverageBoundAsync(data.Resolve("{{data:expected_is_this_coverage_bound_value_247}}"), "Value");
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_248}}"));
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
        await page.VerifyFullTermPremiumAsync(data.Resolve("{{data:expected_full_term_premium_value_280}}"), "value");
        await page.VerifyPremiumWrittenAsync(data.Resolve("{{data:expected_premium_written_value_281}}"), "value");
        await page.VerifyPriorPremiumAsync(data.Resolve("{{data:expected_prior_premium_value_282}}"), "value");
        await page.VerifyPremiumChangeAsync(data.Resolve("{{data:expected_premium_change_value_283}}"), "value");
        await page.EnterTitleAsync(data.Resolve("{{data:title_285}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_286}}"));
        data.Set("SessionId", await page.CaptureResultAsync("value"));

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

    }

}
