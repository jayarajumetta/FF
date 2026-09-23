using NUnit.Framework;
using PnCTestAutomation.Pages.ExpertQuotePages;
using PnCTestAutomation.Products;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public sealed class ExpertQuoteBopSmokeTests
{
    [TestCase("Smokeabcd\n01945678", "01945678")]
    [TestCase("BOP (01945678)", "01945678")]
    public void QuoteCaptureUsesTheCompleteIdentity(string header, string expected) =>
        Assert.That(ClientSearchPage.ParseQuoteIdentity(header), Is.EqualTo(expected));

    [TestCase("Smokeabcd")]
    [TestCase("01945678 01945679")]
    [TestCase("1019456789")]
    public void AmbiguousOrPartialQuoteIdentityFails(string header) =>
        Assert.Throws<InvalidOperationException>(() => ClientSearchPage.ParseQuoteIdentity(header));

    [Test]
    public void ModuleOwnsOnlyTheOriginalBopSmokeAndRequiresActualInputAndQuoteEvidence()
    {
        var module = new ExpertQuoteBopSmokeModule().Descriptor;
        var registry = new ProductModuleRegistry([new SfpProductModule(), new ExpertQuoteBopSmokeModule()]);
        Assert.Multiple(() =>
        {
            Assert.That(registry.Resolve(ExpertQuoteBopSmokeInputs.AlabamaIdentity), Is.SameAs(registry.Modules[1]));
            Assert.That(module.RetrySafe, Is.False);
            Assert.That(module.RequiredCapabilities, Does.Contain(ProductCapability.FrameScope).And.Contain(ProductCapability.DataProfile));
            Assert.That(registry.TryResolve("SGS-CLEQ-04-EQ-SFP-SMOKE-TEST:AL"), Is.Null);
        });
    }
}
