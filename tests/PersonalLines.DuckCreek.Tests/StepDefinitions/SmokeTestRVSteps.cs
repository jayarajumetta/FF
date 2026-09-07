using InsuranceAutomation.Core;
using InsuranceAutomation.PLDC.Pages;
using Reqnroll;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

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
        data.Set("StateName", data.Resolve("{{data:statename}}"));
        data.Set("State", data.Get("State Abbreviation"));
        await page.WaitForLblClientInfoAsync("Exists");
        await page.VerifyLblClientInfoAsync(data.Resolve("{{data:expected_lbl_client_info_5}}"), "");
        await page.EnterTxtFirstAsync(data.Get("First Name"));
        await page.EnterTxtLastAsync(data.Get("Last Name"));
        await page.WaitForAddEditAdditionalInterestFirstMortgageeSearchAsync("Exists");
        await page.ClickAddEditAdditionalInterestFirstMortgageeSearchAsync();
        await page.WaitForBtnCreateNewClientAsync("Exists");
        await page.ClickBtnCreateNewClientAsync();
        await page.ClickPricingDetailsNextAsync();
    }

    [Given(@"^I enter account details$")]
    [When(@"^I enter account details$")]
    [Then(@"^I enter account details$")]
    public async Task EnterAccountDetailsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new AccountInformationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForAccountInformationAsync("Exists");
        await page.EnterDOBAsync(data.Get("DOB"));
        await page.EnterBestPhoneAccountOwnerAsync(data.Resolve("{{data:txt_best_phone_account_owner_18}}"));
        await page.EnterEmailAccountOwnerAsync(data.Resolve("{{data:txt_email_account_owner_19}}"));
        await page.WaitForMaritalStatusAsync("Exists");
        await page.ClickSingleAsync();
        await page.EnterEnterALocationAsync(data.Get("Street Address"));
        await page.EnterOwnerAddressLine2Async(data.Get("Apartment"));
        await page.EnterOwnerAddressCityNewAsync(data.Get("City"));
        await page.SelectStateAsync(data.Resolve("{{data:state_44}}"));
        await page.EnterOwnerAddressZipAsync(data.Get("ZIP"));
        await page.WaitForSatelliteAsync("Visible");
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
        await page.ClickRecreationalVehicleAsync();
        await page.EnterEffectiveDateAsync(page.GetTomorrowEffectiveDate());
        await page.EnterAgentCodeAsync(data.Resolve("{{data:agentcode_40}}"));
        await page.SelectStateAsync("");
        await page.EnterStateAsync(data.Resolve("{{data:state_44}}"));
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
        await page.PauseAsync(10000);

        if (await page.IsPROCEEDPresentAsync())
        {
            await page.VerifyPROCEEDAsync("Exists", "");
            await page.ClickPROCEEDAsync();
            await page.PauseAsync(5000);
        }
        if (await page.IsSSNPresentAsync())
        {
            await page.WaitForSSNAsync("Exists");
            await page.VerifyProposalStartProceedSSNSUBMITAsync("Exists", "");
            await page.EnterSSNAsync(data.Get("SSN"));
            await page.ClickProposalStartProceedSSNSUBMITAsync();
            await page.PauseAsync(5000);
        }
        if (await page.IsCONFIRMPresentAsync())
        {
            await page.VerifyCONFIRMAsync("Exists", "");
            await page.ClickCONFIRMAsync();
            await page.PauseAsync(5000);
        }
        if (await page.IsUSEEXISTINGACCOUNTPresentAsync())
        {
            await page.ClickUSEEXISTINGACCOUNTAsync();
            await page.PauseAsync(5000);
        }
        //if (await page.IsStateMONTANAPresentAsync())
        //{
        //            await page.ClickStateMONTANAAsync();
        //}
        //if (data.Condition("State != \"MONTANA\""))
        //{
        //            await page.ClickUSEEXISTINGACCOUNTAsync();
        //}


    }

    [Given(@"^I capture the proposal number$")]
    [When(@"^I capture the proposal number$")]
    [Then(@"^I capture the proposal number$")]
    public async Task CaptureTheProposalNumberAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await page.WaitForCaptureQuoteNumberAsync("Exists");
        data.Set("QuoteNumber2", await page.CaptureQNumAsync("InnerText"));
        var quoteNumber = data.Get("QuoteNumber2").ReplaceLineEndings(string.Empty);
        var lastName = data.Get("Last Name");
        if (!string.IsNullOrWhiteSpace(lastName))
        {
            quoteNumber = quoteNumber.Replace(lastName, string.Empty, StringComparison.OrdinalIgnoreCase);
        }
        data.Set("QuoteNumber", quoteNumber.Trim());
    }

    [Given(@"^I complete tabs$")]
    [When(@"^I complete tabs$")]
    [Then(@"^I complete tabs$")]
    public async Task CompleteTabsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickCloseTabAsync();
        await page.EnterQuoteSearchInputAsync(data.Resolve("{{runtime:QuoteNumber}}"));
        await page.ClickTabsSearchAsync();
        await page.VerifyQNumAsync($".*\\b{data.Resolve("{{runtime:QuoteNumber}}")}\\b.*", "Regex:InnerText");
    }

}
