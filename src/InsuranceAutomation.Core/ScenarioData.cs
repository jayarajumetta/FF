using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace InsuranceAutomation.Core;

public sealed class ScenarioData
{
    private static readonly HashSet<string> AllowedExternalKeys = new(StringComparer.OrdinalIgnoreCase)
    {
        "url",
        "username",
        "password"
    };

    private readonly Dictionary<string, string> _static = new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, string> _runtime = new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, string> _external = new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, string> _randomPatterns = new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, int> _stepTimeouts = new(StringComparer.OrdinalIgnoreCase);
    private readonly FrameworkConfig _config;

    public ScenarioData(FrameworkConfig config) => _config = config;

    public string CurrentFile { get; private set; } = string.Empty;
    public string CurrentFlow { get; private set; } = string.Empty;
    public bool IsLoaded => !string.IsNullOrWhiteSpace(CurrentFile);

    public void Load(string scenarioFile, string externalFile) =>
        Load(scenarioFile, externalFile, null);

    public void Load(string scenarioFile, string externalFile, string? flowName)
    {
        Reset();
        CurrentFile = scenarioFile;
        CurrentFlow = flowName?.Trim() ?? string.Empty;

        if (!File.Exists(scenarioFile))
            throw new FileNotFoundException($"Scenario data file was not found: {scenarioFile}", scenarioFile);

        using var document = JsonDocument.Parse(File.ReadAllText(scenarioFile));
        var root = document.RootElement;
        if (root.ValueKind != JsonValueKind.Object)
            throw new InvalidOperationException($"Scenario data must be a JSON object: {scenarioFile}");

        PopulateData(root);
        PopulateSelectedFlow(root, CurrentFlow);
        PopulateStateDefaults(root);
        LoadExternalData(externalFile);
        LoadStepTimeouts(FindTestDataRoot(scenarioFile), CurrentFlow);
        PrimeScenarioAliases();
    }

    private void Reset()
    {
        _static.Clear();
        _runtime.Clear();
        _external.Clear();
        _randomPatterns.Clear();
        _stepTimeouts.Clear();
        CurrentFile = string.Empty;
        CurrentFlow = string.Empty;
    }

    private void PopulateSelectedFlow(JsonElement root, string flowName)
    {
        if (!TryGetPropertyIgnoreCase(root, "flows", out var flows) || flows.ValueKind != JsonValueKind.Object)
            return;

        if (string.IsNullOrWhiteSpace(flowName))
        {
            var available = string.Join(", ", flows.EnumerateObject().Select(item => item.Name));
            throw new InvalidOperationException(
                $"Scenario data '{CurrentFile}' contains multiple flows. Pass the current feature name when loading it. Available flows: {available}");
        }

        if (!TryGetPropertyIgnoreCase(flows, flowName, out var flow) || flow.ValueKind != JsonValueKind.Object)
        {
            var available = string.Join(", ", flows.EnumerateObject().Select(item => item.Name));
            throw new InvalidOperationException(
                $"Flow '{flowName}' is not defined in scenario data '{CurrentFile}'. Available flows: {available}");
        }

        PopulateData(flow);
    }

    private void PopulateData(JsonElement element)
    {
        // Direct state files keep business values flat. The dimensions section remains readable
        // for backward compatibility, but generated files use only values and random.
        ReadFlatObject(element, "application", _static);
        ReadFlatObject(element, "dimensions", _static);
        ReadFlatObject(element, "values", _static);
        ReadRandomPatterns(element);
    }

    private void PopulateStateDefaults(JsonElement root)
    {
        if (!TryGetPropertyIgnoreCase(root, "state", out var state) || state.ValueKind != JsonValueKind.Object)
            return;

        AddStateDefault(state, "stateCode", "code", "stateCode");
        AddStateDefault(state, "stateName", "name", "stateName");
        AddStateDefault(state, "stateVariant", "variant", "stateVariant");
    }

    private void AddStateDefault(JsonElement state, string targetKey, params string[] sourceKeys)
    {
        if (_static.ContainsKey(targetKey))
            return;

        foreach (var sourceKey in sourceKeys)
        {
            if (!TryGetPropertyIgnoreCase(state, sourceKey, out var value))
                continue;
            _static[targetKey] = ToText(value);
            return;
        }
    }

