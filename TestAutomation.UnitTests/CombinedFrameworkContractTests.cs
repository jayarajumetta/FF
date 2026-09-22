using NUnit.Framework;
using System.Text.Json;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class CombinedFrameworkContractTests
{
    private JsonElement _contract;

    [OneTimeSetUp]
    public void LoadContract()
    {
        var path = Path.Combine(
            FindRepositoryRoot(),
            "Resources",
            "Contracts",
            "combined-framework-contract.json");
        using var document = JsonDocument.Parse(File.ReadAllText(path));
        _contract = document.RootElement.Clone();
    }

    [Test]
    public void ScenarioStateHasOneOwnerAndRequiredDataFailsExplicitly()
    {
        var state = _contract.GetProperty("scenarioState");

        Assert.Multiple(() =>
        {
            Assert.That(state.GetProperty("owner").GetString(), Is.EqualTo("ScenarioContextData"));
            Assert.That(state.GetProperty("contextKey").GetString(), Is.EqualTo("ContextData"));
            Assert.That(state.GetProperty("missingRequiredValue").GetString(), Is.EqualTo("fail"));
            Assert.That(state.GetProperty("flattenedKeyCollisions").GetString(), Is.EqualTo("fail"));
        });
    }

    [Test]
    public void ControlContractRequiresSemanticStateNotVisibility()
    {
        var controls = _contract.GetProperty("controls");
        var captureSemantics = controls
            .GetProperty("captureSemantics")
            .EnumerateArray()
            .Select(value => value.GetString())
            .ToArray();

        Assert.Multiple(() =>
        {
            Assert.That(
                controls.GetProperty("selectedValueAssertion").GetString(),
                Is.EqualTo("actual-selected-value"));
            Assert.That(controls.GetProperty("trueAssertion").GetString(),
                Is.EqualTo("checked-or-selected"));
            Assert.That(controls.GetProperty("enabledAssertion").GetString(),
                Is.EqualTo("enabled"));
            Assert.That(captureSemantics, Is.EquivalentTo(new[] { "value", "checked", "selected" }));
        });
    }

    [Test]
    public void FrameAndEvidenceContractsRejectSuccessShapedGaps()
    {
        var frames = _contract.GetProperty("frames");
        var evidence = _contract.GetProperty("evidence");

        Assert.Multiple(() =>
        {
            Assert.That(frames.GetProperty("resolvedScopeMustReachAction").GetBoolean(), Is.True);
            Assert.That(frames.GetProperty("resolutionEvidenceRequired").GetBoolean(), Is.True);
            Assert.That(evidence.GetProperty("missingRequiredEvidence").GetString(), Is.EqualTo("fail"));
            Assert.That(evidence.GetProperty("uniqueCheckpointScreenshots").GetBoolean(), Is.True);
            Assert.That(
                evidence.GetProperty("checkpointScreenshotPattern").GetString(),
                Does.Contain("{ordinal}"));
        });
    }

    [Test]
    public void DataProfileAndRetryContractsPreventSilentOrUnsafeFallbacks()
    {
        var profiles = _contract.GetProperty("dataProfiles");
        var retry = _contract.GetProperty("retry");

        Assert.Multiple(() =>
        {
            Assert.That(profiles.GetProperty("missingRequiredValue").GetString(), Is.EqualTo("fail"));
            Assert.That(profiles.GetProperty("profileChecksumRequired").GetBoolean(), Is.True);
            Assert.That(profiles.GetProperty("staleChecksum").GetString(), Is.EqualTo("fail"));
            Assert.That(
                retry.GetProperty("stateChangingUiRetry").GetString(),
                Is.EqualTo("disabled-unless-idempotent"));
            Assert.That(retry.GetProperty("oneFinalOutcomePerScenario").GetBoolean(), Is.True);
        });
    }

    [Test]
    public void PackageContractListsEveryRuntimeCategory()
    {
        var package = _contract.GetProperty("package");
        var inventory = package
            .GetProperty("requiredInventory")
            .EnumerateArray()
            .Select(value => value.GetString())
            .ToArray();

        Assert.Multiple(() =>
        {
            Assert.That(package.GetProperty("oneVersionedArtifact").GetBoolean(), Is.True);
            Assert.That(inventory, Does.Contain("TestAutomation.dll"));
            Assert.That(inventory, Does.Contain("DataPool/DataPool.dll"));
            Assert.That(inventory, Does.Contain("playwright.ps1"));
            Assert.That(inventory, Does.Contain("Resources"));
            Assert.That(inventory, Does.Contain("ci.runsettings"));
            Assert.That(inventory, Does.Contain("Scripts"));
            Assert.That(inventory, Does.Contain("package-manifest.json"));
            Assert.That(inventory, Does.Contain("Tools/SgsReport/SgsReport.dll"));
            Assert.That(inventory, Does.Contain("Tools/SgsReport/SgsReport.deps.json"));
            Assert.That(inventory, Does.Contain("Tools/SgsReport/SgsReport.runtimeconfig.json"));
            Assert.That(
                inventory,
                Does.Contain(
                    "Resources/Contracts/integration-readiness.json"));
            Assert.That(
                inventory,
                Does.Contain(
                    "Scripts/CI/Invoke-StabilizationVerification.ps1"));
        });
    }

    private static string FindRepositoryRoot()
    {
        var directory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
        while (directory != null)
        {
            if (File.Exists(Path.Combine(directory.FullName, "TestAutomation.csproj")))
                return directory.FullName;
            directory = directory.Parent;
        }

        throw new DirectoryNotFoundException("Could not locate the repository root.");
    }
}
