#!/usr/bin/env python3
import json,re
from pathlib import Path
ROOT=Path(__file__).resolve().parents[1]
APPS={'CommercialLines.ExpertQuote':'CommercialLines.ExpertQuote.Tests','CommercialLines.DuckCreek':'CommercialLines.DuckCreek.Tests','PersonalLines.DuckCreek':'PersonalLines.DuckCreek.Tests'}
PROP=re.compile(r'(public\s+ILocator\s+(\w+)\s*=>\s*)(.*?)(;)',re.S)
def esc(s):return s.replace('\\','\\\\').replace('"','\\"')
def expr(c):
 v=esc(c['value']); st=c['strategy'].lower(); role=c.get('role','').capitalize();
 frame=c.get('frameValue',''); root='_page'
 if frame: root=f'_page.FrameLocator("{esc(frame)}")'
 if st=='id': return f'{root}.Locator("[id=\\\"{v}\\\"]")'
 if st=='name': return f'{root}.Locator("[name=\\\"{v}\\\"]")'
 if st=='duckcreekid': return f'{root}.Locator("[duckcreekid=\\\"{v}\\\"], [data-duckcreekid=\\\"{v}\\\"]")'
 if st=='testid': return f'{root}.GetByTestId("{v}")'
 if st=='css': return f'{root}.Locator("{v}")'
 if st=='label': return f'{root}.GetByLabel("{v}", new() {{ Exact = true }})'
 if st=='role' and role:return f'{root}.GetByRole(AriaRole.{role}, new() {{ Name = "{v}", Exact = true }})'
 return None
for app,proj in APPS.items():
 d=json.load(open(ROOT/'Artifacts'/'LocatorFallbackCatalogs'/f'{app}.json')); by={(c['page'],c['control']):c for c in d['controls']}
 changed=0; framechanged=0
 for p in (ROOT/'tests'/proj/'Pages'/'Locators').glob('*Locators.cs'):
  page=p.name.replace('Locators.cs',''); text=p.read_text();
  def repl(m):
   nonlocal_dummy=None
   name=m.group(2); old=m.group(3).strip(); c=by.get((page,name))
   if not c or c.get('aliasOf'):return m.group(0)
   # Keep already-technical source selectors unless raw Tosca explicitly supplies frame context.
   generic=('GetByRole(' in old or 'GetByLabel(' in old or 'GetByText(' in old or 'GetByPlaceholder(' in old)
   cand=None
   priority={'css':5,'duckcreekid':4,'id':3,'testid':2,'name':1}
   choices=[x for x in c.get('candidates',[]) if x.get('confidence',0)>=0.98 and x.get('strategy') in priority]
   choices.sort(key=lambda x:(x.get('matchScore',0),x.get('confidence',0),priority[x['strategy']],bool(x.get('frameValue'))),reverse=True)
   if choices:cand=choices[0]
   if not cand:return m.group(0)
   if not generic and not cand.get('frameValue'):return m.group(0)
   ne=expr(cand)
   if not ne:return m.group(0)
   repl.changed+=1; repl.framechanged+=bool(cand.get('frameValue') and cand.get('frameValue')!='iframe')
   comment=f'// v56 raw Tosca primary: {cand.get("sourceModule","")} | {cand.get("sourceField","")} | {cand.get("sourceProperty","")}'+(f' | frame={cand.get("frameValue")}' if cand.get('frameValue') else '')+'\n    '
   return comment+m.group(1)+ne+m.group(4)
  repl.changed=0;repl.framechanged=0
  new=PROP.sub(repl,text)
  if new!=text:p.write_text(new);changed+=repl.changed;framechanged+=repl.framechanged
 print(app,'promoted',changed,'frame-primary',framechanged)
