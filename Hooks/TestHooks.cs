using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;

using PnCTestAutomation.Configuration;
using PnCTestAutomation.Context;
using PnCTestAutomation.DataPool;
using PnCTestAutomation.Helpers;            // <-- ScenarioContextData lives here
using PnCTestAutomation.Pages;
using PnCTestAutomation.Services;

using Reqnroll;
using Reqnroll.BoDi;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using NUnitTestContext = NUnit.Framework.TestContext;

namespace PnCTestAutomation.Hooks
{
    [Binding]
    public class TestHooks
    {
        private readonly PlaywrightContext _context;
        private readonly BrowserFactory _browserFactory;
        private readonly IObjectContainer _container;
        private IBrowser _browser;
        private IBrowserContext _browserContext;
        private IPage _page;

        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;

        private readonly OAuthConfig _oauthConfig;
        private readonly PingSecretProvider _pingSecretProvider;
        private readonly IConfiguration _configuration;
        private readonly IDataPoolClient _dataPoolClient;

        // Test results folder for this run
        private static string _testResultsRunFolder;

        public TestHooks(
            PlaywrightContext context,
            BrowserFactory browserFactory,
            IObjectContainer container,
            ScenarioContext scenarioContext,
            FeatureContext featureContext,
            OAuthConfig oauthConfig,
            PingSecretProvider pingSecretProvider,
            IConfiguration configuration,
            IDataPoolClient dataPoolClient)
        {
            _context = context;
            _browserFactory = browserFactory;
            _container = container;

            _scenarioContext = scenarioContext;
            _featureContext = featureContext;

            _oauthConfig = oauthConfig;
            _pingSecretProvider = pingSecretProvider;
            _configuration = configuration;
            _dataPoolClient = dataPoolClient;
        }

