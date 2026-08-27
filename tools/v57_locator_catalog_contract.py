#!/usr/bin/env python3
"""v57 post-processor for v56 raw-Tosca fallback catalogs.

Preserves the proven Page.Control mapping from v56 while enforcing the v57 runtime hierarchy:
fieldref(unique physical ModuleAttribute) -> id -> name -> testid -> associated label -> semantic role
-> relationship -> source occurrence/index. CL|DC raw-only DuckCreekId candidates are removed.
"""
from __future__ import annotations
import json,re
from pathlib import Path
from collections import defaultdict,Counter
ROOT=Path(__file__).resolve().parents[1]
RAW=ROOT/'Artifacts'/'ToscaLocatorPropertyCatalog.v54.raw.json'
CAT=ROOT/'Artifacts'/'LocatorFallbackCatalogs'
APPS={
 'CommercialLines.ExpertQuote':('CL_EQ','38668CB4-6566-434E-90C3-2681457CA59BCL-EQ Total'),
 'CommercialLines.DuckCreek':('CL-DC',),
 'PersonalLines.DuckCreek':('PL_DC',),
}

def raw_entries(app,rows):
 p=tuple(x.lower() for x in APPS[app])
 return [e for e in rows if str(e.get('sourceFile','')).lower().startswith(p)]

def fieldref_uniqueness(entries):
 vals=defaultdict(set)
 for e in entries:
  p=e.get('properties') or {}
  v=str(p.get('attributes_fieldref') or p.get('fieldref') or p.get('FieldRef') or p.get('data-fieldref') or '').strip()
  if v:
   vals[v].add(str(e.get('moduleAttributeGuid') or f"{e.get('sourceFile')}|{e.get('module')}|{e.get('field')}"))
 return {v for v,ids in vals.items() if len(ids)==1}, {v:len(ids) for v,ids in vals.items()}

def candidate_fieldref(c):
 if str(c.get('strategy','')).lower()=='fieldref': return str(c.get('value','')).strip()
 if str(c.get('sourceProperty','')).lower() in {'attributes_fieldref','fieldref','data-fieldref'}:
  v=str(c.get('value','')).strip()
  m=re.search(r'\[(?:data-)?fieldref=\\?"([^"\\]+)',v,re.I)
  return m.group(1) if m else ''
 return ''

def rank(c):
 s=str(c.get('strategy','')).lower(); pick=str(c.get('pick','unique')).lower()
 if s=='fieldref': return 1000
 if s=='id': return 900
 if s=='name': return 800
 if s=='testid': return 700
 if s in {'associatedlabel','label'}: return 600
 if s=='role': return 500
 if c.get('anchorStrategy'): return 400
 if s=='css' and pick=='unique': return 350
 if pick in {'first','nth','last'}: return 250
 if s=='xpath': return 200
 if s=='text': return 150
 if s=='duckcreekid': return 50
 return 100

def sig(c):
 return '|'.join(str(c.get(k,'')).lower() for k in ('strategy','value','role','anchorStrategy','anchorValue','frameStrategy','frameValue','pick','index','exact','hasText'))

def process(app,cat,unique_fieldrefs):
 removed_duck=converted_fieldref=converted_label=role_fixes=0
 for ctl in cat.get('controls',[]):
  out=[]; seen=set()
  for original in ctl.get('candidates',[]):
   c=dict(original)
   s=str(c.get('strategy','')).lower()
   # CL|DC: DuckCreekId from Tosca metadata is not browser evidence. Do not generate/use it in v57 catalogs.
   if app=='CommercialLines.DuckCreek' and s=='duckcreekid':
    removed_duck+=1; continue
   fv=candidate_fieldref(c)
   if fv and fv in unique_fieldrefs:
    c['strategy']='fieldref'; c['value']=fv; c['sourceProperty']=c.get('sourceProperty') or 'attributes_fieldref'
    c['reason']='v57 unique raw-Tosca fieldref/model binding; highest Duck Creek technical locator priority.'
    c['confidence']=max(float(c.get('confidence',0)),0.985)
    converted_fieldref+=1
   # Labels for actual form controls resolve to the associated DOM control, not accessibility-tree guesses.
   tag=str(c.get('expectedTag','')).lower(); bt=str(c.get('businessType','')).lower(); sp=str(c.get('sourceProperty','')).lower()
   if s=='label' and (sp=='associatedlabel' or tag in {'input','select','textarea'} or bt in {'textbox','checkbox','radiobutton','combobox','editablecombobox'}):
    c['strategy']='associatedlabel'; converted_label+=1
    c['reason']='v57 label-to-associated-control resolution (for/id, nested control, or source-backed sibling).'
   # Actual HTML tag semantics override Tosca BusinessType classification.
   if str(c.get('strategy','')).lower()=='role':
    if tag=='a' and c.get('role')!='link': c['role']='link'; role_fixes+=1
    elif tag=='button' and c.get('role')!='button': c['role']='button'; role_fixes+=1
   k=sig(c)
   if k in seen: continue
   seen.add(k); out.append(c)
  out.sort(key=lambda x:(rank(x),int(x.get('matchScore',0)),float(x.get('confidence',0))),reverse=True)
  ctl['candidates']=out[:40]
 cat['version']='57.0'
 cat['locatorPriority']='unique fieldref > stable raw HTML id > stable name > application-supported test id > associated label control > DOM-supported role/name > relationship > source occurrence/index'
 cat['frameResolution']='raw HtmlFrame is hint; runtime probes frame briefly, else top document; successful Page.Control scope cached'
 return {'removedRawDuckCreekId':removed_duck,'uniqueFieldrefCandidates':converted_fieldref,'associatedLabelCandidates':converted_label,'tagSemanticRoleFixes':role_fixes}

def main():
 rows=json.loads(RAW.read_text())
 summary={'release':'v57','applications':{},'strategyCounts':{}}
 counts=Counter()
 for app in APPS:
  path=CAT/f'{app}.json'; data=json.loads(path.read_text())
  unique,allcounts=fieldref_uniqueness(raw_entries(app,rows))
  stats=process(app,data,unique)
  stats['uniqueRawFieldrefValues']=len(unique); stats['allRawFieldrefValues']=len(allcounts)
  path.write_text(json.dumps(data,indent=2)+'\n')
  summary['applications'][app]=stats
  for ctl in data['controls']:
   for c in ctl.get('candidates',[]): counts[c.get('strategy','')]+=1
 summary['strategyCounts']=dict(counts.most_common())
 (CAT/'LocatorFallbackCoverage.v57.json').write_text(json.dumps(summary,indent=2)+'\n')
 print(json.dumps(summary,indent=2))
if __name__=='__main__': main()
