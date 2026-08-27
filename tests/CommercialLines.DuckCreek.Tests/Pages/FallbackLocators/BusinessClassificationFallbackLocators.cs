using InsuranceAutomation.Core;

namespace InsuranceAutomation.CLDC.Pages.FallbackLocators;

/// <summary>Raw-Tosca deterministic fallback candidates for the BusinessClassification page. Primary locators remain in Pages/Locators.</summary>
public sealed class BusinessClassificationFallbackLocators
{
    private readonly ILocatorFallbackProvider _provider;
    public BusinessClassificationFallbackLocators(ILocatorFallbackProvider provider) => _provider = provider;
    public IReadOnlyList<LocatorFallbackCandidate> For(string control) =>
        _provider.Find(new ControlIntent("BusinessClassification", control))?.Candidates ?? Array.Empty<LocatorFallbackCandidate>();
}
