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

    public Task ClickBillingNavAsync() =>
        _ui.ClickAsync(_locators.BillingNav, new ControlIntent("Billing", "BillingNav"));

    public Task ClickBillingNEXTAsync() =>
        _ui.ClickAsync(_locators.BillingNEXT, new ControlIntent("Billing", "BillingNEXT"));

    public Task WaitForCHECKAsync(string expected) =>
        _ui.WaitAsync(_locators.CHECK, expected, new ControlIntent("Billing", "CHECK"));

    public Task ClickCHECKAsync() =>
        _ui.ClickAsync(_locators.CHECK, new ControlIntent("Billing", "CHECK"));
    public Task WaitForCHECKAsyncAsync(string expected) =>
        _ui.WaitAsync(_locators.CHECK, expected, new ControlIntent("Billing", "CHECK"));

    public Task WaitForCheckNumberAsync(string expected) =>
        _ui.WaitAsync(_locators.CheckNumber, expected, new ControlIntent("Billing", "CheckNumber"));

    public Task EnterCheckNumberAsync(string value) =>
        _ui.FillAsync(_locators.CheckNumber, value, new ControlIntent("Billing", "CheckNumber"));

    public Task ClickCreateNewBillingAccountAsync() =>
        _ui.ClickAsync(_locators.CreateNewBillingAccount, new ControlIntent("Billing", "CreateNewBillingAccount"));

    public Task PressDirectBillAsync(string key) =>
        _ui.PressAsync(_locators.DirectBill, key, new ControlIntent("Billing", "DirectBill"));

    public Task WaitForDirectBillAsync(string expected) =>
        _ui.WaitAsync(_locators.DirectBill, expected, new ControlIntent("Billing", "DirectBill"));

    public Task ClickDirectBillAsync() =>
        _ui.ClickAsync(_locators.DirectBill, new ControlIntent("Billing", "DirectBill"));

    public Task WaitForHdrBillingAsync(string expected) =>
        _ui.WaitAsync(_locators.HdrBilling, expected, new ControlIntent("Billing", "HdrBilling"));

    public Task WaitForN1PaymentAsync(string expected) =>
        _ui.WaitAsync(_locators.N1Payment, expected, new ControlIntent("Billing", "HdrBilling"));
    
    public Task ClickN1PaymentAsync() =>
        _ui.ClickAsync(_locators.N1Payment, new ControlIntent("Billing", "N1Payment"));

    public Task WaitForPaymentDueDateAsync(string expected) =>
        _ui.WaitAsync(_locators.PaymentDueDate, expected, new ControlIntent("Billing", "PaymentDueDate"));

    public Task EnterPaymentDueDateAsync(string value) =>
        _ui.FillAsync(_locators.PaymentDueDate, value, new ControlIntent("Billing", "PaymentDueDate"));

    public Task PressPrimaryAccountHolderNameAsync(string key) =>
        _ui.PressAsync(_locators.PrimaryAccountHolderName, key, new ControlIntent("Billing", "PrimaryAccountHolderName"));

    public Task WaitForPrimaryAccountHolderNameAsync(string expected) =>
        _ui.WaitAsync(_locators.PrimaryAccountHolderName, expected, new ControlIntent("Billing", "PrimaryAccountHolderName"));

    public Task ClickPrimaryAccountHolderNameAsync() =>
        _ui.ClickAsync(_locators.PrimaryAccountHolderName, new ControlIntent("Billing", "PrimaryAccountHolderName"));

    public Task WaitForRdBtnFullBalanceAsync(string expected) =>
        _ui.WaitAsync(_locators.RdBtnFullBalance, expected, new ControlIntent("Billing", "RdBtnFullBalance"));

    public Task ClickRdBtnFullBalanceAsync() =>
        _ui.ClickAsync(_locators.RdBtnFullBalance, new ControlIntent("Billing", "RdBtnFullBalance"));

    public Task WaitRdBtnFullBalanceAsync(string expected) =>
        _ui.WaitAsync(_locators.RdBtnFullBalance, expected, new ControlIntent("Billing", "RdBtnFullBalance"));

}
