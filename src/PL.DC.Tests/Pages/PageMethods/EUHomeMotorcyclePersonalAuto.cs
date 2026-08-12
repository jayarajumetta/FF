using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EUHomeMotorcyclePersonalAuto
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EUHomeMotorcyclePersonalAuto(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator LnkMotorcycle => EUHomeMotorcyclePersonalAutoLocators.LnkMotorcycle(_page);

    public Task PressLnkMotorcycleAsync(string key) => LnkMotorcycle.PressAsync(key);

    public Task DoubleClickLnkMotorcycleAsync() => LnkMotorcycle.DblClickAsync();

    public Task ClickLnkMotorcycleAsync() => LnkMotorcycle.ClickAsync();

    private ILocator LnkPersonalAuto => EUHomeMotorcyclePersonalAutoLocators.LnkPersonalAuto(_page);

    public Task PressLnkPersonalAutoAsync(string key) => LnkPersonalAuto.PressAsync(key);

    public Task DoubleClickLnkPersonalAutoAsync() => LnkPersonalAuto.DblClickAsync();

    public Task ClickLnkPersonalAutoAsync() => LnkPersonalAuto.ClickAsync();

    private ILocator LnkRV => EUHomeMotorcyclePersonalAutoLocators.LnkRV(_page);

    public Task PressLnkRVAsync(string key) => LnkRV.PressAsync(key);

    public Task DoubleClickLnkRVAsync() => LnkRV.DblClickAsync();

    public Task ClickLnkRVAsync() => LnkRV.ClickAsync();

}
