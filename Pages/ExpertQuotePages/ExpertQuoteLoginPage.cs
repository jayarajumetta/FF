// Pages/LoginPage.cs
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using Playwright_POC.Locators;
using Playwright_POC.Helpers;

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
            await _page.FillAsync(LoginLocators.UsernameInput, username);
            await _page.FillAsync(LoginLocators.PasswordInput, password);
            await _page.ClickAsync(LoginLocators.LoginButton);

            // Wait for page to fully load after login
            await WaitForDashboardAsync();
        }

        private async Task WaitForDashboardAsync()
        {
            // Wait for network to be idle (no pending requests)
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = 60000 });
            
            // Wait for any Angular spinner to disappear
            await LoadingHelpers.WaitForAngularSpinnerAsync(_page);
            
            // Then wait for the dashboard element with extended timeout
            await _page.WaitForSelectorAsync(
                ClientSearchLocators.DashboardElement, 
                new PageWaitForSelectorOptions 
                { 
                    State = WaitForSelectorState.Visible,
                    Timeout = 60000 
                });
        }

        public async Task<bool> IsDashboardVisibleAsync()
        {
            return await _page.IsVisibleAsync(ClientSearchLocators.DashboardElement);
        }
    }
}
