using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using PnCTestAutomation.Models;
using PnCTestAutomation.Services;

namespace PnCTestAutomation.Tools.FormsBaselineGenerator
{
    public enum CanonicalSemanticChangeCategory
    {
        FormAdded,
        FormRemoved,
        StateAdded,
        StateRemoved,
        EditionAdded,
        EditionRemoved,
        EditionReplaced,
        RoutingChanged,
        StatusChanged,
        CompanyApplicabilityChanged,
        SourceSelectionChanged,
        LifecycleChanged,
        Withdrawn,
        Future,
        Expired,
        EffectiveDateBehaviorChanged,
        TransactionBehaviorChanged,
        RuleOrCriteriaChanged,
        SourceConflictIntroduced,
        FormerlyEligibleNowIndeterminate,
        FormerlyIndeterminateNowEligible,
        SourceHashOnly,
        SuspiciousMassChange
    }

    public enum CanonicalSemanticSeverity
    {
        Informational,
        ReviewRequired,
        PotentiallyBreaking,
        ApprovalBlocking
    }

    public sealed record ApprovedRuntimeExpectationEvidence(
        string BaselineName,
        string BaselineSha256,
        string Scenario,
        string State,
        string Form,
        string Status,
        CanonicalExpectedDestination Destination,
        string EvidenceKind);

    public sealed class CanonicalSemanticFinding
    {
        public string FindingId { get; init; } = "";
        public CanonicalSemanticChangeCategory Category { get; init; }
        public CanonicalSemanticSeverity Severity { get; init; }
        public string Scenario { get; init; } = "";
        public string State { get; init; } = "";
        public string Form { get; init; } = "";
        public string OldMeaning { get; init; } = "";
        public string NewMeaning { get; init; } = "";
        public IReadOnlyList<string> Reasons { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> RuleIds { get; init; } = Array.Empty<string>();
        public IReadOnlyList<ApprovedRuntimeExpectationEvidence> ApprovedEvidence { get; init; } =
            Array.Empty<ApprovedRuntimeExpectationEvidence>();
        public IReadOnlyList<CanonicalFormSourceRow> CanonicalSourceEvidence { get; init; } =
            Array.Empty<CanonicalFormSourceRow>();
    }

    public sealed record CanonicalSeverityCount(
        CanonicalSemanticSeverity Severity,
        int Count);

    public sealed class CanonicalSemanticComparisonReport
    {
        public string SchemaVersion { get; init; } = "";
        public string ComparisonRuleVersion { get; init; } = "";
        public string ApprovedBaselineSha256 { get; init; } = "";
        public string ProjectionSha256 { get; init; } = "";
        public int SuspiciousChangeThreshold { get; init; }
        public IReadOnlyList<CanonicalSeverityCount> SeverityCounts { get; init; } =
            Array.Empty<CanonicalSeverityCount>();
        public IReadOnlyList<CanonicalSemanticFinding> Findings { get; init; } =
            Array.Empty<CanonicalSemanticFinding>();
    }

    public sealed record CanonicalSemanticReportContent(
        CanonicalSemanticComparisonReport Report,
        string Json,
        string Markdown);

    public sealed class CanonicalSemanticComparisonOptions
    {
        public int SuspiciousChangeThreshold { get; init; } = 25;
        public CanonicalExpectedProjection PriorProjection { get; init; }
    }

    public static class CanonicalSemanticComparisonService
    {
        public const string SchemaVersion = "1.0";
        public const string ComparisonRuleVersion = "1.0";

        public static CanonicalSemanticReportContent CreateReport(
            string approvedJson,
            CanonicalExpectedProjection projection,
            CanonicalSemanticComparisonOptions options = null)
        {
            var report = Compare(approvedJson, projection, options);
            return new CanonicalSemanticReportContent(
                report,
                SerializeJson(report),
                RenderMarkdown(report));
        }

