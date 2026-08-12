using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQDriverInformation
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQDriverInformation(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator IneligibleQuote => EQDriverInformationLocators.IneligibleQuote(_page);

    public Task PressIneligibleQuoteAsync(string key) => IneligibleQuote.PressAsync(key);

    public Task DoubleClickIneligibleQuoteAsync() => IneligibleQuote.DblClickAsync();

    public Task VerifyIneligibleQuoteAsync(string expected) =>
        Expect(IneligibleQuote).ToContainTextAsync(_data.Resolve(expected));

    private ILocator CLOSEQUOTE => EQDriverInformationLocators.CLOSEQUOTE(_page);

    public Task PressCLOSEQUOTEAsync(string key) => CLOSEQUOTE.PressAsync(key);

    public Task DoubleClickCLOSEQUOTEAsync() => CLOSEQUOTE.DblClickAsync();

    public Task ClickCLOSEQUOTEAsync() => CLOSEQUOTE.ClickAsync();

    private ILocator ExistingClient1 => EQDriverInformationLocators.ExistingClient1(_page);

    public Task PressExistingClient1Async(string key) => ExistingClient1.PressAsync(key);

    public Task DoubleClickExistingClient1Async() => ExistingClient1.DblClickAsync();

    public Task SetExistingClient1Async(string value) =>
        UiActions.ApplyInputAsync(_page, ExistingClient1, _data.Resolve(value));

    public Task TypeExistingClient1Async(string value, float delayMs = 40) =>
        ExistingClient1.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BtnNext => EQDriverInformationLocators.BtnNext(_page);

    public Task PressBtnNextAsync(string key) => BtnNext.PressAsync(key);

    public Task DoubleClickBtnNextAsync() => BtnNext.DblClickAsync();

    public Task ClickBtnNextAsync() => BtnNext.ClickAsync();

    public Task ClickExistingClient1Async() => ExistingClient1.ClickAsync();
}
