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

        /// <summary>Checks the requested contact role and fails with page diagnostics if it is unavailable.</summary>
        public async Task<bool> SelectContactRoleAsync(string contactRole)
        {
            await WaitForSpinnerAsync();
            await ThrowIfQuoteErrorAsync($"selecting Client Details role '{contactRole}'");
            var input = GetContactRoleCheckbox(contactRole);
            try
            {
                await input.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 15000 });

                if (!await input.IsCheckedAsync())
                    await input.CheckAsync();

                Console.WriteLine($"[ClientDetails] '{contactRole}' checkbox checked.");
                return true;
            }
            catch (TimeoutException ex)
            {
                await ThrowIfQuoteErrorAsync($"waiting for Client Details role '{contactRole}'");
                throw new PlaywrightException(
                    $"[ClientDetails] Required '{contactRole}' checkbox was not available. " +
                    $"{await BuildPageDiagnosticsAsync()}", ex);
            }
        }
    }
}
