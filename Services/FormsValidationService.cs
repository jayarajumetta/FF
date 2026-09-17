using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;
using PnCTestAutomation.BusinessOutcomes;
using PnCTestAutomation.Models;

namespace PnCTestAutomation.Services
{
    public interface IFormsValidationService
    {
        List<ExpectedFormEntry> LoadExpectedFormsForLob(
            string lob,
            string state,
            string testCase = "BASIC");

        FormsBaselineSnapshot LoadExpectedBaseline(
            string lob,
            string state,
            string testCase = "BASIC");

        FormsValidationSummary Validate(
            List<ExpectedFormEntry> expected,
            List<ActualFormEntry> actual,
            string lob,
            string state,
            string quoteId);

        string WriteResultsCsv(
            FormsValidationSummary summary,
            string outputPath);
    }

    /// <summary>
    /// Enhanced forms validation engine — replaces the legacy Tosca PowerShell FormsCheck workflow.
    ///
    /// Key improvements over original:
    ///   - Merged single-file-per-LOB baselines (Type column: BASE=shared, B=BASIC-only, C=CE-only)
    ///   - Human-readable validation messages (no more cryptic C-codes as primary output)
    ///   - HTML report generation via FormsReportGenerator
    ///   - Legacy C1–C15 codes preserved as reference field for backward compatibility
    /// </summary>
    public class FormsValidationService : IFormsValidationService
    {
        private readonly DuckCreekFormsConfig _config;

        // Human-readable names for expected status codes
        private static readonly Dictionary<string, string> StatusNames = new(StringComparer.OrdinalIgnoreCase)
        {
            ["YM"] = "Mandatory",
            ["YS"] = "Selected",
            ["YU"] = "Listed (Unchecked)",
            ["N"] = "Not Expected"
        };

        // Human-readable names for DuckCreek selected values
        private static readonly Dictionary<int, string> SelectedNames = new()
        {
            [0] = "Not Checked",
            [1] = "Selected",
            [2] = "Mandatory (Checked)"
        };

        public FormsValidationService(DuckCreekFormsConfig config)
        {
            _config = config;
        }

        // ───────────────────────── Loading expected forms ─────────────────────────

        /// <summary>
        /// Primary loader: resolves the correct baseline file for a LOB/state/testCase combination.
        ///
        /// File resolution order:
        ///   1. Test-case CSV: {LOB}_{testCase}.csv  → load all rows (e.g. SFP_BASIC.csv — Tosca baseline)
        ///   2. Merged CSV:    {LOB}.csv  → filter by Type column (BASE + testCase code)
        ///   3. Include-only JSON: {LOB}.json
        ///   4. Per-state JSON: {LOB}_{state}.json
        /// </summary>
        public List<ExpectedFormEntry> LoadExpectedFormsForLob(
            string lob,
            string state,
            string testCase = "BASIC") =>
            LoadExpectedBaseline(lob, state, testCase).Entries.ToList();

        public FormsBaselineSnapshot LoadExpectedBaseline(
            string lob,
            string state,
            string testCase = "BASIC")
        {
            // Reject any value that contains path separators or other traversal characters
            if (!Regex.IsMatch(lob ?? "", @"^[A-Za-z0-9_]{1,20}$"))
                throw new ArgumentException($"Invalid LOB value: '{lob}'");
            if (!Regex.IsMatch(state ?? "", @"^[A-Za-z]{2,3}$"))
                throw new ArgumentException($"Invalid state value: '{state}'");
            if (!Regex.IsMatch(testCase ?? "BASIC", @"^[A-Za-z0-9_]{1,20}$"))
                throw new ArgumentException($"Invalid testCase value: '{testCase}'");

            var basePath = Path.Combine(AppContext.BaseDirectory, "Resources", "ExpectedForms", lob);

            // 1. Test-case-specific CSV: {LOB}_{testCase}.csv (e.g. SFP_BASIC.csv) — highest priority,
            //    matches the Tosca baseline exactly.
            var legacyCsv = Path.Combine(basePath, $"{lob}_{testCase}.csv");
            if (File.Exists(legacyCsv))
            {
                Console.WriteLine($"Loading test-case baseline: {lob}_{testCase}.csv for state {state}");
                return CreateSnapshot(
                    LoadFromCsv(legacyCsv, state),
                    legacyCsv,
                    lob,
                    testCase);
            }

            // 2. Merged CSV: one file per LOB, filtered by Type column
            var mergedCsv = Path.Combine(basePath, $"{lob}.csv");
            if (File.Exists(mergedCsv))
            {
                var typeCode = GetTypeCodeForTestCase(testCase);
                Console.WriteLine($"Loading merged baseline: {lob}.csv (types: BASE + {typeCode}) for state {state}");
                return CreateSnapshot(
                    LoadFromCsv(
                        mergedCsv,
                        state,
                        typeFilter: new[] { "BASE", typeCode }),
                    mergedCsv,
                    lob,
                    testCase);
            }

            // 3. Include-only JSON: {LOB}.json
            var includeOnlyJson = Path.Combine(basePath, $"{lob}.json");
            if (File.Exists(includeOnlyJson))
            {
                Console.WriteLine($"Loading include-only JSON: {lob}.json for state {state}, testCase {testCase}");
                return CreateSnapshot(
                    LoadFromIncludeOnlyJson(
                        includeOnlyJson,
                        state,
                        testCase),
                    includeOnlyJson,
                    lob,
                    testCase);
            }

            // 4. Per-state JSON (backward compat)
            var jsonPath = Path.Combine(basePath, $"{lob}_{state}.json");
            if (File.Exists(jsonPath))
            {
                return CreateSnapshot(
                    LoadFromJson(jsonPath),
                    jsonPath,
                    lob,
                    testCase);
            }

            throw new FileNotFoundException(
                $"No baseline found for {lob}/{state} (testCase={testCase}). " +
                $"Place {lob}.json (include-only) or {lob}.csv (merged) in Resources/ExpectedForms/{lob}/");
        }

