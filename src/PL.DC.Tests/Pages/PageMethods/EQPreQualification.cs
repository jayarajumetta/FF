using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQPreQualification
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQPreQualification(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator BtnChkBoxCheckBoxNoneOfTheAbove => EQPreQualificationLocators.BtnChkBoxCheckBoxNoneOfTheAbove(_page);

    public Task PressBtnChkBoxCheckBoxNoneOfTheAboveAsync(string key) => BtnChkBoxCheckBoxNoneOfTheAbove.PressAsync(key);

    public Task DoubleClickBtnChkBoxCheckBoxNoneOfTheAboveAsync() => BtnChkBoxCheckBoxNoneOfTheAbove.DblClickAsync();

    public Task SetBtnChkBoxCheckBoxNoneOfTheAboveAsync(string value) =>
        UiActions.ApplyInputAsync(_page, BtnChkBoxCheckBoxNoneOfTheAbove, _data.Resolve(value));

    public Task TypeBtnChkBoxCheckBoxNoneOfTheAboveAsync(string value, float delayMs = 40) =>
        BtnChkBoxCheckBoxNoneOfTheAbove.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BtnNext => EQPreQualificationLocators.BtnNext(_page);

    public Task PressBtnNextAsync(string key) => BtnNext.PressAsync(key);

    public Task DoubleClickBtnNextAsync() => BtnNext.DblClickAsync();

    public Task ClickBtnNextAsync() => BtnNext.ClickAsync();

    public Task ClickBtnChkBoxCheckBoxNoneOfTheAboveAsync() => BtnChkBoxCheckBoxNoneOfTheAbove.ClickAsync();
}
