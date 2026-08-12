using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonPreQualificationGeneralEligibilityRestrictions
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonPreQualificationGeneralEligibilityRestrictions(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator UncheckedNoneOfTheAbove => EQCommonPreQualificationGeneralEligibilityRestrictionsLocators.UncheckedNoneOfTheAbove(_page);

    public Task PressUncheckedNoneOfTheAboveAsync(string key) => UncheckedNoneOfTheAbove.PressAsync(key);

    public Task DoubleClickUncheckedNoneOfTheAboveAsync() => UncheckedNoneOfTheAbove.DblClickAsync();

    public Task SetUncheckedNoneOfTheAboveAsync(string value) =>
        UiActions.ApplyInputAsync(_page, UncheckedNoneOfTheAbove, _data.Resolve(value));

    public Task TypeUncheckedNoneOfTheAboveAsync(string value, float delayMs = 40) =>
        UncheckedNoneOfTheAbove.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task VerifyUncheckedNoneOfTheAboveAsync(string expected) =>
        Expect(UncheckedNoneOfTheAbove).ToContainTextAsync(_data.Resolve(expected));

    private ILocator ResponseRequiredToContinue => EQCommonPreQualificationGeneralEligibilityRestrictionsLocators.ResponseRequiredToContinue(_page);

    public Task PressResponseRequiredToContinueAsync(string key) => ResponseRequiredToContinue.PressAsync(key);

    public Task DoubleClickResponseRequiredToContinueAsync() => ResponseRequiredToContinue.DblClickAsync();

    public Task WaitForResponseRequiredToContinueAsync() =>
        ResponseRequiredToContinue.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator UncheckedConvictedOfAnyOtherTypeOfCrime => EQCommonPreQualificationGeneralEligibilityRestrictionsLocators.UncheckedConvictedOfAnyOtherTypeOfCrime(_page);

    public Task PressUncheckedConvictedOfAnyOtherTypeOfCrimeAsync(string key) => UncheckedConvictedOfAnyOtherTypeOfCrime.PressAsync(key);

    public Task DoubleClickUncheckedConvictedOfAnyOtherTypeOfCrimeAsync() => UncheckedConvictedOfAnyOtherTypeOfCrime.DblClickAsync();

    public Task ClickUncheckedConvictedOfAnyOtherTypeOfCrimeAsync() => UncheckedConvictedOfAnyOtherTypeOfCrime.ClickAsync();

    public Task WaitForUncheckedConvictedOfAnyOtherTypeOfCrimeAsync() =>
        UncheckedConvictedOfAnyOtherTypeOfCrime.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator Rule92005FelonyRule => EQCommonPreQualificationGeneralEligibilityRestrictionsLocators.Rule92005FelonyRule(_page);

    public Task PressRule92005FelonyRuleAsync(string key) => Rule92005FelonyRule.PressAsync(key);

    public Task DoubleClickRule92005FelonyRuleAsync() => Rule92005FelonyRule.DblClickAsync();

    public Task VerifyRule92005FelonyRuleAsync(string expected) =>
        Expect(Rule92005FelonyRule).ToContainTextAsync(_data.Resolve(expected));

    private ILocator GeneralEligibilityQuestions => EQCommonPreQualificationGeneralEligibilityRestrictionsLocators.GeneralEligibilityQuestions(_page);

    public Task PressGeneralEligibilityQuestionsAsync(string key) => GeneralEligibilityQuestions.PressAsync(key);

    public Task DoubleClickGeneralEligibilityQuestionsAsync() => GeneralEligibilityQuestions.DblClickAsync();

    public Task WaitForGeneralEligibilityQuestionsAsync() =>
        GeneralEligibilityQuestions.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator CheckedConvictedOfAnyOtherTypeOfCrime => EQCommonPreQualificationGeneralEligibilityRestrictionsLocators.CheckedConvictedOfAnyOtherTypeOfCrime(_page);

    public Task PressCheckedConvictedOfAnyOtherTypeOfCrimeAsync(string key) => CheckedConvictedOfAnyOtherTypeOfCrime.PressAsync(key);

    public Task DoubleClickCheckedConvictedOfAnyOtherTypeOfCrimeAsync() => CheckedConvictedOfAnyOtherTypeOfCrime.DblClickAsync();

    public Task WaitForCheckedConvictedOfAnyOtherTypeOfCrimeAsync() =>
        CheckedConvictedOfAnyOtherTypeOfCrime.WaitForAsync(new() { State = WaitForSelectorState.Visible });

}
