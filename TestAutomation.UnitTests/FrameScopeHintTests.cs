using System.Diagnostics;
using System.Text.Json;
using NUnit.Framework;
using PnCTestAutomation.Controls;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
[NonParallelizable]
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
    public void CatalogFilenamesInsideDedicatedDirectoryLoad(
        [Values("policy.json", "Policy.v1-2_AL.JSON")] string filename,
        [Values(false, true)] bool additionalOnly)
    {
        using var files = new CatalogFiles(filename);
        var provider = new FrameScopeHintProvider(new FrameScopeHintOptions
        {
            CatalogPath = additionalOnly ? null : files.CatalogName,
            AdditionalCatalogPaths = additionalOnly ? [files.CatalogName] : []
        });

        Assert.That(provider.Require("policy").FramePath, Is.EqualTo(new[] { "policy-frame" }));
    }

    [Test]
    public void ExplicitPrimaryAndAdditionalCatalogFilenamesLoad()
    {
        using var files = new CatalogFiles();
        CatalogFiles.WriteCatalog(files.AdditionalCatalogPath, "account");
        var provider = new FrameScopeHintProvider(new FrameScopeHintOptions
        {
            CatalogPath = files.CatalogName,
            AdditionalCatalogPaths = [files.AdditionalCatalogName]
        });

        Assert.Multiple(() =>
        {
            Assert.That(provider.Hints, Has.Count.EqualTo(2));
            Assert.That(provider.Require("policy").FramePath, Is.EqualTo(new[] { "policy-frame" }));
            Assert.That(provider.Require("account").FramePath, Is.EqualTo(new[] { "account-frame" }));
        });
    }

    [Test]
    public void FileCatalogsStillRejectCrossCatalogScopeCollisions()
    {
        using var files = new CatalogFiles();
        CatalogFiles.WriteCatalog(files.AdditionalCatalogPath, "policy");
        Assert.That(() => new FrameScopeHintProvider(new FrameScopeHintOptions
        {
            CatalogPath = files.CatalogName,
            AdditionalCatalogPaths = [files.AdditionalCatalogName]
        }), Throws.TypeOf<FrameScopeConfigurationException>().With.Message.Contains("ambiguous across catalogs"));
    }

    [Test]
    public void CatalogContentsCannotRedirectSelectedPathsOrMutateOptions()
    {
        using var files = new CatalogFiles();
        CatalogFiles.WriteCatalog(files.AdditionalCatalogPath, "account");
        var outside = Path.Combine(files.OutsideRoot, "not-selected.json");
        var catalog = JsonSerializer.Deserialize<FrameScopeHintCatalog>(File.ReadAllText(files.CatalogPath))!;
        catalog.SourcePath = outside;
        catalog.Checksum = FrameScopeHintValidator.ComputeChecksum(catalog);
        var contents = JsonSerializer.SerializeToNode(catalog)!.AsObject();
        contents["CatalogPath"] = outside;
        contents["AdditionalCatalogPaths"] = JsonSerializer.SerializeToNode(new[] { outside });
        File.WriteAllText(files.CatalogPath, contents.ToJsonString());

        var additionalPaths = new List<string> { files.AdditionalCatalogName };
        var options = new FrameScopeHintOptions
        {
            CatalogPath = files.CatalogName,
            AdditionalCatalogPaths = additionalPaths
        };
        var selectedPaths = options.GetCatalogPaths().ToArray();
        Assert.That(File.Exists(outside), Is.False);

        var provider = new FrameScopeHintProvider(options);

        Assert.Multiple(() =>
        {
            Assert.That(provider.Hints.Select(hint => hint.ScopeId), Is.EqualTo(new[] { "policy", "account" }));
            Assert.That(provider.Require("account").FramePath, Is.EqualTo(new[] { "account-frame" }));
            Assert.That(options.CatalogPath, Is.EqualTo(files.CatalogName));
            Assert.That(options.AdditionalCatalogPaths, Is.SameAs(additionalPaths));
            Assert.That(additionalPaths, Is.EqualTo(new[] { files.AdditionalCatalogName }));
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
            : Path.GetRelativePath(CatalogFiles.CatalogRoot, files.OutsideCatalogPath);
        var options = new FrameScopeHintOptions
        {
            CatalogPath = additional ? files.CatalogName : path,
            AdditionalCatalogPaths = additional ? [path] : []
        };

        Assert.That(() => new FrameScopeHintProvider(options),
            Throws.TypeOf<FrameScopeConfigurationException>().With.Message.Contains("filename"));
    }

    [Test]
    public void FormerInBoundaryPathsAreRejectedEvenWhenTheBasenameExists(
        [Values("absolute", "relative", "nested", "normalized")] string kind,
        [Values(false, true)] bool additional)
    {
        using var files = new CatalogFiles();
        CatalogFiles.WriteCatalog(Path.Combine(files.NestedRoot, files.CatalogName), "nested");
        var path = kind switch
        {
            "absolute" => files.CatalogPath,
            "relative" => Path.GetRelativePath(AppContext.BaseDirectory, files.CatalogPath),
            "nested" => Path.Combine(Path.GetFileName(files.NestedRoot), files.CatalogName),
            "normalized" => Path.Combine(Path.GetFileName(files.NestedRoot), "..", files.CatalogName),
            _ => throw new ArgumentException("Unknown path case.")
        };
        Assert.That(File.Exists(files.CatalogPath), Is.True);
        Assert.That(() => new FrameScopeHintProvider(new FrameScopeHintOptions
        {
            CatalogPath = additional ? files.CatalogName : path,
            AdditionalCatalogPaths = additional ? [path] : []
        }), Throws.TypeOf<FrameScopeConfigurationException>().With.Message.Contains("filename"));
    }

    [TestCaseSource(nameof(InvalidCatalogSelections))]
    public void InvalidCatalogNamesAreRejectedPortablyInBothOptions(string name, bool additional)
    {
        var options = new FrameScopeHintOptions
        {
            CatalogPath = additional ? "policy.json" : name,
            AdditionalCatalogPaths = additional ? [name] : []
        };
        Assert.Multiple(() =>
        {
            Assert.That(options.Validate,
                Throws.TypeOf<FrameScopeConfigurationException>().With.Message.Contains("filename"));
            Assert.That(() => new FrameScopeHintProvider(options),
                Throws.TypeOf<FrameScopeConfigurationException>().With.Message.Contains("filename"));
        });
    }

    private static IEnumerable<TestCaseData> InvalidCatalogSelections()
    {
        var names = new[]
        {
            "", " ", ".", "..", ".json", ".policy.json", "policy..json",
            "policy.txt", "policy", "policy.json.", "policy.json ", " policy.json", "policy .json",
            "policy.json\n", "policy\0.json", "policy?.json", "policy*.json", "policy%2ejson",
            @"nested\policy.json", "nested/policy.json", @"..\policy.json", "../policy.json",
            @"nested\..\policy.json", "nested/../policy.json", @"C:policy.json", @"C:\policy.json",
            @"\policy.json", "/policy.json", @"\\untrusted.invalid\catalogs\policy.json",
            "//untrusted.invalid/catalogs/policy.json", @"\\?\C:\policy.json", @"\\.\C:\policy.json",
            "policy.json:stream.json", "policy:stream.json", "CON.json", "con.v1.json", "PRN.json",
            "AUX.json", "NUL.json", "COM1.json", "com9.v1.json", "LPT1.json", "lpt9.json",
            "COM\u00b9.json", "LPT\u00b2.json", "\u00e9.json"
        };
        foreach (var name in names)
        foreach (var additional in new[] { false, true })
            yield return new TestCaseData(name, additional);
    }

    [Test]
    public void NullAdditionalCatalogSelectionsFailExplicitly()
    {
        Assert.Multiple(() =>
        {
            Assert.That(new FrameScopeHintOptions { AdditionalCatalogPaths = null! }.Validate,
                Throws.TypeOf<FrameScopeConfigurationException>().With.Message.Contains("cannot be null"));
            Assert.That(new FrameScopeHintOptions { AdditionalCatalogPaths = [null!] }.Validate,
                Throws.TypeOf<FrameScopeConfigurationException>().With.Message.Contains("filename"));
            Assert.That(new FrameScopeHintOptions { AdditionalCatalogPaths = ["policy.json", "POLICY.JSON"] }.Validate,
                Throws.TypeOf<FrameScopeConfigurationException>().With.Message.Contains("Duplicate"));
        });
    }

    [Test]
    [Platform("Win")]
    public void CatalogFilenameCaseRemainsCompatibleOnWindows()
    {
        using var files = new CatalogFiles();
        var options = new FrameScopeHintOptions { CatalogPath = files.CatalogName.ToUpperInvariant() };
        Assert.That(new FrameScopeHintProvider(options).Require("policy").ScopeId, Is.EqualTo("policy"));
    }

    [Test]
    public void ApplicationDirectoryIsNotACatalogFallback()
    {
        using var files = new CatalogFiles();
        var applicationPath = Path.Combine(AppContext.BaseDirectory, files.CatalogName);
        CatalogFiles.WriteCatalog(applicationPath, "application");
        try
        {
            File.Delete(files.CatalogPath);
            Assert.That(() => new FrameScopeHintProvider(new FrameScopeHintOptions { CatalogPath = files.CatalogName }),
                Throws.TypeOf<FrameScopeConfigurationException>().With.Message.Contains("missing or malformed"));
        }
        finally
        {
            File.Delete(applicationPath);
        }
    }

    [Test]
    public void LinkedCatalogRootCannotEscapeDedicatedDirectory(
        [Values(false, true)] bool additionalOnly,
        [Values(false, true)] bool dangling)
    {
        using var files = new CatalogFiles();
        var root = CatalogFiles.CatalogRoot;
        var backup = Path.Combine(files.OutsideRoot, "original-root");
        var target = dangling ? Path.Combine(files.OutsideRoot, "missing") : files.OutsideRoot;
        Directory.Move(root, backup);
        try
        {
            CreateDirectoryLink(root, target);
            try
            {
                Assert.That(() => new FrameScopeHintProvider(new FrameScopeHintOptions
                {
                    CatalogPath = additionalOnly ? null : files.CatalogName,
                    AdditionalCatalogPaths = additionalOnly ? [files.CatalogName] : []
                }), Throws.TypeOf<FrameScopeConfigurationException>().With.Message.Contains("reparse points"));
            }
            finally
            {
                Directory.Delete(root);
            }
        }
        finally
        {
            Directory.Move(backup, root);
        }
    }

    [Test]
    public void DirectoryJunctionsWithCatalogFilenamesAreRejected(
        [Values(false, true)] bool additionalOnly,
        [Values(false, true)] bool dangling)
    {
        using var files = new CatalogFiles();
        var link = files.AdditionalCatalogPath;
        var target = dangling ? Path.Combine(files.OutsideRoot, "missing") : files.OutsideRoot;
        CreateDirectoryLink(link, target);
        try
        {
            Assert.That(() => new FrameScopeHintProvider(new FrameScopeHintOptions
            {
                CatalogPath = additionalOnly ? files.CatalogName : files.AdditionalCatalogName,
                AdditionalCatalogPaths = additionalOnly ? [files.AdditionalCatalogName] : []
            }), Throws.TypeOf<FrameScopeConfigurationException>().With.Message.Contains("reparse points"));
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
        var link = files.AdditionalCatalogPath;
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
            Assert.That(() => new FrameScopeHintProvider(new FrameScopeHintOptions { CatalogPath = files.AdditionalCatalogName }),
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

        Assert.That(() => new FrameScopeHintProvider(new FrameScopeHintOptions { CatalogPath = files.CatalogName }),
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

    private static void CreateDirectoryLink(string link, string target)
    {
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
    }

    private sealed class CatalogFiles : IDisposable
    {
        private readonly bool _createdCatalogRoot = !Directory.Exists(CatalogRoot);
        internal static string CatalogRoot => Path.Combine(AppContext.BaseDirectory, "Resources", "FrameScopeHints");
        internal string CatalogName { get; }
        internal string CatalogPath => Path.Combine(CatalogRoot, CatalogName);
        internal string AdditionalCatalogName { get; } = "account-" + Guid.NewGuid().ToString("N") + ".json";
        internal string AdditionalCatalogPath => Path.Combine(CatalogRoot, AdditionalCatalogName);
        internal string NestedRoot { get; } = Path.Combine(CatalogRoot, "nested-" + Guid.NewGuid().ToString("N"));
        internal string OutsideRoot { get; } =
            CatalogRoot + "-frame-hint-tests-" + Guid.NewGuid().ToString("N");
        internal string OutsideCatalogPath => Path.Combine(OutsideRoot, CatalogName);

        internal CatalogFiles(string filename = "policy.json")
        {
            CatalogName = Guid.NewGuid().ToString("N") + "-" + filename;
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
            File.Delete(CatalogPath);
            File.Delete(AdditionalCatalogPath);
            if (Directory.Exists(NestedRoot))
                Directory.Delete(NestedRoot, recursive: true);
            Directory.Delete(OutsideRoot, recursive: true);
            if (_createdCatalogRoot && !Directory.EnumerateFileSystemEntries(CatalogRoot).Any())
                Directory.Delete(CatalogRoot);
        }
    }
}
