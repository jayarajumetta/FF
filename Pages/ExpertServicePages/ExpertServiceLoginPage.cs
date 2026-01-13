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
            await _page.FillAsync(LoginLocators.UsernameInput, username);
            await _page.FillAsync(LoginLocators.PasswordInput, password);
            await _page.ClickAsync(LoginLocators.LoginButton);

            // Wait for login to complete
            await _page.WaitForSelectorAsync(ClientSearchLocators.DashboardElement, new PageWaitForSelectorOptions { Timeout = 8000 });
        }

        public async Task<bool> IsDashboardVisibleAsync()
        {
            return await _page.IsVisibleAsync(ClientSearchLocators.DashboardElement);
        }
    }
}
