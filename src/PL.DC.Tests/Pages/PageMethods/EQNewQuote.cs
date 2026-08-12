using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQNewQuote
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQNewQuote(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator BtnNewQuote => EQNewQuoteLocators.BtnNewQuote(_page);

    public Task PressBtnNewQuoteAsync(string key) => BtnNewQuote.PressAsync(key);

    public Task DoubleClickBtnNewQuoteAsync() => BtnNewQuote.DblClickAsync();

    public Task ClickBtnNewQuoteAsync() => BtnNewQuote.ClickAsync();

    public Task VerifyBtnNewQuoteAsync(string expected) =>
        Expect(BtnNewQuote).ToContainTextAsync(_data.Resolve(expected));

    public Task WaitForBtnNewQuoteAsync() =>
        BtnNewQuote.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator TxtQuoteSearchInput => EQNewQuoteLocators.TxtQuoteSearchInput(_page);

    public Task PressTxtQuoteSearchInputAsync(string key) => TxtQuoteSearchInput.PressAsync(key);

    public Task DoubleClickTxtQuoteSearchInputAsync() => TxtQuoteSearchInput.DblClickAsync();

    public Task SetTxtQuoteSearchInputAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TxtQuoteSearchInput, _data.Resolve(value));

    public Task TypeTxtQuoteSearchInputAsync(string value, float delayMs = 40) =>
        TxtQuoteSearchInput.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BtnSearch1 => EQNewQuoteLocators.BtnSearch1(_page);

    public Task PressBtnSearch1Async(string key) => BtnSearch1.PressAsync(key);

    public Task DoubleClickBtnSearch1Async() => BtnSearch1.DblClickAsync();

    public Task ClickBtnSearch1Async() => BtnSearch1.ClickAsync();

    private ILocator TxtQuotePolicySearch => EQNewQuoteLocators.TxtQuotePolicySearch(_page);

    public Task PressTxtQuotePolicySearchAsync(string key) => TxtQuotePolicySearch.PressAsync(key);

    public Task DoubleClickTxtQuotePolicySearchAsync() => TxtQuotePolicySearch.DblClickAsync();

    public Task SetTxtQuotePolicySearchAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TxtQuotePolicySearch, _data.Resolve(value));

    public Task TypeTxtQuotePolicySearchAsync(string value, float delayMs = 40) =>
        TxtQuotePolicySearch.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BtnSearch => EQNewQuoteLocators.BtnSearch(_page);

    public Task PressBtnSearchAsync(string key) => BtnSearch.PressAsync(key);

    public Task DoubleClickBtnSearchAsync() => BtnSearch.DblClickAsync();

    public Task ClickBtnSearchAsync() => BtnSearch.ClickAsync();

}
