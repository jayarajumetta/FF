using InsuranceAutomation.Core;

namespace InsuranceAutomation.PLDC.Pages.FallbackLocators;

/// <summary>Raw-Tosca deterministic fallback candidates for the Pricing page. Primary locators remain in Pages/Locators.</summary>
public sealed class PricingFallbackLocators
{
    private readonly ILocatorFallbackProvider _provider;
    public PricingFallbackLocators(ILocatorFallbackProvider provider) => _provider = provider;
    public IReadOnlyList<LocatorFallbackCandidate> For(string control) =>
        _provider.Find(new ControlIntent("Pricing", control))?.Candidates ?? Array.Empty<LocatorFallbackCandidate>();
}