        private FormsBaselineSnapshot CreateSnapshot(
            IReadOnlyList<ExpectedFormEntry> entries,
            string path,
            string lob,
            string testCase)
        {
            var resolvedPath = SafeResolvePath(path);
            return new FormsBaselineSnapshot(
                entries,
                $"{lob}:{testCase}".ToUpperInvariant(),
                _config.GetBaselineVersion(
                    lob.ToUpperInvariant(),
                    testCase.ToUpperInvariant()),
                Convert.ToHexString(
                    SHA256.HashData(File.ReadAllBytes(resolvedPath))));
        }

        /// <summary>
        /// Loads forms from a CSV baseline file with optional Type column filtering.
        /// CSV format: Type,Form,AL,AR,AZ,CO,...,WY
        /// </summary>
        public List<ExpectedFormEntry> LoadFromCsv(string csvPath, string stateColumn, string[] typeFilter = null)
        {
            var resolvedCsv = SafeResolvePath(csvPath);
            var entries = new List<ExpectedFormEntry>();
            using var reader = new StreamReader(resolvedCsv);

            var header = reader.ReadLine();
            if (header == null) return entries;

            var columns = header.Split(',');

            var typeIndex = Array.FindIndex(columns,
                c => c.Trim().Equals("Type", StringComparison.OrdinalIgnoreCase));
            var formIndex = Array.FindIndex(columns,
                c => c.Trim().Equals("Form", StringComparison.OrdinalIgnoreCase));
            if (formIndex < 0) formIndex = 0;

            var stateIndex = Array.FindIndex(columns,
                c => c.Trim().Equals(stateColumn, StringComparison.OrdinalIgnoreCase));
            if (stateIndex < 0)
                throw new InvalidOperationException(
                    $"State column '{stateColumn}' not found in CSV header. Available: {header}");

            var typeFilterSet = typeFilter != null
                ? new HashSet<string>(typeFilter, StringComparer.OrdinalIgnoreCase)
                : null;
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(',');
                if (formIndex >= parts.Length) continue;

                // Type filtering: skip rows that don't match the requested types
                if (typeFilterSet != null && typeIndex >= 0 && typeIndex < parts.Length)
                {
                    var rowType = parts[typeIndex].Trim().Trim('"');
                    if (!typeFilterSet.Contains(rowType)) continue;
                }

                var formName = parts[formIndex].Trim().Trim('"');
                var status = stateIndex < parts.Length
                    ? parts[stateIndex].Trim().Trim('"').ToUpperInvariant()
                    : "";
                var type = typeIndex >= 0 && typeIndex < parts.Length
                    ? parts[typeIndex].Trim().Trim('"')
                    : "";

                if (string.IsNullOrEmpty(formName)) continue;

                if (!seen.Add(formName))
                {
                    throw new InvalidDataException(
                        $"The forms baseline contains duplicate form '{formName}'.");
                }

                entries.Add(new ExpectedFormEntry
                {
                    FormName = formName,
                    ExpectedStatus = status,
                    Type = type
                });
            }

            Console.WriteLine($"  Loaded {entries.Count} expected forms for state {stateColumn}" +
                (typeFilter != null ? $" (types: {string.Join("+", typeFilter)})" : ""));
            return entries;
        }

