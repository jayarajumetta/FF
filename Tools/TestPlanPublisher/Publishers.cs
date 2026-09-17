using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace PnCTestAutomation.TestPlanPublisher;

public sealed class DryRunFileTestPlanPublisher : ITestPlanPublisher
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };

    private readonly string _outputPath;

    public DryRunFileTestPlanPublisher(string outputPath)
    {
        _outputPath = Path.GetFullPath(outputPath);
    }

    public async Task<TestPlanPublicationReceipt> PublishAsync(
        TestPlanPublicationBatch batch,
        string reconciliationPath,
        CancellationToken cancellationToken = default)
    {
        var stateStore = new FilePublicationStateStore(reconciliationPath);
        var state = await stateStore.LoadOrCreateAsync(
            batch.CorrelationKey,
            "dry-run",
            cancellationToken);

        foreach (var execution in batch.Executions)
        {
            var executionState = state.GetOrCreate(execution.AutomationId);
            executionState.ResultId ??= DeterministicPositiveId(
                $"{batch.CorrelationKey}|{execution.AutomationId}");
            executionState.Outcome = execution.Outcome.ToString();
            foreach (var attachment in execution.Attachments
                         .Where(item => item.UploadPermitted))
            {
                executionState.AttachmentKeys.Add(attachment.IdempotencyKey);
            }
            executionState.Completed = true;
        }
        state.Completed = true;
        state.LastError = null;
        await stateStore.SaveAsync(state, cancellationToken);

        var output = new
        {
            schemaVersion = 1,
            mode = "dry-run",
            batch.CorrelationKey,
            batch.PackageVersion,
            batch.CommitSha,
            batch.BuildId,
            batch.CatalogVersion,
            batch.CatalogChecksum,
            batch.Environment,
            batch.Browser,
            batch.Shard,
            batch.PlanId,
            executions = batch.Executions.Select(execution => new
            {
                execution.AutomationId,
                outcome = execution.Outcome.ToString(),
                durationMilliseconds = (long)execution.Duration.TotalMilliseconds,
                execution.Mapping.PlanId,
                execution.Mapping.SuiteId,
                execution.Mapping.TestCaseId,
                execution.Mapping.ConfigurationId,
                execution.IdentityHashes,
                attachments = execution.Attachments.Select(attachment => new
                {
                    attachment.RelativePath,
                    attachment.Size,
                    attachment.Sha256,
                    attachment.UploadPermitted
                })
            })
        };
        await AtomicJson.WriteAsync(
            _outputPath,
            output,
            JsonOptions,
            cancellationToken);
        return new TestPlanPublicationReceipt(
            batch.CorrelationKey,
            state.RunId,
            batch.Executions.Count,
            batch.Executions.Sum(item =>
                item.Attachments.Count(attachment => attachment.UploadPermitted)),
            true,
            Path.GetFullPath(reconciliationPath));
    }

    private static int DeterministicPositiveId(string value)
    {
        var bytes = Convert.FromHexString(CanonicalResultLoader.Hash(value));
        return Math.Max(1, BitConverter.ToInt32(bytes, 0) & int.MaxValue);
    }
}

public sealed class AzureDevOpsPublisherOptions
{
    public string OrganizationUrl { get; init; } = "";
    public string TrustedCollectionUrl { get; init; } = "";
    public string Project { get; init; } = "";
    public string Credential { get; init; } = "";
    public bool UseBearerToken { get; init; }

    public void Validate()
    {
        if (!Uri.TryCreate(OrganizationUrl, UriKind.Absolute, out var uri) ||
            uri.Scheme != Uri.UriSchemeHttps ||
            !string.IsNullOrEmpty(uri.UserInfo) ||
            !string.IsNullOrEmpty(uri.Query) ||
            !string.IsNullOrEmpty(uri.Fragment))
        {
            throw new TestPlanPublicationException(
                "AZDO_ORGANIZATION_URL must be an absolute HTTPS URL without credentials or query text.");
        }
        if (!IsAzureDevOpsHost(uri.Host))
        {
            throw new TestPlanPublicationException(
                "AZDO_ORGANIZATION_URL must use a trusted Azure DevOps host.");
        }
        if (UseBearerToken &&
            (!Uri.TryCreate(
                    TrustedCollectionUrl,
                    UriKind.Absolute,
                    out var trustedCollectionUri) ||
             !SameCollection(uri, trustedCollectionUri)))
        {
            throw new TestPlanPublicationException(
                "AZDO_ORGANIZATION_URL must match SYSTEM_COLLECTIONURI when using System.AccessToken.");
        }
        if (string.IsNullOrWhiteSpace(Project) ||
            Project.Any(char.IsControl) ||
            Project.Contains('/') ||
            Project.Contains('\\'))
        {
            throw new TestPlanPublicationException(
                "AZDO_PROJECT is missing or invalid.");
        }
        if (string.IsNullOrWhiteSpace(Credential))
        {
            throw new TestPlanPublicationException(
                "An Azure DevOps service token or PAT must be supplied externally.");
        }
    }

