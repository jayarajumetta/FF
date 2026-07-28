using Microsoft.Playwright;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace PnCTestAutomation.Helpers
{
    public class BrowserFactory
    {
        private static readonly string[] FullscreenArgs = ["--start-fullscreen"];

        // Reqnroll's [ScenarioDependencies] builds a fresh ServiceProvider for every scenario,
        // so a "singleton" BrowserFactory is really one instance per scenario. Creating
        // IPlaywright in the constructor therefore spawned — and leaked — one Node driver
        // process per scenario. The driver is thread-safe and meant to be shared, so it lives
        // here for the lifetime of the process and is disposed once by TestHooks.FinalizeRun.
        private static readonly Lazy<Task<IPlaywright>> SharedPlaywright =
            new(Playwright.CreateAsync, LazyThreadSafetyMode.ExecutionAndPublication);

        private readonly IConfiguration _configuration;

        public BrowserFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Disposes the shared Playwright driver. Call once at the end of the test run.
        /// </summary>
        public static void DisposeShared()
        {
            if (!SharedPlaywright.IsValueCreated)
                return;

            try
            {
                SharedPlaywright.Value.GetAwaiter().GetResult().Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[BrowserFactory] Failed to dispose Playwright driver: {ex.Message}");
            }
        }

        public async Task<IBrowser> GetBrowserAsync(string browserType)
        {
            var playwright = await SharedPlaywright.Value;

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
                "edge" => await LaunchChromiumWithChannelFallbackAsync(playwright, "msedge", headless),
                "chrome" => await LaunchChromiumWithChannelFallbackAsync(playwright, "chrome", headless),
                "chromium" => await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = headless,
                    Args = FullscreenArgs
                }),
                "firefox" => await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = headless
                }),
                "webkit" => await playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = headless
                }),
                _ => throw new ArgumentException("Unsupported browser type")
            };
        }

        private static async Task<IBrowser> LaunchChromiumWithChannelFallbackAsync(
            IPlaywright playwright, string channel, bool headless)
        {
            try
            {
                return await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = headless,
                    Channel = channel,
                    Args = FullscreenArgs
                });
            }
            catch (PlaywrightException)
            {
                // Fall back to Playwright's bundled Chromium when the requested channel is not installed
                return await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = headless,
                    Args = FullscreenArgs
                });
            }
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
