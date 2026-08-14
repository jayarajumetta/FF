using Reqnroll;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.PLDC.Pages;

namespace ToscaArtifactAutomation.PLDC.StepDefinitions;

[Binding, Scope(Feature = "Personal Lines Duck Creek - Cycle Rate Filings Policy 3 NB Prior Eff Date")]
public sealed class CycleRateFilingsPolicy3NBPriorEffDateStepDefinitions
{
    private readonly CycleRateFilingsPolicy3NBPriorEffDateFlowPage _flow;

    public CycleRateFilingsPolicy3NBPriorEffDateStepDefinitions(CycleRateFilingsPolicy3NBPriorEffDateFlowPage flow)
    {
        _flow = flow ?? throw new ArgumentNullException(nameof(flow));
    }

    [When("^I create the insured client and establish the account$")]
    public Task Step01_ClientAndAccountAsync() =>
        _flow.ClientAndAccountAsync();

    [When("^I start the proposal using the selected product, state, effective date, and producer$")]
    public Task Step02_ProposalStartAsync() =>
        _flow.ProposalStartAsync();

    [When("^I complete prequalification and resolve eligibility messages$")]
    public Task Step03_PreQualificationAsync() =>
        _flow.PreQualificationAsync();

    [When("^I add and validate the required driver information$")]
    public Task Step04_DriverInformationAsync() =>
        _flow.DriverInformationAsync();

    [When("^I add and validate the required vehicle or unit information$")]
    public Task Step05_VehicleInformationAsync() =>
        _flow.VehicleInformationAsync();

    [When("^I assign each driver to the applicable vehicle$")]
    public Task Step06_DriverAssignmentAsync() =>
        _flow.DriverAssignmentAsync();

    [When("^I complete claims, violations, and prior\\-insurance information$")]
    public Task Step07_ClaimsAndViolationsAsync() =>
        _flow.ClaimsAndViolationsAsync();

    [When("^I apply and validate the eligible discounts$")]
    public Task Step08_DiscountsAsync() =>
        _flow.DiscountsAsync();

    [When("^I select and verify the required policy and risk coverages$")]
    public Task Step09_CoveragesAsync() =>
        _flow.CoveragesAsync();

    [When("^I verify pricing and complete billing or payment selections$")]
    public Task Step10_PricingAndBillingAsync() =>
        _flow.PricingAndBillingAsync();

    [When("^I submit the application and complete the bind, issue, or transmit workflow$")]
    public Task Step11_SubmissionAsync() =>
        _flow.SubmissionAsync();

    [Then("^I retrieve and verify the resulting quote, policy, and transaction status$")]
    public Task Step12_VerificationAsync() =>
        _flow.VerificationAsync();

}
