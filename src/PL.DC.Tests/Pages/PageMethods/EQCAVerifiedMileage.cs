using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCAVerifiedMileage
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCAVerifiedMileage(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator OptOut => EQCAVerifiedMileageLocators.OptOut(_page);

    public Task PressOptOutAsync(string key) => OptOut.PressAsync(key);

    public Task DoubleClickOptOutAsync() => OptOut.DblClickAsync();

    public Task ClickOptOutAsync() => OptOut.ClickAsync();

}
