#nullable enable
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Models;
using PnCTestAutomation.QuoteHandoffs;

namespace PnCTestAutomation.DataProfiles
{
    public sealed partial class SgsScenarioData : ISgsScenarioData
    {
        private static readonly string[] InputSections = ["application", "dimensions", "values"];
        private readonly ScenarioContextData _context;
        private readonly IQuoteHandoff _quoteHandoff;
        private readonly SgsScenarioDataOptions _options;
        private SgsScenarioDataState State => _context.SgsData;

        public SgsScenarioData(
            ScenarioContextData scenarioData,
            IQuoteHandoff quoteHandoff,
            SgsScenarioDataOptions? options = null)
        {
            ArgumentNullException.ThrowIfNull(scenarioData);
            ArgumentNullException.ThrowIfNull(quoteHandoff);
            _context = scenarioData;
            _quoteHandoff = quoteHandoff;
            _options = options ?? new SgsScenarioDataOptions();
            ArgumentNullException.ThrowIfNull(_options.TimeProvider);
        }

        public void Load(SgsScenarioDataRequest request)
        {
            State.Reset();
            ArgumentNullException.ThrowIfNull(request);
            if (request.StateVariant is not null && string.IsNullOrWhiteSpace(request.StateVariant))
                throw new SgsScenarioDataException("A supplied SGS state variant must not be empty.");
            if (request.LayerPaths is null)
                throw new SgsScenarioDataException("SGS profile layers must be an explicit non-null list.");

            var files = new SgsVerifiedDataFiles(_options.ResourcesRootPath, request.ProductCode);
            var profile = files.Read(request.ProfilePath);
            if (profile["values"] is not JsonObject)
                throw new SgsScenarioDataException("An SGS profile must contain a values object.");

            foreach (var layerPath in request.LayerPaths)
                profile = MergePatch(profile, files.Read(layerPath));

            if (request.StateOverridesPath is not null)
            {
                var overrides = files.Read(request.StateOverridesPath);
                if (request.StateVariant is null || overrides["overrides"] is not JsonObject variants ||
                    variants[request.StateVariant] is not JsonObject patch)
                {
                    throw new SgsScenarioDataException("The selected SGS state override is absent or invalid.");
                }
                profile = MergePatch(profile, patch);
            }

            if (request.ExternalDataPath is not null)
                profile = MergePatch(profile, UnwrapExternalPatch(files.Read(request.ExternalDataPath)));

            foreach (var section in InputSections)
            {
                if (!profile.TryGetPropertyValue(section, out var node))
                    continue;
                if (node is not JsonObject inputObject)
                    throw new SgsScenarioDataException("SGS input sections must be JSON objects.");
                Flatten(inputObject, section);
            }
            RebuildAliases();
            if (profile["random"] is JsonObject random)
            {
                foreach (var entry in random)
                {
                    ValidateKey(entry.Key);
                    if (entry.Value is not JsonObject definition ||
                        definition["pattern"] is not JsonValue pattern ||
                        !pattern.TryGetValue<string>(out var text) ||
                        !State.RandomPatterns.TryAdd(entry.Key, text))
                        throw new SgsScenarioDataException("A declared random-data pattern is invalid or ambiguous.");
                }
            }
            else if (profile["random"] is not null)
                throw new SgsScenarioDataException("SGS random-data declarations must be an object.");
            ApplyRuntimeOverrides(request.RuntimeOverrides);
            ValidateStateVariant(request.StateVariant, request.StateOverridesPath is not null);
            State.ProductCode = request.ProductCode;
            State.ProfilePath = files.NormalizeRequestPath(request.ProfilePath);
            State.ReferenceDate = _options.TimeProvider.GetLocalNow().Date;
            State.IsLoaded = true;
        }

        public string GetRequired(string key)
        {
            EnsureLoaded();
            return ResolveInput(key, new ResolutionScope());
        }

        public string ResolveRequired(string expression)
        {
            EnsureLoaded();
            return ResolveText(expression, new ResolutionScope());
        }

        public string GenerateRandom(string name)
        {
            EnsureLoaded();
            ValidateKey(name);
            if (IsCredentialKey(name))
                throw new SgsScenarioDataException("Credentials cannot be generated as scenario data.");
            if (NormalizeBufferKey(name) is not ("firstname" or "lastname" or "ownerphone" or "owneremail" or "insuredssn"))
                throw new SgsScenarioDataException("Only declared client identity fields may use source random-data generation.");
            if (State.GeneratedValues.TryGetValue(name, out var existing))
                return existing;
            if (!State.RandomPatterns.TryGetValue(name, out var pattern))
                throw new SgsScenarioDataException($"Required random-data declaration '{name}' is absent.");
            var current = NormalizeBufferKey(name) switch
            {
                "firstname" => _context.ClientFirstName,
                "lastname" => _context.ClientLastName,
                "ownerphone" => _context.ClientPhoneNumber,
                "owneremail" => _context.ClientEmail,
                "insuredssn" => _context.SSN,
                _ => null
            };
            if (!string.IsNullOrEmpty(current))
                throw new SgsScenarioDataException("Source generation cannot replace an already-owned scenario identity.");
            string value;
            try
            {
                value = RandomGenerators.GenerateFromSimplePattern(pattern);
            }
            catch (ArgumentException)
            {
                throw new SgsScenarioDataException($"Random-data declaration '{name}' uses unsupported or oversized syntax.");
            }
            CaptureBuffer(name, value);
            State.GeneratedValues.Add(name, value);
            return value;
        }