        public static CanonicalSemanticComparisonReport Compare(
            string approvedJson,
            CanonicalExpectedProjection projection,
            CanonicalSemanticComparisonOptions options = null)
        {
            options ??= new CanonicalSemanticComparisonOptions();
            if (options.SuspiciousChangeThreshold < 1)
                throw new ArgumentOutOfRangeException(
                    nameof(options.SuspiciousChangeThreshold));

            var baselineHash = Convert.ToHexString(
                SHA256.HashData(Encoding.UTF8.GetBytes(approvedJson)));
            var approved = LoadApproved(approvedJson, baselineHash);
            var canonical = ExpandQualified(projection.QualifiedRecords);
            var implicitN = ExpandImplicitN(projection.ImplicitNEvidence);
            var findings = new List<FindingDraft>();

            CompareStates(approved, projection, findings);
            CompareExpectations(approved, canonical, implicitN, findings);
            CompareRouting(approved, projection.QualifiedRecords, findings);
            AddBlockedFindings(approved, projection.BlockedRecords, findings);
            AddImplicitNBehaviorFindings(approved, implicitN, findings);
            AddPriorProjectionFindings(
                projection,
                options.PriorProjection,
                findings);

            var materialChangeCount = findings.Count(finding =>
                finding.Severity != CanonicalSemanticSeverity.Informational);
            if (materialChangeCount >= options.SuspiciousChangeThreshold)
            {
                findings.Add(new FindingDraft(
                    CanonicalSemanticChangeCategory.SuspiciousMassChange,
                    CanonicalSemanticSeverity.ApprovalBlocking,
                    "ALL",
                    "ALL",
                    "ALL",
                    $"{materialChangeCount} material changes",
                    "Approval blocked pending review",
                    new[]
                    {
                        $"Material change count {materialChangeCount} meets or exceeds "
                        + $"the deterministic threshold {options.SuspiciousChangeThreshold}."
                    },
                    new[] { "V1-SUSPICIOUS-MASS-CHANGE" },
                    Array.Empty<ApprovedRuntimeExpectationEvidence>(),
                    Array.Empty<CanonicalFormSourceRow>()));
            }

            var ordered = findings
                .OrderByDescending(finding => finding.Severity)
                .ThenBy(finding => finding.Category)
                .ThenBy(finding => finding.Scenario, StringComparer.Ordinal)
                .ThenBy(finding => finding.State, StringComparer.Ordinal)
                .ThenBy(finding => finding.Form, StringComparer.Ordinal)
                .ThenBy(finding => finding.OldMeaning, StringComparer.Ordinal)
                .ThenBy(finding => finding.NewMeaning, StringComparer.Ordinal)
                .Select((finding, index) => finding.ToFinding($"F{index + 1:D4}"))
                .ToArray();
            return new CanonicalSemanticComparisonReport
            {
                SchemaVersion = SchemaVersion,
                ComparisonRuleVersion = ComparisonRuleVersion,
                ApprovedBaselineSha256 = baselineHash,
                ProjectionSha256 = CanonicalProjectionFingerprint.Compute(projection),
                SuspiciousChangeThreshold = options.SuspiciousChangeThreshold,
                SeverityCounts = Enum.GetValues<CanonicalSemanticSeverity>()
                    .Select(severity => new CanonicalSeverityCount(
                        severity,
                        ordered.Count(finding => finding.Severity == severity)))
                    .ToArray(),
                Findings = ordered
            };
        }

        public static string SerializeJson(
            CanonicalSemanticComparisonReport report)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            options.Converters.Add(new JsonStringEnumConverter());
            return JsonSerializer.Serialize(report, options);
        }

        public static string RenderMarkdown(
            CanonicalSemanticComparisonReport report)
        {
            var builder = new StringBuilder();
            builder.AppendLine("# Forms Baseline Semantic Comparison");
            builder.AppendLine();
            builder.AppendLine($"- Schema: `{report.SchemaVersion}`");
            builder.AppendLine($"- Comparison rules: `{report.ComparisonRuleVersion}`");
            builder.AppendLine($"- Approved baseline SHA-256: `{report.ApprovedBaselineSha256}`");
            builder.AppendLine($"- Canonical projection SHA-256: `{report.ProjectionSha256}`");
            builder.AppendLine($"- Findings: **{report.Findings.Count}**");
            foreach (var count in report.SeverityCounts)
                builder.AppendLine($"- {count.Severity}: **{count.Count}**");
            builder.AppendLine();
            builder.AppendLine("| ID | Severity | Category | Scenario | State | Form | Old | New |");
            builder.AppendLine("|---|---|---|---|---|---|---|---|");
            foreach (var finding in report.Findings)
            {
                builder.AppendLine(
                    $"| {finding.FindingId} | {finding.Severity} | {finding.Category} | "
                    + $"{Escape(finding.Scenario)} | {Escape(finding.State)} | "
                    + $"{Escape(finding.Form)} | {Escape(finding.OldMeaning)} | "
                    + $"{Escape(finding.NewMeaning)} |");
            }

            foreach (var finding in report.Findings)
            {
                builder.AppendLine();
                builder.AppendLine($"## {finding.FindingId} — {finding.Category}");
                foreach (var reason in finding.Reasons)
                    builder.AppendLine($"- {reason}");
                foreach (var evidence in finding.ApprovedEvidence)
                {
                    builder.AppendLine(
                        $"- Approved runtime evidence: {evidence.Scenario}/{evidence.State}/"
                        + $"{evidence.Form} = {evidence.Status} ({evidence.Destination}); "
                        + $"baseline `{evidence.BaselineName}` `{evidence.BaselineSha256}`.");
                }
                foreach (var row in finding.CanonicalSourceEvidence)
                {
                    var cells = string.Join(
                        ", ",
                        row.RelevantCells.Select(cell =>
                            $"{cell.Address} {cell.Header}=`{cell.RawValue}`"));
                    builder.AppendLine(
                        $"- Canonical source: {row.SourceFamily}; "
                        + $"`{row.Workbook.Identity}` `{row.Workbook.Sha256}`; "
                        + $"{row.Worksheet} row {row.SourceRowNumber}; {cells}.");
                }
            }
            return builder.ToString().Replace("\r\n", "\n");
        }

