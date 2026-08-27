using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class SocialSecurityPage
{
    private readonly BrowserSession _browser;
    private readonly SocialSecurityLocators _locators;
    private readonly UiActions _ui;

    public SocialSecurityPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new SocialSecurityLocators(browser.Page);
        _ui = ui;
    }

    public Task ClickDriverInformationAsync() =>
        _ui.ClickAsync(_locators.DriverInformation, new ControlIntent("SocialSecurity", "DriverInformation"));

    public Task EnterMATFORMFIELDAsync(string value) =>
        _ui.FillAsync(_locators.MATFORMFIELD, value, new ControlIntent("SocialSecurity", "MATFORMFIELD"));

    public Task<bool> IsMATFORMFIELDPresentAsync() =>
        _ui.ExistsAsync(_locators.MATFORMFIELD);

    public Task PressNeverResidedInTheHouseholdAndDoesnTRegularlyUseOrHaveAccessToPolicyVehicleSAsync(string key) =>
        _ui.PressAsync(_locators.NeverResidedInTheHouseholdAndDoesnTRegularlyUseOrHaveAccessToPolicyVehicleS, key, new ControlIntent("SocialSecurity", "NeverResidedInTheHouseholdAndDoesnTRegularlyUseOrHaveAccessToPolicyVehicleS"));

    public Task WaitForPrefilledDriversAsync(string expected) =>
        _ui.WaitAsync(_locators.PrefilledDrivers, expected, new ControlIntent("SocialSecurity", "PrefilledDrivers"));

    public Task<string> CapturePrefilledDriversAsync(string property = "") =>
        _ui.CaptureAsync(_locators.PrefilledDrivers, property, new ControlIntent("SocialSecurity", "PrefilledDrivers"));

    public Task<bool> IsPrefilledDriversPresentAsync() =>
        _ui.ExistsAsync(_locators.PrefilledDrivers);

    public Task ClickSaveAndContinueAsync() =>
        _ui.ClickAsync(_locators.SaveAndContinue, new ControlIntent("SocialSecurity", "SaveAndContinue"));

    public Task<bool> IsSaveAndContinuePresentAsync() =>
        _ui.ExistsAsync(_locators.SaveAndContinue);

    public Task EnterStateAsync(string value) =>
        _ui.FillAsync(_locators.State, value, new ControlIntent("SocialSecurity", "State"));

    public Task VerifyUnselectedClientSuggestionsAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.UnselectedClientSuggestions, expected, property, new ControlIntent("SocialSecurity", "UnselectedClientSuggestions"));

    public Task<bool> IsUnselectedClientSuggestionsPresentAsync() =>
        _ui.ExistsAsync(_locators.UnselectedClientSuggestions);

}
