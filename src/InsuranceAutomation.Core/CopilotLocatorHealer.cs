using System.Text.Json;
using System.Text.RegularExpressions;
using GitHub.Copilot;
using Microsoft.Playwright;

namespace InsuranceAutomation.Core;

public sealed class CopilotLocatorHealer
{
    private readonly BrowserSession _browser;
    private readonly RunLogger _logger;

    public CopilotLocatorHealer(BrowserSession browser, RunLogger logger)
    {
        _browser = browser;
        _logger = logger;
    }

    public bool Enabled => !string.Equals(
        Environment.GetEnvironmentVariable("COPILOT_SELF_HEAL"),
        "false",
        StringComparison.OrdinalIgnoreCase);

    public async Task<ILocator?> TryHealAsync(
        ILocator failedLocator,
        ControlIntent control,
        string action,
        Exception failure)
    {
        if (!Enabled) return null;

        var local = await TryDeterministicAsync(control, action);
        if (local is not null)
        {
            _logger.Warn($"SELF-HEAL deterministic locator accepted for {control}.");
            return local;
        }

        try
        {
            var evidence = await CaptureEvidenceAsync(control);
            var response = await AskCopilotAsync(failedLocator, control, action, failure, evidence);
            var proposal = ParseProposal(response);
            if (proposal is null) return null;

            var locator = CreateLocator(proposal);
            if (!await IsUsableAsync(locator, action))
            {
                _logger.Warn($"SELF-HEAL Copilot proposal rejected for {control}: {response}");
                return null;
            }

            _logger.Warn($"SELF-HEAL Copilot accepted for {control}: {proposal.Strategy}:{proposal.Value} ({proposal.Confidence:0.00})");
            return locator;
        }
        catch (Exception ex)
        {
            _logger.Warn($"SELF-HEAL Copilot unavailable for {control}: {ex.Message}");
            return null;
        }
    }

