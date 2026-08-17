using InsuranceAutomation.Core;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class QuoteSearchPage
{
    private readonly QuoteSearchLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public QuoteSearchPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new QuoteSearchLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I capture the quote identity and close the current quote
    public async Task CaptureTheQuoteIdentityAndCloseTheCurrentQuoteAsync()
    {
        // Common_7de90aPage.CaptureTheQuoteIdentityAndCloseTheQuote_00540056_8fa692Async
        _data.Set("Quote_NameNum", await _ui.CaptureAsync(_locators.NameAndQuote, "InnerText"));
        _data.Set("Quote_Num", _data.Resolve("{{runtime:Quote_NameNum}}"));
        _data.Set("Quote_Num", _data.Resolve("{{runtime:QuoteID}}"));
        await _ui.ClickAsync(_locators.CloseQuote);
    }

    // Business step: I retrieve the quote and verify its identity
    public async Task RetrieveTheQuoteAndVerifyItsIdentityAsync()
    {
        // Common_7de90aPage.SearchForTheSameQuoteAndVerifyIdentity_00570068_8fa692Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        await _ui.FillAsync(_locators.QuoteSearch, _data.Resolve("{{runtime:Quote_Num}}"));
        await _ui.ClickAsync(_locators.ClientInfoSearch);
        await _ui.WaitAsync(_locators.Loading, "Absent");
        _data.Set("Screen", _data.Resolve("{{data:required_target_screen}}"));
        await _ui.FillAsync(_locators.PreQualification, _data.Resolve("{{data:prequalification_64}}"));
        if (_data.Condition("if the \"Review Required\" popup is displayed and the configured action is \"Keep Going\""))
        {
        await _ui.ClickAsync(_locators.KeepGoing);
        }
        await _ui.WaitAsync(_locators.Loading, "Absent");
        await _ui.VerifyAsync(_locators.PreQualification, _data.Resolve("Exists"), "");
        await _ui.VerifyAsync(_locators.NameAndQuote, _data.Resolve("{{runtime:Quote_NameNum}}"), "");
    }

}