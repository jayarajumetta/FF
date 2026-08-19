using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class QuoteSearchPage
{
    private readonly BrowserSession _browser;
    private readonly QuoteSearchLocators _locators;
    private readonly UiActions _ui;

    public QuoteSearchPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new QuoteSearchLocators(browser.Page);
        _ui = ui;
    }

    public Task ClickClientInfoSearchAsync() =>
        _ui.ClickAsync(_locators.ClientInfoSearch, new ControlIntent("QuoteSearch", "ClientInfoSearch"));

    public Task ClickCloseQuoteAsync() =>
        _ui.ClickAsync(_locators.CloseQuote, new ControlIntent("QuoteSearch", "CloseQuote"));

    public Task ClickKeepGoingAsync() =>
        _ui.ClickAsync(_locators.KeepGoing, new ControlIntent("QuoteSearch", "KeepGoing"));
public Task VerifyNameAndQuoteAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.NameAndQuote, expected, property, new ControlIntent("QuoteSearch", "NameAndQuote"));

    public Task<string> CaptureNameAndQuoteAsync(string property = "") =>
        _ui.CaptureAsync(_locators.NameAndQuote, property, new ControlIntent("QuoteSearch", "NameAndQuote"));

    public Task VerifyPreQualificationAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.PreQualification, expected, property, new ControlIntent("QuoteSearch", "PreQualification"));

    public Task EnterPreQualificationAsync(string value) =>
        _ui.FillAsync(_locators.PreQualification, value, new ControlIntent("QuoteSearch", "PreQualification"));

    public Task EnterQuoteSearchAsync(string value) =>
        _ui.FillAsync(_locators.QuoteSearch, value, new ControlIntent("QuoteSearch", "QuoteSearch"));


    public Task<bool> IsKeepGoingPresentAsync() => _ui.ExistsAsync(_locators.KeepGoing);

}