        public void ValidateRequiredInputs(IEnumerable<string> keys)
        {
            ArgumentNullException.ThrowIfNull(keys);
            EnsureLoaded();
            foreach (var key in keys)
                GetRequired(key);
        }

        public bool TryGetOptional(string key, [NotNullWhen(true)] out string? value)
        {
            EnsureLoaded();
            if (FindInputKey(key) is null)
            {
                value = null;
                return false;
            }
            value = GetRequired(key);
            return true;
        }

        public void CaptureBuffer(string key, string value)
        {
            EnsureLoaded();
            ValidateKey(key);
            RequireUsable(value);
            RejectExpressionMarkers(value);
            if (IsCredentialKey(key))
                throw new SgsScenarioDataException("Credentials cannot be captured in SGS state; use the current external credential provider.");

            switch (NormalizeBufferKey(key))
            {
                case "quotenum":
                case "quotenumber":
                case "proposalnumber":
                    if (value.Trim().Length > 128)
                        throw new SgsScenarioDataException("A captured quote identity exceeds the domain contract length.");
                    _quoteHandoff.Publish(value);
                    return;
                case "firstname": _context.ClientFirstName = value; return;
                case "lastname": _context.ClientLastName = value; return;
                case "middlename":
                case "middleinitial": _context.ClientMiddleName = value; return;
                case "dob":
                case "dateofbirth": _context.ClientDOB = value; return;
                case "ownerphone": _context.ClientPhoneNumber = value; return;
                case "owneremail": _context.ClientEmail = value; return;
                case "insuredssn":
                case "ssn": _context.SSN = value; return;
                case "effdate":
                case "effectivedate": _context.EffectiveDate = value; return;
                default: State.Captures[key] = value; return;
            }
        }

        public string GetRequiredBuffer(string key)
        {
            EnsureLoaded();
            return ResolveBuffer(key, new ResolutionScope());
        }

        private void EnsureLoaded()
        {
            if (!State.IsLoaded)
                throw new SgsScenarioDataException("SGS scenario data has not been successfully loaded.");
        }

        private void Flatten(JsonObject source, string prefix)
        {
            foreach (var item in source)
            {
                ValidateKey(item.Key);
                var key = prefix + "." + item.Key;
                if (item.Value is JsonObject nested)
                {
                    Flatten(nested, key);
                    continue;
                }

                var value = item.Value is JsonValue scalar
                    ? scalar.TryGetValue<string>(out var text) ? text : scalar.ToJsonString()
                    : null;
                ValidateCredentialStorage(key, value);
                if (!State.Inputs.TryAdd(key, new SgsDataInput(value, item.Value is not JsonArray)))
                    throw new SgsScenarioDataException("SGS nested and dotted keys collide; the profile needs unambiguous qualified paths.");
            }
        }

        private void RebuildAliases()
        {
            State.Aliases.Clear();
            foreach (var key in State.Inputs.Keys)
            {
                for (var separator = key.IndexOf('.'); separator >= 0; separator = key.IndexOf('.', separator + 1))
                {
                    if (State.Inputs.ContainsKey(key[..separator]))
                        throw new SgsScenarioDataException("SGS input paths cannot be both a scalar and a parent of another input.");
                }
                AddAlias(key[(key.IndexOf('.') + 1)..], key);
                AddAlias(key[(key.LastIndexOf('.') + 1)..], key);
            }
        }

        private void AddAlias(string alias, string key)
        {
            if (State.Inputs.ContainsKey(alias) && !alias.Equals(key, StringComparison.OrdinalIgnoreCase))
                throw new SgsScenarioDataException("An SGS leaf alias collides with a qualified input path.");
            if (!State.Aliases.TryGetValue(alias, out var targets))
            {
                targets = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                State.Aliases.Add(alias, targets);
            }
            targets.Add(key);
        }

        private string? FindInputKey(string key)
        {
            ValidateKey(key);
            if (State.Inputs.ContainsKey(key))
                return key;
            if (!State.Aliases.TryGetValue(key, out var targets))
                return null;
            if (targets.Count != 1)
                throw new SgsScenarioDataException($"SGS input alias '{key}' is ambiguous; use its full application, dimensions or values path.");
            return targets.Single();
        }

