using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class FormsPage
{
    private readonly BrowserSession _browser;
    private readonly FormsLocators _locators;
    private readonly UiActions _ui;

    public FormsPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new FormsLocators(browser.Page);
        _ui = ui;
    }

    public Task WaitForAdditionalInterestsAsync(string expected) =>
        _ui.WaitAsync(_locators.AdditionalInterests, expected, new ControlIntent("Forms", "AdditionalInterests"));

    public Task ClickAdditionalInterestsAsync() =>
        _ui.ClickAsync(_locators.AdditionalInterests, new ControlIntent("Forms", "AdditionalInterests"));

    public Task WaitForAddlInterestsAsync(string expected) =>
        _ui.WaitAsync(_locators.AddlInterests, expected, new ControlIntent("Forms", "AddlInterests"));

    public Task ClickBusinessownersAsync() =>
        _ui.ClickAsync(_locators.Businessowners, new ControlIntent("Forms", "Businessowners"));

    public Task WaitForBusinessownersHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.BusinessownersHeading, expected, new ControlIntent("Forms", "BusinessownersHeading"));

    public Task WaitForEffectiveDateAsync(string expected) =>
        _ui.WaitAsync(_locators.EffectiveDate, expected, new ControlIntent("Forms", "EffectiveDate"));

    public Task EnterEffectiveDateAsync(string value) =>
        _ui.FillAsync(_locators.EffectiveDate, value, new ControlIntent("Forms", "EffectiveDate"));

    public Task PressEffectiveDateAsync(string key) =>
        _ui.PressAsync(_locators.EffectiveDate, key, new ControlIntent("Forms", "EffectiveDate"));

    public Task VerifyEmployerSLiabilityCheckBoxAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.EmployerSLiabilityCheckBox, expected, property, new ControlIntent("Forms", "EmployerSLiabilityCheckBox"));

    public Task EnterExpirationDateAsync(string value) =>
        _ui.FillAsync(_locators.ExpirationDate, value, new ControlIntent("Forms", "ExpirationDate"));

    public Task PressExpirationDateAsync(string key) =>
        _ui.PressAsync(_locators.ExpirationDate, key, new ControlIntent("Forms", "ExpirationDate"));

    public Task WaitForHomeownerSLiabilityAsync(string expected) =>
        _ui.WaitAsync(_locators.HomeownerSLiability, expected, new ControlIntent("Forms", "HomeownerSLiability"));

    public Task PressHomeownerSLiabilityAsync(string key) =>
        _ui.PressAsync(_locators.HomeownerSLiability, key, new ControlIntent("Forms", "HomeownerSLiability"));

    public Task ClickHomeownerSLiabilityAsync() =>
        _ui.ClickAsync(_locators.HomeownerSLiability, new ControlIntent("Forms", "HomeownerSLiability"));

    public Task ClickImportPolicyDataButtonAsync() =>
        _ui.ClickAsync(_locators.ImportPolicyDataButton, new ControlIntent("Forms", "ImportPolicyDataButton"));

    public Task EnterLiabilityLimitAsync(string value) =>
        _ui.FillAsync(_locators.LiabilityLimit, value, new ControlIntent("Forms", "LiabilityLimit"));

    public Task PressLiabilityLimitAsync(string key) =>
        _ui.PressAsync(_locators.LiabilityLimit, key, new ControlIntent("Forms", "LiabilityLimit"));

    public Task VerifyLoadingMessageAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.LoadingMessage, expected, property, new ControlIntent("Forms", "LoadingMessage"));

    public Task EnterPDLimitAsync(string value) =>
        _ui.FillAsync(_locators.PDLimit, value, new ControlIntent("Forms", "PDLimit"));

    public Task PressPDLimitAsync(string key) =>
        _ui.PressAsync(_locators.PDLimit, key, new ControlIntent("Forms", "PDLimit"));

    public Task WaitForPersonalAutoAsync(string expected) =>
        _ui.WaitAsync(_locators.PersonalAuto, expected, new ControlIntent("Forms", "PersonalAuto"));

    public Task PressPersonalAutoAsync(string key) =>
        _ui.PressAsync(_locators.PersonalAuto, key, new ControlIntent("Forms", "PersonalAuto"));

    public Task ClickPersonalAutoAsync() =>
        _ui.ClickAsync(_locators.PersonalAuto, new ControlIntent("Forms", "PersonalAuto"));

    public Task EnterPolicyNumberAsync(string value) =>
        _ui.FillAsync(_locators.PolicyNumber, value, new ControlIntent("Forms", "PolicyNumber"));

    public Task PressPolicyNumberAsync(string key) =>
        _ui.PressAsync(_locators.PolicyNumber, key, new ControlIntent("Forms", "PolicyNumber"));

    public Task EnterSessionIDAsync(string value) =>
        _ui.FillAsync(_locators.SessionID, value, new ControlIntent("Forms", "SessionID"));

    public Task VerifyStatusCodeAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.StatusCode, expected, property, new ControlIntent("Forms", "StatusCode"));

    public Task EnterTotalSubjectPremiumAsync(string value) =>
        _ui.FillAsync(_locators.TotalSubjectPremium, value, new ControlIntent("Forms", "TotalSubjectPremium"));

    public Task PressTotalSubjectPremiumAsync(string key) =>
        _ui.PressAsync(_locators.TotalSubjectPremium, key, new ControlIntent("Forms", "TotalSubjectPremium"));

    public Task<string> CaptureValueAsync(string property = "") =>
        _ui.CaptureAsync(_locators.Value, property, new ControlIntent("Forms", "Value"));

    public Task WaitForWatercraftLiabilityAsync(string expected) =>
        _ui.WaitAsync(_locators.WatercraftLiability, expected, new ControlIntent("Forms", "WatercraftLiability"));

    public Task PressWatercraftLiabilityAsync(string key) =>
        _ui.PressAsync(_locators.WatercraftLiability, key, new ControlIntent("Forms", "WatercraftLiability"));

    public Task ClickWatercraftLiabilityAsync() =>
        _ui.ClickAsync(_locators.WatercraftLiability, new ControlIntent("Forms", "WatercraftLiability"));

    public Task PauseAsync(int milliseconds) =>
        Task.Delay(milliseconds);

}
