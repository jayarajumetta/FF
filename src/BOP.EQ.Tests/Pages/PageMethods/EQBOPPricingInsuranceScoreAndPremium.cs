using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPPricingInsuranceScoreAndPremium
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPPricingInsuranceScoreAndPremium(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator InsuranceScoreRefNumber => EQBOPPricingInsuranceScoreAndPremiumLocators.InsuranceScoreRefNumber(_page);

    public Task PressInsuranceScoreRefNumberAsync(string key) => InsuranceScoreRefNumber.PressAsync(key);

    public Task DoubleClickInsuranceScoreRefNumberAsync() => InsuranceScoreRefNumber.DblClickAsync();

    public Task VerifyInsuranceScoreRefNumberAsync(string expected) =>
        Expect(InsuranceScoreRefNumber).ToContainTextAsync(_data.Resolve(expected));

    private ILocator Premium => EQBOPPricingInsuranceScoreAndPremiumLocators.Premium(_page);

    public Task PressPremiumAsync(string key) => Premium.PressAsync(key);

    public Task DoubleClickPremiumAsync() => Premium.DblClickAsync();

    public async Task StorePremiumAsync(string key)
    {
        var value = await Premium.TextContentAsync() ?? await Premium.InputValueAsync();
        _data.SetBuffer(key, value ?? string.Empty);
    }

}
