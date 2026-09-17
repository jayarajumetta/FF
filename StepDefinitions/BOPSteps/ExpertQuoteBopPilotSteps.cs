#nullable enable
using System.Threading.Tasks;
using PnCTestAutomation.DataProfiles;
using PnCTestAutomation.Workflows;
using Reqnroll;

namespace PnCTestAutomation.StepDefinitions.BOPSteps
{
    [Binding]
    public sealed class ExpertQuoteBopPilotSteps
    {
        private readonly IPilotDataContext _data;
        private readonly IExpertQuoteBopPilotWorkflow _workflow;

        public ExpertQuoteBopPilotSteps(
            IPilotDataContext data,
            IExpertQuoteBopPilotWorkflow workflow)
        {
            _data = data;
            _workflow = workflow;
        }

        [Given("the approved ExpertQuote BOP pilot profile for Alabama")]
        public void GivenTheApprovedPilotProfile() =>
            _ = ExpertQuoteBopPilotData.From(_data.Require());

        [When("I create and search for the ExpertQuote BOP pilot client")]
        public Task WhenICreateAndSearchForThePilotClient() =>
            _workflow.CreateClientAsync();

        [When("I apply the approved Alabama account and address values")]
        public Task WhenIApplyTheApprovedAccountAndAddressValues() =>
            _workflow.ApplyAccountAddressAsync();

        [When("I start the Business Owners proposal with approved selections")]
        public Task WhenIStartTheBusinessOwnersProposal() =>
            _workflow.StartProposalAsync();

        [When("I capture the quote identity and close the quote")]
        public Task WhenICaptureAndCloseTheQuote() =>
            _workflow.CaptureAndCloseQuoteAsync();

        [Then("searching by the captured quote returns the exact same identity")]
        public Task ThenSearchingReturnsTheSameQuote() =>
            _workflow.RetrieveAndVerifyQuoteAsync();
    }
}
