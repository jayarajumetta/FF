using Reqnroll;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.CLDC.Pages;

namespace ToscaArtifactAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "Commercial Lines Duck Creek - IM Smoke Test")]
public sealed class IMSmokeTestStepDefinitions
{
    private readonly IMSmokeTestFlowPage _flow;

    public IMSmokeTestStepDefinitions(IMSmokeTestFlowPage flow)
    {
        _flow = flow ?? throw new ArgumentNullException(nameof(flow));
    }

    [Then("^I establish the application, policy, rating\\-state, and effective\\-date information$")]
    public Task Step01_ApplicationSetupAsync() =>
        _flow.ApplicationSetupAsync();

}
