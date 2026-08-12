using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPBuildingSnowAndIceRemovalQuestion
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPBuildingSnowAndIceRemovalQuestion(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator No => EQBOPBuildingSnowAndIceRemovalQuestionLocators.No(_page);

    public Task PressNoAsync(string key) => No.PressAsync(key);

    public Task DoubleClickNoAsync() => No.DblClickAsync();

    public Task ClickNoAsync() => No.ClickAsync();

}
