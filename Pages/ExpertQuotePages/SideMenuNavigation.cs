using Microsoft.Playwright;
using System.Threading.Tasks;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Pages;
using System;

namespace PnCTestAutomation.Pages.ExpertQuotePages
{
    /// <summary>
    /// Side navigation menu for ExpertQuote application
    /// </summary>
    public class SideMenuNavigation : BasePage
    {
        public SideMenuNavigation(IPage page) : base(page) { }

        #region Locators
        // Nav items are ANi-built components. The app is gradually migrating them from
        // data-testid attributes to id attributes (internal library migration - INC0183313).
        // NavItem() matches whichever attribute is present so locators survive the transition.
        private ILocator NavItem(string name) => _page.Locator($"[data-testid='{name}'], #{name}");

        private ILocator ClientNav => NavItem("client-info-nav");
        private ILocator AccountDetailsNav => NavItem("accountInfoPage-nav");
        private ILocator ProposalStartNav => NavItem("proposalStart-nav");
        private ILocator SfpNav => NavItem("cl-sfp-nav");
        private ILocator PolicyDetailsNav => NavItem("PolicyDetails-nav");
        private ILocator PreQualificationNav => NavItem("PreQualification-nav");
        private ILocator PrimaryInsuredDetailsNav => NavItem("BusinessDetails-nav");
        private ILocator ClaimsPriorInsuranceNav => NavItem("ClaimsPriorInsurance-nav");
        private ILocator AddClaimNav => NavItem("AddClaim-nav");
        private ILocator ClientDetailsNav => NavItem("ClientDetails-nav");
        private ILocator NarrativeNav => NavItem("Narrative-nav");
        private ILocator PolicyCoveragesNav => NavItem("PolicyCoverages-nav");
        private ILocator LocationsBuildingsNav => NavItem("AddEditLocation-nav");
        private ILocator OptionalCoveragesNav => NavItem("OptionalCoverages-nav");
        private ILocator FarmPersonalPropertyNav => NavItem("FarmPersonalProperty-nav");
        private ILocator ScheduledPersonalPropertyNav => NavItem("ScheduledPersonalProperty-nav");
        private ILocator LiabilityNav => NavItem("Liability-nav");
        private ILocator MortgageeLossPayeeNav => NavItem("AdditionalInterests-nav");
        private ILocator InsuranceScoreNav => NavItem("InsuranceDesignee-nav");
        private ILocator PricingNav => NavItem("Pricing-nav");
        private ILocator BillingNav => NavItem("Billing-nav");
        private ILocator SubmissionNav => NavItem("Submission-nav");
        #endregion

        #region Navigation Methods

        /// <summary>
        /// Helper method to safely navigate to a menu item, waiting for it to be visible first.
        /// </summary>
        private async Task NavigateToAsync(ILocator navItem, int timeoutMs = 30000)
        {
            // Some pages briefly keep an overlay spinner active while the left nav is already visible.
            // Wait for the overlay to clear before attempting navigation clicks.
            // In Dev this overlay can occasionally linger; don't fail early if it does.
            try
            {
                await _page.Locator(".ngx-spinner-overlay").WaitForAsync(
                    new() { State = WaitForSelectorState.Hidden, Timeout = timeoutMs });
            }
            catch (TimeoutException)
            {
                Console.WriteLine("[SideMenu] Spinner overlay still visible after timeout; proceeding with click fallback.");
            }

            await navItem.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = timeoutMs });

            try
            {
                await navItem.ClickAsync(new() { Timeout = timeoutMs });
            }
            catch (TimeoutException)
            {
                // Fallback for occasional pointer interception races after overlay transitions.
                try
                {
                    await navItem.ClickAsync(new() { Timeout = timeoutMs, Force = true });
                }
                catch (TimeoutException)
                {
                    await navItem.DispatchEventAsync("click");
                }
            }

