using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace Playwright_POC.Pages.ExpertQuotePages
{
    public class SFP_ClientDetailsPage : BasePage
    {
        public SFP_ClientDetailsPage(IPage page) : base(page) { }

        #region Locators
        private ILocator GetContactRoleCheckbox(string role) => _page.Locator($"mat-checkbox:has-text('{role}')");
        private ILocator GetContactRoleLabel(string role) => _page.Locator($"label:has-text('{role}')");
        #endregion

        #region Actions
        /// <summary>
        /// Selects a contact role checkbox (e.g., "Inspection Contact", "Audit Contact")
        /// </summary>
        public async Task SelectContactRoleAsync(string contactRole)
        {
            var checkbox = GetContactRoleCheckbox(contactRole);
            var label = GetContactRoleLabel(contactRole);

            if (await checkbox.CountAsync() > 0)
            {
                await checkbox.ClickAsync();
            }
            else if (await label.CountAsync() > 0)
            {
                await label.ClickAsync();
            }
            else
            {
                Console.WriteLine($"WARNING: {contactRole} checkbox not found - skipping");
            }
        }

        /// <summary>
        /// Legacy method for backward compatibility
        /// </summary>
        public async Task CheckInspectionContactAsync() => await SelectContactRoleAsync("Inspection Contact");
        #endregion
    }
}
