using Reqnroll;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.CLDC.Pages;

namespace ToscaArtifactAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "Commercial Lines Duck Creek - GL Smoke Test")]
public sealed class GLSmokeTestStepDefinitions
{
    private readonly GLSmokeTestFlowPage _flow;

    public GLSmokeTestStepDefinitions(GLSmokeTestFlowPage flow)
    {
        _flow = flow ?? throw new ArgumentNullException(nameof(flow));
    }

    [Then("^I establish the application, policy, rating\\-state, and effective\\-date information$")]
    public Task Step01_ApplicationSetupAsync() =>
        _flow.ApplicationSetupAsync();

}
