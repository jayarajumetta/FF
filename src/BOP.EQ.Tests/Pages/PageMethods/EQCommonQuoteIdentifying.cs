using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonQuoteIdentifying
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonQuoteIdentifying(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator NameAndQuote => EQCommonQuoteIdentifyingLocators.NameAndQuote(_page);

    public Task PressNameAndQuoteAsync(string key) => NameAndQuote.PressAsync(key);

    public Task DoubleClickNameAndQuoteAsync() => NameAndQuote.DblClickAsync();

    public Task VerifyNameAndQuoteAsync(string expected) =>
        Expect(NameAndQuote).ToContainTextAsync(_data.Resolve(expected));

    public async Task StoreNameAndQuoteAsync(string key)
    {
        var value = await NameAndQuote.TextContentAsync() ?? await NameAndQuote.InputValueAsync();
        _data.SetBuffer(key, value ?? string.Empty);
    }

    private ILocator CloseQuote => EQCommonQuoteIdentifyingLocators.CloseQuote(_page);

    public Task PressCloseQuoteAsync(string key) => CloseQuote.PressAsync(key);

    public Task DoubleClickCloseQuoteAsync() => CloseQuote.DblClickAsync();

    public Task SetCloseQuoteAsync(string value) =>
        UiActions.ApplyInputAsync(_page, CloseQuote, _data.Resolve(value));

    public Task TypeCloseQuoteAsync(string value, float delayMs = 40) =>
        CloseQuote.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task ClickCloseQuoteAsync() => CloseQuote.ClickAsync();
}
