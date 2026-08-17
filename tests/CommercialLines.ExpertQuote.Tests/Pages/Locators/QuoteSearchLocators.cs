using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class QuoteSearchLocators
{
    private readonly IPage _page;
    public QuoteSearchLocators(IPage page) => _page = page;

    // Source modules: EQ|Common|Client Info | confidence=Medium score=113
    public ILocator ClientInfoSearch => _page.GetByRole(AriaRole.Button, new() { Name = "Search", Exact = true });

    // Source modules: EQ|Common|Quote Identifying | confidence=Medium score=108
    public ILocator CloseQuote => _page.GetByLabel("Close Quote", new() { Exact = true });

    // Source modules: EQ|Common|Review Required Pop-up | confidence=High score=100
    public ILocator KeepGoing => _page.GetByTestId("btnConfirmYes");

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ|Common|Quote Identifying | confidence=Review score=97
    public ILocator NameAndQuote => _page.GetByLabel("Name and Quote", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator PreQualification => _page.GetByText("PreQualification", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator QuoteSearch => _page.GetByText("Quote Search", new() { Exact = true });

}