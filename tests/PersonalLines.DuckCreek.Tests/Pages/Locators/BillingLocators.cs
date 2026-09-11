using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class BillingLocators
{
    private readonly IPage _page;
    public BillingLocators(IPage page) => _page = page;

    public ILocator BillingNEXT => _page.Locator("[id=\"fields._PolicyPaymentInputDoc.subsequentPaymentData$payerID.value-1\"]");

    public ILocator CHECK => _page.GetByTestId("fields._PolicyPaymentInputDoc.initialPaymentData$paymentMethod.value-chip-wrapper");

    public ILocator CheckNumber => _page.Locator("[name=\"Txt_Check Number\"], [id=\"Txt_Check Number\"]").First;

    public ILocator CreateNewBillingAccount => _page.GetByTestId("fields._PolicyPaymentInputDoc._PolicyPaymentInputDoc$billingCenterAccount.value-new-account-chip-chip");

    public ILocator DirectBill => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentMethod.value-chip-wrapper");

    public ILocator HdrBilling => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.initialPaymentData$amountSelection.value-0-input\"][name=\"mat-radio-group-5\"]");

    public ILocator N1Payment => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentPlan.value-chip-wrapper");

    public ILocator PaymentDueDate => _page.Locator("[name=\"Txt_PaymentDueDate\"], [id=\"Txt_PaymentDueDate\"]").First;

    public ILocator PrimaryAccountHolderName => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$payerID.value-*-payer-chip-wrapper");

    public ILocator RdBtnFullBalance => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.initialPaymentData$amountSelection.value-1-input\"][name=\"mat-radio-group-5\"]");

}
