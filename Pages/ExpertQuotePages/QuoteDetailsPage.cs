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

        public async Task CheckSpecialFarmPackageSelected()
        {
            await _page.WaitForTimeoutAsync(2000);
            bool isSelected = await Locators.ProposalDetailsPageLocators.FarmPackageSelectedIndicator(_page).IsVisibleAsync();
            Assert.That(isSelected, Is.True, "Special Farm Package product is not selected.");
        }

        public async Task EnterQuoteDetailsAsync(ScenarioContextData contextData)
        {
            await Locators.ProposalDetailsPageLocators.EffDateInput(_page).FillAsync(contextData.EffectiveDate);
            string actualPolicyTerm = await Locators.ProposalDetailsPageLocators.PolicyTermDropdownValue(_page).InnerTextAsync();
            Assert.That(actualPolicyTerm.Trim(), Is.EqualTo(contextData.PolicyTerm), "Policy Term does not match expected value.");
            await Locators.ProposalDetailsPageLocators.AgentPCCodeInput(_page).FillAsync(contextData.AgentCode);
        }

        public async Task EnterSFPQuoteDetailsAsync(ScenarioContextData contextData)
        {
            await Locators.ProposalDetailsPageLocators.EffDateInput(_page).FillAsync(contextData.EffectiveDate);
            await Locators.ProposalDetailsPageLocators.ExpandPolicyTermDropdown(_page).ClickAsync();
            await _page.ClickAsync(ExpertQuoteLocatorFactory.AccountInformationPageLocators.SelectPolicyTermFromDropdown(contextData.PolicyTerm));
            await Locators.ProposalDetailsPageLocators.AgentPCCodeInput(_page).FillAsync(contextData.AgentCode);
        }

        public async Task SelectRatingStateAndCompanyAsync(ScenarioContextData contextData)
        {
            await Locators.ProposalDetailsPageLocators.RatingStateDropdown(_page).ClickAsync();
            await _page.ClickAsync($"text={contextData.RatingState.ToUpper()}");
            string actualWritingCompany = await Locators.ProposalDetailsPageLocators.WritingCompanyDropdownValue(_page).InnerTextAsync();
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
                await Locators.ProposalDetailsPageLocators.IndividuallyOwnedCheckbox(_page).ClickAsync();
                await _page.WaitForTimeoutAsync(2000);
                await Locators.ProposalDetailsPageLocators.DBANameInput(_page).FillAsync(contextData.DBAName);
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
            await Locators.ProposalDetailsPageLocators.StartQuoteButton(_page).ClickAsync();
            await _page.WaitForTimeoutAsync(3000);
        }


        public async Task HandleSSNPopupsAsync(ScenarioContextData contextData)
        {
            await _page.WaitForTimeoutAsync(3000);

            // SSN pop-up
            if (await Locators.SSNPopUpLocators.SSNPopup(_page).IsVisibleAsync())
            {
                string ssnToUse = !string.IsNullOrWhiteSpace(contextData.SSN)
                    ? contextData.SSN
                    : RandomGenerators.GenerateRandomSSN();

                await Locators.SSNPopUpLocators.SSNInput(_page).FillAsync(ssnToUse);
                await Locators.GlobalLocators.DialogSubmitButton(_page).ClickAsync();
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
            await Locators.ProposalDetailsPageLocators.RatingStateDropdown(_page).ClickAsync();
            await _page.ClickAsync($"text={contextData.RatingState.ToUpper()}");
           
        }

    }
}

