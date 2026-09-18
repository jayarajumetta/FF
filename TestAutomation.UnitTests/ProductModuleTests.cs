using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PnCTestAutomation.Artifacts;
using PnCTestAutomation.Products;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class ProductModuleTests
{
    [Test]
    public void RegistryAssignsEveryAutomationFamilyToOneModule()
    {
        var registry = Registry();

        Assert.Multiple(() =>
        {
            Assert.That(registry.Modules, Has.Count.EqualTo(1));
            Assert.That(
                registry.Resolve("SFP-BASIC-POLICY:AL").ModuleId,
                Is.EqualTo("sfp-reference"));
            Assert.That(registry.TryResolve("UNREGISTERED:AL"), Is.Null);
        });
    }

    [Test]
    public void RegistryRejectsDuplicateAutomationOwnership()
    {
        var duplicate = new TestProductModule(
            new SfpProductModule().Descriptor with
            {
                ModuleId = "duplicate",
                Product = "Duplicate"
            });

        Assert.That(
            () => new ProductModuleRegistry(
                [new SfpProductModule(), duplicate]),
            Throws.TypeOf<ProductModuleConfigurationException>()
                .With.Message.Contains("Duplicate product automation ID family"));
    }

    [Test]
    public void SfpModuleDeclaresRequiredContractsAndDisablesRetry()
    {
        var descriptor = Registry().Resolve("SFP-BASIC-POLICY:AL");

        Assert.Multiple(() =>
        {
            Assert.That(
                descriptor.RequiredCapabilities,
                Does.Contain(ProductCapability.SemanticControls));
            Assert.That(
                descriptor.RequiredCapabilities,
                Does.Contain(ProductCapability.FrameScope));
            Assert.That(
                descriptor.RequiredCapabilities,
                Does.Contain(ProductCapability.QuoteHandoff));
            Assert.That(
                descriptor.RequiredCapabilities,
                Does.Contain(ProductCapability.TestPlans));
            Assert.That(descriptor.Evidence.RequiresCanonicalResult, Is.True);
            Assert.That(
                descriptor.Evidence.RequiredFailureArtifacts,
                Is.EquivalentTo(
                    new[] { ArtifactKind.Trace, ArtifactKind.Video }));
            Assert.That(descriptor.RetrySafe, Is.False);
        });
    }

    [Test]
    public void StartupRegistersOneRegistryAndNoAdditionalHook()
    {
        var services = new ServiceCollection();
        new Startup().ConfigureServices(services);

        Assert.Multiple(() =>
        {
            Assert.That(
                services.Count(service =>
                    service.ServiceType == typeof(IProductModuleRegistry)),
                Is.EqualTo(1));
            Assert.That(
                typeof(Startup).Assembly.GetTypes().Count(type =>
                    type.Name == "TestHooks"),
                Is.EqualTo(1));
        });
    }

    private static ProductModuleRegistry Registry() =>
        new([new SfpProductModule()]);

    private sealed class TestProductModule(
        ProductModuleDescriptor descriptor) : IProductModule
    {
        public ProductModuleDescriptor Descriptor { get; } = descriptor;
    }
}
