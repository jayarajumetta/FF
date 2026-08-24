using InsuranceAutomation.Core;

namespace InsuranceAutomation.CLEQ.Pages.FallbackLocators;

/// <summary>Application-scoped raw-Tosca fallback provider. Page fallback classes below are typed views over this provider.</summary>
public sealed class CommercialLinesExpertQuoteFallbackLocatorProvider : ILocatorFallbackProvider
{
    private readonly LocatorFallbackCatalogStore _inner;
    public CommercialLinesExpertQuoteFallbackLocatorProvider(FrameworkConfig config) => _inner = new LocatorFallbackCatalogStore(config, "CommercialLines.ExpertQuote");
    public LocatorFallbackControlEntry? Find(ControlIntent intent) => _inner.Find(intent);
    public LocatorFallbackApplicationCatalog Metadata => _inner.Metadata;
}
