using InsuranceAutomation.Core;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class LossHistoryPage
{
    private readonly LossHistoryLocators _locators;
    private readonly ScenarioData _data;
    private readonly UiActions _ui;

    public LossHistoryPage(BrowserSession browser, ScenarioData data, UiActions ui)
    {
        _locators = new LossHistoryLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I complete claims/Violations
    public async Task CompleteClaimsViolationsAsync()
    {
        // EQClaimsViolations_173f1bPage.EQClaimsViolations_0094_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.UWCONTINUE))
        {
            await _ui.WaitAsync(_locators.UWCONTINUE, "Exists");
        }
        await _ui.VerifyAsync(_locators.UWCONTINUE, _data.Resolve("Exists"), "");
        // EQClaimsViolations_173f1bPage.EQClaimsViolations_0095_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.UWCONTINUE))
        {
            await _ui.ClickAsync(_locators.UWCONTINUE);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0096_8f9ff6Async
        _data.Set("ClaimCount", _data.Resolve("{{data:claimcount}}"));
    }

    // Business step: I complete editClaimsViolations
    public async Task CompleteEditClaimsViolationsAsync()
    {
        // EQClaimsViolationNEW_1ca575Page.CheckForClaimsViolationsNeedingEdited_0097_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.EditClaim))
        {
            await _ui.WaitAsync(_locators.EditClaim, "Exists");
        }
        // EQClaimsViolationNEW_1ca575Page.EditItemS_0098_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.EditClaim))
        {
            await _ui.ClickAsync(_locators.EditClaim);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0099_8f9ff6Async
        if (_data.Condition("While Edits Needed [max=30] > Loop"))
        {
            _data.Set("ClaimCount", _data.Resolve("{MATH[{B[ClaimCount]}+1]}"));
        }
        // EQClaimsViolationNEW_1ca575Page.IfClaim_0100_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.ClaimDriverNotInHousehold))
        {
            await _ui.VerifyAsync(_locators.ClaimDriverNotInHousehold, _data.Resolve("Exists"), "");
        }
        // EQClaimsViolationNEW_1ca575Page.EditClaim_0101_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.ClaimDriverNotInHousehold))
        {
            await _ui.ClickAsync(_locators.ClaimDriverNotInHousehold);
            await _ui.PressAsync(_locators.ClaimDriverNotInHousehold, "End");
            await _ui.PressAsync(_locators.ClaimDriverNotInHousehold, "Click");
        }
        await _ui.SelectAsync(_locators.ClaimVehicleLoanedToDriverThatDoesNotDidNotResideInHouseholdAndHasNoAccessToVehicleSInsuredByAmericanNational, _data.Resolve(""));
        await _ui.ClickAsync(_locators.ClaimViolationSaveAndContinue);
        // EQClaimsViolationNEW_1ca575Page.EditViolation_0102_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.ComboBox))
        {
            await _ui.FillAsync(_locators.ComboBox, _data.Resolve("{{data:combobox_278}}"));
        }
        await _ui.SelectAsync(_locators.ClaimViolationDoesNotApply, _data.Resolve(""));
        await _ui.ClickAsync(_locators.ClaimViolationSaveAndContinue);
        // EQClaimsViolationNEW_1ca575Page.CheckForPopUp_0103_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.CONTINUEDoesnTApply))
        {
            await _ui.VerifyAsync(_locators.CONTINUEDoesnTApply, _data.Resolve("Exists"), "");
        }
        // EQClaimsViolationNEW_1ca575Page.SelectContinue_0104_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.CONTINUEDoesnTApply))
        {
            await _ui.ClickAsync(_locators.CONTINUEDoesnTApply);
        }
        // EQClaimsViolationNEW_1ca575Page.Next_0105_8f9ff6Async
        await _ui.ClickAsync(_locators.ClaimsViolationNEWNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0106_8f9ff6Async
        await _ui.WaitAsync(_locators.Loading, "Exists");
    }

    // Business step: I complete claims/Violations
    public async Task CompleteClaimsViolationsAsync2()
    {
        // EQClaimsViolations_173f1bPage.EQClaimsViolations_0106_8f5301Async
        if (await _ui.ExistsAsync(_locators.UWCONTINUE))
        {
            await _ui.WaitAsync(_locators.UWCONTINUE, "Exists");
        }
        await _ui.VerifyAsync(_locators.UWCONTINUE, _data.Resolve("Exists"), "");
        // EQClaimsViolations_173f1bPage.EQClaimsViolations_0107_8f5301Async
        if (await _ui.ExistsAsync(_locators.UWCONTINUE))
        {
            await _ui.ClickAsync(_locators.UWCONTINUE);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0108_8f5301Async
        _data.Set("ClaimCount", _data.Resolve("{{data:claimcount}}"));
    }

    // Business step: I complete editClaimsViolations
    public async Task CompleteEditClaimsViolationsAsync2()
    {
        // EQClaimsViolationNEW_1ca575Page.CheckForClaimsViolationsNeedingEdited_0109_8f5301Async
        if (await _ui.ExistsAsync(_locators.EditClaim))
        {
            await _ui.WaitAsync(_locators.EditClaim, "Exists");
        }
        // EQClaimsViolationNEW_1ca575Page.EditItemS_0110_8f5301Async
        if (await _ui.ExistsAsync(_locators.EditClaim))
        {
            await _ui.ClickAsync(_locators.EditClaim);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0111_8f5301Async
        if (_data.Condition("While Edits Needed [max=30] > Loop"))
        {
            _data.Set("ClaimCount", _data.Resolve("{MATH[{B[ClaimCount]}+1]}"));
        }
        // EQClaimsViolationNEW_1ca575Page.IfClaim_0112_8f5301Async
        if (await _ui.ExistsAsync(_locators.ClaimDriverNotInHousehold))
        {
            await _ui.VerifyAsync(_locators.ClaimDriverNotInHousehold, _data.Resolve("Exists"), "");
        }
        // EQClaimsViolationNEW_1ca575Page.EditClaim_0113_8f5301Async
        if (await _ui.ExistsAsync(_locators.ClaimDriverNotInHousehold))
        {
            await _ui.ClickAsync(_locators.ClaimDriverNotInHousehold);
            await _ui.PressAsync(_locators.ClaimDriverNotInHousehold, "End");
            await _ui.PressAsync(_locators.ClaimDriverNotInHousehold, "Click");
        }
        await _ui.SelectAsync(_locators.ClaimVehicleLoanedToDriverThatDoesNotDidNotResideInHouseholdAndHasNoAccessToVehicleSInsuredByAmericanNational, _data.Resolve(""));
        await _ui.ClickAsync(_locators.ClaimViolationSaveAndContinue);
        // EQClaimsViolationNEW_1ca575Page.EditViolation_0114_8f5301Async
        if (await _ui.ExistsAsync(_locators.ComboBox))
        {
            await _ui.FillAsync(_locators.ComboBox, _data.Resolve("{{data:combobox_329}}"));
        }
        await _ui.SelectAsync(_locators.ClaimViolationDoesNotApply, _data.Resolve(""));
        await _ui.ClickAsync(_locators.ClaimViolationSaveAndContinue);
        // EQClaimsViolationNEW_1ca575Page.CheckForPopUp_0115_8f5301Async
        if (await _ui.ExistsAsync(_locators.CONTINUEDoesnTApply))
        {
            await _ui.VerifyAsync(_locators.CONTINUEDoesnTApply, _data.Resolve("Exists"), "");
        }
        // EQClaimsViolationNEW_1ca575Page.SelectContinue_0116_8f5301Async
        if (await _ui.ExistsAsync(_locators.CONTINUEDoesnTApply))
        {
            await _ui.ClickAsync(_locators.CONTINUEDoesnTApply);
        }
        // EQClaimsViolationNEW_1ca575Page.Next_0117_8f5301Async
        await _ui.ClickAsync(_locators.ClaimsViolationNEWNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0118_8f5301Async
        await _ui.WaitAsync(_locators.Loading, "Exists");
    }

    // Business step: I complete claims/Violations
    public async Task CompleteClaimsViolationsAsync3()
    {
        // EQClaimsViolations_173f1bPage.EQClaimsViolations_0103_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.UWCONTINUE))
        {
            await _ui.WaitAsync(_locators.UWCONTINUE, "Exists");
        }
        await _ui.VerifyAsync(_locators.UWCONTINUE, _data.Resolve("Exists"), "");
        // EQClaimsViolations_173f1bPage.EQClaimsViolations_0104_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.UWCONTINUE))
        {
            await _ui.ClickAsync(_locators.UWCONTINUE);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0105_e2e0d7Async
        _data.Set("ClaimCount", _data.Resolve("{{data:claimcount}}"));
    }

    // Business step: I complete editClaimsViolations
    public async Task CompleteEditClaimsViolationsAsync3()
    {
        // EQClaimsViolationNEW_1ca575Page.CheckForClaimsViolationsNeedingEdited_0106_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.EditClaim))
        {
            await _ui.WaitAsync(_locators.EditClaim, "Exists");
        }
        // EQClaimsViolationNEW_1ca575Page.EditItemS_0107_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.EditClaim))
        {
            await _ui.ClickAsync(_locators.EditClaim);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0108_e2e0d7Async
        if (_data.Condition("While Edits Needed [max=30] > Loop"))
        {
            _data.Set("ClaimCount", _data.Resolve("{MATH[{B[ClaimCount]}+1]}"));
        }
        // EQClaimsViolationNEW_1ca575Page.IfClaim_0109_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.ClaimDriverNotInHousehold))
        {
            await _ui.VerifyAsync(_locators.ClaimDriverNotInHousehold, _data.Resolve("Exists"), "");
        }
        // EQClaimsViolationNEW_1ca575Page.EditClaim_0110_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.ClaimDriverNotInHousehold))
        {
            await _ui.ClickAsync(_locators.ClaimDriverNotInHousehold);
            await _ui.PressAsync(_locators.ClaimDriverNotInHousehold, "End");
            await _ui.PressAsync(_locators.ClaimDriverNotInHousehold, "Click");
        }
        await _ui.SelectAsync(_locators.ClaimVehicleLoanedToDriverThatDoesNotDidNotResideInHouseholdAndHasNoAccessToVehicleSInsuredByAmericanNational, _data.Resolve(""));
        await _ui.ClickAsync(_locators.ClaimViolationSaveAndContinue);
        // EQClaimsViolationNEW_1ca575Page.EditViolation_0111_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.ComboBox))
        {
            await _ui.FillAsync(_locators.ComboBox, _data.Resolve("{{data:combobox_312}}"));
        }
        await _ui.SelectAsync(_locators.ClaimViolationDoesNotApply, _data.Resolve(""));
        await _ui.ClickAsync(_locators.ClaimViolationSaveAndContinue);
        // EQClaimsViolationNEW_1ca575Page.CheckForPopUp_0112_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.CONTINUEDoesnTApply))
        {
            await _ui.VerifyAsync(_locators.CONTINUEDoesnTApply, _data.Resolve("Exists"), "");
        }
        // EQClaimsViolationNEW_1ca575Page.SelectContinue_0113_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.CONTINUEDoesnTApply))
        {
            await _ui.ClickAsync(_locators.CONTINUEDoesnTApply);
        }
        // EQClaimsViolationNEW_1ca575Page.Next_0114_e2e0d7Async
        await _ui.ClickAsync(_locators.ClaimsViolationNEWNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0115_e2e0d7Async
        await _ui.WaitAsync(_locators.Loading, "Exists");
    }

    // Business step: I complete claims/Violations
    public async Task CompleteClaimsViolationsAsync4()
    {
        // EQClaimsViolations_173f1bPage.EQClaimsViolations_0103_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.UWCONTINUE))
        {
            await _ui.WaitAsync(_locators.UWCONTINUE, "Exists");
        }
        await _ui.VerifyAsync(_locators.UWCONTINUE, _data.Resolve("Exists"), "");
        // EQClaimsViolations_173f1bPage.EQClaimsViolations_0104_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.UWCONTINUE))
        {
            await _ui.ClickAsync(_locators.UWCONTINUE);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0105_bafd4aAsync
        _data.Set("ClaimCount", _data.Resolve("{{data:claimcount}}"));
    }

    // Business step: I complete editClaimsViolations
    public async Task CompleteEditClaimsViolationsAsync4()
    {
        // EQClaimsViolationNEW_1ca575Page.CheckForClaimsViolationsNeedingEdited_0106_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.EditClaim))
        {
            await _ui.WaitAsync(_locators.EditClaim, "Exists");
        }
        // EQClaimsViolationNEW_1ca575Page.EditItemS_0107_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.EditClaim))
        {
            await _ui.ClickAsync(_locators.EditClaim);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0108_bafd4aAsync
        if (_data.Condition("While Edits Needed [max=30] > Loop"))
        {
            _data.Set("ClaimCount", _data.Resolve("{MATH[{B[ClaimCount]}+1]}"));
        }
        // EQClaimsViolationNEW_1ca575Page.IfClaim_0109_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.ClaimDriverNotInHousehold))
        {
            await _ui.VerifyAsync(_locators.ClaimDriverNotInHousehold, _data.Resolve("Exists"), "");
        }
        // EQClaimsViolationNEW_1ca575Page.EditClaim_0110_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.ClaimDriverNotInHousehold))
        {
            await _ui.ClickAsync(_locators.ClaimDriverNotInHousehold);
            await _ui.PressAsync(_locators.ClaimDriverNotInHousehold, "End");
            await _ui.PressAsync(_locators.ClaimDriverNotInHousehold, "Click");
        }
        await _ui.SelectAsync(_locators.ClaimVehicleLoanedToDriverThatDoesNotDidNotResideInHouseholdAndHasNoAccessToVehicleSInsuredByAmericanNational, _data.Resolve(""));
        await _ui.ClickAsync(_locators.ClaimViolationSaveAndContinue);
        // EQClaimsViolationNEW_1ca575Page.EditViolation_0111_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.ComboBox))
        {
            await _ui.FillAsync(_locators.ComboBox, _data.Resolve("{{data:combobox_312}}"));
        }
        await _ui.SelectAsync(_locators.ClaimViolationDoesNotApply, _data.Resolve(""));
        await _ui.ClickAsync(_locators.ClaimViolationSaveAndContinue);
        // EQClaimsViolationNEW_1ca575Page.CheckForPopUp_0112_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.CONTINUEDoesnTApply))
        {
            await _ui.VerifyAsync(_locators.CONTINUEDoesnTApply, _data.Resolve("Exists"), "");
        }
        // EQClaimsViolationNEW_1ca575Page.SelectContinue_0113_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.CONTINUEDoesnTApply))
        {
            await _ui.ClickAsync(_locators.CONTINUEDoesnTApply);
        }
        // EQClaimsViolationNEW_1ca575Page.Next_0114_bafd4aAsync
        await _ui.ClickAsync(_locators.ClaimsViolationNEWNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0115_bafd4aAsync
        await _ui.WaitAsync(_locators.Loading, "Exists");
    }

    // Business step: I complete claims/Violations
    public async Task CompleteClaimsViolationsAsync5()
    {
        // EQClaimsViolations_173f1bPage.EQClaimsViolations_0106_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.UWCONTINUE))
        {
            await _ui.WaitAsync(_locators.UWCONTINUE, "Exists");
        }
        await _ui.VerifyAsync(_locators.UWCONTINUE, _data.Resolve("Exists"), "");
        // EQClaimsViolations_173f1bPage.EQClaimsViolations_0107_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.UWCONTINUE))
        {
            await _ui.ClickAsync(_locators.UWCONTINUE);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0108_8f4c8fAsync
        _data.Set("ClaimCount", _data.Resolve("{{data:claimcount}}"));
    }

    // Business step: I complete editClaimsViolations
    public async Task CompleteEditClaimsViolationsAsync5()
    {
        // EQClaimsViolationNEW_1ca575Page.CheckForClaimsViolationsNeedingEdited_0109_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.EditClaim))
        {
            await _ui.WaitAsync(_locators.EditClaim, "Exists");
        }
        // EQClaimsViolationNEW_1ca575Page.EditItemS_0110_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.EditClaim))
        {
            await _ui.ClickAsync(_locators.EditClaim);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0111_8f4c8fAsync
        if (_data.Condition("While Edits Needed [max=30] > Loop"))
        {
            _data.Set("ClaimCount", _data.Resolve("{MATH[{B[ClaimCount]}+1]}"));
        }
        // EQClaimsViolationNEW_1ca575Page.IfClaim_0112_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.ClaimDriverNotInHousehold))
        {
            await _ui.VerifyAsync(_locators.ClaimDriverNotInHousehold, _data.Resolve("Exists"), "");
        }
        // EQClaimsViolationNEW_1ca575Page.EditClaim_0113_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.ClaimDriverNotInHousehold))
        {
            await _ui.ClickAsync(_locators.ClaimDriverNotInHousehold);
            await _ui.PressAsync(_locators.ClaimDriverNotInHousehold, "End");
            await _ui.PressAsync(_locators.ClaimDriverNotInHousehold, "Click");
        }
        await _ui.SelectAsync(_locators.ClaimVehicleLoanedToDriverThatDoesNotDidNotResideInHouseholdAndHasNoAccessToVehicleSInsuredByAmericanNational, _data.Resolve(""));
        await _ui.ClickAsync(_locators.ClaimViolationSaveAndContinue);
        // EQClaimsViolationNEW_1ca575Page.EditViolation_0114_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.ComboBox))
        {
            await _ui.FillAsync(_locators.ComboBox, _data.Resolve("{{data:combobox_329}}"));
        }
        await _ui.SelectAsync(_locators.ClaimViolationDoesNotApply, _data.Resolve(""));
        await _ui.ClickAsync(_locators.ClaimViolationSaveAndContinue);
        // EQClaimsViolationNEW_1ca575Page.CheckForPopUp_0115_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.CONTINUEDoesnTApply))
        {
            await _ui.VerifyAsync(_locators.CONTINUEDoesnTApply, _data.Resolve("Exists"), "");
        }
        // EQClaimsViolationNEW_1ca575Page.SelectContinue_0116_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.CONTINUEDoesnTApply))
        {
            await _ui.ClickAsync(_locators.CONTINUEDoesnTApply);
        }
        // EQClaimsViolationNEW_1ca575Page.Next_0117_8f4c8fAsync
        await _ui.ClickAsync(_locators.ClaimsViolationNEWNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0118_8f4c8fAsync
        await _ui.WaitAsync(_locators.Loading, "Exists");
    }

    // Business step: I complete claims/Violations
    public async Task CompleteClaimsViolationsAsync6()
    {
        // EQClaimsViolations_173f1bPage.EQClaimsViolations_0106_10f911Async
        if (await _ui.ExistsAsync(_locators.UWCONTINUE))
        {
            await _ui.WaitAsync(_locators.UWCONTINUE, "Exists");
        }
        await _ui.VerifyAsync(_locators.UWCONTINUE, _data.Resolve("Exists"), "");
        // EQClaimsViolations_173f1bPage.EQClaimsViolations_0107_10f911Async
        if (await _ui.ExistsAsync(_locators.UWCONTINUE))
        {
            await _ui.ClickAsync(_locators.UWCONTINUE);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0108_10f911Async
        _data.Set("ClaimCount", _data.Resolve("{{data:claimcount}}"));
    }

    // Business step: I complete editClaimsViolations
    public async Task CompleteEditClaimsViolationsAsync6()
    {
        // EQClaimsViolationNEW_1ca575Page.CheckForClaimsViolationsNeedingEdited_0109_10f911Async
        if (await _ui.ExistsAsync(_locators.EditClaim))
        {
            await _ui.WaitAsync(_locators.EditClaim, "Exists");
        }
        // EQClaimsViolationNEW_1ca575Page.EditItemS_0110_10f911Async
        if (await _ui.ExistsAsync(_locators.EditClaim))
        {
            await _ui.ClickAsync(_locators.EditClaim);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0111_10f911Async
        if (_data.Condition("While Edits Needed [max=30] > Loop"))
        {
            _data.Set("ClaimCount", _data.Resolve("{MATH[{B[ClaimCount]}+1]}"));
        }
        // EQClaimsViolationNEW_1ca575Page.IfClaim_0112_10f911Async
        if (await _ui.ExistsAsync(_locators.ClaimDriverNotInHousehold))
        {
            await _ui.VerifyAsync(_locators.ClaimDriverNotInHousehold, _data.Resolve("Exists"), "");
        }
        // EQClaimsViolationNEW_1ca575Page.EditClaim_0113_10f911Async
        if (await _ui.ExistsAsync(_locators.ClaimDriverNotInHousehold))
        {
            await _ui.ClickAsync(_locators.ClaimDriverNotInHousehold);
            await _ui.PressAsync(_locators.ClaimDriverNotInHousehold, "End");
            await _ui.PressAsync(_locators.ClaimDriverNotInHousehold, "Click");
        }
        await _ui.SelectAsync(_locators.ClaimVehicleLoanedToDriverThatDoesNotDidNotResideInHouseholdAndHasNoAccessToVehicleSInsuredByAmericanNational, _data.Resolve(""));
        await _ui.ClickAsync(_locators.ClaimViolationSaveAndContinue);
        // EQClaimsViolationNEW_1ca575Page.EditViolation_0114_10f911Async
        if (await _ui.ExistsAsync(_locators.ComboBox))
        {
            await _ui.FillAsync(_locators.ComboBox, _data.Resolve("{{data:combobox_332}}"));
        }
        await _ui.SelectAsync(_locators.ClaimViolationDoesNotApply, _data.Resolve(""));
        await _ui.ClickAsync(_locators.ClaimViolationSaveAndContinue);
        // EQClaimsViolationNEW_1ca575Page.CheckForPopUp_0115_10f911Async
        if (await _ui.ExistsAsync(_locators.CONTINUEDoesnTApply))
        {
            await _ui.VerifyAsync(_locators.CONTINUEDoesnTApply, _data.Resolve("Exists"), "");
        }
        // EQClaimsViolationNEW_1ca575Page.SelectContinue_0116_10f911Async
        if (await _ui.ExistsAsync(_locators.CONTINUEDoesnTApply))
        {
            await _ui.ClickAsync(_locators.CONTINUEDoesnTApply);
        }
        // EQClaimsViolationNEW_1ca575Page.Next_0117_10f911Async
        await _ui.ClickAsync(_locators.ClaimsViolationNEWNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0118_10f911Async
        await _ui.WaitAsync(_locators.Loading, "Exists");
    }

}
