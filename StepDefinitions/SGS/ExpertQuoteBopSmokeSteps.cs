#nullable enable
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
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
using static Microsoft.Playwright.Assertions;

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
    private IControlScopeResolver? _resolver;
    private IPage Page => context.Page ?? throw new InvalidOperationException("The scenario-owned page is unavailable.");
    private IControlScopeResolver Resolver => _resolver ??= new ControlScopeResolver(
        new PlaywrightControlRuntime(Page,
        [
            new FrameScopeHint { ScopeId = ExpertQuoteBopSmokeInputs.MainScope, PageIndex = 0, IsMainFrame = true }
        ]));

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
    public async Task CreateClient()
    {
        await controls.ClickAsync(await Resolve("new-quote-button"));
        var client = new NewClientPage(Page);
        await client.WaitForFirstNameInputAsync();
        await client.FillFirstNameAsync(state.Client.FirstName);
        await client.FillLastNameAsync(state.Client.LastName);
        await client.FillDOBAsync(state.Client.DateOfBirth);
        await client.VerifyClientDetailsAsync(state.Client.FirstName, state.Client.LastName, state.Client.DateOfBirth);
        await client.ClickSearchAsync();
        await client.ClickCreateNewClientAsync();
        await client.ClickNextAsync();
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Account Information", Exact = true }))
            .ToBeVisibleAsync();
    }

    [When("I enter the client account and address information")]
    public async Task EnterAccount()
    {
        var account = new AccountOwnerInfoPage(Page);
        await account.WaitForPageReadyAsync();
        await account.ValidateAndFillNameFieldsAsync(state);
        await controls.FillAsync(await Resolve("owner.name.middle"), "");
        await account.ValidateAndFillContactFieldsAsync(state);
        await SelectChip("owner.maritalStatus-chip-item-wrapper", "Married");
        await account.FillAddressFieldsAsync(state);
        await controls.AssertAsync(await Resolve("owner.address.state"),
            ControlExpectation.SelectedText(state.Address.State.ToUpperInvariant()));
        await SelectChip("owner.address.resided90days-chip-item-wrapper", "Yes");
        await SelectChip("owner.address.useAsResidence-chip-item-wrapper", "Yes");
        await account.VerifyAddressAndIdentityAsync(state);
        artifacts.RecordComponentOutcome("sgs-account-inputs", true);
        await RecordAsync("account-inputs-applied", new { identityMatched = true, addressMatched = true, maritalStatus = "Married", state = "AL" });
        await account.ClickNextAsync();
    }

    [When("I start the configured policy proposal")]
    public async Task StartProposal()
    {
        var proposal = new QuoteDetailsPage(Page);
        await Expect(Page.GetByText("Proposal Details", new() { Exact = true })).ToBeVisibleAsync();
        await SelectChip("proposal.product-chip-label", "Business Owners");
        await controls.ToggleAsync(await Resolve("business.isIndividualDba"), true);
        await controls.FillAsync(await Resolve("business.individualDba"), state.Business.DBAName);
        await proposal.EnterAndVerifyEffectiveDateAsync(state.Policy.EffectiveDate);
        await controls.ToggleAsync(await Resolve("proposal.riskAddressSelection-0"), true);
        await SelectChip("proposal.LessorsRiskExposure-chip-wrapper", "No");
        await controls.SelectByLabelAsync(await Resolve("proposal.ratingState"), state.Policy.RatingState.ToUpperInvariant());
        await controls.FillAsync(await Resolve("proposal.agentPC"), state.Policy.AgentCode);
        await Page.GetByTestId("proposal.agentPC").PressAsync("Tab");
        await Page.GetByTestId("proposal.agentPC").PressAsync("Tab");
        await controls.AssertAsync(await Resolve("proposal.agentPC"), ControlExpectation.Value(state.Policy.AgentCode));
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
        await controls.ActivateAsync(await Resolve("startQuote"));
    }

    [When("I enter the insured social security number and handle any prefill result")]
    public async Task EnterSsn()
    {
        await new QuoteDetailsPage(Page).HandleSSNPopupsAsync(state);
        await new QuoteDetailsPage(Page).HandleClientExistsPopupAsync();
    }

    [When("I navigate to the required policy screen")]
    public async Task NavigateToPolicy()
    {
        await controls.ClickAsync(await Resolve("PreQualification-nav"));
        await VerifyPolicyScreen();
    }

    [When("I capture the quote identity and close the current quote")]
    public async Task CaptureAndClose()
    {
        var identity = await new ClientSearchPage(Page).ReadActiveQuoteIdentityAsync();
        quoteHandoff.Publish(identity);
        await RecordAsync("quote-captured", new { identityHash = Hash(identity) });
        await new ClientSearchPage(Page).CloseActiveQuoteAsync();
    }

    [When("I retrieve the quote and verify its identity")]
    public async Task RetrieveAndVerify()
    {
        var expected = quoteHandoff.Require(nameof(RetrieveAndVerify)).QuoteNumber;
        await controls.FillAsync(await Resolve("quoteSearchInput"), expected);
        await controls.ClickAsync(await Resolve("quoteSearchButton"));
        await controls.ClickAsync(await Resolve("PreQualification-nav"));
        await VerifyPolicyScreen();
        var actual = await new ClientSearchPage(Page).ReadActiveQuoteIdentityAsync();
        var matches = string.Equals(expected, actual, StringComparison.Ordinal);
        artifacts.RecordComponentOutcome("sgs-quote-identity", matches);
        await RecordAsync("quote-retrieved", new { expectedIdentityHash = Hash(expected), actualIdentityHash = Hash(actual), matched = matches });
        if (!matches)
            throw new InvalidOperationException("The reopened quote does not match the scenario-owned quote identity.");
    }

    private async Task VerifyPolicyScreen()
    {
        var heading = Page.GetByRole(AriaRole.Heading, new() { NameRegex = new Regex("^PreQualification", RegexOptions.IgnoreCase) });
        var keepGoing = Page.GetByTestId("btnConfirmYes");
        await Expect(heading.Or(keepGoing).First).ToBeVisibleAsync();
        if (await keepGoing.IsVisibleAsync())
            await controls.ActivateAsync(await Resolve("btnConfirmYes"));
        await Expect(heading).ToBeVisibleAsync();
    }

    private Task<ResolvedControl> Resolve(string testId) =>
        Resolver.ResolveAsync(ControlDefinition.ByTestId(testId, testId).InScope(ExpertQuoteBopSmokeInputs.MainScope));

    private async Task SelectChip(string testId, string text)
    {
        var control = await Resolver.ResolveAsync(ControlDefinition.ByTestIdWithExactText(testId, testId, text.ToUpperInvariant())
            .InScope(ExpertQuoteBopSmokeInputs.MainScope));
        await controls.ClickAsync(control, ControlExpectation.Selected());
    }

    private Task<ArtifactRecord> RecordAsync(string checkpoint, object details) =>
        capture.CaptureAsync(ArtifactKind.BusinessOutcome, checkpoint, ".json",
            path => File.WriteAllTextAsync(path, JsonSerializer.Serialize(details)));

    private static string Hash(string value) => Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(value)));
}
