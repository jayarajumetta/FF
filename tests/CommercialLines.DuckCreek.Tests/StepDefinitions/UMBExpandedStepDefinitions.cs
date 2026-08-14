using Reqnroll;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.CLDC.Pages;

namespace ToscaArtifactAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "Commercial Lines Duck Creek - UMB Expanded")]
public sealed class UMBExpandedStepDefinitions
{
    private readonly UMBExpandedFlowPage _flow;

    public UMBExpandedStepDefinitions(UMBExpandedFlowPage flow)
    {
        _flow = flow ?? throw new ArgumentNullException(nameof(flow));
    }

    [When("^I create the insured client and establish the account$")]
    public Task Step01_ClientAndAccountAsync() =>
        _flow.ClientAndAccountAsync();

    [Then("^I establish the application, policy, rating\\-state, and effective\\-date information$")]
    public Task Step02_ApplicationSetupAsync() =>
        _flow.ApplicationSetupAsync();

}
