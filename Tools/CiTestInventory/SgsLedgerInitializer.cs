using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Gherkin;
using Gherkin.Ast;
using PnCTestAutomation.Artifacts;
using PnCTestAutomation.Products;

internal static class SgsLedgerInitializer
{
    public static int Run(string[] args)
    {
        if (args.Length is not (3 or 4))
        {
            Console.Error.WriteLine("Usage: initialize-sgs-ledger <repository-root> <dependency-map> <verified-utc> [delta-manifest]");
            return 2;
        }
        try
        {
            Initialize(
                Path.GetFullPath(args[0]),
                Path.GetFullPath(args[1]),
                DateTimeOffset.Parse(args[2], CultureInfo.InvariantCulture),
                args.Length == 4 ? Path.GetFullPath(args[3]) : null);
            return 0;
        }
        catch (Exception exception) when (exception is IOException or JsonException or
            InvalidOperationException or ArgumentException or FormatException or SgsExecutionConfigurationException)
        {
            Console.Error.WriteLine($"SGS ledger initialization failed: {exception.Message}");
            return 1;
        }
    }

    private static void Initialize(
        string root, string mapPath, DateTimeOffset verifiedAt, string? deltaPath)
    {
        var outputPath = Path.Combine(root, "Resources", "Contracts", "sgs-execution-ledger.json");
        if (File.Exists(outputPath))
            throw new InvalidOperationException("The ledger already exists; do not regenerate and erase adaptation progress.");
        var mapBytes = File.ReadAllBytes(mapPath);
        using var mapDocument = JsonDocument.Parse(mapBytes);
        using var featureDocument = ReadJson(root, "sgs-feature-inventory.json");
        using var dataDocument = ReadJson(root, "sgs-data-inventory.json");
        var map = mapDocument.RootElement;
        var featureInventory = featureDocument.RootElement;
        var dataInventory = dataDocument.RootElement;
        var mapCommit = Text(map.GetProperty("freshness"), "sha");
        var sourceRef = Text(map.GetProperty("freshness"), "ref");
        if (mapCommit != Text(featureInventory, "sourceCommit") || mapCommit != Text(dataInventory, "sourceCommit"))
            throw new InvalidOperationException("The reviewed map and retained source payload snapshots differ.");
        var sourceCommit = mapCommit;
        string? deltaHash = null;
        if (deltaPath != null)
        {
            var bytes = File.ReadAllBytes(deltaPath);
            using var deltaDocument = JsonDocument.Parse(bytes);
            var delta = deltaDocument.RootElement;
            if (Text(delta, "baseCommit") != mapCommit || Text(delta, "targetRef") != sourceRef ||
                new[] { "feature", "binding", "page", "locator", "data" }
                    .Any(kind => delta.GetProperty("coverageImpact").GetProperty(kind).GetInt32() != 0))
                throw new InvalidOperationException("Source coverage changed; reconcile its executable dependency map first.");
            sourceCommit = Text(delta, "targetCommit");
            deltaHash = Hash(bytes);
        }
        var features = featureInventory.GetProperty("features").EnumerateArray()
            .ToDictionary(item => Text(item, "sourceRelativePath"), StringComparer.Ordinal);
        var data = dataInventory.GetProperty("files").EnumerateArray()
            .ToDictionary(item => Text(item, "sourceRelativePath"), StringComparer.Ordinal);
        var workflows = new List<SgsWorkflowContract>();
        var edits = new List<(string Path, byte[] Bytes)>();
        var originalHeader = Encoding.UTF8.GetBytes("@SgsImported @NonRunnable @NoRetry\r\n");
        foreach (var source in map.GetProperty("features").EnumerateArray())
        {
            var sourcePath = Text(source, "featurePath");
            if (source.GetProperty("missingDependencyMappings").GetArrayLength() != 0)
                throw new InvalidOperationException($"Incomplete dependencies for {sourcePath}.");
            if (!features.TryGetValue(sourcePath, out var feature))
                throw new InvalidOperationException($"Missing imported feature provenance for {sourcePath}.");
            var destinationPath = Text(feature, "destinationPath");
            var path = ArtifactPathGuard.EnsureSafe(root,
                Path.Combine(root, destinationPath.Replace('/', Path.DirectorySeparatorChar)));
            var bytes = File.ReadAllBytes(path);
            if (!bytes.AsSpan().StartsWith(originalHeader) ||
                Hash(bytes) != Text(feature, "importedSha256") ||
                Hash(bytes.AsSpan(originalHeader.Length).ToArray()) != Text(feature, "sourceSha256"))
                throw new InvalidOperationException($"Source/imported feature payload changed: {destinationPath}.");

            using var reader = new StringReader(Encoding.UTF8.GetString(bytes));
            var document = new Parser().Parse(reader);
            var product = Text(source, "product");
            var folder = SgsExecutionCatalog.ProductFolder(product);
            var family = $"SGS-{product}-" +
                Regex.Replace(Path.GetFileNameWithoutExtension(path).ToUpperInvariant(), "[^A-Z0-9]+", "-").Trim('-');
            var application = product switch
            {
                "CLEQ" => "ExpertQuote",
                "CLDC" => "CommercialDuckCreek",
                "PLDC" => "PersonalDuckCreek",
                _ => throw new InvalidOperationException("Unknown SGS product.")
            };
            var runType = sourcePath.Contains("/Smoke/", StringComparison.Ordinal) ? "Smoke" : "Regression";
            var header = Encoding.UTF8.GetBytes(
                $"@SgsImported @NonRunnable @NoRetry @{application} @{runType} @AutomationId-{family}\r\n");
            var adaptedBytes = header.Concat(bytes.Skip(originalHeader.Length)).ToArray();
            var cases = new List<SgsExecutionCase>();
            var examples = new List<Examples>();
            foreach (var child in document.Feature.Children)
            {
                if (child is Background)
                    continue;
                if (child is not Scenario scenario || !scenario.Examples.Any())
                    throw new InvalidOperationException($"Unsupported SGS scenario structure: {sourcePath}.");
                foreach (var example in scenario.Examples)
                {
                    examples.Add(example);
                    foreach (var row in example.TableBody)
                        cases.Add(CreateCase(Arguments(example, row), SgsSourceCaseStatus.Active));
                }
            }
            if (cases.Count != source.GetProperty("sourceOutlineCaseCount").GetInt32())
                throw new InvalidOperationException($"Source/parsed example counts differ for {family}.");
            foreach (var comment in document.Comments.Where(item => Regex.IsMatch(item.Text, @"^\s*#\s*\|")))
            {
                var example = examples.Where(item => item.Location.Line < comment.Location.Line)
                    .OrderByDescending(item => item.Location.Line).FirstOrDefault()
                    ?? throw new InvalidOperationException("A source-commented example has no header.");
                var headers = string.Join(" | ", example.TableHeader.Cells.Select(cell => cell.Value));
                var row = Regex.Replace(comment.Text, @"^\s*#\s*", "");
                using var disabledReader = new StringReader(
                    $"Feature: Source disabled\nScenario Outline: Retained row\nGiven a source row\nExamples:\n| {headers} |\n{row}\n");
                var disabled = new Parser().Parse(disabledReader).Feature.Children.OfType<Scenario>()
                    .Single().Examples.Single();
                cases.Add(CreateCase(Arguments(disabled, disabled.TableBody.Single()), SgsSourceCaseStatus.CommentedOut));
            }
            var promises = Strings(source, "promisedOrMutatingSteps");
            var promiseText = string.Join("\n", promises);
            var outcomes = new List<string> { "InputsApplied", "QuoteIdentity" };
            if (Regex.IsMatch(promiseText, "premium", RegexOptions.IgnoreCase)) outcomes.Add("Premium");
            if (Regex.IsMatch(promiseText, "(verify|validat).*forms", RegexOptions.IgnoreCase)) outcomes.Add("Forms");
            if (Regex.IsMatch(promiseText, "transmit|transmission", RegexOptions.IgnoreCase)) outcomes.Add("Transmission");
            workflows.Add(new SgsWorkflowContract(
                family, product, document.Feature.Name, sourcePath, destinationPath,
                Text(feature, "sourceSha256"), Text(feature, "importedSha256"), Hash(adaptedBytes),
                application, runType, family.ToLowerInvariant(), outcomes,
                [ArtifactKind.Screenshot, ArtifactKind.Trace, ArtifactKind.Video, ArtifactKind.RuntimeLocator,
                 ArtifactKind.QuoteHandoff, ArtifactKind.TrxMetadata, ArtifactKind.TimingSummary,
                 ArtifactKind.ScenarioReportHtml, ArtifactKind.ScenarioResultJson, ArtifactKind.ExecutionLog],
                promises,
                new SgsWorkflowDependencies(
                    Strings(source, "bindingFiles"), Strings(source, "transitiveSharedBindingFiles"),
                    Strings(source, "directPageFiles").Concat(Strings(source, "sharedPageFiles")).Distinct().Order().ToArray(),
                    Strings(source, "directLocatorFiles").Concat(Strings(source, "sharedLocatorFiles")).Distinct().Order().ToArray(),
                    Strings(source, "frameInputs")),
                new SgsWorkflowReadiness(false, false, false, false, false, false, false, false), cases));
            edits.Add((path, adaptedBytes));

            SgsExecutionCase CreateCase(IReadOnlyDictionary<string, string> arguments, SgsSourceCaseStatus status)
            {
                var project = Text(feature, "sourceProject");
                var profile = data[$"tests/{project}/{arguments["dataFile"]}"];
                var external = data[$"tests/{project}/{arguments["externalDataFile"]}"];
                return new SgsExecutionCase(
                    SgsCaseIdentity.Resolve(family, arguments), arguments,
                    $"SGS/{folder}/{arguments["dataFile"]}", Text(profile, "importedSha256"),
                    $"SGS/{folder}/{arguments["externalDataFile"]}", Text(external, "importedSha256"),
                    status, SgsExecutionStatus.NonRunnable,
                    status == SgsSourceCaseStatus.CommentedOut
                        ? "Disabled in SGS source; QA review and executable adaptation are required before activation."
                        : "Business bindings/pages, strict inputs, selectors/frames, assertions and rich evidence are not yet adapted and verified.",
                    []);
            }
        }
        if (workflows.Count != features.Count)
            throw new InvalidOperationException("Not every retained feature has an executable dependency mapping.");
        var decisions = map.GetProperty("fileDisposition").EnumerateArray()
            .Select(item => new SgsDependencyDecision(
                Text(item, "path"), Text(item, "kind"), Text(item, "disposition"), Text(item, "reason"))).ToArray();
        var catalog = new SgsExecutionCatalog(new SgsExecutionLedger(
            1, Text(featureInventory, "sourceRepository"), sourceRef, sourceCommit, verifiedAt,
            mapCommit, Hash(mapBytes), deltaHash, decisions, workflows));
        foreach (var workflow in workflows)
        foreach (var item in workflow.Cases)
            catalog.ValidateResourcePayloads(Path.Combine(root, "Resources"), new SgsCaseResolution(workflow, item));

        foreach (var edit in edits)
            File.WriteAllBytes(edit.Path, edit.Bytes);
        File.WriteAllText(outputPath,
            JsonSerializer.Serialize(catalog.Ledger, SgsExecutionCatalog.JsonOptions) + "\n", new UTF8Encoding(false));
        Console.WriteLine($"Recorded {workflows.Count} SGS workflows, " +
            $"{workflows.Sum(item => item.Cases.Count(test => test.SourceStatus == SgsSourceCaseStatus.Active))} active cases, " +
            $"{workflows.Sum(item => item.Cases.Count(test => test.SourceStatus == SgsSourceCaseStatus.CommentedOut))} source-commented cases.");
    }

    private static Dictionary<string, string> Arguments(Examples examples, TableRow row) =>
        examples.TableHeader.Cells.Select(cell => cell.Value)
            .Zip(row.Cells.Select(cell => cell.Value))
            .ToDictionary(pair => pair.First, pair => pair.Second, StringComparer.OrdinalIgnoreCase);

    private static JsonDocument ReadJson(string root, string name) =>
        JsonDocument.Parse(File.ReadAllText(Path.Combine(root, "Resources", "Contracts", name)));

    private static string Text(JsonElement element, string property) =>
        element.GetProperty(property).GetString()
        ?? throw new InvalidOperationException($"Missing required '{property}'.");

    private static string[] Strings(JsonElement element, string property) =>
        element.GetProperty(property).EnumerateArray()
            .Select(item => item.GetString() ?? throw new InvalidOperationException($"Empty '{property}' entry.")).ToArray();

    private static string Hash(byte[] bytes) => Convert.ToHexString(SHA256.HashData(bytes));
}
