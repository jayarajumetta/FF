using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPBuildingBuildingDetailsBuildingRatingBasis
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPBuildingBuildingDetailsBuildingRatingBasis(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator BuildingDetailsHeading => EQBOPBuildingBuildingDetailsBuildingRatingBasisLocators.BuildingDetailsHeading(_page);

    public Task PressBuildingDetailsHeadingAsync(string key) => BuildingDetailsHeading.PressAsync(key);

    public Task DoubleClickBuildingDetailsHeadingAsync() => BuildingDetailsHeading.DblClickAsync();

    public Task WaitForBuildingDetailsHeadingAsync() =>
        BuildingDetailsHeading.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator ActualCashValue => EQBOPBuildingBuildingDetailsBuildingRatingBasisLocators.ActualCashValue(_page);

    public Task PressActualCashValueAsync(string key) => ActualCashValue.PressAsync(key);

    public Task DoubleClickActualCashValueAsync() => ActualCashValue.DblClickAsync();

    public Task SetActualCashValueAsync(string value) =>
        UiActions.ApplyInputAsync(_page, ActualCashValue, _data.Resolve(value));

    public Task TypeActualCashValueAsync(string value, float delayMs = 40) =>
        ActualCashValue.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator ReplacementCost => EQBOPBuildingBuildingDetailsBuildingRatingBasisLocators.ReplacementCost(_page);

    public Task PressReplacementCostAsync(string key) => ReplacementCost.PressAsync(key);

    public Task DoubleClickReplacementCostAsync() => ReplacementCost.DblClickAsync();

    public Task SetReplacementCostAsync(string value) =>
        UiActions.ApplyInputAsync(_page, ReplacementCost, _data.Resolve(value));

    public Task TypeReplacementCostAsync(string value, float delayMs = 40) =>
        ReplacementCost.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator YearBuiltRenovated => EQBOPBuildingBuildingDetailsBuildingRatingBasisLocators.YearBuiltRenovated(_page);

    public Task PressYearBuiltRenovatedAsync(string key) => YearBuiltRenovated.PressAsync(key);

    public Task DoubleClickYearBuiltRenovatedAsync() => YearBuiltRenovated.DblClickAsync();

    public Task SetYearBuiltRenovatedAsync(string value) =>
        UiActions.ApplyInputAsync(_page, YearBuiltRenovated, _data.Resolve(value));

    public Task TypeYearBuiltRenovatedAsync(string value, float delayMs = 40) =>
        YearBuiltRenovated.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator WiringYear => EQBOPBuildingBuildingDetailsBuildingRatingBasisLocators.WiringYear(_page);

    public Task PressWiringYearAsync(string key) => WiringYear.PressAsync(key);

    public Task DoubleClickWiringYearAsync() => WiringYear.DblClickAsync();

    public Task SetWiringYearAsync(string value) =>
        UiActions.ApplyInputAsync(_page, WiringYear, _data.Resolve(value));

    public Task TypeWiringYearAsync(string value, float delayMs = 40) =>
        WiringYear.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator HeatingYear => EQBOPBuildingBuildingDetailsBuildingRatingBasisLocators.HeatingYear(_page);

    public Task PressHeatingYearAsync(string key) => HeatingYear.PressAsync(key);

    public Task DoubleClickHeatingYearAsync() => HeatingYear.DblClickAsync();

    public Task SetHeatingYearAsync(string value) =>
        UiActions.ApplyInputAsync(_page, HeatingYear, _data.Resolve(value));

    public Task TypeHeatingYearAsync(string value, float delayMs = 40) =>
        HeatingYear.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator PlumbingYear => EQBOPBuildingBuildingDetailsBuildingRatingBasisLocators.PlumbingYear(_page);

    public Task PressPlumbingYearAsync(string key) => PlumbingYear.PressAsync(key);

    public Task DoubleClickPlumbingYearAsync() => PlumbingYear.DblClickAsync();

    public Task SetPlumbingYearAsync(string value) =>
        UiActions.ApplyInputAsync(_page, PlumbingYear, _data.Resolve(value));

    public Task TypePlumbingYearAsync(string value, float delayMs = 40) =>
        PlumbingYear.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator MainBreaker => EQBOPBuildingBuildingDetailsBuildingRatingBasisLocators.MainBreaker(_page);

    public Task PressMainBreakerAsync(string key) => MainBreaker.PressAsync(key);

    public Task DoubleClickMainBreakerAsync() => MainBreaker.DblClickAsync();

    public Task ClickMainBreakerAsync() => MainBreaker.ClickAsync();

}
