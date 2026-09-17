using System;
using System.Linq;
using System.Threading.Tasks;
using PnCTestAutomation.Artifacts;
using PnCTestAutomation.Services;
using Reqnroll;

namespace PnCTestAutomation.StepDefinitions.SFPSteps
{
    [Binding]
    public sealed class FormsValidationSmokeSteps
    {
        private readonly IFormsOrchestrationService _formsOrchestrator;
        private string _quoteNumber = string.Empty;
        private string _state = string.Empty;
        private string _lob = string.Empty;

        public FormsValidationSmokeSteps(
            IFormsOrchestrationService formsOrchestrator)
        {
            _formsOrchestrator = formsOrchestrator;
        }

        [Given(@"I have an existing quote ""(.*)"" in state ""(.*)"" for LOB ""(.*)""")]
        public void GivenIHaveAnExistingQuote(
            string quoteNumber,
            string state,
            string lob)
        {
            _quoteNumber = quoteNumber;
            _state = state;
            _lob = lob;
            Console.WriteLine(
                $"Preparing forms validation for state {state}, LOB {lob}.");
        }

        [When(@"I extract the DuckCreek session via CLAS cookie")]
        public Task WhenIExtractTheSessionViaCLASCookie() =>
            _formsOrchestrator.PrepareSessionAsync(_quoteNumber);

        [Then(@"the forms should match the baseline")]
        public async Task ThenTheFormsShouldMatchTheBaseline()
        {
            var result = await _formsOrchestrator.ValidateAsync(
                new FormsValidationRequest(
                    _quoteNumber,
                    _state,
                    _lob,
                    "BASIC"));
            var report = result.Evidence.Single(
                artifact => artifact.Kind == ArtifactKind.FormsHtml);
            Console.WriteLine(
                $"[FormsValidation] Validation passed. Report: {report.RelativePath}");
        }
    }
}