        [BeforeTestRun]
        public static void RegisterDependencies(IObjectContainer container)
        {
            // Global type registrations
            container.RegisterTypeAs<PlaywrightContext, PlaywrightContext>();
            container.RegisterTypeAs<BrowserFactory, BrowserFactory>();
            container.RegisterTypeAs<ApiService, IApiService>();

            // Configure locator rescue from appsettings
            var configPath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
            if (File.Exists(configPath))
            {
                var config = new ConfigurationBuilder().AddJsonFile(configPath).Build();
                var rescueEnabled = string.Equals(
                    config["LocatorRescue:Enabled"], "true", StringComparison.OrdinalIgnoreCase);
                var rescueAutoHeal = string.Equals(
                    config["LocatorRescue:AutoHeal"], "true", StringComparison.OrdinalIgnoreCase);
                BasePage.ConfigureRescue(rescueEnabled, rescueAutoHeal);
                Console.WriteLine($"[Hooks] LocatorRescue: Enabled={rescueEnabled}, AutoHeal={rescueAutoHeal}");
            }

            // Create timestamped test results folder for this run
            var root = Directory.GetCurrentDirectory();
            var testResultsRoot = Path.Combine(root, "TestResults");
            _testResultsRunFolder = Path.Combine(testResultsRoot, DateTime.Now.ToString("yyyy-MM-dd_HHmmss"));
            Directory.CreateDirectory(_testResultsRunFolder);

            // Auto-cleanup: Delete TestResults folders older than 7 days
            CleanupOldTestResults(testResultsRoot, days: 7);

            // NOTE:
            // ScenarioContextData will be registered per scenario (instance),
            // not globally, to guarantee one shared object across all bindings
            // within a single scenario.
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

            if (ShouldSkipScenarioForDevStateFilter(out var skipReason))
            {
                NUnit.Framework.Assert.Ignore(skipReason);
                return;
            }

            // Delete any stale QuoteNumber.txt from a previous run so the file-based
            // fallback in UserValidatesFormsViaDuckcreek can never pick up an old quote.
            if (File.Exists("QuoteNumber.txt"))
            {
                File.Delete("QuoteNumber.txt");
                Console.WriteLine("[Hooks] Deleted stale QuoteNumber.txt");
            }

            // Initialize HttpClient for API scenarios (kept from your original code)
            _context.HttpClient = new System.Net.Http.HttpClient
            {
                BaseAddress = new Uri(_configuration["Playwright:ExpertQuoteBase"] ?? "https://expertquote-qa.americannational.com")
            };
            _container.RegisterInstanceAs(_context.HttpClient);

            if (IsApiScenario())
            {
                var pingSecretId = _configuration["OAuthConfig:PingSecretId"]
                    ?? Environment.GetEnvironmentVariable("PING_SECRET_ID")
                    ?? throw new InvalidOperationException(
                        "PING_SECRET_ID is not configured. Set OAuthConfig:PingSecretId in appsettings.json " +
                        "or the PING_SECRET_ID environment variable.");

                var clientSecret = await _pingSecretProvider.GetSecretAsync(pingSecretId);
                if (string.IsNullOrWhiteSpace(clientSecret))
                    throw new Exception("Failed to retrieve ClientSecret from Ping.");

                var token = await AuthHelper.GetTokenWithClientCredentialsAsync(_oauthConfig, clientSecret);
                _context.HttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                Console.WriteLine("API token retrieved successfully.");
            }
            else
            {
                var browserType = _browserFactory.ResolveBrowserType();
                _browser = await _browserFactory.GetBrowserAsync(browserType);

                // Create browser context with tracing and video enabled
                _browserContext = await _browser.NewContextAsync(new BrowserNewContextOptions
                {
                    ViewportSize = new ViewportSize { Width = 1900, Height = 1080 },
                    RecordVideoDir = Path.Combine(_testResultsRunFolder, "Videos")
                });

                // Start tracing — skip on CI unless a full trace is needed for debugging.
                // On CI, traces are only saved on failure anyway, so the overhead is wasted
                // for passing tests. Locally, always trace for developer convenience.
                var isCI = string.Equals(Environment.GetEnvironmentVariable("CI"), "true",
                    StringComparison.OrdinalIgnoreCase);

                if (!isCI)
                {
                    await _browserContext.Tracing.StartAsync(new TracingStartOptions
                    {
                        Screenshots = true,
                        Snapshots = true,
                        Sources = true
                    });
                }

                _page = await _browserContext.NewPageAsync();

                // Timeouts: 30s element / 90s navigation (SSO redirect chains can exceed 60s)
                _page.SetDefaultTimeout(30000);
                _page.SetDefaultNavigationTimeout(90000);

                _context.Page = _page;

                // Register live Playwright objects in the scenario container
                _container.RegisterInstanceAs(_context.Page);
                _container.RegisterInstanceAs(_browser);
                _container.RegisterInstanceAs(_browserContext);

                Console.WriteLine("Browser and Page initialized successfully.");
            }
        }

        [AfterStep]
        public async Task AfterStepAsync()
        {
            if (_scenarioContext.TestError != null && _context.Page != null)
            {
                var scenarioFolder = GetScenarioResultsFolder();
                Directory.CreateDirectory(scenarioFolder);

                var stepText = SanitizeFileName(_scenarioContext.StepContext.StepInfo.Text);
                var fileName = $"Step__{stepText}.png";
                var screenshotFile = Path.Combine(scenarioFolder, fileName);

                try
                {
                    await _context.Page.ScreenshotAsync(new() { Path = screenshotFile, FullPage = true });
                    NUnitTestContext.WriteLine($"[screenshot] {screenshotFile}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Warning] Failed to capture screenshot: {ex.Message}");
                }
            }
        }

