// Tools/FormsBaselineGenerator/FormsBaselineGeneratorTool.cs
//
// ─────────────────────────────────────────────────────────────────────────────
// USAGE (PowerShell)
// ─────────────────────────────────────────────────────────────────────────────
//
//   dotnet test --filter "Category=Tools&Name~GenerateFormsBaseline" `
//     -- TestRunParameters.Parameter(name="EXCEL",value="C:\path\to\SFP_Masterlist.xlsx")
//
// PARAMETERS:
//   OUTPUT    Full path for the generated JSON
//             (default: TestResults/FormsBaseline/{LOB}_MASTERLIST_CANDIDATE.json)
//   BASIC_FEATURE  Authoritative Basic New Business feature (default: Features/SFP/SFP_BasicPolicy.feature)
//   CE_FEATURE     Authoritative Country Estate feature (default: Features/SFP/SFP_CE.feature)
//   STATE_PROFILE  Required reviewed JSON declaring only ApprovedPendingConfiguration states.
//   LOB       Line-of-business prefix — used for folder/file naming  (default: SFP)
//   DRY_RUN   Print the diff and new JSON preview without writing     (default: false)
//   FORM_COL       Excel column header that contains form numbers          (default: auto-detect)
//   TYPE_COL       Excel column header that contains BASE/BASIC/CE type    (default: auto-detect)
//   INCLUDE_SHEETS Comma-separated sheet name substrings to include from the LOB masterlist.
//                  Omit to parse all sheets (full masterlist).
//                  Example: "Division 0,Division 1" for a basic Div 0+1 policy.
//
// HOW IT WORKS:
//   1. Reads every worksheet in the Excel file.
//   2. Auto-detects the header row by looking for two-letter state abbreviations.
//   3. Maps each sheet to BASE / BASIC / CE using the sheet name (or an explicit Type column).
//   4. Skips rows whose form number doesn't match the expected pattern.
//   5. Emits the include-only JSON format consumed by FormsValidationService.LoadFromIncludeOnlyJson().
//   6. If an existing JSON file is present, prints a diff of added / removed forms before writing.
// ─────────────────────────────────────────────────────────────────────────────

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using NUnit.Framework;

