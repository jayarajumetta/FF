#nullable enable
using System.Threading.Tasks;
using PnCTestAutomation.DataProfiles;
using PnCTestAutomation.Workflows;
using Reqnroll;

namespace PnCTestAutomation.StepDefinitions.AutoSteps
{
    [Binding]
    public sealed class PersonalDuckCreekAutoPilotSteps
    {
        private readonly IPilotDataContext _data;
        private readonly IPersonalDuckCreekAutoSmokeWorkflow _smoke;
        private readonly IPersonalDuckCreekStateMaritalWorkflow _microcase;

        public PersonalDuckCreekAutoPilotSteps(
            IPilotDataContext data,
            IPersonalDuckCreekAutoSmokeWorkflow smoke,
            IPersonalDuckCreekStateMaritalWorkflow microcase)
        {
            _data = data;
            _smoke = smoke;
            _microcase = microcase;
        }

        [Given("the approved Personal DuckCreek Auto smoke profile for Arizona")]
        public void GivenTheApprovedSmokeProfile() =>
            _ = PersonalDuckCreekAutoSmokePilotData.From(
                _data.Require());

        [When("I apply the approved Arizona policy and ANG selections")]
        public Task WhenIApplyTheApprovedSmokeSelections() =>
            _smoke.ApplySelectionsAsync();

        [When("I resolve the approved conditional proposal outcomes")]
        public Task WhenIResolveConditionalProposalOutcomes() =>
            _smoke.ResolveConditionalProposalAsync();

        [When("I save the Personal Auto quote and capture its identity")]
        public Task WhenISaveAndCaptureTheQuote() =>
            _smoke.SaveAndCaptureQuoteAsync();

        [Then("searching and reopening the Personal Auto quote returns the same identity")]
        public Task ThenSearchAndReopenReturnsTheSameQuote() =>
            _smoke.SearchReopenAndVerifyAsync();

        [Given("the approved Personal DuckCreek state and marital profile for Alabama")]
        public void GivenTheApprovedStateMaritalProfile() =>
            _ = PersonalDuckCreekStateMaritalPilotData.From(
                _data.Require());

        [When("I select Alabama and Married on the actual Account Information controls")]
        public Task WhenISelectAlabamaAndMarried() =>
            _microcase.ApplyAsync();

        [Then("both exact selections remain applied before account navigation")]
        public Task ThenBothSelectionsRemainApplied() =>
            _microcase.VerifyAsync();
    }
}
