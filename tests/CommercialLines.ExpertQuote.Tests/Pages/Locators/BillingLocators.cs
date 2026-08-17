using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class BillingLocators
{
    private readonly IPage _page;
    public BillingLocators(IPage page) => _page = page;

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    public ILocator Address1 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Address1", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator Billing => _page.GetByText("Billing", new() { Exact = true });

    // Source modules: EQ|BOP|Billing | confidence=Medium score=78
    public ILocator BillingInformationHeading => _page.GetByLabel("Billing Information Heading", new() { Exact = true });

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    public ILocator BusinessName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Business Name", Exact = true });

    // Source modules: EQ|BOP|Billing | confidence=High score=100
    public ILocator CheckButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.initialPaymentData$paymentMethod.value-chip-wrapper");

    // Source modules: EQ|BOP|Billing | confidence=High score=97
    public ILocator CheckNumber => _page.GetByRole(AriaRole.Textbox, new() { Name = "Check Number", Exact = true });

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    public ILocator ChoosePaymentDueDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Choose payment due date", Exact = true });

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    public ILocator City => _page.GetByRole(AriaRole.Textbox, new() { Name = "City", Exact = true });

    // Source modules: EQ|BOP|Billing | confidence=High score=130
    public ILocator CreateNewBillingAccount => _page.GetByTestId("fields._PolicyPaymentInputDoc._PolicyPaymentInputDoc$billingCenterAccount.value-new-account-chip-chip");

    // Source modules: EQ|BOP|Billing | confidence=High score=100
    public ILocator CreditCardButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.initialPaymentData$paymentMethod.value-chip-wrapper");

    // Source modules: EQ|BOP|Billing | confidence=High score=130
    public ILocator DirectBillButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentMethod.value-chip-wrapper");

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    public ILocator FirstName => _page.GetByRole(AriaRole.Textbox, new() { Name = "First Name", Exact = true });

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    public ILocator InitialPaymentFullBalance => _page.GetByRole(AriaRole.Radio, new() { Name = "Initial Payment - Full Balance", Exact = true });

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    public ILocator LastName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Last Name", Exact = true });

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ|BOP|Billing | confidence=High score=130
    public ILocator N1PaymentButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentPlan.value-chip-wrapper");

    // Source modules: EQ|BOP|Billing | confidence=High score=130
    public ILocator OTHERButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$payerID.value-OTHER-payer-chip-chip");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    public ILocator State => _page.GetByRole(AriaRole.Combobox, new() { Name = "State", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator TableRowCellLink => _page.GetByText("Link", new() { Exact = true });

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    public ILocator ZipCode => _page.GetByRole(AriaRole.Textbox, new() { Name = "Zip Code", Exact = true });

}