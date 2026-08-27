using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class BillingLocators
{
    private readonly IPage _page;
    public BillingLocators(IPage page) => _page = page;

    // Source modules: EQ||Billing | confidence=Medium score=113
    // v56 raw Tosca primary: EQ||Billing | Btn_OTHER_1 | Id
    public ILocator BillingNEXT => _page.Locator("[id=\"fields._PolicyPaymentInputDoc.subsequentPaymentData$payerID.value-1\"]");

    // Source modules: EQ||Billing | confidence=High score=130
    public ILocator CHECK => _page.GetByTestId("fields._PolicyPaymentInputDoc.initialPaymentData$paymentMethod.value-chip-wrapper");

    // Source modules: EQ||Billing | confidence=High score=127
    public ILocator CheckNumber => _page.Locator("[name=\"Txt_Check Number\"], [id=\"Txt_Check Number\"]").First;

    // Source modules: EQ||Billing | confidence=High score=130
    public ILocator CreateNewBillingAccount => _page.GetByTestId("fields._PolicyPaymentInputDoc._PolicyPaymentInputDoc$billingCenterAccount.value-new-account-chip-chip");

    // Source modules: EQ||Billing | confidence=High score=130
    public ILocator DirectBill => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentMethod.value-chip-wrapper");

    // Source modules: EQ||Billing | confidence=Medium score=84
    // v56 raw Tosca primary: EQ||Billing | Min | Id+Name
    public ILocator HdrBilling => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.initialPaymentData$amountSelection.value-0-input\"][name=\"mat-radio-group-5\"]");

    // Source modules: EQ||Billing | confidence=High score=130
    public ILocator N1Payment => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentPlan.value-chip-wrapper");

    // Source modules: EQ||Billing | confidence=High score=127
    public ILocator PaymentDueDate => _page.Locator("[name=\"Txt_PaymentDueDate\"], [id=\"Txt_PaymentDueDate\"]").First;

    // Source modules: EQ||Billing | confidence=High score=130
    public ILocator PrimaryAccountHolderName => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$payerID.value-*-payer-chip-wrapper");

    // Source modules: EQ||Billing | confidence=High score=127
    // v56 raw Tosca primary: EQ||Billing | Rd Btn_Full Balance | Id+Name
    public ILocator RdBtnFullBalance => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.initialPaymentData$amountSelection.value-1-input\"][name=\"mat-radio-group-5\"]");

}
