using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

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

    public Task VerifyEstimatedPremiumAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.EstimatedPremium, expected, property, new ControlIntent("Pricing", "EstimatedPremium"));

    public Task VerifyFullTermPremiumAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.FullTermPremium, expected, property, new ControlIntent("Pricing", "FullTermPremium"));

    public Task EnterJavaScriptAsync(string value) =>
        _ui.FillAsync(_locators.JavaScript, value, new ControlIntent("Pricing", "JavaScript"));

    public Task VerifyPremiumAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.Premium, expected, property, new ControlIntent("Pricing", "Premium"));

    public Task VerifyPremiumChangeAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.PremiumChange, expected, property, new ControlIntent("Pricing", "PremiumChange"));

    public Task VerifyPremiumWrittenAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.PremiumWritten, expected, property, new ControlIntent("Pricing", "PremiumWritten"));

    public Task VerifyPriorPremiumAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.PriorPremium, expected, property, new ControlIntent("Pricing", "PriorPremium"));

    public Task VerifyResultAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.Result, expected, property, new ControlIntent("Pricing", "Result"));

    public Task EnterTitleAsync(string value) =>
        _ui.FillAsync(_locators.Title, value, new ControlIntent("Pricing", "Title"));


    public Task<string> CaptureResultAsync(string property = "") =>
        _ui.CaptureAsync(_locators.Result, property, new ControlIntent("Pricing", "Result"));

}
