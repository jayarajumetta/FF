using Microsoft.Playwright;

namespace InsuranceAutomation.Core;

public sealed class UiActions
{
    private readonly LlmLocatorHealer _healer;
    private readonly RunLogger _logger;

    public UiActions(BrowserSession browser, FrameworkConfig config, RunLogger logger)
    {
        _logger = logger;
        _healer = new LlmLocatorHealer(browser, config, logger);
    }

    public Task ClickAsync(ILocator locator) => ClickAsync(locator, new ControlIntent("Application", "Control"));
    public Task FillAsync(ILocator locator, string value) => FillAsync(locator, value, new ControlIntent("Application", "Control"));
    public Task ClickAsync(ILocator locator, ControlIntent intent) => ExecuteAsync(locator,intent,"click",x=>x.ClickAsync());
    public Task FillAsync(ILocator locator,string value,ControlIntent intent) => ExecuteAsync(locator,intent,"fill",x=>x.FillAsync(value??string.Empty));
    public Task PressAsync(ILocator locator,string key,ControlIntent intent) => ExecuteAsync(locator,intent,"press",x=>x.PressAsync(NormalizeKey(key)));

    public Task SmartSetAsync(ILocator locator,string value,ControlIntent intent) => ExecuteAsync(locator,intent,"set",async x=>
    {
        var type=(await x.GetAttributeAsync("type")??"").ToLowerInvariant();
        if(type is "checkbox" or "radio") { await x.SetCheckedAsync(!value.Equals("false",StringComparison.OrdinalIgnoreCase)&&!value.Equals("no",StringComparison.OrdinalIgnoreCase)); return; }
        var tag=await x.EvaluateAsync<string>("e=>e.tagName.toLowerCase()");
        if(tag=="select") { await x.SelectOptionAsync(new SelectOptionValue{Label=value}); return; }
        await x.FillAsync(value??string.Empty);
    });

    public Task SelectAsync(ILocator locator,string value,ControlIntent intent) => ExecuteAsync(locator,intent,"select",async x=>
    {
        try { await x.SelectOptionAsync(new SelectOptionValue{Label=value}); }
        catch(PlaywrightException) { await x.ClickAsync(); await x.PressAsync("Home"); await x.PressAsync("ArrowDown"); }
    });

    public async Task<bool> ExistsAsync(ILocator locator)
    {
        try { return await locator.CountAsync()>0 && await locator.First.IsVisibleAsync(); } catch { return false; }
    }

    public Task WaitAsync(ILocator locator,string expected,ControlIntent intent) =>
        expected.Contains("Absent",StringComparison.OrdinalIgnoreCase)
            ? locator.WaitForAsync(new LocatorWaitForOptions{State=WaitForSelectorState.Detached})
            : ExecuteAsync(locator,intent,"wait-visible",x=>x.WaitForAsync(new LocatorWaitForOptions{State=WaitForSelectorState.Visible}));

    public async Task VerifyAsync(ILocator locator,string expected,string property,ControlIntent intent)
    {
        if(expected.Equals("Visible",StringComparison.OrdinalIgnoreCase)||expected.Equals("Exists",StringComparison.OrdinalIgnoreCase)||expected.Equals("True",StringComparison.OrdinalIgnoreCase))
        {
            await ExecuteAsync(locator,intent,"verify-visible",async x=>{ if(await x.CountAsync()==0) throw new TimeoutException("Expected control to exist."); await x.WaitForAsync(new(){State=WaitForSelectorState.Visible}); });
            return;
        }
        var actual=await CaptureAsync(locator,property,intent);
        if(!string.Equals(actual,expected,StringComparison.OrdinalIgnoreCase)) throw new InvalidOperationException($"Expected '{expected}' but found '{actual}'.");
    }

    public Task<string> CaptureAsync(ILocator locator,string property,ControlIntent intent)=>ExecuteAsync(locator,intent,"capture",async x=>
    {
        if(property.Contains("Value",StringComparison.OrdinalIgnoreCase)) { try { return await x.InputValueAsync(); } catch { } }
        try { return (await x.InnerTextAsync()).Trim(); } catch { return (await x.TextContentAsync()??"").Trim(); }
    });

    public Task ReviewRequiredAsync(string reason) { _logger.Warn($"SOURCE TRACE NOTE: {reason}"); return Task.CompletedTask; }

    private async Task ExecuteAsync(ILocator locator,ControlIntent intent,string action,Func<ILocator,Task> op)
    {
        try { await op(locator); }
        catch(Exception ex) when(IsLocatorFailure(ex)) { var healed=await _healer.TryHealAsync(locator,intent,action,ex); if(healed is null) throw; await op(healed); }
    }
    private async Task<T> ExecuteAsync<T>(ILocator locator,ControlIntent intent,string action,Func<ILocator,Task<T>> op)
    {
        try { return await op(locator); }
        catch(Exception ex) when(IsLocatorFailure(ex)) { var healed=await _healer.TryHealAsync(locator,intent,action,ex); if(healed is null) throw; return await op(healed); }
    }
    private static bool IsLocatorFailure(Exception ex)
    {
        if(ex is not PlaywrightException and not TimeoutException) return false;
        var m=ex.Message.ToLowerInvariant();
        if(m.Contains("target closed")||m.Contains("browser has been closed")||m.Contains("page closed")||m.Contains("context closed")) return false;
        return ex is TimeoutException||m.Contains("timeout")||m.Contains("locator")||m.Contains("strict mode")||m.Contains("not visible")||m.Contains("not enabled")||m.Contains("not editable")||m.Contains("not attached");
    }
    private static string NormalizeKey(string key)=>key.Replace("POST:","",StringComparison.OrdinalIgnoreCase).Replace("PRE:","",StringComparison.OrdinalIgnoreCase).Replace("{TAB}","Tab",StringComparison.OrdinalIgnoreCase).Replace("{ENTER}","Enter",StringComparison.OrdinalIgnoreCase).Replace("{ESC}","Escape",StringComparison.OrdinalIgnoreCase);
}
