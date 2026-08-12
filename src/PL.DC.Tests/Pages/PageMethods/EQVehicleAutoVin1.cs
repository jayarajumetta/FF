using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQVehicleAutoVin1
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQVehicleAutoVin1(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator TxtVIN => EQVehicleAutoVin1Locators.TxtVIN(_page);

    public Task PressTxtVINAsync(string key) => TxtVIN.PressAsync(key);

    public Task DoubleClickTxtVINAsync() => TxtVIN.DblClickAsync();

    public Task SetTxtVINAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TxtVIN, _data.Resolve(value));

    public Task TypeTxtVINAsync(string value, float delayMs = 40) =>
        TxtVIN.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task WaitForTxtVINAsync() =>
        TxtVIN.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    public Task ClickTxtVINAsync() => TxtVIN.ClickAsync();
}
