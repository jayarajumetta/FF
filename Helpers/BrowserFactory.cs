using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace Playwright_POC.Helpers
{
    public class BrowserFactory
    {
        private readonly IPlaywright _playwright;

        public BrowserFactory()
        {
            _playwright = Playwright.CreateAsync().Result;
        }

        public async Task<IBrowser> GetBrowserAsync(string browserType)
        {
            return browserType.ToLower() switch
            {
                "edge" => await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false,
                    ExecutablePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe",
                    Args = new[] {"--start-fullscreen" }
                
                }),
                "chromium" => await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false,
                    ExecutablePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe",
                    Args = new[] { "--start-fullscreen" }
                }),
                "firefox" => await _playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false
                }),
                _ => throw new ArgumentException("Unsupported browser type")
            };
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