using InsuranceAutomation.Core;

namespace InsuranceAutomation.PLDC.Pages.FallbackLocators;

/// <summary>Raw-Tosca deterministic fallback candidates for the PolicyWorkflow page. Primary locators remain in Pages/Locators.</summary>
public sealed class PolicyWorkflowFallbackLocators
{
    private readonly ILocatorFallbackProvider _provider;
    public PolicyWorkflowFallbackLocators(ILocatorFallbackProvider provider) => _provider = provider;
    public IReadOnlyList<LocatorFallbackCandidate> For(string control) =>
        _provider.Find(new ControlIntent("PolicyWorkflow", control))?.Candidates ?? Array.Empty<LocatorFallbackCandidate>();
}
