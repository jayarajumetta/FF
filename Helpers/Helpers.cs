using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static Microsoft.Playwright.Assertions;


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

        public static async Task ClickSaveAsync(IPage page)
        {
            var candidates = new[]
            {
                page.GetByTestId("fields.data_Actions.save"),
                page.GetByTestId("fields.data_Next.saveLocation"),

            };

            foreach (var candidate in candidates)
            {
                if (await candidate.CountAsync() > 0 && await candidate.First.IsVisibleAsync())
                {
                    await candidate.First.ClickAsync();
                    return;
                }
            }

            throw new PlaywrightException("Save button not found using any known data-testid.");
        }

        // Dropdown handling
        public static async Task SelectByTextAsync(IPage page, ILocator matSelect, string optionText, int timeoutMs = 30000, bool blurAfterSelect = true)
        {
            var value = (optionText ?? "").Trim();

            await Expect(matSelect).ToBeVisibleAsync(new() { Timeout = timeoutMs });
            await Expect(matSelect).ToBeEnabledAsync(new() { Timeout = timeoutMs });
            await Expect(matSelect).ToHaveCountAsync(1, new() { Timeout = timeoutMs });


            var clickTarget = matSelect.Locator(".mat-select-trigger, .mat-mdc-select-trigger").First;
            if (await clickTarget.CountAsync() == 0)
                clickTarget = matSelect;

            await clickTarget.ScrollIntoViewIfNeededAsync();
            await page.WaitForTimeoutAsync(3000);
            await clickTarget.ClickAsync(new() { Timeout = timeoutMs });

            var panelId = await matSelect.GetAttributeAsync("aria-controls") ?? await clickTarget.GetAttributeAsync("aria-controls");

            var panel = page.Locator($"[id=\"{panelId.Replace("\"", "\\\"")}\"]");
            await Expect(panel).ToBeVisibleAsync(new() { Timeout = timeoutMs });

            await page.WaitForTimeoutAsync(3000);
            // Select option inside overlay - use Exact match to avoid partial matches (e.g., KANSAS vs ARKANSAS)
            var option = page
                .GetByRole(AriaRole.Listbox)
                .GetByRole(AriaRole.Option, new() { Name = value, Exact = true });


            await option.ScrollIntoViewIfNeededAsync();
            await Expect(option).ToBeVisibleAsync(new() { Timeout = timeoutMs });
            await option.EvaluateAsync("el => el.click()"); // Use native click to avoid Playwright's scroll/hover logic which can cause issues in overlays
            // await option.ClickAsync(new() { Timeout = timeoutMs });

            await page.WaitForTimeoutAsync(3000);

            await Expect(panel).ToBeHiddenAsync(new() { Timeout = timeoutMs });

            if (blurAfterSelect)
                await page.Keyboard.PressAsync("Tab");

            var displayed = await GetDisplayedMatSelectValueLocatorAsync(page, matSelect);
            await Expect(displayed).Not.ToBeEmptyAsync(new() { Timeout = timeoutMs });
        }

        private static async Task<ILocator> GetDisplayedMatSelectValueLocatorAsync(IPage page, ILocator matSelect)
        {
            // Try aria-labelledby
            var labelledBy = (await matSelect.GetAttributeAsync("aria-labelledby")) ??
                string.Empty;

            var id = labelledBy
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .FirstOrDefault(s => s.StartsWith("mat-select-value", StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(id))
                return page.Locator($"#{id}");

            return matSelect.Locator(".mat-select-trigger, .mat-mdc-select-trigger").First;
        }

        public static Task SelectByTestIdAsync(IPage page, string testId, string optionText, int timeoutMs = 30000)
        {
            var matSelect = page.Locator($"mat-select[data-testid='{testId}']");
            return SelectByTextAsync(page, matSelect, optionText, timeoutMs);
        }


        // Button selection handling
        public static async Task SelectButtonAsync(
            IPage page,
            ILocator scope,
            string value,
            ILocator moreOptionsButton,
            int timeoutMs = 30000)
        {
            var target = (value ?? "").Trim();

            var button = scope.GetByRole(AriaRole.Button, new() { Name = target, Exact = true });

            if (await button.CountAsync() > 0 && await button.First.IsVisibleAsync())
            {
                await Expect(button.First).ToBeEnabledAsync(new() { Timeout = timeoutMs });
                await button.First.ScrollIntoViewIfNeededAsync();
                await button.First.ClickAsync(new() { Timeout = timeoutMs });
                return;
            }

            // The 'More Options' overflow button may not be present in all states. If it is not
            // visible, skip rather than fail — the deductible option simply isn't available/needed.
            if (await moreOptionsButton.CountAsync() == 0 || !await moreOptionsButton.IsVisibleAsync())
            {
                System.Console.WriteLine($"[SelectButton] '{target}' not found as a chip and 'More Options' is not visible — skipping selection.");
                return;
            }
            await Expect(moreOptionsButton).ToBeEnabledAsync(new() { Timeout = timeoutMs });
            await moreOptionsButton.ScrollIntoViewIfNeededAsync();
            await moreOptionsButton.ClickAsync(new() { Timeout = timeoutMs });

            var menuPanel = page.Locator(".cdk-overlay-pane .mat-menu-panel, .cdk-overlay-pane .mat-mdc-menu-panel").Last;
            await Expect(menuPanel).ToBeVisibleAsync(new() { Timeout = timeoutMs });

            var menuItem = menuPanel.GetByRole(AriaRole.Menuitem, new LocatorGetByRoleOptions { Name = target, Exact = true });

            await Expect(menuItem.First).ToBeVisibleAsync(new() { Timeout = timeoutMs });
            await menuItem.First.ClickAsync(new() { Timeout = timeoutMs });

            await Expect(menuPanel).ToBeHiddenAsync(new() { Timeout = timeoutMs });

        }

    }
}