namespace PnCTestAutomation.Tools.FormsBaselineGenerator
{
    [TestFixture]
    public class FormsBaselineGeneratorTool
    {
        [Test]
        [Category("Tools")]
        [Description("Reads an SFP (or other LOB) Excel masterlist and emits the include-only JSON baseline " +
                     "for FormsValidationService. Pass EXCEL=<path> via TestRunParameters.")]
        public void GenerateFormsBaseline()
        {
            // ── Read parameters ──────────────────────────────────────────────────
            var excelPath = TestContext.Parameters.Get("EXCEL", "");
            var commonExcelPath = TestContext.Parameters.Get("COMMON_EXCEL", "");
            var stateProfilePath = TestContext.Parameters.Get("STATE_PROFILE", "");
            var lob = TestContext.Parameters.Get("LOB", "SFP");
            var formCol = TestContext.Parameters.Get("FORM_COL", "");
            var typeCol = TestContext.Parameters.Get("TYPE_COL", "");
            var includeSheetsRaw = TestContext.Parameters.Get("INCLUDE_SHEETS", "");
            var includeSheets = string.IsNullOrWhiteSpace(includeSheetsRaw)
                ? Array.Empty<string>()
                : includeSheetsRaw.Split(',')
                    .Select(s => s.Trim())
                    .Where(s => s.Length > 0)
                    .ToArray();
            var dryRun = BoolParam("DRY_RUN", false);

            // Catalog extraction is a review candidate, not a scenario-qualified runtime baseline.
            // AppContext.BaseDirectory = bin/Debug/net8.0 → go up three levels
            var projectRoot = Path.GetFullPath(Path.Combine(
                AppContext.BaseDirectory, "..", "..", ".."));
            var defaultOutput = Path.GetFullPath(Path.Combine(
                projectRoot,
                "TestResults", "FormsBaseline", $"{lob}_MASTERLIST_CANDIDATE.json"));
            var outputPath = TestContext.Parameters.Get("OUTPUT", defaultOutput);
            var basicFeaturePath = TestContext.Parameters.Get(
                "BASIC_FEATURE",
                Path.Combine(projectRoot, "Features", "SFP", "SFP_BasicPolicy.feature"));
            var ceFeaturePath = TestContext.Parameters.Get(
                "CE_FEATURE",
                Path.Combine(projectRoot, "Features", "SFP", "SFP_CE.feature"));
            RejectApprovedBaselineOutput(outputPath, dryRun);
            var stateProfiles = LoadStateProfiles(basicFeaturePath, ceFeaturePath);
            var pendingStateProfiles = LoadPendingStateProfiles(stateProfilePath, stateProfiles);
            var recognizedStateColumns = stateProfiles.Values
                .SelectMany(states => states)
                .Distinct(StringComparer.Ordinal)
                .OrderBy(state => state, StringComparer.Ordinal)
                .ToArray();

            // ── Validate ─────────────────────────────────────────────────────────
            Console.WriteLine();
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║           Forms Baseline Generator                          ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine($"  Excel        : {excelPath}");
            Console.WriteLine($"  Common       : {(string.IsNullOrEmpty(commonExcelPath) ? "(none)" : commonExcelPath)}");
            Console.WriteLine($"  Basic feature: {basicFeaturePath}");
            Console.WriteLine($"  CE feature   : {ceFeaturePath}");
            Console.WriteLine($"  State profile: {stateProfilePath}");
            Console.WriteLine($"  Source states : {string.Join(", ", recognizedStateColumns)}");
            Console.WriteLine($"  Output       : {outputPath}");
            Console.WriteLine($"  LOB          : {lob}");
            Console.WriteLine($"  DryRun       : {dryRun}");
            Console.WriteLine($"  FormCol      : {(string.IsNullOrEmpty(formCol) ? "auto-detect" : formCol)}");
            Console.WriteLine($"  TypeCol      : {(string.IsNullOrEmpty(typeCol) ? "auto-detect" : typeCol)}");
            Console.WriteLine($"  IncludeSheets: {(includeSheets.Length == 0 ? "(all)" : string.Join(", ", includeSheets))}");
            Console.WriteLine();

            if (string.IsNullOrWhiteSpace(excelPath) || !File.Exists(excelPath))
            {
                Console.WriteLine("ERROR: Provide a valid Excel path via:");
                Console.WriteLine("  TestRunParameters.Parameter(name=\"EXCEL\",value=\"C:\\path\\to\\file.xlsx\")");
                Assert.Fail($"Excel file not found: '{excelPath}'");
                return;
            }

            // ── Parse Excel ──────────────────────────────────────────────────────
            Console.WriteLine("Parsing Excel...");
            var options = new ParserOptions
            {
                FormColumnHeader = formCol,
                TypeColumnHeader = typeCol,
                RecognizedStateColumns = recognizedStateColumns,
                IncludeSheets = includeSheets,
            };

            var parser = new ExcelFormsParser();
            var rows = parser.Parse(excelPath, options);

            // ── Merge Common Forms ───────────────────────────────────────────────
            if (!string.IsNullOrWhiteSpace(commonExcelPath) && File.Exists(commonExcelPath))
            {
                Console.WriteLine();
                Console.WriteLine("Parsing Common Forms...");
                var commonRows = parser.ParseCommonForms(commonExcelPath, lob, options);
                var lobFormNumbers = new HashSet<string>(rows.Select(r => r.FormNumber), StringComparer.OrdinalIgnoreCase);
                var added = commonRows.Where(r => !lobFormNumbers.Contains(r.FormNumber)).ToList();
                rows = rows.Concat(added).ToList();
                Console.WriteLine($"  Common forms merged: {added.Count}");
            }

            Console.WriteLine();
            Console.WriteLine($"Total rows parsed: {rows.Count}");
            foreach (var profile in pendingStateProfiles.Where(profile => profile.Value.Length > 0))
            {
                Console.WriteLine(
                    $"WARNING: {profile.Key} ApprovedPendingConfiguration states are excluded from runtime STATES "
                    + $"until complete feature rows exist: {string.Join(", ", profile.Value)}");
            }

            if (rows.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("No form rows found. Tips:");
                Console.WriteLine("  • Check that state abbreviations (AL, AR, ...) appear in the header row.");
                Console.WriteLine("  • If the form number column has a non-standard header, pass FORM_COL=<header>.");
                Console.WriteLine("  • If the Type column has a non-standard header, pass TYPE_COL=<header>.");
                Assert.Fail("No form rows found in the Excel file.");
                return;
            }

            // ── Diff against existing baseline ───────────────────────────────────
            var diffPath = Path.GetFullPath(Path.Combine(
                AppContext.BaseDirectory, "..", "..", "..",
                "TestResults", "FormsBaseline", $"{lob}_diff.txt"));

            if (File.Exists(outputPath))
            {
                Console.WriteLine();
                Console.WriteLine("Diff vs current baseline:");
                PrintDiff(outputPath, rows, diffPath);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"No existing baseline at {outputPath} — will create new file.");
            }

