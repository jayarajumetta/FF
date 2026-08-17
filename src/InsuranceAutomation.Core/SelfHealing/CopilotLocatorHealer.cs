using System.Text.Json;
using System.Text.RegularExpressions;
using GitHub.Copilot;
namespace InsuranceAutomation.Core.SelfHealing;

public sealed class CopilotLocatorHealer : IAsyncDisposable
{
    readonly SelfHealingOptions _options;
    CopilotClient? _client;
    int _calls;
    bool _started;
    public CopilotLocatorHealer(SelfHealingOptions options) => _options = options;

    public async Task<LocatorProposal?> ProposeAsync(HealingRequest request)
    {
        if (!_options.Enabled || _calls >= _options.MaxCopilotCallsPerScenario) return null;
        _calls++;
        _client ??= new CopilotClient(new CopilotClientOptions { WorkingDirectory = Directory.GetCurrentDirectory() });
        if (!_started) { await _client.StartAsync(); _started=true; }

        await using var session = await _client.CreateSessionAsync(new SessionConfig
        {
            Model = _options.Model,
            AvailableTools = new List<string>(),
            SystemMessage = new SystemMessageConfig
            {
                Content = SystemPrompt
            }
        });

        string? final = null;
        var done = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        using var sub = session.On<SessionEvent>(evt =>
        {
            if (evt is AssistantMessageEvent m) final = m.Data.Content;
            if (evt is SessionIdleEvent) done.TrySetResult();
            if (evt is SessionErrorEvent e) done.TrySetException(new InvalidOperationException(e.Data.Message));
        });
        await session.SendAsync(new MessageOptions { Prompt = JsonSerializer.Serialize(request, JsonOptions) });
        await done.Task.WaitAsync(TimeSpan.FromSeconds(45));
        return Parse(final);
    }

    static LocatorProposal? Parse(string? text)
    {
        if (string.IsNullOrWhiteSpace(text)) return null;
        var m = Regex.Match(text, @"\{[\s\S]*\}");
        if (!m.Success) return null;
        try { return JsonSerializer.Deserialize<LocatorProposal>(m.Value, JsonOptions); } catch { return null; }
    }

    const string SystemPrompt = """
You are a Playwright locator-healing specialist for Duck Creek and ExpertQuote insurance applications.
You receive a JSON failure context containing feature/scenario/step intent, the failed primary locator and a sanitized list of DOM elements.
Return ONLY one JSON object: {"strategy":"testid|role|label|placeholder|text|id|name|duckcreekid|css","value":"...","name":"optional accessible name for role","exact":true,"confidence":0.0,"reason":"short reason"}.
Rules: prefer testid, then role+accessible name, label, stable id, name, placeholder, exact text, Duck Creek id, and only then concise CSS. Never return XPath. Never return code, JavaScript, shell, actions, credentials or test data. Do not invent an element absent from the supplied DOM snapshot. Use business intent and nearby field names to disambiguate. If evidence is weak return confidence below 0.5.
""";
    static readonly JsonSerializerOptions JsonOptions = new(){PropertyNameCaseInsensitive=true};

    public async ValueTask DisposeAsync(){ if (_client != null) await _client.DisposeAsync(); }
}
