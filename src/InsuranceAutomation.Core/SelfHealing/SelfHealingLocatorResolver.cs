using System.Text.Json;
using Microsoft.Playwright;
namespace InsuranceAutomation.Core.SelfHealing;

public sealed class SelfHealingLocatorResolver : IAsyncDisposable
{
    readonly BrowserSession _browser;
    readonly SelfHealingOptions _options;
    readonly HealingCache _cache;
    readonly CopilotLocatorHealer _copilot;

    public SelfHealingLocatorResolver(BrowserSession browser, SelfHealingOptions options)
    {
        _browser=browser; _options=options; _cache=new HealingCache(options.CachePath); _copilot=new CopilotLocatorHealer(options);
    }

    public bool Enabled => _options.Enabled;
    public int PrimaryTimeoutMs => _options.PrimaryTimeoutMs;

    public async Task<ILocator> HealAsync(ILocator primary, string controlExpression, string action, string caller, Exception failure)
    {
        if (!_options.Enabled) throw failure;
        var state = ExecutionIntentContext.Current;
        var primaryText = primary.ToString();
        var key = $"{state.Feature}|{caller}|{controlExpression}";

        var cached = await _cache.GetAsync(key);
        if (cached != null)
        {
            var cachedLocator = LocatorProposalFactory.Create(_browser.Page, cached);
            if (await IsUniqueUsableAsync(cachedLocator, action))
            {
                await AuditAsync(state, action, controlExpression, primaryText, cached, "cache", "accepted", "validated cached healed locator");
                return cachedLocator;
            }
        }

        var elements = await DomContextCollector.CollectAsync(_browser.Page);
        var local = LocalProposal(controlExpression, elements);
        if (local != null)
        {
            var localLocator=LocatorProposalFactory.Create(_browser.Page, local);
            if (await IsUniqueUsableAsync(localLocator, action))
            {
                await _cache.PutAsync(key, local);
                await AuditAsync(state, action, controlExpression, primaryText, local, "deterministic", "accepted", local.Reason);
                return localLocator;
            }
        }

        var request = new HealingRequest(state.Feature,state.Scenario,state.Step,action,controlExpression,primaryText,
            _browser.Page.Url,await SafeTitleAsync(),failure.Message,elements);
        var proposal=await _copilot.ProposeAsync(request);
        if (proposal == null || proposal.Confidence < _options.MinimumConfidence)
        {
            await AuditAsync(state, action, controlExpression, primaryText, proposal, "copilot", "rejected", proposal?.Reason ?? "no valid proposal");
            throw new InvalidOperationException($"Locator healing failed for {controlExpression}. Primary: {primaryText}", failure);
        }
        var healed=LocatorProposalFactory.Create(_browser.Page,proposal);
        if (!await IsUniqueUsableAsync(healed, action))
        {
            await AuditAsync(state, action, controlExpression, primaryText, proposal, "copilot", "rejected", "proposal was not unique and usable");
            throw new InvalidOperationException($"Copilot proposed a locator that did not resolve uniquely for {controlExpression}.", failure);
        }
        await _cache.PutAsync(key,proposal);
        await AuditAsync(state, action, controlExpression, primaryText, proposal, "copilot", "accepted", proposal.Reason);
        return healed;
    }

    static LocatorProposal? LocalProposal(string controlExpression, IReadOnlyList<DomElementSnapshot> elements)
    {
        var control = controlExpression.Split('.').LastOrDefault() ?? controlExpression;
        var tokens = System.Text.RegularExpressions.Regex.Matches(control, @"[A-Z]?[a-z]+|[A-Z]+(?![a-z])|\d+").Select(m=>m.Value.ToLowerInvariant()).Where(x=>x.Length>1).ToArray();
        if (tokens.Length==0) return null;
        var ranked = elements.Select(e => new {e,score=Score(e,tokens)}).Where(x=>x.score>0).OrderByDescending(x=>x.score).ToList();
        if (ranked.Count==0 || ranked[0].score < 7) return null;
        var e=ranked[0].e;
        if (!string.IsNullOrWhiteSpace(e.TestId)) return new(){Strategy="testid",Value=e.TestId,Confidence=.90,Reason="DOM test-id matched control intent"};
        if (!string.IsNullOrWhiteSpace(e.AriaLabel)) return new(){Strategy="label",Value=e.AriaLabel,Confidence=.86,Reason="ARIA label matched control intent"};
        if (!string.IsNullOrWhiteSpace(e.Id)) return new(){Strategy="id",Value=e.Id,Confidence=.84,Reason="stable DOM id matched control intent"};
        if (!string.IsNullOrWhiteSpace(e.Name)) return new(){Strategy="name",Value=e.Name,Confidence=.80,Reason="HTML name matched control intent"};
        if (!string.IsNullOrWhiteSpace(e.Placeholder)) return new(){Strategy="placeholder",Value=e.Placeholder,Confidence=.78,Reason="placeholder matched control intent"};
        if (!string.IsNullOrWhiteSpace(e.DuckCreekId)) return new(){Strategy="duckcreekid",Value=e.DuckCreekId,Confidence=.78,Reason="Duck Creek id matched control intent"};
        return null;
    }
    static int Score(DomElementSnapshot e,string[] tokens){var hay=string.Join(' ',e.TestId,e.AriaLabel,e.Id,e.Name,e.Placeholder,e.Text,e.DuckCreekId).ToLowerInvariant();return tokens.Sum(t=>hay.Contains(t,StringComparison.Ordinal)?3:0)+(string.IsNullOrWhiteSpace(e.TestId)?0:2)+(string.IsNullOrWhiteSpace(e.AriaLabel)?0:1);}
    static async Task<bool> IsUniqueUsableAsync(ILocator l,string action){try{if(await l.CountAsync()!=1||!await l.IsVisibleAsync())return false;if(action is "click" or "select" or "smart-set")return await l.IsEnabledAsync();if(action is "fill" or "press")return await l.IsEditableAsync();return true;}catch{return false;}}
    async Task<string> SafeTitleAsync(){try{return await _browser.Page.TitleAsync();}catch{return "";}}
    async Task AuditAsync(ExecutionIntentContext.State state,string action,string expression,string primary,LocatorProposal? p,string provider,string outcome,string reason)
    {
        var dir=Path.GetDirectoryName(_options.AuditPath);if(!string.IsNullOrWhiteSpace(dir))Directory.CreateDirectory(dir);
        var record=new HealingAudit(DateTimeOffset.UtcNow,state.Feature,state.Scenario,state.Step,action,expression,primary,p==null?null:$"{p.Strategy}:{p.Value}",provider,p?.Confidence??0,outcome,reason);
        await File.AppendAllTextAsync(_options.AuditPath,JsonSerializer.Serialize(record)+Environment.NewLine);
    }
    public ValueTask DisposeAsync()=>_copilot.DisposeAsync();
}
