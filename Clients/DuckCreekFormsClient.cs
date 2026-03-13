using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Playwright_POC.Models;

namespace Playwright_POC.Clients
{
    /// <summary>
    /// HTTP client for the DuckCreek Forms Engine API.
    /// Replaces the Tosca API Tester module that POSTs XML to dctserver.aspx.
    ///
    /// IMPORTANT — Dual-user architecture:
    ///   The API service account (e.g. PA3402) is different from the UI login that
    ///   created the DCT.sessionID. DuckCreek will return internal "failure" status
    ///   nodes (DataStoreMissing, User not logged in) but this is EXPECTED.
    ///   HTTP 200 and 500 both contain valid forms XML.
    ///   Only 401/403 indicate real authentication failures.
    /// </summary>
    public class DuckCreekFormsClient
    {
        private readonly HttpClient _httpClient;
        private readonly DuckCreekFormsConfig _config;

        public DuckCreekFormsClient(HttpClient httpClient, DuckCreekFormsConfig config)
        {
            _httpClient = httpClient;
            _config = config;

            var credentials = Convert.ToBase64String(
                Encoding.ASCII.GetBytes($"{_config.Username}:{_config.Password}"));
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", credentials);
        }

        /// <summary>
        /// Calls the DuckCreek FormsEngine.initPrintJob with the given session, manuscript, and printJob.
        /// Accepts HTTP 200 AND 500 as valid (both contain forms XML due to user mismatch).
        /// Only 401/403 are treated as real failures.
        /// </summary>
        public async Task<string> GetFormsAsync(string sessionId, string manuscript, string printJob)
        {
            var xmlPayload = BuildPayload(sessionId, manuscript, printJob);
            var url = $"{_config.ServerBaseUrl.TrimEnd('/')}{_config.Endpoint}";

            var content = new StringContent(xmlPayload, Encoding.UTF8, "text/xml");
            var response = await _httpClient.PostAsync(url, content);

            var statusCode = (int)response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            // 401/403 = real auth failure — throw immediately
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new HttpRequestException($"DuckCreek returned 401 Unauthorized — check API credentials (Username: {_config.Username})");
            if (response.StatusCode == HttpStatusCode.Forbidden)
                throw new HttpRequestException($"DuckCreek returned 403 Forbidden — API user {_config.Username} lacks permission");

            // 200 = success, 500 = expected (user mismatch), both contain forms XML
            if (statusCode == 200)
                Console.WriteLine($"DuckCreek API: 200 OK");
            else if (statusCode == 500)
                Console.WriteLine($"DuckCreek API: 500 (expected — API user ≠ session user). XML still contains forms.");
            else if (statusCode == 400)
                Console.WriteLine($"DuckCreek API: 400 Bad Request — possible XML/manuscript mismatch. Attempting to parse response.");
            else
                Console.WriteLine($"DuckCreek API: Unexpected status {statusCode}. Attempting to parse response.");

            if (string.IsNullOrWhiteSpace(responseBody) || responseBody.Length <= 8)
                throw new InvalidOperationException(
                    $"DuckCreek Forms API returned an empty or too-short response (HTTP {statusCode}, {responseBody.Length} bytes).");

            return responseBody;
        }

        /// <summary>
        /// Calls the Forms API and saves the XML response to the results directory,
        /// mirroring the Tosca file-naming convention: {TestCaseName}_{State}_{QuoteID}.xml
        /// </summary>
        public async Task<string> GetFormsAndSaveAsync(
            string sessionId, string lob, string testCaseName, string state, string quoteId)
        {
            var manuscript = _config.GetManuscriptForLob(lob);
            var responseXml = await GetFormsAsync(sessionId, manuscript, _config.PrintJob);

            var resultsDir = Path.Combine(_config.ResultsBasePath, lob);
            Directory.CreateDirectory(resultsDir);

            var fileName = $"{testCaseName}_{state}_{quoteId}.xml";
            var filePath = Path.Combine(resultsDir, fileName);
            await File.WriteAllTextAsync(filePath, responseXml);

            Console.WriteLine($"Forms XML saved: {filePath}");
            return responseXml;
        }

        private static string BuildPayload(string sessionId, string manuscript, string printJob) =>
            $"<server><requests>" +
            $"<Session.resumeRq sessionID=\"{sessionId}\" />" +
            $"<FormsEngine.initPrintJobRq manuscript=\"{manuscript}\" printJob=\"{printJob}\" forceInit=\"1\" />" +
            $"</requests></server>";
    }
}
