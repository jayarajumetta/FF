using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace Playwright_POC.Helpers
{
    /// <summary>
    /// Helper methods for handling loading states and overlays.
    /// Useful for Angular apps with ngx-spinner or similar loading indicators.
    /// </summary>
    public static class LoadingHelpers
    {
        /// <summary>
        /// Waits for Angular ngx-spinner to disappear.
        /// Handles both cases: spinner appears and disappears, or spinner never appears.
        /// </summary>
        public static async Task WaitForAngularSpinnerAsync(IPage page, int timeoutMs = 30000)
        {
            var spinnerLocator = page.Locator(".ngx-spinner-overlay");

            try
            {
                // First, check if spinner is visible
                var isVisible = await spinnerLocator.IsVisibleAsync();

                if (isVisible)
                {
                    // Spinner is visible, wait for it to disappear
                    await spinnerLocator.WaitForAsync(new()
                    {
                        State = WaitForSelectorState.Hidden,
                        Timeout = timeoutMs
                    });
                }
                else
                {
                    // Spinner not visible, wait briefly in case it's about to appear
                    await Task.Delay(500);

                    // Check again if it appeared
                    isVisible = await spinnerLocator.IsVisibleAsync();

                    if (isVisible)
                    {
                        // It appeared, now wait for it to disappear
                        await spinnerLocator.WaitForAsync(new()
                        {
                            State = WaitForSelectorState.Hidden,
                            Timeout = timeoutMs
                        });
                    }
                }
            }
            catch (TimeoutException)
            {
                // Log the timeout but don't fail the test
                Console.WriteLine($"Warning: Loading spinner did not disappear within {timeoutMs}ms");
                throw; // Re-throw to fail the test - spinner should always disappear
            }

            // Additional wait to ensure page is stable after spinner
            await Task.Delay(300);
        }

        /// <summary>
        /// Waits for any generic loading overlay to disappear.
        /// </summary>
        public static async Task WaitForLoadingOverlayAsync(IPage page, string overlaySelector = ".loading, .spinner, .overlay", int timeoutMs = 30000)
        {
            try
            {
                var overlay = page.Locator(overlaySelector);
                await overlay.WaitForAsync(new()
                {
                    State = WaitForSelectorState.Hidden,
                    Timeout = timeoutMs
                });
            }
            catch
            {
                // Overlay might not exist - that's OK
            }
        }

        /// <summary>
        /// Waits for page to be in a stable state (no network activity).
        /// </summary>
        public static async Task WaitForPageStableAsync(IPage page, int timeoutMs = 30000)
        {
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = timeoutMs });
        }

        /// <summary>
        /// Comprehensive wait: Spinner + Network Idle + Additional delay.
        /// Use this before critical interactions that often fail due to timing.
        /// </summary>
        public static async Task WaitForPageFullyReadyAsync(IPage page, int timeoutMs = 30000)
        {
            // Wait for spinner
            await WaitForAngularSpinnerAsync(page, timeoutMs);

            // Wait for network to be idle
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = timeoutMs });

            // Final stability delay
            await Task.Delay(500);
        }

        /// <summary>
        /// Force clicks an element, bypassing intercepting overlays.
        /// Use when normal click fails due to overlapping elements.
        /// </summary>
        public static async Task ForceClickAsync(IPage page, string selector, int timeoutMs = 15000)
        {
            var locator = page.Locator(selector);

            // Wait for element to exist
            await locator.WaitForAsync(new() { State = WaitForSelectorState.Attached, Timeout = timeoutMs });

            // Wait for any spinners
            await WaitForAngularSpinnerAsync(page);

            // Force click
            await locator.ClickAsync(new() { Force = true, Timeout = timeoutMs });
        }

        /// <summary>
        /// Waits for an element to be clickable (visible and enabled).
        /// </summary>
        public static async Task WaitForElementClickableAsync(IPage page, string selector, int timeoutMs = 15000)
        {
            var locator = page.Locator(selector);
            await Microsoft.Playwright.Assertions.Expect(locator).ToBeVisibleAsync(new() { Timeout = timeoutMs });
            await Microsoft.Playwright.Assertions.Expect(locator).ToBeEnabledAsync(new() { Timeout = timeoutMs });
            await WaitForAngularSpinnerAsync(page);
        }

        /// <summary>
        /// Waits for an element to be enabled.
        /// Useful for buttons that are disabled during form validation.
        /// </summary>
        public static async Task WaitForElementEnabledAsync(ILocator locator, int timeoutMs = 15000)
        {
            await Microsoft.Playwright.Assertions.Expect(locator)
                .ToBeEnabledAsync(new() { Timeout = timeoutMs });
        }

        /// <summary>
        /// Dismisses any modal dialogs, popups, or overlays that may be blocking interaction.
        /// Attempts to click common close buttons or press Escape.
        /// </summary>
        public static async Task DismissPopupsAsync(IPage page)
        {
            // Common close button selectors
            var closeSelectors = new[]
            {
                "[aria-label='Close']",
                "[aria-label='close']",
                ".mat-dialog-close",
                ".close-button",
                ".modal-close",
                "button.close",
                "[data-dismiss='modal']"
            };

            foreach (var selector in closeSelectors)
            {
                try
                {
                    var closeButton = page.Locator(selector).First;
                    if (await closeButton.IsVisibleAsync())
                    {
                        await closeButton.ClickAsync(new() { Timeout = 1000 });
                        await Task.Delay(300);
                        return;
                    }
                }
                catch
                {
                    // Continue to next selector
                }
            }

            // Try pressing Escape as fallback
            try
            {
                await page.Keyboard.PressAsync("Escape");
                await Task.Delay(300);
            }
            catch
            {
                // Escape didn't work, continue
            }
        }

        /// <summary>
        /// Fills an input field and then presses Tab to trigger Angular validation.
        /// Essential for Material/Angular forms that validate on blur.
        /// </summary>
        public static async Task FillAndTabAsync(ILocator locator, string value)
        {
            await locator.FillAsync(value);
            await locator.PressAsync("Tab");
            await Task.Delay(200); // Brief delay for validation
        }

        /// <summary>
        /// Fills an input field using page selector, then presses Tab.
        /// </summary>
        public static async Task FillAndTabAsync(IPage page, string selector, string value)
        {
            var locator = page.Locator(selector);
            await FillAndTabAsync(locator, value);
        }

        /// <summary>
        /// Clicks and waits for navigation or network idle.
        /// Use for buttons that trigger page transitions.
        /// </summary>
        public static async Task ClickAndWaitForNavigationAsync(ILocator locator, IPage page, int timeoutMs = 30000)
        {
            await locator.ClickAsync();
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = timeoutMs });
            await WaitForAngularSpinnerAsync(page, timeoutMs);
        }
    }
}
