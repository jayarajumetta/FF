using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;

        public SessionService(TestContext context, DuckCreekFormsConfig formsConfig, IConfiguration configuration)
        {
            _context = context;
            _formsConfig = formsConfig;
            _configuration = configuration;
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

            var traceEnabled = string.Equals(
                _configuration["Debugging:TraceFormsNetwork"],
                "true",
                StringComparison.OrdinalIgnoreCase);

            var traceBuilder = new StringBuilder();
            var traceLock = new object();

            void AppendTrace(string line)
            {
                if (!traceEnabled) return;
                lock (traceLock)
                {
                    traceBuilder.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}] {line}");
                }
            }

            bool IsRelevantUrl(string url)
            {
                if (string.IsNullOrWhiteSpace(url)) return false;
                var u = url.ToLowerInvariant();
                return u.Contains("express/default")
                    || u.Contains("duckcreek")
                    || u.Contains("dctserver")
                    || u.Contains("ssodev")
                    || u.Contains("deva.anpac.info")
                    || u.Contains("clasq")
                    || u.Contains("clasd")
                    || u.Contains("svdw-clas03")
                    || u.Contains("svqw-clas21");
            }

            async Task LogResponseAsync(IResponse response)
            {
                try
                {
                    if (!IsRelevantUrl(response.Url)) return;

                    var ct = response.Headers.TryGetValue("content-type", out var h) ? h : string.Empty;
                    AppendTrace($"RES  {response.Status} {response.Request.Method} {response.Url} [content-type={ct}]");

                    if ((response.Request.ResourceType == "xhr" || response.Request.ResourceType == "fetch" || response.Request.ResourceType == "document")
                        && !string.IsNullOrEmpty(ct)
                        && (ct.Contains("json", StringComparison.OrdinalIgnoreCase)
                            || ct.Contains("xml", StringComparison.OrdinalIgnoreCase)
                            || ct.Contains("html", StringComparison.OrdinalIgnoreCase)
                            || ct.Contains("text", StringComparison.OrdinalIgnoreCase)))
                    {
                        var body = await response.TextAsync();
                        if (!string.IsNullOrWhiteSpace(body))
                        {
                            var oneLine = body.Replace("\r", " ").Replace("\n", " ").Trim();
                            if (oneLine.Length > 900) oneLine = oneLine[..900] + "...";
                            AppendTrace($"BODY {response.Status} {response.Url} => {oneLine}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    AppendTrace($"RES  <error reading body> {response.Url} => {ex.Message}");
                }
            }

            void RequestHandler(object sender, IRequest req)
            {
                if (!traceEnabled) return;
                if (!IsRelevantUrl(req.Url)) return;
                AppendTrace($"REQ  {req.Method} {req.Url} [type={req.ResourceType}]");
            }

            void ResponseHandler(object sender, IResponse res)
            {
                if (!traceEnabled) return;
                _ = LogResponseAsync(res);
            }

            if (traceEnabled)
            {
                AppendTrace($"TRACE START quote={quoteNumber}, clasBase={_formsConfig.CLASBaseUrl}");
                page.Request += RequestHandler;
                page.Response += ResponseHandler;
            }

            // Navigate the current tab to CLAS (same tab — no popup/second tab).
            // The EQ navigation step that follows will bring the tab back to EQ.
            try
            {
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
            finally
            {
                if (traceEnabled)
                {
                    page.Request -= RequestHandler;
                    page.Response -= ResponseHandler;

                    var traceDir = Path.Combine(AppContext.BaseDirectory, "TestResults", "FormsCheck", "NetworkTrace");
                    Directory.CreateDirectory(traceDir);
                    var tracePath = Path.Combine(traceDir, $"forms_network_{quoteNumber}_{DateTime.Now:yyyyMMdd_HHmmss}.log");
                    await File.WriteAllTextAsync(tracePath, traceBuilder.ToString());
                    Console.WriteLine($"[SessionService] Forms network trace saved: {tracePath}");
                }
            }
        }
    }
}

