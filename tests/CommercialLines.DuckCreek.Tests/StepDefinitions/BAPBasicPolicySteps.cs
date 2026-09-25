using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "BAP Basic Policy")]
public sealed class BAPBasicPolicySteps
{
    private readonly ScenarioContext _scenario;
    public BAPBasicPolicySteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I start a new quote$")]
    [When(@"^I start a new quote$")]
    [Then(@"^I start a new quote$")]
    public async Task StartANewQuoteAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickNewQuoteAsync();
        await page.EnterEffectiveDateAsync(data.Resolve("{{data:effective_date_43}}"));
        await page.PressEffectiveDateAsync("Tab");
        await Task.Delay(2000);
        await page.EnterProductSequentiallyAsync("Carrier  CommercialAuto  Pages   US   (9.23.0.0)");
        await Task.Delay(1000);
        await page.PressProductAsync("Enter");
        await page.PressProductAsync("Tab");
        await Task.Delay(2000);
        await page.EnterProducerSequentiallyAsync("HERALD BENNETT2");
        await page.PressProducerAsync("Tab");
        await Task.Delay(2000);
        await page.WaitForStartAsync("Visible");
        await page.ClickStartAsync();

    }

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

        await page.WaitForQuickQuoteAsync("Visible");
        await page.SetQuickQuoteAsync(data.Resolve("{{data:quick_quote_1}}"));
        await page.WaitForUnderwritingInfoAsync("Exists");
        await page.EnterInsuredTypeAsync(data.Resolve("{{data:insured_type_3}}"));
        await page.EnterEntityTypeAsync(data.Resolve("{{data:entity_type_13}}"));
        await page.WaitForFirstNameAsync("Visible");
        await page.EnterFirstNameAsync(data.Resolve("{{data:first_name_7}}"));
        await page.EnterMiddleNameAsync(data.Resolve("{{data:middle_name_8}}"));
        await page.WaitForLastNameAsync("Visible");
        await page.EnterLastNameAsync(data.Resolve("{{runtime:LastName_0040}}"));
        await page.EnterDOBAsync(data.Resolve("{DATE[][-40y][MM-dd-yyyy]}"));
        if (data.Condition("State!=\"CA\""))
        {
            await page.EnterGenderAsync(data.Resolve("{{data:gender_11}}"));
        }
        await page.EnterPrimaryPhoneAsync(data.Resolve("{{runtime:PrimaryPhone_0041}}"));
        await page.EnterAddressAsync(data.Resolve("{{data:address1_15}}"));
        await page.EnterNamedInsuredZipCodeAsync(data.Resolve("{{data:zipcode_16}}"));
        await page.WaitForClientSearchAsync("Visible");
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
        await page.EnterPolicyInfoRequiredAndOptionalFieldsEffectiveDateAsync(data.Resolve("{{data:effectivedate_51}}"));
        await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_52}}"));
        await page.PauseAsync(1000);
        await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_54}}"));
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_58}}"));
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_68}}"));
        await page.VerifyPriorAmericanNationalPolicyAsync("Absent", "");
        await page.VerifyWhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNationalAsync("Absent", "");
        await page.VerifyIsThisPolicyBeingFullyCancelledAsync("Absent", "");
        await page.PauseAsync(1000);
        await page.WaitForPolicyInfoHeaderAsync("Visible");
        await page.WaitForDescriptionOfSpecifiedOperationAsync("Visible");
        await page.EnterDescriptionOfSpecifiedOperationAsync(data.BuildQuoteDescription());
        data.Set("QuoteDescription", await page.CaptureDescriptionOfSpecifiedOperationAsync("value"));
        await page.PauseAsync(1000);

    }

    [Given(@"^I complete Business Auto policy\-specific fields$")]
    [When(@"^I complete Business Auto policy\-specific fields$")]
    [Then(@"^I complete Business Auto policy\-specific fields$")]
    public async Task CompleteBusinessAutoPolicySpecificFieldsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new DiscountsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyBAPSpecificFieldsOKAsync("Absent", "");
        await page.EnterNAICSCodeSearchValueAsync(data.Resolve("{{data:naics_code_search_value_79}}"));
        await page.PauseAsync(2000);
        await page.EnterNAICSCodeSearchResultsAsync(data.Resolve("{{data:naics_code_search_results_81}}"));
        await page.PauseAsync(2000);
        if (data.Condition("State != \"NY\""))
        {
            await page.EnterAccountCreditAsync(data.Resolve("{{data:account_credit_83}}"));
        }
        await page.PauseAsync(2000);
        await page.WaitForBAPSpecificFieldsOKAsync("Exists");
        await page.ClickBAPSpecificFieldsOKAsync();
        await page.WaitForBAPSpecificFieldsOKAsync("Absent");
        await page.PauseAsync(2000);

    }

    [Given(@"^I run insurance score$")]
    [When(@"^I run insurance score$")]
    [Then(@"^I run insurance score$")]
    public async Task RunInsuranceScoreAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        if (await page.IsInsuranceScoreVisibleAsync())
        {
            await page.ClickInsuranceScoreAsync();
            await page.PauseAsync(2000);
        }

    }

    [Given(@"^I complete underwriting information from the policy information screen$")]
    [When(@"^I complete underwriting information from the policy information screen$")]
    [Then(@"^I complete underwriting information from the policy information screen$")]
    public async Task CompleteUnderwritingInformationFromThePolicyInformationScreenAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyInformationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickEnterPriorLossInformationAsync();
        await page.WaitForLossExperienceHeadingAsync("Exists");
        await page.SetNoKnownLossesAsync(data.Resolve("{{data:no_known_losses_101}}"));
        await page.PauseAsync(1000);
        await page.ClickInsuranceHistoryAsync();
        await page.WaitForIsThereAPriorCarrierAsync("Exists");
        await page.EnterIsThereAPriorCarrierAsync(data.Resolve("{{data:is_there_a_prior_carrier_106}}"));
        await page.EnterCarrierAsync(data.Resolve("{{data:carrier_109}}"));
        await page.EnterPolicyNumberAsync(data.Resolve("{{data:policy_number_110}}"));
        await page.EnterPolicyTypeAsync(data.Resolve("{{data:policy_type_111}}"));
        await page.EnterEffectiveDateAsync(data.Resolve("{DATE[][-2y][MM'/'dd'/'yyyy]}"));
        await page.EnterExpirationDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.EnterModificationFactorAsync(data.Resolve("{{data:modificationfactor_114}}"));
        await page.EnterTotalPremiumAsync(data.Resolve("{{data:total_premium_115}}"));
        await page.ClickOtherInsuranceHistoryOKAsync();
        await page.ClickReturnToQuoteAsync();
       
    }

    [Given(@"^I navigate to policy coverages$")]
    [When(@"^I navigate to policy coverages$")]
    [Then(@"^I navigate to policy coverages$")]
    public async Task NavigateToPolicyCoveragesAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForPolicyCovgerageAsync("Exists");
        await page.ClickPolicyCovgerageAsync();
        await page.EnterTrailerInterchangeCompDeductibleAsync(data.Resolve("{{data:trailer_interchange_comp_deductible_123}}"));
        await page.EnterTrailerInterchangeCollisionDeductibleAsync(data.Resolve("{{data:trailer_interchange_collision_deductible_124}}"));

    }

    [Given(@"^I complete required location information$")]
    [When(@"^I complete required location information$")]
    [Then(@"^I complete required location information$")]
    public async Task CompleteRequiredLocationInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForWCNavigationLinksLocationAsync("Exists");
        await page.ClickWCNavigationLinksLocationAsync();
        await page.ClickOKAsync();
  
    }

    [Given(@"^I navigate to state details$")]
    [When(@"^I navigate to state details$")]
    [Then(@"^I navigate to state details$")]
    public async Task NavigateToStateDetailsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForStateDetailsAsync("Exists");
        await page.ClickStateDetailsAsync();
    
    }

    [Given(@"^I complete vehicle information$")]
    [When(@"^I complete vehicle information$")]
    [Then(@"^I complete vehicle information$")]
    public async Task CompleteVehicleInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForRiskScheduleAsync("Exists");
        await page.ClickRiskScheduleAsync();
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_140}}"));
        await page.ClickAddRiskAtThisLocationAsync();
        await page.WaitForVINAsync("Exists");
        await page.EnterVINAsync(data.Resolve("{{data:vin_144}}"));
        await page.ClickOKAsync();
        await Task.Delay(4000);
        await page.WaitForShowAllLocationsAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_148}}"));
        await page.ClickAddRiskAtThisLocationAsync();
        await page.WaitForVINAsync("Exists");
        await page.EnterVINAsync(data.Resolve("{{data:vin_152}}"));
        await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync(data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_153}}"));
        await page.ClickOKAsync();
        await Task.Delay(2000);

    }

    [Given(@"^I complete driver information$")]
    [When(@"^I complete driver information$")]
    [Then(@"^I complete driver information$")]
    public async Task CompleteDriverInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await Task.Delay(2000);
        await page.ClickDriverScheduleAsync();
        await page.WaitForDriverSchedulePageTitleAsync("Exists");
        await page.ClickAddDriverAsync();
        await page.WaitForFirstNameAsync("Visible");
        await page.EnterFirstNameAsync(data.Resolve("{{data:iframe_duck_creek_policy_first_name_160}}"));
        await page.WaitForLastNameAsync("Visible");
        await page.EnterLastNameAsync(data.Resolve("{{data:iframe_duck_creek_policy_last_name_161}}"));
        await page.WaitForDateOfBirthAsync("Visible");
        await page.EnterDateOfBirthAsync(data.Resolve("{DATE[09-05-2026][-40y][MM-dd-yyyy]}"));
        await page.WaitForStateLicensedAsync("Visible");
        await page.EnterStateLicensedAsync(data.Resolve("{{data:iframe_duck_creek_policy_state_licensed_163}}"));
        await page.WaitForSexAsync("Visible");
        await page.EnterSexAsync(data.Resolve("{{data:iframe_duck_creek_policy_sex_165}}"));
        await page.WaitForMaritalStatusAsync("Visible");
        await page.EnterMaritalStatusAsync(data.Resolve("{{data:iframe_duck_creek_policy_marital_status_166}}"));
        await page.WaitForYearLicensedAsync("Visible");
        await page.EnterYearLicensedAsync(data.Resolve("{{data:iframe_duck_creek_policy_year_licensed_167}}"));
        await page.WaitForDateOfHireAsync("Visible");
        await page.EnterDateOfHireAsync(data.Resolve("{{data:iframe_duck_creek_policy_date_of_hire_168}}"));
        if (await page.DoYouHaveACDLLicenseExistsAsync())
        {
            await page.WaitForDoYouHaveACDLLicenseAsync("Visible");
            await page.EnterDoYouHaveACDLLicenseAsync(data.Resolve("{{data:iframe_duck_creek_policy_do_you_have_a_cdl_license_169}}"));
        }
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();

    }

    [Given(@"^I complete required endorsement information$")]
    [When(@"^I complete required endorsement information$")]
    [Then(@"^I complete required endorsement information$")]
    public async Task CompleteRequiredEndorsementInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForWCNavigationLinksEndorsementsAsync("Exists");
        await page.ClickWCNavigationLinksEndorsementsAsync();

    }

    [Given(@"^I add endorsement$")]
    [When(@"^I add endorsement$")]
    [Then(@"^I add endorsement$")]
    public async Task AddEndorsementAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_192}}"));
        await page.ClickEndorsementsAddEndorsementAsync();
        await page.ClickOKAsync();
   
    }

    [Given(@"^I complete required additional\-interest information$")]
    [When(@"^I complete required additional\-interest information$")]
    [Then(@"^I complete required additional\-interest information$")]
    public async Task CompleteRequiredAdditionalInterestInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForAdditionalInterestsAsync("Exists");
        await page.ClickAdditionalInterestsAsync();

    }

    [Given(@"^I complete required underwriting question information$")]
    [When(@"^I complete required underwriting question information$")]
    [Then(@"^I complete required underwriting question information$")]
    public async Task CompleteRequiredUnderwritingQuestionInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickUWQuestionsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickUpdateAnswersButtonAsync();
        await page.EnterAreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicyAsync(data.Resolve("{{data:are_there_any_commercial_vehicles_owned_by_the_applicant_not_insured_on_the_policy_204}}"));
        await page.EnterAnyPersonalAutoPolicyListingNameInsuredAsync(data.Resolve("{{data:anypersonalautopolicylistingnameinsured_206}}"));
        await page.EnterAnyVehicleCoveredRegisteredInNotPrimaryStateAsync(data.Resolve("{{data:anyvehiclecoveredregisteredinnotprimarystate_207}}"));
        await page.EnterBorrowingHiringOrLeasingWithinYearAsync(data.Resolve("{{data:borrowinghiringorleasingwithinyear_208}}"));
   
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
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_215}}"));
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_218}}"));
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_222}}"));
        await page.PauseAsync(1000);

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
        var noteText = data.Resolve("Test {B[Product (LOB)]}");
        await page.EnterTextBoxSequentiallyAsync(noteText);
        var enteredText = await page.CaptureTextBoxAsync("value");
        if (string.IsNullOrWhiteSpace(enteredText))
        {
            await page.EnterTextBoxSequentiallyAsync(noteText);
        }
        await page.ClickOKAsync();
        await page.PauseAsync(1000);

    }

    [Given(@"^I verify premium$")]
    [When(@"^I verify premium$")]
    [Then(@"^I verify premium$")]
    public async Task VerifyPremiumAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.PauseAsync(2000);
        await page.ClickPricingAsync();
        await page.PauseAsync(2000);
        //await page.WaitForPremiumVisibleAsync();
        //await page.PauseAsync(2000);
        //await page.VerifyPremiumAsync(data.Resolve("{{data:expected_premium_value_233}}"), "value");
        await page.PauseAsync(2000);

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
        await page.PauseAsync(1000);
        await page.WaitForCompleteApplicationAsync("Exists");
        await page.ClickCompleteApplicationAsync();
        await page.WaitForStoplightWaitingResultsAsync("Visible");
        await page.ClickStoplightCloseButtonAsync();
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

        var navigationPage = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await navigationPage.ClickPricingAsync();
        await page.WaitForFullTermPremiumAsync("Visible");
        await navigationPage.PauseAsync(3000);
        await page.VerifyFullTermPremiumAsync(data.Resolve("{{data:expected_full_term_premium_value_280}}"), "value");
        await page.VerifyPremiumWrittenAsync(data.Resolve("{{data:expected_premium_written_value_281}}"), "value");
        await page.VerifyPriorPremiumAsync(data.Resolve("{{data:expected_prior_premium_value_282}}"), "value");
        await page.VerifyPremiumChangeAsync(data.Resolve("{{data:expected_premium_change_value_283}}"), "value");
        //await page.EnterTitleAsync(data.Resolve("{{data:title_285}}"));
        //await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_286}}"));
        //data.Set("SessionId", await page.CaptureResultAsync("value"));

    }

    [Given(@"^I complete forms verification$")]
    [When(@"^I complete forms verification$")]
    [Then(@"^I complete forms verification$")]
    public async Task CompleteFormsVerificationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.EnterSessionIDAsync(data.Resolve("{B[SessionId]}"));
        await page.VerifyStatusCodeAsync(data.Resolve("{{data:expected_statuscode_value_290}}"), "value");
        await page.PauseAsync(1000);
        await page.PauseAsync(1000);

    }

    }
