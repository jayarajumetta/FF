#nullable enable
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PnCTestAutomation.Controls;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Products;
using static Microsoft.Playwright.Assertions;

namespace PnCTestAutomation.Pages.ExpertQuotePages;

public sealed class ExpertQuoteBopSmokePage(IPage page, ISemanticControlActions controls) : BasePage(page)
{
    private readonly IControlScopeResolver _resolver = new ControlScopeResolver(
        new PlaywrightControlRuntime(page,
        [
            new FrameScopeHint { ScopeId = ExpertQuoteBopSmokeInputs.MainScope, PageIndex = 0, IsMainFrame = true }
        ]));

    public async Task CreateClientAsync(ScenarioContextData state)
    {
        await controls.ClickAsync(await Resolve("new-quote-button"));
        var client = new NewClientPage(_page);
        await client.WaitForFirstNameInputAsync();
        await client.FillFirstNameAsync(state.Client.FirstName);
        await client.FillLastNameAsync(state.Client.LastName);
        await client.FillDOBAsync(state.Client.DateOfBirth);
        await client.VerifyClientDetailsAsync(state.Client.FirstName, state.Client.LastName, state.Client.DateOfBirth);
        await client.ClickSearchAsync();
        await client.ClickCreateNewClientAsync();
        await client.ClickNextAsync();
        await Expect(_page.GetByRole(AriaRole.Heading, new() { Name = "Account Information", Exact = true }))
            .ToBeVisibleAsync();
    }

    public async Task EnterAccountAsync(ScenarioContextData state)
    {
        var account = new AccountOwnerInfoPage(_page);
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
    }

    public Task ContinueAccountAsync() => new AccountOwnerInfoPage(_page).ClickNextAsync();

    public async Task ApplyProposalInputsAsync(ScenarioContextData state)
    {
        var proposal = new QuoteDetailsPage(_page);
        await Expect(_page.GetByText("Proposal Details", new() { Exact = true })).ToBeVisibleAsync();
        await SelectChip("proposal.product-chip-label", "Business Owners");
        await controls.ToggleAsync(await _resolver.ResolveAsync(
            ControlDefinition.ByTestId("Individually owned DBA", "business.isIndividualDba")
                .OnElementTag("input").InScope(ExpertQuoteBopSmokeInputs.MainScope)), true);
        await controls.FillAsync(await Resolve("business.individualDba"), state.Business.DBAName);
        await proposal.EnterAndVerifyEffectiveDateAsync(state.Policy.EffectiveDate);
        await controls.ToggleAsync(await Resolve("proposal.riskAddressSelection-0"), true);
        await SelectChip("proposal.LessorsRiskExposure-chip-wrapper", "No");
        await controls.SelectByLabelAsync(await Resolve("proposal.ratingState"), state.Policy.RatingState.ToUpperInvariant());
        await controls.FillAsync(await Resolve("proposal.agentPC"), state.Policy.AgentCode);
        await _page.GetByTestId("proposal.agentPC").PressAsync("Tab");
        await _page.GetByTestId("proposal.agentPC").PressAsync("Tab");
        await controls.AssertAsync(await Resolve("proposal.agentPC"), ControlExpectation.Value(state.Policy.AgentCode));
    }

    public async Task StartQuoteAsync() => await controls.ActivateAsync(await Resolve("startQuote"));

    public async Task EnterSsnAsync(ScenarioContextData state)
    {
        await Expect(_page.GetByTestId("ssn")).ToBeVisibleAsync();
        await new QuoteDetailsPage(_page).HandleSSNPopupsAsync(state);
        await new QuoteDetailsPage(_page).HandleClientExistsPopupAsync();
    }

    public async Task GoToRequiredPolicyScreenAsync()
    {
        await controls.ClickAsync(await Resolve("PreQualification-nav"));
        var heading = _page.GetByRole(AriaRole.Heading, new() { NameRegex = new Regex("^PreQualification", RegexOptions.IgnoreCase) });
        var keepGoing = _page.GetByTestId("btnConfirmYes");
        await Expect(heading.Or(keepGoing).First).ToBeVisibleAsync();
        if (await keepGoing.IsVisibleAsync())
            await controls.ActivateAsync(await Resolve("btnConfirmYes"));
        await Expect(heading).ToBeVisibleAsync();
    }

    public Task<string> ReadQuoteIdentityAsync() => new ClientSearchPage(_page).ReadActiveQuoteIdentityAsync();

    public Task CloseQuoteAsync() => new ClientSearchPage(_page).CloseActiveQuoteAsync();

    public async Task RetrieveQuoteAsync(string identity)
    {
        await controls.FillAsync(await Resolve("quoteSearchInput"), identity);
        await controls.ClickAsync(await Resolve("quoteSearchButton"));
        await GoToRequiredPolicyScreenAsync();
    }

    private Task<ResolvedControl> Resolve(string testId) =>
        _resolver.ResolveAsync(ControlDefinition.ByTestId(testId, testId).InScope(ExpertQuoteBopSmokeInputs.MainScope));

    private async Task SelectChip(string testId, string text)
    {
        var control = await _resolver.ResolveAsync(ControlDefinition.ByTestIdWithExactText(testId, testId, text.ToUpperInvariant())
            .InScope(ExpertQuoteBopSmokeInputs.MainScope));
        await controls.ClickAsync(control, ControlExpectation.Selected());
    }
}
