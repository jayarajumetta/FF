using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using PnCTestAutomation.Models;

namespace PnCTestAutomation.Services
{
    /// <summary>
    /// Enhanced forms validation engine — replaces the legacy Tosca PowerShell FormsCheck workflow.
    ///
    /// Key improvements over original:
    ///   - Merged single-file-per-LOB baselines (Type column: BASE=shared, B=BASIC-only, C=CE-only)
    ///   - Human-readable validation messages (no more cryptic C-codes as primary output)
    ///   - HTML report generation via FormsReportGenerator
    ///   - Record mode: capture actual API response as a proposed baseline update
    ///   - Legacy C1–C15 codes preserved as reference field for backward compatibility
    /// </summary>
    public class FormsValidationService
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
        /// SFP uses SFP.json exclusively, including when stale CSVs remain in build output.
        /// Other LOBs retain their file resolution order:
        ///   1. Test-case CSV: {LOB}_{testCase}.csv  → load all rows (e.g. SFP_BASIC.csv — Tosca baseline)
        ///   2. Merged CSV:    {LOB}.csv  → filter by Type column (BASE + testCase code)
        ///   3. Include-only JSON: {LOB}.json
        ///   4. Per-state JSON: {LOB}_{state}.json
        /// </summary>
        public List<ExpectedFormEntry> LoadExpectedFormsForLob(string lob, string state, string testCase = "BASIC")
        {
            // Reject any value that contains path separators or other traversal characters
            if (!Regex.IsMatch(lob ?? "", @"^[A-Za-z0-9_]{1,20}$"))
                throw new ArgumentException($"Invalid LOB value: '{lob}'");
            if (!Regex.IsMatch(state ?? "", @"^[A-Za-z]{2,3}$"))
                throw new ArgumentException($"Invalid state value: '{state}'");
            if (!Regex.IsMatch(testCase ?? "BASIC", @"^[A-Za-z0-9_]{1,20}$"))
                throw new ArgumentException($"Invalid testCase value: '{testCase}'");

            var basePath = Path.Combine(AppContext.BaseDirectory, "Resources", "ExpectedForms", lob);

            if (lob.Equals("SFP", StringComparison.OrdinalIgnoreCase))
                return LoadFromSfpJson(Path.Combine(basePath, "SFP.json"), state, testCase);

            // 1. Test-case-specific CSV: {LOB}_{testCase}.csv (e.g. SFP_BASIC.csv) — highest priority,
            //    matches the Tosca baseline exactly.
            var legacyCsv = Path.Combine(basePath, $"{lob}_{testCase}.csv");
            if (File.Exists(legacyCsv))
            {
                Console.WriteLine($"Loading test-case baseline: {lob}_{testCase}.csv for state {state}");
                return LoadFromCsv(legacyCsv, state);
            }

            // 2. Merged CSV: one file per LOB, filtered by Type column
            var mergedCsv = Path.Combine(basePath, $"{lob}.csv");
            if (File.Exists(mergedCsv))
            {
                var typeCode = GetTypeCodeForTestCase(testCase);
                Console.WriteLine($"Loading merged baseline: {lob}.csv (types: BASE + {typeCode}) for state {state}");
                return LoadFromCsv(mergedCsv, state, typeFilter: new[] { "BASE", typeCode });
            }

            // 3. Include-only JSON: {LOB}.json
            var includeOnlyJson = Path.Combine(basePath, $"{lob}.json");
            if (File.Exists(includeOnlyJson))
            {
                Console.WriteLine($"Loading include-only JSON: {lob}.json for state {state}, testCase {testCase}");
                return LoadFromIncludeOnlyJson(includeOnlyJson, state, testCase);
            }

            // 4. Per-state JSON (backward compat)
            var jsonPath = Path.Combine(basePath, $"{lob}_{state}.json");
            if (File.Exists(jsonPath))
                return LoadFromJson(jsonPath);

            throw new FileNotFoundException(
                $"No baseline found for {lob}/{state} (testCase={testCase}). " +
                $"Place {lob}.json (include-only) or {lob}.csv (merged) in Resources/ExpectedForms/{lob}/");
        }

