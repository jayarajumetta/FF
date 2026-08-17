using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class DriversPage
{
    private readonly BrowserSession _browser;
    private readonly DriversLocators _locators;
    private readonly UiActions _ui;

    public DriversPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new DriversLocators(browser.Page);
        _ui = ui;
    }

    public Task ClickCLOSEQUOTEAsync() =>
        _ui.ClickAsync(_locators.CLOSEQUOTE, new ControlIntent("Drivers", "CLOSEQUOTE"));

    public Task WaitForCONTINUEAsync(string expected) =>
        _ui.WaitAsync(_locators.CONTINUE, expected, new ControlIntent("Drivers", "CONTINUE"));

    public Task VerifyCONTINUEAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.CONTINUE, expected, property, new ControlIntent("Drivers", "CONTINUE"));

    public Task ClickCONTINUEAsync() =>
        _ui.ClickAsync(_locators.CONTINUE, new ControlIntent("Drivers", "CONTINUE"));

    public Task ClickDriver1PrincipalOccasionalAsync() =>
        _ui.ClickAsync(_locators.Driver1PrincipalOccasional, new ControlIntent("Drivers", "Driver1PrincipalOccasional"));

    public Task ClickDriver1VehicleAsync() =>
        _ui.ClickAsync(_locators.Driver1Vehicle, new ControlIntent("Drivers", "Driver1Vehicle"));

    public Task PressDriver2PrincipalOccasionalAsync(string key) =>
        _ui.PressAsync(_locators.Driver2PrincipalOccasional, key, new ControlIntent("Drivers", "Driver2PrincipalOccasional"));

    public Task ClickDriver2PrincipalOccasionalAsync() =>
        _ui.ClickAsync(_locators.Driver2PrincipalOccasional, new ControlIntent("Drivers", "Driver2PrincipalOccasional"));

    public Task PressDriver2VehicleAsync(string key) =>
        _ui.PressAsync(_locators.Driver2Vehicle, key, new ControlIntent("Drivers", "Driver2Vehicle"));

    public Task ClickDriver2VehicleAsync() =>
        _ui.ClickAsync(_locators.Driver2Vehicle, new ControlIntent("Drivers", "Driver2Vehicle"));

    public Task PressDriver3PrincipalOccasionalAsync(string key) =>
        _ui.PressAsync(_locators.Driver3PrincipalOccasional, key, new ControlIntent("Drivers", "Driver3PrincipalOccasional"));

    public Task ClickDriver3PrincipalOccasionalAsync() =>
        _ui.ClickAsync(_locators.Driver3PrincipalOccasional, new ControlIntent("Drivers", "Driver3PrincipalOccasional"));

    public Task PressDriver3VehicleAsync(string key) =>
        _ui.PressAsync(_locators.Driver3Vehicle, key, new ControlIntent("Drivers", "Driver3Vehicle"));

    public Task ClickDriver3VehicleAsync() =>
        _ui.ClickAsync(_locators.Driver3Vehicle, new ControlIntent("Drivers", "Driver3Vehicle"));

    public Task PressDriver4PrincipalOccasionalAsync(string key) =>
        _ui.PressAsync(_locators.Driver4PrincipalOccasional, key, new ControlIntent("Drivers", "Driver4PrincipalOccasional"));

    public Task ClickDriver4PrincipalOccasionalAsync() =>
        _ui.ClickAsync(_locators.Driver4PrincipalOccasional, new ControlIntent("Drivers", "Driver4PrincipalOccasional"));

    public Task PressDriver4VehicleAsync(string key) =>
        _ui.PressAsync(_locators.Driver4Vehicle, key, new ControlIntent("Drivers", "Driver4Vehicle"));

    public Task ClickDriver4VehicleAsync() =>
        _ui.ClickAsync(_locators.Driver4Vehicle, new ControlIntent("Drivers", "Driver4Vehicle"));

    public Task PressDriver5PrincipalOccasionalAsync(string key) =>
        _ui.PressAsync(_locators.Driver5PrincipalOccasional, key, new ControlIntent("Drivers", "Driver5PrincipalOccasional"));

    public Task ClickDriver5PrincipalOccasionalAsync() =>
        _ui.ClickAsync(_locators.Driver5PrincipalOccasional, new ControlIntent("Drivers", "Driver5PrincipalOccasional"));

    public Task PressDriver5VehicleAsync(string key) =>
        _ui.PressAsync(_locators.Driver5Vehicle, key, new ControlIntent("Drivers", "Driver5Vehicle"));

    public Task ClickDriver5VehicleAsync() =>
        _ui.ClickAsync(_locators.Driver5Vehicle, new ControlIntent("Drivers", "Driver5Vehicle"));

    public Task PressDriverInformationNextAsync(string key) =>
        _ui.PressAsync(_locators.DriverInformationNext, key, new ControlIntent("Drivers", "DriverInformationNext"));

    public Task ClickDriverInformationNextAsync() =>
        _ui.ClickAsync(_locators.DriverInformationNext, new ControlIntent("Drivers", "DriverInformationNext"));

    public Task ClickExistingClient1Async() =>
        _ui.ClickAsync(_locators.ExistingClient1, new ControlIntent("Drivers", "ExistingClient1"));

    public Task VerifyIneligibleQuoteAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.IneligibleQuote, expected, property, new ControlIntent("Drivers", "IneligibleQuote"));

    public Task<bool> IsIneligibleQuotePresentAsync() =>
        _ui.ExistsAsync(_locators.IneligibleQuote);

    public Task WaitForLoadingAsync(string expected) =>
        _ui.WaitAsync(_locators.Loading, expected, new ControlIntent("Drivers", "Loading"));

    public Task ClickMultipleDriverAssignmentNextAsync() =>
        _ui.ClickAsync(_locators.MultipleDriverAssignmentNext, new ControlIntent("Drivers", "MultipleDriverAssignmentNext"));

}
