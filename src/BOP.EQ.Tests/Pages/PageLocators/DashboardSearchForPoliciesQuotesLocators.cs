using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class DashboardSearchForPoliciesQuotesLocators
{
        public static ILocator ViewPolicy(IPage page) =>
        page.Locator("id=quoteListLoadQuoteA");

        public static ILocator SearchMethodEGDescriptionPolicy(IPage page) =>
        page.Locator("id=_keynameAdvSearch1-inputEl");

        public static ILocator SearchButton(IPage page) =>
        page.Locator("[data-duckcreek-id=\"Search\"]");

        public static ILocator Item1ResultsFoundCurrentlyShowing11(IPage page) =>
        page.GetByText("1 results found. Currently showing 1 - 1.", new() { Exact = true });

}
