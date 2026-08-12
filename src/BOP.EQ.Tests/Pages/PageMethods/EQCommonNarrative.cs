using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonNarrative
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonNarrative(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator NarrativeScreenHeading => EQCommonNarrativeLocators.NarrativeScreenHeading(_page);

    public Task PressNarrativeScreenHeadingAsync(string key) => NarrativeScreenHeading.PressAsync(key);

    public Task DoubleClickNarrativeScreenHeadingAsync() => NarrativeScreenHeading.DblClickAsync();

    public Task WaitForNarrativeScreenHeadingAsync() =>
        NarrativeScreenHeading.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator AddNarrative => EQCommonNarrativeLocators.AddNarrative(_page);

    public Task PressAddNarrativeAsync(string key) => AddNarrative.PressAsync(key);

    public Task DoubleClickAddNarrativeAsync() => AddNarrative.DblClickAsync();

    public Task ClickAddNarrativeAsync() => AddNarrative.ClickAsync();

    private ILocator Edit => EQCommonNarrativeLocators.Edit(_page);

    public Task PressEditAsync(string key) => Edit.PressAsync(key);

    public Task DoubleClickEditAsync() => Edit.DblClickAsync();

    public Task ClickEditAsync() => Edit.ClickAsync();

    private ILocator DescriptionOfTheBusinessExposuresActivitiesAndExperience => EQCommonNarrativeLocators.DescriptionOfTheBusinessExposuresActivitiesAndExperience(_page);

    public Task PressDescriptionOfTheBusinessExposuresActivitiesAndExperienceAsync(string key) => DescriptionOfTheBusinessExposuresActivitiesAndExperience.PressAsync(key);

    public Task DoubleClickDescriptionOfTheBusinessExposuresActivitiesAndExperienceAsync() => DescriptionOfTheBusinessExposuresActivitiesAndExperience.DblClickAsync();

    public Task SetDescriptionOfTheBusinessExposuresActivitiesAndExperienceAsync(string value) =>
        UiActions.ApplyInputAsync(_page, DescriptionOfTheBusinessExposuresActivitiesAndExperience, _data.Resolve(value));

    public Task TypeDescriptionOfTheBusinessExposuresActivitiesAndExperienceAsync(string value, float delayMs = 40) =>
        DescriptionOfTheBusinessExposuresActivitiesAndExperience.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Save => EQCommonNarrativeLocators.Save(_page);

    public Task PressSaveAsync(string key) => Save.PressAsync(key);

    public Task DoubleClickSaveAsync() => Save.DblClickAsync();

    public Task ClickSaveAsync() => Save.ClickAsync();

    private ILocator UserDateAndTimestamp => EQCommonNarrativeLocators.UserDateAndTimestamp(_page);

    public Task PressUserDateAndTimestampAsync(string key) => UserDateAndTimestamp.PressAsync(key);

    public Task DoubleClickUserDateAndTimestampAsync() => UserDateAndTimestamp.DblClickAsync();

    public Task VerifyUserDateAndTimestampAsync(string expected) =>
        Expect(UserDateAndTimestamp).ToContainTextAsync(_data.Resolve(expected));

    public Task WaitForUserDateAndTimestampAsync() =>
        UserDateAndTimestamp.WaitForAsync(new() { State = WaitForSelectorState.Visible });

}
