#!/usr/bin/env python3
from __future__ import annotations
import gzip,json,sys,re,hashlib
from pathlib import Path
ROOT=Path(__file__).resolve().parents[1]
OUT=ROOT/'Artifacts'/'ToscaFrameContexts.v56.json'

def load(p):
 with gzip.open(p,'rt',encoding='utf-8') as f:return json.load(f).get('Entities',[])
def params(e,by):
 out={}
 for gid in (e.get('Assocs') or {}).get('Properties',[]) or []:
  x=by.get(gid) or {}; a=x.get('Attributes') or {}
  if x.get('ObjectClass')=='XParam' and a.get('Name') and a.get('Value'):out[str(a['Name'])]=str(a['Value'])
 return out
def frame_selector(props):
 for k in ('Id','attributes_id'):
  v=props.get(k,'').strip()
  if v:
   if v.endswith('*') and '*' not in v[:-1]: return {'strategy':'css','value':f'[id^="{v[:-1]}"]','sourceProperty':k}
   if '*' not in v:return {'strategy':'id','value':v,'sourceProperty':k}
 for k in ('Name','name'):
  v=props.get(k,'').strip()
  if v:return {'strategy':'css','value':f'iframe[name="{v}"]','sourceProperty':k}
 return {'strategy':'css','value':'iframe','sourceProperty':'Tag'}
def app_for(p):
 n=p.name.lower()
 if n.startswith('cl_eq') or 'cl-eq total' in n:return 'CommercialLines.ExpertQuote'
 if n.startswith('cl-dc'):return 'CommercialLines.DuckCreek'
 if n.startswith('pl_dc'):return 'PersonalLines.DuckCreek'
 return 'Unknown'
def main(args):
 paths=[]
 for a in args:
  p=Path(a); paths += list(p.rglob('*.tsu')) if p.is_dir() else [p]
 rows=[]
 for p in paths:
  try: es=load(p)
  except: continue
  by={e.get('Surrogate'):e for e in es}; owners={}
  for m in es:
   if m.get('ObjectClass') not in ('XModule','ApiModule'):continue
   mn=str((m.get('Attributes') or {}).get('Name',''))
   for gid in (m.get('Assocs') or {}).get('Attributes',[]) or []: owners.setdefault(gid,set()).add(mn)
  for f in es:
   a=f.get('Attributes') or {}; pr=params(f,by)
   if f.get('ObjectClass')!='XModuleAttribute' or not (str(a.get('BusinessType','')).lower()=='htmlframe' or str(pr.get('Tag','')).upper()=='IFRAME'):continue
   sel=frame_selector(pr); module_names=set(owners.get(f.get('Surrogate'),set()))
   for gid in (f.get('Assocs') or {}).get('Module',[]) or []:
    m=by.get(gid) or {}; mn=str((m.get('Attributes') or {}).get('Name',''))
    if mn:module_names.add(mn)
   # descendants under frame attribute hierarchy
   stack=list((f.get('Assocs') or {}).get('Attributes',[]) or []); seen=set()
   while stack:
    gid=stack.pop()
    if gid in seen:continue
    seen.add(gid); c=by.get(gid) or {}
    if c.get('ObjectClass')!='XModuleAttribute':continue
    ca=c.get('Attributes') or {}; cp=params(c,by)
    rows.append({'application':app_for(p),'sourceFile':p.name,'module':' | '.join(sorted(module_names)),'frameField':a.get('Name',''),'frameGuid':f.get('Surrogate',''),'frameStrategy':sel['strategy'],'frameValue':sel['value'],'frameSourceProperty':sel['sourceProperty'],'controlField':ca.get('Name',''),'controlGuid':gid,'businessType':ca.get('BusinessType',''),'properties':cp})
    stack.extend((c.get('Assocs') or {}).get('Attributes',[]) or [])
 OUT.parent.mkdir(parents=True,exist_ok=True); OUT.write_text(json.dumps(rows,indent=2),encoding='utf8')
 summary={}
 for app in sorted(set(r['application'] for r in rows)):
  rr=[r for r in rows if r['application']==app]; summary[app]={'frameScopedControls':len(rr),'frames':len(set((r['sourceFile'],r['module'],r['frameGuid']) for r in rr))}
 print(json.dumps({'rows':len(rows),'applications':summary,'output':str(OUT.relative_to(ROOT))},indent=2))
if __name__=='__main__':main(sys.argv[1:])
