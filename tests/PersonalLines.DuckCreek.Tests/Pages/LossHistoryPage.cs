using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class LossHistoryPage
{
    private readonly BrowserSession _browser;
    private readonly LossHistoryLocators _locators;
    private readonly UiActions _ui;

    public LossHistoryPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new LossHistoryLocators(browser.Page);
        _ui = ui;
    }

    public Task VerifyCONTINUEDoesnTApplyAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.CONTINUEDoesnTApply, expected, property, new ControlIntent("LossHistory", "CONTINUEDoesnTApply"));

    public Task ClickCONTINUEDoesnTApplyAsync() =>
        _ui.ClickAsync(_locators.CONTINUEDoesnTApply, new ControlIntent("LossHistory", "CONTINUEDoesnTApply"));

    public Task<bool> IsCONTINUEDoesnTApplyPresentAsync() =>
        _ui.ExistsAsync(_locators.CONTINUEDoesnTApply);

    public Task VerifyClaimDriverNotInHouseholdAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ClaimDriverNotInHousehold, expected, property, new ControlIntent("LossHistory", "ClaimDriverNotInHousehold"));

    public Task PressClaimDriverNotInHouseholdAsync(string key) =>
        _ui.PressAsync(_locators.ClaimDriverNotInHousehold, key, new ControlIntent("LossHistory", "ClaimDriverNotInHousehold"));

    public Task ClickClaimDriverNotInHouseholdAsync() =>
        _ui.ClickAsync(_locators.ClaimDriverNotInHousehold, new ControlIntent("LossHistory", "ClaimDriverNotInHousehold"));

    public Task<bool> IsClaimDriverNotInHouseholdPresentAsync() =>
        _ui.ExistsAsync(_locators.ClaimDriverNotInHousehold);

    public Task SelectClaimVehicleLoanedToDriverThatDoesNotDidNotResideInHouseholdAndHasNoAccessToVehicleSInsuredByAmericanNationalAsync(string value) =>
        _ui.SelectAsync(_locators.ClaimVehicleLoanedToDriverThatDoesNotDidNotResideInHouseholdAndHasNoAccessToVehicleSInsuredByAmericanNational, value, new ControlIntent("LossHistory", "ClaimVehicleLoanedToDriverThatDoesNotDidNotResideInHouseholdAndHasNoAccessToVehicleSInsuredByAmericanNational"));

    public Task SelectClaimViolationDoesNotApplyAsync(string value) =>
        _ui.SelectAsync(_locators.ClaimViolationDoesNotApply, value, new ControlIntent("LossHistory", "ClaimViolationDoesNotApply"));

    public Task ClickClaimViolationSaveAndContinueAsync() =>
        _ui.ClickAsync(_locators.ClaimViolationSaveAndContinue, new ControlIntent("LossHistory", "ClaimViolationSaveAndContinue"));

    public Task ClickClaimsViolationNEWNextAsync() =>
        _ui.ClickAsync(_locators.ClaimsViolationNEWNext, new ControlIntent("LossHistory", "ClaimsViolationNEWNext"));

    public Task EnterComboBoxAsync(string value) =>
        _ui.FillAsync(_locators.ComboBox, value, new ControlIntent("LossHistory", "ComboBox"));

    public Task<bool> IsComboBoxPresentAsync() =>
        _ui.ExistsAsync(_locators.ComboBox);

    public Task WaitForEditClaimAsync(string expected) =>
        _ui.WaitAsync(_locators.EditClaim, expected, new ControlIntent("LossHistory", "EditClaim"));

    public Task ClickEditClaimAsync() =>
        _ui.ClickAsync(_locators.EditClaim, new ControlIntent("LossHistory", "EditClaim"));

    public Task<bool> IsEditClaimPresentAsync() =>
        _ui.ExistsAsync(_locators.EditClaim);
public Task WaitForUWCONTINUEAsync(string expected) =>
        _ui.WaitAsync(_locators.UWCONTINUE, expected, new ControlIntent("LossHistory", "UWCONTINUE"));

    public Task VerifyUWCONTINUEAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.UWCONTINUE, expected, property, new ControlIntent("LossHistory", "UWCONTINUE"));

    public Task ClickUWCONTINUEAsync() =>
        _ui.ClickAsync(_locators.UWCONTINUE, new ControlIntent("LossHistory", "UWCONTINUE"));

    public Task<bool> IsUWCONTINUEPresentAsync() =>
        _ui.ExistsAsync(_locators.UWCONTINUE);

}
