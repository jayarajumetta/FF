using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonSSN
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonSSN(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator TheSSNCouldNotBeFoundPleaseEnterAnSSN => EQCommonSSNLocators.TheSSNCouldNotBeFoundPleaseEnterAnSSN(_page);

    public Task PressTheSSNCouldNotBeFoundPleaseEnterAnSSNAsync(string key) => TheSSNCouldNotBeFoundPleaseEnterAnSSN.PressAsync(key);

    public Task DoubleClickTheSSNCouldNotBeFoundPleaseEnterAnSSNAsync() => TheSSNCouldNotBeFoundPleaseEnterAnSSN.DblClickAsync();

    public Task WaitForTheSSNCouldNotBeFoundPleaseEnterAnSSNAsync() =>
        TheSSNCouldNotBeFoundPleaseEnterAnSSN.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator Ssn => EQCommonSSNLocators.Ssn(_page);

    public Task PressSsnAsync(string key) => Ssn.PressAsync(key);

    public Task DoubleClickSsnAsync() => Ssn.DblClickAsync();

    public Task SetSsnAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Ssn, _data.Resolve(value));

    public Task TypeSsnAsync(string value, float delayMs = 40) =>
        Ssn.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator SUBMIT => EQCommonSSNLocators.SUBMIT(_page);

    public Task PressSUBMITAsync(string key) => SUBMIT.PressAsync(key);

    public Task DoubleClickSUBMITAsync() => SUBMIT.DblClickAsync();

    public Task ClickSUBMITAsync() => SUBMIT.ClickAsync();

    public Task WaitForSUBMITAsync() =>
        SUBMIT.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator SubmitAngular => EQCommonSSNLocators.SubmitAngular(_page);

    public Task PressSubmitAngularAsync(string key) => SubmitAngular.PressAsync(key);

    public Task DoubleClickSubmitAngularAsync() => SubmitAngular.DblClickAsync();

    public Task ClickSubmitAngularAsync() => SubmitAngular.ClickAsync();

    public Task WaitForSubmitAngularAsync() =>
        SubmitAngular.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator NoPrefillMatchFound => EQCommonSSNLocators.NoPrefillMatchFound(_page);

    public Task PressNoPrefillMatchFoundAsync(string key) => NoPrefillMatchFound.PressAsync(key);

    public Task DoubleClickNoPrefillMatchFoundAsync() => NoPrefillMatchFound.DblClickAsync();

    public Task VerifyNoPrefillMatchFoundAsync(string expected) =>
        Expect(NoPrefillMatchFound).ToContainTextAsync(_data.Resolve(expected));

    private ILocator Continue => EQCommonSSNLocators.Continue(_page);

    public Task PressContinueAsync(string key) => Continue.PressAsync(key);

    public Task DoubleClickContinueAsync() => Continue.DblClickAsync();

    public Task ClickContinueAsync() => Continue.ClickAsync();

}
