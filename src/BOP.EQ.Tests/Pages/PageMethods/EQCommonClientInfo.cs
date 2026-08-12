using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonClientInfo
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonClientInfo(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator ClientInfo => EQCommonClientInfoLocators.ClientInfo(_page);

    public Task PressClientInfoAsync(string key) => ClientInfo.PressAsync(key);

    public Task DoubleClickClientInfoAsync() => ClientInfo.DblClickAsync();

    public Task WaitForClientInfoAsync() =>
        ClientInfo.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator NewExistingClientSearch => EQCommonClientInfoLocators.NewExistingClientSearch(_page);

    public Task PressNewExistingClientSearchAsync(string key) => NewExistingClientSearch.PressAsync(key);

    public Task DoubleClickNewExistingClientSearchAsync() => NewExistingClientSearch.DblClickAsync();

    public Task WaitForNewExistingClientSearchAsync() =>
        NewExistingClientSearch.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator CustomerNameFirst => EQCommonClientInfoLocators.CustomerNameFirst(_page);

    public Task PressCustomerNameFirstAsync(string key) => CustomerNameFirst.PressAsync(key);

    public Task DoubleClickCustomerNameFirstAsync() => CustomerNameFirst.DblClickAsync();

    public Task SetCustomerNameFirstAsync(string value) =>
        UiActions.ApplyInputAsync(_page, CustomerNameFirst, _data.Resolve(value));

    public Task TypeCustomerNameFirstAsync(string value, float delayMs = 40) =>
        CustomerNameFirst.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator CustomerNameLast => EQCommonClientInfoLocators.CustomerNameLast(_page);

    public Task PressCustomerNameLastAsync(string key) => CustomerNameLast.PressAsync(key);

    public Task DoubleClickCustomerNameLastAsync() => CustomerNameLast.DblClickAsync();

    public Task SetCustomerNameLastAsync(string value) =>
        UiActions.ApplyInputAsync(_page, CustomerNameLast, _data.Resolve(value));

    public Task TypeCustomerNameLastAsync(string value, float delayMs = 40) =>
        CustomerNameLast.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator CustomerDateOfBirth => EQCommonClientInfoLocators.CustomerDateOfBirth(_page);

    public Task PressCustomerDateOfBirthAsync(string key) => CustomerDateOfBirth.PressAsync(key);

    public Task DoubleClickCustomerDateOfBirthAsync() => CustomerDateOfBirth.DblClickAsync();

    public Task SetCustomerDateOfBirthAsync(string value) =>
        UiActions.ApplyInputAsync(_page, CustomerDateOfBirth, _data.Resolve(value));

    public Task TypeCustomerDateOfBirthAsync(string value, float delayMs = 40) =>
        CustomerDateOfBirth.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Search => EQCommonClientInfoLocators.Search(_page);

    public Task PressSearchAsync(string key) => Search.PressAsync(key);

    public Task DoubleClickSearchAsync() => Search.DblClickAsync();

    public Task ClickSearchAsync() => Search.ClickAsync();

    public Task WaitForCustomerNameFirstAsync() => CustomerNameFirst.WaitForAsync(new() { State = WaitForSelectorState.Visible });
}
