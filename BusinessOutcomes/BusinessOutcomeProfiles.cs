#nullable enable
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PnCTestAutomation.BusinessOutcomes
{
    public enum BusinessOutcomeProfileMode
    {
        Approved,
        NonRunnable
    }

    public enum PremiumToleranceRule
    {
        Absolute
    }

    public enum TransmissionExpectationMode
    {
        AvailabilityOnly,
        TransmitAndVerify
    }

    public sealed class BusinessOutcomeOptions
    {
        public string ProfilePath { get; set; } =
            Path.Combine(
                "Resources",
                "ExpectedOutcomes",
                "sfp-outcomes.json");

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(ProfilePath) ||
                !Path.GetExtension(ProfilePath)
                    .Equals(".json", StringComparison.OrdinalIgnoreCase))
            {
                throw new BusinessOutcomeConfigurationException(
                    "BusinessOutcomes:ProfilePath must identify a JSON profile file.");
            }
        }
    }

    public sealed class ExpectedOutcomeCatalog
    {
        public int SchemaVersion { get; set; }
        public List<ExpectedOutcomeProfile> Profiles { get; set; } = [];
    }

    public sealed class ExpectedOutcomeProfile
    {
        public string ProfileId { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string ScenarioProfile { get; set; } = string.Empty;
        public string Environment { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public BusinessOutcomeProfileMode Mode { get; set; }
        public string BlockedReason { get; set; } = string.Empty;
        public OutcomeProvenance Provenance { get; set; } = new();
        public string Checksum { get; set; } = string.Empty;
        public PremiumOutcomeExpectation? Premium { get; set; }
        public FormsOutcomeExpectation? Forms { get; set; }
        public TransmissionOutcomeExpectation? Transmission { get; set; }
    }

    public sealed class OutcomeProvenance
    {
        public string Source { get; set; } = string.Empty;
        public string ApprovedBy { get; set; } = string.Empty;
        public DateTimeOffset? ApprovedAtUtc { get; set; }
        public DateTimeOffset? ValidUntilUtc { get; set; }
    }

    public sealed class PremiumOutcomeExpectation
    {
        public decimal ExpectedAmount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public PremiumToleranceRule ToleranceRule { get; set; }
        public decimal Tolerance { get; set; }
    }

    public sealed class FormsOutcomeExpectation
    {
        public string BaselineId { get; set; } = string.Empty;
        public string BaselineVersion { get; set; } = string.Empty;
        public string BaselineChecksum { get; set; } = string.Empty;
        public string Manuscript { get; set; } = string.Empty;
        public string PrintJob { get; set; } = string.Empty;
        public List<string> ExpectedReturnSuccessStatuses { get; set; } = [];
        public bool RequireRoleBasedSecurity { get; set; }
    }

    public sealed class TransmissionOutcomeExpectation
    {
        public TransmissionExpectationMode Mode { get; set; }
        public List<string> ExpectedStatuses { get; set; } = [];
        public string IdentityKind { get; set; } = string.Empty;
    }

    public sealed record BusinessOutcomeProfileResolution(
        ExpectedOutcomeProfile Profile,
        bool IsRunnable,
        string Reason);

    public sealed class BusinessOutcomeConfigurationException : Exception
    {
        public BusinessOutcomeConfigurationException(string message)
            : base(message)
        {
        }
    }

    public interface IExpectedOutcomeProfileProvider
    {
        BusinessOutcomeProfileResolution ResolvePreflight(
            string scenarioProfile,
            string environment,
            string state);
    }

    public sealed class ExpectedOutcomeProfileProvider :
        IExpectedOutcomeProfileProvider
    {
        private const int CurrentSchemaVersion = 1;

        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true,
            Converters = { new JsonStringEnumConverter() }
        };

        private readonly IReadOnlyList<ExpectedOutcomeProfile> _profiles;

        public ExpectedOutcomeProfileProvider(BusinessOutcomeOptions options)
            : this(Load(options), () => DateTimeOffset.UtcNow)
        {
        }

        public ExpectedOutcomeProfileProvider(
            ExpectedOutcomeCatalog catalog,
            Func<DateTimeOffset>? utcNow = null)
        {
            ArgumentNullException.ThrowIfNull(catalog);
            ExpectedOutcomeProfileValidator.ValidateCatalog(
                catalog,
                utcNow?.Invoke() ?? DateTimeOffset.UtcNow);
            _profiles = catalog.Profiles;
        }

        public BusinessOutcomeProfileResolution ResolvePreflight(
            string scenarioProfile,
            string environment,
            string state)
        {
            scenarioProfile = RequiredKey(scenarioProfile, nameof(scenarioProfile));
            environment = RequiredKey(environment, nameof(environment));
            state = RequiredKey(state, nameof(state));

            var stateMatches = _profiles
                .Where(profile =>
                    Matches(profile.ScenarioProfile, scenarioProfile) &&
                    Matches(profile.Environment, environment) &&
                    Matches(profile.State, state))
                .ToList();
            var approved = stateMatches
                .Where(profile => profile.Mode == BusinessOutcomeProfileMode.Approved)
                .ToList();

            if (approved.Count > 1)
            {
                throw new BusinessOutcomeConfigurationException(
                    $"Business outcome profile resolution is ambiguous for " +
                    $"{scenarioProfile}/{environment}/{state}.");
            }

            if (approved.Count == 1)
                return new BusinessOutcomeProfileResolution(approved[0], true, string.Empty);

            var nonRunnable = _profiles
                .Where(profile =>
                    profile.Mode == BusinessOutcomeProfileMode.NonRunnable &&
                    Matches(profile.ScenarioProfile, scenarioProfile) &&
                    Matches(profile.Environment, environment) &&
                    (Matches(profile.State, state) || profile.State == "*"))
                .OrderBy(profile => profile.State == "*" ? 1 : 0)
                .ToList();
            if (nonRunnable.Count == 0)
            {
                throw new BusinessOutcomeConfigurationException(
                    $"No business outcome profile exists for " +
                    $"{scenarioProfile}/{environment}/{state}.");
            }

            var bestSpecificity = nonRunnable[0].State == "*" ? 1 : 0;
            if (nonRunnable.Count(profile =>
                    (profile.State == "*" ? 1 : 0) == bestSpecificity) > 1)
            {
                throw new BusinessOutcomeConfigurationException(
                    $"Non-runnable business outcome profile resolution is ambiguous for " +
                    $"{scenarioProfile}/{environment}/{state}.");
            }

            var selected = nonRunnable[0];
            return new BusinessOutcomeProfileResolution(
                selected,
                false,
                selected.BlockedReason);
        }

        private static ExpectedOutcomeCatalog Load(BusinessOutcomeOptions options)
        {
            ArgumentNullException.ThrowIfNull(options);
            options.Validate();
            var path = Path.IsPathRooted(options.ProfilePath)
                ? options.ProfilePath
                : Path.Combine(AppContext.BaseDirectory, options.ProfilePath);
            path = Path.GetFullPath(path);
            if (!File.Exists(path))
            {
                throw new BusinessOutcomeConfigurationException(
                    "The configured business outcome profile file does not exist.");
            }

            try
            {
                return JsonSerializer.Deserialize<ExpectedOutcomeCatalog>(
                           File.ReadAllText(path),
                           JsonOptions)
                       ?? throw new BusinessOutcomeConfigurationException(
                           "The business outcome profile file is empty.");
            }
            catch (JsonException exception)
            {
                throw new BusinessOutcomeConfigurationException(
                    $"The business outcome profile file is invalid JSON: " +
                    $"{exception.Message}");
            }
        }

        private static bool Matches(string configured, string requested) =>
            configured.Equals(requested, StringComparison.OrdinalIgnoreCase);

        private static string RequiredKey(string value, string field)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new BusinessOutcomeConfigurationException(
                    $"{field} is required to resolve a business outcome profile.");
            }

            return value.Trim();
        }
    }

    public static class ExpectedOutcomeProfileValidator
    {
        private static readonly string[] PlaceholderTerms =
            ["placeholder", "pending", "synthetic", "sample", "todo", "tbd"];

        public static void ValidateCatalog(
            ExpectedOutcomeCatalog catalog,
            DateTimeOffset now)
        {
            if (catalog.SchemaVersion != 1)
            {
                throw new BusinessOutcomeConfigurationException(
                    $"Unsupported business outcome schema version " +
                    $"'{catalog.SchemaVersion}'.");
            }

            if (catalog.Profiles == null || catalog.Profiles.Count == 0)
            {
                throw new BusinessOutcomeConfigurationException(
                    "At least one business outcome profile is required.");
            }

            var keys = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var profile in catalog.Profiles)
            {
                ValidateCommon(profile);
                var key = string.Join(
                    "|",
                    profile.ScenarioProfile,
                    profile.Environment,
                    profile.State,
                    profile.Company);
                if (!keys.Add(key))
                {
                    throw new BusinessOutcomeConfigurationException(
                        $"Duplicate business outcome profile key '{key}'.");
                }

                if (profile.Mode == BusinessOutcomeProfileMode.NonRunnable)
                {
                    ValidateNonRunnable(profile);
                    continue;
                }

                ValidateApproved(profile, now);
            }
        }

        public static string ComputeChecksum(ExpectedOutcomeProfile profile)
        {
            var canonical = string.Join(
                "\n",
                profile.ProfileId,
                profile.Version,
                profile.ScenarioProfile,
                profile.Environment,
                profile.State,
                profile.Company,
                profile.Mode,
                profile.Provenance.Source,
                profile.Provenance.ApprovedBy,
                Format(profile.Provenance.ApprovedAtUtc),
                Format(profile.Provenance.ValidUntilUtc),
                profile.Premium?.ExpectedAmount.ToString(
                    "0.############################",
                    CultureInfo.InvariantCulture) ?? string.Empty,
                profile.Premium?.Currency ?? string.Empty,
                profile.Premium?.ToleranceRule.ToString() ?? string.Empty,
                profile.Premium?.Tolerance.ToString(
                    "0.############################",
                    CultureInfo.InvariantCulture) ?? string.Empty,
                profile.Forms?.BaselineId ?? string.Empty,
                profile.Forms?.BaselineVersion ?? string.Empty,
                profile.Forms?.BaselineChecksum ?? string.Empty,
                profile.Forms?.Manuscript ?? string.Empty,
                profile.Forms?.PrintJob ?? string.Empty,
                string.Join(
                    ",",
                    profile.Forms?.ExpectedReturnSuccessStatuses?
                        .Order(StringComparer.OrdinalIgnoreCase)
                        ?? Enumerable.Empty<string>()),
                profile.Forms?.RequireRoleBasedSecurity.ToString() ?? string.Empty,
                profile.Transmission?.Mode.ToString() ?? string.Empty,
                string.Join(
                    ",",
                    profile.Transmission?.ExpectedStatuses?
                        .Order(StringComparer.OrdinalIgnoreCase)
                        ?? Enumerable.Empty<string>()),
                profile.Transmission?.IdentityKind ?? string.Empty);
            return Convert.ToHexString(
                SHA256.HashData(Encoding.UTF8.GetBytes(canonical)));
        }

        private static void ValidateCommon(ExpectedOutcomeProfile profile)
        {
            Require(profile.ProfileId, "profileId");
            Require(profile.Version, "version");
            Require(profile.ScenarioProfile, "scenarioProfile");
            Require(profile.Environment, "environment");
            Require(profile.State, "state");
            Require(profile.Company, "company");
            ArgumentNullException.ThrowIfNull(profile.Provenance);
            Require(profile.Provenance.Source, "provenance.source");
        }

        private static void ValidateNonRunnable(ExpectedOutcomeProfile profile)
        {
            Require(profile.BlockedReason, "blockedReason");
            if (!profile.Checksum.Equals(
                    "PENDING-QA",
                    StringComparison.OrdinalIgnoreCase))
            {
                throw new BusinessOutcomeConfigurationException(
                    $"Non-runnable profile '{profile.ProfileId}' must use the " +
                    "explicit PENDING-QA checksum marker.");
            }

            if (profile.Premium != null ||
                profile.Forms != null ||
                profile.Transmission != null)
            {
                throw new BusinessOutcomeConfigurationException(
                    $"Non-runnable profile '{profile.ProfileId}' cannot contain " +
                    "placeholder business expectations.");
            }
        }

        private static void ValidateApproved(
            ExpectedOutcomeProfile profile,
            DateTimeOffset now)
        {
            if (profile.State == "*" || profile.Company == "*")
            {
                throw new BusinessOutcomeConfigurationException(
                    $"Approved profile '{profile.ProfileId}' must target an exact " +
                    "state and company.");
            }

            RejectPlaceholder(profile.Version, "version");
            RejectPlaceholder(profile.Provenance.Source, "provenance.source");
            RejectPlaceholder(profile.Provenance.ApprovedBy, "provenance.approvedBy");
            if (!profile.Provenance.ApprovedAtUtc.HasValue ||
                !profile.Provenance.ValidUntilUtc.HasValue)
            {
                throw new BusinessOutcomeConfigurationException(
                    $"Approved profile '{profile.ProfileId}' requires approval and " +
                    "expiration timestamps.");
            }

            if (profile.Provenance.ApprovedAtUtc.Value > now ||
                profile.Provenance.ValidUntilUtc.Value <= now)
            {
                throw new BusinessOutcomeConfigurationException(
                    $"Approved profile '{profile.ProfileId}' is stale or not yet applicable.");
            }

            ValidatePremium(profile);
            ValidateForms(profile);
            ValidateTransmission(profile);

            if (profile.Checksum.Length != 64 ||
                !profile.Checksum.All(Uri.IsHexDigit) ||
                !profile.Checksum.Equals(
                    ComputeChecksum(profile),
                    StringComparison.OrdinalIgnoreCase))
            {
                throw new BusinessOutcomeConfigurationException(
                    $"Approved profile '{profile.ProfileId}' checksum is missing or invalid.");
            }
        }

        private static void ValidatePremium(ExpectedOutcomeProfile profile)
        {
            var premium = profile.Premium
                          ?? throw new BusinessOutcomeConfigurationException(
                              $"Approved profile '{profile.ProfileId}' requires premium expectations.");
            if (premium.ExpectedAmount <= 0 ||
                premium.Tolerance < 0 ||
                premium.ToleranceRule != PremiumToleranceRule.Absolute ||
                !premium.Currency.Equals("USD", StringComparison.OrdinalIgnoreCase))
            {
                throw new BusinessOutcomeConfigurationException(
                    $"Approved profile '{profile.ProfileId}' has invalid premium expectations.");
            }
        }

        private static void ValidateForms(ExpectedOutcomeProfile profile)
        {
            var forms = profile.Forms
                        ?? throw new BusinessOutcomeConfigurationException(
                            $"Approved profile '{profile.ProfileId}' requires forms expectations.");
            RejectPlaceholder(forms.BaselineId, "forms.baselineId");
            RejectPlaceholder(forms.BaselineVersion, "forms.baselineVersion");
            RejectPlaceholder(forms.Manuscript, "forms.manuscript");
            RejectPlaceholder(forms.PrintJob, "forms.printJob");
            if (forms.ExpectedReturnSuccessStatuses == null ||
                forms.ExpectedReturnSuccessStatuses.Count == 0)
            {
                throw new BusinessOutcomeConfigurationException(
                    $"Approved profile '{profile.ProfileId}' requires forms return statuses.");
            }
            foreach (var status in forms.ExpectedReturnSuccessStatuses)
                RejectPlaceholder(status, "forms.expectedReturnSuccessStatuses");
            if (forms.BaselineChecksum.Length != 64 ||
                !forms.BaselineChecksum.All(Uri.IsHexDigit))
            {
                throw new BusinessOutcomeConfigurationException(
                    $"Approved profile '{profile.ProfileId}' has an invalid forms baseline checksum.");
            }
        }

        private static void ValidateTransmission(ExpectedOutcomeProfile profile)
        {
            var transmission = profile.Transmission
                               ?? throw new BusinessOutcomeConfigurationException(
                                   $"Approved profile '{profile.ProfileId}' requires a transmission expectation.");
            if (transmission.Mode == TransmissionExpectationMode.TransmitAndVerify)
            {
                if (transmission.ExpectedStatuses == null ||
                    transmission.ExpectedStatuses.Count == 0)
                {
                    throw new BusinessOutcomeConfigurationException(
                        $"Approved profile '{profile.ProfileId}' requires expected transmission statuses.");
                }

                RejectPlaceholder(
                    transmission.IdentityKind,
                    "transmission.identityKind");
                if (!transmission.IdentityKind.Equals(
                        "Quote",
                        StringComparison.OrdinalIgnoreCase))
                {
                    throw new BusinessOutcomeConfigurationException(
                        $"Approved profile '{profile.ProfileId}' uses an unsupported " +
                        "transmission identity contract.");
                }
                foreach (var status in transmission.ExpectedStatuses)
                    RejectPlaceholder(status, "transmission.expectedStatuses");
            }
        }

        private static void Require(string value, string field)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new BusinessOutcomeConfigurationException(
                    $"Business outcome {field} is required.");
            }
        }

        private static void RejectPlaceholder(string value, string field)
        {
            Require(value, field);
            if (PlaceholderTerms.Any(term =>
                    value.Contains(term, StringComparison.OrdinalIgnoreCase)))
            {
                throw new BusinessOutcomeConfigurationException(
                    $"Business outcome {field} contains a placeholder value.");
            }
        }

        private static string Format(DateTimeOffset? value) =>
            value?.ToUniversalTime().ToString("O", CultureInfo.InvariantCulture)
            ?? string.Empty;
    }

    public interface IBusinessOutcomeContext
    {
        ExpectedOutcomeProfile Require();
        void Set(ExpectedOutcomeProfile profile);
        void ConfirmApplicability(
            string environment,
            string state,
            string company);
    }

    public sealed class BusinessOutcomeContext : IBusinessOutcomeContext
    {
        private ExpectedOutcomeProfile? _profile;
        private bool _applicabilityConfirmed;

        public ExpectedOutcomeProfile Require() =>
            _profile == null
                ? throw new BusinessOutcomeConfigurationException(
                    "No approved business outcome profile is active for this scenario.")
                : !_applicabilityConfirmed
                    ? throw new BusinessOutcomeConfigurationException(
                        "The active business outcome profile has not been matched " +
                        "to the scenario environment, state, and company.")
                    : _profile;

        public void Set(ExpectedOutcomeProfile profile)
        {
            ArgumentNullException.ThrowIfNull(profile);
            if (profile.Mode != BusinessOutcomeProfileMode.Approved)
            {
                throw new BusinessOutcomeConfigurationException(
                    "Only an approved business outcome profile can become active.");
            }

            _profile = profile;
            _applicabilityConfirmed = false;
        }

        public void ConfirmApplicability(
            string environment,
            string state,
            string company)
        {
            if (_profile == null)
            {
                throw new BusinessOutcomeConfigurationException(
                    "No approved business outcome profile is active for this scenario.");
            }

            if (!_profile.Environment.Equals(
                    environment,
                    StringComparison.OrdinalIgnoreCase) ||
                !_profile.State.Equals(state, StringComparison.OrdinalIgnoreCase) ||
                !_profile.Company.Equals(company, StringComparison.OrdinalIgnoreCase))
            {
                throw new BusinessOutcomeConfigurationException(
                    "The approved business outcome profile is not applicable to " +
                    "the scenario environment, state, and company.");
            }

            _applicabilityConfirmed = true;
        }
    }
}
