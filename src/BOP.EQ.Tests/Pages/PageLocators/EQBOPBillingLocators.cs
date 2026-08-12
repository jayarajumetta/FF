using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPBillingLocators
{
        public static ILocator BillingInformationHeading(IPage page) =>
        page.GetByText("Billing Information", new() { Exact = true });

        public static ILocator MortgageeButton(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "MortgageeCONNECT ONE BANK", Exact = true });

        public static ILocator CreateNewBillingAccount(IPage page) =>
        page.GetByTestId("fields._PolicyPaymentInputDoc._PolicyPaymentInputDoc$billingCenterAccount.value-new-account-chip-chip");

        public static ILocator OTHERButton(IPage page) =>
        page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$payerID.value-OTHER-payer-chip-chip");

        public static ILocator FirstName(IPage page) =>
        page.Locator("id=fields._PolicyPaymentInputDoc.subsequentPayorData$firstName.value");

        public static ILocator LastName(IPage page) =>
        page.Locator("id=fields._PolicyPaymentInputDoc.subsequentPayorData$lastName.value");

        public static ILocator BusinessName(IPage page) =>
        page.Locator("id=fields._PolicyPaymentInputDoc.subsequentPayorData$businessName.value");

        public static ILocator Address1(IPage page) =>
        page.Locator("id=fields._PolicyPaymentInputDoc.subsequentPayorDataAddress$address1.value");

        public static ILocator City(IPage page) =>
        page.Locator("id=fields._PolicyPaymentInputDoc.subsequentPayorDataAddress$city.value");

        public static ILocator State(IPage page) =>
        page.Locator("id=_temp.fields._PolicyPaymentInputDoc.subsequentPayorDataAddress$state.value");

        public static ILocator ZipCode(IPage page) =>
        page.Locator("id=fields._PolicyPaymentInputDoc.subsequentPayorDataAddress$zipCode.value");

        public static ILocator DirectBillButton(IPage page) =>
        page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentMethod.value-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator Item1PaymentButton(IPage page) =>
        page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentPlan.value-chip-wrapper");

        public static ILocator ChoosePaymentDueDate(IPage page) =>
        page.Locator("id=fields._PolicyPaymentInputDoc.subsequentPaymentData$dueDate.value");

        public static ILocator CheckButton(IPage page) =>
        page.GetByTestId("fields._PolicyPaymentInputDoc.initialPaymentData$paymentMethod.value-chip-wrapper");

        public static ILocator CreditCardButton(IPage page) =>
        page.GetByTestId("fields._PolicyPaymentInputDoc.initialPaymentData$paymentMethod.value-chip-wrapper");

        public static ILocator CheckNumber(IPage page) =>
        page.Locator("id=fields._PolicyPaymentInputDoc.initialPaymentData$checkNumber.value");

        public static ILocator InitialPaymentFullBalance(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "$3,615.00 (Full Balance)", Exact = true });

}
