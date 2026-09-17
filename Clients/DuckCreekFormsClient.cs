using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using PnCTestAutomation.Models;

namespace PnCTestAutomation.Clients
{
    public interface IFormsApiClient
    {
        Task<string> GetFormsAsync(
            string sessionId,
            string manuscript,
            string printJob);
    }

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
    public class DuckCreekFormsClient : IFormsApiClient
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

            Console.WriteLine("[DuckCreekFormsClient] Requesting forms XML.");

            var content = new StringContent(xmlPayload, Encoding.UTF8, "text/xml");
            var response = await _httpClient.PostAsync(url, content);

            var statusCode = (int)response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new HttpRequestException(
                    "DuckCreek returned 401 Unauthorized; verify the configured API credential.");
            if (response.StatusCode == HttpStatusCode.Forbidden)
                throw new HttpRequestException(
                    "DuckCreek returned 403 Forbidden; the configured API identity lacks permission.");
            if (response.StatusCode is not (HttpStatusCode.OK or HttpStatusCode.InternalServerError))
            {
                throw new HttpRequestException(
                    $"DuckCreek Forms API returned HTTP {statusCode} ({response.StatusCode}).");
            }

            Console.WriteLine($"[DuckCreekFormsClient] Response: HTTP {statusCode}, {responseBody.Length} chars");

            if (string.IsNullOrWhiteSpace(responseBody) || responseBody.Length <= 8)
                throw new InvalidOperationException(
                    $"DuckCreek Forms API returned an empty or too-short response (HTTP {statusCode}, {responseBody.Length} bytes).");

            // Detect HTML error pages (e.g. IIS 503, 500 splash pages) — not valid XML.
            // HTTP 200 and 500 both return valid forms XML; any HTML body is an infrastructure error.
            var trimmed = responseBody.TrimStart();
            if (trimmed.StartsWith("<!", StringComparison.OrdinalIgnoreCase) ||
                trimmed.StartsWith("<html", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    $"DuckCreek Forms API returned HTML instead of XML (HTTP {statusCode}).");
            }

            return responseBody;
        }

        private static string BuildPayload(string sessionId, string manuscript, string printJob) =>
            $"<server><requests>" +
            $"<Session.resumeRq sessionID=\"{SecurityElement.Escape(sessionId)}\" />" +
            $"<FormsEngine.initPrintJobRq manuscript=\"{SecurityElement.Escape(manuscript)}\" printJob=\"{SecurityElement.Escape(printJob)}\" forceInit=\"1\" />" +
            $"</requests></server>";
    }
}
