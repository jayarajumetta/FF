#!/usr/bin/env python3
from __future__ import annotations
import gzip, json, sys, hashlib
from pathlib import Path

ROOT=Path(__file__).resolve().parents[1]
OUT=ROOT/'Artifacts'/'ToscaLocatorPropertyCatalog.v54.raw.json'
REPORT=ROOT/'Artifacts'/'V54RawLocatorCatalog.json'
RELEVANT={
 'Id','Name','Tag','DuckCreekId','attributes_data-testid','attributes_id','ClassName','ConstraintIndex','XPath','RelativeId',
 'InnerText','Label','AssociatedLabel','fieldref','FieldRef','attributes_fieldref','data-fieldref','Title','Placeholder','aria-label','Role','type','href','AutomationId','data-automation-id'
}

def parse_self_healing(raw:str)->dict[str,str]:
    if not raw:return {}
    try:data=json.loads(raw)
    except Exception:return {}
    vals=((data.get('HealingParameters') or {}).get('$values') or [])
    out={}
    for row in vals:
        n=str(row.get('Name','')).strip(); v=str(row.get('Value','')).strip()
        if n and v and v not in ('<No label associated>','None'):out.setdefault(n,v)
    return out

def load(path:Path):
    with gzip.open(path,'rt',encoding='utf-8') as f:return json.load(f).get('Entities',[])

def extract(path:Path)->list[dict]:
    entities=load(path); by={e.get('Surrogate'):e for e in entities}
    source_hash=hashlib.sha256(path.read_bytes()).hexdigest()
    # Module names can be linked either from attribute -> Module or Module -> Attributes.
    owner={}
    for m in entities:
        if m.get('ObjectClass') not in ('XModule','ApiModule'):continue
        mn=str((m.get('Attributes') or {}).get('Name','')).strip()
        for key in ('Attributes','ModuleAttributes','Items'):
            for gid in (m.get('Assocs') or {}).get(key,[]) or []:
                if mn: owner.setdefault(gid,[]).append(mn)
    rows=[]
    for e in entities:
        if e.get('ObjectClass')!='XModuleAttribute':continue
        a=e.get('Attributes') or {}; ass=e.get('Assocs') or {}
        mods=list(owner.get(e.get('Surrogate'),[]))
        for gid in ass.get('Module',[]) or []:
            m=by.get(gid) or {}; n=str((m.get('Attributes') or {}).get('Name','')).strip()
            if n and n not in mods:mods.append(n)
        props={}; heal={}
        for gid in ass.get('Properties',[]) or []:
            x=by.get(gid) or {}
            if x.get('ObjectClass')!='XParam':continue
            xa=x.get('Attributes') or {}; n=str(xa.get('Name','')).strip(); v=str(xa.get('Value','')).strip()
            if n=='SelfHealingData':heal.update(parse_self_healing(v));continue
            if n in RELEVANT and v:props[n]=v
        for k,v in heal.items():
            if k in RELEVANT or k.startswith('attributes_'):props.setdefault(k,v)
        if not props and heal.get('Tag'):props['Tag']=heal['Tag']
        rows.append({
          'sourceFile':path.name,'sourceSha256':source_hash,
          'module':' | '.join(dict.fromkeys(mods)),'field':a.get('Name',''),'description':a.get('Description',''),
          'businessType':a.get('BusinessType',''),'moduleAttributeGuid':e.get('Surrogate',''),'properties':props
        })
    return rows

def sig(r):
    return json.dumps([r.get('moduleAttributeGuid'),r.get('module'),r.get('field'),r.get('businessType'),sorted((r.get('properties') or {}).items())],sort_keys=True)

def collect(args):
    paths=[]
    for arg in args:
        p=Path(arg)
        if p.is_dir(): paths.extend(x for x in sorted(p.rglob('*.tsu')) if '__MACOSX' not in x.parts and not x.name.startswith('._'))
        elif p.suffix.lower()=='.tsu':paths.append(p)
    return list(dict.fromkeys(paths))

def main():
    paths=collect(sys.argv[1:])
    if not paths:
        print('Usage: extract_raw_tosca_locator_catalog_v54.py <raw-dir-or-tsu> ...',file=sys.stderr);return 2
    merged=[]; seen=set(); stats={}
    for p in paths:
        rows=extract(p); added=0
        for r in rows:
            s=sig(r)
            if s in seen:continue
            seen.add(s);merged.append(r);added+=1
        stats[p.name]={'xModuleAttributes':len(rows),'uniqueAdded':added,'sha256':hashlib.sha256(p.read_bytes()).hexdigest()}
    OUT.parent.mkdir(parents=True,exist_ok=True);OUT.write_text(json.dumps(merged,indent=2),encoding='utf-8')
    rep={'version':'54.0','sourcePolicy':'RAW_TOSCA_ONLY','rawFiles':len(paths),'locatorPropertyRows':len(merged),'sources':stats,'output':str(OUT.relative_to(ROOT))}
    REPORT.write_text(json.dumps(rep,indent=2),encoding='utf-8');print(json.dumps(rep,indent=2));return 0
if __name__=='__main__':raise SystemExit(main())
