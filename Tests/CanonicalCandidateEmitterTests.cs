using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using NUnit.Framework;
using PnCTestAutomation.Models;
using PnCTestAutomation.Services;
using PnCTestAutomation.Tools.FormsBaselineGenerator;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    [NonParallelizable]
    public class CanonicalCandidateEmitterTests
    {
        private const string WorkbookHash =
            "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
        private const string ApprovedHash =
            "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB";
        private static readonly DateOnly EffectiveDate = new(2027, 4, 3);

        private string _temporaryRoot;

        [SetUp]
        public void CreateTemporaryRoot()
        {
            _temporaryRoot = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                nameof(CanonicalCandidateEmitterTests),
                Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_temporaryRoot);
        }

        [TearDown]
        public void RemoveTemporaryRoot()
        {
            if (Directory.Exists(_temporaryRoot))
                Directory.Delete(_temporaryRoot, recursive: true);
            var parent = Directory.GetParent(_temporaryRoot)?.FullName;
            if (parent != null
                && Directory.Exists(parent)
                && !Directory.EnumerateFileSystemEntries(parent).Any())
            {
                Directory.Delete(parent);
            }
        }

        [Test]
        public void Candidate_IsDeterministicOrderedAndStrictParserCompatible()
        {
            var request = Request(
                Projection(
                    Qualified(
                        "SF06010120",
                        CanonicalExpectedDestination.BASIC,
                        "YS",
                        "VA"),
                    Qualified(
                        "SF05010426",
                        CanonicalExpectedDestination.BASE,
                        "YM",
                        "VA",
                        "AL"),
                    Qualified(
                        "SF07010120",
                        CanonicalExpectedDestination.CE,
                        "YM",
                        "AL")));

            var result = CanonicalCandidateEmitter.CreateCandidate(
                request,
                Options());
            using var document = JsonDocument.Parse(result.CandidateJson);
            var root = document.RootElement;
            var service = new FormsValidationService(new DuckCreekFormsConfig());

            Assert.Multiple(() =>
            {
                Assert.That(root.EnumerateObject().Select(property => property.Name),
                    Is.EqualTo(new[] { "STATES", "BASE", "BASIC", "CE" }));
                Assert.That(root.GetProperty("STATES").EnumerateObject()
                        .Select(property => property.Name),
                    Is.EqualTo(new[] { "BASIC", "CE" }));
                Assert.That(root.GetProperty("STATES").GetProperty("BASIC")
                        .EnumerateArray().Select(value => value.GetString()),
                    Is.EqualTo(new[] { "AL", "VA" }));
                Assert.That(root.GetProperty("BASE").GetProperty("SF05010426")
                    .GetString(), Is.EqualTo("all"));
                Assert.That(root.GetProperty("BASIC").GetProperty("SF06010120")
                    .GetProperty("VA").GetString(), Is.EqualTo("YS"));
                Assert.That(root.GetProperty("CE").GetProperty("SF07010120")
                    .EnumerateArray().Select(value => value.GetString()),
                    Is.EqualTo(new[] { "AL" }));
                Assert.That(service.ParseSfpJson(
                        result.CandidateJson, "VA", "BASIC")
                    .Single(form => form.FormName == "SF06010120").ExpectedStatus,
                    Is.EqualTo("YS"));
                Assert.That(service.ParseSfpJson(
                        result.CandidateJson, "AL", "CE")
                    .Single(form => form.FormName == "SF07010120").ExpectedStatus,
                    Is.EqualTo("YM"));
            });
        }

        [Test]
        public void Candidate_EmitsQualifiedOnlyAndNeverRedundantImplicitN()
        {
            var projection = Projection(
                new[]
                {
                    Qualified(
                        "SF05010426",
                        CanonicalExpectedDestination.BASE,
                        "YM",
                        "AL",
                        "VA")
                },
                new[]
                {
                    new CanonicalImplicitNRecord
                    {
                        NormalizedIdentifier = "SF09990120",
                        ScenarioDestination = CanonicalExpectedDestination.BASIC,
                        States = new[] { "AL", "VA" },
                        SourceRows = new[] { SourceRow("SF09990120") }
                    },
                    new CanonicalImplicitNRecord
                    {
                        NormalizedIdentifier = "SF09990120",
                        ScenarioDestination = CanonicalExpectedDestination.CE,
                        States = new[] { "AL", "VA" },
                        SourceRows = new[] { SourceRow("SF09990120") }
                    }
                });

            var result = CanonicalCandidateEmitter.CreateCandidate(
                Request(projection),
                Options());

            Assert.That(result.CandidateJson,
                Does.Contain("SF05010426").And.Not.Contain("SF09990120"));
        }

        [Test]
        public void BlockedProjectionAndApprovalBlockingReportAlwaysFail()
        {
            var blockedProjection = Projection(
                new[]
                {
                    Qualified(
                        "SF05010426",
                        CanonicalExpectedDestination.BASE,
                        "YM",
                        "AL",
                        "VA")
                },
                blocked: new[]
                {
                    new CanonicalBlockedProjectionRecord
                    {
                        Kind = CanonicalProjectionBlockKind.SourceConflict,
                        NormalizedIdentifier = "SF06010120",
                        States = new[] { "AL" },
                        ImpactedDestinations = new[]
                        {
                            CanonicalExpectedDestination.BASIC
                        }
                    }
                });
            var blockedError = Assert.Throws<InvalidOperationException>(() =>
                CanonicalCandidateEmitter.CreateCandidate(
                    Request(blockedProjection),
                    Options()));
            var approvalError = Assert.Throws<InvalidOperationException>(() =>
                CanonicalCandidateEmitter.CreateCandidate(
                    Request(
                        CompleteProjection(),
                        Report(
                            CompleteProjection(),
                            CanonicalSemanticSeverity.ApprovalBlocking)),
                    Options()));

            Assert.Multiple(() =>
            {
                Assert.That(blockedError!.Message, Does.Contain("blocked"));
                Assert.That(approvalError!.Message,
                    Does.Contain("ApprovalBlocking"));
            });
        }

        [TestCase(CanonicalSemanticSeverity.ReviewRequired)]
        [TestCase(CanonicalSemanticSeverity.PotentiallyBreaking)]
        public void ReviewedChangeSeveritiesRequireExplicitOptIn(
            CanonicalSemanticSeverity severity)
        {
            var projection = CompleteProjection();
            var request = Request(projection, Report(projection, severity));

            var error = Assert.Throws<InvalidOperationException>(() =>
                CanonicalCandidateEmitter.CreateCandidate(request, Options()));
            var allowed = CanonicalCandidateEmitter.CreateCandidate(
                request,
                Options(allowReviewedChanges: true));

            Assert.Multiple(() =>
            {
                Assert.That(error!.Message,
                    Does.Contain("AllowReviewedChanges=true"));
                Assert.That(allowed.CandidateJson, Does.Contain("\"BASE\""));
            });
        }

        [Test]
        public void InformationalOnlyReportProceedsWithoutReviewedOptIn()
        {
            var result = CanonicalCandidateEmitter.CreateCandidate(
                Request(
                    CompleteProjection(),
                    Report(
                        CompleteProjection(),
                        CanonicalSemanticSeverity.Informational)),
                Options());

            Assert.That(result.CandidateJson, Does.Contain("SF05010426"));
        }

        [Test]
        public void IncompleteScenarioOrStateCoverageFails()
        {
            var projection = Projection(
                Qualified(
                    "SF05010426",
                    CanonicalExpectedDestination.BASIC,
                    "YM",
                    "AL",
                    "VA"));
            var missingCe = Request(projection);
            var missingState = Request(
                Projection(
                    Qualified(
                        "SF05010426",
                        CanonicalExpectedDestination.BASE,
                        "YM",
                        "AL")));

            Assert.Multiple(() =>
            {
                Assert.That(
                    Assert.Throws<InvalidOperationException>(() =>
                        CanonicalCandidateEmitter.CreateCandidate(
                            missingCe,
                            Options()))!.Message,
                    Does.Contain("CE state coverage is incomplete"));
                Assert.That(
                    Assert.Throws<InvalidOperationException>(() =>
                        CanonicalCandidateEmitter.CreateCandidate(
                            missingState,
                            Options()))!.Message,
                    Does.Contain("state coverage is incomplete"));
            });
        }

        [Test]
        public void DuplicatePropertyAndRuntimeIdentityFail()
        {
            var duplicateProperty = Projection(
                Qualified(
                    "SF05010426",
                    CanonicalExpectedDestination.BASIC,
                    "YM",
                    "AL",
                    "VA"),
                Qualified(
                    "SF05010426",
                    CanonicalExpectedDestination.BASIC,
                    "YM",
                    "AL",
                    "VA"),
                Qualified(
                    "SF06010120",
                    CanonicalExpectedDestination.CE,
                    "YM",
                    "AL",
                    "VA"));
            var duplicateRuntime = Projection(
                Qualified(
                    "SF05010426",
                    CanonicalExpectedDestination.BASE,
                    "YM",
                    "AL",
                    "VA"),
                Qualified(
                    "SF05010426",
                    CanonicalExpectedDestination.BASIC,
                    "YM",
                    "AL",
                    "VA"));

            Assert.Multiple(() =>
            {
                Assert.That(
                    Assert.Throws<InvalidOperationException>(() =>
                        CanonicalCandidateEmitter.CreateCandidate(
                            Request(duplicateProperty),
                            Options()))!.Message,
                    Does.Contain("Duplicate BASE/BASIC/CE candidate property"));
                Assert.That(
                    Assert.Throws<InvalidOperationException>(() =>
                        CanonicalCandidateEmitter.CreateCandidate(
                            Request(duplicateRuntime),
                            Options()))!.Message,
                    Does.Contain("Duplicate runtime identity"));
            });
        }

        [TestCase("SFP.json")]
        [TestCase("SFP_RATEPOLICY.json")]
        public void ApprovedBaselinePathsAreRejected(string fileName)
        {
            var protectedPath = Path.Combine(
                _temporaryRoot,
                "Resources",
                "ExpectedForms",
                "SFP",
                fileName);
            var error = Assert.Throws<InvalidOperationException>(() =>
                CanonicalCandidateEmitter.WriteCandidate(
                    Request(CompleteProjection()),
                    Options(
                        candidatePath: protectedPath,
                        projectRoot: _temporaryRoot)));

            Assert.That(error!.Message,
                Does.Contain("cannot overwrite an approved Forms baseline"));
            Assert.That(File.Exists(protectedPath), Is.False);
        }

        [Test]
        public void ActualApprovedBaselinePathCannotBeBypassedByAlternateProjectRoot()
        {
            var projectRoot = Path.GetFullPath(Path.Combine(
                AppContext.BaseDirectory,
                "..",
                "..",
                ".."));
            var protectedPath = Path.Combine(
                projectRoot,
                "Resources",
                "ExpectedForms",
                "SFP",
                "SFP.json");

            var error = Assert.Throws<InvalidOperationException>(() =>
                CanonicalCandidateEmitter.WriteCandidate(
                    Request(CompleteProjection()),
                    Options(
                        candidatePath: protectedPath,
                        projectRoot: _temporaryRoot)));

            Assert.That(error!.Message,
                Does.Contain("cannot overwrite an approved Forms baseline"));
        }

        [Test]
        public void ExistingCandidateRequiresExplicitOverwrite()
        {
            var path = Path.Combine(_temporaryRoot, "candidate.json");
            File.WriteAllText(path, "original");
            var request = Request(CompleteProjection());

            var error = Assert.Throws<InvalidOperationException>(() =>
                CanonicalCandidateEmitter.WriteCandidate(
                    request,
                    Options(candidatePath: path, projectRoot: _temporaryRoot)));
            var result = CanonicalCandidateEmitter.WriteCandidate(
                request,
                Options(
                    candidatePath: path,
                    projectRoot: _temporaryRoot,
                    overwriteExisting: true));

            Assert.Multiple(() =>
            {
                Assert.That(error!.Message, Does.Contain("already exists"));
                Assert.That(File.ReadAllText(path), Is.EqualTo(result.CandidateJson));
                Assert.That(File.Exists(result.ManifestPath), Is.True);
            });
        }

        [Test]
        public void CandidateHashIsStableAndManifestSeparatesTimestamp()
        {
            var request = Request(CompleteProjection());
            var first = CanonicalCandidateEmitter.CreateCandidate(
                request,
                Options(timestamp: new DateTimeOffset(
                    2027, 1, 1, 0, 0, 0, TimeSpan.Zero)));
            var second = CanonicalCandidateEmitter.CreateCandidate(
                request,
                Options(timestamp: new DateTimeOffset(
                    2027, 2, 1, 0, 0, 0, TimeSpan.Zero)));

            using var firstManifest = JsonDocument.Parse(first.ManifestJson);
            using var secondManifest = JsonDocument.Parse(second.ManifestJson);
            var firstIdentity = firstManifest.RootElement
                .GetProperty("deterministicIdentity").GetRawText();
            var secondIdentity = secondManifest.RootElement
                .GetProperty("deterministicIdentity").GetRawText();

            Assert.Multiple(() =>
            {
                Assert.That(second.CandidateJson, Is.EqualTo(first.CandidateJson));
                Assert.That(second.CandidateSha256, Is.EqualTo(first.CandidateSha256));
                Assert.That(second.ComparisonReportSha256,
                    Is.EqualTo(first.ComparisonReportSha256));
                Assert.That(secondIdentity, Is.EqualTo(firstIdentity));
                Assert.That(second.ManifestJson, Is.Not.EqualTo(first.ManifestJson));
            });
        }

        [Test]
        public void ManifestContainsRequiredIdentityWithoutSourceSecrets()
        {
            var projection = CompleteProjection(sourceNotes: "password=do-not-emit");
            var result = CanonicalCandidateEmitter.CreateCandidate(
                Request(projection),
                Options());
            using var document = JsonDocument.Parse(result.ManifestJson);
            var identity = document.RootElement.GetProperty("deterministicIdentity");

            Assert.Multiple(() =>
            {
                Assert.That(document.RootElement.GetProperty("schemaVersion").GetString(),
                    Is.EqualTo("1.0"));
                Assert.That(identity.GetProperty("candidateSha256").GetString(),
                    Is.EqualTo(result.CandidateSha256));
                Assert.That(identity.GetProperty("approvedBaselineSha256").GetString(),
                    Is.EqualTo(ApprovedHash));
                Assert.That(identity.GetProperty("comparisonReportSha256").GetString(),
                    Is.EqualTo(result.ComparisonReportSha256));
                Assert.That(identity.GetProperty("sourceWorkbooks")[0]
                    .GetProperty("identity").GetString(), Is.EqualTo("fixture.xlsx"));
                Assert.That(identity.GetProperty("generatorVersion").GetString(),
                    Is.EqualTo("9.0-test"));
                Assert.That(identity.GetProperty("projectionRuleVersion").GetString(),
                    Is.EqualTo("1.0"));
                Assert.That(identity.GetProperty("comparisonRuleVersion").GetString(),
                    Is.EqualTo("1.0"));
                Assert.That(identity.GetProperty("completenessStatus").GetString(),
                    Is.EqualTo("Complete"));
                Assert.That(result.ManifestJson,
                    Does.Not.Contain("password")
                        .And.Not.Contain("do-not-emit")
                        .And.Not.Contain("cookie")
                        .And.Not.Contain("credential"));
            });
        }

        [Test]
        public void WriteCandidateUsesDefaultIsolatedConventionAndCleansTemporaryFiles()
        {
            var result = CanonicalCandidateEmitter.WriteCandidate(
                Request(CompleteProjection()),
                Options(projectRoot: _temporaryRoot));

            Assert.Multiple(() =>
            {
                Assert.That(result.CandidatePath, Is.EqualTo(Path.Combine(
                    _temporaryRoot,
                    "TestResults",
                    "FormsBaseline",
                    "SFP_CANONICAL_CANDIDATE.json")));
                Assert.That(result.ManifestPath, Is.EqualTo(Path.Combine(
                    _temporaryRoot,
                    "TestResults",
                    "FormsBaseline",
                    "SFP_CANONICAL_CANDIDATE.manifest.json")));
                Assert.That(File.Exists(result.CandidatePath), Is.True);
                Assert.That(File.Exists(result.ManifestPath), Is.True);
                Assert.That(Directory.EnumerateFiles(
                        Path.GetDirectoryName(result.CandidatePath)!,
                        "*.tmp"),
                    Is.Empty);
            });
        }

        [Test]
        public void ExistingLegacyEmitterOutputRemainsUnchanged()
        {
            var path = Path.Combine(_temporaryRoot, "legacy.json");
            var rows = new List<ParsedFormRow>
            {
                new()
                {
                    FormNumber = "SF05010426",
                    Section = "BASE",
                    StateValues = new Dictionary<string, string>
                    {
                        ["AL"] = "YM",
                        ["VA"] = "YM"
                    }
                }
            };
            var profiles = new Dictionary<string, string[]>
            {
                ["BASIC"] = new[] { "AL", "VA" },
                ["CE"] = new[] { "AL", "VA" }
            };

            BaselineJsonEmitter.Emit(
                rows,
                profiles,
                new Dictionary<string, string[]>
                {
                    ["BASIC"] = Array.Empty<string>(),
                    ["CE"] = Array.Empty<string>()
                },
                "SFP",
                path);

            Assert.That(File.ReadAllText(path),
                Does.Contain("Auto-generated by FormsBaselineGeneratorTool")
                    .And.Contain("\"SF05010426\": \"all\""));
        }

        private static CanonicalCandidateEmissionRequest Request(
            CanonicalExpectedProjection projection,
            CanonicalSemanticComparisonReport report = null) =>
            new()
            {
                Projection = projection,
                BasicProfiles = Profiles("BASIC", "SFP-BASIC-NEW-BUSINESS"),
                CountryEstateProfiles = Profiles("CE", "SFP-CE-NEW-BUSINESS"),
                ComparisonReport = report ?? Report(projection),
                SourceWorkbooks = new[]
                {
                    new CanonicalSourceWorkbookInput(
                        "fixture.xlsx",
                        "fixture.xlsx",
                        WorkbookHash)
                },
                GeneratorVersion = "9.0-test",
                RuleVersions = new Dictionary<string, string>
                {
                    ["Applicability"] = "1.0",
                    ["EditionLifecycle"] = "1.0",
                    ["ScenarioEligibility"] = "1.0"
                }
            };

        private static CanonicalCandidateEmissionOptions Options(
            bool allowReviewedChanges = false,
            bool overwriteExisting = false,
            string candidatePath = null,
            string projectRoot = null,
            DateTimeOffset? timestamp = null) =>
            new()
            {
                AllowReviewedChanges = allowReviewedChanges,
                OverwriteExisting = overwriteExisting,
                CandidatePath = candidatePath,
                ProjectRoot = projectRoot,
                GenerationTimestampUtc = timestamp
                    ?? new DateTimeOffset(2027, 1, 1, 0, 0, 0, TimeSpan.Zero)
            };

        private static CanonicalExpectedProjection CompleteProjection(
            string sourceNotes = "") =>
            Projection(
                Qualified(
                    "SF05010426",
                    CanonicalExpectedDestination.BASE,
                    "YM",
                    new[] { "AL", "VA" },
                    sourceNotes));

        private static CanonicalExpectedProjection Projection(
            params CanonicalExpectedRecord[] qualified) =>
            Projection(qualified, null, null);

        private static CanonicalExpectedProjection Projection(
            CanonicalExpectedRecord[] qualified,
            CanonicalImplicitNRecord[] implicitN = null,
            CanonicalBlockedProjectionRecord[] blocked = null) =>
            new()
            {
                RuleSetId = CanonicalExpectedRecordProjector.RuleSetId,
                RuleVersion = CanonicalExpectedRecordProjector.RuleVersion,
                QualifiedRecords = qualified ?? Array.Empty<CanonicalExpectedRecord>(),
                ImplicitNEvidence = implicitN ?? Array.Empty<CanonicalImplicitNRecord>(),
                BlockedRecords = blocked ?? Array.Empty<CanonicalBlockedProjectionRecord>()
            };

        private static CanonicalExpectedRecord Qualified(
            string form,
            CanonicalExpectedDestination destination,
            string status,
            params string[] states) =>
            Qualified(form, destination, status, states, "");

        private static CanonicalExpectedRecord Qualified(
            string form,
            CanonicalExpectedDestination destination,
            string status,
            string[] states,
            string sourceNotes) =>
            new()
            {
                NormalizedIdentifier = form,
                FormNumber = form[..^4],
                Edition = form[^4..],
                Destination = destination,
                States = states,
                Company = "American National Insurance Company",
                EffectiveDate = EffectiveDate,
                Transaction = "New Business",
                ProvisionalRuntimeStatus = status,
                ProfileIds = destination switch
                {
                    CanonicalExpectedDestination.BASE => new[]
                    {
                        "SFP-BASIC-NEW-BUSINESS",
                        "SFP-CE-NEW-BUSINESS"
                    },
                    CanonicalExpectedDestination.BASIC => new[]
                    {
                        "SFP-BASIC-NEW-BUSINESS"
                    },
                    _ => new[] { "SFP-CE-NEW-BUSINESS" }
                },
                SourceFamilies = new[] { FormSourceFamily.Sfp },
                SourceRows = new[] { SourceRow(form, sourceNotes) },
                RuleIds = new[] { "V1-QUALIFIED" }
            };

        private static CanonicalFormSourceRow SourceRow(
            string form,
            string notes = "") =>
            new()
            {
                RawFormIdentifier = form,
                NormalizedFormIdentifier = form,
                ParsedFormNumber = form[..^4],
                ParsedEdition = form[^4..],
                SourceFamily = FormSourceFamily.Sfp,
                Workbook = new WorkbookSourceInfo(
                    "fixture.xlsx",
                    "C:\\fixtures\\fixture.xlsx",
                    WorkbookHash),
                Worksheet = "Forms",
                SourceRowNumber = 2,
                RawNotes = notes,
                RelevantCells = new[]
                {
                    new SourceCellFact("Form Number", "A2", form)
                }
            };

        private static ScenarioProfile[] Profiles(
            string product,
            string profileId) =>
            new[] { "VA", "AL" }
                .Select((state, index) => new ScenarioProfile(
                    profileId,
                    ScenarioProfileLoader.ProfileVersion,
                    product,
                    state,
                    "New Business",
                    "American National Insurance Company",
                    EffectiveDate,
                    "New Business",
                    new ScenarioProfileEvidence(
                        product + ".feature",
                        product + " New Business",
                        product,
                        "American National Insurance Company",
                        1,
                        index + 1,
                        state,
                        Array.Empty<string>())))
                .ToArray();

        private static CanonicalSemanticComparisonReport Report(
            CanonicalExpectedProjection projection,
            CanonicalSemanticSeverity? severity = null)
        {
            var findings = severity.HasValue
                ? new[]
                {
                    new CanonicalSemanticFinding
                    {
                        FindingId = "F0001",
                        Category = CanonicalSemanticChangeCategory.SourceHashOnly,
                        Severity = severity.Value,
                        Scenario = "BASIC",
                        State = "AL",
                        Form = "SF05010426",
                        Reasons = new[] { "Fixture finding." },
                        RuleIds = new[] { "V1-FIXTURE" }
                    }
                }
                : Array.Empty<CanonicalSemanticFinding>();
            return new CanonicalSemanticComparisonReport
            {
                SchemaVersion = CanonicalSemanticComparisonService.SchemaVersion,
                ComparisonRuleVersion =
                    CanonicalSemanticComparisonService.ComparisonRuleVersion,
                ApprovedBaselineSha256 = ApprovedHash,
                ProjectionSha256 =
                    CanonicalProjectionFingerprint.Compute(projection),
                SuspiciousChangeThreshold = 25,
                SeverityCounts = Enum.GetValues<CanonicalSemanticSeverity>()
                    .Select(value => new CanonicalSeverityCount(
                        value,
                        findings.Count(finding => finding.Severity == value)))
                    .ToArray(),
                Findings = findings
            };
        }
    }
}
