using Reqnroll;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.PLDC.Pages;

namespace ToscaArtifactAutomation.PLDC.StepDefinitions;

[Binding, Scope(Feature = "Personal Lines Duck Creek - Smoke Test RV")]
public sealed class SmokeTestRVStepDefinitions
{
    private readonly SmokeTestRVFlowPage _flow;

    public SmokeTestRVStepDefinitions(SmokeTestRVFlowPage flow)
    {
        _flow = flow ?? throw new ArgumentNullException(nameof(flow));
    }

    [When("^I create the insured client and establish the account$")]
    public Task Step01_ClientAndAccountAsync() =>
        _flow.ClientAndAccountAsync();

    [When("^I start the proposal using the selected product, state, effective date, and producer$")]
    public Task Step02_ProposalStartAsync() =>
        _flow.ProposalStartAsync();

    [Then("^I retrieve and verify the resulting quote, policy, and transaction status$")]
    public Task Step03_VerificationAsync() =>
        _flow.VerificationAsync();

}