    private async Task<Evidence> CaptureEvidenceAsync(ControlIntent control)
    {
        var screenshot = await _browser.Page.ScreenshotAsync(new PageScreenshotOptions
        {
            FullPage = true,
            Type = ScreenshotType.Png
        });

        var dom = await _browser.Page.EvaluateAsync<string>(@"() => {
            const clone = document.documentElement.cloneNode(true);
            clone.querySelectorAll('script,style,noscript').forEach(e => e.remove());
            clone.querySelectorAll('input,textarea').forEach(e => {
                e.removeAttribute('value');
                if (e.tagName === 'TEXTAREA') e.textContent = '';
            });
            clone.querySelectorAll('[src]').forEach(e => {
                const src = e.getAttribute('src') || '';
                if (src.startsWith('data:')) e.setAttribute('src','[data-removed]');
            });
            return clone.outerHTML.slice(0, 120000);
        }");

        var candidates = await _browser.Page.Locator(
            "input,select,textarea,button,a,[role],[data-testid],[name],[id]")
            .EvaluateAllAsync<string>(@"els => JSON.stringify(els.slice(0,500).map(e => ({
                tag:e.tagName.toLowerCase(),
                id:e.id||'',
                name:e.getAttribute('name')||'',
                role:e.getAttribute('role')||'',
                aria:e.getAttribute('aria-label')||'',
                placeholder:e.getAttribute('placeholder')||'',
                testid:e.getAttribute('data-testid')||'',
                duckcreek:e.getAttribute('data-duckcreek-id')||e.getAttribute('duckcreekid')||'',
                type:e.getAttribute('type')||'',
                text:(e.innerText||'').trim().slice(0,120)
            })))");

        var dir = Path.Combine(Path.GetDirectoryName(_logger.LogPath) ?? "Artifacts", "self-heal");
        Directory.CreateDirectory(dir);
        var safe = Regex.Replace(control.ToString(), "[^A-Za-z0-9_.-]", "_");
        var stamp = DateTime.Now.ToString("yyyyMMdd_HHmmssfff");
        var imagePath = Path.Combine(dir, $"{stamp}_{safe}.png");
        await File.WriteAllBytesAsync(imagePath, screenshot);
        var domPath = Path.Combine(dir, $"{stamp}_{safe}.html");
        await File.WriteAllTextAsync(domPath, dom);

        return new Evidence(screenshot, dom, candidates, imagePath, domPath);
    }

    private async Task<string> AskCopilotAsync(
        ILocator failedLocator,
        ControlIntent control,
        string action,
        Exception failure,
        Evidence evidence)
    {
        var state = ExecutionIntent.Current;
        var model = Environment.GetEnvironmentVariable("COPILOT_HEAL_MODEL") ?? "gpt-5";

        await using var client = new CopilotClient(new CopilotClientOptions
        {
            UseLoggedInUser = true
        });
        await client.StartAsync();

        await using var session = await client.CreateSessionAsync(new SessionConfig
        {
            Model = model,
            OnPermissionRequest = (_, _) => Task.FromResult(PermissionDecision.Reject("Locator healing is reasoning-only. No tools are permitted.")),
            AvailableTools = Array.Empty<string>()
        });

        var response = string.Empty;
        var done = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        using var subscription = session.On<SessionEvent>(evt =>
        {
            if (evt is AssistantMessageEvent message) response = message.Data.Content ?? string.Empty;
            if (evt is SessionIdleEvent) done.TrySetResult(true);
            if (evt is SessionErrorEvent error) done.TrySetException(new InvalidOperationException(error.Data.Message));
        });

        var prompt = $$"""
        You repair ONE Playwright locator. Do not change test data, action, expected result, or business flow.
        Return ONE JSON object only, without markdown.
        Allowed strategy values: testid, role, label, placeholder, text, id, name, css.
        Never return XPath or JavaScript.

        Feature: {{state.Feature}}
        Scenario: {{state.Scenario}}
        Business step: {{state.Step}}
        Page: {{control.Page}}
        Control: {{control.Control}}
        Action: {{action}}
        Failed Playwright locator: {{failedLocator}}
        Failure: {{failure.Message}}
        URL: {{_browser.Page.Url}}
        Title: {{await _browser.Page.TitleAsync()}}

        The screenshot is attached. Use it together with the sanitized DOM below.
        Prefer an exact data-testid, then role+accessible name, label, stable name/id, then concise CSS.
        The proposed locator must identify the control intended by the business step and be suitable for '{{action}}'.

        DOM candidates:
        {{evidence.Candidates}}

        Sanitized HTML DOM:
        {{evidence.Dom}}

        JSON schema:
        {"strategy":"name","value":"customer.name.first","role":"","exact":true,"confidence":0.98,"reason":"short reason"}
        """;

        await session.SendAsync(new MessageOptions
        {
            Prompt = prompt,
            Attachments = new List<Attachment>
            {
                new AttachmentBlob
                {
                    Data = Convert.ToBase64String(evidence.Screenshot),
                    MimeType = "image/png"
                }
            }
        });

        await done.Task.WaitAsync(TimeSpan.FromSeconds(45));
        return response.Trim();
    }

    private async Task<ILocator?> TryDeterministicAsync(ControlIntent control, string action)
    {
        var page = _browser.Page;
        var raw = control.Control;
        var friendly = Regex.Replace(raw, "([a-z0-9])([A-Z])", "$1 $2").Trim();
        var technical = raw.Contains('.') || raw.Contains('_');

        var candidates = new List<ILocator>();
        if (technical)
        {
            candidates.Add(page.Locator($"[name='{Escape(raw)}']").First);
            candidates.Add(page.Locator($"[id='{Escape(raw)}']").First);
        }
        candidates.Add(page.GetByTestId(raw));
        candidates.Add(page.GetByLabel(friendly, new PageGetByLabelOptions { Exact = true }));
        candidates.Add(page.GetByLabel(friendly, new PageGetByLabelOptions { Exact = false }));
        candidates.Add(page.GetByPlaceholder(friendly, new PageGetByPlaceholderOptions { Exact = false }));
        candidates.Add(page.GetByText(friendly, new PageGetByTextOptions { Exact = true }));

        foreach (var candidate in candidates)
        {
            if (await IsUsableAsync(candidate, action)) return candidate;
        }
        return null;
    }

    private async Task<bool> IsUsableAsync(ILocator locator, string action)
    {
        try
        {
            if (await locator.CountAsync() != 1) return false;
            if (!await locator.IsVisibleAsync()) return false;
            if (action is "click" or "fill" or "set" or "select" or "press")
            {
                if (!await locator.IsEnabledAsync()) return false;
            }
            if (action == "fill" && !await locator.IsEditableAsync()) return false;
            return true;
        }
        catch { return false; }
    }

    private Proposal? ParseProposal(string response)
    {
        try
        {
            var start = response.IndexOf('{');
            var end = response.LastIndexOf('}');
            if (start < 0 || end <= start) return null;
            var proposal = JsonSerializer.Deserialize<Proposal>(response[start..(end + 1)],
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (proposal is null || proposal.Confidence < 0.65 || string.IsNullOrWhiteSpace(proposal.Value)) return null;
            if (proposal.Strategy.Equals("xpath", StringComparison.OrdinalIgnoreCase) || proposal.Value.StartsWith("//")) return null;
            return proposal;
        }
        catch (Exception ex)
        {
            _logger.Warn($"SELF-HEAL response could not be parsed: {ex.Message}");
            return null;
        }
    }

    private ILocator CreateLocator(Proposal proposal)
    {
        var page = _browser.Page;
        return proposal.Strategy.ToLowerInvariant() switch
        {
            "testid" => page.GetByTestId(proposal.Value),
            "role" => CreateRoleLocator(page, proposal),
            "label" => page.GetByLabel(proposal.Value, new PageGetByLabelOptions { Exact = proposal.Exact }),
            "placeholder" => page.GetByPlaceholder(proposal.Value, new PageGetByPlaceholderOptions { Exact = proposal.Exact }),
            "text" => page.GetByText(proposal.Value, new PageGetByTextOptions { Exact = proposal.Exact }),
            "id" => page.Locator($"[id='{Escape(proposal.Value)}']"),
            "name" => page.Locator($"[name='{Escape(proposal.Value)}']"),
            "css" => page.Locator(proposal.Value),
            _ => page.Locator("__invalid_locator__")
        };
    }

    private static ILocator CreateRoleLocator(IPage page, Proposal proposal)
    {
        var role = proposal.Role.ToLowerInvariant() switch
        {
            "button" => AriaRole.Button,
            "textbox" => AriaRole.Textbox,
            "combobox" => AriaRole.Combobox,
            "checkbox" => AriaRole.Checkbox,
            "radio" => AriaRole.Radio,
            "link" => AriaRole.Link,
            "option" => AriaRole.Option,
            _ => AriaRole.Generic
        };
        return page.GetByRole(role, new PageGetByRoleOptions { Name = proposal.Value, Exact = proposal.Exact });
    }

    private static string Escape(string value) => value.Replace("'", "\\'");

    private sealed record Evidence(byte[] Screenshot, string Dom, string Candidates, string ImagePath, string DomPath);

    private sealed class Proposal
    {
        public string Strategy { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool Exact { get; set; } = true;
        public double Confidence { get; set; }
        public string Reason { get; set; } = string.Empty;
    }
}
