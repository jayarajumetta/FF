using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class ProposalLocators
{
    private readonly IPage _page;
    public ProposalLocators(IPage page) => _page = page;


    // Source modules: Product Selection | confidence=High score=125
    // Updated: Using unique placeholder to avoid conflict with other combobox elements
    public ILocator EffectiveDate => _page.GetByPlaceholder("m/d/yyyy");

    // Source modules: Common Navigation Links | confidence=Medium score=113
    // Updated: Using text-based locator for more reliable matching with custom link structure
    public ILocator NewQuote => _page.Locator("a").Filter(new() { HasText = "New Quote" }).First;

    // Source modules: Product Selection | confidence=High score=95
    // Updated: Using unique placeholder to avoid conflict with other combobox elements
    public ILocator Product => _page.Locator("input[fieldref='data.VersionIDPages']");

    // Source modules: Product Selection | confidence=High score=125
    // Note: Start button not visible in current page state - may appear after product selection
    public ILocator Start => _page.GetByRole(AriaRole.Link, new() { Name = "Start", Exact = true });


}
