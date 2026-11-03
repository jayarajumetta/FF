using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using ClosedXML.Excel;
using NUnit.Framework;
using PnCTestAutomation.Models;
using PnCTestAutomation.Services;
using PnCTestAutomation.Tools.FormsBaselineGenerator;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    [NonParallelizable]
    public class CanonicalFormsDeltaPipelineTests
    {
        private string _root;
        private Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _root = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                nameof(CanonicalFormsDeltaPipelineTests),
                Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_root);
            _fixture = CreateFixture();
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(_root))
                Directory.Delete(_root, recursive: true);
            var parent = Directory.GetParent(_root)?.FullName;
            if (parent != null
                && Directory.Exists(parent)
                && !Directory.EnumerateFileSystemEntries(parent).Any())
            {
                Directory.Delete(parent);
            }
        }

        [Test]
        public void IdenticalPinnedWorkbook_IsNoChangeAndNotNotificationWorthy()
        {
            File.Copy(_fixture.PreviousSfp, _fixture.CurrentSfp, overwrite: true);

            var result = RunSfp();

            Assert.Multiple(() =>
            {
                Assert.That(result.Status, Is.EqualTo(CanonicalFormsDeltaStatus.NoChanges));
                Assert.That(result.NotificationWorthy, Is.False);
                Assert.That(result.CandidateJson, Is.Null);
                Assert.That(result.RowDeltas, Is.Empty);
            });
        }

        [Test]
        public void MetadataOnlyWorkbookDifference_IsIgnored()
        {
            CreateSfpWorkbook(
                _fixture.CurrentSfp,
                StandardRows(targetAl: "Y"),
                workbookTitle: "Changed package metadata");

            var result = RunSfp();

            Assert.Multiple(() =>
            {
                Assert.That(Hash(_fixture.CurrentSfp), Is.Not.EqualTo(Hash(_fixture.PreviousSfp)));
                Assert.That(result.Status, Is.EqualTo(CanonicalFormsDeltaStatus.NoChanges));
                Assert.That(result.NotificationWorthy, Is.False);
                Assert.That(result.RowDeltas, Is.Empty);
            });
        }

        [TestCase(CanonicalWorkbookDeltaKind.Added)]
        [TestCase(CanonicalWorkbookDeltaKind.Removed)]
        [TestCase(CanonicalWorkbookDeltaKind.Modified)]
        public void DeterministicSingleRowDelta_ChangesOnlyAffectedRuntimeIdentity(
            CanonicalWorkbookDeltaKind kind)
        {
            ConfigureDelta(kind);
            var approvedMeaning = RuntimeMeaning(
                File.ReadAllText(_fixture.Approved));

            var result = RunSfp();
            var candidateMeaning = RuntimeMeaning(result.CandidateJson);

            Assert.Multiple(() =>
            {
                Assert.That(result.Status, Is.EqualTo(CanonicalFormsDeltaStatus.Generated));
                Assert.That(result.RowDeltas.Single().Kind, Is.EqualTo(kind));
                Assert.That(result.Findings, Is.Not.Empty);
                Assert.That(
                    candidateMeaning.Where(pair => pair.Key.Form == "CF00010120"),
                    Is.EquivalentTo(
                        approvedMeaning.Where(pair => pair.Key.Form == "CF00010120")));
                Assert.That(
                    candidateMeaning.Where(pair => pair.Key.Form != "SF05010426"),
                    Is.EquivalentTo(
                        approvedMeaning.Where(pair => pair.Key.Form != "SF05010426")));
            });
        }

        [Test]
        public void UnrelatedAmbiguousLegacyRow_DoesNotBlockChangedIdentity()
        {
            CreateSfpWorkbook(
                _fixture.PreviousSfp,
                StandardRows(targetAl: "Y").Append(
                    Row("T-5911", "Y", "Y", "Y")).ToArray());
            CreateSfpWorkbook(
                _fixture.CurrentSfp,
                StandardRows(targetAl: "X").Append(
                    Row("T-5911", "Y", "Y", "Y")).ToArray());

            var result = RunSfp();

            Assert.Multiple(() =>
            {
                Assert.That(result.Status, Is.EqualTo(CanonicalFormsDeltaStatus.Generated));
                Assert.That(result.RowDeltas, Has.Count.EqualTo(1));
                Assert.That(result.RowDeltas.Single().AffectedFormIdentity,
                    Is.EqualTo("SF05010426"));
                Assert.That(result.Findings.All(finding =>
                    finding.Form != "T5911"), Is.True);
            });
        }

        [Test]
        public void ChangedAmbiguousIdentity_BlocksOnlyThatDeltaFailClosed()
        {
            CreateSfpWorkbook(
                _fixture.PreviousSfp,
                StandardRows(targetAl: "Y").Append(
                    Row("T-5911", "", "", "")).ToArray());
            CreateSfpWorkbook(
                _fixture.CurrentSfp,
                StandardRows(targetAl: "Y").Append(
                    Row("T-5911", "Y", "", "")).ToArray());

            var result = RunSfp();

            Assert.Multiple(() =>
            {
                Assert.That(result.Status, Is.EqualTo(CanonicalFormsDeltaStatus.Blocked));
                Assert.That(result.CandidateJson, Is.Null);
                Assert.That(result.Findings.Single().Category,
                    Is.EqualTo("ChangedIdentityAmbiguous"));
                Assert.That(result.Findings.Single().RuleIds,
                    Does.Contain("V1-DELTA-IDENTITY-AMBIGUOUS"));
            });
        }

        [TestCase(FormsMonitorSourceFamily.SFP)]
        [TestCase(FormsMonitorSourceFamily.Common)]
        public void ChangedSource_ReevaluatesCounterpartAgreementForSameIdentity(
            FormsMonitorSourceFamily family)
        {
            if (family == FormsMonitorSourceFamily.SFP)
            {
                CreateSfpWorkbook(_fixture.PreviousSfp, StandardRows(targetAl: "Y"));
                CreateSfpWorkbook(_fixture.CurrentSfp, StandardRows(targetAl: "X"));
                CreateCommonWorkbook(
                    _fixture.CurrentCommon,
                    new[] { Row("SF05010426", "Y", "Y", "Y") });
            }
            else
            {
                CreateCommonWorkbook(
                    _fixture.PreviousCommon,
                    new[] { Row("SF05010426", "Y", "Y", "Y") });
                CreateCommonWorkbook(
                    _fixture.CurrentCommon,
                    new[] { Row("SF05010426", "X", "Y", "Y") });
                CreateSfpWorkbook(
                    _fixture.CurrentSfp,
                    new[] { Row("SF05010426", "Y", "Y", "Y") });
            }

            var result = family == FormsMonitorSourceFamily.SFP
                ? RunSfp()
                : RunCommon();

            Assert.Multiple(() =>
            {
                Assert.That(result.Status, Is.EqualTo(CanonicalFormsDeltaStatus.Blocked));
                Assert.That(result.CandidateJson, Is.Null);
                Assert.That(result.Findings.Any(finding =>
                    finding.Category == CanonicalProjectionBlockKind.SourceConflict.ToString()),
                    Is.True,
                    string.Join(
                        Environment.NewLine,
                        result.Findings.Select(finding =>
                            $"{finding.Category}: {string.Join("; ", finding.Reasons)}")));
            });
        }

        [Test]
        public void ManifestBindsAllPinnedInputsAffectedIdentityCandidateAndReport()
        {
            CreateSfpWorkbook(_fixture.CurrentSfp, StandardRows(targetAl: "X"));

            var result = RunSfp();
            using var manifest = JsonDocument.Parse(result.ManifestJson);
            var root = manifest.RootElement;

            Assert.Multiple(() =>
            {
                Assert.That(root.GetProperty("previousSourceSha256").GetString(),
                    Is.EqualTo(Hash(_fixture.PreviousSfp)));
                Assert.That(root.GetProperty("currentSourceSha256").GetString(),
                    Is.EqualTo(Hash(_fixture.CurrentSfp)));
                Assert.That(root.GetProperty("counterpartSourceSha256").GetString(),
                    Is.EqualTo(Hash(_fixture.CurrentCommon)));
                Assert.That(root.GetProperty("approvedBaselineSha256").GetString(),
                    Is.EqualTo(Hash(_fixture.Approved)));
                Assert.That(root.GetProperty("affectedIdentitySha256").GetString(),
                    Is.EqualTo(result.AffectedIdentitySha256));
                Assert.That(root.GetProperty("candidateSha256").GetString(),
                    Is.EqualTo(result.CandidateSha256));
                Assert.That(root.GetProperty("reportSha256").GetString(),
                    Is.EqualTo(result.ReportSha256));
                Assert.That(root.GetProperty("packageCorrelationId").GetString(),
                    Is.EqualTo(result.PackageCorrelationId));
            });
        }

        [TestCase("CA")]
        [TestCase("VA")]
        [TestCase("WV")]
        public void NewConfiguredStateDelta_IsNarrowlyAppliedToBasicAndCe(
            string changedState)
        {
            var blank = States().ToDictionary(state => state, _ => "");
            var current = new Dictionary<string, string>(blank)
            {
                [changedState] = "Y"
            };
            CreateSfpWorkbook(
                _fixture.PreviousSfp,
                new[] { Row("SF05010426", blank) });
            CreateSfpWorkbook(
                _fixture.CurrentSfp,
                new[] { Row("SF05010426", current) });

            var result = RunSfp();
            using var document = JsonDocument.Parse(result.CandidateJson);
            var states = document.RootElement.GetProperty("STATES");
            var meaning = RuntimeMeaning(result.CandidateJson);

            Assert.Multiple(() =>
            {
                Assert.That(result.Status, Is.EqualTo(CanonicalFormsDeltaStatus.Generated));
                Assert.That(states.GetProperty("BASIC").EnumerateArray()
                    .Select(item => item.GetString()), Does.Contain(changedState));
                Assert.That(states.GetProperty("CE").EnumerateArray()
                    .Select(item => item.GetString()), Does.Contain(changedState));
                Assert.That(meaning[new RuntimeKey("BASIC", changedState, "SF05010426")],
                    Is.EqualTo("YM"));
                Assert.That(meaning[new RuntimeKey("CE", changedState, "SF05010426")],
                    Is.EqualTo("YM"));
                Assert.That(
                    States().Except(new[] { changedState, "AL", "AZ" })
                        .All(state => !meaning.ContainsKey(
                            new RuntimeKey("BASIC", state, "SF05010426"))),
                    Is.True);
            });
        }

        [Test]
        public void ExactPreviousHashMismatch_FailsWithoutSubstitution()
        {
            CreateSfpWorkbook(_fixture.CurrentSfp, StandardRows(targetAl: "X"));
            var request = SfpRequest() with
            {
                PreviousChangedSource = _fixture.PreviousSfpSource with
                {
                    ExpectedSha256 = new string('F', 64)
                }
            };

            var result = CanonicalFormsDeltaPipeline.Run(request);

            Assert.Multiple(() =>
            {
                Assert.That(result.Status, Is.EqualTo(CanonicalFormsDeltaStatus.Failed));
                Assert.That(result.Reasons.Single(), Does.Contain("hash mismatch"));
                Assert.That(result.CandidateJson, Is.Null);
            });
        }

        [Test]
        public void ProtectedOutputAndAtomicFailure_LeaveNoPackage()
        {
            CreateSfpWorkbook(_fixture.CurrentSfp, StandardRows(targetAl: "X"));
            var protectedRequest = SfpRequest() with
            {
                OutputDirectory = Path.Combine(
                    Path.GetDirectoryName(_fixture.Approved)!,
                    "delta-review")
            };
            var protectedResult = CanonicalFormsDeltaPipeline.Run(
                protectedRequest,
                new CanonicalFormsDeltaOptions { WritePackage = true });
            var safeOutput = Path.Combine(_root, "safe-review");
            var atomicResult = CanonicalFormsDeltaPipeline.Run(
                SfpRequest() with { OutputDirectory = safeOutput },
                new CanonicalFormsDeltaOptions
                {
                    WritePackage = true,
                    InjectAtomicWriteFailure = true
                });

            Assert.Multiple(() =>
            {
                Assert.That(protectedResult.Status,
                    Is.EqualTo(CanonicalFormsDeltaStatus.Failed));
                Assert.That(atomicResult.Status,
                    Is.EqualTo(CanonicalFormsDeltaStatus.Failed));
                Assert.That(Directory.Exists(safeOutput), Is.False);
                Assert.That(Directory.GetDirectories(_root, "*.tmp-*"), Is.Empty);
                Assert.That(Directory.GetDirectories(_root, "*.backup-*"), Is.Empty);
            });
        }

        [Test]
        public void DryFixtureDemonstration_ProducesInMemoryReviewOnly()
        {
            CreateSfpWorkbook(_fixture.CurrentSfp, StandardRows(targetAl: "X"));

            var result = RunSfp();

            TestContext.Out.WriteLine(
                $"DELTA_DEMO status={result.Status} rowDeltas={result.RowDeltas.Count} "
                + $"findings={result.Findings.Count} affected={result.AffectedIdentitySha256} "
                + $"candidate={result.CandidateSha256} report={result.ReportSha256}");
            Assert.Multiple(() =>
            {
                Assert.That(result.Status, Is.EqualTo(CanonicalFormsDeltaStatus.Generated));
                Assert.That(result.Paths, Is.Null);
                Assert.That(Directory.GetDirectories(_root, "*review*"), Is.Empty);
            });
        }

        private CanonicalFormsDeltaResult RunSfp() =>
            CanonicalFormsDeltaPipeline.Run(SfpRequest(), Options());

        private CanonicalFormsDeltaResult RunCommon() =>
            CanonicalFormsDeltaPipeline.Run(CommonRequest(), Options());

        private CanonicalFormsDeltaRequest SfpRequest() =>
            Request(
                FormsMonitorSourceFamily.SFP,
                _fixture.PreviousSfpSource with
                {
                    ExpectedSha256 = Hash(_fixture.PreviousSfp)
                },
                _fixture.CurrentSfpSource with
                {
                    ExpectedSha256 = Hash(_fixture.CurrentSfp)
                },
                _fixture.CurrentCommonSource with
                {
                    ExpectedSha256 = Hash(_fixture.CurrentCommon)
                });

        private CanonicalFormsDeltaRequest CommonRequest() =>
            Request(
                FormsMonitorSourceFamily.Common,
                _fixture.PreviousCommonSource with
                {
                    ExpectedSha256 = Hash(_fixture.PreviousCommon)
                },
                _fixture.CurrentCommonSource with
                {
                    ExpectedSha256 = Hash(_fixture.CurrentCommon)
                },
                _fixture.CurrentSfpSource with
                {
                    ExpectedSha256 = Hash(_fixture.CurrentSfp)
                });

        private CanonicalFormsDeltaRequest Request(
            FormsMonitorSourceFamily family,
            CanonicalFormsDeltaSource previous,
            CanonicalFormsDeltaSource current,
            CanonicalFormsDeltaSource counterpart) =>
            new()
            {
                ChangedSourceFamily = family,
                PreviousChangedSource = previous,
                CurrentChangedSource = current,
                CurrentCounterpartSource = counterpart,
                ApprovedBaselinePath = _fixture.Approved,
                ExpectedApprovedBaselineSha256 = Hash(_fixture.Approved),
                BasicFeaturePath = _fixture.BasicFeature,
                CountryEstateFeaturePath = _fixture.CeFeature,
                EffectiveDate = new DateOnly(2027, 4, 3),
                GeneratorVersion = "CanonicalFormsDeltaPipeline-1.0",
                RuleVersions = new Dictionary<string, string>
                {
                    ["Delta"] = CanonicalFormsDeltaPipeline.RuleVersion,
                    ["Applicability"] =
                        CanonicalApplicabilityInterpreter.RuleVersion,
                    ["Eligibility"] =
                        CanonicalScenarioEligibilityEvaluator.RuleVersion,
                    ["Lifecycle"] =
                        CanonicalEditionLifecycleResolver.RuleVersion,
                    ["Projection"] =
                        CanonicalExpectedRecordProjector.RuleVersion
                }
            };

        private static CanonicalFormsDeltaOptions Options() =>
            new()
            {
                WritePackage = false,
                OverwriteExisting = false,
                GenerationTimestampUtc = new DateTimeOffset(
                    2026,
                    11,
                    3,
                    18,
                    0,
                    0,
                    TimeSpan.Zero)
            };

        private void ConfigureDelta(CanonicalWorkbookDeltaKind kind)
        {
            switch (kind)
            {
                case CanonicalWorkbookDeltaKind.Added:
                    CreateSfpWorkbook(
                        _fixture.PreviousSfp,
                        new[] { Row("SF06010120", "Y", "Y", "Y") });
                    CreateSfpWorkbook(
                        _fixture.CurrentSfp,
                        StandardRows(targetAl: "Y"));
                    WriteApproved(includeTarget: false);
                    break;
                case CanonicalWorkbookDeltaKind.Removed:
                    CreateSfpWorkbook(
                        _fixture.PreviousSfp,
                        StandardRows(targetAl: "Y"));
                    CreateSfpWorkbook(
                        _fixture.CurrentSfp,
                        new[] { Row("SF06010120", "Y", "Y", "Y") });
                    WriteApproved(includeTarget: true);
                    break;
                default:
                    CreateSfpWorkbook(
                        _fixture.PreviousSfp,
                        StandardRows(targetAl: "Y"));
                    CreateSfpWorkbook(
                        _fixture.CurrentSfp,
                        StandardRows(targetAl: "X"));
                    WriteApproved(includeTarget: true);
                    break;
            }
        }

        private Fixture CreateFixture()
        {
            var previousSfp = Path.Combine(_root, "previous-sfp.xlsx");
            var currentSfp = Path.Combine(_root, "current-sfp.xlsx");
            var previousCommon = Path.Combine(_root, "previous-common.xlsx");
            var currentCommon = Path.Combine(_root, "current-common.xlsx");
            var approved = Path.Combine(_root, "approved", "SFP.json");
            var basic = Path.Combine(_root, "SFP_BasicPolicy.feature");
            var ce = Path.Combine(_root, "SFP_CE.feature");
            Directory.CreateDirectory(Path.GetDirectoryName(approved)!);
            CreateSfpWorkbook(previousSfp, StandardRows(targetAl: "Y"));
            CreateSfpWorkbook(currentSfp, StandardRows(targetAl: "Y"));
            CreateCommonWorkbook(
                previousCommon,
                new[] { Row("CF00010120", "Y", "Y", "Y") });
            CreateCommonWorkbook(
                currentCommon,
                new[] { Row("CF00010120", "Y", "Y", "Y") });
            WriteFeature(basic, "BASIC", includeProductSelection: false);
            WriteFeature(ce, "CE", includeProductSelection: true);
            WriteApproved(includeTarget: true, path: approved);
            return new Fixture(
                previousSfp,
                currentSfp,
                previousCommon,
                currentCommon,
                approved,
                basic,
                ce,
                Source("previous-sfp", previousSfp),
                Source("current-sfp", currentSfp),
                Source("previous-common", previousCommon),
                Source("current-common", currentCommon));
        }

        private void WriteApproved(bool includeTarget, string path = null)
        {
            var forms = new Dictionary<string, object>
            {
                ["CF00010120"] = new[] { "AL", "AZ" },
                ["SF06010120"] = new[] { "AL", "AZ" }
            };
            if (includeTarget)
                forms["SF05010426"] = new[] { "AL", "AZ" };
            File.WriteAllText(
                path ?? _fixture.Approved,
                JsonSerializer.Serialize(
                    new Dictionary<string, object>
                    {
                        ["STATES"] = new Dictionary<string, object>
                        {
                            ["BASIC"] = new[] { "AL", "AZ" },
                            ["CE"] = new[] { "AL", "AZ" }
                        },
                        ["BASE"] = forms,
                        ["BASIC"] = new Dictionary<string, object>(),
                        ["CE"] = new Dictionary<string, object>()
                    }));
        }

        private static CanonicalFormsDeltaSource Source(string identity, string path) =>
            new(identity, path, new string('0', 64), $"fixture:{identity}");

        private static IReadOnlyList<RowDefinition> StandardRows(string targetAl) =>
            new[]
            {
                Row("SF05010426", targetAl, "Y", "Y"),
                Row("SF06010120", "Y", "Y", "Y")
            };

        private static RowDefinition Row(
            string form,
            string al,
            string az,
            string ca) =>
            Row(
                form,
                new Dictionary<string, string>(StringComparer.Ordinal)
                {
                    ["AL"] = al,
                    ["AZ"] = az,
                    ["CA"] = ca,
                    ["VA"] = "",
                    ["WV"] = ""
                });

        private static RowDefinition Row(
            string form,
            IReadOnlyDictionary<string, string> states) =>
            new(form, "Mandatory", "", states);

        private static void CreateSfpWorkbook(
            string path,
            IReadOnlyList<RowDefinition> rows,
            string workbookTitle = "")
        {
            using var workbook = new XLWorkbook();
            workbook.Properties.Title = workbookTitle;
            var sheet = workbook.AddWorksheet("Division 0");
            var states = States();
            var headers = new[] { "Form Number", "Selection", "Notes", "Type of Form" }
                .Concat(states)
                .ToArray();
            for (var index = 0; index < headers.Length; index++)
                sheet.Cell(1, index + 1).Value = headers[index];
            for (var index = 0; index < rows.Count; index++)
            {
                var row = rows[index];
                var excelRow = index + 2;
                sheet.Cell(excelRow, 1).Value = row.Form;
                sheet.Cell(excelRow, 2).Value = row.Selection;
                sheet.Cell(excelRow, 3).Value = row.Notes;
                sheet.Cell(excelRow, 4).Value = "BASE";
                for (var stateIndex = 0; stateIndex < states.Length; stateIndex++)
                {
                    sheet.Cell(excelRow, stateIndex + 5).Value =
                        row.States.GetValueOrDefault(states[stateIndex], "");
                }
            }
            workbook.SaveAs(path);
        }

        private static void CreateCommonWorkbook(
            string path,
            IReadOnlyList<RowDefinition> rows)
        {
            using var workbook = new XLWorkbook();
            var sheet = workbook.AddWorksheet("Masterlist");
            sheet.Cell(1, 3).Value = "SFP";
            sheet.Cell(1, 4).Value = "SFP GAP";
            sheet.Cell(1, 10).Value = "Selection";
            sheet.Cell(1, 11).Value = "Notes";
            sheet.Cell(2, 2).Value = "Form Number";
            var states = States();
            for (var index = 0; index < states.Length; index++)
                sheet.Cell(2, index + 5).Value = states[index];
            for (var index = 0; index < rows.Count; index++)
            {
                var row = rows[index];
                var excelRow = index + 3;
                sheet.Cell(excelRow, 2).Value = row.Form;
                sheet.Cell(excelRow, 3).Value = "Y";
                for (var stateIndex = 0; stateIndex < states.Length; stateIndex++)
                {
                    sheet.Cell(excelRow, stateIndex + 5).Value =
                        row.States.GetValueOrDefault(states[stateIndex], "");
                }
                sheet.Cell(excelRow, 10).Value = row.Selection;
                sheet.Cell(excelRow, 11).Value = row.Notes;
            }
            workbook.SaveAs(path);
        }

        private static void WriteFeature(
            string path,
            string product,
            bool includeProductSelection)
        {
            var productRow = includeProductSelection
                ? "      | ProductSelection | CE                                          |\n"
                : "";
            var rows = string.Join(
                "\n",
                States().Select(state => $"      | {state}        |"));
            File.WriteAllText(
                path,
                $$"""
                Feature: {{product}} delta profile
                  Scenario Outline: {{product}} New Business - <StateAbbv>
                    And user selects Special Farm Package and inputs Quote Details
                      | Question       | Answer                                      |
                {{productRow}}      | WritingCompany | American National Property And Casualty Co. |
                    When user validates Forms via Duckcreek for state "<StateAbbv>"
                    Examples:
                      | StateAbbv |
                {{rows}}
                """);
        }

        private static string[] States() => new[] { "AL", "AZ", "CA", "VA", "WV" };

        private static string Hash(string path) =>
            Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(path)));

        private Dictionary<RuntimeKey, string> RuntimeMeaning(string json)
        {
            var service = new FormsValidationService(new DuckCreekFormsConfig());
            using var document = JsonDocument.Parse(json);
            var states = document.RootElement.GetProperty("STATES");
            var result = new Dictionary<RuntimeKey, string>();
            foreach (var product in new[] { "BASIC", "CE" })
            {
                foreach (var state in states.GetProperty(product).EnumerateArray()
                             .Select(item => item.GetString()!))
                {
                    foreach (var form in service.ParseSfpJson(json, state, product)
                                 .Where(form => form.ExpectedStatus != "N"))
                    {
                        result[new RuntimeKey(product, state, form.FormName)] =
                            form.ExpectedStatus;
                    }
                }
            }
            return result;
        }

        private sealed record RowDefinition(
            string Form,
            string Selection,
            string Notes,
            IReadOnlyDictionary<string, string> States);

        private sealed record RuntimeKey(string Product, string State, string Form);

        private sealed record Fixture(
            string PreviousSfp,
            string CurrentSfp,
            string PreviousCommon,
            string CurrentCommon,
            string Approved,
            string BasicFeature,
            string CeFeature,
            CanonicalFormsDeltaSource PreviousSfpSource,
            CanonicalFormsDeltaSource CurrentSfpSource,
            CanonicalFormsDeltaSource PreviousCommonSource,
            CanonicalFormsDeltaSource CurrentCommonSource);
    }
}
