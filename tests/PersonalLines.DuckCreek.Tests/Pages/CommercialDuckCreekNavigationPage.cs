using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class CommercialDuckCreekNavigationPage
{
    private readonly BrowserSession _browser;
    private readonly CommercialDuckCreekNavigationLocators _locators;
    private readonly UiActions _ui;

    public CommercialDuckCreekNavigationPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new CommercialDuckCreekNavigationLocators(browser.Page);
        _ui = ui;
    }

    public Task ClickHomeLinkAsync() =>
        _ui.ClickAsync(_locators.HomeLink, new ControlIntent("Navigation", "HomeLink"));

    public Task WaitForHomeLinkAsync(string expected) =>
        _ui.WaitAsync(_locators.HomeLink, expected, new ControlIntent("Navigation", "HomeLink"));

    public Task ClickClientLinkAsync() =>
        _ui.ClickAsync(_locators.ClientLink, new ControlIntent("Navigation", "ClientLink"));

    public Task WaitForClientLinkAsync(string expected) =>
        _ui.WaitAsync(_locators.ClientLink, expected, new ControlIntent("Navigation", "ClientLink"));

    public async Task<bool> IsClientLinkVisibleAsync() =>
        await _locators.ClientLink.CountAsync() > 0 && await _locators.ClientLink.IsVisibleAsync();

    public Task WaitForClientPageTitleAsync(string expected) =>
        _ui.WaitAsync(_locators.ClientPageTitle, expected, new ControlIntent("Navigation", "ClientPageTitle"));
}
