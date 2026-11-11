using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class CommercialDuckCreekLoginPage
{
    private readonly BrowserSession _browser;
    private readonly CommercialDuckCreekLoginLocators _locators;
    private readonly UiActions _ui;

    public CommercialDuckCreekLoginPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new CommercialDuckCreekLoginLocators(browser.Page);
        _ui = ui;
    }

    public Task EnterUserNameAsync(string value) =>
        _ui.FillAsync(_locators.UserName, value, new ControlIntent("Login", "UserName"));

    public Task EnterPasswordAsync(string value) =>
        _ui.FillAsync(_locators.Password, value, new ControlIntent("Login", "Password"));

    public Task ClickLoginAsync() =>
        _ui.ClickAsync(_locators.Login, new ControlIntent("Login", "Login"));

    public Task WaitForLoginAsync(string expected) =>
        _ui.WaitAsync(_locators.Login, expected, new ControlIntent("Login", "Login"));
}
