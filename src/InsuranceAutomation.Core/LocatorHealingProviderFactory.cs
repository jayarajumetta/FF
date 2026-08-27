namespace InsuranceAutomation.Core;

public static class LocatorHealingProviderFactory
{
    public static ILocatorHealingProvider Create(FrameworkConfig config) =>
        config.SelfHeal.Provider.ToLowerInvariant() switch
        {
            "github-copilot" => new GitHubCopilotLocatorHealingProvider(config),
            "openai-compatible" => new OpenAiCompatibleLocatorHealingProvider(config),
            _ => throw new InvalidOperationException($"Unsupported locator healing provider '{config.SelfHeal.Provider}'.")
        };
}
