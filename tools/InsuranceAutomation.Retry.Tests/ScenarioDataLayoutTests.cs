using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using InsuranceAutomation.Core;
using NUnit.Framework;

namespace InsuranceAutomation.Data.Tests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class ScenarioDataLayoutTests
{
    private string _directory = null!;
    private string _testDataRoot = null!;

    [SetUp]
    public void SetUp()
    {
        _directory = Path.Combine(AppContext.BaseDirectory, "scenario-data-" + Guid.NewGuid().ToString("N"));
        _testDataRoot = Path.Combine(_directory, "TestData");
        Directory.CreateDirectory(_testDataRoot);
    }

    [TearDown]
    public void TearDown() => Directory.Delete(_directory, recursive: true);

    [TestCase("", false)]
    [TestCase("Basic", false)]
    [TestCase("Smoke", false)]
    [TestCase("Basic/Nested", false)]
    [TestCase("", true)]
    [TestCase("Basic", true)]
    [TestCase("Smoke", true)]
    public void LoadsLayeredDataFromFlatAndCategorizedScenarios(string category, bool relativePath)
    {
        var scenario = WriteScenario(category);
        WriteLayers(scenario);
        var data = new ScenarioData(new FrameworkConfig());

        data.Load(relativePath ? Path.GetRelativePath(RepositoryRoot(), scenario) : scenario,
            Path.Combine(_testDataRoot, "ExternalDataOverrides.json"));

        Assert.That(data.Get("policy"), Is.EqualTo("layered"));
        Assert.That(data.Get("inherited"), Is.EqualTo("base"));
    }

    [TestCase("")]
    [TestCase("Basic")]
    [TestCase("Smoke")]
    public void LoadsSourceDataWhenNoLayeredManifestExists(string category)
    {
        var scenario = WriteScenario(category);
        var data = new ScenarioData(new FrameworkConfig());

        data.Load(scenario, Path.Combine(_testDataRoot, "ExternalDataOverrides.json"));

        Assert.That(data.Get("policy"), Is.EqualTo("source"));
    }

    [Test]
    public void CanonicalFieldLookupFallsBackToPromotedScenarioValue()
    {
        var scenario = WriteScenario("Basic");
        File.WriteAllText(scenario, "{\"values\":{\"Address 1\":\"100 Main Street\"}}");
        var data = new ScenarioData(new FrameworkConfig());

        data.Load(scenario, Path.Combine(_testDataRoot, "ExternalDataOverrides.json"));

        Assert.That(data.GetCanonicalFieldRequired("Address 1"), Is.EqualTo("100 Main Street"));
    }

    [Test]
    public void CategorizedScenarioUsesSourceWhenLayeredHashIsStale()
    {
        var scenario = WriteScenario("Basic");
        WriteLayers(scenario);
        File.WriteAllText(scenario, "{\"values\":{\"policy\":\"edited source\"}}");
        var data = new ScenarioData(new FrameworkConfig());

        data.Load(scenario, Path.Combine(_testDataRoot, "ExternalDataOverrides.json"));

        Assert.That(data.Get("policy"), Is.EqualTo("edited source"));
    }

    [Test]
    public void CategorizedScenarioUsesSourceWhenOptionalLayersAreMissing()
    {
        var scenario = WriteScenario("Basic");
        WriteLayers(scenario);
        File.Delete(Path.Combine(_testDataRoot, "Layered", "Base.json"));
        var data = new ScenarioData(new FrameworkConfig());

        data.Load(scenario, Path.Combine(_testDataRoot, "ExternalDataOverrides.json"));

        Assert.That(data.Get("policy"), Is.EqualTo("source"));
    }

    [Test]
    public void CategorizedScenarioDoesNotSilentlyIgnoreInvalidLayeredData()
    {
        var scenario = WriteScenario("Basic");
        WriteLayers(scenario);
        File.WriteAllText(Path.Combine(_testDataRoot, "Layered", "Base.json"), "not json");
        var data = new ScenarioData(new FrameworkConfig());

        Action load = () => data.Load(scenario, Path.Combine(_testDataRoot, "ExternalDataOverrides.json"));
        Assert.Throws<InvalidOperationException>(load);
    }

    private string WriteScenario(string category)
    {
        var directory = Path.Combine(_testDataRoot, "Scenarios", category);
        Directory.CreateDirectory(directory);
        var path = Path.Combine(directory, "sample.json");
        File.WriteAllText(path, "{\"values\":{\"policy\":\"source\"}}");
        return path;
    }

    private void WriteLayers(string scenario)
    {
        var layeredRoot = Path.Combine(_testDataRoot, "Layered");
        Directory.CreateDirectory(layeredRoot);
        File.WriteAllText(Path.Combine(layeredRoot, "Base.json"),
            "{\"values\":{\"policy\":\"base\",\"inherited\":\"base\"}}");
        File.WriteAllText(Path.Combine(layeredRoot, "StateOverrides.json"),
            "{\"overrides\":{\"state\":{\"values\":{\"policy\":\"layered\"}}}}");
        var manifest = new
        {
            entries = new Dictionary<string, object>
            {
                ["sample.json"] = new
                {
                    baseFile = "Layered/Base.json",
                    overridesFile = "Layered/StateOverrides.json",
                    overrideKey = "state",
                    sourceFile = Path.GetRelativePath(_testDataRoot, scenario).Replace('\\', '/'),
                    sourceSha256 = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(File.ReadAllText(scenario))))
                }
            }
        };
        File.WriteAllText(Path.Combine(layeredRoot, "manifest.json"), JsonSerializer.Serialize(manifest));
    }

    private static string RepositoryRoot()
    {
        var current = new DirectoryInfo(AppContext.BaseDirectory);
        while (current is not null)
        {
            if (File.Exists(Path.Combine(current.FullName, "ToscaCanonicalSimple.sln")))
                return current.FullName;
            current = current.Parent;
        }
        throw new DirectoryNotFoundException("Repository root was not found.");
    }
}
