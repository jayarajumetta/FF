using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonPriorCarrierClaimsRequiredInfo
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonPriorCarrierClaimsRequiredInfo(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator PriorPolicyNo => EQCommonPriorCarrierClaimsRequiredInfoLocators.PriorPolicyNo(_page);

    public Task PressPriorPolicyNoAsync(string key) => PriorPolicyNo.PressAsync(key);

    public Task DoubleClickPriorPolicyNoAsync() => PriorPolicyNo.DblClickAsync();

    public Task SetPriorPolicyNoAsync(string value) =>
        UiActions.ApplyInputAsync(_page, PriorPolicyNo, _data.Resolve(value));

    public Task TypePriorPolicyNoAsync(string value, float delayMs = 40) =>
        PriorPolicyNo.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator YearsInBusiness => EQCommonPriorCarrierClaimsRequiredInfoLocators.YearsInBusiness(_page);

    public Task PressYearsInBusinessAsync(string key) => YearsInBusiness.PressAsync(key);

    public Task DoubleClickYearsInBusinessAsync() => YearsInBusiness.DblClickAsync();

    public Task SetYearsInBusinessAsync(string value) =>
        UiActions.ApplyInputAsync(_page, YearsInBusiness, _data.Resolve(value));

    public Task TypeYearsInBusinessAsync(string value, float delayMs = 40) =>
        YearsInBusiness.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Item3Years => EQCommonPriorCarrierClaimsRequiredInfoLocators.Item3Years(_page);

    public Task PressItem3YearsAsync(string key) => Item3Years.PressAsync(key);

    public Task DoubleClickItem3YearsAsync() => Item3Years.DblClickAsync();

    public Task SetItem3YearsAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Item3Years, _data.Resolve(value));

    public Task TypeItem3YearsAsync(string value, float delayMs = 40) =>
        Item3Years.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator PriorInsuranceLatestExpirationDate => EQCommonPriorCarrierClaimsRequiredInfoLocators.PriorInsuranceLatestExpirationDate(_page);

    public Task PressPriorInsuranceLatestExpirationDateAsync(string key) => PriorInsuranceLatestExpirationDate.PressAsync(key);

    public Task DoubleClickPriorInsuranceLatestExpirationDateAsync() => PriorInsuranceLatestExpirationDate.DblClickAsync();

    public Task SetPriorInsuranceLatestExpirationDateAsync(string value) =>
        UiActions.ApplyInputAsync(_page, PriorInsuranceLatestExpirationDate, _data.Resolve(value));

    public Task TypePriorInsuranceLatestExpirationDateAsync(string value, float delayMs = 40) =>
        PriorInsuranceLatestExpirationDate.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator PriorInsuranceLatestCarrier => EQCommonPriorCarrierClaimsRequiredInfoLocators.PriorInsuranceLatestCarrier(_page);

    public Task PressPriorInsuranceLatestCarrierAsync(string key) => PriorInsuranceLatestCarrier.PressAsync(key);

    public Task DoubleClickPriorInsuranceLatestCarrierAsync() => PriorInsuranceLatestCarrier.DblClickAsync();

    public Task SetPriorInsuranceLatestCarrierAsync(string value) =>
        UiActions.ApplyInputAsync(_page, PriorInsuranceLatestCarrier, _data.Resolve(value));

    public Task TypePriorInsuranceLatestCarrierAsync(string value, float delayMs = 40) =>
        PriorInsuranceLatestCarrier.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task ClickItem3YearsAsync() => Item3Years.ClickAsync();

    public Task ClickPriorPolicyNoAsync() => PriorPolicyNo.ClickAsync();
}
