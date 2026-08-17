using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.PLDC.Pages;

namespace InsuranceAutomation.PLDC.StepDefinitions;

[Binding, Scope(Feature = "Smoke Test RV")]
public sealed class SmokeTestRVSteps
{
    private readonly ScenarioContext _scenario;
    public SmokeTestRVSteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I start New Quote$")]
    [When(@"^I start New Quote$")]
    [Then(@"^I start New Quote$")]
    public async Task StartNewQuoteAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForNewQuoteAsync("Exists");
        await page.VerifyNewQuoteAsync(data.Resolve("{{data:expected_btn_new_quote_2}}"), "");
        await page.ClickNewQuoteAsync();

    }

    [Given(@"^I select or create the policy client$")]
    [When(@"^I select or create the policy client$")]
    [Then(@"^I select or create the policy client$")]
    public async Task SelectOrCreateThePolicyClientAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForLblClientInfoAsync("Exists");
        await page.VerifyLblClientInfoAsync(data.Resolve("{{data:expected_lbl_client_info_5}}"), "");
        await page.EnterTxtFirstAsync(data.Get("AL_ClientData.First Name"));
        await page.EnterTxtLastAsync(data.Get("AL_ClientData.Last Name"));
        await page.WaitForAddEditAdditionalInterestFirstMortgageeSearchAsync("Exists");
        await page.ClickAddEditAdditionalInterestFirstMortgageeSearchAsync();
        await page.WaitForBtnCreateNewClientAsync("Exists");
        await page.ClickBtnCreateNewClientAsync();
        await page.ClickPricingDetailsNextAsync();
        data.Set("StateName", data.Resolve("{{data:statename}}"));
        data.Set("State", data.Get("State Abbreviation"));

    }

    [Given(@"^I enter account details$")]
    [When(@"^I enter account details$")]
    [Then(@"^I enter account details$")]
    public async Task EnterAccountDetailsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new AccountInformationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForAccountInformationAsync("Exists");
        await page.VerifyFirstNameAccountOwnerAsync("Exists", "");
        await page.EnterDOBAsync(data.Get("AL_ClientData.DOB"));
        await page.EnterBestPhoneAccountOwnerAsync(data.Resolve("{{data:txt_best_phone_account_owner_18}}"));
        await page.EnterEmailAccountOwnerAsync(data.Resolve("{{data:txt_email_account_owner_19}}"));
        await page.WaitForMaritalStatusAsync("Exists");
        if (data.Condition("'Marital Status' == \"Single\""))
        {
                    await page.ClickSingleAsync();
        }
        if (data.Condition("'Marital Status' == \"Married\""))
        {
                    await page.SelectMarriedAsync("");
        }
        if (data.Condition("'Marital Status' == \"Divorced\""))
        {
                    await page.ClickDivorcedAsync();
        }
        await page.EnterEnterALocationAsync(data.Get("AL_ClientData.Street Address"));
        await page.EnterOwnerAddressLine2Async(data.Get("Apartment"));
        await page.EnterOwnerAddressCityNewAsync(data.Get("AL_ClientData.City"));
        await page.SelectDrpdwnStateAsync("");
        await page.SelectStateNameAsync("");
        await page.EnterOwnerAddressZipAsync(data.Get("AL_ClientData.ZIP"));
        await page.WaitForSatelliteAsync("Visible");
        await page.PressAccountDetailsNextAsync("SHIFTTAB");
        await page.SelectYesAtLeast90DaysAsync("");
        await page.WaitForIsTheAccountAddressAlsoWhereTheClientResidesAsync("Exists");
        await page.SelectYesClientResidesAsync("");
        await page.ClickAccountDetailsNextAsync();

    }

    [Given(@"^I start the policy proposal$")]
    [When(@"^I start the policy proposal$")]
    [Then(@"^I start the policy proposal$")]
    public async Task StartThePolicyProposalAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (data.Condition("LOB == \"PersonalAuto\""))
        {
                    await page.ClickPersonalAutoAsync();
        }
        if (data.Condition("LOB == \"Cycle\""))
        {
                    await page.ClickMotorcycleAsync();
        }
        if (data.Condition("LOB == \"RecreationalVehicle\""))
        {
                    await page.ClickRecreationalVehicleAsync();
        }
        if (data.Condition("LOB != \"RecreationalVehicle\""))
        {
                    await page.EnterEffectiveDateAsync("{DATE}");
        }
        if (data.Condition("LOB != \"RecreationalVehicle\""))
        {
                    await page.EnterAgentCodeAsync(data.Resolve("{{data:agentcode_40}}"));
        }
        if (data.Condition("LOB != \"RecreationalVehicle\""))
        {
                    await page.PressAgentCodeAsync("TAB");
        }
        if (data.Condition("LOB != \"RecreationalVehicle\""))
        {
                    await page.PressStateAsync("TAB");
        }
        if (data.Condition("LOB != \"RecreationalVehicle\""))
        {
                    await page.SelectStateAsync("");
        }
        if (data.Condition("LOB != \"RecreationalVehicle\""))
        {
                    await page.EnterStateAsync(data.Resolve("{{data:state_44}}"));
        }
        if (data.Condition("LOB != \"RecreationalVehicle\""))
        {
                    await page.PressStateAsync("TAB");
        }
        if (data.Condition("LOB != \"RecreationalVehicle\""))
        {
                    await page.PressWritingCompanyAsync("TAB");
        }
        if (data.Condition("LOB != \"RecreationalVehicle\""))
        {
                    await page.SelectWritingCompanyAsync("");
        }
        if (data.Condition("LOB != \"RecreationalVehicle\""))
        {
                    await page.EnterWritingCompanyAsync(data.Resolve("{{data:writingcompany_48}}"));
        }
        if (data.Condition("LOB != \"RecreationalVehicle\""))
        {
                    await page.PressWritingCompanyAsync("TAB");
        }
        await page.WaitForSameAsMailingAddressAsync("True");
        await page.ClickSameAsMailingAddressAsync();
        if (data.Condition("State == \"NEW YORK\""))
        {
                    await page.EnterCountyComboBoxAsync(data.Resolve("{{data:county_combobox_52}}"));
        }
        if (data.Condition("State == \"KENTUCKY\""))
        {
                    await page.EnterCountyComboBoxAsync(data.Resolve("{{data:county_combobox_53}}"));
        }
        if (data.Condition("State == \"NEW YORK\" OR State == \"KENTUCKY\""))
        {
                    await page.WaitForCountyYesAsync("Exists");
        }
        if (data.Condition("State == \"NEW YORK\" OR State == \"KENTUCKY\""))
        {
                    await page.SelectCountyYesAsync("");
        }
        await page.WaitForStartQuoteAsync("True");
        await page.ClickStartQuoteAsync();
        if (await page.IsPROCEEDPresentAsync())
        {
                    await page.VerifyPROCEEDAsync("Exists", "");
        }
        if (await page.IsPROCEEDPresentAsync())
        {
                    await page.ClickPROCEEDAsync();
        }
        if (await page.IsSSNPresentAsync())
        {
                    await page.WaitForSSNAsync("Exists");
        }
        await page.VerifyProposalStartProceedSSNSUBMITAsync("Exists", "");
        if (await page.IsSSNPresentAsync())
        {
                    await page.EnterSSNAsync(data.Get("AL_ClientData.SSN"));
        }
        await page.ClickProposalStartProceedSSNSUBMITAsync();
        if (await page.IsCONFIRMPresentAsync())
        {
                    await page.VerifyCONFIRMAsync("Exists", "");
        }
        if (await page.IsCONFIRMPresentAsync())
        {
                    await page.ClickCONFIRMAsync();
        }
        if (await page.IsUSEEXISTINGACCOUNTPresentAsync())
        {
                    await page.WaitForUSEEXISTINGACCOUNTAsync("Exists");
        }
        if (await page.IsStateMONTANAPresentAsync())
        {
                    await page.ClickStateMONTANAAsync();
        }
        if (data.Condition("State != \"MONTANA\""))
        {
                    await page.ClickUSEEXISTINGACCOUNTAsync();
        }
        data.Set("EffectiveDate", data.Get("Effective Date"));

    }

    [Given(@"^I capture the proposal number$")]
    [When(@"^I capture the proposal number$")]
    [Then(@"^I capture the proposal number$")]
    public async Task CaptureTheProposalNumberAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        data.Set("QuoteNumber2", await page.CaptureQNumAsync("Text"));
        data.Set("QuoteNumber3", data.Resolve("{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}"));
        data.Set("QuoteNumber4", data.Resolve("{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}"));
        data.Set("QuoteNumber", data.Resolve("{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}"));

    }

    [Given(@"^I complete tabs$")]
    [When(@"^I complete tabs$")]
    [Then(@"^I complete tabs$")]
    public async Task CompleteTabsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickCloseTabAsync();
        await page.EnterQuoteSearchInputAsync(data.Resolve("{{runtime:QuoteNumber}}"));
        await page.ClickTabsSearchAsync();
        data.Set("QuoteNumber6", await page.CaptureQNumAsync("Text"));
        await page.VerifyQNumAsync(data.Resolve("{{runtime:QuoteNumber2}}"), "");
        data.Set("QuoteNumber7", data.Resolve("{STRINGREPLACE[{B[QuoteNumber6]}][\"PERSONAL AUTO \"][\"\"]}"));
        data.Set("QuoteNumber8", data.Resolve("{STRINGREPLACE[{B[QuoteNumber7]}][\"\\(\"][\"\"]}"));
        data.Set("QuoteNumber9", data.Resolve("{STRINGREPLACE[{B[QuoteNumber8]}][\"\\)\"][\"\"]}"));

    }

}