        private void ApplyRuntimeOverrides(IReadOnlyDictionary<string, string?>? overrides)
        {
            if (overrides is null)
                return;

            var resolved = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);
            foreach (var item in overrides)
            {
                ValidateKey(item.Key);
                if (IsQuoteKey(item.Key))
                    throw new SgsScenarioDataException("Runtime quote identity must be published through IQuoteHandoff, not SGS input overrides.");
                var key = FindInputKey(item.Key) ?? (InputSections.Any(section =>
                    item.Key.StartsWith(section + ".", StringComparison.OrdinalIgnoreCase))
                    ? item.Key
                    : "values." + item.Key);
                ValidateCredentialStorage(key, item.Value);
                if (!resolved.TryAdd(key, item.Value))
                    throw new SgsScenarioDataException("Multiple SGS runtime overrides target the same qualified input.");
            }
            foreach (var item in resolved)
            {
                if (item.Value is null)
                    State.Inputs.Remove(item.Key);
                else
                    State.Inputs[item.Key] = new SgsDataInput(item.Value, true);
            }
            RebuildAliases();
        }

        private void ValidateStateVariant(string? requested, bool selectedOverride)
        {
            var declared = new List<string>();
            foreach (var key in new[] { "dimensions.stateVariant", "values.state_variant" })
            {
                if (!State.Inputs.TryGetValue(key, out var input))
                    continue;
                if (!input.IsScalar)
                    throw new SgsScenarioDataException("An SGS state variant must be scalar.");
                RequireUsable(input.Value);
                RejectExpressionMarkers(input.Value!);
                declared.Add(input.Value!);
            }
            var variant = requested ?? declared.FirstOrDefault();
            if ((requested is not null && declared.Count == 0 && !selectedOverride) ||
                declared.Any(value => !value.Equals(variant, StringComparison.OrdinalIgnoreCase)))
            {
                throw new SgsScenarioDataException("The requested SGS state variant does not match the effective profile.");
            }
            State.StateVariant = variant;
        }

        private static JsonObject MergePatch(JsonObject target, JsonObject patch)
        {
            var result = (JsonObject)target.DeepClone();
            foreach (var item in patch)
            {
                if (item.Value is null)
                    result.Remove(item.Key);
                else if (item.Value is JsonObject nested)
                    result[item.Key] = MergePatch(result[item.Key] as JsonObject ?? new JsonObject(
                        new JsonNodeOptions { PropertyNameCaseInsensitive = true }), nested);
                else
                    result[item.Key] = item.Value.DeepClone();
            }
            return result;
        }

        private static JsonObject UnwrapExternalPatch(JsonObject patch)
        {
            if (patch["values"] is not JsonObject values)
                return patch;
            foreach (var item in values.ToArray())
            {
                if (item.Value is JsonObject wrapper && wrapper.ContainsKey("value") &&
                    wrapper.All(field => field.Key.Equals("value", StringComparison.OrdinalIgnoreCase) ||
                        field.Key.Equals("replaceRequired", StringComparison.OrdinalIgnoreCase) ||
                        field.Key.Equals("source", StringComparison.OrdinalIgnoreCase) ||
                        field.Key.Equals("note", StringComparison.OrdinalIgnoreCase)))
                {
                    values[item.Key] = wrapper["value"]?.DeepClone();
                }
            }
            return patch;
        }

        private static void ValidateKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key) || key.Length > 256 || key.Any(char.IsControl) ||
                key.IndexOfAny(['{', '}', '[', ']']) >= 0 || key != key.Trim())
            {
                throw new SgsScenarioDataException("An SGS input or buffer key is empty or contains unsupported characters.");
            }
        }

        private static string NormalizeBufferKey(string key) =>
            key.Replace(" ", "", StringComparison.Ordinal)
                .Replace("_", "", StringComparison.Ordinal).ToLowerInvariant();

        private static bool IsQuoteKey(string key) =>
            NormalizeBufferKey(key[(key.LastIndexOf('.') + 1)..]) is "quotenum" or "quotenumber" or "proposalnumber";

        private static bool IsCredentialKey(string key)
        {
            var name = Regex.Replace(key[(key.LastIndexOf('.') + 1)..], "[^a-zA-Z]", "").ToLowerInvariant();
            return name.Contains("password", StringComparison.Ordinal) ||
                   name.Contains("secret", StringComparison.Ordinal) ||
                   name is "username" or "equsername" or "expressusername" or "apikey" or "accesstoken";
        }

        private static void ValidateCredentialStorage(string key, string? value)
        {
            if (IsCredentialKey(key) && !string.IsNullOrWhiteSpace(value) &&
                !Regex.IsMatch(value, @"\A\{\{env:[A-Za-z_][A-Za-z0-9_]*\}\}\z", RegexOptions.IgnoreCase))
            {
                throw new SgsScenarioDataException("SGS credentials must remain external environment references, never literal profile or runtime-override values.");
            }
        }
    }
}
