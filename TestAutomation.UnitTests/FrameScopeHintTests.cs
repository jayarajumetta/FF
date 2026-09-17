using NUnit.Framework;
using PnCTestAutomation.Controls;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class FrameScopeHintTests
{
    [Test]
    public void RepositoryCatalogRejectsGenericSourceHintWithoutApprovingIt()
    {
        var catalog = ReadRepositoryCatalog();

        Assert.Multiple(() =>
        {
            Assert.That(
                () => FrameScopeHintValidator.Validate(catalog),
                Throws.Nothing);
            Assert.That(catalog.Hints, Is.Empty);
            Assert.That(
                catalog.RejectedSourceHints,
                Is.EqualTo(new[] { "iframe" }));
        });
    }

    [Test]
    public void GenericAndDuplicateApprovedHintsFailClosed()
    {
        var generic = Catalog(
            new FrameScopeHint
            {
                ScopeId = "policy",
                PageIndex = 0,
                FramePath = ["iframe"]
            });
        generic.Checksum =
            FrameScopeHintValidator.ComputeChecksum(generic);
        var duplicate = Catalog(
            new FrameScopeHint
            {
                ScopeId = "policy",
                PageIndex = 0,
                FramePath = ["policy-frame"]
            },
            new FrameScopeHint
            {
                ScopeId = "policy",
                PageIndex = 0,
                FramePath = ["shell-frame", "nested-policy-frame"]
            });
        duplicate.Checksum =
            FrameScopeHintValidator.ComputeChecksum(duplicate);

        Assert.Multiple(() =>
        {
            Assert.That(
                () => FrameScopeHintValidator.Validate(generic),
                Throws.TypeOf<FrameScopeConfigurationException>()
                    .With.Message.Contains("generic"));
            Assert.That(
                () => FrameScopeHintValidator.Validate(duplicate),
                Throws.TypeOf<FrameScopeConfigurationException>()
                    .With.Message.Contains("Duplicate"));
        });
    }

    [Test]
    public void ProviderRequiresAnExplicitApprovedScope()
    {
        var catalog = Catalog(
            new FrameScopeHint
            {
                ScopeId = "policy",
                PageIndex = 0,
                FramePath = ["shell-frame", "policy-editor"]
            });
        catalog.Checksum =
            FrameScopeHintValidator.ComputeChecksum(catalog);
        var provider = new FrameScopeHintProvider(catalog);

        Assert.Multiple(() =>
        {
            Assert.That(
                provider.Require("policy").FramePath,
                Is.EqualTo(new[] { "shell-frame", "policy-editor" }));
            Assert.That(
                () => provider.Require("missing"),
                Throws.TypeOf<FrameScopeConfigurationException>()
                    .With.Message.Contains("not approved"));
        });
    }

    [Test]
    public void NestedFramePathMatchesExactlyWithoutTopDocumentFallback()
    {
        var hints = new[]
        {
            new FrameScopeHint
            {
                ScopeId = "policy",
                PageIndex = 0,
                FramePath = ["shell-frame", "policy-editor"]
            }
        };

        Assert.Multiple(() =>
        {
            Assert.That(
                FrameScopeHintMatcher.Match(
                    hints,
                    0,
                    ["shell-frame", "policy-editor"]),
                Is.EqualTo("policy"));
            Assert.That(
                FrameScopeHintMatcher.Match(
                    hints,
                    0,
                    ["policy-editor"]),
                Is.Null);
            Assert.That(
                FrameScopeHintMatcher.Match(
                    hints,
                    1,
                    ["shell-frame", "policy-editor"]),
                Is.Null);
        });
    }

    private static FrameScopeHintCatalog Catalog(
        params FrameScopeHint[] hints) =>
        new()
        {
            SchemaVersion = 1,
            CatalogVersion = "1.0.0",
            SourcePath = "source/frame-hints.json",
            SourceSha256 = new string('A', 64),
            Hints = hints.ToList()
        };

    private static FrameScopeHintCatalog ReadRepositoryCatalog()
    {
        var path = Path.Combine(
            FindRepositoryRoot(),
            "Resources",
            "FrameHints",
            "cldc-bap-frame-hints.json");
        return System.Text.Json.JsonSerializer.Deserialize<
            FrameScopeHintCatalog>(
            File.ReadAllText(path),
            new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
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
