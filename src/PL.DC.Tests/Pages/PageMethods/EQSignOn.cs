using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQSignOn
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQSignOn(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator TxtUsername1 => EQSignOnLocators.TxtUsername1(_page);

    public Task PressTxtUsername1Async(string key) => TxtUsername1.PressAsync(key);

    public Task DoubleClickTxtUsername1Async() => TxtUsername1.DblClickAsync();

    public Task WaitForTxtUsername1Async() =>
        TxtUsername1.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator TxtPassword => EQSignOnLocators.TxtPassword(_page);

    public Task PressTxtPasswordAsync(string key) => TxtPassword.PressAsync(key);

    public Task DoubleClickTxtPasswordAsync() => TxtPassword.DblClickAsync();

    public Task SetTxtPasswordAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TxtPassword, _data.Resolve(value));

    public Task TypeTxtPasswordAsync(string value, float delayMs = 40) =>
        TxtPassword.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BtnSignOn1 => EQSignOnLocators.BtnSignOn1(_page);

    public Task PressBtnSignOn1Async(string key) => BtnSignOn1.PressAsync(key);

    public Task DoubleClickBtnSignOn1Async() => BtnSignOn1.DblClickAsync();

    public Task WaitForBtnSignOn1Async() =>
        BtnSignOn1.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator TxtUsername => EQSignOnLocators.TxtUsername(_page);

    public Task PressTxtUsernameAsync(string key) => TxtUsername.PressAsync(key);

    public Task DoubleClickTxtUsernameAsync() => TxtUsername.DblClickAsync();

    public Task SetTxtUsernameAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TxtUsername, _data.Resolve(value));

    public Task TypeTxtUsernameAsync(string value, float delayMs = 40) =>
        TxtUsername.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task VerifyTxtUsernameAsync(string expected) =>
        Expect(TxtUsername).ToContainTextAsync(_data.Resolve(expected));

    public Task WaitForTxtUsernameAsync() =>
        TxtUsername.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator TxtPassword1 => EQSignOnLocators.TxtPassword1(_page);

    public Task PressTxtPassword1Async(string key) => TxtPassword1.PressAsync(key);

    public Task DoubleClickTxtPassword1Async() => TxtPassword1.DblClickAsync();

    public Task SetTxtPassword1Async(string value) =>
        UiActions.ApplyInputAsync(_page, TxtPassword1, _data.Resolve(value));

    public Task TypeTxtPassword1Async(string value, float delayMs = 40) =>
        TxtPassword1.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

}