    private void ReadRandomPatterns(JsonElement element)
    {
        if (!TryGetPropertyIgnoreCase(element, "random", out var random) || random.ValueKind != JsonValueKind.Object)
            return;

        foreach (var property in random.EnumerateObject())
        {
            if (property.Value.ValueKind == JsonValueKind.Object &&
                TryGetPropertyIgnoreCase(property.Value, "pattern", out var pattern))
            {
                _randomPatterns[property.Name] = ToText(pattern);
            }
            else
            {
                _randomPatterns[property.Name] = ToText(property.Value);
            }
        }
    }

    private void LoadExternalData(string externalFile)
    {
        if (string.IsNullOrWhiteSpace(externalFile) || !File.Exists(externalFile))
            return;

        using var document = JsonDocument.Parse(File.ReadAllText(externalFile));
        var root = document.RootElement;
        if (root.ValueKind != JsonValueKind.Object)
            throw new InvalidOperationException($"External override file must be a JSON object: {externalFile}");

        if (TryGetPropertyIgnoreCase(root, "application", out var application) && application.ValueKind == JsonValueKind.Object)
            ReadAllowedExternalObject(application, externalFile);

        // A compact top-level form is accepted for local/private override files.
        foreach (var property in root.EnumerateObject())
        {
            if (property.Name.StartsWith('_') || property.Name.Equals("application", StringComparison.OrdinalIgnoreCase))
                continue;

            if (property.Name.Equals("values", StringComparison.OrdinalIgnoreCase) && property.Value.ValueKind == JsonValueKind.Object)
            {
                ReadLegacyAllowedValues(property.Value, externalFile);
                continue;
            }

            if (!AllowedExternalKeys.Contains(property.Name))
                throw new InvalidOperationException(
                    $"External override '{property.Name}' is not allowed in '{externalFile}'. Only url, username and password may be external. Business data belongs in the direct state files.");

            _external[property.Name] = ToText(property.Value);
        }
    }

    private void ReadAllowedExternalObject(JsonElement element, string sourceFile)
    {
        foreach (var property in element.EnumerateObject())
        {
            if (!AllowedExternalKeys.Contains(property.Name))
                throw new InvalidOperationException(
                    $"External application override '{property.Name}' is not allowed in '{sourceFile}'. Allowed keys: url, username, password.");
            _external[property.Name] = ToText(property.Value);
        }
    }

    private void ReadLegacyAllowedValues(JsonElement element, string sourceFile)
    {
        foreach (var property in element.EnumerateObject())
        {
            if (!AllowedExternalKeys.Contains(property.Name))
                throw new InvalidOperationException(
                    $"External value override '{property.Name}' is not allowed in '{sourceFile}'. Allowed keys: url, username, password.");

            var value = property.Value;
            if (value.ValueKind == JsonValueKind.Object && TryGetPropertyIgnoreCase(value, "value", out var nestedValue))
                value = nestedValue;
            _external[property.Name] = ToText(value);
        }
    }

    private void LoadStepTimeouts(string? testDataRoot, string flowName)
    {
        if (string.IsNullOrWhiteSpace(testDataRoot))
            return;

        var timeoutFile = Path.Combine(testDataRoot, "StepTimeouts.json");
        if (!File.Exists(timeoutFile))
            return;

        using var document = JsonDocument.Parse(File.ReadAllText(timeoutFile));
        var root = document.RootElement;
        if (root.ValueKind != JsonValueKind.Object)
            throw new InvalidOperationException($"Step timeout configuration must be a JSON object: {timeoutFile}");

        ReadTimeoutMap(root, "steps", _stepTimeouts);

        if (!TryGetPropertyIgnoreCase(root, "features", out var features) || features.ValueKind != JsonValueKind.Object)
            return;

        if (TryGetPropertyIgnoreCase(features, "*", out var allFeatures) && allFeatures.ValueKind == JsonValueKind.Object)
        {
            if (TryGetPropertyIgnoreCase(allFeatures, "steps", out var allSteps) && allSteps.ValueKind == JsonValueKind.Object)
                ReadTimeoutObject(allSteps, _stepTimeouts, timeoutFile);
            else
                ReadTimeoutObject(allFeatures, _stepTimeouts, timeoutFile);
        }

        if (!string.IsNullOrWhiteSpace(flowName) &&
            TryGetPropertyIgnoreCase(features, flowName, out var feature) && feature.ValueKind == JsonValueKind.Object)
        {
            if (TryGetPropertyIgnoreCase(feature, "steps", out var steps) && steps.ValueKind == JsonValueKind.Object)
                ReadTimeoutObject(steps, _stepTimeouts, timeoutFile);
            else
                ReadTimeoutObject(feature, _stepTimeouts, timeoutFile);
        }
    }

