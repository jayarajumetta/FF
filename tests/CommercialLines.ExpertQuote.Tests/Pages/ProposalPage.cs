using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class ProposalPage
{
    private readonly BrowserSession _browser;
    private readonly ProposalLocators _locators;
    private readonly UiActions _ui;

    public ProposalPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new ProposalLocators(browser.Page);
        _ui = ui;
    }

    public Task EnterAgentPCAsync(string value) =>
        _ui.FillAsync(_locators.AgentPC, value, new ControlIntent("Proposal", "AgentPC"));

    public Task PressAgentPCAsync(string key) =>
        _ui.PressAsync(_locators.AgentPC, key, new ControlIntent("Proposal", "AgentPC"));

    public Task SelectBusinessOwnersAsync(string value) =>
        _ui.SelectAsync(_locators.BusinessOwners, value, new ControlIntent("Proposal", "BusinessOwners"));

    public Task ClickBusinessOwnersAsync() =>
        _ui.ClickAsync(_locators.BusinessOwners, new ControlIntent("Proposal", "BusinessOwners"));

    public Task EnterEffectiveDate6F16BAsync(string value) =>
        _ui.FillAsync(_locators.EffectiveDate6F16B, value, new ControlIntent("Proposal", "EffectiveDate6F16B"));

    public Task<string> CaptureEffectiveDate6F16BAsync(string property = "") =>
        _ui.CaptureAsync(_locators.EffectiveDate6F16B, property, new ControlIntent("Proposal", "EffectiveDate6F16B"));

    public Task PressEffectiveDate78F67Async(string key) =>
        _ui.PressAsync(_locators.EffectiveDate78F67, key, new ControlIntent("Proposal", "EffectiveDate78F67"));

    public Task<string> CaptureEffectiveDate78F67Async(string property = "") =>
        _ui.CaptureAsync(_locators.EffectiveDate78F67, property, new ControlIntent("Proposal", "EffectiveDate78F67"));

    public Task EnterIndividualAsync(string value) =>
        _ui.FillAsync(_locators.Individual, value, new ControlIntent("Proposal", "Individual"));

    public Task EnterIndividualDBAAsync(string value) =>
        _ui.FillAsync(_locators.IndividualDBA, value, new ControlIntent("Proposal", "IndividualDBA"));

    public Task ClickIndividuallyOwnedDBAOrTAAsync() =>
        _ui.ClickAsync(_locators.IndividuallyOwnedDBAOrTA, new ControlIntent("Proposal", "IndividuallyOwnedDBAOrTA"));

    public Task SelectLessorsRiskNoAsync(string value) =>
        _ui.SelectAsync(_locators.LessorsRiskNo, value, new ControlIntent("Proposal", "LessorsRiskNo"));

    public Task SelectMissouriAsync(string value) =>
        _ui.SelectAsync(_locators.Missouri, value, new ControlIntent("Proposal", "Missouri"));

    public Task SetNewAccountAddressAsync(string value) =>
        _ui.SmartSetAsync(_locators.NewAccountAddress, value, new ControlIntent("Proposal", "NewAccountAddress"));

    public Task ClickNoAsync() =>
        _ui.ClickAsync(_locators.No, new ControlIntent("Proposal", "No"));

    public Task EnterPolicyTermAsync(string value) =>
        _ui.FillAsync(_locators.PolicyTerm, value, new ControlIntent("Proposal", "PolicyTerm"));

    public Task PressPolicyTermAsync(string key) =>
        _ui.PressAsync(_locators.PolicyTerm, key, new ControlIntent("Proposal", "PolicyTerm"));

    public Task VerifyProposalDetailsAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ProposalDetails, expected, property, new ControlIntent("Proposal", "ProposalDetails"));

    public Task WaitForProposalDetailsHeaderAsync(string expected) =>
        _ui.WaitAsync(_locators.ProposalDetailsHeader, expected, new ControlIntent("Proposal", "ProposalDetailsHeader"));

    public Task PressSearchBusinessNameAsync(string key) =>
        _ui.PressAsync(_locators.SearchBusinessName, key, new ControlIntent("Proposal", "SearchBusinessName"));

    public Task ClickSelectSFPCEAsync() =>
        _ui.ClickAsync(_locators.SelectSFPCE, new ControlIntent("Proposal", "SelectSFPCE"));

    public Task SelectSpecialFarmPackageAsync(string value) =>
        _ui.SelectAsync(_locators.SpecialFarmPackage, value, new ControlIntent("Proposal", "SpecialFarmPackage"));

    public Task ClickStartQuoteAsync() =>
        _ui.ClickAsync(_locators.StartQuote, new ControlIntent("Proposal", "StartQuote"));

    public Task SelectStateAsync(string value) =>
        _ui.SelectAsync(_locators.State, value, new ControlIntent("Proposal", "State"));

    public Task PressStateDropdownAsync(string key) =>
        _ui.PressAsync(_locators.StateDropdown, key, new ControlIntent("Proposal", "StateDropdown"));

    public Task ClickStateDropdownAsync() =>
        _ui.ClickAsync(_locators.StateDropdown, new ControlIntent("Proposal", "StateDropdown"));

    public Task EnterTrueAsync(string value) =>
        _ui.FillAsync(_locators.True, value, new ControlIntent("Proposal", "True"));

}
