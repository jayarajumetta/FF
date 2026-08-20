using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class FormsLocators
{
    private readonly IPage _page;
    public FormsLocators(IPage page) => _page = page;

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator FormsAPIRequest01660 => _page.GetByText("Forms API Request", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator FormsAPIRequestB50D4 => FormsAPIRequest01660; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator FormsAPIResponse3FBAF => _page.GetByText("Forms API Response", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator FormsAPIResponse53891 => FormsAPIResponse3FBAF; // semantic alias; locator defined once

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator LoadingMessage => _page.GetByText("Loading Message", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator N1ResultsFoundCurrentlyShowing11 => _page.GetByText("1 results found. Currently showing 1 - 1.", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator QuickSearchButton => _page.GetByText("QuickSearch Button", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator SearchText => _page.GetByText("Search Text", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ViewPolicy => _page.GetByText("View Policy", new() { Exact = true });

}
