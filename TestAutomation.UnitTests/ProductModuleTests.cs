using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PnCTestAutomation.Artifacts;
using PnCTestAutomation.Pages.ExpertQuotePages.BOP;
using PnCTestAutomation.Pages.CommercialDuckCreekPages.BAP;
using PnCTestAutomation.Products;
using PnCTestAutomation.Workflows;

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
            Assert.That(registry.Modules, Has.Count.EqualTo(3));
            Assert.That(
                registry.Resolve("SFP-BASIC-POLICY:AL").ModuleId,
                Is.EqualTo("sfp-reference"));
            Assert.That(
                registry.Resolve("EQ-BOP-SMOKE:AL").ModuleId,
                Is.EqualTo("expertquote-bop-al-pilot"));
            Assert.That(
                registry.Resolve("CLDC-BAP-SMOKE:AL").ModuleId,
                Is.EqualTo("commercial-duckcreek-bap-al-pilot"));
            Assert.That(registry.TryResolve("UNREGISTERED:AL"), Is.Null);
        });
    }

    [Test]
    public void RegistryRejectsDuplicateAutomationOwnership()
    {
        var duplicate = new TestProductModule(
            new ExpertQuoteBopPilotModule().Descriptor with
            {
                ModuleId = "duplicate",
                Product = "Duplicate"
            });

        Assert.That(
            () => new ProductModuleRegistry(
                [new ExpertQuoteBopPilotModule(), duplicate]),
            Throws.TypeOf<ProductModuleConfigurationException>()
                .With.Message.Contains("Duplicate product automation ID family"));
    }

    [Test]
    public void PilotDeclaresRequiredContractsAndDisablesRetry()
    {
        var descriptor = Registry().Resolve("EQ-BOP-SMOKE:AL");

        Assert.Multiple(() =>
        {
            Assert.That(descriptor.UsesPilotDataProfile, Is.True);
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
            Assert.That(descriptor.RetrySafe, Is.False);
        });
    }

    [Test]
    public void CommercialDuckCreekPilotRequiresFrameEvidenceAndNoRetry()
    {
        var descriptor = Registry().Resolve("CLDC-BAP-SMOKE:AL");

        Assert.Multiple(() =>
        {
            Assert.That(descriptor.UsesPilotDataProfile, Is.True);
            Assert.That(
                descriptor.RequiredCapabilities,
                Does.Contain(ProductCapability.FrameScope));
            Assert.That(
                descriptor.Evidence.RequiredArtifacts,
                Does.Contain(ArtifactKind.RuntimeLocator));
            Assert.That(
                descriptor.BlockedSelectors,
                Does.Contain("stable-frame-paths"));
            Assert.That(descriptor.SelectorExceptionReferences, Is.Empty);
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
                services.Count(service =>
                    service.ServiceType ==
                    typeof(IExpertQuoteBopPilotRuntime)),
                Is.EqualTo(1));
            Assert.That(
                services.Count(service =>
                    service.ServiceType ==
                    typeof(IExpertQuoteBopPilotWorkflow)),
                Is.EqualTo(1));
            Assert.That(
                services.Count(service =>
                    service.ServiceType ==
                    typeof(ICommercialDuckCreekBapPilotRuntime)),
                Is.EqualTo(1));
            Assert.That(
                services.Count(service =>
                    service.ServiceType ==
                    typeof(ICommercialDuckCreekBapPilotWorkflow)),
                Is.EqualTo(1));
            Assert.That(
                typeof(Startup).Assembly.GetTypes().Count(type =>
                    type.Name == "TestHooks"),
                Is.EqualTo(1));
        });
    }

    private static ProductModuleRegistry Registry() =>
        new(
        [
            new SfpProductModule(),
            new ExpertQuoteBopPilotModule(),
            new CommercialDuckCreekBapPilotModule()
        ]);

    private sealed class TestProductModule(
        ProductModuleDescriptor descriptor) : IProductModule
    {
        public ProductModuleDescriptor Descriptor { get; } = descriptor;
    }
}
