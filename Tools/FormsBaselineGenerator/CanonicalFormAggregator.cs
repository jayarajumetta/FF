using System;
using System.Collections.Generic;
using System.Linq;

namespace PnCTestAutomation.Tools.FormsBaselineGenerator
{
    public sealed class CanonicalFormAggregate
    {
        public string AggregationKey { get; init; } = "";
        public string FormNumber { get; init; } = "";
        public string Edition { get; init; } = "";
        public IReadOnlyList<CanonicalFormSourceRow> Contributors { get; init; } =
            Array.Empty<CanonicalFormSourceRow>();
        public IReadOnlyList<CanonicalStateMarker> StateMarkers { get; init; } =
            Array.Empty<CanonicalStateMarker>();
        public IReadOnlyList<CanonicalSourceFinding> Findings { get; init; } =
            Array.Empty<CanonicalSourceFinding>();
        public bool ManualReviewRequired =>
            Findings.Any(finding => finding.ManualReviewRequired);
    }

    public static class CanonicalFormAggregator
    {
        public static IReadOnlyList<CanonicalFormAggregate> Aggregate(
            IEnumerable<CanonicalFormSourceRow> sourceRows)
        {
            var orderedRows = sourceRows
                .OrderBy(SourceOrderKey, StringComparer.Ordinal)
                .ToArray();
            var result = new List<CanonicalFormAggregate>();
            var validRows = orderedRows
                .Where(HasSafeIdentity)
                .GroupBy(AggregationIdentity, StringComparer.Ordinal)
                .OrderBy(group => group.Key, StringComparer.Ordinal);

            foreach (var identityGroup in validRows)
            {
                var partitions = identityGroup
                    .GroupBy(EquivalenceSignature, StringComparer.Ordinal)
                    .OrderBy(group => group.Key, StringComparer.Ordinal)
                    .ToArray();
                var conflictDimensions = partitions.Length > 1
                    ? FindConflictDimensions(identityGroup)
                    : Array.Empty<string>();

                foreach (var partition in partitions)
                {
                    var findings = conflictDimensions.Length == 0
                        ? Array.Empty<CanonicalSourceFinding>()
                        : new[]
                        {
                            new CanonicalSourceFinding(
                                "AggregationConflict",
                                $"Eligibility-affecting dimensions differ for {identityGroup.Key}: "
                                + string.Join(", ", conflictDimensions) + ".",
                                null,
                                ManualReviewRequired: true)
                        };
                    result.Add(CreateAggregate(
                        identityGroup.Key,
                        partition,
                        findings));
                }
            }

            foreach (var row in orderedRows.Where(row => !HasSafeIdentity(row)))
            {
                var finding = new CanonicalSourceFinding(
                    "AggregationIdentityAmbiguous",
                    $"Source row cannot be auto-merged because '{row.NormalizedFormIdentifier}' "
                    + "does not have a consistent safely parsed form number and edition.",
                    row.RelevantCells.FirstOrDefault()?.Address,
                    ManualReviewRequired: true);
                result.Add(CreateAggregate(
                    $"UNRESOLVED|{SourceOrderKey(row)}",
                    new[] { row },
                    new[] { finding }));
            }

            return result
                .OrderBy(aggregate => aggregate.AggregationKey, StringComparer.Ordinal)
                .ThenBy(aggregate => SourceOrderKey(aggregate.Contributors[0]), StringComparer.Ordinal)
                .ToArray();
        }

        private static CanonicalFormAggregate CreateAggregate(
            string aggregationKey,
            IEnumerable<CanonicalFormSourceRow> sourceRows,
            IReadOnlyList<CanonicalSourceFinding> aggregateFindings)
        {
            var contributors = sourceRows
                .OrderBy(SourceOrderKey, StringComparer.Ordinal)
                .ToArray();
            var first = contributors[0];
            var findings = contributors
                .SelectMany(row => row.Findings)
                .Concat(aggregateFindings)
                .OrderBy(finding => finding.Code, StringComparer.Ordinal)
                .ThenBy(finding => finding.Message, StringComparer.Ordinal)
                .ThenBy(finding => finding.CellAddress, StringComparer.Ordinal)
                .ToArray();
            return new CanonicalFormAggregate
            {
                AggregationKey = aggregationKey,
                FormNumber = first.ParsedFormNumber ?? "",
                Edition = first.ParsedEdition ?? "",
                Contributors = contributors,
                StateMarkers = contributors
                    .SelectMany(row => row.StateMarkers)
                    .OrderBy(marker => marker.NormalizedState, StringComparer.Ordinal)
                    .ThenBy(marker => marker.RawHeader, StringComparer.Ordinal)
                    .ThenBy(marker => marker.RawValue, StringComparer.Ordinal)
                    .ThenBy(marker => marker.Address, StringComparer.Ordinal)
                    .ToArray(),
                Findings = findings
            };
        }

