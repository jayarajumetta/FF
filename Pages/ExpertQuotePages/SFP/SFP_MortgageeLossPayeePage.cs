using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Helpers;

namespace Playwright_POC.Pages.ExpertQuotePages.SFP
{
    /// <summary>
    /// SFP Mortgagee / Loss Payee page - for adding mortgagee additional interest to a policy.
    /// </summary>
    public class SFP_MortgageeLossPayeePage : BasePage
    {
        public SFP_MortgageeLossPayeePage(IPage page) : base(page) { }

        #region Locators - Add Mortgagee Button
        public ILocator AddMortgageeButton =>
            _page.GetByTestId("fields.data.account.additionalOtherInterest.addAdditionalInterests");
        #endregion

        #region Locators - Search
        public ILocator SearchNameInput =>
            _page.GetByTestId("temp.searchName");

        public ILocator SearchButton =>
            _page.GetByTestId("searchActionButton");

        public ILocator FirstSearchResultCheckbox =>
            _page.GetByTestId("additionalInsuredSelected.0");
        #endregion

        #region Locators - Mortgagee Details Form
        public ILocator LocationSelect =>
            _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$locationID.value");

        public ILocator ResidenceSelect =>
            _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$buildingID.value");

        public ILocator FirstResidenceOption =>
            _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$buildingID.value-0");

        public ILocator DescriptionOfInterestInput =>
            _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$descriptionOfInterest.value");

        public ILocator AccountNumberInput =>
            _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$accountNumber.value");

        public ILocator ProofOfCoverageYesButton =>
            _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$proofOfCoverageRequired.value-1");

        public ILocator ProofOfCoverageNoButton =>
            _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$proofOfCoverageRequired.value-0");

        public ILocator EscrowBilledYesButton =>
            _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$mortgageeResponsibleForEscrow.value-1");

        public ILocator EscrowBilledNoButton =>
            _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$mortgageeResponsibleForEscrow.value-0");

        public ILocator SaveMortgageeButton =>
            _page.GetByRole(AriaRole.Button, new() { Name = "Save" });

        public ILocator NextButton =>
            _page.GetByTestId("fields.data.next");
        #endregion

        #region Actions
        public async Task AddMortgageeAsync(ScenarioContextData contextData)
        {
            await WaitForSpinnerAsync();

            // Click + ADD ADDITIONAL INTEREST to open the mortgagee form
            await AddMortgageeButton.ClickAsync();
            await WaitForSpinnerAsync();

            // Search for mortgagee by name
            if (!string.IsNullOrEmpty(contextData.MortgageeSearchName))
            {
                await SearchNameInput.FillAsync(contextData.MortgageeSearchName);
                await SearchButton.ClickAsync();
                await WaitForSpinnerAsync();

                // Select the first search result
                await FirstSearchResultCheckbox.ClickAsync();
                await WaitForSpinnerAsync();
            }

            // Select Location if specified
            if (!string.IsNullOrEmpty(contextData.MortgageeLocation))
            {
                await LocationSelect.ClickAsync();
                await _page.GetByRole(AriaRole.Option, new() { Name = contextData.MortgageeLocation, Exact = false }).ClickAsync();
                await WaitForSpinnerAsync();
            }

            // Select Residence if specified
            if (!string.IsNullOrEmpty(contextData.MortgageeResidence))
            {
                await ResidenceSelect.ClickAsync();
                await FirstResidenceOption.ClickAsync();
                await WaitForSpinnerAsync();
            }

            // Copy of DEC (Proof of Coverage Required)
            if (!string.IsNullOrEmpty(contextData.MortgageeCopyOfDEC))
            {
                var isYes = contextData.MortgageeCopyOfDEC.ToLower() is "yes" or "true";
                await (isYes ? ProofOfCoverageYesButton : ProofOfCoverageNoButton).ClickAsync();
            }

            // Account Number
            if (!string.IsNullOrEmpty(contextData.MortgageeAccountNumber))
                await AccountNumberInput.FillAsync(contextData.MortgageeAccountNumber);

            // Description of Interest (free text input)
            if (!string.IsNullOrEmpty(contextData.MortgageeDescriptionOfInterest))
                await DescriptionOfInterestInput.FillAsync(contextData.MortgageeDescriptionOfInterest);

            // Escrow Billed (Mortgagee Responsible for Escrow)
            if (!string.IsNullOrEmpty(contextData.MortgageeEscrowBilled))
            {
                var isYes = contextData.MortgageeEscrowBilled.ToLower() is "yes" or "true";
                await (isYes ? EscrowBilledYesButton : EscrowBilledNoButton).ClickAsync();
            }

            // Save the mortgagee
            await SaveMortgageeButton.ClickAsync();
            await WaitForSpinnerAsync();

            // Navigate to next page (Insurance Score)
            await NextButton.ClickAsync();
            await WaitForSpinnerAsync();
        }
        #endregion
    }
}
