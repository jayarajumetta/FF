using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using PnCTestAutomation.Clients;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Models;
using PnCTestAutomation.Parsers;
using PnCTestAutomation.Services;
using Reqnroll;

namespace PnCTestAutomation.StepDefinitions.SFPSteps
{
    [Binding]
    public class FormsValidationSmokeSteps
    {
        private readonly SessionService _sessionService;
        private readonly DuckCreekFormsClient _formsClient;
        private readonly FormsValidationService _validationService;
        private readonly IConfiguration _configuration;

        private string _quoteNumber;
        private string _state;
        private string _lob;
        private string _sessionId;
        private System.Collections.Generic.List<string> _clasApiCalls;

        public FormsValidationSmokeSteps(
            SessionService sessionService,
            DuckCreekFormsClient formsClient,
            FormsValidationService validationService,
            IConfiguration configuration)
        {
            _sessionService = sessionService;
            _formsClient = formsClient;
            _validationService = validationService;
            _configuration = configuration;
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
            // Sanitize all externally-supplied values immediately on entry, before any use.
            // Mitigates stored path traversal (CWE-22): _lob, _state, and _quoteNumber
            // originate from Gherkin step arguments and could contain traversal sequences
            // or characters that are invalid in file names.
            const string testCase = "BASIC";
            var safeLob         = SanitizeFileName(_lob);
            var safeState       = SanitizeFileName(_state);
            var safeQuoteNumber = SanitizeFileName(_quoteNumber);
            var safeTestCase    = SanitizeFileName(testCase);

            // Log any interesting CLAS API calls captured during session setup
            if (_clasApiCalls?.Count > 0)
            {
                Console.WriteLine($"\n[CLAS Network Intercept] {_clasApiCalls.Count} relevant API calls captured:");
                foreach (var call in _clasApiCalls)
                    Console.WriteLine($"  {call}");
            }

            var responseXml = await _formsClient.GetFormsAndSaveAsync(
                _sessionId, safeLob, $"{safeLob}_{safeTestCase}", safeState, safeQuoteNumber);

            var actualForms = FormsXmlParser.Parse(responseXml);
            Console.WriteLine($"DuckCreek returned {actualForms.Count} forms for {safeLob}/{safeState}/{safeQuoteNumber}");

            var metadata = FormsXmlParser.ParseMetadata(responseXml);
            foreach (var w in metadata.Warnings)
                Console.WriteLine($"  [META INFO] {w}");
            Console.WriteLine($"  Metadata: PrintJob={metadata.PrintJobName}, Manuscript={metadata.Manuscript}, " +
                              $"RoleBasedSecurity={metadata.HasRoleBasedSecurity}, ReturnSuccess={metadata.ReturnSuccessStatus}");

            var expected = _validationService.LoadExpectedFormsForLob(safeLob, safeState, safeTestCase);
            var summary  = _validationService.Validate(expected, actualForms, safeLob, safeState, safeQuoteNumber);
            summary.ResponseMetadata = metadata;
            summary.TestCaseName     = $"{safeLob}_{safeTestCase}";

            FormsValidationService.PrintSummary(summary);
            _validationService.SaveResultsCsv(summary, $"{safeLob}_{safeTestCase}");

            var htmlDir  = Path.GetFullPath(Path.Combine(
                _validationService.GetType().Assembly.Location, "..", "..", "..", "TestResults",
                DateTime.Now.ToString("ddMMMyyyy").ToUpperInvariant()));
            var htmlPath = Path.Combine(htmlDir, $"FormsReport_{safeLob}_{safeState}_{safeQuoteNumber}.html");

            // Verify the resolved path stays within the intended output directory.
            var absoluteHtmlPath = Path.GetFullPath(htmlPath);
            if (!absoluteHtmlPath.StartsWith(htmlDir + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("Path traversal detected: report path escapes the intended output directory.");

            FormsReportGenerator.Generate(summary, htmlPath);
            Console.WriteLine($"[FormsValidation] HTML report saved: {absoluteHtmlPath}");
            MaybeOpenFormsReport(absoluteHtmlPath, summary.Failed > 0);

            if (summary.Failed > 0)
            {
                var failures = string.Join("\n", summary.Results
                    .Where(r => r.Result == "FAIL")
                    .Select(r => $"    {r.FormName}: {r.Message}"));
                Assert.Fail($"Forms validation: {summary.Failed} failure(s) detected.\n{failures}\nSee report: {htmlPath}");
            }
        }

        /// <summary>
        /// Sanitizes a value for safe use as a file name component.
        /// Neutralizes directory traversal sequences and replaces characters
        /// that are invalid in file names with underscores.
        /// Required because file names are derived from externally-supplied
        /// test inputs (path traversal mitigation, CWE-22).
        /// </summary>
        private static string SanitizeFileName(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "_";

            // Neutralize traversal sequences before character-level sanitization
            var sanitized = input.Replace("..", "_");

            // Replace all OS-invalid file name characters with underscores
            foreach (var c in Path.GetInvalidFileNameChars())
                sanitized = sanitized.Replace(c, '_');

            return sanitized;
        }

        private void MaybeOpenFormsReport(string absoluteHtmlPath, bool hasFailures)
        {
            var mode = (_configuration["Debugging:FormsReportOpenMode"] ?? "on-failure").Trim().ToLowerInvariant();

            var openHtml = false;
            var openFolder = false;

            switch (mode)
            {
                case "none":
                    break;
                case "html":
                    openHtml = true;
                    break;
                case "folder":
                    openFolder = true;
                    break;
                case "both":
                    openHtml = true;
                    openFolder = true;
                    break;
                case "on-failure":
                    openHtml = hasFailures;
                    openFolder = hasFailures;
                    break;
                default:
                    Console.WriteLine($"[FormsValidation] Unknown Debugging:FormsReportOpenMode '{mode}'. Using 'on-failure'.");
                    openHtml = hasFailures;
                    openFolder = hasFailures;
                    break;
            }

            if (openHtml)
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(absoluteHtmlPath) { UseShellExecute = true });

            if (openFolder)
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("explorer.exe", $"/select,\"{absoluteHtmlPath}\"") { UseShellExecute = true });
        }
    }
}
