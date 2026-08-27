using InsuranceAutomation.Core;

namespace InsuranceAutomation.CLEQ.Pages.FallbackLocators;

/// <summary>Raw-Tosca deterministic fallback candidates for the Underwriting page. Primary locators remain in Pages/Locators.</summary>
public sealed class UnderwritingFallbackLocators
{
    private readonly ILocatorFallbackProvider _provider;
    public UnderwritingFallbackLocators(ILocatorFallbackProvider provider) => _provider = provider;
    public IReadOnlyList<LocatorFallbackCandidate> For(string control) =>
        _provider.Find(new ControlIntent("Underwriting", control))?.Candidates ?? Array.Empty<LocatorFallbackCandidate>();
}
