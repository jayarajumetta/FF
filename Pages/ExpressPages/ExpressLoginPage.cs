using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Helpers;
using Playwright_POC.Pages;

namespace Playwright_POC.Pages.ExpressPages
{
    public class ExpressLoginPage : BasePage
    {
        public ExpressLoginPage(IPage page) : base(page) { }

        #region Locators
        private ILocator UsernameInput => _page.Locator("input[name='pf.username']");
        private ILocator PasswordInput => _page.Locator("input[name='pf.pass']");
        private ILocator LoginButton => _page.Locator("a[id*='signInBtn']");
        private ILocator ApplicationButton => _page.Locator("button div:has-text('Application')");
        #endregion

        /// <summary>
        /// Exposes the default view model element for Playwright Expect assertions
        /// </summary>
        public ILocator DefaultViewModelElement => ApplicationButton;

        public async Task ExpressLoginAsync(string username, string password)
        {
            await UsernameInput.WaitForAsync(new() { Timeout = 30000 });
            await UsernameInput.FillAsync(username);
            await PasswordInput.FillAsync(password);
            await LoginButton.ClickAsync();

            await ApplicationButton.WaitForAsync(new() { Timeout = 60000 });
        }

        public async Task<bool> IsDefaultViewModelVisibleAsync()
        {
            try
            {
                await ApplicationButton.WaitForAsync(new() { Timeout = 60000 });
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
