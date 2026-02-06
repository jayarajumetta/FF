using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using Playwright_POC.Helpers;
using Playwright_POC.Locators;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace TestAutomation.Pages.ExpertQuotePages
{
    public class PrimaryInsuredPage
    {
        private readonly IPage _page;

        public PrimaryInsuredPage(IPage page)
        {
            _page = page;
        }

        public async Task SelectExistingClientAsPrimaryInsuredAsync(ScenarioContextData contextData)
        {
            var existingClientButton =
                PrimaryInsuredPageConstLocators.SelectExistingClient(_page);

            await existingClientButton.ClickAsync();

            await Helpers.WaitForSpinnerToClearAsync(_page);
            await Helpers.ClickNextAsync(_page);
        }

        public async Task SearchPersonAsync(ScenarioContextData contextData)
        {
            await _page.FillAsync(PrimaryInsuredPageConstLocators.SearchPrimaryInsuredFirstNameInput, contextData.ClientFirstName);
            await _page.FillAsync(PrimaryInsuredPageConstLocators.SearchPrimaryInsuredLastNameInput, contextData.ClientLastName);
            await _page.ClickAsync(PrimaryInsuredPageConstLocators.PrimaryInsuredSearchButton);

            // Selection of Primary Insured from search results will be implemented here later.
        }

        public async Task EnterPrimaryInsuredDetailsAsync(ScenarioContextData contextData)
        {
            var firstName = AddPrimaryInsuredPageLocators.AddPrimaryInsuredFirstNameInput(_page);
            var firstNameValue = (await firstName.InputValueAsync())?.Trim();
            if (string.IsNullOrWhiteSpace(firstNameValue))
            {
                await firstName.ClickAsync();
                await firstName.PressAsync("Control+A");
                await firstName.PressAsync("Delete");
                await firstName.FillAsync(contextData.ClientFirstName ?? string.Empty);
            }
            await AddPrimaryInsuredPageLocators.AddPrimaryInsuredFirstNameInput(_page).FillAsync(contextData.ClientFirstName);
            await AddPrimaryInsuredPageLocators.AddPrimaryInsuredLastNameInput(_page).FillAsync(contextData.ClientLastName);
            await AddPrimaryInsuredPageLocators.AddPrimaryInsuredDOBInput(_page).FillAsync(contextData.ClientDOB);
            await Helpers.ClickNextAsync(_page);
        }

        public async Task ValidatePrimaryInsuredDetailsAsync(ScenarioContextData contextData)
        {

            var firstName = AddPrimaryInsuredPageLocators.AddPrimaryInsuredFirstNameInput(_page);
            var lastName = AddPrimaryInsuredPageLocators.AddPrimaryInsuredLastNameInput(_page);
            var dob = AddPrimaryInsuredPageLocators.AddPrimaryInsuredDOBInput(_page);
            var mailingAddress = AddPrimaryInsuredPageLocators.AddPrimaryInsuredMailingAddressInput(_page);
            var city = AddPrimaryInsuredPageLocators.AddPrimaryInsuredCityInput(_page);
            var state = await _page.GetByTestId("fields.account.accountInput$state.value").InnerTextAsync();
            var zip = AddPrimaryInsuredPageLocators.AddPrimaryInsuredZipCodeInput(_page);
            var email = AddPrimaryInsuredPageLocators.AddPrimaryInsuredEmailAddressInput(_page);
            var ssnNumber = AddPrimaryInsuredPageLocators.ClientSSNOnFile(_page).InnerTextAsync();
            var actualFirst = (await firstName.InputValueAsync())?.Trim();
            var actualLast = (await lastName.InputValueAsync())?.Trim();
            var actualDobText = (await dob.InputValueAsync())?.Trim();
            var actualMailingAddress = (await mailingAddress.InputValueAsync())?.Trim();
            var actualCity = (await city.InputValueAsync())?.Trim();
            var actualState = state?.Trim();
            var actualZip = (await zip.InputValueAsync())?.Trim();
            var actualZip5 = actualZip?.Split('-')[0];
            var actualEmail = (await email.InputValueAsync())?.Trim();

            // Safely await and trim SSN text; guard against null/short values before slicing
            var actualSSN = (await ssnNumber)?.Trim() ?? string.Empty;
            var ssnLast4 = actualSSN.Length >= 4 ? actualSSN[^4..] : actualSSN;


            Assert.That(
                actualFirst,
                Is.EqualTo(contextData.ClientFirstName).IgnoreCase,
                $"First Name mismatch. Expected: {contextData.ClientFirstName}, Actual: {actualFirst}"
            );

            Assert.That(
                actualLast,
                Is.EqualTo(contextData.ClientLastName).IgnoreCase,
                $"Last Name mismatch. Expected: {contextData.ClientLastName}, Actual: {actualLast}"
            );

            var actualDob = DateTime.Parse(actualDobText, CultureInfo.InvariantCulture);
            var expectedDob = DateTime.Parse(contextData.ClientDOB, CultureInfo.InvariantCulture);
            var expectedDobText = expectedDob.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

            Assert.That(
                actualDob,
                Is.EqualTo(expectedDob),
                $"DOB mismatch. Expected: {expectedDob}, Actual: {actualDob}"
            );
            Assert.That(
                actualMailingAddress,
                Is.EqualTo(contextData.StreetAddress).IgnoreCase,
                $"Mailing Address mismatch. Expected: {contextData.StreetAddress}, Actual: {actualMailingAddress}"
            );
            Assert.That(
                actualCity,
                Is.EqualTo(contextData.City).IgnoreCase,
                $"City mismatch. Expected: {contextData.City}, Actual: {actualCity}"
            );
            Assert.That(
                actualState,
                Is.EqualTo(contextData.State).IgnoreCase,
                $"State mismatch. Expected: {contextData.State}, Actual: {actualState}"
            );
            Assert.That(
                actualZip5,
                Is.EqualTo(contextData.ZipCode).IgnoreCase,
                $"Zip Code mismatch. Expected: {contextData.ZipCode}, Actual: {actualZip5}"
            );

            Assert.That(
                actualEmail,
                Is.EqualTo(contextData.ClientEmail).IgnoreCase,
                $"Email Address mismatch. Expected: {contextData.ClientEmail}, Actual: {actualEmail}"
            );

            // Safely get expected last-4 SSN
            var clientSSNLas4 = !string.IsNullOrEmpty(contextData.SSN) && contextData.SSN.Length >= 4
                ? contextData.SSN[^4..]
                : contextData.SSN ?? string.Empty;

            Assert.That(
                ssnLast4,
                Is.EqualTo(clientSSNLas4).IgnoreCase,
                $"SSN Last 4 mismatch. Expected: {clientSSNLas4}, Actual: {ssnLast4}"
            );
        }
    }
}
