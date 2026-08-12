using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPAdditionalCoveragesLiquorLiabilty
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPAdditionalCoveragesLiquorLiabilty(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator GrossLiquorSales => EQBOPAdditionalCoveragesLiquorLiabiltyLocators.GrossLiquorSales(_page);

    public Task PressGrossLiquorSalesAsync(string key) => GrossLiquorSales.PressAsync(key);

    public Task DoubleClickGrossLiquorSalesAsync() => GrossLiquorSales.DblClickAsync();

    public Task SetGrossLiquorSalesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, GrossLiquorSales, _data.Resolve(value));

    public Task TypeGrossLiquorSalesAsync(string value, float delayMs = 40) =>
        GrossLiquorSales.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator NumberOfEvents => EQBOPAdditionalCoveragesLiquorLiabiltyLocators.NumberOfEvents(_page);

    public Task PressNumberOfEventsAsync(string key) => NumberOfEvents.PressAsync(key);

    public Task DoubleClickNumberOfEventsAsync() => NumberOfEvents.DblClickAsync();

    public Task SetNumberOfEventsAsync(string value) =>
        UiActions.ApplyInputAsync(_page, NumberOfEvents, _data.Resolve(value));

    public Task TypeNumberOfEventsAsync(string value, float delayMs = 40) =>
        NumberOfEvents.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator LiquorLiabilityDescriptionOfActivities => EQBOPAdditionalCoveragesLiquorLiabiltyLocators.LiquorLiabilityDescriptionOfActivities(_page);

    public Task PressLiquorLiabilityDescriptionOfActivitiesAsync(string key) => LiquorLiabilityDescriptionOfActivities.PressAsync(key);

    public Task DoubleClickLiquorLiabilityDescriptionOfActivitiesAsync() => LiquorLiabilityDescriptionOfActivities.DblClickAsync();

    public Task SetLiquorLiabilityDescriptionOfActivitiesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, LiquorLiabilityDescriptionOfActivities, _data.Resolve(value));

    public Task TypeLiquorLiabilityDescriptionOfActivitiesAsync(string value, float delayMs = 40) =>
        LiquorLiabilityDescriptionOfActivities.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator NoneOfTheAbove => EQBOPAdditionalCoveragesLiquorLiabiltyLocators.NoneOfTheAbove(_page);

    public Task PressNoneOfTheAboveAsync(string key) => NoneOfTheAbove.PressAsync(key);

    public Task DoubleClickNoneOfTheAboveAsync() => NoneOfTheAbove.DblClickAsync();

    public Task SetNoneOfTheAboveAsync(string value) =>
        UiActions.ApplyInputAsync(_page, NoneOfTheAbove, _data.Resolve(value));

    public Task TypeNoneOfTheAboveAsync(string value, float delayMs = 40) =>
        NoneOfTheAbove.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

}