    private static bool IsAzureDevOpsHost(string host) =>
        host.Equals("dev.azure.com", StringComparison.OrdinalIgnoreCase) ||
        host.EndsWith(".visualstudio.com", StringComparison.OrdinalIgnoreCase);

    private static bool SameCollection(Uri organization, Uri trusted) =>
        trusted.Scheme == Uri.UriSchemeHttps &&
        string.IsNullOrEmpty(trusted.UserInfo) &&
        string.IsNullOrEmpty(trusted.Query) &&
        string.IsNullOrEmpty(trusted.Fragment) &&
        Uri.Compare(
            organization,
            trusted,
            UriComponents.SchemeAndServer | UriComponents.Path,
            UriFormat.SafeUnescaped,
            StringComparison.OrdinalIgnoreCase) == 0;
}

public sealed class AzureDevOpsRestTestPlanPublisher : ITestPlanPublisher
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };

    private readonly HttpClient _httpClient;
    private readonly AzureDevOpsPublisherOptions _options;
    private readonly Uri _apiBase;

    public AzureDevOpsRestTestPlanPublisher(
        HttpClient httpClient,
        AzureDevOpsPublisherOptions options)
    {
        _httpClient = httpClient;
        _options = options;
        _options.Validate();
        _apiBase = new Uri(
            options.OrganizationUrl.TrimEnd('/') + "/" +
            Uri.EscapeDataString(options.Project) + "/");
    }

    public async Task<TestPlanPublicationReceipt> PublishAsync(
        TestPlanPublicationBatch batch,
        string reconciliationPath,
        CancellationToken cancellationToken = default)
    {
        var stateStore = new FilePublicationStateStore(reconciliationPath);
        var state = await stateStore.LoadOrCreateAsync(
            batch.CorrelationKey,
            "azure-devops",
            cancellationToken);
        try
        {
            var runName = $"PnC-{batch.Shard}-{batch.CorrelationKey[..16]}";
            state.RunId ??= await FindOrCreateRunAsync(
                batch,
                runName,
                cancellationToken);
            await stateStore.SaveAsync(state, cancellationToken);

            var existingResults = await GetResultsAsync(
                state.RunId.Value,
                cancellationToken);
            var uploaded = 0;
            foreach (var execution in batch.Executions)
            {
                var executionState = state.GetOrCreate(execution.AutomationId);
                var existingMatches = existingResults
                    .Where(item => item.AutomatedTestName.Equals(
                        execution.AutomationId,
                        StringComparison.Ordinal))
                    .ToArray();
                if (existingMatches.Length > 1)
                {
                    throw new TestPlanPublicationException(
                        $"Azure DevOps contains duplicate results for '{execution.AutomationId}'.");
                }
                if (executionState.ResultId.HasValue)
                {
                    if (existingMatches.Length != 1 ||
                        existingMatches[0].Id != executionState.ResultId.Value)
                    {
                        throw new TestPlanPublicationException(
                            $"The reconciliation record drifted from Azure DevOps for '{execution.AutomationId}'.");
                    }
                }
                else
                {
                    executionState.ResultId =
                        existingMatches.SingleOrDefault()?.Id;
                }

                var pointId = await ResolvePointAsync(
                    execution.Mapping,
                    cancellationToken);
                var published = await UpsertResultAsync(
                    state.RunId.Value,
                    executionState.ResultId,
                    pointId,
                    batch,
                    execution,
                    cancellationToken);
                executionState.ResultId = published.Id;
                executionState.Outcome = published.Outcome;
                executionState.Completed = false;
                await stateStore.SaveAsync(state, cancellationToken);

                var existingAttachmentKeys =
                    await GetAttachmentKeysAsync(
                        state.RunId.Value,
                        published.Id,
                        cancellationToken);
                foreach (var attachment in execution.Attachments
                             .Where(item => item.UploadPermitted))
                {
                    if (existingAttachmentKeys.Contains(
                            attachment.IdempotencyKey))
                    {
                        executionState.AttachmentKeys.Add(
                            attachment.IdempotencyKey);
                        continue;
                    }
                    await UploadAttachmentAsync(
                        state.RunId.Value,
                        published.Id,
                        attachment,
                        cancellationToken);
                    executionState.AttachmentKeys.Add(
                        attachment.IdempotencyKey);
                    uploaded++;
                    await stateStore.SaveAsync(state, cancellationToken);
                }
                var requiredKeys = execution.Attachments
                    .Where(item => item.UploadPermitted)
                    .Select(item => item.IdempotencyKey)
                    .ToHashSet(StringComparer.OrdinalIgnoreCase);
                var remoteKeys = await GetAttachmentKeysAsync(
                    state.RunId.Value,
                    published.Id,
                    cancellationToken);
                if (!requiredKeys.SetEquals(remoteKeys))
                {
                    throw new TestPlanPublicationException(
                        $"Azure DevOps attachment parity failed for '{execution.AutomationId}'.");
                }
                executionState.Completed = true;
                await stateStore.SaveAsync(state, cancellationToken);
            }

            await ValidateRemoteParityAsync(
                state.RunId.Value,
                batch,
                cancellationToken);
            await CompleteRunAsync(state.RunId.Value, cancellationToken);
            state.Completed = true;
            state.LastError = null;
            await stateStore.SaveAsync(state, cancellationToken);
            return new TestPlanPublicationReceipt(
                batch.CorrelationKey,
                state.RunId,
                batch.Executions.Count,
                uploaded,
                false,
                Path.GetFullPath(reconciliationPath));
        }
        catch (Exception exception)
        {
            state.Completed = false;
            state.LastError = SafeError(exception);
            await stateStore.SaveAsync(state, CancellationToken.None);
            if (exception is TestPlanPublicationException)
                throw;
            throw new TestPlanPublicationException(
                "Azure DevOps publication failed; use the reconciliation record to resume.");
        }
    }

    private async Task<int> FindOrCreateRunAsync(
        TestPlanPublicationBatch batch,
        string runName,
        CancellationToken cancellationToken)
    {
        var existing = await SendAsync<AdoList<AdoRun>>(
            HttpMethod.Get,
            $"_apis/test/runs?planId={batch.PlanId}&api-version=7.1",
            null,
            cancellationToken);
        var matches = existing.Value
            .Where(run => run.Name.Equals(runName, StringComparison.Ordinal))
            .ToArray();
        if (matches.Length > 1)
            throw new TestPlanPublicationException(
                "Azure DevOps run correlation is ambiguous.");
        if (matches.Length == 1)
            return RequirePositive(matches[0].Id, "run");

        var created = await SendAsync<AdoRun>(
            HttpMethod.Post,
            "_apis/test/runs?api-version=7.1",
            new
            {
                name = runName,
                plan = new { id = batch.PlanId },
                automated = true,
                state = "InProgress",
                comment =
                    $"correlation={batch.CorrelationKey}; package={batch.PackageVersion}; commit={batch.CommitSha}; catalog={batch.CatalogVersion}/{batch.CatalogChecksum}; environment={batch.Environment}; browser={batch.Browser}; shard={batch.Shard}"
            },
            cancellationToken);
        if (!created.Name.Equals(runName, StringComparison.Ordinal))
            throw new TestPlanPublicationException(
                "Azure DevOps returned a mismatched run identity.");
        return RequirePositive(created.Id, "run");
    }

    private async Task<int> ResolvePointAsync(
        TestPlanMappingEntry mapping,
        CancellationToken cancellationToken)
    {
        var response = await SendAsync<AdoList<AdoPoint>>(
            HttpMethod.Get,
            $"_apis/testplan/Plans/{mapping.PlanId}/Suites/{mapping.SuiteId}/TestPoint?testCaseId={mapping.TestCaseId}&api-version=7.1-preview.2",
            null,
            cancellationToken);
        var matches = response.Value
            .Where(point =>
                point.TestCaseReference?.Id == mapping.TestCaseId &&
                point.Configuration?.Id == mapping.ConfigurationId)
            .ToArray();
        if (matches.Length != 1)
        {
            throw new TestPlanPublicationException(
                $"Azure DevOps test-point mapping is missing or ambiguous for '{mapping.AutomationId}'.");
        }
        return RequirePositive(matches[0].Id, "test point");
    }

    private async Task<AdoResult> UpsertResultAsync(
        int runId,
        int? resultId,
        int pointId,
        TestPlanPublicationBatch batch,
        CanonicalTestExecution execution,
        CancellationToken cancellationToken)
    {
        var outcome = execution.Outcome.ToString();
        var payload = new
        {
            id = resultId,
            testCase = new { id = execution.Mapping.TestCaseId },
            testPoint = new { id = pointId },
            configuration = new { id = execution.Mapping.ConfigurationId },
            outcome,
            state = "Completed",
            automatedTestName = execution.AutomationId,
            automatedTestType = "Reqnroll",
            durationInMs = Math.Max(0, (long)execution.Duration.TotalMilliseconds),
            comment = BuildSafeComment(batch, execution)
        };
        var method = resultId.HasValue
            ? HttpMethod.Patch
            : HttpMethod.Post;
        var response = await SendAsync<AdoList<AdoResult>>(
            method,
            $"_apis/test/runs/{runId}/results?api-version=7.1",
            new[] { payload },
            cancellationToken);
        if (response.Value.Count != 1)
            throw new TestPlanPublicationException(
                $"Azure DevOps returned an ambiguous result for '{execution.AutomationId}'.");
        var result = response.Value[0];
        ValidateResultIdentity(result, execution);
        return result;
    }

    private async Task<HashSet<string>> GetAttachmentKeysAsync(
        int runId,
        int resultId,
        CancellationToken cancellationToken)
    {
        var response = await SendAsync<AdoList<AdoAttachment>>(
            HttpMethod.Get,
            $"_apis/test/runs/{runId}/results/{resultId}/attachments?api-version=7.1-preview.1",
            null,
            cancellationToken);
        var keys = response.Value
            .Select(item => item.Comment)
            .Where(comment => comment.StartsWith(
                "pnc-attachment:",
                StringComparison.OrdinalIgnoreCase))
            .Select(comment => comment["pnc-attachment:".Length..])
            .ToArray();
        if (keys.Length != keys
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .Count())
        {
            throw new TestPlanPublicationException(
                "Azure DevOps contains duplicate publisher-managed attachments.");
        }
        return keys.ToHashSet(StringComparer.OrdinalIgnoreCase);
    }

    private async Task UploadAttachmentAsync(
        int runId,
        int resultId,
        PublicationAttachment attachment,
        CancellationToken cancellationToken)
    {
        var response = await SendAsync<AdoAttachment>(
            HttpMethod.Post,
            $"_apis/test/runs/{runId}/results/{resultId}/attachments?api-version=7.1-preview.1",
            new
            {
                stream = Convert.ToBase64String(
                    await File.ReadAllBytesAsync(
                        attachment.AbsolutePath,
                        cancellationToken)),
                fileName = Path.GetFileName(attachment.RelativePath),
                comment = $"pnc-attachment:{attachment.IdempotencyKey}",
                attachmentType = "GeneralAttachment"
            },
            cancellationToken);
        RequirePositive(response.Id, "attachment");
    }

    private async Task ValidateRemoteParityAsync(
        int runId,
        TestPlanPublicationBatch batch,
        CancellationToken cancellationToken)
    {
        var remote = await GetResultsAsync(runId, cancellationToken);
        var automated = remote
            .Where(item => !string.IsNullOrWhiteSpace(item.AutomatedTestName))
            .ToArray();
        if (automated.Length != batch.Executions.Count)
        {
            throw new TestPlanPublicationException(
                "Azure DevOps result count disagrees with the canonical execution set.");
        }
        foreach (var execution in batch.Executions)
        {
            var matches = automated
                .Where(item => item.AutomatedTestName.Equals(
                    execution.AutomationId,
                    StringComparison.Ordinal))
                .ToArray();
            if (matches.Length != 1)
                throw new TestPlanPublicationException(
                    $"Azure DevOps result parity failed for '{execution.AutomationId}'.");
            ValidateResultIdentity(matches[0], execution);
        }
    }

    private async Task<IReadOnlyList<AdoResult>> GetResultsAsync(
        int runId,
        CancellationToken cancellationToken)
    {
        var response = await SendAsync<AdoList<AdoResult>>(
            HttpMethod.Get,
            $"_apis/test/runs/{runId}/results?api-version=7.1",
            null,
            cancellationToken);
        return response.Value;
    }

    private async Task CompleteRunAsync(
        int runId,
        CancellationToken cancellationToken)
    {
        var response = await SendAsync<AdoRun>(
            HttpMethod.Patch,
            $"_apis/test/runs/{runId}?api-version=7.1",
            new { state = "Completed" },
            cancellationToken);
        if (!response.State.Equals("Completed", StringComparison.OrdinalIgnoreCase))
            throw new TestPlanPublicationException(
                "Azure DevOps did not confirm run completion.");
    }

    private async Task<T> SendAsync<T>(
        HttpMethod method,
        string relativeUri,
        object? payload,
        CancellationToken cancellationToken)
    {
        using var request = new HttpRequestMessage(
            method,
            new Uri(_apiBase, relativeUri));
        request.Headers.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        request.Headers.Authorization = _options.UseBearerToken
            ? new AuthenticationHeaderValue("Bearer", _options.Credential)
            : new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(
                    Encoding.ASCII.GetBytes($":{_options.Credential}")));
        if (payload != null)
            request.Content = JsonContent.Create(payload, options: JsonOptions);

        using var response = await _httpClient.SendAsync(
            request,
            HttpCompletionOption.ResponseHeadersRead,
            cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            throw new TestPlanPublicationException(
                $"Azure DevOps {method.Method} request failed with HTTP {(int)response.StatusCode} ({response.StatusCode}).");
        }
        if (response.StatusCode == HttpStatusCode.NoContent)
            return default!;
        if (response.Content.Headers.ContentType?.MediaType is not { } mediaType ||
            !mediaType.Equals("application/json", StringComparison.OrdinalIgnoreCase))
        {
            throw new TestPlanPublicationException(
                $"Azure DevOps {method.Method} response was not JSON.");
        }
        try
        {
            return await response.Content.ReadFromJsonAsync<T>(
                       JsonOptions,
                       cancellationToken)
                   ?? throw new JsonException();
        }
        catch (JsonException)
        {
            throw new TestPlanPublicationException(
                $"Azure DevOps {method.Method} response was malformed JSON.");
        }
    }

    private static void ValidateResultIdentity(
        AdoResult result,
        CanonicalTestExecution execution)
    {
        if (result.Id <= 0 ||
            !result.AutomatedTestName.Equals(
                execution.AutomationId,
                StringComparison.Ordinal) ||
            !result.Outcome.Equals(
                execution.Outcome.ToString(),
                StringComparison.OrdinalIgnoreCase) ||
            result.TestCase?.Id != execution.Mapping.TestCaseId ||
            result.Configuration?.Id != execution.Mapping.ConfigurationId)
        {
            throw new TestPlanPublicationException(
                $"Azure DevOps returned result identity or outcome drift for '{execution.AutomationId}'.");
        }
    }

    private static string BuildSafeComment(
        TestPlanPublicationBatch batch,
        CanonicalTestExecution execution)
    {
        var hashes = execution.IdentityHashes.Count == 0
            ? "none"
            : string.Join(",", execution.IdentityHashes);
        return
            $"correlation={batch.CorrelationKey}; package={batch.PackageVersion}; commit={batch.CommitSha}; catalog={batch.CatalogVersion}/{batch.CatalogChecksum}; environment={batch.Environment}; browser={batch.Browser}; shard={batch.Shard}; automation={execution.AutomationId}; identityHashes={hashes}";
    }

    private static int RequirePositive(int value, string identity)
    {
        if (value <= 0)
            throw new TestPlanPublicationException(
                $"Azure DevOps returned an invalid {identity} ID.");
        return value;
    }

    private static string SafeError(Exception exception)
    {
        var status = exception is TestPlanPublicationException
            ? exception.Message
            : "Azure DevOps publication failed.";
        return status.Length <= 500 ? status : status[..500];
    }

    private sealed class AdoList<T>
    {
        public List<T> Value { get; init; } = [];
    }

    private sealed class AdoRun
    {
        public int Id { get; init; }
        public string Name { get; init; } = "";
        public string State { get; init; } = "";
    }

    private sealed class AdoResult
    {
        public int Id { get; init; }
        public string AutomatedTestName { get; init; } = "";
        public string Outcome { get; init; } = "";
        public AdoIdentity? TestCase { get; init; }
        public AdoIdentity? Configuration { get; init; }
    }

    private sealed class AdoPoint
    {
        public int Id { get; init; }
        public AdoIdentity? TestCaseReference { get; init; }
        public AdoIdentity? Configuration { get; init; }
    }

    private sealed class AdoAttachment
    {
        public int Id { get; init; }
        public string Comment { get; init; } = "";
    }

    private sealed class AdoIdentity
    {
        public int Id { get; init; }
    }
}

