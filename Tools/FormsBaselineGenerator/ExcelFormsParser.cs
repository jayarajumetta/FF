using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ClosedXML.Excel;

namespace Playwright_POC.Tools.FormsBaselineGenerator
{
    /// <summary>
    /// Represents a single form row extracted from the Excel masterlist.
    /// </summary>
    public class ParsedFormRow
    {
        public string FormNumber { get; set; } = "";
        public string Section { get; set; } = "BASE";  // BASE / BASIC / CE

        /// <summary>State abbreviation → status (YM / YS / YU / N)</summary>
        public Dictionary<string, string> StateValues { get; set; }
            = new(StringComparer.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Configuration for ExcelFormsParser. All fields have sensible defaults for the
    /// standard SFP Excel masterlist layout.
    /// </summary>
    public class ParserOptions
    {
        /// <summary>
        /// Text to look for in the header row to identify the form-number column.
        /// Leave empty to auto-detect (scans for cells whose values look like form numbers).
        /// </summary>
        public string FormColumnHeader { get; set; } = "";

        /// <summary>
        /// Text to look for in the header row to identify the BASE/BASIC/CE type column.
        /// Leave empty to use the sheet-name mapping instead.
        /// </summary>
        public string TypeColumnHeader { get; set; } = "";

        /// <summary>
        /// Maps sheet name sub-strings (case-insensitive) to their DEFAULT section (BASE/BASIC/CE).
        /// A Type column in the sheet always overrides this mapping.
        /// Add entries here if the Excel uses different sheet naming conventions.
        /// </summary>
        public Dictionary<string, string> SheetToSection { get; set; }
            = new(StringComparer.OrdinalIgnoreCase)
            {
                ["Division 0"] = "BASE",
                ["Div 0"] = "BASE",
                ["Base"] = "BASE",
                ["Division I"] = "BASE",
                ["Division 1"] = "BASE",
                ["Division II"] = "BASIC",
                ["Division 2"] = "BASIC",
                ["Division III"] = "BASIC",
                ["Division 3"] = "BASIC",
                ["Division IV"] = "BASIC",
                ["Division 4"] = "BASIC",
                ["Division V"] = "BASIC",
                ["Division 5"] = "BASIC",
                ["Division VI"] = "BASIC",
                ["Division 6"] = "BASIC",
                ["Division VII"] = "BASIC",
                ["Division 7"] = "BASIC",
                ["X-Form"] = "BASIC",
                ["T-Notice"] = "BASE",
                // NOTE: do NOT add a bare "CE" key — it substring-matches "T-Notices"
                ["Country Estate"] = "CE",
                ["Country"] = "CE",
            };

        /// <summary>Fallback section when a sheet name doesn't match any entry above.</summary>
        public string DefaultSection { get; set; } = "BASE";

        /// <summary>
        /// If non-empty, only sheets whose names contain at least one of these substrings
        /// (case-insensitive) will be parsed. Use to scope the generator to a specific
        /// test policy profile — e.g. "Division 0,Division 1" for a basic Div 0+1 policy.
        /// Leave empty to parse all sheets (default / full masterlist).
        /// </summary>
        public string[] IncludeSheets { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Only state abbreviations in this list will be extracted.
        /// Order is preserved in the emitted JSON.
        /// </summary>
        public string[] SupportedStates { get; set; } = Array.Empty<string>();
    }

    /// <summary>
    /// Reads an SFP (or any LOB) Excel masterlist and returns a flat list of ParsedFormRow objects.
    ///
    /// Layout assumptions (all configurable via ParserOptions):
    ///   - Each worksheet may contain forms for one section (BASE / BASIC / CE).
    ///   - A header row contains two-letter state abbreviations as column headers.
    ///   - A form-number column contains values matching the pattern [A-Z]{1,3}\d{4,}.
    ///   - An optional Type column overrides the sheet-name-based section assignment.
    ///   - Cell values are YM, YS, YU, N, or blank (blank treated as N).
    /// </summary>
    public class ExcelFormsParser
    {
        // Matches standard form numbers: SF01021112, X35690422, FI99020121, NM3421025, T5913
        private static readonly Regex FormNumberRegex =
            new(@"^[A-Z]{1,3}\d{3,}", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public List<ParsedFormRow> Parse(string excelPath, ParserOptions options)
        {
            var allRows = new List<ParsedFormRow>();
            var stateSet = new HashSet<string>(options.SupportedStates, StringComparer.OrdinalIgnoreCase);
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase); // dedup form numbers

            using var workbook = new XLWorkbook(excelPath);

            foreach (var sheet in workbook.Worksheets)
            {
                Console.WriteLine($"  Sheet: \"{sheet.Name}\"");

                // ── Sheet filter (INCLUDE_SHEETS) ─────────────────────────────────────
                if (options.IncludeSheets.Length > 0)
                {
                    var matched = options.IncludeSheets.Any(
                        p => sheet.Name.Contains(p, StringComparison.OrdinalIgnoreCase));
                    if (!matched)
                    {
                        Console.WriteLine("    (excluded by INCLUDE_SHEETS — skipped)");
                        continue;
                    }
                }

                if (!sheet.RowsUsed().Any())
                {
                    Console.WriteLine("    (empty — skipped)");
                    continue;
                }

                var sheetDefaultSection = ResolveSheetSection(sheet.Name, options);
                var dataRows = sheet.RowsUsed().ToList();

                // ── Locate the header row (first row that has ≥3 state-abbrev columns) ──
                int headerRowIndex = -1;
                int formColNum = -1;
                int typeColNum = -1;
                var stateColumns = new Dictionary<int, string>(); // columnNumber → stateAbbrev

                for (int ri = 0; ri < Math.Min(dataRows.Count, 15); ri++)
                {
                    var candidate = dataRows[ri];
                    var statesFound = new Dictionary<int, string>();
                    int formFound = -1;
                    int typeFound = -1;

                    foreach (var cell in candidate.CellsUsed())
                    {
                        var text = GetCellText(cell);
                        var colNum = cell.Address.ColumnNumber;

                        if (stateSet.Contains(text))
                            statesFound[colNum] = text.ToUpperInvariant();

                        if (formFound < 0 && IsFormColumnHeader(text, options.FormColumnHeader))
                            formFound = colNum;

                        if (typeFound < 0 && IsTypeColumnHeader(text, options.TypeColumnHeader))
                            typeFound = colNum;
                    }

                    if (statesFound.Count >= 3)
                    {
                        headerRowIndex = ri;
                        stateColumns = statesFound;
                        formColNum = formFound;
                        typeColNum = typeFound;

                        Console.WriteLine($"    Header at row {candidate.RowNumber()}: " +
                            $"FormCol={(formColNum > 0 ? formColNum.ToString() : "auto-detect")}, " +
                            $"TypeCol={(typeColNum > 0 ? typeColNum.ToString() : "none")}, " +
                            $"States=[{string.Join(",", statesFound.Values.OrderBy(s => s))}]");
                        break;
                    }
                }

                if (headerRowIndex < 0)
                {
                    Console.WriteLine("    No header row with state columns found — skipped.");
                    continue;
                }

                // ── Parse data rows ──────────────────────────────────────────────────
                int rowsParsed = 0;

                foreach (var row in dataRows.Skip(headerRowIndex + 1))
                {
                    var formNumber = ExtractFormNumber(row, formColNum);
                    if (string.IsNullOrEmpty(formNumber))
                        continue;

                    if (seen.Contains(formNumber))
                    {
                        Console.WriteLine($"    WARNING: Duplicate form '{formNumber}' — first occurrence kept.");
                        continue;
                    }
                    seen.Add(formNumber);

                    // Section: type column overrides sheet default
                    var section = sheetDefaultSection;
                    if (typeColNum > 0)
                    {
                        var typeCell = GetCellText(row.Cell(typeColNum));
                        if (!string.IsNullOrEmpty(typeCell))
                            section = NormalizeSection(typeCell.ToUpperInvariant(), sheetDefaultSection);
                    }

                    // Extract per-state values
                    // Y in the Excel means mandatory (YM) — normalize to validation service status codes
                    var stateValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    foreach (var (colNum, stateAbbv) in stateColumns)
                    {
                        var raw = GetCellText(row.Cell(colNum)).ToUpperInvariant();
                        stateValues[stateAbbv] = raw switch
                        {
                            "Y" => "YM",
                            "YM" or "YS" or "YU" => raw,
                            _ => "N"
                        };
                    }

                    // Skip forms where every state is N (nothing to include)
                    if (stateValues.Values.All(v => v == "N"))
                        continue;

                    allRows.Add(new ParsedFormRow
                    {
                        FormNumber = formNumber.ToUpperInvariant(),
                        Section = section,
                        StateValues = stateValues
                    });
                    rowsParsed++;
                }

                Console.WriteLine($"    Parsed {rowsParsed} form rows.");
            }

            return allRows;
        }

        // ── Helpers ──────────────────────────────────────────────────────────────

        private string ExtractFormNumber(IXLRow row, int formColNum)
        {
            if (formColNum > 0)
            {
                // Strip spaces and hyphens: "SF 0001 0120" → "SF00010120", "X-3210 0925" → "X32100925"
                var val = StripToAlphanumeric(GetCellText(row.Cell(formColNum)));
                return FormNumberRegex.IsMatch(val) ? val : "";
            }

            // Auto-detect: scan all used cells for the first form-number-shaped value
            foreach (var cell in row.CellsUsed())
            {
                var text = StripToAlphanumeric(GetCellText(cell));
                if (FormNumberRegex.IsMatch(text))
                    return text;
            }
            return "";
        }

        /// <summary>
        /// Reads a cell's display value regardless of its data type.
        /// GetString() only works for Text cells; GetFormattedString() handles
        /// numbers, booleans, date, and formula-computed values too.
        /// </summary>
        private static string GetCellText(IXLCell cell)
        {
            try { return (cell.GetFormattedString() ?? "").Trim(); }
            catch { return (cell.Value.ToString() ?? "").Trim(); }
        }

        private static string ResolveSheetSection(string sheetName, ParserOptions options)
        {
            foreach (var (key, section) in options.SheetToSection)
                if (sheetName.Contains(key, StringComparison.OrdinalIgnoreCase))
                    return section;
            return options.DefaultSection;
        }

        private static bool IsFormColumnHeader(string text, string hint)
        {
            if (!string.IsNullOrEmpty(hint))
                return text.Equals(hint, StringComparison.OrdinalIgnoreCase);

            return text.StartsWith("Form", StringComparison.OrdinalIgnoreCase)
                || text.Equals("Number", StringComparison.OrdinalIgnoreCase)
                || text.Equals("Edition", StringComparison.OrdinalIgnoreCase);
        }

        private static bool IsTypeColumnHeader(string text, string hint)
        {
            if (!string.IsNullOrEmpty(hint))
                return text.Equals(hint, StringComparison.OrdinalIgnoreCase);

            return text.Equals("Type", StringComparison.OrdinalIgnoreCase)
                || text.Equals("Section", StringComparison.OrdinalIgnoreCase);
        }

        private static string NormalizeSection(string raw, string fallback) => raw switch
        {
            "BASE" => "BASE",
            "BASIC" => "BASIC",
            "CE" => "CE",
            _ => fallback
        };

        // ── Common Forms (multi-LOB file) ─────────────────────────────────────────

        /// <summary>
        /// Parses a "Common Forms MASTERLIST" Excel file that has one column per LOB
        /// in row 1, a two-letter-state sub-header row in row 2 under a "{LOB} GAP"
        /// heading, and Y/blank values in each data row.
        ///
        /// For the generator this produces BASE-section rows that are merged with the
        /// LOB-specific masterlist output (LOB-specific rows win on duplicates).
        /// </summary>
        public List<ParsedFormRow> ParseCommonForms(string excelPath, string lob, ParserOptions options)
        {
            var stateSet = new HashSet<string>(options.SupportedStates, StringComparer.OrdinalIgnoreCase);
            var allRows = new List<ParsedFormRow>();
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var gapLabel = $"{lob} GAP";

            using var workbook = new XLWorkbook(excelPath);

            var sheet = workbook.Worksheets
                .FirstOrDefault(ws => ws.Name.Contains("Masterlist", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"  Sheet: \"{(sheet?.Name ?? "not found")}\"");
            if (sheet == null) return allRows;

            var lastCol = sheet.RangeUsed()?.LastCell().Address.ColumnNumber ?? 0;

            // ── Row 1: find the single LOB column and the "{LOB} GAP" group ──────
            int lobCol = -1;
            int gapStart = -1;
            int gapEnd = lastCol;

            for (int c = 1; c <= lastCol; c++)
            {
                var v = GetCellText(sheet.Cell(1, c));
                if (lobCol < 0 && v.Equals(lob, StringComparison.OrdinalIgnoreCase))
                    lobCol = c;
                if (gapStart < 0 && v.Equals(gapLabel, StringComparison.OrdinalIgnoreCase))
                {
                    gapStart = c;
                    for (int c2 = c + 1; c2 <= lastCol; c2++)
                    {
                        if (!string.IsNullOrEmpty(GetCellText(sheet.Cell(1, c2))))
                        {
                            gapEnd = c2 - 1;
                            break;
                        }
                    }
                }
            }

            if (lobCol < 0 || gapStart < 0)
            {
                Console.WriteLine($"    Could not find '{lob}' column or '{gapLabel}' group — skipped.");
                return allRows;
            }

            // ── Row 2: form-number column + state sub-columns under GAP ───────────
            int fnCol = 2;
            for (int c = 1; c <= Math.Min(10, lastCol); c++)
            {
                if (GetCellText(sheet.Cell(2, c)).Contains("Form", StringComparison.OrdinalIgnoreCase))
                {
                    fnCol = c;
                    break;
                }
            }

            var stateColumns = new Dictionary<int, string>();
            for (int c = gapStart + 1; c <= gapEnd; c++)
            {
                var v = GetCellText(sheet.Cell(2, c));
                if (string.IsNullOrEmpty(v)) continue;

                // TX-ANPAC → TX (first occurrence only); TX-Lloyds → skip
                string stateKey;
                if (v.Equals("TX-ANPAC", StringComparison.OrdinalIgnoreCase))
                    stateKey = "TX";
                else if (v.Contains('-') || v.Contains(' '))
                    continue; // skip compound names like "VA - FF", "TX-Lloyds"
                else
                    stateKey = v.ToUpperInvariant();

                if (stateSet.Contains(stateKey) && !stateColumns.ContainsValue(stateKey))
                    stateColumns[c] = stateKey;
            }

            Console.WriteLine($"    LOB col={lobCol}, GAP cols={gapStart}-{gapEnd}, " +
                $"States=[{string.Join(",", stateColumns.Values.OrderBy(s => s))}]");

            // ── Data rows ─────────────────────────────────────────────────────────
            int rowsParsed = 0;
            foreach (var row in sheet.RowsUsed().Where(r => r.RowNumber() > 2))
            {
                if (!GetCellText(row.Cell(lobCol)).Equals("Y", StringComparison.OrdinalIgnoreCase))
                    continue;

                var fn = StripToAlphanumeric(GetCellText(row.Cell(fnCol))).ToUpperInvariant();
                if (string.IsNullOrEmpty(fn) || !FormNumberRegex.IsMatch(fn)) continue;
                if (seen.Contains(fn)) continue;
                seen.Add(fn);

                // Y in a GAP state column → included (YM); blank → N
                var stateValues = options.SupportedStates.ToDictionary(
                    st => st, st => "N", StringComparer.OrdinalIgnoreCase);

                bool anyGapState = false;
                foreach (var (col, stateAbbv) in stateColumns)
                {
                    if (GetCellText(row.Cell(col)).Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        stateValues[stateAbbv] = "YM";
                        anyGapState = true;
                    }
                }

                // SFP=Y but no GAP states populated → applies to all supported states
                if (!anyGapState)
                    foreach (var st in options.SupportedStates)
                        stateValues[st] = "YM";

                allRows.Add(new ParsedFormRow
                {
                    FormNumber = fn,
                    Section = "BASE",
                    StateValues = stateValues
                });
                rowsParsed++;
            }

            Console.WriteLine($"    Parsed {rowsParsed} common form rows.");
            return allRows;
        }

        /// <summary>Strips everything except letters and digits (handles spaces, hyphens, parens, newlines).</summary>
        private static string StripToAlphanumeric(string raw) =>
            new string(raw.Where(char.IsLetterOrDigit).ToArray());
    }
}
