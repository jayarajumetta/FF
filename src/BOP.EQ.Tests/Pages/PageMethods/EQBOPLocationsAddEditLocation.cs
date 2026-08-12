using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPLocationsAddEditLocation
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPLocationsAddEditLocation(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator LabelNicknameForTheLocation => EQBOPLocationsAddEditLocationLocators.LabelNicknameForTheLocation(_page);

    public Task PressLabelNicknameForTheLocationAsync(string key) => LabelNicknameForTheLocation.PressAsync(key);

    public Task DoubleClickLabelNicknameForTheLocationAsync() => LabelNicknameForTheLocation.DblClickAsync();

    public Task SetLabelNicknameForTheLocationAsync(string value) =>
        UiActions.ApplyInputAsync(_page, LabelNicknameForTheLocation, _data.Resolve(value));

    public Task TypeLabelNicknameForTheLocationAsync(string value, float delayMs = 40) =>
        LabelNicknameForTheLocation.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator FeetFromFireHydrant => EQBOPLocationsAddEditLocationLocators.FeetFromFireHydrant(_page);

    public Task PressFeetFromFireHydrantAsync(string key) => FeetFromFireHydrant.PressAsync(key);

    public Task DoubleClickFeetFromFireHydrantAsync() => FeetFromFireHydrant.DblClickAsync();

    public Task SetFeetFromFireHydrantAsync(string value) =>
        UiActions.ApplyInputAsync(_page, FeetFromFireHydrant, _data.Resolve(value));

    public Task TypeFeetFromFireHydrantAsync(string value, float delayMs = 40) =>
        FeetFromFireHydrant.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator OrderWildfireRiskScore => EQBOPLocationsAddEditLocationLocators.OrderWildfireRiskScore(_page);

    public Task PressOrderWildfireRiskScoreAsync(string key) => OrderWildfireRiskScore.PressAsync(key);

    public Task DoubleClickOrderWildfireRiskScoreAsync() => OrderWildfireRiskScore.DblClickAsync();

    public Task ClickOrderWildfireRiskScoreAsync() => OrderWildfireRiskScore.ClickAsync();

    private ILocator Item1100 => EQBOPLocationsAddEditLocationLocators.Item1100(_page);

    public Task PressItem1100Async(string key) => Item1100.PressAsync(key);

    public Task DoubleClickItem1100Async() => Item1100.DblClickAsync();

    public Task SetItem1100Async(string value) =>
        UiActions.ApplyInputAsync(_page, Item1100, _data.Resolve(value));

    public Task TypeItem1100Async(string value, float delayMs = 40) =>
        Item1100.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Save => EQBOPLocationsAddEditLocationLocators.Save(_page);

    public Task PressSaveAsync(string key) => Save.PressAsync(key);

    public Task DoubleClickSaveAsync() => Save.DblClickAsync();

    public Task ClickSaveAsync() => Save.ClickAsync();

    public Task WaitForSaveAsync() =>
        Save.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator MilesFromFireDepartment => EQBOPLocationsAddEditLocationLocators.MilesFromFireDepartment(_page);

    public Task PressMilesFromFireDepartmentAsync(string key) => MilesFromFireDepartment.PressAsync(key);

    public Task DoubleClickMilesFromFireDepartmentAsync() => MilesFromFireDepartment.DblClickAsync();

    public Task SetMilesFromFireDepartmentAsync(string value) =>
        UiActions.ApplyInputAsync(_page, MilesFromFireDepartment, _data.Resolve(value));

    public Task TypeMilesFromFireDepartmentAsync(string value, float delayMs = 40) =>
        MilesFromFireDepartment.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task WaitForMilesFromFireDepartmentAsync() =>
        MilesFromFireDepartment.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator Address1 => EQBOPLocationsAddEditLocationLocators.Address1(_page);

    public Task PressAddress1Async(string key) => Address1.PressAsync(key);

    public Task DoubleClickAddress1Async() => Address1.DblClickAsync();

    public Task SetAddress1Async(string value) =>
        UiActions.ApplyInputAsync(_page, Address1, _data.Resolve(value));

    public Task TypeAddress1Async(string value, float delayMs = 40) =>
        Address1.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator StateDropdown => EQBOPLocationsAddEditLocationLocators.StateDropdown(_page);

    public Task PressStateDropdownAsync(string key) => StateDropdown.PressAsync(key);

    public Task DoubleClickStateDropdownAsync() => StateDropdown.DblClickAsync();

    public Task SetStateDropdownAsync(string value) =>
        UiActions.ApplyInputAsync(_page, StateDropdown, _data.Resolve(value));

    public Task TypeStateDropdownAsync(string value, float delayMs = 40) =>
        StateDropdown.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator State => EQBOPLocationsAddEditLocationLocators.State(_page);

    public Task PressStateAsync(string key) => State.PressAsync(key);

    public Task DoubleClickStateAsync() => State.DblClickAsync();

    public Task SetStateAsync(string value) =>
        UiActions.ApplyInputAsync(_page, State, _data.Resolve(value));

    public Task TypeStateAsync(string value, float delayMs = 40) =>
        State.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator City => EQBOPLocationsAddEditLocationLocators.City(_page);

    public Task PressCityAsync(string key) => City.PressAsync(key);

    public Task DoubleClickCityAsync() => City.DblClickAsync();

    public Task SetCityAsync(string value) =>
        UiActions.ApplyInputAsync(_page, City, _data.Resolve(value));

    public Task TypeCityAsync(string value, float delayMs = 40) =>
        City.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator ZipCode => EQBOPLocationsAddEditLocationLocators.ZipCode(_page);

    public Task PressZipCodeAsync(string key) => ZipCode.PressAsync(key);

    public Task DoubleClickZipCodeAsync() => ZipCode.DblClickAsync();

    public Task SetZipCodeAsync(string value) =>
        UiActions.ApplyInputAsync(_page, ZipCode, _data.Resolve(value));

    public Task TypeZipCodeAsync(string value, float delayMs = 40) =>
        ZipCode.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task WaitForZipCodeAsync() =>
        ZipCode.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator ValidateAddress => EQBOPLocationsAddEditLocationLocators.ValidateAddress(_page);

    public Task PressValidateAddressAsync(string key) => ValidateAddress.PressAsync(key);

    public Task DoubleClickValidateAddressAsync() => ValidateAddress.DblClickAsync();

    public Task ClickValidateAddressAsync() => ValidateAddress.ClickAsync();

    private ILocator Item501750 => EQBOPLocationsAddEditLocationLocators.Item501750(_page);

    public Task PressItem501750Async(string key) => Item501750.PressAsync(key);

    public Task DoubleClickItem501750Async() => Item501750.DblClickAsync();

    public Task SetItem501750Async(string value) =>
        UiActions.ApplyInputAsync(_page, Item501750, _data.Resolve(value));

    public Task TypeItem501750Async(string value, float delayMs = 40) =>
        Item501750.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task ClickFeetFromFireHydrantAsync() => FeetFromFireHydrant.ClickAsync();

    public Task ClickLabelNicknameForTheLocationAsync() => LabelNicknameForTheLocation.ClickAsync();

    public Task ClickStateDropdownAsync() => StateDropdown.ClickAsync();
}
