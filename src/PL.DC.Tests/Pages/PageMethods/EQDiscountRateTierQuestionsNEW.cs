using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQDiscountRateTierQuestionsNEW
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQDiscountRateTierQuestionsNEW(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator ResidentiaProperty1 => EQDiscountRateTierQuestionsNEWLocators.ResidentiaProperty1(_page);

    public Task PressResidentiaProperty1Async(string key) => ResidentiaProperty1.PressAsync(key);

    public Task DoubleClickResidentiaProperty1Async() => ResidentiaProperty1.DblClickAsync();

    public Task SetResidentiaProperty1Async(string value) =>
        UiActions.ApplyInputAsync(_page, ResidentiaProperty1, _data.Resolve(value));

    public Task TypeResidentiaProperty1Async(string value, float delayMs = 40) =>
        ResidentiaProperty1.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator LessThan3000060000 => EQDiscountRateTierQuestionsNEWLocators.LessThan3000060000(_page);

    public Task PressLessThan3000060000Async(string key) => LessThan3000060000.PressAsync(key);

    public Task DoubleClickLessThan3000060000Async() => LessThan3000060000.DblClickAsync();

    public Task SetLessThan3000060000Async(string value) =>
        UiActions.ApplyInputAsync(_page, LessThan3000060000, _data.Resolve(value));

    public Task TypeLessThan3000060000Async(string value, float delayMs = 40) =>
        LessThan3000060000.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Item1500030000 => EQDiscountRateTierQuestionsNEWLocators.Item1500030000(_page);

    public Task PressItem1500030000Async(string key) => Item1500030000.PressAsync(key);

    public Task DoubleClickItem1500030000Async() => Item1500030000.DblClickAsync();

    public Task SetItem1500030000Async(string value) =>
        UiActions.ApplyInputAsync(_page, Item1500030000, _data.Resolve(value));

    public Task TypeItem1500030000Async(string value, float delayMs = 40) =>
        Item1500030000.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator LessThan1500030000 => EQDiscountRateTierQuestionsNEWLocators.LessThan1500030000(_page);

    public Task PressLessThan1500030000Async(string key) => LessThan1500030000.PressAsync(key);

    public Task DoubleClickLessThan1500030000Async() => LessThan1500030000.DblClickAsync();

    public Task SetLessThan1500030000Async(string value) =>
        UiActions.ApplyInputAsync(_page, LessThan1500030000, _data.Resolve(value));

    public Task TypeLessThan1500030000Async(string value, float delayMs = 40) =>
        LessThan1500030000.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator ResidentiaPropertyOld => EQDiscountRateTierQuestionsNEWLocators.ResidentiaPropertyOld(_page);

    public Task PressResidentiaPropertyOldAsync(string key) => ResidentiaPropertyOld.PressAsync(key);

    public Task DoubleClickResidentiaPropertyOldAsync() => ResidentiaPropertyOld.DblClickAsync();

    public Task ClickResidentiaPropertyOldAsync() => ResidentiaPropertyOld.ClickAsync();

    private ILocator LessThanOrEqualTo2500050000Old => EQDiscountRateTierQuestionsNEWLocators.LessThanOrEqualTo2500050000Old(_page);

    public Task PressLessThanOrEqualTo2500050000OldAsync(string key) => LessThanOrEqualTo2500050000Old.PressAsync(key);

    public Task DoubleClickLessThanOrEqualTo2500050000OldAsync() => LessThanOrEqualTo2500050000Old.DblClickAsync();

    public Task ClickLessThanOrEqualTo2500050000OldAsync() => LessThanOrEqualTo2500050000Old.ClickAsync();

}
