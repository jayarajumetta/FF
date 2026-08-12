using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQVehicleSummaryAutoAdditional
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQVehicleSummaryAutoAdditional(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator VIN => EQVehicleSummaryAutoAdditionalLocators.VIN(_page);

    public Task PressVINAsync(string key) => VIN.PressAsync(key);

    public Task DoubleClickVINAsync() => VIN.DblClickAsync();

    public Task SetVINAsync(string value) =>
        UiActions.ApplyInputAsync(_page, VIN, _data.Resolve(value));

    public Task TypeVINAsync(string value, float delayMs = 40) =>
        VIN.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task WaitForVINAsync() =>
        VIN.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator VehicleMoreOptions => EQVehicleSummaryAutoAdditionalLocators.VehicleMoreOptions(_page);

    public Task PressVehicleMoreOptionsAsync(string key) => VehicleMoreOptions.PressAsync(key);

    public Task DoubleClickVehicleMoreOptionsAsync() => VehicleMoreOptions.DblClickAsync();

    public Task ClickVehicleMoreOptionsAsync() => VehicleMoreOptions.ClickAsync();

    private ILocator CollectorCar => EQVehicleSummaryAutoAdditionalLocators.CollectorCar(_page);

    public Task PressCollectorCarAsync(string key) => CollectorCar.PressAsync(key);

    public Task DoubleClickCollectorCarAsync() => CollectorCar.DblClickAsync();

    public Task SetCollectorCarAsync(string value) =>
        UiActions.ApplyInputAsync(_page, CollectorCar, _data.Resolve(value));

    public Task TypeCollectorCarAsync(string value, float delayMs = 40) =>
        CollectorCar.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator CollectorCarTypeMoreOptions => EQVehicleSummaryAutoAdditionalLocators.CollectorCarTypeMoreOptions(_page);

    public Task PressCollectorCarTypeMoreOptionsAsync(string key) => CollectorCarTypeMoreOptions.PressAsync(key);

    public Task DoubleClickCollectorCarTypeMoreOptionsAsync() => CollectorCarTypeMoreOptions.DblClickAsync();

    public Task ClickCollectorCarTypeMoreOptionsAsync() => CollectorCarTypeMoreOptions.ClickAsync();

    private ILocator Classic => EQVehicleSummaryAutoAdditionalLocators.Classic(_page);

    public Task PressClassicAsync(string key) => Classic.PressAsync(key);

    public Task DoubleClickClassicAsync() => Classic.DblClickAsync();

    public Task SetClassicAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Classic, _data.Resolve(value));

    public Task TypeClassicAsync(string value, float delayMs = 40) =>
        Classic.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator AgreedValue => EQVehicleSummaryAutoAdditionalLocators.AgreedValue(_page);

    public Task PressAgreedValueAsync(string key) => AgreedValue.PressAsync(key);

    public Task DoubleClickAgreedValueAsync() => AgreedValue.DblClickAsync();

    public Task SetAgreedValueAsync(string value) =>
        UiActions.ApplyInputAsync(_page, AgreedValue, _data.Resolve(value));

    public Task TypeAgreedValueAsync(string value, float delayMs = 40) =>
        AgreedValue.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Own => EQVehicleSummaryAutoAdditionalLocators.Own(_page);

    public Task PressOwnAsync(string key) => Own.PressAsync(key);

    public Task DoubleClickOwnAsync() => Own.DblClickAsync();

    public Task SetOwnAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Own, _data.Resolve(value));

    public Task TypeOwnAsync(string value, float delayMs = 40) =>
        Own.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Continue => EQVehicleSummaryAutoAdditionalLocators.Continue(_page);

    public Task PressContinueAsync(string key) => Continue.PressAsync(key);

    public Task DoubleClickContinueAsync() => Continue.DblClickAsync();

    public Task ClickContinueAsync() => Continue.ClickAsync();

    private ILocator CONTINUE => EQVehicleSummaryAutoAdditionalLocators.CONTINUE(_page);

    public Task PressCONTINUEAsync(string key) => CONTINUE.PressAsync(key);

    public Task DoubleClickCONTINUEAsync() => CONTINUE.DblClickAsync();

    public Task ClickCONTINUEAsync() => CONTINUE.ClickAsync();

    private ILocator RestrictedUse => EQVehicleSummaryAutoAdditionalLocators.RestrictedUse(_page);

    public Task PressRestrictedUseAsync(string key) => RestrictedUse.PressAsync(key);

    public Task DoubleClickRestrictedUseAsync() => RestrictedUse.DblClickAsync();

    public Task SetRestrictedUseAsync(string value) =>
        UiActions.ApplyInputAsync(_page, RestrictedUse, _data.Resolve(value));

    public Task TypeRestrictedUseAsync(string value, float delayMs = 40) =>
        RestrictedUse.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator AppraisalDate => EQVehicleSummaryAutoAdditionalLocators.AppraisalDate(_page);

    public Task PressAppraisalDateAsync(string key) => AppraisalDate.PressAsync(key);

    public Task DoubleClickAppraisalDateAsync() => AppraisalDate.DblClickAsync();

    public Task SetAppraisalDateAsync(string value) =>
        UiActions.ApplyInputAsync(_page, AppraisalDate, _data.Resolve(value));

    public Task TypeAppraisalDateAsync(string value, float delayMs = 40) =>
        AppraisalDate.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator TotalAnnualMileage => EQVehicleSummaryAutoAdditionalLocators.TotalAnnualMileage(_page);

    public Task PressTotalAnnualMileageAsync(string key) => TotalAnnualMileage.PressAsync(key);

    public Task DoubleClickTotalAnnualMileageAsync() => TotalAnnualMileage.DblClickAsync();

    public Task SetTotalAnnualMileageAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TotalAnnualMileage, _data.Resolve(value));

    public Task TypeTotalAnnualMileageAsync(string value, float delayMs = 40) =>
        TotalAnnualMileage.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator SaveContinue => EQVehicleSummaryAutoAdditionalLocators.SaveContinue(_page);

    public Task PressSaveContinueAsync(string key) => SaveContinue.PressAsync(key);

    public Task DoubleClickSaveContinueAsync() => SaveContinue.DblClickAsync();

    public Task ClickSaveContinueAsync() => SaveContinue.ClickAsync();

    private ILocator ModernClassic => EQVehicleSummaryAutoAdditionalLocators.ModernClassic(_page);

    public Task PressModernClassicAsync(string key) => ModernClassic.PressAsync(key);

    public Task DoubleClickModernClassicAsync() => ModernClassic.DblClickAsync();

    public Task SetModernClassicAsync(string value) =>
        UiActions.ApplyInputAsync(_page, ModernClassic, _data.Resolve(value));

    public Task TypeModernClassicAsync(string value, float delayMs = 40) =>
        ModernClassic.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Odometer => EQVehicleSummaryAutoAdditionalLocators.Odometer(_page);

    public Task PressOdometerAsync(string key) => Odometer.PressAsync(key);

    public Task DoubleClickOdometerAsync() => Odometer.DblClickAsync();

    public Task SetOdometerAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Odometer, _data.Resolve(value));

    public Task TypeOdometerAsync(string value, float delayMs = 40) =>
        Odometer.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator PurchaseDate => EQVehicleSummaryAutoAdditionalLocators.PurchaseDate(_page);

    public Task PressPurchaseDateAsync(string key) => PurchaseDate.PressAsync(key);

    public Task DoubleClickPurchaseDateAsync() => PurchaseDate.DblClickAsync();

    public Task SetPurchaseDateAsync(string value) =>
        UiActions.ApplyInputAsync(_page, PurchaseDate, _data.Resolve(value));

    public Task TypePurchaseDateAsync(string value, float delayMs = 40) =>
        PurchaseDate.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task ClickCollectorCarAsync() => CollectorCar.ClickAsync();
}
