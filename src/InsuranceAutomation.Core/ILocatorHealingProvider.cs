namespace InsuranceAutomation.Core;

public sealed record LocatorHealingProviderRequest(
    string Prompt,
    byte[] Screenshot,
    string EvidenceDirectory);

public interface ILocatorHealingProvider
{
    string Name { get; }
    bool IsAvailable(out string reason);
    Task<string> ProposeAsync(LocatorHealingProviderRequest request, CancellationToken cancellationToken = default);
}
