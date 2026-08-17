using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class BusinessClassificationLocators
{
    private readonly IPage _page;
    public BusinessClassificationLocators(IPage page) => _page = page;

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IndustryClassCodeRestrictionsHeading => _page.GetByText("Industry / Class Code Restrictions Heading", new() { Exact = true });

    // Source modules: EQ|BOP|Prequalification|Industry Class Code Restrictions | confidence=High score=127
    public ILocator NoneOfTheAbove => _page.GetByRole(AriaRole.Checkbox, new() { Name = "None of the Above", Exact = true });

    // Source modules: EQ|BOP|Primary Insured Details| General UW Questions | confidence=High score=130
    public ILocator NoneOfTheAboveCheckbox => _page.GetByTestId("fields.underwritingQuestionsGeneralUWQuestions.generalInformationNewInput$noneOfTheAboveGeneralUWQuestions.value");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

}