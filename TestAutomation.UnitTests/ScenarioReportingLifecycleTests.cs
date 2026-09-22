using System.Collections.Specialized;
using System.Globalization;
using System.Reflection;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Playwright;
using NUnit.Framework;
using PnCTestAutomation.Artifacts;
using PnCTestAutomation.Configuration;
using PnCTestAutomation.Context;
using PnCTestAutomation.DataPool;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Hooks;
using PnCTestAutomation.Models;
using PnCTestAutomation.Products;
using PnCTestAutomation.Reporting;
using PnCTestAutomation.Services;
using PnCTestAutomation.SgsReport;
using PnCTestAutomation.TestPlans;
using Reqnroll;
using Reqnroll.Bindings;
using Reqnroll.BoDi;
using Reqnroll.Configuration;
using Reqnroll.Infrastructure;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
[NonParallelizable]
public sealed class ScenarioReportingLifecycleTests
{
    private string _root = null!;
    private readonly Dictionary<string, string?> _environment = new();
    private readonly List<Harness> _harnesses = [];

    [SetUp]
    public void SetUp()
    {
        _root = Path.Combine(Path.GetTempPath(), "PnCTestAutomation.Reporting", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(_root);
        foreach (var (key, value) in new[]
        {
            ("CI", "true"), ("BROWSER_TYPE", "chromium"), ("PLAYWRIGHT_HEADLESS", "true"),
            ("TEST_ENVIRONMENT", "QA"), ("TEST_ATTEMPT_NUMBER", "1")
        })
        {
            _environment.Add(key, Environment.GetEnvironmentVariable(key));
            Environment.SetEnvironmentVariable(key, value);
        }
    }

    [TearDown]
    public async Task TearDown()
    {
        foreach (var harness in _harnesses)
            await harness.DisposeAsync();
        _harnesses.Clear();
        foreach (var (key, value) in _environment)
            Environment.SetEnvironmentVariable(key, value);
        _environment.Clear();
        Directory.Delete(_root, true);
    }

    [OneTimeTearDown]
    public void StopOwnedDriver() => BrowserFactory.DisposeShared();

    [Test]
    public async Task ApiLifecycleWritesTheFrozenCanonicalProjectionAndRedactedExecutionLog()
    {
        var harness = Create();
        await harness.Hooks.BeforeScenarioAsync();
        harness.State.ClientFirstName = "Contract \"private\" name";
        harness.State.SSN = "012345678";
        harness.Recorder.RecordDiagnostic("contract", "info",
            $"{harness.State.ClientFirstName}; {harness.State.SSN}; {TokenProvider.Token}");
        harness.StartStep("an offline API contract completes");
        await harness.Hooks.AfterStepAsync();
        await harness.Hooks.AfterScenarioAsync();

        var manifest = harness.Manifest();
        var report = harness.Projection();
        var log = File.ReadAllText(harness.ArtifactPath(ArtifactKind.ExecutionLog));
        Assert.Multiple(() =>
        {
            Assert.That(manifest.Outcome, Is.EqualTo(ArtifactOutcome.Passed));
            Assert.That(report.Status, Is.EqualTo(ReportStatus.Pass));
            Assert.That(report.ManifestFingerprint, Is.EqualTo(ScenarioReportProjector.ManifestFingerprint(manifest)));
            Assert.That(report.TestIdentityHash, Is.EqualTo(ScenarioReportProjector.IdentityHash(harness.Identity)));
            Assert.That(report.ExecutionId, Is.EqualTo(harness.Artifacts.RunId));
            Assert.That(report.AttemptNumber, Is.EqualTo(1));
            Assert.That(report.Steps, Has.Length.EqualTo(1));
            Assert.That(manifest.RequiredEvidence, Does.Not.Contain(ArtifactKind.Video));
            Assert.That(log, Does.Not.Contain("private").And.Not.Contain("012345678").And.Not.Contain(TokenProvider.Token));
            Assert.That(report.Diagnostics.Last().Message, Does.Not.Contain("private"));
        });
    }

    [Test]
    [Category("BrowserContract")]
    public async Task PassingBrowserLifecycleKeepsUniqueCheckpointsTraceOwnedVideosAndObservedErrors()
    {
        var harness = Create(api: false);
        await harness.Hooks.BeforeScenarioAsync();
        var page = harness.Browser.Page;
        await page.SetContentAsync("<h1 data-testid='heading'>Offline contract</h1>");
        harness.StartStep("the first offline checkpoint is reached");
        await page.EvaluateAsync("() => console.error('offline-console-contract')");
        await harness.Hooks.AfterStepAsync();
        harness.StartStep("the second offline checkpoint is reached");
        await page.GetByTestId("heading").EvaluateAsync("element => element.textContent = 'Second checkpoint'");
        await harness.Hooks.AfterStepAsync();
        var popup = await page.Context.NewPageAsync();
        harness.Browser.ChecklistPage = popup;
        await popup.SetContentAsync("<p>Offline popup contract</p>");
        await popup.ScreenshotAsync();
        await popup.EvaluateAsync("() => new Promise(resolve => requestAnimationFrame(() => requestAnimationFrame(resolve)))");
        await popup.CloseAsync();
        var transient = await page.Context.NewPageAsync();
        await transient.CloseAsync();
        await harness.Hooks.AfterScenarioAsync();

        var manifest = harness.Manifest();
        var report = harness.Projection();
        Assert.Multiple(() =>
        {
            Assert.That(manifest.Outcome, Is.EqualTo(ArtifactOutcome.Passed));
            Assert.That(manifest.Artifacts.Count(item => item.Kind == ArtifactKind.Video), Is.EqualTo(2));
            Assert.That(manifest.Artifacts.Count(item => item.Kind == ArtifactKind.Trace), Is.EqualTo(1));
            Assert.That(report.Steps.SelectMany(step => step.Screenshots).Distinct().ToArray(), Has.Length.EqualTo(2));
            Assert.That(report.Steps[0].ConsoleErrors, Does.Contain("offline-console-contract"));
            Assert.That(File.ReadAllText(harness.ArtifactPath(ArtifactKind.ConsoleLog)), Does.Contain("offline-console-contract"));
            Assert.That(new FileInfo(harness.ArtifactPath(ArtifactKind.Trace)).Length, Is.GreaterThan(0));
            Assert.That(manifest.EvidenceErrors, Is.Empty);
        });
    }

    [Test]
    public async Task DeferredVerificationFailsTheAuthoritativeOwnerAndPreventsQuotePersistence()
    {
        var harness = Create();
        await harness.Hooks.BeforeScenarioAsync();
        harness.State.QuoteNumber = "01234567";
        harness.Recorder.RecordDeferredVerification(new(
            DateTimeOffset.UtcNow, "Offline premium contract", "ContractPage", "premium", "Value",
            "1540.00", "The observed premium differs."));

        Assert.ThrowsAsync<ArtifactEvidenceException>(() => harness.Hooks.AfterScenarioAsync());
        Assert.Multiple(() =>
        {
            Assert.That(harness.Manifest().Outcome, Is.EqualTo(ArtifactOutcome.Failed));
            Assert.That(harness.Manifest().AuthoritativeScenarioFailed, Is.True);
            Assert.That(harness.Projection().DeferredVerifications, Has.Length.EqualTo(1));
            Assert.That(harness.Projection().Status, Is.EqualTo(ReportStatus.Fail));
            Assert.That(harness.DataPool.Calls, Is.Zero);
        });
    }

    [Test]
    public async Task ARecordedRequiredComponentFailureCannotBeErasedOrPersistedAsAPassingQuote()
    {
        var harness = Create();
        await harness.Hooks.BeforeScenarioAsync();
        harness.State.QuoteNumber = "01234567";
        harness.Artifacts.RecordComponentOutcome("contract-component", false);
        harness.Artifacts.RecordComponentOutcome("contract-component", true);

        Assert.ThrowsAsync<ArtifactEvidenceException>(() => harness.Hooks.AfterScenarioAsync());
        Assert.That(harness.Manifest().Outcome, Is.EqualTo(ArtifactOutcome.Failed));
        Assert.That(harness.DataPool.Calls, Is.Zero);
    }

    [Test]
    public async Task OriginalStepFailureIsPreservedInTheReportWithoutASecondOutcomeOwner()
    {
        var harness = Create();
        await harness.Hooks.BeforeScenarioAsync();
        harness.StartStep("an offline business assertion fails");
        harness.Context.FailStep(new InvalidOperationException("Controlled assertion failure"));
        await harness.Hooks.AfterStepAsync();
        await harness.Hooks.AfterScenarioAsync();

        Assert.Multiple(() =>
        {
            Assert.That(harness.Manifest().Outcome, Is.EqualTo(ArtifactOutcome.Failed));
            Assert.That(harness.Projection().Steps.Single().Status, Is.EqualTo(ReportStatus.Fail));
            Assert.That(harness.Projection().Steps.Single().Error, Does.Contain("Controlled assertion failure"));
        });
    }

    [Test]
    public async Task ConsolidationUsesScenarioRedactedFailureDetailsInsteadOfRawRunnerAssertions()
    {
        var harness = Create();
        await harness.Hooks.BeforeScenarioAsync();
        harness.State.ClientFirstName = "ControlledPrivateName";
        harness.State.SSN = "000001111";
        var raw = $"Actual values: {harness.State.ClientFirstName}, {harness.State.SSN}, {TokenProvider.Token}";
        harness.StartStep("a sensitive offline assertion fails");
        harness.Context.FailStep(new InvalidOperationException(raw));
        await harness.Hooks.AfterStepAsync();
        await harness.Hooks.AfterScenarioAsync();
        var canonical = TestCanonicalFiles.Trx((harness.Identity, "Failed"));
        var ns = TestCanonicalFiles.TrxNamespace;
        canonical.Descendants(ns + "UnitTestResult").Single().Add(
            new XElement(ns + "Output", new XElement(ns + "ErrorInfo", new XElement(ns + "Message", raw))));
        var canonicalPath = Path.Combine(_root, "canonical.trx");
        canonical.Save(canonicalPath);

        var result = new ReportAggregator().Generate(new(_root, canonicalPath, Path.Combine(_root, "report")));
        var html = File.ReadAllText(result.ReportPath);
        Assert.Multiple(() =>
        {
            Assert.That(result.ExitCode, Is.EqualTo(1));
            Assert.That(result.Report.Issues, Is.Empty);
            Assert.That(result.Report.Tests.Single().FailureMessage, Does.Contain(ReportRedactor.Mask));
            Assert.That(html, Does.Not.Contain(harness.State.ClientFirstName)
                .And.Not.Contain(harness.State.SSN).And.Not.Contain(TokenProvider.Token));
        });
    }

    [Test]
    public void RawRunnerIdentityIsPreservedExactlyRatherThanTrimmed()
    {
        const string identity = "  Offline runner identity  ";
        var owner = new ArtifactContext(new ArtifactOptions { RootPath = _root }, "identity-contract", "identity-case",
            automationId: "REPORT-CONTRACT:AL", testIdentity: identity);
        var manifest = owner.Complete(ArtifactOutcome.Passed);
        var projection = ScenarioReportProjector.Project(manifest,
            new("Offline identity contract", "Exact identity", "API", "AL", "Contract", owner.RunId));
        Assert.Multiple(() =>
        {
            Assert.That(manifest.TestIdentity, Is.EqualTo(identity));
            Assert.That(projection.TestIdentityHash, Is.EqualTo(ScenarioReportProjector.IdentityHash(identity)));
        });
    }

    [Test]
    public async Task MissingRequiredEvidenceRendersAnHonestFailedReportAndStillThrows()
    {
        var harness = Create();
        await harness.Hooks.BeforeScenarioAsync();
        harness.Artifacts.Require(ArtifactKind.FormsCsv);

        Assert.ThrowsAsync<ArtifactEvidenceException>(() => harness.Hooks.AfterScenarioAsync());
        Assert.Multiple(() =>
        {
            Assert.That(harness.Manifest().Outcome, Is.EqualTo(ArtifactOutcome.Failed));
            Assert.That(harness.Projection().Status, Is.EqualTo(ReportStatus.Fail));
            Assert.That(harness.Manifest().EvidenceErrors, Does.Contain("Missing required evidence: FormsCsv."));
        });
    }

    [Test]
    public async Task UnexpectedReportDefectPreservesAFailedManifestButDeletesPartialProjections()
    {
        var harness = Create();
        await harness.Hooks.BeforeScenarioAsync();
        var path = harness.Artifacts.CreateArtifactPath(ArtifactKind.ConsoleLog, "duplicate-contract", ".log");
        File.WriteAllText(path, "Controlled duplicate evidence");
        harness.Artifacts.RecordFile(ArtifactKind.ConsoleLog, "first", path);
        harness.Artifacts.RecordFile(ArtifactKind.ConsoleLog, "second", path);

        Assert.ThrowsAsync<ArtifactEvidenceException>(() => harness.Hooks.AfterScenarioAsync());
        Assert.Multiple(() =>
        {
            Assert.That(harness.Manifest().Outcome, Is.EqualTo(ArtifactOutcome.Failed));
            Assert.That(harness.Manifest().ComponentOutcomes["artifact-finalization"], Is.False);
            Assert.That(File.Exists(Path.Combine(harness.Artifacts.ScenarioRoot, ArtifactReportPaths.Report)), Is.False);
            Assert.That(File.Exists(Path.Combine(harness.Artifacts.ScenarioRoot, ArtifactReportPaths.Result)), Is.False);
        });
    }

    [Test]
    public async Task RecorderSnapshotFailureDoesNotPreventFailedManifestPersistence()
    {
        var harness = Create();
        await harness.Hooks.BeforeScenarioAsync();
        harness.Recorder.StartStep("an unfinished contract step");

        Assert.ThrowsAsync<ArtifactEvidenceException>(() => harness.Hooks.AfterScenarioAsync());
        Assert.That(harness.Manifest().Outcome, Is.EqualTo(ArtifactOutcome.Failed));
        Assert.That(harness.Manifest().ComponentOutcomes["report-metadata"], Is.False);
        Assert.That(File.Exists(Path.Combine(harness.Artifacts.ScenarioRoot, ArtifactReportPaths.Report)), Is.False);
    }

    [TestCase("0")]
    [TestCase("-1")]
    [TestCase("retry")]
    public void InvalidAttemptMetadataFailsWithoutLosingTheCanonicalManifest(string attempt)
    {
        Environment.SetEnvironmentVariable("TEST_ATTEMPT_NUMBER", attempt);
        var harness = Create();
        var exception = Assert.ThrowsAsync<InvalidOperationException>(() => harness.Hooks.BeforeScenarioAsync())!;
        harness.Context.SetOutcome(ScenarioExecutionStatus.TestError, exception);

        Assert.ThrowsAsync<ArtifactEvidenceException>(() => harness.Hooks.AfterScenarioAsync());
        Assert.That(harness.Manifest().Outcome, Is.EqualTo(ArtifactOutcome.Failed));
    }

    [TestCase(false, ArtifactOutcome.Passed)]
    [TestCase(true, ArtifactOutcome.Failed)]
    public async Task RequiredPersistenceFailuresAreFatalWhileOptionalFailuresAreExplicitWarnings(
        bool required, ArtifactOutcome expected)
    {
        var harness = Create();
        harness.DataPoolOptions.Required = required;
        harness.DataPool.Result = new(DataPoolPersistenceStatus.Unavailable, "Controlled offline persistence failure");
        await harness.Hooks.BeforeScenarioAsync();
        harness.State.QuoteNumber = "01234567";
        if (required)
            Assert.ThrowsAsync<ArtifactEvidenceException>(() => harness.Hooks.AfterScenarioAsync());
        else
            await harness.Hooks.AfterScenarioAsync();

        Assert.Multiple(() =>
        {
            Assert.That(harness.DataPool.Calls, Is.EqualTo(1));
            Assert.That(harness.Manifest().Outcome, Is.EqualTo(expected));
            Assert.That(harness.Projection().Diagnostics,
                Has.Some.Matches<ReportDiagnostic>(item => item.Component == "data-pool-persistence" &&
                    item.Level == (required ? "error" : "warning")));
        });
    }

    [Test]
    public async Task LogFlushFailureCannotBecomeASuccessfulScenario()
    {
        var harness = Create(failingCapture: ArtifactKind.ExecutionLog);
        await harness.Hooks.BeforeScenarioAsync();

        Assert.ThrowsAsync<ArtifactEvidenceException>(() => harness.Hooks.AfterScenarioAsync());
        Assert.That(harness.Manifest().Outcome, Is.EqualTo(ArtifactOutcome.Failed));
        Assert.That(harness.Manifest().ComponentOutcomes["execution-log"], Is.False);
    }

    [TestCase(ArtifactKind.Trace)]
    [TestCase(ArtifactKind.Video)]
    [Category("BrowserContract")]
    public async Task RequiredBrowserEvidenceFailureIsFatalAfterOtherResourcesAreClosed(ArtifactKind kind)
    {
        var harness = Create(api: false, failingCapture: kind);
        await harness.Hooks.BeforeScenarioAsync();
        await harness.Browser.Page.SetContentAsync("<p>Offline evidence failure contract</p>");

        Assert.ThrowsAsync<ArtifactEvidenceException>(() => harness.Hooks.AfterScenarioAsync());
        Assert.Multiple(() =>
        {
            Assert.That(harness.Manifest().Outcome, Is.EqualTo(ArtifactOutcome.Failed));
            Assert.That(harness.Browser.Page.IsClosed, Is.True);
            Assert.That(harness.Manifest().EvidenceErrors, Does.Contain($"Missing required evidence: {kind}."));
        });
    }

    [Test]
    [Category("BrowserContract")]
    public async Task RequiredCheckpointFailureStopsAtTheStepBoundaryAndKeepsAFailedManifest()
    {
        var harness = Create(api: false, failingCapture: ArtifactKind.Screenshot);
        await harness.Hooks.BeforeScenarioAsync();
        harness.StartStep("a required offline checkpoint cannot be captured");
        var failure = Assert.ThrowsAsync<ArtifactEvidenceException>(() => harness.Hooks.AfterStepAsync())!;
        harness.Context.SetOutcome(ScenarioExecutionStatus.TestError, failure);

        Assert.ThrowsAsync<ArtifactEvidenceException>(() => harness.Hooks.AfterScenarioAsync());
        Assert.That(harness.Manifest().Outcome, Is.EqualTo(ArtifactOutcome.Failed));
        Assert.That(harness.Projection().Steps.Single().Status, Is.EqualTo(ReportStatus.Fail));
    }

    [Test]
    public async Task BrowserContextTeardownFailureIsRecordedBeforeTheManifestIsFrozen()
    {
        var harness = Create();
        await harness.Hooks.BeforeScenarioAsync();
        typeof(TestHooks).GetField("_browserContext", BindingFlags.Instance | BindingFlags.NonPublic)!
            .SetValue(harness.Hooks, DispatchProxy.Create<IBrowserContext, FailingBrowserContext>());

        Assert.ThrowsAsync<ArtifactEvidenceException>(() => harness.Hooks.AfterScenarioAsync());
        Assert.That(harness.Manifest().Outcome, Is.EqualTo(ArtifactOutcome.Failed));
        Assert.That(harness.Manifest().ComponentOutcomes["browser-context-close"], Is.False);
        Assert.That(harness.Projection().Diagnostics,
            Has.Some.Matches<ReportDiagnostic>(item => item.Component == "browser-context-close"));
    }

    [Test]
    public async Task ExistingNonRunnableSgsCaseReportsSkippedWithoutAuthenticationOrBrowserEvidence()
    {
        var workflow = SgsExecutionCatalog.Load(Path.Combine(AppContext.BaseDirectory, "Resources")).Ledger.Workflows[0];
        var testCase = workflow.Cases.First(item => item.SourceStatus == SgsSourceCaseStatus.Active);
        var arguments = new OrderedDictionary();
        foreach (var (key, value) in testCase.Arguments)
            arguments.Add(key, value);
        var harness = Create(
            tags: ["SgsImported", "NonRunnable", "NoRetry", "AutomationId-" + workflow.AutomationFamily,
                workflow.ApplicationTag, workflow.RunTypeTag],
            arguments: arguments, feature: workflow.Feature);
        var ignored = Assert.ThrowsAsync<IgnoreException>(() => harness.Hooks.BeforeScenarioAsync())!;
        harness.Context.SetOutcome(ScenarioExecutionStatus.Skipped, ignored);
        await harness.Hooks.AfterScenarioAsync();

        Assert.Multiple(() =>
        {
            Assert.That(harness.Manifest().Outcome, Is.EqualTo(ArtifactOutcome.Skipped));
            Assert.That(harness.Projection().Status, Is.EqualTo(ReportStatus.Skip));
            Assert.That(harness.Tokens.Calls, Is.Zero);
            Assert.That(harness.Manifest().RequiredEvidence, Does.Not.Contain(ArtifactKind.Video));
            Assert.That(harness.Projection().Steps, Is.Empty);
        });
    }

    [Test]
    public async Task UntaggedLegacyScenarioIsNotGivenAnInventedAutomationIdentity()
    {
        var harness = Create(tags: ["API"]);
        await harness.Hooks.BeforeScenarioAsync();
        await harness.Hooks.AfterScenarioAsync();
        Assert.Multiple(() =>
        {
            Assert.That(harness.Manifest().AutomationId, Is.Null);
            Assert.That(harness.Manifest().Outcome, Is.EqualTo(ArtifactOutcome.Passed));
            Assert.That(File.Exists(Path.Combine(harness.Artifacts.ScenarioRoot, ArtifactReportPaths.Report)), Is.False);
        });
    }

    private Harness Create(
        bool api = true, ArtifactKind? failingCapture = null, string[]? tags = null,
        OrderedDictionary? arguments = null, string feature = "Offline reporting contract")
    {
        var harness = new Harness(_root, api, failingCapture, tags, arguments, feature);
        _harnesses.Add(harness);
        return harness;
    }

    private sealed class Harness : IAsyncDisposable
    {
        private readonly ServiceProvider _provider;
        private readonly IServiceScope _scope;
        public ContextManagerStub Context { get; }
        public TestHooks Hooks { get; }
        public ArtifactContext Artifacts { get; }
        public ScenarioContextData State { get; }
        public PlaywrightContext Browser { get; }
        public ScenarioReportRecorder Recorder { get; }
        public PersistenceClient DataPool { get; } = new();
        public DataPoolClientConfig DataPoolOptions { get; } = new();
        public TokenProvider Tokens { get; } = new();
        public string Identity { get; } = NUnit.Framework.TestContext.CurrentContext.Test.Name;

        public Harness(string root, bool api, ArtifactKind? failingCapture, string[]? tags,
            OrderedDictionary? arguments, string feature)
        {
            tags ??= api ? ["AutomationId-REPORT-CONTRACT", "API"] : ["AutomationId-REPORT-CONTRACT"];
            arguments ??= new OrderedDictionary { ["State"] = "AL" };
            Context = new ContextManagerStub(feature, tags, arguments);
            var automationId = ScenarioAutomationIdentity.Resolve(tags, [],
                ScenarioAutomationIdentity.ResolveQualifier(tags, arguments));
            Artifacts = new ArtifactContext(new ArtifactOptions { RootPath = root }, "offline-contract",
                Guid.NewGuid().ToString("N"), automationId: automationId, testIdentity: automationId == null ? null : Identity);
            var services = new ServiceCollection();
            new Startup().ConfigureServices(services);
            services.AddSingleton(Context.ScenarioContext);
            services.AddSingleton(Context.FeatureContext);
            services.AddSingleton<IObjectContainer>(Context.Container);
            services.Replace(ServiceDescriptor.Singleton<IConfiguration>(new ConfigurationBuilder().Build()));
            services.Replace(ServiceDescriptor.Singleton<IArtifactContext>(Artifacts));
            services.Replace(ServiceDescriptor.Singleton<IArtifactCaptureService>(
                new CaptureService(Artifacts, failingCapture)));
            services.Replace(ServiceDescriptor.Singleton<IAccessTokenProvider>(Tokens));
            services.Replace(ServiceDescriptor.Singleton<IApiService>(new ApiStub()));
            services.Replace(ServiceDescriptor.Singleton<IDataPoolClient>(DataPool));
            services.Replace(ServiceDescriptor.Singleton(DataPoolOptions));
            services.AddScoped<TestHooks>();
            _provider = services.BuildServiceProvider();
            _scope = _provider.CreateScope();
            Hooks = _scope.ServiceProvider.GetRequiredService<TestHooks>();
            State = _scope.ServiceProvider.GetRequiredService<ScenarioContextData>();
            Browser = _scope.ServiceProvider.GetRequiredService<PlaywrightContext>();
            Recorder = _scope.ServiceProvider.GetRequiredService<ScenarioReportRecorder>();
        }

        public void StartStep(string text)
        {
            Context.InitializeStepContext(new StepInfo(StepDefinitionType.When, text, null!, null!, Guid.NewGuid().ToString("N")));
            Hooks.BeforeStep();
        }

        public ArtifactManifest Manifest() =>
            ReportJson.Deserialize<ArtifactManifest>(File.ReadAllText(Path.Combine(Artifacts.ScenarioRoot, "manifest.json")));
        public ScenarioReportProjection Projection() =>
            ReportJson.Deserialize<ScenarioReportProjection>(File.ReadAllText(
                Path.Combine(Artifacts.ScenarioRoot, ArtifactReportPaths.Result)));
        public string ArtifactPath(ArtifactKind kind) =>
            Path.Combine(Artifacts.ScenarioRoot, Manifest().Artifacts.First(item => item.Kind == kind).RelativePath!);

        public async ValueTask DisposeAsync()
        {
            if (Browser.Page is { IsClosed: false })
                await Browser.Page.Context.Browser!.CloseAsync();
            _scope.Dispose();
            await _provider.DisposeAsync();
            Context.Container.Dispose();
        }
    }

    private sealed class ContextManagerStub : IContextManager
    {
        public ObjectContainer Container { get; } = new();
        public TestThreadContext TestThreadContext => throw new NotSupportedException();
        public FeatureContext FeatureContext { get; }
        public ScenarioContext ScenarioContext { get; }
        public ScenarioStepContext StepContext { get; private set; } = null!;
        public StepDefinitionType? CurrentTopLevelStepDefinitionType => StepContext?.StepInfo.StepDefinitionType;

        public ContextManagerStub(string feature, string[] tags, OrderedDictionary arguments)
        {
            Container.RegisterInstanceAs<IContextManager>(this);
            var scenario = new ScenarioInfo("Synthetic lifecycle contract", "", tags, arguments, [], "contract-pickle");
            ScenarioContext = Construct<ScenarioContext>(Container, scenario, null!, new TestObjectResolver());
            FeatureContext = Construct<FeatureContext>(Container,
                new FeatureInfo(CultureInfo.GetCultureInfo("en-US"), "", feature, "", []),
                ConfigurationLoader.GetDefault());
        }

        public void SetOutcome(ScenarioExecutionStatus status, Exception? exception = null)
        {
            typeof(ScenarioContext).GetProperty(nameof(ScenarioContext.ScenarioExecutionStatus))!.SetValue(ScenarioContext, status);
            typeof(ScenarioContext).GetProperty(nameof(ScenarioContext.TestError))!.SetValue(ScenarioContext, exception);
        }

        public void FailStep(Exception exception)
        {
            typeof(ScenarioStepContext).GetProperty(nameof(ScenarioStepContext.Status))!.SetValue(StepContext, ScenarioExecutionStatus.TestError);
            typeof(ScenarioStepContext).GetProperty(nameof(ScenarioStepContext.StepError))!.SetValue(StepContext, exception);
            SetOutcome(ScenarioExecutionStatus.TestError, exception);
        }

        public void InitializeStepContext(StepInfo stepInfo) => StepContext = Construct<ScenarioStepContext>(stepInfo);
        public void CleanupStepContext() => StepContext = null!;
        public void InitializeFeatureContext(FeatureInfo featureInfo) => throw new NotSupportedException();
        public void CleanupFeatureContext() { }
        public void InitializeScenarioContext(ScenarioInfo scenarioInfo, RuleInfo ruleInfo) => throw new NotSupportedException();
        public void CleanupScenarioContext() { }
        private static T Construct<T>(params object[] arguments) =>
            (T)Activator.CreateInstance(typeof(T), BindingFlags.Instance | BindingFlags.NonPublic, null,
                arguments, CultureInfo.InvariantCulture)!;
    }

    private sealed class TokenProvider : IAccessTokenProvider
    {
        public const string Token = "opaque-offline-contract-token";
        public int Calls { get; private set; }
        public Task<AccessToken> GetAccessTokenAsync(CancellationToken cancellationToken = default)
        {
            Calls++;
            return Task.FromResult(new AccessToken(Token, null));
        }
    }

    private sealed class ApiStub : IApiService
    {
        public bool HasAccessToken { get; private set; }
        public void SetAccessToken(AccessToken accessToken) => HasAccessToken = true;
        public Task<TResponse> PostJsonAsync<TRequest, TResponse>(string endpoint, TRequest request,
            ApiRetryMode retryMode = ApiRetryMode.None, CancellationToken cancellationToken = default) =>
            throw new NotSupportedException("Offline lifecycle contracts cannot make product requests.");
    }

    private sealed class PersistenceClient : IDataPoolClient
    {
        public int Calls { get; private set; }
        public DataPoolPersistenceResult Result { get; set; } = new(DataPoolPersistenceStatus.Persisted, "Offline contract persisted");
        public Task<DataPoolPersistenceResult> PersistAsync(QuoteRecord record, CancellationToken cancellationToken = default)
        {
            Calls++;
            return Task.FromResult(Result);
        }
    }

    private sealed class CaptureService(IArtifactContext artifacts, ArtifactKind? failingKind) : IArtifactCaptureService
    {
        private readonly ArtifactCaptureService _inner = new(artifacts);
        public Task<ArtifactRecord> CaptureAsync(ArtifactKind kind, string checkpoint, string extension,
            Func<string, Task> capture, bool required = true) =>
            kind == failingKind ? throw new IOException($"Controlled {kind} capture failure") :
                _inner.CaptureAsync(kind, checkpoint, extension, capture, required);
    }

    public class FailingBrowserContext : DispatchProxy
    {
        protected override object? Invoke(MethodInfo? targetMethod, object?[]? args) => targetMethod!.Name switch
        {
            "get_Pages" => Array.Empty<IPage>(),
            nameof(IBrowserContext.CloseAsync) => Task.FromException(new IOException("Controlled teardown failure")),
            _ => throw new NotSupportedException(targetMethod.Name)
        };
    }
}
