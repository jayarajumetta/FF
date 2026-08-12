using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQAddCycleNext
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQAddCycleNext(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator AddAdditionalVehicle => EQAddCycleNextLocators.AddAdditionalVehicle(_page);

    public Task PressAddAdditionalVehicleAsync(string key) => AddAdditionalVehicle.PressAsync(key);

    public Task DoubleClickAddAdditionalVehicleAsync() => AddAdditionalVehicle.DblClickAsync();

    public Task ClickAddAdditionalVehicleAsync() => AddAdditionalVehicle.ClickAsync();

    private ILocator Next => EQAddCycleNextLocators.Next(_page);

    public Task PressNextAsync(string key) => Next.PressAsync(key);

    public Task DoubleClickNextAsync() => Next.DblClickAsync();

    public Task ClickNextAsync() => Next.ClickAsync();

}
