using InsuranceAutomation.Core;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class BusinessClassificationPage
{
    private readonly BusinessClassificationLocators _locators;
    private readonly ScenarioData _data;
    private readonly UiActions _ui;

    public BusinessClassificationPage(BrowserSession browser, ScenarioData data, UiActions ui)
    {
        _locators = new BusinessClassificationLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I complete industry Class Code Restrictions
    public async Task CompleteIndustryClassCodeRestrictionsAsync()
    {
        // EQBOPPreQualificationIndustryClassCodeRestrictions_0c969cPage.BOPIndustryAnswerNonOfTheAbove_0062_d18a3eAsync
        await _ui.WaitAsync(_locators.IndustryClassCodeRestrictionsHeading, "Exists");
        await _ui.PressAsync(_locators.NoneOfTheAbove, "POST:TAB");
        await _ui.PressAsync(_locators.NoneOfTheAbove, "Tab");
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0063_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_2}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0064_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I complete industry Class Code Questions
    public async Task CompleteIndustryClassCodeQuestionsAsync()
    {
        // EQBOPPrimaryInsuredDetailsIndustryClassCodeQuestions_a7d59cPage.EQBOPPrimaryInsuredDetailsIndustryClassCodeQuestions_0083_d18a3eAsync
        await _ui.PressAsync(_locators.NoneOfTheAboveCheckbox, "POST:TAB");
        await _ui.PressAsync(_locators.NoneOfTheAboveCheckbox, "Tab");
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0084_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_3}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0085_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading, _data.Resolve("Absent"), "");
        }
    }

}
