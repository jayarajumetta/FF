
// Pages/AccountInformationPage.cs
using Microsoft.Playwright;
using System;
using System.Globalization;
using System.Threading.Tasks;
using Playwright_POC.Locators;
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

        public async Task WaitForPageReadyAsync()
        {
            await _page.WaitForSelectorAsync(Locators.AccountInformationConstLocators.FirstName, new() { Timeout = 2000 });
        }





        public async Task ValidateAndFillNameFieldsAsync(ScenarioContextData contextData)
        {
            var firstName = _page.Locator(Locators.AccountInformationConstLocators.FirstName);
            var lastName = _page.Locator(Locators.AccountInformationConstLocators.LastName);
            var dob = _page.Locator(Locators.AccountInformationConstLocators.DateOfBirth);

            // First Name: fill only if empty
            var actualFirst = (await firstName.InputValueAsync())?.Trim();
            if (string.IsNullOrWhiteSpace(actualFirst))
            {
                await firstName.ClickAsync();
                await firstName.PressAsync("Control+A");
                await firstName.PressAsync("Delete");
                await firstName.FillAsync(contextData.ClientFirstName ?? string.Empty);
            }

            // Last Name: fill only if empty
            var actualLast = (await lastName.InputValueAsync())?.Trim();
            if (string.IsNullOrWhiteSpace(actualLast))
            {
                await lastName.ClickAsync();
                await lastName.PressAsync("Control+A");
                await lastName.PressAsync("Delete");
                await lastName.FillAsync(contextData.ClientLastName ?? string.Empty);
            }

            // DOB: fill only if empty (ensure the format matches what the UI expects)
            var actualDobText = (await dob.InputValueAsync())?.Trim();
            if (string.IsNullOrWhiteSpace(actualDobText))
            {
                var expectedDob = DateTime.Parse(contextData.ClientDOB, CultureInfo.InvariantCulture);
                var expectedDobText = expectedDob.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                await dob.ClickAsync();
                await dob.PressAsync("Control+A");
                await dob.PressAsync("Delete");
                await dob.FillAsync(expectedDobText);
            }

            // Assertions (optional, but recommended)
            actualFirst = (await firstName.InputValueAsync())?.Trim();
            actualLast = (await lastName.InputValueAsync())?.Trim();
            actualDobText = (await dob.InputValueAsync())?.Trim();

            if ((contextData.ClientFirstName ?? string.Empty).Trim() != actualFirst)
                throw new Exception($"First Name assertion failed: expected '{contextData.ClientFirstName}', found '{actualFirst}'");

            if ((contextData.ClientLastName ?? string.Empty).Trim() != actualLast)
                throw new Exception($"Last Name assertion failed: expected '{contextData.ClientLastName}', found '{actualLast}'");

        }






        public async Task ValidateAndFillContactFieldsAsync(ScenarioContextData contextData)
        {
            var actualPhone = await _page.InputValueAsync(Locators.AccountInformationConstLocators.BestPhone);
            if (!actualPhone.Equals(contextData.ClientPhoneNumber, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Phone mismatch: Expected '{contextData.ClientPhoneNumber}', Found '{actualPhone}'");
                await _page.FillAsync(Locators.AccountInformationConstLocators.BestPhone, contextData.ClientPhoneNumber);
            }

            var actualEmail = await _page.InputValueAsync(Locators.AccountInformationConstLocators.EmailAddress);
            if (!actualEmail.Equals(contextData.ClientEmail, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Email mismatch: Expected '{contextData.ClientEmail}', Found '{actualEmail}'");
                await _page.FillAsync(Locators.AccountInformationConstLocators.EmailAddress, contextData.ClientEmail);
            }
        }

        public async Task SelectMaritalStatusAsync(string maritalStatus)
        {
            if (!maritalStatus.Equals("Single", StringComparison.OrdinalIgnoreCase) &&
                !maritalStatus.Equals("Married", StringComparison.OrdinalIgnoreCase) &&
                !maritalStatus.Equals("Divorced", StringComparison.OrdinalIgnoreCase))
            {
                await _page.ClickAsync(Locators.DriverSummaryConstLocators.MoreOptionsMaritalStatus);
                await Helpers.Helpers.ClickIfNotSelectedAsync(_page, ExpertQuoteLocatorFactory.DriverSummaryPageLocators.GetMaritalStatusSelection(maritalStatus));
            }
            else
            {
                await Helpers.Helpers.ClickIfNotSelectedAsync(_page, ExpertQuoteLocatorFactory.DriverSummaryPageLocators.GetMaritalStatusSelection(maritalStatus));
            }
        }

        public async Task FillAddressFieldsAsync(ScenarioContextData contextData)
        {
            await _page.FillAsync(Locators.AccountInformationConstLocators.StreetAddressInput, contextData.StreetAddress);
            await _page.FillAsync(Locators.AccountInformationConstLocators.AptNumberInput, contextData.AptNumber);
            await _page.FillAsync(Locators.AccountInformationConstLocators.CityInput, contextData.City);

            await _page.ClickAsync(Locators.AccountInformationConstLocators.StateDropdown);
            await _page.ClickAsync($"text={contextData.State.ToUpper()}");
            await _page.FillAsync(Locators.AccountInformationConstLocators.ZipCodeInput, contextData.ZipCode);
        }

        public async Task WaitForAddressDetailsAsync()
        {
            await _page.WaitForSelectorAsync("[aria-label='Map']", new() { Timeout = 10000 });
        }

        public async Task AnswerMailAndResidenceQuestionsAsync(ScenarioContextData contextData)
        {
            await Helpers.Helpers.ClickIfNotSelectedAsync(_page, ExpertQuoteLocatorFactory.AccountInformationPageLocators.GetReceivedMailButton(contextData.RecievedMail));
            await Helpers.Helpers.ClickIfNotSelectedAsync(_page, ExpertQuoteLocatorFactory.AccountInformationPageLocators.GetClientResidesButton(contextData.WhereClientResides));
        }

        public async Task AnswerReceivedMailAsync(ScenarioContextData contextData)
        {
            await _page.ClickAsync(ExpertQuoteLocatorFactory.AccountInformationPageLocators.GetReceivedMailButton(contextData.RecievedMail));
        }
        public async Task ClickNextAsync()
        {
            await _page.ClickAsync(Locators.GlobalLocators.NextButton);
        }

    }
}