public sealed class PublicationReconciliationState
{
    public int SchemaVersion { get; init; } = 1;
    public string CorrelationKey { get; init; } = "";
    public string PublisherKind { get; init; } = "";
    public int? RunId { get; set; }
    public bool Completed { get; set; }
    public string? LastError { get; set; }
    public Dictionary<string, PublicationExecutionState> Executions { get; init; } =
        new(StringComparer.Ordinal);

    public PublicationExecutionState GetOrCreate(string automationId)
    {
        if (!Executions.TryGetValue(automationId, out var state))
        {
            state = new PublicationExecutionState();
            Executions.Add(automationId, state);
        }
        return state;
    }
}

public sealed class PublicationExecutionState
{
    public int? ResultId { get; set; }
    public string Outcome { get; set; } = "";
    public bool Completed { get; set; }
    public HashSet<string> AttachmentKeys { get; init; } =
        new(StringComparer.OrdinalIgnoreCase);
}

public sealed class FilePublicationStateStore
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    };

    private readonly string _path;

    public FilePublicationStateStore(string path)
    {
        _path = Path.GetFullPath(path);
    }

    public async Task<PublicationReconciliationState> LoadOrCreateAsync(
        string correlationKey,
        string publisherKind,
        CancellationToken cancellationToken)
    {
        if (!File.Exists(_path))
        {
            return new PublicationReconciliationState
            {
                CorrelationKey = correlationKey,
                PublisherKind = publisherKind
            };
        }
        PublicationReconciliationState state;
        try
        {
            await using var stream = File.OpenRead(_path);
            state = await JsonSerializer.DeserializeAsync<PublicationReconciliationState>(
                        stream,
                        JsonOptions,
                        cancellationToken)
                    ?? throw new JsonException();
        }
        catch (Exception exception) when (
            exception is JsonException or IOException)
        {
            throw new TestPlanPublicationException(
                "The publication reconciliation record is corrupt.");
        }
        if (state.SchemaVersion != 1 ||
            !state.CorrelationKey.Equals(
                correlationKey,
                StringComparison.Ordinal) ||
            !state.PublisherKind.Equals(
                publisherKind,
                StringComparison.Ordinal))
        {
            throw new TestPlanPublicationException(
                "The publication reconciliation record does not match this execution.");
        }
        return state;
    }

    public Task SaveAsync(
        PublicationReconciliationState state,
        CancellationToken cancellationToken) =>
        AtomicJson.WriteAsync(_path, state, JsonOptions, cancellationToken);
}

internal static class AtomicJson
{
    public static async Task WriteAsync<T>(
        string path,
        T value,
        JsonSerializerOptions options,
        CancellationToken cancellationToken)
    {
        var fullPath = Path.GetFullPath(path);
        Directory.CreateDirectory(
            Path.GetDirectoryName(fullPath)
            ?? throw new TestPlanPublicationException(
                "Publication output has no parent directory."));
        var temporaryPath = fullPath + "." + Guid.NewGuid().ToString("N") + ".tmp";
        try
        {
            await using (var stream = new FileStream(
                             temporaryPath,
                             FileMode.CreateNew,
                             FileAccess.Write,
                             FileShare.None,
                             4096,
                             FileOptions.WriteThrough))
            {
                await JsonSerializer.SerializeAsync(
                    stream,
                    value,
                    options,
                    cancellationToken);
                await stream.FlushAsync(cancellationToken);
            }
            File.Move(temporaryPath, fullPath, true);
        }
        finally
        {
            if (File.Exists(temporaryPath))
                File.Delete(temporaryPath);
        }
    }
}
