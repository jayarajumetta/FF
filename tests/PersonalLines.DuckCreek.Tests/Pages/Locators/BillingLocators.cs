using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class BillingLocators
{
    private readonly IPage _page;
    public BillingLocators(IPage page) => _page = page;

    public ILocator BillingNEXT => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

    public ILocator CHECK => _page.GetByTestId("fields._PolicyPaymentInputDoc.initialPaymentData$paymentMethod.value-chip-wrapper").Nth(1);

    public ILocator BillingNav => _page.GetByTestId("Billing-nav");

    public ILocator CheckNumber => _page.Locator("[id='fields._PolicyPaymentInputDoc.initialPaymentData$checkNumber.value']");

    public ILocator HdrBilling => _page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { Name = "Billing Information" });

    public ILocator CreateNewBillingAccount => _page.GetByTestId("fields._PolicyPaymentInputDoc._PolicyPaymentInputDoc$billingCenterAccount.value-chip-label").Filter(new() { HasText = "Create New Billing Account" });

    public ILocator DirectBill => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentMethod.value-chip-label").Filter(new() { HasText = "Direct Bill" });

    public ILocator N1Payment => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentPlan.value-chip-label").Filter(new() { HasText = "1 Payment" });

    public ILocator PaymentDueDate => _page.Locator("[id='fields._PolicyPaymentInputDoc.subsequentPaymentData$dueDate.value']");

    public ILocator PrimaryAccountHolderName => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$payerID.value-chip-label").Filter(new() { HasTextRegex = new System.Text.RegularExpressions.Regex("^(?!OTHER$).+") }).First;

    public ILocator RdBtnFullBalance => _page.Locator("label[for=\"fields._PolicyPaymentInputDoc.initialPaymentData$amountSelection.value-1-input\"]").Filter(new LocatorFilterOptions { HasText = "Full Balance" }).First;

    public ILocator PaymentOwner => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$payerID.value-chip-label").First;

    public ILocator SelectpaymentOwnerHeader => _page.GetByText("Select the Primary Payer for the new account");
}
