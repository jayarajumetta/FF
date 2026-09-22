using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NUnit.Framework;
using PnCTestAutomation.DataProfiles;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.QuoteHandoffs;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public sealed class SgsRuntimeCompositionTests
{
    [Test]
    public void RegisteredAdapterSharesScenarioStateAndQuoteHandoffWithoutCrossScopeLeakage()
    {
        var services = new ServiceCollection();
        new Startup().ConfigureServices(services);
        services.RemoveAll<ScenarioContextData>();
        services.AddScoped<ScenarioContextData>();
        using var provider = services.BuildServiceProvider();
        using var first = provider.CreateScope();
        using var second = provider.CreateScope();
        var data = first.ServiceProvider.GetRequiredService<ISgsScenarioData>();
        var owner = first.ServiceProvider.GetRequiredService<ScenarioContextData>();
        var handoff = first.ServiceProvider.GetRequiredService<IQuoteHandoff>();
        var otherData = second.ServiceProvider.GetRequiredService<ISgsScenarioData>();
        var otherOwner = second.ServiceProvider.GetRequiredService<ScenarioContextData>();

        data.Load(new("CLEQ", @"TestData\Scenarios\Smoke\03_eq_bop_smoke_test_al.json", "AL",
            @"TestData\ExternalDataOverrides.json"));
        data.CaptureBuffer("Quote_Num", "01234567");

        Assert.Multiple(() =>
        {
            Assert.That(first.ServiceProvider.GetRequiredService<ISgsScenarioData>(), Is.SameAs(data));
            Assert.That(otherData, Is.Not.SameAs(data));
            Assert.That(owner.SgsData.IsLoaded, Is.True);
            Assert.That(owner.QuoteNumber, Is.EqualTo("01234567"));
            Assert.That(handoff.Require("SGS runtime contract").QuoteNumber, Is.EqualTo("01234567"));
            Assert.That(otherOwner.SgsData.IsLoaded, Is.False);
            Assert.That(second.ServiceProvider.GetRequiredService<IQuoteHandoff>().TryGet(out _), Is.False);
            Assert.That(data.GetRequired("values.effective_date"), Is.EqualTo("03-01-2025"));
        });
    }
}
