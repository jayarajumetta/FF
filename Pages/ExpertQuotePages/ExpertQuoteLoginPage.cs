// Pages/ExpertQuotePages/ExpertQuoteLoginPage.cs
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Playwright_POC.Pages
{
    /// <summary>
    /// Page Object for ExpertQuote Login / Ping SSO page
    /// All locators are encapsulated within this class (proper POM pattern)
    /// </summary>
    public class ExpertQuoteLoginPage : BasePage
    {
        public ExpertQuoteLoginPage(IPage page) : base(page) { }

        // ══════════════════════════════════════════════════════════════════
        // LOCATORS (private - only this page needs to know about these)
        // ══════════════════════════════════════════════════════════════════

        private ILocator UsernameInput => _page.GetByPlaceholder("Username");
        private ILocator PasswordInput => _page.GetByPlaceholder("Password");
        private ILocator SignOnButton => _page.GetByTitle("Sign On");
        
        // Dashboard indicator - confirms login was successful
        private ILocator NewQuoteButton => _page.GetByRole(AriaRole.Button, new() { Name = "New Quote" });

        // ══════════════════════════════════════════════════════════════════
        // PUBLIC METHODS (actions available to tests)
        // ══════════════════════════════════════════════════════════════════

        /// <summary>
        /// Perform login with username and password, wait for dashboard
        /// </summary>
        public async Task LoginAsync(string username, string password)
        {
            await UsernameInput.FillAsync(username);
            await PasswordInput.FillAsync(password);

            // The Ping SSO redirect chain (login → Ping → OAuth callback → dashboard) can
            // take well over 30s on slow QA environments. Temporarily raise the navigation
            // timeout for this page so the click's built-in navigation wait doesn't expire.
            _page.SetDefaultNavigationTimeout(120000);
            await SignOnButton.ClickAsync();

            // Wait for login to complete - dashboard should be visible
            await NewQuoteButton.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 120000 });
        }

        /// <summary>
        /// Check if user is on the dashboard (logged in)
        /// </summary>
        public async Task<bool> IsDashboardVisibleAsync()
        {
            return await NewQuoteButton.IsVisibleAsync();
        }

        /// <summary>
        /// Wait for the login page to be ready for input
        /// </summary>
        public async Task WaitForLoginPageAsync()
        {
            await UsernameInput.WaitForAsync(new() { State = WaitForSelectorState.Visible });
        }
    }
}
