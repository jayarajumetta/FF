#!/usr/bin/env python3
import json,re
from pathlib import Path
ROOT=Path(__file__).resolve().parents[1]; F=ROOT/'Artifacts'/'ToscaFrameContexts.v56.json'; D=ROOT/'Artifacts'/'LocatorFallbackCatalogs'
def norm(s):return re.sub(r'[^a-z0-9]+','',s.lower())
rows=json.loads(F.read_text())
for appfile in D.glob('CommercialLines*.json'):
 if appfile.name=='LocatorFallbackCoverage.json':continue
 d=json.loads(appfile.read_text()); app=d['application']; rr=[r for r in rows if r['application']==app]
 # exact source file+field is strongest; module is used to disambiguate repeated field names
 by={}
 for r in rr:
  by.setdefault((r['sourceFile'].lower(),norm(r['controlField'])),[]).append(r)
 enriched=0
 for ctl in d['controls']:
  for c in ctl.get('candidates',[]):
   matches=by.get((c.get('sourceFile','').lower(),norm(c.get('sourceField',''))),[])
   if not matches:continue
   cm=norm(c.get('sourceModule',''))
   best=next((r for r in matches if norm(r['module']) and (norm(r['module']) in cm or cm in norm(r['module']))),matches[0])
   c['frameStrategy']=best['frameStrategy'];c['frameValue']=best['frameValue'];c['frameField']=best['frameField'];c['frameSourceProperty']=best['frameSourceProperty']; enriched+=1
 d['version']='56.0';d['frameAwareCandidates']=enriched
 appfile.write_text(json.dumps(d,indent=2))
 print(app,enriched)
