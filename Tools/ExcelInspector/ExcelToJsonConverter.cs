// Tools/ExcelInspector/ExcelToJsonConverter.cs
//
// Converts any Excel (.xlsx) workbook into an ExcelWorkbookSnapshot.
// Rules:
//   - Every worksheet is processed in workbook order.
//   - The FIRST used row of each sheet is treated as the column-header row.
//   - Every subsequent non-empty row becomes one Dictionary<string, string>.
//   - Column headers are stored verbatim (trimmed, no normalisation).
//   - Cell values are always stored as strings via GetFormattedString().
//   - Completely empty rows (all cells blank) are skipped.
//   - Sheets that have no used rows at all are included with an empty list.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClosedXML.Excel;

namespace PnCTestAutomation.Tools.ExcelInspector
{
    public static class ExcelToJsonConverter
    {
        /// <summary>
        /// Reads <paramref name="excelPath"/> and returns a fully-populated
        /// <see cref="ExcelWorkbookSnapshot"/> with every cell value preserved as a string.
        /// </summary>
        /// <param name="excelPath">Absolute path to the .xlsx file.</param>
        public static ExcelWorkbookSnapshot Convert(string excelPath)
        {
            if (!File.Exists(excelPath))
                throw new FileNotFoundException($"Excel file not found: {excelPath}");

            var snapshot = new ExcelWorkbookSnapshot
            {
                Source = Path.GetFileName(excelPath),
                GeneratedOn = DateTime.UtcNow.ToString("o"),
                Sheets = new Dictionary<string, List<Dictionary<string, string>>>()
            };

            using var workbook = new XLWorkbook(excelPath);

            foreach (var sheet in workbook.Worksheets)
            {
                var rows = new List<Dictionary<string, string>>();
                snapshot.Sheets[sheet.Name] = rows;

                var usedRows = sheet.RowsUsed().ToList();
                if (usedRows.Count == 0)
                    continue;

                // First used row → headers
                var headerRow = usedRows[0];
                var headers = new List<(int ColNumber, string Header)>();

                foreach (var cell in headerRow.CellsUsed())
                {
                    var text = GetCellText(cell).Trim();
                    if (!string.IsNullOrEmpty(text))
                        headers.Add((cell.Address.ColumnNumber, text));
                }

                if (headers.Count == 0)
                    continue;

                // Remaining rows → data
                foreach (var row in usedRows.Skip(1))
                {
                    // Skip fully empty rows
                    if (!row.CellsUsed().Any())
                        continue;

                    var record = new Dictionary<string, string>();

                    foreach (var (colNumber, header) in headers)
                    {
                        var cell = row.Cell(colNumber);
                        var value = GetCellText(cell);
                        record[header] = value;
                    }

                    // Also skip rows where every mapped value is blank
                    if (record.Values.All(v => string.IsNullOrWhiteSpace(v)))
                        continue;

                    rows.Add(record);
                }
            }

            return snapshot;
        }

        // ── Helpers ──────────────────────────────────────────────────────────

        private static string GetCellText(IXLCell cell)
        {
            try { return (cell.GetFormattedString() ?? "").Trim(); }
            catch { return (cell.Value.ToString() ?? "").Trim(); }
        }
    }
}
