using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using NUnit.Framework;
using PnCTestAutomation.Artifacts;
using PnCTestAutomation.TestPlanPublisher;
using PnCTestAutomation.TestPlans;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class TestPlanPublisherTests
{
    private string _root = null!;

    [SetUp]
    public void SetUp()
    {
        _root = Path.Combine(
            Path.GetTempPath(),
            "PnC-TestPlanPublisher",
            Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(_root);
    }

    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(_root))
            Directory.Delete(_root, recursive: true);
    }

    [Test]
    public void StableAutomationIdentityIsTagBasedAndRejectsAmbiguity()
    {
        var resolved = ScenarioAutomationIdentity.Resolve(
            ["Smoke"],
            ["AutomationId-SFP-BASIC-POLICY"],
            "al");

        Assert.Multiple(() =>
        {
            Assert.That(resolved, Is.EqualTo("SFP-BASIC-POLICY:AL"));
            Assert.That(
                () => ScenarioAutomationIdentity.Resolve(
                    ["AutomationId-ONE", "AutomationId-TWO"],
                    [],
                    "AL"),
                Throws.TypeOf<InvalidOperationException>()
                    .With.Message.Contains("exactly one"));
            Assert.That(
                () => ScenarioAutomationIdentity.Resolve(
                    ["AutomationId-SFP-BASIC"],
                    [],
                    null),
                Throws.TypeOf<InvalidOperationException>()
                    .With.Message.Contains("qualifier"));
        });
    }

    [Test]
    public void ArtifactManifestCarriesStableAutomationAndTestIdentity()
    {
        var context = new ArtifactContext(
            new ArtifactOptions
            {
                RootPath = _root,
                ProfileName = "unit",
                RequiredOnFailure = []
            },
            "run-1",
            "scenario-1",
            automationId: "SFP-BASIC-POLICY:AL",
            testIdentity: "SFPBasicPolicy_State(\"Alabama\",\"AL\")");

        var manifest = context.Complete(authoritativeScenarioFailed: false);

        Assert.Multiple(() =>
        {
            Assert.That(manifest.Version, Is.EqualTo(2));
            Assert.That(
                manifest.AutomationId,
                Is.EqualTo("SFP-BASIC-POLICY:AL"));
            Assert.That(
                manifest.TestIdentity,
                Is.EqualTo("SFPBasicPolicy_State(\"Alabama\",\"AL\")"));
        });
    }

    [Test]
    public void MappingCatalogRejectsInvalidDuplicateAmbiguousAndMissingEntries()
    {
        var valid = Mapping("SFP-BASIC-POLICY:AL", 101);
        var invalidId = Catalog([valid with { PlanId = 0 }]);
        var duplicate = Catalog([valid, valid]);
        var ambiguous = Catalog([
            valid,
            Mapping("SFP-BASIC-POLICY:AR", 101)
        ]);
        var missing = Catalog([valid]);

        Assert.Multiple(() =>
        {
            Assert.That(
                () => invalidId.Validate([valid.AutomationId]),
                Throws.TypeOf<TestPlanPublicationException>()
                    .With.Message.Contains("positive"));
            Assert.That(
                () => duplicate.Validate([valid.AutomationId]),
                Throws.TypeOf<TestPlanPublicationException>()
                    .With.Message.Contains("Duplicate"));
            Assert.That(
                () => ambiguous.Validate([
                    valid.AutomationId,
                    "SFP-BASIC-POLICY:AR"
                ]),
                Throws.TypeOf<TestPlanPublicationException>()
                    .With.Message.Contains("Ambiguous Azure DevOps target"));
            Assert.That(
                () => missing.Validate(["SFP-BASIC-POLICY:AZ"]),
                Throws.TypeOf<TestPlanPublicationException>()
                    .With.Message.Contains("missing gated"));
        });
    }

    [Test]
    public void MappingCatalogRejectsChecksumAndAdoTargetDrift()
    {
        var first = Mapping("SFP-BASIC-POLICY:AL", 101);
        var duplicateTarget = Mapping("SFP-BASIC-POLICY:AR", 101);
        var ambiguous = Catalog([first, duplicateTarget]);
        var stale = Catalog([first]);
        stale = new TestPlanMappingCatalog
        {
            SchemaVersion = stale.SchemaVersion,
            CatalogVersion = stale.CatalogVersion,
            Provenance = stale.Provenance,
            Checksum = new string('0', 64),
            Mappings = stale.Mappings
        };

        Assert.Multiple(() =>
        {
            Assert.That(
                () => ambiguous.Validate([
                    first.AutomationId,
                    duplicateTarget.AutomationId
                ]),
                Throws.TypeOf<TestPlanPublicationException>()
                    .With.Message.Contains("Ambiguous Azure DevOps target"));
            Assert.That(
                () => stale.Validate([first.AutomationId]),
                Throws.TypeOf<TestPlanPublicationException>()
                    .With.Message.Contains("checksum"));
        });
    }

    [Test]
    public void DeferredPilotMappingIsVisibleButCannotSatisfyAGatedRun()
    {
        var draft = new TestPlanMappingCatalog
        {
            SchemaVersion = 1,
            CatalogVersion = "1.0.0",
            Provenance = "unit-test",
            DeferredAutomationIds = ["EQ-BOP-SMOKE:AL"]
        };
        var catalog = new TestPlanMappingCatalog
        {
            SchemaVersion = draft.SchemaVersion,
            CatalogVersion = draft.CatalogVersion,
            Provenance = draft.Provenance,
            DeferredAutomationIds = draft.DeferredAutomationIds,
            Checksum = TestPlanMappingCatalog.ComputeChecksum(draft)
        };

        Assert.Multiple(() =>
        {
            Assert.That(
                () => catalog.Validate([]),
                Throws.Nothing);
            Assert.That(
                () => catalog.Validate(["EQ-BOP-SMOKE:AL"]),
                Throws.TypeOf<TestPlanPublicationException>()
                    .With.Message.Contains("explicitly deferred"));
        });
    }

    [Test]
    public void MappingCatalogRejectsDuplicateOrMappedDeferredIds()
    {
        var mapping = Mapping("EQ-BOP-SMOKE:AL", 101);
        var duplicateDraft = new TestPlanMappingCatalog
        {
            SchemaVersion = 1,
            CatalogVersion = "1.0.0",
            Provenance = "unit-test",
            DeferredAutomationIds =
            [
                "EQ-BOP-SMOKE:AL",
                "EQ-BOP-SMOKE:AL"
            ]
        };
        var overlapDraft = new TestPlanMappingCatalog
        {
            SchemaVersion = 1,
            CatalogVersion = "1.0.0",
            Provenance = "unit-test",
            Mappings = [mapping],
            DeferredAutomationIds = ["EQ-BOP-SMOKE:AL"]
        };
        var duplicate = WithChecksum(duplicateDraft);
        var overlap = WithChecksum(overlapDraft);

        Assert.Multiple(() =>
        {
            Assert.That(
                () => duplicate.Validate([]),
                Throws.TypeOf<TestPlanPublicationException>()
                    .With.Message.Contains("Duplicate deferred"));
            Assert.That(
                () => overlap.Validate([]),
                Throws.TypeOf<TestPlanPublicationException>()
                    .With.Message.Contains("both mapped and deferred"));
        });
    }

    [Test]
    public void CanonicalLoaderValidatesOneToOneParityAndSafeIdentityHashes()
    {
        var fixture = CreateCanonicalFixture();
        var batch = new CanonicalResultLoader().Load(
            fixture.PackageRoot,
            fixture.ResultsRoot,
            fixture.CatalogPath,
            "qa",
            "chromium");

        Assert.Multiple(() =>
        {
            Assert.That(batch.Executions, Has.Count.EqualTo(1));
            Assert.That(
                batch.Executions[0].AutomationId,
                Is.EqualTo(fixture.AutomationId));
            Assert.That(
                batch.Executions[0].IdentityHashes,
                Is.EqualTo(new[] { fixture.IdentityHash }));
            Assert.That(
                batch.Executions[0].Attachments.Count(item =>
                    item.UploadPermitted),
                Is.EqualTo(3));
            Assert.That(batch.CorrelationKey, Has.Length.EqualTo(64));
        });
    }

    [Test]
    public void CanonicalLoaderRejectsAttachmentTamperingAndChangesCorrelationOnMappingDrift()
    {
        var tampered = CreateCanonicalFixture();
        File.AppendAllText(tampered.BusinessEvidencePath, "tampered");
        Assert.That(
            () => new CanonicalResultLoader().Load(
                tampered.PackageRoot,
                tampered.ResultsRoot,
                tampered.CatalogPath,
                "qa",
                "chromium"),
            Throws.TypeOf<TestPlanPublicationException>()
                .With.Message.Contains("size mismatch"));

        var drifted = CreateCanonicalFixture("drift");
        var catalog = ReadCatalog(drifted.CatalogPath);
        var originalBatch = new CanonicalResultLoader().Load(
            drifted.PackageRoot,
            drifted.ResultsRoot,
            drifted.CatalogPath,
            "qa",
            "chromium");
        var mapping = catalog.Mappings[0] with { PlanId = 11 };
        WriteCatalog(drifted.CatalogPath, [mapping]);
        var changedBatch = new CanonicalResultLoader().Load(
            drifted.PackageRoot,
            drifted.ResultsRoot,
            drifted.CatalogPath,
            "qa",
            "chromium");
        Assert.That(
            changedBatch.CorrelationKey,
            Is.Not.EqualTo(originalBatch.CorrelationKey));
    }

    [Test]
    public void CanonicalLoaderSelectsRetryEvidenceWithoutPublishingAttempts()
    {
        var fixture = CreateCanonicalFixture(includeFailedInitialAttempt: true);
        var batch = new CanonicalResultLoader().Load(
            fixture.PackageRoot,
            fixture.ResultsRoot,
            fixture.CatalogPath,
            "qa",
            "chromium");

        Assert.Multiple(() =>
        {
            Assert.That(batch.Executions, Has.Count.EqualTo(1));
            Assert.That(batch.Executions[0].Outcome, Is.EqualTo(CanonicalTestOutcome.Passed));
            Assert.That(
                batch.Executions[0].Attachments.All(item =>
                    item.RelativePath.Contains(
                        "/retry/",
                        StringComparison.Ordinal)),
                Is.True);
        });
    }

    [Test]
    public void CanonicalLoaderRejectsDuplicateStableAutomationIds()
    {
        var fixture = CreateCanonicalFixture(
            "duplicate-automation",
            includeDuplicateAutomationExecution: true);

        Assert.That(
            () => new CanonicalResultLoader().Load(
                fixture.PackageRoot,
                fixture.ResultsRoot,
                fixture.CatalogPath,
                "qa",
                "chromium"),
            Throws.TypeOf<TestPlanPublicationException>()
                .With.Message.Contains("duplicate automation IDs"));
    }

    [Test]
    public async Task DryRunReplayIsIdempotentAndDoesNotCopyAttachmentContents()
    {
        var fixture = CreateCanonicalFixture();
        var batch = new CanonicalResultLoader().Load(
            fixture.PackageRoot,
            fixture.ResultsRoot,
            fixture.CatalogPath,
            "qa",
            "chromium");
        var output = Path.Combine(_root, "dry-run.json");
        var state = Path.Combine(_root, "reconciliation.json");
        var publisher = new DryRunFileTestPlanPublisher(output);

        var first = await publisher.PublishAsync(batch, state);
        var second = await publisher.PublishAsync(batch, state);
        var stateJson = File.ReadAllText(state);
        var outputJson = File.ReadAllText(output);

        Assert.Multiple(() =>
        {
            Assert.That(second.RunId, Is.EqualTo(first.RunId));
            Assert.That(second.PublishedResults, Is.EqualTo(1));
            Assert.That(
                JsonDocument.Parse(stateJson)
                    .RootElement.GetProperty("executions")
                    .EnumerateObject().Count(),
                Is.EqualTo(1));
            Assert.That(outputJson, Does.Not.Contain("sensitive-attachment"));
            Assert.That(outputJson, Does.Contain(fixture.IdentityHash));
        });
    }

    [Test]
    public void AzurePublisherRejectsUnauthorizedResponseWithoutLeakingSecrets()
    {
        const string credential = "publisher-secret-value";
        var handler = new RecordingHandler((_, _) =>
            JsonResponse(
                HttpStatusCode.Unauthorized,
                $"{{\"message\":\"{credential} response detail\"}}"));
        var publisher = CreateAzurePublisher(handler, credential);
        var exception = Assert.ThrowsAsync<TestPlanPublicationException>(
            async () => await publisher.PublishAsync(
                CreateBatch(),
                Path.Combine(_root, "unauthorized-state.json")));

        Assert.Multiple(() =>
        {
            Assert.That(exception!.Message, Does.Contain("HTTP 401"));
            Assert.That(exception.Message, Does.Not.Contain(credential));
            Assert.That(
                File.ReadAllText(
                    Path.Combine(_root, "unauthorized-state.json")),
                Does.Not.Contain(credential));
        });
    }

    [Test]
    public void AzurePublisherRejectsUntrustedOrMismatchedCredentialOrigins()
    {
        Assert.Multiple(() =>
        {
            Assert.That(
                () => new AzureDevOpsPublisherOptions
                {
                    OrganizationUrl = "https://example.invalid/collection",
                    Project = "PnC",
                    Credential = "external-secret",
                    UseBearerToken = false
                }.Validate(),
                Throws.TypeOf<TestPlanPublicationException>()
                    .With.Message.Contains("trusted Azure DevOps host"));
            Assert.That(
                () => new AzureDevOpsPublisherOptions
                {
                    OrganizationUrl = "https://dev.azure.com/intended",
                    TrustedCollectionUrl =
                        "https://dev.azure.com/different",
                    Project = "PnC",
                    Credential = "system-token",
                    UseBearerToken = true
                }.Validate(),
                Throws.TypeOf<TestPlanPublicationException>()
                    .With.Message.Contains("SYSTEM_COLLECTIONURI"));
        });
    }

    [Test]
    public async Task AzurePublisherResumesPartialUploadAndReplaysWithoutDuplicates()
    {
        var attachmentPath = Path.Combine(_root, "safe.json");
        File.WriteAllText(attachmentPath, "{}");
        var hash = Sha256(attachmentPath);
        var batch = CreateBatch(attachmentPath, hash);
        var attachmentKey = batch.Executions[0].Attachments[0].IdempotencyKey;
        var statePath = Path.Combine(_root, "partial-state.json");
        var firstHandler = new StatefulAdoHandler(attachmentKey)
        {
            FailFirstAttachment = true
        };
        var firstPublisher = CreateAzurePublisher(firstHandler, "token-one");

        Assert.That(
            async () => await firstPublisher.PublishAsync(batch, statePath),
            Throws.TypeOf<TestPlanPublicationException>()
                .With.Message.Contains("HTTP 500"));
        var partial = JsonSerializer.Deserialize<PublicationReconciliationState>(
            File.ReadAllText(statePath),
            JsonOptions())!;
        Assert.Multiple(() =>
        {
            Assert.That(partial.RunId, Is.EqualTo(41));
            Assert.That(
                partial.Executions[batch.Executions[0].AutomationId].ResultId,
                Is.EqualTo(51));
            Assert.That(partial.Completed, Is.False);
        });

        var resumeHandler = new StatefulAdoHandler(attachmentKey)
        {
            ExistingRun = true,
            ExistingResult = true
        };
        var resumed = await CreateAzurePublisher(
                resumeHandler,
                "token-two")
            .PublishAsync(batch, statePath);
        var replayed = await CreateAzurePublisher(
                resumeHandler,
                "token-two")
            .PublishAsync(batch, statePath);

        Assert.Multiple(() =>
        {
            Assert.That(resumed.RunId, Is.EqualTo(41));
            Assert.That(replayed.RunId, Is.EqualTo(41));
            Assert.That(resumeHandler.CreateRunCalls, Is.Zero);
            Assert.That(resumeHandler.CreateResultCalls, Is.Zero);
            Assert.That(resumeHandler.UploadCalls, Is.EqualTo(1));
            Assert.That(
                resumeHandler.Requests.All(request =>
                    !request.Contains("token-two", StringComparison.Ordinal)),
                Is.True);
        });
    }

    [Test]
    public void AzurePublisherRejectsRemoteOutcomeParityMismatch()
    {
        var handler = new StatefulAdoHandler("")
        {
            ExistingRun = true,
            ExistingResult = true,
            ParityOutcome = "Failed"
        };
        var exception = Assert.ThrowsAsync<TestPlanPublicationException>(
            async () => await CreateAzurePublisher(handler, "safe-token")
                .PublishAsync(
                    CreateBatch(),
                    Path.Combine(_root, "parity-state.json")));

        Assert.That(
            exception!.Message,
            Does.Contain("identity or outcome drift"));
    }

    [Test]
    public void AzurePublisherRejectsDuplicateManagedAttachments()
    {
        var attachmentPath = Path.Combine(_root, "duplicate-safe.json");
        File.WriteAllText(attachmentPath, "{}");
        var batch = CreateBatch(attachmentPath, Sha256(attachmentPath));
        var handler = new StatefulAdoHandler(
            batch.Executions[0].Attachments[0].IdempotencyKey)
        {
            ExistingRun = true,
            ExistingResult = true,
            ExistingAttachment = true,
            DuplicateAttachment = true
        };

        Assert.That(
            async () => await CreateAzurePublisher(handler, "token")
                .PublishAsync(
                    batch,
                    Path.Combine(_root, "duplicate-attachment-state.json")),
            Throws.TypeOf<TestPlanPublicationException>()
                .With.Message.Contains(
                    "duplicate publisher-managed attachments"));
    }

    [Test]
    public void TemporarySuiteScopeAlwaysCleansUp()
    {
        var manager = new FakeTemporarySuiteManager();
        var scope = new TemporaryTestSuiteScope(manager);

        Assert.That(
            async () => await scope.ExecuteAsync<int>(
                10,
                "temporary",
                _ => throw new InvalidOperationException("test failed")),
            Throws.TypeOf<InvalidOperationException>());
        Assert.Multiple(() =>
        {
            Assert.That(manager.Created, Is.True);
            Assert.That(manager.Deleted, Is.True);
        });
    }

    private CanonicalFixture CreateCanonicalFixture(
        string suffix = "default",
        bool includeFailedInitialAttempt = false,
        bool includeDuplicateAutomationExecution = false)
    {
        var packageRoot = Path.Combine(_root, suffix, "package");
        var resultsRoot = Path.Combine(_root, suffix, "results");
        Directory.CreateDirectory(packageRoot);
        Directory.CreateDirectory(Path.Combine(resultsRoot, "trx"));
        const string automationId = "SFP-BASIC-POLICY:AL";
        const string testIdentity =
            "SFPBasicPolicy_State(\"Alabama\",\"AL\")";
        const string identityHash =
            "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
        File.WriteAllText(
            Path.Combine(packageRoot, "package-manifest.json"),
            JsonSerializer.Serialize(new
            {
                schemaVersion = 1,
                packageVersion = "1.0.0",
                commit = new { sha = "abc123" },
                build = new { id = "42" }
            }));

        var finalTrx = Path.Combine(resultsRoot, "trx", "Shard-final.trx");
        var trxResults = new List<(string Identity, string Outcome)>
        {
            (testIdentity, "Passed")
        };
        var attachments = new List<object>();
        string businessEvidencePath = "";
        if (includeFailedInitialAttempt)
        {
            AddScenarioEvidence(
                resultsRoot,
                "initial",
                automationId,
                testIdentity,
                1,
                identityHash,
                attachments,
                out _);
        }
        AddScenarioEvidence(
            resultsRoot,
            includeFailedInitialAttempt ? "retry" : "initial",
            automationId,
            testIdentity,
            0,
            identityHash,
            attachments,
            out businessEvidencePath);
        if (includeDuplicateAutomationExecution)
        {
            const string duplicateTestIdentity =
                "SFPBasicPolicy_State(\"Duplicate\",\"AL\")";
            trxResults.Add((duplicateTestIdentity, "Passed"));
            AddScenarioEvidence(
                resultsRoot,
                "initial",
                automationId,
                duplicateTestIdentity,
                0,
                identityHash,
                attachments,
                out _,
                "scenario-b");
        }
        WriteTrx(finalTrx, trxResults);
        var resultCount = trxResults.Count;
        File.WriteAllText(
            Path.Combine(resultsRoot, "result-manifest.json"),
            JsonSerializer.Serialize(new
            {
                schemaVersion = 1,
                packageVersion = "1.0.0",
                commit = "abc123",
                buildId = "42",
                shard = "Basic1",
                expected = resultCount,
                discovered = resultCount,
                executed = resultCount,
                passed = resultCount,
                failed = 0,
                finalTrx = "trx/Shard-final.trx",
                finalTrxSha256 = Sha256(finalTrx),
                evidenceManifests =
                    (includeFailedInitialAttempt ? 2 : 1) +
                    (includeDuplicateAutomationExecution ? 1 : 0),
                attachments
            }));
        var catalogPath = Path.Combine(_root, suffix, "catalog.json");
        WriteCatalog(
            catalogPath,
            [Mapping(automationId, 101)]);
        return new CanonicalFixture(
            packageRoot,
            resultsRoot,
            catalogPath,
            businessEvidencePath,
            automationId,
            identityHash);
    }

    private static void AddScenarioEvidence(
        string resultsRoot,
        string attempt,
        string automationId,
        string testIdentity,
        int outcome,
        string identityHash,
        ICollection<object> attachments,
        out string businessEvidencePath,
        string scenarioDirectory = "scenario-a")
    {
        var scenarioRelative = $"evidence/{attempt}/{scenarioDirectory}";
        var scenarioRoot = Path.Combine(
            resultsRoot,
            scenarioRelative.Replace('/', Path.DirectorySeparatorChar));
        Directory.CreateDirectory(Path.Combine(scenarioRoot, "metadata"));
        Directory.CreateDirectory(Path.Combine(scenarioRoot, "business-outcomes"));
        businessEvidencePath = Path.Combine(
            scenarioRoot,
            "business-outcomes",
            "quote.json");
        File.WriteAllText(
            businessEvidencePath,
            JsonSerializer.Serialize(new
            {
                details = new
                {
                    expectedIdentityHash = identityHash
                },
                diagnostic = "sensitive-attachment"
            }));
        var timingPath = Path.Combine(scenarioRoot, "metadata", "timing.json");
        var trxMetadataPath = Path.Combine(
            scenarioRoot,
            "metadata",
            "trx.json");
        File.WriteAllText(timingPath, "{}");
        File.WriteAllText(trxMetadataPath, "{}");
        var manifestPath = Path.Combine(scenarioRoot, "manifest.json");
        File.WriteAllText(
            manifestPath,
            JsonSerializer.Serialize(new
            {
                version = 2,
                automationId,
                testIdentity,
                outcome,
                artifacts = new object[]
                {
                    new
                    {
                        kind = 8,
                        relativePath = "business-outcomes/quote.json"
                    },
                    new
                    {
                        kind = 9,
                        relativePath = "metadata/trx.json"
                    },
                    new
                    {
                        kind = 10,
                        relativePath = "metadata/timing.json"
                    }
                }
            }));
        foreach (var path in new[]
                 {
                     manifestPath,
                     businessEvidencePath,
                     timingPath,
                     trxMetadataPath
                 })
        {
            var relative = Path.GetRelativePath(resultsRoot, path)
                .Replace('\\', '/');
            attachments.Add(new
            {
                path = relative,
                size = new FileInfo(path).Length,
                sha256 = Sha256(path)
            });
        }
    }

    private static TestPlanMappingEntry Mapping(
        string automationId,
        int testCaseId) =>
        new()
        {
            AutomationId = automationId,
            PlanId = 10,
            SuiteId = 20,
            TestCaseId = testCaseId,
            ConfigurationId = 30
        };

    private static TestPlanMappingCatalog Catalog(
        List<TestPlanMappingEntry> mappings)
    {
        var draft = new TestPlanMappingCatalog
        {
            SchemaVersion = 1,
            CatalogVersion = "1.0.0",
            Provenance = "unit-test",
            Mappings = mappings
        };
        return new TestPlanMappingCatalog
        {
            SchemaVersion = draft.SchemaVersion,
            CatalogVersion = draft.CatalogVersion,
            Provenance = draft.Provenance,
            Mappings = draft.Mappings,
            Checksum = TestPlanMappingCatalog.ComputeChecksum(draft)
        };
    }

    private static TestPlanMappingCatalog WithChecksum(
        TestPlanMappingCatalog draft) =>
        new()
        {
            SchemaVersion = draft.SchemaVersion,
            CatalogVersion = draft.CatalogVersion,
            Provenance = draft.Provenance,
            Mappings = draft.Mappings,
            DeferredAutomationIds = draft.DeferredAutomationIds,
            Checksum = TestPlanMappingCatalog.ComputeChecksum(draft)
        };

    private static void WriteCatalog(
        string path,
        List<TestPlanMappingEntry> mappings)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(
            path,
            JsonSerializer.Serialize(Catalog(mappings), JsonOptions()));
    }

    private static TestPlanMappingCatalog ReadCatalog(string path) =>
        JsonSerializer.Deserialize<TestPlanMappingCatalog>(
            File.ReadAllText(path),
            JsonOptions())!;

    private static void WriteTrx(
        string path,
        string testIdentity,
        string outcome) =>
        WriteTrx(path, [(testIdentity, outcome)]);

    private static void WriteTrx(
        string path,
        IReadOnlyCollection<(string Identity, string Outcome)> results)
    {
        var resultElements = string.Join(
            Environment.NewLine,
            results.Select((result, index) =>
                $"""    <UnitTestResult testId="{index + 1}" testName="{result.Identity.Replace("&", "&amp;").Replace("\"", "&quot;")}" outcome="{result.Outcome}" duration="00:00:01.2500000" />"""));
        File.WriteAllText(
            path,
            $$"""
             <?xml version="1.0" encoding="utf-8"?>
             <TestRun xmlns="http://microsoft.com/schemas/VisualStudio/TeamTest/2010">
               <Results>
             {{resultElements}}
               </Results>
             </TestRun>
             """);
    }

    private static TestPlanPublicationBatch CreateBatch(
        string? attachmentPath = null,
        string? hash = null)
    {
        var attachments = attachmentPath == null
            ? Array.Empty<PublicationAttachment>()
            : new[]
            {
                new PublicationAttachment(
                    "metadata/safe.json",
                    attachmentPath,
                    new FileInfo(attachmentPath).Length,
                    hash!,
                    true)
            };
        return new TestPlanPublicationBatch(
            new string('A', 64),
            "1.0.0",
            "abc123",
            "42",
            "1.0.0",
            new string('B', 64),
            "qa",
            "chromium",
            "Basic1",
            10,
            [
                new CanonicalTestExecution(
                    "SFP-BASIC-POLICY:AL",
                    "SFPBasicPolicy_State(\"Alabama\",\"AL\")",
                    CanonicalTestOutcome.Passed,
                    TimeSpan.FromSeconds(1),
                    Mapping(
                        "SFP-BASIC-POLICY:AL",
                        101),
                    [],
                    attachments)
            ]);
    }

    private static AzureDevOpsRestTestPlanPublisher CreateAzurePublisher(
        HttpMessageHandler handler,
        string credential) =>
        new(
            new HttpClient(handler),
            new AzureDevOpsPublisherOptions
            {
                OrganizationUrl = "https://dev.azure.com/example",
                TrustedCollectionUrl = "https://dev.azure.com/example",
                Project = "PnC",
                Credential = credential,
                UseBearerToken = true
            });

    private static HttpResponseMessage JsonResponse(
        HttpStatusCode status,
        string json) =>
        new(status)
        {
            Content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json")
        };

    private static string Sha256(string path) =>
        Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(path)));

    private static JsonSerializerOptions JsonOptions() => new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    };

    private sealed record CanonicalFixture(
        string PackageRoot,
        string ResultsRoot,
        string CatalogPath,
        string BusinessEvidencePath,
        string AutomationId,
        string IdentityHash);

    private sealed class RecordingHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, int, HttpResponseMessage>
            _response;
        private int _count;

        public RecordingHandler(
            Func<HttpRequestMessage, int, HttpResponseMessage> response)
        {
            _response = response;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken) =>
            Task.FromResult(_response(request, _count++));
    }

    private sealed class StatefulAdoHandler : HttpMessageHandler
    {
        private readonly string _attachmentKey;
        private bool _attachmentExists;
        private int _resultParityCalls;

        public StatefulAdoHandler(string attachmentKey)
        {
            _attachmentKey = attachmentKey;
        }

        public bool FailFirstAttachment { get; init; }
        public bool ExistingRun { get; init; }
        public bool ExistingResult { get; init; }
        public bool ExistingAttachment { get; init; }
        public bool DuplicateAttachment { get; init; }
        public string ParityOutcome { get; init; } = "Passed";
        public int CreateRunCalls { get; private set; }
        public int CreateResultCalls { get; private set; }
        public int UploadCalls { get; private set; }
        public List<string> Requests { get; } = [];

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var path = request.RequestUri!.PathAndQuery;
            Requests.Add($"{request.Method} {path}");
            if (request.Method == HttpMethod.Get &&
                path.Contains("_apis/test/runs?planId=", StringComparison.Ordinal))
            {
                return JsonResponse(
                    HttpStatusCode.OK,
                    ExistingRun
                        ? """{"value":[{"id":41,"name":"PnC-Basic1-AAAAAAAAAAAAAAAA","state":"InProgress"}]}"""
                        : """{"value":[]}""");
            }
            if (request.Method == HttpMethod.Post &&
                path.Contains("_apis/test/runs?", StringComparison.Ordinal))
            {
                CreateRunCalls++;
                return JsonResponse(
                    HttpStatusCode.OK,
                    """{"id":41,"name":"PnC-Basic1-AAAAAAAAAAAAAAAA","state":"InProgress"}""");
            }
            if (request.Method == HttpMethod.Get &&
                path.Contains("/TestPoint?", StringComparison.Ordinal))
            {
                return JsonResponse(
                    HttpStatusCode.OK,
                    """{"value":[{"id":61,"testCaseReference":{"id":101},"configuration":{"id":30}}]}""");
            }
            if (request.Method == HttpMethod.Get &&
                path.EndsWith("/results?api-version=7.1", StringComparison.Ordinal))
            {
                _resultParityCalls++;
                var include = ExistingResult || _resultParityCalls > 1;
                return JsonResponse(
                    HttpStatusCode.OK,
                    include
                        ? ResultListJson(ParityOutcome)
                        : """{"value":[]}""");
            }
            if ((request.Method == HttpMethod.Post ||
                 request.Method == HttpMethod.Patch) &&
                path.EndsWith("/results?api-version=7.1", StringComparison.Ordinal))
            {
                if (request.Method == HttpMethod.Post)
                    CreateResultCalls++;
                return JsonResponse(
                    HttpStatusCode.OK,
                    ResultListJson("Passed"));
            }
            if (request.Method == HttpMethod.Get &&
                path.Contains("/attachments?", StringComparison.Ordinal))
            {
                return JsonResponse(
                    HttpStatusCode.OK,
                    _attachmentExists || ExistingAttachment
                        ? DuplicateAttachment
                            ? $$"""{"value":[{"id":71,"comment":"pnc-attachment:{{_attachmentKey}}"},{"id":72,"comment":"pnc-attachment:{{_attachmentKey}}"}]}"""
                            : $$"""{"value":[{"id":71,"comment":"pnc-attachment:{{_attachmentKey}}"}]}"""
                        : """{"value":[]}""");
            }
            if (request.Method == HttpMethod.Post &&
                path.Contains("/attachments?", StringComparison.Ordinal))
            {
                UploadCalls++;
                if (FailFirstAttachment && UploadCalls == 1)
                    return JsonResponse(
                        HttpStatusCode.InternalServerError,
                        """{"message":"sensitive response body"}""");
                _attachmentExists = true;
                return JsonResponse(
                    HttpStatusCode.OK,
                    """{"id":71,"comment":"uploaded"}""");
            }
            if (request.Method == HttpMethod.Patch &&
                path.Contains("_apis/test/runs/41?", StringComparison.Ordinal))
            {
                return JsonResponse(
                    HttpStatusCode.OK,
                    """{"id":41,"name":"PnC-Basic1-AAAAAAAAAAAAAAAA","state":"Completed"}""");
            }
            var body = request.Content == null
                ? ""
                : await request.Content.ReadAsStringAsync(cancellationToken);
            return JsonResponse(
                HttpStatusCode.BadRequest,
                JsonSerializer.Serialize(new { path, body }));
        }

        private static string ResultListJson(string outcome) =>
            JsonSerializer.Serialize(new
            {
                value = new[]
                {
                    new
                    {
                        id = 51,
                        automatedTestName = "SFP-BASIC-POLICY:AL",
                        outcome,
                        testCase = new { id = 101 },
                        configuration = new { id = 30 }
                    }
                }
            });
    }

    private sealed class FakeTemporarySuiteManager :
        ITemporaryTestSuiteManager
    {
        public bool Created { get; private set; }
        public bool Deleted { get; private set; }

        public Task<int> CreateAsync(
            int planId,
            string name,
            CancellationToken cancellationToken = default)
        {
            Created = true;
            return Task.FromResult(99);
        }

        public Task DeleteAsync(
            int planId,
            int suiteId,
            CancellationToken cancellationToken = default)
        {
            Deleted = true;
            return Task.CompletedTask;
        }
    }
}
