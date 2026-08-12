using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPPrimaryInsuredDetailsSnowplowQuestions
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPPrimaryInsuredDetailsSnowplowQuestions(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator SnowplowQuestions => EQBOPPrimaryInsuredDetailsSnowplowQuestionsLocators.SnowplowQuestions(_page);

    public Task PressSnowplowQuestionsAsync(string key) => SnowplowQuestions.PressAsync(key);

    public Task DoubleClickSnowplowQuestionsAsync() => SnowplowQuestions.DblClickAsync();

    public Task WaitForSnowplowQuestionsAsync() =>
        SnowplowQuestions.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator NoneOfTheAbove => EQBOPPrimaryInsuredDetailsSnowplowQuestionsLocators.NoneOfTheAbove(_page);

    public Task PressNoneOfTheAboveAsync(string key) => NoneOfTheAbove.PressAsync(key);

    public Task DoubleClickNoneOfTheAboveAsync() => NoneOfTheAbove.DblClickAsync();

    public Task ClickNoneOfTheAboveAsync() => NoneOfTheAbove.ClickAsync();

    private ILocator NextClaimsPriorInsurance => EQBOPPrimaryInsuredDetailsSnowplowQuestionsLocators.NextClaimsPriorInsurance(_page);

    public Task PressNextClaimsPriorInsuranceAsync(string key) => NextClaimsPriorInsurance.PressAsync(key);

    public Task DoubleClickNextClaimsPriorInsuranceAsync() => NextClaimsPriorInsurance.DblClickAsync();

    public Task ClickNextClaimsPriorInsuranceAsync() => NextClaimsPriorInsurance.ClickAsync();

}
