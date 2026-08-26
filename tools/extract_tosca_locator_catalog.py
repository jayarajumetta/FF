#!/usr/bin/env python3
from __future__ import annotations
import gzip, json, sys, re
from pathlib import Path

ROOT=Path(__file__).resolve().parents[1]
BASE=ROOT/'Artifacts'/'ToscaLocatorPropertyCatalog.json'
OUT=ROOT/'Artifacts'/'ToscaLocatorPropertyCatalog.v52.json'

RELEVANT={
    'Id','Name','Tag','DuckCreekId','attributes_data-testid','attributes_id','ClassName','ConstraintIndex','XPath','RelativeId',
    'InnerText','Label','AssociatedLabel','Title','Placeholder','aria-label','Role','type','href','AutomationId','data-automation-id'
}


def parse_self_healing(raw: str) -> dict[str,str]:
    if not raw: return {}
    try: data=json.loads(raw)
    except Exception: return {}
    vals=((data.get('HealingParameters') or {}).get('$values') or [])
    out={}
    for row in vals:
        name=str(row.get('Name','')).strip(); value=str(row.get('Value','')).strip()
        if name and value and value not in ('<No label associated>','None'):
            out.setdefault(name,value)
    return out


def extract(path: Path) -> list[dict]:
    opener=gzip.open if path.suffix.lower()=='.tsu' else open
    with opener(path,'rt',encoding='utf-8') as f: entities=json.load(f)['Entities']
    by={e['Surrogate']:e for e in entities}
    rows=[]
    for e in entities:
        if e.get('ObjectClass')!='XModuleAttribute': continue
        a=e.get('Attributes') or {}; ass=e.get('Assocs') or {}
        mods=[]
        for gid in ass.get('Module',[]):
            m=by.get(gid) or {}; name=(m.get('Attributes') or {}).get('Name','')
            if name: mods.append(name)
        props={}
        self_heal={}
        for gid in ass.get('Properties',[]):
            x=by.get(gid) or {}
            if x.get('ObjectClass')!='XParam': continue
            xa=x.get('Attributes') or {}; name=str(xa.get('Name','')).strip(); value=str(xa.get('Value','')).strip()
            if name=='SelfHealingData':
                self_heal.update(parse_self_healing(value)); continue
            if name in RELEVANT and value:
                props[name]=value
        # Self-healing technical IDs are valuable Tosca evidence; direct XParams win.
        for k,v in self_heal.items():
            if k in RELEVANT or k.startswith('attributes_'):
                props.setdefault(k,v)
        if not props:
            # retain Tag-only candidates if the tag was present solely in self-healing data
            tag=self_heal.get('Tag')
            if tag: props['Tag']=tag
        rows.append({
            'sourceFile':path.name,
            'module':' | '.join(mods),
            'field':a.get('Name',''),
            'description':a.get('Description',''),
            'businessType':a.get('BusinessType',''),
            'properties':props,
        })
    return rows


def signature(r:dict)->str:
    return json.dumps([r.get('sourceFile'),r.get('module'),r.get('field'),r.get('businessType'),sorted((r.get('properties') or {}).items())],sort_keys=True)


def main():
    if len(sys.argv)<2:
        print('Usage: extract_tosca_locator_catalog.py <raw .tsu> [more .tsu ...]',file=sys.stderr); return 2
    base=json.loads(BASE.read_text(encoding='utf-8')) if BASE.exists() else []
    merged=list(base); seen={signature(r) for r in merged}
    stats={}
    for arg in sys.argv[1:]:
        p=Path(arg); rows=extract(p); added=0
        for r in rows:
            sig=signature(r)
            if sig in seen: continue
            seen.add(sig); merged.append(r); added+=1
        stats[p.name]={'extracted':len(rows),'added':added}
    OUT.write_text(json.dumps(merged,indent=2),encoding='utf-8')
    report={'version':'52.0','baseRows':len(base),'finalRows':len(merged),'sources':stats,'output':str(OUT.relative_to(ROOT))}
    (ROOT/'Artifacts'/'V52ToscaLocatorCatalogMerge.json').write_text(json.dumps(report,indent=2),encoding='utf-8')
    print(json.dumps(report,indent=2)); return 0
if __name__=='__main__': raise SystemExit(main())
