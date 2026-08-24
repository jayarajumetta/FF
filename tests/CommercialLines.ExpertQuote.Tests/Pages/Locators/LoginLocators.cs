using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class LoginLocators
{
    private readonly IPage _page;
    public LoginLocators(IPage page) => _page = page;

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator BODY => _page.GetByText("BODY", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator GetSessionIDBuffer => _page.GetByText("Get Session ID & Buffer", new() { Exact = true });

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator LoadingMessage => _page.GetByText("Loading Message", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator LoggedInUser => _page.GetByText("Logged In User", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator Login07237 => _page.GetByText("Login", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator Login0D21A => Login07237; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator LoginC45A2 => Login07237; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator QuickSearchButton => _page.GetByText("QuickSearch Button", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator SearchMode => _page.Locator("[id='quickSearchModeId-inputEl']");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator SearchText => _page.Locator("[id='quickSearchTextId-inputEl']");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator UserName => _page.GetByText("UserName", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator Username => _page.GetByText("Username", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ViewPolicy => _page.GetByText("View Policy", new() { Exact = true });

}
