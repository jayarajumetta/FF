using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class BillingLocators
{
    private readonly IPage _page;
    public BillingLocators(IPage page) => _page = page;

    // Source modules: EQ||Billing | confidence=Medium score=113
    public ILocator BillingNEXT => _page.GetByRole(AriaRole.Button, new() { Name = "Btn_Billing_NEXT", Exact = true });

    // Source modules: EQ||Billing | confidence=High score=130
    public ILocator CHECK => _page.GetByTestId("fields._PolicyPaymentInputDoc.initialPaymentData$paymentMethod.value-chip-wrapper");

    // Source modules: EQ||Billing | confidence=High score=127
    public ILocator CheckNumber => _page.GetByRole(AriaRole.Textbox, new() { Name = "Txt_Check Number", Exact = true });

    // Source modules: EQ||Billing | confidence=High score=130
    public ILocator CreateNewBillingAccount => _page.GetByTestId("fields._PolicyPaymentInputDoc._PolicyPaymentInputDoc$billingCenterAccount.value-new-account-chip-chip");

    // Source modules: EQ||Billing | confidence=High score=130
    public ILocator DirectBill => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentMethod.value-chip-wrapper");

    // Source modules: EQ||Billing | confidence=Medium score=84
    public ILocator HdrBilling => _page.GetByLabel("H1", new() { Exact = true });

    // Source modules: EQ||Billing | confidence=High score=130
    public ILocator N1Payment => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentPlan.value-chip-wrapper");

    // Source modules: EQ||Billing | confidence=High score=127
    public ILocator PaymentDueDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Txt_PaymentDueDate", Exact = true });

    // Source modules: EQ||Billing | confidence=High score=130
    public ILocator PrimaryAccountHolderName => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$payerID.value-*-payer-chip-wrapper");

    // Source modules: EQ||Billing | confidence=High score=127
    public ILocator RdBtnFullBalance => _page.GetByRole(AriaRole.Radio, new() { Name = "Rd Btn_Full Balance", Exact = true });

}