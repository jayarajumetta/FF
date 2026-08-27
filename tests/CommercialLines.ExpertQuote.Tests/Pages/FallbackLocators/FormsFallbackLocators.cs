using InsuranceAutomation.Core;

namespace InsuranceAutomation.CLEQ.Pages.FallbackLocators;

/// <summary>Raw-Tosca deterministic fallback candidates for the Forms page. Primary locators remain in Pages/Locators.</summary>
public sealed class FormsFallbackLocators
{
    private readonly ILocatorFallbackProvider _provider;
    public FormsFallbackLocators(ILocatorFallbackProvider provider) => _provider = provider;
    public IReadOnlyList<LocatorFallbackCandidate> For(string control) =>
        _provider.Find(new ControlIntent("Forms", control))?.Candidates ?? Array.Empty<LocatorFallbackCandidate>();
}
