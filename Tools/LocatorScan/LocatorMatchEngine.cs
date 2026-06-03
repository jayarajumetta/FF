// Tools/LocatorScan/LocatorMatchEngine.cs
#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PnCTestAutomation.Tools.LocatorScan
{
    /// <summary>
    /// Compares freshly scanned locator candidates against the repo inventory
    /// to flag exact matches and advise reuse.
    /// SIMPLIFIED: Removed near-match detection for performance.
    /// </summary>
    public sealed class LocatorMatchEngine
    {
        // ── Public API ──

        /// <summary>
        /// Annotate each <see cref="ElementReport"/> with existing repo matches.
        /// Only performs exact matching for performance.
        /// </summary>
        public Task AnnotateWithRepoMatchesAsync(
            List<ElementReport> reports,
            List<ExistingLocator> inventory)
        {
            if (reports is null || inventory is null || inventory.Count == 0)
                return Task.CompletedTask;

            // Build a lookup by canonical key for fast exact matching
            var exactLookup = new Dictionary<string, List<ExistingLocator>>(StringComparer.OrdinalIgnoreCase);
            foreach (var loc in inventory)
            {
                if (!exactLookup.TryGetValue(loc.CanonicalKey, out var list))
                {
                    list = new List<ExistingLocator>();
                    exactLookup[loc.CanonicalKey] = list;
                }
                list.Add(loc);
            }

            foreach (var report in reports)
            {
                report.ExistingMatches ??= new List<ExistingMatch>();

                foreach (var candidate in report.Candidates)
                {
                    var key = CandidateToCanonicalKey(candidate);
                    if (string.IsNullOrEmpty(key))
                        continue;

                    // Exact match only
                    if (exactLookup.TryGetValue(key, out var exactMatches))
                    {
                        foreach (var em in exactMatches)
                        {
                            if (!report.ExistingMatches.Any(m =>
                                m.MatchType == "Exact" &&
                                m.ExistingFile == em.FilePath &&
                                m.ExistingMember == em.MemberName))
                            {
                                report.ExistingMatches.Add(new ExistingMatch
                                {
                                    MatchType = "Exact",
                                    Strategy = em.Strategy,
                                    CanonicalKey = em.CanonicalKey,
                                    ExistingFile = em.FilePath,
                                    ExistingClass = em.ClassName,
                                    ExistingMember = em.MemberName,
                                    ExistingCode = em.CodeSnippet
                                });
                            }
                        }
                    }
                }
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Returns only elements that have NO exact match in the repo (new work only).
        /// </summary>
        public List<ElementReport> OnlyWithoutExactMatch(List<ElementReport> reports)
        {
            return reports
                .Where(r => !r.ExistingMatches.Any(m => m.MatchType == "Exact"))
                .ToList();
        }

        // ── Helpers ──

        /// <summary>
        /// Convert a scanned candidate to a canonical key using the same scheme as RepoLocatorInventory.
        /// </summary>
        private static string CandidateToCanonicalKey(LocatorCandidate candidate)
        {
            if (candidate is null) return string.Empty;

            var code = candidate.CodeSnippet ?? string.Empty;
            switch (candidate.Strategy)
            {
                case "GetByTestId":
                    {
                        var val = ExtractFirstQuoted(code);
                        return val is not null
                            ? RepoLocatorInventory.ToCanonicalKey("GetByTestId", null, val)
                            : string.Empty;
                    }
                case "GetByRole":
                    {
                        var roleMatch = Regex.Match(code, @"AriaRole\.(\w+)");
                        var nameMatch = Regex.Match(code, @"Name\s*=\s*""([^""]+)""");
                        if (roleMatch.Success)
                        {
                            var role = roleMatch.Groups[1].Value;
                            var name = nameMatch.Success ? nameMatch.Groups[1].Value : null;
                            return RepoLocatorInventory.ToCanonicalKey("GetByRole", role, name);
                        }
                        return string.Empty;
                    }
                case "GetByLabel":
                    {
                        var val = ExtractFirstQuoted(code);
                        return val is not null
                            ? RepoLocatorInventory.ToCanonicalKey("GetByLabel", null, val)
                            : string.Empty;
                    }
                case "GetByPlaceholder":
                    {
                        var val = ExtractFirstQuoted(code);
                        return val is not null
                            ? RepoLocatorInventory.ToCanonicalKey("GetByPlaceholder", null, val)
                            : string.Empty;
                    }
                case "GetByText":
                    {
                        var val = ExtractFirstQuoted(code);
                        return val is not null
                            ? RepoLocatorInventory.ToCanonicalKey("GetByText", null, val)
                            : string.Empty;
                    }
                case "CssId":
                    {
                        var val = ExtractFirstQuoted(code);
                        if (val is not null && val.StartsWith('#'))
                            val = val.Substring(1);
                        return val is not null
                            ? RepoLocatorInventory.ToCanonicalKey("CssId", null, null, val)
                            : string.Empty;
                    }
                default:
                    return string.Empty;
            }
        }

        private static string? ExtractFirstQuoted(string code)
        {
            var m = Regex.Match(code, "\"([^\"]+)\"");
            return m.Success ? m.Groups[1].Value : null;
        }
    }
}
