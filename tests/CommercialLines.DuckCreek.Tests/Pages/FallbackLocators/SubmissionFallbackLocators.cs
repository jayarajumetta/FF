using InsuranceAutomation.Core;

namespace InsuranceAutomation.CLDC.Pages.FallbackLocators;

/// <summary>Raw-Tosca deterministic fallback candidates for the Submission page. Primary locators remain in Pages/Locators.</summary>
public sealed class SubmissionFallbackLocators
{
    private readonly ILocatorFallbackProvider _provider;
    public SubmissionFallbackLocators(ILocatorFallbackProvider provider) => _provider = provider;
    public IReadOnlyList<LocatorFallbackCandidate> For(string control) =>
        _provider.Find(new ControlIntent("Submission", control))?.Candidates ?? Array.Empty<LocatorFallbackCandidate>();
}
