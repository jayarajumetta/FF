using InsuranceAutomation.Core;

namespace InsuranceAutomation.CLEQ.Pages.FallbackLocators;

/// <summary>Raw-Tosca deterministic fallback candidates for the AccountInformation page. Primary locators remain in Pages/Locators.</summary>
public sealed class AccountInformationFallbackLocators
{
    private readonly ILocatorFallbackProvider _provider;
    public AccountInformationFallbackLocators(ILocatorFallbackProvider provider) => _provider = provider;
    public IReadOnlyList<LocatorFallbackCandidate> For(string control) =>
        _provider.Find(new ControlIntent("AccountInformation", control))?.Candidates ?? Array.Empty<LocatorFallbackCandidate>();
}
