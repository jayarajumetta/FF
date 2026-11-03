using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using ClosedXML.Excel;

namespace PnCTestAutomation.Tools.FormsBaselineGenerator
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
        /// Source columns eligible for extraction. The generator supplies the union of
        /// configured BASIC/CE feature states; scenario-specific approval remains owned
        /// by the emitter's separate state profiles.
        /// </summary>
        public string[] RecognizedStateColumns { get; set; } = Array.Empty<string>();
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
        private static readonly Regex FormPartsRegex =
            new(@"^(?<number>[A-Z]{1,3}\d{3,})(?<edition>\d{4})$",
                RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public List<ParsedFormRow> Parse(string excelPath, ParserOptions options)
        {
            var canonicalRows = ParseCanonical(excelPath, options);
            var rows = LegacyParsedFormProjector.ProjectSfp(canonicalRows, options);
            Console.WriteLine($"  Parsed {rows.Count} form rows.");
            return rows;
        }

        public List<CanonicalFormSourceRow> ParseCanonical(string excelPath, ParserOptions options)
        {
            var allRows = new List<CanonicalFormSourceRow>();
            var stateSet = new HashSet<string>(
                options.RecognizedStateColumns,
                StringComparer.OrdinalIgnoreCase);
            var workbookSource = CreateWorkbookSource(excelPath);

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
                var sourceStateColumns = new Dictionary<int, SourceStateHeader>();
                var ignoredStateLikeColumns = Array.Empty<string>();

                for (int ri = 0; ri < Math.Min(dataRows.Count, 15); ri++)
                {
                    var candidate = dataRows[ri];
                    var statesFound = new Dictionary<int, string>();
                    var stateLikeColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                    int formFound = -1;
                    int typeFound = -1;

                    foreach (var cell in candidate.CellsUsed())
                    {
                        var text = GetCellText(cell);
                        var colNum = cell.Address.ColumnNumber;

                        if (stateSet.Contains(text))
                            statesFound[colNum] = text.ToUpperInvariant();
                        else if (IsStateLikeHeader(text))
                            stateLikeColumns.Add(text.ToUpperInvariant());

                        if (formFound < 0 && IsFormColumnHeader(text, options.FormColumnHeader))
                            formFound = colNum;

                        if (typeFound < 0 && IsTypeColumnHeader(text, options.TypeColumnHeader))
                            typeFound = colNum;
                    }

                    if (statesFound.Count >= 3)
                    {
                        headerRowIndex = ri;
                        stateColumns = statesFound;
                        sourceStateColumns = FindSourceStateColumns(candidate, stateSet, commonGap: false);
                        ignoredStateLikeColumns = stateLikeColumns
                            .OrderBy(state => state, StringComparer.Ordinal)
                            .ToArray();
                        formColNum = formFound;
                        typeColNum = typeFound;

                        Console.WriteLine($"    Header at row {candidate.RowNumber()}: " +
                            $"FormCol={(formColNum > 0 ? formColNum.ToString() : "auto-detect")}, " +
                            $"TypeCol={(typeColNum > 0 ? typeColNum.ToString() : "none")}, " +
                            $"States=[{string.Join(",", statesFound.Values.OrderBy(s => s))}]");
                        if (ignoredStateLikeColumns.Length > 0)
                        {
                            Console.WriteLine(
                                "    WARNING: Ignored unconfigured state-like columns: "
                                + string.Join(", ", ignoredStateLikeColumns));
                        }
                        break;
                    }
                }

                if (headerRowIndex < 0)
                {
                    Console.WriteLine("    No header row with state columns found — skipped.");
                    continue;
                }

                // ── Parse data rows ──────────────────────────────────────────────────
                foreach (var row in dataRows.Skip(headerRowIndex + 1))
                {
                    var formCell = FindFormCell(row, formColNum);
                    var rawFormIdentifier = formCell == null ? "" : GetRawCellText(formCell);
                    if (string.IsNullOrWhiteSpace(rawFormIdentifier))
                        continue;

                    // Section: type column overrides sheet default
                    var section = sheetDefaultSection;
                    var rawType = "";
                    if (typeColNum > 0)
                    {
                        rawType = GetCellText(row.Cell(typeColNum));
                        if (!string.IsNullOrEmpty(rawType))
                            section = NormalizeSection(rawType.ToUpperInvariant(), sheetDefaultSection);
                    }

                    allRows.Add(CreateCanonicalRow(
                        sheet,
                        dataRows[headerRowIndex].RowNumber(),
                        row,
                        formCell!,
                        rawFormIdentifier,
                        section,
                        rawType,
                        FormSourceFamily.Sfp,
                        workbookSource,
                        sourceStateColumns,
                        stateSet));
                }
            }

            return allRows;
        }

        // ── Helpers ──────────────────────────────────────────────────────────────

        private IXLCell FindFormCell(IXLRow row, int formColNum)
        {
            if (formColNum > 0)
                return row.Cell(formColNum);

            // Auto-detect: scan all used cells for the first form-number-shaped value
            foreach (var cell in row.CellsUsed())
            {
                var text = StripToAlphanumeric(GetCellText(cell));
                if (FormNumberRegex.IsMatch(text))
                    return cell;
            }
            return null;
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

        private static string GetRawCellText(IXLCell cell)
        {
            try { return cell.GetFormattedString() ?? ""; }
            catch { return cell.Value.ToString() ?? ""; }
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

        private static bool IsStateLikeHeader(string text) =>
            text.Length == 2 && text.All(character => character is >= 'A' and <= 'Z');

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
            var canonicalRows = ParseCommonFormsCanonical(excelPath, lob, options);
            var rows = LegacyParsedFormProjector.ProjectCommon(canonicalRows, options);
            Console.WriteLine($"    Parsed {rows.Count} common form rows.");
            return rows;
        }

        public List<CanonicalFormSourceRow> ParseCommonFormsCanonical(
            string excelPath,
            string lob,
            ParserOptions options)
        {
            var stateSet = new HashSet<string>(
                options.RecognizedStateColumns,
                StringComparer.OrdinalIgnoreCase);
            var allRows = new List<CanonicalFormSourceRow>();
            var gapLabel = $"{lob} GAP";
            var workbookSource = CreateWorkbookSource(excelPath);

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

            var sourceStateColumns = new Dictionary<int, SourceStateHeader>();
            var ignoredGapColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            for (int c = gapStart + 1; c <= gapEnd; c++)
            {
                var v = GetRawCellText(sheet.Cell(2, c));
                if (string.IsNullOrEmpty(v)) continue;

                var sourceHeader = DescribeStateHeader(v, stateSet, commonGap: true);
                sourceStateColumns[c] = sourceHeader;
                if (!sourceHeader.IsLegacyEligible)
                    ignoredGapColumns.Add(v);
            }

            Console.WriteLine($"    LOB col={lobCol}, GAP cols={gapStart}-{gapEnd}, " +
                $"States=[{string.Join(",", sourceStateColumns.Values
                    .Where(header => header.IsLegacyEligible)
                    .Select(header => header.NormalizedState)
                    .Where(state => state != null)
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .OrderBy(state => state))}]");
            if (ignoredGapColumns.Count > 0)
            {
                Console.WriteLine(
                    "    WARNING: Ignored unconfigured or company-specific GAP columns: "
                    + string.Join(", ", ignoredGapColumns.OrderBy(value => value, StringComparer.OrdinalIgnoreCase)));
            }

            // ── Data rows ─────────────────────────────────────────────────────────
            foreach (var row in sheet.RowsUsed().Where(r => r.RowNumber() > 2))
            {
                if (!GetCellText(row.Cell(lobCol)).Equals("Y", StringComparison.OrdinalIgnoreCase))
                    continue;

                var formCell = row.Cell(fnCol);
                var rawFormIdentifier = GetRawCellText(formCell);
                if (string.IsNullOrWhiteSpace(rawFormIdentifier))
                    continue;

                allRows.Add(CreateCanonicalRow(
                    sheet,
                    headerRowNumber: 2,
                    row,
                    formCell,
                    rawFormIdentifier,
                    "BASE",
                    lob,
                    FormSourceFamily.Common,
                    workbookSource,
                    sourceStateColumns,
                    stateSet));
            }

            return allRows;
        }

        private static CanonicalFormSourceRow CreateCanonicalRow(
            IXLWorksheet sheet,
            int headerRowNumber,
            IXLRow row,
            IXLCell formCell,
            string rawFormIdentifier,
            string section,
            string rawType,
            FormSourceFamily sourceFamily,
            WorkbookSourceInfo workbook,
            IReadOnlyDictionary<int, SourceStateHeader> stateColumns,
            ISet<string> configuredStates)
        {
            var normalizedIdentifier = StripToAlphanumeric(rawFormIdentifier).ToUpperInvariant();
            var findings = new List<CanonicalSourceFinding>();
            var (parsedFormNumber, parsedEdition) = ParseFormParts(
                normalizedIdentifier,
                formCell.Address.ToStringRelative(),
                findings);
            var headerMap = BuildHeaderMap(sheet, headerRowNumber);
            var relevantCells = new List<SourceCellFact>
            {
                new(HeaderForColumn(headerMap, formCell.Address.ColumnNumber, "Form"),
                    formCell.Address.ToStringRelative(),
                    rawFormIdentifier)
            };
            var markers = stateColumns
                .OrderBy(pair => pair.Key)
                .Select(pair =>
                {
                    var cell = row.Cell(pair.Key);
                    var raw = GetRawCellText(cell);
                    relevantCells.Add(new SourceCellFact(
                        pair.Value.RawHeader,
                        cell.Address.ToStringRelative(),
                        raw));
                    if (!pair.Value.IsConfiguredState || pair.Value.IsCompanySpecific)
                    {
                        findings.Add(new CanonicalSourceFinding(
                            pair.Value.IsCompanySpecific
                                ? "CompanySpecificStateHeader"
                                : "UnconfiguredStateHeader",
                            $"Source header '{pair.Value.RawHeader}' is preserved but is not scenario-approved.",
                            cell.Address.ToStringRelative(),
                            ManualReviewRequired: true));
                    }
                    return new CanonicalStateMarker(
                        pair.Value.RawHeader,
                        pair.Value.NormalizedState,
                        cell.Address.ToStringRelative(),
                        raw,
                        pair.Value.IsConfiguredState,
                        pair.Value.IsCompanySpecific,
                        pair.Value.IsLegacyEligible);
                })
                .ToArray();

            var title = ReadFirst(row, headerMap, relevantCells, IsTitleHeader);
            var selection = ReadFirst(row, headerMap, relevantCells, header =>
                HeaderEquals(header, "Selection"));
            var rules = ReadFirst(row, headerMap, relevantCells, header =>
                HeaderEquals(header, "Rules"));
            var printRules = ReadFirst(row, headerMap, relevantCells, header =>
                HeaderEquals(header, "Print Rules"));
            var multipleCriteria = ReadFirst(row, headerMap, relevantCells, header =>
                HeaderContains(header, "Multiple Selection"));
            var additionalCriteria = ReadFirst(row, headerMap, relevantCells, header =>
                HeaderContains(header, "Additional Selection Criteria"));
            var additionalRequirements = ReadFirst(row, headerMap, relevantCells, header =>
                HeaderContains(header, "Additional Requirements"));
            var notes = ReadCombined(row, headerMap, relevantCells, header =>
                HeaderContains(header, "Notes"));
            var rawStartDate = ReadFirst(row, headerMap, relevantCells, IsStartDateHeader);
            var rawStopDate = ReadFirst(row, headerMap, relevantCells, IsStopDateHeader);
            var rawEffectiveDate = ReadFirst(row, headerMap, relevantCells, IsEffectiveDateHeader);
            var rawTransactions = ReadCombined(row, headerMap, relevantCells, header =>
                HeaderContains(header, "Transaction"));
            var rawLifecycle = ReadFirst(row, headerMap, relevantCells, header =>
                HeaderContains(header, "Lifecycle"));
            var rawWithdrawn = ReadCombined(row, headerMap, relevantCells, header =>
                HeaderContains(header, "Withdraw"));
            var rawReplacement = ReadCombined(row, headerMap, relevantCells, header =>
                HeaderContains(header, "Replac"));
            var hints = new[] { sheet.Name, rawType }
                .Concat(ReadAll(row, headerMap, relevantCells, IsSourceHintHeader))
                .Where(value => !string.IsNullOrWhiteSpace(value))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();

            var parsedStartDate = ParseDate(rawStartDate, "StartDateUnparsed", findings);
            var parsedStopDate = ParseDate(rawStopDate, "StopDateUnparsed", findings);
            var parsedEffectiveDate = ParseDate(rawEffectiveDate, "EffectiveDateUnparsed", findings);
            var transactionTokens = ParseTransactionTokens(rawTransactions, findings);

            return new CanonicalFormSourceRow
            {
                RawFormIdentifier = rawFormIdentifier,
                NormalizedFormIdentifier = normalizedIdentifier,
                ParsedFormNumber = parsedFormNumber,
                ParsedEdition = parsedEdition,
                TitleDescription = title,
                SourceFamily = sourceFamily,
                Workbook = workbook,
                Worksheet = sheet.Name,
                SourceRowNumber = row.RowNumber(),
                LegacySection = section,
                SourceDivisionProductHints = hints,
                RelevantCells = relevantCells
                    .GroupBy(cell => cell.Address, StringComparer.OrdinalIgnoreCase)
                    .Select(group => group.First())
                    .OrderBy(cell => XLHelper.GetColumnNumberFromLetter(
                        Regex.Match(cell.Address, @"^[A-Z]+").Value))
                    .ToArray(),
                StateMarkers = markers,
                RawSelection = selection,
                RawRules = rules,
                RawPrintRules = printRules,
                RawMultipleSelectionCriteria = multipleCriteria,
                RawAdditionalSelectionCriteria = additionalCriteria,
                RawAdditionalRequirements = additionalRequirements,
                RawNotes = notes,
                RawStartDate = rawStartDate,
                ParsedStartDate = parsedStartDate,
                RawStopDate = rawStopDate,
                ParsedStopDate = parsedStopDate,
                RawEffectiveDate = rawEffectiveDate,
                ParsedEffectiveDate = parsedEffectiveDate,
                RawTransactionRules = rawTransactions,
                TransactionTokens = transactionTokens,
                RawLifecycle = rawLifecycle,
                RawWithdrawn = rawWithdrawn,
                RawReplacement = rawReplacement,
                Findings = findings
                    .OrderBy(finding => finding.Code, StringComparer.Ordinal)
                    .ThenBy(finding => finding.CellAddress, StringComparer.Ordinal)
                    .ToArray()
            };
        }

        private static Dictionary<int, string> BuildHeaderMap(IXLWorksheet sheet, int headerRowNumber)
        {
            var lastColumn = sheet.RangeUsed()?.LastCell().Address.ColumnNumber ?? 0;
            var headers = new Dictionary<int, string>();
            for (var column = 1; column <= lastColumn; column++)
            {
                var current = GetCellText(sheet.Cell(headerRowNumber, column));
                var prior = headerRowNumber > 1
                    ? GetCellText(sheet.Cell(headerRowNumber - 1, column))
                    : "";
                headers[column] = !string.IsNullOrWhiteSpace(current) ? current : prior;
            }
            return headers;
        }

        private static string ReadFirst(
            IXLRow row,
            IReadOnlyDictionary<int, string> headers,
            ICollection<SourceCellFact> cells,
            Func<string, bool> predicate) =>
            ReadAll(row, headers, cells, predicate).FirstOrDefault() ?? "";

        private static string ReadCombined(
            IXLRow row,
            IReadOnlyDictionary<int, string> headers,
            ICollection<SourceCellFact> cells,
            Func<string, bool> predicate) =>
            string.Join(" | ", ReadAll(row, headers, cells, predicate));

        private static IEnumerable<string> ReadAll(
            IXLRow row,
            IReadOnlyDictionary<int, string> headers,
            ICollection<SourceCellFact> cells,
            Func<string, bool> predicate)
        {
            foreach (var (column, header) in headers.OrderBy(pair => pair.Key))
            {
                if (!predicate(header))
                    continue;
                var cell = row.Cell(column);
                var raw = GetRawCellText(cell);
                cells.Add(new SourceCellFact(header, cell.Address.ToStringRelative(), raw));
                if (!string.IsNullOrWhiteSpace(raw))
                    yield return raw;
            }
        }

        private static string HeaderForColumn(
            IReadOnlyDictionary<int, string> headers,
            int column,
            string fallback) =>
            headers.TryGetValue(column, out var header) && !string.IsNullOrWhiteSpace(header)
                ? header
                : fallback;

        private static (string FormNumber, string Edition) ParseFormParts(
            string normalized,
            string cellAddress,
            ICollection<CanonicalSourceFinding> findings)
        {
            if (!FormNumberRegex.IsMatch(normalized))
            {
                findings.Add(new CanonicalSourceFinding(
                    "InvalidFormIdentifier",
                    $"Form identifier '{normalized}' does not match the legacy form pattern.",
                    cellAddress,
                    ManualReviewRequired: true));
                return (null, null);
            }

            var match = FormPartsRegex.Match(normalized);
            if (match.Success)
                return (match.Groups["number"].Value, match.Groups["edition"].Value);

            findings.Add(new CanonicalSourceFinding(
                "EditionNotParsed",
                $"Form identifier '{normalized}' does not contain a safely parseable edition.",
                cellAddress,
                ManualReviewRequired: true));
            return (null, null);
        }

        private static DateOnly? ParseDate(
            string raw,
            string findingCode,
            ICollection<CanonicalSourceFinding> findings)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return null;
            if (DateOnly.TryParse(raw, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out var date))
                return date;
            findings.Add(new CanonicalSourceFinding(
                findingCode,
                $"Date value '{raw}' could not be parsed safely.",
                null,
                ManualReviewRequired: true));
            return null;
        }

        private static string[] ParseTransactionTokens(
            string raw,
            ICollection<CanonicalSourceFinding> findings)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return Array.Empty<string>();
            var known = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["NB"] = "New Business",
                ["NEW BUSINESS"] = "New Business",
                ["RENEWAL"] = "Renewal",
                ["ENDORSEMENT"] = "Endorsement",
                ["CANCELLATION"] = "Cancellation"
            };
            var rawTokens = raw.Split(new[] { ',', ';', '/', '|' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(token => token.Trim())
                .Where(token => token.Length > 0)
                .ToArray();
            if (rawTokens.All(token => known.ContainsKey(token)))
                return rawTokens.Select(token => known[token]).Distinct(StringComparer.Ordinal).ToArray();
            findings.Add(new CanonicalSourceFinding(
                "TransactionRulesUnparsed",
                $"Transaction rule '{raw}' was preserved but not fully tokenized.",
                null,
                ManualReviewRequired: true));
            return Array.Empty<string>();
        }

        private static Dictionary<int, SourceStateHeader> FindSourceStateColumns(
            IXLRow headerRow,
            ISet<string> configuredStates,
            bool commonGap)
        {
            var result = new Dictionary<int, SourceStateHeader>();
            foreach (var cell in headerRow.CellsUsed())
            {
                var rawHeader = GetRawCellText(cell);
                if (!TryGetStatePrefix(rawHeader, out _))
                    continue;
                result[cell.Address.ColumnNumber] = DescribeStateHeader(
                    rawHeader,
                    configuredStates,
                    commonGap);
            }
            return result;
        }

        private static SourceStateHeader DescribeStateHeader(
            string rawHeader,
            ISet<string> configuredStates,
            bool commonGap)
        {
            TryGetStatePrefix(rawHeader, out var state);
            var normalizedHeader = rawHeader.Trim();
            var companySpecific = normalizedHeader.Length > 2;
            var configured = state != null && configuredStates.Contains(state);
            var legacyEligible = configured && (!companySpecific
                || commonGap && normalizedHeader.Equals("TX-ANPAC", StringComparison.OrdinalIgnoreCase));
            return new SourceStateHeader(
                rawHeader,
                state,
                configured,
                companySpecific,
                legacyEligible);
        }

        private static bool TryGetStatePrefix(string header, out string state)
        {
            var match = Regex.Match(header.Trim(), @"^(?<state>[A-Z]{2})(?:\s*-\s*.+)?$",
                RegexOptions.IgnoreCase);
            state = match.Success ? match.Groups["state"].Value.ToUpperInvariant() : null;
            return match.Success;
        }

        private static WorkbookSourceInfo CreateWorkbookSource(string excelPath)
        {
            var fullPath = Path.GetFullPath(excelPath);
            using var stream = File.OpenRead(fullPath);
            return new WorkbookSourceInfo(
                Path.GetFileName(fullPath),
                fullPath,
                Convert.ToHexString(SHA256.HashData(stream)));
        }

        private static bool HeaderEquals(string header, string expected) =>
            header.Trim().Equals(expected, StringComparison.OrdinalIgnoreCase);

        private static bool HeaderContains(string header, string expected) =>
            header.Trim().Contains(expected, StringComparison.OrdinalIgnoreCase);

        private static bool IsTitleHeader(string header) =>
            HeaderEquals(header, "Form Title")
            || HeaderEquals(header, "Title")
            || HeaderEquals(header, "Description")
            || HeaderEquals(header, "Form Description");

        private static bool IsStartDateHeader(string header) =>
            HeaderContains(header, "Start") && HeaderContains(header, "Date");

        private static bool IsStopDateHeader(string header) =>
            HeaderContains(header, "Stop") && HeaderContains(header, "Date");

        private static bool IsEffectiveDateHeader(string header) =>
            HeaderContains(header, "Effective Date")
            && !IsStartDateHeader(header)
            && !IsStopDateHeader(header);

        private static bool IsSourceHintHeader(string header) =>
            HeaderEquals(header, "Division")
            || HeaderEquals(header, "Product")
            || HeaderEquals(header, "LOB")
            || HeaderEquals(header, "Line of Business")
            || HeaderEquals(header, "Type of Form");

        /// <summary>Strips everything except letters and digits (handles spaces, hyphens, parens, newlines).</summary>
        private static string StripToAlphanumeric(string raw) =>
            new string(raw.Where(char.IsLetterOrDigit).ToArray());

        private sealed record SourceStateHeader(
            string RawHeader,
            string NormalizedState,
            bool IsConfiguredState,
            bool IsCompanySpecific,
            bool IsLegacyEligible);
    }

    public static class LegacyParsedFormProjector
    {
        private static readonly Regex FormNumberRegex =
            new(@"^[A-Z]{1,3}\d{3,}", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public static List<ParsedFormRow> ProjectSfp(
            IEnumerable<CanonicalFormSourceRow> sourceRows,
            ParserOptions options)
        {
            var rows = new List<ParsedFormRow>();
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var source in sourceRows)
            {
                var formNumber = source.NormalizedFormIdentifier;
                if (string.IsNullOrEmpty(formNumber) || !FormNumberRegex.IsMatch(formNumber))
                    continue;
                if (!seen.Add(formNumber))
                {
                    Console.WriteLine($"    WARNING: Duplicate form '{formNumber}' — first occurrence kept.");
                    continue;
                }

                var stateValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                foreach (var marker in source.StateMarkers.Where(marker => marker.IsLegacyEligible))
                {
                    var rawValue = marker.RawValue.Trim().ToUpperInvariant();
                    stateValues[marker.NormalizedState!] = rawValue switch
                    {
                        "Y" => "YM",
                        "YM" or "YS" or "YU" => rawValue,
                        _ => "N"
                    };
                }
                if (stateValues.Values.All(value => value == "N"))
                    continue;
                rows.Add(new ParsedFormRow
                {
                    FormNumber = formNumber,
                    Section = source.LegacySection,
                    StateValues = stateValues
                });
            }
            return rows;
        }

        public static List<ParsedFormRow> ProjectCommon(
            IEnumerable<CanonicalFormSourceRow> sourceRows,
            ParserOptions options)
        {
            var rows = new List<ParsedFormRow>();
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var source in sourceRows)
            {
                var formNumber = source.NormalizedFormIdentifier;
                if (string.IsNullOrEmpty(formNumber) || !FormNumberRegex.IsMatch(formNumber))
                    continue;
                if (!seen.Add(formNumber))
                    continue;

                var stateValues = options.RecognizedStateColumns.ToDictionary(
                    state => state,
                    _ => "N",
                    StringComparer.OrdinalIgnoreCase);
                var anyGapState = false;
                var usedStates = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                foreach (var marker in source.StateMarkers.Where(marker => marker.IsLegacyEligible))
                {
                    var state = marker.NormalizedState!;
                    if (!usedStates.Add(state))
                        continue;
                    if (marker.RawValue.Trim().Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        stateValues[state] = "YM";
                        anyGapState = true;
                    }
                }
                if (!anyGapState)
                {
                    foreach (var state in options.RecognizedStateColumns)
                        stateValues[state] = "YM";
                }
                rows.Add(new ParsedFormRow
                {
                    FormNumber = formNumber,
                    Section = "BASE",
                    StateValues = stateValues
                });
            }
            return rows;
        }
    }
}
