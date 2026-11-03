using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using PnCTestAutomation.Tools.FormsBaselineGenerator;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    public class CanonicalEditionLifecycleResolverTests
    {
        private static readonly DateOnly EffectiveDate = new(2027, 4, 3);

        [Test]
        public void ConfirmedSf0501Replacement_Selects0426AndInactivates0120()
        {
            var result = Resolve(
                Candidate("0120", start: "", stop: "2027-03-21"),
                Candidate("0426", start: "2027-03-21", replacement: "SF 0501 0120"))
                .Single();

            Assert.Multiple(() =>
            {
                Assert.That(result.Status, Is.EqualTo(CanonicalEditionFamilyStatus.Resolved));
                Assert.That(result.ManualReviewRequired, Is.False);
                AssertEdition(result, "SF05010426", CanonicalEditionStatus.ActiveEdition, "YM");
                AssertEdition(result, "SF05010120", CanonicalEditionStatus.InactiveEdition, "N");
                Assert.That(
                    result.Editions.Single(edition =>
                        edition.NormalizedIdentifier == "SF05010120").RuleIds,
                    Does.Contain("V1-REPLACED-EDITION"));
                Assert.That(result.Relationships.Single(),
                    Has.Property(nameof(CanonicalReplacementRelationship.ReplacingIdentifier))
                        .EqualTo("SF05010426")
                        .And.Property(nameof(CanonicalReplacementRelationship.ReplacedIdentifier))
                        .EqualTo("SF05010120")
                        .And.Property(nameof(CanonicalReplacementRelationship.ReplacementStart))
                        .EqualTo(new DateOnly(2027, 3, 21))
                        .And.Property(nameof(CanonicalReplacementRelationship.ReplacedStop))
                        .EqualTo(new DateOnly(2027, 3, 21)));
                Assert.That(result.Relationships.Single().Evidence.Select(evidence =>
                    evidence.SourceRow), Is.EquivalentTo(new[] { 2, 2 }));
            });
        }

        [Test]
        public void FutureReplacement_LeavesCoveredOlderEditionActive()
        {
            var result = Resolve(
                Candidate("0120", start: "", stop: "2027-05-01"),
                Candidate("0527", start: "2027-05-01", replacement: "SF05010120"))
                .Single();

            Assert.Multiple(() =>
            {
                Assert.That(result.Status, Is.EqualTo(CanonicalEditionFamilyStatus.Resolved));
                AssertEdition(result, "SF05010120", CanonicalEditionStatus.ActiveEdition, "YM");
                AssertEdition(result, "SF05010527", CanonicalEditionStatus.FutureEdition, "N");
                Assert.That(
                    result.Editions.Single(edition =>
                        edition.NormalizedIdentifier == "SF05010527").RuleIds,
                    Does.Contain("V1-FUTURE-EDITION"));
            });
        }

        [Test]
        public void ExactBoundary_ActivatesReplacementAndInactivatesOldEdition()
        {
            var result = Resolve(
                Candidate("0120", start: "", stop: "2027-04-03"),
                Candidate("0426", start: "2027-04-03", replacement: "SF05010120"))
                .Single();

            Assert.Multiple(() =>
            {
                AssertEdition(result, "SF05010426", CanonicalEditionStatus.ActiveEdition, "YM");
                AssertEdition(result, "SF05010120", CanonicalEditionStatus.InactiveEdition, "N");
            });
        }

        [Test]
        public void OverlappingEligibleIntervals_RequireManualReview()
        {
            var result = Resolve(
                Candidate("0120", start: "2027-01-01", stop: "2027-06-01"),
                Candidate("0426", start: "2027-03-21", stop: "", replacement: "SF05010120"))
                .Single();

            Assert.Multiple(() =>
            {
                Assert.That(result.Status, Is.EqualTo(CanonicalEditionFamilyStatus.Overlap));
                Assert.That(result.ManualReviewRequired, Is.True);
                Assert.That(result.RuleIds, Does.Contain("V1-EDITION-OVERLAP"));
                Assert.That(result.Editions.Count(edition =>
                    edition.Status == CanonicalEditionStatus.Overlap), Is.EqualTo(2));
                Assert.That(result.Editions.All(edition =>
                    edition.ProvisionalRuntimeStatus == null), Is.True);
            });
        }

        [Test]
        public void GapBetweenReplacementIntervals_RequiresManualReview()
        {
            var result = Resolve(
                Candidate("0120", start: "", stop: "2027-03-21"),
                Candidate("0426", start: "2027-04-10", replacement: "SF05010120"))
                .Single();

            Assert.Multiple(() =>
            {
                Assert.That(result.Status, Is.EqualTo(CanonicalEditionFamilyStatus.Gap));
                Assert.That(result.ManualReviewRequired, Is.True);
                Assert.That(result.RuleIds, Does.Contain("V1-EDITION-GAP"));
                AssertEdition(result, "SF05010120", CanonicalEditionStatus.InactiveEdition, "N");
                AssertEdition(result, "SF05010426", CanonicalEditionStatus.FutureEdition, "N");
            });
        }

        [TestCase("TBD", "2027-03-21", "V1-DATE-UNUSABLE")]
        [TestCase("", "", "V1-REPLACEMENT-DATES-INCOMPLETE")]
        public void UnusableOrIncompleteReplacementDates_RequireManualReview(
            string replacementStart,
            string oldStop,
            string ruleId)
        {
            var result = Resolve(
                Candidate("0120", start: "", stop: oldStop),
                Candidate("0426", start: replacementStart, replacement: "SF05010120"))
                .Single();

            Assert.Multiple(() =>
            {
                Assert.That(result.Status,
                    Is.EqualTo(CanonicalEditionFamilyStatus.ManualReviewRequired));
                Assert.That(result.RuleIds, Does.Contain(ruleId));
            });
        }

        [Test]
        public void MissingReplacementTarget_RequiresManualReview()
        {
            var result = Resolve(
                Candidate("0426", start: "2027-03-21", replacement: "SF05010120"))
                .Single();

            Assert.Multiple(() =>
            {
                Assert.That(result.Status,
                    Is.EqualTo(CanonicalEditionFamilyStatus.ManualReviewRequired));
                Assert.That(result.RuleIds, Does.Contain("V1-REPLACEMENT-TARGET-MISSING"));
            });
        }

        [Test]
        public void MultipleReplacersForSameEdition_AreAConflictingChain()
        {
            var result = Resolve(
                Candidate("0120", stop: "2027-03-21"),
                Candidate("0426", start: "2027-03-21", replacement: "SF05010120"),
                Candidate("0527", start: "2027-03-22", replacement: "SF05010120"))
                .Single();

            Assert.Multiple(() =>
            {
                Assert.That(result.Status,
                    Is.EqualTo(CanonicalEditionFamilyStatus.ManualReviewRequired));
                Assert.That(result.RuleIds, Does.Contain("V1-REPLACEMENT-CHAIN-CONFLICT"));
            });
        }

        [Test]
        public void ReplacementCycle_RequiresManualReview()
        {
            var result = Resolve(
                Candidate(
                    "0120",
                    start: "2027-01-01",
                    stop: "2027-05-01",
                    replacement: "SF05010426"),
                Candidate(
                    "0426",
                    start: "2027-03-21",
                    stop: "2027-05-01",
                    replacement: "SF05010120"))
                .Single();

            Assert.Multiple(() =>
            {
                Assert.That(result.Status,
                    Is.EqualTo(CanonicalEditionFamilyStatus.ManualReviewRequired));
                Assert.That(result.RuleIds, Does.Contain("V1-REPLACEMENT-CYCLE"));
            });
        }

        [TestCase(
            "2027-04-03",
            ScenarioEligibilityOutcome.Ineligible,
            CanonicalEditionFamilyStatus.Resolved,
            CanonicalEditionStatus.InactiveEdition)]
        [TestCase(
            "",
            ScenarioEligibilityOutcome.ManualReviewRequired,
            CanonicalEditionFamilyStatus.ManualReviewRequired,
            CanonicalEditionStatus.ManualReviewRequired)]
        public void WithdrawnEligibility_IsPreserved(
            string stop,
            ScenarioEligibilityOutcome eligibilityOutcome,
            CanonicalEditionFamilyStatus familyStatus,
            CanonicalEditionStatus editionStatus)
        {
            var candidate = Candidate(
                "0120",
                stop: stop,
                lifecycle: "Withdrawn",
                withdrawn: "Yes");
            Assert.That(candidate.Eligibility.Outcome, Is.EqualTo(eligibilityOutcome));

            var result = Resolve(candidate).Single();

            Assert.Multiple(() =>
            {
                Assert.That(result.Status, Is.EqualTo(familyStatus));
                Assert.That(result.Editions.Single().Status, Is.EqualTo(editionStatus));
            });
        }

        [Test]
        public void Step5ManualReview_IsNeverPromotedToActive()
        {
            var candidate = Candidate(
                "0120",
                start: "2027-01-01",
                rules: "Attach when coverage applies");
            Assert.That(candidate.Eligibility.Outcome,
                Is.EqualTo(ScenarioEligibilityOutcome.ManualReviewRequired));

            var result = Resolve(candidate).Single();

            Assert.Multiple(() =>
            {
                Assert.That(result.Status,
                    Is.EqualTo(CanonicalEditionFamilyStatus.ManualReviewRequired));
                Assert.That(result.RuleIds, Does.Contain("V1-STEP5-UNRESOLVED"));
                Assert.That(result.Editions.Single().Status,
                    Is.EqualTo(CanonicalEditionStatus.ManualReviewRequired));
                Assert.That(result.Editions.Single().ProvisionalRuntimeStatus, Is.Null);
            });
        }

        [Test]
        public void StateCompanyAndScenarioDimensions_RemainSeparateFamilies()
        {
            var al = Candidate("0120", profile: Profile("AL"));
            var va = Candidate("0120", profile: Profile("VA"));
            var company = Candidate(
                "0120",
                profile: Profile("AL") with { Company = "Farm Family Casualty Insurance Company" });
            var ce = Candidate(
                "0120",
                product: "CE",
                profile: CeProfile("AL"));

            var results = Resolve(al, va, company, ce);

            Assert.Multiple(() =>
            {
                Assert.That(results, Has.Count.EqualTo(4));
                Assert.That(results.Select(result => result.FamilyKey), Is.Unique);
                Assert.That(results.Select(result => result.ProfileId),
                    Is.EquivalentTo(new[]
                    {
                        "SFP-BASIC-NEW-BUSINESS",
                        "SFP-BASIC-NEW-BUSINESS",
                        "SFP-BASIC-NEW-BUSINESS",
                        "SFP-CE-NEW-BUSINESS"
                    }));
            });
        }

        [Test]
        public void DifferentEligibilityConditions_RemainSeparateFamilies()
        {
            var unconditional = Candidate("0120");
            var conditional = Candidate(
                "0120",
                rules: "Attach when coverage applies",
                sourceRow: 9);

            var results = Resolve(unconditional, conditional);

            Assert.Multiple(() =>
            {
                Assert.That(results, Has.Count.EqualTo(2));
                Assert.That(results.Select(result => result.FamilyKey), Is.Unique);
                Assert.That(results.Select(result => result.Status),
                    Is.EquivalentTo(new[]
                    {
                        CanonicalEditionFamilyStatus.Resolved,
                        CanonicalEditionFamilyStatus.ManualReviewRequired
                    }));
            });
        }

        [Test]
        public void InputOrder_DoesNotChangeResolutionOrEvidence()
        {
            var oldEdition = Candidate("0120", stop: "2027-03-21", sourceRow: 3);
            var newEdition = Candidate(
                "0426",
                start: "2027-03-21",
                replacement: "SF05010120",
                sourceRow: 8);

            var forward = Resolve(oldEdition, newEdition);
            var reverse = Resolve(newEdition, oldEdition);

            Assert.Multiple(() =>
            {
                Assert.That(Snapshot(reverse), Is.EqualTo(Snapshot(forward)));
                Assert.That(forward.Single().RuleSetId, Is.EqualTo("CanonicalEditionLifecycle"));
                Assert.That(forward.Single().RuleVersion, Is.EqualTo("1.0"));
                Assert.That(
                    forward.Single().Editions.SelectMany(edition => edition.SourceEvidence)
                        .Select(evidence => evidence.SourceRow),
                    Is.EquivalentTo(new[] { 3, 8 }));
            });
        }

        [Test]
        public void RawN_RemainsResolvedInactiveEditionRatherThanManualReview()
        {
            var result = Resolve(Candidate("0426", marker: "N")).Single();
            var edition = result.Editions.Single();

            Assert.Multiple(() =>
            {
                Assert.That(result.Status, Is.EqualTo(CanonicalEditionFamilyStatus.Resolved));
                Assert.That(result.ManualReviewRequired, Is.False);
                Assert.That(edition.Status, Is.EqualTo(CanonicalEditionStatus.InactiveEdition));
                Assert.That(edition.ProvisionalRuntimeStatus, Is.EqualTo("N"));
                Assert.That(edition.RuleIds, Does.Contain("V1-RAW-N-NOT-APPLICABLE"));
            });
        }

        private static IReadOnlyList<CanonicalEditionFamilyResolution> Resolve(
            params CanonicalEditionCandidate[] candidates) =>
            CanonicalEditionLifecycleResolver.Resolve(candidates);

        private static CanonicalEditionCandidate Candidate(
            string edition,
            string start = "2027-01-01",
            string stop = "",
            string replacement = "",
            string lifecycle = "Active",
            string withdrawn = "No",
            string rules = "",
            string product = "BASIC",
            ScenarioProfile profile = null,
            int sourceRow = 2,
            string marker = "Y")
        {
            profile ??= Profile("AL");
            var rawIdentifier = $"SF0501{edition}";
            var row = new CanonicalFormSourceRow
            {
                RawFormIdentifier = rawIdentifier,
                NormalizedFormIdentifier = rawIdentifier,
                ParsedFormNumber = "SF0501",
                ParsedEdition = edition,
                TitleDescription = "Special Farm Package form",
                SourceFamily = FormSourceFamily.Sfp,
                Workbook = new WorkbookSourceInfo(
                    "sfp.xlsx",
                    "C:\\sources\\sfp.xlsx",
                    new string('B', 64)),
                Worksheet = "Masterlist",
                SourceRowNumber = sourceRow,
                LegacySection = product,
                SourceDivisionProductHints = new[] { "SFP", product },
                RelevantCells = new[]
                {
                    new SourceCellFact("Form Number", $"A{sourceRow}", rawIdentifier),
                    new SourceCellFact(profile.State, $"B{sourceRow}", marker),
                    new SourceCellFact("Selection", $"C{sourceRow}", "Mandatory"),
                    new SourceCellFact("Replacement", $"D{sourceRow}", replacement)
                },
                StateMarkers = new[]
                {
                    new CanonicalStateMarker(
                        profile.State,
                        profile.State,
                        $"B{sourceRow}",
                        marker,
                        IsConfiguredState: true,
                        IsCompanySpecific: false,
                        IsLegacyEligible: true)
                },
                RawSelection = "Mandatory",
                RawRules = rules,
                RawStartDate = start,
                ParsedStartDate = ParseDate(start),
                RawStopDate = stop,
                ParsedStopDate = ParseDate(stop),
                RawTransactionRules = "New Business",
                TransactionTokens = new[] { "New Business" },
                RawLifecycle = lifecycle,
                RawWithdrawn = withdrawn,
                RawReplacement = replacement
            };
            var aggregate = CanonicalFormAggregator.Aggregate(new[] { row }).Single();
            var interpretation = CanonicalApplicabilityInterpreter.Interpret(aggregate);
            var eligibility = CanonicalScenarioEligibilityEvaluator.Evaluate(
                aggregate,
                interpretation,
                profile);
            return new CanonicalEditionCandidate(aggregate, eligibility);
        }

        private static ScenarioProfile Profile(string state) =>
            ScenarioProfileLoader.LoadBasic(
                    Path.Combine(ProjectRoot(), "Features", "SFP", "SFP_BasicPolicy.feature"),
                    EffectiveDate)
                .Single(profile => profile.State == state);

        private static ScenarioProfile CeProfile(string state) =>
            ScenarioProfileLoader.LoadCountryEstate(
                    Path.Combine(ProjectRoot(), "Features", "SFP", "SFP_CE.feature"),
                    EffectiveDate)
                .Single(profile => profile.State == state);

        private static DateOnly? ParseDate(string value) =>
            DateOnly.TryParse(value, out var date) ? date : null;

        private static void AssertEdition(
            CanonicalEditionFamilyResolution result,
            string identifier,
            CanonicalEditionStatus status,
            string provisionalStatus)
        {
            var edition = result.Editions.Single(item =>
                item.NormalizedIdentifier == identifier);
            Assert.Multiple(() =>
            {
                Assert.That(edition.Status, Is.EqualTo(status));
                Assert.That(edition.ProvisionalRuntimeStatus, Is.EqualTo(provisionalStatus));
            });
        }

        private static string ProjectRoot()
        {
            var directory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
            while (directory != null
                   && !File.Exists(Path.Combine(directory.FullName, "TestAutomation.csproj")))
            {
                directory = directory.Parent;
            }
            return directory?.FullName
                ?? throw new InvalidOperationException("Cannot locate TestAutomation.csproj.");
        }

        private static string Snapshot(
            IEnumerable<CanonicalEditionFamilyResolution> resolutions) =>
            string.Join(
                "\n",
                resolutions.Select(result =>
                    $"{result.FamilyKey}|{result.Status}|"
                    + string.Join(",", result.RuleIds) + "|"
                    + string.Join(",", result.Relationships.Select(relationship =>
                        $"{relationship.ReplacingIdentifier}>{relationship.ReplacedIdentifier}:"
                        + $"{relationship.ReplacementStart:yyyy-MM-dd}:"
                        + $"{relationship.ReplacedStop:yyyy-MM-dd}")) + "|"
                    + string.Join(",", result.Editions.Select(edition =>
                        $"{edition.NormalizedIdentifier}:{edition.Status}:"
                        + $"{edition.ProvisionalRuntimeStatus}:"
                        + string.Join(
                            ";",
                            edition.SourceEvidence.Select(evidence =>
                                $"{evidence.SourceRow}:{evidence.MarkerCell}"))))));
    }
}
