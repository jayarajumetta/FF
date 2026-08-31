using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class VehiclesPage
{
    private readonly BrowserSession _browser;
    private readonly VehiclesLocators _locators;
    private readonly UiActions _ui;

    public VehiclesPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new VehiclesLocators(browser.Page);
        _ui = ui;
    }

    public Task EnterCarrierNameAsync(string value) =>
        _ui.FillAsync(_locators.CarrierName, value, new ControlIntent("Vehicles", "CarrierName"));

    public Task PressCarrierNameAsync(string key) =>
        _ui.PressAsync(_locators.CarrierName, key, new ControlIntent("Vehicles", "CarrierName"));

    public Task WaitForEffectiveDateAsync(string expected) =>
        _ui.WaitAsync(_locators.EffectiveDate, expected, new ControlIntent("Vehicles", "EffectiveDate"));

    public Task EnterEffectiveDateAsync(string value) =>
        _ui.FillAsync(_locators.EffectiveDate, value, new ControlIntent("Vehicles", "EffectiveDate"));

    public Task PressEffectiveDateAsync(string key) =>
        _ui.PressAsync(_locators.EffectiveDate, key, new ControlIntent("Vehicles", "EffectiveDate"));

    public Task EnterExpirationDateAsync(string value) =>
        _ui.FillAsync(_locators.ExpirationDate, value, new ControlIntent("Vehicles", "ExpirationDate"));

    public Task PressExpirationDateAsync(string key) =>
        _ui.PressAsync(_locators.ExpirationDate, key, new ControlIntent("Vehicles", "ExpirationDate"));

    public Task ClickIncludeMotorcycleLiabilityAsync() =>
        _ui.ClickAsync(_locators.IncludeMotorcycleLiability, new ControlIntent("Vehicles", "IncludeMotorcycleLiability"));

    public Task ClickIncludeRecreationalVehicleLiabilityAsync() =>
        _ui.ClickAsync(_locators.IncludeRecreationalVehicleLiability, new ControlIntent("Vehicles", "IncludeRecreationalVehicleLiability"));

    public Task EnterLiabilityLimitAsync(string value) =>
        _ui.FillAsync(_locators.LiabilityLimit, value, new ControlIntent("Vehicles", "LiabilityLimit"));

    public Task PressLiabilityLimitAsync(string key) =>
        _ui.PressAsync(_locators.LiabilityLimit, key, new ControlIntent("Vehicles", "LiabilityLimit"));

    public Task WaitForMotorcycleLiabilityAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Vehicles", "MotorcycleLiability"));

    public Task EnterPDLimitAsync(string value) =>
        _ui.FillAsync(_locators.PDLimit, value, new ControlIntent("Vehicles", "PDLimit"));

    public Task PressPDLimitAsync(string key) =>
        _ui.PressAsync(_locators.PDLimit, key, new ControlIntent("Vehicles", "PDLimit"));

    public Task WaitForPolicyCovgAsync(string expected) =>
        _ui.WaitAsync(_locators.PolicyCovg, expected, new ControlIntent("Vehicles", "PolicyCovg"));

    public Task EnterPolicyNumberAsync(string value) =>
        _ui.FillAsync(_locators.PolicyNumber, value, new ControlIntent("Vehicles", "PolicyNumber"));

    public Task PressPolicyNumberAsync(string key) =>
        _ui.PressAsync(_locators.PolicyNumber, key, new ControlIntent("Vehicles", "PolicyNumber"));

    public Task WaitForRecreationalVehicleLiabilityAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Vehicles", "RecreationalVehicleLiability"));

    public Task ClickRecreationalVehicleLiabilityAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Vehicles", "RecreationalVehicleLiability"));

    public Task WaitForRecreationalVehicleLiabilityHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Vehicles", "RecreationalVehicleLiabilityHeading"));

    public Task EnterTotalSubjectPremiumAsync(string value) =>
        _ui.FillAsync(_locators.TotalSubjectPremium, value, new ControlIntent("Vehicles", "TotalSubjectPremium"));

    public Task PressTotalSubjectPremiumAsync(string key) =>
        _ui.PressAsync(_locators.TotalSubjectPremium, key, new ControlIntent("Vehicles", "TotalSubjectPremium"));


    public Task EnterCarrierNameSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.CarrierName, value, new ControlIntent("Vehicles", "CarrierName"), delayMs);

    public Task EnterEffectiveDateSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.EffectiveDate, value, new ControlIntent("Vehicles", "EffectiveDate"), delayMs);

    public Task EnterExpirationDateSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ExpirationDate, value, new ControlIntent("Vehicles", "ExpirationDate"), delayMs);

    public Task EnterLiabilityLimitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.LiabilityLimit, value, new ControlIntent("Vehicles", "LiabilityLimit"), delayMs);

    public Task EnterPDLimitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PDLimit, value, new ControlIntent("Vehicles", "PDLimit"), delayMs);

    public Task EnterPolicyNumberSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PolicyNumber, value, new ControlIntent("Vehicles", "PolicyNumber"), delayMs);

    public Task EnterTotalSubjectPremiumSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.TotalSubjectPremium, value, new ControlIntent("Vehicles", "TotalSubjectPremium"), delayMs);
}
