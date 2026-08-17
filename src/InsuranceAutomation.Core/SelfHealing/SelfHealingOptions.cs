namespace InsuranceAutomation.Core.SelfHealing;

public sealed class SelfHealingOptions
{
    public bool Enabled { get; init; } = ReadBool("COPILOT_SELF_HEAL", false);
    public string Model { get; init; } = Environment.GetEnvironmentVariable("COPILOT_HEAL_MODEL") ?? "auto";
    public int PrimaryTimeoutMs { get; init; } = ReadInt("COPILOT_HEAL_PRIMARY_TIMEOUT_MS", 5000);
    public int MaxCopilotCallsPerScenario { get; init; } = ReadInt("COPILOT_HEAL_MAX_CALLS", 5);
    public double MinimumConfidence { get; init; } = ReadDouble("COPILOT_HEAL_MIN_CONFIDENCE", 0.72);
    public string CachePath { get; init; } = Environment.GetEnvironmentVariable("COPILOT_HEAL_CACHE") ?? "Artifacts/SelfHealing/locator-heals.json";
    public string AuditPath { get; init; } = Environment.GetEnvironmentVariable("COPILOT_HEAL_AUDIT") ?? "Artifacts/SelfHealing/healing-audit.jsonl";

    static bool ReadBool(string key, bool fallback) => bool.TryParse(Environment.GetEnvironmentVariable(key), out var v) ? v : fallback;
    static int ReadInt(string key, int fallback) => int.TryParse(Environment.GetEnvironmentVariable(key), out var v) ? v : fallback;
    static double ReadDouble(string key, double fallback) => double.TryParse(Environment.GetEnvironmentVariable(key), out var v) ? v : fallback;
}
