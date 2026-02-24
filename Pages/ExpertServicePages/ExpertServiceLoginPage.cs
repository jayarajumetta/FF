using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Helpers;
using Playwright_POC.Pages;

namespace Playwright_POC.Pages.ExpertServicePages
{
    public class ExpertServiceLoginPage : BasePage
    {
        public ExpertServiceLoginPage(IPage page) : base(page) { }

        #region Locators
        private ILocator UsernameInput => _page.GetByTestId("login-username-input");
        private ILocator PasswordInput => _page.GetByTestId("login-password-input");
        private ILocator LoginButton => _page.GetByTestId("login-submit-button");
        private ILocator DashboardElement => _page.GetByTestId("dashboard-container");
        #endregion

        public async Task LoginAsync(string username, string password)
        {
            await UsernameInput.FillAsync(username);
            await PasswordInput.FillAsync(password);
            await LoginButton.ClickAsync();

            // Wait for login to complete
            await DashboardElement.WaitForAsync(new LocatorWaitForOptions { Timeout = 8000 });
        }

        public async Task<bool> IsDashboardVisibleAsync()
        {
            return await DashboardElement.IsVisibleAsync();
        }
    }
}
