using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;
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

    public async Task<ILocator?> TryHealAsync(string controlExpression, string action, Exception failure)
    {
        if (!Enabled) return null;

        var local = await TryDeterministicAsync(controlExpression, action);
        if (local is not null)
        {
            _logger.Warn($"SELF-HEAL local fallback accepted for {controlExpression}.");
            return local;
        }

        if (!CommandExists("copilot"))
        {
            _logger.Warn("GitHub Copilot CLI is not installed. Deterministic self-heal was attempted; AI fallback skipped.");
            return null;
        }

        var candidates = await CollectDomCandidatesAsync();
        var prompt = BuildPrompt(controlExpression, action, failure.Message, candidates);
        var response = await RunCopilotAsync(prompt);
        var proposal = ParseProposal(response);
        if (proposal is null) return null;

        var locator = CreateLocator(proposal);
        if (!await IsUsableAsync(locator, action))
        {
            _logger.Warn($"Copilot proposed locator was rejected: {response}");
            return null;
        }

        _logger.Warn($"SELF-HEAL Copilot locator accepted for {controlExpression}: {proposal.Strategy}:{proposal.Value}");
        return locator;
    }

    private async Task<ILocator?> TryDeterministicAsync(string expression, string action)
    {
        var name = expression.Split('.').LastOrDefault() ?? expression;
        var friendly = Regex.Replace(name, "([a-z0-9])([A-Z])", "$1 $2").Trim();
        if (string.IsNullOrWhiteSpace(friendly)) return null;

        var page = _browser.Page;
        var candidates = new ILocator[]
        {
            page.GetByLabel(friendly, new PageGetByLabelOptions { Exact = true }),
            page.GetByLabel(friendly, new PageGetByLabelOptions { Exact = false }),
            page.GetByPlaceholder(friendly, new PageGetByPlaceholderOptions { Exact = false }),
            page.GetByText(friendly, new PageGetByTextOptions { Exact = true }),
            page.GetByTestId(name),
            page.Locator($"[name='{Escape(name)}']"),
            page.Locator($"[id='{Escape(name)}']")
        };

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
            if (action is "click" or "fill" or "smart-set" or "select" or "press")
            {
                if (!await locator.IsEnabledAsync()) return false;
            }

            if (action is "fill" or "smart-set")
            {
                try
                {
                    if (!await locator.IsEditableAsync()) return false;
                }
                catch
                {
                    // checkbox/radio controls are not editable but can still be smart-set.
                    if (action == "fill") return false;
                }
            }

            return true;
        }
        catch
        {
            return false;
        }
    }

    private async Task<string> CollectDomCandidatesAsync()
    {
        try
        {
            return await _browser.Page.Locator("input,select,textarea,button,a,[role],[data-testid]").EvaluateAllAsync<string>(
                "els => JSON.stringify(els.slice(0,250).map(e => ({tag:e.tagName.toLowerCase(),id:e.id||'',name:e.getAttribute('name')||'',role:e.getAttribute('role')||'',aria:e.getAttribute('aria-label')||'',placeholder:e.getAttribute('placeholder')||'',testid:e.getAttribute('data-testid')||'',text:(e.innerText||'').trim().slice(0,100)})))");
        }
        catch
        {
            return "[]";
        }
    }

    private string BuildPrompt(string controlExpression, string action, string failure, string candidates) =>
        $$"""
        You are a locator-repair assistant for a Playwright C# insurance test.
        Return ONE JSON object only. No markdown. No code. Do not change the business action.
        Allowed strategies: testid, label, placeholder, text, id, name, css.
        Prefer testid, accessible label, stable id/name, then concise css. Never XPath.

        Control intent: {{controlExpression}}
        Original action: {{action}}
        Current URL: {{_browser.Page.Url}}
        Failure: {{failure}}
        Sanitized DOM candidates: {{candidates}}

        Required JSON shape:
        {"strategy":"label","value":"Street Address","exact":true,"confidence":0.95}
        """;

    private static async Task<string> RunCopilotAsync(string prompt)
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = "copilot",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        startInfo.ArgumentList.Add("-p");
        startInfo.ArgumentList.Add(prompt);
        startInfo.ArgumentList.Add("-s");
        startInfo.ArgumentList.Add("--no-ask-user");
        startInfo.ArgumentList.Add("--no-custom-instructions");
        startInfo.ArgumentList.Add("--no-remote");

        using var process = Process.Start(startInfo) ?? throw new InvalidOperationException("Unable to start GitHub Copilot CLI.");
        var output = await process.StandardOutput.ReadToEndAsync();
        await process.WaitForExitAsync();
        return output.Trim();
    }

    private Proposal? ParseProposal(string response)
    {
        try
        {
            var start = response.IndexOf('{');
            var end = response.LastIndexOf('}');
            if (start < 0 || end <= start) return null;
            var proposal = JsonSerializer.Deserialize<Proposal>(response[start..(end + 1)], new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (proposal is null || proposal.Confidence < 0.60 || string.IsNullOrWhiteSpace(proposal.Value)) return null;
            return proposal;
        }
        catch (Exception ex)
        {
            _logger.Warn($"Unable to parse Copilot locator proposal: {ex.Message}");
            return null;
        }
    }

    private ILocator CreateLocator(Proposal proposal)
    {
        var page = _browser.Page;
        return proposal.Strategy.ToLowerInvariant() switch
        {
            "testid" => page.GetByTestId(proposal.Value),
            "label" => page.GetByLabel(proposal.Value, new PageGetByLabelOptions { Exact = proposal.Exact }),
            "placeholder" => page.GetByPlaceholder(proposal.Value, new PageGetByPlaceholderOptions { Exact = proposal.Exact }),
            "text" => page.GetByText(proposal.Value, new PageGetByTextOptions { Exact = proposal.Exact }),
            "id" => page.Locator($"[id='{Escape(proposal.Value)}']"),
            "name" => page.Locator($"[name='{Escape(proposal.Value)}']"),
            "css" => page.Locator(proposal.Value),
            _ => page.Locator("__invalid_locator__")
        };
    }

    private static string Escape(string value) => value.Replace("'", "\\'");

    private static bool CommandExists(string command)
    {
        try
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = OperatingSystem.IsWindows() ? "where" : "which",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            startInfo.ArgumentList.Add(command);
            using var process = Process.Start(startInfo);
            process?.WaitForExit(3000);
            return process?.ExitCode == 0;
        }
        catch
        {
            return false;
        }
    }

    private sealed class Proposal
    {
        public string Strategy { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public bool Exact { get; set; } = true;
        public double Confidence { get; set; }
    }
}
