using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class Login2
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public Login2(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator UserName => Login2Locators.UserName(_page);

    public Task PressUserNameAsync(string key) => UserName.PressAsync(key);

    public Task DoubleClickUserNameAsync() => UserName.DblClickAsync();

    public Task SetUserNameAsync(string value) =>
        UiActions.ApplyInputAsync(_page, UserName, _data.Resolve(value));

    public Task TypeUserNameAsync(string value, float delayMs = 40) =>
        UserName.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task VerifyUserNameAsync(string expected) =>
        Expect(UserName).ToContainTextAsync(_data.Resolve(expected));

    public Task WaitForUserNameAsync() =>
        UserName.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator Password => Login2Locators.Password(_page);

    public Task PressPasswordAsync(string key) => Password.PressAsync(key);

    public Task DoubleClickPasswordAsync() => Password.DblClickAsync();

    public Task SetPasswordAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Password, _data.Resolve(value));

    public Task TypePasswordAsync(string value, float delayMs = 40) =>
        Password.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Login => Login2Locators.Login(_page);

    public Task PressLoginAsync(string key) => Login.PressAsync(key);

    public Task DoubleClickLoginAsync() => Login.DblClickAsync();

    public Task ClickLoginAsync() => Login.ClickAsync();

    public Task WaitForLoginAsync() =>
        Login.WaitForAsync(new() { State = WaitForSelectorState.Visible });

}
