using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "IM Basic Policy")]
public sealed class IMBasicPolicySteps
{
    private readonly ScenarioContext _scenario;
    public IMBasicPolicySteps(ScenarioContext scenario) => _scenario = scenario;

    private static async Task EnterWithRetryAsync(
        string value,
        Func<string, Task> enterValueAsync,
        Func<Task<string>> captureValueAsync,
        string fieldName,
        int maxAttempts = 4,
        int delayMs = 2000,
        Func<Task>? postEnterKeyboardActionAsync = null)
    {
        for (var attempt = 1; attempt <= maxAttempts; attempt++)
        {
            await enterValueAsync(value);
            await Task.Delay(delayMs);

            if (postEnterKeyboardActionAsync is not null)
            {
                await postEnterKeyboardActionAsync();
            }

            var enteredValue = await captureValueAsync();
            if (!string.IsNullOrWhiteSpace(enteredValue))
            {
                return;
            }
        }

        throw new InvalidOperationException($"{fieldName} field is empty after {maxAttempts} attempts.");
    }

    private static async Task EnterWithTabAndNonEmptyRetryAsync(
        Func<Task> enter,
        Func<Task> pressTab,
        Func<Task<string>> capture,
        string fieldName,
        int maxAttempts = 4)
    {
        for (var attempt = 1; attempt <= maxAttempts; attempt++)
        {
            await enter();
            await pressTab();
            await Task.Delay(2000);

            var actual = (await capture())?.Trim() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(actual))
            {
                return;
            }
        }

