using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQ1stCycle
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQ1stCycle(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator VIN => EQ1stCycleLocators.VIN(_page);

    public Task PressVINAsync(string key) => VIN.PressAsync(key);

    public Task DoubleClickVINAsync() => VIN.DblClickAsync();

    public Task SetVINAsync(string value) =>
        UiActions.ApplyInputAsync(_page, VIN, _data.Resolve(value));

    public Task TypeVINAsync(string value, float delayMs = 40) =>
        VIN.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task WaitForVINAsync() =>
        VIN.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator PleaseSelectTheVehicle => EQ1stCycleLocators.PleaseSelectTheVehicle(_page);

    public Task PressPleaseSelectTheVehicleAsync(string key) => PleaseSelectTheVehicle.PressAsync(key);

    public Task DoubleClickPleaseSelectTheVehicleAsync() => PleaseSelectTheVehicle.DblClickAsync();

    public Task WaitForPleaseSelectTheVehicleAsync() =>
        PleaseSelectTheVehicle.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator Cycle1 => EQ1stCycleLocators.Cycle1(_page);

    public Task PressCycle1Async(string key) => Cycle1.PressAsync(key);

    public Task DoubleClickCycle1Async() => Cycle1.DblClickAsync();

    public Task ClickCycle1Async() => Cycle1.ClickAsync();

    private ILocator PleasureUse => EQ1stCycleLocators.PleasureUse(_page);

    public Task PressPleasureUseAsync(string key) => PleasureUse.PressAsync(key);

    public Task DoubleClickPleasureUseAsync() => PleasureUse.DblClickAsync();

    public Task ClickPleasureUseAsync() => PleasureUse.ClickAsync();

    private ILocator NotPleasureUse => EQ1stCycleLocators.NotPleasureUse(_page);

    public Task PressNotPleasureUseAsync(string key) => NotPleasureUse.PressAsync(key);

    public Task DoubleClickNotPleasureUseAsync() => NotPleasureUse.DblClickAsync();

    public Task ClickNotPleasureUseAsync() => NotPleasureUse.ClickAsync();

    private ILocator UnderConstruction => EQ1stCycleLocators.UnderConstruction(_page);

    public Task PressUnderConstructionAsync(string key) => UnderConstruction.PressAsync(key);

    public Task DoubleClickUnderConstructionAsync() => UnderConstruction.DblClickAsync();

    public Task ClickUnderConstructionAsync() => UnderConstruction.ClickAsync();

    private ILocator Loan => EQ1stCycleLocators.Loan(_page);

    public Task PressLoanAsync(string key) => Loan.PressAsync(key);

    public Task DoubleClickLoanAsync() => Loan.DblClickAsync();

    public Task ClickLoanAsync() => Loan.ClickAsync();

    private ILocator Leased => EQ1stCycleLocators.Leased(_page);

    public Task PressLeasedAsync(string key) => Leased.PressAsync(key);

    public Task DoubleClickLeasedAsync() => Leased.DblClickAsync();

    public Task ClickLeasedAsync() => Leased.ClickAsync();

    private ILocator Own => EQ1stCycleLocators.Own(_page);

    public Task PressOwnAsync(string key) => Own.PressAsync(key);

    public Task DoubleClickOwnAsync() => Own.DblClickAsync();

    public Task ClickOwnAsync() => Own.ClickAsync();

    private ILocator NoRegisteredFedTribe => EQ1stCycleLocators.NoRegisteredFedTribe(_page);

    public Task PressNoRegisteredFedTribeAsync(string key) => NoRegisteredFedTribe.PressAsync(key);

    public Task DoubleClickNoRegisteredFedTribeAsync() => NoRegisteredFedTribe.DblClickAsync();

    public Task ClickNoRegisteredFedTribeAsync() => NoRegisteredFedTribe.ClickAsync();

    private ILocator DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications => EQ1stCycleLocators.DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications(_page);

    public Task PressDoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModificationsAsync(string key) => DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications.PressAsync(key);

    public Task DoubleClickDoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModificationsAsync() => DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications.DblClickAsync();

    public Task WaitForDoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModificationsAsync() =>
        DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator Yes => EQ1stCycleLocators.Yes(_page);

    public Task PressYesAsync(string key) => Yes.PressAsync(key);

    public Task DoubleClickYesAsync() => Yes.DblClickAsync();

    public Task ClickYesAsync() => Yes.ClickAsync();

    private ILocator No => EQ1stCycleLocators.No(_page);

    public Task PressNoAsync(string key) => No.PressAsync(key);

    public Task DoubleClickNoAsync() => No.DblClickAsync();

    public Task ClickNoAsync() => No.ClickAsync();

    private ILocator DescriptionOfMods => EQ1stCycleLocators.DescriptionOfMods(_page);

    public Task PressDescriptionOfModsAsync(string key) => DescriptionOfMods.PressAsync(key);

    public Task DoubleClickDescriptionOfModsAsync() => DescriptionOfMods.DblClickAsync();

    public Task SetDescriptionOfModsAsync(string value) =>
        UiActions.ApplyInputAsync(_page, DescriptionOfMods, _data.Resolve(value));

    public Task TypeDescriptionOfModsAsync(string value, float delayMs = 40) =>
        DescriptionOfMods.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator CurrentValue => EQ1stCycleLocators.CurrentValue(_page);

    public Task PressCurrentValueAsync(string key) => CurrentValue.PressAsync(key);

    public Task DoubleClickCurrentValueAsync() => CurrentValue.DblClickAsync();

    public Task SetCurrentValueAsync(string value) =>
        UiActions.ApplyInputAsync(_page, CurrentValue, _data.Resolve(value));

    public Task TypeCurrentValueAsync(string value, float delayMs = 40) =>
        CurrentValue.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator AnnualMileage => EQ1stCycleLocators.AnnualMileage(_page);

    public Task PressAnnualMileageAsync(string key) => AnnualMileage.PressAsync(key);

    public Task DoubleClickAnnualMileageAsync() => AnnualMileage.DblClickAsync();

    public Task SetAnnualMileageAsync(string value) =>
        UiActions.ApplyInputAsync(_page, AnnualMileage, _data.Resolve(value));

    public Task TypeAnnualMileageAsync(string value, float delayMs = 40) =>
        AnnualMileage.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator SaveAndContinue => EQ1stCycleLocators.SaveAndContinue(_page);

    public Task PressSaveAndContinueAsync(string key) => SaveAndContinue.PressAsync(key);

    public Task DoubleClickSaveAndContinueAsync() => SaveAndContinue.DblClickAsync();

    public Task ClickSaveAndContinueAsync() => SaveAndContinue.ClickAsync();

}
