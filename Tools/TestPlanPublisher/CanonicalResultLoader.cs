using System.Security.Cryptography;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;

namespace PnCTestAutomation.TestPlanPublisher;

public sealed class CanonicalResultLoader
{
    private const long MaxPublishableAttachmentBytes = 4 * 1024 * 1024;

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public IReadOnlyList<CanonicalReportResult> LoadReportResults(string canonicalResultPath)
    {
        var document = ReadResultDocument(canonicalResultPath);
        XNamespace trx = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010";
        IReadOnlyList<CanonicalReportResult> results;
        if (document.Root?.Name == trx + "TestRun")
        {
            var root = document.Root;
            var containers = root.Elements(trx + "Results").ToArray();
            if (containers.Length != 1)
                throw new TestPlanPublicationException("The canonical TRX requires one executed Results element.");
            var elements = containers[0].Elements(trx + "UnitTestResult").ToArray();
            results = elements.Select(element => ReadTrxResult(element, reporting: true)).ToArray();
            ValidateReportIdentities(results);
            var summaries = root.Elements(trx + "ResultSummary").ToArray();
            if (summaries.Length != 1 || summaries[0].Elements(trx + "Counters").Count() != 1)
                throw new TestPlanPublicationException("The canonical TRX requires final execution counters.");
            var summary = summaries[0];
            var counters = summary.Element(trx + "Counters")!;
            RequireCounter(counters, "total", results.Count);
            RequireCounter(counters, "executed", results.Count(item => item.Outcome != CanonicalReportOutcome.Skipped));
            RequireCounter(counters, "passed", results.Count(item => item.Outcome == CanonicalReportOutcome.Passed));
            RequireCounter(counters, "failed", elements.Count(item => (string?)item.Attribute("outcome") == "Failed"));
            RequireCounter(counters, "notExecuted", results.Count(item => item.Outcome == CanonicalReportOutcome.Skipped));
            foreach (var (counter, outcome) in new[] { ("error", "Error"), ("timeout", "Timeout"), ("aborted", "Aborted") })
                RequireCounter(counters, counter, elements.Count(item => (string?)item.Attribute("outcome") == outcome), optionalZero: true);
            foreach (var counter in new[] { "inProgress", "pending", "inconclusive", "notRunnable", "disconnected", "passedButRunAborted" })
                RequireCounter(counters, counter, 0, optionalZero: true);
            var summaryOutcome = (string?)summary.Attribute("outcome");
            var failed = results.Any(item => item.Outcome == CanonicalReportOutcome.Failed);
            if (summaryOutcome is not ("Passed" or "Failed" or "Completed" or "NotExecuted") ||
                summaryOutcome == "Passed" && failed ||
                summaryOutcome == "Failed" && !failed ||
                summaryOutcome == "NotExecuted" && results.Any(item => item.Outcome != CanonicalReportOutcome.Skipped) ||
                summary.Descendants(trx + "ErrorInfo").Any() ||
                summary.Descendants(trx + "RunInfo").Any(item =>
                    (string?)item.Attribute("outcome") is "Error" or "Failed" or "Aborted"))
                throw new TestPlanPublicationException(
                    "The canonical TRX run outcome or setup/teardown diagnostics disagree with its individual test results.");
        }
        else if (document.Root?.Name == "test-run")
        {
            var root = document.Root;
            var cases = root.Descendants("test-case").ToArray();
            results = cases.Select(ReadNUnitResult).ToArray();
            ValidateReportIdentities(results);
            RequireCounter(root, "total", results.Count);
            RequireCounter(root, "passed", results.Count(item => item.Outcome == CanonicalReportOutcome.Passed));
            RequireCounter(root, "failed", results.Count(item => item.Outcome == CanonicalReportOutcome.Failed));
            RequireCounter(root, "skipped", cases.Count(item => (string?)item.Attribute("result") == "Skipped"));
            RequireCounter(root, "inconclusive", cases.Count(item => (string?)item.Attribute("result") == "Inconclusive"), optionalZero: true);
            if (root.Attribute("testcasecount") != null)
                RequireCounter(root, "testcasecount", results.Count);
            _ = ReadNUnitDuration(root);
            ValidateNUnitContainer(root);
            foreach (var suite in root.Descendants("test-suite"))
                ValidateNUnitContainer(suite);
        }
        else
        {
            throw new TestPlanPublicationException("Canonical input must be an actual TRX TestRun or NUnit test-run.");
        }
        return results;
    }

