using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "CPP Basic Policy")]
public sealed class CPPBasicPolicySteps
{
    private readonly ScenarioContext _scenario;
    public CPPBasicPolicySteps(ScenarioContext scenario) => _scenario = scenario;

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
        await page.EnterEffectiveDate95094Async(data.Resolve("{{data:effectivedate_86}}"));
        if (data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
                    await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_87}}"));
        }
        await page.PauseAsync(1000);
        if (data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_89}}"));
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
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_93}}"));
        await page.PauseAsync(1000);
        if (data.Condition("'Product (LOB)' != \"WC\""))
        {
                    await page.WaitForPrimaryRatingStateAsync("Exists");
        }
        if (data.Condition("'Product (LOB)' != \"WC\""))
        {
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets PrimaryRatingState
        }
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_99}}"));
        // v56 suppressed redundant Tosca keyboard steering: WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days CLICK
        // v56 suppressed redundant Tosca keyboard steering: WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days Enter
        // v56 suppressed redundant Tosca keyboard steering: WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days Tab
        await page.VerifyPriorAmericanNationalPolicyAsync("Absent", "");
        await page.VerifyWhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNationalAsync("Absent", "");
        await page.VerifyIsThisPolicyBeingFullyCancelledAsync("Absent", "");
        await page.PauseAsync(1000);
        await page.EnterTitleAsync(data.Resolve("{{data:title_104}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_105}}"));
        await page.VerifyResultAsync(data.Resolve("{{data:expected_result_value_106}}"), "value");
        await page.WaitForPolicyInfoHeaderAsync("Visible");
        await page.WaitForDescriptionOfSpecifiedOperationAsync("Visible");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets DescriptionOfSpecifiedOperation
        await page.EnterDescriptionOfSpecifiedOperationAsync("AZ CPP Basic {NMONTH}.{NDAY}.{NYEAR} {Time}");
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
        await page.VerifyReferenceNumberAsync(data.Resolve("{{data:expected_reference_number_innertext_120}}"), "InnerText");
        await page.PauseAsync(1000);
        await page.PauseAsync(1000);

    }

    [Given(@"^I select CPP Coverage \- GL$")]
    [When(@"^I select CPP Coverage \- GL$")]
    [Then(@"^I select CPP Coverage \- GL$")]
    public async Task SelectCPPCoverageGLAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (data.Condition("(State == \"MD\")||(State == \"NJ\")||(State == \"NY\")||(State == \"VT\")"))
        {
                    await page.EnterEstimatedPremiumAsync("");
        }
        if (data.Condition("'CPP LOB' == \"GL\""))
        {
                    await page.ClickGLAsync();
        }

    }

    [Given(@"^I select CPP Coverage \- CP$")]
    [When(@"^I select CPP Coverage \- CP$")]
    [Then(@"^I select CPP Coverage \- CP$")]
    public async Task SelectCPPCoverageCPAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (data.Condition("'CPP LOB' == \"CP\""))
        {
                    await page.ClickCPAsync();
        }

    }

    [Given(@"^I select CPP Coverage \- IM$")]
    [When(@"^I select CPP Coverage \- IM$")]
    [Then(@"^I select CPP Coverage \- IM$")]
    public async Task SelectCPPCoverageIMAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (data.Condition("'CPP LOB' == \"IM\""))
        {
                    await page.ClickIMAsync();
        }

    }

    [Given(@"^I select CP Detail$")]
    [When(@"^I select CP Detail$")]
    [Then(@"^I select CP Detail$")]
    public async Task SelectCPDetailAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (data.Condition("'CPP LOB' == \"CP\""))
        {
                    await page.ClickCPDetailAsync();
        }

    }

    [Given(@"^I complete CP Fields$")]
    [When(@"^I complete CP Fields$")]
    [Then(@"^I complete CP Fields$")]
    public async Task CompleteCPFieldsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForPolicyCovgFF145Async("Exists");
        await page.EnterDoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackupAsync(data.Resolve("{{data:does_any_risk_generate_power_other_than_private_windmills_or_emergency_backup_129}}"));
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
        await page.EnterPolicyCoverageAsync(data.Resolve("{{data:policy_coverage_132}}"));
        if (data.Condition("'Property Extension Endorsements' != NULL"))
        {
                    await page.EnterPropertyExtensionEndorsementsAsync(data.Resolve("{{data:property_extension_endorsements_133}}"));
                    // v56 suppressed redundant Tosca keyboard steering: PropertyExtensionEndorsements CLICK
                    // v56 suppressed redundant Tosca keyboard steering: PropertyExtensionEndorsements Enter
                    // v56 suppressed redundant Tosca keyboard steering: PropertyExtensionEndorsements Tab
        }
        if (data.Condition("'Utility Services' != NULL"))
        {
                    await page.EnterUtilityServicesAsync(data.Resolve("{{data:utility_services_134}}"));
        }
        if (data.Condition("Fungus != NULL"))
        {
                    await page.EnterFungusAsync(data.Resolve("{{data:fungus_135}}"));
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
        await page.EnterFeetFromHydrantAsync(data.Resolve("{{data:feet_from_hydrant_138}}"));
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.WaitForAddress1C0AF1Async("Exists");
        await page.EnterMilesFromFireDepartmentAsync(data.Resolve("{{data:miles_from_fire_department_144}}"));
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.VerifyFeetFromHydrantAsync(data.Resolve("{{data:expected_feet_from_hydrant_value_147}}"), "NotEqual:Value");
        await page.WaitForAddress1C0AF1Async("Exists");
        await page.EnterFeetFromHydrantAsync(data.Resolve("{{data:feet_from_hydrant_149}}"));
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.WaitForAddress1C0AF1Async("Exists");
        await page.ClickCallISOAsync();
        await page.ClickSelectPPCAsync();
        await page.ClickSelectAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.VerifyFeetFromHydrantAsync(data.Resolve("{{data:expected_feet_from_hydrant_value_158}}"), "NotEqual:Value");
        await page.WaitForAddress1C0AF1Async("Exists");
        await page.EnterFeetFromHydrantAsync(data.Resolve("{{data:feet_from_hydrant_160}}"));
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
                    await page.EnterConstruction39800Async(data.Resolve("{{data:construction_170}}"));
        }
        if (data.Condition("'Year Built' != NULL"))
        {
                    await page.EnterYearBuiltAsync(data.Resolve("{{data:year_built_171}}"));
        }
        if (data.Condition("'Square Feet' != NULL"))
        {
                    await page.EnterSquareFeetAsync(data.Resolve("{{data:square_feet_172}}"));
        }
        if (data.Condition("Stories != NULL"))
        {
                    await page.EnterStoriesAsync(data.Resolve("{{data:stories_173}}"));
        }
        if (data.Condition("Interest != NULL"))
        {
                    await page.EnterInterestAsync(data.Resolve("{{data:interest_174}}"));
        }
        if (data.Condition("'Roof Type' != NULL"))
        {
                    await page.EnterRoofTypeAsync(data.Resolve("{{data:roof_type_175}}"));
        }
        if (data.Condition("Deductible != NULL"))
        {
                    await page.EnterDeductible592D9Async(data.Resolve("{{data:deductible_176}}"));
                    // v56 suppressed redundant Tosca keyboard steering: Deductible592D9 CLICK
                    // v56 suppressed redundant Tosca keyboard steering: Deductible592D9 CLICK
                    // v56 suppressed redundant Tosca keyboard steering: Deductible592D9 Tab
        }
        if (data.Condition("'Deductible Increased Theft' != NULL"))
        {
                    await page.EnterDeductibleIncreasedTheft99E5FAsync(data.Resolve("{{data:deductible_increased_theft_177}}"));
        }
        if (data.Condition("'Deductible Wind Hail' != NULL"))
        {
                    await page.EnterDeductibleWindHail911AFAsync(data.Resolve("{{data:deductible_wind_hail_178}}"));
        }
        if (data.Condition("'BG2 Symbol' != NULL"))
        {
                    await page.EnterBG2SymbolAsync(data.Resolve("{{data:bg2_symbol_179}}"));
        }
        if (data.Condition("'BG2 Symbol Prefix' != NULL"))
        {
                    await page.EnterBG2SymbolPrefixAsync(data.Resolve("{{data:bg2_symbol_prefix_180}}"));
                    // v56 suppressed redundant Tosca keyboard steering: BG2SymbolPrefix CLICK
                    // v56 suppressed redundant Tosca keyboard steering: BG2SymbolPrefix Tab
        }
        if (data.Condition("'Is the building cooled?' != NULL"))
        {
                    await page.EnterIsTheBuildingCooledAsync(data.Resolve("{{data:is_the_building_cooled_181}}"));
        }
        if (data.Condition("'Is the building heated with a Solid Fuel Heating Device?' != NULL"))
        {
                    await page.EnterIsTheBuildingHeatedWithASolidFuelHeatingDeviceAsync(data.Resolve("{{data:is_the_building_heated_with_a_solid_fuel_heating_device_182}}"));
                    // v56 suppressed redundant Tosca keyboard steering: IsTheBuildingHeatedWithASolidFuelHeatingDevice CLICK
                    // v56 suppressed redundant Tosca keyboard steering: IsTheBuildingHeatedWithASolidFuelHeatingDevice Tab
        }
        if (data.Condition("'Provide a List of Surrounding Exposure/Other Occupancies within 100 ft (Including North, East, South, and West)' != NULL"))
        {
                    await page.EnterProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWestAsync(data.Resolve("{{data:provide_a_list_of_surrounding_exposure_other_occupancies_within_100_ft_including_north_east_south_and_west_183}}"));
                    // v56 suppressed redundant Tosca keyboard steering: ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest CLICK
                    // v56 suppressed redundant Tosca keyboard steering: ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest Tab
        }
        if (data.Condition("'Eligible For Enhanced Wind Rating Program' != NULL"))
        {
                    await page.EnterEligibleForEnhancedWindRatingProgramAsync(data.Resolve("{{data:eligible_for_enhanced_wind_rating_program_184}}"));
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
                    await page.EnterDescription8A08DAsync(data.Resolve("{{data:description_188}}"));
        }
        if (data.Condition("'Risk Type' != NULL"))
        {
                    await page.EnterRiskTypeAsync(data.Resolve("{{data:risk_type_189}}"));
        }
        if (data.Condition("Coinsurance != NULL"))
        {
                    await page.EnterCoinsurance6348BAsync(data.Resolve("{{data:coinsurance_190}}"));
        }
        if (data.Condition("Deductible != NULL"))
        {
                    await page.EnterDeductible01AB9Async(data.Resolve("{{data:deductible_191}}"));
        }
        if (data.Condition("'Deductible Increased Theft' != NULL"))
        {
                    await page.EnterDeductibleIncreasedTheftF76DBAsync(data.Resolve("{{data:deductible_increased_theft_192}}"));
        }
        if (data.Condition("'Deductible Wind Hail' != NULL"))
        {
                    await page.EnterDeductibleWindHailAB1C3Async(data.Resolve("{{data:deductible_wind_hail_193}}"));
        }
        if (data.Condition("'Cause Of Loss' != NULL"))
        {
                    await page.EnterCauseOfLossAsync(data.Resolve("{{data:cause_of_loss_194}}"));
        }
        if (data.Condition("Valuation != NULL"))
        {
                    await page.EnterValuationAsync(data.Resolve("{{data:valuation_195}}"));
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
                    await page.EnterIncreasedPollutantCleanupAsync(data.Resolve("{{data:increased_pollutant_cleanup_198}}"));
        }
        if (data.Condition("'Debris Removal Additional' != NULL"))
        {
                    await page.EnterDebrisRemovalAdditionalAsync(data.Resolve("{{data:debris_removal_additional_199}}"));
        }
        if (data.Condition("'Debris Removal Additional Limit' != NULL"))
        {
                    await page.EnterDebrisRemovalAdditionalLimitAsync(data.Resolve("{{data:debris_removal_additional_limit_200}}"));
        }
        if (data.Condition("'Vacant Building' != NULL"))
        {
                    await page.EnterVacantBuildingAsync(data.Resolve("{{data:vacant_building_201}}"));
        }
        if (data.Condition("'% Occupied' != NULL"))
        {
                    await page.EnterOccupiedAsync(data.Resolve("{{data:occupied_202}}"));
        }
        if (data.Condition("'Pier Or Wharf' != NULL"))
        {
                    await page.EnterPierOrWharfAsync(data.Resolve("{{data:pier_or_wharf_203}}"));
        }
        if (data.Condition("'Pier Or Wharf Construction' != NULL"))
        {
                    await page.EnterPierOrWharfConstructionAsync(data.Resolve("{{data:pier_or_wharf_construction_204}}"));
        }
        if (data.Condition("'Pier Or Wharf Cause Of Loss' != NULL"))
        {
                    await page.EnterPierOrWharfCauseOfLossAsync(data.Resolve("{{data:pier_or_wharf_cause_of_loss_205}}"));
        }
        if (data.Condition("'Pier Or Wharf COL Options' != NULL"))
        {
                    await page.EnterPierOrWharfCOLOptionsAsync(data.Resolve("{{data:pier_or_wharf_col_options_206}}"));
                    // v56 suppressed redundant Tosca keyboard steering: PierOrWharfCOLOptions CLICK
                    // v56 suppressed redundant Tosca keyboard steering: PierOrWharfCOLOptions Tab
        }
        if (data.Condition("'Vacancy Permit' != NULL"))
        {
                    await page.EnterVacancyPermitAsync(data.Resolve("{{data:vacancy_permit_207}}"));
        }
        if (data.Condition("'Pier Or Wharf COL Options' != NULL"))
        {
                    await page.WaitForPierOrWharfCOLOptionsAsync("Exists");
        }
        await page.ClickAddClassDCD8FAsync();
        if (data.Condition("(State !=\"OR\")||(State!=\"WA\")||(State!=\"VT\")"))
        {
                    await page.EnterSearchValue54F3CAsync(data.Resolve("{{data:search_value_210}}"));
                    // v56 suppressed redundant Tosca keyboard steering: SearchValue54F3C CLICK
                    // v56 suppressed redundant Tosca keyboard steering: SearchValue54F3C Tab
        }
        if (data.Condition("(State !=\"OR\")||(State!=\"WA\")||(State!=\"VT\")"))
        {
                    await page.EnterSearchResultsD0AA8Async(data.Resolve("{{data:search_results_211}}"));
                    // v56 suppressed redundant Tosca keyboard steering: SearchResultsD0AA8 CLICK
                    // v56 suppressed redundant Tosca keyboard steering: SearchResultsD0AA8 Enter
                    // v56 suppressed redundant Tosca keyboard steering: SearchResultsD0AA8 Tab
        }
        await page.EnterOccupancyTypeAsync(data.Resolve("{{data:occupancy_type_212}}"));
        // v56 suppressed redundant Tosca keyboard steering: OccupancyType CLICK
        // v56 suppressed redundant Tosca keyboard steering: OccupancyType Tab
        if (data.Condition("(State ==\"OR\")||(State==\"WA\")"))
        {
                    await page.EnterSearchResultsD0AA8Async("");
        }
        await page.ClickPropertyAddClassOKAsync();
        await page.EnterBuildingRatingGroupAsync(data.Resolve("{{data:building_rating_group_215}}"));
        // v56 suppressed redundant Tosca keyboard steering: BuildingRatingGroup CLICK
        // v56 suppressed redundant Tosca keyboard steering: BuildingRatingGroup Tab
        await page.EnterBuildingLimitAsync(data.Resolve("{{data:building_limit_216}}"));
        await page.EnterPersonalPropertyRatingGroupAsync(data.Resolve("{{data:personal_property_rating_group_217}}"));
        await page.EnterPersonalPropertyLimitAsync(data.Resolve("{{data:personal_property_limit_218}}"));
        await page.EnterPropertyOfOthersRatingGroupAsync(data.Resolve("{{data:property_of_others_rating_group_219}}"));
        await page.EnterPropertyOfOthersLimitAsync(data.Resolve("{{data:property_of_others_limit_220}}"));
        if (data.Condition("(State ==\"OR\")||(State==\"WA\")"))
        {
                    await page.EnterSearchValue54F3CAsync(data.Resolve("{{data:search_value_221}}"));
                    // v56 suppressed redundant Tosca keyboard steering: SearchValue54F3C CLICK
                    // v56 suppressed redundant Tosca keyboard steering: SearchValue54F3C Tab
        }
        await page.ClickDetail7F662Async();
        await page.EnterEstimatorTypeAsync(data.Resolve("{{data:estimator_type_223}}"));
        await page.EnterValuationTypeAsync(data.Resolve("{{data:valuation_type_224}}"));
        await page.ClickCreateValuationAsync();
        await page.ClickGetCalculatedValueAsync();
        await page.ClickPropertyEnterBuildingRCTOKAsync();

    }

    [Given(@"^I complete ensure Property of Others Rating Group has been entered$")]
    [When(@"^I complete ensure Property of Others Rating Group has been entered$")]
    [Then(@"^I complete ensure Property of Others Rating Group has been entered$")]
    public async Task CompleteEnsurePropertyOfOthersRatingGroupHasBeenEnteredAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyPropertyOfOthersRatingGroupAsync(data.Resolve("{{data:expected_property_of_others_rating_group_value_228}}"), "NotEqual:Value");
        await page.VerifyPropertyOfOthersRatingGroupAsync(data.Resolve("{{data:expected_property_of_others_rating_group_value_229}}"), "NotEqual:Value");
        await page.EnterPropertyOfOthersRatingGroupAsync(data.Resolve("{{data:property_of_others_rating_group_230}}"));

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
        await page.EnterTypeAsync(data.Resolve("{{data:type_233}}"));
        // v56 suppressed redundant Tosca keyboard steering: Type CLICK
        // v56 suppressed redundant Tosca keyboard steering: Type Tab
        await page.EnterLoanNumberAsync(data.Resolve("{{data:loan_number_234}}"));
        // v56 suppressed redundant Tosca keyboard steering: LoanNumber CLICK
        // v56 suppressed redundant Tosca keyboard steering: LoanNumber Tab
        await page.EnterInsuredTypeAsync(data.Resolve("{{data:insured_type_235}}"));
        // v56 suppressed redundant Tosca keyboard steering: InsuredType CLICK
        // v56 suppressed redundant Tosca keyboard steering: InsuredType Tab
        await page.EnterFirstNameAsync(data.Resolve("{{data:first_name_236}}"));
        // v56 suppressed redundant Tosca keyboard steering: FirstName CLICK
        // v56 suppressed redundant Tosca keyboard steering: FirstName Tab
        await page.EnterMIAsync(data.Resolve("{{data:mi_237}}"));
        // v56 suppressed redundant Tosca keyboard steering: MI CLICK
        // v56 suppressed redundant Tosca keyboard steering: MI Tab
        await page.EnterLastNameAsync(data.Resolve("{{data:last_name_238}}"));
        // v56 suppressed redundant Tosca keyboard steering: LastName CLICK
        // v56 suppressed redundant Tosca keyboard steering: LastName Tab
        await page.EnterAddress1Async(data.Resolve("{{data:address_1_239}}"));
        // v56 suppressed redundant Tosca keyboard steering: Address1 CLICK
        // v56 suppressed redundant Tosca keyboard steering: Address1 Tab
        await page.EnterZipCodeAsync(data.Resolve("{{data:zip_code_240}}"));
        // v56 suppressed redundant Tosca keyboard steering: ZipCode CLICK
        // v56 suppressed redundant Tosca keyboard steering: ZipCode Tab
        await page.EnterProvisionsApplicableAsync(data.Resolve("{{data:provisions_applicable_241}}"));
        // v56 suppressed redundant Tosca keyboard steering: ProvisionsApplicable CLICK
        // v56 suppressed redundant Tosca keyboard steering: ProvisionsApplicable Tab
        await page.EnterDescriptionOfPropertyAsync(data.Resolve("{{data:description_of_property_242}}"));
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

    }

    [Given(@"^I return to CPP Navigation$")]
    [When(@"^I return to CPP Navigation$")]
    [Then(@"^I return to CPP Navigation$")]
    public async Task ReturnToCPPNavigationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickReturnToCPPAsync();

    }

    [Given(@"^I select GL Detail$")]
    [When(@"^I select GL Detail$")]
    [Then(@"^I select GL Detail$")]
    public async Task SelectGLDetailAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickPolicyInfoAsync();
        if (data.Condition("'CPP LOB' == \"GL\""))
        {
                    await page.ClickGLDetailAsync();
        }

    }

    [Given(@"^I complete CGL Fields$")]
    [When(@"^I complete CGL Fields$")]
    [Then(@"^I complete CGL Fields$")]
    public async Task CompleteCGLFieldsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForPolicyCovg6B651Async("Exists");
        if (data.Condition("'Occurence Limit' != NULL"))
        {
                    await page.EnterOccurenceLimitAsync(data.Resolve("{{data:occurence_limit_259}}"));
                    // v56 suppressed redundant Tosca keyboard steering: OccurenceLimit CLICK
                    // v56 suppressed redundant Tosca keyboard steering: OccurenceLimit Enter
                    // v56 suppressed redundant Tosca keyboard steering: OccurenceLimit Tab
        }
        if (data.Condition("'Aggregate Limit' != NULL"))
        {
                    await page.EnterAggregateLimitAsync(data.Resolve("{{data:aggregate_limit_260}}"));
                    // v56 suppressed redundant Tosca keyboard steering: AggregateLimit CLICK
                    // v56 suppressed redundant Tosca keyboard steering: AggregateLimit Enter
                    // v56 suppressed redundant Tosca keyboard steering: AggregateLimit Tab
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
                    await page.EnterProductsAggLimitAsync("");
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
                    await page.EnterDedTypeAsync(data.Resolve("{{data:ded_type_262}}"));
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
                    await page.EnterDeductibleBasisAsync(data.Resolve("{{data:deductible_basis_263}}"));
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
                    await page.EnterPremOpDedAsync(data.Resolve("{{data:premop_ded_264}}"));
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
                    await page.EnterPremOpPDDedAsync("");
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
                    await page.SetSplitBIDedAsync(data.Resolve("{{data:split_bi_ded_266}}"));
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
                    await page.EnterSplitPDDedAsync("");
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
                    await page.EnterProdBIDedAsync(data.Resolve("{{data:prod_bi_ded_268}}"));
                    // v56 suppressed redundant Tosca keyboard steering: ProdBIDed CLICK
                    // v56 suppressed redundant Tosca keyboard steering: ProdBIDed Tab
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
                    await page.EnterProdPDDedAsync("");
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
                    await page.EnterFireDamageAsync("");
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
                    await page.EnterMedicalAsync("");
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
                    await page.EnterPersAdvInjAsync("");
        }
        if (data.Condition("'Coverage Form' != \"OCP\""))
        {
                    await page.EnterIsTheInsuredEngagedInAnySnowOrIceRemovalOperationsAsync(data.Resolve("{{data:is_the_insured_engaged_in_any_snow_or_ice_removal_operations_273}}"));
                    // v56 suppressed redundant Tosca keyboard steering: IsTheInsuredEngagedInAnySnowOrIceRemovalOperations CLICK
                    // v56 suppressed redundant Tosca keyboard steering: IsTheInsuredEngagedInAnySnowOrIceRemovalOperations Enter
                    // v56 suppressed redundant Tosca keyboard steering: IsTheInsuredEngagedInAnySnowOrIceRemovalOperations Tab
        }
        if (data.Condition("(State==\"NY\")||(State == \"NJ\")||(State == \"WV\")||(State == \"MA\")||(State == \"CT\")||(State == \"ME\")||(State == \"NH\")||(State == \"OR\")||(State == \"AZ\")||(State == \"PA\")||(State == \"MD\")||(State == \"DE\")||(State == \"RI\")||(State == \"VA\")||(State == \"VT\")&& 'Coverage Form' != \"OCP\""))
        {
                    await page.EnterOfFullTimeEmployeesAsync(data.Resolve("{{data:of_full_time_employees_274}}"));
        }
        if (data.Condition("(State==\"NY\")||(State == \"NJ\")||(State == \"WV\")||(State == \"MA\") ||(State == \"CT\")||(State == \"ME\")||(State == \"NH\")||(State == \"OR\")||(State == \"AZ\")||(State == \"PA\")||(State == \"MD\")||(State == \"DE\")||(State == \"RI\")||(State == \"VA\")||(State == \"VT\")&& 'Coverage Form' != \"OCP\""))
        {
                    await page.EnterOfPartTimeEmployeesAsync(data.Resolve("{{data:of_part_time_employees_275}}"));
        }
        if (data.Condition("(State==\"NY\")||(State == \"NJ\")||(State == \"WV\")||(State == \"MA\")||(State == \"CT\")||(State == \"ME\")||(State == \"NH\")||(State == \"OR\") ||(State == \"AZ\")||(State == \"PA\")||(State == \"MD\")||(State == \"DE\")||(State == \"RI\")||(State == \"VA\")||(State == \"VT\")&& 'Coverage Form' != \"OCP\""))
        {
                    await page.EnterOfSeasonalTemporaryEmployeesAsync(data.Resolve("{{data:of_seasonal_temporary_employees_276}}"));
        }

    }

    [Given(@"^I add Class$")]
    [When(@"^I add Class$")]
    [Then(@"^I add Class$")]
    public async Task AddClassAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickCGL08901Async();
        await page.WaitForCGLBA8E8Async("Exists");
        await page.ClickAddClassB04B6Async();
        await page.EnterSearchResults5209CAsync(data.Resolve("{{data:search_results_280}}"));
        await page.ClickAddClassOKAsync();
        await page.EnterExposureAsync(data.Resolve("{{data:exposure_282}}"));
        await page.ClickMainPageOKAsync();

    }

    [Given(@"^I add \[CG0435\] Employee Benefits Liability Endorsement$")]
    [When(@"^I add \[CG0435\] Employee Benefits Liability Endorsement$")]
    [Then(@"^I add \[CG0435\] Employee Benefits Liability Endorsement$")]
    public async Task AddCG0435EmployeeBenefitsLiabilityEndorsementAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (data.Condition("'Navigate to Endorsements Screen first time' != NULL"))
        {
                    await page.ClickEndorsements7572EAsync();
        }
        await page.WaitForEndorsements9626EAsync("Exists");
        await page.ClickAddEndorsementA9973Async();
        await page.EnterEndorsementTypeA2928Async(data.Resolve("{{data:endorsement_type_287}}"));
        await page.EnterNumberOfEmployeesAsync(data.Resolve("{{data:number_of_employees_288}}"));
        await page.ClickCG0435EmployeeBenefitsLiabilityOKAsync();

    }

    [Given(@"^I add \[CG2142\] Exclusion \- Explosion, Collapse and Underground Property Damage Hazard \(Specified Operations\)$")]
    [When(@"^I add \[CG2142\] Exclusion \- Explosion, Collapse and Underground Property Damage Hazard \(Specified Operations\)$")]
    [Then(@"^I add \[CG2142\] Exclusion \- Explosion, Collapse and Underground Property Damage Hazard \(Specified Operations\)$")]
    public async Task AddCG2142ExclusionExplosionCollapseAndUndergroundPropertyDamageHazardSpecifiedOperationsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (data.Condition("'Navigate to Endorsements Screen first time' != NULL"))
        {
                    await page.ClickEndorsements7572EAsync();
        }
        await page.WaitForEndorsements9626EAsync("Exists");
        await page.ClickAddEndorsementA9973Async();
        await page.EnterEndorsementTypeB210CAsync(data.Resolve("{{data:endorsement_type_293}}"));
        await page.SetExcludeExplosionHazardAsync(data.Resolve("{{data:exclude_explosion_hazard_294}}"));
        await page.SetExcludeCollapseHazardAsync(data.Resolve("{{data:exclude_collapse_hazard_295}}"));
        await page.SetExcludeUndergroundPropertyDamageHazardAsync(data.Resolve("{{data:exclude_underground_property_damage_hazard_296}}"));
        await page.EnterDescriptionOfOperationSAsync(data.Resolve("{{data:description_of_operation_s_297}}"));
        if (data.Condition("State != \"VA\""))
        {
                    await page.ClickCG2142ExclusionExplosionCollapseAndUndergroundPropertyDamageHazardSpecifiedOperationsOKAsync();
        }
        if (data.Condition("State == \"VA\""))
        {
                    await page.ClickCG2142ExclusionExplosionCollapseAndUndergroundPropertyDamageHazardSpecifiedOperationsOKAsync();
        }

    }

    [Given(@"^I add \[CG 2149\] Total Pollution Exclusion Endorsement$")]
    [When(@"^I add \[CG 2149\] Total Pollution Exclusion Endorsement$")]
    [Then(@"^I add \[CG 2149\] Total Pollution Exclusion Endorsement$")]
    public async Task AddCG2149TotalPollutionExclusionEndorsementAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (data.Condition("'Navigate to Endorsements Screen first time' != NULL"))
        {
                    await page.ClickEndorsements7572EAsync();
        }
        await page.WaitForEndorsements9626EAsync("Exists");
        await page.ClickAddEndorsementA9973Async();
        await page.EnterEndorsementTypeD83A4Async(data.Resolve("{{data:endorsement_type_303}}"));
        await page.ClickCG2149TotalPollutionExclusionEndorsementOKAsync();

    }

    [Given(@"^I verify and Fill out \[FG0055\] Employment Practices Liability Insurance Coverage Endorsement$")]
    [When(@"^I verify and Fill out \[FG0055\] Employment Practices Liability Insurance Coverage Endorsement$")]
    [Then(@"^I verify and Fill out \[FG0055\] Employment Practices Liability Insurance Coverage Endorsement$")]
    public async Task VerifyAndFillOutFG0055EmploymentPracticesLiabilityInsuranceCoverageEndorsementAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForFG0055TableRowFG0055Async("Exists");
        await page.VerifyFG0055TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementAsync("Exists", "");
        await page.ClickDetailAsync();
        await page.EnterLimitDeductibleAsync(data.Resolve("{{data:limit_deductible_308}}"));
        await page.EnterHasTheInsuredEverHadAClaimForEmploymentPracticesAsync(data.Resolve("{{data:has_the_insured_ever_had_a_claim_for_employment_practices_309}}"));
        await page.EnterTheInsuredAndAnyExecutiveOfficerOrOwnerHasKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaintAsync(data.Resolve("{{data:the_insured_and_any_executive_officer_or_owner_has_knowledge_or_information_of_any_act_error_or_omission_which_might_give_rise_to_an_epl_claim_suit_or_complaint_310}}"));
        await page.EnterThirdPartyAsync(data.Resolve("{{data:third_party_311}}"));
        await page.ClickFG0055FG0062FG0063FG0069FG0071FG0072FG0074FG0077FG0078EmploymentPracticesLiabilityInsuranceCoverageEndorsementOKAsync();

    }

    [Given(@"^I add Addl Interest \[CG2007\] \- Engineers$")]
    [When(@"^I add Addl Interest \[CG2007\] \- Engineers$")]
    [Then(@"^I add Addl Interest \[CG2007\] \- Engineers$")]
    public async Task AddAddlInterestCG2007EngineersAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickAddlInterestsE39FCAsync();
        await page.WaitForAddlInterestsA10A4Async("Exists");
        await page.ClickAddAddlInterestAsync();
        if (data.Condition("Type != NULL"))
        {
                    await page.WaitForTypeD0639Async("Exists");
        }
        await page.ClickCG2007AddLInsuredEngineersArchitectsOKAsync();
        if (data.Condition("Type != NULL"))
        {
                    await page.ClickTypeD0639Async();
        }
        if (data.Condition("Type != NULL"))
        {
                    await page.EnterTypeD0639Async(data.Resolve("{{data:type_319}}"));
        }

    }

    [Given(@"^I add Addl Interest \[CG2020\] Add'l Insured\-Charitable Institution$")]
    [When(@"^I add Addl Interest \[CG2020\] Add'l Insured\-Charitable Institution$")]
    [Then(@"^I add Addl Interest \[CG2020\] Add'l Insured\-Charitable Institution$")]
    public async Task AddAddlInterestCG2020AddLInsuredCharitableInstitutionAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickAddlInterestsE39FCAsync();
        await page.WaitForAddlInterestsA10A4Async("Exists");
        await page.ClickAddAddlInterestAsync();
        if (data.Condition("Type != NULL"))
        {
                    await page.EnterTypeA75B5Async(data.Resolve("{{data:type_323}}"));
        }
        if (data.Condition("'Type of License' != NULL"))
        {
                    await page.EnterTypeOfLicenseAsync(data.Resolve("{{data:type_of_license_324}}"));
                    // v56 suppressed redundant Tosca keyboard steering: TypeOfLicense CLICK
                    // v56 suppressed redundant Tosca keyboard steering: TypeOfLicense Tab
        }
        await page.ClickCG2020AddLInsuredCharitableInstitutionOKAsync();

    }

    [Given(@"^I add Addl Interest \[CG2023\] Add'l Insured\-Executors$")]
    [When(@"^I add Addl Interest \[CG2023\] Add'l Insured\-Executors$")]
    [Then(@"^I add Addl Interest \[CG2023\] Add'l Insured\-Executors$")]
    public async Task AddAddlInterestCG2023AddLInsuredExecutorsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickAddlInterestsE39FCAsync();
        await page.WaitForAddlInterestsA10A4Async("Exists");
        await page.ClickAddAddlInterestAsync();
        if (data.Condition("Type != NULL"))
        {
                    await page.EnterTypeD972CAsync(data.Resolve("{{data:type_329}}"));
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

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickAddlInterestsE39FCAsync();
        await page.WaitForAddlInterestsA10A4Async("Exists");
        await page.ClickAddAddlInterestAsync();
        if (data.Condition("Type != NULL"))
        {
                    await page.EnterTypeD972CAsync(data.Resolve("{{data:type_334}}"));
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

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickAddlInterestsE39FCAsync();
        await page.WaitForAddlInterestsA10A4Async("Exists");
        await page.ClickAddAddlInterestAsync();
        if (data.Condition("Type != NULL"))
        {
                    await page.EnterTypeD972CAsync(data.Resolve("{{data:type_339}}"));
        }
        if (data.Condition("'Type of Equipment' != NULL"))
        {
                    await page.EnterTypeOfEquipmentAsync(data.Resolve("{{data:type_of_equipment_340}}"));
                    // v56 suppressed redundant Tosca keyboard steering: TypeOfEquipment CLICK
                    // v56 suppressed redundant Tosca keyboard steering: TypeOfEquipment Tab
        }
        await page.ClickOKAsync();

    }

    [Given(@"^I answer GL UW Questions OR \& WA$")]
    [When(@"^I answer GL UW Questions OR \& WA$")]
    [Then(@"^I answer GL UW Questions OR \& WA$")]
    public async Task AnswerGLUWQuestionsORWAAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickGLUWQuestionsAsync();
        await page.WaitForGeneralLiabilityInformationAsync("Exists");
        await page.ClickUpdateAnswersFB765Async();
        await page.EnterDescribeAllHoldHarmlessAgreementsAndPleaseProvideACopyAsync(data.Resolve("{{data:describe_all_hold_harmless_agreements_and_please_provide_a_copy_345}}"));
        await page.ClickGeneralLiabilityInformationOKAsync();
        await page.ClickGLUWQuestionsAsync();
        await page.WaitForGeneralLiabilityInformationAsync("Exists");
        await page.ClickProductsCompletedOpsButtonAsync();
        await page.WaitForProductsCompletedOpsAsync("Exists");
        await page.ClickUpdateAnswers69564Async();
        await page.ClickProductsCompletedOpsOKAsync();

    }

    [Given(@"^I return to CPP Navigation for return to cpp$")]
    [When(@"^I return to CPP Navigation for return to cpp$")]
    [Then(@"^I return to CPP Navigation for return to cpp$")]
    public async Task ReturnToCPPNavigationForReturnToCppAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickReturnToCPPAsync();

    }

    [Given(@"^I select IM Detail$")]
    [When(@"^I select IM Detail$")]
    [Then(@"^I select IM Detail$")]
    public async Task SelectIMDetailAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (data.Condition("'CPP LOB' == \"IM\""))
        {
                    await page.ClickIMDetailAsync();
        }

    }

    [Given(@"^I add Accounts Receivable Coverage$")]
    [When(@"^I add Accounts Receivable Coverage$")]
    [Then(@"^I add Accounts Receivable Coverage$")]
    public async Task AddAccountsReceivableCoverageAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForPolicyCovgF9E58Async("Exists");
        await page.EnterCoverageFormToBeAddedAsync(data.Resolve("{{data:coverage_form_to_be_added_356}}"));
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded CLICK
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded Enter
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded Tab
        await page.ClickAddCoverageFormAsync();
        await page.EnterDescriptionAsync(data.Resolve("{{data:description_358}}"));
        // v56 suppressed redundant Tosca keyboard steering: Description CLICK
        // v56 suppressed redundant Tosca keyboard steering: Description Enter
        await page.EnterCoinsuranceAsync(data.Resolve("{{data:coinsurance_359}}"));
        // v56 suppressed redundant Tosca keyboard steering: Coinsurance CLICK
        await page.EnterAwayFromPremisesLmtAsync(data.Resolve("{{data:away_from_premises_lmt_360}}"));
        // v56 suppressed redundant Tosca keyboard steering: AwayFromPremisesLmt CLICK
        await page.EnterAwayFromPremisesDescAsync(data.Resolve("{{data:away_from_premises_desc_361}}"));
        // v56 suppressed redundant Tosca keyboard steering: AwayFromPremisesDesc CLICK
        await page.ClickPolicyCovgAccountsReceivableOKAsync();

    }

    [Given(@"^I add Bailees Customers Coverage$")]
    [When(@"^I add Bailees Customers Coverage$")]
    [Then(@"^I add Bailees Customers Coverage$")]
    public async Task AddBaileesCustomersCoverageAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickPolicyCovgED95CAsync();
        await page.WaitForPolicyCovgF9E58Async("Exists");
        await page.EnterCoverageFormToBeAddedAsync(data.Resolve("{{data:coverage_form_to_be_added_365}}"));
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded CLICK
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded Enter
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded Tab
        await page.ClickAddCoverageFormAsync();
        await page.WaitForCoverageFormDisplay6F446Async("Exists");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Description43F2D
        await page.EnterDescription43F2DAsync(data.Resolve("{{data:description_369}}"));
        // v56 suppressed redundant Tosca keyboard steering: Description43F2D CLICK
        // v56 suppressed redundant Tosca keyboard steering: Description43F2D Enter
        // v56 suppressed redundant Tosca keyboard steering: Description43F2D Tab
        await page.EnterPropertyInTransit710FFAsync(data.Resolve("{{data:property_in_transit_370}}"));
        await page.ClickPropertyAwayFromYourPremisesScheduleAsync();
        await page.ClickAddPremisesAsync();
        await page.EnterAddressStreetCityStateZipAsync(data.Resolve("{{data:address_street_city_state_zip_373}}"));
        // v56 suppressed redundant Tosca keyboard steering: AddressStreetCityStateZip CLICK
        // v56 suppressed redundant Tosca keyboard steering: AddressStreetCityStateZip Tab
        await page.EnterLimit46632Async(data.Resolve("{{data:limit_374}}"));
        await page.ClickPolicyCovgBaileesPropertyAwayFromYourPremisesOKAsync();
        await page.WaitForCoverageFormDisplay6F446Async("Exists");
        await page.ClickPolicyCovgBaileesCutomersOKAsync();

    }

    [Given(@"^I add Computer Systems$")]
    [When(@"^I add Computer Systems$")]
    [Then(@"^I add Computer Systems$")]
    public async Task AddComputerSystemsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickPolicyCovgED95CAsync();
        await page.WaitForPolicyCovgF9E58Async("Exists");
        await page.EnterCoverageFormToBeAddedAsync(data.Resolve("{{data:coverage_form_to_be_added_380}}"));
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded CLICK
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded Enter
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded Tab
        await page.ClickAddCoverageFormAsync();
        await page.WaitForCoverageFormDisplay2ECD4Async("Exists");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Description58EC2
        await page.EnterDescription58EC2Async(data.Resolve("{{data:description_384}}"));
        // v56 suppressed redundant Tosca keyboard steering: Description58EC2 CLICK
        // v56 suppressed redundant Tosca keyboard steering: Description58EC2 Enter
        // v56 suppressed redundant Tosca keyboard steering: Description58EC2 Tab
        await page.EnterDeductibleC91E9Async(data.Resolve("{{data:deductible_385}}"));
        await page.EnterCoinsurance01AB1Async(data.Resolve("{{data:coinsurance_386}}"));
        await page.EnterPropertyInTransit6E905Async(data.Resolve("{{data:property_in_transit_387}}"));
        await page.EnterUnnamedPremisesAsync(data.Resolve("{{data:unnamed_premises_388}}"));
        await page.EnterPersonalPortableComputersAsync(data.Resolve("{{data:personal_portable_computers_389}}"));
        await page.EnterExtraExpenseAsync(data.Resolve("{{data:extra_expense_390}}"));
        await page.EnterVirusHarmfulCodeOrSimilarInstructionAsync(data.Resolve("{{data:virus_harmful_code_or_similar_instruction_391}}"));
        await page.ClickPolicyCovgComputerSystemsOKAsync();

    }

    [Given(@"^I add Contractors Equipment$")]
    [When(@"^I add Contractors Equipment$")]
    [Then(@"^I add Contractors Equipment$")]
    public async Task AddContractorsEquipmentAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickPolicyCovgED95CAsync();
        await page.WaitForPolicyCovgF9E58Async("Exists");
        await page.EnterCoverageFormToBeAddedAsync(data.Resolve("{{data:coverage_form_to_be_added_395}}"));
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded CLICK
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded Enter
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded Tab
        await page.ClickAddCoverageFormAsync();
        await page.WaitForCoverageFormDisplayD1A9BAsync("Exists");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Description03789
        await page.EnterDescription03789Async(data.Resolve("{{data:description_399}}"));
        // v56 suppressed redundant Tosca keyboard steering: Description03789 CLICK
        // v56 suppressed redundant Tosca keyboard steering: Description03789 Tab
        await page.EnterCoinsuranceC9726Async(data.Resolve("{{data:coinsurance_400}}"));
        // v56 suppressed redundant Tosca keyboard steering: CoinsuranceC9726 CLICK
        // v56 suppressed redundant Tosca keyboard steering: CoinsuranceC9726 Tab
        await page.EnterDeductibleC227CAsync(data.Resolve("{{data:deductible_401}}"));
        // v56 suppressed redundant Tosca keyboard steering: DeductibleC227C CLICK
        // v56 suppressed redundant Tosca keyboard steering: DeductibleC227C Tab
        await page.EnterBoomDeductibleAsync(data.Resolve("{{data:boom_deductible_402}}"));
        // v56 suppressed redundant Tosca keyboard steering: BoomDeductible CLICK
        // v56 suppressed redundant Tosca keyboard steering: BoomDeductible Tab
        await page.EnterTypeOfContractorAsync(data.Resolve("{{data:type_of_contractor_403}}"));
        // v56 suppressed redundant Tosca keyboard steering: TypeOfContractor CLICK
        // v56 suppressed redundant Tosca keyboard steering: TypeOfContractor Tab
        await page.EnterScheduledCoverageAsync(data.Resolve("{{data:scheduled_coverage_404}}"));
        // v56 suppressed redundant Tosca keyboard steering: ScheduledCoverage CLICK
        // v56 suppressed redundant Tosca keyboard steering: ScheduledCoverage Tab
        await page.EnterRentedEquipmentExpenseAsync(data.Resolve("{{data:rented_equipment_expense_405}}"));
        // v56 suppressed redundant Tosca keyboard steering: RentedEquipmentExpense CLICK
        // v56 suppressed redundant Tosca keyboard steering: RentedEquipmentExpense Tab
        await page.EnterToolsAndClothingBelongingToYourEmployeesAsync(data.Resolve("{{data:tools_and_clothing_belonging_to_your_employees_406}}"));
        // v56 suppressed redundant Tosca keyboard steering: ToolsAndClothingBelongingToYourEmployees CLICK
        // v56 suppressed redundant Tosca keyboard steering: ToolsAndClothingBelongingToYourEmployees Tab
        await page.EnterMiscItemsBlanketCoverageAsync(data.Resolve("{{data:misc_items_blanket_coverage_407}}"));
        // v56 suppressed redundant Tosca keyboard steering: MiscItemsBlanketCoverage CLICK
        // v56 suppressed redundant Tosca keyboard steering: MiscItemsBlanketCoverage Tab
        await page.EnterRentalReimbursementAsync(data.Resolve("{{data:rental_reimbursement_408}}"));
        // v56 suppressed redundant Tosca keyboard steering: RentalReimbursement CLICK
        // v56 suppressed redundant Tosca keyboard steering: RentalReimbursement Tab
        await page.EnterHiredEquipmentAsync(data.Resolve("{{data:hired_equipment_409}}"));
        // v56 suppressed redundant Tosca keyboard steering: HiredEquipment CLICK
        // v56 suppressed redundant Tosca keyboard steering: HiredEquipment Tab
        await page.ClickPolicyCovgContractorsEquipmentOKAsync();

    }

    [Given(@"^I add Motor Truck Cargo$")]
    [When(@"^I add Motor Truck Cargo$")]
    [Then(@"^I add Motor Truck Cargo$")]
    public async Task AddMotorTruckCargoAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickPolicyCovgED95CAsync();
        await page.WaitForPolicyCovgF9E58Async("Exists");
        await page.EnterCoverageFormToBeAddedAsync(data.Resolve("{{data:coverage_form_to_be_added_413}}"));
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded CLICK
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded Enter
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded Tab
        await page.ClickAddCoverageFormAsync();
        await page.WaitForCoverageFormDisplayB69C2Async("Exists");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets DescriptionF8E60
        await page.EnterDescriptionF8E60Async(data.Resolve("{{data:description_417}}"));
        // v56 suppressed redundant Tosca keyboard steering: DescriptionF8E60 CLICK
        // v56 suppressed redundant Tosca keyboard steering: DescriptionF8E60 Enter
        // v56 suppressed redundant Tosca keyboard steering: DescriptionF8E60 Tab
        await page.EnterCoverageTypeAsync(data.Resolve("{{data:coverage_type_418}}"));
        await page.EnterCoveredPropertyConsistingPrincipallyOfAsync(data.Resolve("{{data:covered_property_consisting_principally_of_419}}"));
        await page.EnterDeductible320C9Async(data.Resolve("{{data:deductible_420}}"));
        await page.EnterPerVehicleLimitAsync(data.Resolve("{{data:per_vehicle_limit_421}}"));
        await page.EnterGroupClassAsync(data.Resolve("{{data:group_class_422}}"));
        await page.EnterNumberOfVehiclesAsync(data.Resolve("{{data:number_of_vehicles_423}}"));
        await page.EnterUnnamedTerminalsLimitAsync(data.Resolve("{{data:unnamed_terminals_limit_424}}"));
        await page.ClickPolicyCovgMotorTruckCargoOKAsync();

    }

    [Given(@"^I add Signs$")]
    [When(@"^I add Signs$")]
    [Then(@"^I add Signs$")]
    public async Task AddSignsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickPolicyCovgED95CAsync();
        await page.WaitForPolicyCovgF9E58Async("Exists");
        await page.EnterCoverageFormToBeAddedAsync(data.Resolve("{{data:coverage_form_to_be_added_428}}"));
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded CLICK
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded Enter
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded Tab
        await page.ClickAddCoverageFormAsync();
        await page.WaitForCoverageFormDisplayC10BAAsync("Exists");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets DescriptionBE47E
        await page.EnterDescriptionBE47EAsync(data.Resolve("{{data:description_432}}"));
        // v56 suppressed redundant Tosca keyboard steering: DescriptionBE47E CLICK
        // v56 suppressed redundant Tosca keyboard steering: DescriptionBE47E Enter
        // v56 suppressed redundant Tosca keyboard steering: DescriptionBE47E Tab
        await page.VerifyCoverageFormA7F96Async("Exists", "");
        await page.EnterN5DeductibleAsync(data.Resolve("{{data:5_deductible_434}}"));
        await page.ClickPolicyCovgSignsOKAsync();
        await page.PauseAsync(1000);

    }

    [Given(@"^I add Accounts Receivable$")]
    [When(@"^I add Accounts Receivable$")]
    [Then(@"^I add Accounts Receivable$")]
    public async Task AddAccountsReceivableAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickRisk5D6FAAsync();
        await page.WaitForRisk873E7Async("Exists");
        await page.EnterCoverageFormCFDD1Async(data.Resolve("{{data:coverage_form_439}}"));
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormCFDD1 CLICK
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormCFDD1 Tab
        await page.ClickAddAsync();
        await page.WaitForAccountsReceivableHeadingAsync("Exists");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets SearchValue79E46
        await page.EnterSearchValue79E46Async(data.Resolve("{{data:search_value_443}}"));
        // v56 suppressed redundant Tosca keyboard steering: SearchValue79E46 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SearchValue79E46 Tab
        await page.EnterSearchResultEAFB8Async(data.Resolve("{{data:search_result_444}}"));
        // v56 suppressed redundant Tosca keyboard steering: SearchResultEAFB8 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SearchResultEAFB8 Enter
        // v56 suppressed redundant Tosca keyboard steering: SearchResultEAFB8 Tab
        await page.EnterConstructionFB8D9Async(data.Resolve("{{data:construction_445}}"));
        // v56 suppressed redundant Tosca keyboard steering: ConstructionFB8D9 CLICK
        // v56 suppressed redundant Tosca keyboard steering: ConstructionFB8D9 Tab
        await page.EnterPremisesTypeAsync(data.Resolve("{{data:premises_type_446}}"));
        // v56 suppressed redundant Tosca keyboard steering: PremisesType CLICK
        // v56 suppressed redundant Tosca keyboard steering: PremisesType Tab
        await page.EnterDuplicatedRecordsAsync(data.Resolve("{{data:duplicated_records_447}}"));
        // v56 suppressed redundant Tosca keyboard steering: DuplicatedRecords CLICK
        // v56 suppressed redundant Tosca keyboard steering: DuplicatedRecords Tab
        await page.EnterClassificationOfRiskAsync(data.Resolve("{{data:classification_of_risk_448}}"));
        // v56 suppressed redundant Tosca keyboard steering: ClassificationOfRisk CLICK
        // v56 suppressed redundant Tosca keyboard steering: ClassificationOfRisk Tab
        await page.ClickRiskAccountsReceivableOKAsync();

    }

    [Given(@"^I complete if search result Alert exists$")]
    [When(@"^I complete if search result Alert exists$")]
    [Then(@"^I complete if search result Alert exists$")]
    public async Task CompleteIfSearchResultAlertExistsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyShowMeAsync("Exists", "");
        await page.ClickShowMeAsync();

    }

    [Given(@"^I complete ensure Class has been entered for Accounts Receivable$")]
    [When(@"^I complete ensure Class has been entered for Accounts Receivable$")]
    [Then(@"^I complete ensure Class has been entered for Accounts Receivable$")]
    public async Task CompleteEnsureClassHasBeenEnteredForAccountsReceivableAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifySearchResultEAFB8Async(data.Resolve("{{data:expected_search_result_value_452}}"), "Value");
        await page.VerifySearchResultEAFB8Async(data.Resolve("{{data:expected_search_result_value_453}}"), "Value");
        await page.WaitForAccountsReceivableHeadingAsync("Exists");
        await page.EnterSearchValue79E46Async(data.Resolve("{{data:search_value_455}}"));
        // v56 suppressed redundant Tosca keyboard steering: SearchValue79E46 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SearchValue79E46 Tab
        await page.EnterSearchResultEAFB8Async(data.Resolve("{{data:search_result_456}}"));
        // v56 suppressed redundant Tosca keyboard steering: SearchResultEAFB8 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SearchResultEAFB8 Enter
        // v56 suppressed redundant Tosca keyboard steering: SearchResultEAFB8 Tab
        await page.ClickRiskAccountsReceivableOKAsync();

    }

    [Given(@"^I add Bailees Customers$")]
    [When(@"^I add Bailees Customers$")]
    [Then(@"^I add Bailees Customers$")]
    public async Task AddBaileesCustomersAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickRisk5D6FAAsync();
        await page.WaitForRisk873E7Async("Exists");
        await page.EnterCoverageFormCFDD1Async(data.Resolve("{{data:coverage_form_460}}"));
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormCFDD1 CLICK
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormCFDD1 Tab
        await page.ClickAddAsync();
        await page.WaitForBaileesCustomersHeadingAsync("Exists");
        await page.EnterDeductible59155Async(data.Resolve("{{data:deductible_463}}"));
        // v56 suppressed redundant Tosca keyboard steering: Deductible59155 CLICK
        // v56 suppressed redundant Tosca keyboard steering: Deductible59155 Tab
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets SearchValueCA6A6
        await page.EnterSearchValueCA6A6Async(data.Resolve("{{data:search_value_465}}"));
        // v56 suppressed redundant Tosca keyboard steering: SearchValueCA6A6 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SearchValueCA6A6 Tab
        await page.EnterSearchResultA1BFBAsync(data.Resolve("{{data:search_result_466}}"));
        // v56 suppressed redundant Tosca keyboard steering: SearchResultA1BFB CLICK
        // v56 suppressed redundant Tosca keyboard steering: SearchResultA1BFB Enter
        // v56 suppressed redundant Tosca keyboard steering: SearchResultA1BFB Tab
        await page.EnterConstructionCD2DEAsync(data.Resolve("{{data:construction_467}}"));
        // v56 suppressed redundant Tosca keyboard steering: ConstructionCD2DE CLICK
        // v56 suppressed redundant Tosca keyboard steering: ConstructionCD2DE Tab
        await page.EnterAnnualGrossReceiptsAsync(data.Resolve("{{data:annual_gross_receipts_468}}"));
        // v56 suppressed redundant Tosca keyboard steering: AnnualGrossReceipts CLICK
        // v56 suppressed redundant Tosca keyboard steering: AnnualGrossReceipts Tab
        await page.EnterAverageNumberOfDaysServiceAsync(data.Resolve("{{data:average_number_of_days_service_469}}"));
        // v56 suppressed redundant Tosca keyboard steering: AverageNumberOfDaysService CLICK
        // v56 suppressed redundant Tosca keyboard steering: AverageNumberOfDaysService Tab
        await page.EnterAverageNumberOfWorkingDaysAsync(data.Resolve("{{data:average_number_of_working_days_470}}"));
        // v56 suppressed redundant Tosca keyboard steering: AverageNumberOfWorkingDays CLICK
        // v56 suppressed redundant Tosca keyboard steering: AverageNumberOfWorkingDays Tab
        await page.EnterAverageServiceChargeAsync(data.Resolve("{{data:average_service_charge_471}}"));
        // v56 suppressed redundant Tosca keyboard steering: AverageServiceCharge CLICK
        // v56 suppressed redundant Tosca keyboard steering: AverageServiceCharge Tab
        await page.EnterAverageValuePerOrderAsync(data.Resolve("{{data:average_value_per_order_472}}"));
        // v56 suppressed redundant Tosca keyboard steering: AverageValuePerOrder CLICK
        // v56 suppressed redundant Tosca keyboard steering: AverageValuePerOrder Tab
        await page.EnterLimitE32DCAsync(data.Resolve("{{data:limit_473}}"));
        // v56 suppressed redundant Tosca keyboard steering: LimitE32DC CLICK
        // v56 suppressed redundant Tosca keyboard steering: LimitE32DC Tab
        await page.EnterEarthquakeAsync(data.Resolve("{{data:earthquake_474}}"));
        // v56 suppressed redundant Tosca keyboard steering: Earthquake CLICK
        // v56 suppressed redundant Tosca keyboard steering: Earthquake Tab
        await page.EnterStorageLimitAsync(data.Resolve("{{data:storage_limit_475}}"));
        // v56 suppressed redundant Tosca keyboard steering: StorageLimit CLICK
        // v56 suppressed redundant Tosca keyboard steering: StorageLimit Tab
        await page.ClickRiskBaileesCustomersOKAsync();

    }

    [Given(@"^I complete if search result Alert exists for show me$")]
    [When(@"^I complete if search result Alert exists for show me$")]
    [Then(@"^I complete if search result Alert exists for show me$")]
    public async Task CompleteIfSearchResultAlertExistsForShowMeAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyShowMeAsync("Exists", "");
        await page.ClickShowMeAsync();

    }

    [Given(@"^I complete ensure Class has been entered for Bailees Customers$")]
    [When(@"^I complete ensure Class has been entered for Bailees Customers$")]
    [Then(@"^I complete ensure Class has been entered for Bailees Customers$")]
    public async Task CompleteEnsureClassHasBeenEnteredForBaileesCustomersAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifySearchResultA1BFBAsync(data.Resolve("{{data:expected_search_result_value_479}}"), "Value");
        await page.VerifySearchResultA1BFBAsync(data.Resolve("{{data:expected_search_result_value_480}}"), "Value");
        await page.EnterSearchValueCA6A6Async(data.Resolve("{{data:search_value_481}}"));
        // v56 suppressed redundant Tosca keyboard steering: SearchValueCA6A6 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SearchValueCA6A6 Tab
        await page.EnterSearchResultA1BFBAsync(data.Resolve("{{data:search_result_482}}"));
        // v56 suppressed redundant Tosca keyboard steering: SearchResultA1BFB CLICK
        // v56 suppressed redundant Tosca keyboard steering: SearchResultA1BFB Enter
        // v56 suppressed redundant Tosca keyboard steering: SearchResultA1BFB Tab
        await page.ClickRiskBaileesCustomersOKAsync();

    }

    [Given(@"^I add Computer Systems for risk$")]
    [When(@"^I add Computer Systems for risk$")]
    [Then(@"^I add Computer Systems for risk$")]
    public async Task AddComputerSystemsForRiskAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickRisk5D6FAAsync();
        await page.WaitForRisk873E7Async("Exists");
        await page.EnterCoverageFormCFDD1Async(data.Resolve("{{data:coverage_form_486}}"));
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormCFDD1 CLICK
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormCFDD1 Tab
        await page.ClickAddAsync();
        await page.EnterComputerEquipmentAsync(data.Resolve("{{data:computer_equipment_488}}"));
        // v56 suppressed redundant Tosca keyboard steering: ComputerEquipment CLICK
        // v56 suppressed redundant Tosca keyboard steering: ComputerEquipment Tab
        await page.EnterDataAndMediaAsync(data.Resolve("{{data:data_and_media_489}}"));
        // v56 suppressed redundant Tosca keyboard steering: DataAndMedia CLICK
        // v56 suppressed redundant Tosca keyboard steering: DataAndMedia Tab
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets SearchValue9FCD1
        await page.EnterSearchValue9FCD1Async(data.Resolve("{{data:search_value_491}}"));
        // v56 suppressed redundant Tosca keyboard steering: SearchValue9FCD1 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SearchValue9FCD1 Tab
        await page.EnterSearchResult4E620Async(data.Resolve("{{data:search_result_492}}"));
        // v56 suppressed redundant Tosca keyboard steering: SearchResult4E620 Click
        // v56 suppressed redundant Tosca keyboard steering: SearchResult4E620 Enter
        // v56 suppressed redundant Tosca keyboard steering: SearchResult4E620 Tab
        await page.EnterConstructionCodeAsync(data.Resolve("{{data:construction_code_493}}"));
        // v56 suppressed redundant Tosca keyboard steering: ConstructionCode CLICK
        // v56 suppressed redundant Tosca keyboard steering: ConstructionCode Tab
        await page.ClickRiskComputerSystemsOKAsync();

    }

    [Given(@"^I complete if search result Alert exists for duck creek policy$")]
    [When(@"^I complete if search result Alert exists for duck creek policy$")]
    [Then(@"^I complete if search result Alert exists for duck creek policy$")]
    public async Task CompleteIfSearchResultAlertExistsForDuckCreekPolicyAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyShowMeAsync("Exists", "");
        await page.ClickShowMeAsync();

    }

    [Given(@"^I complete ensure Class has been entered for Computer Systems$")]
    [When(@"^I complete ensure Class has been entered for Computer Systems$")]
    [Then(@"^I complete ensure Class has been entered for Computer Systems$")]
    public async Task CompleteEnsureClassHasBeenEnteredForComputerSystemsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifySearchResult4E620Async(data.Resolve("{{data:expected_search_result_value_497}}"), "Value");
        await page.VerifySearchResult4E620Async(data.Resolve("{{data:expected_search_result_value_498}}"), "Value");
        await page.EnterSearchValue9FCD1Async(data.Resolve("{{data:search_value_499}}"));
        // v56 suppressed redundant Tosca keyboard steering: SearchValue9FCD1 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SearchValue9FCD1 Tab
        await page.EnterSearchResult4E620Async(data.Resolve("{{data:search_result_500}}"));
        // v56 suppressed redundant Tosca keyboard steering: SearchResult4E620 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SearchResult4E620 Enter
        // v56 suppressed redundant Tosca keyboard steering: SearchResult4E620 Tab
        await page.ClickRiskComputerSystemsOKAsync();

    }

    [Given(@"^I add Signs for risk$")]
    [When(@"^I add Signs for risk$")]
    [Then(@"^I add Signs for risk$")]
    public async Task AddSignsForRiskAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickRisk5D6FAAsync();
        await page.WaitForRisk873E7Async("Exists");
        await page.EnterCoverageFormCFDD1Async(data.Resolve("{{data:coverage_form_504}}"));
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormCFDD1 CLICK
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormCFDD1 Tab
        await page.ClickAddAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.EnterLimitOfInsuranceAsync(data.Resolve("{{data:limit_of_insurance_507}}"));
        // v56 suppressed redundant Tosca keyboard steering: LimitOfInsurance CLICK
        // v56 suppressed redundant Tosca keyboard steering: LimitOfInsurance Tab
        await page.EnterSignLocationAsync(data.Resolve("{{data:sign_location_508}}"));
        // v56 suppressed redundant Tosca keyboard steering: SignLocation CLICK
        // v56 suppressed redundant Tosca keyboard steering: SignLocation Tab
        await page.EnterTypeB082DAsync(data.Resolve("{{data:type_509}}"));
        // v56 suppressed redundant Tosca keyboard steering: TypeB082D CLICK
        // v56 suppressed redundant Tosca keyboard steering: TypeB082D Tab
        await page.EnterLetteringAsync(data.Resolve("{{data:lettering_510}}"));
        // v56 suppressed redundant Tosca keyboard steering: Lettering CLICK
        // v56 suppressed redundant Tosca keyboard steering: Lettering Tab
        await page.ClickRiskSignsOKAsync();

    }

    [Given(@"^I add CM 66 01 Exclude Named Customer$")]
    [When(@"^I add CM 66 01 Exclude Named Customer$")]
    [Then(@"^I add CM 66 01 Exclude Named Customer$")]
    public async Task AddCM6601ExcludeNamedCustomerAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Exists");
        await page.ClickAddEndorsement48A9EAsync();
        await page.EnterType715D6Async(data.Resolve("{{data:type_515}}"));
        // v56 suppressed redundant Tosca keyboard steering: Type715D6 CLICK
        // v56 suppressed redundant Tosca keyboard steering: Type715D6 Tab
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Names
        await page.EnterNamesAsync(data.Resolve("{{data:names_517}}"));
        // v56 suppressed redundant Tosca keyboard steering: Names CLICK
        // v56 suppressed redundant Tosca keyboard steering: Names Tab
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Address
        await page.EnterAddressAsync(data.Resolve("{{data:address_519}}"));
        // v56 suppressed redundant Tosca keyboard steering: Address CLICK
        // v56 suppressed redundant Tosca keyboard steering: Address Tab
        await page.ClickEndorsementCM6601ExcludeNamedCustomerOKAsync();

    }

    [Given(@"^I add IF 00 02 Waterborne Equipment$")]
    [When(@"^I add IF 00 02 Waterborne Equipment$")]
    [Then(@"^I add IF 00 02 Waterborne Equipment$")]
    public async Task AddIF0002WaterborneEquipmentAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickEndorsementAsync();
        await page.WaitForEndorsementHeadingAsync("Exists");
        await page.ClickAddEndorsement48A9EAsync();
        await page.EnterType715D6Async(data.Resolve("{{data:type_524}}"));
        await page.EnterLimit887C5Async(data.Resolve("{{data:limit_525}}"));
        await page.EnterDeductible0CC0AAsync(data.Resolve("{{data:deductible_526}}"));
        await page.ClickEndorsementIF0002WaterborneEquipmentOKAsync();

    }

    [Given(@"^I complete Accounts Receivable Questions$")]
    [When(@"^I complete Accounts Receivable Questions$")]
    [Then(@"^I complete Accounts Receivable Questions$")]
    public async Task CompleteAccountsReceivableQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickSpecificUnderwritingQuestionsAsync();
        await page.ClickAccountsReceivableUWQuestionsAsync();
        await page.WaitForAccountsReceivableHeadingAsync("Exists");
        await page.ClickUpdateAnswersD8A16Async();
        await page.EnterWhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStoredAsync(data.Resolve("{{data:what_is_the_construction_of_the_premises_where_the_receivables_are_stored_532}}"));
        // v56 suppressed redundant Tosca keyboard steering: WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored Tab
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft
        await page.EnterWhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheftAsync(data.Resolve("{{data:what_safeguards_are_in_place_for_receivables_to_protect_against_damage_or_theft_534}}"));
        // v56 suppressed redundant Tosca keyboard steering: WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft Tab
        await page.ClickSpecificUnderwritingQuestionsAccountsReceivableOKAsync();

    }

    [Given(@"^I complete Bailees Customers Questions$")]
    [When(@"^I complete Bailees Customers Questions$")]
    [Then(@"^I complete Bailees Customers Questions$")]
    public async Task CompleteBaileesCustomersQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickSpecificUnderwritingQuestionsAsync();
        await page.ClickBaileesCustomerUWQuestionsAsync();
        await page.WaitForBaileesCustomerHeadingAsync("Exists");
        await page.EnterDryCleaningAsync(data.Resolve("{{data:dry_cleaning_539}}"));
        // v56 suppressed redundant Tosca keyboard steering: DryCleaning CLICK
        // v56 suppressed redundant Tosca keyboard steering: DryCleaning Tab
        await page.EnterLaundryAsync(data.Resolve("{{data:laundry_540}}"));
        // v56 suppressed redundant Tosca keyboard steering: Laundry CLICK
        // v56 suppressed redundant Tosca keyboard steering: Laundry Tab
        await page.EnterN2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremisesAsync(data.Resolve("{{data:2_indicate_the_age_type_of_construction_and_protection_class_of_the_premises_541}}"));
        // v56 suppressed redundant Tosca keyboard steering: N2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremises CLICK
        // v56 suppressed redundant Tosca keyboard steering: N2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremises Tab
        await page.EnterN3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepairAsync(data.Resolve("{{data:3_what_is_the_percentage_of_annual_gross_receipts_derived_from_service_or_repair_542}}"));
        // v56 suppressed redundant Tosca keyboard steering: N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair CLICK
        // v56 suppressed redundant Tosca keyboard steering: N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair CLICK
        // v56 suppressed redundant Tosca keyboard steering: N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair Tab
        await page.EnterN4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdatedAsync(data.Resolve("{{data:4_what_method_do_you_use_for_keeping_records_of_property_in_your_care_and_how_often_are_the_records_updated_543}}"));
        // v56 suppressed redundant Tosca keyboard steering: N4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdated CLICK
        // v56 suppressed redundant Tosca keyboard steering: N4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdated Tab
        await page.EnterN5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintainedAsync(data.Resolve("{{data:5_are_recognized_approved_central_station_burglar_alarms_installed_and_maintained_544}}"));
        // v56 suppressed redundant Tosca keyboard steering: N5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintained CLICK
        // v56 suppressed redundant Tosca keyboard steering: N5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintained Tab
        await page.EnterN6AreAllStorageAreasLockedAtAllTimesWhenUnoccupiedAsync(data.Resolve("{{data:6_are_all_storage_areas_locked_at_all_times_when_unoccupied_545}}"));
        // v56 suppressed redundant Tosca keyboard steering: N6AreAllStorageAreasLockedAtAllTimesWhenUnoccupied CLICK
        // v56 suppressed redundant Tosca keyboard steering: N6AreAllStorageAreasLockedAtAllTimesWhenUnoccupied Tab
        await page.EnterN7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremisesAsync(data.Resolve("{{data:7_are_there_any_hazardous_or_flammable_materials_used_or_stored_on_the_premises_546}}"));
        // v56 suppressed redundant Tosca keyboard steering: N7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremises CLICK
        // v56 suppressed redundant Tosca keyboard steering: N7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremises Tab
        await page.EnterAWhatIsThePublicProtectionClassRatingAsync(data.Resolve("{{data:a_what_is_the_public_protection_class_rating_547}}"));
        // v56 suppressed redundant Tosca keyboard steering: AWhatIsThePublicProtectionClassRating CLICK
        // v56 suppressed redundant Tosca keyboard steering: AWhatIsThePublicProtectionClassRating CLICK
        // v56 suppressed redundant Tosca keyboard steering: AWhatIsThePublicProtectionClassRating Tab
        await page.EnterBAreThereAnyPrivateProtectionImprovementsAsync(data.Resolve("{{data:b_are_there_any_private_protection_improvements_548}}"));
        // v56 suppressed redundant Tosca keyboard steering: BAreThereAnyPrivateProtectionImprovements CLICK
        // v56 suppressed redundant Tosca keyboard steering: BAreThereAnyPrivateProtectionImprovements Tab
        await page.EnterCWhatIsTheDistanceInFeetToTheNearestHydrantAsync(data.Resolve("{{data:c_what_is_the_distance_in_feet_to_the_nearest_hydrant_549}}"));
        // v56 suppressed redundant Tosca keyboard steering: CWhatIsTheDistanceInFeetToTheNearestHydrant CLICK
        // v56 suppressed redundant Tosca keyboard steering: CWhatIsTheDistanceInFeetToTheNearestHydrant Tab
        await page.EnterDWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartmentAsync(data.Resolve("{{data:d_what_is_the_distance_in_miles_to_the_nearest_responding_fire_department_550}}"));
        // v56 suppressed redundant Tosca keyboard steering: DWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment CLICK
        // v56 suppressed redundant Tosca keyboard steering: DWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment Tab
        await page.EnterEAreNoSmokingRulesPostedAndEnforcedAsync(data.Resolve("{{data:e_are_no_smoking_rules_posted_and_enforced_551}}"));
        // v56 suppressed redundant Tosca keyboard steering: EAreNoSmokingRulesPostedAndEnforced CLICK
        // v56 suppressed redundant Tosca keyboard steering: EAreNoSmokingRulesPostedAndEnforced Tab
        await page.EnterN9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystemAsync(data.Resolve("{{data:9_are_the_premises_or_any_portion_of_the_premises_equipped_with_a_sprinkler_system_552}}"));
        // v56 suppressed redundant Tosca keyboard steering: N9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystem CLICK
        // v56 suppressed redundant Tosca keyboard steering: N9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystem Tab
        await page.EnterN10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarmsAsync(data.Resolve("{{data:10_are_the_premises_equipped_with_a_recognized_approved_central_station_fire_alarm_fire_extinguishers_or_smoke_alarms_553}}"));
        // v56 suppressed redundant Tosca keyboard steering: N10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarms CLICK
        // v56 suppressed redundant Tosca keyboard steering: N10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarms Tab
        await page.EnterN11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransitAsync(data.Resolve("{{data:11_what_is_the_procedure_for_transporting_property_include_the_transit_methods_used_and_the_protection_class_provided_while_in_transit_554}}"));
        // v56 suppressed redundant Tosca keyboard steering: N11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransit CLICK
        // v56 suppressed redundant Tosca keyboard steering: N11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransit Tab
        await page.EnterN12AreDriversMVRsReviewedOnARegularBasisAndMaintainedAsync(data.Resolve("{{data:12_are_drivers_mvrs_reviewed_on_a_regular_basis_and_maintained_555}}"));
        // v56 suppressed redundant Tosca keyboard steering: N12AreDriversMVRsReviewedOnARegularBasisAndMaintained CLICK
        // v56 suppressed redundant Tosca keyboard steering: N12AreDriversMVRsReviewedOnARegularBasisAndMaintained Tab
        await page.EnterN13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicleAsync(data.Resolve("{{data:13_what_types_of_vehicles_do_you_operate_and_what_protective_devices_are_on_each_vehicle_556}}"));
        // v56 suppressed redundant Tosca keyboard steering: N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle CLICK
        // v56 suppressed redundant Tosca keyboard steering: N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle CLICK
        // v56 suppressed redundant Tosca keyboard steering: N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle Tab
        await page.EnterN14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorageAsync(data.Resolve("{{data:14_what_is_your_procedure_for_protecting_small_items_from_breakage_or_disappearance_while_in_storage_557}}"));
        // v56 suppressed redundant Tosca keyboard steering: N14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorage CLICK
        // v56 suppressed redundant Tosca keyboard steering: N14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorage Tab
        await page.EnterN15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheftAsync(data.Resolve("{{data:15_what_measures_does_the_insured_take_to_protect_customer_s_property_against_theft_558}}"));
        // v56 suppressed redundant Tosca keyboard steering: N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft CLICK
        // v56 suppressed redundant Tosca keyboard steering: N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft CLICK
        // v56 suppressed redundant Tosca keyboard steering: N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft Tab
        await page.EnterN16DoesTheRiskUseReleaseFormsAsync(data.Resolve("{{data:16_does_the_risk_use_release_forms_559}}"));
        // v56 suppressed redundant Tosca keyboard steering: N16DoesTheRiskUseReleaseForms CLICK
        // v56 suppressed redundant Tosca keyboard steering: N16DoesTheRiskUseReleaseForms Tab
        await page.ClickSpecificUnderwritingQuestionsBaileesCustomerOKAsync();

    }

    [Given(@"^I complete Computer Systems Questions$")]
    [When(@"^I complete Computer Systems Questions$")]
    [Then(@"^I complete Computer Systems Questions$")]
    public async Task CompleteComputerSystemsQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickSpecificUnderwritingQuestionsAsync();
        await page.ClickComputerSystemsUWQuestionsAsync();
        await page.ClickUpdateAnswers3DDA2Async();
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets UpdateAnswers3DDA2
        await page.PressUpdateAnswers3DDA2Async("Click");
        await page.EnterWhatIsTheProcedureForTransportingTheComputerEquipmentAsync(data.Resolve("{{data:what_is_the_procedure_for_transporting_the_computer_equipment_564}}"));
        // v56 suppressed redundant Tosca keyboard steering: WhatIsTheProcedureForTransportingTheComputerEquipment CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatIsTheProcedureForTransportingTheComputerEquipment Tab
        await page.EnterIndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocatedAsync(data.Resolve("{{data:indicate_the_building_s_age_type_of_construction_and_protection_class_and_other_tenants_in_the_building_s_where_the_computer_equipment_is_located_565}}"));
        // v56 suppressed redundant Tosca keyboard steering: IndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocated CLICK
        // v56 suppressed redundant Tosca keyboard steering: IndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocated Tab
        await page.EnterWhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecuredAsync(data.Resolve("{{data:what_are_the_procedures_and_methods_for_keeping_the_edp_areas_secured_566}}"));
        // v56 suppressed redundant Tosca keyboard steering: WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured Tab
        await page.EnterWhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorageAsync(data.Resolve("{{data:what_are_the_procedures_and_schedule_for_backing_up_the_media_and_data_and_their_storage_567}}"));
        // v56 suppressed redundant Tosca keyboard steering: WhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorage CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorage Tab
        await page.EnterProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMediaAsync(data.Resolve("{{data:provide_information_regarding_antivirus_methods_and_copyright_protection_of_data_and_media_568}}"));
        // v56 suppressed redundant Tosca keyboard steering: ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia CLICK
        // v56 suppressed redundant Tosca keyboard steering: ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia CLICK
        // v56 suppressed redundant Tosca keyboard steering: ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia Tab
        await page.EnterWhatIsThePublicProtectionClassRatingAsync(data.Resolve("{{data:what_is_the_public_protection_class_rating_569}}"));
        // v56 suppressed redundant Tosca keyboard steering: WhatIsThePublicProtectionClassRating CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatIsThePublicProtectionClassRating CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatIsThePublicProtectionClassRating CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatIsThePublicProtectionClassRating Tab
        await page.EnterWhatIsTheDistanceInFeetToTheNearestFireHydrantAsync(data.Resolve("{{data:what_is_the_distance_in_feet_to_the_nearest_fire_hydrant_570}}"));
        // v56 suppressed redundant Tosca keyboard steering: WhatIsTheDistanceInFeetToTheNearestFireHydrant CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatIsTheDistanceInFeetToTheNearestFireHydrant CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatIsTheDistanceInFeetToTheNearestFireHydrant Tab
        await page.EnterWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartmentAsync(data.Resolve("{{data:what_is_the_distance_in_miles_to_the_nearest_responding_fire_department_571}}"));
        // v56 suppressed redundant Tosca keyboard steering: WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment Tab
        await page.EnterUninterruptiblePowerSourceAsync(data.Resolve("{{data:uninterruptible_power_source_572}}"));
        // v56 suppressed redundant Tosca keyboard steering: UninterruptiblePowerSource CLICK
        // v56 suppressed redundant Tosca keyboard steering: UninterruptiblePowerSource Tab
        await page.EnterLineConditionerAsync(data.Resolve("{{data:line_conditioner_573}}"));
        // v56 suppressed redundant Tosca keyboard steering: LineConditioner CLICK
        // v56 suppressed redundant Tosca keyboard steering: LineConditioner Tab
        await page.EnterPowerSuppressorVoltageRegulatorAsync(data.Resolve("{{data:power_suppressor_voltage_regulator_574}}"));
        // v56 suppressed redundant Tosca keyboard steering: PowerSuppressorVoltageRegulator CLICK
        // v56 suppressed redundant Tosca keyboard steering: PowerSuppressorVoltageRegulator Tab
        await page.EnterDedicatedLineAsync(data.Resolve("{{data:dedicated_line_575}}"));
        // v56 suppressed redundant Tosca keyboard steering: DedicatedLine CLICK
        // v56 suppressed redundant Tosca keyboard steering: DedicatedLine Tab
        await page.EnterHowOftenIsDataBackedUpAsync(data.Resolve("{{data:how_often_is_data_backed_up_576}}"));
        // v56 suppressed redundant Tosca keyboard steering: HowOftenIsDataBackedUp CLICK
        // v56 suppressed redundant Tosca keyboard steering: HowOftenIsDataBackedUp Tab
        await page.ClickSpecificUnderwritingQuestionsComputerSystemsOKAsync();

    }

    [Given(@"^I complete Contractors Equipment Questions$")]
    [When(@"^I complete Contractors Equipment Questions$")]
    [Then(@"^I complete Contractors Equipment Questions$")]
    public async Task CompleteContractorsEquipmentQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickSpecificUnderwritingQuestionsAsync();
        await page.ClickContractorsEquipmentUWQuestionsAsync();
        await page.WaitForContractorsEquipmentHeadingAsync("Exists");
        await page.ClickUpdateAnswers3DA0BAsync();
        await page.EnterEstimatedHighestValueAsync(data.Resolve("{{data:estimated_highest_value_582}}"));
        // v56 suppressed redundant Tosca keyboard steering: EstimatedHighestValue CLICK
        // v56 suppressed redundant Tosca keyboard steering: EstimatedHighestValue Tab
        await page.EnterIfYesDescribeAsync(data.Resolve("{{data:if_yes_describe_583}}"));
        // v56 suppressed redundant Tosca keyboard steering: IfYesDescribe CLICK
        // v56 suppressed redundant Tosca keyboard steering: IfYesDescribe Tab
        await page.ClickSpecificUnderwritingQuestionsContractorsEquipmentOKAsync();

    }

    [Given(@"^I complete Motor Truck Cargo Questions \(Owner\)$")]
    [When(@"^I complete Motor Truck Cargo Questions \(Owner\)$")]
    [Then(@"^I complete Motor Truck Cargo Questions \(Owner\)$")]
    public async Task CompleteMotorTruckCargoQuestionsOwnerAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickSpecificUnderwritingQuestionsAsync();
        await page.ClickMotorTruckCargoUWQuestionsAsync();
        await page.WaitForMotorTruckCargoHeadingAsync("Exists");
        await page.EnterWhichFormAreYouCompletingAsync(data.Resolve("{{data:which_form_are_you_completing_588}}"));
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment
        await page.EnterN1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipmentAsync(data.Resolve("{{data:1_what_are_the_distances_the_shipments_will_travel_and_the_time_required_to_complete_the_shipment_590}}"));
        // v56 suppressed redundant Tosca keyboard steering: N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment CLICK
        // v56 suppressed redundant Tosca keyboard steering: N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment CLICK
        // v56 suppressed redundant Tosca keyboard steering: N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment Tab
        await page.EnterN2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommoditiesAsync(data.Resolve("{{data:2_what_are_the_types_and_ages_of_the_vehicles_trailers_used_to_transport_your_commodities_591}}"));
        // v56 suppressed redundant Tosca keyboard steering: N2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommodities CLICK
        // v56 suppressed redundant Tosca keyboard steering: N2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommodities Tab
        await page.EnterN3DoesTheApplicantHaulForOthersAsync(data.Resolve("{{data:3_does_the_applicant_haul_for_others_592}}"));
        // v56 suppressed redundant Tosca keyboard steering: N3DoesTheApplicantHaulForOthers CLICK
        // v56 suppressed redundant Tosca keyboard steering: N3DoesTheApplicantHaulForOthers Tab
        await page.EnterN4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailerAsync(data.Resolve("{{data:4_what_protective_devices_are_installed_on_each_vehicle_or_trailer_593}}"));
        // v56 suppressed redundant Tosca keyboard steering: N4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailer CLICK
        // v56 suppressed redundant Tosca keyboard steering: N4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailer Tab
        await page.EnterN5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttachedAsync(data.Resolve("{{data:5_do_any_vehicles_have_special_equipment_mounted_or_attached_594}}"));
        // v56 suppressed redundant Tosca keyboard steering: N5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttached CLICK
        // v56 suppressed redundant Tosca keyboard steering: N5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttached Tab
        await page.EnterN6DoesTheApplicantPullDoubleOrTripleTrailersAsync(data.Resolve("{{data:6_does_the_applicant_pull_double_or_triple_trailers_595}}"));
        // v56 suppressed redundant Tosca keyboard steering: N6DoesTheApplicantPullDoubleOrTripleTrailers CLICK
        // v56 suppressed redundant Tosca keyboard steering: N6DoesTheApplicantPullDoubleOrTripleTrailers Tab
        await page.EnterN7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattendedAsync(data.Resolve("{{data:7_does_the_applicant_leave_the_truck_windows_doors_and_compartments_closed_and_locked_when_unattended_596}}"));
        // v56 suppressed redundant Tosca keyboard steering: N7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattended CLICK
        // v56 suppressed redundant Tosca keyboard steering: N7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattended Tab
        await page.EnterN8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperateAsync(data.Resolve("{{data:8_do_you_provide_scheduled_maintenance_for_the_vehicles_and_trailers_you_operate_597}}"));
        // v56 suppressed redundant Tosca keyboard steering: N8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperate CLICK
        // v56 suppressed redundant Tosca keyboard steering: N8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperate Tab
        await page.EnterN9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommoditiesAsync(data.Resolve("{{data:9_are_the_employees_that_pack_load_and_unload_trained_in_proper_handling_of_the_commodities_598}}"));
        // v56 suppressed redundant Tosca keyboard steering: N9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommodities CLICK
        // v56 suppressed redundant Tosca keyboard steering: N9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommodities Tab
        await page.EnterN10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheftAsync(data.Resolve("{{data:10_how_are_the_goods_being_transported_protected_from_damage_and_theft_599}}"));
        // v56 suppressed redundant Tosca keyboard steering: N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft CLICK
        // v56 suppressed redundant Tosca keyboard steering: N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft Tab
        await page.EnterN11AreDriversMVRsAndTripLogsMaintainedAsync(data.Resolve("{{data:11_are_drivers_mvrs_and_trip_logs_maintained_600}}"));
        // v56 suppressed redundant Tosca keyboard steering: N11AreDriversMVRsAndTripLogsMaintained CLICK
        // v56 suppressed redundant Tosca keyboard steering: N11AreDriversMVRsAndTripLogsMaintained Tab
        await page.EnterN12HowOftenAreTheseLogsReviewedOrUpdatedAsync(data.Resolve("{{data:12_how_often_are_these_logs_reviewed_or_updated_601}}"));
        // v56 suppressed redundant Tosca keyboard steering: N12HowOftenAreTheseLogsReviewedOrUpdated CLICK
        // v56 suppressed redundant Tosca keyboard steering: N12HowOftenAreTheseLogsReviewedOrUpdated Tab
        await page.EnterN13LiveAnimalInTransitCoverageAsync(data.Resolve("{{data:13_live_animal_in_transit_coverage_602}}"));
        // v56 suppressed redundant Tosca keyboard steering: N13LiveAnimalInTransitCoverage CLICK
        // v56 suppressed redundant Tosca keyboard steering: N13LiveAnimalInTransitCoverage Tab
        await page.EnterN14LegalLiabilityCoverageAsync(data.Resolve("{{data:14_legal_liability_coverage_603}}"));
        // v56 suppressed redundant Tosca keyboard steering: N14LegalLiabilityCoverage CLICK
        // v56 suppressed redundant Tosca keyboard steering: N14LegalLiabilityCoverage Tab
        await page.ClickSpecificUnderwritingQuestionsMotorTruckCargoOwnersOKAsync();

    }

    [Given(@"^I complete Signs Questions$")]
    [When(@"^I complete Signs Questions$")]
    [Then(@"^I complete Signs Questions$")]
    public async Task CompleteSignsQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickSpecificUnderwritingQuestionsAsync();
        await page.ClickSignsUWQuestionsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.EnterAreAnySignsOffPremisesOrNotAttachedToBuildingAsync(data.Resolve("{{data:are_any_signs_off_premises_or_not_attached_to_building_608}}"));
        await page.EnterDoesTheApplicantWishToCoverAnySignsInsideTheirPremisesAsync(data.Resolve("{{data:does_the_applicant_wish_to_cover_any_signs_inside_their_premises_609}}"));
        await page.EnterWhatIsTheConstructionOfEachSignAsync(data.Resolve("{{data:what_is_the_construction_of_each_sign_610}}"));
        await page.ClickSpecificUnderwritingQuestionsSignsOKAsync();

    }

    [Given(@"^I return to CPP policy navigation$")]
    [When(@"^I return to CPP policy navigation$")]
    [Then(@"^I return to CPP policy navigation$")]
    public async Task ReturnToCPPPolicyNavigationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickReturnToCPPAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.PauseAsync(1000);

    }

    [Given(@"^I select GL Available Classiifcation$")]
    [When(@"^I select GL Available Classiifcation$")]
    [Then(@"^I select GL Available Classiifcation$")]
    public async Task SelectGLAvailableClassiifcationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickPricing900C9Async();
        await page.EnterAvailableClassificationsAsync(data.Resolve("{{data:available_classifications_617}}"));
        // v56 suppressed redundant Tosca keyboard steering: AvailableClassifications CLICK
        // v56 suppressed redundant Tosca keyboard steering: AvailableClassifications Tab
        // v56 suppressed redundant Tosca keyboard steering: AvailableClassifications Enter

    }

    [Given(@"^I navigate to Underwriting Info Screens$")]
    [When(@"^I navigate to Underwriting Info Screens$")]
    [Then(@"^I navigate to Underwriting Info Screens$")]
    public async Task NavigateToUnderwritingInfoScreensAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickClient35F85Async();
        await page.ClickUnderwritingInfoAsync();

    }

    [Given(@"^I answer General UW Questions$")]
    [When(@"^I answer General UW Questions$")]
    [Then(@"^I answer General UW Questions$")]
    public async Task AnswerGeneralUWQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickGeneralUWQuestionsBFB08Async();
        await page.WaitForGeneralUWQuestions55852Async("Exists");
        await page.ClickUpdateAnswersAsync();

    }

    [Given(@"^I answer General Liability History Questions$")]
    [When(@"^I answer General Liability History Questions$")]
    [Then(@"^I answer General Liability History Questions$")]
    public async Task AnswerGeneralLiabilityHistoryQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickCommercialGeneralLiabilityHistoryE02F8Async();
        await page.WaitForCommercialGeneralLiabilityHistoryC65BFAsync("Exists");
        await page.EnterIsThereAPriorCarrierA9EB5Async(data.Resolve("{{data:is_there_a_prior_carrier_625}}"));
        // v56 suppressed redundant Tosca keyboard steering: IsThereAPriorCarrierA9EB5 CLICK
        // v56 suppressed redundant Tosca keyboard steering: IsThereAPriorCarrierA9EB5 Tab

    }

    [Given(@"^I answer Commercial Property History Questions$")]
    [When(@"^I answer Commercial Property History Questions$")]
    [Then(@"^I answer Commercial Property History Questions$")]
    public async Task AnswerCommercialPropertyHistoryQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickCommercialPropertyHistoryE6A7FAsync();
        await page.WaitForCommercialPropertyHistory76D22Async("Exists");
        await page.EnterIsThereAPriorCarrier5D30EAsync(data.Resolve("{{data:is_there_a_prior_carrier_628}}"));
        // v56 suppressed redundant Tosca keyboard steering: IsThereAPriorCarrier5D30E CLICK
        // v56 suppressed redundant Tosca keyboard steering: IsThereAPriorCarrier5D30E Tab

    }

    [Given(@"^I answer Other Insurance History Questions$")]
    [When(@"^I answer Other Insurance History Questions$")]
    [Then(@"^I answer Other Insurance History Questions$")]
    public async Task AnswerOtherInsuranceHistoryQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickOtherInsuranceHistory5AFD8Async();
        await page.WaitForOtherInsuranceHistory416B1Async("Exists");
        await page.EnterIsThereAPriorCarrierEFB4FAsync(data.Resolve("{{data:is_there_a_prior_carrier_631}}"));
        // v56 suppressed redundant Tosca keyboard steering: IsThereAPriorCarrierEFB4F CLICK
        // v56 suppressed redundant Tosca keyboard steering: IsThereAPriorCarrierEFB4F Tab

    }

    [Given(@"^I navigate back to CPP Main$")]
    [When(@"^I navigate back to CPP Main$")]
    [Then(@"^I navigate back to CPP Main$")]
    public async Task NavigateBackToCPPMainAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickReturnToQuoteAsync();

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
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_635}}"));
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_638}}"));
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_642}}"));
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
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_653}}"));
        // v56 suppressed redundant Tosca keyboard steering: IsThisCoverageBound CLICK
        // v56 suppressed redundant Tosca keyboard steering: IsThisCoverageBound Tab
        await page.VerifyOrderAuditAsync("Exists", "");
        await page.EnterOrderAuditAsync(data.Resolve("{{data:order_audit_655}}"));
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
        await page.VerifyIsThisCoverageBoundAsync(data.Resolve("{{data:expected_is_this_coverage_bound_value_663}}"), "Value");
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_664}}"));
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
        await page.VerifyFullTermPremiumAsync(data.Resolve("{{data:expected_full_term_premium_value_696}}"), "value");
        await page.VerifyPremiumWrittenAsync(data.Resolve("{{data:expected_premium_written_value_697}}"), "value");
        await page.VerifyPriorPremiumAsync(data.Resolve("{{data:expected_prior_premium_value_698}}"), "value");
        await page.VerifyPremiumChangeAsync(data.Resolve("{{data:expected_premium_change_value_699}}"), "value");
        await page.EnterTitleAsync(data.Resolve("{{data:title_701}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_702}}"));
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
        await page.VerifyStatusCodeAsync(data.Resolve("{{data:expected_statuscode_value_706}}"), "value");
        await page.PauseAsync(1000);
        await page.PauseAsync(1000);

    }

}
