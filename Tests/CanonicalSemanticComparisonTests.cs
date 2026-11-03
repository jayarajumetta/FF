using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using NUnit.Framework;
using PnCTestAutomation.Tools.FormsBaselineGenerator;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    public class CanonicalSemanticComparisonTests
    {
        private static readonly DateOnly EffectiveDate = new(2027, 4, 3);

        [Test]
        public void UnchangedExpectation_ProducesNoSemanticFindings()
        {
            var baseline = Baseline(
                baseForms: new() { ["SF05010426"] = "all" });
            var projection = Projection(
                Qualified("SF05010426", CanonicalExpectedDestination.BASE, "AL"));

            var report = CanonicalSemanticComparisonService.Compare(baseline, projection);

            Assert.That(report.Findings, Is.Empty);
        }

        [Test]
        public void AddedAndRemovedForms_AreClassified()
        {
            var baseline = Baseline(
                baseForms: new()
                {
                    ["SF05010426"] = "all",
                    ["SF06010120"] = "all"
                });
            var projection = Projection(
                Qualified("SF05010426", CanonicalExpectedDestination.BASE, "AL"),
                Qualified("SF07010120", CanonicalExpectedDestination.BASE, "AL"));

            var report = CanonicalSemanticComparisonService.Compare(baseline, projection);

            Assert.Multiple(() =>
            {
                Assert.That(report.Findings.Select(finding => finding.Category),
                    Does.Contain(CanonicalSemanticChangeCategory.FormAdded));
                Assert.That(report.Findings.Select(finding => finding.Category),
                    Does.Contain(CanonicalSemanticChangeCategory.FormRemoved));
                Assert.That(report.Findings
                    .Where(finding =>
                        finding.Category == CanonicalSemanticChangeCategory.FormRemoved)
                    .All(finding =>
                        finding.Severity == CanonicalSemanticSeverity.ApprovalBlocking),
                    Is.True);
            });
        }

        [Test]
        public void StateAddedAndRemoved_AreClassified()
        {
            var baseline = Baseline(
                basicStates: new[] { "AL", "VA" },
                ceStates: new[] { "AL", "VA" },
                baseForms: new() { ["SF05010426"] = "all" });
            var projection = Projection(
                Qualified(
                    "SF05010426",
                    CanonicalExpectedDestination.BASE,
                    "AL",
                    "WV"));

            var report = CanonicalSemanticComparisonService.Compare(baseline, projection);

            Assert.Multiple(() =>
            {
                Assert.That(report.Findings.Any(finding =>
                    finding.Category == CanonicalSemanticChangeCategory.StateAdded
                    && finding.State == "WV"), Is.True);
                Assert.That(report.Findings.Any(finding =>
                    finding.Category == CanonicalSemanticChangeCategory.StateRemoved
                    && finding.State == "VA"), Is.True);
            });
        }

        [Test]
        public void EditionReplacement_IsSafelyCorrelatedByFamily()
        {
            var baseline = Baseline(
                baseForms: new() { ["SF05010120"] = "all" });
            var projection = Projection(
                Qualified("SF05010426", CanonicalExpectedDestination.BASE, "AL"));

            var report = CanonicalSemanticComparisonService.Compare(baseline, projection);

            var finding = report.Findings.Single(item =>
                item.Category == CanonicalSemanticChangeCategory.EditionReplaced
                && item.Scenario == "BASIC");
            Assert.Multiple(() =>
            {
                Assert.That(finding.Form, Is.EqualTo("SF05010120 -> SF05010426"));
                Assert.That(finding.Severity,
                    Is.EqualTo(CanonicalSemanticSeverity.ApprovalBlocking));
                Assert.That(finding.ApprovedEvidence, Is.Not.Empty);
                Assert.That(finding.CanonicalSourceEvidence, Is.Not.Empty);
            });
        }

        [Test]
        public void RoutingAndStatusChanges_AreClassified()
        {
            var baseline = Baseline(
                baseForms: new()
                {
                    ["SF05010426"] = new Dictionary<string, string>
                    {
                        ["AL"] = "YS"
                    }
                });
            var projection = Projection(
                Qualified(
                    "SF05010426",
                    CanonicalExpectedDestination.BASIC,
                    new[] { "AL" },
                    status: "YM"),
                Qualified(
                    "SF05010426",
                    CanonicalExpectedDestination.CE,
                    new[] { "AL" },
                    status: "YM"));

            var report = CanonicalSemanticComparisonService.Compare(baseline, projection);

            Assert.Multiple(() =>
            {
                Assert.That(report.Findings.Select(finding => finding.Category),
                    Does.Contain(CanonicalSemanticChangeCategory.RoutingChanged));
                Assert.That(report.Findings.Select(finding => finding.Category),
                    Does.Contain(CanonicalSemanticChangeCategory.StatusChanged));
            });
        }

        [Test]
        public void ExplicitRemoval_IsImplicitNEvidenceAndApprovalBlockingRemoval()
        {
            var baseline = Baseline(
                baseForms: new() { ["SF05010426"] = "all" });
            var projection = Projection(
                implicitN: new[]
                {
                    ImplicitN(
                        "SF05010426",
                        CanonicalExpectedDestination.BASIC,
                        "AL",
                        "V1-EXPLICIT-REMOVAL")
                });

            var report = CanonicalSemanticComparisonService.Compare(baseline, projection);

            var removed = report.Findings.First(finding =>
                finding.Category == CanonicalSemanticChangeCategory.FormRemoved
                && finding.Scenario == "BASIC");
            Assert.Multiple(() =>
            {
                Assert.That(removed.Severity,
                    Is.EqualTo(CanonicalSemanticSeverity.ApprovalBlocking));
                Assert.That(removed.NewMeaning, Is.EqualTo("Implicit N"));
                Assert.That(removed.CanonicalSourceEvidence.Single()
                    .StateMarkers.Single().RawValue, Is.EqualTo("X"));
            });
        }

        [Test]
        public void SourceConflict_ClassifiesEveryStructuredDifference()
        {
            var baseline = Baseline(
                baseForms: new() { ["SF05010426"] = "all" });
            var blocked = SourceConflict();
            var projection = Projection(blocked: new[] { blocked });

            var report = CanonicalSemanticComparisonService.Compare(baseline, projection);
            var categories = report.Findings.Select(finding => finding.Category).ToArray();

            Assert.Multiple(() =>
            {
                Assert.That(categories,
                    Does.Contain(CanonicalSemanticChangeCategory.SourceConflictIntroduced));
                Assert.That(categories,
                    Does.Contain(CanonicalSemanticChangeCategory.StatusChanged));
                Assert.That(categories,
                    Does.Contain(CanonicalSemanticChangeCategory.CompanyApplicabilityChanged));
                Assert.That(categories,
                    Does.Contain(CanonicalSemanticChangeCategory.EffectiveDateBehaviorChanged));
                Assert.That(categories,
                    Does.Contain(CanonicalSemanticChangeCategory.TransactionBehaviorChanged));
                Assert.That(categories,
                    Does.Contain(CanonicalSemanticChangeCategory.RuleOrCriteriaChanged));
                Assert.That(categories,
                    Does.Contain(CanonicalSemanticChangeCategory.LifecycleChanged));
                Assert.That(categories,
                    Does.Contain(CanonicalSemanticChangeCategory.SourceSelectionChanged));
                Assert.That(report.Findings.Single(finding =>
                    finding.Category == CanonicalSemanticChangeCategory.SourceConflictIntroduced)
                    .Severity, Is.EqualTo(CanonicalSemanticSeverity.ApprovalBlocking));
            });
        }

        [Test]
        public void UpstreamBlocked_IsFormerlyEligibleNowIndeterminate()
        {
            var baseline = Baseline(
                baseForms: new() { ["SF05010426"] = "all" });
            var blocked = UpstreamBlocked();
            var projection = Projection(blocked: new[] { blocked });

            var report = CanonicalSemanticComparisonService.Compare(baseline, projection);

            Assert.That(report.Findings.Any(finding =>
                finding.Category
                == CanonicalSemanticChangeCategory.FormerlyEligibleNowIndeterminate
                && finding.Severity == CanonicalSemanticSeverity.ApprovalBlocking), Is.True);
        }

        [Test]
        public void FutureWithdrawnAndExpiredEvidence_AreClassified()
        {
            var baseline = Baseline(
                baseForms: new()
                {
                    ["SF05010426"] = "all",
                    ["SF06010120"] = "all",
                    ["SF07010120"] = "all"
                });
            var projection = Projection(
                implicitN: new[]
                {
                    ImplicitN("SF05010426", CanonicalExpectedDestination.BASIC, "AL",
                        "V1-FUTURE-EDITION"),
                    ImplicitN("SF06010120", CanonicalExpectedDestination.BASIC, "AL",
                        "V1-WITHDRAWN"),
                    ImplicitN("SF07010120", CanonicalExpectedDestination.BASIC, "AL",
                        "V1-DATE-EXPIRED")
                });

            var report = CanonicalSemanticComparisonService.Compare(baseline, projection);

            Assert.Multiple(() =>
            {
                Assert.That(report.Findings.Select(finding => finding.Category),
                    Does.Contain(CanonicalSemanticChangeCategory.Future));
                Assert.That(report.Findings.Select(finding => finding.Category),
                    Does.Contain(CanonicalSemanticChangeCategory.Withdrawn));
                Assert.That(report.Findings.Select(finding => finding.Category),
                    Does.Contain(CanonicalSemanticChangeCategory.Expired));
            });
        }

        [Test]
        public void PriorProjection_DetectsSourceSelectionHashAndEligibilityRecovery()
        {
            var baseline = Baseline(
                baseForms: new()
                {
                    ["SF05010426"] = "all",
                    ["SF06010120"] = "all"
                });
            var prior = Projection(
                qualified: new[]
                {
                    Qualified(
                        "SF05010426",
                        CanonicalExpectedDestination.BASE,
                        new[] { "AL" },
                        sourceFamily: FormSourceFamily.Common,
                        hash: new string('A', 64)),
                    Qualified(
                        "SF06010120",
                        CanonicalExpectedDestination.BASE,
                        new[] { "AL" },
                        hash: new string('A', 64))
                },
                blocked: new[] { UpstreamBlocked("SF07010120") });
            var current = Projection(
                Qualified(
                    "SF05010426",
                    CanonicalExpectedDestination.BASE,
                    new[] { "AL" },
                    sourceFamily: FormSourceFamily.Sfp,
                    hash: new string('B', 64)),
                Qualified(
                    "SF06010120",
                    CanonicalExpectedDestination.BASE,
                    new[] { "AL" },
                    hash: new string('B', 64)),
                Qualified(
                    "SF07010120",
                    CanonicalExpectedDestination.BASIC,
                    "AL"));

            var report = CanonicalSemanticComparisonService.Compare(
                baseline,
                current,
                new CanonicalSemanticComparisonOptions
                {
                    PriorProjection = prior
                });

            Assert.Multiple(() =>
            {
                Assert.That(report.Findings.Select(finding => finding.Category),
                    Does.Contain(CanonicalSemanticChangeCategory.SourceSelectionChanged));
                Assert.That(report.Findings.Select(finding => finding.Category),
                    Does.Contain(CanonicalSemanticChangeCategory.SourceHashOnly));
                Assert.That(report.Findings.Select(finding => finding.Category),
                    Does.Contain(CanonicalSemanticChangeCategory.FormerlyIndeterminateNowEligible));
                Assert.That(report.Findings
                    .Where(finding =>
                        finding.Category == CanonicalSemanticChangeCategory.SourceHashOnly)
                    .All(finding =>
                        finding.Severity == CanonicalSemanticSeverity.Informational),
                    Is.True);
            });
        }

        [Test]
        public void SuspiciousMassChange_IsDeterministicallyApprovalBlocking()
        {
            var baseline = Baseline(
                baseForms: new() { ["SF05010426"] = "all" });
            var projection = Projection(
                Qualified("SF06010120", CanonicalExpectedDestination.BASE, "AL"),
                Qualified("SF07010120", CanonicalExpectedDestination.BASE, "AL"));

            var report = CanonicalSemanticComparisonService.Compare(
                baseline,
                projection,
                new CanonicalSemanticComparisonOptions
                {
                    SuspiciousChangeThreshold = 2
                });

            Assert.That(report.Findings.Any(finding =>
                finding.Category == CanonicalSemanticChangeCategory.SuspiciousMassChange
                && finding.Severity == CanonicalSemanticSeverity.ApprovalBlocking), Is.True);
        }

        [Test]
        public void JsonAndMarkdown_AreDeterministicAndContainCompleteProvenance()
        {
            var baseline = Baseline(
                baseForms: new() { ["SF05010120"] = "all" });
            var projection = Projection(
                Qualified("SF05010426", CanonicalExpectedDestination.BASE, "AL"));

            var first = CanonicalSemanticComparisonService.CreateReport(baseline, projection);
            var second = CanonicalSemanticComparisonService.CreateReport(baseline, projection);

            Assert.Multiple(() =>
            {
                Assert.That(second.Json, Is.EqualTo(first.Json));
                Assert.That(second.Markdown, Is.EqualTo(first.Markdown));
                Assert.That(first.Json, Does.Contain("\"schemaVersion\": \"1.0\""));
                Assert.That(first.Json, Does.Contain("\"comparisonRuleVersion\": \"1.0\""));
                Assert.That(first.Json, Does.Contain("\"canonicalSourceEvidence\""));
                Assert.That(first.Markdown,
                    Does.Contain("Approved runtime evidence")
                        .And.Contain("Canonical source")
                        .And.Contain("A2 Form Number=`SF05010426`"));
                Assert.DoesNotThrow(() => JsonDocument.Parse(first.Json));
            });
        }

        [Test]
        public void Comparison_DoesNotMutateApprovedBaselineContent()
        {
            var baseline = Baseline(
                baseForms: new() { ["SF05010426"] = "all" });
            var before = Convert.ToHexString(
                SHA256.HashData(Encoding.UTF8.GetBytes(baseline)));

            _ = CanonicalSemanticComparisonService.CreateReport(
                baseline,
                Projection(Qualified(
                    "SF05010426",
                    CanonicalExpectedDestination.BASE,
                    "AL")));

            var after = Convert.ToHexString(
                SHA256.HashData(Encoding.UTF8.GetBytes(baseline)));
            Assert.That(after, Is.EqualTo(before));
        }

        private static string Baseline(
            string[] basicStates = null,
            string[] ceStates = null,
            Dictionary<string, object> baseForms = null,
            Dictionary<string, object> basicForms = null,
            Dictionary<string, object> ceForms = null)
        {
            var model = new Dictionary<string, object>
            {
                ["STATES"] = new Dictionary<string, object>
                {
                    ["BASIC"] = basicStates ?? new[] { "AL" },
                    ["CE"] = ceStates ?? new[] { "AL" }
                },
                ["BASE"] = baseForms ?? new Dictionary<string, object>(),
                ["BASIC"] = basicForms ?? new Dictionary<string, object>(),
                ["CE"] = ceForms ?? new Dictionary<string, object>()
            };
            return JsonSerializer.Serialize(model);
        }

        private static CanonicalExpectedProjection Projection(
            params CanonicalExpectedRecord[] qualified) =>
            Projection(qualified, null, null);

        private static CanonicalExpectedProjection Projection(
            CanonicalExpectedRecord[] qualified = null,
            CanonicalImplicitNRecord[] implicitN = null,
            CanonicalBlockedProjectionRecord[] blocked = null) =>
            new()
            {
                RuleSetId = "CanonicalExpectedProjection",
                RuleVersion = "1.0",
                QualifiedRecords = qualified ?? Array.Empty<CanonicalExpectedRecord>(),
                ImplicitNEvidence = implicitN ?? Array.Empty<CanonicalImplicitNRecord>(),
                BlockedRecords = blocked ?? Array.Empty<CanonicalBlockedProjectionRecord>()
            };

        private static CanonicalExpectedRecord Qualified(
            string form,
            CanonicalExpectedDestination destination,
            params string[] states) =>
            Qualified(form, destination, states, "YM", FormSourceFamily.Sfp, new string('A', 64));

        private static CanonicalExpectedRecord Qualified(
            string form,
            CanonicalExpectedDestination destination,
            string[] states,
            string status = "YM",
            FormSourceFamily sourceFamily = FormSourceFamily.Sfp,
            string hash = null)
        {
            var row = SourceRow(form, states[0], "Y", sourceFamily, hash ?? new string('A', 64));
            return new CanonicalExpectedRecord
            {
                NormalizedIdentifier = form,
                FormNumber = form.Length > 4 ? form[..^4] : form,
                Edition = form.Length > 4 ? form[^4..] : "",
                Destination = destination,
                States = states,
                Company = "American National Property And Casualty Co.",
                EffectiveDate = EffectiveDate,
                Transaction = "New Business",
                ProvisionalRuntimeStatus = status,
                ProfileIds = destination == CanonicalExpectedDestination.BASE
                    ? new[] { "SFP-BASIC-NEW-BUSINESS", "SFP-CE-NEW-BUSINESS" }
                    : new[]
                    {
                        destination == CanonicalExpectedDestination.CE
                            ? "SFP-CE-NEW-BUSINESS"
                            : "SFP-BASIC-NEW-BUSINESS"
                    },
                SourceFamilies = new[] { sourceFamily },
                SourceRows = new[] { row },
                RuleIds = new[] { "V1-ELIGIBLE" },
                Reasons = new[] { "Fixture expected record." }
            };
        }

        private static CanonicalImplicitNRecord ImplicitN(
            string form,
            CanonicalExpectedDestination destination,
            string state,
            string ruleId)
        {
            var marker = ruleId.Contains("EXPLICIT", StringComparison.Ordinal) ? "X" : "Y";
            var row = SourceRow(form, state, marker, FormSourceFamily.Sfp, new string('A', 64));
            return new CanonicalImplicitNRecord
            {
                NormalizedIdentifier = form,
                ScenarioDestination = destination,
                States = new[] { state },
                Company = "American National Property And Casualty Co.",
                EffectiveDate = EffectiveDate,
                Transaction = "New Business",
                SourceFamilies = new[] { FormSourceFamily.Sfp },
                SourceRows = new[] { row },
                RuleIds = new[] { ruleId },
                Reasons = new[] { "Fixture implicit-N evidence." }
            };
        }

        private static CanonicalBlockedProjectionRecord SourceConflict()
        {
            var sfpRow = SourceRow(
                "SF05010426",
                "AL",
                "Y",
                FormSourceFamily.Sfp,
                new string('A', 64),
                rules: "Rule A",
                lifecycle: "Active",
                transaction: "New Business");
            var commonRow = SourceRow(
                "SF05010426",
                "AL",
                "X",
                FormSourceFamily.Common,
                new string('B', 64),
                rules: "Rule B",
                lifecycle: "Withdrawn",
                transaction: "Renewal");
            return new CanonicalBlockedProjectionRecord
            {
                Kind = CanonicalProjectionBlockKind.SourceConflict,
                NormalizedIdentifier = "SF05010426",
                ImpactedDestinations = new[] { CanonicalExpectedDestination.BASIC },
                States = new[] { "AL" },
                SourceFamilies = new[] { FormSourceFamily.Sfp, FormSourceFamily.Common },
                SourceRows = new[] { sfpRow, commonRow },
                RuleIds = new[] { "V1-SOURCE-CONFLICT" },
                Reasons = new[] { "Fixture source conflict." },
                ScenarioImpact = "BASIC/AL cannot emit.",
                Variants = new[]
                {
                    new CanonicalProjectionVariantEvidence(
                        "BASIC",
                        "SFP-BASIC-NEW-BUSINESS",
                        "AL",
                        "American National Property And Casualty Co.",
                        EffectiveDate,
                        "New Business",
                        CanonicalEditionStatus.ActiveEdition,
                        "YM",
                        "Condition A",
                        new[] { FormSourceFamily.Sfp },
                        new[] { sfpRow }),
                    new CanonicalProjectionVariantEvidence(
                        "BASIC",
                        "SFP-BASIC-NEW-BUSINESS",
                        "AL",
                        "Farm Family Casualty Insurance Company",
                        new DateOnly(2027, 4, 4),
                        "Renewal",
                        CanonicalEditionStatus.InactiveEdition,
                        "N",
                        "Condition B",
                        new[] { FormSourceFamily.Common },
                        new[] { commonRow })
                }
            };
        }

        private static CanonicalBlockedProjectionRecord UpstreamBlocked(
            string form = "SF05010426") =>
            new()
            {
                Kind = CanonicalProjectionBlockKind.UpstreamBlocked,
                NormalizedIdentifier = form,
                ImpactedDestinations = new[] { CanonicalExpectedDestination.BASIC },
                States = new[] { "AL" },
                SourceFamilies = new[] { FormSourceFamily.Sfp },
                SourceRows = new[]
                {
                    SourceRow(form, "AL", "Y", FormSourceFamily.Sfp, new string('A', 64))
                },
                RuleIds = new[] { "V1-UPSTREAM-BLOCKED" },
                Reasons = new[] { "Fixture blocked result." },
                ScenarioImpact = "BASIC/AL remains unresolved."
            };

        private static CanonicalFormSourceRow SourceRow(
            string form,
            string state,
            string marker,
            FormSourceFamily sourceFamily,
            string hash,
            string rules = "",
            string lifecycle = "Active",
            string transaction = "New Business")
        {
            var workbook = sourceFamily == FormSourceFamily.Sfp ? "sfp.xlsx" : "common.xlsx";
            return new CanonicalFormSourceRow
            {
                RawFormIdentifier = form,
                NormalizedFormIdentifier = form,
                ParsedFormNumber = form.Length > 4 ? form[..^4] : form,
                ParsedEdition = form.Length > 4 ? form[^4..] : "",
                TitleDescription = "Fixture form",
                SourceFamily = sourceFamily,
                Workbook = new WorkbookSourceInfo(workbook, $"C:\\sources\\{workbook}", hash),
                Worksheet = "Masterlist",
                SourceRowNumber = 2,
                LegacySection = "BASE",
                SourceDivisionProductHints = new[] { "SFP", "BASE" },
                RelevantCells = new[]
                {
                    new SourceCellFact("Form Number", "A2", form),
                    new SourceCellFact(state, "B2", marker),
                    new SourceCellFact("Selection", "C2", "Mandatory")
                },
                StateMarkers = new[]
                {
                    new CanonicalStateMarker(
                        state,
                        state,
                        "B2",
                        marker,
                        IsConfiguredState: true,
                        IsCompanySpecific: false,
                        IsLegacyEligible: true)
                },
                RawSelection = "Mandatory",
                RawRules = rules,
                RawStartDate = "2027-03-21",
                ParsedStartDate = new DateOnly(2027, 3, 21),
                RawTransactionRules = transaction,
                TransactionTokens = new[] { transaction },
                RawLifecycle = lifecycle,
                RawWithdrawn = lifecycle == "Withdrawn" ? "Yes" : "No"
            };
        }
    }
}
