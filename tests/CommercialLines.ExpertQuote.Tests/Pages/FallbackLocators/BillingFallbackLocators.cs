using InsuranceAutomation.Core;

namespace InsuranceAutomation.CLEQ.Pages.FallbackLocators;

/// <summary>Raw-Tosca deterministic fallback candidates for the Billing page. Primary locators remain in Pages/Locators.</summary>
public sealed class BillingFallbackLocators
{
    private readonly ILocatorFallbackProvider _provider;
    public BillingFallbackLocators(ILocatorFallbackProvider provider) => _provider = provider;
    public IReadOnlyList<LocatorFallbackCandidate> For(string control) =>
        _provider.Find(new ControlIntent("Billing", control))?.Candidates ?? Array.Empty<LocatorFallbackCandidate>();
}