    public TestPlanPublicationBatch Load(
        string packageRoot,
        string resultsRoot,
        string catalogPath,
        string environment,
        string browser)
    {
        var package = ReadJson<PackageManifest>(
            SafeFile(packageRoot, "package-manifest.json"),
            "package manifest");
        var result = ReadJson<ResultManifest>(
            SafeFile(resultsRoot, "result-manifest.json"),
            "result manifest");
        var catalog = ReadJson<TestPlanMappingCatalog>(
            Path.GetFullPath(catalogPath),
            "mapping catalog");

        ValidateText(environment, nameof(environment));
        ValidateText(browser, nameof(browser));
        if (package.SchemaVersion != 1 ||
            string.IsNullOrWhiteSpace(package.PackageVersion) ||
            string.IsNullOrWhiteSpace(package.Commit?.Sha) ||
            string.IsNullOrWhiteSpace(package.Build?.Id))
        {
            throw new TestPlanPublicationException(
                "The package manifest identity is incomplete.");
        }
        if (result.SchemaVersion != 1 ||
            !result.PackageVersion.Equals(
                package.PackageVersion,
                StringComparison.Ordinal) ||
            !result.Commit.Equals(package.Commit.Sha, StringComparison.Ordinal) ||
            !result.BuildId.Equals(package.Build.Id, StringComparison.Ordinal) ||
            result.Expected <= 0 ||
            result.Expected != result.Discovered ||
            result.Expected != result.Executed ||
            result.Passed + result.Failed != result.Executed)
        {
            throw new TestPlanPublicationException(
                "The canonical result manifest disagrees with package or execution counts.");
        }

        var finalTrx = SafeFile(resultsRoot, result.FinalTrx);
        RequireChecksum(finalTrx, result.FinalTrxSha256, "canonical TRX");
        var trxResults = ReadTrx(finalTrx);
        if (trxResults.Count != result.Executed)
        {
            throw new TestPlanPublicationException(
                "Canonical TRX count disagrees with the result manifest.");
        }

        var attachments = ValidateAttachments(resultsRoot, result.Attachments);
        var artifactManifests = attachments
            .Where(item => Path.GetFileName(item.RelativePath)
                .Equals("manifest.json", StringComparison.OrdinalIgnoreCase))
            .Select(item => new
            {
                Attachment = item,
                Manifest = ReadJson<ScenarioArtifactManifest>(
                    item.AbsolutePath,
                    "scenario artifact manifest")
            })
            .ToArray();
        if (artifactManifests.Length != result.EvidenceManifests)
        {
            throw new TestPlanPublicationException(
                "Scenario manifest count disagrees with the canonical result manifest.");
        }

        var selectedArtifacts = new Dictionary<string, (
            PublicationAttachment Attachment,
            ScenarioArtifactManifest Manifest)>(StringComparer.Ordinal);
        foreach (var trxResult in trxResults)
        {
            var candidates = artifactManifests
                .Where(item => string.Equals(
                    item.Manifest.TestIdentity,
                    trxResult.TestIdentity,
                    StringComparison.Ordinal))
                .ToArray();
            var retry = candidates
                .Where(item => HasPathSegment(item.Attachment.RelativePath, "retry"))
                .ToArray();
            var selected = retry.Length > 0 ? retry : candidates
                .Where(item => HasPathSegment(item.Attachment.RelativePath, "initial"))
                .ToArray();
            if (selected.Length != 1)
            {
                throw new TestPlanPublicationException(
                    $"Test '{trxResult.TestIdentity}' does not have exactly one canonical scenario manifest.");
            }
            if (selected[0].Manifest.Version != 2)
            {
                throw new TestPlanPublicationException(
                    $"Test '{trxResult.TestIdentity}' has an unsupported artifact manifest version.");
            }
            var artifactOutcome = ParseArtifactOutcome(selected[0].Manifest.Outcome);
            if (artifactOutcome != trxResult.Outcome)
            {
                throw new TestPlanPublicationException(
                    $"Outcome parity failed for '{trxResult.TestIdentity}'.");
            }
            if (string.IsNullOrWhiteSpace(selected[0].Manifest.AutomationId))
            {
                throw new TestPlanPublicationException(
                    $"Test '{trxResult.TestIdentity}' has no stable automation ID.");
            }
            if (!selectedArtifacts.TryAdd(
                    trxResult.TestIdentity,
                    (selected[0].Attachment, selected[0].Manifest)))
            {
                throw new TestPlanPublicationException(
                    $"Test identity '{trxResult.TestIdentity}' is ambiguous.");
            }
        }

        var knownIdentities = trxResults
            .Select(item => item.TestIdentity)
            .ToHashSet(StringComparer.Ordinal);
        if (artifactManifests.Any(item =>
                !knownIdentities.Contains(item.Manifest.TestIdentity)))
        {
            throw new TestPlanPublicationException(
                "Scenario evidence contains an execution absent from the canonical TRX.");
        }

        var requiredIds = selectedArtifacts.Values
            .Select(item => item.Manifest.AutomationId)
            .ToArray();
        var duplicateAutomationIds = requiredIds
            .GroupBy(value => value, StringComparer.Ordinal)
            .Where(group => group.Count() > 1)
            .Select(group => group.Key)
            .ToArray();
        if (duplicateAutomationIds.Length > 0)
        {
            throw new TestPlanPublicationException(
                $"Canonical executions contain duplicate automation IDs: {string.Join(", ", duplicateAutomationIds)}.");
        }
        var mappings = catalog.Validate(requiredIds);
        var executions = new List<CanonicalTestExecution>();
        foreach (var trxResult in trxResults)
        {
            var artifact = selectedArtifacts[trxResult.TestIdentity];
            var automationId = artifact.Manifest.AutomationId;
            var mapping = mappings[automationId];

            var scenarioDirectory = Path.GetDirectoryName(
                artifact.Attachment.RelativePath)!.Replace('\\', '/');
            var scenarioAttachments = attachments
                .Where(item =>
                    item.RelativePath.Equals(
                        artifact.Attachment.RelativePath,
                        StringComparison.OrdinalIgnoreCase) ||
                    item.RelativePath.StartsWith(
                        scenarioDirectory + "/",
                        StringComparison.OrdinalIgnoreCase))
                .Select(item => ClassifyAttachment(
                    item,
                    scenarioDirectory,
                    artifact.Manifest))
                .ToArray();
            var identityHashes = ReadIdentityHashes(
                scenarioAttachments,
                artifact.Manifest);
            executions.Add(new CanonicalTestExecution(
                automationId,
                trxResult.TestIdentity,
                trxResult.Outcome,
                trxResult.Duration,
                mapping,
                identityHashes,
                scenarioAttachments));
        }

        var planIds = executions
            .Select(item => item.Mapping.PlanId)
            .Distinct()
            .ToArray();
        if (planIds.Length != 1)
        {
            throw new TestPlanPublicationException(
                "One canonical shard publication must target exactly one Azure DevOps plan.");
        }
        var correlationKey = Hash(
            string.Join(
                "|",
                package.PackageVersion,
                package.Commit.Sha,
                package.Build.Id,
                catalog.CatalogVersion,
                catalog.Checksum.ToUpperInvariant(),
                environment.Trim().ToLowerInvariant(),
                browser.Trim().ToLowerInvariant(),
                result.Shard,
                string.Join(
                    ",",
                    executions
                        .Select(item => item.AutomationId)
                        .OrderBy(value => value, StringComparer.Ordinal)),
                string.Join(
                    ",",
                    executions
                        .SelectMany(item => item.Attachments)
                        .Where(item => item.UploadPermitted)
                        .Select(item => item.IdempotencyKey)
                        .OrderBy(value => value, StringComparer.Ordinal))));

        return new TestPlanPublicationBatch(
            correlationKey,
            package.PackageVersion,
            package.Commit.Sha,
            package.Build.Id,
            catalog.CatalogVersion,
            catalog.Checksum.ToUpperInvariant(),
            environment.Trim(),
            browser.Trim(),
            result.Shard,
            planIds[0],
            executions);
    }