        throw new InvalidOperationException($"Value was empty after Tab commit for field '{fieldName}' after {maxAttempts} attempts.");
    }


    [Given(@"^I start a new quote$")]
    [When(@"^I start a new quote$")]
    [Then(@"^I start a new quote$")]
    public async Task StartANewQuoteAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickNewQuoteAsync();
        await page.EnterEffectiveDateAsync(data.Resolve("{{data:effectivedate_98}}"));
        await page.EnterProductAsync(data.Resolve("{{data:product_45}}"));
        await page.WaitForStartAsync("Visible");
        await page.ClickStartAsync();

    }

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

        await page.WaitForQuickQuoteAsync("Exists");
        await page.SetQuickQuoteAsync(data.Resolve("{{data:quick_quote_2}}"));
        await page.WaitForUnderwritingInfoAsync("Exists");
        await page.EnterInsuredTypeAsync(data.Resolve("{{data:insured_type_4}}"));
        await page.EnterEntityTypeAsync(data.Resolve("{{data:entity_type_8}}"));
        await page.WaitForBusinessNameAsync("Visible");
        await page.EnterBusinessNameSequentiallyAsync(data.Resolve("{{data:business_name_7}}"));
        await page.EnterPrimaryPhoneSequentiallyAsync(data.Resolve("{{runtime:PrimaryPhone_0041}}"));
        await page.EnterAddressSequentiallyAsync(data.Resolve("{{data:address1_12}}"));
        await page.EnterNamedInsuredZipCodeSequentiallyAsync(data.Resolve("{{data:zipcode_11}}"));
        if (await page.ExistsYearsInBusinessAsync())
        {
            await page.EnterYearsInBusinessSequentiallyAsync(data.Resolve("{{data:years_in_business_14}}"));
        }
        await page.EnterFEINSequentiallyAsync(data.Resolve("{{runtime:FEIN_0044}}"));
        await page.EnterNameOfAuditContactAsync(data.Resolve("{{data:name_of_audit_contact_16}}"));
        await page.EnterAuditTelephoneAsync(data.Resolve("{{runtime:AuditTelephone_0045}}"));
        await page.EnterNameOfInspectionContactAsync(data.Resolve("{{data:name_of_inspection_contact_18}}"));
        await page.EnterInspectionTelephoneAsync(data.Resolve("{{runtime:InspectionTelephone_0045}}"));
        await page.EnterInsuredEMailAddressAsync(data.Resolve("{{data:insured_e_mail_address_20}}"));
        await page.EnterWebsiteAddressAsync(data.Resolve("{{data:website_address_21}}"));
        await page.VerifyNamedInsuredZipCodeAsync("[0-9]{5}-[0-9]{4}", "Regex:value");

    }

    [Given(@"^I add a new Associated Client \- Business Owner Type \- Click Add Client$")]
    [When(@"^I add a new Associated Client \- Business Owner Type \- Click Add Client$")]
    [Then(@"^I add a new Associated Client \- Business Owner Type \- Click Add Client$")]
    public async Task AddANewAssociatedClientBusinessOwnerTypeClickAddClientAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForAddClientAsync("Exists");
        await page.ClickAddClientAsync();
        await page.VerifyIndividualTypeAsync("Exists", "");

    }

    [Given(@"^I complete aJAX Error Check$")]
    [When(@"^I complete aJAX Error Check$")]
    [Then(@"^I complete aJAX Error Check$")]
    public async Task CompleteAJAXErrorCheckAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyAJAXErrorCheckAsync("Exists", "");

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
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_37}}"));
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_40}}"));
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_44}}"));
        //await page.PauseAsync(1000);

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

        await page.EnterIndividualTypeSequentiallyAsync(data.Resolve("{{data:individualtype_47}}"));
        await page.PressIndividualTypeAsync("Tab");
        await page.WaitForPleaseVerifySSNAsync("Exists");
        await page.EnterFirstNameSequentiallyAsync(data.Resolve("{{runtime:FirstName_0057}}"));
        var firstName = data.Resolve("{{runtime:FirstName_0057}}");
        await page.EnterMiddleNameSequentiallyAsync(data.Resolve("{{runtime:MiddleName_0057}}"));
        await page.EnterLastNameSequentiallyAsync(data.Resolve("{{runtime:LastName_0057}}"));
        var lastName = data.Resolve("{{runtime:LastName_0057}}");
        await page.EnterAddAssociatedClientDateOfBirthSequentiallyAsync(data.Resolve("{{data:dateofbirth_52}}"));
        await page.EnterAddressSequentiallyAsync(data.Resolve("{{data:address1_53}}"));
        var associatedClientAddress = data.Resolve("{{data:address1_53}}");
        await page.EnterCitySequentiallyAsync(data.Resolve("{{data:city_54}}"));
        await page.EnterStateSequentiallyAsync(data.Resolve("{{data:state_55}}"));
        await page.EnterNamedInsuredZipCodeSequentiallyAsync(data.Resolve("{{data:zipcode_56}}"));
        await page.PressNamedInsuredZipCodeAsync("Tab");
        await page.EnterGenderAsync(data.Resolve("{{data:gender_57}}"));
        await page.WaitForClientSearchAsync("Exists");
        await page.ClickClientSearchAsync();
        await page.VerifySearchResultsDuckCreekPolicyFirstCheckboxAsync("Absent", "");
        await page.ClickOKAsync();
        await page.ClickOrderSSNAsync();
        await page.EnterAddAssociatedClientEnterSSNSequentiallyAsync(data.Resolve("{{data:enter_ssn_65}}"));
        await page.PressAddAssociatedClientEnterSSNAsync("Tab");
        await page.ClickVerifyAsync();
        await page.WaitForPleaseVerifySSNAsync("Absent");
        await page.ClickCompleteAsync();
        await page.ClickClientSearchAsync();
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
        await page.WaitForClientSearchAsync("Absent");

    }

    [Given(@"^I complete Underwring Questions from Client Screen$")]
    [When(@"^I complete Underwring Questions from Client Screen$")]
    [Then(@"^I complete Underwring Questions from Client Screen$")]
    public async Task CompleteUnderwringQuestionsFromClientScreenAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickUnderwritingInfoAsync();
        await page.ClickPropertyUWQuestionsUpdateAnswersAsync();
        await page.ClickInsuranceHistoryAsync();
        await page.EnterIsThereAPriorCarrierSequentiallyAsync(data.Resolve("{{data:is_there_a_prior_carrier_87}}"));
        await page.ClickLossExperienceAsync();
        await page.ClickReturnToQuoteAsync();
    }

    [Given(@"^I complete required policy information$")]
    [When(@"^I complete required policy information$")]
    [Then(@"^I complete required policy information$")]
    public async Task CompleteRequiredPolicyInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForPolicyInfoAsync("Exists");
        await page.ClickPolicyInfoAsync();
        await page.PauseAsync(1000);
        await page.EnterPolicyInfoRequiredAndOptionalFieldsEffectiveDateSequentiallyAsync(data.Resolve("{{data:effectivedate_98}}"));
        await page.EnterYearsInBusinessSequentiallyAsync(data.Resolve("{{data:years_in_business_99}}"));
        await page.PauseAsync(1000);
        await page.EnterPrimaryRatingStateSequentiallyAsync(data.Resolve("{{data:primaryratingstate_101}}"));
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysSequentiallyAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_105}}"));
        await page.PauseAsync(1000);
        await page.VerifyPriorAmericanNationalPolicyAsync("Absent", "");
        await page.VerifyWhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNationalAsync("Absent", "");
        await page.VerifyIsThisPolicyBeingFullyCancelledAsync("Absent", "");
        var descriptionOfSpecifiedOperation = data.BuildQuoteDescription();
        await page.EnterDescriptionOfSpecifiedOperationSequentiallyAsync(descriptionOfSpecifiedOperation);
        await page.PressDescriptionOfSpecifiedOperationAsync("Tab");
        if (data.Resolve("{{data:state_variant}}") == "MD" || data.Resolve("{{data:state_variant}}") == "NY" || data.Resolve("{{data:state_variant}}") == "VT" || data.Resolve("{{data:state_variant}}") == "NJ")
        {
            await page.PauseAsync(3000);
            await page.WaitFostimatedPremiumAsync("Visible");
            await page.EnterEstimatedPremiumsAsync(data.Resolve("{{data:estimated_Premium_11}}"));
        }
        data.Set("QuoteDescription", await page.CaptureDescriptionOfSpecifiedOperationAsync("value"));
    }

    [Given(@"^I run insurance score$")]
    [When(@"^I run insurance score$")]
    [Then(@"^I run insurance score$")]
    public async Task RunInsuranceScoreAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForInsuranceScoreAsync("Exists");
        await page.ClickInsuranceScoreAsync();
        await page.PauseAsync(3000);
    }

    [Given(@"^I add Accounts Receivable Coverage$")]
    [When(@"^I add Accounts Receivable Coverage$")]
    [Then(@"^I add Accounts Receivable Coverage$")]
    public async Task AddAccountsReceivableCoverageAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickIMNavigationLinksPolicyCovgAsync();
        await page.EnterCoverageFormToBeAddedSequentiallyAsync(data.Resolve("{{data:coverage_form_to_be_added_134}}"));
        await page.ClickAddCoverageFormAsync();
        await page.WaitForDescriptionAsync("Visible");
        var description = data.Resolve("{{data:description_136}}");
        await EnterWithRetryAsync(
            description,
            page.EnterDescriptionAsync,
            () => page.CaptureDescriptionAsync("value"),
            "Description");

        await page.PressDescriptionAsync("Tab");
        await page.EnterCoinsuranceSequentiallyAsync(data.Resolve("{{data:coinsurance_137}}"));
        await page.EnterAwayFromPremisesLmtSequentiallyAsync(data.Resolve("{{data:away_from_premises_lmt_138}}"));
        await page.EnterAwayFromPremisesDescSequentiallyAsync(data.Resolve("{{data:away_from_premises_desc_139}}"));
        await page.ClickPolicyCovgAccountsReceivableOKAsync();

    }

    [Given(@"^I add Bailees Customers Coverage$")]
    [When(@"^I add Bailees Customers Coverage$")]
    [Then(@"^I add Bailees Customers Coverage$")]
    public async Task AddBaileesCustomersCoverageAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickIMNavigationLinksPolicyCovgAsync();
        await page.WaitForPolicyCovgMainPolicyCovgAsync("Exists");
        await page.EnterCoverageFormToBeAddedSequentiallyAsync(data.Resolve("{{data:coverage_form_to_be_added_143}}"));
        await page.PressCoverageFormToBeAddedAsync("Tab");
        await page.ClickAddCoverageFormAsync();
        await page.WaitForPolicyCovgBaileesCutomersCoverageFormDisplayAsync("Exists");
        await page.PauseAsync(3000);
        await page.EnterPolicyCovgBaileesCutomersDescriptionSequentiallyAsync(data.Resolve("{{data:description_147}}"));
        await page.PressPolicyCovgBaileesCutomersDescriptionAsync("Tab");
        await page.EnterPolicyCovgBaileesCutomersPropertyInTransitSequentiallyAsync(data.Resolve("{{data:property_in_transit_148}}"));
        await page.ClickPropertyAwayFromYourPremisesScheduleAsync();
        await page.ClickAddPremisesAsync();
        await page.PauseAsync(3000);
        await page.EnterAddressStreetCityStateZipSequentiallyAsync(data.Resolve("{{data:address_street_city_state_zip_151}}"));
        await page.EnterPolicyCovgBaileesPropertyAwayFromYourPremisesLimitSequentiallyAsync(data.Resolve("{{data:limit_152}}"));
        await page.ClickOKAsync();
        await page.PauseAsync(3000);
        await page.WaitForPolicyCovgBaileesCutomersCoverageFormDisplayAsync("Exists");
        await page.ClickOKAsync();

    }

    [Given(@"^I add Contractors Equipment$")]
    [When(@"^I add Contractors Equipment$")]
    [Then(@"^I add Contractors Equipment$")]
    public async Task AddContractorsEquipmentAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickIMNavigationLinksPolicyCovgAsync();
        await page.WaitForPolicyCovgMainPolicyCovgAsync("Exists");
        await page.EnterCoverageFormToBeAddedSequentiallyAsync(data.Resolve("{{data:coverage_form_to_be_added_158}}"));
        await page.PauseAsync(2000);
        await page.PressCoverageFormToBeAddedAsync("Tab");
        await page.ClickAddCoverageFormAsync();
        await page.WaitForPolicyCovgContractorsEquipmentCoverageFormDisplayAsync("Exists");
        await page.EnterPolicyCovgContractorsEquipmentDescriptionSequentiallyAsync(data.Resolve("{{data:description_162}}"));
        await page.EnterPolicyCovgContractorsEquipmentCoinsuranceSequentiallyAsync(data.Resolve("{{data:coinsurance_163}}"));
        await page.EnterPolicyCovgContractorsEquipmentDeductibleSequentiallyAsync(data.Resolve("{{data:deductible_164}}"));
        await page.EnterBoomDeductibleSequentiallyAsync(data.Resolve("{{data:boom_deductible_165}}"));
        await page.EnterTypeOfContractorSequentiallyAsync(data.Resolve("{{data:type_of_contractor_166}}"));
        await page.EnterScheduledCoverageSequentiallyAsync(data.Resolve("{{data:scheduled_coverage_167}}"));
        await page.EnterRentedEquipmentExpenseSequentiallyAsync(data.Resolve("{{data:rented_equipment_expense_168}}"));
        await page.EnterToolsAndClothingBelongingToYourEmployeesSequentiallyAsync(data.Resolve("{{data:tools_and_clothing_belonging_to_your_employees_169}}"));
        await page.EnterMiscItemsBlanketCoverageSequentiallyAsync(data.Resolve("{{data:misc_items_blanket_coverage_170}}"));
        await page.EnterRentalReimbursementSequentiallyAsync(data.Resolve("{{data:rental_reimbursement_171}}"));
        await page.EnterHiredEquipmentSequentiallyAsync(data.Resolve("{{data:hired_equipment_172}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I add Computer Systems$")]
    [When(@"^I add Computer Systems$")]
    [Then(@"^I add Computer Systems$")]
    public async Task AddComputerSystemsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickIMNavigationLinksPolicyCovgAsync();
        await page.WaitForPolicyCovgMainPolicyCovgAsync("Exists");
        await page.EnterCoverageFormToBeAddedSequentiallyAsync(data.Resolve("{{data:coverage_form_to_be_added_176}}"));
        await page.PauseAsync(2000);
        await page.PressCoverageFormToBeAddedAsync("Tab");
        await page.ClickAddCoverageFormAsync();
        await page.WaitForPolicyCovgComputerSystemsCoverageFormDisplayAsync("Exists");
        await page.EnterPolicyCovgComputerSystemsDescriptionSequentiallyAsync(data.Resolve("{{data:description_180}}"));
        await page.PressPolicyCovgComputerSystemsDescriptionAsync("Tab");
        await page.EnterPolicyCovgComputerSystemsDeductibleSequentiallyAsync(data.Resolve("{{data:deductible_181}}"));
        await page.EnterPolicyCovgComputerSystemsCoinsuranceSequentiallyAsync(data.Resolve("{{data:coinsurance_182}}"));
        await page.EnterPolicyCovgComputerSystemsPropertyInTransitSequentiallyAsync(data.Resolve("{{data:property_in_transit_183}}"));
        await page.EnterUnnamedPremisesSequentiallyAsync(data.Resolve("{{data:unnamed_premises_184}}"));
        await page.EnterPersonalPortableComputersSequentiallyAsync(data.Resolve("{{data:personal_portable_computers_185}}"));
        await page.EnterExtraExpenseSequentiallyAsync(data.Resolve("{{data:extra_expense_186}}"));
        await page.EnterVirusHarmfulCodeOrSimilarInstructionSequentiallyAsync(data.Resolve("{{data:virus_harmful_code_or_similar_instruction_187}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I add Motor Truck Cargo$")]
    [When(@"^I add Motor Truck Cargo$")]
    [Then(@"^I add Motor Truck Cargo$")]
    public async Task AddMotorTruckCargoAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickIMNavigationLinksPolicyCovgAsync();
        await page.WaitForPolicyCovgMainPolicyCovgAsync("Exists");
        await page.EnterCoverageFormToBeAddedSequentiallyAsync(data.Resolve("{{data:coverage_form_to_be_added_191}}"));
        await page.PressCoverageFormToBeAddedAsync("Tab");
        await page.PauseAsync(1000);
        await page.ClickAddCoverageFormAsync();
        await page.WaitForPolicyCovgMotorTruckCargoCoverageFormDisplayAsync("Exists");
        await page.EnterPolicyCovgMotorTruckCargoDescriptionSequentiallyAsync(data.Resolve("{{data:description_195}}"));
        await page.EnterCoverageTypeSequentiallyAsync(data.Resolve("{{data:coverage_type_196}}"));
        await page.EnterCoveredPropertyConsistingPrincipallyOfSequentiallyAsync(data.Resolve("{{data:covered_property_consisting_principally_of_197}}"));
        await page.EnterPolicyCovgMotorTruckCargoDeductibleSequentiallyAsync(data.Resolve("{{data:deductible_198}}"));
        await page.EnterPerVehicleLimitSequentiallyAsync(data.Resolve("{{data:per_vehicle_limit_199}}"));
        await page.EnterGroupClassSequentiallyAsync(data.Resolve("{{data:group_class_200}}"));
        await page.EnterNumberOfVehiclesSequentiallyAsync(data.Resolve("{{data:number_of_vehicles_201}}"));
        await page.EnterUnnamedTerminalsLimitAsync(data.Resolve("{{data:unnamed_terminals_limit_202}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I add Signs$")]
    [When(@"^I add Signs$")]
    [Then(@"^I add Signs$")]
    public async Task AddSignsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickIMNavigationLinksPolicyCovgAsync();
        await page.EnterCoverageFormToBeAddedSequentiallyAsync(data.Resolve("{{data:coverage_form_to_be_added_206}}"));
        await page.PressCoverageFormToBeAddedAsync("Tab");
        await page.PauseAsync(1000);
        await page.ClickAddCoverageFormAsync();
        await page.WaitForPolicyCovgSignsCoverageFormDisplayAsync("Exists");
        await page.EnterPolicyCovgSignsDescriptionSequentiallyAsync(data.Resolve("{{data:description_210}}"));
        await page.PauseAsync(3000);
        await page.EnterN5DeductibleSequentiallyAsync(data.Resolve("{{data:5_deductible_212}}"));
        await page.ClickOKAsync();
        await page.PauseAsync(1000);

    }

    [Given(@"^I add Accounts Receivable$")]
    [When(@"^I add Accounts Receivable$")]
    [Then(@"^I add Accounts Receivable$")]
    public async Task AddAccountsReceivableAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickRiskAsync();
        await page.EnterRiskMainCoverageFormSequentiallyAsync(data.Resolve("{{data:coverage_form_217}}"));
        await page.PressRiskMainCoverageFormAsync("Tab");
        await page.ClickAddAsync();
        await page.WaitForAccountsReceivableHeadingAsync("Exists");
        var riskAccountsReceivableSearchValue = data.Resolve("{{data:search_value_221}}");
        await EnterWithRetryAsync(
            riskAccountsReceivableSearchValue,
            page.EnterRiskAccountsReceivableSearchValueAsync,
            () => page.CaptureRiskAccountsReceivableSearchValueAsync("value"),
            "Risk Accounts Receivable Search Value");

        var riskAccountsReceivableSearchResult = data.Resolve("{{data:search_result_222}}");
        await EnterWithRetryAsync(
            riskAccountsReceivableSearchResult,
            page.EnterRiskAccountsReceivableSearchResultAsync,
            () => page.CaptureRiskAccountsReceivableSearchResultAsync("value"),
            "Risk Accounts Receivable Search Result");

        await page.EnterRiskAccountsReceivableConstructionSequentiallyAsync(data.Resolve("{{data:construction_223}}"));
        await page.PressRiskAccountsReceivableConstructionAsync("Tab");
        await page.EnterPremisesTypeSequentiallyAsync(data.Resolve("{{data:premises_type_224}}"));
        await page.PressPremisesTypeAsync("Tab");
        await page.EnterDuplicatedRecordsSequentiallyAsync(data.Resolve("{{data:duplicated_records_225}}"));
        await page.PressDuplicatedRecordsAsync("Tab");
        await page.EnterClassificationOfRiskSequentiallyAsync(data.Resolve("{{data:classification_of_risk_226}}"));
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

        await page.ClickRiskAsync();
        await page.EnterRiskMainCoverageFormSequentiallyAsync(data.Resolve("{{data:coverage_form_230}}"));
        await page.PressRiskMainCoverageFormAsync("Tab");
        await page.ClickAddAsync();
        await page.WaitForBaileesCustomersHeadingAsync("Exists");
        await page.EnterRiskBaileesCustomersDeductibleAsync(data.Resolve("{{data:deductible_233}}"));
        await page.PressRiskBaileesCustomersDeductibleAsync("Tab");
        var riskBaileesCustomersSearchValue = data.Resolve("{{data:search_value_235}}");
        await EnterWithRetryAsync(
            riskBaileesCustomersSearchValue,
            page.EnterRiskBaileesCustomersSearchValueAsync,
            () => page.CaptureRiskBaileesCustomersSearchValueAsync("value"),
            "Risk Bailees Customers Search Value");

        await page.EnterRiskBaileesCustomersSearchResultSequentiallyAsync(data.Resolve("{{data:search_result_236}}"));
        await page.PressRiskBaileesCustomersSearchResultAsync("Tab");
        await page.EnterRiskBaileesCustomersConstructionSequentiallyAsync(data.Resolve("{{data:construction_237}}"));
        await page.PressRiskBaileesCustomersConstructionAsync("Tab");
        await page.EnterAnnualGrossReceiptsAsync(data.Resolve("{{data:annual_gross_receipts_238}}"));
        await page.PressAnnualGrossReceiptsAsync("Tab");
        await page.EnterAverageNumberOfDaysServiceSequentiallyAsync(data.Resolve("{{data:average_number_of_days_service_239}}"));
        await page.PressAverageNumberOfDaysServiceAsync("Tab");
        await page.EnterAverageNumberOfWorkingDaysSequentiallyAsync(data.Resolve("{{data:average_number_of_working_days_240}}"));
        await page.PressAverageNumberOfWorkingDaysAsync("Tab");
        await page.EnterAverageServiceChargeSequentiallyAsync(data.Resolve("{{data:average_service_charge_241}}"));
        await page.PressAverageServiceChargeAsync("Tab");
        await page.EnterAverageValuePerOrderSequentiallyAsync(data.Resolve("{{data:average_value_per_order_242}}"));
        await page.PressAverageValuePerOrderAsync("Tab");
        await page.EnterRiskBaileesCustomersLimitSequentiallyAsync(data.Resolve("{{data:limit_244}}"));
        await page.PressRiskBaileesCustomersLimitAsync("Tab");
        await page.EnterEarthquakeSequentiallyAsync(data.Resolve("{{data:earthquake_244}}"));
        await page.PressEarthquakeAsync("Tab");
        await page.EnterStorageLimitSequentiallyAsync(data.Resolve("{{data:storage_limit_245}}"));
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

        await page.ClickRiskAsync();
        await page.EnterRiskMainCoverageFormSequentiallyAsync(data.Resolve("{{data:coverage_form_249}}"));
        await page.PressRiskMainCoverageFormAsync("Tab");
        await page.ClickAddAsync();
        await page.EnterComputerEquipmentSequentiallyAsync(data.Resolve("{{data:computer_equipment_251}}"));
        await page.EnterDataAndMediaSequentiallyAsync(data.Resolve("{{data:data_and_media_252}}"));
        var riskComputerSystemsSearchValue = data.Resolve("{{data:search_value_254}}");
        await EnterWithRetryAsync(
            riskComputerSystemsSearchValue,
            page.EnterRiskComputerSystemsSearchValueAsync,
            () => page.CaptureRiskComputerSystemsSearchValueAsync("value"),
            "Risk Computer Systems Search Value");

        await page.PressRiskComputerSystemsSearchValueAsync("Tab");
        await page.EnterRiskComputerSystemsSearchResultSequentiallyAsync(data.Resolve("{{data:search_result_255}}"));
        await page.PressRiskComputerSystemsSearchResultAsync("Tab");
        await page.EnterConstructionCodeSequentiallyAsync(data.Resolve("{{data:construction_code_256}}"));
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

        await page.ClickRiskAsync();
        await page.EnterRiskMainCoverageFormSequentiallyAsync(data.Resolve("{{data:coverage_form_260}}"));
        await page.PressRiskMainCoverageFormAsync("Tab");
        await page.ClickAddAsync();
        await page.EnterLimitOfInsuranceSequentiallyAsync(data.Resolve("{{data:limit_of_insurance_263}}"));
        var signLocation = data.Resolve("{{data:sign_location_264}}");
        await EnterWithRetryAsync(
            signLocation,
            page.EnterSignLocationAsync,
            () => page.CaptureSignLocationAsync("value"),
            "Sign Location");

        await EnterWithRetryAsync(data.Resolve("{{data:type_265}}"), page.EnterRiskSignsTypeAsync, () => page.CaptureRiskSignsTypeAsync("value"), "Risk Signs Type");
        var lettering = data.Resolve("{{data:lettering_266}}");
        await EnterWithRetryAsync(
            lettering,
            page.EnterLetteringAsync,
            () => page.CaptureLetteringAsync("value"),
            "Lettering");

        await page.ClickOKAsync();

    }

    [Given(@"^I add CM 66 01 Exclude Named Customer$")]
    [When(@"^I add CM 66 01 Exclude Named Customer$")]
    [Then(@"^I add CM 66 01 Exclude Named Customer$")]
    public async Task AddCM6601ExcludeNamedCustomerAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickEndorsementAsync();
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.EnterEndorsementMainTypeSequentiallyAsync(data.Resolve("{{data:type_271}}"));
        await page.EnterNamesSequentiallyAsync(data.Resolve("{{data:names_273}}"));
        var endorsementAddress = data.Resolve("{{data:address_275}}");
        await EnterWithRetryAsync(
            endorsementAddress,
            page.EnterAddressAsync,
            () => page.CaptureAddressAsync("value"),
            "Endorsement Address",
            maxAttempts: 4,
            delayMs: 2000);

        await page.ClickOKAsync();

    }

    [Given(@"^I add IF 00 02 Waterborne Equipment$")]
    [When(@"^I add IF 00 02 Waterborne Equipment$")]
    [Then(@"^I add IF 00 02 Waterborne Equipment$")]
    public async Task AddIF0002WaterborneEquipmentAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickEndorsementAsync();
        await page.ClickEndorsementMainAddEndorsementAsync();
        await page.EnterEndorsementMainTypeSequentiallyAsync(data.Resolve("{{data:type_280}}"));
        await page.EnterEndorsementIF0002WaterborneEquipmentLimitSequentiallyAsync(data.Resolve("{{data:limit_281}}"));
        await page.EnterEndorsementIF0002WaterborneEquipmentDeductibleSequentiallyAsync(data.Resolve("{{data:deductible_282}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I complete Accounts Receivable Questions$")]
    [When(@"^I complete Accounts Receivable Questions$")]
    [Then(@"^I complete Accounts Receivable Questions$")]
    public async Task CompleteAccountsReceivableQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickSpecificUnderwritingQuestionsAsync();
        await page.ClickUWQuestionsUmbrellaUpdateAnswersAsync();
        await page.PauseAsync(2000);
        var receivablesPremisesConstruction = data.Resolve("{{data:what_is_the_construction_of_the_premises_where_the_receivables_are_stored_288}}");
        await EnterWithRetryAsync(
            receivablesPremisesConstruction,
            page.EnterWhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStoredAsync,
            () => page.CaptureWhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStoredAsync("value"),
            "What Is The Construction Of The Premises Where The Receivables Are Stored",
            delayMs: 2000);

        var receivablesSafeguards = data.Resolve("{{data:what_safeguards_are_in_place_for_receivables_to_protect_against_damage_or_theft_290}}");
        await EnterWithRetryAsync(
            receivablesSafeguards,
            page.EnterWhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheftAsync,
            () => page.CaptureWhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheftAsync("value"),
            "What Safeguards Are In Place For Receivables To Protect Against Damage Or Theft",
            delayMs: 2000);

        await page.ClickOKAsync();

    }

    [Given(@"^I complete Bailees Customers Questions$")]
    [When(@"^I complete Bailees Customers Questions$")]
    [Then(@"^I complete Bailees Customers Questions$")]
    public async Task CompleteBaileesCustomersQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickSpecificUnderwritingQuestionsAsync();
        await page.ClickBaileesCustomerUWQuestionsAsync();
        await page.EnterDryCleaningSequentiallyAsync(data.Resolve("{{data:dry_cleaning_295}}"));
        await page.EnterLaundrySequentiallyAsync(data.Resolve("{{data:laundry_296}}"));
        await page.EnterN2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremisesSequentiallyAsync(data.Resolve("{{data:2_indicate_the_age_type_of_construction_and_protection_class_of_the_premises_297}}"));
        await page.EnterN3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepairSequentiallyAsync(data.Resolve("{{data:3_what_is_the_percentage_of_annual_gross_receipts_derived_from_service_or_repair_298}}"));
        await page.EnterN4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdatedSequentiallyAsync(data.Resolve("{{data:4_what_method_do_you_use_for_keeping_records_of_property_in_your_care_and_how_often_are_the_records_updated_299}}"));
        await page.EnterN5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintainedSequentiallyAsync(data.Resolve("{{data:5_are_recognized_approved_central_station_burglar_alarms_installed_and_maintained_300}}"));
        await page.EnterN6AreAllStorageAreasLockedAtAllTimesWhenUnoccupiedSequentiallyAsync(data.Resolve("{{data:6_are_all_storage_areas_locked_at_all_times_when_unoccupied_301}}"));
        await page.EnterN7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremisesSequentiallyAsync(data.Resolve("{{data:7_are_there_any_hazardous_or_flammable_materials_used_or_stored_on_the_premises_302}}"));
        await page.EnterAWhatIsThePublicProtectionClassRatingSequentiallyAsync(data.Resolve("{{data:a_what_is_the_public_protection_class_rating_303}}"));
        await page.EnterBAreThereAnyPrivateProtectionImprovementsSequentiallyAsync(data.Resolve("{{data:b_are_there_any_private_protection_improvements_304}}"));
        await page.EnterCWhatIsTheDistanceInFeetToTheNearestHydrantSequentiallyAsync(data.Resolve("{{data:c_what_is_the_distance_in_feet_to_the_nearest_hydrant_305}}"));
        await page.EnterDWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartmentSequentiallyAsync(data.Resolve("{{data:d_what_is_the_distance_in_miles_to_the_nearest_responding_fire_department_306}}"));
        await page.EnterEAreNoSmokingRulesPostedAndEnforcedSequentiallyAsync(data.Resolve("{{data:e_are_no_smoking_rules_posted_and_enforced_307}}"));
        await page.EnterN9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystemSequentiallyAsync(data.Resolve("{{data:9_are_the_premises_or_any_portion_of_the_premises_equipped_with_a_sprinkler_system_308}}"));
        await page.EnterN10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarmsSequentiallyAsync(data.Resolve("{{data:10_are_the_premises_equipped_with_a_recognized_approved_central_station_fire_alarm_fire_extinguishers_or_smoke_alarms_309}}"));
        await page.EnterN11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransitSequentiallyAsync(data.Resolve("{{data:11_what_is_the_procedure_for_transporting_property_include_the_transit_methods_used_and_the_protection_class_provided_while_in_transit_310}}"));
        await page.EnterN12AreDriversMVRsReviewedOnARegularBasisAndMaintainedSequentiallyAsync(data.Resolve("{{data:12_are_drivers_mvrs_reviewed_on_a_regular_basis_and_maintained_311}}"));
        await page.EnterN13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicleSequentiallyAsync(data.Resolve("{{data:13_what_types_of_vehicles_do_you_operate_and_what_protective_devices_are_on_each_vehicle_312}}"));
        await page.EnterN14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorageSequentiallyAsync(data.Resolve("{{data:14_what_is_your_procedure_for_protecting_small_items_from_breakage_or_disappearance_while_in_storage_313}}"));
        await page.EnterN15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheftSequentiallyAsync(data.Resolve("{{data:15_what_measures_does_the_insured_take_to_protect_customer_s_property_against_theft_314}}"));
        await page.EnterN16DoesTheRiskUseReleaseFormsSequentiallyAsync(data.Resolve("{{data:16_does_the_risk_use_release_forms_315}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I complete Computer Systems Questions$")]
    [When(@"^I complete Computer Systems Questions$")]
    [Then(@"^I complete Computer Systems Questions$")]
    public async Task CompleteComputerSystemsQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickSpecificUnderwritingQuestionsAsync();
        await page.ClickComputerSystemsUWQuestionsAsync();
        await page.ClickUWQuestionsUmbrellaUpdateAnswersAsync();
        await page.EnterWhatIsTheProcedureForTransportingTheComputerEquipmentSequentiallyAsync(data.Resolve("{{data:what_is_the_procedure_for_transporting_the_computer_equipment_320}}"));
        await page.EnterIndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocatedSequentiallyAsync(data.Resolve("{{data:indicate_the_building_s_age_type_of_construction_and_protection_class_and_other_tenants_in_the_building_s_where_the_computer_equipment_is_located_321}}"));
        await page.EnterWhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecuredSequentiallyAsync(data.Resolve("{{data:what_are_the_procedures_and_methods_for_keeping_the_edp_areas_secured_322}}"));
        await page.EnterWhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorageSequentiallyAsync(data.Resolve("{{data:what_are_the_procedures_and_schedule_for_backing_up_the_media_and_data_and_their_storage_323}}"));
        await page.EnterProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMediaSequentiallyAsync(data.Resolve("{{data:provide_information_regarding_antivirus_methods_and_copyright_protection_of_data_and_media_324}}"));
        await page.EnterWhatIsThePublicProtectionClassRatingSequentiallyAsync(data.Resolve("{{data:what_is_the_public_protection_class_rating_325}}"));
        await page.EnterWhatIsTheDistanceInFeetToTheNearestFireHydrantSequentiallyAsync(data.Resolve("{{data:what_is_the_distance_in_feet_to_the_nearest_fire_hydrant_326}}"));
        await page.EnterWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartmentSequentiallyAsync(data.Resolve("{{data:what_is_the_distance_in_miles_to_the_nearest_responding_fire_department_327}}"));
        await page.EnterUninterruptiblePowerSourceSequentiallyAsync(data.Resolve("{{data:uninterruptible_power_source_328}}"));
        await page.EnterLineConditionerSequentiallyAsync(data.Resolve("{{data:line_conditioner_329}}"));
        await page.EnterPowerSuppressorVoltageRegulatorSequentiallyAsync(data.Resolve("{{data:power_suppressor_voltage_regulator_330}}"));
        await page.EnterDedicatedLineSequentiallyAsync(data.Resolve("{{data:dedicated_line_331}}"));
        await page.EnterHowOftenIsDataBackedUpSequentiallyAsync(data.Resolve("{{data:how_often_is_data_backed_up_332}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I complete Contractors Equipment Questions$")]
    [When(@"^I complete Contractors Equipment Questions$")]
    [Then(@"^I complete Contractors Equipment Questions$")]
    public async Task CompleteContractorsEquipmentQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickSpecificUnderwritingQuestionsAsync();
        await page.ClickContractorsEquipmentUWQuestionsAsync();
        //await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickSpecificUnderwritingQuestionsContractorsEquipmentUpdateAnswersAsync();
        await page.EnterEstimatedHighestValueSequentiallyAsync(data.Resolve("{{data:estimated_highest_value_338}}"));
        await page.EnterIfYesDescribeSequentiallyAsync(data.Resolve("{{data:if_yes_describe_339}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I complete Motor Truck Cargo Questions \(Owner\)$")]
    [When(@"^I complete Motor Truck Cargo Questions \(Owner\)$")]
    [Then(@"^I complete Motor Truck Cargo Questions \(Owner\)$")]
    public async Task CompleteMotorTruckCargoQuestionsOwnerAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickSpecificUnderwritingQuestionsAsync();
        await page.ClickMotorTruckCargoUWQuestionsAsync();
        //await page.WaitForSignsHeadingAsync("Exists");
        await page.EnterWhichFormAreYouCompletingSequentiallyAsync(data.Resolve("{{data:which_form_are_you_completing_344}}"));
        await page.EnterN1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipmentSequentiallyAsync(data.Resolve("{{data:1_what_are_the_distances_the_shipments_will_travel_and_the_time_required_to_complete_the_shipment_346}}"));
        await page.EnterN2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommoditiesSequentiallyAsync(data.Resolve("{{data:2_what_are_the_types_and_ages_of_the_vehicles_trailers_used_to_transport_your_commodities_347}}"));
        await page.EnterN3DoesTheApplicantHaulForOthersSequentiallyAsync(data.Resolve("{{data:3_does_the_applicant_haul_for_others_348}}"));
        await page.EnterN4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailerSequentiallyAsync(data.Resolve("{{data:4_what_protective_devices_are_installed_on_each_vehicle_or_trailer_349}}"));
        await page.EnterN5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttachedSequentiallyAsync(data.Resolve("{{data:5_do_any_vehicles_have_special_equipment_mounted_or_attached_350}}"));
        await page.EnterN6DoesTheApplicantPullDoubleOrTripleTrailersSequentiallyAsync(data.Resolve("{{data:6_does_the_applicant_pull_double_or_triple_trailers_351}}"));
        await page.EnterN7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattendedSequentiallyAsync(data.Resolve("{{data:7_does_the_applicant_leave_the_truck_windows_doors_and_compartments_closed_and_locked_when_unattended_352}}"));
        await page.EnterN8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperateSequentiallyAsync(data.Resolve("{{data:8_do_you_provide_scheduled_maintenance_for_the_vehicles_and_trailers_you_operate_353}}"));
        await page.EnterN9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommoditiesSequentiallyAsync(data.Resolve("{{data:9_are_the_employees_that_pack_load_and_unload_trained_in_proper_handling_of_the_commodities_354}}"));
        await page.EnterN10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheftSequentiallyAsync(data.Resolve("{{data:10_how_are_the_goods_being_transported_protected_from_damage_and_theft_355}}"));
        await page.EnterN11AreDriversMVRsAndTripLogsMaintainedSequentiallyAsync(data.Resolve("{{data:11_are_drivers_mvrs_and_trip_logs_maintained_356}}"));
        await page.EnterN12HowOftenAreTheseLogsReviewedOrUpdatedSequentiallyAsync(data.Resolve("{{data:12_how_often_are_these_logs_reviewed_or_updated_357}}"));
        await page.EnterN13LiveAnimalInTransitCoverageSequentiallyAsync(data.Resolve("{{data:13_live_animal_in_transit_coverage_358}}"));
        await page.EnterN14LegalLiabilityCoverageSequentiallyAsync(data.Resolve("{{data:14_legal_liability_coverage_359}}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I complete Signs Questions$")]
    [When(@"^I complete Signs Questions$")]
    [Then(@"^I complete Signs Questions$")]
    public async Task CompleteSignsQuestionsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickSpecificUnderwritingQuestionsAsync();
        await page.ClickSignsUWQuestionsAsync();
        //await page.WaitForSignsHeadingAsync("Exists");
        var areAnySignsOffPremises = data.Resolve("{{data:are_any_signs_off_premises_or_not_attached_to_building_364}}");
        await EnterWithRetryAsync(
            areAnySignsOffPremises,
            page.EnterAreAnySignsOffPremisesOrNotAttachedToBuildingAsync,
            () => page.CaptureAreAnySignsOffPremisesOrNotAttachedToBuildingAsync("value"),
            "Are Any Signs Off Premises Or Not Attached To Building");

        var doesApplicantWishToCoverSignsInsidePremises = data.Resolve("{{data:does_the_applicant_wish_to_cover_any_signs_inside_their_premises_365}}");
        await EnterWithRetryAsync(
            doesApplicantWishToCoverSignsInsidePremises,
            page.EnterDoesTheApplicantWishToCoverAnySignsInsideTheirPremisesAsync,
            () => page.CaptureDoesTheApplicantWishToCoverAnySignsInsideTheirPremisesAsync("value"),
            "Does The Applicant Wish To Cover Any Signs Inside Their Premises");

        var constructionOfEachSign = data.Resolve("{{data:what_is_the_construction_of_each_sign_366}}");
        await EnterWithRetryAsync(
            constructionOfEachSign,
            page.EnterWhatIsTheConstructionOfEachSignAsync,
            () => page.CaptureWhatIsTheConstructionOfEachSignAsync("value"),
            "What Is The Construction Of Each Sign");

        await page.ClickOKAsync();

    }

    [Given(@"^I complete required billing information for billing$")]
    [When(@"^I complete required billing information for billing$")]
    [Then(@"^I complete required billing information for billing$")]
    public async Task CompleteRequiredBillingInformationForBillingAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickNavigationBillingAsync();
        //await page.WaitForBillingAsync("Exists");
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_370}}"));
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_373}}"));
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_377}}"));
        //await page.PauseAsync(1000);

    }

    [Given(@"^I add notepad comment$")]
    [When(@"^I add notepad comment$")]
    [Then(@"^I add notepad comment$")]
    public async Task AddNotepadCommentAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickNotepadAsync();
        //await page.WaitForNotepadHeadingAsync("Exists");
        await page.ClickAddNotesRemarksAsync();
        //await page.PauseAsync(3000);
        var textBoxValue = data.Resolve("Test {B[Product (LOB)]}");
        await EnterWithRetryAsync(
            textBoxValue,
            page.EnterTextBoxAsync,
            () => page.CaptureTextBoxAsync("value"), 
            "TextBox",
            delayMs: 2000, postEnterKeyboardActionAsync: () => page.PressTextBoxAsync("Tab"));

        await page.PressTextBoxAsync("Tab");
        await page.ClickOKAsync();
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
    }

    [Given(@"^I run Stoplight$")]
    [When(@"^I run Stoplight$")]
    [Then(@"^I run Stoplight$")]
    public async Task RunStoplightAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickCompleteApplicationAsync();
        await page.WaitForStoplightWaitingWindowAsync("Exists");
        await page.ClickStoplightWaitingWindowFirstCloseButtonOnErrorAsync();
        //await page.WaitForStoplightWaitingWindowAsync("Absent");
        await page.VerifyAllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabsAsync("Absent", "");
    }

    [Given(@"^I verify values in premium fields$")]
    [When(@"^I verify values in premium fields$")]
    [Then(@"^I verify values in premium fields$")]
    public async Task VerifyValuesInPremiumFieldsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyFullTermPremiumAsync(data.Resolve("{{data:expected_full_term_premium_value_431}}"), "value");
        await page.VerifyPremiumWrittenAsync(data.Resolve("{{data:expected_premium_written_value_432}}"), "value");
        await page.VerifyPriorPremiumAsync(data.Resolve("{{data:expected_prior_premium_value_433}}"), "value");
        await page.VerifyPremiumChangeAsync(data.Resolve("{{data:expected_premium_change_value_434}}"), "value");
    }

    [Given(@"^I complete forms verification$")]
    [When(@"^I complete forms verification$")]
    [Then(@"^I complete forms verification$")]
    public async Task CompleteFormsVerificationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.EnterSessionIDAsync(data.Resolve("{B[SessionId]}"));
        await page.VerifyStatusCodeAsync(data.Resolve("{{data:expected_statuscode_value_441}}"), "value");
        //await page.PauseAsync(1000);
        //await page.PauseAsync(1000);

    }

}
