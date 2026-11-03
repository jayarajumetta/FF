using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ClosedXML.Excel;
using Gherkin;
using Gherkin.Ast;
using NUnit.Framework;
using PnCTestAutomation.Models;
using PnCTestAutomation.Services;
using PnCTestAutomation.Tools.FormsBaselineGenerator;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    [NonParallelizable]
    public class FormsBaselineGeneratorCharacterizationTests
    {
        private static readonly string[] ParserStates = { "AL", "AR", "AZ" };

        private string _temporaryRoot;
        private string _basicFeaturePath;
        private string _ceFeaturePath;
        private string _stateProfilePath;
        private object _originalBaseDirectory;
        private Dictionary<string, string> _originalParameters;

        [SetUp]
        public void CreateIsolatedWorkspace()
        {
            _temporaryRoot = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                nameof(FormsBaselineGeneratorCharacterizationTests),
                Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_temporaryRoot);
            // Synthetic defaults keep configured and pending state authority separate.
            _basicFeaturePath = WriteScenarioFeature("Basic", "AL", "AR", "AZ");
            _ceFeaturePath = WriteScenarioFeature("Country Estate", "AL", "AR", "AZ");
            _stateProfilePath = WritePendingStateProfile("CA", "VA", "WV");

            _originalBaseDirectory = AppContext.GetData("APP_CONTEXT_BASE_DIRECTORY");
            _originalParameters = new Dictionary<string, string>(
                MutableTestParameters(), StringComparer.Ordinal);
        }

        [TearDown]
        public void RestoreProcessStateAndRemoveWorkspace()
        {
            var parameters = MutableTestParameters();
            parameters.Clear();
            foreach (var pair in _originalParameters)
                parameters.Add(pair.Key, pair.Value);

            AppDomain.CurrentDomain.SetData("APP_CONTEXT_BASE_DIRECTORY", _originalBaseDirectory);

            if (Directory.Exists(_temporaryRoot))
                Directory.Delete(_temporaryRoot, recursive: true);

            var fixtureDirectory = Directory.GetParent(_temporaryRoot)?.FullName;
            if (fixtureDirectory != null
                && Directory.Exists(fixtureDirectory)
                && !Directory.EnumerateFileSystemEntries(fixtureDirectory).Any())
            {
                Directory.Delete(fixtureDirectory);
            }
        }

        [TestCase("Form")]
        [TestCase("Form Number")]
        [TestCase("Number")]
        [TestCase("Edition")]
        public void Parser_RecognizesCurrentFormHeaderAliases(string formHeader)
        {
            var workbookPath = CreateWorkbook(
                "Division 0",
                headerRow: 1,
                formHeader,
                ("SF 0001 0120", "Y", "", ""));

            var rows = Parse(workbookPath);

            Assert.That(rows, Has.Count.EqualTo(1));
            Assert.That(rows[0].FormNumber, Is.EqualTo("SF00010120"));
        }

        [TestCase(1)]
        [TestCase(15)]
        public void Parser_RecognizesHeaderWithinCurrentFifteenRowSearchWindow(int headerRow)
        {
            var workbookPath = CreateWorkbook(
                "Division 0",
                headerRow,
                "Form",
                ("SF00010120", "Y", "", ""));

            var rows = Parse(workbookPath);

            Assert.That(rows.Select(row => row.FormNumber), Is.EqualTo(new[] { "SF00010120" }));
        }

        [Test]
        public void Parser_HeaderAfterCurrentSearchWindowIsIgnored()
        {
            var workbookPath = CreateWorkbook(
                "Division 0",
                headerRow: 16,
                "Form",
                ("SF00010120", "Y", "", ""));

            Assert.That(Parse(workbookPath), Is.Empty,
                "The current parser searches only the first 15 used rows for a state header.");
        }

        [Test]
        public void Parser_FewerThanThreeRecognizedStateHeadersProducesNoRows()
        {
            var workbookPath = Path.Combine(_temporaryRoot, "missing-state-header.xlsx");
            using (var workbook = new XLWorkbook())
            {
                var sheet = workbook.AddWorksheet("Division 0");
                sheet.Cell(1, 1).Value = "Form";
                sheet.Cell(1, 2).Value = "AL";
                sheet.Cell(1, 3).Value = "AR";
                sheet.Cell(1, 4).Value = "XX";
                sheet.Cell(2, 1).Value = "SF00010120";
                sheet.Cell(2, 2).Value = "Y";
                workbook.SaveAs(workbookPath);
            }

            Assert.That(Parse(workbookPath), Is.Empty,
                "The current parser requires at least three configured state columns.");
        }

        [Test]
        public void Parser_RecognizesConfiguredCaVaAndWvColumns()
        {
            var workbookPath = CreateWorkbook(
                new[] { "CA", "VA", "WV" },
                ("SF00010120", new[] { "Y", "YS", "YU" }));

            var rows = Parse(workbookPath, "CA", "VA", "WV");

            Assert.Multiple(() =>
            {
                Assert.That(rows, Has.Count.EqualTo(1));
                Assert.That(rows[0].StateValues, Is.EquivalentTo(
                    new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                    {
                        ["CA"] = "YM",
                        ["VA"] = "YS",
                        ["WV"] = "YU"
                    }));
            });
        }

        [Test]
        public void Parser_DoesNotApproveUnconfiguredStateLikeColumn()
        {
            var workbookPath = CreateWorkbook(
                new[] { "AL", "AR", "AZ", "AK" },
                ("SF00010120", new[] { "Y", "", "", "Y" }));

            var rows = Parse(workbookPath, "AL", "AR", "AZ");

            Assert.Multiple(() =>
            {
                Assert.That(rows, Has.Count.EqualTo(1));
                Assert.That(rows[0].StateValues.Keys, Is.EquivalentTo(new[] { "AL", "AR", "AZ" }));
                Assert.That(rows[0].StateValues, Does.Not.ContainKey("AK"));
            });
        }

        [Test]
        public void CanonicalSfpReader_PreservesRawFactsProvenanceAndFindings()
        {
            var workbookPath = CreateCanonicalSfpWorkbook();
            var row = ParseCanonical(workbookPath, "AL", "AR", "AZ").Single();

            Assert.Multiple(() =>
            {
                Assert.That(row.RawFormIdentifier, Is.EqualTo(" SF 0501 0426 "));
                Assert.That(row.NormalizedFormIdentifier, Is.EqualTo("SF05010426"));
                Assert.That(row.ParsedFormNumber, Is.EqualTo("SF0501"));
                Assert.That(row.ParsedEdition, Is.EqualTo("0426"));
                Assert.That(row.TitleDescription, Is.EqualTo("Farm coverage notice"));
                Assert.That(row.SourceFamily, Is.EqualTo(FormSourceFamily.Sfp));
                Assert.That(row.Workbook.Identity, Is.EqualTo(Path.GetFileName(workbookPath)));
                Assert.That(row.Workbook.Path, Is.EqualTo(Path.GetFullPath(workbookPath)));
                Assert.That(row.Workbook.Sha256, Does.Match("^[A-F0-9]{64}$"));
                Assert.That(row.Worksheet, Is.EqualTo("Division 0"));
                Assert.That(row.SourceRowNumber, Is.EqualTo(2));
                Assert.That(row.RelevantCells.Single(cell => cell.Address == "A2").RawValue,
                    Is.EqualTo(" SF 0501 0426 "));
                Assert.That(row.StateMarkers.Select(marker => (marker.RawHeader, marker.RawValue)),
                    Is.EqualTo(new[]
                    {
                        ("AL", " Y "),
                        ("AR", "X"),
                        ("AZ", ""),
                        ("VA - FF", "Y")
                    }));
                Assert.That(row.StateMarkers.Select(marker => marker.Address),
                    Is.EqualTo(new[] { "R2", "S2", "T2", "U2" }));
                Assert.That(row.StateMarkers.Single(marker => marker.RawHeader == "VA - FF"),
                    Has.Property(nameof(CanonicalStateMarker.IsCompanySpecific)).True
                        .And.Property(nameof(CanonicalStateMarker.IsLegacyEligible)).False);
                Assert.That(row.RawSelection, Is.EqualTo("Mandatory"));
                Assert.That(row.RawRules, Is.EqualTo("Rule 1"));
                Assert.That(row.RawPrintRules, Is.EqualTo("Print on issue"));
                Assert.That(row.RawMultipleSelectionCriteria, Is.EqualTo("One per location"));
                Assert.That(row.RawAdditionalSelectionCriteria, Is.EqualTo("Coverage A"));
                Assert.That(row.RawAdditionalRequirements, Is.EqualTo("Signed request"));
                Assert.That(row.RawNotes, Is.EqualTo("Source note"));
                Assert.That(row.RawStartDate, Is.EqualTo("3/21/2027"));
                Assert.That(row.ParsedStartDate, Is.EqualTo(new DateOnly(2027, 3, 21)));
                Assert.That(row.RawStopDate, Is.EqualTo("not a date"));
                Assert.That(row.ParsedStopDate, Is.Null);
                Assert.That(row.RelevantCells.Single(cell => cell.Address == "K2").RawValue,
                    Is.EqualTo("not a date"));
                Assert.That(row.RawEffectiveDate, Is.EqualTo("4/3/2027"));
                Assert.That(row.ParsedEffectiveDate, Is.EqualTo(new DateOnly(2027, 4, 3)));
                Assert.That(row.RawTransactionRules, Is.EqualTo("NB; Renewal"));
                Assert.That(row.TransactionTokens, Is.EqualTo(new[] { "New Business", "Renewal" }));
                Assert.That(row.RawLifecycle, Is.EqualTo("Active"));
                Assert.That(row.RawWithdrawn, Is.EqualTo("No"));
                Assert.That(row.RawReplacement, Is.EqualTo("SF 0501 0120"));
                Assert.That(row.Findings.Select(finding => finding.Code),
                    Is.EqualTo(new[] { "CompanySpecificStateHeader", "StopDateUnparsed" }));
                Assert.That(row.Findings.All(finding => finding.ManualReviewRequired), Is.True);
            });
        }

        [Test]
        public void CanonicalReader_RetainsMalformedOrEditionlessIdentifierWithoutRepair()
        {
            var workbookPath = CreateWorkbook(
                "Division 0",
                headerRow: 1,
                "Form Number",
                ("Notice Without Edition", "Y", "", ""));
            var parser = new ExcelFormsParser();
            var options = new ParserOptions { RecognizedStateColumns = ParserStates };

            var canonical = parser.ParseCanonical(workbookPath, options).Single();

            Assert.Multiple(() =>
            {
                Assert.That(canonical.RawFormIdentifier, Is.EqualTo("Notice Without Edition"));
                Assert.That(canonical.NormalizedFormIdentifier, Is.EqualTo("NOTICEWITHOUTEDITION"));
                Assert.That(canonical.ParsedFormNumber, Is.Null);
                Assert.That(canonical.ParsedEdition, Is.Null);
                Assert.That(canonical.Findings.Select(finding => finding.Code),
                    Does.Contain("InvalidFormIdentifier"));
                Assert.That(LegacyParsedFormProjector.ProjectSfp(new[] { canonical }, options), Is.Empty);
            });
        }

        [Test]
        public void CanonicalReader_RetainsValidEditionlessIdentifierWithWarning()
        {
            var workbookPath = CreateWorkbook(
                "Division 0",
                headerRow: 1,
                "Form Number",
                ("T5913", "Y", "", ""));
            var parser = new ExcelFormsParser();
            var options = new ParserOptions { RecognizedStateColumns = ParserStates };

            var canonical = parser.ParseCanonical(workbookPath, options).Single();
            var legacy = LegacyParsedFormProjector.ProjectSfp(new[] { canonical }, options).Single();

            Assert.Multiple(() =>
            {
                Assert.That(canonical.RawFormIdentifier, Is.EqualTo("T5913"));
                Assert.That(canonical.NormalizedFormIdentifier, Is.EqualTo("T5913"));
                Assert.That(canonical.ParsedFormNumber, Is.Null);
                Assert.That(canonical.ParsedEdition, Is.Null);
                Assert.That(canonical.Findings.Select(finding => finding.Code),
                    Does.Contain("EditionNotParsed"));
                Assert.That(legacy.FormNumber, Is.EqualTo("T5913"));
            });
        }

        [Test]
        public void CanonicalCommonReader_PreservesCompanyHeadersAndSourceMetadata()
        {
            var workbookPath = CreateCanonicalCommonWorkbook();
            var parser = new ExcelFormsParser();
            var options = new ParserOptions
            {
                RecognizedStateColumns = new[] { "AL", "TX", "VA" }
            };

            var row = parser.ParseCommonFormsCanonical(workbookPath, "SFP", options).Single();
            var legacy = LegacyParsedFormProjector.ProjectCommon(new[] { row }, options).Single();

            Assert.Multiple(() =>
            {
                Assert.That(row.SourceFamily, Is.EqualTo(FormSourceFamily.Common));
                Assert.That(row.Worksheet, Is.EqualTo("Masterlist"));
                Assert.That(row.SourceRowNumber, Is.EqualTo(3));
                Assert.That(row.TitleDescription, Is.EqualTo("Common form title"));
                Assert.That(row.StateMarkers.Select(marker => (marker.RawHeader, marker.RawValue)),
                    Is.EqualTo(new[]
                    {
                        ("AL", "Y"),
                        ("TX-ANPAC", "X"),
                        ("VA - FF", "Y"),
                        ("AK", "")
                    }));
                Assert.That(row.StateMarkers.Select(marker => marker.Address),
                    Is.EqualTo(new[] { "E3", "F3", "G3", "H3" }));
                Assert.That(row.StateMarkers.Single(marker => marker.RawHeader == "TX-ANPAC")
                    .IsLegacyEligible, Is.True);
                Assert.That(row.StateMarkers.Single(marker => marker.RawHeader == "VA - FF")
                    .IsLegacyEligible, Is.False);
                Assert.That(row.RawRules, Is.EqualTo("Common rule"));
                Assert.That(row.RawPrintRules, Is.EqualTo("Common print rule"));
                Assert.That(row.RawSelection, Is.EqualTo("Optional"));
                Assert.That(row.RawMultipleSelectionCriteria, Is.EqualTo("Multiple"));
                Assert.That(row.RawAdditionalSelectionCriteria, Is.EqualTo("Criteria"));
                Assert.That(row.RawAdditionalRequirements, Is.EqualTo("Requirement"));
                Assert.That(row.RawNotes, Is.EqualTo("Common note"));
                Assert.That(row.Findings.Select(finding => finding.Code),
                    Is.EqualTo(new[] { "CompanySpecificStateHeader", "CompanySpecificStateHeader", "UnconfiguredStateHeader" }));
                Assert.That(legacy.FormNumber, Is.EqualTo("CF00010120"));
                Assert.That(legacy.StateValues,
                    Is.EquivalentTo(new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                    {
                        ["AL"] = "YM",
                        ["TX"] = "N",
                        ["VA"] = "N"
                    }));
            });
        }

        [Test]
        public void CanonicalReader_IsDeterministicAndLegacyProjectionMatchesParse()
        {
            var workbookPath = CreateCanonicalSfpWorkbook();
            var parser = new ExcelFormsParser();
            var options = new ParserOptions { RecognizedStateColumns = ParserStates };

            var first = parser.ParseCanonical(workbookPath, options);
            var second = parser.ParseCanonical(workbookPath, options);
            var projected = LegacyParsedFormProjector.ProjectSfp(first, options);
            var parsed = parser.Parse(workbookPath, options);

            Assert.Multiple(() =>
            {
                Assert.That(first.Select(CanonicalSnapshot), Is.EqualTo(second.Select(CanonicalSnapshot)));
                Assert.That(projected.Select(LegacySnapshot), Is.EqualTo(parsed.Select(LegacySnapshot)));
                Assert.That(parsed.Single().StateValues,
                    Is.EquivalentTo(new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                    {
                        ["AL"] = "YM",
                        ["AR"] = "N",
                        ["AZ"] = "N"
                    }));
            });
        }

        [Test]
        public void Parser_UnrecognizedFormHeaderFallsBackToRowWideFormAutoDetection()
        {
            var workbookPath = CreateWorkbook(
                "Division 0",
                headerRow: 1,
                "Document",
                ("SF00010120", "Y", "", ""));

            var rows = Parse(workbookPath);

            Assert.That(rows.Select(row => row.FormNumber), Is.EqualTo(new[] { "SF00010120" }),
                "With no recognized form header, the current parser searches the entire data row for a form identity.");
        }

        [Test]
        public void Parser_KnownDefect_DuplicateFormKeepsFirstRowAndDropsLaterStateContribution()
        {
            var workbookPath = CreateWorkbook(
                "Division 0",
                headerRow: 1,
                "Form",
                ("SF00010120", "Y", "", ""),
                ("SF00010120", "", "Y", ""));

            var rows = Parse(workbookPath);

            Assert.Multiple(() =>
            {
                Assert.That(rows, Has.Count.EqualTo(1),
                    "Current global form-number deduplication keeps only the first source row.");
                Assert.That(rows[0].StateValues["AL"], Is.EqualTo("YM"));
                Assert.That(rows[0].StateValues["AR"], Is.EqualTo("N"),
                    "The later AR contribution is currently lost; a later item is expected to correct this defect.");
            });
        }

        [Test]
        public void Parser_KnownDefect_MapsLegacyYToMandatoryYm()
        {
            var workbookPath = CreateWorkbook(
                "Division 0",
                headerRow: 1,
                "Form",
                ("SF00010120", "Y", "", ""));

            var row = Parse(workbookPath).Single();

            Assert.That(row.StateValues["AL"], Is.EqualTo("YM"),
                "This characterizes legacy behavior and is not approval that every workbook Y means mandatory.");
        }

        [Test]
        public void Emitter_ProducesStrictCandidateUsingConfiguredAndPendingStateProfiles()
        {
            var outputPath = Path.Combine(_temporaryRoot, "candidate.json");
            var stateProfiles = new Dictionary<string, string[]>(StringComparer.Ordinal)
            {
                ["BASIC"] = new[] { "AL", "AR", "AZ", "CT" },
                ["CE"] = new[] { "AL" }
            };
            BaselineJsonEmitter.Emit(
                new List<ParsedFormRow>
                {
                    new()
                    {
                        FormNumber = "SF00010120",
                        Section = "BASE",
                        StateValues = ParserStates.ToDictionary(
                            state => state,
                            state => state == "AL" ? "YM" : "N",
                            StringComparer.OrdinalIgnoreCase)
                    },
                    new()
                    {
                        FormNumber = "SF01010120",
                        Section = "BASIC",
                        StateValues = ParserStates.ToDictionary(
                            state => state,
                            state => state == "AL" ? "YM" : "N",
                            StringComparer.OrdinalIgnoreCase)
                    },
                    new()
                    {
                        FormNumber = "SF02010120",
                        Section = "CE",
                        StateValues = ParserStates.ToDictionary(
                            state => state,
                            state => state == "AL" ? "YM" : "N",
                            StringComparer.OrdinalIgnoreCase)
                    }
                },
                stateProfiles,
                new Dictionary<string, string[]>(StringComparer.Ordinal)
                {
                    ["BASIC"] = new[] { "CA", "VA", "WV" },
                    ["CE"] = new[] { "CA", "VA", "WV" }
                },
                "SFP",
                outputPath);

            var json = File.ReadAllText(outputPath);
            var validator = new FormsValidationService(new DuckCreekFormsConfig());
            Assert.Multiple(() =>
            {
                Assert.That(json, Does.Contain("\"STATES\""));
                Assert.That(json, Does.Contain("\"BASIC\": [\"AL\", \"AR\", \"AZ\", \"CT\"]"));
                Assert.That(json, Does.Contain("\"CE\": [\"AL\"]"));
                Assert.That(json, Does.Contain("\"BASE\"").And.Contain("\"BASIC\"").And.Contain("\"CE\""));
                Assert.That(json, Does.Contain("\"SF00010120\": [\"AL\"]"),
                    "The emitter must not use \"all\" when workbook applicability does not cover every approved profile state.");
                Assert.That(
                    validator.ParseSfpJson(json, "AL", "BASIC").Select(form => form.FormName),
                    Is.EqualTo(new[] { "SF00010120", "SF01010120" }));
                Assert.That(
                    validator.ParseSfpJson(json, "AL", "CE").Select(form => form.FormName),
                    Is.EqualTo(new[] { "SF00010120", "SF02010120" }));
            });
        }

        [Test]
        public void Emitter_RejectsParsedScenarioWithoutConfiguredStateProfile()
        {
            var outputPath = Path.Combine(_temporaryRoot, "candidate.json");
            var rows = new List<ParsedFormRow>
            {
                new()
                {
                    FormNumber = "SF01010120",
                    Section = "BASIC",
                    StateValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                    {
                        ["AL"] = "YM"
                    }
                }
            };

            var error = Assert.Throws<InvalidOperationException>(() =>
                BaselineJsonEmitter.Emit(
                    rows,
                    new Dictionary<string, string[]>(StringComparer.Ordinal)
                    {
                        ["CE"] = new[] { "AL" }
                    },
                    new Dictionary<string, string[]>(StringComparer.Ordinal),
                    "SFP",
                    outputPath));

            Assert.Multiple(() =>
            {
                Assert.That(error!.Message, Does.Contain("does not declare parsed scenario").And.Contain("BASIC"));
                Assert.That(File.Exists(outputPath), Is.False);
            });
        }

        [Test]
        public void Tool_RejectsMissingAuthoritativeBasicFeatureBeforeGeneratingCandidate()
        {
            var workbookPath = CreateWorkbook(
                "Division 0",
                headerRow: 1,
                "Form",
                ("SF00010120", "Y", "", ""));
            UseIsolatedAppBaseDirectory();
            SetToolParameters(
                ("EXCEL", workbookPath),
                ("BASIC_FEATURE", Path.Combine(_temporaryRoot, "missing-basic.feature")),
                ("LOB", "SFP"),
                ("DRY_RUN", "false"));

            var error = Assert.Throws<InvalidOperationException>(
                () => new FormsBaselineGeneratorTool().GenerateFormsBaseline());

            Assert.That(error!.Message, Does.Contain("BASIC state-profile feature file not found"));
        }

        [Test]
        public void Tool_RejectsMissingReviewedPendingStateProfile()
        {
            var workbookPath = CreateWorkbook(
                "Division 0",
                headerRow: 1,
                "Form",
                ("SF00010120", "Y", "", ""));
            UseIsolatedAppBaseDirectory();
            SetToolParameters(
                ("EXCEL", workbookPath),
                ("STATE_PROFILE", Path.Combine(_temporaryRoot, "missing-states.json")),
                ("LOB", "SFP"),
                ("DRY_RUN", "false"));

            var error = Assert.Throws<InvalidOperationException>(
                () => new FormsBaselineGeneratorTool().GenerateFormsBaseline());

            Assert.That(error!.Message, Does.Contain("STATE_PROFILE file not found"));
        }

        [Test]
        public void Tool_RejectsPendingStateThatAlreadyHasConfiguredFeatureRow()
        {
            var workbookPath = CreateWorkbook(
                "Division 0",
                headerRow: 1,
                "Form",
                ("SF00010120", "Y", "", ""));
            var invalidProfile = WritePendingStateProfile("AL");
            UseIsolatedAppBaseDirectory();
            SetToolParameters(
                ("EXCEL", workbookPath),
                ("STATE_PROFILE", invalidProfile),
                ("LOB", "SFP"),
                ("DRY_RUN", "false"));

            var error = Assert.Throws<InvalidOperationException>(
                () => new FormsBaselineGeneratorTool().GenerateFormsBaseline());

            Assert.That(error!.Message, Does.Contain("pending states already have configured feature rows").And.Contain("AL"));
        }

        [Test]
        public void Tool_RejectsFeatureProfileWithoutStateAbbreviationColumn()
        {
            var workbookPath = CreateWorkbook(
                "Division 0",
                headerRow: 1,
                "Form",
                ("SF00010120", "Y", "", ""));
            var invalidFeaturePath = Path.Combine(_temporaryRoot, "invalid-basic.feature");
            File.WriteAllText(invalidFeaturePath, """
                Feature: Invalid Basic profile
                  Scenario Outline: Invalid - <State>
                    When user validates Forms via Duckcreek for state "<StateAbbv>"
                    Examples:
                      | State |
                      | AL    |
                """);
            UseIsolatedAppBaseDirectory();
            SetToolParameters(
                ("EXCEL", workbookPath),
                ("BASIC_FEATURE", invalidFeaturePath),
                ("LOB", "SFP"),
                ("DRY_RUN", "false"));

            var error = Assert.Throws<InvalidOperationException>(
                () => new FormsBaselineGeneratorTool().GenerateFormsBaseline());

            Assert.That(error!.Message, Does.Contain("BASIC state-profile examples require a StateAbbv column"));
        }

        [Test]
        public void Tool_ExtractsConfiguredProfilesFromCanonicalBasicAndCeNewBusinessScenarios()
        {
            var workbookPath = CreateWorkbook(
                "Division 0",
                headerRow: 1,
                "Form",
                ("SF00010120", "Y", "", ""));
            var projectRoot = UseIsolatedAppBaseDirectory();
            var candidatePath = Path.Combine(projectRoot, "TestResults", "FormsBaseline", "canonical-profile.json");
            var canonicalBasic = Path.Combine(ProjectRoot(), "Features", "SFP", "SFP_BasicPolicy.feature");
            var canonicalCe = Path.Combine(ProjectRoot(), "Features", "SFP", "SFP_CE.feature");
            var pendingProfile = WritePendingStateProfile("AK", "HI");
            SetToolParameters(
                ("EXCEL", workbookPath),
                ("BASIC_FEATURE", canonicalBasic),
                ("CE_FEATURE", canonicalCe),
                ("STATE_PROFILE", pendingProfile),
                ("OUTPUT", candidatePath),
                ("LOB", "SFP"),
                ("DRY_RUN", "false"));

            InvokeToolToCompletion();

            var json = File.ReadAllText(candidatePath);
            Assert.Multiple(() =>
            {
                Assert.That(ReadProfileStates(json, "BASIC"), Is.EqualTo(ReadFeatureStates(canonicalBasic)));
                Assert.That(ReadProfileStates(json, "CE"), Is.EqualTo(ReadFeatureStates(canonicalCe)));
                Assert.That(ReadProfileStates(json, "BASIC"), Does.Contain("CA").And.Contain("VA").And.Contain("WV"));
                Assert.That(ReadProfileStates(json, "CE"), Does.Contain("CA").And.Contain("VA").And.Contain("WV"));
                Assert.That(json, Does.Contain("APPROVED PENDING CONFIGURATION"));
                Assert.That(json, Does.Contain("BASIC: AK  HI").And.Contain("CE: AK  HI"));
            });
        }

        [Test]
        public void Tool_PassesConfiguredFeatureStateUnionToParserWithoutPendingOrUnknownStates()
        {
            var workbookPath = CreateWorkbook(
                new[] { "AL", "AR", "AZ", "CA", "VA", "WV", "AK", "HI" },
                ("SF00010120", new[] { "", "", "", "Y", "YS", "YU", "Y", "Y" }));
            var basicFeature = WriteScenarioFeature("Basic", "AL", "AR", "CA", "VA");
            var ceFeature = WriteScenarioFeature("Country Estate", "AL", "AZ", "VA", "WV");
            var pendingProfile = WritePendingStateProfile("HI");
            var projectRoot = UseIsolatedAppBaseDirectory();
            var candidatePath = Path.Combine(
                projectRoot,
                "TestResults",
                "FormsBaseline",
                "configured-state-columns.json");
            SetToolParameters(
                ("EXCEL", workbookPath),
                ("BASIC_FEATURE", basicFeature),
                ("CE_FEATURE", ceFeature),
                ("STATE_PROFILE", pendingProfile),
                ("OUTPUT", candidatePath),
                ("LOB", "SFP"),
                ("DRY_RUN", "false"));

            InvokeToolToCompletion();

            var json = File.ReadAllText(candidatePath);
            Assert.Multiple(() =>
            {
                Assert.That(ReadProfileStates(json, "BASIC"), Is.EqualTo(new[] { "AL", "AR", "CA", "VA" }));
                Assert.That(ReadProfileStates(json, "CE"), Is.EqualTo(new[] { "AL", "AZ", "VA", "WV" }));
                Assert.That(json, Does.Contain("\"CA\": \"YM\""));
                Assert.That(json, Does.Contain("\"VA\": \"YS\""));
                Assert.That(json, Does.Contain("\"WV\": \"YU\""));
                Assert.That(json, Does.Not.Contain("\"AK\""));
                Assert.That(json, Does.Contain("BASIC: HI").And.Contain("CE: HI"));
            });
        }

        [Test]
        public void Tool_DefaultOutputWritesOnlyToIsolatedMasterlistCandidatePath()
        {
            var workbookPath = CreateWorkbook(
                "Division 0",
                headerRow: 1,
                "Form",
                ("SF00010120", "Y", "", ""));
            var projectRoot = UseIsolatedAppBaseDirectory();
            SetToolParameters(("EXCEL", workbookPath), ("LOB", "TESTLOB"), ("DRY_RUN", "false"));

            InvokeToolToCompletion();

            var candidatePath = Path.Combine(
                projectRoot, "TestResults", "FormsBaseline", "TESTLOB_MASTERLIST_CANDIDATE.json");
            var candidateJson = File.ReadAllText(candidatePath);
            var validator = new FormsValidationService(new DuckCreekFormsConfig());
            Assert.Multiple(() =>
            {
                Assert.That(File.Exists(candidatePath), Is.True);
                Assert.That(candidateJson, Does.Contain("\"BASIC\": [\"AL\", \"AR\", \"AZ\"]"));
                Assert.That(candidateJson, Does.Contain("\"CE\": [\"AL\", \"AR\", \"AZ\"]"));
                Assert.That(candidateJson, Does.Contain("BASIC: CA  VA  WV").And.Contain("CE: CA  VA  WV"));
                Assert.That(
                    validator.ParseSfpJson(candidateJson, "AL", "BASIC").Select(form => form.FormName),
                    Is.EqualTo(new[] { "SF00010120" }));
                Assert.That(
                    validator.ParseSfpJson(candidateJson, "AL", "CE").Select(form => form.FormName),
                    Is.EqualTo(new[] { "SF00010120" }));
                Assert.Throws<InvalidOperationException>(() => validator.ParseSfpJson(candidateJson, "VA", "BASIC"));
                Assert.Throws<InvalidOperationException>(() => validator.ParseSfpJson(candidateJson, "VA", "CE"));
                Assert.That(
                    File.Exists(Path.Combine(projectRoot, "Resources", "ExpectedForms", "SFP", "SFP.json")),
                    Is.False);
                Assert.That(
                    File.Exists(Path.Combine(projectRoot, "Resources", "ExpectedForms", "SFP", "SFP_RATEPOLICY.json")),
                    Is.False);
            });
        }

        [Test]
        public void Tool_DryRunDoesNotModifyCandidateButWritesCurrentDiffArtifact()
        {
            var workbookPath = CreateWorkbook(
                "Division 0",
                headerRow: 1,
                "Form",
                ("SF00010120", "Y", "", ""));
            var projectRoot = UseIsolatedAppBaseDirectory();
            var candidatePath = Path.Combine(_temporaryRoot, "existing-candidate.json");
            const string originalCandidate = "{\"BASE\":{\"EXISTING\":[\"AL\"]}}";
            File.WriteAllText(candidatePath, originalCandidate);
            SetToolParameters(
                ("EXCEL", workbookPath),
                ("LOB", "SFP"),
                ("OUTPUT", candidatePath),
                ("DRY_RUN", "true"));

            InvokeToolToCompletion();

            var diffPath = Path.Combine(projectRoot, "TestResults", "FormsBaseline", "SFP_diff.txt");
            Assert.Multiple(() =>
            {
                Assert.That(File.ReadAllText(candidatePath), Is.EqualTo(originalCandidate));
                Assert.That(File.Exists(diffPath), Is.True,
                    "Dry-run currently writes a diff artifact when an output candidate already exists.");
                Assert.That(File.ReadAllText(diffPath), Does.Contain("ADDED").And.Contain("REMOVED"));
            });
        }

        [TestCase("SFP.json")]
        [TestCase("SFP_RATEPOLICY.json")]
        public void Tool_RejectsNonDryRunOverwriteOfApprovedBaseline(string baselineFileName)
        {
            var workbookPath = CreateWorkbook(
                "Division 0",
                headerRow: 1,
                "Form",
                ("SF00010120", "Y", "", ""));
            var projectRoot = UseIsolatedAppBaseDirectory();
            var approvedPath = Path.Combine(
                projectRoot,
                "Resources",
                "ExpectedForms",
                "SFP",
                "normalization-segment",
                "..",
                baselineFileName.ToLowerInvariant());
            SetToolParameters(
                ("EXCEL", workbookPath),
                ("LOB", "SFP"),
                ("OUTPUT", approvedPath),
                ("DRY_RUN", "false"));

            var error = Assert.Throws<InvalidOperationException>(
                () => new FormsBaselineGeneratorTool().GenerateFormsBaseline());

            Assert.Multiple(() =>
            {
                Assert.That(error!.Message,
                    Does.Contain("cannot overwrite approved Forms baseline")
                        .And.Contain(baselineFileName));
                Assert.That(File.Exists(Path.GetFullPath(approvedPath)), Is.False);
                Assert.That(
                    Directory.Exists(Path.Combine(projectRoot, "Resources", "ExpectedForms", "SFP")),
                    Is.False);
            });
        }

        [Test]
        public void Tool_DryRunAllowsApprovedBaselineTargetWithoutWritingIt()
        {
            var workbookPath = CreateWorkbook(
                "Division 0",
                headerRow: 1,
                "Form",
                ("SF00010120", "Y", "", ""));
            var projectRoot = UseIsolatedAppBaseDirectory();
            var ratePolicyPath = Path.Combine(
                projectRoot, "Resources", "ExpectedForms", "SFP", "SFP_RATEPOLICY.json");
            SetToolParameters(
                ("EXCEL", workbookPath),
                ("LOB", "SFP"),
                ("OUTPUT", ratePolicyPath),
                ("DRY_RUN", "true"));

            InvokeToolToCompletion();

            Assert.That(File.Exists(ratePolicyPath), Is.False,
                "Dry-run remains non-writing even when the requested output is an approved baseline path.");
        }

        [Test]
        public void Script_CurrentContractWritesRepositoryRunsettingsBeforeInvokingTool()
        {
            var script = File.ReadAllText(Path.Combine(ProjectRoot(), "Scripts", "generate-baseline.ps1"));

            Assert.Multiple(() =>
            {
                Assert.That(script, Does.Contain("$settings = \"$PSScriptRoot\\..\\generate-baseline.runsettings\""));
                Assert.That(script, Does.Contain("| Out-File -Encoding utf8 $settings"));
                Assert.That(script, Does.Contain("[string]$StateProfile"));
                Assert.That(script, Does.Contain("name=\"STATE_PROFILE\" value=\"$StateProfile\""));
                Assert.That(script, Does.Contain("--filter \"Category=Tools&Name~GenerateFormsBaseline\""));
                Assert.That(script, Does.Not.Contain("Remove-Item $settings"));
            });
        }

        private List<ParsedFormRow> Parse(string workbookPath, params string[] recognizedStates) =>
            new ExcelFormsParser().Parse(
                workbookPath,
                new ParserOptions
                {
                    RecognizedStateColumns = recognizedStates.Length == 0
                        ? ParserStates
                        : recognizedStates
                });

        private List<CanonicalFormSourceRow> ParseCanonical(
            string workbookPath,
            params string[] recognizedStates) =>
            new ExcelFormsParser().ParseCanonical(
                workbookPath,
                new ParserOptions
                {
                    RecognizedStateColumns = recognizedStates.Length == 0
                        ? ParserStates
                        : recognizedStates
                });

        private string CreateCanonicalSfpWorkbook()
        {
            var workbookPath = Path.Combine(_temporaryRoot, $"{Guid.NewGuid():N}-canonical-sfp.xlsx");
            using var workbook = new XLWorkbook();
            var sheet = workbook.AddWorksheet("Division 0");
            var headers = new[]
            {
                "Form Number", "Form Title", "Rules", "Print Rules", "Selection",
                "Multiple Selection Criteria", "Additional Selection Criteria",
                "Additional Requirements", "Notes", "Start Date", "Stop Date",
                "Effective Date", "Transaction Rules", "Lifecycle", "Withdrawn",
                "Replacement", "Type of Form", "AL", "AR", "AZ", "VA - FF"
            };
            for (var column = 0; column < headers.Length; column++)
                sheet.Cell(1, column + 1).Value = headers[column];
            var values = new[]
            {
                " SF 0501 0426 ", "Farm coverage notice", "Rule 1", "Print on issue", "Mandatory",
                "One per location", "Coverage A", "Signed request", "Source note", "3/21/2027",
                "not a date", "4/3/2027", "NB; Renewal", "Active", "No", "SF 0501 0120",
                "BASE", " Y ", "X", "", "Y"
            };
            for (var column = 0; column < values.Length; column++)
                sheet.Cell(2, column + 1).Value = values[column];
            workbook.SaveAs(workbookPath);
            return workbookPath;
        }

        private string CreateCanonicalCommonWorkbook()
        {
            var workbookPath = Path.Combine(_temporaryRoot, $"{Guid.NewGuid():N}-canonical-common.xlsx");
            using var workbook = new XLWorkbook();
            var sheet = workbook.AddWorksheet("Masterlist");
            sheet.Cell(1, 3).Value = "SFP";
            sheet.Cell(1, 4).Value = "SFP GAP";
            sheet.Cell(1, 9).Value = "Rules";
            sheet.Cell(1, 10).Value = "Print Rules";
            sheet.Cell(1, 11).Value = "Selection";
            sheet.Cell(1, 12).Value = "Multiple Selection Criteria";
            sheet.Cell(1, 13).Value = "Additional Selection Criteria";
            sheet.Cell(1, 14).Value = "Additional Requirements";
            sheet.Cell(1, 15).Value = "Notes";
            sheet.Cell(1, 16).Value = "Form Title";
            sheet.Cell(2, 2).Value = "Form Number";
            sheet.Cell(2, 5).Value = "AL";
            sheet.Cell(2, 6).Value = "TX-ANPAC";
            sheet.Cell(2, 7).Value = "VA - FF";
            sheet.Cell(2, 8).Value = "AK";
            sheet.Cell(3, 2).Value = "CF 0001 0120";
            sheet.Cell(3, 3).Value = "Y";
            sheet.Cell(3, 5).Value = "Y";
            sheet.Cell(3, 6).Value = "X";
            sheet.Cell(3, 7).Value = "Y";
            sheet.Cell(3, 8).Value = "";
            sheet.Cell(3, 9).Value = "Common rule";
            sheet.Cell(3, 10).Value = "Common print rule";
            sheet.Cell(3, 11).Value = "Optional";
            sheet.Cell(3, 12).Value = "Multiple";
            sheet.Cell(3, 13).Value = "Criteria";
            sheet.Cell(3, 14).Value = "Requirement";
            sheet.Cell(3, 15).Value = "Common note";
            sheet.Cell(3, 16).Value = "Common form title";
            workbook.SaveAs(workbookPath);
            return workbookPath;
        }

        private static string CanonicalSnapshot(CanonicalFormSourceRow row) =>
            string.Join(
                "~",
                row.SourceFamily,
                row.Workbook.Sha256,
                row.Worksheet,
                row.SourceRowNumber,
                row.RawFormIdentifier,
                row.NormalizedFormIdentifier,
                row.ParsedFormNumber,
                row.ParsedEdition,
                string.Join(";", row.StateMarkers.Select(marker =>
                    $"{marker.RawHeader}:{marker.RawValue}:{marker.Address}:{marker.IsLegacyEligible}")),
                string.Join(";", row.RelevantCells.Select(cell =>
                    $"{cell.Header}:{cell.Address}:{cell.RawValue}")),
                string.Join(";", row.Findings.Select(finding =>
                    $"{finding.Code}:{finding.CellAddress}:{finding.ManualReviewRequired}")));

        private static string LegacySnapshot(ParsedFormRow row) =>
            $"{row.FormNumber}|{row.Section}|{string.Join(";", row.StateValues.OrderBy(pair => pair.Key).Select(pair => $"{pair.Key}:{pair.Value}"))}";

        private string CreateWorkbook(
            string sheetName,
            int headerRow,
            string formHeader,
            params (string Form, string AL, string AR, string AZ)[] rows)
        {
            var workbookPath = Path.Combine(_temporaryRoot, $"{Guid.NewGuid():N}.xlsx");
            using var workbook = new XLWorkbook();
            var sheet = workbook.AddWorksheet(sheetName);

            for (var row = 1; row < headerRow; row++)
                sheet.Cell(row, 1).Value = $"Preamble {row}";

            sheet.Cell(headerRow, 1).Value = formHeader;
            sheet.Cell(headerRow, 2).Value = "AL";
            sheet.Cell(headerRow, 3).Value = "AR";
            sheet.Cell(headerRow, 4).Value = "AZ";

            for (var index = 0; index < rows.Length; index++)
            {
                var targetRow = headerRow + index + 1;
                sheet.Cell(targetRow, 1).Value = rows[index].Form;
                sheet.Cell(targetRow, 2).Value = rows[index].AL;
                sheet.Cell(targetRow, 3).Value = rows[index].AR;
                sheet.Cell(targetRow, 4).Value = rows[index].AZ;
            }

            workbook.SaveAs(workbookPath);
            return workbookPath;
        }

        private string CreateWorkbook(
            string[] stateHeaders,
            params (string Form, string[] Values)[] rows)
        {
            var workbookPath = Path.Combine(_temporaryRoot, $"{Guid.NewGuid():N}.xlsx");
            using var workbook = new XLWorkbook();
            var sheet = workbook.AddWorksheet("Division 0");
            sheet.Cell(1, 1).Value = "Form";
            for (var index = 0; index < stateHeaders.Length; index++)
                sheet.Cell(1, index + 2).Value = stateHeaders[index];

            for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
            {
                sheet.Cell(rowIndex + 2, 1).Value = rows[rowIndex].Form;
                for (var stateIndex = 0; stateIndex < stateHeaders.Length; stateIndex++)
                    sheet.Cell(rowIndex + 2, stateIndex + 2).Value = rows[rowIndex].Values[stateIndex];
            }

            workbook.SaveAs(workbookPath);
            return workbookPath;
        }

        private string WriteScenarioFeature(string profileName, params string[] states)
        {
            var path = Path.Combine(_temporaryRoot, $"{Guid.NewGuid():N}-{profileName}.feature");
            var rows = string.Join(
                Environment.NewLine,
                states.Select(state => $"      | {state}        |"));
            File.WriteAllText(path, $$"""
                Feature: {{profileName}} profile
                  Scenario Outline: {{profileName}} New Business - <StateAbbv>
                    When user validates Forms via Duckcreek for state "<StateAbbv>"
                    Examples:
                      | StateAbbv |
                {{rows}}
                """);
            return path;
        }

        private string WritePendingStateProfile(params string[] states)
        {
            var stateList = string.Join(",", states.Select(state => $"\"{state}\""));
            var path = Path.Combine(_temporaryRoot, $"{Guid.NewGuid():N}-pending-states.json");
            File.WriteAllText(path, $$"""
                {
                  "BASIC": {
                    "Status": "ApprovedPendingConfiguration",
                    "States": [{{stateList}}]
                  },
                  "CE": {
                    "Status": "ApprovedPendingConfiguration",
                    "States": [{{stateList}}]
                  }
                }
                """);
            return path;
        }

        private static string[] ReadFeatureStates(string featurePath)
        {
            var scenario = new Parser().Parse(featurePath).Feature.Children.OfType<Scenario>().Single();
            return scenario.Examples.SelectMany(example =>
            {
                var headers = example.TableHeader.Cells.Select(cell => cell.Value).ToArray();
                var stateColumn = Array.IndexOf(headers, "StateAbbv");
                return example.TableBody.Select(row => row.Cells.ElementAt(stateColumn).Value);
            }).OrderBy(state => state, StringComparer.Ordinal).ToArray();
        }

        private static string[] ReadProfileStates(string json, string profileName)
        {
            using var document = System.Text.Json.JsonDocument.Parse(
                json,
                new System.Text.Json.JsonDocumentOptions
                {
                    CommentHandling = System.Text.Json.JsonCommentHandling.Skip
                });
            return document.RootElement.GetProperty("STATES").GetProperty(profileName)
                .EnumerateArray()
                .Select(state => state.GetString()!)
                .ToArray();
        }

        private string UseIsolatedAppBaseDirectory()
        {
            var projectRoot = Path.Combine(_temporaryRoot, "isolated-project");
            var appBase = Path.Combine(projectRoot, "bin", "Debug", "net8.0");
            Directory.CreateDirectory(appBase);
            AppDomain.CurrentDomain.SetData(
                "APP_CONTEXT_BASE_DIRECTORY",
                appBase + Path.DirectorySeparatorChar);
            return projectRoot;
        }

        private static void InvokeToolToCompletion()
        {
            try
            {
                new FormsBaselineGeneratorTool().GenerateFormsBaseline();
                Assert.Fail("The NUnit tool is expected to finish by calling Assert.Pass.");
            }
            catch (SuccessException)
            {
            }
        }

        private void SetToolParameters(params (string Name, string Value)[] values)
        {
            var parameters = MutableTestParameters();
            if (!values.Any(value => value.Name == "BASIC_FEATURE"))
                parameters["BASIC_FEATURE"] = _basicFeaturePath;
            if (!values.Any(value => value.Name == "CE_FEATURE"))
                parameters["CE_FEATURE"] = _ceFeaturePath;
            if (!values.Any(value => value.Name == "STATE_PROFILE"))
                parameters["STATE_PROFILE"] = _stateProfilePath;
            foreach (var (name, value) in values)
                parameters[name] = value;
        }

        private static Dictionary<string, string> MutableTestParameters()
        {
            var field = typeof(TestParameters).GetField(
                "_parameters",
                BindingFlags.Instance | BindingFlags.NonPublic)
                ?? throw new InvalidOperationException("NUnit TestParameters backing store was not found.");
            return (Dictionary<string, string>)field.GetValue(TestContext.Parameters)!;
        }

        private static string ProjectRoot()
        {
            var directory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
            while (directory != null && !File.Exists(Path.Combine(directory.FullName, "TestAutomation.csproj")))
                directory = directory.Parent;
            return directory?.FullName
                ?? throw new InvalidOperationException("Cannot locate TestAutomation.csproj.");
        }
    }
}
