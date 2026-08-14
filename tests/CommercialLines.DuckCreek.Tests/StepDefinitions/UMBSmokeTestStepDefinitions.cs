using Reqnroll;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.CLDC.Pages;

namespace ToscaArtifactAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "Commercial Lines Duck Creek - UMB Smoke Test")]
public sealed class UMBSmokeTestStepDefinitions
{
    private readonly UMBSmokeTestFlowPage _flow;

    public UMBSmokeTestStepDefinitions(UMBSmokeTestFlowPage flow)
    {
        _flow = flow ?? throw new ArgumentNullException(nameof(flow));
    }

    [Then("^I establish the application, policy, rating\\-state, and effective\\-date information$")]
    public Task Step01_ApplicationSetupAsync() =>
        _flow.ApplicationSetupAsync();

}
