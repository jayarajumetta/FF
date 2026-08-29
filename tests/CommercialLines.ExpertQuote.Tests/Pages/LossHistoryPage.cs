using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

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

    public Task ClickADDCLAIMAsync() =>
        _ui.ClickAsync(_locators.ADDCLAIM, new ControlIntent("LossHistory", "ADDCLAIM"));

    public Task WaitForAddANoteAsync(string expected) =>
        _ui.WaitAsync(_locators.AddANote, expected, new ControlIntent("LossHistory", "AddANote"));

    public Task PressAddANoteAsync(string key) =>
        _ui.PressAsync(_locators.AddANote, key, new ControlIntent("LossHistory", "AddANote"));

    public Task EnterAllLinkAsync(string value) =>
        _ui.FillAsync(_locators.AllLink, value, new ControlIntent("LossHistory", "AllLink"));

    public Task PressAmountPaidAsync(string key) =>
        _ui.PressAsync(_locators.AmountPaid, key, new ControlIntent("LossHistory", "AmountPaid"));

    public Task PressAmountReservedAsync(string key) =>
        _ui.PressAsync(_locators.AmountReserved, key, new ControlIntent("LossHistory", "AmountReserved"));

    public Task VerifyClaimSummaryTableRowCellExplicitNameAmountAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ClaimSummaryTableRowCellExplicitNameAmount, expected, property, new ControlIntent("LossHistory", "ClaimSummaryTableRowCellExplicitNameAmount"));

    public Task VerifyClaimSummaryTableRowCellExplicitNameCATClaimAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ClaimSummaryTableRowCellExplicitNameCATClaim, expected, property, new ControlIntent("LossHistory", "ClaimSummaryTableRowCellExplicitNameCATClaim"));

    public Task VerifyClaimSummaryTableRowCellExplicitNameClaimDateAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ClaimSummaryTableRowCellExplicitNameClaimDate, expected, property, new ControlIntent("LossHistory", "ClaimSummaryTableRowCellExplicitNameClaimDate"));

    public Task VerifyClaimSummaryTableRowCellExplicitNameLineOfCoverageAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ClaimSummaryTableRowCellExplicitNameLineOfCoverage, expected, property, new ControlIntent("LossHistory", "ClaimSummaryTableRowCellExplicitNameLineOfCoverage"));

    public Task VerifyClaimSummaryTableRowCellExplicitNameTypeOfLossAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ClaimSummaryTableRowCellExplicitNameTypeOfLoss, expected, property, new ControlIntent("LossHistory", "ClaimSummaryTableRowCellExplicitNameTypeOfLoss"));

    public Task PressDateOfOccurrenceAsync(string key) =>
        _ui.PressAsync(_locators.ADDCLAIM, key, new ControlIntent("LossHistory", "DateOfOccurrence"));

    public Task PressDescriptionOfOccurrenceOrClaimAsync(string key) =>
        _ui.PressAsync(_locators.DescriptionOfOccurrenceOrClaim, key, new ControlIntent("LossHistory", "DescriptionOfOccurrenceOrClaim"));

    public Task WaitForEChecklistEChecklistOKAsync(string expected) =>
        _ui.WaitAsync(_locators.EChecklistEChecklistOK, expected, new ControlIntent("LossHistory", "EChecklistEChecklistOK"));

    public Task ClickEChecklistEChecklistOKAsync() =>
        _ui.ClickAsync(_locators.EChecklistEChecklistOK, new ControlIntent("LossHistory", "EChecklistEChecklistOK"));

    public Task ClickExceptionAsync() =>
        _ui.ClickAsync(_locators.Exception, new ControlIntent("LossHistory", "Exception"));

    public Task PressExpenseAmountAsync(string key) =>
        _ui.PressAsync(_locators.ExpenseAmount, key, new ControlIntent("LossHistory", "ExpenseAmount"));
public Task WaitForLossRuns3YearsHeaderAsync(string expected) =>
        _ui.WaitAsync(_locators.LossRuns3YearsHeader, expected, new ControlIntent("LossHistory", "LossRuns3YearsHeader"));

    public Task WaitForLossRunsHeaderAsync(string expected) =>
        _ui.WaitAsync(_locators.LossRuns3YearsHeader, expected, new ControlIntent("LossHistory", "LossRunsHeader"));

    public Task PressN3YearsAsync(string key) =>
        _ui.PressAsync(_locators.N3Years, key, new ControlIntent("LossHistory", "N3Years"));

    public Task ClickN3YearsAsync() =>
        _ui.ClickAsync(_locators.N3Years, new ControlIntent("LossHistory", "N3Years"));

    public Task ClickOpenButtonAsync() =>
        _ui.ClickAsync(_locators.OpenButton, new ControlIntent("LossHistory", "OpenButton"));

    public Task PressPolicyExpireAsync(string key) =>
        _ui.PressAsync(_locators.PolicyExpire, key, new ControlIntent("LossHistory", "PolicyExpire"));

    public Task PressPolicyStartAsync(string key) =>
        _ui.PressAsync(_locators.PolicyStart, key, new ControlIntent("LossHistory", "PolicyStart"));

    public Task PressPriorInsuranceLatestCarrierAsync(string key) =>
        _ui.PressAsync(_locators.PriorInsuranceLatestCarrier, key, new ControlIntent("LossHistory", "PriorInsuranceLatestCarrier"));

    public Task PressPriorInsuranceLatestExpirationDateAsync(string key) =>
        _ui.PressAsync(_locators.PriorInsuranceLatestExpirationDate, key, new ControlIntent("LossHistory", "PriorInsuranceLatestExpirationDate"));

    public Task SelectPriorPolicyNoAsync(string value) =>
        _ui.SelectAsync(_locators.PriorPolicyNo, value, new ControlIntent("LossHistory", "PriorPolicyNo"));

    public Task ClickPriorPolicyNoAsync() =>
        _ui.ClickAsync(_locators.PriorPolicyNo, new ControlIntent("LossHistory", "PriorPolicyNo"));

    public Task ClickSaveAsync() =>
        _ui.ClickAsync(_locators.Save, new ControlIntent("LossHistory", "Save"));

    public Task VerifyScreenHeadingAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.NoPrefillMatchFound, expected, property, new ControlIntent("LossHistory", "ScreenHeading"));

    public Task<bool> IsScreenHeadingPresentAsync() =>
        _ui.ExistsAsync(_locators.NoPrefillMatchFound);

    public Task PressTypeOfLossDropdownAsync(string key) =>
        _ui.PressAsync(_locators.TypeOfLossDropdown, key, new ControlIntent("LossHistory", "TypeOfLossDropdown"));

    public Task ClickTypeOfLossSelectionAsync() =>
        _ui.ClickAsync(_locators.ADDCLAIM, new ControlIntent("LossHistory", "TypeOfLossSelection"));

    public Task PressYearsInBusinessAsync(string key) =>
        _ui.PressAsync(_locators.YearsInBusiness, key, new ControlIntent("LossHistory", "YearsInBusiness"));

}
