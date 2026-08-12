using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQOtherPolicyCoveragesSectionNew
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQOtherPolicyCoveragesSectionNew(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator H1AdditionalCoverages => EQOtherPolicyCoveragesSectionNewLocators.H1AdditionalCoverages(_page);

    public Task PressH1AdditionalCoveragesAsync(string key) => H1AdditionalCoverages.PressAsync(key);

    public Task DoubleClickH1AdditionalCoveragesAsync() => H1AdditionalCoverages.DblClickAsync();

    public Task WaitForH1AdditionalCoveragesAsync() =>
        H1AdditionalCoverages.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator TortOption => EQOtherPolicyCoveragesSectionNewLocators.TortOption(_page);

    public Task PressTortOptionAsync(string key) => TortOption.PressAsync(key);

    public Task DoubleClickTortOptionAsync() => TortOption.DblClickAsync();

    public Task SetTortOptionAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TortOption, _data.Resolve(value));

    public Task TypeTortOptionAsync(string value, float delayMs = 40) =>
        TortOption.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator IncomeLossCoverage => EQOtherPolicyCoveragesSectionNewLocators.IncomeLossCoverage(_page);

    public Task PressIncomeLossCoverageAsync(string key) => IncomeLossCoverage.PressAsync(key);

    public Task DoubleClickIncomeLossCoverageAsync() => IncomeLossCoverage.DblClickAsync();

    public Task SetIncomeLossCoverageAsync(string value) =>
        UiActions.ApplyInputAsync(_page, IncomeLossCoverage, _data.Resolve(value));

    public Task TypeIncomeLossCoverageAsync(string value, float delayMs = 40) =>
        IncomeLossCoverage.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator UMPD => EQOtherPolicyCoveragesSectionNewLocators.UMPD(_page);

    public Task PressUMPDAsync(string key) => UMPD.PressAsync(key);

    public Task DoubleClickUMPDAsync() => UMPD.DblClickAsync();

    public Task SetUMPDAsync(string value) =>
        UiActions.ApplyInputAsync(_page, UMPD, _data.Resolve(value));

    public Task TypeUMPDAsync(string value, float delayMs = 40) =>
        UMPD.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator UIMPD => EQOtherPolicyCoveragesSectionNewLocators.UIMPD(_page);

    public Task PressUIMPDAsync(string key) => UIMPD.PressAsync(key);

    public Task DoubleClickUIMPDAsync() => UIMPD.DblClickAsync();

    public Task ClickUIMPDAsync() => UIMPD.ClickAsync();

    private ILocator ADDCoverage => EQOtherPolicyCoveragesSectionNewLocators.ADDCoverage(_page);

    public Task PressADDCoverageAsync(string key) => ADDCoverage.PressAsync(key);

    public Task DoubleClickADDCoverageAsync() => ADDCoverage.DblClickAsync();

    public Task SetADDCoverageAsync(string value) =>
        UiActions.ApplyInputAsync(_page, ADDCoverage, _data.Resolve(value));

    public Task TypeADDCoverageAsync(string value, float delayMs = 40) =>
        ADDCoverage.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task WaitForADDCoverageAsync() =>
        ADDCoverage.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator ADDDriver1 => EQOtherPolicyCoveragesSectionNewLocators.ADDDriver1(_page);

    public Task PressADDDriver1Async(string key) => ADDDriver1.PressAsync(key);

    public Task DoubleClickADDDriver1Async() => ADDDriver1.DblClickAsync();

    public Task ClickADDDriver1Async() => ADDDriver1.ClickAsync();

    private ILocator ADDDriver2 => EQOtherPolicyCoveragesSectionNewLocators.ADDDriver2(_page);

    public Task PressADDDriver2Async(string key) => ADDDriver2.PressAsync(key);

    public Task DoubleClickADDDriver2Async() => ADDDriver2.DblClickAsync();

    public Task ClickADDDriver2Async() => ADDDriver2.ClickAsync();

    private ILocator ADDDriver3 => EQOtherPolicyCoveragesSectionNewLocators.ADDDriver3(_page);

    public Task PressADDDriver3Async(string key) => ADDDriver3.PressAsync(key);

    public Task DoubleClickADDDriver3Async() => ADDDriver3.DblClickAsync();

    public Task ClickADDDriver3Async() => ADDDriver3.ClickAsync();

    private ILocator ADDDriver4 => EQOtherPolicyCoveragesSectionNewLocators.ADDDriver4(_page);

    public Task PressADDDriver4Async(string key) => ADDDriver4.PressAsync(key);

    public Task DoubleClickADDDriver4Async() => ADDDriver4.DblClickAsync();

    public Task ClickADDDriver4Async() => ADDDriver4.ClickAsync();

    private ILocator ADDDriver5 => EQOtherPolicyCoveragesSectionNewLocators.ADDDriver5(_page);

    public Task PressADDDriver5Async(string key) => ADDDriver5.PressAsync(key);

    public Task DoubleClickADDDriver5Async() => ADDDriver5.DblClickAsync();

    public Task ClickADDDriver5Async() => ADDDriver5.ClickAsync();

    private ILocator TotalDisabilityCoverageDriver1 => EQOtherPolicyCoveragesSectionNewLocators.TotalDisabilityCoverageDriver1(_page);

    public Task PressTotalDisabilityCoverageDriver1Async(string key) => TotalDisabilityCoverageDriver1.PressAsync(key);

    public Task DoubleClickTotalDisabilityCoverageDriver1Async() => TotalDisabilityCoverageDriver1.DblClickAsync();

    public Task ClickTotalDisabilityCoverageDriver1Async() => TotalDisabilityCoverageDriver1.ClickAsync();

    private ILocator IncLiabilityClaimsOfFamilyMembers => EQOtherPolicyCoveragesSectionNewLocators.IncLiabilityClaimsOfFamilyMembers(_page);

    public Task PressIncLiabilityClaimsOfFamilyMembersAsync(string key) => IncLiabilityClaimsOfFamilyMembers.PressAsync(key);

    public Task DoubleClickIncLiabilityClaimsOfFamilyMembersAsync() => IncLiabilityClaimsOfFamilyMembers.DblClickAsync();

    public Task ClickIncLiabilityClaimsOfFamilyMembersAsync() => IncLiabilityClaimsOfFamilyMembers.ClickAsync();

    private ILocator ExtraordinaryMedicalBenefit => EQOtherPolicyCoveragesSectionNewLocators.ExtraordinaryMedicalBenefit(_page);

    public Task PressExtraordinaryMedicalBenefitAsync(string key) => ExtraordinaryMedicalBenefit.PressAsync(key);

    public Task DoubleClickExtraordinaryMedicalBenefitAsync() => ExtraordinaryMedicalBenefit.DblClickAsync();

    public Task ClickExtraordinaryMedicalBenefitAsync() => ExtraordinaryMedicalBenefit.ClickAsync();

    private ILocator WorkLossNo => EQOtherPolicyCoveragesSectionNewLocators.WorkLossNo(_page);

    public Task PressWorkLossNoAsync(string key) => WorkLossNo.PressAsync(key);

    public Task DoubleClickWorkLossNoAsync() => WorkLossNo.DblClickAsync();

    public Task ClickWorkLossNoAsync() => WorkLossNo.ClickAsync();

}
