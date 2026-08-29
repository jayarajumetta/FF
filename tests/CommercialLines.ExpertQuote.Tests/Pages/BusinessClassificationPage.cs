using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class BusinessClassificationPage
{
    private readonly BrowserSession _browser;
    private readonly BusinessClassificationLocators _locators;
    private readonly UiActions _ui;

    public BusinessClassificationPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new BusinessClassificationLocators(browser.Page);
        _ui = ui;
    }

    public Task WaitForIndustryClassCodeRestrictionsHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.IndustryClassCodeRestrictionsHeading, expected, new ControlIntent("BusinessClassification", "IndustryClassCodeRestrictionsHeading"));

    public Task PressNoneOfTheAboveAsync(string key) =>
        _ui.PressAsync(_locators.NoneOfTheAbove, key, new ControlIntent("BusinessClassification", "NoneOfTheAbove"));

    public Task PressNoneOfTheAboveCheckboxAsync(string key) =>
        _ui.PressAsync(_locators.NoneOfTheAboveCheckbox, key, new ControlIntent("BusinessClassification", "NoneOfTheAboveCheckbox"));

    public Task VerifyScreenHeadingAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.NoPrefillMatchFound, expected, property, new ControlIntent("BusinessClassification", "ScreenHeading"));

    public Task<bool> IsScreenHeadingPresentAsync() =>
        _ui.ExistsAsync(_locators.NoPrefillMatchFound);

}
