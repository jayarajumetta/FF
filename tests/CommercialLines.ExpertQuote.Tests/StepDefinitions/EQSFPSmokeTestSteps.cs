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
        await page.PressAdditionalInterestsNextAsync("TAB");
        data.Set("StateName", data.Resolve("{{data:statename}}"));

    }

    [Given(@"^I enter account details$")]
    [When(@"^I enter account details$")]
    [Then(@"^I enter account details$")]
    public async Task EnterAccountDetailsAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("OwnerPhone", "3[0-9]{9}");
        data.GenerateRandom("OwnerEmail", "test@[a-z]{4}\\\\.com");

        var page = new AccountInformationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForAccountInformationHeaderAsync("Visible");
        await page.PressOwnerMiddleNameAsync("TAB");
        await page.SelectMarriedAsync("");
        await page.PressStreetAddressAsync("SHIFTTAB");
        await page.PressStreetAddressAsync("ENTER");
        await page.PressStreetAddressAsync("Tab");
        await page.PressAddress2Async("ENTER");
        await page.PressAddress2Async("Tab");
        await page.PressCityAsync("ENTER");
        await page.PressCityAsync("Tab");
        await page.ClickStateDropdownAsync();
        await page.SelectState0110EAsync(data.Resolve("{{runtime:StateName}}"));
        await page.PressZipAsync("ENTER");
        await page.PressZipAsync("Tab");
        await page.WaitForMapAsync("Exists");
        await page.WaitForSatelliteAsync("Exists");
        await page.PressAdditionalInterestsNextAsync("SHIFTTAB");
        await page.SelectHaveYouReceivedMailAtThisAddressForAtLeast90DaysYesAsync("");
        await page.SelectIsTheAccountAddressAlsoWhereTheClientResidesYesAsync("");
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
        await page.PressEffectiveDate78F67Async("Tab");
        await page.EnterTrueAsync(data.Resolve("{{data:true_34}}"));
        await page.PressPolicyTermAsync("TAB");
        await page.EnterPolicyTermAsync(data.Resolve("{{data:policyterm_36}}"));
        await page.PressPolicyTermAsync("TAB");
        await page.PressStateDropdownAsync("TAB");
        await page.SelectStateAsync(data.Resolve("{{runtime:StateName}}"));
        await page.PressAgentPCAsync("ENTER");
        await page.PressAgentPCAsync("Tab");
        data.Set("EffDate", await page.CaptureEffectiveDate78F67Async("InnerText"));
        await page.ClickStateDropdownAsync();
        await page.ClickStartQuoteAsync();
        data.Set("LOB", data.Resolve("{{data:lob}}"));
        data.Set("WaitOnTime", data.Resolve("{{data:waitontime}}"));

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
        await page.WaitForSubmitAngularAsync("Visible");
        await page.PressSubmitAngularAsync("TAB");
        await page.ClickSubmitAngularAsync();
        if (await page.IsNoPrefillMatchFoundPresentAsync())
        {
                    await page.VerifyNoPrefillMatchFoundAsync("Exists", "");
        }
        if (await page.IsContinuePresentAsync())
        {
                    await page.ClickContinueAsync();
        }
        data.Set("WaitOnTime", data.Resolve("{{data:waitontime_2}}"));
        data.Set("Screen", data.Resolve("{{data:screen}}"));
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
        data.Set("Screen", data.Resolve("{{data:screen}}"));
        data.Set("Screen", data.Resolve("{{data:screen_2}}"));
        if (!await page.IsLoadingPresentAsync())
        {
                    await page.WaitForLoadingAsync("Absent");
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
        data.Set("QuoteID", data.Resolve("{{runtime:Quote_Num}}"));
        await page.ClickCloseQuoteAsync();
        await page.WaitForLoadingAsync("Absent");

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
        await page.PressQuoteSearchInputAsync("Tab");
        await page.PressQuoteSearchInputAsync("Tab");
        await page.ClickClientInfoSearchAsync();
        await page.WaitForLoadingAsync("Absent");
        data.Set("Screen", data.Resolve("{{data:screen}}"));
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
        data.Set("Screen", data.Resolve("{{data:screen}}"));
        data.Set("Screen", data.Resolve("{{data:screen_2}}"));
        if (!await page.IsLoadingPresentAsync())
        {
                    await page.WaitForLoadingAsync("Absent");
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
