using System;
using System.Collections.Generic;
using System.Linq;

namespace PnCTestAutomation.Tools.FormsBaselineGenerator
{
    public enum CanonicalExpectedDestination
    {
        BASE,
        BASIC,
        CE
    }

    public enum CanonicalProjectionBlockKind
    {
        SourceConflict,
        UpstreamBlocked
    }

    public sealed class CanonicalExpectedRecord
    {
        public string NormalizedIdentifier { get; init; } = "";
        public string FormNumber { get; init; } = "";
        public string Edition { get; init; } = "";
        public CanonicalExpectedDestination Destination { get; init; }
        public IReadOnlyList<string> States { get; init; } = Array.Empty<string>();
        public string Company { get; init; } = "";
        public DateOnly EffectiveDate { get; init; }
        public string Transaction { get; init; } = "";
        public string ProvisionalRuntimeStatus { get; init; } = "";
        public IReadOnlyList<string> ProfileIds { get; init; } = Array.Empty<string>();
        public IReadOnlyList<FormSourceFamily> SourceFamilies { get; init; } =
            Array.Empty<FormSourceFamily>();
        public IReadOnlyList<CanonicalFormSourceRow> SourceRows { get; init; } =
            Array.Empty<CanonicalFormSourceRow>();
        public IReadOnlyList<string> RuleIds { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> Reasons { get; init; } = Array.Empty<string>();
    }

    public sealed class CanonicalImplicitNRecord
    {
        public string NormalizedIdentifier { get; init; } = "";
        public CanonicalExpectedDestination ScenarioDestination { get; init; }
        public IReadOnlyList<string> States { get; init; } = Array.Empty<string>();
        public string Company { get; init; } = "";
        public DateOnly EffectiveDate { get; init; }
        public string Transaction { get; init; } = "";
        public string ProvisionalRuntimeStatus { get; init; } = "N";
        public string Representation { get; init; } = "ImplicitN-EvidenceOnly";
        public bool IncludedInExpectedSet { get; init; }
        public IReadOnlyList<FormSourceFamily> SourceFamilies { get; init; } =
            Array.Empty<FormSourceFamily>();
        public IReadOnlyList<CanonicalFormSourceRow> SourceRows { get; init; } =
            Array.Empty<CanonicalFormSourceRow>();
        public IReadOnlyList<string> RuleIds { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> Reasons { get; init; } = Array.Empty<string>();
    }

    public sealed class CanonicalBlockedProjectionRecord
    {
        public CanonicalProjectionBlockKind Kind { get; init; }
        public string NormalizedIdentifier { get; init; } = "";
        public IReadOnlyList<CanonicalExpectedDestination> ImpactedDestinations { get; init; } =
            Array.Empty<CanonicalExpectedDestination>();
        public IReadOnlyList<string> States { get; init; } = Array.Empty<string>();
        public IReadOnlyList<FormSourceFamily> SourceFamilies { get; init; } =
            Array.Empty<FormSourceFamily>();
        public IReadOnlyList<CanonicalFormSourceRow> SourceRows { get; init; } =
            Array.Empty<CanonicalFormSourceRow>();
        public IReadOnlyList<string> RuleIds { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> Reasons { get; init; } = Array.Empty<string>();
        public string ScenarioImpact { get; init; } = "";
        public IReadOnlyList<CanonicalProjectionVariantEvidence> Variants { get; init; } =
            Array.Empty<CanonicalProjectionVariantEvidence>();
    }

    public sealed record CanonicalProjectionVariantEvidence(
        string Product,
        string ProfileId,
        string State,
        string Company,
        DateOnly EffectiveDate,
        string Transaction,
        CanonicalEditionStatus EditionStatus,
        string ProvisionalRuntimeStatus,
        string ConditionSignature,
        IReadOnlyList<FormSourceFamily> SourceFamilies,
        IReadOnlyList<CanonicalFormSourceRow> SourceRows);

    public sealed class CanonicalExpectedProjection
    {
        public string RuleSetId { get; init; } = "";
        public string RuleVersion { get; init; } = "";
        public IReadOnlyList<CanonicalExpectedRecord> QualifiedRecords { get; init; } =
            Array.Empty<CanonicalExpectedRecord>();
        public IReadOnlyList<CanonicalImplicitNRecord> ImplicitNEvidence { get; init; } =
            Array.Empty<CanonicalImplicitNRecord>();
        public IReadOnlyList<CanonicalBlockedProjectionRecord> BlockedRecords { get; init; } =
            Array.Empty<CanonicalBlockedProjectionRecord>();
    }

