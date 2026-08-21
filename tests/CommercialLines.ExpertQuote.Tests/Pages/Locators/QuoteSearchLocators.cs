using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class QuoteSearchLocators
{
    private readonly IPage _page;
    public QuoteSearchLocators(IPage page) => _page = page;

    // Source modules: EQ|Common|Client Info | confidence=Medium score=113
    public ILocator ClientInfoSearch => _page.GetByRole(AriaRole.Button, new() { Name = "Search", Exact = true });

    // Source modules: EQ|Common|Quote Identifying | confidence=Medium score=108
    // Close/exit quote - app home/logo link typically in top-left of nav bar
    public ILocator CloseQuote => _page.Locator("a[href='/'], a[href='#/'], a.navbar-brand, a.logo, [data-testid='home'], [data-testid='logo'], mat-toolbar a:first-child").First;

    // Source modules: EQ|Common|Review Required Pop-up | confidence=High score=100
    public ILocator KeepGoing => _page.GetByTestId("btnConfirmYes");

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ|Common|Quote Identifying | confidence=Review score=97
    // Looking for quote and name in the toolbar/header - typically shows "LastName Quote#"
    public ILocator NameAndQuote => _page.Locator("mat-toolbar, [role='banner'], header").First;

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator PreQualification => _page.GetByText("PreQualification", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator QuoteSearch => _page.GetByText("Quote Search", new() { Exact = true });

}
