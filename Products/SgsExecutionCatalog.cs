#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using PnCTestAutomation.Artifacts;

namespace PnCTestAutomation.Products
{
    public enum SgsSourceCaseStatus
    {
        Active,
        CommentedOut
    }

    public enum SgsExecutionStatus
    {
        NonRunnable,
        ReadyForLocalVerification,
        Verified
    }

    public sealed record SgsCaseVerification(
        string RunId,
        string Environment,
        string CanonicalResultPath,
        string ManifestPath,
        string ImplementationCommit,
        DateTimeOffset CompletedAtUtc);

    public sealed record SgsExecutionCase(
        string AutomationId,
        IReadOnlyDictionary<string, string> Arguments,
        string ProfilePath,
        string ProfileSha256,
        string ExternalProfilePath,
        string ExternalProfileSha256,
        SgsSourceCaseStatus SourceStatus,
        SgsExecutionStatus ExecutionStatus,
        string BlockedReason,
        IReadOnlyList<SgsCaseVerification> ConsecutivePassingRuns);

    public sealed record SgsWorkflowDependencies(
        IReadOnlyList<string> Bindings,
        IReadOnlyList<string> SharedBindings,
        IReadOnlyList<string> Pages,
        IReadOnlyList<string> Locators,
        IReadOnlyList<string> FrameInputs);

    public sealed record SgsWorkflowReadiness(
        bool BindingsAdapted,
        bool SelectorsReviewed,
        bool FrameScopeReviewed,
        bool RequiredInputsReviewed,
        bool BusinessAssertionsImplemented,
        bool RichEvidenceWired,
        bool LocalQuoteCreationAuthorized,
        bool TransactionExecutionAuthorized);

    public sealed record SgsWorkflowContract(
        string AutomationFamily,
        string Product,
        string Feature,
        string SourcePath,
        string DestinationPath,
        string SourceSha256,
        string ImportedSha256,
        string AdaptedSha256,
        string ApplicationTag,
        string RunTypeTag,
        string ModuleId,
        IReadOnlyList<string> RequiredOutcomes,
        IReadOnlyList<ArtifactKind> RequiredEvidence,
        IReadOnlyList<string> PromisedBusinessSteps,
        SgsWorkflowDependencies Dependencies,
        SgsWorkflowReadiness Readiness,
        IReadOnlyList<SgsExecutionCase> Cases);

    public sealed record SgsDependencyDecision(
        string Path,
        string Kind,
        string Disposition,
        string Reason);

    public sealed record SgsExecutionLedger(
        int Version,
        string SourceRepository,
        string SourceRef,
        string SourceCommit,
        DateTimeOffset SourceVerifiedAtUtc,
        string DependencyMapSourceCommit,
        string DependencyMapSha256,
        string? SourceDeltaManifestSha256,
        IReadOnlyList<SgsDependencyDecision> DependencyDecisions,
        IReadOnlyList<SgsWorkflowContract> Workflows);

    public sealed record SgsCaseResolution(
        SgsWorkflowContract Workflow,
        SgsExecutionCase Case)
    {
        public bool IsRunnable => Case.SourceStatus == SgsSourceCaseStatus.Active &&
                                  Case.ExecutionStatus != SgsExecutionStatus.NonRunnable;

        public bool CanExecute(string? authorizedLocalCase) => IsRunnable &&
            (Case.ExecutionStatus == SgsExecutionStatus.Verified ||
             string.Equals(Case.AutomationId, authorizedLocalCase, StringComparison.Ordinal));
    }

    public static class SgsCaseIdentity
    {
        private static readonly Regex FamilyPattern = new(
            @"^SGS-(?:CLEQ|CLDC|PLDC)-[A-Z0-9]+(?:-[A-Z0-9]+)*$",
            RegexOptions.CultureInvariant);

        public static string Resolve(
            string automationFamily,
            IReadOnlyDictionary<string, string> arguments) =>
            $"{ValidateFamily(automationFamily)}:{GetQualifier(arguments)}";

        public static string GetQualifier(IReadOnlyDictionary<string, string> arguments)
        {
            ArgumentNullException.ThrowIfNull(arguments);
            var values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var pair in arguments)
            {
                if (string.IsNullOrWhiteSpace(pair.Key) ||
                    string.IsNullOrWhiteSpace(pair.Value) ||
                    !values.TryAdd(pair.Key, pair.Value.Trim()))
                {
                    throw new SgsExecutionConfigurationException(
                        "SGS example arguments contain an empty or duplicate key/value.");
                }
            }

            foreach (var key in new[] { "stateCode", "stateVariant", "dataFile", "externalDataFile" })
            {
                if (!values.ContainsKey(key))
                    throw new SgsExecutionConfigurationException($"SGS identity requires '{key}'.");
            }

