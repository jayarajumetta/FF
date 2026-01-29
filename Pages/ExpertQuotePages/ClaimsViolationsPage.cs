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
            var claimsText = await ClaimsAndViolationsConstLocators.NoClaimsBanner(_page).InnerTextAsync();
            Assert.That(claimsText, Does.Contain("No claims were found on reports"));

            var violationsText = await ClaimsAndViolationsConstLocators.NoViolationsBanner(_page).InnerTextAsync();
            Assert.That(violationsText, Does.Contain("No violations were found on reports"));

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
