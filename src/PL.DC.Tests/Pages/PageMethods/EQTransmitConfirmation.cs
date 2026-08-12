using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQTransmitConfirmation
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQTransmitConfirmation(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator PolicyNumber => EQTransmitConfirmationLocators.PolicyNumber(_page);

    public Task PressPolicyNumberAsync(string key) => PolicyNumber.PressAsync(key);

    public Task DoubleClickPolicyNumberAsync() => PolicyNumber.DblClickAsync();

    public Task WaitForPolicyNumberAsync() =>
        PolicyNumber.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    public async Task StorePolicyNumberAsync(string key)
    {
        var value = await PolicyNumber.TextContentAsync() ?? await PolicyNumber.InputValueAsync();
        _data.SetBuffer(key, value ?? string.Empty);
    }

    private ILocator EffectiveDate => EQTransmitConfirmationLocators.EffectiveDate(_page);

    public Task PressEffectiveDateAsync(string key) => EffectiveDate.PressAsync(key);

    public Task DoubleClickEffectiveDateAsync() => EffectiveDate.DblClickAsync();

    public Task SelectEffectiveDateAsync(string value) =>
        EffectiveDate.SelectOptionAsync(_data.Resolve(value));

}
