using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPPrimaryInsuredDetailsGeneralUWQuestionsLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator GeneralUWQuestionsHeading(IPage page) =>
        page.Locator("id=UnderwritingQuestions.Constant_GeneralUWQuestions-0-layout");

}
