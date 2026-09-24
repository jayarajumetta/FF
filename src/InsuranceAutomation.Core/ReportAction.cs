using System.Text.Json.Serialization;

namespace InsuranceAutomation.Core;

public sealed class ReportAction
{
    [JsonPropertyName("method")]
    public string Method { get; init; } = string.Empty;
    [JsonPropertyName("operation")]
    public string Operation { get; init; } = string.Empty;
    [JsonPropertyName("target")]
    public string Target { get; init; } = string.Empty;
    [JsonPropertyName("status")]
    public string Status { get; set; } = "RUNNING";
    [JsonPropertyName("durationMilliseconds")]
    public double DurationMilliseconds { get; set; }
    [JsonPropertyName("data")]
    public IReadOnlyDictionary<string, string> Data { get; init; } = new Dictionary<string, string>();
    [JsonPropertyName("error")]
    public string Error { get; set; } = string.Empty;
    [JsonPropertyName("result")]
    public string Result { get; set; } = string.Empty;
    [JsonPropertyName("children")]
    public List<ReportAction> Children { get; } = [];
}
