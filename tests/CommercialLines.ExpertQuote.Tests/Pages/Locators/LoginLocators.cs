using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class LoginLocators
{
    private readonly IPage _page;
    public LoginLocators(IPage page) => _page = page;

    public ILocator BODY => _page.GetByText("BODY", new() { Exact = true });

    public ILocator GetSessionIDBuffer => _page.GetByText("Get Session ID & Buffer", new() { Exact = true });

    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    public ILocator LoadingMessage => _page.Locator("[id=\"loadingMessage\"]");

    public ILocator LoggedInUser => _page.GetByText("Logged In User", new() { Exact = true });

    public ILocator Login07237 => _page.Locator("[duckcreekid=\"Login\"], [data-duckcreekid=\"Login\"]");



    public ILocator QuickSearchButton => _page.Locator("[id=\"id_quickSearch\"]");

    public ILocator SearchMode => _page.Locator("[id='quickSearchModeId-inputEl']");

    public ILocator SearchText => _page.Locator("[id='quickSearchTextId-inputEl']");

    public ILocator UserName => _page.Locator("input[id=\"username\"][name=\"pf.username\"]");


    public ILocator ViewPolicy => _page.Locator("[id=\"returnToActiveSessionA\"]");

}
