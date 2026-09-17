using System;

namespace PnCTestAutomation.Configuration
{
    public sealed class PingSecretConfig
    {
        public string TokenEndpoint { get; set; } = string.Empty;
        public string SecretEndpoint { get; set; } = string.Empty;
        public string BootstrapClientId { get; set; } = string.Empty;
        public string BootstrapClientSecret { get; set; } = string.Empty;

        public void Validate()
        {
            ValidateHttpsUri(TokenEndpoint, nameof(TokenEndpoint));
            ValidateHttpsUri(SecretEndpoint, nameof(SecretEndpoint));

            if (string.IsNullOrWhiteSpace(BootstrapClientId))
            {
                throw new InvalidOperationException(
                    "PingSecret:BootstrapClientId must be supplied through configuration.");
            }

            if (string.IsNullOrWhiteSpace(BootstrapClientSecret))
            {
                throw new InvalidOperationException(
                    "PingSecret:BootstrapClientSecret must be supplied through configuration.");
            }
        }

        private static void ValidateHttpsUri(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                !Uri.TryCreate(value, UriKind.Absolute, out var uri) ||
                uri.Scheme != Uri.UriSchemeHttps)
            {
                throw new InvalidOperationException(
                    $"PingSecret:{propertyName} must be an absolute HTTPS URI.");
            }
        }
    }
}
