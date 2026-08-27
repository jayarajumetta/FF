using InsuranceAutomation.Core;

namespace InsuranceAutomation.PLDC.Pages.FallbackLocators;

/// <summary>Raw-Tosca deterministic fallback candidates for the Drivers page. Primary locators remain in Pages/Locators.</summary>
public sealed class DriversFallbackLocators
{
    private readonly ILocatorFallbackProvider _provider;
    public DriversFallbackLocators(ILocatorFallbackProvider provider) => _provider = provider;
    public IReadOnlyList<LocatorFallbackCandidate> For(string control) =>
        _provider.Find(new ControlIntent("Drivers", control))?.Candidates ?? Array.Empty<LocatorFallbackCandidate>();
}
