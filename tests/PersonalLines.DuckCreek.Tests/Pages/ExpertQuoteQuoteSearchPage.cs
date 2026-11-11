using InsuranceAutomation.Core;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class ExpertQuoteQuoteSearchPage
{
    private readonly ExpertQuoteQuoteSearchLocators _locators;
    private readonly UiActions _ui;

    public ExpertQuoteQuoteSearchPage(BrowserSession browser, UiActions ui)
    {
        _locators = new ExpertQuoteQuoteSearchLocators(browser.Page);
        _ui = ui;
    }

    public Task EnterQuoteSearchAsync(string value) =>
        _ui.FillAsync(_locators.QuoteSearchInput, value, new ControlIntent("QuoteSearch", "QuoteSearchInput"));

    public async Task ClickQuoteSearchAsync()
    {
        // The Angular overlay sometimes blocks clicks, use JavaScript click as workaround
        await _locators.QuoteSearchButton.EvaluateAsync("el => el.click()");
    }

    public Task ClickCloseQuoteAsync() =>
        _ui.ClickAsync(_locators.CloseQuote, new ControlIntent("QuoteSearch", "CloseQuote"));

    public Task ClickKeepGoingAsync() =>
        _ui.ClickAsync(_locators.KeepGoing, new ControlIntent("QuoteSearch", "KeepGoing"));

    public Task<bool> IsKeepGoingPresentAsync() => _ui.ExistsAsync(_locators.KeepGoing);

    public Task<string> CaptureNameAndQuoteAsync(string property = "") =>
        _ui.CaptureAsync(_locators.NameAndQuote, property, new ControlIntent("QuoteSearch", "NameAndQuote"));

    public Task VerifyNameAndQuoteAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.NameAndQuote, expected, property, new ControlIntent("QuoteSearch", "NameAndQuote"));

    public Task NavigateToScreenAsync(string screen) =>
        _ui.ClickAsync(_locators.GetNavigationLink(screen), new ControlIntent("Navigation", $"NavLink:{screen}"));

    public Task VerifyScreenAsync(string screen) =>
        _ui.VerifyAsync(_locators.GetScreenHeading(screen), "Visible", "", new ControlIntent("Navigation", $"ScreenHeading:{screen}"));
}
