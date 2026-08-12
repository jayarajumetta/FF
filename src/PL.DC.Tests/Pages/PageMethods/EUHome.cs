using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EUHome
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EUHome(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator TxtSearchType => EUHomeLocators.TxtSearchType(_page);

    public Task PressTxtSearchTypeAsync(string key) => TxtSearchType.PressAsync(key);

    public Task DoubleClickTxtSearchTypeAsync() => TxtSearchType.DblClickAsync();

    public Task WaitForTxtSearchTypeAsync() =>
        TxtSearchType.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator TxtSearchText => EUHomeLocators.TxtSearchText(_page);

    public Task PressTxtSearchTextAsync(string key) => TxtSearchText.PressAsync(key);

    public Task DoubleClickTxtSearchTextAsync() => TxtSearchText.DblClickAsync();

    public Task SetTxtSearchTextAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TxtSearchText, _data.Resolve(value));

    public Task TypeTxtSearchTextAsync(string value, float delayMs = 40) =>
        TxtSearchText.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BtnSearch => EUHomeLocators.BtnSearch(_page);

    public Task PressBtnSearchAsync(string key) => BtnSearch.PressAsync(key);

    public Task DoubleClickBtnSearchAsync() => BtnSearch.DblClickAsync();

    public Task ClickBtnSearchAsync() => BtnSearch.ClickAsync();

}
