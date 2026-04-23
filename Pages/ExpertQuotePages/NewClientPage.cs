// Pages/NewClientPage.cs
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Playwright_POC.Pages
{
    public class NewClientPage
    {
        private readonly IPage _page;

        public NewClientPage(IPage page)
        {
            _page = page;
        }

        #region Locators
        // New/Existing Client Search locators - moved from NewExistingClientSearchLocators
        private ILocator FirstNameInput => _page.Locator("input[name='customer.name.first']");
        private ILocator LastNameInput => _page.Locator("input[name='customer.name.last']");
        private ILocator DateOfBirthInput => _page.Locator("input[name='customer.dateOfBirth']");
        private ILocator BestPhoneInput => _page.Locator("input[name='customer.phone']");
        private ILocator EmailAddressInput => _page.Locator("input[name='customer.email']");
        private ILocator SearchButton => _page.GetByRole(AriaRole.Button, new() { Name = "Search" });
        private ILocator CreateNewClientButton => _page.GetByText("Create New Client", new() { Exact = true });
        
        // Global locators used in this page
        private ILocator NextButton => _page.GetByTestId("next");
        private ILocator AccountInfoPageHeader => _page.Locator("//h1[text()='Account Information']");
        #endregion

        public async Task WaitForFirstNameInputAsync()
        {
            await FirstNameInput.WaitForAsync(new() { Timeout = 2000 });
        }

        public async Task FillFirstNameAsync(string firstName)
        {
            await FirstNameInput.FillAsync(firstName);
        }

        public async Task FillLastNameAsync(string lastName)
        {
            var currentValue = await LastNameInput.InputValueAsync();
            if (!currentValue.Equals(lastName))
            {
                // Clear the field first
                await LastNameInput.FillAsync("");
                // Then fill with the new value
                await LastNameInput.FillAsync(lastName);
            }
        }

        public async Task FillDOBAsync(string dob)
        {
            await DateOfBirthInput.FillAsync(dob);
        }

        public async Task FillBestPhoneAsync(string phone)
        {
            await BestPhoneInput.FillAsync(phone);
        }

        public async Task FillEmailAsync(string email)
        {
            await EmailAddressInput.FillAsync(email);
        }

        public async Task ClickSearchAsync()
        {
            await SearchButton.ClickAsync();
        }

        public async Task WaitForNextButtonAsync()
        {
            await NextButton.WaitForAsync(new() { Timeout = 10000 });
        }

        public async Task ClickCreateNewClientAsync()
        {
            await CreateNewClientButton.ClickAsync();
        }

        public async Task ClickNextAsync()
        {
            await NextButton.ClickAsync();
        }

        public async Task WaitForAccountInfoPageAsync()
        {
            await _page.WaitForLoadStateAsync(LoadState.Load);
            await AccountInfoPageHeader.WaitForAsync(new() { Timeout = 10000 });
        }
    }
}
