using System.Text.Json;
using System.Text.RegularExpressions;
namespace InsuranceAutomation.Core;
public sealed class ScenarioData
{
    private readonly Dictionary<string, string> _static = new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, string> _runtime = new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, string> _external = new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, string> _randomPatterns = new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, string> _canonicalFields = new(StringComparer.OrdinalIgnoreCase);
    private readonly FrameworkConfig _config;
    public ScenarioData(FrameworkConfig config) => _config = config;
    public string CurrentFile { get; private set; } = string.Empty;
    public bool IsLoaded => !string.IsNullOrWhiteSpace(CurrentFile);
    public void Load(string scenarioFile, string externalFile)
    {
        _static.Clear();
        _runtime.Clear();
        _external.Clear();
        _randomPatterns.Clear();
        _canonicalFields.Clear();
        CurrentFile = scenarioFile;
        using var document = JsonDocument.Parse(File.ReadAllText(scenarioFile));
        var root = document.RootElement;
        ReadFlatObject(root, "application", _static);
        ReadFlatObject(root, "dimensions", _static);
        ReadFlatObject(root, "values", _static);
        if (root.TryGetProperty("random", out var random) && random.ValueKind == JsonValueKind.Object)
        {
            foreach (var property in random.EnumerateObject())
            {
                if (property.Value.TryGetProperty("pattern", out var pattern))
                {
                    _randomPatterns[property.Name] = pattern.GetString() ?? string.Empty;
                }
            }
        }
        // Canonical fields are optional source-backed test-data aliases.
        if (root.TryGetProperty("_canonical", out var canonical) && canonical.ValueKind == JsonValueKind.Object &&
            canonical.TryGetProperty("fields", out var fields) && fields.ValueKind == JsonValueKind.Array)
        {
            foreach (var field in fields.EnumerateArray())
            {
                if (!field.TryGetProperty("field", out var fieldNameElement)) continue;
                var fieldName = fieldNameElement.GetString() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(fieldName)) continue;
                var value = field.TryGetProperty("value", out var valueElement)
                    ? valueElement.ValueKind == JsonValueKind.String ? valueElement.GetString() ?? string.Empty : valueElement.ToString()
                    : string.Empty;
                _canonicalFields[fieldName] = value;
                if (field.TryGetProperty("businessName", out var businessNameElement))
                {
                    var businessName = businessNameElement.GetString() ?? string.Empty;
                    if (!string.IsNullOrWhiteSpace(businessName)) _canonicalFields[businessName] = value;
                }
            }
        }
        PrimeScenarioAliases();
        if (File.Exists(externalFile))
        {
            using var externalDocument = JsonDocument.Parse(File.ReadAllText(externalFile));
            var externalRoot = externalDocument.RootElement;
            Flatten(externalRoot, string.Empty, _external);
            // ExternalDataOverrides.json uses { "values": { "Business Key": { "value": "..." } } }.
            // Make the business key directly resolvable without exposing the file structure to tests.
            if (externalRoot.TryGetProperty("values", out var values) && values.ValueKind == JsonValueKind.Object)
            {
                foreach (var property in values.EnumerateObject())
                {
                    if (property.Value.ValueKind == JsonValueKind.Object &&
                        property.Value.TryGetProperty("value", out var valueElement))
                    {
                        _external[property.Name] = valueElement.ValueKind == JsonValueKind.String
                            ? valueElement.GetString() ?? string.Empty
                            : valueElement.ToString();
                    }
                }
            }
        }
    }
    public void LoadSmoke(string baseFile, string stateCode, string stateName, string stateOverridesFile, string externalFile)
    {
        Load(baseFile, externalFile);
        var normalizedState = (stateCode ?? string.Empty).Trim().ToUpperInvariant();
        var normalizedName = (stateName ?? string.Empty).Trim();
        if (string.IsNullOrWhiteSpace(normalizedState))
            throw new InvalidOperationException("CLDC smoke stateCode is required.");
        _runtime["State"] = normalizedState;
        _runtime["state"] = normalizedState;
        _runtime["stateCode"] = normalizedState;
        _runtime["statecode"] = normalizedState;
        _runtime["stateVariant"] = normalizedState;
        _runtime["state_variant"] = normalizedState;
        _runtime["StateName"] = normalizedName;
        _runtime["stateName"] = normalizedName;
        _runtime["statename"] = normalizedName;
        _runtime["state_name"] = normalizedName;
        if (!File.Exists(stateOverridesFile)) return;
        using var overrideDocument = JsonDocument.Parse(File.ReadAllText(stateOverridesFile));
        var overrideRoot = overrideDocument.RootElement;
        if (!overrideRoot.TryGetProperty("overrides", out var allOverrides) || allOverrides.ValueKind != JsonValueKind.Object) return;
        var product = Get("productCode", Get("product_lob")).Trim();
        if (string.IsNullOrWhiteSpace(product) || !allOverrides.TryGetProperty(product, out var productOverrides) || productOverrides.ValueKind != JsonValueKind.Object) return;
        if (!productOverrides.TryGetProperty(normalizedState, out var stateOverride) || stateOverride.ValueKind != JsonValueKind.Object) return;
        if (!stateOverride.TryGetProperty("values", out var values) || values.ValueKind != JsonValueKind.Object) return;
        foreach (var property in values.EnumerateObject())
        {
            _runtime[property.Name] = property.Value.ValueKind == JsonValueKind.String
                ? property.Value.GetString() ?? string.Empty
                : property.Value.ToString();
        }
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
    public string GetCanonicalField(string fieldName, string fallback = "")
    {
        if (_canonicalFields.TryGetValue(fieldName, out var value)) return Resolve(value);
        return fallback;
    }
    public string GetCanonicalFieldRequired(string fieldName)
    {
        var value = GetCanonicalField(fieldName);
        if (string.IsNullOrWhiteSpace(value) || IsSynthetic(value))
            throw new InvalidOperationException($"Raw-Tosca canonical field '{fieldName}' is missing for scenario {CurrentFile}.");
        return value;
    }
    public string GetRequired(string key)
    {
        var value = Get(key);
        if (string.IsNullOrWhiteSpace(value) || IsSynthetic(value))
        {
            throw new InvalidOperationException($"Required test data '{key}' is missing or still synthetic. Scenario data: {CurrentFile}");
        }
        return value;
    }
    public string Get(string key, string fallback = "")
    {
        if (_runtime.TryGetValue(key, out var runtimeValue)) return runtimeValue;
        // An explicit external override wins over the source/static value.
        if (_external.TryGetValue(key, out var externalValue) && !IsSynthetic(externalValue))
        {
            return externalValue;
        }
        if (_static.TryGetValue(key, out var staticValue)) return staticValue;
        if (_canonicalFields.TryGetValue(key, out var canonicalValue)) return canonicalValue;
        return fallback;
    }
    public static bool IsSynthetic(string? value) =>
        string.IsNullOrWhiteSpace(value) || value.Equals("SYNTHETIC_REPLACE_ME", StringComparison.OrdinalIgnoreCase);
    public void SetRuntime(string key, string value) => _runtime[key] = value;
    // Kept as a compatibility alias for source-derived runtime captures.
    public void Set(string key, string value) => SetRuntime(key, value);
    public string GenerateRandom(string key, string? pattern = null)
    {
        if (_runtime.TryGetValue(key, out var existing))
        {
            return existing;
        }
        var effectivePattern = string.IsNullOrWhiteSpace(pattern) && _randomPatterns.TryGetValue(key, out var configured)
            ? configured
            : pattern ?? string.Empty;
        var value = RandomData.Generate(effectivePattern);
        _runtime[key] = value;
        return value;
    }
    // Compatibility alias; random data is created in StepDefinitions.
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
        if (string.IsNullOrEmpty(expression)) return string.Empty;
        var resolved = Regex.Replace(
            expression,
            @"\{\{(data|runtime|external|env):([^}]+)\}\}",
            match => match.Groups[1].Value.Equals("env", StringComparison.OrdinalIgnoreCase)
                ? Environment.GetEnvironmentVariable(match.Groups[2].Value) ?? string.Empty
                : Get(match.Groups[2].Value));
        // Resolve Tosca buffers/reusable parameters before evaluating source functions.
        resolved = Regex.Replace(resolved, @"\{B\[([^\]]+)\]\}", match => Get(match.Groups[1].Value));
        resolved = Regex.Replace(resolved, @"\{PL\[([^\]]+)\]\}", match => Get(match.Groups[1].Value));
        // Canonical source functions that are business data, not browser actions.
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
            if (resolved == before) break;
        }
        return resolved;
    }
    public bool Condition(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression)) return true;
        var normalized = expression.Trim();
        // Generated control-flow labels sometimes carry the real comparison after ';'.
        if (normalized.Contains(';')) normalized = normalized[(normalized.LastIndexOf(';') + 1)..].Trim();
        normalized = normalized.Replace("||", " OR ", StringComparison.Ordinal).Replace("&&", " AND ", StringComparison.Ordinal);
        try { return EvaluateOr(normalized); }
        catch when (!_config.Execution.StrictUnknownConditions) { return false; }
        catch (Exception ex) { throw new InvalidOperationException($"Unsupported source condition '{expression}'. It was not executed silently. {ex.Message}", ex); }
    }
    private bool EvaluateOr(string expression)
    {
        var parts = SplitTopLevel(expression, " OR ");
        if (parts.Count > 1) return parts.Any(EvaluateAnd);
        return EvaluateAnd(expression);
    }
    private bool EvaluateAnd(string expression)
    {
        var parts = SplitTopLevel(expression, " AND ");
        if (parts.Count > 1) return parts.All(EvaluateAtom);
        return EvaluateAtom(expression);
    }
    private bool EvaluateAtom(string expression)
    {
        var value = expression.Trim();
        while (value.StartsWith('(') && value.EndsWith(')') && Balanced(value[1..^1])) value = value[1..^1].Trim();
        if (value.StartsWith("NOT(", StringComparison.OrdinalIgnoreCase) && value.EndsWith(')')) return !EvaluateOr(value[4..^1]);
        if (value.StartsWith("NOT ", StringComparison.OrdinalIgnoreCase)) return !EvaluateAtom(value[4..]);
        var m = Regex.Match(value, @"^(?:['""](.+?)['""]|([A-Za-z0-9 _().:*#/-]+?))\s*(==|!=)\s*(?:['""](.*?)['""]|NULL)$", RegexOptions.IgnoreCase);
        if (!m.Success) throw new InvalidOperationException("No supported data comparison was found.");
        var key = (m.Groups[1].Success ? m.Groups[1].Value : m.Groups[2].Value).Trim().Trim('\'', '"');
        var op = m.Groups[3].Value;
        var expected = m.Groups[4].Success ? m.Groups[4].Value.Trim().Trim('\'', '"') : string.Empty;
        if(expected.Equals("NULL",StringComparison.OrdinalIgnoreCase)) expected=string.Empty;
        var actual=Get(key); var equal=string.Equals(actual,expected,StringComparison.OrdinalIgnoreCase);
        return op=="==" ? equal : !equal;
    }
    private static List<string> SplitTopLevel(string expression,string separator)
    {
        var result=new List<string>(); var depth=0; var quote='\0'; var start=0;
        for(var i=0;i<=expression.Length-separator.Length;i++)
        {
            var c=expression[i];
            if((c=='\''||c=='"')) { if(quote=='\0') quote=c; else if(quote==c) quote='\0'; }
            if(quote!='\0') continue;
            if(c=='(') depth++; else if(c==')') depth--;
            if(depth==0 && expression.AsSpan(i,separator.Length).Equals(separator,StringComparison.OrdinalIgnoreCase))
            { result.Add(expression[start..i].Trim()); start=i+separator.Length; i=start-1; }
        }
        if(start==0) return new List<string>{expression};
        result.Add(expression[start..].Trim()); return result;
    }
    private static bool Balanced(string expression)
    {
        var d=0; foreach(var c in expression){ if(c=='(') d++; else if(c==')'&&--d<0) return false; } return d==0;
    }
    private static string Unquote(string value)
    {
        var text = (value ?? string.Empty).Trim();
        if (text.Length >= 2 && ((text[0] == '\"' && text[^1] == '\"') || (text[0] == '\'' && text[^1] == '\'')))
            return text[1..^1];
        return text;
    }
    private static string ResolveDate(string baseValue, string offset, string format)
    {
        var date = DateTime.Today;
        var baseText = Unquote(baseValue);
        if (!string.IsNullOrWhiteSpace(baseText) && DateTime.TryParse(baseText, out var parsed)) date = parsed;
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
        var dotnetFormat = Unquote(format)
            .Replace("MM", "MM", StringComparison.Ordinal)
            .Replace("dd", "dd", StringComparison.Ordinal)
            .Replace("yyyy", "yyyy", StringComparison.Ordinal);
        return date.ToString(string.IsNullOrWhiteSpace(dotnetFormat) ? "MM-dd-yyyy" : dotnetFormat);
    }
    public IReadOnlyDictionary<string, string> Snapshot()
    {
        var result = new Dictionary<string, string>(_static, StringComparer.OrdinalIgnoreCase);
        foreach (var item in _runtime) result[item.Key] = item.Value;
        foreach (var key in result.Keys.Where(key =>
                     key.Contains("password", StringComparison.OrdinalIgnoreCase) ||
                     key.Contains("secret", StringComparison.OrdinalIgnoreCase)))
        {
            result[key] = "***";
        }
        return result;
    }
    private static void ReadFlatObject(JsonElement root, string name, IDictionary<string, string> target)
    {
        if (!root.TryGetProperty(name, out var value) || value.ValueKind != JsonValueKind.Object) return;
        foreach (var property in value.EnumerateObject())
        {
            target[property.Name] = property.Value.ValueKind == JsonValueKind.String
                ? property.Value.GetString() ?? string.Empty
                : property.Value.ToString();
        }
    }
    private static void Flatten(JsonElement element, string prefix, IDictionary<string, string> target)
    {
        if (element.ValueKind != JsonValueKind.Object) return;
        foreach (var property in element.EnumerateObject())
        {
            var key = string.IsNullOrWhiteSpace(prefix) ? property.Name : $"{prefix}.{property.Name}";
            if (property.Value.ValueKind == JsonValueKind.Object)
            {
                Flatten(property.Value, key, target);
            }
            else
            {
                var value = property.Value.ValueKind == JsonValueKind.String
                    ? property.Value.GetString() ?? string.Empty
                    : property.Value.ToString();
                target[property.Name] = value;
                target[key] = value;
            }
        }
    }
}
public static class RandomData
{
    public static string Generate(string pattern)
    {
        pattern = (pattern ?? string.Empty).Trim().TrimStart('^').TrimEnd('$');
        if (string.IsNullOrWhiteSpace(pattern))
        {
            return Guid.NewGuid().ToString("N")[..10];
        }
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
