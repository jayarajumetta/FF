using System.Text.Json;
using NUnit.Framework;
using PnCTestAutomation.Products;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class IntegrationReadinessTests
{
    [Test]
    public void MatrixMatchesCompiledModulesAndRemainsGated()
    {
        using var matrix = ReadJson(
            "Resources",
            "Contracts",
            "integration-readiness.json");
        var root = matrix.RootElement;
        var workflows = root.GetProperty("workflows")
            .EnumerateArray()
            .ToArray();
        var modules = Registry().Modules;
        var requiredRoles = root.GetProperty("requiredApprovalRoles")
            .EnumerateArray()
            .Select(item => item.GetString()!)
            .ToArray();

        Assert.Multiple(() =>
        {
            Assert.That(root.GetProperty("packageVersion").GetString(),
                Is.EqualTo("1.4.0"));
            Assert.That(
                File.ReadAllText(Path.Combine(
                    FindRepositoryRoot(),
                    "Pipelines",
                    "package-version.txt")).Trim(),
                Is.EqualTo("1.4.0"));
            Assert.That(
                root.GetProperty("topologyDecision").GetString(),
                Is.EqualTo("ProvisionalInAssembly"));
            Assert.That(workflows, Has.Length.EqualTo(7));
            Assert.That(
                workflows.Select(workflow =>
                    workflow.GetProperty("workflowId").GetString()!),
                Is.Unique);
            Assert.That(
                workflows.Select(workflow =>
                    workflow.GetProperty("stableAutomationId").GetString()!),
                Is.Unique);
            Assert.That(
                requiredRoles,
                Is.EquivalentTo(new[]
                {
                    "Architecture/David",
                    "QA",
                    "Security/Operations",
                    "DevOps/ADO"
                }));
        });

        foreach (var workflow in workflows)
        {
            var workflowId =
                workflow.GetProperty("workflowId").GetString()!;
            var moduleId =
                workflow.GetProperty("moduleId").GetString()!;
            var module = modules.Single(item =>
                item.ModuleId == moduleId);
            var family =
                workflow.GetProperty("automationIdFamily").GetString();
            var profile = workflow.GetProperty("profile");
            var evidence = workflow.GetProperty("evidenceContract")
                .EnumerateArray()
                .Select(item => item.GetString()!)
                .ToArray();
            var approvals = workflow.GetProperty("approvalEvidence")
                .EnumerateArray()
                .ToArray();
            var blockers = workflow.GetProperty("blockers")
                .EnumerateArray()
                .ToArray();

            Assert.Multiple(() =>
            {
                Assert.That(
                    module.AutomationIdFamilies,
                    Does.Contain(family),
                    workflowId);
                Assert.That(
                    profile.GetProperty("contractId").GetString(),
                    Is.EqualTo(module.DataProfileId),
                    workflowId);
                Assert.That(
                    evidence,
                    Is.EquivalentTo(module.Evidence.RequiredArtifacts
                        .Select(item => item.ToString())),
                    workflowId);
                Assert.That(
                    workflow.GetProperty("retryPolicy").GetString(),
                    Is.EqualTo("NoRetry"),
                    workflowId);
                Assert.That(module.RetrySafe, Is.False, workflowId);
                Assert.That(
                    workflow.GetProperty("state").GetString(),
                    Is.EqualTo("Gated"),
                    workflowId);
                Assert.That(
                    workflow.GetProperty("requiredBusinessAssertions")
                        .GetArrayLength(),
                    Is.GreaterThan(0),
                    workflowId);
                Assert.That(blockers, Is.Not.Empty, workflowId);
                Assert.That(
                    approvals.Select(approval =>
                        approval.GetProperty("role").GetString()),
                    Is.EquivalentTo(requiredRoles),
                    workflowId);
                Assert.That(
                    approvals.All(approval =>
                        !string.IsNullOrWhiteSpace(
                            approval.GetProperty("required").GetString())),
                    Is.True,
                    workflowId);
                Assert.That(
                    blockers.All(blocker =>
                        requiredRoles.Contains(
                            blocker.GetProperty("owner").GetString())),
                    Is.True,
                    workflowId);
            });

            var selectorStatus = workflow
                .GetProperty("selectorFrameStatus")
                .GetString();
            Assert.That(
                module.BlockedSelectors.Count > 0,
                Is.EqualTo(selectorStatus == "Blocked"),
                workflowId);
        }
    }

    [Test]
    public void MatrixMatchesProfilesShardsAndDeferredMappings()
    {
        var repositoryRoot = FindRepositoryRoot();
        using var matrix = ReadJson(
            "Resources",
            "Contracts",
            "integration-readiness.json");
        using var shards = ReadJson(
            "Pipelines",
            "config",
            "shards.json");
        using var mappings = ReadJson(
            "Pipelines",
            "config",
            "testplans-mapping.template.json");
        var shardIds = shards.RootElement.GetProperty("shards")
            .EnumerateArray()
            .Select(item => item.GetProperty("id").GetString()!)
            .ToHashSet(StringComparer.Ordinal);
        var deferred = mappings.RootElement
            .GetProperty("deferredAutomationIds")
            .EnumerateArray()
            .Select(item => item.GetString()!)
            .ToHashSet(StringComparer.Ordinal);

        foreach (var workflow in matrix.RootElement
                     .GetProperty("workflows")
                     .EnumerateArray())
        {
            var id = workflow.GetProperty("workflowId").GetString()!;
            var profile = workflow.GetProperty("profile");
            var profilePath = profile
                .GetProperty("catalogPath")
                .GetString()!
                .Replace("test/", "", StringComparison.Ordinal)
                .Replace('/', Path.DirectorySeparatorChar);
            Assert.That(
                File.Exists(Path.Combine(repositoryRoot, profilePath)),
                Is.True,
                id);

            foreach (var ownership in workflow
                         .GetProperty("shardOwnership")
                         .EnumerateArray())
            {
                foreach (var shard in ownership
                             .GetProperty("shards")
                             .EnumerateArray())
                {
                    Assert.That(
                        shardIds,
                        Does.Contain(shard.GetString()),
                        id);
                }
            }

            var adoStatus = workflow
                .GetProperty("adoMappingStatus")
                .GetString();
            if (adoStatus == "Deferred")
            {
                Assert.That(
                    deferred,
                    Does.Contain(workflow
                        .GetProperty("stableAutomationId")
                        .GetString()),
                    id);
            }
            else
            {
                Assert.That(adoStatus, Is.EqualTo("ExternalRequired"), id);
            }
        }
    }

    private static ProductModuleRegistry Registry() =>
        new(
        [
            new SfpProductModule(),
            new ExpertQuoteBopPilotModule(),
            new CommercialDuckCreekBapPilotModule(),
            new PersonalDuckCreekAutoSmokePilotModule(),
            new PersonalDuckCreekStateMaritalPilotModule()
        ]);

    private static JsonDocument ReadJson(params string[] path) =>
        JsonDocument.Parse(File.ReadAllText(
            Path.Combine([FindRepositoryRoot(), .. path])));

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
