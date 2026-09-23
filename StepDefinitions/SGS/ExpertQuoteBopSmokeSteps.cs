#nullable enable
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PnCTestAutomation.Artifacts;
using PnCTestAutomation.Configuration;
using PnCTestAutomation.Context;
using PnCTestAutomation.Controls;
using PnCTestAutomation.DataProfiles;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Pages;
using PnCTestAutomation.Pages.ExpertQuotePages;
using PnCTestAutomation.Products;
using PnCTestAutomation.QuoteHandoffs;
using PnCTestAutomation.Services;
using Reqnroll;

namespace PnCTestAutomation.StepDefinitions.SGS;

[Binding, Scope(Feature = "EQ BOP Smoke Test")]
public sealed class ExpertQuoteBopSmokeSteps(
    PlaywrightContext context,
    ScenarioContextData state,
    ISgsScenarioData data,
    ISemanticControlActions controls,
    CredentialsConfig credentials,
    NavigationService navigation,
    IQuoteHandoff quoteHandoff,
    SgsExecutionCatalog catalog,
    IArtifactContext artifacts,
    IArtifactCaptureService capture)
{
    private ExpertQuoteBopSmokePage? _flow;
    private IPage Page => context.Page ?? throw new InvalidOperationException("The scenario-owned page is unavailable.");
    private ExpertQuoteBopSmokePage Flow => _flow ??= new(Page, controls);

    [Given("I open a browser session")]
    public void UseOwnedBrowser()
    {
        if (Page.IsClosed)
            throw new InvalidOperationException("The scenario-owned browser session is closed.");
    }

    [Given("test data {string} and external data {string} are loaded")]
    public async Task LoadData(string profile, string externalProfile)
    {
        var workflow = catalog.Ledger.Workflows.Single(item => item.AutomationFamily == ExpertQuoteBopSmokeInputs.AutomationFamily);
        var selected = workflow.Cases.Single(item => item.AutomationId == ExpertQuoteBopSmokeInputs.AlabamaIdentity);
        catalog.ValidateResourcePayloads(Path.Combine(AppContext.BaseDirectory, "Resources"), new(workflow, selected));
        ExpertQuoteBopSmokeInputs.Load(data, state, profile, externalProfile);
        await RecordAsync("reviewed-inputs", new
        {
            profile,
            externalProfile,
            selected.ProfileSha256,
            selected.ExternalProfileSha256,
            state = "AL",
            product = "BOP",
            effectiveDateRule = "ExecutionDate",
            effectiveDate = state.Policy.EffectiveDate,
            approval = "User-approved Alabama execution-date override, 2026-09-22"
        });
    }

    [Given("I open the configured Commercial Lines ExpertQuote application")]
    public Task OpenApplication() => navigation.GoToExpertQuoteAsync();

    [Given("I sign in to Commercial Lines ExpertQuote using configured credentials")]
    public async Task SignIn()
    {
        if (string.IsNullOrWhiteSpace(credentials.Username) || string.IsNullOrWhiteSpace(credentials.Password))
            throw new InvalidOperationException("ExpertQuote credentials are required from the existing credential provider.");
        var login = new ExpertQuoteLoginPage(Page);
        await login.LoginAsync(credentials.Username, credentials.Password);
        if (!await login.IsDashboardVisibleAsync())
            throw new InvalidOperationException("ExpertQuote did not reach its authenticated dashboard.");
    }

    [When("I create a new client and begin the quote")]
    public Task CreateClient() => Flow.CreateClientAsync(state);

    [When("I enter the client account and address information")]
    public async Task EnterAccount()
    {
        await Flow.EnterAccountAsync(state);
        artifacts.RecordComponentOutcome("sgs-account-inputs", true);
        await RecordAsync("account-inputs-applied", new { identityMatched = true, addressMatched = true, maritalStatus = "Married", state = "AL" });
        await Flow.ContinueAccountAsync();
    }

    [When("I start the configured policy proposal")]
    public async Task StartProposal()
    {
        await Flow.ApplyProposalInputsAsync(state);
        data.CaptureBuffer("EffDate", state.Policy.EffectiveDate);
        artifacts.RecordComponentOutcome("sgs-proposal-inputs", true);
        await RecordAsync("proposal-inputs-applied", new
        {
            product = "BOP",
            individualDbaChecked = true,
            accountAddressChecked = true,
            lessorsRisk = false,
            ratingState = "AL",
            effectiveDate = state.Policy.EffectiveDate,
            agentPcMatched = true
        });
        await Flow.StartQuoteAsync();
    }

    [When("I enter the insured social security number and handle any prefill result")]
    public Task EnterSsn() => Flow.EnterSsnAsync(state);

    [When("I navigate to the required policy screen")]
    public Task NavigateToPolicy() => Flow.GoToRequiredPolicyScreenAsync();

    [When("I capture the quote identity and close the current quote")]
    public async Task CaptureAndClose()
    {
        var identity = await Flow.ReadQuoteIdentityAsync();
        quoteHandoff.Publish(identity);
        await RecordAsync("quote-captured", new { identityHash = Hash(identity) });
        await Flow.CloseQuoteAsync();
    }

    [When("I retrieve the quote and verify its identity")]
    public async Task RetrieveAndVerify()
    {
        var expected = quoteHandoff.Require(nameof(RetrieveAndVerify)).QuoteNumber;
        await Flow.RetrieveQuoteAsync(expected);
        var actual = await Flow.ReadQuoteIdentityAsync();
        var matches = string.Equals(expected, actual, StringComparison.Ordinal);
        artifacts.RecordComponentOutcome("sgs-quote-identity", matches);
        await RecordAsync("quote-retrieved", new { expectedIdentityHash = Hash(expected), actualIdentityHash = Hash(actual), matched = matches });
        if (!matches)
            throw new InvalidOperationException("The reopened quote does not match the scenario-owned quote identity.");
    }

    private Task<ArtifactRecord> RecordAsync(string checkpoint, object details) =>
        capture.CaptureAsync(ArtifactKind.BusinessOutcome, checkpoint, ".json",
            path => File.WriteAllTextAsync(path, JsonSerializer.Serialize(details)));

    private static string Hash(string value) => Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(value)));
}
