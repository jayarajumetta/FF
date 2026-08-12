using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPBuildingAddBuildingOwnRentSqFootage
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPBuildingAddBuildingOwnRentSqFootage(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator SelectIfClientOwnsOrRentsTheBuilding => EQBOPBuildingAddBuildingOwnRentSqFootageLocators.SelectIfClientOwnsOrRentsTheBuilding(_page);

    public Task PressSelectIfClientOwnsOrRentsTheBuildingAsync(string key) => SelectIfClientOwnsOrRentsTheBuilding.PressAsync(key);

    public Task DoubleClickSelectIfClientOwnsOrRentsTheBuildingAsync() => SelectIfClientOwnsOrRentsTheBuilding.DblClickAsync();

    public Task WaitForSelectIfClientOwnsOrRentsTheBuildingAsync() =>
        SelectIfClientOwnsOrRentsTheBuilding.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator OwnButton => EQBOPBuildingAddBuildingOwnRentSqFootageLocators.OwnButton(_page);

    public Task PressOwnButtonAsync(string key) => OwnButton.PressAsync(key);

    public Task DoubleClickOwnButtonAsync() => OwnButton.DblClickAsync();

    public Task SetOwnButtonAsync(string value) =>
        UiActions.ApplyInputAsync(_page, OwnButton, _data.Resolve(value));

    public Task TypeOwnButtonAsync(string value, float delayMs = 40) =>
        OwnButton.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator TotalBuildingSqFootage => EQBOPBuildingAddBuildingOwnRentSqFootageLocators.TotalBuildingSqFootage(_page);

    public Task PressTotalBuildingSqFootageAsync(string key) => TotalBuildingSqFootage.PressAsync(key);

    public Task DoubleClickTotalBuildingSqFootageAsync() => TotalBuildingSqFootage.DblClickAsync();

    public Task SetTotalBuildingSqFootageAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TotalBuildingSqFootage, _data.Resolve(value));

    public Task TypeTotalBuildingSqFootageAsync(string value, float delayMs = 40) =>
        TotalBuildingSqFootage.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task VerifyTotalBuildingSqFootageAsync(string expected) =>
        Expect(TotalBuildingSqFootage).ToContainTextAsync(_data.Resolve(expected));

    public Task WaitForTotalBuildingSqFootageAsync() =>
        TotalBuildingSqFootage.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator InsuredOccupancySqFt => EQBOPBuildingAddBuildingOwnRentSqFootageLocators.InsuredOccupancySqFt(_page);

    public Task PressInsuredOccupancySqFtAsync(string key) => InsuredOccupancySqFt.PressAsync(key);

    public Task DoubleClickInsuredOccupancySqFtAsync() => InsuredOccupancySqFt.DblClickAsync();

    public Task SetInsuredOccupancySqFtAsync(string value) =>
        UiActions.ApplyInputAsync(_page, InsuredOccupancySqFt, _data.Resolve(value));

    public Task TypeInsuredOccupancySqFtAsync(string value, float delayMs = 40) =>
        InsuredOccupancySqFt.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator OwnButtonOld => EQBOPBuildingAddBuildingOwnRentSqFootageLocators.OwnButtonOld(_page);

    public Task PressOwnButtonOldAsync(string key) => OwnButtonOld.PressAsync(key);

    public Task DoubleClickOwnButtonOldAsync() => OwnButtonOld.DblClickAsync();

    public Task ClickOwnButtonOldAsync() => OwnButtonOld.ClickAsync();

    private ILocator RentButton => EQBOPBuildingAddBuildingOwnRentSqFootageLocators.RentButton(_page);

    public Task PressRentButtonAsync(string key) => RentButton.PressAsync(key);

    public Task DoubleClickRentButtonAsync() => RentButton.DblClickAsync();

    public Task ClickRentButtonAsync() => RentButton.ClickAsync();

    public Task ClickInsuredOccupancySqFtAsync() => InsuredOccupancySqFt.ClickAsync();
}
