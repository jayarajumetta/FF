using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonSubmissionReferToUWLocators
{
        public static ILocator UnderwritingRulesAgentComments(IPage page) =>
        page.Locator("id=\"fields.data.policy - Step 2 Underwriting Rules.uWRulesReview.uWRuleReviewLevel8.rows[0].uWRuleReview$agentComments.value\"");

        public static ILocator ReferToUW(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Refer to UW", Exact = true });

}
