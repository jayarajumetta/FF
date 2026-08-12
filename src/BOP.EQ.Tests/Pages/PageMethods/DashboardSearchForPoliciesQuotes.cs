using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class DashboardSearchForPoliciesQuotes
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public DashboardSearchForPoliciesQuotes(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator ViewPolicy => DashboardSearchForPoliciesQuotesLocators.ViewPolicy(_page);

    public Task PressViewPolicyAsync(string key) => ViewPolicy.PressAsync(key);

    public Task DoubleClickViewPolicyAsync() => ViewPolicy.DblClickAsync();

    public Task ClickViewPolicyAsync() => ViewPolicy.ClickAsync();

    public Task VerifyViewPolicyAsync(string expected) =>
        Expect(ViewPolicy).ToContainTextAsync(_data.Resolve(expected));

    public Task WaitForViewPolicyAsync() =>
        ViewPolicy.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator SearchMethodEGDescriptionPolicy => DashboardSearchForPoliciesQuotesLocators.SearchMethodEGDescriptionPolicy(_page);

    public Task PressSearchMethodEGDescriptionPolicyAsync(string key) => SearchMethodEGDescriptionPolicy.PressAsync(key);

    public Task DoubleClickSearchMethodEGDescriptionPolicyAsync() => SearchMethodEGDescriptionPolicy.DblClickAsync();

    public Task SetSearchMethodEGDescriptionPolicyAsync(string value) =>
        UiActions.ApplyInputAsync(_page, SearchMethodEGDescriptionPolicy, _data.Resolve(value));

    public Task TypeSearchMethodEGDescriptionPolicyAsync(string value, float delayMs = 40) =>
        SearchMethodEGDescriptionPolicy.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator SearchButton => DashboardSearchForPoliciesQuotesLocators.SearchButton(_page);

    public Task PressSearchButtonAsync(string key) => SearchButton.PressAsync(key);

    public Task DoubleClickSearchButtonAsync() => SearchButton.DblClickAsync();

    public Task ClickSearchButtonAsync() => SearchButton.ClickAsync();

    public Task WaitForSearchButtonAsync() =>
        SearchButton.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator Item1ResultsFoundCurrentlyShowing11 => DashboardSearchForPoliciesQuotesLocators.Item1ResultsFoundCurrentlyShowing11(_page);

    public Task PressItem1ResultsFoundCurrentlyShowing11Async(string key) => Item1ResultsFoundCurrentlyShowing11.PressAsync(key);

    public Task DoubleClickItem1ResultsFoundCurrentlyShowing11Async() => Item1ResultsFoundCurrentlyShowing11.DblClickAsync();

    public Task WaitForItem1ResultsFoundCurrentlyShowing11Async() =>
        Item1ResultsFoundCurrentlyShowing11.WaitForAsync(new() { State = WaitForSelectorState.Visible });

}
