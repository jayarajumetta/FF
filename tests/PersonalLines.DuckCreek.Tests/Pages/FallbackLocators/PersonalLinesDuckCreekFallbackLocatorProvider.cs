using InsuranceAutomation.Core;

namespace InsuranceAutomation.PLDC.Pages.FallbackLocators;

/// <summary>Application-scoped raw-Tosca fallback provider. Page fallback classes below are typed views over this provider.</summary>
public sealed class PersonalLinesDuckCreekFallbackLocatorProvider : ILocatorFallbackProvider
{
    private readonly LocatorFallbackCatalogStore _inner;
    public PersonalLinesDuckCreekFallbackLocatorProvider(FrameworkConfig config) => _inner = new LocatorFallbackCatalogStore(config, "PersonalLines.DuckCreek");
    public LocatorFallbackControlEntry? Find(ControlIntent intent) => _inner.Find(intent);
    public LocatorFallbackApplicationCatalog Metadata => _inner.Metadata;
}
