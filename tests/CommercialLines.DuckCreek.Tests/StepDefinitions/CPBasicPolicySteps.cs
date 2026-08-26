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
        // Source step 0044: RANDOM input for FEIN.
        await page.EnterFEINAsync(data.Resolve("{{runtime:FEIN_0044}}"));

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForQuickQuoteAsync("Exists");
        await page.SetQuickQuoteAsync(data.Resolve("{{data:quick_quote_2}}"));
        await page.WaitForUnderwritingInfoAsync("Exists");
        await page.EnterInsuredTypeAsync(data.Resolve("{{data:insured_type_4}}"));
        await page.ClickEntityTypeAsync();
        await page.WaitForBusinessNameAsync("Visible");
        await page.EnterBusinessNameAsync(data.Resolve("{{data:business_name_7}}"));
        await page.EnterEntityTypeAsync(data.Resolve("{{data:entity_type_8}}"));
        // Source step 0041: RANDOM input for Primary Phone.
        await page.EnterPrimaryPhoneAsync(data.Resolve("{{runtime:PrimaryPhone_0041}}"));
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Address17A1FB
        await page.EnterZipCode26D22Async(data.Resolve("{{data:zipcode_11}}"));
        await page.EnterAddress17A1FBAsync(data.Resolve("{{data:address1_12}}"));
        await page.VerifyYearsInBusinessAsync("Exists", "");
        await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_14}}"));
        if (data.Condition("'Product (LOB)' != \"UMB\""))
        {
                    await page.EnterNameOfAuditContactAsync(data.Resolve("{{data:name_of_audit_contact_16}}"));
        }
        // Source step 0045: RANDOM input for Audit Telephone #.
        if (data.Condition("'Product (LOB)' != \"UMB\""))
        {
            await page.EnterAuditTelephoneAsync(data.Resolve("{{runtime:AuditTelephone_0045}}"));
        }
        await page.EnterNameOfInspectionContactAsync(data.Resolve("{{data:name_of_inspection_contact_18}}"));
        // v56 suppressed redundant Tosca keyboard steering: NameOfInspectionContact CLICK
        // v56 suppressed redundant Tosca keyboard steering: NameOfInspectionContact CLICK
        // v56 suppressed redundant Tosca keyboard steering: NameOfInspectionContact Tab
        // Source step 0045: RANDOM input for Inspection Telephone #.
        await page.EnterInspectionTelephoneAsync(data.Resolve("{{runtime:InspectionTelephone_0045}}"));
        await page.EnterInsuredEMailAddressAsync(data.Resolve("{{data:insured_e_mail_address_20}}"));
        // v56 suppressed redundant Tosca keyboard steering: InsuredEMailAddress CLICK
        // v56 suppressed redundant Tosca keyboard steering: InsuredEMailAddress Tab
        await page.EnterWebsiteAddressAsync(data.Resolve("{{data:website_address_21}}"));
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Address2
        await page.VerifyZipCode26D22Async("[0-9]{5}-[0-9]{4}", "Regex:value");
        data.Set("State", data.Resolve("{{data:state}}"));
        data.Set("Product (LOB)", data.Resolve("{{data:product_lob}}"));

    }

    [Given(@"^I add a new Associated Client \- Business Owner Type \- Click Add Client$")]
    [When(@"^I add a new Associated Client \- Business Owner Type \- Click Add Client$")]
    [Then(@"^I add a new Associated Client \- Business Owner Type \- Click Add Client$")]
    public async Task AddANewAssociatedClientBusinessOwnerTypeClickAddClientAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForAddClientAsync("Exists");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets AddClient
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
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_37}}"));
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_40}}"));
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_44}}"));
        // v56 suppressed redundant Tosca keyboard steering: EasyPay CLICK
        // v56 suppressed redundant Tosca keyboard steering: EasyPay Enter
        // v56 suppressed redundant Tosca keyboard steering: EasyPay Tab
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
        // v56 suppressed redundant Tosca keyboard steering: IndividualType CLICK
        // v56 suppressed redundant Tosca keyboard steering: IndividualType Tab
        await page.WaitForPleaseVerifySSNF738AAsync("Exists");
        // Source step 0057: RANDOM input for MiddleName.
        await page.EnterMiddleNameAsync(data.Resolve("{{runtime:MiddleName_0057}}"));
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets FirstNameC5387
        // Source step 0057: RANDOM input for LastName.
        await page.EnterLastNameAsync(data.Resolve("{{runtime:LastName_0057}}"));
        await page.EnterDateOfBirth338D7Async(data.Resolve("{{data:dateofbirth_52}}"));
        await page.EnterAddress1D319BAsync(data.Resolve("{{data:address1_53}}"));
        await page.EnterCityAsync(data.Resolve("{{data:city_54}}"));
        await page.EnterStateAsync(data.Resolve("{{data:state_55}}"));
        await page.EnterZipCodeA088EAsync(data.Resolve("{{data:zipcode_56}}"));
        await page.EnterGender4973CAsync(data.Resolve("{{data:gender_57}}"));
        await page.WaitForClientSearch41F28Async("Exists");
        await page.ClickClientSearch41F28Async();
        // Source RANDOM FirstName entered after Client Search per Tosca source step.
        await page.EnterFirstName55A0BAsync(data.Resolve("{{runtime:FirstName_0057}}"));
        await page.VerifySearchResultsDuckCreekPolicyFirstCheckboxAsync("Absent", "");
        await page.ClickOKAsync();
        await page.ClickOrderSSN5E031Async();
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets EnterSSNFA186
        await page.PressEnterSSNFA186Async("Enter");
        await page.EnterEnterSSNFA186Async(data.Resolve("{{data:enter_ssn_65}}"));
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
        await page.WaitForCarrierAsync("Exists");
        await page.EnterCarrierAsync(data.Resolve("{{data:carrier_90}}"));
        await page.EnterPolicyNumberBA28EAsync(data.Resolve("{{data:policy_number_91}}"));
        await page.EnterPolicyTypeAsync(data.Resolve("{{data:policy_type_92}}"));
        await page.EnterEffectiveDateB557FAsync(data.Resolve("{DATE[][-2y][MM'/'dd'/'yyyy]}"));
        await page.EnterExpirationDate34EACAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.EnterModificationFactorAsync(data.Resolve("{{data:modificationfactor_95}}"));
        await page.EnterTotalPremiumAsync(data.Resolve("{{data:total_premium_96}}"));
        await page.ClickOtherInsuranceHistoryOKAsync();
        await page.WaitForDetail0F8C6Async("Exists");
        await page.ClickLossExperienceAsync();
        await page.WaitForNoKnownLossesAsync("Exists");
        await page.SetNoKnownLossesAsync(data.Resolve("{{data:no_known_losses_101}}"));
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
        if (data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
                    await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_110}}"));
        }
        await page.PauseAsync(1000);
        if (data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_112}}"));
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
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_116}}"));
        await page.PauseAsync(1000);
        if (data.Condition("'Product (LOB)' != \"WC\""))
        {
                    await page.WaitForPrimaryRatingStateAsync("Exists");
        }
        if (data.Condition("'Product (LOB)' != \"WC\""))
        {
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets PrimaryRatingState
        }
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_122}}"));
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
        await page.EnterDescriptionOfSpecifiedOperationAsync("AZ CP Basic {NMONTH}.{NDAY}.{NYEAR} {Time}");
        data.Set("QuoteDescription", await page.CaptureDescriptionOfSpecifiedOperationAsync("value"));
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
        // v56 suppressed redundant Tosca keyboard steering: DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup CLICK
        // v56 suppressed redundant Tosca keyboard steering: DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup Enter
        // v56 suppressed redundant Tosca keyboard steering: DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup Tab

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
        if (data.Condition("'Property Extension Endorsements' != NULL"))
        {
                    await page.EnterPropertyExtensionEndorsementsAsync(data.Resolve("{{data:property_extension_endorsements_149}}"));
                    // v56 suppressed redundant Tosca keyboard steering: PropertyExtensionEndorsements CLICK
                    // v56 suppressed redundant Tosca keyboard steering: PropertyExtensionEndorsements Enter
                    // v56 suppressed redundant Tosca keyboard steering: PropertyExtensionEndorsements Tab
        }
        if (data.Condition("'Utility Services' != NULL"))
        {
                    await page.EnterUtilityServicesAsync(data.Resolve("{{data:utility_services_150}}"));
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
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.WaitForAddress1C0AF1Async("Exists");
        await page.EnterMilesFromFireDepartmentAsync(data.Resolve("{{data:miles_from_fire_department_160}}"));
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.VerifyFeetFromHydrantAsync(data.Resolve("{{data:expected_feet_from_hydrant_value_163}}"), "NotEqual:Value");
        await page.WaitForAddress1C0AF1Async("Exists");
        await page.EnterFeetFromHydrantAsync(data.Resolve("{{data:feet_from_hydrant_165}}"));
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
        // v56 suppressed redundant Tosca keyboard steering: FeetFromHydrant CLICK
        // v56 suppressed redundant Tosca keyboard steering: FeetFromHydrant CLICK
        // v56 suppressed redundant Tosca keyboard steering: FeetFromHydrant Enter
        // v56 suppressed redundant Tosca keyboard steering: FeetFromHydrant Tab
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
        }
        if (data.Condition("'Year Built' != NULL"))
        {
                    await page.EnterYearBuiltAsync(data.Resolve("{{data:year_built_187}}"));
        }
        if (data.Condition("'Square Feet' != NULL"))
        {
                    await page.EnterSquareFeetAsync(data.Resolve("{{data:square_feet_188}}"));
        }
        if (data.Condition("Stories != NULL"))
        {
                    await page.EnterStoriesAsync(data.Resolve("{{data:stories_189}}"));
        }
        if (data.Condition("Interest != NULL"))
        {
                    await page.EnterInterestAsync(data.Resolve("{{data:interest_190}}"));
        }
        if (data.Condition("'Roof Type' != NULL"))
        {
                    await page.EnterRoofTypeAsync(data.Resolve("{{data:roof_type_191}}"));
        }
        if (data.Condition("Deductible != NULL"))
        {
                    await page.EnterDeductible592D9Async(data.Resolve("{{data:deductible_192}}"));
                    // v56 suppressed redundant Tosca keyboard steering: Deductible592D9 CLICK
                    // v56 suppressed redundant Tosca keyboard steering: Deductible592D9 CLICK
                    // v56 suppressed redundant Tosca keyboard steering: Deductible592D9 Tab
        }
        if (data.Condition("'Deductible Increased Theft' != NULL"))
        {
                    await page.EnterDeductibleIncreasedTheft99E5FAsync(data.Resolve("{{data:deductible_increased_theft_193}}"));
        }
        if (data.Condition("'Deductible Wind Hail' != NULL"))
        {
                    await page.EnterDeductibleWindHail911AFAsync(data.Resolve("{{data:deductible_wind_hail_194}}"));
        }
        if (data.Condition("'BG2 Symbol' != NULL"))
        {
                    await page.EnterBG2SymbolAsync(data.Resolve("{{data:bg2_symbol_195}}"));
        }
        if (data.Condition("'BG2 Symbol Prefix' != NULL"))
        {
                    await page.EnterBG2SymbolPrefixAsync(data.Resolve("{{data:bg2_symbol_prefix_196}}"));
                    // v56 suppressed redundant Tosca keyboard steering: BG2SymbolPrefix CLICK
                    // v56 suppressed redundant Tosca keyboard steering: BG2SymbolPrefix Tab
        }
        if (data.Condition("'Is the building cooled?' != NULL"))
        {
                    await page.EnterIsTheBuildingCooledAsync(data.Resolve("{{data:is_the_building_cooled_197}}"));
        }
        if (data.Condition("'Is the building heated with a Solid Fuel Heating Device?' != NULL"))
        {
                    await page.EnterIsTheBuildingHeatedWithASolidFuelHeatingDeviceAsync(data.Resolve("{{data:is_the_building_heated_with_a_solid_fuel_heating_device_198}}"));
                    // v56 suppressed redundant Tosca keyboard steering: IsTheBuildingHeatedWithASolidFuelHeatingDevice CLICK
                    // v56 suppressed redundant Tosca keyboard steering: IsTheBuildingHeatedWithASolidFuelHeatingDevice Tab
        }
        if (data.Condition("'Provide a List of Surrounding Exposure/Other Occupancies within 100 ft (Including North, East, South, and West)' != NULL"))
        {
                    await page.EnterProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWestAsync(data.Resolve("{{data:provide_a_list_of_surrounding_exposure_other_occupancies_within_100_ft_including_north_east_south_and_west_199}}"));
                    // v56 suppressed redundant Tosca keyboard steering: ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest CLICK
                    // v56 suppressed redundant Tosca keyboard steering: ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest Tab
        }
        if (data.Condition("'Eligible For Enhanced Wind Rating Program' != NULL"))
        {
                    await page.EnterEligibleForEnhancedWindRatingProgramAsync(data.Resolve("{{data:eligible_for_enhanced_wind_rating_program_200}}"));
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
        }
        if (data.Condition("'Risk Type' != NULL"))
        {
                    await page.EnterRiskTypeAsync(data.Resolve("{{data:risk_type_205}}"));
        }
        if (data.Condition("Coinsurance != NULL"))
        {
                    await page.EnterCoinsurance6348BAsync(data.Resolve("{{data:coinsurance_206}}"));
        }
        if (data.Condition("Deductible != NULL"))
        {
                    await page.EnterDeductible01AB9Async(data.Resolve("{{data:deductible_207}}"));
        }
        if (data.Condition("'Deductible Increased Theft' != NULL"))
        {
                    await page.EnterDeductibleIncreasedTheftF76DBAsync(data.Resolve("{{data:deductible_increased_theft_208}}"));
        }
        if (data.Condition("'Deductible Wind Hail' != NULL"))
        {
                    await page.EnterDeductibleWindHailAB1C3Async(data.Resolve("{{data:deductible_wind_hail_209}}"));
        }
        if (data.Condition("'Cause Of Loss' != NULL"))
        {
                    await page.EnterCauseOfLossAsync(data.Resolve("{{data:cause_of_loss_210}}"));
        }
        if (data.Condition("Valuation != NULL"))
        {
                    await page.EnterValuationAsync(data.Resolve("{{data:valuation_211}}"));
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
        }
        if (data.Condition("'Debris Removal Additional' != NULL"))
        {
                    await page.EnterDebrisRemovalAdditionalAsync(data.Resolve("{{data:debris_removal_additional_215}}"));
        }
        if (data.Condition("'Debris Removal Additional Limit' != NULL"))
        {
                    await page.EnterDebrisRemovalAdditionalLimitAsync(data.Resolve("{{data:debris_removal_additional_limit_216}}"));
        }
        if (data.Condition("'Vacant Building' != NULL"))
        {
                    await page.EnterVacantBuildingAsync(data.Resolve("{{data:vacant_building_217}}"));
        }
        if (data.Condition("'% Occupied' != NULL"))
        {
                    await page.EnterOccupiedAsync(data.Resolve("{{data:occupied_218}}"));
        }
        if (data.Condition("'Pier Or Wharf' != NULL"))
        {
                    await page.EnterPierOrWharfAsync(data.Resolve("{{data:pier_or_wharf_219}}"));
        }
        if (data.Condition("'Pier Or Wharf Construction' != NULL"))
        {
                    await page.EnterPierOrWharfConstructionAsync(data.Resolve("{{data:pier_or_wharf_construction_220}}"));
        }
        if (data.Condition("'Pier Or Wharf Cause Of Loss' != NULL"))
        {
                    await page.EnterPierOrWharfCauseOfLossAsync(data.Resolve("{{data:pier_or_wharf_cause_of_loss_221}}"));
        }
        if (data.Condition("'Pier Or Wharf COL Options' != NULL"))
        {
                    await page.EnterPierOrWharfCOLOptionsAsync(data.Resolve("{{data:pier_or_wharf_col_options_222}}"));
                    // v56 suppressed redundant Tosca keyboard steering: PierOrWharfCOLOptions CLICK
                    // v56 suppressed redundant Tosca keyboard steering: PierOrWharfCOLOptions Tab
        }
        if (data.Condition("'Vacancy Permit' != NULL"))
        {
                    await page.EnterVacancyPermitAsync(data.Resolve("{{data:vacancy_permit_223}}"));
        }
        if (data.Condition("'Pier Or Wharf COL Options' != NULL"))
        {
                    await page.WaitForPierOrWharfCOLOptionsAsync("Exists");
        }
        await page.ClickAddClassDCD8FAsync();
        if (data.Condition("(State !=\"OR\")||(State!=\"WA\")||(State!=\"VT\")"))
        {
                    await page.EnterSearchValue54F3CAsync(data.Resolve("{{data:search_value_226}}"));
                    // v56 suppressed redundant Tosca keyboard steering: SearchValue54F3C CLICK
                    // v56 suppressed redundant Tosca keyboard steering: SearchValue54F3C Tab
        }
        if (data.Condition("(State !=\"OR\")||(State!=\"WA\")||(State!=\"VT\")"))
        {
                    await page.EnterSearchResultsD0AA8Async(data.Resolve("{{data:search_results_227}}"));
                    // v56 suppressed redundant Tosca keyboard steering: SearchResultsD0AA8 CLICK
                    // v56 suppressed redundant Tosca keyboard steering: SearchResultsD0AA8 Enter
                    // v56 suppressed redundant Tosca keyboard steering: SearchResultsD0AA8 Tab
        }
        await page.EnterOccupancyTypeAsync(data.Resolve("{{data:occupancy_type_228}}"));
        // v56 suppressed redundant Tosca keyboard steering: OccupancyType CLICK
        // v56 suppressed redundant Tosca keyboard steering: OccupancyType Tab
        if (data.Condition("(State ==\"OR\")||(State==\"WA\")"))
        {
                    await page.EnterSearchResultsD0AA8Async("");
        }
        await page.ClickPropertyAddClassOKAsync();
        await page.EnterBuildingRatingGroupAsync(data.Resolve("{{data:building_rating_group_231}}"));
        // v56 suppressed redundant Tosca keyboard steering: BuildingRatingGroup CLICK
        // v56 suppressed redundant Tosca keyboard steering: BuildingRatingGroup Tab
        await page.EnterBuildingLimitAsync(data.Resolve("{{data:building_limit_232}}"));
        await page.EnterPersonalPropertyRatingGroupAsync(data.Resolve("{{data:personal_property_rating_group_233}}"));
        await page.EnterPersonalPropertyLimitAsync(data.Resolve("{{data:personal_property_limit_234}}"));
        await page.EnterPropertyOfOthersRatingGroupAsync(data.Resolve("{{data:property_of_others_rating_group_235}}"));
        await page.EnterPropertyOfOthersLimitAsync(data.Resolve("{{data:property_of_others_limit_236}}"));
        if (data.Condition("(State ==\"OR\")||(State==\"WA\")"))
        {
                    await page.EnterSearchValue54F3CAsync(data.Resolve("{{data:search_value_237}}"));
                    // v56 suppressed redundant Tosca keyboard steering: SearchValue54F3C CLICK
                    // v56 suppressed redundant Tosca keyboard steering: SearchValue54F3C Tab
        }
        await page.ClickDetail7F662Async();
        await page.EnterEstimatorTypeAsync(data.Resolve("{{data:estimator_type_239}}"));
        await page.EnterValuationTypeAsync(data.Resolve("{{data:valuation_type_240}}"));
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
        // v56 suppressed redundant Tosca keyboard steering: Type CLICK
        // v56 suppressed redundant Tosca keyboard steering: Type Tab
        await page.EnterLoanNumberAsync(data.Resolve("{{data:loan_number_247}}"));
        // v56 suppressed redundant Tosca keyboard steering: LoanNumber CLICK
        // v56 suppressed redundant Tosca keyboard steering: LoanNumber Tab
        await page.EnterInsuredTypeAsync(data.Resolve("{{data:insured_type_248}}"));
        // v56 suppressed redundant Tosca keyboard steering: InsuredType CLICK
        // v56 suppressed redundant Tosca keyboard steering: InsuredType Tab
        await page.EnterFirstNameAsync(data.Resolve("{{data:first_name_249}}"));
        // v56 suppressed redundant Tosca keyboard steering: FirstName CLICK
        // v56 suppressed redundant Tosca keyboard steering: FirstName Tab
        await page.EnterMIAsync(data.Resolve("{{data:mi_250}}"));
        // v56 suppressed redundant Tosca keyboard steering: MI CLICK
        // v56 suppressed redundant Tosca keyboard steering: MI Tab
        await page.EnterLastNameAsync(data.Resolve("{{data:last_name_251}}"));
        // v56 suppressed redundant Tosca keyboard steering: LastName CLICK
        // v56 suppressed redundant Tosca keyboard steering: LastName Tab
        await page.EnterAddress1Async(data.Resolve("{{data:address_1_252}}"));
        // v56 suppressed redundant Tosca keyboard steering: Address1 CLICK
        // v56 suppressed redundant Tosca keyboard steering: Address1 Tab
        await page.EnterZipCodeAsync(data.Resolve("{{data:zip_code_253}}"));
        // v56 suppressed redundant Tosca keyboard steering: ZipCode CLICK
        // v56 suppressed redundant Tosca keyboard steering: ZipCode Tab
        await page.EnterProvisionsApplicableAsync(data.Resolve("{{data:provisions_applicable_254}}"));
        // v56 suppressed redundant Tosca keyboard steering: ProvisionsApplicable CLICK
        // v56 suppressed redundant Tosca keyboard steering: ProvisionsApplicable Tab
        await page.EnterDescriptionOfPropertyAsync(data.Resolve("{{data:description_of_property_255}}"));
        // v56 suppressed redundant Tosca keyboard steering: DescriptionOfProperty CLICK
        // v56 suppressed redundant Tosca keyboard steering: DescriptionOfProperty Tab
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
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_270}}"));
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_274}}"));
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
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets UpdateAnswers99D68
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
        await page.EnterPasswordAsync(data.Resolve("{{env:CL_DC_PASSWORD}}"));
        await page.ClickLoginAsync();
        await page.WaitForLoginAsync("Absent");

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
        await page.ClickQuickSearchButtonAsync();
        await page.EnterSearchMethodEGDescriptionPolicyAsync(data.Resolve("{{data:search_method_e_g_description_policy_333}}"));
        await page.ClickSearchButtonAsync();
        await page.WaitForViewPolicyAsync("Exists");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets ViewPolicy
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
        // v56 suppressed redundant Tosca keyboard steering: IsThisCoverageBound CLICK
        // v56 suppressed redundant Tosca keyboard steering: IsThisCoverageBound Tab
        await page.VerifyOrderAuditAsync("Exists", "");
        await page.EnterOrderAuditAsync(data.Resolve("{{data:order_audit_343}}"));
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
        await page.VerifyIsThisCoverageBoundAsync(data.Resolve("{{data:expected_is_this_coverage_bound_value_351}}"), "Value");
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_352}}"));
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
        await page.VerifyFullTermPremiumAsync(data.Resolve("{{data:expected_full_term_premium_value_384}}"), "value");
        await page.VerifyPremiumWrittenAsync(data.Resolve("{{data:expected_premium_written_value_385}}"), "value");
        await page.VerifyPriorPremiumAsync(data.Resolve("{{data:expected_prior_premium_value_386}}"), "value");
        await page.VerifyPremiumChangeAsync(data.Resolve("{{data:expected_premium_change_value_387}}"), "value");
        await page.EnterTitleAsync(data.Resolve("{{data:title_389}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_390}}"));
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
        await page.VerifyStatusCodeAsync(data.Resolve("{{data:expected_statuscode_value_394}}"), "value");
        await page.PauseAsync(1000);
        await page.PauseAsync(1000);

    }

}
