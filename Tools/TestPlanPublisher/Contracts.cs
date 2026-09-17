using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace PnCTestAutomation.TestPlanPublisher;

public sealed class TestPlanPublicationException : Exception
{
    public TestPlanPublicationException(string message)
        : base(message)
    {
    }
}

public sealed class TestPlanMappingCatalog
{
    public int SchemaVersion { get; init; }
    public string CatalogVersion { get; init; } = "";
    public string Provenance { get; init; } = "";
    public string Checksum { get; init; } = "";
    public List<TestPlanMappingEntry> Mappings { get; init; } = [];

    public IReadOnlyDictionary<string, TestPlanMappingEntry> Validate(
        IEnumerable<string> requiredAutomationIds)
    {
        if (SchemaVersion != 1)
            throw new TestPlanPublicationException(
                $"Unsupported mapping catalog schema '{SchemaVersion}'.");
        RequireText(CatalogVersion, nameof(CatalogVersion));
        RequireText(Provenance, nameof(Provenance));
        if (!Checksum.Equals(
                ComputeChecksum(this),
                StringComparison.OrdinalIgnoreCase))
        {
            throw new TestPlanPublicationException(
                "The mapping catalog checksum is stale or invalid.");
        }

        var byAutomationId = new Dictionary<string, TestPlanMappingEntry>(
            StringComparer.Ordinal);
        var adoTargets = new HashSet<string>(StringComparer.Ordinal);
        foreach (var mapping in Mappings)
        {
            mapping.Validate();
            if (!byAutomationId.TryAdd(mapping.AutomationId, mapping))
            {
                throw new TestPlanPublicationException(
                    $"Duplicate automation ID '{mapping.AutomationId}'.");
            }
            var target =
                $"{mapping.PlanId}:{mapping.SuiteId}:{mapping.TestCaseId}:{mapping.ConfigurationId}";
            if (!adoTargets.Add(target))
            {
                throw new TestPlanPublicationException(
                    $"Ambiguous Azure DevOps target '{target}'.");
            }
        }

        var required = requiredAutomationIds
            .Where(value => !string.IsNullOrWhiteSpace(value))
            .Distinct(StringComparer.Ordinal)
            .ToArray();
        var missing = required
            .Where(id => !byAutomationId.ContainsKey(id))
            .OrderBy(id => id, StringComparer.Ordinal)
            .ToArray();
        if (missing.Length > 0)
        {
            throw new TestPlanPublicationException(
                $"The mapping catalog is missing gated automation IDs: {string.Join(", ", missing)}.");
        }

        return byAutomationId;
    }

    public static string ComputeChecksum(TestPlanMappingCatalog catalog)
    {
        var lines = new List<string>
        {
            catalog.SchemaVersion.ToString(),
            catalog.CatalogVersion.Trim(),
            catalog.Provenance.Trim()
        };
        lines.AddRange(catalog.Mappings
            .OrderBy(item => item.AutomationId, StringComparer.Ordinal)
            .Select(item => string.Join(
                "|",
                item.AutomationId.Trim(),
                item.PlanId,
                item.SuiteId,
                item.TestCaseId,
                item.ConfigurationId)));
        return Convert.ToHexString(
            SHA256.HashData(Encoding.UTF8.GetBytes(string.Join("\n", lines))));
    }

    private static void RequireText(string value, string name)
    {
        if (string.IsNullOrWhiteSpace(value) ||
            value.Contains('\r') ||
            value.Contains('\n') ||
            value.Contains('|'))
        {
            throw new TestPlanPublicationException(
                $"Mapping catalog {name} is missing or invalid.");
        }
    }
}

public sealed record TestPlanMappingEntry
{
    private static readonly Regex AutomationIdPattern = new(
        @"^[A-Z][A-Z0-9]*(?:-[A-Z0-9]+)*(?::[A-Z0-9][A-Z0-9-]*)$",
        RegexOptions.CultureInvariant);

    public string AutomationId { get; init; } = "";
    public int PlanId { get; init; }
    public int SuiteId { get; init; }
    public int TestCaseId { get; init; }
    public int ConfigurationId { get; init; }

    public void Validate()
    {
        if (!AutomationIdPattern.IsMatch(AutomationId))
            throw new TestPlanPublicationException(
                $"Automation ID '{AutomationId}' is invalid.");
        if (PlanId <= 0 || SuiteId <= 0 ||
            TestCaseId <= 0 || ConfigurationId <= 0)
        {
            throw new TestPlanPublicationException(
                $"Azure DevOps IDs for '{AutomationId}' must be positive.");
        }
    }
}

public enum CanonicalTestOutcome
{
    Passed,
    Failed
}

public sealed record PublicationAttachment(
    string RelativePath,
    string AbsolutePath,
    long Size,
    string Sha256,
    bool UploadPermitted)
{
    public string IdempotencyKey =>
        CanonicalResultLoader.Hash($"{RelativePath}|{Sha256}");
}

public sealed record CanonicalTestExecution(
    string AutomationId,
    string TestIdentity,
    CanonicalTestOutcome Outcome,
    TimeSpan Duration,
    TestPlanMappingEntry Mapping,
    IReadOnlyList<string> IdentityHashes,
    IReadOnlyList<PublicationAttachment> Attachments);

public sealed record TestPlanPublicationBatch(
    string CorrelationKey,
    string PackageVersion,
    string CommitSha,
    string BuildId,
    string CatalogVersion,
    string CatalogChecksum,
    string Environment,
    string Browser,
    string Shard,
    int PlanId,
    IReadOnlyList<CanonicalTestExecution> Executions);

public sealed record TestPlanPublicationReceipt(
    string CorrelationKey,
    int? RunId,
    int PublishedResults,
    int UploadedAttachments,
    bool DryRun,
    string ReconciliationPath);

public interface ITestPlanPublisher
{
    Task<TestPlanPublicationReceipt> PublishAsync(
        TestPlanPublicationBatch batch,
        string reconciliationPath,
        CancellationToken cancellationToken = default);
}

public interface ITemporaryTestSuiteManager
{
    Task<int> CreateAsync(
        int planId,
        string name,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        int planId,
        int suiteId,
        CancellationToken cancellationToken = default);
}

public sealed class TemporaryTestSuiteScope
{
    private readonly ITemporaryTestSuiteManager _manager;

    public TemporaryTestSuiteScope(ITemporaryTestSuiteManager manager)
    {
        _manager = manager;
    }

    public async Task<T> ExecuteAsync<T>(
        int planId,
        string name,
        Func<int, Task<T>> action,
        CancellationToken cancellationToken = default)
    {
        var suiteId = await _manager.CreateAsync(
            planId,
            name,
            cancellationToken);
        try
        {
            return await action(suiteId);
        }
        finally
        {
            await _manager.DeleteAsync(planId, suiteId, cancellationToken);
        }
    }
}
