using System.Text.Json;
using System.Text.RegularExpressions;

namespace InsuranceAutomation.Utils;

public sealed class ScenarioData
{
    private static readonly IReadOnlyDictionary<string,string> CanonicalAliases =
        new Dictionary<string,string>(StringComparer.OrdinalIgnoreCase)
        {
            ["State"] = "StateCode",
            ["State Abbv"] = "StateCode",
            ["State Abbreviation"] = "StateCode",
            ["State Name"] = "StateName",
            ["Login.UserName"] = "Login.Username",
            ["Username"] = "Login.Username",
            ["UserName"] = "Login.Username",
            ["Password"] = "Login.Password"
        };
    private readonly Dictionary<string,string> _values = new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string,string> _buffers = new(StringComparer.OrdinalIgnoreCase);

    public async Task LoadAsync(string relativePath)
    {
        var root = Directory.GetCurrentDirectory();
        var path = Path.Combine(root, relativePath.Replace('/', Path.DirectorySeparatorChar));
        if (!File.Exists(path)) throw new FileNotFoundException($"Test data file not found: {path}");
        var json = await File.ReadAllTextAsync(path);
        var values = JsonSerializer.Deserialize<Dictionary<string,string>>(json) ?? new();
        _values.Clear();
        _buffers.Clear();
        foreach (var pair in values)
            _values[pair.Key] = pair.Value;

        PrimeDerivedBuffers();
    }

    public string Get(string key, string fallback = "")
    {
        if (_values.TryGetValue(key, out var value))
            return ResolveAndCache(key, value);

        if (CanonicalAliases.TryGetValue(key, out var canonical)
            && _values.TryGetValue(canonical, out value))
            return ResolveAndCache(canonical, value);

        return Resolve(fallback);
    }

    private string ResolveAndCache(string key, string value)
    {
        var resolved = Resolve(value);
        _values[key] = resolved;
        return resolved;
    }

    private void PrimeDerivedBuffers()
    {
        PrimeBuffer("FirstName", "First Name");
        PrimeBuffer("LastName", "Last Name");
        PrimeBuffer("Product (LOB)", "LOB");
        PrimeBuffer("QuoteDescription", "Description");

        var ssnKeys = new[]
        {
            "EQ Common SSN.ssn",
            "SSN",
            "Social Security Number"
        };

        foreach (var key in ssnKeys)
        {
            if (!_values.ContainsKey(key))
                continue;

            var ssn = Get(key);
            var digits = new string(ssn.Where(char.IsDigit).ToArray());
            if (digits.Length >= 4)
                _buffers["Last4SSN"] = digits[^4..];
            break;
        }
    }

    private void PrimeBuffer(string bufferName, string dataKey)
    {
        if (_values.ContainsKey(dataKey))
            _buffers[bufferName] = Get(dataKey);
    }

    public void Set(string key, string value) => _values[key] = value;

    public void SetBuffer(string key, string value) => _buffers[key] = value;

    public string Resolve(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return value;
        var now = DateTime.Now;
        value = value
            .Replace("{{date}}", now.ToString("MM/dd/yyyy"), StringComparison.OrdinalIgnoreCase)
            .Replace("{{month}}", now.Month.ToString("00"), StringComparison.OrdinalIgnoreCase)
            .Replace("{{day}}", now.Day.ToString("00"), StringComparison.OrdinalIgnoreCase)
            .Replace("{{year}}", now.Year.ToString(), StringComparison.OrdinalIgnoreCase)
            .Replace("{{time}}", now.ToString("HHmmss"), StringComparison.OrdinalIgnoreCase);
        value = Regex.Replace(value, @"\{\{data:([^}]+)\}\}", match =>
        {
            var key = match.Groups[1].Value;
            if (_values.ContainsKey(key))
                return Get(key);

            if (CanonicalAliases.TryGetValue(key, out var canonical)
                && _values.ContainsKey(canonical))
                return Get(canonical);

            throw new KeyNotFoundException(
                $"Scenario data '{key}' is not present in the active test-data file.");
        }, RegexOptions.IgnoreCase);
        value = Regex.Replace(value, @"\{\{buffer:([^}]+)\}\}", match =>
        {
            var key = match.Groups[1].Value;
            if (_buffers.TryGetValue(key, out var buffered))
                return buffered;

            throw new KeyNotFoundException(
                $"Runtime buffer '{key}' has not been created by an earlier test step.");
        }, RegexOptions.IgnoreCase);
        value = Regex.Replace(value, @"\{\{randomText:(\d+)\}\}", match =>
            new string(Random.Shared.GetItems("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray(), int.Parse(match.Groups[1].Value))),
            RegexOptions.IgnoreCase);
        value = Regex.Replace(value, @"\{\{randomNumber:(\d+):(\d+)\}\}", match =>
            Random.Shared.Next(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value) + 1).ToString(),
            RegexOptions.IgnoreCase);
        value = Regex.Replace(value, @"\{\{randomDigits:(\d+)\}\}", match =>
            string.Concat(Enumerable.Range(0, int.Parse(match.Groups[1].Value)).Select(_ => Random.Shared.Next(0, 10))),
            RegexOptions.IgnoreCase);
        value = value
            .Replace("{{randomEmail}}", $"test{Guid.NewGuid():N}@example.test", StringComparison.OrdinalIgnoreCase)
            .Replace("{{randomPhone}}", $"3{Random.Shared.NextInt64(100000000, 999999999)}", StringComparison.OrdinalIgnoreCase);
        value = Regex.Replace(value, @"\{\{env:([^}]+)\}\}", match =>
        {
            var key = match.Groups[1].Value;
            return Environment.GetEnvironmentVariable(key)
                ?? throw new InvalidOperationException(
                    $"Required environment variable '{key}' is not configured.");
        }, RegexOptions.IgnoreCase);
        value = Regex.Replace(value, @"\{\{dateOffsetYears:(-?\d+):([^}]+)\}\}", match =>
            DateTime.Now.AddYears(int.Parse(match.Groups[1].Value)).ToString(match.Groups[2].Value),
            RegexOptions.IgnoreCase);
        return value;
    }
}
