using System.Runtime.CompilerServices;
using Microsoft.Playwright;
using InsuranceAutomation.Core.SelfHealing;
namespace InsuranceAutomation.Core;

public sealed class PageUiActions : IAsyncDisposable
{
    readonly BrowserSession _browser;
    readonly SelfHealingLocatorResolver _healer;
    public PageUiActions(BrowserSession browser)
    {
        _browser=browser;
        _healer=new SelfHealingLocatorResolver(browser,new SelfHealingOptions());
    }

    async Task RunAsync(ILocator locator, string action, Func<ILocator,Task> run, string expression, string caller)
    {
        try { await run(locator); }
        catch(Exception ex) when (_healer.Enabled && IsHealEligible(ex))
        {
            var healed=await _healer.HealAsync(locator,expression,action,caller,ex);
            await run(healed);
        }
    }
    async Task<T> RunAsync<T>(ILocator locator, string action, Func<ILocator,Task<T>> run, string expression, string caller)
    {
        try { return await run(locator); }
        catch(Exception ex) when (_healer.Enabled && IsHealEligible(ex))
        {
            var healed=await _healer.HealAsync(locator,expression,action,caller,ex);
            return await run(healed);
        }
    }
    float? Timeout => _healer.Enabled ? _healer.PrimaryTimeoutMs : null;

    static bool IsHealEligible(Exception ex)
    {
        if (ex is not PlaywrightException and not TimeoutException) return false;
        var m=ex.Message.ToLowerInvariant();
        if (m.Contains("target closed")||m.Contains("browser has been closed")||m.Contains("page closed")||m.Contains("context closed")) return false;
        return m.Contains("timeout")||m.Contains("locator")||m.Contains("strict mode")||m.Contains("not visible")||m.Contains("not enabled")||m.Contains("not editable")||m.Contains("not attached")||ex is TimeoutException;
    }

    public Task ClickAsync(ILocator l,[CallerArgumentExpression("l")]string e="",[CallerMemberName]string c="") =>
        RunAsync(l,"click",x=>x.ClickAsync(new(){Timeout=Timeout}),e,c);

    public Task FillAsync(ILocator l,string value,[CallerArgumentExpression("l")]string e="",[CallerMemberName]string c="") =>
        RunAsync(l,"fill",async x=>{await x.ClickAsync(new(){Timeout=Timeout});await x.FillAsync("",new(){Timeout=Timeout});await x.PressSequentiallyAsync(value??"",new(){Timeout=Timeout});},e,c);

    public Task SmartSetAsync(ILocator l,string value,[CallerArgumentExpression("l")]string e="",[CallerMemberName]string c="") =>
        RunAsync(l,"smart-set",async x=>{var type=await x.GetAttributeAsync("type");if(type is "checkbox" or "radio"){if(value.Equals("false",StringComparison.OrdinalIgnoreCase)||value.Equals("no",StringComparison.OrdinalIgnoreCase))await x.UncheckAsync(new(){Timeout=Timeout});else await x.CheckAsync(new(){Timeout=Timeout});return;}var tag=await x.EvaluateAsync<string>("e=>e.tagName.toLowerCase()");if(tag=="select"){await x.SelectOptionAsync(new SelectOptionValue{Label=value},new(){Timeout=Timeout});return;}await x.ClickAsync(new(){Timeout=Timeout});await x.FillAsync("",new(){Timeout=Timeout});await x.PressSequentiallyAsync(value??"",new(){Timeout=Timeout});},e,c);

    public Task SelectAsync(ILocator l,string value,[CallerArgumentExpression("l")]string e="",[CallerMemberName]string c="") =>
        RunAsync(l,"select",async x=>{try{await x.SelectOptionAsync(new SelectOptionValue{Label=value},new(){Timeout=Timeout});}catch{await x.ClickAsync(new(){Timeout=Timeout});await _browser.Page.GetByRole(AriaRole.Option,new(){Name=value,Exact=true}).ClickAsync(new(){Timeout=Timeout});}},e,c);

    public Task PressAsync(ILocator l,string key,[CallerArgumentExpression("l")]string e="",[CallerMemberName]string c="") =>
        RunAsync(l,"press",x=>x.PressAsync(key.Replace("POST:",""),new(){Timeout=Timeout}),e,c);

    // Exists is often a branch probe; a legitimate absence must not invoke AI and alter business flow.
    public async Task<bool> ExistsAsync(ILocator l)=>await l.CountAsync()>0;

    public async Task WaitAsync(ILocator l,string expected,[CallerArgumentExpression("l")]string e="",[CallerMemberName]string c="")
    {
        if(expected.Contains("Absent",StringComparison.OrdinalIgnoreCase)||expected.Contains("not",StringComparison.OrdinalIgnoreCase))
        { await l.WaitForAsync(new(){State=WaitForSelectorState.Detached,Timeout=Timeout}); return; }
        await RunAsync(l,"wait-visible",x=>x.WaitForAsync(new(){State=WaitForSelectorState.Visible,Timeout=Timeout}),e,c);
    }

    public async Task VerifyAsync(ILocator l,string expected,string property,[CallerArgumentExpression("l")]string e="",[CallerMemberName]string c="")
    {
        if(expected.Equals("Visible",StringComparison.OrdinalIgnoreCase)||expected.Equals("Exists",StringComparison.OrdinalIgnoreCase)||expected.Equals("True",StringComparison.OrdinalIgnoreCase))
        {
            await RunAsync(l,"verify-visible",async x=>{if(await x.CountAsync()==0)throw new TimeoutException("Expected control to exist.");await x.WaitForAsync(new(){State=WaitForSelectorState.Visible,Timeout=Timeout});},e,c);return;
        }
        var actual=await CaptureAsync(l,property,e,c);if(!string.Equals(actual,expected,StringComparison.OrdinalIgnoreCase))throw new InvalidOperationException($"Expected '{expected}' but found '{actual}'.");
    }

    public Task<string> CaptureAsync(ILocator l,string property="",[CallerArgumentExpression("l")]string e="",[CallerMemberName]string c="") =>
        RunAsync(l,"capture",async x=>{if(property.Contains("Value",StringComparison.OrdinalIgnoreCase)){try{return await x.InputValueAsync(new(){Timeout=Timeout});}catch{}}try{return (await x.InnerTextAsync(new(){Timeout=Timeout})).Trim();}catch{return (await x.TextContentAsync(new(){Timeout=Timeout})??"").Trim();}},e,c);

    public Task ReviewRequiredAsync(string reason)=>throw new InvalidOperationException("Review required: "+reason);
    public ValueTask DisposeAsync()=>_healer.DisposeAsync();
}