        private static bool HasSafeIdentity(CanonicalFormSourceRow row) =>
            !string.IsNullOrWhiteSpace(row.ParsedFormNumber)
            && !string.IsNullOrWhiteSpace(row.ParsedEdition)
            && row.NormalizedFormIdentifier.Equals(
                row.ParsedFormNumber + row.ParsedEdition,
                StringComparison.OrdinalIgnoreCase);

        private static string AggregationIdentity(CanonicalFormSourceRow row) =>
            $"{row.ParsedFormNumber.ToUpperInvariant()}|{row.ParsedEdition.ToUpperInvariant()}";

        private static string EquivalenceSignature(CanonicalFormSourceRow row) =>
            string.Join(
                "\u001F",
                EligibilityDimensions(row)
                    .OrderBy(pair => pair.Key, StringComparer.Ordinal)
                    .Select(pair => $"{pair.Key}={pair.Value}"));

        private static string[] FindConflictDimensions(
            IEnumerable<CanonicalFormSourceRow> rows) =>
            rows.Select(EligibilityDimensions)
                .SelectMany(dimensions => dimensions.Keys)
                .Distinct(StringComparer.Ordinal)
                .Where(name => rows
                    .Select(row => EligibilityDimensions(row).GetValueOrDefault(name, ""))
                    .Distinct(StringComparer.Ordinal)
                    .Skip(1)
                    .Any())
                .OrderBy(name => name, StringComparer.Ordinal)
                .ToArray();

        private static IReadOnlyDictionary<string, string> EligibilityDimensions(
            CanonicalFormSourceRow row) =>
            new Dictionary<string, string>(StringComparer.Ordinal)
            {
                ["AdditionalRequirements"] = Normalize(row.RawAdditionalRequirements),
                ["AdditionalSelectionCriteria"] = Normalize(row.RawAdditionalSelectionCriteria),
                ["CompanyApplicability"] = string.Join(
                    ";",
                    row.StateMarkers
                        .Where(marker => marker.IsCompanySpecific)
                        .OrderBy(marker => marker.RawHeader, StringComparer.Ordinal)
                        .ThenBy(marker => marker.RawValue, StringComparer.Ordinal)
                        .Select(marker => $"{Normalize(marker.RawHeader)}:{NormalizeMarker(marker.RawValue)}")),
                ["EffectiveDate"] = NormalizeDate(row.ParsedEffectiveDate, row.RawEffectiveDate),
                ["ExplicitRemovals"] = string.Join(
                    ";",
                    row.StateMarkers
                        .Where(marker => !marker.IsCompanySpecific)
                        .Where(marker => NormalizeMarker(marker.RawValue) == "X")
                        .Select(marker => Normalize(marker.RawHeader))
                        .Distinct(StringComparer.Ordinal)
                        .OrderBy(value => value, StringComparer.Ordinal)),
                ["Lifecycle"] = Normalize(row.RawLifecycle),
                ["MultipleSelectionCriteria"] = Normalize(row.RawMultipleSelectionCriteria),
                ["Notes"] = Normalize(row.RawNotes),
                ["PrintRules"] = Normalize(row.RawPrintRules),
                ["ProductScenario"] = Normalize(row.LegacySection) + ";"
                    + string.Join(
                        ";",
                        row.SourceDivisionProductHints
                            .Select(Normalize)
                            .Where(value => value.Length > 0)
                            .Distinct(StringComparer.Ordinal)
                            .OrderBy(value => value, StringComparer.Ordinal)),
                ["Replacement"] = Normalize(row.RawReplacement),
                ["Rules"] = Normalize(row.RawRules),
                ["Selection"] = Normalize(row.RawSelection),
                ["StartDate"] = NormalizeDate(row.ParsedStartDate, row.RawStartDate),
                ["StopDate"] = NormalizeDate(row.ParsedStopDate, row.RawStopDate),
                ["TitleDescription"] = Normalize(row.TitleDescription),
                ["Transactions"] = Normalize(row.RawTransactionRules) + ";"
                    + string.Join(
                        ";",
                        row.TransactionTokens
                            .Select(Normalize)
                            .Distinct(StringComparer.Ordinal)
                            .OrderBy(value => value, StringComparer.Ordinal)),
                ["Withdrawn"] = Normalize(row.RawWithdrawn)
            };

        private static string SourceOrderKey(CanonicalFormSourceRow row) =>
            string.Join(
                "|",
                row.SourceFamily,
                row.Workbook.Path ?? "",
                row.Worksheet ?? "",
                row.SourceRowNumber.ToString("D8", System.Globalization.CultureInfo.InvariantCulture),
                row.NormalizedFormIdentifier ?? "");

        private static string Normalize(string value) =>
            string.IsNullOrWhiteSpace(value)
                ? ""
                : string.Join(
                    " ",
                    value.Split(
                        (char[])null,
                        StringSplitOptions.RemoveEmptyEntries))
                    .ToUpperInvariant();

        private static string NormalizeMarker(string value) =>
            string.IsNullOrWhiteSpace(value) ? "<BLANK>" : Normalize(value);

        private static string NormalizeDate(DateOnly? parsed, string raw) =>
            parsed?.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            ?? Normalize(raw);
    }
}
