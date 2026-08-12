using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQDriverLicenseTime
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQDriverLicenseTime(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator YrsLicensedCurrentState => EQDriverLicenseTimeLocators.YrsLicensedCurrentState(_page);

    public Task PressYrsLicensedCurrentStateAsync(string key) => YrsLicensedCurrentState.PressAsync(key);

    public Task DoubleClickYrsLicensedCurrentStateAsync() => YrsLicensedCurrentState.DblClickAsync();

    public Task SetYrsLicensedCurrentStateAsync(string value) =>
        UiActions.ApplyInputAsync(_page, YrsLicensedCurrentState, _data.Resolve(value));

    public Task TypeYrsLicensedCurrentStateAsync(string value, float delayMs = 40) =>
        YrsLicensedCurrentState.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator MonthsLicensedCurrentState => EQDriverLicenseTimeLocators.MonthsLicensedCurrentState(_page);

    public Task PressMonthsLicensedCurrentStateAsync(string key) => MonthsLicensedCurrentState.PressAsync(key);

    public Task DoubleClickMonthsLicensedCurrentStateAsync() => MonthsLicensedCurrentState.DblClickAsync();

    public Task SetMonthsLicensedCurrentStateAsync(string value) =>
        UiActions.ApplyInputAsync(_page, MonthsLicensedCurrentState, _data.Resolve(value));

    public Task TypeMonthsLicensedCurrentStateAsync(string value, float delayMs = 40) =>
        MonthsLicensedCurrentState.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator No => EQDriverLicenseTimeLocators.No(_page);

    public Task PressNoAsync(string key) => No.PressAsync(key);

    public Task DoubleClickNoAsync() => No.DblClickAsync();

    public Task SetNoAsync(string value) =>
        UiActions.ApplyInputAsync(_page, No, _data.Resolve(value));

    public Task TypeNoAsync(string value, float delayMs = 40) =>
        No.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

}
