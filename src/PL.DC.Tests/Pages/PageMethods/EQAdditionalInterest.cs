using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQAdditionalInterest
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQAdditionalInterest(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator H1AdditionalInterestSummary => EQAdditionalInterestLocators.H1AdditionalInterestSummary(_page);

    public Task PressH1AdditionalInterestSummaryAsync(string key) => H1AdditionalInterestSummary.PressAsync(key);

    public Task DoubleClickH1AdditionalInterestSummaryAsync() => H1AdditionalInterestSummary.DblClickAsync();

    public Task WaitForH1AdditionalInterestSummaryAsync() =>
        H1AdditionalInterestSummary.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator Next => EQAdditionalInterestLocators.Next(_page);

    public Task PressNextAsync(string key) => Next.PressAsync(key);

    public Task DoubleClickNextAsync() => Next.DblClickAsync();

    public Task ClickNextAsync() => Next.ClickAsync();

}
