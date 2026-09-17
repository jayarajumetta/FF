using System.Text.Json;
using PnCTestAutomation.TestPlanPublisher;

if (args.Length == 0 ||
    !new[] { "validate", "dry-run", "publish", "reconcile" }
        .Contains(args[0], StringComparer.OrdinalIgnoreCase))
{
    Console.Error.WriteLine(
        "Usage: TestPlanPublisher <validate|dry-run|publish|reconcile> " +
        "--package-root <path> --results-root <path> --catalog <path> " +
        "--environment <name> --browser <name> [--state <path>] [--output <path>]");
    return 2;
}

try
{
    var mode = args[0].ToLowerInvariant();
    var options = ParseOptions(args.Skip(1).ToArray());
    var packageRoot = Require(options, "package-root");
    var resultsRoot = Require(options, "results-root");
    var catalogPath = Require(options, "catalog");
    var environment = Require(options, "environment");
    var browser = Require(options, "browser");
    var statePath = options.GetValueOrDefault(
        "state",
        Path.Combine(
            resultsRoot,
            mode == "dry-run"
                ? "ado-publication-dry-run-reconciliation.json"
                : "ado-publication-reconciliation.json"));
    var outputPath = options.GetValueOrDefault(
        "output",
        Path.Combine(resultsRoot, "ado-testplans-dry-run.json"));

    var batch = new CanonicalResultLoader().Load(
        packageRoot,
        resultsRoot,
        catalogPath,
        environment,
        browser);
    if (mode == "validate")
    {
        Console.WriteLine(JsonSerializer.Serialize(new
        {
            valid = true,
            batch.CorrelationKey,
            batch.PlanId,
            executionCount = batch.Executions.Count
        }));
        return 0;
    }

    ITestPlanPublisher publisher;
    if (mode == "dry-run")
    {
        publisher = new DryRunFileTestPlanPublisher(outputPath);
    }
    else
    {
        if (mode == "reconcile" && !File.Exists(statePath))
        {
            throw new TestPlanPublicationException(
                "Reconcile mode requires an existing reconciliation record.");
        }
        var bearer = EnvironmentValue("SYSTEM_ACCESSTOKEN");
        var pat = EnvironmentValue("AZDO_TEST_PAT");
        var credential = !string.IsNullOrWhiteSpace(bearer) ? bearer : pat;
        publisher = new AzureDevOpsRestTestPlanPublisher(
            new HttpClient(),
            new AzureDevOpsPublisherOptions
            {
                OrganizationUrl =
                    EnvironmentValue("AZDO_ORGANIZATION_URL"),
                TrustedCollectionUrl =
                    EnvironmentValue("SYSTEM_COLLECTIONURI"),
                Project =
                    EnvironmentValue("AZDO_PROJECT"),
                Credential = credential ?? "",
                UseBearerToken = !string.IsNullOrWhiteSpace(bearer)
            });
    }

    var receipt = await publisher.PublishAsync(batch, statePath);
    Console.WriteLine(JsonSerializer.Serialize(new
    {
        published = true,
        receipt.CorrelationKey,
        receipt.RunId,
        receipt.PublishedResults,
        receipt.UploadedAttachments,
        receipt.DryRun,
        receipt.ReconciliationPath
    }));
    return 0;
}
catch (TestPlanPublicationException exception)
{
    Console.Error.WriteLine($"Test Plans publication failed: {exception.Message}");
    return 1;
}
catch (Exception)
{
    Console.Error.WriteLine(
        "Test Plans publication failed with an unexpected non-sensitive error.");
    return 1;
}

static Dictionary<string, string> ParseOptions(string[] values)
{
    if (values.Length % 2 != 0)
        throw new TestPlanPublicationException(
            "Every command option requires a value.");
    var result = new Dictionary<string, string>(
        StringComparer.OrdinalIgnoreCase);
    var allowed = new HashSet<string>(
        [
            "package-root",
            "results-root",
            "catalog",
            "environment",
            "browser",
            "state",
            "output"
        ],
        StringComparer.OrdinalIgnoreCase);
    for (var index = 0; index < values.Length; index += 2)
    {
        var name = values[index].StartsWith("--", StringComparison.Ordinal)
            ? values[index][2..]
            : "";
        if (!allowed.Contains(name) ||
            !result.TryAdd(name, values[index + 1]))
        {
            throw new TestPlanPublicationException(
                $"Command option '{values[index]}' is invalid or duplicated.");
        }
    }
    return result;
}

static string Require(
    IReadOnlyDictionary<string, string> options,
    string name)
{
    if (!options.TryGetValue(name, out var value) ||
        string.IsNullOrWhiteSpace(value))
    {
        throw new TestPlanPublicationException(
            $"Required command option '--{name}' is missing.");
    }
    return value;
}

static string EnvironmentValue(string name)
{
    var value = Environment.GetEnvironmentVariable(name)?.Trim() ?? "";
    return value.StartsWith("$(", StringComparison.Ordinal) &&
           value.EndsWith(')')
        ? ""
        : value;
}
