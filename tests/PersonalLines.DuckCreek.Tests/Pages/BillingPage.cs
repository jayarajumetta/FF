using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

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

    public Task ClickBillingNEXTAsync() =>
        _ui.ClickAsync(_locators.BillingNEXT, new ControlIntent("Billing", "BillingNEXT"));

    public Task ClickCHECKAsync() =>
        _ui.ClickAsync(_locators.CHECK, new ControlIntent("Billing", "CHECK"));

    public Task EnterCheckNumberAsync(string value) =>
        _ui.FillAsync(_locators.CheckNumber, value, new ControlIntent("Billing", "CheckNumber"));

    public Task ClickCreateNewBillingAccountAsync() =>
        _ui.ClickAsync(_locators.CreateNewBillingAccount, new ControlIntent("Billing", "CreateNewBillingAccount"));

    public Task PressDirectBillAsync(string key) =>
        _ui.PressAsync(_locators.DirectBill, key, new ControlIntent("Billing", "DirectBill"));

    public Task ClickDirectBillAsync() =>
        _ui.ClickAsync(_locators.DirectBill, new ControlIntent("Billing", "DirectBill"));

    public Task WaitForHdrBillingAsync(string expected) =>
        _ui.WaitAsync(_locators.HdrBilling, expected, new ControlIntent("Billing", "HdrBilling"));

    public Task ClickN1PaymentAsync() =>
        _ui.ClickAsync(_locators.N1Payment, new ControlIntent("Billing", "N1Payment"));

    public Task EnterPaymentDueDateAsync(string value) =>
        _ui.FillAsync(_locators.PaymentDueDate, value, new ControlIntent("Billing", "PaymentDueDate"));

    public Task PressPrimaryAccountHolderNameAsync(string key) =>
        _ui.PressAsync(_locators.PrimaryAccountHolderName, key, new ControlIntent("Billing", "PrimaryAccountHolderName"));

    public Task ClickPrimaryAccountHolderNameAsync() =>
        _ui.ClickAsync(_locators.PrimaryAccountHolderName, new ControlIntent("Billing", "PrimaryAccountHolderName"));

    public Task ClickRdBtnFullBalanceAsync() =>
        _ui.ClickAsync(_locators.RdBtnFullBalance, new ControlIntent("Billing", "RdBtnFullBalance"));

}
