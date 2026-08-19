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
        await page.PressInsuredTypeAsync("Enter");
        await page.PressInsuredTypeAsync("Tab");
        await page.PressInsuredTypeAsync("Tab");
        await page.ClickEntityTypeAsync();
        await page.WaitForBusinessNameAsync("Visible");
        await page.EnterBusinessNameAsync(data.Resolve("{{data:business_name_7}}"));
        await page.PressBusinessNameAsync("Tab");
        await page.EnterEntityTypeAsync(data.Resolve("{{data:entity_type_8}}"));
        await page.PressEntityTypeAsync("Tab");
        // Source step 0041: RANDOM input for Primary Phone.
        await page.EnterPrimaryPhoneAsync(data.Resolve("{{runtime:PrimaryPhone_0041}}"));
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
        // Source step 0045: RANDOM input for Audit Telephone #.
        if (data.Condition("'Product (LOB)' != \"UMB\""))
        {
            await page.EnterAuditTelephoneAsync(data.Resolve("{{runtime:AuditTelephone_0045}}"));
        }
        await page.EnterNameOfInspectionContactAsync(data.Resolve("{{data:name_of_inspection_contact_18}}"));
        await page.PressNameOfInspectionContactAsync("Tab");
        await page.PressNameOfInspectionContactAsync("Tab");
        await page.PressNameOfInspectionContactAsync("CLICK");
        await page.PressNameOfInspectionContactAsync("CLICK");
        await page.PressNameOfInspectionContactAsync("Tab");
        // Source step 0045: RANDOM input for Inspection Telephone #.
        await page.EnterInspectionTelephoneAsync(data.Resolve("{{runtime:InspectionTelephone_0045}}"));
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
        // Source step 0057: RANDOM input for MiddleName.
        await page.EnterMiddleNameAsync(data.Resolve("{{runtime:MiddleName_0057}}"));
        await page.PressFirstNameC5387Async("TAB");
        await page.PressFirstNameC5387Async("Tab");
        // Source step 0057: RANDOM input for LastName.
        await page.EnterLastNameAsync(data.Resolve("{{runtime:LastName_0057}}"));
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
        // Source RANDOM FirstName entered after Client Search per Tosca source step.
        await page.EnterFirstName55A0BAsync(data.Resolve("{{runtime:FirstName_0057}}"));
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
        await page.PressIsThereAPriorCarrierAsync("Tab");
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
        await page.PressEffectiveDate95094Async("Tab");
        if (data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
                    await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_99}}"));
                    await page.PressYearsInBusinessAsync("Tab");
        }
        await page.PauseAsync(1000);
        if (data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_101}}"));
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
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_105}}"));
        await page.PressWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync("Tab");
        await page.PressWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync("Tab");
        await page.PauseAsync(1000);
        if (data.Condition("'Product (LOB)' != \"WC\""))
        {
                    await page.WaitForPrimaryRatingStateAsync("Exists");
        }
        if (data.Condition("'Product (LOB)' != \"WC\""))
        {
                    await page.PressPrimaryRatingStateAsync("TAB");
        }
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_111}}"));
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
        await page.EnterDescriptionOfSpecifiedOperationAsync("AZ IM Basic {NMONTH}.{NDAY}.{NYEAR} {Time}");
        await page.PressDescriptionOfSpecifiedOperationAsync("Tab");
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
        await page.PressCoverageFormToBeAddedAsync("Tab");
        await page.PressCoverageFormToBeAddedAsync("CLICK");
        await page.PressCoverageFormToBeAddedAsync("Enter");
        await page.PressCoverageFormToBeAddedAsync("Tab");
        await page.ClickAddCoverageFormAsync();
        await page.EnterDescriptionAsync(data.Resolve("{{data:description_136}}"));
        await page.PressDescriptionAsync("Tab");
        await page.PressDescriptionAsync("CLICK");
        await page.PressDescriptionAsync("Enter");
        await page.EnterCoinsuranceAsync(data.Resolve("{{data:coinsurance_137}}"));
        await page.PressCoinsuranceAsync("Tab");
        await page.PressCoinsuranceAsync("CLICK");
        await page.EnterAwayFromPremisesLmtAsync(data.Resolve("{{data:away_from_premises_lmt_138}}"));
        await page.PressAwayFromPremisesLmtAsync("Tab");
        await page.PressAwayFromPremisesLmtAsync("CLICK");
        await page.EnterAwayFromPremisesDescAsync(data.Resolve("{{data:away_from_premises_desc_139}}"));
        await page.PressAwayFromPremisesDescAsync("Tab");
        await page.PressAwayFromPremisesDescAsync("CLICK");
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
        await page.PressCoverageFormToBeAddedAsync("Tab");
        await page.PressCoverageFormToBeAddedAsync("CLICK");
        await page.PressCoverageFormToBeAddedAsync("Enter");
        await page.PressCoverageFormToBeAddedAsync("Tab");
        await page.ClickAddCoverageFormAsync();
        await page.WaitForCoverageFormDisplay6F446Async("Exists");
        await page.PressDescription43F2DAsync("TAB");
        await page.EnterDescription43F2DAsync(data.Resolve("{{data:description_147}}"));
        await page.PressDescription43F2DAsync("CLICK");
        await page.PressDescription43F2DAsync("Enter");
        await page.PressDescription43F2DAsync("Tab");
        await page.EnterPropertyInTransit710FFAsync(data.Resolve("{{data:property_in_transit_148}}"));
        await page.PressPropertyInTransit710FFAsync("Tab");
        await page.PressPropertyInTransit710FFAsync("Tab");
        await page.ClickPropertyAwayFromYourPremisesScheduleAsync();
        await page.ClickAddPremisesAsync();
        await page.EnterAddressStreetCityStateZipAsync(data.Resolve("{{data:address_street_city_state_zip_151}}"));
        await page.PressAddressStreetCityStateZipAsync("CLICK");
        await page.PressAddressStreetCityStateZipAsync("Tab");
        await page.EnterLimit46632Async(data.Resolve("{{data:limit_152}}"));
        await page.PressLimit46632Async("Tab");
        await page.PressLimit46632Async("Tab");
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
        await page.PressCoverageFormToBeAddedAsync("Tab");
        await page.PressCoverageFormToBeAddedAsync("CLICK");
        await page.PressCoverageFormToBeAddedAsync("Enter");
        await page.PressCoverageFormToBeAddedAsync("Tab");
        await page.ClickAddCoverageFormAsync();
        await page.WaitForCoverageFormDisplayD1A9BAsync("Exists");
        await page.PressDescription03789Async("TAB");
        await page.EnterDescription03789Async(data.Resolve("{{data:description_162}}"));
        await page.PressDescription03789Async("Tab");
        await page.PressDescription03789Async("CLICK");
        await page.PressDescription03789Async("Tab");
        await page.EnterCoinsuranceC9726Async(data.Resolve("{{data:coinsurance_163}}"));
        await page.PressCoinsuranceC9726Async("Tab");
        await page.PressCoinsuranceC9726Async("CLICK");
        await page.PressCoinsuranceC9726Async("Tab");
        await page.EnterDeductibleC227CAsync(data.Resolve("{{data:deductible_164}}"));
        await page.PressDeductibleC227CAsync("Tab");
        await page.PressDeductibleC227CAsync("CLICK");
        await page.PressDeductibleC227CAsync("Tab");
        await page.EnterBoomDeductibleAsync(data.Resolve("{{data:boom_deductible_165}}"));
        await page.PressBoomDeductibleAsync("Tab");
        await page.PressBoomDeductibleAsync("CLICK");
        await page.PressBoomDeductibleAsync("Tab");
        await page.EnterTypeOfContractorAsync(data.Resolve("{{data:type_of_contractor_166}}"));
        await page.PressTypeOfContractorAsync("Tab");
        await page.PressTypeOfContractorAsync("CLICK");
        await page.PressTypeOfContractorAsync("Tab");
        await page.EnterScheduledCoverageAsync(data.Resolve("{{data:scheduled_coverage_167}}"));
        await page.PressScheduledCoverageAsync("Tab");
        await page.PressScheduledCoverageAsync("CLICK");
        await page.PressScheduledCoverageAsync("Tab");
        await page.EnterRentedEquipmentExpenseAsync(data.Resolve("{{data:rented_equipment_expense_168}}"));
        await page.PressRentedEquipmentExpenseAsync("Tab");
        await page.PressRentedEquipmentExpenseAsync("CLICK");
        await page.PressRentedEquipmentExpenseAsync("Tab");
        await page.EnterToolsAndClothingBelongingToYourEmployeesAsync(data.Resolve("{{data:tools_and_clothing_belonging_to_your_employees_169}}"));
        await page.PressToolsAndClothingBelongingToYourEmployeesAsync("Tab");
        await page.PressToolsAndClothingBelongingToYourEmployeesAsync("CLICK");
        await page.PressToolsAndClothingBelongingToYourEmployeesAsync("Tab");
        await page.EnterMiscItemsBlanketCoverageAsync(data.Resolve("{{data:misc_items_blanket_coverage_170}}"));
        await page.PressMiscItemsBlanketCoverageAsync("Tab");
        await page.PressMiscItemsBlanketCoverageAsync("CLICK");
        await page.PressMiscItemsBlanketCoverageAsync("Tab");
        await page.EnterRentalReimbursementAsync(data.Resolve("{{data:rental_reimbursement_171}}"));
        await page.PressRentalReimbursementAsync("Tab");
        await page.PressRentalReimbursementAsync("CLICK");
        await page.PressRentalReimbursementAsync("Tab");
        await page.EnterHiredEquipmentAsync(data.Resolve("{{data:hired_equipment_172}}"));
        await page.PressHiredEquipmentAsync("Tab");
        await page.PressHiredEquipmentAsync("CLICK");
        await page.PressHiredEquipmentAsync("Tab");
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
        await page.PressCoverageFormToBeAddedAsync("Tab");
        await page.PressCoverageFormToBeAddedAsync("CLICK");
        await page.PressCoverageFormToBeAddedAsync("Enter");
        await page.PressCoverageFormToBeAddedAsync("Tab");
        await page.ClickAddCoverageFormAsync();
        await page.WaitForCoverageFormDisplay2ECD4Async("Exists");
        await page.PressDescription58EC2Async("TAB");
        await page.EnterDescription58EC2Async(data.Resolve("{{data:description_180}}"));
        await page.PressDescription58EC2Async("CLICK");
        await page.PressDescription58EC2Async("Enter");
        await page.PressDescription58EC2Async("Tab");
        await page.EnterDeductibleC91E9Async(data.Resolve("{{data:deductible_181}}"));
        await page.PressDeductibleC91E9Async("Tab");
        await page.PressDeductibleC91E9Async("Tab");
        await page.EnterCoinsurance01AB1Async(data.Resolve("{{data:coinsurance_182}}"));
        await page.PressCoinsurance01AB1Async("Tab");
        await page.PressCoinsurance01AB1Async("Tab");
        await page.EnterPropertyInTransit6E905Async(data.Resolve("{{data:property_in_transit_183}}"));
        await page.PressPropertyInTransit6E905Async("Tab");
        await page.PressPropertyInTransit6E905Async("Tab");
        await page.EnterUnnamedPremisesAsync(data.Resolve("{{data:unnamed_premises_184}}"));
        await page.PressUnnamedPremisesAsync("Tab");
        await page.PressUnnamedPremisesAsync("Tab");
        await page.EnterPersonalPortableComputersAsync(data.Resolve("{{data:personal_portable_computers_185}}"));
        await page.PressPersonalPortableComputersAsync("Tab");
        await page.PressPersonalPortableComputersAsync("Tab");
        await page.EnterExtraExpenseAsync(data.Resolve("{{data:extra_expense_186}}"));
        await page.PressExtraExpenseAsync("Tab");
        await page.PressExtraExpenseAsync("Tab");
        await page.EnterVirusHarmfulCodeOrSimilarInstructionAsync(data.Resolve("{{data:virus_harmful_code_or_similar_instruction_187}}"));
        await page.PressVirusHarmfulCodeOrSimilarInstructionAsync("Tab");
        await page.PressVirusHarmfulCodeOrSimilarInstructionAsync("Tab");
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
        await page.PressCoverageFormToBeAddedAsync("Tab");
        await page.PressCoverageFormToBeAddedAsync("CLICK");
        await page.PressCoverageFormToBeAddedAsync("Enter");
        await page.PressCoverageFormToBeAddedAsync("Tab");
        await page.ClickAddCoverageFormAsync();
        await page.WaitForCoverageFormDisplayB69C2Async("Exists");
        await page.PressDescriptionF8E60Async("TAB");
        await page.EnterDescriptionF8E60Async(data.Resolve("{{data:description_195}}"));
        await page.PressDescriptionF8E60Async("Tab");
        await page.PressDescriptionF8E60Async("CLICK");
        await page.PressDescriptionF8E60Async("Enter");
        await page.PressDescriptionF8E60Async("Tab");
        await page.EnterCoverageTypeAsync(data.Resolve("{{data:coverage_type_196}}"));
        await page.PressCoverageTypeAsync("Tab");
        await page.PressCoverageTypeAsync("Tab");
        await page.PressCoverageTypeAsync("Tab");
        await page.EnterCoveredPropertyConsistingPrincipallyOfAsync(data.Resolve("{{data:covered_property_consisting_principally_of_197}}"));
        await page.PressCoveredPropertyConsistingPrincipallyOfAsync("Tab");
        await page.PressCoveredPropertyConsistingPrincipallyOfAsync("Tab");
        await page.EnterDeductible320C9Async(data.Resolve("{{data:deductible_198}}"));
        await page.PressDeductible320C9Async("Tab");
        await page.PressDeductible320C9Async("Tab");
        await page.EnterPerVehicleLimitAsync(data.Resolve("{{data:per_vehicle_limit_199}}"));
        await page.PressPerVehicleLimitAsync("Tab");
        await page.PressPerVehicleLimitAsync("Tab");
        await page.EnterGroupClassAsync(data.Resolve("{{data:group_class_200}}"));
        await page.PressGroupClassAsync("Tab");
        await page.PressGroupClassAsync("Tab");
        await page.EnterNumberOfVehiclesAsync(data.Resolve("{{data:number_of_vehicles_201}}"));
        await page.PressNumberOfVehiclesAsync("Tab");
        await page.PressNumberOfVehiclesAsync("Tab");
        await page.EnterUnnamedTerminalsLimitAsync(data.Resolve("{{data:unnamed_terminals_limit_202}}"));
        await page.PressUnnamedTerminalsLimitAsync("Tab");
        await page.PressUnnamedTerminalsLimitAsync("Tab");
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
        await page.PressCoverageFormToBeAddedAsync("Tab");
        await page.PressCoverageFormToBeAddedAsync("CLICK");
        await page.PressCoverageFormToBeAddedAsync("Enter");
        await page.PressCoverageFormToBeAddedAsync("Tab");
        await page.ClickAddCoverageFormAsync();
        await page.WaitForCoverageFormDisplayC10BAAsync("Exists");
        await page.PressDescriptionBE47EAsync("TAB");
        await page.EnterDescriptionBE47EAsync(data.Resolve("{{data:description_210}}"));
        await page.PressDescriptionBE47EAsync("Tab");
        await page.PressDescriptionBE47EAsync("CLICK");
        await page.PressDescriptionBE47EAsync("Enter");
        await page.PressDescriptionBE47EAsync("Tab");
        await page.VerifyCoverageFormA7F96Async("Exists", "");
        await page.EnterN5DeductibleAsync(data.Resolve("{{data:5_deductible_212}}"));
        await page.PressN5DeductibleAsync("Tab");
        await page.PressN5DeductibleAsync("Tab");
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
        await page.PressCoverageFormCFDD1Async("Tab");
        await page.PressCoverageFormCFDD1Async("CLICK");
        await page.PressCoverageFormCFDD1Async("Tab");
        await page.ClickAddAsync();
        await page.WaitForAccountsReceivableHeadingAsync("Exists");
        await page.PressSearchValue79E46Async("TAB");
        await page.EnterSearchValue79E46Async(data.Resolve("{{data:search_value_221}}"));
        await page.PressSearchValue79E46Async("Tab");
        await page.PressSearchValue79E46Async("CLICK");
        await page.PressSearchValue79E46Async("Tab");
        await page.EnterSearchResultEAFB8Async(data.Resolve("{{data:search_result_222}}"));
        await page.PressSearchResultEAFB8Async("Tab");
        await page.PressSearchResultEAFB8Async("CLICK");
        await page.PressSearchResultEAFB8Async("Enter");
        await page.PressSearchResultEAFB8Async("Tab");
        await page.EnterConstructionFB8D9Async(data.Resolve("{{data:construction_223}}"));
        await page.PressConstructionFB8D9Async("Tab");
        await page.PressConstructionFB8D9Async("CLICK");
        await page.PressConstructionFB8D9Async("Tab");
        await page.EnterPremisesTypeAsync(data.Resolve("{{data:premises_type_224}}"));
        await page.PressPremisesTypeAsync("Tab");
        await page.PressPremisesTypeAsync("CLICK");
        await page.PressPremisesTypeAsync("Tab");
        await page.EnterDuplicatedRecordsAsync(data.Resolve("{{data:duplicated_records_225}}"));
        await page.PressDuplicatedRecordsAsync("Tab");
        await page.PressDuplicatedRecordsAsync("CLICK");
        await page.PressDuplicatedRecordsAsync("Tab");
        await page.EnterClassificationOfRiskAsync(data.Resolve("{{data:classification_of_risk_226}}"));
        await page.PressClassificationOfRiskAsync("Tab");
        await page.PressClassificationOfRiskAsync("CLICK");
        await page.PressClassificationOfRiskAsync("Tab");
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
        await page.PressCoverageFormCFDD1Async("Tab");
        await page.PressCoverageFormCFDD1Async("CLICK");
        await page.PressCoverageFormCFDD1Async("Tab");
        await page.ClickAddAsync();
        await page.WaitForBaileesCustomersHeadingAsync("Exists");
        await page.EnterDeductible59155Async(data.Resolve("{{data:deductible_233}}"));
        await page.PressDeductible59155Async("Tab");
        await page.PressDeductible59155Async("CLICK");
        await page.PressDeductible59155Async("Tab");
        await page.PressSearchValueCA6A6Async("TAB");
        await page.EnterSearchValueCA6A6Async(data.Resolve("{{data:search_value_235}}"));
        await page.PressSearchValueCA6A6Async("CLICK");
        await page.PressSearchValueCA6A6Async("Tab");
        await page.PressSearchValueCA6A6Async("Tab");
        await page.EnterSearchResultA1BFBAsync(data.Resolve("{{data:search_result_236}}"));
        await page.PressSearchResultA1BFBAsync("Tab");
        await page.PressSearchResultA1BFBAsync("CLICK");
        await page.PressSearchResultA1BFBAsync("Enter");
        await page.PressSearchResultA1BFBAsync("Tab");
        await page.EnterConstructionCD2DEAsync(data.Resolve("{{data:construction_237}}"));
        await page.PressConstructionCD2DEAsync("Tab");
        await page.PressConstructionCD2DEAsync("CLICK");
        await page.PressConstructionCD2DEAsync("Tab");
        await page.EnterAnnualGrossReceiptsAsync(data.Resolve("{{data:annual_gross_receipts_238}}"));
        await page.PressAnnualGrossReceiptsAsync("Tab");
        await page.PressAnnualGrossReceiptsAsync("CLICK");
        await page.PressAnnualGrossReceiptsAsync("Tab");
        await page.EnterAverageNumberOfDaysServiceAsync(data.Resolve("{{data:average_number_of_days_service_239}}"));
        await page.PressAverageNumberOfDaysServiceAsync("Tab");
        await page.PressAverageNumberOfDaysServiceAsync("CLICK");
        await page.PressAverageNumberOfDaysServiceAsync("Tab");
        await page.EnterAverageNumberOfWorkingDaysAsync(data.Resolve("{{data:average_number_of_working_days_240}}"));
        await page.PressAverageNumberOfWorkingDaysAsync("Tab");
        await page.PressAverageNumberOfWorkingDaysAsync("CLICK");
        await page.PressAverageNumberOfWorkingDaysAsync("Tab");
        await page.EnterAverageServiceChargeAsync(data.Resolve("{{data:average_service_charge_241}}"));
        await page.PressAverageServiceChargeAsync("Tab");
        await page.PressAverageServiceChargeAsync("CLICK");
        await page.PressAverageServiceChargeAsync("Tab");
        await page.EnterAverageValuePerOrderAsync(data.Resolve("{{data:average_value_per_order_242}}"));
        await page.PressAverageValuePerOrderAsync("Tab");
        await page.PressAverageValuePerOrderAsync("CLICK");
        await page.PressAverageValuePerOrderAsync("Tab");
        await page.EnterLimitE32DCAsync(data.Resolve("{{data:limit_243}}"));
        await page.PressLimitE32DCAsync("Tab");
        await page.PressLimitE32DCAsync("CLICK");
        await page.PressLimitE32DCAsync("Tab");
        await page.EnterEarthquakeAsync(data.Resolve("{{data:earthquake_244}}"));
        await page.PressEarthquakeAsync("Tab");
        await page.PressEarthquakeAsync("CLICK");
        await page.PressEarthquakeAsync("Tab");
        await page.EnterStorageLimitAsync(data.Resolve("{{data:storage_limit_245}}"));
        await page.PressStorageLimitAsync("Tab");
        await page.PressStorageLimitAsync("CLICK");
        await page.PressStorageLimitAsync("Tab");
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
        await page.PressCoverageFormCFDD1Async("Tab");
        await page.PressCoverageFormCFDD1Async("CLICK");
        await page.PressCoverageFormCFDD1Async("Tab");
        await page.ClickAddAsync();
        await page.EnterComputerEquipmentAsync(data.Resolve("{{data:computer_equipment_251}}"));
        await page.PressComputerEquipmentAsync("Tab");
        await page.PressComputerEquipmentAsync("CLICK");
        await page.PressComputerEquipmentAsync("Tab");
        await page.EnterDataAndMediaAsync(data.Resolve("{{data:data_and_media_252}}"));
        await page.PressDataAndMediaAsync("Tab");
        await page.PressDataAndMediaAsync("CLICK");
        await page.PressDataAndMediaAsync("Tab");
        await page.PressSearchValue9FCD1Async("TAB");
        await page.EnterSearchValue9FCD1Async(data.Resolve("{{data:search_value_254}}"));
        await page.PressSearchValue9FCD1Async("CLICK");
        await page.PressSearchValue9FCD1Async("Tab");
        await page.PressSearchValue9FCD1Async("Tab");
        await page.EnterSearchResult4E620Async(data.Resolve("{{data:search_result_255}}"));
        await page.PressSearchResult4E620Async("Tab");
        await page.PressSearchResult4E620Async("Click");
        await page.PressSearchResult4E620Async("Enter");
        await page.PressSearchResult4E620Async("Tab");
        await page.PressSearchResult4E620Async("Tab");
        await page.PressSearchResult4E620Async("Tab");
        await page.EnterConstructionCodeAsync(data.Resolve("{{data:construction_code_256}}"));
        await page.PressConstructionCodeAsync("Tab");
        await page.PressConstructionCodeAsync("CLICK");
        await page.PressConstructionCodeAsync("Tab");
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
        await page.PressCoverageFormCFDD1Async("Tab");
        await page.PressCoverageFormCFDD1Async("CLICK");
        await page.PressCoverageFormCFDD1Async("Tab");
        await page.ClickAddAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.EnterLimitOfInsuranceAsync(data.Resolve("{{data:limit_of_insurance_263}}"));
        await page.PressLimitOfInsuranceAsync("Tab");
        await page.PressLimitOfInsuranceAsync("CLICK");
        await page.PressLimitOfInsuranceAsync("Tab");
        await page.EnterSignLocationAsync(data.Resolve("{{data:sign_location_264}}"));
        await page.PressSignLocationAsync("Tab");
        await page.PressSignLocationAsync("CLICK");
        await page.PressSignLocationAsync("Tab");
        await page.EnterTypeB082DAsync(data.Resolve("{{data:type_265}}"));
        await page.PressTypeB082DAsync("Tab");
        await page.PressTypeB082DAsync("CLICK");
        await page.PressTypeB082DAsync("Tab");
        await page.EnterLetteringAsync(data.Resolve("{{data:lettering_266}}"));
        await page.PressLetteringAsync("Tab");
        await page.PressLetteringAsync("CLICK");
        await page.PressLetteringAsync("Tab");
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
        await page.PressType715D6Async("CLICK");
        await page.PressType715D6Async("Tab");
        await page.PressNamesAsync("TAB");
        await page.EnterNamesAsync(data.Resolve("{{data:names_273}}"));
        await page.PressNamesAsync("CLICK");
        await page.PressNamesAsync("Tab");
        await page.PressAddressAsync("TAB");
        await page.EnterAddressAsync(data.Resolve("{{data:address_275}}"));
        await page.PressAddressAsync("CLICK");
        await page.PressAddressAsync("Tab");
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
        await page.PressType715D6Async("Tab");
        await page.PressType715D6Async("Tab");
        await page.EnterLimit887C5Async(data.Resolve("{{data:limit_281}}"));
        await page.PressLimit887C5Async("Tab");
        await page.EnterDeductible0CC0AAsync(data.Resolve("{{data:deductible_282}}"));
        await page.PressDeductible0CC0AAsync("Tab");
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
        await page.PressWhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStoredAsync("Tab");
        await page.PressWhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStoredAsync("CLICK");
        await page.PressWhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStoredAsync("Tab");
        await page.PressWhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheftAsync("TAB");
        await page.EnterWhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheftAsync(data.Resolve("{{data:what_safeguards_are_in_place_for_receivables_to_protect_against_damage_or_theft_290}}"));
        await page.PressWhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheftAsync("Tab");
        await page.PressWhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheftAsync("CLICK");
        await page.PressWhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheftAsync("Tab");
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
        await page.PressDryCleaningAsync("Tab");
        await page.PressDryCleaningAsync("CLICK");
        await page.PressDryCleaningAsync("Tab");
        await page.EnterLaundryAsync(data.Resolve("{{data:laundry_296}}"));
        await page.PressLaundryAsync("Tab");
        await page.PressLaundryAsync("CLICK");
        await page.PressLaundryAsync("Tab");
        await page.EnterN2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremisesAsync(data.Resolve("{{data:2_indicate_the_age_type_of_construction_and_protection_class_of_the_premises_297}}"));
        await page.PressN2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremisesAsync("Tab");
        await page.PressN2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremisesAsync("CLICK");
        await page.PressN2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremisesAsync("Tab");
        await page.EnterN3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepairAsync(data.Resolve("{{data:3_what_is_the_percentage_of_annual_gross_receipts_derived_from_service_or_repair_298}}"));
        await page.PressN3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepairAsync("Tab");
        await page.PressN3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepairAsync("Tab");
        await page.PressN3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepairAsync("CLICK");
        await page.PressN3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepairAsync("CLICK");
        await page.PressN3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepairAsync("Tab");
        await page.EnterN4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdatedAsync(data.Resolve("{{data:4_what_method_do_you_use_for_keeping_records_of_property_in_your_care_and_how_often_are_the_records_updated_299}}"));
        await page.PressN4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdatedAsync("Tab");
        await page.PressN4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdatedAsync("CLICK");
        await page.PressN4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdatedAsync("Tab");
        await page.EnterN5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintainedAsync(data.Resolve("{{data:5_are_recognized_approved_central_station_burglar_alarms_installed_and_maintained_300}}"));
        await page.PressN5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintainedAsync("Tab");
        await page.PressN5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintainedAsync("CLICK");
        await page.PressN5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintainedAsync("Tab");
        await page.EnterN6AreAllStorageAreasLockedAtAllTimesWhenUnoccupiedAsync(data.Resolve("{{data:6_are_all_storage_areas_locked_at_all_times_when_unoccupied_301}}"));
        await page.PressN6AreAllStorageAreasLockedAtAllTimesWhenUnoccupiedAsync("Tab");
        await page.PressN6AreAllStorageAreasLockedAtAllTimesWhenUnoccupiedAsync("CLICK");
        await page.PressN6AreAllStorageAreasLockedAtAllTimesWhenUnoccupiedAsync("Tab");
        await page.EnterN7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremisesAsync(data.Resolve("{{data:7_are_there_any_hazardous_or_flammable_materials_used_or_stored_on_the_premises_302}}"));
        await page.PressN7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremisesAsync("Tab");
        await page.PressN7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremisesAsync("CLICK");
        await page.PressN7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremisesAsync("Tab");
        await page.EnterAWhatIsThePublicProtectionClassRatingAsync(data.Resolve("{{data:a_what_is_the_public_protection_class_rating_303}}"));
        await page.PressAWhatIsThePublicProtectionClassRatingAsync("Tab");
        await page.PressAWhatIsThePublicProtectionClassRatingAsync("Tab");
        await page.PressAWhatIsThePublicProtectionClassRatingAsync("CLICK");
        await page.PressAWhatIsThePublicProtectionClassRatingAsync("CLICK");
        await page.PressAWhatIsThePublicProtectionClassRatingAsync("Tab");
        await page.EnterBAreThereAnyPrivateProtectionImprovementsAsync(data.Resolve("{{data:b_are_there_any_private_protection_improvements_304}}"));
        await page.PressBAreThereAnyPrivateProtectionImprovementsAsync("Tab");
        await page.PressBAreThereAnyPrivateProtectionImprovementsAsync("CLICK");
        await page.PressBAreThereAnyPrivateProtectionImprovementsAsync("Tab");
        await page.EnterCWhatIsTheDistanceInFeetToTheNearestHydrantAsync(data.Resolve("{{data:c_what_is_the_distance_in_feet_to_the_nearest_hydrant_305}}"));
        await page.PressCWhatIsTheDistanceInFeetToTheNearestHydrantAsync("Tab");
        await page.PressCWhatIsTheDistanceInFeetToTheNearestHydrantAsync("CLICK");
        await page.PressCWhatIsTheDistanceInFeetToTheNearestHydrantAsync("Tab");
        await page.EnterDWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartmentAsync(data.Resolve("{{data:d_what_is_the_distance_in_miles_to_the_nearest_responding_fire_department_306}}"));
        await page.PressDWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartmentAsync("Tab");
        await page.PressDWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartmentAsync("CLICK");
        await page.PressDWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartmentAsync("Tab");
        await page.EnterEAreNoSmokingRulesPostedAndEnforcedAsync(data.Resolve("{{data:e_are_no_smoking_rules_posted_and_enforced_307}}"));
        await page.PressEAreNoSmokingRulesPostedAndEnforcedAsync("Tab");
        await page.PressEAreNoSmokingRulesPostedAndEnforcedAsync("CLICK");
        await page.PressEAreNoSmokingRulesPostedAndEnforcedAsync("Tab");
        await page.EnterN9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystemAsync(data.Resolve("{{data:9_are_the_premises_or_any_portion_of_the_premises_equipped_with_a_sprinkler_system_308}}"));
        await page.PressN9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystemAsync("Tab");
        await page.PressN9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystemAsync("CLICK");
        await page.PressN9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystemAsync("Tab");
        await page.EnterN10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarmsAsync(data.Resolve("{{data:10_are_the_premises_equipped_with_a_recognized_approved_central_station_fire_alarm_fire_extinguishers_or_smoke_alarms_309}}"));
        await page.PressN10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarmsAsync("Tab");
        await page.PressN10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarmsAsync("CLICK");
        await page.PressN10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarmsAsync("Tab");
        await page.EnterN11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransitAsync(data.Resolve("{{data:11_what_is_the_procedure_for_transporting_property_include_the_transit_methods_used_and_the_protection_class_provided_while_in_transit_310}}"));
        await page.PressN11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransitAsync("Tab");
        await page.PressN11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransitAsync("CLICK");
        await page.PressN11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransitAsync("Tab");
        await page.EnterN12AreDriversMVRsReviewedOnARegularBasisAndMaintainedAsync(data.Resolve("{{data:12_are_drivers_mvrs_reviewed_on_a_regular_basis_and_maintained_311}}"));
        await page.PressN12AreDriversMVRsReviewedOnARegularBasisAndMaintainedAsync("Tab");
        await page.PressN12AreDriversMVRsReviewedOnARegularBasisAndMaintainedAsync("CLICK");
        await page.PressN12AreDriversMVRsReviewedOnARegularBasisAndMaintainedAsync("Tab");
        await page.EnterN13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicleAsync(data.Resolve("{{data:13_what_types_of_vehicles_do_you_operate_and_what_protective_devices_are_on_each_vehicle_312}}"));
        await page.PressN13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicleAsync("Tab");
        await page.PressN13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicleAsync("Tab");
        await page.PressN13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicleAsync("CLICK");
        await page.PressN13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicleAsync("CLICK");
        await page.PressN13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicleAsync("Tab");
        await page.EnterN14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorageAsync(data.Resolve("{{data:14_what_is_your_procedure_for_protecting_small_items_from_breakage_or_disappearance_while_in_storage_313}}"));
        await page.PressN14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorageAsync("Tab");
        await page.PressN14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorageAsync("CLICK");
        await page.PressN14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorageAsync("Tab");
        await page.EnterN15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheftAsync(data.Resolve("{{data:15_what_measures_does_the_insured_take_to_protect_customer_s_property_against_theft_314}}"));
        await page.PressN15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheftAsync("Tab");
        await page.PressN15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheftAsync("Tab");
        await page.PressN15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheftAsync("CLICK");
        await page.PressN15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheftAsync("CLICK");
        await page.PressN15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheftAsync("Tab");
        await page.EnterN16DoesTheRiskUseReleaseFormsAsync(data.Resolve("{{data:16_does_the_risk_use_release_forms_315}}"));
        await page.PressN16DoesTheRiskUseReleaseFormsAsync("Tab");
        await page.PressN16DoesTheRiskUseReleaseFormsAsync("CLICK");
        await page.PressN16DoesTheRiskUseReleaseFormsAsync("Tab");
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
        await page.PressUpdateAnswers3DDA2Async("Tab");
        await page.PressUpdateAnswers3DDA2Async("Click");
        await page.EnterWhatIsTheProcedureForTransportingTheComputerEquipmentAsync(data.Resolve("{{data:what_is_the_procedure_for_transporting_the_computer_equipment_320}}"));
        await page.PressWhatIsTheProcedureForTransportingTheComputerEquipmentAsync("Tab");
        await page.PressWhatIsTheProcedureForTransportingTheComputerEquipmentAsync("CLICK");
        await page.PressWhatIsTheProcedureForTransportingTheComputerEquipmentAsync("Tab");
        await page.EnterIndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocatedAsync(data.Resolve("{{data:indicate_the_building_s_age_type_of_construction_and_protection_class_and_other_tenants_in_the_building_s_where_the_computer_equipment_is_located_321}}"));
        await page.PressIndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocatedAsync("Tab");
        await page.PressIndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocatedAsync("CLICK");
        await page.PressIndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocatedAsync("Tab");
        await page.EnterWhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecuredAsync(data.Resolve("{{data:what_are_the_procedures_and_methods_for_keeping_the_edp_areas_secured_322}}"));
        await page.PressWhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecuredAsync("Tab");
        await page.PressWhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecuredAsync("Tab");
        await page.PressWhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecuredAsync("CLICK");
        await page.PressWhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecuredAsync("CLICK");
        await page.PressWhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecuredAsync("Tab");
        await page.EnterWhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorageAsync(data.Resolve("{{data:what_are_the_procedures_and_schedule_for_backing_up_the_media_and_data_and_their_storage_323}}"));
        await page.PressWhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorageAsync("Tab");
        await page.PressWhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorageAsync("CLICK");
        await page.PressWhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorageAsync("Tab");
        await page.EnterProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMediaAsync(data.Resolve("{{data:provide_information_regarding_antivirus_methods_and_copyright_protection_of_data_and_media_324}}"));
        await page.PressProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMediaAsync("Tab");
        await page.PressProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMediaAsync("Tab");
        await page.PressProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMediaAsync("CLICK");
        await page.PressProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMediaAsync("CLICK");
        await page.PressProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMediaAsync("Tab");
        await page.EnterWhatIsThePublicProtectionClassRatingAsync(data.Resolve("{{data:what_is_the_public_protection_class_rating_325}}"));
        await page.PressWhatIsThePublicProtectionClassRatingAsync("Tab");
        await page.PressWhatIsThePublicProtectionClassRatingAsync("Tab");
        await page.PressWhatIsThePublicProtectionClassRatingAsync("CLICK");
        await page.PressWhatIsThePublicProtectionClassRatingAsync("CLICK");
        await page.PressWhatIsThePublicProtectionClassRatingAsync("CLICK");
        await page.PressWhatIsThePublicProtectionClassRatingAsync("Tab");
        await page.EnterWhatIsTheDistanceInFeetToTheNearestFireHydrantAsync(data.Resolve("{{data:what_is_the_distance_in_feet_to_the_nearest_fire_hydrant_326}}"));
        await page.PressWhatIsTheDistanceInFeetToTheNearestFireHydrantAsync("Tab");
        await page.PressWhatIsTheDistanceInFeetToTheNearestFireHydrantAsync("CLICK");
        await page.PressWhatIsTheDistanceInFeetToTheNearestFireHydrantAsync("CLICK");
        await page.PressWhatIsTheDistanceInFeetToTheNearestFireHydrantAsync("Tab");
        await page.EnterWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartmentAsync(data.Resolve("{{data:what_is_the_distance_in_miles_to_the_nearest_responding_fire_department_327}}"));
        await page.PressWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartmentAsync("Tab");
        await page.PressWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartmentAsync("CLICK");
        await page.PressWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartmentAsync("CLICK");
        await page.PressWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartmentAsync("Tab");
        await page.EnterUninterruptiblePowerSourceAsync(data.Resolve("{{data:uninterruptible_power_source_328}}"));
        await page.PressUninterruptiblePowerSourceAsync("Tab");
        await page.PressUninterruptiblePowerSourceAsync("CLICK");
        await page.PressUninterruptiblePowerSourceAsync("Tab");
        await page.EnterLineConditionerAsync(data.Resolve("{{data:line_conditioner_329}}"));
        await page.PressLineConditionerAsync("Tab");
        await page.PressLineConditionerAsync("CLICK");
        await page.PressLineConditionerAsync("Tab");
        await page.EnterPowerSuppressorVoltageRegulatorAsync(data.Resolve("{{data:power_suppressor_voltage_regulator_330}}"));
        await page.PressPowerSuppressorVoltageRegulatorAsync("Tab");
        await page.PressPowerSuppressorVoltageRegulatorAsync("CLICK");
        await page.PressPowerSuppressorVoltageRegulatorAsync("Tab");
        await page.EnterDedicatedLineAsync(data.Resolve("{{data:dedicated_line_331}}"));
        await page.PressDedicatedLineAsync("Tab");
        await page.PressDedicatedLineAsync("CLICK");
        await page.PressDedicatedLineAsync("Tab");
        await page.EnterHowOftenIsDataBackedUpAsync(data.Resolve("{{data:how_often_is_data_backed_up_332}}"));
        await page.PressHowOftenIsDataBackedUpAsync("Tab");
        await page.PressHowOftenIsDataBackedUpAsync("CLICK");
        await page.PressHowOftenIsDataBackedUpAsync("Tab");
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
        await page.PressEstimatedHighestValueAsync("Tab");
        await page.PressEstimatedHighestValueAsync("CLICK");
        await page.PressEstimatedHighestValueAsync("Tab");
        await page.EnterIfYesDescribeAsync(data.Resolve("{{data:if_yes_describe_339}}"));
        await page.PressIfYesDescribeAsync("Tab");
        await page.PressIfYesDescribeAsync("CLICK");
        await page.PressIfYesDescribeAsync("Tab");
        await page.ClickSpecificUnderwritingQuestionsContractorsEquipmentOKAsync();

    }

    [Given(@"^I complete Motor Truck Cargo Questions \\(Owner\\)$")]
    [When(@"^I complete Motor Truck Cargo Questions \\(Owner\\)$")]
    [Then(@"^I complete Motor Truck Cargo Questions \\(Owner\\)$")]
    public async Task CompleteMotorTruckCargoQuestionsOwnerAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickSpecificUnderwritingQuestionsAsync();
        await page.ClickMotorTruckCargoUWQuestionsAsync();
        await page.WaitForMotorTruckCargoHeadingAsync("Exists");
        await page.EnterWhichFormAreYouCompletingAsync(data.Resolve("{{data:which_form_are_you_completing_344}}"));
        await page.PressWhichFormAreYouCompletingAsync("Tab");
        await page.PressN1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipmentAsync("TAB");
        await page.EnterN1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipmentAsync(data.Resolve("{{data:1_what_are_the_distances_the_shipments_will_travel_and_the_time_required_to_complete_the_shipment_346}}"));
        await page.PressN1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipmentAsync("Tab");
        await page.PressN1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipmentAsync("Tab");
        await page.PressN1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipmentAsync("CLICK");
        await page.PressN1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipmentAsync("CLICK");
        await page.PressN1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipmentAsync("Tab");
        await page.EnterN2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommoditiesAsync(data.Resolve("{{data:2_what_are_the_types_and_ages_of_the_vehicles_trailers_used_to_transport_your_commodities_347}}"));
        await page.PressN2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommoditiesAsync("Tab");
        await page.PressN2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommoditiesAsync("CLICK");
        await page.PressN2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommoditiesAsync("Tab");
        await page.EnterN3DoesTheApplicantHaulForOthersAsync(data.Resolve("{{data:3_does_the_applicant_haul_for_others_348}}"));
        await page.PressN3DoesTheApplicantHaulForOthersAsync("Tab");
        await page.PressN3DoesTheApplicantHaulForOthersAsync("CLICK");
        await page.PressN3DoesTheApplicantHaulForOthersAsync("Tab");
        await page.EnterN4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailerAsync(data.Resolve("{{data:4_what_protective_devices_are_installed_on_each_vehicle_or_trailer_349}}"));
        await page.PressN4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailerAsync("Tab");
        await page.PressN4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailerAsync("CLICK");
        await page.PressN4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailerAsync("Tab");
        await page.EnterN5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttachedAsync(data.Resolve("{{data:5_do_any_vehicles_have_special_equipment_mounted_or_attached_350}}"));
        await page.PressN5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttachedAsync("Tab");
        await page.PressN5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttachedAsync("CLICK");
        await page.PressN5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttachedAsync("Tab");
        await page.EnterN6DoesTheApplicantPullDoubleOrTripleTrailersAsync(data.Resolve("{{data:6_does_the_applicant_pull_double_or_triple_trailers_351}}"));
        await page.PressN6DoesTheApplicantPullDoubleOrTripleTrailersAsync("Tab");
        await page.PressN6DoesTheApplicantPullDoubleOrTripleTrailersAsync("CLICK");
        await page.PressN6DoesTheApplicantPullDoubleOrTripleTrailersAsync("Tab");
        await page.EnterN7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattendedAsync(data.Resolve("{{data:7_does_the_applicant_leave_the_truck_windows_doors_and_compartments_closed_and_locked_when_unattended_352}}"));
        await page.PressN7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattendedAsync("Tab");
        await page.PressN7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattendedAsync("CLICK");
        await page.PressN7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattendedAsync("Tab");
        await page.EnterN8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperateAsync(data.Resolve("{{data:8_do_you_provide_scheduled_maintenance_for_the_vehicles_and_trailers_you_operate_353}}"));
        await page.PressN8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperateAsync("Tab");
        await page.PressN8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperateAsync("CLICK");
        await page.PressN8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperateAsync("Tab");
        await page.EnterN9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommoditiesAsync(data.Resolve("{{data:9_are_the_employees_that_pack_load_and_unload_trained_in_proper_handling_of_the_commodities_354}}"));
        await page.PressN9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommoditiesAsync("Tab");
        await page.PressN9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommoditiesAsync("CLICK");
        await page.PressN9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommoditiesAsync("Tab");
        await page.EnterN10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheftAsync(data.Resolve("{{data:10_how_are_the_goods_being_transported_protected_from_damage_and_theft_355}}"));
        await page.PressN10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheftAsync("Tab");
        await page.PressN10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheftAsync("CLICK");
        await page.PressN10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheftAsync("Tab");
        await page.EnterN11AreDriversMVRsAndTripLogsMaintainedAsync(data.Resolve("{{data:11_are_drivers_mvrs_and_trip_logs_maintained_356}}"));
        await page.PressN11AreDriversMVRsAndTripLogsMaintainedAsync("Tab");
        await page.PressN11AreDriversMVRsAndTripLogsMaintainedAsync("CLICK");
        await page.PressN11AreDriversMVRsAndTripLogsMaintainedAsync("Tab");
        await page.EnterN12HowOftenAreTheseLogsReviewedOrUpdatedAsync(data.Resolve("{{data:12_how_often_are_these_logs_reviewed_or_updated_357}}"));
        await page.PressN12HowOftenAreTheseLogsReviewedOrUpdatedAsync("Tab");
        await page.PressN12HowOftenAreTheseLogsReviewedOrUpdatedAsync("CLICK");
        await page.PressN12HowOftenAreTheseLogsReviewedOrUpdatedAsync("Tab");
        await page.EnterN13LiveAnimalInTransitCoverageAsync(data.Resolve("{{data:13_live_animal_in_transit_coverage_358}}"));
        await page.PressN13LiveAnimalInTransitCoverageAsync("Tab");
        await page.PressN13LiveAnimalInTransitCoverageAsync("CLICK");
        await page.PressN13LiveAnimalInTransitCoverageAsync("Tab");
        await page.EnterN14LegalLiabilityCoverageAsync(data.Resolve("{{data:14_legal_liability_coverage_359}}"));
        await page.PressN14LegalLiabilityCoverageAsync("Tab");
        await page.PressN14LegalLiabilityCoverageAsync("CLICK");
        await page.PressN14LegalLiabilityCoverageAsync("Tab");
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
        await page.PressAreAnySignsOffPremisesOrNotAttachedToBuildingAsync("Tab");
        await page.PressAreAnySignsOffPremisesOrNotAttachedToBuildingAsync("Tab");
        await page.EnterDoesTheApplicantWishToCoverAnySignsInsideTheirPremisesAsync(data.Resolve("{{data:does_the_applicant_wish_to_cover_any_signs_inside_their_premises_365}}"));
        await page.PressDoesTheApplicantWishToCoverAnySignsInsideTheirPremisesAsync("Tab");
        await page.PressDoesTheApplicantWishToCoverAnySignsInsideTheirPremisesAsync("Tab");
        await page.EnterWhatIsTheConstructionOfEachSignAsync(data.Resolve("{{data:what_is_the_construction_of_each_sign_366}}"));
        await page.PressWhatIsTheConstructionOfEachSignAsync("Tab");
        await page.PressWhatIsTheConstructionOfEachSignAsync("Tab");
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
        await page.PressBillTypeAsync("Tab");
        await page.PressBillTypeAsync("TAB");
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_373}}"));
        await page.PressPayPlanAsync("Tab");
        await page.PressPayPlanAsync("TAB");
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_377}}"));
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
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_388}}"));
        await page.PressIsThisCoverageBoundAsync("Tab");
        await page.PressIsThisCoverageBoundAsync("CLICK");
        await page.PressIsThisCoverageBoundAsync("Tab");
        await page.VerifyOrderAuditAsync("Exists", "");
        await page.EnterOrderAuditAsync(data.Resolve("{{data:order_audit_390}}"));
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
        await page.VerifyIsThisCoverageBoundAsync(data.Resolve("{{data:expected_is_this_coverage_bound_value_398}}"), "Value");
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_399}}"));
        await page.PressIsThisCoverageBoundAsync("Tab");
        await page.PressIsThisCoverageBoundAsync("Tab");
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
