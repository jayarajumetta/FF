using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

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

    public Task VerifyInvalidClassCodeMessageAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.InvalidClassCodeMessage, expected, property, new ControlIntent("BusinessClassification", "InvalidClassCodeMessage"));

}
