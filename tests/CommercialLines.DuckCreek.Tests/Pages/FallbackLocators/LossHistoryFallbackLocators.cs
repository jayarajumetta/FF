using InsuranceAutomation.Core;

namespace InsuranceAutomation.CLDC.Pages.FallbackLocators;

/// <summary>Raw-Tosca deterministic fallback candidates for the LossHistory page. Primary locators remain in Pages/Locators.</summary>
public sealed class LossHistoryFallbackLocators
{
    private readonly ILocatorFallbackProvider _provider;
    public LossHistoryFallbackLocators(ILocatorFallbackProvider provider) => _provider = provider;
    public IReadOnlyList<LocatorFallbackCandidate> For(string control) =>
        _provider.Find(new ControlIntent("LossHistory", control))?.Candidates ?? Array.Empty<LocatorFallbackCandidate>();
}
