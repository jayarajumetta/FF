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
            await AccountInformationConstLocators.FirstName(_page).WaitForAsync(new() { Timeout = 2000 });
        }





        public async Task ValidateAndFillNameFieldsAsync(ScenarioContextData contextData)
        {
            var firstName = Locators.AccountInformationConstLocators.FirstName(_page);
            var lastName = Locators.AccountInformationConstLocators.LastName(_page);
            var dob = Locators.AccountInformationConstLocators.DateOfBirth(_page);

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
            var actualPhone = await Locators.AccountInformationConstLocators.BestPhone(_page).InputValueAsync();
            if (!actualPhone.Equals(contextData.ClientPhoneNumber, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Phone mismatch: Expected '{contextData.ClientPhoneNumber}', Found '{actualPhone}'");
                await Locators.AccountInformationConstLocators.BestPhone(_page).FillAsync(contextData.ClientPhoneNumber);
            }

            var actualEmail = await Locators.AccountInformationConstLocators.EmailAddress(_page).InputValueAsync();
            if (!actualEmail.Equals(contextData.ClientEmail, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Email mismatch: Expected '{contextData.ClientEmail}', Found '{actualEmail}'");
                await Locators.AccountInformationConstLocators.EmailAddress(_page).FillAsync(contextData.ClientEmail);
            }
        }

        public async Task SelectMaritalStatusAsync(string maritalStatus)
        {
            if (!maritalStatus.Equals("Single", StringComparison.OrdinalIgnoreCase) &&
                !maritalStatus.Equals("Married", StringComparison.OrdinalIgnoreCase) &&
                !maritalStatus.Equals("Divorced", StringComparison.OrdinalIgnoreCase))
            {
                await DriverSummaryConstLocators.MoreOptionsMaritalStatus(_page).ClickAsync();
                await Helpers.Helpers.ClickIfNotSelectedAsync(ExpertQuoteLocatorFactory.DriverSummaryPageLocators.GetMaritalStatusSelection(_page, maritalStatus));
            }
            else
            {
                await ExpertQuoteLocatorFactory.DriverSummaryPageLocators.GetMaritalStatusSelection(_page, maritalStatus).ClickAsync();
            }
        }

        public async Task FillAddressFieldsAsync(ScenarioContextData contextData)
        {
            await Locators.AccountInformationConstLocators.StreetAddressInput(_page).FillAsync(contextData.StreetAddress);
            await Locators.AccountInformationConstLocators.AptNumberInput(_page).FillAsync(contextData.AptNumber);
            await Locators.AccountInformationConstLocators.CityInput(_page).FillAsync(contextData.City);

            await Locators.AccountInformationConstLocators.StateDropdown(_page).ClickAsync();
            await _page.ClickAsync($"text={contextData.State.ToUpper()}");
            await Locators.AccountInformationConstLocators.ZipCodeInput(_page).FillAsync(contextData.ZipCode);
        }

        public async Task WaitForAddressDetailsAsync()
        {
            await _page.WaitForSelectorAsync("[aria-label='Map']", new() { Timeout = 10000 });
        }

        public async Task AnswerMailAndResidenceQuestionsAsync(ScenarioContextData contextData)
        {
            await Helpers.Helpers.ClickIfNotSelectedAsync(ExpertQuoteLocatorFactory.AccountInformationPageLocators.GetReceivedMailButton(_page, contextData.RecievedMail));
            await Helpers.Helpers.ClickIfNotSelectedAsync(ExpertQuoteLocatorFactory.AccountInformationPageLocators.GetClientResidesButton(_page, contextData.WhereClientResides));
        }

        public async Task AnswerReceivedMailAsync(ScenarioContextData contextData)
        {
            await Helpers.Helpers.ClickIfNotSelectedAsync(ExpertQuoteLocatorFactory.AccountInformationPageLocators.GetReceivedMailButton(_page, contextData.RecievedMail));
        }
        public async Task ClickNextAsync()
        {
            await Locators.GlobalLocators.NextButton(_page).ClickAsync();
        }

    }
}
