using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Playwright_POC.Tools.FormsBaselineGenerator
{
    /// <summary>
    /// Converts a list of ParsedFormRow objects into the include-only JSON format
    /// consumed by FormsValidationService.LoadFromIncludeOnlyJson().
    ///
    /// Output rules (per form, per section):
    ///   All 23 states = YM  →  "all"
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
            string[] supportedStates,
            string lob,
            string outputPath)
        {
            var sb = new StringBuilder();

            sb.AppendLine("{");
            AppendFileHeader(sb, lob, supportedStates);

            // Group by canonical section name, ignore unknown sections
            var bySection = rows
                .GroupBy(r => r.Section.ToUpperInvariant())
                .ToDictionary(g => g.Key, g => g.OrderBy(r => r.FormNumber).ToList());

            var sectionsPresent = SectionOrder.Where(s => bySection.ContainsKey(s)).ToList();

            for (int si = 0; si < sectionsPresent.Count; si++)
            {
                var sectionName = sectionsPresent[si];
                var sectionRows = bySection[sectionName];
                var isLastSection = si == sectionsPresent.Count - 1;

                AppendSectionHeader(sb, sectionName);
                sb.AppendLine($"  \"{sectionName}\": {{");

                // Pad form numbers to the longest in this section for alignment
                int maxLen = sectionRows.Max(r => r.FormNumber.Length);

                for (int ri = 0; ri < sectionRows.Count; ri++)
                {
                    var row = sectionRows[ri];
                    var isLastRow = ri == sectionRows.Count - 1;
                    var value = ComputeValue(row.StateValues, supportedStates);
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
                Console.WriteLine($"    {s,-8} {bySection[s].Count} forms");
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
                return "\"N\"";  // shouldn't reach here (all-N rows filtered in parser)

            var allYm = included.All(x => x.Status == "YM");
            var coversAll = included.Count == supportedStates.Length;

            // All 23 states, all YM → "all"
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

        // ── JSON text helpers ─────────────────────────────────────────────────────

        private static void AppendFileHeader(StringBuilder sb, string lob, string[] states)
        {
            var rule = new string('═', 77);
            var dash = new string('─', 77);
            var stateList = string.Join("  ", states);

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
            sb.AppendLine($"  // SUPPORTED STATES ({states.Length})");
            sb.AppendLine($"  //   {stateList}");
            sb.AppendLine($"  // {rule}");
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
