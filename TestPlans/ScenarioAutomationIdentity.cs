#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using PnCTestAutomation.Products;

namespace PnCTestAutomation.TestPlans
{
    public static class ScenarioAutomationIdentity
    {
        private const string TagPrefix = "AutomationId-";
        private static readonly Regex StableIdPattern = new(
            @"^[A-Z][A-Z0-9]*(?:-[A-Z0-9]+)*$",
            RegexOptions.CultureInvariant);

        public static string? ResolveQualifier(IEnumerable<string> tags, IDictionary? arguments)
        {
            ArgumentNullException.ThrowIfNull(tags);
            if (tags.Contains("SgsImported", StringComparer.OrdinalIgnoreCase))
                return SgsCaseIdentity.GetQualifier(ReadArguments(arguments));
            if (arguments == null)
                return null;
            foreach (var key in new[] { "StateAbbv", "State" })
            {
                if (arguments.Contains(key) &&
                    arguments[key]?.ToString()?.Trim() is { Length: > 0 } value)
                    return value;
            }
            return null;
        }

        public static IReadOnlyDictionary<string, string> ReadArguments(IDictionary? arguments)
        {
            if (arguments == null)
                throw new SgsExecutionConfigurationException("SGS execution requires its original example arguments.");
            var values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (DictionaryEntry entry in arguments)
            {
                if (entry.Key is not string key || entry.Value is not string value ||
                    !values.TryAdd(key, value))
                    throw new SgsExecutionConfigurationException("SGS example arguments are missing, duplicated, or untyped.");
            }
            return values;
        }

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
