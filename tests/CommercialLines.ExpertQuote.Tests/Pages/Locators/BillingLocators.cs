using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class BillingLocators
{
    private readonly IPage _page;
    public BillingLocators(IPage page) => _page = page;

    public ILocator Address1 => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.subsequentPayorDataAddress$address1.value\"][name=\"fields._PolicyPaymentInputDoc.subsequentPayorDataAddress$address1.value\"]");

    public ILocator Billing => _page.Locator("[id=\"pageTitle\"]");

    public ILocator BillingInformationHeading => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.initialPaymentData$amountSelection.value-0-input\"][name=\"mat-radio-group-8\"]");

    public ILocator BusinessName => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.subsequentPayorData$businessName.value\"][name=\"fields._PolicyPaymentInputDoc.subsequentPayorData$businessName.value\"]");

    public ILocator CheckButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.initialPaymentData$paymentMethod.value-chip-wrapper");

    public ILocator CheckNumber => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.initialPaymentData$checkNumber.value\"][name=\"fields._PolicyPaymentInputDoc.initialPaymentData$checkNumber.value\"]");

    public ILocator ChoosePaymentDueDate => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.subsequentPaymentData$dueDate.value\"][name=\"fields._PolicyPaymentInputDoc.subsequentPaymentData$dueDate.value\"]");

    public ILocator City => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.subsequentPayorDataAddress$city.value\"][name=\"fields._PolicyPaymentInputDoc.subsequentPayorDataAddress$city.value\"]");

    public ILocator CreateNewBillingAccount => _page.GetByTestId("fields._PolicyPaymentInputDoc._PolicyPaymentInputDoc$billingCenterAccount.value-chip-label").Filter(new LocatorFilterOptions { HasText = "Create New Billing Account" }).First;


    public ILocator DirectBillButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentMethod.value-chip-label").Filter(new LocatorFilterOptions { HasText = "Direct Bill" }).First;

    public ILocator FirstName => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.subsequentPayorData$firstName.value\"][name=\"fields._PolicyPaymentInputDoc.subsequentPayorData$firstName.value\"]");

    public ILocator InitialPaymentFullBalance => _page.Locator("label[for=\"fields._PolicyPaymentInputDoc.initialPaymentData$amountSelection.value-1-input\"]").Filter(new LocatorFilterOptions { HasText = "Full Balance" }).First;

    public ILocator LastName => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.subsequentPayorData$lastName.value\"][name=\"fields._PolicyPaymentInputDoc.subsequentPayorData$lastName.value\"]");

    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    public ILocator N1PaymentButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentPlan.value-chip-label").Filter(new LocatorFilterOptions { HasText = "1 Payment" }).First;

    public ILocator OTHERButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$payerID.value-chip-label").Filter(new LocatorFilterOptions { HasText = "OTHER" }).First;

    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    public ILocator State => _page.Locator("[id=\"_temp.fields._PolicyPaymentInputDoc.subsequentPayorDataAddress$state.value\"]");

    public ILocator TableRowCellLink => _page.GetByText("Link", new() { Exact = true });

    public ILocator NextSubmission => _page.Locator("[data-testid=\"fields.data-Next.next-button-label\"], [data-testid=\"fields.data.next-button-label\"]").Filter(new LocatorFilterOptions { HasText = "Next: Submission" }).First;

    public ILocator ZipCode => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.subsequentPayorDataAddress$zipCode.value\"][name=\"fields._PolicyPaymentInputDoc.subsequentPayorDataAddress$zipCode.value\"]");

}
