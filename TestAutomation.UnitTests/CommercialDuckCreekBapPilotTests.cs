using NUnit.Framework;
using PnCTestAutomation.Artifacts;
using PnCTestAutomation.DataProfiles;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Pages.CommercialDuckCreekPages.BAP;
using PnCTestAutomation.QuoteHandoffs;
using PnCTestAutomation.Workflows;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class CommercialDuckCreekBapPilotTests
{
    private string _root = null!;

    [SetUp]
    public void SetUp()
    {
        _root = Path.Combine(
            Path.GetTempPath(),
            "PnCTestAutomation.CldcBapPilot",
            Guid.NewGuid().ToString("N"));
    }

    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(_root))
            Directory.Delete(_root, recursive: true);
    }

    [Test]
    public async Task PilotVerifiesMaskedIdentityAndQuoteRoundTrip()
    {
        var artifacts = Artifacts();
        artifacts.Require(
            ArtifactKind.Screenshot,
            ArtifactKind.BusinessOutcome,
            ArtifactKind.QuoteHandoff);
        var runtime = new FakeRuntime();
        var workflow = new CommercialDuckCreekBapPilotWorkflow(
            new FixedPilotDataContext(DataResolution()),
            runtime,
            new ScenarioQuoteHandoff(new ScenarioContextData()),
            artifacts,
            new ArtifactCaptureService(artifacts));

        await workflow.ApplyIntendedInputsAsync();
        await workflow.VerifyMaskedIdentityAsync();
        await workflow.CaptureBusinessCheckpointsAsync();
        await workflow.SaveAndCaptureQuoteAsync();
        await workflow.SearchReopenAndVerifyAsync();
        var manifest = artifacts.Complete(false);
        var manifestJson = File.ReadAllText(
            Path.Combine(artifacts.ScenarioRoot, "manifest.json"));

        Assert.Multiple(() =>
        {
            Assert.That(runtime.AppliedData, Is.Not.Null);
            Assert.That(runtime.RequestedQuoteIdentity, Is.EqualTo("BAP0123456"));
            Assert.That(
                manifest.Artifacts.Count(record =>
                    record.Kind == ArtifactKind.Screenshot),
                Is.EqualTo(5));
            Assert.That(
                manifest.Artifacts
                    .Where(record =>
                        record.Kind == ArtifactKind.Screenshot)
                    .Select(record => record.RelativePath),
                Is.Unique);
            Assert.That(manifestJson, Does.Not.Contain("125123456"));
            Assert.That(manifestJson, Does.Not.Contain("***-**-3456"));
            Assert.That(manifestJson, Does.Not.Contain("AL_BAP_APPROVED"));
        });
    }

    [TestCase("identity")]
    [TestCase("description")]
    [TestCase("masked")]
    [TestCase("score")]
    [TestCase("save")]
    [TestCase("search")]
    [TestCase("reopen")]
    [TestCase("description-format")]
    public void PilotFailsClosedWhenAnAuthoritativeOutcomeDiffers(
        string defect)
    {
        var runtime = new FakeRuntime
        {
            MaskedIdentity = defect == "masked"
                ? "125123456"
                : "***-**-3456",
            ReopenedIdentity = defect == "identity"
                ? "BAP9999999"
                : "BAP0123456",
            ReopenedDescription = defect == "description"
                ? "AL_BAP_DIFFERENT"
                : "AL_BAP_APPROVED",
            CapturedDescription = defect == "description-format"
                ? "invalid"
                : "AL_BAP_APPROVED",
            ScoreReference = defect == "score" ? "" : "SCORE123",
            SaveStatus = defect == "save" ? "Unknown" : "Saved",
            SearchStatus = defect == "search" ? "Missing" : "Found",
            ReopenStatus = defect == "reopen" ? "Failed" : "Reopened"
        };
        var artifacts = Artifacts(defect);
        var workflow = new CommercialDuckCreekBapPilotWorkflow(
            new FixedPilotDataContext(DataResolution()),
            runtime,
            new ScenarioQuoteHandoff(new ScenarioContextData()),
            artifacts,
            new ArtifactCaptureService(artifacts));

        Assert.That(
            async () =>
            {
                await workflow.ApplyIntendedInputsAsync();
                await workflow.VerifyMaskedIdentityAsync();
                await workflow.CaptureBusinessCheckpointsAsync();
                await workflow.SaveAndCaptureQuoteAsync();
                await workflow.SearchReopenAndVerifyAsync();
            },
            Throws.TypeOf<CommercialDuckCreekPilotOutcomeException>());
    }

    private ArtifactContext Artifacts(string scenario = "round-trip") =>
        new(
            new ArtifactOptions
            {
                RootPath = _root,
                ProfileName = "cldc-bap-pilot"
            },
            "run",
            scenario,
            automationId: "CLDC-BAP-SMOKE:AL",
            testIdentity: "CommercialDuckCreekBapAlPilot");

    private static PilotDataResolution DataResolution()
    {
        var values = new Dictionary<string, string>
        {
            ["client.firstName"] = "Approved",
            ["client.middleName"] = "AL",
            ["client.lastName"] = "Automation",
            ["client.dateOfBirth"] = "09/17/1986",
            ["client.gender"] = "Male",
            ["client.phone"] = "5550100000",
            ["client.email"] = "approved@example.invalid",
            ["client.website"] = "https://example.invalid",
            ["client.insuredType"] = "Individual/Person",
            ["client.entityType"] = "Individual/Sole Proprietor",
            ["address.line1"] = "Approved QA Address",
            ["address.zip"] = "35661",
            ["contact.auditName"] = "Approved Audit",
            ["contact.auditPhone"] = "5550100001",
            ["contact.inspectionName"] = "Approved Inspection",
            ["contact.inspectionPhone"] = "5550100002",
            ["identity.ssn"] = "125123456",
            ["identity.maskedPattern"] = @"^\*{3}-\*{2}-[0-9]{4}$",
            ["policy.quickQuote"] = "false",
            ["policy.product"] = "Approved BAP",
            ["policy.effectiveDate"] = "10/01/2026",
            ["policy.yearsInBusiness"] = "6",
            ["policy.primaryState"] = "Alabama",
            ["policy.priorCoverageWithin90Days"] = "false",
            ["policy.naicsCode"] = "000000",
            ["policy.accountCredit"] = "No",
            ["policy.quoteDescriptionPattern"] = "^AL_BAP_[A-Z]+$",
            ["score.referencePattern"] = "^[A-Z0-9]{6,}$",
            ["quote.identityPattern"] = "^BAP[0-9]{7}$",
            ["quote.saveExpectation"] = "Saved",
            ["quote.searchExpectation"] = "Found",
            ["quote.reopenExpectation"] = "Reopened"
        };
        return new PilotDataResolution(
            new PilotDataProfile
            {
                ProfileId = "cldc-bap-al-smoke",
                ModuleId = "commercial-duckcreek-bap-al-pilot",
                Mode = PilotDataProfileMode.Approved
            },
            values,
            true,
            "");
    }

    private sealed class FixedPilotDataContext(
        PilotDataResolution resolution) : IPilotDataContext
    {
        public PilotDataResolution Require() => resolution;

        public void Set(PilotDataResolution value) =>
            throw new NotSupportedException();
    }

    private sealed class FakeRuntime :
        ICommercialDuckCreekBapPilotRuntime
    {
        public CommercialDuckCreekBapPilotData? AppliedData { get; private set; }
        public string MaskedIdentity { get; init; } = "***-**-3456";
        public string ReopenedIdentity { get; init; } = "BAP0123456";
        public string ReopenedDescription { get; init; } = "AL_BAP_APPROVED";
        public string CapturedDescription { get; init; } = "AL_BAP_APPROVED";
        public string ScoreReference { get; init; } = "SCORE123";
        public string SaveStatus { get; init; } = "Saved";
        public string SearchStatus { get; init; } = "Found";
        public string ReopenStatus { get; init; } = "Reopened";
        public string? RequestedQuoteIdentity { get; private set; }

        public Task ApplyIntendedInputsAsync(
            CommercialDuckCreekBapPilotData data,
            CancellationToken cancellationToken = default)
        {
            AppliedData = data;
            return Task.CompletedTask;
        }

        public Task<string> ReadMaskedIdentityAsync(
            CancellationToken cancellationToken = default) =>
            Task.FromResult(MaskedIdentity);

        public Task<CommercialDuckCreekBusinessCheckpoints>
            CaptureBusinessCheckpointsAsync(
                CancellationToken cancellationToken = default) =>
            Task.FromResult(
                new CommercialDuckCreekBusinessCheckpoints(
                    CapturedDescription,
                    ScoreReference));

        public Task<CommercialDuckCreekSavedQuote> SaveQuoteAsync(
            CancellationToken cancellationToken = default) =>
            Task.FromResult(
                new CommercialDuckCreekSavedQuote(
                    "BAP0123456",
                    SaveStatus));

        public Task<CommercialDuckCreekReopenedQuote>
            SearchAndReopenQuoteAsync(
                string quoteIdentity,
                CancellationToken cancellationToken = default)
        {
            RequestedQuoteIdentity = quoteIdentity;
            return Task.FromResult(
                new CommercialDuckCreekReopenedQuote(
                    ReopenedIdentity,
                    ReopenedDescription,
                    SearchStatus,
                    ReopenStatus));
        }

        public Task CaptureScreenshotAsync(
            string destinationPath,
            CancellationToken cancellationToken = default) =>
            File.WriteAllBytesAsync(
                destinationPath,
                [1, 2, 3],
                cancellationToken);
    }
}
