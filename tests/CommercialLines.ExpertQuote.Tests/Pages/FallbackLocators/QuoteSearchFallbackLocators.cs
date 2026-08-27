using InsuranceAutomation.Core;

namespace InsuranceAutomation.CLEQ.Pages.FallbackLocators;

/// <summary>Raw-Tosca deterministic fallback candidates for the QuoteSearch page. Primary locators remain in Pages/Locators.</summary>
public sealed class QuoteSearchFallbackLocators
{
    private readonly ILocatorFallbackProvider _provider;
    public QuoteSearchFallbackLocators(ILocatorFallbackProvider provider) => _provider = provider;
    public IReadOnlyList<LocatorFallbackCandidate> For(string control) =>
        _provider.Find(new ControlIntent("QuoteSearch", control))?.Candidates ?? Array.Empty<LocatorFallbackCandidate>();
}
