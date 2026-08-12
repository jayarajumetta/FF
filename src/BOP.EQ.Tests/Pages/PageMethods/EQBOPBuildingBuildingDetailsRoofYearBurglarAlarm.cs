using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPBuildingBuildingDetailsRoofYearBurglarAlarm
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPBuildingBuildingDetailsRoofYearBurglarAlarm(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator RoofYear => EQBOPBuildingBuildingDetailsRoofYearBurglarAlarmLocators.RoofYear(_page);

    public Task PressRoofYearAsync(string key) => RoofYear.PressAsync(key);

    public Task DoubleClickRoofYearAsync() => RoofYear.DblClickAsync();

    public Task SetRoofYearAsync(string value) =>
        UiActions.ApplyInputAsync(_page, RoofYear, _data.Resolve(value));

    public Task TypeRoofYearAsync(string value, float delayMs = 40) =>
        RoofYear.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator SprinklerYes => EQBOPBuildingBuildingDetailsRoofYearBurglarAlarmLocators.SprinklerYes(_page);

    public Task PressSprinklerYesAsync(string key) => SprinklerYes.PressAsync(key);

    public Task DoubleClickSprinklerYesAsync() => SprinklerYes.DblClickAsync();

    public Task SetSprinklerYesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, SprinklerYes, _data.Resolve(value));

    public Task TypeSprinklerYesAsync(string value, float delayMs = 40) =>
        SprinklerYes.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task WaitForSprinklerYesAsync() =>
        SprinklerYes.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator AutomaticCommercialCookingExhaustAndExtinguishingANSULSystemYes => EQBOPBuildingBuildingDetailsRoofYearBurglarAlarmLocators.AutomaticCommercialCookingExhaustAndExtinguishingANSULSystemYes(_page);

    public Task PressAutomaticCommercialCookingExhaustAndExtinguishingANSULSystemYesAsync(string key) => AutomaticCommercialCookingExhaustAndExtinguishingANSULSystemYes.PressAsync(key);

    public Task DoubleClickAutomaticCommercialCookingExhaustAndExtinguishingANSULSystemYesAsync() => AutomaticCommercialCookingExhaustAndExtinguishingANSULSystemYes.DblClickAsync();

    public Task ClickAutomaticCommercialCookingExhaustAndExtinguishingANSULSystemYesAsync() => AutomaticCommercialCookingExhaustAndExtinguishingANSULSystemYes.ClickAsync();

    private ILocator WiringTypeOther => EQBOPBuildingBuildingDetailsRoofYearBurglarAlarmLocators.WiringTypeOther(_page);

    public Task PressWiringTypeOtherAsync(string key) => WiringTypeOther.PressAsync(key);

    public Task DoubleClickWiringTypeOtherAsync() => WiringTypeOther.DblClickAsync();

    public Task ClickWiringTypeOtherAsync() => WiringTypeOther.ClickAsync();

    private ILocator ElectricalPanelTypeOther => EQBOPBuildingBuildingDetailsRoofYearBurglarAlarmLocators.ElectricalPanelTypeOther(_page);

    public Task PressElectricalPanelTypeOtherAsync(string key) => ElectricalPanelTypeOther.PressAsync(key);

    public Task DoubleClickElectricalPanelTypeOtherAsync() => ElectricalPanelTypeOther.DblClickAsync();

    public Task ClickElectricalPanelTypeOtherAsync() => ElectricalPanelTypeOther.ClickAsync();

    private ILocator AmperageOfTheMainCircuitBreaker100AmpsOrGreater => EQBOPBuildingBuildingDetailsRoofYearBurglarAlarmLocators.AmperageOfTheMainCircuitBreaker100AmpsOrGreater(_page);

    public Task PressAmperageOfTheMainCircuitBreaker100AmpsOrGreaterAsync(string key) => AmperageOfTheMainCircuitBreaker100AmpsOrGreater.PressAsync(key);

    public Task DoubleClickAmperageOfTheMainCircuitBreaker100AmpsOrGreaterAsync() => AmperageOfTheMainCircuitBreaker100AmpsOrGreater.DblClickAsync();

    public Task ClickAmperageOfTheMainCircuitBreaker100AmpsOrGreaterAsync() => AmperageOfTheMainCircuitBreaker100AmpsOrGreater.ClickAsync();

    private ILocator IsAnyHeatSourceThermostaticallyControlledYes => EQBOPBuildingBuildingDetailsRoofYearBurglarAlarmLocators.IsAnyHeatSourceThermostaticallyControlledYes(_page);

    public Task PressIsAnyHeatSourceThermostaticallyControlledYesAsync(string key) => IsAnyHeatSourceThermostaticallyControlledYes.PressAsync(key);

    public Task DoubleClickIsAnyHeatSourceThermostaticallyControlledYesAsync() => IsAnyHeatSourceThermostaticallyControlledYes.DblClickAsync();

    public Task SetIsAnyHeatSourceThermostaticallyControlledYesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, IsAnyHeatSourceThermostaticallyControlledYes, _data.Resolve(value));

    public Task TypeIsAnyHeatSourceThermostaticallyControlledYesAsync(string value, float delayMs = 40) =>
        IsAnyHeatSourceThermostaticallyControlledYes.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

}
