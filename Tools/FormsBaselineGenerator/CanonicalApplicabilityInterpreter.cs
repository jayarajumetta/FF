using System;
using System.Collections.Generic;
using System.Linq;

namespace PnCTestAutomation.Tools.FormsBaselineGenerator
{
    public enum CanonicalApplicability
    {
        Applicable,
        ExplicitRemoval,
        NotApplicable,
        Unknown
    }

    public enum CanonicalInterpretationOutcome
    {
        Mapped,
        Indeterminate,
        ManualReviewRequired
    }

    public sealed record CanonicalEvidenceReference(
        FormSourceFamily SourceFamily,
        string WorkbookIdentity,
        string WorkbookHash,
        string Worksheet,
        int SourceRow,
        string MarkerCell,
        string SelectionCell);

    public sealed class CanonicalMarkerInterpretation
    {
        public string State { get; init; } = "";
        public string RawHeader { get; init; } = "";
        public string RawMarker { get; init; } = "";
        public string RawSelection { get; init; } = "";
        public CanonicalApplicability Applicability { get; init; }
        public string ProvisionalRuntimeStatus { get; init; }
        public CanonicalInterpretationOutcome Outcome { get; init; }
        public bool ManualReviewRequired { get; init; }
        public string RuleSetId { get; init; } = "";
        public string RuleVersion { get; init; } = "";
        public string RuleId { get; init; } = "";
        public IReadOnlyList<string> Reasons { get; init; } = Array.Empty<string>();
        public IReadOnlyList<CanonicalEvidenceReference> Evidence { get; init; } =
            Array.Empty<CanonicalEvidenceReference>();
    }

    public sealed class CanonicalAggregateInterpretation
    {
        public string AggregationKey { get; init; } = "";
        public string RuleSetId { get; init; } = "";
        public string RuleVersion { get; init; } = "";
        public bool IsBlocked { get; init; }
        public IReadOnlyList<string> BlockReasons { get; init; } = Array.Empty<string>();
        public IReadOnlyList<CanonicalMarkerInterpretation> MarkerResults { get; init; } =
            Array.Empty<CanonicalMarkerInterpretation>();
    }

    public static class CanonicalApplicabilityInterpreter
    {
        public const string RuleSetId = "FormsApplicabilitySelection";
        public const string RuleVersion = "1.0";

        private static readonly HashSet<string> BlockingFindingCodes =
            new(StringComparer.Ordinal)
            {
                "AggregationConflict",
                "AggregationIdentityAmbiguous"
            };

        public static CanonicalAggregateInterpretation Interpret(
            CanonicalFormAggregate aggregate)
        {
            var blockingFindings = aggregate.Findings
                .Where(finding => BlockingFindingCodes.Contains(finding.Code))
                .OrderBy(finding => finding.Code, StringComparer.Ordinal)
                .ThenBy(finding => finding.Message, StringComparer.Ordinal)
                .ToArray();
            if (blockingFindings.Length > 0)
            {
                return new CanonicalAggregateInterpretation
                {
                    AggregationKey = aggregate.AggregationKey,
                    RuleSetId = RuleSetId,
                    RuleVersion = RuleVersion,
                    IsBlocked = true,
                    BlockReasons = blockingFindings
                        .Select(finding => $"{finding.Code}: {finding.Message}")
                        .ToArray()
                };
            }

            var results = aggregate.Contributors
                .OrderBy(SourceOrderKey, StringComparer.Ordinal)
                .SelectMany(row => row.StateMarkers
                    .OrderBy(marker => marker.NormalizedState, StringComparer.Ordinal)
                    .ThenBy(marker => marker.RawHeader, StringComparer.Ordinal)
                    .ThenBy(marker => marker.Address, StringComparer.Ordinal)
                    .Select(marker => InterpretMarker(row, marker)))
                .ToArray();

            return new CanonicalAggregateInterpretation
            {
                AggregationKey = aggregate.AggregationKey,
                RuleSetId = RuleSetId,
                RuleVersion = RuleVersion,
                MarkerResults = results
            };
        }

