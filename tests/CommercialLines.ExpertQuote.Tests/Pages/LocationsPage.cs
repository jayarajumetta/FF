using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class LocationsPage
{
    private readonly BrowserSession _browser;
    private readonly LocationsLocators _locators;
    private readonly UiActions _ui;

    public LocationsPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new LocationsLocators(browser.Page);
        _ui = ui;
    }

    public Task ClickEditLocationButtonLatestAngularAsync() =>
        _ui.ClickAsync(_locators.EditLocationButtonLatestAngular, new ControlIntent("Locations", "EditLocationButtonLatestAngular"));

    public Task WaitForEditLocationHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.EditLocationHeading, expected, new ControlIntent("Locations", "EditLocationHeading"));

    public Task EnterFeetFromHydrantAsync(string value) =>
        _ui.FillAsync(_locators.FeetFromHydrant, value, new ControlIntent("Locations", "FeetFromHydrant"));
public Task<bool> IsLoadingPresentAsync() =>
        _ui.ExistsAsync(_locators.Loading);

    public Task WaitForLocationDescriptionAsync(string expected) =>
        _ui.WaitAsync(_locators.LocationDescription, expected, new ControlIntent("Locations", "LocationDescription"));

    public Task PressLocationDescriptionAsync(string key) =>
        _ui.PressAsync(_locators.LocationDescription, key, new ControlIntent("Locations", "LocationDescription"));

    public Task ClickLocationLinkAsync() =>
        _ui.ClickAsync(_locators.LocationLink, new ControlIntent("Locations", "LocationLink"));

    public Task PressMilesFromFDAsync(string key) =>
        _ui.PressAsync(_locators.MilesFromFD, key, new ControlIntent("Locations", "MilesFromFD"));

    public Task PressMilesFromFireDeptAsync(string key) =>
        _ui.PressAsync(_locators.MilesFromFireDept, key, new ControlIntent("Locations", "MilesFromFireDept"));

    public Task ClickOrderWildfireRiskScoreAsync() =>
        _ui.ClickAsync(_locators.OrderWildfireRiskScore, new ControlIntent("Locations", "OrderWildfireRiskScore"));

    public Task WaitForSaveAsync(string expected) =>
        _ui.WaitAsync(_locators.Save, expected, new ControlIntent("Locations", "Save"));

    public Task VerifySaveAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.Save, expected, property, new ControlIntent("Locations", "Save"));

    public Task ClickSaveAsync() =>
        _ui.ClickAsync(_locators.Save, new ControlIntent("Locations", "Save"));

    public Task<bool> IsSavePresentAsync() =>
        _ui.ExistsAsync(_locators.Save);

    public Task EnterTerritoryAsync(string value) =>
        _ui.FillAsync(_locators.Territory, value, new ControlIntent("Locations", "Territory"));

    public Task EnterTotalFarmingAcreageAsync(string value) =>
        _ui.FillAsync(_locators.TotalFarmingAcreage, value, new ControlIntent("Locations", "TotalFarmingAcreage"));

    public Task PressTotalFarmingAcreageAsync(string key) =>
        _ui.PressAsync(_locators.TotalFarmingAcreage, key, new ControlIntent("Locations", "TotalFarmingAcreage"));

    public Task ClickWindHail1Async() =>
        _ui.ClickAsync(_locators.WindHail1, new ControlIntent("Locations", "WindHail1"));

    public Task ClickWindHail2Async() =>
        _ui.ClickAsync(_locators.WindHail2, new ControlIntent("Locations", "WindHail2"));

    public Task ClickWindHail5Async() =>
        _ui.ClickAsync(_locators.WindHail5, new ControlIntent("Locations", "WindHail5"));

}
