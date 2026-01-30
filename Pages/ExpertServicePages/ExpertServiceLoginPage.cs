// Pages/LoginPage.cs
using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Locators;

namespace Playwright_POC.Pages
{
    public class ExpertServiceLoginPage
    {
        private readonly IPage _page;

        public ExpertServiceLoginPage(IPage page)
        {
            _page = page;
        }

        public async Task LoginAsync(string username, string password)
        {
            await LoginLocators.UsernameInput(_page).FillAsync(username);
            await LoginLocators.PasswordInput(_page).FillAsync(password);
            await LoginLocators.LoginButton(_page).ClickAsync();

            // Wait for login to complete
            await ClientSearchLocators.DashboardElement(_page).WaitForAsync(new LocatorWaitForOptions { Timeout = 8000 });
        }

        public async Task<bool> IsDashboardVisibleAsync()
        {
            return await ClientSearchLocators.DashboardElement(_page).IsVisibleAsync();
        }
    }
}
