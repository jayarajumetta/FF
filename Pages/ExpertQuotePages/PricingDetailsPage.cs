
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
            return await PricingDetailsConstLocators.AccountOwner(_page).InnerTextAsync();
        }

        public async Task<string> GetAccountAddressAsync()
        {
            return await PricingDetailsConstLocators.AccountAddress(_page).InnerTextAsync();
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
           PricingDetailsConstLocators.ProposalButton(_page).ClickAsync();
        }

        public void SelectCoverageOptionOverviewButton()
        {
            PricingDetailsConstLocators.CoverageOptionOverviewButton(_page).ClickAsync();
        }

      
        public async Task ClickNextAsync()
        {
            await GlobalLocators.NextButton(_page).ClickAsync();
        }

    }
}
