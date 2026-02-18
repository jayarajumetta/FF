// Pages/AddAdditionalInterestPage.cs
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using Playwright_POC.Helpers;

namespace Playwright_POC.Pages
{
    public class AddAdditionalInterestPage : BasePage
    {
        public AddAdditionalInterestPage(IPage page) : base(page) { }

        #region Locators
        private ILocator AddAdditionalInterestButton => _page.GetByTestId("add_Additional_Interest");
        private ILocator AdditionalInterestNameInput => _page.GetByTestId("fields.account.additionalOtherInterest.additionalOtherInterestInput$name.value");
        private ILocator AdditionalInterestAddressInput => _page.GetByTestId("fields.account.additionalOtherInterest.additionalOtherInterestInput$name.value");
        private ILocator AdditionalInterestCityInput => _page.GetByTestId("fields.account.additionalOtherInterest.additionalOtherInterestInput$city.value");
        private ILocator AdditionalInterestStateDropdown => _page.GetByTestId("fields.account.additionalOtherInterest.additionalOtherInterestInput$state.value");
        private ILocator AdditionalInterestZipInput => _page.GetByTestId("fields.account.additionalOtherInterest.additionalOtherInterestInput$zipCode.value");
        private ILocator AdditionalInterestPhoneInput => _page.GetByTestId("fields.account.additionalOtherInterest.additionalOtherInterestInput$primaryPhone.value");
        private ILocator RelationshipToAccountHolderInput => _page.GetByTestId("fields.account.additionalOtherInterest.additionalOtherInterestInput$relationshipToInsured.value");
        private ILocator AdditionalInterestDOBInput => _page.GetByLabel("Owner Date Of Birth");
        private ILocator AdditionalInterestDLNumberInput => _page.GetByTestId("fields.account.additionalOtherInterest.additionalOtherInterestInput$ownerDriversLicenseNumber.value");
        private ILocator AdditionalInterestLicenseStateDropdown => _page.GetByLabel(" Owner License State ");
        private ILocator UWRulesDialogContinueButton => _page.GetByTestId("btnConfirmYes");
        private ILocator CancelButton => _page.Locator("button:has-text('Cancel')");
        private ILocator SaveAndContinueButton => _page.GetByTestId("fields.line.save_and_Continue");

        // Dynamic locators
        private ILocator GetOtherRegistrationQuestionButton(string yesOrNo) =>
            _page.Locator($"div[id*='AnyVehicleRegisteredToSomeone'] div:has-text('{yesOrNo}')");

        private ILocator GetVehicleRegisteredToOtherButton(string vehicleMake) =>
            _page.GetByRole(AriaRole.Button, new() { Name = vehicleMake, Exact = true });

        private ILocator GetAdditionalInterestTypeButton(string value) =>
            _page.GetByRole(AriaRole.Button, new() { Name = value });

        private ILocator GetVehicleSelectButton(string value) =>
            _page.Locator("[id*='vehicle']").GetByRole(AriaRole.Button, new() { Name = value });

        private ILocator GetJointOwnerDrivesButton(string yesOrNo) =>
            _page.GetByRole(AriaRole.Button, new() { Name = yesOrNo });

        private ILocator GetStateDropdownOption(string stateCode) =>
            _page.GetByRole(AriaRole.Listbox).GetByRole(AriaRole.Option, new() { Name = stateCode.ToUpper() });
        #endregion

        public async Task AnswerRegisteredToSomeoneElseQuestion(string yesOrNo)
        {
            await GetOtherRegistrationQuestionButton(yesOrNo).ClickAsync();
        }

        public async Task SelectVehicleRegisteredToSomeoneElseAsync(string vehicleMake)
        {
            await GetVehicleRegisteredToOtherButton(vehicleMake).ClickAsync();
        }

        public async Task ClickAddAdditionalInterestAsync()
        {
            await AddAdditionalInterestButton.ClickAsync();
        }

        public async Task SelectAdditionalInterestTypeAsync(string additionalInterestType)
        {
            await GetAdditionalInterestTypeButton(additionalInterestType).ClickAsync();
        }

        public async Task HandleJointOwnerFieldsAsync(ScenarioContextData contextData)
        {
            await GetVehicleSelectButton(contextData.VehicleMake).ClickAsync();
            await GetJointOwnerDrivesButton(contextData.JointOwnerDrive).ClickAsync();
            await RelationshipToAccountHolderInput.FillAsync(contextData.RelationshipToAccountOwner);
        }

        public async Task FillAdditionalInterestFieldsAsync(ScenarioContextData contextData)
        {
            await WaitForSpinnerAsync();
            await Assertions.Expect(AdditionalInterestNameInput).ToBeVisibleAsync();

            await FillInputIfDifferentAsync(AdditionalInterestNameInput, contextData.AdditionalInterestName);
            await FillInputIfDifferentAsync(AdditionalInterestAddressInput, contextData.AdditionalInterestAddress);
            await FillInputIfDifferentAsync(AdditionalInterestCityInput, contextData.AdditionalInterestCity);

            await AdditionalInterestStateDropdown.ClickAsync();
            await GetStateDropdownOption(contextData.AdditionalInterestState).ClickAsync();

            await FillInputIfDifferentAsync(AdditionalInterestZipInput, contextData.AdditionalInterestZipCode);
            await FillInputIfDifferentAsync(AdditionalInterestPhoneInput, contextData.AdditionalInterestPhone);
            await FillInputIfDifferentAsync(AdditionalInterestDOBInput, contextData.AdditionalInterestDOB);
            await FillInputIfDifferentAsync(AdditionalInterestDLNumberInput, contextData.AdditionalInterestDLNumber);

            await AdditionalInterestLicenseStateDropdown.ClickAsync();
            await GetStateDropdownOption(contextData.AdditionalInterestLicenseState).ClickAsync();
        }

        private async Task FillInputIfDifferentAsync(ILocator locator, string value)
        {
            var currentValue = await locator.InputValueAsync();
            if (!currentValue.Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                await locator.FillAsync(value);
            }
        }

        public async Task ClickCancelAsync()
        {
            await CancelButton.ClickAsync();
        }

        public async Task SaveAndContinueAsync()
        {
            await SaveAndContinueButton.ClickAsync();
        }

        public async Task HandleUWDialogIfPresentAsync()
        {
            try
            {
                await UWRulesDialogContinueButton.WaitForAsync(new()
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 5000
                });

                if (await UWRulesDialogContinueButton.IsVisibleAsync())
                {
                    await UWRulesDialogContinueButton.ClickAsync();
                }
            }
            catch (TimeoutException)
            {
                // Dialog didn't appear - continue
            }
        }
    }
}
