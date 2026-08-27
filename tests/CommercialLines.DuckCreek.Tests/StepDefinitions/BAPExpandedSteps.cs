using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "BAP Expanded")]
public sealed class BAPExpandedSteps
{
    private readonly ScenarioContext _scenario;
    public BAPExpandedSteps(ScenarioContext scenario) => _scenario = scenario;

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
        await page.EnterEnterSSN6B3FBAsync(data.Resolve("{{runtime:InsuredSSN}}"));
        data.Set("Last4SSN", data.Get("InsuredSSN").Length >= 4 ? data.Get("InsuredSSN")[^4..] : data.Get("InsuredSSN"));
        // v56 suppressed redundant Tosca keyboard steering: EnterSSN6B3FB TAB
        // v56 suppressed redundant Tosca keyboard steering: EnterSSN6B3FB Enter
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
                    // v56 suppressed redundant Tosca keyboard steering: NameOfAuditContact CLICK
                    // v56 suppressed redundant Tosca keyboard steering: NameOfAuditContact Tab
        }
        // Source step 0048: RANDOM input for Audit Telephone #.
        if (data.Condition("'Product (LOB)' != \"UMB\""))
        {
            await page.EnterAuditTelephoneAsync(data.Resolve("{{runtime:AuditTelephone_0048}}"));
        }
        await page.EnterNameOfInspectionContactAsync(data.Resolve("{{data:name_of_inspection_contact_35}}"));
        // v56 suppressed redundant Tosca keyboard steering: NameOfInspectionContact CLICK
        // v56 suppressed redundant Tosca keyboard steering: NameOfInspectionContact Tab
        // Source step 0048: RANDOM input for Inspection Telephone #.
        await page.EnterInspectionTelephoneAsync(data.Resolve("{{runtime:InspectionTelephone_0048}}"));
        await page.EnterInsuredEMailAddressAsync(data.Resolve("{{data:insured_e_mail_address_37}}"));
        // v56 suppressed redundant Tosca keyboard steering: InsuredEMailAddress CLICK
        // v56 suppressed redundant Tosca keyboard steering: InsuredEMailAddress Tab
        await page.EnterWebsiteAddressAsync(data.Resolve("{{data:website_address_38}}"));
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Address2
        await page.VerifyZipCode26D22Async("[0-9]{5}-[0-9]{4}", "Regex:value");
        data.Set("State", data.Resolve("{{data:state}}"));
        data.Set("Product (LOB)", data.Resolve("{{data:product_lob}}"));

    }

    [Given(@"^I add Third Party Designee$")]
    [When(@"^I add Third Party Designee$")]
    [Then(@"^I add Third Party Designee$")]
    public async Task AddThirdPartyDesigneeAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("AdditionalOtherInterestInputLastName_0055", "^[a-z]{15}$");

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyClient070F4Async("Absent", "");
        await page.ClickClient35F85Async();
        await page.PauseAsync(1000);
        await page.ClickThirdPartyDesigneeAsync();
        await page.WaitForHeadingThirdPartyDesigneeAsync("Exists");
        await page.ClickAddThirdPartyAsync();
        await page.WaitForAdditionalOtherInterestInputFirstNameAsync("Exists");
        await page.EnterAdditionalOtherInterestInputFirstNameAsync(data.Resolve("{{data:additionalotherinterestinput_firstname_52}}"));
        // v56 suppressed redundant Tosca keyboard steering: AdditionalOtherInterestInputFirstName CLICK
        await page.WaitForAdditionalOtherInterestInputLastNameAsync("Exists");
        await page.EnterAdditionalOtherInterestInputLastNameAsync(data.Resolve("{{runtime:AdditionalOtherInterestInputLastName_0055}}"));
        await page.EnterAdditionalOtherInterestInputAddress1Async(data.Resolve("{{data:additionalotherinterestinput_address1_55}}"));
        await page.EnterZipCodeBCEA0Async(data.Resolve("{{data:zip_code_56}}"));
        await page.ClickCommonOKAsync();
        await page.WaitForClient070F4Async("Exists");

    }

    [Given(@"^I add Additional Named Insured$")]
    [When(@"^I add Additional Named Insured$")]
    [Then(@"^I add Additional Named Insured$")]
    public async Task AddAdditionalNamedInsuredAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("AdditionalInsuredLastName_0062", "^[a-z]{15}$");
        data.GenerateRandom("InsuredSSN", "025[0-9]{6}");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyClient070F4Async("Absent", "");
        await page.ClickClient35F85Async();
        await page.ClickAdditionalNamedInsuredAsync();
        await page.WaitForAdditionalNamedInsuredHeadingAsync("Exists");
        await page.ClickAddNamedInsuredIndividualAsync();
        await page.WaitForAdditionalInsuredFirstNameAsync("Exists");
        await page.EnterAdditionalInsuredFirstNameAsync(data.Resolve("{{runtime:AdditionalInsuredLastName_0062}}"));
        await page.EnterAdditionalInsuredFirstNameAsync(data.Resolve("{{data:additional_insured_first_name_65}}"));
        await page.EnterAdditionalInsuredMiddleNameAsync(data.Resolve("{{data:additional_insured_middle_name_66}}"));
        await page.ClickDetail704E6Async();
        await page.WaitForAddress1CB379Async("Exists");
        await page.EnterAddress1CB379Async(data.Resolve("{{data:address_1_70}}"));
        await page.EnterZipCodeD2A54Async(data.Resolve("{{data:zip_code_71}}"));
        await page.EnterDateOfBirthEA1C4Async(data.Resolve("{{data:date_of_birth_72}}"));
        // v56 suppressed redundant Tosca keyboard steering: DateOfBirthEA1C4 CLICK
        // v56 suppressed redundant Tosca keyboard steering: DateOfBirthEA1C4 Tab
        await page.ClickClientSearch2CB16Async();
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
        await page.ClickOrderSSN710BFAsync();
        await page.WaitForSSNWasNotReturnedAsync("Exists");
        // Source step 0044: RANDOM input for Enter SSN.
        await page.EnterEnterSSNFA186Async(data.Resolve("{{runtime:InsuredSSN}}"));
        await page.WaitForEnterSSNE3801Async("Exists");
        await page.ClickEnterSSNE3801Async();
        await page.PressEnterSSNE3801Async("Doubleclick");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets EnterSSNE3801
        await page.ClickVerify34721Async();
        await page.WaitForVerify34721Async("Absent");
        await page.WaitForPleaseVerifySSN8D55BAsync("Absent");
        await page.ClickIndividualOKAsync();
        await page.WaitForReturnToClientAsync("Exists");
        await page.ClickReturnToClientAsync();
        await page.WaitForClient070F4Async("Exists");
        await page.EnterTitleAsync(data.Resolve("{{data:title_88}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_89}}"));
        await page.VerifyResultAsync(data.Resolve("{{data:expected_result_value_90}}"), "value");

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
        await page.EnterEffectiveDate95094Async(data.Resolve("{{data:effectivedate_94}}"));
        if (data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
                    await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_95}}"));
        }
        await page.PauseAsync(1000);
        if (data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_97}}"));
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
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_101}}"));
        if (data.Condition("'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"BAP\""))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_103}}"));
        }
        if (data.Condition("'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"UMB\" || 'Product (LOB)' == \"BAP\""))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_104}}"));
                    await page.PressPrimaryRatingStateAsync("Down");
                    // v56 suppressed redundant Tosca keyboard steering: PrimaryRatingState Enter
                    // v56 suppressed redundant Tosca keyboard steering: PrimaryRatingState Tab
        }
        if (data.Condition("'Product (LOB)' == \"BAP\""))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_106}}"));
        }
        if (data.Condition("'Product (LOB)' == \"BAP\""))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_107}}"));
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
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_111}}"));
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
        await page.EnterDescriptionOfSpecifiedOperationAsync("AL BAP StraightThrough {NMONTH}.{NDAY}.{NYEAR} {Time}");
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
        await page.EnterNAICSCodeSearchValueAsync(data.Resolve("{{data:naics_code_search_value_122}}"));
        // v56 suppressed redundant Tosca keyboard steering: NAICSCodeSearchValue CLICK
        // v56 suppressed redundant Tosca keyboard steering: NAICSCodeSearchValue Tab
        await page.PauseAsync(1000);
        await page.EnterNAICSCodeSearchResultsAsync(data.Resolve("{{data:naics_code_search_results_124}}"));
        // v56 suppressed redundant Tosca keyboard steering: NAICSCodeSearchResults CLICK
        // v56 suppressed redundant Tosca keyboard steering: NAICSCodeSearchResults Tab
        await page.PauseAsync(1000);
        if (data.Condition("State != \"NY\""))
        {
                    await page.EnterAccountCreditAsync(data.Resolve("{{data:account_credit_126}}"));
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
        await page.VerifyReferenceNumberAsync(data.Resolve("{{data:expected_reference_number_innertext_139}}"), "InnerText");
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
        await page.SetNoKnownLossesAsync(data.Resolve("{{data:no_known_losses_144}}"));
        await page.VerifyNoKnownLossesAsync(data.Resolve("{{data:expected_no_known_losses_value_145}}"), "value");
        await page.PauseAsync(1000);
        await page.ClickInsuranceHistoryAsync();
        await page.WaitForIsThereAPriorCarrierAsync("Exists");
        await page.EnterIsThereAPriorCarrierAsync(data.Resolve("{{data:is_there_a_prior_carrier_149}}"));
        await page.ClickIsThereAPriorCarrierAsync();
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets IsThereAPriorCarrier
        await page.EnterCarrierAsync(data.Resolve("{{data:carrier_152}}"));
        await page.EnterPolicyNumberAsync(data.Resolve("{{data:policy_number_153}}"));
        await page.EnterPolicyTypeAsync(data.Resolve("{{data:policy_type_154}}"));
        await page.EnterEffectiveDateAsync(data.Resolve("{DATE[][-2y][MM'/'dd'/'yyyy]}"));
        await page.EnterExpirationDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.EnterModificationFactorAsync(data.Resolve("{{data:modificationfactor_157}}"));
        await page.EnterTotalPremiumAsync(data.Resolve("{{data:total_premium_158}}"));
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
        await page.EnterTrailerInterchangeCompDeductibleAsync(data.Resolve("{{data:trailer_interchange_comp_deductible_166}}"));
        // v56 suppressed redundant Tosca keyboard steering: TrailerInterchangeCompDeductible Click
        // v56 suppressed redundant Tosca keyboard steering: TrailerInterchangeCompDeductible Enter
        // v56 suppressed redundant Tosca keyboard steering: TrailerInterchangeCompDeductible Tab
        await page.EnterTrailerInterchangeCollisionDeductibleAsync(data.Resolve("{{data:trailer_interchange_collision_deductible_167}}"));
        // v56 suppressed redundant Tosca keyboard steering: TrailerInterchangeCollisionDeductible Click
        // v56 suppressed redundant Tosca keyboard steering: TrailerInterchangeCollisionDeductible Enter
        // v56 suppressed redundant Tosca keyboard steering: TrailerInterchangeCollisionDeductible Tab
        await page.WaitForPolicyCovg26786Async("Exists");

    }

    [Given(@"^I complete cT StraightThrough Liability Limit to 1M$")]
    [When(@"^I complete cT StraightThrough Liability Limit to 1M$")]
    [Then(@"^I complete cT StraightThrough Liability Limit to 1M$")]
    public async Task CompleteCTStraightThroughLiabilityLimitTo1MAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyCTStraightThroughLiabilityLimitTo1MAsync("Exists", "");

    }

    [Given(@"^I add NonOwnership Liability$")]
    [When(@"^I add NonOwnership Liability$")]
    [Then(@"^I add NonOwnership Liability$")]
    public async Task AddNonOwnershipLiabilityAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyPolicyCovg26786Async("Absent", "");
        await page.ClickPolicyCovgerageAsync();
        await page.EnterNonOwnedAutoAsync(data.Resolve("{{data:non_owned_auto_172}}"));
        // v56 suppressed redundant Tosca keyboard steering: NonOwnedAuto Click
        // v56 suppressed redundant Tosca keyboard steering: NonOwnedAuto Tab
        await page.WaitForOfEmployeesAsync("Exists");
        await page.EnterOfEmployeesAsync(data.Resolve("{{data:of_employees_174}}"));
        await page.EnterOfPartnersAsync(data.Resolve("{{data:of_partners_175}}"));
        await page.EnterExtendedEmployeeCoverageAsync(data.Resolve("{{data:extended_employee_coverage_176}}"));
        // v56 suppressed redundant Tosca keyboard steering: ExtendedEmployeeCoverage Click
        // v56 suppressed redundant Tosca keyboard steering: ExtendedEmployeeCoverage Tab
        await page.PauseAsync(1000);

    }

    [Given(@"^I add Business Interruption$")]
    [When(@"^I add Business Interruption$")]
    [Then(@"^I add Business Interruption$")]
    public async Task AddBusinessInterruptionAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyPolicyCovg26786Async("Absent", "");
        await page.ClickPolicyCovgerageAsync();
        await page.EnterBusinessInterruptionEndorsementAsync(data.Resolve("{{data:business_interruption_endorsement_180}}"));
        // v56 suppressed redundant Tosca keyboard steering: BusinessInterruptionEndorsement Click
        // v56 suppressed redundant Tosca keyboard steering: BusinessInterruptionEndorsement Tab
        await page.WaitForDetail4A746Async("Exists");
        await page.ClickDetail4A746Async();
        await page.WaitForBusinessInterruptionDetailAsync("Exists");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets DescriptionOfBusinessActivites
        await page.ClickOptionACheckBoxAsync();
        await page.WaitForOptionAScheduleButtonAsync("Exists");
        await page.EnterDescriptionOfBusinessActivitesAsync(data.Resolve("{{data:description_of_business_activites_187}}"));
        await page.ClickOptionAScheduleButtonAsync();
        await page.WaitForOptionAAsync("Exists");
        await page.ClickAddOptionAAsync();
        await page.WaitForBusinessInterruptionLimitOfInsuranceAsync("Exists");
        await page.EnterBusinessInterruptionLimitOfInsuranceAsync(data.Resolve("{{data:iframe_duck_creek_policy_business_interruption_limit_of_insurance_192}}"));
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets BusinessInterruptionDescriptionOfScheduledProperty
        await page.EnterBusinessInterruptionDescriptionOfScheduledPropertyAsync(data.Resolve("{{data:iframe_duck_creek_policy_business_interruption_description_of_scheduledproperty_194}}"));
        await page.ClickOKAsync();
        await page.PauseAsync(1000);
        await page.VerifyIFRAME280B0Async("Exists", "");
        await page.WaitForIFRAME280B0Async("Absent");
        await page.ClickBusinessInterruptionOKAsync();
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

    [Given(@"^I add UM/UIM Coverage$")]
    [When(@"^I add UM/UIM Coverage$")]
    [Then(@"^I add UM/UIM Coverage$")]
    public async Task AddUMUIMCoverageAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickStateDetails33183Async();
        await page.WaitForStateDetailsDetailAsync("Exists");
        await page.ClickStateDetailsDetailAsync();
        await page.WaitForStateDetailsDetailAsync("Absent");
        await page.WaitForUMUIMOKAsync("Visible");
        await page.WaitForStateDetails72631Async("Exists");
        if (data.Condition("'UM Type Default' != NULL"))
        {
                    await page.EnterUMTypeDefaultSelectionsAsync(data.Resolve("{{data:um_type_default_selections_211}}"));
                    // v56 suppressed redundant Tosca keyboard steering: UMTypeDefaultSelections CLICK
                    await page.PressUMTypeDefaultSelectionsAsync("RETURN");
                    // v56 suppressed redundant Tosca keyboard steering: UMTypeDefaultSelections Tab
        }
        if (data.Condition("'UMBI Limit' != NULL AND 'UM Type Default' != \"UMBIPD CSL\""))
        {
                    await page.EnterUMBILimitAsync(data.Resolve("{{data:umbi_limit_212}}"));
                    // v56 suppressed redundant Tosca keyboard steering: UMBILimit CLICK
                    // v56 suppressed redundant Tosca keyboard steering: UMBILimit Tab
        }
        await page.WaitForStateDetails72631Async("Exists");
        await page.VerifyUMUIMOKAsync("Exists", "");
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.ClickUMUIMOKAsync();
        await page.WaitForStateDetailsDetailAsync("Exists");

    }

    [Given(@"^I add Policy Level Coverages$")]
    [When(@"^I add Policy Level Coverages$")]
    [Then(@"^I add Policy Level Coverages$")]
    public async Task AddPolicyLevelCoveragesAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickStateDetails33183Async();
        await page.WaitForStateDetailsDetailAsync("Exists");
        await page.ClickStateDetailsDetailAsync();
        await page.WaitForStateDetailsDetailAsync("Absent");
        await page.WaitForUMUIMOKAsync("Visible");
        await page.ClickHiredAutoLiabilityAsync();
        await page.ClickPrimaryLiabilityIfAnyAsync();
        await page.ClickExcessLiabilityIfAnyAsync();
        await page.ClickEmployeeHiredAutosCheckBoxAsync();
        await page.ClickVolunteerHiredAutosCheckBoxAsync();
        await page.PauseAsync(1000);
        await page.ClickDriveOtherCarAsync();
        await page.ClickComprehensiveAsync();
        await page.WaitForOTCDeductibleE0D59Async("Exists");
        await page.ClickCollisionAsync();
        await page.WaitForCollisionDeductible63D4CAsync("Exists");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets FirstName5059E
        await page.EnterLastName5E149Async(data.Resolve("{{data:last_name_236}}"));
        await page.EnterFirstName5059EAsync(data.Resolve("{{data:first_name_237}}"));
        await page.PauseAsync(1000);
        await page.ClickHiredAutoPhysicalDamageWithoutDriverAsync();
        await page.EnterOTCDeductibleEF1DEAsync(data.Resolve("{{data:otc_deductible_240}}"));
        // v56 suppressed redundant Tosca keyboard steering: OTCDeductibleEF1DE Click
        // v56 suppressed redundant Tosca keyboard steering: OTCDeductibleEF1DE Tab
        await page.ClickOTCIfAny4EFEEAsync();
        await page.EnterCollisionDeductible9C100Async(data.Resolve("{{data:collision_deductible_242}}"));
        await page.ClickCollisionIfAny7532DAsync();
        await page.PauseAsync(1000);
        await page.ClickHiredAutoPhysicalDamageWithDriverAsync();
        await page.EnterOTCDeductible62C21Async(data.Resolve("{{data:otc_deductible_246}}"));
        // v56 suppressed redundant Tosca keyboard steering: OTCDeductible62C21 Click
        // v56 suppressed redundant Tosca keyboard steering: OTCDeductible62C21 Tab
        await page.ClickOTCIfAny6A58BAsync();
        await page.EnterCollisionDeductibleAEEBBAsync(data.Resolve("{{data:collision_deductible_248}}"));
        // v56 suppressed redundant Tosca keyboard steering: CollisionDeductibleAEEBB CLICK
        // v56 suppressed redundant Tosca keyboard steering: CollisionDeductibleAEEBB Enter
        // v56 suppressed redundant Tosca keyboard steering: CollisionDeductibleAEEBB Tab
        await page.ClickCollisionIfAny8AEE8Async();
        await page.EnterVehicleInformationAsync(data.Resolve("{{data:vehicle_information_250}}"));
        await page.PauseAsync(1000);
        await page.ClickUMUIMOKAsync();
        await page.VerifyLoadingMessageAsync("Exists", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.PauseAsync(1000);
        await page.WaitForStateDetailsDetailAsync("Visible");

    }

    [Given(@"^I add a Risk$")]
    [When(@"^I add a Risk$")]
    [Then(@"^I add a Risk$")]
    public async Task AddARiskAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyRiskDDE70Async("Absent", "");
        await page.WaitForRiskScheduleAsync("Exists");
        await page.ClickRiskScheduleAsync();
        await page.WaitForRiskDDE70Async("Exists");
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.WaitForShowAllLocationsAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_264}}"));
        await page.WaitForVehicleTypeAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_266}}"));
        // v56 suppressed redundant Tosca keyboard steering: VehicleType CLICK
        // v56 suppressed redundant Tosca keyboard steering: VehicleType Tab
        await page.VerifyVehicleTypeAsync(data.Resolve("{{data:expected_vehicle_type_value_267}}"), "value");
        await page.ClickAddRiskAtThisLocationAsync();
        await page.WaitForCommercialAutoRiskDetailAsync("Exists");
        if (data.Condition("VIN != NULL"))
        {
                    await page.WaitForVINAsync("Visible");
        }
        if (data.Condition("Year != NULL"))
        {
                    await page.EnterYearAsync("");
        }
        if (data.Condition("Make != NULL"))
        {
                    await page.EnterMakeAsync("");
        }
        if (data.Condition("Model != NULL"))
        {
                    await page.EnterModelAsync("");
        }
        if (data.Condition("VIN != NULL"))
        {
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets VIN
        }
        if (data.Condition("VIN != NULL"))
        {
                    await page.EnterVINAsync(data.Resolve("{{data:vin_275}}"));
        }
        if (data.Condition("Snowplow != NULL"))
        {
                    await page.VerifyIsThisVehicleUsedInSnowPlowOperationsAsync("Exists", "");
        }
        if (data.Condition("Snowplow != NULL"))
        {
                    await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync(data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_278}}"));
                    // v56 suppressed redundant Tosca keyboard steering: IsThisVehicleUsedInSnowPlowOperations Click
                    // v56 suppressed redundant Tosca keyboard steering: IsThisVehicleUsedInSnowPlowOperations Enter
                    // v56 suppressed redundant Tosca keyboard steering: IsThisVehicleUsedInSnowPlowOperations Tab
        }
        if (data.Condition("GCW != NULL"))
        {
                    await page.EnterGCWAsync("");
        }
        if (data.Condition("Snowplow != NULL"))
        {
                    await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync("");
        }
        await page.VerifyCollisionCoverageAsync("Exists", "");
        if (data.Condition("'Collision Coverage' == NULL"))
        {
                    await page.EnterCollisionCoverageAsync(data.Resolve("{{data:collision_coverage_286}}"));
        }
        await page.ClickPhysicalDamageOKAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.PauseAsync(1000);
        await page.VerifyRiskDDE70Async("Absent", "");
        await page.WaitForRiskScheduleAsync("Exists");
        await page.ClickRiskScheduleAsync();
        await page.WaitForRiskDDE70Async("Exists");
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.WaitForShowAllLocationsAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_298}}"));
        await page.WaitForVehicleTypeAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_300}}"));
        // v56 suppressed redundant Tosca keyboard steering: VehicleType CLICK
        // v56 suppressed redundant Tosca keyboard steering: VehicleType Tab
        await page.VerifyVehicleTypeAsync(data.Resolve("{{data:expected_vehicle_type_value_301}}"), "value");
        await page.ClickAddRiskAtThisLocationAsync();
        await page.WaitForCommercialAutoRiskDetailAsync("Exists");
        if (data.Condition("VIN != NULL"))
        {
                    await page.WaitForVINAsync("Visible");
        }
        if (data.Condition("Year != NULL"))
        {
                    await page.EnterYearAsync("");
        }
        if (data.Condition("Make != NULL"))
        {
                    await page.EnterMakeAsync("");
        }
        if (data.Condition("Model != NULL"))
        {
                    await page.EnterModelAsync("");
        }
        if (data.Condition("VIN != NULL"))
        {
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets VIN
        }
        if (data.Condition("VIN != NULL"))
        {
                    await page.EnterVINAsync(data.Resolve("{{data:vin_309}}"));
        }
        if (data.Condition("Snowplow != NULL"))
        {
                    await page.VerifyIsThisVehicleUsedInSnowPlowOperationsAsync("Exists", "");
        }
        if (data.Condition("Snowplow != NULL"))
        {
                    await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync(data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_312}}"));
                    // v56 suppressed redundant Tosca keyboard steering: IsThisVehicleUsedInSnowPlowOperations Click
                    // v56 suppressed redundant Tosca keyboard steering: IsThisVehicleUsedInSnowPlowOperations Enter
                    // v56 suppressed redundant Tosca keyboard steering: IsThisVehicleUsedInSnowPlowOperations Tab
        }
        if (data.Condition("GCW != NULL"))
        {
                    await page.EnterGCWAsync("");
        }
        if (data.Condition("Snowplow != NULL"))
        {
                    await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync(data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_315}}"));
                    // v56 suppressed redundant Tosca keyboard steering: IsThisVehicleUsedInSnowPlowOperations Click
                    // v56 suppressed redundant Tosca keyboard steering: IsThisVehicleUsedInSnowPlowOperations Enter
                    // v56 suppressed redundant Tosca keyboard steering: IsThisVehicleUsedInSnowPlowOperations Tab
        }
        if (data.Condition("'OTC Causes of Loss' != NULL"))
        {
                    await page.EnterOTCCausesOfLossAsync(data.Resolve("{{data:otc_causes_of_loss_316}}"));
                    // v56 suppressed redundant Tosca keyboard steering: OTCCausesOfLoss CLICK
                    // v56 suppressed redundant Tosca keyboard steering: OTCCausesOfLoss Tab
        }
        await page.VerifyCollisionCoverageAsync("Exists", "");
        if (data.Condition("'Collision Coverage' == NULL"))
        {
                    await page.EnterCollisionCoverageAsync(data.Resolve("{{data:collision_coverage_321}}"));
        }
        await page.ClickPhysicalDamageOKAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.PauseAsync(1000);
        await page.VerifyRiskDDE70Async("Absent", "");
        await page.WaitForRiskScheduleAsync("Exists");
        await page.ClickRiskScheduleAsync();
        await page.WaitForRiskDDE70Async("Exists");
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.WaitForShowAllLocationsAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_333}}"));
        await page.WaitForVehicleTypeAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_335}}"));
        // v56 suppressed redundant Tosca keyboard steering: VehicleType CLICK
        // v56 suppressed redundant Tosca keyboard steering: VehicleType Tab
        await page.VerifyVehicleTypeAsync(data.Resolve("{{data:expected_vehicle_type_value_336}}"), "value");
        await page.ClickAddRiskAtThisLocationAsync();
        await page.WaitForCommercialAutoRiskDetailAsync("Exists");
        if (data.Condition("VIN != NULL"))
        {
                    await page.WaitForVINAsync("Visible");
        }
        if (data.Condition("Year != NULL"))
        {
                    await page.EnterYearAsync("");
        }
        if (data.Condition("Make != NULL"))
        {
                    await page.EnterMakeAsync("");
        }
        if (data.Condition("Model != NULL"))
        {
                    await page.EnterModelAsync("");
        }
        if (data.Condition("VIN != NULL"))
        {
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets VIN
        }
        if (data.Condition("VIN != NULL"))
        {
                    await page.EnterVINAsync(data.Resolve("{{data:vin_344}}"));
        }
        if (data.Condition("Snowplow != NULL"))
        {
                    await page.VerifyIsThisVehicleUsedInSnowPlowOperationsAsync("Exists", "");
        }
        if (data.Condition("Snowplow != NULL"))
        {
                    await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync(data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_347}}"));
                    // v56 suppressed redundant Tosca keyboard steering: IsThisVehicleUsedInSnowPlowOperations Click
                    // v56 suppressed redundant Tosca keyboard steering: IsThisVehicleUsedInSnowPlowOperations Enter
                    // v56 suppressed redundant Tosca keyboard steering: IsThisVehicleUsedInSnowPlowOperations Tab
        }
        if (data.Condition("GCW != NULL"))
        {
                    await page.EnterGCWAsync(data.Resolve("{{data:gcw_349}}"));
                    // v56 suppressed redundant Tosca keyboard steering: GCW Click
                    // v56 suppressed redundant Tosca keyboard steering: GCW Enter
                    // v56 suppressed redundant Tosca keyboard steering: GCW Tab
        }
        if (data.Condition("Snowplow != NULL"))
        {
                    await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync("");
        }
        await page.VerifyCollisionCoverageAsync("Exists", "");
        if (data.Condition("'Collision Coverage' == NULL"))
        {
                    await page.EnterCollisionCoverageAsync(data.Resolve("{{data:collision_coverage_355}}"));
        }
        await page.ClickPhysicalDamageOKAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.PauseAsync(1000);
        await page.VerifyRiskDDE70Async("Absent", "");
        await page.WaitForRiskScheduleAsync("Exists");
        await page.ClickRiskScheduleAsync();
        await page.WaitForRiskDDE70Async("Exists");
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.WaitForShowAllLocationsAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_367}}"));
        await page.WaitForVehicleTypeAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_369}}"));
        // v56 suppressed redundant Tosca keyboard steering: VehicleType CLICK
        // v56 suppressed redundant Tosca keyboard steering: VehicleType Tab
        await page.VerifyVehicleTypeAsync(data.Resolve("{{data:expected_vehicle_type_value_370}}"), "value");
        await page.ClickAddRiskAtThisLocationAsync();
        await page.WaitForCommercialAutoRiskDetailAsync("Exists");
        if (data.Condition("VIN != NULL"))
        {
                    await page.WaitForVINAsync("Visible");
        }
        if (data.Condition("Year != NULL"))
        {
                    await page.EnterYearAsync("");
        }
        if (data.Condition("Make != NULL"))
        {
                    await page.EnterMakeAsync("");
        }
        if (data.Condition("Model != NULL"))
        {
                    await page.EnterModelAsync("");
        }
        if (data.Condition("'Value Basis' != NULL"))
        {
                    await page.EnterValueBasisAsync(data.Resolve("{{data:value_basis_377}}"));
                    // v56 suppressed redundant Tosca keyboard steering: ValueBasis Click
                    // v56 suppressed redundant Tosca keyboard steering: ValueBasis Tab
        }
        if (data.Condition("'Original Cost New' != NULL"))
        {
                    await page.EnterOriginalCostNewAsync(data.Resolve("{{data:original_cost_new_378}}"));
                    // v56 suppressed redundant Tosca keyboard steering: OriginalCostNew CLICK
                    // v56 suppressed redundant Tosca keyboard steering: OriginalCostNew Tab
        }
        if (data.Condition("VIN != NULL"))
        {
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets VIN
        }
        if (data.Condition("VIN != NULL"))
        {
                    await page.EnterVINAsync(data.Resolve("{{data:vin_380}}"));
        }
        if (data.Condition("Snowplow != NULL"))
        {
                    await page.VerifyIsThisVehicleUsedInSnowPlowOperationsAsync("Exists", "");
        }
        if (data.Condition("Snowplow != NULL"))
        {
                    await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync(data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_383}}"));
                    // v56 suppressed redundant Tosca keyboard steering: IsThisVehicleUsedInSnowPlowOperations Click
                    // v56 suppressed redundant Tosca keyboard steering: IsThisVehicleUsedInSnowPlowOperations Enter
                    // v56 suppressed redundant Tosca keyboard steering: IsThisVehicleUsedInSnowPlowOperations Tab
        }
        if (data.Condition("'Used as Showroom' != NULL"))
        {
                    await page.EnterUsedAsShowroomAsync(data.Resolve("{{data:used_as_showroom_385}}"));
                    // v56 suppressed redundant Tosca keyboard steering: UsedAsShowroom CLICK
                    // v56 suppressed redundant Tosca keyboard steering: UsedAsShowroom Tab
        }
        if (data.Condition("'Used as Showroom' != NULL"))
        {
                    await page.EnterUsedAsShowroomAsync(data.Resolve("{{data:used_as_showroom_386}}"));
                    // v56 suppressed redundant Tosca keyboard steering: UsedAsShowroom CLICK
                    // v56 suppressed redundant Tosca keyboard steering: UsedAsShowroom Tab
        }
        if (data.Condition("GCW != NULL"))
        {
                    await page.EnterGCWAsync("");
        }
        if (data.Condition("Snowplow != NULL"))
        {
                    await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync("");
        }
        if (data.Condition("'2nd Class Category' != NULL"))
        {
                    await page.EnterN2ndClassCategoryAsync(data.Resolve("{{data:2nd_class_category_389}}"));
                    // v56 suppressed redundant Tosca keyboard steering: N2ndClassCategory Click
                    // v56 suppressed redundant Tosca keyboard steering: N2ndClassCategory Tab
        }
        if (data.Condition("'2nd Class Code' != NULL"))
        {
                    await page.EnterN2ndClassCodeAsync(data.Resolve("{{data:2nd_class_code_390}}"));
                    // v56 suppressed redundant Tosca keyboard steering: N2ndClassCode Click
                    // v56 suppressed redundant Tosca keyboard steering: N2ndClassCode Tab
        }
        await page.VerifyCollisionCoverageAsync("Exists", "");
        if (data.Condition("'Collision Coverage' == NULL"))
        {
                    await page.EnterCollisionCoverageAsync(data.Resolve("{{data:collision_coverage_395}}"));
        }
        await page.ClickPhysicalDamageOKAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.PauseAsync(1000);
        await page.VerifyRiskDDE70Async("Absent", "");
        await page.WaitForRiskScheduleAsync("Exists");
        await page.ClickRiskScheduleAsync();
        await page.WaitForRiskDDE70Async("Exists");
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.WaitForShowAllLocationsAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_407}}"));
        await page.WaitForVehicleTypeAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_409}}"));
        // v56 suppressed redundant Tosca keyboard steering: VehicleType CLICK
        // v56 suppressed redundant Tosca keyboard steering: VehicleType Tab
        await page.VerifyVehicleTypeAsync(data.Resolve("{{data:expected_vehicle_type_value_410}}"), "value");
        await page.ClickAddRiskAtThisLocationAsync();
        await page.WaitForCommercialAutoRiskDetailAsync("Exists");
        if (data.Condition("VIN != NULL"))
        {
                    await page.WaitForVINAsync("Visible");
        }
        if (data.Condition("Year != NULL"))
        {
                    await page.EnterYearAsync(data.Resolve("{{data:year_414}}"));
        }
        if (data.Condition("Make != NULL"))
        {
                    await page.EnterMakeAsync(data.Resolve("{{data:make_415}}"));
        }
        if (data.Condition("Model != NULL"))
        {
                    await page.EnterModelAsync(data.Resolve("{{data:model_416}}"));
        }
        if (data.Condition("'Body Style' != NULL"))
        {
                    await page.EnterBodyStyleAsync(data.Resolve("{{data:body_style_417}}"));
        }
        if (data.Condition("'Stated Amount' != NULL"))
        {
                    await page.EnterStatedAmountAsync(data.Resolve("{{data:stated_amount_418}}"));
        }
        if (data.Condition("VIN != NULL"))
        {
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets VIN
        }
        if (data.Condition("VIN != NULL"))
        {
                    await page.EnterVINAsync(data.Resolve("{{data:vin_420}}"));
        }
        if (data.Condition("Snowplow != NULL"))
        {
                    await page.VerifyIsThisVehicleUsedInSnowPlowOperationsAsync("Exists", "");
        }
        if (data.Condition("Snowplow != NULL"))
        {
                    await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync(data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_423}}"));
                    // v56 suppressed redundant Tosca keyboard steering: IsThisVehicleUsedInSnowPlowOperations Click
                    // v56 suppressed redundant Tosca keyboard steering: IsThisVehicleUsedInSnowPlowOperations Enter
                    // v56 suppressed redundant Tosca keyboard steering: IsThisVehicleUsedInSnowPlowOperations Tab
        }
        if (data.Condition("'Engine Size' != NULL"))
        {
                    await page.EnterEngineSizeCcAsync(data.Resolve("{{data:engine_size_cc_425}}"));
                    // v56 suppressed redundant Tosca keyboard steering: EngineSizeCc Click
                    // v56 suppressed redundant Tosca keyboard steering: EngineSizeCc Tab
        }
        if (data.Condition("'Engine Size' != NULL"))
        {
                    await page.EnterEngineSizeCcAsync(data.Resolve("{{data:engine_size_cc_426}}"));
                    // v56 suppressed redundant Tosca keyboard steering: EngineSizeCc Click
                    // v56 suppressed redundant Tosca keyboard steering: EngineSizeCc Tab
        }
        if (data.Condition("GCW != NULL"))
        {
                    await page.EnterGCWAsync("");
        }
        if (data.Condition("Snowplow != NULL"))
        {
                    await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync("");
        }
        await page.VerifyCollisionCoverageAsync("Exists", "");
        if (data.Condition("'Collision Coverage' == NULL"))
        {
                    await page.EnterCollisionCoverageAsync(data.Resolve("{{data:collision_coverage_433}}"));
        }
        await page.ClickPhysicalDamageOKAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.PauseAsync(1000);
        await page.VerifyRiskDDE70Async("Absent", "");
        await page.WaitForRiskScheduleAsync("Exists");
        await page.ClickRiskScheduleAsync();
        await page.WaitForRiskDDE70Async("Exists");
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.WaitForShowAllLocationsAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_445}}"));
        await page.WaitForVehicleTypeAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_447}}"));
        // v56 suppressed redundant Tosca keyboard steering: VehicleType CLICK
        // v56 suppressed redundant Tosca keyboard steering: VehicleType Tab
        await page.VerifyVehicleTypeAsync(data.Resolve("{{data:expected_vehicle_type_value_448}}"), "value");
        await page.ClickAddRiskAtThisLocationAsync();
        await page.WaitForCommercialAutoRiskDetailAsync("Exists");
        if (data.Condition("VIN != NULL"))
        {
                    await page.WaitForVINAsync("Visible");
        }
        if (data.Condition("Year != NULL"))
        {
                    await page.EnterYearAsync(data.Resolve("{{data:year_452}}"));
        }
        if (data.Condition("Make != NULL"))
        {
                    await page.EnterMakeAsync(data.Resolve("{{data:make_453}}"));
        }
        if (data.Condition("Model != NULL"))
        {
                    await page.EnterModelAsync(data.Resolve("{{data:model_454}}"));
        }
        if (data.Condition("'Body Style' != NULL"))
        {
                    await page.EnterBodyStyleAsync(data.Resolve("{{data:body_style_455}}"));
        }
        if (data.Condition("'Stated Amount' != NULL"))
        {
                    await page.EnterStatedAmountAsync(data.Resolve("{{data:stated_amount_456}}"));
        }
        if (data.Condition("VIN != NULL"))
        {
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets VIN
        }
        if (data.Condition("VIN != NULL"))
        {
                    await page.EnterVINAsync(data.Resolve("{{data:vin_458}}"));
        }
        if (data.Condition("Snowplow != NULL"))
        {
                    await page.VerifyIsThisVehicleUsedInSnowPlowOperationsAsync("Exists", "");
        }
        if (data.Condition("Snowplow != NULL"))
        {
                    await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync(data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_461}}"));
                    // v56 suppressed redundant Tosca keyboard steering: IsThisVehicleUsedInSnowPlowOperations Click
                    // v56 suppressed redundant Tosca keyboard steering: IsThisVehicleUsedInSnowPlowOperations Enter
                    // v56 suppressed redundant Tosca keyboard steering: IsThisVehicleUsedInSnowPlowOperations Tab
        }
        if (data.Condition("GCW != NULL"))
        {
                    await page.EnterGCWAsync("");
        }
        if (data.Condition("Snowplow != NULL"))
        {
                    await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync("");
        }
        await page.VerifyCollisionCoverageAsync("Exists", "");
        if (data.Condition("'Collision Coverage' == NULL"))
        {
                    await page.EnterCollisionCoverageAsync(data.Resolve("{{data:collision_coverage_469}}"));
        }
        await page.ClickPhysicalDamageOKAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.PauseAsync(1000);

    }

    [Given(@"^I add Risk Level Interest$")]
    [When(@"^I add Risk Level Interest$")]
    [Then(@"^I add Risk Level Interest$")]
    public async Task AddRiskLevelInterestAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickRiskScheduleAsync();
        await page.WaitForRiskDDE70Async("Exists");
        await page.VerifyTypeD972CAsync(data.Resolve("{{data:constraint_vehicle_schedule_1_type_476}}"), "InnerText");
        await page.ClickDetail1664BAsync();
        await page.WaitForCommercialAutoRiskDetailAsync("Exists");
        await page.EnterHiredAutoExtAddlInsuredAsync(data.Resolve("{{data:hired_auto_ext_addl_insured_480}}"));
        await page.VerifyHiredAutoExtAddlInsuredAsync(data.Resolve("{{data:expected_hired_auto_ext_addl_insured_value_481}}"), "value");
        await page.WaitForHiredAutoFormAsync("Exists");
        await page.EnterHiredAutoFormAsync(data.Resolve("{{data:hired_auto_form_483}}"));
        // v56 suppressed redundant Tosca keyboard steering: HiredAutoForm CLICK
        // v56 suppressed redundant Tosca keyboard steering: HiredAutoForm Enter
        // v56 suppressed redundant Tosca keyboard steering: HiredAutoForm Tab
        // v56 suppressed redundant Tosca keyboard steering: HiredAutoForm CLICK
        // v56 suppressed redundant Tosca keyboard steering: HiredAutoForm Tab
        await page.WaitForHiredAutoFormAsync("NotEqual");
        await page.WaitForHiredAutoOKAsync("Absent");
        await page.ClickPhysicalDamageOKAsync();
        await page.WaitForRiskDDE70Async("Exists");
        await page.ClickRiskScheduleAsync();
        await page.WaitForRiskDDE70Async("Exists");
        await page.VerifyTypeD972CAsync(data.Resolve("{{data:constraint_vehicle_schedule_1_type_490}}"), "InnerText");
        await page.ClickDetail1664BAsync();
        await page.WaitForCommercialAutoRiskDetailAsync("Exists");
        await page.EnterHiredAutoExtAddlInsuredAsync(data.Resolve("{{data:hired_auto_ext_addl_insured_494}}"));
        await page.VerifyHiredAutoExtAddlInsuredAsync(data.Resolve("{{data:expected_hired_auto_ext_addl_insured_value_495}}"), "value");
        await page.WaitForHiredAutoFormAsync("Exists");
        await page.EnterHiredAutoFormAsync(data.Resolve("{{data:hired_auto_form_497}}"));
        // v56 suppressed redundant Tosca keyboard steering: HiredAutoForm CLICK
        // v56 suppressed redundant Tosca keyboard steering: HiredAutoForm Enter
        // v56 suppressed redundant Tosca keyboard steering: HiredAutoForm Tab
        // v56 suppressed redundant Tosca keyboard steering: HiredAutoForm CLICK
        // v56 suppressed redundant Tosca keyboard steering: HiredAutoForm Tab
        await page.WaitForHiredAutoFormAsync("NotEqual");
        await page.WaitForHiredAutoOKAsync("Absent");
        await page.ClickPhysicalDamageOKAsync();
        await page.WaitForRiskDDE70Async("Exists");
        await page.ClickRiskScheduleAsync();
        await page.WaitForRiskDDE70Async("Exists");
        await page.VerifyTypeD972CAsync(data.Resolve("{{data:constraint_vehicle_schedule_1_type_504}}"), "InnerText");
        await page.ClickDetail1664BAsync();
        await page.WaitForCommercialAutoRiskDetailAsync("Exists");
        await page.EnterHiredAutoExtAddlInsuredAsync(data.Resolve("{{data:hired_auto_ext_addl_insured_508}}"));
        await page.VerifyHiredAutoExtAddlInsuredAsync(data.Resolve("{{data:expected_hired_auto_ext_addl_insured_value_509}}"), "value");
        await page.WaitForHiredAutoFormAsync("Exists");
        await page.EnterHiredAutoFormAsync(data.Resolve("{{data:hired_auto_form_511}}"));
        // v56 suppressed redundant Tosca keyboard steering: HiredAutoForm CLICK
        // v56 suppressed redundant Tosca keyboard steering: HiredAutoForm Enter
        // v56 suppressed redundant Tosca keyboard steering: HiredAutoForm Tab
        // v56 suppressed redundant Tosca keyboard steering: HiredAutoForm CLICK
        // v56 suppressed redundant Tosca keyboard steering: HiredAutoForm Tab
        await page.WaitForHiredAutoFormAsync("NotEqual");
        if (data.Condition("'First Name' != NULL"))
        {
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets HiredAutoCA2001FirstName
        }
        if (data.Condition("'Last Name' != NULL"))
        {
                    await page.EnterHiredAutoCA2001LastNameAsync(data.Resolve("{{data:hiredauto_ca2001_last_name_514}}"));
        }
        if (data.Condition("'Address 1' != NULL"))
        {
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets HiredAutoCA2001Address1
        }
        if (data.Condition("'Zip Code' != NULL"))
        {
                    await page.EnterHiredAutoCA2001ZipCodeAsync(data.Resolve("{{data:hiredauto_ca2001_zipcode_516}}"));
        }
        if (data.Condition("'First Name' != NULL"))
        {
                    await page.ClickHiredAutoOKAsync();
        }
        if (data.Condition("'First Name' != NULL"))
        {
                    await page.EnterHiredAutoCA2001FirstNameAsync(data.Resolve("{{data:hiredauto_ca2001_first_name_518}}"));
        }
        if (data.Condition("'Address 1' != NULL"))
        {
                    await page.EnterHiredAutoCA2001Address1Async(data.Resolve("{{data:hiredauto_ca2001_address1_519}}"));
        }
        await page.WaitForHiredAutoOKAsync("Absent");
        await page.ClickPhysicalDamageOKAsync();
        await page.WaitForRiskDDE70Async("Exists");

    }

    [Given(@"^I verify Risk Level Coverages$")]
    [When(@"^I verify Risk Level Coverages$")]
    [Then(@"^I verify Risk Level Coverages$")]
    public async Task VerifyRiskLevelCoveragesAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyTypeD972CAsync(data.Resolve("{{data:constraint_vehicle_schedule_1_type_523}}"), "InnerText");
        await page.ClickDetail1664BAsync();
        await page.WaitForCommercialAutoRiskDetailAsync("Exists");
        if (data.Condition("'Accept UM' != NULL"))
        {
                    await page.VerifyAcceptUMAsync(data.Resolve("{{data:expected_accept_um_innertext_527}}"), "InnerText");
        }
        await page.ClickPhysicalDamageOKAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.PauseAsync(1000);

    }

    [Given(@"^I add Risk Level Coverages$")]
    [When(@"^I add Risk Level Coverages$")]
    [Then(@"^I add Risk Level Coverages$")]
    public async Task AddRiskLevelCoveragesAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyTypeD972CAsync(data.Resolve("{{data:constraint_vehicle_schedule_1_type_532}}"), "InnerText");
        await page.ClickDetail1664BAsync();
        await page.WaitForCommercialAutoRiskDetailAsync("Exists");
        if (data.Condition("'Loan/Lease Gap' != NULL"))
        {
                    await page.EnterLoanLeaseGapAsync(data.Resolve("{{data:loan_lease_gap_536}}"));
                    // v56 suppressed redundant Tosca keyboard steering: LoanLeaseGap Click
                    // v56 suppressed redundant Tosca keyboard steering: LoanLeaseGap Enter
                    // v56 suppressed redundant Tosca keyboard steering: LoanLeaseGap Tab
        }
        if (data.Condition("'Tapes Coverage' != NULL"))
        {
                    await page.EnterTapesCoverageAsync(data.Resolve("{{data:tapes_coverage_537}}"));
        }
        if (data.Condition("'Audio Visual' != NULL"))
        {
                    await page.EnterAudioVisualAsync(data.Resolve("{{data:audio_visual_538}}"));
        }
        if (data.Condition("'Audio Visual' != NULL"))
        {
                    await page.EnterAVCostNewAsync(data.Resolve("{{data:av_cost_new_539}}"));
        }
        if (data.Condition("Towing != NULL && 'Vehicle Type' == \"Private Passenger\""))
        {
                    await page.EnterTowingAsync("");
        }
        await page.WaitForPhysicalDamageOKAsync("Exists");
        await page.ClickPhysicalDamageOKAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.PauseAsync(1000);
        await page.WaitForRiskDDE70Async("Exists");
        await page.VerifyTypeD972CAsync(data.Resolve("{{data:constraint_vehicle_schedule_1_type_547}}"), "InnerText");
        await page.ClickDetail1664BAsync();
        await page.WaitForCommercialAutoRiskDetailAsync("Exists");
        if (data.Condition("'Loan/Lease Gap' != NULL"))
        {
                    await page.EnterLoanLeaseGapAsync(data.Resolve("{{data:loan_lease_gap_551}}"));
                    // v56 suppressed redundant Tosca keyboard steering: LoanLeaseGap Click
                    // v56 suppressed redundant Tosca keyboard steering: LoanLeaseGap Enter
                    // v56 suppressed redundant Tosca keyboard steering: LoanLeaseGap Tab
        }
        if (data.Condition("'Tapes Coverage' != NULL"))
        {
                    await page.EnterTapesCoverageAsync(data.Resolve("{{data:tapes_coverage_552}}"));
        }
        if (data.Condition("'Audio Visual' != NULL"))
        {
                    await page.EnterAudioVisualAsync(data.Resolve("{{data:audio_visual_553}}"));
        }
        if (data.Condition("'Audio Visual' != NULL"))
        {
                    await page.EnterAVCostNewAsync(data.Resolve("{{data:av_cost_new_554}}"));
        }
        await page.WaitForPhysicalDamageOKAsync("Exists");
        await page.ClickPhysicalDamageOKAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.PauseAsync(1000);
        await page.WaitForRiskDDE70Async("Exists");
        await page.VerifyTypeD972CAsync(data.Resolve("{{data:constraint_vehicle_schedule_1_type_561}}"), "InnerText");
        await page.ClickDetail1664BAsync();
        await page.WaitForCommercialAutoRiskDetailAsync("Exists");
        await page.EnterSeasonalProduceTrailersAsync(data.Resolve("{{data:seasonal_produce_trailers_565}}"));
        // v56 suppressed redundant Tosca keyboard steering: SeasonalProduceTrailers CLICK
        // v56 suppressed redundant Tosca keyboard steering: SeasonalProduceTrailers Tab
        await page.WaitForCoverageBeginDateAsync("Exists");
        await page.EnterCoverageEndDateAsync(data.Resolve("{DATE[09-05-2026][+6M][MM-dd-yyyy]}"));
        // v56 suppressed redundant Tosca keyboard steering: CoverageEndDate CLICK
        // v56 suppressed redundant Tosca keyboard steering: CoverageEndDate Tab
        await page.EnterProduceCarriedAsync(data.Resolve("{{data:produce_carried_568}}"));
        // v56 suppressed redundant Tosca keyboard steering: ProduceCarried CLICK
        // v56 suppressed redundant Tosca keyboard steering: ProduceCarried Tab
        await page.WaitForPhysicalDamageOKAsync("Exists");
        await page.ClickPhysicalDamageOKAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.PauseAsync(1000);
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
        await page.EnterFirstName813D1Async(data.Resolve("{{data:iframe_duck_creek_policy_first_name_579}}"));
        await page.EnterLastName34FF6Async(data.Resolve("{{data:iframe_duck_creek_policy_last_name_580}}"));
        await page.EnterDateOfBirthAsync(data.Resolve("{DATE[09-05-2026][-40y][MM-dd-yyyy]}"));
        await page.EnterStateLicensedAsync(data.Resolve("{{data:iframe_duck_creek_policy_state_licensed_582}}"));
        await page.VerifyDriversLicenseNumberAsync(data.Resolve("{{data:expected_iframe_duck_creek_policy_drivers_license_number_innertext_583}}"), "InnerText");
        await page.EnterSexAsync(data.Resolve("{{data:iframe_duck_creek_policy_sex_584}}"));
        await page.EnterMaritalStatusAsync(data.Resolve("{{data:iframe_duck_creek_policy_marital_status_585}}"));
        await page.EnterYearLicensedAsync(data.Resolve("{{data:iframe_duck_creek_policy_year_licensed_586}}"));
        await page.EnterDateOfHireAsync(data.Resolve("{{data:iframe_duck_creek_policy_date_of_hire_587}}"));
        await page.EnterDoYouHaveACDLLicenseAsync(data.Resolve("{{data:iframe_duck_creek_policy_do_you_have_a_cdl_license_588}}"));
        await page.ClickOKAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.WaitForIFRAME6D695Async("Absent");
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");

    }

    [Given(@"^I verify Mandatory Endorsements$")]
    [When(@"^I verify Mandatory Endorsements$")]
    [Then(@"^I verify Mandatory Endorsements$")]
    public async Task VerifyMandatoryEndorsementsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickEndorsementsC27F0Async();
        await page.WaitForEndorsementsHeadingA3D50Async("Exists");
        await page.VerifyEndorsementScheduleRow1Async("__BLANK__", "InnerText");
        if (data.Condition("'Endorsement Type' ==\"[CA2394] Silica or Silica-Related Dust Exclusion\""))
        {
                    await page.VerifyEndorsementScheduleRow1Async(data.Resolve("{{data:expected_endorsement_schedule_row_1_innertext_598}}"), "InnerText");
        }
        await page.VerifyEndorsementTableRow1Async("__BLANK__", "InnerText");
        if (data.Condition("'Endorsement Type' ==\"[CA2394] Silica or Silica-Related Dust Exclusion\""))
        {
                    await page.VerifyEndorsementTableRow2Async(data.Resolve("{{data:expected_endorsement_table_row_2_innertext_600}}"), "InnerText");
        }

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
        await page.EnterEndorsementType624ADAsync(data.Resolve("{{data:endorsement_type_614}}"));
        await page.EnterEndorsementType624ADAsync(data.Resolve("{{data:endorsement_type_615}}"));
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Click
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Enter
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Tab
        await page.ClickOKAsync();
        await page.VerifyIFRAMEF0A48Async("Exists", "");
        await page.WaitForIFRAMEF0A48Async("Absent");
        await page.WaitForEndorsementsHeadingA3D50Async("Exists");
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
        await page.EnterEndorsementType624ADAsync(data.Resolve("{{data:endorsement_type_633}}"));
        await page.EnterEndorsementType624ADAsync(data.Resolve("{{data:endorsement_type_634}}"));
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Click
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Enter
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Tab
        await page.ClickOKAsync();
        await page.VerifyIFRAMEF0A48Async("Exists", "");
        await page.WaitForIFRAMEF0A48Async("Absent");
        await page.WaitForEndorsementsHeadingA3D50Async("Exists");
        await page.VerifyEndorsementsHeadingA3D50Async("Absent", "");
        await page.ClickEndorsementsC27F0Async();
        await page.WaitForEndorsementsHeadingA3D50Async("Exists");
        await page.WaitForClickAddEndorsementAsync("Visible");
        await page.ClickClickAddEndorsementAsync();
        await page.WaitForEndorsementDetailAsync("Exists");
        if (data.Condition("'Endorsement Type' == \"[CA2325] Leased Workers Coverage\""))
        {
                    await page.WaitForCA2325LeasedWorkersCoverageAsync("Exists");
        }
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
        await page.EnterEndorsementType624ADAsync(data.Resolve("{{data:endorsement_type_653}}"));
        await page.EnterEndorsementType624ADAsync(data.Resolve("{{data:endorsement_type_654}}"));
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Click
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Enter
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Tab
        await page.ClickOKAsync();
        await page.VerifyIFRAMEF0A48Async("Exists", "");
        await page.WaitForIFRAMEF0A48Async("Absent");
        await page.WaitForEndorsementsHeadingA3D50Async("Exists");
        await page.VerifyEndorsementsHeadingA3D50Async("Absent", "");
        await page.ClickEndorsementsC27F0Async();
        await page.WaitForEndorsementsHeadingA3D50Async("Exists");
        await page.WaitForClickAddEndorsementAsync("Visible");
        await page.ClickClickAddEndorsementAsync();
        await page.WaitForEndorsementDetailAsync("Exists");
        if (data.Condition("'Add Excluded Driver' != NULL"))
        {
                    await page.WaitForClickAddExcludedDriverAsync("Exists");
        }
        if (data.Condition("'Add Excluded Driver' != NULL"))
        {
                    await page.ClickClickAddExcludedDriverAsync();
        }
        if (data.Condition("'Driver Name' != NULL"))
        {
                    await page.EnterAddDriverNameAsync(data.Resolve("{{data:iframe_duck_creek_policy_add_driver_name_667}}"));
        }
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
        await page.EnterEndorsementType624ADAsync(data.Resolve("{{data:endorsement_type_675}}"));
        await page.EnterEndorsementType624ADAsync(data.Resolve("{{data:endorsement_type_676}}"));
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Click
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Enter
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Tab
        await page.ClickOKAsync();
        await page.VerifyIFRAMEF0A48Async("Exists", "");
        await page.WaitForIFRAMEF0A48Async("Absent");
        await page.WaitForEndorsementsHeadingA3D50Async("Exists");
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
        if (data.Condition("'Commodities Transported' != NULL"))
        {
                    await page.EnterCA9948ClassesOfCommoditiesTransportedAsync(data.Resolve("{{data:iframe_duck_creek_policy_ca9948_classes_of_commodities_transported_691}}"));
                    // v56 suppressed redundant Tosca keyboard steering: CA9948ClassesOfCommoditiesTransported Click
                    // v56 suppressed redundant Tosca keyboard steering: CA9948ClassesOfCommoditiesTransported Enter
                    // v56 suppressed redundant Tosca keyboard steering: CA9948ClassesOfCommoditiesTransported Tab
        }
        await page.WaitForOKAsync("Exists");
        await page.WaitForEndorsementType624ADAsync("Exists");
        await page.ClickEndorsementType624ADAsync();
        await page.EnterEndorsementType624ADAsync(data.Resolve("{{data:endorsement_type_695}}"));
        await page.EnterEndorsementType624ADAsync(data.Resolve("{{data:endorsement_type_696}}"));
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Click
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Enter
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Tab
        await page.ClickOKAsync();
        await page.VerifyIFRAMEF0A48Async("Exists", "");
        await page.WaitForIFRAMEF0A48Async("Absent");
        await page.WaitForEndorsementsHeadingA3D50Async("Exists");
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
        await page.EnterEndorsementType624ADAsync(data.Resolve("{{data:endorsement_type_714}}"));
        await page.EnterEndorsementType624ADAsync(data.Resolve("{{data:endorsement_type_715}}"));
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Click
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Enter
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Tab
        await page.ClickOKAsync();
        await page.VerifyIFRAMEF0A48Async("Exists", "");
        await page.WaitForIFRAMEF0A48Async("Absent");
        await page.WaitForEndorsementsHeadingA3D50Async("Exists");
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
        if (data.Condition("'Endorsement Type' ==\"Trailer Interchange Coverage\""))
        {
                    await page.EnterTrailerInterchangeEnterDaysInsuredAsync(data.Resolve("{{data:iframe_duck_creek_policy_trailer_interchange_enter_days_insured_730}}"));
        }
        if (data.Condition("'Endorsement Type' ==\"Trailer Interchange Coverage\""))
        {
                    await page.EnterTrailerInterchangeEnterOfTrailersAsync(data.Resolve("{{data:iframe_duck_creek_policy_trailer_interchange_enter_of_trailers_731}}"));
        }
        await page.WaitForOKAsync("Exists");
        await page.WaitForEndorsementType624ADAsync("Exists");
        await page.ClickEndorsementType624ADAsync();
        await page.EnterEndorsementType624ADAsync(data.Resolve("{{data:endorsement_type_735}}"));
        await page.EnterEndorsementType624ADAsync(data.Resolve("{{data:endorsement_type_736}}"));
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Click
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Enter
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Tab
        await page.ClickOKAsync();
        await page.VerifyIFRAMEF0A48Async("Exists", "");
        await page.WaitForIFRAMEF0A48Async("Absent");
        await page.WaitForEndorsementsHeadingA3D50Async("Exists");
        await page.VerifyEndorsementsHeadingA3D50Async("Absent", "");
        await page.ClickEndorsementsC27F0Async();
        await page.WaitForEndorsementsHeadingA3D50Async("Exists");
        await page.WaitForClickAddEndorsementAsync("Visible");
        await page.ClickClickAddEndorsementAsync();
        await page.WaitForEndorsementDetailAsync("Exists");
        if (data.Condition("Year != NULL"))
        {
                    await page.EnterCA9940YearAsync(data.Resolve("{{data:iframe_duck_creek_policy_ca9940_year_747}}"));
        }
        if (data.Condition("Make != NULL"))
        {
                    await page.EnterCA9940MakeAsync(data.Resolve("{{data:iframe_duck_creek_policy_ca9940_make_748}}"));
        }
        if (data.Condition("Model != NULL"))
        {
                    await page.EnterCA9940ModelAsync(data.Resolve("{{data:iframe_duck_creek_policy_ca9940_model_749}}"));
        }
        if (data.Condition("VIN != NULL"))
        {
                    await page.EnterCA9940VINAsync(data.Resolve("{{data:iframe_duck_creek_policy_ca_9940_vin_750}}"));
        }
        if (data.Condition("'Contract Provisions' != NULL"))
        {
                    await page.EnterCA9940ContractProvisionsAsync(data.Resolve("{{data:iframe_duck_creek_policy_ca9940_contract_provisions_751}}"));
                    // v56 suppressed redundant Tosca keyboard steering: CA9940ContractProvisions CLICK
                    // v56 suppressed redundant Tosca keyboard steering: CA9940ContractProvisions Enter
                    // v56 suppressed redundant Tosca keyboard steering: CA9940ContractProvisions Tab
        }
        await page.WaitForOKAsync("Exists");
        await page.WaitForEndorsementType624ADAsync("Exists");
        await page.ClickEndorsementType624ADAsync();
        await page.EnterEndorsementType624ADAsync(data.Resolve("{{data:endorsement_type_755}}"));
        await page.EnterEndorsementType624ADAsync(data.Resolve("{{data:endorsement_type_756}}"));
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Click
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Enter
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Tab
        await page.ClickOKAsync();
        await page.VerifyIFRAMEF0A48Async("Exists", "");
        await page.WaitForIFRAMEF0A48Async("Absent");
        await page.WaitForEndorsementsHeadingA3D50Async("Exists");
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
        await page.EnterEndorsementType624ADAsync(data.Resolve("{{data:endorsement_type_774}}"));
        await page.EnterEndorsementType624ADAsync(data.Resolve("{{data:endorsement_type_775}}"));
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Click
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Enter
        // v56 suppressed redundant Tosca keyboard steering: EndorsementType624AD Tab
        await page.ClickOKAsync();
        await page.VerifyIFRAMEF0A48Async("Exists", "");
        await page.WaitForIFRAMEF0A48Async("Absent");
        await page.WaitForEndorsementsHeadingA3D50Async("Exists");

    }

    [Given(@"^I add Addl Interest$")]
    [When(@"^I add Addl Interest$")]
    [Then(@"^I add Addl Interest$")]
    public async Task AddAddlInterestAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyAddlInterests15174Async("Absent", "");
        await page.ClickAdditionalInterestsAsync();
        await page.WaitForAddlInterests15174Async("Exists");
        await page.ClickAddOtherInterestAsync();
        await page.WaitForTypeOfInterestAsync("Exists");
        await page.EnterTypeOfInterestAsync(data.Resolve("{{data:iframe_duck_creek_policy_type_of_interest_785}}"));
        // v56 suppressed redundant Tosca keyboard steering: TypeOfInterest CLICK
        // v56 suppressed redundant Tosca keyboard steering: TypeOfInterest Enter
        // v56 suppressed redundant Tosca keyboard steering: TypeOfInterest Tab
        await page.WaitForFirstName813D1Async("Exists");
        if (data.Condition("'First Name' != NULL"))
        {
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets FirstName813D1
        }
        if (data.Condition("'First Name' != NULL"))
        {
                    await page.EnterFirstName813D1Async(data.Resolve("{{data:iframe_duck_creek_policy_first_name_788}}"));
        }
        if (data.Condition("'Last Name' != NULL"))
        {
                    await page.EnterLastName34FF6Async(data.Resolve("{{data:iframe_duck_creek_policy_last_name_789}}"));
        }
        if (data.Condition("Address != NULL"))
        {
                    await page.EnterAddress193FF8Async(data.Resolve("{{data:iframe_duck_creek_policy_address_1_790}}"));
        }
        if (data.Condition("ZIP != NULL"))
        {
                    await page.EnterZipCodeB286BAsync(data.Resolve("{{data:iframe_duck_creek_policy_zip_code_791}}"));
        }
        await page.WaitForState64A10Async("Visible");
        await page.ClickOKAsync();
        await page.WaitForAddlInterests15174Async("Exists");
        await page.WaitForIFRAME59D4BAsync("Absent");
        await page.VerifyAddlInterests15174Async("Absent", "");
        await page.ClickAdditionalInterestsAsync();
        await page.WaitForAddlInterests15174Async("Exists");
        await page.ClickAddOtherInterestAsync();
        await page.WaitForTypeOfInterestAsync("Exists");
        await page.EnterTypeOfInterestAsync(data.Resolve("{{data:iframe_duck_creek_policy_type_of_interest_801}}"));
        // v56 suppressed redundant Tosca keyboard steering: TypeOfInterest CLICK
        // v56 suppressed redundant Tosca keyboard steering: TypeOfInterest Enter
        // v56 suppressed redundant Tosca keyboard steering: TypeOfInterest Tab
        await page.WaitForFirstName813D1Async("Exists");
        if (data.Condition("'First Name' != NULL"))
        {
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets FirstName813D1
        }
        if (data.Condition("'First Name' != NULL"))
        {
                    await page.EnterFirstName813D1Async(data.Resolve("{{data:iframe_duck_creek_policy_first_name_804}}"));
        }
        if (data.Condition("'Last Name' != NULL"))
        {
                    await page.EnterLastName34FF6Async(data.Resolve("{{data:iframe_duck_creek_policy_last_name_805}}"));
        }
        if (data.Condition("Address != NULL"))
        {
                    await page.EnterAddress193FF8Async(data.Resolve("{{data:iframe_duck_creek_policy_address_1_806}}"));
        }
        if (data.Condition("ZIP != NULL"))
        {
                    await page.EnterZipCodeB286BAsync(data.Resolve("{{data:iframe_duck_creek_policy_zip_code_807}}"));
        }
        await page.WaitForState64A10Async("Visible");
        if (data.Condition("'Vehicle Association' != NULL"))
        {
                    await page.ClickIFRAMEDuckCreekPolicyVehicleAssociationAsync();
        }
        if (data.Condition("'Vehicle Association' != NULL"))
        {
                    await page.ClickIFRAMEDuckCreekPolicyVehicleAssociationAsync();
                    await page.PressIFRAMEDuckCreekPolicyVehicleAssociationAsync("DOUBLECLICK");
                    await page.PressIFRAMEDuckCreekPolicyVehicleAssociationAsync("DOWN");
                    // v56 suppressed duplicate keyboard steering: IFRAMEDuckCreekPolicyVehicleAssociation DOWN
                    await page.PressIFRAMEDuckCreekPolicyVehicleAssociationAsync("Enter");
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets IFRAMEDuckCreekPolicyVehicleAssociation
        }
        if (data.Condition("'Vehicle Association' != NULL"))
        {
                    await page.WaitForIFRAMEDuckCreekPolicyVehicleAssociationAsync("NotEqual");
        }
        await page.ClickOKAsync();
        await page.WaitForAddlInterests15174Async("Exists");
        await page.WaitForIFRAME59D4BAsync("Absent");
        await page.VerifyAddlInterests15174Async("Absent", "");
        await page.ClickAdditionalInterestsAsync();
        await page.WaitForAddlInterests15174Async("Exists");
        await page.ClickAddOtherInterestAsync();
        await page.WaitForTypeOfInterestAsync("Exists");
        await page.EnterTypeOfInterestAsync(data.Resolve("{{data:iframe_duck_creek_policy_type_of_interest_820}}"));
        // v56 suppressed redundant Tosca keyboard steering: TypeOfInterest CLICK
        // v56 suppressed redundant Tosca keyboard steering: TypeOfInterest Enter
        // v56 suppressed redundant Tosca keyboard steering: TypeOfInterest Tab
        await page.WaitForFirstName813D1Async("Exists");
        if (data.Condition("'First Name' != NULL"))
        {
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets FirstName813D1
        }
        if (data.Condition("'First Name' != NULL"))
        {
                    await page.EnterFirstName813D1Async(data.Resolve("{{data:iframe_duck_creek_policy_first_name_823}}"));
        }
        if (data.Condition("'Last Name' != NULL"))
        {
                    await page.EnterLastName34FF6Async(data.Resolve("{{data:iframe_duck_creek_policy_last_name_824}}"));
        }
        if (data.Condition("Address != NULL"))
        {
                    await page.EnterAddress193FF8Async(data.Resolve("{{data:iframe_duck_creek_policy_address_1_825}}"));
        }
        if (data.Condition("ZIP != NULL"))
        {
                    await page.EnterZipCodeB286BAsync(data.Resolve("{{data:iframe_duck_creek_policy_zip_code_826}}"));
        }
        await page.WaitForState64A10Async("Visible");
        if (data.Condition("'Vehicle Association' != NULL"))
        {
                    await page.ClickIFRAMEDuckCreekPolicyVehicleAssociationAsync();
        }
        if (data.Condition("'Vehicle Association' != NULL"))
        {
                    await page.ClickIFRAMEDuckCreekPolicyVehicleAssociationAsync();
                    await page.PressIFRAMEDuckCreekPolicyVehicleAssociationAsync("DOUBLECLICK");
                    await page.PressIFRAMEDuckCreekPolicyVehicleAssociationAsync("DOWN");
                    // v56 suppressed duplicate keyboard steering: IFRAMEDuckCreekPolicyVehicleAssociation DOWN
                    await page.PressIFRAMEDuckCreekPolicyVehicleAssociationAsync("Enter");
                    // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets IFRAMEDuckCreekPolicyVehicleAssociation
        }
        if (data.Condition("'Vehicle Association' != NULL"))
        {
                    await page.WaitForIFRAMEDuckCreekPolicyVehicleAssociationAsync("NotEqual");
        }
        await page.ClickOKAsync();
        await page.WaitForAddlInterests15174Async("Exists");
        await page.WaitForIFRAME59D4BAsync("Absent");

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
        await page.EnterAreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicyAsync(data.Resolve("{{data:are_there_any_commercial_vehicles_owned_by_the_applicant_not_insured_on_the_policy_837}}"));
        await page.WaitForAreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicyAsync("Equal");
        await page.EnterAnyPersonalAutoPolicyListingNameInsuredAsync(data.Resolve("{{data:anypersonalautopolicylistingnameinsured_839}}"));
        await page.EnterAnyVehicleCoveredRegisteredInNotPrimaryStateAsync(data.Resolve("{{data:anyvehiclecoveredregisteredinnotprimarystate_840}}"));
        await page.EnterBorrowingHiringOrLeasingWithinYearAsync(data.Resolve("{{data:borrowinghiringorleasingwithinyear_841}}"));
        await page.WaitForBorrowingHiringOrLeasingWithinYearAsync("Equal");
        await page.WaitForAnyVehicleCoveredRegisteredInNotPrimaryStateAsync("Equal");
        await page.VerifyHasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiringAsync("Exists", "");
        await page.EnterHasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiringAsync(data.Resolve("{{data:has_any_applicant_been_convicted_of_a_felony_or_been_involved_in_any_incidents_or_claims_relating_to_sexual_abuse_or_molestation_allegations_discrimination_arson_fraud_bribery_or_negligent_hiring_845}}"));

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
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_848}}"));
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_851}}"));
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_855}}"));
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
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_866}}"));
        // v56 suppressed redundant Tosca keyboard steering: IsThisCoverageBound CLICK
        // v56 suppressed redundant Tosca keyboard steering: IsThisCoverageBound Tab
        await page.VerifyOrderAuditAsync("Exists", "");
        await page.EnterOrderAuditAsync(data.Resolve("{{data:order_audit_868}}"));
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
        await page.VerifyIsThisCoverageBoundAsync(data.Resolve("{{data:expected_is_this_coverage_bound_value_876}}"), "Value");
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_877}}"));
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
        await page.EnterTitleAsync(data.Resolve("{{data:title_909}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_910}}"));
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
        await page.VerifyStatusCodeAsync(data.Resolve("{{data:expected_statuscode_value_914}}"), "value");
        await page.PauseAsync(1000);
        await page.PauseAsync(1000);

    }

    [Given(@"^I complete save for Later/Return to Admin$")]
    [When(@"^I complete save for Later/Return to Admin$")]
    [Then(@"^I complete save for Later/Return to Admin$")]
    public async Task CompleteSaveForLaterReturnToAdminAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifySaveForLaterAsync("Exists", "");
        await page.ClickSaveForLaterAsync();
        await page.WaitForSaveForLaterOKAsync("Exists");
        await page.ClickSaveForLaterOKAsync();
        await page.VerifyReturnToAdminAsync("Exists", "");
        await page.ClickReturnToAdminAsync();
        await page.WaitForReturnToAdminAsync("Absent");

    }

}
