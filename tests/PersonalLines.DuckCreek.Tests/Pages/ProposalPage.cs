using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

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

    public Task EnterAgentCodeAsync(string value) =>
        _ui.FillAsync(_locators.AgentCode, value, new ControlIntent("Proposal", "AgentCode"));

    public Task PressAgentCodeAsync(string key) =>
        _ui.PressAsync(_locators.AgentCode, key, new ControlIntent("Proposal", "AgentCode"));

    public Task VerifyCONFIRMAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.CONFIRM, expected, property, new ControlIntent("Proposal", "CONFIRM"));

    public Task ClickCONFIRMAsync() =>
        _ui.ClickAsync(_locators.CONFIRM, new ControlIntent("Proposal", "CONFIRM"));

    public Task<bool> IsCONFIRMPresentAsync() =>
        _ui.ExistsAsync(_locators.CONFIRM);

    public Task ClickCREATENEWACCOUNTAsync() =>
        _ui.ClickAsync(_locators.CREATENEWACCOUNT, new ControlIntent("Proposal", "CREATENEWACCOUNT"));

    public Task<bool> IsCREATENEWACCOUNTPresentAsync() =>
        _ui.ExistsAsync(_locators.CREATENEWACCOUNT);

    public Task VerifyClientAlreadyExistsAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ClientAlreadyExists, expected, property, new ControlIntent("Proposal", "ClientAlreadyExists"));

    public Task<bool> IsClientAlreadyExistsPresentAsync() =>
        _ui.ExistsAsync(_locators.ClientAlreadyExists);

    public Task EnterCountyComboBoxAsync(string value) =>
        _ui.FillAsync(_locators.CountyComboBox, value, new ControlIntent("Proposal", "CountyComboBox"));

    public Task WaitForCountyYesAsync(string expected) =>
        _ui.WaitAsync(_locators.CONFIRM, expected, new ControlIntent("Proposal", "CountyYes"));

    public Task SelectCountyYesAsync(string value) =>
        _ui.SelectAsync(_locators.CONFIRM, value, new ControlIntent("Proposal", "CountyYes"));

    public Task EnterEffectiveDateAsync(string value) =>
        _ui.FillAsync(_locators.EffectiveDate, value, new ControlIntent("Proposal", "EffectiveDate"));

    public Task PressEffectiveDateAsync(string key) =>
        _ui.PressAsync(_locators.EffectiveDate, key, new ControlIntent("Proposal", "EffectiveDate"));

    public Task ClickMotorcycleAsync() =>
        _ui.ClickAsync(_locators.Motorcycle, new ControlIntent("Proposal", "Motorcycle"));

    public Task WaitForNewQuoteAsync(string expected) =>
        _ui.WaitAsync(_locators.NewQuote, expected, new ControlIntent("Proposal", "NewQuote"));

    public Task VerifyNewQuoteAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.NewQuote, expected, property, new ControlIntent("Proposal", "NewQuote"));

    public Task ClickNewQuoteAsync() =>
        _ui.ClickAsync(_locators.NewQuote, new ControlIntent("Proposal", "NewQuote"));

    public Task VerifyPROCEEDAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.CONFIRM, expected, property, new ControlIntent("Proposal", "PROCEED"));

    public Task ClickPROCEEDAsync() =>
        _ui.ClickAsync(_locators.CONFIRM, new ControlIntent("Proposal", "PROCEED"));

    public Task<bool> IsPROCEEDPresentAsync() =>
        _ui.ExistsAsync(_locators.CONFIRM);

    public Task ClickPersonalAutoAsync() =>
        _ui.ClickAsync(_locators.Motorcycle, new ControlIntent("Proposal", "PersonalAuto"));

    public Task VerifyProposalStartProceedSSNSUBMITAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.CONFIRM, expected, property, new ControlIntent("Proposal", "ProposalStartProceedSSNSUBMIT"));

    public Task ClickProposalStartProceedSSNSUBMITAsync() =>
        _ui.ClickAsync(_locators.CONFIRM, new ControlIntent("Proposal", "ProposalStartProceedSSNSUBMIT"));

    public Task<string> CaptureQNumAsync(string property = "") =>
        _ui.CaptureAsync(_locators.NewQuote, property, new ControlIntent("Proposal", "QNum"));

    public Task<string> CaptureQuoteNumberAsync(string property = "") =>
        _ui.CaptureAsync(_locators.QuoteNumber, property, new ControlIntent("Proposal", "QuoteNumber"));

    public Task ClickRecreationalVehicleAsync() =>
        _ui.ClickAsync(_locators.Motorcycle, new ControlIntent("Proposal", "RecreationalVehicle"));

    public Task WaitForSSNAsync(string expected) =>
        _ui.WaitAsync(_locators.SSN, expected, new ControlIntent("Proposal", "SSN"));

    public Task VerifySSNAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.SSN, expected, property, new ControlIntent("Proposal", "SSN"));

    public Task EnterSSNAsync(string value) =>
        _ui.FillAsync(_locators.SSN, value, new ControlIntent("Proposal", "SSN"));

    public Task<bool> IsSSNPresentAsync() =>
        _ui.ExistsAsync(_locators.SSN);

    public Task WaitForSameAsMailingAddressAsync(string expected) =>
        _ui.WaitAsync(_locators.SameAsMailingAddress, expected, new ControlIntent("Proposal", "SameAsMailingAddress"));

    public Task PressSameAsMailingAddressAsync(string key) =>
        _ui.PressAsync(_locators.SameAsMailingAddress, key, new ControlIntent("Proposal", "SameAsMailingAddress"));

    public Task ClickSameAsMailingAddressAsync() =>
        _ui.ClickAsync(_locators.SameAsMailingAddress, new ControlIntent("Proposal", "SameAsMailingAddress"));

    public Task WaitForStartQuoteAsync(string expected) =>
        _ui.WaitAsync(_locators.StartQuote, expected, new ControlIntent("Proposal", "StartQuote"));

    public Task ClickStartQuoteAsync() =>
        _ui.ClickAsync(_locators.StartQuote, new ControlIntent("Proposal", "StartQuote"));

    public Task EnterStateAsync(string value) =>
        _ui.FillAsync(_locators.State, value, new ControlIntent("Proposal", "State"));

    public Task SelectStateAsync(string value) =>
        _ui.SelectAsync(_locators.State, value, new ControlIntent("Proposal", "State"));

    public Task PressStateAsync(string key) =>
        _ui.PressAsync(_locators.State, key, new ControlIntent("Proposal", "State"));

    public Task ClickStateMONTANAAsync() =>
        _ui.ClickAsync(_locators.StateMONTANA, new ControlIntent("Proposal", "StateMONTANA"));

    public Task<bool> IsStateMONTANAPresentAsync() =>
        _ui.ExistsAsync(_locators.StateMONTANA);

    public Task SelectStateNameAsync(string value) =>
        _ui.SelectAsync(_locators.State, value, new ControlIntent("Proposal", "StateName"));

    public Task WaitForUSEEXISTINGACCOUNTAsync(string expected) =>
        _ui.WaitAsync(_locators.CONFIRM, expected, new ControlIntent("Proposal", "USEEXISTINGACCOUNT"));

    public Task ClickUSEEXISTINGACCOUNTAsync() =>
        _ui.ClickAsync(_locators.CONFIRM, new ControlIntent("Proposal", "USEEXISTINGACCOUNT"));

    public Task<bool> IsUSEEXISTINGACCOUNTPresentAsync() =>
        _ui.ExistsAsync(_locators.CONFIRM);

    public Task EnterWritingCompanyAsync(string value) =>
        _ui.FillAsync(_locators.WritingCompany, value, new ControlIntent("Proposal", "WritingCompany"));

    public Task SelectWritingCompanyAsync(string value) =>
        _ui.SelectAsync(_locators.WritingCompany, value, new ControlIntent("Proposal", "WritingCompany"));

    public Task PressWritingCompanyAsync(string key) =>
        _ui.PressAsync(_locators.WritingCompany, key, new ControlIntent("Proposal", "WritingCompany"));

}
