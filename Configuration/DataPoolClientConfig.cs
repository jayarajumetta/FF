#nullable enable
using System;
using System.Net;

namespace PnCTestAutomation.Configuration
{
    public sealed class DataPoolClientConfig
    {
        public string BaseUrl { get; set; } = string.Empty;
        public bool Required { get; set; }
        public bool AutoStart { get; set; } = true;
        public string ApiKey { get; set; } = string.Empty;

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(BaseUrl))
            {
                if (Required)
                {
                    throw new InvalidOperationException(
                        "DataPool:BaseUrl is required for this execution profile.");
                }

                return;
            }

            if (!Uri.TryCreate(BaseUrl, UriKind.Absolute, out var uri) ||
                (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps) ||
                !string.IsNullOrEmpty(uri.UserInfo) ||
                uri.AbsolutePath != "/" ||
                !string.IsNullOrEmpty(uri.Query) ||
                !string.IsNullOrEmpty(uri.Fragment))
            {
                throw new InvalidOperationException(
                    "DataPool:BaseUrl must be an absolute HTTP(S) origin without credentials, path, query, or fragment.");
            }

            if (!uri.IsLoopback &&
                (uri.Scheme != Uri.UriSchemeHttps ||
                 string.IsNullOrWhiteSpace(ApiKey) ||
                 LooksLikeUnexpandedVariable(ApiKey)))
            {
                throw new InvalidOperationException(
                    "A remote DataPool requires HTTPS and DATAPOOL_API_KEY.");
            }
        }

        private static bool LooksLikeUnexpandedVariable(string value) =>
            value.StartsWith("$(", StringComparison.Ordinal) &&
            value.EndsWith(")", StringComparison.Ordinal);
    }
}
