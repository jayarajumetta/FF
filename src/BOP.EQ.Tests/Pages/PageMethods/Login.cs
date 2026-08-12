using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class Login
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public Login(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator Username => LoginLocators.Username(_page);

    public Task PressUsernameAsync(string key) => Username.PressAsync(key);

    public Task DoubleClickUsernameAsync() => Username.DblClickAsync();

    public Task SetUsernameAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Username, _data.Resolve(value));

    public Task TypeUsernameAsync(string value, float delayMs = 40) =>
        Username.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task VerifyUsernameAsync(string expected) =>
        Expect(Username).ToContainTextAsync(_data.Resolve(expected));

    public Task WaitForUsernameAsync() =>
        Username.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator Password => LoginLocators.Password(_page);

    public Task PressPasswordAsync(string key) => Password.PressAsync(key);

    public Task DoubleClickPasswordAsync() => Password.DblClickAsync();

    public Task SetPasswordAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Password, _data.Resolve(value));

    public Task TypePasswordAsync(string value, float delayMs = 40) =>
        Password.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator SignOn => LoginLocators.SignOn(_page);

    public Task PressSignOnAsync(string key) => SignOn.PressAsync(key);

    public Task DoubleClickSignOnAsync() => SignOn.DblClickAsync();

    public Task ClickSignOnAsync() => SignOn.ClickAsync();

}
