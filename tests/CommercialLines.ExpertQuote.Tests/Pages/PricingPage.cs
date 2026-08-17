using InsuranceAutomation.Core;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class PricingPage
{
    private readonly PricingLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public PricingPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new PricingLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I verify premium
    public async Task VerifyPremiumAsync()
    {
        // CLEQSFPPricingVerifyPremium_3cf057Page.EQSFPPricing_0227_503012Async
        _data.Set("Total Premium", await _ui.CaptureAsync(_locators.TotalPremium, "InnerText"));
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0228_503012Async
        _data.Set("Screen", _data.Resolve("{{data:screen_11}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0229_503012Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading))
        {
        await _ui.VerifyAsync(_locators.ScreenHeading, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I verify premium on DC
    public async Task VerifyPremiumOnDCAsync()
    {
        // EQCommonTransactVerifyPremiumOnDC_8d817aPage.VerifyNewPremiumOnDuckCreek_0837_d18a3eAsync
        await _ui.VerifyAsync(_locators.DCTransactionTableRowCellExplicitNameNewPremium, _data.Resolve("{{data:expected_dc_transaction_table_row_cell_explicitname_new_premium_772}}"), "");
        await _ui.VerifyAsync(_locators.DCTransactionTableRowCellExplicitNameStatus, _data.Resolve("{{data:expected_dc_transaction_table_row_cell_explicitname_status_773}}"), "");
    }

    // Business step: I verify premium
    public async Task VerifyPremiumAsync2()
    {
        // CLEQSFPPricingVerifyPremium_3cf057Page.EQSFPPricing_0279_08f3f1Async
        _data.Set("Total Premium", await _ui.CaptureAsync(_locators.TotalPremium, "InnerText"));
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0280_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_14}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0281_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading))
        {
        await _ui.VerifyAsync(_locators.ScreenHeading, _data.Resolve("Absent"), "");
        }
    }

}