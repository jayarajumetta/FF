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

    public ILocator CreateNewBillingAccount => _page.GetByTestId("fields._PolicyPaymentInputDoc._PolicyPaymentInputDoc$billingCenterAccount.value-new-account-chip-chip");


    public ILocator DirectBillButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentMethod.value-chip-wrapper");

    public ILocator FirstName => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.subsequentPayorData$firstName.value\"][name=\"fields._PolicyPaymentInputDoc.subsequentPayorData$firstName.value\"]");

    public ILocator InitialPaymentFullBalance => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.initialPaymentData$amountSelection.value-1-input\"][name=\"mat-radio-group-8\"]");

    public ILocator LastName => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.subsequentPayorData$lastName.value\"][name=\"fields._PolicyPaymentInputDoc.subsequentPayorData$lastName.value\"]");

    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    public ILocator N1PaymentButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentPlan.value-chip-wrapper");

    public ILocator OTHERButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$payerID.value-OTHER-payer-chip-chip");

    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    public ILocator State => _page.Locator("[id=\"_temp.fields._PolicyPaymentInputDoc.subsequentPayorDataAddress$state.value\"]");

    public ILocator TableRowCellLink => _page.GetByText("Link", new() { Exact = true });

    public ILocator ZipCode => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.subsequentPayorDataAddress$zipCode.value\"][name=\"fields._PolicyPaymentInputDoc.subsequentPayorDataAddress$zipCode.value\"]");

}
