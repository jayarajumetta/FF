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
            await NewExistingClientSearchLocators.FirstNameInput(_page).WaitForAsync(new() { Timeout = 2000 });
        }

        public async Task FillFirstNameAsync(string firstName)
        {
            await NewExistingClientSearchLocators.FirstNameInput(_page).FillAsync(firstName);
        }

        public async Task FillLastNameAsync(string lastName)
        {
            var currentValue = await NewExistingClientSearchLocators.LastNameInput(_page).InputValueAsync();
            if (!currentValue.Equals(lastName))
            {

                // Clear the field first
                await NewExistingClientSearchLocators.LastNameInput(_page).FillAsync("");
                // Then fill with the new value
                await NewExistingClientSearchLocators.LastNameInput(_page).FillAsync(lastName);
            }
            
        }

        public async Task FillDOBAsync(string dob)
        {
            await NewExistingClientSearchLocators.DateOfBirthInput(_page).FillAsync(dob);
        }

        public async Task FillBestPhoneAsync(string phone)
        {
            await NewExistingClientSearchLocators.BestPhoneInput(_page).FillAsync(phone);
        }

        public async Task FillEmailAsync(string email)
        {
            await NewExistingClientSearchLocators.EmailAddressInput(_page).FillAsync(email);
        }

        public async Task ClickSearchAsync()
        {
            await NewExistingClientSearchLocators.SearchButton(_page).ClickAsync();
        }

        public async Task WaitForNextButtonAsync()
        {
            await GlobalLocators.NextButton(_page).WaitForAsync(new() { Timeout = 10000 });
        }

        public async Task ClickCreateNewClientAsync()
        {
            await NewExistingClientSearchLocators.CreateNewClientButton(_page).ClickAsync();
        }

        public async Task ClickNextAsync()
        {
            await GlobalLocators.NextButton(_page).ClickAsync();
        }

        public async Task WaitForAccountInfoPageAsync()
        {
            await _page.WaitForLoadStateAsync(LoadState.Load);
            await AccountInformationConstLocators.PageHeader(_page).WaitForAsync(new() { Timeout = 10000 });
        }


    }
}
