using System.Collections.Concurrent;

namespace ToscaModernized.Core.Data;

public sealed class RunDataContext
{
    private readonly ConcurrentDictionary<string, string> _values = new(StringComparer.OrdinalIgnoreCase);

    public string RunId { get; } = $"{DateTimeOffset.UtcNow:yyyyMMdd-HHmmssfff}-{Guid.NewGuid():N}";

    public void Set(string key, string? value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        _values[key] = value ?? string.Empty;
    }

    public bool TryGet(string key, out string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        return _values.TryGetValue(key, out value!);
    }

    public string GetRequired(string key)
    {
        if (!TryGet(key, out var value))
        {
            throw new KeyNotFoundException($"Run-level value '{key}' has not been generated, captured, or configured.");
        }
        return value;
    }

    public IReadOnlyDictionary<string, string> Snapshot() =>
        new Dictionary<string, string>(_values, StringComparer.OrdinalIgnoreCase);
}
