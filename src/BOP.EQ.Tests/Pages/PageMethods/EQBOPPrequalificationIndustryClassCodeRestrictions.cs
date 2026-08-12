using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPPrequalificationIndustryClassCodeRestrictions
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPPrequalificationIndustryClassCodeRestrictions(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator IndustryClassCodeRestrictionsHeading => EQBOPPrequalificationIndustryClassCodeRestrictionsLocators.IndustryClassCodeRestrictionsHeading(_page);

    public Task PressIndustryClassCodeRestrictionsHeadingAsync(string key) => IndustryClassCodeRestrictionsHeading.PressAsync(key);

    public Task DoubleClickIndustryClassCodeRestrictionsHeadingAsync() => IndustryClassCodeRestrictionsHeading.DblClickAsync();

    public Task WaitForIndustryClassCodeRestrictionsHeadingAsync() =>
        IndustryClassCodeRestrictionsHeading.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator NoneOfTheAbove => EQBOPPrequalificationIndustryClassCodeRestrictionsLocators.NoneOfTheAbove(_page);

    public Task PressNoneOfTheAboveAsync(string key) => NoneOfTheAbove.PressAsync(key);

    public Task DoubleClickNoneOfTheAboveAsync() => NoneOfTheAbove.DblClickAsync();

    public Task SetNoneOfTheAboveAsync(string value) =>
        UiActions.ApplyInputAsync(_page, NoneOfTheAbove, _data.Resolve(value));

    public Task TypeNoneOfTheAboveAsync(string value, float delayMs = 40) =>
        NoneOfTheAbove.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

}