        private static CanonicalMarkerInterpretation InterpretMarker(
            CanonicalFormSourceRow row,
            CanonicalStateMarker marker)
        {
            var rawMarker = marker.RawValue;
            var markerValue = rawMarker.Trim().ToUpperInvariant();
            var rawSelection = row.RawSelection;
            var selectionValue = rawSelection.Trim().ToUpperInvariant();
            var applicability = markerValue switch
            {
                "Y" => CanonicalApplicability.Applicable,
                "X" => CanonicalApplicability.ExplicitRemoval,
                "N" => CanonicalApplicability.NotApplicable,
                "" => CanonicalApplicability.NotApplicable,
                _ => CanonicalApplicability.Unknown
            };
            var evidence = new[]
            {
                new CanonicalEvidenceReference(
                    row.SourceFamily,
                    row.Workbook.Identity,
                    row.Workbook.Sha256,
                    row.Worksheet,
                    row.SourceRowNumber,
                    marker.Address,
                    FindSelectionCell(row))
            };

            if (!marker.IsConfiguredState)
            {
                return Review(
                    marker.NormalizedState,
                    marker.RawHeader,
                    rawMarker,
                    rawSelection,
                    applicability,
                    "V1-UNCONFIGURED-STATE",
                    "State marker is not part of the configured scenario-state profile.",
                    evidence);
            }
            if (marker.IsCompanySpecific)
            {
                return Review(
                    marker.NormalizedState,
                    marker.RawHeader,
                    rawMarker,
                    rawSelection,
                    applicability,
                    "V1-COMPANY-DEFERRED",
                    "Company-specific applicability requires a later structured company rule.",
                    evidence);
            }
            if (applicability == CanonicalApplicability.Unknown)
            {
                return Review(
                    marker.NormalizedState,
                    marker.RawHeader,
                    rawMarker,
                    rawSelection,
                    applicability,
                    "V1-UNKNOWN-MARKER",
                    $"Unsupported raw state marker '{rawMarker}' was preserved.",
                    evidence);
            }
            if (selectionValue == "UNAVAILABLE")
            {
                return Review(
                    marker.NormalizedState,
                    marker.RawHeader,
                    rawMarker,
                    rawSelection,
                    applicability,
                    "V1-SELECTION-UNAVAILABLE",
                    "Selection 'Unavailable' cannot be mapped automatically.",
                    evidence);
            }
            if (selectionValue.Length > 0 && selectionValue != "MANDATORY")
            {
                return Review(
                    marker.NormalizedState,
                    marker.RawHeader,
                    rawMarker,
                    rawSelection,
                    applicability,
                    "V1-UNSUPPORTED-SELECTION",
                    $"Unsupported Selection '{rawSelection}' was preserved.",
                    evidence);
            }

            if (applicability == CanonicalApplicability.ExplicitRemoval)
            {
                return Mapped(
                    marker.NormalizedState,
                    marker.RawHeader,
                    rawMarker,
                    rawSelection,
                    applicability,
                    "N",
                    "V1-EXPLICIT-REMOVAL",
                    "Raw X is an explicit removal and remains distinct from blank.",
                    evidence);
            }
            if (applicability == CanonicalApplicability.NotApplicable)
            {
                if (markerValue == "N")
                {
                    return Mapped(
                        marker.NormalizedState,
                        marker.RawHeader,
                        rawMarker,
                        rawSelection,
                        applicability,
                        "N",
                        "V1-RAW-N-NOT-APPLICABLE",
                        "Raw N is not applicable and remains distinct from blank and explicit X.",
                        evidence);
                }
                return Mapped(
                    marker.NormalizedState,
                    marker.RawHeader,
                    rawMarker,
                    rawSelection,
                    applicability,
                    "N",
                    "V1-NOT-APPLICABLE",
                    "Raw blank is not applicable and remains distinct from explicit X.",
                    evidence);
            }
            if (selectionValue == "MANDATORY")
            {
                return Mapped(
                    marker.NormalizedState,
                    marker.RawHeader,
                    rawMarker,
                    rawSelection,
                    applicability,
                    "YM",
                    "V1-Y-MANDATORY",
                    "Applicable Y plus Mandatory Selection maps provisionally to YM.",
                    evidence);
            }
            if (selectionValue.Length == 0)
            {
                return new CanonicalMarkerInterpretation
                {
                    State = marker.NormalizedState,
                    RawHeader = marker.RawHeader,
                    RawMarker = rawMarker,
                    RawSelection = rawSelection,
                    Applicability = applicability,
                    Outcome = CanonicalInterpretationOutcome.Indeterminate,
                    ManualReviewRequired = true,
                    RuleSetId = RuleSetId,
                    RuleVersion = RuleVersion,
                    RuleId = "V1-Y-BLANK-SELECTION",
                    Reasons = new[]
                    {
                        "Applicable Y with blank Selection cannot be mapped automatically."
                    },
                    Evidence = evidence
                };
            }
            throw new InvalidOperationException(
                $"Unhandled applicability/Selection combination: {applicability}/{selectionValue}.");
        }

        private static CanonicalMarkerInterpretation Mapped(
            string state,
            string rawHeader,
            string rawMarker,
            string rawSelection,
            CanonicalApplicability applicability,
            string status,
            string ruleId,
            string reason,
            IReadOnlyList<CanonicalEvidenceReference> evidence) =>
            new()
            {
                State = state,
                RawHeader = rawHeader,
                RawMarker = rawMarker,
                RawSelection = rawSelection,
                Applicability = applicability,
                ProvisionalRuntimeStatus = status,
                Outcome = CanonicalInterpretationOutcome.Mapped,
                RuleSetId = RuleSetId,
                RuleVersion = RuleVersion,
                RuleId = ruleId,
                Reasons = new[] { reason },
                Evidence = evidence
            };

        private static CanonicalMarkerInterpretation Review(
            string state,
            string rawHeader,
            string rawMarker,
            string rawSelection,
            CanonicalApplicability applicability,
            string ruleId,
            string reason,
            IReadOnlyList<CanonicalEvidenceReference> evidence) =>
            new()
            {
                State = state,
                RawHeader = rawHeader,
                RawMarker = rawMarker,
                RawSelection = rawSelection,
                Applicability = applicability,
                Outcome = CanonicalInterpretationOutcome.ManualReviewRequired,
                ManualReviewRequired = true,
                RuleSetId = RuleSetId,
                RuleVersion = RuleVersion,
                RuleId = ruleId,
                Reasons = new[] { reason },
                Evidence = evidence
            };

        private static string FindSelectionCell(CanonicalFormSourceRow row) =>
            row.RelevantCells.FirstOrDefault(cell =>
                cell.Header.Trim().Equals("Selection", StringComparison.OrdinalIgnoreCase))
                ?.Address ?? "";

        private static string SourceOrderKey(CanonicalFormSourceRow row) =>
            string.Join(
                "|",
                row.SourceFamily,
                row.Workbook.Path ?? "",
                row.Worksheet ?? "",
                row.SourceRowNumber.ToString("D8", System.Globalization.CultureInfo.InvariantCulture));
    }
}
