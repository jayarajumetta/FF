using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Gherkin;
using Gherkin.Ast;

namespace PnCTestAutomation.Tools.FormsBaselineGenerator
{
    public enum ScenarioEligibilityOutcome
    {
        Eligible,
        Ineligible,
        Indeterminate,
        ManualReviewRequired
    }

    public sealed record ScenarioProfileEvidence(
        string FeaturePath,
        string ScenarioName,
        string Product,
        string Company,
        int ExamplesIndex,
        int RowIndex,
        string State,
        IReadOnlyList<string> Tags);

    public sealed record ScenarioProfile(
        string ProfileId,
        string ProfileVersion,
        string Product,
        string State,
        string Scenario,
        string Company,
        DateOnly EffectiveDate,
        string Transaction,
        ScenarioProfileEvidence Evidence);

    public sealed class ScenarioEligibilityResult
    {
        public string ProfileId { get; init; } = "";
        public string ProfileVersion { get; init; } = "";
        public string Product { get; init; } = "";
        public string State { get; init; } = "";
        public string Scenario { get; init; } = "";
        public string Company { get; init; } = "";
        public DateOnly EffectiveDate { get; init; }
        public string Transaction { get; init; } = "";
        public string ProvisionalRuntimeStatus { get; init; }
        public ScenarioEligibilityOutcome Outcome { get; init; }
        public string RuleSetId { get; init; } = "";
        public string RuleVersion { get; init; } = "";
        public IReadOnlyList<string> RuleIds { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> Reasons { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> MissingInputs { get; init; } = Array.Empty<string>();
        public IReadOnlyList<CanonicalMarkerInterpretation> ApplicabilityInterpretations { get; init; } =
            Array.Empty<CanonicalMarkerInterpretation>();
        public IReadOnlyList<CanonicalEvidenceReference> SourceEvidence { get; init; } =
            Array.Empty<CanonicalEvidenceReference>();
        public IReadOnlyList<ScenarioProfileEvidence> ProfileEvidence { get; init; } =
            Array.Empty<ScenarioProfileEvidence>();
    }

    public static class ScenarioProfileLoader
    {
        public const string ProfileVersion = "1.0";

        public static IReadOnlyList<ScenarioProfile> LoadBasic(
            string featurePath,
            DateOnly effectiveDate) =>
            Load(featurePath, "SFP-BASIC-NEW-BUSINESS", "BASIC", effectiveDate);

        public static IReadOnlyList<ScenarioProfile> LoadCountryEstate(
            string featurePath,
            DateOnly effectiveDate) =>
            Load(featurePath, "SFP-CE-NEW-BUSINESS", "CE", effectiveDate);

        public static string[] LoadConfiguredStates(
            string featurePath,
            string profileName) =>
            Extract(featurePath, profileName).Rows
                .Select(row => row.State)
                .OrderBy(state => state, StringComparer.Ordinal)
                .ToArray();

        private static IReadOnlyList<ScenarioProfile> Load(
            string featurePath,
            string profileId,
            string product,
            DateOnly effectiveDate)
        {
            var definition = Extract(featurePath, product);
            if (product == "CE" && definition.ProductSelection != "CE")
            {
                throw new InvalidOperationException(
                    "CE state-profile scenario requires ProductSelection='CE'.");
            }

            return definition.Rows
                .OrderBy(row => row.State, StringComparer.Ordinal)
                .Select(row => new ScenarioProfile(
                    profileId,
                    ProfileVersion,
                    product,
                    row.State,
                    "New Business",
                    definition.Company,
                    effectiveDate,
                    "New Business",
                    new ScenarioProfileEvidence(
                        Path.GetFullPath(featurePath),
                        definition.ScenarioName,
                        product,
                        definition.Company,
                        row.ExamplesIndex,
                        row.RowIndex,
                        row.State,
                        row.Tags)))
                .ToArray();
        }

        private static ExtractedProfile Extract(
            string featurePath,
            string profileName)
        {
            if (string.IsNullOrWhiteSpace(featurePath) || !File.Exists(featurePath))
                throw new InvalidOperationException(
                    $"{profileName} state-profile feature file not found: '{featurePath}'.");

            Scenario scenario;
            try
            {
                using var reader = new StringReader(File.ReadAllText(featurePath));
                var feature = new Parser().Parse(reader).Feature;
                var scenarios = feature.Children.OfType<Scenario>().ToArray();
                if (scenarios.Length != 1)
                    throw new InvalidOperationException(
                        $"{profileName} state-profile feature must contain exactly one New Business scenario outline.");
                scenario = scenarios[0];
            }
            catch (CompositeParserException exception)
            {
                throw new InvalidOperationException(
                    $"{profileName} state-profile feature is invalid Gherkin: {exception.Message}", exception);
            }

            if (!scenario.Steps.Any(step =>
                    step.Text == "user validates Forms via Duckcreek for state \"<StateAbbv>\""))
            {
                throw new InvalidOperationException(
                    $"{profileName} state-profile scenario must validate Forms using <StateAbbv>.");
            }

            var company = ReadStepTableValue(scenario, "WritingCompany");
            var productSelection = ReadStepTableValue(scenario, "ProductSelection");
            var states = new HashSet<string>(StringComparer.Ordinal);
            var rows = new List<ExtractedProfileRow>();
            var examplesIndex = 0;
            foreach (var examples in scenario.Examples)
            {
                examplesIndex++;
                var headers = examples.TableHeader.Cells.Select(cell => cell.Value).ToArray();
                var stateColumn = Array.IndexOf(headers, "StateAbbv");
                if (stateColumn < 0)
                    throw new InvalidOperationException(
                        $"{profileName} state-profile examples require a StateAbbv column.");

                var rowIndex = 0;
                foreach (var row in examples.TableBody)
                {
                    rowIndex++;
                    if (row.Cells.Count() <= stateColumn)
                        throw new InvalidOperationException(
                            $"{profileName} state-profile example row is missing StateAbbv.");
                    var state = row.Cells.ElementAt(stateColumn).Value;
                    if (state == null
                        || state.Length != 2
                        || state.Any(character => character is < 'A' or > 'Z')
                        || !states.Add(state))
                    {
                        throw new InvalidOperationException(
                            $"Invalid or duplicate state in {profileName} state-profile feature.");
                    }

                    rows.Add(new ExtractedProfileRow(
                        state,
                        examplesIndex,
                        rowIndex,
                        examples.Tags.Select(tag => tag.Name)
                            .OrderBy(tag => tag, StringComparer.Ordinal)
                            .ToArray()));
                }
            }

            if (states.Count == 0)
                throw new InvalidOperationException(
                    $"{profileName} state-profile feature contains no example states.");
            return new ExtractedProfile(
                scenario.Name,
                company,
                productSelection,
                rows);
        }

        private static string ReadStepTableValue(
            Scenario scenario,
            string question)
        {
            foreach (var table in scenario.Steps
                         .Select(step => step.Argument)
                         .OfType<DataTable>())
            {
                foreach (var row in table.Rows)
                {
                    var cells = row.Cells.Select(cell => cell.Value).ToArray();
                    if (cells.Length >= 2
                        && cells[0].Equals(question, StringComparison.Ordinal))
                    {
                        return cells[1];
                    }
                }
            }
            return "";
        }

        private sealed record ExtractedProfile(
            string ScenarioName,
            string Company,
            string ProductSelection,
            IReadOnlyList<ExtractedProfileRow> Rows);

        private sealed record ExtractedProfileRow(
            string State,
            int ExamplesIndex,
            int RowIndex,
            IReadOnlyList<string> Tags);
    }

    public static class CanonicalScenarioEligibilityEvaluator
    {
        public const string RuleSetId = "SfpBasicCeScenarioEligibility";
        public const string RuleVersion = "1.0";

        private static readonly string[] ConditionalTextNames =
        {
            "Rules",
            "PrintRules",
            "MultipleSelectionCriteria",
            "AdditionalSelectionCriteria",
            "AdditionalRequirements"
        };

        public static ScenarioEligibilityResult Evaluate(
            CanonicalFormAggregate aggregate,
            CanonicalAggregateInterpretation interpretation,
            ScenarioProfile profile)
        {
            var ruleIds = new List<string>();
            var reasons = new List<string>();
            var missingInputs = new List<string>();
            var manualReview = false;
            var indeterminate = false;
            var ineligible = false;
            var targetInterpretations = Array.Empty<CanonicalMarkerInterpretation>();

            void Add(
                string ruleId,
                string reason,
                ScenarioEligibilityOutcome outcome)
            {
                ruleIds.Add(ruleId);
                reasons.Add(reason);
                manualReview |= outcome == ScenarioEligibilityOutcome.ManualReviewRequired;
                indeterminate |= outcome == ScenarioEligibilityOutcome.Indeterminate;
                ineligible |= outcome == ScenarioEligibilityOutcome.Ineligible;
            }

            if (string.IsNullOrWhiteSpace(profile.State))
            {
                missingInputs.Add("State");
                Add("V1-PROFILE-STATE-MISSING", "Scenario profile state is required.",
                    ScenarioEligibilityOutcome.Indeterminate);
            }
            if (string.IsNullOrWhiteSpace(profile.Scenario))
            {
                missingInputs.Add("Scenario");
                Add("V1-PROFILE-SCENARIO-MISSING", "Scenario profile identity is required.",
                    ScenarioEligibilityOutcome.Indeterminate);
            }
            if (string.IsNullOrWhiteSpace(profile.Product))
            {
                missingInputs.Add("Product");
                Add("V1-PROFILE-PRODUCT-MISSING", "Scenario product is required.",
                    ScenarioEligibilityOutcome.Indeterminate);
            }
            if (string.IsNullOrWhiteSpace(profile.Transaction))
            {
                missingInputs.Add("Transaction");
                Add("V1-PROFILE-TRANSACTION-MISSING", "Scenario transaction is required.",
                    ScenarioEligibilityOutcome.Indeterminate);
            }

            if (interpretation.IsBlocked)
            {
                Add(
                    "V1-AGGREGATE-BLOCKED",
                    string.Join(" ", interpretation.BlockReasons),
                    ScenarioEligibilityOutcome.ManualReviewRequired);
                return Result();
            }

            targetInterpretations = interpretation.MarkerResults
                .Where(result => result.State.Equals(profile.State, StringComparison.Ordinal))
                .OrderBy(result => result.RawHeader, StringComparer.Ordinal)
                .ThenBy(result => result.Evidence.FirstOrDefault()?.SourceRow ?? 0)
                .ToArray();
            if (targetInterpretations.Length == 0)
            {
                Add(
                    "V1-STATE-NOT-PRESENT",
                    $"Aggregate has no applicability marker for scenario state {profile.State}.",
                    ScenarioEligibilityOutcome.Ineligible);
                return Result();
            }
            ruleIds.AddRange(targetInterpretations
                .Select(result => result.RuleId)
                .Where(ruleId => !string.IsNullOrWhiteSpace(ruleId)));

            var sourceRows = targetInterpretations
                .SelectMany(result => result.Evidence)
                .Select(evidence => aggregate.Contributors.Single(row =>
                    row.SourceFamily == evidence.SourceFamily
                    && row.Workbook.Identity == evidence.WorkbookIdentity
                    && row.Workbook.Sha256 == evidence.WorkbookHash
                    && row.Worksheet == evidence.Worksheet
                    && row.SourceRowNumber == evidence.SourceRow))
                .Distinct()
                .OrderBy(SourceOrderKey, StringComparer.Ordinal)
                .ToArray();

            var hasCompanySpecificMarker = targetInterpretations.Any(result =>
                !string.IsNullOrWhiteSpace(result.RawHeader)
                && !result.RawHeader.Equals(profile.State, StringComparison.Ordinal));
            foreach (var marker in targetInterpretations)
            {
                if (marker.RuleId == "V1-COMPANY-DEFERRED")
                {
                    var selection = Normalize(marker.RawSelection);
                    if (selection == "UNAVAILABLE")
                    {
                        Add(
                            "V1-SELECTION-UNAVAILABLE",
                            "Selection 'Unavailable' cannot be scenario-qualified.",
                            ScenarioEligibilityOutcome.ManualReviewRequired);
                    }
                    else if (selection != "MANDATORY")
                    {
                        Add(
                            "V1-SELECTION-UNRESOLVED",
                            "Company-specific applicable marker requires Mandatory Selection.",
                            ScenarioEligibilityOutcome.ManualReviewRequired);
                    }
                    continue;
                }
                if (marker.Outcome == CanonicalInterpretationOutcome.ManualReviewRequired
                    || marker.Outcome == CanonicalInterpretationOutcome.Indeterminate)
                {
                    Add(
                        "V1-APPLICABILITY-UNRESOLVED",
                        string.Join(" ", marker.Reasons),
                        ScenarioEligibilityOutcome.ManualReviewRequired);
                }
            }

            var applicabilityKinds = targetInterpretations
                .Select(result => result.Applicability)
                .Distinct()
                .ToArray();
            if (applicabilityKinds.Length > 1)
            {
                Add(
                    "V1-APPLICABILITY-CONFLICT",
                    "Contributing source markers disagree on applicability.",
                    ScenarioEligibilityOutcome.ManualReviewRequired);
            }
            else if (applicabilityKinds[0] == CanonicalApplicability.ExplicitRemoval)
            {
                Add(
                    "V1-EXPLICIT-REMOVAL",
                    "Raw X explicitly removes the form for this state.",
                    ScenarioEligibilityOutcome.Ineligible);
            }
            else if (applicabilityKinds[0] == CanonicalApplicability.NotApplicable)
            {
                foreach (var markerRule in targetInterpretations
                             .Select(marker => marker.RuleId)
                             .Distinct(StringComparer.Ordinal)
                             .OrderBy(ruleId => ruleId, StringComparer.Ordinal))
                {
                    if (markerRule == "V1-RAW-N-NOT-APPLICABLE")
                    {
                        Add(
                            markerRule,
                            "Raw N marks the form not applicable for this state.",
                            ScenarioEligibilityOutcome.Ineligible);
                    }
                    else
                    {
                        Add(
                            "V1-NOT-APPLICABLE",
                            "Raw blank marks the form not applicable for this state.",
                            ScenarioEligibilityOutcome.Ineligible);
                    }
                }
            }
            else if (applicabilityKinds[0] == CanonicalApplicability.Unknown)
            {
                Add(
                    "V1-UNKNOWN-APPLICABILITY",
                    "The raw state applicability marker is unsupported.",
                    ScenarioEligibilityOutcome.ManualReviewRequired);
            }

            if (ineligible || manualReview || indeterminate)
                return Result();

            if (hasCompanySpecificMarker)
                EvaluateCompany();

            EvaluateProduct();
            EvaluateConditionalText();
            EvaluateTransactions();
            EvaluateDates();
            EvaluateLifecycle();

            if (!manualReview && !indeterminate && !ineligible)
            {
                Add(
                    "V1-ELIGIBLE",
                    "Applicable mandatory form satisfies the configured New Business scenario profile.",
                    ScenarioEligibilityOutcome.Eligible);
            }

            return Result();

            void EvaluateCompany()
            {
                if (string.IsNullOrWhiteSpace(profile.Company))
                {
                    missingInputs.Add("Company");
                    Add(
                        "V1-COMPANY-MISSING",
                        "Company-specific applicability requires a scenario-selected company.",
                        ScenarioEligibilityOutcome.Indeterminate);
                    return;
                }

                foreach (var marker in targetInterpretations)
                {
                    if (marker.RawHeader.Equals(profile.State, StringComparison.Ordinal))
                        continue;
                    var companyIdentity = CompanyIdentity(marker.RawHeader, profile.State);
                    if (companyIdentity == null)
                    {
                        Add(
                            "V1-COMPANY-UNKNOWN",
                            $"Company identity in source header '{marker.RawHeader}' is not structured.",
                            ScenarioEligibilityOutcome.ManualReviewRequired);
                    }
                    else if (!CompanyMatches(profile.Company, companyIdentity))
                    {
                        Add(
                            "V1-COMPANY-MISMATCH",
                            $"Source company '{companyIdentity}' does not match scenario company '{profile.Company}'.",
                            ScenarioEligibilityOutcome.Ineligible);
                    }
                    else
                    {
                        ruleIds.Add("V1-COMPANY-MATCH");
                        reasons.Add($"Source company '{companyIdentity}' matches the scenario company.");
                    }
                }
            }

            void EvaluateProduct()
            {
                var expected = profile.Product.Trim().ToUpperInvariant();
                foreach (var row in sourceRows)
                {
                    var section = row.LegacySection.Trim().ToUpperInvariant();
                    if (section is not ("BASE" or "BASIC" or "CE"))
                    {
                        Add(
                            "V1-PRODUCT-UNKNOWN",
                            $"Source product section '{row.LegacySection}' is not structured.",
                            ScenarioEligibilityOutcome.ManualReviewRequired);
                        continue;
                    }
                    if (section != "BASE" && section != expected)
                    {
                        Add(
                            "V1-PRODUCT-MISMATCH",
                            $"Source product section '{section}' does not match profile '{expected}'.",
                            ScenarioEligibilityOutcome.Ineligible);
                    }

                    var explicitHints = row.SourceDivisionProductHints
                        .Select(NormalizeProductHint)
                        .Where(value => value != null)
                        .Distinct(StringComparer.Ordinal)
                        .ToArray();
                    if (explicitHints.Any(value => value != expected))
                    {
                        Add(
                            "V1-PRODUCT-HINT-MISMATCH",
                            $"Source product hint does not match profile '{expected}'.",
                            ScenarioEligibilityOutcome.Ineligible);
                    }
                }
            }

            void EvaluateConditionalText()
            {
                foreach (var row in sourceRows)
                {
                    var values = new[]
                    {
                        row.RawRules,
                        row.RawPrintRules,
                        row.RawMultipleSelectionCriteria,
                        row.RawAdditionalSelectionCriteria,
                        row.RawAdditionalRequirements
                    };
                    var populated = ConditionalTextNames
                        .Zip(values, (name, value) => (name, value))
                        .Where(pair => !string.IsNullOrWhiteSpace(pair.value))
                        .Select(pair => pair.name)
                        .ToArray();
                    if (populated.Length > 0)
                    {
                        Add(
                            "V1-UNSTRUCTURED-CONDITION",
                            "Eligibility-affecting free text requires manual review: "
                            + string.Join(", ", populated) + ".",
                            ScenarioEligibilityOutcome.ManualReviewRequired);
                    }
                }
            }

            void EvaluateTransactions()
            {
                if (!profile.Transaction.Equals("New Business", StringComparison.OrdinalIgnoreCase))
                {
                    Add(
                        "V1-SCENARIO-TRANSACTION-UNSUPPORTED",
                        $"Scenario transaction '{profile.Transaction}' is outside the New Business profile.",
                        ScenarioEligibilityOutcome.Ineligible);
                    return;
                }

                foreach (var row in sourceRows)
                {
                    if (row.TransactionTokens.Any(token =>
                            token.Equals("New Business", StringComparison.OrdinalIgnoreCase)))
                        continue;
                    if (row.TransactionTokens.Count > 0)
                    {
                        Add(
                            "V1-TRANSACTION-INELIGIBLE",
                            "Source transaction restriction excludes New Business.",
                            ScenarioEligibilityOutcome.Ineligible);
                        continue;
                    }
                    if (string.IsNullOrWhiteSpace(row.RawTransactionRules))
                        continue;
                    if (IsExplicitNonNewBusiness(row.RawTransactionRules))
                    {
                        Add(
                            "V1-TRANSACTION-INELIGIBLE",
                            $"Source transaction restriction '{row.RawTransactionRules}' excludes New Business.",
                            ScenarioEligibilityOutcome.Ineligible);
                    }
                    else
                    {
                        Add(
                            "V1-TRANSACTION-AMBIGUOUS",
                            $"Source transaction restriction '{row.RawTransactionRules}' is not structured.",
                            ScenarioEligibilityOutcome.ManualReviewRequired);
                    }
                }
            }

            void EvaluateDates()
            {
                foreach (var row in sourceRows)
                {
                    if (HasUnparsedDate(row))
                    {
                        Add(
                            "V1-DATE-UNPARSED",
                            "A populated source date could not be parsed safely.",
                            ScenarioEligibilityOutcome.ManualReviewRequired);
                    }
                    var lowerBound = new[] { row.ParsedStartDate, row.ParsedEffectiveDate }
                        .Where(date => date.HasValue)
                        .Select(date => date.Value)
                        .DefaultIfEmpty(DateOnly.MinValue)
                        .Max();
                    if (lowerBound > profile.EffectiveDate)
                    {
                        Add(
                            "V1-DATE-NOT-YET-ACTIVE",
                            $"Source interval begins {lowerBound:yyyy-MM-dd}, after "
                            + $"{profile.EffectiveDate:yyyy-MM-dd}.",
                            ScenarioEligibilityOutcome.Ineligible);
                    }
                    if (row.ParsedStopDate.HasValue
                        && row.ParsedStopDate.Value < profile.EffectiveDate)
                    {
                        Add(
                            "V1-DATE-EXPIRED",
                            $"Source interval stopped {row.ParsedStopDate.Value:yyyy-MM-dd}, before "
                            + $"{profile.EffectiveDate:yyyy-MM-dd}.",
                            ScenarioEligibilityOutcome.Ineligible);
                    }
                }
            }

            void EvaluateLifecycle()
            {
                foreach (var row in sourceRows)
                {
                    if (!string.IsNullOrWhiteSpace(row.RawReplacement))
                    {
                        ruleIds.Add("V1-REPLACEMENT-DEFERRED");
                        reasons.Add("Replacement facts are preserved for Step 6 cross-edition evaluation.");
                    }

                    var lifecycle = Normalize(row.RawLifecycle);
                    var withdrawn = Normalize(row.RawWithdrawn);
                    var lifecycleActive = lifecycle is "" or "ACTIVE";
                    var withdrawnNo = withdrawn is "" or "NO" or "N" or "FALSE";
                    var lifecycleWithdrawn = lifecycle.Contains("WITHDRAW", StringComparison.Ordinal);
                    var withdrawnYes = withdrawn is "YES" or "Y" or "TRUE" or "WITHDRAWN";
                    if ((!lifecycleActive && !lifecycleWithdrawn)
                        || (!withdrawnNo && !withdrawnYes))
                    {
                        Add(
                            "V1-LIFECYCLE-UNKNOWN",
                            "Lifecycle/withdrawn source facts are not structured.",
                            ScenarioEligibilityOutcome.ManualReviewRequired);
                    }
                    else if (lifecycleActive && withdrawnYes)
                    {
                        Add(
                            "V1-LIFECYCLE-CONFLICT",
                            "Lifecycle is active while withdrawn is affirmative.",
                            ScenarioEligibilityOutcome.ManualReviewRequired);
                    }
                    else if (lifecycleWithdrawn || withdrawnYes)
                    {
                        if (!row.ParsedStopDate.HasValue)
                        {
                            Add(
                                "V1-WITHDRAWN-DATE-MISSING",
                                "Withdrawn form requires a safely parsed stop date.",
                                ScenarioEligibilityOutcome.ManualReviewRequired);
                        }
                        else if (row.ParsedStopDate.Value <= profile.EffectiveDate)
                        {
                            Add(
                                "V1-WITHDRAWN",
                                $"Form was withdrawn by {row.ParsedStopDate.Value:yyyy-MM-dd}.",
                                ScenarioEligibilityOutcome.Ineligible);
                        }
                    }
                }
            }

            ScenarioEligibilityResult Result()
            {
                var outcome = manualReview
                    ? ScenarioEligibilityOutcome.ManualReviewRequired
                    : indeterminate
                        ? ScenarioEligibilityOutcome.Indeterminate
                        : ineligible
                            ? ScenarioEligibilityOutcome.Ineligible
                            : ScenarioEligibilityOutcome.Eligible;
                return new ScenarioEligibilityResult
                {
                    ProfileId = profile.ProfileId,
                    ProfileVersion = profile.ProfileVersion,
                    Product = profile.Product,
                    State = profile.State,
                    Scenario = profile.Scenario,
                    Company = profile.Company,
                    EffectiveDate = profile.EffectiveDate,
                    Transaction = profile.Transaction,
                    ProvisionalRuntimeStatus = outcome switch
                    {
                        ScenarioEligibilityOutcome.Eligible => "YM",
                        ScenarioEligibilityOutcome.Ineligible => "N",
                        _ => null
                    },
                    Outcome = outcome,
                    RuleSetId = RuleSetId,
                    RuleVersion = RuleVersion,
                    RuleIds = ruleIds.Distinct(StringComparer.Ordinal).ToArray(),
                    Reasons = reasons.Distinct(StringComparer.Ordinal).ToArray(),
                    MissingInputs = missingInputs.Distinct(StringComparer.Ordinal).ToArray(),
                    ApplicabilityInterpretations = targetInterpretations,
                    SourceEvidence = (targetInterpretations.Length > 0
                            ? targetInterpretations.SelectMany(result => result.Evidence)
                            : AggregateEvidence(aggregate))
                        .OrderBy(evidence => evidence.WorkbookIdentity, StringComparer.Ordinal)
                        .ThenBy(evidence => evidence.Worksheet, StringComparer.Ordinal)
                        .ThenBy(evidence => evidence.SourceRow)
                        .ThenBy(evidence => evidence.MarkerCell, StringComparer.Ordinal)
                        .ToArray(),
                    ProfileEvidence = new[] { profile.Evidence }
                };
            }
        }

        private static bool HasUnparsedDate(CanonicalFormSourceRow row) =>
            (!string.IsNullOrWhiteSpace(row.RawStartDate) && !row.ParsedStartDate.HasValue)
            || (!string.IsNullOrWhiteSpace(row.RawStopDate) && !row.ParsedStopDate.HasValue)
            || (!string.IsNullOrWhiteSpace(row.RawEffectiveDate) && !row.ParsedEffectiveDate.HasValue);

        private static IEnumerable<CanonicalEvidenceReference> AggregateEvidence(
            CanonicalFormAggregate aggregate) =>
            aggregate.Contributors.SelectMany(row => row.StateMarkers.Select(marker =>
                new CanonicalEvidenceReference(
                    row.SourceFamily,
                    row.Workbook.Identity,
                    row.Workbook.Sha256,
                    row.Worksheet,
                    row.SourceRowNumber,
                    marker.Address,
                    row.RelevantCells.FirstOrDefault(cell =>
                        cell.Header.Trim().Equals(
                            "Selection",
                            StringComparison.OrdinalIgnoreCase))?.Address ?? "")));

        private static string Normalize(string value) =>
            string.IsNullOrWhiteSpace(value)
                ? ""
                : string.Join(
                    " ",
                    value.Split((char[])null, StringSplitOptions.RemoveEmptyEntries))
                    .ToUpperInvariant();

        private static string NormalizeProductHint(string value)
        {
            var normalized = Normalize(value);
            return normalized switch
            {
                "BASIC" => "BASIC",
                "CE" => "CE",
                "COUNTRY ESTATE" => "CE",
                _ => null
            };
        }

        private static bool IsExplicitNonNewBusiness(string raw)
        {
            var normalized = Normalize(raw)
                .Replace("-", " ", StringComparison.Ordinal);
            return normalized is "RENEWAL"
                or "RENEWAL CONVERSION"
                or "ADJUST RENEWAL"
                or "ENDORSE"
                or "ENDORSEMENT"
                or "ENDORSE ONLY";
        }

        private static string CompanyIdentity(
            string rawHeader,
            string state)
        {
            var suffix = rawHeader.Trim();
            if (suffix.StartsWith(state, StringComparison.OrdinalIgnoreCase))
                suffix = suffix[state.Length..];
            suffix = suffix.Trim(' ', '-', '_');
            if (suffix.Equals("ANPAC", StringComparison.OrdinalIgnoreCase))
                return "ANPAC";
            if (suffix.Equals("FF", StringComparison.OrdinalIgnoreCase)
                || suffix.Equals("FARM FAMILY", StringComparison.OrdinalIgnoreCase))
                return "FARM FAMILY";
            return null;
        }

        private static bool CompanyMatches(
            string scenarioCompany,
            string sourceCompany) =>
            sourceCompany switch
            {
                "ANPAC" => Normalize(scenarioCompany) is
                    "AMERICAN NATIONAL PROPERTY AND CASUALTY CO."
                    or "AMERICAN NATIONAL PROPERTY AND CASUALTY CO"
                    or "ANPAC",
                "FARM FAMILY" => Normalize(scenarioCompany).Contains(
                    "FARM FAMILY",
                    StringComparison.Ordinal),
                _ => false
            };

        private static string SourceOrderKey(CanonicalFormSourceRow row) =>
            string.Join(
                "|",
                row.SourceFamily,
                row.Workbook.Path ?? "",
                row.Worksheet ?? "",
                row.SourceRowNumber.ToString("D8", System.Globalization.CultureInfo.InvariantCulture));
    }
}