    private static IReadOnlyList<PublicationAttachment> ValidateAttachments(
        string resultsRoot,
        IReadOnlyList<ResultAttachment> declared)
    {
        var duplicates = declared
            .GroupBy(item => item.Path, StringComparer.OrdinalIgnoreCase)
            .Where(group => group.Count() > 1)
            .Select(group => group.Key)
            .ToArray();
        if (duplicates.Length > 0)
        {
            throw new TestPlanPublicationException(
                $"Duplicate result attachments: {string.Join(", ", duplicates)}.");
        }

        return declared.Select(item =>
        {
            var path = SafeFile(resultsRoot, item.Path);
            var info = new FileInfo(path);
            if (info.Length != item.Size)
            {
                throw new TestPlanPublicationException(
                    $"Attachment size mismatch for '{item.Path}'.");
            }
            RequireChecksum(path, item.Sha256, $"attachment '{item.Path}'");
            return new PublicationAttachment(
                item.Path.Replace('\\', '/'),
                path,
                item.Size,
                item.Sha256.ToUpperInvariant(),
                false);
        }).ToArray();
    }

    private static IReadOnlyList<TrxResult> ReadTrx(string path)
    {
        var document = ReadResultDocument(path);
        XNamespace ns =
            "http://microsoft.com/schemas/VisualStudio/TeamTest/2010";
        var results = document
            .Descendants(ns + "UnitTestResult")
            .Select(element => ReadTrxResult(element, reporting: false))
            .Select(result => new TrxResult(result.TestIdentity,
                result.Outcome == CanonicalReportOutcome.Passed
                    ? CanonicalTestOutcome.Passed : CanonicalTestOutcome.Failed,
                result.Duration))
            .ToArray();
        if (results.Length == 0)
            throw new TestPlanPublicationException(
                "The canonical TRX contains zero test results.");
        if (results.GroupBy(item => item.TestIdentity, StringComparer.Ordinal)
            .Any(group => group.Count() > 1))
        {
            throw new TestPlanPublicationException(
                "The canonical TRX contains duplicate test identities.");
        }
        return results;
    }

