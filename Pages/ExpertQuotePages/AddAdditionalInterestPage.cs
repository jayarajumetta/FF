// Pages/AddAdditionalInterestPage.cs
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using Playwright_POC.Locators;
using Playwright_POC.Helpers;

namespace Playwright_POC.Pages
{
    public class AddAdditionalInterestPage
    {
        private readonly IPage _page;

        public AddAdditionalInterestPage(IPage page)
        {
            _page = page;
        }

        public async Task AnswerRegisteredToSomeoneElseQuestion(string yesOrNo)
        {
            await _page.ClickAsync(ExpertQuoteLocatorFactory.AdditionalInterestPageLocators.OtherRegistrationQuestion(yesOrNo));
        }

        public async Task SelectVehicleRegisteredToSomeoneElseAsync(string vehicleMake)
        {
            await _page.ClickAsync(ExpertQuoteLocatorFactory.AdditionalInterestPageLocators.SelectVehicleRegisteredToOther(vehicleMake));
        }

        public async Task ClickAddAdditionalInterestAsync()
        {
            await Locators.AdditionalInterestLocators.AddAdditionalInterestButton(_page).ClickAsync();
        }

        public async Task SelectAdditionalInterestTypeAsync(string additionalInterestType)
        {
            await _page.ClickAsync(ExpertQuoteLocatorFactory.AdditionalInterestPageLocators.GetAdditionalInterestType(additionalInterestType));
        }

        public async Task HandleJointOwnerFieldsAsync(ScenarioContextData contextData)
        {
            await _page.ClickAsync(ExpertQuoteLocatorFactory.VehicleSummaryPageLocators.GetVehicleSelectButton(contextData.VehicleMake, StringComparison.OrdinalIgnoreCase));
            await _page.ClickAsync(ExpertQuoteLocatorFactory.AdditionalInterestPageLocators.GetJointOwnerDrivesLocator(contextData.JointOwnerDrive));
            await _page.FillAsync(Locators.AdditionalInterestLocators.RelationshipToAccountHolderInput, contextData.RelationshipToAccountOwner);
        }


        public async Task FillAdditionalInterestFieldsAsync(ScenarioContextData contextData)
        {
            await _page.WaitForTimeoutAsync(3000); 
            await FillInputIfDifferentAsync(Locators.AdditionalInterestLocators.AdditionalInterestNameInput, contextData.AdditionalInterestName);
            await FillInputIfDifferentAsync(Locators.AdditionalInterestLocators.AdditionalInterestAddressInput, contextData.AdditionalInterestAddress);
            await FillInputIfDifferentAsync(Locators.AdditionalInterestLocators.AdditionalInterestCityInput, contextData.AdditionalInterestCity);

            await _page.ClickAsync(Locators.AdditionalInterestLocators.AdditionalInterestStateDropdown);
            await ExpertQuoteLocatorFactory.AccountInformationPageLocators.GetStateDropdownSelectionLocator(_page, contextData.AdditionalInterestState).ClickAsync();

            await FillInputIfDifferentAsync(Locators.AdditionalInterestLocators.AdditionalInterestZipInput, contextData.AdditionalInterestZipCode);
            await FillInputIfDifferentAsync(Locators.AdditionalInterestLocators.AdditionalInterestPhoneInput, contextData.AdditionalInterestPhone);
            await FillInputIfDifferentAsync(Locators.AdditionalInterestLocators.AdditionalInterestDOBInput, contextData.AdditionalInterestDOB);
            await FillInputIfDifferentAsync(Locators.AdditionalInterestLocators.AdditionalInterestDLNumberInput, contextData.AdditionalInterestDLNumber);

            await _page.ClickAsync(Locators.AdditionalInterestLocators.AdditionalInterestLicenseState);
            await ExpertQuoteLocatorFactory.AccountInformationPageLocators.GetStateDropdownSelectionLocator(_page, contextData.AdditionalInterestLicenseState).ClickAsync();
        }

        // Helper method
        public async Task FillInputIfDifferentAsync(string selector, string value)
        {
            var currentValue = await _page.InputValueAsync(selector);
            if (!currentValue.Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                await _page.FillAsync(selector, value);
            }
        }
        
        public async Task ClickCancelAsync()
        {
            await _page.ClickAsync(Locators.GlobalLocators.CancelButton);
        }


        public async Task SaveAndContinueAsync()
        {
            await _page.ClickAsync(Locators.GlobalLocators.SaveAndContinueButton);
        }

        public async Task HandleUWDialogIfPresentAsync()
        {
            await _page.WaitForSelectorAsync(Locators.AdditionalInterestLocators.UWRulesDialogContinueButton, new()
            {
                State = WaitForSelectorState.Visible,
                Timeout = 5000
            });

            if (await _page.Locator(Locators.AdditionalInterestLocators.UWRulesDialogContinueButton).IsVisibleAsync())
            {
                await _page.WaitForSelectorAsync(Locators.AdditionalInterestLocators.UWRulesDialogContinueButton, new() { Timeout = 5000 });
                await _page.ClickAsync(Locators.AdditionalInterestLocators.UWRulesDialogContinueButton);
            }
        }

        public async Task ClickNextAsync()
        {
            await Locators.GlobalLocators.NextButton(_page).ClickAsync();
        }

    }
}
