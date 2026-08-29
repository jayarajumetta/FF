using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class UnderwritingPage
{
    private readonly BrowserSession _browser;
    private readonly UnderwritingLocators _locators;
    private readonly UiActions _ui;

    public UnderwritingPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new UnderwritingLocators(browser.Page);
        _ui = ui;
    }

    public Task WaitForAcceptAsync(string expected) =>
        _ui.WaitAsync(_locators.Accept, expected, new ControlIntent("Underwriting", "Accept"));

    public Task ClickAcceptAsync() =>
        _ui.ClickAsync(_locators.Accept, new ControlIntent("Underwriting", "Accept"));

    public Task WaitForUnderwritingInfoCommercialPropertyHistoryCommercialGeneralLiabilityHistoryAsync(string expected) =>
        _ui.WaitAsync(_locators.UnderwritingInfoCommercialPropertyHistoryCommercialGeneralLiabilityHistory, expected, new ControlIntent("Underwriting", "UnderwritingInfoCommercialPropertyHistoryCommercialGeneralLiabilityHistory"));

    public Task ClickUnderwritingInfoNavigationCommercialGeneralLiabilityHistoryAsync() =>
        _ui.ClickAsync(_locators.UnderwritingInfoNavigationCommercialGeneralLiabilityHistory, new ControlIntent("Underwriting", "UnderwritingInfoNavigationCommercialGeneralLiabilityHistory"));

    public Task ClickCommercialPropertyHistoryAsync() =>
        _ui.ClickAsync(_locators.CommercialPropertyHistory, new ControlIntent("Underwriting", "CommercialPropertyHistory"));

    public Task WaitForUnderwritingInfoGeneralUWQuestionsGeneralUWQuestionsAsync(string expected) =>
        _ui.WaitAsync(_locators.UnderwritingInfoGeneralUWQuestionsGeneralUWQuestions, expected, new ControlIntent("Underwriting", "UnderwritingInfoGeneralUWQuestionsGeneralUWQuestions"));

    public Task ClickUnderwritingInfoNavigationGeneralUWQuestionsAsync() =>
        _ui.ClickAsync(_locators.UnderwritingInfoNavigationGeneralUWQuestions, new ControlIntent("Underwriting", "UnderwritingInfoNavigationGeneralUWQuestions"));

    public Task WaitForInsuranceScoreAsync(string expected) =>
        _ui.WaitAsync(_locators.InsuranceScore, expected, new ControlIntent("Underwriting", "InsuranceScore"));

    public Task ClickInsuranceScoreAsync() =>
        _ui.ClickAsync(_locators.InsuranceScore, new ControlIntent("Underwriting", "InsuranceScore"));

    public Task ClickInsuranceScoreConsentAsync() =>
        _ui.ClickAsync(_locators.InsuranceScoreConsent, new ControlIntent("Underwriting", "InsuranceScoreConsent"));

    public Task EnterUnderwritingInfoCommercialPropertyHistoryIsThereAPriorCarrierAsync(string value) =>
        _ui.FillAsync(_locators.UnderwritingInfoCommercialPropertyHistoryIsThereAPriorCarrier, value, new ControlIntent("Underwriting", "UnderwritingInfoCommercialPropertyHistoryIsThereAPriorCarrier"));

    public Task PressUnderwritingInfoCommercialPropertyHistoryIsThereAPriorCarrierAsync(string key) =>
        _ui.PressAsync(_locators.UnderwritingInfoCommercialPropertyHistoryIsThereAPriorCarrier, key, new ControlIntent("Underwriting", "UnderwritingInfoCommercialPropertyHistoryIsThereAPriorCarrier"));

    public Task EnterUnderwritingInfoCommercialGeneralLiabilityHistoryIsThereAPriorCarrierAsync(string value) =>
        _ui.FillAsync(_locators.UnderwritingInfoCommercialGeneralLiabilityHistoryIsThereAPriorCarrier, value, new ControlIntent("Underwriting", "UnderwritingInfoCommercialGeneralLiabilityHistoryIsThereAPriorCarrier"));

    public Task PressUnderwritingInfoCommercialGeneralLiabilityHistoryIsThereAPriorCarrierAsync(string key) =>
        _ui.PressAsync(_locators.UnderwritingInfoCommercialGeneralLiabilityHistoryIsThereAPriorCarrier, key, new ControlIntent("Underwriting", "UnderwritingInfoCommercialGeneralLiabilityHistoryIsThereAPriorCarrier"));

    public Task EnterUnderwritingInfoOtherInsuranceHistoryIsThereAPriorCarrierAsync(string value) =>
        _ui.FillAsync(_locators.UnderwritingInfoOtherInsuranceHistoryIsThereAPriorCarrier, value, new ControlIntent("Underwriting", "UnderwritingInfoOtherInsuranceHistoryIsThereAPriorCarrier"));

    public Task PressUnderwritingInfoOtherInsuranceHistoryIsThereAPriorCarrierAsync(string key) =>
        _ui.PressAsync(_locators.UnderwritingInfoOtherInsuranceHistoryIsThereAPriorCarrier, key, new ControlIntent("Underwriting", "UnderwritingInfoOtherInsuranceHistoryIsThereAPriorCarrier"));

    public Task WaitForUnderwritingInfoOtherInsuranceHistoryOtherInsuranceHistoryAsync(string expected) =>
        _ui.WaitAsync(_locators.UnderwritingInfoOtherInsuranceHistoryOtherInsuranceHistory, expected, new ControlIntent("Underwriting", "UnderwritingInfoOtherInsuranceHistoryOtherInsuranceHistory"));

    public Task ClickUnderwritingInfoNavigationOtherInsuranceHistoryAsync() =>
        _ui.ClickAsync(_locators.UnderwritingInfoNavigationOtherInsuranceHistory, new ControlIntent("Underwriting", "UnderwritingInfoNavigationOtherInsuranceHistory"));

    public Task VerifyReferenceNumberAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ReferenceNumber, expected, property, new ControlIntent("Underwriting", "ReferenceNumber"));

    public Task VerifyTheInsuranceScoreServiceHasReturnedTheFollowingErrorCREDITVENDORUNREACHABLEPLEASEREPROCESSAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.TheInsuranceScoreServiceHasReturnedTheFollowingErrorCREDITVENDORUNREACHABLEPLEASEREPROCESS, expected, property, new ControlIntent("Underwriting", "TheInsuranceScoreServiceHasReturnedTheFollowingErrorCREDITVENDORUNREACHABLEPLEASEREPROCESS"));

    public Task ClickUpdateAnswersAsync() =>
        _ui.ClickAsync(_locators.UpdateAnswers, new ControlIntent("Underwriting", "UpdateAnswers"));

    public Task PauseAsync(int milliseconds) =>
        Task.Delay(milliseconds);


    public Task EnterUnderwritingInfoCommercialPropertyHistoryIsThereAPriorCarrierSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.UnderwritingInfoCommercialPropertyHistoryIsThereAPriorCarrier, value, new ControlIntent("Underwriting", "UnderwritingInfoCommercialPropertyHistoryIsThereAPriorCarrier"), delayMs);

    public Task EnterUnderwritingInfoCommercialGeneralLiabilityHistoryIsThereAPriorCarrierSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.UnderwritingInfoCommercialGeneralLiabilityHistoryIsThereAPriorCarrier, value, new ControlIntent("Underwriting", "UnderwritingInfoCommercialGeneralLiabilityHistoryIsThereAPriorCarrier"), delayMs);

    public Task EnterUnderwritingInfoOtherInsuranceHistoryIsThereAPriorCarrierSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.UnderwritingInfoOtherInsuranceHistoryIsThereAPriorCarrier, value, new ControlIntent("Underwriting", "UnderwritingInfoOtherInsuranceHistoryIsThereAPriorCarrier"), delayMs);
}
