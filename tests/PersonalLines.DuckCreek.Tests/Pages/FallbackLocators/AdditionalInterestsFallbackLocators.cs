using InsuranceAutomation.Core;

namespace InsuranceAutomation.PLDC.Pages.FallbackLocators;

/// <summary>Raw-Tosca deterministic fallback candidates for the AdditionalInterests page. Primary locators remain in Pages/Locators.</summary>
public sealed class AdditionalInterestsFallbackLocators
{
    private readonly ILocatorFallbackProvider _provider;
    public AdditionalInterestsFallbackLocators(ILocatorFallbackProvider provider) => _provider = provider;
    public IReadOnlyList<LocatorFallbackCandidate> For(string control) =>
        _provider.Find(new ControlIntent("AdditionalInterests", control))?.Candidates ?? Array.Empty<LocatorFallbackCandidate>();
}
