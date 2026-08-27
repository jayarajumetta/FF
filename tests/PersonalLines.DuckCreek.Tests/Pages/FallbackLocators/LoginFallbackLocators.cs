using InsuranceAutomation.Core;

namespace InsuranceAutomation.PLDC.Pages.FallbackLocators;

/// <summary>Raw-Tosca deterministic fallback candidates for the Login page. Primary locators remain in Pages/Locators.</summary>
public sealed class LoginFallbackLocators
{
    private readonly ILocatorFallbackProvider _provider;
    public LoginFallbackLocators(ILocatorFallbackProvider provider) => _provider = provider;
    public IReadOnlyList<LocatorFallbackCandidate> For(string control) =>
        _provider.Find(new ControlIntent("Login", control))?.Candidates ?? Array.Empty<LocatorFallbackCandidate>();
}
