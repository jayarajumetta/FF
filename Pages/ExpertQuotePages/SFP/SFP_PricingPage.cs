using Microsoft.Playwright;

namespace Playwright_POC.Pages
{
    public class SFP_PricingPage : BasePage
    {
        public SFP_PricingPage(IPage page) : base(page) { }

        // Form Fields
        public ILocator ViewFullDetailsCheckbox => _page.GetByRole(AriaRole.Switch, new() { Name = "View Full Details" });

        // Buttons
        public ILocator PolicyCoveragesButton => _page.GetByTestId("fields.data_PremiumBreakdown.pricingPageHeadless$isPolicyWideCollapsed.value");
        public ILocator LiabilityDivisionVButton => _page.GetByTestId("fields.data_PremiumBreakdown.policy_3.line.pricingPageHeadless$isD5Collapsed.value");

        // Checkboxes & Toggles
        public ILocator ViewFullDetailsCheckbox2 => _page.GetByRole(AriaRole.Switch, new() { Name = "View Full Details" });
        public ILocator ViewFullDetailsToggle => _page.GetByTestId("fields.data_PremiumSummary.account_PremiumSummary.policyInput$viewPremiumBreakdown.value");

        // Other Elements
        public ILocator QuoteLink => _page.GetByTestId("fields.policyDocs.proposalPrint_1_2_4");
        public ILocator ViewFullDetails => _page.GetByLabel("View Full Details");
    }
}
