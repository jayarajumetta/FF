using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

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

    public Task WaitForBODYAsync(string expected) =>
        _ui.WaitAsync(_locators.BODY, expected, new ControlIntent("Login", "BODY"));

    public Task<bool> IsBODYPresentAsync() =>
        _ui.ExistsAsync(_locators.BODY);

    public Task EnterGetSessionIDBufferAsync(string value) =>
        _ui.FillAsync(_locators.GetSessionIDBuffer, value, new ControlIntent("Login", "GetSessionIDBuffer"));
public Task VerifyLoadingMessageAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.LoadingMessage, expected, property, new ControlIntent("Login", "LoadingMessage"));

    public Task<bool> IsLoadingMessagePresentAsync() =>
        _ui.ExistsAsync(_locators.LoadingMessage);

    public Task VerifyLoggedInUserAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.LoggedInUser, expected, property, new ControlIntent("Login", "LoggedInUser"));

    public Task<bool> IsLoggedInUserPresentAsync() =>
        _ui.ExistsAsync(_locators.LoggedInUser);

    public Task WaitForLogin07237Async(string expected) =>
        _ui.WaitAsync(_locators.Login07237, expected, new ControlIntent("Login", "Login07237"));

    public Task<bool> IsLogin07237PresentAsync() =>
        _ui.ExistsAsync(_locators.Login07237);

    public Task WaitForLogin0D21AAsync(string expected) =>
        _ui.WaitAsync(_locators.Login0D21A, expected, new ControlIntent("Login", "Login0D21A"));

    public Task WaitForLoginC45A2Async(string expected) =>
        _ui.WaitAsync(_locators.LoginC45A2, expected, new ControlIntent("Login", "LoginC45A2"));

    public Task ClickQuickSearchButtonAsync() =>
        _ui.ClickAsync(_locators.QuickSearchButton, new ControlIntent("Login", "QuickSearchButton"));

    public Task EnterSearchModeAsync(string value) =>
        _ui.FillAsync(_locators.SearchMode, value, new ControlIntent("Login", "SearchMode"));

    public Task EnterSearchTextAsync(string value) =>
        _ui.FillAsync(_locators.SearchText, value, new ControlIntent("Login", "SearchText"));

    public Task PressSearchTextAsync(string key) =>
        _ui.PressAsync(_locators.SearchText, key, new ControlIntent("Login", "SearchText"));

    public Task WaitForUserNameAsync(string expected) =>
        _ui.WaitAsync(_locators.UserName, expected, new ControlIntent("Login", "UserName"));

    public Task WaitForUsernameAsync(string expected) =>
        _ui.WaitAsync(_locators.Username, expected, new ControlIntent("Login", "Username"));

    public Task WaitForViewPolicyAsync(string expected) =>
        _ui.WaitAsync(_locators.ViewPolicy, expected, new ControlIntent("Login", "ViewPolicy"));

    public Task ClickViewPolicyAsync() =>
        _ui.ClickAsync(_locators.ViewPolicy, new ControlIntent("Login", "ViewPolicy"));

    public Task NavigateAsync(string url) =>
        _browser.Page.GotoAsync(url, new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded });

    public Task PauseAsync(int milliseconds) =>
        Task.Delay(milliseconds);

    public Task NoteAsync(string note) =>
        _ui.ReviewRequiredAsync(note);

}