        private List<ExpectedFormEntry> LoadFromJson(string jsonPath)
        {
            var json = File.ReadAllText(SafeResolvePath(jsonPath));
            var entries = JsonSerializer.Deserialize<List<ExpectedFormEntry>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                ?? new List<ExpectedFormEntry>();

            foreach (var e in entries)
                e.ExpectedStatus = (e.ExpectedStatus ?? "").Trim().ToUpperInvariant();

            return entries;
        }

        /// <summary>
        /// Loads the include-only JSON format: { BASE: { form: "all" | [states] }, BASIC: {...}, CE: {...} }
        /// Only forms expected for the given state+testCase are returned (implicit N for all others).
        /// Supports // line comments and /* */ block comments in the JSON file.
        /// </summary>
        private List<ExpectedFormEntry> LoadFromIncludeOnlyJson(string jsonPath, string state, string testCase)
        {
            var sectionForTestCase = testCase?.ToUpperInvariant() switch
            {
                "CE" => "CE",
                _ => "BASIC"
            };

            var json = File.ReadAllText(SafeResolvePath(jsonPath));
            using var doc = JsonDocument.Parse(json, new JsonDocumentOptions
            {
                CommentHandling = JsonCommentHandling.Skip
            });

            var root = doc.RootElement;
            var entries = new List<ExpectedFormEntry>();
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var sectionName in new[] { "BASE", sectionForTestCase })
            {
                if (!root.TryGetProperty(sectionName, out var section)) continue;

                foreach (var prop in section.EnumerateObject())
                {
                    var formName = prop.Name;
                    if (!seen.Add(formName)) continue;

                    var status = ResolveStatusFromJsonElement(prop.Value, state);
                    if (status == null) continue; // not expected in this state

                    entries.Add(new ExpectedFormEntry
                    {
                        FormName = formName,
                        ExpectedStatus = status,
                        Type = sectionName
                    });
                }
            }