        private static ApprovedSet LoadApproved(
            string approvedJson,
            string baselineHash)
        {
            using var document = JsonDocument.Parse(
                approvedJson,
                new JsonDocumentOptions
                {
                    CommentHandling = JsonCommentHandling.Skip
                });
            var statesObject = document.RootElement.GetProperty("STATES");
            var service = new FormsValidationService(new DuckCreekFormsConfig());
            var entries = new List<ApprovedEntry>();
            var states = new Dictionary<string, string[]>(StringComparer.Ordinal);
            foreach (var scenario in new[] { "BASIC", "CE" })
            {
                var scenarioStates = statesObject.GetProperty(scenario)
                    .EnumerateArray()
                    .Select(item => item.GetString())
                    .ToArray();
                states[scenario] = scenarioStates;
                foreach (var state in scenarioStates)
                {
                    foreach (var form in service.ParseSfpJson(
                                 approvedJson,
                                 state,
                                 scenario))
                    {
                        var destination = form.Type switch
                        {
                            "BASE" => CanonicalExpectedDestination.BASE,
                            "B" => CanonicalExpectedDestination.BASIC,
                            "C" => CanonicalExpectedDestination.CE,
                            _ => throw new InvalidOperationException(
                                $"Unexpected approved SFP type '{form.Type}'.")
                        };
                        entries.Add(new ApprovedEntry(
                            scenario,
                            state,
                            form.FormName,
                            form.ExpectedStatus,
                            destination,
                            new ApprovedRuntimeExpectationEvidence(
                                "SFP.json",
                                baselineHash,
                                scenario,
                                state,
                                form.FormName,
                                form.ExpectedStatus,
                                destination,
                                "ApprovedRuntimeBaseline")));
                    }
                }
            }
            return new ApprovedSet(states, entries);
        }

        private static void CompareStates(
            ApprovedSet approved,
            CanonicalExpectedProjection projection,
            ICollection<FindingDraft> findings)
        {
            foreach (var scenario in new[] { "BASIC", "CE" })
            {
                var oldStates = approved.States[scenario].ToHashSet(StringComparer.Ordinal);
                var newStates = ProjectionStates(projection, scenario);
                foreach (var state in newStates.Except(oldStates).OrderBy(value => value))
                {
                    findings.Add(Simple(
                        CanonicalSemanticChangeCategory.StateAdded,
                        CanonicalSemanticSeverity.ReviewRequired,
                        scenario,
                        state,
                        "ALL",
                        "State absent",
                        "State configured",
                        "Canonical profile contains a state not approved in SFP.json.",
                        "V1-STATE-ADDED"));
                }
                foreach (var state in oldStates.Except(newStates).OrderBy(value => value))
                {
                    findings.Add(Simple(
                        CanonicalSemanticChangeCategory.StateRemoved,
                        CanonicalSemanticSeverity.PotentiallyBreaking,
                        scenario,
                        state,
                        "ALL",
                        "State approved",
                        "State absent",
                        "Approved scenario state has no canonical projection evidence.",
                        "V1-STATE-REMOVED"));
                }
            }
        }

