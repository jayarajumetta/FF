// Pages/ProposalDetailsPage.cs
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using Playwright_POC.Locators;
using Playwright_POC.Helpers;
using static Microsoft.Playwright.Assertions;

namespace Playwright_POC.Pages
{
    public class QuoteDetailsPage
    {
        private readonly IPage _page;

        public QuoteDetailsPage(IPage page)
        {
            _page = page;
        }


        public async Task WaitForProposalPageLoadAsync()
        {
            await _page.WaitForLoadStateAsync(LoadState.Load);
        }

        public async Task SelectPersonalAutoProductAsync()
        {
            await Locators.ProposalDetailsPageLocators.PersonalAutoButton(_page).ClickAsync();
        }

        public async Task SelectMotorcycleProductAsync()
        {
            await Locators.ProposalDetailsPageLocators.MotorcycleButton(_page).ClickAsync();
        }

        public async Task SelectRecreationalVehicleProductAsync()
        {
            await Locators.ProposalDetailsPageLocators.RecreationalVehicleButton(_page).ClickAsync();
        }

        public async Task SelectHomeProductAsync()
        {
            await Locators.ProposalDetailsPageLocators.HomeButton(_page).ClickAsync();
        }

        public async Task SelectBusinessOwnerProductAsync()
        {
            await Locators.ProposalDetailsPageLocators.BusinessOwnerButton(_page).ClickAsync();
        }

        public async Task SelectSpecialFarmPackageProductAsync()
        {
            await Locators.ProposalDetailsPageLocators.FarmPackageButton(_page).ClickAsync();
        }

        public async Task WaitForSpecialFarmPackageSelectedAsync()
        {
            // Use Playwright Expect with auto-retry instead of arbitrary sleep
            await Expect(Locators.ProposalDetailsPageLocators.FarmPackageSelectedIndicator(_page))
                .ToBeVisibleAsync(new() { Timeout = 10000 });
        }

        /// <summary>
        /// Enters quote details and returns the actual policy term for verification by the caller.
        /// </summary>
        public async Task<string> EnterQuoteDetailsAsync(ScenarioContextData contextData)
        {
            await Locators.ProposalDetailsPageLocators.EffDateInput(_page).FillAsync(contextData.EffectiveDate);
            string actualPolicyTerm = await Locators.ProposalDetailsPageLocators.PolicyTermDropdownValue(_page).InnerTextAsync();
            await Locators.ProposalDetailsPageLocators.AgentPCCodeInput(_page).FillAsync(contextData.AgentCode);
            return actualPolicyTerm.Trim();
        }

        public async Task EnterSFPQuoteDetailsAsync(ScenarioContextData contextData)
        {
            // Wait for the Quote Details form to be fully loaded using Expect
            await Expect(_page.GetByText("Quote Details")).ToBeVisibleAsync(new() { Timeout = 30000 });
            
            // Try multiple locator strategies for effective date field
            var effDateField = _page.Locator("input[formcontrolname='effectiveDate'], input[name='effectiveDate'], input[id*='effectiveDate'], input[data-testid*='effectiveDate']").First;
            
            // If the above doesn't work, try finding by the label text and getting the associated input
            if (!await effDateField.IsVisibleAsync())
            {
                effDateField = _page.Locator("mat-form-field:has-text('Effective Date') input").First;
            }
            
            await Expect(effDateField).ToBeVisibleAsync(new() { Timeout = 30000 });
            await effDateField.FillAsync(contextData.EffectiveDate);

            await Helpers.Helpers.SelectByTextAsync(_page, Locators.ProposalDetailsPageLocators.ExpandPolicyTermDropdown(_page), 
                  contextData.PolicyTerm);
            
            await Locators.ProposalDetailsPageLocators.AgentPCCodeInput(_page).FillAsync(contextData.AgentCode);
        }

        /// <summary>
        /// Selects rating state and returns the actual writing company for verification by the caller.
        /// </summary>
        public async Task<string> SelectRatingStateAndCompanyAsync(ScenarioContextData contextData)
        {
            await Locators.ProposalDetailsPageLocators.RatingStateDropdown(_page).ClickAsync();
            await _page.GetByText(contextData.RatingState.ToUpper(), new() { Exact = true }).ClickAsync();
            
            // Wait for writing company to populate after state selection
            await LoadingHelpers.WaitForAngularSpinnerAsync(_page);
            
            string actualWritingCompany = await Locators.ProposalDetailsPageLocators.WritingCompanyDropdownValue(_page).InnerTextAsync();
            return actualWritingCompany.Trim();
        }

