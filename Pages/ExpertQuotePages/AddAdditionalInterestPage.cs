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
            await ExpertQuoteLocatorFactory.AdditionalInterestPageLocators.SelectVehicleRegisteredToOther(_page, vehicleMake).ClickAsync();
        }

        public async Task ClickAddAdditionalInterestAsync()
        {
            await Locators.AdditionalInterestLocators.AddAdditionalInterestButton(_page).ClickAsync();
        }

        public async Task SelectAdditionalInterestTypeAsync(string additionalInterestType)
        {
            await ExpertQuoteLocatorFactory.AdditionalInterestPageLocators.GetAdditionalInterestType(_page, additionalInterestType).ClickAsync();
        }

        public async Task HandleJointOwnerFieldsAsync(ScenarioContextData contextData)
        {
            await ExpertQuoteLocatorFactory.VehicleSummaryPageLocators.GetVehicleSelectButton(_page, contextData.VehicleMake, StringComparison.OrdinalIgnoreCase).ClickAsync();
            await ExpertQuoteLocatorFactory.AdditionalInterestPageLocators.GetJointOwnerDrivesLocator(_page, contextData.JointOwnerDrive).ClickAsync();
            await AdditionalInterestLocators.RelationshipToAccountHolderInput(_page).FillAsync(contextData.RelationshipToAccountOwner);
        }


        public async Task FillAdditionalInterestFieldsAsync(ScenarioContextData contextData)
        {
            // Wait for additional interest form to be ready
            await LoadingHelpers.WaitForAngularSpinnerAsync(_page);
            await Assertions.Expect(Locators.AdditionalInterestLocators.AdditionalInterestNameInput(_page)).ToBeVisibleAsync();

            await FillInputIfDifferentAsync(Locators.AdditionalInterestLocators.AdditionalInterestNameInput(_page), contextData.AdditionalInterestName);
            await FillInputIfDifferentAsync(Locators.AdditionalInterestLocators.AdditionalInterestAddressInput(_page), contextData.AdditionalInterestAddress);
            await FillInputIfDifferentAsync(Locators.AdditionalInterestLocators.AdditionalInterestCityInput(_page), contextData.AdditionalInterestCity);

            await Locators.AdditionalInterestLocators.AdditionalInterestStateDropdown(_page).ClickAsync();
            await ExpertQuoteLocatorFactory.AccountInformationPageLocators.GetStateDropdownSelectionLocator(_page, contextData.AdditionalInterestState).ClickAsync();

            await FillInputIfDifferentAsync(Locators.AdditionalInterestLocators.AdditionalInterestZipInput(_page), contextData.AdditionalInterestZipCode);
            await FillInputIfDifferentAsync(Locators.AdditionalInterestLocators.AdditionalInterestPhoneInput(_page), contextData.AdditionalInterestPhone);
            await FillInputIfDifferentAsync(Locators.AdditionalInterestLocators.AdditionalInterestDOBInput(_page), contextData.AdditionalInterestDOB);
            await FillInputIfDifferentAsync(Locators.AdditionalInterestLocators.AdditionalInterestDLNumberInput(_page), contextData.AdditionalInterestDLNumber);

            await Locators.AdditionalInterestLocators.AdditionalInterestLicenseState(_page).ClickAsync();
            await ExpertQuoteLocatorFactory.AccountInformationPageLocators.GetStateDropdownSelectionLocator(_page, contextData.AdditionalInterestLicenseState).ClickAsync();
        }

        // Helper method
        public async Task FillInputIfDifferentAsync(ILocator locator, string value)
        {
            var currentValue = await locator.InputValueAsync();
            if (!currentValue.Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                await locator.FillAsync(value);
            }
        }
        
        public async Task ClickCancelAsync()
        {
            await _page.ClickAsync(Locators.GlobalLocators.CancelButton);
        }


        public async Task SaveAndContinueAsync()
        {
            await Locators.GlobalLocators.SaveAndContinueButton(_page).ClickAsync();
        }

        public async Task HandleUWDialogIfPresentAsync()
        {
            await AdditionalInterestLocators.UWRulesDialogContinueButton(_page).WaitForAsync(new()
            {
                State = WaitForSelectorState.Visible,
                Timeout = 5000
            });

            if (await AdditionalInterestLocators.UWRulesDialogContinueButton(_page).IsVisibleAsync())
            {
                await AdditionalInterestLocators.UWRulesDialogContinueButton(_page).WaitForAsync(new() { Timeout = 5000 });
                await Locators.AdditionalInterestLocators.UWRulesDialogContinueButton(_page).ClickAsync();
            }
        }


    }
}