        private static void CompareExpectations(
            ApprovedSet approved,
            IReadOnlyDictionary<ExpectationKey, List<CanonicalExpectedRecord>> canonical,
            IReadOnlyDictionary<ExpectationKey, List<CanonicalImplicitNRecord>> implicitN,
            ICollection<FindingDraft> findings)
        {
            var oldQualified = approved.Entries
                .Where(entry => entry.Status != "N")
                .ToDictionary(entry => entry.Key, entry => entry);
            var newQualified = canonical
                .Where(pair => pair.Value.Count == 1)
                .ToDictionary(pair => pair.Key, pair => pair.Value[0]);
            foreach (var duplicate in canonical.Where(pair => pair.Value.Count > 1))
            {
                findings.Add(new FindingDraft(
                    CanonicalSemanticChangeCategory.RuleOrCriteriaChanged,
                    CanonicalSemanticSeverity.ApprovalBlocking,
                    duplicate.Key.Scenario,
                    duplicate.Key.State,
                    duplicate.Key.Form,
                    oldQualified.TryGetValue(duplicate.Key, out var prior)
                        ? prior.Status
                        : "No approved expectation",
                    "Multiple canonical meanings",
                    new[]
                    {
                        "Multiple canonical expected records map to one runtime scenario/state/form."
                    },
                    new[] { "V1-DUPLICATE-RUNTIME-IDENTITY" },
                    prior == null
                        ? Array.Empty<ApprovedRuntimeExpectationEvidence>()
                        : new[] { prior.Evidence },
                    OrderRows(duplicate.Value.SelectMany(record => record.SourceRows))));
            }

            var added = newQualified.Keys.Except(oldQualified.Keys).ToHashSet();
            var removed = oldQualified.Keys.Except(newQualified.Keys).ToHashSet();
            PairEditions(oldQualified, newQualified, added, removed, findings);

            foreach (var key in added.OrderBy(KeyOrder, StringComparer.Ordinal))
            {
                var record = newQualified[key];
                var category = HasOldFamily(oldQualified.Keys, key)
                    ? CanonicalSemanticChangeCategory.EditionAdded
                    : CanonicalSemanticChangeCategory.FormAdded;
                findings.Add(new FindingDraft(
                    category,
                    CanonicalSemanticSeverity.ReviewRequired,
                    key.Scenario,
                    key.State,
                    key.Form,
                    "No approved expectation",
                    $"{record.ProvisionalRuntimeStatus}/{record.Destination}",
                    new[] { "Canonical projection adds an expected form." },
                    new[] { "V1-FORM-ADDED" },
                    Array.Empty<ApprovedRuntimeExpectationEvidence>(),
                    record.SourceRows));
            }
            foreach (var key in removed.OrderBy(KeyOrder, StringComparer.Ordinal))
            {
                var prior = oldQualified[key];
                implicitN.TryGetValue(key, out var nEvidence);
                var category = HasNewFamily(newQualified.Keys, key)
                    ? CanonicalSemanticChangeCategory.EditionRemoved
                    : CanonicalSemanticChangeCategory.FormRemoved;
                findings.Add(new FindingDraft(
                    category,
                    CanonicalSemanticSeverity.ApprovalBlocking,
                    key.Scenario,
                    key.State,
                    key.Form,
                    $"{prior.Status}/{prior.Destination}",
                    nEvidence == null ? "No canonical expectation" : "Implicit N",
                    new[]
                    {
                        nEvidence == null
                            ? "Approved expected form is absent from the canonical qualified set."
                            : "Approved expected form is explicitly retained as implicit-N evidence."
                    },
                    new[] { "V1-FORM-REMOVED" },
                    new[] { prior.Evidence },
                    nEvidence == null
                        ? Array.Empty<CanonicalFormSourceRow>()
                        : OrderRows(nEvidence.SelectMany(record => record.SourceRows))));
            }

            foreach (var key in oldQualified.Keys.Intersect(newQualified.Keys)
                         .OrderBy(KeyOrder, StringComparer.Ordinal))
            {
                var prior = oldQualified[key];
                var current = newQualified[key];
                if (prior.Status == current.ProvisionalRuntimeStatus)
                    continue;
                var severity = current.ProvisionalRuntimeStatus == "N"
                    ? CanonicalSemanticSeverity.ApprovalBlocking
                    : CanonicalSemanticSeverity.PotentiallyBreaking;
                findings.Add(new FindingDraft(
                    CanonicalSemanticChangeCategory.StatusChanged,
                    severity,
                    key.Scenario,
                    key.State,
                    key.Form,
                    prior.Status,
                    current.ProvisionalRuntimeStatus,
                    new[] { "Runtime status changes for the same scenario/state/form." },
                    new[] { "V1-STATUS-CHANGED" },
                    new[] { prior.Evidence },
                    current.SourceRows));
            }
        }

        private static void PairEditions(
            IReadOnlyDictionary<ExpectationKey, ApprovedEntry> oldQualified,
            IReadOnlyDictionary<ExpectationKey, CanonicalExpectedRecord> newQualified,
            ISet<ExpectationKey> added,
            ISet<ExpectationKey> removed,
            ICollection<FindingDraft> findings)
        {
            var groups = added.Concat(removed)
                .Where(key => TryFormParts(key.Form, out _, out _))
                .GroupBy(key =>
                {
                    TryFormParts(key.Form, out var family, out _);
                    return $"{key.Scenario}|{key.State}|{family}";
                }, StringComparer.Ordinal);
            foreach (var group in groups)
            {
                var groupAdded = group.Where(added.Contains).ToArray();
                var groupRemoved = group.Where(removed.Contains).ToArray();
                if (groupAdded.Length != 1 || groupRemoved.Length != 1)
                    continue;
                var addedKey = groupAdded[0];
                var removedKey = groupRemoved[0];
                if (addedKey.Form == removedKey.Form)
                    continue;
                var current = newQualified[addedKey];
                var prior = oldQualified[removedKey];
                findings.Add(new FindingDraft(
                    CanonicalSemanticChangeCategory.EditionReplaced,
                    CanonicalSemanticSeverity.ApprovalBlocking,
                    addedKey.Scenario,
                    addedKey.State,
                    $"{removedKey.Form} -> {addedKey.Form}",
                    $"{prior.Status}/{prior.Destination}",
                    $"{current.ProvisionalRuntimeStatus}/{current.Destination}",
                    new[] { "One approved edition is replaced by one canonical edition in the same form family." },
                    new[] { "V1-EDITION-REPLACED" },
                    new[] { prior.Evidence },
                    current.SourceRows));
                added.Remove(addedKey);
                removed.Remove(removedKey);
            }
        }

