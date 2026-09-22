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
using PnCTestAutomation.Reporting;
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
    public partial class TestHooks
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
        private readonly SgsExecutionCatalog _sgsCatalog;
        private readonly ScenarioContextData _scenarioData;
        private readonly DataPoolClientConfig _dataPoolOptions;
        private ProductEvidenceContract _productEvidence;
        private bool _tracingStarted;

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
            IProductModuleRegistry productModules,
            SgsExecutionCatalog sgsCatalog,
            ScenarioContextData scenarioData,
            DataPoolClientConfig dataPoolOptions,
            ScenarioReportRecorder reportRecorder,
            ScenarioReportPrivacy reportPrivacy)
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
            _sgsCatalog = sgsCatalog;
            _scenarioData = scenarioData;
            _dataPoolOptions = dataPoolOptions;
            _reportRecorder = reportRecorder;
            _reportPrivacy = reportPrivacy;
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

            var tags = (_scenarioContext.ScenarioInfo.Tags ?? [])
                .Concat(_featureContext.FeatureInfo.Tags ?? [])
                .ToHashSet(StringComparer.OrdinalIgnoreCase);
            var automationId = ScenarioAutomationIdentity.Resolve(
                _scenarioContext.ScenarioInfo.Tags ?? [],
                _featureContext.FeatureInfo.Tags ?? [],
                ScenarioAutomationIdentity.ResolveQualifier(tags, _scenarioContext.ScenarioInfo.Arguments));
            InitializeReporting(automationId, tags);
            SgsCaseResolution sgsResolution = null;
            if (tags.Contains("SgsImported"))
            {
                sgsResolution = _sgsCatalog.Resolve(
                    _featureContext.FeatureInfo.Title,
                    tags,
                    ScenarioAutomationIdentity.ReadArguments(_scenarioContext.ScenarioInfo.Arguments));
                _reportMetadata = _reportMetadata with { Application = sgsResolution.Workflow.ApplicationTag };
                if (!sgsResolution.IsRunnable)
                {
                    SkipScenario(
                        $"SGS case '{sgsResolution.Case.AutomationId}' is non-runnable: " +
                        sgsResolution.Case.BlockedReason);
                    return;
                }
                if (tags.Contains("NonRunnable"))
                    throw new SgsExecutionConfigurationException(
                        "An SGS case marked runnable still has a NonRunnable feature tag.");
                _sgsCatalog.ValidateResourcePayloads(
                    Path.Combine(AppContext.BaseDirectory, "Resources"), sgsResolution);
            }

            if (ShouldSkipScenarioForDevStateFilter(out var skipReason))
            {
                SkipScenario(skipReason);
                return;
            }

            var productModule = automationId == null
                ? null
                : _productModules.TryResolve(automationId);
            if (_reportingEnabled && productModule != null)
                _reportMetadata = _reportMetadata with { Lob = productModule.Product };
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
                    SkipScenario(
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
            if (sgsResolution != null)
                _artifacts.Require(sgsResolution.Workflow.RequiredEvidence.ToArray());

            if (IsApiScenario())
            {
                var accessToken = await _accessTokenProvider.GetAccessTokenAsync();
                _reportPrivacy.RegisterSensitiveValue(accessToken.Value);
                _apiService.SetAccessToken(accessToken);
            }
            else
            {
                if (_reportingEnabled)
                    _artifacts.Require(ArtifactKind.Screenshot, ArtifactKind.Trace, ArtifactKind.Video);
                var browserType = _browserFactory.ResolveBrowserType();
                _browser = await _browserFactory.GetBrowserAsync(browserType);

                // Create browser context with tracing and video enabled
                _browserContext = await _browser.NewContextAsync(new BrowserNewContextOptions
                {
                    ViewportSize = new ViewportSize { Width = 1900, Height = 1080 },
                    RecordVideoDir = _artifacts.GetArtifactDirectory(ArtifactKind.Video)
                });
                AttachBrowserReporting();

                var isCI = string.Equals(Environment.GetEnvironmentVariable("CI"), "true",
                    StringComparison.OrdinalIgnoreCase);

                if (_reportingEnabled || !isCI || _productEvidence?.RequiresFailureTrace == true)
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
                if (_reportingEnabled)
                    OnReportPage(this, _page);

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

        [AfterScenario(Order = int.MaxValue)]
        public async Task AfterScenarioAsync()
        {
            var wasSkipped =
                NUnitTestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Skipped ||
                _scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.Skipped ||
                _scenarioContext.TestError is NUnit.Framework.IgnoreException or NUnit.Framework.InconclusiveException;
            var runnerFailed = !wasSkipped &&
                (_scenarioContext.TestError != null ||
                 _scenarioContext.ScenarioExecutionStatus != ScenarioExecutionStatus.OK ||
                 NUnitTestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed);
            if (_scenarioContext.TestError != null)
                RecordDiagnostic("scenario", wasSkipped ? "skip" : "error", _scenarioContext.TestError.Message);
            while (_reportSteps.TryPop(out var unfinished))
            {
                var failure = RecordCompletionFailure("step-recording",
                    new InvalidOperationException("A started step did not reach its AfterStep boundary."));
                try
                {
                    _reportRecorder.EndStep(unfinished.Order, ReportStatus.Fail, failure.Message);
                }
                catch (InvalidOperationException exception)
                {
                    RecordCompletionFailure("step-recording", exception);
                }
            }
            if (_reportRecorder.HasFailures)
                _artifacts.RecordComponentOutcome("business-verification", false);
            var hasFailed = runnerFailed || !_completionFailures.IsEmpty ||
                _reportRecorder.HasFailures || _artifacts.HasFailedComponents;
            if (hasFailed && !IsApiScenario())
                RequireFailureEvidence();

            if (hasFailed && Debugger.IsAttached && _context.Page is { IsClosed: false })
            {
                Console.WriteLine("\n" + new string('=', 60));
                Console.WriteLine("TEST FAILED - BROWSER PAUSED FOR DEBUGGING");
                Console.WriteLine($"Error: {_reportPrivacy.CreateRedactor().Text(_scenarioContext.TestError?.Message)}");
                Console.WriteLine("Playwright Inspector is open. Hit Resume there to finish the run.");
                Console.WriteLine(new string('=', 60) + "\n");
                try
                {
                    await _context.Page.PauseAsync();
                }
                catch (Exception exception)
                {
                    RecordDiagnostic("debugger", "warning", exception.Message);
                }
            }

            if (_context.Page is { IsClosed: false } && (_reportingEnabled || hasFailed))
                await TryCompleteAsync("final-screenshot", async () => await CaptureScreenshotAsync("scenario-final"));

            if (_browserContext != null && _tracingStarted)
            {
                await TryCompleteAsync("trace-finalization", async () =>
                {
                    if (_reportingEnabled || hasFailed || !_completionFailures.IsEmpty)
                        await _artifactCapture.CaptureAsync(ArtifactKind.Trace, "scenario-trace", ".zip",
                            path => _browserContext.Tracing.StopAsync(new TracingStopOptions { Path = path }),
                            required: _reportingEnabled || _productEvidence?.RequiresFailureTrace == true);
                    else
                        await _browserContext.Tracing.StopAsync();
                });
                _tracingStarted = false;
            }

            var pages = ReportPages().Concat(_browserContext?.Pages ?? Array.Empty<IPage>())
                .Concat(new[] { _context.Page, _context.ChecklistPage }).Where(page => page != null).Distinct().ToArray();
            var videos = pages.Select((page, index) => (Video: page.Video, Index: index + 1,
                    Owned: page == _page || page == _context.Page || page == _context.ChecklistPage))
                .Where(item => item.Video != null).ToArray();
            foreach (var page in pages)
            {
                if (!page.IsClosed)
                    await TryCompleteAsync("page-close", () => page.CloseAsync());
            }
            _context.ChecklistPage = null;
            var contextClosed = _browserContext == null;
            if (_browserContext != null)
                await TryCompleteAsync("browser-context-close", async () =>
                {
                    await _browserContext.CloseAsync();
                    contextClosed = true;
                });
            if (!contextClosed && _browser != null)
                await TryCompleteAsync("browser-close", () => _browser.CloseAsync());
            if (contextClosed)
            {
                foreach (var (video, index, owned) in videos)
                {
                    if (owned && (_reportingEnabled || hasFailed || !_completionFailures.IsEmpty))
                        await TryCompleteAsync("video-finalization", async () =>
                            await _artifactCapture.CaptureAsync(ArtifactKind.Video, $"page-{index}", ".webm",
                                video.SaveAsAsync,
                                required: _reportingEnabled || _productEvidence?.RequiresFailureVideo == true));
                    await TryCompleteAsync("video-cleanup", video.DeleteAsync);
                }
            }
            else if (videos.Length > 0)
                RecordCompletionFailure("video-finalization",
                    new InvalidOperationException("Video completion could not be confirmed after browser-context shutdown failed."));
            if (contextClosed && _browser != null)
                await TryCompleteAsync("browser-close", () => _browser.CloseAsync());
            DetachBrowserReporting();

            if (_quoteHandoff.TryGet(out _))
                _artifacts.RecordMarker(ArtifactKind.QuoteHandoff, "quote-captured");
            ScenarioReportMetadata metadata = null;
            if (_reportingEnabled)
            {
                try
                {
                    metadata = SnapshotReportMetadata();
                }
                catch (Exception exception)
                {
                    RecordCompletionFailure("report-metadata", exception);
                }
            }

            if (!wasSkipped && !hasFailed && _completionFailures.IsEmpty &&
                !_artifacts.HasFailedComponents && _quoteHandoff.TryGet(out _))
                await TryCompleteAsync("data-pool-persistence", async () =>
                {
                    var environment = Environment.GetEnvironmentVariable("TEST_ENVIRONMENT")
                        ?? _configuration["Environment"] ?? "qa";
                    var result = await _dataPoolClient.PersistAsync(
                        QuoteRecordFactory.FromScenarioContext(_scenarioData, environment));
                    if (!result.Succeeded && _dataPoolOptions.Required)
                        throw new DataPoolPersistenceException(
                            $"Required DataPool persistence was not completed: {result.Status}. {result.Message}");
                    RecordDiagnostic("data-pool-persistence", result.Succeeded ? "info" : "warning",
                        $"{result.Status}: {result.Message}");
                });

            if (_reportingEnabled)
            {
                if (metadata != null)
                    metadata = SnapshotReportMetadata();
                await TryCompleteAsync("execution-log", () => WriteScenarioLogsAsync(metadata));
                if (metadata != null)
                    metadata = SnapshotReportMetadata();
            }
            var outcome = hasFailed || !_completionFailures.IsEmpty || _artifacts.HasFailedComponents
                ? ArtifactOutcome.Failed
                : wasSkipped ? ArtifactOutcome.Skipped : ArtifactOutcome.Passed;
            if (metadata != null)
                _artifacts.Complete(outcome, manifest => WriteFrozenReport(manifest, metadata));
            else
                _artifacts.Complete(outcome);

            if (!_completionFailures.IsEmpty)
                throw new ArtifactEvidenceException(string.Join(Environment.NewLine,
                    _completionFailures.Select(failure => failure.Message).Distinct(StringComparer.Ordinal)));
            if (!runnerFailed && (_reportRecorder.HasFailures || _artifacts.HasFailedComponents))
                throw new ArtifactEvidenceException("Scenario completion found failed business verifications or required components.");
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

            if (args.Contains("stateCode"))
            {
                var stateCode = args["stateCode"]?.ToString()?.Trim();
                if (!string.IsNullOrWhiteSpace(stateCode))
                    return stateCode.ToUpperInvariant();
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