    public static class CanonicalExpectedRecordProjector
    {
        public const string RuleSetId = "CanonicalExpectedProjection";
        public const string RuleVersion = "1.0";

        public static CanonicalExpectedProjection Project(
            IEnumerable<CanonicalEditionFamilyResolution> families)
        {
            var blocked = new List<CanonicalBlockedProjectionRecord>();
            var resolvedEditions = new List<EditionEnvelope>();
            foreach (var family in families.OrderBy(
                         family => family.FamilyKey,
                         StringComparer.Ordinal))
            {
                if (family.Status != CanonicalEditionFamilyStatus.Resolved)
                {
                    blocked.Add(BlockUpstream(family));
                    continue;
                }

                resolvedEditions.AddRange(family.Editions
                    .OrderBy(edition => edition.NormalizedIdentifier, StringComparer.Ordinal)
                    .Select(edition => new EditionEnvelope(family, edition)));
            }

            var atomic = new List<AtomicProjectionRecord>();
            foreach (var correlationGroup in resolvedEditions
                         .GroupBy(SourceCorrelationKey, StringComparer.Ordinal)
                         .OrderBy(group => group.Key, StringComparer.Ordinal))
            {
                var variants = correlationGroup
                    .GroupBy(SourceAgreementSignature, StringComparer.Ordinal)
                    .OrderBy(group => group.Key, StringComparer.Ordinal)
                    .Select(group => CreateAtomic(group))
                    .ToArray();
                var familiesPresent = variants
                    .SelectMany(variant => variant.SourceFamilies)
                    .Distinct()
                    .ToArray();
                if (variants.Length > 1
                    && familiesPresent.Contains(FormSourceFamily.Sfp)
                    && familiesPresent.Contains(FormSourceFamily.Common))
                {
                    blocked.Add(BlockSourceConflict(correlationGroup, variants));
                    continue;
                }
                atomic.AddRange(variants);
            }

            var active = atomic
                .Where(record =>
                    record.EditionStatus == CanonicalEditionStatus.ActiveEdition
                    && record.ProvisionalRuntimeStatus == "YM")
                .ToArray();
            var inactive = atomic
                .Where(record => !active.Contains(record))
                .ToArray();

            var routed = RouteActiveRecords(active);
            return new CanonicalExpectedProjection
            {
                RuleSetId = RuleSetId,
                RuleVersion = RuleVersion,
                QualifiedRecords = UnionQualifiedStates(routed),
                ImplicitNEvidence = ProjectImplicitN(inactive),
                BlockedRecords = blocked
                    .OrderBy(record => record.NormalizedIdentifier, StringComparer.Ordinal)
                    .ThenBy(record => record.Kind)
                    .ThenBy(record => string.Join(",", record.States), StringComparer.Ordinal)
                    .ToArray()
            };
        }

        private static IReadOnlyList<RoutedProjectionRecord> RouteActiveRecords(
            IEnumerable<AtomicProjectionRecord> active)
        {
            var result = new List<RoutedProjectionRecord>();
            foreach (var group in active
                         .GroupBy(BaseRoutingKey, StringComparer.Ordinal)
                         .OrderBy(group => group.Key, StringComparer.Ordinal))
            {
                var products = group.Select(record => record.Product)
                    .Distinct(StringComparer.Ordinal)
                    .OrderBy(value => value, StringComparer.Ordinal)
                    .ToArray();
                if (products.SequenceEqual(new[] { "BASIC", "CE" }))
                {
                    result.Add(CreateRouted(
                        CanonicalExpectedDestination.BASE,
                        group,
                        "V1-ROUTE-BASE",
                        "BASIC and CE expectations are fully identical for this scenario state."));
                    continue;
                }

                foreach (var productGroup in group
                             .GroupBy(record => record.Product, StringComparer.Ordinal)
                             .OrderBy(productGroup => productGroup.Key, StringComparer.Ordinal))
                {
                    var destination = Destination(productGroup.Key);
                    result.Add(CreateRouted(
                        destination,
                        productGroup,
                        "V1-ROUTE-SCENARIO",
                        $"Expectation remains {destination} because no fully identical "
                        + "BASIC/CE counterpart exists."));
                }
            }
            return result;
        }

