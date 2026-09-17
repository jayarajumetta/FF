using System.Text.Json;
using NUnit.Framework;
using PnCTestAutomation.TestPlanPublisher;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class PersonalDuckCreekPilotIntegrationTests
{
    [Test]
    public void PilotsHaveTwoDisjointOwnersAndNoRetryTags()
    {
        var root = FindRepositoryRoot();
        using var catalog = JsonDocument.Parse(File.ReadAllText(
            Path.Combine(root, "Pipelines", "config", "shards.json")));
        var suite = catalog.RootElement
            .GetProperty("suites")
            .EnumerateArray()
            .Single(item =>
                item.GetProperty("name").GetString() ==
                "PersonalDuckCreekPilot");
        var shards = catalog.RootElement
            .GetProperty("shards")
            .EnumerateArray()
            .Where(item =>
                item.GetProperty("suite").GetString() ==
                "PersonalDuckCreekPilot")
            .ToArray();
        var smoke = File.ReadAllText(Path.Combine(
            root,
            "Features",
            "Auto",
            "PLDC_Auto_AZ_ANG_Pilot.feature"));
        var microcase = File.ReadAllText(Path.Combine(
            root,
            "Features",
            "Auto",
            "PLDC_Auto_State_Marital_Pilot.feature"));

        Assert.Multiple(() =>
        {
            Assert.That(
                suite.GetProperty("shards").GetArrayLength(),
                Is.EqualTo(2));
            Assert.That(shards, Has.Length.EqualTo(2));
            Assert.That(
                shards.Select(item =>
                    item.GetProperty("id").GetString()),
                Is.Unique);
            Assert.That(smoke, Does.Contain("@PldcAutoAzAngPilot"));
            Assert.That(
                smoke,
                Does.Contain("@AutomationId-PLDC-AUTO-SMOKE"));
            Assert.That(
                microcase,
                Does.Contain("@PldcAutoStateMaritalPilot"));
            Assert.That(
                microcase,
                Does.Contain(
                    "@AutomationId-PLDC-AUTO-STATE-MARITAL"));
            Assert.That(smoke, Does.Contain("@NonRunnable"));
            Assert.That(microcase, Does.Contain("@NonRunnable"));
            Assert.That(smoke, Does.Contain("@NoRetry"));
            Assert.That(microcase, Does.Contain("@NoRetry"));
            Assert.That(smoke, Does.Not.Contain("@RetrySafe"));
            Assert.That(microcase, Does.Not.Contain("@RetrySafe"));
        });
    }

    [Test]
    public async Task BothAutomationIdsMaintainDryRunParity()
    {
        var root = Path.Combine(
            Path.GetTempPath(),
            "PnC-Pldc-Ado-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        try
        {
            var output = Path.Combine(root, "dry-run.json");
            var state = Path.Combine(root, "reconciliation.json");
            var smoke = Mapping("PLDC-AUTO-SMOKE:AZ", 21);
            var microcase = Mapping(
                "PLDC-AUTO-STATE-MARITAL:AL",
                22);
            var batch = new TestPlanPublicationBatch(
                "pldc-correlation",
                "1.4.0",
                "commit",
                "build",
                "catalog",
                "checksum",
                "qa",
                "chromium",
                "PersonalDuckCreekPilot",
                1,
                [
                    Execution(smoke, "AZ ANG smoke"),
                    Execution(microcase, "AL state marital microcase")
                ]);

            var receipt = await new DryRunFileTestPlanPublisher(output)
                .PublishAsync(batch, state);
            using var document = JsonDocument.Parse(
                File.ReadAllText(output));
            var ids = document.RootElement
                .GetProperty("executions")
                .EnumerateArray()
                .Select(item =>
                    item.GetProperty("automationId").GetString())
                .ToArray();

            Assert.Multiple(() =>
            {
                Assert.That(receipt.PublishedResults, Is.EqualTo(2));
                Assert.That(
                    ids,
                    Is.EquivalentTo(new[]
                    {
                        "PLDC-AUTO-SMOKE:AZ",
                        "PLDC-AUTO-STATE-MARITAL:AL"
                    }));
            });
        }
        finally
        {
            if (Directory.Exists(root))
                Directory.Delete(root, recursive: true);
        }
    }

    private static TestPlanMappingEntry Mapping(
        string automationId,
        int testCaseId) =>
        new()
        {
            AutomationId = automationId,
            PlanId = 1,
            SuiteId = 2,
            TestCaseId = testCaseId,
            ConfigurationId = 3
        };

    private static CanonicalTestExecution Execution(
        TestPlanMappingEntry mapping,
        string displayName) =>
        new(
            mapping.AutomationId,
            displayName,
            CanonicalTestOutcome.Passed,
            TimeSpan.FromSeconds(1),
            mapping,
            [],
            []);

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
