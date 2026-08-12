using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQPreQualificationLocators
{
    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnChkBoxCheckBoxNoneOfTheAbove(IPage page) =>
        page.Locator("#fields\\\\.data\\\\.policy\\\\.preQualificationQuestionPolicy\\\\$noneOfTheAbove\\\\.value-checkbox");

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnNext(IPage page) =>
        page.GetByText("Next", new() { Exact = true });

}
