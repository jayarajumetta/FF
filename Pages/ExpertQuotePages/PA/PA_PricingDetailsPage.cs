// Pages/ExpertQuotePages/PA_PricingDetailsPage.cs
using Microsoft.Playwright;
using Playwright_POC.Helpers;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;

namespace Playwright_POC.Pages
{
    public class PA_PricingDetailsPage : BasePage
    {
        public PA_PricingDetailsPage(IPage page) : base(page) { }

        #region Locators
        private ILocator AccountOwner => _page.Locator("div.readonly-field:has(span.readonly-label:has-text('Account Owner')) >> span.readonly-value");
        private ILocator AccountAddress => _page.Locator("div.readonly-field:has(span.readonly-label:has-text('Account Address')) >> span.readonly-value");
        private ILocator ProposalButton => _page.GetByTestId("fields.data.create_Proposal");
        private ILocator CoverageOptionOverviewButton => _page.GetByTestId("fields.data.create_CoverageOptionOverview");

        // Dynamic locators
        private ILocator GetAdditionalRatingDetailsButton(string yesOrNo) =>
            _page.Locator($"button[data-testid*='AdditionalRatinginformation'] div:has-text('{yesOrNo}')");
        #endregion

        public async Task<string> GetAccountOwnerAsync()
        {
            await WaitForSpinnerAsync();
            await Expect(AccountOwner).ToBeVisibleAsync();
            return await AccountOwner.InnerTextAsync();
        }

        public async Task<string> GetAccountAddressAsync()
        {
            return await AccountAddress.InnerTextAsync();
        }

        public async Task AssertAccountOwnerAsync(string expected)
        {
            await Expect(AccountOwner).ToHaveTextAsync(expected);
        }

        public async Task AssertAccountAddressAsync(string expected)
        {
            await Expect(AccountAddress).ToContainTextAsync(expected);
        }

        public void SelectAdditionalRatingDetails(string yesOrNo)
        {
            GetAdditionalRatingDetailsButton(yesOrNo).ClickAsync();
        }

        public void SelectProposalButton()
        {
            ProposalButton.ClickAsync();
        }

        public void SelectCoverageOptionOverviewButton()
        {
            CoverageOptionOverviewButton.ClickAsync();
        }
    }
}
