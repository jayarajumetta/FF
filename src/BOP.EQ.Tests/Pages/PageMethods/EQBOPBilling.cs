using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPBilling
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPBilling(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator BillingInformationHeading => EQBOPBillingLocators.BillingInformationHeading(_page);

    public Task PressBillingInformationHeadingAsync(string key) => BillingInformationHeading.PressAsync(key);

    public Task DoubleClickBillingInformationHeadingAsync() => BillingInformationHeading.DblClickAsync();

    public Task WaitForBillingInformationHeadingAsync() =>
        BillingInformationHeading.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator MortgageeButton => EQBOPBillingLocators.MortgageeButton(_page);

    public Task PressMortgageeButtonAsync(string key) => MortgageeButton.PressAsync(key);

    public Task DoubleClickMortgageeButtonAsync() => MortgageeButton.DblClickAsync();

    public Task ClickMortgageeButtonAsync() => MortgageeButton.ClickAsync();

    private ILocator CreateNewBillingAccount => EQBOPBillingLocators.CreateNewBillingAccount(_page);

    public Task PressCreateNewBillingAccountAsync(string key) => CreateNewBillingAccount.PressAsync(key);

    public Task DoubleClickCreateNewBillingAccountAsync() => CreateNewBillingAccount.DblClickAsync();

    public Task SetCreateNewBillingAccountAsync(string value) =>
        UiActions.ApplyInputAsync(_page, CreateNewBillingAccount, _data.Resolve(value));

    public Task TypeCreateNewBillingAccountAsync(string value, float delayMs = 40) =>
        CreateNewBillingAccount.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator OTHERButton => EQBOPBillingLocators.OTHERButton(_page);

    public Task PressOTHERButtonAsync(string key) => OTHERButton.PressAsync(key);

    public Task DoubleClickOTHERButtonAsync() => OTHERButton.DblClickAsync();

    public Task SetOTHERButtonAsync(string value) =>
        UiActions.ApplyInputAsync(_page, OTHERButton, _data.Resolve(value));

    public Task TypeOTHERButtonAsync(string value, float delayMs = 40) =>
        OTHERButton.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator FirstName => EQBOPBillingLocators.FirstName(_page);

    public Task PressFirstNameAsync(string key) => FirstName.PressAsync(key);

    public Task DoubleClickFirstNameAsync() => FirstName.DblClickAsync();

    public Task SetFirstNameAsync(string value) =>
        UiActions.ApplyInputAsync(_page, FirstName, _data.Resolve(value));

    public Task TypeFirstNameAsync(string value, float delayMs = 40) =>
        FirstName.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator LastName => EQBOPBillingLocators.LastName(_page);

    public Task PressLastNameAsync(string key) => LastName.PressAsync(key);

    public Task DoubleClickLastNameAsync() => LastName.DblClickAsync();

    public Task SetLastNameAsync(string value) =>
        UiActions.ApplyInputAsync(_page, LastName, _data.Resolve(value));

    public Task TypeLastNameAsync(string value, float delayMs = 40) =>
        LastName.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BusinessName => EQBOPBillingLocators.BusinessName(_page);

    public Task PressBusinessNameAsync(string key) => BusinessName.PressAsync(key);

    public Task DoubleClickBusinessNameAsync() => BusinessName.DblClickAsync();

    public Task SetBusinessNameAsync(string value) =>
        UiActions.ApplyInputAsync(_page, BusinessName, _data.Resolve(value));

    public Task TypeBusinessNameAsync(string value, float delayMs = 40) =>
        BusinessName.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Address1 => EQBOPBillingLocators.Address1(_page);

    public Task PressAddress1Async(string key) => Address1.PressAsync(key);

    public Task DoubleClickAddress1Async() => Address1.DblClickAsync();

    public Task SetAddress1Async(string value) =>
        UiActions.ApplyInputAsync(_page, Address1, _data.Resolve(value));

    public Task TypeAddress1Async(string value, float delayMs = 40) =>
        Address1.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator City => EQBOPBillingLocators.City(_page);

    public Task PressCityAsync(string key) => City.PressAsync(key);

    public Task DoubleClickCityAsync() => City.DblClickAsync();

    public Task SetCityAsync(string value) =>
        UiActions.ApplyInputAsync(_page, City, _data.Resolve(value));

    public Task TypeCityAsync(string value, float delayMs = 40) =>
        City.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator State => EQBOPBillingLocators.State(_page);

    public Task PressStateAsync(string key) => State.PressAsync(key);

    public Task DoubleClickStateAsync() => State.DblClickAsync();

    public Task SetStateAsync(string value) =>
        State.SelectOptionAsync(_data.Resolve(value));

    private ILocator ZipCode => EQBOPBillingLocators.ZipCode(_page);

    public Task PressZipCodeAsync(string key) => ZipCode.PressAsync(key);

    public Task DoubleClickZipCodeAsync() => ZipCode.DblClickAsync();

    public Task SetZipCodeAsync(string value) =>
        UiActions.ApplyInputAsync(_page, ZipCode, _data.Resolve(value));

    public Task TypeZipCodeAsync(string value, float delayMs = 40) =>
        ZipCode.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator DirectBillButton => EQBOPBillingLocators.DirectBillButton(_page);

    public Task PressDirectBillButtonAsync(string key) => DirectBillButton.PressAsync(key);

    public Task DoubleClickDirectBillButtonAsync() => DirectBillButton.DblClickAsync();

    public Task SetDirectBillButtonAsync(string value) =>
        UiActions.ApplyInputAsync(_page, DirectBillButton, _data.Resolve(value));

    public Task TypeDirectBillButtonAsync(string value, float delayMs = 40) =>
        DirectBillButton.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Item1PaymentButton => EQBOPBillingLocators.Item1PaymentButton(_page);

    public Task PressItem1PaymentButtonAsync(string key) => Item1PaymentButton.PressAsync(key);

    public Task DoubleClickItem1PaymentButtonAsync() => Item1PaymentButton.DblClickAsync();

    public Task SetItem1PaymentButtonAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Item1PaymentButton, _data.Resolve(value));

    public Task TypeItem1PaymentButtonAsync(string value, float delayMs = 40) =>
        Item1PaymentButton.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator ChoosePaymentDueDate => EQBOPBillingLocators.ChoosePaymentDueDate(_page);

    public Task PressChoosePaymentDueDateAsync(string key) => ChoosePaymentDueDate.PressAsync(key);

    public Task DoubleClickChoosePaymentDueDateAsync() => ChoosePaymentDueDate.DblClickAsync();

    public Task SetChoosePaymentDueDateAsync(string value) =>
        UiActions.ApplyInputAsync(_page, ChoosePaymentDueDate, _data.Resolve(value));

    public Task TypeChoosePaymentDueDateAsync(string value, float delayMs = 40) =>
        ChoosePaymentDueDate.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator CheckButton => EQBOPBillingLocators.CheckButton(_page);

    public Task PressCheckButtonAsync(string key) => CheckButton.PressAsync(key);

    public Task DoubleClickCheckButtonAsync() => CheckButton.DblClickAsync();

    public Task SetCheckButtonAsync(string value) =>
        UiActions.ApplyInputAsync(_page, CheckButton, _data.Resolve(value));

    public Task TypeCheckButtonAsync(string value, float delayMs = 40) =>
        CheckButton.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator CreditCardButton => EQBOPBillingLocators.CreditCardButton(_page);

    public Task PressCreditCardButtonAsync(string key) => CreditCardButton.PressAsync(key);

    public Task DoubleClickCreditCardButtonAsync() => CreditCardButton.DblClickAsync();

    public Task SetCreditCardButtonAsync(string value) =>
        UiActions.ApplyInputAsync(_page, CreditCardButton, _data.Resolve(value));

    public Task TypeCreditCardButtonAsync(string value, float delayMs = 40) =>
        CreditCardButton.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator CheckNumber => EQBOPBillingLocators.CheckNumber(_page);

    public Task PressCheckNumberAsync(string key) => CheckNumber.PressAsync(key);

    public Task DoubleClickCheckNumberAsync() => CheckNumber.DblClickAsync();

    public Task SetCheckNumberAsync(string value) =>
        UiActions.ApplyInputAsync(_page, CheckNumber, _data.Resolve(value));

    public Task TypeCheckNumberAsync(string value, float delayMs = 40) =>
        CheckNumber.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task VerifyCheckNumberAsync(string expected) =>
        Expect(CheckNumber).ToContainTextAsync(_data.Resolve(expected));

    public Task WaitForCheckNumberAsync() =>
        CheckNumber.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator InitialPaymentFullBalance => EQBOPBillingLocators.InitialPaymentFullBalance(_page);

    public Task PressInitialPaymentFullBalanceAsync(string key) => InitialPaymentFullBalance.PressAsync(key);

    public Task DoubleClickInitialPaymentFullBalanceAsync() => InitialPaymentFullBalance.DblClickAsync();

    public Task ClickInitialPaymentFullBalanceAsync() => InitialPaymentFullBalance.ClickAsync();

}