        private static IReadOnlyList<CanonicalExpectedRecord> UnionQualifiedStates(
            IEnumerable<RoutedProjectionRecord> routed) =>
            routed
                .GroupBy(StateUnionKey, StringComparer.Ordinal)
                .OrderBy(group => group.Key, StringComparer.Ordinal)
                .Select(group =>
                {
                    var first = group.First();
                    return new CanonicalExpectedRecord
                    {
                        NormalizedIdentifier = first.NormalizedIdentifier,
                        FormNumber = first.FormNumber,
                        Edition = first.Edition,
                        Destination = first.Destination,
                        States = group.SelectMany(record => record.States)
                            .Distinct(StringComparer.Ordinal)
                            .OrderBy(state => state, StringComparer.Ordinal)
                            .ToArray(),
                        Company = first.Company,
                        EffectiveDate = first.EffectiveDate,
                        Transaction = first.Transaction,
                        ProvisionalRuntimeStatus = first.ProvisionalRuntimeStatus,
                        ProfileIds = group.SelectMany(record => record.ProfileIds)
                            .Distinct(StringComparer.Ordinal)
                            .OrderBy(value => value, StringComparer.Ordinal)
                            .ToArray(),
                        SourceFamilies = group.SelectMany(record => record.SourceFamilies)
                            .Distinct()
                            .OrderBy(value => value)
                            .ToArray(),
                        SourceRows = OrderSourceRows(group.SelectMany(record => record.SourceRows)),
                        RuleIds = group.SelectMany(record => record.RuleIds)
                            .Append("V1-ADDITIVE-STATE-UNION")
                            .Distinct(StringComparer.Ordinal)
                            .ToArray(),
                        Reasons = group.SelectMany(record => record.Reasons)
                            .Append("States are unioned only because every non-state "
                                + "eligibility dimension is identical.")
                            .Distinct(StringComparer.Ordinal)
                            .ToArray()
                    };
                })
                .ToArray();

        private static IReadOnlyList<CanonicalImplicitNRecord> ProjectImplicitN(
            IEnumerable<AtomicProjectionRecord> inactive) =>
            inactive
                .GroupBy(ImplicitNKey, StringComparer.Ordinal)
                .OrderBy(group => group.Key, StringComparer.Ordinal)
                .Select(group =>
                {
                    var first = group.First();
                    return new CanonicalImplicitNRecord
                    {
                        NormalizedIdentifier = first.NormalizedIdentifier,
                        ScenarioDestination = Destination(first.Product),
                        States = group.Select(record => record.State)
                            .Distinct(StringComparer.Ordinal)
                            .OrderBy(value => value, StringComparer.Ordinal)
                            .ToArray(),
                        Company = first.Company,
                        EffectiveDate = first.EffectiveDate,
                        Transaction = first.Transaction,
                        IncludedInExpectedSet = false,
                        SourceFamilies = group.SelectMany(record => record.SourceFamilies)
                            .Distinct()
                            .OrderBy(value => value)
                            .ToArray(),
                        SourceRows = OrderSourceRows(group.SelectMany(record => record.SourceRows)),
                        RuleIds = group.SelectMany(record => record.RuleIds)
                            .Append("V1-IMPLICIT-N-EVIDENCE")
                            .Distinct(StringComparer.Ordinal)
                            .ToArray(),
                        Reasons = group.SelectMany(record => record.Reasons)
                            .Append("N is retained as evidence only; strict runtime expectations "
                                + "represent absent forms implicitly rather than emitting redundant N rows.")
                            .Distinct(StringComparer.Ordinal)
                            .ToArray()
                    };
                })
                .ToArray();

        private static AtomicProjectionRecord CreateAtomic(
            IEnumerable<EditionEnvelope> editions)
        {
            var ordered = editions
                .OrderBy(envelope => envelope.Edition.AggregationKey, StringComparer.Ordinal)
                .ToArray();
            var first = ordered[0];
            return new AtomicProjectionRecord(
                first.Edition.NormalizedIdentifier,
                first.Edition.FormNumber,
                first.Edition.Edition,
                first.Edition.Eligibility.Product,
                first.Edition.Eligibility.ProfileId,
                first.Edition.Eligibility.State,
                first.Edition.Eligibility.Scenario,
                first.Edition.Eligibility.Company,
                first.Edition.Eligibility.EffectiveDate,
                first.Edition.Eligibility.Transaction,
                first.Edition.Status,
                first.Edition.ProvisionalRuntimeStatus ?? "N",
                SemanticConditionSignature(first),
                ordered.SelectMany(envelope => envelope.Edition.Aggregate.Contributors)
                    .Select(row => row.SourceFamily)
                    .Distinct()
                    .OrderBy(value => value)
                    .ToArray(),
                OrderSourceRows(ordered.SelectMany(envelope =>
                    envelope.Edition.Aggregate.Contributors)),
                ordered.SelectMany(envelope => envelope.Edition.RuleIds)
                    .Append("V1-SOURCE-AGREEMENT")
                    .Distinct(StringComparer.Ordinal)
                    .ToArray(),
                ordered.SelectMany(envelope => envelope.Edition.Reasons)
                    .Append("Matching source records agree on all expectation dimensions.")
                    .Distinct(StringComparer.Ordinal)
                    .ToArray());
        }