            if (!Regex.IsMatch(values["stateCode"], "^[A-Z]{2}$", RegexOptions.CultureInvariant))
                throw new SgsExecutionConfigurationException("SGS stateCode must be a two-letter state.");
            var variant = Regex.Replace(values["stateVariant"].ToUpperInvariant(), @"\s+", "-");
            if (!Regex.IsMatch(variant, @"^[A-Z]{2}(?:-[A-Z0-9]+)*$", RegexOptions.CultureInvariant))
                throw new SgsExecutionConfigurationException("SGS stateVariant is not a stable qualifier.");
            if (variant != values["stateCode"] &&
                !variant.StartsWith(values["stateCode"] + "-", StringComparison.Ordinal))
            {
                throw new SgsExecutionConfigurationException("SGS stateCode and stateVariant disagree.");
            }

            values["dataFile"] = NormalizeRelativePath(values["dataFile"]);
            values["externalDataFile"] = NormalizeRelativePath(values["externalDataFile"]);
            // Display-only state names and example order do not own execution identity.
            var identityInputs = values
                .Where(pair => !pair.Key.Equals("stateName", StringComparison.OrdinalIgnoreCase))
                .OrderBy(pair => pair.Key, StringComparer.OrdinalIgnoreCase)
                .Select(pair => $"{pair.Key.ToLowerInvariant()}={pair.Value}");
            var hash = Convert.ToHexString(SHA256.HashData(
                Encoding.UTF8.GetBytes(string.Join("\n", identityInputs))))[..12];
            return $"{variant}-{hash}";
        }

