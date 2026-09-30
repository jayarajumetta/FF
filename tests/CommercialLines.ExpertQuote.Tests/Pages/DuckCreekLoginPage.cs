using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class DuckCreekLoginPage
{
    private readonly BrowserSession _browser;
    private readonly IPage _page;
    private readonly DuckCreekLoginLocators _locators;
    private readonly UiActions _ui;

    public DuckCreekLoginPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _page = browser.Page;
        _locators = new DuckCreekLoginLocators(browser.Page);
        _ui = ui;
    }

    public Task NavigateAsync(string url) =>
        _page.GotoAsync(url, new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded });

    public Task WaitForBODYAsync(string expected) =>
        _ui.WaitAsync(_locators.BODY, expected, new ControlIntent("Login", "BODY"));

    public Task WaitForLoginAsync(string expected) =>
        _ui.WaitAsync(_locators.Login, expected, new ControlIntent("Login", "Login"));

    public Task ClickLoginAsync() =>
        _ui.ClickAsync(_locators.Login, new ControlIntent("Login", "Login"));

    public Task EnterUserNameAsync(string value) =>
        _ui.FillAsync(_locators.UserName, value, new ControlIntent("Login", "UserName"));

    public Task EnterPasswordAsync(string value) =>
        _ui.FillAsync(_locators.Password, value, new ControlIntent("Login", "Password"));
}
