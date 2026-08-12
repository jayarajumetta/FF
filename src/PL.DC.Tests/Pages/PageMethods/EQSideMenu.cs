using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQSideMenu
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQSideMenu(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator DriverInformation => EQSideMenuLocators.DriverInformation(_page);

    public Task PressDriverInformationAsync(string key) => DriverInformation.PressAsync(key);

    public Task DoubleClickDriverInformationAsync() => DriverInformation.DblClickAsync();

    public Task SetDriverInformationAsync(string value) =>
        UiActions.ApplyInputAsync(_page, DriverInformation, _data.Resolve(value));

    public Task TypeDriverInformationAsync(string value, float delayMs = 40) =>
        DriverInformation.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator VehicleSummary => EQSideMenuLocators.VehicleSummary(_page);

    public Task PressVehicleSummaryAsync(string key) => VehicleSummary.PressAsync(key);

    public Task DoubleClickVehicleSummaryAsync() => VehicleSummary.DblClickAsync();

    public Task SetVehicleSummaryAsync(string value) =>
        UiActions.ApplyInputAsync(_page, VehicleSummary, _data.Resolve(value));

    public Task TypeVehicleSummaryAsync(string value, float delayMs = 40) =>
        VehicleSummary.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task SelectVehicleSummaryAsync(string value) =>
        VehicleSummary.SelectOptionAsync(_data.Resolve(value));

    private ILocator Coverages => EQSideMenuLocators.Coverages(_page);

    public Task PressCoveragesAsync(string key) => Coverages.PressAsync(key);

    public Task DoubleClickCoveragesAsync() => Coverages.DblClickAsync();

    public Task SelectCoveragesAsync(string value) =>
        Coverages.SelectOptionAsync(_data.Resolve(value));

    private ILocator QuoteNumber => EQSideMenuLocators.QuoteNumber(_page);

    public Task PressQuoteNumberAsync(string key) => QuoteNumber.PressAsync(key);

    public Task DoubleClickQuoteNumberAsync() => QuoteNumber.DblClickAsync();

    public async Task StoreQuoteNumberAsync(string key)
    {
        var value = await QuoteNumber.TextContentAsync() ?? await QuoteNumber.InputValueAsync();
        _data.SetBuffer(key, value ?? string.Empty);
    }

}
