using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQAddAdditionalDriver1
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQAddAdditionalDriver1(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator Driver1 => EQAddAdditionalDriver1Locators.Driver1(_page);

    public Task PressDriver1Async(string key) => Driver1.PressAsync(key);

    public Task DoubleClickDriver1Async() => Driver1.DblClickAsync();

    public async Task StoreDriver1Async(string key)
    {
        var value = await Driver1.TextContentAsync() ?? await Driver1.InputValueAsync();
        _data.SetBuffer(key, value ?? string.Empty);
    }

}