        private static void CompareRouting(
            ApprovedSet approved,
            IReadOnlyList<CanonicalExpectedRecord> qualified,
            ICollection<FindingDraft> findings)
        {
            var oldRoutes = approved.Entries
                .Where(entry => entry.Status != "N")
                .GroupBy(entry => $"{entry.State}|{entry.Form}", StringComparer.Ordinal)
                .ToDictionary(
                    group => group.Key,
                    group => RouteMeaning(group.Select(entry => entry.Destination)),
                    StringComparer.Ordinal);
            var newRoutes = qualified
                .SelectMany(record => record.States.Select(state => (record, state)))
                .GroupBy(item => $"{item.state}|{item.record.NormalizedIdentifier}", StringComparer.Ordinal)
                .ToDictionary(
                    group => group.Key,
                    group => RouteMeaning(group.Select(item => item.record.Destination)),
                    StringComparer.Ordinal);
            foreach (var key in oldRoutes.Keys.Intersect(newRoutes.Keys)
                         .OrderBy(value => value, StringComparer.Ordinal))
            {
                if (oldRoutes[key] == newRoutes[key])
                    continue;
                var parts = key.Split('|');
                var sourceRows = qualified
                    .Where(record => record.NormalizedIdentifier == parts[1]
                        && record.States.Contains(parts[0]))
                    .SelectMany(record => record.SourceRows);
                findings.Add(new FindingDraft(
                    CanonicalSemanticChangeCategory.RoutingChanged,
                    CanonicalSemanticSeverity.PotentiallyBreaking,
                    "BASIC/CE",
                    parts[0],
                    parts[1],
                    oldRoutes[key],
                    newRoutes[key],
                    new[] { "BASE/BASIC/CE destination meaning changes." },
                    new[] { "V1-ROUTING-CHANGED" },
                    approved.Entries.Where(entry =>
                            entry.State == parts[0]
                            && entry.Form == parts[1]
                            && entry.Status != "N")
                        .Select(entry => entry.Evidence)
                        .ToArray(),
                    OrderRows(sourceRows)));
            }
        }

        private static void AddBlockedFindings(
            ApprovedSet approved,
            IEnumerable<CanonicalBlockedProjectionRecord> blockedRecords,
            ICollection<FindingDraft> findings)
        {
            foreach (var blocked in blockedRecords)
            {
                if (blocked.Kind == CanonicalProjectionBlockKind.SourceConflict)
                {
                    findings.Add(new FindingDraft(
                        CanonicalSemanticChangeCategory.SourceConflictIntroduced,
                        CanonicalSemanticSeverity.ApprovalBlocking,
                        string.Join("/", blocked.ImpactedDestinations),
                        string.Join(",", blocked.States),
                        blocked.NormalizedIdentifier,
                        ApprovedMeaning(approved, blocked),
                        "Source conflict / no complete expected record",
                        blocked.Reasons,
                        blocked.RuleIds,
                        ApprovedEvidence(approved, blocked),
                        blocked.SourceRows));
                    AddVariantDimensionFindings(blocked, findings);
                    continue;
                }

                findings.Add(new FindingDraft(
                    CanonicalSemanticChangeCategory.FormerlyEligibleNowIndeterminate,
                    CanonicalSemanticSeverity.ApprovalBlocking,
                    string.Join("/", blocked.ImpactedDestinations),
                    string.Join(",", blocked.States),
                    blocked.NormalizedIdentifier,
                    ApprovedMeaning(approved, blocked),
                    "Blocked/indeterminate",
                    blocked.Reasons,
                    blocked.RuleIds,
                    ApprovedEvidence(approved, blocked),
                    blocked.SourceRows));
            }
        }

        private static void AddVariantDimensionFindings(
            CanonicalBlockedProjectionRecord blocked,
            ICollection<FindingDraft> findings)
        {
            AddVariantFinding(
                blocked,
                CanonicalSemanticChangeCategory.StatusChanged,
                CanonicalSemanticSeverity.ApprovalBlocking,
                blocked.Variants.Select(variant => variant.ProvisionalRuntimeStatus),
                "V1-SOURCE-STATUS-CONFLICT",
                findings);
            AddVariantFinding(
                blocked,
                CanonicalSemanticChangeCategory.CompanyApplicabilityChanged,
                CanonicalSemanticSeverity.ReviewRequired,
                blocked.Variants.Select(variant => variant.Company),
                "V1-SOURCE-COMPANY-CONFLICT",
                findings);
            AddVariantFinding(
                blocked,
                CanonicalSemanticChangeCategory.EffectiveDateBehaviorChanged,
                CanonicalSemanticSeverity.PotentiallyBreaking,
                blocked.Variants.Select(variant => variant.EffectiveDate.ToString("yyyy-MM-dd")),
                "V1-SOURCE-DATE-CONFLICT",
                findings);
            AddVariantFinding(
                blocked,
                CanonicalSemanticChangeCategory.TransactionBehaviorChanged,
                CanonicalSemanticSeverity.PotentiallyBreaking,
                blocked.Variants.Select(variant => variant.Transaction),
                "V1-SOURCE-TRANSACTION-CONFLICT",
                findings);
            AddVariantFinding(
                blocked,
                CanonicalSemanticChangeCategory.RuleOrCriteriaChanged,
                CanonicalSemanticSeverity.ReviewRequired,
                blocked.Variants.Select(variant => variant.ConditionSignature),
                "V1-SOURCE-CONDITION-CONFLICT",
                findings);
            AddVariantFinding(
                blocked,
                CanonicalSemanticChangeCategory.LifecycleChanged,
                CanonicalSemanticSeverity.PotentiallyBreaking,
                blocked.Variants.Select(variant => variant.EditionStatus.ToString()),
                "V1-SOURCE-LIFECYCLE-CONFLICT",
                findings);
            AddVariantFinding(
                blocked,
                CanonicalSemanticChangeCategory.SourceSelectionChanged,
                CanonicalSemanticSeverity.ReviewRequired,
                blocked.Variants.Select(variant =>
                    string.Join(",", variant.SourceFamilies.OrderBy(value => value))),
                "V1-SOURCE-SELECTION-CONFLICT",
                findings);
        }

