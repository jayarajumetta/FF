using System.Text.Json;
using NUnit.Framework;
using PnCTestAutomation.TestPlanPublisher;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class CommercialDuckCreekPilotIntegrationTests
{
    [Test]
    public void PilotHasOneIsolatedShardAndNoRetryTag()
    {
        var root = FindRepositoryRoot();
        using var catalog = JsonDocument.Parse(File.ReadAllText(
            Path.Combine(root, "Pipelines", "config", "shards.json")));
        var suite = catalog.RootElement
            .GetProperty("suites")
            .EnumerateArray()
            .Single(item =>
                item.GetProperty("name").GetString() ==
                "CommercialDuckCreekPilot");
        var shard = catalog.RootElement
            .GetProperty("shards")
            .EnumerateArray()
            .Single(item =>
                item.GetProperty("id").GetString() ==
                "CldcBapAlPilot");
        var feature = File.ReadAllText(Path.Combine(
            root,
            "Features",
            "BOP",
            "CLDC_BAP_AL_Pilot.feature"));

        Assert.Multiple(() =>
        {
            Assert.That(
                suite.GetProperty("shards").GetArrayLength(),
                Is.EqualTo(1));
            Assert.That(
                shard.GetProperty("suite").GetString(),
                Is.EqualTo("CommercialDuckCreekPilot"));
            Assert.That(feature, Does.Contain("@CldcBapAlPilot"));
            Assert.That(
                feature,
                Does.Contain("@AutomationId-CLDC-BAP-SMOKE"));
            Assert.That(feature, Does.Contain("@NonRunnable"));
            Assert.That(feature, Does.Contain("@NoRetry"));
            Assert.That(feature, Does.Not.Contain("@RetrySafe"));
        });
    }

    [Test]
    public async Task PilotAutomationIdentityMaintainsDryRunParity()
    {
        var root = Path.Combine(
            Path.GetTempPath(),
            "PnC-CldcBap-Ado-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        try
        {
            var output = Path.Combine(root, "dry-run.json");
            var state = Path.Combine(root, "reconciliation.json");
            var mapping = new TestPlanMappingEntry
            {
                AutomationId = "CLDC-BAP-SMOKE:AL",
                PlanId = 11,
                SuiteId = 12,
                TestCaseId = 13,
                ConfigurationId = 14
            };
            var batch = new TestPlanPublicationBatch(
                "cldc-bap-correlation",
                "1.3.0",
                "commit",
                "build",
                "catalog",
                "checksum",
                "qa",
                "chromium",
                "CldcBapAlPilot",
                1,
                [
                    new CanonicalTestExecution(
                        "CLDC-BAP-SMOKE:AL",
                        "Create, save, and reopen the Alabama BAP quote",
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
                    Is.EqualTo("CLDC-BAP-SMOKE:AL"));
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
            if (File.Exists(
                    Path.Combine(
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
