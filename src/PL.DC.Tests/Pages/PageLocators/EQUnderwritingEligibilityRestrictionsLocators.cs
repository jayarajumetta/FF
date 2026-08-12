using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQUnderwritingEligibilityRestrictionsLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator Yes(IPage page) =>
        page.GetByTestId("fields.data.policy.underwritingQuestionsPolicy$felonyConviction.value-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator No(IPage page) =>
        page.GetByTestId("fields.data.policy.underwritingQuestionsPolicy$felonyConviction.value-chip-wrapper");

}
