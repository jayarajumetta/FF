using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQPersonalInjuryProtectionSectionNew
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQPersonalInjuryProtectionSectionNew(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator HouseholdMembersAge65OrReceivingPension => EQPersonalInjuryProtectionSectionNewLocators.HouseholdMembersAge65OrReceivingPension(_page);

    public Task PressHouseholdMembersAge65OrReceivingPensionAsync(string key) => HouseholdMembersAge65OrReceivingPension.PressAsync(key);

    public Task DoubleClickHouseholdMembersAge65OrReceivingPensionAsync() => HouseholdMembersAge65OrReceivingPension.DblClickAsync();

    public Task ClickHouseholdMembersAge65OrReceivingPensionAsync() => HouseholdMembersAge65OrReceivingPension.ClickAsync();

    private ILocator PIPLimit => EQPersonalInjuryProtectionSectionNewLocators.PIPLimit(_page);

    public Task PressPIPLimitAsync(string key) => PIPLimit.PressAsync(key);

    public Task DoubleClickPIPLimitAsync() => PIPLimit.DblClickAsync();

    public Task SetPIPLimitAsync(string value) =>
        UiActions.ApplyInputAsync(_page, PIPLimit, _data.Resolve(value));

    public Task TypePIPLimitAsync(string value, float delayMs = 40) =>
        PIPLimit.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator PIPDeductible => EQPersonalInjuryProtectionSectionNewLocators.PIPDeductible(_page);

    public Task PressPIPDeductibleAsync(string key) => PIPDeductible.PressAsync(key);

    public Task DoubleClickPIPDeductibleAsync() => PIPDeductible.DblClickAsync();

    public Task SetPIPDeductibleAsync(string value) =>
        UiActions.ApplyInputAsync(_page, PIPDeductible, _data.Resolve(value));

    public Task TypePIPDeductibleAsync(string value, float delayMs = 40) =>
        PIPDeductible.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator AdditionalPIP => EQPersonalInjuryProtectionSectionNewLocators.AdditionalPIP(_page);

    public Task PressAdditionalPIPAsync(string key) => AdditionalPIP.PressAsync(key);

    public Task DoubleClickAdditionalPIPAsync() => AdditionalPIP.DblClickAsync();

    public Task ClickAdditionalPIPAsync() => AdditionalPIP.ClickAsync();

    private ILocator PIPStacking => EQPersonalInjuryProtectionSectionNewLocators.PIPStacking(_page);

    public Task PressPIPStackingAsync(string key) => PIPStacking.PressAsync(key);

    public Task DoubleClickPIPStackingAsync() => PIPStacking.DblClickAsync();

    public Task ClickPIPStackingAsync() => PIPStacking.ClickAsync();

    private ILocator ExtraPIPOption => EQPersonalInjuryProtectionSectionNewLocators.ExtraPIPOption(_page);

    public Task PressExtraPIPOptionAsync(string key) => ExtraPIPOption.PressAsync(key);

    public Task DoubleClickExtraPIPOptionAsync() => ExtraPIPOption.DblClickAsync();

    public Task SetExtraPIPOptionAsync(string value) =>
        UiActions.ApplyInputAsync(_page, ExtraPIPOption, _data.Resolve(value));

    public Task TypeExtraPIPOptionAsync(string value, float delayMs = 40) =>
        ExtraPIPOption.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator AutoHealthInsurer => EQPersonalInjuryProtectionSectionNewLocators.AutoHealthInsurer(_page);

    public Task PressAutoHealthInsurerAsync(string key) => AutoHealthInsurer.PressAsync(key);

    public Task DoubleClickAutoHealthInsurerAsync() => AutoHealthInsurer.DblClickAsync();

    public Task SetAutoHealthInsurerAsync(string value) =>
        UiActions.ApplyInputAsync(_page, AutoHealthInsurer, _data.Resolve(value));

    public Task TypeAutoHealthInsurerAsync(string value, float delayMs = 40) =>
        AutoHealthInsurer.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator MedicalExpenseElimination => EQPersonalInjuryProtectionSectionNewLocators.MedicalExpenseElimination(_page);

    public Task PressMedicalExpenseEliminationAsync(string key) => MedicalExpenseElimination.PressAsync(key);

    public Task DoubleClickMedicalExpenseEliminationAsync() => MedicalExpenseElimination.DblClickAsync();

    public Task ClickMedicalExpenseEliminationAsync() => MedicalExpenseElimination.ClickAsync();

    private ILocator WorkLossNo => EQPersonalInjuryProtectionSectionNewLocators.WorkLossNo(_page);

    public Task PressWorkLossNoAsync(string key) => WorkLossNo.PressAsync(key);

    public Task DoubleClickWorkLossNoAsync() => WorkLossNo.DblClickAsync();

    public Task ClickWorkLossNoAsync() => WorkLossNo.ClickAsync();

    private ILocator BroadenedPIP => EQPersonalInjuryProtectionSectionNewLocators.BroadenedPIP(_page);

    public Task PressBroadenedPIPAsync(string key) => BroadenedPIP.PressAsync(key);

    public Task DoubleClickBroadenedPIPAsync() => BroadenedPIP.DblClickAsync();

    public Task ClickBroadenedPIPAsync() => BroadenedPIP.ClickAsync();

    private ILocator AdditionalDeathBenefit => EQPersonalInjuryProtectionSectionNewLocators.AdditionalDeathBenefit(_page);

    public Task PressAdditionalDeathBenefitAsync(string key) => AdditionalDeathBenefit.PressAsync(key);

    public Task DoubleClickAdditionalDeathBenefitAsync() => AdditionalDeathBenefit.DblClickAsync();

    public Task ClickAdditionalDeathBenefitAsync() => AdditionalDeathBenefit.ClickAsync();

    private ILocator WaiverOfIncomeLoss => EQPersonalInjuryProtectionSectionNewLocators.WaiverOfIncomeLoss(_page);

    public Task PressWaiverOfIncomeLossAsync(string key) => WaiverOfIncomeLoss.PressAsync(key);

    public Task DoubleClickWaiverOfIncomeLossAsync() => WaiverOfIncomeLoss.DblClickAsync();

    public Task ClickWaiverOfIncomeLossAsync() => WaiverOfIncomeLoss.ClickAsync();

}
