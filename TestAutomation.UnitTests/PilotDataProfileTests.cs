using System.Text.Json;
using System.Text.Json.Serialization;
using NUnit.Framework;
using PnCTestAutomation.DataProfiles;
using PnCTestAutomation.Products;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class PilotDataProfileTests
{
    private static readonly DateTimeOffset ValidationTime =
        new(2026, 9, 17, 12, 0, 0, TimeSpan.Zero);

    [Test]
    public void RepositoryProfilePreservesSourceProvenanceAndIsNonRunnable()
    {
        var catalog = ReadRepositoryCatalog();
        var provider = new PilotDataProfileProvider(
            catalog,
            () => ValidationTime);
        var resolution = provider.Resolve(
            ExpertQuoteBopPilotModule.DataProfileId,
            "qa",
            "AL");

        Assert.Multiple(() =>
        {
            Assert.That(catalog.SourceRepository, Is.EqualTo("PnC_DC_TestAutomation"));
            Assert.That(catalog.SourceFiles, Has.Count.EqualTo(22));
            Assert.That(
                catalog.SourceFiles.Single(source =>
                    source.Path.EndsWith(
                        "03_eq_bop_smoke_test_al.json",
                        StringComparison.Ordinal)).Sha256,
                Is.EqualTo(
                    "64FCA2C4AA23CB746156FB388A80503D1487D0D7ADD0D99D92723BB656721FF6"));
            Assert.That(resolution.IsRunnable, Is.False);
            Assert.That(
                resolution.Profile.MissingRequiredKeys,
                Does.Contain("client.ssn"));
            Assert.That(
                resolution.Values["proposal.product"],
                Is.EqualTo("Business Owners"));
            Assert.That(
                resolution.Values.Keys,
                Does.Not.Contain("client.ssn"));
        });
    }

    [Test]
    public void ResolutionUsesExplicitPrecedence()
    {
        var catalog = ValidCatalog();
        catalog.Profiles[0].Layers.Add(new PilotDataLayer
        {
            Name = "state",
            Precedence = 200,
            Values = new Dictionary<string, string>
            {
                ["proposal.product"] = "Business Owners"
            }
        });
        catalog.Profiles[0].Checksum =
            PilotDataProfileValidator.ComputeChecksum(
                catalog,
                catalog.Profiles[0]);

        var resolution = new PilotDataProfileProvider(
                catalog,
                () => ValidationTime)
            .Resolve("eq-bop-al-smoke", "qa", "AL");

        Assert.That(
            resolution.Values["proposal.product"],
            Is.EqualTo("Business Owners"));
    }

    [TestCase("missing")]
    [TestCase("collision")]
    [TestCase("synthetic")]
    [TestCase("secret")]
    [TestCase("precedence")]
    [TestCase("stale")]
    [TestCase("checksum")]
    public void InvalidProfilesFailClosed(string defect)
    {
        var catalog = ValidCatalog();
        var profile = catalog.Profiles[0];
        switch (defect)
        {
            case "missing":
                profile.MissingRequiredKeys.Clear();
                profile.Layers[0].Values.Remove("proposal.product");
                break;
            case "collision":
                profile.Layers[0].Values["account.product"] = "BOP";
                break;
            case "synthetic":
                profile.Layers[0].Values["proposal.product"] =
                    "{{product}}";
                break;
            case "secret":
                profile.Layers[0].Values["auth.password"] = "not-a-secret";
                break;
            case "precedence":
                profile.Layers.Add(new PilotDataLayer
                {
                    Name = "duplicate-order",
                    Precedence = 100,
                    Values = new Dictionary<string, string>
                    {
                        ["proposal.other"] = "value"
                    }
                });
                break;
            case "stale":
                profile.ValidUntilUtc = ValidationTime.AddDays(-1);
                break;
        }
        profile.Checksum = PilotDataProfileValidator.ComputeChecksum(
            catalog,
            profile);
        if (defect == "checksum")
            profile.Checksum = new string('0', 64);

        Assert.That(
            () => PilotDataProfileValidator.ValidateCatalog(
                catalog,
                ValidationTime),
            Throws.TypeOf<PilotDataConfigurationException>());
    }

    private static PilotDataCatalog ReadRepositoryCatalog()
    {
        var path = Path.Combine(
            FindRepositoryRoot(),
            "Resources",
            "DataProfiles",
            "eq-bop-pilot.json");
        return JsonSerializer.Deserialize<PilotDataCatalog>(
            File.ReadAllText(path),
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter() }
            })!;
    }

    private static PilotDataCatalog ValidCatalog()
    {
        var profile = new PilotDataProfile
        {
            ProfileId = "eq-bop-al-smoke",
            Version = "1.0.0",
            ModuleId = "expertquote-bop-al-pilot",
            Environment = "qa",
            State = "AL",
            Mode = PilotDataProfileMode.Approved,
            ValidUntilUtc = ValidationTime.AddDays(30),
            RequiredKeys = ["proposal.product"],
            Layers =
            [
                new PilotDataLayer
                {
                    Name = "base",
                    Precedence = 100,
                    Values = new Dictionary<string, string>
                    {
                        ["proposal.product"] = "BOP"
                    }
                }
            ]
        };
        var catalog = new PilotDataCatalog
        {
            SchemaVersion = 1,
            CatalogVersion = "1.0.0",
            SourceRepository = "source",
            SourceFiles =
            [
                new PilotSourceFile
                {
                    Path = "source.json",
                    Sha256 = new string('A', 64)
                }
            ],
            Profiles = [profile]
        };
        profile.Checksum =
            PilotDataProfileValidator.ComputeChecksum(catalog, profile);
        return catalog;
    }

    private static string FindRepositoryRoot()
    {
        var directory = new DirectoryInfo(
            TestContext.CurrentContext.TestDirectory);
        while (directory != null)
        {
            if (File.Exists(
                    Path.Combine(directory.FullName, "TestAutomation.csproj")))
            {
                return directory.FullName;
            }
            directory = directory.Parent;
        }
        throw new DirectoryNotFoundException(
            "Could not locate the repository root.");
    }
}
