using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class LoginPage
{
    private readonly BrowserSession _browser;
    private readonly IPage _page;
    private readonly LoginLocators _locators;
    private readonly UiActions _ui;

    public LoginPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _page = browser.Page;
        _locators = new LoginLocators(browser.Page);
        _ui = ui;
    }

    public Task WaitForBODYAsync(string expected) =>
        _ui.WaitAsync(_locators.BODY, expected, new ControlIntent("Login", "BODY"));

    public Task VerifyLoggedInUserAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.LoggedInUser, expected, property, new ControlIntent("Login", "LoggedInUser"));

    public Task WaitForLoginAsync(string expected) =>
        _ui.WaitAsync(_locators.Login, expected, new ControlIntent("Login", "Login"));

    public Task ClickLoginAsync() =>
        _ui.ClickAsync(_locators.Login, new ControlIntent("Login", "Login"));

    public Task EnterPasswordAsync(string value) =>
        _ui.FillAsync(_locators.Password, value, new ControlIntent("Login", "Password"));

    public Task EnterUserNameAsync(string value) =>
        _ui.FillAsync(_locators.UserName, value, new ControlIntent("Login", "UserName"));

    public Task PressUserNameAsync(string key) =>
        _ui.PressAsync(_locators.UserName, key, new ControlIntent("Login", "UserName"));

    public Task NavigateAsync(string url) =>
        _page.GotoAsync(url, new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded });

    public Task PauseAsync(int milliseconds) =>
        Task.Delay(milliseconds);


    public Task EnterPasswordSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Password, value, new ControlIntent("Login", "Password"), delayMs);

    public Task EnterUserNameSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.UserName, value, new ControlIntent("Login", "UserName"), delayMs);
}
