using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EdgePreferencesFile
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EdgePreferencesFile(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator RootObject => EdgePreferencesFileLocators.RootObject(_page);

    public Task PressRootObjectAsync(string key) => RootObject.PressAsync(key);

    public Task DoubleClickRootObjectAsync() => RootObject.DblClickAsync();

}
