
using Playwright_POC.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Playwright_POC.Services
{
    public interface IApiService
    {
        HttpClient HttpClient { get; }
        ApiHeaders Headers { get; }
        void SetAuthToken(string token);
    }

    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiHeaders _apiHeaders;

        public ApiService(HttpClient httpClient, ApiHeaders apiHeaders)
        {
            _httpClient = httpClient;
            _apiHeaders = apiHeaders;
        }

        public HttpClient HttpClient => _httpClient;
        public ApiHeaders Headers => _apiHeaders;

        public void SetAuthToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
    }
}
