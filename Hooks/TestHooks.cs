using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;

using PnCTestAutomation.Artifacts;
using PnCTestAutomation.BusinessOutcomes;
using PnCTestAutomation.Configuration;
using PnCTestAutomation.Context;
using PnCTestAutomation.DataPool;
using PnCTestAutomation.Helpers;            // <-- ScenarioContextData lives here
using PnCTestAutomation.Pages;
using PnCTestAutomation.Products;
using PnCTestAutomation.QuoteHandoffs;
using PnCTestAutomation.Services;
using PnCTestAutomation.TestPlans;

using Reqnroll;
using Reqnroll.BoDi;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

        private readonly IAccessTokenProvider _accessTokenProvider;
        private readonly IApiService _apiService;
        private readonly IConfiguration _configuration;
        private readonly IDataPoolClient _dataPoolClient;
        private readonly IQuoteHandoff _quoteHandoff;
        private readonly IArtifactContext _artifacts;
        private readonly IArtifactCaptureService _artifactCapture;
        private readonly IExpectedOutcomeProfileProvider _outcomeProfiles;
        private readonly IBusinessOutcomeContext _businessOutcomeContext;
        private readonly IProductModuleRegistry _productModules;
        private ProductEvidenceContract _productEvidence;
        private bool _tracingStarted;
        private ArtifactEvidenceException _artifactFailure;

        public TestHooks(
            PlaywrightContext context,
            BrowserFactory browserFactory,
            IObjectContainer container,
            ScenarioContext scenarioContext,
            FeatureContext featureContext,
            IAccessTokenProvider accessTokenProvider,
            IApiService apiService,
            IConfiguration configuration,
            IDataPoolClient dataPoolClient,
            IQuoteHandoff quoteHandoff,
            IArtifactContext artifacts,
            IArtifactCaptureService artifactCapture,
            IExpectedOutcomeProfileProvider outcomeProfiles,
            IBusinessOutcomeContext businessOutcomeContext,
            IProductModuleRegistry productModules)
        {
            _context = context;
            _browserFactory = browserFactory;
            _container = container;

            _scenarioContext = scenarioContext;
            _featureContext = featureContext;

            _accessTokenProvider = accessTokenProvider;
            _apiService = apiService;
            _configuration = configuration;
            _dataPoolClient = dataPoolClient;
            _quoteHandoff = quoteHandoff;
            _artifacts = artifacts;
            _artifactCapture = artifactCapture;
            _outcomeProfiles = outcomeProfiles;
            _businessOutcomeContext = businessOutcomeContext;
            _productModules = productModules;
        }

        [BeforeTestRun]
        public static void RegisterDependencies(IObjectContainer container)
        {
            // Global type registrations
            container.RegisterTypeAs<PlaywrightContext, PlaywrightContext>();
            container.RegisterTypeAs<BrowserFactory, BrowserFactory>();

            // Configure locator rescue from appsettings
            var configPath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
            if (File.Exists(configPath))
            {
                var config = new ConfigurationBuilder()
                    .AddJsonFile(configPath)
                    .AddEnvironmentVariables()
                    .Build();
                var rescueEnabled = string.Equals(
                    config["LocatorRescue:Enabled"], "true", StringComparison.OrdinalIgnoreCase);
                BasePage.ConfigureRescue(rescueEnabled);
                Console.WriteLine(
                    $"[Hooks] LocatorRescue: Enabled={rescueEnabled}, Mode=diagnostic-only");

                // Quotes are persisted over HTTP at the end of each passing scenario, so the
                // DataPool app has to be up before the first one finishes. Opt out with
                // "DataPool:AutoStart": false when something else owns its lifetime.
                var dataPoolBaseUrl =
                    Environment.GetEnvironmentVariable("DATAPOOL_BASE_URL")
                    ?? config["DataPool:BaseUrl"];
                var autoStartSetting =
                    Environment.GetEnvironmentVariable("DATAPOOL_AUTO_START")
                    ?? config["DataPool:AutoStart"];
                var autoStart = !string.Equals(
                    autoStartSetting,
                    "false",
                    StringComparison.OrdinalIgnoreCase);
                DataPoolLauncher.EnsureRunning(dataPoolBaseUrl, autoStart);

                var artifactOptions =
                    config.GetSection("Artifacts").Get<ArtifactOptions>()
                    ?? new ArtifactOptions();
                artifactOptions.RootPath =
                    Environment.GetEnvironmentVariable("TEST_ARTIFACT_ROOT")
                    ?? artifactOptions.RootPath;
                artifactOptions.Validate();
                CleanupOldTestResults(
                    ArtifactContext.ResolveOutputRoot(artifactOptions),
                    days: 7);
            }
        }

        [BeforeScenario]
        public async Task BeforeScenarioAsync()
        {
            // Seeds the single ScenarioContextData for this scenario. Startup's DI factory
            // returns this same instance to bindings that inject it rather than reading the key.
            // Only seed if absent: if anything resolved it ahead of this hook, overwriting here
            // would leave that holder pointing at an orphaned object.
            if (!_scenarioContext.ContainsKey(ScenarioContextData.ContextKey))
            {
                _scenarioContext[ScenarioContextData.ContextKey] = new ScenarioContextData();
            }

            if ((_scenarioContext.ScenarioInfo.Tags ?? []).Any(tag =>
                    tag.Equals("SgsImported", StringComparison.OrdinalIgnoreCase)))
            {
                NUnit.Framework.Assert.Ignore(
                    "Imported SGS feature retained as a business deliverable. " +
                    "Destination bindings, profiles, selectors, outcomes, and " +
                    "execution ownership must be adapted before it can run.");
                return;
            }

            if (ShouldSkipScenarioForDevStateFilter(out var skipReason))
            {
                NUnit.Framework.Assert.Ignore(skipReason);
                return;
            }

            var automationId = ScenarioAutomationIdentity.Resolve(
                _scenarioContext.ScenarioInfo.Tags ?? [],
                _featureContext.FeatureInfo.Tags ?? [],
                TryGetScenarioStateAbbreviation());
            var productModule = automationId == null
                ? null
                : _productModules.TryResolve(automationId);
            if (TryGetBusinessOutcomeScenarioProfile(out var scenarioProfile))
            {
                var state = TryGetScenarioStateAbbreviation()
                            ?? throw new BusinessOutcomeConfigurationException(
                                "A state argument is required for an SFP business outcome scenario.");
                var environment =
                    Environment.GetEnvironmentVariable("TEST_ENVIRONMENT")
                    ?? _configuration["Environment"]
                    ?? "qa";
                var resolution = _outcomeProfiles.ResolvePreflight(
                    scenarioProfile,
                    environment,
                    state);
                if (!resolution.IsRunnable)
                {
                    NUnit.Framework.Assert.Ignore(
                        $"Business outcome profile '{resolution.Profile.ProfileId}' " +
                        $"is explicitly non-runnable: {resolution.Reason}");
                    return;
                }

                _businessOutcomeContext.Set(resolution.Profile);
            }

            _productEvidence = productModule?.Evidence;
            if (_productEvidence != null)
            {
                _artifacts.Require(
                    _productEvidence.RequiredArtifacts.ToArray());
            }

            if (IsApiScenario())
            {
                var accessToken = await _accessTokenProvider.GetAccessTokenAsync();
                _apiService.SetAccessToken(accessToken);
            }
            else
            {
                var browserType = _browserFactory.ResolveBrowserType();
                _browser = await _browserFactory.GetBrowserAsync(browserType);

                // Create browser context with tracing and video enabled
                _browserContext = await _browser.NewContextAsync(new BrowserNewContextOptions
                {
                    ViewportSize = new ViewportSize { Width = 1900, Height = 1080 },
                    RecordVideoDir = _artifacts.GetArtifactDirectory(ArtifactKind.Video)
                });

                var isCI = string.Equals(Environment.GetEnvironmentVariable("CI"), "true",
                    StringComparison.OrdinalIgnoreCase);

                if (!isCI || _productEvidence?.RequiresFailureTrace == true)
                {
                    await _browserContext.Tracing.StartAsync(new TracingStartOptions
                    {
                        Screenshots = true,
                        Snapshots = true,
                        Sources = true
                    });
                    _tracingStarted = true;
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
                try
                {
                    RequireFailureEvidence();
                    var screenshot = await _artifactCapture.CaptureAsync(
                        ArtifactKind.Screenshot,
                        "step-failure",
                        ".png",
                        path => _context.Page.ScreenshotAsync(
                            new()
                            {
                                Path = path,
                                FullPage = true
                            }));
                    NUnitTestContext.WriteLine(
                        $"[screenshot] {screenshot.RelativePath}");
                }
                catch
                {
                    _artifactFailure = new ArtifactEvidenceException(
                        "A requested failure screenshot could not be captured.");
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
            if (hasFailed)
                RequireFailureEvidence();

            // Pause on failure only when a debugger is attached (i.e. Run > Debug in VS/Rider).
            // Normal CI / right-click "Run Test" runs are never blocked.
            if (hasFailed && System.Diagnostics.Debugger.IsAttached && _context.Page != null)
            {
                Console.WriteLine("\n" + new string('=', 60));
                Console.WriteLine("TEST FAILED - BROWSER PAUSED FOR DEBUGGING");
                Console.WriteLine($"Error: {_scenarioContext.TestError?.Message}");
                Console.WriteLine("Playwright Inspector is open. Hit Resume there to finish the run.");
                Console.WriteLine(new string('=', 60) + "\n");

                try
                {
                    // Blocks until Resume is clicked in the Inspector — there is no timeout.
                    await _context.Page.PauseAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Debug] Pause ended: {ex.Message}");
                }
            }

            if (_browserContext != null)
            {
                if (hasFailed)
                {
                    if (_tracingStarted)
                    {
                        try
                        {
                            var trace = await _artifactCapture.CaptureAsync(
                                ArtifactKind.Trace,
                                "scenario-failure",
                                ".zip",
                                path => _browserContext.Tracing.StopAsync(
                                    new TracingStopOptions { Path = path }),
                                required:
                                    _productEvidence?.RequiresFailureTrace == true);
                            NUnitTestContext.WriteLine($"[trace] {trace.RelativePath}");
                            _tracingStarted = false;
                        }
                        catch
                        {
                            _artifactFailure ??= new ArtifactEvidenceException(
                                "A requested failure trace could not be captured.");
                        }
                    }
                }
                else
                {
                    if (_tracingStarted)
                    {
                        try { await _browserContext.Tracing.StopAsync(); } catch { /* ignore */ }
                        _tracingStarted = false;
                    }

                }
            }

            // Close Playwright resources safely. Grab the video handle first — it hangs off the
            // page and we need it after both the page and the context are gone.
            var video = _context.Page?.Video;

            try { if (_context.Page != null) await _context.Page.CloseAsync(); } catch { /* ignore */ }
            try { if (_browserContext != null) await _browserContext.CloseAsync(); } catch { /* ignore */ }

            // Playwright only finalizes the .webm once the context closes, which is why this
            // runs here. Keep it for failures, drop it otherwise: previously every scenario left
            // a video behind and FinalizeRun only removed the folder when it was empty, so it
            // never was.
            if (video != null)
            {
                try
                {
                    if (hasFailed)
                    {
                        var videoArtifact = await _artifactCapture.CaptureAsync(
                            ArtifactKind.Video,
                            "scenario-failure",
                            ".webm",
                            video.SaveAsAsync,
                            required:
                                _productEvidence?.RequiresFailureVideo == true);
                        NUnitTestContext.WriteLine(
                            $"[video] {videoArtifact.RelativePath}");
                    }

                    await video.DeleteAsync();
                }
                catch
                {
                    _artifactFailure ??= new ArtifactEvidenceException(
                        "Requested video evidence could not be finalized.");
                }
            }

            try { if (_browser != null) await _browser.CloseAsync(); } catch { /* ignore */ }

            // ── DataPool: persist quote only from truly passing tests ──
            // Exclude: failed tests (TestError != null), skipped tests (outcome = Skipped),
            // and scenarios without a captured quote number.
            var isPassing = !hasFailed && _scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.OK;
            Exception persistenceFailure = null;
            if (isPassing && _artifactFailure == null)
            {
                if (_quoteHandoff.TryGet(out _))
                {
                    var ctx = _scenarioContext[ScenarioContextData.ContextKey] as ScenarioContextData
                              ?? throw new InvalidOperationException(
                                  "ScenarioContextData was unavailable during DataPool persistence.");
                    var env = _configuration["Environment"]
                              ?? Environment.GetEnvironmentVariable("TEST_ENVIRONMENT")
                              ?? "qa";
                    var record = QuoteRecordFactory.FromScenarioContext(ctx, env);
                    try
                    {
                        var result = await _dataPoolClient.PersistAsync(record);
                        if (!result.Succeeded)
                        {
                            Console.WriteLine(
                                $"[DataPool] Persistence not completed: {result.Status}. {result.Message}");
                        }
                    }
                    catch (DataPoolPersistenceException exception)
                    {
                        persistenceFailure = exception;
                    }
                }
            }

            if (_quoteHandoff.TryGet(out _))
                _artifacts.RecordMarker(ArtifactKind.QuoteHandoff, "quote-captured");

            _artifacts.Complete(
                _scenarioContext.ScenarioExecutionStatus != ScenarioExecutionStatus.OK ||
                hasFailed ||
                _artifactFailure != null ||
                persistenceFailure != null);

            if (_artifactFailure != null)
                throw _artifactFailure;
            if (persistenceFailure != null)
                throw persistenceFailure;
        }

        [AfterTestRun]
        public static void FinalizeRun()
        {
            // Shut down the shared Playwright driver process (see BrowserFactory).
            BrowserFactory.DisposeShared();

            // Only stops DataPool if this run was the one that started it.
            DataPoolLauncher.StopIfStarted();
        }

        // ------------ Helpers ------------

        private bool IsApiScenario()
        {
            var scenarioTags = _scenarioContext.ScenarioInfo.Tags ?? [];
            var featureTags = _featureContext.FeatureInfo.Tags ?? [];

            return scenarioTags.Any(t => t.Equals("API", StringComparison.OrdinalIgnoreCase))
                || featureTags.Any(t => t.Equals("API", StringComparison.OrdinalIgnoreCase));
        }

        private void RequireFailureEvidence()
        {
            _artifacts.RequireFailureEvidence();
            if (_productEvidence != null)
            {
                _artifacts.Require(
                    _productEvidence.RequiredFailureArtifacts.ToArray());
            }
        }

        private bool TryGetBusinessOutcomeScenarioProfile(out string profile)
        {
            profile = string.Empty;
            var tags = (_scenarioContext.ScenarioInfo.Tags ?? [])
                .Concat(_featureContext.FeatureInfo.Tags ?? [])
                .ToHashSet(StringComparer.OrdinalIgnoreCase);
            if (!tags.Contains("BusinessOutcomes"))
                return false;

            if (tags.Contains("SfpCountryEstateOutcome"))
            {
                profile = "sfp-country-estate";
                return true;
            }

            if (tags.Contains("SfpBasicOutcome"))
            {
                profile = "sfp-basic";
                return true;
            }

            throw new BusinessOutcomeConfigurationException(
                "A BusinessOutcomes scenario must declare a stable SFP outcome profile tag.");
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

            var envSetting = Environment.GetEnvironmentVariable("TEST_ENVIRONMENT")
                             ?? _configuration["Environment"]
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
