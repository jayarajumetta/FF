// Pages/PricingDetailsPage.cs
using Microsoft.Playwright;
using Playwright_POC.Helpers;
using Playwright_POC.Locators;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;

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
            // Wait for pricing details to load
            await LoadingHelpers.WaitForAngularSpinnerAsync(_page);
            await Assertions.Expect(PricingDetailsConstLocators.AccountOwner(_page)).ToBeVisibleAsync();
            return await PricingDetailsConstLocators.AccountOwner(_page).InnerTextAsync();
        }

        public async Task<string> GetAccountAddressAsync()
        {
            return await PricingDetailsConstLocators.AccountAddress(_page).InnerTextAsync();
        }

        public async Task AssertAccountOwnerAsync(string expected)
        {
            await Expect(PricingDetailsConstLocators.AccountOwner(_page)).ToHaveTextAsync(expected);
        }

        public async Task AssertAccountAddressAsync(string expected)
        {
            await Expect(PricingDetailsConstLocators.AccountAddress(_page))
                .ToContainTextAsync(expected);
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
