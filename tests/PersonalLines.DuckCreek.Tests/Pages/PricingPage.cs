using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

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

    public Task WaitForHeaderPricingDetailsAsync(string expected) =>
        _ui.WaitAsync(_locators.HeaderPricingDetails, expected, new ControlIntent("Pricing", "HeaderPricingDetails"));
public Task ClickPricingDetailsNewNextAsync() =>
        _ui.ClickAsync(_locators.PricingDetailsNewNext, new ControlIntent("Pricing", "PricingDetailsNewNext"));

}
