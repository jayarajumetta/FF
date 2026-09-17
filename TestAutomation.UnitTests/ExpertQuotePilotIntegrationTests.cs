using System.Text.Json;
using NUnit.Framework;
using PnCTestAutomation.TestPlanPublisher;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class ExpertQuotePilotIntegrationTests
{
    [Test]
    public void PilotHasOneNonOverlappingShardAndDoesNotEnableRetry()
    {
        var root = FindRepositoryRoot();
        using var catalog = JsonDocument.Parse(File.ReadAllText(
            Path.Combine(root, "Pipelines", "config", "shards.json")));
        var suite = catalog.RootElement
            .GetProperty("suites")
            .EnumerateArray()
            .Single(item =>
                item.GetProperty("name").GetString() ==
                "ExpertQuotePilot");
        var shard = catalog.RootElement
            .GetProperty("shards")
            .EnumerateArray()
            .Single(item =>
                item.GetProperty("id").GetString() ==
                "EqBopAlPilot");
        var feature = File.ReadAllText(Path.Combine(
            root,
            "Features",
            "BOP",
            "EQBOP_AL_Pilot.feature"));

        Assert.Multiple(() =>
        {
            Assert.That(
                suite.GetProperty("shards").GetArrayLength(),
                Is.EqualTo(1));
            Assert.That(
                shard.GetProperty("suite").GetString(),
                Is.EqualTo("ExpertQuotePilot"));
            Assert.That(feature, Does.Contain("@EqBopAlPilot"));
            Assert.That(feature, Does.Contain("@AutomationId-EQ-BOP-SMOKE"));
            Assert.That(feature, Does.Contain("@NonRunnable"));
            Assert.That(feature, Does.Contain("@NoRetry"));
            Assert.That(feature, Does.Not.Contain("@RetrySafe"));
        });
    }

    [Test]
    public void RepositoryMappingTemplateDefersPilotUntilAdoOwnershipExists()
    {
        var root = FindRepositoryRoot();
        var catalog = JsonSerializer.Deserialize<TestPlanMappingCatalog>(
            File.ReadAllText(Path.Combine(
                root,
                "Pipelines",
                "config",
                "testplans-mapping.template.json")),
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

        Assert.Multiple(() =>
        {
            Assert.That(
                catalog.DeferredAutomationIds,
                Is.EqualTo(["EQ-BOP-SMOKE:AL"]));
            Assert.That(() => catalog.Validate([]), Throws.Nothing);
        });
    }

    [Test]
    public async Task PilotAutomationIdentityMaintainsDryRunParity()
    {
        var root = Path.Combine(
            Path.GetTempPath(),
            "PnC-EqBop-Ado-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        try
        {
            var output = Path.Combine(root, "dry-run.json");
            var state = Path.Combine(root, "reconciliation.json");
            var mapping = new TestPlanMappingEntry
            {
                AutomationId = "EQ-BOP-SMOKE:AL",
                PlanId = 1,
                SuiteId = 2,
                TestCaseId = 3,
                ConfigurationId = 4
            };
            var batch = new TestPlanPublicationBatch(
                "eq-bop-correlation",
                "1.1.0",
                "commit",
                "build",
                "catalog",
                "checksum",
                "qa",
                "chromium",
                "EqBopAlPilot",
                1,
                [
                    new CanonicalTestExecution(
                        "EQ-BOP-SMOKE:AL",
                        "Create, close, and retrieve the Alabama BOP quote",
                        CanonicalTestOutcome.Passed,
                        TimeSpan.FromSeconds(1),
                        mapping,
                        [],
                        [])
                ]);

            var receipt = await new DryRunFileTestPlanPublisher(output)
                .PublishAsync(batch, state);
            using var document = JsonDocument.Parse(
                File.ReadAllText(output));
            var execution = document.RootElement
                .GetProperty("executions")[0];

            Assert.Multiple(() =>
            {
                Assert.That(receipt.PublishedResults, Is.EqualTo(1));
                Assert.That(
                    execution.GetProperty("automationId").GetString(),
                    Is.EqualTo("EQ-BOP-SMOKE:AL"));
                Assert.That(
                    execution.GetProperty("outcome").GetString(),
                    Is.EqualTo("Passed"));
            });
        }
        finally
        {
            if (Directory.Exists(root))
                Directory.Delete(root, recursive: true);
        }
    }

    private static string FindRepositoryRoot()
    {
        var directory = new DirectoryInfo(
            TestContext.CurrentContext.TestDirectory);
        while (directory != null)
        {
            if (File.Exists(Path.Combine(
                    directory.FullName,
                    "TestAutomation.csproj")))
            {
                return directory.FullName;
            }
            directory = directory.Parent;
        }
        throw new DirectoryNotFoundException(
            "Could not locate the repository root.");
    }
}