        private static RoutedProjectionRecord CreateRouted(
            CanonicalExpectedDestination destination,
            IEnumerable<AtomicProjectionRecord> records,
            string ruleId,
            string reason)
        {
            var ordered = records.OrderBy(record => record.ProfileId, StringComparer.Ordinal)
                .ToArray();
            var first = ordered[0];
            return new RoutedProjectionRecord(
                first.NormalizedIdentifier,
                first.FormNumber,
                first.Edition,
                destination,
                new[] { first.State },
                first.Company,
                first.EffectiveDate,
                first.Transaction,
                first.ProvisionalRuntimeStatus,
                first.SemanticSignature,
                ordered.Select(record => record.ProfileId)
                    .Distinct(StringComparer.Ordinal)
                    .OrderBy(value => value, StringComparer.Ordinal)
                    .ToArray(),
                ordered.SelectMany(record => record.SourceFamilies)
                    .Distinct()
                    .OrderBy(value => value)
                    .ToArray(),
                OrderSourceRows(ordered.SelectMany(record => record.SourceRows)),
                ordered.SelectMany(record => record.RuleIds)
                    .Append(ruleId)
                    .Distinct(StringComparer.Ordinal)
                    .ToArray(),
                ordered.SelectMany(record => record.Reasons)
                    .Append(reason)
                    .Distinct(StringComparer.Ordinal)
                    .ToArray());
        }

        private static CanonicalBlockedProjectionRecord BlockUpstream(
            CanonicalEditionFamilyResolution family) =>
            new()
            {
                Kind = CanonicalProjectionBlockKind.UpstreamBlocked,
                NormalizedIdentifier = string.Join(
                    ",",
                    family.Editions.Select(edition => edition.NormalizedIdentifier)
                        .Distinct(StringComparer.Ordinal)
                        .OrderBy(value => value, StringComparer.Ordinal)),
                ImpactedDestinations = new[] { Destination(family.Editions[0].Eligibility.Product) },
                States = new[] { family.State },
                SourceFamilies = family.Editions
                    .SelectMany(edition => edition.Aggregate.Contributors)
                    .Select(row => row.SourceFamily)
                    .Distinct()
                    .OrderBy(value => value)
                    .ToArray(),
                SourceRows = OrderSourceRows(family.Editions
                    .SelectMany(edition => edition.Aggregate.Contributors)),
                RuleIds = family.RuleIds
                    .Append("V1-UPSTREAM-BLOCKED")
                    .Distinct(StringComparer.Ordinal)
                    .ToArray(),
                Reasons = family.Reasons
                    .Append($"Step 6 family status {family.Status} cannot project a complete expected record.")
                    .Distinct(StringComparer.Ordinal)
                    .ToArray(),
                ScenarioImpact = $"{family.ProfileId}/{family.State} remains unresolved.",
                Variants = family.Editions.Select(edition =>
                        new CanonicalProjectionVariantEvidence(
                            edition.Eligibility.Product,
                            edition.Eligibility.ProfileId,
                            edition.Eligibility.State,
                            edition.Eligibility.Company,
                            edition.Eligibility.EffectiveDate,
                            edition.Eligibility.Transaction,
                            edition.Status,
                            edition.ProvisionalRuntimeStatus ?? "N",
                            SemanticConditionSignature(new EditionEnvelope(family, edition)),
                            edition.Aggregate.Contributors.Select(row => row.SourceFamily)
                                .Distinct()
                                .OrderBy(value => value)
                                .ToArray(),
                            OrderSourceRows(edition.Aggregate.Contributors)))
                    .ToArray()
            };

