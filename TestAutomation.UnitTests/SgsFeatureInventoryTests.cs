using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Products;
using NUnit.Framework;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class SgsFeatureInventoryTests
{
    private static readonly Regex NonInputPrefix = new(
        "^(wait|expected|verify|assert|actual|display)",
        RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

    [Test]
    public void AllSourceFeaturesAreRetainedWithVerifiablePayloads()
    {
        var root = FindRepositoryRoot();
        var manifestPath = Path.Combine(
            root,
            "Resources",
            "Contracts",
            "sgs-feature-inventory.json");
        using var document = JsonDocument.Parse(File.ReadAllText(manifestPath));
        var manifest = document.RootElement;
        var features = manifest.GetProperty("features")
            .EnumerateArray()
            .ToArray();

        Assert.Multiple(() =>
        {
            Assert.That(manifest.GetProperty("featureCount").GetInt32(), Is.EqualTo(32));
            Assert.That(
                manifest.GetProperty("generatedCaseCount").GetInt32(),
                Is.EqualTo(1115));
            Assert.That(features, Has.Length.EqualTo(32));
            Assert.That(
                features.Select(feature =>
                    feature.GetProperty("destinationPath").GetString()),
                Is.Unique);
            Assert.That(
                features.Select(feature =>
                    feature.GetProperty("sourceRelativePath").GetString()),
                Is.Unique);
            Assert.That(
                features.Select(feature =>
                    feature.GetProperty("sourceProject").GetString()).Distinct(),
                Is.EquivalentTo(new[]
                {
                    "CommercialLines.DuckCreek.Tests",
                    "CommercialLines.ExpertQuote.Tests",
                    "PersonalLines.DuckCreek.Tests"
                }));
        });

        var header = Encoding.UTF8.GetBytes(
            "@SgsImported @NonRunnable @NoRetry\r\n");
        var catalog = SgsExecutionCatalog.Load(Path.Combine(root, "Resources"));
        foreach (var feature in features)
        {
            var relativePath = feature.GetProperty("destinationPath")
                .GetString()!
                .Replace('/', Path.DirectorySeparatorChar);
            var path = Path.Combine(root, relativePath);
            var bytes = File.ReadAllBytes(path);
            var workflow = catalog.Ledger.Workflows.Single(item =>
                item.DestinationPath == feature.GetProperty("destinationPath").GetString());
            var adaptedHeaderLength = Array.IndexOf(bytes, (byte)'\n') + 1;
            Assert.That(adaptedHeaderLength, Is.GreaterThan(0), relativePath);
            var adaptedHeader = Encoding.UTF8.GetString(bytes, 0, adaptedHeaderLength);
            var sourcePayload = bytes.AsSpan(adaptedHeaderLength).ToArray();

            Assert.Multiple(() =>
            {
                Assert.That(adaptedHeader, Does.Contain("@SgsImported"), relativePath);
                Assert.That(adaptedHeader, Does.Contain("@NoRetry"), relativePath);
                Assert.That(adaptedHeader, Does.Contain("@AutomationId-" + workflow.AutomationFamily), relativePath);
                Assert.That(
                    Convert.ToHexString(SHA256.HashData(bytes)),
                    Is.EqualTo(workflow.AdaptedSha256),
                    relativePath);
                Assert.That(
                    Convert.ToHexString(SHA256.HashData(header.Concat(sourcePayload).ToArray())),
                    Is.EqualTo(feature.GetProperty("importedSha256").GetString()),
                    relativePath);
                Assert.That(
                    Convert.ToHexString(SHA256.HashData(sourcePayload)),
                    Is.EqualTo(feature.GetProperty("sourceSha256").GetString()),
                    relativePath);
                Assert.That(workflow.SourceSha256, Is.EqualTo(feature.GetProperty("sourceSha256").GetString()));
                Assert.That(workflow.ImportedSha256, Is.EqualTo(feature.GetProperty("importedSha256").GetString()));
                Assert.That(
                    feature.GetProperty("executionStatus").GetString(),
                    Is.EqualTo("NonRunnable"),
                    relativePath);
            });
        }
    }

    [Test]
    public void ImportedScenarioDataUsesRuntimeIdentityTokensAndVerifiablePayloads()
    {
        var root = FindRepositoryRoot();
        var manifestPath = Path.Combine(
            root,
            "Resources",
            "Contracts",
            "sgs-data-inventory.json");
        using var manifestDocument = JsonDocument.Parse(
            File.ReadAllText(manifestPath));
        var manifest = manifestDocument.RootElement;
        var files = manifest.GetProperty("files").EnumerateArray().ToArray();
        var scenarioData = files
            .Where(file =>
                file.GetProperty("kind").GetString() == "scenario-data")
            .ToArray();

        Assert.Multiple(() =>
        {
            Assert.That(
                manifest.GetProperty("referencedScenarioDataCount").GetInt32(),
                Is.EqualTo(1152));
            Assert.That(
                manifest.GetProperty("frameCatalogCount").GetInt32(),
                Is.EqualTo(1));
            Assert.That(files, Has.Length.EqualTo(1153));
            Assert.That(scenarioData, Has.Length.EqualTo(1152));
            Assert.That(
                files.Select(file =>
                    file.GetProperty("destinationPath").GetString()),
                Is.Unique);
            Assert.That(
                manifest.GetProperty("identityDataPolicy")
                    .GetProperty("mode")
                    .GetString(),
                Is.EqualTo("runtime-generated"));
        });

        foreach (var file in files)
        {
            var relativePath = file.GetProperty("destinationPath")
                .GetString()!
                .Replace('/', Path.DirectorySeparatorChar);
            var path = Path.Combine(root, relativePath);
            var bytes = File.ReadAllBytes(path);

            Assert.That(
                Convert.ToHexString(SHA256.HashData(bytes)),
                Is.EqualTo(file.GetProperty("importedSha256").GetString()),
                relativePath);

            using var dataDocument = JsonDocument.Parse(bytes);
            if (file.GetProperty("kind").GetString() != "scenario-data")
                continue;

            var values = dataDocument.RootElement.GetProperty("values");
            foreach (var property in values.EnumerateObject())
            {
                if (property.Value.ValueKind != JsonValueKind.String)
                    continue;

                var expectedToken = GetIdentityToken(property.Name);
                if (expectedToken != null)
                {
                    Assert.That(
                        property.Value.GetString(),
                        Is.EqualTo(expectedToken),
                        $"{relativePath}: {property.Name}");
                }
            }

            ValidateCredentialPlaceholders(dataDocument.RootElement, relativePath);
        }
    }

    [Test]
    public void RuntimeIdentityTokensResolveOncePerScenario()
    {
        var context = new ScenarioContextData();
        var resolved = RandomGenerators.ResolveRuntimeTokens(
            "{{firstName}} {{middleInitial}} {{lastName}} | " +
            "{{randomDOB}} | {{randomPhone}} | {{randomEmail}} | {{randomSSN}}",
            context);
        var resolvedAgain = RandomGenerators.ResolveRuntimeTokens(
            "{{firstName}} {{lastName}} | {{randomEmail}} | {{randomSSN}}",
            context);

        Assert.Multiple(() =>
        {
            Assert.That(resolved, Does.Not.Contain("{{"));
            Assert.That(resolvedAgain, Does.Not.Contain("{{"));
            Assert.That(
                resolvedAgain,
                Does.Contain($"{context.ClientFirstName} {context.ClientLastName}"));
            Assert.That(resolvedAgain, Does.Contain(context.ClientEmail));
            Assert.That(resolvedAgain, Does.Contain(context.SSN));
        });
    }

    private static string? GetIdentityToken(string propertyName)
    {
        var normalized = Regex.Replace(propertyName, "[^a-zA-Z0-9]", "")
            .ToLowerInvariant();
        if (NonInputPrefix.IsMatch(normalized))
            return null;
        if (normalized.Contains("firstname"))
            return "{{firstName}}";
        if (normalized.Contains("lastname"))
            return "{{lastName}}";
        if (normalized.Contains("middlename"))
            return "{{middleInitial}}";
        if (Regex.IsMatch(normalized, "nameof.*contact|contactname"))
            return "{{firstName}} {{lastName}}";
        if (normalized.Contains("dateofbirth") ||
            Regex.IsMatch(
                propertyName,
                @"(^|[_.\s-])dob($|[_.\s\d-])",
                RegexOptions.IgnoreCase))
        {
            return "{{randomDOB}}";
        }
        if ((normalized.Contains("phone") ||
             normalized.Contains("telephone")) &&
            !Regex.IsMatch(normalized, "(type|extension|ext)$"))
        {
            return "{{randomPhone}}";
        }
        if ((normalized.Contains("email") ||
             Regex.IsMatch(
                 propertyName,
                 @"e[_\s.-]*mail",
                 RegexOptions.IgnoreCase)) &&
            !normalized.Contains("type"))
        {
            return "{{randomEmail}}";
        }
        if (Regex.IsMatch(
                propertyName,
                @"social[_\s.-]*security|(^|[_.\s-])ssn($|[_.\s\d-])",
                RegexOptions.IgnoreCase) ||
            normalized.Contains("insuredssn"))
        {
            return "{{randomSSN}}";
        }

        return null;
    }

    private static void ValidateCredentialPlaceholders(
        JsonElement element,
        string relativePath)
    {
        if (element.ValueKind == JsonValueKind.Object)
        {
            foreach (var property in element.EnumerateObject())
            {
                if (property.Value.ValueKind == JsonValueKind.String &&
                    (property.Name.Equals(
                         "username",
                         StringComparison.OrdinalIgnoreCase) ||
                     property.Name.Equals(
                         "password",
                         StringComparison.OrdinalIgnoreCase)))
                {
                    Assert.That(
                        property.Value.GetString(),
                        Is.EqualTo("SYNTHETIC_REPLACE_ME"),
                        $"{relativePath}: credential placeholders must be external");
                }
                else
                {
                    ValidateCredentialPlaceholders(
                        property.Value,
                        relativePath);
                }
            }
        }
        else if (element.ValueKind == JsonValueKind.Array)
        {
            foreach (var item in element.EnumerateArray())
                ValidateCredentialPlaceholders(item, relativePath);
        }
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
