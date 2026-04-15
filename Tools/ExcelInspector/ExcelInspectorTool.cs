// Tools/ExcelInspector/ExcelInspectorTool.cs
//
// ─────────────────────────────────────────────────────────────────────────────
// USAGE (PowerShell)
// ─────────────────────────────────────────────────────────────────────────────
//
//   dotnet test --filter "Category=Tools&Name~InspectExcel" `
//     -- TestRunParameters.Parameter(name="EXCEL",value="C:\path\to\file.xlsx") `
//        TestRunParameters.Parameter(name="OUTPUT",value="C:\path\to\output.json")
//
// PARAMETERS:
//   EXCEL   (required) Full path to the .xlsx file to inspect.
//   OUTPUT  (optional) Full path for the generated JSON snapshot.
//             Default: same directory as EXCEL, same base name, .json extension.
//
// HOW IT WORKS:
//   1. Opens every worksheet in the workbook.
//   2. Treats the first used row of each sheet as column headers (verbatim).
//   3. Converts every subsequent non-empty row into a JSON object.
//   4. Writes a single JSON file preserving all sheets, rows, and cell values.
// ─────────────────────────────────────────────────────────────────────────────

using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using NUnit.Framework;

namespace Playwright_POC.Tools.ExcelInspector
{
    [TestFixture]
    public class ExcelInspectorTool
    {
        [Test]
        [Category("Tools")]
        [Description("Dumps an Excel workbook to a raw JSON snapshot preserving all sheets, rows and " +
                     "cell values verbatim. Pass EXCEL=<path> via TestRunParameters.")]
        public void InspectExcel()
        {
            // ── Read parameters ──────────────────────────────────────────────
            var excelPath = TestContext.Parameters.Get("EXCEL", "");

            if (string.IsNullOrWhiteSpace(excelPath) || !File.Exists(excelPath))
            {
                Console.WriteLine("ERROR: Provide a valid Excel path via:");
                Console.WriteLine("  TestRunParameters.Parameter(name=\"EXCEL\",value=\"C:\\path\\to\\file.xlsx\")");
                Assert.Fail($"Excel file not found: '{excelPath}'");
                return;
            }

            var defaultOutput = Path.Combine(
                Path.GetDirectoryName(excelPath)!,
                Path.GetFileNameWithoutExtension(excelPath) + ".json");

            var outputPath = TestContext.Parameters.Get("OUTPUT", defaultOutput);

            // ── Banner ───────────────────────────────────────────────────────
            Console.WriteLine();
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║           Excel Inspector                                   ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine($"  Excel  : {excelPath}");
            Console.WriteLine($"  Output : {outputPath}");
            Console.WriteLine();

            // ── Convert ──────────────────────────────────────────────────────
            Console.WriteLine("Reading workbook...");
            var snapshot = ExcelToJsonConverter.Convert(excelPath);

            int totalRows  = 0;
            int totalSheets = 0;

            foreach (var (sheetName, rows) in snapshot.Sheets)
            {
                Console.WriteLine($"  Sheet: \"{sheetName}\" — {rows.Count} rows");
                totalRows  += rows.Count;
                totalSheets++;
            }

            Console.WriteLine();
            Console.WriteLine($"Total: {totalSheets} sheets, {totalRows} data rows");

            // ── Write JSON ───────────────────────────────────────────────────
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented        = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.Never,
                Encoder              = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            // Map to the exact output shape: _source, _generatedOn, Sheets
            var outputDoc = new
            {
                _source      = snapshot.Source,
                _generatedOn = snapshot.GeneratedOn,
                Sheets       = snapshot.Sheets
            };

            var json = JsonSerializer.Serialize(outputDoc, jsonOptions);

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);
            File.WriteAllText(outputPath, json, new System.Text.UTF8Encoding(false));

            Console.WriteLine();
            Console.WriteLine($"Snapshot written: {outputPath}");
            Console.WriteLine($"  File size: {new FileInfo(outputPath).Length:N0} bytes");

            Assert.Pass($"Done. {totalSheets} sheets, {totalRows} rows written to {outputPath}");
        }
    }
}
