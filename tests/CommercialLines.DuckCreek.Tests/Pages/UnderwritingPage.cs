using InsuranceAutomation.Core;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class UnderwritingPage
{
    private readonly UnderwritingLocators _locators;
    private readonly ScenarioData _data;
    private readonly UiActions _ui;

    public UnderwritingPage(BrowserSession browser, ScenarioData data, UiActions ui)
    {
        _locators = new UnderwritingLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I run insurance score
    public async Task RunInsuranceScoreAsync()
    {
        // PolicyInfoInsuranceScore_19a5b4Page.InsuranceScore_0096_a1ba9cAsync
        await _ui.VerifyAsync(_locators.TheInsuranceScoreServiceHasReturnedTheFollowingErrorCREDITVENDORUNREACHABLEPLEASEREPROCESS, _data.Resolve("Exists"), "");
        // TBoxEvaluationTool_b95b5cPage.CheckIfItIsBAPVT_0097_a1ba9cAsync
        _data.Set("CheckIfItIsBAPVT", _data.Resolve("'{B[Product (LOB)]}' = 'BAP' && '{B[State]}'= 'VT'"));
        // PolicyInfoInsuranceScore_19a5b4Page.ClickInsuranceScoreConsentIfAvailable_0098_a1ba9cAsync
        await _ui.ClickAsync(_locators.InsuranceScoreConsent);
        await _ui.WaitAsync(_locators.Accept, "Exists");
        await _ui.ClickAsync(_locators.Accept);
        await _ui.WaitAsync(_locators.InsuranceScore, "Exists");
        // PolicyInfoInsuranceScore_19a5b4Page.ClickInsuranceScoreAndWaitForLoadingWindow_0099_a1ba9cAsync
        await _ui.ClickAsync(_locators.InsuranceScore);
        // PolicyInfoInsuranceScore_19a5b4Page.InsuranceScore_0100_a1ba9cAsync
        await _ui.VerifyAsync(_locators.ReferenceNumber, _data.Resolve("{{data:expected_reference_number_innertext_135}}"), "InnerText");
        // TBoxWait_7ea9e1Page.Wait12SecondForAMaxOf60Seconds_0101_a1ba9cAsync
        await Task.Delay(1000);
        // TBoxWait_7ea9e1Page.Wait12Second_0105_a1ba9cAsync
        await Task.Delay(1000);
    }

    // Business step: I run insurance score
    public async Task RunInsuranceScoreAsync2()
    {
        // PolicyInfoInsuranceScore_19a5b4Page.InsuranceScore_0077_f90f36Async
        await _ui.VerifyAsync(_locators.TheInsuranceScoreServiceHasReturnedTheFollowingErrorCREDITVENDORUNREACHABLEPLEASEREPROCESS, _data.Resolve("Exists"), "");
        // TBoxEvaluationTool_b95b5cPage.CheckIfItIsBAPVT_0078_f90f36Async
        _data.Set("CheckIfItIsBAPVT", _data.Resolve("'{B[Product (LOB)]}' = 'BAP' && '{B[State]}'= 'VT'"));
        // PolicyInfoInsuranceScore_19a5b4Page.ClickInsuranceScoreConsentIfAvailable_0079_f90f36Async
        await _ui.ClickAsync(_locators.InsuranceScoreConsent);
        await _ui.WaitAsync(_locators.Accept, "Exists");
        await _ui.ClickAsync(_locators.Accept);
        await _ui.WaitAsync(_locators.InsuranceScore, "Exists");
        // PolicyInfoInsuranceScore_19a5b4Page.ClickInsuranceScoreAndWaitForLoadingWindow_0080_f90f36Async
        await _ui.ClickAsync(_locators.InsuranceScore);
        // PolicyInfoInsuranceScore_19a5b4Page.InsuranceScore_0081_f90f36Async
        await _ui.VerifyAsync(_locators.ReferenceNumber, _data.Resolve("{{data:expected_reference_number_innertext_96}}"), "InnerText");
        // TBoxWait_7ea9e1Page.Wait12SecondForAMaxOf60Seconds_0082_f90f36Async
        await Task.Delay(1000);
        // TBoxWait_7ea9e1Page.Wait12Second_0086_f90f36Async
        await Task.Delay(1000);
    }

    // Business step: I run insurance score
    public async Task RunInsuranceScoreAsync3()
    {
        // PolicyInfoInsuranceScore_19a5b4Page.InsuranceScore_0084_aad19bAsync
        await _ui.VerifyAsync(_locators.TheInsuranceScoreServiceHasReturnedTheFollowingErrorCREDITVENDORUNREACHABLEPLEASEREPROCESS, _data.Resolve("Exists"), "");
        // TBoxEvaluationTool_b95b5cPage.CheckIfItIsBAPVT_0085_aad19bAsync
        _data.Set("CheckIfItIsBAPVT", _data.Resolve("'{B[Product (LOB)]}' = 'BAP' && '{B[State]}'= 'VT'"));
        // PolicyInfoInsuranceScore_19a5b4Page.ClickInsuranceScoreConsentIfAvailable_0086_aad19bAsync
        await _ui.ClickAsync(_locators.InsuranceScoreConsent);
        await _ui.WaitAsync(_locators.Accept, "Exists");
        await _ui.ClickAsync(_locators.Accept);
        await _ui.WaitAsync(_locators.InsuranceScore, "Exists");
        // PolicyInfoInsuranceScore_19a5b4Page.ClickInsuranceScoreAndWaitForLoadingWindow_0087_aad19bAsync
        await _ui.ClickAsync(_locators.InsuranceScore);
        // PolicyInfoInsuranceScore_19a5b4Page.InsuranceScore_0088_aad19bAsync
        await _ui.VerifyAsync(_locators.ReferenceNumber, _data.Resolve("{{data:expected_reference_number_innertext_120}}"), "InnerText");
        // TBoxWait_7ea9e1Page.Wait12SecondForAMaxOf60Seconds_0089_aad19bAsync
        await Task.Delay(1000);
        // TBoxWait_7ea9e1Page.Wait12Second_0093_aad19bAsync
        await Task.Delay(1000);
    }

    // Business step: I answer General UW Questions
    public async Task AnswerGeneralUWQuestionsAsync()
    {
        // CPPClientUnderwritingInfoNavigation_75adbdPage.CPPClientUnderwritingInfoNavigation_0268_aad19bAsync
        await _ui.ClickAsync(_locators.GeneralUWQuestionsBFB08);
        // UnderwritingInfoGeneralUWQuestions_3222c4Page.UnderwritingInfoGeneralUWQuestions_0269_aad19bAsync
        await _ui.WaitAsync(_locators.GeneralUWQuestions55852, "Exists");
        await _ui.ClickAsync(_locators.UpdateAnswers);
    }

    // Business step: I answer General Liability History Questions
    public async Task AnswerGeneralLiabilityHistoryQuestionsAsync()
    {
        // CPPClientUnderwritingInfoNavigation_75adbdPage.CPPClientUnderwritingInfoNavigation_0270_aad19bAsync
        await _ui.ClickAsync(_locators.CommercialGeneralLiabilityHistoryE02F8);
        // CPPClientUnderwritingInfoCommercialGeneralLiabilityHistory_7572a9Page.CPPClientUnderwritingInfoCommercialGeneralLiabilityHistory_0271_aad19bAsync
        await _ui.WaitAsync(_locators.CommercialGeneralLiabilityHistoryC65BF, "Exists");
        await _ui.FillAsync(_locators.IsThereAPriorCarrierA9EB5, _data.Resolve("{{data:is_there_a_prior_carrier_625}}"));
        await _ui.PressAsync(_locators.IsThereAPriorCarrierA9EB5, "Tab");
        await _ui.PressAsync(_locators.IsThereAPriorCarrierA9EB5, "CLICK");
        await _ui.PressAsync(_locators.IsThereAPriorCarrierA9EB5, "Tab");
    }

    // Business step: I answer Commercial Property History Questions
    public async Task AnswerCommercialPropertyHistoryQuestionsAsync()
    {
        // CPPClientUnderwritingInfoNavigation_75adbdPage.CPPClientUnderwritingInfoNavigation_0272_aad19bAsync
        await _ui.ClickAsync(_locators.CommercialPropertyHistoryE6A7F);
        // CPPClientUnderwritingInfoCommercialPropertyHistory_3b98bbPage.CPPClientUnderwritingInfoCommercialPropertyHistory_0273_aad19bAsync
        await _ui.WaitAsync(_locators.CommercialPropertyHistory76D22, "Exists");
        await _ui.FillAsync(_locators.IsThereAPriorCarrier5D30E, _data.Resolve("{{data:is_there_a_prior_carrier_628}}"));
        await _ui.PressAsync(_locators.IsThereAPriorCarrier5D30E, "Tab");
        await _ui.PressAsync(_locators.IsThereAPriorCarrier5D30E, "CLICK");
        await _ui.PressAsync(_locators.IsThereAPriorCarrier5D30E, "Tab");
    }

    // Business step: I answer Other Insurance History Questions
    public async Task AnswerOtherInsuranceHistoryQuestionsAsync()
    {
        // CPPClientUnderwritingInfoNavigation_75adbdPage.CPPClientUnderwritingInfoNavigation_0274_aad19bAsync
        await _ui.ClickAsync(_locators.OtherInsuranceHistory5AFD8);
        // UnderwritingInfoOtherInsuranceHistory_b78753Page.UnderwritingInfoOtherInsuranceHistory_0275_aad19bAsync
        await _ui.WaitAsync(_locators.OtherInsuranceHistory416B1, "Exists");
        await _ui.FillAsync(_locators.IsThereAPriorCarrierEFB4F, _data.Resolve("{{data:is_there_a_prior_carrier_631}}"));
        await _ui.PressAsync(_locators.IsThereAPriorCarrierEFB4F, "Tab");
        await _ui.PressAsync(_locators.IsThereAPriorCarrierEFB4F, "CLICK");
        await _ui.PressAsync(_locators.IsThereAPriorCarrierEFB4F, "Tab");
    }

    // Business step: I run insurance score
    public async Task RunInsuranceScoreAsync4()
    {
        // PolicyInfoInsuranceScore_19a5b4Page.InsuranceScore_0089_677267Async
        await _ui.VerifyAsync(_locators.TheInsuranceScoreServiceHasReturnedTheFollowingErrorCREDITVENDORUNREACHABLEPLEASEREPROCESS, _data.Resolve("Exists"), "");
        // TBoxEvaluationTool_b95b5cPage.CheckIfItIsBAPVT_0090_677267Async
        _data.Set("CheckIfItIsBAPVT", _data.Resolve("'{B[Product (LOB)]}' = 'BAP' && '{B[State]}'= 'VT'"));
        // PolicyInfoInsuranceScore_19a5b4Page.ClickInsuranceScoreConsentIfAvailable_0091_677267Async
        await _ui.ClickAsync(_locators.InsuranceScoreConsent);
        await _ui.WaitAsync(_locators.Accept, "Exists");
        await _ui.ClickAsync(_locators.Accept);
        await _ui.WaitAsync(_locators.InsuranceScore, "Exists");
        // PolicyInfoInsuranceScore_19a5b4Page.ClickInsuranceScoreAndWaitForLoadingWindow_0092_677267Async
        await _ui.ClickAsync(_locators.InsuranceScore);
        // PolicyInfoInsuranceScore_19a5b4Page.InsuranceScore_0093_677267Async
        await _ui.VerifyAsync(_locators.ReferenceNumber, _data.Resolve("{{data:expected_reference_number_innertext_140}}"), "InnerText");
        // TBoxWait_7ea9e1Page.Wait12SecondForAMaxOf60Seconds_0094_677267Async
        await Task.Delay(1000);
        // TBoxWait_7ea9e1Page.Wait12Second_0098_677267Async
        await Task.Delay(1000);
    }

    // Business step: I run insurance score
    public async Task RunInsuranceScoreAsync5()
    {
        // PolicyInfoInsuranceScore_19a5b4Page.InsuranceScore_0100_a6f47eAsync
        await _ui.VerifyAsync(_locators.TheInsuranceScoreServiceHasReturnedTheFollowingErrorCREDITVENDORUNREACHABLEPLEASEREPROCESS, _data.Resolve("Exists"), "");
        // TBoxEvaluationTool_b95b5cPage.CheckIfItIsBAPVT_0101_a6f47eAsync
        _data.Set("CheckIfItIsBAPVT", _data.Resolve("'{B[Product (LOB)]}' = 'BAP' && '{B[State]}'= 'VT'"));
        // PolicyInfoInsuranceScore_19a5b4Page.ClickInsuranceScoreConsentIfAvailable_0102_a6f47eAsync
        await _ui.ClickAsync(_locators.InsuranceScoreConsent);
        await _ui.WaitAsync(_locators.Accept, "Exists");
        await _ui.ClickAsync(_locators.Accept);
        await _ui.WaitAsync(_locators.InsuranceScore, "Exists");
        // PolicyInfoInsuranceScore_19a5b4Page.ClickInsuranceScoreAndWaitForLoadingWindow_0103_a6f47eAsync
        await _ui.ClickAsync(_locators.InsuranceScore);
        // PolicyInfoInsuranceScore_19a5b4Page.InsuranceScore_0104_a6f47eAsync
        await _ui.VerifyAsync(_locators.ReferenceNumber, _data.Resolve("{{data:expected_reference_number_innertext_139}}"), "InnerText");
        // TBoxWait_7ea9e1Page.Wait12SecondForAMaxOf60Seconds_0105_a6f47eAsync
        await Task.Delay(1000);
        // TBoxWait_7ea9e1Page.Wait12Second_0109_a6f47eAsync
        await Task.Delay(1000);
    }

    // Business step: I run insurance score
    public async Task RunInsuranceScoreAsync6()
    {
        // PolicyInfoInsuranceScore_19a5b4Page.InsuranceScore_0089_a8e5f5Async
        await _ui.VerifyAsync(_locators.TheInsuranceScoreServiceHasReturnedTheFollowingErrorCREDITVENDORUNREACHABLEPLEASEREPROCESS, _data.Resolve("Exists"), "");
        // TBoxEvaluationTool_b95b5cPage.CheckIfItIsBAPVT_0090_a8e5f5Async
        _data.Set("CheckIfItIsBAPVT", _data.Resolve("'{B[Product (LOB)]}' = 'BAP' && '{B[State]}'= 'VT'"));
        // PolicyInfoInsuranceScore_19a5b4Page.ClickInsuranceScoreConsentIfAvailable_0091_a8e5f5Async
        await _ui.ClickAsync(_locators.InsuranceScoreConsent);
        await _ui.WaitAsync(_locators.Accept, "Exists");
        await _ui.ClickAsync(_locators.Accept);
        await _ui.WaitAsync(_locators.InsuranceScore, "Exists");
        // PolicyInfoInsuranceScore_19a5b4Page.ClickInsuranceScoreAndWaitForLoadingWindow_0092_a8e5f5Async
        await _ui.ClickAsync(_locators.InsuranceScore);
        // PolicyInfoInsuranceScore_19a5b4Page.InsuranceScore_0093_a8e5f5Async
        await _ui.VerifyAsync(_locators.ReferenceNumber, _data.Resolve("{{data:expected_reference_number_innertext_129}}"), "InnerText");
        // TBoxWait_7ea9e1Page.Wait12SecondForAMaxOf60Seconds_0094_a8e5f5Async
        await Task.Delay(1000);
        // TBoxWait_7ea9e1Page.Wait12Second_0098_a8e5f5Async
        await Task.Delay(1000);
    }

}
