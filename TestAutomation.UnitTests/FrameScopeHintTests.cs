using System.Diagnostics;
using System.Text.Json;
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

    [TestCase(false)]
    [TestCase(true)]
    public void CatalogFilesInsideApplicationDirectoryLoad(bool absolute)
    {
        using var files = new CatalogFiles();
        var path = absolute ? files.CatalogPath : files.RelativePath;
        var provider = new FrameScopeHintProvider(new FrameScopeHintOptions { CatalogPath = path });

        Assert.That(provider.Require("policy").FramePath, Is.EqualTo(new[] { "policy-frame" }));
    }

    [Test]
    public void CanonicalInBoundaryPathsAndAdditionalCatalogsLoad()
    {
        using var files = new CatalogFiles();
        var additional = Path.Combine(files.InsideRoot, "account.json");
        CatalogFiles.WriteCatalog(additional, "account");
        var provider = new FrameScopeHintProvider(new FrameScopeHintOptions
        {
            CatalogPath = Path.Combine(files.RelativeRoot, "nested", "..", "nested", "policy.json"),
            AdditionalCatalogPaths = [additional]
        });

        Assert.Multiple(() =>
        {
            Assert.That(provider.Hints, Has.Count.EqualTo(2));
            Assert.That(provider.Require("policy").FramePath, Is.EqualTo(new[] { "policy-frame" }));
            Assert.That(provider.Require("account").FramePath, Is.EqualTo(new[] { "account-frame" }));
        });
    }

    [Test]
    public void CatalogContentsCannotRedirectSelectedPathsOrMutateOptions()
    {
        using var files = new CatalogFiles();
        var additional = Path.Combine(files.InsideRoot, "account.json");
        CatalogFiles.WriteCatalog(additional, "account");
        var outside = Path.Combine(files.OutsideRoot, "not-selected.json");
        var catalog = JsonSerializer.Deserialize<FrameScopeHintCatalog>(File.ReadAllText(files.CatalogPath))!;
        catalog.SourcePath = outside;
        catalog.Checksum = FrameScopeHintValidator.ComputeChecksum(catalog);
        var contents = JsonSerializer.SerializeToNode(catalog)!.AsObject();
        contents["CatalogPath"] = outside;
        contents["AdditionalCatalogPaths"] = JsonSerializer.SerializeToNode(new[] { outside });
        File.WriteAllText(files.CatalogPath, contents.ToJsonString());

        var additionalPaths = new List<string> { additional };
        var options = new FrameScopeHintOptions
        {
            CatalogPath = files.RelativePath,
            AdditionalCatalogPaths = additionalPaths
        };
        var selectedPaths = options.GetCatalogPaths().ToArray();
        Assert.That(File.Exists(outside), Is.False);

        var provider = new FrameScopeHintProvider(options);

        Assert.Multiple(() =>
        {
            Assert.That(provider.Hints.Select(hint => hint.ScopeId), Is.EqualTo(new[] { "policy", "account" }));
            Assert.That(provider.Require("account").FramePath, Is.EqualTo(new[] { "account-frame" }));
            Assert.That(options.CatalogPath, Is.EqualTo(files.RelativePath));
            Assert.That(options.AdditionalCatalogPaths, Is.SameAs(additionalPaths));
            Assert.That(additionalPaths, Is.EqualTo(new[] { additional }));
            Assert.That(options.GetCatalogPaths(), Is.EqualTo(selectedPaths));
        });
    }

    [TestCase(false, false)]
    [TestCase(false, true)]
    [TestCase(true, false)]
    [TestCase(true, true)]
    public void OutsideCatalogsIncludingSiblingPrefixesAreRejected(bool absolute, bool additional)
    {
        using var files = new CatalogFiles();
        var path = absolute
            ? files.OutsideCatalogPath
            : Path.GetRelativePath(AppContext.BaseDirectory, files.OutsideCatalogPath);
        var options = new FrameScopeHintOptions
        {
            CatalogPath = additional ? files.RelativePath : path,
            AdditionalCatalogPaths = additional ? [path] : []
        };

        Assert.That(() => new FrameScopeHintProvider(options),
            Throws.TypeOf<FrameScopeConfigurationException>().With.Message.Contains("application directory"));
    }

    [TestCase(@"\\untrusted.invalid\catalogs\policy.json")]
    [TestCase("//untrusted.invalid/catalogs/policy.json")]
    [TestCase(@"\\?\C:\outside.json")]
    [TestCase(@"\\.\C:\outside.json")]
    public void NetworkAndDeviceCatalogPathsAreRejected(string path)
    {
        Assert.That(() => new FrameScopeHintProvider(new FrameScopeHintOptions { CatalogPath = path }),
            Throws.TypeOf<FrameScopeConfigurationException>().With.Message.Contains("local paths"));
    }

    [TestCase(@"C:policy.json")]
    [TestCase(@"\policy.json")]
    [Platform("Win")]
    public void AmbiguousRootedCatalogPathsAreRejected(string path)
    {
        Assert.That(() => new FrameScopeHintProvider(new FrameScopeHintOptions { CatalogPath = path }),
            Throws.TypeOf<FrameScopeConfigurationException>().With.Message.Contains("fully qualified"));
    }

    [Test]
    public void CatalogRootComparisonUsesPlatformCaseSemantics()
    {
        using var files = new CatalogFiles();
        var root = AppContext.BaseDirectory;
        var differentCase = root == root.ToUpperInvariant() ? root.ToLowerInvariant() : root.ToUpperInvariant();
        var options = new FrameScopeHintOptions { CatalogPath = Path.Combine(differentCase, files.RelativePath) };

        if (OperatingSystem.IsWindows())
            Assert.That(new FrameScopeHintProvider(options).Require("policy").ScopeId, Is.EqualTo("policy"));
        else
            Assert.That(() => new FrameScopeHintProvider(options),
                Throws.TypeOf<FrameScopeConfigurationException>().With.Message.Contains("application directory"));
    }

    [TestCase(false, false)]
    [TestCase(true, false)]
    [TestCase(false, true)]
    [TestCase(true, true)]
    public void LinkedCatalogDirectoriesCannotEscapeApplicationDirectory(bool additional, bool dangling)
    {
        using var files = new CatalogFiles();
        var link = Path.Combine(files.InsideRoot, "linked");
        var target = dangling ? Path.Combine(files.OutsideRoot, "missing") : files.OutsideRoot;
        if (OperatingSystem.IsWindows())
        {
            using var process = Process.Start(new ProcessStartInfo
            {
                FileName = Environment.GetEnvironmentVariable("ComSpec") ?? "cmd.exe",
                Arguments = $"/c mklink /J \"{link}\" \"{target}\"",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            })!;
            Assert.That(process.WaitForExit(10000), Is.True, "The test junction command must finish.");
            Assert.That(process.ExitCode, Is.Zero, "The test junction must be created.");
        }
        else
        {
            Directory.CreateSymbolicLink(link, target);
        }
        try
        {
            var path = Path.Combine(link, "outside.json");
            var options = new FrameScopeHintOptions
            {
                CatalogPath = additional ? files.RelativePath : path,
                AdditionalCatalogPaths = additional ? [path] : []
            };
            Assert.That(() => new FrameScopeHintProvider(options),
                Throws.TypeOf<FrameScopeConfigurationException>().With.Message.Contains("reparse points"));
        }
        finally
        {
            Directory.Delete(link);
        }
    }

    [TestCase(false)]
    [TestCase(true)]
    public void LinkedCatalogFilesAreRejectedEvenWhenDangling(bool dangling)
    {
        const int errorPrivilegeNotHeld = 1314;
        using var files = new CatalogFiles();
        var link = Path.Combine(files.InsideRoot, "linked.json");
        var target = dangling ? Path.Combine(files.OutsideRoot, "missing.json") : files.OutsideCatalogPath;
        try
        {
            File.CreateSymbolicLink(link, target);
        }
        catch (IOException exception) when (
            OperatingSystem.IsWindows() && (exception.HResult & 0xffff) == errorPrivilegeNotHeld)
        {
            Assert.Ignore("File symbolic links require Windows Developer Mode or the symbolic-link privilege.");
        }
        try
        {
            Assert.That(() => new FrameScopeHintProvider(new FrameScopeHintOptions { CatalogPath = link }),
                Throws.TypeOf<FrameScopeConfigurationException>().With.Message.Contains("reparse points"));
        }
        finally
        {
            File.Delete(link);
        }
    }

    [TestCase("missing", "missing or malformed")]
    [TestCase("malformed", "missing or malformed")]
    [TestCase("null", "missing or malformed")]
    [TestCase("checksum", "checksum")]
    [TestCase("schema", "schema")]
    public void FileCatalogsStillFailForMissingOrInvalidContent(string defect, string message)
    {
        using var files = new CatalogFiles();
        switch (defect)
        {
            case "missing":
                File.Delete(files.CatalogPath);
                break;
            case "malformed":
                File.WriteAllText(files.CatalogPath, "{");
                break;
            case "null":
                File.WriteAllText(files.CatalogPath, "null");
                break;
            default:
                var catalog = JsonSerializer.Deserialize<FrameScopeHintCatalog>(File.ReadAllText(files.CatalogPath))!;
                if (defect == "checksum")
                    catalog.Checksum = "";
                else
                    catalog.SchemaVersion = 0;
                File.WriteAllText(files.CatalogPath, JsonSerializer.Serialize(catalog));
                break;
        }

        Assert.That(() => new FrameScopeHintProvider(new FrameScopeHintOptions { CatalogPath = files.RelativePath }),
            Throws.TypeOf<FrameScopeConfigurationException>().With.Message.Contains(message));
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

    private sealed class CatalogFiles : IDisposable
    {
        internal string RelativeRoot { get; } = "frame-hint-tests-" + Guid.NewGuid().ToString("N");
        internal string InsideRoot => Path.Combine(AppContext.BaseDirectory, RelativeRoot);
        internal string RelativePath => Path.Combine(RelativeRoot, "nested", "policy.json");
        internal string CatalogPath => Path.Combine(AppContext.BaseDirectory, RelativePath);
        internal string OutsideRoot { get; } =
            Path.TrimEndingDirectorySeparator(AppContext.BaseDirectory) + "-frame-hint-tests-" + Guid.NewGuid().ToString("N");
        internal string OutsideCatalogPath => Path.Combine(OutsideRoot, "outside.json");

        internal CatalogFiles()
        {
            WriteCatalog(CatalogPath, "policy");
            WriteCatalog(OutsideCatalogPath, "outside");
        }

        internal static void WriteCatalog(string path, string scope)
        {
            var catalog = Catalog(new FrameScopeHint { ScopeId = scope, FramePath = [scope + "-frame"] });
            catalog.Checksum = FrameScopeHintValidator.ComputeChecksum(catalog);
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            File.WriteAllText(path, JsonSerializer.Serialize(catalog));
        }

        public void Dispose()
        {
            Directory.Delete(InsideRoot, recursive: true);
            Directory.Delete(OutsideRoot, recursive: true);
        }
    }
}
