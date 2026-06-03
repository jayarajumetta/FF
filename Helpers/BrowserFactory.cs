using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace PnCTestAutomation.Helpers
{
    public class BrowserFactory
    {
        private static readonly string[] FullscreenArgs = ["--start-fullscreen"];
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

            var normalizedBrowser = NormalizeBrowserType(browserType);

            return normalizedBrowser switch
            {
                "edge" => await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = headless,
                    Channel = "msedge",
                    Args = FullscreenArgs
                }),
                "chrome" => await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = headless,
                    Channel = "chrome",
                    Args = FullscreenArgs
                }),
                "chromium" => await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = headless,
                    Args = FullscreenArgs
                }),
                "firefox" => await _playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = headless
                }),
                "webkit" => await _playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = headless
                }),
                _ => throw new ArgumentException("Unsupported browser type")
            };
        }

        public string ResolveBrowserType()
        {
            // Env var wins for one-off runs. appsettings is the default.
            var configured = Environment.GetEnvironmentVariable("BROWSER_TYPE");
            if (string.IsNullOrWhiteSpace(configured))
                configured = _configuration["Playwright:BrowserType"];

            return NormalizeBrowserType(configured);
        }

        private static string NormalizeBrowserType(string browserType)
        {
            var normalized = (browserType ?? "chromium").Trim().ToLowerInvariant();

            return normalized switch
            {
                "msedge" => "edge",
                "edge" => "edge",
                "chrome" => "chrome",
                "chromium" => "chromium",
                "firefox" => "firefox",
                "webkit" => "webkit",
                _ => throw new ArgumentException(
                    "Unsupported browser type. Use one of: chrome, edge, chromium, firefox, webkit")
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

        public static async Task<IPage> GetPageAsync(IBrowser browser, string url)
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
