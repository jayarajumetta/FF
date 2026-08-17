using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class SocialSecurityPage
{
    private readonly BrowserSession _browser;
    private readonly SocialSecurityLocators _locators;
    private readonly UiActions _ui;

    public SocialSecurityPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new SocialSecurityLocators(browser.Page);
        _ui = ui;
    }

    public Task ClickContinueAsync() =>
        _ui.ClickAsync(_locators.Continue, new ControlIntent("SocialSecurity", "Continue"));

    public Task<bool> IsContinuePresentAsync() =>
        _ui.ExistsAsync(_locators.Continue);

    public Task VerifyEChecklistEChecklistSubmitAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.EChecklistEChecklistSubmit, expected, property, new ControlIntent("SocialSecurity", "EChecklistEChecklistSubmit"));

    public Task ClickEChecklistEChecklistSubmitAsync() =>
        _ui.ClickAsync(_locators.EChecklistEChecklistSubmit, new ControlIntent("SocialSecurity", "EChecklistEChecklistSubmit"));

    public Task VerifyNoPrefillMatchFoundAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.NoPrefillMatchFound, expected, property, new ControlIntent("SocialSecurity", "NoPrefillMatchFound"));

    public Task<bool> IsNoPrefillMatchFoundPresentAsync() =>
        _ui.ExistsAsync(_locators.NoPrefillMatchFound);

    public Task VerifyScreenHeadingAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ScreenHeading, expected, property, new ControlIntent("SocialSecurity", "ScreenHeading"));

    public Task<bool> IsScreenHeadingPresentAsync() =>
        _ui.ExistsAsync(_locators.ScreenHeading);

    public Task WaitForSubmitAngularAsync(string expected) =>
        _ui.WaitAsync(_locators.SubmitAngular, expected, new ControlIntent("SocialSecurity", "SubmitAngular"));

    public Task PressSubmitAngularAsync(string key) =>
        _ui.PressAsync(_locators.SubmitAngular, key, new ControlIntent("SocialSecurity", "SubmitAngular"));

    public Task ClickSubmitAngularAsync() =>
        _ui.ClickAsync(_locators.SubmitAngular, new ControlIntent("SocialSecurity", "SubmitAngular"));

    public Task WaitForTheSSNCouldNotBeFoundPleaseEnterAnSSNAsync(string expected) =>
        _ui.WaitAsync(_locators.TheSSNCouldNotBeFoundPleaseEnterAnSSN, expected, new ControlIntent("SocialSecurity", "TheSSNCouldNotBeFoundPleaseEnterAnSSN"));

    public Task VerifyTheSSNCouldNotBeFoundPleaseEnterAnSSNAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.TheSSNCouldNotBeFoundPleaseEnterAnSSN, expected, property, new ControlIntent("SocialSecurity", "TheSSNCouldNotBeFoundPleaseEnterAnSSN"));

    public Task EnterTheSSNCouldNotBeFoundPleaseEnterAnSSNAsync(string value) =>
        _ui.FillAsync(_locators.TheSSNCouldNotBeFoundPleaseEnterAnSSN, value, new ControlIntent("SocialSecurity", "TheSSNCouldNotBeFoundPleaseEnterAnSSN"));

}
