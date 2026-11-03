using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using PnCTestAutomation.Tools.FormsBaselineGenerator;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    public class CanonicalScenarioEligibilityTests
    {
        private static readonly DateOnly EffectiveDate = new(2027, 4, 3);

        [Test]
        public void FeatureProfiles_ExtractBasicAndCeNewBusinessIdentity()
        {
            var basic = LoadBasic();
            var ce = LoadCe();

            Assert.Multiple(() =>
            {
                Assert.That(basic, Has.Count.EqualTo(44));
                Assert.That(ce, Has.Count.EqualTo(44));
                Assert.That(basic.Select(profile => profile.State), Is.Unique);
                Assert.That(ce.Select(profile => profile.State), Is.Unique);
                Assert.That(basic.All(profile =>
                    profile.ProfileId == "SFP-BASIC-NEW-BUSINESS"
                    && profile.ProfileVersion == "1.0"
                    && profile.Product == "BASIC"
                    && profile.Scenario == "New Business"
                    && profile.Transaction == "New Business"
                    && profile.EffectiveDate == EffectiveDate), Is.True);
                Assert.That(ce.All(profile =>
                    profile.ProfileId == "SFP-CE-NEW-BUSINESS"
                    && profile.Product == "CE"
                    && profile.Scenario == "New Business"), Is.True);
                Assert.That(basic.Select(profile => profile.Company).Distinct().Single(),
                    Is.EqualTo("American National Property And Casualty Co."));
                Assert.That(ce.Select(profile => profile.Company).Distinct().Single(),
                    Is.EqualTo("American National Property And Casualty Co."));
            });
        }

        [Test]
        public void FeatureProfiles_RecognizeCaVaWvAsConfiguredDevOnlyRows()
        {
            foreach (var profile in LoadBasic().Concat(LoadCe())
                         .Where(profile => profile.State is "CA" or "VA" or "WV"))
            {
                Assert.That(profile.Evidence.Tags, Does.Contain("@DevOnly"), profile.State);
            }

            Assert.Multiple(() =>
            {
                Assert.That(
                    LoadBasic().Where(profile => profile.State is "CA" or "VA" or "WV")
                        .Select(profile => profile.State),
                    Is.EquivalentTo(new[] { "CA", "VA", "WV" }));
                Assert.That(
                    LoadCe().Where(profile => profile.State is "CA" or "VA" or "WV")
                        .Select(profile => profile.State),
                    Is.EquivalentTo(new[] { "CA", "VA", "WV" }));
            });
        }

        [Test]
        public void ApplicableMandatoryNewBusiness_IsEligible()
        {
            var result = Evaluate(Row("AL", "Y", "Mandatory"), Profile("AL"));

            Assert.Multiple(() =>
            {
                Assert.That(result.Outcome, Is.EqualTo(ScenarioEligibilityOutcome.Eligible));
                Assert.That(result.ProvisionalRuntimeStatus, Is.EqualTo("YM"));
                Assert.That(result.RuleIds, Does.Contain("V1-ELIGIBLE"));
                Assert.That(result.RuleIds, Does.Contain("V1-Y-MANDATORY"));
                Assert.That(result.ApplicabilityInterpretations.Single().ProvisionalRuntimeStatus,
                    Is.EqualTo("YM"));
                Assert.That(result.MissingInputs, Is.Empty);
            });
        }

        [TestCase("VA", "Y", "V1-STATE-NOT-PRESENT")]
        [TestCase("AL", "X", "V1-EXPLICIT-REMOVAL")]
        [TestCase("AL", "", "V1-NOT-APPLICABLE")]
        [TestCase("AL", "N", "V1-RAW-N-NOT-APPLICABLE")]
        public void StateMismatchOrNonApplicable_IsIneligible(
            string markerState,
            string marker,
            string ruleId)
        {
            var result = Evaluate(Row(markerState, marker, "Mandatory"), Profile("AL"));

            Assert.Multiple(() =>
            {
                Assert.That(result.Outcome, Is.EqualTo(ScenarioEligibilityOutcome.Ineligible));
                Assert.That(result.ProvisionalRuntimeStatus, Is.EqualTo("N"));
                Assert.That(result.RuleIds, Does.Contain(ruleId));
            });
        }

        [Test]
        public void RawN_NeverBecomesQualifiedRuntimeStatus()
        {
            var result = Evaluate(Row("AL", "N", "Mandatory"), Profile("AL"));

            Assert.Multiple(() =>
            {
                Assert.That(result.Outcome, Is.EqualTo(ScenarioEligibilityOutcome.Ineligible));
                Assert.That(result.ProvisionalRuntimeStatus, Is.EqualTo("N"));
                Assert.That(result.RuleIds, Does.Contain("V1-RAW-N-NOT-APPLICABLE"));
                Assert.That(result.ProvisionalRuntimeStatus, Is.Not.AnyOf("YM", "YS", "YU"));
                Assert.That(result.ApplicabilityInterpretations.Single().RawMarker,
                    Is.EqualTo("N"));
            });
        }

        [TestCase("Renewal", "2027-03-01", "", "V1-TRANSACTION-INELIGIBLE")]
        [TestCase("New Business", "2027-04-04", "", "V1-DATE-NOT-YET-ACTIVE")]
        [TestCase("New Business", "2027-03-01", "2027-04-02", "V1-DATE-EXPIRED")]
        public void TransactionAndDateGates_ExcludeKnownIneligibleRecords(
            string transaction,
            string startDate,
            string stopDate,
            string ruleId)
        {
            var row = Row(
                "AL",
                "Y",
                "Mandatory",
                transaction: transaction,
                startDate: startDate,
                stopDate: stopDate);

            var result = Evaluate(row, Profile("AL"));

            Assert.Multiple(() =>
            {
                Assert.That(result.Outcome, Is.EqualTo(ScenarioEligibilityOutcome.Ineligible));
                Assert.That(result.RuleIds, Does.Contain(ruleId));
            });
        }

        [TestCase(
            "American National Property And Casualty Co.",
            ScenarioEligibilityOutcome.Eligible,
            "V1-COMPANY-MATCH")]
        [TestCase(
            "Farm Family Casualty Insurance Company",
            ScenarioEligibilityOutcome.Ineligible,
            "V1-COMPANY-MISMATCH")]
        [TestCase("", ScenarioEligibilityOutcome.Indeterminate, "V1-COMPANY-MISSING")]
        public void CompanySpecificApplicability_UsesScenarioSelectedCompany(
            string company,
            ScenarioEligibilityOutcome outcome,
            string ruleId)
        {
            var result = Evaluate(
                Row("AL", "Y", "Mandatory", companySpecific: true),
                Profile("AL") with { Company = company });

            Assert.Multiple(() =>
            {
                Assert.That(result.Outcome, Is.EqualTo(outcome));
                Assert.That(result.RuleIds, Does.Contain(ruleId));
                Assert.That(
                    result.ProvisionalRuntimeStatus,
                    Is.EqualTo(outcome switch
                    {
                        ScenarioEligibilityOutcome.Eligible => "YM",
                        ScenarioEligibilityOutcome.Ineligible => "N",
                        _ => null
                    }));
                if (outcome == ScenarioEligibilityOutcome.Indeterminate)
                    Assert.That(result.MissingInputs, Does.Contain("Company"));
            });
        }

        [Test]
        public void UnstructuredEligibilityText_RequiresManualReview()
        {
            var result = Evaluate(
                Row("AL", "Y", "Mandatory", rules: "Attach when coverage applies"),
                Profile("AL"));

            Assert.Multiple(() =>
            {
                Assert.That(result.Outcome,
                    Is.EqualTo(ScenarioEligibilityOutcome.ManualReviewRequired));
                Assert.That(result.RuleIds, Does.Contain("V1-UNSTRUCTURED-CONDITION"));
                Assert.That(result.Reasons.Single(reason =>
                    reason.Contains("free text", StringComparison.OrdinalIgnoreCase)),
                    Does.Contain("Rules"));
            });
        }

        [Test]
        public void UnavailableSelection_PropagatesManualReview()
        {
            var result = Evaluate(Row("AL", "Y", "Unavailable"), Profile("AL"));

            Assert.Multiple(() =>
            {
                Assert.That(result.Outcome,
                    Is.EqualTo(ScenarioEligibilityOutcome.ManualReviewRequired));
                Assert.That(result.RuleIds, Does.Contain("V1-APPLICABILITY-UNRESOLVED"));
            });
        }

        [Test]
        public void AggregationConflict_PropagatesManualReview()
        {
            var aggregates = CanonicalFormAggregator.Aggregate(new[]
            {
                Row("AL", "Y", "Mandatory", sourceRow: 2),
                Row("AL", "Y", "Unavailable", sourceRow: 3)
            });
            var aggregate = aggregates.First();
            var interpretation = CanonicalApplicabilityInterpreter.Interpret(aggregate);

            var result = CanonicalScenarioEligibilityEvaluator.Evaluate(
                aggregate,
                interpretation,
                Profile("AL"));

            Assert.Multiple(() =>
            {
                Assert.That(aggregates, Has.Count.EqualTo(2));
                Assert.That(result.Outcome,
                    Is.EqualTo(ScenarioEligibilityOutcome.ManualReviewRequired));
                Assert.That(result.RuleIds, Does.Contain("V1-AGGREGATE-BLOCKED"));
            });
        }

        [TestCase(
            "Withdrawn",
            "Yes",
            "2027-04-03",
            ScenarioEligibilityOutcome.Ineligible,
            "V1-WITHDRAWN")]
        [TestCase(
            "Withdrawn",
            "Yes",
            "",
            ScenarioEligibilityOutcome.ManualReviewRequired,
            "V1-WITHDRAWN-DATE-MISSING")]
        public void WithdrawnLifecycle_UsesOnlySafeStopDateGate(
            string lifecycle,
            string withdrawn,
            string stopDate,
            ScenarioEligibilityOutcome outcome,
            string ruleId)
        {
            var result = Evaluate(
                Row(
                    "AL",
                    "Y",
                    "Mandatory",
                    stopDate: stopDate,
                    lifecycle: lifecycle,
                    withdrawn: withdrawn),
                Profile("AL"));

            Assert.Multiple(() =>
            {
                Assert.That(result.Outcome, Is.EqualTo(outcome));
                Assert.That(result.RuleIds, Does.Contain(ruleId));
                Assert.That(
                    result.ProvisionalRuntimeStatus,
                    Is.EqualTo(outcome == ScenarioEligibilityOutcome.Ineligible ? "N" : null));
            });
        }

        [Test]
        public void ExplicitProductMismatch_IsIneligible()
        {
            var result = Evaluate(
                Row("AL", "Y", "Mandatory", product: "CE"),
                Profile("AL"));

            Assert.Multiple(() =>
            {
                Assert.That(result.Outcome, Is.EqualTo(ScenarioEligibilityOutcome.Ineligible));
                Assert.That(result.RuleIds, Does.Contain("V1-PRODUCT-MISMATCH"));
            });
        }

        [Test]
        public void ExplanationsAndEvidence_AreDeterministic()
        {
            var aggregate = CanonicalFormAggregator.Aggregate(new[]
            {
                Row("AL", "Y", "Mandatory", sourceRow: 7)
            }).Single();
            var interpretation = CanonicalApplicabilityInterpreter.Interpret(aggregate);
            var profile = Profile("AL");

            var first = CanonicalScenarioEligibilityEvaluator.Evaluate(
                aggregate,
                interpretation,
                profile);
            var second = CanonicalScenarioEligibilityEvaluator.Evaluate(
                aggregate,
                interpretation,
                profile);

            Assert.Multiple(() =>
            {
                Assert.That(Snapshot(second), Is.EqualTo(Snapshot(first)));
                Assert.That(first.RuleSetId, Is.EqualTo("SfpBasicCeScenarioEligibility"));
                Assert.That(first.RuleVersion, Is.EqualTo("1.0"));
                Assert.That(first.SourceEvidence.Single(),
                    Has.Property(nameof(CanonicalEvidenceReference.SourceRow)).EqualTo(7)
                        .And.Property(nameof(CanonicalEvidenceReference.MarkerCell)).EqualTo("B7")
                        .And.Property(nameof(CanonicalEvidenceReference.SelectionCell)).EqualTo("C7"));
                Assert.That(first.ProfileEvidence.Single().State, Is.EqualTo("AL"));
                Assert.That(first.ProfileEvidence.Single().FeaturePath,
                    Does.EndWith(Path.Combine("Features", "SFP", "SFP_BasicPolicy.feature")));
            });
        }

        private static ScenarioEligibilityResult Evaluate(
            CanonicalFormSourceRow row,
            ScenarioProfile profile)
        {
            var aggregate = CanonicalFormAggregator.Aggregate(new[] { row }).Single();
            var interpretation = CanonicalApplicabilityInterpreter.Interpret(aggregate);
            return CanonicalScenarioEligibilityEvaluator.Evaluate(
                aggregate,
                interpretation,
                profile);
        }

        private static ScenarioProfile Profile(string state) =>
            LoadBasic().Single(profile => profile.State == state);

        private static IReadOnlyList<ScenarioProfile> LoadBasic() =>
            ScenarioProfileLoader.LoadBasic(
                Path.Combine(ProjectRoot(), "Features", "SFP", "SFP_BasicPolicy.feature"),
                EffectiveDate);

        private static IReadOnlyList<ScenarioProfile> LoadCe() =>
            ScenarioProfileLoader.LoadCountryEstate(
                Path.Combine(ProjectRoot(), "Features", "SFP", "SFP_CE.feature"),
                EffectiveDate);

        private static CanonicalFormSourceRow Row(
            string state,
            string marker,
            string selection,
            int sourceRow = 2,
            string transaction = "New Business",
            string startDate = "2027-03-21",
            string stopDate = "",
            string lifecycle = "Active",
            string withdrawn = "No",
            string rules = "",
            string product = "BASIC",
            bool companySpecific = false)
        {
            var rawHeader = companySpecific ? $"{state}-ANPAC" : state;
            var transactionTokens = transaction switch
            {
                "New Business" => new[] { "New Business" },
                "Renewal" => new[] { "Renewal" },
                _ => Array.Empty<string>()
            };
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
                LegacySection = product,
                SourceDivisionProductHints = new[] { "SFP", product },
                RelevantCells = new[]
                {
                    new SourceCellFact("Form Number", $"A{sourceRow}", "SF02270801"),
                    new SourceCellFact(rawHeader, $"B{sourceRow}", marker),
                    new SourceCellFact("Selection", $"C{sourceRow}", selection)
                },
                StateMarkers = new[]
                {
                    new CanonicalStateMarker(
                        rawHeader,
                        state,
                        $"B{sourceRow}",
                        marker,
                        IsConfiguredState: true,
                        IsCompanySpecific: companySpecific,
                        IsLegacyEligible: !companySpecific)
                },
                RawSelection = selection,
                RawRules = rules,
                RawStartDate = startDate,
                ParsedStartDate = ParseDate(startDate),
                RawStopDate = stopDate,
                ParsedStopDate = ParseDate(stopDate),
                RawEffectiveDate = "",
                RawTransactionRules = transaction,
                TransactionTokens = transactionTokens,
                RawLifecycle = lifecycle,
                RawWithdrawn = withdrawn
            };
        }

        private static DateOnly? ParseDate(string value) =>
            string.IsNullOrWhiteSpace(value) ? null : DateOnly.Parse(value);

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

        private static string Snapshot(ScenarioEligibilityResult result) =>
            string.Join(
                "|",
                result.ProfileId,
                result.ProfileVersion,
                result.State,
                result.Scenario,
                result.Company,
                result.EffectiveDate,
                result.Transaction,
                result.ProvisionalRuntimeStatus,
                result.Outcome,
                result.RuleSetId,
                result.RuleVersion,
                string.Join(",", result.RuleIds),
                string.Join(",", result.Reasons),
                string.Join(",", result.MissingInputs),
                string.Join(",", result.SourceEvidence.Select(evidence =>
                    $"{evidence.WorkbookIdentity}:{evidence.SourceRow}:{evidence.MarkerCell}")),
                string.Join(",", result.ProfileEvidence.Select(evidence =>
                    $"{evidence.ScenarioName}:{evidence.ExamplesIndex}:{evidence.RowIndex}:{evidence.State}")));
    }
}
