using System;
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
        // PingFederate SSO login (QA Express)
        private ILocator PfUsernameInput => _page.Locator("input[name='pf.username']");
        private ILocator PfPasswordInput => _page.Locator("input[name='pf.pass']");
        private ILocator PfLoginButton => _page.Locator("a[id*='signInBtn']");
        private ILocator ApplicationButton => _page.Locator("button div:has-text('Application')");

        // DuckCreek ExtJS login (CLAS Express)
        private ILocator DctUsernameInput => _page.Locator("input[name='_username']");
        private ILocator DctPasswordInput => _page.Locator("input[name='_password']");
        private ILocator DctLoginButton => _page.Locator("#home a");
        private ILocator SearchBarInput => _page.Locator("input[fieldref='PolicyHeaderInput.SearchText']");
        #endregion

        /// <summary>
        /// Exposes the default view model element for Playwright Expect assertions
        /// </summary>
        public ILocator DefaultViewModelElement => ApplicationButton;

        public async Task ExpressLoginAsync(string username, string password)
        {
            // Wait for either login form to appear (CLAS vs QA Express)
            var either = _page.Locator("input[name='_username'], input[name='pf.username']");
            await either.First.WaitForAsync(new() { Timeout = 30000 });

            if (await DctUsernameInput.IsVisibleAsync())
            {
                // DuckCreek ExtJS login (CLAS Express)
                Console.WriteLine("[ExpressLogin] DuckCreek ExtJS login detected");
                await DctUsernameInput.FillAsync(username);
                await DctPasswordInput.FillAsync(password);
                await DctLoginButton.ClickAsync();

                // DEV environment may be slower - wait for navigation and DOM to settle
                Console.WriteLine("[ExpressLogin] Waiting for post-login navigation...");
                await _page.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = 90000 });
                await Task.Delay(2000); // Allow ExtJS to fully initialize

                // Verify the search input appears
                try
                {
                    await SearchBarInput.WaitForAsync(new() { Timeout = 90000 });
                    Console.WriteLine("[ExpressLogin] CLAS homepage loaded successfully - search input visible");
                }
                catch (TimeoutException ex)
                {
                    Console.WriteLine($"[ExpressLogin] ERROR: Search input not visible after 90s. Current URL: {_page.Url}");
                    // Take a screenshot for debugging
                    var screenshotPath = $"clas_login_timeout_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                    await _page.ScreenshotAsync(new() { Path = screenshotPath });
                    Console.WriteLine($"[ExpressLogin] Screenshot saved: {screenshotPath}");
                    throw new TimeoutException($"CLAS homepage did not load after login. Search input not found. Current URL: {_page.Url}", ex);
                }
            }
            else
            {
                // PingFederate SSO login (QA Express)
                Console.WriteLine("[ExpressLogin] PingFederate SSO login detected");
                await PfUsernameInput.FillAsync(username);
                await PfPasswordInput.FillAsync(password);
                await PfLoginButton.ClickAsync();
                await ApplicationButton.WaitForAsync(new() { Timeout = 60000 });
            }
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
