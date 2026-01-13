
// Pages/PricingDetailsPage.cs
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright_POC.Helpers;
using Playwright_POC.Locators;
using System.Threading.Tasks;

namespace Playwright_POC.Pages
{
    public class PricingDetailsPage
    {
        private readonly IPage _page;

        public PricingDetailsPage(IPage page)
        {
            _page = page;
        }


        public async Task<string> GetAccountOwnerAsync()
        {
            await _page.WaitForTimeoutAsync(5000);
            return await _page.Locator(PricingDetailsConstLocators.AccountOwner).InnerTextAsync();
        }

        public async Task<string> GetAccountAddressAsync()
        {
            return await _page.Locator(PricingDetailsConstLocators.AccountAddress).InnerTextAsync();
        }

        public void AssertAccountOwner(string actual, string expected)
        {
            Assert.That(actual, Is.EqualTo(expected));
        }

        public void AssertAccountAddress(string actual, string expected)
        {
            var expectedLength = expected.Length;
            var actualSubstring = actual.Substring(0, expectedLength);
            Assert.That(actualSubstring, Is.EqualTo(expected).IgnoreCase);
        }

        public void SelectAdditionalRatingDetails(string yesOrNo)
        {
            _page.ClickAsync(ExpertQuoteLocatorFactory.PricingDetailsPageLocators.AdditionalRatingDetailsButton(yesOrNo));
        }

        public void SelectProposalButton()
        {
           _page.ClickAsync(PricingDetailsConstLocators.ProposalButton);
        }

        public void SelectCoverageOptionOverviewButton()
        {
            _page.ClickAsync(PricingDetailsConstLocators.CoverageOptionOverviewButton);
        }

      
        public async Task ClickNextAsync()
        {
            await _page.ClickAsync(GlobalLocators.NextButton);
        }

    }
}
