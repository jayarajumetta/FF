using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQClientSelection
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQClientSelection(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator TxtFirst => EQClientSelectionLocators.TxtFirst(_page);

    public Task PressTxtFirstAsync(string key) => TxtFirst.PressAsync(key);

    public Task DoubleClickTxtFirstAsync() => TxtFirst.DblClickAsync();

    public Task SetTxtFirstAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TxtFirst, _data.Resolve(value));

    public Task TypeTxtFirstAsync(string value, float delayMs = 40) =>
        TxtFirst.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator TxtLast => EQClientSelectionLocators.TxtLast(_page);

    public Task PressTxtLastAsync(string key) => TxtLast.PressAsync(key);

    public Task DoubleClickTxtLastAsync() => TxtLast.DblClickAsync();

    public Task SetTxtLastAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TxtLast, _data.Resolve(value));

    public Task TypeTxtLastAsync(string value, float delayMs = 40) =>
        TxtLast.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BtnSearch => EQClientSelectionLocators.BtnSearch(_page);

    public Task PressBtnSearchAsync(string key) => BtnSearch.PressAsync(key);

    public Task DoubleClickBtnSearchAsync() => BtnSearch.DblClickAsync();

    public Task ClickBtnSearchAsync() => BtnSearch.ClickAsync();

    public Task WaitForBtnSearchAsync() =>
        BtnSearch.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator BtnCreateNewClient => EQClientSelectionLocators.BtnCreateNewClient(_page);

    public Task PressBtnCreateNewClientAsync(string key) => BtnCreateNewClient.PressAsync(key);

    public Task DoubleClickBtnCreateNewClientAsync() => BtnCreateNewClient.DblClickAsync();

    public Task SetBtnCreateNewClientAsync(string value) =>
        UiActions.ApplyInputAsync(_page, BtnCreateNewClient, _data.Resolve(value));

    public Task TypeBtnCreateNewClientAsync(string value, float delayMs = 40) =>
        BtnCreateNewClient.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task WaitForBtnCreateNewClientAsync() =>
        BtnCreateNewClient.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator BtnNext => EQClientSelectionLocators.BtnNext(_page);

    public Task PressBtnNextAsync(string key) => BtnNext.PressAsync(key);

    public Task DoubleClickBtnNextAsync() => BtnNext.DblClickAsync();

    public Task ClickBtnNextAsync() => BtnNext.ClickAsync();

    public Task ClickBtnCreateNewClientAsync() => BtnCreateNewClient.ClickAsync();
}
