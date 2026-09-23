// Pages/AccountOwnerInfoPage.cs
using Microsoft.Playwright;
using System;
using System.Globalization;
using System.Threading.Tasks;
using PnCTestAutomation.Helpers;

namespace PnCTestAutomation.Pages
{
    public class AccountOwnerInfoPage : BasePage
    {
        public AccountOwnerInfoPage(IPage page) : base(page) { }

        #region Locators
        // Account Owner Information
        private ILocator PageHeader => _page.GetByRole(AriaRole.Heading, new() { Name = "Account Information", Exact = true });
        private ILocator FirstNameInput => _page.GetByTestId("owner.name.first");
        private ILocator MiddleNameInput => _page.GetByTestId("owner.name.middle");
        private ILocator LastNameInput => _page.GetByTestId("owner.name.last");
        private ILocator DateOfBirthInput => _page.Locator("input[name='owner.dateOfBirth']");
        private ILocator BestPhoneInput => _page.GetByTestId("owner.phone");
        private ILocator EmailAddressInput => _page.GetByTestId("owner.email");

        // Account/Mailing Address Information
        private ILocator StreetAddressInput => _page.GetByPlaceholder("Enter a location");
        private ILocator AptNumberInput => _page.GetByTestId("owner.address.line2");
        private ILocator CityInput => _page.GetByTestId("owner.address.city");
        private ILocator StateDropdown => _page.GetByTestId("owner.address.state");
        private ILocator ZipCodeInput => _page.GetByTestId("owner.address.zip");

        // Dynamic locators
        private ILocator GetReceivedMailButton(string yesOrNo) =>
            _page.GetByTestId("owner.address.resided90days-chip-item-wrapper").Filter(new() { HasText = yesOrNo }).First;

        private ILocator GetClientResidesButton(string yesOrNo) =>
            _page.GetByTestId("owner.address.useAsResidence-chip-item-wrapper").Filter(new() { HasText = yesOrNo }).First;

        private ILocator GetMaritalStatusButton(string maritalStatus) =>
            _page.GetByTestId("owner.maritalStatus-chip-item-wrapper").Filter(new() { HasText = maritalStatus.Trim() }).First;

        private ILocator MoreOptionsMaritalStatus => _page.Locator("[data-testid*='maritalStatus.value-other']");

        private ILocator GetMoreOptionsValue(string value) =>
            _page.GetByRole(AriaRole.Button, new() { Name = value });
        #endregion

        public async Task WaitForPageReadyAsync()
        {
            await FirstNameInput.WaitForAsync(new() { Timeout = 2000 });
        }

        public async Task ValidateAndFillNameFieldsAsync(ScenarioContextData contextData)
        {
            // First Name: fill only if empty
            var actualFirst = (await FirstNameInput.InputValueAsync())?.Trim();
            if (string.IsNullOrWhiteSpace(actualFirst))
            {
                await FirstNameInput.ClickAsync();
                await FirstNameInput.PressAsync("Control+A");
                await FirstNameInput.PressAsync("Delete");
                await FirstNameInput.FillAsync(contextData.ClientFirstName ?? string.Empty);
            }

            // Middle Name: fill if provided
            if (!string.IsNullOrWhiteSpace(contextData.ClientMiddleName))
            {
                await MiddleNameInput.ClickAsync();
                await MiddleNameInput.PressAsync("Control+A");
                await MiddleNameInput.PressAsync("Delete");
                await MiddleNameInput.FillAsync(contextData.ClientMiddleName);
            }

            // Last Name: fill only if empty
            var actualLast = (await LastNameInput.InputValueAsync())?.Trim();
            if (string.IsNullOrWhiteSpace(actualLast))
            {
                await LastNameInput.ClickAsync();
                await LastNameInput.PressAsync("Control+A");
                await LastNameInput.PressAsync("Delete");
                await LastNameInput.FillAsync(contextData.ClientLastName ?? string.Empty);
            }

            // DOB: fill only if empty
            var actualDobText = (await DateOfBirthInput.InputValueAsync())?.Trim();
            if (string.IsNullOrWhiteSpace(actualDobText))
            {
                var expectedDob = DateTime.Parse(contextData.ClientDOB, CultureInfo.InvariantCulture);
                var expectedDobText = expectedDob.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                await DateOfBirthInput.ClickAsync();
                await DateOfBirthInput.PressAsync("Control+A");
                await DateOfBirthInput.PressAsync("Delete");
                await DateOfBirthInput.FillAsync(expectedDobText);
            }

            // Assertions
            actualFirst = (await FirstNameInput.InputValueAsync())?.Trim();
            actualLast = (await LastNameInput.InputValueAsync())?.Trim();

            if ((contextData.ClientFirstName ?? string.Empty).Trim() != actualFirst)
                throw new Exception($"First Name assertion failed: expected '{contextData.ClientFirstName}', found '{actualFirst}'");

            if ((contextData.ClientLastName ?? string.Empty).Trim() != actualLast)
                throw new Exception($"Last Name assertion failed: expected '{contextData.ClientLastName}', found '{actualLast}'");
        }

