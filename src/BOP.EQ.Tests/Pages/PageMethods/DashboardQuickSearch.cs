using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class DashboardQuickSearch
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public DashboardQuickSearch(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator SearchText => DashboardQuickSearchLocators.SearchText(_page);

    public Task PressSearchTextAsync(string key) => SearchText.PressAsync(key);

    public Task DoubleClickSearchTextAsync() => SearchText.DblClickAsync();

    public Task SetSearchTextAsync(string value) =>
        UiActions.ApplyInputAsync(_page, SearchText, _data.Resolve(value));

    public Task TypeSearchTextAsync(string value, float delayMs = 40) =>
        SearchText.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator QuickSearchButton => DashboardQuickSearchLocators.QuickSearchButton(_page);

    public Task PressQuickSearchButtonAsync(string key) => QuickSearchButton.PressAsync(key);

    public Task DoubleClickQuickSearchButtonAsync() => QuickSearchButton.DblClickAsync();

    public Task ClickQuickSearchButtonAsync() => QuickSearchButton.ClickAsync();

    private ILocator SearchMode => DashboardQuickSearchLocators.SearchMode(_page);

    public Task PressSearchModeAsync(string key) => SearchMode.PressAsync(key);

    public Task DoubleClickSearchModeAsync() => SearchMode.DblClickAsync();

    public Task SetSearchModeAsync(string value) =>
        UiActions.ApplyInputAsync(_page, SearchMode, _data.Resolve(value));

    public Task TypeSearchModeAsync(string value, float delayMs = 40) =>
        SearchMode.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

}