        private static void AddVariantFinding(
            CanonicalBlockedProjectionRecord blocked,
            CanonicalSemanticChangeCategory category,
            CanonicalSemanticSeverity severity,
            IEnumerable<string> values,
            string ruleId,
            ICollection<FindingDraft> findings)
        {
            var distinct = values.Distinct(StringComparer.Ordinal).ToArray();
            if (distinct.Length < 2)
                return;
            findings.Add(new FindingDraft(
                category,
                severity,
                string.Join("/", blocked.ImpactedDestinations),
                string.Join(",", blocked.States),
                blocked.NormalizedIdentifier,
                distinct[0],
                string.Join(" | ", distinct.Skip(1)),
                new[] { $"Conflicting source variants differ for {category}." },
                new[] { ruleId },
                Array.Empty<ApprovedRuntimeExpectationEvidence>(),
                blocked.SourceRows));
        }

        private static void AddImplicitNBehaviorFindings(
            ApprovedSet approved,
            IReadOnlyDictionary<ExpectationKey, List<CanonicalImplicitNRecord>> implicitN,
            ICollection<FindingDraft> findings)
        {
            foreach (var pair in implicitN.OrderBy(pair => KeyOrder(pair.Key), StringComparer.Ordinal))
            {
                var records = pair.Value;
                var rules = records.SelectMany(record => record.RuleIds).ToArray();
                var category = rules.Any(rule => rule.Contains("FUTURE", StringComparison.Ordinal))
                    ? CanonicalSemanticChangeCategory.Future
                    : rules.Any(rule => rule.Contains("WITHDRAW", StringComparison.Ordinal))
                        ? CanonicalSemanticChangeCategory.Withdrawn
                        : rules.Any(rule => rule.Contains("EXPIRED", StringComparison.Ordinal))
                            ? CanonicalSemanticChangeCategory.Expired
                            : rules.Any(rule => rule.Contains("REPLAC", StringComparison.Ordinal))
                                ? CanonicalSemanticChangeCategory.LifecycleChanged
                                : (CanonicalSemanticChangeCategory?)null;
                if (!category.HasValue)
                    continue;
                var severity = category == CanonicalSemanticChangeCategory.Withdrawn
                    ? CanonicalSemanticSeverity.ApprovalBlocking
                    : CanonicalSemanticSeverity.PotentiallyBreaking;
                findings.Add(new FindingDraft(
                    category.Value,
                    severity,
                    pair.Key.Scenario,
                    pair.Key.State,
                    pair.Key.Form,
                    approved.Entries.FirstOrDefault(entry => entry.Key == pair.Key)?.Status
                        ?? "No approved expectation",
                    "Implicit N",
                    records.SelectMany(record => record.Reasons)
                        .Distinct(StringComparer.Ordinal)
                        .ToArray(),
                    records.SelectMany(record => record.RuleIds)
                        .Distinct(StringComparer.Ordinal)
                        .ToArray(),
                    approved.Entries.Where(entry => entry.Key == pair.Key)
                        .Select(entry => entry.Evidence)
                        .ToArray(),
                    OrderRows(records.SelectMany(record => record.SourceRows))));
            }
        }

