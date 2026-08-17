using InsuranceAutomation.Core;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class BillingPage
{
    private readonly BillingLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public BillingPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new BillingLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I configure direct\-pay billing
    public async Task ConfigureDirectPayBillingAsync()
    {
        // EQBilling_48a6fbPage.BillingCreateAndUpdateBillingDetails_0147_8f9ff6Async
        await _ui.WaitAsync(_locators.HdrBilling, "Visible");
        await _ui.ClickAsync(_locators.CreateNewBillingAccount);
        await _ui.ClickAsync(_locators.PrimaryAccountHolderName);
        await _ui.PressAsync(_locators.PrimaryAccountHolderName, "Click");
        await _ui.PressAsync(_locators.PrimaryAccountHolderName, "Scroll[3]");
        await _ui.ClickAsync(_locators.DirectBill);
        await _ui.PressAsync(_locators.DirectBill, "Click");
        await _ui.PressAsync(_locators.DirectBill, "scroll[3]");
        await _ui.ClickAsync(_locators.N1Payment);
        await _ui.FillAsync(_locators.PaymentDueDate, _data.Resolve("{{data:txt_paymentduedate_522}}"));
        await _ui.ClickAsync(_locators.RdBtnFullBalance);
        await _ui.ClickAsync(_locators.CHECK);
        await _ui.FillAsync(_locators.CheckNumber, _data.Resolve("{{data:txt_check_number_525}}"));
        await _ui.ClickAsync(_locators.BillingNEXT);
    }

    // Business step: I configure direct\-pay billing
    public async Task ConfigureDirectPayBillingAsync2()
    {
        // EQBilling_48a6fbPage.BillingCreateAndUpdateBillingDetails_0159_8f5301Async
        await _ui.WaitAsync(_locators.HdrBilling, "Visible");
        await _ui.ClickAsync(_locators.CreateNewBillingAccount);
        await _ui.ClickAsync(_locators.PrimaryAccountHolderName);
        await _ui.PressAsync(_locators.PrimaryAccountHolderName, "Click");
        await _ui.PressAsync(_locators.PrimaryAccountHolderName, "Scroll[3]");
        await _ui.ClickAsync(_locators.DirectBill);
        await _ui.PressAsync(_locators.DirectBill, "Click");
        await _ui.PressAsync(_locators.DirectBill, "scroll[3]");
        await _ui.ClickAsync(_locators.N1Payment);
        await _ui.FillAsync(_locators.PaymentDueDate, _data.Resolve("{{data:txt_paymentduedate_573}}"));
        await _ui.ClickAsync(_locators.RdBtnFullBalance);
        await _ui.ClickAsync(_locators.CHECK);
        await _ui.FillAsync(_locators.CheckNumber, _data.Resolve("{{data:txt_check_number_576}}"));
        await _ui.ClickAsync(_locators.BillingNEXT);
    }

    // Business step: I configure direct\-pay billing
    public async Task ConfigureDirectPayBillingAsync3()
    {
        // EQBilling_48a6fbPage.BillingCreateAndUpdateBillingDetails_0160_e2e0d7Async
        await _ui.WaitAsync(_locators.HdrBilling, "Visible");
        await _ui.ClickAsync(_locators.CreateNewBillingAccount);
        await _ui.ClickAsync(_locators.PrimaryAccountHolderName);
        await _ui.PressAsync(_locators.PrimaryAccountHolderName, "Click");
        await _ui.PressAsync(_locators.PrimaryAccountHolderName, "Scroll[3]");
        await _ui.ClickAsync(_locators.DirectBill);
        await _ui.PressAsync(_locators.DirectBill, "Click");
        await _ui.PressAsync(_locators.DirectBill, "scroll[3]");
        await _ui.ClickAsync(_locators.N1Payment);
        await _ui.FillAsync(_locators.PaymentDueDate, _data.Resolve("{{data:txt_paymentduedate_558}}"));
        await _ui.ClickAsync(_locators.RdBtnFullBalance);
        await _ui.ClickAsync(_locators.CHECK);
        await _ui.FillAsync(_locators.CheckNumber, _data.Resolve("{{data:txt_check_number_561}}"));
        await _ui.ClickAsync(_locators.BillingNEXT);
    }

    // Business step: I configure direct\-pay billing
    public async Task ConfigureDirectPayBillingAsync4()
    {
        // EQBilling_48a6fbPage.BillingCreateAndUpdateBillingDetails_0160_bafd4aAsync
        await _ui.WaitAsync(_locators.HdrBilling, "Visible");
        await _ui.ClickAsync(_locators.CreateNewBillingAccount);
        await _ui.ClickAsync(_locators.PrimaryAccountHolderName);
        await _ui.PressAsync(_locators.PrimaryAccountHolderName, "Click");
        await _ui.PressAsync(_locators.PrimaryAccountHolderName, "Scroll[3]");
        await _ui.ClickAsync(_locators.DirectBill);
        await _ui.PressAsync(_locators.DirectBill, "Click");
        await _ui.PressAsync(_locators.DirectBill, "scroll[3]");
        await _ui.ClickAsync(_locators.N1Payment);
        await _ui.FillAsync(_locators.PaymentDueDate, _data.Resolve("{{data:txt_paymentduedate_558}}"));
        await _ui.ClickAsync(_locators.RdBtnFullBalance);
        await _ui.ClickAsync(_locators.CHECK);
        await _ui.FillAsync(_locators.CheckNumber, _data.Resolve("{{data:txt_check_number_561}}"));
        await _ui.ClickAsync(_locators.BillingNEXT);
    }

    // Business step: I configure direct\-pay billing
    public async Task ConfigureDirectPayBillingAsync5()
    {
        // EQBilling_48a6fbPage.BillingCreateAndUpdateBillingDetails_0163_8f4c8fAsync
        await _ui.WaitAsync(_locators.HdrBilling, "Visible");
        await _ui.ClickAsync(_locators.CreateNewBillingAccount);
        await _ui.ClickAsync(_locators.PrimaryAccountHolderName);
        await _ui.PressAsync(_locators.PrimaryAccountHolderName, "Click");
        await _ui.PressAsync(_locators.PrimaryAccountHolderName, "Scroll[3]");
        await _ui.ClickAsync(_locators.DirectBill);
        await _ui.PressAsync(_locators.DirectBill, "Click");
        await _ui.PressAsync(_locators.DirectBill, "scroll[3]");
        await _ui.ClickAsync(_locators.N1Payment);
        await _ui.FillAsync(_locators.PaymentDueDate, _data.Resolve("{{data:txt_paymentduedate_575}}"));
        await _ui.ClickAsync(_locators.RdBtnFullBalance);
        await _ui.ClickAsync(_locators.CHECK);
        await _ui.FillAsync(_locators.CheckNumber, _data.Resolve("{{data:txt_check_number_578}}"));
        await _ui.ClickAsync(_locators.BillingNEXT);
    }

    // Business step: I configure direct\-pay billing
    public async Task ConfigureDirectPayBillingAsync6()
    {
        // EQBilling_48a6fbPage.BillingCreateAndUpdateBillingDetails_0163_10f911Async
        await _ui.WaitAsync(_locators.HdrBilling, "Visible");
        await _ui.ClickAsync(_locators.CreateNewBillingAccount);
        await _ui.ClickAsync(_locators.PrimaryAccountHolderName);
        await _ui.PressAsync(_locators.PrimaryAccountHolderName, "Click");
        await _ui.PressAsync(_locators.PrimaryAccountHolderName, "Scroll[3]");
        await _ui.ClickAsync(_locators.DirectBill);
        await _ui.PressAsync(_locators.DirectBill, "Click");
        await _ui.PressAsync(_locators.DirectBill, "scroll[3]");
        await _ui.ClickAsync(_locators.N1Payment);
        await _ui.FillAsync(_locators.PaymentDueDate, _data.Resolve("{{data:txt_paymentduedate_578}}"));
        await _ui.ClickAsync(_locators.RdBtnFullBalance);
        await _ui.ClickAsync(_locators.CHECK);
        await _ui.FillAsync(_locators.CheckNumber, _data.Resolve("{{data:txt_check_number_581}}"));
        await _ui.ClickAsync(_locators.BillingNEXT);
    }

}