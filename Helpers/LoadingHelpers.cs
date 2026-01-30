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
        /// Waits for an element to be clickable (visible, enabled, not covered).
        /// </summary>
        public static async Task WaitForElementClickableAsync(IPage page, string selector, int timeoutMs = 15000)
        {
            var locator = page.Locator(selector);
            
            // Wait for visible
            await locator.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = timeoutMs });
            
            // Wait for enabled
            await Task.Run(async () =>
            {
                var timeout = DateTime.Now.AddMilliseconds(timeoutMs);
                while (DateTime.Now < timeout)
                {
                    if (await locator.IsEnabledAsync())
                        return;
                    await Task.Delay(100);
                }
                throw new TimeoutException($"Element {selector} not enabled within {timeoutMs}ms");
            });
            
            // Wait for any overlays to clear
            await WaitForAngularSpinnerAsync(page);
        }
    }
}
