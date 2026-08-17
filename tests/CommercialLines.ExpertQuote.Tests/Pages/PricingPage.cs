using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class PricingPage
{
    private readonly BrowserSession _browser;
    private readonly PricingLocators _locators;
    private readonly UiActions _ui;

    public PricingPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new PricingLocators(browser.Page);
        _ui = ui;
    }

    public Task VerifyDCTransactionTableRowCellExplicitNameNewPremiumAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.DCTransactionTableRowCellExplicitNameNewPremium, expected, property, new ControlIntent("Pricing", "DCTransactionTableRowCellExplicitNameNewPremium"));

    public Task VerifyDCTransactionTableRowCellExplicitNameStatusAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.DCTransactionTableRowCellExplicitNameStatus, expected, property, new ControlIntent("Pricing", "DCTransactionTableRowCellExplicitNameStatus"));

    public Task VerifyScreenHeadingAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ScreenHeading, expected, property, new ControlIntent("Pricing", "ScreenHeading"));

    public Task<bool> IsScreenHeadingPresentAsync() =>
        _ui.ExistsAsync(_locators.ScreenHeading);

    public Task<string> CaptureTotalPremiumAsync(string property = "") =>
        _ui.CaptureAsync(_locators.TotalPremium, property, new ControlIntent("Pricing", "TotalPremium"));

}
