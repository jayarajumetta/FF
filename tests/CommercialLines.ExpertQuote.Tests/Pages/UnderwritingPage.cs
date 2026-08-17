using InsuranceAutomation.Core;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class UnderwritingPage
{
    private readonly UnderwritingLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public UnderwritingPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new UnderwritingLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I complete insurance Score
    public async Task CompleteInsuranceScoreAsync()
    {
        // CLEQSFPInsuranceScore_3046e8Page.EQSFPInputInsuranceScoreInformation_0190_503012Async
        await _ui.FillAsync(_locators.EntityType, _data.Resolve("{{data:entity_type_248}}"));
        await _ui.PressAsync(_locators.InsuranceScoreConsent, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.InsuranceScoreConsent, "SHIFTTAB");
        await _ui.PressAsync(_locators.InsuranceScoreConsent, "SCROLL[-3]");
        // CLEQSFPInsuranceScoreCLEQCommonWaitOnLoadingIndicator_314f5bPage.EQLoadingIndicatorWait_0191_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPInsuranceScore_3046e8Page.EQSFPInputInsuranceScoreInformation_0192_503012Async
        await _ui.ClickAsync(_locators.PrimaryInsured);
        // CLEQSFPInsuranceScore_3046e8Page.TBoxWait_0193_503012Async
        await Task.Delay(1000);
        // CLEQSFPInsuranceScore_3046e8Page.EQSFPInputInsuranceScoreInformation_0194_503012Async
        await _ui.ClickAsync(_locators.InsuranceScoreConsent);
        await _ui.WaitAsync(_locators.Accept, "Exists");
        await _ui.ClickAsync(_locators.Accept);
        // CLEQSFPInsuranceScoreCLEQCommonWaitOnLoadingIndicator_314f5bPage.EQLoadingIndicatorWait_0195_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0196_503012Async
        _data.Set("Screen", _data.Resolve("{{data:screen_9}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0197_503012Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading))
        {
        await _ui.VerifyAsync(_locators.ScreenHeading, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I complete general UW Questions
    public async Task CompleteGeneralUWQuestionsAsync()
    {
        // EQBOPPrimaryInsuredDetailsGeneralUWQuestions_e3bc3bPage.EQBOPPrimaryInsuredDetailsGeneralUWQuestions_0081_d18a3eAsync
        await _ui.PressAsync(_locators.NoneOfTheAboveCheckBox, "POST:TAB");
        await _ui.PressAsync(_locators.NoneOfTheAboveCheckBox, "Tab");
        // EQBOPPrimaryInsuredDetailsIndustryClassCodeQuestions_a7d59cPage.EQLoadingIndicatorWait_0082_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I answer Building Eligibility Questions
    public async Task AnswerBuildingEligibilityQuestionsAsync()
    {
        // EQBOPBuilding26AnswerBuildingEligibilityQuestions_1d0761Page.EQBOPBuildingBuildingEligibilityQuestions_0262_d18a3eAsync
        await _ui.PressAsync(_locators.BuildingEligibilityQuestionsNoneOfTheAboveCheckboxAngular, "POST:TAB");
        await _ui.PressAsync(_locators.BuildingEligibilityQuestionsNoneOfTheAboveCheckboxAngular, "Tab");
        await _ui.ClickAsync(_locators.Save);
        // EQBOPBuilding26AnswerBuildingEligibilityQuestions_1d0761Page.SetBufferForWaitOnTime_0263_d18a3eAsync
        _data.Set("WaitOnTime", _data.Resolve("{{data:waitontime}}"));
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0264_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_7}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0265_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading))
        {
        await _ui.VerifyAsync(_locators.ScreenHeading, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I complete insurance Score and premium Verification
    public async Task CompleteInsuranceScoreAndPremiumVerificationAsync()
    {
        // EQBOPPricingInsuranceScoreAndPremiumVerification_59a466Page.EQBOPPricingInsuranceScoreAndPremium_0332_d18a3eAsync
        _data.Set("Premium", await _ui.CaptureAsync(_locators.Premium, "InnerText"));
        // EQBOPPricingInsuranceScoreAndPremiumVerification_59a466Page.EQBOPPricingVerifyPremiums_0333_d18a3eAsync
        await _ui.VerifyAsync(_locators.TABLERowCellExplicitName1, _data.Resolve("{{data:expected_table_row_cell_explicitname_1_390}}"), "");
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0334_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_11}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0335_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading))
        {
        await _ui.VerifyAsync(_locators.ScreenHeading, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I complete insurance Score
    public async Task CompleteInsuranceScoreAsync2()
    {
        // CLEQSFPInsuranceScore_3046e8Page.EQSFPInputInsuranceScoreInformation_0242_08f3f1Async
        await _ui.FillAsync(_locators.EntityType, _data.Resolve("{{data:entity_type_296}}"));
        await _ui.PressAsync(_locators.InsuranceScoreConsent, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.InsuranceScoreConsent, "SHIFTTAB");
        await _ui.PressAsync(_locators.InsuranceScoreConsent, "SCROLL[-3]");
        // CLEQSFPInsuranceScoreCLEQCommonWaitOnLoadingIndicator_314f5bPage.EQLoadingIndicatorWait_0243_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPInsuranceScore_3046e8Page.EQSFPInputInsuranceScoreInformation_0244_08f3f1Async
        await _ui.ClickAsync(_locators.PrimaryInsured);
        // CLEQSFPInsuranceScore_3046e8Page.TBoxWait_0245_08f3f1Async
        await Task.Delay(1000);
        // CLEQSFPInsuranceScore_3046e8Page.EQSFPInputInsuranceScoreInformation_0246_08f3f1Async
        await _ui.ClickAsync(_locators.InsuranceScoreConsent);
        await _ui.WaitAsync(_locators.Accept, "Exists");
        await _ui.ClickAsync(_locators.Accept);
        // CLEQSFPInsuranceScoreCLEQCommonWaitOnLoadingIndicator_314f5bPage.EQLoadingIndicatorWait_0247_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0248_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_12}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0249_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading))
        {
        await _ui.VerifyAsync(_locators.ScreenHeading, _data.Resolve("Absent"), "");
        }
    }

}