            // ── Emit JSON ────────────────────────────────────────────────────────
            Console.WriteLine();
            if (dryRun)
            {
                Console.WriteLine("DRY RUN — diff printed above. No file written.");
                Console.WriteLine("Remove DRY_RUN=true (or set to false) to write the baseline.");
            }
            else
            {
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);
                BaselineJsonEmitter.Emit(rows, stateProfiles, pendingStateProfiles, lob, outputPath);
                Console.WriteLine($"Baseline written: {outputPath}");
            }

            Assert.Pass($"Done. {rows.Count} forms processed.");
        }

        [Test]
        [Explicit("Candidate-only canonical orchestration requires explicit local workbook inputs.")]
        [Category("Tools")]
        [Description("Runs the canonical Forms pipeline and writes an isolated review package. "
            + "This never promotes or overwrites an approved baseline.")]
        public void GenerateCanonicalFormsReviewPackage()
        {
            var projectRoot = Path.GetFullPath(Path.Combine(
                AppContext.BaseDirectory, "..", "..", ".."));
            var request = new CanonicalFormsPipelineRequest
            {
                SfpWorkbookPath = TestContext.Parameters.Get("SFP_EXCEL", ""),
                CommonWorkbookPath = TestContext.Parameters.Get("COMMON_EXCEL", ""),
                ApprovedBaselinePath = TestContext.Parameters.Get(
                    "APPROVED_BASELINE",
                    Path.Combine(
                        projectRoot,
                        "Resources",
                        "ExpectedForms",
                        "SFP",
                        "SFP.json")),
                BasicFeaturePath = TestContext.Parameters.Get(
                    "BASIC_FEATURE",
                    Path.Combine(
                        projectRoot,
                        "Features",
                        "SFP",
                        "SFP_BasicPolicy.feature")),
                CountryEstateFeaturePath = TestContext.Parameters.Get(
                    "CE_FEATURE",
                    Path.Combine(
                        projectRoot,
                        "Features",
                        "SFP",
                        "SFP_CE.feature")),
                PendingStateProfilePath = TestContext.Parameters.Get(
                    "STATE_PROFILE",
                    ""),
                OutputDirectory = TestContext.Parameters.Get(
                    "OUTPUT_DIR",
                    Path.Combine(
                        projectRoot,
                        "TestResults",
                        "FormsBaseline",
                        "CanonicalReviewPackage")),
                GeneratorVersion = "CanonicalFormsPipeline-1.0",
                RuleVersions = new Dictionary<string, string>
                {
                    ["Aggregation"] = "1.0",
                    ["Applicability"] =
                        CanonicalApplicabilityInterpreter.RuleVersion,
                    ["ScenarioEligibility"] =
                        CanonicalScenarioEligibilityEvaluator.RuleVersion,
                    ["EditionLifecycle"] =
                        CanonicalEditionLifecycleResolver.RuleVersion,
                    ["Projection"] = CanonicalExpectedRecordProjector.RuleVersion,
                    ["SemanticComparison"] =
                        CanonicalSemanticComparisonService.ComparisonRuleVersion
                }
            };
            var result = CanonicalFormsPipeline.Run(
                request,
                new CanonicalFormsPipelineOptions
                {
                    AllowReviewedChanges =
                        BoolParam("ALLOW_REVIEWED_CHANGES", false),
                    OverwriteExisting = BoolParam("OVERWRITE", false),
                    WritePackage = true
                });
            if (result.Status != CanonicalFormsPackageStatus.Generated)
            {
                Assert.Fail(
                    $"Canonical review package status: {result.Status}. "
                    + string.Join(" ", result.Reasons));
            }
            Assert.Pass(
                $"Canonical review package generated: "
                + $"{result.Paths?.PackageDirectory}; "
                + $"CorrelationId={result.PackageCorrelationId}");
        }

        [Test]
        [Explicit("Operational delta review requires exact acquired workbook paths and hashes.")]
        [Category("Tools")]
        [Description("Runs the change-driven canonical Forms delta pipeline. "
            + "Package writing is disabled unless explicitly reviewed and requested.")]
        public void RunCanonicalFormsDeltaReview()
        {
            var projectRoot = Path.GetFullPath(Path.Combine(
                AppContext.BaseDirectory, "..", "..", ".."));
            var settings = CanonicalFormsDeltaOperation.ReadSettings(
                name => TestContext.Parameters.Get(name, ""),
                Environment.GetEnvironmentVariable,
                projectRoot);
            var result = CanonicalFormsDeltaOperation.Run(settings);
            if (result.Status == CanonicalFormsDeltaStatus.Failed)
            {
                Assert.Fail(
                    $"Canonical Forms delta failed. {string.Join(" ", result.Reasons)}");
            }
            Assert.Pass(
                $"Canonical Forms delta status: {result.Status}; "
                + $"Result={settings.ResultPath}; "
                + $"CorrelationId={result.PackageCorrelationId ?? ""}");
        }

        // ── Diff helper ──────────────────────────────────────────────────────────

        private static void PrintDiff(string existingJsonPath, List<ParsedFormRow> newRows, string diffPath)
        {
            HashSet<string> existingNames;
            try
            {
                var jsonText = File.ReadAllText(existingJsonPath);
                using var doc = JsonDocument.Parse(jsonText, new JsonDocumentOptions
                {
                    CommentHandling = JsonCommentHandling.Skip
                });

                existingNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                foreach (var section in doc.RootElement.EnumerateObject()
                    .Where(section => section.Name is "BASE" or "BASIC" or "CE"))
                    foreach (var form in section.Value.EnumerateObject())
                        existingNames.Add(form.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  (Could not parse existing JSON: {ex.Message})");
                return;
            }

            var newNames = new HashSet<string>(
                newRows.Select(r => r.FormNumber), StringComparer.OrdinalIgnoreCase);

            var added = newNames.Except(existingNames).OrderBy(x => x).ToList();
            var removed = existingNames.Except(newNames).OrderBy(x => x).ToList();

            var lines = new List<string>();

            if (added.Count == 0 && removed.Count == 0)
            {
                lines.Add("No additions or removals — only state values may have changed.");
            }
            else
            {
                if (added.Count > 0)
                {
                    lines.Add($"ADDED ({added.Count}):");
                    foreach (var f in added) lines.Add($"  + {f}");
                }
                if (removed.Count > 0)
                {
                    lines.Add($"REMOVED ({removed.Count}):");
                    foreach (var f in removed) lines.Add($"  - {f}");
                }
            }

            foreach (var line in lines)
                Console.WriteLine($"  {line}");

            Directory.CreateDirectory(Path.GetDirectoryName(diffPath)!);
            File.WriteAllLines(diffPath, lines);
            Console.WriteLine($"  Diff saved: {diffPath}");
        }

        // ── Utility ──────────────────────────────────────────────────────────────

        private static IReadOnlyDictionary<string, string[]> LoadStateProfiles(
            string basicFeaturePath,
            string ceFeaturePath)
        {
            return new Dictionary<string, string[]>(StringComparer.Ordinal)
            {
                ["BASIC"] = LoadScenarioStates(basicFeaturePath, "BASIC"),
                ["CE"] = LoadScenarioStates(ceFeaturePath, "CE")
            };
        }

        private static string[] LoadScenarioStates(string featurePath, string profileName)
            => ScenarioProfileLoader.LoadConfiguredStates(featurePath, profileName);

        private static IReadOnlyDictionary<string, string[]> LoadPendingStateProfiles(
            string stateProfilePath,
            IReadOnlyDictionary<string, string[]> configuredProfiles)
        {
            if (string.IsNullOrWhiteSpace(stateProfilePath) || !File.Exists(stateProfilePath))
                throw new InvalidOperationException(
                    $"STATE_PROFILE file not found: '{stateProfilePath}'. "
                    + "Provide reviewed ApprovedPendingConfiguration declarations for BASIC and CE.");

            try
            {
                using var document = JsonDocument.Parse(
                    File.ReadAllText(stateProfilePath),
                    new JsonDocumentOptions { CommentHandling = JsonCommentHandling.Skip });
                if (document.RootElement.ValueKind != JsonValueKind.Object)
                    throw new InvalidOperationException("STATE_PROFILE must be a JSON object.");

                var result = new Dictionary<string, string[]>(StringComparer.Ordinal);
                var profileNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                foreach (var profile in document.RootElement.EnumerateObject())
                {
                    if (!profileNames.Add(profile.Name)
                        || profile.Name is not ("BASIC" or "CE")
                        || profile.Value.ValueKind != JsonValueKind.Object)
                    {
                        throw new InvalidOperationException(
                            $"Invalid or duplicate STATE_PROFILE scenario '{profile.Name}'.");
                    }

                    var fields = profile.Value.EnumerateObject().ToArray();
                    if (fields.Length != 2
                        || fields.Count(field => field.NameEquals("Status")) != 1
                        || fields.Count(field => field.NameEquals("States")) != 1
                        || profile.Value.GetProperty("Status").ValueKind != JsonValueKind.String
                        || profile.Value.GetProperty("Status").GetString() != "ApprovedPendingConfiguration"
                        || profile.Value.GetProperty("States").ValueKind != JsonValueKind.Array)
                    {
                        throw new InvalidOperationException(
                            $"STATE_PROFILE.{profile.Name} requires Status='ApprovedPendingConfiguration' and a States array.");
                    }

                    var states = new HashSet<string>(StringComparer.Ordinal);
                    foreach (var stateValue in profile.Value.GetProperty("States").EnumerateArray())
                    {
                        var state = stateValue.ValueKind == JsonValueKind.String
                            ? stateValue.GetString()
                            : null;
                        if (state == null
                            || state.Length != 2
                            || state.Any(character => character is < 'A' or > 'Z')
                            || !states.Add(state))
                        {
                            throw new InvalidOperationException(
                                $"Invalid or duplicate pending state in STATE_PROFILE.{profile.Name}.");
                        }
                    }

                    var overlap = states.Intersect(configuredProfiles[profile.Name], StringComparer.Ordinal).ToArray();
                    if (overlap.Length > 0)
                    {
                        throw new InvalidOperationException(
                            $"STATE_PROFILE.{profile.Name} pending states already have configured feature rows: "
                            + string.Join(", ", overlap));
                    }
                    result.Add(profile.Name, states.OrderBy(state => state, StringComparer.Ordinal).ToArray());
                }

                foreach (var profileName in new[] { "BASIC", "CE" })
                    if (!result.ContainsKey(profileName))
                        throw new InvalidOperationException($"STATE_PROFILE requires a {profileName} declaration.");
                return result;
            }
            catch (JsonException exception)
            {
                throw new InvalidOperationException(
                    $"STATE_PROFILE is not valid JSON: {exception.Message}", exception);
            }
        }

        private static void RejectApprovedBaselineOutput(string outputPath, bool dryRun)
        {
            if (dryRun)
                return;

            var approvedBaselineDirectory = Path.GetFullPath(Path.Combine(
                AppContext.BaseDirectory, "..", "..", "..", "Resources", "ExpectedForms", "SFP"));
            var approvedBaselinePaths = new[]
            {
                Path.Combine(approvedBaselineDirectory, "SFP.json"),
                Path.Combine(approvedBaselineDirectory, "SFP_RATEPOLICY.json")
            };
            var resolvedOutputPath = Path.GetFullPath(outputPath);
            var approvedPath = approvedBaselinePaths.FirstOrDefault(path =>
                resolvedOutputPath.Equals(Path.GetFullPath(path), StringComparison.OrdinalIgnoreCase));

            if (approvedPath != null)
            {
                throw new InvalidOperationException(
                    $"Masterlist extraction cannot overwrite approved Forms baseline '{Path.GetFileName(approvedPath)}'. " +
                    "Emit a candidate and review state/company/scenario rules first.");
            }
        }

        private static bool BoolParam(string name, bool defaultValue)
            => string.Equals(
                TestContext.Parameters.Get(name, defaultValue.ToString()),
                "true", StringComparison.OrdinalIgnoreCase);
    }
}
