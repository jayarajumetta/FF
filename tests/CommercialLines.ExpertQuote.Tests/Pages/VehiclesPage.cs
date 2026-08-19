using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

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

    public Task WaitForAddCoverageAsync(string expected) =>
        _ui.WaitAsync(_locators.AddCoverage, expected, new ControlIntent("Vehicles", "AddCoverage"));

    public Task SelectAddCoverageAsync(string value) =>
        _ui.SelectAsync(_locators.AddCoverage, value, new ControlIntent("Vehicles", "AddCoverage"));

    public Task ClickClientInfoSearchAsync() =>
        _ui.ClickAsync(_locators.ClientInfoSearch, new ControlIntent("Vehicles", "ClientInfoSearch"));

    public Task PressDescriptionAsync(string key) =>
        _ui.PressAsync(_locators.Description, key, new ControlIntent("Vehicles", "Description"));

    public Task PressLimitAsync(string key) =>
        _ui.PressAsync(_locators.Limit, key, new ControlIntent("Vehicles", "Limit"));
public Task ClickSaveAsync() =>
        _ui.ClickAsync(_locators.Save, new ControlIntent("Vehicles", "Save"));

    public Task WaitForScheduledPersonalPropertyHeaderAsync(string expected) =>
        _ui.WaitAsync(_locators.ScheduledPersonalPropertyHeader, expected, new ControlIntent("Vehicles", "ScheduledPersonalPropertyHeader"));

    public Task VerifyScreenHeadingAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ScreenHeading, expected, property, new ControlIntent("Vehicles", "ScreenHeading"));

    public Task<bool> IsScreenHeadingPresentAsync() =>
        _ui.ExistsAsync(_locators.ScreenHeading);

    public Task PressSearchByNameOrCodeAsync(string key) =>
        _ui.PressAsync(_locators.SearchByNameOrCode, key, new ControlIntent("Vehicles", "SearchByNameOrCode"));

    public Task EnterTrueAsync(string value) =>
        _ui.FillAsync(_locators.True, value, new ControlIntent("Vehicles", "True"));

    public Task PressYearOfLastAppraisalAsync(string key) =>
        _ui.PressAsync(_locators.YearOfLastAppraisal, key, new ControlIntent("Vehicles", "YearOfLastAppraisal"));

}
