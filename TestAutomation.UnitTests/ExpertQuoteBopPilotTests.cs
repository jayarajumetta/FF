using NUnit.Framework;
using PnCTestAutomation.Artifacts;
using PnCTestAutomation.BusinessOutcomes;
using PnCTestAutomation.Controls;
using PnCTestAutomation.DataProfiles;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Models;
using PnCTestAutomation.Pages.ExpertQuotePages.BOP;
using PnCTestAutomation.Products;
using PnCTestAutomation.QuoteHandoffs;
using PnCTestAutomation.Workflows;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class ExpertQuoteBopPilotTests
{
    private string _root = null!;

    [SetUp]
    public void SetUp()
    {
        _root = Path.Combine(
            Path.GetTempPath(),
            "PnCTestAutomation.EqBopPilot",
            Guid.NewGuid().ToString("N"));
    }

    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(_root))
            Directory.Delete(_root, recursive: true);
    }

    [Test]
    public void SelectorMapIsTestIdFirstAndEveryIdFallbackIsDocumented()
    {
        var descriptor = new ExpertQuoteBopPilotModule().Descriptor;
        var fallbackReferences = ExpertQuoteBopPilotControls.All
            .SelectMany(control => control.Selectors)
            .Where(selector =>
                selector.Kind == ControlSelectorKind.AniHtmlId)
            .Select(selector => selector.ExceptionReference)
            .ToArray();

        Assert.Multiple(() =>
        {
            Assert.That(
                ExpertQuoteBopPilotControls.All.All(control =>
                    control.Selectors[0].Kind ==
                    ControlSelectorKind.TestId),
                Is.True);
            Assert.That(
                fallbackReferences,
                Is.SubsetOf(descriptor.SelectorExceptionReferences));
            Assert.That(
                ExpertQuoteBopPilotControls.Product.Selectors[0].ExactText,
                Is.EqualTo("Business Owners"));
            Assert.That(
                ExpertQuoteBopPilotControls.MaritalStatus
                    .Selectors[0].ExactText,
                Is.EqualTo("Married"));
        });
    }

    [Test]
    public void PilotControlAdapterRequestsSemanticPostconditions()
    {
        var resolver = new RecordingResolver();
        var actions = new RecordingActions();
        var page = new ExpertQuoteBopPilotPage(
            resolver,
            actions,
            (_, _) => Task.CompletedTask);
        var data = Data();

        Assert.That(
            async () => await page.ApplyAccountAddressAsync(data),
            Throws.Nothing);
        Assert.That(
            async () => await page.StartProposalAsync(data),
            Throws.TypeOf<PilotWorkflowBlockedException>()
                .With.Message.Contains("prefill-result"));

        Assert.Multiple(() =>
        {
            Assert.That(
                actions.Operations,
                Does.Contain("select:Account state:Alabama"));
            Assert.That(
                actions.Operations,
                Does.Contain("selected:Owner marital status"));
            Assert.That(
                actions.Operations,
                Does.Contain("toggle:Individually owned DBA:True"));
            Assert.That(
                actions.Operations,
                Does.Contain("selected:Business Owners product"));
            Assert.That(
                actions.Operations,
                Does.Contain("fill:Agent PC code:D2102"));
            Assert.That(
                resolver.ResolvedScopes,
                Has.All.EqualTo("page 1 main frame"));
        });
    }

    [Test]
    public async Task QuoteRoundTripUsesScenarioHandoffAndUniqueEvidence()
    {
        var artifacts = Artifacts();
        artifacts.Require(
            ArtifactKind.Screenshot,
            ArtifactKind.QuoteHandoff);
        var runtime = new FakePilotRuntime("01999999", "01999999");
        var verifier = new RecordingOutcomeVerifier();
        var workflow = new ExpertQuoteBopPilotWorkflow(
            new FixedPilotDataContext(DataResolution()),
            runtime,
            new ScenarioQuoteHandoff(new ScenarioContextData()),
            verifier,
            artifacts,
            new ArtifactCaptureService(artifacts));

        await workflow.CaptureAndCloseQuoteAsync();
        await workflow.RetrieveAndVerifyQuoteAsync();
        var manifest = artifacts.Complete(false);
        var screenshots = manifest.Artifacts
            .Where(record => record.Kind == ArtifactKind.Screenshot)
            .ToArray();
        var manifestJson = File.ReadAllText(
            Path.Combine(artifacts.ScenarioRoot, "manifest.json"));

        Assert.Multiple(() =>
        {
            Assert.That(verifier.Expected, Is.EqualTo("01999999"));
            Assert.That(verifier.Actual, Is.EqualTo("01999999"));
            Assert.That(runtime.RetrievedIdentity, Is.EqualTo("01999999"));
            Assert.That(screenshots, Has.Length.EqualTo(2));
            Assert.That(
                screenshots.Select(record => record.RelativePath),
                Is.Unique);
            Assert.That(
                manifest.Artifacts.Count(record =>
                    record.Kind == ArtifactKind.QuoteHandoff),
                Is.EqualTo(1));
            Assert.That(manifestJson, Does.Not.Contain("01999999"));
        });
    }

    [Test]
    public void QuoteRoundTripFailsOnIdentityMismatch()
    {
        var artifacts = Artifacts("mismatch");
        var workflow = new ExpertQuoteBopPilotWorkflow(
            new FixedPilotDataContext(DataResolution()),
            new FakePilotRuntime("01999999", "01888888"),
            new ScenarioQuoteHandoff(new ScenarioContextData()),
            new RecordingOutcomeVerifier(),
            artifacts,
            new ArtifactCaptureService(artifacts));

        Assert.That(
            async () =>
            {
                await workflow.CaptureAndCloseQuoteAsync();
                await workflow.RetrieveAndVerifyQuoteAsync();
            },
            Throws.TypeOf<BusinessOutcomeException>());
    }

    private ArtifactContext Artifacts(string scenario = "round-trip") =>
        new(
            new ArtifactOptions
            {
                RootPath = _root,
                ProfileName = "eq-bop-pilot"
            },
            "run",
            scenario,
            automationId: "EQ-BOP-SMOKE:AL",
            testIdentity: "ExpertQuoteBopAlPilot");

    private static ExpertQuoteBopPilotData Data() =>
        ExpertQuoteBopPilotData.From(DataResolution());

    private static PilotDataResolution DataResolution()
    {
        var values = new Dictionary<string, string>
        {
            ["client.firstName"] = "Approved",
            ["client.lastName"] = "Automation",
            ["client.dateOfBirth"] = "08/13/2004",
            ["client.phone"] = "5550100000",
            ["client.email"] = "approved@example.invalid",
            ["client.ssn"] = "000000000",
            ["account.maritalStatus"] = "Married",
            ["address.line1"] = "Approved QA Address",
            ["address.city"] = "Muscle Shoals",
            ["address.stateName"] = "Alabama",
            ["address.stateCode"] = "AL",
            ["address.zip"] = "35661",
            ["address.receivedMail"] = "true",
            ["address.isResidence"] = "true",
            ["proposal.product"] = "Business Owners",
            ["proposal.businessType"] = "Individual",
            ["proposal.dbaName"] = "Approved QA Business",
            ["proposal.effectiveDate"] = "10/01/2026",
            ["proposal.useAccountAddress"] = "true",
            ["proposal.lessorsRiskExposure"] = "No",
            ["proposal.ratingState"] = "ALABAMA",
            ["proposal.agentCode"] = "D2102",
            ["prefill.expectedOutcome"] = "No match",
            ["navigation.target"] = "PreQualification",
            ["quote.identityPattern"] = "^[0-9]{8}$"
        };
        return new PilotDataResolution(
            new PilotDataProfile
            {
                ProfileId = "eq-bop-al-smoke",
                ModuleId = "expertquote-bop-al-pilot",
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

    private sealed class FakePilotRuntime(
        string capturedIdentity,
        string retrievedIdentity) : IExpertQuoteBopPilotRuntime
    {
        public string? RetrievedIdentity { get; private set; }

        public Task ApplyClientIdentityAsync(
            ExpertQuoteBopPilotData data,
            CancellationToken cancellationToken = default) =>
            Task.CompletedTask;

        public Task ApplyAccountAddressAsync(
            ExpertQuoteBopPilotData data,
            CancellationToken cancellationToken = default) =>
            Task.CompletedTask;

        public Task StartProposalAsync(
            ExpertQuoteBopPilotData data,
            CancellationToken cancellationToken = default) =>
            Task.CompletedTask;

        public Task<string> CaptureAndCloseQuoteAsync(
            CancellationToken cancellationToken = default) =>
            Task.FromResult(capturedIdentity);

        public Task<string> RetrieveQuoteAsync(
            string quoteIdentity,
            CancellationToken cancellationToken = default)
        {
            RetrievedIdentity = quoteIdentity;
            return Task.FromResult(retrievedIdentity);
        }

        public Task CaptureScreenshotAsync(
            string path,
            CancellationToken cancellationToken = default) =>
            File.WriteAllBytesAsync(path, [1, 2, 3], cancellationToken);
    }

    private sealed class RecordingOutcomeVerifier : IBusinessOutcomeVerifier
    {
        public string? Expected { get; private set; }
        public string? Actual { get; private set; }

        public Task VerifyQuoteIdentityAsync(
            string authoritativeIdentity,
            string actualIdentity,
            string checkpoint)
        {
            Expected = authoritativeIdentity;
            Actual = actualIdentity;
            if (!authoritativeIdentity.Equals(
                    actualIdentity,
                    StringComparison.Ordinal))
            {
                throw new BusinessOutcomeException(
                    "quote identity",
                    "mismatch");
            }
            return Task.CompletedTask;
        }

        public Task<decimal> VerifyPremiumAsync(string rawPremium) =>
            throw new NotSupportedException();

        public Task VerifyFormsContractAsync(
            FormsBaselineSnapshot baseline,
            FormsResponseMetadata metadata,
            string requestedManuscript,
            string requestedPrintJob) =>
            throw new NotSupportedException();

        public Task VerifyTransmissionAvailabilityAsync(
            TransmissionAvailability availability) =>
            throw new NotSupportedException();

        public Task VerifyTransmissionResultAsync(
            TransmissionResult result,
            string authoritativeIdentity) =>
            throw new NotSupportedException();
    }

    private sealed class RecordingResolver : IControlScopeResolver
    {
        public List<string> ResolvedScopes { get; } = [];

        public Task<ResolvedControl> ResolveAsync(
            ControlDefinition definition,
            TimeSpan? timeout = null,
            CancellationToken cancellationToken = default)
        {
            var scope = new ControlScope(
                "page 1 main frame",
                0,
                0,
                true);
            ResolvedScopes.Add(scope.Description);
            return Task.FromResult(new ResolvedControl(
                definition,
                definition.Selectors[0],
                scope,
                new StubElement()));
        }

        public async Task<ResolvedControl?> TryResolveAsync(
            ControlDefinition definition,
            TimeSpan? timeout = null,
            CancellationToken cancellationToken = default) =>
            await ResolveAsync(definition, timeout, cancellationToken);
    }

    private sealed class RecordingActions : ISemanticControlActions
    {
        public List<string> Operations { get; } = [];

        public Task ClickAsync(
            ResolvedControl control,
            ControlExpectation? postcondition = null,
            CancellationToken cancellationToken = default)
        {
            Operations.Add(
                postcondition?.Assertion == ControlAssertion.Selected
                    ? $"selected:{control.Definition.Name}"
                    : $"click:{control.Definition.Name}");
            return Task.CompletedTask;
        }

        public Task FillAsync(
            ResolvedControl control,
            string value,
            CancellationToken cancellationToken = default)
        {
            Operations.Add($"fill:{control.Definition.Name}:{value}");
            return Task.CompletedTask;
        }

        public Task SelectAsync(
            ResolvedControl control,
            string value,
            CancellationToken cancellationToken = default)
        {
            Operations.Add($"select:{control.Definition.Name}:{value}");
            return Task.CompletedTask;
        }

        public Task ToggleAsync(
            ResolvedControl control,
            bool isChecked,
            CancellationToken cancellationToken = default)
        {
            Operations.Add(
                $"toggle:{control.Definition.Name}:{isChecked}");
            return Task.CompletedTask;
        }

        public Task AssertAsync(
            ResolvedControl control,
            ControlExpectation expectation,
            CancellationToken cancellationToken = default) =>
            Task.CompletedTask;
    }

    private sealed class StubElement : IControlElement
    {
        public Task ScrollIntoViewAsync(
            CancellationToken cancellationToken = default) =>
            Task.CompletedTask;
        public Task ClickAsync(
            CancellationToken cancellationToken = default) =>
            Task.CompletedTask;
        public Task FillAsync(
            string value,
            CancellationToken cancellationToken = default) =>
            Task.CompletedTask;
        public Task SelectAsync(
            string value,
            CancellationToken cancellationToken = default) =>
            Task.CompletedTask;
        public Task SetCheckedAsync(
            bool value,
            CancellationToken cancellationToken = default) =>
            Task.CompletedTask;
        public Task<bool> IsCheckedAsync(
            CancellationToken cancellationToken = default) =>
            Task.FromResult(false);
        public Task<bool> IsEnabledAsync(
            CancellationToken cancellationToken = default) =>
            Task.FromResult(true);
        public Task<bool> IsSelectedAsync(
            CancellationToken cancellationToken = default) =>
            Task.FromResult(false);
        public Task<string> GetValueAsync(
            CancellationToken cancellationToken = default) =>
            Task.FromResult("");
        public Task<string> GetSelectedValueAsync(
            CancellationToken cancellationToken = default) =>
            Task.FromResult("");
    }
}
