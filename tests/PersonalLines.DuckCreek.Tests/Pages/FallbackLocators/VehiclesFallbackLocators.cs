using InsuranceAutomation.Core;

namespace InsuranceAutomation.PLDC.Pages.FallbackLocators;

/// <summary>Raw-Tosca deterministic fallback candidates for the Vehicles page. Primary locators remain in Pages/Locators.</summary>
public sealed class VehiclesFallbackLocators
{
    private readonly ILocatorFallbackProvider _provider;
    public VehiclesFallbackLocators(ILocatorFallbackProvider provider) => _provider = provider;
    public IReadOnlyList<LocatorFallbackCandidate> For(string control) =>
        _provider.Find(new ControlIntent("Vehicles", control))?.Candidates ?? Array.Empty<LocatorFallbackCandidate>();
}
