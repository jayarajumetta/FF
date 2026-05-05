// Tools/FormsBaselineGenerator/FormsBaselineGeneratorTool.cs
//
// ─────────────────────────────────────────────────────────────────────────────
// USAGE (PowerShell)
// ─────────────────────────────────────────────────────────────────────────────
//
//   dotnet test --filter "Category=Tools&Name~GenerateFormsBaseline" `
//     -- TestRunParameters.Parameter(name="EXCEL",value="C:\path\to\SFP_Masterlist.xlsx")
//
// OPTIONAL PARAMETERS:
//   OUTPUT    Full path for the generated JSON
//             (default: Resources/ExpectedForms/{LOB}/{LOB}.json relative to project source)
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

namespace Playwright_POC.Tools.FormsBaselineGenerator
{
    [TestFixture]
    public class FormsBaselineGeneratorTool
    {
        private static readonly string[] SupportedStates =
        [
            "AL","AR","AZ","CO","ID","IL","KS","KY","LA","MN",
            "MT","NE","NV","ND","OR","SC","SD","TN","TX","UT","WA","WI","WY"
        ];

        [Test]
        [Category("Tools")]
        [Description("Reads an SFP (or other LOB) Excel masterlist and emits the include-only JSON baseline " +
                     "for FormsValidationService. Pass EXCEL=<path> via TestRunParameters.")]
        public void GenerateFormsBaseline()
        {
            // ── Read parameters ──────────────────────────────────────────────────
            var excelPath = TestContext.Parameters.Get("EXCEL", "");
            var commonExcelPath = TestContext.Parameters.Get("COMMON_EXCEL", "");
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

            // Default output: <project-root>/Resources/ExpectedForms/{LOB}/{LOB}.json
            // AppContext.BaseDirectory = bin/Debug/net8.0 → go up three levels
            var defaultOutput = Path.GetFullPath(Path.Combine(
                AppContext.BaseDirectory, "..", "..", "..",
                "Resources", "ExpectedForms", lob, $"{lob}.json"));
            var outputPath = TestContext.Parameters.Get("OUTPUT", defaultOutput);

            // ── Validate ─────────────────────────────────────────────────────────
            Console.WriteLine();
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║           Forms Baseline Generator                          ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine($"  Excel        : {excelPath}");
            Console.WriteLine($"  Common       : {(string.IsNullOrEmpty(commonExcelPath) ? "(none)" : commonExcelPath)}");
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
                SupportedStates = SupportedStates,
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
                BaselineJsonEmitter.Emit(rows, SupportedStates, lob, outputPath);
                Console.WriteLine($"Baseline written: {outputPath}");
            }

            Assert.Pass($"Done. {rows.Count} forms processed.");
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
                foreach (var section in doc.RootElement.EnumerateObject())
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

        private static bool BoolParam(string name, bool defaultValue)
            => string.Equals(
                TestContext.Parameters.Get(name, defaultValue.ToString()),
                "true", StringComparison.OrdinalIgnoreCase);
    }
}
