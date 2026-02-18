using Microsoft.Playwright;
using Playwright_POC.Helpers;
using System;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;

namespace Playwright_POC.Pages.ExpertQuotePages
{
    internal class ClaimsViolationsPage : BasePage
    {
        public ClaimsViolationsPage(IPage page) : base(page) { }

        #region Locators
        private ILocator NoClaimsBanner => _page.GetByText("No claims were found on reports");
        private ILocator NoViolationsBanner => _page.GetByText("No violations were found on reports");
        private ILocator AddClaimsButton => _page.GetByTestId("add_Claim");
        private ILocator AddViolationsButton => _page.GetByTestId("add_Violation");
        private ILocator YearsInBusinessInput => _page.GetByTestId("fields.data.policy.policyUnderwriting.accountInput$yearsInBusiness.value");

        // Dynamic locators
        private ILocator GetExposuresInsuredButton(bool insured) =>
            _page.Locator($"button[data-testid^='fields.data.policy.policyInput$exposuresInsuredAN90Days.value-{(insured ? "0" : "1")}']");

        private ILocator GetYearsOfContinuousCoverageButton(string optionText) =>
            _page.Locator("button[data-testid^='fields.data.policy.policyUnderwriting.policyUnderwritingInput$yearsMaintainedContinuousInsuranceCoverage.value']")
                .Filter(new() { HasTextString = optionText });
        #endregion

        public async Task VerifyNoClaimsOrViolationsAndContinueAsync()
        {
            await Expect(NoClaimsBanner).ToContainTextAsync("No claims were found on reports");
            await Expect(NoViolationsBanner).ToContainTextAsync("No violations were found on reports");
            await ClickNextAsync();
        }

        public async Task AddClaimsAsync()
        {
            await AddClaimsButton.ClickAsync();
        }

        public async Task AddViolationsAsync()
        {
            await AddViolationsButton.ClickAsync();
        }

        public async Task SetExposuresInsuredAN90DaysAsync(bool insured)
        {
            var value = insured ? "Yes" : "No";
            var button = _page.Locator(
                $"button[data-testid^='fields.data.policy.policyInput$exposuresInsuredAN90Days.value'] >> text={value}"
            );
            await button.ClickAsync();
            await WaitForSpinnerAsync();
        }

        public async Task EnterYearsInBusinessAsync(string years)
        {
            await YearsInBusinessInput.FillAsync(years);
        }

        public async Task SelectYearsOfContinuousCoverageAsync(string years)
        {
            int y = 0;
            int.TryParse((years ?? "").Trim(), out y);

            string optionText = y switch
            {
                <= 0 => "NO PRIOR CARRIER",
                1 => "1 YEAR",
                2 => "2 YEARS",
                _ => "3+ YEARS"
            };

            await GetYearsOfContinuousCoverageButton(optionText).First.ClickAsync();
            await WaitForSpinnerAsync();
        }
    }
}
