using InsuranceAutomation.Core;

namespace InsuranceAutomation.CLEQ.Pages.FallbackLocators;

/// <summary>Raw-Tosca deterministic fallback candidates for the PolicyInformation page. Primary locators remain in Pages/Locators.</summary>
public sealed class PolicyInformationFallbackLocators
{
    private readonly ILocatorFallbackProvider _provider;
    public PolicyInformationFallbackLocators(ILocatorFallbackProvider provider) => _provider = provider;
    public IReadOnlyList<LocatorFallbackCandidate> For(string control) =>
        _provider.Find(new ControlIntent("PolicyInformation", control))?.Candidates ?? Array.Empty<LocatorFallbackCandidate>();
}