        public static string NormalizeRelativePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || path.Any(char.IsControl))
                throw new SgsExecutionConfigurationException("SGS resource path is empty or invalid.");
            var normalized = path.Replace('\\', '/');
            if (Path.IsPathRooted(path) || normalized.StartsWith('/') ||
                normalized.Contains(':') ||
                normalized.Split('/').Any(part => part.Length == 0 || part is "." or ".."))
            {
                throw new SgsExecutionConfigurationException("SGS resource path must be a contained relative path.");
            }
            return normalized;
        }

        private static string ValidateFamily(string family)
        {
            if (family == null || !FamilyPattern.IsMatch(family))
                throw new SgsExecutionConfigurationException("SGS automation family is invalid.");
            return family;
        }
    }

    public sealed class SgsExecutionCatalog
    {
        public static JsonSerializerOptions JsonOptions { get; } = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow,
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        public SgsExecutionCatalog(SgsExecutionLedger ledger)
        {
            ArgumentNullException.ThrowIfNull(ledger);
            Validate(ledger);
            Ledger = ledger;
        }

        public SgsExecutionLedger Ledger { get; }

        public static SgsExecutionCatalog Load(string resourceRoot)
        {
            var path = ArtifactPathGuard.EnsureSafe(
                resourceRoot,
                Path.Combine(resourceRoot, "Contracts", "sgs-execution-ledger.json"));
            if (!File.Exists(path))
                throw new SgsExecutionConfigurationException("The SGS execution ledger is missing.");
            try
            {
                return new SgsExecutionCatalog(
                    JsonSerializer.Deserialize<SgsExecutionLedger>(File.ReadAllText(path), JsonOptions)
                    ?? throw new SgsExecutionConfigurationException("The SGS execution ledger is empty."));
            }
            catch (JsonException exception)
            {
                throw new SgsExecutionConfigurationException(
                    "The SGS execution ledger has an invalid schema.", exception);
            }
        }

        public SgsCaseResolution Resolve(
            string feature,
            IEnumerable<string> tags,
            IReadOnlyDictionary<string, string> arguments)
        {
            ArgumentNullException.ThrowIfNull(tags);
            var tagSet = tags.ToHashSet(StringComparer.OrdinalIgnoreCase);
            var matches = Ledger.Workflows.Where(workflow =>
                workflow.Feature.Equals(feature, StringComparison.Ordinal) &&
                tagSet.Contains("AutomationId-" + workflow.AutomationFamily)).ToArray();
            if (matches.Length != 1)
                throw new SgsExecutionConfigurationException("The SGS feature has no unique declared workflow owner.");
            var workflow = matches[0];
            var identity = SgsCaseIdentity.Resolve(workflow.AutomationFamily, arguments);
            var cases = workflow.Cases.Where(item =>
                item.AutomationId.Equals(identity, StringComparison.Ordinal)).ToArray();
            if (cases.Length != 1)
                throw new SgsExecutionConfigurationException("The SGS example has no unique ledger entry.");
            if (!tagSet.Contains("SgsImported") || !tagSet.Contains("NoRetry") ||
                !tagSet.Contains(workflow.ApplicationTag) || !tagSet.Contains(workflow.RunTypeTag))
            {
                throw new SgsExecutionConfigurationException("The SGS workflow is missing its execution contract tags.");
            }
            if (tagSet.Contains("RetrySafe"))
                throw new SgsExecutionConfigurationException("SGS mutations are not approved for scenario retries.");
            return new SgsCaseResolution(workflow, cases[0]);
        }

        public void ValidateResourcePayloads(string resourceRoot, SgsCaseResolution resolution)
        {
            var productFolder = ProductFolder(resolution.Workflow.Product);
            foreach (var item in new[]
                     {
                         (resolution.Case.ProfilePath, resolution.Case.ProfileSha256),
                         (resolution.Case.ExternalProfilePath, resolution.Case.ExternalProfileSha256)
                     })
            {
                var relativePath = SgsCaseIdentity.NormalizeRelativePath(item.Item1);
                if (!relativePath.StartsWith($"SGS/{productFolder}/TestData/", StringComparison.Ordinal))
                    throw new SgsExecutionConfigurationException("SGS profile escapes its product ownership.");
                var path = ArtifactPathGuard.EnsureSafe(
                    resourceRoot,
                    Path.Combine(resourceRoot, relativePath.Replace('/', Path.DirectorySeparatorChar)));
                if (!File.Exists(path) ||
                    !Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(path)))
                        .Equals(item.Item2, StringComparison.Ordinal))
                {
                    throw new SgsExecutionConfigurationException(
                        $"SGS profile '{relativePath}' is missing or does not match its reviewed checksum.");
                }
            }
        }

        public static string ProductFolder(string product) => product switch
        {
            "CLEQ" => "CommercialLines.ExpertQuote",
            "CLDC" => "CommercialLines.DuckCreek",
            "PLDC" => "PersonalLines.DuckCreek",
            _ => throw new SgsExecutionConfigurationException("Unknown SGS product.")
        };

        private static void Validate(SgsExecutionLedger ledger)
        {
            if (ledger.Version != 1 || ledger.SourceRepository != "PnC_DC_TestAutomation" ||
                ledger.SourceRef != "refs/remotes/origin/main" ||
                !IsHash(ledger.SourceCommit, 40) || !IsHash(ledger.DependencyMapSha256, 64) ||
                !IsHash(ledger.DependencyMapSourceCommit, 40) ||
                (ledger.SourceCommit != ledger.DependencyMapSourceCommit &&
                 !IsHash(ledger.SourceDeltaManifestSha256, 64)) ||
                ledger.SourceVerifiedAtUtc == default ||
                ledger.Workflows == null || ledger.Workflows.Count == 0 ||
                ledger.DependencyDecisions == null || ledger.DependencyDecisions.Count == 0)
            {
                throw new SgsExecutionConfigurationException("SGS ledger provenance or workflow inventory is incomplete.");
            }
            RequireUnique(ledger.Workflows.Select(item => item.AutomationFamily), "workflow families");
            RequireUnique(ledger.Workflows.Select(item => item.SourcePath), "source features");
            RequireUnique(ledger.Workflows.Select(item => item.DestinationPath), "destination features");
            RequireUnique(ledger.DependencyDecisions.Select(item => item.Path), "dependency decisions");
            var caseIds = new HashSet<string>(StringComparer.Ordinal);
            foreach (var workflow in ledger.Workflows)
            {
                var productFolder = ProductFolder(workflow.Product);
                if (string.IsNullOrWhiteSpace(workflow.Feature) ||
                    !workflow.AutomationFamily.StartsWith($"SGS-{workflow.Product}-", StringComparison.Ordinal) ||
                    !IsHash(workflow.SourceSha256, 64) || !IsHash(workflow.ImportedSha256, 64) ||
                    !IsHash(workflow.AdaptedSha256, 64) ||
                    workflow.RunTypeTag is not ("Smoke" or "Regression") ||
                    workflow.ApplicationTag != ApplicationTag(workflow.Product) ||
                    string.IsNullOrWhiteSpace(workflow.ModuleId) ||
                    workflow.Cases == null || workflow.Cases.Count == 0 ||
                    workflow.Dependencies == null || workflow.Readiness == null ||
                    workflow.Dependencies.Bindings == null || workflow.Dependencies.Bindings.Count == 0 ||
                    workflow.Dependencies.Pages == null || workflow.Dependencies.Pages.Count == 0 ||
                    workflow.Dependencies.Locators == null || workflow.Dependencies.Locators.Count == 0 ||
                    workflow.RequiredEvidence == null || workflow.RequiredEvidence.Count == 0 ||
                    workflow.RequiredEvidence.Any(kind => !Enum.IsDefined(kind)) ||
                    workflow.RequiredOutcomes == null || workflow.RequiredOutcomes.Count == 0)
                {
                    throw new SgsExecutionConfigurationException("An SGS workflow has an incomplete execution contract.");
                }
                if (!SgsCaseIdentity.NormalizeRelativePath(workflow.DestinationPath)
                        .StartsWith($"Features/SGS/{productFolder}/", StringComparison.Ordinal))
                    throw new SgsExecutionConfigurationException("An SGS feature has incorrect product ownership.");
                foreach (var item in workflow.Cases)
                {
                    if (item.Arguments == null ||
                        item.AutomationId != SgsCaseIdentity.Resolve(workflow.AutomationFamily, item.Arguments) ||
                        !caseIds.Add(item.AutomationId) ||
                        !Enum.IsDefined(item.SourceStatus) || !Enum.IsDefined(item.ExecutionStatus) ||
                        !IsHash(item.ProfileSha256, 64) || !IsHash(item.ExternalProfileSha256, 64) ||
                        item.ConsecutivePassingRuns == null)
                        throw new SgsExecutionConfigurationException("An SGS case has invalid identity, checksum, or status.");

                    var expectedPrefix = $"SGS/{productFolder}/";
                    if (SgsCaseIdentity.NormalizeRelativePath(item.ProfilePath) !=
                        expectedPrefix + SgsCaseIdentity.NormalizeRelativePath(item.Arguments["dataFile"]) ||
                        SgsCaseIdentity.NormalizeRelativePath(item.ExternalProfilePath) !=
                        expectedPrefix + SgsCaseIdentity.NormalizeRelativePath(item.Arguments["externalDataFile"]))
                        throw new SgsExecutionConfigurationException("SGS example arguments and owned profiles disagree.");
                    if (item.SourceStatus == SgsSourceCaseStatus.CommentedOut &&
                        item.ExecutionStatus != SgsExecutionStatus.NonRunnable)
                        throw new SgsExecutionConfigurationException("Source-commented coverage cannot be silently enabled.");
                    if (item.ExecutionStatus == SgsExecutionStatus.NonRunnable)
                    {
                        if (string.IsNullOrWhiteSpace(item.BlockedReason))
                            throw new SgsExecutionConfigurationException("A blocked SGS case requires an explicit reason.");
                    }
                    else
                    {
                        var ready = workflow.Readiness;
                        if (!ready.BindingsAdapted || !ready.SelectorsReviewed || !ready.FrameScopeReviewed ||
                            !ready.RequiredInputsReviewed || !ready.BusinessAssertionsImplemented ||
                            !ready.RichEvidenceWired || !ready.LocalQuoteCreationAuthorized ||
                            (workflow.RequiredOutcomes.Contains("Transmission", StringComparer.Ordinal) &&
                             !ready.TransactionExecutionAuthorized))
                            throw new SgsExecutionConfigurationException("SGS execution cannot bypass its readiness requirements.");
                        if (!string.IsNullOrEmpty(item.BlockedReason))
                            throw new SgsExecutionConfigurationException("A runnable SGS case still declares a blocking reason.");
                    }
                    if (item.ExecutionStatus == SgsExecutionStatus.Verified)
                    {
                        var runs = item.ConsecutivePassingRuns;
                        if (runs.Count < 2 || runs.Select(run => run.RunId).Distinct().Count() != runs.Count ||
                            runs.Any(run => string.IsNullOrWhiteSpace(run.RunId) ||
                                string.IsNullOrWhiteSpace(run.Environment) ||
                                string.IsNullOrWhiteSpace(run.CanonicalResultPath) ||
                                string.IsNullOrWhiteSpace(run.ManifestPath) ||
                                !IsHash(run.ImplementationCommit, 40) || run.CompletedAtUtc == default))
                            throw new SgsExecutionConfigurationException("Verified SGS cases require two distinct evidenced local passes.");
                    }
                }
            }
        }

        private static string ApplicationTag(string product) => product switch
        {
            "CLEQ" => "ExpertQuote",
            "CLDC" => "CommercialDuckCreek",
            "PLDC" => "PersonalDuckCreek",
            _ => throw new SgsExecutionConfigurationException("Unknown SGS product.")
        };

        private static bool IsHash(string? value, int length) =>
            value != null && value.Length == length && value.All(Uri.IsHexDigit);

        private static void RequireUnique(IEnumerable<string> values, string description)
        {
            var list = values.ToArray();
            if (list.Any(string.IsNullOrWhiteSpace) ||
                list.Distinct(StringComparer.OrdinalIgnoreCase).Count() != list.Length)
                throw new SgsExecutionConfigurationException($"SGS {description} contain missing or duplicate entries.");
        }
    }

    public sealed class SgsExecutionConfigurationException : Exception
    {
        public SgsExecutionConfigurationException(string message) : base(message) { }
        public SgsExecutionConfigurationException(string message, Exception inner) : base(message, inner) { }
    }
}
