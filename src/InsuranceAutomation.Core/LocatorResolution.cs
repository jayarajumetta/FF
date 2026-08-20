using Microsoft.Playwright;

namespace InsuranceAutomation.Core;

public enum LocatorPick { Unique, First, Last, Nth }
public sealed record LocatorSpec(string Strategy,string Value,string? Role=null,string? AnchorStrategy=null,string? AnchorValue=null,LocatorPick Pick=LocatorPick.Unique,int Index=0,bool Exact=true,string? SourceModule=null,string? SourceField=null);

public static class LocatorResolution
{
    public static ILocator Build(IPage page, LocatorSpec spec)
    {
        var locator=string.IsNullOrWhiteSpace(spec.AnchorStrategy)
            ? Raw(page,spec.Strategy,spec.Value,spec.Role,spec.Exact)
            : Raw(Raw(page,spec.AnchorStrategy!,spec.AnchorValue??string.Empty,null,true),spec.Strategy,spec.Value,spec.Role,spec.Exact);
        return spec.Pick switch { LocatorPick.First=>locator.First, LocatorPick.Last=>locator.Last, LocatorPick.Nth=>locator.Nth(spec.Index), _=>locator };
    }
    private static ILocator Raw(IPage p,string s,string v,string? r,bool e)=>s.ToLowerInvariant() switch
    {"testid"=>p.GetByTestId(v),"id"=>p.Locator($"[id=\"{Esc(v)}\"]"),"name"=>p.Locator($"[name=\"{Esc(v)}\"]"),"duckcreekid"=>p.Locator($"[duckcreekid=\"{Esc(v)}\"], [data-duckcreekid=\"{Esc(v)}\"]"),"label"=>p.GetByLabel(v,new(){Exact=e}),"placeholder"=>p.GetByPlaceholder(v,new(){Exact=e}),"text"=>p.GetByText(v,new(){Exact=e}),"title"=>p.GetByTitle(v,new(){Exact=e}),"role"=>p.GetByRole(Role(r),new(){Name=v,Exact=e}),"css"=>p.Locator(v),_=>p.Locator(v)};
    private static ILocator Raw(ILocator p,string s,string v,string? r,bool e)=>s.ToLowerInvariant() switch
    {"testid"=>p.GetByTestId(v),"id"=>p.Locator($"[id=\"{Esc(v)}\"]"),"name"=>p.Locator($"[name=\"{Esc(v)}\"]"),"duckcreekid"=>p.Locator($"[duckcreekid=\"{Esc(v)}\"], [data-duckcreekid=\"{Esc(v)}\"]"),"label"=>p.GetByLabel(v,new(){Exact=e}),"placeholder"=>p.GetByPlaceholder(v,new(){Exact=e}),"text"=>p.GetByText(v,new(){Exact=e}),"title"=>p.GetByTitle(v,new(){Exact=e}),"role"=>p.GetByRole(Role(r),new(){Name=v,Exact=e}),"css"=>p.Locator(v),_=>p.Locator(v)};
    private static AriaRole Role(string? r)=>(r??"").ToLowerInvariant() switch {"button"=>AriaRole.Button,"textbox"=>AriaRole.Textbox,"checkbox"=>AriaRole.Checkbox,"radio"=>AriaRole.Radio,"combobox"=>AriaRole.Combobox,"link"=>AriaRole.Link,"heading"=>AriaRole.Heading,"option"=>AriaRole.Option,"tab"=>AriaRole.Tab,"menuitem"=>AriaRole.Menuitem,"switch"=>AriaRole.Switch,_=>AriaRole.Generic};
    private static string Esc(string v)=>v.Replace("\\","\\\\").Replace("\"","\\\"");
}