    private static void ReadTimeoutMap(JsonElement element, string propertyName, IDictionary<string, int> target)
    {
        if (!TryGetPropertyIgnoreCase(element, propertyName, out var timeouts) || timeouts.ValueKind != JsonValueKind.Object)
            return;
        ReadTimeoutObject(timeouts, target, propertyName);
    }

    private static void ReadTimeoutObject(JsonElement timeouts, IDictionary<string, int> target, string source)
    {
        foreach (var property in timeouts.EnumerateObject())
        {
            if (property.Name.StartsWith('_'))
                continue;
            target[property.Name] = ParseTimeoutMilliseconds(property.Value, source, property.Name);
        }
    }

    private static int ParseTimeoutMilliseconds(JsonElement value, string source, string key)
    {
        if (value.ValueKind == JsonValueKind.Number && value.TryGetInt32(out var milliseconds) && milliseconds > 0)
            return milliseconds;

        var text = ToText(value).Trim();
        var match = Regex.Match(text, @"^(\d+(?:\.\d+)?)\s*(ms|s|m)?$", RegexOptions.IgnoreCase);
        if (!match.Success)
            throw new InvalidOperationException($"Invalid timeout '{text}' for '{key}' in {source}. Use milliseconds, 45s or 2m.");

        var amount = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
        var multiplier = match.Groups[2].Value.ToLowerInvariant() switch
        {
            "m" => 60_000d,
            "s" => 1_000d,
            _ => 1d
        };
        var result = checked((int)Math.Round(amount * multiplier, MidpointRounding.AwayFromZero));
        if (result <= 0)
            throw new InvalidOperationException($"Timeout for '{key}' in {source} must be greater than zero.");
        return result;
    }

