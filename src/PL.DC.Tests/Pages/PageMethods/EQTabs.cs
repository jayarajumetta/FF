using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQTabs
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQTabs(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator BtnCloseTab => EQTabsLocators.BtnCloseTab(_page);

    public Task PressBtnCloseTabAsync(string key) => BtnCloseTab.PressAsync(key);

    public Task DoubleClickBtnCloseTabAsync() => BtnCloseTab.DblClickAsync();

    public Task SetBtnCloseTabAsync(string value) =>
        UiActions.ApplyInputAsync(_page, BtnCloseTab, _data.Resolve(value));

    public Task TypeBtnCloseTabAsync(string value, float delayMs = 40) =>
        BtnCloseTab.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BtnNewTab => EQTabsLocators.BtnNewTab(_page);

    public Task PressBtnNewTabAsync(string key) => BtnNewTab.PressAsync(key);

    public Task DoubleClickBtnNewTabAsync() => BtnNewTab.DblClickAsync();

    public Task SetBtnNewTabAsync(string value) =>
        UiActions.ApplyInputAsync(_page, BtnNewTab, _data.Resolve(value));

    public Task TypeBtnNewTabAsync(string value, float delayMs = 40) =>
        BtnNewTab.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator TxtQuoteSearchInput => EQTabsLocators.TxtQuoteSearchInput(_page);

    public Task PressTxtQuoteSearchInputAsync(string key) => TxtQuoteSearchInput.PressAsync(key);

    public Task DoubleClickTxtQuoteSearchInputAsync() => TxtQuoteSearchInput.DblClickAsync();

    public Task SetTxtQuoteSearchInputAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TxtQuoteSearchInput, _data.Resolve(value));

    public Task TypeTxtQuoteSearchInputAsync(string value, float delayMs = 40) =>
        TxtQuoteSearchInput.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BtnSearch => EQTabsLocators.BtnSearch(_page);

    public Task PressBtnSearchAsync(string key) => BtnSearch.PressAsync(key);

    public Task DoubleClickBtnSearchAsync() => BtnSearch.DblClickAsync();

    public Task ClickBtnSearchAsync() => BtnSearch.ClickAsync();

    private ILocator BtnEdit => EQTabsLocators.BtnEdit(_page);

    public Task PressBtnEditAsync(string key) => BtnEdit.PressAsync(key);

    public Task DoubleClickBtnEditAsync() => BtnEdit.DblClickAsync();

    public Task SetBtnEditAsync(string value) =>
        UiActions.ApplyInputAsync(_page, BtnEdit, _data.Resolve(value));

    public Task TypeBtnEditAsync(string value, float delayMs = 40) =>
        BtnEdit.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator LblQNum => EQTabsLocators.LblQNum(_page);

    public Task PressLblQNumAsync(string key) => LblQNum.PressAsync(key);

    public Task DoubleClickLblQNumAsync() => LblQNum.DblClickAsync();

    public Task VerifyLblQNumAsync(string expected) =>
        Expect(LblQNum).ToContainTextAsync(_data.Resolve(expected));

    public async Task StoreLblQNumAsync(string key)
    {
        var value = await LblQNum.TextContentAsync() ?? await LblQNum.InputValueAsync();
        _data.SetBuffer(key, value ?? string.Empty);
    }

    private ILocator LblQuote => EQTabsLocators.LblQuote(_page);

    public Task PressLblQuoteAsync(string key) => LblQuote.PressAsync(key);

    public Task DoubleClickLblQuoteAsync() => LblQuote.DblClickAsync();

    public async Task StoreLblQuoteAsync(string key)
    {
        var value = await LblQuote.TextContentAsync() ?? await LblQuote.InputValueAsync();
        _data.SetBuffer(key, value ?? string.Empty);
    }

    public Task ClickBtnCloseTabAsync() => BtnCloseTab.ClickAsync();

    public Task ClickBtnEditAsync() => BtnEdit.ClickAsync();

    public Task ClickBtnNewTabAsync() => BtnNewTab.ClickAsync();
}
