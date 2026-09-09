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

    public Task EnterAgentCommentsAsync(string value) =>
        _ui.PressSequentiallyAsync(_locators.AgentComments, value, new ControlIntent("Underwriting", "AgentComments"));

    public Task EnterAgentComments2Async(string value) =>
        _ui.PressSequentiallyAsync(_locators.AgentComments2, value, new ControlIntent("Underwriting", "AgentComments2"));

    public async Task<bool> IsAgentCommentsVisibleAndEditableAsync()
    {
        try
        {
            await _locators.AgentComments.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 3000 });
        }
        catch (Exception ex) when (ex is PlaywrightException or TimeoutException)
        {
            return false;
        }
        return await _locators.AgentComments.IsVisibleAsync() && await _locators.AgentComments.IsEditableAsync();
    }

    public async Task<bool> IsAgentComments2VisibleAndEditableAsync()
    {
        try
        {
            await _locators.AgentComments2.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 3000 });
        }
        catch (Exception ex) when (ex is PlaywrightException or TimeoutException)
        {
            return false;
        }
        return await _locators.AgentComments2.IsVisibleAsync() && await _locators.AgentComments2.IsEditableAsync();
    }

    public Task ClickAcceptAsync() =>
        _ui.ClickAsync(_locators.Accept, new ControlIntent("Underwriting", "Accept"));

    public Task ClickReferToUWAsync() =>
        _ui.ClickAsync(_locators.ReferToUW, new ControlIntent("Underwriting", "ReferToUW"));

    public Task PressBuildingEligibilityQuestionsNoneOfTheAboveCheckboxAngularAsync(string key) =>
        _ui.PressAsync(_locators.BuildingEligibilityQuestionsNoneOfTheAboveCheckboxAngular, key, new ControlIntent("Underwriting", "BuildingEligibilityQuestionsNoneOfTheAboveCheckboxAngular"));

    public Task ClickBuildingEligibilityQuestionsNoneOfTheAboveCheckboxAngularAsync() =>
        _ui.ClickAsync(_locators.BuildingEligibilityQuestionsNoneOfTheAboveCheckboxAngular, new ControlIntent("Underwriting", "BuildingEligibilityQuestionsNoneOfTheAboveCheckboxAngular"));

    public Task EnterEntityTypeAsync(string value) =>
        _ui.FillAsync(_locators.EntityType, value, new ControlIntent("Underwriting", "EntityType"));

    public Task PressInsuranceScoreConsentAsync(string key) =>
        _ui.PressAsync(_locators.InsuranceScoreConsent, key, new ControlIntent("Underwriting", "InsuranceScoreConsent"));

    public Task ClickInsuranceScoreConsentAsync() =>
        _ui.ClickAsync(_locators.InsuranceScoreConsent, new ControlIntent("Underwriting", "InsuranceScoreConsent"));
public Task PressNoneOfTheAboveCheckBoxAsync(string key) =>
        _ui.PressAsync(_locators.NoneOfTheAboveCheckBox, key, new ControlIntent("Underwriting", "NoneOfTheAboveCheckBox"));

    public Task ClickNoneOfTheAboveCheckBoxAsync() =>
        _ui.ClickAsync(_locators.NoneOfTheAboveCheckBox, new ControlIntent("Underwriting", "NoneOfTheAboveCheckBox"));

    public Task<string> CapturePremiumAsync(string property = "") =>
        _ui.CaptureAsync(_locators.Premium, property, new ControlIntent("Underwriting", "Premium"));

    public Task ClickPrimaryInsuredAsync() =>
        _ui.ClickAsync(_locators.PrimaryInsured, new ControlIntent("Underwriting", "PrimaryInsured"));

    public Task ClickSaveAsync() =>
        _ui.ClickAsync(_locators.Save, new ControlIntent("Underwriting", "Save"));

    public Task<bool> IsKeepGoingConfirmPresentAsync() =>
        _ui.ExistsAsync(_locators.KeepGoingConfirm);

    public async Task ClickKeepGoingConfirmAsync()
    {
        var locator = _locators.KeepGoingConfirm;
        try
        {
            await _ui.ClickAsync(locator, new ControlIntent("Underwriting", "KeepGoingConfirm"));
        }
        catch (Exception ex) when (ex is TimeoutException or PlaywrightException)
        {
            await locator.ScrollIntoViewIfNeededAsync();
            try
            {
                await locator.ClickAsync(new LocatorClickOptions { Force = true, Timeout = 5000 });
            }
            catch (Exception ex2) when (ex2 is TimeoutException or PlaywrightException)
            {
                await locator.EvaluateAsync("el => el.click()");
            }
        }
    }

    public async Task ClickKeepGoingConfirmIfPresentAsync()
    {
        if (await IsKeepGoingConfirmPresentAsync())
            await ClickKeepGoingConfirmAsync();
    }

    public Task VerifyScreenHeadingAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ScreenHeading, expected, property, new ControlIntent("Underwriting", "ScreenHeading"));

    public Task<bool> IsScreenHeadingPresentAsync() =>
        _ui.ExistsAsync(_locators.ScreenHeading);

    public Task VerifyTABLERowCellExplicitName1Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.TABLERowCellExplicitName1, expected, property, new ControlIntent("Underwriting", "TABLERowCellExplicitName1"));

    public Task PauseAsync(int milliseconds) =>
        Task.Delay(milliseconds);


}