    public int? GetStepTimeoutMs(string stepText)
    {
        if (_stepTimeouts.Count == 0 || string.IsNullOrWhiteSpace(stepText))
            return null;

        var normalized = stepText.Trim();
        if (_stepTimeouts.TryGetValue(normalized, out var exact))
            return exact;

        // Feature-specific entries are loaded after global entries, so inspect wildcard
        // patterns in reverse order to preserve the same override precedence.
        foreach (var item in _stepTimeouts.Reverse())
        {
            if (!item.Key.Contains('*'))
                continue;
            var pattern = "^" + Regex.Escape(item.Key).Replace("\\*", ".*", StringComparison.Ordinal) + "$";
            if (Regex.IsMatch(normalized, pattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
                return item.Value;
        }

        return _stepTimeouts.TryGetValue("*", out var fallback) ? fallback : null;
    }

    private static string? FindTestDataRoot(string scenarioFile)
    {
        var directory = new DirectoryInfo(Path.GetDirectoryName(Path.GetFullPath(scenarioFile)) ?? string.Empty);
        while (directory is not null)
        {
            if (directory.Name.Equals("TestData", StringComparison.OrdinalIgnoreCase))
                return directory.FullName;
            directory = directory.Parent;
        }
        return null;
    }

    private void PrimeScenarioAliases()
    {
        if (_static.TryGetValue("product_lob", out var lob) && !string.IsNullOrWhiteSpace(lob))
            _runtime["Product (LOB)"] = lob;
        if (_static.TryGetValue("state", out var state) && !string.IsNullOrWhiteSpace(state))
            _runtime["State"] = state;
        if (_static.TryGetValue("primaryratingstate", out var ratingState) && !string.IsNullOrWhiteSpace(ratingState))
            _runtime["PrimaryRatingState"] = ratingState;
    }

    public string GetRequired(string key)
    {
        var value = Get(key);
        if (string.IsNullOrWhiteSpace(value) || IsSynthetic(value))
            throw new InvalidOperationException($"Required test data '{key}' is missing or still synthetic. Scenario data: {CurrentFile}; Flow: {CurrentFlow}");
        return value;
    }

    public string Get(string key, string fallback = "")
    {
        if (_runtime.TryGetValue(key, out var runtimeValue))
            return runtimeValue;
        if (_external.TryGetValue(key, out var externalValue) && !IsSynthetic(externalValue))
            return externalValue;
        if (_static.TryGetValue(key, out var staticValue))
            return staticValue;
        return fallback;
    }

    public static bool IsSynthetic(string? value) =>
        string.IsNullOrWhiteSpace(value) || value.Equals("SYNTHETIC_REPLACE_ME", StringComparison.OrdinalIgnoreCase);

    public void SetRuntime(string key, string value) => _runtime[key] = value;
    public void Set(string key, string value) => SetRuntime(key, value);

    public string GenerateRandom(string key, string? pattern = null)
    {
        if (_runtime.TryGetValue(key, out var existing))
            return existing;

        var effectivePattern = string.IsNullOrWhiteSpace(pattern) && _randomPatterns.TryGetValue(key, out var configured)
            ? configured
            : pattern ?? string.Empty;
        var value = RandomData.Generate(effectivePattern);
        _runtime[key] = value;
        return value;
    }

    public string Random(string key, string pattern) => GenerateRandom(key, pattern);

    public string BuildQuoteDescription(string? flow = null)
    {
        static string Token(string value, string fallback) =>
            string.Concat((string.IsNullOrWhiteSpace(value) ? fallback : value).Where(char.IsLetterOrDigit)).ToUpperInvariant();

        var state = Token(Get("stateCode", Get("state", "NA")), "NA");
        var lob = Token(Get("product_lob", Get("Product (LOB)", "CLDC")), "CLDC");
        var random = GenerateRandom("QuoteDescriptionRandom", "^[A-Z0-9]{4}$").ToUpperInvariant();
        var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        var flowPart = string.IsNullOrWhiteSpace(flow) ? string.Empty : "_" + Token(flow, "FLOW");
        return $"{state}_{lob}_{random}_{timestamp}{flowPart}";
    }

    public string Resolve(string expression)
    {
        if (string.IsNullOrEmpty(expression))
            return string.Empty;

        var resolved = Regex.Replace(
            expression,
            @"\{\{(data|runtime|external|env):([^}]+)\}\}",
            match => match.Groups[1].Value.Equals("env", StringComparison.OrdinalIgnoreCase)
                ? Environment.GetEnvironmentVariable(match.Groups[2].Value) ?? string.Empty
                : Get(match.Groups[2].Value));

        // Legacy runtime aliases remain supported while feature code is progressively normalised.
        resolved = Regex.Replace(resolved, @"\{B\[([^\]]+)\]\}", match => Get(match.Groups[1].Value));
        resolved = Regex.Replace(resolved, @"\{PL\[([^\]]+)\]\}", match => Get(match.Groups[1].Value));

        for (var pass = 0; pass < 5; pass++)
        {
            var before = resolved;
            resolved = Regex.Replace(resolved, @"\{STRINGREPLACE\[([^\]]*)\]\[([^\]]*)\]\[([^\]]*)\]\}", match =>
            {
                var input = Unquote(match.Groups[1].Value);
                var oldValue = Unquote(match.Groups[2].Value).Replace("\\)", ")", StringComparison.Ordinal);
                var newValue = Unquote(match.Groups[3].Value);
                return input.Replace(oldValue, newValue, StringComparison.Ordinal);
            }, RegexOptions.IgnoreCase);
            resolved = Regex.Replace(resolved, @"\{STRINGTOUPPER\[([^\]]*)\]\}",
                match => Unquote(match.Groups[1].Value).ToUpperInvariant(), RegexOptions.IgnoreCase);
            resolved = Regex.Replace(resolved, @"\{DATE\[([^\]]*)\]\[([^\]]*)\]\[([^\]]*)\]\}",
                match => ResolveDate(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value), RegexOptions.IgnoreCase);
            if (resolved == before)
                break;
        }
        return resolved;
    }

    public bool Condition(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression))
            return true;

        var normalized = expression.Trim();
        if (normalized.Contains(';'))
            normalized = normalized[(normalized.LastIndexOf(';') + 1)..].Trim();
        normalized = normalized.Replace("||", " OR ", StringComparison.Ordinal).Replace("&&", " AND ", StringComparison.Ordinal);
        try
        {
            return EvaluateOr(normalized);
        }
        catch when (!_config.Execution.StrictUnknownConditions)
        {
            return false;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Unsupported data condition '{expression}'. It was not executed silently. {ex.Message}", ex);
        }
    }

