using Microsoft.Playwright;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PnCTestAutomation.Pages.ExpertQuotePages
{
    public class SFP_ClientDetailsPage : BasePage
    {
        public SFP_ClientDetailsPage(IPage page) : base(page) { }

        // These checkboxes use data-testid on a plain <input class="checkbox-input">.
        // Pattern: "Inspection Contact" → data-testid="fields.primaryInsured.accountInput$isInspectionContact.value"
        //          "Audit Contact"      → data-testid="fields.primaryInsured.accountInput$isAuditContact.value"
        private ILocator GetContactRoleCheckbox(string role)
        {
            var key = string.Concat(
                role.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(w => char.ToUpper(w[0]) + w.Substring(1)));
            return _page.Locator($"input[data-testid='fields.primaryInsured.accountInput$is{key}.value']");
        }

        /// <summary>
        /// Checks a contact role checkbox. Returns true if found and checked, false otherwise.
        /// </summary>
        public async Task<bool> SelectContactRoleAsync(string contactRole)
        {
            await WaitForSpinnerAsync();
            var input = GetContactRoleCheckbox(contactRole);
            try
            {
                await input.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 15000 });

                if (!await input.IsCheckedAsync())
                    await input.CheckAsync();

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