        public List<ExpectedFormEntry> LoadExpectedFormsTemplateForRecording(
            string lob,
            string testCase = "BASIC")
        {
            if (!Regex.IsMatch(lob ?? "", @"^[A-Za-z0-9_]{1,20}$"))
                throw new ArgumentException($"Invalid LOB value: '{lob}'");
            if (!Regex.IsMatch(testCase ?? "BASIC", @"^[A-Za-z0-9_]{1,20}$"))
                throw new ArgumentException($"Invalid testCase value: '{testCase}'");

            var basePath = Path.Combine(AppContext.BaseDirectory, "Resources", "ExpectedForms", lob);
            if (lob.Equals("SFP", StringComparison.OrdinalIgnoreCase))
                return LoadFromSfpJson(Path.Combine(basePath, "SFP.json"), null, testCase);

            var testCaseCsv = Path.Combine(basePath, $"{lob}_{testCase}.csv");
            if (File.Exists(testCaseCsv))
                return LoadFirstCsvState(testCaseCsv);

            var mergedCsv = Path.Combine(basePath, $"{lob}.csv");
            if (File.Exists(mergedCsv))
                return LoadFirstCsvState(
                    mergedCsv,
                    new[] { "BASE", GetTypeCodeForTestCase(testCase) });

            throw new FileNotFoundException(
                $"CSV baseline template not found for {lob}/{testCase}. " +
                "Record mode requires a CSV whose form/type structure can seed the proposal.");
        }

        private List<ExpectedFormEntry> LoadFirstCsvState(string csvPath, string[] typeFilter = null)
        {
            var resolvedCsv = SafeResolvePath(csvPath);
            var header = File.ReadLines(resolvedCsv).FirstOrDefault()
                ?? throw new InvalidOperationException($"CSV baseline is empty: {resolvedCsv}");
            var state = header.Split(',')
                .Select(column => column.Trim())
                .FirstOrDefault(column => Regex.IsMatch(column, @"^[A-Z]{2,3}$"));

            if (state == null)
                throw new InvalidOperationException(
                    $"CSV baseline has no state columns to seed record mode: {resolvedCsv}");

            return LoadFromCsv(resolvedCsv, state, typeFilter);
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
                    Console.WriteLine($"  WARNING: Duplicate form '{formName}' — keeping first occurrence");
                    continue;
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
        /// SFP keeps the BASE/BASIC/CE JSON layout. STATES declares approved scenario coverage;
        /// a declared form omitted from a state's include list is explicitly N, not informational.
        /// A null state selects the first approved state only for a recording template.
        /// </summary>
        public List<ExpectedFormEntry> LoadFromSfpJson(string jsonPath, string state, string testCase = "BASIC")
        {
            return ParseSfpJson(File.ReadAllText(SafeResolvePath(jsonPath)), state, testCase);
        }

        public List<ExpectedFormEntry> ParseSfpJson(string json, string state, string testCase = "BASIC")
        {
            using var document = JsonDocument.Parse(json,
                new JsonDocumentOptions { CommentHandling = JsonCommentHandling.Skip });
            var root = document.RootElement;
            var variant = (testCase ?? "BASIC").ToUpperInvariant();
            if (root.ValueKind != JsonValueKind.Object ||
                !root.TryGetProperty("STATES", out var stateMap) || stateMap.ValueKind != JsonValueKind.Object)
                throw new InvalidOperationException("SFP.json requires a STATES object declaring approved scenario states.");

            RequireUniqueProperties(root, "SFP.json");
            RequireUniqueProperties(stateMap, "STATES");
            var approved = new Dictionary<string, HashSet<string>>(StringComparer.Ordinal);
            foreach (var scenario in stateMap.EnumerateObject())
            {
                if (scenario.Name is not ("BASIC" or "CE") || scenario.Value.ValueKind != JsonValueKind.Array)
                    throw new InvalidOperationException($"Invalid SFP scenario state declaration: {scenario.Name}.");
                var states = new HashSet<string>(StringComparer.Ordinal);
                foreach (var item in scenario.Value.EnumerateArray())
                {
                    if (item.ValueKind != JsonValueKind.String ||
                        !Regex.IsMatch(item.GetString() ?? "", "^[A-Z]{2}$") || !states.Add(item.GetString()))
                        throw new InvalidOperationException($"Invalid or duplicate state in STATES.{scenario.Name}.");
                }
                if (states.Count == 0)
                    throw new InvalidOperationException($"STATES.{scenario.Name} cannot be empty.");
                approved.Add(scenario.Name, states);
            }
            if (!approved.TryGetValue(variant, out var supported))
                throw new InvalidOperationException($"SFP scenario '{variant}' has no approved JSON baseline.");
            state = state?.ToUpperInvariant() ?? supported.First();
            if (!supported.Contains(state))
                throw new InvalidOperationException($"State '{state}' is not approved in SFP.json for {variant}.");

            var knownStates = approved.Values.SelectMany(states => states).ToHashSet(StringComparer.Ordinal);
            var result = new List<ExpectedFormEntry>();
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var sectionName in new[] { "BASE", variant })
            {
                if (!root.TryGetProperty(sectionName, out var section) || section.ValueKind != JsonValueKind.Object)
                    throw new InvalidOperationException($"SFP.json requires a {sectionName} forms object.");
                RequireUniqueProperties(section, sectionName);
                foreach (var form in section.EnumerateObject())
                {
                    if (!Regex.IsMatch(form.Name, "^[A-Z0-9]+$") || !seen.Add(form.Name))
                        throw new InvalidOperationException($"Invalid or duplicate SFP form: {form.Name}.");
                    var value = form.Value;
                    if (value.ValueKind == JsonValueKind.String)
                    {
                        if (value.GetString() != "all")
                            throw new InvalidOperationException($"Invalid include value for {form.Name}; use \"all\", a state array or a status map.");
                    }
                    else if (value.ValueKind == JsonValueKind.Array)
                    {
                        var listed = new HashSet<string>(StringComparer.Ordinal);
                        foreach (var item in value.EnumerateArray())
                            if (item.ValueKind != JsonValueKind.String ||
                                !knownStates.Contains(item.GetString()) || !listed.Add(item.GetString()))
                                throw new InvalidOperationException($"Invalid or duplicate state for {form.Name}.");
                    }
                    else if (value.ValueKind == JsonValueKind.Object)
                    {
                        RequireUniqueProperties(value, form.Name);
                        foreach (var status in value.EnumerateObject())
                            if (!knownStates.Contains(status.Name) || status.Value.ValueKind != JsonValueKind.String ||
                                status.Value.GetString() is not ("YM" or "YS" or "YU" or "N"))
                                throw new InvalidOperationException($"Invalid state/status for {form.Name}/{status.Name}.");
                    }
                    else
                        throw new InvalidOperationException($"Invalid SFP form definition: {form.Name}.");

                    result.Add(new ExpectedFormEntry
                    {
                        FormName = form.Name,
                        ExpectedStatus = ResolveStatusFromJsonElement(value, state) ?? "N",
                        Type = sectionName == "BASE" ? "BASE" : GetTypeCodeForTestCase(variant)
                    });
                }
            }
            if (result.Count == 0)
                throw new InvalidOperationException($"SFP.json contains no forms for {variant}.");
            Console.WriteLine($"Loading SFP.json for {variant}/{state}: {result.Count} explicit expectations.");
            return result;
        }

