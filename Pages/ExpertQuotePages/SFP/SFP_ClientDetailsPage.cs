using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace Playwright_POC.Pages.ExpertQuotePages
{
    public class SFP_ClientDetailsPage : BasePage
    {
        public SFP_ClientDetailsPage(IPage page) : base(page) { }

        // mat-checkbox hides the native <input> with CSS — cannot click/check it directly.
        // The visible clickable surface is the <label> inside mat-checkbox.
        private ILocator GetContactRoleLabel(string role) =>
            _page.Locator($"mat-checkbox:has-text('{role}') label");

        private ILocator GetContactRoleCheckbox(string role) =>
            _page.Locator($"mat-checkbox:has-text('{role}') input[type='checkbox']");

        /// <summary>
        /// Checks a contact role checkbox. Returns true if found and checked, false otherwise.
        /// </summary>
        public async Task<bool> SelectContactRoleAsync(string contactRole)
        {
            await WaitForSpinnerAsync();
            var input = GetContactRoleCheckbox(contactRole);
            var label = GetContactRoleLabel(contactRole);
            try
            {
                // Wait for the input to be in the DOM (it is CSS-hidden, so use Attached not Visible)
                await input.First.WaitForAsync(new() { State = WaitForSelectorState.Attached, Timeout = 15000 });

                // Only click if not already checked
                var isChecked = await input.First.IsCheckedAsync();
                if (!isChecked)
                {
                    await label.First.ScrollIntoViewIfNeededAsync();
                    await label.First.ClickAsync();
                }

                Console.WriteLine($"[ClientDetails] '{contactRole}' checkbox checked.");
                return true;
            }
            catch (TimeoutException)
            {
                Console.WriteLine($"[ClientDetails] WARNING: '{contactRole}' checkbox not found — skipping.");
                return false;
            }
        }
    }
}