    private bool EvaluateOr(string expression)
    {
        var parts = SplitTopLevel(expression, " OR ");
        return parts.Count > 1 ? parts.Any(EvaluateAnd) : EvaluateAnd(expression);
    }

    private bool EvaluateAnd(string expression)
    {
        var parts = SplitTopLevel(expression, " AND ");
        return parts.Count > 1 ? parts.All(EvaluateAtom) : EvaluateAtom(expression);
    }

    private bool EvaluateAtom(string expression)
    {
        var value = expression.Trim();
        while (value.StartsWith('(') && value.EndsWith(')') && Balanced(value[1..^1]))
            value = value[1..^1].Trim();
        if (value.StartsWith("NOT(", StringComparison.OrdinalIgnoreCase) && value.EndsWith(')'))
            return !EvaluateOr(value[4..^1]);
        if (value.StartsWith("NOT ", StringComparison.OrdinalIgnoreCase))
            return !EvaluateAtom(value[4..]);

        var match = Regex.Match(value, @"^(?:['""](.+?)['""]|([A-Za-z0-9 _().:*#/-]+?))\s*(==|!=)\s*(?:['""](.*?)['""]|NULL)$", RegexOptions.IgnoreCase);
        if (!match.Success)
            throw new InvalidOperationException("No supported data comparison was found.");

        var key = (match.Groups[1].Success ? match.Groups[1].Value : match.Groups[2].Value).Trim().Trim('\'', '"');
        var operation = match.Groups[3].Value;
        var expected = match.Groups[4].Success ? match.Groups[4].Value.Trim().Trim('\'', '"') : string.Empty;
        if (expected.Equals("NULL", StringComparison.OrdinalIgnoreCase))
            expected = string.Empty;
        var actual = Get(key);
        var equal = string.Equals(actual, expected, StringComparison.OrdinalIgnoreCase);
        return operation == "==" ? equal : !equal;
    }

