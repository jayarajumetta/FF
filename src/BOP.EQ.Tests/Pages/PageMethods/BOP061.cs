using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class BOP061
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public BOP061(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator BOPRestaurantQuestionnaireHeader => BOP061Locators.BOPRestaurantQuestionnaireHeader(_page);

    public Task PressBOPRestaurantQuestionnaireHeaderAsync(string key) => BOPRestaurantQuestionnaireHeader.PressAsync(key);

    public Task DoubleClickBOPRestaurantQuestionnaireHeaderAsync() => BOPRestaurantQuestionnaireHeader.DblClickAsync();

    public Task WaitForBOPRestaurantQuestionnaireHeaderAsync() =>
        BOPRestaurantQuestionnaireHeader.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator Exception => BOP061Locators.Exception(_page);

    public Task PressExceptionAsync(string key) => Exception.PressAsync(key);

    public Task DoubleClickExceptionAsync() => Exception.DblClickAsync();

    public Task ClickExceptionAsync() => Exception.ClickAsync();

    private ILocator OK => BOP061Locators.OK(_page);

    public Task PressOKAsync(string key) => OK.PressAsync(key);

    public Task DoubleClickOKAsync() => OK.DblClickAsync();

    public Task ClickOKAsync() => OK.ClickAsync();

}
