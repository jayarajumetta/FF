using System.Text.Json; using Microsoft.Playwright;
namespace InsuranceAutomation.Core;
public sealed record LocatorSpec(string Id,string Strategy,string Value,string Role="");
public sealed class LocatorRepository {
 readonly Dictionary<string,LocatorSpec> _specs=new();
 public void Load(string catalogFile,string fallbackFile){
  _specs.Clear(); using var doc=JsonDocument.Parse(File.ReadAllText(catalogFile));
  foreach(var item in doc.RootElement.GetProperty("definitions").EnumerateArray()){
   var id=item.GetProperty("id").GetString()??""; if(!item.TryGetProperty("candidates",out var candidates)||candidates.GetArrayLength()==0) continue;
   var c=candidates[0]; _specs[id]=new LocatorSpec(id,c.GetProperty("strategy").GetString()??"Css",c.GetProperty("value").GetString()??"",c.TryGetProperty("role",out var role)?role.GetString()??"":"");
  }
  if(File.Exists(fallbackFile)){using var f=JsonDocument.Parse(File.ReadAllText(fallbackFile));foreach(var p in f.RootElement.EnumerateObject())_specs[p.Name]=new LocatorSpec(p.Name,"LabelOrText",p.Value.GetString()??"");}
 }
 public ILocator Get(IPage page,string id){
  if(!_specs.TryGetValue(id,out var s)) throw new KeyNotFoundException("Locator not found: "+id);
  if(s.Strategy=="TestId") return page.GetByTestId(s.Value);
  if(s.Strategy=="Role") return page.GetByRole(ParseRole(s.Role),new(){Name=s.Value,Exact=true});
  if(s.Strategy=="Label") return page.GetByLabel(s.Value,new(){Exact=true});
  if(s.Strategy=="Text") return page.GetByText(s.Value,new(){Exact=true});
  if(s.Strategy=="Name") return page.Locator("[name=\""+s.Value.Replace("\"","\\\"")+"\"]");
  if(s.Strategy=="XPath") return page.Locator("xpath="+s.Value);
  if(s.Strategy=="LabelOrText") return page.GetByLabel(s.Value,new(){Exact=true}).Or(page.GetByText(s.Value,new(){Exact=true}));
  if(s.Strategy=="Id") return page.Locator("#"+CssEscape(s.Value));
  return page.Locator(s.Value);
 }
 static AriaRole ParseRole(string role)=>Enum.TryParse<AriaRole>(role,true,out var parsed)?parsed:AriaRole.Button;
 static string CssEscape(string value)=>value.Replace(":","\\:").Replace(".","\\.");
}
