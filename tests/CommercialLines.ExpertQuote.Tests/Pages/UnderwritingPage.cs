using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

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

    public Task PressBuildingEligibilityQuestionsNoneOfTheAboveCheckboxAngularAsync(string key) =>
        _ui.PressAsync(_locators.BuildingEligibilityQuestionsNoneOfTheAboveCheckboxAngular, key, new ControlIntent("Underwriting", "BuildingEligibilityQuestionsNoneOfTheAboveCheckboxAngular"));

    public Task EnterEntityTypeAsync(string value) =>
        _ui.FillAsync(_locators.EntityType, value, new ControlIntent("Underwriting", "EntityType"));

    public Task PressInsuranceScoreConsentAsync(string key) =>
        _ui.PressAsync(_locators.InsuranceScoreConsent, key, new ControlIntent("Underwriting", "InsuranceScoreConsent"));

    public Task ClickInsuranceScoreConsentAsync() =>
        _ui.ClickAsync(_locators.InsuranceScoreConsent, new ControlIntent("Underwriting", "InsuranceScoreConsent"));

    public Task WaitForLoadingAsync(string expected) =>
        _ui.WaitAsync(_locators.Loading, expected, new ControlIntent("Underwriting", "Loading"));

    public Task PressNoneOfTheAboveCheckBoxAsync(string key) =>
        _ui.PressAsync(_locators.NoneOfTheAboveCheckBox, key, new ControlIntent("Underwriting", "NoneOfTheAboveCheckBox"));

    public Task<string> CapturePremiumAsync(string property = "") =>
        _ui.CaptureAsync(_locators.Premium, property, new ControlIntent("Underwriting", "Premium"));

    public Task ClickPrimaryInsuredAsync() =>
        _ui.ClickAsync(_locators.PrimaryInsured, new ControlIntent("Underwriting", "PrimaryInsured"));

    public Task ClickSaveAsync() =>
        _ui.ClickAsync(_locators.Save, new ControlIntent("Underwriting", "Save"));

    public Task VerifyScreenHeadingAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ScreenHeading, expected, property, new ControlIntent("Underwriting", "ScreenHeading"));

    public Task<bool> IsScreenHeadingPresentAsync() =>
        _ui.ExistsAsync(_locators.ScreenHeading);

    public Task VerifyTABLERowCellExplicitName1Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.TABLERowCellExplicitName1, expected, property, new ControlIntent("Underwriting", "TABLERowCellExplicitName1"));

    public Task PauseAsync(int milliseconds) =>
        Task.Delay(milliseconds);

}
