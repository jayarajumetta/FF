
using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Locators;

namespace TestAutomation.Pages.ExpressPages
{
    public class ExpressLoginPage
    {
        private readonly IPage _page;

        public ExpressLoginPage(IPage page) => _page = page;

        /// <summary>
        /// Exposes the default view model element for Playwright Expect assertions
        /// </summary>
        public ILocator DefaultViewModelElement => _page.Locator(ExpressDashboardConstLocators.ApplicationButton);

        public async Task ExpressLoginAsync(string username, string password)
        {
            // Wait for fields to be present before filling
            await _page.Locator(ExpressLoginConstLocators.UsernameInput).WaitForAsync(new() { Timeout = 30000 });
            await _page.FillAsync(ExpressLoginConstLocators.UsernameInput, username);
            await _page.FillAsync(ExpressLoginConstLocators.PasswordInput, password);
            await _page.ClickAsync(ExpressLoginConstLocators.LoginButton);

            // Wait for a reliable post-login element
            await _page.WaitForSelectorAsync(
                ExpressDashboardConstLocators.ApplicationButton,
                new() { Timeout = 60000 }  
            );
        }

        // Optional: expose a verification helper if your step wants to assert
        public async Task<bool> IsDefaultViewModelVisibleAsync()
        {
            try
            {
                await _page.WaitForSelectorAsync(
                    ExpressDashboardConstLocators.ApplicationButton,
                    new() { Timeout = 60000 }
                );
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
