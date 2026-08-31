using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "WC Smoke Test")]
public sealed class WCSmokeTestSteps
{
    private readonly ScenarioContext _scenario;
    public WCSmokeTestSteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I sign in to Duck Creek$")]
    [When(@"^I sign in to Duck Creek$")]
    [Then(@"^I sign in to Duck Creek$")]
    public async Task SignInToDuckCreekAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

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

        await page.VerifyOKAsync("Exists", "");
        await page.ClickOKAsync();

    }

    [Given(@"^I sign in to Duck Creek for logged in user$")]
    [When(@"^I sign in to Duck Creek for logged in user$")]
    [Then(@"^I sign in to Duck Creek for logged in user$")]
    public async Task SignInToDuckCreekForLoggedInUserAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyLoggedInUserAsync("Exists", "");

    }

    [Given(@"^I sign out of the application$")]
    [When(@"^I sign out of the application$")]
    [Then(@"^I sign out of the application$")]
    public async Task SignOutOfTheApplicationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickLoggedInUserAsync();
        await page.ClickLogoutAsync();
        await page.PauseAsync(1000);
        await page.VerifyBrowserCommunicationHTTPStatusZeroAsync("Exists", "");
        await page.ClickOKAsync();
        await page.WaitForOKAsync("Absent");
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

        await page.EnterUserNameAsync(data.Resolve("{{env:CL_DC_USERNAME}}"));
        await page.EnterPasswordAsync(data.Resolve("{{env:CL_DC_PASSWORD}}"));
        await page.ClickLoginAsync();
        await page.WaitForLoginAsync("Absent");

    }

    [Given(@"^I start a new quote$")]
    [When(@"^I start a new quote$")]
    [Then(@"^I start a new quote$")]
    public async Task StartANewQuoteAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickNewQuoteAsync();
        await page.EnterEffectiveDateAsync(data.Resolve("{{data:effective_date_43}}"));
        await page.EnterProductAsync(data.Resolve("{{data:product_45}}"));
        await page.EnterProducerAsync(data.Resolve("{{data:producer}}"));
        await page.WaitForStartAsync("Visible");
        await page.ClickStartAsync();

    }

    [Given(@"^I enter business client information$")]
    [When(@"^I enter business client information$")]
    [Then(@"^I enter business client information$")]
    public async Task EnterBusinessClientInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("PrimaryPhone_0082", "[0-9]{10}");
        data.GenerateRandom("FEIN_0085", "486[0-9]{6}");
        data.GenerateRandom("AuditTelephone_0086", "[0-9]{10}");
        data.GenerateRandom("InspectionTelephone_0086", "[0-9]{10}");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForQuickQuoteAsync("Exists");
        await page.SetQuickQuoteAsync(data.Resolve("{{data:quick_quote_51}}"));
        await page.WaitForUnderwritingInfoAsync("Exists");
        await page.EnterInsuredTypeAsync(data.Resolve("{{data:insured_type_53}}"));
        await page.EnterEntityTypeAsync(data.Resolve("{{data:entity_type_57}}"));
        await page.WaitForBusinessNameAsync("Visible");
        await page.EnterBusinessNameAsync(data.Resolve("{{data:business_name_56}}"));
        await page.EnterPrimaryPhoneAsync(data.Resolve("{{runtime:PrimaryPhone_0082}}"));
        await page.EnterNamedInsuredZipCodeAsync(data.Resolve("{{data:zipcode_60}}"));
        await page.EnterFEINAsync(data.Resolve("{{runtime:FEIN_0085}}"));

        await page.EnterAddressAsync(data.Resolve("{{data:address1_61}}"));
        await page.VerifyYearsInBusinessAsync("Exists", "");
        await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_63}}"));
        await page.EnterNameOfAuditContactAsync(data.Resolve("{{data:name_of_audit_contact_65}}"));
        await page.EnterAuditTelephoneAsync(data.Resolve("{{runtime:AuditTelephone_0086}}"));
        await page.EnterNameOfInspectionContactAsync(data.Resolve("{{data:name_of_inspection_contact_67}}"));
        await page.EnterInspectionTelephoneAsync(data.Resolve("{{runtime:InspectionTelephone_0086}}"));
        await page.EnterInsuredEMailAddressAsync(data.Resolve("{{data:insured_e_mail_address_69}}"));
        await page.EnterWebsiteAddressAsync(data.Resolve("{{data:website_address_70}}"));
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
        await page.VerifyIndividualTypeAsync("Absent", "");

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
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_86}}"));
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_89}}"));
        await page.WaitForPayPlanAsync("Equal");
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_93}}"));
        await page.PauseAsync(1000);

    }

    [Given(@"^I complete the Associated Client Info$")]
    [When(@"^I complete the Associated Client Info$")]
    [Then(@"^I complete the Associated Client Info$")]
    public async Task CompleteTheAssociatedClientInfoAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("MiddleName_0098", "^[a-z]{1}$");
        data.GenerateRandom("LastName_0098", "^[a-z]{7}$");
        data.GenerateRandom("FirstName_0098", "^[a-z]{4}$");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.EnterIndividualTypeAsync(data.Resolve("{{data:individualtype_96}}"));
        await page.WaitForPleaseVerifySSNAsync("Exists");
        await page.PauseAsync(4000);
        await page.EnterFirstNameAsync(data.Resolve("{{runtime:FirstName_0098}}"));
        await page.EnterMiddleNameAsync(data.Resolve("{{runtime:MiddleName_0098}}"));
        await page.PauseAsync(4000);
        await page.EnterLastNameAsync(data.Resolve("{{runtime:LastName_0098}}"));
        await page.EnterAddAssociatedClientDateOfBirthAsync(data.Resolve("{{data:dateofbirth_101}}"));
        await page.EnterAddressAsync(data.Resolve("{{data:address1_102}}"));
        await page.PauseAsync(1000);
        await page.EnterCityAsync(data.Resolve("{{data:city_103}}"));
        await page.EnterStateAsync(data.Resolve("{{data:state_104}}"));
        await page.EnterNamedInsuredZipCodeAsync(data.Resolve("{{data:zipcode_105}}"));
        await page.EnterGenderAsync(data.Resolve("{{data:gender_106}}"));
        await page.PauseAsync(4000);
        await page.WaitForClientSearchAsync("Exists");
        await page.ClickClientSearchAsync();
        await page.VerifySearchResultsDuckCreekPolicyFirstCheckboxAsync("Absent", "");
        await page.PauseAsync(1000);
        await page.ClickOKAsync();
        await page.ClickOrderSSNAsync();
        await page.EnterAddAssociatedClientEnterSSNAsync(data.Resolve("{{data:enter_ssn_114}}"));
        await page.ClickVerifyAsync();
        await page.WaitForPleaseVerifySSNAsync("Absent");
        await page.ClickCompleteAsync();
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
        await page.EnterPolicyInfoRequiredAndOptionalFieldsEffectiveDateAsync(data.Resolve("{{data:effectivedate_138}}"));
        await page.PauseAsync(1000);
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_141}}"));
        await page.PauseAsync(1000);
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_145}}"));
        await page.VerifyPriorAmericanNationalPolicyAsync("Absent", "");
        await page.VerifyWhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNationalAsync("Absent", "");
        await page.VerifyIsThisPolicyBeingFullyCancelledAsync("Absent", "");
        await page.PauseAsync(1000);

    }

    [Given(@"^I complete WC Specific Fields$")]
    [When(@"^I complete WC Specific Fields$")]
    [Then(@"^I complete WC Specific Fields$")]
    public async Task CompleteWCSpecificFieldsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.EnterHasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverageAsync(data.Resolve("{{data:has_the_applicant_been_in_business_for_at_least_3_years_with_continuous_workers_compensation_coverage_150}}"));
        await page.WaitForPolicyInfoHeaderAsync("Visible");
        await page.WaitForDescriptionOfSpecifiedOperationAsync("Visible");
        await page.EnterDescriptionOfSpecifiedOperationAsync(data.BuildQuoteDescription());
        data.Set("QuoteDescription", await page.CaptureDescriptionOfSpecifiedOperationAsync("value"));

    }

    [Given(@"^I navigate to Policy Info and Verify Desc$")]
    [When(@"^I navigate to Policy Info and Verify Desc$")]
    [Then(@"^I navigate to Policy Info and Verify Desc$")]
    public async Task NavigateToPolicyInfoAndVerifyDescAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickPolicyInfoAsync();
        await page.VerifyDescriptionOfSpecifiedOperationAsync(data.Resolve("{B[QuoteDescription]}"), "value");

    }

    [Given(@"^I sign out of the application for logged in user$")]
    [When(@"^I sign out of the application for logged in user$")]
    [Then(@"^I sign out of the application for logged in user$")]
    public async Task SignOutOfTheApplicationForLoggedInUserAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickLoggedInUserAsync();
        await page.ClickLogoutAsync();
        await page.PauseAsync(1000);
        await page.VerifyBrowserCommunicationHTTPStatusZeroAsync("Exists", "");
        await page.ClickOKAsync();
        await page.WaitForOKAsync("Absent");
        await page.ClickLoggedInUserAsync();
        await page.ClickLogoutAsync();

    }

}
