using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class ProposalPage
{
    private readonly BrowserSession _browser;
    private readonly ProposalLocators _locators;
    private readonly UiActions _ui;

    public ProposalPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new ProposalLocators(browser.Page);
        _ui = ui;
    }

    public Task EnterEffectiveDateAsync(string value) =>
        _ui.FillAsync(_locators.EffectiveDate, value, new ControlIntent("Proposal", "EffectiveDate"));

    public Task PressEffectiveDateAsync(string key) =>
        _ui.PressAsync(_locators.EffectiveDate, key, new ControlIntent("Proposal", "EffectiveDate"));

    public Task<string> CaptureEffectiveDateAsync(string property = "") =>
        _ui.CaptureAsync(_locators.EffectiveDate, property, new ControlIntent("Proposal", "EffectiveDate"));

    public Task ClickNewQuoteAsync() =>
        _ui.ClickAsync(_locators.NewQuote, new ControlIntent("Proposal", "NewQuote"));

    public Task EnterProductAsync(string value) =>
        _ui.FillAsync(_locators.Product, value, new ControlIntent("Proposal", "Product"));
    public Task EnterProducerAsync(string value) =>
        _ui.FillAsync(_locators.Producer, value, new ControlIntent("Proposal", "Producer"));
    public Task PressProductAsync(string key) =>
        _ui.PressAsync(_locators.Product, key, new ControlIntent("Proposal", "Product"));

    public Task WaitForStartAsync(string expected) =>
        _ui.WaitAsync(_locators.Start, expected, new ControlIntent("Proposal", "Start"));

    public Task ClickStartAsync() =>
        _ui.ClickAsync(_locators.Start, new ControlIntent("Proposal", "Start"));


    public Task EnterEffectiveDateSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.EffectiveDate, value, new ControlIntent("Proposal", "EffectiveDate"), delayMs);

    public Task EnterProductSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Product, value, new ControlIntent("Proposal", "Product"), delayMs);
}
