using InsuranceAutomation.Core;

namespace InsuranceAutomation.CLDC.Pages.FallbackLocators;

/// <summary>Application-scoped raw-Tosca fallback provider. Page fallback classes below are typed views over this provider.</summary>
public sealed class CommercialLinesDuckCreekFallbackLocatorProvider : ILocatorFallbackProvider
{
    private readonly LocatorFallbackCatalogStore _inner;
    public CommercialLinesDuckCreekFallbackLocatorProvider(FrameworkConfig config) => _inner = new LocatorFallbackCatalogStore(config, "CommercialLines.DuckCreek");
    public LocatorFallbackControlEntry? Find(ControlIntent intent) => _inner.Find(intent);
    public LocatorFallbackApplicationCatalog Metadata => _inner.Metadata;
}