    private static XDocument ReadResultDocument(string path)
    {
        try
        {
            using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var reader = XmlReader.Create(stream, new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Prohibit,
                XmlResolver = null,
                MaxCharactersInDocument = 100 * 1024 * 1024
            });
            return XDocument.Load(reader, LoadOptions.None);
        }
        catch (Exception exception) when (exception is XmlException or IOException or UnauthorizedAccessException)
        {
            throw new TestPlanPublicationException("The canonical execution result is missing, empty or malformed.");
        }
    }

    private static CanonicalReportResult ReadTrxResult(XElement element, bool reporting)
    {
        var name = (string?)element.Attribute("testName") ?? "";
        var outcomeText = (string?)element.Attribute("outcome") ?? "";
        var outcome = outcomeText switch
        {
            "Passed" => CanonicalReportOutcome.Passed,
            "Failed" => CanonicalReportOutcome.Failed,
            "NotExecuted" when reporting => CanonicalReportOutcome.Skipped,
            "Error" or "Timeout" or "Aborted" when reporting => CanonicalReportOutcome.Failed,
            _ => throw new TestPlanPublicationException($"Canonical TRX contains non-final outcome '{outcomeText}'.")
        };
        var durationText = (string?)element.Attribute("duration");
        if (!TimeSpan.TryParse(durationText, reporting ? CultureInfo.InvariantCulture : CultureInfo.CurrentCulture, out var duration) ||
            reporting && duration < TimeSpan.Zero)
            throw new TestPlanPublicationException($"Canonical TRX duration is invalid for '{name}'.");
        if (string.IsNullOrWhiteSpace(name))
            throw new TestPlanPublicationException("Canonical TRX contains an unnamed test.");
        var ns = element.Name.Namespace;
        var error = element.Element(ns + "Output")?.Element(ns + "ErrorInfo");
        if (reporting && outcome != CanonicalReportOutcome.Failed && error != null)
            throw new TestPlanPublicationException("A non-failed canonical TRX test contains failure diagnostics.");
        if (reporting)
            ValidateWindow(element, "startTime", "endTime");
        return new CanonicalReportResult(name, outcome, duration,
            error == null ? null : string.Join("\n", error.Elements().Select(item => item.Value)));
    }

    private static CanonicalReportResult ReadNUnitResult(XElement element)
    {
        var name = (string?)element.Attribute("fullname");
        if (string.IsNullOrWhiteSpace(name))
            throw new TestPlanPublicationException("A canonical NUnit case requires its full identity.");
        var outcome = (string?)element.Attribute("result") switch
        {
            "Passed" => CanonicalReportOutcome.Passed,
            "Failed" => CanonicalReportOutcome.Failed,
            "Skipped" or "Inconclusive" => CanonicalReportOutcome.Skipped,
            _ => throw new TestPlanPublicationException("Canonical NUnit contains a non-final test result.")
        };
        if (outcome != CanonicalReportOutcome.Failed && element.Element("failure") != null)
            throw new TestPlanPublicationException("A non-failed canonical NUnit case contains failure diagnostics.");
        ValidateWindow(element, "start-time", "end-time");
        var diagnostic = element.Element("failure") ?? element.Element("reason");
        return new CanonicalReportResult(name, outcome, ReadNUnitDuration(element),
            diagnostic == null ? null : string.Join("\n", diagnostic.Elements().Select(item => item.Value)));
    }

    private static TimeSpan ReadNUnitDuration(XElement element)
    {
        if (!double.TryParse((string?)element.Attribute("duration"),
                NumberStyles.Float, CultureInfo.InvariantCulture, out var seconds) ||
            !double.IsFinite(seconds) || seconds < 0 || seconds >= TimeSpan.MaxValue.TotalSeconds)
            throw new TestPlanPublicationException("Canonical NUnit duration is invalid.");
        return TimeSpan.FromSeconds(seconds);
    }

    private static void ValidateNUnitContainer(XElement element)
    {
        var cases = element.Descendants("test-case").ToArray();
        if (cases.Length == 0)
        {
            if ((string?)element.Attribute("result") == "Failed" || element.Element("failure") != null)
                throw new TestPlanPublicationException("A canonical NUnit suite has a setup/teardown failure with no executed cases.");
            return;
        }
        var failed = cases.Any(item => (string?)item.Attribute("result") == "Failed");
        var passed = cases.Any(item => (string?)item.Attribute("result") == "Passed");
        var outcome = (string?)element.Attribute("result");
        if (outcome is not ("Passed" or "Failed" or "Skipped" or "Inconclusive") ||
            outcome == "Failed" && !failed ||
            outcome == "Passed" && (failed || element.Element("failure") != null) ||
            outcome is "Skipped" or "Inconclusive" && (passed || failed))
            throw new TestPlanPublicationException(
                "A canonical NUnit run/suite has setup, teardown or outcome failures inconsistent with its test cases.");
    }

    private static void ValidateReportIdentities(IReadOnlyList<CanonicalReportResult> results)
    {
        if (results.Count == 0)
            throw new TestPlanPublicationException("The canonical input contains zero executed test results.");
        if (results.GroupBy(item => item.TestIdentity, StringComparer.Ordinal).Any(group => group.Count() != 1))
            throw new TestPlanPublicationException("The canonical input contains duplicate test identities.");
    }

    private static void RequireCounter(XElement element, string name, int expected, bool optionalZero = false)
    {
        var value = (string?)element.Attribute(name);
        if (value == null && optionalZero && expected == 0)
            return;
        if (!int.TryParse(value, NumberStyles.None, CultureInfo.InvariantCulture, out var actual) || actual != expected)
            throw new TestPlanPublicationException($"Canonical '{name}' counter disagrees with the actual test results.");
    }

    private static void ValidateWindow(XElement element, string startName, string endName)
    {
        var startText = (string?)element.Attribute(startName);
        var endText = (string?)element.Attribute(endName);
        if (startText == null && endText == null)
            return;
        if (!DateTimeOffset.TryParse(startText, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var start) ||
            !DateTimeOffset.TryParse(endText, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var end) ||
            end < start)
            throw new TestPlanPublicationException("Canonical result timestamps are missing or reversed.");
    }

    private static CanonicalTestOutcome ParseArtifactOutcome(JsonElement value)
    {
        if (value.ValueKind == JsonValueKind.Number &&
            value.TryGetInt32(out var numeric))
        {
            return numeric switch
            {
                0 => CanonicalTestOutcome.Passed,
                1 => CanonicalTestOutcome.Failed,
                _ => throw new TestPlanPublicationException(
                    $"Invalid artifact outcome '{numeric}'.")
            };
        }
        if (value.ValueKind == JsonValueKind.String)
        {
            return value.GetString() switch
            {
                "Passed" => CanonicalTestOutcome.Passed,
                "Failed" => CanonicalTestOutcome.Failed,
                var other => throw new TestPlanPublicationException(
                    $"Invalid artifact outcome '{other}'.")
            };
        }
        throw new TestPlanPublicationException("Invalid artifact outcome.");
    }

    private static bool IsSafeAttachment(
        string relativePath,
        string scenarioDirectory,
        ScenarioArtifactManifest manifest)
    {
        if (Path.GetFileName(relativePath).Equals(
                "manifest.json",
                StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }
        var itemPath = relativePath[(scenarioDirectory.Length + 1)..];
        var record = manifest.Artifacts.SingleOrDefault(item =>
            item.RelativePath?.Replace('\\', '/').Equals(
                itemPath,
                StringComparison.OrdinalIgnoreCase) == true);
        return record?.Kind is 8 or 9 or 10;
    }

    private static IReadOnlyList<string> ReadIdentityHashes(
        IReadOnlyList<PublicationAttachment> attachments,
        ScenarioArtifactManifest manifest)
    {
        var businessPaths = manifest.Artifacts
            .Where(item => item.Kind == 8 && item.RelativePath != null)
            .Select(item => item.RelativePath!)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);
        var hashes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var attachment in attachments.Where(item =>
                     businessPaths.Any(path =>
                         item.RelativePath.EndsWith(
                             path.Replace('\\', '/'),
                             StringComparison.OrdinalIgnoreCase))))
        {
            using var document = JsonDocument.Parse(
                File.ReadAllText(attachment.AbsolutePath));
            CollectIdentityHashes(document.RootElement, hashes);
        }
        return hashes.OrderBy(value => value, StringComparer.Ordinal).ToArray();
    }

    private static void CollectIdentityHashes(
        JsonElement element,
        ISet<string> hashes)
    {
        if (element.ValueKind == JsonValueKind.Object)
        {
            foreach (var property in element.EnumerateObject())
            {
                if (property.Name.EndsWith(
                        "IdentityHash",
                        StringComparison.OrdinalIgnoreCase) &&
                    property.Value.ValueKind == JsonValueKind.String &&
                    property.Value.GetString() is { } value &&
                    value.Length == 64 &&
                    value.All(Uri.IsHexDigit))
                {
                    hashes.Add(value.ToUpperInvariant());
                }
                else
                {
                    CollectIdentityHashes(property.Value, hashes);
                }
            }
        }
        else if (element.ValueKind == JsonValueKind.Array)
        {
            foreach (var child in element.EnumerateArray())
                CollectIdentityHashes(child, hashes);
        }
    }

    private static T ReadJson<T>(string path, string description)
    {
        try
        {
            return JsonSerializer.Deserialize<T>(
                       File.ReadAllText(path),
                       JsonOptions)
                   ?? throw new JsonException();
        }
        catch (Exception exception) when (
            exception is JsonException or IOException)
        {
            throw new TestPlanPublicationException(
                $"The {description} is missing or malformed.");
        }
    }

    private static string SafeFile(string root, string relativePath)
    {
        var rootPath = Path.GetFullPath(root)
            .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar) +
            Path.DirectorySeparatorChar;
        var path = Path.GetFullPath(
            Path.Combine(rootPath, relativePath.Replace('/', Path.DirectorySeparatorChar)));
        if (!path.StartsWith(rootPath, StringComparison.OrdinalIgnoreCase) ||
            !File.Exists(path))
        {
            throw new TestPlanPublicationException(
                $"Required canonical input '{relativePath}' is missing or unsafe.");
        }
        return path;
    }

    private static void RequireChecksum(
        string path,
        string expected,
        string description)
    {
        if (string.IsNullOrWhiteSpace(expected) ||
            !FileChecksum(path).Equals(
                expected,
                StringComparison.OrdinalIgnoreCase))
        {
            throw new TestPlanPublicationException(
                $"Checksum mismatch for {description}.");
        }
    }

    private static string FileChecksum(string path)
    {
        using var stream = new FileStream(
            path,
            FileMode.Open,
            FileAccess.Read,
            FileShare.Read,
            81920,
            FileOptions.SequentialScan);
        return Convert.ToHexString(SHA256.HashData(stream));
    }

    private static PublicationAttachment ClassifyAttachment(
        PublicationAttachment attachment,
        string scenarioDirectory,
        ScenarioArtifactManifest manifest)
    {
        var uploadPermitted = IsSafeAttachment(
            attachment.RelativePath,
            scenarioDirectory,
            manifest);
        if (uploadPermitted &&
            attachment.Size > MaxPublishableAttachmentBytes)
        {
            throw new TestPlanPublicationException(
                $"Publishable attachment '{attachment.RelativePath}' exceeds the safe size limit.");
        }
        return attachment with { UploadPermitted = uploadPermitted };
    }

    private static bool HasPathSegment(string path, string segment) =>
        path.Replace('\\', '/')
            .Split('/', StringSplitOptions.RemoveEmptyEntries)
            .Contains(segment, StringComparer.OrdinalIgnoreCase);

    private static void ValidateText(string value, string name)
    {
        if (string.IsNullOrWhiteSpace(value) ||
            value.Any(char.IsControl) ||
            value.Length > 100)
        {
            throw new TestPlanPublicationException(
                $"{name} is missing or invalid.");
        }
    }

    internal static string Hash(string value) => Convert.ToHexString(
        SHA256.HashData(Encoding.UTF8.GetBytes(value)));

    private sealed class PackageManifest
    {
        public int SchemaVersion { get; init; }
        public string PackageVersion { get; init; } = "";
        public PackageCommit? Commit { get; init; }
        public PackageBuild? Build { get; init; }
    }

    private sealed class PackageCommit
    {
        public string Sha { get; init; } = "";
    }

    private sealed class PackageBuild
    {
        public string Id { get; init; } = "";
    }

    private sealed class ResultManifest
    {
        public int SchemaVersion { get; init; }
        public string PackageVersion { get; init; } = "";
        public string Commit { get; init; } = "";
        public string BuildId { get; init; } = "";
        public string Shard { get; init; } = "";
        public int Expected { get; init; }
        public int Discovered { get; init; }
        public int Executed { get; init; }
        public int Passed { get; init; }
        public int Failed { get; init; }
        public string FinalTrx { get; init; } = "";
        public string FinalTrxSha256 { get; init; } = "";
        public int EvidenceManifests { get; init; }
        public List<ResultAttachment> Attachments { get; init; } = [];
    }

    private sealed class ResultAttachment
    {
        public string Path { get; init; } = "";
        public long Size { get; init; }
        public string Sha256 { get; init; } = "";
    }

    private sealed class ScenarioArtifactManifest
    {
        public int Version { get; init; }
        public string AutomationId { get; init; } = "";
        public string TestIdentity { get; init; } = "";
        public JsonElement Outcome { get; init; }
        public List<ScenarioArtifactRecord> Artifacts { get; init; } = [];
    }

    private sealed class ScenarioArtifactRecord
    {
        public int Kind { get; init; }
        public string? RelativePath { get; init; }
    }

    private sealed record TrxResult(
        string TestIdentity,
        CanonicalTestOutcome Outcome,
        TimeSpan Duration);
}
