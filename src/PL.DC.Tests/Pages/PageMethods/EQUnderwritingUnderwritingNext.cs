using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQUnderwritingUnderwritingNext
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQUnderwritingUnderwritingNext(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator Next => EQUnderwritingUnderwritingNextLocators.Next(_page);

    public Task PressNextAsync(string key) => Next.PressAsync(key);

    public Task DoubleClickNextAsync() => Next.DblClickAsync();

    public Task ClickNextAsync() => Next.ClickAsync();

}
