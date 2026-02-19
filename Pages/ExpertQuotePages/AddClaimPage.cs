using Microsoft.Playwright;
using Playwright_POC.Helpers;
using System;
using System.Threading.Tasks;

namespace Playwright_POC.Pages.ExpertQuotePages
{
    /// <summary>
    /// Page object for the Add Claim dialog/modal in Claims & Violations
    /// </summary>
    internal class AddClaimPage : BasePage
    {
        public AddClaimPage(IPage page) : base(page) { }

        #region Locators
        // Amount fields
        private ILocator AmountPaidInput => _page.GetByTestId("fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$amountPaid.value");
        private ILocator AmountReservedInput => _page.GetByTestId("fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$amountReserved.value");
        private ILocator ExpenseAmountInput => _page.GetByTestId("fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$expenseAmount.value");
        
        // Claim Type buttons (Property / Liability)
        private ILocator ClaimTypePropertyButton => _page.GetByTestId("fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$claimType.value-0");
        private ILocator ClaimTypeLiabilityButton => _page.GetByTestId("fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$claimType.value-1");
        
        // Dropdowns
        private ILocator TypeOfLossDropdown => _page.GetByTestId("_temp.fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$typeOfLoss.value");
        private ILocator CauseOfLossDropdown => _page.GetByTestId("_temp.fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$causeOfLoss.value");
        
        // Description
        private ILocator DescriptionInput => _page.GetByTestId("fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$descriptionOfOccurrenceOrClaim.value");
        
        // Claim Status buttons (Open / Closed)
        private ILocator ClaimStatusOpenButton => _page.GetByTestId("fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$claimStatus.value-0");
        private ILocator ClaimStatusClosedButton => _page.GetByTestId("fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$claimStatus.value-1");
        
        // CAT Loss buttons (Yes / No)
        private ILocator CatLossYesButton => _page.GetByTestId("fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$cATLoss.value-0");
        private ILocator CatLossNoButton => _page.GetByTestId("fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$cATLoss.value-1");
        
        // Action buttons
        private ILocator CancelButton => _page.GetByTestId("fields.underwritingLossExperience.rows[0].addLoss.rows[0].cancel");
        private ILocator SaveButton => _page.GetByTestId("fields.underwritingLossExperience.rows[0].addLoss.rows[0].save");
        private ILocator DeleteButton => _page.GetByTestId("fields.underwritingLossExperience.rows[0].addLoss.rows[0].delete");
        
        // Date picker
        private ILocator DateOfOccurrenceInput => _page.GetByRole(AriaRole.Textbox).Nth(0); // First textbox in the dialog
        private ILocator OpenCalendarButton => _page.GetByRole(AriaRole.Button, new() { Name = "Open calendar" });
        #endregion

        #region Actions
        public async Task EnterAmountPaidAsync(string amount)
        {
            await AmountPaidInput.FillAsync(amount);
        }

        public async Task EnterAmountReservedAsync(string amount)
        {
            await AmountReservedInput.FillAsync(amount);
        }

        public async Task EnterExpenseAmountAsync(string amount)
        {
            await ExpenseAmountInput.FillAsync(amount);
        }

        public async Task SelectClaimTypeAsync(string claimType)
        {
            if (claimType.Equals("Property", StringComparison.OrdinalIgnoreCase))
            {
                await ClaimTypePropertyButton.ClickAsync();
            }
            else if (claimType.Equals("Liability", StringComparison.OrdinalIgnoreCase))
            {
                await ClaimTypeLiabilityButton.ClickAsync();
            }
        }

        public async Task SelectTypeOfLossAsync(string typeOfLoss)
        {
            await TypeOfLossDropdown.ClickAsync();
            await _page.GetByRole(AriaRole.Option, new() { Name = typeOfLoss }).ClickAsync();
        }

        public async Task SelectCauseOfLossAsync(string causeOfLoss)
        {
            await CauseOfLossDropdown.ClickAsync();
            await _page.GetByRole(AriaRole.Option, new() { Name = causeOfLoss }).ClickAsync();
        }

        public async Task EnterDescriptionAsync(string description)
        {
            await DescriptionInput.FillAsync(description);
        }

        public async Task SelectClaimStatusAsync(string status)
        {
            if (status.Equals("Open", StringComparison.OrdinalIgnoreCase))
            {
                await ClaimStatusOpenButton.ClickAsync();
            }
            else if (status.Equals("Closed", StringComparison.OrdinalIgnoreCase))
            {
                await ClaimStatusClosedButton.ClickAsync();
            }
        }

        public async Task SetCatLossAsync(bool isCatLoss)
        {
            if (isCatLoss)
            {
                await CatLossYesButton.ClickAsync();
            }
            else
            {
                await CatLossNoButton.ClickAsync();
            }
        }

        public async Task EnterDateOfOccurrenceAsync(string date)
        {
            await DateOfOccurrenceInput.FillAsync(date);
        }

        public async Task OpenCalendarAsync()
        {
            await OpenCalendarButton.ClickAsync();
        }

        public async Task SaveClaimAsync()
        {
            await SaveButton.ClickAsync();
            await WaitForSpinnerAsync();
        }

        public async Task CancelClaimAsync()
        {
            await CancelButton.ClickAsync();
        }

        public async Task DeleteClaimAsync()
        {
            await DeleteButton.ClickAsync();
            await WaitForSpinnerAsync();
        }
        #endregion
    }
}
