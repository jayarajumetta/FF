using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCycleUnderwriting
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCycleUnderwriting(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator HaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelony => EQCycleUnderwritingLocators.HaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelony(_page);

    public Task PressHaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelonyAsync(string key) => HaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelony.PressAsync(key);

    public Task DoubleClickHaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelonyAsync() => HaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelony.DblClickAsync();

    public Task WaitForHaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelonyAsync() =>
        HaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelony.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator No => EQCycleUnderwritingLocators.No(_page);

    public Task PressNoAsync(string key) => No.PressAsync(key);

    public Task DoubleClickNoAsync() => No.DblClickAsync();

    public Task ClickNoAsync() => No.ClickAsync();

    private ILocator IsAnyVintageCycleGaragedInADifferentLocation => EQCycleUnderwritingLocators.IsAnyVintageCycleGaragedInADifferentLocation(_page);

    public Task PressIsAnyVintageCycleGaragedInADifferentLocationAsync(string key) => IsAnyVintageCycleGaragedInADifferentLocation.PressAsync(key);

    public Task DoubleClickIsAnyVintageCycleGaragedInADifferentLocationAsync() => IsAnyVintageCycleGaragedInADifferentLocation.DblClickAsync();

    public Task WaitForIsAnyVintageCycleGaragedInADifferentLocationAsync() =>
        IsAnyVintageCycleGaragedInADifferentLocation.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator No1 => EQCycleUnderwritingLocators.No1(_page);

    public Task PressNo1Async(string key) => No1.PressAsync(key);

    public Task DoubleClickNo1Async() => No1.DblClickAsync();

    public Task ClickNo1Async() => No1.ClickAsync();

    private ILocator Next => EQCycleUnderwritingLocators.Next(_page);

    public Task PressNextAsync(string key) => Next.PressAsync(key);

    public Task DoubleClickNextAsync() => Next.DblClickAsync();

    public Task ClickNextAsync() => Next.ClickAsync();

}
