using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPPrimaryInsuredDetailsGeneralUWQuestions
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPPrimaryInsuredDetailsGeneralUWQuestions(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator GeneralUWQuestionsHeading => EQBOPPrimaryInsuredDetailsGeneralUWQuestionsLocators.GeneralUWQuestionsHeading(_page);

    public Task PressGeneralUWQuestionsHeadingAsync(string key) => GeneralUWQuestionsHeading.PressAsync(key);

    public Task DoubleClickGeneralUWQuestionsHeadingAsync() => GeneralUWQuestionsHeading.DblClickAsync();

    public Task WaitForGeneralUWQuestionsHeadingAsync() =>
        GeneralUWQuestionsHeading.WaitForAsync(new() { State = WaitForSelectorState.Visible });

}
