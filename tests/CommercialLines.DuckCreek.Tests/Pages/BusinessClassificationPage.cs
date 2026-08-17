using InsuranceAutomation.Core;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class BusinessClassificationPage
{
    private readonly BusinessClassificationLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public BusinessClassificationPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new BusinessClassificationLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I verify Class Codes on Policy are Valid
    public async Task VerifyClassCodesOnPolicyAreValidAsync()
    {
        // Pricing_a0d9bbPage.VerifyInvalidClassCodesMessageDoesNotExist_0122_bb930cAsync
        await _ui.VerifyAsync(_locators.InvalidClassCodeMessage, _data.Resolve("Absent"), "");
    }

    // Business step: I verify Class Codes on Policy are Valid
    public async Task VerifyClassCodesOnPolicyAreValidAsync2()
    {
        // Pricing_a0d9bbPage.VerifyInvalidClassCodesMessageDoesNotExist_0143_f2d6bdAsync
        await _ui.VerifyAsync(_locators.InvalidClassCodeMessage, _data.Resolve("Absent"), "");
    }

}