using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;


namespace Playwright_POC.Helpers
{
    internal class Helpers
    {
        // ✅ Old version: keep it for legacy string selectors (xpath/css)
        public static async Task ClickIfNotSelectedAsync(IPage page, string selector)
        {
            var locator = page.Locator(selector);
            await ClickIfNotSelectedAsync(locator);
        }

        // ✅ New version: works with GetBy... because it accepts ILocator
        public static async Task ClickIfNotSelectedAsync(ILocator locator)
        {
            // Option 1: Your original logic (Angular Material toggle selected class)
            bool isSelected = await locator.EvaluateAsync<bool>(
                "el => el.classList.contains('mat-button-toggle-checked')"
            );

            if (!isSelected)
                await locator.ClickAsync();
        }


        public static async Task ClickNextAsync(IPage page)
        {
            var candidates = new[]
            {
        page.GetByTestId("fields.data.next"),
        page.GetByTestId("fields.data-Next.next"),
        page.GetByTestId("next"),
        page.GetByRole(AriaRole.Button, new() { Name = "Next" })
    };

            foreach (var candidate in candidates)
            {
                if (await candidate.CountAsync() > 0 && await candidate.First.IsVisibleAsync())
                {
                    await candidate.First.ClickAsync();
                    return;
                }
            }

            throw new PlaywrightException("Next button not found using any known data-testid.");
        }



        public static async Task WaitForSpinnerToClearAsync(IPage page, int timeoutMs = 60000)
        {
            // Covers common ngx-spinner overlay patterns
            var overlay = page.Locator(".ngx-spinner-overlay");

            // If it exists, wait for it to be hidden (display:none/opacity/removed)
            if (await overlay.CountAsync() > 0)
            {
                await overlay.First.WaitForAsync(new() { State = WaitForSelectorState.Hidden, Timeout = timeoutMs });
            }


        }
    }
}

