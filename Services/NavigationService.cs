
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using Playwright_POC.Context;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Playwright_POC.Services
{
    // Drives navigation on the same Playwright Page while preserving session/SSO
    public class NavigationService
    {
        private readonly PlaywrightContext _ctx;
        private readonly IConfiguration _config;

        public NavigationService(PlaywrightContext ctx, IConfiguration config)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public IPage Page => _ctx.Page ?? throw new InvalidOperationException("Page is not initialized yet.");

        public async Task GoToExpertQuoteAsync()
        {
            var env = _config["Environment"] ?? "QA";
            var urlKey = env.Equals("Dev", StringComparison.OrdinalIgnoreCase)
                ? "Playwright:ExpertQuoteDev"
                : "Playwright:ExpertQuote";
            await GotoWithRetryAsync(_config[urlKey] ?? throw new InvalidOperationException($"Missing config key: {urlKey}"));
        }

        public async Task GoToQAExpressAsync()
        {
            await GotoWithRetryAsync(_config["Playwright:QAExpress"] ?? throw new InvalidOperationException("Missing Playwright:QAExpress"));
            await Page.WaitForURLAsync(new Regex(@"express/defaultViewmodel", RegexOptions.IgnoreCase),
                                       new() { Timeout = 90000 });
        }

        private async Task GotoWithRetryAsync(string url, int attempts = 2)
        {
            for (var i = 0; i < attempts; i++)
            {
                try
                {
                    await Page.GotoAsync(url, new PageGotoOptions
                    {
                        Timeout = 90000,
                        WaitUntil = WaitUntilState.NetworkIdle
                    });
                    return;
                }
                catch (PlaywrightException) when (i < attempts - 1)
                {
                    await Task.Delay(2000);
                }
            }

            // Last attempt
            await Page.GotoAsync(url, new PageGotoOptions
            {
                Timeout = 90000,
                WaitUntil = WaitUntilState.NetworkIdle
            });
        }
    }
}
