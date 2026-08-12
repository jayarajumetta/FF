using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class TransACTLocators
{
        public static ILocator TransACT(IPage page) =>
        page.Locator("id=pageTitle");

        public static ILocator PolicyStatus(IPage page) =>
        page.Locator("id=f_P1142D296E2AF41ADA4E2E1FCB6B2F1E3CA_2_1-inputEl");

        public static ILocator TransactionType(IPage page) =>
        page.Locator("id=f_tB2C8F4EC9E3041B7B52430914E990D15D2_2_1-inputEl");

        public static ILocator ViewPolicy(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "View Policy (BOPTESTPZAZ, JOHN DE)", Exact = true });

        public static ILocator Go(IPage page) =>
        page.Locator("[data-duckcreek-id=\"Go\"]");

        public static ILocator QuickFilterList(IPage page) =>
        page.Locator("id=f_tB2C8F4EC9E3041B7B52430914E990D15D5_2_1-inputEl");

        public static ILocator Policy(IPage page) =>
        page.Locator("id=f_P1142D296E2AF41ADA4E2E1FCB6B2F1E3C5_2_1-inputEl");

}
