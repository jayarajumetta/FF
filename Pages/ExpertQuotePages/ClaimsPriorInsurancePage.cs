using Microsoft.Playwright;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;

namespace Playwright_POC.Pages.ExpertQuotePages
{
    internal class ClaimsPriorInsurancePage : BasePage
    {
        public ClaimsPriorInsurancePage(IPage page) : base(page) { }

        #region Locators
        private ILocator NoClaimsBanner => _page.GetByText("No claims were found on reports");
        private ILocator NoViolationsBanner => _page.GetByText("No violations were found on reports");
        private ILocator AddClaimButton => _page.GetByTestId("fields.data.policy.policyUnderwriting.underwritingLossExperience.addClaim");
        private ILocator AddViolationsButton => _page.GetByTestId("add_Violation");
        private ILocator YearsInBusinessInput => _page.GetByTestId("fields.data.policy.policyUnderwriting.accountInput$yearsInBusiness.value");
        private ILocator EditClaimButton => _page.GetByTestId("fields.data.policy.policyUnderwriting.underwritingLossExperience.rows[0].addLoss.rows[0].editClaim");
        
        // Prior Insurance fields
        private ILocator PriorPolicyNumberInput => _page.GetByTestId("fields.data.policy.policyInput$priorPolicyNumberAN.value");
        private ILocator ReasonForNewCoverageDropdown => _page.GetByTestId("fields.data.policy.policyInput$reasonForNewCoverage.value");
        private ILocator PriorInsuranceCarrierInput => _page.GetByTestId("fields.data.policy.policyUnderwriting.policyUnderwritingInput$priorInsuranceLatestCarrier.value");
        
        // Exposures Insured (Yes/No)
        private ILocator ExposuresInsuredYesButton => _page.GetByTestId("fields.data.policy.policyInput$exposuresInsuredAN90Days.value-0");
        private ILocator ExposuresInsuredNoButton => _page.GetByTestId("fields.data.policy.policyInput$exposuresInsuredAN90Days.value-1");
        
        // Fully Cancelled (Yes/No)
        private ILocator FullyCancelledYesButton => _page.GetByTestId("fields.data.policy.policyInput$fullyCancelled.value-0");
        private ILocator FullyCancelledNoButton => _page.GetByTestId("fields.data.policy.policyInput$fullyCancelled.value-1");
        
        // Transfer Unearned Premium (Yes/No)
        private ILocator TransferUnearnedPremiumYesButton => _page.GetByTestId("fields.data.policy.policyInput$transferUnearnedPremium.value-0");
        private ILocator TransferUnearnedPremiumNoButton => _page.GetByTestId("fields.data.policy.policyInput$transferUnearnedPremium.value-1");
        
        // Years of Continuous Coverage
        private ILocator YearsCoverageNoPriorButton => _page.GetByTestId("fields.data.policy.policyUnderwriting.policyUnderwritingInput$yearsMaintainedContinuousInsuranceCoverage.value-0");
        private ILocator YearsCoverage1YearButton => _page.GetByTestId("fields.data.policy.policyUnderwriting.policyUnderwritingInput$yearsMaintainedContinuousInsuranceCoverage.value-1");
        private ILocator YearsCoverage2YearsButton => _page.GetByTestId("fields.data.policy.policyUnderwriting.policyUnderwritingInput$yearsMaintainedContinuousInsuranceCoverage.value-2");
        private ILocator YearsCoverage3PlusButton => _page.GetByTestId("fields.data.policy.policyUnderwriting.policyUnderwritingInput$yearsMaintainedContinuousInsuranceCoverage.value-3");
        #endregion

        #region Actions
        public async Task VerifyNoClaimsOrViolationsAndContinueAsync()
        {
            await Expect(NoClaimsBanner).ToContainTextAsync("No claims were found on reports");
            await Expect(NoViolationsBanner).ToContainTextAsync("No violations were found on reports");
            await ClickNextAsync();
        }

        public async Task AddClaimsAsync()
        {
            await AddClaimButton.ClickAsync();
        }

        public async Task AddViolationsAsync()
        {
            await AddViolationsButton.ClickAsync();
        }

        public async Task SetExposuresInsuredAN90DaysAsync(bool insured)
        {
            var button = insured ? ExposuresInsuredYesButton : ExposuresInsuredNoButton;
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

            var button = y switch
            {
                <= 0 => YearsCoverageNoPriorButton,
                1 => YearsCoverage1YearButton,
                2 => YearsCoverage2YearsButton,
                _ => YearsCoverage3PlusButton
            };

            await button.ClickAsync();
            await WaitForSpinnerAsync();
        }

        public async Task EnterPriorPolicyNumberAsync(string policyNumber)
        {
            await PriorPolicyNumberInput.FillAsync(policyNumber);
        }

        public async Task SelectReasonForNewCoverageAsync(string reason)
        {
            await ReasonForNewCoverageDropdown.ClickAsync();
            await _page.GetByRole(AriaRole.Option, new() { Name = reason }).ClickAsync();
            await WaitForSpinnerAsync();
        }

        public async Task EnterPriorInsuranceCarrierAsync(string carrier)
        {
            await PriorInsuranceCarrierInput.FillAsync(carrier);
        }

        public async Task SetFullyCancelledAsync(bool yes)
        {
            var button = yes ? FullyCancelledYesButton : FullyCancelledNoButton;
            await button.ClickAsync();
            await WaitForSpinnerAsync();
        }

        public async Task SetTransferUnearnedPremiumAsync(bool yes)
        {
            var button = yes ? TransferUnearnedPremiumYesButton : TransferUnearnedPremiumNoButton;
            await button.ClickAsync();
            await WaitForSpinnerAsync();
        }

        public async Task ClickEditClaimAsync()
        {
            await EditClaimButton.ClickAsync();
            await WaitForSpinnerAsync();
        }

        public async Task ClickAddClaimAsync()
        {
            await AddClaimButton.ClickAsync();
            await WaitForSpinnerAsync();
        }
        #endregion
    }
}
