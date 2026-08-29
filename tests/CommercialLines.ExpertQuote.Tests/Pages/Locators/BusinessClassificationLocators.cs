using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class BusinessClassificationLocators
{
    private readonly IPage _page;
    public BusinessClassificationLocators(IPage page) => _page = page;

    public ILocator IndustryClassCodeRestrictionsHeading => _page.Locator("[id=\"UnderwritingQuestions.Constant_IndustryClassCodeRestrictions-0-layout\"]");

    public ILocator NoneOfTheAbove => _page.Locator("[id=\"fields.data.underwritingQuestions.underwritingQuestions$noneOfTheAboveIndustryClassCodeRestrictions.value-checkbox\"]");

    public ILocator NoneOfTheAboveCheckbox => _page.GetByTestId("fields.underwritingQuestionsGeneralUWQuestions.generalInformationNewInput$noneOfTheAboveGeneralUWQuestions.value");

    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

}
