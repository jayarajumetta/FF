using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class SubmissionReferApproveCompleteIssuanceBackToAgentLocators
{
        public static ILocator Approve(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Approve", Exact = true });

        // REVIEW: no stronger source locator.
    public static ILocator ReferRequestIssuance(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "{REGEX[\"Refer|Request Issuance\"]}", Exact = true });

        public static ILocator CompleteIssuance(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Complete Issuance", Exact = true });

        public static ILocator BackToAgent(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Back to Agent", Exact = true });

}
