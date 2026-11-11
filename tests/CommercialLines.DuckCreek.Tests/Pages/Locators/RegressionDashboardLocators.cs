using Microsoft.Playwright;
namespace InsuranceAutomation.CLDC.Pages.Locators;
public sealed class RegressionDashboardLocators
{
    private readonly IPage _page;
    public RegressionDashboardLocators(IPage page) => _page = page;
    public ILocator QuickSearchMode => _page.Locator("#quickSearchModeId-inputEl");
    public ILocator QuickSearchText => _page.Locator("#quickSearchTextId-inputEl");
    public ILocator QuickSearchButton => _page.Locator("#id_quickSearch");
    public ILocator Search => _page.Locator("#id_Search");
    public ILocator AdvancedMethod => _page.Locator("#_keynameAdvSearch1-inputEl");
    public ILocator AdvancedCriteria => _page.Locator("#_keyvalueTextSearch1-inputEl");
    public ILocator ViewPolicy => _page.Locator("#quoteListLoadQuoteA, [data-tip='View Policy']").First;
    public ILocator LoadingIndicator => _page.Locator(".x-mask-msg, .x-mask-loading, [aria-label='Loading']").First;
}
