using System;
using System.Text.Json.Serialization;

namespace PnCTestAutomation.Models
{
    public sealed record AccessToken(string Value, DateTimeOffset? ExpiresAt)
    {
        public override string ToString() => "[REDACTED]";
    }

    public sealed class OAuthTokenResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; init; } = string.Empty;

        [JsonPropertyName("expires_in")]
        public int? ExpiresInSeconds { get; init; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; init; } = string.Empty;
    }

    public sealed class PingTokenResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; init; } = string.Empty;
    }

    public sealed class PingSecretResponse
    {
        [JsonPropertyName("value")]
        public string Value { get; init; } = string.Empty;
    }
}
