using System;

namespace PnCTestAutomation.Configuration
{
    public sealed class OAuthConfig
    {
        public string AuthUrl { get; set; } = string.Empty;
        public string TokenUrl { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public string RedirectUri { get; set; } = string.Empty;
        public string Scope { get; set; } = "openid profile";
        public string GrantType { get; set; } = "password";
        public string PingSecretId { get; set; } = string.Empty;

        public void ValidateClientCredentials()
        {
            ValidateHttpsUri(TokenUrl, nameof(TokenUrl));
            RequireValue(ClientId, nameof(ClientId));
            RequireValue(PingSecretId, nameof(PingSecretId));
        }

        private static void RequireValue(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidOperationException(
                    $"OAuthConfig:{propertyName} must be supplied through configuration.");
            }
        }

        private static void ValidateHttpsUri(string value, string propertyName)
        {
            RequireValue(value, propertyName);
            if (!Uri.TryCreate(value, UriKind.Absolute, out var uri) ||
                uri.Scheme != Uri.UriSchemeHttps)
            {
                throw new InvalidOperationException(
                    $"OAuthConfig:{propertyName} must be an absolute HTTPS URI.");
            }
        }
    }
}
