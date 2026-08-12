using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQUnderwritingEligibilityRestrictions
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQUnderwritingEligibilityRestrictions(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator Yes => EQUnderwritingEligibilityRestrictionsLocators.Yes(_page);

    public Task PressYesAsync(string key) => Yes.PressAsync(key);

    public Task DoubleClickYesAsync() => Yes.DblClickAsync();

    public Task SetYesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Yes, _data.Resolve(value));

    public Task TypeYesAsync(string value, float delayMs = 40) =>
        Yes.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator No => EQUnderwritingEligibilityRestrictionsLocators.No(_page);

    public Task PressNoAsync(string key) => No.PressAsync(key);

    public Task DoubleClickNoAsync() => No.DblClickAsync();

    public Task SetNoAsync(string value) =>
        UiActions.ApplyInputAsync(_page, No, _data.Resolve(value));

    public Task TypeNoAsync(string value, float delayMs = 40) =>
        No.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task ClickYesAsync() => Yes.ClickAsync();
}