        public async Task ValidateAndFillContactFieldsAsync(ScenarioContextData contextData)
        {
            var actualPhone = await BestPhoneInput.InputValueAsync();
            if (!actualPhone.Equals(contextData.ClientPhoneNumber, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Phone mismatch: Expected '{contextData.ClientPhoneNumber}', Found '{actualPhone}'");
                await BestPhoneInput.FillAsync(contextData.ClientPhoneNumber);
            }

            var actualEmail = await EmailAddressInput.InputValueAsync();
            if (!actualEmail.Equals(contextData.ClientEmail, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Email mismatch: Expected '{contextData.ClientEmail}', Found '{actualEmail}'");
                await EmailAddressInput.FillAsync(contextData.ClientEmail);
            }
        }

        public async Task SelectMaritalStatusAsync(string maritalStatus)
        {
            if (!maritalStatus.Equals("Single", StringComparison.OrdinalIgnoreCase) &&
                !maritalStatus.Equals("Married", StringComparison.OrdinalIgnoreCase) &&
                !maritalStatus.Equals("Divorced", StringComparison.OrdinalIgnoreCase))
            {
                await MoreOptionsMaritalStatus.ClickAsync();
                await ClickIfNotSelectedAsync(GetMoreOptionsValue(maritalStatus));
            }
            else
            {
                await GetMaritalStatusButton(maritalStatus).ClickAsync();
            }
        }

        public async Task FillAddressFieldsAsync(ScenarioContextData contextData)
        {
            await StreetAddressInput.FillAsync(contextData.StreetAddress);
            await AptNumberInput.FillAsync(contextData.AptNumber);
            await CityInput.FillAsync(contextData.City);

            await StateDropdown.ClickAsync();
            // Use exact matching to prevent "KANSAS" from matching "ARKANSAS"
            await _page.GetByRole(AriaRole.Option, new() { Name = contextData.State.ToUpper(), Exact = true }).ClickAsync();
            await ZipCodeInput.FillAsync(contextData.ZipCode);
        }

        public async Task WaitForAddressDetailsAsync()
        {
            await _page.WaitForSelectorAsync("[aria-label='Map']", new() { Timeout = 10000 });
        }

        public async Task AnswerMailAndResidenceQuestionsAsync(ScenarioContextData contextData)
        {
            await ClickIfNotSelectedAsync(GetReceivedMailButton(contextData.RecievedMail));
            await ClickIfNotSelectedAsync(GetClientResidesButton(contextData.WhereClientResides));
        }

        public async Task AnswerReceivedMailAsync(ScenarioContextData contextData)
        {
            await ClickIfNotSelectedAsync(GetReceivedMailButton(contextData.RecievedMail));
        }

        public async Task VerifyAddressAndIdentityAsync(ScenarioContextData data)
        {
            await Assertions.Expect(FirstNameInput).ToHaveValueAsync(data.ClientFirstName);
            await Assertions.Expect(LastNameInput).ToHaveValueAsync(data.ClientLastName);
            await Assertions.Expect(DateOfBirthInput).ToHaveValueAsync(data.ClientDOB);
            await Assertions.Expect(MiddleNameInput).ToHaveValueAsync(data.ClientMiddleName);
            await Assertions.Expect(BestPhoneInput).ToHaveValueAsync(data.ClientPhoneNumber);
            await Assertions.Expect(EmailAddressInput).ToHaveValueAsync(data.ClientEmail);
            await Assertions.Expect(StreetAddressInput).ToHaveValueAsync(data.StreetAddress);
            await Assertions.Expect(AptNumberInput).ToHaveValueAsync(data.AptNumber);
            await Assertions.Expect(CityInput).ToHaveValueAsync(data.City);
            await Assertions.Expect(ZipCodeInput).ToHaveValueAsync(data.ZipCode);
        }
    }
}
