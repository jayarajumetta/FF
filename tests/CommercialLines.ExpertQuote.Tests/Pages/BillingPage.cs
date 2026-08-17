using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class BillingPage
{
    private readonly BrowserSession _browser;
    private readonly BillingLocators _locators;
    private readonly UiActions _ui;

    public BillingPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new BillingLocators(browser.Page);
        _ui = ui;
    }

    public Task PressAddress1Async(string key) =>
        _ui.PressAsync(_locators.Address1, key, new ControlIntent("Billing", "Address1"));

    public Task WaitForBillingAsync(string expected) =>
        _ui.WaitAsync(_locators.Billing, expected, new ControlIntent("Billing", "Billing"));

    public Task WaitForBillingInformationHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.BillingInformationHeading, expected, new ControlIntent("Billing", "BillingInformationHeading"));

    public Task PressBusinessNameAsync(string key) =>
        _ui.PressAsync(_locators.BusinessName, key, new ControlIntent("Billing", "BusinessName"));

    public Task PressCheckButtonAsync(string key) =>
        _ui.PressAsync(_locators.CheckButton, key, new ControlIntent("Billing", "CheckButton"));

    public Task WaitForCheckNumberAsync(string expected) =>
        _ui.WaitAsync(_locators.CheckNumber, expected, new ControlIntent("Billing", "CheckNumber"));

    public Task VerifyCheckNumberAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.CheckNumber, expected, property, new ControlIntent("Billing", "CheckNumber"));

    public Task PressCheckNumberAsync(string key) =>
        _ui.PressAsync(_locators.CheckNumber, key, new ControlIntent("Billing", "CheckNumber"));

    public Task PressChoosePaymentDueDateAsync(string key) =>
        _ui.PressAsync(_locators.ChoosePaymentDueDate, key, new ControlIntent("Billing", "ChoosePaymentDueDate"));

    public Task PressCityAsync(string key) =>
        _ui.PressAsync(_locators.City, key, new ControlIntent("Billing", "City"));

    public Task ClickCreateNewBillingAccountAsync() =>
        _ui.ClickAsync(_locators.CreateNewBillingAccount, new ControlIntent("Billing", "CreateNewBillingAccount"));

    public Task PressCreditCardButtonAsync(string key) =>
        _ui.PressAsync(_locators.CreditCardButton, key, new ControlIntent("Billing", "CreditCardButton"));

    public Task PressDirectBillButtonAsync(string key) =>
        _ui.PressAsync(_locators.DirectBillButton, key, new ControlIntent("Billing", "DirectBillButton"));

    public Task PressFirstNameAsync(string key) =>
        _ui.PressAsync(_locators.FirstName, key, new ControlIntent("Billing", "FirstName"));

    public Task ClickInitialPaymentFullBalanceAsync() =>
        _ui.ClickAsync(_locators.InitialPaymentFullBalance, new ControlIntent("Billing", "InitialPaymentFullBalance"));

    public Task PressLastNameAsync(string key) =>
        _ui.PressAsync(_locators.LastName, key, new ControlIntent("Billing", "LastName"));

    public Task WaitForLoadingAsync(string expected) =>
        _ui.WaitAsync(_locators.Loading, expected, new ControlIntent("Billing", "Loading"));

    public Task PressN1PaymentButtonAsync(string key) =>
        _ui.PressAsync(_locators.N1PaymentButton, key, new ControlIntent("Billing", "N1PaymentButton"));

    public Task ClickOTHERButtonAsync() =>
        _ui.ClickAsync(_locators.OTHERButton, new ControlIntent("Billing", "OTHERButton"));

    public Task VerifyScreenHeadingAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ScreenHeading, expected, property, new ControlIntent("Billing", "ScreenHeading"));

    public Task<bool> IsScreenHeadingPresentAsync() =>
        _ui.ExistsAsync(_locators.ScreenHeading);

    public Task PressStateAsync(string key) =>
        _ui.PressAsync(_locators.State, key, new ControlIntent("Billing", "State"));

    public Task VerifyTableRowCellLinkAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.TableRowCellLink, expected, property, new ControlIntent("Billing", "TableRowCellLink"));

    public Task PressZipCodeAsync(string key) =>
        _ui.PressAsync(_locators.ZipCode, key, new ControlIntent("Billing", "ZipCode"));

    public Task PauseAsync(int milliseconds) =>
        Task.Delay(milliseconds);

}
