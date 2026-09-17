#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PnCTestAutomation.TestPlans
{
    public static class ScenarioAutomationIdentity
    {
        private const string TagPrefix = "AutomationId-";
        private static readonly Regex StableIdPattern = new(
            @"^[A-Z][A-Z0-9]*(?:-[A-Z0-9]+)*$",
            RegexOptions.CultureInvariant);

        public static string? Resolve(
            IEnumerable<string> scenarioTags,
            IEnumerable<string> featureTags,
            string? qualifier)
        {
            ArgumentNullException.ThrowIfNull(scenarioTags);
            ArgumentNullException.ThrowIfNull(featureTags);

            var identifiers = scenarioTags
                .Concat(featureTags)
                .Where(tag => tag.StartsWith(
                    TagPrefix,
                    StringComparison.OrdinalIgnoreCase))
                .Select(tag => tag[TagPrefix.Length..].Trim().ToUpperInvariant())
                .Distinct(StringComparer.Ordinal)
                .ToList();
            if (identifiers.Count == 0)
                return null;
            if (identifiers.Count != 1)
            {
                throw new InvalidOperationException(
                    "A publishable scenario must declare exactly one AutomationId tag.");
            }
            if (!StableIdPattern.IsMatch(identifiers[0]))
            {
                throw new InvalidOperationException(
                    $"Automation ID '{identifiers[0]}' is invalid.");
            }

            var normalizedQualifier = qualifier?.Trim().ToUpperInvariant();
            if (string.IsNullOrWhiteSpace(normalizedQualifier) ||
                !StableIdPattern.IsMatch(normalizedQualifier))
            {
                throw new InvalidOperationException(
                    "A publishable scenario requires a stable execution qualifier.");
            }

            return $"{identifiers[0]}:{normalizedQualifier}";
        }
    }
}
