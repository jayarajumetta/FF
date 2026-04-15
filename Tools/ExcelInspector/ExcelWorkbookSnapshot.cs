// Tools/ExcelInspector/ExcelWorkbookSnapshot.cs
//
// Strongly-typed model representing the raw JSON snapshot of an Excel workbook.
// Every cell value is preserved as a string — no summarisation, no domain mapping.

using System.Collections.Generic;

namespace Playwright_POC.Tools.ExcelInspector
{
    /// <summary>
    /// Root container for a full Excel workbook snapshot.
    /// Serialises to:
    /// {
    ///   "_source":      "FileName.xlsx",
    ///   "_generatedOn": "2026-04-09T12:00:00Z",
    ///   "Sheets": { "SheetName": [ { "ColHeader": "CellValue", ... }, ... ] }
    /// }
    /// </summary>
    public sealed class ExcelWorkbookSnapshot
    {
        /// <summary>Original file name (not full path) of the source workbook.</summary>
        public string Source { get; set; } = "";

        /// <summary>UTC timestamp when the snapshot was generated (ISO-8601).</summary>
        public string GeneratedOn { get; set; } = "";

        /// <summary>
        /// One entry per worksheet.  Key = exact worksheet name as it appears in Excel.
        /// Value = ordered list of rows; each row is a dictionary of
        /// verbatim column-header → cell-value-as-string.
        /// </summary>
        public Dictionary<string, List<Dictionary<string, string>>> Sheets { get; set; }
            = new();
    }
}
