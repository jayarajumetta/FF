using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright_POC.Clients;
using Playwright_POC.Helpers;
using Playwright_POC.Models;
using Playwright_POC.Parsers;
using Playwright_POC.Services;
using Reqnroll;

namespace Playwright_POC.StepDefinitions.SFPSteps
{
    [Binding]
    public class FormsValidationSmokeSteps
    {
        private readonly SessionService _sessionService;
        private readonly DuckCreekFormsClient _formsClient;
        private readonly FormsValidationService _validationService;

        private string _quoteNumber;
        private string _state;
        private string _lob;
        private string _sessionId;
        private System.Collections.Generic.List<string> _clasApiCalls;

        public FormsValidationSmokeSteps(
            SessionService sessionService,
            DuckCreekFormsClient formsClient,
            FormsValidationService validationService)
        {
            _sessionService = sessionService;
            _formsClient = formsClient;
            _validationService = validationService;
        }

        [Given(@"I have an existing quote ""(.*)"" in state ""(.*)"" for LOB ""(.*)""")]
        public void GivenIHaveAnExistingQuote(string quoteNumber, string state, string lob)
        {
            _quoteNumber = quoteNumber;
            _state = state;
            _lob = lob;
            Console.WriteLine($"Testing forms validation for quote {quoteNumber}, state {state}, LOB {lob}");
        }

        [When(@"I extract the DuckCreek session via CLAS cookie")]
        public async Task WhenIExtractTheSessionViaCLASCookie()
        {
            (_sessionId, _clasApiCalls) = await _sessionService.GetDuckCreekSessionIdAndInterceptClasAsync(_quoteNumber);
            Console.WriteLine($"DuckCreek_SessionId cookie: {_sessionId}");
            Assert.That(_sessionId, Is.Not.Null.And.Not.Empty,
                "DuckCreek_SessionId cookie was not set after opening the policy in CLAS.");
        }

        [Then(@"the forms should match the baseline")]
        public async Task ThenTheFormsShouldMatchTheBaseline()
        {
            // Log any interesting CLAS API calls captured during session setup
            if (_clasApiCalls?.Count > 0)
            {
                Console.WriteLine($"\n[CLAS Network Intercept] {_clasApiCalls.Count} relevant API calls captured:");
                foreach (var call in _clasApiCalls)
                    Console.WriteLine($"  {call}");
            }

            var responseXml = await _formsClient.GetFormsAndSaveAsync(
                _sessionId, _lob, $"{_lob}_BasicPolicy", _state, _quoteNumber);

            var actualForms = FormsXmlParser.Parse(responseXml);
            Console.WriteLine($"DuckCreek returned {actualForms.Count} forms for {_lob}/{_state}/{_quoteNumber}");

            var metadata = FormsXmlParser.ParseMetadata(responseXml);
            foreach (var w in metadata.Warnings)
                Console.WriteLine($"  [META INFO] {w}");
            Console.WriteLine($"  Metadata: PrintJob={metadata.PrintJobName}, Manuscript={metadata.Manuscript}, " +
                              $"RoleBasedSecurity={metadata.HasRoleBasedSecurity}, ReturnSuccess={metadata.ReturnSuccessStatus}");

            var testCase = "BASIC";
            var expected = _validationService.LoadExpectedFormsForLob(_lob, _state, testCase);
            var summary = _validationService.Validate(expected, actualForms, _lob, _state, _quoteNumber);
            summary.ResponseMetadata = metadata;
            summary.TestCaseName = $"{_lob}_{testCase}";

            FormsValidationService.PrintSummary(summary);
            _validationService.SaveResultsCsv(summary, $"{_lob}_{testCase}");

            var htmlDir = Path.Combine(
                _validationService.GetType().Assembly.Location, "..", "..", "..", "TestResults",
                DateTime.Now.ToString("ddMMMyyyy").ToUpperInvariant());
            var htmlPath = Path.Combine(htmlDir, $"FormsReport_{_lob}_{_state}_{_quoteNumber}.html");
            FormsReportGenerator.Generate(summary, htmlPath);

            var absoluteHtmlPath = Path.GetFullPath(htmlPath);
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(absoluteHtmlPath) { UseShellExecute = true });
            // Open the containing folder so the file can easily be attached to Teams/email
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("explorer.exe", $"/select,\"{absoluteHtmlPath}\"") { UseShellExecute = true });

            if (summary.Failed > 0)
            {
                var failures = string.Join("\n", summary.Results
                    .Where(r => r.Result == "FAIL")
                    .Select(r => $"    {r.FormName}: {r.Message}"));
                Assert.Fail($"Forms validation: {summary.Failed} failure(s) detected.\n{failures}\nSee report: {htmlPath}");
            }
        }
    }
}
