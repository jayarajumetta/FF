using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQVintageCycle
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQVintageCycle(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator CycleVIN => EQVintageCycleLocators.CycleVIN(_page);

    public Task PressCycleVINAsync(string key) => CycleVIN.PressAsync(key);

    public Task DoubleClickCycleVINAsync() => CycleVIN.DblClickAsync();

    public Task SetCycleVINAsync(string value) =>
        UiActions.ApplyInputAsync(_page, CycleVIN, _data.Resolve(value));

    public Task TypeCycleVINAsync(string value, float delayMs = 40) =>
        CycleVIN.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task WaitForCycleVINAsync() =>
        CycleVIN.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator PleaseSelectTheVehicle => EQVintageCycleLocators.PleaseSelectTheVehicle(_page);

    public Task PressPleaseSelectTheVehicleAsync(string key) => PleaseSelectTheVehicle.PressAsync(key);

    public Task DoubleClickPleaseSelectTheVehicleAsync() => PleaseSelectTheVehicle.DblClickAsync();

    public Task WaitForPleaseSelectTheVehicleAsync() =>
        PleaseSelectTheVehicle.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator VehicleType => EQVintageCycleLocators.VehicleType(_page);

    public Task PressVehicleTypeAsync(string key) => VehicleType.PressAsync(key);

    public Task DoubleClickVehicleTypeAsync() => VehicleType.DblClickAsync();

    public Task WaitForVehicleTypeAsync() =>
        VehicleType.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator Vintage => EQVintageCycleLocators.Vintage(_page);

    public Task PressVintageAsync(string key) => Vintage.PressAsync(key);

    public Task DoubleClickVintageAsync() => Vintage.DblClickAsync();

    public Task ClickVintageAsync() => Vintage.ClickAsync();

    private ILocator IsThisVehicleOwnedOrFinanced => EQVintageCycleLocators.IsThisVehicleOwnedOrFinanced(_page);

    public Task PressIsThisVehicleOwnedOrFinancedAsync(string key) => IsThisVehicleOwnedOrFinanced.PressAsync(key);

    public Task DoubleClickIsThisVehicleOwnedOrFinancedAsync() => IsThisVehicleOwnedOrFinanced.DblClickAsync();

    public Task WaitForIsThisVehicleOwnedOrFinancedAsync() =>
        IsThisVehicleOwnedOrFinanced.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator Loan => EQVintageCycleLocators.Loan(_page);

    public Task PressLoanAsync(string key) => Loan.PressAsync(key);

    public Task DoubleClickLoanAsync() => Loan.DblClickAsync();

    public Task ClickLoanAsync() => Loan.ClickAsync();

    private ILocator Leased => EQVintageCycleLocators.Leased(_page);

    public Task PressLeasedAsync(string key) => Leased.PressAsync(key);

    public Task DoubleClickLeasedAsync() => Leased.DblClickAsync();

    public Task ClickLeasedAsync() => Leased.ClickAsync();

    private ILocator Own => EQVintageCycleLocators.Own(_page);

    public Task PressOwnAsync(string key) => Own.PressAsync(key);

    public Task DoubleClickOwnAsync() => Own.DblClickAsync();

    public Task ClickOwnAsync() => Own.ClickAsync();

    private ILocator DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications => EQVintageCycleLocators.DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications(_page);

    public Task PressDoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModificationsAsync(string key) => DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications.PressAsync(key);

    public Task DoubleClickDoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModificationsAsync() => DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications.DblClickAsync();

    public Task WaitForDoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModificationsAsync() =>
        DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator No => EQVintageCycleLocators.No(_page);

    public Task PressNoAsync(string key) => No.PressAsync(key);

    public Task DoubleClickNoAsync() => No.DblClickAsync();

    public Task ClickNoAsync() => No.ClickAsync();

    private ILocator AgreedValue => EQVintageCycleLocators.AgreedValue(_page);

    public Task PressAgreedValueAsync(string key) => AgreedValue.PressAsync(key);

    public Task DoubleClickAgreedValueAsync() => AgreedValue.DblClickAsync();

    public Task SetAgreedValueAsync(string value) =>
        UiActions.ApplyInputAsync(_page, AgreedValue, _data.Resolve(value));

    public Task TypeAgreedValueAsync(string value, float delayMs = 40) =>
        AgreedValue.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator AppraisalDate => EQVintageCycleLocators.AppraisalDate(_page);

    public Task PressAppraisalDateAsync(string key) => AppraisalDate.PressAsync(key);

    public Task DoubleClickAppraisalDateAsync() => AppraisalDate.DblClickAsync();

    public Task SetAppraisalDateAsync(string value) =>
        UiActions.ApplyInputAsync(_page, AppraisalDate, _data.Resolve(value));

    public Task TypeAppraisalDateAsync(string value, float delayMs = 40) =>
        AppraisalDate.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator SaveAndContinue => EQVintageCycleLocators.SaveAndContinue(_page);

    public Task PressSaveAndContinueAsync(string key) => SaveAndContinue.PressAsync(key);

    public Task DoubleClickSaveAndContinueAsync() => SaveAndContinue.DblClickAsync();

    public Task ClickSaveAndContinueAsync() => SaveAndContinue.ClickAsync();

}
