using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using Playwright_POC.Locators;
using Playwright_POC.Helpers;
using static Microsoft.Playwright.Assertions;

namespace Playwright_POC.Pages.ExpertQuotePages
{
    internal class ClaimsViolationsPage
    {
        private readonly IPage _page;

        public ClaimsViolationsPage(IPage page)
        {
            _page = page;
        }
        public async Task VerifyNoClaimsOrViolationsAndContinueAsync()
        {
            await Expect(ClaimsAndViolationsConstLocators.NoClaimsBanner(_page))
                .ToContainTextAsync("No claims were found on reports");

            await Expect(ClaimsAndViolationsConstLocators.NoViolationsBanner(_page))
                .ToContainTextAsync("No violations were found on reports");

            await Locators.GlobalLocators.NextButton(_page).ClickAsync();
        }

        public async Task AddClaimsAsync()
        {
                       await Locators.ClaimsAndViolationsConstLocators.AddClaimsButton(_page).ClickAsync();
            // Additional steps to add claims can be implemented here
        }

        public async Task AddViolationsAsync()
        {
            await Locators.ClaimsAndViolationsConstLocators.AddViolationsButton(_page).ClickAsync();
            // Additional steps to add violations can be implemented here
        }
    }
}
