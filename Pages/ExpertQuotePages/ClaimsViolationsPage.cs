using Microsoft.Playwright;
using Playwright_POC.Helpers;
using Playwright_POC.Locators;
using System;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;
using static Playwright_POC.Helpers.Helpers;

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

            await Helpers.Helpers.ClickNextAsync(_page);
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

        public async Task SetExposuresInsuredAN90DaysAsync(bool insured)
        {
            await UiToggleHelpers.ClickYesNoAsync(
                _page,
                "fields.data.policy.policyInput$exposuresInsuredAN90Days.value",
                insured
            );
        }

        public async Task EnterYearsInBusinessAsync(string years)
        {
            await _page.GetByTestId("fields.data.policy.policyUnderwriting.accountInput$yearsInBusiness.value").FillAsync(years);
        }

        public async Task SelectYearsOfContinuousCoverageAsync(string years)
        {
            // Parse the feature-file value safely
            int y = 0;
            int.TryParse((years ?? "").Trim(), out y);

            // Convert numeric years to the chip label used in the UI
            // UI options: NO PRIOR CARRIER | 1 YEAR | 2 YEARS | 3+ YEARS
            string optionText = y switch
            {
                <= 0 => "NO PRIOR CARRIER",
                1 => "1 YEAR",
                2 => "2 YEARS",
                _ => "3+ YEARS"
            };

            // The chip group test id from your DOM (update if your page uses the accountInput version)
            const string testId = "fields.data.policy.policyUnderwriting.policyUnderwritingInput$yearsMaintainedContinuousInsuranceCoverage.value";

            // Click the specific chip by text INSIDE the group
            await _page.Locator($"button[data-testid^='{testId}']", new() { HasTextString = optionText })
                      .First
                      .ClickAsync();

            await Helpers.Helpers.WaitForSpinnerToClearAsync(_page);
        }
    }
}
