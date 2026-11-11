using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class CommercialDuckCreekNavigationLocators
{
    private readonly IPage _page;
    public CommercialDuckCreekNavigationLocators(IPage page) => _page = page;

    public ILocator ClientLink => _page.Locator("a[onclick*='MainInterview_Account']").Filter(new LocatorFilterOptions { Visible = true }).First;

    public ILocator HomeLink => _page.Locator("span.mainActionsCaption", new() { HasTextString = "Home" }).First;

    public ILocator ClientPageTitle => _page.Locator("#pageTitle").Filter(new LocatorFilterOptions { HasText = "Client" });
}
