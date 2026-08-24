using InsuranceAutomation.Core;

namespace InsuranceAutomation.CLEQ.Pages.FallbackLocators;

/// <summary>Raw-Tosca deterministic fallback candidates for the Buildings page. Primary locators remain in Pages/Locators.</summary>
public sealed class BuildingsFallbackLocators
{
    private readonly ILocatorFallbackProvider _provider;
    public BuildingsFallbackLocators(ILocatorFallbackProvider provider) => _provider = provider;
    public IReadOnlyList<LocatorFallbackCandidate> For(string control) =>
        _provider.Find(new ControlIntent("Buildings", control))?.Candidates ?? Array.Empty<LocatorFallbackCandidate>();
}