        public async Task SelectRiskAddressAsync(ScenarioContextData contextData)
        {
            var displayedRiskAddress = await _page.Locator(Locators.ProposalDetailsPageLocators.RiskAddressRadioButton).InnerTextAsync();
            Console.WriteLine($"Displayed Risk Address: {displayedRiskAddress}");
            Console.WriteLine($"Provided Risk Address: {contextData.RiskAddress}");
            if (displayedRiskAddress.Trim().Equals(contextData.RiskAddress.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                await _page.ClickAsync(Locators.ProposalDetailsPageLocators.RiskAddressRadioButton);
            }
            else
            {
                await _page.ClickAsync(Locators.ProposalDetailsPageLocators.AddNewRiskAddressRadioButton);
                // Enter new risk address details here if needed
            }
        }

        public async Task SelectLessorsRiskExposureAsync(ScenarioContextData contextData)
        {
            await _page.ClickAsync(ExpertQuoteLocatorFactory.AccountInformationPageLocators.SelectLessorsRiskExposureButton(contextData.LessorRiskExposure));
        }

        public async Task SelectBusinessEntityAsync(ScenarioContextData contextData)
        {
            if ((contextData.BusinessEntity == "Individually Owned") || (contextData.BusinessEntity == "DBA") || (contextData.BusinessEntity == "T/A"))
            {
                await Locators.ProposalDetailsPageLocators.IndividuallyOwnedCheckbox(_page).ClickAsync();
                // Wait for DBA name input to become visible/enabled instead of arbitrary sleep
                await Expect(Locators.ProposalDetailsPageLocators.DBANameInput(_page)).ToBeVisibleAsync();
                await Locators.ProposalDetailsPageLocators.DBANameInput(_page).FillAsync(contextData.DBAName);
            }
            else
            {
                await _page.FillAsync(Locators.ProposalDetailsPageLocators.BusinessEntitySearchInput, contextData.BusinessEntity);
                await _page.ClickAsync(Locators.ProposalDetailsPageLocators.BusinessEntitySearchButton);
                // Wait for search results instead of arbitrary sleep
                await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            }
        }


        public async Task ClickStartQuoteAsync()
        {
            await Locators.ProposalDetailsPageLocators.StartQuoteButton(_page).ClickAsync();
            // Wait for navigation/loading instead of arbitrary sleep
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }


        public async Task HandleSSNPopupsAsync(ScenarioContextData contextData)
        {   
            // Wait for page to stabilize after Start Quote
            await LoadingHelpers.WaitForAngularSpinnerAsync(_page);

            // SSN pop-up - check with short timeout
            var ssnPopup = Locators.SSNPopUpLocators.SSNPopup(_page);
            try
            {
                await ssnPopup.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 5000 });
                
                string ssnToUse = !string.IsNullOrWhiteSpace(contextData.SSN)
                    ? contextData.SSN
                    : RandomGenerators.GenerateRandomSSN();

                // Persist the SSN used so later validation sees the same full SSN
                contextData.SSN = ssnToUse;

                await Locators.SSNPopUpLocators.SSNInput(_page).FillAsync(ssnToUse);
                await Locators.GlobalLocators.DialogSubmitButton(_page).ClickAsync();
            }
            catch (TimeoutException)
            {
                // SSN popup didn't appear - that's okay, continue
            }

            // SSN Confirmation pop-up - check with short timeout
            try
            {
                await _page.WaitForSelectorAsync(Locators.SSNPopUpLocators.SSNConfirmPopup, new() { State = WaitForSelectorState.Visible, Timeout = 3000 });
                await _page.ClickAsync(Locators.SSNPopUpLocators.SSNConfirmButton);
            }
            catch (TimeoutException)
            {
                // Confirmation popup didn't appear - that's okay, continue
            }

            // Wait for any remaining loading
            await LoadingHelpers.WaitForAngularSpinnerAsync(_page);
        }


        public async Task HandleClientExistsPopupAsync()
        {
            try
            {
                await _page.WaitForSelectorAsync(Locators.ClientExistsPopUpLocators.ClientExistsPopup, new() { State = WaitForSelectorState.Visible, Timeout = 3000 });
                await _page.ClickAsync(Locators.ClientExistsPopUpLocators.CreateNewClientButton);
            }
            catch (TimeoutException)
            {
                // Popup didn't appear - that's okay, continue
            }
        }

        public async Task SelectRatingStateAsync(ScenarioContextData contextData)
        {
            await Locators.ProposalDetailsPageLocators.RatingStateDropdown(_page).ClickAsync();
            await _page.GetByText(contextData.RatingState.ToUpper(), new() { Exact = true }).ClickAsync();
        }
    }
}