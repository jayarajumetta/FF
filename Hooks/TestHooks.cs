// Pages/TestHooks.cs
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;

using Playwright_POC.Configuration;
using Playwright_POC.Context;
using Playwright_POC.Helpers;            // <-- ScenarioContextData lives here
using Playwright_POC.Services;

using Reqnroll;
using Reqnroll.BoDi;

using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// Alias the two TestContext types to avoid ambiguity
using PocTestContext = Playwright_POC.Context.TestContext;
using NUnitTestContext = NUnit.Framework.TestContext;

namespace Playwright_POC.Hooks
{
    [Binding]
    public class TestHooks
    {
        private readonly PocTestContext _context;
        private readonly BrowserFactory _browserFactory;
        private readonly IObjectContainer _container;
        private IBrowser _browser;
        private IPage _page;

        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;

        private readonly OAuthConfig _oauthConfig;
        private readonly PingSecretProvider _pingSecretProvider;
        private readonly IConfiguration _configuration;

        public TestHooks(
            PocTestContext context,
            BrowserFactory browserFactory,
            IObjectContainer container,
            ScenarioContext scenarioContext,
            FeatureContext featureContext,
            OAuthConfig oauthConfig,
            PingSecretProvider pingSecretProvider,
            IConfiguration configuration)
        {
            _context = context;
            _browserFactory = browserFactory;
            _container = container;

            _scenarioContext = scenarioContext;
            _featureContext = featureContext;

            _oauthConfig = oauthConfig;
            _pingSecretProvider = pingSecretProvider;
            _configuration = configuration;
        }

        [BeforeTestRun]
        public static void RegisterDependencies(IObjectContainer container)
        {
            // Global type registrations
            container.RegisterTypeAs<PocTestContext, PocTestContext>();
            container.RegisterTypeAs<BrowserFactory, BrowserFactory>();
            container.RegisterTypeAs<ApiService, IApiService>();
            
            // Register ScenarioContextData as InstancePerDependency with a shared backing field
            container.RegisterFactoryAs<ScenarioContextData>(() => 
            {
                // This will be called once per scenario context
                return new ScenarioContextData();
            }).InstancePerContext();
        }

        [BeforeScenario]
        public async Task BeforeScenarioAsync()
        {
            // Store in Reqnroll's ScenarioContext instead of DI container
            _scenarioContext["ContextData"] = new ScenarioContextData();
            Console.WriteLine("[Hooks] ScenarioContextData registered for this scenario.");

            // Initialize HttpClient for API scenarios (kept from your original code)
            _context.HttpClient = new System.Net.Http.HttpClient
            {
                BaseAddress = new Uri("https://expertquote-qa.americannational.com")
            };
            _container.RegisterInstanceAs(_context.HttpClient);

            if (IsApiScenario())
            {
                var clientSecret = await _pingSecretProvider.GetSecretAsync("<your-secret-id>");
                if (string.IsNullOrWhiteSpace(clientSecret))
                    throw new Exception("Failed to retrieve ClientSecret from Ping.");

                var token = await AuthHelper.GetTokenWithClientCredentialsAsync(_oauthConfig, clientSecret);
                _context.HttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                Console.WriteLine("API token retrieved successfully.");
            }
            else
            {
                var browserType = Environment.GetEnvironmentVariable("BROWSER_TYPE") ?? "chromium";
                _browser = await _browserFactory.GetBrowserAsync(browserType);
                _page = await _browserFactory.GetPageAsync(_browser, "about:blank");

                // Harden timeouts for slow environments
                _page.SetDefaultTimeout(60000);
                _page.SetDefaultNavigationTimeout(90000);

                _context.Page = _page;

                // Register live Playwright objects in the scenario container
                _container.RegisterInstanceAs(_context.Page);
                _container.RegisterInstanceAs(_browser);

                Console.WriteLine("Browser and Page initialized successfully.");
            }
        }

        [AfterStep]
        public async Task AfterStepAsync()
        {
            if (_scenarioContext.TestError != null && _context.Page != null)
            {
                var root = Directory.GetCurrentDirectory();
                var screenshotDir = Path.Combine(root, "Screenshots");
                Directory.CreateDirectory(screenshotDir);

                var stepText = SanitizeFileName(_scenarioContext.StepContext.StepInfo.Text);
                var fileName = $"{SanitizeFileName(_scenarioContext.ScenarioInfo.Title)}__{stepText}.png";
                var screenshotFile = Path.Combine(screenshotDir, fileName);

                await _context.Page.ScreenshotAsync(new() { Path = screenshotFile, FullPage = true });

                // Log screenshot path for debugging
                NUnitTestContext.WriteLine($"[screenshot] {screenshotFile}");
            }
        }

        [AfterScenario]
        public async Task AfterScenarioAsync()
        {
            // Close Playwright resources safely
            try { if (_context.Page != null) await _context.Page.CloseAsync(); } catch { /* ignore */ }
            try { if (_browser != null) await _browser.CloseAsync(); } catch { /* ignore */ }

            // Dispose HttpClient (API and UI scenarios)
            _context.HttpClient?.Dispose();
        }

        [AfterTestRun]
        public static void FinalizeRun()
        {
            // No reporting to finalize
        }

        // ------------ Helpers ------------

        private bool IsApiScenario()
        {
            var scenarioTags = _scenarioContext.ScenarioInfo.Tags ?? Array.Empty<string>();
            var featureTags = _featureContext.FeatureInfo.Tags ?? Array.Empty<string>();

            return scenarioTags.Any(t => t.Equals("API", StringComparison.OrdinalIgnoreCase))
                || featureTags.Any(t => t.Equals("API", StringComparison.OrdinalIgnoreCase));
        }

        private static string SanitizeFileName(string name)
        {
            foreach (var c in Path.GetInvalidFileNameChars())
                name = name.Replace(c, '_');
            return name;
        }
    }
}
