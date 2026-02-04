using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.Playwright;


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
        page.GetByTestId("next")
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

    }
}

