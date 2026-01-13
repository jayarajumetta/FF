using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Playwright_POC.Helpers
{
    public class PingSecretProvider
    {
        private readonly HttpClient _client;
        private readonly string _tokenEndpoint;
        private readonly string _secretEndpoint;
        private readonly string _bootstrapClientId;
        private readonly string _bootstrapClientSecret;

        public PingSecretProvider(HttpClient client, string tokenEndpoint, string secretEndpoint, string bootstrapClientId, string bootstrapClientSecret)
        {
            _client = client;
            _tokenEndpoint = tokenEndpoint;
            _secretEndpoint = secretEndpoint;
            _bootstrapClientId = bootstrapClientId;
            _bootstrapClientSecret = bootstrapClientSecret;
        }

        public async Task<string> GetSecretAsync(string secretId)
        {
            // 1. Get bootstrap token using client_secret_post
            var tokenRequest = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "client_id", _bootstrapClientId },
                { "client_secret", _bootstrapClientSecret }
            };

            var tokenResponse = await _client.PostAsync(_tokenEndpoint, new FormUrlEncodedContent(tokenRequest));
            var tokenJson = await tokenResponse.Content.ReadAsStringAsync();
            if (!tokenResponse.IsSuccessStatusCode)
                throw new Exception($"Bootstrap token request failed: {tokenResponse.StatusCode}, {tokenJson}");

            var tokenObj = JsonSerializer.Deserialize<TokenResponse>(tokenJson);
            var bootstrapToken = tokenObj?.AccessToken ?? throw new Exception("Bootstrap access token not found.");

            // 2. Use bootstrap token to get real client_secret
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bootstrapToken);
            var secretResponse = await _client.GetAsync($"{_secretEndpoint}/{secretId}");
            var secretJson = await secretResponse.Content.ReadAsStringAsync();
            if (!secretResponse.IsSuccessStatusCode)
                throw new Exception($"Secret retrieval failed: {secretResponse.StatusCode}, {secretJson}");

            var secretObj = JsonSerializer.Deserialize<SecretResponse>(secretJson);
            return secretObj?.Value ?? throw new Exception("Secret value not found.");
        }

        public class TokenResponse { public string AccessToken { get; set; } }
        public class SecretResponse { public string Value { get; set; } }
    }
}