using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class LoginPage
{
    private readonly BrowserSession _browser;
    private readonly LoginLocators _locators;
    private readonly UiActions _ui;

    public LoginPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new LoginLocators(browser.Page);
        _ui = ui;
    }

    public Task ClickAddEditAdditionalInterestFirstMortgageeSearchAsync() =>
        _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch, new ControlIntent("Login", "AddEditAdditionalInterestFirstMortgageeSearch"));

    public Task WaitForBtnApproveAsync(string expected) =>
        _ui.WaitAsync(_locators.BtnApprove, expected, new ControlIntent("Login", "BtnApprove"));

    public Task ClickBtnApproveAsync() =>
        _ui.ClickAsync(_locators.BtnApprove, new ControlIntent("Login", "BtnApprove"));

    public Task SetBypassLevel9BRulesAsync(string value) =>
        _ui.SmartSetAsync(_locators.BypassLevel9BRules, value, new ControlIntent("Login", "BypassLevel9BRules"));

    public Task<bool> IsBypassLevel9BRulesPresentAsync() =>
        _ui.ExistsAsync(_locators.BypassLevel9BRules);

    public Task EnterBypassLevel9BRulesCommentsAsync(string value) =>
        _ui.FillAsync(_locators.BypassLevel9BRulesComments, value, new ControlIntent("Login", "BypassLevel9BRulesComments"));

    public Task PressBypassLevel9BRulesCommentsAsync(string key) =>
        _ui.PressAsync(_locators.BypassLevel9BRulesComments, key, new ControlIntent("Login", "BypassLevel9BRulesComments"));

    public Task EnterBypassLevel9Comments1Async(string value) =>
        _ui.FillAsync(_locators.BypassLevel9Comments1, value, new ControlIntent("Login", "BypassLevel9Comments1"));

    public Task PressBypassLevel9Comments1Async(string key) =>
        _ui.PressAsync(_locators.BypassLevel9Comments1, key, new ControlIntent("Login", "BypassLevel9Comments1"));

    public Task ClickBypassLevel9Comments1Async() =>
        _ui.ClickAsync(_locators.BypassLevel9Comments1, new ControlIntent("Login", "BypassLevel9Comments1"));

    public Task VerifyChkBoxBypassLevel9RulesAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ChkBoxBypassLevel9Rules, expected, property, new ControlIntent("Login", "ChkBoxBypassLevel9Rules"));

    public Task SetChkBoxBypassLevel9RulesAsync(string value) =>
        _ui.SmartSetAsync(_locators.ChkBoxBypassLevel9Rules, value, new ControlIntent("Login", "ChkBoxBypassLevel9Rules"));

    public Task<bool> IsChkBoxBypassLevel9RulesPresentAsync() =>
        _ui.ExistsAsync(_locators.ChkBoxBypassLevel9Rules);

    public Task ClickHomeAsync() =>
        _ui.ClickAsync(_locators.Home, new ControlIntent("Login", "Home"));

    public Task VerifyLblLoginIDAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.LblLoginID, expected, property, new ControlIntent("Login", "LblLoginID"));

    public Task<bool> IsLblLoginIDPresentAsync() =>
        _ui.ExistsAsync(_locators.LblLoginID);

    public Task ClickLnkHomeAsync() =>
        _ui.ClickAsync(_locators.LnkHome, new ControlIntent("Login", "LnkHome"));

    public Task ClickLnkLOGINAsync() =>
        _ui.ClickAsync(_locators.LnkLOGIN, new ControlIntent("Login", "LnkLOGIN"));

    public Task ClickLnkMotorcycleAsync() =>
        _ui.ClickAsync(_locators.LnkMotorcycle, new ControlIntent("Login", "LnkMotorcycle"));

    public Task ClickLnkPersonalAutoAsync() =>
        _ui.ClickAsync(_locators.LnkPersonalAuto, new ControlIntent("Login", "LnkPersonalAuto"));

    public Task ClickLnkPricingAsync() =>
        _ui.ClickAsync(_locators.LnkPricing, new ControlIntent("Login", "LnkPricing"));

    public Task<bool> IsLnkPricingPresentAsync() =>
        _ui.ExistsAsync(_locators.LnkPricing);

    public Task ClickLnkRVAsync() =>
        _ui.ClickAsync(_locators.LnkRV, new ControlIntent("Login", "LnkRV"));

    public Task EnterPasswordAsync(string value) =>
        _ui.FillAsync(_locators.Password, value, new ControlIntent("Login", "Password"));

    public Task ClickPolicyQuoteAsync() =>
        _ui.ClickAsync(_locators.PolicyQuote, new ControlIntent("Login", "PolicyQuote"));

    public Task<bool> IsPolicyQuotePresentAsync() =>
        _ui.ExistsAsync(_locators.PolicyQuote);

    public Task WaitForTxtLoginID1Async(string expected) =>
        _ui.WaitAsync(_locators.TxtLoginID1, expected, new ControlIntent("Login", "TxtLoginID1"));

    public Task EnterTxtLoginID1Async(string value) =>
        _ui.FillAsync(_locators.TxtLoginID1, value, new ControlIntent("Login", "TxtLoginID1"));

    public Task<bool> IsTxtLoginID1PresentAsync() =>
        _ui.ExistsAsync(_locators.TxtLoginID1);

    public Task EnterTxtSearchTextAsync(string value) =>
        _ui.FillAsync(_locators.TxtSearchText, value, new ControlIntent("Login", "TxtSearchText"));

    public Task WaitForTxtSearchTypeAsync(string expected) =>
        _ui.WaitAsync(_locators.TxtSearchType, expected, new ControlIntent("Login", "TxtSearchType"));

    public Task<bool> IsTxtSearchTypePresentAsync() =>
        _ui.ExistsAsync(_locators.TxtSearchType);

    public Task WaitForTxtUnderwritingNotesAsync(string expected) =>
        _ui.WaitAsync(_locators.TxtUnderwritingNotes, expected, new ControlIntent("Login", "TxtUnderwritingNotes"));

    public Task EnterTxtUnderwritingNotesAsync(string value) =>
        _ui.FillAsync(_locators.TxtUnderwritingNotes, value, new ControlIntent("Login", "TxtUnderwritingNotes"));

    public Task PressTxtUnderwritingNotesAsync(string key) =>
        _ui.PressAsync(_locators.TxtUnderwritingNotes, key, new ControlIntent("Login", "TxtUnderwritingNotes"));

    public Task<bool> IsTxtUnderwritingNotesPresentAsync() =>
        _ui.ExistsAsync(_locators.TxtUnderwritingNotes);

}
