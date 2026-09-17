using System.Security.Cryptography;
using System.Text;
using DataPool.Configuration;

namespace DataPool.Security
{
    public sealed class DataPoolRequestGuardMiddleware
    {
        public const string ApiKeyHeader = "X-DataPool-Key";

        private readonly RequestDelegate _next;
        private readonly DataPoolRuntimeOptions _options;

        public DataPoolRequestGuardMiddleware(
            RequestDelegate next,
            DataPoolRuntimeOptions options)
        {
            _next = next;
            _options = options;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.Equals("/health"))
            {
                await _next(context);
                return;
            }

            if (!string.IsNullOrWhiteSpace(_options.ApiKey) &&
                !HasValidApiKey(context.Request))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            if (context.Request.ContentLength > _options.MaxRequestBodyBytes)
            {
                context.Response.StatusCode = StatusCodes.Status413PayloadTooLarge;
                return;
            }

            await _next(context);
        }

        private bool HasValidApiKey(HttpRequest request)
        {
            if (!request.Headers.TryGetValue(ApiKeyHeader, out var suppliedValues) ||
                suppliedValues.Count != 1)
            {
                return false;
            }

            var expected = Encoding.UTF8.GetBytes(_options.ApiKey);
            var supplied = Encoding.UTF8.GetBytes(suppliedValues[0] ?? string.Empty);
            return expected.Length == supplied.Length &&
                   CryptographicOperations.FixedTimeEquals(expected, supplied);
        }
    }
}
