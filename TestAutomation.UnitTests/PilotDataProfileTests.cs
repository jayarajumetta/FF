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
    public void CommercialDuckCreekProfileHasCompleteRedactedProvenance()
    {
        var catalog = ReadRepositoryCatalog("cldc-bap-pilot.json");
        var resolution = new PilotDataProfileProvider(
                catalog,
                () => ValidationTime)
            .Resolve(
                CommercialDuckCreekBapPilotModule.DataProfileId,
                "qa",
                "AL");

        Assert.Multiple(() =>
        {
            Assert.That(catalog.SourceFiles, Has.Count.EqualTo(46));
            Assert.That(
                catalog.SourceFiles.Single(source =>
                    source.Path.EndsWith(
                        "012_bap_smoke_test_al.json",
                        StringComparison.Ordinal)).Sha256,
                Is.EqualTo(
                    "6A6629A2281F495060137731320F03178068193B4DDBDB8C0DA0124C4E39E7C2"));
            Assert.That(
                catalog.SourceFiles.Single(source =>
                    source.Path.EndsWith(
                        "DuckCreekFrameHints.json",
                        StringComparison.Ordinal)).Sha256,
                Is.EqualTo(
                    "6F4DDFABA85EA620CE17AD401AEB940B0F047B7C3FBF45FEF20F8999B1D25D32"));
            Assert.That(resolution.IsRunnable, Is.False);
            Assert.That(
                resolution.Profile.MissingRequiredKeys,
                Does.Contain("identity.ssn"));
            Assert.That(
                resolution.Profile.MissingRequiredKeys,
                Does.Contain("policy.effectiveDate"));
            Assert.That(
                resolution.Profile.MissingRequiredKeys,
                Does.Contain("quote.reopenExpectation"));
            Assert.That(
                resolution.Values["policy.primaryState"],
                Is.EqualTo("Alabama"));
            Assert.That(
                resolution.Values.Keys.Any(key =>
                    key.Contains(
                        "password",
                        StringComparison.OrdinalIgnoreCase)),
                Is.False);
            Assert.That(
                resolution.Values.Values,
                Has.None.EqualTo("12-01-2025"));
        });
    }

    [Test]
    public void PersonalDuckCreekProfilesPreserveSourceAndBlockUnsafeData()
    {
        var catalog = ReadRepositoryCatalog("pldc-auto-pilot.json");
        var provider = new PilotDataProfileProvider(
            catalog,
            () => ValidationTime);
        var smoke = provider.Resolve(
            PersonalDuckCreekAutoSmokePilotModule.DataProfileId,
            "qa",
            "AZ");
        var microcase = provider.Resolve(
            PersonalDuckCreekStateMaritalPilotModule.DataProfileId,
            "qa",
            "AL");

        Assert.Multiple(() =>
        {
            Assert.That(catalog.SourceFiles, Has.Count.EqualTo(50));
            Assert.That(
                catalog.SourceFiles.Single(source =>
                    source.Path.EndsWith(
                        "211_Smoke_Test_Auto.feature",
                        StringComparison.Ordinal)).Sha256,
                Is.EqualTo(
                    "29FD4E2A4013FC06A3902F68411E6CF6829D21CC4D2A0DF93538660B0E13A8E1"));
            Assert.That(
                catalog.SourceFiles.Single(source =>
                    source.Path.EndsWith(
                        "AccountInformationPage.cs",
                        StringComparison.Ordinal)).Sha256,
                Is.EqualTo(
                    "08EA1A8FEE8C7C35B5AF2DE7CB826AF29A79C5E525A489E1C5721B27C58749F9"));
            Assert.That(smoke.IsRunnable, Is.False);
            Assert.That(
                smoke.Values["proposal.writingCompany"],
                Is.EqualTo("ANG"));
            Assert.That(
                smoke.Values["account.maritalStatus"],
                Is.EqualTo("Single"));
            Assert.That(
                smoke.Profile.MissingRequiredKeys,
                Does.Contain("proposal.effectiveDate"));
            Assert.That(microcase.IsRunnable, Is.False);
            Assert.That(
                microcase.Values["address.stateName"],
                Is.EqualTo("Alabama"));
            Assert.That(
                microcase.Profile.MissingRequiredKeys,
                Does.Contain("account.maritalStatus"));
            Assert.That(
                microcase.Values.Keys.Any(key =>
                    key.Contains(
                        "password",
                        StringComparison.OrdinalIgnoreCase)),
                Is.False);
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

    [Test]
    public void MultipleCatalogsResolveIndependentlyAndRejectAmbiguousKeys()
    {
        var first = ValidCatalog();
        var second = ValidCatalog();
        second.CatalogVersion = "2.0.0";
        second.Profiles[0].ProfileId = "cldc-bap-al-smoke";
        second.Profiles[0].ModuleId =
            "commercial-duckcreek-bap-al-pilot";
        second.Profiles[0].Checksum =
            PilotDataProfileValidator.ComputeChecksum(
                second,
                second.Profiles[0]);
        var provider = new PilotDataProfileProvider(
            [first, second],
            () => ValidationTime);

        var resolution = provider.Resolve(
            "cldc-bap-al-smoke",
            "qa",
            "AL");

        Assert.Multiple(() =>
        {
            Assert.That(
                resolution.Profile.ModuleId,
                Is.EqualTo("commercial-duckcreek-bap-al-pilot"));
            Assert.That(
                () => new PilotDataProfileProvider(
                    [first, first],
                    () => ValidationTime),
                Throws.TypeOf<PilotDataConfigurationException>()
                    .With.Message.Contains("ambiguous across catalogs"));
        });
    }

    [Test]
    public void CatalogOptionsRejectDuplicatesAndSupportExclusiveOverride()
    {
        var options = new PilotDataProfileOptions
        {
            CatalogPath = "first.json",
            AdditionalCatalogPaths = ["FIRST.JSON"]
        };

        Assert.That(
            options.Validate,
            Throws.TypeOf<PilotDataConfigurationException>()
                .With.Message.Contains("Duplicate"));

        options.UseExclusiveCatalog("external.json");

        Assert.Multiple(() =>
        {
            Assert.That(options.Validate, Throws.Nothing);
            Assert.That(
                options.GetCatalogPaths(),
                Is.EqualTo(["external.json"]));
        });
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

    private static PilotDataCatalog ReadRepositoryCatalog(
        string fileName = "eq-bop-pilot.json")
    {
        var path = Path.Combine(
            FindRepositoryRoot(),
            "Resources",
            "DataProfiles",
            fileName);
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
