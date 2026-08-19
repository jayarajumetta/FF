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

    public Task WaitForCommercialGeneralLiabilityHistoryC65BFAsync(string expected) =>
        _ui.WaitAsync(_locators.CommercialGeneralLiabilityHistoryC65BF, expected, new ControlIntent("Underwriting", "CommercialGeneralLiabilityHistoryC65BF"));

    public Task ClickCommercialGeneralLiabilityHistoryE02F8Async() =>
        _ui.ClickAsync(_locators.CommercialGeneralLiabilityHistoryE02F8, new ControlIntent("Underwriting", "CommercialGeneralLiabilityHistoryE02F8"));

    public Task WaitForCommercialPropertyHistory76D22Async(string expected) =>
        _ui.WaitAsync(_locators.CommercialPropertyHistory76D22, expected, new ControlIntent("Underwriting", "CommercialPropertyHistory76D22"));

    public Task ClickCommercialPropertyHistoryE6A7FAsync() =>
        _ui.ClickAsync(_locators.CommercialPropertyHistoryE6A7F, new ControlIntent("Underwriting", "CommercialPropertyHistoryE6A7F"));

    public Task WaitForGeneralUWQuestions55852Async(string expected) =>
        _ui.WaitAsync(_locators.GeneralUWQuestions55852, expected, new ControlIntent("Underwriting", "GeneralUWQuestions55852"));

    public Task ClickGeneralUWQuestionsBFB08Async() =>
        _ui.ClickAsync(_locators.GeneralUWQuestionsBFB08, new ControlIntent("Underwriting", "GeneralUWQuestionsBFB08"));

    public Task WaitForInsuranceScoreAsync(string expected) =>
        _ui.WaitAsync(_locators.InsuranceScore, expected, new ControlIntent("Underwriting", "InsuranceScore"));

    public Task ClickInsuranceScoreAsync() =>
        _ui.ClickAsync(_locators.InsuranceScore, new ControlIntent("Underwriting", "InsuranceScore"));

    public Task ClickInsuranceScoreConsentAsync() =>
        _ui.ClickAsync(_locators.InsuranceScoreConsent, new ControlIntent("Underwriting", "InsuranceScoreConsent"));

    public Task EnterIsThereAPriorCarrier5D30EAsync(string value) =>
        _ui.FillAsync(_locators.IsThereAPriorCarrier5D30E, value, new ControlIntent("Underwriting", "IsThereAPriorCarrier5D30E"));

    public Task PressIsThereAPriorCarrier5D30EAsync(string key) =>
        _ui.PressAsync(_locators.IsThereAPriorCarrier5D30E, key, new ControlIntent("Underwriting", "IsThereAPriorCarrier5D30E"));

    public Task EnterIsThereAPriorCarrierA9EB5Async(string value) =>
        _ui.FillAsync(_locators.IsThereAPriorCarrierA9EB5, value, new ControlIntent("Underwriting", "IsThereAPriorCarrierA9EB5"));

    public Task PressIsThereAPriorCarrierA9EB5Async(string key) =>
        _ui.PressAsync(_locators.IsThereAPriorCarrierA9EB5, key, new ControlIntent("Underwriting", "IsThereAPriorCarrierA9EB5"));

    public Task EnterIsThereAPriorCarrierEFB4FAsync(string value) =>
        _ui.FillAsync(_locators.IsThereAPriorCarrierEFB4F, value, new ControlIntent("Underwriting", "IsThereAPriorCarrierEFB4F"));

    public Task PressIsThereAPriorCarrierEFB4FAsync(string key) =>
        _ui.PressAsync(_locators.IsThereAPriorCarrierEFB4F, key, new ControlIntent("Underwriting", "IsThereAPriorCarrierEFB4F"));

    public Task WaitForOtherInsuranceHistory416B1Async(string expected) =>
        _ui.WaitAsync(_locators.OtherInsuranceHistory416B1, expected, new ControlIntent("Underwriting", "OtherInsuranceHistory416B1"));

    public Task ClickOtherInsuranceHistory5AFD8Async() =>
        _ui.ClickAsync(_locators.OtherInsuranceHistory5AFD8, new ControlIntent("Underwriting", "OtherInsuranceHistory5AFD8"));

    public Task VerifyReferenceNumberAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ReferenceNumber, expected, property, new ControlIntent("Underwriting", "ReferenceNumber"));

    public Task VerifyTheInsuranceScoreServiceHasReturnedTheFollowingErrorCREDITVENDORUNREACHABLEPLEASEREPROCESSAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.TheInsuranceScoreServiceHasReturnedTheFollowingErrorCREDITVENDORUNREACHABLEPLEASEREPROCESS, expected, property, new ControlIntent("Underwriting", "TheInsuranceScoreServiceHasReturnedTheFollowingErrorCREDITVENDORUNREACHABLEPLEASEREPROCESS"));

    public Task ClickUpdateAnswersAsync() =>
        _ui.ClickAsync(_locators.UpdateAnswers, new ControlIntent("Underwriting", "UpdateAnswers"));

    public Task PauseAsync(int milliseconds) =>
        Task.Delay(milliseconds);


}
