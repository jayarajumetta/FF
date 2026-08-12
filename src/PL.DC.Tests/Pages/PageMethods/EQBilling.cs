using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBilling
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBilling(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator HdrBilling => EQBillingLocators.HdrBilling(_page);

    public Task PressHdrBillingAsync(string key) => HdrBilling.PressAsync(key);

    public Task DoubleClickHdrBillingAsync() => HdrBilling.DblClickAsync();

    public Task WaitForHdrBillingAsync() =>
        HdrBilling.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator BtnCreateNewBillingAccount => EQBillingLocators.BtnCreateNewBillingAccount(_page);

    public Task PressBtnCreateNewBillingAccountAsync(string key) => BtnCreateNewBillingAccount.PressAsync(key);

    public Task DoubleClickBtnCreateNewBillingAccountAsync() => BtnCreateNewBillingAccount.DblClickAsync();

    public Task SetBtnCreateNewBillingAccountAsync(string value) =>
        UiActions.ApplyInputAsync(_page, BtnCreateNewBillingAccount, _data.Resolve(value));

    public Task TypeBtnCreateNewBillingAccountAsync(string value, float delayMs = 40) =>
        BtnCreateNewBillingAccount.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BtnDirectBill => EQBillingLocators.BtnDirectBill(_page);

    public Task PressBtnDirectBillAsync(string key) => BtnDirectBill.PressAsync(key);

    public Task DoubleClickBtnDirectBillAsync() => BtnDirectBill.DblClickAsync();

    public Task SetBtnDirectBillAsync(string value) =>
        UiActions.ApplyInputAsync(_page, BtnDirectBill, _data.Resolve(value));

    public Task TypeBtnDirectBillAsync(string value, float delayMs = 40) =>
        BtnDirectBill.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Btn1Payment => EQBillingLocators.Btn1Payment(_page);

    public Task PressBtn1PaymentAsync(string key) => Btn1Payment.PressAsync(key);

    public Task DoubleClickBtn1PaymentAsync() => Btn1Payment.DblClickAsync();

    public Task SetBtn1PaymentAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Btn1Payment, _data.Resolve(value));

    public Task TypeBtn1PaymentAsync(string value, float delayMs = 40) =>
        Btn1Payment.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator TxtPaymentDueDate => EQBillingLocators.TxtPaymentDueDate(_page);

    public Task PressTxtPaymentDueDateAsync(string key) => TxtPaymentDueDate.PressAsync(key);

    public Task DoubleClickTxtPaymentDueDateAsync() => TxtPaymentDueDate.DblClickAsync();

    public Task SetTxtPaymentDueDateAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TxtPaymentDueDate, _data.Resolve(value));

    public Task TypeTxtPaymentDueDateAsync(string value, float delayMs = 40) =>
        TxtPaymentDueDate.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator RdBtnFullBalance => EQBillingLocators.RdBtnFullBalance(_page);

    public Task PressRdBtnFullBalanceAsync(string key) => RdBtnFullBalance.PressAsync(key);

    public Task DoubleClickRdBtnFullBalanceAsync() => RdBtnFullBalance.DblClickAsync();

    public Task ClickRdBtnFullBalanceAsync() => RdBtnFullBalance.ClickAsync();

    private ILocator BtnCHECK => EQBillingLocators.BtnCHECK(_page);

    public Task PressBtnCHECKAsync(string key) => BtnCHECK.PressAsync(key);

    public Task DoubleClickBtnCHECKAsync() => BtnCHECK.DblClickAsync();

    public Task SetBtnCHECKAsync(string value) =>
        UiActions.ApplyInputAsync(_page, BtnCHECK, _data.Resolve(value));

    public Task TypeBtnCHECKAsync(string value, float delayMs = 40) =>
        BtnCHECK.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator TxtCheckNumber => EQBillingLocators.TxtCheckNumber(_page);

    public Task PressTxtCheckNumberAsync(string key) => TxtCheckNumber.PressAsync(key);

    public Task DoubleClickTxtCheckNumberAsync() => TxtCheckNumber.DblClickAsync();

    public Task SetTxtCheckNumberAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TxtCheckNumber, _data.Resolve(value));

    public Task TypeTxtCheckNumberAsync(string value, float delayMs = 40) =>
        TxtCheckNumber.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task WaitForTxtCheckNumberAsync() =>
        TxtCheckNumber.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator BtnBillingNEXT => EQBillingLocators.BtnBillingNEXT(_page);

    public Task PressBtnBillingNEXTAsync(string key) => BtnBillingNEXT.PressAsync(key);

    public Task DoubleClickBtnBillingNEXTAsync() => BtnBillingNEXT.DblClickAsync();

    public Task ClickBtnBillingNEXTAsync() => BtnBillingNEXT.ClickAsync();

    private ILocator TxtDueDate => EQBillingLocators.TxtDueDate(_page);

    public Task PressTxtDueDateAsync(string key) => TxtDueDate.PressAsync(key);

    public Task DoubleClickTxtDueDateAsync() => TxtDueDate.DblClickAsync();

    public Task SetTxtDueDateAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TxtDueDate, _data.Resolve(value));

    public Task TypeTxtDueDateAsync(string value, float delayMs = 40) =>
        TxtDueDate.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task VerifyTxtDueDateAsync(string expected) =>
        Expect(TxtDueDate).ToContainTextAsync(_data.Resolve(expected));

    public Task WaitForTxtDueDateAsync() =>
        TxtDueDate.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    public Task ClickBtnCHECKAsync() => BtnCHECK.ClickAsync();

    public Task ClickBtnCreateNewBillingAccountAsync() => BtnCreateNewBillingAccount.ClickAsync();
}
