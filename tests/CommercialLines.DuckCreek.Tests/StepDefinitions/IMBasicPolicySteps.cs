using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "IM Basic Policy")]
public sealed class IMBasicPolicySteps
{
    private readonly ScenarioContext _scenario;
    public IMBasicPolicySteps(ScenarioContext scenario) => _scenario = scenario;

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

    [Given(@"^I complete Underwring Questions from Client Screen$")]
    [When(@"^I complete Underwring Questions from Client Screen$")]
    [Then(@"^I complete Underwring Questions from Client Screen$")]
    public async Task CompleteUnderwringQuestionsFromClientScreenAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickUnderwritingInfoAsync();
        await page.WaitForGeneralUWQuestionsAsync("Exists");
        await page.ClickUpdateAnswers9CB86Async();
        await page.ClickInsuranceHistoryAsync();
        await page.EnterIsThereAPriorCarrierAsync(data.Resolve("{{data:is_there_a_prior_carrier_87}}"));
        await page.ClickLossExperienceAsync();
        await page.WaitForLossExperienceHeadingAsync("Exists");
        await page.ClickNoKnownLossesAsync();
        await page.ClickReturnToQuoteAsync();
        await page.EnterTitleAsync(data.Resolve("{{data:title_92}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_93}}"));
        await page.VerifyResultAsync(data.Resolve("{{data:expected_result_value_94}}"), "value");

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
        await page.EnterEffectiveDate95094Async(data.Resolve("{{data:effectivedate_98}}"));
        if (data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
                    await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_99}}"));
        }
        await page.PauseAsync(1000);
        if (data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_101}}"));
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
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_105}}"));
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
        await page.EnterDescriptionOfSpecifiedOperationAsync("AZ IM Basic {NMONTH}.{NDAY}.{NYEAR} {Time}");
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
        await page.VerifyReferenceNumberAsync(data.Resolve("{{data:expected_reference_number_innertext_129}}"), "InnerText");
        await page.PauseAsync(1000);
        await page.PauseAsync(1000);

    }

    [Given(@"^I add Accounts Receivable Coverage$")]
    [When(@"^I add Accounts Receivable Coverage$")]
    [Then(@"^I add Accounts Receivable Coverage$")]
    public async Task AddAccountsReceivableCoverageAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickPolicyCovgED95CAsync();
        await page.WaitForPolicyCovgF9E58Async("Exists");
        await page.EnterCoverageFormToBeAddedAsync(data.Resolve("{{data:coverage_form_to_be_added_134}}"));
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded CLICK
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded Enter
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded Tab
        await page.ClickAddCoverageFormAsync();
        await page.EnterDescriptionAsync(data.Resolve("{{data:description_136}}"));
        // v56 suppressed redundant Tosca keyboard steering: Description CLICK
        // v56 suppressed redundant Tosca keyboard steering: Description Enter
        await page.EnterCoinsuranceAsync(data.Resolve("{{data:coinsurance_137}}"));
        // v56 suppressed redundant Tosca keyboard steering: Coinsurance CLICK
        await page.EnterAwayFromPremisesLmtAsync(data.Resolve("{{data:away_from_premises_lmt_138}}"));
        // v56 suppressed redundant Tosca keyboard steering: AwayFromPremisesLmt CLICK
        await page.EnterAwayFromPremisesDescAsync(data.Resolve("{{data:away_from_premises_desc_139}}"));
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
        await page.EnterCoverageFormToBeAddedAsync(data.Resolve("{{data:coverage_form_to_be_added_143}}"));
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded CLICK
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded Enter
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded Tab
        await page.ClickAddCoverageFormAsync();
        await page.WaitForCoverageFormDisplay6F446Async("Exists");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Description43F2D
        await page.EnterDescription43F2DAsync(data.Resolve("{{data:description_147}}"));
        // v56 suppressed redundant Tosca keyboard steering: Description43F2D CLICK
        // v56 suppressed redundant Tosca keyboard steering: Description43F2D Enter
        // v56 suppressed redundant Tosca keyboard steering: Description43F2D Tab
        await page.EnterPropertyInTransit710FFAsync(data.Resolve("{{data:property_in_transit_148}}"));
        await page.ClickPropertyAwayFromYourPremisesScheduleAsync();
        await page.ClickAddPremisesAsync();
        await page.EnterAddressStreetCityStateZipAsync(data.Resolve("{{data:address_street_city_state_zip_151}}"));
        // v56 suppressed redundant Tosca keyboard steering: AddressStreetCityStateZip CLICK
        // v56 suppressed redundant Tosca keyboard steering: AddressStreetCityStateZip Tab
        await page.EnterLimit46632Async(data.Resolve("{{data:limit_152}}"));
        await page.ClickPolicyCovgBaileesPropertyAwayFromYourPremisesOKAsync();
        await page.WaitForCoverageFormDisplay6F446Async("Exists");
        await page.ClickPolicyCovgBaileesCutomersOKAsync();

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
        await page.EnterCoverageFormToBeAddedAsync(data.Resolve("{{data:coverage_form_to_be_added_158}}"));
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded CLICK
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded Enter
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded Tab
        await page.ClickAddCoverageFormAsync();
        await page.WaitForCoverageFormDisplayD1A9BAsync("Exists");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Description03789
        await page.EnterDescription03789Async(data.Resolve("{{data:description_162}}"));
        // v56 suppressed redundant Tosca keyboard steering: Description03789 CLICK
        // v56 suppressed redundant Tosca keyboard steering: Description03789 Tab
        await page.EnterCoinsuranceC9726Async(data.Resolve("{{data:coinsurance_163}}"));
        // v56 suppressed redundant Tosca keyboard steering: CoinsuranceC9726 CLICK
        // v56 suppressed redundant Tosca keyboard steering: CoinsuranceC9726 Tab
        await page.EnterDeductibleC227CAsync(data.Resolve("{{data:deductible_164}}"));
        // v56 suppressed redundant Tosca keyboard steering: DeductibleC227C CLICK
        // v56 suppressed redundant Tosca keyboard steering: DeductibleC227C Tab
        await page.EnterBoomDeductibleAsync(data.Resolve("{{data:boom_deductible_165}}"));
        // v56 suppressed redundant Tosca keyboard steering: BoomDeductible CLICK
        // v56 suppressed redundant Tosca keyboard steering: BoomDeductible Tab
        await page.EnterTypeOfContractorAsync(data.Resolve("{{data:type_of_contractor_166}}"));
        // v56 suppressed redundant Tosca keyboard steering: TypeOfContractor CLICK
        // v56 suppressed redundant Tosca keyboard steering: TypeOfContractor Tab
        await page.EnterScheduledCoverageAsync(data.Resolve("{{data:scheduled_coverage_167}}"));
        // v56 suppressed redundant Tosca keyboard steering: ScheduledCoverage CLICK
        // v56 suppressed redundant Tosca keyboard steering: ScheduledCoverage Tab
        await page.EnterRentedEquipmentExpenseAsync(data.Resolve("{{data:rented_equipment_expense_168}}"));
        // v56 suppressed redundant Tosca keyboard steering: RentedEquipmentExpense CLICK
        // v56 suppressed redundant Tosca keyboard steering: RentedEquipmentExpense Tab
        await page.EnterToolsAndClothingBelongingToYourEmployeesAsync(data.Resolve("{{data:tools_and_clothing_belonging_to_your_employees_169}}"));
        // v56 suppressed redundant Tosca keyboard steering: ToolsAndClothingBelongingToYourEmployees CLICK
        // v56 suppressed redundant Tosca keyboard steering: ToolsAndClothingBelongingToYourEmployees Tab
        await page.EnterMiscItemsBlanketCoverageAsync(data.Resolve("{{data:misc_items_blanket_coverage_170}}"));
        // v56 suppressed redundant Tosca keyboard steering: MiscItemsBlanketCoverage CLICK
        // v56 suppressed redundant Tosca keyboard steering: MiscItemsBlanketCoverage Tab
        await page.EnterRentalReimbursementAsync(data.Resolve("{{data:rental_reimbursement_171}}"));
        // v56 suppressed redundant Tosca keyboard steering: RentalReimbursement CLICK
        // v56 suppressed redundant Tosca keyboard steering: RentalReimbursement Tab
        await page.EnterHiredEquipmentAsync(data.Resolve("{{data:hired_equipment_172}}"));
        // v56 suppressed redundant Tosca keyboard steering: HiredEquipment CLICK
        // v56 suppressed redundant Tosca keyboard steering: HiredEquipment Tab
        await page.ClickPolicyCovgContractorsEquipmentOKAsync();

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
        await page.EnterCoverageFormToBeAddedAsync(data.Resolve("{{data:coverage_form_to_be_added_176}}"));
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded CLICK
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded Enter
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded Tab
        await page.ClickAddCoverageFormAsync();
        await page.WaitForCoverageFormDisplay2ECD4Async("Exists");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Description58EC2
        await page.EnterDescription58EC2Async(data.Resolve("{{data:description_180}}"));
        // v56 suppressed redundant Tosca keyboard steering: Description58EC2 CLICK
        // v56 suppressed redundant Tosca keyboard steering: Description58EC2 Enter
        // v56 suppressed redundant Tosca keyboard steering: Description58EC2 Tab
        await page.EnterDeductibleC91E9Async(data.Resolve("{{data:deductible_181}}"));
        await page.EnterCoinsurance01AB1Async(data.Resolve("{{data:coinsurance_182}}"));
        await page.EnterPropertyInTransit6E905Async(data.Resolve("{{data:property_in_transit_183}}"));
        await page.EnterUnnamedPremisesAsync(data.Resolve("{{data:unnamed_premises_184}}"));
        await page.EnterPersonalPortableComputersAsync(data.Resolve("{{data:personal_portable_computers_185}}"));
        await page.EnterExtraExpenseAsync(data.Resolve("{{data:extra_expense_186}}"));
        await page.EnterVirusHarmfulCodeOrSimilarInstructionAsync(data.Resolve("{{data:virus_harmful_code_or_similar_instruction_187}}"));
        await page.ClickPolicyCovgComputerSystemsOKAsync();

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
        await page.EnterCoverageFormToBeAddedAsync(data.Resolve("{{data:coverage_form_to_be_added_191}}"));
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded CLICK
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded Enter
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded Tab
        await page.ClickAddCoverageFormAsync();
        await page.WaitForCoverageFormDisplayB69C2Async("Exists");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets DescriptionF8E60
        await page.EnterDescriptionF8E60Async(data.Resolve("{{data:description_195}}"));
        // v56 suppressed redundant Tosca keyboard steering: DescriptionF8E60 CLICK
        // v56 suppressed redundant Tosca keyboard steering: DescriptionF8E60 Enter
        // v56 suppressed redundant Tosca keyboard steering: DescriptionF8E60 Tab
        await page.EnterCoverageTypeAsync(data.Resolve("{{data:coverage_type_196}}"));
        await page.EnterCoveredPropertyConsistingPrincipallyOfAsync(data.Resolve("{{data:covered_property_consisting_principally_of_197}}"));
        await page.EnterDeductible320C9Async(data.Resolve("{{data:deductible_198}}"));
        await page.EnterPerVehicleLimitAsync(data.Resolve("{{data:per_vehicle_limit_199}}"));
        await page.EnterGroupClassAsync(data.Resolve("{{data:group_class_200}}"));
        await page.EnterNumberOfVehiclesAsync(data.Resolve("{{data:number_of_vehicles_201}}"));
        await page.EnterUnnamedTerminalsLimitAsync(data.Resolve("{{data:unnamed_terminals_limit_202}}"));
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
        await page.EnterCoverageFormToBeAddedAsync(data.Resolve("{{data:coverage_form_to_be_added_206}}"));
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded CLICK
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded Enter
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormToBeAdded Tab
        await page.ClickAddCoverageFormAsync();
        await page.WaitForCoverageFormDisplayC10BAAsync("Exists");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets DescriptionBE47E
        await page.EnterDescriptionBE47EAsync(data.Resolve("{{data:description_210}}"));
        // v56 suppressed redundant Tosca keyboard steering: DescriptionBE47E CLICK
        // v56 suppressed redundant Tosca keyboard steering: DescriptionBE47E Enter
        // v56 suppressed redundant Tosca keyboard steering: DescriptionBE47E Tab
        await page.VerifyCoverageFormA7F96Async("Exists", "");
        await page.EnterN5DeductibleAsync(data.Resolve("{{data:5_deductible_212}}"));
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
        await page.EnterCoverageFormCFDD1Async(data.Resolve("{{data:coverage_form_217}}"));
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormCFDD1 CLICK
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormCFDD1 Tab
        await page.ClickAddAsync();
        await page.WaitForAccountsReceivableHeadingAsync("Exists");
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets SearchValue79E46
        await page.EnterSearchValue79E46Async(data.Resolve("{{data:search_value_221}}"));
        // v56 suppressed redundant Tosca keyboard steering: SearchValue79E46 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SearchValue79E46 Tab
        await page.EnterSearchResultEAFB8Async(data.Resolve("{{data:search_result_222}}"));
        // v56 suppressed redundant Tosca keyboard steering: SearchResultEAFB8 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SearchResultEAFB8 Enter
        // v56 suppressed redundant Tosca keyboard steering: SearchResultEAFB8 Tab
        await page.EnterConstructionFB8D9Async(data.Resolve("{{data:construction_223}}"));
        // v56 suppressed redundant Tosca keyboard steering: ConstructionFB8D9 CLICK
        // v56 suppressed redundant Tosca keyboard steering: ConstructionFB8D9 Tab
        await page.EnterPremisesTypeAsync(data.Resolve("{{data:premises_type_224}}"));
        // v56 suppressed redundant Tosca keyboard steering: PremisesType CLICK
        // v56 suppressed redundant Tosca keyboard steering: PremisesType Tab
        await page.EnterDuplicatedRecordsAsync(data.Resolve("{{data:duplicated_records_225}}"));
        // v56 suppressed redundant Tosca keyboard steering: DuplicatedRecords CLICK
        // v56 suppressed redundant Tosca keyboard steering: DuplicatedRecords Tab
        await page.EnterClassificationOfRiskAsync(data.Resolve("{{data:classification_of_risk_226}}"));
        // v56 suppressed redundant Tosca keyboard steering: ClassificationOfRisk CLICK
        // v56 suppressed redundant Tosca keyboard steering: ClassificationOfRisk Tab
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
        await page.EnterCoverageFormCFDD1Async(data.Resolve("{{data:coverage_form_230}}"));
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormCFDD1 CLICK
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormCFDD1 Tab
        await page.ClickAddAsync();
        await page.WaitForBaileesCustomersHeadingAsync("Exists");
        await page.EnterDeductible59155Async(data.Resolve("{{data:deductible_233}}"));
        // v56 suppressed redundant Tosca keyboard steering: Deductible59155 CLICK
        // v56 suppressed redundant Tosca keyboard steering: Deductible59155 Tab
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets SearchValueCA6A6
        await page.EnterSearchValueCA6A6Async(data.Resolve("{{data:search_value_235}}"));
        // v56 suppressed redundant Tosca keyboard steering: SearchValueCA6A6 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SearchValueCA6A6 Tab
        await page.EnterSearchResultA1BFBAsync(data.Resolve("{{data:search_result_236}}"));
        // v56 suppressed redundant Tosca keyboard steering: SearchResultA1BFB CLICK
        // v56 suppressed redundant Tosca keyboard steering: SearchResultA1BFB Enter
        // v56 suppressed redundant Tosca keyboard steering: SearchResultA1BFB Tab
        await page.EnterConstructionCD2DEAsync(data.Resolve("{{data:construction_237}}"));
        // v56 suppressed redundant Tosca keyboard steering: ConstructionCD2DE CLICK
        // v56 suppressed redundant Tosca keyboard steering: ConstructionCD2DE Tab
        await page.EnterAnnualGrossReceiptsAsync(data.Resolve("{{data:annual_gross_receipts_238}}"));
        // v56 suppressed redundant Tosca keyboard steering: AnnualGrossReceipts CLICK
        // v56 suppressed redundant Tosca keyboard steering: AnnualGrossReceipts Tab
        await page.EnterAverageNumberOfDaysServiceAsync(data.Resolve("{{data:average_number_of_days_service_239}}"));
        // v56 suppressed redundant Tosca keyboard steering: AverageNumberOfDaysService CLICK
        // v56 suppressed redundant Tosca keyboard steering: AverageNumberOfDaysService Tab
        await page.EnterAverageNumberOfWorkingDaysAsync(data.Resolve("{{data:average_number_of_working_days_240}}"));
        // v56 suppressed redundant Tosca keyboard steering: AverageNumberOfWorkingDays CLICK
        // v56 suppressed redundant Tosca keyboard steering: AverageNumberOfWorkingDays Tab
        await page.EnterAverageServiceChargeAsync(data.Resolve("{{data:average_service_charge_241}}"));
        // v56 suppressed redundant Tosca keyboard steering: AverageServiceCharge CLICK
        // v56 suppressed redundant Tosca keyboard steering: AverageServiceCharge Tab
        await page.EnterAverageValuePerOrderAsync(data.Resolve("{{data:average_value_per_order_242}}"));
        // v56 suppressed redundant Tosca keyboard steering: AverageValuePerOrder CLICK
        // v56 suppressed redundant Tosca keyboard steering: AverageValuePerOrder Tab
        await page.EnterLimitE32DCAsync(data.Resolve("{{data:limit_243}}"));
        // v56 suppressed redundant Tosca keyboard steering: LimitE32DC CLICK
        // v56 suppressed redundant Tosca keyboard steering: LimitE32DC Tab
        await page.EnterEarthquakeAsync(data.Resolve("{{data:earthquake_244}}"));
        // v56 suppressed redundant Tosca keyboard steering: Earthquake CLICK
        // v56 suppressed redundant Tosca keyboard steering: Earthquake Tab
        await page.EnterStorageLimitAsync(data.Resolve("{{data:storage_limit_245}}"));
        // v56 suppressed redundant Tosca keyboard steering: StorageLimit CLICK
        // v56 suppressed redundant Tosca keyboard steering: StorageLimit Tab
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
        await page.EnterCoverageFormCFDD1Async(data.Resolve("{{data:coverage_form_249}}"));
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormCFDD1 CLICK
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormCFDD1 Tab
        await page.ClickAddAsync();
        await page.EnterComputerEquipmentAsync(data.Resolve("{{data:computer_equipment_251}}"));
        // v56 suppressed redundant Tosca keyboard steering: ComputerEquipment CLICK
        // v56 suppressed redundant Tosca keyboard steering: ComputerEquipment Tab
        await page.EnterDataAndMediaAsync(data.Resolve("{{data:data_and_media_252}}"));
        // v56 suppressed redundant Tosca keyboard steering: DataAndMedia CLICK
        // v56 suppressed redundant Tosca keyboard steering: DataAndMedia Tab
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets SearchValue9FCD1
        await page.EnterSearchValue9FCD1Async(data.Resolve("{{data:search_value_254}}"));
        // v56 suppressed redundant Tosca keyboard steering: SearchValue9FCD1 CLICK
        // v56 suppressed redundant Tosca keyboard steering: SearchValue9FCD1 Tab
        await page.EnterSearchResult4E620Async(data.Resolve("{{data:search_result_255}}"));
        // v56 suppressed redundant Tosca keyboard steering: SearchResult4E620 Click
        // v56 suppressed redundant Tosca keyboard steering: SearchResult4E620 Enter
        // v56 suppressed redundant Tosca keyboard steering: SearchResult4E620 Tab
        await page.EnterConstructionCodeAsync(data.Resolve("{{data:construction_code_256}}"));
        // v56 suppressed redundant Tosca keyboard steering: ConstructionCode CLICK
        // v56 suppressed redundant Tosca keyboard steering: ConstructionCode Tab
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
        await page.EnterCoverageFormCFDD1Async(data.Resolve("{{data:coverage_form_260}}"));
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormCFDD1 CLICK
        // v56 suppressed redundant Tosca keyboard steering: CoverageFormCFDD1 Tab
        await page.ClickAddAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.EnterLimitOfInsuranceAsync(data.Resolve("{{data:limit_of_insurance_263}}"));
        // v56 suppressed redundant Tosca keyboard steering: LimitOfInsurance CLICK
        // v56 suppressed redundant Tosca keyboard steering: LimitOfInsurance Tab
        await page.EnterSignLocationAsync(data.Resolve("{{data:sign_location_264}}"));
        // v56 suppressed redundant Tosca keyboard steering: SignLocation CLICK
        // v56 suppressed redundant Tosca keyboard steering: SignLocation Tab
        await page.EnterTypeB082DAsync(data.Resolve("{{data:type_265}}"));
        // v56 suppressed redundant Tosca keyboard steering: TypeB082D CLICK
        // v56 suppressed redundant Tosca keyboard steering: TypeB082D Tab
        await page.EnterLetteringAsync(data.Resolve("{{data:lettering_266}}"));
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
        await page.EnterType715D6Async(data.Resolve("{{data:type_271}}"));
        // v56 suppressed redundant Tosca keyboard steering: Type715D6 CLICK
        // v56 suppressed redundant Tosca keyboard steering: Type715D6 Tab
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Names
        await page.EnterNamesAsync(data.Resolve("{{data:names_273}}"));
        // v56 suppressed redundant Tosca keyboard steering: Names CLICK
        // v56 suppressed redundant Tosca keyboard steering: Names Tab
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets Address
        await page.EnterAddressAsync(data.Resolve("{{data:address_275}}"));
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
        await page.EnterType715D6Async(data.Resolve("{{data:type_280}}"));
        await page.EnterLimit887C5Async(data.Resolve("{{data:limit_281}}"));
        await page.EnterDeductible0CC0AAsync(data.Resolve("{{data:deductible_282}}"));
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
        await page.EnterWhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStoredAsync(data.Resolve("{{data:what_is_the_construction_of_the_premises_where_the_receivables_are_stored_288}}"));
        // v56 suppressed redundant Tosca keyboard steering: WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored Tab
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft
        await page.EnterWhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheftAsync(data.Resolve("{{data:what_safeguards_are_in_place_for_receivables_to_protect_against_damage_or_theft_290}}"));
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
        await page.EnterDryCleaningAsync(data.Resolve("{{data:dry_cleaning_295}}"));
        // v56 suppressed redundant Tosca keyboard steering: DryCleaning CLICK
        // v56 suppressed redundant Tosca keyboard steering: DryCleaning Tab
        await page.EnterLaundryAsync(data.Resolve("{{data:laundry_296}}"));
        // v56 suppressed redundant Tosca keyboard steering: Laundry CLICK
        // v56 suppressed redundant Tosca keyboard steering: Laundry Tab
        await page.EnterN2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremisesAsync(data.Resolve("{{data:2_indicate_the_age_type_of_construction_and_protection_class_of_the_premises_297}}"));
        // v56 suppressed redundant Tosca keyboard steering: N2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremises CLICK
        // v56 suppressed redundant Tosca keyboard steering: N2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremises Tab
        await page.EnterN3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepairAsync(data.Resolve("{{data:3_what_is_the_percentage_of_annual_gross_receipts_derived_from_service_or_repair_298}}"));
        // v56 suppressed redundant Tosca keyboard steering: N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair CLICK
        // v56 suppressed redundant Tosca keyboard steering: N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair CLICK
        // v56 suppressed redundant Tosca keyboard steering: N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair Tab
        await page.EnterN4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdatedAsync(data.Resolve("{{data:4_what_method_do_you_use_for_keeping_records_of_property_in_your_care_and_how_often_are_the_records_updated_299}}"));
        // v56 suppressed redundant Tosca keyboard steering: N4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdated CLICK
        // v56 suppressed redundant Tosca keyboard steering: N4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdated Tab
        await page.EnterN5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintainedAsync(data.Resolve("{{data:5_are_recognized_approved_central_station_burglar_alarms_installed_and_maintained_300}}"));
        // v56 suppressed redundant Tosca keyboard steering: N5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintained CLICK
        // v56 suppressed redundant Tosca keyboard steering: N5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintained Tab
        await page.EnterN6AreAllStorageAreasLockedAtAllTimesWhenUnoccupiedAsync(data.Resolve("{{data:6_are_all_storage_areas_locked_at_all_times_when_unoccupied_301}}"));
        // v56 suppressed redundant Tosca keyboard steering: N6AreAllStorageAreasLockedAtAllTimesWhenUnoccupied CLICK
        // v56 suppressed redundant Tosca keyboard steering: N6AreAllStorageAreasLockedAtAllTimesWhenUnoccupied Tab
        await page.EnterN7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremisesAsync(data.Resolve("{{data:7_are_there_any_hazardous_or_flammable_materials_used_or_stored_on_the_premises_302}}"));
        // v56 suppressed redundant Tosca keyboard steering: N7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremises CLICK
        // v56 suppressed redundant Tosca keyboard steering: N7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremises Tab
        await page.EnterAWhatIsThePublicProtectionClassRatingAsync(data.Resolve("{{data:a_what_is_the_public_protection_class_rating_303}}"));
        // v56 suppressed redundant Tosca keyboard steering: AWhatIsThePublicProtectionClassRating CLICK
        // v56 suppressed redundant Tosca keyboard steering: AWhatIsThePublicProtectionClassRating CLICK
        // v56 suppressed redundant Tosca keyboard steering: AWhatIsThePublicProtectionClassRating Tab
        await page.EnterBAreThereAnyPrivateProtectionImprovementsAsync(data.Resolve("{{data:b_are_there_any_private_protection_improvements_304}}"));
        // v56 suppressed redundant Tosca keyboard steering: BAreThereAnyPrivateProtectionImprovements CLICK
        // v56 suppressed redundant Tosca keyboard steering: BAreThereAnyPrivateProtectionImprovements Tab
        await page.EnterCWhatIsTheDistanceInFeetToTheNearestHydrantAsync(data.Resolve("{{data:c_what_is_the_distance_in_feet_to_the_nearest_hydrant_305}}"));
        // v56 suppressed redundant Tosca keyboard steering: CWhatIsTheDistanceInFeetToTheNearestHydrant CLICK
        // v56 suppressed redundant Tosca keyboard steering: CWhatIsTheDistanceInFeetToTheNearestHydrant Tab
        await page.EnterDWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartmentAsync(data.Resolve("{{data:d_what_is_the_distance_in_miles_to_the_nearest_responding_fire_department_306}}"));
        // v56 suppressed redundant Tosca keyboard steering: DWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment CLICK
        // v56 suppressed redundant Tosca keyboard steering: DWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment Tab
        await page.EnterEAreNoSmokingRulesPostedAndEnforcedAsync(data.Resolve("{{data:e_are_no_smoking_rules_posted_and_enforced_307}}"));
        // v56 suppressed redundant Tosca keyboard steering: EAreNoSmokingRulesPostedAndEnforced CLICK
        // v56 suppressed redundant Tosca keyboard steering: EAreNoSmokingRulesPostedAndEnforced Tab
        await page.EnterN9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystemAsync(data.Resolve("{{data:9_are_the_premises_or_any_portion_of_the_premises_equipped_with_a_sprinkler_system_308}}"));
        // v56 suppressed redundant Tosca keyboard steering: N9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystem CLICK
        // v56 suppressed redundant Tosca keyboard steering: N9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystem Tab
        await page.EnterN10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarmsAsync(data.Resolve("{{data:10_are_the_premises_equipped_with_a_recognized_approved_central_station_fire_alarm_fire_extinguishers_or_smoke_alarms_309}}"));
        // v56 suppressed redundant Tosca keyboard steering: N10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarms CLICK
        // v56 suppressed redundant Tosca keyboard steering: N10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarms Tab
        await page.EnterN11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransitAsync(data.Resolve("{{data:11_what_is_the_procedure_for_transporting_property_include_the_transit_methods_used_and_the_protection_class_provided_while_in_transit_310}}"));
        // v56 suppressed redundant Tosca keyboard steering: N11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransit CLICK
        // v56 suppressed redundant Tosca keyboard steering: N11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransit Tab
        await page.EnterN12AreDriversMVRsReviewedOnARegularBasisAndMaintainedAsync(data.Resolve("{{data:12_are_drivers_mvrs_reviewed_on_a_regular_basis_and_maintained_311}}"));
        // v56 suppressed redundant Tosca keyboard steering: N12AreDriversMVRsReviewedOnARegularBasisAndMaintained CLICK
        // v56 suppressed redundant Tosca keyboard steering: N12AreDriversMVRsReviewedOnARegularBasisAndMaintained Tab
        await page.EnterN13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicleAsync(data.Resolve("{{data:13_what_types_of_vehicles_do_you_operate_and_what_protective_devices_are_on_each_vehicle_312}}"));
        // v56 suppressed redundant Tosca keyboard steering: N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle CLICK
        // v56 suppressed redundant Tosca keyboard steering: N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle CLICK
        // v56 suppressed redundant Tosca keyboard steering: N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle Tab
        await page.EnterN14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorageAsync(data.Resolve("{{data:14_what_is_your_procedure_for_protecting_small_items_from_breakage_or_disappearance_while_in_storage_313}}"));
        // v56 suppressed redundant Tosca keyboard steering: N14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorage CLICK
        // v56 suppressed redundant Tosca keyboard steering: N14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorage Tab
        await page.EnterN15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheftAsync(data.Resolve("{{data:15_what_measures_does_the_insured_take_to_protect_customer_s_property_against_theft_314}}"));
        // v56 suppressed redundant Tosca keyboard steering: N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft CLICK
        // v56 suppressed redundant Tosca keyboard steering: N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft CLICK
        // v56 suppressed redundant Tosca keyboard steering: N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft Tab
        await page.EnterN16DoesTheRiskUseReleaseFormsAsync(data.Resolve("{{data:16_does_the_risk_use_release_forms_315}}"));
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
        await page.EnterWhatIsTheProcedureForTransportingTheComputerEquipmentAsync(data.Resolve("{{data:what_is_the_procedure_for_transporting_the_computer_equipment_320}}"));
        // v56 suppressed redundant Tosca keyboard steering: WhatIsTheProcedureForTransportingTheComputerEquipment CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatIsTheProcedureForTransportingTheComputerEquipment Tab
        await page.EnterIndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocatedAsync(data.Resolve("{{data:indicate_the_building_s_age_type_of_construction_and_protection_class_and_other_tenants_in_the_building_s_where_the_computer_equipment_is_located_321}}"));
        // v56 suppressed redundant Tosca keyboard steering: IndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocated CLICK
        // v56 suppressed redundant Tosca keyboard steering: IndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocated Tab
        await page.EnterWhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecuredAsync(data.Resolve("{{data:what_are_the_procedures_and_methods_for_keeping_the_edp_areas_secured_322}}"));
        // v56 suppressed redundant Tosca keyboard steering: WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured Tab
        await page.EnterWhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorageAsync(data.Resolve("{{data:what_are_the_procedures_and_schedule_for_backing_up_the_media_and_data_and_their_storage_323}}"));
        // v56 suppressed redundant Tosca keyboard steering: WhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorage CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorage Tab
        await page.EnterProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMediaAsync(data.Resolve("{{data:provide_information_regarding_antivirus_methods_and_copyright_protection_of_data_and_media_324}}"));
        // v56 suppressed redundant Tosca keyboard steering: ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia CLICK
        // v56 suppressed redundant Tosca keyboard steering: ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia CLICK
        // v56 suppressed redundant Tosca keyboard steering: ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia Tab
        await page.EnterWhatIsThePublicProtectionClassRatingAsync(data.Resolve("{{data:what_is_the_public_protection_class_rating_325}}"));
        // v56 suppressed redundant Tosca keyboard steering: WhatIsThePublicProtectionClassRating CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatIsThePublicProtectionClassRating CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatIsThePublicProtectionClassRating CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatIsThePublicProtectionClassRating Tab
        await page.EnterWhatIsTheDistanceInFeetToTheNearestFireHydrantAsync(data.Resolve("{{data:what_is_the_distance_in_feet_to_the_nearest_fire_hydrant_326}}"));
        // v56 suppressed redundant Tosca keyboard steering: WhatIsTheDistanceInFeetToTheNearestFireHydrant CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatIsTheDistanceInFeetToTheNearestFireHydrant CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatIsTheDistanceInFeetToTheNearestFireHydrant Tab
        await page.EnterWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartmentAsync(data.Resolve("{{data:what_is_the_distance_in_miles_to_the_nearest_responding_fire_department_327}}"));
        // v56 suppressed redundant Tosca keyboard steering: WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment CLICK
        // v56 suppressed redundant Tosca keyboard steering: WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment Tab
        await page.EnterUninterruptiblePowerSourceAsync(data.Resolve("{{data:uninterruptible_power_source_328}}"));
        // v56 suppressed redundant Tosca keyboard steering: UninterruptiblePowerSource CLICK
        // v56 suppressed redundant Tosca keyboard steering: UninterruptiblePowerSource Tab
        await page.EnterLineConditionerAsync(data.Resolve("{{data:line_conditioner_329}}"));
        // v56 suppressed redundant Tosca keyboard steering: LineConditioner CLICK
        // v56 suppressed redundant Tosca keyboard steering: LineConditioner Tab
        await page.EnterPowerSuppressorVoltageRegulatorAsync(data.Resolve("{{data:power_suppressor_voltage_regulator_330}}"));
        // v56 suppressed redundant Tosca keyboard steering: PowerSuppressorVoltageRegulator CLICK
        // v56 suppressed redundant Tosca keyboard steering: PowerSuppressorVoltageRegulator Tab
        await page.EnterDedicatedLineAsync(data.Resolve("{{data:dedicated_line_331}}"));
        // v56 suppressed redundant Tosca keyboard steering: DedicatedLine CLICK
        // v56 suppressed redundant Tosca keyboard steering: DedicatedLine Tab
        await page.EnterHowOftenIsDataBackedUpAsync(data.Resolve("{{data:how_often_is_data_backed_up_332}}"));
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
        await page.EnterEstimatedHighestValueAsync(data.Resolve("{{data:estimated_highest_value_338}}"));
        // v56 suppressed redundant Tosca keyboard steering: EstimatedHighestValue CLICK
        // v56 suppressed redundant Tosca keyboard steering: EstimatedHighestValue Tab
        await page.EnterIfYesDescribeAsync(data.Resolve("{{data:if_yes_describe_339}}"));
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
        await page.EnterWhichFormAreYouCompletingAsync(data.Resolve("{{data:which_form_are_you_completing_344}}"));
        // v56 suppressed Tosca focus-navigation TAB: direct Playwright locator targets N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment
        await page.EnterN1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipmentAsync(data.Resolve("{{data:1_what_are_the_distances_the_shipments_will_travel_and_the_time_required_to_complete_the_shipment_346}}"));
        // v56 suppressed redundant Tosca keyboard steering: N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment CLICK
        // v56 suppressed redundant Tosca keyboard steering: N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment CLICK
        // v56 suppressed redundant Tosca keyboard steering: N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment Tab
        await page.EnterN2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommoditiesAsync(data.Resolve("{{data:2_what_are_the_types_and_ages_of_the_vehicles_trailers_used_to_transport_your_commodities_347}}"));
        // v56 suppressed redundant Tosca keyboard steering: N2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommodities CLICK
        // v56 suppressed redundant Tosca keyboard steering: N2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommodities Tab
        await page.EnterN3DoesTheApplicantHaulForOthersAsync(data.Resolve("{{data:3_does_the_applicant_haul_for_others_348}}"));
        // v56 suppressed redundant Tosca keyboard steering: N3DoesTheApplicantHaulForOthers CLICK
        // v56 suppressed redundant Tosca keyboard steering: N3DoesTheApplicantHaulForOthers Tab
        await page.EnterN4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailerAsync(data.Resolve("{{data:4_what_protective_devices_are_installed_on_each_vehicle_or_trailer_349}}"));
        // v56 suppressed redundant Tosca keyboard steering: N4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailer CLICK
        // v56 suppressed redundant Tosca keyboard steering: N4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailer Tab
        await page.EnterN5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttachedAsync(data.Resolve("{{data:5_do_any_vehicles_have_special_equipment_mounted_or_attached_350}}"));
        // v56 suppressed redundant Tosca keyboard steering: N5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttached CLICK
        // v56 suppressed redundant Tosca keyboard steering: N5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttached Tab
        await page.EnterN6DoesTheApplicantPullDoubleOrTripleTrailersAsync(data.Resolve("{{data:6_does_the_applicant_pull_double_or_triple_trailers_351}}"));
        // v56 suppressed redundant Tosca keyboard steering: N6DoesTheApplicantPullDoubleOrTripleTrailers CLICK
        // v56 suppressed redundant Tosca keyboard steering: N6DoesTheApplicantPullDoubleOrTripleTrailers Tab
        await page.EnterN7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattendedAsync(data.Resolve("{{data:7_does_the_applicant_leave_the_truck_windows_doors_and_compartments_closed_and_locked_when_unattended_352}}"));
        // v56 suppressed redundant Tosca keyboard steering: N7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattended CLICK
        // v56 suppressed redundant Tosca keyboard steering: N7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattended Tab
        await page.EnterN8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperateAsync(data.Resolve("{{data:8_do_you_provide_scheduled_maintenance_for_the_vehicles_and_trailers_you_operate_353}}"));
        // v56 suppressed redundant Tosca keyboard steering: N8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperate CLICK
        // v56 suppressed redundant Tosca keyboard steering: N8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperate Tab
        await page.EnterN9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommoditiesAsync(data.Resolve("{{data:9_are_the_employees_that_pack_load_and_unload_trained_in_proper_handling_of_the_commodities_354}}"));
        // v56 suppressed redundant Tosca keyboard steering: N9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommodities CLICK
        // v56 suppressed redundant Tosca keyboard steering: N9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommodities Tab
        await page.EnterN10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheftAsync(data.Resolve("{{data:10_how_are_the_goods_being_transported_protected_from_damage_and_theft_355}}"));
        // v56 suppressed redundant Tosca keyboard steering: N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft CLICK
        // v56 suppressed redundant Tosca keyboard steering: N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft Tab
        await page.EnterN11AreDriversMVRsAndTripLogsMaintainedAsync(data.Resolve("{{data:11_are_drivers_mvrs_and_trip_logs_maintained_356}}"));
        // v56 suppressed redundant Tosca keyboard steering: N11AreDriversMVRsAndTripLogsMaintained CLICK
        // v56 suppressed redundant Tosca keyboard steering: N11AreDriversMVRsAndTripLogsMaintained Tab
        await page.EnterN12HowOftenAreTheseLogsReviewedOrUpdatedAsync(data.Resolve("{{data:12_how_often_are_these_logs_reviewed_or_updated_357}}"));
        // v56 suppressed redundant Tosca keyboard steering: N12HowOftenAreTheseLogsReviewedOrUpdated CLICK
        // v56 suppressed redundant Tosca keyboard steering: N12HowOftenAreTheseLogsReviewedOrUpdated Tab
        await page.EnterN13LiveAnimalInTransitCoverageAsync(data.Resolve("{{data:13_live_animal_in_transit_coverage_358}}"));
        // v56 suppressed redundant Tosca keyboard steering: N13LiveAnimalInTransitCoverage CLICK
        // v56 suppressed redundant Tosca keyboard steering: N13LiveAnimalInTransitCoverage Tab
        await page.EnterN14LegalLiabilityCoverageAsync(data.Resolve("{{data:14_legal_liability_coverage_359}}"));
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
        await page.EnterAreAnySignsOffPremisesOrNotAttachedToBuildingAsync(data.Resolve("{{data:are_any_signs_off_premises_or_not_attached_to_building_364}}"));
        await page.EnterDoesTheApplicantWishToCoverAnySignsInsideTheirPremisesAsync(data.Resolve("{{data:does_the_applicant_wish_to_cover_any_signs_inside_their_premises_365}}"));
        await page.EnterWhatIsTheConstructionOfEachSignAsync(data.Resolve("{{data:what_is_the_construction_of_each_sign_366}}"));
        await page.ClickSpecificUnderwritingQuestionsSignsOKAsync();

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
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_370}}"));
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_373}}"));
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_377}}"));
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
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_388}}"));
        // v56 suppressed redundant Tosca keyboard steering: IsThisCoverageBound CLICK
        // v56 suppressed redundant Tosca keyboard steering: IsThisCoverageBound Tab
        await page.VerifyOrderAuditAsync("Exists", "");
        await page.EnterOrderAuditAsync(data.Resolve("{{data:order_audit_390}}"));
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
        await page.VerifyIsThisCoverageBoundAsync(data.Resolve("{{data:expected_is_this_coverage_bound_value_398}}"), "Value");
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_399}}"));
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
        await page.VerifyFullTermPremiumAsync(data.Resolve("{{data:expected_full_term_premium_value_431}}"), "value");
        await page.VerifyPremiumWrittenAsync(data.Resolve("{{data:expected_premium_written_value_432}}"), "value");
        await page.VerifyPriorPremiumAsync(data.Resolve("{{data:expected_prior_premium_value_433}}"), "value");
        await page.VerifyPremiumChangeAsync(data.Resolve("{{data:expected_premium_change_value_434}}"), "value");
        await page.EnterTitleAsync(data.Resolve("{{data:title_436}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_437}}"));
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
        await page.VerifyStatusCodeAsync(data.Resolve("{{data:expected_statuscode_value_441}}"), "value");
        await page.PauseAsync(1000);
        await page.PauseAsync(1000);

    }

}
