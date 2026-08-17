using System.Text.Json;
namespace InsuranceAutomation.Core.SelfHealing;

public sealed class HealingCache
{
    readonly string _path;
    readonly SemaphoreSlim _gate = new(1,1);
    Dictionary<string, LocatorProposal>? _cache;
    public HealingCache(string path) => _path = path;

    public async Task<LocatorProposal?> GetAsync(string key)
    {
        await EnsureAsync();
        return _cache!.TryGetValue(key, out var p) ? p : null;
    }

    public async Task PutAsync(string key, LocatorProposal proposal)
    {
        await _gate.WaitAsync();
        try
        {
            await EnsureUnlockedAsync();
            _cache![key] = proposal;
            var dir = Path.GetDirectoryName(_path); if (!string.IsNullOrWhiteSpace(dir)) Directory.CreateDirectory(dir);
            await File.WriteAllTextAsync(_path, JsonSerializer.Serialize(_cache, JsonOptions));
        }
        finally { _gate.Release(); }
    }

    async Task EnsureAsync(){ await _gate.WaitAsync(); try { await EnsureUnlockedAsync(); } finally { _gate.Release(); } }
    async Task EnsureUnlockedAsync()
    {
        if (_cache != null) return;
        if (!File.Exists(_path)) { _cache = new(StringComparer.OrdinalIgnoreCase); return; }
        try { _cache = JsonSerializer.Deserialize<Dictionary<string, LocatorProposal>>(await File.ReadAllTextAsync(_path), JsonOptions) ?? new(StringComparer.OrdinalIgnoreCase); }
        catch { _cache = new(StringComparer.OrdinalIgnoreCase); }
    }
    static readonly JsonSerializerOptions JsonOptions = new(){WriteIndented=true,PropertyNameCaseInsensitive=true};
}
