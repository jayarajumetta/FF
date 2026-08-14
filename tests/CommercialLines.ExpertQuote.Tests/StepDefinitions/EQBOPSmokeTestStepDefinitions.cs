using Reqnroll;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.CLEQ.Pages;

namespace ToscaArtifactAutomation.CLEQ.StepDefinitions;

[Binding, Scope(Feature = "Commercial Lines ExpertQuote - EQ BOP Smoke Test")]
public sealed class EQBOPSmokeTestStepDefinitions
{
    private readonly EQBOPSmokeTestFlowPage _flow;

    public EQBOPSmokeTestStepDefinitions(EQBOPSmokeTestFlowPage flow)
    {
        _flow = flow ?? throw new ArgumentNullException(nameof(flow));
    }

    [When("^I create the insured client and establish the account$")]
    public Task Step01_ClientAndAccountAsync() =>
        _flow.ClientAndAccountAsync();

    [When("^I start the proposal using the selected product, state, effective date, and producer$")]
    public Task Step02_ProposalStartAsync() =>
        _flow.ProposalStartAsync();

    [When("^I complete insured identity validation and handle any prefill result$")]
    public Task Step03_IdentityAndPrefillAsync() =>
        _flow.IdentityAndPrefillAsync();

    [When("^I complete prequalification and resolve eligibility messages$")]
    public Task Step04_PreQualificationAsync() =>
        _flow.PreQualificationAsync();

    [Then("^I retrieve and verify the resulting quote, policy, and transaction status$")]
    public Task Step05_VerificationAsync() =>
        _flow.VerificationAsync();

}
