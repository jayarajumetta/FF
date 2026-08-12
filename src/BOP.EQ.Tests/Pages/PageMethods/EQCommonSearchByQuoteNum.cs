using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonSearchByQuoteNum
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonSearchByQuoteNum(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator QuoteSearchInput => EQCommonSearchByQuoteNumLocators.QuoteSearchInput(_page);

    public Task PressQuoteSearchInputAsync(string key) => QuoteSearchInput.PressAsync(key);

    public Task DoubleClickQuoteSearchInputAsync() => QuoteSearchInput.DblClickAsync();

    public Task SetQuoteSearchInputAsync(string value) =>
        UiActions.ApplyInputAsync(_page, QuoteSearchInput, _data.Resolve(value));

    public Task TypeQuoteSearchInputAsync(string value, float delayMs = 40) =>
        QuoteSearchInput.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Search => EQCommonSearchByQuoteNumLocators.Search(_page);

    public Task PressSearchAsync(string key) => Search.PressAsync(key);

    public Task DoubleClickSearchAsync() => Search.DblClickAsync();

    public Task ClickSearchAsync() => Search.ClickAsync();

}
