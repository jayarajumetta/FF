using InsuranceAutomation.Core;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class PricingPage
{
    private readonly PricingLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public PricingPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new PricingLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I complete pricing and verify the premium
    public async Task CompletePricingAndVerifyThePremiumAsync()
    {
        // EQPricingDetailsNew_1774eePage.EQPricingDetailsNew_0142_8f9ff6Async
        await _ui.WaitAsync(_locators.HeaderPricingDetails, "Exists");
        await _ui.ClickAsync(_locators.PricingDetailsNewNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0143_8f9ff6Async
        await _ui.WaitAsync(_locators.Loading, "Exists");
    }

    // Business step: I complete pricing and verify the premium
    public async Task CompletePricingAndVerifyThePremiumAsync2()
    {
        // EQPricingDetailsNew_1774eePage.EQPricingDetailsNew_0154_8f5301Async
        await _ui.WaitAsync(_locators.HeaderPricingDetails, "Exists");
        await _ui.ClickAsync(_locators.PricingDetailsNewNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0155_8f5301Async
        await _ui.WaitAsync(_locators.Loading, "Exists");
    }

    // Business step: I complete pricing and verify the premium
    public async Task CompletePricingAndVerifyThePremiumAsync3()
    {
        // EQPricingDetailsNew_1774eePage.EQPricingDetailsNew_0151_e2e0d7Async
        await _ui.WaitAsync(_locators.HeaderPricingDetails, "Exists");
        await _ui.ClickAsync(_locators.PricingDetailsNewNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0152_e2e0d7Async
        await _ui.WaitAsync(_locators.Loading, "Exists");
    }

    // Business step: I complete pricing and verify the premium
    public async Task CompletePricingAndVerifyThePremiumAsync4()
    {
        // EQPricingDetailsNew_1774eePage.EQPricingDetailsNew_0151_bafd4aAsync
        await _ui.WaitAsync(_locators.HeaderPricingDetails, "Exists");
        await _ui.ClickAsync(_locators.PricingDetailsNewNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0152_bafd4aAsync
        await _ui.WaitAsync(_locators.Loading, "Exists");
    }

    // Business step: I complete pricing and verify the premium
    public async Task CompletePricingAndVerifyThePremiumAsync5()
    {
        // EQPricingDetailsNew_1774eePage.EQPricingDetailsNew_0154_8f4c8fAsync
        await _ui.WaitAsync(_locators.HeaderPricingDetails, "Exists");
        await _ui.ClickAsync(_locators.PricingDetailsNewNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0155_8f4c8fAsync
        await _ui.WaitAsync(_locators.Loading, "Exists");
    }

    // Business step: I complete pricing and verify the premium
    public async Task CompletePricingAndVerifyThePremiumAsync6()
    {
        // EQPricingDetailsNew_1774eePage.EQPricingDetailsNew_0154_10f911Async
        await _ui.WaitAsync(_locators.HeaderPricingDetails, "Exists");
        await _ui.ClickAsync(_locators.PricingDetailsNewNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0155_10f911Async
        await _ui.WaitAsync(_locators.Loading, "Exists");
    }

}