using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class BillingLocators
{
    private readonly IPage _page;
    public BillingLocators(IPage page) => _page = page;

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Billing | Address1 | Id+Name
    public ILocator Address1 => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.subsequentPayorDataAddress$address1.value\"][name=\"fields._PolicyPaymentInputDoc.subsequentPayorDataAddress$address1.value\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: Billing | Billing | Id
    public ILocator Billing => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: EQ|BOP|Billing | confidence=Medium score=78
    // v56 raw Tosca primary: EQ|BOP|Billing | Initial Payment - Minimum Balance | Id+Name
    public ILocator BillingInformationHeading => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.initialPaymentData$amountSelection.value-0-input\"][name=\"mat-radio-group-8\"]");

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Billing | Business Name | Id+Name
    public ILocator BusinessName => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.subsequentPayorData$businessName.value\"][name=\"fields._PolicyPaymentInputDoc.subsequentPayorData$businessName.value\"]");

    // Source modules: EQ|BOP|Billing | confidence=High score=100
    public ILocator CheckButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.initialPaymentData$paymentMethod.value-chip-wrapper");

    // Source modules: EQ|BOP|Billing | confidence=High score=97
    // v56 raw Tosca primary: EQ|BOP|Billing | Check Number | Id+Name
    public ILocator CheckNumber => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.initialPaymentData$checkNumber.value\"][name=\"fields._PolicyPaymentInputDoc.initialPaymentData$checkNumber.value\"]");

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Billing | Choose payment due date | Id+Name
    public ILocator ChoosePaymentDueDate => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.subsequentPaymentData$dueDate.value\"][name=\"fields._PolicyPaymentInputDoc.subsequentPaymentData$dueDate.value\"]");

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Billing | City | Id+Name
    public ILocator City => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.subsequentPayorDataAddress$city.value\"][name=\"fields._PolicyPaymentInputDoc.subsequentPayorDataAddress$city.value\"]");

    // Source modules: EQ|BOP|Billing | confidence=High score=130
    public ILocator CreateNewBillingAccount => _page.GetByTestId("fields._PolicyPaymentInputDoc._PolicyPaymentInputDoc$billingCenterAccount.value-new-account-chip-chip");

    // Source modules: EQ|BOP|Billing | confidence=High score=100
    public ILocator CreditCardButton => CheckButton; // semantic alias; locator defined once

    // Source modules: EQ|BOP|Billing | confidence=High score=130
    public ILocator DirectBillButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentMethod.value-chip-wrapper");

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Billing | First Name | Id+Name
    public ILocator FirstName => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.subsequentPayorData$firstName.value\"][name=\"fields._PolicyPaymentInputDoc.subsequentPayorData$firstName.value\"]");

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Billing | Initial Payment - Full Balance | Id+Name
    public ILocator InitialPaymentFullBalance => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.initialPaymentData$amountSelection.value-1-input\"][name=\"mat-radio-group-8\"]");

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Billing | Last Name | Id+Name
    public ILocator LastName => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.subsequentPayorData$lastName.value\"][name=\"fields._PolicyPaymentInputDoc.subsequentPayorData$lastName.value\"]");

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ|BOP|Billing | confidence=High score=130
    public ILocator N1PaymentButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentPlan.value-chip-wrapper");

    // Source modules: EQ|BOP|Billing | confidence=High score=130
    public ILocator OTHERButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$payerID.value-OTHER-payer-chip-chip");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Billing | State | Id
    public ILocator State => _page.Locator("[id=\"_temp.fields._PolicyPaymentInputDoc.subsequentPayorDataAddress$state.value\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator TableRowCellLink => _page.GetByText("Link", new() { Exact = true });

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Billing | Zip Code | Id+Name
    public ILocator ZipCode => _page.Locator("input[id=\"fields._PolicyPaymentInputDoc.subsequentPayorDataAddress$zipCode.value\"][name=\"fields._PolicyPaymentInputDoc.subsequentPayorDataAddress$zipCode.value\"]");

}
