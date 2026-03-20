using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Helpers;
using Playwright_POC.Pages;
using System;

namespace Playwright_POC.Pages.ExpertQuotePages
{
    /// <summary>
    /// Side navigation menu for ExpertQuote application
    /// </summary>
    public class SideMenuNavigation : BasePage
    {
        public SideMenuNavigation(IPage page) : base(page) { }

        #region Locators
        private ILocator ClientNav => _page.GetByTestId("client-info-nav");
        private ILocator AccountDetailsNav => _page.GetByTestId("accountInfoPage-nav");
        private ILocator ProposalStartNav => _page.GetByTestId("proposalStart-nav");
        private ILocator SfpNav => _page.GetByTestId("cl-sfp-nav");
        private ILocator PolicyDetailsNav => _page.GetByTestId("PolicyDetails-nav");
        private ILocator PreQualificationNav => _page.GetByTestId("PreQualification-nav");
        private ILocator PrimaryInsuredDetailsNav => _page.GetByTestId("BusinessDetails-nav");
        private ILocator ClaimsPriorInsuranceNav => _page.GetByTestId("ClaimsPriorInsurance-nav");
        private ILocator AddClaimNav => _page.GetByTestId("AddClaim-nav");
        private ILocator ClientDetailsNav => _page.GetByTestId("ClientDetails-nav");
        private ILocator NarrativeNav => _page.GetByTestId("Narrative-nav");
        private ILocator PolicyCoveragesNav => _page.GetByTestId("PolicyCoverages-nav");
        private ILocator LocationsBuildingsNav => _page.GetByTestId("AddEditLocation-nav");
        private ILocator OptionalCoveragesNav => _page.GetByTestId("OptionalCoverages-nav");
        private ILocator FarmPersonalPropertyNav => _page.GetByTestId("FarmPersonalProperty-nav");
        private ILocator ScheduledPersonalPropertyNav => _page.GetByTestId("ScheduledPersonalProperty-nav");
        private ILocator LiabilityNav => _page.GetByTestId("Liability-nav");
        private ILocator MortgageeLossPayeeNav => _page.GetByTestId("AdditionalInterests-nav");
        private ILocator InsuranceScoreNav => _page.GetByTestId("InsuranceDesignee-nav");
        private ILocator PricingNav => _page.GetByTestId("Pricing-nav");
        private ILocator BillingNav => _page.GetByTestId("Billing-nav");
        private ILocator SubmissionNav => _page.GetByTestId("Submission-nav");
        #endregion

