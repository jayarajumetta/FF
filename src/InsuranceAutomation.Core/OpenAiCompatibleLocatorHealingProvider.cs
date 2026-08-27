using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace InsuranceAutomation.Core;

public sealed class OpenAiCompatibleLocatorHealingProvider : ILocatorHealingProvider, IDisposable
{
    private readonly FrameworkConfig _config;
    private readonly HttpClient _http;

    public OpenAiCompatibleLocatorHealingProvider(FrameworkConfig config)
    {
        _config = config;
        _http = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(Math.Max(5, config.SelfHeal.RequestTimeoutSeconds))
        };
    }

    public string Name => "openai-compatible";

    public bool IsAvailable(out string reason)
    {
        if (string.IsNullOrWhiteSpace(_config.SelfHeal.Endpoint))
        {
            reason = "selfHeal.endpoint is not configured.";
            return false;
        }
        if (string.IsNullOrWhiteSpace(_config.SelfHeal.Model))
        {
            reason = "selfHeal.model is not configured.";
            return false;
        }
        var apiKey = _config.GetLlmApiKey();
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            reason = $"environment variable '{_config.SelfHeal.ApiKeyEnvironmentVariable}' is not set.";
            return false;
        }
        reason = string.Empty;
        return true;
    }

    public async Task<string> ProposeAsync(LocatorHealingProviderRequest request, CancellationToken cancellationToken = default)
    {
        var apiKey = _config.GetLlmApiKey();
        if (string.IsNullOrWhiteSpace(apiKey))
            throw new InvalidOperationException($"Environment variable '{_config.SelfHeal.ApiKeyEnvironmentVariable}' is not set.");

        object content;
        if (_config.SelfHeal.IncludeScreenshot && request.Screenshot.Length > 0)
        {
            content = new object[]
            {
                new { type = "text", text = request.Prompt },
                new { type = "image_url", image_url = new { url = "data:image/png;base64," + Convert.ToBase64String(request.Screenshot) } }
            };
        }
        else
        {
            content = request.Prompt;
        }

        var body = new
        {
            model = _config.SelfHeal.Model,
            temperature = 0,
            messages = new[] { new { role = "user", content } }
        };

        using var httpRequest = new HttpRequestMessage(HttpMethod.Post, _config.SelfHeal.Endpoint);
        httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        httpRequest.Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
        using var response = await _http.SendAsync(httpRequest, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new InvalidOperationException($"LLM HTTP {(int)response.StatusCode}: {json}");

        using var doc = JsonDocument.Parse(json);
        var choices = doc.RootElement.GetProperty("choices");
        if (choices.GetArrayLength() == 0) return string.Empty;
        return choices[0].GetProperty("message").GetProperty("content").GetString() ?? string.Empty;
    }

    public void Dispose() => _http.Dispose();
}
