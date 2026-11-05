using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Extensions.Configuration;
using PnCTestAutomation.Context;
using PnCTestAutomation.Models;
using PnCTestAutomation.Pages.ExpressPages;
using PnCTestAutomation.Helpers;

namespace PnCTestAutomation.Services
{
    /// <summary>
    /// Opens CLAS Express, opens a quote, and extracts the session used for Forms.
    /// </summary>
    public class SessionService
    {
        private readonly PlaywrightContext _context;
        private readonly DuckCreekFormsConfig _formsConfig;
        private readonly IConfiguration _configuration;
        public SessionService(PlaywrightContext context, DuckCreekFormsConfig formsConfig,
            IConfiguration configuration)
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
                    || u.Contains("svqw-clas2");
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
                RetryDiagnostics.For(page)?.Mark("clas-search action=click-search");
                await homePage.ClickSearchButtonAsync();

                await new ExpressSearchResultsPage(page).OpenExactQuoteAsync(quoteNumber);
                Console.WriteLine($"[SessionService] Requested CLAS quote: {quoteNumber}; waiting for navigation.");

                await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = 60000 });

                async Task<string> ReadSessionCookieAsync()
                {
                    var cookies = await page.Context.CookiesAsync(new[] { _formsConfig.CLASBaseUrl });
                    var values = cookies
                        .Where(c => c.Name.Equals("DuckCreek_SessionId", StringComparison.OrdinalIgnoreCase)
                            && !string.IsNullOrWhiteSpace(c.Value))
                        .Select(c => c.Value).Distinct(StringComparer.Ordinal).ToArray();
                    if (values.Length > 1)
                        throw new InvalidOperationException("Multiple different DuckCreek session cookies apply to CLAS; cannot identify the quote session safely.");
                    return values.SingleOrDefault();
                }

                var sessionId = await ReadSessionCookieAsync();
                if (string.IsNullOrWhiteSpace(sessionId))
                    throw new InvalidOperationException(
                        $"Opened quote {quoteNumber} in CLAS but DuckCreek_SessionId was not set. Forms were not requested.");

                var saveForLaterBtn = page.Locator("[actionref='SaveForLater']");
                var saveForLaterAvailable = true;
                try
                {
                    await saveForLaterBtn.WaitForAsync(new() { Timeout = 5000 });
                }
                catch (TimeoutException)
                {
                    saveForLaterAvailable = false;
                    Console.WriteLine("[SessionService] Save For Later is not available on the CLAS page; quote lock release was not confirmed.");
                }

                if (saveForLaterAvailable)
                {
                    await saveForLaterBtn.ClickAsync();
                    try
                    {
                        await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = 15000 });
                    }
                    catch (TimeoutException)
                    {
                        Console.WriteLine("[SessionService] CLAS did not reach network idle after Save For Later; quote lock release was not confirmed.");
                    }
                    Console.WriteLine("[SessionService] Clicked Save For Later; lock release is not independently verified.");
                }

                return sessionId;
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
