using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class AdditionalInterestsPage
{
    private readonly BrowserSession _browser;
    private readonly AdditionalInterestsLocators _locators;
    private readonly UiActions _ui;

    public AdditionalInterestsPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new AdditionalInterestsLocators(browser.Page);
        _ui = ui;
    }

    public Task ClickAdditionalInterestNextAsync() =>
        _ui.ClickAsync(_locators.AdditionalInterestNext, new ControlIntent("AdditionalInterests", "AdditionalInterestNext"));

    public Task WaitForAdditionalInterestNextAsync(string expected) =>
        _ui.WaitAsync(_locators.AdditionalInterestNext, expected, new ControlIntent("AdditionalInterests", "AdditionalInterestNext"));
    public Task WaitForCONTINUED555DAsync(string expected) =>
        _ui.WaitAsync(_locators.CONTINUED555D, expected, new ControlIntent("AdditionalInterests", "CONTINUED555D"));

    public Task WaitAdditionalInterestHeaderAsync(string expected) =>
        _ui.WaitAsync(_locators.AdditionalInterestHeader, expected, new ControlIntent("AdditionalInterests", "AdditionalInterestHeader"));

    public Task ClickCONTINUED555DAsync() =>
        _ui.ClickAsync(_locators.CONTINUED555D, new ControlIntent("AdditionalInterests", "CONTINUED555D"));

    public Task<bool> IsCONTINUED555DPresentAsync() =>
        _ui.ExistsAsync(_locators.CONTINUED555D);

    public Task VerifyEQCommonLoadingIndicatorWaitAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.EQCommonLoadingIndicatorWait, expected, property, new ControlIntent("AdditionalInterests", "EQCommonLoadingIndicatorWait"));

}
