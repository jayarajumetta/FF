using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class PricingLocators
{
    private readonly IPage _page;
    public PricingLocators(IPage page) => _page = page;

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator DCTransactionTableRowCellExplicitNameNewPremium => _page.GetByText("(ExplicitName=New Premium)", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator DCTransactionTableRowCellExplicitNameStatus => _page.GetByText("(ExplicitName=Status)", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    // Source modules: EQ|SFP|Pricing | confidence=High score=97
    // v56 raw Tosca primary: EQ|SFP|Pricing | Total Premium | Id
    public ILocator TotalPremium => _page.Locator("[id=\"LineCoverages.EQPricingSummaryFullPremiumTotalPremiumSumm-0-layout\"]");

}