            Console.WriteLine($"  Loaded {entries.Count} expected forms for state {state} " +
                $"(sections: BASE + {sectionForTestCase})");
            return entries;
        }

        private static string ResolveStatusFromJsonElement(JsonElement value, string state)
        {
            switch (value.ValueKind)
            {
                case JsonValueKind.String:
                    return value.GetString()?.Equals("all", StringComparison.OrdinalIgnoreCase) == true
                        ? "YM" : null;

                case JsonValueKind.Array:
                    foreach (var item in value.EnumerateArray())
                    {
                        if (item.GetString()?.Equals(state, StringComparison.OrdinalIgnoreCase) == true)
                            return "YM";
                    }
                    return null;

                case JsonValueKind.Object:
                    return value.TryGetProperty(state, out var statusEl)
                        ? statusEl.GetString()?.ToUpperInvariant()
                        : null;

                default:
                    return null;
            }
        }

        /// <summary>
        /// Maps a test case name to its single-letter Type code in the CSV.
        /// Convention: BASIC→B, CE→C. Extensible for future test cases.
        /// </summary>
        private static string SafeResolvePath(string path)
        {
            var resolved = Path.GetFullPath(path);
            var allowedBase = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "Resources"));
            if (!resolved.StartsWith(allowedBase + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException(
                    $"Path '{resolved}' is outside the permitted Resources directory.");
            return resolved;
        }

        private static string GetTypeCodeForTestCase(string testCase)
        {
            return testCase?.ToUpperInvariant() switch
            {
                "BASIC" => "B",
                "CE" => "C",
                _ => testCase?.Length > 0 ? testCase[..1].ToUpperInvariant() : "B"
            };
        }

        // ───────────────────────── Core validation engine ─────────────────────────

        /// <summary>
        /// Validates actual forms against expected baseline. Produces human-readable messages
        /// with legacy C1–C15 codes preserved as reference.
        /// </summary>
        public FormsValidationSummary Validate(
            List<ExpectedFormEntry> expected,
            List<ActualFormEntry> actual,
            string lob,
            string state,
            string quoteId)
        {
            actual = ApplyCompanyFilters(actual, state);

            var results = new List<FormValidationResult>();
            var actualLookup = actual.ToDictionary(a => a.Name, a => a);

            // Phase 1: Check each expected form against actual response
            foreach (var exp in expected)
            {
                var result = new FormValidationResult
                {
                    FormName = exp.FormName,
                    ExpectedStatus = exp.ExpectedStatus
                };

                if (actualLookup.TryGetValue(exp.FormName, out var policyForm))
                {
                    result.ActualSelected = policyForm.Selected;
                    EvaluateFormOnPolicy(result, exp.ExpectedStatus, policyForm.Selected);
                }
                else
                {
                    result.ActualSelected = -1; // Not on policy
                    EvaluateFormNotOnPolicy(result, exp.ExpectedStatus);
                }

                // Keep reports focused on actionable items by excluding
                // "correctly absent" rows (C12) from output.
                if (!string.Equals(result.ResultCode, "C12", StringComparison.OrdinalIgnoreCase))
                    results.Add(result);
            }

            // Phase 2: Unexpected forms (on policy but not in baseline)
            var expectedNames = new HashSet<string>(expected.Select(e => e.FormName));
            foreach (var policyForm in actual.Where(a => !expectedNames.Contains(a.Name)))
            {
                var selectedDesc = SelectedNames.GetValueOrDefault(policyForm.Selected, $"selected={policyForm.Selected}");
                var code = policyForm.Selected == 2 ? "C14" : "C15";

                results.Add(new FormValidationResult
                {
                    FormName = policyForm.Name,
                    ExpectedStatus = "",
                    ActualSelected = policyForm.Selected,
                    Result = "FAIL",
                    ResultCode = code,
                    Details = $"{code} INFO: Form {policyForm.Name} is not on test case but is listed on policy",
                    Message = $"Not in baseline but found on policy as {selectedDesc}"
                });
            }

            return new FormsValidationSummary
            {
                LOB = lob,
                State = state,
                QuoteId = quoteId,
                TotalForms = results.Count,
                Passed = results.Count(r => r.Result == "PASS"),
                Failed = results.Count(r => r.Result == "FAIL"),
                Info = results.Count(r => r.Result == "INFO"),
                Issues = results.Count(r => r.Result == "ISSUE"),
                Results = results
            };
        }

        // ───────────────────────── Evaluation logic (C1–C15) ─────────────────────

        private static void EvaluateFormOnPolicy(FormValidationResult result, string expected, int selected)
        {
            var expectedDesc = StatusNames.GetValueOrDefault(expected, expected);
            var actualDesc = SelectedNames.GetValueOrDefault(selected, $"selected={selected}");

            switch (expected, selected)
            {
                case ("YM", 2):
                    SetResult(result, "PASS", "C1",
                        $"Expected {expectedDesc}, found {actualDesc}");
                    break;
                case ("YM", 1):
                    SetResult(result, "PASS", "C2",
                        $"Expected {expectedDesc}, found {actualDesc} (not flagged as mandatory but is checked)");
                    break;
                case ("YS", 1):
                    SetResult(result, "PASS", "C3",
                        $"Expected {expectedDesc}, found {actualDesc}");
                    break;
                case ("YS", 0):
                    SetResult(result, "FAIL", "C4",
                        $"Expected {expectedDesc}, but form is {actualDesc}");
                    break;
                case ("N", 2):
                    SetResult(result, "FAIL", "C5",
                        $"Expected {expectedDesc}, but form is present and {actualDesc}");
                    break;
                case ("YM", 0):
                    SetResult(result, "FAIL", "C6",
                        $"Expected {expectedDesc}, but form is {actualDesc}");
                    break;
                case ("N", 0):
                    SetResult(result, "FAIL", "C7",
                        $"Expected {expectedDesc}, but form is present on policy (unchecked)");
                    break;
                case ("YU", 0):
                    SetResult(result, "PASS", "C8",
                        $"Expected {expectedDesc}, found {actualDesc} — correctly listed but unchecked");
                    break;
                case ("N", 1):
                    SetResult(result, "FAIL", "C9",
                        $"Expected {expectedDesc}, but form is present and {actualDesc}");
                    break;
                default:
                    SetResult(result, "ISSUE", "C10",
                        $"Unexpected combination: expected={expected}, actual selected={selected} — needs review");
                    break;
            }
        }

        private static void EvaluateFormNotOnPolicy(FormValidationResult result, string expected)
        {
            var expectedDesc = StatusNames.GetValueOrDefault(expected, expected);

            switch (expected)
            {
                case "YM" or "YS" or "YU":
                    SetResult(result, "FAIL", "C11",
                        $"Expected {expectedDesc}, but form is missing from policy entirely");
                    break;
                case "N":
                    SetResult(result, "PASS", "C12",
                        $"Correctly absent — expected {expectedDesc} and form is not on policy");
                    break;
                default:
                    SetResult(result, "ISSUE", "C13",
                        $"Unknown expected status '{expected}' and form is not on policy — needs review");
                    break;
            }
        }

        private static void SetResult(FormValidationResult result, string outcome, string code, string message)
        {
            result.Result = outcome;
            result.ResultCode = code;
            result.Message = message;
            // Legacy Details field for backward compatibility with CSV format
            result.Details = $"{code} {outcome}: Form {result.FormName} — {message}";
        }

        // ───────────────────────── Output: CSV results ───────────────────────────

        /// <summary>
        /// Saves results CSV with both human-readable and legacy formats.
        /// </summary>
        public string WriteResultsCsv(
            FormsValidationSummary summary,
            string outputPath)
        {
            var filePath = Path.GetFullPath(outputPath);
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
            using var writer = new StreamWriter(filePath);
            writer.WriteLine("Form,Expected,Actual,Result,Code,Message");

            foreach (var r in summary.Results)
            {
                var actual = r.ActualSelected >= 0
                    ? SelectedNames.GetValueOrDefault(r.ActualSelected, r.ActualSelected.ToString())
                    : "Not On Policy";
                writer.WriteLine($"{Esc(r.FormName)},{Esc(r.ExpectedStatus)},{Esc(actual)},{r.Result},{r.ResultCode},{Esc(r.Message)}");
            }

            var summaryLine = $"Total: {summary.TotalForms} | " +
                              $"PASS: {summary.Passed} | FAIL: {summary.Failed} | " +
                              $"INFO: {summary.Info} | ISSUE: {summary.Issues}";
            writer.WriteLine($"{Esc(summaryLine)},,,,,");

            Console.WriteLine($"Results CSV saved: {filePath}");
            return filePath;
        }

        // ───────────────────────── Output: Console summary ───────────────────────

        /// <summary>
        /// Prints a clean, grouped summary to the console.
        /// </summary>
        public static void PrintSummary(FormsValidationSummary summary)
        {
            Console.WriteLine();
            Console.WriteLine($"╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine($"║  FORMS VALIDATION: {summary.LOB} / {summary.State} / Quote {summary.QuoteId,-15}  ║");
            Console.WriteLine($"╠══════════════════════════════════════════════════════════════╣");
            Console.WriteLine($"║  Total: {summary.TotalForms,-5}  PASS: {summary.Passed,-5}  FAIL: {summary.Failed,-5}  INFO: {summary.Info,-5}  ║");
            Console.WriteLine($"╚══════════════════════════════════════════════════════════════╝");

            // Group by result for clean output
            var failures = summary.Results.Where(r => r.Result == "FAIL").ToList();
            var issues = summary.Results.Where(r => r.Result == "ISSUE").ToList();
            var infos = summary.Results.Where(r => r.Result == "INFO").ToList();

            if (failures.Count > 0)
            {
                Console.WriteLine($"\n  FAILURES ({failures.Count}):");
                foreach (var f in failures)
                    Console.WriteLine($"    [FAIL] {f.FormName} — {f.Message}");
            }

            if (issues.Count > 0)
            {
                Console.WriteLine($"\n  ISSUES ({issues.Count}):");
                foreach (var i in issues)
                    Console.WriteLine($"    [ISSUE] {i.FormName} — {i.Message}");
            }

            if (infos.Count > 0)
            {
                Console.WriteLine($"\n  INFO ({infos.Count}):");
                foreach (var i in infos)
                    Console.WriteLine($"    [INFO] {i.FormName} — {i.Message}");
            }

            if (summary.AllPassed)
                Console.WriteLine("\n  All forms validated successfully.");

            Console.WriteLine();
        }

        // ───────────────────────── Company filtering ─────────────────────────────

        private List<ActualFormEntry> ApplyCompanyFilters(List<ActualFormEntry> actual, string state)
        {
            if (_config.CompanyFilters == null || _config.CompanyFilters.Count == 0)
                return actual;

            var rule = _config.CompanyFilters.FirstOrDefault(
                r => r.State.Equals(state, StringComparison.OrdinalIgnoreCase));
            if (rule?.ExcludePrefixes == null || rule.ExcludePrefixes.Count == 0)
                return actual;

            var before = actual.Count;
            var filtered = actual.Where(a =>
                !rule.ExcludePrefixes.Any(prefix =>
                    a.Name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))).ToList();

            var removed = before - filtered.Count;
            if (removed > 0)
                Console.WriteLine($"  Company filter: Removed {removed} form(s) for state {state} ({rule.Reason})");

            return filtered;
        }

        private static string Esc(string value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            if (value.Contains(',') || value.Contains('"') || value.Contains('\n'))
                return $"\"{value.Replace("\"", "\"\"")}\"";
            return value;
        }
    }
}
