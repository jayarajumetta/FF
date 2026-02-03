// Pages/ExpertQuoteLoginPage.cs
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Playwright_POC.Pages
{
    public class ExpertQuoteLoginPage
    {
        private readonly IPage _page;

        public ExpertQuoteLoginPage(IPage page)
        {
            _page = page;
        }

        #region Locators
        // Login locators - moved from LoginLocators static class
        private ILocator UsernameInput => _page.GetByPlaceholder("Username");
        private ILocator PasswordInput => _page.GetByPlaceholder("Password");
        private ILocator LoginButton => _page.GetByTitle("Sign On");
        
        // Dashboard element for login verification - moved from ClientSearchLocators
        public ILocator DashboardElement => _page.Locator("strong").GetByText("Quote", new() { Exact = true }).First;
        #endregion

        public async Task LoginAsync(string username, string password)
        {
            await UsernameInput.FillAsync(username);
            await PasswordInput.FillAsync(password);
            await LoginButton.ClickAsync();

            // Wait for login to complete
            await DashboardElement.WaitForAsync(new LocatorWaitForOptions { Timeout = 30000 });
        }

        public async Task<bool> IsDashboardVisibleAsync()
        {
            return await DashboardElement.IsVisibleAsync();
        }
    }
}
