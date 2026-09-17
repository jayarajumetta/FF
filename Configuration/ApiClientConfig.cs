using System;

namespace PnCTestAutomation.Configuration
{
    public sealed class ApiClientConfig
    {
        public string BaseUrl { get; set; } = string.Empty;
        public int MaxTransientAttempts { get; set; } = 2;
        public int RetryDelayMilliseconds { get; set; } = 500;

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(BaseUrl) ||
                !Uri.TryCreate(BaseUrl, UriKind.Absolute, out var uri) ||
                uri.Scheme != Uri.UriSchemeHttps)
            {
                throw new InvalidOperationException(
                    "ApiClient:BaseUrl must be an absolute HTTPS URI.");
            }

            if (MaxTransientAttempts is < 1 or > 3)
            {
                throw new InvalidOperationException(
                    "ApiClient:MaxTransientAttempts must be between 1 and 3.");
            }

            if (RetryDelayMilliseconds is < 0 or > 10_000)
            {
                throw new InvalidOperationException(
                    "ApiClient:RetryDelayMilliseconds must be between 0 and 10000.");
            }
        }
    }
}
