using System;
using System.Collections.Generic;
using System.Linq;

namespace PnCTestAutomation.Tools.FormsBaselineGenerator
{
    public enum CanonicalEditionStatus
    {
        ActiveEdition,
        InactiveEdition,
        FutureEdition,
        Overlap,
        ManualReviewRequired
    }

    public enum CanonicalEditionFamilyStatus
    {
        Resolved,
        Overlap,
        Gap,
        ManualReviewRequired
    }

    public sealed record CanonicalEditionCandidate(
        CanonicalFormAggregate Aggregate,
        ScenarioEligibilityResult Eligibility);

    public sealed record CanonicalReplacementRelationship(
        string ReplacingIdentifier,
        string ReplacedIdentifier,
        DateOnly ReplacementStart,
        DateOnly ReplacedStop,
        IReadOnlyList<CanonicalEvidenceReference> Evidence);

    public sealed class CanonicalEditionResolution
    {
        public string AggregationKey { get; init; } = "";
        public string FormNumber { get; init; } = "";
        public string Edition { get; init; } = "";
        public string NormalizedIdentifier { get; init; } = "";
        public CanonicalFormAggregate Aggregate { get; init; }
        public CanonicalEditionStatus Status { get; init; }
        public string ProvisionalRuntimeStatus { get; init; }
        public ScenarioEligibilityResult Eligibility { get; init; }
        public IReadOnlyList<string> RelatedIdentifiers { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> RuleIds { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> Reasons { get; init; } = Array.Empty<string>();
        public IReadOnlyList<CanonicalEvidenceReference> SourceEvidence { get; init; } =
            Array.Empty<CanonicalEvidenceReference>();
    }

    public sealed class CanonicalEditionFamilyResolution
    {
        public string FamilyKey { get; init; } = "";
        public string FormNumber { get; init; } = "";
        public string ProfileId { get; init; } = "";
        public string State { get; init; } = "";
        public string Scenario { get; init; } = "";
        public string Company { get; init; } = "";
        public DateOnly EffectiveDate { get; init; }
        public CanonicalEditionFamilyStatus Status { get; init; }
        public bool ManualReviewRequired { get; init; }
        public string RuleSetId { get; init; } = "";
        public string RuleVersion { get; init; } = "";
        public IReadOnlyList<string> RuleIds { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> Reasons { get; init; } = Array.Empty<string>();
        public IReadOnlyList<CanonicalReplacementRelationship> Relationships { get; init; } =
            Array.Empty<CanonicalReplacementRelationship>();
        public IReadOnlyList<CanonicalEditionResolution> Editions { get; init; } =
            Array.Empty<CanonicalEditionResolution>();
    }

    public static class CanonicalEditionLifecycleResolver
    {
        public const string RuleSetId = "CanonicalEditionLifecycle";
        public const string RuleVersion = "1.0";

        public static IReadOnlyList<CanonicalEditionFamilyResolution> Resolve(
            IEnumerable<CanonicalEditionCandidate> candidates) =>
            candidates
                .OrderBy(CandidateOrderKey, StringComparer.Ordinal)
                .GroupBy(FamilyKey, StringComparer.Ordinal)
                .OrderBy(group => group.Key, StringComparer.Ordinal)
                .Select(ResolveFamily)
                .ToArray();

        private static CanonicalEditionFamilyResolution ResolveFamily(
            IGrouping<string, CanonicalEditionCandidate> family)
        {
            var candidates = family
                .OrderBy(CandidateOrderKey, StringComparer.Ordinal)
                .ToArray();
            var first = candidates[0];
            var metadata = candidates
                .Select(CreateMetadata)
                .OrderBy(item => item.Identifier, StringComparer.Ordinal)
                .ThenBy(item => item.Candidate.Aggregate.AggregationKey, StringComparer.Ordinal)
                .ToArray();
            var familyRules = new List<string>();
            var familyReasons = new List<string>();
            var manualReview = false;

            void Manual(string ruleId, string reason)
            {
                manualReview = true;
                familyRules.Add(ruleId);
                familyReasons.Add(reason);
            }

            foreach (var item in metadata)
            {
                if (item.HasUnusableDate)
                {
                    Manual(
                        "V1-DATE-UNUSABLE",
                        $"{item.Identifier} contains populated date text that is not safely parsed.");
                }
                if (item.ReplacementTargets.Length > 1)
                {
                    Manual(
                        "V1-REPLACEMENT-CONFLICT",
                        $"{item.Identifier} identifies multiple replacement targets.");
                }
            }

            if (metadata.GroupBy(item => item.Identifier, StringComparer.Ordinal)
                .Any(group => group.Count() > 1))
            {
                Manual(
                    "V1-DUPLICATE-EDITION-PARTITIONS",
                    "The same form edition occurs in multiple condition partitions.");
            }

            var byIdentifier = metadata
                .GroupBy(item => item.Identifier, StringComparer.Ordinal)
                .ToDictionary(group => group.Key, group => group.First(), StringComparer.Ordinal);
            var relationships = new List<CanonicalReplacementRelationship>();
            foreach (var replacing in metadata.Where(item => item.ReplacementTargets.Length == 1))
            {
                var target = replacing.ReplacementTargets[0];
                if (!byIdentifier.TryGetValue(target, out var replaced))
                {
                    Manual(
                        "V1-REPLACEMENT-TARGET-MISSING",
                        $"{replacing.Identifier} references missing replacement target {target}.");
                    continue;
                }
                if (!replacing.LowerBound.HasValue || !replaced.StopDate.HasValue)
                {
                    Manual(
                        "V1-REPLACEMENT-DATES-INCOMPLETE",
                        $"{replacing.Identifier} -> {target} requires a parsed replacement start "
                        + "and replaced-edition stop date.");
                    continue;
                }
                relationships.Add(new CanonicalReplacementRelationship(
                    replacing.Identifier,
                    target,
                    replacing.LowerBound.Value,
                    replaced.StopDate.Value,
                    replacing.Candidate.Eligibility.SourceEvidence
                        .Concat(replaced.Candidate.Eligibility.SourceEvidence)
                        .OrderBy(evidence => evidence.WorkbookIdentity, StringComparer.Ordinal)
                        .ThenBy(evidence => evidence.Worksheet, StringComparer.Ordinal)
                        .ThenBy(evidence => evidence.SourceRow)
                        .ThenBy(evidence => evidence.MarkerCell, StringComparer.Ordinal)
                        .ToArray()));
            }

            if (relationships.GroupBy(
                    relationship => relationship.ReplacedIdentifier,
                    StringComparer.Ordinal)
                .Any(group => group.Count() > 1))
            {
                Manual(
                    "V1-REPLACEMENT-CHAIN-CONFLICT",
                    "Multiple editions identify the same direct replacement target.");
            }
            if (HasCycle(relationships))
            {
                Manual(
                    "V1-REPLACEMENT-CYCLE",
                    "Replacement relationships contain a cycle.");
            }

            if (metadata.Length > 1
                && metadata.Any(item =>
                    item.Candidate.Eligibility.Outcome == ScenarioEligibilityOutcome.Eligible
                    && !item.LowerBound.HasValue
                    && !item.StopDate.HasValue))
            {
                Manual(
                    "V1-EDITION-DATES-INCOMPLETE",
                    "Multiple editions cannot be resolved when an otherwise eligible edition "
                    + "has no parsed interval boundary.");
            }

            var states = metadata.ToDictionary(
                item => item,
                item => InitialStatus(item, first.Eligibility.EffectiveDate));
            foreach (var relationship in relationships)
            {
                var replacing = byIdentifier[relationship.ReplacingIdentifier];
                var replaced = byIdentifier[relationship.ReplacedIdentifier];
                if (relationship.ReplacementStart <= first.Eligibility.EffectiveDate
                    && relationship.ReplacedStop <= first.Eligibility.EffectiveDate
                    && states[replaced] != CanonicalEditionStatus.ManualReviewRequired)
                {
                    states[replaced] = CanonicalEditionStatus.InactiveEdition;
                }
            }

            if (metadata.Any(item =>
                    item.Candidate.Eligibility.Outcome
                    is ScenarioEligibilityOutcome.ManualReviewRequired
                    or ScenarioEligibilityOutcome.Indeterminate))
            {
                Manual(
                    "V1-STEP5-UNRESOLVED",
                    "At least one edition has an unresolved Step 5 scenario-eligibility result.");
            }

            CanonicalEditionFamilyStatus familyStatus;
            if (manualReview)
            {
                familyStatus = CanonicalEditionFamilyStatus.ManualReviewRequired;
                foreach (var item in metadata.Where(item =>
                             states[item] == CanonicalEditionStatus.ActiveEdition))
                {
                    states[item] = CanonicalEditionStatus.ManualReviewRequired;
                }
            }
            else
            {
                var active = metadata
                    .Where(item => states[item] == CanonicalEditionStatus.ActiveEdition)
                    .ToArray();
                if (active.Length > 1)
                {
                    familyStatus = CanonicalEditionFamilyStatus.Overlap;
                    familyRules.Add("V1-EDITION-OVERLAP");
                    familyReasons.Add(
                        "Multiple Step 5-eligible editions are date-active for the scenario.");
                    foreach (var item in active)
                        states[item] = CanonicalEditionStatus.Overlap;
                }
                else if (active.Length == 0
                         && (relationships.Count > 0
                             || metadata.Any(item =>
                                 item.Candidate.Eligibility.Outcome
                                 == ScenarioEligibilityOutcome.Eligible)))
                {
                    familyStatus = CanonicalEditionFamilyStatus.Gap;
                    familyRules.Add("V1-EDITION-GAP");
                    familyReasons.Add(
                        "No Step 5-eligible edition is date-active for the scenario.");
                }
                else
                {
                    familyStatus = CanonicalEditionFamilyStatus.Resolved;
                    familyRules.Add("V1-EDITION-RESOLVED");
                    familyReasons.Add(
                        active.Length == 1
                            ? $"{active[0].Identifier} is the sole date-active eligible edition."
                            : "No edition is expected because all editions are scenario-ineligible.");
                }
            }

            var editionResults = metadata
                .Select(item => CreateEditionResult(
                    item,
                    states[item],
                    relationships,
                    familyRules,
                    familyReasons,
                    first.Eligibility.EffectiveDate))
                .OrderBy(result => result.NormalizedIdentifier, StringComparer.Ordinal)
                .ThenBy(result => result.AggregationKey, StringComparer.Ordinal)
                .ToArray();

            return new CanonicalEditionFamilyResolution
            {
                FamilyKey = family.Key,
                FormNumber = first.Aggregate.FormNumber,
                ProfileId = first.Eligibility.ProfileId,
                State = first.Eligibility.State,
                Scenario = first.Eligibility.Scenario,
                Company = first.Eligibility.Company,
                EffectiveDate = first.Eligibility.EffectiveDate,
                Status = familyStatus,
                ManualReviewRequired = familyStatus
                    is CanonicalEditionFamilyStatus.ManualReviewRequired
                    or CanonicalEditionFamilyStatus.Overlap
                    or CanonicalEditionFamilyStatus.Gap,
                RuleSetId = RuleSetId,
                RuleVersion = RuleVersion,
                RuleIds = familyRules.Distinct(StringComparer.Ordinal).ToArray(),
                Reasons = familyReasons.Distinct(StringComparer.Ordinal).ToArray(),
                Relationships = relationships
                    .OrderBy(relationship => relationship.ReplacingIdentifier, StringComparer.Ordinal)
                    .ThenBy(relationship => relationship.ReplacedIdentifier, StringComparer.Ordinal)
                    .ToArray(),
                Editions = editionResults
            };
        }

        private static CandidateMetadata CreateMetadata(
            CanonicalEditionCandidate candidate)
        {
            var rows = candidate.Aggregate.Contributors;
            var lowerBounds = rows
                .SelectMany(row => new[] { row.ParsedStartDate, row.ParsedEffectiveDate })
                .Where(value => value.HasValue)
                .Select(value => value.Value)
                .Distinct()
                .ToArray();
            var stops = rows
                .Where(row => row.ParsedStopDate.HasValue)
                .Select(row => row.ParsedStopDate.Value)
                .Distinct()
                .ToArray();
            var targets = rows
                .Select(row => NormalizeIdentifier(row.RawReplacement))
                .Where(value => value.Length > 0)
                .Distinct(StringComparer.Ordinal)
                .OrderBy(value => value, StringComparer.Ordinal)
                .ToArray();
            return new CandidateMetadata(
                candidate,
                candidate.Aggregate.FormNumber + candidate.Aggregate.Edition,
                lowerBounds.Length == 0 ? null : lowerBounds.Max(),
                stops.Length == 0 ? null : stops.Single(),
                targets,
                rows.Any(HasUnusableDate));
        }

        private static CanonicalEditionStatus InitialStatus(
            CandidateMetadata item,
            DateOnly effectiveDate)
        {
            if (item.Candidate.Eligibility.Outcome
                is ScenarioEligibilityOutcome.ManualReviewRequired
                or ScenarioEligibilityOutcome.Indeterminate)
            {
                return CanonicalEditionStatus.ManualReviewRequired;
            }
            if (item.LowerBound.HasValue && item.LowerBound.Value > effectiveDate)
                return CanonicalEditionStatus.FutureEdition;
            if (item.Candidate.Eligibility.Outcome == ScenarioEligibilityOutcome.Ineligible)
                return CanonicalEditionStatus.InactiveEdition;
            if (item.StopDate.HasValue && item.StopDate.Value < effectiveDate)
                return CanonicalEditionStatus.InactiveEdition;
            return CanonicalEditionStatus.ActiveEdition;
        }

        private static CanonicalEditionResolution CreateEditionResult(
            CandidateMetadata item,
            CanonicalEditionStatus status,
            IReadOnlyList<CanonicalReplacementRelationship> relationships,
            IReadOnlyList<string> familyRules,
            IReadOnlyList<string> familyReasons,
            DateOnly effectiveDate)
        {
            var related = relationships
                .Where(relationship =>
                    relationship.ReplacingIdentifier == item.Identifier
                    || relationship.ReplacedIdentifier == item.Identifier)
                .Select(relationship =>
                    relationship.ReplacingIdentifier == item.Identifier
                        ? relationship.ReplacedIdentifier
                        : relationship.ReplacingIdentifier)
                .Distinct(StringComparer.Ordinal)
                .OrderBy(value => value, StringComparer.Ordinal)
                .ToArray();
            var editionRules = new List<string>(item.Candidate.Eligibility.RuleIds);
            var editionReasons = new List<string>(item.Candidate.Eligibility.Reasons);
            var activatedReplacement = relationships.FirstOrDefault(relationship =>
                relationship.ReplacedIdentifier == item.Identifier
                && relationship.ReplacementStart <= effectiveDate
                && relationship.ReplacedStop <= effectiveDate);
            switch (status)
            {
                case CanonicalEditionStatus.ActiveEdition:
                    editionRules.Add("V1-ACTIVE-EDITION");
                    editionReasons.Add(
                        $"{item.Identifier} is Step 5 eligible and its interval includes "
                        + $"{effectiveDate:yyyy-MM-dd}.");
                    break;
                case CanonicalEditionStatus.FutureEdition:
                    editionRules.Add("V1-FUTURE-EDITION");
                    editionReasons.Add(
                        $"{item.Identifier} begins after {effectiveDate:yyyy-MM-dd}.");
                    break;
                case CanonicalEditionStatus.InactiveEdition when activatedReplacement != null:
                    editionRules.Add("V1-REPLACED-EDITION");
                    editionReasons.Add(
                        $"{item.Identifier} is replaced by "
                        + $"{activatedReplacement.ReplacingIdentifier} for "
                        + $"{effectiveDate:yyyy-MM-dd}.");
                    break;
                case CanonicalEditionStatus.InactiveEdition:
                    editionRules.Add("V1-INACTIVE-EDITION");
                    editionReasons.Add(
                        item.Candidate.Eligibility.Outcome
                        == ScenarioEligibilityOutcome.Ineligible
                            ? $"{item.Identifier} remains ineligible under Step 5."
                            : $"{item.Identifier} does not cover {effectiveDate:yyyy-MM-dd}.");
                    break;
                case CanonicalEditionStatus.Overlap:
                    editionRules.Add("V1-EDITION-OVERLAP");
                    editionReasons.Add(
                        $"{item.Identifier} overlaps another date-active eligible edition.");
                    break;
                case CanonicalEditionStatus.ManualReviewRequired:
                    editionRules.Add("V1-MANUAL-REVIEW");
                    editionReasons.Add(
                        $"{item.Identifier} cannot be resolved deterministically.");
                    break;
            }
            return new CanonicalEditionResolution
            {
                AggregationKey = item.Candidate.Aggregate.AggregationKey,
                FormNumber = item.Candidate.Aggregate.FormNumber,
                Edition = item.Candidate.Aggregate.Edition,
                NormalizedIdentifier = item.Identifier,
                Aggregate = item.Candidate.Aggregate,
                Status = status,
                ProvisionalRuntimeStatus = status == CanonicalEditionStatus.ActiveEdition
                    ? "YM"
                    : status is CanonicalEditionStatus.InactiveEdition
                        or CanonicalEditionStatus.FutureEdition
                        ? "N"
                        : null,
                Eligibility = item.Candidate.Eligibility,
                RelatedIdentifiers = related,
                RuleIds = editionRules
                    .Concat(familyRules)
                    .Distinct(StringComparer.Ordinal)
                    .ToArray(),
                Reasons = editionReasons
                    .Concat(familyReasons)
                    .Distinct(StringComparer.Ordinal)
                    .ToArray(),
                SourceEvidence = item.Candidate.Eligibility.SourceEvidence
            };
        }

        private static bool HasCycle(
            IReadOnlyList<CanonicalReplacementRelationship> relationships)
        {
            var outgoing = relationships
                .GroupBy(
                    relationship => relationship.ReplacingIdentifier,
                    StringComparer.Ordinal)
                .ToDictionary(
                    group => group.Key,
                    group => group.First().ReplacedIdentifier,
                    StringComparer.Ordinal);
            foreach (var start in outgoing.Keys)
            {
                var seen = new HashSet<string>(StringComparer.Ordinal);
                var current = start;
                while (outgoing.TryGetValue(current, out var next))
                {
                    if (!seen.Add(current))
                        return true;
                    current = next;
                }
            }
            return false;
        }

        private static bool HasUnusableDate(CanonicalFormSourceRow row) =>
            (!string.IsNullOrWhiteSpace(row.RawStartDate) && !row.ParsedStartDate.HasValue)
            || (!string.IsNullOrWhiteSpace(row.RawStopDate) && !row.ParsedStopDate.HasValue)
            || (!string.IsNullOrWhiteSpace(row.RawEffectiveDate) && !row.ParsedEffectiveDate.HasValue);

        private static string FamilyKey(CanonicalEditionCandidate candidate) =>
            string.Join(
                "|",
                candidate.Aggregate.FormNumber,
                candidate.Eligibility.ProfileId,
                candidate.Eligibility.ProfileVersion,
                candidate.Eligibility.State,
                candidate.Eligibility.Scenario,
                Normalize(candidate.Eligibility.Company),
                candidate.Eligibility.EffectiveDate.ToString("yyyy-MM-dd"),
                candidate.Eligibility.Transaction,
                ConditionSignature(candidate.Aggregate, candidate.Eligibility.State));

        private static string ConditionSignature(
            CanonicalFormAggregate aggregate,
            string state) =>
            string.Join(
                "\u001F",
                aggregate.Contributors
                    .Select(row => string.Join(
                        "\u001E",
                        Normalize(row.LegacySection),
                        string.Join(";", row.SourceDivisionProductHints
                            .Select(Normalize)
                            .OrderBy(value => value, StringComparer.Ordinal)),
                        Normalize(row.RawSelection),
                        Normalize(row.RawRules),
                        Normalize(row.RawPrintRules),
                        Normalize(row.RawMultipleSelectionCriteria),
                        Normalize(row.RawAdditionalSelectionCriteria),
                        Normalize(row.RawAdditionalRequirements),
                        Normalize(row.RawTransactionRules),
                        string.Join(";", row.StateMarkers
                            .Where(marker => marker.NormalizedState == state)
                            .Select(marker => Normalize(marker.RawHeader))
                            .OrderBy(value => value, StringComparer.Ordinal))))
                    .Distinct(StringComparer.Ordinal)
                    .OrderBy(value => value, StringComparer.Ordinal));

        private static string CandidateOrderKey(CanonicalEditionCandidate candidate) =>
            string.Join(
                "|",
                FamilyKey(candidate),
                candidate.Aggregate.FormNumber,
                candidate.Aggregate.Edition,
                candidate.Aggregate.AggregationKey);

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

        private sealed record CandidateMetadata(
            CanonicalEditionCandidate Candidate,
            string Identifier,
            DateOnly? LowerBound,
            DateOnly? StopDate,
            string[] ReplacementTargets,
            bool HasUnusableDate);
    }
}
