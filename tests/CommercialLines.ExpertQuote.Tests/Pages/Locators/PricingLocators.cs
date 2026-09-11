using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class PricingLocators
{
    private readonly IPage _page;
    public PricingLocators(IPage page) => _page = page;

    public ILocator DCTransactionTableRowCellExplicitNameNewPremium => _page.GetByText("(ExplicitName=New Premium)", new() { Exact = true });

    public ILocator DCTransactionTableRowCellExplicitNameStatus => _page.GetByText("(ExplicitName=Status)", new() { Exact = true });

    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    public ILocator TotalPremium => _page.Locator("[id=\"LineCoverages.EQPricingSummaryFullPremiumTotalPremiumSumm-0-layout\"]");

}
