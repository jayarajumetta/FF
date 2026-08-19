using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

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

    public Task VerifyAccountInformationAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.AccountInformation, expected, property, new ControlIntent("AccountInformation", "AccountInformation"));

    public Task WaitForAccountInformationHeaderAsync(string expected) =>
        _ui.WaitAsync(_locators.AccountInformationHeader, expected, new ControlIntent("AccountInformation", "AccountInformationHeader"));

    public Task PressAdditionalInterestsNextAsync(string key) =>
        _ui.PressAsync(_locators.AdditionalInterestsNext, key, new ControlIntent("AccountInformation", "AdditionalInterestsNext"));

    public Task ClickAdditionalInterestsNextAsync() =>
        _ui.ClickAsync(_locators.AdditionalInterestsNext, new ControlIntent("AccountInformation", "AdditionalInterestsNext"));

    public Task EnterAddress2Async(string value) =>
        _ui.FillAsync(_locators.Address2, value, new ControlIntent("AccountInformation", "Address2"));

    public Task PressAddress2Async(string key) =>
        _ui.PressAsync(_locators.Address2, key, new ControlIntent("AccountInformation", "Address2"));

    public Task EnterCityAsync(string value) =>
        _ui.FillAsync(_locators.City, value, new ControlIntent("AccountInformation", "City"));

    public Task PressCityAsync(string key) =>
        _ui.PressAsync(_locators.City, key, new ControlIntent("AccountInformation", "City"));

    public Task SelectHaveYouReceivedMailAtThisAddressForAtLeast90DaysYesAsync(string value) =>
        _ui.SelectAsync(_locators.HaveYouReceivedMailAtThisAddressForAtLeast90DaysYes, value, new ControlIntent("AccountInformation", "HaveYouReceivedMailAtThisAddressForAtLeast90DaysYes"));

    public Task SelectIsTheAccountAddressAlsoWhereTheClientResidesYesAsync(string value) =>
        _ui.SelectAsync(_locators.IsTheAccountAddressAlsoWhereTheClientResidesYes, value, new ControlIntent("AccountInformation", "IsTheAccountAddressAlsoWhereTheClientResidesYes"));

    public Task WaitForMapAsync(string expected) =>
        _ui.WaitAsync(_locators.Map, expected, new ControlIntent("AccountInformation", "Map"));

    public Task VerifyMapAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.Map, expected, property, new ControlIntent("AccountInformation", "Map"));

    public Task SelectMarriedAsync(string value) =>
        _ui.SelectAsync(_locators.Married, value, new ControlIntent("AccountInformation", "Married"));

    public Task ClickMarriedAsync() =>
        _ui.ClickAsync(_locators.Married, new ControlIntent("AccountInformation", "Married"));

    public Task EnterOwnerMiddleNameAsync(string value) =>
        _ui.FillAsync(_locators.OwnerMiddleName, value, new ControlIntent("AccountInformation", "OwnerMiddleName"));

    public Task PressOwnerMiddleNameAsync(string key) =>
        _ui.PressAsync(_locators.OwnerMiddleName, key, new ControlIntent("AccountInformation", "OwnerMiddleName"));

    public Task WaitForSatelliteAsync(string expected) =>
        _ui.WaitAsync(_locators.Satellite, expected, new ControlIntent("AccountInformation", "Satellite"));

    public Task VerifySatelliteAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.Satellite, expected, property, new ControlIntent("AccountInformation", "Satellite"));

    public Task SelectState0110EAsync(string value) =>
        _ui.SelectAsync(_locators.State0110E, value, new ControlIntent("AccountInformation", "State0110E"));

    public Task EnterStateAE19AAsync(string value) =>
        _ui.FillAsync(_locators.StateAE19A, value, new ControlIntent("AccountInformation", "StateAE19A"));

    public Task ClickStateDropdownAsync() =>
        _ui.ClickAsync(_locators.StateDropdown, new ControlIntent("AccountInformation", "StateDropdown"));

    public Task EnterStreetAddressAsync(string value) =>
        _ui.FillAsync(_locators.StreetAddress, value, new ControlIntent("AccountInformation", "StreetAddress"));

    public Task PressStreetAddressAsync(string key) =>
        _ui.PressAsync(_locators.StreetAddress, key, new ControlIntent("AccountInformation", "StreetAddress"));

    public Task ClickYesAsync() =>
        _ui.ClickAsync(_locators.Yes, new ControlIntent("AccountInformation", "Yes"));

    public Task EnterZipAsync(string value) =>
        _ui.FillAsync(_locators.Zip, value, new ControlIntent("AccountInformation", "Zip"));

    public Task PressZipAsync(string key) =>
        _ui.PressAsync(_locators.Zip, key, new ControlIntent("AccountInformation", "Zip"));


    public Task EnterOwnerPhoneAsync(string value) =>
        _ui.FillAsync(_locators.OwnerPhone, value, new ControlIntent("AccountInformation", "OwnerPhone"));


    public Task EnterOwnerEmailAsync(string value) =>
        _ui.FillAsync(_locators.OwnerEmail, value, new ControlIntent("AccountInformation", "OwnerEmail"));

}
