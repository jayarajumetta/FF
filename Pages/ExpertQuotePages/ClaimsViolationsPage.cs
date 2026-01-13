using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using Playwright_POC.Locators;
using Playwright_POC.Helpers;
using NUnit.Framework;

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
            var claimsText = await _page.Locator(Locators.ClaimsAndViolationsConstLocators.NoClaimsBanner).InnerTextAsync();
            Assert.That(claimsText, Does.Contain("No claims were found on reports"));

            var violationsText = await _page.Locator(Locators.ClaimsAndViolationsConstLocators.NoViolationsBanner).InnerTextAsync();
            Assert.That(violationsText, Does.Contain("No violations were found on reports"));

            await _page.ClickAsync(Locators.GlobalLocators.NextButton);
        }

        public async Task AddClaimsAsync()
        {
                       await _page.ClickAsync(Locators.ClaimsAndViolationsConstLocators.AddClaimsButton);
            // Additional steps to add claims can be implemented here
        }

        public async Task AddViolationsAsync()
        {
            await _page.ClickAsync(Locators.ClaimsAndViolationsConstLocators.AddViolationsButton);
            // Additional steps to add violations can be implemented here
        }
    }
}