        private static void AddPriorProjectionFindings(
            CanonicalExpectedProjection current,
            CanonicalExpectedProjection prior,
            ICollection<FindingDraft> findings)
        {
            if (prior == null)
                return;
            var currentQualified = ExpandQualified(current.QualifiedRecords)
                .Where(pair => pair.Value.Count == 1)
                .ToDictionary(pair => pair.Key, pair => pair.Value[0]);
            var priorQualified = ExpandQualified(prior.QualifiedRecords)
                .Where(pair => pair.Value.Count == 1)
                .ToDictionary(pair => pair.Key, pair => pair.Value[0]);
            foreach (var key in currentQualified.Keys.Intersect(priorQualified.Keys)
                         .OrderBy(KeyOrder, StringComparer.Ordinal))
            {
                var now = currentQualified[key];
                var before = priorQualified[key];
                var priorFamilies = before.SourceFamilies.OrderBy(value => value).ToArray();
                var currentFamilies = now.SourceFamilies.OrderBy(value => value).ToArray();
                if (!priorFamilies.SequenceEqual(currentFamilies))
                {
                    findings.Add(new FindingDraft(
                        CanonicalSemanticChangeCategory.SourceSelectionChanged,
                        CanonicalSemanticSeverity.ReviewRequired,
                        key.Scenario,
                        key.State,
                        key.Form,
                        string.Join(",", priorFamilies),
                        string.Join(",", currentFamilies),
                        new[] { "Expectation meaning is unchanged but contributing source families changed." },
                        new[] { "V1-SOURCE-SELECTION-CHANGED" },
                        Array.Empty<ApprovedRuntimeExpectationEvidence>(),
                        now.SourceRows));
                    continue;
                }

                var priorHashes = SourceHashes(before.SourceRows);
                var currentHashes = SourceHashes(now.SourceRows);
                if (!priorHashes.SequenceEqual(currentHashes))
                {
                    findings.Add(new FindingDraft(
                        CanonicalSemanticChangeCategory.SourceHashOnly,
                        CanonicalSemanticSeverity.Informational,
                        key.Scenario,
                        key.State,
                        key.Form,
                        string.Join(",", priorHashes),
                        string.Join(",", currentHashes),
                        new[] { "Expectation meaning is unchanged; only source hash metadata changed." },
                        new[] { "V1-SOURCE-HASH-ONLY" },
                        Array.Empty<ApprovedRuntimeExpectationEvidence>(),
                        now.SourceRows));
                }
            }

            foreach (var blocked in prior.BlockedRecords)
            {
                foreach (var state in blocked.States)
                foreach (var destination in blocked.ImpactedDestinations)
                {
                    var scenario = destination == CanonicalExpectedDestination.CE ? "CE" : "BASIC";
                    var key = new ExpectationKey(scenario, state, blocked.NormalizedIdentifier);
                    if (!currentQualified.TryGetValue(key, out var record))
                        continue;
                    findings.Add(new FindingDraft(
                        CanonicalSemanticChangeCategory.FormerlyIndeterminateNowEligible,
                        CanonicalSemanticSeverity.ReviewRequired,
                        scenario,
                        state,
                        blocked.NormalizedIdentifier,
                        "Blocked/indeterminate",
                        $"{record.ProvisionalRuntimeStatus}/{record.Destination}",
                        new[] { "Previously blocked canonical evidence is now fully eligible." },
                        new[] { "V1-INDETERMINATE-NOW-ELIGIBLE" },
                        Array.Empty<ApprovedRuntimeExpectationEvidence>(),
                        record.SourceRows));
                }
            }
        }

        private static Dictionary<ExpectationKey, List<CanonicalExpectedRecord>> ExpandQualified(
            IEnumerable<CanonicalExpectedRecord> records)
        {
            var result = new Dictionary<ExpectationKey, List<CanonicalExpectedRecord>>();
            foreach (var record in records)
            foreach (var state in record.States)
            foreach (var scenario in Scenarios(record.Destination))
            {
                var key = new ExpectationKey(scenario, state, record.NormalizedIdentifier);
                result.GetOrAdd(key).Add(record);
            }
            return result;
        }

        private static Dictionary<ExpectationKey, List<CanonicalImplicitNRecord>> ExpandImplicitN(
            IEnumerable<CanonicalImplicitNRecord> records)
        {
            var result = new Dictionary<ExpectationKey, List<CanonicalImplicitNRecord>>();
            foreach (var record in records)
            foreach (var state in record.States)
            {
                var scenario = record.ScenarioDestination == CanonicalExpectedDestination.CE
                    ? "CE"
                    : "BASIC";
                var key = new ExpectationKey(scenario, state, record.NormalizedIdentifier);
                result.GetOrAdd(key).Add(record);
            }
            return result;
        }

        private static HashSet<string> ProjectionStates(
            CanonicalExpectedProjection projection,
            string scenario)
        {
            var destination = scenario == "CE"
                ? CanonicalExpectedDestination.CE
                : CanonicalExpectedDestination.BASIC;
            var states = projection.QualifiedRecords
                .Where(record => record.Destination == CanonicalExpectedDestination.BASE
                    || record.Destination == destination)
                .SelectMany(record => record.States)
                .Concat(projection.ImplicitNEvidence
                    .Where(record => record.ScenarioDestination == destination)
                    .SelectMany(record => record.States))
                .Concat(projection.BlockedRecords
                    .Where(record => record.ImpactedDestinations.Contains(destination))
                    .SelectMany(record => record.States))
                .ToHashSet(StringComparer.Ordinal);
            return states;
        }

        private static IEnumerable<string> Scenarios(
            CanonicalExpectedDestination destination) =>
            destination switch
            {
                CanonicalExpectedDestination.BASE => new[] { "BASIC", "CE" },
                CanonicalExpectedDestination.BASIC => new[] { "BASIC" },
                CanonicalExpectedDestination.CE => new[] { "CE" },
                _ => Array.Empty<string>()
            };

        private static string ApprovedMeaning(
            ApprovedSet approved,
            CanonicalBlockedProjectionRecord blocked)
        {
            var meanings = ApprovedEvidence(approved, blocked)
                .Select(evidence => $"{evidence.Scenario}/{evidence.State}="
                    + $"{evidence.Status}/{evidence.Destination}")
                .Distinct(StringComparer.Ordinal)
                .ToArray();
            return meanings.Length == 0 ? "No approved expectation" : string.Join(" | ", meanings);
        }

        private static ApprovedRuntimeExpectationEvidence[] ApprovedEvidence(
            ApprovedSet approved,
            CanonicalBlockedProjectionRecord blocked) =>
            approved.Entries.Where(entry =>
                    blocked.States.Contains(entry.State)
                    && blocked.NormalizedIdentifier.Split(',')
                        .Contains(entry.Form, StringComparer.Ordinal)
                    && blocked.ImpactedDestinations.Any(destination =>
                        Scenarios(destination).Contains(entry.Scenario)))
                .Select(entry => entry.Evidence)
                .ToArray();

