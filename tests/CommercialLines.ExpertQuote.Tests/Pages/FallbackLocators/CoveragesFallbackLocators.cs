using InsuranceAutomation.Core;

namespace InsuranceAutomation.CLEQ.Pages.FallbackLocators;

/// <summary>Raw-Tosca deterministic fallback candidates for the Coverages page. Primary locators remain in Pages/Locators.</summary>
public sealed class CoveragesFallbackLocators
{
    private readonly ILocatorFallbackProvider _provider;
    public CoveragesFallbackLocators(ILocatorFallbackProvider provider) => _provider = provider;
    public IReadOnlyList<LocatorFallbackCandidate> For(string control) =>
        _provider.Find(new ControlIntent("Coverages", control))?.Candidates ?? Array.Empty<LocatorFallbackCandidate>();
}
