using Microsoft.Playwright;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;

namespace PnCTestAutomation.Pages.ExpertQuotePages
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
        private ILocator GetExposuresInsuredButton(string yesOrNo) =>
            _page.GetByTestId("fields.data.policy.policyInput$exposuresInsuredAN90Days.value-chip-item-wrapper")
                 .Filter(new() { HasText = yesOrNo }).First;

        // Fully Cancelled (Yes/No)
        private ILocator GetFullyCancelledButton(string yesOrNo) =>
            _page.GetByTestId("fields.data.policy.policyInput$fullyCancelled.value-chip-item-wrapper")
                 .Filter(new() { HasText = yesOrNo }).First;

        // Transfer Unearned Premium (Yes/No)
        private ILocator GetTransferUnearnedPremiumButton(string yesOrNo) =>
            _page.GetByTestId("fields.data.policy.policyInput$transferUnearnedPremium.value-chip-item-wrapper")
                 .Filter(new() { HasText = yesOrNo }).First;

        // Years of Continuous Coverage
        private ILocator GetYearsContinuousCoverageButton(string chipLabel) =>
            _page.GetByTestId("fields.data.policy.policyUnderwriting.policyUnderwritingInput$yearsMaintainedContinuousInsuranceCoverage.value-chip-item-wrapper")
                 .Filter(new() { HasText = chipLabel }).First;
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
            await GetExposuresInsuredButton(insured ? "Yes" : "No").ClickAsync();
            await WaitForSpinnerAsync();
        }

        public async Task EnterYearsInBusinessAsync(string years)
        {
            await YearsInBusinessInput.FillAsync(years);
        }

        public async Task SelectYearsOfContinuousCoverageAsync(string years)
        {
            var normalized = (years ?? "").Trim().ToLower();

            // Map input values to chip label text in DOM
            string chipLabel;
            if (normalized.Contains("no prior") || normalized == "0")
                chipLabel = "No Prior Carrier";
            else if (normalized.StartsWith("1"))
                chipLabel = "1 year";
            else if (normalized.StartsWith("2"))
                chipLabel = "2 years";
            else
                chipLabel = "3+ years";

            await GetYearsContinuousCoverageButton(chipLabel).ClickAsync();
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
            await GetFullyCancelledButton(yes ? "Yes" : "No").ClickAsync();
            await WaitForSpinnerAsync();
        }

        public async Task SetTransferUnearnedPremiumAsync(bool yes)
        {
            await GetTransferUnearnedPremiumButton(yes ? "Yes" : "No").ClickAsync();
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
