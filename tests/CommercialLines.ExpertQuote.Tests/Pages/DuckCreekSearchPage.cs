using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class DuckCreekSearchPage
{
    private readonly BrowserSession _browser;
    private readonly IPage _page;
    private readonly DuckCreekSearchLocators _locators;
    private readonly UiActions _ui;

    public DuckCreekSearchPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _page = browser.Page;
        _locators = new DuckCreekSearchLocators(browser.Page);
        _ui = ui;
    }

    public Task ClickQuickSearchAsync() =>
        _ui.ClickAsync(_locators.QuickSearch, new ControlIntent("Search", "QuickSearch"));

    public Task SelectSearchFieldAsync(string value) =>
        _ui.SmartSetAsync(_locators.SearchField, value, new ControlIntent("Search", "SearchField"));

    public Task SelectSearchOperatorAsync(string value) =>
        _ui.SmartSetAsync(_locators.SearchOperator, value, new ControlIntent("Search", "SearchOperator"));

    public Task EnterSearchValueAsync(string value) =>
        _ui.FillAsync(_locators.SearchValue, value, new ControlIntent("Search", "SearchValue"));

    public Task ClickSearchAsync() =>
        _ui.ClickAsync(_locators.SearchButton, new ControlIntent("Search", "SearchButton"));

    public Task ClickSearchResultInsuredNameAsync() =>
        _ui.ClickAsync(_locators.SearchResultInsuredNameLink, new ControlIntent("Search", "SearchResultInsuredNameLink"));

    public Task ClickBusinessOwnersQuoteAsync() =>
        _ui.ClickAsync(_locators.BusinessOwnersQuoteLink, new ControlIntent("Search", "BusinessOwnersQuoteLink"));

    public Task ClickSubmissionAsync() =>
        _ui.ClickAsync(_locators.SubmissionLink, new ControlIntent("Search", "SubmissionLink"));

    public Task ClickCompleteApplicationAsync() =>
        _ui.ClickAsync(_locators.CompleteApplicationButton, new ControlIntent("Search", "CompleteApplicationButton"));

    public Task WaitForProcessingCompleteAsync(int timeoutMs = 120000) =>
        _locators.ProcessingCompleteMessage.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = timeoutMs });

    public Task ClickProcessingCompleteCloseAsync() =>
        _ui.ClickAsync(_locators.ProcessingCompleteCloseButton, new ControlIntent("Search", "ProcessingCompleteCloseButton"));

    public Task ClickApproveAsync() =>
        _ui.ClickAsync(_locators.ApproveButton, new ControlIntent("Search", "ApproveButton"));

    public Task ClickOkAsync() =>
        _ui.ClickAsync(_locators.OkButton, new ControlIntent("Search", "OkButton"));

    public Task WaitForOkButtonAsync(int timeoutMs = 10000) =>
        _locators.OkButton.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = timeoutMs });

    public Task VerifyApprovedStatusAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ApprovedStatus, expected, property, new ControlIntent("Search", "ApprovedStatus"));
}
