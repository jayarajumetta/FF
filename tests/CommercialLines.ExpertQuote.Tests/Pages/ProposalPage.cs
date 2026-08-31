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
        _ui.SelectAsync(_locators.BusinessOwnersChip, value, new ControlIntent("Proposal", "BusinessOwners"));

    public Task ClickBusinessOwnersAsync() =>
        _ui.ClickAsync(_locators.BusinessOwnersChip, new ControlIntent("Proposal", "BusinessOwners"));

    public Task EnterEffectiveDate6F16BAsync(string value) =>
        _ui.FillAsync(_locators.EffectiveDate, value, new ControlIntent("Proposal", "EffectiveDate6F16B"));

    public Task<string> CaptureEffectiveDate6F16BAsync(string property = "") =>
        _ui.CaptureAsync(_locators.EffectiveDate, property, new ControlIntent("Proposal", "EffectiveDate6F16B"));

    public Task PressEffectiveDate78F67Async(string key) =>
        _ui.PressAsync(_locators.EffectiveDate, key, new ControlIntent("Proposal", "EffectiveDate78F67"));

    public Task<string> CaptureEffectiveDate78F67Async(string property = "") =>
        _ui.CaptureAsync(_locators.EffectiveDate, property, new ControlIntent("Proposal", "EffectiveDate78F67"));

    public Task EnterIndividualAsync(string value) =>
        _ui.ReviewRequiredAsync($"BusinessType source parameter = '{value}'. This is orchestration data, not an editable control.");

    public Task EnterIndividualDBAAsync(string value) =>
        _ui.FillAsync(_locators.DbaOrTaNameField, value, new ControlIntent("Proposal", "IndividualDBA"));

    public Task ClickIndividuallyOwnedDBAOrTAAsync() =>
        _ui.ClickAsync(_locators.IndividuallyOwnedDbaCheckbox, new ControlIntent("Proposal", "IndividuallyOwnedDBAOrTA"));

    public Task SelectLessorsRiskNoAsync(string value) =>
        _ui.SelectAsync(_locators.LessorsRiskNoChip, value, new ControlIntent("Proposal", "LessorsRiskNo"));

    public Task ClickLessorsRiskNoAsync() =>
    _ui.ClickAsync(_locators.LessorsRiskNoChip, new ControlIntent("Proposal", "LessorsRiskNo"));

    public Task SelectMissouriAsync(string value) =>
        _ui.SelectAsync(_locators.Missouri, value, new ControlIntent("Proposal", "Missouri"));

    public Task ClickRatingStateDropdownOptionAsync(string value) =>
    _ui.ClickAsync(_locators.GetDropdownOption(value), new ControlIntent("Proposal", "Missouri"));

    
    public Task ClickRatingStateDropdownAsync() =>
    _ui.ClickAsync(_locators.RatingStateDropdown, new ControlIntent("Proposal", "Missouri"));

    public Task SetNewAccountAddressAsync(string value) =>
        _ui.SmartSetAsync(_locators.AccountAddressRadio, value, new ControlIntent("Proposal", "NewAccountAddress"));

    public Task ClickNoAsync() =>
        _ui.ClickAsync(_locators.LessorsRiskNoChip, new ControlIntent("Proposal", "No"));

    public Task EnterPolicyTermAsync(string value) =>
        _ui.FillAsync(_locators.PolicyTermDropdown, value, new ControlIntent("Proposal", "PolicyTerm"));

    public Task PressPolicyTermAsync(string key) =>
        _ui.PressAsync(_locators.PolicyTermDropdown, key, new ControlIntent("Proposal", "PolicyTerm"));

    public Task VerifyProposalDetailsAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ProposalDetailsHeader, expected, property, new ControlIntent("Proposal", "ProposalDetails"));

    public Task WaitForProposalDetailsHeaderAsync(string expected) =>
        _ui.WaitAsync(_locators.ProposalDetailsHeader, expected, new ControlIntent("Proposal", "ProposalDetailsHeader"));

    public Task PressSearchBusinessNameAsync(string key) =>
        _ui.PressAsync(_locators.BusinessNameSearchField, key, new ControlIntent("Proposal", "SearchBusinessName"));

    public Task ClickSelectSFPCEAsync() =>
        _ui.ClickAsync(_locators.SelectSFPCE, new ControlIntent("Proposal", "SelectSFPCE"));

    public Task SelectSpecialFarmPackageAsync(string value) =>
        _ui.SelectAsync(_locators.SpecialFarmPackageChip, value, new ControlIntent("Proposal", "SpecialFarmPackage"));

    public Task ClickStartQuoteAsync() =>
        _ui.ClickAsync(_locators.StartQuoteButton, new ControlIntent("Proposal", "StartQuote"));

    public Task SelectStateAsync(string value) =>
        _ui.SelectAsync(_locators.RatingStateDropdown, value, new ControlIntent("Proposal", "RatingState"));

    public Task PressStateDropdownAsync(string key) =>
        _ui.PressAsync(_locators.RatingStateDropdown, key, new ControlIntent("Proposal", "StateDropdown"));

    public Task ClickStateDropdownAsync() =>
        _ui.ClickAsync(_locators.RatingStateDropdown, new ControlIntent("Proposal", "StateDropdown"));

    // Semantic alias retained for source-step compatibility; one physical Page method owns the control.
    public Task EnterTrueAsync(string value) => SetNewAccountAddressAsync(value);

}
