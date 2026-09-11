using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLEQ.Pages;

namespace InsuranceAutomation.CLEQ.StepDefinitions;

[Binding, Scope(Feature = "EQ SFP Smoke Test")]
public sealed class EQSFPSmokeTestSteps
{
    private readonly ScenarioContext _scenario;
    public EQSFPSmokeTestSteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I enter client search information$")]
    [When(@"^I enter client search information$")]
    [Then(@"^I enter client search information$")]
    public async Task EnterClientSearchInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("LastName", "Smoke[a-z]{4}");
        data.GenerateRandom("FirstName", "SFP [a-z]{3}");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForClientInfoAsync("Visible");
        await page.WaitForNewExistingClientSearchAsync("Visible");
        await page.EnterCustomerNameFirstAsync(data.Resolve("{{runtime:FirstName}}"));
        await page.EnterCustomerNameLastAsync(data.Resolve("{{runtime:LastName}}"));
        await page.EnterCustomerDateOfBirthAsync(data.Resolve("{{data:customer_dateofbirth_7}}"));
        await page.ClickClientInfoSearchAsync();

    }

    [Given(@"^I create a new client$")]
    [When(@"^I create a new client$")]
    [Then(@"^I create a new client$")]
    public async Task CreateANewClientAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForExistingClientMatchAsync("Exists");
        await page.ClickCreateNewClient1Async();
        data.Set("StateName", data.Resolve("{{data:statename}}"));

    }

    [Given(@"^I enter account details$")]
    [When(@"^I enter account details$")]
    [Then(@"^I enter account details$")]
    public async Task EnterAccountDetailsAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("OwnerPhone");
        data.GenerateRandom("OwnerEmail");

        var page = new AccountInformationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // XTestStep/XTestStepValue order is authoritative; manual CSV/workbooks are not inputs.
        await page.WaitForAccountInformationHeaderAsync("Visible");
        await page.EnterOwnerMiddleNameAsync("");
        await page.EnterOwnerPhoneAsync(data.Resolve("{{runtime:OwnerPhone}}"));
        await page.EnterOwnerEmailAsync(data.Resolve("{{runtime:OwnerEmail}}"));
        await page.ClickMarriedAsync();

        await page.EnterStreetAddressAsync(data.GetCanonicalFieldRequired("Address 1"));
        await page.EnterAddress2Async(data.GetCanonicalField("Address 2"));
        await page.EnterCityAsync(data.GetCanonicalFieldRequired("City"));
        await page.SelectStateAsync(data.GetCanonicalFieldRequired("State Name"));
        await page.EnterZipAsync(data.GetCanonicalFieldRequired("Zip"));

        var county = data.GetCanonicalField("County");
        if (!string.IsNullOrWhiteSpace(county))
            await page.EnterCountyAsync(county);

        // Map/Satellite are generated only after address steering in raw Tosca.
        await page.VerifyMapAsync("Visible", "");
        await page.VerifySatelliteAsync("Visible", "");

        await page.SelectHaveYouReceivedMailAtThisAddressForAtLeast90DaysYesAsync();
        await page.SelectIsTheAccountAddressAlsoWhereTheClientResidesYesAsync();
        await page.ClickAdditionalInterestsNextAsync();
    }


    [Given(@"^I start the policy proposal$")]
    [When(@"^I start the policy proposal$")]
    [Then(@"^I start the policy proposal$")]
    public async Task StartThePolicyProposalAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForProposalDetailsHeaderAsync("Visible");
        await page.SelectSpecialFarmPackageAsync("");
        await page.PressEffectiveDate78F67Async("ENTER");
        await page.EnterTrueAsync(data.Resolve("{{data:true_34}}"));
        await page.EnterPolicyTermAsync(data.Resolve("{{data:policyterm_36}}"));
        await page.SelectStateAsync(data.Resolve("{{runtime:StateName}}"));
        await page.PressAgentPCAsync("ENTER");
        await page.ClickStateDropdownAsync();
        await page.ClickStartQuoteAsync();

    }

    [Given(@"^I enter and validate the insured social security number$")]
    [When(@"^I enter and validate the insured social security number$")]
    [Then(@"^I enter and validate the insured social security number$")]
    public async Task EnterAndValidateTheInsuredSocialSecurityNumberAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("InsuredSSN", "025[0-9]{6}");

        var page = new SocialSecurityPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForTheSSNCouldNotBeFoundPleaseEnterAnSSNAsync("Visible");
        // Source step 0042: RANDOM input for ssn.
        await page.EnterTheSSNCouldNotBeFoundPleaseEnterAnSSNAsync(data.Resolve("{{runtime:InsuredSSN}}"));
        await page.WaitForSubmitAngularAsync("Visible");
        await page.ClickSubmitAngularAsync();
        if (await page.IsNoPrefillMatchFoundPresentAsync())
        {
                    await page.VerifyNoPrefillMatchFoundAsync("Exists", "");
        }
        if (await page.IsContinuePresentAsync())
        {
                    await page.ClickContinueAsync();
        }
        if (!await page.IsScreenHeadingPresentAsync())
        {
                    await page.VerifyScreenHeadingAsync("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen$")]
    [When(@"^I navigate to the required policy screen$")]
    [Then(@"^I navigate to the required policy screen$")]
    public async Task NavigateToTheRequiredPolicyScreenAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (!await page.IsScreen4475CPresentAsync())
        {
                    await page.ClickScreen4475CAsync();
        }
        if (data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
                    await page.ClickKeepGoingAsync();
        }
        if (!await page.IsLoadingPresentAsync())
        {
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.WaitForScreenHeading9696CAsync("Exists");
        }

    }

    [Given(@"^I complete quote Identifying and Close Quote$")]
    [When(@"^I complete quote Identifying and Close Quote$")]
    [Then(@"^I complete quote Identifying and Close Quote$")]
    public async Task CompleteQuoteIdentifyingAndCloseQuoteAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        data.Set("Quote_NameNum", await page.CaptureNameAndQuoteAsync("InnerText"));
        data.Set("Quote_Num", data.Resolve("{STRINGREPLACE[{B[Quote_NameNum]}][{B[LastName]}][]}"));
        await page.ClickCloseQuoteAsync();

    }

    [Given(@"^I search by QuoteNum$")]
    [When(@"^I search by QuoteNum$")]
    [Then(@"^I search by QuoteNum$")]
    public async Task SearchByQuoteNumAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.EnterQuoteSearchInputAsync(data.Resolve("{B[Quote_Num]}"));
        await page.ClickClientInfoSearchAsync();
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.VerifyScreenHeading9696CAsync("Absent", "");
        }

    }

    [Given(@"^I navigate to the required policy screen for screen$")]
    [When(@"^I navigate to the required policy screen for screen$")]
    [Then(@"^I navigate to the required policy screen for screen$")]
    public async Task NavigateToTheRequiredPolicyScreenForScreenAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (!await page.IsScreen4475CPresentAsync())
        {
                    await page.ClickScreen4475CAsync();
        }
        if (data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
                    await page.ClickKeepGoingAsync();
        }
        if (!await page.IsLoadingPresentAsync())
        {
        }
        if (!await page.IsScreenHeading9696CPresentAsync())
        {
                    await page.WaitForScreenHeading9696CAsync("Exists");
        }

    }

    [Given(@"^I complete verifying Quote$")]
    [When(@"^I complete verifying Quote$")]
    [Then(@"^I complete verifying Quote$")]
    public async Task CompleteVerifyingQuoteAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.VerifyNameAndQuoteAsync(data.Resolve("{{data:expected_name_and_quote_innertext_78}}"), "InnerText");

    }

}
