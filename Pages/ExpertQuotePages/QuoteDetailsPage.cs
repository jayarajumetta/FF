// Pages/ProposalDetailsPage.cs
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using Playwright_POC.Locators;
using Playwright_POC.Helpers;
using NUnit.Framework;

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
            await _page.ClickAsync(Locators.ProposalDetailsPageLocators.PersonalAutoButton);
        }

        public async Task SelectMotorcycleProductAsync()
        {
            await _page.ClickAsync(Locators.ProposalDetailsPageLocators.MotorcycleButton);
        }

        public async Task SelectRecreationalVehicleProductAsync()
        {
            await _page.ClickAsync(Locators.ProposalDetailsPageLocators.RecreationalVehicleButton);
        }

        public async Task SelectHomeProductAsync()
        {
            await _page.ClickAsync(Locators.ProposalDetailsPageLocators.HomeButton);
        }

        public async Task SelectBusinessOwnerProductAsync()
        {
            await _page.ClickAsync(Locators.ProposalDetailsPageLocators.BusinessOwnerButton);
        }

        public async Task SelectSpecialFarmPackageProductAsync()
        {
            await _page.ClickAsync(Locators.ProposalDetailsPageLocators.FarmPackageButton);
        }

        public async Task CheckSpecialFarmPackageSelected()
        {
            await _page.WaitForTimeoutAsync(2000);
            bool isSelected = await _page.IsVisibleAsync(Locators.ProposalDetailsPageLocators.FarmPackageSelectedIndicator);
            Assert.That(isSelected, Is.True, "Special Farm Package product is not selected.");
        }

        public async Task EnterQuoteDetailsAsync(ScenarioContextData contextData)
        {
            await _page.FillAsync(Locators.ProposalDetailsPageLocators.EffDateInput, contextData.EffectiveDate);
            string actualPolicyTerm = await _page.InnerTextAsync(Locators.ProposalDetailsPageLocators.PolicyTermDropdownValue);
            Assert.That(actualPolicyTerm.Trim(), Is.EqualTo(contextData.PolicyTerm), "Policy Term does not match expected value.");
            await _page.FillAsync(Locators.ProposalDetailsPageLocators.AgentPCCodeInput, contextData.AgentCode);
        }

        public async Task EnterSFPQuoteDetailsAsync(ScenarioContextData contextData)
        {
            await _page.FillAsync(Locators.ProposalDetailsPageLocators.EffDateInput, contextData.EffectiveDate);
            await _page.ClickAsync(Locators.ProposalDetailsPageLocators.ExpandPolicyTermDropdown);
            await _page.ClickAsync(ExpertQuoteLocatorFactory.AccountInformationPageLocators.SelectPolicyTermFromDropdown(contextData.PolicyTerm));
            await _page.FillAsync(Locators.ProposalDetailsPageLocators.AgentPCCodeInput, contextData.AgentCode);
        }

        public async Task SelectRatingStateAndCompanyAsync(ScenarioContextData contextData)
        {
            await _page.ClickAsync(Locators.ProposalDetailsPageLocators.RatingStateDropdown);
            await _page.ClickAsync($"text={contextData.RatingState.ToUpper()}");
            string actualWritingCompany = await _page.InnerTextAsync(Locators.ProposalDetailsPageLocators.WritingCompanyDropdownValue);
            Assert.That(actualWritingCompany.Trim(), Is.EqualTo(contextData.WritingCompany), "Writing Company does not match expected value.");
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
                await _page.ClickAsync(Locators.ProposalDetailsPageLocators.IndividuallyOwnedCheckbox);
                await _page.WaitForTimeoutAsync(2000);
                await _page.FillAsync(Locators.ProposalDetailsPageLocators.DBANameInput, contextData.DBAName);
            }
            else
            {
                await _page.FillAsync(Locators.ProposalDetailsPageLocators.BusinessEntitySearchInput, contextData.BusinessEntity);
                await _page.ClickAsync(Locators.ProposalDetailsPageLocators.BusinessEntitySearchButton);
                await _page.WaitForTimeoutAsync(2000);
            }
        }


        public async Task ClickStartQuoteAsync()
        {
            await _page.ClickAsync(Locators.ProposalDetailsPageLocators.StartQuoteButton);
            await _page.WaitForTimeoutAsync(3000);
        }


        public async Task HandleSSNPopupsAsync(ScenarioContextData contextData)
        {
            await _page.WaitForTimeoutAsync(3000);

            // SSN pop-up
            if (await _page.IsVisibleAsync(Locators.SSNPopUpLocators.SSNPopup))
            {
                string ssnToUse = !string.IsNullOrWhiteSpace(contextData.SSN)
                    ? contextData.SSN
                    : RandomGenerators.GenerateRandomSSN();

                await _page.FillAsync(Locators.SSNPopUpLocators.SSNInput, ssnToUse);
                await _page.ClickAsync(Locators.GlobalLocators.DialogSubmitButton);
            }

            // SSN Confirmation pop-up
            if (await _page.IsVisibleAsync(Locators.SSNPopUpLocators.SSNConfirmPopup))
            {
                await _page.ClickAsync(Locators.SSNPopUpLocators.SSNConfirmButton);
            }

            await _page.WaitForTimeoutAsync(2000);
        }


        public async Task HandleClientExistsPopupAsync()
        {
            if (await _page.IsVisibleAsync(Locators.ClientExistsPopUpLocators.ClientExistsPopup))
            {
                await _page.ClickAsync(Locators.ClientExistsPopUpLocators.CreateNewClientButton);
            }
        }

        public async Task SelectRatingStateAsync(ScenarioContextData contextData)
        {
            await _page.ClickAsync(Locators.ProposalDetailsPageLocators.RatingStateDropdown);
            await _page.ClickAsync($"text={contextData.RatingState.ToUpper()}");
           
        }

    }
}

