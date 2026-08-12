using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonTransactVerifyDCPremium
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonTransactVerifyDCPremium(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator PolicyNumber => EQCommonTransactVerifyDCPremiumLocators.PolicyNumber(_page);

    public Task PressPolicyNumberAsync(string key) => PolicyNumber.PressAsync(key);

    public Task DoubleClickPolicyNumberAsync() => PolicyNumber.DblClickAsync();

    public async Task StorePolicyNumberAsync(string key)
    {
        var value = await PolicyNumber.TextContentAsync() ?? await PolicyNumber.InputValueAsync();
        _data.SetBuffer(key, value ?? string.Empty);
    }

}
