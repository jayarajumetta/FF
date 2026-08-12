using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonPreQualificationAddClassCodesSearchAddClassCodes
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonPreQualificationAddClassCodesSearchAddClassCodes(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator FindAClassCode => EQCommonPreQualificationAddClassCodesSearchAddClassCodesLocators.FindAClassCode(_page);

    public Task PressFindAClassCodeAsync(string key) => FindAClassCode.PressAsync(key);

    public Task DoubleClickFindAClassCodeAsync() => FindAClassCode.DblClickAsync();

    public Task WaitForFindAClassCodeAsync() =>
        FindAClassCode.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator ClassFilter => EQCommonPreQualificationAddClassCodesSearchAddClassCodesLocators.ClassFilter(_page);

    public Task PressClassFilterAsync(string key) => ClassFilter.PressAsync(key);

    public Task DoubleClickClassFilterAsync() => ClassFilter.DblClickAsync();

    public Task SetClassFilterAsync(string value) =>
        UiActions.ApplyInputAsync(_page, ClassFilter, _data.Resolve(value));

    public Task TypeClassFilterAsync(string value, float delayMs = 40) =>
        ClassFilter.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Search => EQCommonPreQualificationAddClassCodesSearchAddClassCodesLocators.Search(_page);

    public Task PressSearchAsync(string key) => Search.PressAsync(key);

    public Task DoubleClickSearchAsync() => Search.DblClickAsync();

    public Task ClickSearchAsync() => Search.ClickAsync();

    private ILocator On => EQCommonPreQualificationAddClassCodesSearchAddClassCodesLocators.On(_page);

    public Task PressOnAsync(string key) => On.PressAsync(key);

    public Task DoubleClickOnAsync() => On.DblClickAsync();

    public Task SetOnAsync(string value) =>
        UiActions.ApplyInputAsync(_page, On, _data.Resolve(value));

    public Task TypeOnAsync(string value, float delayMs = 40) =>
        On.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task WaitForOnAsync() =>
        On.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator YouHaveSelected1ClassCodes => EQCommonPreQualificationAddClassCodesSearchAddClassCodesLocators.YouHaveSelected1ClassCodes(_page);

    public Task PressYouHaveSelected1ClassCodesAsync(string key) => YouHaveSelected1ClassCodes.PressAsync(key);

    public Task DoubleClickYouHaveSelected1ClassCodesAsync() => YouHaveSelected1ClassCodes.DblClickAsync();

    public Task SetYouHaveSelected1ClassCodesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, YouHaveSelected1ClassCodes, _data.Resolve(value));

    public Task TypeYouHaveSelected1ClassCodesAsync(string value, float delayMs = 40) =>
        YouHaveSelected1ClassCodes.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task WaitForYouHaveSelected1ClassCodesAsync() =>
        YouHaveSelected1ClassCodes.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator Add => EQCommonPreQualificationAddClassCodesSearchAddClassCodesLocators.Add(_page);

    public Task PressAddAsync(string key) => Add.PressAsync(key);

    public Task DoubleClickAddAsync() => Add.DblClickAsync();

    public Task ClickAddAsync() => Add.ClickAsync();

    public Task ClickYouHaveSelected1ClassCodesAsync() => YouHaveSelected1ClassCodes.ClickAsync();
}
