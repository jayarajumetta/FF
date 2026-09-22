using NUnit.Framework;
using PnCTestAutomation.Controls;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class FrameScopeHintTests
{
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

    [Test]
    public void MultipleCatalogsRemainIndependentAndRejectScopeCollisions()
    {
        var policy = Catalog(
            new FrameScopeHint
            {
                ScopeId = "policy",
                PageIndex = 0,
                FramePath = ["policy-frame"]
            });
        policy.Checksum = FrameScopeHintValidator.ComputeChecksum(policy);
        var account = Catalog(
            new FrameScopeHint
            {
                ScopeId = "account",
                PageIndex = 0,
                FramePath = ["shell-frame", "account-frame"]
            });
        account.CatalogVersion = "2.0.0";
        account.Checksum = FrameScopeHintValidator.ComputeChecksum(account);

        var provider = new FrameScopeHintProvider([policy, account]);

        Assert.Multiple(() =>
        {
            Assert.That(provider.Hints, Has.Count.EqualTo(2));
            Assert.That(
                provider.Require("account").FramePath,
                Is.EqualTo(new[] { "shell-frame", "account-frame" }));
            Assert.That(
                () => new FrameScopeHintProvider([policy, policy]),
                Throws.TypeOf<FrameScopeConfigurationException>()
                    .With.Message.Contains("ambiguous across catalogs"));
        });
    }

    [Test]
    public void CatalogOptionsRejectDuplicatePaths()
    {
        var options = new FrameScopeHintOptions
        {
            CatalogPath = "first.json",
            AdditionalCatalogPaths = ["FIRST.JSON"]
        };

        Assert.That(
            options.Validate,
            Throws.TypeOf<FrameScopeConfigurationException>()
                .With.Message.Contains("Duplicate"));
    }

    [Test]
    public void NoDeletedPilotCatalogIsImplicitlyLoaded()
    {
        var options = new FrameScopeHintOptions();
        Assert.That(options.GetCatalogPaths(), Is.Empty);
        Assert.That(
            () => new FrameScopeHintProvider(options),
            Throws.TypeOf<FrameScopeConfigurationException>().With.Message.Contains("explicit approved"));
    }

    [Test]
    public void MainFrameScopeIsExplicitAndMatchesOnlyItsDeclaredPage()
    {
        var hint = new FrameScopeHint { ScopeId = "cleq-main", PageIndex = 0, IsMainFrame = true };
        var catalog = Catalog(hint);
        catalog.SchemaVersion = 2;
        catalog.Checksum = FrameScopeHintValidator.ComputeChecksum(catalog);
        var provider = new FrameScopeHintProvider(catalog);

        Assert.Multiple(() =>
        {
            Assert.That(FrameScopeHintMatcher.Match(provider.Hints, 0, []), Is.EqualTo("cleq-main"));
            Assert.That(FrameScopeHintMatcher.Match(provider.Hints, 1, []), Is.Null);
            Assert.That(FrameScopeHintMatcher.Match(provider.Hints, 0, ["child"]), Is.Null);
            Assert.That(
                FrameScopeHintMatcher.Match([new FrameScopeHint { ScopeId = "implicit" }], 0, []),
                Is.Null);
        });
    }

    [TestCase(1, true)]
    [TestCase(2, false)]
    public void EmptyFramePathsCannotBeImplicitMainFrameFallbacks(int schema, bool main)
    {
        var catalog = Catalog(new FrameScopeHint { ScopeId = "policy", IsMainFrame = main });
        catalog.SchemaVersion = schema;
        catalog.Checksum = FrameScopeHintValidator.ComputeChecksum(catalog);
        Assert.That(() => FrameScopeHintValidator.Validate(catalog),
            Throws.TypeOf<FrameScopeConfigurationException>().With.Message.Contains("invalid page/path"));
    }

    [Test]
    public void MainFrameAndNamedFramePathsCannotBeCombined()
    {
        var catalog = Catalog(new FrameScopeHint
        {
            ScopeId = "policy", IsMainFrame = true, FramePath = ["policy-frame"]
        });
        catalog.SchemaVersion = 2;
        catalog.Checksum = FrameScopeHintValidator.ComputeChecksum(catalog);
        Assert.That(() => FrameScopeHintValidator.Validate(catalog),
            Throws.TypeOf<FrameScopeConfigurationException>());
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

}
