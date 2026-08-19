using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "IM Smoke Test")]
public sealed class IMSmokeTestSteps
{
    private readonly ScenarioContext _scenario;
    public IMSmokeTestSteps(ScenarioContext scenario) => _scenario = scenario;

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
        await page.PressUserNameAsync("Tab");
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

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickNewQuoteAsync();
        await page.EnterEffectiveDateAsync(data.Resolve("{{data:effective_date_43}}"));
        await page.PressEffectiveDateAsync("Tab");
        if (data.Condition("'Product:*' != \"Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)\""))
        {
                    await page.EnterProductAsync(data.Resolve("{{data:product_45}}"));
                    await page.PressProductAsync("CLICK");
                    await page.PressProductAsync("Enter");
                    await page.PressProductAsync("Tab");
        }
        await page.WaitForStartAsync("Visible");
        await page.ClickStartAsync();
        await page.ClickStartAsync();

    }

    [Given(@"^I enter individual client information$")]
    [When(@"^I enter individual client information$")]
    [Then(@"^I enter individual client information$")]
    public async Task EnterIndividualClientInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("LastName_0067", "^[a-z]{4}$");
        data.GenerateRandom("PrimaryPhone_0068", "[0-9]{10}");
        data.GenerateRandom("InsuredSSN", "125[0-9]{6}");
        data.GenerateRandom("AuditTelephone_0075", "[0-9]{10}");
        data.GenerateRandom("InspectionTelephone_0075", "[0-9]{10}");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.SetQuickQuoteAsync(data.Resolve("{{data:quick_quote_50}}"));
        await page.WaitForUnderwritingInfoAsync("Exists");
        await page.EnterInsuredTypeAsync(data.Resolve("{{data:insured_type_52}}"));
        await page.PressInsuredTypeAsync("Enter");
        await page.PressInsuredTypeAsync("Tab");
        await page.PressInsuredTypeAsync("Tab");
        await page.PressInsuredTypeAsync("Tab");
        await page.ClickEntityTypeAsync();
        await page.WaitForFirstName55A0BAsync("Visible");
        await page.PressFirstName55A0BAsync("TAB");
        await page.PressFirstName55A0BAsync("Tab");
        await page.EnterFirstName55A0BAsync(data.Resolve("{{data:first_name_56}}"));
        await page.PressFirstName55A0BAsync("CLICK");
        await page.PressFirstName55A0BAsync("Tab");
        await page.PressFirstName55A0BAsync("Tab");
        await page.EnterMiddleNameAsync(data.Resolve("{{data:middle_name_57}}"));
        await page.PressMiddleNameAsync("Tab");
        await page.PressMiddleNameAsync("Tab");
        await page.EnterLastNameAsync(data.Resolve("{{runtime:LastName_0067}}"));
        await page.PressLastNameAsync("TAB");
        await page.PressLastNameAsync("Tab");
        await page.EnterDOBAsync(data.Resolve("{DATE[][-40y][MM-dd-yyyy]}"));
        await page.PressDOBAsync("Tab");
        await page.PressDOBAsync("Tab");
        if (data.Condition("State!=\"CA\""))
        {
                    await page.EnterGender1DC4AAsync(data.Resolve("{{data:gender_60}}"));
                    await page.PressGender1DC4AAsync("Tab");
                    await page.PressGender1DC4AAsync("Tab");
        }
        await page.EnterEntityTypeAsync(data.Resolve("{{data:entity_type_62}}"));
        await page.PressEntityTypeAsync("Enter");
        await page.PressEntityTypeAsync("Tab");
        await page.PressEntityTypeAsync("Tab");
        // Source step 0068: RANDOM input for Primary Phone.
        await page.EnterPrimaryPhoneAsync(data.Resolve("{{runtime:PrimaryPhone_0068}}"));
        await page.EnterAddress17A1FBAsync(data.Resolve("{{data:address1_64}}"));
        await page.PressAddress17A1FBAsync("Tab");
        await page.PressAddress17A1FBAsync("Tab");
        await page.EnterZipCode26D22Async(data.Resolve("{{data:zipcode_65}}"));
        await page.PressZipCode26D22Async("Tab");
        await page.PressZipCode26D22Async("Tab");
        await page.ClickClientSearchCA696Async();
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
        await page.WaitForOrderSSN68C87Async("Exists");
        await page.ClickOrderSSN68C87Async();
        await page.WaitForEnterSSN6B3FBAsync("Exists");
        await page.EnterEnterSSN6B3FBAsync(data.Resolve("{{runtime:InsuredSSN}}"));
        data.Set("Last4SSN", data.Get("InsuredSSN").Length >= 4 ? data.Get("InsuredSSN")[^4..] : data.Get("InsuredSSN"));
        await page.PressEnterSSN6B3FBAsync("TAB");
        await page.PressEnterSSN6B3FBAsync("Enter");
        await page.ClickEnterSSN6B3FBAsync();
        await page.PressEnterSSN6B3FBAsync("Doubleclick");
        await page.PressEnterSSN6B3FBAsync("Tab");
        await page.ClickVerify8CDBEAsync();
        await page.WaitForVerify8CDBEAsync("Absent");
        await page.WaitForSocialSecurityAsync("Equal");
        await page.VerifySocialSecurityAsync(data.Resolve("XXX-XX-{B[Last4SSN]}"), "InnerText");
        await page.WaitForPleaseVerifySSN3EAB9Async("Absent");
        if (data.Condition("'Product (LOB)' != \"UMB\""))
        {
                    await page.EnterNameOfAuditContactAsync(data.Resolve("{{data:name_of_audit_contact_82}}"));
                    await page.PressNameOfAuditContactAsync("Tab");
                    await page.PressNameOfAuditContactAsync("CLICK");
                    await page.PressNameOfAuditContactAsync("Tab");
                    await page.PressNameOfAuditContactAsync("Tab");
        }
        // Source step 0075: RANDOM input for Audit Telephone #.
        if (data.Condition("'Product (LOB)' != \"UMB\""))
        {
            await page.EnterAuditTelephoneAsync(data.Resolve("{{runtime:AuditTelephone_0075}}"));
        }
        await page.EnterNameOfInspectionContactAsync(data.Resolve("{{data:name_of_inspection_contact_84}}"));
        await page.PressNameOfInspectionContactAsync("Tab");
        await page.PressNameOfInspectionContactAsync("CLICK");
        await page.PressNameOfInspectionContactAsync("Tab");
        // Source step 0075: RANDOM input for Inspection Telephone #.
        await page.EnterInspectionTelephoneAsync(data.Resolve("{{runtime:InspectionTelephone_0075}}"));
        await page.EnterInsuredEMailAddressAsync(data.Resolve("{{data:insured_e_mail_address_86}}"));
        await page.PressInsuredEMailAddressAsync("Tab");
        await page.PressInsuredEMailAddressAsync("CLICK");
        await page.PressInsuredEMailAddressAsync("Tab");
        await page.EnterWebsiteAddressAsync(data.Resolve("{{data:website_address_87}}"));
        await page.PressWebsiteAddressAsync("Tab");
        await page.PressAddress2Async("TAB");
        await page.PressAddress2Async("Tab");
        await page.VerifyZipCode26D22Async("[0-9]{5}-[0-9]{4}", "Regex:value");
        data.Set("State", data.Resolve("{{data:state}}"));
        data.Set("Product (LOB)", data.Resolve("{{data:product_lob}}"));
        await page.EnterTitleAsync(data.Resolve("{{data:title_94}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_95}}"));
        await page.VerifyResultAsync(data.Resolve("{{data:expected_result_value_96}}"), "value");

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
        await page.EnterEffectiveDate95094Async(data.Resolve("{{data:effectivedate_100}}"));
        await page.PressEffectiveDate95094Async("Tab");
        if (data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
                    await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_101}}"));
                    await page.PressYearsInBusinessAsync("Tab");
        }
        await page.PauseAsync(1000);
        if (data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
                    await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_103}}"));
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
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_107}}"));
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
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_113}}"));
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

    }

    [Given(@"^I navigate to Policy Info and Verify Desc$")]
    [When(@"^I navigate to Policy Info and Verify Desc$")]
    [Then(@"^I navigate to Policy Info and Verify Desc$")]
    public async Task NavigateToPolicyInfoAndVerifyDescAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
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

}
