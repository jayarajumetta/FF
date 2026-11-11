using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class AccountInformationPage
{
    private readonly BrowserSession _browser;
    private readonly AccountInformationLocators _locators;
    private readonly UiActions _ui;

    public AccountInformationPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new AccountInformationLocators(browser.Page);
        _ui = ui;
    }

    public Task PressAccountDetailsNextAsync(string key) =>
        _ui.PressAsync(_locators.AccountDetailsNext, key, new ControlIntent("AccountInformation", "AccountDetailsNext"));

    public Task ClickAccountDetailsNextAsync() =>
        _ui.ClickAsync(_locators.AccountDetailsNext, new ControlIntent("AccountInformation", "AccountDetailsNext"));

    public Task WaitForAccountInformationAsync(string expected) =>
        _ui.WaitAsync(_locators.AccountInformation, expected, new ControlIntent("AccountInformation", "AccountInformation"));

    public Task EnterBestPhoneAccountOwnerAsync(string value) =>
        _ui.FillAsync(_locators.BestPhoneAccountOwner, value, new ControlIntent("AccountInformation", "BestPhoneAccountOwner"));

    public Task EnterDOBAsync(string value) =>
        _ui.FillAsync(_locators.DOB, value, new ControlIntent("AccountInformation", "DOB"));

    public Task ClickDivorcedAsync() =>
        _ui.ClickAsync(_locators.Divorced, new ControlIntent("AccountInformation", "Divorced"));

    public Task SelectDrpdwnStateAsync(string value) =>
        _ui.SelectAsync(_locators.DrpdwnState, value, new ControlIntent("AccountInformation", "DrpdwnState"));

    public Task EnterEmailAccountOwnerAsync(string value) =>
        _ui.FillAsync(_locators.EmailAccountOwner, value, new ControlIntent("AccountInformation", "EmailAccountOwner"));

    public Task WaitForEnterALocationAsync(string expected) =>
        _ui.WaitAsync(_locators.EnterALocation, expected, new ControlIntent("AccountInformation", "EnterALocation"));

    public Task EnterEnterALocationAsync(string value) =>
        _ui.PressSequentiallyAsync(_locators.EnterALocation, value, new ControlIntent("AccountInformation", "EnterALocation"));

    public Task VerifyFirstNameAccountOwnerAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.FirstNameAccountOwner, expected, property, new ControlIntent("AccountInformation", "FirstNameAccountOwner"));

    public Task WaitForIsTheAccountAddressAlsoWhereTheClientResidesAsync(string expected) =>
        _ui.WaitAsync(_locators.AccountInformation, expected, new ControlIntent("AccountInformation", "IsTheAccountAddressAlsoWhereTheClientResides"));

    public Task WaitForMaritalStatusAsync(string expected) =>
        _ui.WaitAsync(_locators.AccountInformation, expected, new ControlIntent("AccountInformation", "MaritalStatus"));

    public Task SelectMarriedAsync(string value) =>
        _ui.SelectAsync(_locators.Divorced, value, new ControlIntent("AccountInformation", "Married"));

    public Task WaitForOwnerAddressCityNewAsync(string expected) =>
        _ui.WaitAsync(_locators.OwnerAddressCityNew, expected, new ControlIntent("AccountInformation", "OwnerAddressCityNew"));

    public Task EnterOwnerAddressCityNewAsync(string value) =>
        _ui.PressSequentiallyAsync(_locators.OwnerAddressCityNew, value, new ControlIntent("AccountInformation", "OwnerAddressCityNew"));

    public Task WaitForOwnerAddressLine2Async(string expected) =>
        _ui.WaitAsync(_locators.OwnerAddressLine2, expected, new ControlIntent("AccountInformation", "OwnerAddressLine2"));

    public Task EnterOwnerAddressLine2Async(string value) =>
        _ui.PressSequentiallyAsync(_locators.OwnerAddressLine2, value, new ControlIntent("AccountInformation", "OwnerAddressLine2"));

    public Task WaitForOwnerAddressZipAsync(string expected) =>
        _ui.WaitAsync(_locators.OwnerAddressZip, expected, new ControlIntent("AccountInformation", "OwnerAddressZip"));

    public Task EnterOwnerAddressZipAsync(string value) =>
        _ui.PressSequentiallyAsync(_locators.OwnerAddressZip, value, new ControlIntent("AccountInformation", "OwnerAddressZip"));

    public async Task WaitForSatelliteAsync(string expected)
    {
        if (string.Equals(expected, "Visible", StringComparison.OrdinalIgnoreCase) &&
            !await _ui.ExistsAsync(_locators.Satellite))
        {
            return;
        }

        await _ui.WaitAsync(_locators.Satellite, expected, new ControlIntent("AccountInformation", "Satellite"));
    }

    public Task ClickSingleAsync() =>
        _ui.ClickAsync(_locators.Single, new ControlIntent("AccountInformation", "Single"));

    public Task SelectStateNameAsync(string value) =>
        _ui.SelectAsync(_locators.AccountDetailsNext, value, new ControlIntent("AccountInformation", "StateName"));

    public Task SelectStateAsync(string value) =>
        _ui.SelectAsync(_locators.StateDropdown, value, new ControlIntent("AccountInformation", "StateDropdown"));

    public Task EnterStateAsync(string value) =>
    _ui.FillAsync(_locators.StateDropdown, value, new ControlIntent("Proposal", "State"));

    public Task SelectYesAtLeast90DaysAsync(string value) =>
        _ui.SelectAsync(_locators.YesAtLeast90Days, value, new ControlIntent("AccountInformation", "YesAtLeast90Days"));

    public Task WaitForYesClientResidesAsync(string expected) =>
        _ui.WaitAsync(_locators.YesClientResides, expected, new ControlIntent("AccountInformation", "YesClientResides"));
    public Task WaitForYesAtLeast90DaysAsync(string expected) =>
        _ui.WaitAsync(_locators.YesAtLeast90Days, expected, new ControlIntent("AccountInformation", "YesAtLeast90Days"));

    public Task ClickYesAtLeast90DaysAsync() =>
        _ui.ClickAsync(_locators.YesAtLeast90Days, new ControlIntent("AccountInformation", "YesAtLeast90Days"));

    public Task SelectYesClientResidesAsync(string value) =>
        _ui.SelectAsync(_locators.YesClientResides, value, new ControlIntent("AccountInformation", "YesClientResides"));

    public Task VerifyMapAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.Map, expected, property, new ControlIntent("AccountInformation", "Map"));

    public Task<bool> IsMapPresentAsync() =>
        _ui.ExistsAsync(_locators.Map);

    public Task VerifySatelliteAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.Satellite, expected, property, new ControlIntent("AccountInformation", "Satellite"));

    public Task<bool> IsSatellitePresentAsync() =>
        _ui.ExistsAsync(_locators.Satellite);

    public Task SelectHaveYouReceivedMailAtThisAddressForAtLeast90DaysYesAsync() =>
        _ui.ClickAsync(_locators.YesAtLeast90Days, new ControlIntent("AccountInformation", "HaveYouReceivedMailAtThisAddressForAtLeast90DaysYes"));

    public Task SelectIsTheAccountAddressAlsoWhereTheClientResidesYesAsync() =>
        _ui.ClickAsync(_locators.YesClientResides, new ControlIntent("AccountInformation", "IsTheAccountAddressAlsoWhereTheClientResidesYes"));

    public Task ClickAdditionalInterestsNextAsync() =>
        _ui.ClickAsync(_locators.AdditionalInterestsNext, new ControlIntent("AccountInformation", "AdditionalInterestsNext"));

}