        private static bool HasOldFamily(
            IEnumerable<ExpectationKey> keys,
            ExpectationKey target)
        {
            if (!TryFormParts(target.Form, out var family, out _))
                return false;
            return keys.Any(key =>
                key.Scenario == target.Scenario
                && key.State == target.State
                && TryFormParts(key.Form, out var candidateFamily, out _)
                && candidateFamily == family);
        }

        private static bool HasNewFamily(
            IEnumerable<ExpectationKey> keys,
            ExpectationKey target) =>
            HasOldFamily(keys, target);

        private static bool TryFormParts(
            string form,
            out string family,
            out string edition)
        {
            family = "";
            edition = "";
            if (string.IsNullOrWhiteSpace(form) || form.Length <= 4)
                return false;
            edition = form[^4..];
            if (!edition.All(char.IsDigit))
                return false;
            family = form[..^4];
            return family.Length > 0;
        }

        private static string RouteMeaning(
            IEnumerable<CanonicalExpectedDestination> destinations)
        {
            var values = destinations.Distinct().OrderBy(value => value).ToArray();
            if (values.Contains(CanonicalExpectedDestination.BASE))
                return "BASE";
            return string.Join("+", values);
        }

        private static string[] SourceHashes(
            IEnumerable<CanonicalFormSourceRow> rows) =>
            rows.Select(row => $"{row.SourceFamily}:{row.Workbook.Identity}:{row.Workbook.Sha256}")
                .Distinct(StringComparer.Ordinal)
                .OrderBy(value => value, StringComparer.Ordinal)
                .ToArray();

        private static CanonicalFormSourceRow[] OrderRows(
            IEnumerable<CanonicalFormSourceRow> rows) =>
            rows.OrderBy(row => row.SourceFamily)
                .ThenBy(row => row.Workbook.Path, StringComparer.Ordinal)
                .ThenBy(row => row.Worksheet, StringComparer.Ordinal)
                .ThenBy(row => row.SourceRowNumber)
                .ThenBy(row => row.NormalizedFormIdentifier, StringComparer.Ordinal)
                .ToArray();

        private static string KeyOrder(ExpectationKey key) =>
            $"{key.Scenario}|{key.State}|{key.Form}";

        private static FindingDraft Simple(
            CanonicalSemanticChangeCategory category,
            CanonicalSemanticSeverity severity,
            string scenario,
            string state,
            string form,
            string oldMeaning,
            string newMeaning,
            string reason,
            string ruleId) =>
            new(
                category,
                severity,
                scenario,
                state,
                form,
                oldMeaning,
                newMeaning,
                new[] { reason },
                new[] { ruleId },
                Array.Empty<ApprovedRuntimeExpectationEvidence>(),
                Array.Empty<CanonicalFormSourceRow>());

        private static string Escape(string value) =>
            (value ?? "").Replace("|", "\\|").Replace("\r", " ").Replace("\n", " ");

        private sealed record ExpectationKey(
            string Scenario,
            string State,
            string Form);

        private sealed record ApprovedEntry(
            string Scenario,
            string State,
            string Form,
            string Status,
            CanonicalExpectedDestination Destination,
            ApprovedRuntimeExpectationEvidence Evidence)
        {
            public ExpectationKey Key => new(Scenario, State, Form);
        }

        private sealed record ApprovedSet(
            IReadOnlyDictionary<string, string[]> States,
            IReadOnlyList<ApprovedEntry> Entries);

        private sealed record FindingDraft(
            CanonicalSemanticChangeCategory Category,
            CanonicalSemanticSeverity Severity,
            string Scenario,
            string State,
            string Form,
            string OldMeaning,
            string NewMeaning,
            IReadOnlyList<string> Reasons,
            IReadOnlyList<string> RuleIds,
            IReadOnlyList<ApprovedRuntimeExpectationEvidence> ApprovedEvidence,
            IReadOnlyList<CanonicalFormSourceRow> CanonicalSourceEvidence)
        {
            public CanonicalSemanticFinding ToFinding(string findingId) =>
                new()
                {
                    FindingId = findingId,
                    Category = Category,
                    Severity = Severity,
                    Scenario = Scenario,
                    State = State,
                    Form = Form,
                    OldMeaning = OldMeaning,
                    NewMeaning = NewMeaning,
                    Reasons = Reasons.Distinct(StringComparer.Ordinal).ToArray(),
                    RuleIds = RuleIds.Distinct(StringComparer.Ordinal).ToArray(),
                    ApprovedEvidence = ApprovedEvidence,
                    CanonicalSourceEvidence = OrderRows(CanonicalSourceEvidence)
                };
        }

        private static List<TValue> GetOrAdd<TKey, TValue>(
            this IDictionary<TKey, List<TValue>> dictionary,
            TKey key)
        {
            if (!dictionary.TryGetValue(key, out var values))
            {
                values = new List<TValue>();
                dictionary.Add(key, values);
            }
            return values;
        }
    }
}
