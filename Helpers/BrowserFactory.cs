using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Playwright_POC.Helpers
{
    public class BrowserFactory
    {
        private readonly IPlaywright _playwright;
        private readonly IConfiguration _configuration;

        public BrowserFactory(IConfiguration configuration)
        {
            _playwright = Playwright.CreateAsync().Result;
            _configuration = configuration;
        }

        public async Task<IBrowser> GetBrowserAsync(string browserType)
        {
            // Default to appsettings value unless overridden by PLAYWRIGHT_HEADLESS env var
            bool headless = ParseTruthy(_configuration["Playwright:Headless"]);
            var env = Environment.GetEnvironmentVariable("PLAYWRIGHT_HEADLESS");
            if (!string.IsNullOrEmpty(env))
            {
                // Accept "1", "true", "yes" as headless, everything else as headed
                headless = ParseTruthy(env);
            }

            return browserType.ToLower() switch
            {
                "edge" => await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = headless,
                    ExecutablePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe",
                    Args = new[] {"--start-fullscreen" }
                }),
                "chromium" => await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = headless,
                    ExecutablePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe",
                    Args = new[] { "--start-fullscreen" }
                }),
                "firefox" => await _playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = headless
                }),
                _ => throw new ArgumentException("Unsupported browser type")
            };
        }

        private static bool ParseTruthy(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            return value.Equals("1", StringComparison.OrdinalIgnoreCase)
                   || value.Equals("true", StringComparison.OrdinalIgnoreCase)
                   || value.Equals("yes", StringComparison.OrdinalIgnoreCase)
                   || value.Equals("on", StringComparison.OrdinalIgnoreCase);
        }

        public async Task<IPage> GetPageAsync(IBrowser browser, string url)
        {
            var context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1900,
                    Height = 1080
                }
            });
            var page = await context.NewPageAsync();
            await page.GotoAsync(url);
            return page;
        }
    }
}