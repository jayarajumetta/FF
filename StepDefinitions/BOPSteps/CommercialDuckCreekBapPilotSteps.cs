#nullable enable
using System.Threading.Tasks;
using PnCTestAutomation.DataProfiles;
using PnCTestAutomation.Workflows;
using Reqnroll;

namespace PnCTestAutomation.StepDefinitions.BOPSteps
{
    [Binding]
    public sealed class CommercialDuckCreekBapPilotSteps
    {
        private readonly IPilotDataContext _data;
        private readonly ICommercialDuckCreekBapPilotWorkflow _workflow;

        public CommercialDuckCreekBapPilotSteps(
            IPilotDataContext data,
            ICommercialDuckCreekBapPilotWorkflow workflow)
        {
            _data = data;
            _workflow = workflow;
        }

        [Given("the approved Commercial DuckCreek BAP pilot profile for Alabama")]
        public void GivenTheApprovedPilotProfile() =>
            _ = CommercialDuckCreekBapPilotData.From(_data.Require());

        [When("I start the BAP quote and apply the approved Alabama selections")]
        public Task WhenIStartTheQuoteAndApplyApprovedSelections() =>
            _workflow.ApplyIntendedInputsAsync();

        [When("I verify the returned insured identity is masked")]
        public Task WhenIVerifyTheMaskedIdentity() =>
            _workflow.VerifyMaskedIdentityAsync();

        [When("I capture a valid quote description and insurance score reference")]
        public Task WhenICaptureBusinessCheckpoints() =>
            _workflow.CaptureBusinessCheckpointsAsync();

        [When("I save the quote and capture its authoritative identity")]
        public Task WhenISaveAndCaptureTheQuote() =>
            _workflow.SaveAndCaptureQuoteAsync();

        [Then("searching and reopening the quote preserves its identity and description")]
        public Task ThenSearchAndReopenPreservesTheQuote() =>
            _workflow.SearchReopenAndVerifyAsync();
    }
}
