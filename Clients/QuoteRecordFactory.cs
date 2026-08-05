using PnCTestAutomation.Models;
using PnCTestAutomation.Helpers;
using System;
using System.Collections.Generic;
#nullable enable

namespace PnCTestAutomation.DataPool
{
    /// <summary>
    /// Derives a <see cref="QuoteRecord"/> from the in-memory <see cref="ScenarioContextData"/>
    /// produced by a completed test scenario.
    ///
    /// Classification rules (no hardcoding — all derived from actual test data):
    ///
    ///   Lob  (Line of Business):
    ///     Inspects FormsLob first.  If absent, falls back to:
    ///       - ProductSelection contains "BOP"  → "BOP"
    ///       - ProductSelection is "CE" / "Country Estate" → "SFP"
    ///       - ProductSelection is "SFP" / "Special Farm Package" → "SFP"
    ///       - ProductSelection is "PA"  → "PA"
    ///       - else → "Unknown"
    ///
    ///   SfpVariant (only meaningful when Lob == "SFP"):
    ///     Derived from ProductSelection stored in ScenarioContextData:
    ///       - "CE" / "Country Estate" → "CE"
    ///       - "SFP" / "Special Farm Package" / anything else → "BasicPolicy"
    ///
    ///   IsCommittedReferral:
    ///     True when Farm.PrimaryFarmType is "Committed" (case-insensitive).
    ///     Extend this heuristic as your data model evolves.
    /// </summary>
    public static class QuoteRecordFactory
    {
        public static QuoteRecord? FromScenarioContext(ScenarioContextData ctx, string? environment = null)
        {
            if (ctx is null) return null;

            var quoteId = ctx.QuoteNumber;
            if (string.IsNullOrWhiteSpace(quoteId)) return null;

            var lob        = DeriveLineOfBusiness(ctx);
            var sfpVariant = lob == "SFP" ? DeriveSfpVariant(ctx) : null;
            var type       = DeriveRecordType(ctx);

            return new QuoteRecord
            {
                Id                 = quoteId,
                Transaction        = type,
                Status             = "available",
                Lob                = lob,
                SfpVariant         = sfpVariant,
                State              = NormalizeState(ctx.RatingState ?? ctx.State),
                IsCommittedReferral = IsCommittedReferral(ctx),
                Notes              = BuildNotes(ctx, lob, sfpVariant),
                CreatedAt          = DateTime.UtcNow,
                EffectiveDate      = ctx.Policy?.EffectiveDate,
                Environment        = environment,
            };
        }

        // ── Classification helpers ────────────────────────────────────────────

        private static string DeriveLineOfBusiness(ScenarioContextData ctx)
        {
            // FormsLob is set explicitly in forms-validation scenarios — highest priority.
            if (!string.IsNullOrWhiteSpace(ctx.FormsLob))
                return NormalizeLob(ctx.FormsLob);

            var ps = (ctx.ProductSelection ?? string.Empty).Trim();

            if (ContainsIgnoreCase(ps, "BOP")) return "BOP";
            if (ContainsIgnoreCase(ps, "PA"))  return "PA";

            // SFP family
            if (ContainsIgnoreCase(ps, "CE")
                || ContainsIgnoreCase(ps, "Country Estate")
                || ContainsIgnoreCase(ps, "SFP")
                || ContainsIgnoreCase(ps, "Special Farm Package"))
                return "SFP";

            // Final fallback: non-null farm data means SFP
            if (!string.IsNullOrWhiteSpace(ctx.Farm?.PrimaryFarmType))
                return "SFP";

            return "Unknown";
        }

        private static string DeriveSfpVariant(ScenarioContextData ctx)
        {
            var ps = (ctx.ProductSelection ?? string.Empty).Trim();

            if (ps.Equals("CE", StringComparison.OrdinalIgnoreCase)
                || ContainsIgnoreCase(ps, "Country Estate"))
                return "CE";

            return "BasicPolicy";
        }

