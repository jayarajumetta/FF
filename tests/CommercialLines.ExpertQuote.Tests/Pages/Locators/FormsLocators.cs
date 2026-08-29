using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class FormsLocators
{
    private readonly IPage _page;
    public FormsLocators(IPage page) => _page = page;

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator FormsAPIRequest01660 => _page.GetByText("Forms API Request", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator FormsAPIRequestB50D4 => FormsAPIRequest01660; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator FormsAPIResponse3FBAF => _page.GetByText("Forms API Response", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator FormsAPIResponse53891 => FormsAPIResponse3FBAF; // semantic alias; locator defined once

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: Indicators and Errors | Loading Message | Id
    public ILocator LoadingMessage => _page.Locator("[id=\"loadingMessage\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator N1ResultsFoundCurrentlyShowing11 => _page.GetByText("1 results found. Currently showing 1 - 1.", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: Dashboard|QuickSearch | QuickSearch Button | Id
    public ILocator QuickSearchButton => _page.Locator("[id=\"id_quickSearch\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator SearchText => _page.Locator("[id='quickSearchTextId-inputEl']");

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: TransACT | View Policy  (*) | Id
    public ILocator ViewPolicy => _page.Locator("[id=\"returnToActiveSessionA\"]");

}
