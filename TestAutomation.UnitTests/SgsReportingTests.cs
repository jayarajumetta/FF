using System.Collections.Immutable;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using NUnit.Framework;
using PnCTestAutomation.Artifacts;
using PnCTestAutomation.Reporting;
using PnCTestAutomation.SgsReport;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public sealed class SgsReportingTests
{
    private string _root = null!;
    private static readonly DateTimeOffset Started = new(2026, 9, 22, 13, 0, 0, TimeSpan.Zero);
    private static readonly byte[] Png = Convert.FromBase64String(
        "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+/l9sAAAAASUVORK5CYII=");

    [SetUp]
    public void SetUp()
    {
        _root = Path.Combine(Path.GetTempPath(), "PnCTestAutomation.Tests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(_root);
    }

    [TearDown]
    public void TearDown() => Directory.Delete(_root, true);

    [Test]
    public void ProjectorTakesOutcomeOnlyFromManifestAndPreservesTeardownFailure()
    {
        var fixture = CreateScenario(ArtifactOutcome.Failed);
        fixture = fixture with
        {
            Manifest = fixture.Manifest with
            {
                AuthoritativeScenarioFailed = false,
                ComponentOutcomes = ImmutableDictionary<string, bool>.Empty.Add("browser-teardown", false)
            }
        };
        var projection = ScenarioReportProjector.Project(fixture.Manifest, fixture.Metadata);
        Assert.Multiple(() =>
        {
            Assert.That(projection.Status, Is.EqualTo(ReportStatus.Fail));
            Assert.That(projection.Steps.All(step => step.Status == ReportStatus.Pass), Is.True);
            Assert.That(projection.ComponentOutcomes["browser-teardown"], Is.False);
        });
        Save(fixture);
        var result = Aggregate(("case-1", "Failed"));
        Assert.Multiple(() =>
        {
            Assert.That(result.ExitCode, Is.EqualTo(1));
            Assert.That(File.ReadAllText(result.ReportPath), Does.Contain("browser-teardown"));
        });
    }

    [TestCase(ArtifactOutcome.Passed, "Passed", 0, "PASS")]
    [TestCase(ArtifactOutcome.Failed, "Failed", 1, "FAIL")]
    [TestCase(ArtifactOutcome.Skipped, "NotExecuted", 1, "SKIP")]
    public void CanonicalStatusControlsAllOutputs(ArtifactOutcome outcome, string canonical, int exit, string status)
    {
        var fixture = CreateScenario(outcome);
        var result = Aggregate(("case-1", canonical));
        var summary = ReadSummary(result);
        var xml = XDocument.Load(Path.Combine(_root, "consolidated", "output.xml"));
        Assert.Multiple(() =>
        {
            Assert.That(result.ExitCode, Is.EqualTo(exit));
            Assert.That(summary.GetProperty("status").GetString(), Is.EqualTo(status));
            Assert.That(summary.GetProperty("total").GetInt32(), Is.EqualTo(1));
            Assert.That(summary.GetProperty("passed").GetInt32(), Is.EqualTo(outcome == ArtifactOutcome.Passed ? 1 : 0));
            Assert.That(summary.GetProperty("failed").GetInt32(), Is.EqualTo(outcome == ArtifactOutcome.Failed ? 1 : 0));
            Assert.That(summary.GetProperty("skipped").GetInt32(), Is.EqualTo(outcome == ArtifactOutcome.Skipped ? 1 : 0));
            Assert.That(xml.Descendants("test").Single().Element("status")!.Attribute("status")!.Value, Is.EqualTo(status));
            Assert.That(xml.Root!.Attribute("generator")!.Value, Does.Contain("not canonical"));
            Assert.That(xml.Descendants("stat").Single().Attribute("ok")!.Value,
                Is.EqualTo(xml.Descendants("stat").Single().Attribute("pass")!.Value));
            foreach (var file in new[] { "report.html", "log.html", "output.xml", "summary.json" })
                Assert.That(new FileInfo(Path.Combine(_root, "consolidated", file)).Length, Is.GreaterThan(0));
            Assert.That(File.Exists(ReportPaths.Resolve(fixture.Directory, ScenarioReportWriter.ReportRelativePath)), Is.True);
            Assert.That(File.Exists(ReportPaths.Resolve(fixture.Directory, ScenarioReportWriter.ResultRelativePath)), Is.True);
        });
    }

    [Test]
    public void NUnitCanonicalInputUsesSameAggregatorAndTruthfulSkipCounts()
    {
        CreateScenario(ArtifactOutcome.Skipped);
        var canonical = Path.Combine(_root, "canonical.xml");
        TestCanonicalFiles.NUnit(("case-1", "Skipped")).Save(canonical);
        var result = new ReportAggregator().Generate(Options(canonical));
        Assert.That(ReadSummary(result).GetProperty("skipped").GetInt32(), Is.EqualTo(1));
        Assert.That(result.ExitCode, Is.EqualTo(1));
    }

    [Test]
    public void ConsolidationPreservesScenarioOnlyIdentityRedactionAndRawIdentityCorrelation()
    {
        const string identity = "QuoteFor(\"PrivateCustomer\",\"111 Private Lane\")";
        var fixture = CreateScenario(ArtifactOutcome.Passed, identity: identity);
        fixture = fixture with
        {
            Manifest = fixture.Manifest with
            {
                RunId = "run-PrivateCustomer",
                ScenarioId = "scenario-PrivateCustomer",
                AutomationId = "SGS-UNIT:PrivateCustomer",
                ProfileName = "profile-PrivateCustomer"
            }
        };
        File.WriteAllText(Path.Combine(fixture.Directory, "manifest.json"), ReportJson.Serialize(fixture.Manifest));
        ScenarioReportWriter.Write(fixture.Directory, fixture.Manifest, fixture.Metadata,
            new ReportRedactor(["PrivateCustomer", "111 Private Lane"]));

        var result = Aggregate((identity, "Passed"));
        var projection = result.Report.Tests.Single().Attempts.Single().Projection;
        Assert.Multiple(() =>
        {
            Assert.That(result.ExitCode, Is.Zero);
            Assert.That(result.Report.Issues, Is.Empty);
            Assert.That(result.Report.Tests.Single().TestIdentity, Is.EqualTo(projection.TestFullName));
            Assert.That(projection.TestIdentityHash, Is.EqualTo(ScenarioReportProjector.IdentityHash(identity)));
            Assert.That(projection.ManifestFingerprint,
                Is.EqualTo(ScenarioReportProjector.ManifestFingerprint(fixture.Manifest)));
            Assert.That(projection.AutomationId, Is.EqualTo("SGS-UNIT:[REDACTED]"));
            Assert.That(projection.TestFullName, Is.EqualTo("QuoteFor(\"[REDACTED]\",\"[REDACTED]\")"));
            foreach (var name in new[] { "report.html", "log.html", "output.xml", "summary.json" })
                Assert.That(File.ReadAllText(Path.Combine(_root, "consolidated", name)),
                    Does.Not.Contain("PrivateCustomer").And.Not.Contain("111 Private Lane"));
        });
    }

    [TestCase("different-case")]
    [TestCase("case-1[REDACTED]invented-suffix")]
    public void DisplayIdentityCannotBeChangedIntoAnUnrelatedExecution(string displayIdentity)
    {
        var fixture = CreateScenario(ArtifactOutcome.Passed);
        var path = ReportPaths.Resolve(fixture.Directory, ScenarioReportWriter.ResultRelativePath);
        var saved = ReportJson.Deserialize<ScenarioReportProjection>(File.ReadAllText(path));
        File.WriteAllText(path, ReportJson.Serialize(saved with { TestFullName = displayIdentity }));

        var result = Aggregate(("case-1", "Passed"));
        Assert.Multiple(() =>
        {
            Assert.That(result.ExitCode, Is.EqualTo(2));
            Assert.That(result.Report.Issues.Any(issue => issue.Code == "projection-mismatch"), Is.True);
            Assert.That(result.Report.Tests.Single().TestIdentity, Does.Not.Contain(displayIdentity));
        });
    }

    [Test]
    public void ScenarioOwnedQuoteHandoffMarkerSatisfiesTheCanonicalMarkerRequirement()
    {
        var owner = CreateOwner();
        owner.Require(ArtifactKind.QuoteHandoff);
        owner.RecordMarker(ArtifactKind.QuoteHandoff, "quote-captured");
        owner.Complete(ArtifactOutcome.Passed, snapshot =>
        {
            var files = ScenarioReportWriter.Write(owner.ScenarioRoot, snapshot, OwnerMetadata());
            Assert.That(files.Issues, Is.Empty);
        });
        var result = Aggregate(("owner-case", "Passed"));
        Assert.Multiple(() =>
        {
            Assert.That(result.ExitCode, Is.Zero);
            Assert.That(result.Report.Issues, Is.Empty);
            Assert.That(result.Report.Tests.Single().Attempts.Single().Evidence.Files
                .Any(file => file.Kind == nameof(ArtifactKind.QuoteHandoff)), Is.False);
        });
    }

    [TestCase(ArtifactKind.FormsCsv)]
    [TestCase(ArtifactKind.Video)]
    public void MarkerCannotReplaceRequiredFileEvidence(ArtifactKind kind)
    {
        var fixture = CreateScenario(ArtifactOutcome.Passed, media: false);
        fixture = fixture with
        {
            Manifest = fixture.Manifest with
            {
                RequiredEvidence = fixture.Manifest.RequiredEvidence.Append(kind).ToArray(),
                Artifacts = fixture.Manifest.Artifacts.Append(
                    new ArtifactRecord(kind, "invalid-file-marker", null, Started)).ToArray()
            }
        };
        Save(fixture);
        var result = Aggregate(("case-1", "Passed"));
        Assert.That(result.Report.Issues.Any(issue =>
            issue.Code == "required-evidence" && issue.Message.Contains(kind.ToString())), Is.True);
        Assert.That(result.ExitCode, Is.EqualTo(2));
    }

    [Test]
    public void MissingQuoteHandoffCannotBeSynthesizedDuringConsolidation()
    {
        var fixture = CreateScenario(ArtifactOutcome.Passed);
        fixture = fixture with
        {
            Manifest = fixture.Manifest with
            {
                RequiredEvidence = fixture.Manifest.RequiredEvidence.Append(ArtifactKind.QuoteHandoff).ToArray()
            }
        };
        Save(fixture);
        var result = Aggregate(("case-1", "Passed"));
        Assert.That(result.Report.Issues.Any(issue =>
            issue.Code == "required-evidence" && issue.Message.Contains(nameof(ArtifactKind.QuoteHandoff))), Is.True);
        Assert.That(result.ExitCode, Is.EqualTo(2));
    }

    [TestCase(ArtifactOutcome.Passed, "Passed", 0)]
    [TestCase(ArtifactOutcome.Failed, "Failed", 1)]
    [TestCase(ArtifactOutcome.Skipped, "NotExecuted", 1)]
    public void ExistingArtifactOwnerFinalizesTheExactWriterSnapshot(
        ArtifactOutcome outcome, string canonical, int expectedExit)
    {
        var context = CreateOwner();
        var metadata = OwnerMetadata();
        ArtifactManifest? supplied = null;
        var manifest = context.Complete(outcome, snapshot =>
        {
            supplied = snapshot;
            var files = ScenarioReportWriter.Write(context.ScenarioRoot, snapshot, metadata);
            Assert.That(files.Issues, Is.Empty);
        });
        var saved = ReportJson.Deserialize<ArtifactManifest>(
            File.ReadAllText(Path.Combine(context.ScenarioRoot, "manifest.json")));
        var projected = ReportJson.Deserialize<ScenarioReportProjection>(
            File.ReadAllText(ReportPaths.Resolve(context.ScenarioRoot, ArtifactReportPaths.Result)));
        Assert.Multiple(() =>
        {
            Assert.That(manifest, Is.SameAs(supplied));
            Assert.That(ReportJson.Serialize(saved), Is.EqualTo(ReportJson.Serialize(manifest)));
            Assert.That(projected.ManifestFingerprint, Is.EqualTo(ScenarioReportProjector.ManifestFingerprint(saved)));
            Assert.That(context.Records.Count(item => item.Kind == ArtifactKind.ScenarioReportHtml), Is.EqualTo(1));
            Assert.That(context.Records.Count(item => item.Kind == ArtifactKind.ScenarioResultJson), Is.EqualTo(1));
            Assert.That(Aggregate(("owner-case", canonical)).ExitCode, Is.EqualTo(expectedExit));
        });
    }

    [Test]
    public void ExistingOwnerRequiredEvidenceFailurePersistsMatchingFailedProjection()
    {
        var context = CreateOwner();
        context.Require(ArtifactKind.Screenshot);
        Assert.That(() => context.Complete(ArtifactOutcome.Passed, snapshot =>
        {
            Assert.That(snapshot.Outcome, Is.EqualTo(ArtifactOutcome.Failed));
            var files = ScenarioReportWriter.Write(context.ScenarioRoot, snapshot, OwnerMetadata());
            Assert.That(files.Issues.Any(issue => issue.Code == "required-evidence"), Is.True);
        }), Throws.TypeOf<ArtifactEvidenceException>());
        var saved = ReportJson.Deserialize<ArtifactManifest>(File.ReadAllText(Path.Combine(context.ScenarioRoot, "manifest.json")));
        var projected = ReportJson.Deserialize<ScenarioReportProjection>(
            File.ReadAllText(ReportPaths.Resolve(context.ScenarioRoot, ArtifactReportPaths.Result)));
        Assert.Multiple(() =>
        {
            Assert.That(saved.Outcome, Is.EqualTo(ArtifactOutcome.Failed));
            Assert.That(projected.Status, Is.EqualTo(ReportStatus.Fail));
            Assert.That(projected.ManifestFingerprint, Is.EqualTo(ScenarioReportProjector.ManifestFingerprint(saved)));
            Assert.That(Aggregate(("owner-case", "Failed")).ExitCode, Is.Not.Zero);
        });
    }

    [Test]
    public void ExistingOwnerDeletesPartialSuccessOutputsIfRenderingFails()
    {
        var context = CreateOwner();
        Assert.That(() => context.Complete(ArtifactOutcome.Passed, snapshot =>
            ScenarioReportWriter.Write(context.ScenarioRoot, snapshot, OwnerMetadata(),
                limits: new ReportLimits { MaxReportHtmlBytes = 1 })),
            Throws.TypeOf<ArtifactEvidenceException>());
        var saved = ReportJson.Deserialize<ArtifactManifest>(File.ReadAllText(Path.Combine(context.ScenarioRoot, "manifest.json")));
        Assert.Multiple(() =>
        {
            Assert.That(saved.Outcome, Is.EqualTo(ArtifactOutcome.Failed));
            Assert.That(saved.ComponentOutcomes["artifact-finalization"], Is.False);
            Assert.That(File.Exists(ReportPaths.Resolve(context.ScenarioRoot, ArtifactReportPaths.Report)), Is.False);
            Assert.That(File.Exists(ReportPaths.Resolve(context.ScenarioRoot, ArtifactReportPaths.Result)), Is.False);
        });
    }

    [Test]
    public void SourceBackedOfflineUiHasHierarchyStatisticsDiagnosticsAndOnlyActualLinks()
    {
        var fixture = CreateScenario(ArtifactOutcome.Failed);
        fixture = fixture with
        {
            Metadata = fixture.Metadata with
            {
                Steps = fixture.Metadata.Steps.Add(new ReportStep(2, "Then verify nested premium", ReportStatus.Fail,
                    Started.AddMilliseconds(100), 100)
                {
                    ParentOrder = 1,
                    Error = "Expected premium differs",
                    Binding = new ReportBinding("Fixture.VerifyPremium", @"StepDefinitions\Fixture.cs", 42),
                    ConsoleErrors = ["Browser exception"],
                    NetworkErrors = ["HTTP 503"],
                    Screenshots = ["screenshots/0002-final.png"]
                }),
                DeferredVerifications =
                [
                    new DeferredReportFailure(Started.AddMilliseconds(300), "Verify premium", "Pricing", "Premium", "Value",
                        "100.00", "Expected premium differs", "screenshots/0002-final.png")
                ],
                Diagnostics = [new ReportDiagnostic(Started.AddSeconds(1), "teardown", "ERROR", "Browser close failure")]
            }
        };
        Save(fixture);
        var result = Aggregate(("case-1", "Failed"));
        var html = File.ReadAllText(result.ReportPath);
        Assert.Multiple(() =>
        {
            foreach (var token in new[]
            {
                "robot-banner FAIL", "statistics-grid", "Statistics by feature", "Statistics by application",
                "Statistics by state", "Statistics by LOB", "feature-group", "scenario-card", "attempt-tab",
                "step-row", "data-step-order=\"2\"", "Fixture.VerifyPremium", "Console / page errors", "HTTP 503",
                "Deferred verification failures", "Browser close failure", "evidence-gallery", "lightbox-previous",
                "lightbox-next", "embedded-log", "Redacted scenario-result.json", "PnC forms report", "video-block",
                "d1fa9404f1a245722879e523626beb72e68d033b"
            })
                Assert.That(html, Does.Contain(token));
            Assert.That(html, Does.Contain("../scenario/screenshots/0001-start.png"));
            Assert.That(html, Does.Contain("../scenario/screenshots/0002-final.png"));
            Assert.That(html, Does.Contain("../scenario/forms/report.html"));
            Assert.That(html, Does.Not.Contain("<script src=").And.Not.Contain("cdn."));
            Assert.That(html, Does.Not.Contain("scenario.png"));
            Assert.That(html, Does.Contain("HAR: unavailable").And.Contain("Evidence bundle: unavailable"));
        });
    }

    [TestCase(ArtifactKind.ExecutionLog)]
    [TestCase(ArtifactKind.Screenshot)]
    [TestCase(ArtifactKind.Trace)]
    [TestCase(ArtifactKind.Video)]
    [TestCase(ArtifactKind.ScenarioReportHtml)]
    [TestCase(ArtifactKind.ScenarioResultJson)]
    public void MissingOrEmptyRequiredEvidenceFailsTheGate(ArtifactKind kind)
    {
        var fixture = CreateScenario();
        var files = fixture.Manifest.Artifacts.Where(item => item.Kind == kind).Select(item =>
            ReportPaths.Resolve(fixture.Directory, item.RelativePath!)).ToArray();
        foreach (var file in files)
            File.WriteAllText(file, "");
        var result = Aggregate(("case-1", "Passed"));
        Assert.That(result.ExitCode, Is.EqualTo(2));
        Assert.That(ReadSummary(result).GetProperty("status").GetString(), Is.EqualTo("FAIL"));
        Assert.That(ReadSummary(result).GetProperty("passed").GetInt32(), Is.EqualTo(1),
            "Evidence failures must not rewrite the actual canonical test count.");
    }

    [Test]
    public void OptionalAbsentVideoTraceHarAndBundleAreNotFabricated()
    {
        CreateScenario(media: false);
        var result = Aggregate(("case-1", "Passed"));
        var html = File.ReadAllText(result.ReportPath);
        Assert.Multiple(() =>
        {
            Assert.That(result.ExitCode, Is.Zero);
            Assert.That(html, Does.Contain("Video: unavailable").And.Contain("Playwright trace: unavailable"));
            Assert.That(html, Does.Not.Contain("<video ").And.Not.Contain("href=\"../scenario/video"));
            Assert.That(result.Report.Tests.Single().Attempts.Length, Is.EqualTo(1));
        });
    }

    [Test]
    public void WriterReportsRequiredOmissionsWithoutOwningOrRepairingOutcome()
    {
        var fixture = CreateScenario();
        foreach (var record in fixture.Manifest.Artifacts.Where(item => item.Kind == ArtifactKind.Screenshot))
            File.Delete(ReportPaths.Resolve(fixture.Directory, record.RelativePath!));
        var files = ScenarioReportWriter.Write(fixture.Directory, fixture.Manifest, fixture.Metadata);
        var saved = ReportJson.Deserialize<ScenarioReportProjection>(File.ReadAllText(files.ResultPath));
        Assert.Multiple(() =>
        {
            Assert.That(files.Issues.Any(issue => issue.Code == "required-evidence"), Is.True);
            Assert.That(saved.Status, Is.EqualTo(ReportStatus.Pass));
            Assert.That(fixture.Manifest.Outcome, Is.EqualTo(ArtifactOutcome.Passed));
            Assert.That(File.ReadAllText(files.ReportPath), Does.Contain("robot-banner FAIL"));
        });
    }

    [Test]
    public void WriterRequiresCanonicalReservationsAndNeverCreatesItsOwnRecords()
    {
        var fixture = CreateScenario();
        var unreserved = fixture.Manifest with
        {
            Artifacts = fixture.Manifest.Artifacts.Where(item => item.Kind != ArtifactKind.ScenarioReportHtml).ToArray()
        };
        Assert.That(() => ScenarioReportWriter.Write(fixture.Directory, unreserved, fixture.Metadata),
            Throws.TypeOf<ArtifactEvidenceException>().With.Message.Contains("reserve"));
    }

    [Test]
    public void ManifestRequiredErrorsAndFailedComponentsRemainVisible()
    {
        var fixture = CreateScenario(ArtifactOutcome.Failed);
        fixture = fixture with
        {
            Manifest = fixture.Manifest with
            {
                EvidenceErrors = ["Required evidence publication failed."],
                ComponentOutcomes = ImmutableDictionary<string, bool>.Empty.Add("DataPool", false)
            }
        };
        Save(fixture);
        var result = Aggregate(("case-1", "Failed"));
        Assert.That(result.ExitCode, Is.Not.Zero);
        var html = File.ReadAllText(result.ReportPath);
        Assert.That(html, Does.Contain("DataPool").And.Contain("Required evidence publication failed"));
    }

    [Test]
    public void DeferredFailureCannotSilentlyPassWithAGreenManifest()
    {
        var fixture = CreateScenario();
        fixture = fixture with
        {
            Metadata = fixture.Metadata with
            {
                DeferredVerifications = [new DeferredReportFailure(Started, "assertion", "page", "control", "Text", "expected", "mismatch")]
            }
        };
        Save(fixture);
        var result = Aggregate(("case-1", "Passed"));
        Assert.That(result.Report.Issues.Any(issue => issue.Code == "outcome-inconsistent"), Is.True);
        Assert.That(result.ExitCode, Is.EqualTo(2));
    }

    [TestCase("missing")]
    [TestCase("empty")]
    [TestCase("no-results")]
    public void MissingEmptyOrDiscoveryOnlyCanonicalStillWritesTruthfulFailureOutputs(string variant)
    {
        CreateScenario();
        var path = Path.Combine(_root, "canonical.trx");
        if (variant == "empty")
            File.WriteAllText(path, "");
        else if (variant == "no-results")
            TestCanonicalFiles.Trx().Save(path);
        var result = new ReportAggregator().Generate(Options(path));
        Assert.Multiple(() =>
        {
            Assert.That(result.ExitCode, Is.EqualTo(2));
            Assert.That(result.Report.Tests, Is.Empty);
            Assert.That(ReadSummary(result).GetProperty("total").GetInt32(), Is.Zero);
            Assert.That(File.ReadAllText(result.ReportPath), Does.Contain("Evidence discovery is not execution"));
            Assert.That(result.Report.UnmatchedEvidence.Length, Is.EqualTo(1));
            Assert.That(File.Exists(Path.Combine(_root, "consolidated", "output.xml")), Is.True);
        });
    }

    [Test]
    public void IdentityCountAndOutcomeMismatchAreNotRepaired()
    {
        CreateScenario();
        var result = Aggregate(("case-1", "Failed"), ("unmatched test", "Passed"));
        Assert.Multiple(() =>
        {
            Assert.That(result.ExitCode, Is.EqualTo(2));
            Assert.That(result.Report.Issues.Select(issue => issue.Code), Does.Contain("outcome-mismatch").And.Contain("missing-scenario"));
            Assert.That(ReadSummary(result).GetProperty("total").GetInt32(), Is.EqualTo(2));
            Assert.That(ReadSummary(result).GetProperty("failed").GetInt32(), Is.EqualTo(1));
        });
    }

    [Test]
    public void ManifestFingerprintRejectsStalePreTeardownSuccessProjection()
    {
        var fixture = CreateScenario();
        var changed = fixture.Manifest with
        {
            Outcome = ArtifactOutcome.Failed,
            ComponentOutcomes = ImmutableDictionary<string, bool>.Empty.Add("teardown", false)
        };
        File.WriteAllText(Path.Combine(fixture.Directory, "manifest.json"), ReportJson.Serialize(changed));
        var result = Aggregate(("case-1", "Failed"));
        Assert.That(result.Report.Issues.Any(issue => issue.Code == "projection-mismatch"), Is.True);
        Assert.That(result.Report.Tests.Single().Attempts.Single().Projection.Status, Is.EqualTo(ReportStatus.Fail));
    }

    [Test]
    public void StaleHtmlCannotRemainLinkedAfterCanonicalJsonHasChanged()
    {
        var fixture = CreateScenario();
        var staleHtml = File.ReadAllText(ReportPaths.Resolve(fixture.Directory, ScenarioReportWriter.ReportRelativePath));
        fixture = fixture with { Manifest = fixture.Manifest with { Outcome = ArtifactOutcome.Failed, AuthoritativeScenarioFailed = true } };
        Save(fixture);
        File.WriteAllText(ReportPaths.Resolve(fixture.Directory, ScenarioReportWriter.ReportRelativePath), staleHtml);
        var result = Aggregate(("case-1", "Failed"));
        Assert.That(result.Report.Issues.Any(issue => issue.Code == "html-projection-mismatch"), Is.True);
        Assert.That(result.Report.Tests.Single().Attempts.Single().Evidence.Files
            .Single(item => item.Kind == "ScenarioReportHtml").Href, Is.Null);
    }

    [Test]
    public void ReparsePointAncestorOfScenarioRootIsRejected()
    {
        var ancestor = Path.Combine(_root, "linked");
        var scenario = Path.Combine(ancestor, "scenario");
        Assert.That(() => ReportPaths.SafeRoot(scenario, path =>
                path == ancestor ? FileAttributes.Directory | FileAttributes.ReparsePoint : null),
            Throws.TypeOf<ArtifactEvidenceException>().With.Message.Contains("reparse"));
    }

    [Test]
    public void SensitiveFileNamesAreRejectedInsteadOfLeakingThroughHrefOrRawJson()
    {
        var fixture = CreateScenario();
        var manifest = fixture.Manifest with
        {
            Artifacts = fixture.Manifest.Artifacts.Append(new ArtifactRecord(
                ArtifactKind.Screenshot, "sensitive", "screenshots/password=credential.png", Started)).ToArray()
        };
        Assert.That(() => ScenarioReportProjector.Project(manifest, fixture.Metadata),
            Throws.TypeOf<ArtifactEvidenceException>().With.Message.Contains("Sensitive artifact filenames"));
    }

    [TestCase("outcome")]
    [TestCase("authoritativeScenarioFailed")]
    [TestCase("requiredEvidence")]
    public void MissingCanonicalManifestFieldsNeverDefaultToSuccess(string field)
    {
        var fixture = CreateScenario();
        var json = System.Text.Json.Nodes.JsonNode.Parse(ReportJson.Serialize(fixture.Manifest))!.AsObject();
        json.Remove(field);
        File.WriteAllText(Path.Combine(fixture.Directory, "manifest.json"), json.ToJsonString());
        var result = Aggregate(("case-1", "Passed"));
        Assert.That(result.ExitCode, Is.EqualTo(2));
        Assert.That(result.Report.Issues.Any(issue => issue.Code == "scenario-input"), Is.True);
    }

    [Test]
    public void AmbiguousJsonAndMissingStepStatusCannotHideRawDataOrImplyPassingSteps()
    {
        Assert.That(() => ReportJson.Deserialize<Dictionary<string, string>>(
                """{"password":"secret","Password":"[REDACTED]"}"""),
            Throws.TypeOf<JsonException>().With.Message.Contains("duplicate"));
        var step = new ReportStep(1, "real step", ReportStatus.Pass, Started, 1);
        var json = System.Text.Json.Nodes.JsonNode.Parse(ReportJson.Serialize(step))!.AsObject();
        json.Remove("status");
        Assert.That(() => ReportJson.Deserialize<ReportStep>(json.ToJsonString()), Throws.TypeOf<JsonException>());
    }

    [TestCase("duration")]
    [TestCase("unknown-property")]
    public void RawProjectionBytesCannotHideIgnoredOrComputedFieldTampering(string mutation)
    {
        var fixture = CreateScenario();
        var path = ReportPaths.Resolve(fixture.Directory, ScenarioReportWriter.ResultRelativePath);
        var json = System.Text.Json.Nodes.JsonNode.Parse(File.ReadAllText(path))!.AsObject();
        if (mutation == "duration")
            json["durationMilliseconds"] = 999999;
        else
            json["unexpectedPrivateField"] = "raw-private-value";
        File.WriteAllText(path, json.ToJsonString());
        var result = Aggregate(("case-1", "Passed"));
        Assert.That(result.ExitCode, Is.EqualTo(2));
        var html = File.ReadAllText(result.ReportPath);
        Assert.That(html, Does.Not.Contain("raw-private-value")
            .And.Not.Contain("href=\"../scenario/reports/scenario-result.json\""));
    }

    [Test]
    public void OversizeIndividualReportCannotBeWrittenAsSuccess()
    {
        var fixture = CreateScenario();
        Assert.That(() => ScenarioReportWriter.Write(fixture.Directory, fixture.Manifest, fixture.Metadata,
                limits: new ReportLimits { MaxReportHtmlBytes = 1 }),
            Throws.TypeOf<ArtifactEvidenceException>().With.Message.Contains("limit"));
    }

    [Test]
    public void DeepOrCyclicStepHierarchyIsRejectedBeforeRendering()
    {
        var fixture = CreateScenario();
        var steps = Enumerable.Range(1, 65).Select(order => new ReportStep(
            order, "nested", ReportStatus.Pass, Started, 0)
        { ParentOrder = order == 1 ? null : order - 1 }).ToImmutableArray();
        Assert.That(() => ScenarioReportProjector.Project(fixture.Manifest, fixture.Metadata with { Steps = steps }),
            Throws.ArgumentException.With.Message.Contains("depth"));
        Assert.That(() => ScenarioReportProjector.Project(fixture.Manifest, fixture.Metadata with
        {
            Steps = [new ReportStep(1, "cyclic", ReportStatus.Pass, Started, 0) { ParentOrder = 1 }]
        }), Throws.ArgumentException);
    }

    [Test]
    public void OnlyRealAttemptsAreGroupedAndEarlierFailureIsNotCountedAsAnotherTest()
    {
        CreateScenario(ArtifactOutcome.Failed, directory: "initial", attempt: 1);
        CreateScenario(ArtifactOutcome.Passed, directory: "retry", attempt: 2);
        var result = Aggregate(("case-1", "Passed"));
        Assert.Multiple(() =>
        {
            Assert.That(result.ExitCode, Is.Zero);
            Assert.That(ReadSummary(result).GetProperty("total").GetInt32(), Is.EqualTo(1));
            Assert.That(ReadSummary(result).GetProperty("attempts").GetInt32(), Is.EqualTo(2));
            Assert.That(ReadSummary(result).GetProperty("retried").GetInt32(), Is.EqualTo(1));
            Assert.That(File.ReadAllText(result.ReportPath), Does.Contain("Actual attempt 1").And.Contain("Actual attempt 2"));
            Assert.That(File.ReadAllText(Path.Combine(_root, "consolidated", "log.html")), Does.Contain("Attempt 1").And.Contain("Attempt 2"));
        });
    }

    [Test]
    public void MissingOrDuplicateAttemptsFailWithSourceFileLabels()
    {
        CreateScenario(directory: "first", attempt: 2);
        CreateScenario(directory: "second", attempt: 2);
        var result = Aggregate(("case-1", "Passed"));
        Assert.That(result.Report.Issues.Select(issue => issue.Code), Does.Contain("missing-attempt").And.Contain("duplicate-attempt"));
        Assert.That(result.Report.Issues.Single(issue => issue.Code == "duplicate-attempt").Message,
            Does.Contain("first/manifest.json").And.Contain("second/manifest.json"));
    }

    [Test]
    public void IdenticalAttachmentCopiesAreDeduplicatedButChangedCopiesAreNot()
    {
        var fixture = CreateScenario();
        var copy = Path.Combine(_root, "attachment-copy");
        CopyTree(fixture.Directory, copy);
        var result = Aggregate(("case-1", "Passed"));
        Assert.Multiple(() =>
        {
            Assert.That(result.ExitCode, Is.Zero);
            Assert.That(result.Report.DuplicateCopies.Length, Is.EqualTo(1));
            Assert.That(ReadSummary(result).GetProperty("attempts").GetInt32(), Is.EqualTo(1));
        });
        File.AppendAllText(ReportPaths.Resolve(copy, "logs/execution.log"), "\nchanged copy");
        result = Aggregate(("case-1", "Passed"));
        Assert.That(result.Report.Issues.Any(issue => issue.Code == "duplicate-attempt"), Is.True);
    }

    [Test]
    public void ExplicitCanonicalRootsExcludeAttachmentCopiesAndMustNotOverlap()
    {
        var fixture = CreateScenario(directory: "agent");
        CopyTree(fixture.Directory, Path.Combine(_root, "runner"));
        File.AppendAllText(ReportPaths.Resolve(Path.Combine(_root, "runner"), "logs/execution.log"), "\nattachment copy");
        var path = WriteCanonical(("case-1", "Passed"));
        var options = Options(path) with { ScenarioRoots = ["agent"] };
        Assert.That(new ReportAggregator().Generate(options).ExitCode, Is.Zero);
        var overlap = new ReportAggregator().Generate(options with { ScenarioRoots = [_root, "agent"] });
        Assert.That(overlap.Report.Issues.Any(issue => issue.Code == "scenario-root"), Is.True);
        var escape = new ReportAggregator().Generate(options with { ScenarioRoots = [Path.GetDirectoryName(_root)!] });
        Assert.That(escape.Report.Issues.Any(issue => issue.Code == "scenario-root"), Is.True);
    }

    [TestCase("../escape.png")]
    [TestCase("screenshots/../../escape.png")]
    [TestCase("C:\\outside.png")]
    [TestCase("\\\\server\\outside.png")]
    [TestCase("screenshots/file.png:secret")]
    [TestCase("https://host/image.png")]
    [TestCase("javascript:alert(1)")]
    [TestCase("screenshots/%2e%2e/escape.png")]
    [TestCase("screenshots/space. /image.png")]
    public void UntrustedArtifactPathsCannotEscapeOrBecomeActiveUris(string path)
    {
        var fixture = CreateScenario();
        var manifest = fixture.Manifest with
        {
            Artifacts = fixture.Manifest.Artifacts.Append(new ArtifactRecord(ArtifactKind.Screenshot, "unsafe", path, Started)).ToArray()
        };
        Assert.That(() => ScenarioReportProjector.Project(manifest, fixture.Metadata),
            Throws.TypeOf<ArtifactEvidenceException>());
    }

    [TestCase("javascript:alert(1)")]
    [TestCase("https://external/image.png")]
    [TestCase("//external/image.png")]
    [TestCase("../%2fexternal")]
    [TestCase("../..%2foutside")]
    [TestCase("../file%3Astream")]
    public void PureRendererDoesNotTrustSuppliedActiveLinks(string href)
    {
        var fixture = CreateScenario();
        var projection = ScenarioReportProjector.Project(fixture.Manifest, fixture.Metadata);
        var documents = ScenarioReportRenderer.Render(projection,
            new ScenarioReportEvidence([new ReportEvidenceFile("Video", "unsafe", "unsafe", href, 100)], []));
        Assert.That(documents.Html, Does.Not.Contain("href=\"" + href).And.Not.Contain("src=\"" + href));
    }

    [Test]
    public void PortableHrefEncodingPreservesSpacesAndQuotesWithoutHtmlInjection()
    {
        var path = Path.Combine(_root, "screenshots", "space ' image.png");
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllBytes(path, Png);
        var href = ReportPaths.Href(_root, Path.Combine(_root, "report"), path);
        Assert.That(href, Is.EqualTo("../screenshots/space%20%27%20image.png"));
        Assert.That(ReportPaths.IsLocalHref(href), Is.True);
        Assert.That(() => ReportPaths.Href(_root, _root, Path.Combine(Path.GetDirectoryName(_root)!, "outside.png")),
            Throws.TypeOf<ArtifactEvidenceException>());
    }

    [Test]
    public void AllDynamicDisplaySurfacesAreEncodedAndSensitiveValuesAreRedacted()
    {
        const string payload = "<script>window.pwned=true</script>\" onerror=\"alert(1)";
        var fixture = CreateScenario(identity: "case-1 email=person@example.test");
        fixture = fixture with
        {
            Metadata = fixture.Metadata with
            {
                Feature = payload,
                Scenario = payload,
                Tags = [payload],
                Steps =
                [
                    new ReportStep(1, payload, ReportStatus.Pass, Started, 100)
                    {
                        Binding = new ReportBinding(payload, payload),
                        Data = ImmutableDictionary<string, string>.Empty.Add("password", "top secret value")
                            .Add("Premium", payload).Add("Email", "someone@example.test"),
                        Error = "Authorization: Bearer credential-text\npassword=\"two words\"\n" + payload,
                        ConsoleErrors = ["token=not-for-output"],
                        NetworkErrors = ["GET https://user:secret@example.test/api?access_token=not-for-output"],
                        Screenshots = ["screenshots/0001-start.png"]
                    }
                ]
            }
        };
        File.WriteAllText(ReportPaths.Resolve(fixture.Directory, "logs/execution.log"), "authorization: Bearer hidden-log-value\npassword='hidden log secret'");
        Save(fixture);
        var result = Aggregate(("case-1 email=person@example.test", "Passed"));
        Assert.That(result.ExitCode, Is.Zero, string.Join("\n", result.Report.Issues));
        var all = new[] { File.ReadAllText(result.ReportPath),
            File.ReadAllText(ReportPaths.Resolve(fixture.Directory, ScenarioReportWriter.ReportRelativePath)),
            File.ReadAllText(ReportPaths.Resolve(fixture.Directory, ScenarioReportWriter.ResultRelativePath)),
            File.ReadAllText(Path.Combine(_root, "consolidated", "log.html")),
            File.ReadAllText(Path.Combine(_root, "consolidated", "summary.json")),
            File.ReadAllText(Path.Combine(_root, "consolidated", "output.xml")) };
        Assert.Multiple(() =>
        {
            foreach (var contents in all)
            {
                foreach (var secret in new[] { "top secret value", "someone@example.test", "person@example.test", "credential-text", "two words", "not-for-output", "hidden-log-value", "hidden log secret", "user:secret" })
                    Assert.That(contents, Does.Not.Contain(secret));
                Assert.That(contents, Does.Not.Contain("<script>window.pwned"));
            }
            foreach (var html in new[] { all[0], all[1], all[3] })
                Assert.That(html, Does.Not.Contain("\" onerror=\"alert"));
            Assert.That(all[0], Does.Contain("&lt;script&gt;"));
            Assert.That(all[0], Does.Not.Contain("href=\"../scenario/logs/execution.log\""),
                "An unsafe original log must never bypass the redacted preview.");
        });
    }

    [TestCase("password=\"two words\"", "two words")]
    [TestCase("\"api_key\": \"abc;def\"", "abc;def")]
    [TestCase("Authorization: Basic dXNlcjpwYXNz", "dXNlcjpwYXNz")]
    [TestCase("Cookie: session=secret value", "secret value")]
    [TestCase("GET https://name:pass@example.test/path?token=abc#secret", "name:pass")]
    [TestCase("status=failed password=secret-value", "secret-value")]
    [TestCase("result=unexpected clientPassword=\"secret-value\"", "secret-value")]
    [TestCase("<Password>secret-value</Password>", "secret-value")]
    [TestCase("Unexpected identifier 123-45-6789", "123-45-6789")]
    [TestCase("Unexpected value eyJhbGciOiJub25lIn0.eyJzdWIiOiJ1bml0In0.signature", "eyJhbGci")]
    public void RedactionIsIdempotentAndHandlesQuotedOrHeaderCredentials(string input, string secret)
    {
        var redactor = new ReportRedactor();
        var once = redactor.Text(input);
        Assert.That(once, Does.Not.Contain(secret));
        Assert.That(redactor.Text(once), Is.EqualTo(once));
    }

    [Test]
    public void KnownSecretValuesAreRemovedEvenWhenNoSensitiveKeyIsPresent()
    {
        var redactor = new ReportRedactor(["literal-runtime-credential"]);
        Assert.That(redactor.Text("Login failed using literal-runtime-credential"), Does.Not.Contain("literal-runtime-credential"));
    }

    [Test]
    public void RedactedRawJsonRemainsValidJsonIncludingQuotedSensitiveValues()
    {
        var redactor = new ReportRedactor();
        var json = redactor.Text("""{"data":{"password":"secret value","api_key":"another value"},"status":"PASS"}""");
        using var document = JsonDocument.Parse(json);
        Assert.That(document.RootElement.GetProperty("data").GetProperty("password").GetString(), Is.EqualTo(ReportRedactor.Mask));
        Assert.That(redactor.Text(json), Is.EqualTo(json));
    }

    [Test]
    public void RawProjectionPreviewPreservesRedactedUrlAndNewlineValues()
    {
        var fixture = CreateScenario();
        fixture = fixture with
        {
            Metadata = fixture.Metadata with
            {
                Diagnostics = [new ReportDiagnostic(Started, "browser", "warning",
                    "Request failed https://example.test/path?token=private-value\n  at Client.Execute()")]
            }
        };
        Save(fixture);
        var result = Aggregate(("case-1", "Passed"));
        var expected = ReportJson.Serialize(result.Report.Tests.Single().Attempts.Single().Projection);
        foreach (var path in new[]
        {
            result.ReportPath, ReportPaths.Resolve(fixture.Directory, ScenarioReportWriter.ReportRelativePath)
        })
        {
            var html = File.ReadAllText(path);
            var match = System.Text.RegularExpressions.Regex.Match(html,
                """<details class="raw-json"[^>]*>.*?<pre>(.*?)</pre>""",
                System.Text.RegularExpressions.RegexOptions.Singleline);
            Assert.That(match.Success, Is.True);
            var json = System.Net.WebUtility.HtmlDecode(match.Groups[1].Value);
            Assert.That(json, Is.EqualTo(expected));
            Assert.That(json, Does.Not.Contain("private-value"));
        }
    }

    [Test]
    public void LogAndImageLimitsAreExplicitWithoutInventingLinksOrLeakingTruncatedSecrets()
    {
        var fixture = CreateScenario();
        File.WriteAllText(ReportPaths.Resolve(fixture.Directory, "logs/execution.log"),
            "safe first line\npassword=" + new string('x', 100));
        var projection = ScenarioReportProjector.Project(fixture.Manifest, fixture.Metadata);
        var reader = new ReportEvidenceReader(new ReportLimits
        {
            MaxLogBytes = 30,
            MaxImagesPerScenario = 1,
            MaxImageBytes = 1,
            MaxRawJsonBytes = 1
        });
        var evidence = reader.Read(projection, fixture.Directory, _root, Path.Combine(_root, "consolidated"));
        var log = evidence.Files.Single(item => item.Kind == "ExecutionLog");
        Assert.Multiple(() =>
        {
            Assert.That(log.Truncated, Is.True);
            Assert.That(log.Href, Is.Null);
            Assert.That(log.Text, Is.EqualTo("safe first line\n"));
            Assert.That(evidence.Files.Where(item => item.Kind == "Screenshot").All(item => item.ImageDataUri == null), Is.True);
            Assert.That(evidence.Files.Where(item => item.Kind == "Screenshot").All(item => item.Href != null), Is.True);
        });
        var html = ScenarioReportRenderer.Render(projection, evidence, new ReportLimits { MaxRawJsonBytes = 1 }).Html;
        Assert.That(html, Does.Contain("too large to embed").And.Contain("Not embedded"));
    }

    [Test]
    public void RecorderIsScenarioOwnedUsesMonotonicTimingAndRequiresCompletedSteps()
    {
        var clock = new FixtureTimeProvider();
        var recorder = new ScenarioReportRecorder(clock);
        var metadata = new ScenarioReportMetadata("unit", "unit", "unit", "AL", "BOP", "execution");
        var parent = recorder.StartStep("When pricing");
        var child = recorder.StartStep("Then compare premium", parentOrder: parent);
        Assert.That(() => recorder.EndStep(parent, ReportStatus.Pass), Throws.InvalidOperationException);
        Assert.That(() => recorder.Snapshot(metadata), Throws.InvalidOperationException);
        clock.Advance(TimeSpan.FromMilliseconds(120));
        recorder.EndStep(child, ReportStatus.Fail, "mismatch");
        recorder.EndStep(parent, ReportStatus.Fail);
        var snapshot = recorder.Snapshot(metadata);
        recorder.RecordDiagnostic("after-snapshot", "INFO", "later");
        Assert.Multiple(() =>
        {
            Assert.That(snapshot.Steps[1].DurationMilliseconds, Is.EqualTo(120));
            Assert.That(snapshot.Steps[1].ParentOrder, Is.EqualTo(parent));
            Assert.That(snapshot.Diagnostics, Is.Empty);
            Assert.That(new ScenarioReportRecorder().Snapshot(metadata).Steps, Is.Empty);
            Assert.That(() => recorder.EndStep(child, ReportStatus.Pass), Throws.InvalidOperationException);
        });
    }

    [Test]
    public void DuplicateScreenshotFilesAreNotAcceptedAsDistinctCaptures()
    {
        var fixture = CreateScenario();
        var manifest = fixture.Manifest with
        {
            Artifacts = fixture.Manifest.Artifacts.Append(
                new ArtifactRecord(ArtifactKind.Screenshot, "fake second capture", "screenshots/0001-start.png", Started)).ToArray()
        };
        var projection = ScenarioReportProjector.Project(manifest, fixture.Metadata);
        var evidence = new ReportEvidenceReader().Read(projection, fixture.Directory, _root, _root);
        Assert.That(evidence.Issues.Any(issue => issue.Code == "duplicate-evidence"), Is.True);
    }

    [Test]
    public void OutputCannotEscapeOrOverwriteAnIndividualReportOrCanonicalInput()
    {
        var fixture = CreateScenario();
        var canonical = WriteCanonical(("case-1", "Passed"));
        Assert.Multiple(() =>
        {
            Assert.That(() => new ReportAggregator().Generate(Options(canonical) with { OutputDirectory = Path.GetDirectoryName(_root)! }),
                Throws.TypeOf<ArtifactEvidenceException>());
            Assert.That(() => new ReportAggregator().Generate(Options(canonical) with { OutputDirectory = Path.Combine(fixture.Directory, "reports") }),
                Throws.TypeOf<ArtifactEvidenceException>());
        });
        var xml = Path.Combine(_root, "output.xml");
        TestCanonicalFiles.NUnit(("case-1", "Passed")).Save(xml);
        Assert.That(() => new ReportAggregator().Generate(Options(xml) with { OutputDirectory = _root }),
            Throws.TypeOf<ArtifactEvidenceException>());
    }

    [Test]
    public void CliReturnsRealFailureExitCodesAndAllRequestedFiles()
    {
        CreateScenario(ArtifactOutcome.Failed);
        var canonical = WriteCanonical(("case-1", "Failed"));
        using var output = new StringWriter();
        using var error = new StringWriter();
        var exit = Program.Run(["--evidence-root", _root, "--canonical-result", canonical,
            "--output-dir", Path.Combine(_root, "consolidated")], output, error);
        Assert.Multiple(() =>
        {
            Assert.That(exit, Is.EqualTo(1));
            Assert.That(output.ToString(), Does.StartWith("FAIL:"));
            Assert.That(Program.Run(["--evidence-root"], output, error), Is.EqualTo(2));
            Assert.That(File.Exists(Path.Combine(_root, "consolidated", "summary.json")), Is.True);
        });
    }

    [Test]
    public void SavesExplicitlyLabelledUnitFixtureForOfflineUiReview()
    {
        var fixture = CreateScenario(ArtifactOutcome.Failed, directory: "initial", media: false);
        fixture = fixture with
        {
            Metadata = fixture.Metadata with
            {
                Steps = fixture.Metadata.Steps.Select(step => step with { Status = ReportStatus.Fail, Error = "Synthetic assertion failure for reporter unit coverage (not a live business run)." }).ToImmutableArray(),
                DeferredVerifications = [new DeferredReportFailure(Started, "Verify unit fixture", "Fixture", "Premium", "Value", "100", "Synthetic mismatch", "screenshots/0001-start.png")]
            }
        };
        Save(fixture);
        CreateScenario(directory: "retry", media: false, attempt: 2);
        CreateScenario(ArtifactOutcome.Failed, identity: "case-2", directory: "failed", media: false);
        CreateScenario(ArtifactOutcome.Skipped, identity: "case-3", directory: "skipped", media: false);
        var result = Aggregate(("case-1", "Passed"), ("case-2", "Failed"), ("case-3", "NotExecuted"));
        Assert.That(result.ExitCode, Is.EqualTo(1));
        var sample = Path.Combine(TestContext.CurrentContext.WorkDirectory, "SgsReportingUnitSample", Guid.NewGuid().ToString("N"));
        CopyTree(_root, sample);
        var path = Path.Combine(sample, "consolidated", "report.html");
        TestContext.AddTestAttachment(path, "SGS reporting synthetic unit-fixture preview; NOT a live execution report.");
        TestContext.Progress.WriteLine("SGS_UNIT_REPORT_SAMPLE=" + path);
    }

    private ScenarioFixture CreateScenario(ArtifactOutcome outcome = ArtifactOutcome.Passed,
        string identity = "case-1", string directory = "scenario", int attempt = 1, bool media = true)
    {
        var root = Path.Combine(_root, directory);
        Directory.CreateDirectory(root);
        var started = Started.AddSeconds((attempt - 1) * 10);
        var artifacts = new List<ArtifactRecord>();
        void Write(ArtifactKind kind, string relative, byte[] bytes)
        {
            var path = ReportPaths.Resolve(root, relative);
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            File.WriteAllBytes(path, bytes);
            artifacts.Add(new ArtifactRecord(kind, kind + "-" + artifacts.Count, relative, started));
        }
        Write(ArtifactKind.ExecutionLog, "logs/execution.log", Encoding.UTF8.GetBytes("Synthetic unit fixture only. No browser or business flow was executed.\n"));
        Write(ArtifactKind.Screenshot, "screenshots/0001-start.png", Png);
        Write(ArtifactKind.Screenshot, "screenshots/0002-final.png", Png);
        Write(ArtifactKind.FormsHtml, "forms/report.html", Encoding.UTF8.GetBytes("<html><body>Synthetic forms unit fixture</body></html>"));
        Write(ArtifactKind.TimingSummary, "metadata/timing.json", Encoding.UTF8.GetBytes("{}"));
        Write(ArtifactKind.TrxMetadata, "metadata/trx.json", Encoding.UTF8.GetBytes("{}"));
        if (media)
        {
            Write(ArtifactKind.Trace, "traces/trace.zip", Encoding.UTF8.GetBytes("Synthetic trace unit fixture"));
            Write(ArtifactKind.Video, "video/execution.webm", Encoding.UTF8.GetBytes("Synthetic video unit fixture"));
        }
        artifacts.Add(new ArtifactRecord(ArtifactKind.ScenarioReportHtml, "report", ScenarioReportWriter.ReportRelativePath, started));
        artifacts.Add(new ArtifactRecord(ArtifactKind.ScenarioResultJson, "result", ScenarioReportWriter.ResultRelativePath, started));
        var required = new List<ArtifactKind>
        {
            ArtifactKind.ExecutionLog, ArtifactKind.Screenshot, ArtifactKind.ScenarioReportHtml, ArtifactKind.ScenarioResultJson
        };
        if (media)
            required.AddRange([ArtifactKind.Trace, ArtifactKind.Video]);
        var manifest = new ArtifactManifest(2, "reporting-unit-run", directory,
            "SGS-UNIT:" + ScenarioReportProjector.IdentityHash(identity)[..10], identity, "rich-unit-fixture",
            outcome, outcome == ArtifactOutcome.Failed, ImmutableDictionary<string, bool>.Empty,
            required, [], artifacts, "metadata/trx.json", "metadata/timing.json", started, started.AddSeconds(1));
        var metadata = new ScenarioReportMetadata(
            "SGS reporting unit fixture - NOT LIVE EXECUTION", "Reporter unit scenario " + identity,
            "ExpertQuote", "AL", "BOP", "unit-execution-" + ScenarioReportProjector.IdentityHash(identity)[..8], attempt)
        {
            Tags = ["unit-fixture", "not-live"],
            Steps = outcome == ArtifactOutcome.Skipped ? [] :
            [
                new ReportStep(1, "When presenting a synthetic business step", ReportStatus.Pass, started, 100)
                {
                    Binding = new ReportBinding("Fixture.BusinessStep", @"StepDefinitions\Fixture.cs", 12),
                    Data = ImmutableDictionary<string, string>.Empty.Add("State", "AL"),
                    Screenshots = ["screenshots/0001-start.png"]
                }
            ]
        };
        var fixture = new ScenarioFixture(root, manifest, metadata);
        Save(fixture);
        return fixture;
    }

    private static void Save(ScenarioFixture fixture)
    {
        File.WriteAllText(Path.Combine(fixture.Directory, "manifest.json"), ReportJson.Serialize(fixture.Manifest));
        ScenarioReportWriter.Write(fixture.Directory, fixture.Manifest, fixture.Metadata);
    }

    private ArtifactContext CreateOwner()
    {
        var time = Started;
        var context = new ArtifactContext(new ArtifactOptions
        {
            RootPath = _root,
            ProfileName = "rich-unit-fixture",
            RequiredOnFailure = []
        }, "owner-unit-run", "owner-case", () => time = time.AddMilliseconds(10),
            automationId: "SGS-UNIT:OWNER", testIdentity: "owner-case");
        var log = context.CreateArtifactPath(ArtifactKind.ExecutionLog, "unit-execution", ".log");
        File.WriteAllText(log, "Synthetic reporting unit fixture; no live execution.");
        context.RecordFile(ArtifactKind.ExecutionLog, "unit-execution", log);
        context.Require(ArtifactKind.ExecutionLog);
        return context;
    }

    private static ScenarioReportMetadata OwnerMetadata() => new(
        "Artifact owner unit integration - NOT LIVE EXECUTION", "Writer callback integration",
        "Unit", "AL", "BOP", "owner-unit-execution");

    private SgsReportResult Aggregate(params (string Identity, string Outcome)[] tests) =>
        new ReportAggregator().Generate(Options(WriteCanonical(tests)));
    private SgsReportOptions Options(string path) => new(_root, path, Path.Combine(_root, "consolidated"));
    private string WriteCanonical(params (string Identity, string Outcome)[] tests)
    {
        var path = Path.Combine(_root, "canonical.trx");
        TestCanonicalFiles.Trx(tests).Save(path);
        return path;
    }
    private static JsonElement ReadSummary(SgsReportResult result) =>
        JsonDocument.Parse(File.ReadAllText(Path.Combine(Path.GetDirectoryName(result.ReportPath)!, "summary.json"))).RootElement.Clone();
    private static void CopyTree(string source, string destination)
    {
        Directory.CreateDirectory(destination);
        foreach (var path in Directory.GetFiles(source, "*", SearchOption.AllDirectories))
        {
            var target = Path.Combine(destination, Path.GetRelativePath(source, path));
            Directory.CreateDirectory(Path.GetDirectoryName(target)!);
            File.Copy(path, target);
        }
    }
    private sealed record ScenarioFixture(string Directory, ArtifactManifest Manifest, ScenarioReportMetadata Metadata);
    private sealed class FixtureTimeProvider : TimeProvider
    {
        private long _ticks;
        public override long TimestampFrequency => TimeSpan.TicksPerSecond;
        public override long GetTimestamp() => _ticks;
        public override DateTimeOffset GetUtcNow() => Started.AddTicks(_ticks);
        internal void Advance(TimeSpan time) => _ticks += time.Ticks;
    }
}
