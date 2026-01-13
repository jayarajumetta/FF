using Microsoft.Playwright;
using Newtonsoft.Json;
using Playwright_POC.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_POC.Helpers
{
    // Custom exception to carry response body for troubleshooting
    public class TokenRequestException : Exception
    {
        public string ResponseBody { get; }
        public TokenRequestException(string message, string responseBody) : base(message)
        {
            ResponseBody = responseBody;
        }
    }

    public static class AuthHelper
    {
        // Existing PKCE-based login method retained for UI automation
        public static async Task<string> LoginAndGetToken(IPage page, OAuthConfig oauthConfig, CredentialsConfig credentials)
        {
            var (codeVerifier, codeChallenge) = GeneratePkce();
            var authUrl = $"{oauthConfig.AuthUrl}?client_id={oauthConfig.ClientId}&response_type=code&scope=openid%20profile&redirect_uri={Uri.EscapeDataString(oauthConfig.RedirectUri)}&code_challenge_method=S256&code_challenge={codeChallenge}";

            await page.GotoAsync(authUrl);
            await page.FillAsync("#username", credentials.Username);
            await page.FillAsync("#password", credentials.Password);
            await page.ClickAsync("#loginButton");

            await page.WaitForURLAsync(url => url.Contains("/oauth/login"));
            var redirectUrl = page.Url;
            var uri = new Uri(redirectUrl);
            var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
            var authCode = queryParams["code"];
            if (string.IsNullOrEmpty(authCode))
                throw new Exception("Authorization code not found in redirect URL.");

            using var client = new HttpClient();
            var formData = new Dictionary<string, string>
            {
                { "grant_type", "authorization_code" },
                { "code", authCode },
                { "redirect_uri", oauthConfig.RedirectUri },
                { "client_id", oauthConfig.ClientId },
                { "code_verifier", codeVerifier }
            };

            var response = await client.PostAsync(oauthConfig.TokenUrl, new FormUrlEncodedContent(formData));
            var json = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                throw new TokenRequestException($"Token request failed with status {response.StatusCode}", json);

            dynamic tokens = JsonConvert.DeserializeObject(json);
            if (tokens.access_token == null)
                throw new Exception("Access token not found in token response.");

            return tokens.access_token;
        }

        // Password Grant Flow
        public static async Task<string> GetTokenWithPasswordAsync(OAuthConfig oauthConfig, CredentialsConfig credentials)
        {
            using var client = new HttpClient();
            var formData = new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "username", credentials.Username },
                { "password", credentials.Password },
                { "client_id", oauthConfig.ClientId },
                { "scope", oauthConfig.Scope ?? "openid profile" }
            };

            var response = await client.PostAsync(oauthConfig.TokenUrl, new FormUrlEncodedContent(formData));
            var json = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                throw new TokenRequestException($"Token request failed with status {response.StatusCode}", json);

            dynamic tokens = JsonConvert.DeserializeObject(json);
            if (tokens.access_token == null)
                throw new Exception("Access token not found in token response.");

            return tokens.access_token;
        }

        // Client Credentials Flow
        public static async Task<string> GetTokenWithClientCredentialsAsync(OAuthConfig oauthConfig, string clientSecret)
        {
            using var client = new HttpClient();
            var formData = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "client_id", oauthConfig.ClientId },
                { "client_secret", clientSecret },
                { "scope", oauthConfig.Scope ?? "openid profile" }
            };

            var response = await client.PostAsync(oauthConfig.TokenUrl, new FormUrlEncodedContent(formData));
            var json = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                throw new TokenRequestException($"Token request failed with status {response.StatusCode}", json);

            dynamic tokens = JsonConvert.DeserializeObject(json);
            if (tokens.access_token == null)
                throw new Exception("Access token not found in token response.");

            return tokens.access_token;
        }

        private static (string CodeVerifier, string CodeChallenge) GeneratePkce()
        {
            var randomBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            var codeVerifier = Convert.ToBase64String(randomBytes)
                .Replace("+", "-")
                .Replace("/", "_")
                .Replace("=", "");

            using (var sha256 = SHA256.Create())
            {
                var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(codeVerifier));
                var codeChallenge = Convert.ToBase64String(hash)
                    .Replace("+", "-")
                    .Replace("/", "_")
                    .Replace("=", "");
                return (codeVerifier, codeChallenge);
            }
        }
    }
}