using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPPrimaryInsuredDetailsGeneralUWQuestions2Locators
{
    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator NoneOfTheAboveCheckBox(IPage page) =>
        page.Locator("#fields\\\\.underwritingQuestionsGeneralUWQuestions\\\\.generalInformationNewInput\\\\$noneOfTheAboveGeneralUWQuestions\\\\.value-checkbox");

}
