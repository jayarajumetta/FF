using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using ClosedXML.Excel;
using NUnit.Framework;
using PnCTestAutomation.Models;
using PnCTestAutomation.Services;
using PnCTestAutomation.Tools.FormsBaselineGenerator;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    [NonParallelizable]
    public class CanonicalFormsPipelineTests
    {
        private string _temporaryRoot;
        private FixtureFiles _files;

        [SetUp]
        public void CreateFixture()
        {
            _temporaryRoot = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                nameof(CanonicalFormsPipelineTests),
                Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_temporaryRoot);
            _files = CreateFixtureFiles();
        }

        [TearDown]
        public void RemoveFixture()
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
        public void FullPipeline_GeneratesDeterministicStrictAtomicReviewPackage()
        {
            var output = Path.Combine(_temporaryRoot, "review-package");
            var result = CanonicalFormsPipeline.Run(
                Request(output),
                Options(writePackage: true));
            var service = new FormsValidationService(new DuckCreekFormsConfig());

            Assert.Multiple(() =>
            {
                Assert.That(result.Status, Is.EqualTo(CanonicalFormsPackageStatus.Generated));
                Assert.That(result.Paths, Is.Not.Null);
                Assert.That(Directory.EnumerateFiles(output)
                    .Select(Path.GetFileName), Is.EquivalentTo(new[]
                    {
                        CanonicalFormsPipeline.CandidateFileName,
                        CanonicalFormsPipeline.ManifestFileName,
                        CanonicalFormsPipeline.SemanticJsonFileName,
                        CanonicalFormsPipeline.SemanticMarkdownFileName
                    }));
                Assert.That(result.SemanticReport!.Report.Findings, Is.Empty);
                Assert.That(result.Projection!.BlockedRecords, Is.Empty);
                Assert.That(result.Candidate!.ProjectionSha256,
                    Is.EqualTo(result.SemanticReport.Report.ProjectionSha256));
                Assert.That(service.ParseSfpJson(
                        result.Candidate.CandidateJson,
                        "AL",
                        "BASIC")
                    .Where(form => form.ExpectedStatus != "N")
                    .Select(form => form.FormName),
                    Is.EquivalentTo(new[] { "CF00010120", "SF05010426" }));
                Assert.That(service.ParseSfpJson(
                        result.Candidate.CandidateJson,
                        "AZ",
                        "CE")
                    .Where(form => form.ExpectedStatus != "N")
                    .Select(form => form.FormName),
                    Is.EquivalentTo(new[] { "CF00010120", "SF05010426" }));
            });
        }

        [Test]
        public void SameInputs_ProduceSameProjectionReportCandidateAndCorrelationHashes()
        {
            var first = CanonicalFormsPipeline.Run(
                Request(),
                Options(
                    writePackage: false,
                    timestamp: new DateTimeOffset(
                        2027, 1, 1, 0, 0, 0, TimeSpan.Zero)));
            var second = CanonicalFormsPipeline.Run(
                Request(),
                Options(
                    writePackage: false,
                    timestamp: new DateTimeOffset(
                        2027, 2, 1, 0, 0, 0, TimeSpan.Zero)));

            Assert.Multiple(() =>
            {
                Assert.That(first.Status, Is.EqualTo(CanonicalFormsPackageStatus.Generated));
                Assert.That(second.ProjectionSha256, Is.EqualTo(first.ProjectionSha256));
                Assert.That(second.Candidate!.ComparisonReportSha256,
                    Is.EqualTo(first.Candidate!.ComparisonReportSha256));
                Assert.That(second.Candidate.CandidateSha256,
                    Is.EqualTo(first.Candidate.CandidateSha256));
                Assert.That(second.PackageCorrelationId,
                    Is.EqualTo(first.PackageCorrelationId));
                Assert.That(second.Candidate.ManifestJson,
                    Is.Not.EqualTo(first.Candidate.ManifestJson));
            });
        }

        [Test]
        public void ProjectionFingerprint_StreamsWithoutChangingCanonicalHash()
        {
            var projection = new CanonicalExpectedProjection
            {
                RuleSetId = "CanonicalExpectedProjection",
                RuleVersion = "1.0",
                QualifiedRecords = new[]
                {
                    new CanonicalExpectedRecord
                    {
                        NormalizedIdentifier = "SF05010426",
                        FormNumber = "SF0501",
                        Edition = "0426",
                        Destination = CanonicalExpectedDestination.BASE,
                        States = new[] { "AL", "AZ" },
                        Company = "SFP",
                        EffectiveDate = new DateOnly(2027, 4, 3),
                        Transaction = "New Business",
                        ProvisionalRuntimeStatus = "YM",
                        ProfileIds = new[]
                        {
                            "SFP-BASIC-NEW-BUSINESS",
                            "SFP-CE-NEW-BUSINESS"
                        },
                        SourceFamilies = new[] { FormSourceFamily.Sfp },
                        RuleIds = new[] { "V1-ROUTE-BASE" },
                        Reasons = new[] { "Equivalent BASIC and CE expectations." }
                    }
                }
            };
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            options.Converters.Add(new JsonStringEnumConverter());
            var legacyJson = JsonSerializer.Serialize(projection, options);
            var expected = Convert.ToHexString(
                SHA256.HashData(Encoding.UTF8.GetBytes(legacyJson)));

            Assert.That(
                CanonicalProjectionFingerprint.Compute(projection),
                Is.EqualTo(expected));
        }

        [Test]
        public void ReportProjectionManifestAndInputHashesAreBound()
        {
            var result = CanonicalFormsPipeline.Run(
                Request(),
                Options(writePackage: false));
            using var manifest = JsonDocument.Parse(result.Candidate!.ManifestJson);
            var identity = manifest.RootElement.GetProperty("deterministicIdentity");

            Assert.Multiple(() =>
            {
                Assert.That(identity.GetProperty("projectionSha256").GetString(),
                    Is.EqualTo(result.ProjectionSha256));
                Assert.That(identity.GetProperty("comparisonReportSha256").GetString(),
                    Is.EqualTo(result.Candidate.ComparisonReportSha256));
                Assert.That(identity.GetProperty("candidateSha256").GetString(),
                    Is.EqualTo(result.Candidate.CandidateSha256));
                Assert.That(identity.GetProperty("packageCorrelationId").GetString(),
                    Is.EqualTo(result.PackageCorrelationId));
                Assert.That(identity.GetProperty("inputArtifacts").GetArrayLength(),
                    Is.EqualTo(6));
                Assert.That(result.SemanticReport!.Report.ProjectionSha256,
                    Is.EqualTo(result.ProjectionSha256));
            });
        }

        [Test]
        public void SourceConflictBlocksCandidateAndReturnsInMemoryDiagnostics()
        {
            CreateCommonWorkbook(
                _files.CommonWorkbook,
                "SF05010426",
                "Unavailable",
                "password=must-not-leak");
            var result = CanonicalFormsPipeline.Run(
                Request(Path.Combine(_temporaryRoot, "blocked-package")),
                Options(writePackage: true));

            Assert.Multiple(() =>
            {
                Assert.That(result.Status, Is.EqualTo(CanonicalFormsPackageStatus.Blocked));
                Assert.That(result.Candidate, Is.Null);
                Assert.That(result.Paths, Is.Null);
                Assert.That(result.Projection!.BlockedRecords, Is.Not.Empty);
                Assert.That(result.SemanticReport!.Report.Findings.Any(finding =>
                    finding.Severity == CanonicalSemanticSeverity.ApprovalBlocking), Is.True);
                Assert.That(Directory.Exists(Path.Combine(
                    _temporaryRoot,
                    "blocked-package")), Is.False);
            });
        }

        [Test]
        public void ReviewRequiredDefaultsToManualReviewAndExplicitOptInGenerates()
        {
            WriteApprovedBaseline(
                _files.ApprovedBaseline,
                includeCommonForm: false);
            var defaultResult = CanonicalFormsPipeline.Run(
                Request(),
                Options(writePackage: false));
            var approvedResult = CanonicalFormsPipeline.Run(
                Request(),
                Options(
                    writePackage: false,
                    allowReviewedChanges: true));

            Assert.Multiple(() =>
            {
                Assert.That(defaultResult.Status,
                    Is.EqualTo(CanonicalFormsPackageStatus.ManualReviewRequired));
                Assert.That(defaultResult.Candidate, Is.Null);
                Assert.That(defaultResult.SemanticReport!.Report.Findings.Any(finding =>
                    finding.Severity == CanonicalSemanticSeverity.ReviewRequired), Is.True);
                Assert.That(approvedResult.Status,
                    Is.EqualTo(CanonicalFormsPackageStatus.Generated));
                Assert.That(approvedResult.Candidate, Is.Not.Null);
            });
        }

        [Test]
        public void WorkbookMutationDuringParseFailsWithoutPackage()
        {
            var output = Path.Combine(_temporaryRoot, "mutation-package");
            var result = CanonicalFormsPipeline.Run(
                Request(output),
                Options(
                    writePackage: true,
                    afterWorkbookParse: () =>
                        File.AppendAllText(_files.SfpWorkbook, "changed")));

            Assert.Multiple(() =>
            {
                Assert.That(result.Status, Is.EqualTo(CanonicalFormsPackageStatus.Failed));
                Assert.That(result.Reasons.Single(),
                    Does.Contain("changed during canonical parsing"));
                Assert.That(Directory.Exists(output), Is.False);
            });
        }

        [Test]
        public void ApprovedBaselineDirectoryIsRejectedAsPackageOutput()
        {
            var unsafeOutput = Path.Combine(
                Path.GetDirectoryName(_files.ApprovedBaseline)!,
                "review");
            var result = CanonicalFormsPipeline.Run(
                Request(unsafeOutput),
                Options(writePackage: true));

            Assert.Multiple(() =>
            {
                Assert.That(result.Status, Is.EqualTo(CanonicalFormsPackageStatus.Failed));
                Assert.That(result.Reasons.Single(),
                    Does.Contain("cannot be inside the approved Forms baseline directory"));
                Assert.That(Directory.Exists(unsafeOutput), Is.False);
            });
        }

        [Test]
        public void ExistingPackageRequiresExplicitOverwrite()
        {
            var output = Path.Combine(_temporaryRoot, "overwrite-package");
            var first = CanonicalFormsPipeline.Run(
                Request(output),
                Options(writePackage: true));
            File.WriteAllText(Path.Combine(output, "old-marker.txt"), "old");
            var refused = CanonicalFormsPipeline.Run(
                Request(output),
                Options(writePackage: true));
            var overwritten = CanonicalFormsPipeline.Run(
                Request(output),
                Options(writePackage: true, overwriteExisting: true));

            Assert.Multiple(() =>
            {
                Assert.That(first.Status, Is.EqualTo(CanonicalFormsPackageStatus.Generated));
                Assert.That(refused.Status, Is.EqualTo(CanonicalFormsPackageStatus.Failed));
                Assert.That(refused.Reasons.Single(), Does.Contain("already exists"));
                Assert.That(overwritten.Status,
                    Is.EqualTo(CanonicalFormsPackageStatus.Generated));
                Assert.That(File.Exists(Path.Combine(output, "old-marker.txt")), Is.False);
            });
        }

        [Test]
        public void AtomicFailureCleansTemporaryPackageAndLeavesNoCompletePackage()
        {
            var output = Path.Combine(_temporaryRoot, "atomic-package");
            var result = CanonicalFormsPipeline.Run(
                Request(output),
                Options(
                    writePackage: true,
                    failureStage:
                        CanonicalPackageWriteStage.AfterTemporaryPackageWritten));

            Assert.Multiple(() =>
            {
                Assert.That(result.Status, Is.EqualTo(CanonicalFormsPackageStatus.Failed));
                Assert.That(Directory.Exists(output), Is.False);
                Assert.That(Directory.EnumerateDirectories(
                        _temporaryRoot,
                        "atomic-package.tmp-*"),
                    Is.Empty);
                Assert.That(Directory.EnumerateDirectories(
                        _temporaryRoot,
                        "atomic-package.backup-*"),
                    Is.Empty);
            });
        }

        [Test]
        public void PackageReportsContainNoRawSecretMaterial()
        {
            CreateSfpWorkbook(
                _files.SfpWorkbook,
                "SF05010426",
                "Mandatory",
                "password=do-not-emit");
            var result = CanonicalFormsPipeline.Run(
                Request(),
                Options(writePackage: false));
            var packageText = string.Join(
                "\n",
                result.Candidate!.CandidateJson,
                result.Candidate.ManifestJson,
                result.SemanticReport!.Json,
                result.SemanticReport.Markdown);

            Assert.That(packageText,
                Does.Not.Contain("password")
                    .And.Not.Contain("do-not-emit")
                    .And.Not.Contain("credential")
                    .And.Not.Contain("cookie"));
        }

        [Test]
        public void LegacyGeneratorEmitterRemainsAvailableAndUnchanged()
        {
            var legacyPath = Path.Combine(_temporaryRoot, "legacy.json");
            BaselineJsonEmitter.Emit(
                new List<ParsedFormRow>
                {
                    new()
                    {
                        FormNumber = "SF05010426",
                        Section = "BASE",
                        StateValues = new Dictionary<string, string>
                        {
                            ["AL"] = "YM",
                            ["AR"] = "YM",
                            ["AZ"] = "YM"
                        }
                    }
                },
                new Dictionary<string, string[]>
                {
                    ["BASIC"] = new[] { "AL", "AR", "AZ" },
                    ["CE"] = new[] { "AL", "AR", "AZ" }
                },
                new Dictionary<string, string[]>
                {
                    ["BASIC"] = Array.Empty<string>(),
                    ["CE"] = Array.Empty<string>()
                },
                "SFP",
                legacyPath);

            Assert.That(File.ReadAllText(legacyPath),
                Does.Contain("Auto-generated by FormsBaselineGeneratorTool")
                    .And.Contain("\"SF05010426\": \"all\""));
        }

        private CanonicalFormsPipelineRequest Request(string outputDirectory = null) =>
            new()
            {
                SfpWorkbookPath = _files.SfpWorkbook,
                CommonWorkbookPath = _files.CommonWorkbook,
                ApprovedBaselinePath = _files.ApprovedBaseline,
                BasicFeaturePath = _files.BasicFeature,
                CountryEstateFeaturePath = _files.CeFeature,
                PendingStateProfilePath = _files.PendingProfile,
                OutputDirectory = outputDirectory,
                Lob = "SFP",
                EffectiveDate = new DateOnly(2027, 4, 3),
                GeneratorVersion = "10.0-test",
                RuleVersions = new Dictionary<string, string>
                {
                    ["Aggregation"] = "1.0",
                    ["Applicability"] = CanonicalApplicabilityInterpreter.RuleVersion,
                    ["ScenarioEligibility"] =
                        CanonicalScenarioEligibilityEvaluator.RuleVersion,
                    ["EditionLifecycle"] =
                        CanonicalEditionLifecycleResolver.RuleVersion,
                    ["Projection"] = CanonicalExpectedRecordProjector.RuleVersion,
                    ["SemanticComparison"] =
                        CanonicalSemanticComparisonService.ComparisonRuleVersion
                }
            };

        private static CanonicalFormsPipelineOptions Options(
            bool writePackage,
            bool allowReviewedChanges = false,
            bool overwriteExisting = false,
            DateTimeOffset? timestamp = null,
            Action afterWorkbookParse = null,
            CanonicalPackageWriteStage? failureStage = null) =>
            new()
            {
                WritePackage = writePackage,
                AllowReviewedChanges = allowReviewedChanges,
                OverwriteExisting = overwriteExisting,
                GenerationTimestampUtc = timestamp
                    ?? new DateTimeOffset(2027, 1, 1, 0, 0, 0, TimeSpan.Zero),
                AfterWorkbookParse = afterWorkbookParse,
                InjectFailureAt = failureStage
            };

        private FixtureFiles CreateFixtureFiles()
        {
            var sfp = Path.Combine(_temporaryRoot, "sfp-fixture.xlsx");
            var common = Path.Combine(_temporaryRoot, "common-fixture.xlsx");
            var approved = Path.Combine(_temporaryRoot, "approved", "SFP.json");
            var basic = Path.Combine(_temporaryRoot, "SFP_BasicPolicy.feature");
            var ce = Path.Combine(_temporaryRoot, "SFP_CE.feature");
            var pending = Path.Combine(_temporaryRoot, "pending-states.json");
            Directory.CreateDirectory(Path.GetDirectoryName(approved)!);
            CreateSfpWorkbook(sfp, "SF05010426", "Mandatory", "");
            CreateCommonWorkbook(common, "CF00010120", "Mandatory", "");
            WriteApprovedBaseline(approved, includeCommonForm: true);
            WriteFeature(basic, "BASIC", includeProductSelection: false);
            WriteFeature(ce, "CE", includeProductSelection: true);
            File.WriteAllText(
                pending,
                """
                {
                  "BASIC": {
                    "Status": "ApprovedPendingConfiguration",
                    "States": ["CA"]
                  },
                  "CE": {
                    "Status": "ApprovedPendingConfiguration",
                    "States": ["CA"]
                  }
                }
                """);
            return new FixtureFiles(sfp, common, approved, basic, ce, pending);
        }

        private static void CreateSfpWorkbook(
            string path,
            string form,
            string selection,
            string notes)
        {
            using var workbook = new XLWorkbook();
            var sheet = workbook.AddWorksheet("Division 0");
            var headers = new[]
            {
                "Form Number",
                "Selection",
                "Notes",
                "Type of Form",
                "AL",
                "AR",
                "AZ"
            };
            for (var index = 0; index < headers.Length; index++)
                sheet.Cell(1, index + 1).Value = headers[index];
            sheet.Cell(2, 1).Value = form;
            sheet.Cell(2, 2).Value = selection;
            sheet.Cell(2, 3).Value = notes;
            sheet.Cell(2, 4).Value = "BASE";
            sheet.Cell(2, 5).Value = "Y";
            sheet.Cell(2, 6).Value = "Y";
            sheet.Cell(2, 7).Value = "Y";
            workbook.SaveAs(path);
        }

        private static void CreateCommonWorkbook(
            string path,
            string form,
            string selection,
            string notes)
        {
            using var workbook = new XLWorkbook();
            var sheet = workbook.AddWorksheet("Masterlist");
            sheet.Cell(1, 3).Value = "SFP";
            sheet.Cell(1, 4).Value = "SFP GAP";
            sheet.Cell(1, 8).Value = "Selection";
            sheet.Cell(1, 9).Value = "Notes";
            sheet.Cell(2, 2).Value = "Form Number";
            sheet.Cell(2, 5).Value = "AL";
            sheet.Cell(2, 6).Value = "AR";
            sheet.Cell(2, 7).Value = "AZ";
            sheet.Cell(3, 2).Value = form;
            sheet.Cell(3, 3).Value = "Y";
            sheet.Cell(3, 5).Value = "Y";
            sheet.Cell(3, 6).Value = "Y";
            sheet.Cell(3, 7).Value = "Y";
            sheet.Cell(3, 8).Value = selection;
            sheet.Cell(3, 9).Value = notes;
            workbook.SaveAs(path);
        }

        private static void WriteApprovedBaseline(
            string path,
            bool includeCommonForm)
        {
            var forms = new Dictionary<string, object>
            {
                ["SF05010426"] = "all"
            };
            if (includeCommonForm)
                forms.Add("CF00010120", "all");
            File.WriteAllText(
                path,
                JsonSerializer.Serialize(
                    new Dictionary<string, object>
                    {
                        ["STATES"] = new Dictionary<string, object>
                        {
                            ["BASIC"] = new[] { "AL", "AR", "AZ" },
                            ["CE"] = new[] { "AL", "AR", "AZ" }
                        },
                        ["BASE"] = forms,
                        ["BASIC"] = new Dictionary<string, object>(),
                        ["CE"] = new Dictionary<string, object>()
                    }));
        }

        private static void WriteFeature(
            string path,
            string product,
            bool includeProductSelection)
        {
            var productRow = includeProductSelection
                ? "      | ProductSelection | CE                                          |\n"
                : "";
            File.WriteAllText(
                path,
                $$"""
                Feature: {{product}} canonical profile
                  Scenario Outline: {{product}} New Business - <StateAbbv>
                    And user selects Special Farm Package and inputs Quote Details
                      | Question       | Answer                                      |
                {{productRow}}      | WritingCompany | American National Property And Casualty Co. |
                    When user validates Forms via Duckcreek for state "<StateAbbv>"
                    Examples:
                      | StateAbbv |
                      | AL        |
                      | AR        |
                      | AZ        |
                """);
        }

        private sealed record FixtureFiles(
            string SfpWorkbook,
            string CommonWorkbook,
            string ApprovedBaseline,
            string BasicFeature,
            string CeFeature,
            string PendingProfile);
    }
}