    private static List<string> SplitTopLevel(string expression, string separator)
    {
        var result = new List<string>();
        var depth = 0;
        var quote = '\0';
        var start = 0;
        for (var index = 0; index <= expression.Length - separator.Length; index++)
        {
            var current = expression[index];
            if (current is '\'' or '"')
            {
                if (quote == '\0') quote = current;
                else if (quote == current) quote = '\0';
            }
            if (quote != '\0') continue;
            if (current == '(') depth++;
            else if (current == ')') depth--;
            if (depth == 0 && expression.AsSpan(index, separator.Length).Equals(separator, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(expression[start..index].Trim());
                start = index + separator.Length;
                index = start - 1;
            }
        }
        if (start == 0)
            return new List<string> { expression };
        result.Add(expression[start..].Trim());
        return result;
    }

    private static bool Balanced(string expression)
    {
        var depth = 0;
        foreach (var current in expression)
        {
            if (current == '(') depth++;
            else if (current == ')' && --depth < 0) return false;
        }
        return depth == 0;
    }

    private static string Unquote(string value)
    {
        var text = (value ?? string.Empty).Trim();
        if (text.Length >= 2 && ((text[0] == '"' && text[^1] == '"') || (text[0] == '\'' && text[^1] == '\'')))
            return text[1..^1];
        return text;
    }

    private static string ResolveDate(string baseValue, string offset, string format)
    {
        var date = DateTime.Today;
        var baseText = Unquote(baseValue);
        if (!string.IsNullOrWhiteSpace(baseText) && DateTime.TryParse(baseText, out var parsed))
            date = parsed;

        var delta = Unquote(offset).Trim();
        var match = Regex.Match(delta, @"^([+-]?\d+)\s*([dmy])$", RegexOptions.IgnoreCase);
        if (match.Success)
        {
            var amount = int.Parse(match.Groups[1].Value);
            date = match.Groups[2].Value.ToLowerInvariant() switch
            {
                "d" => date.AddDays(amount),
                "m" => date.AddMonths(amount),
                "y" => date.AddYears(amount),
                _ => date
            };
        }

        var dotnetFormat = Unquote(format);
        return date.ToString(string.IsNullOrWhiteSpace(dotnetFormat) ? "MM-dd-yyyy" : dotnetFormat);
    }

    public IReadOnlyDictionary<string, string> Snapshot()
    {
        var result = new Dictionary<string, string>(_static, StringComparer.OrdinalIgnoreCase);
        foreach (var item in _runtime)
            result[item.Key] = item.Value;
        foreach (var item in _external)
            result[item.Key] = item.Value;

        foreach (var key in result.Keys.Where(IsSecretKey).ToArray())
            result[key] = "***";
        return result;
    }

    private static bool IsSecretKey(string key) =>
        key.Contains("password", StringComparison.OrdinalIgnoreCase) ||
        key.Contains("secret", StringComparison.OrdinalIgnoreCase) ||
        key.Contains("token", StringComparison.OrdinalIgnoreCase) ||
        key.Contains("authorization", StringComparison.OrdinalIgnoreCase);

    private static void ReadFlatObject(JsonElement root, string name, IDictionary<string, string> target)
    {
        if (!TryGetPropertyIgnoreCase(root, name, out var value) || value.ValueKind != JsonValueKind.Object)
            return;
        foreach (var property in value.EnumerateObject())
            target[property.Name] = ToText(property.Value);
    }

    private static bool TryGetPropertyIgnoreCase(JsonElement element, string name, out JsonElement value)
    {
        if (element.ValueKind == JsonValueKind.Object)
        {
            foreach (var property in element.EnumerateObject())
            {
                if (!property.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    continue;
                value = property.Value;
                return true;
            }
        }
        value = default;
        return false;
    }

    private static string ToText(JsonElement value) => value.ValueKind switch
    {
        JsonValueKind.String => value.GetString() ?? string.Empty,
        JsonValueKind.Null or JsonValueKind.Undefined => string.Empty,
        _ => value.ToString()
    };
}

public static class RandomData
{
    public static string Generate(string pattern)
    {
        pattern = (pattern ?? string.Empty).Trim().TrimStart('^').TrimEnd('$');
        if (string.IsNullOrWhiteSpace(pattern))
            return Guid.NewGuid().ToString("N")[..10];

        var output = new System.Text.StringBuilder();
        for (var index = 0; index < pattern.Length;)
        {
            if (pattern[index] == '\\' && index + 1 < pattern.Length)
            {
                output.Append(pattern[index + 1]);
                index += 2;
                continue;
            }
            if (pattern[index] == '[')
            {
                var close = pattern.IndexOf(']', index);
                if (close < 0)
                {
                    output.Append(pattern[index++]);
                    continue;
                }
                var characterClass = pattern[(index + 1)..close];
                var count = 1;
                var countMatch = Regex.Match(pattern[(close + 1)..], @"^\{(\d+)\}");
                if (countMatch.Success)
                {
                    count = int.Parse(countMatch.Groups[1].Value);
                    close += countMatch.Length;
                }
                for (var item = 0; item < count; item++)
                {
                    output.Append(characterClass.Contains("A-Z", StringComparison.Ordinal)
                        ? (char)('A' + Random.Shared.Next(26))
                        : characterClass.Contains("a-z", StringComparison.Ordinal)
                            ? (char)('a' + Random.Shared.Next(26))
                            : (char)('0' + Random.Shared.Next(10)));
                }
                index = close + 1;
                continue;
            }
            output.Append(pattern[index++]);
        }
        return output.ToString();
    }
}
