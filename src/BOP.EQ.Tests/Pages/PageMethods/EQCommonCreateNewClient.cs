using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonCreateNewClient
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonCreateNewClient(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator ExistingClientMatch => EQCommonCreateNewClientLocators.ExistingClientMatch(_page);

    public Task PressExistingClientMatchAsync(string key) => ExistingClientMatch.PressAsync(key);

    public Task DoubleClickExistingClientMatchAsync() => ExistingClientMatch.DblClickAsync();

    public Task WaitForExistingClientMatchAsync() =>
        ExistingClientMatch.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator CreateNewClient1 => EQCommonCreateNewClientLocators.CreateNewClient1(_page);

    public Task PressCreateNewClient1Async(string key) => CreateNewClient1.PressAsync(key);

    public Task DoubleClickCreateNewClient1Async() => CreateNewClient1.DblClickAsync();

    public Task SetCreateNewClient1Async(string value) =>
        UiActions.ApplyInputAsync(_page, CreateNewClient1, _data.Resolve(value));

    public Task TypeCreateNewClient1Async(string value, float delayMs = 40) =>
        CreateNewClient1.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Next => EQCommonCreateNewClientLocators.Next(_page);

    public Task PressNextAsync(string key) => Next.PressAsync(key);

    public Task DoubleClickNextAsync() => Next.DblClickAsync();

    public Task ClickNextAsync() => Next.ClickAsync();

    public Task ClickCreateNewClient1Async() => CreateNewClient1.ClickAsync();

    public Task WaitForCreateNewClient1Async() => CreateNewClient1.WaitForAsync(new() { State = WaitForSelectorState.Visible });
}
