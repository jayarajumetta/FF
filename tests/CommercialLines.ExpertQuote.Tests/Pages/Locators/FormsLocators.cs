using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class FormsLocators
{
    private readonly IPage _page;
    public FormsLocators(IPage page) => _page = page;

    public ILocator FormsAPIRequest01660 => _page.GetByText("Forms API Request", new() { Exact = true });


    public ILocator FormsAPIResponse3FBAF => _page.GetByText("Forms API Response", new() { Exact = true });


    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    public ILocator LoadingMessage => _page.Locator("[id=\"loadingMessage\"]");

    public ILocator N1ResultsFoundCurrentlyShowing11 => _page.GetByText("1 results found. Currently showing 1 - 1.", new() { Exact = true });

    public ILocator QuickSearchButton => _page.Locator("[id=\"id_quickSearch\"]");

    public ILocator SearchText => _page.Locator("[id='quickSearchTextId-inputEl']");

    public ILocator ViewPolicy => _page.Locator("[id=\"returnToActiveSessionA\"]");

}
