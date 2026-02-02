// Pages/LoginPage.cs
using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Locators;

namespace Playwright_POC.Pages
{
    public class ExpertQuoteLoginPage
    {
        private readonly IPage _page;

        public ExpertQuoteLoginPage(IPage page)
        {
            _page = page;
        }

        public async Task LoginAsync(string username, string password)
        {
            await LoginLocators.UsernameInput(_page).FillAsync(username);
            await LoginLocators.PasswordInput(_page).FillAsync(password);
            await LoginLocators.LoginButton(_page).ClickAsync();

            // Wait for login to complete
            var dashboardLocator = ClientSearchLocators.NewQuoteButton(_page);
            await dashboardLocator.WaitForAsync(new() { State = WaitForSelectorState.Visible });
        }

        public async Task<bool> IsDashboardVisibleAsync()
        {
            return await ClientSearchLocators.NewQuoteButton(_page).IsVisibleAsync();
        }
    }
}
