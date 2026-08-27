using InsuranceAutomation.Core;

namespace InsuranceAutomation.CLEQ.Pages.FallbackLocators;

/// <summary>Raw-Tosca deterministic fallback candidates for the Locations page. Primary locators remain in Pages/Locators.</summary>
public sealed class LocationsFallbackLocators
{
    private readonly ILocatorFallbackProvider _provider;
    public LocationsFallbackLocators(ILocatorFallbackProvider provider) => _provider = provider;
    public IReadOnlyList<LocatorFallbackCandidate> For(string control) =>
        _provider.Find(new ControlIntent("Locations", control))?.Candidates ?? Array.Empty<LocatorFallbackCandidate>();
}
