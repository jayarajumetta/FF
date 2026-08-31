using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class PolicyInformationPage
{
    private readonly BrowserSession _browser;
    private readonly PolicyInformationLocators _locators;
    private readonly UiActions _ui;

    public PolicyInformationPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new PolicyInformationLocators(browser.Page);
        _ui = ui;
    }

    public Task EnterCarrierAsync(string value) =>
        _ui.FillAsync(_locators.Carrier, value, new ControlIntent("PolicyInformation", "Carrier"));

    public Task PressCarrierAsync(string key) =>
        _ui.PressAsync(_locators.Carrier, key, new ControlIntent("PolicyInformation", "Carrier"));

    public Task WaitForClientAsync(string expected) =>
        _ui.WaitAsync(_locators.Client, expected, new ControlIntent("PolicyInformation", "Client"));

    public Task WaitForDetailAsync(string expected) =>
        _ui.WaitAsync(_locators.Detail, expected, new ControlIntent("PolicyInformation", "Detail"));

    public Task EnterEffectiveDateAsync(string value) =>
        _ui.FillAsync(_locators.EffectiveDate, value, new ControlIntent("PolicyInformation", "EffectiveDate"));

    public Task PressEffectiveDateAsync(string key) =>
        _ui.PressAsync(_locators.EffectiveDate, key, new ControlIntent("PolicyInformation", "EffectiveDate"));

    public Task ClickEnterPriorLossInformationAsync() =>
        _ui.ClickAsync(_locators.EnterPriorLossInformation, new ControlIntent("PolicyInformation", "EnterPriorLossInformation"));

    public Task EnterExpirationDateAsync(string value) =>
        _ui.FillAsync(_locators.ExpirationDate, value, new ControlIntent("PolicyInformation", "ExpirationDate"));

    public Task PressExpirationDateAsync(string key) =>
        _ui.PressAsync(_locators.ExpirationDate, key, new ControlIntent("PolicyInformation", "ExpirationDate"));

    public Task ClickInsuranceHistoryAsync() =>
        _ui.ClickAsync(_locators.InsuranceHistory, new ControlIntent("PolicyInformation", "InsuranceHistory"));

    public Task WaitForIsThereAPriorCarrierAsync(string expected) =>
        _ui.WaitAsync(_locators.IsThereAPriorCarrier, expected, new ControlIntent("PolicyInformation", "IsThereAPriorCarrier"));

    public Task EnterIsThereAPriorCarrierAsync(string value) =>
        _ui.FillAsync(_locators.IsThereAPriorCarrier, value, new ControlIntent("PolicyInformation", "IsThereAPriorCarrier"));

    public Task PressIsThereAPriorCarrierAsync(string key) =>
        _ui.PressAsync(_locators.IsThereAPriorCarrier, key, new ControlIntent("PolicyInformation", "IsThereAPriorCarrier"));

    public Task ClickIsThereAPriorCarrierAsync() =>
        _ui.ClickAsync(_locators.IsThereAPriorCarrier, new ControlIntent("PolicyInformation", "IsThereAPriorCarrier"));

    public Task WaitForLossExperienceHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.LossExperienceHeading, expected, new ControlIntent("PolicyInformation", "LossExperienceHeading"));

    public Task EnterModificationFactorAsync(string value) =>
        _ui.FillAsync(_locators.ModificationFactor, value, new ControlIntent("PolicyInformation", "ModificationFactor"));

    public Task PressModificationFactorAsync(string key) =>
        _ui.PressAsync(_locators.ModificationFactor, key, new ControlIntent("PolicyInformation", "ModificationFactor"));

    public Task VerifyNoKnownLossesAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.NoKnownLosses, expected, property, new ControlIntent("PolicyInformation", "NoKnownLosses"));

    public Task SetNoKnownLossesAsync(string value) =>
        _ui.SmartSetAsync(_locators.NoKnownLosses, value, new ControlIntent("PolicyInformation", "NoKnownLosses"));

    public Task PressNoKnownLossesAsync(string key) =>
        _ui.PressAsync(_locators.NoKnownLosses, key, new ControlIntent("PolicyInformation", "NoKnownLosses"));

    public Task ClickOtherInsuranceHistoryOKAsync() =>
        _ui.ClickAsync(_locators.OtherInsuranceHistoryOK, new ControlIntent("PolicyInformation", "OtherInsuranceHistoryOK"));

    public Task EnterPolicyNumberAsync(string value) =>
        _ui.FillAsync(_locators.PolicyNumber, value, new ControlIntent("PolicyInformation", "PolicyNumber"));

    public Task PressPolicyNumberAsync(string key) =>
        _ui.PressAsync(_locators.PolicyNumber, key, new ControlIntent("PolicyInformation", "PolicyNumber"));

    public Task EnterPolicyTypeAsync(string value) =>
        _ui.FillAsync(_locators.PolicyType, value, new ControlIntent("PolicyInformation", "PolicyType"));

    public Task PressPolicyTypeAsync(string key) =>
        _ui.PressAsync(_locators.PolicyType, key, new ControlIntent("PolicyInformation", "PolicyType"));

    public Task ClickReturnToQuoteAsync() =>
        _ui.ClickAsync(_locators.ReturnToQuote, new ControlIntent("PolicyInformation", "ReturnToQuote"));

    public Task EnterTotalPremiumAsync(string value) =>
        _ui.FillAsync(_locators.TotalPremium, value, new ControlIntent("PolicyInformation", "TotalPremium"));

    public Task PressTotalPremiumAsync(string key) =>
        _ui.PressAsync(_locators.TotalPremium, key, new ControlIntent("PolicyInformation", "TotalPremium"));

    public Task PauseAsync(int milliseconds) =>
        Task.Delay(milliseconds);


    public Task EnterCarrierSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Carrier, value, new ControlIntent("PolicyInformation", "Carrier"), delayMs);

    public Task EnterEffectiveDateSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.EffectiveDate, value, new ControlIntent("PolicyInformation", "EffectiveDate"), delayMs);

    public Task EnterExpirationDateSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ExpirationDate, value, new ControlIntent("PolicyInformation", "ExpirationDate"), delayMs);

    public Task EnterIsThereAPriorCarrierSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.IsThereAPriorCarrier, value, new ControlIntent("PolicyInformation", "IsThereAPriorCarrier"), delayMs);

    public Task EnterModificationFactorSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ModificationFactor, value, new ControlIntent("PolicyInformation", "ModificationFactor"), delayMs);

    public Task EnterPolicyNumberSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PolicyNumber, value, new ControlIntent("PolicyInformation", "PolicyNumber"), delayMs);

    public Task EnterPolicyTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PolicyType, value, new ControlIntent("PolicyInformation", "PolicyType"), delayMs);

    public Task EnterTotalPremiumSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.TotalPremium, value, new ControlIntent("PolicyInformation", "TotalPremium"), delayMs);
}
