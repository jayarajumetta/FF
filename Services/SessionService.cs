using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright_POC.Context;
using Playwright_POC.Models;
using Playwright_POC.Pages.ExpressPages;

namespace Playwright_POC.Services
{
    /// <summary>
    /// Opens CLAS Express in a second tab, logs in, opens a quote, and extracts
    /// the DuckCreek_SessionId cookie — the colon-separated session ID that
    /// Session.resumeRq expects.
    /// </summary>
    public class SessionService
    {
        private readonly TestContext _context;
        private readonly DuckCreekFormsConfig _formsConfig;

        public SessionService(TestContext context, DuckCreekFormsConfig formsConfig)
        {
            _context = context;
            _formsConfig = formsConfig;
        }

        /// <summary>
        /// Opens CLAS, logs in, opens the policy, and extracts the DuckCreek_SessionId cookie.
        /// Returns (sessionId, empty list) — the list is kept for API compatibility.
        /// </summary>
        public async Task<(string SessionId, List<string> ApiCalls)> GetDuckCreekSessionIdAndInterceptClasAsync(string quoteNumber)
        {
            var sessionId = await GetDuckCreekSessionIdViaCLASAsync(quoteNumber);
            return (sessionId, new List<string>());
        }

        public async Task<string> GetDuckCreekSessionIdViaCLASAsync(string quoteNumber)
        {
            var page = _context.Page
                ?? throw new InvalidOperationException("No Playwright page is available.");

            // Navigate the current tab to CLAS (same tab — no popup/second tab).
            // The EQ navigation step that follows will bring the tab back to EQ.

            // 1. Navigate to CLAS
            Console.WriteLine($"[SessionService] Navigating to CLAS: {_formsConfig.CLASBaseUrl}");
            await page.GotoAsync(_formsConfig.CLASBaseUrl,
                new() { WaitUntil = WaitUntilState.NetworkIdle, Timeout = 30000 });

            // 2. Log in
            Console.WriteLine($"[SessionService] Logging in as {_formsConfig.CLASUsername}");
            var loginPage = new ExpressLoginPage(page);
            await loginPage.ExpressLoginAsync(_formsConfig.CLASUsername, _formsConfig.CLASPassword);

            // 3. Search for the quote
            Console.WriteLine($"[SessionService] Searching for quote: {quoteNumber}");
            var homePage = new ExpressHomePage(page);
            await homePage.EnterQuoteNumber(quoteNumber);
            await homePage.ClickSearchButtonAsync();

            // 4. Validate the quote number appears in the results grid
            var quoteCell = page.Locator($"p[fieldref='PolicyInput.PolicyNumber']:has-text('{quoteNumber}')");
            await quoteCell.WaitForAsync(new() { Timeout = 30000 });
            var displayedNumber = (await quoteCell.TextContentAsync())?.Trim();
            Console.WriteLine($"[SessionService] Found quote in grid: {displayedNumber}");

            if (displayedNumber != quoteNumber)
                throw new InvalidOperationException(
                    $"Quote mismatch: searched for '{quoteNumber}' but grid shows '{displayedNumber}'");

            // 5. Click "View Policy" to open the policy and establish the DuckCreek session
            var viewPolicyButton = page.Locator("button[title='View Policy']").First;
            await viewPolicyButton.ClickAsync();
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = 60000 });

            // 6. Extract DuckCreek_SessionId from cookies
            var cookies = await page.Context.CookiesAsync(new[] { _formsConfig.CLASBaseUrl });
            var dckCookie = cookies.FirstOrDefault(c =>
                c.Name.Equals("DuckCreek_SessionId", StringComparison.OrdinalIgnoreCase));

            if (dckCookie != null && !string.IsNullOrWhiteSpace(dckCookie.Value))
            {
                Console.WriteLine($"[SessionService] DuckCreek_SessionId cookie: {dckCookie.Value}");

                // 7. Click Save For Later to release the edit lock before leaving CLAS.
                //    The next step will navigate back to EQ and search for the quote.
                try
                {
                    var saveForLaterBtn = page.Locator("[actionref='SaveForLater']");
                    await saveForLaterBtn.WaitForAsync(new() { Timeout = 5000 });
                    await saveForLaterBtn.ClickAsync();
                    await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = 15000 });
                    Console.WriteLine("[SessionService] Clicked Save For Later — quote lock released. Page will return to EQ via next step.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[SessionService] Save For Later not found on CLAS page (non-fatal): {ex.Message}");
                }

                return dckCookie.Value;
            }

            Console.WriteLine("[SessionService] DuckCreek_SessionId cookie not found. All cookies:");
            foreach (var c in cookies)
                Console.WriteLine($"  {c.Name} = {c.Value[..Math.Min(60, c.Value.Length)]}...");

            throw new InvalidOperationException(
                $"Opened quote {quoteNumber} in CLAS but DuckCreek_SessionId cookie was not set.");
        }
    }
}

