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

namespace PnCTestAutomation.DataProfiles
{
    public enum PilotDataProfileMode
    {
        Approved,
        NonRunnable
    }

    public sealed class PilotDataProfileOptions
    {
        public string CatalogPath { get; set; } = Path.Combine(
            "Resources",
            "DataProfiles",
            "eq-bop-pilot.json");

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(CatalogPath) ||
                !Path.GetExtension(CatalogPath).Equals(
                    ".json",
                    StringComparison.OrdinalIgnoreCase))
            {
                throw new PilotDataConfigurationException(
                    "PilotDataProfiles:CatalogPath must identify a JSON file.");
            }
        }
    }

    public sealed class PilotDataCatalog
    {
        public int SchemaVersion { get; set; }
        public string CatalogVersion { get; set; } = "";
        public string SourceRepository { get; set; } = "";
        public List<PilotSourceFile> SourceFiles { get; set; } = [];
        public List<PilotDataProfile> Profiles { get; set; } = [];
    }

    public sealed class PilotSourceFile
    {
        public string Path { get; set; } = "";
        public string Sha256 { get; set; } = "";
    }

    public sealed class PilotDataProfile
    {
        public string ProfileId { get; set; } = "";
        public string Version { get; set; } = "";
        public string ModuleId { get; set; } = "";
        public string Environment { get; set; } = "";
        public string State { get; set; } = "";
        public PilotDataProfileMode Mode { get; set; }
        public string BlockedReason { get; set; } = "";
        public DateTimeOffset ValidUntilUtc { get; set; }
        public List<string> RequiredKeys { get; set; } = [];
        public List<string> MissingRequiredKeys { get; set; } = [];
        public List<PilotDataLayer> Layers { get; set; } = [];
        public string Checksum { get; set; } = "";
    }

    public sealed class PilotDataLayer
    {
        public string Name { get; set; } = "";
        public int Precedence { get; set; }
        public Dictionary<string, string> Values { get; set; } =
            new(StringComparer.OrdinalIgnoreCase);
    }

    public sealed record PilotDataResolution(
        PilotDataProfile Profile,
        IReadOnlyDictionary<string, string> Values,
        bool IsRunnable,
        string Reason);

    public interface IPilotDataProfileProvider
    {
        PilotDataResolution Resolve(
            string profileId,
            string environment,
            string state);
    }

    public interface IPilotDataContext
    {
        PilotDataResolution Require();
        void Set(PilotDataResolution resolution);
    }

    public sealed class PilotDataContext : IPilotDataContext
    {
        private PilotDataResolution? _resolution;

        public PilotDataResolution Require() =>
            _resolution
            ?? throw new PilotDataConfigurationException(
                "The pilot data profile was not initialized.");

        public void Set(PilotDataResolution resolution)
        {
            ArgumentNullException.ThrowIfNull(resolution);
            if (_resolution != null)
            {
                throw new PilotDataConfigurationException(
                    "The pilot data profile is already initialized.");
            }
            _resolution = resolution;
        }
    }

    public sealed class PilotDataProfileProvider :
        IPilotDataProfileProvider
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true,
            Converters = { new JsonStringEnumConverter() }
        };

        private readonly PilotDataCatalog _catalog;

        public PilotDataProfileProvider(PilotDataProfileOptions options)
            : this(Load(options), () => DateTimeOffset.UtcNow)
        {
        }

        public PilotDataProfileProvider(
            PilotDataCatalog catalog,
            Func<DateTimeOffset>? utcNow = null)
        {
            ArgumentNullException.ThrowIfNull(catalog);
            PilotDataProfileValidator.ValidateCatalog(
                catalog,
                utcNow?.Invoke() ?? DateTimeOffset.UtcNow);
            _catalog = catalog;
        }

        public PilotDataResolution Resolve(
            string profileId,
            string environment,
            string state)
        {
            var matches = _catalog.Profiles.Where(profile =>
                    profile.ProfileId.Equals(
                        Required(profileId, nameof(profileId)),
                        StringComparison.OrdinalIgnoreCase) &&
                    profile.Environment.Equals(
                        Required(environment, nameof(environment)),
                        StringComparison.OrdinalIgnoreCase) &&
                    profile.State.Equals(
                        Required(state, nameof(state)),
                        StringComparison.OrdinalIgnoreCase))
                .ToArray();
            if (matches.Length != 1)
            {
                throw new PilotDataConfigurationException(
                    matches.Length == 0
                        ? $"No pilot data profile exists for {profileId}/{environment}/{state}."
                        : $"Pilot data profile resolution is ambiguous for {profileId}/{environment}/{state}.");
            }

            var profile = matches[0];
            var values = PilotDataProfileValidator.ResolveValues(profile);
            return new PilotDataResolution(
                profile,
                values,
                profile.Mode == PilotDataProfileMode.Approved,
                profile.Mode == PilotDataProfileMode.Approved
                    ? ""
                    : profile.BlockedReason);
        }

        private static PilotDataCatalog Load(PilotDataProfileOptions options)
        {
            ArgumentNullException.ThrowIfNull(options);
            options.Validate();
            var path = Path.IsPathRooted(options.CatalogPath)
                ? options.CatalogPath
                : Path.Combine(AppContext.BaseDirectory, options.CatalogPath);
            try
            {
                return JsonSerializer.Deserialize<PilotDataCatalog>(
                           File.ReadAllText(Path.GetFullPath(path)),
                           JsonOptions)
                       ?? throw new JsonException();
            }
            catch (Exception exception) when (
                exception is IOException or JsonException)
            {
                throw new PilotDataConfigurationException(
                    "The configured pilot data profile is missing or malformed.");
            }
        }

        private static string Required(string value, string field)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new PilotDataConfigurationException($"{field} is required.");
            return value.Trim();
        }
    }

    public static class PilotDataProfileValidator
    {
        private static readonly string[] SyntheticTerms =
            ["{{", "}}", "placeholder", "synthetic", "sample", "todo", "tbd"];
        private static readonly string[] SecretKeyTerms =
            ["password", "secret", "token", "credential", "authorization"];

        public static void ValidateCatalog(
            PilotDataCatalog catalog,
            DateTimeOffset now)
        {
            if (catalog.SchemaVersion != 1)
                throw new PilotDataConfigurationException(
                    $"Unsupported pilot data schema '{catalog.SchemaVersion}'.");
            Require(catalog.CatalogVersion, "catalogVersion");
            Require(catalog.SourceRepository, "sourceRepository");
            if (catalog.SourceFiles.Count == 0)
                throw new PilotDataConfigurationException(
                    "At least one source file provenance record is required.");
            RequireUnique(
                catalog.SourceFiles.Select(source => source.Path),
                "source path");
            foreach (var source in catalog.SourceFiles)
            {
                Require(source.Path, "source path");
                RequireHash(source.Sha256, $"source hash for '{source.Path}'");
            }
            if (catalog.Profiles.Count == 0)
                throw new PilotDataConfigurationException(
                    "At least one pilot data profile is required.");
            RequireUnique(
                catalog.Profiles.Select(profile =>
                    $"{profile.ProfileId}|{profile.Environment}|{profile.State}"),
                "profile key");
            foreach (var profile in catalog.Profiles)
                ValidateProfile(catalog, profile, now);
        }

        public static IReadOnlyDictionary<string, string> ResolveValues(
            PilotDataProfile profile)
        {
            var resolved = new Dictionary<string, string>(
                StringComparer.OrdinalIgnoreCase);
            foreach (var layer in profile.Layers.OrderBy(item => item.Precedence))
            {
                foreach (var value in layer.Values)
                    resolved[value.Key] = value.Value.Trim();
            }
            return resolved;
        }

        public static string ComputeChecksum(
            PilotDataCatalog catalog,
            PilotDataProfile profile)
        {
            var lines = new List<string>
            {
                catalog.SchemaVersion.ToString(CultureInfo.InvariantCulture),
                catalog.CatalogVersion.Trim(),
                catalog.SourceRepository.Trim()
            };
            lines.AddRange(catalog.SourceFiles
                .OrderBy(source => source.Path, StringComparer.Ordinal)
                .Select(source =>
                    $"source|{source.Path.Trim()}|{source.Sha256.Trim().ToUpperInvariant()}"));
            lines.AddRange(
            [
                profile.ProfileId.Trim(),
                profile.Version.Trim(),
                profile.ModuleId.Trim(),
                profile.Environment.Trim(),
                profile.State.Trim(),
                profile.Mode.ToString(),
                profile.BlockedReason.Trim(),
                profile.ValidUntilUtc.ToUniversalTime().ToString(
                    "O",
                    CultureInfo.InvariantCulture),
                string.Join(
                    ",",
                    profile.RequiredKeys.Order(StringComparer.OrdinalIgnoreCase)),
                string.Join(
                    ",",
                    profile.MissingRequiredKeys.Order(
                        StringComparer.OrdinalIgnoreCase))
            ]);
            foreach (var layer in profile.Layers
                         .OrderBy(item => item.Precedence)
                         .ThenBy(item => item.Name, StringComparer.Ordinal))
            {
                lines.Add(
                    $"layer|{layer.Precedence}|{layer.Name.Trim()}");
                lines.AddRange(layer.Values
                    .OrderBy(item => item.Key, StringComparer.Ordinal)
                    .Select(item =>
                        $"value|{item.Key.Trim()}|{item.Value.Trim()}"));
            }
            return Convert.ToHexString(
                SHA256.HashData(Encoding.UTF8.GetBytes(string.Join("\n", lines))));
        }

        private static void ValidateProfile(
            PilotDataCatalog catalog,
            PilotDataProfile profile,
            DateTimeOffset now)
        {
            Require(profile.ProfileId, "profileId");
            Require(profile.Version, "version");
            Require(profile.ModuleId, "moduleId");
            Require(profile.Environment, "environment");
            Require(profile.State, "state");
            if (profile.ValidUntilUtc == default ||
                profile.ValidUntilUtc <= now)
            {
                throw new PilotDataConfigurationException(
                    $"Pilot data profile '{profile.ProfileId}' is stale.");
            }
            if (profile.Mode == PilotDataProfileMode.NonRunnable)
                Require(profile.BlockedReason, "blockedReason");
            else if (!string.IsNullOrWhiteSpace(profile.BlockedReason))
                throw new PilotDataConfigurationException(
                    $"Approved profile '{profile.ProfileId}' cannot have a blocked reason.");
            if (profile.RequiredKeys.Count == 0)
                throw new PilotDataConfigurationException(
                    $"Profile '{profile.ProfileId}' has no required keys.");
            RequireUnique(profile.RequiredKeys, "required key");
            RequireUnique(profile.MissingRequiredKeys, "missing required key");
            var undeclaredMissingKeys = profile.MissingRequiredKeys
                .Where(key => !profile.RequiredKeys.Contains(
                    key,
                    StringComparer.OrdinalIgnoreCase))
                .ToArray();
            if (undeclaredMissingKeys.Length > 0)
            {
                throw new PilotDataConfigurationException(
                    $"Profile '{profile.ProfileId}' declares unknown missing keys: " +
                    string.Join(", ", undeclaredMissingKeys));
            }
            if (profile.Layers.Count == 0)
                throw new PilotDataConfigurationException(
                    $"Profile '{profile.ProfileId}' has no data layers.");
            RequireUnique(
                profile.Layers.Select(layer =>
                    layer.Precedence.ToString(CultureInfo.InvariantCulture)),
                "layer precedence");
            RequireUnique(
                profile.Layers.Select(layer => layer.Name),
                "layer name");

            var allKeys = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var layer in profile.Layers)
            {
                Require(layer.Name, "layer name");
                foreach (var item in layer.Values)
                {
                    ValidateKey(item.Key);
                    ValidateValue(item.Value, item.Key);
                    allKeys.Add(item.Key);
                }
            }
            var leafCollision = allKeys
                .GroupBy(
                    key => key[(key.LastIndexOf('.') + 1)..],
                    StringComparer.OrdinalIgnoreCase)
                .FirstOrDefault(group => group.Count() > 1);
            if (leafCollision != null)
            {
                throw new PilotDataConfigurationException(
                    $"Flattened pilot data key '{leafCollision.Key}' is ambiguous.");
            }

            var resolved = ResolveValues(profile);
            var missing = profile.RequiredKeys
                .Where(key =>
                    !resolved.TryGetValue(key, out var value) ||
                    string.IsNullOrWhiteSpace(value))
                .ToArray();
            if (profile.Mode == PilotDataProfileMode.Approved &&
                (missing.Length > 0 ||
                 profile.MissingRequiredKeys.Count > 0))
            {
                throw new PilotDataConfigurationException(
                    $"Profile '{profile.ProfileId}' is missing required keys: {string.Join(", ", missing)}.");
            }
            if (profile.Mode == PilotDataProfileMode.NonRunnable &&
                !missing.ToHashSet(StringComparer.OrdinalIgnoreCase)
                    .SetEquals(profile.MissingRequiredKeys))
            {
                throw new PilotDataConfigurationException(
                    $"Profile '{profile.ProfileId}' missing-key declaration is stale or incomplete.");
            }
            if (!profile.Checksum.Equals(
                    ComputeChecksum(catalog, profile),
                    StringComparison.OrdinalIgnoreCase))
            {
                throw new PilotDataConfigurationException(
                    $"Profile '{profile.ProfileId}' has a stale or mismatched checksum.");
            }
        }

        private static void ValidateKey(string key)
        {
            Require(key, "data key");
            if (!key.Contains('.') ||
                key.Any(char.IsWhiteSpace) ||
                SecretKeyTerms.Any(term =>
                    key.Contains(term, StringComparison.OrdinalIgnoreCase)))
            {
                throw new PilotDataConfigurationException(
                    $"Pilot data key '{key}' is invalid or sensitive.");
            }
        }

        private static void ValidateValue(string value, string key)
        {
            Require(value, $"value for '{key}'");
            if (SyntheticTerms.Any(term =>
                    value.Contains(term, StringComparison.OrdinalIgnoreCase)))
            {
                throw new PilotDataConfigurationException(
                    $"Pilot data value for '{key}' is synthetic or unresolved.");
            }
        }

        private static void RequireHash(string value, string description)
        {
            if (value.Length != 64 ||
                value.Any(character => !Uri.IsHexDigit(character)))
            {
                throw new PilotDataConfigurationException(
                    $"{description} must be a SHA-256 value.");
            }
        }

        private static void RequireUnique(
            IEnumerable<string> values,
            string description)
        {
            var duplicate = values
                .GroupBy(value => value, StringComparer.OrdinalIgnoreCase)
                .FirstOrDefault(group => group.Count() > 1);
            if (duplicate != null)
            {
                throw new PilotDataConfigurationException(
                    $"Duplicate or ambiguous {description} '{duplicate.Key}'.");
            }
        }

        private static void Require(string value, string description)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                value.Contains('\r') ||
                value.Contains('\n') ||
                value.Contains('|'))
            {
                throw new PilotDataConfigurationException(
                    $"{description} is missing or invalid.");
            }
        }
    }

    public sealed class PilotDataConfigurationException : Exception
    {
        public PilotDataConfigurationException(string message)
            : base(message)
        {
        }
    }

    public sealed record ExpertQuoteBopPilotData(
        string FirstName,
        string LastName,
        string DateOfBirth,
        string Phone,
        string Email,
        string SocialSecurityNumber,
        string MaritalStatus,
        string AddressLine1,
        string City,
        string StateName,
        string StateCode,
        string Zip,
        bool ReceivesMail,
        bool IsResidence,
        string Product,
        string BusinessType,
        string DbaName,
        string EffectiveDate,
        bool UseAccountAddress,
        string LessorsRiskExposure,
        string RatingState,
        string AgentCode,
        string PrefillExpectedOutcome,
        string NavigationTarget,
        string QuoteIdentityPattern)
    {
        public static ExpertQuoteBopPilotData From(
            PilotDataResolution resolution)
        {
            ArgumentNullException.ThrowIfNull(resolution);
            if (!resolution.IsRunnable)
            {
                throw new PilotDataConfigurationException(
                    $"Pilot profile '{resolution.Profile.ProfileId}' is non-runnable.");
            }

            return new ExpertQuoteBopPilotData(
                Value("client.firstName"),
                Value("client.lastName"),
                Value("client.dateOfBirth"),
                Value("client.phone"),
                Value("client.email"),
                Value("client.ssn"),
                Value("account.maritalStatus"),
                Value("address.line1"),
                Value("address.city"),
                Value("address.stateName"),
                Value("address.stateCode"),
                Value("address.zip"),
                Boolean("address.receivedMail"),
                Boolean("address.isResidence"),
                Value("proposal.product"),
                Value("proposal.businessType"),
                Value("proposal.dbaName"),
                Value("proposal.effectiveDate"),
                Boolean("proposal.useAccountAddress"),
                Value("proposal.lessorsRiskExposure"),
                Value("proposal.ratingState"),
                Value("proposal.agentCode"),
                Value("prefill.expectedOutcome"),
                Value("navigation.target"),
                Value("quote.identityPattern"));

            string Value(string key) =>
                resolution.Values.TryGetValue(key, out var value) &&
                !string.IsNullOrWhiteSpace(value)
                    ? value
                    : throw new PilotDataConfigurationException(
                        $"Required pilot value '{key}' is missing.");

            bool Boolean(string key) =>
                bool.TryParse(Value(key), out var value)
                    ? value
                    : throw new PilotDataConfigurationException(
                        $"Pilot value '{key}' must be true or false.");
        }
    }
}
