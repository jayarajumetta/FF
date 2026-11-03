using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PnCTestAutomation.Tools.FormsBaselineGenerator;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    public class CanonicalFormAggregationTests
    {
        [Test]
        public void CompatibleDuplicate_UnionsLaterVaContributionAndPreservesProvenance()
        {
            var first = Row(
                "SF0227",
                "0801",
                sourceRow: 10,
                markers: new[] { Marker("AL", "Y", "B10") });
            var later = Row(
                "SF0227",
                "0801",
                sourceRow: 25,
                markers: new[] { Marker("VA", "Y", "C25") });

            var aggregate = CanonicalFormAggregator.Aggregate(new[] { later, first }).Single();

            Assert.Multiple(() =>
            {
                Assert.That(aggregate.AggregationKey, Is.EqualTo("SF0227|0801"));
                Assert.That(aggregate.Contributors.Select(row => row.SourceRowNumber),
                    Is.EqualTo(new[] { 10, 25 }));
                Assert.That(aggregate.StateMarkers.Select(marker => marker.NormalizedState),
                    Is.EqualTo(new[] { "AL", "VA" }));
                Assert.That(aggregate.Contributors.SelectMany(row => row.RelevantCells)
                    .Select(cell => cell.Address), Is.EquivalentTo(new[] { "A10", "B10", "A25", "C25" }));
                Assert.That(aggregate.ManualReviewRequired, Is.False);
            });
        }

        [Test]
        public void CompatibleDuplicate_UnionsSf02770826WvVaAndLaterCaContribution()
        {
            var first = Row(
                "SF0277",
                "0826",
                sourceRow: 4,
                markers: new[]
                {
                    Marker("WV", "Y", "B4"),
                    Marker("VA", "Y", "C4")
                });
            var later = Row(
                "SF0277",
                "0826",
                sourceRow: 9,
                markers: new[] { Marker("CA", "Y", "D9") });

            var aggregate = CanonicalFormAggregator.Aggregate(new[] { first, later }).Single();

            Assert.That(
                aggregate.StateMarkers.Select(marker => (marker.NormalizedState, marker.RawValue)),
                Is.EqualTo(new[] { ("CA", "Y"), ("VA", "Y"), ("WV", "Y") }));
            Assert.That(aggregate.Contributors, Has.Count.EqualTo(2));
        }

        [Test]
        public void CompanyApplicabilityConflict_RemainsSeparateWithManualReview()
        {
            var anpac = Row(
                "SF0227",
                "0801",
                sourceRow: 10,
                markers: new[] { Marker("TX-ANPAC", "Y", "B10", companySpecific: true) });
            var lloyds = Row(
                "SF0227",
                "0801",
                sourceRow: 11,
                markers: new[] { Marker("TX-Lloyds", "Y", "B11", companySpecific: true) });

            var aggregates = CanonicalFormAggregator.Aggregate(new[] { anpac, lloyds });

            Assert.Multiple(() =>
            {
                Assert.That(aggregates, Has.Count.EqualTo(2));
                Assert.That(aggregates.All(aggregate => aggregate.ManualReviewRequired), Is.True);
                Assert.That(aggregates.SelectMany(aggregate => aggregate.Findings)
                    .Where(finding => finding.Code == "AggregationConflict")
                    .All(finding => finding.Message.Contains("CompanyApplicability")), Is.True);
            });
        }

        [Test]
        public void ExplicitXAndBlankForSameState_RemainDistinctAndConflict()
        {
            var removal = Row(
                "SF0227",
                "0801",
                sourceRow: 10,
                markers: new[] { Marker("VA", "X", "B10") });
            var blank = Row(
                "SF0227",
                "0801",
                sourceRow: 11,
                markers: new[] { Marker("VA", "", "B11") });

            var aggregates = CanonicalFormAggregator.Aggregate(new[] { removal, blank });

            Assert.Multiple(() =>
            {
                Assert.That(aggregates, Has.Count.EqualTo(2));
                Assert.That(aggregates.SelectMany(aggregate => aggregate.StateMarkers)
                    .Select(marker => marker.RawValue), Is.EquivalentTo(new[] { "X", "" }));
                Assert.That(aggregates.All(aggregate => aggregate.Findings.Any(finding =>
                    finding.Code == "AggregationConflict"
                    && finding.Message.Contains("ExplicitRemovals"))), Is.True);
            });
        }

        [TestCase("Selection")]
        [TestCase("Rules")]
        [TestCase("StartDate")]
        [TestCase("Lifecycle")]
        [TestCase("Transactions")]
        public void EligibilityDimensionConflict_RemainsSeparateWithFinding(string dimension)
        {
            var first = Row("SF0227", "0801", sourceRow: 1);
            var second = Row(
                "SF0227",
                "0801",
                sourceRow: 2,
                selection: dimension == "Selection" ? "Optional" : "Mandatory",
                rules: dimension == "Rules" ? "Different rule" : "Same rule",
                startDate: dimension == "StartDate" ? "4/3/2027" : "3/21/2027",
                lifecycle: dimension == "Lifecycle" ? "Withdrawn" : "Active",
                transactions: dimension == "Transactions" ? "Renewal" : "New Business");

            var aggregates = CanonicalFormAggregator.Aggregate(new[] { first, second });

            Assert.That(aggregates, Has.Count.EqualTo(2));
            Assert.That(aggregates.All(aggregate => aggregate.Findings.Any(finding =>
                finding.Code == "AggregationConflict"
                && finding.Message.Contains(dimension))), Is.True);
        }

        [Test]
        public void InconsistentEditionAndMalformedIdentity_AreNeverAutoMerged()
        {
            var valid = Row("SF0227", "0801", sourceRow: 1);
            var inconsistent = Row(
                "SF0227",
                "0802",
                sourceRow: 2,
                rawIdentifier: "SF02270801",
                normalizedIdentifier: "SF02270801");
            var malformed = Row(
                null,
                null,
                sourceRow: 3,
                rawIdentifier: "Unknown Notice",
                normalizedIdentifier: "UNKNOWNNOTICE");

            var aggregates = CanonicalFormAggregator.Aggregate(
                new[] { malformed, inconsistent, valid });

            Assert.Multiple(() =>
            {
                Assert.That(aggregates, Has.Count.EqualTo(3));
                Assert.That(aggregates.Count(aggregate =>
                    aggregate.Findings.Any(finding =>
                        finding.Code == "AggregationIdentityAmbiguous")), Is.EqualTo(2));
                Assert.That(aggregates.Single(aggregate =>
                    aggregate.AggregationKey == "SF0227|0801").ManualReviewRequired, Is.False);
            });
        }

        [Test]
        public void SfpAndCommonAgreementCombinesButDisagreementBlocksMerge()
        {
            var sfp = Row(
                "SF0227",
                "0801",
                sourceRow: 1,
                family: FormSourceFamily.Sfp);
            var commonAgreement = Row(
                "SF0227",
                "0801",
                sourceRow: 2,
                family: FormSourceFamily.Common);
            var commonConflict = Row(
                "SF0227",
                "0801",
                sourceRow: 3,
                family: FormSourceFamily.Common,
                rules: "Conflicting rule");

            var agreement = CanonicalFormAggregator.Aggregate(new[] { sfp, commonAgreement }).Single();
            var disagreement = CanonicalFormAggregator.Aggregate(new[] { sfp, commonConflict });

            Assert.Multiple(() =>
            {
                Assert.That(agreement.Contributors.Select(row => row.SourceFamily),
                    Is.EquivalentTo(new[] { FormSourceFamily.Sfp, FormSourceFamily.Common }));
                Assert.That(agreement.ManualReviewRequired, Is.False);
                Assert.That(disagreement, Has.Count.EqualTo(2));
                Assert.That(disagreement.All(aggregate => aggregate.ManualReviewRequired), Is.True);
            });
        }

        [Test]
        public void AggregationOrderAndFacts_AreDeterministicAcrossInputOrder()
        {
            var rows = new[]
            {
                Row("SF0277", "0826", sourceRow: 9, markers: new[] { Marker("CA", "Y", "D9") }),
                Row("SF0227", "0801", sourceRow: 10, markers: new[] { Marker("AL", "X", "B10") }),
                Row("SF0227", "0801", sourceRow: 25, markers: new[] { Marker("VA", "", "C25") }),
                Row("SF0277", "0826", sourceRow: 4, markers: new[] { Marker("WV", "Y", "B4") })
            };

            var forward = CanonicalFormAggregator.Aggregate(rows);
            var reverse = CanonicalFormAggregator.Aggregate(rows.AsEnumerable().Reverse());

            Assert.Multiple(() =>
            {
                Assert.That(Snapshot(reverse), Is.EqualTo(Snapshot(forward)));
                Assert.That(forward.SelectMany(aggregate => aggregate.Contributors).Count(),
                    Is.EqualTo(rows.Length));
                Assert.That(forward.SelectMany(aggregate => aggregate.StateMarkers)
                    .Select(marker => marker.RawValue),
                    Does.Contain("X").And.Contain(""));
            });
        }

        private static CanonicalFormSourceRow Row(
            string formNumber,
            string edition,
            int sourceRow,
            FormSourceFamily family = FormSourceFamily.Sfp,
            IReadOnlyList<CanonicalStateMarker> markers = null,
            string selection = "Mandatory",
            string rules = "Same rule",
            string startDate = "3/21/2027",
            string lifecycle = "Active",
            string transactions = "New Business",
            string rawIdentifier = null,
            string normalizedIdentifier = null)
        {
            var normalized = formNumber == null || edition == null
                ? ""
                : formNumber + edition;
            rawIdentifier ??= normalized;
            normalizedIdentifier ??= normalized;
            var workbook = family == FormSourceFamily.Sfp ? "sfp.xlsx" : "common.xlsx";
            var stateMarkers = markers ?? new[] { Marker("AL", "Y", $"B{sourceRow}") };
            return new CanonicalFormSourceRow
            {
                RawFormIdentifier = rawIdentifier,
                NormalizedFormIdentifier = normalizedIdentifier,
                ParsedFormNumber = formNumber,
                ParsedEdition = edition,
                TitleDescription = "Form title",
                SourceFamily = family,
                Workbook = new WorkbookSourceInfo(workbook, $"C:\\sources\\{workbook}", new string('A', 64)),
                Worksheet = "Masterlist",
                SourceRowNumber = sourceRow,
                LegacySection = "BASE",
                SourceDivisionProductHints = new[] { "SFP", "BASE" },
                RelevantCells = new[]
                {
                    new SourceCellFact("Form Number", $"A{sourceRow}", normalized)
                }.Concat(stateMarkers.Select(marker =>
                    new SourceCellFact(marker.RawHeader, marker.Address, marker.RawValue))).ToArray(),
                StateMarkers = stateMarkers,
                RawSelection = selection,
                RawRules = rules,
                RawPrintRules = "Print rule",
                RawMultipleSelectionCriteria = "Multiple criteria",
                RawAdditionalSelectionCriteria = "Additional criteria",
                RawAdditionalRequirements = "Requirement",
                RawNotes = "Note",
                RawStartDate = startDate,
                ParsedStartDate = DateOnly.TryParse(startDate, out var parsedStart) ? parsedStart : null,
                RawStopDate = "",
                RawEffectiveDate = "4/3/2027",
                ParsedEffectiveDate = new DateOnly(2027, 4, 3),
                RawTransactionRules = transactions,
                TransactionTokens = new[] { transactions },
                RawLifecycle = lifecycle,
                RawWithdrawn = "No",
                RawReplacement = ""
            };
        }

        private static CanonicalStateMarker Marker(
            string header,
            string value,
            string address,
            bool companySpecific = false)
        {
            var normalizedState = header[..2];
            return new CanonicalStateMarker(
                header,
                normalizedState,
                address,
                value,
                IsConfiguredState: true,
                IsCompanySpecific: companySpecific,
                IsLegacyEligible: !companySpecific);
        }

        private static string Snapshot(IEnumerable<CanonicalFormAggregate> aggregates) =>
            string.Join(
                "\n",
                aggregates.Select(aggregate =>
                    $"{aggregate.AggregationKey}|"
                    + string.Join(",", aggregate.Contributors.Select(row =>
                        $"{row.SourceFamily}:{row.SourceRowNumber}")) + "|"
                    + string.Join(",", aggregate.StateMarkers.Select(marker =>
                        $"{marker.RawHeader}:{marker.RawValue}:{marker.Address}")) + "|"
                    + string.Join(",", aggregate.Findings.Select(finding =>
                        $"{finding.Code}:{finding.Message}"))));
    }
}
