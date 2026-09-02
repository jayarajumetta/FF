using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class ClientSearchPage
{
    private readonly BrowserSession _browser;
    private readonly ClientSearchLocators _locators;
    private readonly UiActions _ui;

    public ClientSearchPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new ClientSearchLocators(browser.Page);
        _ui = ui;
    }

    public Task PressAdditionalInterestsNextAsync(string key) =>
        _ui.PressAsync(_locators.AdditionalInterestsNext, key, new ControlIntent("ClientSearch", "AdditionalInterestsNext"));

    public Task ClickAdditionalInterestsNextAsync() =>
        _ui.ClickAsync(_locators.AdditionalInterestsNext, new ControlIntent("ClientSearch", "AdditionalInterestsNext"));

    public Task WaitForClientInfoAsync(string expected) =>
        _ui.WaitAsync(_locators.ClientInfo, expected, new ControlIntent("ClientSearch", "ClientInfo"));

    public Task VerifyClientInfoAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ClientInfo, expected, property, new ControlIntent("ClientSearch", "ClientInfo"));

    public Task ClickClientInfoSearchAsync() =>
        _ui.ClickAsync(_locators.ClientInfoSearch, new ControlIntent("ClientSearch", "ClientInfoSearch"));

    public Task ClickCreateNewClientAsync() =>
        _ui.ClickAsync(_locators.CreateNewClient, new ControlIntent("ClientSearch", "CreateNewClient"));

    public Task ClickCreateNewClient1Async() =>
        _ui.ClickAsync(_locators.CreateNewClient, new ControlIntent("ClientSearch", "CreateNewClient1"));

    public Task EnterCustomerDateOfBirthAsync(string value) =>
        _ui.FillAsync(_locators.CustomerDateOfBirth, value, new ControlIntent("ClientSearch", "CustomerDateOfBirth"));

    public Task EnterCustomerNameFirstAsync(string value) =>
        _ui.FillAsync(_locators.CustomerNameFirst, value, new ControlIntent("ClientSearch", "CustomerNameFirst"));

    public Task EnterCustomerNameLastAsync(string value) =>
        _ui.FillAsync(_locators.CustomerNameLast, value, new ControlIntent("ClientSearch", "CustomerNameLast"));

    public Task WaitForExistingClientMatchAsync(string expected) =>
        _ui.WaitAsync(_locators.ExistingClientMatch, expected, new ControlIntent("ClientSearch", "ExistingClientMatch"));

    public Task VerifyExistingClientMatchAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ExistingClientMatch, expected, property, new ControlIntent("ClientSearch", "ExistingClientMatch"));

    public Task<bool> IsExistingClientMatchPresentAsync() =>
        _ui.ExistsAsync(_locators.ExistingClientMatch);

    public Task WaitForNewExistingClientSearchAsync(string expected) =>
        _ui.WaitAsync(_locators.NewExistingClientSearch, expected, new ControlIntent("ClientSearch", "NewExistingClientSearch"));

    public Task VerifyNewQuoteAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.NewQuote, expected, property, new ControlIntent("ClientSearch", "NewQuote"));

    public Task ClickNewQuoteAsync() =>
        _ui.ClickAsync(_locators.NewQuote, new ControlIntent("ClientSearch", "NewQuote"));

}
