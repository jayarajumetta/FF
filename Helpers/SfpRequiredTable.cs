using System;
using System.Collections.Generic;
using System.Linq;
using Reqnroll;

namespace PnCTestAutomation.Helpers
{
    internal static class SfpRequiredTable
    {
        public static IReadOnlyDictionary<string, string> Read(Table table, params string[] fields)
        {
            if (!table.Header.SequenceEqual(new[] { "Question", "Answer" }))
                throw new ArgumentException("Expected exactly the Question and Answer table columns.");

            var expected = new HashSet<string>(fields, StringComparer.Ordinal);
            var values = new Dictionary<string, string>(StringComparer.Ordinal);
            foreach (var row in table.Rows)
            {
                var question = row["Question"].Trim();
                var answer = row["Answer"].Trim();
                if (!expected.Contains(question))
                    throw new ArgumentException($"Unsupported SFP table field '{question}'.");
                if (string.IsNullOrWhiteSpace(answer))
                    throw new ArgumentException($"SFP table field '{question}' requires a value.");
                if (!values.TryAdd(question, answer))
                    throw new ArgumentException($"Duplicate SFP table field '{question}'.");
            }

            var missing = expected.Except(values.Keys).ToArray();
            if (missing.Length != 0)
                throw new ArgumentException($"Missing SFP table fields: {string.Join(", ", missing)}.");
            return values;
        }

        public static bool YesNo(string value) => value switch
        {
            "Yes" => true,
            "No" => false,
            _ => throw new ArgumentException($"Expected Yes or No, received '{value}'.")
        };

        public static void RequireValue(string field, string actual, params string[] supported)
        {
            if (!supported.Contains(actual, StringComparer.Ordinal))
                throw new ArgumentException(
                    $"Unsupported {field} '{actual}'. Expected: {string.Join(", ", supported)}.");
        }
    }
}
