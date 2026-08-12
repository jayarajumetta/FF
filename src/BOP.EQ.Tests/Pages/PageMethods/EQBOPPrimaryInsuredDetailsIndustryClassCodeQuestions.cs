using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPPrimaryInsuredDetailsIndustryClassCodeQuestions
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPPrimaryInsuredDetailsIndustryClassCodeQuestions(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator IndustryClassCodeQuestionsHeading => EQBOPPrimaryInsuredDetailsIndustryClassCodeQuestionsLocators.IndustryClassCodeQuestionsHeading(_page);

    public Task PressIndustryClassCodeQuestionsHeadingAsync(string key) => IndustryClassCodeQuestionsHeading.PressAsync(key);

    public Task DoubleClickIndustryClassCodeQuestionsHeadingAsync() => IndustryClassCodeQuestionsHeading.DblClickAsync();

    public Task WaitForIndustryClassCodeQuestionsHeadingAsync() =>
        IndustryClassCodeQuestionsHeading.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator NoneOfTheAboveCheckbox => EQBOPPrimaryInsuredDetailsIndustryClassCodeQuestionsLocators.NoneOfTheAboveCheckbox(_page);

    public Task PressNoneOfTheAboveCheckboxAsync(string key) => NoneOfTheAboveCheckbox.PressAsync(key);

    public Task DoubleClickNoneOfTheAboveCheckboxAsync() => NoneOfTheAboveCheckbox.DblClickAsync();

    public Task SetNoneOfTheAboveCheckboxAsync(string value) =>
        UiActions.ApplyInputAsync(_page, NoneOfTheAboveCheckbox, _data.Resolve(value));

    public Task TypeNoneOfTheAboveCheckboxAsync(string value, float delayMs = 40) =>
        NoneOfTheAboveCheckbox.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

}
