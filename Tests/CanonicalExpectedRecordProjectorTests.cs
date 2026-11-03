using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PnCTestAutomation.Tools.FormsBaselineGenerator;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    public class CanonicalExpectedRecordProjectorTests
    {
        private static readonly DateOnly EffectiveDate = new(2027, 4, 3);

        [Test]
        public void SfpAndCommonExactAgreement_CombinesAllProvenance()
        {
            var projection = Project(
                Family(FormSourceFamily.Sfp, "BASIC", "AL", sourceRow: 2),
                Family(FormSourceFamily.Common, "BASIC", "AL", sourceRow: 9));

            var record = projection.QualifiedRecords.Single();
            Assert.Multiple(() =>
            {
                Assert.That(record.Destination, Is.EqualTo(CanonicalExpectedDestination.BASIC));
                Assert.That(record.SourceFamilies,
                    Is.EqualTo(new[] { FormSourceFamily.Sfp, FormSourceFamily.Common }));
                Assert.That(record.SourceRows.Select(row => row.SourceRowNumber),
                    Is.EqualTo(new[] { 2, 9 }));
                Assert.That(record.SourceRows.Select(row => row.Workbook.Identity),
                    Is.EquivalentTo(new[] { "common.xlsx", "sfp.xlsx" }));
                Assert.That(record.RuleIds, Does.Contain("V1-SOURCE-AGREEMENT"));
                Assert.That(projection.BlockedRecords, Is.Empty);
            });
        }

        [Test]
        public void AdditiveStates_UnionOnlyWhenOtherDimensionsAgree()
        {
            var projection = Project(
                Family(FormSourceFamily.Sfp, "BASIC", "VA", sourceRow: 7),
                Family(FormSourceFamily.Sfp, "BASIC", "AL", sourceRow: 2));

            var record = projection.QualifiedRecords.Single();
            Assert.Multiple(() =>
            {
                Assert.That(record.States, Is.EqualTo(new[] { "AL", "VA" }));
                Assert.That(record.SourceRows, Has.Count.EqualTo(2));
                Assert.That(record.RuleIds, Does.Contain("V1-ADDITIVE-STATE-UNION"));
            });
        }

        [TestCase("Status")]
        [TestCase("Company")]
        [TestCase("Date")]
        [TestCase("Lifecycle")]
        [TestCase("Conditions")]
        [TestCase("Transaction")]
        public void SfpCommonExpectationDisagreement_BlocksSourceConflict(
            string dimension)
        {
            var sfp = Family(FormSourceFamily.Sfp, "BASIC", "AL");
            var common = dimension switch
            {
                "Status" => Family(
                    FormSourceFamily.Common,
                    "BASIC",
                    "AL",
                    editionStatus: CanonicalEditionStatus.InactiveEdition,
                    marker: "X"),
                "Company" => Family(
                    FormSourceFamily.Common,
                    "BASIC",
                    "AL",
                    company: "Farm Family Casualty Insurance Company"),
                "Date" => Family(
                    FormSourceFamily.Common,
                    "BASIC",
                    "AL",
                    effectiveDate: new DateOnly(2027, 4, 4)),
                "Lifecycle" => Family(
                    FormSourceFamily.Common,
                    "BASIC",
                    "AL",
                    lifecycle: "Withdrawn"),
                "Conditions" => Family(
                    FormSourceFamily.Common,
                    "BASIC",
                    "AL",
                    rules: "Attach when coverage applies"),
                "Transaction" => Family(
                    FormSourceFamily.Common,
                    "BASIC",
                    "AL",
                    transaction: "Renewal"),
                _ => throw new ArgumentOutOfRangeException(nameof(dimension))
            };

            var projection = Project(sfp, common);

            var blocked = projection.BlockedRecords.Single();
            Assert.Multiple(() =>
            {
                Assert.That(blocked.Kind, Is.EqualTo(CanonicalProjectionBlockKind.SourceConflict));
                Assert.That(blocked.RuleIds, Does.Contain("V1-SOURCE-CONFLICT"));
                Assert.That(blocked.SourceFamilies,
                    Is.EqualTo(new[] { FormSourceFamily.Sfp, FormSourceFamily.Common }));
                Assert.That(blocked.SourceRows, Has.Count.EqualTo(2));
                Assert.That(blocked.ScenarioImpact, Does.Contain("BASIC").And.Contain("AL"));
                Assert.That(projection.QualifiedRecords, Is.Empty);
                Assert.That(projection.ImplicitNEvidence, Is.Empty);
            });
        }

        [Test]
        public void CommonOriginAlone_DoesNotDetermineBaseDestination()
        {
            var projection = Project(
                Family(FormSourceFamily.Common, "BASIC", "AL"));

            Assert.Multiple(() =>
            {
                Assert.That(projection.QualifiedRecords.Single().Destination,
                    Is.EqualTo(CanonicalExpectedDestination.BASIC));
                Assert.That(projection.QualifiedRecords.Single().Destination,
                    Is.Not.EqualTo(CanonicalExpectedDestination.BASE));
            });
        }

        [Test]
        public void IdenticalBasicAndCeExpectations_RouteToBase()
        {
            var projection = Project(
                Family(FormSourceFamily.Sfp, "BASIC", "AL", sourceRow: 2),
                Family(FormSourceFamily.Sfp, "CE", "AL", sourceRow: 5));

            var record = projection.QualifiedRecords.Single();
            Assert.Multiple(() =>
            {
                Assert.That(record.Destination, Is.EqualTo(CanonicalExpectedDestination.BASE));
                Assert.That(record.ProfileIds,
                    Is.EquivalentTo(new[]
                    {
                        "SFP-BASIC-NEW-BUSINESS",
                        "SFP-CE-NEW-BUSINESS"
                    }));
                Assert.That(record.RuleIds, Does.Contain("V1-ROUTE-BASE"));
                Assert.That(record.SourceRows, Has.Count.EqualTo(2));
            });
        }

        [Test]
        public void BasicCeConditionDifference_RemainsSeparateDestinations()
        {
            var projection = Project(
                Family(FormSourceFamily.Sfp, "BASIC", "AL"),
                Family(
                    FormSourceFamily.Sfp,
                    "CE",
                    "AL",
                    rules: "Country Estate condition",
                    sourceRow: 6));

            Assert.Multiple(() =>
            {
                Assert.That(projection.QualifiedRecords, Has.Count.EqualTo(2));
                Assert.That(projection.QualifiedRecords.Select(record => record.Destination),
                    Is.EquivalentTo(new[]
                    {
                        CanonicalExpectedDestination.BASIC,
                        CanonicalExpectedDestination.CE
                    }));
                Assert.That(projection.QualifiedRecords.All(record =>
                    record.Destination != CanonicalExpectedDestination.BASE), Is.True);
            });
        }

        [Test]
        public void SameFormWithDifferentBasicCeStatus_IsQualifiedOnlyWhereExpected()
        {
            var projection = Project(
                Family(FormSourceFamily.Sfp, "BASIC", "AL"),
                Family(
                    FormSourceFamily.Sfp,
                    "CE",
                    "AL",
                    editionStatus: CanonicalEditionStatus.InactiveEdition,
                    marker: "X",
                    sourceRow: 6));

            Assert.Multiple(() =>
            {
                Assert.That(projection.QualifiedRecords.Single().Destination,
                    Is.EqualTo(CanonicalExpectedDestination.BASIC));
                Assert.That(projection.ImplicitNEvidence.Single().ScenarioDestination,
                    Is.EqualTo(CanonicalExpectedDestination.CE));
                Assert.That(projection.QualifiedRecords.Any(record =>
                    record.Destination == CanonicalExpectedDestination.BASE), Is.False);
            });
        }

        [TestCase(CanonicalEditionFamilyStatus.Overlap)]
        [TestCase(CanonicalEditionFamilyStatus.Gap)]
        [TestCase(CanonicalEditionFamilyStatus.ManualReviewRequired)]
        public void UnresolvedStep6Family_ProjectsOnlyBlockedEvidence(
            CanonicalEditionFamilyStatus status)
        {
            var projection = Project(
                Family(
                    FormSourceFamily.Sfp,
                    "BASIC",
                    "AL",
                    familyStatus: status));

            var blocked = projection.BlockedRecords.Single();
            Assert.Multiple(() =>
            {
                Assert.That(blocked.Kind, Is.EqualTo(CanonicalProjectionBlockKind.UpstreamBlocked));
                Assert.That(blocked.RuleIds, Does.Contain("V1-UPSTREAM-BLOCKED"));
                Assert.That(blocked.SourceRows, Has.Count.EqualTo(1));
                Assert.That(projection.QualifiedRecords, Is.Empty);
                Assert.That(projection.ImplicitNEvidence, Is.Empty);
            });
        }

        [Test]
        public void InactiveN_IsEvidenceOnlyAndNotPartOfExpectedSet()
        {
            var projection = Project(
                Family(
                    FormSourceFamily.Sfp,
                    "BASIC",
                    "AL",
                    editionStatus: CanonicalEditionStatus.InactiveEdition,
                    marker: "X"));

            var evidence = projection.ImplicitNEvidence.Single();
            Assert.Multiple(() =>
            {
                Assert.That(projection.QualifiedRecords, Is.Empty);
                Assert.That(evidence.ProvisionalRuntimeStatus, Is.EqualTo("N"));
                Assert.That(evidence.Representation, Is.EqualTo("ImplicitN-EvidenceOnly"));
                Assert.That(evidence.IncludedInExpectedSet, Is.False);
                Assert.That(evidence.RuleIds, Does.Contain("V1-IMPLICIT-N-EVIDENCE"));
            });
        }

        [Test]
        public void RawN_IsImplicitEvidenceAndNotBlockedOrQualified()
        {
            var projection = Project(
                Family(
                    FormSourceFamily.Sfp,
                    "BASIC",
                    "AL",
                    editionStatus: CanonicalEditionStatus.InactiveEdition,
                    marker: "N"));

            var evidence = projection.ImplicitNEvidence.Single();
            Assert.Multiple(() =>
            {
                Assert.That(projection.QualifiedRecords, Is.Empty);
                Assert.That(projection.BlockedRecords, Is.Empty);
                Assert.That(evidence.ProvisionalRuntimeStatus, Is.EqualTo("N"));
                Assert.That(evidence.RuleIds,
                    Does.Contain("V1-RAW-N-NOT-APPLICABLE"));
                Assert.That(evidence.SourceRows.Single().StateMarkers.Single().RawValue,
                    Is.EqualTo("N"));
            });
        }

        [Test]
        public void Projection_IsDeterministicAndLosesNoRawProvenance()
        {
            var sfp = Family(FormSourceFamily.Sfp, "BASIC", "AL", sourceRow: 8);
            var common = Family(FormSourceFamily.Common, "BASIC", "AL", sourceRow: 3);
            var forward = Project(sfp, common);
            var reverse = Project(common, sfp);

            Assert.Multiple(() =>
            {
                Assert.That(Snapshot(reverse), Is.EqualTo(Snapshot(forward)));
                Assert.That(forward.RuleSetId, Is.EqualTo("CanonicalExpectedProjection"));
                Assert.That(forward.RuleVersion, Is.EqualTo("1.0"));
                Assert.That(
                    forward.QualifiedRecords.Single().SourceRows
                        .SelectMany(row => row.RelevantCells)
                        .Select(cell => $"{cell.Address}:{cell.RawValue}"),
                    Is.EquivalentTo(new[]
                    {
                        "A3:SF05010426", "B3:Y", "C3:Mandatory",
                        "A8:SF05010426", "B8:Y", "C8:Mandatory"
                    }));
            });
        }

        private static CanonicalExpectedProjection Project(
            params CanonicalEditionFamilyResolution[] families) =>
            CanonicalExpectedRecordProjector.Project(families);

        private static CanonicalEditionFamilyResolution Family(
            FormSourceFamily sourceFamily,
            string product,
            string state,
            CanonicalEditionStatus editionStatus = CanonicalEditionStatus.ActiveEdition,
            CanonicalEditionFamilyStatus familyStatus = CanonicalEditionFamilyStatus.Resolved,
            string marker = "Y",
            string company = "American National Property And Casualty Co.",
            DateOnly? effectiveDate = null,
            string transaction = "New Business",
            string lifecycle = "Active",
            string rules = "",
            int sourceRow = 2)
        {
            var profileId = product == "CE"
                ? "SFP-CE-NEW-BUSINESS"
                : "SFP-BASIC-NEW-BUSINESS";
            var date = effectiveDate ?? EffectiveDate;
            var workbookName = sourceFamily == FormSourceFamily.Sfp
                ? "sfp.xlsx"
                : "common.xlsx";
            var row = new CanonicalFormSourceRow
            {
                RawFormIdentifier = "SF05010426",
                NormalizedFormIdentifier = "SF05010426",
                ParsedFormNumber = "SF0501",
                ParsedEdition = "0426",
                TitleDescription = "Special Farm Package form",
                SourceFamily = sourceFamily,
                Workbook = new WorkbookSourceInfo(
                    workbookName,
                    $"C:\\sources\\{workbookName}",
                    sourceFamily == FormSourceFamily.Sfp
                        ? new string('A', 64)
                        : new string('B', 64)),
                Worksheet = sourceFamily == FormSourceFamily.Sfp
                    ? "SFP Masterlist"
                    : "Common Masterlist",
                SourceRowNumber = sourceRow,
                LegacySection = product,
                SourceDivisionProductHints = new[] { "SFP", product },
                RelevantCells = new[]
                {
                    new SourceCellFact("Form Number", $"A{sourceRow}", "SF05010426"),
                    new SourceCellFact(state, $"B{sourceRow}", marker),
                    new SourceCellFact("Selection", $"C{sourceRow}", "Mandatory")
                },
                StateMarkers = new[]
                {
                    new CanonicalStateMarker(
                        state,
                        state,
                        $"B{sourceRow}",
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
                TransactionTokens = transaction == "New Business"
                    ? new[] { "New Business" }
                    : new[] { transaction },
                RawLifecycle = lifecycle,
                RawWithdrawn = lifecycle == "Withdrawn" ? "Yes" : "No"
            };
            var aggregate = new CanonicalFormAggregate
            {
                AggregationKey = $"SF0501|0426|{sourceFamily}|{product}|{state}|{sourceRow}",
                FormNumber = "SF0501",
                Edition = "0426",
                Contributors = new[] { row },
                StateMarkers = row.StateMarkers
            };
            var eligibilityOutcome = editionStatus == CanonicalEditionStatus.ActiveEdition
                ? ScenarioEligibilityOutcome.Eligible
                : ScenarioEligibilityOutcome.Ineligible;
            var eligibility = new ScenarioEligibilityResult
            {
                ProfileId = profileId,
                ProfileVersion = "1.0",
                Product = product,
                State = state,
                Scenario = "New Business",
                Company = company,
                EffectiveDate = date,
                Transaction = transaction,
                ProvisionalRuntimeStatus = editionStatus == CanonicalEditionStatus.ActiveEdition
                    ? "YM"
                    : "N",
                Outcome = eligibilityOutcome,
                RuleSetId = "SfpBasicCeScenarioEligibility",
                RuleVersion = "1.0",
                RuleIds = new[]
                {
                    editionStatus == CanonicalEditionStatus.ActiveEdition
                        ? "V1-ELIGIBLE"
                        : marker switch
                        {
                            "N" => "V1-RAW-N-NOT-APPLICABLE",
                            "" => "V1-NOT-APPLICABLE",
                            _ => "V1-EXPLICIT-REMOVAL"
                        }
                },
                Reasons = new[] { "Fixture eligibility result." },
                SourceEvidence = new[]
                {
                    new CanonicalEvidenceReference(
                        sourceFamily,
                        workbookName,
                        row.Workbook.Sha256,
                        row.Worksheet,
                        sourceRow,
                        $"B{sourceRow}",
                        $"C{sourceRow}")
                }
            };
            var edition = new CanonicalEditionResolution
            {
                AggregationKey = aggregate.AggregationKey,
                FormNumber = "SF0501",
                Edition = "0426",
                NormalizedIdentifier = "SF05010426",
                Aggregate = aggregate,
                Status = editionStatus,
                ProvisionalRuntimeStatus = editionStatus == CanonicalEditionStatus.ActiveEdition
                    ? "YM"
                    : "N",
                Eligibility = eligibility,
                RuleIds = eligibility.RuleIds
                    .Append(
                        editionStatus == CanonicalEditionStatus.ActiveEdition
                            ? "V1-ACTIVE-EDITION"
                            : "V1-INACTIVE-EDITION")
                    .ToArray(),
                Reasons = new[] { "Fixture lifecycle result." },
                SourceEvidence = eligibility.SourceEvidence
            };
            return new CanonicalEditionFamilyResolution
            {
                FamilyKey = $"{profileId}|{state}|{company}|{date:yyyy-MM-dd}|{transaction}|{sourceFamily}|{sourceRow}",
                FormNumber = "SF0501",
                ProfileId = profileId,
                State = state,
                Scenario = "New Business",
                Company = company,
                EffectiveDate = date,
                Status = familyStatus,
                ManualReviewRequired = familyStatus != CanonicalEditionFamilyStatus.Resolved,
                RuleSetId = "CanonicalEditionLifecycle",
                RuleVersion = "1.0",
                RuleIds = familyStatus == CanonicalEditionFamilyStatus.Resolved
                    ? new[] { "V1-EDITION-RESOLVED" }
                    : new[] { $"V1-{familyStatus.ToString().ToUpperInvariant()}" },
                Reasons = new[] { "Fixture family result." },
                Editions = new[] { edition }
            };
        }

        private static string Snapshot(CanonicalExpectedProjection projection)
        {
            var qualified = projection.QualifiedRecords.Select(record =>
                $"Q|{record.Destination}|{record.NormalizedIdentifier}|"
                + $"{string.Join(",", record.States)}|"
                + $"{string.Join(",", record.SourceFamilies)}|"
                + string.Join(",", record.SourceRows.Select(row =>
                    $"{row.SourceFamily}:{row.SourceRowNumber}")));
            var implicitN = projection.ImplicitNEvidence.Select(record =>
                $"N|{record.ScenarioDestination}|{record.NormalizedIdentifier}|"
                + string.Join(",", record.States));
            var blocked = projection.BlockedRecords.Select(record =>
                $"B|{record.Kind}|{record.NormalizedIdentifier}|"
                + $"{string.Join(",", record.States)}|"
                + string.Join(",", record.SourceFamilies));
            return string.Join("\n", qualified.Concat(implicitN).Concat(blocked));
        }
    }
}
