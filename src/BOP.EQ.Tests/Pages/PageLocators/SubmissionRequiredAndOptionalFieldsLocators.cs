using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class SubmissionRequiredAndOptionalFieldsLocators
{
        public static ILocator SubmissionHeading(IPage page) =>
        page.Locator("id=pageTop");

        public static ILocator IsThisCoverageBound(IPage page) =>
        page.Locator("[data-duckcreek-id=\"PolicyWorkflowDataInput.IsCoverageBound*\"]");

        public static ILocator DoesThisChangeRepresentAReductionInCoverage(IPage page) =>
        page.Locator("[data-duckcreek-id=\"PolicyInput.ReductionInCoverage\"]");

        public static ILocator OrderAudit(IPage page) =>
        page.Locator("[data-duckcreek-id=\"PolicyInput.OrderAudit\"]");

}
