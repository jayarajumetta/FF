using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class CommercialDuckCreekPolicyWorkflowPage
{
    private readonly BrowserSession _browser;
    private readonly CommercialDuckCreekPolicyWorkflowLocators _locators;
    private readonly UiActions _ui;

    public CommercialDuckCreekPolicyWorkflowPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new CommercialDuckCreekPolicyWorkflowLocators(browser.Page);
        _ui = ui;
    }

    public Task WaitForUserNameInitialAsync(string expected) =>
        _ui.WaitAsync(_locators.UserNameInitial, expected, new ControlIntent("PolicyWorkflow", "UserNameInitial"));

    public Task ClickUserNameInitialAsync() =>
        _ui.ClickAsync(_locators.UserNameInitial, new ControlIntent("PolicyWorkflow", "UserNameInitial"));

    public Task WaitForLogoutAsync(string expected) =>
        _ui.WaitAsync(_locators.Logout, expected, new ControlIntent("PolicyWorkflow", "Logout"));

    public Task ClickLogoutAsync() =>
        _ui.ClickAsync(_locators.Logout, new ControlIntent("PolicyWorkflow", "Logout"));

    public Task WaitForLogoutOkButtonAsync(string expected) =>
        _ui.WaitAsync(_locators.LogoutOkButton, expected, new ControlIntent("PolicyWorkflow", "LogoutOkButton"));

    public async Task ClickLogoutOkButtonAsync()
    {
        try
        {
            await _locators.LogoutOkButton.ClickAsync(new LocatorClickOptions { Timeout = 5000 });
        }
        catch (PlaywrightException)
        {
            // The OK click can trigger a page navigation/reload that destroys the
            // current execution context mid-click; treat that as success since the
            // dialog has already been dismissed by the click action itself.
        }

        await _browser.Page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
    }

    public async Task<bool> LogoutOkButtonIsVisibleAsync() =>
        await _locators.LogoutOkButton.CountAsync() > 0 && await _locators.LogoutOkButton.IsVisibleAsync();

    public Task WaitForQuickSearchButtonAsync(string expected) =>
        _ui.WaitAsync(_locators.QuickSearchButton, expected, new ControlIntent("PolicyWorkflow", "QuickSearchButton"));

    public Task ClickQuickSearchButtonAsync() =>
        _ui.ClickAsync(_locators.QuickSearchButton, new ControlIntent("PolicyWorkflow", "QuickSearchButton"));

    public Task WaitForSearchButtonAsync(string expected) =>
        _ui.WaitAsync(_locators.SearchButton, expected, new ControlIntent("PolicyWorkflow", "SearchButton"));

    public Task ClickSearchButtonAsync() =>
        _ui.ClickAsync(_locators.SearchButton, new ControlIntent("PolicyWorkflow", "SearchButton"));

    public Task WaitForSearchResultsInsuredNameColumnHeaderAsync(string expected) =>
        _ui.WaitAsync(_locators.SearchResultsInsuredNameColumnHeader, expected, new ControlIntent("PolicyWorkflow", "SearchResultsInsuredNameColumnHeader"));

    public Task ClickSearchResultInsuredNameLinkAsync() =>
        _ui.ClickAsync(_locators.SearchResultInsuredNameLink, new ControlIntent("PolicyWorkflow", "SearchResultInsuredNameLink"));

    public Task WaitForCommercialAutoQuoteLinkAsync(string expected) =>
        _ui.WaitAsync(_locators.CommercialAutoQuoteLink, expected, new ControlIntent("PolicyWorkflow", "CommercialAutoQuoteLink"));

    public Task ClickCommercialAutoQuoteLinkAsync() =>
        _ui.ClickAsync(_locators.CommercialAutoQuoteLink, new ControlIntent("PolicyWorkflow", "CommercialAutoQuoteLink"));

    public Task WaitForSearchMethodEGDescriptionPolicyAsync(string expected) =>
        _ui.WaitAsync(_locators.SearchMethodEGDescriptionPolicy, expected, new ControlIntent("PolicyWorkflow", "SearchMethodEGDescriptionPolicy"));

    public Task EnterSearchMethodEGDescriptionPolicySequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.SearchMethodEGDescriptionPolicy, value, new ControlIntent("PolicyWorkflow", "SearchMethodEGDescriptionPolicy"), delayMs);

    public Task PressSearchMethodEGDescriptionPolicyAsync(string key) =>
        _ui.PressAsync(_locators.SearchMethodEGDescriptionPolicy, key, new ControlIntent("PolicyWorkflow", "SearchMethodEGDescriptionPolicy"));

    public Task WaitForSearchTextAsync(string expected) =>
        _ui.WaitAsync(_locators.SearchText, expected, new ControlIntent("PolicyWorkflow", "SearchText"));

    public Task EnterSearchTextSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.SearchText, value, new ControlIntent("PolicyWorkflow", "SearchText"), delayMs);
}