        #region Navigation Methods
        public async Task GoToClientAsync() { await ClientNav.ClickAsync(); await WaitForSpinnerAsync(); }
        public async Task GoToAccountDetailsAsync() { await AccountDetailsNav.ClickAsync(); await WaitForSpinnerAsync(); }
        public async Task GoToProposalStartAsync() { await ProposalStartNav.ClickAsync(); await WaitForSpinnerAsync(); }
        public async Task GoToSfpAsync() { await SfpNav.ClickAsync(); await WaitForSpinnerAsync(); }
        public async Task GoToPolicyDetailsAsync() { await PolicyDetailsNav.ClickAsync(); await WaitForSpinnerAsync(); }
        public async Task GoToPreQualificationAsync() { await PreQualificationNav.ClickAsync(); await WaitForSpinnerAsync(); }
        public async Task GoToPrimaryInsuredDetailsAsync() { await PrimaryInsuredDetailsNav.ClickAsync(); await WaitForSpinnerAsync(); }
        public async Task GoToClaimsPriorInsuranceAsync() { await ClaimsPriorInsuranceNav.ClickAsync(); await WaitForSpinnerAsync(); }
        public async Task GoToAddClaimAsync() { await AddClaimNav.ClickAsync(); await WaitForSpinnerAsync(); }
        public async Task GoToClientDetailsAsync() { await ClientDetailsNav.ClickAsync(); await WaitForSpinnerAsync(); }
        public async Task GoToNarrativeAsync() { await NarrativeNav.ClickAsync(); await WaitForSpinnerAsync(); }
        public async Task GoToPolicyCoveragesAsync() { await PolicyCoveragesNav.ClickAsync(); await WaitForSpinnerAsync(); }
        public async Task GoToLocationsBuildingsAsync() { await LocationsBuildingsNav.ClickAsync(); await WaitForSpinnerAsync(); }
        public async Task GoToOptionalCoveragesAsync() { await OptionalCoveragesNav.ClickAsync(); await WaitForSpinnerAsync(); }
        public async Task GoToFarmPersonalPropertyAsync() { await FarmPersonalPropertyNav.ClickAsync(); await WaitForSpinnerAsync(); }
        public async Task GoToScheduledPersonalPropertyAsync() { await ScheduledPersonalPropertyNav.ClickAsync(); await WaitForSpinnerAsync(); }
        public async Task GoToLiabilityAsync() { await LiabilityNav.ClickAsync(); await WaitForSpinnerAsync(); }
        public async Task GoToMortgageeLossPayeeAsync() { await MortgageeLossPayeeNav.ClickAsync(); await WaitForSpinnerAsync(); }
        public async Task GoToInsuranceScoreAsync() { await InsuranceScoreNav.ClickAsync(); await WaitForSpinnerAsync(); }
        public async Task GoToPricingAsync() { await PricingNav.ClickAsync(); await WaitForSpinnerAsync(); }
        public async Task GoToBillingAsync() { await BillingNav.ClickAsync(); await WaitForSpinnerAsync(); }
        public async Task GoToSubmissionAsync() { await SubmissionNav.ClickAsync(); await WaitForSpinnerAsync(); }

        /// <summary>
        /// Navigates to any left-menu item by friendly name (case-insensitive).
        /// Delegates to the existing typed GoToXxxAsync methods — test IDs stay in one place.
        /// </summary>
        public Task GoToByNameAsync(string name) =>
            name.Trim().ToLowerInvariant() switch
            {
                "client" or "client info"                                    => GoToClientAsync(),
                "account" or "account details"                               => GoToAccountDetailsAsync(),
                "proposal" or "proposal start"                               => GoToProposalStartAsync(),
                "sfp" or "special farm package"                              => GoToSfpAsync(),
                "policy details" or "policy"                                 => GoToPolicyDetailsAsync(),
                "pre-qualification" or "prequalification"                    => GoToPreQualificationAsync(),
                "primary insured" or "business details"                      => GoToPrimaryInsuredDetailsAsync(),
                "claims" or "claims & prior insurance"
                    or "claims and prior insurance"                           => GoToClaimsPriorInsuranceAsync(),
                "add claim"                                                   => GoToAddClaimAsync(),
                "client details"                                             => GoToClientDetailsAsync(),
                "narrative"                                                   => GoToNarrativeAsync(),
                "policy coverages" or "coverages"                            => GoToPolicyCoveragesAsync(),
                "locations" or "locations & buildings"
                    or "locations and buildings"                              => GoToLocationsBuildingsAsync(),
                "optional coverages" or "optional"                           => GoToOptionalCoveragesAsync(),
                "farm personal property" or "farm property"                  => GoToFarmPersonalPropertyAsync(),
                "scheduled personal property" or "scheduled"                 => GoToScheduledPersonalPropertyAsync(),
                "liability"                                                   => GoToLiabilityAsync(),
                "mortgagee" or "additional interests"
                    or "mortgagee & loss payee"                               => GoToMortgageeLossPayeeAsync(),
                "insurance score" or "insurance designee"                    => GoToInsuranceScoreAsync(),
                "pricing"                                                     => GoToPricingAsync(),
                "billing"                                                     => GoToBillingAsync(),
                "submission"                                                  => GoToSubmissionAsync(),
                _ => throw new ArgumentException(
                    $"Unknown nav menu item: '{name}'. Check SideMenuNavigation.GoToByNameAsync for valid names.")
            };
        #endregion
    }
}
