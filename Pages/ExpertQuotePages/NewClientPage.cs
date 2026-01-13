
// Pages/NewClientPage.cs
using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Locators;

namespace Playwright_POC.Pages
{
    public class NewClientPage
    {
        private readonly IPage _page;

        public NewClientPage(IPage page)
        {
            _page = page;
        }


        public async Task WaitForFirstNameInputAsync()
        {
            await _page.WaitForSelectorAsync(NewExistingClientSearchLocators.FirstNameInput, new() { Timeout = 2000 });
        }

        public async Task FillFirstNameAsync(string firstName)
        {
            await _page.FillAsync(NewExistingClientSearchLocators.FirstNameInput, firstName);
        }

        public async Task FillLastNameAsync(string lastName)
        {
            var currentValue = await _page.InputValueAsync(NewExistingClientSearchLocators.LastNameInput);
            if (!currentValue.Equals(lastName))
            {

                // Clear the field first
                await _page.FillAsync(NewExistingClientSearchLocators.LastNameInput, "");
                // Then fill with the new value
                await _page.FillAsync(NewExistingClientSearchLocators.LastNameInput, lastName);
            }
            
        }

        public async Task FillDOBAsync(string dob)
        {
            await _page.FillAsync(NewExistingClientSearchLocators.DateOfBirthInput, dob);
        }

        public async Task FillBestPhoneAsync(string phone)
        {
            await _page.FillAsync(NewExistingClientSearchLocators.BestPhoneInput, phone);
        }

        public async Task FillEmailAsync(string email)
        {
            await _page.FillAsync(NewExistingClientSearchLocators.EmailAddressInput, email);
        }

        public async Task ClickSearchAsync()
        {
            await _page.ClickAsync(NewExistingClientSearchLocators.SearchButton);
        }

        public async Task WaitForNextButtonAsync()
        {
            await _page.WaitForSelectorAsync(GlobalLocators.NextButton, new() { Timeout = 10000 });
        }

        public async Task ClickCreateNewClientAsync()
        {
            await _page.ClickAsync(NewExistingClientSearchLocators.CreateNewClientButton);
        }

        public async Task ClickNextAsync()
        {
            await _page.ClickAsync(GlobalLocators.NextButton);
        }

        public async Task WaitForAccountInfoPageAsync()
        {
            await _page.WaitForLoadStateAsync(LoadState.Load);
            await _page.WaitForSelectorAsync(AccountInformationConstLocators.PageHeader, new() { Timeout = 10000 });
        }


    }
}
