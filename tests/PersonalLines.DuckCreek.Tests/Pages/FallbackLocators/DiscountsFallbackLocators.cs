using InsuranceAutomation.Core;

namespace InsuranceAutomation.PLDC.Pages.FallbackLocators;

/// <summary>Raw-Tosca deterministic fallback candidates for the Discounts page. Primary locators remain in Pages/Locators.</summary>
public sealed class DiscountsFallbackLocators
{
    private readonly ILocatorFallbackProvider _provider;
    public DiscountsFallbackLocators(ILocatorFallbackProvider provider) => _provider = provider;
    public IReadOnlyList<LocatorFallbackCandidate> For(string control) =>
        _provider.Find(new ControlIntent("Discounts", control))?.Candidates ?? Array.Empty<LocatorFallbackCandidate>();
}
