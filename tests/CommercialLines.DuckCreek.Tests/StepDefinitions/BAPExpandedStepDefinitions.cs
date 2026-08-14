using Reqnroll;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.CLDC.Pages;

namespace ToscaArtifactAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "Commercial Lines Duck Creek - BAP Expanded")]
public sealed class BAPExpandedStepDefinitions
{
    private readonly BAPExpandedFlowPage _flow;

    public BAPExpandedStepDefinitions(BAPExpandedFlowPage flow)
    {
        _flow = flow ?? throw new ArgumentNullException(nameof(flow));
    }

    [When("^I create the insured client and establish the account$")]
    public Task Step01_ClientAndAccountAsync() =>
        _flow.ClientAndAccountAsync();

    [When("^I establish the application, policy, rating\\-state, and effective\\-date information$")]
    public Task Step02_ApplicationSetupAsync() =>
        _flow.ApplicationSetupAsync();

    [When("^I select and verify the required policy and risk coverages$")]
    public Task Step03_CoveragesAsync() =>
        _flow.CoveragesAsync();

    [When("^I add and complete all required locations, risks, classes, buildings, or scheduled items$")]
    public Task Step04_RiskDetailsAsync() =>
        _flow.RiskDetailsAsync();

    [When("^I add the applicable interests and endorsements$")]
    public Task Step05_InterestsAndEndorsementsAsync() =>
        _flow.InterestsAndEndorsementsAsync();

    [When("^I complete underwriting questions and resolve decision checks$")]
    public Task Step06_UnderwritingAsync() =>
        _flow.UnderwritingAsync();

    [When("^I calculate and verify the policy premium$")]
    public Task Step07_PricingAsync() =>
        _flow.PricingAsync();

    [Then("^I submit the application and complete the bind, issue, or transmit workflow$")]
    public Task Step08_SubmissionAsync() =>
        _flow.SubmissionAsync();

}
