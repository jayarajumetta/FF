using NUnit.Framework;
using PnCTestAutomation.Artifacts;
using PnCTestAutomation.Controls;
using PnCTestAutomation.DataProfiles;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Pages.PersonalDuckCreekPages.Auto;
using PnCTestAutomation.QuoteHandoffs;
using PnCTestAutomation.Workflows;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class PersonalDuckCreekPilotTests
{
    private string _root = null!;

    [SetUp]
    public void SetUp()
    {
        _root = Path.Combine(
            Path.GetTempPath(),
            "PnCTestAutomation.PldcPilot",
            Guid.NewGuid().ToString("N"));
    }

    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(_root))
            Directory.Delete(_root, recursive: true);
    }

    [Test]
    public void CorrectedControlContractsTargetActualEnabledControls()
    {
        Assert.That(
            PersonalDuckCreekControlContracts.Validate,
            Throws.Nothing);

        Assert.Multiple(() =>
        {
            Assert.That(
                PersonalDuckCreekControlContracts.AccountState.TargetControl,
                Is.EqualTo("account-state"));
            Assert.That(
                PersonalDuckCreekControlContracts.AccountState.TargetControl,
                Is.Not.EqualTo(
                    PersonalDuckCreekControlContracts.AccountDetailsNext));
            Assert.That(
                PersonalDuckCreekControlContracts.Married.TargetControl,
                Is.EqualTo("marital-status-married"));
            Assert.That(
                PersonalDuckCreekControlContracts.Married.TargetControl,
                Is.Not.EqualTo(
                    PersonalDuckCreekControlContracts.DivorcedMaritalOption));
            Assert.That(
                PersonalDuckCreekControlContracts.All.All(contract =>
                    contract.ReadinessControl == contract.TargetControl),
                Is.True);
            Assert.That(
                PersonalDuckCreekControlContracts.All.All(contract =>
                    contract.ReadinessAssertion ==
                    ControlAssertion.Enabled),
                Is.True);
            Assert.That(
                new[]
                {
                    PersonalDuckCreekControlContracts.AccountState,
                    PersonalDuckCreekControlContracts.WritingCompany,
                    PersonalDuckCreekControlContracts.Married
                }.All(contract =>
                    contract.Postcondition ==
                    ControlAssertion.SelectedValue),
                Is.True);
        });
    }

    [Test]
    public async Task SmokeWorkflowVerifiesSelectionsConditionsAndQuoteRoundTrip()
    {
        var artifacts = Artifacts("smoke", "PLDC-AUTO-SMOKE:AZ");
        artifacts.Require(
            ArtifactKind.Screenshot,
            ArtifactKind.BusinessOutcome,
            ArtifactKind.QuoteHandoff);
        var runtime = new FakeRuntime();
        var workflow = new PersonalDuckCreekAutoSmokeWorkflow(
            new FixedPilotDataContext(SmokeResolution()),
            runtime,
            new ScenarioQuoteHandoff(new ScenarioContextData()),
            artifacts,
            new ArtifactCaptureService(artifacts));

        await workflow.ApplySelectionsAsync();
        await workflow.ResolveConditionalProposalAsync();
        await workflow.SaveAndCaptureQuoteAsync();
        await workflow.SearchReopenAndVerifyAsync();
        var manifest = artifacts.Complete(false);
        var manifestJson = File.ReadAllText(
            Path.Combine(artifacts.ScenarioRoot, "manifest.json"));

        Assert.Multiple(() =>
        {
            Assert.That(runtime.SmokeData, Is.Not.Null);
            Assert.That(runtime.RequestedQuote, Is.EqualTo("PA12345678"));
            Assert.That(
                manifest.Artifacts.Count(record =>
                    record.Kind == ArtifactKind.Screenshot),
                Is.EqualTo(4));
            Assert.That(
                manifest.Artifacts
                    .Where(record =>
                        record.Kind == ArtifactKind.Screenshot)
                    .Select(record => record.RelativePath),
                Is.Unique);
            Assert.That(manifestJson, Does.Not.Contain("111223333"));
            Assert.That(manifestJson, Does.Not.Contain("Approved Person"));
            Assert.That(manifestJson, Does.Not.Contain("PA12345678"));
        });
    }

    [TestCase("state")]
    [TestCase("company")]
    [TestCase("marital")]
    [TestCase("conditional")]
    [TestCase("save")]
    [TestCase("identity")]
    [TestCase("search")]
    [TestCase("reopen")]
    public void SmokeWorkflowFailsClosedOnOutcomeDrift(string defect)
    {
        var artifacts = Artifacts(defect, "PLDC-AUTO-SMOKE:AZ");
        var runtime = new FakeRuntime
        {
            SmokeState = defect == "state" ? "Alabama" : "Arizona",
            WritingCompany = defect == "company" ? "Other" : "ANG",
            SmokeMarital = defect == "marital" ? "Married" : "Single",
            InvalidAddressShown = defect == "conditional",
            SaveStatus = defect == "save" ? "Unknown" : "Saved",
            SavedQuote = defect == "identity" ? "invalid" : "PA12345678",
            SearchStatus = defect == "search" ? "Missing" : "Found",
            ReopenStatus = defect == "reopen" ? "Failed" : "Reopened"
        };
        var workflow = new PersonalDuckCreekAutoSmokeWorkflow(
            new FixedPilotDataContext(SmokeResolution()),
            runtime,
            new ScenarioQuoteHandoff(new ScenarioContextData()),
            artifacts,
            new ArtifactCaptureService(artifacts));

        Assert.That(
            async () =>
            {
                await workflow.ApplySelectionsAsync();
                await workflow.ResolveConditionalProposalAsync();
                await workflow.SaveAndCaptureQuoteAsync();
                await workflow.SearchReopenAndVerifyAsync();
            },
            Throws.TypeOf<PersonalDuckCreekPilotOutcomeException>());
    }

    [Test]
    public async Task MicrocaseVerifiesStateMaritalAndPageReadiness()
    {
        var artifacts = Artifacts(
            "microcase",
            "PLDC-AUTO-STATE-MARITAL:AL");
        artifacts.Require(
            ArtifactKind.Screenshot,
            ArtifactKind.BusinessOutcome);
        var runtime = new FakeRuntime();
        var workflow = new PersonalDuckCreekStateMaritalWorkflow(
            new FixedPilotDataContext(MicrocaseResolution()),
            runtime,
            artifacts,
            new ArtifactCaptureService(artifacts));

        await workflow.ApplyAsync();
        await workflow.VerifyAsync();
        var manifest = artifacts.Complete(false);

        Assert.Multiple(() =>
        {
            Assert.That(runtime.MicrocaseData, Is.Not.Null);
            Assert.That(
                manifest.Artifacts.Count(record =>
                    record.Kind == ArtifactKind.Screenshot),
                Is.EqualTo(1));
            Assert.That(
                manifest.Artifacts.Count(record =>
                    record.Kind == ArtifactKind.BusinessOutcome),
                Is.EqualTo(1));
        });
    }

    [TestCase("state")]
    [TestCase("marital")]
    [TestCase("readiness")]
    public void MicrocaseFailsClosedOnSelectionOrReadinessDrift(
        string defect)
    {
        var runtime = new FakeRuntime
        {
            AccountState = defect == "state" ? "Arizona" : "Alabama",
            AccountMarital = defect == "marital" ? "Divorced" : "Married",
            AccountPage = defect == "readiness"
                ? "Proposal"
                : "Account Information"
        };
        var artifacts = Artifacts(
            defect,
            "PLDC-AUTO-STATE-MARITAL:AL");
        var workflow = new PersonalDuckCreekStateMaritalWorkflow(
            new FixedPilotDataContext(MicrocaseResolution()),
            runtime,
            artifacts,
            new ArtifactCaptureService(artifacts));

        Assert.That(
            async () =>
            {
                await workflow.ApplyAsync();
                await workflow.VerifyAsync();
            },
            Throws.TypeOf<PersonalDuckCreekPilotOutcomeException>());
    }

    private ArtifactContext Artifacts(
        string scenario,
        string automationId) =>
        new(
            new ArtifactOptions
            {
                RootPath = _root,
                ProfileName = "pldc-pilot"
            },
            "run",
            scenario,
            automationId: automationId,
            testIdentity: scenario);

    private static PilotDataResolution SmokeResolution()
    {
        var values = CommonValues("Arizona", "AZ", "Single");
        values["proposal.product"] = "Personal Auto";
        values["proposal.effectiveDate"] = "10/01/2026";
        values["proposal.agentCode"] = "A100";
        values["proposal.writingCompany"] = "ANG";
        values["proposal.useMailingAddress"] = "true";
        values["identity.ssn"] = "111223333";
        values["conditional.invalidAddressExpected"] = "false";
        values["conditional.ssnWarningExpected"] = "false";
        values["conditional.confirmSsnExpected"] = "false";
        values["conditional.existingClientExpected"] = "false";
        values["quote.identityPattern"] = "^PA[0-9]{8}$";
        values["quote.saveExpectation"] = "Saved";
        values["quote.searchExpectation"] = "Found";
        values["quote.reopenExpectation"] = "Reopened";
        return Resolution(
            "pldc-auto-az-ang-smoke",
            "personal-duckcreek-auto-az-ang-pilot",
            values);
    }

    private static PilotDataResolution MicrocaseResolution()
    {
        var values = CommonValues("Alabama", "AL", "Married");
        values["account.pageExpectation"] = "Account Information";
        return Resolution(
            "pldc-auto-state-marital-microcase",
            "personal-duckcreek-auto-state-marital-pilot",
            values);
    }

    private static Dictionary<string, string> CommonValues(
        string stateName,
        string stateCode,
        string maritalStatus) =>
        new()
        {
            ["client.firstName"] = "Approved",
            ["client.lastName"] = "Person",
            ["client.dateOfBirth"] = "01/01/1990",
            ["client.phone"] = "5550100000",
            ["client.email"] = "approved@example.invalid",
            ["address.line1"] = "Approved QA Address",
            ["address.line2"] = "Unit 1",
            ["address.city"] = "Approved City",
            ["address.stateName"] = stateName,
            ["address.stateCode"] = stateCode,
            ["address.zip"] = "35005",
            ["account.maritalStatus"] = maritalStatus,
            ["account.residedNinetyDays"] = "true",
            ["account.isResidence"] = "true"
        };

    private static PilotDataResolution Resolution(
        string profileId,
        string moduleId,
        Dictionary<string, string> values) =>
        new(
            new PilotDataProfile
            {
                ProfileId = profileId,
                ModuleId = moduleId,
                Mode = PilotDataProfileMode.Approved
            },
            values,
            true,
            "");

    private sealed class FixedPilotDataContext(
        PilotDataResolution resolution) : IPilotDataContext
    {
        public PilotDataResolution Require() => resolution;

        public void Set(PilotDataResolution value) =>
            throw new NotSupportedException();
    }

    private sealed class FakeRuntime :
        IPersonalDuckCreekAutoPilotRuntime
    {
        public PersonalDuckCreekAutoSmokePilotData? SmokeData
            { get; private set; }
        public PersonalDuckCreekStateMaritalPilotData? MicrocaseData
            { get; private set; }
        public string SmokeState { get; init; } = "Arizona";
        public string WritingCompany { get; init; } = "ANG";
        public string SmokeMarital { get; init; } = "Single";
        public bool InvalidAddressShown { get; init; }
        public string SavedQuote { get; init; } = "PA12345678";
        public string SaveStatus { get; init; } = "Saved";
        public string SearchStatus { get; init; } = "Found";
        public string ReopenStatus { get; init; } = "Reopened";
        public string AccountState { get; init; } = "Alabama";
        public string AccountMarital { get; init; } = "Married";
        public string AccountPage { get; init; } = "Account Information";
        public string? RequestedQuote { get; private set; }

        public Task<PersonalDuckCreekPolicySelections>
            ApplySmokeSelectionsAsync(
                PersonalDuckCreekAutoSmokePilotData data,
                CancellationToken cancellationToken = default)
        {
            SmokeData = data;
            return Task.FromResult(
                new PersonalDuckCreekPolicySelections(
                    SmokeState,
                    WritingCompany,
                    SmokeMarital));
        }

        public Task<PersonalDuckCreekConditionalOutcomes>
            ResolveConditionalProposalAsync(
                PersonalDuckCreekAutoSmokePilotData data,
                CancellationToken cancellationToken = default) =>
            Task.FromResult(
                new PersonalDuckCreekConditionalOutcomes(
                    InvalidAddressShown,
                    false,
                    false,
                    false));

        public Task<PersonalDuckCreekSavedQuote> SaveQuoteAsync(
            CancellationToken cancellationToken = default) =>
            Task.FromResult(
                new PersonalDuckCreekSavedQuote(
                    SavedQuote,
                    SaveStatus));

        public Task<PersonalDuckCreekReopenedQuote>
            SearchAndReopenQuoteAsync(
                string quoteIdentity,
                CancellationToken cancellationToken = default)
        {
            RequestedQuote = quoteIdentity;
            return Task.FromResult(
                new PersonalDuckCreekReopenedQuote(
                    SavedQuote,
                    SearchStatus,
                    ReopenStatus));
        }

        public Task<PersonalDuckCreekAccountSelections>
            ApplyStateAndMaritalAsync(
                PersonalDuckCreekStateMaritalPilotData data,
                CancellationToken cancellationToken = default)
        {
            MicrocaseData = data;
            return Task.FromResult(
                new PersonalDuckCreekAccountSelections(
                    AccountState,
                    AccountMarital,
                    AccountPage));
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
