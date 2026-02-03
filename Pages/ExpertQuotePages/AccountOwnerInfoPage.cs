// Pages/AccountInformationPage.cs
using Microsoft.Playwright;
using System;
using System.Globalization;
using System.Threading.Tasks;
using Playwright_POC.Helpers;

namespace Playwright_POC.Pages
{
    public class AccountOwnerInfoPage
    {
        private readonly IPage _page;

        public AccountOwnerInfoPage(IPage page)
        {
            _page = page;
        }

        #region Locators
        // Account Information locators - moved from AccountInformationConstLocators
        private ILocator FirstName => _page.Locator("input[name='owner.name.first']");
        private ILocator MiddleName => _page.Locator("input[name='owner.name.middle']");
        private ILocator LastName => _page.Locator("input[name='owner.name.last']");
        private ILocator DateOfBirth => _page.Locator("input[name='owner.dateOfBirth']");
        private ILocator BestPhone => _page.Locator("input[name='owner.phone']");
        private ILocator EmailAddress => _page.Locator("input[name='owner.email']");
        
        // Address fields
        private ILocator StreetAddressInput => _page.Locator("input[name='owner.address.line1']");
        private ILocator AptNumberInput => _page.Locator("input[name='owner.address.line2']");
        private ILocator CityInput => _page.Locator("input[name='owner.address.city']");
        private ILocator StateDropdown => _page.Locator("mat-select[id='owner.address.state']");
        private ILocator ZipCodeInput => _page.Locator("input[name='owner.address.zip']");
        
        // Dynamic locators
        private ILocator MoreOptionsMaritalStatus => _page.GetByTestId("owner.maritalStatus-other");
        private ILocator GetMaritalStatusSelection(string value) => 
            _page.GetByRole(AriaRole.Button, new() { Name = value });
        private ILocator GetReceivedMailButton(string yesOrNo) =>
            _page.Locator("[data-testid^='owner.address.resided90days-']").Filter(new() { HasText = yesOrNo });
        private ILocator GetClientResidesButton(string yesOrNo) =>
            _page.Locator("[data-testid^='owner.address.useAsResidence']").Filter(new() { HasText = yesOrNo });
        
        // Global - handles multiple test-id patterns
        private ILocator NextButton => _page.Locator("[data-testid='next'], [data-testid='fields.data.next']");
        #endregion

        public async Task WaitForPageReadyAsync()
        {
            await FirstName.WaitForAsync(new() { Timeout = 2000 });
        }

        public async Task ValidateAndFillNameFieldsAsync(ScenarioContextData contextData)
        {
            // First Name: fill only if empty
            var actualFirst = (await FirstName.InputValueAsync())?.Trim();
            if (string.IsNullOrWhiteSpace(actualFirst))
            {
                await FirstName.ClickAsync();
                await FirstName.PressAsync("Control+A");
                await FirstName.PressAsync("Delete");
                await FirstName.FillAsync(contextData.ClientFirstName ?? string.Empty);
            }

            // Last Name: fill only if empty
            var actualLast = (await LastName.InputValueAsync())?.Trim();
            if (string.IsNullOrWhiteSpace(actualLast))
            {
                await LastName.ClickAsync();
                await LastName.PressAsync("Control+A");
                await LastName.PressAsync("Delete");
                await LastName.FillAsync(contextData.ClientLastName ?? string.Empty);
            }

            // DOB: fill only if empty (ensure the format matches what the UI expects)
            var actualDobText = (await DateOfBirth.InputValueAsync())?.Trim();
            if (string.IsNullOrWhiteSpace(actualDobText))
            {
                var expectedDob = DateTime.Parse(contextData.ClientDOB, CultureInfo.InvariantCulture);
                var expectedDobText = expectedDob.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                await DateOfBirth.ClickAsync();
                await DateOfBirth.PressAsync("Control+A");
                await DateOfBirth.PressAsync("Delete");
                await DateOfBirth.FillAsync(expectedDobText);
            }

            // Assertions (optional, but recommended)
            actualFirst = (await FirstName.InputValueAsync())?.Trim();
            actualLast = (await LastName.InputValueAsync())?.Trim();
            actualDobText = (await DateOfBirth.InputValueAsync())?.Trim();

            if ((contextData.ClientFirstName ?? string.Empty).Trim() != actualFirst)
                throw new Exception($"First Name assertion failed: expected '{contextData.ClientFirstName}', found '{actualFirst}'");

            if ((contextData.ClientLastName ?? string.Empty).Trim() != actualLast)
                throw new Exception($"Last Name assertion failed: expected '{contextData.ClientLastName}', found '{actualLast}'");
        }

        public async Task ValidateAndFillContactFieldsAsync(ScenarioContextData contextData)
        {
            var actualPhone = await BestPhone.InputValueAsync();
            if (!actualPhone.Equals(contextData.ClientPhoneNumber, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Phone mismatch: Expected '{contextData.ClientPhoneNumber}', Found '{actualPhone}'");
                await BestPhone.FillAsync(contextData.ClientPhoneNumber);
            }

            var actualEmail = await EmailAddress.InputValueAsync();
            if (!actualEmail.Equals(contextData.ClientEmail, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Email mismatch: Expected '{contextData.ClientEmail}', Found '{actualEmail}'");
                await EmailAddress.FillAsync(contextData.ClientEmail);
            }
        }

        public async Task SelectMaritalStatusAsync(string maritalStatus)
        {
            // Wait for marital status section to be ready (use First to avoid strict mode violation)
            await _page.Locator("[data-testid^='owner.maritalStatus']").First.WaitForAsync(new() { Timeout = 10000 });
            
            if (!maritalStatus.Equals("Single", StringComparison.OrdinalIgnoreCase) &&
                !maritalStatus.Equals("Married", StringComparison.OrdinalIgnoreCase) &&
                !maritalStatus.Equals("Divorced", StringComparison.OrdinalIgnoreCase))
            {
                await MoreOptionsMaritalStatus.ClickAsync();
                await Helpers.Helpers.ClickIfNotSelectedAsync(GetMaritalStatusSelection(maritalStatus));
            }
            else
            {
                await GetMaritalStatusSelection(maritalStatus).ClickAsync();
            }
        }

        public async Task FillAddressFieldsAsync(ScenarioContextData contextData)
        {
            await StreetAddressInput.FillAsync(contextData.StreetAddress);
            await AptNumberInput.FillAsync(contextData.AptNumber);
            await CityInput.FillAsync(contextData.City);

            await StateDropdown.ClickAsync();
            await _page.ClickAsync($"text={contextData.State.ToUpper()}");
            await ZipCodeInput.FillAsync(contextData.ZipCode);
        }

        public async Task WaitForAddressDetailsAsync()
        {
            await _page.WaitForSelectorAsync("[aria-label='Map']", new() { Timeout = 10000 });
        }

        public async Task AnswerMailAndResidenceQuestionsAsync(ScenarioContextData contextData)
        {
            await Helpers.Helpers.ClickIfNotSelectedAsync(GetReceivedMailButton(contextData.RecievedMail));
            await Helpers.Helpers.ClickIfNotSelectedAsync(GetClientResidesButton(contextData.WhereClientResides));
        }

        public async Task AnswerReceivedMailAsync(ScenarioContextData contextData)
        {
            await Helpers.Helpers.ClickIfNotSelectedAsync(GetReceivedMailButton(contextData.RecievedMail));
        }

        public async Task ClickNextAsync()
        {
            await NextButton.ClickAsync();
        }

    }
}
