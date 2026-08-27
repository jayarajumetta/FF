using InsuranceAutomation.Core;

namespace InsuranceAutomation.PLDC.Pages.FallbackLocators;

/// <summary>Raw-Tosca deterministic fallback candidates for the Navigation page. Primary locators remain in Pages/Locators.</summary>
public sealed class NavigationFallbackLocators
{
    private readonly ILocatorFallbackProvider _provider;
    public NavigationFallbackLocators(ILocatorFallbackProvider provider) => _provider = provider;
    public IReadOnlyList<LocatorFallbackCandidate> For(string control) =>
        _provider.Find(new ControlIntent("Navigation", control))?.Candidates ?? Array.Empty<LocatorFallbackCandidate>();
}
