using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBillingLocators
{
        public static ILocator HdrBilling(IPage page) =>
        page.Locator("id=pageTitle");

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnCreateNewBillingAccount(IPage page) =>
        page.GetByText("Create New Billing Account", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnDirectBill(IPage page) =>
        page.GetByText("Direct Bill", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Btn1Payment(IPage page) =>
        page.GetByText("1 Payment", new() { Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtPaymentDueDate(IPage page) =>
        page.Locator("#fields\\\\._PolicyPaymentInputDoc\\\\.subsequentPaymentData\\\\$dueDate\\\\.value");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator RdBtnFullBalance(IPage page) =>
        page.Locator("#fields\\\\._PolicyPaymentInputDoc\\\\.initialPaymentData\\\\$amountSelection\\\\.value-1-input");

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnCHECK(IPage page) =>
        page.GetByText("Check", new() { Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtCheckNumber(IPage page) =>
        page.Locator("#fields\\\\._PolicyPaymentInputDoc\\\\.initialPaymentData\\\\$checkNumber\\\\.value");

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnBillingNEXT(IPage page) =>
        page.GetByText("Next", new() { Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtDueDate(IPage page) =>
        page.Locator("#fields\\\\._PolicyPaymentInputDoc\\\\.subsequentPaymentData\\\\$dueDate\\\\.value");

}
