using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonStartNewQuote
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonStartNewQuote(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator NewQuote => EQCommonStartNewQuoteLocators.NewQuote(_page);

    public Task PressNewQuoteAsync(string key) => NewQuote.PressAsync(key);

    public Task DoubleClickNewQuoteAsync() => NewQuote.DblClickAsync();

    public Task ClickNewQuoteAsync() => NewQuote.ClickAsync();

    public Task VerifyNewQuoteAsync(string expected) =>
        Expect(NewQuote).ToContainTextAsync(_data.Resolve(expected));

    public Task WaitForNewQuoteAsync() =>
        NewQuote.WaitForAsync(new() { State = WaitForSelectorState.Visible });

}
