using Reqnroll;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.CLEQ.Pages;

namespace ToscaArtifactAutomation.CLEQ.StepDefinitions;

[Binding, Scope(Feature = "Commercial Lines ExpertQuote - EQ BOP Basic Policy")]
public sealed class EQBOPBasicPolicyStepDefinitions
{
    private readonly EQBOPBasicPolicyFlowPage _flow;

    public EQBOPBasicPolicyStepDefinitions(EQBOPBasicPolicyFlowPage flow)
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

    [When("^I complete the required policy\\-level business information$")]
    public Task Step04_PolicyDetailsAsync() =>
        _flow.PolicyDetailsAsync();

    [When("^I select and verify the required policy and risk coverages$")]
    public Task Step05_CoveragesAsync() =>
        _flow.CoveragesAsync();

    [When("^I verify pricing and complete billing or payment selections$")]
    public Task Step06_PricingAndBillingAsync() =>
        _flow.PricingAndBillingAsync();

    [When("^I submit the application and complete the bind, issue, or transmit workflow$")]
    public Task Step07_SubmissionAsync() =>
        _flow.SubmissionAsync();

    [Then("^I retrieve and verify the resulting quote, policy, and transaction status$")]
    public Task Step08_VerificationAsync() =>
        _flow.VerificationAsync();

}