        private static CanonicalBlockedProjectionRecord BlockSourceConflict(
            IEnumerable<EditionEnvelope> editions,
            IEnumerable<AtomicProjectionRecord> variants)
        {
            var ordered = editions.OrderBy(
                    envelope => envelope.Edition.AggregationKey,
                    StringComparer.Ordinal)
                .ToArray();
            var first = ordered[0];
            return new CanonicalBlockedProjectionRecord
            {
                Kind = CanonicalProjectionBlockKind.SourceConflict,
                NormalizedIdentifier = first.Edition.NormalizedIdentifier,
                ImpactedDestinations = new[]
                {
                    Destination(first.Edition.Eligibility.Product)
                },
                States = new[] { first.Edition.Eligibility.State },
                SourceFamilies = variants.SelectMany(variant => variant.SourceFamilies)
                    .Distinct()
                    .OrderBy(value => value)
                    .ToArray(),
                SourceRows = OrderSourceRows(ordered.SelectMany(envelope =>
                    envelope.Edition.Aggregate.Contributors)),
                RuleIds = new[] { "V1-SOURCE-CONFLICT" },
                Reasons = new[]
                {
                    "SFP/Common records disagree on status, company, date, lifecycle, "
                    + "transaction, or eligibility conditions."
                },
                ScenarioImpact = $"{first.Edition.Eligibility.ProfileId}/"
                    + $"{first.Edition.Eligibility.State} cannot emit a complete expected record.",
                Variants = variants.Select(variant =>
                        new CanonicalProjectionVariantEvidence(
                            variant.Product,
                            variant.ProfileId,
                            variant.State,
                            variant.Company,
                            variant.EffectiveDate,
                            variant.Transaction,
                            variant.EditionStatus,
                            variant.ProvisionalRuntimeStatus,
                            variant.SemanticSignature,
                            variant.SourceFamilies,
                            variant.SourceRows))
                    .OrderBy(variant => variant.Product, StringComparer.Ordinal)
                    .ThenBy(variant => variant.Company, StringComparer.Ordinal)
                    .ThenBy(variant => variant.EffectiveDate)
                    .ThenBy(variant => variant.Transaction, StringComparer.Ordinal)
                    .ThenBy(variant => variant.ProvisionalRuntimeStatus, StringComparer.Ordinal)
                    .ToArray()
            };
        }

        private static string SourceCorrelationKey(EditionEnvelope envelope) =>
            string.Join(
                "|",
                envelope.Edition.NormalizedIdentifier,
                envelope.Edition.Eligibility.Product,
                envelope.Edition.Eligibility.ProfileVersion,
                envelope.Edition.Eligibility.State,
                envelope.Edition.Eligibility.Scenario);

        private static string SourceAgreementSignature(EditionEnvelope envelope) =>
            string.Join(
                "|",
                Normalize(envelope.Edition.Eligibility.Company),
                envelope.Edition.Eligibility.EffectiveDate.ToString("yyyy-MM-dd"),
                Normalize(envelope.Edition.Eligibility.Transaction),
                envelope.Edition.Status,
                envelope.Edition.ProvisionalRuntimeStatus ?? "N",
                SemanticConditionSignature(envelope));

        private static string SemanticConditionSignature(EditionEnvelope envelope) =>
            string.Join(
                "\u001F",
                envelope.Edition.Aggregate.Contributors
                    .Select(row => string.Join(
                        "\u001E",
                        Normalize(row.RawSelection),
                        Normalize(row.RawRules),
                        Normalize(row.RawPrintRules),
                        Normalize(row.RawMultipleSelectionCriteria),
                        Normalize(row.RawAdditionalSelectionCriteria),
                        Normalize(row.RawAdditionalRequirements),
                        Normalize(row.RawTransactionRules),
                        NormalizeDate(row.ParsedStartDate, row.RawStartDate),
                        NormalizeDate(row.ParsedStopDate, row.RawStopDate),
                        NormalizeDate(row.ParsedEffectiveDate, row.RawEffectiveDate),
                        Normalize(row.RawLifecycle),
                        Normalize(row.RawWithdrawn),
                        NormalizeIdentifier(row.RawReplacement),
                        string.Join(";", row.StateMarkers
                            .Where(marker =>
                                marker.NormalizedState == envelope.Edition.Eligibility.State)
                            .Select(marker => MarkerCondition(
                                marker,
                                envelope.Edition.Eligibility.State))
                            .OrderBy(value => value, StringComparer.Ordinal))))
                    .Distinct(StringComparer.Ordinal)
                    .OrderBy(value => value, StringComparer.Ordinal));

