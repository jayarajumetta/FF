using System.Text.Json;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using PnCTestAutomation.Controls;
using PnCTestAutomation.Artifacts;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class ArtifactContextTests
{
    private string _temporaryRoot = null!;

    [SetUp]
    public void SetUp()
    {
        _temporaryRoot = Path.Combine(
            Path.GetTempPath(),
            "PnCTestAutomation.Tests",
            Guid.NewGuid().ToString("N"));
    }

    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(_temporaryRoot))
            Directory.Delete(_temporaryRoot, recursive: true);
    }

    [Test]
    public async Task ScreenshotRequestsAlwaysCaptureFreshUniqueArtifacts()
    {
        var context = CreateContext();
        var capture = new ArtifactCaptureService(context);
        var writes = 0;

        var first = await capture.CaptureAsync(
            ArtifactKind.Screenshot,
            "step-failure",
            ".png",
            path => File.WriteAllTextAsync(path, $"capture-{++writes}"));
        var second = await capture.CaptureAsync(
            ArtifactKind.Screenshot,
            "step-failure",
            ".png",
            path => File.WriteAllTextAsync(path, $"capture-{++writes}"));

        Assert.Multiple(() =>
        {
            Assert.That(writes, Is.EqualTo(2));
            Assert.That(first.RelativePath, Is.Not.EqualTo(second.RelativePath));
            Assert.That(
                File.ReadAllText(Path.Combine(context.ScenarioRoot, first.RelativePath!)),
                Is.EqualTo("capture-1"));
            Assert.That(
                File.ReadAllText(Path.Combine(context.ScenarioRoot, second.RelativePath!)),
                Is.EqualTo("capture-2"));
        });
    }

    [Test]
    public void RepositoryArtifactConfigurationBindsAndValidates()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.json"))
            .Build();
        var options = configuration
            .GetSection("Artifacts")
            .Get<ArtifactOptions>();

        Assert.Multiple(() =>
        {
            Assert.That(options, Is.Not.Null);
            Assert.That(() => options!.Validate(), Throws.Nothing);
            Assert.That(
                options!.RequiredOnFailure,
                Does.Contain(ArtifactKind.Screenshot));
        });
    }

    [Test]
    public void ArtifactConfigurationRejectsInvalidRequiredEvidence()
    {
        var options = new ArtifactOptions
        {
            RootPath = _temporaryRoot,
            ProfileName = "unit",
            RequiredOnFailure = [(ArtifactKind)999]
        };

        Assert.That(
            options.Validate,
            Throws.TypeOf<InvalidOperationException>()
                .With.Message.Contains("RequiredOnFailure"));
    }

    [Test]
    public void ArtifactPathsRejectTraversalAndOutOfRootTargets()
    {
        var context = CreateContext();
        var outside = Path.Combine(
            Path.GetDirectoryName(context.ScenarioRoot)!,
            "outside.txt");

        Assert.Multiple(() =>
        {
            Assert.That(
                () => context.CreateArtifactPath(
                    ArtifactKind.Screenshot,
                    @"..\escape",
                    ".png"),
                Throws.ArgumentException);
            Assert.That(
                () => context.RecordFile(
                    ArtifactKind.Screenshot,
                    "outside",
                    outside),
                Throws.TypeOf<ArtifactEvidenceException>()
                    .With.Message.Contains("escapes"));
        });
    }

    [Test]
    public void ArtifactPathsRejectReparsePoints()
    {
        var root = Path.GetFullPath(_temporaryRoot);
        var candidate = Path.Combine(root, "linked", "file.txt");

        Assert.That(
            () => ArtifactPathGuard.EnsureSafe(
                root,
                candidate,
                path => path.EndsWith("linked", StringComparison.Ordinal)
                    ? FileAttributes.Directory | FileAttributes.ReparsePoint
                    : null),
            Throws.TypeOf<ArtifactEvidenceException>()
                .With.Message.Contains("reparse"));
    }

    [Test]
    public void RequiredEvidenceFailsWhileOptionalEvidenceMayBeAbsent()
    {
        var optional = CreateContext("optional");
        var optionalManifest = optional.Complete(
            authoritativeScenarioFailed: false);

        var required = CreateContext("required");
        required.Require(ArtifactKind.Screenshot);
        var exception = Assert.Throws<ArtifactEvidenceException>(
            () => required.Complete(authoritativeScenarioFailed: false));

        Assert.Multiple(() =>
        {
            Assert.That(optionalManifest.Outcome, Is.EqualTo(ArtifactOutcome.Passed));
            Assert.That(exception!.Message, Does.Contain("Screenshot"));
        });
    }

    [Test]
    public void SkippedScenarioRemainsSkippedInSavedManifest()
    {
        var context = CreateContext("skipped");
        var manifest = context.Complete(ArtifactOutcome.Skipped);
        var saved = JsonSerializer.Deserialize<ArtifactManifest>(
            File.ReadAllText(Path.Combine(context.ScenarioRoot, "manifest.json")),
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        Assert.Multiple(() =>
        {
            Assert.That(manifest.Outcome, Is.EqualTo(ArtifactOutcome.Skipped));
            Assert.That(saved!.Outcome, Is.EqualTo(ArtifactOutcome.Skipped));
            Assert.That(manifest.AuthoritativeScenarioFailed, Is.False);
            Assert.That((int)ArtifactOutcome.Passed, Is.Zero);
            Assert.That((int)ArtifactOutcome.Failed, Is.EqualTo(1));
            Assert.That((int)ArtifactKind.RuntimeLocator, Is.EqualTo(12));
        });
    }

    [Test]
    public void SkipCannotHideMissingRequiredEvidence()
    {
        var context = CreateContext("incomplete-skip");
        context.Require(ArtifactKind.ExecutionLog);

        Assert.That(
            () => context.Complete(ArtifactOutcome.Skipped),
            Throws.TypeOf<ArtifactEvidenceException>().With.Message.Contains("ExecutionLog"));

        var saved = JsonSerializer.Deserialize<ArtifactManifest>(
            File.ReadAllText(Path.Combine(context.ScenarioRoot, "manifest.json")),
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        Assert.That(saved!.Outcome, Is.EqualTo(ArtifactOutcome.Failed));
    }

    [TestCase(ArtifactKind.ScenarioReportHtml, ".html", "<html></html>", "reports")]
    [TestCase(ArtifactKind.ScenarioResultJson, ".json", "{\"outcome\":\"Failed\"}", "reports")]
    [TestCase(ArtifactKind.ExecutionLog, ".log", "Scenario failed.", "logs")]
    [TestCase(ArtifactKind.ConsoleLog, ".log", "No console errors.", "logs")]
    [TestCase(ArtifactKind.NetworkLog, ".log", "No network errors.", "logs")]
    [TestCase(ArtifactKind.Har, ".har", "{\"log\":{}}", "network")]
    [TestCase(ArtifactKind.EvidenceBundle, ".zip", "test-bundle", "bundles")]
    public void RichReportEvidenceUsesTheExistingArtifactOwner(
        ArtifactKind kind,
        string extension,
        string content,
        string directory)
    {
        var context = CreateContext(kind.ToString());
        context.Require(kind);
        var path = context.CreateArtifactPath(kind, "checkpoint", extension);
        File.WriteAllText(path, content);
        var record = context.RecordFile(kind, "checkpoint", path);
        var manifest = context.Complete(ArtifactOutcome.Failed);

        Assert.Multiple(() =>
        {
            Assert.That(Path.GetDirectoryName(path), Is.EqualTo(Path.Combine(context.ScenarioRoot, directory)));
            Assert.That(manifest.Artifacts, Does.Contain(record));
            Assert.That(manifest.EvidenceErrors, Is.Empty);
        });
    }

    [TestCase(ArtifactKind.ScenarioReportHtml, ".html")]
    [TestCase(ArtifactKind.ScenarioResultJson, ".json")]
    [TestCase(ArtifactKind.Har, ".har")]
    public void CorruptRichEvidenceIsFatal(ArtifactKind kind, string extension)
    {
        var context = CreateContext("corrupt-report");
        var path = context.CreateArtifactPath(kind, "report", extension);
        File.WriteAllText(path, "not a report or structured document");
        context.RecordFile(kind, "report", path);

        Assert.That(
            () => context.Complete(ArtifactOutcome.Passed),
            Throws.TypeOf<ArtifactEvidenceException>().With.Message.Contains("missing or corrupt"));
    }

    [TestCase(ArtifactKind.Screenshot)]
    [TestCase(ArtifactKind.ScenarioReportHtml)]
    [TestCase(ArtifactKind.ExecutionLog)]
    public void FileEvidenceCannotBeSatisfiedByAMarker(ArtifactKind kind)
    {
        var context = CreateContext();
        Assert.That(() => context.RecordMarker(kind, "not-a-file"), Throws.ArgumentException);
    }

    [Test]
    public async Task RuntimeLocatorEvidenceRecordsScopeWithoutRawSelector()
    {
        var context = CreateContext("runtime-locator");
        context.Require(ArtifactKind.RuntimeLocator);
        var sink = new ArtifactControlEvidenceSink(context);
        var selector = ControlSelector.ByTestId("sensitive.runtime.id");

        await sink.RecordAsync(new ControlEvidence(
            "Policy state",
            selector,
            new ControlScope(
                "page 1 frame 'policy'",
                0,
                1,
                false,
                "FRAME-IDENTITY",
                "cldc-policy"),
            "select",
            ControlAssertion.SelectedValue));
        var manifest = context.Complete(false);
        var record = manifest.Artifacts.Single(item =>
            item.Kind == ArtifactKind.RuntimeLocator);
        var content = File.ReadAllText(Path.Combine(
            context.ScenarioRoot,
            record.RelativePath!));

        Assert.Multiple(() =>
        {
            Assert.That(content, Does.Contain("FRAME-IDENTITY"));
            Assert.That(content, Does.Contain("cldc-policy"));
            Assert.That(content, Does.Contain("SelectedValue"));
            Assert.That(content, Does.Not.Contain("sensitive.runtime.id"));
        });
    }

    [Test]
    public async Task DeletedEvidenceFailsManifestCompletion()
    {
        var context = CreateContext();
        var capture = new ArtifactCaptureService(context);
        var record = await capture.CaptureAsync(
            ArtifactKind.FormsHtml,
            "forms-report",
            ".html",
            path => File.WriteAllTextAsync(path, "<html></html>"));
        File.Delete(Path.Combine(context.ScenarioRoot, record.RelativePath!));

        Assert.That(
            () => context.Complete(authoritativeScenarioFailed: false),
            Throws.TypeOf<ArtifactEvidenceException>()
                .With.Message.Contains("missing or corrupt"));
    }

    [Test]
    public void CorruptStructuredEvidenceFailsManifestCompletion()
    {
        var context = CreateContext();
        context.Require(ArtifactKind.FormsXml);
        var path = context.CreateArtifactPath(
            ArtifactKind.FormsXml,
            "forms-response",
            ".xml");
        File.WriteAllText(path, "not xml");
        context.RecordFile(ArtifactKind.FormsXml, "forms-response", path);

        Assert.That(
            () => context.Complete(authoritativeScenarioFailed: false),
            Throws.TypeOf<ArtifactEvidenceException>()
                .With.Message.Contains("missing or corrupt"));
    }

    [Test]
    public void ExistingScenarioFailurePreservesPrimaryErrorAndRecordsEvidenceDefect()
    {
        var context = CreateContext();
        context.Require(
            ArtifactKind.Screenshot,
            ArtifactKind.Trace,
            ArtifactKind.Video);

        var manifest = context.Complete(authoritativeScenarioFailed: true);

        Assert.Multiple(() =>
        {
            Assert.That(manifest.Outcome, Is.EqualTo(ArtifactOutcome.Failed));
            Assert.That(
                manifest.EvidenceErrors,
                Does.Contain("Missing required evidence: Screenshot."));
            Assert.That(
                manifest.EvidenceErrors,
                Does.Contain("Missing required evidence: Trace."));
            Assert.That(
                manifest.EvidenceErrors,
                Does.Contain("Missing required evidence: Video."));
        });
    }

    [Test]
    public void ManifestUsesAuthoritativeFailureAndRejectsOutcomeDisagreement()
    {
        var failedScenario = CreateContext("scenario-failed");
        failedScenario.RecordComponentOutcome("forms-validation", succeeded: true);
        var failedManifest = failedScenario.Complete(
            authoritativeScenarioFailed: true);

        var disagreement = CreateContext("outcome-disagreement");
        disagreement.RecordComponentOutcome("forms-validation", succeeded: false);
        var exception = Assert.Throws<ArtifactEvidenceException>(
            () => disagreement.Complete(authoritativeScenarioFailed: false));

        Assert.Multiple(() =>
        {
            Assert.That(failedManifest.Outcome, Is.EqualTo(ArtifactOutcome.Failed));
            Assert.That(failedManifest.AuthoritativeScenarioFailed, Is.True);
            Assert.That(exception!.Message, Does.Contain("disagrees"));
        });
    }

    [Test]
    public async Task ManifestContainsEveryRecordedArtifactAndTimingMetadata()
    {
        var context = CreateContext();
        var capture = new ArtifactCaptureService(context);
        await capture.CaptureAsync(
            ArtifactKind.Screenshot,
            "checkpoint",
            ".png",
            path => File.WriteAllTextAsync(path, "sensitive-field-value"));
        context.RecordMarker(ArtifactKind.QuoteHandoff, "quote-captured");

        var manifest = context.Complete(authoritativeScenarioFailed: false);
        var manifestPath = Path.Combine(context.ScenarioRoot, "manifest.json");
        var saved = JsonSerializer.Deserialize<ArtifactManifest>(
            File.ReadAllText(manifestPath),
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        Assert.Multiple(() =>
        {
            Assert.That(saved, Is.Not.Null);
            Assert.That(saved!.Artifacts, Has.Count.EqualTo(4));
            Assert.That(saved.Artifacts.Select(item => item.Kind), Does.Contain(ArtifactKind.Screenshot));
            Assert.That(saved.Artifacts.Select(item => item.Kind), Does.Contain(ArtifactKind.QuoteHandoff));
            Assert.That(saved.Artifacts.Select(item => item.Kind), Does.Contain(ArtifactKind.TimingSummary));
            Assert.That(saved.Artifacts.Select(item => item.Kind), Does.Contain(ArtifactKind.TrxMetadata));
            Assert.That(saved.Outcome, Is.EqualTo(ArtifactOutcome.Passed));
            Assert.That(saved.EvidenceErrors, Is.Empty);
            Assert.That(saved.TrxMetadataPath, Is.Not.Empty);
            Assert.That(saved.TimingSummaryPath, Is.Not.Empty);
            Assert.That(manifest.Artifacts, Has.Count.EqualTo(saved.Artifacts.Count));
            Assert.That(File.ReadAllText(manifestPath), Does.Not.Contain("sensitive-field-value"));
        });
    }

    private ArtifactContext CreateContext(string scenarioId = "scenario-1") =>
        new(
            new ArtifactOptions
            {
                RootPath = _temporaryRoot,
                ProfileName = "unit",
                RequiredOnFailure = []
            },
            "run-1",
            scenarioId,
            () => new DateTimeOffset(2026, 1, 2, 3, 4, 5, TimeSpan.Zero));
}