        private static void RequireUniqueProperties(JsonElement element, string location)
        {
            var names = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var property in element.EnumerateObject())
                if (!names.Add(property.Name))
                    throw new InvalidOperationException($"Duplicate property '{property.Name}' in {location}.");
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
                    Result = "INFO",
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
        public string SaveResultsCsv(FormsValidationSummary summary, string testCaseName)
        {
            // Sanitize at the sink: testCaseName and the summary fields used in the file
            // name all originate from external data (CSV ReadLine / Gherkin arguments).
            // Path traversal mitigation (CWE-22): strip traversal sequences, apply an
            // allowlist, then verify the final path stays inside the intended directory.
            var safeTestCase  = SanitizeFileNameSegment(testCaseName);
            var safeLob       = SanitizeFileNameSegment(summary.LOB);
            var safeState     = SanitizeFileNameSegment(summary.State);
            var safeQuoteId   = SanitizeFileNameSegment(summary.QuoteId);

            var baseDir  = Path.GetFullPath(Path.Combine(_config.ResultsBasePath, safeLob));
            Directory.CreateDirectory(baseDir);

            var safeFile = Path.GetFileName($"{safeTestCase}_{safeState}_{safeQuoteId}Results.csv");
            var filePath = Path.GetFullPath(Path.Combine(baseDir, safeFile));

            // Containment check: reject any path that escapes the intended output directory.
            if (!filePath.StartsWith(baseDir + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("Path traversal detected: CSV path escapes the intended output directory.");

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

        /// <summary>
        /// Sanitizes a single file name segment against path traversal (CWE-22).
        /// Strips OS-invalid characters, neutralizes traversal sequences, then
        /// applies an allowlist so only letters, digits, underscores, and dashes remain.
        /// </summary>
        private static string SanitizeFileNameSegment(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "_";

            // Neutralize traversal sequences before character-level checks
            var value = input.Replace("..", "_");

            // Strip OS-invalid file name characters
            foreach (var c in Path.GetInvalidFileNameChars())
                value = value.Replace(c, '_');

            // Allowlist: permit only letters, digits, underscore, and dash
            value = Regex.Replace(value, @"[^a-zA-Z0-9_\-]", "_");

            return value;
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

        // ───────────────────────── Record mode: baseline capture ──────────────────

        /// <summary>
        /// Captures the actual API response as a proposed baseline update.
        /// Saves to a _PROPOSED.csv file alongside the existing baseline.
        /// The user reviews the diff and replaces the baseline manually.
        /// </summary>
        public string SaveProposedBaseline(
            List<ActualFormEntry> actualForms,
            List<ExpectedFormEntry> currentBaseline,
            string lob,
            string state,
            string testCase = "BASIC")
        {
            if (lob.Equals("SFP", StringComparison.OrdinalIgnoreCase))
                return SaveSfpJsonProposal(actualForms, currentBaseline, state, testCase);

            var basePath = Path.Combine(AppContext.BaseDirectory, "Resources", "ExpectedForms", lob);
            Directory.CreateDirectory(basePath);
            var suffix = string.IsNullOrWhiteSpace(testCase) ? "" : $"_{testCase.ToUpperInvariant()}";
            var proposedPath = Path.Combine(basePath, $"{lob}{suffix}_PROPOSED.csv");

            // If the proposed file already exists, read it and merge the new state column.
            // Otherwise, start from the current baseline structure.
            var allForms = new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);
            var allTypes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            var states = new List<string>();

            // Read existing proposed file if it exists (accumulates across multiple state runs)
            if (File.Exists(proposedPath))
            {
                using var reader = new StreamReader(proposedPath);
                var header = reader.ReadLine();
                if (header != null)
                {
                    var cols = header.Split(',');
                    var pFormIdx = Array.FindIndex(cols, c => c.Trim().Equals("Form", StringComparison.OrdinalIgnoreCase));
                    var pTypeIdx = Array.FindIndex(cols, c => c.Trim().Equals("Type", StringComparison.OrdinalIgnoreCase));
                    if (pFormIdx < 0) pFormIdx = 1;

                    for (int i = 0; i < cols.Length; i++)
                    {
                        var col = cols[i].Trim();
                        if (i != pFormIdx && i != pTypeIdx && col.Length == 2)
                            states.Add(col);
                    }

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        var parts = line.Split(',');
                        var formName = pFormIdx < parts.Length ? parts[pFormIdx].Trim() : "";
                        if (string.IsNullOrEmpty(formName)) continue;

                        var type = pTypeIdx >= 0 && pTypeIdx < parts.Length ? parts[pTypeIdx].Trim() : "BASE";
                        allTypes[formName] = type;

                        var stateVals = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                        for (int i = 0; i < states.Count; i++)
                        {
                            var colIdx = Array.FindIndex(cols, c => c.Trim().Equals(states[i], StringComparison.OrdinalIgnoreCase));
                            if (colIdx >= 0 && colIdx < parts.Length)
                                stateVals[states[i]] = parts[colIdx].Trim();
                        }
                        allForms[formName] = stateVals;
                    }
                }
            }
            else
            {
                // Seed from current baseline
                foreach (var entry in currentBaseline)
                {
                    allForms[entry.FormName] = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    allTypes[entry.FormName] = string.IsNullOrEmpty(entry.Type) ? "BASE" : entry.Type;
                }
            }

            if (!states.Contains(state, StringComparer.OrdinalIgnoreCase))
                states.Add(state);

            // Map actual forms for this state
            var actualLookup = actualForms.ToDictionary(a => a.Name, a => a);

            // Update state column based on actual API response
            foreach (var formName in allForms.Keys.ToList())
            {
                if (actualLookup.TryGetValue(formName, out var actual))
                {
                    allForms[formName][state] = actual.Selected switch
                    {
                        2 => "YM",
                        1 => "YS",
                        0 => "YU",
                        _ => "YU"
                    };
                }
                else
                {
                    allForms[formName][state] = "N";
                }
            }

            // Add forms found on policy but not in baseline
            foreach (var actual in actualForms.Where(a => !allForms.ContainsKey(a.Name)))
            {
                allForms[actual.Name] = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                {
                    [state] = actual.Selected switch { 2 => "YM", 1 => "YS", _ => "YU" }
                };
                allTypes[actual.Name] = "BASE";
            }

            // Write proposed file
            states.Sort(StringComparer.OrdinalIgnoreCase);
            using (var writer = new StreamWriter(proposedPath))
            {
                writer.WriteLine("Type,Form," + string.Join(",", states));
                foreach (var (formName, stateVals) in allForms.OrderBy(kv => kv.Key))
                {
                    var type = allTypes.GetValueOrDefault(formName, "BASE");
                    var values = states.Select(s => stateVals.GetValueOrDefault(s, "")).ToArray();
                    writer.WriteLine($"{type},{formName},{string.Join(",", values)}");
                }
            }

            Console.WriteLine($"\n  PROPOSED BASELINE saved: {proposedPath}");
            Console.WriteLine($"  Review the file, then merge into {lob}.json (or rename to {lob}.csv) to activate.");
            return proposedPath;
        }

        private string SaveSfpJsonProposal(
            List<ActualFormEntry> actualForms, List<ExpectedFormEntry> template, string state, string testCase)
        {
            var variant = (testCase ?? "BASIC").ToUpperInvariant();
            state = state?.ToUpperInvariant();
            if (variant is not ("BASIC" or "CE") || !Regex.IsMatch(state ?? "", "^[A-Z]{2}$"))
                throw new ArgumentException("SFP proposals require BASIC/CE and a two-letter state.");
            if (actualForms.Any(form => !Regex.IsMatch(form.Name ?? "", "^[A-Z0-9]+$") ||
                form.Selected is < 0 or > 2) ||
                actualForms.Select(form => form.Name).Distinct(StringComparer.OrdinalIgnoreCase).Count() != actualForms.Count)
                throw new InvalidOperationException("SFP recording contains invalid or duplicate actual forms.");

            var path = Path.Combine(AppContext.BaseDirectory, "Resources", "ExpectedForms", "SFP",
                $"SFP_{variant}_PROPOSED.json");
            JsonObject proposal;
            if (File.Exists(path))
            {
                LoadFromSfpJson(path, null, variant);
                proposal = JsonNode.Parse(File.ReadAllText(path), documentOptions:
                    new JsonDocumentOptions { CommentHandling = JsonCommentHandling.Skip }).AsObject();
            }
            else
            {
                proposal = new JsonObject
                {
                    ["STATES"] = new JsonObject { [variant] = new JsonArray() },
                    ["BASE"] = new JsonObject(),
                    [variant] = new JsonObject()
                };
                foreach (var form in template)
                {
                    var section = form.Type == "BASE" ? "BASE" : variant;
                    proposal[section].AsObject().Add(form.FormName, new JsonObject());
                }
            }

            var states = proposal["STATES"][variant].AsArray();
            if (!states.Any(item => item.GetValue<string>() == state))
                states.Add(state);
            var actual = actualForms.ToDictionary(form => form.Name, StringComparer.Ordinal);
            var known = new HashSet<string>(StringComparer.Ordinal);
            foreach (var sectionName in new[] { "BASE", variant })
                foreach (var form in proposal[sectionName].AsObject())
                {
                    if (form.Value is not JsonObject statuses)
                        throw new InvalidOperationException($"Recorded proposal requires explicit statuses for {form.Key}.");
                    statuses[state] = actual.TryGetValue(form.Key, out var found)
                        ? found.Selected == 2 ? "YM" : found.Selected == 1 ? "YS" : "YU"
                        : "N";
                    known.Add(form.Key);
                }
            foreach (var form in actualForms.Where(form => !known.Contains(form.Name)))
                proposal[variant].AsObject().Add(form.Name, new JsonObject
                {
                    [state] = form.Selected == 2 ? "YM" : form.Selected == 1 ? "YS" : "YU"
                });

            File.WriteAllText(path, proposal.ToJsonString(new JsonSerializerOptions { WriteIndented = true }) + Environment.NewLine);
            Console.WriteLine($"PROPOSED JSON saved: {path}. Review state, scenario and form classification before updating SFP.json.");
            return path;
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
