using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PnCTestAutomation.Artifacts;
using PnCTestAutomation.BusinessOutcomes;
using PnCTestAutomation.QuoteHandoffs;
using PnCTestAutomation.Services;
using Reqnroll;

namespace PnCTestAutomation.StepDefinitions.SFPSteps
{
    [Binding]
    public sealed class FormsValidationSmokeSteps
    {
        private readonly IFormsOrchestrationService _formsOrchestrator;
        private readonly IBusinessOutcomeContext _businessOutcomeContext;
        private readonly IQuoteHandoff _quoteHandoff;
        private readonly IConfiguration _configuration;
        private string _quoteNumber = string.Empty;
        private string _state = string.Empty;
        private string _lob = string.Empty;

        public FormsValidationSmokeSteps(
            IFormsOrchestrationService formsOrchestrator,
            IBusinessOutcomeContext businessOutcomeContext,
            IQuoteHandoff quoteHandoff,
            IConfiguration configuration)
        {
            _formsOrchestrator = formsOrchestrator;
            _businessOutcomeContext = businessOutcomeContext;
            _quoteHandoff = quoteHandoff;
            _configuration = configuration;
        }

        [Given(@"I have an existing quote ""(.*)"" in state ""(.*)"" for LOB ""(.*)"" and company ""(.*)""")]
        public void GivenIHaveAnExistingQuote(
            string quoteNumber,
            string state,
            string lob,
            string company)
        {
            _quoteNumber = quoteNumber;
            _state = state;
            _lob = lob;
            _quoteHandoff.Publish(quoteNumber);
            _businessOutcomeContext.ConfirmApplicability(
                Environment.GetEnvironmentVariable("TEST_ENVIRONMENT")
                ?? _configuration["Environment"]
                ?? "qa",
                state,
                company);
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
