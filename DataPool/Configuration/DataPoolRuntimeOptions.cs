using System.Net;

namespace DataPool.Configuration
{
    public sealed class DataPoolRuntimeOptions
    {
        public string ListenUrl { get; init; } = "http://127.0.0.1:5100";
        public string ApiKey { get; init; } = string.Empty;
        public long MaxRequestBodyBytes { get; init; } = 64 * 1024;

        public static DataPoolRuntimeOptions FromConfiguration(
            IConfiguration configuration) =>
            new()
            {
                ListenUrl = Environment.GetEnvironmentVariable("DATAPOOL_LISTEN_URL")
                            ?? configuration["DataPool:ListenUrl"]
                            ?? "http://127.0.0.1:5100",
                ApiKey = Environment.GetEnvironmentVariable("DATAPOOL_API_KEY")
                         ?? configuration["DataPool:ApiKey"]
                         ?? string.Empty,
                MaxRequestBodyBytes =
                    configuration.GetValue<long?>("DataPool:MaxRequestBodyBytes")
                    ?? 64 * 1024
            };

        public void Validate()
        {
            if (!Uri.TryCreate(ListenUrl, UriKind.Absolute, out var uri) ||
                (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps) ||
                !string.IsNullOrEmpty(uri.UserInfo) ||
                uri.AbsolutePath != "/" ||
                !string.IsNullOrEmpty(uri.Query) ||
                !string.IsNullOrEmpty(uri.Fragment))
            {
                throw new InvalidOperationException(
                    "DataPool:ListenUrl must be an absolute HTTP(S) origin without credentials, path, query, or fragment.");
            }

            if (!IsLoopback(uri.Host) &&
                (uri.Scheme != Uri.UriSchemeHttps ||
                 string.IsNullOrWhiteSpace(ApiKey) ||
                 LooksLikeUnexpandedVariable(ApiKey)))
            {
                throw new InvalidOperationException(
                    "Remote DataPool exposure requires HTTPS and DATAPOOL_API_KEY.");
            }

            if (MaxRequestBodyBytes is < 1024 or > 1024 * 1024)
            {
                throw new InvalidOperationException(
                    "DataPool:MaxRequestBodyBytes must be between 1024 and 1048576.");
            }
        }

        private static bool IsLoopback(string host) =>
            string.Equals(host, "localhost", StringComparison.OrdinalIgnoreCase) ||
            (IPAddress.TryParse(host, out var address) && IPAddress.IsLoopback(address));

        private static bool LooksLikeUnexpandedVariable(string value) =>
            value.StartsWith("$(", StringComparison.Ordinal) &&
            value.EndsWith(")", StringComparison.Ordinal);
    }
}
