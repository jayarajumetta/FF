using System.Xml.Linq;
using NUnit.Framework;
using PnCTestAutomation.Artifacts;
using PnCTestAutomation.BusinessOutcomes;
using PnCTestAutomation.Clients;
using PnCTestAutomation.Models;
using PnCTestAutomation.Services;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class FormsOrchestrationTests
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
    public async Task PassingFormsValidationProducesCompleteEvidence()
    {
        var artifacts = CreateArtifacts("pass");
        var service = CreateService(
            artifacts,
            new FakeValidationService(PassingSummary()),
            ValidXml(),
            new FakeEvidenceWriter());

        var result = await service.ValidateAsync(Request());
        var manifest = artifacts.Complete(authoritativeScenarioFailed: false);

        Assert.Multiple(() =>
        {
            Assert.That(result.Summary.AllPassed, Is.True);
            Assert.That(result.Evidence.Select(item => item.Kind), Is.EquivalentTo(new[]
            {
                ArtifactKind.FormsXml,
                ArtifactKind.FormsCsv,
                ArtifactKind.FormsHtml,
                ArtifactKind.FormsMarkdown,
                ArtifactKind.FormsTrx
            }));
            Assert.That(manifest.Outcome, Is.EqualTo(ArtifactOutcome.Passed));
            Assert.That(manifest.ComponentOutcomes["forms-validation"], Is.True);
            Assert.That(manifest.RequiredEvidence, Is.SupersetOf(result.Evidence.Select(item => item.Kind)));
        });
    }

    [Test]
    public void FormsMismatchFailsEvenWhenCallerWouldOtherwisePass()
    {
        var artifacts = CreateArtifacts("mismatch");
        var service = CreateService(
            artifacts,
            new FakeValidationService(FailingSummary()),
            ValidXml(),
            new FakeEvidenceWriter());

        var exception = Assert.ThrowsAsync<FormsValidationException>(
            async () => await service.ValidateAsync(Request()));
        var manifest = artifacts.Complete(authoritativeScenarioFailed: true);

        Assert.Multiple(() =>
        {
            Assert.That(exception!.Stage, Is.EqualTo("business comparison"));
            Assert.That(manifest.Outcome, Is.EqualTo(ArtifactOutcome.Failed));
            Assert.That(manifest.ComponentOutcomes["forms-validation"], Is.False);
        });
    }

    [Test]
    public async Task PassingFormsCheckCannotEraseAnEarlierRealFailure()
    {
        var artifacts = CreateArtifacts("sticky-failure");
        var failedCheck = CreateService(
            artifacts, new FakeValidationService(FailingSummary()),
            ValidXml(), new FakeEvidenceWriter());
        var passingCheck = CreateService(
            artifacts, new FakeValidationService(PassingSummary()),
            ValidXml(), new FakeEvidenceWriter());

        Assert.ThrowsAsync<FormsValidationException>(async () =>
            await failedCheck.ValidateAsync(Request()));
        var result = await passingCheck.ValidateAsync(Request());

        Assert.That(result.Summary.AllPassed, Is.True);
        Assert.That(() => artifacts.Complete(authoritativeScenarioFailed: false),
            Throws.TypeOf<ArtifactEvidenceException>().With.Message.Contains("failed required component"));
    }

    [Test]
    public void MissingBaselineFailsClosed()
    {
        var artifacts = CreateArtifacts("missing-baseline");
        var service = CreateService(
            artifacts,
            new FakeValidationService(
                new FileNotFoundException("sensitive baseline path")),
            ValidXml(),
            new FakeEvidenceWriter());

        var exception = Assert.ThrowsAsync<FormsValidationException>(
            async () => await service.ValidateAsync(Request()));
        var manifest = artifacts.Complete(authoritativeScenarioFailed: true);

        Assert.Multiple(() =>
        {
            Assert.That(exception!.Stage, Is.EqualTo("baseline resolution"));
            Assert.That(exception.ToString(), Does.Not.Contain("sensitive baseline path"));
            Assert.That(manifest.ComponentOutcomes["forms-validation"], Is.False);
        });
    }

    [Test]
    public void FormsApiFailureFailsClosedWithoutSensitiveResponseDetails()
    {
        var service = CreateService(
            CreateArtifacts("api-failure"),
            new FakeValidationService(PassingSummary()),
            formsXml: null,
            new FakeEvidenceWriter(),
            apiFailure: new HttpRequestException("sensitive response body"));

        var exception = Assert.ThrowsAsync<FormsValidationException>(
            async () => await service.ValidateAsync(Request()));

        Assert.Multiple(() =>
        {
            Assert.That(exception!.Stage, Is.EqualTo("Forms API request"));
            Assert.That(exception.ToString(), Does.Not.Contain("sensitive response body"));
        });
    }

    [Test]
    public void SessionFailureFailsClosedWithoutCredentialDetails()
    {
        var artifacts = CreateArtifacts("session-failure");
        var service = new FormsOrchestrationService(
            new FakeSessionProvider(
                new InvalidOperationException("username=user password=secret")),
            new FakeFormsApiClient(ValidXml(), failure: null),
            new FakeValidationService(PassingSummary()),
            new FakeEvidenceWriter(),
            artifacts,
            new ArtifactCaptureService(artifacts),
            CreateVerifier(artifacts),
            new DuckCreekFormsConfig
            {
                Manuscript = "Manuscript",
                PrintJob = "PrintJob"
            });

        var exception = Assert.ThrowsAsync<FormsValidationException>(
            async () => await service.ValidateAsync(Request()));

        Assert.Multiple(() =>
        {
            Assert.That(exception!.Stage, Is.EqualTo("session acquisition"));
            Assert.That(exception.ToString(), Does.Not.Contain("password=secret"));
        });
    }

    [Test]
    public void EmptyFormsOutputFailsClosed()
    {
        var service = CreateService(
            CreateArtifacts("invalid-response"),
            new FakeValidationService(PassingSummary()),
            "<server><responses /></server>",
            new FakeEvidenceWriter());

        var exception = Assert.ThrowsAsync<FormsValidationException>(
            async () => await service.ValidateAsync(Request()));

        Assert.That(exception!.Stage, Is.EqualTo("response validation"));
    }

    [Test]
    public void FormsMetadataMismatchFailsClosed()
    {
        var service = CreateService(
            CreateArtifacts("metadata-mismatch"),
            new FakeValidationService(PassingSummary()),
            "<server><responses><FormsEngine.initPrintJobRs returnSuccessStatus=\"1\"><printJob name=\"Wrong\" manuscript=\"Manuscript\"><printDoc name=\"FORM-A\" selected=\"2\" /></printJob></FormsEngine.initPrintJobRs></responses></server>",
            new FakeEvidenceWriter());

        var exception = Assert.ThrowsAsync<BusinessOutcomeException>(
            async () => await service.ValidateAsync(Request()));

        Assert.That(exception!.Outcome, Is.EqualTo("forms contract"));
    }

    [TestCase(true)]
    [TestCase(false)]
    public void MissingReturnStatusKeepsRowComparisonEvidenceAndFailingContractOutcome(bool rowsPass)
    {
        var artifacts = CreateArtifacts("contract-evidence");
        var summary = rowsPass ? PassingSummary() : FailingSummary();
        var service = CreateService(
            artifacts, new FakeValidationService(summary),
            ValidXml().Replace(" returnSuccessStatus=\"1\"", "", StringComparison.Ordinal),
            new FormsEvidenceWriter(new FormsValidationService(new DuckCreekFormsConfig())));

        var failure = Assert.ThrowsAsync<BusinessOutcomeException>(async () =>
            await service.ValidateAsync(Request()));
        var manifest = artifacts.Complete(authoritativeScenarioFailed: true);
        string EvidencePath(ArtifactKind kind) => Path.Combine(artifacts.ScenarioRoot,
            manifest.Artifacts.Single(item => item.Kind == kind).RelativePath!);
        var xml = XDocument.Load(EvidencePath(ArtifactKind.FormsTrx));
        XNamespace ns = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010";
        Assert.Multiple(() =>
        {
            Assert.That(failure!.Outcome, Is.EqualTo("forms contract"));
            Assert.That(summary.ContractFailures, Has.Count.EqualTo(1));
            Assert.That(summary.AllPassed, Is.False);
            Assert.That(summary.Results.Single().Result, Is.EqualTo(rowsPass ? "PASS" : "FAIL"));
            Assert.That(summary.TotalForms, Is.EqualTo(1), "A contract error must not invent another form.");
            Assert.That(manifest.EvidenceErrors, Is.Empty);
            Assert.That(manifest.Outcome, Is.EqualTo(ArtifactOutcome.Failed));
            Assert.That(manifest.ComponentOutcomes["business-forms-contract"], Is.False);
            Assert.That(manifest.ComponentOutcomes["forms-validation"], Is.False);
            Assert.That(File.ReadAllText(EvidencePath(ArtifactKind.FormsCsv)), Does.Contain("FORM-A"));
            Assert.That(File.ReadAllText(EvidencePath(ArtifactKind.FormsHtml)),
                Does.Contain("FAILURES DETECTED").And.Contain("Forms contract failures"));
            Assert.That(File.ReadAllText(EvidencePath(ArtifactKind.FormsMarkdown)),
                Does.Contain("FAILURES DETECTED").And.Contain("Forms contract failures"));
            Assert.That(xml.Descendants(ns + "UnitTestResult").Single().Attribute("outcome")!.Value, Is.EqualTo("Failed"));
            Assert.That(xml.Descendants(ns + "Counters").Single().Attribute("failed")!.Value, Is.EqualTo("1"));
            Assert.That(xml.Descendants(ns + "ErrorInfo").Single().Value, Does.Contain("Forms contract"));
        });
    }

    [Test]
    public void MissingRequiredReportFailsClosed()
    {
        var artifacts = CreateArtifacts("missing-report");
        var service = CreateService(
            artifacts,
            new FakeValidationService(PassingSummary()),
            ValidXml(),
            new FakeEvidenceWriter(skip: ArtifactKind.FormsHtml));

        var exception = Assert.ThrowsAsync<ArtifactEvidenceException>(
            async () => await service.ValidateAsync(Request()));

        Assert.Multiple(() =>
        {
            Assert.That(exception!.Message, Does.Contain("FormsHtml"));
            Assert.That(
                artifacts.Records.Any(item => item.Kind == ArtifactKind.FormsHtml),
                Is.False);
        });
    }

    private FormsOrchestrationService CreateService(
        IArtifactContext artifacts,
        IFormsValidationService validation,
        string? formsXml,
        IFormsEvidenceWriter writer,
        Exception? apiFailure = null) =>
        new(
            new FakeSessionProvider(),
            new FakeFormsApiClient(formsXml, apiFailure),
            validation,
            writer,
            artifacts,
            new ArtifactCaptureService(artifacts),
            CreateVerifier(artifacts),
            new DuckCreekFormsConfig
            {
                Manuscript = "Manuscript",
                PrintJob = "PrintJob"
            });

    private static BusinessOutcomeVerifier CreateVerifier(
        IArtifactContext artifacts)
    {
        var context = new BusinessOutcomeContext();
        context.Set(new ExpectedOutcomeProfile
        {
            ProfileId = "unit-profile",
            Version = "1.0.0",
            ScenarioProfile = "sfp-basic",
            Environment = "qa",
            State = "MN",
            Company = "Company",
            Mode = BusinessOutcomeProfileMode.Approved,
            Forms = new FormsOutcomeExpectation
            {
                BaselineId = "SFP:BASIC",
                BaselineVersion = "v1",
                BaselineChecksum = new string('A', 64),
                Manuscript = "Manuscript",
                PrintJob = "PrintJob",
                ExpectedReturnSuccessStatuses = ["1"],
                RequireRoleBasedSecurity = true
            }
        });
        context.ConfirmApplicability("qa", "MN", "Company");
        return new BusinessOutcomeVerifier(
            context,
            new ArtifactCaptureService(artifacts),
            artifacts);
    }

    private ArtifactContext CreateArtifacts(string scenarioId) =>
        new(
            new ArtifactOptions
            {
                RootPath = _temporaryRoot,
                ProfileName = "unit",
                RequiredOnFailure = []
            },
            "run-1",
            scenarioId);

    private static FormsValidationRequest Request() =>
        new("Q-100", "MN", "SFP", "BASIC");

    private static FormsValidationSummary PassingSummary() =>
        new()
        {
            LOB = "SFP",
            State = "MN",
            QuoteId = "Q-100",
            TotalForms = 1,
            Passed = 1,
            Results =
            [
                new FormValidationResult
                {
                    FormName = "FORM-A",
                    ExpectedStatus = "YM",
                    ActualSelected = 2,
                    Result = "PASS",
                    ResultCode = "C1",
                    Message = "Matched."
                }
            ]
        };

    private static FormsValidationSummary FailingSummary()
    {
        var summary = PassingSummary();
        summary.Passed = 0;
        summary.Failed = 1;
        summary.Results =
        [
            new FormValidationResult
            {
                FormName = "FORM-A",
                Result = "FAIL",
                Message = "Expected mandatory form was missing."
            }
        ];
        return summary;
    }

    private static string ValidXml() =>
        """
        <server>
          <responses>
            <Session.resumeRs status="success" />
            <FormsEngine.initPrintJobRs returnSuccessStatus="1">
              <printJob name="PrintJob" manuscript="Manuscript">
                <roleBasedSecurity />
                <printDoc name="FORM-A" selected="2" docType="PDF" caption="Form A" />
              </printJob>
            </FormsEngine.initPrintJobRs>
          </responses>
        </server>
        """;

    private sealed class FakeSessionProvider : IFormsSessionProvider
    {
        private readonly Exception? _failure;

        public FakeSessionProvider(Exception? failure = null)
        {
            _failure = failure;
        }

        public Task<FormsSession> PrepareSessionAsync(string quoteNumber) =>
            _failure == null
                ? Task.FromResult(
                    new FormsSession(
                        "sensitive-session-id",
                        quoteNumber))
                : Task.FromException<FormsSession>(_failure);
    }

    private sealed class FakeFormsApiClient : IFormsApiClient
    {
        private readonly string? _xml;
        private readonly Exception? _failure;

        public FakeFormsApiClient(string? xml, Exception? failure)
        {
            _xml = xml;
            _failure = failure;
        }

        public Task<string> GetFormsAsync(
            string sessionId,
            string manuscript,
            string printJob)
        {
            if (_failure != null)
                throw _failure;
            return Task.FromResult(_xml!);
        }
    }

    private sealed class FakeValidationService : IFormsValidationService
    {
        private readonly FormsValidationSummary? _summary;
        private readonly Exception? _baselineFailure;

        public FakeValidationService(FormsValidationSummary summary)
        {
            _summary = summary;
        }

        public FakeValidationService(Exception baselineFailure)
        {
            _baselineFailure = baselineFailure;
        }

        public List<ExpectedFormEntry> LoadExpectedFormsForLob(
            string lob,
            string state,
            string testCase = "BASIC")
        {
            if (_baselineFailure != null)
                throw _baselineFailure;
            return
            [
                new ExpectedFormEntry
                {
                    FormName = "FORM-A",
                    ExpectedStatus = "YM"
                }
            ];
        }

        public FormsBaselineSnapshot LoadExpectedBaseline(
            string lob,
            string state,
            string testCase = "BASIC") =>
            new(
                LoadExpectedFormsForLob(lob, state, testCase),
                "SFP:BASIC",
                "v1",
                new string('A', 64));

        public FormsValidationSummary Validate(
            List<ExpectedFormEntry> expected,
            List<ActualFormEntry> actual,
            string lob,
            string state,
            string quoteId) =>
            _summary!;

        public string WriteResultsCsv(
            FormsValidationSummary summary,
            string outputPath) =>
            throw new AssertionException("The evidence writer owns output.");
    }

    private sealed class FakeEvidenceWriter : IFormsEvidenceWriter
    {
        private readonly ArtifactKind? _skip;

        public FakeEvidenceWriter(ArtifactKind? skip = null)
        {
            _skip = skip;
        }

        public void WriteCsv(FormsValidationSummary summary, string path) =>
            Write(ArtifactKind.FormsCsv, path);

        public void WriteHtml(FormsValidationSummary summary, string path) =>
            Write(ArtifactKind.FormsHtml, path);

        public void WriteMarkdown(FormsValidationSummary summary, string path) =>
            Write(ArtifactKind.FormsMarkdown, path);

        public void WriteTrx(FormsValidationSummary summary, string path) =>
            Write(ArtifactKind.FormsTrx, path);

        private void Write(ArtifactKind kind, string path)
        {
            if (_skip == kind)
                return;

            var content = kind switch
            {
                ArtifactKind.FormsCsv =>
                    "Form,Expected,Actual,Result,Code,Message\r\nFORM-A,YM,Mandatory,PASS,C1,Matched.",
                ArtifactKind.FormsHtml => "<!DOCTYPE html><html></html>",
                ArtifactKind.FormsMarkdown => "# Forms Validation - SFP / MN",
                ArtifactKind.FormsTrx => "<TestRun />",
                _ => throw new AssertionException($"Unsupported evidence kind: {kind}")
            };
            File.WriteAllText(path, content);
        }
    }
}
