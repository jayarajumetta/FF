using InsuranceAutomation.Core;

namespace InsuranceAutomation.CLEQ.Pages.FallbackLocators;

/// <summary>Raw-Tosca deterministic fallback candidates for the SocialSecurity page. Primary locators remain in Pages/Locators.</summary>
public sealed class SocialSecurityFallbackLocators
{
    private readonly ILocatorFallbackProvider _provider;
    public SocialSecurityFallbackLocators(ILocatorFallbackProvider provider) => _provider = provider;
    public IReadOnlyList<LocatorFallbackCandidate> For(string control) =>
        _provider.Find(new ControlIntent("SocialSecurity", control))?.Candidates ?? Array.Empty<LocatorFallbackCandidate>();
}
