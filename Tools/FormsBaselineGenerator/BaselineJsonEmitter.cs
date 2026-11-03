using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PnCTestAutomation.Tools.FormsBaselineGenerator
{
    /// <summary>
    /// Converts ParsedFormRow objects and reviewed scenario state profiles into
    /// the strict SFP JSON format consumed by FormsValidationService.ParseSfpJson().
    ///
    /// Output rules (per form, per section):
    ///   All approved states = YM  →  "all"
    ///   Some states   = YM  →  ["AL", "AR", ...]
    ///   Mixed YM/YS/YU      →  { "AL": "YM", "TX": "YS" }
    ///   All states    = N   →  form is omitted entirely
    /// </summary>
    public static class BaselineJsonEmitter
    {
        private static readonly string[] SectionOrder = { "BASE", "BASIC", "CE" };

        private static readonly Dictionary<string, string> SectionDescriptions = new()
        {
            ["BASE"] = "shared by Basic Policy and Country Estate",
            ["BASIC"] = "SFP Basic Policy only — loaded in addition to BASE",
            ["CE"] = "Country Estate only — loaded in addition to BASE",
        };

        public static void Emit(
            List<ParsedFormRow> rows,
            IReadOnlyDictionary<string, string[]> stateProfiles,
            IReadOnlyDictionary<string, string[]> pendingStateProfiles,
            string lob,
            string outputPath)
        {
            var sb = new StringBuilder();

            sb.AppendLine("{");
            AppendFileHeader(sb, lob, stateProfiles, pendingStateProfiles);
            AppendStates(sb, stateProfiles);

            // Group by canonical section name, ignore unknown sections
            var bySection = rows
                .GroupBy(r => r.Section.ToUpperInvariant())
                .ToDictionary(g => g.Key, g => g.OrderBy(r => r.FormNumber).ToList());
            var missingProfiles = bySection.Keys
                .Where(section => section is "BASIC" or "CE")
                .Where(section => !stateProfiles.ContainsKey(section))
                .OrderBy(section => section, StringComparer.Ordinal)
                .ToArray();
            if (missingProfiles.Length > 0)
            {
                throw new InvalidOperationException(
                    $"STATE_PROFILE does not declare parsed scenario section(s): {string.Join(", ", missingProfiles)}.");
            }

            var sectionsPresent = SectionOrder
                .Where(section => section == "BASE" || stateProfiles.ContainsKey(section))
                .ToList();
            var knownStates = stateProfiles.Values
                .SelectMany(states => states)
                .Distinct(StringComparer.Ordinal)
                .OrderBy(state => state, StringComparer.Ordinal)
                .ToArray();

            for (int si = 0; si < sectionsPresent.Count; si++)
            {
                var sectionName = sectionsPresent[si];
                var sectionRows = bySection.GetValueOrDefault(sectionName, new List<ParsedFormRow>());
                var isLastSection = si == sectionsPresent.Count - 1;
                var applicableStates = sectionName == "BASE"
                    ? knownStates
                    : stateProfiles[sectionName].OrderBy(state => state, StringComparer.Ordinal).ToArray();
                sectionRows = sectionRows
                    .Where(row => HasIncludedState(row.StateValues, applicableStates))
                    .ToList();

                AppendSectionHeader(sb, sectionName);
                sb.AppendLine($"  \"{sectionName}\": {{");

                // Pad form numbers to the longest in this section for alignment
                int maxLen = sectionRows.Count == 0 ? 0 : sectionRows.Max(r => r.FormNumber.Length);

                for (int ri = 0; ri < sectionRows.Count; ri++)
                {
                    var row = sectionRows[ri];
                    var isLastRow = ri == sectionRows.Count - 1;
                    var value = ComputeValue(row.StateValues, applicableStates);
                    var padding = new string(' ', maxLen - row.FormNumber.Length);
                    var comma = isLastRow ? "" : ",";

                    sb.AppendLine($"    \"{row.FormNumber}\":{padding} {value}{comma}");
                }

                sb.Append(isLastSection ? "  }" : "  },");
                sb.AppendLine();
                sb.AppendLine();
            }

            sb.AppendLine("}");

            File.WriteAllText(outputPath, sb.ToString(), new UTF8Encoding(false));

            Console.WriteLine();
            Console.WriteLine("  Section summary:");
            foreach (var s in sectionsPresent)
                Console.WriteLine($"    {s,-8} {bySection.GetValueOrDefault(s)?.Count ?? 0} forms");
            Console.WriteLine($"    Total    {rows.Count} forms");
        }

        // ── Value computation ─────────────────────────────────────────────────────

        private static string ComputeValue(
            Dictionary<string, string> stateValues,
            string[] supportedStates)
        {
            // Collect only states that have a non-N value
            var included = supportedStates
                .Where(s => stateValues.TryGetValue(s, out var v)
                            && !string.IsNullOrEmpty(v)
                            && !v.Equals("N", StringComparison.OrdinalIgnoreCase))
                .Select(s => (State: s, Status: stateValues[s].ToUpperInvariant()))
                .ToList();

            if (!included.Any())
                throw new InvalidOperationException("Cannot emit a form with no approved non-N state.");

            var allYm = included.All(x => x.Status == "YM");
            var coversAll = included.Count == supportedStates.Length;

            // All approved states, all YM → "all"
            if (coversAll && allYm)
                return "\"all\"";

            // Subset of states, all YM → compact array on one line
            if (allYm)
            {
                var states = string.Join(", ", included.Select(x => $"\"{x.State}\""));
                return $"[{states}]";
            }

            // Mixed statuses → object
            var pairs = string.Join(", ", included.Select(x => $"\"{x.State}\": \"{x.Status}\""));
            return $"{{ {pairs} }}";
        }

        private static bool HasIncludedState(
            IReadOnlyDictionary<string, string> stateValues,
            IEnumerable<string> approvedStates) =>
            approvedStates.Any(state =>
                stateValues.TryGetValue(state, out var value)
                && !string.IsNullOrEmpty(value)
                && !value.Equals("N", StringComparison.OrdinalIgnoreCase));

        // ── JSON text helpers ─────────────────────────────────────────────────────

        private static void AppendFileHeader(
            StringBuilder sb,
            string lob,
            IReadOnlyDictionary<string, string[]> stateProfiles,
            IReadOnlyDictionary<string, string[]> pendingStateProfiles)
        {
            var rule = new string('═', 77);
            var stateCount = stateProfiles.Values
                .SelectMany(states => states)
                .Distinct(StringComparer.Ordinal)
                .Count();

            sb.AppendLine($"  // {rule}");
            sb.AppendLine($"  // {lob} Expected Forms Baseline");
            sb.AppendLine($"  // Auto-generated by FormsBaselineGeneratorTool — do not hand-edit.");
            sb.AppendLine($"  // Re-run the generator when the {lob} Excel masterlist changes.");
            sb.AppendLine($"  // {rule}");
            sb.AppendLine($"  //");
            sb.AppendLine($"  // SECTIONS");
            sb.AppendLine($"  //   BASE  — forms shared by ALL {lob} test cases");
            sb.AppendLine($"  //   BASIC — forms for {lob} Basic Policy only");
            sb.AppendLine($"  //   CE    — forms for Country Estate only");
            sb.AppendLine($"  //");
            sb.AppendLine($"  // TO REGENERATE");
            sb.AppendLine($"  //   dotnet test --filter \"Category=Tools&Name~GenerateFormsBaseline\" ^");
            sb.AppendLine($"  //     -- TestRunParameters.Parameter(name=\"EXCEL\",value=\"path\\to\\{lob}_Masterlist.xlsx\")");
            sb.AppendLine($"  //");
            sb.AppendLine($"  // APPROVED PROFILE STATES ({stateCount})");
            foreach (var profile in stateProfiles.OrderBy(pair => pair.Key, StringComparer.Ordinal))
                sb.AppendLine($"  //   {profile.Key}: {string.Join("  ", profile.Value)}");
            sb.AppendLine($"  //");
            sb.AppendLine($"  // APPROVED PENDING CONFIGURATION");
            sb.AppendLine($"  //   Excluded from runtime STATES and form expectations until complete feature rows exist.");
            foreach (var profile in pendingStateProfiles.OrderBy(pair => pair.Key, StringComparer.Ordinal))
                sb.AppendLine($"  //   {profile.Key}: {string.Join("  ", profile.Value)}");
            sb.AppendLine($"  // {rule}");
            sb.AppendLine();
        }

        private static void AppendStates(
            StringBuilder sb,
            IReadOnlyDictionary<string, string[]> stateProfiles)
        {
            sb.AppendLine("  \"STATES\": {");
            var profiles = stateProfiles.OrderBy(pair => pair.Key, StringComparer.Ordinal).ToList();
            for (var index = 0; index < profiles.Count; index++)
            {
                var profile = profiles[index];
                var comma = index == profiles.Count - 1 ? "" : ",";
                var states = string.Join(
                    ", ",
                    profile.Value.OrderBy(state => state, StringComparer.Ordinal)
                        .Select(state => $"\"{state}\""));
                sb.AppendLine($"    \"{profile.Key}\": [{states}]{comma}");
            }
            sb.AppendLine("  },");
            sb.AppendLine();
        }

        private static void AppendSectionHeader(StringBuilder sb, string sectionName)
        {
            var dash = new string('─', 77);
            var desc = SectionDescriptions.GetValueOrDefault(sectionName, sectionName);
            sb.AppendLine($"  // {dash}");
            sb.AppendLine($"  // {sectionName} — {desc}");
            sb.AppendLine($"  // {dash}");
        }
    }
}
