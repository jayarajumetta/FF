using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace Playwright_POC.Pages.ExpertQuotePages
{
    public class SFP_ClientDetailsPage : BasePage
    {
        public SFP_ClientDetailsPage(IPage page) : base(page) { }

        private ILocator GetContactRoleCheckbox(string role) => _page.Locator($"mat-checkbox:has-text('{role}')");

        /// <summary>
        /// Clicks a contact role checkbox. Returns true if found and clicked, false otherwise.
        /// </summary>
        public async Task<bool> SelectContactRoleAsync(string contactRole)
        {
            var checkbox = GetContactRoleCheckbox(contactRole);
            try
            {
                await checkbox.First.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 10000 });
                await checkbox.First.ClickAsync();
                return true;
            }
            catch (TimeoutException)
            {
                Console.WriteLine($"WARNING: '{contactRole}' checkbox not found — skipping.");
                return false;
            }
        }
    }
}
