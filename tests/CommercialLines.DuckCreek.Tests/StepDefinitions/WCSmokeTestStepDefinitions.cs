using Reqnroll;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.CLDC.Pages;

namespace ToscaArtifactAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "Commercial Lines Duck Creek - WC Smoke Test")]
public sealed class WCSmokeTestStepDefinitions
{
    private readonly WCSmokeTestFlowPage _flow;

    public WCSmokeTestStepDefinitions(WCSmokeTestFlowPage flow)
    {
        _flow = flow ?? throw new ArgumentNullException(nameof(flow));
    }

    [Then("^I establish the application, policy, rating\\-state, and effective\\-date information$")]
    public Task Step01_ApplicationSetupAsync() =>
        _flow.ApplicationSetupAsync();

}
