#!/usr/bin/env python3
from __future__ import annotations
import json,re
from pathlib import Path
ROOT=Path(__file__).resolve().parents[1]
APP='CommercialLines.DuckCreek'; PROJ='CommercialLines.DuckCreek.Tests'
PROP=re.compile(r'(public\s+ILocator\s+(\w+)\s*=>\s*)(.*?)(;)',re.S)

def esc(s): return str(s).replace('\\','\\\\').replace('"','\\"')
def xpath_lit(v):
 v=str(v)
 if "'" not in v:return "'"+v+"'"
 if '"' not in v:return '"'+v+'"'
 parts=v.split("'")
 return 'concat('+', "\\\'", '.join("'"+x+"'" for x in parts)+')'
def associated_xpath(v):
 q=xpath_lit(str(v).strip())
 return "(//*[@id = //label[normalize-space(string(.))="+q+"]/@for] | //label[normalize-space(string(.))="+q+"]//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))="+q+"]/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])"

def rank(c):
 s=c.get('strategy','').lower(); pick=c.get('pick','unique').lower()
 return {'fieldref':1000,'id':900,'name':800,'testid':700,'associatedlabel':600,'label':590,'role':500,'css':350,'xpath':200,'text':150}.get(s,100) + (25 if c.get('anchorStrategy') else 0) - (50 if pick in {'first','nth','last'} else 0)

def role_name(r):
 return {'button':'Button','textbox':'Textbox','checkbox':'Checkbox','radio':'Radio','combobox':'Combobox','link':'Link','heading':'Heading','option':'Option','tab':'Tab','menuitem':'Menuitem','switch':'Switch'}.get(str(r).lower(),'Generic')

def expr(c):
 s=c.get('strategy','').lower(); v=esc(c.get('value','')); base=None
 if s=='fieldref': base=f'_page.Locator("[fieldref=\\"{v}\\"], [data-fieldref=\\"{v}\\"]")'
 elif s=='id': base=f'_page.Locator("[id=\\"{v}\\"]")'
 elif s=='name': base=f'_page.Locator("[name=\\"{v}\\"]")'
 elif s=='testid': base=f'_page.GetByTestId("{v}")'
 elif s in {'associatedlabel','label'}: base=f'_page.Locator("xpath={esc(associated_xpath(c.get("value","")))}")'
 elif s=='role': base=f'_page.GetByRole(AriaRole.{role_name(c.get("role"))}, new() {{ Name = "{v}", Exact = true }})'
 elif s=='css': base=f'_page.Locator("{v}")'
 elif s=='xpath': base=f'_page.Locator("xpath={v}")'
 elif s=='text': base=f'_page.GetByText("{v}", new() {{ Exact = true }})'
 if not base:return None
 if c.get('hasText'): base += f'.Filter(new() {{ HasText = "{esc(c["hasText"])}" }})'
 pick=c.get('pick','unique').lower()
 if pick=='first':base+='.First'
 elif pick=='last':base+='.Last'
 elif pick=='nth':base+=f'.Nth({int(c.get("index",0))})'
 return base

data=json.loads((ROOT/'Artifacts/LocatorFallbackCatalogs'/f'{APP}.json').read_text())
by={(c['page'],c['control']):c for c in data['controls']}
stats={'fieldrefPromoted':0,'duckCreekIdRemoved':0,'genericPromoted':0,'unresolvedDuckCreekId':[]}
for path in sorted((ROOT/'tests'/PROJ/'Pages'/'Locators').glob('*Locators.cs')):
 page=path.name.replace('Locators.cs',''); text=path.read_text()
 def repl(m):
  name=m.group(2); old=m.group(3).strip(); ctl=by.get((page,name))
  if not ctl or ctl.get('aliasOf'):return m.group(0)
  choices=[x for x in ctl.get('candidates',[]) if x.get('strategy','').lower()!='duckcreekid']
  choices.sort(key=lambda x:(rank(x),int(x.get('matchScore',0)),float(x.get('confidence',0))),reverse=True)
  unique_field=[x for x in choices if x.get('strategy','').lower()=='fieldref' and float(x.get('confidence',0))>=0.90]
  old_duck='duckcreekid' in old.lower() or 'data-duckcreekid' in old.lower()
  generic=any(x in old for x in ('GetByRole(','GetByLabel(','GetByText(','GetByPlaceholder('))
  cand=None
  if unique_field:cand=unique_field[0]
  elif old_duck:
   viable=[x for x in choices if float(x.get('confidence',0))>=0.60 and int(x.get('matchScore',0))>=78]
   if viable:cand=viable[0]
  elif generic:
   viable=[x for x in choices if rank(x)>=500 and float(x.get('confidence',0))>=0.75]
   if viable:cand=viable[0]
  if not cand:
   if old_duck:stats['unresolvedDuckCreekId'].append(f'{page}.{name}')
   return m.group(0)
  ne=expr(cand)
  if not ne:return m.group(0)
  if old_duck:stats['duckCreekIdRemoved']+=1
  if cand.get('strategy','').lower()=='fieldref':stats['fieldrefPromoted']+=1
  elif generic:stats['genericPromoted']+=1
  comment=f'// v57 raw Tosca primary: {cand.get("sourceModule","")} | {cand.get("sourceField","")} | {cand.get("sourceProperty","")} | strategy={cand.get("strategy","")}\n    '
  return comment+m.group(1)+ne+m.group(4)
 new=PROP.sub(repl,text)
 if new!=text:path.write_text(new)
# Hard contract: raw CL|DC login IDs/link semantics supplied by source/runtime review. Do not use DuckCreekId.
p=ROOT/'tests'/PROJ/'Pages'/'Locators'/'LoginLocators.cs'; t=p.read_text()
t=re.sub(r'public ILocator Login\s*=>.*?;', 'public ILocator Login => _page.GetByRole(AriaRole.Link, new() { Name = "Login", Exact = true });', t)
t=re.sub(r'public ILocator Password\s*=>.*?;', 'public ILocator Password => _page.Locator("[id=\\"password-inputEl\\"]");', t)
t=re.sub(r'public ILocator UserName\s*=>.*?;', 'public ILocator UserName => _page.Locator("[id=\\"username-inputEl\\"]");', t)
t=t.replace('Page.Locator(', '_page.Locator(')
p.write_text(t)
# Count remaining raw-generated DuckCreekId primaries after replacements.
remaining=[]
for p in (ROOT/'tests'/PROJ/'Pages'/'Locators').glob('*Locators.cs'):
 for i,l in enumerate(p.read_text().splitlines(),1):
  if 'duckcreekid' in l.lower() and 'public ILocator' in l:remaining.append(f'{p.name}:{i}')
stats['remainingDuckCreekIdPrimary']=remaining
(ROOT/'Artifacts'/'V57PrimaryLocatorPromotion.json').write_text(json.dumps(stats,indent=2)+'\n')
print(json.dumps(stats,indent=2))
