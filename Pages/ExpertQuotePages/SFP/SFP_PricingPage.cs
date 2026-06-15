using Microsoft.Playwright;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PnCTestAutomation.Pages
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

        /// <summary>
        /// Attempts to read the annual premium amount from the pricing page.
        /// Tries known EQ test ID patterns first, then falls back to body text scan.
        /// Returns null if the amount cannot be located — refine locators after first run.
        /// </summary>
        public async Task<decimal?> GetAnnualPremiumAsync()
        {
            try
            {
                // Target the Total Premium value cell by its known EQ id pattern.
                // id="LineCoverages.EQPricingSummaryFullPremiumTotalPremiumSumm-0-layout"
                var el = _page.Locator("[id*='FullPremiumTotalPremiumSumm']").First;
                if (await el.CountAsync() > 0)
                {
                    var raw = await el.InnerTextAsync(new() { Timeout = 5000 });
                    var m = Regex.Match(raw, @"\$([\d,]+\.?\d{0,2})");
                    if (m.Success && decimal.TryParse(m.Groups[1].Value.Replace(",", ""),
                            NumberStyles.Any, CultureInfo.InvariantCulture, out var v))
                        return v;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Premium] Error reading premium amount: {ex.Message}");
            }
            return null;
        }
    }
}
