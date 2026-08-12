using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQVehicleSummaryAutoMotorHomeUse
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQVehicleSummaryAutoMotorHomeUse(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator BtnLoan => EQVehicleSummaryAutoMotorHomeUseLocators.BtnLoan(_page);

    public Task PressBtnLoanAsync(string key) => BtnLoan.PressAsync(key);

    public Task DoubleClickBtnLoanAsync() => BtnLoan.DblClickAsync();

    public Task SetBtnLoanAsync(string value) =>
        UiActions.ApplyInputAsync(_page, BtnLoan, _data.Resolve(value));

    public Task TypeBtnLoanAsync(string value, float delayMs = 40) =>
        BtnLoan.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BtnLeased => EQVehicleSummaryAutoMotorHomeUseLocators.BtnLeased(_page);

    public Task PressBtnLeasedAsync(string key) => BtnLeased.PressAsync(key);

    public Task DoubleClickBtnLeasedAsync() => BtnLeased.DblClickAsync();

    public Task SetBtnLeasedAsync(string value) =>
        UiActions.ApplyInputAsync(_page, BtnLeased, _data.Resolve(value));

    public Task TypeBtnLeasedAsync(string value, float delayMs = 40) =>
        BtnLeased.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BtnOwn => EQVehicleSummaryAutoMotorHomeUseLocators.BtnOwn(_page);

    public Task PressBtnOwnAsync(string key) => BtnOwn.PressAsync(key);

    public Task DoubleClickBtnOwnAsync() => BtnOwn.DblClickAsync();

    public Task SetBtnOwnAsync(string value) =>
        UiActions.ApplyInputAsync(_page, BtnOwn, _data.Resolve(value));

    public Task TypeBtnOwnAsync(string value, float delayMs = 40) =>
        BtnOwn.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator NativeAmericanRegisterNO => EQVehicleSummaryAutoMotorHomeUseLocators.NativeAmericanRegisterNO(_page);

    public Task PressNativeAmericanRegisterNOAsync(string key) => NativeAmericanRegisterNO.PressAsync(key);

    public Task DoubleClickNativeAmericanRegisterNOAsync() => NativeAmericanRegisterNO.DblClickAsync();

    public Task ClickNativeAmericanRegisterNOAsync() => NativeAmericanRegisterNO.ClickAsync();

    private ILocator ILCategory1 => EQVehicleSummaryAutoMotorHomeUseLocators.ILCategory1(_page);

    public Task PressILCategory1Async(string key) => ILCategory1.PressAsync(key);

    public Task DoubleClickILCategory1Async() => ILCategory1.DblClickAsync();

    public Task ClickILCategory1Async() => ILCategory1.ClickAsync();

    private ILocator CategoryI => EQVehicleSummaryAutoMotorHomeUseLocators.CategoryI(_page);

    public Task PressCategoryIAsync(string key) => CategoryI.PressAsync(key);

    public Task DoubleClickCategoryIAsync() => CategoryI.DblClickAsync();

    public Task ClickCategoryIAsync() => CategoryI.ClickAsync();

    private ILocator ActiveDisablingDevice => EQVehicleSummaryAutoMotorHomeUseLocators.ActiveDisablingDevice(_page);

    public Task PressActiveDisablingDeviceAsync(string key) => ActiveDisablingDevice.PressAsync(key);

    public Task DoubleClickActiveDisablingDeviceAsync() => ActiveDisablingDevice.DblClickAsync();

    public Task ClickActiveDisablingDeviceAsync() => ActiveDisablingDevice.ClickAsync();

    private ILocator PleasureCANYFFCIC => EQVehicleSummaryAutoMotorHomeUseLocators.PleasureCANYFFCIC(_page);

    public Task PressPleasureCANYFFCICAsync(string key) => PleasureCANYFFCIC.PressAsync(key);

    public Task DoubleClickPleasureCANYFFCICAsync() => PleasureCANYFFCIC.DblClickAsync();

    public Task SetPleasureCANYFFCICAsync(string value) =>
        UiActions.ApplyInputAsync(_page, PleasureCANYFFCIC, _data.Resolve(value));

    public Task TypePleasureCANYFFCICAsync(string value, float delayMs = 40) =>
        PleasureCANYFFCIC.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Item1Day => EQVehicleSummaryAutoMotorHomeUseLocators.Item1Day(_page);

    public Task PressItem1DayAsync(string key) => Item1Day.PressAsync(key);

    public Task DoubleClickItem1DayAsync() => Item1Day.DblClickAsync();

    public Task ClickItem1DayAsync() => Item1Day.ClickAsync();

    private ILocator NYFFCICTotalAnnualMiles => EQVehicleSummaryAutoMotorHomeUseLocators.NYFFCICTotalAnnualMiles(_page);

    public Task PressNYFFCICTotalAnnualMilesAsync(string key) => NYFFCICTotalAnnualMiles.PressAsync(key);

    public Task DoubleClickNYFFCICTotalAnnualMilesAsync() => NYFFCICTotalAnnualMiles.DblClickAsync();

    public Task SetNYFFCICTotalAnnualMilesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, NYFFCICTotalAnnualMiles, _data.Resolve(value));

    public Task TypeNYFFCICTotalAnnualMilesAsync(string value, float delayMs = 40) =>
        NYFFCICTotalAnnualMiles.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator WorkMilesDay => EQVehicleSummaryAutoMotorHomeUseLocators.WorkMilesDay(_page);

    public Task PressWorkMilesDayAsync(string key) => WorkMilesDay.PressAsync(key);

    public Task DoubleClickWorkMilesDayAsync() => WorkMilesDay.DblClickAsync();

    public Task SetWorkMilesDayAsync(string value) =>
        UiActions.ApplyInputAsync(_page, WorkMilesDay, _data.Resolve(value));

    public Task TypeWorkMilesDayAsync(string value, float delayMs = 40) =>
        WorkMilesDay.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator NonWorkAnnualMiles => EQVehicleSummaryAutoMotorHomeUseLocators.NonWorkAnnualMiles(_page);

    public Task PressNonWorkAnnualMilesAsync(string key) => NonWorkAnnualMiles.PressAsync(key);

    public Task DoubleClickNonWorkAnnualMilesAsync() => NonWorkAnnualMiles.DblClickAsync();

    public Task SetNonWorkAnnualMilesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, NonWorkAnnualMiles, _data.Resolve(value));

    public Task TypeNonWorkAnnualMilesAsync(string value, float delayMs = 40) =>
        NonWorkAnnualMiles.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator MoreOptionsFarmUse => EQVehicleSummaryAutoMotorHomeUseLocators.MoreOptionsFarmUse(_page);

    public Task PressMoreOptionsFarmUseAsync(string key) => MoreOptionsFarmUse.PressAsync(key);

    public Task DoubleClickMoreOptionsFarmUseAsync() => MoreOptionsFarmUse.DblClickAsync();

    public Task ClickMoreOptionsFarmUseAsync() => MoreOptionsFarmUse.ClickAsync();

    private ILocator TxtPurchaseDate => EQVehicleSummaryAutoMotorHomeUseLocators.TxtPurchaseDate(_page);

    public Task PressTxtPurchaseDateAsync(string key) => TxtPurchaseDate.PressAsync(key);

    public Task DoubleClickTxtPurchaseDateAsync() => TxtPurchaseDate.DblClickAsync();

    public Task SetTxtPurchaseDateAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TxtPurchaseDate, _data.Resolve(value));

    public Task TypeTxtPurchaseDateAsync(string value, float delayMs = 40) =>
        TxtPurchaseDate.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator TxtOdometer => EQVehicleSummaryAutoMotorHomeUseLocators.TxtOdometer(_page);

    public Task PressTxtOdometerAsync(string key) => TxtOdometer.PressAsync(key);

    public Task DoubleClickTxtOdometerAsync() => TxtOdometer.DblClickAsync();

    public Task SetTxtOdometerAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TxtOdometer, _data.Resolve(value));

    public Task TypeTxtOdometerAsync(string value, float delayMs = 40) =>
        TxtOdometer.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BtnSaveContinue => EQVehicleSummaryAutoMotorHomeUseLocators.BtnSaveContinue(_page);

    public Task PressBtnSaveContinueAsync(string key) => BtnSaveContinue.PressAsync(key);

    public Task DoubleClickBtnSaveContinueAsync() => BtnSaveContinue.DblClickAsync();

    public Task ClickBtnSaveContinueAsync() => BtnSaveContinue.ClickAsync();

    private ILocator TxtAnnualMileage => EQVehicleSummaryAutoMotorHomeUseLocators.TxtAnnualMileage(_page);

    public Task PressTxtAnnualMileageAsync(string key) => TxtAnnualMileage.PressAsync(key);

    public Task DoubleClickTxtAnnualMileageAsync() => TxtAnnualMileage.DblClickAsync();

    public Task SetTxtAnnualMileageAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TxtAnnualMileage, _data.Resolve(value));

    public Task TypeTxtAnnualMileageAsync(string value, float delayMs = 40) =>
        TxtAnnualMileage.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task WaitForTxtAnnualMileageAsync() =>
        TxtAnnualMileage.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    public Task ClickBtnLeasedAsync() => BtnLeased.ClickAsync();

    public Task ClickBtnLoanAsync() => BtnLoan.ClickAsync();

    public Task ClickBtnOwnAsync() => BtnOwn.ClickAsync();

    public Task ClickPleasureCANYFFCICAsync() => PleasureCANYFFCIC.ClickAsync();
}
