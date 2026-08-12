using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPBuildingCostEstimator
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPBuildingCostEstimator(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator CommercialButton => EQBOPBuildingCostEstimatorLocators.CommercialButton(_page);

    public Task PressCommercialButtonAsync(string key) => CommercialButton.PressAsync(key);

    public Task DoubleClickCommercialButtonAsync() => CommercialButton.DblClickAsync();

    public Task SetCommercialButtonAsync(string value) =>
        UiActions.ApplyInputAsync(_page, CommercialButton, _data.Resolve(value));

    public Task TypeCommercialButtonAsync(string value, float delayMs = 40) =>
        CommercialButton.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BVSButton => EQBOPBuildingCostEstimatorLocators.BVSButton(_page);

    public Task PressBVSButtonAsync(string key) => BVSButton.PressAsync(key);

    public Task DoubleClickBVSButtonAsync() => BVSButton.DblClickAsync();

    public Task SetBVSButtonAsync(string value) =>
        UiActions.ApplyInputAsync(_page, BVSButton, _data.Resolve(value));

    public Task TypeBVSButtonAsync(string value, float delayMs = 40) =>
        BVSButton.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Frame => EQBOPBuildingCostEstimatorLocators.Frame(_page);

    public Task PressFrameAsync(string key) => Frame.PressAsync(key);

    public Task DoubleClickFrameAsync() => Frame.DblClickAsync();

    public Task SetFrameAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Frame, _data.Resolve(value));

    public Task TypeFrameAsync(string value, float delayMs = 40) =>
        Frame.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BVSGroupCombobox => EQBOPBuildingCostEstimatorLocators.BVSGroupCombobox(_page);

    public Task PressBVSGroupComboboxAsync(string key) => BVSGroupCombobox.PressAsync(key);

    public Task DoubleClickBVSGroupComboboxAsync() => BVSGroupCombobox.DblClickAsync();

    public Task SetBVSGroupComboboxAsync(string value) =>
        BVSGroupCombobox.SelectOptionAsync(_data.Resolve(value));

    private ILocator BVSGroup => EQBOPBuildingCostEstimatorLocators.BVSGroup(_page);

    public Task PressBVSGroupAsync(string key) => BVSGroup.PressAsync(key);

    public Task DoubleClickBVSGroupAsync() => BVSGroup.DblClickAsync();

    public Task SetBVSGroupAsync(string value) =>
        BVSGroup.SelectOptionAsync(_data.Resolve(value));

    private ILocator BVSResultsCombobox => EQBOPBuildingCostEstimatorLocators.BVSResultsCombobox(_page);

    public Task PressBVSResultsComboboxAsync(string key) => BVSResultsCombobox.PressAsync(key);

    public Task DoubleClickBVSResultsComboboxAsync() => BVSResultsCombobox.DblClickAsync();

    public Task SetBVSResultsComboboxAsync(string value) =>
        BVSResultsCombobox.SelectOptionAsync(_data.Resolve(value));

    private ILocator BVSResult => EQBOPBuildingCostEstimatorLocators.BVSResult(_page);

    public Task PressBVSResultAsync(string key) => BVSResult.PressAsync(key);

    public Task DoubleClickBVSResultAsync() => BVSResult.DblClickAsync();

    public Task SetBVSResultAsync(string value) =>
        BVSResult.SelectOptionAsync(_data.Resolve(value));

    private ILocator YearBuilt => EQBOPBuildingCostEstimatorLocators.YearBuilt(_page);

    public Task PressYearBuiltAsync(string key) => YearBuilt.PressAsync(key);

    public Task DoubleClickYearBuiltAsync() => YearBuilt.DblClickAsync();

    public Task SetYearBuiltAsync(string value) =>
        UiActions.ApplyInputAsync(_page, YearBuilt, _data.Resolve(value));

    public Task TypeYearBuiltAsync(string value, float delayMs = 40) =>
        YearBuilt.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator RoofTypeMain => EQBOPBuildingCostEstimatorLocators.RoofTypeMain(_page);

    public Task PressRoofTypeMainAsync(string key) => RoofTypeMain.PressAsync(key);

    public Task DoubleClickRoofTypeMainAsync() => RoofTypeMain.DblClickAsync();

    public Task SetRoofTypeMainAsync(string value) =>
        UiActions.ApplyInputAsync(_page, RoofTypeMain, _data.Resolve(value));

    public Task TypeRoofTypeMainAsync(string value, float delayMs = 40) =>
        RoofTypeMain.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator RoofTypeSelection => EQBOPBuildingCostEstimatorLocators.RoofTypeSelection(_page);

    public Task PressRoofTypeSelectionAsync(string key) => RoofTypeSelection.PressAsync(key);

    public Task DoubleClickRoofTypeSelectionAsync() => RoofTypeSelection.DblClickAsync();

    public Task SetRoofTypeSelectionAsync(string value) =>
        UiActions.ApplyInputAsync(_page, RoofTypeSelection, _data.Resolve(value));

    public Task TypeRoofTypeSelectionAsync(string value, float delayMs = 40) =>
        RoofTypeSelection.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator GetValuation => EQBOPBuildingCostEstimatorLocators.GetValuation(_page);

    public Task PressGetValuationAsync(string key) => GetValuation.PressAsync(key);

    public Task DoubleClickGetValuationAsync() => GetValuation.DblClickAsync();

    public Task ClickGetValuationAsync() => GetValuation.ClickAsync();

    private ILocator NumberOfStories => EQBOPBuildingCostEstimatorLocators.NumberOfStories(_page);

    public Task PressNumberOfStoriesAsync(string key) => NumberOfStories.PressAsync(key);

    public Task DoubleClickNumberOfStoriesAsync() => NumberOfStories.DblClickAsync();

    public Task SetNumberOfStoriesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, NumberOfStories, _data.Resolve(value));

    public Task TypeNumberOfStoriesAsync(string value, float delayMs = 40) =>
        NumberOfStories.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task ClickBVSButtonAsync() => BVSButton.ClickAsync();

    public Task ClickBVSGroupAsync() => BVSGroup.ClickAsync();

    public Task ClickBVSGroupComboboxAsync() => BVSGroupCombobox.ClickAsync();

    public Task ClickBVSResultAsync() => BVSResult.ClickAsync();

    public Task ClickBVSResultsComboboxAsync() => BVSResultsCombobox.ClickAsync();

    public Task ClickRoofTypeMainAsync() => RoofTypeMain.ClickAsync();

    public Task ClickRoofTypeSelectionAsync() => RoofTypeSelection.ClickAsync();
}
