using InsuranceAutomation.Core;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

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

    // Business step: I enter Required
    public async Task EnterRequiredAsync()
    {
        // CLEQSFPPriorClaimsEnterRequired_faf113Page.EQPriorCarrierClaimsEnterRequiredInfo_0124_503012Async
        await _ui.ClickAsync(_locators.PriorPolicyNo);
        // CLEQSFPPriorClaimsEnterRequired_faf113Page.EQLoadingIndicatorWait_0125_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPPriorClaimsEnterRequired_faf113Page.EQPriorCarrierClaimsClick3_0126_503012Async
        await _ui.PressAsync(_locators.YearsInBusiness, "POST:ENTER");
        await _ui.PressAsync(_locators.YearsInBusiness, "Enter");
        await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        await _ui.ClickAsync(_locators.N3Years);
        await _ui.PressAsync(_locators.N3Years, "POST:TAB");
        await _ui.PressAsync(_locators.N3Years, "Tab");
        // CLEQSFPPriorClaimsEnterRequired_faf113Page.EQLoadingIndicatorWait_0127_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPPriorClaimsEnterRequired_faf113Page.EQPriorCarrierClaimsEnterLatestExpiration_0128_503012Async
        await _ui.PressAsync(_locators.PriorInsuranceLatestExpirationDate, "POST:ENTER");
        await _ui.PressAsync(_locators.PriorInsuranceLatestExpirationDate, "Enter");
        await _ui.PressAsync(_locators.PriorInsuranceLatestExpirationDate, "Tab");
        // CLEQSFPPriorClaimsEnterRequired_faf113Page.EQLoadingIndicatorWait_0129_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPPriorClaimsEnterRequired_faf113Page.EQPriorCarrierClaimsEnterLatestCarrier_0130_503012Async
        await _ui.PressAsync(_locators.PriorInsuranceLatestCarrier, "POST:ENTER");
        await _ui.PressAsync(_locators.PriorInsuranceLatestCarrier, "Enter");
        await _ui.PressAsync(_locators.PriorInsuranceLatestCarrier, "Tab");
    }

    // Business step: I enter Required
    public async Task EnterRequiredAsync2()
    {
        // EQBOPPriorClaimsEnterRequired_b29b5bPage.EQPriorCarrierClaimsEnterRequiredInfo_0113_d18a3eAsync
        await _ui.SelectAsync(_locators.PriorPolicyNo, _data.Resolve(""));
        // EQBOPPriorClaimsEnterRequired_b29b5bPage.EQLoadingIndicatorWait_0114_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPPriorClaimsEnterRequired_b29b5bPage.EQPriorCarrierClaimsEnterRequiredInfo_0115_d18a3eAsync
        await _ui.PressAsync(_locators.YearsInBusiness, "POST:ENTER");
        await _ui.PressAsync(_locators.YearsInBusiness, "Enter");
        await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        // EQBOPPriorClaimsEnterRequired_b29b5bPage.EQLoadingIndicatorWait_0116_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPPriorClaimsEnterRequired_b29b5bPage.EQPriorCarrierClaimsClick3_0117_d18a3eAsync
        await _ui.ClickAsync(_locators.N3Years);
        await _ui.PressAsync(_locators.N3Years, "POST:TAB");
        await _ui.PressAsync(_locators.N3Years, "Tab");
        // EQBOPPriorClaimsEnterRequired_b29b5bPage.EQLoadingIndicatorWait_0118_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPPriorClaimsEnterRequired_b29b5bPage.EQPriorCarrierClaimsEnterLatestExpiration_0119_d18a3eAsync
        await _ui.PressAsync(_locators.PriorInsuranceLatestExpirationDate, "POST:ENTER");
        await _ui.PressAsync(_locators.PriorInsuranceLatestExpirationDate, "Enter");
        await _ui.PressAsync(_locators.PriorInsuranceLatestExpirationDate, "Tab");
        // EQBOPPriorClaimsEnterRequired_b29b5bPage.EQLoadingIndicatorWait_0120_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPPriorClaimsEnterRequired_b29b5bPage.EQPriorCarrierClaimsEnterLatestCarrier_0121_d18a3eAsync
        await _ui.PressAsync(_locators.PriorInsuranceLatestCarrier, "POST:ENTER");
        await _ui.PressAsync(_locators.PriorInsuranceLatestCarrier, "Enter");
        await _ui.PressAsync(_locators.PriorInsuranceLatestCarrier, "Tab");
        // EQBOPClaimsPriorInsuranceAddVerifyDeleteClaims_574436Page.TBoxSetBuffer_0122_d18a3eAsync
        _data.Set("Type of Loss", _data.Resolve("{{data:type_of_loss}}"));
    }

    // Business step: I add/Verify/Delete Claims
    public async Task AddVerifyDeleteClaimsAsync()
    {
        // EQBOPClaimsPriorInsuranceAddVerifyDeleteClaims_574436Page.EQBOPClaimsPriorInsuranceAddClaimsDateOfOccurence_0123_d18a3eAsync
        await _ui.ClickAsync(_locators.ADDCLAIM);
        await _ui.PressAsync(_locators.DateOfOccurrence, "POST:CTRL+A");
        await _ui.PressAsync(_locators.DateOfOccurrence, "CTRL+A");
        await _ui.PressAsync(_locators.DateOfOccurrence, "Enter");
        await _ui.PressAsync(_locators.DateOfOccurrence, "Tab");
        // EQBOPClaimsPriorInsuranceAddVerifyDeleteClaims_574436Page.EQLoadingIndicatorWait_0124_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPClaimsPriorInsuranceAddVerifyDeleteClaims_574436Page.EQBOPClaimsPriorInsuranceAddClaimsPolicyStart_0125_d18a3eAsync
        await _ui.PressAsync(_locators.PolicyStart, "POST:CTRL+A");
        await _ui.PressAsync(_locators.PolicyStart, "CTRL+A");
        await _ui.PressAsync(_locators.PolicyStart, "Enter");
        await _ui.PressAsync(_locators.PolicyStart, "Tab");
        // EQBOPClaimsPriorInsuranceAddVerifyDeleteClaims_574436Page.EQLoadingIndicatorWait_0126_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPClaimsPriorInsuranceAddVerifyDeleteClaims_574436Page.EQBOPClaimsPriorInsuranceAddClaimsPolicyExpire_0127_d18a3eAsync
        await _ui.PressAsync(_locators.PolicyExpire, "POST:CTRL+A");
        await _ui.PressAsync(_locators.PolicyExpire, "CTRL+A");
        await _ui.PressAsync(_locators.PolicyExpire, "Enter");
        await _ui.PressAsync(_locators.PolicyExpire, "Tab");
        // EQBOPClaimsPriorInsuranceAddVerifyDeleteClaims_574436Page.EQLoadingIndicatorWait_0128_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPClaimsPriorInsuranceAddVerifyDeleteClaims_574436Page.EQBOPClaimsPriorInsuranceAddClaimsAmountPaid_0129_d18a3eAsync
        await _ui.PressAsync(_locators.AmountPaid, "POST:CTRL+A");
        await _ui.PressAsync(_locators.AmountPaid, "CTRL+A");
        await _ui.PressAsync(_locators.AmountPaid, "Enter");
        await _ui.PressAsync(_locators.AmountPaid, "Tab");
        // EQBOPClaimsPriorInsuranceAddVerifyDeleteClaims_574436Page.EQLoadingIndicatorWait_0130_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPClaimsPriorInsuranceAddVerifyDeleteClaims_574436Page.EQBOPClaimsPriorInsuranceAddClaimsAmountReserved_0131_d18a3eAsync
        await _ui.PressAsync(_locators.AmountReserved, "POST:CTRL+A");
        await _ui.PressAsync(_locators.AmountReserved, "CTRL+A");
        await _ui.PressAsync(_locators.AmountReserved, "Enter");
        await _ui.PressAsync(_locators.AmountReserved, "Tab");
        // EQBOPClaimsPriorInsuranceAddVerifyDeleteClaims_574436Page.EQLoadingIndicatorWait_0132_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPClaimsPriorInsuranceAddVerifyDeleteClaims_574436Page.EQBOPClaimsPriorInsuranceAddClaimsExpenseAmount_0133_d18a3eAsync
        await _ui.PressAsync(_locators.ExpenseAmount, "POST:CTRL+A");
        await _ui.PressAsync(_locators.ExpenseAmount, "CTRL+A");
        await _ui.PressAsync(_locators.ExpenseAmount, "Enter");
        await _ui.PressAsync(_locators.ExpenseAmount, "Tab");
        // EQBOPClaimsPriorInsuranceAddVerifyDeleteClaims_574436Page.EQLoadingIndicatorWait_0134_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPClaimsPriorInsuranceAddVerifyDeleteClaims_574436Page.EQBOPClaimsPriorInsuranceAddClaimsTypeOfLoss_0135_d18a3eAsync
        await _ui.PressAsync(_locators.TypeOfLossDropdown, "POST:TAB");
        await _ui.PressAsync(_locators.TypeOfLossDropdown, "Tab");
        await _ui.ClickAsync(_locators.TypeOfLossSelection);
        // EQBOPClaimsPriorInsuranceAddVerifyDeleteClaims_574436Page.EQLoadingIndicatorWait_0136_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPClaimsPriorInsuranceAddVerifyDeleteClaims_574436Page.EQBOPClaimsPriorInsuranceAddClaimsDescriptionOfClaim_0137_d18a3eAsync
        await _ui.PressAsync(_locators.DescriptionOfOccurrenceOrClaim, "POST:ENTER");
        await _ui.PressAsync(_locators.DescriptionOfOccurrenceOrClaim, "Enter");
        await _ui.PressAsync(_locators.DescriptionOfOccurrenceOrClaim, "Tab");
        await _ui.ClickAsync(_locators.OpenButton);
        await _ui.ClickAsync(_locators.Save);
        // EQBOPClaimsPriorInsuranceAddVerifyDeleteClaims_574436Page.EQBOPClaimsPriorInsuranceAddClaimClaimsSummaryTableVerifyHeadings_0138_d18a3eAsync
        await _ui.VerifyAsync(_locators.ClaimSummaryTableRowCellExplicitNameClaimDate, _data.Resolve("{{data:expected_claim_summary_table_row_cell_explicitname_claim_date_165}}"), "");
        await _ui.VerifyAsync(_locators.ClaimSummaryTableRowCellExplicitNameAmount, _data.Resolve("{{data:expected_claim_summary_table_row_cell_explicitname_amount_166}}"), "");
        await _ui.VerifyAsync(_locators.ClaimSummaryTableRowCellExplicitNameLineOfCoverage, _data.Resolve("{{data:expected_claim_summary_table_row_cell_explicitname_line_of_coverage_167}}"), "");
        await _ui.VerifyAsync(_locators.ClaimSummaryTableRowCellExplicitNameTypeOfLoss, _data.Resolve("{{data:expected_claim_summary_table_row_cell_explicitname_type_of_loss_168}}"), "");
        await _ui.VerifyAsync(_locators.ClaimSummaryTableRowCellExplicitNameCATClaim, _data.Resolve("{{data:expected_claim_summary_table_row_cell_explicitname_cat_claim_169}}"), "");
        // EQBOPClaimsPriorInsuranceAddVerifyDeleteClaims_574436Page.EQBOPClaimsPriorInsuranceAddClaimClaimsSummaryTableVerifyCorrectValues_0139_d18a3eAsync
        await _ui.VerifyAsync(_locators.ClaimSummaryTableRowCellExplicitNameClaimDate, _data.Resolve("{{data:expected_claim_summary_table_row_cell_explicitname_claim_date_170}}"), "");
        await _ui.VerifyAsync(_locators.ClaimSummaryTableRowCellExplicitNameAmount, _data.Resolve("__BLANK__"), "");
        await _ui.VerifyAsync(_locators.ClaimSummaryTableRowCellExplicitNameLineOfCoverage, _data.Resolve("{{data:expected_claim_summary_table_row_cell_explicitname_line_of_coverage_172}}"), "");
        await _ui.VerifyAsync(_locators.ClaimSummaryTableRowCellExplicitNameTypeOfLoss, _data.Resolve("{{data:expected_claim_summary_table_row_cell_explicitname_type_of_loss_173}}"), "");
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0141_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_6}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0142_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I complete eChecklist \- Loss Runs \- 3 Years
    public async Task CompleteEChecklistLossRuns3YearsAsync()
    {
        // CLEQCommonEChecklistLossRuns3Years_99f5d4Page.CLEQEChecklistLossRuns3Yrs_0518_d18a3eAsync
        await _ui.FillAsync(_locators.AllLink, _data.Resolve(""));
        await _ui.WaitAsync(_locators.LossRunsHeader, "Exists");
        await _ui.ClickAsync(_locators.Exception);
        await _ui.WaitAsync(_locators.AddANote, "Visible");
        await _ui.PressAsync(_locators.AddANote, "POST:TAB");
        await _ui.PressAsync(_locators.AddANote, "Tab");
        await _ui.ClickAsync(_locators.EChecklistEChecklistOK);
        await _ui.WaitAsync(_locators.EChecklistEChecklistOK, "Absent");
        // CLEQCommonEChecklistLossRuns3Years_99f5d4Page.CLEQEChecklistSync_0519_d18a3eAsync
        await _ui.WaitAsync(_locators.LossRuns3YearsHeader, "Absent");
    }

    // Business step: I enter Required
    public async Task EnterRequiredAsync3()
    {
        // CLEQSFPPriorClaimsEnterRequired_faf113Page.EQPriorCarrierClaimsEnterRequiredInfo_0124_08f3f1Async
        await _ui.ClickAsync(_locators.PriorPolicyNo);
        // CLEQSFPPriorClaimsEnterRequired_faf113Page.EQLoadingIndicatorWait_0125_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPPriorClaimsEnterRequired_faf113Page.EQPriorCarrierClaimsClick3_0126_08f3f1Async
        await _ui.PressAsync(_locators.YearsInBusiness, "POST:ENTER");
        await _ui.PressAsync(_locators.YearsInBusiness, "Enter");
        await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        await _ui.ClickAsync(_locators.N3Years);
        await _ui.PressAsync(_locators.N3Years, "POST:TAB");
        await _ui.PressAsync(_locators.N3Years, "Tab");
        // CLEQSFPPriorClaimsEnterRequired_faf113Page.EQLoadingIndicatorWait_0127_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPPriorClaimsEnterRequired_faf113Page.EQPriorCarrierClaimsEnterLatestExpiration_0128_08f3f1Async
        await _ui.PressAsync(_locators.PriorInsuranceLatestExpirationDate, "POST:ENTER");
        await _ui.PressAsync(_locators.PriorInsuranceLatestExpirationDate, "Enter");
        await _ui.PressAsync(_locators.PriorInsuranceLatestExpirationDate, "Tab");
        // CLEQSFPPriorClaimsEnterRequired_faf113Page.EQLoadingIndicatorWait_0129_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPPriorClaimsEnterRequired_faf113Page.EQPriorCarrierClaimsEnterLatestCarrier_0130_08f3f1Async
        await _ui.PressAsync(_locators.PriorInsuranceLatestCarrier, "POST:ENTER");
        await _ui.PressAsync(_locators.PriorInsuranceLatestCarrier, "Enter");
        await _ui.PressAsync(_locators.PriorInsuranceLatestCarrier, "Tab");
    }

}
