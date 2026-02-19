using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace Playwright_POC.Helpers
{
    public class Helpers
    {
        /// <summary>
        /// Legacy string selector version. Prefer BasePage.ClickIfNotSelectedAsync with ILocator.
        /// </summary>
        [Obsolete("Use page object methods via BasePage instead. This will be removed in a future release.")]
        public static async Task ClickIfNotSelectedAsync(IPage page, string selector)
        {
            var locator = page.Locator(selector);
            await ClickIfNotSelectedAsync(locator);
        }

        /// <summary>
        /// Works with GetBy locators. Prefer page object methods via BasePage.
        /// </summary>
        [Obsolete("Use page object methods via BasePage instead. This will be removed in a future release.")]
        public static async Task ClickIfNotSelectedAsync(ILocator locator)
        {
            // Angular Material toggle selected class check
            bool isSelected = await locator.EvaluateAsync<bool>(
                "el => el.classList.contains('mat-button-toggle-checked')"
            );

            if (!isSelected)
                await locator.ClickAsync();
        }


        /// <summary>
        /// Clicks the Next button using testId fallbacks. Prefer page object methods via BasePage.
        /// </summary>
        [Obsolete("Use page object ClickNextAsync() via BasePage instead. This will be removed in a future release.")]
        public static async Task ClickNextAsync(IPage page)
        {
            var candidates = new[]
            {
                page.GetByTestId("fields.data.next"),
                page.GetByTestId("fields.data-Next.next"),
                page.GetByTestId("fields.data_Rules.next"),
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



        /// <summary>
        /// Waits for ngx-spinner overlay to clear. Prefer BasePage.WaitForSpinnerAsync().
        /// </summary>
        [Obsolete("Use page object WaitForSpinnerAsync() via BasePage instead. This will be removed in a future release.")]
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

        [Obsolete("Use page object Yes/No methods. This will be removed in a future release.")]
        public static class UiToggleHelpers
        {
            /// <summary>
            /// Clicks Yes/No toggle buttons. Prefer page-specific methods.
            /// </summary>
            public static async Task ClickYesNoAsync(
                IPage page,
                string testId,
                bool yes)
            {
                var value = yes ? "Yes" : "No";

                var button = page.Locator(
                    $"button[data-testid^='{testId}'] >> text={value}"
                );

                await button.ClickAsync();
#pragma warning disable CS0618 // Type or member is obsolete
                await Helpers.WaitForSpinnerToClearAsync(page);
#pragma warning restore CS0618
            }
        }

    }
}