            await WaitForSpinnerAsync();
        }

        public async Task GoToClientAsync() { await NavigateToAsync(ClientNav); }
        public async Task GoToAccountDetailsAsync() { await NavigateToAsync(AccountDetailsNav); }
        public async Task GoToProposalStartAsync() { await NavigateToAsync(ProposalStartNav); }
        public async Task GoToSfpAsync() { await NavigateToAsync(SfpNav); }
        public async Task GoToPolicyDetailsAsync() { await NavigateToAsync(PolicyDetailsNav); }
        public async Task GoToPreQualificationAsync() { await NavigateToAsync(PreQualificationNav); }
        public async Task GoToPrimaryInsuredDetailsAsync() { await NavigateToAsync(PrimaryInsuredDetailsNav); }
        public async Task GoToClaimsPriorInsuranceAsync() { await NavigateToAsync(ClaimsPriorInsuranceNav); }
        public async Task GoToAddClaimAsync() { await NavigateToAsync(AddClaimNav); }
        public async Task GoToClientDetailsAsync() { await NavigateToAsync(ClientDetailsNav); }
        public async Task GoToNarrativeAsync() { await NavigateToAsync(NarrativeNav); }
        public async Task GoToPolicyCoveragesAsync() { await NavigateToAsync(PolicyCoveragesNav); }
        public async Task GoToLocationsBuildingsAsync() { await NavigateToAsync(LocationsBuildingsNav); }
        public async Task GoToOptionalCoveragesAsync() { await NavigateToAsync(OptionalCoveragesNav); }
        public async Task GoToFarmPersonalPropertyAsync() { await NavigateToAsync(FarmPersonalPropertyNav); }
        public async Task GoToScheduledPersonalPropertyAsync() { await NavigateToAsync(ScheduledPersonalPropertyNav); }
        public async Task GoToLiabilityAsync() { await NavigateToAsync(LiabilityNav); }
        public async Task GoToMortgageeLossPayeeAsync() { await NavigateToAsync(MortgageeLossPayeeNav); }
        public async Task GoToInsuranceScoreAsync() { await NavigateToAsync(InsuranceScoreNav); }
        public async Task GoToPricingAsync() { await NavigateToAsync(PricingNav); }
        public async Task GoToBillingAsync() { await NavigateToAsync(BillingNav); }
        public async Task GoToSubmissionAsync() { await NavigateToAsync(SubmissionNav); }

        /// <summary>
        /// Navigates to any left-menu item by friendly name (case-insensitive).
        /// Delegates to the existing typed GoToXxxAsync methods — test IDs stay in one place.
        /// </summary>
        public Task GoToByNameAsync(string name) =>
            name.Trim().ToLowerInvariant() switch
            {
                "client" or "client info" => GoToClientAsync(),
                "account" or "account details" => GoToAccountDetailsAsync(),
                "proposal" or "proposal start" => GoToProposalStartAsync(),
                "sfp" or "special farm package" => GoToSfpAsync(),
                "policy details" or "policy" => GoToPolicyDetailsAsync(),
                "pre-qualification" or "prequalification" => GoToPreQualificationAsync(),
                "primary insured" or "business details" => GoToPrimaryInsuredDetailsAsync(),
                "claims" or "claims & prior insurance"
                    or "claims and prior insurance" => GoToClaimsPriorInsuranceAsync(),
                "add claim" => GoToAddClaimAsync(),
                "client details" => GoToClientDetailsAsync(),
                "narrative" => GoToNarrativeAsync(),
                "policy coverages" or "coverages" => GoToPolicyCoveragesAsync(),
                "locations" or "locations & buildings"
                    or "locations and buildings" => GoToLocationsBuildingsAsync(),
                "optional coverages" or "optional" => GoToOptionalCoveragesAsync(),
                "farm personal property" or "farm property" => GoToFarmPersonalPropertyAsync(),
                "scheduled personal property" or "scheduled" => GoToScheduledPersonalPropertyAsync(),
                "liability" => GoToLiabilityAsync(),
                "mortgagee" or "additional interests"
                    or "mortgagee & loss payee" => GoToMortgageeLossPayeeAsync(),
                "insurance score" or "insurance designee" => GoToInsuranceScoreAsync(),
                "pricing" => GoToPricingAsync(),
                "billing" => GoToBillingAsync(),
                "submission" => GoToSubmissionAsync(),
                _ => throw new ArgumentException(
                    $"Unknown nav menu item: '{name}'. Check SideMenuNavigation.GoToByNameAsync for valid names.")
            };

        /// <summary>
        /// Returns true if the Insurance Score / Insurance Designee nav item is present
        /// and visible in the side menu for the current state/transaction.
        /// The app only renders this nav item when the business rules require it
        /// (inception date >= 11/14/2014, or SD/WI renewal conversions).
        /// </summary>
        public async Task<bool> IsInsuranceScoreNavPresentAsync()
        {
            return await InsuranceScoreNav.CountAsync() > 0 && await InsuranceScoreNav.IsVisibleAsync();
        }
        #endregion
    }
}
