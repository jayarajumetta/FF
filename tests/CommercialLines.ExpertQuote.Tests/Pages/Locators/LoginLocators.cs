using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class LoginLocators
{
    private readonly IPage _page;
    public LoginLocators(IPage page) => _page = page;

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator BODY => _page.GetByText("BODY", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator GetSessionIDBuffer => _page.GetByText("Get Session ID & Buffer", new() { Exact = true });

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: Indicators and Errors | Loading Message | Id
    public ILocator LoadingMessage => _page.Locator("[id=\"loadingMessage\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator LoggedInUser => _page.GetByText("Logged In User", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: Login | Login | DuckCreekId
    public ILocator Login07237 => _page.Locator("[duckcreekid=\"Login\"], [data-duckcreekid=\"Login\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator Login0D21A => Login07237; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator LoginC45A2 => Login07237; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: Dashboard|QuickSearch | QuickSearch Button | Id
    public ILocator QuickSearchButton => _page.Locator("[id=\"id_quickSearch\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator SearchMode => _page.Locator("[id='quickSearchModeId-inputEl']");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator SearchText => _page.Locator("[id='quickSearchTextId-inputEl']");

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: Login | Username | Id+Name
    public ILocator UserName => _page.Locator("input[id=\"username\"][name=\"pf.username\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: Login | Username | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as UserName
    public ILocator Username => UserName;

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: TransACT | View Policy  (*) | Id
    public ILocator ViewPolicy => _page.Locator("[id=\"returnToActiveSessionA\"]");

}
