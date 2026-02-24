using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Helpers;
using Playwright_POC.Pages;

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
        #endregion
    }
}