        private static string BaseRoutingKey(AtomicProjectionRecord record) =>
            string.Join(
                "|",
                record.NormalizedIdentifier,
                record.State,
                Normalize(record.Company),
                record.EffectiveDate.ToString("yyyy-MM-dd"),
                Normalize(record.Transaction),
                record.ProvisionalRuntimeStatus,
                record.SemanticSignature);

        private static string StateUnionKey(RoutedProjectionRecord record) =>
            string.Join(
                "|",
                record.Destination,
                record.NormalizedIdentifier,
                Normalize(record.Company),
                record.EffectiveDate.ToString("yyyy-MM-dd"),
                Normalize(record.Transaction),
                record.ProvisionalRuntimeStatus,
                record.SemanticSignature);

        private static string ImplicitNKey(AtomicProjectionRecord record) =>
            string.Join(
                "|",
                record.Product,
                record.NormalizedIdentifier,
                Normalize(record.Company),
                record.EffectiveDate.ToString("yyyy-MM-dd"),
                Normalize(record.Transaction),
                record.SemanticSignature);

        private static CanonicalExpectedDestination Destination(string product) =>
            product switch
            {
                "BASIC" => CanonicalExpectedDestination.BASIC,
                "CE" => CanonicalExpectedDestination.CE,
                _ => throw new InvalidOperationException(
                    $"Unsupported projection product '{product}'.")
            };

        private static CanonicalFormSourceRow[] OrderSourceRows(
            IEnumerable<CanonicalFormSourceRow> rows) =>
            rows.OrderBy(row => row.SourceFamily)
                .ThenBy(row => row.Workbook.Path, StringComparer.Ordinal)
                .ThenBy(row => row.Worksheet, StringComparer.Ordinal)
                .ThenBy(row => row.SourceRowNumber)
                .ThenBy(row => row.NormalizedFormIdentifier, StringComparer.Ordinal)
                .ToArray();

        private static string NormalizeIdentifier(string value) =>
            string.IsNullOrWhiteSpace(value)
                ? ""
                : new string(value.Where(char.IsLetterOrDigit).ToArray()).ToUpperInvariant();

        private static string Normalize(string value) =>
            string.IsNullOrWhiteSpace(value)
                ? ""
                : string.Join(
                    " ",
                    value.Split((char[])null, StringSplitOptions.RemoveEmptyEntries))
                    .ToUpperInvariant();

        private static string NormalizeDate(DateOnly? parsed, string raw) =>
            parsed?.ToString("yyyy-MM-dd") ?? Normalize(raw);

        private static string MarkerCondition(
            CanonicalStateMarker marker,
            string state)
        {
            var header = marker.RawHeader.Trim();
            if (header.Equals(state, StringComparison.OrdinalIgnoreCase))
                return $"STATE:{Normalize(marker.RawValue)}";
            if (header.StartsWith(state, StringComparison.OrdinalIgnoreCase))
                header = header[state.Length..].Trim(' ', '-', '_');
            return $"COMPANY:{Normalize(header)}:{Normalize(marker.RawValue)}";
        }

        private sealed record EditionEnvelope(
            CanonicalEditionFamilyResolution Family,
            CanonicalEditionResolution Edition);

        private sealed record AtomicProjectionRecord(
            string NormalizedIdentifier,
            string FormNumber,
            string Edition,
            string Product,
            string ProfileId,
            string State,
            string Scenario,
            string Company,
            DateOnly EffectiveDate,
            string Transaction,
            CanonicalEditionStatus EditionStatus,
            string ProvisionalRuntimeStatus,
            string SemanticSignature,
            IReadOnlyList<FormSourceFamily> SourceFamilies,
            IReadOnlyList<CanonicalFormSourceRow> SourceRows,
            IReadOnlyList<string> RuleIds,
            IReadOnlyList<string> Reasons);

        private sealed record RoutedProjectionRecord(
            string NormalizedIdentifier,
            string FormNumber,
            string Edition,
            CanonicalExpectedDestination Destination,
            IReadOnlyList<string> States,
            string Company,
            DateOnly EffectiveDate,
            string Transaction,
            string ProvisionalRuntimeStatus,
            string SemanticSignature,
            IReadOnlyList<string> ProfileIds,
            IReadOnlyList<FormSourceFamily> SourceFamilies,
            IReadOnlyList<CanonicalFormSourceRow> SourceRows,
            IReadOnlyList<string> RuleIds,
            IReadOnlyList<string> Reasons);
    }
}
