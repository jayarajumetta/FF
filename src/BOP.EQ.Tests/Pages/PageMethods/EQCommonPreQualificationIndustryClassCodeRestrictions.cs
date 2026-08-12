using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonPreQualificationIndustryClassCodeRestrictions
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonPreQualificationIndustryClassCodeRestrictions(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator IndustryClassCodeRestrictions => EQCommonPreQualificationIndustryClassCodeRestrictionsLocators.IndustryClassCodeRestrictions(_page);

    public Task PressIndustryClassCodeRestrictionsAsync(string key) => IndustryClassCodeRestrictions.PressAsync(key);

    public Task DoubleClickIndustryClassCodeRestrictionsAsync() => IndustryClassCodeRestrictions.DblClickAsync();

    public Task WaitForIndustryClassCodeRestrictionsAsync() =>
        IndustryClassCodeRestrictions.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator CheckBoxOutlineBlankNoneOfTheAbove => EQCommonPreQualificationIndustryClassCodeRestrictionsLocators.CheckBoxOutlineBlankNoneOfTheAbove(_page);

    public Task PressCheckBoxOutlineBlankNoneOfTheAboveAsync(string key) => CheckBoxOutlineBlankNoneOfTheAbove.PressAsync(key);

    public Task DoubleClickCheckBoxOutlineBlankNoneOfTheAboveAsync() => CheckBoxOutlineBlankNoneOfTheAbove.DblClickAsync();

    public Task ClickCheckBoxOutlineBlankNoneOfTheAboveAsync() => CheckBoxOutlineBlankNoneOfTheAbove.ClickAsync();

    private ILocator ResponseRequiredToContinue => EQCommonPreQualificationIndustryClassCodeRestrictionsLocators.ResponseRequiredToContinue(_page);

    public Task PressResponseRequiredToContinueAsync(string key) => ResponseRequiredToContinue.PressAsync(key);

    public Task DoubleClickResponseRequiredToContinueAsync() => ResponseRequiredToContinue.DblClickAsync();

    public Task SelectResponseRequiredToContinueAsync(string value) =>
        ResponseRequiredToContinue.SelectOptionAsync(_data.Resolve(value));

    private ILocator NextPrimaryInsuredDetails => EQCommonPreQualificationIndustryClassCodeRestrictionsLocators.NextPrimaryInsuredDetails(_page);

    public Task PressNextPrimaryInsuredDetailsAsync(string key) => NextPrimaryInsuredDetails.PressAsync(key);

    public Task DoubleClickNextPrimaryInsuredDetailsAsync() => NextPrimaryInsuredDetails.DblClickAsync();

    public Task ClickNextPrimaryInsuredDetailsAsync() => NextPrimaryInsuredDetails.ClickAsync();

}
