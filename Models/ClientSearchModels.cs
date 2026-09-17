using System.Text.Json.Serialization;

namespace PnCTestAutomation.Models
{
    public sealed class ClientSearchRequest
    {
        [JsonPropertyName("exactSearch")]
        public bool ExactSearch { get; init; }

        [JsonPropertyName("includePhoneticMatch")]
        public bool IncludePhoneticMatch { get; init; } = true;

        [JsonPropertyName("includeAgentGrants")]
        public bool IncludeAgentGrants { get; init; } = true;

        [JsonPropertyName("firstName")]
        public string FirstName { get; init; } = string.Empty;

        [JsonPropertyName("lastName")]
        public string LastName { get; init; } = string.Empty;

        [JsonPropertyName("dateOfBirth")]
        public string DateOfBirth { get; init; } = string.Empty;

        [JsonPropertyName("emailAddress")]
        public string EmailAddress { get; init; } = string.Empty;

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; init; } = string.Empty;
    }

    public sealed class ClientSearchResponse
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; init; } = string.Empty;

        [JsonPropertyName("lastName")]
        public string LastName { get; init; } = string.Empty;
    }
}
