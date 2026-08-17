using InsuranceAutomation.Core;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class AdditionalInterestsPage
{
    private readonly AdditionalInterestsLocators _locators;
    private readonly ScenarioData _data;
    private readonly UiActions _ui;

    public AdditionalInterestsPage(BrowserSession browser, ScenarioData data, UiActions ui)
    {
        _locators = new AdditionalInterestsLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I complete additional Interest Page
    public async Task CompleteAdditionalInterestPageAsync()
    {
        // EQAdditionalInterest_b6f3d1Page.AdditionalInterest_0145_8f9ff6Async
        await _ui.ClickAsync(_locators.AdditionalInterestNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0146_8f9ff6Async
        await _ui.VerifyAsync(_locators.EQCommonLoadingIndicatorWait, _data.Resolve("Exists"), "");
    }

    // Business step: I complete additional Interest Page
    public async Task CompleteAdditionalInterestPageAsync2()
    {
        // EQAdditionalInterest_b6f3d1Page.AdditionalInterest_0157_8f5301Async
        await _ui.ClickAsync(_locators.AdditionalInterestNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0158_8f5301Async
        await _ui.VerifyAsync(_locators.EQCommonLoadingIndicatorWait, _data.Resolve("Exists"), "");
    }

    // Business step: I complete additional Interest Page
    public async Task CompleteAdditionalInterestPageAsync3()
    {
        // EQAdditionalInterest_b6f3d1Page.AdditionalInterest_0158_e2e0d7Async
        await _ui.ClickAsync(_locators.AdditionalInterestNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0159_e2e0d7Async
        await _ui.VerifyAsync(_locators.EQCommonLoadingIndicatorWait, _data.Resolve("Exists"), "");
    }

    // Business step: I complete additional Interest Page
    public async Task CompleteAdditionalInterestPageAsync4()
    {
        // EQAdditionalInterest_b6f3d1Page.AdditionalInterest_0158_bafd4aAsync
        await _ui.ClickAsync(_locators.AdditionalInterestNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0159_bafd4aAsync
        await _ui.VerifyAsync(_locators.EQCommonLoadingIndicatorWait, _data.Resolve("Exists"), "");
    }

    // Business step: I complete additional Interest Page
    public async Task CompleteAdditionalInterestPageAsync5()
    {
        // EQAdditionalInterest_b6f3d1Page.AdditionalInterest_0161_8f4c8fAsync
        await _ui.ClickAsync(_locators.AdditionalInterestNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0162_8f4c8fAsync
        await _ui.VerifyAsync(_locators.EQCommonLoadingIndicatorWait, _data.Resolve("Exists"), "");
    }

    // Business step: I complete additional Interest Page
    public async Task CompleteAdditionalInterestPageAsync6()
    {
        // EQAdditionalInterest_b6f3d1Page.AdditionalInterest_0161_10f911Async
        await _ui.ClickAsync(_locators.AdditionalInterestNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0162_10f911Async
        await _ui.VerifyAsync(_locators.EQCommonLoadingIndicatorWait, _data.Resolve("Exists"), "");
    }

}