        [AfterScenario]
        public async Task AfterScenarioAsync()
        {
            // Close the checklist popup tab if it is still open (e.g. test failed mid-checklist)
            if (_context.ChecklistPage != null)
            {
                try
                {
                    if (!_context.ChecklistPage.IsClosed)
                        await _context.ChecklistPage.CloseAsync();
                }
                catch { /* ignore — tab may already be gone */ }
                _context.ChecklistPage = null;
            }
            // Handle tracing and video on failure
            var hasFailed = _scenarioContext.TestError != null;

            // Pause on failure only when a debugger is attached (i.e. Run > Debug in VS/Rider).
            // Normal CI / right-click "Run Test" runs are never blocked.
            var pauseOnFailure = System.Diagnostics.Debugger.IsAttached;
            var pauseTimeoutSeconds = _configuration.GetValue<int>("Debugging:PauseTimeoutSeconds", 300);

            if (hasFailed && pauseOnFailure && _context.Page != null)
            {
                Console.WriteLine("\n" + new string('=', 60));
                Console.WriteLine("TEST FAILED - BROWSER PAUSED FOR DEBUGGING");
                Console.WriteLine($"Error: {_scenarioContext.TestError?.Message}");
                Console.WriteLine($"Browser will remain open for {pauseTimeoutSeconds} seconds.");
                Console.WriteLine("Press any key in the console to continue, or wait for timeout.");
                Console.WriteLine(new string('=', 60) + "\n");

                try
                {
                    // Use Playwright's pause for interactive debugging
                    await _context.Page.PauseAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Debug] Pause ended: {ex.Message}");
                }
            }

            if (_browserContext != null)
            {
                var scenarioFolder = GetScenarioResultsFolder();

                var isCI = string.Equals(Environment.GetEnvironmentVariable("CI"), "true",
                    StringComparison.OrdinalIgnoreCase);

                if (hasFailed)
                {
                    Directory.CreateDirectory(scenarioFolder);

                    // Save trace on failure (only if tracing was started — not on CI)
                    if (!isCI)
                    {
                        var traceFile = Path.Combine(scenarioFolder, "trace.zip");
                        try
                        {
                            await _browserContext.Tracing.StopAsync(new TracingStopOptions { Path = traceFile });
                            NUnitTestContext.WriteLine($"[trace] {traceFile}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[Warning] Failed to save trace: {ex.Message}");
                        }
                    }
                }
                else
                {
                    // Stop tracing without saving if test passed (only if it was started)
                    if (!isCI)
                    {
                        try { await _browserContext.Tracing.StopAsync(); } catch { /* ignore */ }
                    }

                    // Write pass record for telemetry (time-to-resolution tracking)
                    try
                    {
                        var passRecord = Path.Combine(_testResultsRunFolder, "pass-records.csv");
                        var scenarioName = _scenarioContext.ScenarioInfo.Title;
                        var line = $"{DateTime.UtcNow:O},{scenarioName}";
                        File.AppendAllText(passRecord, line + Environment.NewLine);
                    }
                    catch { /* ignore — telemetry must never block test execution */ }
                }
            }

            // Close Playwright resources safely
            try { if (_context.Page != null) await _context.Page.CloseAsync(); } catch { /* ignore */ }
            try
            {
                if (_browserContext != null)
                {
                    await _browserContext.CloseAsync();

                    // Move video to scenario folder on failure, delete on success
                    if (hasFailed)
                    {
                        // Video is saved automatically when context closes
                        Console.WriteLine("[video] Video saved for failed test");
                    }
                }
            }
            catch { /* ignore */ }
            try { if (_browser != null) await _browser.CloseAsync(); } catch { /* ignore */ }

            // Dispose HttpClient (API and UI scenarios)
            _context.HttpClient?.Dispose();

