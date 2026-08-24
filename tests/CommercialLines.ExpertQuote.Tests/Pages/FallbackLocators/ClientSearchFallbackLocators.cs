using InsuranceAutomation.Core;

namespace InsuranceAutomation.CLEQ.Pages.FallbackLocators;

/// <summary>Raw-Tosca deterministic fallback candidates for the ClientSearch page. Primary locators remain in Pages/Locators.</summary>
public sealed class ClientSearchFallbackLocators
{
    private readonly ILocatorFallbackProvider _provider;
    public ClientSearchFallbackLocators(ILocatorFallbackProvider provider) => _provider = provider;
    public IReadOnlyList<LocatorFallbackCandidate> For(string control) =>
        _provider.Find(new ControlIntent("ClientSearch", control))?.Candidates ?? Array.Empty<LocatorFallbackCandidate>();
}