        private static string DeriveRecordType(ScenarioContextData ctx)
        {
            // If the quote was finalised to a policy a policy number is typically
            // different from the quote number (or the page title changes).
            // For now we inspect whether the quote number matches a "policy issued" pattern.
            // Extend this as the app exposes a richer signal.
            var qn = ctx.QuoteNumber ?? string.Empty;
            return qn.StartsWith("P", StringComparison.OrdinalIgnoreCase) ? "Policy" : "Quote";
        }

        private static bool IsCommittedReferral(ScenarioContextData ctx)
        {
            // Committed referrals have a specific PrimaryFarmType value in the UI.
            var farmType = ctx.Farm?.PrimaryFarmType ?? string.Empty;
            return ContainsIgnoreCase(farmType, "Committed");
        }

        private static string BuildNotes(ScenarioContextData ctx, string lob, string? sfpVariant)
        {
            var parts = new List<string> { $"LOB={lob}" };
            if (sfpVariant != null)          parts.Add($"Variant={sfpVariant}");
            if (!string.IsNullOrWhiteSpace(ctx.Farm?.PrimaryFarmType))
                parts.Add($"FarmType={ctx.Farm.PrimaryFarmType}");
            if (!string.IsNullOrWhiteSpace(ctx.Policy?.EffectiveDate))
                parts.Add($"Effective={ctx.Policy.EffectiveDate}");
            return string.Join(", ", parts);
        }

        private static string NormalizeLob(string raw)
        {
            raw = raw.Trim().ToUpperInvariant();
            return raw switch
            {
                "SFP" or "SPECIAL FARM PACKAGE" => "SFP",
                "BOP" or "BUSINESSOWNERS"        => "BOP",
                "PA"  or "PERSONAL AUTO"         => "PA",
                _                               => raw
            };
        }

        private static bool ContainsIgnoreCase(string source, string value)
            => source.Contains(value, StringComparison.OrdinalIgnoreCase);

        private static readonly Dictionary<string, string> _stateAbbreviations = new(StringComparer.OrdinalIgnoreCase)
        {
            ["Alabama"] = "AL", ["Alaska"] = "AK", ["Arizona"] = "AZ", ["Arkansas"] = "AR",
            ["California"] = "CA", ["Colorado"] = "CO", ["Connecticut"] = "CT", ["Delaware"] = "DE",
            ["Florida"] = "FL", ["Georgia"] = "GA", ["Hawaii"] = "HI", ["Idaho"] = "ID",
            ["Illinois"] = "IL", ["Indiana"] = "IN", ["Iowa"] = "IA", ["Kansas"] = "KS",
            ["Kentucky"] = "KY", ["Louisiana"] = "LA", ["Maine"] = "ME", ["Maryland"] = "MD",
            ["Massachusetts"] = "MA", ["Michigan"] = "MI", ["Minnesota"] = "MN", ["Mississippi"] = "MS",
            ["Missouri"] = "MO", ["Montana"] = "MT", ["Nebraska"] = "NE", ["Nevada"] = "NV",
            ["New Hampshire"] = "NH", ["New Jersey"] = "NJ", ["New Mexico"] = "NM", ["New York"] = "NY",
            ["North Carolina"] = "NC", ["North Dakota"] = "ND", ["Ohio"] = "OH", ["Oklahoma"] = "OK",
            ["Oregon"] = "OR", ["Pennsylvania"] = "PA", ["Rhode Island"] = "RI", ["South Carolina"] = "SC",
            ["South Dakota"] = "SD", ["Tennessee"] = "TN", ["Texas"] = "TX", ["Utah"] = "UT",
            ["Vermont"] = "VT", ["Virginia"] = "VA", ["Washington"] = "WA", ["West Virginia"] = "WV",
            ["Wisconsin"] = "WI", ["Wyoming"] = "WY"
        };

        private static string? NormalizeState(string? state)
        {
            if (string.IsNullOrWhiteSpace(state)) return null;
            return _stateAbbreviations.TryGetValue(state.Trim(), out var abbr) ? abbr : state.Trim();
        }
    }
}