            // ── DataPool: persist quote if test passed and a quote number was captured ──
            // Only persist on success — failed tests may have partial/invalid data.
            if (!hasFailed)
            {
                try
                {
                    var ctx = _scenarioContext["ContextData"] as ScenarioContextData;
                    var record = QuoteRecordFactory.FromScenarioContext(ctx);
                    if (record != null)
                        await _dataPoolClient.TryPersistAsync(record);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DataPool] Error building quote record: {ex.Message}");
                }
            }
        }

        [AfterTestRun]
        public static void FinalizeRun()
        {
            // Cleanup empty folders in TestResults
            if (Directory.Exists(_testResultsRunFolder))
            {
                try
                {
                    // Remove Videos folder if empty
                    var videosFolder = Path.Combine(_testResultsRunFolder, "Videos");
                    if (Directory.Exists(videosFolder) && !Directory.EnumerateFiles(videosFolder).Any())
                    {
                        Directory.Delete(videosFolder, true);
                    }

                    // Remove run folder if empty
                    if (!Directory.EnumerateFileSystemEntries(_testResultsRunFolder).Any())
                    {
                        Directory.Delete(_testResultsRunFolder);
                    }
                }
                catch { /* ignore cleanup errors */ }
            }
        }

        // ------------ Helpers ------------

        private bool IsApiScenario()
        {
            var scenarioTags = _scenarioContext.ScenarioInfo.Tags ?? [];
            var featureTags = _featureContext.FeatureInfo.Tags ?? [];

            return scenarioTags.Any(t => t.Equals("API", StringComparison.OrdinalIgnoreCase))
                || featureTags.Any(t => t.Equals("API", StringComparison.OrdinalIgnoreCase));
        }

        private static string SanitizeFileName(string name)
        {
            foreach (var c in Path.GetInvalidFileNameChars())
                name = name.Replace(c, '_');
            return name;
        }

        private string GetScenarioResultsFolder()
        {
            var scenarioName = SanitizeFileName(_scenarioContext.ScenarioInfo.Title);
            return Path.Combine(_testResultsRunFolder, scenarioName);
        }

        private static void CleanupOldTestResults(string testResultsRoot, int days)
        {
            if (!Directory.Exists(testResultsRoot)) return;

            var cutoff = DateTime.Now.AddDays(-days);

            foreach (var dir in Directory.GetDirectories(testResultsRoot))
            {
                try
                {
                    var dirInfo = new DirectoryInfo(dir);
                    if (dirInfo.CreationTime < cutoff)
                    {
                        Directory.Delete(dir, true);
                        Console.WriteLine($"[Cleanup] Deleted old test results: {dirInfo.Name}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Warning] Failed to cleanup {dir}: {ex.Message}");
                }
            }
        }

        private bool ShouldSkipScenarioForDevStateFilter(out string reason)
        {
            reason = string.Empty;

            var envSetting = _configuration["Environment"]
                             ?? Environment.GetEnvironmentVariable("TEST_ENVIRONMENT")
                             ?? "QA";

            if (!envSetting.Equals("Dev", StringComparison.OrdinalIgnoreCase))
                return false;

            var allowedStates = _configuration
                .GetSection("StateFilters:DevAllowedStates")
                .Get<string[]>();

            if (allowedStates == null || allowedStates.Length == 0)
                return false;

            var scenarioState = TryGetScenarioStateAbbreviation();
            if (string.IsNullOrWhiteSpace(scenarioState))
                return false;

            var allowed = new HashSet<string>(
                allowedStates
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .Select(s => s.Trim().ToUpperInvariant()),
                StringComparer.OrdinalIgnoreCase);

            if (allowed.Contains(scenarioState))
                return false;

            reason = $"Skipping Dev scenario for state '{scenarioState}'. Allowed Dev states: {string.Join(", ", allowed.Order())}.";
            return true;
        }

        private string TryGetScenarioStateAbbreviation()
        {
            var args = _scenarioContext.ScenarioInfo.Arguments;
            if (args == null || args.Count == 0)
                return null;

            if (args.Contains("StateAbbv"))
            {
                var stateAbbv = args["StateAbbv"]?.ToString()?.Trim();
                if (!string.IsNullOrWhiteSpace(stateAbbv))
                    return stateAbbv.ToUpperInvariant();
            }

            if (args.Contains("State"))
            {
                var state = args["State"]?.ToString()?.Trim();
                if (!string.IsNullOrWhiteSpace(state) && state.Length == 2)
                    return state.ToUpperInvariant();
            }

            return null;
        }
    }
}
