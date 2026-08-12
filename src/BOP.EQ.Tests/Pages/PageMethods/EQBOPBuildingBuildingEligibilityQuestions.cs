using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPBuildingBuildingEligibilityQuestions
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPBuildingBuildingEligibilityQuestions(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator Save => EQBOPBuildingBuildingEligibilityQuestionsLocators.Save(_page);

    public Task PressSaveAsync(string key) => Save.PressAsync(key);

    public Task DoubleClickSaveAsync() => Save.DblClickAsync();

    public Task ClickSaveAsync() => Save.ClickAsync();

}
