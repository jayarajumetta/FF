using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PnCTestAutomation.Tools.FormsBaselineGenerator;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    public class CanonicalApplicabilityInterpreterTests
    {
        [Test]
        public void ApplicableYAndMandatory_MapsProvisionallyToYm()
        {
            var result = Interpret("Y", "Mandatory").MarkerResults.Single();

            Assert.Multiple(() =>
            {
                Assert.That(result.Applicability, Is.EqualTo(CanonicalApplicability.Applicable));
                Assert.That(result.ProvisionalRuntimeStatus, Is.EqualTo("YM"));
                Assert.That(result.Outcome, Is.EqualTo(CanonicalInterpretationOutcome.Mapped));
                Assert.That(result.ManualReviewRequired, Is.False);
                Assert.That(result.RuleId, Is.EqualTo("V1-Y-MANDATORY"));
            });
        }

        [Test]
        public void ApplicableYAndBlankSelection_IsIndeterminateAndRequiresReview()
        {
            var result = Interpret("Y", "").MarkerResults.Single();

            Assert.Multiple(() =>
            {
                Assert.That(result.Applicability, Is.EqualTo(CanonicalApplicability.Applicable));
                Assert.That(result.ProvisionalRuntimeStatus, Is.Null);
                Assert.That(result.Outcome, Is.EqualTo(CanonicalInterpretationOutcome.Indeterminate));
                Assert.That(result.ManualReviewRequired, Is.True);
            });
        }

        [Test]
        public void UnavailableSelection_IsManualReviewAndNeverMapsToN()
        {
            var result = Interpret("X", "Unavailable").MarkerResults.Single();

            Assert.Multiple(() =>
            {
                Assert.That(result.Applicability, Is.EqualTo(CanonicalApplicability.ExplicitRemoval));
                Assert.That(result.ProvisionalRuntimeStatus, Is.Null);
                Assert.That(result.Outcome,
                    Is.EqualTo(CanonicalInterpretationOutcome.ManualReviewRequired));
                Assert.That(result.RuleId, Is.EqualTo("V1-SELECTION-UNAVAILABLE"));
            });
        }

        [TestCase("X", CanonicalApplicability.ExplicitRemoval, "V1-EXPLICIT-REMOVAL")]
        [TestCase("", CanonicalApplicability.NotApplicable, "V1-NOT-APPLICABLE")]
        [TestCase("N", CanonicalApplicability.NotApplicable, "V1-RAW-N-NOT-APPLICABLE")]
        public void NonApplicableMarker_MapsProvisionallyToNButKeepsSourceReason(
            string marker,
            CanonicalApplicability applicability,
            string ruleId)
        {
            var result = Interpret(marker, "Mandatory").MarkerResults.Single();

            Assert.Multiple(() =>
            {
                Assert.That(result.RawMarker, Is.EqualTo(marker));
                Assert.That(result.Applicability, Is.EqualTo(applicability));
                Assert.That(result.ProvisionalRuntimeStatus, Is.EqualTo("N"));
                Assert.That(result.RuleId, Is.EqualTo(ruleId));
            });
        }

        [Test]
        public void RawNBlankAndX_HaveDistinctRulesReasonsAndRawEvidence()
        {
            var rawN = Interpret("N", "Mandatory").MarkerResults.Single();
            var blank = Interpret("", "Mandatory").MarkerResults.Single();
            var removal = Interpret("X", "Mandatory").MarkerResults.Single();

            Assert.Multiple(() =>
            {
                Assert.That(
                    new[] { rawN.RuleId, blank.RuleId, removal.RuleId },
                    Is.Unique);
                Assert.That(rawN.Reasons.Single(), Does.Contain("Raw N"));
                Assert.That(blank.Reasons.Single(), Does.Contain("Raw blank"));
                Assert.That(removal.Reasons.Single(), Does.Contain("Raw X"));
                Assert.That(rawN.RawMarker, Is.EqualTo("N"));
                Assert.That(blank.RawMarker, Is.Empty);
                Assert.That(removal.RawMarker, Is.EqualTo("X"));
                Assert.That(rawN.Evidence.Single().MarkerCell, Is.EqualTo("B1"));
            });
        }

        [TestCase("?", "Mandatory", "V1-UNKNOWN-MARKER")]
        [TestCase("Y", "Optional", "V1-UNSUPPORTED-SELECTION")]
        [TestCase("X", "Optional", "V1-UNSUPPORTED-SELECTION")]
        public void UnknownMarkerOrSelection_RequiresManualReview(
            string marker,
            string selection,
            string ruleId)
        {
            var result = Interpret(marker, selection).MarkerResults.Single();

            Assert.Multiple(() =>
            {
                Assert.That(result.ProvisionalRuntimeStatus, Is.Null);
                Assert.That(result.Outcome,
                    Is.EqualTo(CanonicalInterpretationOutcome.ManualReviewRequired));
                Assert.That(result.ManualReviewRequired, Is.True);
                Assert.That(result.RuleId, Is.EqualTo(ruleId));
            });
        }

        [Test]
        public void AggregationConflict_IsBlockedWithoutMarkerInterpretation()
        {
            var aggregate = Aggregate(
                Row("Y", "Mandatory", sourceRow: 1),
                Row("Y", "Optional", sourceRow: 2));

            var interpretations = aggregate
                .Select(CanonicalApplicabilityInterpreter.Interpret)
                .ToArray();

            Assert.Multiple(() =>
            {
                Assert.That(aggregate, Has.Count.EqualTo(2));
                Assert.That(interpretations.All(interpretation => interpretation.IsBlocked), Is.True);
                Assert.That(interpretations.All(interpretation =>
                    interpretation.MarkerResults.Count == 0), Is.True);
                Assert.That(interpretations.All(interpretation =>
                    interpretation.BlockReasons.Single().StartsWith("AggregationConflict:")), Is.True);
            });
        }

        [Test]
        public void MultipleProvenanceMarkers_ArePreservedWithEvidence()
        {
            var aggregate = Aggregate(
                Row("Y", "Mandatory", sourceRow: 3, state: "VA"),
                Row("Y", "Mandatory", sourceRow: 7, state: "WV")).Single();

            var interpretation = CanonicalApplicabilityInterpreter.Interpret(aggregate);

            Assert.Multiple(() =>
            {
                Assert.That(interpretation.MarkerResults, Has.Count.EqualTo(2));
                Assert.That(interpretation.MarkerResults.Select(result =>
                    result.Evidence.Single().SourceRow), Is.EqualTo(new[] { 3, 7 }));
                Assert.That(interpretation.MarkerResults.Select(result =>
                    result.Evidence.Single().MarkerCell), Is.EqualTo(new[] { "B3", "B7" }));
                Assert.That(interpretation.MarkerResults.All(result =>
                    result.Evidence.Single().SelectionCell is "C3" or "C7"), Is.True);
            });
        }

        [Test]
        public void RuleVersionAndResultOrder_AreDeterministic()
        {
            var aggregate = Aggregate(
                Row("", "Mandatory", sourceRow: 9, state: "WV"),
                Row("Y", "Mandatory", sourceRow: 2, state: "VA")).Single();

            var first = CanonicalApplicabilityInterpreter.Interpret(aggregate);
            var second = CanonicalApplicabilityInterpreter.Interpret(aggregate);

            Assert.Multiple(() =>
            {
                Assert.That(first.RuleSetId, Is.EqualTo("FormsApplicabilitySelection"));
                Assert.That(first.RuleVersion, Is.EqualTo("1.0"));
                Assert.That(Snapshot(second), Is.EqualTo(Snapshot(first)));
                Assert.That(first.MarkerResults.Select(result => result.Evidence.Single().SourceRow),
                    Is.EqualTo(new[] { 2, 9 }));
            });
        }

        private static CanonicalAggregateInterpretation Interpret(
            string marker,
            string selection) =>
            CanonicalApplicabilityInterpreter.Interpret(
                Aggregate(Row(marker, selection, sourceRow: 1)).Single());

        private static IReadOnlyList<CanonicalFormAggregate> Aggregate(
            params CanonicalFormSourceRow[] rows) =>
            CanonicalFormAggregator.Aggregate(rows);

        private static CanonicalFormSourceRow Row(
            string marker,
            string selection,
            int sourceRow,
            string state = "AL")
        {
            var markerCell = $"B{sourceRow}";
            var selectionCell = $"C{sourceRow}";
            return new CanonicalFormSourceRow
            {
                RawFormIdentifier = "SF02270801",
                NormalizedFormIdentifier = "SF02270801",
                ParsedFormNumber = "SF0227",
                ParsedEdition = "0801",
                TitleDescription = "Form title",
                SourceFamily = FormSourceFamily.Sfp,
                Workbook = new WorkbookSourceInfo(
                    "sfp.xlsx",
                    "C:\\sources\\sfp.xlsx",
                    new string('A', 64)),
                Worksheet = "Masterlist",
                SourceRowNumber = sourceRow,
                LegacySection = "BASE",
                SourceDivisionProductHints = new[] { "SFP", "BASE" },
                RelevantCells = new[]
                {
                    new SourceCellFact("Form Number", $"A{sourceRow}", "SF02270801"),
                    new SourceCellFact(state, markerCell, marker),
                    new SourceCellFact("Selection", selectionCell, selection)
                },
                StateMarkers = new[]
                {
                    new CanonicalStateMarker(
                        state,
                        state,
                        markerCell,
                        marker,
                        IsConfiguredState: true,
                        IsCompanySpecific: false,
                        IsLegacyEligible: true)
                },
                RawSelection = selection,
                RawRules = "Same rule",
                RawPrintRules = "Print rule",
                RawMultipleSelectionCriteria = "Multiple criteria",
                RawAdditionalSelectionCriteria = "Additional criteria",
                RawAdditionalRequirements = "Requirement",
                RawNotes = "Note",
                RawStartDate = "3/21/2027",
                ParsedStartDate = new DateOnly(2027, 3, 21),
                RawEffectiveDate = "4/3/2027",
                ParsedEffectiveDate = new DateOnly(2027, 4, 3),
                RawTransactionRules = "New Business",
                TransactionTokens = new[] { "New Business" },
                RawLifecycle = "Active",
                RawWithdrawn = "No"
            };
        }

        private static string Snapshot(CanonicalAggregateInterpretation interpretation) =>
            string.Join(
                "|",
                interpretation.RuleSetId,
                interpretation.RuleVersion,
                interpretation.IsBlocked,
                string.Join(
                    ";",
                    interpretation.MarkerResults.Select(result =>
                        $"{result.RawMarker}:{result.RawSelection}:{result.Applicability}:"
                        + $"{result.ProvisionalRuntimeStatus}:{result.Outcome}:{result.RuleId}:"
                        + $"{result.Evidence.Single().SourceRow}")));
    }
}
