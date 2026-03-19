using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Playwright_POC.Models;

namespace Playwright_POC.Clients
{
    /// <summary>
    /// HTTP client for the DuckCreek Forms Engine API.
    /// Posts Session.resumeRq + FormsEngine.initPrintJobRq XML to dctserver.aspx.
    ///
    /// The sessionID comes from the DuckCreek_SessionId cookie set by CLAS Express
    /// after opening a policy. Format: colon-separated hex (e.g. 9CFEB9B9:33C24A91:...).
    ///
    /// HTTP Basic Auth uses the API service account (PA3402).
    /// HTTP 200 and 500 both contain valid forms XML.
    /// Only 401/403 indicate real authentication failures.
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
        /// Calls Session.resumeRq + FormsEngine.initPrintJobRq.
        /// </summary>
        public async Task<string> GetFormsAsync(string sessionId, string manuscript, string printJob)
        {
            var xmlPayload = BuildPayload(sessionId, manuscript, printJob);
            var url = $"{_config.ServerBaseUrl.TrimEnd('/')}{_config.Endpoint}";

            Console.WriteLine($"[DuckCreekFormsClient] POST {url}");
            Console.WriteLine($"[DuckCreekFormsClient] SessionID: {sessionId}");

            var content = new StringContent(xmlPayload, Encoding.UTF8, "text/xml");
            var response = await _httpClient.PostAsync(url, content);

            var statusCode = (int)response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new HttpRequestException($"DuckCreek returned 401 Unauthorized — check API credentials (Username: {_config.Username})");
            if (response.StatusCode == HttpStatusCode.Forbidden)
                throw new HttpRequestException($"DuckCreek returned 403 Forbidden — API user {_config.Username} lacks permission");

            Console.WriteLine($"[DuckCreekFormsClient] Response: HTTP {statusCode}, {responseBody.Length} chars");

            // Log first part of response for diagnostics
            if (statusCode != 200 || !responseBody.Contains("form name="))
                Console.WriteLine($"[DuckCreekFormsClient] Response body (first 600): {responseBody[..Math.Min(600, responseBody.Length)]}");

            if (string.IsNullOrWhiteSpace(responseBody) || responseBody.Length <= 8)
                throw new InvalidOperationException(
                    $"DuckCreek Forms API returned an empty or too-short response (HTTP {statusCode}, {responseBody.Length} bytes).");

            return responseBody;
        }

        /// <summary>
        /// Calls the Forms API and saves the XML response to the results directory.
        /// File naming: {TestCaseName}_{State}_{QuoteID}.xml
        /// </summary>
        public async Task<string> GetFormsAndSaveAsync(
            string sessionId, string lob, string testCaseName, string state, string quoteId)
        {
            var manuscript = _config.GetManuscriptForLob(lob);
            var printJob = _config.GetPrintJobForLob(lob);
            Console.WriteLine($"[DuckCreekFormsClient] LOB={lob}, Manuscript={manuscript}, PrintJob={printJob}");
            var responseXml = await GetFormsAsync(sessionId, manuscript, printJob);

            var resultsDir = Path.Combine(_config.ResultsBasePath, lob);
            Directory.CreateDirectory(resultsDir);

            var fileName = $"{testCaseName}_{state}_{quoteId}.xml";
            var filePath = Path.Combine(resultsDir, fileName);
            await File.WriteAllTextAsync(filePath, responseXml);

            Console.WriteLine($"[DuckCreekFormsClient] Forms XML saved: {filePath}");
            return responseXml;
        }

        private static string BuildPayload(string sessionId, string manuscript, string printJob) =>
            $"<server><requests>" +
            $"<Session.resumeRq sessionID=\"{SecurityElement.Escape(sessionId)}\" />" +
            $"<FormsEngine.initPrintJobRq manuscript=\"{SecurityElement.Escape(manuscript)}\" printJob=\"{SecurityElement.Escape(printJob)}\" forceInit=\"1\" />" +
            $"</requests></server>";
    }
}
